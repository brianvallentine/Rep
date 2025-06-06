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
using Sias.Cobranca.DB2.CB0009B;

namespace Code
{
    public class CB0009B
    {
        public bool IsCall { get; set; }

        public CB0009B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA.                          *      */
        /*"      *   PROGRAMA ...............  CB0009B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  16/02/2000                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  LIBERACAO DE BILHETES PARA ERROS:  *      */
        /*"      *                                                                *      */
        /*"      *   0101 - FILIAL NAO INFORMADA                                  *      */
        /*"      *   0102 - FILIAL NAO CADASTRADA                                 *      */
        /*"      *   0103 - FILIAL ENCERRADA                                      *      */
        /*"      *   0201 - AGENCIA DE COBRANCA NAO INFORMADA                     *      */
        /*"      *   0202 - AGENCIA DE COBRANCA NAO CADASTRADA                    *      */
        /*"      *   0701 - MATRICULA DO INDICADOR NAO INFORMADA                  *      */
        /*"      *   0702 - EMPREGADO NAO ENCONTRADO. VERIFIQUE MATRICULA         *      */
        /*"      *   1101 - IDADE FORA DOS LIMITES DA COBERTURA                   *      */
        /*"      *   1501 - OPCAO DE COBERTURA NAO INFORMADA                      *      */
        /*"      *   1502 - OPCAO DE COBERTURA INVALIDA (VIRG)                    *      */
        /*"      *   1503 - OPCAO DE COBERTURA NAO VALIDA P/ A DATA DA VENDA      *      */
        /*"      *   1602 - DATA DE PAGAMENTO INVALIDA                            *      */
        /*"      *   1801 - VALOR RECEBIDO NAO INFORMADO                          *      */
        /*"      *   1802 - DADOS PAG/CRED DO BILHETE (RCAP) NAO CADASTRADO       *      */
        /*"      *   1803 - PROFISSAO DECLINAVEL (OUTROS)                         *      */
        /*"      *   1901 - DATA DE PAGAMENTO DIFERE DA DATA DO RCAP              *      */
        /*"      *   2101 - VALOR RECEBIDO DIFERE DO VALOR DO RCAP                *      */
        /*"      *   2102 - VALOR RECEBIDO DIFERE DO VALOR CALCULADO              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * -------------------------------------------------------------- *      */
        /*"      * SISTEMAS                            V0SISTEMA         INPUT    *      */
        /*"      * MOVIMENTO DE BILHETES               V0BILHETE         I-O      *      */
        /*"      * COMISSAO FENAE                      V0COMISSAO_FENAE  INPUT    *      */
        /*"      * FUNCIONARIOS                        V0FUNCIOCEF       INPUT    *      */
        /*"      * ERROS                               V0BILHETE_ERROS   I-O      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    A L T E R A C O E S                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.51  *   VERSAO 51   - INCIDENTE 599595 - ERRO NO ACESSO A GE0070S    *      */
        /*"      *                                                                *      */
        /*"      *   03/09/2024  - CANETTA               PROCURE POR V.51         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.50  *   VERSAO 50   - INCIDENTE 599595 - ERRO NO ACESSO A GE0070S    *      */
        /*"      *                                                                *      */
        /*"      *   20/08/2024  - CANETTA               PROCURE POR V.50         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.49  *   VERSAO 49   - DEMANDA 575149 - APOIO +FUTURO (3729)          *      */
        /*"      *                                                                *      */
        /*"      *   03/07/2024  - CANETTA               PROCURE POR V.49         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.48  *   VERSAO 48   - INCIDENTE 593096 - LIMITAR ACESSO A CHAMADA DA *      */
        /*"      *                 GE0070S                                        *      */
        /*"      *                                                                *      */
        /*"      *   26/06/2024  - ELIERMES/ROGER        PROCURE POR V.48         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.47  *   VERSAO 47   - DEMANDA 575149 - APOIO +FUTURO (3729)          *      */
        /*"      *                                                                *      */
        /*"      *   28/06/2024  - CANETTA               PROCURE POR V.47         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.46  *   VERSAO 46 - DEMANDA 508.682                                  *      */
        /*"      *             - MUDA A SITUACAO DA BILHETE PARA '0' QUANDO       *      */
        /*"      *               O RCAP NAO ESTIVER CADASTRADO.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/12/2023 - FELIPE LARA         PROCURE POR V.46         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.45  *   VERSAO 45 - DEMANDA 559.665                                  *      */
        /*"      *             - NAO TRATAR A MATRICULA ENVIADA PELO SISTEMA DE   *      */
        /*"      *               VENDAS, RESPEITAR E CADASTRAR NA BASE DO SIAS A  *      */
        /*"      *               MESMA MATRICULA RECEBIDA NO ARQUIVO.             *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/12/2023 - FRANK CARVALHO      PROCURE POR V.44         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.44  *   VERSAO 44 - DEMANDA 554.757                                  *      */
        /*"      *             - AJUSTAR A BUSCA PELO PLANO DO BILHETE NA TABELA  *      */
        /*"      *               BILHETE_COBERTURAS. O PROGRAMA ESTA MODIFICANDO  *      */
        /*"      *               O PLANO DO PRODUTO 3721 PARA O PLANO DO PRODUTO  *      */
        /*"      *               3724.                                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/11/2023 - FRANK CARVALHO      PROCURE POR V.44         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.43  *   VERSAO 43 - DEMANDA 551989 - NAO PERMITIR ALTERAR MATRICULA  *      */
        /*"      *               DO VENDEDOR P/ 777777 QUANDO BILHETE AMPARO(3721)*      */
        /*"      *               COM ORIGEM 13,15 E 22 E CANAL 3 OU 4                    */
        /*"      *                                                                *      */
        /*"      *   EM 14/11/2023 - ELIERMES OLIVEIRA   PROCURE POR V.43         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.42  *  VERSAO 42  - DEMANDA 402.982                                  *      */
        /*"      *             - RETIRAR GRAVACAO DE ERROS DA PROPOSTA DA VIEW    *      */
        /*"      *               V0BILHETE_ERROS                                  *      */
        /*"      *             - GRAVAR ERROS DA PROPOSTA NA NOVA TABELA          *      */
        /*"      *               VG_CRITICA_PROPOSTA PARA POSTERIOR ANALISE DO    *      */
        /*"      *               GESTOR NO ATALHO 04.23                           *      */
        /*"      *             - SOMAR 10000 AOS COD-ERRO UTILIZADOS NAS TABELAS  *      */
        /*"      *               DE BILHETE E VIDA AO MESMO TEMPO                 *      */
        /*"      *                                                                *      */
        /*"      *  EM 14/02/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.42        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 41                                                    *      */
        /*"      *             - ABEND 259505                                     *      */
        /*"      *                PARA NAO CANCELAR POR ESTOURO DA TABELA INTERNA *      */
        /*"      *                AUMENTOU-SE O TAMANHO DA TABELA                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/09/2020 - THIAGO BLAIER                                *      */
        /*"      *                                       PROCURE POR V.41         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 40   - HISTORIA 230625                                *      */
        /*"      *        TRATAR BILHETES PROVENIENTES DO ATM QUE NAO TENHAM O    *      */
        /*"      *        CODIGO DO PRODUTO NO COD-PLANO. ORIGEM 18 E 19.         *      */
        /*"      *        ASSUMIR COD_PLANO = 3709                                *      */
        /*"      *                                            PROCURE POR V.40    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 39   - HISTORIA 204146                                *      */
        /*"      *                 RETIRA BILHETES COM RENOVACAO.                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/06/2019                      PROCURE POR  V.39         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV.02 *   VERSAO 38   - HISTORIA 200604                                *      */
        /*"      *               - ALTERAR A APLICAÇÂO PARA TRATAMENTO DA NOVA    *      */
        /*"      *                 EMPRESA (JV1). CORRIGIR SELECT NAS TABELAS     *      */
        /*"      *                 'BILHETE_PLANCOBER' E 'BILHETE_COBERTURA'.     *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/05/2019 - HERVAL SOUZA       PROCURE POR JV.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV.01 *   VERSAO 37 - PROJETO JOINT VENTURE (JV)                       *      */
        /*"=     *             - AVALIAR IMPACTO PRODUTO, APOLICE, ORGAO, ETC.    *      */
        /*"=     *             - Historia: 181586.                                *      */
        /*"=     *    EM 01/02/2019 - HERVAL SOUZA                                *      */
        /*"=     *                                        PROCURE POR JV.01       *      */
        /*"JV.01 *----------------------------------------------------------------*      */
        /*"      *  036 - 11/01/2019 - BRICEHO        (ALTRAN)                    *      */
        /*"      *  DEMANDA 180114                                                *      */
        /*"      *        NAO TRATAR BILHETES PROVENIENTES DO ATM QUE NAO TENHAM  *      */
        /*"      *        O CODIGO DO PRODUTO NO COD-PLANO. ORIGEM 18 E 19.       *      */
        /*"      *                                            PROCURE POR V.36    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  035 - 03/11/2015 - CLAUDETE RADEL (MILLENIUM)                 *      */
        /*"      *  CAD 123562 / 2015                                             *      */
        /*"      *        RETIRAR A VALIDAÇÃO DE IDADE MAIOR DE 70 ANOS PARA O    *      */
        /*"      *        PRODUTO 3709 (RAMO 37, OPC COBERTURA 21 E 31)           *      */
        /*"      *                                            PROCURE POR V.35    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  034 - 04/10/2014 - COREON                                     *      */
        /*"      *  CAD 103659 / 2014                                             *      */
        /*"      *        NSGD - NOVA SOLUCAO DE GESTAO DE DEPOSITOS              *      */
        /*"      *                                            PROCURE POR V.34    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  033 - 24/08/2012 - MARCO (FAST COMPUTER)                      *      */
        /*"      *  CAD 73467 / 2012                                              *      */
        /*"      *        AJUSTE NO PROGRAMA PARA CORRECAO DO ABEND SQLCODE= -305 *      */
        /*"      *        NA TABELA V0AGENCIACEF                                  *      */
        /*"      *                                            PROCURE POR V.33    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  032 - 13/12/2011 - BARDUCCO - CADMUS 64651                    *      */
        /*"      *  CAD 64651 / 2011                                              *      */
        /*"      *        AUMENTA OCORRENCIAS DA TABELA WACEF-AGENCIAS, DE: 4000         */
        /*"      *        PARA: 5000 OCORRENCIAS. EVITA ABEND S04E.               *      */
        /*"      *                                            PROCURE POR V.32    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  031 - 19/03/2010 - MARCO       (FAST COMPUTER)                *      */
        /*"      *  CAD 39359/2010                                                *      */
        /*"      *        EMISSAO DE BILHETES COM A NUMERACAO SEM DV ERRONEAMENTE *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.31    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  030 - 07/08/2009 - FAST COMPUTER                              *      */
        /*"      *                                                                *      */
        /*"      *  CAD 27948/2009   - LIBERA BILHETES RAMO 81 E 82 PARA:         *      */
        /*"      *                                                                *      */
        /*"      *          803     NOME DO SEGURADO DIVERGE PARA CPF/DATA NASC   *      */
        /*"      *         1401     ENDERECO NAO INFORMADO                        *      */
        /*"      *         2205     DV DA CONTA DE DEBITO INVALIDO                *      */
        /*"      *         XXXX     AGENCIA DE COBRANCA NAO CADASTRADA            *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.30    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  029 - 15/07/2009 - BRSEG                                      *      */
        /*"      *                                                                *      */
        /*"      *  CAD 26651/2009   - LIBERACAO DE BILHETES RD                   *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.29    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  028 - 19/02/2009 - FAST COMPUTER                              *      */
        /*"      *                                                                *      */
        /*"      *  CAD 21031/2009   - EMISSAO DO BILHETE AP  8259475872          *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.28    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  027 - 05/01/2009 - LEANDRO CORTES (FAST COMPUTER)             *      */
        /*"      *  CAD 18696/2009                                                *      */
        /*"      *        EMISSAO DE BILHETES COM A NUMERACAO SEM DV ERRONEAMENTE *      */
        /*"      *        PREMIO PAGO.                                            *      */
        /*"      *                                            PROCURE POR V.27    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  026 - 07/11/2008 - EDIVALDO    (FAST COMPUTER)                *      */
        /*"      *  CAD 16578/2008                                                *      */
        /*"      *        EMISSAO DE BILHETES COM DIFERENCA DE ATE CINCO REAIS NO *      */
        /*"      *        PREMIO PAGO.                                            *      */
        /*"      *                                            PROCURE POR V.26    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  13/08/08   WELLINGTON VERAS (POLITEC)              *      */
        /*"      *    PROJETO FGV                                                 *      */
        /*"      *                INIBIR COMANDO DISPLAY    WV0808                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  024 - 18/06/2008 - EDIVALDO    (FAST COMPUTER)                *      */
        /*"      *  CAD 11586/2008                                                *      */
        /*"      *        EMISSAO DE BILHETES COM A NUMERACAO SEM DV ERRONEAMENTE *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.24    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  023 - 12/05/2008 - WANGER      (FAST COMPUTER)                *      */
        /*"      *  CAD 9772/2008                                                 *      */
        /*"      *        EMISSAO DE BILHETES COM A NUMERACAO SEM DV ERRONEAMENTE *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.23    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  022 - 02/04/2008 - WANGER      (FAST COMPUTER)                *      */
        /*"      *  SSI 19915/2007 E CAD 8560                                     *      */
        /*"      *                  ALTERA MARGEM DE DIFERENCA DO PAGO PARA A     *      */
        /*"      *                  COBERTURA                                     *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.22    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  021 - 20/02/2008 - MARCO PAIVA (FAST COMPUTER)                *      */
        /*"      *                                                                *      */
        /*"      *  SSI 20573/2008- ALTERA SITUACAO DOS BILHETE  95344918145,     *      */
        /*"      *                  84639305564,8259336748,8259357844,8259357843  *      */
        /*"      *                                                                *      */
        /*"      *  SSI 19779/2008- ALTERA SITUACAO DOS BILHETE  84637764910      *      */
        /*"      *                                                                *      */
        /*"      *  SSI 19783/2008- ALTERA SITUACAO DOS BILHETE  84638955530      *      */
        /*"      *                                                                *      */
        /*"      *  SSI 19367/2007- ALTERA SITUACAO DOS BILHETE  95335000718      *      */
        /*"      *                                               95335000726      *      */
        /*"      *                                                                *      */
        /*"      *  SSI 18418/2007- ALTERA SITUACAO DOS BILHETE  84637255780      *      */
        /*"      *                                                                *      */
        /*"      *  SSI 18087/2007- ALTERA SITUACAO DOS BILHETES 84553030079,     *      */
        /*"      *                                               84571676635      *      */
        /*"      *                                                                *      */
        /*"      *  SSI 16172/2007- ALTERA SITUACAO DOS BILHETES 84633012883,     *      */
        /*"      *                                84635706912,84625550006         *      */
        /*"      *                                                                *      */
        /*"      *  SSI 16044/2007- ALTERA SITUACAO DO  BILHETE  84627012397      *      */
        /*"      *                                                                *      */
        /*"      *  SSI 17713/2007- ALTERA SITUACAO DO  BILHETE  84611840295      *      */
        /*"      *                                                                *      */
        /*"      *  SSI 17708/2007- ALTERA SITUACAO DO  BILHETE  8259298302       *      */
        /*"      *                                                                *      */
        /*"      *  SSI 15736/2007- ALTERA SITUACAO DOS  BILHETES     84626494363 *      */
        /*"      *                                  84626712620, 84611727502      *      */
        /*"      *                                                                *      */
        /*"      *  SSI-17113  (24/07/2007) - ALTERA SITUACAO DOS BILHETES        *      */
        /*"      *                                  84626958360, 84627259848      *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.21    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  020 - 24/04/2007 - MARCO PAIVA (FAST COMPUTER)                *      */
        /*"      *  SSI 15008/2007- ALTERA SITUACAO DOS  BILHETES 84626006091     *      */
        /*"      *                                                                *      */
        /*"      *  OBS: SUBSTITUIDA V.19 POR V.20                                *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.20    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  019 - 07/03/2007 - LUCIA VIEIRA                               *      */
        /*"      *  SSI 13465/2007- ALTERA SITUACAO DOS  BILHETES 84625537808     *      */
        /*"      *                                                84622520254     *      */
        /*"      *                                                84570893497     *      */
        /*"      *                                            PROCURE POR V.19    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  018 - 26/12/2006 - LUCIA VIEIRA                               *      */
        /*"      *  SSI 12343/2006- INCLUI PESQUISA NAS TABELAS RCAP E RCAP COM-  *      */
        /*"      *                  PLEMENTO TAMBEM PELA FONTE                    *      */
        /*"      *                                            PROCURE POR V.18    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  017 - 13/04/2006 - TERCIO CARVALHO                            *      */
        /*"      *  SSI 8426/2006 - LIBERADA A CRITICA DE PROFISSAO PARA BILHETE  *      */
        /*"      *                                            PROCURE POR V.17    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  016 - 20/01/2004 - MANOEL MESSIAS                             *      */
        /*"      *  O PROGRAMA ESTAVA MUDANDO O RAMO DA V0BILHETE DE 14 PARA 82 O *      */
        /*"      *  QUE NAO EH CORRETO. QDO O RAMO FOR 14 NAO PERMITIR A TROCA.   *      */
        /*"      *                                            PROCURE POR MM2004  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  015 - 02/01/2004 - LUIZ FERNANDO GONCALVES                    *      */
        /*"      *  PERMITIR EMISSAO DO BILHETE 84536762296 COM IDADE ACIMA DO    *      */
        /*"      *  LIMITE. SOLICITO PELA SUPOV JOSE N LIMA.                      *      */
        /*"      *                                            PROCURE POR LF0102  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  014 - 05/12/2003 - LUIZ FERNANDO GONCALVES                    *      */
        /*"      *  PERMITIR EMISSAO DE BILHETES COMO AP OU RD EM FAIXAS DE       *      */
        /*"      *  NUMERACAO DE TITULO NAO PERTECENTE AO RAMO (TEMPORARIA)       *      */
        /*"      *  EM 02/01/2004 RETORNA VERSAO ORIGINAL     PROCURE POR LF1205  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  013 - 08/10/2003 - FREDERICO FONSECA                          *      */
        /*"      *  LIBEROU A EMISSAO DO BILHETE SINISTRADO 84535704403 A PEDIDO  *      */
        /*"      *    DO SR. PEDRO V FEITOSA - SUPOV                              *      */
        /*"      *                                            PROCURE POR PEDRO   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  012 - 26/03/2003 - TERCIO CARVALHO                            *      */
        /*"      *  LIBEROU PROFISSAO 'OUTROS' A PEDIDO DA GEPES                  *      */
        /*"      *                                            PROCURE POR TC0303  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  011 - 11/03/2003 - MANOEL MESSIAS                             *      */
        /*"      *  VOLTOU A ABENDAR NO UPDATE DA V0BILHETE R2230 COM (-310)      *      */
        /*"      *                                            PROCURE POR MM0303  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  010 - 10/03/2003 - TERCIO CARVALHO                            *      */
        /*"      *  PASSA A NAO LIBERAR O CODIGO 1803 - PROFISSAO DECLINAVEL      *      */
        /*"      *                                            PROCURE POR TL0303  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  009 - 13/12/2002 - MANOEL MESSIAS                             *      */
        /*"      *  ESTAVA ABENDANDO NO UPDATE DA V0BILHETE R2230 COM (-310).     *      */
        /*"      *                                            PROCURE POR MM1312  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  008 - 27/08/2002 - MANOEL MESSIAS                             *      */
        /*"      *  ESTAVA ABENDANDO NA LEITURA DA BI-BILHETE-ACATADO COM (-811). *      */
        /*"      *                                            PROCURE POR MM2708  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  007 - 26/08/2002 - MANOEL MESSIAS                             *      */
        /*"      *  CRITICAR PROFISSAO SOMENTE PARA O RAMO 82.                    *      */
        /*"      *                                            PROCURE POR MM2608  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  006 - 20/08/2002 - MANOEL MESSIAS                             *      */
        /*"      *  AUMENTAR O PERIODO DA DTLIBERACAO NA LEITURA DA TABELA V0SIS- *      */
        /*"      *  TEMA DE 30 DIAS PARA 1 ANO.                                   *      */
        /*"      *                                            PROCURE POR MM2008  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  005 - 14/08/2002 - TERCIO CARVALHO                            *      */
        /*"      *  RECUPERA A OPCOBER PARA TODOS DOS BILHETES QUE ESTA COLUNA    *      */
        /*"      *  ESTEJA ZERADA.                                                *      */
        /*"      *                                            PROCURE POR TL0218  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  004 - 12/08/2002 - TERCIO CARVALHO                            *      */
        /*"      *  FAZ O BATIMENTO DA PROFISSAO.                                 *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR TL0208  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  003 - 06/08/2002 - MANOEL MESSIAS                             *      */
        /*"      *  MUDAR O RAMO DOS BILHETES CADASTRADOS NO RAMO ERRADO. DO RAMO *      */
        /*"      * 72 (RD) PARA O RAMO 82 (AP) E VICE-VERSA.                      *      */
        /*"      *                                            PROCURE POR MM0608  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  002 - 30/08/2001 - CLOVIS                                     *      */
        /*"      * INCLUSAO DE SORT INTERNO COM ROTINA PARA LIBERACAO DE BILHETES *      */
        /*"      * CADASTRADOS NA V0BILHETE COM DIGITO INVALIDO.                  *      */
        /*"      *                                                                *      */
        /*"      * CLOVIS                                                         *      */
        /*"      * 30/08/2001                                                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  001 - 05/02/2001 - VIRGINIA                                   *      */
        /*"      * ALTERACAO SOLICITADA PELO SR. VINHAES POR NOTA (01/02/2001)    *      */
        /*"      * FOI ALTERADO O WHERE DA  R0400-00-DECLARE-V0BILHETE DE 'IN'    *      */
        /*"      * PARA 'BETWEEN'                                                 *      */
        /*"      * VIRGINIA                                                       *      */
        /*"      * 05/02/2001                                                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  002 - 25/02/2003 - VIRGINIA                                   *      */
        /*"      * ALTERADO PARA TRATAR O ERRO 1502 - OPCAO COBERTURA INVALIDA.   *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public SortBasis<CB0009B_REG_ARQSORT> ARQSORT { get; set; } = new SortBasis<CB0009B_REG_ARQSORT>(new CB0009B_REG_ARQSORT());
        /*"01        REG-ARQSORT.*/
        public CB0009B_REG_ARQSORT REG_ARQSORT { get; set; } = new CB0009B_REG_ARQSORT();
        public class CB0009B_REG_ARQSORT : VarBasis
        {
            /*"  05      SOR-NUMBIL          PIC  9(015).*/
            public IntBasis SOR_NUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05      SOR-NRTIT           PIC  9(015).*/
            public IntBasis SOR_NRTIT { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_AGE { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77    VIND-NULL01               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-COUNT                PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTNASC               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRMATRGER            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRMATRGER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VALADTGER            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_VALADTGER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTPAGGER             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTPAGGER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTCANCEL             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTCANCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRMATRSUN            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRMATRSUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VALADTSUN            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_VALADTSUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTPAGSUN             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTPAGSUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTLIBER              PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTLIBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VLPRMTOT             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_VLPRMTOT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODEMP               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NUMAPOL              PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRENDOS              PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRPARCEL             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRTIT                PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRTIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODPRODU             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-AGECOBR              PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-RECUPERA             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_RECUPERA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ACRESCIMO            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_ACRESCIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRCERTIF             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WS-SEQ-CRITICA            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis WS_SEQ_CRITICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-COD-PRODUTO          PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WS-PDT-LID-ANT            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis WS_PDT_LID_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WI                        PIC S9(003)     COMP VALUE +0.*/
        public IntBasis WI { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"77    WS-ANO-BASE               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis WS_ANO_BASE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WS-ANO-NASC               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis WS_ANO_NASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WS-IDADE                  PIC S9(003)     COMP VALUE +0.*/
        public IntBasis WS_IDADE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"77    WS-DAT-LID-ANT            PIC  X(010)     VALUE SPACES.*/
        public StringBasis WS_DAT_LID_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77    WS-PGM-CALL               PIC  X(008)     VALUE SPACES.*/
        public StringBasis WS_PGM_CALL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77    WSHOST-FONTE              PIC S9(004)     COMP.*/
        public IntBasis WSHOST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-AGECOBR            PIC S9(004)     COMP.*/
        public IntBasis WSHOST_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-SITUACAO           PIC  X(001).*/
        public StringBasis WSHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    WSHOST-VLPRMTOT1          PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLPRMTOT1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-VLPRMTOT2          PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLPRMTOT2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0SIST-DTMOVABE           PIC  X(010).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0SIST-DTPARAM            PIC  X(010).*/
        public StringBasis V0SIST_DTPARAM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0SIST-DTLIBERA           PIC  X(010).*/
        public StringBasis V0SIST_DTLIBERA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    CBO-COD-CBO               PIC S9(004)    COMP.*/
        public IntBasis CBO_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    CBO-DESCR-CBO             PIC  X(050).*/
        public StringBasis CBO_DESCR_CBO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
        /*"77    PESSOA-FISICA-COD-CBO     PIC S9(004)    COMP.*/
        public IntBasis PESSOA_FISICA_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    PRPFIDEL-COD-PESSOA       PIC S9(009)    COMP.*/
        public IntBasis PRPFIDEL_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    PRPFIDEL-ORIGEM           PIC S9(004)    COMP.*/
        public IntBasis PRPFIDEL_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    PRPFIDEL-CANAL            PIC S9(004)    COMP.*/
        public IntBasis PRPFIDEL_CANAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    PRPFIDEL-COD-PLANO        PIC S9(004)    COMP.*/
        public IntBasis PRPFIDEL_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0ACEF-AGENCIA            PIC S9(004)    COMP.*/
        public IntBasis V0ACEF_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0ACEF-ESCNEG             PIC S9(004)    COMP.*/
        public IntBasis V0ACEF_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0ACEF-FONTE              PIC S9(004)    COMP.*/
        public IntBasis V0ACEF_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0ACEF-SITUACAO           PIC  X(001).*/
        public StringBasis V0ACEF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    BI-COD-USUARIO            PIC  X(008).*/
        public StringBasis BI_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77    V0FONT-SITUACAO           PIC  X(001).*/
        public StringBasis V0FONT_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0BILH-NUMBIL             PIC S9(015)     COMP-3.*/
        public IntBasis V0BILH_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0BILH-NUMAPOL            PIC S9(015)     COMP-3.*/
        public IntBasis V0BILH_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0BILH-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0BILH_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-AGECOBR            PIC S9(004)     COMP.*/
        public IntBasis V0BILH_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-MATRICULA          PIC S9(015)     COMP-3.*/
        public IntBasis V0BILH_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0BILH-AGECONTA           PIC S9(004)     COMP.*/
        public IntBasis V0BILH_AGECONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-OPECONTA           PIC S9(004)     COMP.*/
        public IntBasis V0BILH_OPECONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-NUMCONTA           PIC S9(013)     COMP-3.*/
        public IntBasis V0BILH_NUMCONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0BILH-DIGCONTA           PIC S9(004)     COMP.*/
        public IntBasis V0BILH_DIGCONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-CODCLIEN           PIC S9(009)     COMP.*/
        public IntBasis V0BILH_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0BILH-PROFISSAO          PIC  X(020).*/
        public StringBasis V0BILH_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77    V0BILH-SEXO               PIC  X(001).*/
        public StringBasis V0BILH_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0BILH-ESTCIV             PIC  X(001).*/
        public StringBasis V0BILH_ESTCIV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0BILH-OCOREND            PIC S9(004)     COMP.*/
        public IntBasis V0BILH_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-AGECONDEB          PIC S9(004)     COMP.*/
        public IntBasis V0BILH_AGECONDEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-OPECONDEB          PIC S9(004)     COMP.*/
        public IntBasis V0BILH_OPECONDEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-NUMCONDEB          PIC S9(009)     COMP.*/
        public IntBasis V0BILH_NUMCONDEB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0BILH-DIGCONDEB          PIC S9(004)     COMP.*/
        public IntBasis V0BILH_DIGCONDEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-OPCOBER            PIC S9(004)     COMP.*/
        public IntBasis V0BILH_OPCOBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-DTQITBCO           PIC  X(010).*/
        public StringBasis V0BILH_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0BILH-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0BILH_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0BILH-RAMO               PIC S9(004)     COMP.*/
        public IntBasis V0BILH_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-DTVENDA            PIC  X(010).*/
        public StringBasis V0BILH_DTVENDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0BILH-DTMOVTO            PIC  X(010).*/
        public StringBasis V0BILH_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0BILH-NUMAPOLANT         PIC S9(015)     COMP-3.*/
        public IntBasis V0BILH_NUMAPOLANT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0BILH-SITUACAO           PIC  X(001).*/
        public StringBasis V0BILH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0BILH-TIPCANCEL          PIC  X(001).*/
        public StringBasis V0BILH_TIPCANCEL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0BILH-TIPSINIST          PIC  X(001).*/
        public StringBasis V0BILH_TIPSINIST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0BILH-CODUSU             PIC  X(008).*/
        public StringBasis V0BILH_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77    V0BILH-DTCANCEL           PIC  X(010).*/
        public StringBasis V0BILH_DTCANCEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0BILH-FX-RENDA-IND       PIC S9(004)     COMP.*/
        public IntBasis V0BILH_FX_RENDA_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-FX-RENDA-FAM       PIC S9(004)     COMP.*/
        public IntBasis V0BILH_FX_RENDA_FAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-COD-PRODUTO        PIC S9(004)     COMP.*/
        public IntBasis V0BILH_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BCOB-CODOPCAO           PIC S9(004)     COMP.*/
        public IntBasis V0BCOB_CODOPCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BCOB-VLPRMTOT           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0BCOB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0BCOB-VLPRMTOT1          PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0BCOB_VLPRMTOT1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0BCOB-VLPRMTOT2          PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0BCOB_VLPRMTOT2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0BCOB-DTINIVIG           PIC  X(010).*/
        public StringBasis V0BCOB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0BILP-CODPRODU          PIC S9(004)     COMP.*/
        public IntBasis V0BILP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0ERRO-NUMBIL             PIC S9(015)     COMP-3.*/
        public IntBasis V0ERRO_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0ERRO-CODERRO            PIC S9(004)     COMP.*/
        public IntBasis V0ERRO_CODERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0ERRO-MSG-CRITICA        PIC  X(040).*/
        public StringBasis V0ERRO_MSG_CRITICA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77    V0ERRO-COUNT              PIC S9(009)     COMP.*/
        public IntBasis V0ERRO_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-NUMAPOL            PIC S9(013)     COMP-3.*/
        public IntBasis V0FOLL_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0FOLL-SITUACAO           PIC  X(001).*/
        public StringBasis V0FOLL_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-OPERACAO           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-VLPREMIO           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0FOLL_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0FOLL-DTQITBCO           PIC  X(010).*/
        public StringBasis V0FOLL_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FOLL-DTLIBER            PIC  X(010).*/
        public StringBasis V0FOLL_DTLIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FOLL-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0FOLL_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCAP-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0RCAP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-NRRCAP             PIC S9(009)     COMP.*/
        public IntBasis V0RCAP_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCAP-NRPROPOS           PIC S9(009)     COMP.*/
        public IntBasis V0RCAP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCAP-NOME               PIC  X(040).*/
        public StringBasis V0RCAP_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77    V0RCAP-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0RCAP-VALPRI             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0RCAP_VALPRI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0RCAP-DTCADAST           PIC  X(010).*/
        public StringBasis V0RCAP_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCAP-DTMOVTO            PIC  X(010).*/
        public StringBasis V0RCAP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCAP-SITUACAO           PIC  X(001).*/
        public StringBasis V0RCAP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0RCAP-OPERACAO           PIC S9(004)     COMP.*/
        public IntBasis V0RCAP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0RCAP_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCAP-NUMAPOL            PIC S9(013)     COMP-3.*/
        public IntBasis V0RCAP_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0RCAP-NRENDOS            PIC S9(009)     COMP.*/
        public IntBasis V0RCAP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCAP-NRPARCEL           PIC S9(004)     COMP.*/
        public IntBasis V0RCAP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-NRTIT              PIC S9(013)     COMP-3.*/
        public IntBasis V0RCAP_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0RCAP-CODPRODU           PIC S9(004)     COMP.*/
        public IntBasis V0RCAP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-AGECOBR            PIC S9(004)     COMP.*/
        public IntBasis V0RCAP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-RECUPERA           PIC  X(001).*/
        public StringBasis V0RCAP_RECUPERA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0RCAP-ACRESCIMO          PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0RCAP_ACRESCIMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0RCAP-NRCERTIF           PIC S9(015)     COMP-3.*/
        public IntBasis V0RCAP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0RCOM-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0RCOM_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCOM-NRRCAP             PIC S9(009)     COMP.*/
        public IntBasis V0RCOM_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCOM-NRRCAPCO           PIC S9(009)     COMP.*/
        public IntBasis V0RCOM_NRRCAPCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCOM-OPERACAO           PIC S9(004)     COMP.*/
        public IntBasis V0RCOM_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCOM-DTMOVTO            PIC  X(010).*/
        public StringBasis V0RCOM_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCOM-HORAOPER           PIC  X(010).*/
        public StringBasis V0RCOM_HORAOPER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCOM-SITUACAO           PIC  X(001).*/
        public StringBasis V0RCOM_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0RCOM-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0RCOM_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCOM-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0RCOM_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCOM-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0RCOM_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCOM-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0RCOM_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0RCOM-DATARCAP           PIC  X(010).*/
        public StringBasis V0RCOM_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCOM-DTCADAST           PIC  X(010).*/
        public StringBasis V0RCOM_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCOM-SITCONTB           PIC  X(001).*/
        public StringBasis V0RCOM_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0RCOM-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0RCOM_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0CLIE-CODCLIEN           PIC S9(009)     COMP.*/
        public IntBasis V0CLIE_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0CLIE-NOME               PIC  X(040).*/
        public StringBasis V0CLIE_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77    V0CLIE-DTNASC             PIC  X(010).*/
        public StringBasis V0CLIE_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FCEF-MATRICULA          PIC S9(015)     COMP-3.*/
        public IntBasis V0FCEF_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0FCEF-AGECONTA           PIC S9(004)     COMP.*/
        public IntBasis V0FCEF_AGECONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FCEF-OPECONTA           PIC S9(004)     COMP.*/
        public IntBasis V0FCEF_OPECONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FCEF-NUMCONTA           PIC S9(013)     COMP-3.*/
        public IntBasis V0FCEF_NUMCONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0FCEF-DIGCONTA           PIC S9(004)     COMP.*/
        public IntBasis V0FCEF_DIGCONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0CFEN_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0CFEN-NUMBIL             PIC S9(015)     COMP-3.*/
        public IntBasis V0CFEN_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0CFEN-AGECOBR            PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-VALADT             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0CFEN_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0CFEN-DTCREDITO          PIC  X(010).*/
        public StringBasis V0CFEN_DTCREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CFEN-MATRICULA          PIC S9(015)     COMP-3.*/
        public IntBasis V0CFEN_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0CFEN-AGECONTA           PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_AGECONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-OPECONTA           PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_OPECONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-NUMCONTA           PIC S9(013)     COMP-3.*/
        public IntBasis V0CFEN_NUMCONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0CFEN-DIGCONTA           PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_DIGCONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-AGECTADEB          PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-OPRCTADEB          PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-NUMCTADEB          PIC S9(013)     COMP-3.*/
        public IntBasis V0CFEN_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0CFEN-DIGCTADEB          PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-SINDICO            PIC  X(040).*/
        public StringBasis V0CFEN_SINDICO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77    V0CFEN-DTQITBCO           PIC  X(010).*/
        public StringBasis V0CFEN_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CFEN-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0CFEN_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0CFEN-DTMOVTO            PIC  X(010).*/
        public StringBasis V0CFEN_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CFEN-SITUACAO           PIC  X(001).*/
        public StringBasis V0CFEN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0CFEN-NRMATRGER          PIC S9(015)     COMP-3.*/
        public IntBasis V0CFEN_NRMATRGER { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0CFEN-VALADTGER          PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0CFEN_VALADTGER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0CFEN-DTPAGGER           PIC  X(010).*/
        public StringBasis V0CFEN_DTPAGGER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CFEN-DTCANCEL           PIC  X(010).*/
        public StringBasis V0CFEN_DTCANCEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CFEN-NRMATRSUN          PIC S9(015)     COMP-3.*/
        public IntBasis V0CFEN_NRMATRSUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0CFEN-VALADTSUN          PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0CFEN_VALADTSUN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0CFEN-DTPAGSUN           PIC  X(010).*/
        public StringBasis V0CFEN_DTPAGSUN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0TRBL-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0TRBL_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0TRBL-MATRICULA          PIC S9(015)     COMP-3.*/
        public IntBasis V0TRBL_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0TRBL-TIPOFUNC           PIC  X(001).*/
        public StringBasis V0TRBL_TIPOFUNC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0TRBL-NRCERTIF           PIC S9(015)     COMP-3.*/
        public IntBasis V0TRBL_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0TRBL-DTMOVTO            PIC  X(010).*/
        public StringBasis V0TRBL_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0TRBL-CODPRODU           PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-SITUACAO           PIC  X(001).*/
        public StringBasis V0TRBL_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0TRBL-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-ESCNEG             PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-AGECOBR            PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0TRBL_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0TRBL-TARIFA             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0TRBL_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0TRBL-BALCAO             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0TRBL_BALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    VAL-PAGO-FIDELIZ          PIC S9(013)V99  COMP-3.*/
        public DoubleBasis VAL_PAGO_FIDELIZ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    BILFAI-RAMO               PIC S9(004)     COMP.*/
        public IntBasis BILFAI_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           NIVEIS-88.*/
        public CB0009B_NIVEIS_88 NIVEIS_88 { get; set; } = new CB0009B_NIVEIS_88();
        public class CB0009B_NIVEIS_88 : VarBasis
        {
            /*"  03         N88-NOVOS-ACESSOS  PIC  X(001)    VALUE  '&'.*/

            public SelectorBasis N88_NOVOS_ACESSOS { get; set; } = new SelectorBasis("001", "&")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88       NOVOS-ACESSOS                     VALUE  'S'. */
							new SelectorItemBasis("NOVOS_ACESSOS", "S")
                }
            };

            /*"01  TAB-CBO1.*/
        }
        public CB0009B_TAB_CBO1 TAB_CBO1 { get; set; } = new CB0009B_TAB_CBO1();
        public class CB0009B_TAB_CBO1 : VarBasis
        {
            /*"    05      TAB-CBO.*/
            public CB0009B_TAB_CBO TAB_CBO { get; set; } = new CB0009B_TAB_CBO();
            public class CB0009B_TAB_CBO : VarBasis
            {
                /*"      10    FILLER    OCCURS    999   TIMES.*/
                public ListBasis<CB0009B_FILLER_0> FILLER_0 { get; set; } = new ListBasis<CB0009B_FILLER_0>(999);
                public class CB0009B_FILLER_0 : VarBasis
                {
                    /*"        15  TAB-DESCR-CBO-C          PIC  X(20).*/
                    public StringBasis TAB_DESCR_CBO_C { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                    /*"01  WS-AUX-WORK.*/
                }
            }
        }
        public CB0009B_WS_AUX_WORK WS_AUX_WORK { get; set; } = new CB0009B_WS_AUX_WORK();
        public class CB0009B_WS_AUX_WORK : VarBasis
        {
            /*"  03  WFIM-CBO                  PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_CBO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  WFIM-AGENCIAS             PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_AGENCIAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  WFIM-V0BILHETE            PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_V0BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  WFIM-V0ERRO               PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_V0ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  WFIM-COBERTURA            PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  LD-V0BILHETE              PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_V0BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-BILACAT                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_BILACAT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-GERAL                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_GERAL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-GERAL                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_GERAL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-BILEMI                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_BILEMI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  ER-BILEMI                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis ER_BILEMI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-DTMENOR                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_DTMENOR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-FOLLOW                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_FOLLOW { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-FOLLOW                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_FOLLOW { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-FOLLOW                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_FOLLOW { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-COBRCAP                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_COBRCAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-RCAPNAO                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_RCAPNAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-RCAPDIV                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_RCAPDIV { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-RCAPUSO                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_RCAPUSO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-RCAPCAN                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_RCAPCAN { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-RCAP98                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_RCAP98 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-RCAP99                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_RCAP99 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-RCAP00                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_RCAP00 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-RCAP01                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_RCAP01 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-RCAP02                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_RCAP02 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-RCAP03                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_RCAP03 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-RCAP04                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_RCAP04 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-RCAP05                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_RCAP05 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-REATIVA                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_REATIVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-V0AVISO                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_V0AVISO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-FENAE                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_FENAE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-TARIFA                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_TARIFA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-COMINAO                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_COMINAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-IDADE                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_IDADE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-CLI1101                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_CLI1101 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-DTN1101                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_DTN1101 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-IDADE                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_IDADE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-IDADE                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_IDADE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-FILIAL                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_FILIAL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-FILIAL                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_FILIAL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-FILIAL                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_FILIAL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-FILIAL                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_FILIAL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-SEXO                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_SEXO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-SEXO                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_SEXO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-SEXO                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_SEXO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-NOME                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_NOME { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-NOME                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_NOME { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-NOME1                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_NOME1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-RENDA                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_RENDA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-RENDA                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_RENDA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-RENDA                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_RENDA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-CIVIL                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_CIVIL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-CIVIL                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_CIVIL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-CIVIL                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_CIVIL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-DAT1602                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_DAT1602 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-DAT1602                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_DAT1602 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-DAT1602                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_DAT1602 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-DAT1602                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_DAT1602 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-DAT1901                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_DAT1901 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-DAT1901                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_DAT1901 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-DAT1901                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_DAT1901 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-DAT1901                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_DAT1901 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-ERR1801                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_ERR1801 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-ERR1801                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_ERR1801 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-ERR1801                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_ERR1801 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-ERR1801                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_ERR1801 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-ERR1802                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_ERR1802 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-ERR1802                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_ERR1802 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-ERR1802                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_ERR1802 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-ERR1802                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_ERR1802 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-ERR1803                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_ERR1803 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-ERR1803                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_ERR1803 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-ERR1803                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_ERR1803 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-ERR1803                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_ERR1803 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-ERR1811                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_ERR1811 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-ERR1811                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_ERR1811 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-ERR1811                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_ERR1811 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-ERR1811                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_ERR1811 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-ERR1501                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_ERR1501 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-ERR1501                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_ERR1501 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-ERR1501                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_ERR1501 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-ERR1501                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_ERR1501 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-VAL1501                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_VAL1501 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-ERR1502                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_ERR1502 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-ERR1502                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_ERR1502 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-ERR1502                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_ERR1502 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-ERR1502                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_ERR1502 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-ERR1503                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_ERR1503 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-ERR1503                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_ERR1503 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-ERR1503                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_ERR1503 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-ERR1503                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_ERR1503 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-ERR2102                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_ERR2102 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-ERR2102                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_ERR2102 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-ERR2102                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_ERR2102 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-ERR2102                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_ERR2102 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-ERR2101                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_ERR2101 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-ERR2101                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_ERR2101 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-ERR2101                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_ERR2101 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-ERR2101                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_ERR2101 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-VAL2101                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_VAL2101 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-VAL2101                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_VAL2101 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-SUBS                   PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis WS_SUBS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  WS-ANOCALC                PIC S9(009)    COMP.*/
            public IntBasis WS_ANOCALC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03  AC-INDICADOR              PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_INDICADOR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-DTINIVIG               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_DTINIVIG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-BILHETE                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis WS_BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-BILHETE                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AL-BILHETE                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AL_BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-FENAE                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis WS_FENAE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-FENAE                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_FENAE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AL-FENAE                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AL_FENAE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-MATRIC                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis WS_MATRIC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-MATRIC                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_MATRIC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AL-MATRIC                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AL_MATRIC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-SITUA0                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_SITUA0 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-SITUA0                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_SITUA0 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-SITUA1                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_SITUA1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-SITUA1                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_SITUA1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-SITUAR                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_SITUAR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  ER-LIBERA                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis ER_LIBERA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  FU-DESPREZA               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis FU_DESPREZA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DE-ERROS                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DE_ERROS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  FU-ERROS                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis FU_ERROS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-VLRCAP                 PIC S9(013)V99  COMP-3.*/
            public DoubleBasis WS_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-VLDIFE                 PIC S9(013)V99  COMP-3.*/
            public DoubleBasis WS_VLDIFE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-VLDIFE2                PIC S9(013)V99  COMP-3.*/
            public DoubleBasis WS_VLDIFE2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-VLMAIOR                PIC S9(013)V99  COMP-3.*/
            public DoubleBasis WS_VLMAIOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SEM-ERROS                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis SEM_ERROS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  COM-ERROS                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis COM_ERROS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-FLAG                   PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WS_FLAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WS-FLAG-100               PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WS_FLAG_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  FLAG-COBERT               PIC  X(001)    VALUE   SPACES.*/
            public StringBasis FLAG_COBERT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  CL-SITUA0                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis CL_SITUA0 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  CL-DESPREZA               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis CL_DESPREZA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  CL-COBERT                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis CL_COBERT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  CL-SITUA1                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis CL_SITUA1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  CL-ALTERA                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis CL_ALTERA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AUX-VLDIFE                PIC  ZZ9,99.*/
            public DoubleBasis AUX_VLDIFE { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V99."), 2);
            /*"  03  AC-VLMAIOR                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_VLMAIOR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-VLMAIOR                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_VLMAIOR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-VLMAIOR                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_VLMAIOR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-VLMAIOR                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_VLMAIOR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-DTMENOR                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LB_DTMENOR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-DE72-PARA82            PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_DE72_PARA82 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-DE82-PARA72            PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_DE82_PARA72 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-ATU-RAMO               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_ATU_RAMO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-ATU-PROF               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_ATU_PROF { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-DES-PROF               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_DES_PROF { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WFIM-V1BILHETE            PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WFIM_V1BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-SORT                 PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  LD-V1BILHETE              PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_V1BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-TITULO                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_TITULO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-CANCELA                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_CANCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-UTILIZA                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_UTILIZA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-LIBERA                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_LIBERA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-RCAPNAO1               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_RCAPNAO1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-BILHNAO                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_BILHNAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  BI-LIBERA                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis BI_LIBERA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  BI-COMISSAO               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis BI_COMISSAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-SORT                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LD-SORT                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  IN-INSERT                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis IN_INSERT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  IN-DESPREZA               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis IN_DESPREZA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-RESULT                 PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis WS_RESULT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  WS-RESTO                  PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  WPARM11-AUX               PIC S9(007) VALUE ZEROS COMP-3.*/
            public IntBasis WPARM11_AUX { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  03  WERRO-UPDT                PIC  9(001) VALUE ZERO.*/
            public IntBasis WERRO_UPDT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_CB0009B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_CB0009B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_CB0009B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_CB0009B_FILLER_1 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-QUI         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_CB0009B_FILLER_1()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_QUI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-QUI.*/
            private _REDEF_CB0009B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_CB0009B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_CB0009B_FILLER_4(); _.Move(WDATA_QUI, _filler_4); VarBasis.RedefinePassValue(WDATA_QUI, _filler_4, WDATA_QUI); _filler_4.ValueChanged += () => { _.Move(_filler_4, WDATA_QUI); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WDATA_QUI); }
            }  //Redefines
            public class _REDEF_CB0009B_FILLER_4 : VarBasis
            {
                /*"    10       WDAT-QUI-ANO      PIC  9(004).*/
                public IntBasis WDAT_QUI_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-QUI-MES      PIC  9(002).*/
                public IntBasis WDAT_QUI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-QUI-DIA      PIC  9(002).*/
                public IntBasis WDAT_QUI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-NAS         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_CB0009B_FILLER_4()
                {
                    WDAT_QUI_ANO.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WDAT_QUI_MES.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    WDAT_QUI_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_NAS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-NAS.*/
            private _REDEF_CB0009B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_CB0009B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_CB0009B_FILLER_7(); _.Move(WDATA_NAS, _filler_7); VarBasis.RedefinePassValue(WDATA_NAS, _filler_7, WDATA_NAS); _filler_7.ValueChanged += () => { _.Move(_filler_7, WDATA_NAS); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, WDATA_NAS); }
            }  //Redefines
            public class _REDEF_CB0009B_FILLER_7 : VarBasis
            {
                /*"    10       WDAT-NAS-ANO      PIC  9(004).*/
                public IntBasis WDAT_NAS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-NAS-MES      PIC  9(002).*/
                public IntBasis WDAT_NAS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-NAS-DIA      PIC  9(002).*/
                public IntBasis WDAT_NAS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WMMDD-QUI         PIC  9(004)    VALUE ZEROS.*/

                public _REDEF_CB0009B_FILLER_7()
                {
                    WDAT_NAS_ANO.ValueChanged += OnValueChanged;
                    FILLER_8.ValueChanged += OnValueChanged;
                    WDAT_NAS_MES.ValueChanged += OnValueChanged;
                    FILLER_9.ValueChanged += OnValueChanged;
                    WDAT_NAS_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WMMDD_QUI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         FILLER            REDEFINES      WMMDD-QUI.*/
            private _REDEF_CB0009B_FILLER_10 _filler_10 { get; set; }
            public _REDEF_CB0009B_FILLER_10 FILLER_10
            {
                get { _filler_10 = new _REDEF_CB0009B_FILLER_10(); _.Move(WMMDD_QUI, _filler_10); VarBasis.RedefinePassValue(WMMDD_QUI, _filler_10, WMMDD_QUI); _filler_10.ValueChanged += () => { _.Move(_filler_10, WMMDD_QUI); }; return _filler_10; }
                set { VarBasis.RedefinePassValue(value, _filler_10, WMMDD_QUI); }
            }  //Redefines
            public class _REDEF_CB0009B_FILLER_10 : VarBasis
            {
                /*"    10       MMDD-QUI-MES      PIC  9(002).*/
                public IntBasis MMDD_QUI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       MMDD-QUI-DIA      PIC  9(002).*/
                public IntBasis MMDD_QUI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WMMDD-NAS         PIC  9(004)    VALUE ZEROS.*/

                public _REDEF_CB0009B_FILLER_10()
                {
                    MMDD_QUI_MES.ValueChanged += OnValueChanged;
                    MMDD_QUI_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WMMDD_NAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         FILLER            REDEFINES      WMMDD-NAS.*/
            private _REDEF_CB0009B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_CB0009B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_CB0009B_FILLER_11(); _.Move(WMMDD_NAS, _filler_11); VarBasis.RedefinePassValue(WMMDD_NAS, _filler_11, WMMDD_NAS); _filler_11.ValueChanged += () => { _.Move(_filler_11, WMMDD_NAS); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, WMMDD_NAS); }
            }  //Redefines
            public class _REDEF_CB0009B_FILLER_11 : VarBasis
            {
                /*"    10       MMDD-NAS-MES      PIC  9(002).*/
                public IntBasis MMDD_NAS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       MMDD-NAS-DIA      PIC  9(002).*/
                public IntBasis MMDD_NAS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WANO-NAS          PIC  9(004)    VALUE ZEROS.*/

                public _REDEF_CB0009B_FILLER_11()
                {
                    MMDD_NAS_MES.ValueChanged += OnValueChanged;
                    MMDD_NAS_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WANO_NAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         FILLER            REDEFINES      WANO-NAS.*/
            private _REDEF_CB0009B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_CB0009B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_CB0009B_FILLER_12(); _.Move(WANO_NAS, _filler_12); VarBasis.RedefinePassValue(WANO_NAS, _filler_12, WANO_NAS); _filler_12.ValueChanged += () => { _.Move(_filler_12, WANO_NAS); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, WANO_NAS); }
            }  //Redefines
            public class _REDEF_CB0009B_FILLER_12 : VarBasis
            {
                /*"    10       ANO-NAS-SS        PIC  9(002).*/
                public IntBasis ANO_NAS_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       ANO-NAS-AA        PIC  9(002).*/
                public IntBasis ANO_NAS_AA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-NRTIT           PIC  9(011)    VALUE   ZEROS.*/

                public _REDEF_CB0009B_FILLER_12()
                {
                    ANO_NAS_SS.ValueChanged += OnValueChanged;
                    ANO_NAS_AA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER             REDEFINES      WS-NRTIT.*/
            private _REDEF_CB0009B_FILLER_13 _filler_13 { get; set; }
            public _REDEF_CB0009B_FILLER_13 FILLER_13
            {
                get { _filler_13 = new _REDEF_CB0009B_FILLER_13(); _.Move(WS_NRTIT, _filler_13); VarBasis.RedefinePassValue(WS_NRTIT, _filler_13, WS_NRTIT); _filler_13.ValueChanged += () => { _.Move(_filler_13, WS_NRTIT); }; return _filler_13; }
                set { VarBasis.RedefinePassValue(value, _filler_13, WS_NRTIT); }
            }  //Redefines
            public class _REDEF_CB0009B_FILLER_13 : VarBasis
            {
                /*"      10     WS-NUMTIT          PIC  9(010).*/
                public IntBasis WS_NUMTIT { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      10     WS-DIGTIT          PIC  9(001).*/
                public IntBasis WS_DIGTIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WS-NUMBIL         PIC  9(011)    VALUE ZEROS.*/

                public _REDEF_CB0009B_FILLER_13()
                {
                    WS_NUMTIT.ValueChanged += OnValueChanged;
                    WS_DIGTIT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NUMBIL { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER            REDEFINES      WS-NUMBIL.*/
            private _REDEF_CB0009B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_CB0009B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_CB0009B_FILLER_14(); _.Move(WS_NUMBIL, _filler_14); VarBasis.RedefinePassValue(WS_NUMBIL, _filler_14, WS_NUMBIL); _filler_14.ValueChanged += () => { _.Move(_filler_14, WS_NUMBIL); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, WS_NUMBIL); }
            }  //Redefines
            public class _REDEF_CB0009B_FILLER_14 : VarBasis
            {
                /*"    10       WS-PRENRO         PIC  9(001).*/
                public IntBasis WS_PRENRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       WS-NRRCAP         PIC  9(009).*/
                public IntBasis WS_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10       WS-DIGNRO         PIC  9(001).*/
                public IntBasis WS_DIGNRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WS-BIL-ATM        PIC  X(001)    VALUE SPACES.*/

                public _REDEF_CB0009B_FILLER_14()
                {
                    WS_PRENRO.ValueChanged += OnValueChanged;
                    WS_NRRCAP.ValueChanged += OnValueChanged;
                    WS_DIGNRO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_BIL_ATM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03        WABEND.*/
            public CB0009B_WABEND WABEND { get; set; } = new CB0009B_WABEND();
            public class CB0009B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' CB0009B  '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" CB0009B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01  WS-AGENCIACEF.*/
            }
        }
        public CB0009B_WS_AGENCIACEF WS_AGENCIACEF { get; set; } = new CB0009B_WS_AGENCIACEF();
        public class CB0009B_WS_AGENCIACEF : VarBasis
        {
            /*"  03          WACEF-AGENCIAS.*/
            public CB0009B_WACEF_AGENCIAS WACEF_AGENCIAS { get; set; } = new CB0009B_WACEF_AGENCIAS();
            public class CB0009B_WACEF_AGENCIAS : VarBasis
            {
                /*"    05        WACEF-OCORREAGE     OCCURS       6000  TIMES                                  INDEXED      BY    WS-AGE.*/
                public ListBasis<CB0009B_WACEF_OCORREAGE> WACEF_OCORREAGE { get; set; } = new ListBasis<CB0009B_WACEF_OCORREAGE>(6000);
                public class CB0009B_WACEF_OCORREAGE : VarBasis
                {
                    /*"    10        WACEF-AGENCIA       PIC S9(004)        COMP.*/
                    public IntBasis WACEF_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"    10        WACEF-ESCNEG        PIC S9(004)        COMP.*/
                    public IntBasis WACEF_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"    10        WACEF-FONTE         PIC S9(004)        COMP.*/
                    public IntBasis WACEF_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"    10        WACEF-SITUACAO      PIC  X(001).*/
                    public StringBasis WACEF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"01             LPARM11X.*/
                }
            }
            public CB0009B_LPARM11X LPARM11X { get; set; } = new CB0009B_LPARM11X();
            public class CB0009B_LPARM11X : VarBasis
            {
                /*"  03           LPARM11            PIC  9(010).*/
                public IntBasis LPARM11 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"  03           FILLER             REDEFINES   LPARM11.*/
                private _REDEF_CB0009B_FILLER_20 _filler_20 { get; set; }
                public _REDEF_CB0009B_FILLER_20 FILLER_20
                {
                    get { _filler_20 = new _REDEF_CB0009B_FILLER_20(); _.Move(LPARM11, _filler_20); VarBasis.RedefinePassValue(LPARM11, _filler_20, LPARM11); _filler_20.ValueChanged += () => { _.Move(_filler_20, LPARM11); }; return _filler_20; }
                    set { VarBasis.RedefinePassValue(value, _filler_20, LPARM11); }
                }  //Redefines
                public class _REDEF_CB0009B_FILLER_20 : VarBasis
                {
                    /*"    05         LPARM11-1          PIC  9(001).*/
                    public IntBasis LPARM11_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    05         LPARM11-2          PIC  9(001).*/
                    public IntBasis LPARM11_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    05         LPARM11-3          PIC  9(001).*/
                    public IntBasis LPARM11_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    05         LPARM11-4          PIC  9(001).*/
                    public IntBasis LPARM11_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    05         LPARM11-5          PIC  9(001).*/
                    public IntBasis LPARM11_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    05         LPARM11-6          PIC  9(001).*/
                    public IntBasis LPARM11_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    05         LPARM11-7          PIC  9(001).*/
                    public IntBasis LPARM11_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    05         LPARM11-8          PIC  9(001).*/
                    public IntBasis LPARM11_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    05         LPARM11-9          PIC  9(001).*/
                    public IntBasis LPARM11_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    05         LPARM11-10         PIC  9(001).*/
                    public IntBasis LPARM11_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"01            LPARM.*/

                    public _REDEF_CB0009B_FILLER_20()
                    {
                        LPARM11_1.ValueChanged += OnValueChanged;
                        LPARM11_2.ValueChanged += OnValueChanged;
                        LPARM11_3.ValueChanged += OnValueChanged;
                        LPARM11_4.ValueChanged += OnValueChanged;
                        LPARM11_5.ValueChanged += OnValueChanged;
                        LPARM11_6.ValueChanged += OnValueChanged;
                        LPARM11_7.ValueChanged += OnValueChanged;
                        LPARM11_8.ValueChanged += OnValueChanged;
                        LPARM11_9.ValueChanged += OnValueChanged;
                        LPARM11_10.ValueChanged += OnValueChanged;
                    }

                }
            }
            public CB0009B_LPARM LPARM { get; set; } = new CB0009B_LPARM();
            public class CB0009B_LPARM : VarBasis
            {
                /*"  03          LPARM01.*/
                public CB0009B_LPARM01 LPARM01 { get; set; } = new CB0009B_LPARM01();
                public class CB0009B_LPARM01 : VarBasis
                {
                    /*"    10        LPARM01-DD          PIC  9(002).*/
                    public IntBasis LPARM01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10        LPARM01-MM          PIC  9(002).*/
                    public IntBasis LPARM01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10        LPARM01-AA          PIC  9(004).*/
                    public IntBasis LPARM01_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"  03          LPARM02.*/
                }
                public CB0009B_LPARM02 LPARM02 { get; set; } = new CB0009B_LPARM02();
                public class CB0009B_LPARM02 : VarBasis
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
        }


        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Copies.GE0070W GE0070W { get; set; } = new Copies.GE0070W();
        public Copies.GE0071W GE0071W { get; set; } = new Copies.GE0071W();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public Dclgens.VG102 VG102 { get; set; } = new Dclgens.VG102();
        public CB0009B_V0AGENCIAS V0AGENCIAS { get; set; } = new CB0009B_V0AGENCIAS();
        public CB0009B_V0BILHETE V0BILHETE { get; set; } = new CB0009B_V0BILHETE();
        public CB0009B_V0ERRO V0ERRO { get; set; } = new CB0009B_V0ERRO();
        public CB0009B_V1ERRO V1ERRO { get; set; } = new CB0009B_V1ERRO();
        public CB0009B_V2ERRO V2ERRO { get; set; } = new CB0009B_V2ERRO();
        public CB0009B_V0COBERTURA V0COBERTURA { get; set; } = new CB0009B_V0COBERTURA();
        public CB0009B_V1BILHETE V1BILHETE { get; set; } = new CB0009B_V1BILHETE();
        public CB0009B_CCBO CCBO { get; set; } = new CB0009B_CCBO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSORT_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQSORT.SetFile(ARQSORT_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -1008- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1009- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1011- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1013- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1016- DISPLAY '------------------------------------------' . */
            _.Display($"------------------------------------------");

            /*" -1017- DISPLAY 'CB0009B - LIBERACAO DE BILHETES PARA ERROS' */
            _.Display($"CB0009B - LIBERACAO DE BILHETES PARA ERROS");

            /*" -1018- DISPLAY 'ROTINA: JPEMD01                           ' . */
            _.Display($"ROTINA: JPEMD01                           ");

            /*" -1019- DISPLAY '                                          ' . */
            _.Display($"                                          ");

            /*" -1037- DISPLAY 'VERSAO V.50 EM 20/08/2024 INCIDENTE 599595' . */
            _.Display($"VERSAO V.50 EM 20/08/2024 INCIDENTE 599595");

            /*" -1039- DISPLAY '------------------------------------------' . */
            _.Display($"------------------------------------------");

            /*" -1042- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -1050- SORT ARQSORT ON ASCENDING KEY SOR-NUMBIL INPUT PROCEDURE R7000-00-INPUT-SORT THRU R7000-99-SAIDA OUTPUT PROCEDURE R7500-00-OUTPUT-SORT THRU R7500-99-SAIDA. */
            ARQSORT.Sort("SOR-NUMBIL", () => R7000_00_INPUT_SORT_SECTION(), () => R7500_00_OUTPUT_SORT_SECTION());

            /*" -1053- MOVE SPACES TO WFIM-V0BILHETE */
            _.Move("", WS_AUX_WORK.WFIM_V0BILHETE);

            /*" -1055- PERFORM R0400-00-DECLARE-V0BILHETE. */

            R0400_00_DECLARE_V0BILHETE_SECTION();

            /*" -1057- PERFORM R0410-00-FETCH-V0BILHETE. */

            R0410_00_FETCH_V0BILHETE_SECTION();

            /*" -1058- PERFORM R0450-00-PROCESSA-V0BILHETE UNTIL WFIM-V0BILHETE NOT EQUAL SPACES. */

            while (!(!WS_AUX_WORK.WFIM_V0BILHETE.IsEmpty()))
            {

                R0450_00_PROCESSA_V0BILHETE_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1063- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1067- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1068- DISPLAY ' ' */
            _.Display($" ");

            /*" -1069- DISPLAY 'CB0009B - FIM NORMAL' . */
            _.Display($"CB0009B - FIM NORMAL");

            /*" -1070- DISPLAY ' ' */
            _.Display($" ");

            /*" -1071- DISPLAY 'LIDOS V0BILHETE ....... ' LD-V0BILHETE */
            _.Display($"LIDOS V0BILHETE ....... {WS_AUX_WORK.LD_V0BILHETE}");

            /*" -1072- DISPLAY 'ALTERA BILHETE EMITIDO. ' AC-BILEMI */
            _.Display($"ALTERA BILHETE EMITIDO. {WS_AUX_WORK.AC_BILEMI}");

            /*" -1073- DISPLAY 'ERRO   BILHETE EMITIDO. ' ER-BILEMI */
            _.Display($"ERRO   BILHETE EMITIDO. {WS_AUX_WORK.ER_BILEMI}");

            /*" -1074- DISPLAY 'ACATA BILHETE ......... ' AC-BILACAT */
            _.Display($"ACATA BILHETE ......... {WS_AUX_WORK.AC_BILACAT}");

            /*" -1075- DISPLAY ' ' */
            _.Display($" ");

            /*" -1076- DISPLAY 'DESPREZA MAIOR 1 ANO .. ' AC-DTMENOR */
            _.Display($"DESPREZA MAIOR 1 ANO .. {WS_AUX_WORK.AC_DTMENOR}");

            /*" -1077- DISPLAY 'RCAP DIVERGENTE ....... ' AC-RCAPDIV */
            _.Display($"RCAP DIVERGENTE ....... {WS_AUX_WORK.AC_RCAPDIV}");

            /*" -1078- DISPLAY 'RCAP NAO CADASTRADO ... ' AC-RCAPNAO */
            _.Display($"RCAP NAO CADASTRADO ... {WS_AUX_WORK.AC_RCAPNAO}");

            /*" -1079- DISPLAY 'NAO CADASTRADO 1998 ... ' AC-RCAP98 */
            _.Display($"NAO CADASTRADO 1998 ... {WS_AUX_WORK.AC_RCAP98}");

            /*" -1080- DISPLAY 'NAO CADASTRADO 1999 ... ' AC-RCAP99 */
            _.Display($"NAO CADASTRADO 1999 ... {WS_AUX_WORK.AC_RCAP99}");

            /*" -1081- DISPLAY 'NAO CADASTRADO 2000 ... ' AC-RCAP00 */
            _.Display($"NAO CADASTRADO 2000 ... {WS_AUX_WORK.AC_RCAP00}");

            /*" -1082- DISPLAY 'NAO CADASTRADO 2001 ... ' AC-RCAP01 */
            _.Display($"NAO CADASTRADO 2001 ... {WS_AUX_WORK.AC_RCAP01}");

            /*" -1083- DISPLAY 'NAO CADASTRADO 2002 ... ' AC-RCAP02 */
            _.Display($"NAO CADASTRADO 2002 ... {WS_AUX_WORK.AC_RCAP02}");

            /*" -1084- DISPLAY 'NAO CADASTRADO 2003 ... ' AC-RCAP03 */
            _.Display($"NAO CADASTRADO 2003 ... {WS_AUX_WORK.AC_RCAP03}");

            /*" -1085- DISPLAY 'NAO CADASTRADO 2004 ... ' AC-RCAP04 */
            _.Display($"NAO CADASTRADO 2004 ... {WS_AUX_WORK.AC_RCAP04}");

            /*" -1086- DISPLAY 'NAO CADASTRADO 2005 ... ' AC-RCAP05 */
            _.Display($"NAO CADASTRADO 2005 ... {WS_AUX_WORK.AC_RCAP05}");

            /*" -1087- DISPLAY 'RCAP JA UTILIZADO ..... ' AC-RCAPUSO */
            _.Display($"RCAP JA UTILIZADO ..... {WS_AUX_WORK.AC_RCAPUSO}");

            /*" -1088- DISPLAY 'RCAP CANCELADO ........ ' AC-RCAPCAN */
            _.Display($"RCAP CANCELADO ........ {WS_AUX_WORK.AC_RCAPCAN}");

            /*" -1089- DISPLAY ' ' */
            _.Display($" ");

            /*" -1090- DISPLAY 'DESPREZA GERAL ........ ' DP-GERAL */
            _.Display($"DESPREZA GERAL ........ {WS_AUX_WORK.DP_GERAL}");

            /*" -1091- DISPLAY 'ALTERA   GERAL ........ ' UP-GERAL */
            _.Display($"ALTERA   GERAL ........ {WS_AUX_WORK.UP_GERAL}");

            /*" -1092- DISPLAY ' ' */
            _.Display($" ");

            /*" -1093- DISPLAY 'TRATA    FOLLOWUP ..... ' AC-FOLLOW */
            _.Display($"TRATA    FOLLOWUP ..... {WS_AUX_WORK.AC_FOLLOW}");

            /*" -1094- DISPLAY 'DESPREZA FOLLOWUP ..... ' DP-FOLLOW */
            _.Display($"DESPREZA FOLLOWUP ..... {WS_AUX_WORK.DP_FOLLOW}");

            /*" -1095- DISPLAY 'ALTERA   FOLLOWUP ..... ' UP-FOLLOW */
            _.Display($"ALTERA   FOLLOWUP ..... {WS_AUX_WORK.UP_FOLLOW}");

            /*" -1096- DISPLAY 'ALTERA   COB. RCAP .... ' AC-COBRCAP */
            _.Display($"ALTERA   COB. RCAP .... {WS_AUX_WORK.AC_COBRCAP}");

            /*" -1097- DISPLAY 'INSERE FENAE .......... ' AC-FENAE */
            _.Display($"INSERE FENAE .......... {WS_AUX_WORK.AC_FENAE}");

            /*" -1098- DISPLAY 'INSERE TARIFA ......... ' AC-TARIFA */
            _.Display($"INSERE TARIFA ......... {WS_AUX_WORK.AC_TARIFA}");

            /*" -1099- DISPLAY 'COMISSAO NAO CADASTR... ' AC-COMINAO */
            _.Display($"COMISSAO NAO CADASTR... {WS_AUX_WORK.AC_COMINAO}");

            /*" -1100- DISPLAY 'DESPREZA DTINIVIG ..... ' AC-DTINIVIG */
            _.Display($"DESPREZA DTINIVIG ..... {WS_AUX_WORK.AC_DTINIVIG}");

            /*" -1101- DISPLAY ' ' */
            _.Display($" ");

            /*" -1102- DISPLAY 'REATIVA RCAP .......... ' AC-REATIVA */
            _.Display($"REATIVA RCAP .......... {WS_AUX_WORK.AC_REATIVA}");

            /*" -1103- DISPLAY 'ALTERA SALDO AVISO .... ' UP-V0AVISO */
            _.Display($"ALTERA SALDO AVISO .... {WS_AUX_WORK.UP_V0AVISO}");

            /*" -1104- DISPLAY ' ' */
            _.Display($" ");

            /*" -1105- DISPLAY 'TRATA NOME ............ ' AC-NOME */
            _.Display($"TRATA NOME ............ {WS_AUX_WORK.AC_NOME}");

            /*" -1106- DISPLAY 'LIBERA NOME BILHETE ... ' LB-NOME */
            _.Display($"LIBERA NOME BILHETE ... {WS_AUX_WORK.LB_NOME}");

            /*" -1107- DISPLAY 'LIBERA NOME APOLICE ... ' LB-NOME1 */
            _.Display($"LIBERA NOME APOLICE ... {WS_AUX_WORK.LB_NOME1}");

            /*" -1108- DISPLAY ' ' */
            _.Display($" ");

            /*" -1109- DISPLAY 'TRATA SEXO ............ ' AC-SEXO */
            _.Display($"TRATA SEXO ............ {WS_AUX_WORK.AC_SEXO}");

            /*" -1110- DISPLAY 'DESPREZA SEXO ......... ' DP-SEXO */
            _.Display($"DESPREZA SEXO ......... {WS_AUX_WORK.DP_SEXO}");

            /*" -1111- DISPLAY 'LIBERA SEXO ........... ' LB-SEXO */
            _.Display($"LIBERA SEXO ........... {WS_AUX_WORK.LB_SEXO}");

            /*" -1112- DISPLAY ' ' */
            _.Display($" ");

            /*" -1113- DISPLAY 'TRATA RENDA ........... ' AC-RENDA */
            _.Display($"TRATA RENDA ........... {WS_AUX_WORK.AC_RENDA}");

            /*" -1114- DISPLAY 'DESPREZA RENDA ........ ' DP-RENDA */
            _.Display($"DESPREZA RENDA ........ {WS_AUX_WORK.DP_RENDA}");

            /*" -1115- DISPLAY 'LIBERA RENDA........... ' LB-RENDA */
            _.Display($"LIBERA RENDA........... {WS_AUX_WORK.LB_RENDA}");

            /*" -1116- DISPLAY ' ' */
            _.Display($" ");

            /*" -1117- DISPLAY 'TRATA EST. CIVIL ...... ' AC-CIVIL */
            _.Display($"TRATA EST. CIVIL ...... {WS_AUX_WORK.AC_CIVIL}");

            /*" -1118- DISPLAY 'DESPREZA EST. CIVIL ... ' DP-CIVIL */
            _.Display($"DESPREZA EST. CIVIL ... {WS_AUX_WORK.DP_CIVIL}");

            /*" -1119- DISPLAY 'LIBERA EST. CIVIL ..... ' LB-CIVIL */
            _.Display($"LIBERA EST. CIVIL ..... {WS_AUX_WORK.LB_CIVIL}");

            /*" -1120- DISPLAY ' ' */
            _.Display($" ");

            /*" -1121- DISPLAY 'TRATA IDADE (1101) .... ' AC-IDADE */
            _.Display($"TRATA IDADE (1101) .... {WS_AUX_WORK.AC_IDADE}");

            /*" -1122- DISPLAY 'DESPREZA CLIENTE ...... ' DP-CLI1101 */
            _.Display($"DESPREZA CLIENTE ...... {WS_AUX_WORK.DP_CLI1101}");

            /*" -1123- DISPLAY 'DESPREZA DTNASC ....... ' DP-DTN1101 */
            _.Display($"DESPREZA DTNASC ....... {WS_AUX_WORK.DP_DTN1101}");

            /*" -1124- DISPLAY 'DESPREZA IDADE ........ ' DP-IDADE */
            _.Display($"DESPREZA IDADE ........ {WS_AUX_WORK.DP_IDADE}");

            /*" -1125- DISPLAY 'LIBERA COD. (1101) .... ' LB-IDADE */
            _.Display($"LIBERA COD. (1101) .... {WS_AUX_WORK.LB_IDADE}");

            /*" -1126- DISPLAY ' ' */
            _.Display($" ");

            /*" -1127- DISPLAY 'TRATA FILIAL/AGENCIA .. ' AC-FILIAL */
            _.Display($"TRATA FILIAL/AGENCIA .. {WS_AUX_WORK.AC_FILIAL}");

            /*" -1128- DISPLAY 'DESPREZA FIL/AGE ...... ' DP-FILIAL */
            _.Display($"DESPREZA FIL/AGE ...... {WS_AUX_WORK.DP_FILIAL}");

            /*" -1129- DISPLAY 'LIBERA FILIAL/AGENCIA . ' LB-FILIAL */
            _.Display($"LIBERA FILIAL/AGENCIA . {WS_AUX_WORK.LB_FILIAL}");

            /*" -1130- DISPLAY 'ALTERA FILIAL/AGENCIA . ' UP-FILIAL */
            _.Display($"ALTERA FILIAL/AGENCIA . {WS_AUX_WORK.UP_FILIAL}");

            /*" -1131- DISPLAY ' ' */
            _.Display($" ");

            /*" -1132- DISPLAY 'TRATA DTQITBCO(1602) .. ' AC-DAT1602 */
            _.Display($"TRATA DTQITBCO(1602) .. {WS_AUX_WORK.AC_DAT1602}");

            /*" -1133- DISPLAY 'DESPREZA (1602) ....... ' DP-DAT1602 */
            _.Display($"DESPREZA (1602) ....... {WS_AUX_WORK.DP_DAT1602}");

            /*" -1134- DISPLAY 'LIBERA DTQITBCO(1602) . ' LB-DAT1602 */
            _.Display($"LIBERA DTQITBCO(1602) . {WS_AUX_WORK.LB_DAT1602}");

            /*" -1135- DISPLAY 'ALTERA DTQITBCO(1602) . ' UP-DAT1602 */
            _.Display($"ALTERA DTQITBCO(1602) . {WS_AUX_WORK.UP_DAT1602}");

            /*" -1136- DISPLAY ' ' */
            _.Display($" ");

            /*" -1137- DISPLAY 'TRATA DATARCAP(1901) .. ' AC-DAT1901 */
            _.Display($"TRATA DATARCAP(1901) .. {WS_AUX_WORK.AC_DAT1901}");

            /*" -1138- DISPLAY 'DESPREZA (1901) ....... ' DP-DAT1901 */
            _.Display($"DESPREZA (1901) ....... {WS_AUX_WORK.DP_DAT1901}");

            /*" -1139- DISPLAY 'LIBERA DATARCAP(1901) . ' LB-DAT1901 */
            _.Display($"LIBERA DATARCAP(1901) . {WS_AUX_WORK.LB_DAT1901}");

            /*" -1140- DISPLAY 'ALTERA DATARCAP(1901) . ' UP-DAT1901 */
            _.Display($"ALTERA DATARCAP(1901) . {WS_AUX_WORK.UP_DAT1901}");

            /*" -1141- DISPLAY ' ' */
            _.Display($" ");

            /*" -1142- DISPLAY 'TRATA ERRO(1801) ...... ' AC-ERR1801 */
            _.Display($"TRATA ERRO(1801) ...... {WS_AUX_WORK.AC_ERR1801}");

            /*" -1143- DISPLAY 'DESPREZA (1801) ....... ' DP-ERR1801 */
            _.Display($"DESPREZA (1801) ....... {WS_AUX_WORK.DP_ERR1801}");

            /*" -1144- DISPLAY 'LIBERA (1801) ......... ' LB-ERR1801 */
            _.Display($"LIBERA (1801) ......... {WS_AUX_WORK.LB_ERR1801}");

            /*" -1145- DISPLAY 'ALTERA (1801) ......... ' UP-ERR1801 */
            _.Display($"ALTERA (1801) ......... {WS_AUX_WORK.UP_ERR1801}");

            /*" -1146- DISPLAY ' ' */
            _.Display($" ");

            /*" -1147- DISPLAY 'TRATA ERRO(1802) ...... ' AC-ERR1802 */
            _.Display($"TRATA ERRO(1802) ...... {WS_AUX_WORK.AC_ERR1802}");

            /*" -1148- DISPLAY 'DESPREZA (1802) ....... ' DP-ERR1802 */
            _.Display($"DESPREZA (1802) ....... {WS_AUX_WORK.DP_ERR1802}");

            /*" -1149- DISPLAY 'LIBERA (1802) ......... ' LB-ERR1802 */
            _.Display($"LIBERA (1802) ......... {WS_AUX_WORK.LB_ERR1802}");

            /*" -1150- DISPLAY 'ALTERA (1802) ......... ' UP-ERR1802 */
            _.Display($"ALTERA (1802) ......... {WS_AUX_WORK.UP_ERR1802}");

            /*" -1151- DISPLAY ' ' */
            _.Display($" ");

            /*" -1152- DISPLAY 'TRATA ERRO(1803) ...... ' AC-ERR1803 */
            _.Display($"TRATA ERRO(1803) ...... {WS_AUX_WORK.AC_ERR1803}");

            /*" -1153- DISPLAY 'DESPREZA (1803) ....... ' DP-ERR1803 */
            _.Display($"DESPREZA (1803) ....... {WS_AUX_WORK.DP_ERR1803}");

            /*" -1154- DISPLAY 'LIBERA (1803) ......... ' LB-ERR1803 */
            _.Display($"LIBERA (1803) ......... {WS_AUX_WORK.LB_ERR1803}");

            /*" -1155- DISPLAY 'ALTERA (1803) ......... ' UP-ERR1803 */
            _.Display($"ALTERA (1803) ......... {WS_AUX_WORK.UP_ERR1803}");

            /*" -1156- DISPLAY ' ' */
            _.Display($" ");

            /*" -1157- DISPLAY 'TRATA ERRO(1811) ...... ' AC-ERR1811 */
            _.Display($"TRATA ERRO(1811) ...... {WS_AUX_WORK.AC_ERR1811}");

            /*" -1158- DISPLAY 'DESPREZA (1811) ....... ' DP-ERR1811 */
            _.Display($"DESPREZA (1811) ....... {WS_AUX_WORK.DP_ERR1811}");

            /*" -1159- DISPLAY 'LIBERA (1811) ......... ' LB-ERR1811 */
            _.Display($"LIBERA (1811) ......... {WS_AUX_WORK.LB_ERR1811}");

            /*" -1160- DISPLAY 'ALTERA (1811) ......... ' UP-ERR1811 */
            _.Display($"ALTERA (1811) ......... {WS_AUX_WORK.UP_ERR1811}");

            /*" -1161- DISPLAY ' ' */
            _.Display($" ");

            /*" -1162- DISPLAY 'TRATA ERRO(1501) ...... ' AC-ERR1501 */
            _.Display($"TRATA ERRO(1501) ...... {WS_AUX_WORK.AC_ERR1501}");

            /*" -1163- DISPLAY 'ALTERA VALOR (1501) ... ' UP-VAL1501 */
            _.Display($"ALTERA VALOR (1501) ... {WS_AUX_WORK.UP_VAL1501}");

            /*" -1164- DISPLAY 'DESPREZA (1501) ....... ' DP-ERR1501 */
            _.Display($"DESPREZA (1501) ....... {WS_AUX_WORK.DP_ERR1501}");

            /*" -1165- DISPLAY 'LIBERA (1501) ......... ' LB-ERR1501 */
            _.Display($"LIBERA (1501) ......... {WS_AUX_WORK.LB_ERR1501}");

            /*" -1166- DISPLAY 'ALTERA (1501) ......... ' UP-ERR1501 */
            _.Display($"ALTERA (1501) ......... {WS_AUX_WORK.UP_ERR1501}");

            /*" -1167- DISPLAY ' ' */
            _.Display($" ");

            /*" -1168- DISPLAY 'TRATA ERRO(1502) ...... ' AC-ERR1502 */
            _.Display($"TRATA ERRO(1502) ...... {WS_AUX_WORK.AC_ERR1502}");

            /*" -1169- DISPLAY 'DESPREZA (1502) ....... ' DP-ERR1502 */
            _.Display($"DESPREZA (1502) ....... {WS_AUX_WORK.DP_ERR1502}");

            /*" -1170- DISPLAY 'LIBERA (1502) ......... ' LB-ERR1502 */
            _.Display($"LIBERA (1502) ......... {WS_AUX_WORK.LB_ERR1502}");

            /*" -1171- DISPLAY 'ALTERA (1502) ......... ' UP-ERR1502 */
            _.Display($"ALTERA (1502) ......... {WS_AUX_WORK.UP_ERR1502}");

            /*" -1172- DISPLAY ' ' */
            _.Display($" ");

            /*" -1173- DISPLAY ' ' */
            _.Display($" ");

            /*" -1174- DISPLAY 'TRATA ERRO(1503) ...... ' AC-ERR1503 */
            _.Display($"TRATA ERRO(1503) ...... {WS_AUX_WORK.AC_ERR1503}");

            /*" -1175- DISPLAY 'DESPREZA (1503) ....... ' DP-ERR1503 */
            _.Display($"DESPREZA (1503) ....... {WS_AUX_WORK.DP_ERR1503}");

            /*" -1176- DISPLAY 'LIBERA (1503) ......... ' LB-ERR1503 */
            _.Display($"LIBERA (1503) ......... {WS_AUX_WORK.LB_ERR1503}");

            /*" -1177- DISPLAY 'ALTERA (1503) ......... ' UP-ERR1503 */
            _.Display($"ALTERA (1503) ......... {WS_AUX_WORK.UP_ERR1503}");

            /*" -1178- DISPLAY ' ' */
            _.Display($" ");

            /*" -1179- DISPLAY 'TRATA ERRO(2102) ...... ' AC-ERR2102 */
            _.Display($"TRATA ERRO(2102) ...... {WS_AUX_WORK.AC_ERR2102}");

            /*" -1180- DISPLAY 'DESPREZA (2102) ....... ' DP-ERR2102 */
            _.Display($"DESPREZA (2102) ....... {WS_AUX_WORK.DP_ERR2102}");

            /*" -1181- DISPLAY 'LIBERA (2102) ......... ' LB-ERR2102 */
            _.Display($"LIBERA (2102) ......... {WS_AUX_WORK.LB_ERR2102}");

            /*" -1182- DISPLAY 'ALTERA (2102) ......... ' UP-ERR2102 */
            _.Display($"ALTERA (2102) ......... {WS_AUX_WORK.UP_ERR2102}");

            /*" -1183- DISPLAY ' ' */
            _.Display($" ");

            /*" -1184- DISPLAY 'TRATA ERRO(2101) ...... ' AC-ERR2101 */
            _.Display($"TRATA ERRO(2101) ...... {WS_AUX_WORK.AC_ERR2101}");

            /*" -1185- DISPLAY 'DESPREZA (2101) ....... ' DP-ERR2101 */
            _.Display($"DESPREZA (2101) ....... {WS_AUX_WORK.DP_ERR2101}");

            /*" -1186- DISPLAY 'TRATA VALOR(2101) ..... ' AC-VAL2101 */
            _.Display($"TRATA VALOR(2101) ..... {WS_AUX_WORK.AC_VAL2101}");

            /*" -1187- DISPLAY 'DESP. VALOR(2101) ..... ' DP-VAL2101 */
            _.Display($"DESP. VALOR(2101) ..... {WS_AUX_WORK.DP_VAL2101}");

            /*" -1188- DISPLAY 'LIBERA (2101) ......... ' LB-ERR2101 */
            _.Display($"LIBERA (2101) ......... {WS_AUX_WORK.LB_ERR2101}");

            /*" -1189- DISPLAY 'ALTERA (2101) ......... ' UP-ERR2101 */
            _.Display($"ALTERA (2101) ......... {WS_AUX_WORK.UP_ERR2101}");

            /*" -1190- DISPLAY ' ' */
            _.Display($" ");

            /*" -1191- DISPLAY 'TRATA INDICADOR ....... ' AC-INDICADOR */
            _.Display($"TRATA INDICADOR ....... {WS_AUX_WORK.AC_INDICADOR}");

            /*" -1192- DISPLAY 'ACHOU V0BILHETE ....... ' WS-BILHETE */
            _.Display($"ACHOU V0BILHETE ....... {WS_AUX_WORK.WS_BILHETE}");

            /*" -1193- DISPLAY 'ALTERA V0BILHETE ...... ' AL-BILHETE */
            _.Display($"ALTERA V0BILHETE ...... {WS_AUX_WORK.AL_BILHETE}");

            /*" -1194- DISPLAY 'DESPREZA V0BILHETE .... ' DP-BILHETE */
            _.Display($"DESPREZA V0BILHETE .... {WS_AUX_WORK.DP_BILHETE}");

            /*" -1195- DISPLAY ' ' */
            _.Display($" ");

            /*" -1196- DISPLAY 'ACHOU V0COMISSAO ...... ' WS-FENAE */
            _.Display($"ACHOU V0COMISSAO ...... {WS_AUX_WORK.WS_FENAE}");

            /*" -1197- DISPLAY 'ALTERA V0COMISSAO ..... ' AL-FENAE */
            _.Display($"ALTERA V0COMISSAO ..... {WS_AUX_WORK.AL_FENAE}");

            /*" -1198- DISPLAY 'DESPREZA V0COMISSAO ... ' DP-FENAE */
            _.Display($"DESPREZA V0COMISSAO ... {WS_AUX_WORK.DP_FENAE}");

            /*" -1199- DISPLAY ' ' */
            _.Display($" ");

            /*" -1200- DISPLAY 'SEM MATRICULA ......... ' WS-MATRIC */
            _.Display($"SEM MATRICULA ......... {WS_AUX_WORK.WS_MATRIC}");

            /*" -1201- DISPLAY 'MATRICULAS 7777777 .... ' AL-MATRIC */
            _.Display($"MATRICULAS 7777777 .... {WS_AUX_WORK.AL_MATRIC}");

            /*" -1202- DISPLAY 'DESPREZA MATRICULA .... ' DP-MATRIC */
            _.Display($"DESPREZA MATRICULA .... {WS_AUX_WORK.DP_MATRIC}");

            /*" -1203- DISPLAY 'SEM  UPDATE MATRICULA . ' FU-DESPREZA */
            _.Display($"SEM  UPDATE MATRICULA . {WS_AUX_WORK.FU_DESPREZA}");

            /*" -1204- DISPLAY ' ' */
            _.Display($" ");

            /*" -1205- DISPLAY 'BILHETES COM ERRO ..... ' COM-ERROS */
            _.Display($"BILHETES COM ERRO ..... {WS_AUX_WORK.COM_ERROS}");

            /*" -1206- DISPLAY 'BILHETES SEM ERRO ..... ' SEM-ERROS */
            _.Display($"BILHETES SEM ERRO ..... {WS_AUX_WORK.SEM_ERROS}");

            /*" -1207- DISPLAY ' ' */
            _.Display($" ");

            /*" -1208- DISPLAY 'BILHETES SITUACAO 0 ... ' AC-SITUA0 */
            _.Display($"BILHETES SITUACAO 0 ... {WS_AUX_WORK.AC_SITUA0}");

            /*" -1209- DISPLAY 'DESPREZA SITUACAO 0 ... ' DP-SITUA0 */
            _.Display($"DESPREZA SITUACAO 0 ... {WS_AUX_WORK.DP_SITUA0}");

            /*" -1210- DISPLAY 'BILHETES SITUACAO 1 ... ' AC-SITUA1 */
            _.Display($"BILHETES SITUACAO 1 ... {WS_AUX_WORK.AC_SITUA1}");

            /*" -1211- DISPLAY 'DESPREZA SITUACAO 1 ... ' DP-SITUA1 */
            _.Display($"DESPREZA SITUACAO 1 ... {WS_AUX_WORK.DP_SITUA1}");

            /*" -1212- DISPLAY 'BILHETES COM ERRO ..... ' ER-LIBERA */
            _.Display($"BILHETES COM ERRO ..... {WS_AUX_WORK.ER_LIBERA}");

            /*" -1213- DISPLAY 'BILHETES SITUACAO R ... ' AC-SITUAR */
            _.Display($"BILHETES SITUACAO R ... {WS_AUX_WORK.AC_SITUAR}");

            /*" -1214- DISPLAY ' ' */
            _.Display($" ");

            /*" -1215- DISPLAY 'ERROS DELETADOS ....... ' DE-ERROS */
            _.Display($"ERROS DELETADOS ....... {WS_AUX_WORK.DE_ERROS}");

            /*" -1216- DISPLAY 'ERROS INDICADOR ....... ' FU-ERROS */
            _.Display($"ERROS INDICADOR ....... {WS_AUX_WORK.FU_ERROS}");

            /*" -1217- DISPLAY ' ' */
            _.Display($" ");

            /*" -1218- DISPLAY 'DESPREZADOS ........... ' CL-DESPREZA */
            _.Display($"DESPREZADOS ........... {WS_AUX_WORK.CL_DESPREZA}");

            /*" -1219- DISPLAY 'SITUACAO 0 ............ ' CL-SITUA0 */
            _.Display($"SITUACAO 0 ............ {WS_AUX_WORK.CL_SITUA0}");

            /*" -1220- DISPLAY 'TRATA COBERTURA ....... ' CL-COBERT */
            _.Display($"TRATA COBERTURA ....... {WS_AUX_WORK.CL_COBERT}");

            /*" -1221- DISPLAY 'REJEITADOS ............ ' CL-SITUA1 */
            _.Display($"REJEITADOS ............ {WS_AUX_WORK.CL_SITUA1}");

            /*" -1222- DISPLAY 'ALTERADOS ............. ' CL-ALTERA */
            _.Display($"ALTERADOS ............. {WS_AUX_WORK.CL_ALTERA}");

            /*" -1223- DISPLAY ' ' */
            _.Display($" ");

            /*" -1224- DISPLAY 'TRATA VALOR MAIOR ..... ' AC-VLMAIOR */
            _.Display($"TRATA VALOR MAIOR ..... {WS_AUX_WORK.AC_VLMAIOR}");

            /*" -1225- DISPLAY 'DESPREZA VALOR MAIOR .. ' DP-VLMAIOR */
            _.Display($"DESPREZA VALOR MAIOR .. {WS_AUX_WORK.DP_VLMAIOR}");

            /*" -1226- DISPLAY 'ALTERA VALOR MAIOR .... ' UP-VLMAIOR */
            _.Display($"ALTERA VALOR MAIOR .... {WS_AUX_WORK.UP_VLMAIOR}");

            /*" -1227- DISPLAY 'LIBERA VALOR MAIOR .... ' LB-VLMAIOR */
            _.Display($"LIBERA VALOR MAIOR .... {WS_AUX_WORK.LB_VLMAIOR}");

            /*" -1228- DISPLAY ' ' */
            _.Display($" ");

            /*" -1229- DISPLAY 'RAMOS ATUALIZADOS    .. ' AC-ATU-RAMO */
            _.Display($"RAMOS ATUALIZADOS    .. {WS_AUX_WORK.AC_ATU_RAMO}");

            /*" -1230- DISPLAY 'ATUALIZ DE 82 PARA 72.. ' AC-DE82-PARA72 */
            _.Display($"ATUALIZ DE 82 PARA 72.. {WS_AUX_WORK.AC_DE82_PARA72}");

            /*" -1231- DISPLAY 'ATUALIZ DE 72 PARA 82.. ' AC-DE72-PARA82 */
            _.Display($"ATUALIZ DE 72 PARA 82.. {WS_AUX_WORK.AC_DE72_PARA82}");

            /*" -1232- DISPLAY ' ' */
            _.Display($" ");

            /*" -1233- DISPLAY 'PROFISSOES ATUALIZADAS. ' AC-ATU-PROF */
            _.Display($"PROFISSOES ATUALIZADAS. {WS_AUX_WORK.AC_ATU_PROF}");

            /*" -1234- DISPLAY 'PROFISSOES DESPREZADAS. ' AC-DES-PROF */
            _.Display($"PROFISSOES DESPREZADAS. {WS_AUX_WORK.AC_DES_PROF}");

            /*" -1235- DISPLAY ' ' */
            _.Display($" ");

            /*" -1236- DISPLAY 'CB0009B - FIM NORMAL' . */
            _.Display($"CB0009B - FIM NORMAL");

            /*" -1239- DISPLAY ' ' */
            _.Display($" ");

            /*" -1239- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -1250- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1252- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1254- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -1255- SET WS-AGE TO 1. */
            WS_AGE.Value = 1;

            /*" -1256- MOVE SPACES TO WFIM-AGENCIAS */
            _.Move("", WS_AUX_WORK.WFIM_AGENCIAS);

            /*" -1258- PERFORM R0200-00-DECLARE-V0AGENCIAS. */

            R0200_00_DECLARE_V0AGENCIAS_SECTION();

            /*" -1262- PERFORM R0210-00-FETCH-V0AGENCIAS UNTIL WFIM-AGENCIAS NOT EQUAL SPACES. */

            while (!(!WS_AUX_WORK.WFIM_AGENCIAS.IsEmpty()))
            {

                R0210_00_FETCH_V0AGENCIAS_SECTION();
            }

            /*" -1268- MOVE 9999 TO V0ACEF-AGENCIA V0ACEF-ESCNEG V0ACEF-FONTE. */
            _.Move(9999, V0ACEF_AGENCIA, V0ACEF_ESCNEG, V0ACEF_FONTE);

            /*" -1269- SET WS-SUBS TO WS-AGE */
            WS_AUX_WORK.WS_SUBS.Value = WS_AGE;

            /*" -1273- PERFORM R0250-00-LIMPA-TABELA UNTIL WS-SUBS GREATER 6000. */

            while (!(WS_AUX_WORK.WS_SUBS > 6000))
            {

                R0250_00_LIMPA_TABELA_SECTION();
            }

            /*" -1275- INITIALIZE TAB-CBO1. */
            _.Initialize(
                TAB_CBO1
            );

            /*" -1277- PERFORM R8100-00-DECLARE-CBO. */

            R8100_00_DECLARE_CBO_SECTION();

            /*" -1279- PERFORM R8110-00-FETCH-CBO. */

            R8110_00_FETCH_CBO_SECTION();

            /*" -1280- IF WFIM-CBO EQUAL 'S' */

            if (WS_AUX_WORK.WFIM_CBO == "S")
            {

                /*" -1281- DISPLAY '8110 - PROBLEMA NO FETCH DA CBO         ' */
                _.Display($"8110 - PROBLEMA NO FETCH DA CBO         ");

                /*" -1283- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1286- PERFORM R8120-00-CARREGA-CBO UNTIL WFIM-CBO EQUAL 'S' . */

            while (!(WS_AUX_WORK.WFIM_CBO == "S"))
            {

                R8120_00_CARREGA_CBO_SECTION();
            }

            /*" -1286- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -1296- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1298- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1307- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -1310- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1311- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(V0SISTEMA)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(V0SISTEMA)");

                /*" -1314- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1315- MOVE V0SIST-DTPARAM TO WDATA-REL */
            _.Move(V0SIST_DTPARAM, WS_AUX_WORK.WDATA_REL);

            /*" -1316- MOVE 01 TO WDAT-REL-DIA */
            _.Move(01, WS_AUX_WORK.FILLER_1.WDAT_REL_DIA);

            /*" -1318- MOVE WDATA-REL TO V0SIST-DTPARAM. */
            _.Move(WS_AUX_WORK.WDATA_REL, V0SIST_DTPARAM);

            /*" -1319- DISPLAY 'DATA PROCESSAMENTO .... ' V0SIST-DTMOVABE */
            _.Display($"DATA PROCESSAMENTO .... {V0SIST_DTMOVABE}");

            /*" -1320- DISPLAY 'DATA PARAMETRO ........ ' V0SIST-DTPARAM */
            _.Display($"DATA PARAMETRO ........ {V0SIST_DTPARAM}");

            /*" -1322- DISPLAY 'DATA LIBERA BILHETE ... ' V0SIST-DTLIBERA. */
            _.Display($"DATA LIBERA BILHETE ... {V0SIST_DTLIBERA}");

            /*" -1324- MOVE 0,20 TO WS-VLDIFE */
            _.Move(0.20, WS_AUX_WORK.WS_VLDIFE);

            /*" -1326- MOVE 5 TO WS-VLDIFE2. */
            _.Move(5, WS_AUX_WORK.WS_VLDIFE2);

            /*" -1326- MOVE WS-VLDIFE TO AUX-VLDIFE. */
            _.Move(WS_AUX_WORK.WS_VLDIFE, WS_AUX_WORK.AUX_VLDIFE);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -1307- EXEC SQL SELECT DTMOVABE , (DTMOVABE - 15 MONTH) , (DTMOVABE - 1 YEAR) INTO :V0SIST-DTMOVABE , :V0SIST-DTPARAM , :V0SIST-DTLIBERA FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'CB' END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
                _.Move(executed_1.V0SIST_DTPARAM, V0SIST_DTPARAM);
                _.Move(executed_1.V0SIST_DTLIBERA, V0SIST_DTLIBERA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-V0AGENCIAS-SECTION */
        private void R0200_00_DECLARE_V0AGENCIAS_SECTION()
        {
            /*" -1337- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1339- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1355- PERFORM R0200_00_DECLARE_V0AGENCIAS_DB_DECLARE_1 */

            R0200_00_DECLARE_V0AGENCIAS_DB_DECLARE_1();

            /*" -1357- PERFORM R0200_00_DECLARE_V0AGENCIAS_DB_OPEN_1 */

            R0200_00_DECLARE_V0AGENCIAS_DB_OPEN_1();

            /*" -1361- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1362- DISPLAY 'R0200-00 - PROBLEMAS DECLARE (V0AGENCIAS)' */
                _.Display($"R0200-00 - PROBLEMAS DECLARE (V0AGENCIAS)");

                /*" -1362- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0AGENCIAS-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V0AGENCIAS_DB_DECLARE_1()
        {
            /*" -1355- EXEC SQL DECLARE V0AGENCIAS CURSOR FOR SELECT A.COD_AGENCIA , A.COD_ESCNEG , A.SITUACAO , B.COD_FONTE , C.SITUACAO FROM SEGUROS.V0AGENCIACEF A, SEGUROS.V0MALHACEF B, SEGUROS.V0FONTE C WHERE A.COD_AGENCIA > 0 AND A.COD_SUREG = B.COD_SUREG AND B.COD_FONTE = C.FONTE ORDER BY A.COD_AGENCIA END-EXEC. */
            V0AGENCIAS = new CB0009B_V0AGENCIAS(false);
            string GetQuery_V0AGENCIAS()
            {
                var query = @$"SELECT A.COD_AGENCIA
							, 
							A.COD_ESCNEG
							, 
							A.SITUACAO
							, 
							B.COD_FONTE
							, 
							C.SITUACAO 
							FROM SEGUROS.V0AGENCIACEF A
							, 
							SEGUROS.V0MALHACEF B
							, 
							SEGUROS.V0FONTE C 
							WHERE A.COD_AGENCIA > 0 
							AND A.COD_SUREG = B.COD_SUREG 
							AND B.COD_FONTE = C.FONTE 
							ORDER BY A.COD_AGENCIA";

                return query;
            }
            V0AGENCIAS.GetQueryEvent += GetQuery_V0AGENCIAS;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0AGENCIAS-DB-OPEN-1 */
        public void R0200_00_DECLARE_V0AGENCIAS_DB_OPEN_1()
        {
            /*" -1357- EXEC SQL OPEN V0AGENCIAS END-EXEC. */

            V0AGENCIAS.Open();

        }

        [StopWatch]
        /*" R0400-00-DECLARE-V0BILHETE-DB-DECLARE-1 */
        public void R0400_00_DECLARE_V0BILHETE_DB_DECLARE_1()
        {
            /*" -1478- EXEC SQL DECLARE V0BILHETE CURSOR FOR SELECT NUM_BILHETE , NUM_APOLICE , FONTE , AGE_COBRANCA , NUM_MATRICULA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_CLIENTE , PROFISSAO , IDE_SEXO , ESTADO_CIVIL , OPC_COBERTURA , DATA_QUITACAO , VAL_RCAP , RAMO , DATA_VENDA , DATA_MOVIMENTO , SITUACAO , COD_USUARIO , BI_FAIXA_RENDA_IND , BI_FAIXA_RENDA_FAM , VALUE(COD_PRODUTO,0) FROM SEGUROS.BILHETE WHERE SITUACAO BETWEEN '0' AND '4' AND NUM_APOL_ANTERIOR = 0 END-EXEC. */
            V0BILHETE = new CB0009B_V0BILHETE(false);
            string GetQuery_V0BILHETE()
            {
                var query = @$"SELECT NUM_BILHETE
							, 
							NUM_APOLICE
							, 
							FONTE
							, 
							AGE_COBRANCA
							, 
							NUM_MATRICULA
							, 
							COD_AGENCIA
							, 
							OPERACAO_CONTA
							, 
							NUM_CONTA
							, 
							DIG_CONTA
							, 
							COD_CLIENTE
							, 
							PROFISSAO
							, 
							IDE_SEXO
							, 
							ESTADO_CIVIL
							, 
							OPC_COBERTURA
							, 
							DATA_QUITACAO
							, 
							VAL_RCAP
							, 
							RAMO
							, 
							DATA_VENDA
							, 
							DATA_MOVIMENTO
							, 
							SITUACAO
							, 
							COD_USUARIO
							, 
							BI_FAIXA_RENDA_IND
							, 
							BI_FAIXA_RENDA_FAM
							, 
							VALUE(COD_PRODUTO
							,0) 
							FROM SEGUROS.BILHETE 
							WHERE SITUACAO BETWEEN '0' AND '4' 
							AND NUM_APOL_ANTERIOR = 0";

                return query;
            }
            V0BILHETE.GetQueryEvent += GetQuery_V0BILHETE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0AGENCIAS-SECTION */
        private void R0210_00_FETCH_V0AGENCIAS_SECTION()
        {
            /*" -1373- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1375- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1381- PERFORM R0210_00_FETCH_V0AGENCIAS_DB_FETCH_1 */

            R0210_00_FETCH_V0AGENCIAS_DB_FETCH_1();

            /*" -1384- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1385- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1385- PERFORM R0210_00_FETCH_V0AGENCIAS_DB_CLOSE_1 */

                    R0210_00_FETCH_V0AGENCIAS_DB_CLOSE_1();

                    /*" -1387- MOVE 'S' TO WFIM-AGENCIAS */
                    _.Move("S", WS_AUX_WORK.WFIM_AGENCIAS);

                    /*" -1388- GO TO R0210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                    return;

                    /*" -1389- ELSE */
                }
                else
                {


                    /*" -1390- DISPLAY 'R0210-00 - PROBLEMAS FETCH (V0AGENCIAS)  ' */
                    _.Display($"R0210-00 - PROBLEMAS FETCH (V0AGENCIAS)  ");

                    /*" -1391- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1392- END-IF */
                }


                /*" -1394- END-IF. */
            }


            /*" -1395- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -1396- MOVE ZERO TO V0ACEF-ESCNEG */
                _.Move(0, V0ACEF_ESCNEG);

                /*" -1398- END-IF. */
            }


            /*" -1400- MOVE V0ACEF-AGENCIA TO WACEF-AGENCIA(WS-AGE). */
            _.Move(V0ACEF_AGENCIA, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA);

            /*" -1402- MOVE V0ACEF-ESCNEG TO WACEF-ESCNEG(WS-AGE). */
            _.Move(V0ACEF_ESCNEG, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_ESCNEG);

            /*" -1404- MOVE V0ACEF-FONTE TO WACEF-FONTE(WS-AGE). */
            _.Move(V0ACEF_FONTE, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_FONTE);

            /*" -1406- IF V0ACEF-SITUACAO NOT EQUAL '0' OR V0FONT-SITUACAO NOT EQUAL '0' */

            if (V0ACEF_SITUACAO != "0" || V0FONT_SITUACAO != "0")
            {

                /*" -1407- MOVE '1' TO WACEF-SITUACAO(WS-AGE) */
                _.Move("1", WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_SITUACAO);

                /*" -1408- ELSE */
            }
            else
            {


                /*" -1410- MOVE '0' TO WACEF-SITUACAO(WS-AGE). */
                _.Move("0", WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_SITUACAO);
            }


            /*" -1410- SET WS-AGE UP BY 1. */
            WS_AGE.Value += 1;

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0AGENCIAS-DB-FETCH-1 */
        public void R0210_00_FETCH_V0AGENCIAS_DB_FETCH_1()
        {
            /*" -1381- EXEC SQL FETCH V0AGENCIAS INTO :V0ACEF-AGENCIA , :V0ACEF-ESCNEG:VIND-NULL01, :V0ACEF-SITUACAO , :V0ACEF-FONTE , :V0FONT-SITUACAO END-EXEC. */

            if (V0AGENCIAS.Fetch())
            {
                _.Move(V0AGENCIAS.V0ACEF_AGENCIA, V0ACEF_AGENCIA);
                _.Move(V0AGENCIAS.V0ACEF_ESCNEG, V0ACEF_ESCNEG);
                _.Move(V0AGENCIAS.VIND_NULL01, VIND_NULL01);
                _.Move(V0AGENCIAS.V0ACEF_SITUACAO, V0ACEF_SITUACAO);
                _.Move(V0AGENCIAS.V0ACEF_FONTE, V0ACEF_FONTE);
                _.Move(V0AGENCIAS.V0FONT_SITUACAO, V0FONT_SITUACAO);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0AGENCIAS-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0AGENCIAS_DB_CLOSE_1()
        {
            /*" -1385- EXEC SQL CLOSE V0AGENCIAS END-EXEC */

            V0AGENCIAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-LIMPA-TABELA-SECTION */
        private void R0250_00_LIMPA_TABELA_SECTION()
        {
            /*" -1420- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1423- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1426- MOVE V0ACEF-AGENCIA TO WACEF-AGENCIA(WS-AGE). */
            _.Move(V0ACEF_AGENCIA, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA);

            /*" -1429- MOVE V0ACEF-ESCNEG TO WACEF-ESCNEG(WS-AGE). */
            _.Move(V0ACEF_ESCNEG, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_ESCNEG);

            /*" -1432- MOVE V0ACEF-FONTE TO WACEF-FONTE(WS-AGE). */
            _.Move(V0ACEF_FONTE, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_FONTE);

            /*" -1436- MOVE SPACES TO WACEF-SITUACAO(WS-AGE). */
            _.Move("", WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_SITUACAO);

            /*" -1437- SET WS-AGE UP BY 1. */
            WS_AGE.Value += 1;

            /*" -1437- SET WS-SUBS TO WS-AGE. */
            WS_AUX_WORK.WS_SUBS.Value = WS_AGE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-DECLARE-V0BILHETE-SECTION */
        private void R0400_00_DECLARE_V0BILHETE_SECTION()
        {
            /*" -1448- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1450- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1478- PERFORM R0400_00_DECLARE_V0BILHETE_DB_DECLARE_1 */

            R0400_00_DECLARE_V0BILHETE_DB_DECLARE_1();

            /*" -1480- PERFORM R0400_00_DECLARE_V0BILHETE_DB_OPEN_1 */

            R0400_00_DECLARE_V0BILHETE_DB_OPEN_1();

            /*" -1484- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1485- DISPLAY 'R0400-00 - PROBLEMAS DECLARE (V0BILHETE)  ' */
                _.Display($"R0400-00 - PROBLEMAS DECLARE (V0BILHETE)  ");

                /*" -1485- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0400-00-DECLARE-V0BILHETE-DB-OPEN-1 */
        public void R0400_00_DECLARE_V0BILHETE_DB_OPEN_1()
        {
            /*" -1480- EXEC SQL OPEN V0BILHETE END-EXEC. */

            V0BILHETE.Open();

        }

        [StopWatch]
        /*" R0500-00-DECLARE-V0ERRO-DB-DECLARE-1 */
        public void R0500_00_DECLARE_V0ERRO_DB_DECLARE_1()
        {
            /*" -2219- EXEC SQL DECLARE V0ERRO CURSOR FOR SELECT A.NUM_CERTIFICADO, A.COD_MSG_CRITICA, B.DES_MSG_CRITICA FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :V0BILH-NUMBIL AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> 3 ORDER BY A.COD_MSG_CRITICA WITH UR END-EXEC. */
            V0ERRO = new CB0009B_V0ERRO(true);
            string GetQuery_V0ERRO()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO
							, 
							A.COD_MSG_CRITICA
							, 
							B.DES_MSG_CRITICA 
							FROM SEGUROS.VG_CRITICA_PROPOSTA A
							, 
							SEGUROS.VG_DM_MSG_CRITICA B 
							WHERE A.NUM_CERTIFICADO = '{V0BILH_NUMBIL}' 
							AND A.STA_CRITICA IN ( '0'
							, '1'
							, '2'
							, '4'
							, '5'
							, '8' ) 
							AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA 
							AND B.COD_TP_MSG_CRITICA <> 3 
							ORDER BY A.COD_MSG_CRITICA";

                return query;
            }
            V0ERRO.GetQueryEvent += GetQuery_V0ERRO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-FETCH-V0BILHETE-SECTION */
        private void R0410_00_FETCH_V0BILHETE_SECTION()
        {
            /*" -1496- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1498- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1523- PERFORM R0410_00_FETCH_V0BILHETE_DB_FETCH_1 */

            R0410_00_FETCH_V0BILHETE_DB_FETCH_1();

            /*" -1527- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1527- PERFORM R0410_00_FETCH_V0BILHETE_DB_CLOSE_1 */

                R0410_00_FETCH_V0BILHETE_DB_CLOSE_1();

                /*" -1529- MOVE 'S' TO WFIM-V0BILHETE */
                _.Move("S", WS_AUX_WORK.WFIM_V0BILHETE);

                /*" -1531- GO TO R0410-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1532- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1533- DISPLAY 'R0410-00 - PROBLEMAS FETCH   (V0BILHETE)  ' */
                _.Display($"R0410-00 - PROBLEMAS FETCH   (V0BILHETE)  ");

                /*" -1536- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1537- ADD 1 TO LD-V0BILHETE. */
            WS_AUX_WORK.LD_V0BILHETE.Value = WS_AUX_WORK.LD_V0BILHETE + 1;

            /*" -1541- DISPLAY 'BILHETE V0BILHETE LIDO: ' V0BILH-NUMBIL '/' V0BILH-COD-PRODUTO */

            $"BILHETE V0BILHETE LIDO: {V0BILH_NUMBIL}/{V0BILH_COD_PRODUTO}"
            .Display();

            /*" -1541- . */

        }

        [StopWatch]
        /*" R0410-00-FETCH-V0BILHETE-DB-FETCH-1 */
        public void R0410_00_FETCH_V0BILHETE_DB_FETCH_1()
        {
            /*" -1523- EXEC SQL FETCH V0BILHETE INTO :V0BILH-NUMBIL , :V0BILH-NUMAPOL , :V0BILH-FONTE , :V0BILH-AGECOBR , :V0BILH-MATRICULA , :V0BILH-AGECONTA , :V0BILH-OPECONTA , :V0BILH-NUMCONTA , :V0BILH-DIGCONTA , :V0BILH-CODCLIEN , :V0BILH-PROFISSAO , :V0BILH-SEXO , :V0BILH-ESTCIV , :V0BILH-OPCOBER , :V0BILH-DTQITBCO , :V0BILH-VLRCAP , :V0BILH-RAMO , :V0BILH-DTVENDA , :V0BILH-DTMOVTO , :V0BILH-SITUACAO , :V0BILH-CODUSU , :V0BILH-FX-RENDA-IND, :V0BILH-FX-RENDA-FAM, :V0BILH-COD-PRODUTO END-EXEC. */

            if (V0BILHETE.Fetch())
            {
                _.Move(V0BILHETE.V0BILH_NUMBIL, V0BILH_NUMBIL);
                _.Move(V0BILHETE.V0BILH_NUMAPOL, V0BILH_NUMAPOL);
                _.Move(V0BILHETE.V0BILH_FONTE, V0BILH_FONTE);
                _.Move(V0BILHETE.V0BILH_AGECOBR, V0BILH_AGECOBR);
                _.Move(V0BILHETE.V0BILH_MATRICULA, V0BILH_MATRICULA);
                _.Move(V0BILHETE.V0BILH_AGECONTA, V0BILH_AGECONTA);
                _.Move(V0BILHETE.V0BILH_OPECONTA, V0BILH_OPECONTA);
                _.Move(V0BILHETE.V0BILH_NUMCONTA, V0BILH_NUMCONTA);
                _.Move(V0BILHETE.V0BILH_DIGCONTA, V0BILH_DIGCONTA);
                _.Move(V0BILHETE.V0BILH_CODCLIEN, V0BILH_CODCLIEN);
                _.Move(V0BILHETE.V0BILH_PROFISSAO, V0BILH_PROFISSAO);
                _.Move(V0BILHETE.V0BILH_SEXO, V0BILH_SEXO);
                _.Move(V0BILHETE.V0BILH_ESTCIV, V0BILH_ESTCIV);
                _.Move(V0BILHETE.V0BILH_OPCOBER, V0BILH_OPCOBER);
                _.Move(V0BILHETE.V0BILH_DTQITBCO, V0BILH_DTQITBCO);
                _.Move(V0BILHETE.V0BILH_VLRCAP, V0BILH_VLRCAP);
                _.Move(V0BILHETE.V0BILH_RAMO, V0BILH_RAMO);
                _.Move(V0BILHETE.V0BILH_DTVENDA, V0BILH_DTVENDA);
                _.Move(V0BILHETE.V0BILH_DTMOVTO, V0BILH_DTMOVTO);
                _.Move(V0BILHETE.V0BILH_SITUACAO, V0BILH_SITUACAO);
                _.Move(V0BILHETE.V0BILH_CODUSU, V0BILH_CODUSU);
                _.Move(V0BILHETE.V0BILH_FX_RENDA_IND, V0BILH_FX_RENDA_IND);
                _.Move(V0BILHETE.V0BILH_FX_RENDA_FAM, V0BILH_FX_RENDA_FAM);
                _.Move(V0BILHETE.V0BILH_COD_PRODUTO, V0BILH_COD_PRODUTO);
            }

        }

        [StopWatch]
        /*" R0410-00-FETCH-V0BILHETE-DB-CLOSE-1 */
        public void R0410_00_FETCH_V0BILHETE_DB_CLOSE_1()
        {
            /*" -1527- EXEC SQL CLOSE V0BILHETE END-EXEC */

            V0BILHETE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-PROCESSA-V0BILHETE-SECTION */
        private void R0450_00_PROCESSA_V0BILHETE_SECTION()
        {
            /*" -1550- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1553- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1557- PERFORM R7180-00-SELECT-PROPIDELIZ. */

            R7180_00_SELECT_PROPIDELIZ_SECTION();

            /*" -1558- IF V0BILH-NUMAPOL NOT EQUAL ZEROS */

            if (V0BILH_NUMAPOL != 00)
            {

                /*" -1559- ADD 1 TO AC-BILEMI */
                WS_AUX_WORK.AC_BILEMI.Value = WS_AUX_WORK.AC_BILEMI + 1;

                /*" -1560- MOVE '9' TO V0BILH-SITUACAO */
                _.Move("9", V0BILH_SITUACAO);

                /*" -1561- PERFORM R2400-00-UPDATE-V0BILHETE */

                R2400_00_UPDATE_V0BILHETE_SECTION();

                /*" -1564- GO TO R0450-90-LEITURA. */

                R0450_90_LEITURA(); //GOTO
                return;
            }


            /*" -1566- PERFORM R1510-00-SELECT-V0ERRO */

            R1510_00_SELECT_V0ERRO_SECTION();

            /*" -1567- IF V0ERRO-COUNT EQUAL 1 */

            if (V0ERRO_COUNT == 1)
            {

                /*" -1568- PERFORM R1515-00-SELECT-V0ERRO */

                R1515_00_SELECT_V0ERRO_SECTION();

                /*" -1569- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1570- MOVE 'R' TO V0BILH-SITUACAO */
                    _.Move("R", V0BILH_SITUACAO);

                    /*" -1571- ADD 1 TO AC-SITUAR */
                    WS_AUX_WORK.AC_SITUAR.Value = WS_AUX_WORK.AC_SITUAR + 1;

                    /*" -1572- PERFORM R2500-00-UPDATE-V0BILHETE */

                    R2500_00_UPDATE_V0BILHETE_SECTION();

                    /*" -1574- GO TO R0450-90-LEITURA. */

                    R0450_90_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -1575- MOVE V0BILH-CODCLIEN TO V0CLIE-CODCLIEN */
            _.Move(V0BILH_CODCLIEN, V0CLIE_CODCLIEN);

            /*" -1577- PERFORM R0610-00-SELECT-V0CLIENTE */

            R0610_00_SELECT_V0CLIENTE_SECTION();

            /*" -1578- IF V0BILH-COD-PRODUTO EQUAL 0 */

            if (V0BILH_COD_PRODUTO == 0)
            {

                /*" -1579- MOVE 'N' TO N88-NOVOS-ACESSOS */
                _.Move("N", NIVEIS_88.N88_NOVOS_ACESSOS);

                /*" -1581- DISPLAY 'R0450-00 - BILHETE SEM COD-PRODUTO: ' V0BILH-NUMBIL ' DTA-QUITACAO ' V0BILH-DTMOVTO */

                $"R0450-00 - BILHETE SEM COD-PRODUTO: {V0BILH_NUMBIL} DTA-QUITACAO {V0BILH_DTMOVTO}"
                .Display();

                /*" -1582- ELSE */
            }
            else
            {


                /*" -1583- PERFORM R0453-00-ACESSA-GE0070S THRU R0453-99-SAIDA */

                R0453_00_ACESSA_GE0070S_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0453_99_SAIDA*/


                /*" -1586- END-IF */
            }


            /*" -1589- MOVE SPACES TO WS-FLAG WS-FLAG-100 */
            _.Move("", WS_AUX_WORK.WS_FLAG, WS_AUX_WORK.WS_FLAG_100);

            /*" -1591- PERFORM R0452-00-PROCESSA-TABELAS. */

            R0452_00_PROCESSA_TABELAS_SECTION();

            /*" -1592- IF WS-FLAG-100 NOT EQUAL SPACES */

            if (!WS_AUX_WORK.WS_FLAG_100.IsEmpty())
            {

                /*" -1593- ADD 1 TO DP-GERAL */
                WS_AUX_WORK.DP_GERAL.Value = WS_AUX_WORK.DP_GERAL + 1;

                /*" -1594- MOVE '2' TO V0BILH-SITUACAO */
                _.Move("2", V0BILH_SITUACAO);

                /*" -1595- ADD 1 TO UP-GERAL */
                WS_AUX_WORK.UP_GERAL.Value = WS_AUX_WORK.UP_GERAL + 1;

                /*" -1596- PERFORM R2500-00-UPDATE-V0BILHETE */

                R2500_00_UPDATE_V0BILHETE_SECTION();

                /*" -1597- GO TO R0450-90-LEITURA */

                R0450_90_LEITURA(); //GOTO
                return;

                /*" -1599- END-IF */
            }


            /*" -1600- IF WS-FLAG NOT EQUAL SPACES */

            if (!WS_AUX_WORK.WS_FLAG.IsEmpty())
            {

                /*" -1601- ADD 1 TO DP-GERAL */
                WS_AUX_WORK.DP_GERAL.Value = WS_AUX_WORK.DP_GERAL + 1;

                /*" -1604- IF V0BILH-SITUACAO EQUAL '0' OR '2' OR '4' */

                if (V0BILH_SITUACAO.In("0", "2", "4"))
                {

                    /*" -1605- MOVE '1' TO V0BILH-SITUACAO */
                    _.Move("1", V0BILH_SITUACAO);

                    /*" -1606- ADD 1 TO UP-GERAL */
                    WS_AUX_WORK.UP_GERAL.Value = WS_AUX_WORK.UP_GERAL + 1;

                    /*" -1607- PERFORM R2500-00-UPDATE-V0BILHETE */

                    R2500_00_UPDATE_V0BILHETE_SECTION();

                    /*" -1608- GO TO R0450-90-LEITURA */

                    R0450_90_LEITURA(); //GOTO
                    return;

                    /*" -1609- ELSE */
                }
                else
                {


                    /*" -1612- GO TO R0450-90-LEITURA. */

                    R0450_90_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -1613- IF V0BILH-NUMBIL EQUAL 84571928707 */

            if (V0BILH_NUMBIL == 84571928707)
            {

                /*" -1616- PERFORM R2100-00-UPDATE-V0COFENAE. */

                R2100_00_UPDATE_V0COFENAE_SECTION();
            }


            /*" -1619- MOVE SPACES TO WFIM-V0ERRO FLAG-COBERT. */
            _.Move("", WS_AUX_WORK.WFIM_V0ERRO, WS_AUX_WORK.FLAG_COBERT);

            /*" -1621- PERFORM R0500-00-DECLARE-V0ERRO. */

            R0500_00_DECLARE_V0ERRO_SECTION();

            /*" -1623- PERFORM R0510-00-FETCH-V0ERRO. */

            R0510_00_FETCH_V0ERRO_SECTION();

            /*" -1624- IF WFIM-V0ERRO NOT EQUAL SPACES */

            if (!WS_AUX_WORK.WFIM_V0ERRO.IsEmpty())
            {

                /*" -1625- ADD 1 TO SEM-ERROS */
                WS_AUX_WORK.SEM_ERROS.Value = WS_AUX_WORK.SEM_ERROS + 1;

                /*" -1626- ELSE */
            }
            else
            {


                /*" -1627- ADD 1 TO COM-ERROS */
                WS_AUX_WORK.COM_ERROS.Value = WS_AUX_WORK.COM_ERROS + 1;

                /*" -1634- PERFORM R0550-00-PROCESSA-V0ERRO UNTIL WFIM-V0ERRO NOT EQUAL SPACES. */

                while (!(!WS_AUX_WORK.WFIM_V0ERRO.IsEmpty()))
                {

                    R0550_00_PROCESSA_V0ERRO_SECTION();
                }
            }


            /*" -1637- PERFORM R1500-00-LIBERA-BILHETE. */

            R1500_00_LIBERA_BILHETE_SECTION();

            /*" -1638- IF V0BILH-SITUACAO NOT EQUAL '0' */

            if (V0BILH_SITUACAO != "0")
            {

                /*" -1639- ADD 1 TO CL-DESPREZA */
                WS_AUX_WORK.CL_DESPREZA.Value = WS_AUX_WORK.CL_DESPREZA + 1;

                /*" -1640- ELSE */
            }
            else
            {


                /*" -1641- ADD 1 TO CL-SITUA0 */
                WS_AUX_WORK.CL_SITUA0.Value = WS_AUX_WORK.CL_SITUA0 + 1;

                /*" -1642- IF FLAG-COBERT EQUAL SPACES */

                if (WS_AUX_WORK.FLAG_COBERT.IsEmpty())
                {

                    /*" -1643- ADD 1 TO CL-COBERT */
                    WS_AUX_WORK.CL_COBERT.Value = WS_AUX_WORK.CL_COBERT + 1;

                    /*" -1646- PERFORM R1600-00-VER-COBERTURA. */

                    R1600_00_VER_COBERTURA_SECTION();
                }

            }


            /*" -1647- IF V0BILH-SITUACAO NOT EQUAL '0' */

            if (V0BILH_SITUACAO != "0")
            {

                /*" -1648- ADD 1 TO AC-VLMAIOR */
                WS_AUX_WORK.AC_VLMAIOR.Value = WS_AUX_WORK.AC_VLMAIOR + 1;

                /*" -1648- PERFORM R3000-00-VER-MAIOR. */

                R3000_00_VER_MAIOR_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0450_90_LEITURA */

            R0450_90_LEITURA();

        }

        [StopWatch]
        /*" R0450-90-LEITURA */
        private void R0450_90_LEITURA(bool isPerform = false)
        {
            /*" -1653- PERFORM R0410-00-FETCH-V0BILHETE. */

            R0410_00_FETCH_V0BILHETE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0451-00-SELECT-BI-BIL-ACAT-SECTION */
        private void R0451_00_SELECT_BI_BIL_ACAT_SECTION()
        {
            /*" -1662- MOVE '0451' TO WNR-EXEC-SQL. */
            _.Move("0451", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1664- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1669- PERFORM R0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1 */

            R0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1();

            /*" -1672- IF SQLCODE NOT EQUAL ZEROS AND 100 AND -811 */

            if (!DB.SQLCODE.In("00", "100", "-811"))
            {

                /*" -1673- DISPLAY 'BILHETE ..' V0BILH-NUMBIL */
                _.Display($"BILHETE ..{V0BILH_NUMBIL}");

                /*" -1673- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0451-00-SELECT-BI-BIL-ACAT-DB-SELECT-1 */
        public void R0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1()
        {
            /*" -1669- EXEC SQL SELECT COD_USUARIO INTO :BI-COD-USUARIO FROM SEGUROS.BI_BILHETE_ACATADO WHERE NUM_BILHETE = :V0BILH-NUMBIL END-EXEC. */

            var r0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1_Query1 = new R0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1_Query1.Execute(r0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BI_COD_USUARIO, BI_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0451_99_SAIDA*/

        [StopWatch]
        /*" R0452-00-PROCESSA-TABELAS-SECTION */
        private void R0452_00_PROCESSA_TABELAS_SECTION()
        {
            /*" -1683- MOVE '0452' TO WNR-EXEC-SQL. */
            _.Move("0452", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1685- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1687- IF V0BILH-NUMBIL LESS 80000000000 OR V0BILH-NUMBIL GREATER 99999999999 */

            if (V0BILH_NUMBIL < 80000000000 || V0BILH_NUMBIL > 99999999999)
            {

                /*" -1688- DISPLAY 'BILHETE COM PROBLEMAS NO RCAP ' V0BILH-NUMBIL */
                _.Display($"BILHETE COM PROBLEMAS NO RCAP {V0BILH_NUMBIL}");

                /*" -1689- MOVE 'S' TO WS-FLAG */
                _.Move("S", WS_AUX_WORK.WS_FLAG);

                /*" -1690- ADD 1 TO AC-RCAPDIV */
                WS_AUX_WORK.AC_RCAPDIV.Value = WS_AUX_WORK.AC_RCAPDIV + 1;

                /*" -1693- GO TO R0452-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0452_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1694- MOVE V0BILH-NUMBIL TO WS-NUMBIL */
            _.Move(V0BILH_NUMBIL, WS_AUX_WORK.WS_NUMBIL);

            /*" -1696- MOVE WS-NRRCAP TO V0RCAP-NRRCAP. */
            _.Move(WS_AUX_WORK.FILLER_14.WS_NRRCAP, V0RCAP_NRRCAP);

            /*" -1698- PERFORM R0460-00-SELECT-V0RCAP. */

            R0460_00_SELECT_V0RCAP_SECTION();

            /*" -1699- IF V0RCAP-SITUACAO EQUAL 'N' */

            if (V0RCAP_SITUACAO == "N")
            {

                /*" -1700- IF V0BILH-DTQITBCO LESS '1999-01-01' */

                if (V0BILH_DTQITBCO < "1999-01-01")
                {

                    /*" -1701- ADD 1 TO AC-RCAP98 */
                    WS_AUX_WORK.AC_RCAP98.Value = WS_AUX_WORK.AC_RCAP98 + 1;

                    /*" -1702- ELSE */
                }
                else
                {


                    /*" -1703- IF V0BILH-DTQITBCO LESS '2000-01-01' */

                    if (V0BILH_DTQITBCO < "2000-01-01")
                    {

                        /*" -1704- ADD 1 TO AC-RCAP99 */
                        WS_AUX_WORK.AC_RCAP99.Value = WS_AUX_WORK.AC_RCAP99 + 1;

                        /*" -1705- ELSE */
                    }
                    else
                    {


                        /*" -1706- IF V0BILH-DTQITBCO LESS '2001-01-01' */

                        if (V0BILH_DTQITBCO < "2001-01-01")
                        {

                            /*" -1707- ADD 1 TO AC-RCAP00 */
                            WS_AUX_WORK.AC_RCAP00.Value = WS_AUX_WORK.AC_RCAP00 + 1;

                            /*" -1708- ELSE */
                        }
                        else
                        {


                            /*" -1709- IF V0BILH-DTQITBCO LESS '2002-01-01' */

                            if (V0BILH_DTQITBCO < "2002-01-01")
                            {

                                /*" -1710- ADD 1 TO AC-RCAP01 */
                                WS_AUX_WORK.AC_RCAP01.Value = WS_AUX_WORK.AC_RCAP01 + 1;

                                /*" -1711- ELSE */
                            }
                            else
                            {


                                /*" -1712- IF V0BILH-DTQITBCO LESS '2003-01-01' */

                                if (V0BILH_DTQITBCO < "2003-01-01")
                                {

                                    /*" -1713- ADD 1 TO AC-RCAP02 */
                                    WS_AUX_WORK.AC_RCAP02.Value = WS_AUX_WORK.AC_RCAP02 + 1;

                                    /*" -1714- ELSE */
                                }
                                else
                                {


                                    /*" -1715- IF V0BILH-DTQITBCO LESS '2004-01-01' */

                                    if (V0BILH_DTQITBCO < "2004-01-01")
                                    {

                                        /*" -1716- ADD 1 TO AC-RCAP03 */
                                        WS_AUX_WORK.AC_RCAP03.Value = WS_AUX_WORK.AC_RCAP03 + 1;

                                        /*" -1717- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1718- IF V0BILH-DTQITBCO LESS '2005-01-01' */

                                        if (V0BILH_DTQITBCO < "2005-01-01")
                                        {

                                            /*" -1719- ADD 1 TO AC-RCAP04 */
                                            WS_AUX_WORK.AC_RCAP04.Value = WS_AUX_WORK.AC_RCAP04 + 1;

                                            /*" -1720- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1723- ADD 1 TO AC-RCAP05. */
                                            WS_AUX_WORK.AC_RCAP05.Value = WS_AUX_WORK.AC_RCAP05 + 1;
                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -1725- IF V0RCAP-SITUACAO EQUAL 'N' */

            if (V0RCAP_SITUACAO == "N")
            {

                /*" -1726- MOVE 'S' TO WS-FLAG-100 */
                _.Move("S", WS_AUX_WORK.WS_FLAG_100);

                /*" -1727- ADD 1 TO AC-RCAPNAO */
                WS_AUX_WORK.AC_RCAPNAO.Value = WS_AUX_WORK.AC_RCAPNAO + 1;

                /*" -1728- GO TO R0452-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0452_99_SAIDA*/ //GOTO
                return;

                /*" -1729- ELSE */
            }
            else
            {


                /*" -1730- IF V0RCAP-SITUACAO EQUAL '*' */

                if (V0RCAP_SITUACAO == "*")
                {

                    /*" -1731- MOVE 'S' TO WS-FLAG */
                    _.Move("S", WS_AUX_WORK.WS_FLAG);

                    /*" -1732- ADD 1 TO AC-RCAPDIV */
                    WS_AUX_WORK.AC_RCAPDIV.Value = WS_AUX_WORK.AC_RCAPDIV + 1;

                    /*" -1733- GO TO R0452-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0452_99_SAIDA*/ //GOTO
                    return;

                    /*" -1734- ELSE */
                }
                else
                {


                    /*" -1736- IF V0RCAP-SITUACAO EQUAL '0' NEXT SENTENCE */

                    if (V0RCAP_SITUACAO == "0")
                    {

                        /*" -1737- ELSE */
                    }
                    else
                    {


                        /*" -1738- IF V0RCAP-SITUACAO EQUAL '2' */

                        if (V0RCAP_SITUACAO == "2")
                        {

                            /*" -1739- MOVE 'S' TO WS-FLAG */
                            _.Move("S", WS_AUX_WORK.WS_FLAG);

                            /*" -1740- ADD 1 TO AC-RCAPCAN */
                            WS_AUX_WORK.AC_RCAPCAN.Value = WS_AUX_WORK.AC_RCAPCAN + 1;

                            /*" -1741- GO TO R0452-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0452_99_SAIDA*/ //GOTO
                            return;

                            /*" -1742- ELSE */
                        }
                        else
                        {


                            /*" -1743- MOVE 'S' TO WS-FLAG */
                            _.Move("S", WS_AUX_WORK.WS_FLAG);

                            /*" -1744- ADD 1 TO AC-RCAPUSO */
                            WS_AUX_WORK.AC_RCAPUSO.Value = WS_AUX_WORK.AC_RCAPUSO + 1;

                            /*" -1747- GO TO R0452-99-SAIDA. */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0452_99_SAIDA*/ //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -1749- PERFORM R0451-00-SELECT-BI-BIL-ACAT. */

            R0451_00_SELECT_BI_BIL_ACAT_SECTION();

            /*" -1750- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1751- ADD 1 TO AC-BILACAT */
                WS_AUX_WORK.AC_BILACAT.Value = WS_AUX_WORK.AC_BILACAT + 1;

                /*" -1752- MOVE '0' TO V0BILH-SITUACAO */
                _.Move("0", V0BILH_SITUACAO);

                /*" -1753- PERFORM R2400-00-UPDATE-V0BILHETE */

                R2400_00_UPDATE_V0BILHETE_SECTION();

                /*" -1754- ELSE */
            }
            else
            {


                /*" -1755- IF V0RCOM-DATARCAP LESS V0SIST-DTPARAM */

                if (V0RCOM_DATARCAP < V0SIST_DTPARAM)
                {

                    /*" -1758- IF V0BILH-SITUACAO EQUAL '0' OR '2' OR '4' */

                    if (V0BILH_SITUACAO.In("0", "2", "4"))
                    {

                        /*" -1759- ADD 1 TO LB-DTMENOR */
                        WS_AUX_WORK.LB_DTMENOR.Value = WS_AUX_WORK.LB_DTMENOR + 1;

                        /*" -1760- ELSE */
                    }
                    else
                    {


                        /*" -1761- MOVE 'S' TO WS-FLAG */
                        _.Move("S", WS_AUX_WORK.WS_FLAG);

                        /*" -1762- ADD 1 TO AC-DTMENOR */
                        WS_AUX_WORK.AC_DTMENOR.Value = WS_AUX_WORK.AC_DTMENOR + 1;

                        /*" -1765- GO TO R0452-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0452_99_SAIDA*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1767- PERFORM R0470-00-SELECT-V0COMISSAO. */

            R0470_00_SELECT_V0COMISSAO_SECTION();

            /*" -1768- IF V0CFEN-SITUACAO EQUAL '*' */

            if (V0CFEN_SITUACAO == "*")
            {

                /*" -1769- ADD 1 TO AC-FENAE */
                WS_AUX_WORK.AC_FENAE.Value = WS_AUX_WORK.AC_FENAE + 1;

                /*" -1770- PERFORM R6000-00-MONTA-FENAE */

                R6000_00_MONTA_FENAE_SECTION();

                /*" -1771- IF V0CFEN-SITUACAO EQUAL '*' */

                if (V0CFEN_SITUACAO == "*")
                {

                    /*" -1773- DISPLAY 'CRITICA***FALHA AO INSERIR COMISSAO = ' V0BILH-NUMBIL */
                    _.Display($"CRITICA***FALHA AO INSERIR COMISSAO = {V0BILH_NUMBIL}");

                    /*" -1774- MOVE 'S' TO WS-FLAG */
                    _.Move("S", WS_AUX_WORK.WS_FLAG);

                    /*" -1775- ADD 1 TO AC-COMINAO */
                    WS_AUX_WORK.AC_COMINAO.Value = WS_AUX_WORK.AC_COMINAO + 1;

                    /*" -1778- GO TO R0452-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0452_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -1780- MOVE V0BILH-NUMBIL TO V0FOLL-NUMAPOL. */
            _.Move(V0BILH_NUMBIL, V0FOLL_NUMAPOL);

            /*" -1782- PERFORM R0455-00-SELECT-V0FOLLOWUP. */

            R0455_00_SELECT_V0FOLLOWUP_SECTION();

            /*" -1783- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1784- MOVE '0' TO V0FOLL-SITUACAO */
                _.Move("0", V0FOLL_SITUACAO);

                /*" -1785- ELSE */
            }
            else
            {


                /*" -1786- ADD 1 TO AC-FOLLOW */
                WS_AUX_WORK.AC_FOLLOW.Value = WS_AUX_WORK.AC_FOLLOW + 1;

                /*" -1787- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1788- PERFORM R4000-00-TRATA-FOLLOWUP */

                    R4000_00_TRATA_FOLLOWUP_SECTION();

                    /*" -1789- ELSE */
                }
                else
                {


                    /*" -1790- IF V0BILH-NUMBIL EQUAL 83778032038 */

                    if (V0BILH_NUMBIL == 83778032038)
                    {

                        /*" -1791- MOVE '0' TO V0FOLL-SITUACAO */
                        _.Move("0", V0FOLL_SITUACAO);

                        /*" -1792- ELSE */
                    }
                    else
                    {


                        /*" -1793- MOVE 'S' TO WS-FLAG */
                        _.Move("S", WS_AUX_WORK.WS_FLAG);

                        /*" -1794- ADD 1 TO DP-FOLLOW */
                        WS_AUX_WORK.DP_FOLLOW.Value = WS_AUX_WORK.DP_FOLLOW + 1;

                        /*" -1797- GO TO R0452-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0452_99_SAIDA*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1798- IF V0FOLL-SITUACAO EQUAL '*' */

            if (V0FOLL_SITUACAO == "*")
            {

                /*" -1799- MOVE 'S' TO WS-FLAG */
                _.Move("S", WS_AUX_WORK.WS_FLAG);

                /*" -1799- ADD 1 TO DP-FOLLOW. */
                WS_AUX_WORK.DP_FOLLOW.Value = WS_AUX_WORK.DP_FOLLOW + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0452_99_SAIDA*/

        [StopWatch]
        /*" R0453-00-ACESSA-GE0070S-SECTION */
        private void R0453_00_ACESSA_GE0070S_SECTION()
        {
            /*" -1810- MOVE '0453' TO WNR-EXEC-SQL */
            _.Move("0453", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1813- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1814- DISPLAY '***' */
            _.Display($"***");

            /*" -1818- DISPLAY 'GE0070S ANT: ' V0BILH-NUMBIL '/' WS-PDT-LID-ANT '/' WS-DAT-LID-ANT '/' N88-NOVOS-ACESSOS */

            $"GE0070S ANT: {V0BILH_NUMBIL}/{WS_PDT_LID_ANT}/{WS_DAT_LID_ANT}/{NIVEIS_88.N88_NOVOS_ACESSOS}"
            .Display();

            /*" -1822- DISPLAY 'GE0070S ...: ' V0BILH-NUMBIL '/' V0BILH-COD-PRODUTO '/' V0BILH-DTVENDA '/' N88-NOVOS-ACESSOS */

            $"GE0070S ...: {V0BILH_NUMBIL}/{V0BILH_COD_PRODUTO}/{V0BILH_DTVENDA}/{NIVEIS_88.N88_NOVOS_ACESSOS}"
            .Display();

            /*" -1824- IF V0BILH-COD-PRODUTO EQUAL WS-PDT-LID-ANT AND V0BILH-DTVENDA EQUAL WS-DAT-LID-ANT */

            if (V0BILH_COD_PRODUTO == WS_PDT_LID_ANT && V0BILH_DTVENDA == WS_DAT_LID_ANT)
            {

                /*" -1825- IF NOVOS-ACESSOS */

                if (NIVEIS_88.N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
                {

                    /*" -1826- PERFORM R04531-00-ACESSA-GE0071S THRU R04531-99-SAIDA */

                    R04531_00_ACESSA_GE0071S_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R04531_99_SAIDA*/


                    /*" -1827- END-IF */
                }


                /*" -1828- DISPLAY 'R0453-99-SAIDA' */
                _.Display($"R0453-99-SAIDA");

                /*" -1829- GO TO R0453-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0453_99_SAIDA*/ //GOTO
                return;

                /*" -1830- ELSE */
            }
            else
            {


                /*" -1831- MOVE V0BILH-COD-PRODUTO TO WS-PDT-LID-ANT */
                _.Move(V0BILH_COD_PRODUTO, WS_PDT_LID_ANT);

                /*" -1832- MOVE V0BILH-DTVENDA TO WS-DAT-LID-ANT */
                _.Move(V0BILH_DTVENDA, WS_DAT_LID_ANT);

                /*" -1835- END-IF */
            }


            /*" -1836- MOVE 'S' TO LK-0070-E-TRACE */
            _.Move("S", GE0070W.LK_0070_E_TRACE);

            /*" -1837- MOVE 'BATCH' TO LK-0070-E-COD-USUARIO */
            _.Move("BATCH", GE0070W.LK_0070_E_COD_USUARIO);

            /*" -1838- MOVE 'CB0009B' TO LK-0070-E-NOM-PROGRAMA */
            _.Move("CB0009B", GE0070W.LK_0070_E_NOM_PROGRAMA);

            /*" -1839- MOVE 001 TO LK-0070-E-ACAO */
            _.Move(001, GE0070W.LK_0070_E_ACAO);

            /*" -1840- MOVE V0BILH-COD-PRODUTO TO LK-0070-I-COD-PRODUTO */
            _.Move(V0BILH_COD_PRODUTO, GE0070W.LK_0070_I_COD_PRODUTO);

            /*" -1841- MOVE ZEROS TO LK-0070-I-SEQ-PRODUTO-VRS */
            _.Move(0, GE0070W.LK_0070_I_SEQ_PRODUTO_VRS);

            /*" -1843- MOVE V0BILH-DTVENDA TO LK-0070-I-DTA-PROPOSTA */
            _.Move(V0BILH_DTVENDA, GE0070W.LK_0070_I_DTA_PROPOSTA);

            /*" -1844- MOVE 'GE0070S' TO WS-PGM-CALL */
            _.Move("GE0070S", WS_PGM_CALL);

            /*" -1887- CALL WS-PGM-CALL USING LK-0070-E-TRACE LK-0070-E-COD-USUARIO LK-0070-E-NOM-PROGRAMA LK-0070-E-ACAO LK-0070-I-COD-PRODUTO LK-0070-I-SEQ-PRODUTO-VRS LK-0070-I-DTA-PROPOSTA LK-0070-S-DTA-INI-VIGENCIA LK-0070-S-DTA-FIM-VIGENCIA LK-0070-S-IND-FLUXO-PARAM LK-0070-S-COD-PERIOD-VIGENCIA LK-0070-S-QTD-PERIOD-VIGENCIA LK-0070-S-COD-MOEDA LK-0070-S-IND-RENOVA LK-0070-S-IND-RENOVA-AUTOMAT LK-0070-S-QTD-RENOVA-AUTOMAT LK-0070-S-IND-DPS LK-0070-S-IND-REENQUADRA-PREM LK-0070-S-IND-REAJUSTE-PREMIO LK-0070-S-COD-INDICE-REAJUSTE LK-0070-S-COD-PERIOD-REAJUSTE LK-0070-S-COD-INDC-DEVOLUCAO LK-0070-S-PCT-JUROS-DEVOLUCAO LK-0070-S-PCT-MULTA-DEVOLUCAO LK-0070-S-IND-FLUXO-COMISSAO LK-0070-S-IND-ACOPLADO LK-0070-S-IND-FLUXO-SINISTRO LK-0070-S-IND-CONJUGE LK-0070-S-COD-USUARIO LK-0070-S-NOM-PROGRAMA LK-0070-S-DTH-CADASTRAMENTO LK-0070-IND-ERRO LK-0070-MSG-ERRO LK-0070-NOM-TABELA LK-0070-SQLCODE LK-0070-SQLERRMC LK-0070-SQLSTATE */
            _.Call(WS_PGM_CALL, GE0070W);

            /*" -1888- IF LK-0070-IND-ERRO EQUAL ZEROS */

            if (GE0070W.LK_0070_IND_ERRO == 00)
            {

                /*" -1890- DISPLAY 'LK-0070-S-IND-FLUXO-PARAM: ' LK-0070-S-IND-FLUXO-PARAM */
                _.Display($"LK-0070-S-IND-FLUXO-PARAM: {GE0070W.LK_0070_S_IND_FLUXO_PARAM}");

                /*" -1891- MOVE LK-0070-S-IND-FLUXO-PARAM TO N88-NOVOS-ACESSOS */
                _.Move(GE0070W.LK_0070_S_IND_FLUXO_PARAM, NIVEIS_88.N88_NOVOS_ACESSOS);

                /*" -1892- IF NOVOS-ACESSOS */

                if (NIVEIS_88.N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
                {

                    /*" -1893- PERFORM R04531-00-ACESSA-GE0071S THRU R04531-99-SAIDA */

                    R04531_00_ACESSA_GE0071S_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R04531_99_SAIDA*/


                    /*" -1894- END-IF */
                }


                /*" -1895- ELSE */
            }
            else
            {


                /*" -1896- DISPLAY '***' */
                _.Display($"***");

                /*" -1897- DISPLAY ' R0453-00-ACESSA-GE0070S   ' */
                _.Display($" R0453-00-ACESSA-GE0070S   ");

                /*" -1898- DISPLAY ' CALL GE0070S ' */
                _.Display($" CALL GE0070S ");

                /*" -1899- DISPLAY ' ERRO CALL GE0070S(' LK-0070-IND-ERRO ')' */

                $" ERRO CALL GE0070S({GE0070W.LK_0070_IND_ERRO})"
                .Display();

                /*" -1900- DISPLAY ' LK-0070-E-TRACE  : ' LK-0070-E-TRACE */
                _.Display($" LK-0070-E-TRACE  : {GE0070W.LK_0070_E_TRACE}");

                /*" -1901- DISPLAY ' LK-0070-E-COD-USU: ' LK-0070-E-COD-USUARIO */
                _.Display($" LK-0070-E-COD-USU: {GE0070W.LK_0070_E_COD_USUARIO}");

                /*" -1902- DISPLAY ' LK-0070-E-NOM-PRO: ' LK-0070-E-NOM-PROGRAMA */
                _.Display($" LK-0070-E-NOM-PRO: {GE0070W.LK_0070_E_NOM_PROGRAMA}");

                /*" -1903- DISPLAY ' LK-0070-E-ACAO   : ' LK-0070-E-ACAO */
                _.Display($" LK-0070-E-ACAO   : {GE0070W.LK_0070_E_ACAO}");

                /*" -1904- DISPLAY ' LK-0070-I-COD-PRO: ' LK-0070-I-COD-PRODUTO */
                _.Display($" LK-0070-I-COD-PRO: {GE0070W.LK_0070_I_COD_PRODUTO}");

                /*" -1905- DISPLAY ' LK-0070-I-SEQ-PRO: ' LK-0070-I-SEQ-PRODUTO-VRS */
                _.Display($" LK-0070-I-SEQ-PRO: {GE0070W.LK_0070_I_SEQ_PRODUTO_VRS}");

                /*" -1906- DISPLAY ' LK-0070-I-DTA-PRO: ' LK-0070-I-DTA-PROPOSTA */
                _.Display($" LK-0070-I-DTA-PRO: {GE0070W.LK_0070_I_DTA_PROPOSTA}");

                /*" -1907- DISPLAY '***' */
                _.Display($"***");

                /*" -1908- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1910- END-IF */
            }


            /*" -1910- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0453_99_SAIDA*/

        [StopWatch]
        /*" R04531-00-ACESSA-GE0071S-SECTION */
        private void R04531_00_ACESSA_GE0071S_SECTION()
        {
            /*" -1919- MOVE '04531' TO WNR-EXEC-SQL */
            _.Move("04531", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1922- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1923- MOVE 'S' TO LK-0071-E-TRACE */
            _.Move("S", GE0071W.LK_0071_E_TRACE);

            /*" -1924- MOVE 'BATCH' TO LK-0071-E-COD-USUARIO */
            _.Move("BATCH", GE0071W.LK_0071_E_COD_USUARIO);

            /*" -1925- MOVE 'CB0009B' TO LK-0071-E-NOM-PROGRAMA */
            _.Move("CB0009B", GE0071W.LK_0071_E_NOM_PROGRAMA);

            /*" -1926- MOVE 001 TO LK-0071-E-ACAO */
            _.Move(001, GE0071W.LK_0071_E_ACAO);

            /*" -1927- MOVE V0BILH-COD-PRODUTO TO LK-0071-I-COD-PRODUTO */
            _.Move(V0BILH_COD_PRODUTO, GE0071W.LK_0071_I_COD_PRODUTO);

            /*" -1929- MOVE LK-0070-I-SEQ-PRODUTO-VRS TO LK-0071-I-SEQ-PRODUTO-VRS */
            _.Move(GE0070W.LK_0070_I_SEQ_PRODUTO_VRS, GE0071W.LK_0071_I_SEQ_PRODUTO_VRS);

            /*" -1930- MOVE SPACES TO LK-0071-I-COD-OPC-COBERTURA */
            _.Move("", GE0071W.LK_0071_I_COD_OPC_COBERTURA);

            /*" -1931- MOVE V0BILH-OPCOBER TO LK-0071-I-COD-OPC-PLANO */
            _.Move(V0BILH_OPCOBER, GE0071W.LK_0071_I_COD_OPC_PLANO);

            /*" -1932- MOVE 'N' TO LK-0071-I-IND-CONJUGE */
            _.Move("N", GE0071W.LK_0071_I_IND_CONJUGE);

            /*" -1933- MOVE V0BILH-DTVENDA(1:4) TO WS-ANO-BASE */
            _.Move(V0BILH_DTVENDA.Substring(1, 4), WS_ANO_BASE);

            /*" -1934- MOVE V0CLIE-DTNASC(1:4) TO WS-ANO-NASC */
            _.Move(V0CLIE_DTNASC.Substring(1, 4), WS_ANO_NASC);

            /*" -1935- COMPUTE WS-IDADE = WS-ANO-BASE - WS-ANO-NASC */
            WS_IDADE.Value = WS_ANO_BASE - WS_ANO_NASC;

            /*" -1937- IF V0CLIE-DTNASC(6:5) GREATER V0BILH-DTVENDA(6:5) */

            if (V0CLIE_DTNASC.Substring(6, 5) > V0BILH_DTVENDA.Substring(6, 5))
            {

                /*" -1938- COMPUTE WS-IDADE = WS-IDADE - 1 */
                WS_IDADE.Value = WS_IDADE - 1;

                /*" -1939- END-IF */
            }


            /*" -1942- MOVE WS-IDADE TO LK-0071-I-NUM-IDADE */
            _.Move(WS_IDADE, GE0071W.LK_0071_I_NUM_IDADE);

            /*" -1943- MOVE 'GE0071S' TO WS-PGM-CALL */
            _.Move("GE0071S", WS_PGM_CALL);

            /*" -1944- DISPLAY 'EXECUTOU: ' WS-PGM-CALL */
            _.Display($"EXECUTOU: {WS_PGM_CALL}");

            /*" -1976- CALL WS-PGM-CALL USING LK-0071-E-TRACE LK-0071-E-COD-USUARIO LK-0071-E-NOM-PROGRAMA LK-0071-E-ACAO LK-0071-I-COD-PRODUTO LK-0071-I-SEQ-PRODUTO-VRS LK-0071-I-COD-OPC-COBERTURA LK-0071-I-COD-OPC-PLANO LK-0071-I-IND-CONJUGE LK-0071-I-NUM-IDADE LK-0071-S-NUM-IDADE-INI LK-0071-S-NUM-IDADE-FIM LK-0071-S-VLR-INI-PREMIO LK-0071-S-VLR-FIM-PREMIO LK-0071-S-PCT-IOF LK-0071-S-PCT-REENQUADRAMENTO LK-0071-S-IND-PERMIT-VENDA LK-0071-S-VLR-TOTAL-IS LK-0071-S-QTD-OCC LK-0071-S-ARR LK-0071-IND-ERRO LK-0071-MSG-ERRO LK-0071-NOM-TABELA LK-0071-SQLCODE LK-0071-SQLERRMC LK-0071-SQLSTATE */
            _.Call(WS_PGM_CALL, GE0071W, GE0071W.LK_0071_S_ARR);

            /*" -1977- IF LK-0071-IND-ERRO NOT EQUAL ZEROS */

            if (GE0071W.LK_0071_S_ARR.LK_0071_IND_ERRO != 00)
            {

                /*" -1978- DISPLAY '***' */
                _.Display($"***");

                /*" -1979- DISPLAY ' 17000-00-OBTER-COBERTURA  ' */
                _.Display($" 17000-00-OBTER-COBERTURA  ");

                /*" -1980- DISPLAY ' ERRO CALL GE0071S(' LK-0071-IND-ERRO ')' */

                $" ERRO CALL GE0071S({GE0071W.LK_0071_S_ARR.LK_0071_IND_ERRO})"
                .Display();

                /*" -1981- DISPLAY ' LK-0071-E-TRACE  : ' LK-0071-E-TRACE */
                _.Display($" LK-0071-E-TRACE  : {GE0071W.LK_0071_E_TRACE}");

                /*" -1982- DISPLAY ' LK-0071-E-COD-USU: ' LK-0071-E-COD-USUARIO */
                _.Display($" LK-0071-E-COD-USU: {GE0071W.LK_0071_E_COD_USUARIO}");

                /*" -1983- DISPLAY ' LK-0071-E-NOM-PRO: ' LK-0071-E-NOM-PROGRAMA */
                _.Display($" LK-0071-E-NOM-PRO: {GE0071W.LK_0071_E_NOM_PROGRAMA}");

                /*" -1984- DISPLAY ' LK-0071-E-ACAO   : ' LK-0071-E-ACAO */
                _.Display($" LK-0071-E-ACAO   : {GE0071W.LK_0071_E_ACAO}");

                /*" -1985- DISPLAY ' LK-0071-I-COD-PRO: ' LK-0071-I-COD-PRODUTO */
                _.Display($" LK-0071-I-COD-PRO: {GE0071W.LK_0071_I_COD_PRODUTO}");

                /*" -1986- DISPLAY ' LK-0071-I-SEQ-PRO: ' LK-0071-I-SEQ-PRODUTO-VRS */
                _.Display($" LK-0071-I-SEQ-PRO: {GE0071W.LK_0071_I_SEQ_PRODUTO_VRS}");

                /*" -1987- DISPLAY ' LK-0071-I-COD-OPC: ' LK-0071-I-COD-OPC-COBERTURA */
                _.Display($" LK-0071-I-COD-OPC: {GE0071W.LK_0071_I_COD_OPC_COBERTURA}");

                /*" -1988- DISPLAY ' LK-0071-I-COD-PLA: ' LK-0071-I-COD-OPC-PLANO */
                _.Display($" LK-0071-I-COD-PLA: {GE0071W.LK_0071_I_COD_OPC_PLANO}");

                /*" -1989- DISPLAY ' LK-0071-I-IND-CON: ' LK-0071-I-IND-CONJUGE */
                _.Display($" LK-0071-I-IND-CON: {GE0071W.LK_0071_I_IND_CONJUGE}");

                /*" -1990- DISPLAY ' LK-0071-I-NUM-IDA: ' LK-0071-I-NUM-IDADE */
                _.Display($" LK-0071-I-NUM-IDA: {GE0071W.LK_0071_I_NUM_IDADE}");

                /*" -1991- DISPLAY '***' */
                _.Display($"***");

                /*" -1992- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1994- END-IF */
            }


            /*" -1995- DISPLAY '** NUM-IDADE-INI.......: ' LK-0071-S-NUM-IDADE-INI */
            _.Display($"** NUM-IDADE-INI.......: {GE0071W.LK_0071_S_NUM_IDADE_INI}");

            /*" -1996- DISPLAY '** COD-OPC-PLANO.......: ' LK-0071-I-COD-OPC-PLANO */
            _.Display($"** COD-OPC-PLANO.......: {GE0071W.LK_0071_I_COD_OPC_PLANO}");

            /*" -1997- DISPLAY '** NUM-IDADE-FIM.......: ' LK-0071-S-NUM-IDADE-FIM */
            _.Display($"** NUM-IDADE-FIM.......: {GE0071W.LK_0071_S_NUM_IDADE_FIM}");

            /*" -1998- DISPLAY '** VLR-INI-PREMIO......: ' LK-0071-S-VLR-INI-PREMIO */
            _.Display($"** VLR-INI-PREMIO......: {GE0071W.LK_0071_S_VLR_INI_PREMIO}");

            /*" -1999- DISPLAY '** VLR-FIM-PREMIO......: ' LK-0071-S-VLR-FIM-PREMIO */
            _.Display($"** VLR-FIM-PREMIO......: {GE0071W.LK_0071_S_VLR_FIM_PREMIO}");

            /*" -2000- DISPLAY '**PCT-IOF..............: ' LK-0071-S-PCT-IOF */
            _.Display($"**PCT-IOF..............: {GE0071W.LK_0071_S_PCT_IOF}");

            /*" -2002- DISPLAY '**PCT-REENQUADRAMENTO..: ' LK-0071-S-PCT-REENQUADRAMENTO */
            _.Display($"**PCT-REENQUADRAMENTO..: {GE0071W.LK_0071_S_PCT_REENQUADRAMENTO}");

            /*" -2004- DISPLAY '**IND-PERMIT-VENDA.....: ' LK-0071-S-IND-PERMIT-VENDA */
            _.Display($"**IND-PERMIT-VENDA.....: {GE0071W.LK_0071_S_IND_PERMIT_VENDA}");

            /*" -2005- IF LK-0071-S-IND-PERMIT-VENDA = 'N' */

            if (GE0071W.LK_0071_S_IND_PERMIT_VENDA == "N")
            {

                /*" -2006- DISPLAY '** VENDA NAO PERMITIDA PARA ESTA IDADE **' */
                _.Display($"** VENDA NAO PERMITIDA PARA ESTA IDADE **");

                /*" -2007- DISPLAY '** VENDA NAO PERMITIDA PARA ESTA IDADE **' */
                _.Display($"** VENDA NAO PERMITIDA PARA ESTA IDADE **");

                /*" -2008- DISPLAY '** VENDA NAO PERMITIDA PARA ESTA IDADE **' */
                _.Display($"** VENDA NAO PERMITIDA PARA ESTA IDADE **");

                /*" -2009- DISPLAY '** VENDA NAO PERMITIDA PARA ESTA IDADE **' */
                _.Display($"** VENDA NAO PERMITIDA PARA ESTA IDADE **");

                /*" -2011- END-IF */
            }


            /*" -2011- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R04531_99_SAIDA*/

        [StopWatch]
        /*" R0455-00-SELECT-V0FOLLOWUP-SECTION */
        private void R0455_00_SELECT_V0FOLLOWUP_SECTION()
        {
            /*" -2019- MOVE '0455' TO WNR-EXEC-SQL. */
            _.Move("0455", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2021- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2036- PERFORM R0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1 */

            R0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1();

        }

        [StopWatch]
        /*" R0455-00-SELECT-V0FOLLOWUP-DB-SELECT-1 */
        public void R0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1()
        {
            /*" -2036- EXEC SQL SELECT VLPREMIO , BCOAVISO , AGEAVISO , NRAVISO , DTQITBCO , SITUACAO INTO :V0FOLL-VLPREMIO , :V0FOLL-BCOAVISO , :V0FOLL-AGEAVISO , :V0FOLL-NRAVISO , :V0FOLL-DTQITBCO , :V0FOLL-SITUACAO FROM SEGUROS.V0FOLLOWUP WHERE NUM_APOLICE = :V0FOLL-NUMAPOL END-EXEC. */

            var r0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1 = new R0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1()
            {
                V0FOLL_NUMAPOL = V0FOLL_NUMAPOL.ToString(),
            };

            var executed_1 = R0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1.Execute(r0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FOLL_VLPREMIO, V0FOLL_VLPREMIO);
                _.Move(executed_1.V0FOLL_BCOAVISO, V0FOLL_BCOAVISO);
                _.Move(executed_1.V0FOLL_AGEAVISO, V0FOLL_AGEAVISO);
                _.Move(executed_1.V0FOLL_NRAVISO, V0FOLL_NRAVISO);
                _.Move(executed_1.V0FOLL_DTQITBCO, V0FOLL_DTQITBCO);
                _.Move(executed_1.V0FOLL_SITUACAO, V0FOLL_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0455_99_SAIDA*/

        [StopWatch]
        /*" R0460-00-SELECT-V0RCAP-SECTION */
        private void R0460_00_SELECT_V0RCAP_SECTION()
        {
            /*" -2047- MOVE '0460' TO WNR-EXEC-SQL. */
            _.Move("0460", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2049- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2086- PERFORM R0460_00_SELECT_V0RCAP_DB_SELECT_1 */

            R0460_00_SELECT_V0RCAP_DB_SELECT_1();

            /*" -2090- IF SQLCODE NOT EQUAL ZEROS NEXT SENTENCE */

            if (DB.SQLCODE != 00)
            {

                /*" -2091- ELSE */
            }
            else
            {


                /*" -2092- IF VIND-AGECOBR LESS ZEROS */

                if (VIND_AGECOBR < 00)
                {

                    /*" -2093- MOVE ZEROS TO V0RCAP-AGECOBR */
                    _.Move(0, V0RCAP_AGECOBR);

                    /*" -2094- END-IF */
                }


                /*" -2095- GO TO R0460-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0460_99_SAIDA*/ //GOTO
                return;

                /*" -2098- END-IF. */
            }


            /*" -2134- PERFORM R0460_00_SELECT_V0RCAP_DB_SELECT_2 */

            R0460_00_SELECT_V0RCAP_DB_SELECT_2();

            /*" -2137- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2138- MOVE 'N' TO V0RCAP-SITUACAO */
                _.Move("N", V0RCAP_SITUACAO);

                /*" -2139- ELSE */
            }
            else
            {


                /*" -2140- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2141- MOVE '*' TO V0RCAP-SITUACAO */
                    _.Move("*", V0RCAP_SITUACAO);

                    /*" -2142- ELSE */
                }
                else
                {


                    /*" -2143- IF VIND-AGECOBR LESS ZEROS */

                    if (VIND_AGECOBR < 00)
                    {

                        /*" -2143- MOVE ZEROS TO V0RCAP-AGECOBR. */
                        _.Move(0, V0RCAP_AGECOBR);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0460-00-SELECT-V0RCAP-DB-SELECT-1 */
        public void R0460_00_SELECT_V0RCAP_DB_SELECT_1()
        {
            /*" -2086- EXEC SQL SELECT A.VLRCAP , A.VALPRI , A.SITUACAO , A.AGECOBR , B.FONTE , B.NRRCAP , B.BCOAVISO , B.AGEAVISO , B.NRAVISO , B.VLRCAP , B.DATARCAP , B.DTCADAST , B.DTMOVTO , B.SITCONTB INTO :V0RCAP-VLRCAP , :V0RCAP-VALPRI , :V0RCAP-SITUACAO , :V0RCAP-AGECOBR:VIND-AGECOBR , :V0RCOM-FONTE , :V0RCOM-NRRCAP , :V0RCOM-BCOAVISO , :V0RCOM-AGEAVISO , :V0RCOM-NRAVISO , :V0RCOM-VLRCAP , :V0RCOM-DATARCAP , :V0RCOM-DTCADAST , :V0RCOM-DTMOVTO , :V0RCOM-SITCONTB FROM SEGUROS.V0RCAP A, SEGUROS.V0RCAPCOMP B WHERE A.NRRCAP = :V0RCAP-NRRCAP AND A.FONTE = :V0BILH-FONTE AND B.FONTE = A.FONTE AND B.NRRCAP = A.NRRCAP AND B.NRRCAPCO = 0 AND B.SITUACAO = '0' END-EXEC. */

            var r0460_00_SELECT_V0RCAP_DB_SELECT_1_Query1 = new R0460_00_SELECT_V0RCAP_DB_SELECT_1_Query1()
            {
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0BILH_FONTE = V0BILH_FONTE.ToString(),
            };

            var executed_1 = R0460_00_SELECT_V0RCAP_DB_SELECT_1_Query1.Execute(r0460_00_SELECT_V0RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_VLRCAP, V0RCAP_VLRCAP);
                _.Move(executed_1.V0RCAP_VALPRI, V0RCAP_VALPRI);
                _.Move(executed_1.V0RCAP_SITUACAO, V0RCAP_SITUACAO);
                _.Move(executed_1.V0RCAP_AGECOBR, V0RCAP_AGECOBR);
                _.Move(executed_1.VIND_AGECOBR, VIND_AGECOBR);
                _.Move(executed_1.V0RCOM_FONTE, V0RCOM_FONTE);
                _.Move(executed_1.V0RCOM_NRRCAP, V0RCOM_NRRCAP);
                _.Move(executed_1.V0RCOM_BCOAVISO, V0RCOM_BCOAVISO);
                _.Move(executed_1.V0RCOM_AGEAVISO, V0RCOM_AGEAVISO);
                _.Move(executed_1.V0RCOM_NRAVISO, V0RCOM_NRAVISO);
                _.Move(executed_1.V0RCOM_VLRCAP, V0RCOM_VLRCAP);
                _.Move(executed_1.V0RCOM_DATARCAP, V0RCOM_DATARCAP);
                _.Move(executed_1.V0RCOM_DTCADAST, V0RCOM_DTCADAST);
                _.Move(executed_1.V0RCOM_DTMOVTO, V0RCOM_DTMOVTO);
                _.Move(executed_1.V0RCOM_SITCONTB, V0RCOM_SITCONTB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0460_99_SAIDA*/

        [StopWatch]
        /*" R0460-00-SELECT-V0RCAP-DB-SELECT-2 */
        public void R0460_00_SELECT_V0RCAP_DB_SELECT_2()
        {
            /*" -2134- EXEC SQL SELECT A.VLRCAP , A.VALPRI , A.SITUACAO , A.AGECOBR , B.FONTE , B.NRRCAP , B.BCOAVISO , B.AGEAVISO , B.NRAVISO , B.VLRCAP , B.DATARCAP , B.DTCADAST , B.DTMOVTO , B.SITCONTB INTO :V0RCAP-VLRCAP , :V0RCAP-VALPRI , :V0RCAP-SITUACAO , :V0RCAP-AGECOBR:VIND-AGECOBR , :V0RCOM-FONTE , :V0RCOM-NRRCAP , :V0RCOM-BCOAVISO , :V0RCOM-AGEAVISO , :V0RCOM-NRAVISO , :V0RCOM-VLRCAP , :V0RCOM-DATARCAP , :V0RCOM-DTCADAST , :V0RCOM-DTMOVTO , :V0RCOM-SITCONTB FROM SEGUROS.V0RCAP A, SEGUROS.V0RCAPCOMP B WHERE A.NRRCAP = :V0RCAP-NRRCAP AND B.FONTE = A.FONTE AND B.NRRCAP = A.NRRCAP AND B.NRRCAPCO = 0 AND B.SITUACAO = '0' END-EXEC. */

            var r0460_00_SELECT_V0RCAP_DB_SELECT_2_Query1 = new R0460_00_SELECT_V0RCAP_DB_SELECT_2_Query1()
            {
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
            };

            var executed_1 = R0460_00_SELECT_V0RCAP_DB_SELECT_2_Query1.Execute(r0460_00_SELECT_V0RCAP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_VLRCAP, V0RCAP_VLRCAP);
                _.Move(executed_1.V0RCAP_VALPRI, V0RCAP_VALPRI);
                _.Move(executed_1.V0RCAP_SITUACAO, V0RCAP_SITUACAO);
                _.Move(executed_1.V0RCAP_AGECOBR, V0RCAP_AGECOBR);
                _.Move(executed_1.VIND_AGECOBR, VIND_AGECOBR);
                _.Move(executed_1.V0RCOM_FONTE, V0RCOM_FONTE);
                _.Move(executed_1.V0RCOM_NRRCAP, V0RCOM_NRRCAP);
                _.Move(executed_1.V0RCOM_BCOAVISO, V0RCOM_BCOAVISO);
                _.Move(executed_1.V0RCOM_AGEAVISO, V0RCOM_AGEAVISO);
                _.Move(executed_1.V0RCOM_NRAVISO, V0RCOM_NRAVISO);
                _.Move(executed_1.V0RCOM_VLRCAP, V0RCOM_VLRCAP);
                _.Move(executed_1.V0RCOM_DATARCAP, V0RCOM_DATARCAP);
                _.Move(executed_1.V0RCOM_DTCADAST, V0RCOM_DTCADAST);
                _.Move(executed_1.V0RCOM_DTMOVTO, V0RCOM_DTMOVTO);
                _.Move(executed_1.V0RCOM_SITCONTB, V0RCOM_SITCONTB);
            }


        }

        [StopWatch]
        /*" R0470-00-SELECT-V0COMISSAO-SECTION */
        private void R0470_00_SELECT_V0COMISSAO_SECTION()
        {
            /*" -2154- MOVE '0470' TO WNR-EXEC-SQL. */
            _.Move("0470", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2156- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2178- PERFORM R0470_00_SELECT_V0COMISSAO_DB_SELECT_1 */

            R0470_00_SELECT_V0COMISSAO_DB_SELECT_1();

            /*" -2181- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2181- MOVE '*' TO V0CFEN-SITUACAO. */
                _.Move("*", V0CFEN_SITUACAO);
            }


        }

        [StopWatch]
        /*" R0470-00-SELECT-V0COMISSAO-DB-SELECT-1 */
        public void R0470_00_SELECT_V0COMISSAO_DB_SELECT_1()
        {
            /*" -2178- EXEC SQL SELECT AGECOBR , NUM_MATRICULA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , DTQITBCO , VLRCAP , SITUACAO INTO :V0CFEN-AGECOBR , :V0CFEN-MATRICULA , :V0CFEN-AGECONTA , :V0CFEN-OPECONTA , :V0CFEN-NUMCONTA , :V0CFEN-DIGCONTA , :V0CFEN-DTQITBCO , :V0CFEN-VLRCAP , :V0CFEN-SITUACAO FROM SEGUROS.V0COMISSAO_FENAE WHERE NUMBIL = :V0BILH-NUMBIL AND NUM_MATRICULA NOT IN (8888888,9999999) END-EXEC. */

            var r0470_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1 = new R0470_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R0470_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1.Execute(r0470_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CFEN_AGECOBR, V0CFEN_AGECOBR);
                _.Move(executed_1.V0CFEN_MATRICULA, V0CFEN_MATRICULA);
                _.Move(executed_1.V0CFEN_AGECONTA, V0CFEN_AGECONTA);
                _.Move(executed_1.V0CFEN_OPECONTA, V0CFEN_OPECONTA);
                _.Move(executed_1.V0CFEN_NUMCONTA, V0CFEN_NUMCONTA);
                _.Move(executed_1.V0CFEN_DIGCONTA, V0CFEN_DIGCONTA);
                _.Move(executed_1.V0CFEN_DTQITBCO, V0CFEN_DTQITBCO);
                _.Move(executed_1.V0CFEN_VLRCAP, V0CFEN_VLRCAP);
                _.Move(executed_1.V0CFEN_SITUACAO, V0CFEN_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0470_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-DECLARE-V0ERRO-SECTION */
        private void R0500_00_DECLARE_V0ERRO_SECTION()
        {
            /*" -2192- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2206- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2219- PERFORM R0500_00_DECLARE_V0ERRO_DB_DECLARE_1 */

            R0500_00_DECLARE_V0ERRO_DB_DECLARE_1();

            /*" -2222- PERFORM R0500_00_DECLARE_V0ERRO_DB_OPEN_1 */

            R0500_00_DECLARE_V0ERRO_DB_OPEN_1();

            /*" -2226- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2227- DISPLAY 'R0500-00 - PROBLEMAS DECLARE (V0ERRO)    ' */
                _.Display($"R0500-00 - PROBLEMAS DECLARE (V0ERRO)    ");

                /*" -2227- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-V0ERRO-DB-OPEN-1 */
        public void R0500_00_DECLARE_V0ERRO_DB_OPEN_1()
        {
            /*" -2222- EXEC SQL OPEN V0ERRO END-EXEC. */

            V0ERRO.Open();

        }

        [StopWatch]
        /*" R2810-00-DECLARE-V0ERRO-DB-DECLARE-1 */
        public void R2810_00_DECLARE_V0ERRO_DB_DECLARE_1()
        {
            /*" -4136- EXEC SQL DECLARE V1ERRO CURSOR FOR SELECT A.NUM_CERTIFICADO, A.COD_MSG_CRITICA FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :V0BILH-NUMBIL AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA IN (701,702,703) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> 3 ORDER BY A.COD_MSG_CRITICA WITH UR END-EXEC. */
            V1ERRO = new CB0009B_V1ERRO(true);
            string GetQuery_V1ERRO()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO
							, 
							A.COD_MSG_CRITICA 
							FROM SEGUROS.VG_CRITICA_PROPOSTA A
							, 
							SEGUROS.VG_DM_MSG_CRITICA B 
							WHERE A.NUM_CERTIFICADO = '{V0BILH_NUMBIL}' 
							AND A.STA_CRITICA IN ( '0'
							, '1'
							, '2'
							, '4'
							, '5'
							, '8' ) 
							AND A.COD_MSG_CRITICA IN (701
							,702
							,703) 
							AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA 
							AND B.COD_TP_MSG_CRITICA <> 3 
							ORDER BY A.COD_MSG_CRITICA";

                return query;
            }
            V1ERRO.GetQueryEvent += GetQuery_V1ERRO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-V0ERRO-SECTION */
        private void R0510_00_FETCH_V0ERRO_SECTION()
        {
            /*" -2238- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2240- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2244- PERFORM R0510_00_FETCH_V0ERRO_DB_FETCH_1 */

            R0510_00_FETCH_V0ERRO_DB_FETCH_1();

            /*" -2247- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2248- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2248- PERFORM R0510_00_FETCH_V0ERRO_DB_CLOSE_1 */

                    R0510_00_FETCH_V0ERRO_DB_CLOSE_1();

                    /*" -2250- MOVE 'S' TO WFIM-V0ERRO */
                    _.Move("S", WS_AUX_WORK.WFIM_V0ERRO);

                    /*" -2251- GO TO R0510-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/ //GOTO
                    return;

                    /*" -2252- ELSE */
                }
                else
                {


                    /*" -2253- DISPLAY 'R0510-00 - PROBLEMAS FETCH (V0ERRO)      ' */
                    _.Display($"R0510-00 - PROBLEMAS FETCH (V0ERRO)      ");

                    /*" -2255- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2259- DISPLAY 'ERRO: ' V0ERRO-NUMBIL '/' V0ERRO-CODERRO '/' V0ERRO-MSG-CRITICA */

            $"ERRO: {V0ERRO_NUMBIL}/{V0ERRO_CODERRO}/{V0ERRO_MSG_CRITICA}"
            .Display();

            /*" -2259- . */

        }

        [StopWatch]
        /*" R0510-00-FETCH-V0ERRO-DB-FETCH-1 */
        public void R0510_00_FETCH_V0ERRO_DB_FETCH_1()
        {
            /*" -2244- EXEC SQL FETCH V0ERRO INTO :V0ERRO-NUMBIL , :V0ERRO-CODERRO , :V0ERRO-MSG-CRITICA END-EXEC. */

            if (V0ERRO.Fetch())
            {
                _.Move(V0ERRO.V0ERRO_NUMBIL, V0ERRO_NUMBIL);
                _.Move(V0ERRO.V0ERRO_CODERRO, V0ERRO_CODERRO);
                _.Move(V0ERRO.V0ERRO_MSG_CRITICA, V0ERRO_MSG_CRITICA);
            }

        }

        [StopWatch]
        /*" R0510-00-FETCH-V0ERRO-DB-CLOSE-1 */
        public void R0510_00_FETCH_V0ERRO_DB_CLOSE_1()
        {
            /*" -2248- EXEC SQL CLOSE V0ERRO END-EXEC */

            V0ERRO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-PROCESSA-V0ERRO-SECTION */
        private void R0550_00_PROCESSA_V0ERRO_SECTION()
        {
            /*" -2268- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2270- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2273- IF V0ERRO-CODERRO EQUAL 1200 OR 11201 */

            if (V0ERRO_CODERRO.In("1200", "11201"))
            {

                /*" -2274- ADD 1 TO AC-SEXO */
                WS_AUX_WORK.AC_SEXO.Value = WS_AUX_WORK.AC_SEXO + 1;

                /*" -2279- PERFORM R0560-00-TRATA-SEXO. */

                R0560_00_TRATA_SEXO_SECTION();
            }


            /*" -2281- IF V0ERRO-CODERRO EQUAL 11301 OR 11302 */

            if (V0ERRO_CODERRO.In("11301", "11302"))
            {

                /*" -2282- ADD 1 TO AC-CIVIL */
                WS_AUX_WORK.AC_CIVIL.Value = WS_AUX_WORK.AC_CIVIL + 1;

                /*" -2286- PERFORM R0570-00-TRATA-CIVIL. */

                R0570_00_TRATA_CIVIL_SECTION();
            }


            /*" -2287- IF V0ERRO-CODERRO EQUAL 11101 */

            if (V0ERRO_CODERRO == 11101)
            {

                /*" -2288- ADD 1 TO AC-IDADE */
                WS_AUX_WORK.AC_IDADE.Value = WS_AUX_WORK.AC_IDADE + 1;

                /*" -2297- PERFORM R0600-00-TRATA-IDADE. */

                R0600_00_TRATA_IDADE_SECTION();
            }


            /*" -2303- IF V0ERRO-CODERRO EQUAL 10101 OR 10102 OR 10103 OR 10201 OR 10202 OR 10205 */

            if (V0ERRO_CODERRO.In("10101", "10102", "10103", "10201", "10202", "10205"))
            {

                /*" -2304- ADD 1 TO AC-FILIAL */
                WS_AUX_WORK.AC_FILIAL.Value = WS_AUX_WORK.AC_FILIAL + 1;

                /*" -2309- PERFORM R0650-00-TRATA-FILIAL. */

                R0650_00_TRATA_FILIAL_SECTION();
            }


            /*" -2311- IF V0ERRO-CODERRO EQUAL 12301 OR 12302 */

            if (V0ERRO_CODERRO.In("12301", "12302"))
            {

                /*" -2312- ADD 1 TO AC-RENDA */
                WS_AUX_WORK.AC_RENDA.Value = WS_AUX_WORK.AC_RENDA + 1;

                /*" -2317- PERFORM R0660-00-TRATA-RENDA. */

                R0660_00_TRATA_RENDA_SECTION();
            }


            /*" -2319- IF V0ERRO-CODERRO EQUAL 11803 OR 11811 */

            if (V0ERRO_CODERRO.In("11803", "11811"))
            {

                /*" -2331- PERFORM R0670-00-TRATA-PROFISSAO. */

                R0670_00_TRATA_PROFISSAO_SECTION();
            }


            /*" -2340- IF V0ERRO-CODERRO EQUAL 11501 OR 11502 OR 1503 OR 1602 OR 11801 OR 11802 OR 11901 OR 12101 OR 12102 */

            if (V0ERRO_CODERRO.In("11501", "11502", "1503", "1602", "11801", "11802", "11901", "12101", "12102"))
            {

                /*" -2342- PERFORM R0700-00-TRATA-ERROS. */

                R0700_00_TRATA_ERROS_SECTION();
            }


            /*" -2345- IF V0ERRO-CODERRO EQUAL 803 AND V0BILH-RAMO EQUAL 81 OR 82 */

            if (V0ERRO_CODERRO == 803 && V0BILH_RAMO.In("81", "82"))
            {

                /*" -2346- PERFORM R2860-00-DELETE-VGCRITICA */

                R2860_00_DELETE_VGCRITICA_SECTION();

                /*" -2349- END-IF */
            }


            /*" -2352- IF V0ERRO-CODERRO EQUAL 11401 AND V0BILH-RAMO EQUAL 81 OR 82 */

            if (V0ERRO_CODERRO == 11401 && V0BILH_RAMO.In("81", "82"))
            {

                /*" -2353- PERFORM R2860-00-DELETE-VGCRITICA */

                R2860_00_DELETE_VGCRITICA_SECTION();

                /*" -2355- END-IF */
            }


            /*" -2358- IF V0ERRO-CODERRO EQUAL 2205 AND V0BILH-RAMO EQUAL 81 OR 82 */

            if (V0ERRO_CODERRO == 2205 && V0BILH_RAMO.In("81", "82"))
            {

                /*" -2359- PERFORM R2860-00-DELETE-VGCRITICA */

                R2860_00_DELETE_VGCRITICA_SECTION();

                /*" -2360- END-IF */
            }


            /*" -2360- . */

            /*" -0- FLUXCONTROL_PERFORM R0550_90_LEITURA */

            R0550_90_LEITURA();

        }

        [StopWatch]
        /*" R0550-90-LEITURA */
        private void R0550_90_LEITURA(bool isPerform = false)
        {
            /*" -2363- PERFORM R0510-00-FETCH-V0ERRO. */

            R0510_00_FETCH_V0ERRO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0560-00-TRATA-SEXO-SECTION */
        private void R0560_00_TRATA_SEXO_SECTION()
        {
            /*" -2373- MOVE '0560' TO WNR-EXEC-SQL. */
            _.Move("0560", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2375- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2395- IF V0BILH-NUMBIL EQUAL 84518482341 OR 84518482406 OR 84526643618 OR 84553629272 OR 84554580277 OR 84554581001 OR 84560491345 OR 84566065380 OR 84571379622 OR 84537351621 OR 84537351613 OR 84603462236 OR 95319958970 OR 84586320041 OR 95320033836 OR 84580641008 OR 84575286092 OR 84588629481 OR 84585693740 OR 84602111472 */

            if (V0BILH_NUMBIL.In("84518482341", "84518482406", "84526643618", "84553629272", "84554580277", "84554581001", "84560491345", "84566065380", "84571379622", "84537351621", "84537351613", "84603462236", "95319958970", "84586320041", "95320033836", "84580641008", "84575286092", "84588629481", "84585693740", "84602111472"))
            {

                /*" -2396- MOVE 'M' TO V0BILH-SEXO */
                _.Move("M", V0BILH_SEXO);

                /*" -2399- PERFORM R0565-00-UPDATE-V0BILHETE. */

                R0565_00_UPDATE_V0BILHETE_SECTION();
            }


            /*" -2413- IF V0BILH-NUMBIL EQUAL 84526623749 OR 84541651979 OR 84569647810 OR 84575309289 OR 84579990908 OR 84580494102 OR 84602236240 OR 84602506477 OR 84603464344 OR 95319205246 OR 95319205254 OR 95319205262 OR 95317867381 OR 95319899167 */

            if (V0BILH_NUMBIL.In("84526623749", "84541651979", "84569647810", "84575309289", "84579990908", "84580494102", "84602236240", "84602506477", "84603464344", "95319205246", "95319205254", "95319205262", "95317867381", "95319899167"))
            {

                /*" -2414- MOVE 'F' TO V0BILH-SEXO */
                _.Move("F", V0BILH_SEXO);

                /*" -2417- PERFORM R0565-00-UPDATE-V0BILHETE. */

                R0565_00_UPDATE_V0BILHETE_SECTION();
            }


            /*" -2420- IF V0BILH-SEXO NOT EQUAL 'M' AND V0BILH-SEXO NOT EQUAL 'F' AND V0BILH-SEXO NOT EQUAL SPACES */

            if (V0BILH_SEXO != "M" && V0BILH_SEXO != "F" && !V0BILH_SEXO.IsEmpty())
            {

                /*" -2421- MOVE SPACES TO V0BILH-SEXO */
                _.Move("", V0BILH_SEXO);

                /*" -2424- PERFORM R0565-00-UPDATE-V0BILHETE. */

                R0565_00_UPDATE_V0BILHETE_SECTION();
            }


            /*" -2427- ADD 1 TO LB-SEXO */
            WS_AUX_WORK.LB_SEXO.Value = WS_AUX_WORK.LB_SEXO + 1;

            /*" -2427- PERFORM R2860-00-DELETE-VGCRITICA. */

            R2860_00_DELETE_VGCRITICA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0560_99_SAIDA*/

        [StopWatch]
        /*" R0565-00-UPDATE-V0BILHETE-SECTION */
        private void R0565_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -2438- MOVE '0565' TO WNR-EXEC-SQL. */
            _.Move("0565", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2440- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2445- PERFORM R0565_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R0565_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -2449- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2450- DISPLAY 'R0565-00 - PROBLEMAS UPDATE (V0BILHETE)  ' */
                _.Display($"R0565-00 - PROBLEMAS UPDATE (V0BILHETE)  ");

                /*" -2450- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0565-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R0565_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -2445- EXEC SQL UPDATE SEGUROS.V0BILHETE SET IDE_SEXO = :V0BILH-SEXO , COD_USUARIO = 'CB0009B' WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r0565_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R0565_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V0BILH_SEXO = V0BILH_SEXO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R0565_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r0565_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0565_99_SAIDA*/

        [StopWatch]
        /*" R0570-00-TRATA-CIVIL-SECTION */
        private void R0570_00_TRATA_CIVIL_SECTION()
        {
            /*" -2461- MOVE '0570' TO WNR-EXEC-SQL. */
            _.Move("0570", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2463- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2464- IF V0BILH-NUMBIL EQUAL 84603187731 */

            if (V0BILH_NUMBIL == 84603187731)
            {

                /*" -2465- MOVE 'S' TO V0BILH-ESTCIV */
                _.Move("S", V0BILH_ESTCIV);

                /*" -2468- PERFORM R0575-00-UPDATE-V0BILHETE. */

                R0575_00_UPDATE_V0BILHETE_SECTION();
            }


            /*" -2474- IF V0BILH-ESTCIV NOT EQUAL 'C' AND V0BILH-ESTCIV NOT EQUAL 'S' AND V0BILH-ESTCIV NOT EQUAL 'V' AND V0BILH-ESTCIV NOT EQUAL 'D' AND V0BILH-ESTCIV NOT EQUAL 'O' AND V0BILH-ESTCIV NOT EQUAL SPACES */

            if (V0BILH_ESTCIV != "C" && V0BILH_ESTCIV != "S" && V0BILH_ESTCIV != "V" && V0BILH_ESTCIV != "D" && V0BILH_ESTCIV != "O" && !V0BILH_ESTCIV.IsEmpty())
            {

                /*" -2475- MOVE 'S' TO V0BILH-ESTCIV */
                _.Move("S", V0BILH_ESTCIV);

                /*" -2478- PERFORM R0575-00-UPDATE-V0BILHETE. */

                R0575_00_UPDATE_V0BILHETE_SECTION();
            }


            /*" -2480- ADD 1 TO LB-CIVIL */
            WS_AUX_WORK.LB_CIVIL.Value = WS_AUX_WORK.LB_CIVIL + 1;

            /*" -2480- PERFORM R2860-00-DELETE-VGCRITICA. */

            R2860_00_DELETE_VGCRITICA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_99_SAIDA*/

        [StopWatch]
        /*" R0575-00-UPDATE-V0BILHETE-SECTION */
        private void R0575_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -2491- MOVE '0575' TO WNR-EXEC-SQL. */
            _.Move("0575", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2493- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2498- PERFORM R0575_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R0575_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -2502- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2503- DISPLAY 'R0575-00 - PROBLEMAS UPDATE (V0BILHETE)  ' */
                _.Display($"R0575-00 - PROBLEMAS UPDATE (V0BILHETE)  ");

                /*" -2503- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0575-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R0575_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -2498- EXEC SQL UPDATE SEGUROS.V0BILHETE SET ESTADO_CIVIL = :V0BILH-ESTCIV , COD_USUARIO = 'CB0009B' WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r0575_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R0575_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V0BILH_ESTCIV = V0BILH_ESTCIV.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R0575_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r0575_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0575_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-TRATA-IDADE-SECTION */
        private void R0600_00_TRATA_IDADE_SECTION()
        {
            /*" -2514- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2516- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2517- IF V0BILH-NUMBIL = 84535704403 */

            if (V0BILH_NUMBIL == 84535704403)
            {

                /*" -2519- GO TO R0600-10-LIBERA. */

                R0600_10_LIBERA(); //GOTO
                return;
            }


            /*" -2520- IF V0BILH-NUMBIL = 84536762296 */

            if (V0BILH_NUMBIL == 84536762296)
            {

                /*" -2526- GO TO R0600-10-LIBERA. */

                R0600_10_LIBERA(); //GOTO
                return;
            }


            /*" -2527- IF V0CLIE-CODCLIEN EQUAL ZEROS */

            if (V0CLIE_CODCLIEN == 00)
            {

                /*" -2528- ADD 1 TO DP-CLI1101 */
                WS_AUX_WORK.DP_CLI1101.Value = WS_AUX_WORK.DP_CLI1101 + 1;

                /*" -2530- GO TO R0600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2531- IF V0CLIE-DTNASC EQUAL SPACES */

            if (V0CLIE_DTNASC.IsEmpty())
            {

                /*" -2532- ADD 1 TO DP-DTN1101 */
                WS_AUX_WORK.DP_DTN1101.Value = WS_AUX_WORK.DP_DTN1101 + 1;

                /*" -2535- GO TO R0600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2536- MOVE V0BILH-DTQITBCO TO WDATA-QUI */
            _.Move(V0BILH_DTQITBCO, WS_AUX_WORK.WDATA_QUI);

            /*" -2537- MOVE WDAT-QUI-MES TO MMDD-QUI-MES */
            _.Move(WS_AUX_WORK.FILLER_4.WDAT_QUI_MES, WS_AUX_WORK.FILLER_10.MMDD_QUI_MES);

            /*" -2539- MOVE WDAT-QUI-DIA TO MMDD-QUI-DIA. */
            _.Move(WS_AUX_WORK.FILLER_4.WDAT_QUI_DIA, WS_AUX_WORK.FILLER_10.MMDD_QUI_DIA);

            /*" -2540- MOVE V0CLIE-DTNASC TO WDATA-NAS */
            _.Move(V0CLIE_DTNASC, WS_AUX_WORK.WDATA_NAS);

            /*" -2541- MOVE WDAT-NAS-MES TO MMDD-NAS-MES */
            _.Move(WS_AUX_WORK.FILLER_7.WDAT_NAS_MES, WS_AUX_WORK.FILLER_11.MMDD_NAS_MES);

            /*" -2544- MOVE WDAT-NAS-DIA TO MMDD-NAS-DIA. */
            _.Move(WS_AUX_WORK.FILLER_7.WDAT_NAS_DIA, WS_AUX_WORK.FILLER_11.MMDD_NAS_DIA);

            /*" -2545- MOVE ZEROS TO WS-ANOCALC. */
            _.Move(0, WS_AUX_WORK.WS_ANOCALC);

            /*" -2548- COMPUTE WS-ANOCALC EQUAL WDAT-QUI-ANO - WDAT-NAS-ANO. */
            WS_AUX_WORK.WS_ANOCALC.Value = WS_AUX_WORK.FILLER_4.WDAT_QUI_ANO - WS_AUX_WORK.FILLER_7.WDAT_NAS_ANO;

            /*" -2549- IF WS-ANOCALC LESS 14 */

            if (WS_AUX_WORK.WS_ANOCALC < 14)
            {

                /*" -2550- ADD 1 TO DP-IDADE */
                WS_AUX_WORK.DP_IDADE.Value = WS_AUX_WORK.DP_IDADE + 1;

                /*" -2552- GO TO R0600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2554- IF WS-ANOCALC EQUAL 14 AND WMMDD-QUI LESS WMMDD-NAS */

            if (WS_AUX_WORK.WS_ANOCALC == 14 && WS_AUX_WORK.WMMDD_QUI < WS_AUX_WORK.WMMDD_NAS)
            {

                /*" -2555- ADD 1 TO DP-IDADE */
                WS_AUX_WORK.DP_IDADE.Value = WS_AUX_WORK.DP_IDADE + 1;

                /*" -2557- GO TO R0600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2558- IF NOVOS-ACESSOS */

            if (NIVEIS_88.N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
            {

                /*" -2559- MOVE LK-0070-I-COD-PRODUTO TO V0BILP-CODPRODU */
                _.Move(GE0070W.LK_0070_I_COD_PRODUTO, V0BILP_CODPRODU);

                /*" -2560- ELSE */
            }
            else
            {


                /*" -2561- PERFORM R6300-00-SELECIONA-PRODUTO */

                R6300_00_SELECIONA_PRODUTO_SECTION();

                /*" -2563- END-IF */
            }


            /*" -2566- IF NOT ( V0BILP-CODPRODU EQUAL 3709 OR JVPROD(3709) OR 3729) */

            if (!(V0BILP_CODPRODU.In("3709", JVBKINCL.FILLER.JVPROD[3709].ToString(), "3729")))
            {

                /*" -2567- IF WS-ANOCALC GREATER 70 */

                if (WS_AUX_WORK.WS_ANOCALC > 70)
                {

                    /*" -2568- ADD 1 TO DP-IDADE */
                    WS_AUX_WORK.DP_IDADE.Value = WS_AUX_WORK.DP_IDADE + 1;

                    /*" -2569- GO TO R0600-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/ //GOTO
                    return;

                    /*" -2570- END-IF */
                }


                /*" -2572- IF WS-ANOCALC EQUAL 70 AND WMMDD-QUI GREATER WMMDD-NAS */

                if (WS_AUX_WORK.WS_ANOCALC == 70 && WS_AUX_WORK.WMMDD_QUI > WS_AUX_WORK.WMMDD_NAS)
                {

                    /*" -2573- ADD 1 TO DP-IDADE */
                    WS_AUX_WORK.DP_IDADE.Value = WS_AUX_WORK.DP_IDADE + 1;

                    /*" -2574- GO TO R0600-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/ //GOTO
                    return;

                    /*" -2575- END-IF */
                }


                /*" -2575- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0600_10_LIBERA */

            R0600_10_LIBERA();

        }

        [StopWatch]
        /*" R0600-10-LIBERA */
        private void R0600_10_LIBERA(bool isPerform = false)
        {
            /*" -2581- ADD 1 TO LB-IDADE */
            WS_AUX_WORK.LB_IDADE.Value = WS_AUX_WORK.LB_IDADE + 1;

            /*" -2581- PERFORM R2860-00-DELETE-VGCRITICA. */

            R2860_00_DELETE_VGCRITICA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0610-00-SELECT-V0CLIENTE-SECTION */
        private void R0610_00_SELECT_V0CLIENTE_SECTION()
        {
            /*" -2592- MOVE '0610' TO WNR-EXEC-SQL. */
            _.Move("0610", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2594- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2603- PERFORM R0610_00_SELECT_V0CLIENTE_DB_SELECT_1 */

            R0610_00_SELECT_V0CLIENTE_DB_SELECT_1();

            /*" -2606- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2607- MOVE ZEROS TO V0CLIE-CODCLIEN */
                _.Move(0, V0CLIE_CODCLIEN);

                /*" -2608- ELSE */
            }
            else
            {


                /*" -2609- IF VIND-DTNASC LESS ZEROS */

                if (VIND_DTNASC < 00)
                {

                    /*" -2610- MOVE SPACES TO V0CLIE-DTNASC */
                    _.Move("", V0CLIE_DTNASC);

                    /*" -2611- END-IF */
                }


                /*" -2615- END-IF */
            }


            /*" -2615- . */

        }

        [StopWatch]
        /*" R0610-00-SELECT-V0CLIENTE-DB-SELECT-1 */
        public void R0610_00_SELECT_V0CLIENTE_DB_SELECT_1()
        {
            /*" -2603- EXEC SQL SELECT COD_CLIENTE , NOME_RAZAO , DATA_NASCIMENTO INTO :V0CLIE-CODCLIEN , :V0CLIE-NOME , :V0CLIE-DTNASC:VIND-DTNASC FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0CLIE-CODCLIEN END-EXEC. */

            var r0610_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 = new R0610_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1()
            {
                V0CLIE_CODCLIEN = V0CLIE_CODCLIEN.ToString(),
            };

            var executed_1 = R0610_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1.Execute(r0610_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIE_CODCLIEN, V0CLIE_CODCLIEN);
                _.Move(executed_1.V0CLIE_NOME, V0CLIE_NOME);
                _.Move(executed_1.V0CLIE_DTNASC, V0CLIE_DTNASC);
                _.Move(executed_1.VIND_DTNASC, VIND_DTNASC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_99_SAIDA*/

        [StopWatch]
        /*" R0620-00-TRATA-ANO-CLIENTE-SECTION */
        private void R0620_00_TRATA_ANO_CLIENTE_SECTION()
        {
            /*" -2624- MOVE '0620' TO WNR-EXEC-SQL. */
            _.Move("0620", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2626- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2627- MOVE V0CLIE-DTNASC TO WDATA-NAS */
            _.Move(V0CLIE_DTNASC, WS_AUX_WORK.WDATA_NAS);

            /*" -2629- MOVE WDAT-NAS-ANO TO WANO-NAS */
            _.Move(WS_AUX_WORK.FILLER_7.WDAT_NAS_ANO, WS_AUX_WORK.WANO_NAS);

            /*" -2630- IF ANO-NAS-AA GREATER 30 */

            if (WS_AUX_WORK.FILLER_12.ANO_NAS_AA > 30)
            {

                /*" -2631- IF ANO-NAS-SS EQUAL 19 */

                if (WS_AUX_WORK.FILLER_12.ANO_NAS_SS == 19)
                {

                    /*" -2633- GO TO R0620-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0620_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2634- MOVE 19 TO ANO-NAS-SS */
            _.Move(19, WS_AUX_WORK.FILLER_12.ANO_NAS_SS);

            /*" -2635- MOVE WANO-NAS TO WDAT-NAS-ANO */
            _.Move(WS_AUX_WORK.WANO_NAS, WS_AUX_WORK.FILLER_7.WDAT_NAS_ANO);

            /*" -2637- MOVE WDATA-NAS TO V0CLIE-DTNASC */
            _.Move(WS_AUX_WORK.WDATA_NAS, V0CLIE_DTNASC);

            /*" -2644- PERFORM R0620_00_TRATA_ANO_CLIENTE_DB_UPDATE_1 */

            R0620_00_TRATA_ANO_CLIENTE_DB_UPDATE_1();

            /*" -2647- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2648- DISPLAY 'R0620-00 - PROBLEMAS UPDATE (V0CLIENTE)  ' */
                _.Display($"R0620-00 - PROBLEMAS UPDATE (V0CLIENTE)  ");

                /*" -2648- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0620-00-TRATA-ANO-CLIENTE-DB-UPDATE-1 */
        public void R0620_00_TRATA_ANO_CLIENTE_DB_UPDATE_1()
        {
            /*" -2644- EXEC SQL UPDATE SEGUROS.V0CLIENTE SET DATA_NASCIMENTO = :V0CLIE-DTNASC WHERE COD_CLIENTE = :V0CLIE-CODCLIEN END-EXEC. */

            var r0620_00_TRATA_ANO_CLIENTE_DB_UPDATE_1_Update1 = new R0620_00_TRATA_ANO_CLIENTE_DB_UPDATE_1_Update1()
            {
                V0CLIE_DTNASC = V0CLIE_DTNASC.ToString(),
                V0CLIE_CODCLIEN = V0CLIE_CODCLIEN.ToString(),
            };

            R0620_00_TRATA_ANO_CLIENTE_DB_UPDATE_1_Update1.Execute(r0620_00_TRATA_ANO_CLIENTE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0620_99_SAIDA*/

        [StopWatch]
        /*" R0650-00-TRATA-FILIAL-SECTION */
        private void R0650_00_TRATA_FILIAL_SECTION()
        {
            /*" -2658- MOVE '0650' TO WNR-EXEC-SQL. */
            _.Move("0650", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2660- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2662- MOVE 9999 TO WSHOST-FONTE WSHOST-AGECOBR */
            _.Move(9999, WSHOST_FONTE, WSHOST_AGECOBR);

            /*" -2665- MOVE '1' TO WSHOST-SITUACAO. */
            _.Move("1", WSHOST_SITUACAO);

            /*" -2666- SET WS-AGE TO 1 */
            WS_AGE.Value = 1;

            /*" -2667- SEARCH WACEF-OCORREAGE */
            for (; WS_AGE < WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE.Items.Count; WS_AGE.Value++)
            {

                /*" -2669- WHEN V0BILH-AGECOBR EQUAL WACEF-AGENCIA(WS-AGE) */

                if (V0BILH_AGECOBR == WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA)
                {


                    /*" -2671- MOVE WACEF-FONTE(WS-AGE) TO WSHOST-FONTE */
                    _.Move(WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_FONTE, WSHOST_FONTE);

                    /*" -2673- MOVE WACEF-AGENCIA(WS-AGE) TO WSHOST-AGECOBR */
                    _.Move(WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA, WSHOST_AGECOBR);

                    /*" -2674- MOVE WACEF-SITUACAO(WS-AGE) TO WSHOST-SITUACAO  END-SEARCH. */
                    break;
                }
            }


            /*" -2678- IF WSHOST-SITUACAO NOT EQUAL '0' */

            if (WSHOST_SITUACAO != "0")
            {

                /*" -2679- PERFORM R0655-00-TRATA-AGECOBR */

                R0655_00_TRATA_AGECOBR_SECTION();

                /*" -2682- GO TO R0650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2685- IF V0BILH-FONTE EQUAL WSHOST-FONTE AND V0BILH-AGECOBR EQUAL WSHOST-AGECOBR NEXT SENTENCE */

            if (V0BILH_FONTE == WSHOST_FONTE && V0BILH_AGECOBR == WSHOST_AGECOBR)
            {

                /*" -2686- ELSE */
            }
            else
            {


                /*" -2687- ADD 1 TO UP-FILIAL */
                WS_AUX_WORK.UP_FILIAL.Value = WS_AUX_WORK.UP_FILIAL + 1;

                /*" -2690- PERFORM R2000-00-UPDATE-V0BILHETE. */

                R2000_00_UPDATE_V0BILHETE_SECTION();
            }


            /*" -2691- IF V0BILH-AGECOBR NOT EQUAL V0CFEN-AGECOBR */

            if (V0BILH_AGECOBR != V0CFEN_AGECOBR)
            {

                /*" -2694- PERFORM R2100-00-UPDATE-V0COFENAE. */

                R2100_00_UPDATE_V0COFENAE_SECTION();
            }


            /*" -2696- ADD 1 TO LB-FILIAL */
            WS_AUX_WORK.LB_FILIAL.Value = WS_AUX_WORK.LB_FILIAL + 1;

            /*" -2696- PERFORM R2860-00-DELETE-VGCRITICA. */

            R2860_00_DELETE_VGCRITICA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_99_SAIDA*/

        [StopWatch]
        /*" R0655-00-TRATA-AGECOBR-SECTION */
        private void R0655_00_TRATA_AGECOBR_SECTION()
        {
            /*" -2707- MOVE '0655' TO WNR-EXEC-SQL. */
            _.Move("0655", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2709- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2711- MOVE 9999 TO WSHOST-FONTE WSHOST-AGECOBR */
            _.Move(9999, WSHOST_FONTE, WSHOST_AGECOBR);

            /*" -2714- MOVE '1' TO WSHOST-SITUACAO. */
            _.Move("1", WSHOST_SITUACAO);

            /*" -2715- SET WS-AGE TO 1 */
            WS_AGE.Value = 1;

            /*" -2716- SEARCH WACEF-OCORREAGE */
            for (; WS_AGE < WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE.Items.Count; WS_AGE.Value++)
            {

                /*" -2718- WHEN V0CFEN-AGECOBR EQUAL WACEF-AGENCIA(WS-AGE) */

                if (V0CFEN_AGECOBR == WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA)
                {


                    /*" -2720- MOVE WACEF-FONTE(WS-AGE) TO WSHOST-FONTE */
                    _.Move(WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_FONTE, WSHOST_FONTE);

                    /*" -2722- MOVE WACEF-AGENCIA(WS-AGE) TO WSHOST-AGECOBR */
                    _.Move(WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA, WSHOST_AGECOBR);

                    /*" -2723- MOVE WACEF-SITUACAO(WS-AGE) TO WSHOST-SITUACAO  END-SEARCH. */
                    break;
                }
            }


            /*" -2726- IF WSHOST-SITUACAO NOT EQUAL '0' */

            if (WSHOST_SITUACAO != "0")
            {

                /*" -2727- IF V0BILH-RAMO EQUAL 81 OR 82 */

                if (V0BILH_RAMO.In("81", "82"))
                {

                    /*" -2729- ADD 1 TO LB-FILIAL */
                    WS_AUX_WORK.LB_FILIAL.Value = WS_AUX_WORK.LB_FILIAL + 1;

                    /*" -2730- PERFORM R2860-00-DELETE-VGCRITICA */

                    R2860_00_DELETE_VGCRITICA_SECTION();

                    /*" -2731- ELSE */
                }
                else
                {


                    /*" -2732- ADD 1 TO DP-FILIAL */
                    WS_AUX_WORK.DP_FILIAL.Value = WS_AUX_WORK.DP_FILIAL + 1;

                    /*" -2735- GO TO R0655-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0655_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2738- IF V0BILH-FONTE EQUAL WSHOST-FONTE AND V0BILH-AGECOBR EQUAL WSHOST-AGECOBR NEXT SENTENCE */

            if (V0BILH_FONTE == WSHOST_FONTE && V0BILH_AGECOBR == WSHOST_AGECOBR)
            {

                /*" -2739- ELSE */
            }
            else
            {


                /*" -2740- ADD 1 TO UP-FILIAL */
                WS_AUX_WORK.UP_FILIAL.Value = WS_AUX_WORK.UP_FILIAL + 1;

                /*" -2743- PERFORM R2000-00-UPDATE-V0BILHETE. */

                R2000_00_UPDATE_V0BILHETE_SECTION();
            }


            /*" -2745- ADD 1 TO LB-FILIAL */
            WS_AUX_WORK.LB_FILIAL.Value = WS_AUX_WORK.LB_FILIAL + 1;

            /*" -2745- PERFORM R2860-00-DELETE-VGCRITICA. */

            R2860_00_DELETE_VGCRITICA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0655_99_SAIDA*/

        [StopWatch]
        /*" R0660-00-TRATA-RENDA-SECTION */
        private void R0660_00_TRATA_RENDA_SECTION()
        {
            /*" -2756- MOVE '0660' TO WNR-EXEC-SQL. */
            _.Move("0660", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2758- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2760- IF V0BILH-FX-RENDA-IND LESS 1 OR V0BILH-FX-RENDA-IND GREATER 5 */

            if (V0BILH_FX_RENDA_IND < 1 || V0BILH_FX_RENDA_IND > 5)
            {

                /*" -2762- IF V0BILH-FX-RENDA-FAM GREATER 0 AND V0BILH-FX-RENDA-FAM LESS 6 */

                if (V0BILH_FX_RENDA_FAM > 0 && V0BILH_FX_RENDA_FAM < 6)
                {

                    /*" -2764- MOVE V0BILH-FX-RENDA-FAM TO V0BILH-FX-RENDA-IND */
                    _.Move(V0BILH_FX_RENDA_FAM, V0BILH_FX_RENDA_IND);

                    /*" -2765- ELSE */
                }
                else
                {


                    /*" -2768- MOVE 1 TO V0BILH-FX-RENDA-IND V0BILH-FX-RENDA-FAM */
                    _.Move(1, V0BILH_FX_RENDA_IND, V0BILH_FX_RENDA_FAM);

                    /*" -2769- ELSE */
                }

            }
            else
            {


                /*" -2771- IF V0BILH-FX-RENDA-FAM LESS 1 OR V0BILH-FX-RENDA-FAM GREATER 5 */

                if (V0BILH_FX_RENDA_FAM < 1 || V0BILH_FX_RENDA_FAM > 5)
                {

                    /*" -2775- MOVE V0BILH-FX-RENDA-IND TO V0BILH-FX-RENDA-FAM. */
                    _.Move(V0BILH_FX_RENDA_IND, V0BILH_FX_RENDA_FAM);
                }

            }


            /*" -2778- PERFORM R0665-00-UPDATE-V0BILHETE. */

            R0665_00_UPDATE_V0BILHETE_SECTION();

            /*" -2780- ADD 1 TO LB-RENDA. */
            WS_AUX_WORK.LB_RENDA.Value = WS_AUX_WORK.LB_RENDA + 1;

            /*" -2780- PERFORM R2860-00-DELETE-VGCRITICA. */

            R2860_00_DELETE_VGCRITICA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0660_99_SAIDA*/

        [StopWatch]
        /*" R0665-00-UPDATE-V0BILHETE-SECTION */
        private void R0665_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -2791- MOVE '0665' TO WNR-EXEC-SQL. */
            _.Move("0665", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2793- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2798- PERFORM R0665_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R0665_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -2802- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2803- DISPLAY 'R0665-00 - PROBLEMAS UPDATE (V0BILHETE)  ' */
                _.Display($"R0665-00 - PROBLEMAS UPDATE (V0BILHETE)  ");

                /*" -2803- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0665-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R0665_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -2798- EXEC SQL UPDATE SEGUROS.V0BILHETE SET BI_FAIXA_RENDA_IND = :V0BILH-FX-RENDA-IND, BI_FAIXA_RENDA_FAM = :V0BILH-FX-RENDA-FAM WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r0665_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R0665_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V0BILH_FX_RENDA_IND = V0BILH_FX_RENDA_IND.ToString(),
                V0BILH_FX_RENDA_FAM = V0BILH_FX_RENDA_FAM.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R0665_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r0665_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0665_99_SAIDA*/

        [StopWatch]
        /*" R0670-00-TRATA-PROFISSAO-SECTION */
        private void R0670_00_TRATA_PROFISSAO_SECTION()
        {
            /*" -2814- MOVE '0670' TO WNR-EXEC-SQL. */
            _.Move("0670", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2833- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2834- IF V0ERRO-CODERRO EQUAL 11803 */

            if (V0ERRO_CODERRO == 11803)
            {

                /*" -2835- ADD 1 TO AC-ERR1803 */
                WS_AUX_WORK.AC_ERR1803.Value = WS_AUX_WORK.AC_ERR1803 + 1;

                /*" -2837- ELSE */
            }
            else
            {


                /*" -2838- IF V0ERRO-CODERRO EQUAL 11811 */

                if (V0ERRO_CODERRO == 11811)
                {

                    /*" -2841- ADD 1 TO AC-ERR1811. */
                    WS_AUX_WORK.AC_ERR1811.Value = WS_AUX_WORK.AC_ERR1811 + 1;
                }

            }


            /*" -2843- IF V0BILH-PROFISSAO (1:4) EQUAL SPACES OR V0BILH-NUMBIL EQUAL 84602174016 */

            if (V0BILH_PROFISSAO.Substring(1, 4) == string.Empty || V0BILH_NUMBIL == 84602174016)
            {

                /*" -2844- MOVE ZEROS TO WERRO-UPDT */
                _.Move(0, WS_AUX_WORK.WERRO_UPDT);

                /*" -2845- MOVE 'OUTROS' TO V0BILH-PROFISSAO */
                _.Move("OUTROS", V0BILH_PROFISSAO);

                /*" -2846- PERFORM R2230-00-UPDATE-V0BILHETE */

                R2230_00_UPDATE_V0BILHETE_SECTION();

                /*" -2847- IF WERRO-UPDT NOT EQUAL ZEROS */

                if (WS_AUX_WORK.WERRO_UPDT != 00)
                {

                    /*" -2848- PERFORM R0710-00-DESPREZA-ERROS */

                    R0710_00_DESPREZA_ERROS_SECTION();

                    /*" -2851- GO TO R0670-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0670_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2851- PERFORM R0730-00-DELETA-ERROS. */

            R0730_00_DELETA_ERROS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0670_99_SAIDA*/

        [StopWatch]
        /*" R0680-00-CALCULA-DIAS-SECTION */
        private void R0680_00_CALCULA_DIAS_SECTION()
        {
            /*" -2862- MOVE '0680' TO WNR-EXEC-SQL. */
            _.Move("0680", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2864- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2865- MOVE V0SIST-DTMOVABE TO WDATA-REL */
            _.Move(V0SIST_DTMOVABE, WS_AUX_WORK.WDATA_REL);

            /*" -2866- MOVE WDAT-REL-DIA TO LPARM01-DD */
            _.Move(WS_AUX_WORK.FILLER_1.WDAT_REL_DIA, WS_AGENCIACEF.LPARM.LPARM01.LPARM01_DD);

            /*" -2867- MOVE WDAT-REL-MES TO LPARM01-MM */
            _.Move(WS_AUX_WORK.FILLER_1.WDAT_REL_MES, WS_AGENCIACEF.LPARM.LPARM01.LPARM01_MM);

            /*" -2869- MOVE WDAT-REL-ANO TO LPARM01-AA. */
            _.Move(WS_AUX_WORK.FILLER_1.WDAT_REL_ANO, WS_AGENCIACEF.LPARM.LPARM01.LPARM01_AA);

            /*" -2870- MOVE V0BILH-DTQITBCO TO WDATA-REL */
            _.Move(V0BILH_DTQITBCO, WS_AUX_WORK.WDATA_REL);

            /*" -2871- MOVE WDAT-REL-DIA TO LPARM02-DD */
            _.Move(WS_AUX_WORK.FILLER_1.WDAT_REL_DIA, WS_AGENCIACEF.LPARM.LPARM02.LPARM02_DD);

            /*" -2872- MOVE WDAT-REL-MES TO LPARM02-MM */
            _.Move(WS_AUX_WORK.FILLER_1.WDAT_REL_MES, WS_AGENCIACEF.LPARM.LPARM02.LPARM02_MM);

            /*" -2874- MOVE WDAT-REL-ANO TO LPARM02-AA. */
            _.Move(WS_AUX_WORK.FILLER_1.WDAT_REL_ANO, WS_AGENCIACEF.LPARM.LPARM02.LPARM02_AA);

            /*" -2876- MOVE ZEROS TO LPARM03. */
            _.Move(0, WS_AGENCIACEF.LPARM.LPARM03);

            /*" -2879- CALL 'PRODIFC1' USING LPARM. */
            _.Call("PRODIFC1", WS_AGENCIACEF.LPARM);

            /*" -2880- IF LPARM03 GREATER 15 */

            if (WS_AGENCIACEF.LPARM.LPARM03 > 15)
            {

                /*" -2881- PERFORM R0730-00-DELETA-ERROS */

                R0730_00_DELETA_ERROS_SECTION();

                /*" -2882- ELSE */
            }
            else
            {


                /*" -2882- PERFORM R0710-00-DESPREZA-ERROS. */

                R0710_00_DESPREZA_ERROS_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0680_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-TRATA-ERROS-SECTION */
        private void R0700_00_TRATA_ERROS_SECTION()
        {
            /*" -2893- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2925- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2926- IF V0ERRO-CODERRO EQUAL 11501 */

            if (V0ERRO_CODERRO == 11501)
            {

                /*" -2927- ADD 1 TO AC-ERR1501 */
                WS_AUX_WORK.AC_ERR1501.Value = WS_AUX_WORK.AC_ERR1501 + 1;

                /*" -2928- ELSE */
            }
            else
            {


                /*" -2929- IF V0ERRO-CODERRO EQUAL 11502 */

                if (V0ERRO_CODERRO == 11502)
                {

                    /*" -2930- ADD 1 TO AC-ERR1502 */
                    WS_AUX_WORK.AC_ERR1502.Value = WS_AUX_WORK.AC_ERR1502 + 1;

                    /*" -2931- ELSE */
                }
                else
                {


                    /*" -2932- IF V0ERRO-CODERRO EQUAL 1503 */

                    if (V0ERRO_CODERRO == 1503)
                    {

                        /*" -2933- ADD 1 TO AC-ERR1503 */
                        WS_AUX_WORK.AC_ERR1503.Value = WS_AUX_WORK.AC_ERR1503 + 1;

                        /*" -2934- ELSE */
                    }
                    else
                    {


                        /*" -2935- IF V0ERRO-CODERRO EQUAL 1602 */

                        if (V0ERRO_CODERRO == 1602)
                        {

                            /*" -2936- ADD 1 TO AC-DAT1602 */
                            WS_AUX_WORK.AC_DAT1602.Value = WS_AUX_WORK.AC_DAT1602 + 1;

                            /*" -2937- ELSE */
                        }
                        else
                        {


                            /*" -2938- IF V0ERRO-CODERRO EQUAL 11801 */

                            if (V0ERRO_CODERRO == 11801)
                            {

                                /*" -2939- ADD 1 TO AC-ERR1801 */
                                WS_AUX_WORK.AC_ERR1801.Value = WS_AUX_WORK.AC_ERR1801 + 1;

                                /*" -2940- ELSE */
                            }
                            else
                            {


                                /*" -2941- IF V0ERRO-CODERRO EQUAL 11802 */

                                if (V0ERRO_CODERRO == 11802)
                                {

                                    /*" -2942- ADD 1 TO AC-ERR1802 */
                                    WS_AUX_WORK.AC_ERR1802.Value = WS_AUX_WORK.AC_ERR1802 + 1;

                                    /*" -2943- ELSE */
                                }
                                else
                                {


                                    /*" -2944- IF V0ERRO-CODERRO EQUAL 11901 */

                                    if (V0ERRO_CODERRO == 11901)
                                    {

                                        /*" -2945- ADD 1 TO AC-DAT1901 */
                                        WS_AUX_WORK.AC_DAT1901.Value = WS_AUX_WORK.AC_DAT1901 + 1;

                                        /*" -2946- ELSE */
                                    }
                                    else
                                    {


                                        /*" -2947- IF V0ERRO-CODERRO EQUAL 12101 */

                                        if (V0ERRO_CODERRO == 12101)
                                        {

                                            /*" -2948- ADD 1 TO AC-ERR2101 */
                                            WS_AUX_WORK.AC_ERR2101.Value = WS_AUX_WORK.AC_ERR2101 + 1;

                                            /*" -2949- ELSE */
                                        }
                                        else
                                        {


                                            /*" -2950- IF V0ERRO-CODERRO EQUAL 12102 */

                                            if (V0ERRO_CODERRO == 12102)
                                            {

                                                /*" -2951- ADD 1 TO AC-ERR2102 */
                                                WS_AUX_WORK.AC_ERR2102.Value = WS_AUX_WORK.AC_ERR2102 + 1;

                                                /*" -2952- ELSE */
                                            }
                                            else
                                            {


                                                /*" -2954- GO TO R0700-99-SAIDA. */
                                                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/ //GOTO
                                                return;
                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -2957- COMPUTE V0BCOB-VLPRMTOT1 EQUAL V0RCAP-VLRCAP - WS-VLDIFE. */
            V0BCOB_VLPRMTOT1.Value = V0RCAP_VLRCAP - WS_AUX_WORK.WS_VLDIFE;

            /*" -2960- COMPUTE V0BCOB-VLPRMTOT2 EQUAL V0RCAP-VLRCAP + WS-VLDIFE. */
            V0BCOB_VLPRMTOT2.Value = V0RCAP_VLRCAP + WS_AUX_WORK.WS_VLDIFE;

            /*" -2962- IF (VIND-COD-PRODUTO LESS ZEROS) OR (V0BILH-COD-PRODUTO EQUAL ZEROS) */

            if ((VIND_COD_PRODUTO < 00) || (V0BILH_COD_PRODUTO == 00))
            {

                /*" -2963- PERFORM R0900-00-SELECT-V0COBERTURA */

                R0900_00_SELECT_V0COBERTURA_SECTION();

                /*" -2964- ELSE */
            }
            else
            {


                /*" -2965- IF NOVOS-ACESSOS */

                if (NIVEIS_88.N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
                {

                    /*" -2966- DISPLAY 'NOVOS ACESSOS-1: ' N88-NOVOS-ACESSOS */
                    _.Display($"NOVOS ACESSOS-1: {NIVEIS_88.N88_NOVOS_ACESSOS}");

                    /*" -2967- MOVE 'S' TO FLAG-COBERT */
                    _.Move("S", WS_AUX_WORK.FLAG_COBERT);

                    /*" -2969- MOVE LK-0071-I-COD-OPC-PLANO TO V0BCOB-CODOPCAO */
                    _.Move(GE0071W.LK_0071_I_COD_OPC_PLANO, V0BCOB_CODOPCAO);

                    /*" -2970- MOVE V0BILH-DTVENDA TO V0BCOB-DTINIVIG */
                    _.Move(V0BILH_DTVENDA, V0BCOB_DTINIVIG);

                    /*" -2972- MOVE LK-0071-S-VLR-INI-PREMIO TO V0BCOB-VLPRMTOT */
                    _.Move(GE0071W.LK_0071_S_VLR_INI_PREMIO, V0BCOB_VLPRMTOT);

                    /*" -2973- ELSE */
                }
                else
                {


                    /*" -2974- DISPLAY 'R0940-00 (1)' */
                    _.Display($"R0940-00 (1)");

                    /*" -2975- PERFORM R0940-00-SELECT-V0COBERTURA */

                    R0940_00_SELECT_V0COBERTURA_SECTION();

                    /*" -2976- END-IF */
                }


                /*" -2997- END-IF */
            }


            /*" -2998- IF V0BILH-OPCOBER NOT EQUAL V0BCOB-CODOPCAO */

            if (V0BILH_OPCOBER != V0BCOB_CODOPCAO)
            {

                /*" -2999- DISPLAY '-------------- ATENCAO ---------------' */
                _.Display($"-------------- ATENCAO ---------------");

                /*" -3000- DISPLAY '-------------- ATENCAO ---------------' */
                _.Display($"-------------- ATENCAO ---------------");

                /*" -3001- DISPLAY '-------------- ATENCAO ---------------' */
                _.Display($"-------------- ATENCAO ---------------");

                /*" -3002- DISPLAY 'TROCOU A OPCAO DE COBERTURA DO BILHETE' */
                _.Display($"TROCOU A OPCAO DE COBERTURA DO BILHETE");

                /*" -3003- DISPLAY 'PARAGRAFO: R0700-00-TRATA-ERROS       ' */
                _.Display($"PARAGRAFO: R0700-00-TRATA-ERROS       ");

                /*" -3004- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -3005- DISPLAY '------------- VERIFICAR --------------' */
                _.Display($"------------- VERIFICAR --------------");

                /*" -3007- END-IF */
            }


            /*" -3011- IF V0BILH-OPCOBER NOT EQUAL V0BCOB-CODOPCAO OR V0BILH-DTQITBCO NOT EQUAL V0RCOM-DATARCAP OR V0BILH-DTVENDA NOT EQUAL V0RCOM-DATARCAP OR V0BILH-VLRCAP NOT EQUAL V0BCOB-VLPRMTOT */

            if (V0BILH_OPCOBER != V0BCOB_CODOPCAO || V0BILH_DTQITBCO != V0RCOM_DATARCAP || V0BILH_DTVENDA != V0RCOM_DATARCAP || V0BILH_VLRCAP != V0BCOB_VLPRMTOT)
            {

                /*" -3013- PERFORM R0720-00-ALTERA-BILHETE. */

                R0720_00_ALTERA_BILHETE_SECTION();
            }


            /*" -3013- PERFORM R0730-00-DELETA-ERROS. */

            R0730_00_DELETA_ERROS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0710-00-DESPREZA-ERROS-SECTION */
        private void R0710_00_DESPREZA_ERROS_SECTION()
        {
            /*" -3024- MOVE '0710' TO WNR-EXEC-SQL. */
            _.Move("0710", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3026- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3027- IF V0ERRO-CODERRO EQUAL 11501 */

            if (V0ERRO_CODERRO == 11501)
            {

                /*" -3028- ADD 1 TO DP-ERR1501 */
                WS_AUX_WORK.DP_ERR1501.Value = WS_AUX_WORK.DP_ERR1501 + 1;

                /*" -3029- ELSE */
            }
            else
            {


                /*" -3030- IF V0ERRO-CODERRO EQUAL 11502 */

                if (V0ERRO_CODERRO == 11502)
                {

                    /*" -3031- ADD 1 TO DP-ERR1502 */
                    WS_AUX_WORK.DP_ERR1502.Value = WS_AUX_WORK.DP_ERR1502 + 1;

                    /*" -3032- ELSE */
                }
                else
                {


                    /*" -3033- IF V0ERRO-CODERRO EQUAL 1503 */

                    if (V0ERRO_CODERRO == 1503)
                    {

                        /*" -3034- ADD 1 TO DP-ERR1503 */
                        WS_AUX_WORK.DP_ERR1503.Value = WS_AUX_WORK.DP_ERR1503 + 1;

                        /*" -3035- ELSE */
                    }
                    else
                    {


                        /*" -3036- IF V0ERRO-CODERRO EQUAL 1602 */

                        if (V0ERRO_CODERRO == 1602)
                        {

                            /*" -3037- ADD 1 TO DP-DAT1602 */
                            WS_AUX_WORK.DP_DAT1602.Value = WS_AUX_WORK.DP_DAT1602 + 1;

                            /*" -3038- ELSE */
                        }
                        else
                        {


                            /*" -3039- IF V0ERRO-CODERRO EQUAL 11801 */

                            if (V0ERRO_CODERRO == 11801)
                            {

                                /*" -3040- ADD 1 TO DP-ERR1801 */
                                WS_AUX_WORK.DP_ERR1801.Value = WS_AUX_WORK.DP_ERR1801 + 1;

                                /*" -3041- ELSE */
                            }
                            else
                            {


                                /*" -3042- IF V0ERRO-CODERRO EQUAL 11802 */

                                if (V0ERRO_CODERRO == 11802)
                                {

                                    /*" -3043- ADD 1 TO DP-ERR1802 */
                                    WS_AUX_WORK.DP_ERR1802.Value = WS_AUX_WORK.DP_ERR1802 + 1;

                                    /*" -3044- ELSE */
                                }
                                else
                                {


                                    /*" -3045- IF V0ERRO-CODERRO EQUAL 11803 */

                                    if (V0ERRO_CODERRO == 11803)
                                    {

                                        /*" -3046- ADD 1 TO DP-ERR1803 */
                                        WS_AUX_WORK.DP_ERR1803.Value = WS_AUX_WORK.DP_ERR1803 + 1;

                                        /*" -3047- ELSE */
                                    }
                                    else
                                    {


                                        /*" -3048- IF V0ERRO-CODERRO EQUAL 11811 */

                                        if (V0ERRO_CODERRO == 11811)
                                        {

                                            /*" -3049- ADD 1 TO DP-ERR1811 */
                                            WS_AUX_WORK.DP_ERR1811.Value = WS_AUX_WORK.DP_ERR1811 + 1;

                                            /*" -3050- ELSE */
                                        }
                                        else
                                        {


                                            /*" -3051- IF V0ERRO-CODERRO EQUAL 11901 */

                                            if (V0ERRO_CODERRO == 11901)
                                            {

                                                /*" -3052- ADD 1 TO DP-DAT1901 */
                                                WS_AUX_WORK.DP_DAT1901.Value = WS_AUX_WORK.DP_DAT1901 + 1;

                                                /*" -3053- ELSE */
                                            }
                                            else
                                            {


                                                /*" -3054- IF V0ERRO-CODERRO EQUAL 12101 */

                                                if (V0ERRO_CODERRO == 12101)
                                                {

                                                    /*" -3055- ADD 1 TO DP-ERR2101 */
                                                    WS_AUX_WORK.DP_ERR2101.Value = WS_AUX_WORK.DP_ERR2101 + 1;

                                                    /*" -3056- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -3057- IF V0ERRO-CODERRO EQUAL 12102 */

                                                    if (V0ERRO_CODERRO == 12102)
                                                    {

                                                        /*" -3057- ADD 1 TO DP-ERR2102. */
                                                        WS_AUX_WORK.DP_ERR2102.Value = WS_AUX_WORK.DP_ERR2102 + 1;
                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_99_SAIDA*/

        [StopWatch]
        /*" R0720-00-ALTERA-BILHETE-SECTION */
        private void R0720_00_ALTERA_BILHETE_SECTION()
        {
            /*" -3101- MOVE '0720' TO WNR-EXEC-SQL. */
            _.Move("0720", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3103- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3104- IF V0ERRO-CODERRO EQUAL 11501 */

            if (V0ERRO_CODERRO == 11501)
            {

                /*" -3105- ADD 1 TO UP-ERR1501 */
                WS_AUX_WORK.UP_ERR1501.Value = WS_AUX_WORK.UP_ERR1501 + 1;

                /*" -3106- ELSE */
            }
            else
            {


                /*" -3107- IF V0ERRO-CODERRO EQUAL 11502 */

                if (V0ERRO_CODERRO == 11502)
                {

                    /*" -3108- ADD 1 TO UP-ERR1502 */
                    WS_AUX_WORK.UP_ERR1502.Value = WS_AUX_WORK.UP_ERR1502 + 1;

                    /*" -3109- ELSE */
                }
                else
                {


                    /*" -3110- IF V0ERRO-CODERRO EQUAL 1503 */

                    if (V0ERRO_CODERRO == 1503)
                    {

                        /*" -3111- ADD 1 TO UP-ERR1503 */
                        WS_AUX_WORK.UP_ERR1503.Value = WS_AUX_WORK.UP_ERR1503 + 1;

                        /*" -3112- ELSE */
                    }
                    else
                    {


                        /*" -3113- IF V0ERRO-CODERRO EQUAL 1602 */

                        if (V0ERRO_CODERRO == 1602)
                        {

                            /*" -3114- ADD 1 TO UP-DAT1602 */
                            WS_AUX_WORK.UP_DAT1602.Value = WS_AUX_WORK.UP_DAT1602 + 1;

                            /*" -3115- ELSE */
                        }
                        else
                        {


                            /*" -3116- IF V0ERRO-CODERRO EQUAL 11801 */

                            if (V0ERRO_CODERRO == 11801)
                            {

                                /*" -3117- ADD 1 TO UP-ERR1801 */
                                WS_AUX_WORK.UP_ERR1801.Value = WS_AUX_WORK.UP_ERR1801 + 1;

                                /*" -3118- ELSE */
                            }
                            else
                            {


                                /*" -3119- IF V0ERRO-CODERRO EQUAL 11802 */

                                if (V0ERRO_CODERRO == 11802)
                                {

                                    /*" -3120- ADD 1 TO UP-ERR1802 */
                                    WS_AUX_WORK.UP_ERR1802.Value = WS_AUX_WORK.UP_ERR1802 + 1;

                                    /*" -3121- ELSE */
                                }
                                else
                                {


                                    /*" -3122- IF V0ERRO-CODERRO EQUAL 11803 */

                                    if (V0ERRO_CODERRO == 11803)
                                    {

                                        /*" -3123- ADD 1 TO UP-ERR1803 */
                                        WS_AUX_WORK.UP_ERR1803.Value = WS_AUX_WORK.UP_ERR1803 + 1;

                                        /*" -3124- ELSE */
                                    }
                                    else
                                    {


                                        /*" -3125- IF V0ERRO-CODERRO EQUAL 11811 */

                                        if (V0ERRO_CODERRO == 11811)
                                        {

                                            /*" -3126- ADD 1 TO UP-ERR1811 */
                                            WS_AUX_WORK.UP_ERR1811.Value = WS_AUX_WORK.UP_ERR1811 + 1;

                                            /*" -3127- ELSE */
                                        }
                                        else
                                        {


                                            /*" -3128- IF V0ERRO-CODERRO EQUAL 11901 */

                                            if (V0ERRO_CODERRO == 11901)
                                            {

                                                /*" -3129- ADD 1 TO UP-DAT1901 */
                                                WS_AUX_WORK.UP_DAT1901.Value = WS_AUX_WORK.UP_DAT1901 + 1;

                                                /*" -3130- ELSE */
                                            }
                                            else
                                            {


                                                /*" -3131- IF V0ERRO-CODERRO EQUAL 12101 */

                                                if (V0ERRO_CODERRO == 12101)
                                                {

                                                    /*" -3132- ADD 1 TO UP-ERR2101 */
                                                    WS_AUX_WORK.UP_ERR2101.Value = WS_AUX_WORK.UP_ERR2101 + 1;

                                                    /*" -3133- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -3168- ADD 1 TO UP-ERR2102. */
                                                    WS_AUX_WORK.UP_ERR2102.Value = WS_AUX_WORK.UP_ERR2102 + 1;
                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -3168- PERFORM R2250-00-UPDATE-V0BILHETE. */

            R2250_00_UPDATE_V0BILHETE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0720_99_SAIDA*/

        [StopWatch]
        /*" R0730-00-DELETA-ERROS-SECTION */
        private void R0730_00_DELETA_ERROS_SECTION()
        {
            /*" -3179- MOVE '0730' TO WNR-EXEC-SQL. */
            _.Move("0730", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3181- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3182- IF V0ERRO-CODERRO EQUAL 11501 */

            if (V0ERRO_CODERRO == 11501)
            {

                /*" -3183- ADD 1 TO LB-ERR1501 */
                WS_AUX_WORK.LB_ERR1501.Value = WS_AUX_WORK.LB_ERR1501 + 1;

                /*" -3184- ELSE */
            }
            else
            {


                /*" -3185- IF V0ERRO-CODERRO EQUAL 11502 */

                if (V0ERRO_CODERRO == 11502)
                {

                    /*" -3186- ADD 1 TO LB-ERR1502 */
                    WS_AUX_WORK.LB_ERR1502.Value = WS_AUX_WORK.LB_ERR1502 + 1;

                    /*" -3187- ELSE */
                }
                else
                {


                    /*" -3188- IF V0ERRO-CODERRO EQUAL 1503 */

                    if (V0ERRO_CODERRO == 1503)
                    {

                        /*" -3189- ADD 1 TO LB-ERR1503 */
                        WS_AUX_WORK.LB_ERR1503.Value = WS_AUX_WORK.LB_ERR1503 + 1;

                        /*" -3190- ELSE */
                    }
                    else
                    {


                        /*" -3191- IF V0ERRO-CODERRO EQUAL 1602 */

                        if (V0ERRO_CODERRO == 1602)
                        {

                            /*" -3192- ADD 1 TO LB-DAT1602 */
                            WS_AUX_WORK.LB_DAT1602.Value = WS_AUX_WORK.LB_DAT1602 + 1;

                            /*" -3193- ELSE */
                        }
                        else
                        {


                            /*" -3194- IF V0ERRO-CODERRO EQUAL 11801 */

                            if (V0ERRO_CODERRO == 11801)
                            {

                                /*" -3195- ADD 1 TO LB-ERR1801 */
                                WS_AUX_WORK.LB_ERR1801.Value = WS_AUX_WORK.LB_ERR1801 + 1;

                                /*" -3196- ELSE */
                            }
                            else
                            {


                                /*" -3197- IF V0ERRO-CODERRO EQUAL 11802 */

                                if (V0ERRO_CODERRO == 11802)
                                {

                                    /*" -3198- ADD 1 TO LB-ERR1802 */
                                    WS_AUX_WORK.LB_ERR1802.Value = WS_AUX_WORK.LB_ERR1802 + 1;

                                    /*" -3199- ELSE */
                                }
                                else
                                {


                                    /*" -3200- IF V0ERRO-CODERRO EQUAL 11803 */

                                    if (V0ERRO_CODERRO == 11803)
                                    {

                                        /*" -3201- ADD 1 TO LB-ERR1803 */
                                        WS_AUX_WORK.LB_ERR1803.Value = WS_AUX_WORK.LB_ERR1803 + 1;

                                        /*" -3202- ELSE */
                                    }
                                    else
                                    {


                                        /*" -3203- IF V0ERRO-CODERRO EQUAL 11811 */

                                        if (V0ERRO_CODERRO == 11811)
                                        {

                                            /*" -3204- ADD 1 TO LB-ERR1811 */
                                            WS_AUX_WORK.LB_ERR1811.Value = WS_AUX_WORK.LB_ERR1811 + 1;

                                            /*" -3205- ELSE */
                                        }
                                        else
                                        {


                                            /*" -3206- IF V0ERRO-CODERRO EQUAL 11901 */

                                            if (V0ERRO_CODERRO == 11901)
                                            {

                                                /*" -3207- ADD 1 TO LB-DAT1901 */
                                                WS_AUX_WORK.LB_DAT1901.Value = WS_AUX_WORK.LB_DAT1901 + 1;

                                                /*" -3208- ELSE */
                                            }
                                            else
                                            {


                                                /*" -3209- IF V0ERRO-CODERRO EQUAL 12101 */

                                                if (V0ERRO_CODERRO == 12101)
                                                {

                                                    /*" -3210- ADD 1 TO LB-ERR2101 */
                                                    WS_AUX_WORK.LB_ERR2101.Value = WS_AUX_WORK.LB_ERR2101 + 1;

                                                    /*" -3211- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -3247- ADD 1 TO LB-ERR2102. */
                                                    WS_AUX_WORK.LB_ERR2102.Value = WS_AUX_WORK.LB_ERR2102 + 1;
                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -3247- PERFORM R2860-00-DELETE-VGCRITICA. */

            R2860_00_DELETE_VGCRITICA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0730_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-SELECT-V0COBERTURA-SECTION */
        private void R0900_00_SELECT_V0COBERTURA_SECTION()
        {
            /*" -3258- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3260- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3276- PERFORM R0900_00_SELECT_V0COBERTURA_DB_SELECT_1 */

            R0900_00_SELECT_V0COBERTURA_DB_SELECT_1();

            /*" -3279- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3280- PERFORM R0910-00-SELECT-V0COBERTURA */

                R0910_00_SELECT_V0COBERTURA_SECTION();

                /*" -3281- GO TO R0900-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/ //GOTO
                return;

                /*" -3282- ELSE */
            }
            else
            {


                /*" -3283- IF VIND-VLPRMTOT LESS ZEROS */

                if (VIND_VLPRMTOT < 00)
                {

                    /*" -3284- PERFORM R0910-00-SELECT-V0COBERTURA */

                    R0910_00_SELECT_V0COBERTURA_SECTION();

                    /*" -3287- GO TO R0900-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -3287- MOVE 'S' TO FLAG-COBERT. */
            _.Move("S", WS_AUX_WORK.FLAG_COBERT);

        }

        [StopWatch]
        /*" R0900-00-SELECT-V0COBERTURA-DB-SELECT-1 */
        public void R0900_00_SELECT_V0COBERTURA_DB_SELECT_1()
        {
            /*" -3276- EXEC SQL SELECT COD_OPCAO , DTINIVIG , VLPRMTOT INTO :V0BCOB-CODOPCAO , :V0BCOB-DTINIVIG , :V0BCOB-VLPRMTOT:VIND-VLPRMTOT FROM SEGUROS.V0BILHETE_COBER WHERE COD_EMPRESA = 0 AND RAMOFR = :V0BILH-RAMO AND MODALIFR = 0 AND VLPRMTOT = :V0RCAP-VLRCAP AND PCCOMCOR > 0 AND IDE_COBERTURA = '1' AND DTINIVIG <= :V0BILH-DTQITBCO AND DTTERVIG >= :V0BILH-DTQITBCO END-EXEC. */

            var r0900_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1 = new R0900_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1()
            {
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V0RCAP_VLRCAP = V0RCAP_VLRCAP.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
            };

            var executed_1 = R0900_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1.Execute(r0900_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BCOB_CODOPCAO, V0BCOB_CODOPCAO);
                _.Move(executed_1.V0BCOB_DTINIVIG, V0BCOB_DTINIVIG);
                _.Move(executed_1.V0BCOB_VLPRMTOT, V0BCOB_VLPRMTOT);
                _.Move(executed_1.VIND_VLPRMTOT, VIND_VLPRMTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-SELECT-V0COBERTURA-SECTION */
        private void R0910_00_SELECT_V0COBERTURA_SECTION()
        {
            /*" -3298- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3300- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3317- PERFORM R0910_00_SELECT_V0COBERTURA_DB_SELECT_1 */

            R0910_00_SELECT_V0COBERTURA_DB_SELECT_1();

            /*" -3320- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3321- PERFORM R0920-00-SELECT-V0COBERTURA */

                R0920_00_SELECT_V0COBERTURA_SECTION();

                /*" -3322- GO TO R0910-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;

                /*" -3323- ELSE */
            }
            else
            {


                /*" -3324- IF VIND-VLPRMTOT LESS ZEROS */

                if (VIND_VLPRMTOT < 00)
                {

                    /*" -3325- PERFORM R0920-00-SELECT-V0COBERTURA */

                    R0920_00_SELECT_V0COBERTURA_SECTION();

                    /*" -3328- GO TO R0910-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -3328- MOVE 'S' TO FLAG-COBERT. */
            _.Move("S", WS_AUX_WORK.FLAG_COBERT);

        }

        [StopWatch]
        /*" R0910-00-SELECT-V0COBERTURA-DB-SELECT-1 */
        public void R0910_00_SELECT_V0COBERTURA_DB_SELECT_1()
        {
            /*" -3317- EXEC SQL SELECT COD_OPCAO , DTINIVIG , VLPRMTOT INTO :V0BCOB-CODOPCAO , :V0BCOB-DTINIVIG , :V0BCOB-VLPRMTOT:VIND-VLPRMTOT FROM SEGUROS.V0BILHETE_COBER WHERE COD_EMPRESA = 0 AND RAMOFR = :V0BILH-RAMO AND MODALIFR = 0 AND VLPRMTOT >= :V0BCOB-VLPRMTOT1 AND VLPRMTOT <= :V0BCOB-VLPRMTOT2 AND PCCOMCOR > 0 AND IDE_COBERTURA = '1' AND DTINIVIG = :V0BILH-DTQITBCO AND DTTERVIG = :V0BILH-DTQITBCO END-EXEC. */

            var r0910_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1 = new R0910_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1()
            {
                V0BCOB_VLPRMTOT1 = V0BCOB_VLPRMTOT1.ToString(),
                V0BCOB_VLPRMTOT2 = V0BCOB_VLPRMTOT2.ToString(),
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
            };

            var executed_1 = R0910_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1.Execute(r0910_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BCOB_CODOPCAO, V0BCOB_CODOPCAO);
                _.Move(executed_1.V0BCOB_DTINIVIG, V0BCOB_DTINIVIG);
                _.Move(executed_1.V0BCOB_VLPRMTOT, V0BCOB_VLPRMTOT);
                _.Move(executed_1.VIND_VLPRMTOT, VIND_VLPRMTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0920-00-SELECT-V0COBERTURA-SECTION */
        private void R0920_00_SELECT_V0COBERTURA_SECTION()
        {
            /*" -3339- MOVE '0920' TO WNR-EXEC-SQL. */
            _.Move("0920", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3341- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3358- PERFORM R0920_00_SELECT_V0COBERTURA_DB_SELECT_1 */

            R0920_00_SELECT_V0COBERTURA_DB_SELECT_1();

            /*" -3361- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3362- PERFORM R0930-00-SELECT-V0COBERTURA */

                R0930_00_SELECT_V0COBERTURA_SECTION();

                /*" -3363- GO TO R0920-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0920_99_SAIDA*/ //GOTO
                return;

                /*" -3364- ELSE */
            }
            else
            {


                /*" -3365- IF VIND-VLPRMTOT LESS ZEROS */

                if (VIND_VLPRMTOT < 00)
                {

                    /*" -3366- PERFORM R0930-00-SELECT-V0COBERTURA */

                    R0930_00_SELECT_V0COBERTURA_SECTION();

                    /*" -3369- GO TO R0920-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0920_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -3369- MOVE 'S' TO FLAG-COBERT. */
            _.Move("S", WS_AUX_WORK.FLAG_COBERT);

        }

        [StopWatch]
        /*" R0920-00-SELECT-V0COBERTURA-DB-SELECT-1 */
        public void R0920_00_SELECT_V0COBERTURA_DB_SELECT_1()
        {
            /*" -3358- EXEC SQL SELECT COD_OPCAO , DTINIVIG , VLPRMTOT INTO :V0BCOB-CODOPCAO , :V0BCOB-DTINIVIG , :V0BCOB-VLPRMTOT:VIND-VLPRMTOT FROM SEGUROS.V0BILHETE_COBER WHERE COD_EMPRESA = 0 AND RAMOFR = :V0BILH-RAMO AND MODALIFR = 0 AND DTINIVIG <= :V0BILH-DTQITBCO AND DTTERVIG >= :V0BILH-DTQITBCO AND VLPRMTOT >= :V0BCOB-VLPRMTOT1 AND VLPRMTOT <= :V0BCOB-VLPRMTOT2 AND PCCOMCOR > 0 AND IDE_COBERTURA = '1' END-EXEC. */

            var r0920_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1 = new R0920_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1()
            {
                V0BCOB_VLPRMTOT1 = V0BCOB_VLPRMTOT1.ToString(),
                V0BCOB_VLPRMTOT2 = V0BCOB_VLPRMTOT2.ToString(),
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
            };

            var executed_1 = R0920_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1.Execute(r0920_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BCOB_CODOPCAO, V0BCOB_CODOPCAO);
                _.Move(executed_1.V0BCOB_DTINIVIG, V0BCOB_DTINIVIG);
                _.Move(executed_1.V0BCOB_VLPRMTOT, V0BCOB_VLPRMTOT);
                _.Move(executed_1.VIND_VLPRMTOT, VIND_VLPRMTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0920_99_SAIDA*/

        [StopWatch]
        /*" R0930-00-SELECT-V0COBERTURA-SECTION */
        private void R0930_00_SELECT_V0COBERTURA_SECTION()
        {
            /*" -3380- MOVE '0930' TO WNR-EXEC-SQL. */
            _.Move("0930", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3382- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3385- COMPUTE WSHOST-VLPRMTOT1 EQUAL V0RCAP-VLRCAP - WS-VLDIFE2. */
            WSHOST_VLPRMTOT1.Value = V0RCAP_VLRCAP - WS_AUX_WORK.WS_VLDIFE2;

            /*" -3389- COMPUTE WSHOST-VLPRMTOT2 EQUAL V0RCAP-VLRCAP + WS-VLDIFE2. */
            WSHOST_VLPRMTOT2.Value = V0RCAP_VLRCAP + WS_AUX_WORK.WS_VLDIFE2;

            /*" -3407- PERFORM R0930_00_SELECT_V0COBERTURA_DB_SELECT_1 */

            R0930_00_SELECT_V0COBERTURA_DB_SELECT_1();

            /*" -3410- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3411- PERFORM R0950-00-VERIFICA-COBERTURA */

                R0950_00_VERIFICA_COBERTURA_SECTION();

                /*" -3412- GO TO R0930-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0930_99_SAIDA*/ //GOTO
                return;

                /*" -3413- ELSE */
            }
            else
            {


                /*" -3414- IF VIND-VLPRMTOT LESS ZEROS */

                if (VIND_VLPRMTOT < 00)
                {

                    /*" -3415- PERFORM R0950-00-VERIFICA-COBERTURA */

                    R0950_00_VERIFICA_COBERTURA_SECTION();

                    /*" -3417- GO TO R0930-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0930_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -3419- MOVE 'S' TO FLAG-COBERT. */
            _.Move("S", WS_AUX_WORK.FLAG_COBERT);

        }

        [StopWatch]
        /*" R0930-00-SELECT-V0COBERTURA-DB-SELECT-1 */
        public void R0930_00_SELECT_V0COBERTURA_DB_SELECT_1()
        {
            /*" -3407- EXEC SQL SELECT COD_OPCAO , DTINIVIG , VLPRMTOT INTO :V0BCOB-CODOPCAO , :V0BCOB-DTINIVIG , :V0BCOB-VLPRMTOT:VIND-VLPRMTOT FROM SEGUROS.V0BILHETE_COBER WHERE COD_EMPRESA = 0 AND RAMOFR = :V0BILH-RAMO AND MODALIFR = 0 AND COD_OPCAO = :V0BILH-OPCOBER AND VLPRMTOT >= :WSHOST-VLPRMTOT1 AND VLPRMTOT <= :WSHOST-VLPRMTOT2 AND PCCOMCOR > 0 AND IDE_COBERTURA = '1' AND DTINIVIG <= :V0BILH-DTQITBCO AND DTTERVIG >= :V0BILH-DTQITBCO END-EXEC. */

            var r0930_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1 = new R0930_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1()
            {
                WSHOST_VLPRMTOT1 = WSHOST_VLPRMTOT1.ToString(),
                WSHOST_VLPRMTOT2 = WSHOST_VLPRMTOT2.ToString(),
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V0BILH_OPCOBER = V0BILH_OPCOBER.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
            };

            var executed_1 = R0930_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1.Execute(r0930_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BCOB_CODOPCAO, V0BCOB_CODOPCAO);
                _.Move(executed_1.V0BCOB_DTINIVIG, V0BCOB_DTINIVIG);
                _.Move(executed_1.V0BCOB_VLPRMTOT, V0BCOB_VLPRMTOT);
                _.Move(executed_1.VIND_VLPRMTOT, VIND_VLPRMTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0930_99_SAIDA*/

        [StopWatch]
        /*" R0940-00-SELECT-V0COBERTURA-SECTION */
        private void R0940_00_SELECT_V0COBERTURA_SECTION()
        {
            /*" -3427- MOVE '0940' TO WNR-EXEC-SQL. */
            _.Move("0940", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3429- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3446- PERFORM R0940_00_SELECT_V0COBERTURA_DB_SELECT_1 */

            R0940_00_SELECT_V0COBERTURA_DB_SELECT_1();

            /*" -3449- DISPLAY 'V0BCOB-DTINIVIG ' V0BCOB-DTINIVIG */
            _.Display($"V0BCOB-DTINIVIG {V0BCOB_DTINIVIG}");

            /*" -3450- DISPLAY 'V0BCOB-CODOPCAO ' V0BCOB-CODOPCAO */
            _.Display($"V0BCOB-CODOPCAO {V0BCOB_CODOPCAO}");

            /*" -3452- DISPLAY 'V0BCOB-VLPRMTOT ' V0BCOB-VLPRMTOT */
            _.Display($"V0BCOB-VLPRMTOT {V0BCOB_VLPRMTOT}");

            /*" -3453- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3454- DISPLAY 'R0940-00 - PROBLEMAS NO SELECT V0BILHETE_COBER)' */
                _.Display($"R0940-00 - PROBLEMAS NO SELECT V0BILHETE_COBER)");

                /*" -3455- DISPLAY 'BILHETE       = ' V0BILH-NUMBIL */
                _.Display($"BILHETE       = {V0BILH_NUMBIL}");

                /*" -3456- DISPLAY 'RAMO          = ' V0BILH-RAMO */
                _.Display($"RAMO          = {V0BILH_RAMO}");

                /*" -3457- DISPLAY 'PREMIO        = ' V0RCAP-VALPRI */
                _.Display($"PREMIO        = {V0RCAP_VALPRI}");

                /*" -3458- DISPLAY 'PRODUTO       = ' V0BILH-COD-PRODUTO */
                _.Display($"PRODUTO       = {V0BILH_COD_PRODUTO}");

                /*" -3459- DISPLAY 'DATA QUITACAO = ' V0BILH-DTQITBCO */
                _.Display($"DATA QUITACAO = {V0BILH_DTQITBCO}");

                /*" -3460- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3462- END-IF */
            }


            /*" -3463- MOVE 'S' TO FLAG-COBERT. */
            _.Move("S", WS_AUX_WORK.FLAG_COBERT);

        }

        [StopWatch]
        /*" R0940-00-SELECT-V0COBERTURA-DB-SELECT-1 */
        public void R0940_00_SELECT_V0COBERTURA_DB_SELECT_1()
        {
            /*" -3446- EXEC SQL SELECT COD_OPCAO , DTINIVIG , VLPRMTOT INTO :V0BCOB-CODOPCAO , :V0BCOB-DTINIVIG , :V0BCOB-VLPRMTOT:VIND-VLPRMTOT FROM SEGUROS.V0BILHETE_COBER WHERE COD_EMPRESA = 0 AND RAMOFR = :V0BILH-RAMO AND MODALIFR = 0 AND VLPRMTOT = :V0RCAP-VALPRI AND PCCOMCOR > 0 AND IDE_COBERTURA = '1' AND CODPRODU = :V0BILH-COD-PRODUTO AND DTINIVIG <= :V0BILH-DTQITBCO AND DTTERVIG >= :V0BILH-DTQITBCO END-EXEC. */

            var r0940_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1 = new R0940_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1()
            {
                V0BILH_COD_PRODUTO = V0BILH_COD_PRODUTO.ToString(),
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V0RCAP_VALPRI = V0RCAP_VALPRI.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
            };

            var executed_1 = R0940_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1.Execute(r0940_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BCOB_CODOPCAO, V0BCOB_CODOPCAO);
                _.Move(executed_1.V0BCOB_DTINIVIG, V0BCOB_DTINIVIG);
                _.Move(executed_1.V0BCOB_VLPRMTOT, V0BCOB_VLPRMTOT);
                _.Move(executed_1.VIND_VLPRMTOT, VIND_VLPRMTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0940_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-VERIFICA-COBERTURA-SECTION */
        private void R0950_00_VERIFICA_COBERTURA_SECTION()
        {
            /*" -3471- MOVE '0950' TO WNR-EXEC-SQL. */
            _.Move("0950", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3473- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3474- MOVE SPACES TO WFIM-COBERTURA. */
            _.Move("", WS_AUX_WORK.WFIM_COBERTURA);

            /*" -3476- PERFORM R3010-00-DECLARE-V0COBERTURA. */

            R3010_00_DECLARE_V0COBERTURA_SECTION();

            /*" -3477- PERFORM R3020-00-FETCH-V0COBERTURA UNTIL WFIM-COBERTURA NOT EQUAL SPACES. */

            while (!(!WS_AUX_WORK.WFIM_COBERTURA.IsEmpty()))
            {

                R3020_00_FETCH_V0COBERTURA_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-LIBERA-BILHETE-SECTION */
        private void R1500_00_LIBERA_BILHETE_SECTION()
        {
            /*" -3688- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3690- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3692- PERFORM R1510-00-SELECT-V0ERRO. */

            R1510_00_SELECT_V0ERRO_SECTION();

            /*" -3693- IF V0ERRO-COUNT EQUAL ZEROS */

            if (V0ERRO_COUNT == 00)
            {

                /*" -3694- IF V0BILH-SITUACAO NOT EQUAL '0' */

                if (V0BILH_SITUACAO != "0")
                {

                    /*" -3695- MOVE '0' TO V0BILH-SITUACAO */
                    _.Move("0", V0BILH_SITUACAO);

                    /*" -3696- ADD 1 TO AC-SITUA0 */
                    WS_AUX_WORK.AC_SITUA0.Value = WS_AUX_WORK.AC_SITUA0 + 1;

                    /*" -3697- PERFORM R2500-00-UPDATE-V0BILHETE */

                    R2500_00_UPDATE_V0BILHETE_SECTION();

                    /*" -3698- ELSE */
                }
                else
                {


                    /*" -3699- ADD 1 TO DP-SITUA0 */
                    WS_AUX_WORK.DP_SITUA0.Value = WS_AUX_WORK.DP_SITUA0 + 1;

                    /*" -3700- ELSE */
                }

            }
            else
            {


                /*" -3701- IF V0BILH-SITUACAO EQUAL '0' */

                if (V0BILH_SITUACAO == "0")
                {

                    /*" -3702- MOVE '1' TO V0BILH-SITUACAO */
                    _.Move("1", V0BILH_SITUACAO);

                    /*" -3703- ADD 1 TO AC-SITUA1 */
                    WS_AUX_WORK.AC_SITUA1.Value = WS_AUX_WORK.AC_SITUA1 + 1;

                    /*" -3704- PERFORM R2500-00-UPDATE-V0BILHETE */

                    R2500_00_UPDATE_V0BILHETE_SECTION();

                    /*" -3705- ELSE */
                }
                else
                {


                    /*" -3705- ADD 1 TO DP-SITUA1. */
                    WS_AUX_WORK.DP_SITUA1.Value = WS_AUX_WORK.DP_SITUA1 + 1;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-SELECT-V0ERRO-SECTION */
        private void R1510_00_SELECT_V0ERRO_SECTION()
        {
            /*" -3716- MOVE '1510' TO WNR-EXEC-SQL. */
            _.Move("1510", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3725- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3735- PERFORM R1510_00_SELECT_V0ERRO_DB_SELECT_1 */

            R1510_00_SELECT_V0ERRO_DB_SELECT_1();

            /*" -3738- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3739- MOVE ZEROS TO V0ERRO-COUNT */
                _.Move(0, V0ERRO_COUNT);

                /*" -3740- ELSE */
            }
            else
            {


                /*" -3741- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3742- DISPLAY 'R1510-00 - PROBLEMAS NO SELECT(V0ERROS)  ' */
                    _.Display($"R1510-00 - PROBLEMAS NO SELECT(V0ERROS)  ");

                    /*" -3743- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3744- ELSE */
                }
                else
                {


                    /*" -3745- IF VIND-COUNT LESS ZEROS */

                    if (VIND_COUNT < 00)
                    {

                        /*" -3745- MOVE ZEROS TO V0ERRO-COUNT. */
                        _.Move(0, V0ERRO_COUNT);
                    }

                }

            }


        }

        [StopWatch]
        /*" R1510-00-SELECT-V0ERRO-DB-SELECT-1 */
        public void R1510_00_SELECT_V0ERRO_DB_SELECT_1()
        {
            /*" -3735- EXEC SQL SELECT COUNT(*) INTO :V0ERRO-COUNT :VIND-COUNT FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :V0BILH-NUMBIL AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> 3 WITH UR END-EXEC. */

            var r1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1 = new R1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1.Execute(r1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ERRO_COUNT, V0ERRO_COUNT);
                _.Move(executed_1.VIND_COUNT, VIND_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1515-00-SELECT-V0ERRO-SECTION */
        private void R1515_00_SELECT_V0ERRO_SECTION()
        {
            /*" -3755- MOVE '1515' TO WNR-EXEC-SQL. */
            _.Move("1515", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3758- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3765- PERFORM R1515_00_SELECT_V0ERRO_DB_SELECT_1 */

            R1515_00_SELECT_V0ERRO_DB_SELECT_1();

            /*" -3768- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3769- CONTINUE */

                /*" -3770- ELSE */
            }
            else
            {


                /*" -3771- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3772- DISPLAY 'R1515-00 - PROBLEMAS NO SELECT(V0ERROS)  ' */
                    _.Display($"R1515-00 - PROBLEMAS NO SELECT(V0ERROS)  ");

                    /*" -3772- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1515-00-SELECT-V0ERRO-DB-SELECT-1 */
        public void R1515_00_SELECT_V0ERRO_DB_SELECT_1()
        {
            /*" -3765- EXEC SQL SELECT SEQ_CRITICA INTO :V0ERRO-COUNT :VIND-COUNT FROM SEGUROS.VG_CRITICA_PROPOSTA WHERE NUM_CERTIFICADO = :V0BILH-NUMBIL AND COD_MSG_CRITICA = 834 WITH UR END-EXEC. */

            var r1515_00_SELECT_V0ERRO_DB_SELECT_1_Query1 = new R1515_00_SELECT_V0ERRO_DB_SELECT_1_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R1515_00_SELECT_V0ERRO_DB_SELECT_1_Query1.Execute(r1515_00_SELECT_V0ERRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ERRO_COUNT, V0ERRO_COUNT);
                _.Move(executed_1.VIND_COUNT, VIND_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1515_99_SAIDA*/

        [StopWatch]
        /*" R1550-00-SELECT-SEQ-CRTCA-SECTION */
        private void R1550_00_SELECT_SEQ_CRTCA_SECTION()
        {
            /*" -3783- MOVE '1550' TO WNR-EXEC-SQL. */
            _.Move("1550", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3785- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3787- MOVE ZEROS TO WS-SEQ-CRITICA */
            _.Move(0, WS_SEQ_CRITICA);

            /*" -3795- PERFORM R1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1 */

            R1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1();

            /*" -3798- IF SQLCODE NOT EQUAL +100 AND +0 */

            if (!DB.SQLCODE.In("+100", "+0"))
            {

                /*" -3800- DISPLAY 'R1550-00 - ERRO SELECT(VG_CRITICA_PROPOSTA) ' V0ERRO-NUMBIL ' >> ' V0ERRO-CODERRO */

                $"R1550-00 - ERRO SELECT(VG_CRITICA_PROPOSTA) {V0ERRO_NUMBIL} >> {V0ERRO_CODERRO}"
                .Display();

                /*" -3801- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3802- END-IF */
            }


            /*" -3802- . */

        }

        [StopWatch]
        /*" R1550-00-SELECT-SEQ-CRTCA-DB-SELECT-1 */
        public void R1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1()
        {
            /*" -3795- EXEC SQL SELECT VALUE(A.SEQ_CRITICA, 0) INTO :WS-SEQ-CRITICA FROM SEGUROS.VG_CRITICA_PROPOSTA A WHERE A.NUM_CERTIFICADO = :V0ERRO-NUMBIL AND A.COD_MSG_CRITICA = :V0ERRO-CODERRO AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) WITH UR END-EXEC. */

            var r1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1_Query1 = new R1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1_Query1()
            {
                V0ERRO_CODERRO = V0ERRO_CODERRO.ToString(),
                V0ERRO_NUMBIL = V0ERRO_NUMBIL.ToString(),
            };

            var executed_1 = R1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1_Query1.Execute(r1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_SEQ_CRITICA, WS_SEQ_CRITICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1550_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-VER-COBERTURA-SECTION */
        private void R1600_00_VER_COBERTURA_SECTION()
        {
            /*" -3811- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3813- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3816- COMPUTE V0BCOB-VLPRMTOT1 EQUAL V0RCAP-VLRCAP - WS-VLDIFE. */
            V0BCOB_VLPRMTOT1.Value = V0RCAP_VLRCAP - WS_AUX_WORK.WS_VLDIFE;

            /*" -3820- COMPUTE V0BCOB-VLPRMTOT2 EQUAL V0RCAP-VLRCAP + WS-VLDIFE. */
            V0BCOB_VLPRMTOT2.Value = V0RCAP_VLRCAP + WS_AUX_WORK.WS_VLDIFE;

            /*" -3822- IF (VIND-COD-PRODUTO LESS ZEROS) OR (V0BILH-COD-PRODUTO EQUAL ZEROS) */

            if ((VIND_COD_PRODUTO < 00) || (V0BILH_COD_PRODUTO == 00))
            {

                /*" -3823- PERFORM R0900-00-SELECT-V0COBERTURA */

                R0900_00_SELECT_V0COBERTURA_SECTION();

                /*" -3824- ELSE */
            }
            else
            {


                /*" -3825- IF NOVOS-ACESSOS */

                if (NIVEIS_88.N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
                {

                    /*" -3826- DISPLAY 'NOVOS ACESSOS-2: ' N88-NOVOS-ACESSOS */
                    _.Display($"NOVOS ACESSOS-2: {NIVEIS_88.N88_NOVOS_ACESSOS}");

                    /*" -3827- MOVE 'S' TO FLAG-COBERT */
                    _.Move("S", WS_AUX_WORK.FLAG_COBERT);

                    /*" -3829- MOVE LK-0071-I-COD-OPC-PLANO TO V0BCOB-CODOPCAO */
                    _.Move(GE0071W.LK_0071_I_COD_OPC_PLANO, V0BCOB_CODOPCAO);

                    /*" -3830- MOVE V0BILH-DTVENDA TO V0BCOB-DTINIVIG */
                    _.Move(V0BILH_DTVENDA, V0BCOB_DTINIVIG);

                    /*" -3832- MOVE LK-0071-S-VLR-INI-PREMIO TO V0BCOB-VLPRMTOT */
                    _.Move(GE0071W.LK_0071_S_VLR_INI_PREMIO, V0BCOB_VLPRMTOT);

                    /*" -3833- ELSE */
                }
                else
                {


                    /*" -3834- DISPLAY 'R0940-00 (2)' */
                    _.Display($"R0940-00 (2)");

                    /*" -3835- PERFORM R0940-00-SELECT-V0COBERTURA */

                    R0940_00_SELECT_V0COBERTURA_SECTION();

                    /*" -3836- END-IF */
                }


                /*" -3839- END-IF */
            }


            /*" -3840- IF V0BCOB-CODOPCAO EQUAL ZEROS */

            if (V0BCOB_CODOPCAO == 00)
            {

                /*" -3841- MOVE '1' TO V0BILH-SITUACAO */
                _.Move("1", V0BILH_SITUACAO);

                /*" -3842- ADD 1 TO CL-SITUA1 */
                WS_AUX_WORK.CL_SITUA1.Value = WS_AUX_WORK.CL_SITUA1 + 1;

                /*" -3843- PERFORM R2500-00-UPDATE-V0BILHETE */

                R2500_00_UPDATE_V0BILHETE_SECTION();

                /*" -3845- GO TO R1600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3846- IF V0BILH-OPCOBER NOT EQUAL V0BCOB-CODOPCAO */

            if (V0BILH_OPCOBER != V0BCOB_CODOPCAO)
            {

                /*" -3847- DISPLAY '-------------- ATENCAO ---------------' */
                _.Display($"-------------- ATENCAO ---------------");

                /*" -3848- DISPLAY '-------------- ATENCAO ---------------' */
                _.Display($"-------------- ATENCAO ---------------");

                /*" -3849- DISPLAY '-------------- ATENCAO ---------------' */
                _.Display($"-------------- ATENCAO ---------------");

                /*" -3850- DISPLAY 'TROCOU A OPCAO DE COBERTURA DO BILHETE' */
                _.Display($"TROCOU A OPCAO DE COBERTURA DO BILHETE");

                /*" -3851- DISPLAY 'PARAGRAFO: R1600-00-VER-COBERTURA     ' */
                _.Display($"PARAGRAFO: R1600-00-VER-COBERTURA     ");

                /*" -3852- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -3853- DISPLAY '------------- VERIFICAR --------------' */
                _.Display($"------------- VERIFICAR --------------");

                /*" -3855- END-IF */
            }


            /*" -3859- IF V0BILH-OPCOBER NOT EQUAL V0BCOB-CODOPCAO OR V0BILH-DTQITBCO NOT EQUAL V0RCOM-DATARCAP OR V0BILH-DTVENDA NOT EQUAL V0RCOM-DATARCAP OR V0BILH-VLRCAP NOT EQUAL V0BCOB-VLPRMTOT */

            if (V0BILH_OPCOBER != V0BCOB_CODOPCAO || V0BILH_DTQITBCO != V0RCOM_DATARCAP || V0BILH_DTVENDA != V0RCOM_DATARCAP || V0BILH_VLRCAP != V0BCOB_VLPRMTOT)
            {

                /*" -3860- ADD 1 TO CL-ALTERA */
                WS_AUX_WORK.CL_ALTERA.Value = WS_AUX_WORK.CL_ALTERA + 1;

                /*" -3860- PERFORM R2250-00-UPDATE-V0BILHETE. */

                R2250_00_UPDATE_V0BILHETE_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-UPDATE-V0BILHETE-SECTION */
        private void R2000_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -3871- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3873- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3879- PERFORM R2000_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R2000_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -3883- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3884- DISPLAY 'R2000-00 - PROBLEMAS UPDATE (V0BILHETE)  ' */
                _.Display($"R2000-00 - PROBLEMAS UPDATE (V0BILHETE)  ");

                /*" -3884- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2000-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R2000_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -3879- EXEC SQL UPDATE SEGUROS.V0BILHETE SET FONTE = :WSHOST-FONTE , AGECOBR = :WSHOST-AGECOBR , COD_USUARIO = 'CB0009B' WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r2000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R2000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                WSHOST_AGECOBR = WSHOST_AGECOBR.ToString(),
                WSHOST_FONTE = WSHOST_FONTE.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R2000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r2000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-UPDATE-V0COFENAE-SECTION */
        private void R2100_00_UPDATE_V0COFENAE_SECTION()
        {
            /*" -3895- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3897- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3901- PERFORM R2100_00_UPDATE_V0COFENAE_DB_UPDATE_1 */

            R2100_00_UPDATE_V0COFENAE_DB_UPDATE_1();

            /*" -3905- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3906- DISPLAY 'R2100-00 - PROBLEMAS UPDATE (V0CFEN)     ' */
                _.Display($"R2100-00 - PROBLEMAS UPDATE (V0CFEN)     ");

                /*" -3906- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-UPDATE-V0COFENAE-DB-UPDATE-1 */
        public void R2100_00_UPDATE_V0COFENAE_DB_UPDATE_1()
        {
            /*" -3901- EXEC SQL UPDATE SEGUROS.V0COMISSAO_FENAE SET AGECOBR = :V0BILH-AGECOBR WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r2100_00_UPDATE_V0COFENAE_DB_UPDATE_1_Update1 = new R2100_00_UPDATE_V0COFENAE_DB_UPDATE_1_Update1()
            {
                V0BILH_AGECOBR = V0BILH_AGECOBR.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R2100_00_UPDATE_V0COFENAE_DB_UPDATE_1_Update1.Execute(r2100_00_UPDATE_V0COFENAE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2230-00-UPDATE-V0BILHETE-SECTION */
        private void R2230_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -3937- MOVE '2230' TO WNR-EXEC-SQL. */
            _.Move("2230", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3939- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3942- MOVE ZERO TO WERRO-UPDT. */
            _.Move(0, WS_AUX_WORK.WERRO_UPDT);

            /*" -3947- PERFORM R2230_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R2230_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -3951- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3951- MOVE 1 TO WERRO-UPDT. */
                _.Move(1, WS_AUX_WORK.WERRO_UPDT);
            }


        }

        [StopWatch]
        /*" R2230-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R2230_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -3947- EXEC SQL UPDATE SEGUROS.V0BILHETE SET COD_USUARIO = 'CB0009B' , PROFISSAO = :V0BILH-PROFISSAO WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r2230_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R2230_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V0BILH_PROFISSAO = V0BILH_PROFISSAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R2230_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r2230_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2230_99_SAIDA*/

        [StopWatch]
        /*" R2250-00-UPDATE-V0BILHETE-SECTION */
        private void R2250_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -3961- MOVE '2250' TO WNR-EXEC-SQL. */
            _.Move("2250", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3963- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3973- PERFORM R2250_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R2250_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -3977- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3978- DISPLAY 'R2250-00 - PROBLEMAS UPDATE (V0BILHETE)  ' */
                _.Display($"R2250-00 - PROBLEMAS UPDATE (V0BILHETE)  ");

                /*" -3981- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3981- PERFORM R2255-00-UPDATE-PRP-FIDELIZ. */

            R2255_00_UPDATE_PRP_FIDELIZ_SECTION();

        }

        [StopWatch]
        /*" R2250-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R2250_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -3973- EXEC SQL UPDATE SEGUROS.V0BILHETE SET OPC_COBERTURA = :V0BCOB-CODOPCAO , DTQITBCO = :V0RCOM-DATARCAP , DATA_VENDA = :V0RCOM-DATARCAP , VLRCAP = :V0BCOB-VLPRMTOT , DTMOVTO = :V0SIST-DTMOVABE , TIMESTAMP = CURRENT TIMESTAMP, COD_USUARIO = 'CB0009B' WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r2250_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R2250_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V0BCOB_CODOPCAO = V0BCOB_CODOPCAO.ToString(),
                V0RCOM_DATARCAP = V0RCOM_DATARCAP.ToString(),
                V0BCOB_VLPRMTOT = V0BCOB_VLPRMTOT.ToString(),
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R2250_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r2250_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/

        [StopWatch]
        /*" R2255-00-UPDATE-PRP-FIDELIZ-SECTION */
        private void R2255_00_UPDATE_PRP_FIDELIZ_SECTION()
        {
            /*" -3990- MOVE '2255' TO WNR-EXEC-SQL. */
            _.Move("2255", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3992- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3994- IF V0BCOB-VLPRMTOT NUMERIC AND V0BCOB-VLPRMTOT GREATER ZEROS */

            if (V0BCOB_VLPRMTOT.IsNumeric() && V0BCOB_VLPRMTOT > 00)
            {

                /*" -3995- MOVE V0BCOB-VLPRMTOT TO VAL-PAGO-FIDELIZ */
                _.Move(V0BCOB_VLPRMTOT, VAL_PAGO_FIDELIZ);

                /*" -3996- ELSE */
            }
            else
            {


                /*" -3998- MOVE V0RCOM-VLRCAP TO VAL-PAGO-FIDELIZ. */
                _.Move(V0RCOM_VLRCAP, VAL_PAGO_FIDELIZ);
            }


            /*" -4007- PERFORM R2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1 */

            R2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1();

            /*" -4010- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4011- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -4013- DISPLAY 'R2255-00 - PROBLEMAS UPDATE (PRPFIDEL) ' SQLCODE */
                    _.Display($"R2255-00 - PROBLEMAS UPDATE (PRPFIDEL) {DB.SQLCODE}");

                    /*" -4015- DISPLAY '           NUM SICOB.......................... ' V0BILH-NUMBIL */
                    _.Display($"           NUM SICOB.......................... {V0BILH_NUMBIL}");

                    /*" -4016- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2255-00-UPDATE-PRP-FIDELIZ-DB-UPDATE-1 */
        public void R2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1()
        {
            /*" -4007- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET DTQITBCO = :V0RCOM-DATARCAP, DATA_CREDITO = :V0RCOM-DTMOVTO , VAL_PAGO = :VAL-PAGO-FIDELIZ WHERE NUM_SICOB = :V0BILH-NUMBIL AND DTQITBCO = '0001-01-01' AND DATA_CREDITO = '0001-01-01' AND VAL_PAGO = 0 END-EXEC. */

            var r2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1 = new R2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1()
            {
                VAL_PAGO_FIDELIZ = VAL_PAGO_FIDELIZ.ToString(),
                V0RCOM_DATARCAP = V0RCOM_DATARCAP.ToString(),
                V0RCOM_DTMOVTO = V0RCOM_DTMOVTO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1.Execute(r2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2255_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-UPDATE-V0BILHETE-SECTION */
        private void R2400_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -4025- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4027- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4032- PERFORM R2400_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R2400_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -4036- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4036- ADD 1 TO ER-BILEMI. */
                WS_AUX_WORK.ER_BILEMI.Value = WS_AUX_WORK.ER_BILEMI + 1;
            }


        }

        [StopWatch]
        /*" R2400-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R2400_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -4032- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO, COD_USUARIO = 'CB0009B' WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r2400_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R2400_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R2400_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r2400_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-UPDATE-V0BILHETE-SECTION */
        private void R2500_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -4047- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4049- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4054- PERFORM R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -4057- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4060- ADD 1 TO ER-LIBERA. */
                WS_AUX_WORK.ER_LIBERA.Value = WS_AUX_WORK.ER_LIBERA + 1;
            }


            /*" -4061- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4062- IF V0BILH-SITUACAO EQUAL '0' */

                if (V0BILH_SITUACAO == "0")
                {

                    /*" -4062- PERFORM R2255-00-UPDATE-PRP-FIDELIZ. */

                    R2255_00_UPDATE_PRP_FIDELIZ_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R2500-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -4054- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO, COD_USUARIO = 'CB0009B' WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-DELETE-V0ERRO-SECTION */
        private void R2800_00_DELETE_V0ERRO_SECTION()
        {
            /*" -4093- MOVE '2800' TO WNR-EXEC-SQL. */
            _.Move("2800", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4095- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4097- PERFORM R2810-00-DECLARE-V0ERRO */

            R2810_00_DECLARE_V0ERRO_SECTION();

            /*" -4099- PERFORM R2820-00-FETCH-V0ERRO */

            R2820_00_FETCH_V0ERRO_SECTION();

            /*" -4100- PERFORM R2830-00-PROCESSA-V0ERRO UNTIL WFIM-V0ERRO NOT EQUAL SPACES. */

            while (!(!WS_AUX_WORK.WFIM_V0ERRO.IsEmpty()))
            {

                R2830_00_PROCESSA_V0ERRO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R2810-00-DECLARE-V0ERRO-SECTION */
        private void R2810_00_DECLARE_V0ERRO_SECTION()
        {
            /*" -4119- MOVE '2810' TO WNR-EXEC-SQL. */
            _.Move("2810", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4121- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4123- MOVE 'N' TO WFIM-V0ERRO */
            _.Move("N", WS_AUX_WORK.WFIM_V0ERRO);

            /*" -4136- PERFORM R2810_00_DECLARE_V0ERRO_DB_DECLARE_1 */

            R2810_00_DECLARE_V0ERRO_DB_DECLARE_1();

            /*" -4139- PERFORM R2810_00_DECLARE_V0ERRO_DB_OPEN_1 */

            R2810_00_DECLARE_V0ERRO_DB_OPEN_1();

            /*" -4143- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4145- DISPLAY 'R2810-00 - PROBLEMAS DECLARE (V1ERRO) ' V0BILH-NUMBIL ' >> ' SQLCODE */

                $"R2810-00 - PROBLEMAS DECLARE (V1ERRO) {V0BILH_NUMBIL} >> {DB.SQLCODE}"
                .Display();

                /*" -4146- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4146- END-IF. */
            }


        }

        [StopWatch]
        /*" R2810-00-DECLARE-V0ERRO-DB-OPEN-1 */
        public void R2810_00_DECLARE_V0ERRO_DB_OPEN_1()
        {
            /*" -4139- EXEC SQL OPEN V1ERRO END-EXEC. */

            V1ERRO.Open();

        }

        [StopWatch]
        /*" R2851-00-DECLARE-V0ERRO-DB-DECLARE-1 */
        public void R2851_00_DECLARE_V0ERRO_DB_DECLARE_1()
        {
            /*" -4241- EXEC SQL DECLARE V2ERRO CURSOR FOR SELECT A.NUM_CERTIFICADO, A.COD_MSG_CRITICA FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :V0BILH-NUMBIL AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA IN (1501,1502,1503,1602,1801 ,1802,1901,2101,2102) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA = 1 ORDER BY A.COD_MSG_CRITICA WITH UR END-EXEC. */
            V2ERRO = new CB0009B_V2ERRO(true);
            string GetQuery_V2ERRO()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO
							, 
							A.COD_MSG_CRITICA 
							FROM SEGUROS.VG_CRITICA_PROPOSTA A
							, 
							SEGUROS.VG_DM_MSG_CRITICA B 
							WHERE A.NUM_CERTIFICADO = '{V0BILH_NUMBIL}' 
							AND A.STA_CRITICA IN ( '0'
							, '1'
							, '2'
							, '4'
							, '5'
							, '8' ) 
							AND A.COD_MSG_CRITICA IN (1501
							,1502
							,1503
							,1602
							,1801 
							,1802
							,1901
							,2101
							,2102) 
							AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA 
							AND B.COD_TP_MSG_CRITICA = 1 
							ORDER BY A.COD_MSG_CRITICA";

                return query;
            }
            V2ERRO.GetQueryEvent += GetQuery_V2ERRO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2810_99_SAIDA*/

        [StopWatch]
        /*" R2820-00-FETCH-V0ERRO-SECTION */
        private void R2820_00_FETCH_V0ERRO_SECTION()
        {
            /*" -4156- MOVE '2820' TO WNR-EXEC-SQL. */
            _.Move("2820", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4158- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4162- PERFORM R2820_00_FETCH_V0ERRO_DB_FETCH_1 */

            R2820_00_FETCH_V0ERRO_DB_FETCH_1();

            /*" -4165- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4166- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4166- PERFORM R2820_00_FETCH_V0ERRO_DB_CLOSE_1 */

                    R2820_00_FETCH_V0ERRO_DB_CLOSE_1();

                    /*" -4168- MOVE 'S' TO WFIM-V0ERRO */
                    _.Move("S", WS_AUX_WORK.WFIM_V0ERRO);

                    /*" -4169- GO TO R2820-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2820_99_SAIDA*/ //GOTO
                    return;

                    /*" -4170- ELSE */
                }
                else
                {


                    /*" -4171- DISPLAY 'R2820-00 - PROBLEMAS FETCH (V1ERRO)      ' */
                    _.Display($"R2820-00 - PROBLEMAS FETCH (V1ERRO)      ");

                    /*" -4172- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4173- END-IF */
                }


                /*" -4173- END-IF. */
            }


        }

        [StopWatch]
        /*" R2820-00-FETCH-V0ERRO-DB-FETCH-1 */
        public void R2820_00_FETCH_V0ERRO_DB_FETCH_1()
        {
            /*" -4162- EXEC SQL FETCH V1ERRO INTO :V0ERRO-NUMBIL , :V0ERRO-CODERRO END-EXEC. */

            if (V1ERRO.Fetch())
            {
                _.Move(V1ERRO.V0ERRO_NUMBIL, V0ERRO_NUMBIL);
                _.Move(V1ERRO.V0ERRO_CODERRO, V0ERRO_CODERRO);
            }

        }

        [StopWatch]
        /*" R2820-00-FETCH-V0ERRO-DB-CLOSE-1 */
        public void R2820_00_FETCH_V0ERRO_DB_CLOSE_1()
        {
            /*" -4166- EXEC SQL CLOSE V1ERRO END-EXEC */

            V1ERRO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2820_99_SAIDA*/

        [StopWatch]
        /*" R2830-00-PROCESSA-V0ERRO-SECTION */
        private void R2830_00_PROCESSA_V0ERRO_SECTION()
        {
            /*" -4183- MOVE '2830' TO WNR-EXEC-SQL. */
            _.Move("2830", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4185- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4187- PERFORM R2860-00-DELETE-VGCRITICA */

            R2860_00_DELETE_VGCRITICA_SECTION();

            /*" -4188- ADD 1 TO FU-ERROS */
            WS_AUX_WORK.FU_ERROS.Value = WS_AUX_WORK.FU_ERROS + 1;

            /*" -4189- PERFORM R2820-00-FETCH-V0ERRO */

            R2820_00_FETCH_V0ERRO_SECTION();

            /*" -4189- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2830_99_SAIDA*/

        [StopWatch]
        /*" R2850-00-DELETE-V0ERRO-SECTION */
        private void R2850_00_DELETE_V0ERRO_SECTION()
        {
            /*" -4198- MOVE '2850' TO WNR-EXEC-SQL. */
            _.Move("2850", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4200- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4202- PERFORM R2851-00-DECLARE-V0ERRO */

            R2851_00_DECLARE_V0ERRO_SECTION();

            /*" -4204- PERFORM R2852-00-FETCH-V0ERRO */

            R2852_00_FETCH_V0ERRO_SECTION();

            /*" -4205- PERFORM R2855-00-PROCESSA-V0ERRO UNTIL WFIM-V0ERRO NOT EQUAL SPACES. */

            while (!(!WS_AUX_WORK.WFIM_V0ERRO.IsEmpty()))
            {

                R2855_00_PROCESSA_V0ERRO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2850_99_SAIDA*/

        [StopWatch]
        /*" R2851-00-DECLARE-V0ERRO-SECTION */
        private void R2851_00_DECLARE_V0ERRO_SECTION()
        {
            /*" -4223- MOVE '2851' TO WNR-EXEC-SQL. */
            _.Move("2851", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4225- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4227- MOVE 'N' TO WFIM-V0ERRO */
            _.Move("N", WS_AUX_WORK.WFIM_V0ERRO);

            /*" -4241- PERFORM R2851_00_DECLARE_V0ERRO_DB_DECLARE_1 */

            R2851_00_DECLARE_V0ERRO_DB_DECLARE_1();

            /*" -4244- PERFORM R2851_00_DECLARE_V0ERRO_DB_OPEN_1 */

            R2851_00_DECLARE_V0ERRO_DB_OPEN_1();

            /*" -4248- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4250- DISPLAY 'R2851-00 - PROBLEMAS DECLARE (V2ERRO) ' V0BILH-NUMBIL ' >> ' SQLCODE */

                $"R2851-00 - PROBLEMAS DECLARE (V2ERRO) {V0BILH_NUMBIL} >> {DB.SQLCODE}"
                .Display();

                /*" -4251- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4251- END-IF. */
            }


        }

        [StopWatch]
        /*" R2851-00-DECLARE-V0ERRO-DB-OPEN-1 */
        public void R2851_00_DECLARE_V0ERRO_DB_OPEN_1()
        {
            /*" -4244- EXEC SQL OPEN V2ERRO END-EXEC. */

            V2ERRO.Open();

        }

        [StopWatch]
        /*" R3010-00-DECLARE-V0COBERTURA-DB-DECLARE-1 */
        public void R3010_00_DECLARE_V0COBERTURA_DB_DECLARE_1()
        {
            /*" -4432- EXEC SQL DECLARE V0COBERTURA CURSOR FOR SELECT COD_OPCAO , DTINIVIG , VLPRMTOT FROM SEGUROS.V0BILHETE_COBER WHERE COD_EMPRESA = 0 AND RAMOFR = :V0BILH-RAMO AND MODALIFR = 0 AND VLPRMTOT >= :V0BCOB-VLPRMTOT1 AND VLPRMTOT <= :V0BCOB-VLPRMTOT2 AND PCCOMCOR > 0 AND IDE_COBERTURA = '1' AND DTINIVIG <= :V0BILH-DTQITBCO AND DTTERVIG >= :V0BILH-DTQITBCO ORDER BY COD_OPCAO DESC END-EXEC. */
            V0COBERTURA = new CB0009B_V0COBERTURA(true);
            string GetQuery_V0COBERTURA()
            {
                var query = @$"SELECT COD_OPCAO
							, 
							DTINIVIG
							, 
							VLPRMTOT 
							FROM SEGUROS.V0BILHETE_COBER 
							WHERE COD_EMPRESA = 0 
							AND RAMOFR = '{V0BILH_RAMO}' 
							AND MODALIFR = 0 
							AND VLPRMTOT >= '{V0BCOB_VLPRMTOT1}' 
							AND VLPRMTOT <= '{V0BCOB_VLPRMTOT2}' 
							AND PCCOMCOR > 0 
							AND IDE_COBERTURA = '1' 
							AND DTINIVIG <= '{V0BILH_DTQITBCO}' 
							AND DTTERVIG >= '{V0BILH_DTQITBCO}' 
							ORDER BY COD_OPCAO DESC";

                return query;
            }
            V0COBERTURA.GetQueryEvent += GetQuery_V0COBERTURA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2851_99_SAIDA*/

        [StopWatch]
        /*" R2852-00-FETCH-V0ERRO-SECTION */
        private void R2852_00_FETCH_V0ERRO_SECTION()
        {
            /*" -4261- MOVE '2852' TO WNR-EXEC-SQL. */
            _.Move("2852", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4263- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4267- PERFORM R2852_00_FETCH_V0ERRO_DB_FETCH_1 */

            R2852_00_FETCH_V0ERRO_DB_FETCH_1();

            /*" -4270- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4271- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4271- PERFORM R2852_00_FETCH_V0ERRO_DB_CLOSE_1 */

                    R2852_00_FETCH_V0ERRO_DB_CLOSE_1();

                    /*" -4273- MOVE 'S' TO WFIM-V0ERRO */
                    _.Move("S", WS_AUX_WORK.WFIM_V0ERRO);

                    /*" -4274- GO TO R2852-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2852_99_SAIDA*/ //GOTO
                    return;

                    /*" -4275- ELSE */
                }
                else
                {


                    /*" -4276- DISPLAY 'R2852-00 - PROBLEMAS FETCH (V2ERRO)      ' */
                    _.Display($"R2852-00 - PROBLEMAS FETCH (V2ERRO)      ");

                    /*" -4277- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4278- END-IF */
                }


                /*" -4278- END-IF. */
            }


        }

        [StopWatch]
        /*" R2852-00-FETCH-V0ERRO-DB-FETCH-1 */
        public void R2852_00_FETCH_V0ERRO_DB_FETCH_1()
        {
            /*" -4267- EXEC SQL FETCH V2ERRO INTO :V0ERRO-NUMBIL , :V0ERRO-CODERRO END-EXEC. */

            if (V2ERRO.Fetch())
            {
                _.Move(V2ERRO.V0ERRO_NUMBIL, V0ERRO_NUMBIL);
                _.Move(V2ERRO.V0ERRO_CODERRO, V0ERRO_CODERRO);
            }

        }

        [StopWatch]
        /*" R2852-00-FETCH-V0ERRO-DB-CLOSE-1 */
        public void R2852_00_FETCH_V0ERRO_DB_CLOSE_1()
        {
            /*" -4271- EXEC SQL CLOSE V2ERRO END-EXEC */

            V2ERRO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2852_99_SAIDA*/

        [StopWatch]
        /*" R2855-00-PROCESSA-V0ERRO-SECTION */
        private void R2855_00_PROCESSA_V0ERRO_SECTION()
        {
            /*" -4288- MOVE '2855' TO WNR-EXEC-SQL. */
            _.Move("2855", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4290- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4292- PERFORM R2860-00-DELETE-VGCRITICA */

            R2860_00_DELETE_VGCRITICA_SECTION();

            /*" -4293- PERFORM R2852-00-FETCH-V0ERRO */

            R2852_00_FETCH_V0ERRO_SECTION();

            /*" -4293- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2855_99_SAIDA*/

        [StopWatch]
        /*" R2860-00-DELETE-VGCRITICA-SECTION */
        private void R2860_00_DELETE_VGCRITICA_SECTION()
        {
            /*" -4306- MOVE '2860' TO WNR-EXEC-SQL. */
            _.Move("2860", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4308- PERFORM R1550-00-SELECT-SEQ-CRTCA */

            R1550_00_SELECT_SEQ_CRTCA_SECTION();

            /*" -4309- IF WS-SEQ-CRITICA EQUAL ZEROS */

            if (WS_SEQ_CRITICA == 00)
            {

                /*" -4310- GO TO R2860-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2860_99_SAIDA*/ //GOTO
                return;

                /*" -4312- END-IF */
            }


            /*" -4314- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -4315- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -4316- MOVE 03 TO LK-VG001-TIPO-ACAO */
            _.Move(03, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -4317- MOVE V0ERRO-NUMBIL TO LK-VG001-NUM-CERTIFICADO */
            _.Move(V0ERRO_NUMBIL, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -4318- MOVE V0ERRO-CODERRO TO LK-VG001-COD-MSG-CRITICA */
            _.Move(V0ERRO_CODERRO, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -4319- MOVE WS-SEQ-CRITICA TO LK-VG001-SEQ-CRITICA */
            _.Move(WS_SEQ_CRITICA, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -4320- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -4321- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -4322- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -4323- MOVE 'CB0009B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("CB0009B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -4324- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -4325- MOVE 'B' TO LK-VG001-STA-CRITICA */
            _.Move("B", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -4326- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -4329- MOVE 'EXCLUSAO LOGICA DE ERRO DA PROPOSTA ' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("EXCLUSAO LOGICA DE ERRO DA PROPOSTA ", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -4331- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -4332- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -4333- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -4334- DISPLAY '* R2860-PROBLEMAS CALL SUBROTINA SPBVG001  *' */
                _.Display($"* R2860-PROBLEMAS CALL SUBROTINA SPBVG001  *");

                /*" -4335- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -4336- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -4337- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -4338- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -4339- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -4340- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -4341- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -4343- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -4344- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4345- END-IF */
            }


            /*" -4345- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2860_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-VER-MAIOR-SECTION */
        private void R3000_00_VER_MAIOR_SECTION()
        {
            /*" -4354- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4356- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4359- COMPUTE V0BCOB-VLPRMTOT1 EQUAL V0RCAP-VLRCAP - WS-VLDIFE. */
            V0BCOB_VLPRMTOT1.Value = V0RCAP_VLRCAP - WS_AUX_WORK.WS_VLDIFE;

            /*" -4363- COMPUTE V0BCOB-VLPRMTOT2 EQUAL V0RCAP-VLRCAP + WS-VLDIFE. */
            V0BCOB_VLPRMTOT2.Value = V0RCAP_VLRCAP + WS_AUX_WORK.WS_VLDIFE;

            /*" -4364- MOVE SPACES TO WFIM-COBERTURA. */
            _.Move("", WS_AUX_WORK.WFIM_COBERTURA);

            /*" -4366- PERFORM R3010-00-DECLARE-V0COBERTURA. */

            R3010_00_DECLARE_V0COBERTURA_SECTION();

            /*" -4369- PERFORM R3020-00-FETCH-V0COBERTURA UNTIL WFIM-COBERTURA NOT EQUAL SPACES. */

            while (!(!WS_AUX_WORK.WFIM_COBERTURA.IsEmpty()))
            {

                R3020_00_FETCH_V0COBERTURA_SECTION();
            }

            /*" -4370- IF V0BCOB-CODOPCAO EQUAL ZEROS */

            if (V0BCOB_CODOPCAO == 00)
            {

                /*" -4371- ADD 1 TO DP-VLMAIOR */
                WS_AUX_WORK.DP_VLMAIOR.Value = WS_AUX_WORK.DP_VLMAIOR + 1;

                /*" -4373- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4374- IF V0BILH-OPCOBER NOT EQUAL V0BCOB-CODOPCAO */

            if (V0BILH_OPCOBER != V0BCOB_CODOPCAO)
            {

                /*" -4375- DISPLAY '-------------- ATENCAO ---------------' */
                _.Display($"-------------- ATENCAO ---------------");

                /*" -4376- DISPLAY '-------------- ATENCAO ---------------' */
                _.Display($"-------------- ATENCAO ---------------");

                /*" -4377- DISPLAY '-------------- ATENCAO ---------------' */
                _.Display($"-------------- ATENCAO ---------------");

                /*" -4378- DISPLAY 'TROCOU A OPCAO DE COBERTURA DO BILHETE' */
                _.Display($"TROCOU A OPCAO DE COBERTURA DO BILHETE");

                /*" -4379- DISPLAY 'PARAGRAFO: R3000-00-VER-MAIOR         ' */
                _.Display($"PARAGRAFO: R3000-00-VER-MAIOR         ");

                /*" -4380- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -4381- DISPLAY '------------- VERIFICAR --------------' */
                _.Display($"------------- VERIFICAR --------------");

                /*" -4383- END-IF */
            }


            /*" -4387- IF V0BILH-OPCOBER NOT EQUAL V0BCOB-CODOPCAO OR V0BILH-DTQITBCO NOT EQUAL V0RCOM-DATARCAP OR V0BILH-DTVENDA NOT EQUAL V0RCOM-DATARCAP OR V0BILH-VLRCAP NOT EQUAL V0BCOB-VLPRMTOT */

            if (V0BILH_OPCOBER != V0BCOB_CODOPCAO || V0BILH_DTQITBCO != V0RCOM_DATARCAP || V0BILH_DTVENDA != V0RCOM_DATARCAP || V0BILH_VLRCAP != V0BCOB_VLPRMTOT)
            {

                /*" -4388- ADD 1 TO UP-VLMAIOR */
                WS_AUX_WORK.UP_VLMAIOR.Value = WS_AUX_WORK.UP_VLMAIOR + 1;

                /*" -4391- PERFORM R2250-00-UPDATE-V0BILHETE. */

                R2250_00_UPDATE_V0BILHETE_SECTION();
            }


            /*" -4394- PERFORM R2850-00-DELETE-V0ERRO. */

            R2850_00_DELETE_V0ERRO_SECTION();

            /*" -4397- PERFORM R1510-00-SELECT-V0ERRO. */

            R1510_00_SELECT_V0ERRO_SECTION();

            /*" -4398- IF V0ERRO-COUNT EQUAL ZEROS */

            if (V0ERRO_COUNT == 00)
            {

                /*" -4399- MOVE '0' TO V0BILH-SITUACAO */
                _.Move("0", V0BILH_SITUACAO);

                /*" -4400- ADD 1 TO LB-VLMAIOR */
                WS_AUX_WORK.LB_VLMAIOR.Value = WS_AUX_WORK.LB_VLMAIOR + 1;

                /*" -4401- PERFORM R2500-00-UPDATE-V0BILHETE */

                R2500_00_UPDATE_V0BILHETE_SECTION();

                /*" -4402- ELSE */
            }
            else
            {


                /*" -4402- ADD 1 TO DP-VLMAIOR. */
                WS_AUX_WORK.DP_VLMAIOR.Value = WS_AUX_WORK.DP_VLMAIOR + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3010-00-DECLARE-V0COBERTURA-SECTION */
        private void R3010_00_DECLARE_V0COBERTURA_SECTION()
        {
            /*" -4413- MOVE '3010' TO WNR-EXEC-SQL. */
            _.Move("3010", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4415- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4432- PERFORM R3010_00_DECLARE_V0COBERTURA_DB_DECLARE_1 */

            R3010_00_DECLARE_V0COBERTURA_DB_DECLARE_1();

            /*" -4434- PERFORM R3010_00_DECLARE_V0COBERTURA_DB_OPEN_1 */

            R3010_00_DECLARE_V0COBERTURA_DB_OPEN_1();

            /*" -4438- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4439- DISPLAY 'R3010-00 - PROBLEMAS DECLARE (V0COBERTURA)' */
                _.Display($"R3010-00 - PROBLEMAS DECLARE (V0COBERTURA)");

                /*" -4439- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3010-00-DECLARE-V0COBERTURA-DB-OPEN-1 */
        public void R3010_00_DECLARE_V0COBERTURA_DB_OPEN_1()
        {
            /*" -4434- EXEC SQL OPEN V0COBERTURA END-EXEC. */

            V0COBERTURA.Open();

        }

        [StopWatch]
        /*" R7100-00-DECLARE-V1BILHETE-DB-DECLARE-1 */
        public void R7100_00_DECLARE_V1BILHETE_DB_DECLARE_1()
        {
            /*" -4992- EXEC SQL DECLARE V1BILHETE CURSOR FOR SELECT NUMBIL , SITUACAO , COD_USUARIO , DTCANCEL , RAMO FROM SEGUROS.V0BILHETE WHERE SITUACAO BETWEEN '0' AND '4' AND DTMOVTO >= :V0SIST-DTLIBERA FOR UPDATE OF SITUACAO , COD_USUARIO , DTCANCEL , RAMO END-EXEC. */
            V1BILHETE = new CB0009B_V1BILHETE(true);
            string GetQuery_V1BILHETE()
            {
                var query = @$"SELECT NUMBIL
							, 
							SITUACAO
							, 
							COD_USUARIO
							, 
							DTCANCEL
							, 
							RAMO 
							FROM SEGUROS.V0BILHETE 
							WHERE SITUACAO BETWEEN '0' AND '4' 
							AND DTMOVTO >= '{V0SIST_DTLIBERA}'";

                return query;
            }
            V1BILHETE.GetQueryEvent += GetQuery_V1BILHETE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/

        [StopWatch]
        /*" R3020-00-FETCH-V0COBERTURA-SECTION */
        private void R3020_00_FETCH_V0COBERTURA_SECTION()
        {
            /*" -4450- MOVE '3020' TO WNR-EXEC-SQL. */
            _.Move("3020", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4452- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4456- PERFORM R3020_00_FETCH_V0COBERTURA_DB_FETCH_1 */

            R3020_00_FETCH_V0COBERTURA_DB_FETCH_1();

            /*" -4460- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4460- PERFORM R3020_00_FETCH_V0COBERTURA_DB_CLOSE_1 */

                R3020_00_FETCH_V0COBERTURA_DB_CLOSE_1();

                /*" -4462- MOVE 'S' TO WFIM-COBERTURA */
                _.Move("S", WS_AUX_WORK.WFIM_COBERTURA);

                /*" -4464- MOVE ZEROS TO V0BCOB-CODOPCAO V0BCOB-VLPRMTOT */
                _.Move(0, V0BCOB_CODOPCAO, V0BCOB_VLPRMTOT);

                /*" -4467- GO TO R3020-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4468- IF VIND-VLPRMTOT LESS ZEROS */

            if (VIND_VLPRMTOT < 00)
            {

                /*" -4470- MOVE ZEROS TO V0BCOB-CODOPCAO V0BCOB-VLPRMTOT */
                _.Move(0, V0BCOB_CODOPCAO, V0BCOB_VLPRMTOT);

                /*" -4473- GO TO R3020-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4473- PERFORM R3020_00_FETCH_V0COBERTURA_DB_CLOSE_2 */

            R3020_00_FETCH_V0COBERTURA_DB_CLOSE_2();

            /*" -4475- MOVE 'S' TO WFIM-COBERTURA. */
            _.Move("S", WS_AUX_WORK.WFIM_COBERTURA);

            /*" -4475- MOVE 'S' TO FLAG-COBERT. */
            _.Move("S", WS_AUX_WORK.FLAG_COBERT);

        }

        [StopWatch]
        /*" R3020-00-FETCH-V0COBERTURA-DB-FETCH-1 */
        public void R3020_00_FETCH_V0COBERTURA_DB_FETCH_1()
        {
            /*" -4456- EXEC SQL FETCH V0COBERTURA INTO :V0BCOB-CODOPCAO , :V0BCOB-DTINIVIG , :V0BCOB-VLPRMTOT:VIND-VLPRMTOT END-EXEC. */

            if (V0COBERTURA.Fetch())
            {
                _.Move(V0COBERTURA.V0BCOB_CODOPCAO, V0BCOB_CODOPCAO);
                _.Move(V0COBERTURA.V0BCOB_DTINIVIG, V0BCOB_DTINIVIG);
                _.Move(V0COBERTURA.V0BCOB_VLPRMTOT, V0BCOB_VLPRMTOT);
                _.Move(V0COBERTURA.VIND_VLPRMTOT, VIND_VLPRMTOT);
            }

        }

        [StopWatch]
        /*" R3020-00-FETCH-V0COBERTURA-DB-CLOSE-1 */
        public void R3020_00_FETCH_V0COBERTURA_DB_CLOSE_1()
        {
            /*" -4460- EXEC SQL CLOSE V0COBERTURA END-EXEC */

            V0COBERTURA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/

        [StopWatch]
        /*" R3020-00-FETCH-V0COBERTURA-DB-CLOSE-2 */
        public void R3020_00_FETCH_V0COBERTURA_DB_CLOSE_2()
        {
            /*" -4473- EXEC SQL CLOSE V0COBERTURA END-EXEC */

            V0COBERTURA.Close();

        }

        [StopWatch]
        /*" R4000-00-TRATA-FOLLOWUP-SECTION */
        private void R4000_00_TRATA_FOLLOWUP_SECTION()
        {
            /*" -4486- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4488- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4489- IF V0FOLL-SITUACAO NOT EQUAL '0' */

            if (V0FOLL_SITUACAO != "0")
            {

                /*" -4490- PERFORM R4050-00-TRATA-COBRCAP */

                R4050_00_TRATA_COBRCAP_SECTION();

                /*" -4493- GO TO R4000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4494- MOVE ZEROS TO WS-VLRCAP */
            _.Move(0, WS_AUX_WORK.WS_VLRCAP);

            /*" -4497- COMPUTE WS-VLRCAP EQUAL V0FOLL-VLPREMIO + V0RCAP-VLRCAP. */
            WS_AUX_WORK.WS_VLRCAP.Value = V0FOLL_VLPREMIO + V0RCAP_VLRCAP;

            /*" -4498- MOVE WS-VLRCAP TO V0RCAP-VLRCAP */
            _.Move(WS_AUX_WORK.WS_VLRCAP, V0RCAP_VLRCAP);

            /*" -4501- PERFORM R4050-00-TRATA-COBRCAP. */

            R4050_00_TRATA_COBRCAP_SECTION();

            /*" -4502- IF V0FOLL-SITUACAO NOT EQUAL '*' */

            if (V0FOLL_SITUACAO != "*")
            {

                /*" -4503- PERFORM R4100-00-INSERT-V0RCAPCOMP */

                R4100_00_INSERT_V0RCAPCOMP_SECTION();

                /*" -4504- PERFORM R4150-00-UPDATE-V0RCAP */

                R4150_00_UPDATE_V0RCAP_SECTION();

                /*" -4505- PERFORM R4200-00-UPDATE-V0FOLLOWUP */

                R4200_00_UPDATE_V0FOLLOWUP_SECTION();

                /*" -4506- ADD 1 TO UP-FOLLOW */
                WS_AUX_WORK.UP_FOLLOW.Value = WS_AUX_WORK.UP_FOLLOW + 1;

                /*" -4509- GO TO R4000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4510- MOVE V0CFEN-VLRCAP TO V0RCAP-VLRCAP */
            _.Move(V0CFEN_VLRCAP, V0RCAP_VLRCAP);

            /*" -4510- PERFORM R4050-00-TRATA-COBRCAP. */

            R4050_00_TRATA_COBRCAP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4050-00-TRATA-COBRCAP-SECTION */
        private void R4050_00_TRATA_COBRCAP_SECTION()
        {
            /*" -4521- MOVE '4050' TO WNR-EXEC-SQL. */
            _.Move("4050", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4523- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4526- COMPUTE V0BCOB-VLPRMTOT1 EQUAL V0RCAP-VLRCAP - WS-VLDIFE. */
            V0BCOB_VLPRMTOT1.Value = V0RCAP_VLRCAP - WS_AUX_WORK.WS_VLDIFE;

            /*" -4530- COMPUTE V0BCOB-VLPRMTOT2 EQUAL V0RCAP-VLRCAP + WS-VLDIFE. */
            V0BCOB_VLPRMTOT2.Value = V0RCAP_VLRCAP + WS_AUX_WORK.WS_VLDIFE;

            /*" -4532- IF (VIND-COD-PRODUTO LESS ZEROS) OR (V0BILH-COD-PRODUTO EQUAL ZEROS) */

            if ((VIND_COD_PRODUTO < 00) || (V0BILH_COD_PRODUTO == 00))
            {

                /*" -4533- PERFORM R0900-00-SELECT-V0COBERTURA */

                R0900_00_SELECT_V0COBERTURA_SECTION();

                /*" -4534- ELSE */
            }
            else
            {


                /*" -4535- IF NOVOS-ACESSOS */

                if (NIVEIS_88.N88_NOVOS_ACESSOS["NOVOS_ACESSOS"])
                {

                    /*" -4536- DISPLAY 'NOVOS ACESSOS-3: ' N88-NOVOS-ACESSOS */
                    _.Display($"NOVOS ACESSOS-3: {NIVEIS_88.N88_NOVOS_ACESSOS}");

                    /*" -4537- MOVE 'S' TO FLAG-COBERT */
                    _.Move("S", WS_AUX_WORK.FLAG_COBERT);

                    /*" -4539- MOVE LK-0071-I-COD-OPC-PLANO TO V0BCOB-CODOPCAO */
                    _.Move(GE0071W.LK_0071_I_COD_OPC_PLANO, V0BCOB_CODOPCAO);

                    /*" -4540- MOVE V0BILH-DTVENDA TO V0BCOB-DTINIVIG */
                    _.Move(V0BILH_DTVENDA, V0BCOB_DTINIVIG);

                    /*" -4542- MOVE LK-0071-S-VLR-INI-PREMIO TO V0BCOB-VLPRMTOT */
                    _.Move(GE0071W.LK_0071_S_VLR_INI_PREMIO, V0BCOB_VLPRMTOT);

                    /*" -4543- ELSE */
                }
                else
                {


                    /*" -4544- DISPLAY 'R0940-00 (3)' */
                    _.Display($"R0940-00 (3)");

                    /*" -4545- PERFORM R0940-00-SELECT-V0COBERTURA */

                    R0940_00_SELECT_V0COBERTURA_SECTION();

                    /*" -4546- END-IF */
                }


                /*" -4549- END-IF */
            }


            /*" -4550- IF V0BILH-OPCOBER NOT EQUAL V0BCOB-CODOPCAO */

            if (V0BILH_OPCOBER != V0BCOB_CODOPCAO)
            {

                /*" -4551- DISPLAY '-------------- ATENCAO ---------------' */
                _.Display($"-------------- ATENCAO ---------------");

                /*" -4552- DISPLAY '-------------- ATENCAO ---------------' */
                _.Display($"-------------- ATENCAO ---------------");

                /*" -4553- DISPLAY '-------------- ATENCAO ---------------' */
                _.Display($"-------------- ATENCAO ---------------");

                /*" -4554- DISPLAY 'TROCOU A OPCAO DE COBERTURA DO BILHETE' */
                _.Display($"TROCOU A OPCAO DE COBERTURA DO BILHETE");

                /*" -4555- DISPLAY 'PARAGRAFO: R4050-00-TRATA-COBRCAP     ' */
                _.Display($"PARAGRAFO: R4050-00-TRATA-COBRCAP     ");

                /*" -4556- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -4557- DISPLAY '------------- VERIFICAR --------------' */
                _.Display($"------------- VERIFICAR --------------");

                /*" -4559- END-IF */
            }


            /*" -4560- IF V0BCOB-CODOPCAO EQUAL ZEROS */

            if (V0BCOB_CODOPCAO == 00)
            {

                /*" -4561- MOVE '*' TO V0FOLL-SITUACAO */
                _.Move("*", V0FOLL_SITUACAO);

                /*" -4562- GO TO R4050-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4050_99_SAIDA*/ //GOTO
                return;

                /*" -4563- ELSE */
            }
            else
            {


                /*" -4566- MOVE SPACES TO V0FOLL-SITUACAO. */
                _.Move("", V0FOLL_SITUACAO);
            }


            /*" -4567- ADD 1 TO AC-COBRCAP */
            WS_AUX_WORK.AC_COBRCAP.Value = WS_AUX_WORK.AC_COBRCAP + 1;

            /*" -4567- PERFORM R2250-00-UPDATE-V0BILHETE. */

            R2250_00_UPDATE_V0BILHETE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4050_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-INSERT-V0RCAPCOMP-SECTION */
        private void R4100_00_INSERT_V0RCAPCOMP_SECTION()
        {
            /*" -4578- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4580- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4581- MOVE V0RCOM-NRRCAP TO V0RCOM-NRRCAPCO */
            _.Move(V0RCOM_NRRCAP, V0RCOM_NRRCAPCO);

            /*" -4582- MOVE 100 TO V0RCOM-OPERACAO */
            _.Move(100, V0RCOM_OPERACAO);

            /*" -4583- MOVE V0SIST-DTMOVABE TO V0RCOM-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0RCOM_DTMOVTO);

            /*" -4584- MOVE '0' TO V0RCOM-SITUACAO */
            _.Move("0", V0RCOM_SITUACAO);

            /*" -4588- MOVE ZEROS TO V0RCOM-CODEMP VIND-CODEMP. */
            _.Move(0, V0RCOM_CODEMP, VIND_CODEMP);

            /*" -4606- PERFORM R4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1 */

            R4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1();

            /*" -4609- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4610- DISPLAY 'R4100-00 - PROBLEMAS INSERT (V0RCAPCOMP) ' */
                _.Display($"R4100-00 - PROBLEMAS INSERT (V0RCAPCOMP) ");

                /*" -4610- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4100-00-INSERT-V0RCAPCOMP-DB-INSERT-1 */
        public void R4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -4606- EXEC SQL INSERT INTO SEGUROS.V0RCAPCOMP VALUES (:V0RCOM-FONTE , :V0RCOM-NRRCAP , :V0RCOM-NRRCAPCO , :V0RCOM-OPERACAO , :V0RCOM-DTMOVTO , CURRENT TIME , :V0RCOM-SITUACAO , :V0FOLL-BCOAVISO , :V0FOLL-AGEAVISO , :V0FOLL-NRAVISO , :V0FOLL-VLPREMIO , :V0FOLL-DTQITBCO , :V0RCOM-DTCADAST , :V0RCOM-SITCONTB , :V0RCOM-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP) END-EXEC. */

            var r4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 = new R4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1()
            {
                V0RCOM_FONTE = V0RCOM_FONTE.ToString(),
                V0RCOM_NRRCAP = V0RCOM_NRRCAP.ToString(),
                V0RCOM_NRRCAPCO = V0RCOM_NRRCAPCO.ToString(),
                V0RCOM_OPERACAO = V0RCOM_OPERACAO.ToString(),
                V0RCOM_DTMOVTO = V0RCOM_DTMOVTO.ToString(),
                V0RCOM_SITUACAO = V0RCOM_SITUACAO.ToString(),
                V0FOLL_BCOAVISO = V0FOLL_BCOAVISO.ToString(),
                V0FOLL_AGEAVISO = V0FOLL_AGEAVISO.ToString(),
                V0FOLL_NRAVISO = V0FOLL_NRAVISO.ToString(),
                V0FOLL_VLPREMIO = V0FOLL_VLPREMIO.ToString(),
                V0FOLL_DTQITBCO = V0FOLL_DTQITBCO.ToString(),
                V0RCOM_DTCADAST = V0RCOM_DTCADAST.ToString(),
                V0RCOM_SITCONTB = V0RCOM_SITCONTB.ToString(),
                V0RCOM_CODEMP = V0RCOM_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
            };

            R4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1.Execute(r4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4150-00-UPDATE-V0RCAP-SECTION */
        private void R4150_00_UPDATE_V0RCAP_SECTION()
        {
            /*" -4621- MOVE '4150' TO WNR-EXEC-SQL. */
            _.Move("4150", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4624- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4627- MOVE WS-VLRCAP TO V0RCAP-VLRCAP. */
            _.Move(WS_AUX_WORK.WS_VLRCAP, V0RCAP_VLRCAP);

            /*" -4631- PERFORM R4150_00_UPDATE_V0RCAP_DB_UPDATE_1 */

            R4150_00_UPDATE_V0RCAP_DB_UPDATE_1();

            /*" -4634- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4635- DISPLAY 'R4150-00 - PROBLEMAS UPDATE (V0RCAP)      ' */
                _.Display($"R4150-00 - PROBLEMAS UPDATE (V0RCAP)      ");

                /*" -4635- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4150-00-UPDATE-V0RCAP-DB-UPDATE-1 */
        public void R4150_00_UPDATE_V0RCAP_DB_UPDATE_1()
        {
            /*" -4631- EXEC SQL UPDATE SEGUROS.V0RCAP SET VLRCAP = :V0RCAP-VLRCAP WHERE NRRCAP = :V0RCAP-NRRCAP END-EXEC. */

            var r4150_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1 = new R4150_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1()
            {
                V0RCAP_VLRCAP = V0RCAP_VLRCAP.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
            };

            R4150_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1.Execute(r4150_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4150_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-UPDATE-V0FOLLOWUP-SECTION */
        private void R4200_00_UPDATE_V0FOLLOWUP_SECTION()
        {
            /*" -4646- MOVE '4200' TO WNR-EXEC-SQL. */
            _.Move("4200", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4649- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4655- PERFORM R4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1 */

            R4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1();

            /*" -4658- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4659- DISPLAY 'R4200-00 - PROBLEMAS UPDATE (V0FOLLOWUP)  ' */
                _.Display($"R4200-00 - PROBLEMAS UPDATE (V0FOLLOWUP)  ");

                /*" -4659- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4200-00-UPDATE-V0FOLLOWUP-DB-UPDATE-1 */
        public void R4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1()
        {
            /*" -4655- EXEC SQL UPDATE SEGUROS.V0FOLLOWUP SET SITUACAO = '2' , OPERACAO = 403 , DTLIBER = :V0SIST-DTMOVABE WHERE NUM_APOLICE = :V0FOLL-NUMAPOL END-EXEC. */

            var r4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1_Update1 = new R4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1_Update1()
            {
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
                V0FOLL_NUMAPOL = V0FOLL_NUMAPOL.ToString(),
            };

            R4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1_Update1.Execute(r4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-MONTA-FENAE-SECTION */
        private void R6000_00_MONTA_FENAE_SECTION()
        {
            /*" -4670- MOVE '6000' TO WNR-EXEC-SQL. */
            _.Move("6000", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4673- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4674- IF V0RCAP-AGECOBR EQUAL ZEROS */

            if (V0RCAP_AGECOBR == 00)
            {

                /*" -4675- MOVE V0BILH-AGECOBR TO V0CFEN-AGECOBR */
                _.Move(V0BILH_AGECOBR, V0CFEN_AGECOBR);

                /*" -4676- ELSE */
            }
            else
            {


                /*" -4678- MOVE V0RCAP-AGECOBR TO V0CFEN-AGECOBR. */
                _.Move(V0RCAP_AGECOBR, V0CFEN_AGECOBR);
            }


            /*" -4679- MOVE ZEROS TO V0CFEN-CODEMP */
            _.Move(0, V0CFEN_CODEMP);

            /*" -4680- MOVE V0BILH-NUMBIL TO V0CFEN-NUMBIL */
            _.Move(V0BILH_NUMBIL, V0CFEN_NUMBIL);

            /*" -4681- MOVE ZEROS TO V0CFEN-VALADT */
            _.Move(0, V0CFEN_VALADT);

            /*" -4682- MOVE V0BILH-MATRICULA TO V0CFEN-MATRICULA */
            _.Move(V0BILH_MATRICULA, V0CFEN_MATRICULA);

            /*" -4683- MOVE V0BILH-AGECONTA TO V0CFEN-AGECONTA */
            _.Move(V0BILH_AGECONTA, V0CFEN_AGECONTA);

            /*" -4684- MOVE V0BILH-OPECONTA TO V0CFEN-OPECONTA */
            _.Move(V0BILH_OPECONTA, V0CFEN_OPECONTA);

            /*" -4685- MOVE V0BILH-NUMCONTA TO V0CFEN-NUMCONTA */
            _.Move(V0BILH_NUMCONTA, V0CFEN_NUMCONTA);

            /*" -4686- MOVE V0BILH-DIGCONTA TO V0CFEN-DIGCONTA */
            _.Move(V0BILH_DIGCONTA, V0CFEN_DIGCONTA);

            /*" -4690- MOVE ZEROS TO V0CFEN-AGECTADEB V0CFEN-OPRCTADEB V0CFEN-NUMCTADEB V0CFEN-DIGCTADEB */
            _.Move(0, V0CFEN_AGECTADEB, V0CFEN_OPRCTADEB, V0CFEN_NUMCTADEB, V0CFEN_DIGCTADEB);

            /*" -4691- MOVE SPACES TO V0CFEN-SINDICO */
            _.Move("", V0CFEN_SINDICO);

            /*" -4692- MOVE V0RCAP-VLRCAP TO V0CFEN-VLRCAP */
            _.Move(V0RCAP_VLRCAP, V0CFEN_VLRCAP);

            /*" -4693- MOVE V0SIST-DTMOVABE TO V0CFEN-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0CFEN_DTMOVTO);

            /*" -4694- MOVE '0' TO V0CFEN-SITUACAO */
            _.Move("0", V0CFEN_SITUACAO);

            /*" -4698- MOVE ZEROS TO V0CFEN-NRMATRGER V0CFEN-VALADTGER V0CFEN-NRMATRSUN V0CFEN-VALADTSUN */
            _.Move(0, V0CFEN_NRMATRGER, V0CFEN_VALADTGER, V0CFEN_NRMATRSUN, V0CFEN_VALADTSUN);

            /*" -4702- MOVE SPACES TO V0CFEN-DTPAGGER V0CFEN-DTCANCEL V0CFEN-DTPAGSUN. */
            _.Move("", V0CFEN_DTPAGGER, V0CFEN_DTCANCEL, V0CFEN_DTPAGSUN);

            /*" -4705- MOVE V0RCOM-DATARCAP TO V0CFEN-DTCREDITO V0CFEN-DTQITBCO. */
            _.Move(V0RCOM_DATARCAP, V0CFEN_DTCREDITO, V0CFEN_DTQITBCO);

            /*" -4714- MOVE -1 TO VIND-NRMATRGER VIND-VALADTGER VIND-DTPAGGER VIND-DTCANCEL VIND-NRMATRSUN VIND-VALADTSUN VIND-DTPAGSUN. */
            _.Move(-1, VIND_NRMATRGER, VIND_VALADTGER, VIND_DTPAGGER, VIND_DTCANCEL, VIND_NRMATRSUN, VIND_VALADTSUN, VIND_DTPAGSUN);

            /*" -4717- PERFORM R6100-00-INSERT-V0COMISFENAE. */

            R6100_00_INSERT_V0COMISFENAE_SECTION();

            /*" -4718- IF V0CFEN-SITUACAO EQUAL '0' */

            if (V0CFEN_SITUACAO == "0")
            {

                /*" -4718- PERFORM R6500-00-TARIFA-BALCAO. */

                R6500_00_TARIFA_BALCAO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6100-00-INSERT-V0COMISFENAE-SECTION */
        private void R6100_00_INSERT_V0COMISFENAE_SECTION()
        {
            /*" -4729- MOVE '6100' TO WNR-EXEC-SQL. */
            _.Move("6100", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4732- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4761- PERFORM R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1 */

            R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1();

            /*" -4765- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4765- MOVE '*' TO V0CFEN-SITUACAO. */
                _.Move("*", V0CFEN_SITUACAO);
            }


        }

        [StopWatch]
        /*" R6100-00-INSERT-V0COMISFENAE-DB-INSERT-1 */
        public void R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1()
        {
            /*" -4761- EXEC SQL INSERT INTO SEGUROS.V0COMISSAO_FENAE VALUES (:V0CFEN-CODEMP , :V0CFEN-NUMBIL , :V0CFEN-AGECOBR , :V0CFEN-VALADT , :V0CFEN-DTCREDITO , :V0CFEN-MATRICULA , :V0CFEN-AGECONTA , :V0CFEN-OPECONTA , :V0CFEN-NUMCONTA , :V0CFEN-DIGCONTA , :V0CFEN-AGECTADEB , :V0CFEN-OPRCTADEB , :V0CFEN-NUMCTADEB , :V0CFEN-DIGCTADEB , :V0CFEN-SINDICO , :V0CFEN-DTQITBCO , :V0CFEN-VLRCAP , :V0CFEN-DTMOVTO , :V0CFEN-SITUACAO , CURRENT TIMESTAMP , :V0CFEN-NRMATRGER:VIND-NRMATRGER , :V0CFEN-VALADTGER:VIND-VALADTGER , :V0CFEN-DTPAGGER:VIND-DTPAGGER , :V0CFEN-DTCANCEL:VIND-DTCANCEL , :V0CFEN-NRMATRSUN:VIND-NRMATRSUN , :V0CFEN-VALADTSUN:VIND-VALADTSUN , :V0CFEN-DTPAGSUN:VIND-DTPAGSUN) END-EXEC. */

            var r6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1 = new R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1()
            {
                V0CFEN_CODEMP = V0CFEN_CODEMP.ToString(),
                V0CFEN_NUMBIL = V0CFEN_NUMBIL.ToString(),
                V0CFEN_AGECOBR = V0CFEN_AGECOBR.ToString(),
                V0CFEN_VALADT = V0CFEN_VALADT.ToString(),
                V0CFEN_DTCREDITO = V0CFEN_DTCREDITO.ToString(),
                V0CFEN_MATRICULA = V0CFEN_MATRICULA.ToString(),
                V0CFEN_AGECONTA = V0CFEN_AGECONTA.ToString(),
                V0CFEN_OPECONTA = V0CFEN_OPECONTA.ToString(),
                V0CFEN_NUMCONTA = V0CFEN_NUMCONTA.ToString(),
                V0CFEN_DIGCONTA = V0CFEN_DIGCONTA.ToString(),
                V0CFEN_AGECTADEB = V0CFEN_AGECTADEB.ToString(),
                V0CFEN_OPRCTADEB = V0CFEN_OPRCTADEB.ToString(),
                V0CFEN_NUMCTADEB = V0CFEN_NUMCTADEB.ToString(),
                V0CFEN_DIGCTADEB = V0CFEN_DIGCTADEB.ToString(),
                V0CFEN_SINDICO = V0CFEN_SINDICO.ToString(),
                V0CFEN_DTQITBCO = V0CFEN_DTQITBCO.ToString(),
                V0CFEN_VLRCAP = V0CFEN_VLRCAP.ToString(),
                V0CFEN_DTMOVTO = V0CFEN_DTMOVTO.ToString(),
                V0CFEN_SITUACAO = V0CFEN_SITUACAO.ToString(),
                V0CFEN_NRMATRGER = V0CFEN_NRMATRGER.ToString(),
                VIND_NRMATRGER = VIND_NRMATRGER.ToString(),
                V0CFEN_VALADTGER = V0CFEN_VALADTGER.ToString(),
                VIND_VALADTGER = VIND_VALADTGER.ToString(),
                V0CFEN_DTPAGGER = V0CFEN_DTPAGGER.ToString(),
                VIND_DTPAGGER = VIND_DTPAGGER.ToString(),
                V0CFEN_DTCANCEL = V0CFEN_DTCANCEL.ToString(),
                VIND_DTCANCEL = VIND_DTCANCEL.ToString(),
                V0CFEN_NRMATRSUN = V0CFEN_NRMATRSUN.ToString(),
                VIND_NRMATRSUN = VIND_NRMATRSUN.ToString(),
                V0CFEN_VALADTSUN = V0CFEN_VALADTSUN.ToString(),
                VIND_VALADTSUN = VIND_VALADTSUN.ToString(),
                V0CFEN_DTPAGSUN = V0CFEN_DTPAGSUN.ToString(),
                VIND_DTPAGSUN = VIND_DTPAGSUN.ToString(),
            };

            R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1.Execute(r6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R6300-00-SELECIONA-PRODUTO-SECTION */
        private void R6300_00_SELECIONA_PRODUTO_SECTION()
        {
            /*" -4802- MOVE '6300' TO WNR-EXEC-SQL. */
            _.Move("6300", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4804- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4815- PERFORM R6300_00_SELECIONA_PRODUTO_DB_SELECT_1 */

            R6300_00_SELECIONA_PRODUTO_DB_SELECT_1();

            /*" -4818- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4819- DISPLAY 'R6300-00 (ERRO BUSCA BILHETE_COBERTURA)' */
                _.Display($"R6300-00 (ERRO BUSCA BILHETE_COBERTURA)");

                /*" -4820- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -4821- DISPLAY 'RAMO   : ' V0BILH-RAMO */
                _.Display($"RAMO   : {V0BILH_RAMO}");

                /*" -4822- DISPLAY 'OPC_COB: ' V0BILH-OPCOBER */
                _.Display($"OPC_COB: {V0BILH_OPCOBER}");

                /*" -4823- DISPLAY 'DT QUITACAO: ' V0BILH-DTQITBCO */
                _.Display($"DT QUITACAO: {V0BILH_DTQITBCO}");

                /*" -4824- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4825- END-IF. */
            }


        }

        [StopWatch]
        /*" R6300-00-SELECIONA-PRODUTO-DB-SELECT-1 */
        public void R6300_00_SELECIONA_PRODUTO_DB_SELECT_1()
        {
            /*" -4815- EXEC SQL SELECT COD_PRODUTO INTO :V0BILP-CODPRODU FROM SEGUROS.BILHETE_COBERTURA WHERE COD_EMPRESA = 0 AND RAMO_COBERTURA = :V0BILH-RAMO AND MODALI_COBERTURA = 0 AND COD_OPCAO_PLANO = :V0BILH-OPCOBER AND IDE_COBERTURA = '1' AND DATA_INIVIGENCIA <= :V0BILH-DTQITBCO AND DATA_TERVIGENCIA >= :V0BILH-DTQITBCO END-EXEC. */

            var r6300_00_SELECIONA_PRODUTO_DB_SELECT_1_Query1 = new R6300_00_SELECIONA_PRODUTO_DB_SELECT_1_Query1()
            {
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V0BILH_OPCOBER = V0BILH_OPCOBER.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
            };

            var executed_1 = R6300_00_SELECIONA_PRODUTO_DB_SELECT_1_Query1.Execute(r6300_00_SELECIONA_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BILP_CODPRODU, V0BILP_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R6500-00-TARIFA-BALCAO-SECTION */
        private void R6500_00_TARIFA_BALCAO_SECTION()
        {
            /*" -4833- MOVE '6500' TO WNR-EXEC-SQL. */
            _.Move("6500", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4835- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4836- MOVE ZEROS TO V0TRBL-CODEMP */
            _.Move(0, V0TRBL_CODEMP);

            /*" -4837- MOVE 9999999 TO V0TRBL-MATRICULA */
            _.Move(9999999, V0TRBL_MATRICULA);

            /*" -4838- MOVE '5' TO V0TRBL-TIPOFUNC */
            _.Move("5", V0TRBL_TIPOFUNC);

            /*" -4839- MOVE V0BILH-NUMBIL TO V0TRBL-NRCERTIF */
            _.Move(V0BILH_NUMBIL, V0TRBL_NRCERTIF);

            /*" -4840- MOVE V0SIST-DTMOVABE TO V0TRBL-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0TRBL_DTMOVTO);

            /*" -4841- MOVE '0' TO V0TRBL-SITUACAO */
            _.Move("0", V0TRBL_SITUACAO);

            /*" -4842- MOVE V0RCOM-BCOAVISO TO V0TRBL-BCOAVISO */
            _.Move(V0RCOM_BCOAVISO, V0TRBL_BCOAVISO);

            /*" -4843- MOVE V0RCOM-AGEAVISO TO V0TRBL-AGEAVISO */
            _.Move(V0RCOM_AGEAVISO, V0TRBL_AGEAVISO);

            /*" -4845- MOVE V0RCOM-NRAVISO TO V0TRBL-NRAVISO. */
            _.Move(V0RCOM_NRAVISO, V0TRBL_NRAVISO);

            /*" -4846- IF V0BILH-RAMO EQUAL 72 OR 14 */

            if (V0BILH_RAMO.In("72", "14"))
            {

                /*" -4847- MOVE 7106 TO V0TRBL-CODPRODU */
                _.Move(7106, V0TRBL_CODPRODU);

                /*" -4848- ELSE */
            }
            else
            {


                /*" -4851- MOVE 8201 TO V0TRBL-CODPRODU. */
                _.Move(8201, V0TRBL_CODPRODU);
            }


            /*" -4852- MOVE V0BILH-FONTE TO V0TRBL-FONTE */
            _.Move(V0BILH_FONTE, V0TRBL_FONTE);

            /*" -4853- MOVE V0CFEN-AGECOBR TO V0TRBL-AGECOBR */
            _.Move(V0CFEN_AGECOBR, V0TRBL_AGECOBR);

            /*" -4855- MOVE 9999 TO V0TRBL-ESCNEG. */
            _.Move(9999, V0TRBL_ESCNEG);

            /*" -4856- SET WS-AGE TO 1 */
            WS_AGE.Value = 1;

            /*" -4857- SEARCH WACEF-OCORREAGE */
            for (; WS_AGE < WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE.Items.Count; WS_AGE.Value++)
            {

                /*" -4859- WHEN V0TRBL-AGECOBR EQUAL WACEF-AGENCIA(WS-AGE) */

                if (V0TRBL_AGECOBR == WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA)
                {


                    /*" -4861- MOVE WACEF-ESCNEG(WS-AGE) TO V0TRBL-ESCNEG */
                    _.Move(WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_ESCNEG, V0TRBL_ESCNEG);

                    /*" -4862- MOVE WACEF-FONTE(WS-AGE) TO V0TRBL-FONTE  END-SEARCH. */
                    break;
                }
            }


            /*" -4866- IF V0BILH-DTMOVTO LESS '2000-01-17' */

            if (V0BILH_DTMOVTO < "2000-01-17")
            {

                /*" -4867- MOVE 1,00 TO V0TRBL-TARIFA */
                _.Move(1.00, V0TRBL_TARIFA);

                /*" -4868- MOVE 3,00 TO V0TRBL-BALCAO */
                _.Move(3.00, V0TRBL_BALCAO);

                /*" -4869- ELSE */
            }
            else
            {


                /*" -4870- IF V0BILH-DTMOVTO LESS '2000-03-09' */

                if (V0BILH_DTMOVTO < "2000-03-09")
                {

                    /*" -4871- MOVE 1,00 TO V0TRBL-TARIFA */
                    _.Move(1.00, V0TRBL_TARIFA);

                    /*" -4872- MOVE 3,65 TO V0TRBL-BALCAO */
                    _.Move(3.65, V0TRBL_BALCAO);

                    /*" -4873- ELSE */
                }
                else
                {


                    /*" -4874- MOVE 1,30 TO V0TRBL-TARIFA */
                    _.Move(1.30, V0TRBL_TARIFA);

                    /*" -4877- MOVE 3,65 TO V0TRBL-BALCAO. */
                    _.Move(3.65, V0TRBL_BALCAO);
                }

            }


            /*" -4879- PERFORM R6550-00-SELECT-TARIFA-BALCAO. */

            R6550_00_SELECT_TARIFA_BALCAO_SECTION();

            /*" -4880- IF V0ERRO-COUNT EQUAL ZEROS */

            if (V0ERRO_COUNT == 00)
            {

                /*" -4880- PERFORM R6700-00-INSERT-TARIFA-BALCAO. */

                R6700_00_INSERT_TARIFA_BALCAO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6500_99_SAIDA*/

        [StopWatch]
        /*" R6550-00-SELECT-TARIFA-BALCAO-SECTION */
        private void R6550_00_SELECT_TARIFA_BALCAO_SECTION()
        {
            /*" -4891- MOVE '6550' TO WNR-EXEC-SQL. */
            _.Move("6550", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4893- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4901- PERFORM R6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1 */

            R6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1();

            /*" -4904- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4905- MOVE ZEROS TO V0ERRO-COUNT */
                _.Move(0, V0ERRO_COUNT);

                /*" -4906- ELSE */
            }
            else
            {


                /*" -4907- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4908- DISPLAY 'R6550-00 - PROBLEMAS NO SELECT(TARIFA)   ' */
                    _.Display($"R6550-00 - PROBLEMAS NO SELECT(TARIFA)   ");

                    /*" -4909- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4910- ELSE */
                }
                else
                {


                    /*" -4911- IF VIND-COUNT LESS ZEROS */

                    if (VIND_COUNT < 00)
                    {

                        /*" -4911- MOVE ZEROS TO V0ERRO-COUNT. */
                        _.Move(0, V0ERRO_COUNT);
                    }

                }

            }


        }

        [StopWatch]
        /*" R6550-00-SELECT-TARIFA-BALCAO-DB-SELECT-1 */
        public void R6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1()
        {
            /*" -4901- EXEC SQL SELECT COUNT(*) INTO :V0ERRO-COUNT:VIND-COUNT FROM SEGUROS.TARIFA_BALCAO_CEF WHERE COD_EMPRESA = :V0TRBL-CODEMP AND NUM_MATRICULA = :V0TRBL-MATRICULA AND TIPO_FUNCIONARIO = :V0TRBL-TIPOFUNC AND NUM_CERTIFICADO = :V0TRBL-NRCERTIF END-EXEC. */

            var r6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1_Query1 = new R6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1_Query1()
            {
                V0TRBL_MATRICULA = V0TRBL_MATRICULA.ToString(),
                V0TRBL_TIPOFUNC = V0TRBL_TIPOFUNC.ToString(),
                V0TRBL_NRCERTIF = V0TRBL_NRCERTIF.ToString(),
                V0TRBL_CODEMP = V0TRBL_CODEMP.ToString(),
            };

            var executed_1 = R6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1_Query1.Execute(r6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ERRO_COUNT, V0ERRO_COUNT);
                _.Move(executed_1.VIND_COUNT, VIND_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6550_99_SAIDA*/

        [StopWatch]
        /*" R6700-00-INSERT-TARIFA-BALCAO-SECTION */
        private void R6700_00_INSERT_TARIFA_BALCAO_SECTION()
        {
            /*" -4922- MOVE '6700' TO WNR-EXEC-SQL. */
            _.Move("6700", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4924- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4942- PERFORM R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1 */

            R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1();

            /*" -4945- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4945- ADD 1 TO AC-TARIFA. */
                WS_AUX_WORK.AC_TARIFA.Value = WS_AUX_WORK.AC_TARIFA + 1;
            }


        }

        [StopWatch]
        /*" R6700-00-INSERT-TARIFA-BALCAO-DB-INSERT-1 */
        public void R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1()
        {
            /*" -4942- EXEC SQL INSERT INTO SEGUROS.TARIFA_BALCAO_CEF VALUES (:V0TRBL-CODEMP , :V0TRBL-MATRICULA , :V0TRBL-TIPOFUNC , :V0TRBL-NRCERTIF , :V0TRBL-DTMOVTO , :V0TRBL-CODPRODU , :V0TRBL-SITUACAO , :V0TRBL-FONTE , :V0TRBL-ESCNEG , :V0TRBL-AGECOBR , :V0TRBL-BCOAVISO , :V0TRBL-AGEAVISO , :V0TRBL-NRAVISO , :V0TRBL-TARIFA , :V0TRBL-BALCAO , CURRENT TIMESTAMP) END-EXEC. */

            var r6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1 = new R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1()
            {
                V0TRBL_CODEMP = V0TRBL_CODEMP.ToString(),
                V0TRBL_MATRICULA = V0TRBL_MATRICULA.ToString(),
                V0TRBL_TIPOFUNC = V0TRBL_TIPOFUNC.ToString(),
                V0TRBL_NRCERTIF = V0TRBL_NRCERTIF.ToString(),
                V0TRBL_DTMOVTO = V0TRBL_DTMOVTO.ToString(),
                V0TRBL_CODPRODU = V0TRBL_CODPRODU.ToString(),
                V0TRBL_SITUACAO = V0TRBL_SITUACAO.ToString(),
                V0TRBL_FONTE = V0TRBL_FONTE.ToString(),
                V0TRBL_ESCNEG = V0TRBL_ESCNEG.ToString(),
                V0TRBL_AGECOBR = V0TRBL_AGECOBR.ToString(),
                V0TRBL_BCOAVISO = V0TRBL_BCOAVISO.ToString(),
                V0TRBL_AGEAVISO = V0TRBL_AGEAVISO.ToString(),
                V0TRBL_NRAVISO = V0TRBL_NRAVISO.ToString(),
                V0TRBL_TARIFA = V0TRBL_TARIFA.ToString(),
                V0TRBL_BALCAO = V0TRBL_BALCAO.ToString(),
            };

            R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1.Execute(r6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6700_99_SAIDA*/

        [StopWatch]
        /*" R7000-00-INPUT-SORT-SECTION */
        private void R7000_00_INPUT_SORT_SECTION()
        {
            /*" -4956- MOVE '7000' TO WNR-EXEC-SQL. */
            _.Move("7000", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4958- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4959- MOVE SPACES TO WFIM-V1BILHETE */
            _.Move("", WS_AUX_WORK.WFIM_V1BILHETE);

            /*" -4961- PERFORM R7100-00-DECLARE-V1BILHETE. */

            R7100_00_DECLARE_V1BILHETE_SECTION();

            /*" -4963- PERFORM R7110-00-FETCH-V1BILHETE. */

            R7110_00_FETCH_V1BILHETE_SECTION();

            /*" -4967- PERFORM R7150-00-PROCESSA-V1BILHETE UNTIL WFIM-V1BILHETE NOT EQUAL SPACES. */

            while (!(!WS_AUX_WORK.WFIM_V1BILHETE.IsEmpty()))
            {

                R7150_00_PROCESSA_V1BILHETE_SECTION();
            }

            /*" -4967- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7100-00-DECLARE-V1BILHETE-SECTION */
        private void R7100_00_DECLARE_V1BILHETE_SECTION()
        {
            /*" -4977- MOVE '7100' TO WNR-EXEC-SQL. */
            _.Move("7100", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4979- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4992- PERFORM R7100_00_DECLARE_V1BILHETE_DB_DECLARE_1 */

            R7100_00_DECLARE_V1BILHETE_DB_DECLARE_1();

            /*" -4995- PERFORM R7100_00_DECLARE_V1BILHETE_DB_OPEN_1 */

            R7100_00_DECLARE_V1BILHETE_DB_OPEN_1();

            /*" -4999- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5000- DISPLAY 'R7100-00 - PROBLEMAS DECLARE (V1BILHETE)  ' */
                _.Display($"R7100-00 - PROBLEMAS DECLARE (V1BILHETE)  ");

                /*" -5000- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7100-00-DECLARE-V1BILHETE-DB-OPEN-1 */
        public void R7100_00_DECLARE_V1BILHETE_DB_OPEN_1()
        {
            /*" -4995- EXEC SQL OPEN V1BILHETE END-EXEC. */

            V1BILHETE.Open();

        }

        [StopWatch]
        /*" R8100-00-DECLARE-CBO-DB-DECLARE-1 */
        public void R8100_00_DECLARE_CBO_DB_DECLARE_1()
        {
            /*" -5556- EXEC SQL DECLARE CCBO CURSOR FOR SELECT COD_CBO, DESCR_CBO FROM SEGUROS.CBO WHERE COD_CBO BETWEEN 001 AND 999 ORDER BY COD_CBO END-EXEC. */
            CCBO = new CB0009B_CCBO(false);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7100_99_SAIDA*/

        [StopWatch]
        /*" R7110-00-FETCH-V1BILHETE-SECTION */
        private void R7110_00_FETCH_V1BILHETE_SECTION()
        {
            /*" -5011- MOVE '7110' TO WNR-EXEC-SQL. */
            _.Move("7110", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5014- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5020- PERFORM R7110_00_FETCH_V1BILHETE_DB_FETCH_1 */

            R7110_00_FETCH_V1BILHETE_DB_FETCH_1();

            /*" -5024- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -5024- PERFORM R7110_00_FETCH_V1BILHETE_DB_CLOSE_1 */

                R7110_00_FETCH_V1BILHETE_DB_CLOSE_1();

                /*" -5026- MOVE 'S' TO WFIM-V1BILHETE */
                _.Move("S", WS_AUX_WORK.WFIM_V1BILHETE);

                /*" -5028- GO TO R7110-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7110_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5029- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5030- DISPLAY 'R7110-00 - PROBLEMAS FETCH   (V1BILHETE)  ' */
                _.Display($"R7110-00 - PROBLEMAS FETCH   (V1BILHETE)  ");

                /*" -5033- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5034- IF VIND-DTCANCEL LESS ZEROS */

            if (VIND_DTCANCEL < 00)
            {

                /*" -5037- MOVE SPACES TO V0BILH-DTCANCEL. */
                _.Move("", V0BILH_DTCANCEL);
            }


            /*" -5038- ADD 1 TO LD-V1BILHETE. */
            WS_AUX_WORK.LD_V1BILHETE.Value = WS_AUX_WORK.LD_V1BILHETE + 1;

            /*" -5041- DISPLAY 'BILHETE V1BILHETE LIDO: ' V0BILH-NUMBIL */
            _.Display($"BILHETE V1BILHETE LIDO: {V0BILH_NUMBIL}");

            /*" -5041- . */

        }

        [StopWatch]
        /*" R7110-00-FETCH-V1BILHETE-DB-FETCH-1 */
        public void R7110_00_FETCH_V1BILHETE_DB_FETCH_1()
        {
            /*" -5020- EXEC SQL FETCH V1BILHETE INTO :V0BILH-NUMBIL , :V0BILH-SITUACAO , :V0BILH-CODUSU , :V0BILH-DTCANCEL:VIND-DTCANCEL, :V0BILH-RAMO END-EXEC. */

            if (V1BILHETE.Fetch())
            {
                _.Move(V1BILHETE.V0BILH_NUMBIL, V0BILH_NUMBIL);
                _.Move(V1BILHETE.V0BILH_SITUACAO, V0BILH_SITUACAO);
                _.Move(V1BILHETE.V0BILH_CODUSU, V0BILH_CODUSU);
                _.Move(V1BILHETE.V0BILH_DTCANCEL, V0BILH_DTCANCEL);
                _.Move(V1BILHETE.VIND_DTCANCEL, VIND_DTCANCEL);
                _.Move(V1BILHETE.V0BILH_RAMO, V0BILH_RAMO);
            }

        }

        [StopWatch]
        /*" R7110-00-FETCH-V1BILHETE-DB-CLOSE-1 */
        public void R7110_00_FETCH_V1BILHETE_DB_CLOSE_1()
        {
            /*" -5024- EXEC SQL CLOSE V1BILHETE END-EXEC */

            V1BILHETE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7110_99_SAIDA*/

        [StopWatch]
        /*" R7150-00-PROCESSA-V1BILHETE-SECTION */
        private void R7150_00_PROCESSA_V1BILHETE_SECTION()
        {
            /*" -5050- MOVE '7150' TO WNR-EXEC-SQL. */
            _.Move("7150", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5053- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5058- PERFORM R7180-00-SELECT-PROPIDELIZ. */

            R7180_00_SELECT_PROPIDELIZ_SECTION();

            /*" -5059- IF V0BILH-RAMO EQUAL 72 OR 82 */

            if (V0BILH_RAMO.In("72", "82"))
            {

                /*" -5061- PERFORM R7165-00-SELECT-FAIXA-RCAP. */

                R7165_00_SELECT_FAIXA_RCAP_SECTION();
            }


            /*" -5063- MOVE V0BILH-NUMBIL TO WS-NUMBIL WS-NRTIT. */
            _.Move(V0BILH_NUMBIL, WS_AUX_WORK.WS_NUMBIL, WS_AUX_WORK.WS_NRTIT);

            /*" -5065- PERFORM R7155-00-CONFERE-TITULO. */

            R7155_00_CONFERE_TITULO_SECTION();

            /*" -5066- IF WS-NUMBIL EQUAL WS-NRTIT */

            if (WS_AUX_WORK.WS_NUMBIL == WS_AUX_WORK.WS_NRTIT)
            {

                /*" -5067- ADD 1 TO AC-TITULO */
                WS_AUX_WORK.AC_TITULO.Value = WS_AUX_WORK.AC_TITULO + 1;

                /*" -5069- GO TO R7150-90-LEITURA. */

                R7150_90_LEITURA(); //GOTO
                return;
            }


            /*" -5071- MOVE WS-NRTIT TO V0RCAP-NRTIT. */
            _.Move(WS_AUX_WORK.WS_NRTIT, V0RCAP_NRTIT);

            /*" -5074- PERFORM R7160-00-SELECT-V0RCAP. */

            R7160_00_SELECT_V0RCAP_SECTION();

            /*" -5075- IF V0RCAP-SITUACAO EQUAL '*' */

            if (V0RCAP_SITUACAO == "*")
            {

                /*" -5076- ADD 1 TO AC-RCAPNAO1 */
                WS_AUX_WORK.AC_RCAPNAO1.Value = WS_AUX_WORK.AC_RCAPNAO1 + 1;

                /*" -5077- GO TO R7150-90-LEITURA */

                R7150_90_LEITURA(); //GOTO
                return;

                /*" -5078- ELSE */
            }
            else
            {


                /*" -5079- IF V0RCAP-SITUACAO EQUAL '2' */

                if (V0RCAP_SITUACAO == "2")
                {

                    /*" -5080- ADD 1 TO AC-CANCELA */
                    WS_AUX_WORK.AC_CANCELA.Value = WS_AUX_WORK.AC_CANCELA + 1;

                    /*" -5081- GO TO R7150-90-LEITURA */

                    R7150_90_LEITURA(); //GOTO
                    return;

                    /*" -5082- ELSE */
                }
                else
                {


                    /*" -5083- IF V0RCAP-SITUACAO NOT EQUAL '0' */

                    if (V0RCAP_SITUACAO != "0")
                    {

                        /*" -5084- ADD 1 TO AC-UTILIZA */
                        WS_AUX_WORK.AC_UTILIZA.Value = WS_AUX_WORK.AC_UTILIZA + 1;

                        /*" -5087- GO TO R7150-90-LEITURA. */

                        R7150_90_LEITURA(); //GOTO
                        return;
                    }

                }

            }


            /*" -5088- ADD 1 TO GV-SORT */
            WS_AUX_WORK.GV_SORT.Value = WS_AUX_WORK.GV_SORT + 1;

            /*" -5089- MOVE WS-NUMBIL TO SOR-NUMBIL */
            _.Move(WS_AUX_WORK.WS_NUMBIL, REG_ARQSORT.SOR_NUMBIL);

            /*" -5090- MOVE WS-NRTIT TO SOR-NRTIT */
            _.Move(WS_AUX_WORK.WS_NRTIT, REG_ARQSORT.SOR_NRTIT);

            /*" -5092- RELEASE REG-ARQSORT. */
            ARQSORT.Release(REG_ARQSORT);

            /*" -5093- ADD 1 TO AC-LIBERA */
            WS_AUX_WORK.AC_LIBERA.Value = WS_AUX_WORK.AC_LIBERA + 1;

            /*" -5094- MOVE '8' TO V0BILH-SITUACAO */
            _.Move("8", V0BILH_SITUACAO);

            /*" -5095- MOVE 'CB0009T' TO V0BILH-CODUSU */
            _.Move("CB0009T", V0BILH_CODUSU);

            /*" -5096- MOVE V0SIST-DTMOVABE TO V0BILH-DTCANCEL */
            _.Move(V0SIST_DTMOVABE, V0BILH_DTCANCEL);

            /*" -5097- MOVE ZEROS TO VIND-DTCANCEL */
            _.Move(0, VIND_DTCANCEL);

            /*" -5100- PERFORM R7200-00-UPDATE-V0BILHETE. */

            R7200_00_UPDATE_V0BILHETE_SECTION();

            /*" -5100- PERFORM R7210-00-DELETE-V0COMISSAO. */

            R7210_00_DELETE_V0COMISSAO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R7150_90_LEITURA */

            R7150_90_LEITURA();

        }

        [StopWatch]
        /*" R7150-90-LEITURA */
        private void R7150_90_LEITURA(bool isPerform = false)
        {
            /*" -5105- PERFORM R7110-00-FETCH-V1BILHETE. */

            R7110_00_FETCH_V1BILHETE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7150_99_SAIDA*/

        [StopWatch]
        /*" R7155-00-CONFERE-TITULO-SECTION */
        private void R7155_00_CONFERE_TITULO_SECTION()
        {
            /*" -5115- MOVE '7155' TO WNR-EXEC-SQL. */
            _.Move("7155", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5117- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5120- MOVE WS-NUMTIT TO LPARM11. */
            _.Move(WS_AUX_WORK.FILLER_13.WS_NUMTIT, WS_AGENCIACEF.LPARM11X.LPARM11);

            /*" -5132- COMPUTE WPARM11-AUX = LPARM11-1 * 3 + LPARM11-2 * 2 + LPARM11-3 * 9 + LPARM11-4 * 8 + LPARM11-5 * 7 + LPARM11-6 * 6 + LPARM11-7 * 5 + LPARM11-8 * 4 + LPARM11-9 * 3 + LPARM11-10 * 2. */
            WS_AUX_WORK.WPARM11_AUX.Value = WS_AGENCIACEF.LPARM11X.FILLER_20.LPARM11_1 * 3 + WS_AGENCIACEF.LPARM11X.FILLER_20.LPARM11_2 * 2 + WS_AGENCIACEF.LPARM11X.FILLER_20.LPARM11_3 * 9 + WS_AGENCIACEF.LPARM11X.FILLER_20.LPARM11_4 * 8 + WS_AGENCIACEF.LPARM11X.FILLER_20.LPARM11_5 * 7 + WS_AGENCIACEF.LPARM11X.FILLER_20.LPARM11_6 * 6 + WS_AGENCIACEF.LPARM11X.FILLER_20.LPARM11_7 * 5 + WS_AGENCIACEF.LPARM11X.FILLER_20.LPARM11_8 * 4 + WS_AGENCIACEF.LPARM11X.FILLER_20.LPARM11_9 * 3 + WS_AGENCIACEF.LPARM11X.FILLER_20.LPARM11_10 * 2;

            /*" -5135- DIVIDE WPARM11-AUX BY 11 GIVING WS-RESULT REMAINDER WS-RESTO. */
            _.Divide(WS_AUX_WORK.WPARM11_AUX, 11, WS_AUX_WORK.WS_RESULT, WS_AUX_WORK.WS_RESTO);

            /*" -5136- IF WS-RESTO EQUAL ZEROS */

            if (WS_AUX_WORK.WS_RESTO == 00)
            {

                /*" -5137- MOVE 0 TO WS-DIGTIT */
                _.Move(0, WS_AUX_WORK.FILLER_13.WS_DIGTIT);

                /*" -5138- ELSE */
            }
            else
            {


                /*" -5139- SUBTRACT WS-RESTO FROM 11 GIVING WS-DIGTIT. */
                WS_AUX_WORK.FILLER_13.WS_DIGTIT.Value = 11 - WS_AUX_WORK.WS_RESTO;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7155_99_SAIDA*/

        [StopWatch]
        /*" R7160-00-SELECT-V0RCAP-SECTION */
        private void R7160_00_SELECT_V0RCAP_SECTION()
        {
            /*" -5150- MOVE '7160' TO WNR-EXEC-SQL. */
            _.Move("7160", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5152- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5157- PERFORM R7160_00_SELECT_V0RCAP_DB_SELECT_1 */

            R7160_00_SELECT_V0RCAP_DB_SELECT_1();

            /*" -5160- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5160- MOVE '*' TO V0RCAP-SITUACAO. */
                _.Move("*", V0RCAP_SITUACAO);
            }


        }

        [StopWatch]
        /*" R7160-00-SELECT-V0RCAP-DB-SELECT-1 */
        public void R7160_00_SELECT_V0RCAP_DB_SELECT_1()
        {
            /*" -5157- EXEC SQL SELECT SITUACAO INTO :V0RCAP-SITUACAO FROM SEGUROS.V0RCAP WHERE NRTIT = :V0RCAP-NRTIT END-EXEC. */

            var r7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1 = new R7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1()
            {
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
            };

            var executed_1 = R7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1.Execute(r7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_SITUACAO, V0RCAP_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7160_99_SAIDA*/

        [StopWatch]
        /*" R7165-00-SELECT-FAIXA-RCAP-SECTION */
        private void R7165_00_SELECT_FAIXA_RCAP_SECTION()
        {
            /*" -5171- MOVE '7165' TO WNR-EXEC-SQL. */
            _.Move("7165", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5173- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5180- PERFORM R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1 */

            R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1();

            /*" -5183- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5185- GO TO R7165-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7165_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5186- IF BILFAI-RAMO NOT EQUAL V0BILH-RAMO */

            if (BILFAI_RAMO != V0BILH_RAMO)
            {

                /*" -5187- MOVE BILFAI-RAMO TO V0BILH-RAMO */
                _.Move(BILFAI_RAMO, V0BILH_RAMO);

                /*" -5188- PERFORM R7170-00-UPDATE-V0BILHETE */

                R7170_00_UPDATE_V0BILHETE_SECTION();

                /*" -5189- IF BILFAI-RAMO EQUAL 72 */

                if (BILFAI_RAMO == 72)
                {

                    /*" -5190- ADD +1 TO AC-DE82-PARA72 */
                    WS_AUX_WORK.AC_DE82_PARA72.Value = WS_AUX_WORK.AC_DE82_PARA72 + +1;

                    /*" -5191- ELSE */
                }
                else
                {


                    /*" -5191- ADD +1 TO AC-DE72-PARA82. */
                    WS_AUX_WORK.AC_DE72_PARA82.Value = WS_AUX_WORK.AC_DE72_PARA82 + +1;
                }

            }


        }

        [StopWatch]
        /*" R7165-00-SELECT-FAIXA-RCAP-DB-SELECT-1 */
        public void R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1()
        {
            /*" -5180- EXEC SQL SELECT COD_RAMO INTO :BILFAI-RAMO FROM SEGUROS.BILHETE_FAIXA WHERE NUMBIL_INI <= :V0BILH-NUMBIL AND NUMBIL_FIM >= :V0BILH-NUMBIL AND COD_RAMO IN (72,82) END-EXEC. */

            var r7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1 = new R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1.Execute(r7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILFAI_RAMO, BILFAI_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7165_99_SAIDA*/

        [StopWatch]
        /*" R7170-00-UPDATE-V0BILHETE-SECTION */
        private void R7170_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -5201- MOVE '7170' TO WNR-EXEC-SQL. */
            _.Move("7170", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5203- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5210- PERFORM R7170_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R7170_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -5214- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5216- ADD 1 TO AC-ATU-RAMO. */
                WS_AUX_WORK.AC_ATU_RAMO.Value = WS_AUX_WORK.AC_ATU_RAMO + 1;
            }


        }

        [StopWatch]
        /*" R7170-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R7170_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -5210- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO, DTCANCEL = :V0BILH-DTCANCEL:VIND-DTCANCEL, RAMO = :V0BILH-RAMO, COD_USUARIO = 'CB0009B' WHERE CURRENT OF V1BILHETE END-EXEC. */

            var r7170_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R7170_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1(V1BILHETE)
            {
                V0BILH_DTCANCEL = V0BILH_DTCANCEL.ToString(),
                VIND_DTCANCEL = VIND_DTCANCEL.ToString(),
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
                V0SIST_DTLIBERA = V0SIST_DTLIBERA.ToString(),
            };

            R7170_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r7170_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7170_99_SAIDA*/

        [StopWatch]
        /*" R7180-00-SELECT-PROPIDELIZ-SECTION */
        private void R7180_00_SELECT_PROPIDELIZ_SECTION()
        {
            /*" -5224- MOVE '7180' TO WNR-EXEC-SQL. */
            _.Move("7180", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5229- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5238- PERFORM R7180_00_SELECT_PROPIDELIZ_DB_SELECT_1 */

            R7180_00_SELECT_PROPIDELIZ_DB_SELECT_1();

            /*" -5241- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5253- GO TO R7180-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7180_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7180-00-SELECT-PROPIDELIZ-DB-SELECT-1 */
        public void R7180_00_SELECT_PROPIDELIZ_DB_SELECT_1()
        {
            /*" -5238- EXEC SQL SELECT ORIGEM_PROPOSTA , COD_PLANO , CANAL_PROPOSTA INTO :PRPFIDEL-ORIGEM ,:PRPFIDEL-COD-PLANO ,:PRPFIDEL-CANAL FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :V0BILH-NUMBIL END-EXEC. */

            var r7180_00_SELECT_PROPIDELIZ_DB_SELECT_1_Query1 = new R7180_00_SELECT_PROPIDELIZ_DB_SELECT_1_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R7180_00_SELECT_PROPIDELIZ_DB_SELECT_1_Query1.Execute(r7180_00_SELECT_PROPIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRPFIDEL_ORIGEM, PRPFIDEL_ORIGEM);
                _.Move(executed_1.PRPFIDEL_COD_PLANO, PRPFIDEL_COD_PLANO);
                _.Move(executed_1.PRPFIDEL_CANAL, PRPFIDEL_CANAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7180_99_SAIDA*/

        [StopWatch]
        /*" R7200-00-UPDATE-V0BILHETE-SECTION */
        private void R7200_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -5270- MOVE '7200' TO WNR-EXEC-SQL. */
            _.Move("7200", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5273- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5280- PERFORM R7200_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R7200_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -5284- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5284- ADD 1 TO BI-LIBERA. */
                WS_AUX_WORK.BI_LIBERA.Value = WS_AUX_WORK.BI_LIBERA + 1;
            }


        }

        [StopWatch]
        /*" R7200-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R7200_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -5280- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO, DTCANCEL = :V0BILH-DTCANCEL:VIND-DTCANCEL, RAMO = :V0BILH-RAMO, COD_USUARIO = 'CB0009B' WHERE CURRENT OF V1BILHETE END-EXEC. */

            var r7200_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R7200_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1(V1BILHETE)
            {
                V0BILH_DTCANCEL = V0BILH_DTCANCEL.ToString(),
                VIND_DTCANCEL = VIND_DTCANCEL.ToString(),
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
                V0SIST_DTLIBERA = V0SIST_DTLIBERA.ToString(),
            };

            R7200_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r7200_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7200_99_SAIDA*/

        [StopWatch]
        /*" R7210-00-DELETE-V0COMISSAO-SECTION */
        private void R7210_00_DELETE_V0COMISSAO_SECTION()
        {
            /*" -5295- MOVE '7210' TO WNR-EXEC-SQL. */
            _.Move("7210", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5298- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5302- PERFORM R7210_00_DELETE_V0COMISSAO_DB_DELETE_1 */

            R7210_00_DELETE_V0COMISSAO_DB_DELETE_1();

            /*" -5306- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5306- ADD 1 TO BI-COMISSAO. */
                WS_AUX_WORK.BI_COMISSAO.Value = WS_AUX_WORK.BI_COMISSAO + 1;
            }


        }

        [StopWatch]
        /*" R7210-00-DELETE-V0COMISSAO-DB-DELETE-1 */
        public void R7210_00_DELETE_V0COMISSAO_DB_DELETE_1()
        {
            /*" -5302- EXEC SQL DELETE FROM SEGUROS.V0COMISSAO_FENAE WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r7210_00_DELETE_V0COMISSAO_DB_DELETE_1_Delete1 = new R7210_00_DELETE_V0COMISSAO_DB_DELETE_1_Delete1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R7210_00_DELETE_V0COMISSAO_DB_DELETE_1_Delete1.Execute(r7210_00_DELETE_V0COMISSAO_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7210_99_SAIDA*/

        [StopWatch]
        /*" R7500-00-OUTPUT-SORT-SECTION */
        private void R7500_00_OUTPUT_SORT_SECTION()
        {
            /*" -5317- MOVE '7500' TO WNR-EXEC-SQL. */
            _.Move("7500", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5320- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5321- MOVE SPACES TO WFIM-SORT. */
            _.Move("", WS_AUX_WORK.WFIM_SORT);

            /*" -5324- PERFORM R7510-00-LE-ARQSORT. */

            R7510_00_LE_ARQSORT_SECTION();

            /*" -5325- IF WFIM-SORT NOT EQUAL SPACES */

            if (!WS_AUX_WORK.WFIM_SORT.IsEmpty())
            {

                /*" -5328- GO TO R7500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5332- PERFORM R7550-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!WS_AUX_WORK.WFIM_SORT.IsEmpty()))
            {

                R7550_00_PROCESSA_SORT_SECTION();
            }

            /*" -5332- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -5335- DISPLAY ' ' */
            _.Display($" ");

            /*" -5336- DISPLAY 'CB0009B - LIBERA BILHETES   ' . */
            _.Display($"CB0009B - LIBERA BILHETES   ");

            /*" -5337- DISPLAY ' ' */
            _.Display($" ");

            /*" -5338- DISPLAY 'LIDOS V1BILHETE ....... ' LD-V1BILHETE */
            _.Display($"LIDOS V1BILHETE ....... {WS_AUX_WORK.LD_V1BILHETE}");

            /*" -5339- DISPLAY 'BILHETES CERTOS ....... ' AC-TITULO */
            _.Display($"BILHETES CERTOS ....... {WS_AUX_WORK.AC_TITULO}");

            /*" -5340- DISPLAY 'BILHETES SEM CREDITO .. ' AC-RCAPNAO1 */
            _.Display($"BILHETES SEM CREDITO .. {WS_AUX_WORK.AC_RCAPNAO1}");

            /*" -5341- DISPLAY 'CREDITO CANCELADO ..... ' AC-CANCELA */
            _.Display($"CREDITO CANCELADO ..... {WS_AUX_WORK.AC_CANCELA}");

            /*" -5342- DISPLAY 'CREDITO UTILIZADO ..... ' AC-UTILIZA */
            _.Display($"CREDITO UTILIZADO ..... {WS_AUX_WORK.AC_UTILIZA}");

            /*" -5343- DISPLAY 'BILHETES CANCELADOS ... ' AC-LIBERA */
            _.Display($"BILHETES CANCELADOS ... {WS_AUX_WORK.AC_LIBERA}");

            /*" -5344- DISPLAY 'ERRO UPDATE BILHETE ... ' BI-LIBERA */
            _.Display($"ERRO UPDATE BILHETE ... {WS_AUX_WORK.BI_LIBERA}");

            /*" -5345- DISPLAY 'ERRO DELETE COMISSAO .. ' BI-COMISSAO */
            _.Display($"ERRO DELETE COMISSAO .. {WS_AUX_WORK.BI_COMISSAO}");

            /*" -5346- DISPLAY 'GRAVADOS SORT ......... ' GV-SORT */
            _.Display($"GRAVADOS SORT ......... {WS_AUX_WORK.GV_SORT}");

            /*" -5347- DISPLAY ' ' */
            _.Display($" ");

            /*" -5348- DISPLAY 'LIDOS SORT ............ ' LD-SORT */
            _.Display($"LIDOS SORT ............ {WS_AUX_WORK.LD_SORT}");

            /*" -5349- DISPLAY 'BILHETE SEM CADASTRO .. ' AC-BILHNAO */
            _.Display($"BILHETE SEM CADASTRO .. {WS_AUX_WORK.AC_BILHNAO}");

            /*" -5350- DISPLAY 'DESPREZA INCLUSAO ..... ' IN-DESPREZA */
            _.Display($"DESPREZA INCLUSAO ..... {WS_AUX_WORK.IN_DESPREZA}");

            /*" -5351- DISPLAY 'BILHETES LIBERADOS .... ' IN-INSERT */
            _.Display($"BILHETES LIBERADOS .... {WS_AUX_WORK.IN_INSERT}");

            /*" -5352- DISPLAY ' ' */
            _.Display($" ");

            /*" -5353- DISPLAY 'CB0009B - FIM LIBERA BILHETES    ' . */
            _.Display($"CB0009B - FIM LIBERA BILHETES    ");

            /*" -5353- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7500_99_SAIDA*/

        [StopWatch]
        /*" R7510-00-LE-ARQSORT-SECTION */
        private void R7510_00_LE_ARQSORT_SECTION()
        {
            /*" -5364- MOVE '7510' TO WNR-EXEC-SQL. */
            _.Move("7510", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5367- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5369- RETURN ARQSORT AT END */
            try
            {
                ARQSORT.Return(REG_ARQSORT, () =>
                {

                    /*" -5370- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", WS_AUX_WORK.WFIM_SORT);

                    /*" -5373- GO TO R7510-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R7510_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -5373- ADD 1 TO LD-SORT. */
            WS_AUX_WORK.LD_SORT.Value = WS_AUX_WORK.LD_SORT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7510_99_SAIDA*/

        [StopWatch]
        /*" R7550-00-PROCESSA-SORT-SECTION */
        private void R7550_00_PROCESSA_SORT_SECTION()
        {
            /*" -5384- MOVE '7550' TO WNR-EXEC-SQL. */
            _.Move("7550", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5386- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5387- MOVE SOR-NUMBIL TO V0BILH-NUMBIL */
            _.Move(REG_ARQSORT.SOR_NUMBIL, V0BILH_NUMBIL);

            /*" -5389- PERFORM R7600-00-SELECT-V0BILHETE. */

            R7600_00_SELECT_V0BILHETE_SECTION();

            /*" -5390- IF V0BILH-SITUACAO NOT EQUAL '0' */

            if (V0BILH_SITUACAO != "0")
            {

                /*" -5391- ADD 1 TO AC-BILHNAO */
                WS_AUX_WORK.AC_BILHNAO.Value = WS_AUX_WORK.AC_BILHNAO + 1;

                /*" -5394- GO TO R7550-90-LEITURA. */

                R7550_90_LEITURA(); //GOTO
                return;
            }


            /*" -5395- MOVE SOR-NRTIT TO V0BILH-NUMBIL */
            _.Move(REG_ARQSORT.SOR_NRTIT, V0BILH_NUMBIL);

            /*" -5396- MOVE V0SIST-DTMOVABE TO V0BILH-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0BILH_DTMOVTO);

            /*" -5397- MOVE 'CB0009B' TO V0BILH-CODUSU */
            _.Move("CB0009B", V0BILH_CODUSU);

            /*" -5398- MOVE SPACES TO V0BILH-DTCANCEL */
            _.Move("", V0BILH_DTCANCEL);

            /*" -5400- MOVE -1 TO VIND-DTCANCEL. */
            _.Move(-1, VIND_DTCANCEL);

            /*" -5400- PERFORM R7650-00-INSERT-V0BILHETE. */

            R7650_00_INSERT_V0BILHETE_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R7550_90_LEITURA */

            R7550_90_LEITURA();

        }

        [StopWatch]
        /*" R7550-90-LEITURA */
        private void R7550_90_LEITURA(bool isPerform = false)
        {
            /*" -5405- PERFORM R7510-00-LE-ARQSORT. */

            R7510_00_LE_ARQSORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7550_99_SAIDA*/

        [StopWatch]
        /*" R7600-00-SELECT-V0BILHETE-SECTION */
        private void R7600_00_SELECT_V0BILHETE_SECTION()
        {
            /*" -5415- MOVE '7600' TO WNR-EXEC-SQL. */
            _.Move("7600", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5417- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5477- PERFORM R7600_00_SELECT_V0BILHETE_DB_SELECT_1 */

            R7600_00_SELECT_V0BILHETE_DB_SELECT_1();

            /*" -5481- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5482- MOVE '*' TO V0BILH-SITUACAO */
                _.Move("*", V0BILH_SITUACAO);

                /*" -5483- ELSE */
            }
            else
            {


                /*" -5483- MOVE '0' TO V0BILH-SITUACAO. */
                _.Move("0", V0BILH_SITUACAO);
            }


        }

        [StopWatch]
        /*" R7600-00-SELECT-V0BILHETE-DB-SELECT-1 */
        public void R7600_00_SELECT_V0BILHETE_DB_SELECT_1()
        {
            /*" -5477- EXEC SQL SELECT NUM_APOLICE , FONTE , AGECOBR , NUM_MATRICULA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , CODCLIEN , PROFISSAO , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DTQITBCO , VLRCAP , RAMO , DATA_VENDA , NUM_APOL_ANTERIOR , TIP_CANCELAMENTO , SIT_SINISTRO , BI_FAIXA_RENDA_IND , BI_FAIXA_RENDA_FAM , COD_PRODUTO INTO :V0BILH-NUMAPOL , :V0BILH-FONTE , :V0BILH-AGECOBR , :V0BILH-MATRICULA , :V0BILH-AGECONTA , :V0BILH-OPECONTA , :V0BILH-NUMCONTA , :V0BILH-DIGCONTA , :V0BILH-CODCLIEN , :V0BILH-PROFISSAO , :V0BILH-SEXO , :V0BILH-ESTCIV , :V0BILH-OCOREND , :V0BILH-AGECONDEB , :V0BILH-OPECONDEB , :V0BILH-NUMCONDEB , :V0BILH-DIGCONDEB , :V0BILH-OPCOBER , :V0BILH-DTQITBCO , :V0BILH-VLRCAP , :V0BILH-RAMO , :V0BILH-DTVENDA , :V0BILH-NUMAPOLANT , :V0BILH-TIPCANCEL , :V0BILH-TIPSINIST , :V0BILH-FX-RENDA-IND , :V0BILH-FX-RENDA-FAM , :V0BILH-COD-PRODUTO FROM SEGUROS.V0BILHETE WHERE NUMBIL = :V0BILH-NUMBIL AND SITUACAO = '8' END-EXEC. */

            var r7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1 = new R7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1.Execute(r7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BILH_NUMAPOL, V0BILH_NUMAPOL);
                _.Move(executed_1.V0BILH_FONTE, V0BILH_FONTE);
                _.Move(executed_1.V0BILH_AGECOBR, V0BILH_AGECOBR);
                _.Move(executed_1.V0BILH_MATRICULA, V0BILH_MATRICULA);
                _.Move(executed_1.V0BILH_AGECONTA, V0BILH_AGECONTA);
                _.Move(executed_1.V0BILH_OPECONTA, V0BILH_OPECONTA);
                _.Move(executed_1.V0BILH_NUMCONTA, V0BILH_NUMCONTA);
                _.Move(executed_1.V0BILH_DIGCONTA, V0BILH_DIGCONTA);
                _.Move(executed_1.V0BILH_CODCLIEN, V0BILH_CODCLIEN);
                _.Move(executed_1.V0BILH_PROFISSAO, V0BILH_PROFISSAO);
                _.Move(executed_1.V0BILH_SEXO, V0BILH_SEXO);
                _.Move(executed_1.V0BILH_ESTCIV, V0BILH_ESTCIV);
                _.Move(executed_1.V0BILH_OCOREND, V0BILH_OCOREND);
                _.Move(executed_1.V0BILH_AGECONDEB, V0BILH_AGECONDEB);
                _.Move(executed_1.V0BILH_OPECONDEB, V0BILH_OPECONDEB);
                _.Move(executed_1.V0BILH_NUMCONDEB, V0BILH_NUMCONDEB);
                _.Move(executed_1.V0BILH_DIGCONDEB, V0BILH_DIGCONDEB);
                _.Move(executed_1.V0BILH_OPCOBER, V0BILH_OPCOBER);
                _.Move(executed_1.V0BILH_DTQITBCO, V0BILH_DTQITBCO);
                _.Move(executed_1.V0BILH_VLRCAP, V0BILH_VLRCAP);
                _.Move(executed_1.V0BILH_RAMO, V0BILH_RAMO);
                _.Move(executed_1.V0BILH_DTVENDA, V0BILH_DTVENDA);
                _.Move(executed_1.V0BILH_NUMAPOLANT, V0BILH_NUMAPOLANT);
                _.Move(executed_1.V0BILH_TIPCANCEL, V0BILH_TIPCANCEL);
                _.Move(executed_1.V0BILH_TIPSINIST, V0BILH_TIPSINIST);
                _.Move(executed_1.V0BILH_FX_RENDA_IND, V0BILH_FX_RENDA_IND);
                _.Move(executed_1.V0BILH_FX_RENDA_FAM, V0BILH_FX_RENDA_FAM);
                _.Move(executed_1.V0BILH_COD_PRODUTO, V0BILH_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7600_99_SAIDA*/

        [StopWatch]
        /*" R7650-00-INSERT-V0BILHETE-SECTION */
        private void R7650_00_INSERT_V0BILHETE_SECTION()
        {
            /*" -5494- MOVE '7650' TO WNR-EXEC-SQL. */
            _.Move("7650", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5497- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5533- PERFORM R7650_00_INSERT_V0BILHETE_DB_INSERT_1 */

            R7650_00_INSERT_V0BILHETE_DB_INSERT_1();

            /*" -5536- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5537- ADD 1 TO IN-DESPREZA */
                WS_AUX_WORK.IN_DESPREZA.Value = WS_AUX_WORK.IN_DESPREZA + 1;

                /*" -5538- ELSE */
            }
            else
            {


                /*" -5538- ADD 1 TO IN-INSERT. */
                WS_AUX_WORK.IN_INSERT.Value = WS_AUX_WORK.IN_INSERT + 1;
            }


        }

        [StopWatch]
        /*" R7650-00-INSERT-V0BILHETE-DB-INSERT-1 */
        public void R7650_00_INSERT_V0BILHETE_DB_INSERT_1()
        {
            /*" -5533- EXEC SQL INSERT INTO SEGUROS.V0BILHETE VALUES (:V0BILH-NUMBIL , :V0BILH-NUMAPOL , :V0BILH-FONTE , :V0BILH-AGECOBR , :V0BILH-MATRICULA , :V0BILH-AGECONTA , :V0BILH-OPECONTA , :V0BILH-NUMCONTA , :V0BILH-DIGCONTA , :V0BILH-CODCLIEN , :V0BILH-PROFISSAO , :V0BILH-SEXO , :V0BILH-ESTCIV , :V0BILH-OCOREND , :V0BILH-AGECONDEB , :V0BILH-OPECONDEB , :V0BILH-NUMCONDEB , :V0BILH-DIGCONDEB , :V0BILH-OPCOBER , :V0BILH-DTQITBCO , :V0BILH-VLRCAP , :V0BILH-RAMO , :V0BILH-DTVENDA , :V0BILH-DTMOVTO , :V0BILH-NUMAPOLANT , :V0BILH-SITUACAO , :V0BILH-TIPCANCEL , :V0BILH-TIPSINIST , :V0BILH-CODUSU , CURRENT TIMESTAMP , :V0BILH-DTCANCEL:VIND-DTCANCEL, :V0BILH-FX-RENDA-IND , :V0BILH-FX-RENDA-FAM , :V0BILH-COD-PRODUTO) END-EXEC. */

            var r7650_00_INSERT_V0BILHETE_DB_INSERT_1_Insert1 = new R7650_00_INSERT_V0BILHETE_DB_INSERT_1_Insert1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
                V0BILH_NUMAPOL = V0BILH_NUMAPOL.ToString(),
                V0BILH_FONTE = V0BILH_FONTE.ToString(),
                V0BILH_AGECOBR = V0BILH_AGECOBR.ToString(),
                V0BILH_MATRICULA = V0BILH_MATRICULA.ToString(),
                V0BILH_AGECONTA = V0BILH_AGECONTA.ToString(),
                V0BILH_OPECONTA = V0BILH_OPECONTA.ToString(),
                V0BILH_NUMCONTA = V0BILH_NUMCONTA.ToString(),
                V0BILH_DIGCONTA = V0BILH_DIGCONTA.ToString(),
                V0BILH_CODCLIEN = V0BILH_CODCLIEN.ToString(),
                V0BILH_PROFISSAO = V0BILH_PROFISSAO.ToString(),
                V0BILH_SEXO = V0BILH_SEXO.ToString(),
                V0BILH_ESTCIV = V0BILH_ESTCIV.ToString(),
                V0BILH_OCOREND = V0BILH_OCOREND.ToString(),
                V0BILH_AGECONDEB = V0BILH_AGECONDEB.ToString(),
                V0BILH_OPECONDEB = V0BILH_OPECONDEB.ToString(),
                V0BILH_NUMCONDEB = V0BILH_NUMCONDEB.ToString(),
                V0BILH_DIGCONDEB = V0BILH_DIGCONDEB.ToString(),
                V0BILH_OPCOBER = V0BILH_OPCOBER.ToString(),
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V0BILH_VLRCAP = V0BILH_VLRCAP.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
                V0BILH_DTVENDA = V0BILH_DTVENDA.ToString(),
                V0BILH_DTMOVTO = V0BILH_DTMOVTO.ToString(),
                V0BILH_NUMAPOLANT = V0BILH_NUMAPOLANT.ToString(),
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_TIPCANCEL = V0BILH_TIPCANCEL.ToString(),
                V0BILH_TIPSINIST = V0BILH_TIPSINIST.ToString(),
                V0BILH_CODUSU = V0BILH_CODUSU.ToString(),
                V0BILH_DTCANCEL = V0BILH_DTCANCEL.ToString(),
                VIND_DTCANCEL = VIND_DTCANCEL.ToString(),
                V0BILH_FX_RENDA_IND = V0BILH_FX_RENDA_IND.ToString(),
                V0BILH_FX_RENDA_FAM = V0BILH_FX_RENDA_FAM.ToString(),
                V0BILH_COD_PRODUTO = V0BILH_COD_PRODUTO.ToString(),
            };

            R7650_00_INSERT_V0BILHETE_DB_INSERT_1_Insert1.Execute(r7650_00_INSERT_V0BILHETE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7650_99_SAIDA*/

        [StopWatch]
        /*" R8100-00-DECLARE-CBO-SECTION */
        private void R8100_00_DECLARE_CBO_SECTION()
        {
            /*" -5548- MOVE '8100' TO WNR-EXEC-SQL. */
            _.Move("8100", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5550- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5556- PERFORM R8100_00_DECLARE_CBO_DB_DECLARE_1 */

            R8100_00_DECLARE_CBO_DB_DECLARE_1();

            /*" -5558- PERFORM R8100_00_DECLARE_CBO_DB_OPEN_1 */

            R8100_00_DECLARE_CBO_DB_OPEN_1();

            /*" -5561- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5562- DISPLAY 'R8100 - PROBLEMAS DECLARE (CBO      ) ..' */
                _.Display($"R8100 - PROBLEMAS DECLARE (CBO      ) ..");

                /*" -5563- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -5563- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8100-00-DECLARE-CBO-DB-OPEN-1 */
        public void R8100_00_DECLARE_CBO_DB_OPEN_1()
        {
            /*" -5558- EXEC SQL OPEN CCBO END-EXEC. */

            CCBO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_99_SAIDA*/

        [StopWatch]
        /*" R8110-00-FETCH-CBO-SECTION */
        private void R8110_00_FETCH_CBO_SECTION()
        {
            /*" -5572- MOVE '8110' TO WNR-EXEC-SQL. */
            _.Move("8110", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5574- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5577- PERFORM R8110_00_FETCH_CBO_DB_FETCH_1 */

            R8110_00_FETCH_CBO_DB_FETCH_1();

            /*" -5580- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5581- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5582- MOVE 'S' TO WFIM-CBO */
                    _.Move("S", WS_AUX_WORK.WFIM_CBO);

                    /*" -5582- PERFORM R8110_00_FETCH_CBO_DB_CLOSE_1 */

                    R8110_00_FETCH_CBO_DB_CLOSE_1();

                    /*" -5584- ELSE */
                }
                else
                {


                    /*" -5584- PERFORM R8110_00_FETCH_CBO_DB_CLOSE_2 */

                    R8110_00_FETCH_CBO_DB_CLOSE_2();

                    /*" -5586- DISPLAY '8110 - (PROBLEMAS NO FETCH CCBO     ) ..' */
                    _.Display($"8110 - (PROBLEMAS NO FETCH CCBO     ) ..");

                    /*" -5587- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -5587- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R8110-00-FETCH-CBO-DB-FETCH-1 */
        public void R8110_00_FETCH_CBO_DB_FETCH_1()
        {
            /*" -5577- EXEC SQL FETCH CCBO INTO :CBO-COD-CBO, :CBO-DESCR-CBO END-EXEC. */

            if (CCBO.Fetch())
            {
                _.Move(CCBO.CBO_COD_CBO, CBO_COD_CBO);
                _.Move(CCBO.CBO_DESCR_CBO, CBO_DESCR_CBO);
            }

        }

        [StopWatch]
        /*" R8110-00-FETCH-CBO-DB-CLOSE-1 */
        public void R8110_00_FETCH_CBO_DB_CLOSE_1()
        {
            /*" -5582- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8110_99_SAIDA*/

        [StopWatch]
        /*" R8110-00-FETCH-CBO-DB-CLOSE-2 */
        public void R8110_00_FETCH_CBO_DB_CLOSE_2()
        {
            /*" -5584- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }

        [StopWatch]
        /*" R8120-00-CARREGA-CBO-SECTION */
        private void R8120_00_CARREGA_CBO_SECTION()
        {
            /*" -5597- MOVE '8120' TO WNR-EXEC-SQL. */
            _.Move("8120", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5599- DISPLAY WNR-EXEC-SQL */
            _.Display(WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5602- MOVE CBO-DESCR-CBO TO TAB-DESCR-CBO-C (CBO-COD-CBO) */
            _.Move(CBO_DESCR_CBO, TAB_CBO1.TAB_CBO.FILLER_0[CBO_COD_CBO].TAB_DESCR_CBO_C);

            /*" -5602- PERFORM R8110-00-FETCH-CBO. */

            R8110_00_FETCH_CBO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8120_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -5611- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WS_AUX_WORK.WABEND.WSQLCODE);

            /*" -5612- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], WS_AUX_WORK.WABEND.WSQLERRD1);

            /*" -5613- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], WS_AUX_WORK.WABEND.WSQLERRD2);

            /*" -5616- DISPLAY WABEND. */
            _.Display(WS_AUX_WORK.WABEND);

            /*" -5616- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5620- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -5620- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}