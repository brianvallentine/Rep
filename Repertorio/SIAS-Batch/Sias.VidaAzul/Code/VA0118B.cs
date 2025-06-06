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
using Sias.VidaAzul.DB2.VA0118B;

namespace Code
{
    public class VA0118B
    {
        public bool IsCall { get; set; }

        public VA0118B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *   FUNCAO .................  INTEGRA V0PROPOSTAVA               *      */
        /*"      *   ANALISTA/PROGRAMADOR....  FONSECA                            *      */
        /*"      *   PROGRAMA ...............  VA0118B                            *      */
        /*"      *   DATA ...................  12/01/95                           *      */
        /*"      ******************************************************************      */
        /*"      *                         ALTERACOES                             *      */
        /*"      ******************************************************************      */
        /*"      *  VERSAO 103 - DEMANDA 571.983 / RITM0004281                    *      */
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
        /*"      *  EM 08/10/2024 - TERCIO CARVALHO                               *      */
        /*"      *                                        PROCURE POR V.103       *      */
        /*"      ******************************************************************      */
        /*"      *  VERSAO 102 - INCIDENTE 600024                                 *      */
        /*"      *             - TRATAR -811 NA CONSULTA DA VG_CRITICA_PROPOSTA   *      */
        /*"      *                                                                *      */
        /*"      *  EM 22/08/2024 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.102       *      */
        /*"      ******************************************************************      */
        /*"      *  VERSAO 101 - SOLICITACAO RITM0000172                          *      */
        /*"      *             - CASO ACATAMENTO = 'S' LIBERAR PARA EMISSAO       *      */
        /*"      *             - CASO COD-MSG-CRITICA SEJA TIPO INFORMATIVO NAO   *      */
        /*"      *               ALTERAR SITUACAO PROPOSTAS_VA P/ '1' = EM CRITICA*      */
        /*"      *                                                                *      */
        /*"      *  EM 19/08/2024 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.101       *      */
        /*"      ******************************************************************      */
        /*"      *  VERSAO 100 - DEMANDA 571.176 - DPS ELETRONICA                 *      */
        /*"      *             - VERIFICA SE O CERTIFICADO DEVERAH TER DPS ELETRO-*      */
        /*"      *               NICA PREENCHIDA. CASO POSITIVO: DEVERAH AGUARDAR *      */
        /*"      *               RESULTADO DA DPS ELETRONICA, QUE SERAH RECEBIDA  *      */
        /*"      *               PELO SIAS NA TABELA VG_DPS_PROPOSTA. CASO NEGATI-*      */
        /*"      *               VO: O CERTIFICADO ESTARAH LIBERADO PARA EMISSAO  *      */
        /*"      *                                                                *      */
        /*"      *  EM 05/08/2024 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.100       *      */
        /*"      ******************************************************************      */
        /*"      *  VERSAO  99 - DEMANDA 484.074                                  *      */
        /*"      *             - RETIRADA DA CRITICA DE DPS PARA OS PRODUTOS      *      */
        /*"      *               VIDA PROTECAO EXECUTIVA.                         *      */
        /*"      *                                                                *      */
        /*"      *  EM 11/01/2024 - TERCIO CARVALHO                               *      */
        /*"      *                                        PROCURE POR V.99        *      */
        /*"      ******************************************************************      */
        /*"      *  VERSAO  98 - DEMANDA 471.118                                  *      */
        /*"      *             - CORRECAO PERFORM 8595-00-VERIFICA-CRTCA-PEND     *      */
        /*"      *               FALTOU SECTION NA 8600-PRIMEIRA-COBRANCA O QUE   *      */
        /*"      *               PROVOCOU INVASAO DE ROTINA.                      *      */
        /*"      *             - CORRECAO 8120-VERIFICA-PROPAUTOM                 *      */
        /*"      *               SUBSTITUICAO PERFORM DELA MESMA POR GO TO        *      */
        /*"      *             - SECCIONAR TODAS AS ROTINAS.                      *      */
        /*"      *                                                                *      */
        /*"      *  EM 23/02/2023 - BRICE HO                                      *      */
        /*"      *                                        PROCURE POR V.98        *      */
        /*"      ******************************************************************      */
        /*"V.97  *  VERSAO  97 - DEMANDA 402.982                                  *      */
        /*"      *             - RETIRAR GRAVACAO DE ERROS DA PROPOSTA DA TABELA  *      */
        /*"      *               ERROS_PROP_VIDAZUL                               *      */
        /*"      *             - GRAVAR ERROS DA PROPOSTA NA NOVA TABELA          *      */
        /*"      *               VG_CRITICA_PROPOSTA PARA POSTERIOR ANALISE DO    *      */
        /*"      *               GESTOR NO ATALHO 04.23                           *      */
        /*"      *             - RETORNA SITUACAO DA PROPOSTA PARA EM CRITICA CASO*      */
        /*"      *               SEJA ENCONTRADO ALGUMA CRITICA PENDENTE          *      */
        /*"      *                                                                *      */
        /*"      *  EM 16/02/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.97        *      */
        /*"      ******************************************************************      */
        /*"V.96  *  VERSAO 96  - PLD Circular 612 - Fase 2 -  Demanda 379166      *      */
        /*"      *             - EXCLUIR CRITICA DE PEPS, JA QUE A MESMA FOI      *      */
        /*"      *               SUBSTITUIDA PELA AVALIACAO DE RISCO NO VA0601B   *      */
        /*"      *             - INCLUIDO ROTINA SPBVG001 PARA CONSULTA DE RISCO  *      */
        /*"      *               DA PROPOSTA. CASO EXISTA RISCO CRITICO NAO       *      */
        /*"      *               SOLUCIONADO AGUARDA CONCLUSAO DO TRATAMENTO      *      */
        /*"      *               PELO GESTOR, CASO NAO ENCONTRE RISCO CADASTRADO, *      */
        /*"      *               VERIFICA SE MOTOR GEROU CLASSIFICACAO, SE GEROU  *      */
        /*"      *               INSERE CLASSIFICACAO, SE NAO GEROU INFORMA QUE A *      */
        /*"      *               PROPOSTA SERAH EMITIDA SEM ANALISE DE RISCO      *      */
        /*"      *                                                                *      */
        /*"      *   EM 31/07/2022 - ELIERMES OLIVEIRA   PROCURE POR V.96         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.95  *   VERSAO 95 - DEMANDA 390.816                                  *      */
        /*"      *             - ACERTO PARA NAO ALTERAR A DATA-PROXVEN,          *      */
        /*"      *               ESTAVA MODIFICANDO A DATA-PROXVEN CAUSANDO A     *      */
        /*"      *               MIGRA��O ANTES DO PERIODO CORRETO                *      */
        /*"      *               MANTER EM R$ 100MIL                              *      */
        /*"      *             - RETIRAR ACESSO A GE_RETENCAO_PROPOSTA            *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/06/2022 - THIAGO BLAIER       PROCURE POR V.95         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   DEMAIS HISTORICOS DE MANUTENCOES - VIDE FINAL DO PROGRMA     *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WIND                             PIC S9(04)    COMP VALUE +0*/
        public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-QT-RISCO-CRITICO              PIC 9(007) VALUE 0.*/
        public IntBasis WS_QT_RISCO_CRITICO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01  WS-QT-EM-CRITICA                 PIC 9(007) VALUE 0.*/
        public IntBasis WS_QT_EM_CRITICA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01  WS-QT-EMISSAO-S-RISCO            PIC 9(007) VALUE 0.*/
        public IntBasis WS_QT_EMISSAO_S_RISCO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01  WS-QT-EMISSAO-C-RISCO            PIC 9(007) VALUE 0.*/
        public IntBasis WS_QT_EMISSAO_C_RISCO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01  WS-QT-LIBERADO-EMISSAO           PIC 9(007) VALUE 0.*/
        public IntBasis WS_QT_LIBERADO_EMISSAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01  WS-ERRO-VG009                    PIC 9(001) VALUE 0.*/
        public IntBasis WS_ERRO_VG009 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"01  WS-QTD-RISCO-GRAVADO             PIC S9(4) USAGE COMP.*/
        public IntBasis WS_QTD_RISCO_GRAVADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-PROGRAMA                      PIC X(008) VALUE SPACES.*/
        public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  WS-COD-CRITICA                   PIC 9(005) VALUE 0.*/
        public IntBasis WS_COD_CRITICA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01  WS-ERRO-COUNT                    PIC S9(04) VALUE +0 COMP.*/
        public IntBasis WS_ERRO_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WHOST-VLPREMIO-W         PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VLPREMIO_W { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-VLPREMIO           PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  CALENDAR-DATA-CALENDARIO         PIC X(10).*/
        public StringBasis CALENDAR_DATA_CALENDARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WHOST-PROXIMA-DATA               PIC X(10).*/
        public StringBasis WHOST_PROXIMA_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WHOST-DATA-MOVIMENTO             PIC X(10).*/
        public StringBasis WHOST_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  W03-VENCIMENTO                   PIC X(10).*/
        public StringBasis W03_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  CALENDAR-DIA-SEMANA              PIC X(10).*/
        public StringBasis CALENDAR_DIA_SEMANA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  CALENDAR-FERIADO                 PIC X(10).*/
        public StringBasis CALENDAR_FERIADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WHOST-DTINIVIG                   PIC X(10).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WHOST-SIT-PROP-FIDELIZ           PIC X(03).*/
        public StringBasis WHOST_SIT_PROP_FIDELIZ { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
        /*"01  WHOST-SITUACAO-ENVIO             PIC X(01).*/
        public StringBasis WHOST_SITUACAO_ENVIO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  WS-FIM-RISCO                     PIC X(003)  VALUE SPACES.*/
        public StringBasis WS_FIM_RISCO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01  WS-NUM-CERTIFICADO-RISCO         PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis WS_NUM_CERTIFICADO_RISCO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01  WS-SIT-REGISTRO-RISCO            PIC X(01)   VALUE SPACES.*/
        public StringBasis WS_SIT_REGISTRO_RISCO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"01  WS-AC-TOT-RISCO                  PIC 9(013)V99 VALUE 0.*/
        public DoubleBasis WS_AC_TOT_RISCO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"01  WS-RESTITUICAO                   PIC  X(001) VALUE 'N'.*/

        public SelectorBasis WS_RESTITUICAO { get; set; } = new SelectorBasis("001", "N")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-SIM-RESTITUIDO                          VALUE 'S'. */
							new SelectorItemBasis("WS_SIM_RESTITUIDO", "S"),
							/*" 88 WS-NAO-RESTITUIDO                          VALUE 'N'. */
							new SelectorItemBasis("WS_NAO_RESTITUIDO", "N")
                }
        };

        /*"01  WS-DECLINADO                     PIC  X(001) VALUE 'N'.*/

        public SelectorBasis WS_DECLINADO { get; set; } = new SelectorBasis("001", "N")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-SIM-DECLINADO                           VALUE 'S'. */
							new SelectorItemBasis("WS_SIM_DECLINADO", "S"),
							/*" 88 WS-NAO-DECLINADO                           VALUE 'N'. */
							new SelectorItemBasis("WS_NAO_DECLINADO", "N")
                }
        };

        /*"01  WS-PROPOSTA-FIDELIZ              PIC  X(001) VALUE 'N'.*/

        public SelectorBasis WS_PROPOSTA_FIDELIZ { get; set; } = new SelectorBasis("001", "N")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-SIM-PROPOSTA                            VALUE 'S'. */
							new SelectorItemBasis("WS_SIM_PROPOSTA", "S"),
							/*" 88 WS-NAO-PROPOSTA                            VALUE 'N'. */
							new SelectorItemBasis("WS_NAO_PROPOSTA", "N")
                }
        };

        /*"01  WS-PRODUTO-SIVPF                 PIC  X(001) VALUE 'N'.*/

        public SelectorBasis WS_PRODUTO_SIVPF { get; set; } = new SelectorBasis("001", "N")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-SIM-PRODU-SIVPF                         VALUE 'S'. */
							new SelectorItemBasis("WS_SIM_PRODU_SIVPF", "S"),
							/*" 88 WS-NAO-PRODU-SIVPF                         VALUE 'N'. */
							new SelectorItemBasis("WS_NAO_PRODU_SIVPF", "N")
                }
        };

        /*"01  WS-PRODUTO-PU                    PIC  X(001) VALUE 'S'.*/

        public SelectorBasis WS_PRODUTO_PU { get; set; } = new SelectorBasis("001", "S")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-PU-VIGENTE                              VALUE 'S'. */
							new SelectorItemBasis("WS_PU_VIGENTE", "S"),
							/*" 88 WS-PU-ENCERRADO                            VALUE 'N'. */
							new SelectorItemBasis("WS_PU_ENCERRADO", "N")
                }
        };

        /*"01  WS-BCO-RELAT                     PIC S9(4) USAGE COMP.*/
        public IntBasis WS_BCO_RELAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-VLR-RELAT                    PIC S9(10)V9(5) USAGE COMP-3*/
        public DoubleBasis WS_VLR_RELAT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"01  WS-NUM-ORDEM-RELAT               PIC S9(15)V    USAGE COMP-3*/
        public DoubleBasis WS_NUM_ORDEM_RELAT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01  WS-TXT-NEGA-PROPOSTA             PIC  X(61) VALUE    'PROPOSTA NEGADA PELA CONSULTA AO SERVICO DE SUBSCRICAO.'.*/
        public StringBasis WS_TXT_NEGA_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "61", "X(61)"), @"PROPOSTA NEGADA PELA CONSULTA AO SERVICO DE SUBSCRICAO.");
        /*"01  WS-TXT-NEGA-CEM-MIL.*/
        public VA0118B_WS_TXT_NEGA_CEM_MIL WS_TXT_NEGA_CEM_MIL { get; set; } = new VA0118B_WS_TXT_NEGA_CEM_MIL();
        public class VA0118B_WS_TXT_NEGA_CEM_MIL : VarBasis
        {
            /*" 03 FILLER                           PIC  X(37) VALUE    'PROPOSTA NEGADA, VALOR DO ACUMULO DE '.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "37", "X(37)"), @"PROPOSTA NEGADA, VALOR DO ACUMULO DE ");
            /*" 03 FILLER                           PIC  X(24) VALUE    'RISCO MAIOR QUE CEM MIL.'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"RISCO MAIOR QUE CEM MIL.");
            /*"01  WS-TXT-NEGA-600-MIL.*/
        }
        public VA0118B_WS_TXT_NEGA_600_MIL WS_TXT_NEGA_600_MIL { get; set; } = new VA0118B_WS_TXT_NEGA_600_MIL();
        public class VA0118B_WS_TXT_NEGA_600_MIL : VarBasis
        {
            /*" 03 FILLER                           PIC  X(37) VALUE    'PROPOSTA NEGADA, VALOR DO ACUMULO DE '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "37", "X(37)"), @"PROPOSTA NEGADA, VALOR DO ACUMULO DE ");
            /*" 03 FILLER                           PIC  X(24) VALUE    'RISCO MAIOR QUE 600 MIL.'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"RISCO MAIOR QUE 600 MIL.");
            /*"01 WS-TXT-SEM-CONSULTA               PIC  X(61) VALUE    'PROPOSTA NEGADA SEM RETORNO DO SERVICO DE SUBSCRICAO.'.*/
        }
        public StringBasis WS_TXT_SEM_CONSULTA { get; set; } = new StringBasis(new PIC("X", "61", "X(61)"), @"PROPOSTA NEGADA SEM RETORNO DO SERVICO DE SUBSCRICAO.");
        /*"01 WS-TXT-ACEITA-PROPOSTA            PIC  X(61) VALUE    'PROPOSTA ACEITA.'.*/
        public StringBasis WS_TXT_ACEITA_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "61", "X(61)"), @"PROPOSTA ACEITA.");
        /*"01  VIND-ORIGEM                      PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-FAIXA-RENDA                 PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_FAIXA_RENDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-CRM                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_CRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTMOVTO                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DATSEL                      PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DATSEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CODEMP                      PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CODPRP                      PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_CODPRP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NUMBIL                      PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-VLVARMON                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_VLVARMON { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTQITBCO                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-ESTR-COBR                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_ESTR_COBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-ORIG-PRODU                  PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_ORIG_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TEM-SAF                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TEM-CDG                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_TEM_CDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-AGENCIADOR                  PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CODRELAT                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_CODRELAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDAGE                           PIC S9(4) COMP.*/
        public IntBasis INDAGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDOPR                           PIC S9(4) COMP.*/
        public IntBasis INDOPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDNUM                           PIC S9(4) COMP.*/
        public IntBasis INDNUM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDDIG                           PIC S9(4) COMP.*/
        public IntBasis INDDIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDCARTAO                        PIC S9(4) COMP.*/
        public IntBasis INDCARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-ACEITACAO                   PIC S9(4) COMP.*/
        public IntBasis VIND_ACEITACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DATA-DECLINIO               PIC S9(4) COMP.*/
        public IntBasis VIND_DATA_DECLINIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTENV                       PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_DTENV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTRET                       PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_DTRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CODRET                      PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NREQ                        PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_NREQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-SEQUEN                      PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_SEQUEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NLOTE                       PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_NLOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTCRED                      PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_DTCRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-STATUS                      PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_STATUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-VLCRED                      PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_VLCRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  CONDTE-IEA                       PIC S9(005)V9(02) COMP-3.*/
        public DoubleBasis CONDTE_IEA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"01  CONDTE-IPA                       PIC S9(005)V9(02) COMP-3.*/
        public DoubleBasis CONDTE_IPA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"01  DESCON-PERC                      PIC S9(003)V9(04) COMP-3.*/
        public DoubleBasis DESCON_PERC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(04)"), 4);
        /*"01  DESCON-DTINIVIG                  PIC  X(010).*/
        public StringBasis DESCON_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  DESCON-VLPREMIO                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis DESCON_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  DESCON-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis DESCON_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  DESCON-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis DESCON_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  WHOST-COUNT                      PIC S9(4) COMP.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SIVPF-NR-PROPOSTA                PIC S9(15) COMP-3.*/
        public IntBasis SIVPF_NR_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  SIVPF-NR-SICOB                   PIC S9(15) COMP-3.*/
        public IntBasis SIVPF_NR_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  SIVPF-NR-IDENTIFI                PIC S9(15) COMP-3.*/
        public IntBasis SIVPF_NR_IDENTIFI { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  SIVPF-SIT-PROPOSTA               PIC  X(03).*/
        public StringBasis SIVPF_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
        /*"01  SIVPF-DTQITBCO                   PIC  X(10).*/
        public StringBasis SIVPF_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIVPF-DATA-CREDITO               PIC  X(10).*/
        public StringBasis SIVPF_DATA_CREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIVPF-VAL-PAGO                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis SIVPF_VAL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  SIVPF-OPCAO-COBER                PIC  X(01).*/
        public StringBasis SIVPF_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  SIVPF-COD-PLANO                  PIC S9(04) COMP.*/
        public IntBasis SIVPF_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  CONVER-NUM-SICOB                 PIC S9(15) COMP-3.*/
        public IntBasis CONVER_NUM_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  CONVER-NUM-PROPOSTA              PIC S9(15) COMP-3.*/
        public IntBasis CONVER_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0PARC-NRCERTIF                  PIC S9(15) COMP-3.*/
        public IntBasis V0PARC_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-NRCERTIF                  PIC S9(15) COMP-3.*/
        public IntBasis PROPVA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-NRPROPAZ                  PIC S9(13) COMP-3.*/
        public IntBasis PROPVA_NRPROPAZ { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  PROPVA-CODPRODU                  PIC S9(04) COMP.*/
        public IntBasis PROPVA_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-CODCLIEN                  PIC S9(09) COMP.*/
        public IntBasis PROPVA_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  PROPVA-OCOREND                   PIC S9(04) COMP.*/
        public IntBasis PROPVA_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-FONTE                     PIC S9(4) COMP.*/
        public IntBasis PROPVA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-AGECOBR                   PIC S9(4) COMP.*/
        public IntBasis PROPVA_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-OPCAO-COBER               PIC  X(1).*/
        public StringBasis PROPVA_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-DTQITBCO                  PIC  X(10).*/
        public StringBasis PROPVA_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTINICDG                  PIC  X(10).*/
        public StringBasis PROPVA_DTINICDG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTINISAF                  PIC  X(10).*/
        public StringBasis PROPVA_DTINISAF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-NRMATRVEN                 PIC S9(15) COMP-3.*/
        public IntBasis PROPVA_NRMATRVEN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-CODOPER                   PIC S9(4) COMP.*/
        public IntBasis PROPVA_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  DIFPAR-CODOPER                   PIC S9(4) COMP.*/
        public IntBasis DIFPAR_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-DTMOVTO                   PIC  X(10).*/
        public StringBasis PROPVA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTPROXVEN                 PIC  X(10).*/
        public StringBasis PROPVA_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTPROXVEN-S               PIC  X(10).*/
        public StringBasis PROPVA_DTPROXVEN_S { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTVENCTO                  PIC  X(10).*/
        public StringBasis PROPVA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTMINVEN                  PIC  X(10).*/
        public StringBasis PROPVA_DTMINVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-SITUACAO                  PIC  X(1).*/
        public StringBasis PROPVA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-SITUACAO-ORIGINAL         PIC  X(1).*/
        public StringBasis PROPVA_SITUACAO_ORIGINAL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-ACATAMENTO                PIC  X(1).*/
        public StringBasis PROPVA_ACATAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-NUM-APOLICE               PIC S9(13) COMP-3.*/
        public IntBasis PROPVA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  PROPVA-CODSUBES                  PIC S9(4) COMP.*/
        public IntBasis PROPVA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-OCORHIST                  PIC S9(4) COMP.*/
        public IntBasis PROPVA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-NRPARCEL                  PIC S9(4) COMP.*/
        public IntBasis PROPVA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-SIT-INTERF                PIC  X(1).*/
        public StringBasis PROPVA_SIT_INTERF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-TIMESTAMP                 PIC  X(26).*/
        public StringBasis PROPVA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"01  PROPVA-IDADE                     PIC S9(4) COMP.*/
        public IntBasis PROPVA_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-SEXO                      PIC  X(1).*/
        public StringBasis PROPVA_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-EST-CIV                   PIC  X(1).*/
        public StringBasis PROPVA_EST_CIV { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-COD-CRM                   PIC S9(4) COMP.*/
        public IntBasis PROPVA_COD_CRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-NRMATRFUN                 PIC S9(15) COMP-3.*/
        public IntBasis PROPVA_NRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-INRMATRFUN                PIC S9(4) COMP.*/
        public IntBasis PROPVA_INRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-NRPROPOS                  PIC S9(09) COMP.*/
        public IntBasis PROPVA_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  PROPVA-INRPROPOS                 PIC S9(04) COMP.*/
        public IntBasis PROPVA_INRPROPOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-DTADMIS                   PIC  X(10) VALUE SPACES.*/
        public StringBasis PROPVA_DTADMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  PROPVA-IDTADMIS                  PIC S9(04) COMP VALUE ZEROS*/
        public IntBasis PROPVA_IDTADMIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WPROPVA-DTADMIS                  PIC  X(10).*/
        public StringBasis WPROPVA_DTADMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WPROPVA-IDTADMIS                 PIC S9(04).*/
        public IntBasis WPROPVA_IDTADMIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)."));
        /*"01  PROPVA-CODCCT                    PIC S9(15) COMP-3.*/
        public IntBasis PROPVA_CODCCT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-ICODCCT                   PIC S9(4) COMP.*/
        public IntBasis PROPVA_ICODCCT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-CODUSU                    PIC  X(8).*/
        public StringBasis PROPVA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01  PROPVA-FAIXA-RENDA-IND           PIC  X(1).*/
        public StringBasis PROPVA_FAIXA_RENDA_IND { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-DATA                      PIC  X(10).*/
        public StringBasis PROPVA_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DPS-TITULAR               PIC  X(30).*/
        public StringBasis PROPVA_DPS_TITULAR { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"01  PROPVA-ORIGEM-PROPOSTA           PIC S9(04)        COMP.*/
        public IntBasis PROPVA_ORIGEM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PRODVG-CODPRODAZ                 PIC  X(03).*/
        public StringBasis PRODVG_CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
        /*"01  PRODVG-PERIPGTO                  PIC S9(04)        COMP.*/
        public IntBasis PRODVG_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PRODVG-ESTR-COBR                 PIC  X(10).*/
        public StringBasis PRODVG_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PRODVG-ORIG-PRODU                PIC  X(10).*/
        public StringBasis PRODVG_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PRODVG-AGENCIADOR                PIC S9(9)         COMP.*/
        public IntBasis PRODVG_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  PRODVG-TEM-SAF                   PIC  X(1).*/
        public StringBasis PRODVG_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PRODVG-TEM-CDG                   PIC  X(1).*/
        public StringBasis PRODVG_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PRODVG-CODRELAT                  PIC  X(8).*/
        public StringBasis PRODVG_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01  PRODVG-RISCO                     PIC  X(1).*/
        public StringBasis PRODVG_RISCO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PRODVG-COBERADIC-PREMIO          PIC  X(1).*/
        public StringBasis PRODVG_COBERADIC_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PRODVG-DESCONTO-ADESAO           PIC S9(003)V9(05) COMP-3.*/
        public DoubleBasis PRODVG_DESCONTO_ADESAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(05)"), 5);
        /*"01  PRODVG-SITPLANCEF                PIC  X(001).*/
        public StringBasis PRODVG_SITPLANCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  PRODVG-COD-PRODUTO               PIC S9(04)        COMP.*/
        public IntBasis PRODVG_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PRODVG-ARQ-FDCAP                 PIC S9(04)        COMP.*/
        public IntBasis PRODVG_ARQ_FDCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PRODVG-RAMO                      PIC S9(04)        COMP.*/
        public IntBasis PRODVG_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-IND-ARQFDCAP                  PIC S9(004)       COMP.*/
        public IntBasis WS_IND_ARQFDCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PRODVG-COD-RUBRICA               PIC S9(004)       COMP.*/
        public IntBasis PRODVG_COD_RUBRICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-IND-RUBRICA                   PIC S9(004)       COMP.*/
        public IntBasis WS_IND_RUBRICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-ATUALIZA-OPCPAGVA             PIC X(003)  VALUE SPACES.*/
        public StringBasis WS_ATUALIZA_OPCPAGVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01  PRODVG-CUSTOCAP-TOTAL            PIC  X(001).*/
        public StringBasis PRODVG_CUSTOCAP_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  PRODVG-CUSTOCAP-TOTAL-9          PIC  9(001).*/
        public IntBasis PRODVG_CUSTOCAP_TOTAL_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
        /*"01  OPCAOP-OPCAOPAG                  PIC  X(1).*/
        public StringBasis OPCAOP_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  OPCAOP-PERIPGTO                  PIC S9(4) COMP.*/
        public IntBasis OPCAOP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-DIA-DEB                   PIC S9(4) COMP.*/
        public IntBasis OPCAOP_DIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-AGECTADEB                 PIC S9(4) COMP.*/
        public IntBasis OPCAOP_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-OPRCTADEB                 PIC S9(4) COMP.*/
        public IntBasis OPCAOP_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-NUMCTADEB                 PIC S9(13) COMP-3.*/
        public IntBasis OPCAOP_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  OPCAOP-DIGCTADEB                 PIC S9(4) COMP.*/
        public IntBasis OPCAOP_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-CARTAOCRED                PIC  X(16) VALUE SPACES.*/
        public StringBasis OPCAOP_CARTAOCRED { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
        /*"01  V0AGCEF-COD-AGCOBR               PIC S9(4) COMP.*/
        public IntBasis V0AGCEF_COD_AGCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  COBERP-DTINIVIG                  PIC  X(10).*/
        public StringBasis COBERP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COBERP-DTTERVIG                  PIC  X(10).*/
        public StringBasis COBERP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COBERP-IMPMORNATU                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPMORACID                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPINVPERM                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPAMDS                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPDH                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPDIT                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLPREMIO                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMVG-DIF                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMVG_DIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMAP-DIF                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMAP_DIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  DIFPAR-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis DIFPAR_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLCUSTCAP                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPSEGCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLCUSTCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPSEGAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLCUSTAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IIMPSEGAUXF               PIC S9(04)    COMP.*/
        public IntBasis COBERP_IIMPSEGAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-IVLCUSTAUXF              PIC S9(04)    COMP.*/
        public IntBasis COBERP_IVLCUSTAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-QTTITCAP                 PIC S9(04)    COMP.*/
        public IntBasis COBERP_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-IQTTITCAP                PIC S9(04)    COMP.*/
        public IntBasis COBERP_IQTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0COBER-MINOCOR                 PIC S9(04)    COMP.*/
        public IntBasis V0COBER_MINOCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COMISI-VALADT                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COMISI_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  PARCOM-TIPCOM                   PIC  X(01).*/
        public StringBasis PARCOM_TIPCOM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  FUNDO-PCCOMCOR                  PIC S9(03)V99 COMP-3.*/
        public DoubleBasis FUNDO_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  V1RIND-PCIOF                    PIC S9(03)V99 COMP-3.*/
        public DoubleBasis V1RIND_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  V1RIND-DTINIVIG                 PIC  X(10).*/
        public StringBasis V1RIND_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V1APOL-RAMO                     PIC S9(04)    COMP.*/
        public IntBasis V1APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  FUNDO-PCCOMIND                   PIC S9(03)V99 COMP-3.*/
        public DoubleBasis FUNDO_PCCOMIND { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  FUNDO-PCCOMGER                   PIC S9(03)V99 COMP-3.*/
        public DoubleBasis FUNDO_PCCOMGER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  FUNDO-PCCOMSUP                   PIC S9(03)V99 COMP-3.*/
        public DoubleBasis FUNDO_PCCOMSUP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  FUNDO-PCCOMTOT                   PIC S9(03)V99 COMP-3.*/
        public DoubleBasis FUNDO_PCCOMTOT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  FUNDO-VALBASVG                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FUNDO_VALBASVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  FUNDO-VALBASAP                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FUNDO_VALBASAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  FUNDO-VLCOMISVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FUNDO_VLCOMISVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  FUNDO-VLCOMISAP                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FUNDO_VLCOMISAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  CLIENT-DTNASC                    PIC  X(10).*/
        public StringBasis CLIENT_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  CLIENT-DTNASC-I                  PIC S9(04)    COMP.*/
        public IntBasis CLIENT_DTNASC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  CLIENT-CGCCPF                    PIC S9(15)    COMP-3.*/
        public IntBasis CLIENT_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  CDGCOB-DTINIVIG                  PIC  X(010).*/
        public StringBasis CDGCOB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SAFCOB-DTINIVIG                  PIC  X(010).*/
        public StringBasis SAFCOB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  REPCDG-DTREF                     PIC  X(010).*/
        public StringBasis REPCDG_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  REPSAF-DTREF                     PIC  X(010).*/
        public StringBasis REPSAF_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  RELATO-CODRELAT                  PIC  X(008).*/
        public StringBasis RELATO_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  RELATO-NRPARCEL                  PIC S9(004) COMP VALUE +0.*/
        public IntBasis RELATO_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  RELATO-OPERACAO                  PIC S9(004) COMP VALUE +0.*/
        public IntBasis RELATO_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  RELATO-NUM-APOLICE               PIC S9(13)       COMP-3.*/
        public IntBasis RELATO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  RELATO-CODSUBES                  PIC S9(4)        COMP.*/
        public IntBasis RELATO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  RELATO-NUM-COPIAS                PIC S9(004)      COMP.*/
        public IntBasis RELATO_NUM_COPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  CLIROT-DTMOVABE                  PIC  X(010).*/
        public StringBasis CLIROT_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  FONTE-PROPAUTOM                  PIC S9(009)      COMP.*/
        public IntBasis FONTE_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  PROPAUTOM-BENEFI                 PIC S9(009)      COMP.*/
        public IntBasis PROPAUTOM_BENEFI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  APCORR-RAMO                      PIC S9(004)      COMP.*/
        public IntBasis APCORR_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  APCORR-DTINIVIG                  PIC  X(010).*/
        public StringBasis APCORR_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SUBGRU-CODSUBES                  PIC S9(004)      COMP.*/
        public IntBasis SUBGRU_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  HISCOBPR-IMP-MORNATU             PIC S9(013)V99   COMP-3.*/
        public DoubleBasis HISCOBPR_IMP_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  OPCPAGVI-PERI-PAGAMENTO          PIC S9(004)      COMP.*/
        public IntBasis OPCPAGVI_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SEGURVGA-NUM-APOLICE             PIC S9(013)V     COMP-3.*/
        public DoubleBasis SEGURVGA_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V"), 0);
        /*"01  SEGURVGA-NUM-ITEM                PIC S9(009)      COMP.*/
        public IntBasis SEGURVGA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WSISTEMA-DTMOVABE                PIC  X(010).*/
        public StringBasis WSISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOVABE                 PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-CURRDATE                 PIC  X(010).*/
        public StringBasis SISTEMA_CURRDATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOVABE2                PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOVABE3                PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MMFAIXA                          PIC S9(004)      COMP.*/
        public IntBasis MMFAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  MFAIXA                           PIC S9(004)      COMP.*/
        public IntBasis MFAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  MAGENCIADOR                      PIC S9(009)      COMP.*/
        public IntBasis MAGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  MDTMOVTO                         PIC  X(010).*/
        public StringBasis MDTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MMDTMOVTO                        PIC  X(010).*/
        public StringBasis MMDTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MCODOPER                         PIC S9(004)      COMP.*/
        public IntBasis MCODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  MDTREF                           PIC  X(010).*/
        public StringBasis MDTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MTPBENEF                         PIC  X(001).*/
        public StringBasis MTPBENEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  MTPINCLUS                        PIC  X(001).*/
        public StringBasis MTPINCLUS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  MNUM-MATRICULA                   PIC S9(015)      COMP-3.*/
        public IntBasis MNUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  MMNUM-MATRICULA                  PIC S9(015)      COMP-3.*/
        public IntBasis MMNUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  MAGECOBR                         PIC S9(04)       COMP.*/
        public IntBasis MAGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  MNUM-CTA-CORRENTE                PIC S9(017)      COMP-3.*/
        public IntBasis MNUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "17", "S9(017)"));
        /*"01  MDAC-CTA-CORRENTE                PIC  X(001).*/
        public StringBasis MDAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  MTXAPMA                          PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTXAPMA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  MTXAPIP                          PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTXAPIP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  MTXVG                            PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTXVG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  BENEF-NRBENEF                    PIC S9(04)       COMP.*/
        public IntBasis BENEF_NRBENEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  BENEF-NOMBENEF                   PIC X(40).*/
        public StringBasis BENEF_NOMBENEF { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  BENEF-GRAUPAR                    PIC X(10).*/
        public StringBasis BENEF_GRAUPAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  BENEF-PCTBENEF                   PIC S9(03)V99    COMP-3.*/
        public DoubleBasis BENEF_PCTBENEF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  BENEF-DTTERVIG                   PIC X(10).*/
        public StringBasis BENEF_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  BENEF-DTINIVIG                   PIC X(10).*/
        public StringBasis BENEF_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  BENEF-DTTERVIG-I                 PIC S9(04)       COMP.*/
        public IntBasis BENEF_DTTERVIG_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-COD-MSG-CRITICA               PIC S9(04)       COMP.*/
        public IntBasis WS_COD_MSG_CRITICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-COD-TP-MSG-CRITICA            PIC S9(04)       COMP.*/
        public IntBasis WS_COD_TP_MSG_CRITICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  BANCOS-NRTIT                     PIC S9(013)      COMP-3.*/
        public IntBasis BANCOS_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  FATURC-DTREF                     PIC  X(010).*/
        public StringBasis FATURC_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  PARCEL-OCORHIST                  PIC S9(004)      COMP.*/
        public IntBasis PARCEL_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  HOST-CODCONV                     PIC S9(004)      COMP.*/
        public IntBasis HOST_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  CONVEN-CODCONV                   PIC S9(004)      COMP.*/
        public IntBasis CONVEN_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  CONVEN-CARTAO                    PIC S9(004)      COMP.*/
        public IntBasis CONVEN_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  HISTCB-DTVENCTO                  PIC  X(010).*/
        public StringBasis HISTCB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  HISTCB-SITUACAO                  PIC  X(001).*/
        public StringBasis HISTCB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  HISTCB-CODOPER                   PIC S9(004)      COMP.*/
        public IntBasis HISTCB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0HCOB-VLPRMTOT                  PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V0HCOB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01         V1RCAC-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-NRRCAPCO     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRRCAPCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-HORAOPER     PIC  X(008).*/
        public StringBasis V1RCAC_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01         V1RCAC-DTMOVTO      PIC  X(010).*/
        public StringBasis V1RCAC_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1RCAC-SITUACAO     PIC  X(001).*/
        public StringBasis V1RCAC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1RCAC-BCOAVISO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-AGEAVISO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-NRAVISO      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1RCAC_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V1RCAC-DATARCAP     PIC  X(010).*/
        public StringBasis V1RCAC_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1RCAC-DTCADAST     PIC  X(010).*/
        public StringBasis V1RCAC_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1RCAC-SITCONTB     PIC  X(001).*/
        public StringBasis V1RCAC_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1RCAC-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1RCAC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V1RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V1RCAP-DATARCAP     PIC  X(010)       VALUE  SPACES.*/
        public StringBasis V1RCAP_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V0RCAP-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0RCAP-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-NRTIT        PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0RCAP_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0RCAP-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-NOME         PIC  X(040).*/
        public StringBasis V0RCAP_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01         V0RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0RCAP-VALPRI       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0RCAP_VALPRI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0RCAP-DTCADAST     PIC  X(010).*/
        public StringBasis V0RCAP_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0RCAP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0RCAP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0RCAP-SITUACAO     PIC  X(001).*/
        public StringBasis V0RCAP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0RCAP-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0RCAP-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0RCAP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0RCAP-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0RCAP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0RCAP-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-NRCERTIF     PIC S9(015)       VALUE +0 COMP-3*/
        public IntBasis V0RCAP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01         V0RCAP-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V2RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V2RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01 WS-FIM-ERRO-DPS             PIC X(003) VALUE SPACES.*/
        public StringBasis WS_FIM_ERRO_DPS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01 WS-FIM-ERRO-ACAT            PIC X(003) VALUE SPACES.*/
        public StringBasis WS_FIM_ERRO_ACAT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01 AC-DESPR-DPS-ELETR          PIC 9(007) VALUE  0.*/
        public IntBasis AC_DESPR_DPS_ELETR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01 WS-ERRO-DPS-ELETR           PIC X(001) VALUE SPACES.*/
        public StringBasis WS_ERRO_DPS_ELETR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01 WS-STA-PROPOSTA-SIAS        PIC S9(04) USAGE COMP.*/
        public IntBasis WS_STA_PROPOSTA_SIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01 WS-COD-ERRO-DPS             PIC S9(04) USAGE COMP.*/
        public IntBasis WS_COD_ERRO_DPS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01 WS-STA-CRITICA              PIC X(001) VALUE SPACES.*/
        public StringBasis WS_STA_CRITICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01 WS-EDIT.*/
        public VA0118B_WS_EDIT WS_EDIT { get; set; } = new VA0118B_WS_EDIT();
        public class VA0118B_WS_EDIT : VarBasis
        {
            /*"   10 WS-SMALLINT              PIC ZZ.ZZ9- OCCURS 20 TIMES.*/
            public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZ.ZZ9-"), 20);
            /*"   10 WS-INTEGER               PIC Z.ZZZ.ZZZ.ZZ9- OCCURS 5 TIMES*/
            public ListBasis<IntBasis, Int64> WS_INTEGER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "11", "Z.ZZZ.ZZZ.ZZ9-"), 5);
            /*"   10 WS-BIGINT                PIC 99999999999999 OCCURS 5 TIMES*/
            public ListBasis<IntBasis, Int64> WS_BIGINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "14", "99999999999999"), 5);
            /*"   10 WS-DECIMAL               PIC ZZZZZZZZZZ9,999999                                                 OCCURS 10 TIMES*/
            public ListBasis<DoubleBasis, double> WS_DECIMAL { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "11", "ZZZZZZZZZZ9V999999"), 10);
            /*"   10 WS-TAXA                  PIC 9,99999-      OCCURS 5 TIMES.*/
            public ListBasis<DoubleBasis, double> WS_TAXA { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "1", "9V99999-"), 5);
            /*"01  V0FOLHM-COD-CARTA                PIC  X(001).*/
        }
        public StringBasis V0FOLHM_COD_CARTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  V0FOLHM-DTEMICAR                 PIC  X(010).*/
        public StringBasis V0FOLHM_DTEMICAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0FOLH-COD-PRODUTO               PIC S9(004)      COMP.*/
        public IntBasis V0FOLH_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0FOLH-NRCERTIF                  PIC S9(015)      COMP-3.*/
        public IntBasis V0FOLH_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  V0FOLH-COD-CARTA                 PIC  X(001).*/
        public StringBasis V0FOLH_COD_CARTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  V0FOLH-DTEMICAR                  PIC  X(010).*/
        public StringBasis V0FOLH_DTEMICAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0FOLH-DTSOLICIT                 PIC  X(010).*/
        public StringBasis V0FOLH_DTSOLICIT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0FOLH-CODUSU                    PIC  X(008).*/
        public StringBasis V0FOLH_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  V0FOLH-SITUACAO                  PIC  X(001).*/
        public StringBasis V0FOLH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  V0FOLH-TIMESTAMP                 PIC  X(026).*/
        public StringBasis V0FOLH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01  WS-TABMES.*/
        public VA0118B_WS_TABMES WS_TABMES { get; set; } = new VA0118B_WS_TABMES();
        public class VA0118B_WS_TABMES : VarBasis
        {
            /*"    10 FILLER PIC X(24) VALUE '312831303130313130313031'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"312831303130313130313031");
            /*"01  WS-TABMES-R REDEFINES WS-TABMES.*/
        }
        private _REDEF_VA0118B_WS_TABMES_R _ws_tabmes_r { get; set; }
        public _REDEF_VA0118B_WS_TABMES_R WS_TABMES_R
        {
            get { _ws_tabmes_r = new _REDEF_VA0118B_WS_TABMES_R(); _.Move(WS_TABMES, _ws_tabmes_r); VarBasis.RedefinePassValue(WS_TABMES, _ws_tabmes_r, WS_TABMES); _ws_tabmes_r.ValueChanged += () => { _.Move(_ws_tabmes_r, WS_TABMES); }; return _ws_tabmes_r; }
            set { VarBasis.RedefinePassValue(value, _ws_tabmes_r, WS_TABMES); }
        }  //Redefines
        public class _REDEF_VA0118B_WS_TABMES_R : VarBasis
        {
            /*"    10 WS-ULTDIA OCCURS 12 TIMES PIC 9(02).*/
            public ListBasis<IntBasis, Int64> WS_ULTDIA { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "2", "9(02)."), 12);
            /*"01  WS-WORK-AREAS.*/

            public _REDEF_VA0118B_WS_TABMES_R()
            {
                WS_ULTDIA.ValueChanged += OnValueChanged;
            }

        }
        public VA0118B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VA0118B_WS_WORK_AREAS();
        public class VA0118B_WS_WORK_AREAS : VarBasis
        {
            /*"    03  WS-QTD-ERRO-803               PIC 9(005) VALUE ZEROS.*/
            public IntBasis WS_QTD_ERRO_803 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    03  WS-CONTA-803                  PIC S9(04) COMP.*/
            public IntBasis WS_CONTA_803 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    03  W-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    03  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_VA0118B_CANAL _canal { get; set; }
            public _REDEF_VA0118B_CANAL CANAL
            {
                get { _canal = new _REDEF_VA0118B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA0118B_CANAL : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                    VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF                      VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-VENDA-SASSE                    VALUE 2. */
							new SelectorItemBasis("CANAL_VENDA_SASSE", "2"),
							/*" 88 CANAL-VENDA-CORRETOR                 VALUE 3. */
							new SelectorItemBasis("CANAL_VENDA_CORRETOR", "3"),
							/*" 88 CANAL-VENDA-ATM                      VALUE 4. */
							new SelectorItemBasis("CANAL_VENDA_ATM", "4"),
							/*" 88 CANAL-VENDA-GITEL                    VALUE 5. */
							new SelectorItemBasis("CANAL_VENDA_GITEL", "5"),
							/*" 88 CANAL-VENDA-INTERNET                 VALUE 7. */
							new SelectorItemBasis("CANAL_VENDA_INTERNET", "7"),
							/*" 88 CANAL-VENDA-INTRANET                 VALUE 8. */
							new SelectorItemBasis("CANAL_VENDA_INTRANET", "8")
                }
                };

                /*"        07  FILLER                    PIC 9(013).*/
                public IntBasis FILLER_5 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    03  FILLER REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_VA0118B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA0118B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_VA0118B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_VA0118B_FILLER_6(); _.Move(W_NUM_PROPOSTA, _filler_6); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _filler_6, W_NUM_PROPOSTA); _filler_6.ValueChanged += () => { _.Move(_filler_6, W_NUM_PROPOSTA); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA0118B_FILLER_6 : VarBasis
            {
                /*"        07  FILLER                    PIC X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-CANAL-PROPOSTA1         PIC 9(004).*/

                public SelectorBasis W_CANAL_PROPOSTA1 { get; set; } = new SelectorBasis("004")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 PROPOSTA-CACB                      VALUE 9994. */
							new SelectorItemBasis("PROPOSTA_CACB", "9994"),
							/*" 88 PROPOSTA-COPESP                    VALUE 9995. */
							new SelectorItemBasis("PROPOSTA_COPESP", "9995")
                }
                };

                /*"        07  FILLER                    PIC 9(009).*/
                public IntBasis FILLER_8 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    03  PRODVG-CUSTOCAP-TOTAL-A          PIC  X(001).*/

                public _REDEF_VA0118B_FILLER_6()
                {
                    FILLER_7.ValueChanged += OnValueChanged;
                    W_CANAL_PROPOSTA1.ValueChanged += OnValueChanged;
                    FILLER_8.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis PRODVG_CUSTOCAP_TOTAL_A { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  PRODVG-CUSTOCAP-TOTAL-N          REDEFINES        PRODVG-CUSTOCAP-TOTAL-A          PIC  9(001).*/
            private _REDEF_IntBasis _prodvg_custocap_total_n { get; set; }
            public _REDEF_IntBasis PRODVG_CUSTOCAP_TOTAL_N
            {
                get { _prodvg_custocap_total_n = new _REDEF_IntBasis(new PIC("9", "001", "9(001).")); ; _.Move(PRODVG_CUSTOCAP_TOTAL_A, _prodvg_custocap_total_n); VarBasis.RedefinePassValue(PRODVG_CUSTOCAP_TOTAL_A, _prodvg_custocap_total_n, PRODVG_CUSTOCAP_TOTAL_A); _prodvg_custocap_total_n.ValueChanged += () => { _.Move(_prodvg_custocap_total_n, PRODVG_CUSTOCAP_TOTAL_A); }; return _prodvg_custocap_total_n; }
                set { VarBasis.RedefinePassValue(value, _prodvg_custocap_total_n, PRODVG_CUSTOCAP_TOTAL_A); }
            }  //Redefines
            /*"    03  WS-CHAVE.*/
            public VA0118B_WS_CHAVE WS_CHAVE { get; set; } = new VA0118B_WS_CHAVE();
            public class VA0118B_WS_CHAVE : VarBasis
            {
                /*"        05 WS-NUM-APOLICE            PIC 9(13).*/
                public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"        05 WS-CODSUBES               PIC 9(04).*/
                public IntBasis WS_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    03  WS-CHAVE-ANT.*/
            }
            public VA0118B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new VA0118B_WS_CHAVE_ANT();
            public class VA0118B_WS_CHAVE_ANT : VarBasis
            {
                /*"        05 WS-NUM-APOLICE-ANT        PIC 9(13)      VALUE ZEROS.*/
                public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"        05 WS-CODSUBES-ANT           PIC 9(04)      VALUE ZEROS.*/
                public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03  WS-QTDE-ANOS                 PIC 9(02)      VALUE ZEROS.*/
            }
            public IntBasis WS_QTDE_ANOS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    03  WS-COUNT                     PIC 9(02)      VALUE ZEROS.*/
            public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    03  WS-TAXA-VG                   PIC 9(02)V99   VALUE ZEROS.*/
            public DoubleBasis WS_TAXA_VG { get; set; } = new DoubleBasis(new PIC("9", "2", "9(02)V99"), 2);
            /*"    03  WS-TAXA-AP                   PIC 9(02)V99   VALUE ZEROS.*/
            public DoubleBasis WS_TAXA_AP { get; set; } = new DoubleBasis(new PIC("9", "2", "9(02)V99"), 2);
            /*"    03  WS-TAXA-TOT                  PIC 9(02)V99   VALUE ZEROS.*/
            public DoubleBasis WS_TAXA_TOT { get; set; } = new DoubleBasis(new PIC("9", "2", "9(02)V99"), 2);
            /*"    03  WTEM-SIVPF                   PIC 9 VALUE 0.*/
            public IntBasis WTEM_SIVPF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WTEM-MOVFEDCA                PIC X(03)     VALUE SPACES.*/
            public StringBasis WTEM_MOVFEDCA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    03  WTEM-MOVIMVGA                PIC X(03)     VALUE SPACES.*/
            public StringBasis WTEM_MOVIMVGA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    03  WS-EOF                       PIC 9 VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOP                       PIC 9 VALUE 0.*/
            public IntBasis WS_EOP { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOS                       PIC 9 VALUE 0.*/
            public IntBasis WS_EOS { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOF-D                     PIC 9 VALUE 0.*/
            public IntBasis WS_EOF_D { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WFIM-V1RCAP                  PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03  WTEM-V0RCAP                  PIC X(001)  VALUE SPACES.*/
            public StringBasis WTEM_V0RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03  WS-RATEIO                    PIC  9(003)V9(5).*/
            public DoubleBasis WS_RATEIO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V9(5)."), 5);
            /*"    03  WS-IND-IOF                   PIC S9(001)V9(4) COMP-3.*/
            public DoubleBasis WS_IND_IOF { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(001)V9(4)"), 4);
            /*"    03  WS-COD-CARTA                 PIC  X(001).*/
            public StringBasis WS_COD_CARTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  WS-CODPRODU-ANT              PIC S9(004)  COMP  VALUE +0*/
            public IntBasis WS_CODPRODU_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03  W01A0100.*/
            public VA0118B_W01A0100 W01A0100 { get; set; } = new VA0118B_W01A0100();
            public class VA0118B_W01A0100 : VarBasis
            {
                /*"        05 W01N0100                  PIC 9(01).*/
                public IntBasis W01N0100 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"    03  WSQLCODE3                    PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03  WSQLCODE-PLANOS              PIC S9(009) COMP.*/
            public IntBasis WSQLCODE_PLANOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03 W-DTEMICAR      PIC X(010) VALUE SPACES.*/
            public StringBasis W_DTEMICAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    03 FILLER  REDEFINES W-DTEMICAR.*/
            private _REDEF_VA0118B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_VA0118B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_VA0118B_FILLER_9(); _.Move(W_DTEMICAR, _filler_9); VarBasis.RedefinePassValue(W_DTEMICAR, _filler_9, W_DTEMICAR); _filler_9.ValueChanged += () => { _.Move(_filler_9, W_DTEMICAR); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, W_DTEMICAR); }
            }  //Redefines
            public class _REDEF_VA0118B_FILLER_9 : VarBasis
            {
                /*"       05 W-SSEMICAR                 PIC 9(004).*/
                public IntBasis W_SSEMICAR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 FILLER                     PIC X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 W-MMEMICAR                 PIC 9(002).*/
                public IntBasis W_MMEMICAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05 FILLER                     PIC X(001).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 W-DDEMICAR                 PIC 9(002).*/
                public IntBasis W_DDEMICAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-VIGENCIA.*/

                public _REDEF_VA0118B_FILLER_9()
                {
                    W_SSEMICAR.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    W_MMEMICAR.ValueChanged += OnValueChanged;
                    FILLER_11.ValueChanged += OnValueChanged;
                    W_DDEMICAR.ValueChanged += OnValueChanged;
                }

            }
            public VA0118B_WS_VIGENCIA WS_VIGENCIA { get; set; } = new VA0118B_WS_VIGENCIA();
            public class VA0118B_WS_VIGENCIA : VarBasis
            {
                /*"       05  WS-VIG-ANO                PIC 9(004).*/
                public IntBasis WS_VIG_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VIG-MES                PIC 9(002).*/
                public IntBasis WS_VIG_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VIG-DIA                PIC 9(002).*/
                public IntBasis WS_VIG_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-VIGENCIA1.*/
            }
            public VA0118B_WS_VIGENCIA1 WS_VIGENCIA1 { get; set; } = new VA0118B_WS_VIGENCIA1();
            public class VA0118B_WS_VIGENCIA1 : VarBasis
            {
                /*"       05  WS-VIG-ANO1               PIC 9(004).*/
                public IntBasis WS_VIG_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VIG-MES1               PIC 9(002).*/
                public IntBasis WS_VIG_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VIG-DIA1               PIC 9(002).*/
                public IntBasis WS_VIG_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-DTVENCTO-AUX.*/
            }
            public VA0118B_WS_DTVENCTO_AUX WS_DTVENCTO_AUX { get; set; } = new VA0118B_WS_DTVENCTO_AUX();
            public class VA0118B_WS_DTVENCTO_AUX : VarBasis
            {
                /*"       05  WS-VENCTO-ANO             PIC 9(004).*/
                public IntBasis WS_VENCTO_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VENCTO-MES             PIC 9(002).*/
                public IntBasis WS_VENCTO_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VENCTO-DIA             PIC 9(002).*/
                public IntBasis WS_VENCTO_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W01DTSQL                      PIC X(010).*/
            }
            public StringBasis W01DTSQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03 W01DTSQL-R    REDEFINES W01DTSQL.*/
            private _REDEF_VA0118B_W01DTSQL_R _w01dtsql_r { get; set; }
            public _REDEF_VA0118B_W01DTSQL_R W01DTSQL_R
            {
                get { _w01dtsql_r = new _REDEF_VA0118B_W01DTSQL_R(); _.Move(W01DTSQL, _w01dtsql_r); VarBasis.RedefinePassValue(W01DTSQL, _w01dtsql_r, W01DTSQL); _w01dtsql_r.ValueChanged += () => { _.Move(_w01dtsql_r, W01DTSQL); }; return _w01dtsql_r; }
                set { VarBasis.RedefinePassValue(value, _w01dtsql_r, W01DTSQL); }
            }  //Redefines
            public class _REDEF_VA0118B_W01DTSQL_R : VarBasis
            {
                /*"       05  W01AASQL                  PIC 9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W01T1SQL                  PIC X(001).*/
                public StringBasis W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01MMSQL                  PIC 9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01T2SQL                  PIC X(001).*/
                public StringBasis W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01DDSQL                  PIC 9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W02DTSQL.*/

                public _REDEF_VA0118B_W01DTSQL_R()
                {
                    W01AASQL.ValueChanged += OnValueChanged;
                    W01T1SQL.ValueChanged += OnValueChanged;
                    W01MMSQL.ValueChanged += OnValueChanged;
                    W01T2SQL.ValueChanged += OnValueChanged;
                    W01DDSQL.ValueChanged += OnValueChanged;
                }

            }
            public VA0118B_W02DTSQL W02DTSQL { get; set; } = new VA0118B_W02DTSQL();
            public class VA0118B_W02DTSQL : VarBasis
            {
                /*"       05  W02AAMMSQL.*/
                public VA0118B_W02AAMMSQL W02AAMMSQL { get; set; } = new VA0118B_W02AAMMSQL();
                public class VA0118B_W02AAMMSQL : VarBasis
                {
                    /*"           10  W02AASQL              PIC 9(004).*/
                    public IntBasis W02AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"           10  W02T1SQL              PIC X(001).*/
                    public StringBasis W02T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"           10  W02MMSQL              PIC 9(002).*/
                    public IntBasis W02MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       05  W02T2SQL                  PIC X(001).*/
                }
                public StringBasis W02T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W02DDSQL                  PIC 9(002).*/
                public IntBasis W02DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W03DTSQL.*/
            }
            public VA0118B_W03DTSQL W03DTSQL { get; set; } = new VA0118B_W03DTSQL();
            public class VA0118B_W03DTSQL : VarBasis
            {
                /*"       05  W03AAMMSQL.*/
                public VA0118B_W03AAMMSQL W03AAMMSQL { get; set; } = new VA0118B_W03AAMMSQL();
                public class VA0118B_W03AAMMSQL : VarBasis
                {
                    /*"           10  W03AASQL              PIC 9(004).*/
                    public IntBasis W03AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"           10  W03T1SQL              PIC X(001).*/
                    public StringBasis W03T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"           10  W03MMSQL              PIC 9(002).*/
                    public IntBasis W03MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       05  W03T2SQL                  PIC X(001).*/
                }
                public StringBasis W03T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W03DDSQL                  PIC 9(002).*/
                public IntBasis W03DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W04DTSQL.*/
            }
            public VA0118B_W04DTSQL W04DTSQL { get; set; } = new VA0118B_W04DTSQL();
            public class VA0118B_W04DTSQL : VarBasis
            {
                /*"       05  W04SASQL                  PIC 9(004).*/
                public IntBasis W04SASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W04SASQL-R                REDEFINES           W04SASQL.*/
                private _REDEF_VA0118B_W04SASQL_R _w04sasql_r { get; set; }
                public _REDEF_VA0118B_W04SASQL_R W04SASQL_R
                {
                    get { _w04sasql_r = new _REDEF_VA0118B_W04SASQL_R(); _.Move(W04SASQL, _w04sasql_r); VarBasis.RedefinePassValue(W04SASQL, _w04sasql_r, W04SASQL); _w04sasql_r.ValueChanged += () => { _.Move(_w04sasql_r, W04SASQL); }; return _w04sasql_r; }
                    set { VarBasis.RedefinePassValue(value, _w04sasql_r, W04SASQL); }
                }  //Redefines
                public class _REDEF_VA0118B_W04SASQL_R : VarBasis
                {
                    /*"         10  W04AASQL                PIC 9(004).*/
                    public IntBasis W04AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"       05  W04T1SQL                  PIC X(001).*/

                    public _REDEF_VA0118B_W04SASQL_R()
                    {
                        W04AASQL.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis W04T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W04MMSQL                  PIC 9(002).*/
                public IntBasis W04MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W04T2SQL                  PIC X(001).*/
                public StringBasis W04T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W04DDSQL                  PIC 9(002).*/
                public IntBasis W04DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W05DTSQL.*/
            }
            public VA0118B_W05DTSQL W05DTSQL { get; set; } = new VA0118B_W05DTSQL();
            public class VA0118B_W05DTSQL : VarBasis
            {
                /*"       05  W05AASQL                  PIC 9(004).*/
                public IntBasis W05AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W05T1SQL                  PIC X(001).*/
                public StringBasis W05T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W05MMSQL                  PIC 9(002).*/
                public IntBasis W05MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W05T2SQL                  PIC X(001).*/
                public StringBasis W05T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W05DDSQL                  PIC 9(002).*/
                public IntBasis W05DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-CONT-BENEF                 PIC  9(004) VALUE 0.*/
            }
            public IntBasis WS_CONT_BENEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    03 WS-CTA-CORRENTE-R.*/
            public VA0118B_WS_CTA_CORRENTE_R WS_CTA_CORRENTE_R { get; set; } = new VA0118B_WS_CTA_CORRENTE_R();
            public class VA0118B_WS_CTA_CORRENTE_R : VarBasis
            {
                /*"       05 WS-OPER-SEG                PIC  9(004).*/
                public IntBasis WS_OPER_SEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 WS-CTA-SEG                 PIC  9(012).*/
                public IntBasis WS_CTA_SEG { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    03  WS-CTA-CORRENTE              REDEFINES        WS-CTA-CORRENTE-R            PIC 9(016).*/
            }
            private _REDEF_IntBasis _ws_cta_corrente { get; set; }
            public _REDEF_IntBasis WS_CTA_CORRENTE
            {
                get { _ws_cta_corrente = new _REDEF_IntBasis(new PIC("9", "016", "9(016).")); ; _.Move(WS_CTA_CORRENTE_R, _ws_cta_corrente); VarBasis.RedefinePassValue(WS_CTA_CORRENTE_R, _ws_cta_corrente, WS_CTA_CORRENTE_R); _ws_cta_corrente.ValueChanged += () => { _.Move(_ws_cta_corrente, WS_CTA_CORRENTE_R); }; return _ws_cta_corrente; }
                set { VarBasis.RedefinePassValue(value, _ws_cta_corrente, WS_CTA_CORRENTE_R); }
            }  //Redefines
            /*"    03 WS-CTA-CORRENTE-VR.*/
            public VA0118B_WS_CTA_CORRENTE_VR WS_CTA_CORRENTE_VR { get; set; } = new VA0118B_WS_CTA_CORRENTE_VR();
            public class VA0118B_WS_CTA_CORRENTE_VR : VarBasis
            {
                /*"       05 WS-OPER                    PIC  9(004).*/
                public IntBasis WS_OPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 WS-CTA                     PIC  9(012).*/
                public IntBasis WS_CTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    03 WS-CTA-CORRENTEV              REDEFINES       WS-CTA-CORRENTE-VR            PIC 9(016).*/
            }
            private _REDEF_IntBasis _ws_cta_correntev { get; set; }
            public _REDEF_IntBasis WS_CTA_CORRENTEV
            {
                get { _ws_cta_correntev = new _REDEF_IntBasis(new PIC("9", "016", "9(016).")); ; _.Move(WS_CTA_CORRENTE_VR, _ws_cta_correntev); VarBasis.RedefinePassValue(WS_CTA_CORRENTE_VR, _ws_cta_correntev, WS_CTA_CORRENTE_VR); _ws_cta_correntev.ValueChanged += () => { _.Move(_ws_cta_correntev, WS_CTA_CORRENTE_VR); }; return _ws_cta_correntev; }
                set { VarBasis.RedefinePassValue(value, _ws_cta_correntev, WS_CTA_CORRENTE_VR); }
            }  //Redefines
            /*"    03 WS-ENCONTROU                  PIC  X(001) VALUE 'S'.*/

            public SelectorBasis WS_ENCONTROU { get; set; } = new SelectorBasis("001", "S")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ENCONTROU                  VALUE 'S'. */
							new SelectorItemBasis("ENCONTROU", "S"),
							/*" 88 NAO-ENCONTROU              VALUE 'N'. */
							new SelectorItemBasis("NAO_ENCONTROU", "N")
                }
            };

            /*"    03 WS-LEITUA-SIVPF               PIC  X(001) VALUE 'N'.*/

            public SelectorBasis WS_LEITUA_SIVPF { get; set; } = new SelectorBasis("001", "N")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 LEU-SIVPF                  VALUE 'S'. */
							new SelectorItemBasis("LEU_SIVPF", "S"),
							/*" 88 NAO-LEU-SIVPF              VALUE 'N'. */
							new SelectorItemBasis("NAO_LEU_SIVPF", "N")
                }
            };

            /*"    03 WS-ACESSO-CLIENTE             PIC  9(001) VALUE ZERO.*/

            public SelectorBasis WS_ACESSO_CLIENTE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ACESSO-CLIENTE-OK                       VALUE 1. */
							new SelectorItemBasis("ACESSO_CLIENTE_OK", "1"),
							/*" 88 ACESSO-CLIENTE-ER                       VALUE 2. */
							new SelectorItemBasis("ACESSO_CLIENTE_ER", "2")
                }
            };

            /*"    03  W-RCAPS                      PIC 9(001).*/

            public SelectorBasis W_RCAPS { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-CADASTRADO                       VALUE 01. */
							new SelectorItemBasis("RCAP_CADASTRADO", "01")
                }
            };

            /*"    03  W-RCAP-COMP                  PIC 9(001).*/

            public SelectorBasis W_RCAP_COMP { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-COMP-CADASTRADO                  VALUE 01. */
							new SelectorItemBasis("RCAP_COMP_CADASTRADO", "01")
                }
            };

            /*"    03 UPDATE-SIVPF-SIVPF            PIC  9(007) VALUE  0.*/
            public IntBasis UPDATE_SIVPF_SIVPF { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-LIDOS-0                    PIC  9(007) VALUE  0.*/
            public IntBasis AC_LIDOS_0 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-LIDOS-7                    PIC  9(007) VALUE  0.*/
            public IntBasis AC_LIDOS_7 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-INCLUSOES                  PIC  9(007) VALUE  0.*/
            public IntBasis AC_INCLUSOES { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-INTEGRADOS                 PIC  9(007) VALUE  0.*/
            public IntBasis AC_INTEGRADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-COBRADOS                   PIC  9(007) VALUE  0.*/
            public IntBasis AC_COBRADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPREZADOS                PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPREZADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-PRODUVG              PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_PRODUVG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-AGENCCEF             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_AGENCCEF { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-CLIENTE              PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_CLIENTE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-CONTA                PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_CONTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-DPS-TIT              PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_DPS_TIT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-FONTE                PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_FONTE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-HISCOBPR             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_HISCOBPR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-IDADE                PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_IDADE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-OPCAOPAG             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_OPCAOPAG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-PARCELVA             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_PARCELVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-PERIPGTO             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_PERIPGTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-PLAVAVGA             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_PLAVAVGA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-CRTCA-PRP            PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_CRTCA_PRP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-FOLHETOS                   PIC  9(007) VALUE  ZEROS.*/
            public IntBasis AC_FOLHETOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-ACEITA-PRD-001             PIC  9(007) VALUE  ZEROS.*/
            public IntBasis AC_ACEITA_PRD_001 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-ACEITA-PRD-002             PIC  9(007) VALUE  ZEROS.*/
            public IntBasis AC_ACEITA_PRD_002 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DECLIN-PROPVA              PIC  9(007) VALUE  ZEROS.*/
            public IntBasis AC_DECLIN_PROPVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DECLIN-100MIL              PIC  9(007) VALUE  ZEROS.*/
            public IntBasis AC_DECLIN_100MIL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DECLIN-600MIL              PIC  9(007) VALUE  ZEROS.*/
            public IntBasis AC_DECLIN_600MIL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03  W-NUMR-TITULO                PIC  9(013)   VALUE ZEROS.*/
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    03  FILLER                       REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_VA0118B_FILLER_18 _filler_18 { get; set; }
            public _REDEF_VA0118B_FILLER_18 FILLER_18
            {
                get { _filler_18 = new _REDEF_VA0118B_FILLER_18(); _.Move(W_NUMR_TITULO, _filler_18); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_18, W_NUMR_TITULO); _filler_18.ValueChanged += () => { _.Move(_filler_18, W_NUMR_TITULO); }; return _filler_18; }
                set { VarBasis.RedefinePassValue(value, _filler_18, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_VA0118B_FILLER_18 : VarBasis
            {
                /*"      05    WTITL-ZEROS              PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05    WTITL-SEQUENCIA          PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05    WTITL-DIGITO             PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    03              DPARM01X.*/

                public _REDEF_VA0118B_FILLER_18()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public VA0118B_DPARM01X DPARM01X { get; set; } = new VA0118B_DPARM01X();
            public class VA0118B_DPARM01X : VarBasis
            {
                /*"      05            DPARM01          PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05            DPARM01-R        REDEFINES   DPARM01.*/
                private _REDEF_VA0118B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_VA0118B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_VA0118B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_VA0118B_DPARM01_R : VarBasis
                {
                    /*"        10          DPARM01-1        PIC  9(001).*/
                    public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-2        PIC  9(001).*/
                    public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-3        PIC  9(001).*/
                    public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-4        PIC  9(001).*/
                    public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-5        PIC  9(001).*/
                    public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-6        PIC  9(001).*/
                    public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-7        PIC  9(001).*/
                    public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-8        PIC  9(001).*/
                    public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-9        PIC  9(001).*/
                    public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-10       PIC  9(001).*/
                    public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      05            DPARM01-D1       PIC  9(001).*/

                    public _REDEF_VA0118B_DPARM01_R()
                    {
                        DPARM01_1.ValueChanged += OnValueChanged;
                        DPARM01_2.ValueChanged += OnValueChanged;
                        DPARM01_3.ValueChanged += OnValueChanged;
                        DPARM01_4.ValueChanged += OnValueChanged;
                        DPARM01_5.ValueChanged += OnValueChanged;
                        DPARM01_6.ValueChanged += OnValueChanged;
                        DPARM01_7.ValueChanged += OnValueChanged;
                        DPARM01_8.ValueChanged += OnValueChanged;
                        DPARM01_9.ValueChanged += OnValueChanged;
                        DPARM01_10.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis DPARM01_D1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      05            DPARM01-RC       PIC S9(004) COMP VALUE +0.*/
                public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    03 PARM-PROSOMU1.*/
            }
            public VA0118B_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new VA0118B_PARM_PROSOMU1();
            public class VA0118B_PARM_PROSOMU1 : VarBasis
            {
                /*"      05 SU1-DATA1.*/
                public VA0118B_SU1_DATA1 SU1_DATA1 { get; set; } = new VA0118B_SU1_DATA1();
                public class VA0118B_SU1_DATA1 : VarBasis
                {
                    /*"        10 SU1-DD1                   PIC 99.*/
                    public IntBasis SU1_DD1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-MM1                   PIC 99.*/
                    public IntBasis SU1_MM1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-AA1                   PIC 9999.*/
                    public IntBasis SU1_AA1 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"      05 SU1-NRDIAS                  PIC S9(5) COMP-3.*/
                }
                public IntBasis SU1_NRDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(5)"));
                /*"      05 SU1-DATA2.*/
                public VA0118B_SU1_DATA2 SU1_DATA2 { get; set; } = new VA0118B_SU1_DATA2();
                public class VA0118B_SU1_DATA2 : VarBasis
                {
                    /*"        10 SU1-DD2                   PIC 99.*/
                    public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-MM2                   PIC 99.*/
                    public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-AA2                   PIC 9999.*/
                    public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"01  WS-SQLCODE                    PIC  ---9.*/
                }
            }
        }
        public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
        /*"01     WS-NUM-TITULO-X.*/
        public VA0118B_WS_NUM_TITULO_X WS_NUM_TITULO_X { get; set; } = new VA0118B_WS_NUM_TITULO_X();
        public class VA0118B_WS_NUM_TITULO_X : VarBasis
        {
            /*"   05  WS-NUM-PLANO                  PIC  9(003).*/
            public IntBasis WS_NUM_PLANO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"   05  WS-NUM-SERIE                  PIC  9(003).*/
            public IntBasis WS_NUM_SERIE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"   05  WS-NUM-TITULO                 PIC  9(006).*/
            public IntBasis WS_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01     WS-NUM-TITULO-9               REDEFINES       WS-NUM-TITULO-X               PIC  9(012).*/
        }
        private _REDEF_IntBasis _ws_num_titulo_9 { get; set; }
        public _REDEF_IntBasis WS_NUM_TITULO_9
        {
            get { _ws_num_titulo_9 = new _REDEF_IntBasis(new PIC("9", "012", "9(012).")); ; _.Move(WS_NUM_TITULO_X, _ws_num_titulo_9); VarBasis.RedefinePassValue(WS_NUM_TITULO_X, _ws_num_titulo_9, WS_NUM_TITULO_X); _ws_num_titulo_9.ValueChanged += () => { _.Move(_ws_num_titulo_9, WS_NUM_TITULO_X); }; return _ws_num_titulo_9; }
            set { VarBasis.RedefinePassValue(value, _ws_num_titulo_9, WS_NUM_TITULO_X); }
        }  //Redefines
        /*"01     WS-COMBINACAO                 PIC  X(020).*/
        public StringBasis WS_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01     WS-COMBINACAO-R               REDEFINES       WS-COMBINACAO.*/
        private _REDEF_VA0118B_WS_COMBINACAO_R _ws_combinacao_r { get; set; }
        public _REDEF_VA0118B_WS_COMBINACAO_R WS_COMBINACAO_R
        {
            get { _ws_combinacao_r = new _REDEF_VA0118B_WS_COMBINACAO_R(); _.Move(WS_COMBINACAO, _ws_combinacao_r); VarBasis.RedefinePassValue(WS_COMBINACAO, _ws_combinacao_r, WS_COMBINACAO); _ws_combinacao_r.ValueChanged += () => { _.Move(_ws_combinacao_r, WS_COMBINACAO); }; return _ws_combinacao_r; }
            set { VarBasis.RedefinePassValue(value, _ws_combinacao_r, WS_COMBINACAO); }
        }  //Redefines
        public class _REDEF_VA0118B_WS_COMBINACAO_R : VarBasis
        {
            /*"   05  WS-COMB OCCURS 20 TIMES       PIC  X(001).*/
            public ListBasis<StringBasis, string> WS_COMB { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 20);
            /*"01     WS-COMBINACAO-9               PIC  9(009).*/

            public _REDEF_VA0118B_WS_COMBINACAO_R()
            {
                WS_COMB.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_COMBINACAO_9 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"01  WABEND.*/
        public VA0118B_WABEND WABEND { get; set; } = new VA0118B_WABEND();
        public class VA0118B_WABEND : VarBasis
        {
            /*"    10    FILLER                   PIC  X(010) VALUE          'VA0118B  '.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0118B  ");
            /*"    10    FILLER                   PIC  X(028) VALUE          ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"    10    FILLER                   PIC  X(014) VALUE          '    SQLCODE = '.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"    10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    10    FILLER                   PIC  X(014)   VALUE          '   SQLERRD1 = '.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"    10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    10    FILLER                   PIC  X(014)   VALUE          '   SQLERRD2 = '.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"    10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"    10      LOCALIZA-ABEND-1.*/
            public VA0118B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0118B_LOCALIZA_ABEND_1();
            public class VA0118B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      15    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      15    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10      LOCALIZA-ABEND-2.*/
            }
            public VA0118B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0118B_LOCALIZA_ABEND_2();
            public class VA0118B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      15    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      15    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01           FC0001S-LINKAGE.*/
            }
        }
        public VA0118B_FC0001S_LINKAGE FC0001S_LINKAGE { get; set; } = new VA0118B_FC0001S_LINKAGE();
        public class VA0118B_FC0001S_LINKAGE : VarBasis
        {
            /*"  05         FC0001S-NUM-PROPOSTA    PIC  S9(015)    COMP-3.*/
            public IntBasis FC0001S_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  05         FC0001S-VLR-MENSALIDADE PIC  S9(008)V99 COMP-3.*/
            public DoubleBasis FC0001S_VLR_MENSALIDADE { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V99"), 2);
            /*"  05         FC0001S-NUM-PLANO       PIC  S9(004) COMP.*/
            public IntBasis FC0001S_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         FC0001S-NUM-SERIE       PIC  S9(004) COMP.*/
            public IntBasis FC0001S_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         FC0001S-NUM-TITULO      PIC  S9(009) COMP.*/
            public IntBasis FC0001S_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         FC0001S-IND-DV          PIC  S9(004) COMP.*/
            public IntBasis FC0001S_IND_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         FC0001S-DTH-INI-VIGENCIA PIC   X(010).*/
            public StringBasis FC0001S_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         FC0001S-DTH-FIM-VIGENCIA PIC   X(010).*/
            public StringBasis FC0001S_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         FC0001S-DES-COMBINACAO  PIC   X(020).*/
            public StringBasis FC0001S_DES_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05         FC0001S-SQLCODE         PIC  S9(004) COMP.*/
            public IntBasis FC0001S_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         FC0001S-COD-RETORNO     PIC  S9(004) COMP.*/
            public IntBasis FC0001S_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         FC0001S-DES-MENSAGEM    PIC   X(070).*/
            public StringBasis FC0001S_DES_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"01         LK-NUM-PLANO            PIC S9(4)      USAGE COMP.*/
        }
        public IntBasis LK_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-NUM-SERIE            PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-NUM-TITULO           PIC S9(9)      USAGE COMP.*/
        public IntBasis LK_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01         LK-NUM-PROPOSTA         PIC S9(15)V    USAGE COMP-3.*/
        public DoubleBasis LK_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01         LK-QTD-TITULOS          PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_QTD_TITULOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-VLR-TITULO           PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LK_VLR_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"01         LK-EMP-PARCEIRA         PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_EMP_PARCEIRA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-COD-RAMO             PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-TRACE                PIC X(009).*/

        public SelectorBasis LK_TRACE { get; set; } = new SelectorBasis("009")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88       LK-TRACE-ON             VALUE 'TRACE ON '. */
							new SelectorItemBasis("LK_TRACE_ON", "TRACE ON "),
							/*" 88       LK-TRACE-OFF            VALUE 'TRACE OFF'. */
							new SelectorItemBasis("LK_TRACE_OFF", "TRACE OFF")
                }
        };

        /*"01         LK-OUT-COD-RETORNO     PIC S9(004) COMP.*/
        public IntBasis LK_OUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         LK-OUT-SQLCODE         PIC S9(004) COMP.*/
        public IntBasis LK_OUT_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         LK-OUT-MENSAGEM        PIC X(070).*/
        public StringBasis LK_OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01         LK-OUT-SQLERRMC        PIC X(070).*/
        public StringBasis LK_OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01         LK-OUT-SQLSTATE        PIC X(005).*/
        public StringBasis LK_OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");


        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Copies.SPVG009W SPVG009W { get; set; } = new Copies.SPVG009W();
        public Copies.SPVG015W SPVG015W { get; set; } = new Copies.SPVG015W();
        public Copies.SPVG017W SPVG017W { get; set; } = new Copies.SPVG017W();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.MOVFEDCA MOVFEDCA { get; set; } = new Dclgens.MOVFEDCA();
        public Dclgens.TITFEDCA TITFEDCA { get; set; } = new Dclgens.TITFEDCA();
        public Dclgens.COMFEDCA COMFEDCA { get; set; } = new Dclgens.COMFEDCA();
        public Dclgens.PARFEDCA PARFEDCA { get; set; } = new Dclgens.PARFEDCA();
        public Dclgens.FCSERIE FCSERIE { get; set; } = new Dclgens.FCSERIE();
        public Dclgens.ERRPROVI ERRPROVI { get; set; } = new Dclgens.ERRPROVI();
        public Dclgens.COMISSOE COMISSOE { get; set; } = new Dclgens.COMISSOE();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.VG078 VG078 { get; set; } = new Dclgens.VG078();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.VG103 VG103 { get; set; } = new Dclgens.VG103();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA0118B_CPROPVA CPROPVA { get; set; } = new VA0118B_CPROPVA();
        public VA0118B_V1RCAPCOMP V1RCAPCOMP { get; set; } = new VA0118B_V1RCAPCOMP();
        public VA0118B_CBENEFP CBENEFP { get; set; } = new VA0118B_CBENEFP();
        public VA0118B_C01_RCAPCOMP C01_RCAPCOMP { get; set; } = new VA0118B_C01_RCAPCOMP();

        public VA0118B_CSR_RISCO CSR_RISCO { get; set; } = new VA0118B_CSR_RISCO(true);
        string GetQuery_CSR_RISCO()
        {
            var query = @$"SELECT A.NUM_CERTIFICADO
							,A.SIT_REGISTRO
							FROM SEGUROS.PROPOSTAS_VA A
							, SEGUROS.CLIENTES B
							, SEGUROS.PROPOSTA_FIDELIZ C WHERE C.COD_PRODUTO_SIVPF = '{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF}' AND B.CGCCPF = '{CLIENT_CGCCPF}' AND A.COD_CLIENTE = B.COD_CLIENTE AND A.NUM_CERTIFICADO = C.NUM_PROPOSTA_SIVPF AND A.SIT_REGISTRO IN ('3'
							,'6')";

            return query;
        }


        public VA0118B_CSR_ERRO_DPS CSR_ERRO_DPS { get; set; } = new VA0118B_CSR_ERRO_DPS(true);
        string GetQuery_CSR_ERRO_DPS()
        {
            var query = @$"SELECT A.NUM_CERTIFICADO
							,A.SEQ_CRITICA
							,A.COD_MSG_CRITICA
							FROM SEGUROS.VG_CRITICA_PROPOSTA A WHERE A.NUM_CERTIFICADO = '{PROPVA_NRCERTIF}' AND A.COD_MSG_CRITICA IN (8
							,10
							,11) AND A.STA_CRITICA IN ('0'
							,'1'
							,'2'
							,'4'
							,'5'
							,'8')";

            return query;
        }


        public VA0118B_CSR_ERRO_ACAT CSR_ERRO_ACAT { get; set; } = new VA0118B_CSR_ERRO_ACAT(true);
        string GetQuery_CSR_ERRO_ACAT()
        {
            var query = @$"SELECT A.NUM_CERTIFICADO
							,A.SEQ_CRITICA
							,A.COD_MSG_CRITICA
							FROM SEGUROS.VG_CRITICA_PROPOSTA A WHERE A.NUM_CERTIFICADO = '{PROPVA_NRCERTIF}' AND A.STA_CRITICA IN ('0'
							,'1'
							,'2'
							,'4'
							,'5'
							,'8')";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                InitializeGetQuery();

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        public void InitializeGetQuery()
        {
            CSR_RISCO.GetQueryEvent += GetQuery_CSR_RISCO;
            CSR_ERRO_DPS.GetQueryEvent += GetQuery_CSR_ERRO_DPS;
            CSR_ERRO_ACAT.GetQueryEvent += GetQuery_CSR_ERRO_ACAT;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -990- DISPLAY ' ' */
            _.Display($" ");

            /*" -992- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1000- DISPLAY 'PROGRAMA EM EXECUCAO VA0118B - ' 'VERSAO V.103 - DEMANDA 571.983 / RITM0004281' 'VERSAO V.102 - INCIDENTE 600024' */

            $"PROGRAMA EM EXECUCAO VA0118B - VERSAO V.103 - DEMANDA 571.983 / RITM0004281VERSAO V.102 - INCIDENTE 600024"
            .Display();

            /*" -1007- DISPLAY 'COMPILADO EM ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"COMPILADO EM FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1009- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1011- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -1012- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1013- MOVE 'SELECT V0SISTEMA' TO COMANDO. */
            _.Move("SELECT V0SISTEMA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1015- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1027- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -1030- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1035- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1036- MOVE SISTEMA-CURRDATE TO W04DTSQL. */
            _.Move(SISTEMA_CURRDATE, WS_WORK_AREAS.W04DTSQL);

            /*" -1037- MOVE W04DDSQL TO SU1-DD1. */
            _.Move(WS_WORK_AREAS.W04DTSQL.W04DDSQL, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -1038- MOVE W04MMSQL TO SU1-MM1. */
            _.Move(WS_WORK_AREAS.W04DTSQL.W04MMSQL, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -1039- MOVE W04AASQL TO SU1-AA1. */
            _.Move(WS_WORK_AREAS.W04DTSQL.W04SASQL_R.W04AASQL, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -1040- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2);

            /*" -1041- PERFORM 0010-SOMA-DIAS THRU 0010-FIM 6 TIMES. */

            M_0010_SOMA_DIAS_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/


            /*" -1042- MOVE SU1-DD2 TO W04DDSQL. */
            _.Move(WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WS_WORK_AREAS.W04DTSQL.W04DDSQL);

            /*" -1043- MOVE SU1-MM2 TO W04MMSQL. */
            _.Move(WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WS_WORK_AREAS.W04DTSQL.W04MMSQL);

            /*" -1045- MOVE SU1-AA2 TO W04AASQL. */
            _.Move(WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WS_WORK_AREAS.W04DTSQL.W04SASQL_R.W04AASQL);

            /*" -1046- DISPLAY 'DATA ATUAL                     ' SISTEMA-CURRDATE. */
            _.Display($"DATA ATUAL                     {SISTEMA_CURRDATE}");

            /*" -1048- DISPLAY 'DATA MINIMA P/ PRIMEIRO DEBITO ' W04DTSQL. */
            _.Display($"DATA MINIMA P/ PRIMEIRO DEBITO {WS_WORK_AREAS.W04DTSQL}");

            /*" -1050- MOVE 'SELECT MAX V0SUBGRUPO' TO COMANDO. */
            _.Move("SELECT MAX V0SUBGRUPO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1055- PERFORM M_0000_PRINCIPAL_DB_SELECT_2 */

            M_0000_PRINCIPAL_DB_SELECT_2();

            /*" -1058- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1060- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1060- PERFORM 0010-LER-TITULO-V0BANCO. */

            M_0010_LER_TITULO_V0BANCO(true);

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -1027- EXEC SQL SELECT DTMOVABE, CURRENT DATE, CURRENT DATE + 8 DAYS, CURRENT DATE + 1 MONTH INTO :SISTEMA-DTMOVABE, :SISTEMA-CURRDATE, :SISTEMA-DTMOVABE2, :SISTEMA-DTMOVABE3 FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VA' WITH UR END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
                _.Move(executed_1.SISTEMA_CURRDATE, SISTEMA_CURRDATE);
                _.Move(executed_1.SISTEMA_DTMOVABE2, SISTEMA_DTMOVABE2);
                _.Move(executed_1.SISTEMA_DTMOVABE3, SISTEMA_DTMOVABE3);
            }


        }

        [StopWatch]
        /*" M-0010-LER-TITULO-V0BANCO */
        private void M_0010_LER_TITULO_V0BANCO(bool isPerform = false)
        {
            /*" -1065- MOVE 'SELECT V0BANCO' TO COMANDO. */
            _.Move("SELECT V0BANCO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1070- PERFORM M_0010_LER_TITULO_V0BANCO_DB_SELECT_1 */

            M_0010_LER_TITULO_V0BANCO_DB_SELECT_1();

            /*" -1073- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1074- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1076- END-IF */
            }


            /*" -1078- MOVE BANCOS-NRTIT TO W-NUMR-TITULO. */
            _.Move(BANCOS_NRTIT, WS_WORK_AREAS.W_NUMR_TITULO);

            /*" -1080- MOVE 'DECLARE CPROPVA' TO COMANDO. */
            _.Move("DECLARE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1137- PERFORM M_0010_LER_TITULO_V0BANCO_DB_DECLARE_1 */

            M_0010_LER_TITULO_V0BANCO_DB_DECLARE_1();

            /*" -1140- MOVE 'OPEN CPROPVA' TO COMANDO. */
            _.Move("OPEN CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1140- PERFORM M_0010_LER_TITULO_V0BANCO_DB_OPEN_1 */

            M_0010_LER_TITULO_V0BANCO_DB_OPEN_1();

            /*" -1143- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1145- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1147- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


            /*" -1150- PERFORM 0100-PROCESSA-PROPOSTA THRU 0100-FIM UNTIL WS-EOF = 1. */

            while (!(WS_WORK_AREAS.WS_EOF == 1))
            {

                M_0100_PROCESSA_PROPOSTA_SECTION();

                M_0100_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

            }

            /*" -1152- MOVE 'UPDATE V0BANCO' TO COMANDO. */
            _.Move("UPDATE V0BANCO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1157- PERFORM M_0010_LER_TITULO_V0BANCO_DB_UPDATE_1 */

            M_0010_LER_TITULO_V0BANCO_DB_UPDATE_1();

            /*" -1160- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1162- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1162- PERFORM 0000-TERMINA. */

            M_0000_TERMINA(true);

        }

        [StopWatch]
        /*" M-0010-LER-TITULO-V0BANCO-DB-SELECT-1 */
        public void M_0010_LER_TITULO_V0BANCO_DB_SELECT_1()
        {
            /*" -1070- EXEC SQL SELECT NRTIT INTO :BANCOS-NRTIT FROM SEGUROS.V0BANCO WHERE BANCO = 104 END-EXEC. */

            var m_0010_LER_TITULO_V0BANCO_DB_SELECT_1_Query1 = new M_0010_LER_TITULO_V0BANCO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0010_LER_TITULO_V0BANCO_DB_SELECT_1_Query1.Execute(m_0010_LER_TITULO_V0BANCO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BANCOS_NRTIT, BANCOS_NRTIT);
            }


        }

        [StopWatch]
        /*" M-0010-LER-TITULO-V0BANCO-DB-DECLARE-1 */
        public void M_0010_LER_TITULO_V0BANCO_DB_DECLARE_1()
        {
            /*" -1137- EXEC SQL DECLARE CPROPVA CURSOR FOR SELECT NUM_APOLICE, CODSUBES, NRCERTIF, CODPRODU, CODCLIEN, OCOREND, FONTE, AGECOBR, OPCAO_COBER, DTQITBCO, DTQITBCO + 6 MONTHS, DTQITBCO + 1 MONTH, DTPROXVEN, DTQITBCO + 30 DAYS, NRMATRVEN, CODOPER, DTMOVTO, SITUACAO, NUM_APOLICE, CODSUBES, OCORHIST, NRPARCE, SIT_INTERFACE, TIMESTAMP, IDADE, IDE_SEXO, ESTADO_CIVIL, COD_CRM, NUM_MATRICULA, DATA_ADMISSAO, NRPROPOS, COD_CCT, CODUSU, DTVENCTO, FAIXA_RENDA_IND, DATE(TIMESTAMP), VALUE(DPS_TITULAR, '       ' ), COD_ORIGEM_PROPOSTA, SITUACAO, VALUE(ACATAMENTO, ' ' ) FROM SEGUROS.V0PROPOSTAVA A WHERE A.SITUACAO IN ( '0' , '7' ) AND NOT A.NUM_APOLICE BETWEEN 107700000000 AND 107799999999 FOR UPDATE OF CODPRODU, CODOPER, DTMOVTO, DTPROXVEN, SITUACAO, CODSUBES, NRPARCE, SIT_INTERFACE, TIMESTAMP, DTVENCTO END-EXEC. */
            CPROPVA = new VA0118B_CPROPVA(false);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							CODSUBES
							, 
							NRCERTIF
							, 
							CODPRODU
							, 
							CODCLIEN
							, 
							OCOREND
							, 
							FONTE
							, 
							AGECOBR
							, 
							OPCAO_COBER
							, 
							DTQITBCO
							, 
							DTQITBCO + 6 MONTHS
							, 
							DTQITBCO + 1 MONTH
							, 
							DTPROXVEN
							, 
							DTQITBCO + 30 DAYS
							, 
							NRMATRVEN
							, 
							CODOPER
							, 
							DTMOVTO
							, 
							SITUACAO
							, 
							NUM_APOLICE
							, 
							CODSUBES
							, 
							OCORHIST
							, 
							NRPARCE
							, 
							SIT_INTERFACE
							, 
							TIMESTAMP
							, 
							IDADE
							, 
							IDE_SEXO
							, 
							ESTADO_CIVIL
							, 
							COD_CRM
							, 
							NUM_MATRICULA
							, 
							DATA_ADMISSAO
							, 
							NRPROPOS
							, 
							COD_CCT
							, 
							CODUSU
							, 
							DTVENCTO
							, 
							FAIXA_RENDA_IND
							, 
							DATE(TIMESTAMP)
							, 
							VALUE(DPS_TITULAR
							, ' ' )
							, 
							COD_ORIGEM_PROPOSTA
							, 
							SITUACAO
							, 
							VALUE(ACATAMENTO
							, ' ' ) 
							FROM SEGUROS.V0PROPOSTAVA A 
							WHERE A.SITUACAO IN ( '0'
							, '7' ) 
							AND NOT A.NUM_APOLICE BETWEEN 107700000000 
							AND 107799999999";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" M-0010-LER-TITULO-V0BANCO-DB-OPEN-1 */
        public void M_0010_LER_TITULO_V0BANCO_DB_OPEN_1()
        {
            /*" -1140- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" M-0010-LER-TITULO-V0BANCO-DB-UPDATE-1 */
        public void M_0010_LER_TITULO_V0BANCO_DB_UPDATE_1()
        {
            /*" -1157- EXEC SQL UPDATE SEGUROS.V0BANCO SET NRTIT = :BANCOS-NRTIT, TIMESTAMP = CURRENT TIMESTAMP WHERE BANCO = 104 END-EXEC. */

            var m_0010_LER_TITULO_V0BANCO_DB_UPDATE_1_Update1 = new M_0010_LER_TITULO_V0BANCO_DB_UPDATE_1_Update1()
            {
                BANCOS_NRTIT = BANCOS_NRTIT.ToString(),
            };

            M_0010_LER_TITULO_V0BANCO_DB_UPDATE_1_Update1.Execute(m_0010_LER_TITULO_V0BANCO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-2 */
        public void M_0000_PRINCIPAL_DB_SELECT_2()
        {
            /*" -1055- EXEC SQL SELECT VALUE(MAX(COD_SUBGRUPO),0) INTO :SUBGRU-CODSUBES FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = 0109700000024 END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_2_Query1 = new M_0000_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_2_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGRU_CODSUBES, SUBGRU_CODSUBES);
            }


        }

        [StopWatch]
        /*" M-0000-TERMINA */
        private void M_0000_TERMINA(bool isPerform = false)
        {
            /*" -1167- PERFORM 9000-FINALIZA THRU 9000-FIM. */

            M_9000_FINALIZA_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


            /*" -1169- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1169- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0010-SOMA-DIAS-SECTION */
        private void M_0010_SOMA_DIAS_SECTION()
        {
            /*" -1176- MOVE '0010-SOMA-DIAS        ' TO PARAGRAFO. */
            _.Move("0010-SOMA-DIAS        ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1178- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1179- MOVE +1 TO SU1-NRDIAS. */
            _.Move(+1, WS_WORK_AREAS.PARM_PROSOMU1.SU1_NRDIAS);

            /*" -1180- CALL 'PROSOCU1' USING PARM-PROSOMU1. */
            _.Call("PROSOCU1", WS_WORK_AREAS.PARM_PROSOMU1);

            /*" -1180- MOVE SU1-DATA2 TO SU1-DATA1. */
            _.Move(WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-SECTION */
        private void M_0100_PROCESSA_PROPOSTA_SECTION()
        {
            /*" -1188- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1190- DISPLAY PARAGRAFO ' >> ' PROPVA-NRCERTIF */

            $"{WABEND.LOCALIZA_ABEND_1.PARAGRAFO} >> {PROPVA_NRCERTIF}"
            .Display();

            /*" -1191- IF PROPVA-SITUACAO EQUAL '0' */

            if (PROPVA_SITUACAO == "0")
            {

                /*" -1192- ADD 1 TO AC-LIDOS-0 */
                WS_WORK_AREAS.AC_LIDOS_0.Value = WS_WORK_AREAS.AC_LIDOS_0 + 1;

                /*" -1193- ELSE */
            }
            else
            {


                /*" -1194- ADD 1 TO AC-LIDOS-7 */
                WS_WORK_AREAS.AC_LIDOS_7.Value = WS_WORK_AREAS.AC_LIDOS_7 + 1;

                /*" -1196- END-IF */
            }


            /*" -1198- MOVE 'N' TO WS-LEITUA-SIVPF. */
            _.Move("N", WS_WORK_AREAS.WS_LEITUA_SIVPF);

            /*" -1200- MOVE 'NAO' TO WTEM-MOVIMVGA. */
            _.Move("NAO", WS_WORK_AREAS.WTEM_MOVIMVGA);

            /*" -1202- MOVE 'SELECT V0PRODUTOSVG' TO COMANDO. */
            _.Move("SELECT V0PRODUTOSVG", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1240- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_1 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_1();

            /*" -1243- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1244- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1247- DISPLAY 'NAO ENCONTRADO NA PRODUTOS_VG ' '  NUM_APOLICE = ' PROPVA-NUM-APOLICE '  CODSUBES    = ' PROPVA-CODSUBES */

                    $"NAO ENCONTRADO NA PRODUTOS_VG   NUM_APOLICE = {PROPVA_NUM_APOLICE}  CODSUBES    = {PROPVA_CODSUBES}"
                    .Display();

                    /*" -1248- ADD 1 TO AC-DESPR-PRODUVG */
                    WS_WORK_AREAS.AC_DESPR_PRODUVG.Value = WS_WORK_AREAS.AC_DESPR_PRODUVG + 1;

                    /*" -1249- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1250- ELSE */
                }
                else
                {


                    /*" -1253- DISPLAY 'PROBLEMAS NO ACESSO A PRODUTOS_VG ' '  NUM_APOLICE = ' PROPVA-NUM-APOLICE '  CODSUBES    = ' PROPVA-CODSUBES */

                    $"PROBLEMAS NO ACESSO A PRODUTOS_VG   NUM_APOLICE = {PROPVA_NUM_APOLICE}  CODSUBES    = {PROPVA_CODSUBES}"
                    .Display();

                    /*" -1254- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1255- END-IF */
                }


                /*" -1257- END-IF. */
            }


            /*" -1258- IF WS-IND-ARQFDCAP LESS ZEROS */

            if (WS_IND_ARQFDCAP < 00)
            {

                /*" -1259- MOVE ZEROS TO PRODVG-ARQ-FDCAP */
                _.Move(0, PRODVG_ARQ_FDCAP);

                /*" -1261- END-IF. */
            }


            /*" -1262- IF WS-IND-RUBRICA LESS ZEROS */

            if (WS_IND_RUBRICA < 00)
            {

                /*" -1263- MOVE ZEROS TO PRODVG-COD-RUBRICA */
                _.Move(0, PRODVG_COD_RUBRICA);

                /*" -1265- END-IF. */
            }


            /*" -1266- MOVE PRODVG-CUSTOCAP-TOTAL TO PRODVG-CUSTOCAP-TOTAL-A */
            _.Move(PRODVG_CUSTOCAP_TOTAL, WS_WORK_AREAS.PRODVG_CUSTOCAP_TOTAL_A);

            /*" -1273- MOVE PRODVG-CUSTOCAP-TOTAL-N TO PRODVG-CUSTOCAP-TOTAL-9 */
            _.Move(WS_WORK_AREAS.PRODVG_CUSTOCAP_TOTAL_N, PRODVG_CUSTOCAP_TOTAL_9);

            /*" -1282- MOVE PRODVG-COD-PRODUTO TO PROPVA-CODPRODU. */
            _.Move(PRODVG_COD_PRODUTO, PROPVA_CODPRODU);

            /*" -1284- MOVE 'SELECT V0CLIENTE' TO COMANDO */
            _.Move("SELECT V0CLIENTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1286- MOVE ZERO TO WS-ACESSO-CLIENTE */
            _.Move(0, WS_WORK_AREAS.WS_ACESSO_CLIENTE);

            /*" -1294- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_2 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_2();

            /*" -1297- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1298- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1299- DISPLAY 'VA0118B - CLIENTE NAO CADASTRADO ' */
                    _.Display($"VA0118B - CLIENTE NAO CADASTRADO ");

                    /*" -1301- DISPLAY '          CERTIFICADO........... ' PROPVA-NRCERTIF */
                    _.Display($"          CERTIFICADO........... {PROPVA_NRCERTIF}");

                    /*" -1303- DISPLAY '          CODIGO DO CLIENTE..... ' PROPVA-CODCLIEN */
                    _.Display($"          CODIGO DO CLIENTE..... {PROPVA_CODCLIEN}");

                    /*" -1304- MOVE 2 TO WS-ACESSO-CLIENTE */
                    _.Move(2, WS_WORK_AREAS.WS_ACESSO_CLIENTE);

                    /*" -1305- ELSE */
                }
                else
                {


                    /*" -1306- DISPLAY 'VA0118B - ERRO NO ACESSO CLIENTE ' */
                    _.Display($"VA0118B - ERRO NO ACESSO CLIENTE ");

                    /*" -1308- DISPLAY '          CERTIFICADO........... ' PROPVA-NRCERTIF */
                    _.Display($"          CERTIFICADO........... {PROPVA_NRCERTIF}");

                    /*" -1310- DISPLAY '          CODIGO DO CLIENTE..... ' PROPVA-CODCLIEN */
                    _.Display($"          CODIGO DO CLIENTE..... {PROPVA_CODCLIEN}");

                    /*" -1312- DISPLAY '          SQLCODE............... ' SQLCODE */
                    _.Display($"          SQLCODE............... {DB.SQLCODE}");

                    /*" -1313- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1314- ELSE */
                }

            }
            else
            {


                /*" -1315- IF CLIENT-DTNASC-I LESS ZEROES */

                if (CLIENT_DTNASC_I < 00)
                {

                    /*" -1316- DISPLAY 'VA0118B - CLIENTE SEM DATA NASCIMENTO ' */
                    _.Display($"VA0118B - CLIENTE SEM DATA NASCIMENTO ");

                    /*" -1318- DISPLAY '          CERTIFICADO................ ' PROPVA-NRCERTIF */
                    _.Display($"          CERTIFICADO................ {PROPVA_NRCERTIF}");

                    /*" -1320- DISPLAY '          CODIGO DO CLIENTE.......... ' PROPVA-CODCLIEN */
                    _.Display($"          CODIGO DO CLIENTE.......... {PROPVA_CODCLIEN}");

                    /*" -1322- MOVE 2 TO WS-ACESSO-CLIENTE. */
                    _.Move(2, WS_WORK_AREAS.WS_ACESSO_CLIENTE);
                }

            }


            /*" -1323- IF ACESSO-CLIENTE-ER */

            if (WS_WORK_AREAS.WS_ACESSO_CLIENTE["ACESSO_CLIENTE_ER"])
            {

                /*" -1324- ADD 1 TO AC-DESPR-CLIENTE */
                WS_WORK_AREAS.AC_DESPR_CLIENTE.Value = WS_WORK_AREAS.AC_DESPR_CLIENTE + 1;

                /*" -1325- MOVE '1' TO PROPVA-SITUACAO */
                _.Move("1", PROPVA_SITUACAO);

                /*" -1327- GO TO 0100-NEXT. */

                M_0100_NEXT(); //GOTO
                return;
            }


            /*" -1328- IF PROPVA-FONTE NOT GREATER ZEROS */

            if (PROPVA_FONTE <= 00)
            {

                /*" -1329- DISPLAY ' DESPREZADO FONTE ......... ' PROPVA-NRCERTIF */
                _.Display($" DESPREZADO FONTE ......... {PROPVA_NRCERTIF}");

                /*" -1330- MOVE 0201 TO ERRPROVI-COD-ERRO */
                _.Move(0201, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                /*" -1331- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                /*" -1332- IF WS-COD-TP-MSG-CRITICA NOT EQUAL 03 */

                if (WS_COD_TP_MSG_CRITICA != 03)
                {

                    /*" -1333- MOVE '1' TO PROPVA-SITUACAO */
                    _.Move("1", PROPVA_SITUACAO);

                    /*" -1334- ADD 1 TO AC-DESPR-FONTE */
                    WS_WORK_AREAS.AC_DESPR_FONTE.Value = WS_WORK_AREAS.AC_DESPR_FONTE + 1;

                    /*" -1335- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1336- END-IF */
                }


                /*" -1339- END-IF */
            }


            /*" -1341- MOVE 'N' TO WS-ERRO-DPS-ELETR */
            _.Move("N", WS_ERRO_DPS_ELETR);

            /*" -1342- IF PROPVA-CODPRODU EQUAL 9750 OR 9751 OR 9752 */

            if (PROPVA_CODPRODU.In("9750", "9751", "9752"))
            {

                /*" -1344- PERFORM 0108-00-ANALISA-STATUS-DPS */

                M_0108_00_ANALISA_STATUS_DPS_SECTION();

                /*" -1345- IF WS-ERRO-DPS-ELETR EQUAL 'S' */

                if (WS_ERRO_DPS_ELETR == "S")
                {

                    /*" -1346- MOVE '1' TO PROPVA-SITUACAO */
                    _.Move("1", PROPVA_SITUACAO);

                    /*" -1347- ADD 1 TO AC-DESPR-DPS-ELETR */
                    AC_DESPR_DPS_ELETR.Value = AC_DESPR_DPS_ELETR + 1;

                    /*" -1348- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1349- END-IF */
                }


                /*" -1352- END-IF */
            }


            /*" -1395- IF PROPVA-NUM-APOLICE = 109300001294 OR PROPVA-NUM-APOLICE = 107700000011 OR PROPVA-NUM-APOLICE = 107700000013 OR PROPVA-NUM-APOLICE = 109300001391 OR PROPVA-NUM-APOLICE = 109300001392 OR PROPVA-NUM-APOLICE = 109300001311 OR PROPVA-NUM-APOLICE = 109300000909 OR PROPVA-NUM-APOLICE = 3009300000909 OR PROPVA-NUM-APOLICE = 3009300001909 OR PROPVA-NUM-APOLICE = 109300000598 OR PROPVA-NUM-APOLICE = 109300001666 OR PROPVA-NUM-APOLICE = 109300001679 OR PROPVA-NUM-APOLICE = 109300001680 OR PROPVA-NUM-APOLICE = 109300002357 OR PROPVA-NUM-APOLICE = 109300002358 OR PROPVA-NUM-APOLICE = 3009300002358 OR PROPVA-NUM-APOLICE = 3009300012358 OR PROPVA-NUM-APOLICE = 109300002344 OR PROPVA-NUM-APOLICE = 3009300002344 OR PROPVA-NUM-APOLICE = 3009300012344 OR PROPVA-NUM-APOLICE = 109300002001 OR PROPVA-NUM-APOLICE = 109300002002 OR PROPVA-NUM-APOLICE = 3009300002002 OR PROPVA-NUM-APOLICE = 3009300012002 OR PROPVA-NUM-APOLICE = 109300002003 OR PROPVA-NUM-APOLICE = 3009300002003 OR PROPVA-NUM-APOLICE = 3009300012003 OR PROPVA-NUM-APOLICE = 109300002004 OR PROPVA-NUM-APOLICE = 109300002005 OR PROPVA-NUM-APOLICE = 3009300002005 OR PROPVA-NUM-APOLICE = 3009300012005 OR PROPVA-NUM-APOLICE = 109300002006 OR PROPVA-NUM-APOLICE = 3009300002006 OR PROPVA-NUM-APOLICE = 3009300012006 OR PROPVA-NUM-APOLICE = 109300001392 OR PROPVA-NUM-APOLICE = 109300001311 OR PROPVA-NUM-APOLICE = 109300001679 OR PROPVA-NUM-APOLICE = 109300001680 OR PROPVA-NUM-APOLICE = 109300002357 OR PROPVA-NUM-APOLICE = 109300002001 OR PROPVA-NUM-APOLICE = 109300002004 OR PROPVA-NUM-APOLICE = 3009300007513 OR PROPVA-NUM-APOLICE = 3009300007514 */

            if (PROPVA_NUM_APOLICE == 109300001294 || PROPVA_NUM_APOLICE == 107700000011 || PROPVA_NUM_APOLICE == 107700000013 || PROPVA_NUM_APOLICE == 109300001391 || PROPVA_NUM_APOLICE == 109300001392 || PROPVA_NUM_APOLICE == 109300001311 || PROPVA_NUM_APOLICE == 109300000909 || PROPVA_NUM_APOLICE == 3009300000909 || PROPVA_NUM_APOLICE == 3009300001909 || PROPVA_NUM_APOLICE == 109300000598 || PROPVA_NUM_APOLICE == 109300001666 || PROPVA_NUM_APOLICE == 109300001679 || PROPVA_NUM_APOLICE == 109300001680 || PROPVA_NUM_APOLICE == 109300002357 || PROPVA_NUM_APOLICE == 109300002358 || PROPVA_NUM_APOLICE == 3009300002358 || PROPVA_NUM_APOLICE == 3009300012358 || PROPVA_NUM_APOLICE == 109300002344 || PROPVA_NUM_APOLICE == 3009300002344 || PROPVA_NUM_APOLICE == 3009300012344 || PROPVA_NUM_APOLICE == 109300002001 || PROPVA_NUM_APOLICE == 109300002002 || PROPVA_NUM_APOLICE == 3009300002002 || PROPVA_NUM_APOLICE == 3009300012002 || PROPVA_NUM_APOLICE == 109300002003 || PROPVA_NUM_APOLICE == 3009300002003 || PROPVA_NUM_APOLICE == 3009300012003 || PROPVA_NUM_APOLICE == 109300002004 || PROPVA_NUM_APOLICE == 109300002005 || PROPVA_NUM_APOLICE == 3009300002005 || PROPVA_NUM_APOLICE == 3009300012005 || PROPVA_NUM_APOLICE == 109300002006 || PROPVA_NUM_APOLICE == 3009300002006 || PROPVA_NUM_APOLICE == 3009300012006 || PROPVA_NUM_APOLICE == 109300001392 || PROPVA_NUM_APOLICE == 109300001311 || PROPVA_NUM_APOLICE == 109300001679 || PROPVA_NUM_APOLICE == 109300001680 || PROPVA_NUM_APOLICE == 109300002357 || PROPVA_NUM_APOLICE == 109300002001 || PROPVA_NUM_APOLICE == 109300002004 || PROPVA_NUM_APOLICE == 3009300007513 || PROPVA_NUM_APOLICE == 3009300007514)
            {

                /*" -1396- CONTINUE */

                /*" -1401- ELSE */
            }
            else
            {


                /*" -1402- IF PROPVA-DPS-TITULAR EQUAL SPACES */

                if (PROPVA_DPS_TITULAR.IsEmpty())
                {

                    /*" -1403- DISPLAY ' DESPREZADO DPS TITULAR ..  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO DPS TITULAR ..  {PROPVA_NRCERTIF}");

                    /*" -1404- MOVE 1803 TO ERRPROVI-COD-ERRO */
                    _.Move(1803, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -1405- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                    M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                    /*" -1406- IF WS-COD-TP-MSG-CRITICA NOT EQUAL 03 */

                    if (WS_COD_TP_MSG_CRITICA != 03)
                    {

                        /*" -1407- MOVE '1' TO PROPVA-SITUACAO */
                        _.Move("1", PROPVA_SITUACAO);

                        /*" -1408- ADD 1 TO AC-DESPR-DPS-TIT */
                        WS_WORK_AREAS.AC_DESPR_DPS_TIT.Value = WS_WORK_AREAS.AC_DESPR_DPS_TIT + 1;

                        /*" -1409- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -1410- END-IF */
                    }


                    /*" -1411- END-IF */
                }


                /*" -1413- END-IF */
            }


            /*" -1415- IF PROPVA-INRPROPOS LESS ZEROS OR PROPVA-NRPROPOS EQUAL ZEROS */

            if (PROPVA_INRPROPOS < 00 || PROPVA_NRPROPOS == 00)
            {

                /*" -1416- CONTINUE */

                /*" -1417- ELSE */
            }
            else
            {


                /*" -1419- MOVE 'SELECT V0MOVIMENTO' TO COMANDO */
                _.Move("SELECT V0MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1425- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_3 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_3();

                /*" -1428- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1429- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1430- CONTINUE */

                        /*" -1431- ELSE */
                    }
                    else
                    {


                        /*" -1432- DISPLAY 'VA0118B - ERRO NO ACESSO V0MOVIMENTO' */
                        _.Display($"VA0118B - ERRO NO ACESSO V0MOVIMENTO");

                        /*" -1434- DISPLAY '          CERTIFICADO.............. ' PROPVA-NRCERTIF */
                        _.Display($"          CERTIFICADO.............. {PROPVA_NRCERTIF}");

                        /*" -1436- DISPLAY '          PROPOSTA................. ' PROPVA-NRPROPOS */
                        _.Display($"          PROPOSTA................. {PROPVA_NRPROPOS}");

                        /*" -1438- DISPLAY '          SQLCODE.................. ' SQLCODE */
                        _.Display($"          SQLCODE.................. {DB.SQLCODE}");

                        /*" -1439- GO TO 9999-ERRO */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1440- END-IF */
                    }


                    /*" -1441- ELSE */
                }
                else
                {


                    /*" -1442- DISPLAY 'VA0118B - PROPOSTA JA CADASTRADA' */
                    _.Display($"VA0118B - PROPOSTA JA CADASTRADA");

                    /*" -1444- DISPLAY '          CERTIFICADO.......... ' PROPVA-NRCERTIF */
                    _.Display($"          CERTIFICADO.......... {PROPVA_NRCERTIF}");

                    /*" -1446- DISPLAY '          PROPOSTA............. ' PROPVA-NRPROPOS */
                    _.Display($"          PROPOSTA............. {PROPVA_NRPROPOS}");

                    /*" -1447- MOVE -1 TO PROPVA-INRPROPOS */
                    _.Move(-1, PROPVA_INRPROPOS);

                    /*" -1448- MOVE 0 TO PROPVA-NRPROPOS */
                    _.Move(0, PROPVA_NRPROPOS);

                    /*" -1449- END-IF */
                }


                /*" -1452- END-IF */
            }


            /*" -1453- IF VIND-ESTR-COBR LESS 0 */

            if (VIND_ESTR_COBR < 0)
            {

                /*" -1455- MOVE SPACES TO PRODVG-ESTR-COBR. */
                _.Move("", PRODVG_ESTR_COBR);
            }


            /*" -1456- IF VIND-ORIG-PRODU LESS 0 */

            if (VIND_ORIG_PRODU < 0)
            {

                /*" -1458- MOVE SPACES TO PRODVG-ORIG-PRODU. */
                _.Move("", PRODVG_ORIG_PRODU);
            }


            /*" -1459- IF VIND-AGENCIADOR LESS 0 */

            if (VIND_AGENCIADOR < 0)
            {

                /*" -1461- MOVE +0 TO PRODVG-AGENCIADOR. */
                _.Move(+0, PRODVG_AGENCIADOR);
            }


            /*" -1462- IF VIND-TEM-SAF LESS 0 */

            if (VIND_TEM_SAF < 0)
            {

                /*" -1464- MOVE 'N' TO PRODVG-TEM-SAF. */
                _.Move("N", PRODVG_TEM_SAF);
            }


            /*" -1465- IF VIND-TEM-CDG LESS 0 */

            if (VIND_TEM_CDG < 0)
            {

                /*" -1467- MOVE 'N' TO PRODVG-TEM-CDG. */
                _.Move("N", PRODVG_TEM_CDG);
            }


            /*" -1468- IF VIND-CODRELAT LESS 0 */

            if (VIND_CODRELAT < 0)
            {

                /*" -1470- MOVE '********' TO PRODVG-CODRELAT. */
                _.Move("********", PRODVG_CODRELAT);
            }


            /*" -1472- IF PRODVG-ORIG-PRODU = 'MULT' OR 'CAMP' AND PROPVA-IDADE = 0 */

            if (PRODVG_ORIG_PRODU.In("MULT", "CAMP") && PROPVA_IDADE == 0)
            {

                /*" -1473- DISPLAY ' DESPREZADO IDADE ......... ' PROPVA-NRCERTIF */
                _.Display($" DESPREZADO IDADE ......... {PROPVA_NRCERTIF}");

                /*" -1474- MOVE 1002 TO ERRPROVI-COD-ERRO */
                _.Move(1002, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                /*" -1475- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                /*" -1476- IF WS-COD-TP-MSG-CRITICA NOT EQUAL 03 */

                if (WS_COD_TP_MSG_CRITICA != 03)
                {

                    /*" -1477- MOVE '1' TO PROPVA-SITUACAO */
                    _.Move("1", PROPVA_SITUACAO);

                    /*" -1478- ADD 1 TO AC-DESPR-IDADE */
                    WS_WORK_AREAS.AC_DESPR_IDADE.Value = WS_WORK_AREAS.AC_DESPR_IDADE + 1;

                    /*" -1479- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1480- END-IF */
                }


                /*" -1484- END-IF */
            }


            /*" -1486- MOVE 'SELECT V0OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT V0OPCAOPAGVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1506- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_4 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_4();

            /*" -1509- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1510- DISPLAY 'ERRO SELECT V0OPCAOPAGVA  SQLCODE  = ' SQLCODE */
                _.Display($"ERRO SELECT V0OPCAOPAGVA  SQLCODE  = {DB.SQLCODE}");

                /*" -1511- DISPLAY 'NRCERTIF = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF = {PROPVA_NRCERTIF}");

                /*" -1512- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1514- END-IF. */
            }


            /*" -1517- IF (PRODVG-ORIG-PRODU = 'MULT' OR 'VIDAZUL' ) AND PROPVA-NUM-APOLICE NOT EQUAL 109300000635 */

            if ((PRODVG_ORIG_PRODU.In("MULT", "VIDAZUL")) && PROPVA_NUM_APOLICE != 109300000635)
            {

                /*" -1518- IF (PROPVA-SITUACAO = '7' OR OPCAOP-OPCAOPAG EQUAL '5' ) */

                if ((PROPVA_SITUACAO == "7" || OPCAOP_OPCAOPAG == "5"))
                {

                    /*" -1519- CONTINUE */

                    /*" -1520- ELSE */
                }
                else
                {


                    /*" -1521- MOVE 'SELECT V0PARCELVA  ' TO COMANDO */
                    _.Move("SELECT V0PARCELVA  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -1527- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_5 */

                    M_0100_PROCESSA_PROPOSTA_DB_SELECT_5();

                    /*" -1529- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1530- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -1532- DISPLAY ' DESPREZADO PARCELVA ... ' PROPVA-NRCERTIF */
                            _.Display($" DESPREZADO PARCELVA ... {PROPVA_NRCERTIF}");

                            /*" -1533- MOVE '1' TO PROPVA-SITUACAO */
                            _.Move("1", PROPVA_SITUACAO);

                            /*" -1534- ADD 1 TO AC-DESPR-PARCELVA */
                            WS_WORK_AREAS.AC_DESPR_PARCELVA.Value = WS_WORK_AREAS.AC_DESPR_PARCELVA + 1;

                            /*" -1535- GO TO 0100-NEXT */

                            M_0100_NEXT(); //GOTO
                            return;

                            /*" -1536- ELSE */
                        }
                        else
                        {


                            /*" -1537- GO TO 9999-ERRO */

                            M_9999_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1538- END-IF */
                        }


                        /*" -1539- END-IF */
                    }


                    /*" -1540- END-IF */
                }


                /*" -1542- END-IF */
            }


            /*" -1543- IF INDAGE LESS ZEROS */

            if (INDAGE < 00)
            {

                /*" -1545- MOVE ZEROS TO OPCAOP-AGECTADEB. */
                _.Move(0, OPCAOP_AGECTADEB);
            }


            /*" -1546- IF INDOPR LESS ZEROS */

            if (INDOPR < 00)
            {

                /*" -1548- MOVE ZEROS TO OPCAOP-OPRCTADEB. */
                _.Move(0, OPCAOP_OPRCTADEB);
            }


            /*" -1549- IF INDNUM LESS ZEROS */

            if (INDNUM < 00)
            {

                /*" -1551- MOVE ZEROS TO OPCAOP-NUMCTADEB. */
                _.Move(0, OPCAOP_NUMCTADEB);
            }


            /*" -1552- IF INDDIG LESS ZEROS */

            if (INDDIG < 00)
            {

                /*" -1554- MOVE ZEROS TO OPCAOP-DIGCTADEB. */
                _.Move(0, OPCAOP_DIGCTADEB);
            }


            /*" -1556- IF INDCARTAO LESS ZEROS OR OPCAOP-CARTAOCRED NOT NUMERIC */

            if (INDCARTAO < 00 || !OPCAOP_CARTAOCRED.IsNumeric())
            {

                /*" -1558- MOVE ZEROS TO OPCAOP-CARTAOCRED. */
                _.Move(0, OPCAOP_CARTAOCRED);
            }


            /*" -1560- MOVE 'NAO' TO WS-ATUALIZA-OPCPAGVA */
            _.Move("NAO", WS_ATUALIZA_OPCPAGVA);

            /*" -1561- IF OPCAOP-PERIPGTO = 0 */

            if (OPCAOP_PERIPGTO == 0)
            {

                /*" -1562- IF PRODVG-PERIPGTO = 0 */

                if (PRODVG_PERIPGTO == 0)
                {

                    /*" -1563- CONTINUE */

                    /*" -1564- ELSE */
                }
                else
                {


                    /*" -1565- MOVE PRODVG-PERIPGTO TO OPCAOP-PERIPGTO */
                    _.Move(PRODVG_PERIPGTO, OPCAOP_PERIPGTO);

                    /*" -1566- MOVE 'SIM' TO WS-ATUALIZA-OPCPAGVA */
                    _.Move("SIM", WS_ATUALIZA_OPCPAGVA);

                    /*" -1567- END-IF */
                }


                /*" -1569- END-IF */
            }


            /*" -1571- IF OPCAOP-OPCAOPAG = '1' OR '2' OR '3' OR '4' OR '5' */

            if (OPCAOP_OPCAOPAG.In("1", "2", "3", "4", "5"))
            {

                /*" -1572- CONTINUE */

                /*" -1573- ELSE */
            }
            else
            {


                /*" -1574- IF OPCAOP-AGECTADEB EQUAL ZEROS */

                if (OPCAOP_AGECTADEB == 00)
                {

                    /*" -1575- IF OPCAOP-CARTAOCRED EQUAL ZEROS */

                    if (OPCAOP_CARTAOCRED == 00)
                    {

                        /*" -1576- MOVE 'SIM' TO WS-ATUALIZA-OPCPAGVA */
                        _.Move("SIM", WS_ATUALIZA_OPCPAGVA);

                        /*" -1581- MOVE '3' TO OPCAOP-OPCAOPAG */
                        _.Move("3", OPCAOP_OPCAOPAG);

                        /*" -1582- END-IF */
                    }


                    /*" -1583- ELSE */
                }
                else
                {


                    /*" -1584- MOVE 'SIM' TO WS-ATUALIZA-OPCPAGVA */
                    _.Move("SIM", WS_ATUALIZA_OPCPAGVA);

                    /*" -1585- MOVE '1' TO OPCAOP-OPCAOPAG */
                    _.Move("1", OPCAOP_OPCAOPAG);

                    /*" -1586- END-IF */
                }


                /*" -1588- END-IF */
            }


            /*" -1590- IF OPCAOP-DIA-DEB GREATER 0 AND OPCAOP-DIA-DEB LESS 29 */

            if (OPCAOP_DIA_DEB > 0 && OPCAOP_DIA_DEB < 29)
            {

                /*" -1591- CONTINUE */

                /*" -1592- ELSE */
            }
            else
            {


                /*" -1593- MOVE 'SIM' TO WS-ATUALIZA-OPCPAGVA */
                _.Move("SIM", WS_ATUALIZA_OPCPAGVA);

                /*" -1594- MOVE 10 TO OPCAOP-DIA-DEB */
                _.Move(10, OPCAOP_DIA_DEB);

                /*" -1596- END-IF */
            }


            /*" -1597- IF WS-ATUALIZA-OPCPAGVA EQUAL 'SIM' */

            if (WS_ATUALIZA_OPCPAGVA == "SIM")
            {

                /*" -1598- MOVE 'UPDATE OPCAO_PAG_VIDAZUL' TO COMANDO */
                _.Move("UPDATE OPCAO_PAG_VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1604- PERFORM M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1 */

                M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1();

                /*" -1606- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1607- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1608- END-IF */
                }


                /*" -1610- END-IF */
            }


            /*" -1612- IF OPCAOP-OPCAOPAG NOT EQUAL '1' AND '2' AND '3' AND '4' AND '5' */

            if (!OPCAOP_OPCAOPAG.In("1", "2", "3", "4", "5"))
            {

                /*" -1613- MOVE 1601 TO ERRPROVI-COD-ERRO */
                _.Move(1601, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                /*" -1614- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                /*" -1615- IF WS-COD-TP-MSG-CRITICA NOT EQUAL 03 */

                if (WS_COD_TP_MSG_CRITICA != 03)
                {

                    /*" -1616- MOVE '1' TO PROPVA-SITUACAO */
                    _.Move("1", PROPVA_SITUACAO);

                    /*" -1617- ADD 1 TO AC-DESPR-OPCAOPAG */
                    WS_WORK_AREAS.AC_DESPR_OPCAOPAG.Value = WS_WORK_AREAS.AC_DESPR_OPCAOPAG + 1;

                    /*" -1618- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1619- END-IF */
                }


                /*" -1621- END-IF */
            }


            /*" -1623- IF OPCAOP-PERIPGTO NOT EQUAL 0 AND 1 AND 2 AND 3 AND 6 AND 12 */

            if (!OPCAOP_PERIPGTO.In("0", "1", "2", "3", "6", "12"))
            {

                /*" -1624- MOVE 0802 TO ERRPROVI-COD-ERRO */
                _.Move(0802, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                /*" -1625- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                /*" -1626- IF WS-COD-TP-MSG-CRITICA NOT EQUAL 03 */

                if (WS_COD_TP_MSG_CRITICA != 03)
                {

                    /*" -1627- MOVE '1' TO PROPVA-SITUACAO */
                    _.Move("1", PROPVA_SITUACAO);

                    /*" -1628- ADD 1 TO AC-DESPR-PERIPGTO */
                    WS_WORK_AREAS.AC_DESPR_PERIPGTO.Value = WS_WORK_AREAS.AC_DESPR_PERIPGTO + 1;

                    /*" -1629- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1630- END-IF */
                }


                /*" -1632- END-IF */
            }


            /*" -1634- IF OPCAOP-DIA-DEB GREATER 0 AND OPCAOP-DIA-DEB LESS 29 */

            if (OPCAOP_DIA_DEB > 0 && OPCAOP_DIA_DEB < 29)
            {

                /*" -1635- CONTINUE */

                /*" -1636- ELSE */
            }
            else
            {


                /*" -1637- MOVE 0802 TO ERRPROVI-COD-ERRO */
                _.Move(0802, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                /*" -1638- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                /*" -1639- IF WS-COD-TP-MSG-CRITICA NOT EQUAL 03 */

                if (WS_COD_TP_MSG_CRITICA != 03)
                {

                    /*" -1640- MOVE '1' TO PROPVA-SITUACAO */
                    _.Move("1", PROPVA_SITUACAO);

                    /*" -1641- ADD 1 TO AC-DESPR-PERIPGTO */
                    WS_WORK_AREAS.AC_DESPR_PERIPGTO.Value = WS_WORK_AREAS.AC_DESPR_PERIPGTO + 1;

                    /*" -1642- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1643- END-IF */
                }


                /*" -1645- END-IF */
            }


            /*" -1649- IF (OPCAOP-OPCAOPAG EQUAL '1' OR '2' ) AND (OPCAOP-AGECTADEB EQUAL ZEROES OR OPCAOP-OPRCTADEB EQUAL ZEROES OR OPCAOP-NUMCTADEB EQUAL ZEROES) */

            if ((OPCAOP_OPCAOPAG.In("1", "2")) && (OPCAOP_AGECTADEB == 00 || OPCAOP_OPRCTADEB == 00 || OPCAOP_NUMCTADEB == 00))
            {

                /*" -1650- DISPLAY ' DESPREZADO CONTA CORR ...  ' PROPVA-NRCERTIF */
                _.Display($" DESPREZADO CONTA CORR ...  {PROPVA_NRCERTIF}");

                /*" -1651- MOVE 0901 TO ERRPROVI-COD-ERRO */
                _.Move(0901, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                /*" -1652- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                /*" -1653- IF WS-COD-TP-MSG-CRITICA NOT EQUAL 03 */

                if (WS_COD_TP_MSG_CRITICA != 03)
                {

                    /*" -1654- MOVE '1' TO PROPVA-SITUACAO */
                    _.Move("1", PROPVA_SITUACAO);

                    /*" -1655- ADD 1 TO AC-DESPR-CONTA */
                    WS_WORK_AREAS.AC_DESPR_CONTA.Value = WS_WORK_AREAS.AC_DESPR_CONTA + 1;

                    /*" -1656- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1657- END-IF */
                }


                /*" -1672- END-IF */
            }


            /*" -1673- IF PROPVA-ORIGEM-PROPOSTA NOT EQUAL 1000 */

            if (PROPVA_ORIGEM_PROPOSTA != 1000)
            {

                /*" -1675- IF PRODVG-ORIG-PRODU = 'MULT' OR PRODVG-ORIG-PRODU = 'CAMP' */

                if (PRODVG_ORIG_PRODU == "MULT" || PRODVG_ORIG_PRODU == "CAMP")
                {

                    /*" -1676- IF PROPVA-AGECOBR = ZEROES */

                    if (PROPVA_AGECOBR == 00)
                    {

                        /*" -1677- MOVE OPCAOP-AGECTADEB TO PROPVA-AGECOBR */
                        _.Move(OPCAOP_AGECTADEB, PROPVA_AGECOBR);

                        /*" -1678- END-IF */
                    }


                    /*" -1679- MOVE 'SELECT V0AGENCIACEF      ' TO COMANDO */
                    _.Move("SELECT V0AGENCIACEF      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -1685- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_6 */

                    M_0100_PROCESSA_PROPOSTA_DB_SELECT_6();

                    /*" -1688- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1689- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -1690- DISPLAY ' AGENCIA INEXISTENTE .....  ' PROPVA-NRCERTIF */
                            _.Display($" AGENCIA INEXISTENTE .....  {PROPVA_NRCERTIF}");

                            /*" -1691- MOVE 0102 TO ERRPROVI-COD-ERRO */
                            _.Move(0102, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                            /*" -1692- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                            M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                            /*" -1693- IF WS-COD-TP-MSG-CRITICA NOT EQUAL 03 */

                            if (WS_COD_TP_MSG_CRITICA != 03)
                            {

                                /*" -1694- MOVE '1' TO PROPVA-SITUACAO */
                                _.Move("1", PROPVA_SITUACAO);

                                /*" -1695- ADD 1 TO AC-DESPR-AGENCCEF */
                                WS_WORK_AREAS.AC_DESPR_AGENCCEF.Value = WS_WORK_AREAS.AC_DESPR_AGENCCEF + 1;

                                /*" -1696- GO TO 0100-NEXT */

                                M_0100_NEXT(); //GOTO
                                return;

                                /*" -1697- END-IF */
                            }


                            /*" -1698- ELSE */
                        }
                        else
                        {


                            /*" -1699- GO TO 9999-ERRO */

                            M_9999_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1700- END-IF */
                        }


                        /*" -1701- END-IF */
                    }


                    /*" -1702- END-IF */
                }


                /*" -1704- END-IF */
            }


            /*" -1719- MOVE ZEROS TO COBERP-IMPMORNATU COBERP-IMPMORACID COBERP-IMPINVPERM COBERP-IMPAMDS COBERP-IMPDH COBERP-IMPDIT COBERP-VLPREMIO COBERP-PRMVG COBERP-PRMAP COBERP-IMPSEGCDG COBERP-VLCUSTCDG COBERP-VLCUSTCAP COBERP-QTTITCAP */
            _.Move(0, COBERP_IMPMORNATU, COBERP_IMPMORACID, COBERP_IMPINVPERM, COBERP_IMPAMDS, COBERP_IMPDH, COBERP_IMPDIT, COBERP_VLPREMIO, COBERP_PRMVG, COBERP_PRMAP, COBERP_IMPSEGCDG, COBERP_VLCUSTCDG, COBERP_VLCUSTCAP, COBERP_QTTITCAP);

            /*" -1721- IF PROPVA-NUM-APOLICE EQUAL 109300000635 AND PROPVA-CODSUBES EQUAL 1 */

            if (PROPVA_NUM_APOLICE == 109300000635 && PROPVA_CODSUBES == 1)
            {

                /*" -1727- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_7 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_7();

                /*" -1730- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1732- DISPLAY 'ERRO LEITURA MINIMO OCORHIST CERTIF = ' PROPVA-NRCERTIF */
                    _.Display($"ERRO LEITURA MINIMO OCORHIST CERTIF = {PROPVA_NRCERTIF}");

                    /*" -1733- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1734- END-IF */
                }


                /*" -1735- MOVE 'SELECT V0COBERPROPVA X1  ' TO COMANDO */
                _.Move("SELECT V0COBERPROPVA X1  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1774- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_8 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_8();

                /*" -1776- ELSE */
            }
            else
            {


                /*" -1777- MOVE 'SELECT V0COBERPROPVA X2  ' TO COMANDO */
                _.Move("SELECT V0COBERPROPVA X2  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1814- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_9 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_9();

                /*" -1817- END-IF. */
            }


            /*" -1818- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1819- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1821- END-IF */
            }


            /*" -1826- IF PROPVA-CODPRODU EQUAL 9351 OR 9352 OR 9353 OR 9310 OR JVPRD9351 OR JVPRD9352 OR JVPRD9353 OR JVPRD9310 */

            if (PROPVA_CODPRODU.In("9351", "9352", "9353", "9310", JVBKINCL.JV_PRODUTOS.JVPRD9351.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9352.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9353.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
            {

                /*" -1827- SET WS-NAO-DECLINADO TO TRUE */
                WS_DECLINADO["WS_NAO_DECLINADO"] = true;

                /*" -1828- PERFORM 0250-00-CALCULA-LIMITE-RISCO */

                M_0250_00_CALCULA_LIMITE_RISCO_SECTION();

                /*" -1829- IF WS-SIM-DECLINADO */

                if (WS_DECLINADO["WS_SIM_DECLINADO"])
                {

                    /*" -1830- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1831- END-IF */
                }


                /*" -1833- END-IF */
            }


            /*" -1834- IF PROPVA-CODPRODU EQUAL 7707 */

            if (PROPVA_CODPRODU == 7707)
            {

                /*" -1835- CONTINUE */

                /*" -1836- ELSE */
            }
            else
            {


                /*" -1839- IF COBERP-IMPMORNATU EQUAL 0 OR COBERP-VLPREMIO EQUAL 0 OR COBERP-PRMVG EQUAL 0 */

                if (COBERP_IMPMORNATU == 0 || COBERP_VLPREMIO == 0 || COBERP_PRMVG == 0)
                {

                    /*" -1840- DISPLAY ' DESPREZADO HISCOBPR .....  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO HISCOBPR .....  {PROPVA_NRCERTIF}");

                    /*" -1841- MOVE 0603 TO ERRPROVI-COD-ERRO */
                    _.Move(0603, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -1842- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                    M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                    /*" -1843- IF WS-COD-TP-MSG-CRITICA NOT EQUAL 03 */

                    if (WS_COD_TP_MSG_CRITICA != 03)
                    {

                        /*" -1844- MOVE '1' TO PROPVA-SITUACAO */
                        _.Move("1", PROPVA_SITUACAO);

                        /*" -1845- ADD 1 TO AC-DESPR-HISCOBPR */
                        WS_WORK_AREAS.AC_DESPR_HISCOBPR.Value = WS_WORK_AREAS.AC_DESPR_HISCOBPR + 1;

                        /*" -1846- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -1847- END-IF */
                    }


                    /*" -1848- END-IF */
                }


                /*" -1850- END-IF */
            }


            /*" -1851- IF PROPVA-INRPROPOS < 0 */

            if (PROPVA_INRPROPOS < 0)
            {

                /*" -1852- MOVE 0 TO PROPVA-NRPROPOS */
                _.Move(0, PROPVA_NRPROPOS);

                /*" -1854- END-IF */
            }


            /*" -1855- IF COBERP-IVLCUSTAUXF < 0 */

            if (COBERP_IVLCUSTAUXF < 0)
            {

                /*" -1856- MOVE 0 TO COBERP-VLCUSTAUXF */
                _.Move(0, COBERP_VLCUSTAUXF);

                /*" -1858- END-IF */
            }


            /*" -1859- IF COBERP-IIMPSEGAUXF < 0 */

            if (COBERP_IIMPSEGAUXF < 0)
            {

                /*" -1860- MOVE 0 TO COBERP-IMPSEGAUXF */
                _.Move(0, COBERP_IMPSEGAUXF);

                /*" -1862- END-IF */
            }


            /*" -1863- IF COBERP-IQTTITCAP < 0 */

            if (COBERP_IQTTITCAP < 0)
            {

                /*" -1864- MOVE 0 TO COBERP-QTTITCAP */
                _.Move(0, COBERP_QTTITCAP);

                /*" -1866- END-IF */
            }


            /*" -1867- IF PROPVA-INRMATRFUN < 0 */

            if (PROPVA_INRMATRFUN < 0)
            {

                /*" -1868- MOVE 0 TO PROPVA-NRMATRFUN */
                _.Move(0, PROPVA_NRMATRFUN);

                /*" -1870- END-IF */
            }


            /*" -1871- IF PROPVA-ICODCCT < 0 */

            if (PROPVA_ICODCCT < 0)
            {

                /*" -1872- MOVE 0 TO PROPVA-CODCCT */
                _.Move(0, PROPVA_CODCCT);

                /*" -1874- END-IF */
            }


            /*" -1875- IF PROPVA-NUM-APOLICE EQUAL 109300000635 */

            if (PROPVA_NUM_APOLICE == 109300000635)
            {

                /*" -1876- MOVE 'SELECT V0HISTCOBVA 1' TO COMANDO */
                _.Move("SELECT V0HISTCOBVA 1", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1882- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_10 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_10();

                /*" -1884- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1885- IF SQLCODE EQUAL 100 OR -811 */

                    if (DB.SQLCODE.In("100", "-811"))
                    {

                        /*" -1886- CONTINUE */

                        /*" -1887- ELSE */
                    }
                    else
                    {


                        /*" -1888- DISPLAY 'NRCERTIF  = ' PROPVA-NRCERTIF */
                        _.Display($"NRCERTIF  = {PROPVA_NRCERTIF}");

                        /*" -1889- DISPLAY 'NRPARCEL  = ' V0COBER-MINOCOR */
                        _.Display($"NRPARCEL  = {V0COBER_MINOCOR}");

                        /*" -1890- GO TO 9999-ERRO */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1891- END-IF */
                    }


                    /*" -1892- END-IF */
                }


                /*" -1893- ELSE */
            }
            else
            {


                /*" -1894- MOVE 'SELECT V0PARCELVA 2' TO COMANDO */
                _.Move("SELECT V0PARCELVA 2", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1900- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_11 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_11();

                /*" -1903- END-IF */
            }


            /*" -1904- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1905- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1906- MOVE ZEROS TO V0HCOB-VLPRMTOT */
                    _.Move(0, V0HCOB_VLPRMTOT);

                    /*" -1907- ELSE */
                }
                else
                {


                    /*" -1908- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1909- END-IF */
                }


                /*" -1911- END-IF */
            }


            /*" -1913- IF PRODVG-ORIG-PRODU = 'MULT' OR 'CAMP' AND PROPVA-SITUACAO = '0' */

            if (PRODVG_ORIG_PRODU.In("MULT", "CAMP") && PROPVA_SITUACAO == "0")
            {

                /*" -1914- PERFORM 1000-INTEGRA-MULTIPREMIADO THRU 1000-FIM */

                M_1000_INTEGRA_MULTIPREMIADO_SECTION();

                M_1000_AJUSTA_DTPROXVEN();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/


                /*" -1915- MOVE PRODVG-CODRELAT TO RELATO-CODRELAT */
                _.Move(PRODVG_CODRELAT, RELATO_CODRELAT);

                /*" -1916- IF WSQLCODE-PLANOS = 100 */

                if (WS_WORK_AREAS.WSQLCODE_PLANOS == 100)
                {

                    /*" -1917- DISPLAY ' DESPREZADO PLAVAVGA 1 ...  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO PLAVAVGA 1 ...  {PROPVA_NRCERTIF}");

                    /*" -1918- MOVE 0604 TO ERRPROVI-COD-ERRO */
                    _.Move(0604, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -1919- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                    M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                    /*" -1920- IF WS-COD-TP-MSG-CRITICA NOT EQUAL 03 */

                    if (WS_COD_TP_MSG_CRITICA != 03)
                    {

                        /*" -1921- MOVE '1' TO PROPVA-SITUACAO */
                        _.Move("1", PROPVA_SITUACAO);

                        /*" -1922- ADD 1 TO AC-DESPR-PLAVAVGA */
                        WS_WORK_AREAS.AC_DESPR_PLAVAVGA.Value = WS_WORK_AREAS.AC_DESPR_PLAVAVGA + 1;

                        /*" -1923- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -1924- END-IF */
                    }


                    /*" -1925- END-IF */
                }


                /*" -1927- END-IF */
            }


            /*" -1929- IF PRODVG-ORIG-PRODU = 'VIDAZUL' AND PROPVA-SITUACAO = '0' */

            if (PRODVG_ORIG_PRODU == "VIDAZUL" && PROPVA_SITUACAO == "0")
            {

                /*" -1930- PERFORM 1100-INTEGRA-VIDAZUL THRU 1100-FIM */

                M_1100_INTEGRA_VIDAZUL_SECTION();

                M_1100_AJUSTA_DTPROXVEN();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/


                /*" -1931- IF PRODVG-CODPRODAZ = 'EXC' */

                if (PRODVG_CODPRODAZ == "EXC")
                {

                    /*" -1932- MOVE 'VG0420B' TO RELATO-CODRELAT */
                    _.Move("VG0420B", RELATO_CODRELAT);

                    /*" -1933- ELSE */
                }
                else
                {


                    /*" -1934- IF PRODVG-CODPRODAZ = 'SNR' */

                    if (PRODVG_CODPRODAZ == "SNR")
                    {

                        /*" -1935- MOVE 'VG0420B' TO RELATO-CODRELAT */
                        _.Move("VG0420B", RELATO_CODRELAT);

                        /*" -1936- END-IF */
                    }


                    /*" -1937- END-IF */
                }


                /*" -1938- IF WSQLCODE-PLANOS = 100 */

                if (WS_WORK_AREAS.WSQLCODE_PLANOS == 100)
                {

                    /*" -1939- DISPLAY ' DESPREZADO PLAVAVGA 2 ...  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO PLAVAVGA 2 ...  {PROPVA_NRCERTIF}");

                    /*" -1940- MOVE 0604 TO ERRPROVI-COD-ERRO */
                    _.Move(0604, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -1941- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                    M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                    /*" -1942- IF WS-COD-TP-MSG-CRITICA NOT EQUAL 03 */

                    if (WS_COD_TP_MSG_CRITICA != 03)
                    {

                        /*" -1943- MOVE '1' TO PROPVA-SITUACAO */
                        _.Move("1", PROPVA_SITUACAO);

                        /*" -1944- ADD 1 TO AC-DESPR-PLAVAVGA */
                        WS_WORK_AREAS.AC_DESPR_PLAVAVGA.Value = WS_WORK_AREAS.AC_DESPR_PLAVAVGA + 1;

                        /*" -1945- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -1946- END-IF */
                    }


                    /*" -1947- END-IF */
                }


                /*" -1949- END-IF */
            }


            /*" -1951- IF PRODVG-ORIG-PRODU = ( 'GLOBAL' ) AND PROPVA-SITUACAO = '0' */

            if (PRODVG_ORIG_PRODU == ("GLOBAL") && PROPVA_SITUACAO == "0")
            {

                /*" -1952- PERFORM 2000-INTEGRA-EMPRESA-GLOBAL THRU 2000-FIM */

                M_2000_INTEGRA_EMPRESA_GLOBAL_SECTION();

                M_2000_AJUSTA_DTPROXVEN();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/


                /*" -1953- MOVE 'VL0420B' TO RELATO-CODRELAT */
                _.Move("VL0420B", RELATO_CODRELAT);

                /*" -1954- IF WSQLCODE-PLANOS = 100 */

                if (WS_WORK_AREAS.WSQLCODE_PLANOS == 100)
                {

                    /*" -1955- DISPLAY ' DESPREZADO PLAVAVGA 3 ...  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO PLAVAVGA 3 ...  {PROPVA_NRCERTIF}");

                    /*" -1956- MOVE 0604 TO ERRPROVI-COD-ERRO */
                    _.Move(0604, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -1957- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                    M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                    /*" -1958- IF WS-COD-TP-MSG-CRITICA NOT EQUAL 03 */

                    if (WS_COD_TP_MSG_CRITICA != 03)
                    {

                        /*" -1959- MOVE '1' TO PROPVA-SITUACAO */
                        _.Move("1", PROPVA_SITUACAO);

                        /*" -1960- ADD 1 TO AC-DESPR-PLAVAVGA */
                        WS_WORK_AREAS.AC_DESPR_PLAVAVGA.Value = WS_WORK_AREAS.AC_DESPR_PLAVAVGA + 1;

                        /*" -1961- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -1962- END-IF */
                    }


                    /*" -1963- END-IF */
                }


                /*" -1965- END-IF */
            }


            /*" -1968- IF PROPVA-NUM-APOLICE = 109700000027 AND PROPVA-CODSUBES = 1 AND PROPVA-SITUACAO = '0' */

            if (PROPVA_NUM_APOLICE == 109700000027 && PROPVA_CODSUBES == 1 && PROPVA_SITUACAO == "0")
            {

                /*" -1969- PERFORM 3000-INTEGRA-JORNAL-FENAM THRU 3000-FIM */

                M_3000_INTEGRA_JORNAL_FENAM_SECTION();

                M_3000_AJUSTA_DTPROXVEN();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_FIM*/


                /*" -1970- MOVE 'VA0424B' TO RELATO-CODRELAT */
                _.Move("VA0424B", RELATO_CODRELAT);

                /*" -1971- IF WSQLCODE-PLANOS = 100 */

                if (WS_WORK_AREAS.WSQLCODE_PLANOS == 100)
                {

                    /*" -1972- DISPLAY ' DESPREZADO PLAVAVGA 4 ...  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO PLAVAVGA 4 ...  {PROPVA_NRCERTIF}");

                    /*" -1973- MOVE 0604 TO ERRPROVI-COD-ERRO */
                    _.Move(0604, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -1974- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                    M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                    /*" -1975- IF WS-COD-TP-MSG-CRITICA NOT EQUAL 03 */

                    if (WS_COD_TP_MSG_CRITICA != 03)
                    {

                        /*" -1976- MOVE '1' TO PROPVA-SITUACAO */
                        _.Move("1", PROPVA_SITUACAO);

                        /*" -1977- ADD 1 TO AC-DESPR-PLAVAVGA */
                        WS_WORK_AREAS.AC_DESPR_PLAVAVGA.Value = WS_WORK_AREAS.AC_DESPR_PLAVAVGA + 1;

                        /*" -1978- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -1979- END-IF */
                    }


                    /*" -1980- END-IF */
                }


                /*" -1982- END-IF */
            }


            /*" -1984- IF PRODVG-ORIG-PRODU = ( 'AVERB' ) AND PROPVA-SITUACAO = '0' */

            if (PRODVG_ORIG_PRODU == ("AVERB") && PROPVA_SITUACAO == "0")
            {

                /*" -1985- PERFORM 4000-INTEGRA-PREF-VIDA THRU 4000-FIM */

                M_4000_INTEGRA_PREF_VIDA_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4000_FIM*/


                /*" -1986- MOVE PRODVG-CODRELAT TO RELATO-CODRELAT */
                _.Move(PRODVG_CODRELAT, RELATO_CODRELAT);

                /*" -1987- IF WSQLCODE-PLANOS = 100 */

                if (WS_WORK_AREAS.WSQLCODE_PLANOS == 100)
                {

                    /*" -1988- DISPLAY ' DESPREZADO PLAVAVGA 5 ...  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO PLAVAVGA 5 ...  {PROPVA_NRCERTIF}");

                    /*" -1989- MOVE 0604 TO ERRPROVI-COD-ERRO */
                    _.Move(0604, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -1990- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                    M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                    /*" -1991- IF WS-COD-TP-MSG-CRITICA NOT EQUAL 03 */

                    if (WS_COD_TP_MSG_CRITICA != 03)
                    {

                        /*" -1992- MOVE '1' TO PROPVA-SITUACAO */
                        _.Move("1", PROPVA_SITUACAO);

                        /*" -1993- ADD 1 TO AC-DESPR-PLAVAVGA */
                        WS_WORK_AREAS.AC_DESPR_PLAVAVGA.Value = WS_WORK_AREAS.AC_DESPR_PLAVAVGA + 1;

                        /*" -1994- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -1995- END-IF */
                    }


                    /*" -1996- END-IF */
                }


                /*" -1998- END-IF */
            }


            /*" -2000- IF PRODVG-ORIG-PRODU = 'PAREN' OR 'CEF DEB CC' AND PROPVA-SITUACAO = '0' */

            if (PRODVG_ORIG_PRODU.In("PAREN", "CEF DEB CC") && PROPVA_SITUACAO == "0")
            {

                /*" -2001- PERFORM 5000-INTEGRA-PARENTES-PV THRU 5000-FIM */

                M_5000_INTEGRA_PARENTES_PV_SECTION();

                M_5000_AJUSTA_DTPROXVEN();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -2002- MOVE PRODVG-CODRELAT TO RELATO-CODRELAT */
                _.Move(PRODVG_CODRELAT, RELATO_CODRELAT);

                /*" -2003- IF WSQLCODE-PLANOS = 100 */

                if (WS_WORK_AREAS.WSQLCODE_PLANOS == 100)
                {

                    /*" -2004- DISPLAY ' DESPREZADO PLAVAVGA 6 ...  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO PLAVAVGA 6 ...  {PROPVA_NRCERTIF}");

                    /*" -2005- MOVE 0604 TO ERRPROVI-COD-ERRO */
                    _.Move(0604, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -2006- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                    M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                    /*" -2007- IF WS-COD-TP-MSG-CRITICA NOT EQUAL 03 */

                    if (WS_COD_TP_MSG_CRITICA != 03)
                    {

                        /*" -2008- MOVE '1' TO PROPVA-SITUACAO */
                        _.Move("1", PROPVA_SITUACAO);

                        /*" -2009- ADD 1 TO AC-DESPR-PLAVAVGA */
                        WS_WORK_AREAS.AC_DESPR_PLAVAVGA.Value = WS_WORK_AREAS.AC_DESPR_PLAVAVGA + 1;

                        /*" -2010- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -2011- END-IF */
                    }


                    /*" -2012- END-IF */
                }


                /*" -2014- END-IF */
            }


            /*" -2016- IF PRODVG-ORIG-PRODU = 'CAAES' AND PROPVA-SITUACAO = '0' */

            if (PRODVG_ORIG_PRODU == "CAAES" && PROPVA_SITUACAO == "0")
            {

                /*" -2017- PERFORM 5000-INTEGRA-PARENTES-PV THRU 5000-FIM */

                M_5000_INTEGRA_PARENTES_PV_SECTION();

                M_5000_AJUSTA_DTPROXVEN();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -2018- MOVE '       ' TO RELATO-CODRELAT */
                _.Move("       ", RELATO_CODRELAT);

                /*" -2019- IF WSQLCODE-PLANOS = 100 */

                if (WS_WORK_AREAS.WSQLCODE_PLANOS == 100)
                {

                    /*" -2020- DISPLAY ' DESPREZADO PLAVAVGA 7 ...  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO PLAVAVGA 7 ...  {PROPVA_NRCERTIF}");

                    /*" -2021- MOVE 0604 TO ERRPROVI-COD-ERRO */
                    _.Move(0604, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -2022- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                    M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                    /*" -2023- IF WS-COD-TP-MSG-CRITICA NOT EQUAL 03 */

                    if (WS_COD_TP_MSG_CRITICA != 03)
                    {

                        /*" -2024- MOVE '1' TO PROPVA-SITUACAO */
                        _.Move("1", PROPVA_SITUACAO);

                        /*" -2025- ADD 1 TO AC-DESPR-PLAVAVGA */
                        WS_WORK_AREAS.AC_DESPR_PLAVAVGA.Value = WS_WORK_AREAS.AC_DESPR_PLAVAVGA + 1;

                        /*" -2026- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -2027- END-IF */
                    }


                    /*" -2028- END-IF */
                }


                /*" -2030- END-IF */
            }


            /*" -2032- PERFORM 8595-00-VERIFICA-CRTCA-PEND */

            M_8595_00_VERIFICA_CRTCA_PEND_SECTION();

            /*" -2033- IF WS-ERRO-COUNT > ZEROS */

            if (WS_ERRO_COUNT > 00)
            {

                /*" -2034- IF PROPVA-ACATAMENTO EQUAL 'S' */

                if (PROPVA_ACATAMENTO == "S")
                {

                    /*" -2035- PERFORM 0116-FECHAR-MSG-ERRO-ACAT */

                    M_0116_FECHAR_MSG_ERRO_ACAT_SECTION();

                    /*" -2036- ELSE */
                }
                else
                {


                    /*" -2038- DISPLAY 'CERTIFICADO POSSUI CRITICA PENDENTE CADASTRADA '. ' PROPVA-NRCERTIF ' ' WS-ERRO-COUNT */

                    $"CERTIFICADO POSSUI CRITICA PENDENTE CADASTRADA {RCAPS.DCLRCAPS} PROPVA-NRCERTIF {WS_ERRO_COUNT}"
                    .Display();

                    /*" -2039- MOVE '1' TO PROPVA-SITUACAO */
                    _.Move("1", PROPVA_SITUACAO);

                    /*" -2040- ADD 1 TO AC-DESPR-CRTCA-PRP */
                    WS_WORK_AREAS.AC_DESPR_CRTCA_PRP.Value = WS_WORK_AREAS.AC_DESPR_CRTCA_PRP + 1;

                    /*" -2041- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -2042- END-IF */
                }


                /*" -2044- END-IF */
            }


            /*" -2045- MOVE 1 TO WS-COD-CRITICA */
            _.Move(1, WS_COD_CRITICA);

            /*" -2048- PERFORM 8580-00-CONS-COD-CRITICA THRU 8580-99-SAIDA */

            M_8580_00_CONS_COD_CRITICA_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8580_99_SAIDA*/


            /*" -2049- IF VG001-IND-EXISTE EQUAL 'N' */

            if (SPVG001V.VG001_IND_EXISTE == "N")
            {

                /*" -2051- PERFORM 8550-00-PROCURA-RISCO-PROP THRU 8550-99-EXIT */

                M_8550_00_PROCURA_RISCO_PROP_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8550_99_EXIT*/


                /*" -2053- ELSE */
            }
            else
            {


                /*" -2054- IF LK-VG001-S-STA-CRITICA NOT EQUAL '6' */

                if (SPVG001W.LK_VG001_S_STA_CRITICA != "6")
                {

                    /*" -2056- DISPLAY 'CERTIF. EM ANALISE DE CRITICA.......: ' PROPVA-NRCERTIF */
                    _.Display($"CERTIF. EM ANALISE DE CRITICA.......: {PROPVA_NRCERTIF}");

                    /*" -2057- MOVE '1' TO PROPVA-SITUACAO */
                    _.Move("1", PROPVA_SITUACAO);

                    /*" -2058- ADD 1 TO WS-QT-EM-CRITICA */
                    WS_QT_EM_CRITICA.Value = WS_QT_EM_CRITICA + 1;

                    /*" -2059- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -2060- ELSE */
                }
                else
                {


                    /*" -2062- DISPLAY 'LIBERADO PARA EMISSAO APOS ANALISE..: ' PROPVA-NRCERTIF */
                    _.Display($"LIBERADO PARA EMISSAO APOS ANALISE..: {PROPVA_NRCERTIF}");

                    /*" -2063- ADD 1 TO WS-QT-LIBERADO-EMISSAO */
                    WS_QT_LIBERADO_EMISSAO.Value = WS_QT_LIBERADO_EMISSAO + 1;

                    /*" -2064- END-IF */
                }


                /*" -2083- END-IF */
            }


            /*" -2084- IF PROPVA-SITUACAO = '7' */

            if (PROPVA_SITUACAO == "7")
            {

                /*" -2086- PERFORM 8600-PRIMEIRA-COBRANCA THRU 8600-FIM */

                M_8600_PRIMEIRA_COBRANCA_SECTION();

                M_8600_10_CONTINUA();

                M_8600_15_INSERT_V0HISTCOBVA();

                M_8600_CONTINUA();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8600_FIM*/


                /*" -2088- END-IF */
            }


            /*" -2089- IF PROPVA-SITUACAO-ORIGINAL = '0' */

            if (PROPVA_SITUACAO_ORIGINAL == "0")
            {

                /*" -2090- IF PROPVA-SITUACAO = '3' */

                if (PROPVA_SITUACAO == "3")
                {

                    /*" -2092- IF WTEM-MOVIMVGA = 'SIM' NEXT SENTENCE */

                    if (WS_WORK_AREAS.WTEM_MOVIMVGA == "SIM")
                    {

                        /*" -2093- ELSE */
                    }
                    else
                    {


                        /*" -2095- MOVE PROPVA-SITUACAO-ORIGINAL TO PROPVA-SITUACAO */
                        _.Move(PROPVA_SITUACAO_ORIGINAL, PROPVA_SITUACAO);

                        /*" -2097- DISPLAY '*** PROPOSTA SEM INCLUSAO NA V0MOVIMENTO ' PROPVA-NRCERTIF ' ' PROPVA-SITUACAO */

                        $"*** PROPOSTA SEM INCLUSAO NA V0MOVIMENTO {PROPVA_NRCERTIF} {PROPVA_SITUACAO}"
                        .Display();

                        /*" -2098- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -2099- END-IF */
                    }


                    /*" -2101- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -2102- END-IF */
                }


                /*" -2104- END-IF. */
            }


            /*" -2105- IF PROPVA-SITUACAO = '3' */

            if (PROPVA_SITUACAO == "3")
            {

                /*" -2106- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO */
                _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

                /*" -2107- MOVE 'SELECT COBRANCA_MENS_VGAP1 ' TO COMANDO */
                _.Move("SELECT COBRANCA_MENS_VGAP1 ", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2118- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_12 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_12();

                /*" -2120- IF SQLCODE EQUAL ZEROES */

                if (DB.SQLCODE == 00)
                {

                    /*" -2121- MOVE 6 TO RELATO-OPERACAO */
                    _.Move(6, RELATO_OPERACAO);

                    /*" -2122- MOVE 2 TO RELATO-NRPARCEL */
                    _.Move(2, RELATO_NRPARCEL);

                    /*" -2123- PERFORM 0200-SOLICITA-CERTIFICADO THRU 0200-FIM */

                    M_0200_SOLICITA_CERTIFICADO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/


                    /*" -2124- PERFORM 1110-VERIFICA-RCAP THRU 1110-FIM */

                    M_1110_VERIFICA_RCAP_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1110_FIM*/


                    /*" -2125- ELSE */
                }
                else
                {


                    /*" -2126- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -2128- MOVE ZEROS TO RELATO-OPERACAO RELATO-NRPARCEL */
                        _.Move(0, RELATO_OPERACAO, RELATO_NRPARCEL);

                        /*" -2129- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO */
                        _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

                        /*" -2130- MOVE 'SELECT COBRANCA_MENS_VGAP2 ' TO COMANDO */
                        _.Move("SELECT COBRANCA_MENS_VGAP2 ", WABEND.LOCALIZA_ABEND_2.COMANDO);

                        /*" -2141- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_13 */

                        M_0100_PROCESSA_PROPOSTA_DB_SELECT_13();

                        /*" -2143- IF SQLCODE EQUAL ZEROES */

                        if (DB.SQLCODE == 00)
                        {

                            /*" -2145- MOVE 5 TO RELATO-OPERACAO RELATO-NRPARCEL */
                            _.Move(5, RELATO_OPERACAO, RELATO_NRPARCEL);

                            /*" -2146- PERFORM 0200-SOLICITA-CERTIFICADO THRU 0200-FIM */

                            M_0200_SOLICITA_CERTIFICADO_SECTION();
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/


                            /*" -2147- PERFORM 1110-VERIFICA-RCAP THRU 1110-FIM */

                            M_1110_VERIFICA_RCAP_SECTION();
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1110_FIM*/


                            /*" -2148- ELSE */
                        }
                        else
                        {


                            /*" -2149- IF SQLCODE NOT EQUAL 100 */

                            if (DB.SQLCODE != 100)
                            {

                                /*" -2150- GO TO 9999-ERRO */

                                M_9999_ERRO_SECTION(); //GOTO
                                return;

                                /*" -2151- ELSE */
                            }
                            else
                            {


                                /*" -2152- PERFORM 0200-SOLICITA-CERTIFICADO THRU 0200-FIM */

                                M_0200_SOLICITA_CERTIFICADO_SECTION();
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/


                                /*" -2153- PERFORM 1110-VERIFICA-RCAP THRU 1110-FIM */

                                M_1110_VERIFICA_RCAP_SECTION();
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1110_FIM*/


                                /*" -2154- END-IF */
                            }


                            /*" -2155- END-IF */
                        }


                        /*" -2156- ELSE */
                    }
                    else
                    {


                        /*" -2157- GO TO 9999-ERRO */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2158- END-IF */
                    }


                    /*" -2159- END-IF */
                }


                /*" -2161- END-IF. */
            }


            /*" -2163- IF PROPVA-NUM-APOLICE = 97010000889 AND PROPVA-SITUACAO = '3' */

            if (PROPVA_NUM_APOLICE == 97010000889 && PROPVA_SITUACAO == "3")
            {

                /*" -2164- PERFORM 0300-VERIFICA-CROT THRU 0300-FIM */

                M_0300_VERIFICA_CROT_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_FIM*/


                /*" -2171- END-IF */
            }


            /*" -2172- IF PROPVA-SITUACAO = '3' */

            if (PROPVA_SITUACAO == "3")
            {

                /*" -2173- IF PRODVG-ORIG-PRODU = ( 'MULT' ) */

                if (PRODVG_ORIG_PRODU == ("MULT"))
                {

                    /*" -2174- PERFORM R0397-00-PROXIMO-FOLHETO THRU R0397-FIM */

                    R0397_00_PROXIMO_FOLHETO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0397_FIM*/


                    /*" -2175- PERFORM 0400-GERA-MOV-FOLHETOS THRU 0400-FIM */

                    M_0400_GERA_MOV_FOLHETOS_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0400_FIM*/


                    /*" -2176- END-IF */
                }


                /*" -2178- END-IF */
            }


            /*" -2184- IF CANAL-VENDA-GITEL OR PROPOSTA-CACB OR PROPOSTA-COPESP OR PROPVA-DTPROXVEN-S EQUAL '9999-12-31' */

            if (WS_WORK_AREAS.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_GITEL"] || WS_WORK_AREAS.FILLER_6.W_CANAL_PROPOSTA1["PROPOSTA_CACB"] || WS_WORK_AREAS.FILLER_6.W_CANAL_PROPOSTA1["PROPOSTA_COPESP"] || PROPVA_DTPROXVEN_S == "9999-12-31")
            {

                /*" -2185- MOVE PROPVA-DTPROXVEN-S TO PROPVA-DTPROXVEN */
                _.Move(PROPVA_DTPROXVEN_S, PROPVA_DTPROXVEN);

                /*" -2187- END-IF */
            }


            /*" -2188- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2190- MOVE 'UPDATE V0PROPOSTAVA 04' TO COMANDO. */
            _.Move("UPDATE V0PROPOSTAVA 04", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2202- PERFORM M_0100_PROCESSA_PROPOSTA_DB_UPDATE_2 */

            M_0100_PROCESSA_PROPOSTA_DB_UPDATE_2();

            /*" -2205- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2206- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2208- END-IF */
            }


            /*" -2210- ADD 1 TO AC-INCLUSOES */
            WS_WORK_AREAS.AC_INCLUSOES.Value = WS_WORK_AREAS.AC_INCLUSOES + 1;

            /*" -2211- IF PROPVA-SITUACAO EQUAL '3' */

            if (PROPVA_SITUACAO == "3")
            {

                /*" -2212- ADD 1 TO AC-INTEGRADOS */
                WS_WORK_AREAS.AC_INTEGRADOS.Value = WS_WORK_AREAS.AC_INTEGRADOS + 1;

                /*" -2213- ELSE */
            }
            else
            {


                /*" -2214- IF PROPVA-SITUACAO EQUAL '8' */

                if (PROPVA_SITUACAO == "8")
                {

                    /*" -2215- ADD 1 TO AC-COBRADOS */
                    WS_WORK_AREAS.AC_COBRADOS.Value = WS_WORK_AREAS.AC_COBRADOS + 1;

                    /*" -2216- END-IF */
                }


                /*" -2218- END-IF */
            }


            /*" -2218- . */

            /*" -0- FLUXCONTROL_PERFORM M_0100_NEXT */

            M_0100_NEXT();

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_1()
        {
            /*" -1240- EXEC SQL SELECT CODPRODAZ, PERIPGTO, ESTR_COBR, ORIG_PRODU, COD_AGENCIADOR, TEM_SAF, TEM_CDG, CODRELAT, COBERADIC_PREMIO, CUSTOCAP_TOTAL, DESCONTO_ADESAO, CODPRODU, VALUE(RISCO, '1' ), SITPLANCEF, ARQ_FDCAP, COD_RUBRICA INTO :PRODVG-CODPRODAZ, :PRODVG-PERIPGTO, :PRODVG-ESTR-COBR :VIND-ESTR-COBR , :PRODVG-ORIG-PRODU:VIND-ORIG-PRODU, :PRODVG-AGENCIADOR:VIND-AGENCIADOR, :PRODVG-TEM-SAF:VIND-TEM-SAF, :PRODVG-TEM-CDG:VIND-TEM-CDG, :PRODVG-CODRELAT:VIND-CODRELAT, :PRODVG-COBERADIC-PREMIO, :PRODVG-CUSTOCAP-TOTAL, :PRODVG-DESCONTO-ADESAO, :PRODVG-COD-PRODUTO, :PRODVG-RISCO, :PRODVG-SITPLANCEF, :PRODVG-ARQ-FDCAP:WS-IND-ARQFDCAP, :PRODVG-COD-RUBRICA:WS-IND-RUBRICA FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND ESTR_EMISS = 'MULT' WITH UR END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODVG_CODPRODAZ, PRODVG_CODPRODAZ);
                _.Move(executed_1.PRODVG_PERIPGTO, PRODVG_PERIPGTO);
                _.Move(executed_1.PRODVG_ESTR_COBR, PRODVG_ESTR_COBR);
                _.Move(executed_1.VIND_ESTR_COBR, VIND_ESTR_COBR);
                _.Move(executed_1.PRODVG_ORIG_PRODU, PRODVG_ORIG_PRODU);
                _.Move(executed_1.VIND_ORIG_PRODU, VIND_ORIG_PRODU);
                _.Move(executed_1.PRODVG_AGENCIADOR, PRODVG_AGENCIADOR);
                _.Move(executed_1.VIND_AGENCIADOR, VIND_AGENCIADOR);
                _.Move(executed_1.PRODVG_TEM_SAF, PRODVG_TEM_SAF);
                _.Move(executed_1.VIND_TEM_SAF, VIND_TEM_SAF);
                _.Move(executed_1.PRODVG_TEM_CDG, PRODVG_TEM_CDG);
                _.Move(executed_1.VIND_TEM_CDG, VIND_TEM_CDG);
                _.Move(executed_1.PRODVG_CODRELAT, PRODVG_CODRELAT);
                _.Move(executed_1.VIND_CODRELAT, VIND_CODRELAT);
                _.Move(executed_1.PRODVG_COBERADIC_PREMIO, PRODVG_COBERADIC_PREMIO);
                _.Move(executed_1.PRODVG_CUSTOCAP_TOTAL, PRODVG_CUSTOCAP_TOTAL);
                _.Move(executed_1.PRODVG_DESCONTO_ADESAO, PRODVG_DESCONTO_ADESAO);
                _.Move(executed_1.PRODVG_COD_PRODUTO, PRODVG_COD_PRODUTO);
                _.Move(executed_1.PRODVG_RISCO, PRODVG_RISCO);
                _.Move(executed_1.PRODVG_SITPLANCEF, PRODVG_SITPLANCEF);
                _.Move(executed_1.PRODVG_ARQ_FDCAP, PRODVG_ARQ_FDCAP);
                _.Move(executed_1.WS_IND_ARQFDCAP, WS_IND_ARQFDCAP);
                _.Move(executed_1.PRODVG_COD_RUBRICA, PRODVG_COD_RUBRICA);
                _.Move(executed_1.WS_IND_RUBRICA, WS_IND_RUBRICA);
            }


        }

        [StopWatch]
        /*" M-0100-NEXT */
        private void M_0100_NEXT(bool isPerform = false)
        {
            /*" -2227- DISPLAY 'PROPVA-SITUACAO   = ' PROPVA-SITUACAO */
            _.Display($"PROPVA-SITUACAO   = {PROPVA_SITUACAO}");

            /*" -2229- DISPLAY 'PRODVG-ORIG-PRODU = ' PRODVG-ORIG-PRODU */
            _.Display($"PRODVG-ORIG-PRODU = {PRODVG_ORIG_PRODU}");

            /*" -2231- IF PROPVA-SITUACAO = '0' AND PRODVG-ORIG-PRODU = 'CEF DEB CC' */

            if (PROPVA_SITUACAO == "0" && PRODVG_ORIG_PRODU == "CEF DEB CC")
            {

                /*" -2232- CONTINUE */

                /*" -2233- ELSE */
            }
            else
            {


                /*" -2234- EVALUATE PROPVA-SITUACAO */
                switch (PROPVA_SITUACAO.Value.Trim())
                {

                    /*" -2235- WHEN '0' */
                    case "0":

                        /*" -2236- WHEN '1' */
                        break;
                    case "1":

                        /*" -2237- ADD 1 TO AC-DESPREZADOS */
                        WS_WORK_AREAS.AC_DESPREZADOS.Value = WS_WORK_AREAS.AC_DESPREZADOS + 1;

                        /*" -2238- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO */
                        _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

                        /*" -2239- MOVE 'UPDATE V0PROPOSTAVA 01' TO COMANDO */
                        _.Move("UPDATE V0PROPOSTAVA 01", WABEND.LOCALIZA_ABEND_2.COMANDO);

                        /*" -2243- PERFORM M_0100_NEXT_DB_UPDATE_1 */

                        M_0100_NEXT_DB_UPDATE_1();

                        /*" -2245- IF SQLCODE NOT EQUAL ZEROES */

                        if (DB.SQLCODE != 00)
                        {

                            /*" -2246- GO TO 9999-ERRO */

                            M_9999_ERRO_SECTION(); //GOTO
                            return;

                            /*" -2259- END-IF */
                        }


                        /*" -2260- WHEN '3' */
                        break;
                    case "3":

                        /*" -2261- IF PRODVG-ESTR-COBR EQUAL 'MULT' */

                        if (PRODVG_ESTR_COBR == "MULT")
                        {

                            /*" -2263- PERFORM R7770-00-PROPOSTAS-SIVPF-SIVPF THRU R7770-FIM */

                            R7770_00_PROPOSTAS_SIVPF_SIVPF_SECTION();
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R7770_FIM*/


                            /*" -2264- END-IF */
                        }


                        /*" -2265- END-EVALUATE */
                        break;
                }


                /*" -2267- END-IF */
            }


            /*" -2267- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


        }

        [StopWatch]
        /*" M-0100-NEXT-DB-UPDATE-1 */
        public void M_0100_NEXT_DB_UPDATE_1()
        {
            /*" -2243- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '1' WHERE NRCERTIF = :PROPVA-NRCERTIF END-EXEC */

            var m_0100_NEXT_DB_UPDATE_1_Update1 = new M_0100_NEXT_DB_UPDATE_1_Update1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_0100_NEXT_DB_UPDATE_1_Update1.Execute(m_0100_NEXT_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-2 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_2()
        {
            /*" -1294- EXEC SQL SELECT DATA_NASCIMENTO , CGCCPF INTO :CLIENT-DTNASC:CLIENT-DTNASC-I , :CLIENT-CGCCPF FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :PROPVA-CODCLIEN WITH UR END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENT_DTNASC, CLIENT_DTNASC);
                _.Move(executed_1.CLIENT_DTNASC_I, CLIENT_DTNASC_I);
                _.Move(executed_1.CLIENT_CGCCPF, CLIENT_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-3 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_3()
        {
            /*" -1425- EXEC SQL SELECT NUM_PROPOSTA INTO :PROPVA-NRPROPOS:PROPVA-INRPROPOS FROM SEGUROS.V0MOVIMENTO WHERE COD_FONTE = :PROPVA-FONTE AND NUM_PROPOSTA = :PROPVA-NRPROPOS END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1()
            {
                PROPVA_NRPROPOS = PROPVA_NRPROPOS.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPVA_NRPROPOS, PROPVA_NRPROPOS);
                _.Move(executed_1.PROPVA_INRPROPOS, PROPVA_INRPROPOS);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-UPDATE-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1()
        {
            /*" -1604- EXEC SQL UPDATE SEGUROS.OPCAO_PAG_VIDAZUL SET PERI_PAGAMENTO = :OPCAOP-PERIPGTO, DIA_DEBITO = :OPCAOP-DIA-DEB, OPCAO_PAGAMENTO = :OPCAOP-OPCAOPAG WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1 = new M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1()
            {
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                OPCAOP_OPCAOPAG = OPCAOP_OPCAOPAG.ToString(),
                OPCAOP_DIA_DEB = OPCAOP_DIA_DEB.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1.Execute(m_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0101-00-INSERT-VG-CRTCA-PROP-SECTION */
        private void M_0101_00_INSERT_VG_CRTCA_PROP_SECTION()
        {
            /*" -2275- MOVE '0101-00-INSERT-VG-CRTCA-PROP ' TO PARAGRAFO. */
            _.Move("0101-00-INSERT-VG-CRTCA-PROP ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2276- MOVE 'INSERT VG_CRITICA_PROPOSTA   ' TO COMANDO. */
            _.Move("INSERT VG_CRITICA_PROPOSTA   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2278- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2280- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -2281- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -2282- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -2283- MOVE PROPVA-NRCERTIF TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPVA_NRCERTIF, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -2284- MOVE ERRPROVI-COD-ERRO TO LK-VG001-COD-MSG-CRITICA */
            _.Move(ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -2285- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -2286- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -2287- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -2288- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -2289- MOVE 'VA0118B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0118B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -2290- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -2291- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -2292- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -2295- MOVE 'INSERCAO DE ERRO NA EMISSAO DA PROPOSTA' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("INSERCAO DE ERRO NA EMISSAO DA PROPOSTA", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -2297- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -2298- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -2299- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -2303- DISPLAY 'ERRO JAH GRAVADO 0101 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 0101 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -2304- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -2305- ELSE */
                }
                else
                {


                    /*" -2306- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2307- DISPLAY '* 0101 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 0101 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -2308- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2309- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -2310- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -2311- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -2312- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -2313- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -2314- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -2316- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2317- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -2318- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2319- END-IF */
                }


                /*" -2320- END-IF */
            }


            /*" -2334- . */

            /*" -2335- MOVE ERRPROVI-COD-ERRO TO WS-COD-MSG-CRITICA */
            _.Move(ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO, WS_COD_MSG_CRITICA);

            /*" -2337- PERFORM 8605-00-VERIFICA-TP-MENS */

            M_8605_00_VERIFICA_TP_MENS_SECTION();

            /*" -2338- IF PROPVA-ACATAMENTO EQUAL 'S' */

            if (PROPVA_ACATAMENTO == "S")
            {

                /*" -2339- IF WS-COD-TP-MSG-CRITICA NOT EQUAL 02 */

                if (WS_COD_TP_MSG_CRITICA != 02)
                {

                    /*" -2340- MOVE 03 TO WS-COD-TP-MSG-CRITICA */
                    _.Move(03, WS_COD_TP_MSG_CRITICA);

                    /*" -2341- END-IF */
                }


                /*" -2342- END-IF */
            }


            /*" -2342- . */

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-4 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_4()
        {
            /*" -1506- EXEC SQL SELECT OPCAOPAG, PERIPGTO, DIA_DEBITO, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, NUM_CARTAO_CREDITO INTO :OPCAOP-OPCAOPAG, :OPCAOP-PERIPGTO, :OPCAOP-DIA-DEB, :OPCAOP-AGECTADEB:INDAGE, :OPCAOP-OPRCTADEB:INDOPR, :OPCAOP-NUMCTADEB:INDNUM, :OPCAOP-DIGCTADEB:INDDIG, :OPCAOP-CARTAOCRED:INDCARTAO FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND DTTERVIG IN ( '1999-12-31' , '9999-12-31' ) END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCAOP_OPCAOPAG, OPCAOP_OPCAOPAG);
                _.Move(executed_1.OPCAOP_PERIPGTO, OPCAOP_PERIPGTO);
                _.Move(executed_1.OPCAOP_DIA_DEB, OPCAOP_DIA_DEB);
                _.Move(executed_1.OPCAOP_AGECTADEB, OPCAOP_AGECTADEB);
                _.Move(executed_1.INDAGE, INDAGE);
                _.Move(executed_1.OPCAOP_OPRCTADEB, OPCAOP_OPRCTADEB);
                _.Move(executed_1.INDOPR, INDOPR);
                _.Move(executed_1.OPCAOP_NUMCTADEB, OPCAOP_NUMCTADEB);
                _.Move(executed_1.INDNUM, INDNUM);
                _.Move(executed_1.OPCAOP_DIGCTADEB, OPCAOP_DIGCTADEB);
                _.Move(executed_1.INDDIG, INDDIG);
                _.Move(executed_1.OPCAOP_CARTAOCRED, OPCAOP_CARTAOCRED);
                _.Move(executed_1.INDCARTAO, INDCARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0101_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-5 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_5()
        {
            /*" -1527- EXEC SQL SELECT NRCERTIF INTO :V0PARC-NRCERTIF FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_NRCERTIF, V0PARC_NRCERTIF);
            }


        }

        [StopWatch]
        /*" M-0105-00-VERIF-DPS-ELETRONICA-SECTION */
        private void M_0105_00_VERIF_DPS_ELETRONICA_SECTION()
        {
            /*" -2356- MOVE '0105-00-VERIF-DPS-ELETRONICA ' TO PARAGRAFO. */
            _.Move("0105-00-VERIF-DPS-ELETRONICA ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2357- MOVE 'VERIFICAR DPS ELETRONICA     ' TO COMANDO. */
            _.Move("VERIFICAR DPS ELETRONICA     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2359- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2361- INITIALIZE LK-VG015-E-TRACE LK-VG015-E-IDE-SISTEMA LK-VG015-E-COD-USUARIO LK-VG015-E-NOM-PROGRAMA LK-VG015-E-TIPO-ACAO LK-VG015-E-NUM-CPF-CNPJ LK-VG015-E-COD-PRODUTO LK-VG015-E-VLR-IS LK-VG015-S-STA-PROPOSTA LK-VG015-S-SEQ-PRODUTO-DPS LK-VG015-S-VLR-ACUMULADO-IS LK-VG015-IND-ERRO LK-VG015-MENSAGEM LK-VG015-NOM-TABELA LK-VG015-SQLCODE LK-VG015-SQLERRMC LK-VG015-SQLSTATE. */
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

            /*" -2362- MOVE 'N' TO LK-VG015-E-TRACE */
            _.Move("N", SPVG015W.LK_VG015_E_TRACE);

            /*" -2363- MOVE 'VG' TO LK-VG015-E-IDE-SISTEMA */
            _.Move("VG", SPVG015W.LK_VG015_E_IDE_SISTEMA);

            /*" -2364- MOVE 'BATCH' TO LK-VG015-E-COD-USUARIO */
            _.Move("BATCH", SPVG015W.LK_VG015_E_COD_USUARIO);

            /*" -2365- MOVE 'VA0118B' TO LK-VG015-E-NOM-PROGRAMA */
            _.Move("VA0118B", SPVG015W.LK_VG015_E_NOM_PROGRAMA);

            /*" -2366- MOVE 01 TO LK-VG015-E-TIPO-ACAO */
            _.Move(01, SPVG015W.LK_VG015_E_TIPO_ACAO);

            /*" -2367- MOVE CLIENT-CGCCPF TO LK-VG015-E-NUM-CPF-CNPJ */
            _.Move(CLIENT_CGCCPF, SPVG015W.LK_VG015_E_NUM_CPF_CNPJ);

            /*" -2369- MOVE PROPVA-CODPRODU TO LK-VG015-E-COD-PRODUTO */
            _.Move(PROPVA_CODPRODU, SPVG015W.LK_VG015_E_COD_PRODUTO);

            /*" -2370- MOVE PROPVA-NRCERTIF TO WS-NUM-CERTIFICADO-RISCO */
            _.Move(PROPVA_NRCERTIF, WS_NUM_CERTIFICADO_RISCO);

            /*" -2371- MOVE ZEROS TO HISCOBPR-IMP-MORNATU */
            _.Move(0, HISCOBPR_IMP_MORNATU);

            /*" -2373- PERFORM 0284-00-SOMA-IS THRU 0284-99-SAIDA */

            M_0284_00_SOMA_IS_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0284_99_SAIDA*/


            /*" -2374- MOVE HISCOBPR-IMP-MORNATU TO LK-VG015-E-VLR-IS */
            _.Move(HISCOBPR_IMP_MORNATU, SPVG015W.LK_VG015_E_VLR_IS);

            /*" -2375- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -2377- MOVE 'SPBVG015' TO VG001-PROGRAMA */
            _.Move("SPBVG015", SPVG001V.VG001_PROGRAMA);

            /*" -2379- CALL VG001-PROGRAMA USING LK-VG015-E-TRACE LK-VG015-E-IDE-SISTEMA LK-VG015-E-COD-USUARIO LK-VG015-E-NOM-PROGRAMA LK-VG015-E-TIPO-ACAO LK-VG015-E-NUM-CPF-CNPJ LK-VG015-E-COD-PRODUTO LK-VG015-E-VLR-IS LK-VG015-S-STA-PROPOSTA LK-VG015-S-SEQ-PRODUTO-DPS LK-VG015-S-VLR-ACUMULADO-IS LK-VG015-IND-ERRO LK-VG015-MENSAGEM LK-VG015-NOM-TABELA LK-VG015-SQLCODE LK-VG015-SQLERRMC LK-VG015-SQLSTATE */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG015W);

            /*" -2380- IF LK-VG015-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG015W.LK_VG015_IND_ERRO != 00)
            {

                /*" -2381- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -2382- DISPLAY '* 0105 -  PROBLEMAS CALL SUBROTINA SPBVG015 *' */
                _.Display($"* 0105 -  PROBLEMAS CALL SUBROTINA SPBVG015 *");

                /*" -2383- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -2384- DISPLAY '* NUM-CERTIF..: ' PROPVA-NRCERTIF */
                _.Display($"* NUM-CERTIF..: {PROPVA_NRCERTIF}");

                /*" -2385- DISPLAY '* NUM-CPFCNPJ.: ' LK-VG015-E-NUM-CPF-CNPJ */
                _.Display($"* NUM-CPFCNPJ.: {SPVG015W.LK_VG015_E_NUM_CPF_CNPJ}");

                /*" -2386- DISPLAY '* COD-PRODUTO.: ' LK-VG015-E-COD-PRODUTO */
                _.Display($"* COD-PRODUTO.: {SPVG015W.LK_VG015_E_COD_PRODUTO}");

                /*" -2387- DISPLAY '* IND-ERRO....: ' LK-VG015-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG015W.LK_VG015_IND_ERRO}");

                /*" -2388- DISPLAY '* MSG-ERRO....: ' LK-VG015-MENSAGEM */
                _.Display($"* MSG-ERRO....: {SPVG015W.LK_VG015_MENSAGEM}");

                /*" -2389- DISPLAY '* NOM-TABELA..: ' LK-VG015-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG015W.LK_VG015_NOM_TABELA}");

                /*" -2390- DISPLAY '* SQLCODE.....: ' LK-VG015-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG015W.LK_VG015_SQLCODE}");

                /*" -2391- DISPLAY '* SQLERRMC....: ' LK-VG015-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG015W.LK_VG015_SQLERRMC}");

                /*" -2393- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -2394- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -2395- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2396- END-IF */
            }


            /*" -2396- . */

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-6 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_6()
        {
            /*" -1685- EXEC SQL SELECT COD_AGENCIA INTO :V0AGCEF-COD-AGCOBR FROM SEGUROS.V0AGENCIACEF WHERE COD_AGENCIA = :PROPVA-AGECOBR WITH UR END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1()
            {
                PROPVA_AGECOBR = PROPVA_AGECOBR.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0AGCEF_COD_AGCOBR, V0AGCEF_COD_AGCOBR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0105_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-7 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_7()
        {
            /*" -1727- EXEC SQL SELECT MIN(OCORHIST) INTO :V0COBER-MINOCOR FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :PROPVA-NRCERTIF WITH UR END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBER_MINOCOR, V0COBER_MINOCOR);
            }


        }

        [StopWatch]
        /*" M-0106-CONSULTA-ANALISE-DPS-SECTION */
        private void M_0106_CONSULTA_ANALISE_DPS_SECTION()
        {
            /*" -2408- MOVE '0106-CONSULTA-ANALISE-DPS ' TO PARAGRAFO. */
            _.Move("0106-CONSULTA-ANALISE-DPS ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2409- MOVE 'CONSULTA DPS ELETRONICA   ' TO COMANDO. */
            _.Move("CONSULTA DPS ELETRONICA   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2412- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2413- INITIALIZE LK-VG017-E-TRACE LK-VG017-E-IDE-SISTEMA LK-VG017-E-COD-USUARIO LK-VG017-E-NOM-PROGRAMA LK-VG017-E-TIPO-ACAO LK-VG017-E-NUM-PROTOCOLO LK-VG017-E-NUM-CPF-CNPJ LK-VG017-E-NUM-PROPOSTA LK-VG017-E-SEQ-PRODUTO-DPS LK-VG017-E-DTH-CONSULTA-DPS LK-VG017-E-IND-TP-PESSOA LK-VG017-E-IND-TP-SEGURADO LK-VG017-E-NUM-CERTIFICADO LK-VG017-E-VLR-IS LK-VG017-E-VLR-ACUMULADO-IS LK-VG017-E-STA-PROPOSTA-SIAS LK-VG017-E-STA-PROPOSTA-MOTOR LK-VG017-IND-ERRO LK-VG017-MENSAGEM LK-VG017-NOM-TABELA LK-VG017-SQLCODE LK-VG017-SQLERRMC LK-VG017-SQLSTATE */
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

            /*" -2416- . */

            /*" -2417- MOVE 'N' TO LK-VG017-E-TRACE */
            _.Move("N", SPVG017W.LK_VG017_E_TRACE);

            /*" -2418- MOVE 'VG' TO LK-VG017-E-IDE-SISTEMA */
            _.Move("VG", SPVG017W.LK_VG017_E_IDE_SISTEMA);

            /*" -2419- MOVE 'BATCH' TO LK-VG017-E-COD-USUARIO */
            _.Move("BATCH", SPVG017W.LK_VG017_E_COD_USUARIO);

            /*" -2420- MOVE 'VA0118B' TO LK-VG017-E-NOM-PROGRAMA */
            _.Move("VA0118B", SPVG017W.LK_VG017_E_NOM_PROGRAMA);

            /*" -2422- MOVE 1 TO LK-VG017-E-TIPO-ACAO */
            _.Move(1, SPVG017W.LK_VG017_E_TIPO_ACAO);

            /*" -2424- MOVE PROPVA-NRCERTIF TO LK-VG017-E-NUM-PROPOSTA */
            _.Move(PROPVA_NRCERTIF, SPVG017W.LK_VG017_E_NUM_PROPOSTA);

            /*" -2427- MOVE 'SPBVG017' TO WS-PROGRAMA */
            _.Move("SPBVG017", WS_PROGRAMA);

            /*" -2428- CALL WS-PROGRAMA USING LK-VG017-E-TRACE LK-VG017-E-IDE-SISTEMA LK-VG017-E-COD-USUARIO LK-VG017-E-NOM-PROGRAMA LK-VG017-E-TIPO-ACAO LK-VG017-E-NUM-PROTOCOLO LK-VG017-E-NUM-CPF-CNPJ LK-VG017-E-NUM-PROPOSTA LK-VG017-E-SEQ-PRODUTO-DPS LK-VG017-E-DTH-CONSULTA-DPS LK-VG017-E-IND-TP-PESSOA LK-VG017-E-IND-TP-SEGURADO LK-VG017-E-NUM-CERTIFICADO LK-VG017-E-VLR-IS LK-VG017-E-VLR-ACUMULADO-IS LK-VG017-E-STA-PROPOSTA-SIAS LK-VG017-E-STA-PROPOSTA-MOTOR LK-VG017-IND-ERRO LK-VG017-MENSAGEM LK-VG017-NOM-TABELA LK-VG017-SQLCODE LK-VG017-SQLERRMC LK-VG017-SQLSTATE */
            _.Call(WS_PROGRAMA, SPVG017W);

            /*" -2430- . */

            /*" -2431- IF LK-VG017-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG017W.LK_VG017_IND_ERRO != 00)
            {

                /*" -2432- MOVE LK-VG017-E-TIPO-ACAO TO WS-SMALLINT(01) */
                _.Move(SPVG017W.LK_VG017_E_TIPO_ACAO, WS_EDIT.WS_SMALLINT[01]);

                /*" -2433- MOVE LK-VG017-E-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(SPVG017W.LK_VG017_E_NUM_PROPOSTA, WS_EDIT.WS_BIGINT[01]);

                /*" -2434- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -2435- DISPLAY '* 0106 - PROBLEMAS CALL SUBROTINA SPBVG017   *' */
                _.Display($"* 0106 - PROBLEMAS CALL SUBROTINA SPBVG017   *");

                /*" -2436- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -2437- DISPLAY '* TRACE         = ' LK-VG017-E-TRACE */
                _.Display($"* TRACE         = {SPVG017W.LK_VG017_E_TRACE}");

                /*" -2438- DISPLAY '* IDE-SISTEMA   = ' LK-VG017-E-IDE-SISTEMA */
                _.Display($"* IDE-SISTEMA   = {SPVG017W.LK_VG017_E_IDE_SISTEMA}");

                /*" -2439- DISPLAY '* COD-USUARIO   = ' LK-VG017-E-COD-USUARIO */
                _.Display($"* COD-USUARIO   = {SPVG017W.LK_VG017_E_COD_USUARIO}");

                /*" -2440- DISPLAY '* NOM-PROGRAMA  = ' LK-VG017-E-NOM-PROGRAMA */
                _.Display($"* NOM-PROGRAMA  = {SPVG017W.LK_VG017_E_NOM_PROGRAMA}");

                /*" -2441- DISPLAY '* TIPO-ACAO     = ' WS-SMALLINT(01) */
                _.Display($"* TIPO-ACAO     = {WS_EDIT.WS_SMALLINT[1]}");

                /*" -2442- DISPLAY '* NUM-PROPOSTA  = ' WS-BIGINT(01) */
                _.Display($"* NUM-PROPOSTA  = {WS_EDIT.WS_BIGINT[1]}");

                /*" -2443- DISPLAY '* IND-ERRO      = ' LK-VG017-IND-ERRO */
                _.Display($"* IND-ERRO      = {SPVG017W.LK_VG017_IND_ERRO}");

                /*" -2444- DISPLAY '* MSG-ERRO      = ' LK-VG017-MENSAGEM */
                _.Display($"* MSG-ERRO      = {SPVG017W.LK_VG017_MENSAGEM}");

                /*" -2445- DISPLAY '* NOM-TABELA    = ' LK-VG017-NOM-TABELA */
                _.Display($"* NOM-TABELA    = {SPVG017W.LK_VG017_NOM_TABELA}");

                /*" -2446- DISPLAY '* SQLCODE       = ' LK-VG017-SQLCODE */
                _.Display($"* SQLCODE       = {SPVG017W.LK_VG017_SQLCODE}");

                /*" -2447- DISPLAY '* SQLERRMC      = ' LK-VG017-SQLERRMC */
                _.Display($"* SQLERRMC      = {SPVG017W.LK_VG017_SQLERRMC}");

                /*" -2449- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -2450- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -2451- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2453- END-IF */
            }


            /*" -2455- DISPLAY 'LK-VG017-E-STA-PROPOSTA-SIAS >> ' LK-VG017-E-STA-PROPOSTA-SIAS */
            _.Display($"LK-VG017-E-STA-PROPOSTA-SIAS >> {SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS}");

            /*" -2455- . */

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-UPDATE-2 */
        public void M_0100_PROCESSA_PROPOSTA_DB_UPDATE_2()
        {
            /*" -2202- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET CODPRODU = :PROPVA-CODPRODU, CODOPER = :PROPVA-CODOPER, DTMOVTO = :MDTMOVTO, DTPROXVEN = :PROPVA-DTPROXVEN, SITUACAO = :PROPVA-SITUACAO, CODSUBES = :PROPVA-CODSUBES, NRPARCE = 1, SIT_INTERFACE = '0' , TIMESTAMP = CURRENT TIMESTAMP WHERE CURRENT OF CPROPVA END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_UPDATE_2_Update1 = new M_0100_PROCESSA_PROPOSTA_DB_UPDATE_2_Update1(CPROPVA)
            {
                PROPVA_DTPROXVEN = PROPVA_DTPROXVEN.ToString(),
                PROPVA_CODPRODU = PROPVA_CODPRODU.ToString(),
                PROPVA_SITUACAO = PROPVA_SITUACAO.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_CODOPER = PROPVA_CODOPER.ToString(),
                MDTMOVTO = MDTMOVTO.ToString(),
            };

            M_0100_PROCESSA_PROPOSTA_DB_UPDATE_2_Update1.Execute(m_0100_PROCESSA_PROPOSTA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-8 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_8()
        {
            /*" -1774- EXEC SQL SELECT DTINIVIG, DTTERVIG, IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIO, PRMVG, PRMAP, IMPSEGCDC, VLCUSTCDG, VLCUSTCAP, IMPSEGAUXF, VLCUSTAUXF, QTTITCAP INTO :COBERP-DTINIVIG, :COBERP-DTTERVIG, :COBERP-IMPMORNATU, :COBERP-IMPMORACID, :COBERP-IMPINVPERM, :COBERP-IMPAMDS, :COBERP-IMPDH, :COBERP-IMPDIT, :COBERP-VLPREMIO, :COBERP-PRMVG, :COBERP-PRMAP, :COBERP-IMPSEGCDG, :COBERP-VLCUSTCDG, :COBERP-VLCUSTCAP, :COBERP-IMPSEGAUXF:COBERP-IIMPSEGAUXF, :COBERP-VLCUSTAUXF:COBERP-IVLCUSTAUXF, :COBERP-QTTITCAP:COBERP-IQTTITCAP FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND OCORHIST = :V0COBER-MINOCOR WITH UR END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                V0COBER_MINOCOR = V0COBER_MINOCOR.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBERP_DTINIVIG, COBERP_DTINIVIG);
                _.Move(executed_1.COBERP_DTTERVIG, COBERP_DTTERVIG);
                _.Move(executed_1.COBERP_IMPMORNATU, COBERP_IMPMORNATU);
                _.Move(executed_1.COBERP_IMPMORACID, COBERP_IMPMORACID);
                _.Move(executed_1.COBERP_IMPINVPERM, COBERP_IMPINVPERM);
                _.Move(executed_1.COBERP_IMPAMDS, COBERP_IMPAMDS);
                _.Move(executed_1.COBERP_IMPDH, COBERP_IMPDH);
                _.Move(executed_1.COBERP_IMPDIT, COBERP_IMPDIT);
                _.Move(executed_1.COBERP_VLPREMIO, COBERP_VLPREMIO);
                _.Move(executed_1.COBERP_PRMVG, COBERP_PRMVG);
                _.Move(executed_1.COBERP_PRMAP, COBERP_PRMAP);
                _.Move(executed_1.COBERP_IMPSEGCDG, COBERP_IMPSEGCDG);
                _.Move(executed_1.COBERP_VLCUSTCDG, COBERP_VLCUSTCDG);
                _.Move(executed_1.COBERP_VLCUSTCAP, COBERP_VLCUSTCAP);
                _.Move(executed_1.COBERP_IMPSEGAUXF, COBERP_IMPSEGAUXF);
                _.Move(executed_1.COBERP_IIMPSEGAUXF, COBERP_IIMPSEGAUXF);
                _.Move(executed_1.COBERP_VLCUSTAUXF, COBERP_VLCUSTAUXF);
                _.Move(executed_1.COBERP_IVLCUSTAUXF, COBERP_IVLCUSTAUXF);
                _.Move(executed_1.COBERP_QTTITCAP, COBERP_QTTITCAP);
                _.Move(executed_1.COBERP_IQTTITCAP, COBERP_IQTTITCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0106_99_EXIT*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-9 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_9()
        {
            /*" -1814- EXEC SQL SELECT DTINIVIG, IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIO, PRMVG, PRMAP, IMPSEGCDC, VLCUSTCDG, VLCUSTCAP, IMPSEGAUXF, VLCUSTAUXF, QTTITCAP INTO :COBERP-DTINIVIG, :COBERP-IMPMORNATU, :COBERP-IMPMORACID, :COBERP-IMPINVPERM, :COBERP-IMPAMDS, :COBERP-IMPDH, :COBERP-IMPDIT, :COBERP-VLPREMIO, :COBERP-PRMVG, :COBERP-PRMAP, :COBERP-IMPSEGCDG, :COBERP-VLCUSTCDG, :COBERP-VLCUSTCAP, :COBERP-IMPSEGAUXF:COBERP-IIMPSEGAUXF, :COBERP-VLCUSTAUXF:COBERP-IVLCUSTAUXF, :COBERP-QTTITCAP:COBERP-IQTTITCAP FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND OCORHIST = :PROPVA-OCORHIST WITH UR END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_9_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBERP_DTINIVIG, COBERP_DTINIVIG);
                _.Move(executed_1.COBERP_IMPMORNATU, COBERP_IMPMORNATU);
                _.Move(executed_1.COBERP_IMPMORACID, COBERP_IMPMORACID);
                _.Move(executed_1.COBERP_IMPINVPERM, COBERP_IMPINVPERM);
                _.Move(executed_1.COBERP_IMPAMDS, COBERP_IMPAMDS);
                _.Move(executed_1.COBERP_IMPDH, COBERP_IMPDH);
                _.Move(executed_1.COBERP_IMPDIT, COBERP_IMPDIT);
                _.Move(executed_1.COBERP_VLPREMIO, COBERP_VLPREMIO);
                _.Move(executed_1.COBERP_PRMVG, COBERP_PRMVG);
                _.Move(executed_1.COBERP_PRMAP, COBERP_PRMAP);
                _.Move(executed_1.COBERP_IMPSEGCDG, COBERP_IMPSEGCDG);
                _.Move(executed_1.COBERP_VLCUSTCDG, COBERP_VLCUSTCDG);
                _.Move(executed_1.COBERP_VLCUSTCAP, COBERP_VLCUSTCAP);
                _.Move(executed_1.COBERP_IMPSEGAUXF, COBERP_IMPSEGAUXF);
                _.Move(executed_1.COBERP_IIMPSEGAUXF, COBERP_IIMPSEGAUXF);
                _.Move(executed_1.COBERP_VLCUSTAUXF, COBERP_VLCUSTAUXF);
                _.Move(executed_1.COBERP_IVLCUSTAUXF, COBERP_IVLCUSTAUXF);
                _.Move(executed_1.COBERP_QTTITCAP, COBERP_QTTITCAP);
                _.Move(executed_1.COBERP_IQTTITCAP, COBERP_IQTTITCAP);
            }


        }

        [StopWatch]
        /*" M-0107-GRAVAR-ANALISE-DPS-SECTION */
        private void M_0107_GRAVAR_ANALISE_DPS_SECTION()
        {
            /*" -2468- MOVE '0107-GRAVAR-ANALISE-DPS ' TO PARAGRAFO. */
            _.Move("0107-GRAVAR-ANALISE-DPS ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2469- MOVE 'GRAVAR ANALISE DE DPS ELETRONICA' TO COMANDO. */
            _.Move("GRAVAR ANALISE DE DPS ELETRONICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2472- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2473- MOVE 'N' TO LK-VG017-E-TRACE */
            _.Move("N", SPVG017W.LK_VG017_E_TRACE);

            /*" -2474- MOVE 'VG' TO LK-VG017-E-IDE-SISTEMA */
            _.Move("VG", SPVG017W.LK_VG017_E_IDE_SISTEMA);

            /*" -2475- MOVE 'BATCH' TO LK-VG017-E-COD-USUARIO */
            _.Move("BATCH", SPVG017W.LK_VG017_E_COD_USUARIO);

            /*" -2476- MOVE 'VA0118B' TO LK-VG017-E-NOM-PROGRAMA */
            _.Move("VA0118B", SPVG017W.LK_VG017_E_NOM_PROGRAMA);

            /*" -2478- MOVE 2 TO LK-VG017-E-TIPO-ACAO */
            _.Move(2, SPVG017W.LK_VG017_E_TIPO_ACAO);

            /*" -2479- MOVE SPACES TO LK-VG017-E-DTH-CONSULTA-DPS */
            _.Move("", SPVG017W.LK_VG017_E_DTH_CONSULTA_DPS);

            /*" -2480- MOVE WS-STA-PROPOSTA-SIAS TO LK-VG017-E-STA-PROPOSTA-SIAS */
            _.Move(WS_STA_PROPOSTA_SIAS, SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS);

            /*" -2482- MOVE SPACES TO LK-VG017-E-STA-PROPOSTA-MOTOR */
            _.Move("", SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR);

            /*" -2485- MOVE 'SPBVG017' TO WS-PROGRAMA */
            _.Move("SPBVG017", WS_PROGRAMA);

            /*" -2486- CALL WS-PROGRAMA USING LK-VG017-E-TRACE LK-VG017-E-IDE-SISTEMA LK-VG017-E-COD-USUARIO LK-VG017-E-NOM-PROGRAMA LK-VG017-E-TIPO-ACAO LK-VG017-E-NUM-PROTOCOLO LK-VG017-E-NUM-CPF-CNPJ LK-VG017-E-NUM-PROPOSTA LK-VG017-E-SEQ-PRODUTO-DPS LK-VG017-E-DTH-CONSULTA-DPS LK-VG017-E-IND-TP-PESSOA LK-VG017-E-IND-TP-SEGURADO LK-VG017-E-NUM-CERTIFICADO LK-VG017-E-VLR-IS LK-VG017-E-VLR-ACUMULADO-IS LK-VG017-E-STA-PROPOSTA-SIAS LK-VG017-E-STA-PROPOSTA-MOTOR LK-VG017-IND-ERRO LK-VG017-MENSAGEM LK-VG017-NOM-TABELA LK-VG017-SQLCODE LK-VG017-SQLERRMC LK-VG017-SQLSTATE */
            _.Call(WS_PROGRAMA, SPVG017W);

            /*" -2488- . */

            /*" -2489- IF LK-VG017-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG017W.LK_VG017_IND_ERRO != 00)
            {

                /*" -2490- MOVE LK-VG017-E-TIPO-ACAO TO WS-SMALLINT(01) */
                _.Move(SPVG017W.LK_VG017_E_TIPO_ACAO, WS_EDIT.WS_SMALLINT[01]);

                /*" -2491- MOVE LK-VG017-E-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(SPVG017W.LK_VG017_E_NUM_PROPOSTA, WS_EDIT.WS_BIGINT[01]);

                /*" -2492- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -2493- DISPLAY '* 0106 - PROBLEMAS CALL SUBROTINA SPBVG017   *' */
                _.Display($"* 0106 - PROBLEMAS CALL SUBROTINA SPBVG017   *");

                /*" -2494- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -2495- DISPLAY '* TRACE         = ' LK-VG017-E-TRACE */
                _.Display($"* TRACE         = {SPVG017W.LK_VG017_E_TRACE}");

                /*" -2496- DISPLAY '* IDE-SISTEMA   = ' LK-VG017-E-IDE-SISTEMA */
                _.Display($"* IDE-SISTEMA   = {SPVG017W.LK_VG017_E_IDE_SISTEMA}");

                /*" -2497- DISPLAY '* COD-USUARIO   = ' LK-VG017-E-COD-USUARIO */
                _.Display($"* COD-USUARIO   = {SPVG017W.LK_VG017_E_COD_USUARIO}");

                /*" -2498- DISPLAY '* NOM-PROGRAMA  = ' LK-VG017-E-NOM-PROGRAMA */
                _.Display($"* NOM-PROGRAMA  = {SPVG017W.LK_VG017_E_NOM_PROGRAMA}");

                /*" -2499- DISPLAY '* TIPO-ACAO     = ' WS-SMALLINT(01) */
                _.Display($"* TIPO-ACAO     = {WS_EDIT.WS_SMALLINT[1]}");

                /*" -2500- DISPLAY '* NUM-PROPOSTA  = ' WS-BIGINT(01) */
                _.Display($"* NUM-PROPOSTA  = {WS_EDIT.WS_BIGINT[1]}");

                /*" -2501- DISPLAY '* IND-ERRO      = ' LK-VG017-IND-ERRO */
                _.Display($"* IND-ERRO      = {SPVG017W.LK_VG017_IND_ERRO}");

                /*" -2502- DISPLAY '* MSG-ERRO      = ' LK-VG017-MENSAGEM */
                _.Display($"* MSG-ERRO      = {SPVG017W.LK_VG017_MENSAGEM}");

                /*" -2503- DISPLAY '* NOM-TABELA    = ' LK-VG017-NOM-TABELA */
                _.Display($"* NOM-TABELA    = {SPVG017W.LK_VG017_NOM_TABELA}");

                /*" -2504- DISPLAY '* SQLCODE       = ' LK-VG017-SQLCODE */
                _.Display($"* SQLCODE       = {SPVG017W.LK_VG017_SQLCODE}");

                /*" -2505- DISPLAY '* SQLERRMC      = ' LK-VG017-SQLERRMC */
                _.Display($"* SQLERRMC      = {SPVG017W.LK_VG017_SQLERRMC}");

                /*" -2507- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -2508- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -2509- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2511- END-IF */
            }


            /*" -2511- . */

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-10 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_10()
        {
            /*" -1882- EXEC SQL SELECT VLPRMTOT INTO :V0HCOB-VLPRMTOT FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = :V0COBER-MINOCOR END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                V0COBER_MINOCOR = V0COBER_MINOCOR.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_VLPRMTOT, V0HCOB_VLPRMTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0107_99_EXIT*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-11 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_11()
        {
            /*" -1900- EXEC SQL SELECT PRMVG + PRMAP INTO :V0HCOB-VLPRMTOT FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_11_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_VLPRMTOT, V0HCOB_VLPRMTOT);
            }


        }

        [StopWatch]
        /*" M-0108-00-ANALISA-STATUS-DPS-SECTION */
        private void M_0108_00_ANALISA_STATUS_DPS_SECTION()
        {
            /*" -2542- MOVE '0108-00-ANALISA-STATUS-DPS ' TO PARAGRAFO. */
            _.Move("0108-00-ANALISA-STATUS-DPS ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2543- MOVE 'REALIZA ANALISE DE DPS ELETRONICA' TO COMANDO. */
            _.Move("REALIZA ANALISE DE DPS ELETRONICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2545- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2547- PERFORM 0106-CONSULTA-ANALISE-DPS */

            M_0106_CONSULTA_ANALISE_DPS_SECTION();

            /*" -2549- EVALUATE LK-VG017-E-STA-PROPOSTA-SIAS */
            switch (SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS.Value)
            {

                /*" -2550- WHEN 0 */
                case 0:

                    /*" -2551- PERFORM 0105-00-VERIF-DPS-ELETRONICA */

                    M_0105_00_VERIF_DPS_ELETRONICA_SECTION();

                    /*" -2553- PERFORM 0109-MOVE-AREA-PRIMEIRO-DPS */

                    M_0109_MOVE_AREA_PRIMEIRO_DPS_SECTION();

                    /*" -2555- IF LK-VG015-S-STA-PROPOSTA EQUAL 'S' */

                    if (SPVG015W.LK_VG015_S_STA_PROPOSTA == "S")
                    {

                        /*" -2556- MOVE 1 TO WS-STA-PROPOSTA-SIAS */
                        _.Move(1, WS_STA_PROPOSTA_SIAS);

                        /*" -2558- PERFORM 0107-GRAVAR-ANALISE-DPS */

                        M_0107_GRAVAR_ANALISE_DPS_SECTION();

                        /*" -2560- MOVE 'S' TO WS-ERRO-DPS-ELETR */
                        _.Move("S", WS_ERRO_DPS_ELETR);

                        /*" -2561- MOVE 008 TO ERRPROVI-COD-ERRO */
                        _.Move(008, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                        /*" -2564- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                        M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                        /*" -2567- ELSE */
                    }
                    else
                    {


                        /*" -2568- MOVE 2 TO WS-STA-PROPOSTA-SIAS */
                        _.Move(2, WS_STA_PROPOSTA_SIAS);

                        /*" -2569- PERFORM 0107-GRAVAR-ANALISE-DPS */

                        M_0107_GRAVAR_ANALISE_DPS_SECTION();

                        /*" -2570- MOVE 'N' TO WS-ERRO-DPS-ELETR */
                        _.Move("N", WS_ERRO_DPS_ELETR);

                        /*" -2572- END-IF */
                    }


                    /*" -2574- WHEN 1 */
                    break;
                case 1:

                    /*" -2575- MOVE 008 TO WS-COD-ERRO-DPS */
                    _.Move(008, WS_COD_ERRO_DPS);

                    /*" -2577- PERFORM 0115-00-CONS-ERRO-DPS-FECHADO */

                    M_0115_00_CONS_ERRO_DPS_FECHADO_SECTION();

                    /*" -2578- IF WS-STA-CRITICA EQUAL ' ' */

                    if (WS_STA_CRITICA == " ")
                    {

                        /*" -2580- MOVE 'S' TO WS-ERRO-DPS-ELETR */
                        _.Move("S", WS_ERRO_DPS_ELETR);

                        /*" -2581- MOVE 008 TO ERRPROVI-COD-ERRO */
                        _.Move(008, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                        /*" -2582- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                        M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                        /*" -2584- END-IF */
                    }


                    /*" -2586- WHEN 2 */
                    break;
                case 2:

                    /*" -2588- MOVE 'N' TO WS-ERRO-DPS-ELETR */
                    _.Move("N", WS_ERRO_DPS_ELETR);

                    /*" -2590- WHEN 3 */
                    break;
                case 3:

                    /*" -2591- MOVE 008 TO WS-COD-ERRO-DPS */
                    _.Move(008, WS_COD_ERRO_DPS);

                    /*" -2593- PERFORM 0115-00-CONS-ERRO-DPS-FECHADO */

                    M_0115_00_CONS_ERRO_DPS_FECHADO_SECTION();

                    /*" -2594- IF WS-STA-CRITICA EQUAL ' ' */

                    if (WS_STA_CRITICA == " ")
                    {

                        /*" -2596- MOVE 'S' TO WS-ERRO-DPS-ELETR */
                        _.Move("S", WS_ERRO_DPS_ELETR);

                        /*" -2597- MOVE 008 TO ERRPROVI-COD-ERRO */
                        _.Move(008, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                        /*" -2598- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                        M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                        /*" -2600- END-IF */
                    }


                    /*" -2602- WHEN 4 */
                    break;
                case 4:

                    /*" -2603- MOVE 008 TO WS-COD-ERRO-DPS */
                    _.Move(008, WS_COD_ERRO_DPS);

                    /*" -2605- PERFORM 0115-00-CONS-ERRO-DPS-FECHADO */

                    M_0115_00_CONS_ERRO_DPS_FECHADO_SECTION();

                    /*" -2606- IF WS-STA-CRITICA EQUAL ' ' */

                    if (WS_STA_CRITICA == " ")
                    {

                        /*" -2608- MOVE 'S' TO WS-ERRO-DPS-ELETR */
                        _.Move("S", WS_ERRO_DPS_ELETR);

                        /*" -2609- MOVE 008 TO ERRPROVI-COD-ERRO */
                        _.Move(008, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                        /*" -2610- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                        M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                        /*" -2613- END-IF */
                    }


                    /*" -2615- WHEN 5 */
                    break;
                case 5:

                    /*" -2616- MOVE 'N' TO WS-ERRO-DPS-ELETR */
                    _.Move("N", WS_ERRO_DPS_ELETR);

                    /*" -2618- PERFORM 0111-FECHAR-MSG-ERRO-DPS */

                    M_0111_FECHAR_MSG_ERRO_DPS_SECTION();

                    /*" -2619- MOVE 009 TO WS-COD-ERRO-DPS */
                    _.Move(009, WS_COD_ERRO_DPS);

                    /*" -2621- PERFORM 0115-00-CONS-ERRO-DPS-FECHADO */

                    M_0115_00_CONS_ERRO_DPS_FECHADO_SECTION();

                    /*" -2622- IF SQLCODE EQUAL +100 */

                    if (DB.SQLCODE == +100)
                    {

                        /*" -2623- MOVE 009 TO ERRPROVI-COD-ERRO */
                        _.Move(009, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                        /*" -2624- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                        M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                        /*" -2626- END-IF */
                    }


                    /*" -2629- WHEN 6 */
                    break;
                case 6:

                    /*" -2630- MOVE 010 TO WS-COD-ERRO-DPS */
                    _.Move(010, WS_COD_ERRO_DPS);

                    /*" -2632- PERFORM 0115-00-CONS-ERRO-DPS-FECHADO */

                    M_0115_00_CONS_ERRO_DPS_FECHADO_SECTION();

                    /*" -2633- IF WS-STA-CRITICA EQUAL ' ' */

                    if (WS_STA_CRITICA == " ")
                    {

                        /*" -2634- MOVE 'S' TO WS-ERRO-DPS-ELETR */
                        _.Move("S", WS_ERRO_DPS_ELETR);

                        /*" -2635- MOVE 010 TO ERRPROVI-COD-ERRO */
                        _.Move(010, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                        /*" -2636- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                        M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                        /*" -2638- END-IF */
                    }


                    /*" -2640- WHEN 7 */
                    break;
                case 7:

                    /*" -2641- MOVE 011 TO WS-COD-ERRO-DPS */
                    _.Move(011, WS_COD_ERRO_DPS);

                    /*" -2643- PERFORM 0115-00-CONS-ERRO-DPS-FECHADO */

                    M_0115_00_CONS_ERRO_DPS_FECHADO_SECTION();

                    /*" -2644- IF WS-STA-CRITICA EQUAL ' ' */

                    if (WS_STA_CRITICA == " ")
                    {

                        /*" -2645- MOVE 'S' TO WS-ERRO-DPS-ELETR */
                        _.Move("S", WS_ERRO_DPS_ELETR);

                        /*" -2646- MOVE 011 TO ERRPROVI-COD-ERRO */
                        _.Move(011, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                        /*" -2647- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                        M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                        /*" -2649- END-IF */
                    }


                    /*" -2651- WHEN 9 */
                    break;
                case 9:

                    /*" -2652- MOVE 011 TO WS-COD-ERRO-DPS */
                    _.Move(011, WS_COD_ERRO_DPS);

                    /*" -2654- PERFORM 0115-00-CONS-ERRO-DPS-FECHADO */

                    M_0115_00_CONS_ERRO_DPS_FECHADO_SECTION();

                    /*" -2655- IF WS-STA-CRITICA EQUAL ' ' */

                    if (WS_STA_CRITICA == " ")
                    {

                        /*" -2656- MOVE 'S' TO WS-ERRO-DPS-ELETR */
                        _.Move("S", WS_ERRO_DPS_ELETR);

                        /*" -2657- MOVE 011 TO ERRPROVI-COD-ERRO */
                        _.Move(011, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                        /*" -2658- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                        M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                        /*" -2664- END-IF */
                    }


                    /*" -2666- WHEN OTHER */
                    break;
                default:

                    /*" -2669- DISPLAY '* 0108-ERRO: STATUS DPS DESCONHECIDO : ' LK-VG017-E-STA-PROPOSTA-SIAS */
                    _.Display($"* 0108-ERRO: STATUS DPS DESCONHECIDO : {SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS}");

                    /*" -2670- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -2671- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2672- END-EVALUATE */
                    break;
            }


            /*" -2672- . */

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-12 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_12()
        {
            /*" -2118- EXEC SQL SELECT NUM_APOLICE, CODSUBES INTO :RELATO-NUM-APOLICE, :RELATO-CODSUBES FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = 'A5' AND NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND COD_OPERACAO = 6 WITH UR END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_12_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_12_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_12_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_12_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATO_NUM_APOLICE, RELATO_NUM_APOLICE);
                _.Move(executed_1.RELATO_CODSUBES, RELATO_CODSUBES);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0108_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-13 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_13()
        {
            /*" -2141- EXEC SQL SELECT NUM_APOLICE, CODSUBES INTO :RELATO-NUM-APOLICE, :RELATO-CODSUBES FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = 'A4' AND NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND COD_OPERACAO = 5 WITH UR END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_13_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_13_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_13_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_13_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATO_NUM_APOLICE, RELATO_NUM_APOLICE);
                _.Move(executed_1.RELATO_CODSUBES, RELATO_CODSUBES);
            }


        }

        [StopWatch]
        /*" M-0109-MOVE-AREA-PRIMEIRO-DPS-SECTION */
        private void M_0109_MOVE_AREA_PRIMEIRO_DPS_SECTION()
        {
            /*" -2681- MOVE '0109-MOVE-AREA-PRIMEIRO-DPS' TO PARAGRAFO. */
            _.Move("0109-MOVE-AREA-PRIMEIRO-DPS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2682- MOVE 'MOVE AREA PARA GRAVACAO DO 1O DPS' TO COMANDO. */
            _.Move("AREA PARA GRAVACAO DO 1O DPS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2685- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2686- INITIALIZE LK-VG017-E-TRACE LK-VG017-E-IDE-SISTEMA LK-VG017-E-COD-USUARIO LK-VG017-E-NOM-PROGRAMA LK-VG017-E-TIPO-ACAO LK-VG017-E-NUM-PROTOCOLO LK-VG017-E-NUM-CPF-CNPJ LK-VG017-E-NUM-PROPOSTA LK-VG017-E-SEQ-PRODUTO-DPS LK-VG017-E-DTH-CONSULTA-DPS LK-VG017-E-IND-TP-PESSOA LK-VG017-E-IND-TP-SEGURADO LK-VG017-E-NUM-CERTIFICADO LK-VG017-E-VLR-IS LK-VG017-E-VLR-ACUMULADO-IS LK-VG017-E-STA-PROPOSTA-SIAS LK-VG017-E-STA-PROPOSTA-MOTOR LK-VG017-IND-ERRO LK-VG017-MENSAGEM LK-VG017-NOM-TABELA LK-VG017-SQLCODE LK-VG017-SQLERRMC LK-VG017-SQLSTATE */
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

            /*" -2689- . */

            /*" -2690- MOVE CLIENT-CGCCPF TO LK-VG017-E-NUM-CPF-CNPJ */
            _.Move(CLIENT_CGCCPF, SPVG017W.LK_VG017_E_NUM_CPF_CNPJ);

            /*" -2691- MOVE ZEROS TO LK-VG017-E-NUM-PROTOCOLO */
            _.Move(0, SPVG017W.LK_VG017_E_NUM_PROTOCOLO);

            /*" -2692- MOVE PROPVA-NRCERTIF TO LK-VG017-E-NUM-PROPOSTA */
            _.Move(PROPVA_NRCERTIF, SPVG017W.LK_VG017_E_NUM_PROPOSTA);

            /*" -2694- MOVE LK-VG015-S-SEQ-PRODUTO-DPS TO LK-VG017-E-SEQ-PRODUTO-DPS */
            _.Move(SPVG015W.LK_VG015_S_SEQ_PRODUTO_DPS, SPVG017W.LK_VG017_E_SEQ_PRODUTO_DPS);

            /*" -2695- MOVE SPACES TO LK-VG017-E-DTH-CONSULTA-DPS */
            _.Move("", SPVG017W.LK_VG017_E_DTH_CONSULTA_DPS);

            /*" -2696- MOVE 'F' TO LK-VG017-E-IND-TP-PESSOA */
            _.Move("F", SPVG017W.LK_VG017_E_IND_TP_PESSOA);

            /*" -2697- MOVE 'S' TO LK-VG017-E-IND-TP-SEGURADO */
            _.Move("S", SPVG017W.LK_VG017_E_IND_TP_SEGURADO);

            /*" -2698- MOVE PROPVA-NRCERTIF TO LK-VG017-E-NUM-CERTIFICADO */
            _.Move(PROPVA_NRCERTIF, SPVG017W.LK_VG017_E_NUM_CERTIFICADO);

            /*" -2700- MOVE LK-VG015-E-VLR-IS TO LK-VG017-E-VLR-IS */
            _.Move(SPVG015W.LK_VG015_E_VLR_IS, SPVG017W.LK_VG017_E_VLR_IS);

            /*" -2703- MOVE LK-VG015-S-VLR-ACUMULADO-IS TO LK-VG017-E-VLR-ACUMULADO-IS */
            _.Move(SPVG015W.LK_VG015_S_VLR_ACUMULADO_IS, SPVG017W.LK_VG017_E_VLR_ACUMULADO_IS);

            /*" -2704- MOVE WS-STA-PROPOSTA-SIAS TO LK-VG017-E-STA-PROPOSTA-SIAS */
            _.Move(WS_STA_PROPOSTA_SIAS, SPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS);

            /*" -2705- MOVE SPACES TO LK-VG017-E-STA-PROPOSTA-MOTOR */
            _.Move("", SPVG017W.LK_VG017_E_STA_PROPOSTA_MOTOR);

            /*" -2705- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0109_99_EXIT*/

        [StopWatch]
        /*" M-0110-FETCH-SECTION */
        private void M_0110_FETCH_SECTION()
        {
            /*" -2717- MOVE '0110-FETCH' TO PARAGRAFO */
            _.Move("0110-FETCH", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2718- MOVE 'FETCH CPROPVA' TO COMANDO */
            _.Move("FETCH CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2720- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2762- PERFORM M_0110_FETCH_DB_FETCH_1 */

            M_0110_FETCH_DB_FETCH_1();

            /*" -2765- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2766- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2767- MOVE 1 TO WS-EOF */
                    _.Move(1, WS_WORK_AREAS.WS_EOF);

                    /*" -2768- MOVE 'CLOSE CPROPVA' TO COMANDO */
                    _.Move("CLOSE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -2768- PERFORM M_0110_FETCH_DB_CLOSE_1 */

                    M_0110_FETCH_DB_CLOSE_1();

                    /*" -2770- GO TO 0110-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/ //GOTO
                    return;

                    /*" -2771- ELSE */
                }
                else
                {


                    /*" -2772- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2773- END-IF */
                }


                /*" -2775- END-IF */
            }


            /*" -2776- IF VIND-ORIGEM LESS +0 */

            if (VIND_ORIGEM < +0)
            {

                /*" -2778- MOVE ZEROS TO PROPVA-ORIGEM-PROPOSTA */
                _.Move(0, PROPVA_ORIGEM_PROPOSTA);

                /*" -2815- END-IF. */
            }


            /*" -2816- MOVE PROPVA-NRCERTIF TO W-NUM-PROPOSTA. */
            _.Move(PROPVA_NRCERTIF, WS_WORK_AREAS.W_NUM_PROPOSTA);

            /*" -2818- MOVE PROPVA-DTPROXVEN TO PROPVA-DTPROXVEN-S. */
            _.Move(PROPVA_DTPROXVEN, PROPVA_DTPROXVEN_S);

            /*" -2819- MOVE PROPVA-NUM-APOLICE TO WS-NUM-APOLICE. */
            _.Move(PROPVA_NUM_APOLICE, WS_WORK_AREAS.WS_CHAVE.WS_NUM_APOLICE);

            /*" -2821- MOVE PROPVA-CODSUBES TO WS-CODSUBES. */
            _.Move(PROPVA_CODSUBES, WS_WORK_AREAS.WS_CHAVE.WS_CODSUBES);

            /*" -2822- IF PROPVA-CODOPER EQUAL ZEROS */

            if (PROPVA_CODOPER == 00)
            {

                /*" -2823- MOVE 101 TO PROPVA-CODOPER */
                _.Move(101, PROPVA_CODOPER);

                /*" -2825- END-IF */
            }


            /*" -2826- IF VIND-FAIXA-RENDA LESS +0 */

            if (VIND_FAIXA_RENDA < +0)
            {

                /*" -2827- MOVE '0' TO PROPVA-FAIXA-RENDA-IND */
                _.Move("0", PROPVA_FAIXA_RENDA_IND);

                /*" -2829- END-IF */
            }


            /*" -2831- PERFORM 1500-SELECT-PRODUTOSVG THRU 1500-FIM. */

            M_1500_SELECT_PRODUTOSVG_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/


            /*" -2832- IF PRODVG-RAMO EQUAL 77 */

            if (PRODVG_RAMO == 77)
            {

                /*" -2833- GO TO 0110-FETCH */
                new Task(() => M_0110_FETCH_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -2835- END-IF. */
            }


            /*" -2838- IF PRODVG-ORIG-PRODU = 'PAREN' OR 'CEF DEB CC' AND PROPVA-SITUACAO = '0' AND PROPVA-DTPROXVEN = '9999-12-31' */

            if (PRODVG_ORIG_PRODU.In("PAREN", "CEF DEB CC") && PROPVA_SITUACAO == "0" && PROPVA_DTPROXVEN == "9999-12-31")
            {

                /*" -2844- MOVE '7' TO PROPVA-SITUACAO. */
                _.Move("7", PROPVA_SITUACAO);
            }


            /*" -2845- IF PROPVA-SITUACAO = '7' */

            if (PROPVA_SITUACAO == "7")
            {

                /*" -2846- MOVE 0 TO WS-COUNT */
                _.Move(0, WS_WORK_AREAS.WS_COUNT);

                /*" -2847- MOVE PROPVA-DATA TO WHOST-PROXIMA-DATA */
                _.Move(PROPVA_DATA, WHOST_PROXIMA_DATA);

                /*" -2849- PERFORM 0120-00-CALCULA-POSTAGEM THRU 0120-99-SAIDA UNTIL WS-COUNT EQUAL 2 */

                while (!(WS_WORK_AREAS.WS_COUNT == 2))
                {

                    M_0120_00_CALCULA_POSTAGEM_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0120_99_SAIDA*/

                }

                /*" -2851- GO TO 0110-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/ //GOTO
                return;
            }


            /*" -2853- IF PROPVA-SITUACAO = '0' AND PRODVG-ORIG-PRODU = 'CEF DEB CC' */

            if (PROPVA_SITUACAO == "0" && PRODVG_ORIG_PRODU == "CEF DEB CC")
            {

                /*" -2855- GO TO 0110-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/ //GOTO
                return;
            }


            /*" -2857- MOVE 0 TO WS-COUNT. */
            _.Move(0, WS_WORK_AREAS.WS_COUNT);

            /*" -2859- MOVE PROPVA-DATA TO WHOST-PROXIMA-DATA */
            _.Move(PROPVA_DATA, WHOST_PROXIMA_DATA);

            /*" -2860- PERFORM 0120-00-CALCULA-POSTAGEM THRU 0120-99-SAIDA UNTIL WS-COUNT EQUAL 2. */

            while (!(WS_WORK_AREAS.WS_COUNT == 2))
            {

                M_0120_00_CALCULA_POSTAGEM_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0120_99_SAIDA*/

            }

        }

        [StopWatch]
        /*" M-0110-FETCH-DB-FETCH-1 */
        public void M_0110_FETCH_DB_FETCH_1()
        {
            /*" -2762- EXEC SQL FETCH CPROPVA INTO :PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-NRCERTIF, :PROPVA-CODPRODU, :PROPVA-CODCLIEN, :PROPVA-OCOREND, :PROPVA-FONTE, :PROPVA-AGECOBR, :PROPVA-OPCAO-COBER, :PROPVA-DTQITBCO, :PROPVA-DTINICDG, :PROPVA-DTINISAF, :PROPVA-DTPROXVEN, :PROPVA-DTMINVEN, :PROPVA-NRMATRVEN, :PROPVA-CODOPER, :PROPVA-DTMOVTO, :PROPVA-SITUACAO, :PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-OCORHIST, :PROPVA-NRPARCEL, :PROPVA-SIT-INTERF, :PROPVA-TIMESTAMP, :PROPVA-IDADE, :PROPVA-SEXO, :PROPVA-EST-CIV, :PROPVA-COD-CRM:VIND-COD-CRM, :PROPVA-NRMATRFUN:PROPVA-INRMATRFUN, :PROPVA-DTADMIS:PROPVA-IDTADMIS, :PROPVA-NRPROPOS:PROPVA-INRPROPOS, :PROPVA-CODCCT:PROPVA-ICODCCT, :PROPVA-CODUSU, :PROPVA-DTVENCTO, :PROPVA-FAIXA-RENDA-IND:VIND-FAIXA-RENDA, :PROPVA-DATA, :PROPVA-DPS-TITULAR, :PROPVA-ORIGEM-PROPOSTA:VIND-ORIGEM, :PROPVA-SITUACAO-ORIGINAL, :PROPVA-ACATAMENTO END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.PROPVA_NUM_APOLICE, PROPVA_NUM_APOLICE);
                _.Move(CPROPVA.PROPVA_CODSUBES, PROPVA_CODSUBES);
                _.Move(CPROPVA.PROPVA_NRCERTIF, PROPVA_NRCERTIF);
                _.Move(CPROPVA.PROPVA_CODPRODU, PROPVA_CODPRODU);
                _.Move(CPROPVA.PROPVA_CODCLIEN, PROPVA_CODCLIEN);
                _.Move(CPROPVA.PROPVA_OCOREND, PROPVA_OCOREND);
                _.Move(CPROPVA.PROPVA_FONTE, PROPVA_FONTE);
                _.Move(CPROPVA.PROPVA_AGECOBR, PROPVA_AGECOBR);
                _.Move(CPROPVA.PROPVA_OPCAO_COBER, PROPVA_OPCAO_COBER);
                _.Move(CPROPVA.PROPVA_DTQITBCO, PROPVA_DTQITBCO);
                _.Move(CPROPVA.PROPVA_DTINICDG, PROPVA_DTINICDG);
                _.Move(CPROPVA.PROPVA_DTINISAF, PROPVA_DTINISAF);
                _.Move(CPROPVA.PROPVA_DTPROXVEN, PROPVA_DTPROXVEN);
                _.Move(CPROPVA.PROPVA_DTMINVEN, PROPVA_DTMINVEN);
                _.Move(CPROPVA.PROPVA_NRMATRVEN, PROPVA_NRMATRVEN);
                _.Move(CPROPVA.PROPVA_CODOPER, PROPVA_CODOPER);
                _.Move(CPROPVA.PROPVA_DTMOVTO, PROPVA_DTMOVTO);
                _.Move(CPROPVA.PROPVA_SITUACAO, PROPVA_SITUACAO);
                _.Move(CPROPVA.PROPVA_NUM_APOLICE, PROPVA_NUM_APOLICE);
                _.Move(CPROPVA.PROPVA_CODSUBES, PROPVA_CODSUBES);
                _.Move(CPROPVA.PROPVA_OCORHIST, PROPVA_OCORHIST);
                _.Move(CPROPVA.PROPVA_NRPARCEL, PROPVA_NRPARCEL);
                _.Move(CPROPVA.PROPVA_SIT_INTERF, PROPVA_SIT_INTERF);
                _.Move(CPROPVA.PROPVA_TIMESTAMP, PROPVA_TIMESTAMP);
                _.Move(CPROPVA.PROPVA_IDADE, PROPVA_IDADE);
                _.Move(CPROPVA.PROPVA_SEXO, PROPVA_SEXO);
                _.Move(CPROPVA.PROPVA_EST_CIV, PROPVA_EST_CIV);
                _.Move(CPROPVA.PROPVA_COD_CRM, PROPVA_COD_CRM);
                _.Move(CPROPVA.VIND_COD_CRM, VIND_COD_CRM);
                _.Move(CPROPVA.PROPVA_NRMATRFUN, PROPVA_NRMATRFUN);
                _.Move(CPROPVA.PROPVA_INRMATRFUN, PROPVA_INRMATRFUN);
                _.Move(CPROPVA.PROPVA_DTADMIS, PROPVA_DTADMIS);
                _.Move(CPROPVA.PROPVA_IDTADMIS, PROPVA_IDTADMIS);
                _.Move(CPROPVA.PROPVA_NRPROPOS, PROPVA_NRPROPOS);
                _.Move(CPROPVA.PROPVA_INRPROPOS, PROPVA_INRPROPOS);
                _.Move(CPROPVA.PROPVA_CODCCT, PROPVA_CODCCT);
                _.Move(CPROPVA.PROPVA_ICODCCT, PROPVA_ICODCCT);
                _.Move(CPROPVA.PROPVA_CODUSU, PROPVA_CODUSU);
                _.Move(CPROPVA.PROPVA_DTVENCTO, PROPVA_DTVENCTO);
                _.Move(CPROPVA.PROPVA_FAIXA_RENDA_IND, PROPVA_FAIXA_RENDA_IND);
                _.Move(CPROPVA.VIND_FAIXA_RENDA, VIND_FAIXA_RENDA);
                _.Move(CPROPVA.PROPVA_DATA, PROPVA_DATA);
                _.Move(CPROPVA.PROPVA_DPS_TITULAR, PROPVA_DPS_TITULAR);
                _.Move(CPROPVA.PROPVA_ORIGEM_PROPOSTA, PROPVA_ORIGEM_PROPOSTA);
                _.Move(CPROPVA.VIND_ORIGEM, VIND_ORIGEM);
                _.Move(CPROPVA.PROPVA_SITUACAO_ORIGINAL, PROPVA_SITUACAO_ORIGINAL);
                _.Move(CPROPVA.PROPVA_ACATAMENTO, PROPVA_ACATAMENTO);
            }

        }

        [StopWatch]
        /*" M-0110-FETCH-DB-CLOSE-1 */
        public void M_0110_FETCH_DB_CLOSE_1()
        {
            /*" -2768- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/

        [StopWatch]
        /*" M-0111-FECHAR-MSG-ERRO-DPS-SECTION */
        private void M_0111_FECHAR_MSG_ERRO_DPS_SECTION()
        {
            /*" -2878- MOVE '0111-FECHAR-MSG-ERRO-DPS' TO PARAGRAFO */
            _.Move("0111-FECHAR-MSG-ERRO-DPS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2880- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2882- INITIALIZE WS-FIM-ERRO-DPS */
            _.Initialize(
                WS_FIM_ERRO_DPS
            );

            /*" -2884- PERFORM 0112-00-ABRIR-CSR-ERRO-DPS */

            M_0112_00_ABRIR_CSR_ERRO_DPS_SECTION();

            /*" -2888- PERFORM 0113-00-FETCH-CSR-ERRO-DPS THRU 0113-99-SAIDA UNTIL WS-FIM-ERRO-DPS EQUAL 'SIM' */

            while (!(WS_FIM_ERRO_DPS == "SIM"))
            {

                M_0113_00_FETCH_CSR_ERRO_DPS_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0113_99_SAIDA*/

            }

            /*" -2888- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0111_FIM*/

        [StopWatch]
        /*" M-0112-00-ABRIR-CSR-ERRO-DPS-SECTION */
        private void M_0112_00_ABRIR_CSR_ERRO_DPS_SECTION()
        {
            /*" -2895- MOVE '0112-00-ABRIR-CSR-ERRO-DPS    ' TO PARAGRAFO */
            _.Move("0112-00-ABRIR-CSR-ERRO-DPS    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2896- MOVE 'OPEN DO CURSOR CSR-ERRO-DPS   ' TO COMANDO */
            _.Move("OPEN DO CURSOR CSR-ERRO-DPS   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2898- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2898- PERFORM M_0112_00_ABRIR_CSR_ERRO_DPS_DB_OPEN_1 */

            M_0112_00_ABRIR_CSR_ERRO_DPS_DB_OPEN_1();

            /*" -2901- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2902- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -2902- PERFORM M_0112_00_ABRIR_CSR_ERRO_DPS_DB_CLOSE_1 */

                M_0112_00_ABRIR_CSR_ERRO_DPS_DB_CLOSE_1();

                /*" -2904- DISPLAY 'VA0118B - PROBLEMAS NO OPEN DO CSR_ERRO_DPS' */
                _.Display($"VA0118B - PROBLEMAS NO OPEN DO CSR_ERRO_DPS");

                /*" -2905- DISPLAY ' COD_PRODUTO_SIVPF.. ' PROPOFID-COD-PRODUTO-SIVPF */
                _.Display($" COD_PRODUTO_SIVPF.. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF}");

                /*" -2906- DISPLAY ' CPF_CLIENTE........ ' CLIENT-CGCCPF */
                _.Display($" CPF_CLIENTE........ {CLIENT_CGCCPF}");

                /*" -2907- DISPLAY ' NUM-CERTIFICADO.... ' PROPVA-NRCERTIF */
                _.Display($" NUM-CERTIFICADO.... {PROPVA_NRCERTIF}");

                /*" -2908- DISPLAY ' SQLCODE............ ' WS-SQLCODE */
                _.Display($" SQLCODE............ {WS_SQLCODE}");

                /*" -2909- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2910- END-IF */
            }


            /*" -2910- . */

        }

        [StopWatch]
        /*" M-0112-00-ABRIR-CSR-ERRO-DPS-DB-OPEN-1 */
        public void M_0112_00_ABRIR_CSR_ERRO_DPS_DB_OPEN_1()
        {
            /*" -2898- EXEC SQL OPEN CSR_ERRO_DPS END-EXEC */

            CSR_ERRO_DPS.Open();

        }

        [StopWatch]
        /*" M-0112-00-ABRIR-CSR-ERRO-DPS-DB-CLOSE-1 */
        public void M_0112_00_ABRIR_CSR_ERRO_DPS_DB_CLOSE_1()
        {
            /*" -2902- EXEC SQL CLOSE CSR_ERRO_DPS END-EXEC */

            CSR_ERRO_DPS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0112_99_SAIDA*/

        [StopWatch]
        /*" M-0113-00-FETCH-CSR-ERRO-DPS-SECTION */
        private void M_0113_00_FETCH_CSR_ERRO_DPS_SECTION()
        {
            /*" -2919- MOVE '0113-00-FETCH-CSR-ERRO-DPS    ' TO PARAGRAFO */
            _.Move("0113-00-FETCH-CSR-ERRO-DPS    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2920- MOVE 'FETCH DO CURSOR CSR-ERRO-DPS  ' TO COMANDO */
            _.Move("FETCH DO CURSOR CSR-ERRO-DPS  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2922- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2927- PERFORM M_0113_00_FETCH_CSR_ERRO_DPS_DB_FETCH_1 */

            M_0113_00_FETCH_CSR_ERRO_DPS_DB_FETCH_1();

            /*" -2930-  EVALUATE SQLCODE  */

            /*" -2931-  WHEN ZEROS  */

            /*" -2931- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2932- PERFORM 0114-00-FECHAR-ERRO-DPS */

                M_0114_00_FECHAR_ERRO_DPS_SECTION();

                /*" -2933-  WHEN +100  */

                /*" -2933- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -2933- PERFORM M_0113_00_FETCH_CSR_ERRO_DPS_DB_CLOSE_1 */

                M_0113_00_FETCH_CSR_ERRO_DPS_DB_CLOSE_1();

                /*" -2935- MOVE 'SIM' TO WS-FIM-ERRO-DPS */
                _.Move("SIM", WS_FIM_ERRO_DPS);

                /*" -2936-  WHEN OTHER  */

                /*" -2936- ELSE */
            }
            else
            {


                /*" -2937- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -2937- PERFORM M_0113_00_FETCH_CSR_ERRO_DPS_DB_CLOSE_2 */

                M_0113_00_FETCH_CSR_ERRO_DPS_DB_CLOSE_2();

                /*" -2939- MOVE 'FIM' TO WS-FIM-ERRO-DPS */
                _.Move("FIM", WS_FIM_ERRO_DPS);

                /*" -2940- DISPLAY 'VA0118B - PROBLEMAS FETCH DO CURSOR CSR_ERRO_DPS' */
                _.Display($"VA0118B - PROBLEMAS FETCH DO CURSOR CSR_ERRO_DPS");

                /*" -2941- DISPLAY ' SEQ-CRITICA........ ' VG103-SEQ-CRITICA */
                _.Display($" SEQ-CRITICA........ {VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA}");

                /*" -2942- DISPLAY ' COD-MSG-CRITICA.... ' VG103-COD-MSG-CRITICA */
                _.Display($" COD-MSG-CRITICA.... {VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA}");

                /*" -2943- DISPLAY ' NUM-CERTIFICADO.... ' VG103-NUM-CERTIFICADO */
                _.Display($" NUM-CERTIFICADO.... {VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO}");

                /*" -2945- DISPLAY ' SQLCODE............ ' WS-SQLCODE */
                _.Display($" SQLCODE............ {WS_SQLCODE}");

                /*" -2946- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2947-  END-EVALUATE  */

                /*" -2947- END-IF */
            }


            /*" -2947- . */

        }

        [StopWatch]
        /*" M-0113-00-FETCH-CSR-ERRO-DPS-DB-FETCH-1 */
        public void M_0113_00_FETCH_CSR_ERRO_DPS_DB_FETCH_1()
        {
            /*" -2927- EXEC SQL FETCH CSR_ERRO_DPS INTO :VG103-NUM-CERTIFICADO, :VG103-SEQ-CRITICA, :VG103-COD-MSG-CRITICA END-EXEC */

            if (CSR_ERRO_DPS.Fetch())
            {
                _.Move(CSR_ERRO_DPS.VG103_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO);
                _.Move(CSR_ERRO_DPS.VG103_SEQ_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA);
                _.Move(CSR_ERRO_DPS.VG103_COD_MSG_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA);
            }

        }

        [StopWatch]
        /*" M-0113-00-FETCH-CSR-ERRO-DPS-DB-CLOSE-1 */
        public void M_0113_00_FETCH_CSR_ERRO_DPS_DB_CLOSE_1()
        {
            /*" -2933- EXEC SQL CLOSE CSR_ERRO_DPS END-EXEC */

            CSR_ERRO_DPS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0113_99_SAIDA*/

        [StopWatch]
        /*" M-0113-00-FETCH-CSR-ERRO-DPS-DB-CLOSE-2 */
        public void M_0113_00_FETCH_CSR_ERRO_DPS_DB_CLOSE_2()
        {
            /*" -2937- EXEC SQL CLOSE CSR_ERRO_DPS END-EXEC */

            CSR_ERRO_DPS.Close();

        }

        [StopWatch]
        /*" M-0114-00-FECHAR-ERRO-DPS-SECTION */
        private void M_0114_00_FECHAR_ERRO_DPS_SECTION()
        {
            /*" -2957- MOVE '0114-00-FECHAR-ERRO-DPS' TO PARAGRAFO */
            _.Move("0114-00-FECHAR-ERRO-DPS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2961- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2963- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -2964- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -2965- MOVE 03 TO LK-VG001-TIPO-ACAO */
            _.Move(03, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -2966- MOVE PROPVA-NRCERTIF TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPVA_NRCERTIF, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -2967- MOVE VG103-SEQ-CRITICA TO LK-VG001-SEQ-CRITICA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -2968- MOVE VG103-COD-MSG-CRITICA TO LK-VG001-COD-MSG-CRITICA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -2969- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -2970- MOVE CLIENT-CGCCPF TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(CLIENT_CGCCPF, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -2971- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -2972- MOVE 'VA0118B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0118B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -2973- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -2974- MOVE 'B' TO LK-VG001-STA-CRITICA */
            _.Move("B", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -2975- MOVE 45 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(45, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -2978- MOVE 'ERRO TRATADO APOS RECEBIMENTO DE DPS ACEITO' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("ERRO TRATADO APOS RECEBIMENTO DE DPS ACEITO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -2980- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -2981- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -2982- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -2983- DISPLAY '* 0114 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                _.Display($"* 0114 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                /*" -2984- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -2985- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -2986- DISPLAY '* SEQ-CRITICA.: ' LK-VG001-SEQ-CRITICA */
                _.Display($"* SEQ-CRITICA.: {SPVG001W.LK_VG001_SEQ_CRITICA}");

                /*" -2987- DISPLAY '* MSG-CRITICA.: ' LK-VG001-COD-MSG-CRITICA */
                _.Display($"* MSG-CRITICA.: {SPVG001W.LK_VG001_COD_MSG_CRITICA}");

                /*" -2988- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -2989- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -2990- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -2991- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -2992- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -2994- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -2995- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -2996- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2997- END-IF */
            }


            /*" -2997- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0114_99_SAIDA*/

        [StopWatch]
        /*" M-0115-00-CONS-ERRO-DPS-FECHADO-SECTION */
        private void M_0115_00_CONS_ERRO_DPS_FECHADO_SECTION()
        {
            /*" -3008- MOVE '0115-00-CONS-ERRO-DPS-FECHADO' TO PARAGRAFO */
            _.Move("0115-00-CONS-ERRO-DPS-FECHADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3010- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3012- MOVE SPACES TO WS-STA-CRITICA */
            _.Move("", WS_STA_CRITICA);

            /*" -3021- PERFORM M_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1 */

            M_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1();

            /*" -3024- IF SQLCODE NOT EQUAL ZEROS AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -3025- DISPLAY '8595-00 - PROBLEMAS NO SELECT(VG_CRITICA_PROP)' */
                _.Display($"8595-00 - PROBLEMAS NO SELECT(VG_CRITICA_PROP)");

                /*" -3026- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3028- END-IF */
            }


            /*" -3029- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -3030- MOVE ' ' TO WS-STA-CRITICA */
                _.Move(" ", WS_STA_CRITICA);

                /*" -3031- ELSE */
            }
            else
            {


                /*" -3033- IF WS-STA-CRITICA NOT EQUAL '0' AND '1' AND '2' AND '4' AND '5' AND '8' */

                if (!WS_STA_CRITICA.In("0", "1", "2", "4", "5", "8"))
                {

                    /*" -3034- MOVE 'T' TO WS-STA-CRITICA */
                    _.Move("T", WS_STA_CRITICA);

                    /*" -3035- MOVE 'N' TO WS-ERRO-DPS-ELETR */
                    _.Move("N", WS_ERRO_DPS_ELETR);

                    /*" -3036- ELSE */
                }
                else
                {


                    /*" -3037- MOVE 'P' TO WS-STA-CRITICA */
                    _.Move("P", WS_STA_CRITICA);

                    /*" -3038- MOVE 'S' TO WS-ERRO-DPS-ELETR */
                    _.Move("S", WS_ERRO_DPS_ELETR);

                    /*" -3039- END-IF */
                }


                /*" -3040- END-IF */
            }


            /*" -3040- . */

        }

        [StopWatch]
        /*" M-0115-00-CONS-ERRO-DPS-FECHADO-DB-SELECT-1 */
        public void M_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1()
        {
            /*" -3021- EXEC SQL SELECT A.STA_CRITICA INTO :WS-STA-CRITICA FROM SEGUROS.VG_CRITICA_PROPOSTA A WHERE A.NUM_CERTIFICADO = :PROPVA-NRCERTIF AND A.COD_MSG_CRITICA = :WS-COD-ERRO-DPS ORDER BY A.DTH_CADASTRAMENTO DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var m_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1_Query1 = new M_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                WS_COD_ERRO_DPS = WS_COD_ERRO_DPS.ToString(),
            };

            var executed_1 = M_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1_Query1.Execute(m_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_STA_CRITICA, WS_STA_CRITICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0115_99_SAIDA*/

        [StopWatch]
        /*" M-0116-FECHAR-MSG-ERRO-ACAT-SECTION */
        private void M_0116_FECHAR_MSG_ERRO_ACAT_SECTION()
        {
            /*" -3052- MOVE '0116-FECHAR-MSG-ERRO-ACAT' TO PARAGRAFO */
            _.Move("0116-FECHAR-MSG-ERRO-ACAT", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3054- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3056- INITIALIZE WS-FIM-ERRO-ACAT */
            _.Initialize(
                WS_FIM_ERRO_ACAT
            );

            /*" -3058- PERFORM 0117-00-ABRIR-CSR-ERRO-ACAT */

            M_0117_00_ABRIR_CSR_ERRO_ACAT_SECTION();

            /*" -3062- PERFORM 0118-00-FETCH-CSR-ERRO-ACAT THRU 0118-99-SAIDA UNTIL WS-FIM-ERRO-ACAT EQUAL 'SIM' */

            while (!(WS_FIM_ERRO_ACAT == "SIM"))
            {

                M_0118_00_FETCH_CSR_ERRO_ACAT_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0118_99_SAIDA*/

            }

            /*" -3062- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0116_FIM*/

        [StopWatch]
        /*" M-0117-00-ABRIR-CSR-ERRO-ACAT-SECTION */
        private void M_0117_00_ABRIR_CSR_ERRO_ACAT_SECTION()
        {
            /*" -3069- MOVE '0117-00-ABRIR-CSR-ERRO-ACAT    ' TO PARAGRAFO */
            _.Move("0117-00-ABRIR-CSR-ERRO-ACAT    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3070- MOVE 'OPEN DO CURSOR CSR-ERRO-ACAT  ' TO COMANDO */
            _.Move("OPEN DO CURSOR CSR-ERRO-ACAT  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3072- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3072- PERFORM M_0117_00_ABRIR_CSR_ERRO_ACAT_DB_OPEN_1 */

            M_0117_00_ABRIR_CSR_ERRO_ACAT_DB_OPEN_1();

            /*" -3075- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3076- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -3076- PERFORM M_0117_00_ABRIR_CSR_ERRO_ACAT_DB_CLOSE_1 */

                M_0117_00_ABRIR_CSR_ERRO_ACAT_DB_CLOSE_1();

                /*" -3078- DISPLAY 'VA0118B - PROBLEMAS NO OPEN DO CSR_ERRO_ACAT' */
                _.Display($"VA0118B - PROBLEMAS NO OPEN DO CSR_ERRO_ACAT");

                /*" -3079- DISPLAY ' COD_PRODUTO_SIVPF.. ' PROPOFID-COD-PRODUTO-SIVPF */
                _.Display($" COD_PRODUTO_SIVPF.. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF}");

                /*" -3080- DISPLAY ' CPF_CLIENTE........ ' CLIENT-CGCCPF */
                _.Display($" CPF_CLIENTE........ {CLIENT_CGCCPF}");

                /*" -3081- DISPLAY ' NUM-CERTIFICADO.... ' PROPVA-NRCERTIF */
                _.Display($" NUM-CERTIFICADO.... {PROPVA_NRCERTIF}");

                /*" -3082- DISPLAY ' SQLCODE............ ' WS-SQLCODE */
                _.Display($" SQLCODE............ {WS_SQLCODE}");

                /*" -3083- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3084- END-IF */
            }


            /*" -3084- . */

        }

        [StopWatch]
        /*" M-0117-00-ABRIR-CSR-ERRO-ACAT-DB-OPEN-1 */
        public void M_0117_00_ABRIR_CSR_ERRO_ACAT_DB_OPEN_1()
        {
            /*" -3072- EXEC SQL OPEN CSR_ERRO_ACAT END-EXEC */

            CSR_ERRO_ACAT.Open();

        }

        [StopWatch]
        /*" M-0117-00-ABRIR-CSR-ERRO-ACAT-DB-CLOSE-1 */
        public void M_0117_00_ABRIR_CSR_ERRO_ACAT_DB_CLOSE_1()
        {
            /*" -3076- EXEC SQL CLOSE CSR_ERRO_ACAT END-EXEC */

            CSR_ERRO_ACAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0117_99_SAIDA*/

        [StopWatch]
        /*" M-0118-00-FETCH-CSR-ERRO-ACAT-SECTION */
        private void M_0118_00_FETCH_CSR_ERRO_ACAT_SECTION()
        {
            /*" -3093- MOVE '0118-00-FETCH-CSR-ERRO-ACAT   ' TO PARAGRAFO */
            _.Move("0118-00-FETCH-CSR-ERRO-ACAT   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3094- MOVE 'FETCH DO CURSOR CSR-ERRO-ACAT ' TO COMANDO */
            _.Move("FETCH DO CURSOR CSR-ERRO-ACAT ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3096- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3101- PERFORM M_0118_00_FETCH_CSR_ERRO_ACAT_DB_FETCH_1 */

            M_0118_00_FETCH_CSR_ERRO_ACAT_DB_FETCH_1();

            /*" -3104-  EVALUATE SQLCODE  */

            /*" -3105-  WHEN ZEROS  */

            /*" -3105- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3106- PERFORM 0119-00-FECHAR-ERRO-ACAT */

                M_0119_00_FECHAR_ERRO_ACAT_SECTION();

                /*" -3107-  WHEN +100  */

                /*" -3107- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -3107- PERFORM M_0118_00_FETCH_CSR_ERRO_ACAT_DB_CLOSE_1 */

                M_0118_00_FETCH_CSR_ERRO_ACAT_DB_CLOSE_1();

                /*" -3109- MOVE 'SIM' TO WS-FIM-ERRO-ACAT */
                _.Move("SIM", WS_FIM_ERRO_ACAT);

                /*" -3110-  WHEN OTHER  */

                /*" -3110- ELSE */
            }
            else
            {


                /*" -3111- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -3111- PERFORM M_0118_00_FETCH_CSR_ERRO_ACAT_DB_CLOSE_2 */

                M_0118_00_FETCH_CSR_ERRO_ACAT_DB_CLOSE_2();

                /*" -3113- MOVE 'FIM' TO WS-FIM-ERRO-ACAT */
                _.Move("FIM", WS_FIM_ERRO_ACAT);

                /*" -3114- DISPLAY 'VA0118B - PROBLEMAS FETCH CURSOR CSR_ERRO_ACAT' */
                _.Display($"VA0118B - PROBLEMAS FETCH CURSOR CSR_ERRO_ACAT");

                /*" -3115- DISPLAY ' SEQ-CRITICA........ ' VG103-SEQ-CRITICA */
                _.Display($" SEQ-CRITICA........ {VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA}");

                /*" -3116- DISPLAY ' COD-MSG-CRITICA.... ' VG103-COD-MSG-CRITICA */
                _.Display($" COD-MSG-CRITICA.... {VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA}");

                /*" -3117- DISPLAY ' NUM-CERTIFICADO.... ' VG103-NUM-CERTIFICADO */
                _.Display($" NUM-CERTIFICADO.... {VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO}");

                /*" -3119- DISPLAY ' SQLCODE............ ' WS-SQLCODE */
                _.Display($" SQLCODE............ {WS_SQLCODE}");

                /*" -3120- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3121-  END-EVALUATE  */

                /*" -3121- END-IF */
            }


            /*" -3121- . */

        }

        [StopWatch]
        /*" M-0118-00-FETCH-CSR-ERRO-ACAT-DB-FETCH-1 */
        public void M_0118_00_FETCH_CSR_ERRO_ACAT_DB_FETCH_1()
        {
            /*" -3101- EXEC SQL FETCH CSR_ERRO_ACAT INTO :VG103-NUM-CERTIFICADO, :VG103-SEQ-CRITICA, :VG103-COD-MSG-CRITICA END-EXEC */

            if (CSR_ERRO_ACAT.Fetch())
            {
                _.Move(CSR_ERRO_ACAT.VG103_NUM_CERTIFICADO, VG103.DCLVG_CRITICA_PROPOSTA.VG103_NUM_CERTIFICADO);
                _.Move(CSR_ERRO_ACAT.VG103_SEQ_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA);
                _.Move(CSR_ERRO_ACAT.VG103_COD_MSG_CRITICA, VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA);
            }

        }

        [StopWatch]
        /*" M-0118-00-FETCH-CSR-ERRO-ACAT-DB-CLOSE-1 */
        public void M_0118_00_FETCH_CSR_ERRO_ACAT_DB_CLOSE_1()
        {
            /*" -3107- EXEC SQL CLOSE CSR_ERRO_ACAT END-EXEC */

            CSR_ERRO_ACAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0118_99_SAIDA*/

        [StopWatch]
        /*" M-0118-00-FETCH-CSR-ERRO-ACAT-DB-CLOSE-2 */
        public void M_0118_00_FETCH_CSR_ERRO_ACAT_DB_CLOSE_2()
        {
            /*" -3111- EXEC SQL CLOSE CSR_ERRO_ACAT END-EXEC */

            CSR_ERRO_ACAT.Close();

        }

        [StopWatch]
        /*" M-0119-00-FECHAR-ERRO-ACAT-SECTION */
        private void M_0119_00_FECHAR_ERRO_ACAT_SECTION()
        {
            /*" -3131- MOVE '0119-00-FECHAR-ERRO-ACAT' TO PARAGRAFO */
            _.Move("0119-00-FECHAR-ERRO-ACAT", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3135- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3137- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -3138- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -3139- MOVE 03 TO LK-VG001-TIPO-ACAO */
            _.Move(03, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -3140- MOVE PROPVA-NRCERTIF TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPVA_NRCERTIF, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -3141- MOVE VG103-SEQ-CRITICA TO LK-VG001-SEQ-CRITICA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_SEQ_CRITICA, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -3142- MOVE VG103-COD-MSG-CRITICA TO LK-VG001-COD-MSG-CRITICA */
            _.Move(VG103.DCLVG_CRITICA_PROPOSTA.VG103_COD_MSG_CRITICA, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -3143- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -3144- MOVE CLIENT-CGCCPF TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(CLIENT_CGCCPF, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -3145- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -3146- MOVE 'VA0118B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0118B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -3147- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -3148- MOVE 'B' TO LK-VG001-STA-CRITICA */
            _.Move("B", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -3149- MOVE 45 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(45, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -3152- MOVE 'ERRO TRATADO APOS ACATAMENTO DO USUARIO ' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("ERRO TRATADO APOS ACATAMENTO DO USUARIO ", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -3154- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -3155- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -3156- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -3157- DISPLAY '* 0119 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                _.Display($"* 0119 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                /*" -3158- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -3159- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -3160- DISPLAY '* SEQ-CRITICA.: ' LK-VG001-SEQ-CRITICA */
                _.Display($"* SEQ-CRITICA.: {SPVG001W.LK_VG001_SEQ_CRITICA}");

                /*" -3161- DISPLAY '* MSG-CRITICA.: ' LK-VG001-COD-MSG-CRITICA */
                _.Display($"* MSG-CRITICA.: {SPVG001W.LK_VG001_COD_MSG_CRITICA}");

                /*" -3162- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -3163- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -3164- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -3165- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -3166- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -3168- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -3169- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -3170- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3171- END-IF */
            }


            /*" -3171- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0119_99_SAIDA*/

        [StopWatch]
        /*" M-0120-00-CALCULA-POSTAGEM-SECTION */
        private void M_0120_00_CALCULA_POSTAGEM_SECTION()
        {
            /*" -3180- MOVE '0120-00-CALCULA-POSTAGEM' TO PARAGRAFO */
            _.Move("0120-00-CALCULA-POSTAGEM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3182- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3184- PERFORM 0130-00-CALCULA-DIA-UTIL THRU 0130-99-SAIDA. */

            M_0130_00_CALCULA_DIA_UTIL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0130_99_SAIDA*/


            /*" -3188- IF CALENDAR-DIA-SEMANA EQUAL 'S' OR CALENDAR-DIA-SEMANA EQUAL 'D' OR CALENDAR-FERIADO EQUAL 'N' NEXT SENTENCE */

            if (CALENDAR_DIA_SEMANA == "S" || CALENDAR_DIA_SEMANA == "D" || CALENDAR_FERIADO == "N")
            {

                /*" -3189- ELSE */
            }
            else
            {


                /*" -3189- ADD 1 TO WS-COUNT. */
                WS_WORK_AREAS.WS_COUNT.Value = WS_WORK_AREAS.WS_COUNT + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0120_99_SAIDA*/

        [StopWatch]
        /*" M-0130-00-CALCULA-DIA-UTIL-SECTION */
        private void M_0130_00_CALCULA_DIA_UTIL_SECTION()
        {
            /*" -3197- MOVE '0130-00-CALCULA-DIA-UTIL' TO PARAGRAFO */
            _.Move("0130-00-CALCULA-DIA-UTIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3198- MOVE 'SELECT                  ' TO COMANDO. */
            _.Move("SELECT                  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3200- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3216- PERFORM M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1 */

            M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1();

            /*" -3219- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3220- DISPLAY 'VA0118B - PROBLEMAS SELECT CALENDARIO' */
                _.Display($"VA0118B - PROBLEMAS SELECT CALENDARIO");

                /*" -3220- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0130-00-CALCULA-DIA-UTIL-DB-SELECT-1 */
        public void M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1()
        {
            /*" -3216- EXEC SQL SELECT DATA_CALENDARIO, (DATA_CALENDARIO + 1 DAY), DIA_SEMANA, FERIADO INTO :CALENDAR-DATA-CALENDARIO, :WHOST-PROXIMA-DATA, :CALENDAR-DIA-SEMANA, :CALENDAR-FERIADO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO >= :WHOST-PROXIMA-DATA AND DATA_CALENDARIO <= :WHOST-PROXIMA-DATA WITH UR END-EXEC. */

            var m_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1 = new M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1()
            {
                WHOST_PROXIMA_DATA = WHOST_PROXIMA_DATA.ToString(),
            };

            var executed_1 = M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1.Execute(m_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR_DATA_CALENDARIO);
                _.Move(executed_1.WHOST_PROXIMA_DATA, WHOST_PROXIMA_DATA);
                _.Move(executed_1.CALENDAR_DIA_SEMANA, CALENDAR_DIA_SEMANA);
                _.Move(executed_1.CALENDAR_FERIADO, CALENDAR_FERIADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0130_99_SAIDA*/

        [StopWatch]
        /*" M-0200-SOLICITA-CERTIFICADO-SECTION */
        private void M_0200_SOLICITA_CERTIFICADO_SECTION()
        {
            /*" -3232- MOVE '0200-SOLICITA-CERTIFICADO' TO PARAGRAFO. */
            _.Move("0200-SOLICITA-CERTIFICADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3233- MOVE 'INSERT V0RELATORIOS' TO COMANDO. */
            _.Move("INSERT V0RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3236- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3279- PERFORM M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1 */

            M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1();

            /*" -3282- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3282- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0200-SOLICITA-CERTIFICADO-DB-INSERT-1 */
        public void M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1()
        {
            /*" -3279- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VA0118B' , CURRENT DATE, 'VA' , :RELATO-CODRELAT, 0, 0, CURRENT DATE, CURRENT DATE, CURRENT DATE, 0, 0, 0, 0, 0, 0, 0, 0, :PROPVA-NUM-APOLICE, 0, :RELATO-NRPARCEL, :PROPVA-NRCERTIF, 0, :PROPVA-CODSUBES, :RELATO-OPERACAO, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var m_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1 = new M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1()
            {
                RELATO_CODRELAT = RELATO_CODRELAT.ToString(),
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                RELATO_NRPARCEL = RELATO_NRPARCEL.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                RELATO_OPERACAO = RELATO_OPERACAO.ToString(),
            };

            M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1.Execute(m_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/

        [StopWatch]
        /*" M-0250-00-CALCULA-LIMITE-RISCO-SECTION */
        private void M_0250_00_CALCULA_LIMITE_RISCO_SECTION()
        {
            /*" -3290- MOVE '0250-00-CALCULA-LIMITE-RISCO  ' TO PARAGRAFO */
            _.Move("0250-00-CALCULA-LIMITE-RISCO  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3292- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3293- INITIALIZE WS-FIM-RISCO */
            _.Initialize(
                WS_FIM_RISCO
            );

            /*" -3294- SET WS-NAO-RESTITUIDO TO TRUE */
            WS_RESTITUICAO["WS_NAO_RESTITUIDO"] = true;

            /*" -3295- SET WS-NAO-PRODU-SIVPF TO TRUE */
            WS_PRODUTO_SIVPF["WS_NAO_PRODU_SIVPF"] = true;

            /*" -3297- SET WS-NAO-PROPOSTA TO TRUE */
            WS_PROPOSTA_FIDELIZ["WS_NAO_PROPOSTA"] = true;

            /*" -3299- MOVE COBERP-IMPMORNATU TO WS-AC-TOT-RISCO */
            _.Move(COBERP_IMPMORNATU, WS_AC_TOT_RISCO);

            /*" -3301- PERFORM 0255-00-ACESSA-PROPOSTA */

            M_0255_00_ACESSA_PROPOSTA_SECTION();

            /*" -3302- IF WS-SIM-PROPOSTA OR WS-SIM-PRODU-SIVPF */

            if (WS_PROPOSTA_FIDELIZ["WS_SIM_PROPOSTA"] || WS_PRODUTO_SIVPF["WS_SIM_PRODU_SIVPF"])
            {

                /*" -3304- PERFORM 0260-00-ABRIR-CSR-RISCO THRU 0260-99-SAIDA */

                M_0260_00_ABRIR_CSR_RISCO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0260_99_SAIDA*/


                /*" -3307- PERFORM 0270-00-FETCH-CSR-RISCO THRU 0270-99-SAIDA */

                M_0270_00_FETCH_CSR_RISCO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0270_99_SAIDA*/


                /*" -3311- PERFORM 0280-00-CALCULA-RISCO THRU 0280-99-SAIDA UNTIL WS-FIM-RISCO EQUAL 'SIM' */

                while (!(WS_FIM_RISCO == "SIM"))
                {

                    M_0280_00_CALCULA_RISCO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0280_99_SAIDA*/

                }

                /*" -3312-  EVALUATE PROPVA-CODPRODU  */

                /*" -3312-  WHEN 9351 */

                /*" -3312-  WHEN JVPRD9351 */

                /*" -3313-  WHEN 9352 */

                /*" -3313-  WHEN JVPRD9352 */

                /*" -3314-  WHEN 9353 */

                /*" -3314-  WHEN JVPRD9353 */

                /*" -3318- IF   PROPVA-CODPRODU EQUALS 9351 OR  JVPRD9351  OR  9352  OR  JVPRD9352  OR  9353  OR  JVPRD9353 */

                if (PROPVA_CODPRODU.In("9351", JVBKINCL.JV_PRODUTOS.JVPRD9351.ToString(), "9352", JVBKINCL.JV_PRODUTOS.JVPRD9352.ToString(), "9353", JVBKINCL.JV_PRODUTOS.JVPRD9353.ToString()))
                {

                    /*" -3318- PERFORM 0500-00-DEFINE-SIT-PROPOSTA THRU 0500-99-SAIDA */

                    M_0500_00_DEFINE_SIT_PROPOSTA_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0500_99_SAIDA*/


                    /*" -3318-  WHEN 9310 */

                    /*" -3318- IF   PROPVA-CODPRODU EQUALS  9310 */

                    if (PROPVA_CODPRODU == 9310)
                    {

                        /*" -3318-  WHEN JVPRD9310 */

                        /*" -3318- ELSE IF   PROPVA-CODPRODU EQUALS  JVPRD9310 */
                    }
                    else

                    if (PROPVA_CODPRODU == JVBKINCL.JV_PRODUTOS.JVPRD9310)
                    {

                        /*" -3322- PERFORM 0510-00-DEFINE-SIT-PROPOSTA THRU 0510-99-SAIDA */

                        M_0510_00_DEFINE_SIT_PROPOSTA_SECTION();
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0510_99_SAIDA*/


                        /*" -3324-  END-EVALUATE  */

                        /*" -3324- END-IF */
                    }


                    /*" -3326- END-IF */
                }


                /*" -3326- . */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0250_SAIDA*/

        [StopWatch]
        /*" M-0255-00-ACESSA-PROPOSTA-SECTION */
        private void M_0255_00_ACESSA_PROPOSTA_SECTION()
        {
            /*" -3334- MOVE '0255-00-ACESSA-PROPOSTA       ' TO PARAGRAFO */
            _.Move("0255-00-ACESSA-PROPOSTA       ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3335- MOVE 'SELECT PROPOSTA_FIDELIZ       ' TO COMANDO */
            _.Move("SELECT PROPOSTA_FIDELIZ       ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3337- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3353- PERFORM M_0255_00_ACESSA_PROPOSTA_DB_SELECT_1 */

            M_0255_00_ACESSA_PROPOSTA_DB_SELECT_1();

            /*" -3356-  EVALUATE SQLCODE  */

            /*" -3357-  WHEN ZEROS  */

            /*" -3357- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3358- SET WS-SIM-PROPOSTA TO TRUE */
                WS_PROPOSTA_FIDELIZ["WS_SIM_PROPOSTA"] = true;

                /*" -3360-  WHEN +100  */

                /*" -3360- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -3362- PERFORM 0256-RECUPERA-PRODUTO-SIVPF */

                M_0256_RECUPERA_PRODUTO_SIVPF_SECTION();

                /*" -3363-  WHEN OTHER  */

                /*" -3363- ELSE */
            }
            else
            {


                /*" -3364- DISPLAY 'VA0118B - PROBLEMAS NO SELECT PROPOSTA_FIDELIZ' */
                _.Display($"VA0118B - PROBLEMAS NO SELECT PROPOSTA_FIDELIZ");

                /*" -3366- DISPLAY ' NUM-CERTIFICADO.......   ' PROPVA-NRCERTIF */
                _.Display($" NUM-CERTIFICADO.......   {PROPVA_NRCERTIF}");

                /*" -3368- DISPLAY ' SQLCODE...............   ' SQLCODE */
                _.Display($" SQLCODE...............   {DB.SQLCODE}");

                /*" -3369- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3371-  END-EVALUATE  */

                /*" -3371- END-IF */
            }


            /*" -3371- . */

        }

        [StopWatch]
        /*" M-0255-00-ACESSA-PROPOSTA-DB-SELECT-1 */
        public void M_0255_00_ACESSA_PROPOSTA_DB_SELECT_1()
        {
            /*" -3353- EXEC SQL SELECT COD_PRODUTO_SIVPF , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , VAL_PAGO INTO :PROPOFID-COD-PRODUTO-SIVPF , :PROPOFID-AGECTADEB , :PROPOFID-OPRCTADEB , :PROPOFID-NUMCTADEB , :PROPOFID-DIGCTADEB , :PROPOFID-VAL-PAGO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPVA-NRCERTIF WITH UR END-EXEC */

            var m_0255_00_ACESSA_PROPOSTA_DB_SELECT_1_Query1 = new M_0255_00_ACESSA_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0255_00_ACESSA_PROPOSTA_DB_SELECT_1_Query1.Execute(m_0255_00_ACESSA_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PROPOFID_AGECTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB);
                _.Move(executed_1.PROPOFID_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);
                _.Move(executed_1.PROPOFID_NUMCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB);
                _.Move(executed_1.PROPOFID_DIGCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB);
                _.Move(executed_1.PROPOFID_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0255_SAIDA*/

        [StopWatch]
        /*" M-0256-RECUPERA-PRODUTO-SIVPF-SECTION */
        private void M_0256_RECUPERA_PRODUTO_SIVPF_SECTION()
        {
            /*" -3379- MOVE '0256-RECUPERA-PRODUTO-SIVPF   ' TO PARAGRAFO */
            _.Move("0256-RECUPERA-PRODUTO-SIVPF   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3380- MOVE 'SELECT PRODUTOS_SIVPF         ' TO COMANDO */
            _.Move("SELECT PRODUTOS_SIVPF         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3382- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3388- PERFORM M_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1 */

            M_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1();

            /*" -3391-  EVALUATE SQLCODE  */

            /*" -3392-  WHEN ZEROS  */

            /*" -3392- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3393- SET WS-SIM-PRODU-SIVPF TO TRUE */
                WS_PRODUTO_SIVPF["WS_SIM_PRODU_SIVPF"] = true;

                /*" -3395-  WHEN +100  */

                /*" -3395- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -3397- SET WS-NAO-PRODU-SIVPF TO TRUE */
                WS_PRODUTO_SIVPF["WS_NAO_PRODU_SIVPF"] = true;

                /*" -3398-  WHEN OTHER  */

                /*" -3398- ELSE */
            }
            else
            {


                /*" -3399- DISPLAY 'VA0118B - PROBLEMAS NO SELECT PROPOSTA_FIDELIZ' */
                _.Display($"VA0118B - PROBLEMAS NO SELECT PROPOSTA_FIDELIZ");

                /*" -3401- DISPLAY ' COD-PRODUTO...........   ' PROPVA-CODPRODU */
                _.Display($" COD-PRODUTO...........   {PROPVA_CODPRODU}");

                /*" -3403- DISPLAY ' SQLCODE...............   ' SQLCODE */
                _.Display($" SQLCODE...............   {DB.SQLCODE}");

                /*" -3404- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3406-  END-EVALUATE  */

                /*" -3406- END-IF */
            }


            /*" -3406- . */

        }

        [StopWatch]
        /*" M-0256-RECUPERA-PRODUTO-SIVPF-DB-SELECT-1 */
        public void M_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1()
        {
            /*" -3388- EXEC SQL SELECT COD_PRODUTO_SIVPF INTO :PROPOFID-COD-PRODUTO-SIVPF FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_PRODUTO = :PROPVA-CODPRODU WITH UR END-EXEC */

            var m_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1_Query1 = new M_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1_Query1()
            {
                PROPVA_CODPRODU = PROPVA_CODPRODU.ToString(),
            };

            var executed_1 = M_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1_Query1.Execute(m_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0256_SAIDA*/

        [StopWatch]
        /*" M-0260-00-ABRIR-CSR-RISCO-SECTION */
        private void M_0260_00_ABRIR_CSR_RISCO_SECTION()
        {
            /*" -3414- MOVE '0260-00-ABRIR-CSR-RISCO       ' TO PARAGRAFO */
            _.Move("0260-00-ABRIR-CSR-RISCO       ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3415- MOVE 'OPEN DO CURSOR CSR-RISCO      ' TO COMANDO */
            _.Move("OPEN DO CURSOR CSR-RISCO      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3417- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3417- PERFORM M_0260_00_ABRIR_CSR_RISCO_DB_OPEN_1 */

            M_0260_00_ABRIR_CSR_RISCO_DB_OPEN_1();

            /*" -3420- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3421- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -3421- PERFORM M_0260_00_ABRIR_CSR_RISCO_DB_CLOSE_1 */

                M_0260_00_ABRIR_CSR_RISCO_DB_CLOSE_1();

                /*" -3423- DISPLAY 'VA0118B - PROBLEMAS NO OPEN DO CSR-RISCO' */
                _.Display($"VA0118B - PROBLEMAS NO OPEN DO CSR-RISCO");

                /*" -3425- DISPLAY ' COD_PRODUTO_SIVPF.....   ' PROPOFID-COD-PRODUTO-SIVPF */
                _.Display($" COD_PRODUTO_SIVPF.....   {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF}");

                /*" -3427- DISPLAY ' CPF_CLIENTE...........   ' CLIENT-CGCCPF */
                _.Display($" CPF_CLIENTE...........   {CLIENT_CGCCPF}");

                /*" -3429- DISPLAY ' NUM-CERTIFICADO.......   ' PROPVA-NRCERTIF */
                _.Display($" NUM-CERTIFICADO.......   {PROPVA_NRCERTIF}");

                /*" -3431- DISPLAY ' SQLCODE...............   ' WS-SQLCODE */
                _.Display($" SQLCODE...............   {WS_SQLCODE}");

                /*" -3432- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3434- END-IF */
            }


            /*" -3434- . */

        }

        [StopWatch]
        /*" M-0260-00-ABRIR-CSR-RISCO-DB-OPEN-1 */
        public void M_0260_00_ABRIR_CSR_RISCO_DB_OPEN_1()
        {
            /*" -3417- EXEC SQL OPEN CSR_RISCO END-EXEC */

            CSR_RISCO.Open();

        }

        [StopWatch]
        /*" M-1120-DECLARE-V0RCAPCOMP-DB-DECLARE-1 */
        public void M_1120_DECLARE_V0RCAPCOMP_DB_DECLARE_1()
        {
            /*" -4608- EXEC SQL DECLARE V1RCAPCOMP CURSOR FOR SELECT FONTE , NRRCAP , NRRCAPCO , OPERACAO , DTMOVTO , HORAOPER , SITUACAO , BCOAVISO , AGEAVISO , NRAVISO , VLRCAP , DATARCAP , DTCADAST , SITCONTB FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO = '0' END-EXEC. */
            V1RCAPCOMP = new VA0118B_V1RCAPCOMP(true);
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
							AND NRRCAP = '{V0RCAP_NRRCAP}' 
							AND OPERACAO >= 100 
							AND OPERACAO <= 199 
							AND SITUACAO = '0'";

                return query;
            }
            V1RCAPCOMP.GetQueryEvent += GetQuery_V1RCAPCOMP;

        }

        [StopWatch]
        /*" M-0260-00-ABRIR-CSR-RISCO-DB-CLOSE-1 */
        public void M_0260_00_ABRIR_CSR_RISCO_DB_CLOSE_1()
        {
            /*" -3421- EXEC SQL CLOSE CSR_RISCO END-EXEC */

            CSR_RISCO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0260_99_SAIDA*/

        [StopWatch]
        /*" M-0270-00-FETCH-CSR-RISCO-SECTION */
        private void M_0270_00_FETCH_CSR_RISCO_SECTION()
        {
            /*" -3442- MOVE '0270-00-FETCH-CSR-RISCO       ' TO PARAGRAFO */
            _.Move("0270-00-FETCH-CSR-RISCO       ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3443- MOVE 'FETCH DO CURSOR CSR-RISCO     ' TO COMANDO */
            _.Move("FETCH DO CURSOR CSR-RISCO     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3445- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3449- PERFORM M_0270_00_FETCH_CSR_RISCO_DB_FETCH_1 */

            M_0270_00_FETCH_CSR_RISCO_DB_FETCH_1();

            /*" -3452-  EVALUATE SQLCODE  */

            /*" -3453-  WHEN ZEROS  */

            /*" -3453- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3454- CONTINUE */

                /*" -3455-  WHEN +100  */

                /*" -3455- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -3455- PERFORM M_0270_00_FETCH_CSR_RISCO_DB_CLOSE_1 */

                M_0270_00_FETCH_CSR_RISCO_DB_CLOSE_1();

                /*" -3457- MOVE 'SIM' TO WS-FIM-RISCO */
                _.Move("SIM", WS_FIM_RISCO);

                /*" -3458-  WHEN OTHER  */

                /*" -3458- ELSE */
            }
            else
            {


                /*" -3459- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -3459- PERFORM M_0270_00_FETCH_CSR_RISCO_DB_CLOSE_2 */

                M_0270_00_FETCH_CSR_RISCO_DB_CLOSE_2();

                /*" -3461- MOVE 'FIM' TO WS-FIM-RISCO */
                _.Move("FIM", WS_FIM_RISCO);

                /*" -3462- DISPLAY 'VA0118B - PROBLEMAS NO FETCH DO CURSOR CSR-RISCO' */
                _.Display($"VA0118B - PROBLEMAS NO FETCH DO CURSOR CSR-RISCO");

                /*" -3464- DISPLAY ' COD_PRODUTO_SIVPF.....   ' PROPOFID-COD-PRODUTO-SIVPF */
                _.Display($" COD_PRODUTO_SIVPF.....   {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF}");

                /*" -3466- DISPLAY ' CPF_CLIENTE...........   ' CLIENT-CGCCPF */
                _.Display($" CPF_CLIENTE...........   {CLIENT_CGCCPF}");

                /*" -3468- DISPLAY ' NUM-CERTIFICADO.......   ' PROPVA-NRCERTIF */
                _.Display($" NUM-CERTIFICADO.......   {PROPVA_NRCERTIF}");

                /*" -3470- DISPLAY ' SQLCODE...............   ' WS-SQLCODE */
                _.Display($" SQLCODE...............   {WS_SQLCODE}");

                /*" -3471- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3473-  END-EVALUATE  */

                /*" -3473- END-IF */
            }


            /*" -3473- . */

        }

        [StopWatch]
        /*" M-0270-00-FETCH-CSR-RISCO-DB-FETCH-1 */
        public void M_0270_00_FETCH_CSR_RISCO_DB_FETCH_1()
        {
            /*" -3449- EXEC SQL FETCH CSR_RISCO INTO :WS-NUM-CERTIFICADO-RISCO, :WS-SIT-REGISTRO-RISCO END-EXEC */

            if (CSR_RISCO.Fetch())
            {
                _.Move(CSR_RISCO.WS_NUM_CERTIFICADO_RISCO, WS_NUM_CERTIFICADO_RISCO);
                _.Move(CSR_RISCO.WS_SIT_REGISTRO_RISCO, WS_SIT_REGISTRO_RISCO);
            }

        }

        [StopWatch]
        /*" M-0270-00-FETCH-CSR-RISCO-DB-CLOSE-1 */
        public void M_0270_00_FETCH_CSR_RISCO_DB_CLOSE_1()
        {
            /*" -3455- EXEC SQL CLOSE CSR_RISCO END-EXEC */

            CSR_RISCO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0270_99_SAIDA*/

        [StopWatch]
        /*" M-0270-00-FETCH-CSR-RISCO-DB-CLOSE-2 */
        public void M_0270_00_FETCH_CSR_RISCO_DB_CLOSE_2()
        {
            /*" -3459- EXEC SQL CLOSE CSR_RISCO END-EXEC */

            CSR_RISCO.Close();

        }

        [StopWatch]
        /*" M-0280-00-CALCULA-RISCO-SECTION */
        private void M_0280_00_CALCULA_RISCO_SECTION()
        {
            /*" -3481- MOVE '0280-00-CALCULA-RISCO         ' TO PARAGRAFO */
            _.Move("0280-00-CALCULA-RISCO         ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3482- MOVE 'PROCESSA CALCULO LIMITE RISCO ' TO COMANDO */
            _.Move("PROCESSA CALCULO LIMITE RISCO ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3484- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3485- SET WS-PU-VIGENTE TO TRUE */
            WS_PRODUTO_PU["WS_PU_VIGENTE"] = true;

            /*" -3492- PERFORM 0282-00-VERIFICA-PU THRU 0282-99-SAIDA */

            M_0282_00_VERIFICA_PU_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0282_99_SAIDA*/


            /*" -3493- IF WS-PU-VIGENTE */

            if (WS_PRODUTO_PU["WS_PU_VIGENTE"])
            {

                /*" -3495- PERFORM 0284-00-SOMA-IS THRU 0284-99-SAIDA */

                M_0284_00_SOMA_IS_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0284_99_SAIDA*/


                /*" -3497- END-IF */
            }


            /*" -3500- PERFORM 0270-00-FETCH-CSR-RISCO THRU 0270-99-SAIDA */

            M_0270_00_FETCH_CSR_RISCO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0270_99_SAIDA*/


            /*" -3500- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0280_99_SAIDA*/

        [StopWatch]
        /*" M-0282-00-VERIFICA-PU-SECTION */
        private void M_0282_00_VERIFICA_PU_SECTION()
        {
            /*" -3508- MOVE '0282-00-VERIFICA-PU           ' TO PARAGRAFO */
            _.Move("0282-00-VERIFICA-PU           ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3509- MOVE 'RECUPERA APOLICE E NUM ITEM   ' TO COMANDO */
            _.Move("RECUPERA APOLICE E NUM ITEM   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3511- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3518- PERFORM M_0282_00_VERIFICA_PU_DB_SELECT_1 */

            M_0282_00_VERIFICA_PU_DB_SELECT_1();

            /*" -3521-  EVALUATE SQLCODE  */

            /*" -3522-  WHEN ZEROS  */

            /*" -3522- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3523- CONTINUE */

                /*" -3524-  WHEN OTHER  */

                /*" -3524- ELSE */
            }
            else
            {


                /*" -3525- DISPLAY 'VA0118B - PROBLEMAS ACESSO OPCAO_PAG_VIDAZUL' */
                _.Display($"VA0118B - PROBLEMAS ACESSO OPCAO_PAG_VIDAZUL");

                /*" -3527- DISPLAY ' NUM-CERTIFICADO.......   ' WS-NUM-CERTIFICADO-RISCO */
                _.Display($" NUM-CERTIFICADO.......   {WS_NUM_CERTIFICADO_RISCO}");

                /*" -3529- DISPLAY ' SQLCODE...............   ' SQLCODE */
                _.Display($" SQLCODE...............   {DB.SQLCODE}");

                /*" -3530- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3532-  END-EVALUATE  */

                /*" -3532- END-IF */
            }


            /*" -3534- IF OPCPAGVI-PERI-PAGAMENTO EQUAL ZEROS */

            if (OPCPAGVI_PERI_PAGAMENTO == 00)
            {

                /*" -3542- PERFORM M_0282_00_VERIFICA_PU_DB_SELECT_2 */

                M_0282_00_VERIFICA_PU_DB_SELECT_2();

                /*" -3545-  EVALUATE SQLCODE  */

                /*" -3546-  WHEN ZEROS  */

                /*" -3546- IF   SQLCODE EQUALS  ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -3548- PERFORM 0283-00-VERIFICA-VIGENCIA THRU 0283-99-SAIDA */

                    M_0283_00_VERIFICA_VIGENCIA_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0283_99_SAIDA*/


                    /*" -3551-  WHEN +100  */

                    /*" -3551- ELSE IF   SQLCODE EQUALS  +100 */
                }
                else

                if (DB.SQLCODE == +100)
                {

                    /*" -3552- SET WS-PU-VIGENTE TO TRUE */
                    WS_PRODUTO_PU["WS_PU_VIGENTE"] = true;

                    /*" -3553-  WHEN OTHER  */

                    /*" -3553- ELSE */
                }
                else
                {


                    /*" -3554- DISPLAY 'VA0118B - PROBLEMAS ACESSO SEGURADOS_VGAP' */
                    _.Display($"VA0118B - PROBLEMAS ACESSO SEGURADOS_VGAP");

                    /*" -3556- DISPLAY ' NUM-CERTIFICADO.......   ' WS-NUM-CERTIFICADO-RISCO */
                    _.Display($" NUM-CERTIFICADO.......   {WS_NUM_CERTIFICADO_RISCO}");

                    /*" -3558- DISPLAY ' SQLCODE...............   ' SQLCODE */
                    _.Display($" SQLCODE...............   {DB.SQLCODE}");

                    /*" -3559- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3561-  END-EVALUATE  */

                    /*" -3561- END-IF */
                }


                /*" -3563- END-IF */
            }


            /*" -3563- . */

        }

        [StopWatch]
        /*" M-0282-00-VERIFICA-PU-DB-SELECT-1 */
        public void M_0282_00_VERIFICA_PU_DB_SELECT_1()
        {
            /*" -3518- EXEC SQL SELECT PERI_PAGAMENTO INTO :OPCPAGVI-PERI-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :WS-NUM-CERTIFICADO-RISCO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC */

            var m_0282_00_VERIFICA_PU_DB_SELECT_1_Query1 = new M_0282_00_VERIFICA_PU_DB_SELECT_1_Query1()
            {
                WS_NUM_CERTIFICADO_RISCO = WS_NUM_CERTIFICADO_RISCO.ToString(),
            };

            var executed_1 = M_0282_00_VERIFICA_PU_DB_SELECT_1_Query1.Execute(m_0282_00_VERIFICA_PU_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI_PERI_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0282_99_SAIDA*/

        [StopWatch]
        /*" M-0282-00-VERIFICA-PU-DB-SELECT-2 */
        public void M_0282_00_VERIFICA_PU_DB_SELECT_2()
        {
            /*" -3542- EXEC SQL SELECT NUM_APOLICE, NUM_ITEM INTO :SEGURVGA-NUM-APOLICE , :SEGURVGA-NUM-ITEM FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :WS-NUM-CERTIFICADO-RISCO AND TIPO_SEGURADO = '1' WITH UR END-EXEC */

            var m_0282_00_VERIFICA_PU_DB_SELECT_2_Query1 = new M_0282_00_VERIFICA_PU_DB_SELECT_2_Query1()
            {
                WS_NUM_CERTIFICADO_RISCO = WS_NUM_CERTIFICADO_RISCO.ToString(),
            };

            var executed_1 = M_0282_00_VERIFICA_PU_DB_SELECT_2_Query1.Execute(m_0282_00_VERIFICA_PU_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_NUM_APOLICE, SEGURVGA_NUM_APOLICE);
                _.Move(executed_1.SEGURVGA_NUM_ITEM, SEGURVGA_NUM_ITEM);
            }


        }

        [StopWatch]
        /*" M-0283-00-VERIFICA-VIGENCIA-SECTION */
        private void M_0283_00_VERIFICA_VIGENCIA_SECTION()
        {
            /*" -3571- MOVE '0282-00-VERIFICA-PU           ' TO PARAGRAFO */
            _.Move("0282-00-VERIFICA-PU           ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3572- MOVE 'VERIFICA VIGENCIA PRODUTO PU  ' TO COMANDO */
            _.Move("VERIFICA VIGENCIA PRODUTO PU  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3575- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3586- PERFORM M_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1 */

            M_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1();

            /*" -3589-  EVALUATE SQLCODE  */

            /*" -3590-  WHEN ZEROS  */

            /*" -3590- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3591- SET WS-PU-VIGENTE TO TRUE */
                WS_PRODUTO_PU["WS_PU_VIGENTE"] = true;

                /*" -3592-  WHEN +100  */

                /*" -3592- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -3593- SET WS-PU-ENCERRADO TO TRUE */
                WS_PRODUTO_PU["WS_PU_ENCERRADO"] = true;

                /*" -3594-  WHEN OTHER  */

                /*" -3594- ELSE */
            }
            else
            {


                /*" -3595- DISPLAY 'VA0118B - PROBLEMAS ACESSO APOLICE_COBERTURAS' */
                _.Display($"VA0118B - PROBLEMAS ACESSO APOLICE_COBERTURAS");

                /*" -3597- DISPLAY ' NUM-CERTIFICADO.......   ' WS-NUM-CERTIFICADO-RISCO */
                _.Display($" NUM-CERTIFICADO.......   {WS_NUM_CERTIFICADO_RISCO}");

                /*" -3599- DISPLAY ' NUM-APOLICE...........   ' SEGURVGA-NUM-APOLICE */
                _.Display($" NUM-APOLICE...........   {SEGURVGA_NUM_APOLICE}");

                /*" -3601- DISPLAY ' NUM-ITEM..............   ' SEGURVGA-NUM-ITEM */
                _.Display($" NUM-ITEM..............   {SEGURVGA_NUM_ITEM}");

                /*" -3603- DISPLAY ' SQLCODE...............   ' SQLCODE */
                _.Display($" SQLCODE...............   {DB.SQLCODE}");

                /*" -3604- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3606-  END-EVALUATE  */

                /*" -3606- END-IF */
            }


            /*" -3606- . */

        }

        [StopWatch]
        /*" M-0283-00-VERIFICA-VIGENCIA-DB-SELECT-1 */
        public void M_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1()
        {
            /*" -3586- EXEC SQL SELECT DATA_INIVIGENCIA , DATA_TERVIGENCIA INTO :APOLICOB-DATA-INIVIGENCIA , :APOLICOB-DATA-TERVIGENCIA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND DATA_INIVIGENCIA <= :SISTEMA-DTMOVABE AND DATA_TERVIGENCIA >= :SISTEMA-DTMOVABE WITH UR END-EXEC */

            var m_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1_Query1 = new M_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1_Query1()
            {
                SEGURVGA_NUM_APOLICE = SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA_NUM_ITEM.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            var executed_1 = M_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1_Query1.Execute(m_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);
                _.Move(executed_1.APOLICOB_DATA_TERVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0283_99_SAIDA*/

        [StopWatch]
        /*" M-0284-00-SOMA-IS-SECTION */
        private void M_0284_00_SOMA_IS_SECTION()
        {
            /*" -3614- MOVE '0284-00-SOMA-IS               ' TO PARAGRAFO */
            _.Move("0284-00-SOMA-IS               ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3615- MOVE 'SOMA IMPORTANCIA SEGURADA     ' TO COMANDO */
            _.Move("SOMA IMPORTANCIA SEGURADA     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3617- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3624- PERFORM M_0284_00_SOMA_IS_DB_SELECT_1 */

            M_0284_00_SOMA_IS_DB_SELECT_1();

            /*" -3627-  EVALUATE SQLCODE  */

            /*" -3628-  WHEN ZEROS  */

            /*" -3628- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3629- ADD HISCOBPR-IMP-MORNATU TO WS-AC-TOT-RISCO */
                WS_AC_TOT_RISCO.Value = WS_AC_TOT_RISCO + HISCOBPR_IMP_MORNATU;

                /*" -3630-  WHEN +100  */

                /*" -3630- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -3631- MOVE ZEROS TO HISCOBPR-IMP-MORNATU */
                _.Move(0, HISCOBPR_IMP_MORNATU);

                /*" -3632-  WHEN OTHER  */

                /*" -3632- ELSE */
            }
            else
            {


                /*" -3633- DISPLAY 'VA0118B - PROBLEMAS ACESSO HIS_COBER_PROPOST' */
                _.Display($"VA0118B - PROBLEMAS ACESSO HIS_COBER_PROPOST");

                /*" -3635- DISPLAY ' NUM-CERTIFICADO.......   ' WS-NUM-CERTIFICADO-RISCO */
                _.Display($" NUM-CERTIFICADO.......   {WS_NUM_CERTIFICADO_RISCO}");

                /*" -3637- DISPLAY ' SQLCODE...............   ' SQLCODE */
                _.Display($" SQLCODE...............   {DB.SQLCODE}");

                /*" -3638- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3640-  END-EVALUATE  */

                /*" -3640- END-IF */
            }


            /*" -3640- . */

        }

        [StopWatch]
        /*" M-0284-00-SOMA-IS-DB-SELECT-1 */
        public void M_0284_00_SOMA_IS_DB_SELECT_1()
        {
            /*" -3624- EXEC SQL SELECT IMP_MORNATU INTO :HISCOBPR-IMP-MORNATU FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :WS-NUM-CERTIFICADO-RISCO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC */

            var m_0284_00_SOMA_IS_DB_SELECT_1_Query1 = new M_0284_00_SOMA_IS_DB_SELECT_1_Query1()
            {
                WS_NUM_CERTIFICADO_RISCO = WS_NUM_CERTIFICADO_RISCO.ToString(),
            };

            var executed_1 = M_0284_00_SOMA_IS_DB_SELECT_1_Query1.Execute(m_0284_00_SOMA_IS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR_IMP_MORNATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0284_99_SAIDA*/

        [StopWatch]
        /*" M-0300-VERIFICA-CROT-SECTION */
        private void M_0300_VERIFICA_CROT_SECTION()
        {
            /*" -3648- MOVE '0300-VERIFICA-CROT' TO PARAGRAFO. */
            _.Move("0300-VERIFICA-CROT", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3649- MOVE 'SELECT V0CLIENTE' TO COMANDO. */
            _.Move("SELECT V0CLIENTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3651- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3657- PERFORM M_0300_VERIFICA_CROT_DB_SELECT_1 */

            M_0300_VERIFICA_CROT_DB_SELECT_1();

            /*" -3660- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3662- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3664- MOVE 'SELECT V1CLIENTE_CROT' TO COMANDO. */
            _.Move("SELECT V1CLIENTE_CROT", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3669- PERFORM M_0300_VERIFICA_CROT_DB_SELECT_2 */

            M_0300_VERIFICA_CROT_DB_SELECT_2();

            /*" -3673- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3674- PERFORM 0320-UPDATE-CROT THRU 0320-FIM */

                M_0320_UPDATE_CROT_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0320_FIM*/


                /*" -3675- ELSE */
            }
            else
            {


                /*" -3676- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3677- PERFORM 0330-INCLUI-CROT THRU 0330-FIM */

                    M_0330_INCLUI_CROT_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0330_FIM*/


                    /*" -3678- ELSE */
                }
                else
                {


                    /*" -3678- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0300-VERIFICA-CROT-DB-SELECT-1 */
        public void M_0300_VERIFICA_CROT_DB_SELECT_1()
        {
            /*" -3657- EXEC SQL SELECT CGCCPF INTO :CLIENT-CGCCPF FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :PROPVA-CODCLIEN WITH UR END-EXEC. */

            var m_0300_VERIFICA_CROT_DB_SELECT_1_Query1 = new M_0300_VERIFICA_CROT_DB_SELECT_1_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            var executed_1 = M_0300_VERIFICA_CROT_DB_SELECT_1_Query1.Execute(m_0300_VERIFICA_CROT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENT_CGCCPF, CLIENT_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_FIM*/

        [StopWatch]
        /*" M-0300-VERIFICA-CROT-DB-SELECT-2 */
        public void M_0300_VERIFICA_CROT_DB_SELECT_2()
        {
            /*" -3669- EXEC SQL SELECT DTMOVABE INTO :CLIROT-DTMOVABE FROM SEGUROS.V1CLIENTE_CROT WHERE CGCCPF = :CLIENT-CGCCPF END-EXEC. */

            var m_0300_VERIFICA_CROT_DB_SELECT_2_Query1 = new M_0300_VERIFICA_CROT_DB_SELECT_2_Query1()
            {
                CLIENT_CGCCPF = CLIENT_CGCCPF.ToString(),
            };

            var executed_1 = M_0300_VERIFICA_CROT_DB_SELECT_2_Query1.Execute(m_0300_VERIFICA_CROT_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIROT_DTMOVABE, CLIROT_DTMOVABE);
            }


        }

        [StopWatch]
        /*" M-0320-UPDATE-CROT-SECTION */
        private void M_0320_UPDATE_CROT_SECTION()
        {
            /*" -3690- MOVE '0320-UPDATE-CROT' TO PARAGRAFO. */
            _.Move("0320-UPDATE-CROT", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3691- MOVE 'UPDATE V0CLIENTE_CROT' TO COMANDO. */
            _.Move("UPDATE V0CLIENTE_CROT", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3693- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3694- IF CLIROT-DTMOVABE < SISTEMA-DTMOVABE */

            if (CLIROT_DTMOVABE < SISTEMA_DTMOVABE)
            {

                /*" -3696- MOVE SISTEMA-DTMOVABE TO CLIROT-DTMOVABE. */
                _.Move(SISTEMA_DTMOVABE, CLIROT_DTMOVABE);
            }


            /*" -3701- PERFORM M_0320_UPDATE_CROT_DB_UPDATE_1 */

            M_0320_UPDATE_CROT_DB_UPDATE_1();

            /*" -3704- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3704- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0320-UPDATE-CROT-DB-UPDATE-1 */
        public void M_0320_UPDATE_CROT_DB_UPDATE_1()
        {
            /*" -3701- EXEC SQL UPDATE SEGUROS.V0CLIENTE_CROT SET BILH_VDAZUL = 'S' , DTMOVABE = :CLIROT-DTMOVABE WHERE CGCCPF = :CLIENT-CGCCPF END-EXEC. */

            var m_0320_UPDATE_CROT_DB_UPDATE_1_Update1 = new M_0320_UPDATE_CROT_DB_UPDATE_1_Update1()
            {
                CLIROT_DTMOVABE = CLIROT_DTMOVABE.ToString(),
                CLIENT_CGCCPF = CLIENT_CGCCPF.ToString(),
            };

            M_0320_UPDATE_CROT_DB_UPDATE_1_Update1.Execute(m_0320_UPDATE_CROT_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0320_FIM*/

        [StopWatch]
        /*" M-0330-INCLUI-CROT-SECTION */
        private void M_0330_INCLUI_CROT_SECTION()
        {
            /*" -3716- MOVE '0330-INCLUI-CROT' TO PARAGRAFO. */
            _.Move("0330-INCLUI-CROT", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3717- MOVE 'INSERT V0CLIENTE_CROT' TO COMANDO. */
            _.Move("INSERT V0CLIENTE_CROT", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3719- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3726- PERFORM M_0330_INCLUI_CROT_DB_INSERT_1 */

            M_0330_INCLUI_CROT_DB_INSERT_1();

            /*" -3729- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3729- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0330-INCLUI-CROT-DB-INSERT-1 */
        public void M_0330_INCLUI_CROT_DB_INSERT_1()
        {
            /*" -3726- EXEC SQL INSERT INTO SEGUROS.V0CLIENTE_CROT VALUES (:CLIENT-CGCCPF, 'N' , 'N' , 'S' , :SISTEMA-DTMOVABE) END-EXEC. */

            var m_0330_INCLUI_CROT_DB_INSERT_1_Insert1 = new M_0330_INCLUI_CROT_DB_INSERT_1_Insert1()
            {
                CLIENT_CGCCPF = CLIENT_CGCCPF.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            M_0330_INCLUI_CROT_DB_INSERT_1_Insert1.Execute(m_0330_INCLUI_CROT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0330_FIM*/

        [StopWatch]
        /*" R0397-00-PROXIMO-FOLHETO-SECTION */
        private void R0397_00_PROXIMO_FOLHETO_SECTION()
        {
            /*" -3741- MOVE 'R0397-00-PROXIMO-FOLHETO' TO PARAGRAFO. */
            _.Move("R0397-00-PROXIMO-FOLHETO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3742- MOVE SPACES TO COMANDO. */
            _.Move("", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3745- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3746- IF WS-CHAVE-ANT NOT EQUAL WS-CHAVE */

            if (WS_WORK_AREAS.WS_CHAVE_ANT != WS_WORK_AREAS.WS_CHAVE)
            {

                /*" -3747- PERFORM R0398-00-MAX-V0FOLHETO THRU R0398-FIM */

                R0398_00_MAX_V0FOLHETO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0398_FIM*/


                /*" -3749- PERFORM R0399-00-SELECT-V0FOLHETO THRU R0399-FIM */

                R0399_00_SELECT_V0FOLHETO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0399_FIM*/


                /*" -3750- MOVE PROPVA-NUM-APOLICE TO WS-NUM-APOLICE-ANT */
                _.Move(PROPVA_NUM_APOLICE, WS_WORK_AREAS.WS_CHAVE_ANT.WS_NUM_APOLICE_ANT);

                /*" -3750- MOVE PROPVA-CODSUBES TO WS-CODSUBES-ANT. */
                _.Move(PROPVA_CODSUBES, WS_WORK_AREAS.WS_CHAVE_ANT.WS_CODSUBES_ANT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0397_FIM*/

        [StopWatch]
        /*" R0398-00-MAX-V0FOLHETO-SECTION */
        private void R0398_00_MAX_V0FOLHETO_SECTION()
        {
            /*" -3763- MOVE 'R0398-00-MAX-V0FOLHETO' TO PARAGRAFO. */
            _.Move("R0398-00-MAX-V0FOLHETO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3764- MOVE 'SELECT MAX V0FOLHETO-INFO' TO COMANDO. */
            _.Move("SELECT MAX V0FOLHETO-INFO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3766- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3771- PERFORM R0398_00_MAX_V0FOLHETO_DB_SELECT_1 */

            R0398_00_MAX_V0FOLHETO_DB_SELECT_1();

            /*" -3774- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3775- DISPLAY 'VA0118B - PROBLEMAS SELECT MAX VFOLHETO' */
                _.Display($"VA0118B - PROBLEMAS SELECT MAX VFOLHETO");

                /*" -3775- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0398-00-MAX-V0FOLHETO-DB-SELECT-1 */
        public void R0398_00_MAX_V0FOLHETO_DB_SELECT_1()
        {
            /*" -3771- EXEC SQL SELECT MAX(DTEMICAR) INTO :V0FOLHM-DTEMICAR FROM SEGUROS.V0FOLHETO_INFO WHERE SITUACAO = '0' END-EXEC. */

            var r0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1 = new R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1.Execute(r0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FOLHM_DTEMICAR, V0FOLHM_DTEMICAR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0398_FIM*/

        [StopWatch]
        /*" R0399-00-SELECT-V0FOLHETO-SECTION */
        private void R0399_00_SELECT_V0FOLHETO_SECTION()
        {
            /*" -3784- MOVE 'R0399-00-SELECT-FOLHETO' TO PARAGRAFO. */
            _.Move("R0399-00-SELECT-FOLHETO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3785- MOVE 'SELECT V0FOLHETO-INFO' TO COMANDO. */
            _.Move("SELECT V0FOLHETO-INFO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3787- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3795- PERFORM R0399_00_SELECT_V0FOLHETO_DB_SELECT_1 */

            R0399_00_SELECT_V0FOLHETO_DB_SELECT_1();

            /*" -3798- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3799- IF SQLCODE EQUAL -811 */

                if (DB.SQLCODE == -811)
                {

                    /*" -3800- CONTINUE */

                    /*" -3801- ELSE */
                }
                else
                {


                    /*" -3802- DISPLAY 'VG0469B - PROBLEMAS SELECT V0FOLHETO' */
                    _.Display($"VG0469B - PROBLEMAS SELECT V0FOLHETO");

                    /*" -3803- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3804- END-IF */
                }


                /*" -3806- END-IF */
            }


            /*" -3807- MOVE V0FOLH-COD-CARTA TO WS-COD-CARTA */
            _.Move(V0FOLH_COD_CARTA, WS_WORK_AREAS.WS_COD_CARTA);

            /*" -3807- MOVE V0FOLH-DTEMICAR TO W-DTEMICAR. */
            _.Move(V0FOLH_DTEMICAR, WS_WORK_AREAS.W_DTEMICAR);

        }

        [StopWatch]
        /*" R0399-00-SELECT-V0FOLHETO-DB-SELECT-1 */
        public void R0399_00_SELECT_V0FOLHETO_DB_SELECT_1()
        {
            /*" -3795- EXEC SQL SELECT COD_CARTA, DTEMICAR INTO :V0FOLH-COD-CARTA, :V0FOLH-DTEMICAR FROM SEGUROS.V0FOLHETO_INFO WHERE DTEMICAR = :V0FOLHM-DTEMICAR AND SITUACAO = '0' END-EXEC. */

            var r0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1 = new R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1()
            {
                V0FOLHM_DTEMICAR = V0FOLHM_DTEMICAR.ToString(),
            };

            var executed_1 = R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1.Execute(r0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FOLH_COD_CARTA, V0FOLH_COD_CARTA);
                _.Move(executed_1.V0FOLH_DTEMICAR, V0FOLH_DTEMICAR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0399_FIM*/

        [StopWatch]
        /*" M-0400-GERA-MOV-FOLHETOS-SECTION */
        private void M_0400_GERA_MOV_FOLHETOS_SECTION()
        {
            /*" -3825- MOVE '0400-GERA-MOV-FOLHETOS' TO PARAGRAFO. */
            _.Move("0400-GERA-MOV-FOLHETOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3826- MOVE 'INSERT V0FOLHETO' TO COMANDO. */
            _.Move("INSERT V0FOLHETO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3828- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3829- MOVE PROPVA-CODPRODU TO V0FOLH-COD-PRODUTO */
            _.Move(PROPVA_CODPRODU, V0FOLH_COD_PRODUTO);

            /*" -3830- MOVE PROPVA-NRCERTIF TO V0FOLH-NRCERTIF */
            _.Move(PROPVA_NRCERTIF, V0FOLH_NRCERTIF);

            /*" -3832- MOVE WS-COD-CARTA TO V0FOLH-COD-CARTA */
            _.Move(WS_WORK_AREAS.WS_COD_CARTA, V0FOLH_COD_CARTA);

            /*" -3834- MOVE SISTEMA-DTMOVABE TO V0FOLH-DTSOLICIT. */
            _.Move(SISTEMA_DTMOVABE, V0FOLH_DTSOLICIT);

            /*" -3835- IF W-DDEMICAR > 20 */

            if (WS_WORK_AREAS.FILLER_9.W_DDEMICAR > 20)
            {

                /*" -3837- COMPUTE W-MMEMICAR = W-MMEMICAR + 1 */
                WS_WORK_AREAS.FILLER_9.W_MMEMICAR.Value = WS_WORK_AREAS.FILLER_9.W_MMEMICAR + 1;

                /*" -3838- IF W-MMEMICAR > 12 */

                if (WS_WORK_AREAS.FILLER_9.W_MMEMICAR > 12)
                {

                    /*" -3839- MOVE 1 TO W-MMEMICAR */
                    _.Move(1, WS_WORK_AREAS.FILLER_9.W_MMEMICAR);

                    /*" -3841- ADD 1 TO W-SSEMICAR. */
                    WS_WORK_AREAS.FILLER_9.W_SSEMICAR.Value = WS_WORK_AREAS.FILLER_9.W_SSEMICAR + 1;
                }

            }


            /*" -3843- MOVE 20 TO W-DDEMICAR. */
            _.Move(20, WS_WORK_AREAS.FILLER_9.W_DDEMICAR);

            /*" -3845- MOVE W-DTEMICAR TO V0FOLH-DTEMICAR */
            _.Move(WS_WORK_AREAS.W_DTEMICAR, V0FOLH_DTEMICAR);

            /*" -3846- MOVE 'VA0118B' TO V0FOLH-CODUSU */
            _.Move("VA0118B", V0FOLH_CODUSU);

            /*" -3848- MOVE '0' TO V0FOLH-SITUACAO. */
            _.Move("0", V0FOLH_SITUACAO);

            /*" -3858- PERFORM M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1 */

            M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1();

            /*" -3861- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3862- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -3863- CONTINUE */

                    /*" -3864- ELSE */
                }
                else
                {


                    /*" -3865- DISPLAY 'PROBLEMAS INSERT V0FOLHETO_INFO' */
                    _.Display($"PROBLEMAS INSERT V0FOLHETO_INFO");

                    /*" -3866- DISPLAY 'COD-PRODUTO......... ' V0FOLH-COD-PRODUTO */
                    _.Display($"COD-PRODUTO......... {V0FOLH_COD_PRODUTO}");

                    /*" -3867- DISPLAY 'CERTIFCADO.......... ' V0FOLH-NRCERTIF */
                    _.Display($"CERTIFCADO.......... {V0FOLH_NRCERTIF}");

                    /*" -3868- DISPLAY 'COD-CARTA........... ' V0FOLH-COD-CARTA */
                    _.Display($"COD-CARTA........... {V0FOLH_COD_CARTA}");

                    /*" -3869- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3870- END-IF */
                }


                /*" -3871- ELSE */
            }
            else
            {


                /*" -3872- ADD 1 TO AC-FOLHETOS */
                WS_WORK_AREAS.AC_FOLHETOS.Value = WS_WORK_AREAS.AC_FOLHETOS + 1;

                /*" -3874- END-IF */
            }


            /*" -3874- . */

        }

        [StopWatch]
        /*" M-0400-GERA-MOV-FOLHETOS-DB-INSERT-1 */
        public void M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1()
        {
            /*" -3858- EXEC SQL INSERT INTO SEGUROS.V0FOLHETO_INFO VALUES (:V0FOLH-COD-PRODUTO, :V0FOLH-NRCERTIF, :V0FOLH-COD-CARTA, :V0FOLH-DTEMICAR, :V0FOLH-DTSOLICIT, :V0FOLH-CODUSU, :V0FOLH-SITUACAO, CURRENT TIMESTAMP) END-EXEC. */

            var m_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1 = new M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1()
            {
                V0FOLH_COD_PRODUTO = V0FOLH_COD_PRODUTO.ToString(),
                V0FOLH_NRCERTIF = V0FOLH_NRCERTIF.ToString(),
                V0FOLH_COD_CARTA = V0FOLH_COD_CARTA.ToString(),
                V0FOLH_DTEMICAR = V0FOLH_DTEMICAR.ToString(),
                V0FOLH_DTSOLICIT = V0FOLH_DTSOLICIT.ToString(),
                V0FOLH_CODUSU = V0FOLH_CODUSU.ToString(),
                V0FOLH_SITUACAO = V0FOLH_SITUACAO.ToString(),
            };

            M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1.Execute(m_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0400_FIM*/

        [StopWatch]
        /*" M-0500-00-DEFINE-SIT-PROPOSTA-SECTION */
        private void M_0500_00_DEFINE_SIT_PROPOSTA_SECTION()
        {
            /*" -3882- MOVE '0500-00-DEFINE-SIT-PROPOSTA   ' TO PARAGRAFO */
            _.Move("0500-00-DEFINE-SIT-PROPOSTA   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3883- MOVE 'DEFINE SITUACAO DA PROPOSTA   ' TO COMANDO */
            _.Move("DEFINE SITUACAO DA PROPOSTA   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3888- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3889- IF WS-AC-TOT-RISCO > 30000 */

            if (WS_AC_TOT_RISCO > 30000)
            {

                /*" -3890- IF WS-AC-TOT-RISCO <= 100000 */

                if (WS_AC_TOT_RISCO <= 100000)
                {

                    /*" -3891- ADD 1 TO AC-ACEITA-PRD-001 */
                    WS_WORK_AREAS.AC_ACEITA_PRD_001.Value = WS_WORK_AREAS.AC_ACEITA_PRD_001 + 1;

                    /*" -3893- MOVE WS-TXT-ACEITA-PROPOSTA TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move(WS_TXT_ACEITA_PROPOSTA, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -3895- PERFORM 0600-00-INSERE-ANDAMENTO THRU 0600-99-SAIDA */

                    M_0600_00_INSERE_ANDAMENTO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0600_99_SAIDA*/


                    /*" -3896- ELSE */
                }
                else
                {


                    /*" -3897- MOVE 1852 TO ERRPROVI-COD-ERRO */
                    _.Move(1852, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -3898- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                    M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                    /*" -3899- IF PROPVA-SITUACAO EQUAL '0' */

                    if (PROPVA_SITUACAO == "0")
                    {

                        /*" -3900- MOVE 'VA0469B' TO RELATO-CODRELAT */
                        _.Move("VA0469B", RELATO_CODRELAT);

                        /*" -3901- PERFORM 0550-00-REALIZA-DEVOLUCAO */

                        M_0550_00_REALIZA_DEVOLUCAO_SECTION();

                        /*" -3902- END-IF */
                    }


                    /*" -3903- IF WS-SIM-PROPOSTA */

                    if (WS_PROPOSTA_FIDELIZ["WS_SIM_PROPOSTA"])
                    {

                        /*" -3904- PERFORM 0580-00-DECLINA-PROPOSTA */

                        M_0580_00_DECLINA_PROPOSTA_SECTION();

                        /*" -3905- END-IF */
                    }


                    /*" -3907- PERFORM 0590-00-ATUALIZA-PROPOSTAS-VA */

                    M_0590_00_ATUALIZA_PROPOSTAS_VA_SECTION();

                    /*" -3909- MOVE WS-TXT-NEGA-CEM-MIL TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move(WS_TXT_NEGA_CEM_MIL, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -3911- ADD 1 TO AC-DECLIN-100MIL */
                    WS_WORK_AREAS.AC_DECLIN_100MIL.Value = WS_WORK_AREAS.AC_DECLIN_100MIL + 1;

                    /*" -3914- PERFORM 0600-00-INSERE-ANDAMENTO THRU 0600-99-SAIDA */

                    M_0600_00_INSERE_ANDAMENTO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0600_99_SAIDA*/


                    /*" -3915- SET WS-SIM-DECLINADO TO TRUE */
                    WS_DECLINADO["WS_SIM_DECLINADO"] = true;

                    /*" -3916- END-IF */
                }


                /*" -3918- END-IF */
            }


            /*" -3918- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0500_99_SAIDA*/

        [StopWatch]
        /*" M-0510-00-DEFINE-SIT-PROPOSTA-SECTION */
        private void M_0510_00_DEFINE_SIT_PROPOSTA_SECTION()
        {
            /*" -3926- MOVE '0510-00-DEFINE-SIT-PROPOSTA   ' TO PARAGRAFO */
            _.Move("0510-00-DEFINE-SIT-PROPOSTA   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3927- MOVE 'DEFINE SITUACAO DA PROPOSTA   ' TO COMANDO */
            _.Move("DEFINE SITUACAO DA PROPOSTA   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3931- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3932- IF WS-AC-TOT-RISCO > 600000 */

            if (WS_AC_TOT_RISCO > 600000)
            {

                /*" -3933- MOVE 1852 TO ERRPROVI-COD-ERRO */
                _.Move(1852, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                /*" -3935- PERFORM 0101-00-INSERT-VG-CRTCA-PROP */

                M_0101_00_INSERT_VG_CRTCA_PROP_SECTION();

                /*" -3938- IF PROPVA-SITUACAO EQUAL '0' */

                if (PROPVA_SITUACAO == "0")
                {

                    /*" -3939- MOVE 'VA0469B' TO RELATO-CODRELAT */
                    _.Move("VA0469B", RELATO_CODRELAT);

                    /*" -3940- PERFORM 0550-00-REALIZA-DEVOLUCAO */

                    M_0550_00_REALIZA_DEVOLUCAO_SECTION();

                    /*" -3942- END-IF */
                }


                /*" -3943- IF WS-SIM-PROPOSTA */

                if (WS_PROPOSTA_FIDELIZ["WS_SIM_PROPOSTA"])
                {

                    /*" -3944- PERFORM 0580-00-DECLINA-PROPOSTA */

                    M_0580_00_DECLINA_PROPOSTA_SECTION();

                    /*" -3946- END-IF */
                }


                /*" -3948- PERFORM 0590-00-ATUALIZA-PROPOSTAS-VA */

                M_0590_00_ATUALIZA_PROPOSTAS_VA_SECTION();

                /*" -3949- MOVE WS-TXT-NEGA-600-MIL TO VG078-DES-ANDAMENTO-TEXT */
                _.Move(WS_TXT_NEGA_600_MIL, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                /*" -3951- ADD 1 TO AC-DECLIN-600MIL */
                WS_WORK_AREAS.AC_DECLIN_600MIL.Value = WS_WORK_AREAS.AC_DECLIN_600MIL + 1;

                /*" -3954- PERFORM 0600-00-INSERE-ANDAMENTO THRU 0600-99-SAIDA */

                M_0600_00_INSERE_ANDAMENTO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0600_99_SAIDA*/


                /*" -3955- SET WS-SIM-DECLINADO TO TRUE */
                WS_DECLINADO["WS_SIM_DECLINADO"] = true;

                /*" -3956- ELSE */
            }
            else
            {


                /*" -3957- ADD 1 TO AC-ACEITA-PRD-002 */
                WS_WORK_AREAS.AC_ACEITA_PRD_002.Value = WS_WORK_AREAS.AC_ACEITA_PRD_002 + 1;

                /*" -3959- END-IF */
            }


            /*" -3959- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0510_99_SAIDA*/

        [StopWatch]
        /*" M-0550-00-REALIZA-DEVOLUCAO-SECTION */
        private void M_0550_00_REALIZA_DEVOLUCAO_SECTION()
        {
            /*" -3967- MOVE '0550-00-REALIZA-DEVOLUCAO ' TO PARAGRAFO */
            _.Move("0550-00-REALIZA-DEVOLUCAO ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3968- MOVE 'CONSULTA DEVOLUCAO SEGURADO' TO COMANDO */
            _.Move("CONSULTA DEVOLUCAO SEGURADO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3970- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3978- PERFORM M_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1 */

            M_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1();

            /*" -3981-  EVALUATE SQLCODE  */

            /*" -3982-  WHEN ZEROS  */

            /*" -3982- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3983- SET WS-SIM-RESTITUIDO TO TRUE */
                WS_RESTITUICAO["WS_SIM_RESTITUIDO"] = true;

                /*" -3984-  WHEN +100  */

                /*" -3984- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -3985- CONTINUE */

                /*" -3986-  WHEN -811  */

                /*" -3986- ELSE IF   SQLCODE EQUALS  -811 */
            }
            else

            if (DB.SQLCODE == -811)
            {

                /*" -3987- PERFORM 0555-00-ATUALIZA-RELATORIOS */

                M_0555_00_ATUALIZA_RELATORIOS_SECTION();

                /*" -3988-  WHEN OTHER  */

                /*" -3988- ELSE */
            }
            else
            {


                /*" -3989- DISPLAY 'VA0118B - PROBLEMAS NO SELECT DA RELATORIOS' */
                _.Display($"VA0118B - PROBLEMAS NO SELECT DA RELATORIOS");

                /*" -3991- DISPLAY ' NUM-CERTIFICADO.......   ' PROPVA-NRCERTIF */
                _.Display($" NUM-CERTIFICADO.......   {PROPVA_NRCERTIF}");

                /*" -3993- DISPLAY ' COD-RELATORIO.........   ' RELATO-CODRELAT */
                _.Display($" COD-RELATORIO.........   {RELATO_CODRELAT}");

                /*" -3995- DISPLAY ' SQLCODE...............   ' SQLCODE */
                _.Display($" SQLCODE...............   {DB.SQLCODE}");

                /*" -3996- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3998-  END-EVALUATE  */

                /*" -3998- END-IF */
            }


            /*" -3999- IF WS-NAO-RESTITUIDO */

            if (WS_RESTITUICAO["WS_NAO_RESTITUIDO"])
            {

                /*" -4000- PERFORM 0560-00-INSERT-RELATORIOS */

                M_0560_00_INSERT_RELATORIOS_SECTION();

                /*" -4002- END-IF */
            }


            /*" -4002- . */

        }

        [StopWatch]
        /*" M-0550-00-REALIZA-DEVOLUCAO-DB-SELECT-1 */
        public void M_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1()
        {
            /*" -3978- EXEC SQL SELECT COD_USUARIO INTO :RELATORI-COD-USUARIO FROM SEGUROS.RELATORIOS WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND COD_RELATORIO = :RELATO-CODRELAT AND SIT_REGISTRO = '0' END-EXEC */

            var m_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1_Query1 = new M_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                RELATO_CODRELAT = RELATO_CODRELAT.ToString(),
            };

            var executed_1 = M_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1_Query1.Execute(m_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0550_99_SAIDA*/

        [StopWatch]
        /*" M-0555-00-ATUALIZA-RELATORIOS-SECTION */
        private void M_0555_00_ATUALIZA_RELATORIOS_SECTION()
        {
            /*" -4010- MOVE '0555-00-ATUALIZA-RELATORIOS ' TO PARAGRAFO */
            _.Move("0555-00-ATUALIZA-RELATORIOS ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4011- MOVE 'ATUALIZA TABELA RELATORIOS  ' TO COMANDO */
            _.Move("ATUALIZA TABELA RELATORIOS  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4013- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4020- PERFORM M_0555_00_ATUALIZA_RELATORIOS_DB_UPDATE_1 */

            M_0555_00_ATUALIZA_RELATORIOS_DB_UPDATE_1();

            /*" -4023- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -4024- CONTINUE */

                /*" -4025- ELSE */
            }
            else
            {


                /*" -4026- DISPLAY 'VA0118B - PROBLEMAS NO UPDATE TABELA RELATORIOS' */
                _.Display($"VA0118B - PROBLEMAS NO UPDATE TABELA RELATORIOS");

                /*" -4028- DISPLAY ' NUM-CERTIFICADO.......   ' PROPVA-NRCERTIF */
                _.Display($" NUM-CERTIFICADO.......   {PROPVA_NRCERTIF}");

                /*" -4030- DISPLAY ' COD-RELATORIO.........   ' RELATO-CODRELAT */
                _.Display($" COD-RELATORIO.........   {RELATO_CODRELAT}");

                /*" -4032- DISPLAY ' SQLCODE...............   ' SQLCODE */
                _.Display($" SQLCODE...............   {DB.SQLCODE}");

                /*" -4033- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -4035- END-IF */
            }


            /*" -4035- . */

        }

        [StopWatch]
        /*" M-0555-00-ATUALIZA-RELATORIOS-DB-UPDATE-1 */
        public void M_0555_00_ATUALIZA_RELATORIOS_DB_UPDATE_1()
        {
            /*" -4020- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND COD_RELATORIO = :RELATO-CODRELAT AND SIT_REGISTRO = '0' END-EXEC */

            var m_0555_00_ATUALIZA_RELATORIOS_DB_UPDATE_1_Update1 = new M_0555_00_ATUALIZA_RELATORIOS_DB_UPDATE_1_Update1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                RELATO_CODRELAT = RELATO_CODRELAT.ToString(),
            };

            M_0555_00_ATUALIZA_RELATORIOS_DB_UPDATE_1_Update1.Execute(m_0555_00_ATUALIZA_RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0555_99_SAIDA*/

        [StopWatch]
        /*" M-0560-00-INSERT-RELATORIOS-SECTION */
        private void M_0560_00_INSERT_RELATORIOS_SECTION()
        {
            /*" -4043- MOVE '0560-00-INSERT-RELATORIOS ' TO PARAGRAFO */
            _.Move("0560-00-INSERT-RELATORIOS ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4044- MOVE 'INSERE DEVOLUCAO SEGURADO  ' TO COMANDO */
            _.Move("INSERE DEVOLUCAO SEGURADO  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4047- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4049- IF (PROPOFID-NUMCTADEB NOT EQUAL ZEROS AND OPCAOP-OPCAOPAG NOT EQUAL '5' ) */

            if ((PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB != 00 && OPCAOP_OPCAOPAG != "5"))
            {

                /*" -4050- MOVE 104 TO WS-BCO-RELAT */
                _.Move(104, WS_BCO_RELAT);

                /*" -4051- MOVE PROPOFID-VAL-PAGO TO WS-VLR-RELAT */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, WS_VLR_RELAT);

                /*" -4052- COMPUTE WS-VLR-RELAT = WS-VLR-RELAT * 100 */
                WS_VLR_RELAT.Value = WS_VLR_RELAT * 100;

                /*" -4053- MOVE WS-VLR-RELAT TO WS-NUM-ORDEM-RELAT */
                _.Move(WS_VLR_RELAT, WS_NUM_ORDEM_RELAT);

                /*" -4054- MOVE 2 TO RELATO-NUM-COPIAS */
                _.Move(2, RELATO_NUM_COPIAS);

                /*" -4055- ELSE */
            }
            else
            {


                /*" -4061- MOVE ZEROS TO WS-BCO-RELAT PROPOFID-AGECTADEB PROPOFID-OPRCTADEB PROPOFID-NUMCTADEB PROPOFID-DIGCTADEB WS-NUM-ORDEM-RELAT */
                _.Move(0, WS_BCO_RELAT, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB, WS_NUM_ORDEM_RELAT);

                /*" -4063- END-IF */
            }


            /*" -4064- IF OPCAOP-OPCAOPAG EQUAL '5' */

            if (OPCAOP_OPCAOPAG == "5")
            {

                /*" -4065- MOVE 5 TO RELATO-NUM-COPIAS */
                _.Move(5, RELATO_NUM_COPIAS);

                /*" -4066- MOVE PROPOFID-VAL-PAGO TO WS-VLR-RELAT */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, WS_VLR_RELAT);

                /*" -4067- COMPUTE WS-VLR-RELAT = WS-VLR-RELAT * 100 */
                WS_VLR_RELAT.Value = WS_VLR_RELAT * 100;

                /*" -4068- MOVE WS-VLR-RELAT TO WS-NUM-ORDEM-RELAT */
                _.Move(WS_VLR_RELAT, WS_NUM_ORDEM_RELAT);

                /*" -4069- ELSE */
            }
            else
            {


                /*" -4070- MOVE 2 TO RELATO-NUM-COPIAS */
                _.Move(2, RELATO_NUM_COPIAS);

                /*" -4073- END-IF */
            }


            /*" -4162- PERFORM M_0560_00_INSERT_RELATORIOS_DB_INSERT_1 */

            M_0560_00_INSERT_RELATORIOS_DB_INSERT_1();

            /*" -4165- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -4166- CONTINUE */

                /*" -4167- ELSE */
            }
            else
            {


                /*" -4168- DISPLAY 'VA0118B - PROBLEMAS NO INSERT TABELA RELATORIOS' */
                _.Display($"VA0118B - PROBLEMAS NO INSERT TABELA RELATORIOS");

                /*" -4170- DISPLAY ' NUM-CERTIFICADO.......   ' PROPVA-NRCERTIF */
                _.Display($" NUM-CERTIFICADO.......   {PROPVA_NRCERTIF}");

                /*" -4172- DISPLAY ' COD-RELATORIO.........   ' RELATO-CODRELAT */
                _.Display($" COD-RELATORIO.........   {RELATO_CODRELAT}");

                /*" -4174- DISPLAY ' SQLCODE...............   ' SQLCODE */
                _.Display($" SQLCODE...............   {DB.SQLCODE}");

                /*" -4175- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -4177- END-IF */
            }


            /*" -4177- . */

        }

        [StopWatch]
        /*" M-0560-00-INSERT-RELATORIOS-DB-INSERT-1 */
        public void M_0560_00_INSERT_RELATORIOS_DB_INSERT_1()
        {
            /*" -4162- EXEC SQL INSERT INTO SEGUROS.RELATORIOS ( COD_USUARIO , DATA_SOLICITACAO , IDE_SISTEMA , COD_RELATORIO , NUM_COPIAS , QUANTIDADE , PERI_INICIAL , PERI_FINAL , DATA_REFERENCIA , MES_REFERENCIA , ANO_REFERENCIA , ORGAO_EMISSOR , COD_FONTE , COD_PRODUTOR , RAMO_EMISSOR , COD_MODALIDADE , COD_CONGENERE , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , NUM_CERTIFICADO , NUM_TITULO , COD_SUBGRUPO , COD_OPERACAO , COD_PLANO , OCORR_HISTORICO , NUM_APOL_LIDER , ENDOS_LIDER , NUM_PARC_LIDER , NUM_SINISTRO , NUM_SINI_LIDER , NUM_ORDEM , COD_MOEDA , TIPO_CORRECAO , SIT_REGISTRO , IND_PREV_DEFINIT , IND_ANAL_RESUMO , COD_EMPRESA , PERI_RENOVACAO , PCT_AUMENTO , TIMESTAMP ) VALUES ( 'VA0118B' , :SISTEMA-DTMOVABE , 'VA' , :RELATO-CODRELAT , :RELATO-NUM-COPIAS , :WS-BCO-RELAT , :SISTEMA-DTMOVABE , :SISTEMA-DTMOVABE , :SISTEMA-DTMOVABE , :PROPOFID-AGECTADEB , :PROPOFID-OPRCTADEB , :PROPOFID-DIGCTADEB , 0 , 0 , 0 , 0 , 0 , :PROPVA-NUM-APOLICE , 0 , 1 , :PROPVA-NRCERTIF , 0 , :PROPVA-CODSUBES , 16 , 0 , 0 , ' ' , ' ' , 0 , :PROPOFID-NUMCTADEB , ' ' , :WS-NUM-ORDEM-RELAT , 0 , ' ' , '0' , ' ' , ' ' , NULL , 0 , 0 , CURRENT TIMESTAMP ) END-EXEC */

            var m_0560_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 = new M_0560_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1()
            {
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                RELATO_CODRELAT = RELATO_CODRELAT.ToString(),
                RELATO_NUM_COPIAS = RELATO_NUM_COPIAS.ToString(),
                WS_BCO_RELAT = WS_BCO_RELAT.ToString(),
                PROPOFID_AGECTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB.ToString(),
                PROPOFID_OPRCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB.ToString(),
                PROPOFID_DIGCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB.ToString(),
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPOFID_NUMCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB.ToString(),
                WS_NUM_ORDEM_RELAT = WS_NUM_ORDEM_RELAT.ToString(),
            };

            M_0560_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1.Execute(m_0560_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0560_99_SAIDA*/

        [StopWatch]
        /*" M-0580-00-DECLINA-PROPOSTA-SECTION */
        private void M_0580_00_DECLINA_PROPOSTA_SECTION()
        {
            /*" -4185- MOVE '0580-00-DECLINA-PROPOSTA   ' TO PARAGRAFO */
            _.Move("0580-00-DECLINA-PROPOSTA   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4186- MOVE 'ATUALIZA PROPOSTA_FIDELIZ  ' TO COMANDO */
            _.Move("ATUALIZA PROPOSTA_FIDELIZ  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4188- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4189- MOVE 'REJ' TO PROPOFID-SIT-PROPOSTA */
            _.Move("REJ", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

            /*" -4191- MOVE 'S' TO PROPOFID-SITUACAO-ENVIO */
            _.Move("S", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);

            /*" -4197- PERFORM M_0580_00_DECLINA_PROPOSTA_DB_UPDATE_1 */

            M_0580_00_DECLINA_PROPOSTA_DB_UPDATE_1();

            /*" -4200- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4201- CONTINUE */

                /*" -4202- ELSE */
            }
            else
            {


                /*" -4203- DISPLAY 'VA0118B - PROBLEMAS NO UPDATE PROPOSTA_FIDELIZ' */
                _.Display($"VA0118B - PROBLEMAS NO UPDATE PROPOSTA_FIDELIZ");

                /*" -4205- DISPLAY ' NUM-CERTIFICADO.......   ' PROPVA-NRCERTIF */
                _.Display($" NUM-CERTIFICADO.......   {PROPVA_NRCERTIF}");

                /*" -4207- DISPLAY ' SQLCODE...............   ' SQLCODE */
                _.Display($" SQLCODE...............   {DB.SQLCODE}");

                /*" -4208- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -4210- END-IF */
            }


            /*" -4210- . */

        }

        [StopWatch]
        /*" M-0580-00-DECLINA-PROPOSTA-DB-UPDATE-1 */
        public void M_0580_00_DECLINA_PROPOSTA_DB_UPDATE_1()
        {
            /*" -4197- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :PROPOFID-SIT-PROPOSTA , SITUACAO_ENVIO = :PROPOFID-SITUACAO-ENVIO , COD_USUARIO = 'VA0118B' WHERE NUM_PROPOSTA_SIVPF = :PROPVA-NRCERTIF END-EXEC */

            var m_0580_00_DECLINA_PROPOSTA_DB_UPDATE_1_Update1 = new M_0580_00_DECLINA_PROPOSTA_DB_UPDATE_1_Update1()
            {
                PROPOFID_SITUACAO_ENVIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO.ToString(),
                PROPOFID_SIT_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_0580_00_DECLINA_PROPOSTA_DB_UPDATE_1_Update1.Execute(m_0580_00_DECLINA_PROPOSTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0580_99_SAIDA*/

        [StopWatch]
        /*" M-0590-00-ATUALIZA-PROPOSTAS-VA-SECTION */
        private void M_0590_00_ATUALIZA_PROPOSTAS_VA_SECTION()
        {
            /*" -4218- MOVE '0590-00-ATUALIZA-PROPOSTAS-VA  ' TO PARAGRAFO */
            _.Move("0590-00-ATUALIZA-PROPOSTAS-VA  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4219- MOVE 'ATUALIZA PROPOSTAS_VA          ' TO COMANDO */
            _.Move("ATUALIZA PROPOSTAS_VA          ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4221- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4222- MOVE '2' TO PROPVA-SITUACAO */
            _.Move("2", PROPVA_SITUACAO);

            /*" -4224- MOVE ZEROS TO VIND-DATA-DECLINIO */
            _.Move(0, VIND_DATA_DECLINIO);

            /*" -4230- PERFORM M_0590_00_ATUALIZA_PROPOSTAS_VA_DB_UPDATE_1 */

            M_0590_00_ATUALIZA_PROPOSTAS_VA_DB_UPDATE_1();

            /*" -4233- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4234- ADD 1 TO AC-DECLIN-PROPVA */
                WS_WORK_AREAS.AC_DECLIN_PROPVA.Value = WS_WORK_AREAS.AC_DECLIN_PROPVA + 1;

                /*" -4235- ELSE */
            }
            else
            {


                /*" -4236- DISPLAY 'VA0118B - PROBLEMAS NO UPDATE PROPOSTAS_VA' */
                _.Display($"VA0118B - PROBLEMAS NO UPDATE PROPOSTAS_VA");

                /*" -4238- DISPLAY ' NUM-CERTIFICADO.......   ' PROPVA-NRCERTIF */
                _.Display($" NUM-CERTIFICADO.......   {PROPVA_NRCERTIF}");

                /*" -4240- DISPLAY ' SQLCODE...............   ' SQLCODE */
                _.Display($" SQLCODE...............   {DB.SQLCODE}");

                /*" -4241- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -4243- END-IF */
            }


            /*" -4243- . */

        }

        [StopWatch]
        /*" M-0590-00-ATUALIZA-PROPOSTAS-VA-DB-UPDATE-1 */
        public void M_0590_00_ATUALIZA_PROPOSTAS_VA_DB_UPDATE_1()
        {
            /*" -4230- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_REGISTRO = :PROPVA-SITUACAO , COD_USUARIO = 'VA0118B' , DTA_DECLINIO = :SISTEMA-DTMOVABE WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC */

            var m_0590_00_ATUALIZA_PROPOSTAS_VA_DB_UPDATE_1_Update1 = new M_0590_00_ATUALIZA_PROPOSTAS_VA_DB_UPDATE_1_Update1()
            {
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                PROPVA_SITUACAO = PROPVA_SITUACAO.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_0590_00_ATUALIZA_PROPOSTAS_VA_DB_UPDATE_1_Update1.Execute(m_0590_00_ATUALIZA_PROPOSTAS_VA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0590_99_SAIDA*/

        [StopWatch]
        /*" M-0600-00-INSERE-ANDAMENTO-SECTION */
        private void M_0600_00_INSERE_ANDAMENTO_SECTION()
        {
            /*" -4251- MOVE '0600-00-INSERE-ANDAMENTO ' TO PARAGRAFO */
            _.Move("0600-00-INSERE-ANDAMENTO ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4252- MOVE 'INSERT VG_ANDAMENTO_PROP ' TO COMANDO */
            _.Move("INSERT VG_ANDAMENTO_PROP ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4254- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4255- MOVE PROPVA-NRCERTIF TO VG078-NUM-CERTIFICADO */
            _.Move(PROPVA_NRCERTIF, VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO);

            /*" -4257- MOVE 61 TO VG078-DES-ANDAMENTO-LEN */
            _.Move(61, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_LEN);

            /*" -4259- MOVE 'VA0118B' TO VG078-COD-USUARIO */
            _.Move("VA0118B", VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO);

            /*" -4274- PERFORM M_0600_00_INSERE_ANDAMENTO_DB_INSERT_1 */

            M_0600_00_INSERE_ANDAMENTO_DB_INSERT_1();

            /*" -4277- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4278- CONTINUE */

                /*" -4279- ELSE */
            }
            else
            {


                /*" -4280- DISPLAY 'VA0118B - PROBLEMAS NO INSERT VG_ANDAMENTO_PROP' */
                _.Display($"VA0118B - PROBLEMAS NO INSERT VG_ANDAMENTO_PROP");

                /*" -4281- DISPLAY 'NUM-CERTIFICADO = ' VG078-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO = {VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO}");

                /*" -4282- DISPLAY 'SQLCODE         = ' SQLCODE */
                _.Display($"SQLCODE         = {DB.SQLCODE}");

                /*" -4283- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -4285- END-IF */
            }


            /*" -4285- . */

        }

        [StopWatch]
        /*" M-0600-00-INSERE-ANDAMENTO-DB-INSERT-1 */
        public void M_0600_00_INSERE_ANDAMENTO_DB_INSERT_1()
        {
            /*" -4274- EXEC SQL INSERT INTO SEGUROS.VG_ANDAMENTO_PROP ( NUM_CERTIFICADO , DTH_CADASTRAMENTO , DES_ANDAMENTO , COD_USUARIO ) VALUES ( :VG078-NUM-CERTIFICADO , CURRENT TIMESTAMP , :VG078-DES-ANDAMENTO , :VG078-COD-USUARIO ) END-EXEC */

            var m_0600_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1 = new M_0600_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1()
            {
                VG078_NUM_CERTIFICADO = VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO.ToString(),
                VG078_DES_ANDAMENTO = VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.ToString(),
                VG078_COD_USUARIO = VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO.ToString(),
            };

            M_0600_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1.Execute(m_0600_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0600_99_SAIDA*/

        [StopWatch]
        /*" M-1000-INTEGRA-MULTIPREMIADO-SECTION */
        private void M_1000_INTEGRA_MULTIPREMIADO_SECTION()
        {
            /*" -4368- MOVE '1000-INTEGRA-MULTIPREMIADO' TO PARAGRAFO */
            _.Move("1000-INTEGRA-MULTIPREMIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4372- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4373- MOVE PROPVA-DTQITBCO TO W01DTSQL. */
            _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);

            /*" -4379- MOVE W01DTSQL TO MDTMOVTO. */
            _.Move(WS_WORK_AREAS.W01DTSQL, MDTMOVTO);

            /*" -4380- IF PROPVA-DTPROXVEN < PROPVA-DTMINVEN */

            if (PROPVA_DTPROXVEN < PROPVA_DTMINVEN)
            {

                /*" -4381- MOVE PROPVA-DTPROXVEN TO W01DTSQL */
                _.Move(PROPVA_DTPROXVEN, WS_WORK_AREAS.W01DTSQL);

                /*" -4382- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -4383- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -4384- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -4385- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -4386- END-IF */
                }


                /*" -4387- IF W01DDSQL > WS-ULTDIA (W01MMSQL) */

                if (WS_WORK_AREAS.W01DTSQL_R.W01DDSQL > WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL])
                {

                    /*" -4388- MOVE WS-ULTDIA (W01MMSQL) TO W01DDSQL */
                    _.Move(WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL], WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

                    /*" -4389- END-IF */
                }


                /*" -4389- MOVE W01DTSQL TO PROPVA-DTPROXVEN. */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);
            }


            /*" -0- FLUXCONTROL_PERFORM M_1000_AJUSTA_DTPROXVEN */

            M_1000_AJUSTA_DTPROXVEN();

        }

        [StopWatch]
        /*" M-1000-AJUSTA-DTPROXVEN */
        private void M_1000_AJUSTA_DTPROXVEN(bool isPerform = false)
        {
            /*" -4398- IF PROPVA-DTPROXVEN < W04DTSQL */

            if (PROPVA_DTPROXVEN < WS_WORK_AREAS.W04DTSQL)
            {

                /*" -4399- MOVE PROPVA-DTPROXVEN TO W01DTSQL */
                _.Move(PROPVA_DTPROXVEN, WS_WORK_AREAS.W01DTSQL);

                /*" -4400- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -4401- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -4402- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -4403- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -4404- END-IF */
                }


                /*" -4405- IF W01DDSQL > WS-ULTDIA (W01MMSQL) */

                if (WS_WORK_AREAS.W01DTSQL_R.W01DDSQL > WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL])
                {

                    /*" -4406- MOVE WS-ULTDIA (W01MMSQL) TO W01DDSQL */
                    _.Move(WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL], WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

                    /*" -4407- END-IF */
                }


                /*" -4408- MOVE W01DTSQL TO PROPVA-DTPROXVEN */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

                /*" -4410- GO TO 1000-AJUSTA-DTPROXVEN. */
                new Task(() => M_1000_AJUSTA_DTPROXVEN()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -4412- MOVE 0 TO MAGENCIADOR MNUM-MATRICULA. */
            _.Move(0, MAGENCIADOR, MNUM_MATRICULA);

            /*" -4414- MOVE '4' TO MTPINCLUS. */
            _.Move("4", MTPINCLUS);

            /*" -4414- PERFORM 8000-INTEGRA-VG THRU 8000-FIM. */

            M_8000_INTEGRA_VG_SECTION();

            R8000_PROPAUTOM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-1100-INTEGRA-VIDAZUL-SECTION */
        private void M_1100_INTEGRA_VIDAZUL_SECTION()
        {
            /*" -4426- MOVE '1100-INTEGRA-VIDAZUL' TO PARAGRAFO */
            _.Move("1100-INTEGRA-VIDAZUL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4430- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4434- MOVE PROPVA-DTQITBCO TO MDTMOVTO WS-VIGENCIA. */
            _.Move(PROPVA_DTQITBCO, MDTMOVTO, WS_WORK_AREAS.WS_VIGENCIA);

            /*" -4435- IF OPCAOP-PERIPGTO GREATER 12 */

            if (OPCAOP_PERIPGTO > 12)
            {

                /*" -4436- COMPUTE WS-QTDE-ANOS = OPCAOP-PERIPGTO / 12 */
                WS_WORK_AREAS.WS_QTDE_ANOS.Value = OPCAOP_PERIPGTO / 12;

                /*" -4437- COMPUTE WS-VIG-ANO = WS-VIG-ANO + WS-QTDE-ANOS */
                WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_ANO.Value = WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_ANO + WS_WORK_AREAS.WS_QTDE_ANOS;

                /*" -4438- ELSE */
            }
            else
            {


                /*" -4439- IF WS-VIG-MES GREATER 12 */

                if (WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_MES > 12)
                {

                    /*" -4440- SUBTRACT 12 FROM WS-VIG-MES */
                    WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_MES.Value = WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_MES - 12;

                    /*" -4441- ADD 1 TO WS-VIG-ANO */
                    WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_ANO.Value = WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_ANO + 1;

                    /*" -4442- END-IF */
                }


                /*" -4444- END-IF. */
            }


            /*" -4445- MOVE WS-VIGENCIA TO WS-VIGENCIA1. */
            _.Move(WS_WORK_AREAS.WS_VIGENCIA, WS_WORK_AREAS.WS_VIGENCIA1);

            /*" -4447- MOVE OPCAOP-DIA-DEB TO WS-VIG-DIA1. */
            _.Move(OPCAOP_DIA_DEB, WS_WORK_AREAS.WS_VIGENCIA1.WS_VIG_DIA1);

            /*" -4448- IF WS-VIGENCIA1 LESS WS-VIGENCIA */

            if (WS_WORK_AREAS.WS_VIGENCIA1 < WS_WORK_AREAS.WS_VIGENCIA)
            {

                /*" -4449- ADD 1 TO WS-VIG-MES */
                WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_MES.Value = WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_MES + 1;

                /*" -4450- IF WS-VIG-MES GREATER 12 */

                if (WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_MES > 12)
                {

                    /*" -4451- MOVE 1 TO WS-VIG-MES */
                    _.Move(1, WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_MES);

                    /*" -4453- ADD 1 TO WS-VIG-ANO. */
                    WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_ANO.Value = WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_ANO + 1;
                }

            }


            /*" -4454- MOVE OPCAOP-DIA-DEB TO WS-VIG-DIA. */
            _.Move(OPCAOP_DIA_DEB, WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_DIA);

            /*" -4459- MOVE WS-VIGENCIA TO PROPVA-DTPROXVEN. */
            _.Move(WS_WORK_AREAS.WS_VIGENCIA, PROPVA_DTPROXVEN);

            /*" -0- FLUXCONTROL_PERFORM M_1100_AJUSTA_DTPROXVEN */

            M_1100_AJUSTA_DTPROXVEN();

        }

        [StopWatch]
        /*" M-1100-AJUSTA-DTPROXVEN */
        private void M_1100_AJUSTA_DTPROXVEN(bool isPerform = false)
        {
            /*" -4463- IF PROPVA-DTPROXVEN < W04DTSQL */

            if (PROPVA_DTPROXVEN < WS_WORK_AREAS.W04DTSQL)
            {

                /*" -4464- MOVE PROPVA-DTPROXVEN TO W01DTSQL */
                _.Move(PROPVA_DTPROXVEN, WS_WORK_AREAS.W01DTSQL);

                /*" -4465- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -4466- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -4467- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -4468- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -4469- END-IF */
                }


                /*" -4470- IF W01DDSQL > WS-ULTDIA (W01MMSQL) */

                if (WS_WORK_AREAS.W01DTSQL_R.W01DDSQL > WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL])
                {

                    /*" -4471- MOVE WS-ULTDIA (W01MMSQL) TO W01DDSQL */
                    _.Move(WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL], WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

                    /*" -4472- END-IF */
                }


                /*" -4473- MOVE W01DTSQL TO PROPVA-DTPROXVEN */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

                /*" -4475- GO TO 1100-AJUSTA-DTPROXVEN. */
                new Task(() => M_1100_AJUSTA_DTPROXVEN()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -4477- MOVE 0 TO MAGENCIADOR MNUM-MATRICULA. */
            _.Move(0, MAGENCIADOR, MNUM_MATRICULA);

            /*" -4479- MOVE '4' TO MTPINCLUS. */
            _.Move("4", MTPINCLUS);

            /*" -4480- PERFORM 8000-INTEGRA-VG THRU 8000-FIM. */

            M_8000_INTEGRA_VG_SECTION();

            R8000_PROPAUTOM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/

        [StopWatch]
        /*" M-1110-VERIFICA-RCAP-SECTION */
        private void M_1110_VERIFICA_RCAP_SECTION()
        {
            /*" -4487- MOVE '1110-VERIFICA-RCAP  ' TO PARAGRAFO */
            _.Move("1110-VERIFICA-RCAP  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4489- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4491- MOVE SPACES TO WFIM-V1RCAP. */
            _.Move("", WS_WORK_AREAS.WFIM_V1RCAP);

            /*" -4493- MOVE PROPVA-NRCERTIF TO CONVER-NUM-PROPOSTA. */
            _.Move(PROPVA_NRCERTIF, CONVER_NUM_PROPOSTA);

            /*" -4495- MOVE 'SELECT CONVERSAO SICOB' TO COMANDO. */
            _.Move("SELECT CONVERSAO SICOB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4501- PERFORM M_1110_VERIFICA_RCAP_DB_SELECT_1 */

            M_1110_VERIFICA_RCAP_DB_SELECT_1();

            /*" -4504- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4505- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4506- MOVE PROPVA-NRCERTIF TO V0RCAP-NRTIT */
                    _.Move(PROPVA_NRCERTIF, V0RCAP_NRTIT);

                    /*" -4507- MOVE PROPVA-NRCERTIF TO V0RCAP-NRCERTIF */
                    _.Move(PROPVA_NRCERTIF, V0RCAP_NRCERTIF);

                    /*" -4508- ELSE */
                }
                else
                {


                    /*" -4509- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4510- ELSE */
                }

            }
            else
            {


                /*" -4511- MOVE CONVER-NUM-SICOB TO V0RCAP-NRTIT */
                _.Move(CONVER_NUM_SICOB, V0RCAP_NRTIT);

                /*" -4513- MOVE CONVER-NUM-PROPOSTA TO V0RCAP-NRCERTIF. */
                _.Move(CONVER_NUM_PROPOSTA, V0RCAP_NRCERTIF);
            }


            /*" -4515- MOVE 'SELECT V0RCAP        ' TO COMANDO. */
            _.Move("SELECT V0RCAP        ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4526- PERFORM M_1110_VERIFICA_RCAP_DB_SELECT_2 */

            M_1110_VERIFICA_RCAP_DB_SELECT_2();

            /*" -4529- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4530- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4531- GO TO 1110-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1110_FIM*/ //GOTO
                    return;

                    /*" -4532- ELSE */
                }
                else
                {


                    /*" -4534- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4536- MOVE 'SELECT V1RCAPCOMP    ' TO COMANDO. */
            _.Move("SELECT V1RCAPCOMP    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4552- PERFORM M_1110_VERIFICA_RCAP_DB_SELECT_3 */

            M_1110_VERIFICA_RCAP_DB_SELECT_3();

            /*" -4555- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4557- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4559- PERFORM 1120-BAIXA-RCAP THRU 1120-FIM. */

            M_1120_BAIXA_RCAP_SECTION();

            M_1120_DECLARE_V0RCAPCOMP();

            M_1120_FETCH_V0RCAPCOMP();

            M_1120_UPDATE_V0RCAPCOMP();

            M_1120_INSERT_V0RCAPCOMP();

            M_1120_UPDATE_V0AVISOSALDO();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1120_FIM*/


            /*" -4561- MOVE 'UPDATE V0RCAP        ' TO COMANDO. */
            _.Move("UPDATE V0RCAP        ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4571- PERFORM M_1110_VERIFICA_RCAP_DB_UPDATE_1 */

            M_1110_VERIFICA_RCAP_DB_UPDATE_1();

            /*" -4574- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4575- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1110-VERIFICA-RCAP-DB-SELECT-1 */
        public void M_1110_VERIFICA_RCAP_DB_SELECT_1()
        {
            /*" -4501- EXEC SQL SELECT NUM_SICOB INTO :CONVER-NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :CONVER-NUM-PROPOSTA WITH UR END-EXEC. */

            var m_1110_VERIFICA_RCAP_DB_SELECT_1_Query1 = new M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1()
            {
                CONVER_NUM_PROPOSTA = CONVER_NUM_PROPOSTA.ToString(),
            };

            var executed_1 = M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1.Execute(m_1110_VERIFICA_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVER_NUM_SICOB, CONVER_NUM_SICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1110_FIM*/

        [StopWatch]
        /*" M-1110-VERIFICA-RCAP-DB-SELECT-2 */
        public void M_1110_VERIFICA_RCAP_DB_SELECT_2()
        {
            /*" -4526- EXEC SQL SELECT FONTE, NRRCAP INTO :V0RCAP-FONTE, :V0RCAP-NRRCAP FROM SEGUROS.V0RCAP WHERE (NRTIT = :V0RCAP-NRTIT OR NRCERTIF = :V0RCAP-NRCERTIF) AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO = '0' END-EXEC. */

            var m_1110_VERIFICA_RCAP_DB_SELECT_2_Query1 = new M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1()
            {
                V0RCAP_NRCERTIF = V0RCAP_NRCERTIF.ToString(),
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
            };

            var executed_1 = M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1.Execute(m_1110_VERIFICA_RCAP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_FONTE, V0RCAP_FONTE);
                _.Move(executed_1.V0RCAP_NRRCAP, V0RCAP_NRRCAP);
            }


        }

        [StopWatch]
        /*" M-1110-VERIFICA-RCAP-DB-UPDATE-1 */
        public void M_1110_VERIFICA_RCAP_DB_UPDATE_1()
        {
            /*" -4571- EXEC SQL UPDATE SEGUROS.V0RCAP SET SITUACAO = '1' , OPERACAO = 220 , NUM_APOLICE = :PROPVA-NUM-APOLICE, NRENDOS = 0, NRPARCEL = 0, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC. */

            var m_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1 = new M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1.Execute(m_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1120-BAIXA-RCAP-SECTION */
        private void M_1120_BAIXA_RCAP_SECTION()
        {
            /*" -4582- MOVE '1120-BAIXA-RCAP      ' TO PARAGRAFO */
            _.Move("1120-BAIXA-RCAP      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4583- MOVE 'DECLARE V1RCAPCOMP   ' TO COMANDO. */
            _.Move("DECLARE V1RCAPCOMP   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4584- DISPLAY PARAGRAFO. */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -0- FLUXCONTROL_PERFORM M_1120_DECLARE_V0RCAPCOMP */

            M_1120_DECLARE_V0RCAPCOMP();

        }

        [StopWatch]
        /*" M-1110-VERIFICA-RCAP-DB-SELECT-3 */
        public void M_1110_VERIFICA_RCAP_DB_SELECT_3()
        {
            /*" -4552- EXEC SQL SELECT BCOAVISO , AGEAVISO , NRAVISO , DATARCAP INTO :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-DATARCAP FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP AND NRRCAPCO = 0 AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO = '0' END-EXEC. */

            var m_1110_VERIFICA_RCAP_DB_SELECT_3_Query1 = new M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1()
            {
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            var executed_1 = M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1.Execute(m_1110_VERIFICA_RCAP_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RCAC_BCOAVISO, V1RCAC_BCOAVISO);
                _.Move(executed_1.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(executed_1.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
                _.Move(executed_1.V1RCAC_DATARCAP, V1RCAC_DATARCAP);
            }


        }

        [StopWatch]
        /*" M-1120-DECLARE-V0RCAPCOMP */
        private void M_1120_DECLARE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -4608- PERFORM M_1120_DECLARE_V0RCAPCOMP_DB_DECLARE_1 */

            M_1120_DECLARE_V0RCAPCOMP_DB_DECLARE_1();

            /*" -4610- PERFORM M_1120_DECLARE_V0RCAPCOMP_DB_OPEN_1 */

            M_1120_DECLARE_V0RCAPCOMP_DB_OPEN_1();

            /*" -4613- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4614- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1120-DECLARE-V0RCAPCOMP-DB-OPEN-1 */
        public void M_1120_DECLARE_V0RCAPCOMP_DB_OPEN_1()
        {
            /*" -4610- EXEC SQL OPEN V1RCAPCOMP END-EXEC. */

            V1RCAPCOMP.Open();

        }

        [StopWatch]
        /*" M-8100-MONTA-BENEFICIARIOS-DB-DECLARE-1 */
        public void M_8100_MONTA_BENEFICIARIOS_DB_DECLARE_1()
        {
            /*" -6237- EXEC SQL DECLARE CBENEFP CURSOR FOR SELECT NOMBENEF, GRAUPAR, PCTBENEF FROM SEGUROS.V0BENEFPROPAZ WHERE NRPROPAZ = :PROPVA-NRPROPAZ AND AGELOTE = 0 AND DTLOTE = 0 AND NRLOTE = 0 AND NRSEQLOTE = 0 WITH UR END-EXEC. */
            CBENEFP = new VA0118B_CBENEFP(true);
            string GetQuery_CBENEFP()
            {
                var query = @$"SELECT NOMBENEF
							, 
							GRAUPAR
							, 
							PCTBENEF 
							FROM SEGUROS.V0BENEFPROPAZ 
							WHERE NRPROPAZ = '{PROPVA_NRPROPAZ}' 
							AND AGELOTE = 0 
							AND DTLOTE = 0 
							AND NRLOTE = 0 
							AND NRSEQLOTE = 0";

                return query;
            }
            CBENEFP.GetQueryEvent += GetQuery_CBENEFP;

        }

        [StopWatch]
        /*" M-1120-FETCH-V0RCAPCOMP */
        private void M_1120_FETCH_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -4618- MOVE 'FETCH V1VCAPCOMP     ' TO COMANDO. */
            _.Move("FETCH V1VCAPCOMP     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4620- DISPLAY COMANDO */
            _.Display(WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4635- PERFORM M_1120_FETCH_V0RCAPCOMP_DB_FETCH_1 */

            M_1120_FETCH_V0RCAPCOMP_DB_FETCH_1();

            /*" -4638- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4639- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4639- PERFORM M_1120_FETCH_V0RCAPCOMP_DB_CLOSE_1 */

                    M_1120_FETCH_V0RCAPCOMP_DB_CLOSE_1();

                    /*" -4641- GO TO 1120-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1120_FIM*/ //GOTO
                    return;

                    /*" -4642- ELSE */
                }
                else
                {


                    /*" -4643- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-1120-FETCH-V0RCAPCOMP-DB-FETCH-1 */
        public void M_1120_FETCH_V0RCAPCOMP_DB_FETCH_1()
        {
            /*" -4635- EXEC SQL FETCH V1RCAPCOMP INTO :V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1RCAC-DTMOVTO , :V1RCAC-HORAOPER , :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB END-EXEC. */

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
        /*" M-1120-FETCH-V0RCAPCOMP-DB-CLOSE-1 */
        public void M_1120_FETCH_V0RCAPCOMP_DB_CLOSE_1()
        {
            /*" -4639- EXEC SQL CLOSE V1RCAPCOMP END-EXEC */

            V1RCAPCOMP.Close();

        }

        [StopWatch]
        /*" M-1120-UPDATE-V0RCAPCOMP */
        private void M_1120_UPDATE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -4647- MOVE 'UPDATE V0RCAPCOMP    ' TO COMANDO. */
            _.Move("UPDATE V0RCAPCOMP    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4649- DISPLAY COMANDO */
            _.Display(WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4659- PERFORM M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1 */

            M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1();

            /*" -4662- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4663- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1120-UPDATE-V0RCAPCOMP-DB-UPDATE-1 */
        public void M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1()
        {
            /*" -4659- EXEC SQL UPDATE SEGUROS.V0RCAPCOMP SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1RCAC-FONTE AND NRRCAP = :V1RCAC-NRRCAP AND NRRCAPCO = :V1RCAC-NRRCAPCO AND OPERACAO = :V1RCAC-OPERACAO AND DTMOVTO = :V1RCAC-DTMOVTO AND HORAOPER = :V1RCAC-HORAOPER END-EXEC. */

            var m_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1 = new M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1()
            {
                V1RCAC_NRRCAPCO = V1RCAC_NRRCAPCO.ToString(),
                V1RCAC_OPERACAO = V1RCAC_OPERACAO.ToString(),
                V1RCAC_HORAOPER = V1RCAC_HORAOPER.ToString(),
                V1RCAC_DTMOVTO = V1RCAC_DTMOVTO.ToString(),
                V1RCAC_NRRCAP = V1RCAC_NRRCAP.ToString(),
                V1RCAC_FONTE = V1RCAC_FONTE.ToString(),
            };

            M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1.Execute(m_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1120-INSERT-V0RCAPCOMP */
        private void M_1120_INSERT_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -4668- MOVE 'INSERT V0RCAPCOMP    ' TO COMANDO. */
            _.Move("INSERT V0RCAPCOMP    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4669- MOVE '0' TO V1RCAC-SITCONTB */
            _.Move("0", V1RCAC_SITCONTB);

            /*" -4670- MOVE '0' TO V1RCAC-SITUACAO */
            _.Move("0", V1RCAC_SITUACAO);

            /*" -4672- MOVE 220 TO V1RCAC-OPERACAO */
            _.Move(220, V1RCAC_OPERACAO);

            /*" -4690- PERFORM M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1 */

            M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1();

            /*" -4693- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4694- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1120-INSERT-V0RCAPCOMP-DB-INSERT-1 */
        public void M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -4690- EXEC SQL INSERT INTO SEGUROS.V0RCAPCOMP VALUES (:V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :SISTEMA-DTMOVABE , CURRENT TIME, :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB , :V1RCAC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var m_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 = new M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1()
            {
                V1RCAC_FONTE = V1RCAC_FONTE.ToString(),
                V1RCAC_NRRCAP = V1RCAC_NRRCAP.ToString(),
                V1RCAC_NRRCAPCO = V1RCAC_NRRCAPCO.ToString(),
                V1RCAC_OPERACAO = V1RCAC_OPERACAO.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
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

            M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1.Execute(m_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-1120-UPDATE-V0AVISOSALDO */
        private void M_1120_UPDATE_V0AVISOSALDO(bool isPerform = false)
        {
            /*" -4698- MOVE 'UPDATE V0AVISOSALDO  ' TO COMANDO. */
            _.Move("UPDATE V0AVISOSALDO  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4700- DISPLAY COMANDO */
            _.Display(WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4707- PERFORM M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1 */

            M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1();

            /*" -4711- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -4713- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4713- GO TO 1120-FETCH-V0RCAPCOMP. */

            M_1120_FETCH_V0RCAPCOMP(); //GOTO
            return;

        }

        [StopWatch]
        /*" M-1120-UPDATE-V0AVISOSALDO-DB-UPDATE-1 */
        public void M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1()
        {
            /*" -4707- EXEC SQL UPDATE SEGUROS.V0AVISOS_SALDOS SET SDOATU = (SDOATU - :V1RCAC-VLRCAP) WHERE BCOAVISO = :V1RCAC-BCOAVISO AND AGEAVISO = :V1RCAC-AGEAVISO AND NRAVISO = :V1RCAC-NRAVISO END-EXEC. */

            var m_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1 = new M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1()
            {
                V1RCAC_VLRCAP = V1RCAC_VLRCAP.ToString(),
                V1RCAC_BCOAVISO = V1RCAC_BCOAVISO.ToString(),
                V1RCAC_AGEAVISO = V1RCAC_AGEAVISO.ToString(),
                V1RCAC_NRAVISO = V1RCAC_NRAVISO.ToString(),
            };

            M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1.Execute(m_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1120_FIM*/

        [StopWatch]
        /*" M-1500-SELECT-PRODUTOSVG-SECTION */
        private void M_1500_SELECT_PRODUTOSVG_SECTION()
        {
            /*" -4721- MOVE '1500-SELECT V0PRODUTOSVG' TO PARAGRAFO */
            _.Move("1500-SELECT V0PRODUTOSVG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4722- MOVE 'SELECT V0PRODUTOSVG     ' TO COMANDO */
            _.Move("SELECT V0PRODUTOSVG     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4724- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4759- PERFORM M_1500_SELECT_PRODUTOSVG_DB_SELECT_1 */

            M_1500_SELECT_PRODUTOSVG_DB_SELECT_1();

            /*" -4762- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4764- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4765- MOVE PRODVG-CUSTOCAP-TOTAL TO PRODVG-CUSTOCAP-TOTAL-A */
            _.Move(PRODVG_CUSTOCAP_TOTAL, WS_WORK_AREAS.PRODVG_CUSTOCAP_TOTAL_A);

            /*" -4765- MOVE PRODVG-CUSTOCAP-TOTAL-N TO PRODVG-CUSTOCAP-TOTAL-9. */
            _.Move(WS_WORK_AREAS.PRODVG_CUSTOCAP_TOTAL_N, PRODVG_CUSTOCAP_TOTAL_9);

        }

        [StopWatch]
        /*" M-1500-SELECT-PRODUTOSVG-DB-SELECT-1 */
        public void M_1500_SELECT_PRODUTOSVG_DB_SELECT_1()
        {
            /*" -4759- EXEC SQL SELECT CODPRODAZ, ESTR_COBR, ORIG_PRODU, COD_AGENCIADOR, TEM_SAF, TEM_CDG, CODRELAT, COBERADIC_PREMIO, CUSTOCAP_TOTAL, DESCONTO_ADESAO, CODPRODU, VALUE(RISCO, '1' ), SITPLANCEF , ARQ_FDCAP, RAMO INTO :PRODVG-CODPRODAZ, :PRODVG-ESTR-COBR :VIND-ESTR-COBR , :PRODVG-ORIG-PRODU:VIND-ORIG-PRODU, :PRODVG-AGENCIADOR:VIND-AGENCIADOR, :PRODVG-TEM-SAF:VIND-TEM-SAF, :PRODVG-TEM-CDG:VIND-TEM-CDG, :PRODVG-CODRELAT:VIND-CODRELAT, :PRODVG-COBERADIC-PREMIO, :PRODVG-CUSTOCAP-TOTAL, :PRODVG-DESCONTO-ADESAO, :PRODVG-COD-PRODUTO, :PRODVG-RISCO, :PRODVG-SITPLANCEF, :PRODVG-ARQ-FDCAP:WS-IND-ARQFDCAP, :PRODVG-RAMO FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES WITH UR END-EXEC. */

            var m_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1 = new M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1.Execute(m_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODVG_CODPRODAZ, PRODVG_CODPRODAZ);
                _.Move(executed_1.PRODVG_ESTR_COBR, PRODVG_ESTR_COBR);
                _.Move(executed_1.VIND_ESTR_COBR, VIND_ESTR_COBR);
                _.Move(executed_1.PRODVG_ORIG_PRODU, PRODVG_ORIG_PRODU);
                _.Move(executed_1.VIND_ORIG_PRODU, VIND_ORIG_PRODU);
                _.Move(executed_1.PRODVG_AGENCIADOR, PRODVG_AGENCIADOR);
                _.Move(executed_1.VIND_AGENCIADOR, VIND_AGENCIADOR);
                _.Move(executed_1.PRODVG_TEM_SAF, PRODVG_TEM_SAF);
                _.Move(executed_1.VIND_TEM_SAF, VIND_TEM_SAF);
                _.Move(executed_1.PRODVG_TEM_CDG, PRODVG_TEM_CDG);
                _.Move(executed_1.VIND_TEM_CDG, VIND_TEM_CDG);
                _.Move(executed_1.PRODVG_CODRELAT, PRODVG_CODRELAT);
                _.Move(executed_1.VIND_CODRELAT, VIND_CODRELAT);
                _.Move(executed_1.PRODVG_COBERADIC_PREMIO, PRODVG_COBERADIC_PREMIO);
                _.Move(executed_1.PRODVG_CUSTOCAP_TOTAL, PRODVG_CUSTOCAP_TOTAL);
                _.Move(executed_1.PRODVG_DESCONTO_ADESAO, PRODVG_DESCONTO_ADESAO);
                _.Move(executed_1.PRODVG_COD_PRODUTO, PRODVG_COD_PRODUTO);
                _.Move(executed_1.PRODVG_RISCO, PRODVG_RISCO);
                _.Move(executed_1.PRODVG_SITPLANCEF, PRODVG_SITPLANCEF);
                _.Move(executed_1.PRODVG_ARQ_FDCAP, PRODVG_ARQ_FDCAP);
                _.Move(executed_1.WS_IND_ARQFDCAP, WS_IND_ARQFDCAP);
                _.Move(executed_1.PRODVG_RAMO, PRODVG_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/

        [StopWatch]
        /*" M-2000-INTEGRA-EMPRESA-GLOBAL-SECTION */
        private void M_2000_INTEGRA_EMPRESA_GLOBAL_SECTION()
        {
            /*" -4777- MOVE '2000-INTEGRA-EMPRESA-GLOBAL' TO PARAGRAFO */
            _.Move("2000-INTEGRA-EMPRESA-GLOBAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4781- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4782- MOVE PROPVA-DTQITBCO TO W01DTSQL. */
            _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);

            /*" -4783- IF W01DDSQL < 16 */

            if (WS_WORK_AREAS.W01DTSQL_R.W01DDSQL < 16)
            {

                /*" -4784- MOVE 01 TO W01DDSQL */
                _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

                /*" -4785- ELSE */
            }
            else
            {


                /*" -4787- MOVE 15 TO W01DDSQL. */
                _.Move(15, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);
            }


            /*" -4788- ADD 1 TO W01MMSQL. */
            WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

            /*" -4789- IF W01MMSQL > 12 */

            if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
            {

                /*" -4790- MOVE 01 TO W01MMSQL */
                _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                /*" -4792- COMPUTE W01AASQL = W01AASQL + 1. */
                WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;
            }


            /*" -4798- MOVE W01DTSQL TO MDTMOVTO. */
            _.Move(WS_WORK_AREAS.W01DTSQL, MDTMOVTO);

            /*" -4799- IF PROPVA-DTPROXVEN < PROPVA-DTMINVEN */

            if (PROPVA_DTPROXVEN < PROPVA_DTMINVEN)
            {

                /*" -4800- MOVE PROPVA-DTPROXVEN TO W01DTSQL */
                _.Move(PROPVA_DTPROXVEN, WS_WORK_AREAS.W01DTSQL);

                /*" -4801- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -4802- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -4803- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -4804- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -4805- END-IF */
                }


                /*" -4806- IF W01DDSQL > WS-ULTDIA (W01MMSQL) */

                if (WS_WORK_AREAS.W01DTSQL_R.W01DDSQL > WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL])
                {

                    /*" -4807- MOVE WS-ULTDIA (W01MMSQL) TO W01DDSQL */
                    _.Move(WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL], WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

                    /*" -4808- END-IF */
                }


                /*" -4808- MOVE W01DTSQL TO PROPVA-DTPROXVEN. */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);
            }


            /*" -0- FLUXCONTROL_PERFORM M_2000_AJUSTA_DTPROXVEN */

            M_2000_AJUSTA_DTPROXVEN();

        }

        [StopWatch]
        /*" M-2000-AJUSTA-DTPROXVEN */
        private void M_2000_AJUSTA_DTPROXVEN(bool isPerform = false)
        {
            /*" -4817- IF PROPVA-DTPROXVEN < W04DTSQL */

            if (PROPVA_DTPROXVEN < WS_WORK_AREAS.W04DTSQL)
            {

                /*" -4818- MOVE PROPVA-DTPROXVEN TO W01DTSQL */
                _.Move(PROPVA_DTPROXVEN, WS_WORK_AREAS.W01DTSQL);

                /*" -4819- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -4820- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -4821- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -4822- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -4823- END-IF */
                }


                /*" -4824- IF W01DDSQL > WS-ULTDIA (W01MMSQL) */

                if (WS_WORK_AREAS.W01DTSQL_R.W01DDSQL > WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL])
                {

                    /*" -4825- MOVE WS-ULTDIA (W01MMSQL) TO W01DDSQL */
                    _.Move(WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL], WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

                    /*" -4826- END-IF */
                }


                /*" -4827- MOVE W01DTSQL TO PROPVA-DTPROXVEN */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

                /*" -4829- GO TO 2000-AJUSTA-DTPROXVEN. */
                new Task(() => M_2000_AJUSTA_DTPROXVEN()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -4830- MOVE 'INSERT V0SUBGRUPO' TO COMANDO. */
            _.Move("INSERT V0SUBGRUPO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4832- DISPLAY COMANDO */
            _.Display(WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4833- COMPUTE SUBGRU-CODSUBES = SUBGRU-CODSUBES + 1. */
            SUBGRU_CODSUBES.Value = SUBGRU_CODSUBES + 1;

            /*" -4836- MOVE SUBGRU-CODSUBES TO PROPVA-CODSUBES. */
            _.Move(SUBGRU_CODSUBES, PROPVA_CODSUBES);

            /*" -4837- MOVE PROPVA-DTQITBCO TO W01DTSQL. */
            _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);

            /*" -4838- MOVE 01 TO W01DDSQL. */
            _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

            /*" -4840- MOVE W01DTSQL TO APCORR-DTINIVIG. */
            _.Move(WS_WORK_AREAS.W01DTSQL, APCORR_DTINIVIG);

            /*" -4842- MOVE 81 TO APCORR-RAMO. */
            _.Move(81, APCORR_RAMO);

            /*" -4844- PERFORM 2100-INCLUI-CORRETOR THRU 2100-FIM. */

            M_2100_INCLUI_CORRETOR_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2100_FIM*/


            /*" -4846- MOVE 93 TO APCORR-RAMO. */
            _.Move(93, APCORR_RAMO);

            /*" -4848- PERFORM 2100-INCLUI-CORRETOR THRU 2100-FIM. */

            M_2100_INCLUI_CORRETOR_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2100_FIM*/


            /*" -4850- MOVE 'SELECT V0PLANOSVA' TO COMANDO. */
            _.Move("SELECT V0PLANOSVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4866- PERFORM M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1 */

            M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1();

            /*" -4869- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4870- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -4872- END-IF */
            }


            /*" -4873- COMPUTE MTXAPIP = MTXAPMA / 2. */
            MTXAPIP.Value = MTXAPMA / 2f;

            /*" -4875- COMPUTE MTXAPMA = MTXAPMA - MTXAPIP. */
            MTXAPMA.Value = MTXAPMA - MTXAPIP;

            /*" -4877- MOVE 'INSERT V0CONDTEC' TO COMANDO. */
            _.Move("INSERT V0CONDTEC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4903- PERFORM M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1 */

            M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1();

            /*" -4906- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4906- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-2000-AJUSTA-DTPROXVEN-DB-SELECT-1 */
        public void M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1()
        {
            /*" -4866- EXEC SQL SELECT TAXAVG, TAXAAP INTO :MTXVG, :MTXAPMA FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND OPCAO_COBER = :PROPVA-OPCAO-COBER AND DTINIVIG <= :PROPVA-DTQITBCO AND DTTERVIG >= :PROPVA-DTQITBCO AND IDADE_INICIAL = 0 AND IDADE_FINAL = 0 AND PERIPGTO = :OPCAOP-PERIPGTO AND VLPREMIOTOT = :COBERP-VLPREMIO WITH UR END-EXEC. */

            var m_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1 = new M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_OPCAO_COBER = PROPVA_OPCAO_COBER.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                COBERP_VLPREMIO = COBERP_VLPREMIO.ToString(),
            };

            var executed_1 = M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1.Execute(m_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MTXVG, MTXVG);
                _.Move(executed_1.MTXAPMA, MTXAPMA);
            }


        }

        [StopWatch]
        /*" M-2000-AJUSTA-DTPROXVEN-DB-INSERT-1 */
        public void M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1()
        {
            /*" -4903- EXEC SQL INSERT INTO SEGUROS.V0CONDTEC VALUES (0109700000024, :PROPVA-CODSUBES, 0, 0, 0, :MTXAPMA, :MTXAPIP, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0) END-EXEC. */

            var m_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1 = new M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1()
            {
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                MTXAPMA = MTXAPMA.ToString(),
                MTXAPIP = MTXAPIP.ToString(),
            };

            M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1.Execute(m_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

        [StopWatch]
        /*" M-2100-INCLUI-CORRETOR-SECTION */
        private void M_2100_INCLUI_CORRETOR_SECTION()
        {
            /*" -4918- MOVE '2100-INCLUI-CORRETOR' TO PARAGRAFO. */
            _.Move("2100-INCLUI-CORRETOR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4919- MOVE 'INSERT V0APOLCORRET' TO COMANDO. */
            _.Move("INSERT V0APOLCORRET", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4921- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4937- PERFORM M_2100_INCLUI_CORRETOR_DB_INSERT_1 */

            M_2100_INCLUI_CORRETOR_DB_INSERT_1();

            /*" -4940- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4940- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-2100-INCLUI-CORRETOR-DB-INSERT-1 */
        public void M_2100_INCLUI_CORRETOR_DB_INSERT_1()
        {
            /*" -4937- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (0109700000024, :APCORR-RAMO, 0, 17256, :PROPVA-CODSUBES, :APCORR-DTINIVIG, '9999-12-31' , 100.00, 5.00, '1' , '1' , 0, CURRENT TIMESTAMP, 'VA0118B' ) END-EXEC. */

            var m_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1 = new M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1()
            {
                APCORR_RAMO = APCORR_RAMO.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                APCORR_DTINIVIG = APCORR_DTINIVIG.ToString(),
            };

            M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1.Execute(m_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2100_FIM*/

        [StopWatch]
        /*" M-3000-INTEGRA-JORNAL-FENAM-SECTION */
        private void M_3000_INTEGRA_JORNAL_FENAM_SECTION()
        {
            /*" -4952- MOVE '3000-INTEGRA-JORNAL-FENAM' TO PARAGRAFO */
            _.Move("3000-INTEGRA-JORNAL-FENAM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4956- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4963- MOVE PROPVA-DTQITBCO TO MDTMOVTO W01DTSQL. */
            _.Move(PROPVA_DTQITBCO, MDTMOVTO, WS_WORK_AREAS.W01DTSQL);

            /*" -4964- MOVE OPCAOP-DIA-DEB TO W01DDSQL. */
            _.Move(OPCAOP_DIA_DEB, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

            /*" -4965- ADD 1 TO W01MMSQL. */
            WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

            /*" -4966- IF W01MMSQL > 12 */

            if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
            {

                /*" -4967- MOVE 01 TO W01MMSQL */
                _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                /*" -4968- COMPUTE W01AASQL = W01AASQL + 1. */
                WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;
            }


            /*" -4970- MOVE W01DTSQL TO PROPVA-DTPROXVEN. */
            _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

            /*" -4971- IF W01DTSQL < PROPVA-DTMINVEN */

            if (WS_WORK_AREAS.W01DTSQL < PROPVA_DTMINVEN)
            {

                /*" -4972- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -4973- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -4974- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -4975- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -4976- END-IF */
                }


                /*" -4977- IF W01DDSQL > WS-ULTDIA (W01MMSQL) */

                if (WS_WORK_AREAS.W01DTSQL_R.W01DDSQL > WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL])
                {

                    /*" -4978- MOVE WS-ULTDIA (W01MMSQL) TO W01DDSQL */
                    _.Move(WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL], WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

                    /*" -4979- END-IF */
                }


                /*" -4979- MOVE W01DTSQL TO PROPVA-DTPROXVEN. */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);
            }


            /*" -0- FLUXCONTROL_PERFORM M_3000_AJUSTA_DTPROXVEN */

            M_3000_AJUSTA_DTPROXVEN();

        }

        [StopWatch]
        /*" M-3000-AJUSTA-DTPROXVEN */
        private void M_3000_AJUSTA_DTPROXVEN(bool isPerform = false)
        {
            /*" -4988- IF PROPVA-DTPROXVEN < W04DTSQL */

            if (PROPVA_DTPROXVEN < WS_WORK_AREAS.W04DTSQL)
            {

                /*" -4989- MOVE PROPVA-DTPROXVEN TO W01DTSQL */
                _.Move(PROPVA_DTPROXVEN, WS_WORK_AREAS.W01DTSQL);

                /*" -4990- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -4991- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -4992- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -4993- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -4994- END-IF */
                }


                /*" -4995- IF W01DDSQL > WS-ULTDIA (W01MMSQL) */

                if (WS_WORK_AREAS.W01DTSQL_R.W01DDSQL > WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL])
                {

                    /*" -4996- MOVE WS-ULTDIA (W01MMSQL) TO W01DDSQL */
                    _.Move(WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL], WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

                    /*" -4997- END-IF */
                }


                /*" -4998- MOVE W01DTSQL TO PROPVA-DTPROXVEN */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

                /*" -5000- GO TO 3000-AJUSTA-DTPROXVEN. */
                new Task(() => M_3000_AJUSTA_DTPROXVEN()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -5002- MOVE 0 TO MAGENCIADOR MNUM-MATRICULA. */
            _.Move(0, MAGENCIADOR, MNUM_MATRICULA);

            /*" -5004- MOVE '1' TO MTPINCLUS. */
            _.Move("1", MTPINCLUS);

            /*" -5004- PERFORM 8000-INTEGRA-VG THRU 8000-FIM. */

            M_8000_INTEGRA_VG_SECTION();

            R8000_PROPAUTOM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_FIM*/

        [StopWatch]
        /*" M-4000-INTEGRA-PREF-VIDA-SECTION */
        private void M_4000_INTEGRA_PREF_VIDA_SECTION()
        {
            /*" -5016- MOVE '4000-INTEGRA-PREF-VIDA' TO PARAGRAFO */
            _.Move("4000-INTEGRA-PREF-VIDA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5018- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5019- MOVE PROPVA-DTQITBCO TO MDTMOVTO. */
            _.Move(PROPVA_DTQITBCO, MDTMOVTO);

            /*" -5020- MOVE PROPVA-NRMATRFUN TO MNUM-MATRICULA. */
            _.Move(PROPVA_NRMATRFUN, MNUM_MATRICULA);

            /*" -5022- MOVE '1' TO MTPINCLUS. */
            _.Move("1", MTPINCLUS);

            /*" -5024- MOVE PRODVG-AGENCIADOR TO MAGENCIADOR. */
            _.Move(PRODVG_AGENCIADOR, MAGENCIADOR);

            /*" -5024- PERFORM 8000-INTEGRA-VG THRU 8000-FIM. */

            M_8000_INTEGRA_VG_SECTION();

            R8000_PROPAUTOM();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4000_FIM*/

        [StopWatch]
        /*" M-5000-INTEGRA-PARENTES-PV-SECTION */
        private void M_5000_INTEGRA_PARENTES_PV_SECTION()
        {
            /*" -5036- MOVE '5000-INTEGRA-PARENTES-PV' TO PARAGRAFO */
            _.Move("5000-INTEGRA-PARENTES-PV", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5040- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5042- MOVE PROPVA-DTQITBCO TO MDTMOVTO. */
            _.Move(PROPVA_DTQITBCO, MDTMOVTO);

            /*" -5043- IF PRODVG-ORIG-PRODU = 'CEF DEB CC' */

            if (PRODVG_ORIG_PRODU == "CEF DEB CC")
            {

                /*" -5044- MOVE PROPVA-DTVENCTO TO W01DTSQL */
                _.Move(PROPVA_DTVENCTO, WS_WORK_AREAS.W01DTSQL);

                /*" -5045- ELSE */
            }
            else
            {


                /*" -5051- MOVE PROPVA-DTQITBCO TO W01DTSQL. */
                _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);
            }


            /*" -5052- MOVE OPCAOP-DIA-DEB TO W01DDSQL. */
            _.Move(OPCAOP_DIA_DEB, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

            /*" -5053- ADD 1 TO W01MMSQL. */
            WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

            /*" -5054- IF W01MMSQL > 12 */

            if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
            {

                /*" -5055- MOVE 01 TO W01MMSQL */
                _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                /*" -5056- COMPUTE W01AASQL = W01AASQL + 1. */
                WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;
            }


            /*" -5058- MOVE W01DTSQL TO PROPVA-DTPROXVEN. */
            _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

            /*" -5059- IF W01DTSQL < PROPVA-DTMINVEN */

            if (WS_WORK_AREAS.W01DTSQL < PROPVA_DTMINVEN)
            {

                /*" -5060- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -5061- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -5062- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -5063- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -5064- END-IF */
                }


                /*" -5065- IF W01DDSQL > WS-ULTDIA (W01MMSQL) */

                if (WS_WORK_AREAS.W01DTSQL_R.W01DDSQL > WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL])
                {

                    /*" -5066- MOVE WS-ULTDIA (W01MMSQL) TO W01DDSQL */
                    _.Move(WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL], WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

                    /*" -5067- END-IF */
                }


                /*" -5067- MOVE W01DTSQL TO PROPVA-DTPROXVEN. */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);
            }


            /*" -0- FLUXCONTROL_PERFORM M_5000_AJUSTA_DTPROXVEN */

            M_5000_AJUSTA_DTPROXVEN();

        }

        [StopWatch]
        /*" M-5000-AJUSTA-DTPROXVEN */
        private void M_5000_AJUSTA_DTPROXVEN(bool isPerform = false)
        {
            /*" -5076- IF PROPVA-DTPROXVEN < W04DTSQL */

            if (PROPVA_DTPROXVEN < WS_WORK_AREAS.W04DTSQL)
            {

                /*" -5077- MOVE PROPVA-DTPROXVEN TO W01DTSQL */
                _.Move(PROPVA_DTPROXVEN, WS_WORK_AREAS.W01DTSQL);

                /*" -5078- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -5079- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -5080- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -5081- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -5082- END-IF */
                }


                /*" -5083- IF W01DDSQL > WS-ULTDIA (W01MMSQL) */

                if (WS_WORK_AREAS.W01DTSQL_R.W01DDSQL > WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL])
                {

                    /*" -5084- MOVE WS-ULTDIA (W01MMSQL) TO W01DDSQL */
                    _.Move(WS_TABMES_R.WS_ULTDIA[WS_WORK_AREAS.W01DTSQL_R.W01MMSQL], WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

                    /*" -5085- END-IF */
                }


                /*" -5086- MOVE W01DTSQL TO PROPVA-DTPROXVEN */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

                /*" -5091- GO TO 5000-AJUSTA-DTPROXVEN. */
                new Task(() => M_5000_AJUSTA_DTPROXVEN()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -5093- IF PROPVA-NRPARCEL = 0 AND PROPVA-CODOPER = 201 */

            if (PROPVA_NRPARCEL == 0 && PROPVA_CODOPER == 201)
            {

                /*" -5094- MOVE PROPVA-DTMOVTO TO W01DTSQL */
                _.Move(PROPVA_DTMOVTO, WS_WORK_AREAS.W01DTSQL);

                /*" -5095- MOVE OPCAOP-DIA-DEB TO W01DDSQL */
                _.Move(OPCAOP_DIA_DEB, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

                /*" -5098- MOVE W01DTSQL TO PROPVA-DTPROXVEN. */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);
            }


            /*" -5099- MOVE PROPVA-NRMATRFUN TO MNUM-MATRICULA. */
            _.Move(PROPVA_NRMATRFUN, MNUM_MATRICULA);

            /*" -5100- MOVE PRODVG-AGENCIADOR TO MAGENCIADOR. */
            _.Move(PRODVG_AGENCIADOR, MAGENCIADOR);

            /*" -5102- MOVE '1' TO MTPINCLUS. */
            _.Move("1", MTPINCLUS);

            /*" -5104- PERFORM 8000-INTEGRA-VG THRU 8000-FIM. */

            M_8000_INTEGRA_VG_SECTION();

            R8000_PROPAUTOM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/


            /*" -5106- IF PROPOSTA-CACB OR PROPOSTA-COPESP */

            if (WS_WORK_AREAS.FILLER_6.W_CANAL_PROPOSTA1["PROPOSTA_CACB"] || WS_WORK_AREAS.FILLER_6.W_CANAL_PROPOSTA1["PROPOSTA_COPESP"])
            {

                /*" -5106- PERFORM 5100-GERA-COMISSAO. */

                M_5100_GERA_COMISSAO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

        [StopWatch]
        /*" M-5100-GERA-COMISSAO-SECTION */
        private void M_5100_GERA_COMISSAO_SECTION()
        {
            /*" -5119- MOVE '5100-GERA-COMISSAO' TO PARAGRAFO */
            _.Move("5100-GERA-COMISSAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5120- MOVE 'INSERT            ' TO COMANDO. */
            _.Move("INSERT            ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5122- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5125- MOVE 93 TO COMISSOE-RAMO-COBERTURA. */
            _.Move(93, COMISSOE.DCLCOMISSOES.COMISSOE_RAMO_COBERTURA);

            /*" -5127- IF PROPVA-CODPRODU EQUAL 9335 OR PROPVA-CODPRODU EQUAL 9338 */

            if (PROPVA_CODPRODU == 9335 || PROPVA_CODPRODU == 9338)
            {

                /*" -5129- MOVE 17 TO COMISSOE-PCT-COM-CORRETOR */
                _.Move(17, COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR);

                /*" -5130- ELSE */
            }
            else
            {


                /*" -5132- MOVE 75 TO COMISSOE-PCT-COM-CORRETOR */
                _.Move(75, COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR);

                /*" -5134- END-IF. */
            }


            /*" -5137- COMPUTE COMISSOE-VAL-BASICO = COBERP-PRMVG + COBERP-PRMAP. */
            COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO.Value = COBERP_PRMVG + COBERP_PRMAP;

            /*" -5141- COMPUTE COMISSOE-VAL-COMISSAO = COMISSOE-VAL-BASICO * COMISSOE-PCT-COM-CORRETOR / 100. */
            COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO.Value = COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO * COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR / 100f;

            /*" -5142- MOVE PROPVA-NUM-APOLICE TO COMISSOE-NUM-APOLICE */
            _.Move(PROPVA_NUM_APOLICE, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_APOLICE);

            /*" -5143- MOVE ZEROS TO COMISSOE-NUM-ENDOSSO */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_ENDOSSO);

            /*" -5144- MOVE PROPVA-NRCERTIF TO COMISSOE-NUM-CERTIFICADO */
            _.Move(PROPVA_NRCERTIF, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_CERTIFICADO);

            /*" -5145- MOVE SPACES TO COMISSOE-DAC-CERTIFICADO */
            _.Move("", COMISSOE.DCLCOMISSOES.COMISSOE_DAC_CERTIFICADO);

            /*" -5146- MOVE '1' TO COMISSOE-TIPO-SEGURADO */
            _.Move("1", COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_SEGURADO);

            /*" -5147- MOVE 1 TO COMISSOE-NUM-PARCELA */
            _.Move(1, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_PARCELA);

            /*" -5148- MOVE 1101 TO COMISSOE-COD-OPERACAO */
            _.Move(1101, COMISSOE.DCLCOMISSOES.COMISSOE_COD_OPERACAO);

            /*" -5149- MOVE 7005 TO COMISSOE-COD-PRODUTOR */
            _.Move(7005, COMISSOE.DCLCOMISSOES.COMISSOE_COD_PRODUTOR);

            /*" -5150- MOVE ZEROS TO COMISSOE-MODALI-COBERTURA */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_MODALI_COBERTURA);

            /*" -5151- MOVE 1 TO COMISSOE-OCORR-HISTORICO */
            _.Move(1, COMISSOE.DCLCOMISSOES.COMISSOE_OCORR_HISTORICO);

            /*" -5152- MOVE PROPVA-FONTE TO COMISSOE-COD-FONTE */
            _.Move(PROPVA_FONTE, COMISSOE.DCLCOMISSOES.COMISSOE_COD_FONTE);

            /*" -5153- MOVE PROPVA-CODCLIEN TO COMISSOE-COD-CLIENTE */
            _.Move(PROPVA_CODCLIEN, COMISSOE.DCLCOMISSOES.COMISSOE_COD_CLIENTE);

            /*" -5154- MOVE SISTEMA-DTMOVABE TO COMISSOE-DATA-CALCULO */
            _.Move(SISTEMA_DTMOVABE, COMISSOE.DCLCOMISSOES.COMISSOE_DATA_CALCULO);

            /*" -5155- MOVE ZEROS TO COMISSOE-NUM-RECIBO */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_RECIBO);

            /*" -5156- MOVE '1' TO COMISSOE-TIPO-COMISSAO */
            _.Move("1", COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_COMISSAO);

            /*" -5158- MOVE ZEROS TO COMISSOE-QTD-PARCELAS COMISSOE-PCT-DESC-PREMIO */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_QTD_PARCELAS, COMISSOE.DCLCOMISSOES.COMISSOE_PCT_DESC_PREMIO);

            /*" -5159- MOVE PROPVA-CODSUBES TO COMISSOE-COD-SUBGRUPO */
            _.Move(PROPVA_CODSUBES, COMISSOE.DCLCOMISSOES.COMISSOE_COD_SUBGRUPO);

            /*" -5160- MOVE SPACES TO COMISSOE-DATA-MOVIMENTO */
            _.Move("", COMISSOE.DCLCOMISSOES.COMISSOE_DATA_MOVIMENTO);

            /*" -5161- MOVE SISTEMA-DTMOVABE TO COMISSOE-DATA-SELECAO */
            _.Move(SISTEMA_DTMOVABE, COMISSOE.DCLCOMISSOES.COMISSOE_DATA_SELECAO);

            /*" -5165- MOVE ZEROS TO COMISSOE-COD-EMPRESA COMISSOE-COD-PREPOSTO COMISSOE-NUM-BILHETE COMISSOE-VAL-VARMON */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_COD_EMPRESA, COMISSOE.DCLCOMISSOES.COMISSOE_COD_PREPOSTO, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_BILHETE, COMISSOE.DCLCOMISSOES.COMISSOE_VAL_VARMON);

            /*" -5167- MOVE SISTEMA-DTMOVABE TO COMISSOE-DATA-QUITACAO. */
            _.Move(SISTEMA_DTMOVABE, COMISSOE.DCLCOMISSOES.COMISSOE_DATA_QUITACAO);

            /*" -5168- MOVE -1 TO VIND-DTMOVTO */
            _.Move(-1, VIND_DTMOVTO);

            /*" -5169- MOVE ZEROS TO VIND-DATSEL */
            _.Move(0, VIND_DATSEL);

            /*" -5170- MOVE ZEROS TO VIND-CODEMP */
            _.Move(0, VIND_CODEMP);

            /*" -5171- MOVE -1 TO VIND-CODPRP */
            _.Move(-1, VIND_CODPRP);

            /*" -5172- MOVE -1 TO VIND-NUMBIL */
            _.Move(-1, VIND_NUMBIL);

            /*" -5173- MOVE -1 TO VIND-VLVARMON */
            _.Move(-1, VIND_VLVARMON);

            /*" -5175- MOVE ZEROS TO VIND-DTQITBCO. */
            _.Move(0, VIND_DTQITBCO);

            /*" -5209- PERFORM M_5100_GERA_COMISSAO_DB_INSERT_1 */

            M_5100_GERA_COMISSAO_DB_INSERT_1();

            /*" -5213- IF SQLCODE EQUAL -803 NEXT SENTENCE */

            if (DB.SQLCODE == -803)
            {

                /*" -5214- ELSE */
            }
            else
            {


                /*" -5215- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5216- DISPLAY '5100 - PROBLEMAS NO INSERT(COMISSAO)' */
                    _.Display($"5100 - PROBLEMAS NO INSERT(COMISSAO)");

                    /*" -5217- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-5100-GERA-COMISSAO-DB-INSERT-1 */
        public void M_5100_GERA_COMISSAO_DB_INSERT_1()
        {
            /*" -5209- EXEC SQL INSERT INTO SEGUROS.COMISSOES VALUES( :COMISSOE-NUM-APOLICE, :COMISSOE-NUM-ENDOSSO, :COMISSOE-NUM-CERTIFICADO, :COMISSOE-DAC-CERTIFICADO, :COMISSOE-TIPO-SEGURADO, :COMISSOE-NUM-PARCELA, :COMISSOE-COD-OPERACAO, :COMISSOE-COD-PRODUTOR, :COMISSOE-RAMO-COBERTURA, :COMISSOE-MODALI-COBERTURA, :COMISSOE-OCORR-HISTORICO, :COMISSOE-COD-FONTE, :COMISSOE-COD-CLIENTE, :COMISSOE-VAL-COMISSAO, :COMISSOE-DATA-CALCULO, :COMISSOE-NUM-RECIBO, :COMISSOE-VAL-BASICO, :COMISSOE-TIPO-COMISSAO, :COMISSOE-QTD-PARCELAS, :COMISSOE-PCT-COM-CORRETOR, :COMISSOE-PCT-DESC-PREMIO, :COMISSOE-COD-SUBGRUPO, CURRENT TIME, :COMISSOE-DATA-MOVIMENTO:VIND-DTMOVTO, :COMISSOE-DATA-SELECAO:VIND-DATSEL, :COMISSOE-COD-EMPRESA:VIND-CODEMP, :COMISSOE-COD-PREPOSTO:VIND-CODPRP, CURRENT TIMESTAMP, :COMISSOE-NUM-BILHETE:VIND-NUMBIL, :COMISSOE-VAL-VARMON:VIND-VLVARMON, :COMISSOE-DATA-QUITACAO:VIND-DTQITBCO) END-EXEC. */

            var m_5100_GERA_COMISSAO_DB_INSERT_1_Insert1 = new M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1()
            {
                COMISSOE_NUM_APOLICE = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_APOLICE.ToString(),
                COMISSOE_NUM_ENDOSSO = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_ENDOSSO.ToString(),
                COMISSOE_NUM_CERTIFICADO = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_CERTIFICADO.ToString(),
                COMISSOE_DAC_CERTIFICADO = COMISSOE.DCLCOMISSOES.COMISSOE_DAC_CERTIFICADO.ToString(),
                COMISSOE_TIPO_SEGURADO = COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_SEGURADO.ToString(),
                COMISSOE_NUM_PARCELA = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_PARCELA.ToString(),
                COMISSOE_COD_OPERACAO = COMISSOE.DCLCOMISSOES.COMISSOE_COD_OPERACAO.ToString(),
                COMISSOE_COD_PRODUTOR = COMISSOE.DCLCOMISSOES.COMISSOE_COD_PRODUTOR.ToString(),
                COMISSOE_RAMO_COBERTURA = COMISSOE.DCLCOMISSOES.COMISSOE_RAMO_COBERTURA.ToString(),
                COMISSOE_MODALI_COBERTURA = COMISSOE.DCLCOMISSOES.COMISSOE_MODALI_COBERTURA.ToString(),
                COMISSOE_OCORR_HISTORICO = COMISSOE.DCLCOMISSOES.COMISSOE_OCORR_HISTORICO.ToString(),
                COMISSOE_COD_FONTE = COMISSOE.DCLCOMISSOES.COMISSOE_COD_FONTE.ToString(),
                COMISSOE_COD_CLIENTE = COMISSOE.DCLCOMISSOES.COMISSOE_COD_CLIENTE.ToString(),
                COMISSOE_VAL_COMISSAO = COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO.ToString(),
                COMISSOE_DATA_CALCULO = COMISSOE.DCLCOMISSOES.COMISSOE_DATA_CALCULO.ToString(),
                COMISSOE_NUM_RECIBO = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_RECIBO.ToString(),
                COMISSOE_VAL_BASICO = COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO.ToString(),
                COMISSOE_TIPO_COMISSAO = COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_COMISSAO.ToString(),
                COMISSOE_QTD_PARCELAS = COMISSOE.DCLCOMISSOES.COMISSOE_QTD_PARCELAS.ToString(),
                COMISSOE_PCT_COM_CORRETOR = COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR.ToString(),
                COMISSOE_PCT_DESC_PREMIO = COMISSOE.DCLCOMISSOES.COMISSOE_PCT_DESC_PREMIO.ToString(),
                COMISSOE_COD_SUBGRUPO = COMISSOE.DCLCOMISSOES.COMISSOE_COD_SUBGRUPO.ToString(),
                COMISSOE_DATA_MOVIMENTO = COMISSOE.DCLCOMISSOES.COMISSOE_DATA_MOVIMENTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
                COMISSOE_DATA_SELECAO = COMISSOE.DCLCOMISSOES.COMISSOE_DATA_SELECAO.ToString(),
                VIND_DATSEL = VIND_DATSEL.ToString(),
                COMISSOE_COD_EMPRESA = COMISSOE.DCLCOMISSOES.COMISSOE_COD_EMPRESA.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                COMISSOE_COD_PREPOSTO = COMISSOE.DCLCOMISSOES.COMISSOE_COD_PREPOSTO.ToString(),
                VIND_CODPRP = VIND_CODPRP.ToString(),
                COMISSOE_NUM_BILHETE = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_BILHETE.ToString(),
                VIND_NUMBIL = VIND_NUMBIL.ToString(),
                COMISSOE_VAL_VARMON = COMISSOE.DCLCOMISSOES.COMISSOE_VAL_VARMON.ToString(),
                VIND_VLVARMON = VIND_VLVARMON.ToString(),
                COMISSOE_DATA_QUITACAO = COMISSOE.DCLCOMISSOES.COMISSOE_DATA_QUITACAO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
            };

            M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1.Execute(m_5100_GERA_COMISSAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5100_FIM*/

        [StopWatch]
        /*" R6000-00-TRATA-FC0001S-SECTION */
        private void R6000_00_TRATA_FC0001S_SECTION()
        {
            /*" -5224- MOVE 'R6000-00-TRATA-FC0001S' TO PARAGRAFO. */
            _.Move("R6000-00-TRATA-FC0001S", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5225- MOVE 'TRATA FC0001S' TO COMANDO. */
            _.Move("TRATA FC0001S", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5227- DISPLAY PARAGRAFO. */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5229- PERFORM R6290-00-INSERT-MOVFEDCA THRU R6290-99-SAIDA. */

            R6290_00_INSERT_MOVFEDCA_SECTION();

            R6290_10_INSERT();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R6290_99_SAIDA*/


            /*" -5230- IF WTEM-MOVFEDCA EQUAL 'SIM' */

            if (WS_WORK_AREAS.WTEM_MOVFEDCA == "SIM")
            {

                /*" -5231- GO TO R6000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/ //GOTO
                return;

                /*" -5233- END-IF. */
            }


            /*" -5235- PERFORM R6300-00-INSERT-TITFEDCA THRU R6300-99-SAIDA. */

            R6300_00_INSERT_TITFEDCA_SECTION();

            R6300_00_INSERT();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R6300_99_SAIDA*/


            /*" -5237- PERFORM R6400-00-INSERT-COMFEDCA THRU R6400-99-SAIDA. */

            R6400_00_INSERT_COMFEDCA_SECTION();

            R6400_10_INSERT();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R6400_99_SAIDA*/


            /*" -5237- PERFORM R6500-00-INSERT-PARFEDCA THRU R6500-99-SAIDA. */

            R6500_00_INSERT_PARFEDCA_SECTION();

            R6500_10_INSERT();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R6500_99_SAIDA*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6290-00-INSERT-MOVFEDCA-SECTION */
        private void R6290_00_INSERT_MOVFEDCA_SECTION()
        {
            /*" -5245- MOVE 'R6290-00-INSERT-MOVFEDCA' TO PARAGRAFO. */
            _.Move("R6290-00-INSERT-MOVFEDCA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5247- DISPLAY PARAGRAFO. */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5250- MOVE 'NAO' TO WTEM-MOVFEDCA. */
            _.Move("NAO", WS_WORK_AREAS.WTEM_MOVFEDCA);

            /*" -5252- MOVE 'SELECT COMUNIC_FED_CAP_VA' TO COMANDO. */
            _.Move("SELECT COMUNIC_FED_CAP_VA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5257- PERFORM R6290_00_INSERT_MOVFEDCA_DB_SELECT_1 */

            R6290_00_INSERT_MOVFEDCA_DB_SELECT_1();

            /*" -5260- IF SQLCODE EQUAL ZEROS OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -5262- MOVE 'SIM' TO WTEM-MOVFEDCA */
                _.Move("SIM", WS_WORK_AREAS.WTEM_MOVFEDCA);

                /*" -5263- GO TO R6290-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R6290_99_SAIDA*/ //GOTO
                return;

                /*" -5264- ELSE */
            }
            else
            {


                /*" -5265- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5266- CONTINUE */

                    /*" -5267- ELSE */
                }
                else
                {


                    /*" -5268- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5270- END-IF */
                }


                /*" -5272- INITIALIZE FC0001S-LINKAGE */
                _.Initialize(
                    FC0001S_LINKAGE
                );

                /*" -5275- MOVE 809 TO FC0001S-NUM-PLANO */
                _.Move(809, FC0001S_LINKAGE.FC0001S_NUM_PLANO);

                /*" -5278- MOVE PROPVA-NRCERTIF TO FC0001S-NUM-PROPOSTA */
                _.Move(PROPVA_NRCERTIF, FC0001S_LINKAGE.FC0001S_NUM_PROPOSTA);

                /*" -5281- MOVE PRODVG-CUSTOCAP-TOTAL-9 TO FC0001S-VLR-MENSALIDADE */
                _.Move(PRODVG_CUSTOCAP_TOTAL_9, FC0001S_LINKAGE.FC0001S_VLR_MENSALIDADE);

                /*" -5283- CALL 'FC0001S' USING FC0001S-LINKAGE. */
                _.Call("FC0001S", FC0001S_LINKAGE);
            }


            /*" -5284- IF FC0001S-COD-RETORNO NOT EQUAL ZEROS */

            if (FC0001S_LINKAGE.FC0001S_COD_RETORNO != 00)
            {

                /*" -5285- MOVE FC0001S-SQLCODE TO WS-SQLCODE */
                _.Move(FC0001S_LINKAGE.FC0001S_SQLCODE, WS_SQLCODE);

                /*" -5299- DISPLAY 'PROBLEMAS NO ACESSO A FC0001S ' ' ' FC0001S-NUM-PROPOSTA ' ' WS-SQLCODE ' ' FC0001S-DES-MENSAGEM ' ' FC0001S-VLR-MENSALIDADE ' ' FC0001S-NUM-PLANO ' ' FC0001S-NUM-SERIE ' ' FC0001S-NUM-TITULO ' ' FC0001S-IND-DV ' ' FC0001S-DTH-INI-VIGENCIA ' ' FC0001S-DTH-FIM-VIGENCIA ' ' FC0001S-DES-COMBINACAO ' ' FC0001S-SQLCODE ' ' FC0001S-COD-RETORNO */

                $"PROBLEMAS NO ACESSO A FC0001S  {FC0001S_LINKAGE.FC0001S_NUM_PROPOSTA} {WS_SQLCODE} {FC0001S_LINKAGE.FC0001S_DES_MENSAGEM} {FC0001S_LINKAGE.FC0001S_VLR_MENSALIDADE} {FC0001S_LINKAGE.FC0001S_NUM_PLANO} {FC0001S_LINKAGE.FC0001S_NUM_SERIE} {FC0001S_LINKAGE.FC0001S_NUM_TITULO} {FC0001S_LINKAGE.FC0001S_IND_DV} {FC0001S_LINKAGE.FC0001S_DTH_INI_VIGENCIA} {FC0001S_LINKAGE.FC0001S_DTH_FIM_VIGENCIA} {FC0001S_LINKAGE.FC0001S_DES_COMBINACAO} {FC0001S_LINKAGE.FC0001S_SQLCODE} {FC0001S_LINKAGE.FC0001S_COD_RETORNO}"
                .Display();

                /*" -5300- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -5302- END-IF. */
            }


            /*" -5304- MOVE FC0001S-NUM-PLANO TO WS-NUM-PLANO */
            _.Move(FC0001S_LINKAGE.FC0001S_NUM_PLANO, WS_NUM_TITULO_X.WS_NUM_PLANO);

            /*" -5306- MOVE FC0001S-NUM-SERIE TO WS-NUM-SERIE */
            _.Move(FC0001S_LINKAGE.FC0001S_NUM_SERIE, WS_NUM_TITULO_X.WS_NUM_SERIE);

            /*" -5308- MOVE FC0001S-NUM-TITULO TO WS-NUM-TITULO */
            _.Move(FC0001S_LINKAGE.FC0001S_NUM_TITULO, WS_NUM_TITULO_X.WS_NUM_TITULO);

            /*" -5310- MOVE WS-NUM-TITULO-9 TO MOVFEDCA-NRTITFDCAP. */
            _.Move(WS_NUM_TITULO_9, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP);

            /*" -5312- MOVE PRODVG-CUSTOCAP-TOTAL-9 TO MOVFEDCA-VAL-CUSTO-CAPITALI. */
            _.Move(PRODVG_CUSTOCAP_TOTAL_9, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_VAL_CUSTO_CAPITALI);

            /*" -0- FLUXCONTROL_PERFORM R6290_10_INSERT */

            R6290_10_INSERT();

        }

        [StopWatch]
        /*" R6290-00-INSERT-MOVFEDCA-DB-SELECT-1 */
        public void R6290_00_INSERT_MOVFEDCA_DB_SELECT_1()
        {
            /*" -5257- EXEC SQL SELECT SITUACAO INTO :COMFEDCA-SITUACAO FROM SEGUROS.COMUNIC_FED_CAP_VA WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC. */

            var r6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1 = new R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1.Execute(r6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COMFEDCA_SITUACAO, COMFEDCA.DCLCOMUNIC_FED_CAP_VA.COMFEDCA_SITUACAO);
            }


        }

        [StopWatch]
        /*" R6290-10-INSERT */
        private void R6290_10_INSERT(bool isPerform = false)
        {
            /*" -5346- PERFORM R6290_10_INSERT_DB_INSERT_1 */

            R6290_10_INSERT_DB_INSERT_1();

            /*" -5349- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5350- DISPLAY 'R6290 - ERRO NO INSERT DA MOVFEDCA ' */
                _.Display($"R6290 - ERRO NO INSERT DA MOVFEDCA ");

                /*" -5351- DISPLAY 'NRO CERTIFICADO - ' PROPVA-NRCERTIF */
                _.Display($"NRO CERTIFICADO - {PROPVA_NRCERTIF}");

                /*" -5352- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -5352- END-IF. */
            }


        }

        [StopWatch]
        /*" R6290-10-INSERT-DB-INSERT-1 */
        public void R6290_10_INSERT_DB_INSERT_1()
        {
            /*" -5346- EXEC SQL INSERT INTO SEGUROS.MOVIMEN_FED_CAP_VA ( NUM_CERTIFICADO , COD_OPERACAO , COD_FONTE , NUM_PROPOSTA , DTMVFDCAP , NUM_PARCELA , QUANT_TIT_CAPITALI , VAL_CUSTO_CAPITALI , SITUACAO , NRTITFDCAP , NRMSCAP , NUM_SEQUENCIA , TIMESTAMP , CODPRODU ) VALUES ( :PROPVA-NRCERTIF , 1 , :PROPVA-FONTE , 0 , :SISTEMA-DTMOVABE , 0 , 1 , :MOVFEDCA-VAL-CUSTO-CAPITALI , '1' , :MOVFEDCA-NRTITFDCAP , 0 , 0 , CURRENT TIMESTAMP , :PRODVG-COD-PRODUTO ) END-EXEC. */

            var r6290_10_INSERT_DB_INSERT_1_Insert1 = new R6290_10_INSERT_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                MOVFEDCA_VAL_CUSTO_CAPITALI = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_VAL_CUSTO_CAPITALI.ToString(),
                MOVFEDCA_NRTITFDCAP = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP.ToString(),
                PRODVG_COD_PRODUTO = PRODVG_COD_PRODUTO.ToString(),
            };

            R6290_10_INSERT_DB_INSERT_1_Insert1.Execute(r6290_10_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6290_99_SAIDA*/

        [StopWatch]
        /*" R6300-00-INSERT-TITFEDCA-SECTION */
        private void R6300_00_INSERT_TITFEDCA_SECTION()
        {
            /*" -5360- MOVE 'R6300-00-INSERT-TITFEDCA' TO PARAGRAFO. */
            _.Move("R6300-00-INSERT-TITFEDCA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5361- MOVE 'INSERE TITFEDCA' TO COMANDO. */
            _.Move("INSERE TITFEDCA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5363- DISPLAY PARAGRAFO. */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5365- MOVE FC0001S-DTH-INI-VIGENCIA TO TITFEDCA-DATA-INIVIGENCIA */
            _.Move(FC0001S_LINKAGE.FC0001S_DTH_INI_VIGENCIA, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_INIVIGENCIA);

            /*" -5367- MOVE FC0001S-DTH-FIM-VIGENCIA TO TITFEDCA-DATA-TERVIGENCIA */
            _.Move(FC0001S_LINKAGE.FC0001S_DTH_FIM_VIGENCIA, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_TERVIGENCIA);

            /*" -5370- MOVE FC0001S-DES-COMBINACAO TO WS-COMBINACAO. */
            _.Move(FC0001S_LINKAGE.FC0001S_DES_COMBINACAO, WS_COMBINACAO);

            /*" -5373- PERFORM R6310-00-TRATA-COMBINACAO THRU R6310-99-SAIDA. */

            R6310_00_TRATA_COMBINACAO_SECTION();

            R6310_10_LOOP();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R6310_99_SAIDA*/


            /*" -5376- MOVE WS-COMBINACAO-9 TO TITFEDCA-NRSORTEIO. */
            _.Move(WS_COMBINACAO_9, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO);

            /*" -5378- MOVE PRODVG-CUSTOCAP-TOTAL-9 TO TITFEDCA-VAL-CUSTO-TITULO. */
            _.Move(PRODVG_CUSTOCAP_TOTAL_9, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_VAL_CUSTO_TITULO);

            /*" -0- FLUXCONTROL_PERFORM R6300_00_INSERT */

            R6300_00_INSERT();

        }

        [StopWatch]
        /*" R6300-00-INSERT */
        private void R6300_00_INSERT(bool isPerform = false)
        {
            /*" -5412- PERFORM R6300_00_INSERT_DB_INSERT_1 */

            R6300_00_INSERT_DB_INSERT_1();

            /*" -5415- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5416- DISPLAY '6300 - ERRO NO INSERT DA TITFEDCA ' */
                _.Display($"6300 - ERRO NO INSERT DA TITFEDCA ");

                /*" -5417- DISPLAY 'CERTIF ' PROPVA-NRCERTIF */
                _.Display($"CERTIF {PROPVA_NRCERTIF}");

                /*" -5418- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -5418- END-IF. */
            }


        }

        [StopWatch]
        /*" R6300-00-INSERT-DB-INSERT-1 */
        public void R6300_00_INSERT_DB_INSERT_1()
        {
            /*" -5412- EXEC SQL INSERT INTO SEGUROS.TITULOS_FED_CAP_VA ( NRTITFDCAP , NUM_CERTIFICADO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , NRSORTEIO , VAL_CUSTO_TITULO , NRPARCEL , NRMFDCAPF , SITUACAO , SIT_RELAT , DATA_MOVIMENTO , TIMESTAMP , NRMFDCAPR , NRTITREN ) VALUES ( :MOVFEDCA-NRTITFDCAP , :PROPVA-NRCERTIF , :TITFEDCA-DATA-INIVIGENCIA , :TITFEDCA-DATA-TERVIGENCIA , :TITFEDCA-NRSORTEIO , :TITFEDCA-VAL-CUSTO-TITULO , 0 , 0 , '0' , '1' , :SISTEMA-DTMOVABE , CURRENT TIMESTAMP , 0 , 0 ) END-EXEC. */

            var r6300_00_INSERT_DB_INSERT_1_Insert1 = new R6300_00_INSERT_DB_INSERT_1_Insert1()
            {
                MOVFEDCA_NRTITFDCAP = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                TITFEDCA_DATA_INIVIGENCIA = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_INIVIGENCIA.ToString(),
                TITFEDCA_DATA_TERVIGENCIA = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_TERVIGENCIA.ToString(),
                TITFEDCA_NRSORTEIO = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO.ToString(),
                TITFEDCA_VAL_CUSTO_TITULO = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_VAL_CUSTO_TITULO.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            R6300_00_INSERT_DB_INSERT_1_Insert1.Execute(r6300_00_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6300_99_SAIDA*/

        [StopWatch]
        /*" R6310-00-TRATA-COMBINACAO-SECTION */
        private void R6310_00_TRATA_COMBINACAO_SECTION()
        {
            /*" -5426- MOVE 'R6310-00-TRATA-COMBINACAO' TO PARAGRAFO. */
            _.Move("R6310-00-TRATA-COMBINACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5427- MOVE 'TRATA COMBINACAO' TO COMANDO. */
            _.Move("TRATA COMBINACAO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5429- DISPLAY PARAGRAFO. */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5430- MOVE ZEROS TO WIND. */
            _.Move(0, WIND);

            /*" -0- FLUXCONTROL_PERFORM R6310_10_LOOP */

            R6310_10_LOOP();

        }

        [StopWatch]
        /*" R6310-10-LOOP */
        private void R6310_10_LOOP(bool isPerform = false)
        {
            /*" -5435- ADD 1 TO WIND. */
            WIND.Value = WIND + 1;

            /*" -5436- IF WIND GREATER 20 */

            if (WIND > 20)
            {

                /*" -5437- DISPLAY 'PROBLEMAS NO NUMERO DE SORTE' */
                _.Display($"PROBLEMAS NO NUMERO DE SORTE");

                /*" -5438- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -5440- END-IF. */
            }


            /*" -5441- IF WS-COMB(WIND) = ' ' */

            if (WS_COMBINACAO_R.WS_COMB[WIND] == " ")
            {

                /*" -5442- SUBTRACT 1 FROM WIND */
                WIND.Value = WIND - 1;

                /*" -5444- MOVE WS-COMBINACAO(1:WIND) TO WS-COMBINACAO-9 */
                _.Move(WS_COMBINACAO.Substring(1, WIND), WS_COMBINACAO_9);

                /*" -5445- ELSE */
            }
            else
            {


                /*" -5445- GO TO R6310-10-LOOP. */
                new Task(() => R6310_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6310_99_SAIDA*/

        [StopWatch]
        /*" R6400-00-INSERT-COMFEDCA-SECTION */
        private void R6400_00_INSERT_COMFEDCA_SECTION()
        {
            /*" -5453- MOVE 'R6400-00-INSERT-COMFEDCA' TO PARAGRAFO. */
            _.Move("R6400-00-INSERT-COMFEDCA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5454- MOVE 'INSERT COMFEDCA' TO COMANDO. */
            _.Move("INSERT COMFEDCA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5455- DISPLAY PARAGRAFO. */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -0- FLUXCONTROL_PERFORM R6400_10_INSERT */

            R6400_10_INSERT();

        }

        [StopWatch]
        /*" R6400-10-INSERT */
        private void R6400_10_INSERT(bool isPerform = false)
        {
            /*" -5470- PERFORM R6400_10_INSERT_DB_INSERT_1 */

            R6400_10_INSERT_DB_INSERT_1();

            /*" -5473- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5474- DISPLAY 'R6400 - ERRO NO INSERT DA TITFEDCA ' */
                _.Display($"R6400 - ERRO NO INSERT DA TITFEDCA ");

                /*" -5475- DISPLAY 'NRO CERTIFICADO - ' PROPVA-NRCERTIF */
                _.Display($"NRO CERTIFICADO - {PROPVA_NRCERTIF}");

                /*" -5476- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -5476- END-IF. */
            }


        }

        [StopWatch]
        /*" R6400-10-INSERT-DB-INSERT-1 */
        public void R6400_10_INSERT_DB_INSERT_1()
        {
            /*" -5470- EXEC SQL INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO , SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ( :PROPVA-NRCERTIF , '0' , :SISTEMA-DTMOVABE, CURRENT TIMESTAMP ) END-EXEC. */

            var r6400_10_INSERT_DB_INSERT_1_Insert1 = new R6400_10_INSERT_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            R6400_10_INSERT_DB_INSERT_1_Insert1.Execute(r6400_10_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6400_99_SAIDA*/

        [StopWatch]
        /*" R6500-00-INSERT-PARFEDCA-SECTION */
        private void R6500_00_INSERT_PARFEDCA_SECTION()
        {
            /*" -5484- MOVE 'R6500-00-INSERT-PARFEDCA' TO PARAGRAFO. */
            _.Move("R6500-00-INSERT-PARFEDCA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5485- MOVE 'INSERT PARFEDCA' TO COMANDO. */
            _.Move("INSERT PARFEDCA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5487- DISPLAY PARAGRAFO. */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -0- FLUXCONTROL_PERFORM R6500_10_INSERT */

            R6500_10_INSERT();

        }

        [StopWatch]
        /*" R6500-10-INSERT */
        private void R6500_10_INSERT(bool isPerform = false)
        {
            /*" -5493- MOVE PRODVG-CUSTOCAP-TOTAL-9 TO PARFEDCA-VAL-CUSTO-TITULO. */
            _.Move(PRODVG_CUSTOCAP_TOTAL_9, PARFEDCA.DCLPARCEL_FED_CAP_VA.PARFEDCA_VAL_CUSTO_TITULO);

            /*" -5512- PERFORM R6500_10_INSERT_DB_INSERT_1 */

            R6500_10_INSERT_DB_INSERT_1();

            /*" -5515- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5516- DISPLAY '6500 - ERRO NO INSERT DA COMFEDCA ' */
                _.Display($"6500 - ERRO NO INSERT DA COMFEDCA ");

                /*" -5517- DISPLAY 'CERTIF ' PROPVA-NRCERTIF */
                _.Display($"CERTIF {PROPVA_NRCERTIF}");

                /*" -5518- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -5519- END-IF. */
            }


        }

        [StopWatch]
        /*" R6500-10-INSERT-DB-INSERT-1 */
        public void R6500_10_INSERT_DB_INSERT_1()
        {
            /*" -5512- EXEC SQL INSERT INTO SEGUROS.PARCEL_FED_CAP_VA ( NRTITFDCAP , NUM_PARCELA , VAL_CUSTO_TITULO , DTFATUR , DATA_MOVIMENTO , SITUACAO , NRMFDCAP , TIMESTAMP ) VALUES ( :MOVFEDCA-NRTITFDCAP , 0 , :PARFEDCA-VAL-CUSTO-TITULO , :SISTEMA-DTMOVABE , :SISTEMA-DTMOVABE , '1' , 0 , CURRENT TIMESTAMP ) END-EXEC. */

            var r6500_10_INSERT_DB_INSERT_1_Insert1 = new R6500_10_INSERT_DB_INSERT_1_Insert1()
            {
                MOVFEDCA_NRTITFDCAP = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP.ToString(),
                PARFEDCA_VAL_CUSTO_TITULO = PARFEDCA.DCLPARCEL_FED_CAP_VA.PARFEDCA_VAL_CUSTO_TITULO.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            R6500_10_INSERT_DB_INSERT_1_Insert1.Execute(r6500_10_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6500_99_SAIDA*/

        [StopWatch]
        /*" R7000-00-TRATA-FC0105B-SECTION */
        private void R7000_00_TRATA_FC0105B_SECTION()
        {
            /*" -5527- MOVE 'R7000-00-TRATA-FC0105B' TO PARAGRAFO. */
            _.Move("R7000-00-TRATA-FC0105B", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5528- MOVE 'TRATA FC0105B' TO COMANDO. */
            _.Move("TRATA FC0105B", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5530- DISPLAY PARAGRAFO. */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5532- PERFORM R7290-00-INSERT-MOVFEDCA THRU R7290-99-SAIDA. */

            R7290_00_INSERT_MOVFEDCA_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R7290_99_SAIDA*/


            /*" -5534- IF (WTEM-MOVFEDCA EQUAL 'SIM' ) OR (LK-OUT-COD-RETORNO NOT EQUAL ZEROS) */

            if ((WS_WORK_AREAS.WTEM_MOVFEDCA == "SIM") || (LK_OUT_COD_RETORNO != 00))
            {

                /*" -5535- GO TO R7000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/ //GOTO
                return;

                /*" -5537- END-IF. */
            }


            /*" -5537- PERFORM R7400-00-INSERT-COMFEDCA THRU R7400-99-SAIDA. */

            R7400_00_INSERT_COMFEDCA_SECTION();

            R7400_10_INSERT();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R7400_99_SAIDA*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7290-00-INSERT-MOVFEDCA-SECTION */
        private void R7290_00_INSERT_MOVFEDCA_SECTION()
        {
            /*" -5545- MOVE 'R7290-00-INSERT-MOVFEDCA' TO PARAGRAFO. */
            _.Move("R7290-00-INSERT-MOVFEDCA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5546- MOVE 'SELECT COMUNIC_FED_CAP_VA' TO COMANDO. */
            _.Move("SELECT COMUNIC_FED_CAP_VA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5548- DISPLAY PARAGRAFO. */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5552- MOVE 'NAO' TO WTEM-MOVFEDCA. */
            _.Move("NAO", WS_WORK_AREAS.WTEM_MOVFEDCA);

            /*" -5557- PERFORM R7290_00_INSERT_MOVFEDCA_DB_SELECT_1 */

            R7290_00_INSERT_MOVFEDCA_DB_SELECT_1();

            /*" -5560- IF SQLCODE EQUAL ZEROS OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -5562- MOVE 'SIM' TO WTEM-MOVFEDCA */
                _.Move("SIM", WS_WORK_AREAS.WTEM_MOVFEDCA);

                /*" -5563- GO TO R7290-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7290_99_SAIDA*/ //GOTO
                return;

                /*" -5564- ELSE */
            }
            else
            {


                /*" -5565- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5566- CONTINUE */

                    /*" -5567- ELSE */
                }
                else
                {


                    /*" -5568- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5569- END-IF */
                }


                /*" -5571- END-IF */
            }


            /*" -5586- INITIALIZE LK-NUM-PLANO LK-NUM-SERIE LK-NUM-TITULO LK-NUM-PROPOSTA LK-QTD-TITULOS LK-VLR-TITULO LK-EMP-PARCEIRA LK-COD-RAMO LK-TRACE LK-OUT-COD-RETORNO LK-OUT-SQLCODE LK-OUT-MENSAGEM LK-OUT-SQLERRMC LK-OUT-SQLSTATE */
            _.Initialize(
                LK_NUM_PLANO
                , LK_NUM_SERIE
                , LK_NUM_TITULO
                , LK_NUM_PROPOSTA
                , LK_QTD_TITULOS
                , LK_VLR_TITULO
                , LK_EMP_PARCEIRA
                , LK_COD_RAMO
                , LK_TRACE
                , LK_OUT_COD_RETORNO
                , LK_OUT_SQLCODE
                , LK_OUT_MENSAGEM
                , LK_OUT_SQLERRMC
                , LK_OUT_SQLSTATE
            );

            /*" -5589- MOVE PRODVG-COD-RUBRICA TO LK-NUM-PLANO */
            _.Move(PRODVG_COD_RUBRICA, LK_NUM_PLANO);

            /*" -5592- MOVE PROPVA-NRCERTIF TO LK-NUM-PROPOSTA */
            _.Move(PROPVA_NRCERTIF, LK_NUM_PROPOSTA);

            /*" -5595- MOVE COBERP-QTTITCAP TO LK-QTD-TITULOS */
            _.Move(COBERP_QTTITCAP, LK_QTD_TITULOS);

            /*" -5598- MOVE COBERP-VLCUSTCAP TO LK-VLR-TITULO */
            _.Move(COBERP_VLCUSTCAP, LK_VLR_TITULO);

            /*" -5601- MOVE 0001 TO LK-EMP-PARCEIRA */
            _.Move(0001, LK_EMP_PARCEIRA);

            /*" -5604- MOVE PRODVG-COD-PRODUTO TO LK-COD-RAMO */
            _.Move(PRODVG_COD_PRODUTO, LK_COD_RAMO);

            /*" -5607- MOVE 'TRACE OFF' TO LK-TRACE */
            _.Move("TRACE OFF", LK_TRACE);

            /*" -5623- CALL 'FC0105B' USING LK-NUM-PLANO , LK-NUM-SERIE , LK-NUM-TITULO , LK-NUM-PROPOSTA , LK-QTD-TITULOS , LK-VLR-TITULO , LK-EMP-PARCEIRA , LK-COD-RAMO , LK-TRACE , LK-OUT-COD-RETORNO , LK-OUT-SQLCODE , LK-OUT-MENSAGEM , LK-OUT-SQLERRMC , LK-OUT-SQLSTATE . */
            _.Call("FC0105B", LK_NUM_PLANO, LK_NUM_SERIE, LK_NUM_TITULO, LK_NUM_PROPOSTA, LK_QTD_TITULOS, LK_VLR_TITULO, LK_EMP_PARCEIRA, LK_COD_RAMO, LK_TRACE, LK_OUT_COD_RETORNO, LK_OUT_SQLCODE, LK_OUT_MENSAGEM, LK_OUT_SQLERRMC, LK_OUT_SQLSTATE, RCAPS.DCLRCAPS);

            /*" -5624- IF LK-OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LK_OUT_COD_RETORNO != 00)
            {

                /*" -5625- MOVE LK-OUT-SQLCODE TO WS-SQLCODE */
                _.Move(LK_OUT_SQLCODE, WS_SQLCODE);

                /*" -5641- DISPLAY 'PROBLEMAS NO ACESSO A FC0105B ' ' ' LK-NUM-PLANO ' ' LK-NUM-SERIE ' ' LK-NUM-TITULO ' ' LK-NUM-PROPOSTA ' ' LK-QTD-TITULOS ' ' LK-VLR-TITULO ' ' LK-EMP-PARCEIRA ' ' LK-COD-RAMO ' ' LK-TRACE ' ' LK-OUT-COD-RETORNO ' ' LK-OUT-SQLCODE ' ' LK-OUT-MENSAGEM ' ' LK-OUT-SQLERRMC ' ' LK-OUT-SQLSTATE ' ' WS-SQLCODE */

                $"PROBLEMAS NO ACESSO A FC0105B  {LK_NUM_PLANO} {LK_NUM_SERIE} {LK_NUM_TITULO} {LK_NUM_PROPOSTA} {LK_QTD_TITULOS} {LK_VLR_TITULO} {LK_EMP_PARCEIRA} {LK_COD_RAMO} {LK_TRACE} {LK_OUT_COD_RETORNO} {LK_OUT_SQLCODE} {LK_OUT_MENSAGEM} {LK_OUT_SQLERRMC} {LK_OUT_SQLSTATE} {WS_SQLCODE}"
                .Display();

                /*" -5641- END-IF. */
            }


        }

        [StopWatch]
        /*" R7290-00-INSERT-MOVFEDCA-DB-SELECT-1 */
        public void R7290_00_INSERT_MOVFEDCA_DB_SELECT_1()
        {
            /*" -5557- EXEC SQL SELECT SITUACAO INTO :COMFEDCA-SITUACAO FROM SEGUROS.COMUNIC_FED_CAP_VA WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC. */

            var r7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1 = new R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1.Execute(r7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COMFEDCA_SITUACAO, COMFEDCA.DCLCOMUNIC_FED_CAP_VA.COMFEDCA_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7290_99_SAIDA*/

        [StopWatch]
        /*" R7400-00-INSERT-COMFEDCA-SECTION */
        private void R7400_00_INSERT_COMFEDCA_SECTION()
        {
            /*" -5649- MOVE 'R7400-00-INSERT-COMFEDCA' TO PARAGRAFO. */
            _.Move("R7400-00-INSERT-COMFEDCA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5650- MOVE 'INSERT COMFEDCA' TO COMANDO. */
            _.Move("INSERT COMFEDCA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5650- DISPLAY PARAGRAFO. */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -0- FLUXCONTROL_PERFORM R7400_10_INSERT */

            R7400_10_INSERT();

        }

        [StopWatch]
        /*" R7400-10-INSERT */
        private void R7400_10_INSERT(bool isPerform = false)
        {
            /*" -5666- PERFORM R7400_10_INSERT_DB_INSERT_1 */

            R7400_10_INSERT_DB_INSERT_1();

            /*" -5669- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5670- DISPLAY 'R7400 - ERRO NO INSERT DA TITFEDCA ' */
                _.Display($"R7400 - ERRO NO INSERT DA TITFEDCA ");

                /*" -5671- DISPLAY 'NRO CERTIFICADO - ' PROPVA-NRCERTIF */
                _.Display($"NRO CERTIFICADO - {PROPVA_NRCERTIF}");

                /*" -5672- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -5672- END-IF. */
            }


        }

        [StopWatch]
        /*" R7400-10-INSERT-DB-INSERT-1 */
        public void R7400_10_INSERT_DB_INSERT_1()
        {
            /*" -5666- EXEC SQL INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO , SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ( :PROPVA-NRCERTIF , '0' , :SISTEMA-DTMOVABE, CURRENT TIMESTAMP ) END-EXEC. */

            var r7400_10_INSERT_DB_INSERT_1_Insert1 = new R7400_10_INSERT_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            R7400_10_INSERT_DB_INSERT_1_Insert1.Execute(r7400_10_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7400_99_SAIDA*/

        [StopWatch]
        /*" M-8000-INTEGRA-VG-SECTION */
        private void M_8000_INTEGRA_VG_SECTION()
        {
            /*" -5684- MOVE '8000-INTEGRA-VG       ' TO PARAGRAFO. */
            _.Move("8000-INTEGRA-VG       ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5685- MOVE 'SELECT V0CONDTEC' TO COMANDO. */
            _.Move("SELECT V0CONDTEC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5687- DISPLAY PARAGRAFO. */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5688- MOVE 101 TO MCODOPER. */
            _.Move(101, MCODOPER);

            /*" -5696- PERFORM M_8000_INTEGRA_VG_DB_SELECT_1 */

            M_8000_INTEGRA_VG_DB_SELECT_1();

            /*" -5699- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5702- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5703- MOVE MDTMOVTO TO W02DTSQL. */
            _.Move(MDTMOVTO, WS_WORK_AREAS.W02DTSQL);

            /*" -5704- MOVE SISTEMA-DTMOVABE TO W03DTSQL. */
            _.Move(SISTEMA_DTMOVABE, WS_WORK_AREAS.W03DTSQL);

            /*" -5706- MOVE 01 TO W03DTSQL(9:2). */
            _.MoveAtPosition(01, WS_WORK_AREAS.W03DTSQL, 9, 2);

            /*" -5707- IF W02AAMMSQL > W03AAMMSQL */

            if (WS_WORK_AREAS.W02DTSQL.W02AAMMSQL > WS_WORK_AREAS.W03DTSQL.W03AAMMSQL)
            {

                /*" -5708- MOVE 01 TO W02DDSQL */
                _.Move(01, WS_WORK_AREAS.W02DTSQL.W02DDSQL);

                /*" -5709- MOVE W02DTSQL TO MDTREF */
                _.Move(WS_WORK_AREAS.W02DTSQL, MDTREF);

                /*" -5710- ELSE */
            }
            else
            {


                /*" -5712- MOVE W03DTSQL TO MDTREF. */
                _.Move(WS_WORK_AREAS.W03DTSQL, MDTREF);
            }


            /*" -5713- MOVE 'SELECT V0CLIENTE' TO COMANDO. */
            _.Move("SELECT V0CLIENTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5715- DISPLAY COMANDO */
            _.Display(WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5721- PERFORM M_8000_INTEGRA_VG_DB_SELECT_2 */

            M_8000_INTEGRA_VG_DB_SELECT_2();

            /*" -5724- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5726- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5727- IF CLIENT-DTNASC-I LESS ZEROES */

            if (CLIENT_DTNASC_I < 00)
            {

                /*" -5728- DISPLAY 'CLIENTE SEM DATA DE NASCIMENTO' */
                _.Display($"CLIENTE SEM DATA DE NASCIMENTO");

                /*" -5730- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5732- PERFORM 8500-CALC-PROP-AUTOM THRU 8500-FIM. */

            M_8500_CALC_PROP_AUTOM_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8500_FIM*/


            /*" -5736- IF INDAGE < 0 OR INDOPR < 0 OR INDNUM < 0 OR INDDIG < 0 */

            if (INDAGE < 0 || INDOPR < 0 || INDNUM < 0 || INDDIG < 0)
            {

                /*" -5737- MOVE PROPVA-AGECOBR TO MAGECOBR */
                _.Move(PROPVA_AGECOBR, MAGECOBR);

                /*" -5738- MOVE 0 TO MNUM-CTA-CORRENTE */
                _.Move(0, MNUM_CTA_CORRENTE);

                /*" -5739- MOVE ' ' TO MDAC-CTA-CORRENTE */
                _.Move(" ", MDAC_CTA_CORRENTE);

                /*" -5740- ELSE */
            }
            else
            {


                /*" -5741- MOVE OPCAOP-AGECTADEB TO MAGECOBR */
                _.Move(OPCAOP_AGECTADEB, MAGECOBR);

                /*" -5742- MOVE OPCAOP-OPRCTADEB TO WS-OPER-SEG */
                _.Move(OPCAOP_OPRCTADEB, WS_WORK_AREAS.WS_CTA_CORRENTE_R.WS_OPER_SEG);

                /*" -5743- MOVE OPCAOP-NUMCTADEB TO WS-CTA-SEG */
                _.Move(OPCAOP_NUMCTADEB, WS_WORK_AREAS.WS_CTA_CORRENTE_R.WS_CTA_SEG);

                /*" -5744- MOVE WS-CTA-CORRENTE TO MNUM-CTA-CORRENTE */
                _.Move(WS_WORK_AREAS.WS_CTA_CORRENTE, MNUM_CTA_CORRENTE);

                /*" -5745- MOVE OPCAOP-DIGCTADEB TO W01N0100 */
                _.Move(OPCAOP_DIGCTADEB, WS_WORK_AREAS.W01A0100.W01N0100);

                /*" -5747- MOVE W01A0100 TO MDAC-CTA-CORRENTE. */
                _.Move(WS_WORK_AREAS.W01A0100, MDAC_CTA_CORRENTE);
            }


            /*" -5748- MOVE '8000-INTEGRA-VG           ' TO PARAGRAFO. */
            _.Move("8000-INTEGRA-VG           ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5749- MOVE 'SELECT V0PLANOSVA' TO COMANDO. */
            _.Move("SELECT V0PLANOSVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5751- DISPLAY COMANDO */
            _.Display(WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5752- IF PROPVA-DTMOVTO < PROPVA-DTQITBCO */

            if (PROPVA_DTMOVTO < PROPVA_DTQITBCO)
            {

                /*" -5753- MOVE PROPVA-DTMOVTO TO WHOST-DTINIVIG */
                _.Move(PROPVA_DTMOVTO, WHOST_DTINIVIG);

                /*" -5754- ELSE */
            }
            else
            {


                /*" -5756- MOVE PROPVA-DTQITBCO TO WHOST-DTINIVIG. */
                _.Move(PROPVA_DTQITBCO, WHOST_DTINIVIG);
            }


            /*" -5758- PERFORM R7771-00-LER-PROP-SIVPF */

            R7771_00_LER_PROP_SIVPF_SECTION();

            /*" -5760- IF PROPVA-CODPRODU EQUAL 7705 OR JVPRD7705 OR 7707 */

            if (PROPVA_CODPRODU.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString(), "7707"))
            {

                /*" -5780- PERFORM M_8000_INTEGRA_VG_DB_SELECT_3 */

                M_8000_INTEGRA_VG_DB_SELECT_3();

                /*" -5782- ELSE */
            }
            else
            {


                /*" -5784- IF PROPVA-CODPRODU EQUAL 9753 OR 9754 */

                if (PROPVA_CODPRODU.In("9753", "9754"))
                {

                    /*" -5801- PERFORM M_8000_INTEGRA_VG_DB_SELECT_4 */

                    M_8000_INTEGRA_VG_DB_SELECT_4();

                    /*" -5803- ELSE */
                }
                else
                {


                    /*" -5821- PERFORM M_8000_INTEGRA_VG_DB_SELECT_5 */

                    M_8000_INTEGRA_VG_DB_SELECT_5();

                    /*" -5823- END-IF */
                }


                /*" -5825- END-IF. */
            }


            /*" -5827- MOVE SQLCODE TO WSQLCODE-PLANOS. */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WSQLCODE_PLANOS);

            /*" -5828- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5829- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5830- IF PRODVG-SITPLANCEF EQUAL 'N' */

                    if (PRODVG_SITPLANCEF == "N")
                    {

                        /*" -5833- MOVE 0 TO MFAIXA MTXVG MTXAPMA */
                        _.Move(0, MFAIXA, MTXVG, MTXAPMA);

                        /*" -5834- ELSE */
                    }
                    else
                    {


                        /*" -5845- DISPLAY '8000- PLANO NAO ENCONTRADO *' ' ' PROPVA-NRCERTIF ' ' PROPVA-NUM-APOLICE ' ' PROPVA-CODSUBES ' ' PROPVA-OPCAO-COBER ' ' WHOST-DTINIVIG ' ' CLIENT-DTNASC ' ' PROPVA-IDADE ' ' OPCAOP-PERIPGTO ' ' COBERP-VLPREMIO '****************************' */

                        $"8000- PLANO NAO ENCONTRADO * {PROPVA_NRCERTIF} {PROPVA_NUM_APOLICE} {PROPVA_CODSUBES} {PROPVA_OPCAO_COBER} {WHOST_DTINIVIG} {CLIENT_DTNASC} {PROPVA_IDADE} {OPCAOP_PERIPGTO} {COBERP_VLPREMIO}****************************"
                        .Display();

                        /*" -5846- GO TO 8000-FIM */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/ //GOTO
                        return;

                        /*" -5847- ELSE */
                    }

                }
                else
                {


                    /*" -5849- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5850- COMPUTE MTXAPIP = MTXAPMA / 2. */
            MTXAPIP.Value = MTXAPMA / 2f;

            /*" -5852- COMPUTE MTXAPMA = MTXAPMA - MTXAPIP. */
            MTXAPMA.Value = MTXAPMA - MTXAPIP;

            /*" -5854- PERFORM 8110-COUNT-BENEFICIARIOS THRU 8110-FIM. */

            M_8110_COUNT_BENEFICIARIOS_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8110_FIM*/


            /*" -5855- IF WHOST-COUNT EQUAL ZEROS */

            if (WHOST_COUNT == 00)
            {

                /*" -5856- MOVE ZEROS TO WS-CONT-BENEF */
                _.Move(0, WS_WORK_AREAS.WS_CONT_BENEF);

                /*" -5857- ELSE */
            }
            else
            {


                /*" -5859- MOVE 1 TO WS-CONT-BENEF. */
                _.Move(1, WS_WORK_AREAS.WS_CONT_BENEF);
            }


            /*" -5860- IF WS-CONT-BENEF EQUAL ZEROS */

            if (WS_WORK_AREAS.WS_CONT_BENEF == 00)
            {

                /*" -5861- MOVE 'S' TO MTPBENEF */
                _.Move("S", MTPBENEF);

                /*" -5862- ELSE */
            }
            else
            {


                /*" -5864- MOVE 'N' TO MTPBENEF. */
                _.Move("N", MTPBENEF);
            }


            /*" -5865- IF COBERP-IMPMORNATU NOT EQUAL 0 */

            if (COBERP_IMPMORNATU != 0)
            {

                /*" -5867- COMPUTE COBERP-IMPMORACID = COBERP-IMPMORACID - COBERP-IMPMORNATU */
                COBERP_IMPMORACID.Value = COBERP_IMPMORACID - COBERP_IMPMORNATU;

                /*" -5869- COMPUTE COBERP-IMPMORACID = COBERP-IMPMORACID - (COBERP-IMPMORNATU * CONDTE-IEA) / 100 */
                COBERP_IMPMORACID.Value = COBERP_IMPMORACID - (COBERP_IMPMORNATU * CONDTE_IEA) / 100f;

                /*" -5872- COMPUTE COBERP-IMPINVPERM = COBERP-IMPINVPERM - (COBERP-IMPMORNATU * CONDTE-IPA) / 100. */
                COBERP_IMPINVPERM.Value = COBERP_IMPINVPERM - (COBERP_IMPMORNATU * CONDTE_IPA) / 100f;
            }


            /*" -5873- IF COBERP-PRMAP EQUAL 0 */

            if (COBERP_PRMAP == 0)
            {

                /*" -5874- COMPUTE COBERP-IMPMORACID = 0 */
                COBERP_IMPMORACID.Value = 0;

                /*" -5882- COMPUTE COBERP-IMPINVPERM = 0. */
                COBERP_IMPINVPERM.Value = 0;
            }


            /*" -5883- MOVE 'SELECT MOVIMENTO_VGAP' TO COMANDO. */
            _.Move("SELECT MOVIMENTO_VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5885- DISPLAY COMANDO */
            _.Display(WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5893- PERFORM M_8000_INTEGRA_VG_DB_SELECT_6 */

            M_8000_INTEGRA_VG_DB_SELECT_6();

            /*" -5896- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5897- MOVE 'SIM' TO WTEM-MOVIMVGA */
                _.Move("SIM", WS_WORK_AREAS.WTEM_MOVIMVGA);

                /*" -5898- MOVE '3' TO PROPVA-SITUACAO */
                _.Move("3", PROPVA_SITUACAO);

                /*" -5899- GO TO 8000-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/ //GOTO
                return;

                /*" -5901- END-IF. */
            }


            /*" -5902- IF SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 100)
            {

                /*" -5903- DISPLAY 'ERRO SELECT MOVIMENTO_VGAP ' PROPVA-NRCERTIF */
                _.Display($"ERRO SELECT MOVIMENTO_VGAP {PROPVA_NRCERTIF}");

                /*" -5904- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -5904- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R8000_PROPAUTOM */

            R8000_PROPAUTOM();

        }

        [StopWatch]
        /*" M-8000-INTEGRA-VG-DB-SELECT-1 */
        public void M_8000_INTEGRA_VG_DB_SELECT_1()
        {
            /*" -5696- EXEC SQL SELECT GARAN_ADIC_IEA, GARAN_ADIC_IPA INTO :CONDTE-IEA, :CONDTE-IPA FROM SEGUROS.V0CONDTEC WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPVA-CODSUBES END-EXEC. */

            var m_8000_INTEGRA_VG_DB_SELECT_1_Query1 = new M_8000_INTEGRA_VG_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_8000_INTEGRA_VG_DB_SELECT_1_Query1.Execute(m_8000_INTEGRA_VG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDTE_IEA, CONDTE_IEA);
                _.Move(executed_1.CONDTE_IPA, CONDTE_IPA);
            }


        }

        [StopWatch]
        /*" R8000-PROPAUTOM */
        private void R8000_PROPAUTOM(bool isPerform = false)
        {
            /*" -5910- IF PROPVA-NUM-APOLICE = 109300000635 AND PROPVA-CODSUBES = 1 */

            if (PROPVA_NUM_APOLICE == 109300000635 && PROPVA_CODSUBES == 1)
            {

                /*" -5911- MOVE COBERP-DTINIVIG TO MMDTMOVTO */
                _.Move(COBERP_DTINIVIG, MMDTMOVTO);

                /*" -5912- MOVE COBERP-DTTERVIG TO WSISTEMA-DTMOVABE */
                _.Move(COBERP_DTTERVIG, WSISTEMA_DTMOVABE);

                /*" -5913- MOVE PROPVA-COD-CRM TO MMNUM-MATRICULA */
                _.Move(PROPVA_COD_CRM, MMNUM_MATRICULA);

                /*" -5914- MOVE V0COBER-MINOCOR TO MMFAIXA */
                _.Move(V0COBER_MINOCOR, MMFAIXA);

                /*" -5915- ELSE */
            }
            else
            {


                /*" -5916- MOVE MDTMOVTO TO MMDTMOVTO */
                _.Move(MDTMOVTO, MMDTMOVTO);

                /*" -5917- MOVE SISTEMA-DTMOVABE TO WSISTEMA-DTMOVABE */
                _.Move(SISTEMA_DTMOVABE, WSISTEMA_DTMOVABE);

                /*" -5918- MOVE MNUM-MATRICULA TO MMNUM-MATRICULA */
                _.Move(MNUM_MATRICULA, MMNUM_MATRICULA);

                /*" -5919- MOVE MFAIXA TO MMFAIXA */
                _.Move(MFAIXA, MMFAIXA);

                /*" -5921- END-IF */
            }


            /*" -5923- MOVE 101 TO MCODOPER. */
            _.Move(101, MCODOPER);

            /*" -5924- MOVE '8000-INTEGRA-VG           ' TO PARAGRAFO. */
            _.Move("8000-INTEGRA-VG           ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5925- MOVE 'INSERT V0MOVIMENTO' TO COMANDO. */
            _.Move("INSERT V0MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5927- DISPLAY COMANDO */
            _.Display(WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6004- PERFORM R8000_PROPAUTOM_DB_INSERT_1 */

            R8000_PROPAUTOM_DB_INSERT_1();

            /*" -6007- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -6008- MOVE 'SIM' TO WTEM-MOVIMVGA */
                _.Move("SIM", WS_WORK_AREAS.WTEM_MOVIMVGA);

                /*" -6010- END-IF. */
            }


            /*" -6011- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -6014- IF (SQLCODE EQUAL -803) AND (PROPVA-INRPROPOS LESS 0 OR PROPVA-NRPROPOS EQUAL 0) */

                if ((DB.SQLCODE == -803) && (PROPVA_INRPROPOS < 0 || PROPVA_NRPROPOS == 0))
                {

                    /*" -6015- ADD 1 TO FONTE-PROPAUTOM */
                    FONTE_PROPAUTOM.Value = FONTE_PROPAUTOM + 1;

                    /*" -6016- GO TO R8000-PROPAUTOM */
                    new Task(() => R8000_PROPAUTOM()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -6017- ELSE */
                }
                else
                {


                    /*" -6018- DISPLAY 'R8000-PROPAUTOM (ERRO INSERT V0MOVIMENTO)' */
                    _.Display($"R8000-PROPAUTOM (ERRO INSERT V0MOVIMENTO)");

                    /*" -6019- DISPLAY 'CERTIFICADO... ' PROPVA-NRCERTIF */
                    _.Display($"CERTIFICADO... {PROPVA_NRCERTIF}");

                    /*" -6020- DISPLAY 'PROPAUTOM..... ' FONTE-PROPAUTOM */
                    _.Display($"PROPAUTOM..... {FONTE_PROPAUTOM}");

                    /*" -6021- DISPLAY 'FONTE......... ' PROPVA-FONTE */
                    _.Display($"FONTE......... {PROPVA_FONTE}");

                    /*" -6022- DISPLAY 'SISTEMA-DTMOVABE  ' SISTEMA-DTMOVABE */
                    _.Display($"SISTEMA-DTMOVABE  {SISTEMA_DTMOVABE}");

                    /*" -6023- DISPLAY 'WSISTEMA-DTMOVABE ' WSISTEMA-DTMOVABE */
                    _.Display($"WSISTEMA-DTMOVABE {WSISTEMA_DTMOVABE}");

                    /*" -6024- DISPLAY ' PROPVA-DTADMIS   ' PROPVA-DTADMIS */
                    _.Display($" PROPVA-DTADMIS   {PROPVA_DTADMIS}");

                    /*" -6025- DISPLAY ' PROPVA-IDTADMIS ' PROPVA-IDTADMIS */
                    _.Display($" PROPVA-IDTADMIS {PROPVA_IDTADMIS}");

                    /*" -6026- DISPLAY 'CLIENT-DTNASC     ' CLIENT-DTNASC */
                    _.Display($"CLIENT-DTNASC     {CLIENT_DTNASC}");

                    /*" -6027- DISPLAY 'DATA REFERENCIA   ' MDTREF */
                    _.Display($"DATA REFERENCIA   {MDTREF}");

                    /*" -6028- DISPLAY 'MMDTMOVTO         ' MMDTMOVTO */
                    _.Display($"MMDTMOVTO         {MMDTMOVTO}");

                    /*" -6030- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -6032- PERFORM 8100-MONTA-BENEFICIARIOS THRU 8100-FIM. */

            M_8100_MONTA_BENEFICIARIOS_SECTION();

            M_8100_LOOP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8100_FIM*/


            /*" -6033- MOVE 'UPDATE V0FONTE' TO COMANDO. */
            _.Move("UPDATE V0FONTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6035- DISPLAY COMANDO */
            _.Display(WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6037- IF PROPVA-INRPROPOS LESS 0 OR PROPVA-NRPROPOS EQUAL 0 */

            if (PROPVA_INRPROPOS < 0 || PROPVA_NRPROPOS == 0)
            {

                /*" -6042- PERFORM R8000_PROPAUTOM_DB_UPDATE_1 */

                R8000_PROPAUTOM_DB_UPDATE_1();

                /*" -6044- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -6046- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -6049- IF PRODVG-ORIG-PRODU = 'MULT' OR 'GLOBAL' OR 'VIDAZUL' AND PROPVA-NUM-APOLICE NOT EQUAL 109300000635 AND OPCAOP-OPCAOPAG NOT EQUAL '5' */

            if (PRODVG_ORIG_PRODU.In("MULT", "GLOBAL", "VIDAZUL") && PROPVA_NUM_APOLICE != 109300000635 && OPCAOP_OPCAOPAG != "5")
            {

                /*" -6050- IF PROPVA-CODCCT EQUAL ZEROS */

                if (PROPVA_CODCCT == 00)
                {

                    /*" -6051- MOVE 'UPDATE V0PARCELVA' TO COMANDO */
                    _.Move("UPDATE V0PARCELVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -6058- PERFORM R8000_PROPAUTOM_DB_UPDATE_2 */

                    R8000_PROPAUTOM_DB_UPDATE_2();

                    /*" -6060- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -6062- GO TO 9999-ERRO. */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -6066- IF PRODVG-ORIG-PRODU = 'MULT' OR 'GLOBAL' OR 'VIDAZUL' AND OPCAOP-OPCAOPAG NOT EQUAL '5' AND PROPVA-CODCCT EQUAL ZEROS AND COBERP-VLPREMIO = V0HCOB-VLPRMTOT */

            if (PRODVG_ORIG_PRODU.In("MULT", "GLOBAL", "VIDAZUL") && OPCAOP_OPCAOPAG != "5" && PROPVA_CODCCT == 00 && COBERP_VLPREMIO == V0HCOB_VLPRMTOT)
            {

                /*" -6067- MOVE 'UPDATE V0HISTCONTABILVA' TO COMANDO */
                _.Move("UPDATE V0HISTCONTABILVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -6075- PERFORM R8000_PROPAUTOM_DB_UPDATE_3 */

                R8000_PROPAUTOM_DB_UPDATE_3();

                /*" -6078- IF SQLCODE NOT = ZEROS AND SQLCODE NOT = 100 */

                if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
                {

                    /*" -6079- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6080- END-IF */
                }


                /*" -6081- ELSE */
            }
            else
            {


                /*" -6085- IF PRODVG-ORIG-PRODU = 'MULT' OR 'GLOBAL' AND PROPVA-CODCCT EQUAL ZEROS AND COBERP-VLPREMIO NOT = V0HCOB-VLPRMTOT AND OPCAOP-OPCAOPAG NOT EQUAL '5' */

                if (PRODVG_ORIG_PRODU.In("MULT", "GLOBAL") && PROPVA_CODCCT == 00 && COBERP_VLPREMIO != V0HCOB_VLPRMTOT && OPCAOP_OPCAOPAG != "5")
                {

                    /*" -6087- PERFORM 8880-ACERTA-DIF-PREMIO THRU 8880-FIM. */

                    M_8880_ACERTA_DIF_PREMIO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8880_FIM*/

                }

            }


            /*" -6089- IF PRODVG-ORIG-PRODU = 'CAMP' AND OPCAOP-OPCAOPAG NOT EQUAL '5' */

            if (PRODVG_ORIG_PRODU == "CAMP" && OPCAOP_OPCAOPAG != "5")
            {

                /*" -6090- MOVE 'SELECT V0HISTCOBVA' TO COMANDO */
                _.Move("SELECT V0HISTCOBVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -6096- PERFORM R8000_PROPAUTOM_DB_SELECT_1 */

                R8000_PROPAUTOM_DB_SELECT_1();

                /*" -6098- IF SQLCODE = ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -6100- COMPUTE COBERP-VLPREMIO = COBERP-VLPREMIO * (1 - PRODVG-DESCONTO-ADESAO) */
                    COBERP_VLPREMIO.Value = COBERP_VLPREMIO * (1 - PRODVG_DESCONTO_ADESAO);

                    /*" -6102- COMPUTE COBERP-PRMVG = COBERP-PRMVG * (1 - PRODVG-DESCONTO-ADESAO) */
                    COBERP_PRMVG.Value = COBERP_PRMVG * (1 - PRODVG_DESCONTO_ADESAO);

                    /*" -6103- COMPUTE COBERP-PRMAP = V0HCOB-VLPRMTOT - COBERP-PRMVG */
                    COBERP_PRMAP.Value = V0HCOB_VLPRMTOT - COBERP_PRMVG;

                    /*" -6104- MOVE 'UPDATE V0HISTCONTABILVA' TO COMANDO */
                    _.Move("UPDATE V0HISTCONTABILVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -6112- PERFORM R8000_PROPAUTOM_DB_UPDATE_4 */

                    R8000_PROPAUTOM_DB_UPDATE_4();

                    /*" -6115- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

                    if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
                    {

                        /*" -6116- GO TO 9999-ERRO */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -6117- ELSE */
                    }
                    else
                    {


                        /*" -6118- MOVE 'UPDATE V0PARCELVA' TO COMANDO */
                        _.Move("UPDATE V0PARCELVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

                        /*" -6125- PERFORM R8000_PROPAUTOM_DB_UPDATE_5 */

                        R8000_PROPAUTOM_DB_UPDATE_5();

                        /*" -6127- IF SQLCODE NOT EQUAL ZEROES */

                        if (DB.SQLCODE != 00)
                        {

                            /*" -6128- GO TO 9999-ERRO */

                            M_9999_ERRO_SECTION(); //GOTO
                            return;

                            /*" -6129- END-IF */
                        }


                        /*" -6130- IF COBERP-VLPREMIO NOT = V0HCOB-VLPRMTOT */

                        if (COBERP_VLPREMIO != V0HCOB_VLPRMTOT)
                        {

                            /*" -6131- PERFORM 8880-ACERTA-DIF-PREMIO THRU 8880-FIM */

                            M_8880_ACERTA_DIF_PREMIO_SECTION();
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8880_FIM*/


                            /*" -6132- END-IF */
                        }


                        /*" -6133- ELSE */
                    }

                }
                else
                {


                    /*" -6135- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -6137- IF PRODVG-TEM-CDG = 'S' AND COBERP-VLCUSTCDG NOT EQUAL 0 */

            if (PRODVG_TEM_CDG == "S" && COBERP_VLCUSTCDG != 0)
            {

                /*" -6139- PERFORM 8200-CONCEDE-CDG THRU 8200-FIM. */

                M_8200_CONCEDE_CDG_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/

            }


            /*" -6141- IF PRODVG-TEM-SAF = 'S' AND COBERP-VLCUSTAUXF GREATER 0 */

            if (PRODVG_TEM_SAF == "S" && COBERP_VLCUSTAUXF > 0)
            {

                /*" -6143- PERFORM 8300-CONCEDE-SAF THRU 8300-FIM. */

                M_8300_CONCEDE_SAF_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8300_FIM*/

            }


            /*" -6144- IF PROPVA-CODOPER EQUAL ZEROS */

            if (PROPVA_CODOPER == 00)
            {

                /*" -6146- MOVE 101 TO PROPVA-CODOPER. */
                _.Move(101, PROPVA_CODOPER);
            }


            /*" -6148- MOVE '3' TO PROPVA-SITUACAO. */
            _.Move("3", PROPVA_SITUACAO);

            /*" -6149- MOVE 'SELECT V0COMISICOBVA' TO COMANDO. */
            _.Move("SELECT V0COMISICOBVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6151- DISPLAY COMANDO */
            _.Display(WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6158- PERFORM R8000_PROPAUTOM_DB_SELECT_2 */

            R8000_PROPAUTOM_DB_SELECT_2();

            /*" -6161- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -6163- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6165- IF PROPVA-CODPRODU EQUAL 9753 OR 9754 */

            if (PROPVA_CODPRODU.In("9753", "9754"))
            {

                /*" -6167- GO TO 8000-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/ //GOTO
                return;
            }


            /*" -6168- IF PRODVG-ORIG-PRODU = 'PAREN' OR 'CEF DEB CC' */

            if (PRODVG_ORIG_PRODU.In("PAREN", "CEF DEB CC"))
            {

                /*" -6170- GO TO 8000-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/ //GOTO
                return;
            }


            /*" -6171- IF PROPVA-ORIGEM-PROPOSTA NOT EQUAL 12 */

            if (PROPVA_ORIGEM_PROPOSTA != 12)
            {

                /*" -6171- PERFORM 8800-APROPRIA-FUNDO THRU 8800-FIM. */

                M_8800_APROPRIA_FUNDO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8800_FIM*/

            }


        }

        [StopWatch]
        /*" R8000-PROPAUTOM-DB-INSERT-1 */
        public void R8000_PROPAUTOM_DB_INSERT_1()
        {
            /*" -6004- EXEC SQL INSERT INTO SEGUROS.V0MOVIMENTO VALUES (:PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-FONTE, :FONTE-PROPAUTOM, '1' , :PROPVA-NRCERTIF, ' ' , :MTPINCLUS, :PROPVA-CODCLIEN, :MAGENCIADOR, 0, 0, 0, :MMFAIXA, 'S' , :MTPBENEF, :OPCAOP-PERIPGTO, 12, ' ' , :PROPVA-EST-CIV, :PROPVA-SEXO, 0, ' ' , 1, 1, 104, :MAGECOBR, ' ' , :MMNUM-MATRICULA, :MNUM-CTA-CORRENTE, :MDAC-CTA-CORRENTE, 0, ' ' , '1' , 0, 0, 0, 0, 0, :MTXAPMA, :MTXAPIP, 0, 0, 0, :MTXVG, 0, :COBERP-IMPMORNATU, 0, :COBERP-IMPMORACID, 0, :COBERP-IMPINVPERM, 0, :COBERP-IMPAMDS, 0, :COBERP-IMPDH, 0, :COBERP-IMPDIT, 0, :COBERP-PRMVG, 0, :COBERP-PRMAP, :MCODOPER, :SISTEMA-DTMOVABE, 0, '1' , :PROPVA-CODUSU, :WSISTEMA-DTMOVABE, :PROPVA-DTADMIS:PROPVA-IDTADMIS, NULL, :CLIENT-DTNASC, NULL, :MDTREF, :MMDTMOVTO, NULL, NULL) END-EXEC. */

            var r8000_PROPAUTOM_DB_INSERT_1_Insert1 = new R8000_PROPAUTOM_DB_INSERT_1_Insert1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                MTPINCLUS = MTPINCLUS.ToString(),
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                MAGENCIADOR = MAGENCIADOR.ToString(),
                MMFAIXA = MMFAIXA.ToString(),
                MTPBENEF = MTPBENEF.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                PROPVA_EST_CIV = PROPVA_EST_CIV.ToString(),
                PROPVA_SEXO = PROPVA_SEXO.ToString(),
                MAGECOBR = MAGECOBR.ToString(),
                MMNUM_MATRICULA = MMNUM_MATRICULA.ToString(),
                MNUM_CTA_CORRENTE = MNUM_CTA_CORRENTE.ToString(),
                MDAC_CTA_CORRENTE = MDAC_CTA_CORRENTE.ToString(),
                MTXAPMA = MTXAPMA.ToString(),
                MTXAPIP = MTXAPIP.ToString(),
                MTXVG = MTXVG.ToString(),
                COBERP_IMPMORNATU = COBERP_IMPMORNATU.ToString(),
                COBERP_IMPMORACID = COBERP_IMPMORACID.ToString(),
                COBERP_IMPINVPERM = COBERP_IMPINVPERM.ToString(),
                COBERP_IMPAMDS = COBERP_IMPAMDS.ToString(),
                COBERP_IMPDH = COBERP_IMPDH.ToString(),
                COBERP_IMPDIT = COBERP_IMPDIT.ToString(),
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                MCODOPER = MCODOPER.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                PROPVA_CODUSU = PROPVA_CODUSU.ToString(),
                WSISTEMA_DTMOVABE = WSISTEMA_DTMOVABE.ToString(),
                PROPVA_DTADMIS = PROPVA_DTADMIS.ToString(),
                PROPVA_IDTADMIS = PROPVA_IDTADMIS.ToString(),
                CLIENT_DTNASC = CLIENT_DTNASC.ToString(),
                MDTREF = MDTREF.ToString(),
                MMDTMOVTO = MMDTMOVTO.ToString(),
            };

            R8000_PROPAUTOM_DB_INSERT_1_Insert1.Execute(r8000_PROPAUTOM_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R8000-PROPAUTOM-DB-UPDATE-1 */
        public void R8000_PROPAUTOM_DB_UPDATE_1()
        {
            /*" -6042- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :FONTE-PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :PROPVA-FONTE END-EXEC */

            var r8000_PROPAUTOM_DB_UPDATE_1_Update1 = new R8000_PROPAUTOM_DB_UPDATE_1_Update1()
            {
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            R8000_PROPAUTOM_DB_UPDATE_1_Update1.Execute(r8000_PROPAUTOM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-8000-INTEGRA-VG-DB-SELECT-2 */
        public void M_8000_INTEGRA_VG_DB_SELECT_2()
        {
            /*" -5721- EXEC SQL SELECT DATA_NASCIMENTO INTO :CLIENT-DTNASC:CLIENT-DTNASC-I FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :PROPVA-CODCLIEN WITH UR END-EXEC. */

            var m_8000_INTEGRA_VG_DB_SELECT_2_Query1 = new M_8000_INTEGRA_VG_DB_SELECT_2_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            var executed_1 = M_8000_INTEGRA_VG_DB_SELECT_2_Query1.Execute(m_8000_INTEGRA_VG_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENT_DTNASC, CLIENT_DTNASC);
                _.Move(executed_1.CLIENT_DTNASC_I, CLIENT_DTNASC_I);
            }


        }

        [StopWatch]
        /*" R8000-PROPAUTOM-DB-UPDATE-2 */
        public void R8000_PROPAUTOM_DB_UPDATE_2()
        {
            /*" -6058- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET PRMVG = :COBERP-PRMVG, PRMAP = :COBERP-PRMAP, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 END-EXEC */

            var r8000_PROPAUTOM_DB_UPDATE_2_Update1 = new R8000_PROPAUTOM_DB_UPDATE_2_Update1()
            {
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            R8000_PROPAUTOM_DB_UPDATE_2_Update1.Execute(r8000_PROPAUTOM_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R8000-PROPAUTOM-DB-SELECT-1 */
        public void R8000_PROPAUTOM_DB_SELECT_1()
        {
            /*" -6096- EXEC SQL SELECT VLPRMTOT INTO :V0HCOB-VLPRMTOT FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 END-EXEC */

            var r8000_PROPAUTOM_DB_SELECT_1_Query1 = new R8000_PROPAUTOM_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = R8000_PROPAUTOM_DB_SELECT_1_Query1.Execute(r8000_PROPAUTOM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_VLPRMTOT, V0HCOB_VLPRMTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/

        [StopWatch]
        /*" R8000-PROPAUTOM-DB-UPDATE-3 */
        public void R8000_PROPAUTOM_DB_UPDATE_3()
        {
            /*" -6075- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET PRMVG = :COBERP-PRMVG, PRMAP = :COBERP-PRMAP, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 AND SITUACAO = '0' END-EXEC */

            var r8000_PROPAUTOM_DB_UPDATE_3_Update1 = new R8000_PROPAUTOM_DB_UPDATE_3_Update1()
            {
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            R8000_PROPAUTOM_DB_UPDATE_3_Update1.Execute(r8000_PROPAUTOM_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" M-8000-INTEGRA-VG-DB-SELECT-3 */
        public void M_8000_INTEGRA_VG_DB_SELECT_3()
        {
            /*" -5780- EXEC SQL SELECT FAIXA, TAXAVG, TAXAAP INTO :MFAIXA, :MTXVG, :MTXAPMA FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND OPCAO_COBER = :PROPVA-OPCAO-COBER AND COD_PLANO = :SIVPF-COD-PLANO AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG AND IDADE_INICIAL <= :PROPVA-IDADE AND IDADE_FINAL >= :PROPVA-IDADE AND PERIPGTO = :OPCAOP-PERIPGTO AND (IMPMORNATU = :COBERP-IMPMORNATU OR IMPMORNATU = 0) WITH UR END-EXEC */

            var m_8000_INTEGRA_VG_DB_SELECT_3_Query1 = new M_8000_INTEGRA_VG_DB_SELECT_3_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_OPCAO_COBER = PROPVA_OPCAO_COBER.ToString(),
                COBERP_IMPMORNATU = COBERP_IMPMORNATU.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                SIVPF_COD_PLANO = SIVPF_COD_PLANO.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
                PROPVA_IDADE = PROPVA_IDADE.ToString(),
            };

            var executed_1 = M_8000_INTEGRA_VG_DB_SELECT_3_Query1.Execute(m_8000_INTEGRA_VG_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MFAIXA, MFAIXA);
                _.Move(executed_1.MTXVG, MTXVG);
                _.Move(executed_1.MTXAPMA, MTXAPMA);
            }


        }

        [StopWatch]
        /*" R8000-PROPAUTOM-DB-SELECT-2 */
        public void R8000_PROPAUTOM_DB_SELECT_2()
        {
            /*" -6158- EXEC SQL SELECT VALADT INTO :COMISI-VALADT FROM SEGUROS.V0COMISICOBVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND SITUACAO <> '3' WITH UR END-EXEC. */

            var r8000_PROPAUTOM_DB_SELECT_2_Query1 = new R8000_PROPAUTOM_DB_SELECT_2_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = R8000_PROPAUTOM_DB_SELECT_2_Query1.Execute(r8000_PROPAUTOM_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COMISI_VALADT, COMISI_VALADT);
            }


        }

        [StopWatch]
        /*" R8000-PROPAUTOM-DB-UPDATE-4 */
        public void R8000_PROPAUTOM_DB_UPDATE_4()
        {
            /*" -6112- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET PRMVG = :COBERP-PRMVG, PRMAP = :COBERP-PRMAP, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 AND SITUACAO = '0' END-EXEC */

            var r8000_PROPAUTOM_DB_UPDATE_4_Update1 = new R8000_PROPAUTOM_DB_UPDATE_4_Update1()
            {
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            R8000_PROPAUTOM_DB_UPDATE_4_Update1.Execute(r8000_PROPAUTOM_DB_UPDATE_4_Update1);

        }

        [StopWatch]
        /*" M-8110-COUNT-BENEFICIARIOS-SECTION */
        private void M_8110_COUNT_BENEFICIARIOS_SECTION()
        {
            /*" -6183- MOVE '8110-COUNT-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("8110-COUNT-BENEFICIARIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6184- MOVE 'SELECT V0BENEPROPAZ' TO COMANDO. */
            _.Move("SELECT V0BENEPROPAZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6186- DISPLAY PARAGRAFO. */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6188- MOVE PROPVA-NRCERTIF TO PROPVA-NRPROPAZ. */
            _.Move(PROPVA_NRCERTIF, PROPVA_NRPROPAZ);

            /*" -6198- PERFORM M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1 */

            M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1();

            /*" -6201- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6201- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8110-COUNT-BENEFICIARIOS-DB-SELECT-1 */
        public void M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1()
        {
            /*" -6198- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WHOST-COUNT FROM SEGUROS.V0BENEFPROPAZ WHERE NRPROPAZ = :PROPVA-NRPROPAZ AND AGELOTE = 0 AND DTLOTE = 0 AND NRLOTE = 0 AND NRSEQLOTE = 0 WITH UR END-EXEC. */

            var m_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1 = new M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1()
            {
                PROPVA_NRPROPAZ = PROPVA_NRPROPAZ.ToString(),
            };

            var executed_1 = M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1.Execute(m_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }

        [StopWatch]
        /*" R8000-PROPAUTOM-DB-UPDATE-5 */
        public void R8000_PROPAUTOM_DB_UPDATE_5()
        {
            /*" -6125- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET PRMVG = :COBERP-PRMVG, PRMAP = :COBERP-PRMAP, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 END-EXEC */

            var r8000_PROPAUTOM_DB_UPDATE_5_Update1 = new R8000_PROPAUTOM_DB_UPDATE_5_Update1()
            {
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            R8000_PROPAUTOM_DB_UPDATE_5_Update1.Execute(r8000_PROPAUTOM_DB_UPDATE_5_Update1);

        }

        [StopWatch]
        /*" M-8000-INTEGRA-VG-DB-SELECT-4 */
        public void M_8000_INTEGRA_VG_DB_SELECT_4()
        {
            /*" -5801- EXEC SQL SELECT FAIXA, TAXAVG, TAXAAP INTO :MFAIXA, :MTXVG, :MTXAPMA FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND OPCAO_COBER = :PROPVA-OPCAO-COBER AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG AND IDADE_INICIAL <= :PROPVA-IDADE AND IDADE_FINAL >= :PROPVA-IDADE AND PERIPGTO = :OPCAOP-PERIPGTO WITH UR END-EXEC */

            var m_8000_INTEGRA_VG_DB_SELECT_4_Query1 = new M_8000_INTEGRA_VG_DB_SELECT_4_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_OPCAO_COBER = PROPVA_OPCAO_COBER.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
                PROPVA_IDADE = PROPVA_IDADE.ToString(),
            };

            var executed_1 = M_8000_INTEGRA_VG_DB_SELECT_4_Query1.Execute(m_8000_INTEGRA_VG_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MFAIXA, MFAIXA);
                _.Move(executed_1.MTXVG, MTXVG);
                _.Move(executed_1.MTXAPMA, MTXAPMA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8110_FIM*/

        [StopWatch]
        /*" M-8000-INTEGRA-VG-DB-SELECT-5 */
        public void M_8000_INTEGRA_VG_DB_SELECT_5()
        {
            /*" -5821- EXEC SQL SELECT FAIXA, TAXAVG, TAXAAP INTO :MFAIXA, :MTXVG, :MTXAPMA FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND OPCAO_COBER = :PROPVA-OPCAO-COBER AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG AND IDADE_INICIAL <= :PROPVA-IDADE AND IDADE_FINAL >= :PROPVA-IDADE AND PERIPGTO = :OPCAOP-PERIPGTO AND IMPMORNATU = :COBERP-IMPMORNATU WITH UR END-EXEC */

            var m_8000_INTEGRA_VG_DB_SELECT_5_Query1 = new M_8000_INTEGRA_VG_DB_SELECT_5_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_OPCAO_COBER = PROPVA_OPCAO_COBER.ToString(),
                COBERP_IMPMORNATU = COBERP_IMPMORNATU.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
                PROPVA_IDADE = PROPVA_IDADE.ToString(),
            };

            var executed_1 = M_8000_INTEGRA_VG_DB_SELECT_5_Query1.Execute(m_8000_INTEGRA_VG_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MFAIXA, MFAIXA);
                _.Move(executed_1.MTXVG, MTXVG);
                _.Move(executed_1.MTXAPMA, MTXAPMA);
            }


        }

        [StopWatch]
        /*" M-8100-MONTA-BENEFICIARIOS-SECTION */
        private void M_8100_MONTA_BENEFICIARIOS_SECTION()
        {
            /*" -6213- MOVE '8100-MONTA-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("8100-MONTA-BENEFICIARIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6214- MOVE 'DECLARE CBENEFP' TO COMANDO. */
            _.Move("DECLARE CBENEFP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6216- DISPLAY PARAGRAFO. */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6217- IF NAO-LEU-SIVPF */

            if (WS_WORK_AREAS.WS_LEITUA_SIVPF["NAO_LEU_SIVPF"])
            {

                /*" -6220- PERFORM R7771-00-LER-PROP-SIVPF THRU R7771-FIM. */

                R7771_00_LER_PROP_SIVPF_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7771_FIM*/

            }


            /*" -6221- IF WTEM-SIVPF EQUAL 1 */

            if (WS_WORK_AREAS.WTEM_SIVPF == 1)
            {

                /*" -6222- MOVE SIVPF-NR-SICOB TO PROPVA-NRPROPAZ */
                _.Move(SIVPF_NR_SICOB, PROPVA_NRPROPAZ);

                /*" -6223- ELSE */
            }
            else
            {


                /*" -6225- MOVE PROPVA-NRCERTIF TO PROPVA-NRPROPAZ. */
                _.Move(PROPVA_NRCERTIF, PROPVA_NRPROPAZ);
            }


            /*" -6237- PERFORM M_8100_MONTA_BENEFICIARIOS_DB_DECLARE_1 */

            M_8100_MONTA_BENEFICIARIOS_DB_DECLARE_1();

            /*" -6240- MOVE 'OPEN CBENEFP' TO COMANDO. */
            _.Move("OPEN CBENEFP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6240- PERFORM M_8100_MONTA_BENEFICIARIOS_DB_OPEN_1 */

            M_8100_MONTA_BENEFICIARIOS_DB_OPEN_1();

            /*" -6243- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6245- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6245- MOVE ZEROS TO WS-CONT-BENEF. */
            _.Move(0, WS_WORK_AREAS.WS_CONT_BENEF);

            /*" -0- FLUXCONTROL_PERFORM M_8100_LOOP */

            M_8100_LOOP();

        }

        [StopWatch]
        /*" M-8100-MONTA-BENEFICIARIOS-DB-OPEN-1 */
        public void M_8100_MONTA_BENEFICIARIOS_DB_OPEN_1()
        {
            /*" -6240- EXEC SQL OPEN CBENEFP END-EXEC. */

            CBENEFP.Open();

        }

        [StopWatch]
        /*" R7774-00-LER-RCAP-COMP-DB-DECLARE-1 */
        public void R7774_00_LER_RCAP_COMP_DB_DECLARE_1()
        {
            /*" -8152- EXEC SQL DECLARE C01_RCAPCOMP CURSOR FOR SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP, COD_OPERACAO FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 ORDER BY COD_OPERACAO DESC WITH UR END-EXEC */
            C01_RCAPCOMP = new VA0118B_C01_RCAPCOMP(true);
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

        [StopWatch]
        /*" M-8000-INTEGRA-VG-DB-SELECT-6 */
        public void M_8000_INTEGRA_VG_DB_SELECT_6()
        {
            /*" -5893- EXEC SQL SELECT DATA_MOVIMENTO INTO :WHOST-DATA-MOVIMENTO FROM SEGUROS.MOVIMENTO_VGAP WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND COD_OPERACAO = 101 FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var m_8000_INTEGRA_VG_DB_SELECT_6_Query1 = new M_8000_INTEGRA_VG_DB_SELECT_6_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_8000_INTEGRA_VG_DB_SELECT_6_Query1.Execute(m_8000_INTEGRA_VG_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATA_MOVIMENTO, WHOST_DATA_MOVIMENTO);
            }


        }

        [StopWatch]
        /*" M-8100-LOOP */
        private void M_8100_LOOP(bool isPerform = false)
        {
            /*" -6250- MOVE 'FETCH CBENEFP' TO COMANDO. */
            _.Move("FETCH CBENEFP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6252- DISPLAY COMANDO */
            _.Display(WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6257- PERFORM M_8100_LOOP_DB_FETCH_1 */

            M_8100_LOOP_DB_FETCH_1();

            /*" -6260- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6261- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6262- MOVE 'CLOSE CBENEFP' TO COMANDO */
                    _.Move("CLOSE CBENEFP", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -6262- PERFORM M_8100_LOOP_DB_CLOSE_1 */

                    M_8100_LOOP_DB_CLOSE_1();

                    /*" -6264- GO TO 8100-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8100_FIM*/ //GOTO
                    return;

                    /*" -6265- ELSE */
                }
                else
                {


                    /*" -6267- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -6269- ADD 1 TO WS-CONT-BENEF. */
            WS_WORK_AREAS.WS_CONT_BENEF.Value = WS_WORK_AREAS.WS_CONT_BENEF + 1;

            /*" -6271- MOVE WS-CONT-BENEF TO BENEF-NRBENEF. */
            _.Move(WS_WORK_AREAS.WS_CONT_BENEF, BENEF_NRBENEF);

            /*" -6272- MOVE 'INSERT V0BENEFIPROP' TO COMANDO. */
            _.Move("INSERT V0BENEFIPROP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6274- DISPLAY COMANDO */
            _.Display(WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6286- PERFORM M_8100_LOOP_DB_INSERT_1 */

            M_8100_LOOP_DB_INSERT_1();

            /*" -6289- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6290- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -6291- MOVE ZEROS TO WS-CONTA-803 */
                    _.Move(0, WS_WORK_AREAS.WS_CONTA_803);

                    /*" -6292- PERFORM 8120-VERIFICA-PROPAUTOM */

                    M_8120_VERIFICA_PROPAUTOM_SECTION();

                    /*" -6293- ELSE */
                }
                else
                {


                    /*" -6294- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6295- END-IF */
                }


                /*" -6297- END-IF. */
            }


            /*" -6297- GO TO 8100-LOOP. */
            new Task(() => M_8100_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" M-8100-LOOP-DB-FETCH-1 */
        public void M_8100_LOOP_DB_FETCH_1()
        {
            /*" -6257- EXEC SQL FETCH CBENEFP INTO :BENEF-NOMBENEF, :BENEF-GRAUPAR, :BENEF-PCTBENEF END-EXEC. */

            if (CBENEFP.Fetch())
            {
                _.Move(CBENEFP.BENEF_NOMBENEF, BENEF_NOMBENEF);
                _.Move(CBENEFP.BENEF_GRAUPAR, BENEF_GRAUPAR);
                _.Move(CBENEFP.BENEF_PCTBENEF, BENEF_PCTBENEF);
            }

        }

        [StopWatch]
        /*" M-8100-LOOP-DB-CLOSE-1 */
        public void M_8100_LOOP_DB_CLOSE_1()
        {
            /*" -6262- EXEC SQL CLOSE CBENEFP END-EXEC */

            CBENEFP.Close();

        }

        [StopWatch]
        /*" M-8100-LOOP-DB-INSERT-1 */
        public void M_8100_LOOP_DB_INSERT_1()
        {
            /*" -6286- EXEC SQL INSERT INTO SEGUROS.V0BENEFIPROP VALUES (:PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-FONTE, :FONTE-PROPAUTOM, :BENEF-NRBENEF, :BENEF-NOMBENEF, :BENEF-GRAUPAR, :BENEF-PCTBENEF, 'VA0118B' , NULL) END-EXEC. */

            var m_8100_LOOP_DB_INSERT_1_Insert1 = new M_8100_LOOP_DB_INSERT_1_Insert1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                BENEF_NRBENEF = BENEF_NRBENEF.ToString(),
                BENEF_NOMBENEF = BENEF_NOMBENEF.ToString(),
                BENEF_GRAUPAR = BENEF_GRAUPAR.ToString(),
                BENEF_PCTBENEF = BENEF_PCTBENEF.ToString(),
            };

            M_8100_LOOP_DB_INSERT_1_Insert1.Execute(m_8100_LOOP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8100_FIM*/

        [StopWatch]
        /*" M-8120-VERIFICA-PROPAUTOM-SECTION */
        private void M_8120_VERIFICA_PROPAUTOM_SECTION()
        {
            /*" -6309- MOVE '8120-VERIFICA-PROPAUTOM' TO PARAGRAFO. */
            _.Move("8120-VERIFICA-PROPAUTOM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6310- MOVE 'SELECT V0BENEFIPROP' TO COMANDO. */
            _.Move("SELECT V0BENEFIPROP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6310- DISPLAY PARAGRAFO. */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -0- FLUXCONTROL_PERFORM M_8120_INICIO_VERIFICA */

            M_8120_INICIO_VERIFICA();

        }

        [StopWatch]
        /*" M-8120-INICIO-VERIFICA */
        private void M_8120_INICIO_VERIFICA(bool isPerform = false)
        {
            /*" -6322- PERFORM M_8120_INICIO_VERIFICA_DB_SELECT_1 */

            M_8120_INICIO_VERIFICA_DB_SELECT_1();

            /*" -6325- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -6327- ADD 1 TO WS-CONTA-803 */
                WS_WORK_AREAS.WS_CONTA_803.Value = WS_WORK_AREAS.WS_CONTA_803 + 1;

                /*" -6328- IF WS-CONTA-803 > 10000 */

                if (WS_WORK_AREAS.WS_CONTA_803 > 10000)
                {

                    /*" -6329- DISPLAY 'NAO FOI POSSIVEL ENCONTRAR PROPOSTA ' */
                    _.Display($"NAO FOI POSSIVEL ENCONTRAR PROPOSTA ");

                    /*" -6330- DISPLAY 'AUTOMATICA DISPONIVEL PARA ESSA FONTE' */
                    _.Display($"AUTOMATICA DISPONIVEL PARA ESSA FONTE");

                    /*" -6331- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6332- ELSE */
                }
                else
                {


                    /*" -6334- ADD 1 TO FONTE-PROPAUTOM */
                    FONTE_PROPAUTOM.Value = FONTE_PROPAUTOM + 1;

                    /*" -6335- GO TO 8120-INICIO-VERIFICA */
                    new Task(() => M_8120_INICIO_VERIFICA()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -6336- END-IF */
                }


                /*" -6337- ELSE */
            }
            else
            {


                /*" -6338- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -6339- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6340- END-IF */
                }


                /*" -6340- END-IF. */
            }


        }

        [StopWatch]
        /*" M-8120-INICIO-VERIFICA-DB-SELECT-1 */
        public void M_8120_INICIO_VERIFICA_DB_SELECT_1()
        {
            /*" -6322- EXEC SQL SELECT NUM_PROPOSTA INTO :PROPAUTOM-BENEFI FROM SEGUROS.V0BENEFIPROP WHERE COD_FONTE = :PROPVA-FONTE AND NUM_PROPOSTA = :FONTE-PROPAUTOM AND NUM_BENEFICIARIO = :BENEF-NRBENEF WITH UR END-EXEC. */

            var m_8120_INICIO_VERIFICA_DB_SELECT_1_Query1 = new M_8120_INICIO_VERIFICA_DB_SELECT_1_Query1()
            {
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                BENEF_NRBENEF = BENEF_NRBENEF.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            var executed_1 = M_8120_INICIO_VERIFICA_DB_SELECT_1_Query1.Execute(m_8120_INICIO_VERIFICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPAUTOM_BENEFI, PROPAUTOM_BENEFI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8120_FIM*/

        [StopWatch]
        /*" M-8200-CONCEDE-CDG-SECTION */
        private void M_8200_CONCEDE_CDG_SECTION()
        {
            /*" -6352- MOVE '8200-CONCEDE-CDG ' TO PARAGRAFO. */
            _.Move("8200-CONCEDE-CDG ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6353- MOVE 'SELECT V0CDGCOBER' TO COMANDO. */
            _.Move("SELECT V0CDGCOBER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6355- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6361- PERFORM M_8200_CONCEDE_CDG_DB_SELECT_1 */

            M_8200_CONCEDE_CDG_DB_SELECT_1();

            /*" -6364- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -6365- IF CDGCOB-DTINIVIG > PROPVA-DTINICDG */

                if (CDGCOB_DTINIVIG > PROPVA_DTINICDG)
                {

                    /*" -6366- PERFORM 8210-ELIMINA-CDG THRU 8210-FIM */

                    M_8210_ELIMINA_CDG_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8210_FIM*/


                    /*" -6367- PERFORM 8220-INCLUI-CDG THRU 8220-FIM */

                    M_8220_INCLUI_CDG_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8220_FIM*/


                    /*" -6368- END-IF */
                }


                /*" -6369- ELSE */
            }
            else
            {


                /*" -6370- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6371- PERFORM 8220-INCLUI-CDG THRU 8220-FIM */

                    M_8220_INCLUI_CDG_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8220_FIM*/


                    /*" -6372- ELSE */
                }
                else
                {


                    /*" -6374- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -6376- MOVE PROPVA-DTQITBCO TO W01DTSQL. */
            _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);

            /*" -6377- IF OPCAOP-PERIPGTO GREATER 12 */

            if (OPCAOP_PERIPGTO > 12)
            {

                /*" -6378- COMPUTE WS-QTDE-ANOS = OPCAOP-PERIPGTO / 12 */
                WS_WORK_AREAS.WS_QTDE_ANOS.Value = OPCAOP_PERIPGTO / 12;

                /*" -6379- COMPUTE W01AASQL = W01AASQL + WS-QTDE-ANOS */
                WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + WS_WORK_AREAS.WS_QTDE_ANOS;

                /*" -6380- ELSE */
            }
            else
            {


                /*" -6381- ADD OPCAOP-PERIPGTO TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + OPCAOP_PERIPGTO;

                /*" -6382- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -6383- COMPUTE W01MMSQL = W01MMSQL - 12 */
                    WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL - 12;

                    /*" -6384- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -6385- END-IF */
                }


                /*" -6387- END-IF. */
            }


            /*" -6388- MOVE PROPVA-DTQITBCO TO W01DTSQL. */
            _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);

            /*" -6389- ADD OPCAOP-PERIPGTO TO W01MMSQL. */
            WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + OPCAOP_PERIPGTO;

            /*" -6390- IF W01MMSQL > 12 */

            if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
            {

                /*" -6391- COMPUTE W01MMSQL = W01MMSQL - 12 */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL - 12;

                /*" -6393- COMPUTE W01AASQL = W01AASQL + 1. */
                WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;
            }


            /*" -6394- MOVE 01 TO W01DDSQL. */
            _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

            /*" -6396- MOVE W01DTSQL TO REPCDG-DTREF. */
            _.Move(WS_WORK_AREAS.W01DTSQL, REPCDG_DTREF);

            /*" -6397- MOVE '8200-CONCEDE-CDG          ' TO PARAGRAFO. */
            _.Move("8200-CONCEDE-CDG          ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6398- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6400- MOVE 'SELECT V0REPASSECDG' TO COMANDO. */
            _.Move("SELECT V0REPASSECDG", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6406- PERFORM M_8200_CONCEDE_CDG_DB_SELECT_2 */

            M_8200_CONCEDE_CDG_DB_SELECT_2();

            /*" -6409- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6410- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6411- PERFORM 8230-INCLUI-REPASSE-CDG THRU 8230-FIM */

                    M_8230_INCLUI_REPASSE_CDG_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8230_FIM*/


                    /*" -6412- ELSE */
                }
                else
                {


                    /*" -6412- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-8200-CONCEDE-CDG-DB-SELECT-1 */
        public void M_8200_CONCEDE_CDG_DB_SELECT_1()
        {
            /*" -6361- EXEC SQL SELECT DTINIVIG INTO :CDGCOB-DTINIVIG FROM SEGUROS.V0CDGCOBER WHERE CODCLIEN = :PROPVA-CODCLIEN AND DTTERVIG = '9999-12-31' END-EXEC. */

            var m_8200_CONCEDE_CDG_DB_SELECT_1_Query1 = new M_8200_CONCEDE_CDG_DB_SELECT_1_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            var executed_1 = M_8200_CONCEDE_CDG_DB_SELECT_1_Query1.Execute(m_8200_CONCEDE_CDG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CDGCOB_DTINIVIG, CDGCOB_DTINIVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/

        [StopWatch]
        /*" M-8200-CONCEDE-CDG-DB-SELECT-2 */
        public void M_8200_CONCEDE_CDG_DB_SELECT_2()
        {
            /*" -6406- EXEC SQL SELECT DTREFER INTO :REPCDG-DTREF FROM SEGUROS.V0REPASSECDG WHERE CODCLIEN = :PROPVA-CODCLIEN AND DTREFER = :REPCDG-DTREF END-EXEC. */

            var m_8200_CONCEDE_CDG_DB_SELECT_2_Query1 = new M_8200_CONCEDE_CDG_DB_SELECT_2_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                REPCDG_DTREF = REPCDG_DTREF.ToString(),
            };

            var executed_1 = M_8200_CONCEDE_CDG_DB_SELECT_2_Query1.Execute(m_8200_CONCEDE_CDG_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.REPCDG_DTREF, REPCDG_DTREF);
            }


        }

        [StopWatch]
        /*" M-8210-ELIMINA-CDG-SECTION */
        private void M_8210_ELIMINA_CDG_SECTION()
        {
            /*" -6424- MOVE '8210-ELIMINA-CDG' TO PARAGRAFO. */
            _.Move("8210-ELIMINA-CDG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6425- MOVE 'DELETE V0CDGCOBER' TO COMANDO. */
            _.Move("DELETE V0CDGCOBER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6427- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6430- PERFORM M_8210_ELIMINA_CDG_DB_DELETE_1 */

            M_8210_ELIMINA_CDG_DB_DELETE_1();

            /*" -6433- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6433- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8210-ELIMINA-CDG-DB-DELETE-1 */
        public void M_8210_ELIMINA_CDG_DB_DELETE_1()
        {
            /*" -6430- EXEC SQL DELETE FROM SEGUROS.V0CDGCOBER WHERE CODCLIEN = :PROPVA-CODCLIEN END-EXEC. */

            var m_8210_ELIMINA_CDG_DB_DELETE_1_Delete1 = new M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1.Execute(m_8210_ELIMINA_CDG_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8210_FIM*/

        [StopWatch]
        /*" M-8220-INCLUI-CDG-SECTION */
        private void M_8220_INCLUI_CDG_SECTION()
        {
            /*" -6445- MOVE '8220-INCLUI-CDG' TO PARAGRAFO. */
            _.Move("8220-INCLUI-CDG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6446- MOVE 'INSERT V0CDGCOBER' TO COMANDO. */
            _.Move("INSERT V0CDGCOBER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6448- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6460- PERFORM M_8220_INCLUI_CDG_DB_INSERT_1 */

            M_8220_INCLUI_CDG_DB_INSERT_1();

            /*" -6463- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -6463- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8220-INCLUI-CDG-DB-INSERT-1 */
        public void M_8220_INCLUI_CDG_DB_INSERT_1()
        {
            /*" -6460- EXEC SQL INSERT INTO SEGUROS.V0CDGCOBER VALUES (:PROPVA-CODCLIEN, :PROPVA-DTINICDG, '9999-12-31' , :COBERP-IMPSEGCDG, :COBERP-VLCUSTCDG, :PROPVA-NRCERTIF, :PROPVA-OCORHIST, '0' , 'VA0118B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_8220_INCLUI_CDG_DB_INSERT_1_Insert1 = new M_8220_INCLUI_CDG_DB_INSERT_1_Insert1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                PROPVA_DTINICDG = PROPVA_DTINICDG.ToString(),
                COBERP_IMPSEGCDG = COBERP_IMPSEGCDG.ToString(),
                COBERP_VLCUSTCDG = COBERP_VLCUSTCDG.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
            };

            M_8220_INCLUI_CDG_DB_INSERT_1_Insert1.Execute(m_8220_INCLUI_CDG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8220_FIM*/

        [StopWatch]
        /*" M-8230-INCLUI-REPASSE-CDG-SECTION */
        private void M_8230_INCLUI_REPASSE_CDG_SECTION()
        {
            /*" -6475- MOVE '8230-INCLUI-REPASSE-CDG' TO PARAGRAFO. */
            _.Move("8230-INCLUI-REPASSE-CDG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6476- MOVE 'INSERT V0REPASSECDG' TO COMANDO. */
            _.Move("INSERT V0REPASSECDG", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6478- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6488- PERFORM M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1 */

            M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1();

            /*" -6491- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -6491- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8230-INCLUI-REPASSE-CDG-DB-INSERT-1 */
        public void M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1()
        {
            /*" -6488- EXEC SQL INSERT INTO SEGUROS.V0REPASSECDG VALUES (:PROPVA-CODCLIEN, :REPCDG-DTREF, :COBERP-VLCUSTCDG, :PROPVA-NRCERTIF, 1, '0' , :SISTEMA-DTMOVABE, CURRENT TIMESTAMP) END-EXEC. */

            var m_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1 = new M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                REPCDG_DTREF = REPCDG_DTREF.ToString(),
                COBERP_VLCUSTCDG = COBERP_VLCUSTCDG.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1.Execute(m_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8230_FIM*/

        [StopWatch]
        /*" M-8300-CONCEDE-SAF-SECTION */
        private void M_8300_CONCEDE_SAF_SECTION()
        {
            /*" -6503- MOVE '8300-CONCEDE-SAF ' TO PARAGRAFO. */
            _.Move("8300-CONCEDE-SAF ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6505- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6506- IF PRODVG-RISCO = 'N' */

            if (PRODVG_RISCO == "N")
            {

                /*" -6508- MOVE PROPVA-DTQITBCO TO PROPVA-DTINISAF. */
                _.Move(PROPVA_DTQITBCO, PROPVA_DTINISAF);
            }


            /*" -6510- MOVE 'SELECT V0SAFCOBER' TO COMANDO. */
            _.Move("SELECT V0SAFCOBER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6516- PERFORM M_8300_CONCEDE_SAF_DB_SELECT_1 */

            M_8300_CONCEDE_SAF_DB_SELECT_1();

            /*" -6519- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -6520- IF SAFCOB-DTINIVIG > PROPVA-DTINISAF */

                if (SAFCOB_DTINIVIG > PROPVA_DTINISAF)
                {

                    /*" -6521- PERFORM 8310-ELIMINA-SAF THRU 8310-FIM */

                    M_8310_ELIMINA_SAF_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8310_FIM*/


                    /*" -6522- PERFORM 8320-INCLUI-SAF THRU 8320-FIM */

                    M_8320_INCLUI_SAF_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8320_FIM*/


                    /*" -6523- END-IF */
                }


                /*" -6524- ELSE */
            }
            else
            {


                /*" -6525- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6526- PERFORM 8320-INCLUI-SAF THRU 8320-FIM */

                    M_8320_INCLUI_SAF_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8320_FIM*/


                    /*" -6527- ELSE */
                }
                else
                {


                    /*" -6529- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -6535- MOVE PROPVA-DTQITBCO TO W01DTSQL. */
            _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);

            /*" -6536- IF PRODVG-RISCO = '1' */

            if (PRODVG_RISCO == "1")
            {

                /*" -6538- ADD OPCAOP-PERIPGTO TO W01MMSQL. */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + OPCAOP_PERIPGTO;
            }


            /*" -6539- IF W01MMSQL > 12 */

            if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
            {

                /*" -6540- COMPUTE W01MMSQL = W01MMSQL - 12 */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL - 12;

                /*" -6542- COMPUTE W01AASQL = W01AASQL + 1. */
                WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;
            }


            /*" -6543- MOVE 01 TO W01DDSQL. */
            _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

            /*" -6545- MOVE W01DTSQL TO REPSAF-DTREF. */
            _.Move(WS_WORK_AREAS.W01DTSQL, REPSAF_DTREF);

            /*" -6546- MOVE '8300-CONCEDE-SAF          ' TO PARAGRAFO. */
            _.Move("8300-CONCEDE-SAF          ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6548- MOVE 'SELECT V0HISTREPSAF' TO COMANDO. */
            _.Move("SELECT V0HISTREPSAF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6554- PERFORM M_8300_CONCEDE_SAF_DB_SELECT_2 */

            M_8300_CONCEDE_SAF_DB_SELECT_2();

            /*" -6557- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -6558- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6559- PERFORM 8330-INCLUI-REPASSE-SAF THRU 8330-FIM */

                    M_8330_INCLUI_REPASSE_SAF_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8330_FIM*/


                    /*" -6560- ELSE */
                }
                else
                {


                    /*" -6561- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -6562- CONTINUE */

                        /*" -6563- ELSE */
                    }
                    else
                    {


                        /*" -6564- GO TO 9999-ERRO */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -6565- END-IF */
                    }


                    /*" -6566- END-IF */
                }


                /*" -6568- END-IF */
            }


            /*" -6568- . */

        }

        [StopWatch]
        /*" M-8300-CONCEDE-SAF-DB-SELECT-1 */
        public void M_8300_CONCEDE_SAF_DB_SELECT_1()
        {
            /*" -6516- EXEC SQL SELECT DTINIVIG INTO :SAFCOB-DTINIVIG FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :PROPVA-CODCLIEN AND DTTERVIG = '9999-12-31' END-EXEC. */

            var m_8300_CONCEDE_SAF_DB_SELECT_1_Query1 = new M_8300_CONCEDE_SAF_DB_SELECT_1_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            var executed_1 = M_8300_CONCEDE_SAF_DB_SELECT_1_Query1.Execute(m_8300_CONCEDE_SAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SAFCOB_DTINIVIG, SAFCOB_DTINIVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8300_FIM*/

        [StopWatch]
        /*" M-8300-CONCEDE-SAF-DB-SELECT-2 */
        public void M_8300_CONCEDE_SAF_DB_SELECT_2()
        {
            /*" -6554- EXEC SQL SELECT DTREF INTO :REPSAF-DTREF FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :PROPVA-CODCLIEN AND DTREF = :REPSAF-DTREF END-EXEC */

            var m_8300_CONCEDE_SAF_DB_SELECT_2_Query1 = new M_8300_CONCEDE_SAF_DB_SELECT_2_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                REPSAF_DTREF = REPSAF_DTREF.ToString(),
            };

            var executed_1 = M_8300_CONCEDE_SAF_DB_SELECT_2_Query1.Execute(m_8300_CONCEDE_SAF_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.REPSAF_DTREF, REPSAF_DTREF);
            }


        }

        [StopWatch]
        /*" M-8310-ELIMINA-SAF-SECTION */
        private void M_8310_ELIMINA_SAF_SECTION()
        {
            /*" -6580- MOVE '8310-ELIMINA-SAF' TO PARAGRAFO. */
            _.Move("8310-ELIMINA-SAF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6581- MOVE 'DELETE V0SAFCOBER' TO COMANDO. */
            _.Move("DELETE V0SAFCOBER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6583- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6586- PERFORM M_8310_ELIMINA_SAF_DB_DELETE_1 */

            M_8310_ELIMINA_SAF_DB_DELETE_1();

            /*" -6589- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6589- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8310-ELIMINA-SAF-DB-DELETE-1 */
        public void M_8310_ELIMINA_SAF_DB_DELETE_1()
        {
            /*" -6586- EXEC SQL DELETE FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :PROPVA-CODCLIEN END-EXEC. */

            var m_8310_ELIMINA_SAF_DB_DELETE_1_Delete1 = new M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1.Execute(m_8310_ELIMINA_SAF_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8310_FIM*/

        [StopWatch]
        /*" M-8320-INCLUI-SAF-SECTION */
        private void M_8320_INCLUI_SAF_SECTION()
        {
            /*" -6601- MOVE '8320-INCLUI-SAF' TO PARAGRAFO. */
            _.Move("8320-INCLUI-SAF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6602- MOVE 'INSERT V0SAFCOBER' TO COMANDO. */
            _.Move("INSERT V0SAFCOBER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6604- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6616- PERFORM M_8320_INCLUI_SAF_DB_INSERT_1 */

            M_8320_INCLUI_SAF_DB_INSERT_1();

            /*" -6619- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -6620- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -6621- CONTINUE */

                    /*" -6622- ELSE */
                }
                else
                {


                    /*" -6623- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6624- END-IF */
                }


                /*" -6626- END-IF */
            }


            /*" -6626- . */

        }

        [StopWatch]
        /*" M-8320-INCLUI-SAF-DB-INSERT-1 */
        public void M_8320_INCLUI_SAF_DB_INSERT_1()
        {
            /*" -6616- EXEC SQL INSERT INTO SEGUROS.V0SAFCOBER VALUES (:PROPVA-CODCLIEN, :PROPVA-DTINISAF, '9999-12-31' , :COBERP-IMPSEGAUXF, :COBERP-VLCUSTAUXF, :PROPVA-NRCERTIF, :PROPVA-OCORHIST, '0' , 'VA0118B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_8320_INCLUI_SAF_DB_INSERT_1_Insert1 = new M_8320_INCLUI_SAF_DB_INSERT_1_Insert1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                PROPVA_DTINISAF = PROPVA_DTINISAF.ToString(),
                COBERP_IMPSEGAUXF = COBERP_IMPSEGAUXF.ToString(),
                COBERP_VLCUSTAUXF = COBERP_VLCUSTAUXF.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
            };

            M_8320_INCLUI_SAF_DB_INSERT_1_Insert1.Execute(m_8320_INCLUI_SAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8320_FIM*/

        [StopWatch]
        /*" M-8330-INCLUI-REPASSE-SAF-SECTION */
        private void M_8330_INCLUI_REPASSE_SAF_SECTION()
        {
            /*" -6638- MOVE '8330-INCLUI-REPASE-SAF' TO PARAGRAFO. */
            _.Move("8330-INCLUI-REPASE-SAF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6639- MOVE 'INSERT V0HISTREPSAF INCLUSAO' TO COMANDO. */
            _.Move("INSERT V0HISTREPSAF INCLUSAO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6641- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6657- PERFORM M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1 */

            M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1();

            /*" -6660- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -6661- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -6662- CONTINUE */

                    /*" -6663- ELSE */
                }
                else
                {


                    /*" -6664- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6665- END-IF */
                }


                /*" -6668- END-IF */
            }


            /*" -6670- MOVE 'INSERT V0HISTREPSAF 1100' TO COMANDO. */
            _.Move("INSERT V0HISTREPSAF 1100", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6686- PERFORM M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2 */

            M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2();

            /*" -6689- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -6690- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -6691- CONTINUE */

                    /*" -6692- ELSE */
                }
                else
                {


                    /*" -6693- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6694- END-IF */
                }


                /*" -6696- END-IF */
            }


            /*" -6696- . */

        }

        [StopWatch]
        /*" M-8330-INCLUI-REPASSE-SAF-DB-INSERT-1 */
        public void M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1()
        {
            /*" -6657- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:PROPVA-CODCLIEN, :REPSAF-DTREF, :PROPVA-NRCERTIF, 1, :PROPVA-NRMATRFUN, :COBERP-VLCUSTAUXF, :PROPVA-CODOPER, '0' , '0' , 0, 0, 'VA0118B' , CURRENT TIMESTAMP, :PROPVA-DTQITBCO:VIND-DTMOVTO) END-EXEC. */

            var m_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1 = new M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                REPSAF_DTREF = REPSAF_DTREF.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_NRMATRFUN = PROPVA_NRMATRFUN.ToString(),
                COBERP_VLCUSTAUXF = COBERP_VLCUSTAUXF.ToString(),
                PROPVA_CODOPER = PROPVA_CODOPER.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1.Execute(m_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8330_FIM*/

        [StopWatch]
        /*" M-8330-INCLUI-REPASSE-SAF-DB-INSERT-2 */
        public void M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2()
        {
            /*" -6686- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:PROPVA-CODCLIEN, :REPSAF-DTREF, :PROPVA-NRCERTIF, 1, :PROPVA-NRMATRFUN, :COBERP-VLCUSTAUXF, 1100, '0' , '0' , 0, 0, 'VA0118B' , CURRENT TIMESTAMP, :PROPVA-DTQITBCO:VIND-DTMOVTO) END-EXEC. */

            var m_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1 = new M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                REPSAF_DTREF = REPSAF_DTREF.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_NRMATRFUN = PROPVA_NRMATRFUN.ToString(),
                COBERP_VLCUSTAUXF = COBERP_VLCUSTAUXF.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1.Execute(m_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" M-8500-CALC-PROP-AUTOM-SECTION */
        private void M_8500_CALC_PROP_AUTOM_SECTION()
        {
            /*" -6831- MOVE '8500-CALC-PROP-AUTOM' TO PARAGRAFO. */
            _.Move("8500-CALC-PROP-AUTOM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6832- MOVE 'SELECT V0FONTE' TO COMANDO. */
            _.Move("SELECT V0FONTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6834- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6836- IF PROPVA-INRPROPOS NOT LESS 0 AND PROPVA-NRPROPOS GREATER 0 */

            if (PROPVA_INRPROPOS >= 0 && PROPVA_NRPROPOS > 0)
            {

                /*" -6837- MOVE PROPVA-NRPROPOS TO FONTE-PROPAUTOM */
                _.Move(PROPVA_NRPROPOS, FONTE_PROPAUTOM);

                /*" -6840- GO TO 8500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8500_FIM*/ //GOTO
                return;
            }


            /*" -6845- PERFORM M_8500_CALC_PROP_AUTOM_DB_SELECT_1 */

            M_8500_CALC_PROP_AUTOM_DB_SELECT_1();

            /*" -6848- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6850- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6850- COMPUTE FONTE-PROPAUTOM = FONTE-PROPAUTOM + 1. */
            FONTE_PROPAUTOM.Value = FONTE_PROPAUTOM + 1;

        }

        [StopWatch]
        /*" M-8500-CALC-PROP-AUTOM-DB-SELECT-1 */
        public void M_8500_CALC_PROP_AUTOM_DB_SELECT_1()
        {
            /*" -6845- EXEC SQL SELECT PROPAUTOM INTO :FONTE-PROPAUTOM FROM SEGUROS.V0FONTE WHERE FONTE = :PROPVA-FONTE END-EXEC. */

            var m_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1 = new M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1()
            {
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            var executed_1 = M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1.Execute(m_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTE_PROPAUTOM, FONTE_PROPAUTOM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8500_FIM*/

        [StopWatch]
        /*" M-8550-00-PROCURA-RISCO-PROP-SECTION */
        private void M_8550_00_PROCURA_RISCO_PROP_SECTION()
        {
            /*" -6863- MOVE '8550-00-PROCURA-RISCO-PROP  ' TO PARAGRAFO. */
            _.Move("8550-00-PROCURA-RISCO-PROP  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6864- MOVE 'CALL SPBVG009               ' TO COMANDO. */
            _.Move("CALL SPBVG009               ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6866- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6867- MOVE 'N' TO LK-VG009-E-TRACE */
            _.Move("N", SPVG009W.LK_VG009_E_TRACE);

            /*" -6869- MOVE 'VA0118B' TO LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA */
            _.Move("VA0118B", SPVG009W.LK_VG009_E_COD_USUARIO, SPVG009W.LK_VG009_E_NOM_PROGRAMA);

            /*" -6870- MOVE 01 TO LK-VG009-E-TIPO-ACAO */
            _.Move(01, SPVG009W.LK_VG009_E_TIPO_ACAO);

            /*" -6872- MOVE PROPVA-NRCERTIF TO LK-VG009-E-NUM-PROPOSTA */
            _.Move(PROPVA_NRCERTIF, SPVG009W.LK_VG009_E_NUM_PROPOSTA);

            /*" -6873- MOVE 0 TO LK-VG009-IND-ERRO */
            _.Move(0, SPVG009W.LK_VG009_IND_ERRO);

            /*" -6875- MOVE SPACES TO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA */
            _.Move("", SPVG009W.LK_VG009_MSG_ERRO, SPVG009W.LK_VG009_NOM_TABELA);

            /*" -6876- MOVE 0 TO LK-VG009-SQLCODE */
            _.Move(0, SPVG009W.LK_VG009_SQLCODE);

            /*" -6878- MOVE SPACES TO LK-VG009-SQLERRMC */
            _.Move("", SPVG009W.LK_VG009_SQLERRMC);

            /*" -6880- MOVE 'SPBVG009' TO WS-PROGRAMA */
            _.Move("SPBVG009", WS_PROGRAMA);

            /*" -6901- CALL WS-PROGRAMA USING LK-VG009-E-TRACE LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA LK-VG009-E-TIPO-ACAO LK-VG009-E-NUM-PROPOSTA LK-VG009-S-COD-PESSOA LK-VG009-S-SEQ-PESSOA-HIST LK-VG009-S-COD-CLASSIF-RISCO LK-VG009-S-NUM-SCORE-RISCO LK-VG009-S-DTA-CLASSIF-RISCO LK-VG009-S-IND-PEND-APROVACAO LK-VG009-S-IND-DECL-AUTOMATICO LK-VG009-S-IND-ATLZ-FXA-RISCO LK-VG009-IND-ERRO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA LK-VG009-SQLCODE LK-VG009-SQLERRMC */
            _.Call(WS_PROGRAMA, SPVG009W);

            /*" -6902- IF LK-VG009-IND-ERRO NOT EQUAL ZEROS AND 001 */

            if (!SPVG009W.LK_VG009_IND_ERRO.In("00", "001"))
            {

                /*" -6903- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -6904- DISPLAY '* 8550 - PROBLEMAS CALL SUBROTINA SPBVG009    *' */
                _.Display($"* 8550 - PROBLEMAS CALL SUBROTINA SPBVG009    *");

                /*" -6905- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -6906- DISPLAY '* NUM-PROPOST: ' LK-VG009-E-NUM-PROPOSTA */
                _.Display($"* NUM-PROPOST: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                /*" -6907- DISPLAY '* TIPO-ACAO..: ' LK-VG009-E-TIPO-ACAO */
                _.Display($"* TIPO-ACAO..: {SPVG009W.LK_VG009_E_TIPO_ACAO}");

                /*" -6908- DISPLAY '* IND-ERRO...: ' LK-VG009-IND-ERRO */
                _.Display($"* IND-ERRO...: {SPVG009W.LK_VG009_IND_ERRO}");

                /*" -6909- DISPLAY '* MSG-ERRO...: ' LK-VG009-MSG-ERRO */
                _.Display($"* MSG-ERRO...: {SPVG009W.LK_VG009_MSG_ERRO}");

                /*" -6910- DISPLAY '* NOM-TABELA.: ' LK-VG009-NOM-TABELA */
                _.Display($"* NOM-TABELA.: {SPVG009W.LK_VG009_NOM_TABELA}");

                /*" -6911- DISPLAY '* SQLCODE....: ' LK-VG009-SQLCODE */
                _.Display($"* SQLCODE....: {SPVG009W.LK_VG009_SQLCODE}");

                /*" -6912- DISPLAY '* SQLERRMC...: ' LK-VG009-SQLERRMC */
                _.Display($"* SQLERRMC...: {SPVG009W.LK_VG009_SQLERRMC}");

                /*" -6913- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -6914- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -6915- END-IF */
            }


            /*" -6916- . */

            /*" -6918- MOVE 0 TO WS-ERRO-VG009 */
            _.Move(0, WS_ERRO_VG009);

            /*" -6919-  EVALUATE TRUE  */

            /*" -6920-  WHEN LK-VG009-IND-ERRO = 00  */

            /*" -6920- IF LK-VG009-IND-ERRO = 00 */

            if (SPVG009W.LK_VG009_IND_ERRO == 00)
            {

                /*" -6924- PERFORM 8560-00-GRAVA-CLASSIF-RISCO THRU 8560-99-SAIDA */

                M_8560_00_GRAVA_CLASSIF_RISCO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8560_99_SAIDA*/


                /*" -6925- IF LK-VG009-S-COD-CLASSIF-RISCO EQUAL 04 */

                if (SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO == 04)
                {

                    /*" -6927- DISPLAY 'DESPREZADO RISCO CRITICO.: ' PROPVA-NRCERTIF */
                    _.Display($"DESPREZADO RISCO CRITICO.: {PROPVA_NRCERTIF}");

                    /*" -6928- MOVE '1' TO PROPVA-SITUACAO */
                    _.Move("1", PROPVA_SITUACAO);

                    /*" -6929- ADD 1 TO WS-QT-RISCO-CRITICO */
                    WS_QT_RISCO_CRITICO.Value = WS_QT_RISCO_CRITICO + 1;

                    /*" -6930- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -6931- END-IF */
                }


                /*" -6932-  WHEN LK-VG009-IND-ERRO = 01  */

                /*" -6932- ELSE IF LK-VG009-IND-ERRO = 01 */
            }
            else

            if (SPVG009W.LK_VG009_IND_ERRO == 01)
            {

                /*" -6933- IF LK-VG009-SQLCODE = +100 */

                if (SPVG009W.LK_VG009_SQLCODE == +100)
                {

                    /*" -6935- PERFORM 8570-00-GRAVA-EMITE-SEM-RISCO THRU 8570-99-SAIDA */

                    M_8570_00_GRAVA_EMITE_SEM_RISCO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8570_99_SAIDA*/


                    /*" -6936- ELSE */
                }
                else
                {


                    /*" -6937- MOVE 1 TO WS-ERRO-VG009 */
                    _.Move(1, WS_ERRO_VG009);

                    /*" -6938- END-IF */
                }


                /*" -6939-  WHEN OTHER  */

                /*" -6939- ELSE */
            }
            else
            {


                /*" -6940- MOVE 1 TO WS-ERRO-VG009 */
                _.Move(1, WS_ERRO_VG009);

                /*" -6942-  END-EVALUATE  */

                /*" -6942- END-IF */
            }


            /*" -6943- IF WS-ERRO-VG009 NOT EQUAL ZEROS */

            if (WS_ERRO_VG009 != 00)
            {

                /*" -6944- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -6945- DISPLAY '* 8551 - PROBLEMAS CALL SUBROTINA SPBVG009    *' */
                _.Display($"* 8551 - PROBLEMAS CALL SUBROTINA SPBVG009    *");

                /*" -6946- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -6947- DISPLAY '* NUM-PROPOST: ' LK-VG009-E-NUM-PROPOSTA */
                _.Display($"* NUM-PROPOST: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                /*" -6948- DISPLAY '* TIPO-ACAO..: ' LK-VG009-E-TIPO-ACAO */
                _.Display($"* TIPO-ACAO..: {SPVG009W.LK_VG009_E_TIPO_ACAO}");

                /*" -6949- DISPLAY '* IND-ERRO...: ' LK-VG009-IND-ERRO */
                _.Display($"* IND-ERRO...: {SPVG009W.LK_VG009_IND_ERRO}");

                /*" -6950- DISPLAY '* MSG-ERRO...: ' LK-VG009-MSG-ERRO */
                _.Display($"* MSG-ERRO...: {SPVG009W.LK_VG009_MSG_ERRO}");

                /*" -6951- DISPLAY '* NOM-TABELA.: ' LK-VG009-NOM-TABELA */
                _.Display($"* NOM-TABELA.: {SPVG009W.LK_VG009_NOM_TABELA}");

                /*" -6952- DISPLAY '* SQLCODE....: ' LK-VG009-SQLCODE */
                _.Display($"* SQLCODE....: {SPVG009W.LK_VG009_SQLCODE}");

                /*" -6953- DISPLAY '* SQLERRMC...: ' LK-VG009-SQLERRMC */
                _.Display($"* SQLERRMC...: {SPVG009W.LK_VG009_SQLERRMC}");

                /*" -6955- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -6956- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -6957- END-IF */
            }


            /*" -6957- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8550_99_EXIT*/

        [StopWatch]
        /*" M-8560-00-GRAVA-CLASSIF-RISCO-SECTION */
        private void M_8560_00_GRAVA_CLASSIF_RISCO_SECTION()
        {
            /*" -6969- MOVE '8560-00-GRAVA-CLASSIF-RISCO  ' TO PARAGRAFO. */
            _.Move("8560-00-GRAVA-CLASSIF-RISCO  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6971- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6972- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -6973- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -6974- MOVE PROPVA-NRCERTIF TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPVA_NRCERTIF, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -6975- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -6976- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -6977- MOVE CLIENT-CGCCPF TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(CLIENT_CGCCPF, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -6978- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -6979- MOVE 'VA0118B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0118B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -6980- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -6981- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -6982- MOVE 35 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(35, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -6984- MOVE 'CADASTRAMENTO DE AVALIACAO DE RISCO' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("CADASTRAMENTO DE AVALIACAO DE RISCO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -6986- ADD 1 TO WS-QT-EMISSAO-C-RISCO */
            WS_QT_EMISSAO_C_RISCO.Value = WS_QT_EMISSAO_C_RISCO + 1;

            /*" -6988- EVALUATE LK-VG009-S-COD-CLASSIF-RISCO */
            switch (SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO.Value)
            {

                /*" -6989- WHEN 01 */
                case 01:

                    /*" -6991- MOVE 'PROPOSTA COM CLASSIFICACAO DE RISCO BAIXA' TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move("PROPOSTA COM CLASSIFICACAO DE RISCO BAIXA", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -6993- MOVE 2 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(2, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -6994- WHEN 02 */
                    break;
                case 02:

                    /*" -6996- MOVE 'PROPOSTA COM CLASSIFICACAO DE RISCO MODERADO' TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move("PROPOSTA COM CLASSIFICACAO DE RISCO MODERADO", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -6998- MOVE 3 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(3, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -6999- WHEN 03 */
                    break;
                case 03:

                    /*" -7001- MOVE 'PROPOSTA COM CLASSIFICACAO DE RISCO ELEVADO' TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move("PROPOSTA COM CLASSIFICACAO DE RISCO ELEVADO", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -7003- MOVE 4 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(4, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -7004- WHEN 04 */
                    break;
                case 04:

                    /*" -7006- MOVE 'PROPOSTA COM CLASSIFICACAO DE RISCO CRITICO' TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move("PROPOSTA COM CLASSIFICACAO DE RISCO CRITICO", VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -7007- MOVE 1 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(1, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -7008- WHEN OTHER */
                    break;
                default:

                    /*" -7011- DISPLAY 'ERRO - CLASSIFICACAO DE RISCO NAO CADASTRADA' LK-VG009-S-COD-CLASSIF-RISCO */
                    _.Display($"ERRO - CLASSIFICACAO DE RISCO NAO CADASTRADA{SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO}");

                    /*" -7012- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7014- END-EVALUATE */
                    break;
            }


            /*" -7016- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -7017- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -7018- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -7022- DISPLAY 'ERRO JAH GRAVADO 8560 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 8560 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -7023- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -7024- ELSE */
                }
                else
                {


                    /*" -7025- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -7026- DISPLAY '* 8560 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 8560 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -7027- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -7028- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -7029- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -7030- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -7031- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -7032- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -7033- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -7035- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -7036- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -7037- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7038- END-IF */
                }


                /*" -7040- END-IF */
            }


            /*" -7042- PERFORM 8590-00-GRAVA-ANDAMENTO-PROP THRU 8590-99-SAIDA */

            M_8590_00_GRAVA_ANDAMENTO_PROP_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8590_99_SAIDA*/


            /*" -7042- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8560_99_SAIDA*/

        [StopWatch]
        /*" M-8570-00-GRAVA-EMITE-SEM-RISCO-SECTION */
        private void M_8570_00_GRAVA_EMITE_SEM_RISCO_SECTION()
        {
            /*" -7054- MOVE '8570-00-GRAVA-EMITE-SEM-RISCO  ' TO PARAGRAFO. */
            _.Move("8570-00-GRAVA-EMITE-SEM-RISCO  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7055- MOVE 'CALL SPBVG001                  ' TO COMANDO. */
            _.Move("CALL SPBVG001                  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7057- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7058- MOVE 5 TO WS-COD-CRITICA */
            _.Move(5, WS_COD_CRITICA);

            /*" -7061- PERFORM 8580-00-CONS-COD-CRITICA THRU 8580-99-SAIDA */

            M_8580_00_CONS_COD_CRITICA_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8580_99_SAIDA*/


            /*" -7062- IF VG001-IND-EXISTE EQUAL 'S' */

            if (SPVG001V.VG001_IND_EXISTE == "S")
            {

                /*" -7063- GO TO 8570-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8570_99_SAIDA*/ //GOTO
                return;

                /*" -7067- END-IF */
            }


            /*" -7069- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -7070- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -7071- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -7072- MOVE PROPVA-NRCERTIF TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPVA_NRCERTIF, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -7073- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -7074- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -7075- MOVE CLIENT-CGCCPF TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(CLIENT_CGCCPF, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -7076- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -7077- MOVE 'VA0118B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0118B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -7078- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -7079- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -7080- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -7081- MOVE 5 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(5, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -7084- MOVE 'EMISSAO DE PROPOSTA SEM CLASSIFICACAO DE RISCO' TO LK-VG001-DES-COMPLEMENTAR-T VG078-DES-ANDAMENTO-TEXT */
            _.Move("EMISSAO DE PROPOSTA SEM CLASSIFICACAO DE RISCO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

            /*" -7086- ADD 1 TO WS-QT-EMISSAO-S-RISCO */
            WS_QT_EMISSAO_S_RISCO.Value = WS_QT_EMISSAO_S_RISCO + 1;

            /*" -7088- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -7089- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -7090- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -7094- DISPLAY 'ERRO JAH GRAVADO 8570 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 8570 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -7095- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -7096- ELSE */
                }
                else
                {


                    /*" -7097- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -7098- DISPLAY '* 8570 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 8570 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -7099- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -7100- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -7101- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -7102- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -7103- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -7104- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -7105- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -7107- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -7108- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -7109- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7110- END-IF */
                }


                /*" -7112- END-IF */
            }


            /*" -7114- PERFORM 8590-00-GRAVA-ANDAMENTO-PROP THRU 8590-99-SAIDA */

            M_8590_00_GRAVA_ANDAMENTO_PROP_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8590_99_SAIDA*/


            /*" -7114- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8570_99_SAIDA*/

        [StopWatch]
        /*" M-8580-00-CONS-COD-CRITICA-SECTION */
        private void M_8580_00_CONS_COD_CRITICA_SECTION()
        {
            /*" -7121- MOVE '8580-00-CONS-COD-CRITICA  ' TO PARAGRAFO. */
            _.Move("8580-00-CONS-COD-CRITICA  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7122- MOVE 'CALL SPBVG001             ' TO COMANDO. */
            _.Move("CALL SPBVG001             ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7124- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7125- MOVE 'N' TO VG001-IND-EXISTE */
            _.Move("N", SPVG001V.VG001_IND_EXISTE);

            /*" -7126- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -7127- MOVE 07 TO LK-VG001-TIPO-ACAO */
            _.Move(07, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -7128- MOVE PROPVA-NRCERTIF TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPVA_NRCERTIF, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -7129- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -7130- MOVE SPACES TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -7131- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -7132- MOVE WS-COD-CRITICA TO LK-VG001-COD-MSG-CRITICA */
            _.Move(WS_COD_CRITICA, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -7133- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -7134- MOVE 'VA0118B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0118B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -7135- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -7136- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -7137- MOVE 00 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(00, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -7139- MOVE SPACES TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -7141- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -7142- IF LK-VG001-IND-ERRO = 0 */

            if (SPVG001W.LK_VG001_IND_ERRO == 0)
            {

                /*" -7143- IF LK-VG001-S-NUM-CERTIFICADO > 0 */

                if (SPVG001W.LK_VG001_S_NUM_CERTIFICADO > 0)
                {

                    /*" -7144- MOVE 'S' TO VG001-IND-EXISTE */
                    _.Move("S", SPVG001V.VG001_IND_EXISTE);

                    /*" -7145- ELSE */
                }
                else
                {


                    /*" -7146- MOVE 'N' TO VG001-IND-EXISTE */
                    _.Move("N", SPVG001V.VG001_IND_EXISTE);

                    /*" -7147- END-IF */
                }


                /*" -7148- ELSE */
            }
            else
            {


                /*" -7149- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -7150- DISPLAY '* 8580 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                _.Display($"* 8580 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                /*" -7151- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -7152- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -7153- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -7154- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -7155- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -7156- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -7157- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -7159- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -7160- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -7161- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -7162- END-IF */
            }


            /*" -7162- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8580_99_SAIDA*/

        [StopWatch]
        /*" M-8590-00-GRAVA-ANDAMENTO-PROP-SECTION */
        private void M_8590_00_GRAVA_ANDAMENTO_PROP_SECTION()
        {
            /*" -7170- MOVE '8590-00-GRAVA-ANDAMENTO-PROP  ' TO PARAGRAFO. */
            _.Move("8590-00-GRAVA-ANDAMENTO-PROP  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7171- MOVE 'SELECT VG_ANDAMENTO_PROP      ' TO COMANDO. */
            _.Move("SELECT VG_ANDAMENTO_PROP      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7173- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7174- MOVE ZEROS TO WS-QTD-RISCO-GRAVADO */
            _.Move(0, WS_QTD_RISCO_GRAVADO);

            /*" -7176- MOVE PROPVA-NRCERTIF TO VG078-NUM-CERTIFICADO */
            _.Move(PROPVA_NRCERTIF, VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO);

            /*" -7184- PERFORM M_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1 */

            M_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1();

            /*" -7187- IF SQLCODE NOT EQUAL ZEROS AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -7188- DISPLAY '8590-00 (ERRO - SELECT VG_ANDAMENTO_PROP)' */
                _.Display($"8590-00 (ERRO - SELECT VG_ANDAMENTO_PROP)");

                /*" -7189- DISPLAY 'CERTIF: ' VG078-NUM-CERTIFICADO */
                _.Display($"CERTIF: {VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO}");

                /*" -7190- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -7192- END-IF */
            }


            /*" -7193- IF WS-QTD-RISCO-GRAVADO EQUAL ZEROS */

            if (WS_QTD_RISCO_GRAVADO == 00)
            {

                /*" -7195- PERFORM 0600-00-INSERE-ANDAMENTO THRU 0600-99-SAIDA */

                M_0600_00_INSERE_ANDAMENTO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0600_99_SAIDA*/


                /*" -7196- END-IF */
            }


            /*" -7196- . */

        }

        [StopWatch]
        /*" M-8590-00-GRAVA-ANDAMENTO-PROP-DB-SELECT-1 */
        public void M_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1()
        {
            /*" -7184- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :WS-QTD-RISCO-GRAVADO FROM SEGUROS.VG_ANDAMENTO_PROP WHERE NUM_CERTIFICADO = :VG078-NUM-CERTIFICADO AND DES_ANDAMENTO LIKE '%PROPOSTA COM CLASSIFICACAO DE RISCO%' WITH UR END-EXEC */

            var m_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1_Query1 = new M_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1_Query1()
            {
                VG078_NUM_CERTIFICADO = VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1_Query1.Execute(m_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QTD_RISCO_GRAVADO, WS_QTD_RISCO_GRAVADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8590_99_SAIDA*/

        [StopWatch]
        /*" M-8595-00-VERIFICA-CRTCA-PEND-SECTION */
        private void M_8595_00_VERIFICA_CRTCA_PEND_SECTION()
        {
            /*" -7204- MOVE '8595-00-VERIFICA-CRTCA-PEND  ' TO PARAGRAFO. */
            _.Move("8595-00-VERIFICA-CRTCA-PEND  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7205- MOVE 'SELECT VG_CRITICA_PROPOSTA   ' TO COMANDO. */
            _.Move("SELECT VG_CRITICA_PROPOSTA   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7207- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7209- MOVE ZEROS TO WS-ERRO-COUNT */
            _.Move(0, WS_ERRO_COUNT);

            /*" -7219- PERFORM M_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1 */

            M_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1();

            /*" -7222- IF SQLCODE NOT EQUAL ZEROS AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -7223- DISPLAY '8595-00 - PROBLEMAS NO SELECT(VG_CRITICA_PROP)' */
                _.Display($"8595-00 - PROBLEMAS NO SELECT(VG_CRITICA_PROP)");

                /*" -7224- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -7225- END-IF */
            }


            /*" -7225- . */

        }

        [StopWatch]
        /*" M-8595-00-VERIFICA-CRTCA-PEND-DB-SELECT-1 */
        public void M_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1()
        {
            /*" -7219- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :WS-ERRO-COUNT FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :PROPVA-NRCERTIF AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> 3 WITH UR END-EXEC. */

            var m_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1 = new M_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1.Execute(m_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_ERRO_COUNT, WS_ERRO_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8595_99_SAIDA*/

        [StopWatch]
        /*" M-8600-PRIMEIRA-COBRANCA-SECTION */
        private void M_8600_PRIMEIRA_COBRANCA_SECTION()
        {
            /*" -7237- MOVE '8600-PRIMEIRA-COBRANCA     ' TO PARAGRAFO. */
            _.Move("8600-PRIMEIRA-COBRANCA     ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7239- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7242- IF CANAL-VENDA-GITEL */

            if (WS_WORK_AREAS.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_GITEL"])
            {

                /*" -7243- MOVE PROPVA-DTVENCTO TO WS-DTVENCTO-AUX */
                _.Move(PROPVA_DTVENCTO, WS_WORK_AREAS.WS_DTVENCTO_AUX);

                /*" -7244- MOVE OPCAOP-DIA-DEB TO WS-VENCTO-DIA */
                _.Move(OPCAOP_DIA_DEB, WS_WORK_AREAS.WS_DTVENCTO_AUX.WS_VENCTO_DIA);

                /*" -7245- IF WS-DTVENCTO-AUX GREATER PROPVA-DTVENCTO */

                if (WS_WORK_AREAS.WS_DTVENCTO_AUX > PROPVA_DTVENCTO)
                {

                    /*" -7246- MOVE WS-DTVENCTO-AUX TO PROPVA-DTVENCTO */
                    _.Move(WS_WORK_AREAS.WS_DTVENCTO_AUX, PROPVA_DTVENCTO);

                    /*" -7247- ELSE */
                }
                else
                {


                    /*" -7248- ADD 1 TO WS-VENCTO-MES */
                    WS_WORK_AREAS.WS_DTVENCTO_AUX.WS_VENCTO_MES.Value = WS_WORK_AREAS.WS_DTVENCTO_AUX.WS_VENCTO_MES + 1;

                    /*" -7249- IF WS-VENCTO-MES GREATER 12 */

                    if (WS_WORK_AREAS.WS_DTVENCTO_AUX.WS_VENCTO_MES > 12)
                    {

                        /*" -7250- MOVE 1 TO WS-VENCTO-MES */
                        _.Move(1, WS_WORK_AREAS.WS_DTVENCTO_AUX.WS_VENCTO_MES);

                        /*" -7251- ADD 1 TO WS-VENCTO-ANO */
                        WS_WORK_AREAS.WS_DTVENCTO_AUX.WS_VENCTO_ANO.Value = WS_WORK_AREAS.WS_DTVENCTO_AUX.WS_VENCTO_ANO + 1;

                        /*" -7252- END-IF */
                    }


                    /*" -7253- MOVE WS-DTVENCTO-AUX TO PROPVA-DTVENCTO */
                    _.Move(WS_WORK_AREAS.WS_DTVENCTO_AUX, PROPVA_DTVENCTO);

                    /*" -7254- END-IF */
                }


                /*" -7256- END-IF. */
            }


            /*" -7261- IF CANAL-VENDA-GITEL OR PROPOSTA-CACB OR PROPOSTA-COPESP */

            if (WS_WORK_AREAS.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_GITEL"] || WS_WORK_AREAS.FILLER_6.W_CANAL_PROPOSTA1["PROPOSTA_CACB"] || WS_WORK_AREAS.FILLER_6.W_CANAL_PROPOSTA1["PROPOSTA_COPESP"])
            {

                /*" -7262- MOVE PROPVA-DTVENCTO TO HISTCB-DTVENCTO */
                _.Move(PROPVA_DTVENCTO, HISTCB_DTVENCTO);

                /*" -7263- GO TO 8600-10-CONTINUA */

                M_8600_10_CONTINUA(); //GOTO
                return;

                /*" -7265- END-IF. */
            }


            /*" -7266- IF PRODVG-COBERADIC-PREMIO = 'S' */

            if (PRODVG_COBERADIC_PREMIO == "S")
            {

                /*" -7267- CONTINUE */

                /*" -7268- ELSE */
            }
            else
            {


                /*" -7270- IF PRODVG-TEM-SAF = 'S' OR PRODVG-TEM-CDG = 'S' */

                if (PRODVG_TEM_SAF == "S" || PRODVG_TEM_CDG == "S")
                {

                    /*" -7274- COMPUTE COBERP-PRMVG = COBERP-PRMVG + COBERP-VLCUSTCDG + COBERP-VLCUSTCAP + COBERP-VLCUSTAUXF */
                    COBERP_PRMVG.Value = COBERP_PRMVG + COBERP_VLCUSTCDG + COBERP_VLCUSTCAP + COBERP_VLCUSTAUXF;

                    /*" -7275- END-IF */
                }


                /*" -7277- END-IF */
            }


            /*" -7278- MOVE SISTEMA-DTMOVABE2 TO W01DTSQL */
            _.Move(SISTEMA_DTMOVABE2, WS_WORK_AREAS.W01DTSQL);

            /*" -7279- MOVE OPCAOP-DIA-DEB TO W01DDSQL */
            _.Move(OPCAOP_DIA_DEB, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

            /*" -7280- IF W01DTSQL < SISTEMA-DTMOVABE2 */

            if (WS_WORK_AREAS.W01DTSQL < SISTEMA_DTMOVABE2)
            {

                /*" -7281- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -7282- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -7283- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -7284- ADD 1 TO W01AASQL */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -7285- END-IF */
                }


                /*" -7287- END-IF */
            }


            /*" -7288- PERFORM UNTIL W01DTSQL NOT LESS PROPVA-DTQITBCO */

            while (!(WS_WORK_AREAS.W01DTSQL >= PROPVA_DTQITBCO))
            {

                /*" -7289- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -7290- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -7291- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -7292- ADD 1 TO W01AASQL */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -7293- END-IF */
                }


                /*" -7295- END-PERFORM */
            }

            /*" -7296- IF W01DTSQL < PROPVA-DTQITBCO */

            if (WS_WORK_AREAS.W01DTSQL < PROPVA_DTQITBCO)
            {

                /*" -7297- MOVE PROPVA-DTQITBCO TO W01DTSQL */
                _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);

                /*" -7298- MOVE OPCAOP-DIA-DEB TO W01DDSQL */
                _.Move(OPCAOP_DIA_DEB, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

                /*" -7299- ELSE */
            }
            else
            {


                /*" -7300- IF W01DTSQL = PROPVA-DTQITBCO */

                if (WS_WORK_AREAS.W01DTSQL == PROPVA_DTQITBCO)
                {

                    /*" -7306- PERFORM M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1 */

                    M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1();

                    /*" -7308- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -7309- DISPLAY 'ERRO NO AJUSTE NA DATA DE VENCIMENTO' */
                        _.Display($"ERRO NO AJUSTE NA DATA DE VENCIMENTO");

                        /*" -7310- DISPLAY 'CERTIFICADO = ' PROPVA-NRCERTIF */
                        _.Display($"CERTIFICADO = {PROPVA_NRCERTIF}");

                        /*" -7311- GO TO 9999-ERRO */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -7312- ELSE */
                    }
                    else
                    {


                        /*" -7313- MOVE W03-VENCIMENTO TO W01DTSQL */
                        _.Move(W03_VENCIMENTO, WS_WORK_AREAS.W01DTSQL);

                        /*" -7314- END-IF */
                    }


                    /*" -7315- END-IF */
                }


                /*" -7317- END-IF */
            }


            /*" -7317- MOVE W01DTSQL TO HISTCB-DTVENCTO. */
            _.Move(WS_WORK_AREAS.W01DTSQL, HISTCB_DTVENCTO);

            /*" -0- FLUXCONTROL_PERFORM M_8600_10_CONTINUA */

            M_8600_10_CONTINUA();

        }

        [StopWatch]
        /*" M-8600-PRIMEIRA-COBRANCA-DB-SELECT-1 */
        public void M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1()
        {
            /*" -7306- EXEC SQL SELECT DATE(:PROPVA-DTQITBCO) + 5 DAYS INTO :W03-VENCIMENTO FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VA' WITH UR END-EXEC */

            var m_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1 = new M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1()
            {
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
            };

            var executed_1 = M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1.Execute(m_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W03_VENCIMENTO, W03_VENCIMENTO);
            }


        }

        [StopWatch]
        /*" M-8600-10-CONTINUA */
        private void M_8600_10_CONTINUA(bool isPerform = false)
        {
            /*" -7322- MOVE '8600-10-CONTINUA' TO PARAGRAFO. */
            _.Move("8600-10-CONTINUA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7325- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7326- IF OPCAOP-OPCAOPAG EQUAL '1' OR '2' */

            if (OPCAOP_OPCAOPAG.In("1", "2"))
            {

                /*" -7327- MOVE 1 TO PARCEL-OCORHIST */
                _.Move(1, PARCEL_OCORHIST);

                /*" -7328- ELSE */
            }
            else
            {


                /*" -7329- MOVE 0 TO PARCEL-OCORHIST */
                _.Move(0, PARCEL_OCORHIST);

                /*" -7331- END-IF */
            }


            /*" -7332- IF PROPVA-IDTADMIS LESS ZEROS */

            if (PROPVA_IDTADMIS < 00)
            {

                /*" -7333- MOVE '1900-01-01' TO DESCON-DTINIVIG */
                _.Move("1900-01-01", DESCON_DTINIVIG);

                /*" -7334- ELSE */
            }
            else
            {


                /*" -7335- MOVE PROPVA-DTADMIS TO DESCON-DTINIVIG */
                _.Move(PROPVA_DTADMIS, DESCON_DTINIVIG);

                /*" -7337- END-IF */
            }


            /*" -7338- MOVE '8600-PRIMEIRA-COBRANCA' TO PARAGRAFO. */
            _.Move("8600-PRIMEIRA-COBRANCA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7340- MOVE 'SELECT VG_PARCELAS_DESCON ' TO COMANDO. */
            _.Move("SELECT VG_PARCELAS_DESCON ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7350- PERFORM M_8600_10_CONTINUA_DB_SELECT_1 */

            M_8600_10_CONTINUA_DB_SELECT_1();

            /*" -7353- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7354- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7355- MOVE 0,00 TO DESCON-PERC */
                    _.Move(0.00, DESCON_PERC);

                    /*" -7356- ELSE */
                }
                else
                {


                    /*" -7357- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7358- END-IF */
                }


                /*" -7360- END-IF */
            }


            /*" -7362- COMPUTE DESCON-VLPREMIO = COBERP-VLPREMIO * (1 - DESCON-PERC). */
            DESCON_VLPREMIO.Value = COBERP_VLPREMIO * (1 - DESCON_PERC);

            /*" -7363- COMPUTE DESCON-PRMVG = COBERP-PRMVG * DESCON-PERC. */
            DESCON_PRMVG.Value = COBERP_PRMVG * DESCON_PERC;

            /*" -7365- COMPUTE DESCON-PRMAP = COBERP-PRMAP * DESCON-PERC. */
            DESCON_PRMAP.Value = COBERP_PRMAP * DESCON_PERC;

            /*" -7366- MOVE DESCON-VLPREMIO TO WHOST-VLPREMIO. */
            _.Move(DESCON_VLPREMIO, WHOST_VLPREMIO);

            /*" -7368- MOVE DESCON-VLPREMIO TO WHOST-VLPREMIO-W. */
            _.Move(DESCON_VLPREMIO, WHOST_VLPREMIO_W);

            /*" -7370- MOVE 'INSERT V0PARCELVA' TO COMANDO. */
            _.Move("INSERT V0PARCELVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7382- PERFORM M_8600_10_CONTINUA_DB_INSERT_1 */

            M_8600_10_CONTINUA_DB_INSERT_1();

            /*" -7385- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7386- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -7387- DISPLAY ' PARCELA JA INCLUIDA       ' */
                    _.Display($" PARCELA JA INCLUIDA       ");

                    /*" -7388- DISPLAY ' NAO SERA NOVAMENTE GERADA ' PROPVA-NRCERTIF */
                    _.Display($" NAO SERA NOVAMENTE GERADA {PROPVA_NRCERTIF}");

                    /*" -7389- GO TO 8600-CONTINUA */

                    M_8600_CONTINUA(); //GOTO
                    return;

                    /*" -7390- ELSE */
                }
                else
                {


                    /*" -7391- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7392- END-IF */
                }


                /*" -7395- END-IF */
            }


            /*" -7396- IF OPCAOP-OPCAOPAG EQUAL '1' OR '2' */

            if (OPCAOP_OPCAOPAG.In("1", "2"))
            {

                /*" -7397- PERFORM 8700-GERA-DEBITO THRU 8700-FIM */

                M_8700_GERA_DEBITO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8700_FIM*/


                /*" -7397- END-IF. */
            }


        }

        [StopWatch]
        /*" M-8600-10-CONTINUA-DB-SELECT-1 */
        public void M_8600_10_CONTINUA_DB_SELECT_1()
        {
            /*" -7350- EXEC SQL SELECT PCT_PARCELA_DESC INTO :DESCON-PERC FROM SEGUROS.VG_PARCELAS_DESCON WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPVA-CODSUBES AND NUM_PARCELA_DESC = 1 AND DT_INIVIG_PARCDESC <= :DESCON-DTINIVIG AND DT_TERVIG_PARCDESC >= :DESCON-DTINIVIG WITH UR END-EXEC. */

            var m_8600_10_CONTINUA_DB_SELECT_1_Query1 = new M_8600_10_CONTINUA_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                DESCON_DTINIVIG = DESCON_DTINIVIG.ToString(),
            };

            var executed_1 = M_8600_10_CONTINUA_DB_SELECT_1_Query1.Execute(m_8600_10_CONTINUA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DESCON_PERC, DESCON_PERC);
            }


        }

        [StopWatch]
        /*" M-8600-10-CONTINUA-DB-INSERT-1 */
        public void M_8600_10_CONTINUA_DB_INSERT_1()
        {
            /*" -7382- EXEC SQL INSERT INTO SEGUROS.V0PARCELVA VALUES (:PROPVA-NRCERTIF, 1, :HISTCB-DTVENCTO, :COBERP-PRMVG, :COBERP-PRMAP, 0, :OPCAOP-OPCAOPAG, ' ' , :PARCEL-OCORHIST, CURRENT TIMESTAMP) END-EXEC. */

            var m_8600_10_CONTINUA_DB_INSERT_1_Insert1 = new M_8600_10_CONTINUA_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                HISTCB_DTVENCTO = HISTCB_DTVENCTO.ToString(),
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                OPCAOP_OPCAOPAG = OPCAOP_OPCAOPAG.ToString(),
                PARCEL_OCORHIST = PARCEL_OCORHIST.ToString(),
            };

            M_8600_10_CONTINUA_DB_INSERT_1_Insert1.Execute(m_8600_10_CONTINUA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-8600-15-INSERT-V0HISTCOBVA */
        private void M_8600_15_INSERT_V0HISTCOBVA(bool isPerform = false)
        {
            /*" -7403- ADD 1 TO WTITL-SEQUENCIA. */
            WS_WORK_AREAS.FILLER_18.WTITL_SEQUENCIA.Value = WS_WORK_AREAS.FILLER_18.WTITL_SEQUENCIA + 1;

            /*" -7405- MOVE WTITL-SEQUENCIA TO DPARM01. */
            _.Move(WS_WORK_AREAS.FILLER_18.WTITL_SEQUENCIA, WS_WORK_AREAS.DPARM01X.DPARM01);

            /*" -7407- CALL 'PROTIT01' USING DPARM01X. */
            _.Call("PROTIT01", WS_WORK_AREAS.DPARM01X);

            /*" -7408- IF DPARM01-RC NOT EQUAL +0 */

            if (WS_WORK_AREAS.DPARM01X.DPARM01_RC != +0)
            {

                /*" -7409- DISPLAY 'ERRO CHAMADA PROTIT01' */
                _.Display($"ERRO CHAMADA PROTIT01");

                /*" -7411- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7413- MOVE DPARM01-D1 TO WTITL-DIGITO. */
            _.Move(WS_WORK_AREAS.DPARM01X.DPARM01_D1, WS_WORK_AREAS.FILLER_18.WTITL_DIGITO);

            /*" -7415- MOVE W-NUMR-TITULO TO BANCOS-NRTIT. */
            _.Move(WS_WORK_AREAS.W_NUMR_TITULO, BANCOS_NRTIT);

            /*" -7416- IF OPCAOP-OPCAOPAG = '3' */

            if (OPCAOP_OPCAOPAG == "3")
            {

                /*" -7417- MOVE '5' TO HISTCB-SITUACAO */
                _.Move("5", HISTCB_SITUACAO);

                /*" -7418- ELSE */
            }
            else
            {


                /*" -7420- MOVE '0' TO HISTCB-SITUACAO. */
                _.Move("0", HISTCB_SITUACAO);
            }


            /*" -7421- MOVE '8600-PRIMEIRA-COBRANCA' TO PARAGRAFO. */
            _.Move("8600-PRIMEIRA-COBRANCA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7423- MOVE 'INSERT V0HISTCOBVA' TO COMANDO. */
            _.Move("INSERT V0HISTCOBVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7439- PERFORM M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_1 */

            M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_1();

            /*" -7442- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -7443- IF (SQLCODE EQUAL -803) */

                if ((DB.SQLCODE == -803))
                {

                    /*" -7444- IF (WS-QTD-ERRO-803 < 5000) */

                    if ((WS_WORK_AREAS.WS_QTD_ERRO_803 < 5000))
                    {

                        /*" -7445- ADD 1 TO WS-QTD-ERRO-803 */
                        WS_WORK_AREAS.WS_QTD_ERRO_803.Value = WS_WORK_AREAS.WS_QTD_ERRO_803 + 1;

                        /*" -7446- GO TO 8600-15-INSERT-V0HISTCOBVA */
                        new Task(() => M_8600_15_INSERT_V0HISTCOBVA()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -7447- ELSE */
                    }
                    else
                    {


                        /*" -7448- DISPLAY 'ERRO DUPLICIDADE DE NUM-TITULO > 5000' */
                        _.Display($"ERRO DUPLICIDADE DE NUM-TITULO > 5000");

                        /*" -7449- END-IF */
                    }


                    /*" -7451- END-IF */
                }


                /*" -7452- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -7454- END-IF */
            }


            /*" -7456- IF DESCON-PRMVG NOT GREATER ZEROS AND DESCON-PRMAP NOT GREATER ZEROS */

            if (DESCON_PRMVG <= 00 && DESCON_PRMAP <= 00)
            {

                /*" -7458- GO TO 8600-CONTINUA. */

                M_8600_CONTINUA(); //GOTO
                return;
            }


            /*" -7459- MOVE '8600-PRIMEIRA-COBRANCA' TO PARAGRAFO. */
            _.Move("8600-PRIMEIRA-COBRANCA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7461- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7463- MOVE 'INSERT V0DIFPARCELVA' TO COMANDO. */
            _.Move("INSERT V0DIFPARCELVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7478- PERFORM M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_2 */

            M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_2();

            /*" -7481- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7481- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8600-15-INSERT-V0HISTCOBVA-DB-INSERT-1 */
        public void M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_1()
        {
            /*" -7439- EXEC SQL INSERT INTO SEGUROS.V0HISTCOBVA VALUES (:PROPVA-NRCERTIF, 1, :BANCOS-NRTIT, :HISTCB-DTVENCTO, :DESCON-VLPREMIO, :OPCAOP-OPCAOPAG, :HISTCB-SITUACAO, 0, 0, 0, 0, 0, 0, 0) END-EXEC. */

            var m_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_1_Insert1 = new M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                BANCOS_NRTIT = BANCOS_NRTIT.ToString(),
                HISTCB_DTVENCTO = HISTCB_DTVENCTO.ToString(),
                DESCON_VLPREMIO = DESCON_VLPREMIO.ToString(),
                OPCAOP_OPCAOPAG = OPCAOP_OPCAOPAG.ToString(),
                HISTCB_SITUACAO = HISTCB_SITUACAO.ToString(),
            };

            M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_1_Insert1.Execute(m_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-8600-CONTINUA */
        private void M_8600_CONTINUA(bool isPerform = false)
        {
            /*" -7487- MOVE '8' TO PROPVA-SITUACAO. */
            _.Move("8", PROPVA_SITUACAO);

            /*" -7489- MOVE PROPVA-DTQITBCO TO MDTMOVTO. */
            _.Move(PROPVA_DTQITBCO, MDTMOVTO);

            /*" -7491- IF PROPOSTA-CACB OR PROPOSTA-COPESP */

            if (WS_WORK_AREAS.FILLER_6.W_CANAL_PROPOSTA1["PROPOSTA_CACB"] || WS_WORK_AREAS.FILLER_6.W_CANAL_PROPOSTA1["PROPOSTA_COPESP"])
            {

                /*" -7492- GO TO 8600-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8600_FIM*/ //GOTO
                return;

                /*" -7494- END-IF. */
            }


            /*" -7495- MOVE '8600-PRIMEIRA-COBRANCA' TO PARAGRAFO. */
            _.Move("8600-PRIMEIRA-COBRANCA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7497- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7499- MOVE 'UPDATE V0PROPOSTAVA 05' TO COMANDO. */
            _.Move("UPDATE V0PROPOSTAVA 05", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7503- PERFORM M_8600_CONTINUA_DB_UPDATE_1 */

            M_8600_CONTINUA_DB_UPDATE_1();

            /*" -7506- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -7551- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7553- MOVE PROPVA-DTQITBCO TO W01DTSQL. */
            _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);

            /*" -7555- COMPUTE W01MMSQL = W01MMSQL + OPCAOP-PERIPGTO. */
            WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + OPCAOP_PERIPGTO;

            /*" -7556- IF W01MMSQL GREATER 12 */

            if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
            {

                /*" -7558- COMPUTE W01MMSQL = W01MMSQL - 12 */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL - 12;

                /*" -7560- COMPUTE W01AASQL = W01AASQL + 1. */
                WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;
            }


            /*" -7561- MOVE W01DTSQL TO PROPVA-DTPROXVEN. */
            _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

            /*" -7562- IF OPCAOP-DIA-DEB GREATER ZEROS */

            if (OPCAOP_DIA_DEB > 00)
            {

                /*" -7563- MOVE OPCAOP-DIA-DEB TO W01DDSQL. */
                _.Move(OPCAOP_DIA_DEB, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);
            }


            /*" -7564- IF W01DDSQL GREATER 28 */

            if (WS_WORK_AREAS.W01DTSQL_R.W01DDSQL > 28)
            {

                /*" -7565- MOVE 28 TO W01DDSQL. */
                _.Move(28, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);
            }


            /*" -7566- IF W01DTSQL LESS PROPVA-DTPROXVEN */

            if (WS_WORK_AREAS.W01DTSQL < PROPVA_DTPROXVEN)
            {

                /*" -7567- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -7568- IF W01MMSQL GREATER 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -7569- MOVE 1 TO W01MMSQL */
                    _.Move(1, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -7570- ADD 1 TO W01AASQL. */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;
                }

            }


            /*" -7570- MOVE W01DTSQL TO PROPVA-DTPROXVEN. */
            _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

        }

        [StopWatch]
        /*" M-8600-CONTINUA-DB-UPDATE-1 */
        public void M_8600_CONTINUA_DB_UPDATE_1()
        {
            /*" -7503- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET DTVENCTO = :HISTCB-DTVENCTO WHERE CURRENT OF CPROPVA END-EXEC. */

            var m_8600_CONTINUA_DB_UPDATE_1_Update1 = new M_8600_CONTINUA_DB_UPDATE_1_Update1(CPROPVA)
            {
                HISTCB_DTVENCTO = HISTCB_DTVENCTO.ToString(),
            };

            M_8600_CONTINUA_DB_UPDATE_1_Update1.Execute(m_8600_CONTINUA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-8600-15-INSERT-V0HISTCOBVA-DB-INSERT-2 */
        public void M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_2()
        {
            /*" -7478- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:PROPVA-NRCERTIF, 1, 1, 680, :HISTCB-DTVENCTO, 0, 0, 0, 0, :DESCON-PRMVG, :DESCON-PRMAP, 0, ' ' ) END-EXEC. */

            var m_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_2_Insert1 = new M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_2_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                HISTCB_DTVENCTO = HISTCB_DTVENCTO.ToString(),
                DESCON_PRMVG = DESCON_PRMVG.ToString(),
                DESCON_PRMAP = DESCON_PRMAP.ToString(),
            };

            M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_2_Insert1.Execute(m_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_2_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8600_FIM*/

        [StopWatch]
        /*" M-8605-00-VERIFICA-TP-MENS-SECTION */
        private void M_8605_00_VERIFICA_TP_MENS_SECTION()
        {
            /*" -7579- MOVE '8605-00-VERIFICA-TP-MENS     ' TO PARAGRAFO. */
            _.Move("8605-00-VERIFICA-TP-MENS     ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7580- MOVE 'SELECT VG_DM_MSG_CRITICA     ' TO COMANDO. */
            _.Move("SELECT VG_DM_MSG_CRITICA     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7582- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7584- MOVE ZEROS TO WS-COD-TP-MSG-CRITICA */
            _.Move(0, WS_COD_TP_MSG_CRITICA);

            /*" -7590- PERFORM M_8605_00_VERIFICA_TP_MENS_DB_SELECT_1 */

            M_8605_00_VERIFICA_TP_MENS_DB_SELECT_1();

            /*" -7593- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7595- DISPLAY '8605-00 - PROBLEMAS SELECT(VG_DM_MSG_CRITICA) ' WS-COD-MSG-CRITICA */
                _.Display($"8605-00 - PROBLEMAS SELECT(VG_DM_MSG_CRITICA) {WS_COD_MSG_CRITICA}");

                /*" -7596- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -7597- END-IF */
            }


            /*" -7597- . */

        }

        [StopWatch]
        /*" M-8605-00-VERIFICA-TP-MENS-DB-SELECT-1 */
        public void M_8605_00_VERIFICA_TP_MENS_DB_SELECT_1()
        {
            /*" -7590- EXEC SQL SELECT COD_TP_MSG_CRITICA INTO :WS-COD-TP-MSG-CRITICA FROM SEGUROS.VG_DM_MSG_CRITICA WHERE COD_MSG_CRITICA = :WS-COD-MSG-CRITICA WITH UR END-EXEC. */

            var m_8605_00_VERIFICA_TP_MENS_DB_SELECT_1_Query1 = new M_8605_00_VERIFICA_TP_MENS_DB_SELECT_1_Query1()
            {
                WS_COD_MSG_CRITICA = WS_COD_MSG_CRITICA.ToString(),
            };

            var executed_1 = M_8605_00_VERIFICA_TP_MENS_DB_SELECT_1_Query1.Execute(m_8605_00_VERIFICA_TP_MENS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COD_TP_MSG_CRITICA, WS_COD_TP_MSG_CRITICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8605_99_SAIDA*/

        [StopWatch]
        /*" M-8700-GERA-DEBITO-SECTION */
        private void M_8700_GERA_DEBITO_SECTION()
        {
            /*" -7611- MOVE '8700-GERA-DEBITO' TO PARAGRAFO. */
            _.Move("8700-GERA-DEBITO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7612- MOVE 'SELECT V0CONVENIOSVG' TO COMANDO. */
            _.Move("SELECT V0CONVENIOSVG", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7614- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7623- PERFORM M_8700_GERA_DEBITO_DB_SELECT_1 */

            M_8700_GERA_DEBITO_DB_SELECT_1();

            /*" -7626- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7628- DISPLAY '*** PROBLEMAS NO ACESSO A V0CONVSICOV ' PROPVA-CODPRODU */
                _.Display($"*** PROBLEMAS NO ACESSO A V0CONVSICOV {PROPVA_CODPRODU}");

                /*" -7630- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7631- IF OPCAOP-OPCAOPAG EQUAL '1' OR '2' */

            if (OPCAOP_OPCAOPAG.In("1", "2"))
            {

                /*" -7632- MOVE ZEROS TO OPCAOP-CARTAOCRED */
                _.Move(0, OPCAOP_CARTAOCRED);

                /*" -7641- MOVE CONVEN-CODCONV TO HOST-CODCONV. */
                _.Move(CONVEN_CODCONV, HOST_CODCONV);
            }


            /*" -7643- MOVE 'INSERT V0HISTCONTAVA' TO COMANDO. */
            _.Move("INSERT V0HISTCONTAVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7685- PERFORM M_8700_GERA_DEBITO_DB_INSERT_1 */

            M_8700_GERA_DEBITO_DB_INSERT_1();

            /*" -7688- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7688- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8700-GERA-DEBITO-DB-SELECT-1 */
        public void M_8700_GERA_DEBITO_DB_SELECT_1()
        {
            /*" -7623- EXEC SQL SELECT COD_SEGURO, COD_CONV_CARTAO INTO :CONVEN-CODCONV, :CONVEN-CARTAO FROM SEGUROS.V0CONVENIOSVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES WITH UR END-EXEC. */

            var m_8700_GERA_DEBITO_DB_SELECT_1_Query1 = new M_8700_GERA_DEBITO_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_8700_GERA_DEBITO_DB_SELECT_1_Query1.Execute(m_8700_GERA_DEBITO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVEN_CODCONV, CONVEN_CODCONV);
                _.Move(executed_1.CONVEN_CARTAO, CONVEN_CARTAO);
            }


        }

        [StopWatch]
        /*" M-8700-GERA-DEBITO-DB-INSERT-1 */
        public void M_8700_GERA_DEBITO_DB_INSERT_1()
        {
            /*" -7685- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTAVA (NRCERTIF , NRPARCEL , OCORRHISTCTA , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , DTVENCTO , VLPRMTOT , SITUACAO , TIPLANC , TIMESTAMP , OCORHIST , CODCONV , NSAS , NSL , NSAC , CODRET , CODUSU , NUM_CARTAO_CREDITO) VALUES (:PROPVA-NRCERTIF, 1, 1, :OPCAOP-AGECTADEB, :OPCAOP-OPRCTADEB, :OPCAOP-NUMCTADEB, :OPCAOP-DIGCTADEB, :HISTCB-DTVENCTO, :DESCON-VLPREMIO, '0' , '1' , CURRENT TIMESTAMP, 0, :HOST-CODCONV, NULL, NULL, NULL, NULL, NULL, :OPCAOP-CARTAOCRED) END-EXEC. */

            var m_8700_GERA_DEBITO_DB_INSERT_1_Insert1 = new M_8700_GERA_DEBITO_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                OPCAOP_AGECTADEB = OPCAOP_AGECTADEB.ToString(),
                OPCAOP_OPRCTADEB = OPCAOP_OPRCTADEB.ToString(),
                OPCAOP_NUMCTADEB = OPCAOP_NUMCTADEB.ToString(),
                OPCAOP_DIGCTADEB = OPCAOP_DIGCTADEB.ToString(),
                HISTCB_DTVENCTO = HISTCB_DTVENCTO.ToString(),
                DESCON_VLPREMIO = DESCON_VLPREMIO.ToString(),
                HOST_CODCONV = HOST_CODCONV.ToString(),
                OPCAOP_CARTAOCRED = OPCAOP_CARTAOCRED.ToString(),
            };

            M_8700_GERA_DEBITO_DB_INSERT_1_Insert1.Execute(m_8700_GERA_DEBITO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8700_FIM*/

        [StopWatch]
        /*" M-8800-APROPRIA-FUNDO-SECTION */
        private void M_8800_APROPRIA_FUNDO_SECTION()
        {
            /*" -7705- MOVE '8800-APROPRIA-FUNDO' TO PARAGRAFO. */
            _.Move("8800-APROPRIA-FUNDO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7706- MOVE 'SELECT V0PARCOMVA  ' TO COMANDO. */
            _.Move("SELECT V0PARCOMVA  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7708- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7718- PERFORM M_8800_APROPRIA_FUNDO_DB_SELECT_1 */

            M_8800_APROPRIA_FUNDO_DB_SELECT_1();

            /*" -7721- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -7722- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7723- MOVE 0 TO FUNDO-PCCOMIND */
                    _.Move(0, FUNDO_PCCOMIND);

                    /*" -7724- ELSE */
                }
                else
                {


                    /*" -7725- DISPLAY 'ERRO SEGUROS.V0PARCOMVA TIPCOM  =  0' */
                    _.Display($"ERRO SEGUROS.V0PARCOMVA TIPCOM  =  0");

                    /*" -7726- DISPLAY 'CODPRODU          = ' PROPVA-CODPRODU */
                    _.Display($"CODPRODU          = {PROPVA_CODPRODU}");

                    /*" -7727- DISPLAY 'OPCAP PERIODO PAG = ' OPCAOP-PERIPGTO */
                    _.Display($"OPCAP PERIODO PAG = {OPCAOP_PERIPGTO}");

                    /*" -7728- DISPLAY 'DT INIVIGENCIA    = ' PROPVA-DTQITBCO */
                    _.Display($"DT INIVIGENCIA    = {PROPVA_DTQITBCO}");

                    /*" -7730- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -7732- MOVE 'SELECT V0PARCOMVA 1' TO COMANDO. */
            _.Move("SELECT V0PARCOMVA 1", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7742- PERFORM M_8800_APROPRIA_FUNDO_DB_SELECT_2 */

            M_8800_APROPRIA_FUNDO_DB_SELECT_2();

            /*" -7746- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -7747- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7748- MOVE 0 TO FUNDO-PCCOMGER */
                    _.Move(0, FUNDO_PCCOMGER);

                    /*" -7749- ELSE */
                }
                else
                {


                    /*" -7750- DISPLAY 'ERRO SEGUROS.V0PARCOMVA TIPCOM  =  1' */
                    _.Display($"ERRO SEGUROS.V0PARCOMVA TIPCOM  =  1");

                    /*" -7751- DISPLAY 'CODPRODU          = ' PROPVA-CODPRODU */
                    _.Display($"CODPRODU          = {PROPVA_CODPRODU}");

                    /*" -7752- DISPLAY 'OPCAP PERIODO PAG = ' OPCAOP-PERIPGTO */
                    _.Display($"OPCAP PERIODO PAG = {OPCAOP_PERIPGTO}");

                    /*" -7753- DISPLAY 'DT INIVIGENCIA    = ' PROPVA-DTQITBCO */
                    _.Display($"DT INIVIGENCIA    = {PROPVA_DTQITBCO}");

                    /*" -7755- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -7757- MOVE 'SELECT V0PARCOMVA 2' TO COMANDO. */
            _.Move("SELECT V0PARCOMVA 2", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7767- PERFORM M_8800_APROPRIA_FUNDO_DB_SELECT_3 */

            M_8800_APROPRIA_FUNDO_DB_SELECT_3();

            /*" -7770- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -7771- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7772- MOVE 0 TO FUNDO-PCCOMSUP */
                    _.Move(0, FUNDO_PCCOMSUP);

                    /*" -7773- ELSE */
                }
                else
                {


                    /*" -7774- DISPLAY 'ERRO SEGUROS.V0PARCOMVA TIPCOM  =  1' */
                    _.Display($"ERRO SEGUROS.V0PARCOMVA TIPCOM  =  1");

                    /*" -7775- DISPLAY 'CODPRODU          = ' PROPVA-CODPRODU */
                    _.Display($"CODPRODU          = {PROPVA_CODPRODU}");

                    /*" -7776- DISPLAY 'OPCAP PERIODO PAG = ' OPCAOP-PERIPGTO */
                    _.Display($"OPCAP PERIODO PAG = {OPCAOP_PERIPGTO}");

                    /*" -7777- DISPLAY 'DT INIVIGENCIA    = ' PROPVA-DTQITBCO */
                    _.Display($"DT INIVIGENCIA    = {PROPVA_DTQITBCO}");

                    /*" -7779- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -7780- IF PROPVA-CODPRODU EQUAL 7705 OR JVPRD7705 */

            if (PROPVA_CODPRODU.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString()))
            {

                /*" -7781- IF PROPVA-ORIGEM-PROPOSTA = 13 OR 14 */

                if (PROPVA_ORIGEM_PROPOSTA.In("13", "14"))
                {

                    /*" -7782- MOVE 11 TO FUNDO-PCCOMIND */
                    _.Move(11, FUNDO_PCCOMIND);

                    /*" -7783- ELSE */
                }
                else
                {


                    /*" -7784- MOVE 16 TO FUNDO-PCCOMIND */
                    _.Move(16, FUNDO_PCCOMIND);

                    /*" -7785- END-IF */
                }


                /*" -7787- END-IF. */
            }


            /*" -7790- IF FUNDO-PCCOMIND EQUAL ZEROES AND FUNDO-PCCOMGER EQUAL ZEROES AND FUNDO-PCCOMSUP EQUAL ZEROES */

            if (FUNDO_PCCOMIND == 00 && FUNDO_PCCOMGER == 00 && FUNDO_PCCOMSUP == 00)
            {

                /*" -7791- DISPLAY 'PARAMETROS DE COMISSAO NAO ENCONTRADOS ' */
                _.Display($"PARAMETROS DE COMISSAO NAO ENCONTRADOS ");

                /*" -7792- DISPLAY 'CODPRODU          = ' PROPVA-CODPRODU */
                _.Display($"CODPRODU          = {PROPVA_CODPRODU}");

                /*" -7793- DISPLAY 'OPCAP PERIODO PAG = ' OPCAOP-PERIPGTO */
                _.Display($"OPCAP PERIODO PAG = {OPCAOP_PERIPGTO}");

                /*" -7794- DISPLAY 'DT INIVIGENCIA    = ' PROPVA-DTQITBCO */
                _.Display($"DT INIVIGENCIA    = {PROPVA_DTQITBCO}");

                /*" -7796- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7802- COMPUTE FUNDO-PCCOMTOT = FUNDO-PCCOMIND + FUNDO-PCCOMGER + FUNDO-PCCOMSUP. */
            FUNDO_PCCOMTOT.Value = FUNDO_PCCOMIND + FUNDO_PCCOMGER + FUNDO_PCCOMSUP;

            /*" -7804- MOVE 'SELECT V1APOLICE' TO COMANDO */
            _.Move("SELECT V1APOLICE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7810- PERFORM M_8800_APROPRIA_FUNDO_DB_SELECT_4 */

            M_8800_APROPRIA_FUNDO_DB_SELECT_4();

            /*" -7813- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -7814- DISPLAY 'ERRO SELECT SEGUROS.V0APOLICE ' */
                _.Display($"ERRO SELECT SEGUROS.V0APOLICE ");

                /*" -7815- DISPLAY 'APOLICE = ' PROPVA-NUM-APOLICE */
                _.Display($"APOLICE = {PROPVA_NUM_APOLICE}");

                /*" -7819- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7821- MOVE MDTMOVTO TO V1RIND-DTINIVIG */
            _.Move(MDTMOVTO, V1RIND_DTINIVIG);

            /*" -7823- MOVE 'SELECT V1RAMOIND' TO COMANDO */
            _.Move("SELECT V1RAMOIND", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7831- PERFORM M_8800_APROPRIA_FUNDO_DB_SELECT_5 */

            M_8800_APROPRIA_FUNDO_DB_SELECT_5();

            /*" -7834- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -7835- DISPLAY 'ERRO SELECT SEGUROS.V1RAMOIND ' */
                _.Display($"ERRO SELECT SEGUROS.V1RAMOIND ");

                /*" -7836- DISPLAY 'RAMO     = ' V1APOL-RAMO */
                _.Display($"RAMO     = {V1APOL_RAMO}");

                /*" -7837- DISPLAY 'DTINIVIG = ' V1RIND-DTINIVIG */
                _.Display($"DTINIVIG = {V1RIND_DTINIVIG}");

                /*" -7839- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7841- COMPUTE WS-IND-IOF ROUNDED = (1 + (V1RIND-PCIOF / 100)) */
            WS_WORK_AREAS.WS_IND_IOF.Value = (1 + (V1RIND_PCIOF / 100f));

            /*" -7842- COMPUTE FUNDO-VALBASVG ROUNDED = COBERP-PRMVG / WS-IND-IOF */
            FUNDO_VALBASVG.Value = COBERP_PRMVG / WS_WORK_AREAS.WS_IND_IOF;

            /*" -7844- COMPUTE FUNDO-VALBASAP ROUNDED = COBERP-PRMAP / WS-IND-IOF */
            FUNDO_VALBASAP.Value = COBERP_PRMAP / WS_WORK_AREAS.WS_IND_IOF;

            /*" -7846- COMPUTE FUNDO-VLCOMISVG ROUNDED = (FUNDO-VALBASVG * FUNDO-PCCOMTOT) / 100. */
            FUNDO_VLCOMISVG.Value = (FUNDO_VALBASVG * FUNDO_PCCOMTOT) / 100f;

            /*" -7849- COMPUTE FUNDO-VLCOMISAP ROUNDED = (FUNDO-VALBASAP * FUNDO-PCCOMTOT) / 100. */
            FUNDO_VLCOMISAP.Value = (FUNDO_VALBASAP * FUNDO_PCCOMTOT) / 100f;

            /*" -7851- MOVE 'INSERT V0FUNDOCOMISVA' TO COMANDO. */
            _.Move("INSERT V0FUNDOCOMISVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7895- PERFORM M_8800_APROPRIA_FUNDO_DB_INSERT_1 */

            M_8800_APROPRIA_FUNDO_DB_INSERT_1();

            /*" -7898- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7898- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8800-APROPRIA-FUNDO-DB-SELECT-1 */
        public void M_8800_APROPRIA_FUNDO_DB_SELECT_1()
        {
            /*" -7718- EXEC SQL SELECT PCCOMCOR INTO :FUNDO-PCCOMIND FROM SEGUROS.V0PARCOMVA WHERE CODPRODU = :PROPVA-CODPRODU AND PERIPGTO = :OPCAOP-PERIPGTO AND DTINIVIG <= :PROPVA-DTQITBCO AND DTTERVIG >= :PROPVA-DTQITBCO AND TIPCOM = '0' WITH UR END-EXEC. */

            var m_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1 = new M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1()
            {
                PROPVA_CODPRODU = PROPVA_CODPRODU.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
            };

            var executed_1 = M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1.Execute(m_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FUNDO_PCCOMIND, FUNDO_PCCOMIND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8800_FIM*/

        [StopWatch]
        /*" M-8800-APROPRIA-FUNDO-DB-SELECT-2 */
        public void M_8800_APROPRIA_FUNDO_DB_SELECT_2()
        {
            /*" -7742- EXEC SQL SELECT PCCOMCOR INTO :FUNDO-PCCOMGER FROM SEGUROS.V0PARCOMVA WHERE CODPRODU = :PROPVA-CODPRODU AND PERIPGTO = :OPCAOP-PERIPGTO AND DTINIVIG <= :PROPVA-DTQITBCO AND DTTERVIG >= :PROPVA-DTQITBCO AND TIPCOM = '1' WITH UR END-EXEC. */

            var m_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1 = new M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1()
            {
                PROPVA_CODPRODU = PROPVA_CODPRODU.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
            };

            var executed_1 = M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1.Execute(m_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FUNDO_PCCOMGER, FUNDO_PCCOMGER);
            }


        }

        [StopWatch]
        /*" R7770-00-PROPOSTAS-SIVPF-SIVPF-SECTION */
        private void R7770_00_PROPOSTAS_SIVPF_SIVPF_SECTION()
        {
            /*" -7910- MOVE 'R7770-00-PROPOSTAS-SIVPF-SIVPF' TO PARAGRAFO. */
            _.Move("R7770-00-PROPOSTAS-SIVPF-SIVPF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7913- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7914- IF NAO-LEU-SIVPF */

            if (WS_WORK_AREAS.WS_LEITUA_SIVPF["NAO_LEU_SIVPF"])
            {

                /*" -7917- PERFORM R7771-00-LER-PROP-SIVPF THRU R7771-FIM. */

                R7771_00_LER_PROP_SIVPF_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7771_FIM*/

            }


            /*" -7918- IF WTEM-SIVPF EQUAL 1 */

            if (WS_WORK_AREAS.WTEM_SIVPF == 1)
            {

                /*" -7921- PERFORM R7772-00-VERIFICA-ATUALIZACOES THRU R7772-FIM */

                R7772_00_VERIFICA_ATUALIZACOES_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7772_FIM*/


                /*" -7924- PERFORM R7775-00-UPD-PROP-SIVPF-SIVPF THRU R7775-FIM */

                R7775_00_UPD_PROP_SIVPF_SIVPF_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7775_FIM*/


                /*" -7925- ADD 1 TO UPDATE-SIVPF-SIVPF. */
                WS_WORK_AREAS.UPDATE_SIVPF_SIVPF.Value = WS_WORK_AREAS.UPDATE_SIVPF_SIVPF + 1;
            }


        }

        [StopWatch]
        /*" M-8800-APROPRIA-FUNDO-DB-SELECT-3 */
        public void M_8800_APROPRIA_FUNDO_DB_SELECT_3()
        {
            /*" -7767- EXEC SQL SELECT PCCOMCOR INTO :FUNDO-PCCOMSUP FROM SEGUROS.V0PARCOMVA WHERE CODPRODU = :PROPVA-CODPRODU AND PERIPGTO = :OPCAOP-PERIPGTO AND DTINIVIG <= :PROPVA-DTQITBCO AND DTTERVIG >= :PROPVA-DTQITBCO AND TIPCOM = '2' WITH UR END-EXEC. */

            var m_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1 = new M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1()
            {
                PROPVA_CODPRODU = PROPVA_CODPRODU.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
            };

            var executed_1 = M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1.Execute(m_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FUNDO_PCCOMSUP, FUNDO_PCCOMSUP);
            }


        }

        [StopWatch]
        /*" M-8800-APROPRIA-FUNDO-DB-INSERT-1 */
        public void M_8800_APROPRIA_FUNDO_DB_INSERT_1()
        {
            /*" -7895- EXEC SQL INSERT INTO SEGUROS.V0FUNDOCOMISVA (CODPRODU , NRCERTIF , NRPROPAZ , NUM_TERMO, SITUACAO , CODOPER , FONTE , AGENCIA , CODCLIEN , NRMATRVEN, VLBASVG , VALBASAP , VLCOMISVG, VLCOMISAP, DTQITBCO , PCCOMIND , PCCOMGER , PCCOMSUP , DTMOVTO , COD_USUARIO, TIMESTAMP) VALUES (:PROPVA-CODPRODU, :PROPVA-NRCERTIF, 0, 0, '0' , 1101, :PROPVA-FONTE, :PROPVA-AGECOBR, :PROPVA-CODCLIEN, :PROPVA-NRMATRVEN, :FUNDO-VALBASVG, :FUNDO-VALBASAP, :FUNDO-VLCOMISVG, :FUNDO-VLCOMISAP, :PROPVA-DTQITBCO, :FUNDO-PCCOMIND, :FUNDO-PCCOMGER, :FUNDO-PCCOMSUP, :SISTEMA-DTMOVABE, 'VA0118B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1 = new M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1()
            {
                PROPVA_CODPRODU = PROPVA_CODPRODU.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
                PROPVA_AGECOBR = PROPVA_AGECOBR.ToString(),
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                PROPVA_NRMATRVEN = PROPVA_NRMATRVEN.ToString(),
                FUNDO_VALBASVG = FUNDO_VALBASVG.ToString(),
                FUNDO_VALBASAP = FUNDO_VALBASAP.ToString(),
                FUNDO_VLCOMISVG = FUNDO_VLCOMISVG.ToString(),
                FUNDO_VLCOMISAP = FUNDO_VLCOMISAP.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
                FUNDO_PCCOMIND = FUNDO_PCCOMIND.ToString(),
                FUNDO_PCCOMGER = FUNDO_PCCOMGER.ToString(),
                FUNDO_PCCOMSUP = FUNDO_PCCOMSUP.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1.Execute(m_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7770_FIM*/

        [StopWatch]
        /*" M-8800-APROPRIA-FUNDO-DB-SELECT-4 */
        public void M_8800_APROPRIA_FUNDO_DB_SELECT_4()
        {
            /*" -7810- EXEC SQL SELECT RAMO INTO :V1APOL-RAMO FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE WITH UR END-EXEC. */

            var m_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1 = new M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1.Execute(m_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APOL_RAMO, V1APOL_RAMO);
            }


        }

        [StopWatch]
        /*" R7771-00-LER-PROP-SIVPF-SECTION */
        private void R7771_00_LER_PROP_SIVPF_SECTION()
        {
            /*" -7936- MOVE 'R7771-00-LER-PROP-SIVPF ' TO PARAGRAFO. */
            _.Move("R7771-00-LER-PROP-SIVPF ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7937- MOVE 'SELECT PROPOSTA-FIDELIZ ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7939- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7940- MOVE ZEROS TO WTEM-SIVPF. */
            _.Move(0, WS_WORK_AREAS.WTEM_SIVPF);

            /*" -7942- MOVE PROPVA-NRCERTIF TO SIVPF-NR-PROPOSTA. */
            _.Move(PROPVA_NRCERTIF, SIVPF_NR_PROPOSTA);

            /*" -7944- MOVE 'S' TO WS-LEITUA-SIVPF. */
            _.Move("S", WS_WORK_AREAS.WS_LEITUA_SIVPF);

            /*" -7963- PERFORM R7771_00_LER_PROP_SIVPF_DB_SELECT_1 */

            R7771_00_LER_PROP_SIVPF_DB_SELECT_1();

            /*" -7966- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -7967- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -7968- DISPLAY 'ERRO SELECT PROPOSTA_FIDELIZ' */
                    _.Display($"ERRO SELECT PROPOSTA_FIDELIZ");

                    /*" -7969- DISPLAY 'NUM PROPOSTA SIVPF = ' SIVPF-NR-PROPOSTA */
                    _.Display($"NUM PROPOSTA SIVPF = {SIVPF_NR_PROPOSTA}");

                    /*" -7971- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -7972- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -7973- MOVE 1 TO WTEM-SIVPF. */
                _.Move(1, WS_WORK_AREAS.WTEM_SIVPF);
            }


        }

        [StopWatch]
        /*" R7771-00-LER-PROP-SIVPF-DB-SELECT-1 */
        public void R7771_00_LER_PROP_SIVPF_DB_SELECT_1()
        {
            /*" -7963- EXEC SQL SELECT NUM_IDENTIFICACAO, NUM_SICOB, SIT_PROPOSTA, DTQITBCO, VAL_PAGO, DATA_CREDITO, OPCAO_COBER, COD_PLANO INTO :SIVPF-NR-IDENTIFI, :SIVPF-NR-SICOB, :SIVPF-SIT-PROPOSTA, :SIVPF-DTQITBCO, :SIVPF-VAL-PAGO, :SIVPF-DATA-CREDITO, :SIVPF-OPCAO-COBER, :SIVPF-COD-PLANO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :SIVPF-NR-PROPOSTA END-EXEC. */

            var r7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1 = new R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1()
            {
                SIVPF_NR_PROPOSTA = SIVPF_NR_PROPOSTA.ToString(),
            };

            var executed_1 = R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1.Execute(r7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIVPF_NR_IDENTIFI, SIVPF_NR_IDENTIFI);
                _.Move(executed_1.SIVPF_NR_SICOB, SIVPF_NR_SICOB);
                _.Move(executed_1.SIVPF_SIT_PROPOSTA, SIVPF_SIT_PROPOSTA);
                _.Move(executed_1.SIVPF_DTQITBCO, SIVPF_DTQITBCO);
                _.Move(executed_1.SIVPF_VAL_PAGO, SIVPF_VAL_PAGO);
                _.Move(executed_1.SIVPF_DATA_CREDITO, SIVPF_DATA_CREDITO);
                _.Move(executed_1.SIVPF_OPCAO_COBER, SIVPF_OPCAO_COBER);
                _.Move(executed_1.SIVPF_COD_PLANO, SIVPF_COD_PLANO);
            }


        }

        [StopWatch]
        /*" M-8800-APROPRIA-FUNDO-DB-SELECT-5 */
        public void M_8800_APROPRIA_FUNDO_DB_SELECT_5()
        {
            /*" -7831- EXEC SQL SELECT PCIOF INTO :V1RIND-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = :V1APOL-RAMO AND DTINIVIG <= :V1RIND-DTINIVIG AND DTTERVIG >= :V1RIND-DTINIVIG WITH UR END-EXEC. */

            var m_8800_APROPRIA_FUNDO_DB_SELECT_5_Query1 = new M_8800_APROPRIA_FUNDO_DB_SELECT_5_Query1()
            {
                V1RIND_DTINIVIG = V1RIND_DTINIVIG.ToString(),
                V1APOL_RAMO = V1APOL_RAMO.ToString(),
            };

            var executed_1 = M_8800_APROPRIA_FUNDO_DB_SELECT_5_Query1.Execute(m_8800_APROPRIA_FUNDO_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RIND_PCIOF, V1RIND_PCIOF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7771_FIM*/

        [StopWatch]
        /*" R7772-00-VERIFICA-ATUALIZACOES-SECTION */
        private void R7772_00_VERIFICA_ATUALIZACOES_SECTION()
        {
            /*" -7984- MOVE 'R7772-00-VERIFICA-ATUALIZ' TO PARAGRAFO. */
            _.Move("R7772-00-VERIFICA-ATUALIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7986- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7989- MOVE ZERO TO W-RCAPS W-RCAP-COMP. */
            _.Move(0, WS_WORK_AREAS.W_RCAPS, WS_WORK_AREAS.W_RCAP_COMP);

            /*" -7990- IF SIVPF-OPCAO-COBER EQUAL SPACES */

            if (SIVPF_OPCAO_COBER.IsEmpty())
            {

                /*" -7992- MOVE PROPVA-OPCAO-COBER TO SIVPF-OPCAO-COBER. */
                _.Move(PROPVA_OPCAO_COBER, SIVPF_OPCAO_COBER);
            }


            /*" -7998- IF (CANAL-VENDA-GITEL) OR (CANAL-VENDA-SASSE) OR (PRODVG-ORIG-PRODU = 'PAREN' OR 'CEF DEB CC' ) OR (OPCAOP-OPCAOPAG EQUAL '5' ) OR (PROPVA-ORIGEM-PROPOSTA EQUAL 1010) OR (PROPVA-ORIGEM-PROPOSTA EQUAL 1009) */

            if ((WS_WORK_AREAS.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_GITEL"]) || (WS_WORK_AREAS.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_SASSE"]) || (PRODVG_ORIG_PRODU.In("PAREN", "CEF DEB CC")) || (OPCAOP_OPCAOPAG == "5") || (PROPVA_ORIGEM_PROPOSTA == 1010) || (PROPVA_ORIGEM_PROPOSTA == 1009))
            {

                /*" -8000- MOVE PROPVA-DTQITBCO TO SIVPF-DTQITBCO */
                _.Move(PROPVA_DTQITBCO, SIVPF_DTQITBCO);

                /*" -8002- MOVE SISTEMA-DTMOVABE TO SIVPF-DATA-CREDITO */
                _.Move(SISTEMA_DTMOVABE, SIVPF_DATA_CREDITO);

                /*" -8004- MOVE COBERP-VLPREMIO TO SIVPF-VAL-PAGO */
                _.Move(COBERP_VLPREMIO, SIVPF_VAL_PAGO);

                /*" -8005- GO TO R7772-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7772_FIM*/ //GOTO
                return;

                /*" -8007- END-IF. */
            }


            /*" -8012- IF SIVPF-DTQITBCO EQUAL '0001-01-01' OR SIVPF-DTQITBCO EQUAL '1900-01-01' OR SIVPF-DATA-CREDITO EQUAL '0001-01-01' OR SIVPF-DATA-CREDITO EQUAL '1901-01-01' OR SIVPF-VAL-PAGO EQUAL ZEROS */

            if (SIVPF_DTQITBCO == "0001-01-01" || SIVPF_DTQITBCO == "1900-01-01" || SIVPF_DATA_CREDITO == "0001-01-01" || SIVPF_DATA_CREDITO == "1901-01-01" || SIVPF_VAL_PAGO == 00)
            {

                /*" -8015- MOVE SIVPF-NR-SICOB TO RCAPS-NUM-TITULO OF DCLRCAPS */
                _.Move(SIVPF_NR_SICOB, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

                /*" -8018- PERFORM R7773-00-LER-RCAPS THRU R7773-FIM */

                R7773_00_LER_RCAPS_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7773_FIM*/


                /*" -8019- IF NOT RCAP-CADASTRADO */

                if (!WS_WORK_AREAS.W_RCAPS["RCAP_CADASTRADO"])
                {

                    /*" -8020- DISPLAY 'VA0118B - PROBLEMAS NO ACESSO A RCAP' */
                    _.Display($"VA0118B - PROBLEMAS NO ACESSO A RCAP");

                    /*" -8022- DISPLAY '          NUMERO DO TITULO......... ' RCAPS-NUM-TITULO OF DCLRCAPS */
                    _.Display($"          NUMERO DO TITULO......... {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

                    /*" -8024- DISPLAY '          SQLCODE.................. ' SQLCODE */
                    _.Display($"          SQLCODE.................. {DB.SQLCODE}");

                    /*" -8025- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -8027- ELSE */
                }
                else
                {


                    /*" -8030- PERFORM R7774-00-LER-RCAP-COMP THRU R7774-FIM */

                    R7774_00_LER_RCAP_COMP_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R7774_FIM*/


                    /*" -8031- IF NOT RCAP-COMP-CADASTRADO */

                    if (!WS_WORK_AREAS.W_RCAP_COMP["RCAP_COMP_CADASTRADO"])
                    {

                        /*" -8032- DISPLAY 'VA0118B - PROBLEMAS ACESSO RCAP-COMP' */
                        _.Display($"VA0118B - PROBLEMAS ACESSO RCAP-COMP");

                        /*" -8034- DISPLAY '          CODIGO DA FONTE.......... ' RCAPS-COD-FONTE OF DCLRCAPS */
                        _.Display($"          CODIGO DA FONTE.......... {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -8036- DISPLAY '          NUM RCAP................. ' RCAPS-NUM-RCAP OF DCLRCAPS */
                        _.Display($"          NUM RCAP................. {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -8038- DISPLAY '          SQLCODE.................. ' SQLCODE */
                        _.Display($"          SQLCODE.................. {DB.SQLCODE}");

                        /*" -8040- GO TO 9999-ERRO. */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -8041- IF RCAP-CADASTRADO */

            if (WS_WORK_AREAS.W_RCAPS["RCAP_CADASTRADO"])
            {

                /*" -8042- IF RCAP-COMP-CADASTRADO */

                if (WS_WORK_AREAS.W_RCAP_COMP["RCAP_COMP_CADASTRADO"])
                {

                    /*" -8044- IF SIVPF-DTQITBCO EQUAL '0001-01-01' OR SIVPF-DTQITBCO EQUAL '1900-01-01' */

                    if (SIVPF_DTQITBCO == "0001-01-01" || SIVPF_DTQITBCO == "1900-01-01")
                    {

                        /*" -8046- MOVE RCAPCOMP-DATA-RCAP OF DCLRCAP-COMPLEMENTAR TO SIVPF-DTQITBCO */
                        _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP, SIVPF_DTQITBCO);

                        /*" -8048- END-IF */
                    }


                    /*" -8050- IF SIVPF-DATA-CREDITO EQUAL '0001-01-01' OR SIVPF-DATA-CREDITO EQUAL '1901-01-01' */

                    if (SIVPF_DATA_CREDITO == "0001-01-01" || SIVPF_DATA_CREDITO == "1901-01-01")
                    {

                        /*" -8052- MOVE RCAPCOMP-DATA-MOVIMENTO OF DCLRCAP-COMPLEMENTAR TO SIVPF-DATA-CREDITO */
                        _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO, SIVPF_DATA_CREDITO);

                        /*" -8054- END-IF */
                    }


                    /*" -8055- IF SIVPF-VAL-PAGO EQUAL ZEROS */

                    if (SIVPF_VAL_PAGO == 00)
                    {

                        /*" -8056- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO SIVPF-VAL-PAGO. */
                        _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, SIVPF_VAL_PAGO);
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7772_FIM*/

        [StopWatch]
        /*" R7773-00-LER-RCAPS-SECTION */
        private void R7773_00_LER_RCAPS_SECTION()
        {
            /*" -8068- MOVE 'R7773-00-LER-RCAPS           ' TO PARAGRAFO. */
            _.Move("R7773-00-LER-RCAPS           ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8069- MOVE 'SELECT RCAPS                 ' TO COMANDO. */
            _.Move("SELECT RCAPS                 ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8072- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8083- PERFORM R7773_00_LER_RCAPS_DB_SELECT_1 */

            R7773_00_LER_RCAPS_DB_SELECT_1();

            /*" -8086- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -8087- MOVE 1 TO W-RCAPS */
                _.Move(1, WS_WORK_AREAS.W_RCAPS);

                /*" -8088- ELSE */
            }
            else
            {


                /*" -8089- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -8090- CONTINUE */

                    /*" -8091- ELSE */
                }
                else
                {


                    /*" -8094- DISPLAY 'ERRO AO LER RCAPS >> ' RCAPS-NUM-TITULO OF DCLRCAPS ' >> ' PROPVA-NRCERTIF ' >> ' SQLCODE */

                    $"ERRO AO LER RCAPS >> {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO} >> {PROPVA_NRCERTIF} >> {DB.SQLCODE}"
                    .Display();

                    /*" -8095- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -8095- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" R7773-00-LER-RCAPS-DB-SELECT-1 */
        public void R7773_00_LER_RCAPS_DB_SELECT_1()
        {
            /*" -8083- EXEC SQL SELECT COD_FONTE, NUM_RCAP, VAL_RCAP INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP FROM SEGUROS.RCAPS WHERE (NUM_TITULO =:DCLRCAPS.RCAPS-NUM-TITULO OR NUM_CERTIFICADO = :PROPVA-NRCERTIF) WITH UR END-EXEC. */

            var r7773_00_LER_RCAPS_DB_SELECT_1_Query1 = new R7773_00_LER_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = R7773_00_LER_RCAPS_DB_SELECT_1_Query1.Execute(r7773_00_LER_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7773_FIM*/

        [StopWatch]
        /*" R7774-00-LER-RCAP-COMP-SECTION */
        private void R7774_00_LER_RCAP_COMP_SECTION()
        {
            /*" -8107- MOVE 'R7774-00-LER-RCAP-COMP       ' TO PARAGRAFO. */
            _.Move("R7774-00-LER-RCAP-COMP       ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8108- MOVE 'SELECT RCAP_COMPLEMENTAR     ' TO COMANDO. */
            _.Move("SELECT RCAP_COMPLEMENTAR     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8110- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8127- PERFORM R7774_00_LER_RCAP_COMP_DB_SELECT_1 */

            R7774_00_LER_RCAP_COMP_DB_SELECT_1();

            /*" -8130- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -8131- MOVE 1 TO W-RCAP-COMP */
                _.Move(1, WS_WORK_AREAS.W_RCAP_COMP);

                /*" -8132- ELSE */
            }
            else
            {


                /*" -8134- IF SQLCODE NOT EQUAL 100 AND SQLCODE NOT EQUAL -811 */

                if (DB.SQLCODE != 100 && DB.SQLCODE != -811)
                {

                    /*" -8135- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -8136- ELSE */
                }
                else
                {


                    /*" -8152- PERFORM R7774_00_LER_RCAP_COMP_DB_DECLARE_1 */

                    R7774_00_LER_RCAP_COMP_DB_DECLARE_1();

                    /*" -8154- PERFORM R7774_00_LER_RCAP_COMP_DB_OPEN_1 */

                    R7774_00_LER_RCAP_COMP_DB_OPEN_1();

                    /*" -8157- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -8158- DISPLAY 'VA0118B - PROBLEMAS NO OPEN DA RCAPCOMP' */
                        _.Display($"VA0118B - PROBLEMAS NO OPEN DA RCAPCOMP");

                        /*" -8160- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                        _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -8162- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                        _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -8164- DISPLAY '          SQLCODE...................... ' SQLCODE */
                        _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                        /*" -8165- GO TO 9999-ERRO */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -8167- END-IF */
                    }


                    /*" -8178- PERFORM R7774_00_LER_RCAP_COMP_DB_FETCH_1 */

                    R7774_00_LER_RCAP_COMP_DB_FETCH_1();

                    /*" -8181- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                    if (!DB.SQLCODE.In("00", "100"))
                    {

                        /*" -8182- DISPLAY 'VA0118B - PROBLEMAS NO FETCH DA RCAPCOMP' */
                        _.Display($"VA0118B - PROBLEMAS NO FETCH DA RCAPCOMP");

                        /*" -8184- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                        _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -8186- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                        _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -8188- DISPLAY '          SQLCODE...................... ' SQLCODE */
                        _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                        /*" -8189- GO TO 9999-ERRO */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -8191- END-IF */
                    }


                    /*" -8192- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -8193- MOVE 1 TO W-RCAP-COMP */
                        _.Move(1, WS_WORK_AREAS.W_RCAP_COMP);

                        /*" -8195- END-IF */
                    }


                    /*" -8195- PERFORM R7774_00_LER_RCAP_COMP_DB_CLOSE_1 */

                    R7774_00_LER_RCAP_COMP_DB_CLOSE_1();

                    /*" -8198- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -8199- DISPLAY 'VA0118B - PROBLEMAS NO CLOSE DA RCAPCOMP' */
                        _.Display($"VA0118B - PROBLEMAS NO CLOSE DA RCAPCOMP");

                        /*" -8201- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                        _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -8203- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                        _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -8205- DISPLAY '          SQLCODE...................... ' SQLCODE */
                        _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                        /*" -8205- GO TO 9999-ERRO. */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R7774-00-LER-RCAP-COMP-DB-SELECT-1 */
        public void R7774_00_LER_RCAP_COMP_DB_SELECT_1()
        {
            /*" -8127- EXEC SQL SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 AND COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */

            var r7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1 = new R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1()
            {
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            var executed_1 = R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1.Execute(r7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1);
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
        /*" R7774-00-LER-RCAP-COMP-DB-OPEN-1 */
        public void R7774_00_LER_RCAP_COMP_DB_OPEN_1()
        {
            /*" -8154- EXEC SQL OPEN C01_RCAPCOMP END-EXEC */

            C01_RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R7774-00-LER-RCAP-COMP-DB-FETCH-1 */
        public void R7774_00_LER_RCAP_COMP_DB_FETCH_1()
        {
            /*" -8178- EXEC SQL FETCH C01_RCAPCOMP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-COD-OPERACAO END-EXEC */

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
        /*" R7774-00-LER-RCAP-COMP-DB-CLOSE-1 */
        public void R7774_00_LER_RCAP_COMP_DB_CLOSE_1()
        {
            /*" -8195- EXEC SQL CLOSE C01_RCAPCOMP END-EXEC */

            C01_RCAPCOMP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7774_FIM*/

        [StopWatch]
        /*" R7775-00-UPD-PROP-SIVPF-SIVPF-SECTION */
        private void R7775_00_UPD_PROP_SIVPF_SIVPF_SECTION()
        {
            /*" -8217- MOVE 'R7775-00-UPD-PROP-SIVPF    ' TO PARAGRAFO. */
            _.Move("R7775-00-UPD-PROP-SIVPF    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8218- MOVE 'UPDATE PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8220- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8221- IF PROPVA-SITUACAO = '3' */

            if (PROPVA_SITUACAO == "3")
            {

                /*" -8222- MOVE 'EMT' TO WHOST-SIT-PROP-FIDELIZ */
                _.Move("EMT", WHOST_SIT_PROP_FIDELIZ);

                /*" -8223- ELSE */
            }
            else
            {


                /*" -8225- MOVE 'PEN' TO WHOST-SIT-PROP-FIDELIZ. */
                _.Move("PEN", WHOST_SIT_PROP_FIDELIZ);
            }


            /*" -8227- IF PROPOSTA-CACB OR PROPOSTA-COPESP */

            if (WS_WORK_AREAS.FILLER_6.W_CANAL_PROPOSTA1["PROPOSTA_CACB"] || WS_WORK_AREAS.FILLER_6.W_CANAL_PROPOSTA1["PROPOSTA_COPESP"])
            {

                /*" -8228- MOVE 'N' TO WHOST-SITUACAO-ENVIO */
                _.Move("N", WHOST_SITUACAO_ENVIO);

                /*" -8229- ELSE */
            }
            else
            {


                /*" -8230- MOVE 'S' TO WHOST-SITUACAO-ENVIO */
                _.Move("S", WHOST_SITUACAO_ENVIO);

                /*" -8233- END-IF. */
            }


            /*" -8244- PERFORM R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1 */

            R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1();

            /*" -8247- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -8248- DISPLAY 'ERRO UPDATE PROPOSTA_FIDELIZ' */
                _.Display($"ERRO UPDATE PROPOSTA_FIDELIZ");

                /*" -8249- DISPLAY 'PROPOSTA SIVPF = ' SIVPF-NR-PROPOSTA */
                _.Display($"PROPOSTA SIVPF = {SIVPF_NR_PROPOSTA}");

                /*" -8250- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7775-00-UPD-PROP-SIVPF-SIVPF-DB-UPDATE-1 */
        public void R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1()
        {
            /*" -8244- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WHOST-SIT-PROP-FIDELIZ, SITUACAO_ENVIO = :WHOST-SITUACAO-ENVIO, DTQITBCO = :SIVPF-DTQITBCO, VAL_PAGO = :SIVPF-VAL-PAGO, DATA_CREDITO = :SIVPF-DATA-CREDITO, OPCAO_COBER = :SIVPF-OPCAO-COBER, COD_USUARIO = 'VA0118B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_PROPOSTA_SIVPF = :SIVPF-NR-PROPOSTA END-EXEC. */

            var r7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1 = new R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1()
            {
                WHOST_SIT_PROP_FIDELIZ = WHOST_SIT_PROP_FIDELIZ.ToString(),
                WHOST_SITUACAO_ENVIO = WHOST_SITUACAO_ENVIO.ToString(),
                SIVPF_DATA_CREDITO = SIVPF_DATA_CREDITO.ToString(),
                SIVPF_OPCAO_COBER = SIVPF_OPCAO_COBER.ToString(),
                SIVPF_DTQITBCO = SIVPF_DTQITBCO.ToString(),
                SIVPF_VAL_PAGO = SIVPF_VAL_PAGO.ToString(),
                SIVPF_NR_PROPOSTA = SIVPF_NR_PROPOSTA.ToString(),
            };

            R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1.Execute(r7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7775_FIM*/

        [StopWatch]
        /*" M-8880-ACERTA-DIF-PREMIO-SECTION */
        private void M_8880_ACERTA_DIF_PREMIO_SECTION()
        {
            /*" -8257- MOVE '8880-ACERTA-DIF-PREMIO' TO PARAGRAFO. */
            _.Move("8880-ACERTA-DIF-PREMIO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8259- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8261- COMPUTE WS-TAXA-VG = COBERP-PRMVG / COBERP-VLPREMIO. */
            WS_WORK_AREAS.WS_TAXA_VG.Value = COBERP_PRMVG / COBERP_VLPREMIO;

            /*" -8263- COMPUTE WS-TAXA-AP = COBERP-PRMAP / COBERP-VLPREMIO. */
            WS_WORK_AREAS.WS_TAXA_AP.Value = COBERP_PRMAP / COBERP_VLPREMIO;

            /*" -8264- IF COBERP-VLPREMIO > V0HCOB-VLPRMTOT */

            if (COBERP_VLPREMIO > V0HCOB_VLPRMTOT)
            {

                /*" -8265- MOVE 401 TO DIFPAR-CODOPER */
                _.Move(401, DIFPAR_CODOPER);

                /*" -8266- ELSE */
            }
            else
            {


                /*" -8268- MOVE 601 TO DIFPAR-CODOPER. */
                _.Move(601, DIFPAR_CODOPER);
            }


            /*" -8270- COMPUTE COBERP-PRMVG = V0HCOB-VLPRMTOT * WS-TAXA-VG. */
            COBERP_PRMVG.Value = V0HCOB_VLPRMTOT * WS_WORK_AREAS.WS_TAXA_VG;

            /*" -8272- COMPUTE COBERP-PRMAP = V0HCOB-VLPRMTOT - COBERP-PRMVG. */
            COBERP_PRMAP.Value = V0HCOB_VLPRMTOT - COBERP_PRMVG;

            /*" -8273- IF DIFPAR-CODOPER = 401 */

            if (DIFPAR_CODOPER == 401)
            {

                /*" -8275- COMPUTE DIFPAR-PRMVG = COBERP-VLPREMIO - V0HCOB-VLPRMTOT. */
                DIFPAR_PRMVG.Value = COBERP_VLPREMIO - V0HCOB_VLPRMTOT;
            }


            /*" -8276- IF DIFPAR-CODOPER = 601 */

            if (DIFPAR_CODOPER == 601)
            {

                /*" -8278- COMPUTE DIFPAR-PRMVG = V0HCOB-VLPRMTOT - COBERP-VLPREMIO. */
                DIFPAR_PRMVG.Value = V0HCOB_VLPRMTOT - COBERP_VLPREMIO;
            }


            /*" -8280- MOVE 'UPDATE V0PARCELVA' TO COMANDO */
            _.Move("UPDATE V0PARCELVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8287- PERFORM M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1 */

            M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1();

            /*" -8290- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -8291- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -8292- IF PROPVA-NUM-APOLICE EQUAL 109300000635 */

                    if (PROPVA_NUM_APOLICE == 109300000635)
                    {

                        /*" -8293- GO TO 8880-FIM */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8880_FIM*/ //GOTO
                        return;

                        /*" -8294- ELSE */
                    }
                    else
                    {


                        /*" -8295- DISPLAY 'ERRO UPDATE V0PARCELVA' */
                        _.Display($"ERRO UPDATE V0PARCELVA");

                        /*" -8296- DISPLAY 'NRCERTIF  = ' PROPVA-NRCERTIF */
                        _.Display($"NRCERTIF  = {PROPVA_NRCERTIF}");

                        /*" -8298- GO TO 9999-ERRO. */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -8300- MOVE 'INSERT V0DIFPARCELVA' TO COMANDO. */
            _.Move("INSERT V0DIFPARCELVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8315- PERFORM M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1 */

            M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1();

            /*" -8319- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -8321- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -8323- MOVE 'UPDATE V0HISTCONTABILVA' TO COMANDO. */
            _.Move("UPDATE V0HISTCONTABILVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8331- PERFORM M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2 */

            M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2();

            /*" -8335- IF SQLCODE NOT = ZEROS AND SQLCODE NOT = 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -8336- DISPLAY 'ERRO UPDATE V0HISTCONTABILVA' */
                _.Display($"ERRO UPDATE V0HISTCONTABILVA");

                /*" -8337- DISPLAY 'NRCERTIF  = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF  = {PROPVA_NRCERTIF}");

                /*" -8337- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8880-ACERTA-DIF-PREMIO-DB-UPDATE-1 */
        public void M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1()
        {
            /*" -8287- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET PRMVG = :COBERP-PRMVG, PRMAP = :COBERP-PRMAP, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 END-EXEC */

            var m_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1 = new M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1()
            {
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1.Execute(m_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-8880-ACERTA-DIF-PREMIO-DB-INSERT-1 */
        public void M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1()
        {
            /*" -8315- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:PROPVA-NRCERTIF, 9999, 1, :DIFPAR-CODOPER, :PROPVA-DTQITBCO, :COBERP-VLPREMIO, 0, :V0HCOB-VLPRMTOT, 0, :DIFPAR-PRMVG, 0, 0, ' ' ) END-EXEC. */

            var m_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1 = new M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                DIFPAR_CODOPER = DIFPAR_CODOPER.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
                COBERP_VLPREMIO = COBERP_VLPREMIO.ToString(),
                V0HCOB_VLPRMTOT = V0HCOB_VLPRMTOT.ToString(),
                DIFPAR_PRMVG = DIFPAR_PRMVG.ToString(),
            };

            M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1.Execute(m_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8880_FIM*/

        [StopWatch]
        /*" M-8880-ACERTA-DIF-PREMIO-DB-UPDATE-2 */
        public void M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2()
        {
            /*" -8331- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET PRMVG = :COBERP-PRMVG, PRMAP = :COBERP-PRMAP, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 AND SITUACAO = '0' END-EXEC. */

            var m_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1 = new M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1()
            {
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1.Execute(m_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-9000-FINALIZA-SECTION */
        private void M_9000_FINALIZA_SECTION()
        {
            /*" -8349- MOVE '9000-FINALIZA' TO PARAGRAFO. */
            _.Move("9000-FINALIZA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8350- MOVE 'COMMIT WORK' TO COMANDO. */
            _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8353- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8353- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -8355- DISPLAY 'PROCESSAMENTO COM COMMIT ' */
            _.Display($"PROCESSAMENTO COM COMMIT ");

            /*" -8356- DISPLAY 'PROCESSAMENTO COM COMMIT ' */
            _.Display($"PROCESSAMENTO COM COMMIT ");

            /*" -8364- DISPLAY 'PROCESSAMENTO COM COMMIT ' */
            _.Display($"PROCESSAMENTO COM COMMIT ");

            /*" -8365- DISPLAY ' ' . */
            _.Display($" ");

            /*" -8366- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -8367- DISPLAY '       *** VA0118B *** TERMINO NORMAL' . */
            _.Display($"       *** VA0118B *** TERMINO NORMAL");

            /*" -8368- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -8369- DISPLAY ' ' . */
            _.Display($" ");

            /*" -8370- DISPLAY 'LIDOS A EMITIR ............. ' AC-LIDOS-0 */
            _.Display($"LIDOS A EMITIR ............. {WS_WORK_AREAS.AC_LIDOS_0}");

            /*" -8371- DISPLAY 'LIDOS A COBRAR ............. ' AC-LIDOS-7 */
            _.Display($"LIDOS A COBRAR ............. {WS_WORK_AREAS.AC_LIDOS_7}");

            /*" -8372- DISPLAY 'INCLUSOES .................. ' AC-INCLUSOES */
            _.Display($"INCLUSOES .................. {WS_WORK_AREAS.AC_INCLUSOES}");

            /*" -8373- DISPLAY 'CERTIFICADOS EMITIDOS ...... ' AC-INTEGRADOS */
            _.Display($"CERTIFICADOS EMITIDOS ...... {WS_WORK_AREAS.AC_INTEGRADOS}");

            /*" -8374- DISPLAY 'CERTIFICADOS COBRADOS ...... ' AC-COBRADOS */
            _.Display($"CERTIFICADOS COBRADOS ...... {WS_WORK_AREAS.AC_COBRADOS}");

            /*" -8375- DISPLAY 'DESPREZADOS ................ ' AC-DESPREZADOS */
            _.Display($"DESPREZADOS ................ {WS_WORK_AREAS.AC_DESPREZADOS}");

            /*" -8376- DISPLAY 'MOV. EMISSAO FOLHETOS....... ' AC-FOLHETOS */
            _.Display($"MOV. EMISSAO FOLHETOS....... {WS_WORK_AREAS.AC_FOLHETOS}");

            /*" -8377- DISPLAY 'PROPOSTAS SIVPF EMITIDAS.... ' UPDATE-SIVPF-SIVPF */
            _.Display($"PROPOSTAS SIVPF EMITIDAS.... {WS_WORK_AREAS.UPDATE_SIVPF_SIVPF}");

            /*" -8378- DISPLAY '                             ' */
            _.Display($"                             ");

            /*" -8379- DISPLAY 'DESPR-PRODUVG                ' AC-DESPR-PRODUVG */
            _.Display($"DESPR-PRODUVG                {WS_WORK_AREAS.AC_DESPR_PRODUVG}");

            /*" -8381- DISPLAY 'DESPR-AGENCCEF               ' AC-DESPR-AGENCCEF */
            _.Display($"DESPR-AGENCCEF               {WS_WORK_AREAS.AC_DESPR_AGENCCEF}");

            /*" -8382- DISPLAY 'DESPR-CLIENTE                ' AC-DESPR-CLIENTE */
            _.Display($"DESPR-CLIENTE                {WS_WORK_AREAS.AC_DESPR_CLIENTE}");

            /*" -8383- DISPLAY 'DESPR-CONTA                  ' AC-DESPR-CONTA */
            _.Display($"DESPR-CONTA                  {WS_WORK_AREAS.AC_DESPR_CONTA}");

            /*" -8384- DISPLAY 'DESPR-DPS-TIT                ' AC-DESPR-DPS-TIT */
            _.Display($"DESPR-DPS-TIT                {WS_WORK_AREAS.AC_DESPR_DPS_TIT}");

            /*" -8385- DISPLAY 'DESPR-FONTE                  ' AC-DESPR-FONTE */
            _.Display($"DESPR-FONTE                  {WS_WORK_AREAS.AC_DESPR_FONTE}");

            /*" -8386- DISPLAY 'DESPR-HISCOBPR               ' AC-DESPR-HISCOBPR */
            _.Display($"DESPR-HISCOBPR               {WS_WORK_AREAS.AC_DESPR_HISCOBPR}");

            /*" -8387- DISPLAY 'DESPR-IDADE                  ' AC-DESPR-IDADE */
            _.Display($"DESPR-IDADE                  {WS_WORK_AREAS.AC_DESPR_IDADE}");

            /*" -8388- DISPLAY 'DESPR-OPCAOPAG               ' AC-DESPR-OPCAOPAG */
            _.Display($"DESPR-OPCAOPAG               {WS_WORK_AREAS.AC_DESPR_OPCAOPAG}");

            /*" -8389- DISPLAY 'DESPR-PARCELVA               ' AC-DESPR-PARCELVA */
            _.Display($"DESPR-PARCELVA               {WS_WORK_AREAS.AC_DESPR_PARCELVA}");

            /*" -8390- DISPLAY 'DESPR-PERIPGTO               ' AC-DESPR-PERIPGTO */
            _.Display($"DESPR-PERIPGTO               {WS_WORK_AREAS.AC_DESPR_PERIPGTO}");

            /*" -8391- DISPLAY 'DESPR-PLAVAVGA               ' AC-DESPR-PLAVAVGA */
            _.Display($"DESPR-PLAVAVGA               {WS_WORK_AREAS.AC_DESPR_PLAVAVGA}");

            /*" -8392- DISPLAY 'DESPR-CRITICA-PROPOSTA       ' AC-DESPR-CRTCA-PRP */
            _.Display($"DESPR-CRITICA-PROPOSTA       {WS_WORK_AREAS.AC_DESPR_CRTCA_PRP}");

            /*" -8394- DISPLAY 'DESPR-DPS-ELETRONICO         ' AC-DESPR-DPS-ELETR */
            _.Display($"DESPR-DPS-ELETRONICO         {AC_DESPR_DPS_ELETR}");

            /*" -8395- DISPLAY '                             ' */
            _.Display($"                             ");

            /*" -8396- DISPLAY 'PROPOSTAS-ACEITAS <= 100 MIL ' AC-ACEITA-PRD-001 */
            _.Display($"PROPOSTAS-ACEITAS <= 100 MIL {WS_WORK_AREAS.AC_ACEITA_PRD_001}");

            /*" -8397- DISPLAY 'PROPOSTAS-ACEITAS <  600 MIL ' AC-ACEITA-PRD-002 */
            _.Display($"PROPOSTAS-ACEITAS <  600 MIL {WS_WORK_AREAS.AC_ACEITA_PRD_002}");

            /*" -8398- DISPLAY 'TOTAL PROPOSTAS DECLINADAS   ' AC-DECLIN-PROPVA */
            _.Display($"TOTAL PROPOSTAS DECLINADAS   {WS_WORK_AREAS.AC_DECLIN_PROPVA}");

            /*" -8399- DISPLAY 'PROP-DECLINADAS   > 100 MIL  ' AC-DECLIN-100MIL */
            _.Display($"PROP-DECLINADAS   > 100 MIL  {WS_WORK_AREAS.AC_DECLIN_100MIL}");

            /*" -8400- DISPLAY 'PROP-DECLINADAS   > 600 MIL  ' AC-DECLIN-600MIL */
            _.Display($"PROP-DECLINADAS   > 600 MIL  {WS_WORK_AREAS.AC_DECLIN_600MIL}");

            /*" -8401- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -8403- DISPLAY 'QUANT RISCO CRITICO          ' WS-QT-RISCO-CRITICO */
            _.Display($"QUANT RISCO CRITICO          {WS_QT_RISCO_CRITICO}");

            /*" -8405- DISPLAY 'QUANT EM ANALISE DE RISCO    ' WS-QT-EM-CRITICA */
            _.Display($"QUANT EM ANALISE DE RISCO    {WS_QT_EM_CRITICA}");

            /*" -8407- DISPLAY 'QUANT EMISSAO C/ AVAL. RISCO ' WS-QT-EMISSAO-C-RISCO */
            _.Display($"QUANT EMISSAO C/ AVAL. RISCO {WS_QT_EMISSAO_C_RISCO}");

            /*" -8409- DISPLAY 'QUANT EMISSAO S/ AVAL. RISCO ' WS-QT-EMISSAO-S-RISCO */
            _.Display($"QUANT EMISSAO S/ AVAL. RISCO {WS_QT_EMISSAO_S_RISCO}");

            /*" -8411- DISPLAY 'QUANT LIBERADA APOS ANALISE  ' WS-QT-LIBERADO-EMISSAO */
            _.Display($"QUANT LIBERADA APOS ANALISE  {WS_QT_LIBERADO_EMISSAO}");

            /*" -8412- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -8413- DISPLAY '       *** VA0118B *** TERMINO NORMAL' . */
            _.Display($"       *** VA0118B *** TERMINO NORMAL");

            /*" -8414- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -8414- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9999-ERRO-SECTION */
        private void M_9999_ERRO_SECTION()
        {
            /*" -8427- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -8428- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -8429- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -8430- MOVE SQLCODE TO WSQLCODE3. */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WSQLCODE3);

            /*" -8432- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -8434- DISPLAY '*** VA0118B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VA0118B *** ROLLBACK EM ANDAMENTO ...");

            /*" -8434- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -8437- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8438- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8438- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -8441- DISPLAY ' ' . */
            _.Display($" ");

            /*" -8442- DISPLAY 'LIDOS A EMITIR ....... ' AC-LIDOS-0 */
            _.Display($"LIDOS A EMITIR ....... {WS_WORK_AREAS.AC_LIDOS_0}");

            /*" -8443- DISPLAY 'LIDOS A COBRAR ....... ' AC-LIDOS-7 */
            _.Display($"LIDOS A COBRAR ....... {WS_WORK_AREAS.AC_LIDOS_7}");

            /*" -8444- DISPLAY ' ' . */
            _.Display($" ");

            /*" -8445- DISPLAY 'INCLUSOES ............ ' AC-INCLUSOES. */
            _.Display($"INCLUSOES ............ {WS_WORK_AREAS.AC_INCLUSOES}");

            /*" -8446- DISPLAY 'CERTIFICADOS EMITIDOS. ' AC-INTEGRADOS */
            _.Display($"CERTIFICADOS EMITIDOS. {WS_WORK_AREAS.AC_INTEGRADOS}");

            /*" -8447- DISPLAY 'CERTIFICADOS COBRADOS. ' AC-COBRADOS */
            _.Display($"CERTIFICADOS COBRADOS. {WS_WORK_AREAS.AC_COBRADOS}");

            /*" -8448- DISPLAY ' ' . */
            _.Display($" ");

            /*" -8449- DISPLAY 'DESPREZADOS .......... ' AC-DESPREZADOS. */
            _.Display($"DESPREZADOS .......... {WS_WORK_AREAS.AC_DESPREZADOS}");

            /*" -8451- DISPLAY ' ' */
            _.Display($" ");

            /*" -8452- DISPLAY 'CERTIFICADO... ' PROPVA-NRCERTIF. */
            _.Display($"CERTIFICADO... {PROPVA_NRCERTIF}");

            /*" -8453- DISPLAY 'APOLICE....... ' PROPVA-NUM-APOLICE */
            _.Display($"APOLICE....... {PROPVA_NUM_APOLICE}");

            /*" -8454- DISPLAY 'SUBGRUPO...... ' PROPVA-CODSUBES */
            _.Display($"SUBGRUPO...... {PROPVA_CODSUBES}");

            /*" -8455- DISPLAY 'PROPAUTOM..... ' FONTE-PROPAUTOM. */
            _.Display($"PROPAUTOM..... {FONTE_PROPAUTOM}");

            /*" -8457- DISPLAY 'FONTE......... ' PROPVA-FONTE. */
            _.Display($"FONTE......... {PROPVA_FONTE}");

            /*" -8458- DISPLAY 'TITULO........ ' RCAPS-NUM-TITULO */
            _.Display($"TITULO........ {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

            /*" -8460- DISPLAY '*** VA0118B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VA0118B *** ERRO DE EXECUCAO");

            /*" -8461- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -8461- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}