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
using Sias.Cobranca.DB2.CB2005B;

namespace Code
{
    public class CB2005B
    {
        public bool IsCall { get; set; }

        public CB2005B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  BILHETES DE SEGURO (SASSE)         *      */
        /*"      *   PROGRAMA ...............  CB2005B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  WANGER C.SILVA / ALEXANDRE BURGOS  *      */
        /*"      *   PROGRAMADOR ............  ALEXANDRE BURGOS / ENRICO / WANGER *      */
        /*"      *   DATA CODIFICACAO .......  MARCO / 1995                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  A PARTIR DO MOVIMENTO DE BILHETES  *      */
        /*"      *                             (V0BILHETE), ATUALIZA O DB DE APO- *      */
        /*"      *                             LICES PARA BILHETES COM PAGAMENTO  *      */
        /*"      *                             MENSAL.                            *      */
        /*"      ******************************************************************      */
        /*"V.22  *  VERSAO 22  - JAZZ   582106                                    *      */
        /*"      *             - META 2024 - INCORPORACAO DA EMPRESA XS2 PELA     *      */
        /*"      *               CVP.                                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/05/2024 - SERGIO LORETO                                *      */
        /*"      *                                       PROCURE POR V.22         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.21  *  VERSAO 21  - DEMANDA 564.320                                  *      */
        /*"      *             - SUBSTITUIR A CHAMADA DA ROTINA FC0105S DA CAP    *      */
        /*"      *               PELA VG0105S                                     *      */
        /*"      *                                                                *      */
        /*"      *  EM 19/01/2024 - RAUL BASILI ROTTA                             *      */
        /*"      *                                        PROCURE POR V.21        *      */
        /*"V.20  *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO  .............  - DEMANDA 455132                   *      */
        /*"      *                               HUSNI ALI HUSNI                  *      */
        /*"      *                               24/02/2023                       *      */
        /*"      *                               ESPECIFICACAO DOS CAMPOS NO      *      */
        /*"      *                               MOMENTO DA EXECUCAO DE INCLUSAO  *      */
        /*"      *                               DA TABELE MOVTO_DEBITOCC_CEF     *      */
        /*"      *                                       PROCURE POR V.20         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.19  *  VERSAO 19  - DEMANDA 402.982                                  *      */
        /*"      *             - RETIRAR GRAVACAO DE ERROS DA PROPOSTA DA VIEW    *      */
        /*"      *               V0BILHETE_ERROS                                  *      */
        /*"      *             - GRAVAR ERROS DA PROPOSTA NA NOVA TABELA          *      */
        /*"      *               VG_CRITICA_PROPOSTA PARA POSTERIOR ANALISE DO    *      */
        /*"      *               GESTOR NO ATALHO 04.23                           *      */
        /*"      *             - SOMAR 10000 AOS COD-ERRO UTILIZADOS NAS TABELAS  *      */
        /*"      *               DE BILHETE E VIDA AO MESMO TEMPO                 *      */
        /*"      *                                                                *      */
        /*"      *  EM 14/02/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.19        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 18...: DEMANDA 306086/TAREFA 307030                     *      */
        /*"      *               CADASTRAR APOLICE CORRETOR COMO CAIXA SEGURIDADE *      */
        /*"      *               (25267) PARA PROPOSTAS COM PRODUTO XS2 E DATA DE *      */
        /*"      *               EMISSAO MAIOR IGUAL A 16/08/2021 E TIPO COMISSAO *      */
        /*"      *               = 1 (CORRETAGEM) QUE HOJE SAO TRATADOS PELO      *      */
        /*"      *               WIZ                                              *      */
        /*"      * DATA .......: 13/08/2021                                       *      */
        /*"      * RESPONSAVEL.: HUSNI ALI HUSNI                                  *      */
        /*"      *                                                   PROCURE V.18 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.17  *   VERSAO 17 - TAREFA 245699                                    *      */
        /*"      *             - CALCULAR VALOR DE IOF E PARCELA COM DUAS CASAS   *      */
        /*"      *               DECIMAIS NO MOMENTO DE CARGA DAS PARCELAS        *      */
        /*"      *                                                                *      */
        /*"      *  22/05/2020 - HUSNI ALI HUSNI                                  *      */
        /*"      *                                        PROCURE POR V.17        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV.02 *   VERSAO 16   - HISTORIA 200604                                *      */
        /*"      *               - ALTERAR A APLICACAO PARA TRATAMENTO DA NOVA    *      */
        /*"      *                 EMPRESA (JV1). CORRIGIR SELECT NAS TABELAS     *      */
        /*"      *                 'BILHETE_PLANCOBER' E 'BILHETE_COBERTURA'.     *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/05/2019 - HERVAL SOUZA       PROCURE POR JV.02         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15   - HISTORIA 196716                                *      */
        /*"      *               - ALTERAR A APLICACAO PARA TRATAMENTO DA NOVA    *      */
        /*"      *                 EMPRESA (JV1) E SEUS PRODUTOS.                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/04/2019 - LUIZ FERNANDO      PROCURE POR V.15          *      */
        /*"      *                                                                *      */
        /*"      *--------------------------------------------------------------- *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 14 - HISTORIA 178780                                  *      */
        /*"      *             - MUDANCAS DE PRODUTOS ACOPLADOS - CAP             *      */
        /*"      *               PARA ATENDER A CIRCULAR SUSEP 569/576            *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/01/2019 - RIBAMAR MARQUES (ALTRAN)                     *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.14         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 13 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.13         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12 - CAD-68.235                                       *      */
        /*"      *                                                                *      */
        /*"      *             - CUSTOMIZACAO PARA O CANAL DE VENDA MAIS ESTUDO   *      */
        /*"      *               OS PROGRAMAS                                     *      */
        /*"      *                                                                *      */
        /*"      *                  . BI3005B                                     *      */
        /*"      *                  . BI3600B                                     *      */
        /*"      *                  . BI3602B                                     *      */
        /*"      *                  . BI0030B                                     *      */
        /*"      *                  . BI0031B                                     *      */
        /*"      *                  . BI0422B                                     *      */
        /*"      *                  . BI0602B                                     *      */
        /*"      *                  . BI6032B                                     *      */
        /*"      *                  . BI6114B                                     *      */
        /*"      *                  . BI7028B                                     *      */
        /*"      *                  . BI7029B                                     *      */
        /*"      *                  . BI7114B                                     *      */
        /*"      *                  . CB2005B                                     *      */
        /*"      *                                                                *      */
        /*"      *                FORAM PREPARADOS PARA TRABALHAR COM PARAMETROS  *      */
        /*"      *                DEFINIDOS NA SEGUROS.ARQUIVOS_SIVPF.            *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/04/2012 - TERCIO CARVALHO (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.12    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - CAD 201.012                                      *      */
        /*"      *               - AJUSTE NO PROGRAMA PARA NAO MAIS CRITICAR      *      */
        /*"      *                 CODIGO DE ERRO 834 PARA PRODUTOS SYSTEM CRED.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/02/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 - CAD 31.934                                       *      */
        /*"      *                                                                *      */
        /*"      *               - INCLUSAO DO CAMPO LK-NUM-NSA NOS PARAMETROS DA *      */
        /*"      *                 CHAMADA DA ROTINA FC0105B.                     *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/11/2009 - FAST COMPUTER - TERCIO FREITAS               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  009 - 21/03/2009 - FAST COMPUTER                              *      */
        /*"      *  CAD 21.756                                                    *      */
        /*"      *               MUDANCA NOS PRODUTOS ACOPLADOS COM CAPITALIZACAO *      */
        /*"      *               PARA ATENDER A CIRCULAR SUSEP                    *      */
        /*"      *               CIRCULAR 365 DE 27 DE MAIO DE 2008               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.09    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  008 - 13/01/2009 - EDIVALDO GOMES (FAST COMPUTER)             *      */
        /*"      *  SSI CAD 19535                                                 *      */
        /*"      *                  TRATA ABEND NO PROGRAMA (LOOP)                *      */
        /*"      *                                            PROCURE POR V.08    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  26/08/08   WELLINGTON VERAS (POLITEC)              *      */
        /*"      *    PROJETO FGV                                                 *      */
        /*"      *    INCLUSAO DA CLAUSULA WITH UR NO COMANDO SELECT   - WV0808   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  007 - 27/05/2008 - MARCO PAIVA (FAST COMPUTER)                *      */
        /*"      *  SSI CAD 10745                                                 *      */
        /*"      *                  CARREGA HOST DO PRODUTO DA TABELA             *      */
        /*"      *                  SEGUROS.V0BILHETE_PLCOBER PARA CRITICAR O     *      */
        /*"      *                  LIMITE DE RISCO PARA O PRODUTO 8103           *      */
        /*"      *                                            PROCURE POR V.07    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  006 - 02/04/2008 - WANGER ( FAST COMPUTER )                   *      */
        /*"      *  SSI CAD 8560                                                  *      */
        /*"      *                  ACEITAR VALOR DE ACUMULO DE RISCO PARA O      *      */
        /*"      *                  PRODUTO 8103                                  *      */
        /*"      *                                            PROCURE POR V.06    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  005 - 28/01/2008 - FAST COMPUTER - CADASTRA CORRETOR 24112    *      */
        /*"      *                     PARA FENAE /MARSH                          *      */
        /*"      *                     R1030-00-TRATA-FENAE                       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  004 - 18/09/2007 - MARCO PAIVA (FAST COMPUTER)                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
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
        /*"      *  SSI 15736/2007- ALTERA SITUACAO DOS BILHETES 84626712620      *      */
        /*"      *                                                                *      */
        /*"      *  SSI-17113  (24/07/2007) - ALTERA SITUACAO DOS BILHETES        *      */
        /*"      *                                  84626958360, 84627259848,     *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.04    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  003 - 24/04/2007 - MARCO PAIVA (FAST COMPUTER)                *      */
        /*"      *  SSI 15008/2007- ALTERA SITUACAO DOS BILHETES 84626006091      *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  002 - 02/04/2007 - FAST COMPUTER                              *      */
        /*"      *  SSI 14626/2007- ACEITAR RCAP COM DIFERENCA DE (+/-) R$ 10,00. *      */
        /*"      *                                            PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  001 - 09/03/2007 - LUCIA VIEIRA                               *      */
        /*"      *  SSI 13465/2007- ALTERA SITUACAO DOS  BILHETES 84625537808     *      */
        /*"      *                                                84622520254     *      */
        /*"      *  SSI 13465/2007- ALTERA SITUACAO DOS  BILHETES 84570893497     *      */
        /*"      *                                            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ESTA VERSAO DO DIA 16SET2002- A PROMOCAO DESTA VERSAO SE DEU   *      */
        /*"      * EM 26AGO2002 PELO MESSIAS.                                     *      */
        /*"      * VERSAO RETORNADA POR VIRGINIA EM 27SET2002                     *      */
        /*"      * ALTERACAO DE 27SET2002 - PROCURAR VIRG                         *      */
        /*"      * NO DECLARE DA V0BILHETE FOI ACRESCIDO O NUM_APOL_ANTERIOR      *      */
        /*"      * IGUAL A ZERO (NAO IRA PEGAR RENOVACAO)                         *      */
        /*"      *                                              VIRGINIA- SET/02  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * NOVA VERSAO DO SISTEMA                                         *      */
        /*"      *                                                                *      */
        /*"      *   SUBSTITUIDA A TABELA V0MOVIBIL PELA V0BILHETE                *      */
        /*"      *   EMITE-SE UMA APOLICE COLETIVA PARA CADA RAMO+OPCAO           *      */
        /*"      *   GERA O ADIANTAMENTO DE COMISSAO DA FENAE                     *      */
        /*"      *   ELIMINADA A GERACAO DE V0CLIENTE E V0ENDERECO (CB0006B)      *      */
        /*"      *   ELIMINADA A GERACAO DE TABELAS DO VG/APC                     *      */
        /*"      *   ELIMINADA A GERACAO DA V0OUTROS_COBER                        *      */
        /*"      *                                                                *      */
        /*"      *                                              FONSECA - NOV/96  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   A VERSAO DE APOLICE COLETIVA NAO FOI IMPLANTADA.             *      */
        /*"      *   O PROGRAMA EMITE UMA APOLICE PARA CADA BILHETE,              *      */
        /*"      *     BAIXANDO O RCAP CORRESPONDENTE                             *      */
        /*"      *                                                                *      */
        /*"      *                                              FONSECA - JAN/97  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   AGENCIA NAO CADASTRADA VER CL001.                            *      */
        /*"      *                                                                *      */
        /*"      *                                              CLOVIS  - 21/07/98*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   23/11/1998                CLOVIS                             *      */
        /*"      *                             ALTERA V0AVISOS_SALDOS.            *      */
        /*"      *                             PROCURE CL9811.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   12/02/2000                TERCIO                             *      */
        /*"      *                             O PROGRAMA PASSA A NAO MAIS TRATAR *      */
        /*"      *                             POR FAIXA BILHETES ORIUDOS DO      *      */
        /*"      *                             SIVPF                              *      */
        /*"      *                             PROCURE TL0002.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   26/06/2000                LUIZ CARLOS                        *      */
        /*"      *   PASSA A GERAR SIT-PROPOSTA DA PROPOSTA-FIDELIZ COM 'ANA', AO *      */
        /*"      *   INVEZ DE 'REJ', CASO A PROPOSTA TENHA ALGUM ERRO.            *      */
        /*"      *                            PROCURE LC0600.                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   28/08/2000                LUIZ CARLOS                        *      */
        /*"      *   PASSA A GERAR SIT-PROPOSTA DA PROPOSTA-FIDELIZ COM 'PEN', AO *      */
        /*"      *   INVEZ DE 'ANA', CASO A PROPOSTA TENHA ALGUM ERRO.            *      */
        /*"      *                            PROCURE LC0800.                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 25/09/2000                                                *      */
        /*"      *   ALTERA COMISSAO FENAE PARA 0,5% DO PREMIO TOTAL.             *      */
        /*"      *   CORRETOR 17256 PARA DOCUMENTOS COM INICIO APOS 01/10/2000    *      */
        /*"      *                         PROCURE POR CL0900                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 12/08/2002                                                *      */
        /*"      *   PASSA A CRITICAR PRFISSAO DECLINAVEL.                        *      */
        /*"      *                         PROCURE POR TL0208                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 26/08/2002                                                *      */
        /*"      *   CRITICAR PROFISSAO DECLINAVEL SOMENTE PARA O RAMO 82.        *      */
        /*"      *                         PROCURE POR MM2608                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 26/09/2002                                                *      */
        /*"      *   NAO DEIXAR ABENDAR QUANDO A OPCAO DE COBERTURA ESTIVER ZERADA*      */
        /*"      *                         PROCURE POR MM2609                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 27/09/2002                                                *      */
        /*"      *   PASSAR A CHECAR O LIMITE DE RISCO DO BILHETE AP (RAMO 82) POR*      */
        /*"      *   SEGURADO (CPF).                                              *      */
        /*"      *                         PROCURE POR MM2709                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 11/02/2003                                                *      */
        /*"      *   PASSAR A CRITICAR LIMITE DE IDADE.                           *      */
        /*"      *                                                                *      */
        /*"      *                         PROCURE POR TL0302                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 30/12/2003                                                *      */
        /*"      *   A LEITURA NA TABELA V0PROP_ESTIPULANTE ESTAVA MELANDO OS     *      */
        /*"      *   BILHETES, POIS, GRAVAVA COM O CODIGO DE PRODUTO 8299 O QUE   *      */
        /*"      *   EH UM CODIGO INVALIDO PARA O BILHETE.                        *      */
        /*"      *                                                                *      */
        /*"      *                         PROCURE POR MM1203                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 01/03/2004                                                *      */
        /*"      *   ALTERA COMISSAO FENAE PARA R$2,02 (FIXO).                    *      */
        /*"      *   CORRETOR 17256 PARA DOCUMENTOS COM QUITACAO                  *      */
        /*"      *                  A PARTIR DE 01/12/2003.                       *      */
        /*"      *                         PROCURE POR CL0304                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 13/04/2006 - TERCIO CARVALHO                              *      */
        /*"      *   SSI 8426/2006 - LIBERADA A CRITICA DE PROFISSAO              *      */
        /*"      *                         PROCURE POR FC0406                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 15/05/2006 - TERCIO CARVALHO                              *      */
        /*"      *                   INCLUIDO ERRO 202 EM FUNCAO DE ABEND         *      */
        /*"      *                         PROCURE POR FC0506                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
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
        /*"      * RECONVERSAO ANO 2000            CONSEDA4           12/09/1998  *      */
        /*"      *                                                                *      */
        /*"      *    29/12/98 - CONSEDA4                                         *      */
        /*"      *    ALTERACAO DO CALCULO DO IOF - ACESSO A TABELA V2RAMO        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         W77-ERRO            PIC  X(001)      VALUE ' '.*/
        public StringBasis W77_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
        /*"77         WIND                PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-NRRCAP        PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-SIT-PROP-SIVPF PIC X(003).*/
        public StringBasis WHOST_SIT_PROP_SIVPF { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         WHOST-NUMOPG        PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-NUMREC        PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-NUMBIL        PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis WHOST_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         BILACAT-NUMBIL      PIC S9(015)      VALUE +0  COMP-3*/
        public IntBasis BILACAT_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         WWORK-RAMO-ANT      PIC S9(004)                COMP.*/
        public IntBasis WWORK_RAMO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WWORK-OPCAO-ANT     PIC S9(004)                COMP.*/
        public IntBasis WWORK_OPCAO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RIND-PCIOF        PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1RIND_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         WWORK-MIN-DTINIVIG  PIC X(010).*/
        public StringBasis WWORK_MIN_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WWORK-MAX-DTTERVIG  PIC X(010).*/
        public StringBasis WWORK_MAX_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"77         VIND-AGENCIA        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-OPERACAO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NUMCONTA       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_NUMCONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DIGCONTA       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DIGCONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NUMCARTAO      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_NUMCARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DIADEBITO      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DIADEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NRCERTIF       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-MARGEM         PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_MARGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-USUARIO        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_USUARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTENVIO        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTENVIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTRETORNO      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTRETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CODRETORNO     PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CODRETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77         WS-COD-PRODUTO      PIC S9(004)   VALUE 0      COMP-5*/
        public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77         V0SIVPF-SIT-PROPOSTA PIC  X(003)     VALUE    SPACES.*/
        public StringBasis V0SIVPF_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"77         V0CONV-NUM-SICOB     PIC S9(015)     VALUE +0 COMP-3.*/
        public IntBasis V0CONV_NUM_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0CONV-NUM-PROPOSTA-SIVPF PIC S9(015) VALUE +0 COMP-3*/
        public IntBasis V0CONV_NUM_PROPOSTA_SIVPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0CONV-ORIGEM-PROPOSTA    PIC S9(004) VALUE +0 COMP.*/
        public IntBasis V0CONV_ORIGEM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77         V0BILH-OPE-CONTA    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_OPE_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-NUM-CONTA    PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0BILH_NUM_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0BILH-DIG-CONTA    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_DIG_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77         V0BILH-DTA-VENDA    PIC  X(010).*/
        public StringBasis V0BILH_DTA_VENDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0BILH-DIGCTA-DEB   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0BILH_DIGCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-OPCAO-COBER  PIC S9(004)               COMP.*/
        public IntBasis V0BILH_OPCAO_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0BILH-DTQITBCO     PIC  X(010).*/
        public StringBasis V0BILH_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"77         V0APCB-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APCB_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCB-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APCB_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCB-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0APCB_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APCB-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0APCB_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCB-CODPRODU     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APCB_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCB-NUM-MATR     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0APCB_NUM_MATR { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0APCB-TIPOCOB      PIC  X(001).*/
        public StringBasis V0APCB_TIPOCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APCB-AGECOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0APCB_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCB-AGENCIA      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APCB_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCB-OPE-CONTA    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APCB_OPE_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCB-NUM-CONTA    PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0APCB_NUM_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APCB-DIG-CONTA    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APCB_DIG_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCB-AGENCIA-DEB  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APCB_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCB-OPERACAO-DEB PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APCB_OPERACAO_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCB-NUMCTA-DEB   PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0APCB_NUMCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APCB-DIGCTA-DEB   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APCB_DIGCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCB-NUM-CARTAO   PIC S9(016)      VALUE +0 COMP-3.*/
        public IntBasis V0APCB_NUM_CARTAO { get; set; } = new IntBasis(new PIC("S9", "16", "S9(016)"));
        /*"77         V0APCB-DIA-DEBITO   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APCB_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCB-NRCERTIF     PIC  X(025).*/
        public StringBasis V0APCB_NRCERTIF { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        /*"77         V0APCB-MARGEM       PIC S9(003)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0APCB_MARGEM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
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
        /*"77         V0APOL-NUMBIL       PIC S9(015)   VALUE +0 COMP-3.*/
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
        /*"77         V0MVDB-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0MVDB_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MVDB-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0MVDB_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0MVDB-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0MVDB_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MVDB-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0MVDB_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0MVDB-SITUACAO     PIC  X(001).*/
        public StringBasis V0MVDB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0MVDB-DTVENCTO     PIC  X(010).*/
        public StringBasis V0MVDB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0MVDB-VLR-DEBITO   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0MVDB_VLR_DEBITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0MVDB-DTMOVTO      PIC  X(010).*/
        public StringBasis V0MVDB_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0MVDB-DIA-DEBITO   PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0MVDB_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0MVDB-AGENCIA-DEB  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0MVDB_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0MVDB-OPERACAO-DEB PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0MVDB_OPERACAO_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0MVDB-NUMCTA-DEB   PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0MVDB_NUMCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0MVDB-DIGCTA-DEB   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0MVDB_DIGCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0MVDB-CONVENIO     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0MVDB_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MVDB-DTENVIO      PIC  X(010).*/
        public StringBasis V0MVDB_DTENVIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0MVDB-DTRETORNO    PIC  X(010).*/
        public StringBasis V0MVDB_DTRETORNO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0MVDB-COD-RETORNO  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0MVDB_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0MVDB-NSAS         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0MVDB_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0MVDB-COD-USUARIO  PIC  X(008).*/
        public StringBasis V0MVDB_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0MVDB-REQUISICAO   PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0MVDB_REQUISICAO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0MVDB-NUM-CARTAO   PIC S9(016)      VALUE +0 COMP-3.*/
        public IntBasis V0MVDB_NUM_CARTAO { get; set; } = new IntBasis(new PIC("S9", "16", "S9(016)"));
        /*"77         V0MVDB-SEQUENCIA    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0MVDB_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0MVDB-NUM-LOTE     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0MVDB_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MVDB-DTCREDITO    PIC  X(010).*/
        public StringBasis V0MVDB_DTCREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0MVDB-STATUS       PIC  X(002).*/
        public StringBasis V0MVDB_STATUS { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V0MVDB-VLR-CREDITO  PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0MVDB_VLR_CREDITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
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
        /*"01  WS-I-ERRO                   PIC  9(003) VALUE ZEROS.*/
        public IntBasis WS_I_ERRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"01  WS-FLAG-TEM-ERRO            PIC  X(001) VALUE 'N'.*/
        public StringBasis WS_FLAG_TEM_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WORK-TAB-ERROS-CERT.*/
        public CB2005B_WORK_TAB_ERROS_CERT WORK_TAB_ERROS_CERT { get; set; } = new CB2005B_WORK_TAB_ERROS_CERT();
        public class CB2005B_WORK_TAB_ERROS_CERT : VarBasis
        {
            /*"    05  WS-TAB-ERROS-CERT   OCCURS 100 TIMES.*/
            public ListBasis<CB2005B_WS_TAB_ERROS_CERT> WS_TAB_ERROS_CERT { get; set; } = new ListBasis<CB2005B_WS_TAB_ERROS_CERT>(100);
            public class CB2005B_WS_TAB_ERROS_CERT : VarBasis
            {
                /*"      10  TB-ERRO-CERT          PIC S9(004) COMP.*/
                public IntBasis TB_ERRO_CERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"01  WORK-JV1.*/
            }
        }
        public CB2005B_WORK_JV1 WORK_JV1 { get; set; } = new CB2005B_WORK_JV1();
        public class CB2005B_WORK_JV1 : VarBasis
        {
            /*" 05 WS-JV1-PROGRAMA                  PIC  X(008)    VALUE SPACES*/
            public StringBasis WS_JV1_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*" 05 WH-JV1-COD-ORGAO                 PIC S9(004) COMP-5 VALUE +0*/
            public IntBasis WH_JV1_COD_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*" 05 WS-JV1-ACHEI-PRODUTO             PIC  X(003)    VALUE  'SIM'*/
            public StringBasis WS_JV1_ACHEI_PRODUTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"SIM");
            /*"01  WREA88.*/
        }
        public CB2005B_WREA88 WREA88 { get; set; } = new CB2005B_WREA88();
        public class CB2005B_WREA88 : VarBasis
        {
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
							/*" 88 ORIGEM-MANUAL                            VALUE 06. */
							new SelectorItemBasis("ORIGEM_MANUAL", "06"),
							/*" 88 ORIGEM-REMOTA                            VALUE 07. */
							new SelectorItemBasis("ORIGEM_REMOTA", "07"),
							/*" 88 ORIGEM-INTRANET                          VALUE 08. */
							new SelectorItemBasis("ORIGEM_INTRANET", "08"),
							/*" 88 ORIGEM-INTERNET                          VALUE 09. */
							new SelectorItemBasis("ORIGEM_INTERNET", "09"),
							/*" 88 ORIGEM-CORRET-VIT                        VALUE 10. */
							new SelectorItemBasis("ORIGEM_CORRET_VIT", "10"),
							/*" 88 ORIGEM-FILIAL                            VALUE 11. */
							new SelectorItemBasis("ORIGEM_FILIAL", "11"),
							/*" 88 ORIGEM-MARSH                             VALUE 12. */
							new SelectorItemBasis("ORIGEM_MARSH", "12"),
							/*" 88 ORIGEM-LOTERICO                          VALUE 13. */
							new SelectorItemBasis("ORIGEM_LOTERICO", "13"),
							/*" 88 ORIGEM-CORRESPOND                        VALUE 14. */
							new SelectorItemBasis("ORIGEM_CORRESPOND", "14"),
							/*" 88 ORIGEM-SYSTEMCRED                        VALUE 1001. */
							new SelectorItemBasis("ORIGEM_SYSTEMCRED", "1001"),
							/*" 88 ORIGEM-GRUPOFIG                          VALUE 1002. */
							new SelectorItemBasis("ORIGEM_GRUPOFIG", "1002")
                }
            };

            /*"    05  W-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  CANAL REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_CB2005B_CANAL _canal { get; set; }
            public _REDEF_CB2005B_CANAL CANAL
            {
                get { _canal = new _REDEF_CB2005B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_CB2005B_CANAL : VarBasis
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

                /*"        07  FILLER                    PIC X(013).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"01         WS-COD-CORRETOR      PIC  9(009)     VALUE 0.*/

                public _REDEF_CB2005B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                }

            }
        }

        public SelectorBasis WS_COD_CORRETOR { get; set; } = new SelectorBasis("009", "0")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88       N88-COD-CORRETOR    VALUES  2496,  2933,  6327,  7005,                                      9440, 17256, 17604, 17752,                                     18040, 19224, 23914, 23922,                                     23931, 23949, 23957, 24112,                                     24121, 24163, 24236, 24287,                                     24295, 24309, 24317, 24333,                                     24341, 24368, 24384, 24392,                                     24431, 24449, 24457, 24481,                                     24716, 24937, 24945, 24970,                                     24996, 25003, 101150. */
							new SelectorItemBasis("N88_COD_CORRETOR", "2496,2933,6327,7005,9440,17256,17604,17752,18040,19224,23914,23922,23931,23949,23957,24112,24121,24163,24236,24287,24295,24309,24317,24333,24341,24368,24384,24392,24431,24449,24457,24481,24716,24937,24945,24970,24996,25003,101150")
                }
        };

        /*"01  TAB-CBO1.*/
        public CB2005B_TAB_CBO1 TAB_CBO1 { get; set; } = new CB2005B_TAB_CBO1();
        public class CB2005B_TAB_CBO1 : VarBasis
        {
            /*"    05      TAB-CBO.*/
            public CB2005B_TAB_CBO TAB_CBO { get; set; } = new CB2005B_TAB_CBO();
            public class CB2005B_TAB_CBO : VarBasis
            {
                /*"      10    FILLER    OCCURS    999   TIMES.*/
                public ListBasis<CB2005B_FILLER_1> FILLER_1 { get; set; } = new ListBasis<CB2005B_FILLER_1>(999);
                public class CB2005B_FILLER_1 : VarBasis
                {
                    /*"        15  TAB-DESCR-CBO-C          PIC  X(20).*/
                    public StringBasis TAB_DESCR_CBO_C { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                    /*"01           WS-TIME.*/
                }
            }
        }
        public CB2005B_WS_TIME WS_TIME { get; set; } = new CB2005B_WS_TIME();
        public class CB2005B_WS_TIME : VarBasis
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
        private _REDEF_CB2005B_WS000_HORA_TIME_REDF _ws000_hora_time_redf { get; set; }
        public _REDEF_CB2005B_WS000_HORA_TIME_REDF WS000_HORA_TIME_REDF
        {
            get { _ws000_hora_time_redf = new _REDEF_CB2005B_WS000_HORA_TIME_REDF(); _.Move(WS000_HORA_TIME, _ws000_hora_time_redf); VarBasis.RedefinePassValue(WS000_HORA_TIME, _ws000_hora_time_redf, WS000_HORA_TIME); _ws000_hora_time_redf.ValueChanged += () => { _.Move(_ws000_hora_time_redf, WS000_HORA_TIME); }; return _ws000_hora_time_redf; }
            set { VarBasis.RedefinePassValue(value, _ws000_hora_time_redf, WS000_HORA_TIME); }
        }  //Redefines
        public class _REDEF_CB2005B_WS000_HORA_TIME_REDF : VarBasis
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

            public _REDEF_CB2005B_WS000_HORA_TIME_REDF()
            {
                WS000_HT.ValueChanged += OnValueChanged;
                WS000_P1.ValueChanged += OnValueChanged;
                WS000_MT.ValueChanged += OnValueChanged;
                WS000_P2.ValueChanged += OnValueChanged;
                WS000_ST.ValueChanged += OnValueChanged;
            }

        }
        public CB2005B_WS000_PARM_PROSOMD1 WS000_PARM_PROSOMD1 { get; set; } = new CB2005B_WS000_PARM_PROSOMD1();
        public class CB2005B_WS000_PARM_PROSOMD1 : VarBasis
        {
            /*"  05         WS000-DATA01       PIC  9(008).*/
            public IntBasis WS000_DATA01 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05         WS000-QTDIAS       PIC S9(005) COMP-3.*/
            public IntBasis WS000_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05         WS000-DATA02       PIC  9(008).*/
            public IntBasis WS000_DATA02 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"01         WS002-ACUMULADORES.*/
        }
        public CB2005B_WS002_ACUMULADORES WS002_ACUMULADORES { get; set; } = new CB2005B_WS002_ACUMULADORES();
        public class CB2005B_WS002_ACUMULADORES : VarBasis
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
        /*"01     LK-COD-USUARIO          PIC  X(8).*/
        public StringBasis LK_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
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
        /*"01  W-TAB-SISTEMA-ORIGEM.*/
        public CB2005B_W_TAB_SISTEMA_ORIGEM W_TAB_SISTEMA_ORIGEM { get; set; } = new CB2005B_W_TAB_SISTEMA_ORIGEM();
        public class CB2005B_W_TAB_SISTEMA_ORIGEM : VarBasis
        {
            /*"    05  WTAB-SISTEMA-ORIGEM   OCCURS    200  TIMES                                PIC  S9(004) COMP.*/
            public ListBasis<IntBasis, Int64> WTAB_SISTEMA_ORIGEM { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 200);
            /*"01     AREA-DE-WORK.*/
        }
        public CB2005B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new CB2005B_AREA_DE_WORK();
        public class CB2005B_AREA_DE_WORK : VarBasis
        {
            /*"  05   WS-SIT-PRODUTO           PIC  9(001)  VALUE 0.*/

            public SelectorBasis WS_SIT_PRODUTO { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 WS-PROD-RUNON                         VALUE 1. */
							new SelectorItemBasis("WS_PROD_RUNON", "1"),
							/*" 88 WS-PROD-RUNOFF                        VALUE 2. */
							new SelectorItemBasis("WS_PROD_RUNOFF", "2")
                }
            };

            /*"  05   WINDI                         PIC S9(004) COMP VALUE +0.*/
            public IntBasis WINDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05   WIND1                         PIC S9(004) COMP VALUE +0.*/
            public IntBasis WIND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05   WINF                          PIC S9(004) COMP VALUE +0.*/
            public IntBasis WINF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05   WSUP                          PIC S9(004) COMP VALUE +0.*/
            public IntBasis WSUP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05   WTEM-SISTEMA-ORIGEM           PIC  X(003) VALUE SPACES.*/
            public StringBasis WTEM_SISTEMA_ORIGEM { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05   WS-COMBINACAO                 PIC  X(020).*/
            public StringBasis WS_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05   WS-COMBINACAO-R               REDEFINES       WS-COMBINACAO.*/
            private _REDEF_CB2005B_WS_COMBINACAO_R _ws_combinacao_r { get; set; }
            public _REDEF_CB2005B_WS_COMBINACAO_R WS_COMBINACAO_R
            {
                get { _ws_combinacao_r = new _REDEF_CB2005B_WS_COMBINACAO_R(); _.Move(WS_COMBINACAO, _ws_combinacao_r); VarBasis.RedefinePassValue(WS_COMBINACAO, _ws_combinacao_r, WS_COMBINACAO); _ws_combinacao_r.ValueChanged += () => { _.Move(_ws_combinacao_r, WS_COMBINACAO); }; return _ws_combinacao_r; }
                set { VarBasis.RedefinePassValue(value, _ws_combinacao_r, WS_COMBINACAO); }
            }  //Redefines
            public class _REDEF_CB2005B_WS_COMBINACAO_R : VarBasis
            {
                /*"       10  WS-COMB OCCURS 20 TIMES   PIC  X(001).*/
                public ListBasis<StringBasis, string> WS_COMB { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 20);
                /*"  05   WS-COMBINACAO-9               PIC  9(009).*/

                public _REDEF_CB2005B_WS_COMBINACAO_R()
                {
                    WS_COMB.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_COMBINACAO_9 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05   WS-NUM-TITULO-X.*/
            public CB2005B_WS_NUM_TITULO_X WS_NUM_TITULO_X { get; set; } = new CB2005B_WS_NUM_TITULO_X();
            public class CB2005B_WS_NUM_TITULO_X : VarBasis
            {
                /*"       10  WS-NUM-PLANO              PIC  9(003).*/
                public IntBasis WS_NUM_PLANO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  WS-NUM-SERIE              PIC  9(003).*/
                public IntBasis WS_NUM_SERIE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  WS-NUM-TITULO             PIC  9(006).*/
                public IntBasis WS_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"  05   WS-NUM-TITULO-9               REDEFINES       WS-NUM-TITULO-X               PIC  9(012).*/
            }
            private _REDEF_IntBasis _ws_num_titulo_9 { get; set; }
            public _REDEF_IntBasis WS_NUM_TITULO_9
            {
                get { _ws_num_titulo_9 = new _REDEF_IntBasis(new PIC("9", "012", "9(012).")); ; _.Move(WS_NUM_TITULO_X, _ws_num_titulo_9); VarBasis.RedefinePassValue(WS_NUM_TITULO_X, _ws_num_titulo_9, WS_NUM_TITULO_X); _ws_num_titulo_9.ValueChanged += () => { _.Move(_ws_num_titulo_9, WS_NUM_TITULO_X); }; return _ws_num_titulo_9; }
                set { VarBasis.RedefinePassValue(value, _ws_num_titulo_9, WS_NUM_TITULO_X); }
            }  //Redefines
            /*"  05   WS-SQLCODE                    PIC  ----9.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "5", "----9."));
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
            /*"  05         WFIM-SISTEMA-ORIGEM PIC X(003)   VALUE SPACES.*/
            public StringBasis WFIM_SISTEMA_ORIGEM { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WS-SIVPF          PIC  X(001)    VALUE SPACES.*/
            public StringBasis WS_SIVPF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         W-INTEIRO         PIC  9(004)    VALUE ZEROS.*/
            public IntBasis W_INTEIRO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         W-RESTO           PIC  9(004)    VALUE ZEROS.*/
            public IntBasis W_RESTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WWORK-FUNDAO      PIC  X(001)    VALUE SPACE.*/
            public StringBasis WWORK_FUNDAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WPROC-BILHETES    PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WPROC_BILHETES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WTEM-PROPESTIP    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_PROPESTIP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-GELMR        PIC  X(003)    VALUE SPACES.*/
            public StringBasis WTEM_GELMR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WWORK-NUM-APOL    PIC  9(013)    VALUE ZEROS.*/
            public IntBasis WWORK_NUM_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUM-APOL.*/
            private _REDEF_CB2005B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_CB2005B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_CB2005B_FILLER_2(); _.Move(WWORK_NUM_APOL, _filler_2); VarBasis.RedefinePassValue(WWORK_NUM_APOL, _filler_2, WWORK_NUM_APOL); _filler_2.ValueChanged += () => { _.Move(_filler_2, WWORK_NUM_APOL); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WWORK_NUM_APOL); }
            }  //Redefines
            public class _REDEF_CB2005B_FILLER_2 : VarBasis
            {
                /*"    10       WWORK-ORG-APOL    PIC  9(003).*/
                public IntBasis WWORK_ORG_APOL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-RMO-APOL    PIC  9(002).*/
                public IntBasis WWORK_RMO_APOL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-SEQ-APOL    PIC  9(008).*/
                public IntBasis WWORK_SEQ_APOL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  05         WWORK-PCPARCOR-I  PIC S9(003)V99   COMP-3.*/

                public _REDEF_CB2005B_FILLER_2()
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
            /*"  05         WS-VAL-IOCC-IX    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_VAL_IOCC_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WS-PRM-TOTAL-IX   PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_PRM_TOTAL_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
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
            private _REDEF_CB2005B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_CB2005B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_CB2005B_FILLER_3(); _.Move(WWORK_NUM_ORDEM, _filler_3); VarBasis.RedefinePassValue(WWORK_NUM_ORDEM, _filler_3, WWORK_NUM_ORDEM); _filler_3.ValueChanged += () => { _.Move(_filler_3, WWORK_NUM_ORDEM); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WWORK_NUM_ORDEM); }
            }  //Redefines
            public class _REDEF_CB2005B_FILLER_3 : VarBasis
            {
                /*"    10       WWORK-ORD-CONGE   PIC  9(004).*/
                public IntBasis WWORK_ORD_CONGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-ORD-ORGAO   PIC  9(003).*/
                public IntBasis WWORK_ORD_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-ORD-SEQUE   PIC  9(007).*/
                public IntBasis WWORK_ORD_SEQUE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"  05         WWORK-NUMBIL      PIC  9(015)    VALUE ZEROS.*/

                public _REDEF_CB2005B_FILLER_3()
                {
                    WWORK_ORD_CONGE.ValueChanged += OnValueChanged;
                    WWORK_ORD_ORGAO.ValueChanged += OnValueChanged;
                    WWORK_ORD_SEQUE.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_NUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUMBIL.*/
            private _REDEF_CB2005B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_CB2005B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_CB2005B_FILLER_4(); _.Move(WWORK_NUMBIL, _filler_4); VarBasis.RedefinePassValue(WWORK_NUMBIL, _filler_4, WWORK_NUMBIL); _filler_4.ValueChanged += () => { _.Move(_filler_4, WWORK_NUMBIL); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WWORK_NUMBIL); }
            }  //Redefines
            public class _REDEF_CB2005B_FILLER_4 : VarBasis
            {
                /*"    10       FILLER            PIC  9(004).*/
                public IntBasis FILLER_5 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-NRRCAP      PIC  9(009).*/
                public IntBasis WWORK_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10       FILLER            PIC  9(002).*/
                public IntBasis FILLER_6 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WWORK-DATA.*/

                public _REDEF_CB2005B_FILLER_4()
                {
                    FILLER_5.ValueChanged += OnValueChanged;
                    WWORK_NRRCAP.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                }

            }
            public CB2005B_WWORK_DATA WWORK_DATA { get; set; } = new CB2005B_WWORK_DATA();
            public class CB2005B_WWORK_DATA : VarBasis
            {
                /*"    10       WWORK-ANO         PIC  9(004).*/
                public IntBasis WWORK_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WWORK-MES         PIC  9(002).*/
                public IntBasis WWORK_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
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
            private _REDEF_CB2005B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_CB2005B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_CB2005B_FILLER_9(); _.Move(WDATA_REL, _filler_9); VarBasis.RedefinePassValue(WDATA_REL, _filler_9, WDATA_REL); _filler_9.ValueChanged += () => { _.Move(_filler_9, WDATA_REL); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, WDATA_REL); }
            }  //Redefines
            public class _REDEF_CB2005B_FILLER_9 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-SISTEMA.*/

                public _REDEF_CB2005B_FILLER_9()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_11.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public CB2005B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new CB2005B_WDATA_SISTEMA();
            public class CB2005B_WDATA_SISTEMA : VarBasis
            {
                /*"    10       WDATA-SIS-ANO     PIC  9(004).*/
                public IntBasis WDATA_SIS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-MES     PIC  9(002).*/
                public IntBasis WDATA_SIS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-DIA     PIC  9(002).*/
                public IntBasis WDATA_SIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WWORK-DATAINI     PIC  9(008)  VALUE ZEROS.*/
            }
            public IntBasis WWORK_DATAINI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER            REDEFINES    WWORK-DATAINI.*/
            private _REDEF_CB2005B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_CB2005B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_CB2005B_FILLER_14(); _.Move(WWORK_DATAINI, _filler_14); VarBasis.RedefinePassValue(WWORK_DATAINI, _filler_14, WWORK_DATAINI); _filler_14.ValueChanged += () => { _.Move(_filler_14, WWORK_DATAINI); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, WWORK_DATAINI); }
            }  //Redefines
            public class _REDEF_CB2005B_FILLER_14 : VarBasis
            {
                /*"    10       WWORK-DIAINI      PIC  9(002).*/
                public IntBasis WWORK_DIAINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-MESINI      PIC  9(002).*/
                public IntBasis WWORK_MESINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-ANOINI      PIC  9(004).*/
                public IntBasis WWORK_ANOINI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WWORK-DATATER     PIC  9(008)  VALUE ZEROS.*/

                public _REDEF_CB2005B_FILLER_14()
                {
                    WWORK_DIAINI.ValueChanged += OnValueChanged;
                    WWORK_MESINI.ValueChanged += OnValueChanged;
                    WWORK_ANOINI.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_DATATER { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER            REDEFINES    WWORK-DATATER.*/
            private _REDEF_CB2005B_FILLER_15 _filler_15 { get; set; }
            public _REDEF_CB2005B_FILLER_15 FILLER_15
            {
                get { _filler_15 = new _REDEF_CB2005B_FILLER_15(); _.Move(WWORK_DATATER, _filler_15); VarBasis.RedefinePassValue(WWORK_DATATER, _filler_15, WWORK_DATATER); _filler_15.ValueChanged += () => { _.Move(_filler_15, WWORK_DATATER); }; return _filler_15; }
                set { VarBasis.RedefinePassValue(value, _filler_15, WWORK_DATATER); }
            }  //Redefines
            public class _REDEF_CB2005B_FILLER_15 : VarBasis
            {
                /*"    10       WWORK-DIATER      PIC  9(002).*/
                public IntBasis WWORK_DIATER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-MESTER      PIC  9(002).*/
                public IntBasis WWORK_MESTER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-ANOTER      PIC  9(004).*/
                public IntBasis WWORK_ANOTER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WWORK-QTCOSSEG    PIC  9(002)  VALUE ZEROS.*/

                public _REDEF_CB2005B_FILLER_15()
                {
                    WWORK_DIATER.ValueChanged += OnValueChanged;
                    WWORK_MESTER.ValueChanged += OnValueChanged;
                    WWORK_ANOTER.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_QTCOSSEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WDATA-CURR.*/
            public CB2005B_WDATA_CURR WDATA_CURR { get; set; } = new CB2005B_WDATA_CURR();
            public class CB2005B_WDATA_CURR : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CABEC.*/
            }
            public CB2005B_WDATA_CABEC WDATA_CABEC { get; set; } = new CB2005B_WDATA_CABEC();
            public class CB2005B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WS-CODANGAR-R.*/
            }
            public CB2005B_WS_CODANGAR_R WS_CODANGAR_R { get; set; } = new CB2005B_WS_CODANGAR_R();
            public class CB2005B_WS_CODANGAR_R : VarBasis
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
            public CB2005B_PROM11W099 PROM11W099 { get; set; } = new CB2005B_PROM11W099();
            public class CB2005B_PROM11W099 : VarBasis
            {
                /*"    10       PROM11W099-NUMERO   PIC  9(015).*/
                public IntBasis PROM11W099_NUMERO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10       PROM11W099-TAM      PIC S9(004)   COMP.*/
                public IntBasis PROM11W099_TAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10       PROM11W099-DAC      PIC  X(001).*/
                public StringBasis PROM11W099_DAC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05         WS-NUMREC-R.*/
            }
            public CB2005B_WS_NUMREC_R WS_NUMREC_R { get; set; } = new CB2005B_WS_NUMREC_R();
            public class CB2005B_WS_NUMREC_R : VarBasis
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
            public CB2005B_WDATA_MOVABE WDATA_MOVABE { get; set; } = new CB2005B_WDATA_MOVABE();
            public class CB2005B_WDATA_MOVABE : VarBasis
            {
                /*"    10          WDATA-AA-MOVABE PIC  9(004)     VALUE    ZEROS.*/
                public IntBasis WDATA_AA_MOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER          PIC  X(001)     VALUE   '-'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10          WDATA-MM-MOVABE PIC  9(002)     VALUE    ZEROS.*/
                public IntBasis WDATA_MM_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER          PIC  X(001)     VALUE   '-'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10          WDATA-DD-MOVABE PIC  9(002)     VALUE    ZEROS.*/
                public IntBasis WDATA_DD_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05            WDATA-WORK.*/
            }
            public CB2005B_WDATA_WORK WDATA_WORK { get; set; } = new CB2005B_WDATA_WORK();
            public class CB2005B_WDATA_WORK : VarBasis
            {
                /*"    10          WDATA-AA-WORK   PIC  9(004)     VALUE    ZEROS.*/
                public IntBasis WDATA_AA_WORK { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER          PIC  X(001)     VALUE   '-'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10          WDATA-MM-WORK   PIC  9(002)     VALUE    ZEROS.*/
                public IntBasis WDATA_MM_WORK { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER          PIC  X(001)     VALUE   '-'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10          WDATA-DD-WORK   PIC  9(002)     VALUE    ZEROS.*/
                public IntBasis WDATA_DD_WORK { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        WABEND.*/
            }
            public CB2005B_WABEND WABEND { get; set; } = new CB2005B_WABEND();
            public class CB2005B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'CB2005B '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"CB2005B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01            LPARM.*/
            }
        }
        public CB2005B_LPARM LPARM { get; set; } = new CB2005B_LPARM();
        public class CB2005B_LPARM : VarBasis
        {
            /*"  03          LPARM01.*/
            public CB2005B_LPARM01 LPARM01 { get; set; } = new CB2005B_LPARM01();
            public class CB2005B_LPARM01 : VarBasis
            {
                /*"    10        LPARM01-DD          PIC  9(002).*/
                public IntBasis LPARM01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        LPARM01-MM          PIC  9(002).*/
                public IntBasis LPARM01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        LPARM01-AA          PIC  9(004).*/
                public IntBasis LPARM01_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03          LPARM02.*/
            }
            public CB2005B_LPARM02 LPARM02 { get; set; } = new CB2005B_LPARM02();
            public class CB2005B_LPARM02 : VarBasis
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
            /*"01           FC0001S-LINKAGE.*/
        }
        public CB2005B_FC0001S_LINKAGE FC0001S_LINKAGE { get; set; } = new CB2005B_FC0001S_LINKAGE();
        public class CB2005B_FC0001S_LINKAGE : VarBasis
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
        }


        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Copies.GEJVWCNT GEJVWCNT { get; set; } = new Copies.GEJVWCNT();
        public Copies.GEJVW002 GEJVW002 { get; set; } = new Copies.GEJVW002();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public Dclgens.MOVFEDCA MOVFEDCA { get; set; } = new Dclgens.MOVFEDCA();
        public Dclgens.TITFEDCA TITFEDCA { get; set; } = new Dclgens.TITFEDCA();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.PARAMGER PARAMGER { get; set; } = new Dclgens.PARAMGER();
        public Dclgens.GE101 GE101 { get; set; } = new Dclgens.GE101();
        public CB2005B_CORIGEM CORIGEM { get; set; } = new CB2005B_CORIGEM();
        public CB2005B_V0BILHETE V0BILHETE { get; set; } = new CB2005B_V0BILHETE();
        public CB2005B_V1COSSEGPROD V1COSSEGPROD { get; set; } = new CB2005B_V1COSSEGPROD();
        public CB2005B_V1RCAPCOMP V1RCAPCOMP { get; set; } = new CB2005B_V1RCAPCOMP();
        public CB2005B_CCBO CCBO { get; set; } = new CB2005B_CCBO();
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
            /*" -1542- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1545- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1548- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1552- DISPLAY '---------------------------------' '----------------------------' */
            _.Display($"-------------------------------------------------------------");

            /*" -1554- DISPLAY 'PROGRAMA CB2005B - VERSAO V.22 ' '- DEMANDA 589106 - 09/08/2024.' */
            _.Display($"PROGRAMA CB2005B - VERSAO V.22 - DEMANDA 589106 - 09/08/2024.");

            /*" -1561- DISPLAY 'DATA/HORA DE COMPILACAO = ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"DATA/HORA DE COMPILACAO = FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1563- DISPLAY '---------------------------------' '----------------------------' */
            _.Display($"-------------------------------------------------------------");

            /*" -1565- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1570- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -1571- INITIALIZE LK-GEJVW002-NOM-PROG-ORIGEM LK-GEJVW002-COD-USUARIO-ORIGEM LK-GEJVW002-SIAS-NUM-EMP LK-GEJVW002-SIAS-DTA-INI LK-GEJVW002-SIAS-COD-CGCCPF LK-GEJVW002-SIAS-COD-LIDER LK-GEJVW002-SIAS-COD-EMP-CAP LK-GEJVW002-PREV-NUM-EMP LK-GEJVW002-PREV-DTA-INI LK-GEJVW002-PREV-COD-CGCCPF LK-GEJVW002-PREV-COD-LIDER LK-GEJVW002-PREV-COD-EMP-CAP LK-GEJVW002-JV-NUM-EMP LK-GEJVW002-JV-DTA-INI LK-GEJVW002-JV-COD-CGCCPF LK-GEJVW002-JV-COD-LIDER LK-GEJVW002-JV-COD-EMP-CAP. */
            _.Initialize(
                GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM
                , GEJVW002.LK_GEJVW002_COD_USUARIO_ORIGEM
                , GEJVW002.LK_GEJVW002_SIAS_NUM_EMP
                , GEJVW002.LK_GEJVW002_SIAS_DTA_INI
                , GEJVW002.LK_GEJVW002_SIAS_COD_CGCCPF
                , GEJVW002.LK_GEJVW002_SIAS_COD_LIDER
                , GEJVW002.LK_GEJVW002_SIAS_COD_EMP_CAP
                , GEJVW002.LK_GEJVW002_PREV_NUM_EMP
                , GEJVW002.LK_GEJVW002_PREV_DTA_INI
                , GEJVW002.LK_GEJVW002_PREV_COD_CGCCPF
                , GEJVW002.LK_GEJVW002_PREV_COD_LIDER
                , GEJVW002.LK_GEJVW002_PREV_COD_EMP_CAP
                , GEJVW002.LK_GEJVW002_JV_NUM_EMP
                , GEJVW002.LK_GEJVW002_JV_DTA_INI
                , GEJVW002.LK_GEJVW002_JV_COD_CGCCPF
                , GEJVW002.LK_GEJVW002_JV_COD_LIDER
                , GEJVW002.LK_GEJVW002_JV_COD_EMP_CAP
            );

            /*" -1575- INITIALIZE LK-GEJVWCNT-IND-ERRO LK-GEJVWCNT-MENSAGEM-RETORNO LK-GEJVWCNT-NOME-TABELA LK-GEJVWCNT-SQLCODE LK-GEJVWCNT-SQLERRMC. */
            _.Initialize(
                GEJVWCNT.LK_GEJVWCNT_IND_ERRO
                , GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO
                , GEJVWCNT.LK_GEJVWCNT_NOME_TABELA
                , GEJVWCNT.LK_GEJVWCNT_SQLCODE
                , GEJVWCNT.LK_GEJVWCNT_SQLERRMC
            );

            /*" -1576- MOVE 'CB2005B' TO LK-GEJVW002-NOM-PROG-ORIGEM. */
            _.Move("CB2005B", GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM);

            /*" -1578- MOVE 'BATCH' TO LK-GEJVW002-COD-USUARIO-ORIGEM. */
            _.Move("BATCH", GEJVW002.LK_GEJVW002_COD_USUARIO_ORIGEM);

            /*" -1578- MOVE 'GEJVS002' TO WS-JV1-PROGRAMA. */
            _.Move("GEJVS002", WORK_JV1.WS_JV1_PROGRAMA);

            /*" -1580- CALL WS-JV1-PROGRAMA USING LK-GEJVW002-NOM-PROG-ORIGEM LK-GEJVW002-COD-USUARIO-ORIGEM LK-GEJVW002-SIAS-NUM-EMP LK-GEJVW002-SIAS-DTA-INI LK-GEJVW002-SIAS-COD-LIDER LK-GEJVW002-SIAS-COD-CGCCPF LK-GEJVW002-SIAS-COD-EMP-CAP LK-GEJVW002-PREV-NUM-EMP LK-GEJVW002-PREV-DTA-INI LK-GEJVW002-PREV-COD-LIDER LK-GEJVW002-PREV-COD-CGCCPF LK-GEJVW002-PREV-COD-EMP-CAP LK-GEJVW002-JV-NUM-EMP LK-GEJVW002-JV-DTA-INI LK-GEJVW002-JV-COD-LIDER LK-GEJVW002-JV-COD-CGCCPF LK-GEJVW002-JV-COD-EMP-CAP LK-GEJVWCNT-IND-ERRO LK-GEJVWCNT-MENSAGEM-RETORNO LK-GEJVWCNT-NOME-TABELA LK-GEJVWCNT-SQLCODE LK-GEJVWCNT-SQLERRMC. */
            _.Call(WORK_JV1.WS_JV1_PROGRAMA, GEJVW002, GEJVWCNT);

            /*" -1581- IF LK-GEJVWCNT-IND-ERRO NOT = ZEROS */

            if (GEJVWCNT.LK_GEJVWCNT_IND_ERRO != 00)
            {

                /*" -1582- DISPLAY 'CB2005B- ERRO NA CHAMADA DA GEJVS002 ' */
                _.Display($"CB2005B- ERRO NA CHAMADA DA GEJVS002 ");

                /*" -1583- DISPLAY 'CB2005B- ROTINA CANCELADA ' */
                _.Display($"CB2005B- ROTINA CANCELADA ");

                /*" -1584- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1588- END-IF. */
            }


            /*" -1590- INITIALIZE TAB-CBO1. */
            _.Initialize(
                TAB_CBO1
            );

            /*" -1592- PERFORM R8100-00-DECLARE-CBO. */

            R8100_00_DECLARE_CBO_SECTION();

            /*" -1594- PERFORM R8110-00-FETCH-CBO. */

            R8110_00_FETCH_CBO_SECTION();

            /*" -1595- IF WFIM-CBO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CBO.IsEmpty())
            {

                /*" -1596- DISPLAY '8110 - PROBLEMA NO FETCH DA CBO         ' */
                _.Display($"8110 - PROBLEMA NO FETCH DA CBO         ");

                /*" -1598- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1601- PERFORM R8120-00-CARREGA-CBO UNTIL WFIM-CBO EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_CBO == "S"))
            {

                R8120_00_CARREGA_CBO_SECTION();
            }

            /*" -1603- PERFORM R0200-00-CARREGA-ORIGEM. */

            R0200_00_CARREGA_ORIGEM_SECTION();

            /*" -1604- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -1606- DISPLAY 'INICIO DO DECLARE ...... ' WS-TIME. */
            _.Display($"INICIO DO DECLARE ...... {WS_TIME}");

            /*" -1608- PERFORM R0900-00-DECLARE-V0BILHETE. */

            R0900_00_DECLARE_V0BILHETE_SECTION();

            /*" -1609- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -1611- DISPLAY 'FIM DO DECLARE ......... ' WS-TIME. */
            _.Display($"FIM DO DECLARE ......... {WS_TIME}");

            /*" -1613- PERFORM R0910-00-FETCH-V0BILHETE. */

            R0910_00_FETCH_V0BILHETE_SECTION();

            /*" -1614- IF WFIM-V0BILHETE NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0BILHETE.IsEmpty())
            {

                /*" -1616- DISPLAY 'CB2005B - NAO FOI SELECIONADO BILHETE P/ EMISSAO...' */
                _.Display($"CB2005B - NAO FOI SELECIONADO BILHETE P/ EMISSAO...");

                /*" -1618- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1621- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V0BILHETE NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0BILHETE.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1623- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -1623- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1629- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1630- DISPLAY ' ' */
            _.Display($" ");

            /*" -1632- DISPLAY '*--------  CB2005B - FIM NORMAL  --------*' */
            _.Display($"*--------  CB2005B - FIM NORMAL  --------*");

            /*" -1632- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -1644- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1650- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1653- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1654- DISPLAY 'ERRO SELECT V1SISTEMA EM' */
                _.Display($"ERRO SELECT V1SISTEMA EM");

                /*" -1656- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1659- MOVE '0101' TO WNR-EXEC-SQL. */
            _.Move("0101", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1665- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_2 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_2();

            /*" -1668- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1669- DISPLAY 'ERRO SELECT V1SISTEMA CB' */
                _.Display($"ERRO SELECT V1SISTEMA CB");

                /*" -1675- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1677- MOVE 10 TO WS-VLDIFE. */
            _.Move(10, AREA_DE_WORK.WS_VLDIFE);

            /*" -1677- DISPLAY 'DATA SISTEMA "CB": ' V1SIST-DTMOVACB. */

            $"DATA SISTEMA CB: {V1SIST_DTMOVACB}"
            .Display();

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1650- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' WITH UR END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-2 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_2()
        {
            /*" -1665- EXEC SQL SELECT DTMOVABE,CURRENT TIMESTAMP INTO :V1SIST-DTMOVACB, :V1SIST-TIMESTAMP FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CB' WITH UR END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVACB, V1SIST_DTMOVACB);
                _.Move(executed_1.V1SIST_TIMESTAMP, V1SIST_TIMESTAMP);
            }


        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-SECTION */
        private void R0200_00_CARREGA_ORIGEM_SECTION()
        {
            /*" -1689- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1695- PERFORM R0200_00_CARREGA_ORIGEM_DB_DECLARE_1 */

            R0200_00_CARREGA_ORIGEM_DB_DECLARE_1();

            /*" -1697- PERFORM R0200_00_CARREGA_ORIGEM_DB_OPEN_1 */

            R0200_00_CARREGA_ORIGEM_DB_OPEN_1();

            /*" -1700- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1701- DISPLAY 'PROBLEMAS NO OPEN CORIGEM ' */
                _.Display($"PROBLEMAS NO OPEN CORIGEM ");

                /*" -1703- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1706- MOVE '0201' TO WNR-EXEC-SQL. */
            _.Move("0201", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1707- PERFORM UNTIL WFIM-SISTEMA-ORIGEM EQUAL 'SIM' */

            while (!(AREA_DE_WORK.WFIM_SISTEMA_ORIGEM == "SIM"))
            {

                /*" -1709- PERFORM R0200_00_CARREGA_ORIGEM_DB_FETCH_1 */

                R0200_00_CARREGA_ORIGEM_DB_FETCH_1();

                /*" -1711- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1712- ADD 1 TO WIND1 */
                    AREA_DE_WORK.WIND1.Value = AREA_DE_WORK.WIND1 + 1;

                    /*" -1714- MOVE ARQSIVPF-SISTEMA-ORIGEM TO WTAB-SISTEMA-ORIGEM (WIND1) */
                    _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM, W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[AREA_DE_WORK.WIND1]);

                    /*" -1715- ELSE */
                }
                else
                {


                    /*" -1716- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1717- MOVE 'SIM' TO WFIM-SISTEMA-ORIGEM */
                        _.Move("SIM", AREA_DE_WORK.WFIM_SISTEMA_ORIGEM);

                        /*" -1717- PERFORM R0200_00_CARREGA_ORIGEM_DB_CLOSE_1 */

                        R0200_00_CARREGA_ORIGEM_DB_CLOSE_1();

                        /*" -1719- ELSE */
                    }
                    else
                    {


                        /*" -1720- DISPLAY 'PROBLEMAS NO FETCH CORIGEM ' */
                        _.Display($"PROBLEMAS NO FETCH CORIGEM ");

                        /*" -1721- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1722- END-IF */
                    }


                    /*" -1723- END-IF */
                }


                /*" -1723- END-PERFORM. */
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-DECLARE-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_DECLARE_1()
        {
            /*" -1695- EXEC SQL DECLARE CORIGEM CURSOR FOR SELECT SISTEMA_ORIGEM FROM SEGUROS.ARQUIVOS_SIVPF WHERE DATA_GERACAO = '9999-12-31' AND QTDE_REG_GER = 981 ORDER BY SISTEMA_ORIGEM END-EXEC. */
            CORIGEM = new CB2005B_CORIGEM(false);
            string GetQuery_CORIGEM()
            {
                var query = @$"SELECT SISTEMA_ORIGEM 
							FROM SEGUROS.ARQUIVOS_SIVPF 
							WHERE DATA_GERACAO = '9999-12-31' 
							AND QTDE_REG_GER = 981 
							ORDER BY SISTEMA_ORIGEM";

                return query;
            }
            CORIGEM.GetQueryEvent += GetQuery_CORIGEM;

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-OPEN-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_OPEN_1()
        {
            /*" -1697- EXEC SQL OPEN CORIGEM END-EXEC. */

            CORIGEM.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0BILHETE-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1()
        {
            /*" -1766- EXEC SQL DECLARE V0BILHETE CURSOR WITH HOLD FOR SELECT NUMBIL , FONTE , AGECOBR , NUM_MATRICULA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , CODCLIEN , PROFISSAO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB, NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DATA_VENDA , DTQITBCO , VLRCAP , RAMO , COD_USUARIO , SITUACAO , NUM_APOL_ANTERIOR FROM SEGUROS.V0BILHETE WHERE SITUACAO IN ( 'E' , 'F' ) AND NUM_APOL_ANTERIOR = 0 AND RAMO IN ( 81, 82) ORDER BY NUMBIL END-EXEC. */
            V0BILHETE = new CB2005B_V0BILHETE(false);
            string GetQuery_V0BILHETE()
            {
                var query = @$"SELECT NUMBIL
							, 
							FONTE
							, 
							AGECOBR
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
							DATA_VENDA
							, 
							DTQITBCO
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
							WHERE SITUACAO IN ( 'E'
							, 'F' ) 
							AND NUM_APOL_ANTERIOR = 0 
							AND RAMO IN ( 81
							, 82) 
							ORDER BY NUMBIL";

                return query;
            }
            V0BILHETE.GetQueryEvent += GetQuery_V0BILHETE;

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-FETCH-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_FETCH_1()
        {
            /*" -1709- EXEC SQL FETCH CORIGEM INTO :ARQSIVPF-SISTEMA-ORIGEM END-EXEC */

            if (CORIGEM.Fetch())
            {
                _.Move(CORIGEM.ARQSIVPF_SISTEMA_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-CLOSE-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_CLOSE_1()
        {
            /*" -1717- EXEC SQL CLOSE CORIGEM END-EXEC */

            CORIGEM.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V0BILHETE-SECTION */
        private void R0900_00_DECLARE_V0BILHETE_SECTION()
        {
            /*" -1735- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1737- MOVE SPACE TO WFIM-V0BILHETE. */
            _.Move("", AREA_DE_WORK.WFIM_V0BILHETE);

            /*" -1766- PERFORM R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1 */

            R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1();

            /*" -1768- PERFORM R0900_00_DECLARE_V0BILHETE_DB_OPEN_1 */

            R0900_00_DECLARE_V0BILHETE_DB_OPEN_1();

            /*" -1771- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1772- DISPLAY 'PROBLEMAS NO OPEN (V0BILHETE) ... ' */
                _.Display($"PROBLEMAS NO OPEN (V0BILHETE) ... ");

                /*" -1772- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0BILHETE-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0BILHETE_DB_OPEN_1()
        {
            /*" -1768- EXEC SQL OPEN V0BILHETE END-EXEC. */

            V0BILHETE.Open();

        }

        [StopWatch]
        /*" R1080-00-GRAVA-V0APOLCOSCED-DB-DECLARE-1 */
        public void R1080_00_GRAVA_V0APOLCOSCED_DB_DECLARE_1()
        {
            /*" -3589- EXEC SQL DECLARE V1COSSEGPROD CURSOR FOR SELECT CODPRODU , RAMO , CONGENER , PCPARTIC , PCCOMCOS , PCADMCOS , DTINIVIG , DTTERVIG , SITUACAO FROM SEGUROS.V1COSSEGPROD WHERE CODPRODU = :V1BILP-CODPRODU AND RAMO = :WWORK-RAMO-ANT AND DTINIVIG <= :V0ENDO-DTINIVIG AND DTTERVIG >= :V0ENDO-DTINIVIG AND SUBPRODU = :WWORK-OPCAO-ANT WITH UR END-EXEC. */
            V1COSSEGPROD = new CB2005B_V1COSSEGPROD(true);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0BILHETE-SECTION */
        private void R0910_00_FETCH_V0BILHETE_SECTION()
        {
            /*" -1781- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0910_10_LE */

            R0910_10_LE();

        }

        [StopWatch]
        /*" R0910-10-LE */
        private void R0910_10_LE(bool isPerform = false)
        {
            /*" -1809- PERFORM R0910_10_LE_DB_FETCH_1 */

            R0910_10_LE_DB_FETCH_1();

            /*" -1812- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1813- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1813- PERFORM R0910_10_LE_DB_CLOSE_1 */

                    R0910_10_LE_DB_CLOSE_1();

                    /*" -1815- MOVE 'S' TO WFIM-V0BILHETE */
                    _.Move("S", AREA_DE_WORK.WFIM_V0BILHETE);

                    /*" -1816- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -1817- ELSE */
                }
                else
                {


                    /*" -1818- DISPLAY 'R0910-00 (ERRO -  FETCH V0BILHETE)...' */
                    _.Display($"R0910-00 (ERRO -  FETCH V0BILHETE)...");

                    /*" -1820- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1821- IF V0BILH-NUMBIL EQUAL 82340761517 */

            if (V0BILH_NUMBIL == 82340761517)
            {

                /*" -1823- GO TO R0910-10-LE. */
                new Task(() => R0910_10_LE()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1831- ADD 1 TO WACC-LIDOS WACC-DISPLAY. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;
            AREA_DE_WORK.WACC_DISPLAY.Value = AREA_DE_WORK.WACC_DISPLAY + 1;

            /*" -1832- IF WACC-PROCESSADOS EQUAL 500 */

            if (AREA_DE_WORK.WACC_PROCESSADOS == 500)
            {

                /*" -1833- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -1834- DISPLAY 'TOTAL ATUALIZADO.. ' WPROC-BILHETES '  ' WS-TIME */

                $"TOTAL ATUALIZADO.. {AREA_DE_WORK.WPROC_BILHETES}  {WS_TIME}"
                .Display();

                /*" -1834- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -1839- MOVE ZEROS TO WACC-PROCESSADOS. */
                _.Move(0, AREA_DE_WORK.WACC_PROCESSADOS);
            }


            /*" -1840- INITIALIZE WORK-TAB-ERROS-CERT */
            _.Initialize(
                WORK_TAB_ERROS_CERT
            );

            /*" -1841- MOVE ZEROS TO WS-I-ERRO */
            _.Move(0, WS_I_ERRO);

            /*" -1841- . */

        }

        [StopWatch]
        /*" R0910-10-LE-DB-FETCH-1 */
        public void R0910_10_LE_DB_FETCH_1()
        {
            /*" -1809- EXEC SQL FETCH V0BILHETE INTO :V0BILH-NUMBIL , :V0BILH-FONTE , :V0BILH-AGECOBR , :V0BILH-NUM-MATR , :V0BILH-AGENCIA , :V0BILH-OPE-CONTA , :V0BILH-NUM-CONTA , :V0BILH-DIG-CONTA , :V0BILH-CODCLIEN , :V0BILH-PROFISSAO , :V0BILH-AGENCIA-DEB , :V0BILH-OPERACAO-DEB , :V0BILH-NUMCTA-DEB , :V0BILH-DIGCTA-DEB , :V0BILH-OPCAO-COBER , :V0BILH-DTA-VENDA , :V0BILH-DTQITBCO , :V0BILH-VLRCAP , :V0BILH-RAMO , :V0BILH-CODUSU , :V0BILH-SITUACAO , :V0BILH-NUM-APO-ANT END-EXEC. */

            if (V0BILHETE.Fetch())
            {
                _.Move(V0BILHETE.V0BILH_NUMBIL, V0BILH_NUMBIL);
                _.Move(V0BILHETE.V0BILH_FONTE, V0BILH_FONTE);
                _.Move(V0BILHETE.V0BILH_AGECOBR, V0BILH_AGECOBR);
                _.Move(V0BILHETE.V0BILH_NUM_MATR, V0BILH_NUM_MATR);
                _.Move(V0BILHETE.V0BILH_AGENCIA, V0BILH_AGENCIA);
                _.Move(V0BILHETE.V0BILH_OPE_CONTA, V0BILH_OPE_CONTA);
                _.Move(V0BILHETE.V0BILH_NUM_CONTA, V0BILH_NUM_CONTA);
                _.Move(V0BILHETE.V0BILH_DIG_CONTA, V0BILH_DIG_CONTA);
                _.Move(V0BILHETE.V0BILH_CODCLIEN, V0BILH_CODCLIEN);
                _.Move(V0BILHETE.V0BILH_PROFISSAO, V0BILH_PROFISSAO);
                _.Move(V0BILHETE.V0BILH_AGENCIA_DEB, V0BILH_AGENCIA_DEB);
                _.Move(V0BILHETE.V0BILH_OPERACAO_DEB, V0BILH_OPERACAO_DEB);
                _.Move(V0BILHETE.V0BILH_NUMCTA_DEB, V0BILH_NUMCTA_DEB);
                _.Move(V0BILHETE.V0BILH_DIGCTA_DEB, V0BILH_DIGCTA_DEB);
                _.Move(V0BILHETE.V0BILH_OPCAO_COBER, V0BILH_OPCAO_COBER);
                _.Move(V0BILHETE.V0BILH_DTA_VENDA, V0BILH_DTA_VENDA);
                _.Move(V0BILHETE.V0BILH_DTQITBCO, V0BILH_DTQITBCO);
                _.Move(V0BILHETE.V0BILH_VLRCAP, V0BILH_VLRCAP);
                _.Move(V0BILHETE.V0BILH_RAMO, V0BILH_RAMO);
                _.Move(V0BILHETE.V0BILH_CODUSU, V0BILH_CODUSU);
                _.Move(V0BILHETE.V0BILH_SITUACAO, V0BILH_SITUACAO);
                _.Move(V0BILHETE.V0BILH_NUM_APO_ANT, V0BILH_NUM_APO_ANT);
            }

        }

        [StopWatch]
        /*" R0910-10-LE-DB-CLOSE-1 */
        public void R0910_10_LE_DB_CLOSE_1()
        {
            /*" -1813- EXEC SQL CLOSE V0BILHETE END-EXEC */

            V0BILHETE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1885- MOVE '1015' TO WNR-EXEC-SQL. */
            _.Move("1015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1887- PERFORM R1600-00-BUSCA-PRODUTO THRU R1600-99-SAIDA. */

            R1600_00_BUSCA_PRODUTO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/


            /*" -1888- IF WS-JV1-ACHEI-PRODUTO = 'NAO' */

            if (WORK_JV1.WS_JV1_ACHEI_PRODUTO == "NAO")
            {

                /*" -1889- DISPLAY 'R1000-00 (NAO ENCONTRADO BILHETE_COBERTURA)' */
                _.Display($"R1000-00 (NAO ENCONTRADO BILHETE_COBERTURA)");

                /*" -1891- DISPLAY 'BILHETE: ' V0BILH-NUMBIL ' ' V0BILH-RAMO ' ' V0BILH-OPCAO-COBER */

                $"BILHETE: {V0BILH_NUMBIL} {V0BILH_RAMO} {V0BILH_OPCAO_COBER}"
                .Display();

                /*" -1892- GO TO R1000-00-LEITURA */

                R1000_00_LEITURA(); //GOTO
                return;

                /*" -1906- END-IF. */
            }


            /*" -1908- MOVE V1BILP-CODPRODU TO PRODUTO-COD-PRODUTO WS-COD-PRODUTO. */
            _.Move(V1BILP_CODPRODU, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO, WS_COD_PRODUTO);

            /*" -1909- INITIALIZE WS-SIT-PRODUTO. */
            _.Initialize(
                AREA_DE_WORK.WS_SIT_PRODUTO
            );

            /*" -1911- PERFORM R1040-PRODUTO-RUNOFF. */

            R1040_PRODUTO_RUNOFF_SECTION();

            /*" -1913- PERFORM R7000-JV1-BUSCA-EMPRESA-RAMO. */

            R7000_JV1_BUSCA_EMPRESA_RAMO_SECTION();

            /*" -1914- IF (PRODUTO-COD-EMPRESA = 10 OR 11) */

            if ((PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA.In("10", "11")))
            {

                /*" -1915- IF WS-PROD-RUNON */

                if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"])
                {

                    /*" -1916- MOVE 300 TO WH-JV1-COD-ORGAO */
                    _.Move(300, WORK_JV1.WH_JV1_COD_ORGAO);

                    /*" -1917- ELSE */
                }
                else
                {


                    /*" -1918- MOVE 10 TO WH-JV1-COD-ORGAO */
                    _.Move(10, WORK_JV1.WH_JV1_COD_ORGAO);

                    /*" -1919- END-IF */
                }


                /*" -1949- END-IF. */
            }


            /*" -1950- MOVE V0BILH-RAMO TO WWORK-RAMO-ANT */
            _.Move(V0BILH_RAMO, WWORK_RAMO_ANT);

            /*" -1952- MOVE V0BILH-OPCAO-COBER TO WWORK-OPCAO-ANT. */
            _.Move(V0BILH_OPCAO_COBER, WWORK_OPCAO_ANT);

            /*" -1953- MOVE ZEROES TO V0ADIA-VALADT. */
            _.Move(0, V0ADIA_VALADT);

            /*" -1954- MOVE '9999-99-99' TO WWORK-MIN-DTINIVIG. */
            _.Move("9999-99-99", WWORK_MIN_DTINIVIG);

            /*" -1955- MOVE SPACES TO WWORK-MAX-DTTERVIG. */
            _.Move("", WWORK_MAX_DTTERVIG);

            /*" -1960- MOVE ZEROES TO WWORK-NUM-ITENS. */
            _.Move(0, AREA_DE_WORK.WWORK_NUM_ITENS);

            /*" -1961- MOVE V0BILH-DTQITBCO TO WWORK-DATA. */
            _.Move(V0BILH_DTQITBCO, AREA_DE_WORK.WWORK_DATA);

            /*" -1962- MOVE WWORK-ANO TO WWORK-ANOINI. */
            _.Move(AREA_DE_WORK.WWORK_DATA.WWORK_ANO, AREA_DE_WORK.FILLER_14.WWORK_ANOINI);

            /*" -1963- MOVE WWORK-MES TO WWORK-MESINI. */
            _.Move(AREA_DE_WORK.WWORK_DATA.WWORK_MES, AREA_DE_WORK.FILLER_14.WWORK_MESINI);

            /*" -1965- MOVE WWORK-DIA TO WWORK-DIAINI. */
            _.Move(AREA_DE_WORK.WWORK_DATA.WWORK_DIA, AREA_DE_WORK.FILLER_14.WWORK_DIAINI);

            /*" -1966- MOVE WWORK-DATAINI TO WS000-DATA01. */
            _.Move(AREA_DE_WORK.WWORK_DATAINI, WS000_PARM_PROSOMD1.WS000_DATA01);

            /*" -1967- MOVE 1 TO WS000-QTDIAS. */
            _.Move(1, WS000_PARM_PROSOMD1.WS000_QTDIAS);

            /*" -1969- MOVE ZEROS TO WS000-DATA02. */
            _.Move(0, WS000_PARM_PROSOMD1.WS000_DATA02);

            /*" -1971- CALL 'PROSOMC1' USING WS000-PARM-PROSOMD1 */
            _.Call("PROSOMC1", WS000_PARM_PROSOMD1);

            /*" -1972- MOVE WS000-DATA02 TO WWORK-DATAINI. */
            _.Move(WS000_PARM_PROSOMD1.WS000_DATA02, AREA_DE_WORK.WWORK_DATAINI);

            /*" -1973- MOVE WWORK-ANOINI TO WWORK-ANO. */
            _.Move(AREA_DE_WORK.FILLER_14.WWORK_ANOINI, AREA_DE_WORK.WWORK_DATA.WWORK_ANO);

            /*" -1974- MOVE WWORK-MESINI TO WWORK-MES. */
            _.Move(AREA_DE_WORK.FILLER_14.WWORK_MESINI, AREA_DE_WORK.WWORK_DATA.WWORK_MES);

            /*" -1976- MOVE WWORK-DIAINI TO WWORK-DIA. */
            _.Move(AREA_DE_WORK.FILLER_14.WWORK_DIAINI, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);

            /*" -1977- IF WWORK-MES EQUAL 02 */

            if (AREA_DE_WORK.WWORK_DATA.WWORK_MES == 02)
            {

                /*" -1978- IF WWORK-DIA EQUAL 29 */

                if (AREA_DE_WORK.WWORK_DATA.WWORK_DIA == 29)
                {

                    /*" -1979- COMPUTE WWORK-ANO-BI = WWORK-ANO / 4 */
                    AREA_DE_WORK.WWORK_ANO_BI.Value = AREA_DE_WORK.WWORK_DATA.WWORK_ANO / 4;

                    /*" -1980- COMPUTE WWORK-ANO-BI = WWORK-ANO-BI * 4 */
                    AREA_DE_WORK.WWORK_ANO_BI.Value = AREA_DE_WORK.WWORK_ANO_BI * 4;

                    /*" -1981- IF WWORK-ANO NOT EQUAL WWORK-ANO-BI */

                    if (AREA_DE_WORK.WWORK_DATA.WWORK_ANO != AREA_DE_WORK.WWORK_ANO_BI)
                    {

                        /*" -1982- MOVE 03 TO WWORK-MES */
                        _.Move(03, AREA_DE_WORK.WWORK_DATA.WWORK_MES);

                        /*" -1984- MOVE 01 TO WWORK-DIA. */
                        _.Move(01, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);
                    }

                }

            }


            /*" -1985- IF WWORK-DATA < WWORK-MIN-DTINIVIG */

            if (AREA_DE_WORK.WWORK_DATA < WWORK_MIN_DTINIVIG)
            {

                /*" -1987- MOVE WWORK-DATA TO WWORK-MIN-DTINIVIG. */
                _.Move(AREA_DE_WORK.WWORK_DATA, WWORK_MIN_DTINIVIG);
            }


            /*" -1989- IF V0BILH-RAMO = 82 OR 81 */

            if (V0BILH_RAMO.In("82", "81"))
            {

                /*" -1990- COMPUTE WWORK-ANOINI = WWORK-ANOINI + 5 */
                AREA_DE_WORK.FILLER_14.WWORK_ANOINI.Value = AREA_DE_WORK.FILLER_14.WWORK_ANOINI + 5;

                /*" -1991- ELSE */
            }
            else
            {


                /*" -1992- COMPUTE WWORK-ANOINI = WWORK-ANOINI + 1 */
                AREA_DE_WORK.FILLER_14.WWORK_ANOINI.Value = AREA_DE_WORK.FILLER_14.WWORK_ANOINI + 1;

                /*" -1994- END-IF. */
            }


            /*" -1996- MOVE WWORK-ANOINI TO WWORK-ANO. */
            _.Move(AREA_DE_WORK.FILLER_14.WWORK_ANOINI, AREA_DE_WORK.WWORK_DATA.WWORK_ANO);

            /*" -1997- IF WWORK-MES EQUAL 02 */

            if (AREA_DE_WORK.WWORK_DATA.WWORK_MES == 02)
            {

                /*" -1998- IF WWORK-DIA EQUAL 29 */

                if (AREA_DE_WORK.WWORK_DATA.WWORK_DIA == 29)
                {

                    /*" -1999- COMPUTE WWORK-ANO-BI = WWORK-ANO / 4 */
                    AREA_DE_WORK.WWORK_ANO_BI.Value = AREA_DE_WORK.WWORK_DATA.WWORK_ANO / 4;

                    /*" -2000- COMPUTE WWORK-ANO-BI = WWORK-ANO-BI * 4 */
                    AREA_DE_WORK.WWORK_ANO_BI.Value = AREA_DE_WORK.WWORK_ANO_BI * 4;

                    /*" -2001- IF WWORK-ANO NOT EQUAL WWORK-ANO-BI */

                    if (AREA_DE_WORK.WWORK_DATA.WWORK_ANO != AREA_DE_WORK.WWORK_ANO_BI)
                    {

                        /*" -2002- MOVE 03 TO WWORK-MES */
                        _.Move(03, AREA_DE_WORK.WWORK_DATA.WWORK_MES);

                        /*" -2004- MOVE 01 TO WWORK-DIA. */
                        _.Move(01, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);
                    }

                }

            }


            /*" -2005- IF WWORK-DATA > WWORK-MAX-DTTERVIG */

            if (AREA_DE_WORK.WWORK_DATA > WWORK_MAX_DTTERVIG)
            {

                /*" -2008- MOVE WWORK-DATA TO WWORK-MAX-DTTERVIG. */
                _.Move(AREA_DE_WORK.WWORK_DATA, WWORK_MAX_DTTERVIG);
            }


            /*" -2013- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2020- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -2023- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2025- DISPLAY 'R1000-00 (ERRO - SELECT V1NUMERO_AES)...' */
                _.Display($"R1000-00 (ERRO - SELECT V1NUMERO_AES)...");

                /*" -2027- DISPLAY 'ORGAO: ' WH-JV1-COD-ORGAO 'RAMO: ' V0BILH-RAMO */

                $"ORGAO: {WORK_JV1.WH_JV1_COD_ORGAO}RAMO: {V0BILH_RAMO}"
                .Display();

                /*" -2029- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2033- COMPUTE V0NAES-SEQ-APOL = V1NAES-SEQ-APOL + 1. */
            V0NAES_SEQ_APOL.Value = V1NAES_SEQ_APOL + 1;

            /*" -2035- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2037- MOVE 'S' TO WS-SIVPF. */
            _.Move("S", AREA_DE_WORK.WS_SIVPF);

            /*" -2049- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_2();

            /*" -2052- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2053- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2054- MOVE 'N' TO WS-SIVPF */
                    _.Move("N", AREA_DE_WORK.WS_SIVPF);

                    /*" -2055- ELSE */
                }
                else
                {


                    /*" -2056- DISPLAY 'R1020-00 (ERRO - SELECT PROPOSTA_FIDELIZ)' */
                    _.Display($"R1020-00 (ERRO - SELECT PROPOSTA_FIDELIZ)");

                    /*" -2058- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'RAMO: ' V0BILH-RAMO '  ' */

                    $"BILHETE: {V0BILH_NUMBIL}  RAMO: {V0BILH_RAMO}  "
                    .Display();

                    /*" -2060- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2061- IF WS-SIVPF EQUAL 'N' */

            if (AREA_DE_WORK.WS_SIVPF == "N")
            {

                /*" -2063- MOVE '1021' TO WNR-EXEC-SQL */
                _.Move("1021", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2064- MOVE 'S' TO WS-SIVPF */
                _.Move("S", AREA_DE_WORK.WS_SIVPF);

                /*" -2070- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_3 */

                R1000_00_PROCESSA_REGISTRO_DB_SELECT_3();

                /*" -2072- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2073- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -2074- MOVE 'N' TO WS-SIVPF */
                        _.Move("N", AREA_DE_WORK.WS_SIVPF);

                        /*" -2075- ELSE */
                    }
                    else
                    {


                        /*" -2076- DISPLAY 'R1021-00 (ERRO - SELECT CONVERSAO_SICOB)' */
                        _.Display($"R1021-00 (ERRO - SELECT CONVERSAO_SICOB)");

                        /*" -2078- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'RAMO: ' V0BILH-RAMO '  ' */

                        $"BILHETE: {V0BILH_NUMBIL}  RAMO: {V0BILH_RAMO}  "
                        .Display();

                        /*" -2079- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2080- ELSE */
                    }

                }
                else
                {


                    /*" -2091- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_4 */

                    R1000_00_PROCESSA_REGISTRO_DB_SELECT_4();

                    /*" -2093- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2094- DISPLAY 'R1021-00 (ERRO - SELECT PROPOSTA_FIDEL )' */
                        _.Display($"R1021-00 (ERRO - SELECT PROPOSTA_FIDEL )");

                        /*" -2096- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'RAMO: ' V0BILH-RAMO '  ' */

                        $"BILHETE: {V0BILH_NUMBIL}  RAMO: {V0BILH_RAMO}  "
                        .Display();

                        /*" -2098- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -2099- IF WS-SIVPF EQUAL 'N' */

            if (AREA_DE_WORK.WS_SIVPF == "N")
            {

                /*" -2101- DISPLAY '----> PROBLEMAS NO CADASTRO DE PROPOSTA ' ' ' V0BILH-NUMBIL */

                $"----> PROBLEMAS NO CADASTRO DE PROPOSTA  {V0BILH_NUMBIL}"
                .Display();

                /*" -2103- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2106- MOVE V0CONV-NUM-PROPOSTA-SIVPF TO W-NUM-PROPOSTA */
            _.Move(V0CONV_NUM_PROPOSTA_SIVPF, WREA88.W_NUM_PROPOSTA);

            /*" -2112- MOVE V0CONV-ORIGEM-PROPOSTA TO W-ORIGEM-PROPOSTA */
            _.Move(V0CONV_ORIGEM_PROPOSTA, WREA88.W_ORIGEM_PROPOSTA);

            /*" -2114- PERFORM R1010-00-VERIFICA-ORIGEM */

            R1010_00_VERIFICA_ORIGEM_SECTION();

            /*" -2116- IF V0BILH-RAMO EQUAL 82 OR V0BILH-RAMO EQUAL 81 */

            if (V0BILH_RAMO == 82 || V0BILH_RAMO == 81)
            {

                /*" -2117- PERFORM R1100-00-SELECT-CLIENTE */

                R1100_00_SELECT_CLIENTE_SECTION();

                /*" -2118- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2119- GO TO R1000-00-LEITURA */

                    R1000_00_LEITURA(); //GOTO
                    return;

                    /*" -2120- END-IF */
                }


                /*" -2121- PERFORM R1200-00-SELECT-GELIMRISCO */

                R1200_00_SELECT_GELIMRISCO_SECTION();

                /*" -2122- PERFORM R1300-00-SELECT-BIL-COBER */

                R1300_00_SELECT_BIL_COBER_SECTION();

                /*" -2123- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2124- GO TO R1000-00-LEITURA */

                    R1000_00_LEITURA(); //GOTO
                    return;

                    /*" -2125- END-IF */
                }


                /*" -2127- COMPUTE GELMR-VLR-SOMA-IS = GELMR-VLR-SOMA-IS + V1BILC-IMPSEG-IX */
                GELMR_VLR_SOMA_IS.Value = GELMR_VLR_SOMA_IS + V1BILC_IMPSEG_IX;

                /*" -2132- IF GELMR-VLR-SOMA-IS > 100000,01 AND V1BILP-CODPRODU NOT EQUAL 8103 AND WTEM-SISTEMA-ORIGEM EQUAL 'NAO' */

                if (GELMR_VLR_SOMA_IS > 100000.01 && V1BILP_CODPRODU != 8103 && AREA_DE_WORK.WTEM_SISTEMA_ORIGEM == "NAO")
                {

                    /*" -2133- MOVE 834 TO V0BILER-COD-ERRO */
                    _.Move(834, V0BILER_COD_ERRO);

                    /*" -2134- PERFORM R3045-00-GRAVA-TAB-ERRO */

                    R3045_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2135- MOVE 'F' TO V0BILH-SITUACAO */
                    _.Move("F", V0BILH_SITUACAO);

                    /*" -2136- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -2139- DISPLAY 'ULTRAPASSA LIMITE DE RISCO. BILHETE REJEITADO ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN ' ' V0CLIE-CGCCPF */

                    $"ULTRAPASSA LIMITE DE RISCO. BILHETE REJEITADO {V0BILH_NUMBIL} {V0BILH_CODCLIEN} {V0CLIE_CGCCPF}"
                    .Display();

                    /*" -2141- GO TO R1000-00-LEITURA. */

                    R1000_00_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -2144- IF ORIGEM-MARSH OR CANAL-VENDA-ATM NEXT SENTENCE */

            if (WREA88.W_ORIGEM_PROPOSTA["ORIGEM_MARSH"] || WREA88.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_ATM"])
            {

                /*" -2145- ELSE */
            }
            else
            {


                /*" -2146- GO TO R1000-00-LEITURA */

                R1000_00_LEITURA(); //GOTO
                return;

                /*" -2148- END-IF. */
            }


            /*" -2151- MOVE ZEROS TO WWORK-NUM-APOL */
            _.Move(0, AREA_DE_WORK.WWORK_NUM_APOL);

            /*" -2153- MOVE WH-JV1-COD-ORGAO TO WWORK-ORG-APOL. */
            _.Move(WORK_JV1.WH_JV1_COD_ORGAO, AREA_DE_WORK.FILLER_2.WWORK_ORG_APOL);

            /*" -2154- MOVE V0BILH-RAMO TO WWORK-RMO-APOL. */
            _.Move(V0BILH_RAMO, AREA_DE_WORK.FILLER_2.WWORK_RMO_APOL);

            /*" -2155- MOVE V0NAES-SEQ-APOL TO WWORK-SEQ-APOL. */
            _.Move(V0NAES_SEQ_APOL, AREA_DE_WORK.FILLER_2.WWORK_SEQ_APOL);

            /*" -2157- MOVE WWORK-NUM-APOL TO V0APOL-NUM-APOL. */
            _.Move(AREA_DE_WORK.WWORK_NUM_APOL, V0APOL_NUM_APOL);

            /*" -2160- MOVE '1040' TO WNR-EXEC-SQL. */
            _.Move("1040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2161- MOVE 0 TO V1BILC-COD-EMPR */
            _.Move(0, V1BILC_COD_EMPR);

            /*" -2162- MOVE V1BILP-CODPRODU TO V1BILC-CODPRODU */
            _.Move(V1BILP_CODPRODU, V1BILC_CODPRODU);

            /*" -2163- MOVE WWORK-RAMO-ANT TO V1BILC-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V1BILC_RAMOFR);

            /*" -2164- MOVE 0 TO V1BILC-MODALIFR */
            _.Move(0, V1BILC_MODALIFR);

            /*" -2166- MOVE WWORK-OPCAO-ANT TO V1BILC-OPCAO */
            _.Move(WWORK_OPCAO_ANT, V1BILC_OPCAO);

            /*" -2180- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_5 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_5();

            /*" -2202- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2203- MOVE 1503 TO V0BILER-COD-ERRO */
                _.Move(1503, V0BILER_COD_ERRO);

                /*" -2204- PERFORM R3045-00-GRAVA-TAB-ERRO */

                R3045_00_GRAVA_TAB_ERRO_SECTION();

                /*" -2205- MOVE 'F' TO V0BILH-SITUACAO */
                _.Move("F", V0BILH_SITUACAO);

                /*" -2206- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -2207- DISPLAY 'R1040-00 (ERRO SELECT V1BILCOBER)' */
                _.Display($"R1040-00 (ERRO SELECT V1BILCOBER)");

                /*" -2208- DISPLAY 'COD_EMPRESA: ' V1BILC-COD-EMPR */
                _.Display($"COD_EMPRESA: {V1BILC_COD_EMPR}");

                /*" -2209- DISPLAY 'CODPRODU   : ' V1BILC-CODPRODU */
                _.Display($"CODPRODU   : {V1BILC_CODPRODU}");

                /*" -2210- DISPLAY 'RAMOFR     : ' V1BILC-RAMOFR */
                _.Display($"RAMOFR     : {V1BILC_RAMOFR}");

                /*" -2211- DISPLAY 'MODALIFR   : ' V1BILC-MODALIFR */
                _.Display($"MODALIFR   : {V1BILC_MODALIFR}");

                /*" -2212- DISPLAY 'COD_OPCAO  : ' V1BILC-OPCAO */
                _.Display($"COD_OPCAO  : {V1BILC_OPCAO}");

                /*" -2213- DISPLAY 'DTINIVIG   : ' WWORK-MIN-DTINIVIG */
                _.Display($"DTINIVIG   : {WWORK_MIN_DTINIVIG}");

                /*" -2214- DISPLAY 'DTTERVIG   : ' WWORK-MAX-DTTERVIG */
                _.Display($"DTTERVIG   : {WWORK_MAX_DTTERVIG}");

                /*" -2217- GO TO R1000-00-LEITURA. */

                R1000_00_LEITURA(); //GOTO
                return;
            }


            /*" -2220- DISPLAY 'R1000 - ENTRA  R3000 - ' WWORK-NUM-ITENS ' / ' V0BILH-NUMBIL ' / ' V0CONV-NUM-PROPOSTA-SIVPF */

            $"R1000 - ENTRA  R3000 - {AREA_DE_WORK.WWORK_NUM_ITENS} / {V0BILH_NUMBIL} / {V0CONV_NUM_PROPOSTA_SIVPF}"
            .Display();

            /*" -2221- PERFORM R3000-00-ACUMULA-BILHETE. */

            R3000_00_ACUMULA_BILHETE_SECTION();

            /*" -2225- DISPLAY 'R1000 - SAINDO R3000 - ' WWORK-NUM-ITENS ' / ' V0BILH-NUMBIL ' / ' V0CONV-NUM-PROPOSTA-SIVPF */

            $"R1000 - SAINDO R3000 - {AREA_DE_WORK.WWORK_NUM_ITENS} / {V0BILH_NUMBIL} / {V0CONV_NUM_PROPOSTA_SIVPF}"
            .Display();

            /*" -2226- IF WWORK-NUM-ITENS EQUAL ZEROES */

            if (AREA_DE_WORK.WWORK_NUM_ITENS == 00)
            {

                /*" -2228- GO TO R1000-00-LEITURA. */

                R1000_00_LEITURA(); //GOTO
                return;
            }


            /*" -2231- MOVE '1025' TO WNR-EXEC-SQL. */
            _.Move("1025", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2237- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1 */

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1();

            /*" -2240- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2242- DISPLAY 'R1025-00 (ERRO - UPDATE V0NUMERO_AES)...' */
                _.Display($"R1025-00 (ERRO - UPDATE V0NUMERO_AES)...");

                /*" -2244- DISPLAY 'ORGAO: ' WH-JV1-COD-ORGAO 'RAMO: ' WWORK-RAMO-ANT */

                $"ORGAO: {WORK_JV1.WH_JV1_COD_ORGAO}RAMO: {WWORK_RAMO_ANT}"
                .Display();

                /*" -2246- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2248- ADD +1 TO AC-U-V0NUMERAES. */
            AREA_DE_WORK.AC_U_V0NUMERAES.Value = AREA_DE_WORK.AC_U_V0NUMERAES + +1;

            /*" -2251- ADD +1 TO AC-U-V0FONTE. */
            AREA_DE_WORK.AC_U_V0FONTE.Value = AREA_DE_WORK.AC_U_V0FONTE + +1;

            /*" -2252- COMPUTE WWORK-IS-APOL = V1BILC-IMPSEG-IX * WWORK-NUM-ITENS. */
            AREA_DE_WORK.WWORK_IS_APOL.Value = V1BILC_IMPSEG_IX * AREA_DE_WORK.WWORK_NUM_ITENS;

            /*" -2254- COMPUTE WWORK-PR-APOL = V1BILC-PRMTAR-IX * WWORK-NUM-ITENS. */
            AREA_DE_WORK.WWORK_PR_APOL.Value = V1BILC_PRMTAR_IX * AREA_DE_WORK.WWORK_NUM_ITENS;

            /*" -2256- MOVE V0BILH-CODCLIEN TO V0APOL-CODCLIEN. */
            _.Move(V0BILH_CODCLIEN, V0APOL_CODCLIEN);

            /*" -2257- MOVE WWORK-NUM-ITENS TO V0APOL-NUM-ITEM */
            _.Move(AREA_DE_WORK.WWORK_NUM_ITENS, V0APOL_NUM_ITEM);

            /*" -2259- MOVE ZEROS TO V0APOL-MODALIDA */
            _.Move(0, V0APOL_MODALIDA);

            /*" -2261- MOVE WWORK-RAMO-ANT TO V0APOL-RAMO */
            _.Move(WWORK_RAMO_ANT, V0APOL_RAMO);

            /*" -2262- IF V0BILH-NUM-APO-ANT GREATER 0 */

            if (V0BILH_NUM_APO_ANT > 0)
            {

                /*" -2263- PERFORM R3270-00-SELECT-APOLICE-ANT */

                R3270_00_SELECT_APOLICE_ANT_SECTION();

                /*" -2264- MOVE V1APOL-NUM-APOL TO V0APOL-NUM-APO-ANT */
                _.Move(V1APOL_NUM_APOL, V0APOL_NUM_APO_ANT);

                /*" -2265- ELSE */
            }
            else
            {


                /*" -2267- MOVE 0 TO V0APOL-NUM-APO-ANT. */
                _.Move(0, V0APOL_NUM_APO_ANT);
            }


            /*" -2268- MOVE '1' TO V0APOL-TIPSGU */
            _.Move("1", V0APOL_TIPSGU);

            /*" -2269- MOVE '2' TO V0APOL-TIPAPO */
            _.Move("2", V0APOL_TIPAPO);

            /*" -2270- MOVE '3' TO V0APOL-TIPCALC */
            _.Move("3", V0APOL_TIPCALC);

            /*" -2271- MOVE 'N' TO V0APOL-PODPUBL */
            _.Move("N", V0APOL_PODPUBL);

            /*" -2272- MOVE ZEROS TO V0APOL-NUM-ATA */
            _.Move(0, V0APOL_NUM_ATA);

            /*" -2273- MOVE ZEROS TO V0APOL-ANO-ATA */
            _.Move(0, V0APOL_ANO_ATA);

            /*" -2274- MOVE SPACES TO V0APOL-IDEMAN */
            _.Move("", V0APOL_IDEMAN);

            /*" -2276- MOVE ZEROS TO V0APOL-PCDESCON */
            _.Move(0, V0APOL_PCDESCON);

            /*" -2277- MOVE ZEROS TO V0APOL-PCTCED */
            _.Move(0, V0APOL_PCTCED);

            /*" -2278- MOVE '4' TO V0APOL-TPCOSCED */
            _.Move("4", V0APOL_TPCOSCED);

            /*" -2279- MOVE ZEROS TO V0APOL-QTCOSSEG */
            _.Move(0, V0APOL_QTCOSSEG);

            /*" -2281- MOVE ZEROS TO V0APOL-COD-EMPRESA */
            _.Move(0, V0APOL_COD_EMPRESA);

            /*" -2283- MOVE '2' TO V0APOL-TPCORRET. */
            _.Move("2", V0APOL_TPCORRET);

            /*" -2286- MOVE '1070' TO WNR-EXEC-SQL. */
            _.Move("1070", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2306- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_6 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_6();

            /*" -2309- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2310- DISPLAY 'R1070-00 (ERRO - SELECT V0BILHETE_COBER)...' */
                _.Display($"R1070-00 (ERRO - SELECT V0BILHETE_COBER)...");

                /*" -2317- DISPLAY 'EMPR: ' V1BILC-COD-EMPR '  ' 'PROD: ' V1BILC-CODPRODU '  ' 'RAMO: ' V1BILC-RAMOFR '  ' 'MODA: ' V1BILC-MODALIFR '  ' 'OPCA: ' V1BILC-OPCAO '  ' 'DAT1: ' V0ENDO-DTINIVIG '  ' 'DAT2: ' V0ENDO-DTTERVIG */

                $"EMPR: {V1BILC_COD_EMPR}  PROD: {V1BILC_CODPRODU}  RAMO: {V1BILC_RAMOFR}  MODA: {V1BILC_MODALIFR}  OPCA: {V1BILC_OPCAO}  DAT1: {V0ENDO_DTINIVIG}  DAT2: {V0ENDO_DTTERVIG}"
                .Display();

                /*" -2319- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2320- IF V0BILH-DTQITBCO > '2004-08-31' */

            if (V0BILH_DTQITBCO > "2004-08-31")
            {

                /*" -2322- MOVE 4 TO V1BILC-PCIOCC. */
                _.Move(4, V1BILC_PCIOCC);
            }


            /*" -2323- IF V0BILH-DTQITBCO > '2005-08-31' */

            if (V0BILH_DTQITBCO > "2005-08-31")
            {

                /*" -2325- MOVE 2 TO V1BILC-PCIOCC. */
                _.Move(2, V1BILC_PCIOCC);
            }


            /*" -2326- IF V0BILH-DTQITBCO > '2006-08-31' */

            if (V0BILH_DTQITBCO > "2006-08-31")
            {

                /*" -2328- MOVE 0 TO V1BILC-PCIOCC. */
                _.Move(0, V1BILC_PCIOCC);
            }


            /*" -2336- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_7 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_7();

            /*" -2339- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2340- DISPLAY 'ERRO SELECT SEGUROS.V1RAMOIND ' */
                _.Display($"ERRO SELECT SEGUROS.V1RAMOIND ");

                /*" -2341- DISPLAY 'RAMO     = ' V1BILC-RAMOFR */
                _.Display($"RAMO     = {V1BILC_RAMOFR}");

                /*" -2342- DISPLAY 'DTINIVIG = ' V0BILH-DTQITBCO */
                _.Display($"DTINIVIG = {V0BILH_DTQITBCO}");

                /*" -2343- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2345- END-IF. */
            }


            /*" -2347- MOVE V1RIND-PCIOF TO V0APOL-PCIOCC */
            _.Move(V1RIND_PCIOF, V0APOL_PCIOCC);

            /*" -2349- MOVE ' ' TO WTEM-PROPESTIP. */
            _.Move(" ", AREA_DE_WORK.WTEM_PROPESTIP);

            /*" -2358- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_8 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_8();

            /*" -2361- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2362- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2363- MOVE 'N' TO WTEM-PROPESTIP */
                    _.Move("N", AREA_DE_WORK.WTEM_PROPESTIP);

                    /*" -2364- ELSE */
                }
                else
                {


                    /*" -2365- DISPLAY 'R1070-00 (ERRO - SELECT V0PROP_ESTIPULANTE).' */
                    _.Display($"R1070-00 (ERRO - SELECT V0PROP_ESTIPULANTE).");

                    /*" -2368- DISPLAY 'EMPR: ' V1BILC-COD-EMPR '  ' 'PROD: ' V1BILC-CODPRODU '  ' 'BILH: ' V0BILH-NUMBIL */

                    $"EMPR: {V1BILC_COD_EMPR}  PROD: {V1BILC_CODPRODU}  BILH: {V0BILH_NUMBIL}"
                    .Display();

                    /*" -2369- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2370- ELSE */
                }

            }
            else
            {


                /*" -2374- MOVE 'S' TO WTEM-PROPESTIP. */
                _.Move("S", AREA_DE_WORK.WTEM_PROPESTIP);
            }


            /*" -2375- IF V1BILP-CODPRODU EQUAL 8103 */

            if (V1BILP_CODPRODU == 8103)
            {

                /*" -2376- MOVE V1BILP-CODPRODU TO V0APOL-CODPRODU */
                _.Move(V1BILP_CODPRODU, V0APOL_CODPRODU);

                /*" -2377- ELSE */
            }
            else
            {


                /*" -2379- IF WTEM-PROPESTIP EQUAL 'S' */

                if (AREA_DE_WORK.WTEM_PROPESTIP == "S")
                {

                    /*" -2380- MOVE 8202 TO V0APOL-CODPRODU */
                    _.Move(8202, V0APOL_CODPRODU);

                    /*" -2381- ELSE */
                }
                else
                {


                    /*" -2383- MOVE V1BILP-CODPRODU TO V0APOL-CODPRODU. */
                    _.Move(V1BILP_CODPRODU, V0APOL_CODPRODU);
                }

            }


            /*" -2386- MOVE '1065' TO WNR-EXEC-SQL. */
            _.Move("1065", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2438- PERFORM R1000_00_PROCESSA_REGISTRO_DB_INSERT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_1();

            /*" -2441- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2442- DISPLAY 'R1065-00 (PROBLEMAS NA INSERCAO) ... ' */
                _.Display($"R1065-00 (PROBLEMAS NA INSERCAO) ... ");

                /*" -2444- DISPLAY 'APOLICE: ' V0APOL-NUM-APOL '  ' 'OPCAO: ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APOL_NUM_APOL}  OPCAO: {WWORK_OPCAO_ANT}"
                .Display();

                /*" -2446- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2447- ADD +1 TO AC-I-V0APOLICE. */
            AREA_DE_WORK.AC_I_V0APOLICE.Value = AREA_DE_WORK.AC_I_V0APOLICE + +1;

            /*" -2448- MOVE V0APOL-NUM-APOL TO V0ENDO-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0ENDO_NUM_APOL);

            /*" -2449- MOVE ZEROS TO V0ENDO-NRENDOS */
            _.Move(0, V0ENDO_NRENDOS);

            /*" -2450- MOVE ZEROS TO V0ENDO-CODSUBES */
            _.Move(0, V0ENDO_CODSUBES);

            /*" -2451- MOVE V0BILH-FONTE TO V0ENDO-FONTE */
            _.Move(V0BILH_FONTE, V0ENDO_FONTE);

            /*" -2452- MOVE V1FONT-PROPAUTOM TO V0ENDO-NRPROPOS */
            _.Move(V1FONT_PROPAUTOM, V0ENDO_NRPROPOS);

            /*" -2453- MOVE V1SIST-DTMOVACB TO V0ENDO-DATPRO */
            _.Move(V1SIST_DTMOVACB, V0ENDO_DATPRO);

            /*" -2454- MOVE V1SIST-DTMOVACB TO V0ENDO-DT-LIBER */
            _.Move(V1SIST_DTMOVACB, V0ENDO_DT_LIBER);

            /*" -2456- MOVE V1SIST-DTMOVACB TO V0ENDO-DTEMIS */
            _.Move(V1SIST_DTMOVACB, V0ENDO_DTEMIS);

            /*" -2458- MOVE 104 TO V0ENDO-BCORCAP V0ENDO-BCOCOBR. */
            _.Move(104, V0ENDO_BCORCAP, V0ENDO_BCOCOBR);

            /*" -2459- MOVE V0BILH-AGECOBR TO V0ENDO-AGERCAP. */
            _.Move(V0BILH_AGECOBR, V0ENDO_AGERCAP);

            /*" -2460- MOVE V1RCAC-AGEAVISO TO V0ENDO-AGECOBR. */
            _.Move(V1RCAC_AGEAVISO, V0ENDO_AGECOBR);

            /*" -2462- MOVE '0' TO V0ENDO-DACCOBR */
            _.Move("0", V0ENDO_DACCOBR);

            /*" -2463- MOVE WWORK-NRRCAP TO V0ENDO-NRRCAP */
            _.Move(AREA_DE_WORK.FILLER_4.WWORK_NRRCAP, V0ENDO_NRRCAP);

            /*" -2464- MOVE V0BILH-VLRCAP TO V0ENDO-VLRCAP. */
            _.Move(V0BILH_VLRCAP, V0ENDO_VLRCAP);

            /*" -2465- MOVE '0' TO V0ENDO-DACRCAP */
            _.Move("0", V0ENDO_DACRCAP);

            /*" -2466- MOVE '0' TO V0ENDO-IDRCAP */
            _.Move("0", V0ENDO_IDRCAP);

            /*" -2467- MOVE V0BILH-DTQITBCO TO V0ENDO-DATARCAP */
            _.Move(V0BILH_DTQITBCO, V0ENDO_DATARCAP);

            /*" -2469- MOVE +0 TO VIND-DATARCAP. */
            _.Move(+0, VIND_DATARCAP);

            /*" -2470- MOVE WWORK-MIN-DTINIVIG TO V0ENDO-DTINIVIG. */
            _.Move(WWORK_MIN_DTINIVIG, V0ENDO_DTINIVIG);

            /*" -2472- MOVE WWORK-MAX-DTTERVIG TO V0ENDO-DTTERVIG. */
            _.Move(WWORK_MAX_DTTERVIG, V0ENDO_DTTERVIG);

            /*" -2473- MOVE ZEROS TO V0ENDO-PCENTRAD */
            _.Move(0, V0ENDO_PCENTRAD);

            /*" -2474- MOVE ZEROS TO V0ENDO-PCADICIO */
            _.Move(0, V0ENDO_PCADICIO);

            /*" -2476- MOVE ZEROS TO V0ENDO-PRESTA1 */
            _.Move(0, V0ENDO_PRESTA1);

            /*" -2479- IF V0APOL-RAMO = 82 OR 81 */

            if (V0APOL_RAMO.In("82", "81"))
            {

                /*" -2480- MOVE 12 TO V0ENDO-QTPARCEL */
                _.Move(12, V0ENDO_QTPARCEL);

                /*" -2481- ELSE */
            }
            else
            {


                /*" -2482- MOVE 12 TO V0ENDO-QTPARCEL */
                _.Move(12, V0ENDO_QTPARCEL);

                /*" -2484- END-IF. */
            }


            /*" -2485- MOVE ZEROS TO V0ENDO-CDFRACIO */
            _.Move(0, V0ENDO_CDFRACIO);

            /*" -2486- MOVE ZEROS TO V0ENDO-QTPRESTA */
            _.Move(0, V0ENDO_QTPRESTA);

            /*" -2487- MOVE 1 TO V0ENDO-QTITENS */
            _.Move(1, V0ENDO_QTITENS);

            /*" -2488- MOVE SPACES TO V0ENDO-CODTXT */
            _.Move("", V0ENDO_CODTXT);

            /*" -2490- MOVE ZEROS TO V0ENDO-CDACEITA */
            _.Move(0, V0ENDO_CDACEITA);

            /*" -2493- MOVE V1BILC-CODUNIMO TO V0ENDO-MOEDA-IMP V0ENDO-MOEDA-PRM. */
            _.Move(V1BILC_CODUNIMO, V0ENDO_MOEDA_IMP, V0ENDO_MOEDA_PRM);

            /*" -2494- MOVE '0' TO V0ENDO-TIPO-ENDO */
            _.Move("0", V0ENDO_TIPO_ENDO);

            /*" -2496- MOVE 'CB2005B' TO V0ENDO-COD-USUAR */
            _.Move("CB2005B", V0ENDO_COD_USUAR);

            /*" -2498- MOVE 1 TO V0ENDO-OCORR-END. */
            _.Move(1, V0ENDO_OCORR_END);

            /*" -2500- MOVE '0' TO V0ENDO-SITUACAO. */
            _.Move("0", V0ENDO_SITUACAO);

            /*" -2501- MOVE ZEROS TO V0ENDO-COD-EMPRESA */
            _.Move(0, V0ENDO_COD_EMPRESA);

            /*" -2502- MOVE '1' TO V0ENDO-CORRECAO */
            _.Move("1", V0ENDO_CORRECAO);

            /*" -2503- MOVE 'S' TO V0ENDO-ISENTA-CST */
            _.Move("S", V0ENDO_ISENTA_CST);

            /*" -2504- MOVE -1 TO VIND-DTVENCTO */
            _.Move(-1, VIND_DTVENCTO);

            /*" -2506- MOVE -1 TO VIND-VLCUSEMI */
            _.Move(-1, VIND_VLCUSEMI);

            /*" -2508- MOVE -1 TO VIND-CFPREFIX. */
            _.Move(-1, VIND_CFPREFIX);

            /*" -2509- MOVE V0APOL-RAMO TO V0ENDO-RAMO. */
            _.Move(V0APOL_RAMO, V0ENDO_RAMO);

            /*" -2512- MOVE V0APOL-CODPRODU TO V0ENDO-CODPRODU. */
            _.Move(V0APOL_CODPRODU, V0ENDO_CODPRODU);

            /*" -2515- MOVE '1075' TO WNR-EXEC-SQL. */
            _.Move("1075", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2605- PERFORM R1000_00_PROCESSA_REGISTRO_DB_INSERT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_2();

            /*" -2608- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2609- DISPLAY 'R1075-00 (ERRO - INSERT V0ENDOSSO)...' */
                _.Display($"R1075-00 (ERRO - INSERT V0ENDOSSO)...");

                /*" -2610- DISPLAY 'V0ENDO-NUM-APOL   = ' V0ENDO-NUM-APOL */
                _.Display($"V0ENDO-NUM-APOL   = {V0ENDO_NUM_APOL}");

                /*" -2611- DISPLAY 'V0ENDO-NRENDOS    = ' V0ENDO-NRENDOS */
                _.Display($"V0ENDO-NRENDOS    = {V0ENDO_NRENDOS}");

                /*" -2612- DISPLAY 'V0ENDO-FONTE      = ' V0ENDO-FONTE */
                _.Display($"V0ENDO-FONTE      = {V0ENDO_FONTE}");

                /*" -2613- DISPLAY 'V0ENDO-NRPROPOS   = ' V0ENDO-NRPROPOS */
                _.Display($"V0ENDO-NRPROPOS   = {V0ENDO_NRPROPOS}");

                /*" -2614- DISPLAY 'RAMO   : ' WWORK-RAMO-ANT */
                _.Display($"RAMO   : {WWORK_RAMO_ANT}");

                /*" -2615- DISPLAY 'OPCAO  : ' WWORK-OPCAO-ANT */
                _.Display($"OPCAO  : {WWORK_OPCAO_ANT}");

                /*" -2617- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2621- ADD +1 TO AC-I-V0ENDOSSO. */
            AREA_DE_WORK.AC_I_V0ENDOSSO.Value = AREA_DE_WORK.AC_I_V0ENDOSSO + +1;

            /*" -2622- MOVE V0ENDO-COD-EMPRESA TO V0APCB-COD-EMPRESA */
            _.Move(V0ENDO_COD_EMPRESA, V0APCB_COD_EMPRESA);

            /*" -2623- MOVE V0ENDO-FONTE TO V0APCB-FONTE */
            _.Move(V0ENDO_FONTE, V0APCB_FONTE);

            /*" -2624- MOVE V0ENDO-NUM-APOL TO V0APCB-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0APCB_NUM_APOL);

            /*" -2625- MOVE V0ENDO-NRENDOS TO V0APCB-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0APCB_NRENDOS);

            /*" -2626- MOVE V0ENDO-CODPRODU TO V0APCB-CODPRODU */
            _.Move(V0ENDO_CODPRODU, V0APCB_CODPRODU);

            /*" -2627- MOVE V0BILH-NUM-MATR TO V0APCB-NUM-MATR */
            _.Move(V0BILH_NUM_MATR, V0APCB_NUM_MATR);

            /*" -2628- MOVE '1' TO V0APCB-TIPOCOB */
            _.Move("1", V0APCB_TIPOCOB);

            /*" -2629- MOVE V0BILH-AGECOBR TO V0APCB-AGECOBR */
            _.Move(V0BILH_AGECOBR, V0APCB_AGECOBR);

            /*" -2630- MOVE V0BILH-AGENCIA TO V0APCB-AGENCIA */
            _.Move(V0BILH_AGENCIA, V0APCB_AGENCIA);

            /*" -2631- MOVE V0BILH-OPE-CONTA TO V0APCB-OPE-CONTA */
            _.Move(V0BILH_OPE_CONTA, V0APCB_OPE_CONTA);

            /*" -2632- MOVE V0BILH-NUM-CONTA TO V0APCB-NUM-CONTA */
            _.Move(V0BILH_NUM_CONTA, V0APCB_NUM_CONTA);

            /*" -2633- MOVE V0BILH-DIG-CONTA TO V0APCB-DIG-CONTA */
            _.Move(V0BILH_DIG_CONTA, V0APCB_DIG_CONTA);

            /*" -2634- MOVE V0BILH-AGENCIA-DEB TO V0APCB-AGENCIA-DEB */
            _.Move(V0BILH_AGENCIA_DEB, V0APCB_AGENCIA_DEB);

            /*" -2635- MOVE V0BILH-OPERACAO-DEB TO V0APCB-OPERACAO-DEB */
            _.Move(V0BILH_OPERACAO_DEB, V0APCB_OPERACAO_DEB);

            /*" -2636- MOVE V0BILH-NUMCTA-DEB TO V0APCB-NUMCTA-DEB */
            _.Move(V0BILH_NUMCTA_DEB, V0APCB_NUMCTA_DEB);

            /*" -2637- MOVE V0BILH-DIGCTA-DEB TO V0APCB-DIGCTA-DEB */
            _.Move(V0BILH_DIGCTA_DEB, V0APCB_DIGCTA_DEB);

            /*" -2638- MOVE ZEROS TO V0APCB-NUM-CARTAO */
            _.Move(0, V0APCB_NUM_CARTAO);

            /*" -2639- MOVE V0BILH-DTQITBCO TO WDATA-SISTEMA */
            _.Move(V0BILH_DTQITBCO, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -2640- MOVE WDATA-SIS-DIA TO V0APCB-DIA-DEBITO */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA, V0APCB_DIA_DEBITO);

            /*" -2641- MOVE SPACES TO V0APCB-NRCERTIF */
            _.Move("", V0APCB_NRCERTIF);

            /*" -2643- MOVE ZEROS TO V0APCB-MARGEM. */
            _.Move(0, V0APCB_MARGEM);

            /*" -2652- MOVE ZEROS TO VIND-AGENCIA VIND-OPERACAO VIND-NUMCONTA VIND-DIGCONTA VIND-NUMCARTAO VIND-DIADEBITO VIND-NRCERTIF VIND-MARGEM. */
            _.Move(0, VIND_AGENCIA, VIND_OPERACAO, VIND_NUMCONTA, VIND_DIGCONTA, VIND_NUMCARTAO, VIND_DIADEBITO, VIND_NRCERTIF, VIND_MARGEM);

            /*" -2655- MOVE '1076' TO WNR-EXEC-SQL. */
            _.Move("1076", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2699- PERFORM R1000_00_PROCESSA_REGISTRO_DB_INSERT_3 */

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_3();

            /*" -2702- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2703- DISPLAY 'R1076-00 (ERRO - INSERT V0APOLCOB)...' */
                _.Display($"R1076-00 (ERRO - INSERT V0APOLCOB)...");

                /*" -2704- DISPLAY 'V0ENDO-NUM-APOL   = ' V0ENDO-NUM-APOL */
                _.Display($"V0ENDO-NUM-APOL   = {V0ENDO_NUM_APOL}");

                /*" -2705- DISPLAY 'V0ENDO-NRENDOS    = ' V0ENDO-NRENDOS */
                _.Display($"V0ENDO-NRENDOS    = {V0ENDO_NRENDOS}");

                /*" -2706- DISPLAY 'V0ENDO-FONTE      = ' V0ENDO-FONTE */
                _.Display($"V0ENDO-FONTE      = {V0ENDO_FONTE}");

                /*" -2707- DISPLAY 'V0ENDO-NRPROPOS   = ' V0ENDO-NRPROPOS */
                _.Display($"V0ENDO-NRPROPOS   = {V0ENDO_NRPROPOS}");

                /*" -2708- DISPLAY 'RAMO   : ' WWORK-RAMO-ANT */
                _.Display($"RAMO   : {WWORK_RAMO_ANT}");

                /*" -2709- DISPLAY 'OPCAO  : ' WWORK-OPCAO-ANT */
                _.Display($"OPCAO  : {WWORK_OPCAO_ANT}");

                /*" -2718- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2719- IF ORIGEM-MARSH */

            if (WREA88.W_ORIGEM_PROPOSTA["ORIGEM_MARSH"])
            {

                /*" -2720- PERFORM R1030-00-TRATA-FENAE */

                R1030_00_TRATA_FENAE_SECTION();

                /*" -2722- ELSE */
            }
            else
            {


                /*" -2724- IF WS-PROD-RUNON AND V1SIST-DTMOVACB >= '2021-08-16' */

                if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"] && V1SIST_DTMOVACB >= "2021-08-16")
                {

                    /*" -2725- PERFORM R1051-00-TRATA-FUNDAO-01 */

                    R1051_00_TRATA_FUNDAO_01_SECTION();

                    /*" -2726- ELSE */
                }
                else
                {


                    /*" -2727- PERFORM R1050-00-TRATA-FUNDAO */

                    R1050_00_TRATA_FUNDAO_SECTION();

                    /*" -2728- END-IF */
                }


                /*" -2733- END-IF */
            }


            /*" -2735- PERFORM R4280-00-TRATA-FC0105S. */

            R4280_00_TRATA_FC0105S_SECTION();

            /*" -2737- ADD +1 TO AC-I-V0APOLCORRET. */
            AREA_DE_WORK.AC_I_V0APOLCORRET.Value = AREA_DE_WORK.AC_I_V0APOLCORRET + +1;

            /*" -2737- MOVE ZEROS TO V0PARC-NRPARCEL. */
            _.Move(0, V0PARC_NRPARCEL);

            /*" -0- FLUXCONTROL_PERFORM R1000_20_PARCELA */

            R1000_20_PARCELA();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -2020- EXEC SQL SELECT SEQ_APOLICE INTO :V1NAES-SEQ-APOL FROM SEGUROS.V1NUMERO_AES WHERE COD_ORGAO = :WH-JV1-COD-ORGAO AND COD_RAMO = :V0BILH-RAMO END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                WH_JV1_COD_ORGAO = WORK_JV1.WH_JV1_COD_ORGAO.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1NAES_SEQ_APOL, V1NAES_SEQ_APOL);
            }


        }

        [StopWatch]
        /*" R1000-20-PARCELA */
        private void R1000_20_PARCELA(bool isPerform = false)
        {
            /*" -2743- PERFORM R1080-00-GRAVA-V0APOLCOSCED. */

            R1080_00_GRAVA_V0APOLCOSCED_SECTION();

            /*" -2745- IF WACC-PCTCED GREATER ZEROS AND WACC-QTCOSSEG GREATER ZEROS */

            if (AREA_DE_WORK.WACC_PCTCED > 00 && AREA_DE_WORK.WACC_QTCOSSEG > 00)
            {

                /*" -2747- PERFORM R1090-00-UPDATE-V0APOLICE. */

                R1090_00_UPDATE_V0APOLICE_SECTION();
            }


            /*" -2748- MOVE V0APOL-NUM-APOL TO V0PARC-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0PARC_NUM_APOL);

            /*" -2749- MOVE 0 TO V0PARC-NRENDOS */
            _.Move(0, V0PARC_NRENDOS);

            /*" -2751- ADD 1 TO V0PARC-NRPARCEL */
            V0PARC_NRPARCEL.Value = V0PARC_NRPARCEL + 1;

            /*" -2752- IF V0PARC-NRPARCEL GREATER V0ENDO-QTPARCEL */

            if (V0PARC_NRPARCEL > V0ENDO_QTPARCEL)
            {

                /*" -2759- GO TO R1000-20-CONTINUA. */

                R1000_20_CONTINUA(); //GOTO
                return;
            }


            /*" -2760- IF V0PARC-NRPARCEL EQUAL 01 */

            if (V0PARC_NRPARCEL == 01)
            {

                /*" -2761- MOVE V0BILH-NUMBIL TO V0PARC-NRTIT */
                _.Move(V0BILH_NUMBIL, V0PARC_NRTIT);

                /*" -2762- MOVE 2 TO V0PARC-OCORHIST */
                _.Move(2, V0PARC_OCORHIST);

                /*" -2763- MOVE '1' TO V0PARC-SITUACAO */
                _.Move("1", V0PARC_SITUACAO);

                /*" -2764- ELSE */
            }
            else
            {


                /*" -2765- MOVE ZEROS TO V0PARC-NRTIT */
                _.Move(0, V0PARC_NRTIT);

                /*" -2766- MOVE 1 TO V0PARC-OCORHIST */
                _.Move(1, V0PARC_OCORHIST);

                /*" -2768- MOVE '0' TO V0PARC-SITUACAO. */
                _.Move("0", V0PARC_SITUACAO);
            }


            /*" -2769- MOVE '0' TO V0PARC-DACPARC */
            _.Move("0", V0PARC_DACPARC);

            /*" -2770- MOVE V0BILH-FONTE TO V0PARC-FONTE */
            _.Move(V0BILH_FONTE, V0PARC_FONTE);

            /*" -2771- MOVE WWORK-PR-APOL TO V0PARC-PRM-TAR-IX */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0PARC_PRM_TAR_IX);

            /*" -2772- MOVE ZEROS TO V0PARC-VAL-DES-IX */
            _.Move(0, V0PARC_VAL_DES_IX);

            /*" -2773- MOVE WWORK-PR-APOL TO V0PARC-OTNPRLIQ */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0PARC_OTNPRLIQ);

            /*" -2774- MOVE ZEROS TO V0PARC-OTNADFRA */
            _.Move(0, V0PARC_OTNADFRA);

            /*" -2776- MOVE ZEROS TO V0PARC-OTNCUSTO */
            _.Move(0, V0PARC_OTNCUSTO);

            /*" -2779- COMPUTE WS-VAL-IOCC-IX ROUNDED = V0PARC-OTNPRLIQ * V1BILC-PCIOCC / 100. */
            AREA_DE_WORK.WS_VAL_IOCC_IX.Value = V0PARC_OTNPRLIQ * V1BILC_PCIOCC / 100f;

            /*" -2781- MOVE WS-VAL-IOCC-IX TO V0PARC-OTNIOF */
            _.Move(AREA_DE_WORK.WS_VAL_IOCC_IX, V0PARC_OTNIOF);

            /*" -2785- COMPUTE WS-PRM-TOTAL-IX = V0PARC-OTNPRLIQ + V0PARC-OTNADFRA + V0PARC-OTNCUSTO + V0PARC-OTNIOF. */
            AREA_DE_WORK.WS_PRM_TOTAL_IX.Value = V0PARC_OTNPRLIQ + V0PARC_OTNADFRA + V0PARC_OTNCUSTO + V0PARC_OTNIOF;

            /*" -2788- MOVE WS-PRM-TOTAL-IX TO V0PARC-OTNTOTAL */
            _.Move(AREA_DE_WORK.WS_PRM_TOTAL_IX, V0PARC_OTNTOTAL);

            /*" -2789- MOVE ZEROS TO V0PARC-QTDDOC */
            _.Move(0, V0PARC_QTDDOC);

            /*" -2791- MOVE ZEROS TO V0PARC-COD-EMPRESA. */
            _.Move(0, V0PARC_COD_EMPRESA);

            /*" -2794- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2818- PERFORM R1000_20_PARCELA_DB_INSERT_1 */

            R1000_20_PARCELA_DB_INSERT_1();

            /*" -2821- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2822- DISPLAY 'R2000-00 (ERRO - INSERT V0PARCELA)...' */
                _.Display($"R2000-00 (ERRO - INSERT V0PARCELA)...");

                /*" -2826- DISPLAY 'APOL: ' V0PARC-NUM-APOL '  ' 'ENDO: ' V0PARC-NRENDOS '  ' 'PARC: ' V0PARC-NRPARCEL '  ' 'BILH: ' V0BILH-NUMBIL */

                $"APOL: {V0PARC_NUM_APOL}  ENDO: {V0PARC_NRENDOS}  PARC: {V0PARC_NRPARCEL}  BILH: {V0BILH_NUMBIL}"
                .Display();

                /*" -2828- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2830- ADD +1 TO AC-I-V0PARCELA. */
            AREA_DE_WORK.AC_I_V0PARCELA.Value = AREA_DE_WORK.AC_I_V0PARCELA + +1;

            /*" -2835- PERFORM R2010-00-GRAVA-V0HISTOPARC. */

            R2010_00_GRAVA_V0HISTOPARC_SECTION();

            /*" -2836- IF V0PARC-NRPARCEL EQUAL 1 */

            if (V0PARC_NRPARCEL == 1)
            {

                /*" -2837- PERFORM R2020-00-GRAVA-OPERACAO-BAIXA */

                R2020_00_GRAVA_OPERACAO_BAIXA_SECTION();

                /*" -2838- ELSE */
            }
            else
            {


                /*" -2840- PERFORM R2050-00-GRAVA-MOVDEBCC-CEF. */

                R2050_00_GRAVA_MOVDEBCC_CEF_SECTION();
            }


            /*" -2840- GO TO R1000-20-PARCELA. */
            new Task(() => R1000_20_PARCELA()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1000-20-PARCELA-DB-INSERT-1 */
        public void R1000_20_PARCELA_DB_INSERT_1()
        {
            /*" -2818- EXEC SQL INSERT INTO SEGUROS.V0PARCELA VALUES (:V0PARC-NUM-APOL , :V0PARC-NRENDOS , :V0PARC-NRPARCEL , :V0PARC-DACPARC , :V0PARC-FONTE , :V0PARC-NRTIT , :V0PARC-PRM-TAR-IX , :V0PARC-VAL-DES-IX , :V0PARC-OTNPRLIQ , :V0PARC-OTNADFRA , :V0PARC-OTNCUSTO , :V0PARC-OTNIOF , :V0PARC-OTNTOTAL , :V0PARC-OCORHIST , :V0PARC-QTDDOC , :V0PARC-SITUACAO , :V0PARC-COD-EMPRESA , CURRENT TIMESTAMP, NULL) END-EXEC. */

            var r1000_20_PARCELA_DB_INSERT_1_Insert1 = new R1000_20_PARCELA_DB_INSERT_1_Insert1()
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

            R1000_20_PARCELA_DB_INSERT_1_Insert1.Execute(r1000_20_PARCELA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_2()
        {
            /*" -2049- EXEC SQL SELECT NUM_PROPOSTA_SIVPF, ORIGEM_PROPOSTA, NUM_SICOB, SIT_PROPOSTA INTO :V0CONV-NUM-PROPOSTA-SIVPF , :V0CONV-ORIGEM-PROPOSTA , :V0CONV-NUM-SICOB, :V0SIVPF-SIT-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :V0BILH-NUMBIL AND COD_PRODUTO_SIVPF IN (09,10) END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_NUM_PROPOSTA_SIVPF, V0CONV_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.V0CONV_ORIGEM_PROPOSTA, V0CONV_ORIGEM_PROPOSTA);
                _.Move(executed_1.V0CONV_NUM_SICOB, V0CONV_NUM_SICOB);
                _.Move(executed_1.V0SIVPF_SIT_PROPOSTA, V0SIVPF_SIT_PROPOSTA);
            }


        }

        [StopWatch]
        /*" R1000-20-CONTINUA */
        private void R1000_20_CONTINUA(bool isPerform = false)
        {
            /*" -2845- MOVE V0APOL-NUM-APOL TO V0COBA-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0COBA_NUM_APOL);

            /*" -2846- MOVE 0 TO V0COBA-NRENDOS */
            _.Move(0, V0COBA_NRENDOS);

            /*" -2847- MOVE ZEROS TO V0COBA-NUM-ITEM */
            _.Move(0, V0COBA_NUM_ITEM);

            /*" -2848- MOVE ZEROS TO V0COBA-COD-COBER */
            _.Move(0, V0COBA_COD_COBER);

            /*" -2849- MOVE 1 TO V0COBA-FATOR-MULT */
            _.Move(1, V0COBA_FATOR_MULT);

            /*" -2850- MOVE ZEROS TO V0COBA-COD-EMPRESA */
            _.Move(0, V0COBA_COD_EMPRESA);

            /*" -2851- MOVE '0' TO V0COBA-SITUACAO */
            _.Move("0", V0COBA_SITUACAO);

            /*" -2853- MOVE +0 TO VIND-SITUACAO */
            _.Move(+0, VIND_SITUACAO);

            /*" -2854- MOVE V0ENDO-DTINIVIG TO V0COBA-DATA-INIVI */
            _.Move(V0ENDO_DTINIVIG, V0COBA_DATA_INIVI);

            /*" -2855- MOVE V0ENDO-DTTERVIG TO V0COBA-DATA-TERVI */
            _.Move(V0ENDO_DTTERVIG, V0COBA_DATA_TERVI);

            /*" -2856- MOVE 1 TO V0COBA-OCORHIST */
            _.Move(1, V0COBA_OCORHIST);

            /*" -2857- MOVE WWORK-RAMO-ANT TO V0COBA-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0COBA_RAMOFR);

            /*" -2859- MOVE V0APOL-MODALIDA TO V0COBA-MODALIFR */
            _.Move(V0APOL_MODALIDA, V0COBA_MODALIFR);

            /*" -2860- MOVE WWORK-IS-APOL TO V0COBA-IMP-SEG-IX */
            _.Move(AREA_DE_WORK.WWORK_IS_APOL, V0COBA_IMP_SEG_IX);

            /*" -2861- MOVE WWORK-PR-APOL TO V0COBA-PRM-TAR-IX */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0COBA_PRM_TAR_IX);

            /*" -2862- MOVE WWORK-IS-APOL TO V0COBA-IMP-SEG-VR */
            _.Move(AREA_DE_WORK.WWORK_IS_APOL, V0COBA_IMP_SEG_VR);

            /*" -2864- MOVE WWORK-PR-APOL TO V0COBA-PRM-TAR-VR */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0COBA_PRM_TAR_VR);

            /*" -2866- MOVE 100 TO V0COBA-PCT-COBERT. */
            _.Move(100, V0COBA_PCT_COBERT);

            /*" -2869- MOVE '2030' TO WNR-EXEC-SQL. */
            _.Move("2030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2889- PERFORM R1000_20_CONTINUA_DB_INSERT_1 */

            R1000_20_CONTINUA_DB_INSERT_1();

            /*" -2892- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2893- DISPLAY 'R2030-00 (ERRO - INSERT V0COBERAPOL)...' */
                _.Display($"R2030-00 (ERRO - INSERT V0COBERAPOL)...");

                /*" -2896- DISPLAY 'APOL: ' V0COBA-NUM-APOL '  ' 'ENDO: ' V0COBA-NRENDOS '  ' 'RAMO: ' V0COBA-RAMOFR '  ' */

                $"APOL: {V0COBA_NUM_APOL}  ENDO: {V0COBA_NRENDOS}  RAMO: {V0COBA_RAMOFR}  "
                .Display();

                /*" -2898- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2905- ADD +1 TO AC-I-V0COBERAPOL. */
            AREA_DE_WORK.AC_I_V0COBERAPOL.Value = AREA_DE_WORK.AC_I_V0COBERAPOL + +1;

            /*" -2906- IF WWORK-FUNDAO EQUAL 'S' */

            if (AREA_DE_WORK.WWORK_FUNDAO == "S")
            {

                /*" -2911- GO TO R1000-00-LEITURA. */

                R1000_00_LEITURA(); //GOTO
                return;
            }


            /*" -2912- MOVE 17256 TO V0ADIA-CODPDT */
            _.Move(17256, V0ADIA_CODPDT);

            /*" -2914- MOVE 010 TO V0ADIA-FONTE */
            _.Move(010, V0ADIA_FONTE);

            /*" -2916- MOVE '2034' TO WNR-EXEC-SQL. */
            _.Move("2034", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2918- MOVE V0APOL-NUMBIL TO WHOST-NUMBIL. */
            _.Move(V0APOL_NUMBIL, WHOST_NUMBIL);

            /*" -2926- PERFORM R1000_20_CONTINUA_DB_SELECT_1 */

            R1000_20_CONTINUA_DB_SELECT_1();

            /*" -2929- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2930- GO TO R1000-00-LEITURA */

                R1000_00_LEITURA(); //GOTO
                return;

                /*" -2931- ELSE */
            }
            else
            {


                /*" -2932- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2933- DISPLAY 'R2034-00 (ERRO - SELECT V0ADIANTA)...' */
                    _.Display($"R2034-00 (ERRO - SELECT V0ADIANTA)...");

                    /*" -2935- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2938- MOVE '2035' TO WNR-EXEC-SQL. */
            _.Move("2035", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2942- PERFORM R1000_20_CONTINUA_DB_SELECT_2 */

            R1000_20_CONTINUA_DB_SELECT_2();

            /*" -2945- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2946- DISPLAY 'R2035-00 (ERRO - SELECT V0NUMERO_OUTROS)...' */
                _.Display($"R2035-00 (ERRO - SELECT V0NUMERO_OUTROS)...");

                /*" -2948- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2949- COMPUTE V1NOUT-NUMOPG = V1NOUT-NUMOPG + 1. */
            V1NOUT_NUMOPG.Value = V1NOUT_NUMOPG + 1;

            /*" -2951- MOVE V1NOUT-NUMOPG TO V0ADIA-NUMOPG */
            _.Move(V1NOUT_NUMOPG, V0ADIA_NUMOPG);

            /*" -2954- MOVE '2040' TO WNR-EXEC-SQL. */
            _.Move("2040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2958- PERFORM R1000_20_CONTINUA_DB_UPDATE_1 */

            R1000_20_CONTINUA_DB_UPDATE_1();

            /*" -2961- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2962- DISPLAY 'R2040-00 (ERRO - UPDATE V0NUMERO_OUTROS)...' */
                _.Display($"R2040-00 (ERRO - UPDATE V0NUMERO_OUTROS)...");

                /*" -2963- DISPLAY 'NUMOPG: ' V1NOUT-NUMOPG */
                _.Display($"NUMOPG: {V1NOUT_NUMOPG}");

                /*" -2965- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2966- MOVE ZEROS TO V0ADIA-QTPRESTA */
            _.Move(0, V0ADIA_QTPRESTA);

            /*" -2967- MOVE ZEROS TO V0ADIA-NRPROPOS */
            _.Move(0, V0ADIA_NRPROPOS);

            /*" -2968- MOVE V0APOL-NUM-APOL TO V0ADIA-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0ADIA_NUM_APOL);

            /*" -2969- MOVE ZEROS TO V0ADIA-NRENDOS */
            _.Move(0, V0ADIA_NRENDOS);

            /*" -2970- MOVE ZEROS TO V0ADIA-NRPARCEL */
            _.Move(0, V0ADIA_NRPARCEL);

            /*" -2971- MOVE V1SIST-DTMOVABE TO V0ADIA-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0ADIA_DTMOVTO);

            /*" -2972- MOVE '0' TO V0ADIA-SITUACAO */
            _.Move("0", V0ADIA_SITUACAO);

            /*" -2973- MOVE ZEROS TO V0ADIA-COD-EMP */
            _.Move(0, V0ADIA_COD_EMP);

            /*" -2975- MOVE '2' TO V0ADIA-TIPO-ADT */
            _.Move("2", V0ADIA_TIPO_ADT);

            /*" -2978- MOVE '2045' TO WNR-EXEC-SQL. */
            _.Move("2045", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2994- PERFORM R1000_20_CONTINUA_DB_INSERT_2 */

            R1000_20_CONTINUA_DB_INSERT_2();

            /*" -2997- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3004- DISPLAY 'R2045-00 (ERRO - INSERT V0ADIANTA)...' 'CODPDT: ' V0ADIA-CODPDT '  ' 'NUMOPG: ' V0ADIA-NUMOPG '  ' 'APOL: ' V0ADIA-NUM-APOL '  ' 'ENDO: ' V0ADIA-NRENDOS '  ' 'PARC: ' V0ADIA-NRPARCEL '  ' 'FONTE: ' V0ADIA-FONTE */

                $"R2045-00 (ERRO - INSERT V0ADIANTA)...CODPDT: {V0ADIA_CODPDT}  NUMOPG: {V0ADIA_NUMOPG}  APOL: {V0ADIA_NUM_APOL}  ENDO: {V0ADIA_NRENDOS}  PARC: {V0ADIA_NRPARCEL}  FONTE: {V0ADIA_FONTE}"
                .Display();

                /*" -3006- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3011- ADD +1 TO AC-I-V0ADIANTA. */
            AREA_DE_WORK.AC_I_V0ADIANTA.Value = AREA_DE_WORK.AC_I_V0ADIANTA + +1;

            /*" -3012- MOVE 17256 TO V0FORM-CODPDT */
            _.Move(17256, V0FORM_CODPDT);

            /*" -3013- MOVE 010 TO V0FORM-FONTE */
            _.Move(010, V0FORM_FONTE);

            /*" -3014- MOVE V0ADIA-NUMOPG TO V0FORM-NUMOPG */
            _.Move(V0ADIA_NUMOPG, V0FORM_NUMOPG);

            /*" -3015- MOVE ZEROS TO V0FORM-NRPROPOS */
            _.Move(0, V0FORM_NRPROPOS);

            /*" -3016- MOVE V0APOL-NUM-APOL TO V0FORM-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0FORM_NUM_APOL);

            /*" -3017- MOVE ZEROS TO V0FORM-NRENDOS */
            _.Move(0, V0FORM_NRENDOS);

            /*" -3018- MOVE ZEROS TO V0FORM-NRPARCEL */
            _.Move(0, V0FORM_NRPARCEL);

            /*" -3019- MOVE ZEROS TO V0FORM-NUMPTC */
            _.Move(0, V0FORM_NUMPTC);

            /*" -3020- MOVE V0ADIA-VALADT TO V0FORM-VALRCP */
            _.Move(V0ADIA_VALADT, V0FORM_VALRCP);

            /*" -3021- MOVE ZEROS TO V0FORM-PCGACM */
            _.Move(0, V0FORM_PCGACM);

            /*" -3022- MOVE '0' TO V0FORM-SITUACAO */
            _.Move("0", V0FORM_SITUACAO);

            /*" -3023- MOVE V0ADIA-VALADT TO V0FORM-VALSDO */
            _.Move(V0ADIA_VALADT, V0FORM_VALSDO);

            /*" -3024- MOVE V1SIST-DTMOVABE TO V0FORM-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0FORM_DTMOVTO);

            /*" -3025- MOVE V1SIST-DTMOVABE TO V0FORM-DTVENCTO */
            _.Move(V1SIST_DTMOVABE, V0FORM_DTVENCTO);

            /*" -3027- MOVE ZEROS TO V0FORM-COD-EMP */
            _.Move(0, V0FORM_COD_EMP);

            /*" -3030- MOVE '2050' TO WNR-EXEC-SQL. */
            _.Move("2050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3048- PERFORM R1000_20_CONTINUA_DB_INSERT_3 */

            R1000_20_CONTINUA_DB_INSERT_3();

            /*" -3051- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3058- DISPLAY 'PROBLEMAS NA INSERCAO (V0FORMAREC) ... ' ' ' V0FORM-CODPDT ' ' V0FORM-NUMOPG ' ' V0FORM-NUM-APOL ' ' V0FORM-NRENDOS ' ' V0FORM-NRPARCEL ' ' V0FORM-FONTE */

                $"PROBLEMAS NA INSERCAO (V0FORMAREC) ...  {V0FORM_CODPDT} {V0FORM_NUMOPG} {V0FORM_NUM_APOL} {V0FORM_NRENDOS} {V0FORM_NRPARCEL} {V0FORM_FONTE}"
                .Display();

                /*" -3063- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3064- MOVE 17256 TO V0HISR-CODPDT */
            _.Move(17256, V0HISR_CODPDT);

            /*" -3065- MOVE 010 TO V0HISR-FONTE */
            _.Move(010, V0HISR_FONTE);

            /*" -3066- MOVE V0ADIA-NUMOPG TO V0HISR-NUMOPG */
            _.Move(V0ADIA_NUMOPG, V0HISR_NUMOPG);

            /*" -3067- MOVE ZEROS TO V0HISR-NRPROPOS */
            _.Move(0, V0HISR_NRPROPOS);

            /*" -3068- MOVE V0APOL-NUM-APOL TO V0HISR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0HISR_NUM_APOL);

            /*" -3069- MOVE ZEROS TO V0HISR-NRENDOS */
            _.Move(0, V0HISR_NRENDOS);

            /*" -3070- MOVE ZEROS TO V0HISR-NRPARCEL */
            _.Move(0, V0HISR_NRPARCEL);

            /*" -3071- MOVE ZEROS TO V0HISR-NUMPTC */
            _.Move(0, V0HISR_NUMPTC);

            /*" -3072- MOVE V0ADIA-VALADT TO V0HISR-VALRCP */
            _.Move(V0ADIA_VALADT, V0HISR_VALRCP);

            /*" -3073- MOVE 999999 TO V0HISR-NUMREC */
            _.Move(999999, V0HISR_NUMREC);

            /*" -3074- MOVE V1SIST-DTMOVABE TO V0HISR-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0HISR_DTMOVTO);

            /*" -3075- MOVE 1401 TO V0HISR-OPERACAO */
            _.Move(1401, V0HISR_OPERACAO);

            /*" -3077- MOVE ZEROS TO V0HISR-COD-EMP */
            _.Move(0, V0HISR_COD_EMP);

            /*" -3080- MOVE '2055' TO WNR-EXEC-SQL. */
            _.Move("2055", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3097- PERFORM R1000_20_CONTINUA_DB_INSERT_4 */

            R1000_20_CONTINUA_DB_INSERT_4();

            /*" -3100- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3107- DISPLAY 'PROBLEMAS NA INSERCAO (V0HISTOREC) ... ' ' ' V0HISR-CODPDT ' ' V0HISR-NUMOPG ' ' V0HISR-NUM-APOL ' ' V0HISR-NRENDOS ' ' V0HISR-NRPARCEL ' ' V0HISR-FONTE */

                $"PROBLEMAS NA INSERCAO (V0HISTOREC) ...  {V0HISR_CODPDT} {V0HISR_NUMOPG} {V0HISR_NUM_APOL} {V0HISR_NRENDOS} {V0HISR_NRPARCEL} {V0HISR_FONTE}"
                .Display();

                /*" -3107- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1000-20-CONTINUA-DB-INSERT-1 */
        public void R1000_20_CONTINUA_DB_INSERT_1()
        {
            /*" -2889- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:V0COBA-NUM-APOL , :V0COBA-NRENDOS , :V0COBA-NUM-ITEM , :V0COBA-OCORHIST , :V0COBA-RAMOFR , :V0COBA-MODALIFR , :V0COBA-COD-COBER , :V0COBA-IMP-SEG-IX , :V0COBA-PRM-TAR-IX , :V0COBA-IMP-SEG-VR , :V0COBA-PRM-TAR-VR , :V0COBA-PCT-COBERT , :V0COBA-FATOR-MULT , :V0COBA-DATA-INIVI , :V0COBA-DATA-TERVI , :V0COBA-COD-EMPRESA , CURRENT TIMESTAMP , :V0COBA-SITUACAO:VIND-SITUACAO) END-EXEC. */

            var r1000_20_CONTINUA_DB_INSERT_1_Insert1 = new R1000_20_CONTINUA_DB_INSERT_1_Insert1()
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

            R1000_20_CONTINUA_DB_INSERT_1_Insert1.Execute(r1000_20_CONTINUA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-20-CONTINUA-DB-SELECT-1 */
        public void R1000_20_CONTINUA_DB_SELECT_1()
        {
            /*" -2926- EXEC SQL SELECT NUMOPG INTO :WHOST-NUMOPG FROM SEGUROS.V0ADIANTA WHERE CODPDT = 17256 AND NUM_APOLICE = :WHOST-NUMBIL AND NUMOPG > 0 WITH UR END-EXEC. */

            var r1000_20_CONTINUA_DB_SELECT_1_Query1 = new R1000_20_CONTINUA_DB_SELECT_1_Query1()
            {
                WHOST_NUMBIL = WHOST_NUMBIL.ToString(),
            };

            var executed_1 = R1000_20_CONTINUA_DB_SELECT_1_Query1.Execute(r1000_20_CONTINUA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NUMOPG, WHOST_NUMOPG);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_3()
        {
            /*" -2070- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :V0CONV-NUM-PROPOSTA-SIVPF FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB = :V0BILH-NUMBIL WITH UR END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_NUM_PROPOSTA_SIVPF, V0CONV_NUM_PROPOSTA_SIVPF);
            }


        }

        [StopWatch]
        /*" R1000-20-CONTINUA-DB-UPDATE-1 */
        public void R1000_20_CONTINUA_DB_UPDATE_1()
        {
            /*" -2958- EXEC SQL UPDATE SEGUROS.V0NUMERO_OUTROS SET NUMOPG = :V1NOUT-NUMOPG WHERE NUMOPG > 0 END-EXEC. */

            var r1000_20_CONTINUA_DB_UPDATE_1_Update1 = new R1000_20_CONTINUA_DB_UPDATE_1_Update1()
            {
                V1NOUT_NUMOPG = V1NOUT_NUMOPG.ToString(),
            };

            R1000_20_CONTINUA_DB_UPDATE_1_Update1.Execute(r1000_20_CONTINUA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-20-CONTINUA-DB-SELECT-2 */
        public void R1000_20_CONTINUA_DB_SELECT_2()
        {
            /*" -2942- EXEC SQL SELECT NUMOPG INTO :V1NOUT-NUMOPG FROM SEGUROS.V0NUMERO_OUTROS END-EXEC. */

            var r1000_20_CONTINUA_DB_SELECT_2_Query1 = new R1000_20_CONTINUA_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R1000_20_CONTINUA_DB_SELECT_2_Query1.Execute(r1000_20_CONTINUA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1NOUT_NUMOPG, V1NOUT_NUMOPG);
            }


        }

        [StopWatch]
        /*" R1000-20-CONTINUA-DB-INSERT-2 */
        public void R1000_20_CONTINUA_DB_INSERT_2()
        {
            /*" -2994- EXEC SQL INSERT INTO SEGUROS.V0ADIANTA VALUES (:V0ADIA-CODPDT , :V0ADIA-FONTE , :V0ADIA-NUMOPG , :V0ADIA-VALADT , :V0ADIA-QTPRESTA , :V0ADIA-NRPROPOS , :V0ADIA-NUM-APOL , :V0ADIA-NRENDOS , :V0ADIA-NRPARCEL , :V0ADIA-DTMOVTO , :V0ADIA-SITUACAO , :V0ADIA-COD-EMP , CURRENT TIMESTAMP , :V0ADIA-TIPO-ADT) END-EXEC. */

            var r1000_20_CONTINUA_DB_INSERT_2_Insert1 = new R1000_20_CONTINUA_DB_INSERT_2_Insert1()
            {
                V0ADIA_CODPDT = V0ADIA_CODPDT.ToString(),
                V0ADIA_FONTE = V0ADIA_FONTE.ToString(),
                V0ADIA_NUMOPG = V0ADIA_NUMOPG.ToString(),
                V0ADIA_VALADT = V0ADIA_VALADT.ToString(),
                V0ADIA_QTPRESTA = V0ADIA_QTPRESTA.ToString(),
                V0ADIA_NRPROPOS = V0ADIA_NRPROPOS.ToString(),
                V0ADIA_NUM_APOL = V0ADIA_NUM_APOL.ToString(),
                V0ADIA_NRENDOS = V0ADIA_NRENDOS.ToString(),
                V0ADIA_NRPARCEL = V0ADIA_NRPARCEL.ToString(),
                V0ADIA_DTMOVTO = V0ADIA_DTMOVTO.ToString(),
                V0ADIA_SITUACAO = V0ADIA_SITUACAO.ToString(),
                V0ADIA_COD_EMP = V0ADIA_COD_EMP.ToString(),
                V0ADIA_TIPO_ADT = V0ADIA_TIPO_ADT.ToString(),
            };

            R1000_20_CONTINUA_DB_INSERT_2_Insert1.Execute(r1000_20_CONTINUA_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1()
        {
            /*" -2237- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET SEQ_APOLICE = :V0NAES-SEQ-APOL WHERE COD_ORGAO = :WH-JV1-COD-ORGAO AND COD_RAMO = :WWORK-RAMO-ANT END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1()
            {
                V0NAES_SEQ_APOL = V0NAES_SEQ_APOL.ToString(),
                WH_JV1_COD_ORGAO = WORK_JV1.WH_JV1_COD_ORGAO.ToString(),
                WWORK_RAMO_ANT = WWORK_RAMO_ANT.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-20-CONTINUA-DB-INSERT-3 */
        public void R1000_20_CONTINUA_DB_INSERT_3()
        {
            /*" -3048- EXEC SQL INSERT INTO SEGUROS.V0FORMAREC VALUES (:V0FORM-CODPDT , :V0FORM-FONTE , :V0FORM-NUMOPG , :V0FORM-NRPROPOS , :V0FORM-NUM-APOL , :V0FORM-NRENDOS , :V0FORM-NRPARCEL , :V0FORM-NUMPTC , :V0FORM-VALRCP , :V0FORM-PCGACM , :V0FORM-SITUACAO , :V0FORM-VALSDO , :V0FORM-DTMOVTO , :V0FORM-DTVENCTO , :V0FORM-COD-EMP , CURRENT TIMESTAMP) END-EXEC. */

            var r1000_20_CONTINUA_DB_INSERT_3_Insert1 = new R1000_20_CONTINUA_DB_INSERT_3_Insert1()
            {
                V0FORM_CODPDT = V0FORM_CODPDT.ToString(),
                V0FORM_FONTE = V0FORM_FONTE.ToString(),
                V0FORM_NUMOPG = V0FORM_NUMOPG.ToString(),
                V0FORM_NRPROPOS = V0FORM_NRPROPOS.ToString(),
                V0FORM_NUM_APOL = V0FORM_NUM_APOL.ToString(),
                V0FORM_NRENDOS = V0FORM_NRENDOS.ToString(),
                V0FORM_NRPARCEL = V0FORM_NRPARCEL.ToString(),
                V0FORM_NUMPTC = V0FORM_NUMPTC.ToString(),
                V0FORM_VALRCP = V0FORM_VALRCP.ToString(),
                V0FORM_PCGACM = V0FORM_PCGACM.ToString(),
                V0FORM_SITUACAO = V0FORM_SITUACAO.ToString(),
                V0FORM_VALSDO = V0FORM_VALSDO.ToString(),
                V0FORM_DTMOVTO = V0FORM_DTMOVTO.ToString(),
                V0FORM_DTVENCTO = V0FORM_DTVENCTO.ToString(),
                V0FORM_COD_EMP = V0FORM_COD_EMP.ToString(),
            };

            R1000_20_CONTINUA_DB_INSERT_3_Insert1.Execute(r1000_20_CONTINUA_DB_INSERT_3_Insert1);

        }

        [StopWatch]
        /*" R1000-00-LEITURA */
        private void R1000_00_LEITURA(bool isPerform = false)
        {
            /*" -3113- IF WS-I-ERRO > ZEROS */

            if (WS_I_ERRO > 00)
            {

                /*" -3114- MOVE 'S' TO WS-FLAG-TEM-ERRO */
                _.Move("S", WS_FLAG_TEM_ERRO);

                /*" -3116- MOVE 1 TO WS-I-ERRO */
                _.Move(1, WS_I_ERRO);

                /*" -3118- PERFORM R3050-00-INSERE-ERRO UNTIL WS-FLAG-TEM-ERRO EQUAL 'N' */

                while (!(WS_FLAG_TEM_ERRO == "N"))
                {

                    R3050_00_INSERE_ERRO_SECTION();
                }

                /*" -3120- END-IF */
            }


            /*" -3121- IF WS-SIVPF EQUAL 'S' */

            if (AREA_DE_WORK.WS_SIVPF == "S")
            {

                /*" -3122- IF V0BILH-SITUACAO EQUAL '9' */

                if (V0BILH_SITUACAO == "9")
                {

                    /*" -3123- MOVE 'EMT' TO WHOST-SIT-PROP-SIVPF */
                    _.Move("EMT", WHOST_SIT_PROP_SIVPF);

                    /*" -3124- ELSE */
                }
                else
                {


                    /*" -3125- MOVE 'PEN' TO WHOST-SIT-PROP-SIVPF */
                    _.Move("PEN", WHOST_SIT_PROP_SIVPF);

                    /*" -3127- END-IF */
                }


                /*" -3129- IF V0SIVPF-SIT-PROPOSTA EQUAL WHOST-SIT-PROP-SIVPF NEXT SENTENCE */

                if (V0SIVPF_SIT_PROPOSTA == WHOST_SIT_PROP_SIVPF)
                {

                    /*" -3130- ELSE */
                }
                else
                {


                    /*" -3132- MOVE '2060' TO WNR-EXEC-SQL */
                    _.Move("2060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -3139- PERFORM R1000_00_LEITURA_DB_UPDATE_1 */

                    R1000_00_LEITURA_DB_UPDATE_1();

                    /*" -3141- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                    if (!DB.SQLCODE.In("00", "100"))
                    {

                        /*" -3143- DISPLAY 'PROBLEMAS NO UPDATE (PROPOSTA_FIDELIZ) ' ' ' V0BILH-NUMBIL */

                        $"PROBLEMAS NO UPDATE (PROPOSTA_FIDELIZ)  {V0BILH_NUMBIL}"
                        .Display();

                        /*" -3145- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -3147- IF V0BILH-RAMO EQUAL 82 OR 81 */

            if (V0BILH_RAMO.In("82", "81"))
            {

                /*" -3148- IF V0BILH-SITUACAO EQUAL '9' */

                if (V0BILH_SITUACAO == "9")
                {

                    /*" -3149- ADD 1 TO GELMR-QTD-SEGUROS */
                    GELMR_QTD_SEGUROS.Value = GELMR_QTD_SEGUROS + 1;

                    /*" -3150- IF WTEM-GELMR EQUAL 'SIM' */

                    if (AREA_DE_WORK.WTEM_GELMR == "SIM")
                    {

                        /*" -3151- PERFORM R1400-00-UPDATE-GELIMRISCO */

                        R1400_00_UPDATE_GELIMRISCO_SECTION();

                        /*" -3152- ELSE */
                    }
                    else
                    {


                        /*" -3154- PERFORM R1500-00-INSERT-GELIMRISCO. */

                        R1500_00_INSERT_GELIMRISCO_SECTION();
                    }

                }

            }


            /*" -3154- PERFORM R0910-00-FETCH-V0BILHETE. */

            R0910_00_FETCH_V0BILHETE_SECTION();

        }

        [StopWatch]
        /*" R1000-00-LEITURA-DB-UPDATE-1 */
        public void R1000_00_LEITURA_DB_UPDATE_1()
        {
            /*" -3139- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WHOST-SIT-PROP-SIVPF, SITUACAO_ENVIO = 'S' , COD_USUARIO = 'CB2005B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_SICOB = :V0BILH-NUMBIL END-EXEC */

            var r1000_00_LEITURA_DB_UPDATE_1_Update1 = new R1000_00_LEITURA_DB_UPDATE_1_Update1()
            {
                WHOST_SIT_PROP_SIVPF = WHOST_SIT_PROP_SIVPF.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R1000_00_LEITURA_DB_UPDATE_1_Update1.Execute(r1000_00_LEITURA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-20-CONTINUA-DB-INSERT-4 */
        public void R1000_20_CONTINUA_DB_INSERT_4()
        {
            /*" -3097- EXEC SQL INSERT INTO SEGUROS.V0HISTOREC VALUES (:V0HISR-CODPDT , :V0HISR-FONTE , :V0HISR-NUMOPG , :V0HISR-NRPROPOS , :V0HISR-NUM-APOL , :V0HISR-NRENDOS , :V0HISR-NRPARCEL , :V0HISR-NUMPTC , :V0HISR-VALRCP , :V0HISR-NUMREC , :V0HISR-DTMOVTO , :V0HISR-OPERACAO , CURRENT TIME, :V0HISR-COD-EMP , CURRENT TIMESTAMP) END-EXEC. */

            var r1000_20_CONTINUA_DB_INSERT_4_Insert1 = new R1000_20_CONTINUA_DB_INSERT_4_Insert1()
            {
                V0HISR_CODPDT = V0HISR_CODPDT.ToString(),
                V0HISR_FONTE = V0HISR_FONTE.ToString(),
                V0HISR_NUMOPG = V0HISR_NUMOPG.ToString(),
                V0HISR_NRPROPOS = V0HISR_NRPROPOS.ToString(),
                V0HISR_NUM_APOL = V0HISR_NUM_APOL.ToString(),
                V0HISR_NRENDOS = V0HISR_NRENDOS.ToString(),
                V0HISR_NRPARCEL = V0HISR_NRPARCEL.ToString(),
                V0HISR_NUMPTC = V0HISR_NUMPTC.ToString(),
                V0HISR_VALRCP = V0HISR_VALRCP.ToString(),
                V0HISR_NUMREC = V0HISR_NUMREC.ToString(),
                V0HISR_DTMOVTO = V0HISR_DTMOVTO.ToString(),
                V0HISR_OPERACAO = V0HISR_OPERACAO.ToString(),
                V0HISR_COD_EMP = V0HISR_COD_EMP.ToString(),
            };

            R1000_20_CONTINUA_DB_INSERT_4_Insert1.Execute(r1000_20_CONTINUA_DB_INSERT_4_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-4 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_4()
        {
            /*" -2091- EXEC SQL SELECT NUM_PROPOSTA_SIVPF, ORIGEM_PROPOSTA, NUM_SICOB, SIT_PROPOSTA INTO :V0CONV-NUM-PROPOSTA-SIVPF , :V0CONV-ORIGEM-PROPOSTA , :V0CONV-NUM-SICOB, :V0SIVPF-SIT-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :V0CONV-NUM-PROPOSTA-SIVPF END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1()
            {
                V0CONV_NUM_PROPOSTA_SIVPF = V0CONV_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_NUM_PROPOSTA_SIVPF, V0CONV_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.V0CONV_ORIGEM_PROPOSTA, V0CONV_ORIGEM_PROPOSTA);
                _.Move(executed_1.V0CONV_NUM_SICOB, V0CONV_NUM_SICOB);
                _.Move(executed_1.V0SIVPF_SIT_PROPOSTA, V0SIVPF_SIT_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-INSERT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_INSERT_1()
        {
            /*" -2438- EXEC SQL INSERT INTO SEGUROS.V0APOLICE (CODCLIEN , NUM_APOLICE , NUM_ITEM , MODALIDA , ORGAO , RAMO , NUM_APOL_ANTERIOR , NUMBIL , TIPSGU , TIPAPO , TIPCALC , PODPUBL , NUM_ATA , ANO_ATA , IDEMAN , PCDESCON , PCIOCC , TPCOSCED , QTCOSSEG , PCTCED , DATA_SORTEIO , COD_EMPRESA , TIMESTAMP , CODPRODU , TPCORRET) VALUES (:V0APOL-CODCLIEN , :V0APOL-NUM-APOL , :V0APOL-NUM-ITEM , :V0APOL-MODALIDA , :V0APOL-ORGAO , :V0APOL-RAMO , :V0APOL-NUM-APO-ANT , :V0APOL-NUMBIL , :V0APOL-TIPSGU , :V0APOL-TIPAPO , :V0APOL-TIPCALC , :V0APOL-PODPUBL , :V0APOL-NUM-ATA , :V0APOL-ANO-ATA , :V0APOL-IDEMAN , :V0APOL-PCDESCON , :V0APOL-PCIOCC , :V0APOL-TPCOSCED , :V0APOL-QTCOSSEG , :V0APOL-PCTCED , NULL , :V0APOL-COD-EMPRESA , CURRENT TIMESTAMP , :V0APOL-CODPRODU , :V0APOL-TPCORRET) END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1 = new R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1()
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

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1.Execute(r1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-5 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_5()
        {
            /*" -2180- EXEC SQL SELECT SUM(VAL_COBERTURA_IX), SUM(PRM_TARIFARIO_IX) INTO :V1BILC-IMPSEG-IX, :V1BILC-PRMTAR-IX FROM SEGUROS.V0BILHETE_COBER WHERE RAMOFR = :V1BILC-RAMOFR AND MODALIFR = :V1BILC-MODALIFR AND COD_OPCAO = :V1BILC-OPCAO AND DTINIVIG <= :V0BILH-DTQITBCO AND DTTERVIG >= :V0BILH-DTQITBCO WITH UR END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1()
            {
                V1BILC_MODALIFR = V1BILC_MODALIFR.ToString(),
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V1BILC_RAMOFR = V1BILC_RAMOFR.ToString(),
                V1BILC_OPCAO = V1BILC_OPCAO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILC_IMPSEG_IX, V1BILC_IMPSEG_IX);
                _.Move(executed_1.V1BILC_PRMTAR_IX, V1BILC_PRMTAR_IX);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-INSERT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_INSERT_2()
        {
            /*" -2605- EXEC SQL INSERT INTO SEGUROS.V0ENDOSSO (NUM_APOLICE , NRENDOS , CODSUBES , FONTE , NRPROPOS , DATPRO , DATA_LIBERACAO , DTEMIS , NRRCAP , VLRCAP , BCORCAP , AGERCAP , DACRCAP , IDRCAP , BCOCOBR , AGECOBR , DACCOBR , DTINIVIG , DTTERVIG , CDFRACIO , PCENTRAD , PCADICIO , PRESTA1 , QTPARCEL , QTPRESTA , QTITENS , CODTXT , CDACEITA , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SITUACAO , DATARCAP , COD_EMPRESA , CORRECAO , ISENTA_CUSTO , TIMESTAMP , DTVENCTO , CFPREFIX , VLCUSEMI , RAMO , CODPRODU) VALUES (:V0ENDO-NUM-APOL , :V0ENDO-NRENDOS , :V0ENDO-CODSUBES , :V0ENDO-FONTE , :V0ENDO-NRPROPOS , :V0ENDO-DATPRO , :V0ENDO-DT-LIBER , :V0ENDO-DTEMIS , :V0ENDO-NRRCAP , :V0ENDO-VLRCAP , :V0ENDO-BCORCAP , :V0ENDO-AGERCAP , :V0ENDO-DACRCAP , :V0ENDO-IDRCAP , :V0ENDO-BCOCOBR , :V0ENDO-AGECOBR , :V0ENDO-DACCOBR , :V0ENDO-DTINIVIG , :V0ENDO-DTTERVIG , :V0ENDO-CDFRACIO , :V0ENDO-PCENTRAD , :V0ENDO-PCADICIO , :V0ENDO-PRESTA1 , :V0ENDO-QTPARCEL , :V0ENDO-QTPRESTA , :V0ENDO-QTITENS , :V0ENDO-CODTXT , :V0ENDO-CDACEITA , :V0ENDO-MOEDA-IMP , :V0ENDO-MOEDA-PRM , :V0ENDO-TIPO-ENDO , :V0ENDO-COD-USUAR , :V0ENDO-OCORR-END , :V0ENDO-SITUACAO , :V0ENDO-DATARCAP:VIND-DATARCAP , :V0ENDO-COD-EMPRESA , :V0ENDO-CORRECAO , :V0ENDO-ISENTA-CST , CURRENT TIMESTAMP , :V0ENDO-DTVENCTO:VIND-DTVENCTO , :V0ENDO-CFPREFIX:VIND-CFPREFIX , :V0ENDO-VLCUSEMI:VIND-VLCUSEMI , :V0ENDO-RAMO , :V0ENDO-CODPRODU) END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1 = new R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1()
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

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1.Execute(r1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1010-00-VERIFICA-ORIGEM-SECTION */
        private void R1010_00_VERIFICA_ORIGEM_SECTION()
        {
            /*" -3166- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3167- MOVE 1 TO WINF. */
            _.Move(1, AREA_DE_WORK.WINF);

            /*" -3168- MOVE WIND1 TO WSUP. */
            _.Move(AREA_DE_WORK.WIND1, AREA_DE_WORK.WSUP);

            /*" -3170- MOVE SPACES TO WTEM-SISTEMA-ORIGEM */
            _.Move("", AREA_DE_WORK.WTEM_SISTEMA_ORIGEM);

            /*" -3171- PERFORM UNTIL WTEM-SISTEMA-ORIGEM NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WTEM_SISTEMA_ORIGEM.IsEmpty()))
            {

                /*" -3172- IF WINF > WSUP */

                if (AREA_DE_WORK.WINF > AREA_DE_WORK.WSUP)
                {

                    /*" -3173- MOVE 'NAO' TO WTEM-SISTEMA-ORIGEM */
                    _.Move("NAO", AREA_DE_WORK.WTEM_SISTEMA_ORIGEM);

                    /*" -3174- ELSE */
                }
                else
                {


                    /*" -3175- COMPUTE WINDI = (WSUP + WINF) / 2 */
                    AREA_DE_WORK.WINDI.Value = (AREA_DE_WORK.WSUP + AREA_DE_WORK.WINF) / 2;

                    /*" -3177- IF W-ORIGEM-PROPOSTA < WTAB-SISTEMA-ORIGEM(WINDI) */

                    if (WREA88.W_ORIGEM_PROPOSTA < W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[AREA_DE_WORK.WINDI])
                    {

                        /*" -3178- COMPUTE WSUP = WINDI - 1 */
                        AREA_DE_WORK.WSUP.Value = AREA_DE_WORK.WINDI - 1;

                        /*" -3179- ELSE */
                    }
                    else
                    {


                        /*" -3181- IF W-ORIGEM-PROPOSTA > WTAB-SISTEMA-ORIGEM(WINDI) */

                        if (WREA88.W_ORIGEM_PROPOSTA > W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[AREA_DE_WORK.WINDI])
                        {

                            /*" -3182- COMPUTE WINF = WINDI + 1 */
                            AREA_DE_WORK.WINF.Value = AREA_DE_WORK.WINDI + 1;

                            /*" -3183- ELSE */
                        }
                        else
                        {


                            /*" -3184- MOVE 'SIM' TO WTEM-SISTEMA-ORIGEM */
                            _.Move("SIM", AREA_DE_WORK.WTEM_SISTEMA_ORIGEM);

                            /*" -3185- END-IF */
                        }


                        /*" -3186- END-IF */
                    }


                    /*" -3187- END-IF */
                }


                /*" -3187- END-PERFORM. */
            }

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-INSERT-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_INSERT_3()
        {
            /*" -2699- EXEC SQL INSERT INTO SEGUROS.V0APOLCOB (COD_EMPRESA , FONTE , NUM_APOLICE , NRENDOS , CODPRODU , NUM_MATRICULA , TIPO_COBRANCA , AGECOBR , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , NUM_CARTAO , DIA_DEBITO , NRCERTIF_AUTO , TIMESTAMP , MARGEM_COMERCIAL) VALUES (:V0APCB-COD-EMPRESA , :V0APCB-FONTE , :V0APCB-NUM-APOL , :V0APCB-NRENDOS , :V0APCB-CODPRODU , :V0APCB-NUM-MATR , :V0APCB-TIPOCOB , :V0APCB-AGECOBR , :V0APCB-AGENCIA , :V0APCB-OPE-CONTA , :V0APCB-NUM-CONTA , :V0APCB-DIG-CONTA , :V0APCB-AGENCIA-DEB:VIND-AGENCIA , :V0APCB-OPERACAO-DEB:VIND-OPERACAO , :V0APCB-NUMCTA-DEB:VIND-NUMCONTA , :V0APCB-DIGCTA-DEB:VIND-DIGCONTA , :V0APCB-NUM-CARTAO:VIND-NUMCARTAO , :V0APCB-DIA-DEBITO:VIND-DIADEBITO , :V0APCB-NRCERTIF:VIND-NRCERTIF , CURRENT TIMESTAMP , :V0APCB-MARGEM:VIND-MARGEM) END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_INSERT_3_Insert1 = new R1000_00_PROCESSA_REGISTRO_DB_INSERT_3_Insert1()
            {
                V0APCB_COD_EMPRESA = V0APCB_COD_EMPRESA.ToString(),
                V0APCB_FONTE = V0APCB_FONTE.ToString(),
                V0APCB_NUM_APOL = V0APCB_NUM_APOL.ToString(),
                V0APCB_NRENDOS = V0APCB_NRENDOS.ToString(),
                V0APCB_CODPRODU = V0APCB_CODPRODU.ToString(),
                V0APCB_NUM_MATR = V0APCB_NUM_MATR.ToString(),
                V0APCB_TIPOCOB = V0APCB_TIPOCOB.ToString(),
                V0APCB_AGECOBR = V0APCB_AGECOBR.ToString(),
                V0APCB_AGENCIA = V0APCB_AGENCIA.ToString(),
                V0APCB_OPE_CONTA = V0APCB_OPE_CONTA.ToString(),
                V0APCB_NUM_CONTA = V0APCB_NUM_CONTA.ToString(),
                V0APCB_DIG_CONTA = V0APCB_DIG_CONTA.ToString(),
                V0APCB_AGENCIA_DEB = V0APCB_AGENCIA_DEB.ToString(),
                VIND_AGENCIA = VIND_AGENCIA.ToString(),
                V0APCB_OPERACAO_DEB = V0APCB_OPERACAO_DEB.ToString(),
                VIND_OPERACAO = VIND_OPERACAO.ToString(),
                V0APCB_NUMCTA_DEB = V0APCB_NUMCTA_DEB.ToString(),
                VIND_NUMCONTA = VIND_NUMCONTA.ToString(),
                V0APCB_DIGCTA_DEB = V0APCB_DIGCTA_DEB.ToString(),
                VIND_DIGCONTA = VIND_DIGCONTA.ToString(),
                V0APCB_NUM_CARTAO = V0APCB_NUM_CARTAO.ToString(),
                VIND_NUMCARTAO = VIND_NUMCARTAO.ToString(),
                V0APCB_DIA_DEBITO = V0APCB_DIA_DEBITO.ToString(),
                VIND_DIADEBITO = VIND_DIADEBITO.ToString(),
                V0APCB_NRCERTIF = V0APCB_NRCERTIF.ToString(),
                VIND_NRCERTIF = VIND_NRCERTIF.ToString(),
                V0APCB_MARGEM = V0APCB_MARGEM.ToString(),
                VIND_MARGEM = VIND_MARGEM.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_3_Insert1.Execute(r1000_00_PROCESSA_REGISTRO_DB_INSERT_3_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-6 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_6()
        {
            /*" -2306- EXEC SQL SELECT CODUNIMO, PCCOMCOR, VALMAX_COBERBAS, PCIOCC INTO :V1BILC-CODUNIMO, :V1BILC-PCCOMCOR, :V1BILC-VALMAX, :V1BILC-PCIOCC FROM SEGUROS.V0BILHETE_COBER WHERE RAMOFR = :V1BILC-RAMOFR AND MODALIFR = :V1BILC-MODALIFR AND COD_OPCAO = :V1BILC-OPCAO AND PCCOMCOR > 0 AND IDE_COBERTURA = '1' AND DTINIVIG <= :V0BILH-DTQITBCO AND DTTERVIG >= :V0BILH-DTQITBCO WITH UR END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1()
            {
                V1BILC_MODALIFR = V1BILC_MODALIFR.ToString(),
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V1BILC_RAMOFR = V1BILC_RAMOFR.ToString(),
                V1BILC_OPCAO = V1BILC_OPCAO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILC_CODUNIMO, V1BILC_CODUNIMO);
                _.Move(executed_1.V1BILC_PCCOMCOR, V1BILC_PCCOMCOR);
                _.Move(executed_1.V1BILC_VALMAX, V1BILC_VALMAX);
                _.Move(executed_1.V1BILC_PCIOCC, V1BILC_PCIOCC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-7 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_7()
        {
            /*" -2336- EXEC SQL SELECT PCIOF INTO :V1RIND-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = :V1BILC-RAMOFR AND DTINIVIG <= :V0BILH-DTQITBCO AND DTTERVIG >= :V0BILH-DTQITBCO WITH UR END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1()
            {
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V1BILC_RAMOFR = V1BILC_RAMOFR.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RIND_PCIOF, V1RIND_PCIOF);
            }


        }

        [StopWatch]
        /*" R1030-00-TRATA-FENAE-SECTION */
        private void R1030_00_TRATA_FENAE_SECTION()
        {
            /*" -3202- MOVE '1030' TO WNR-EXEC-SQL. */
            _.Move("1030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3209- MOVE 'S' TO WWORK-FUNDAO. */
            _.Move("S", AREA_DE_WORK.WWORK_FUNDAO);

            /*" -3210- MOVE 24112 TO V0APCR-CODCORR */
            _.Move(24112, V0APCR_CODCORR);

            /*" -3212- MOVE V0APCR-CODCORR TO WS-COD-CORRETOR */
            _.Move(V0APCR_CODCORR, WS_COD_CORRETOR);

            /*" -3217- IF WS-PROD-RUNON AND N88-COD-CORRETOR AND V0APCR-TIPCOM = '1' AND V1SIST-DTMOVACB >= '2021-08-16' AND V0BILH-NUM-APO-ANT = 0 */

            if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"] && WS_COD_CORRETOR["N88_COD_CORRETOR"] && V0APCR_TIPCOM == "1" && V1SIST_DTMOVACB >= "2021-08-16" && V0BILH_NUM_APO_ANT == 0)
            {

                /*" -3218- MOVE 25267 TO V0APCR-CODCORR */
                _.Move(25267, V0APCR_CODCORR);

                /*" -3220- END-IF */
            }


            /*" -3222- MOVE 100 TO V0APCR-PCPARCOR. */
            _.Move(100, V0APCR_PCPARCOR);

            /*" -3225- MOVE 17 TO V0APCR-PCCOMCOR. */
            _.Move(17, V0APCR_PCCOMCOR);

            /*" -3226- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -3227- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -3228- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -3229- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -3230- MOVE WWORK-RAMO-ANT TO V0APCR-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0APCR_RAMOFR);

            /*" -3231- MOVE 0 TO V0APCR-MODALIFR */
            _.Move(0, V0APCR_MODALIFR);

            /*" -3232- MOVE '1' TO V0APCR-TIPCOM */
            _.Move("1", V0APCR_TIPCOM);

            /*" -3233- MOVE '1' TO V0APCR-INDCRT */
            _.Move("1", V0APCR_INDCRT);

            /*" -3235- MOVE ZEROS TO V0APCR-COD-EMPRESA. */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -3238- MOVE 'CB2005B' TO V0APCR-COD-USUARIO. */
            _.Move("CB2005B", V0APCR_COD_USUARIO);

            /*" -3254- PERFORM R1030_00_TRATA_FENAE_DB_INSERT_1 */

            R1030_00_TRATA_FENAE_DB_INSERT_1();

            /*" -3257- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3258- DISPLAY 'R1030-00 (ERRO - INSERT V0APOLCORRET)...' */
                _.Display($"R1030-00 (ERRO - INSERT V0APOLCORRET)...");

                /*" -3261- DISPLAY 'APOLICE: ' V0APCR-NUM-APOL '  ' 'RAMO: ' V0APCR-RAMOFR '  ' 'OPCAO: ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APCR_NUM_APOL}  RAMO: {V0APCR_RAMOFR}  OPCAO: {WWORK_OPCAO_ANT}"
                .Display();

                /*" -3263- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3263- ADD +1 TO AC-I-V0APOLCORRET. */
            AREA_DE_WORK.AC_I_V0APOLCORRET.Value = AREA_DE_WORK.AC_I_V0APOLCORRET + +1;

        }

        [StopWatch]
        /*" R1030-00-TRATA-FENAE-DB-INSERT-1 */
        public void R1030_00_TRATA_FENAE_DB_INSERT_1()
        {
            /*" -3254- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (:V0APCR-NUM-APOL , :V0APCR-RAMOFR , :V0APCR-MODALIFR , :V0APCR-CODCORR , :V0APCR-CODSUBES , :V0APCR-DTINIVIG , :V0APCR-DTTERVIG , :V0APCR-PCPARCOR , :V0APCR-PCCOMCOR , :V0APCR-TIPCOM , :V0APCR-INDCRT , :V0APCR-COD-EMPRESA , CURRENT TIMESTAMP , :V0APCR-COD-USUARIO) END-EXEC. */

            var r1030_00_TRATA_FENAE_DB_INSERT_1_Insert1 = new R1030_00_TRATA_FENAE_DB_INSERT_1_Insert1()
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

            R1030_00_TRATA_FENAE_DB_INSERT_1_Insert1.Execute(r1030_00_TRATA_FENAE_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-8 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_8()
        {
            /*" -2358- EXEC SQL SELECT COD_PRODUTO INTO :V0PROE-CODPRODU FROM SEGUROS.V0PROP_ESTIPULANTE WHERE NUMBIL = :V0BILH-NUMBIL AND FONTE = 0 AND NUM_PROPOSTA = 0 AND COD_FROTA = '0' WITH UR END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROE_CODPRODU, V0PROE_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/

        [StopWatch]
        /*" R1040-PRODUTO-RUNOFF-SECTION */
        private void R1040_PRODUTO_RUNOFF_SECTION()
        {
            /*" -3272- SET WS-IND-PROD TO 1 */
            JVBKINCL.WS_IND_PROD.Value = 1;

            /*" -3274- SEARCH CVPPROD AT END */
            void SearchAtEnd0()
            {

                /*" -3275- SET WS-PROD-RUNON TO TRUE */
                AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"] = true;

                /*" -3276- WHEN CVPPROD(WS-IND-PROD) EQUAL WS-COD-PRODUTO */
            };

            var mustSearchAtEnd0 = true;
            for (; JVBKINCL.WS_IND_PROD < JVBKINCL.CVP_PRODUTO.CVPPROD.Items.Count; JVBKINCL.WS_IND_PROD.Value++)
            {

                if (JVBKINCL.CVP_PRODUTO.CVPPROD[JVBKINCL.WS_IND_PROD] == WS_COD_PRODUTO)
                {

                    mustSearchAtEnd0 = false;

                    /*" -3277- SET WS-PROD-RUNOFF TO TRUE */
                    AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNOFF"] = true;

                    /*" -3279- END-SEARCH */

                    /*" -3279- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1040_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-TRATA-FUNDAO-SECTION */
        private void R1050_00_TRATA_FUNDAO_SECTION()
        {
            /*" -3293- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3300- MOVE 'S' TO WWORK-FUNDAO. */
            _.Move("S", AREA_DE_WORK.WWORK_FUNDAO);

            /*" -3301- MOVE 19224 TO V0APCR-CODCORR */
            _.Move(19224, V0APCR_CODCORR);

            /*" -3303- MOVE 50 TO V0APCR-PCPARCOR. */
            _.Move(50, V0APCR_PCPARCOR);

            /*" -3306- MOVE ZEROS TO AUX-VALBAS AUX-PERCENT. */
            _.Move(0, AREA_DE_WORK.AUX_VALBAS, AREA_DE_WORK.AUX_PERCENT);

            /*" -3309- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100. */
            AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

            /*" -3313- COMPUTE AUX-PERCENT EQUAL (2,74 / AUX-VALBAS) * 100. */
            AREA_DE_WORK.AUX_PERCENT.Value = (2.74 / AREA_DE_WORK.AUX_VALBAS) * 100;

            /*" -3315- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR. */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

            /*" -3316- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -3317- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -3318- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -3319- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -3320- MOVE WWORK-RAMO-ANT TO V0APCR-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0APCR_RAMOFR);

            /*" -3321- MOVE 0 TO V0APCR-MODALIFR */
            _.Move(0, V0APCR_MODALIFR);

            /*" -3322- MOVE '1' TO V0APCR-TIPCOM */
            _.Move("1", V0APCR_TIPCOM);

            /*" -3323- MOVE '2' TO V0APCR-INDCRT */
            _.Move("2", V0APCR_INDCRT);

            /*" -3325- MOVE ZEROS TO V0APCR-COD-EMPRESA. */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -3327- MOVE 'CB2005B' TO V0APCR-COD-USUARIO. */
            _.Move("CB2005B", V0APCR_COD_USUARIO);

            /*" -3330- MOVE '105A' TO WNR-EXEC-SQL. */
            _.Move("105A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3346- PERFORM R1050_00_TRATA_FUNDAO_DB_INSERT_1 */

            R1050_00_TRATA_FUNDAO_DB_INSERT_1();

            /*" -3349- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3350- DISPLAY 'R1077-00 (ERRO - INSERT V0APOLCORRET)...' */
                _.Display($"R1077-00 (ERRO - INSERT V0APOLCORRET)...");

                /*" -3353- DISPLAY 'APOLICE: ' V0APCR-NUM-APOL '  ' 'RAMO: ' V0APCR-RAMOFR '  ' 'OPCAO: ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APCR_NUM_APOL}  RAMO: {V0APCR_RAMOFR}  OPCAO: {WWORK_OPCAO_ANT}"
                .Display();

                /*" -3355- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3363- ADD +1 TO AC-I-V0APOLCORRET. */
            AREA_DE_WORK.AC_I_V0APOLCORRET.Value = AREA_DE_WORK.AC_I_V0APOLCORRET + +1;

            /*" -3364- MOVE 17256 TO V0APCR-CODCORR */
            _.Move(17256, V0APCR_CODCORR);

            /*" -3366- MOVE 50 TO V0APCR-PCPARCOR. */
            _.Move(50, V0APCR_PCPARCOR);

            /*" -3369- MOVE ZEROS TO AUX-VALBAS AUX-PERCENT. */
            _.Move(0, AREA_DE_WORK.AUX_VALBAS, AREA_DE_WORK.AUX_PERCENT);

            /*" -3372- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100. */
            AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

            /*" -3376- COMPUTE AUX-PERCENT EQUAL (3,32 / AUX-VALBAS) * 100. */
            AREA_DE_WORK.AUX_PERCENT.Value = (3.32 / AREA_DE_WORK.AUX_VALBAS) * 100;

            /*" -3391- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR. */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

            /*" -3392- IF V0BILH-DTQITBCO GREATER '2000-09-30' */

            if (V0BILH_DTQITBCO > "2000-09-30")
            {

                /*" -3402- MOVE 1 TO V0APCR-PCCOMCOR. */
                _.Move(1, V0APCR_PCCOMCOR);
            }


            /*" -3403- IF V0BILH-DTQITBCO GREATER '2003-11-30' */

            if (V0BILH_DTQITBCO > "2003-11-30")
            {

                /*" -3406- PERFORM R1060-00-TRATA-FENAE. */

                R1060_00_TRATA_FENAE_SECTION();
            }


            /*" -3407- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -3408- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -3409- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -3410- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -3411- MOVE WWORK-RAMO-ANT TO V0APCR-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0APCR_RAMOFR);

            /*" -3412- MOVE 0 TO V0APCR-MODALIFR */
            _.Move(0, V0APCR_MODALIFR);

            /*" -3413- MOVE '1' TO V0APCR-TIPCOM */
            _.Move("1", V0APCR_TIPCOM);

            /*" -3414- MOVE '1' TO V0APCR-INDCRT */
            _.Move("1", V0APCR_INDCRT);

            /*" -3416- MOVE ZEROS TO V0APCR-COD-EMPRESA. */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -3418- MOVE 'CB2005B' TO V0APCR-COD-USUARIO. */
            _.Move("CB2005B", V0APCR_COD_USUARIO);

            /*" -3421- MOVE '105B' TO WNR-EXEC-SQL. */
            _.Move("105B", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3437- PERFORM R1050_00_TRATA_FUNDAO_DB_INSERT_2 */

            R1050_00_TRATA_FUNDAO_DB_INSERT_2();

            /*" -3440- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3441- DISPLAY 'R1077-00 (ERRO - INSERT V0APOLCORRET)...' */
                _.Display($"R1077-00 (ERRO - INSERT V0APOLCORRET)...");

                /*" -3444- DISPLAY 'APOLICE: ' V0APCR-NUM-APOL '  ' 'RAMO: ' V0APCR-RAMOFR '  ' 'OPCAO: ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APCR_NUM_APOL}  RAMO: {V0APCR_RAMOFR}  OPCAO: {WWORK_OPCAO_ANT}"
                .Display();

                /*" -3446- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3446- ADD +1 TO AC-I-V0APOLCORRET. */
            AREA_DE_WORK.AC_I_V0APOLCORRET.Value = AREA_DE_WORK.AC_I_V0APOLCORRET + +1;

        }

        [StopWatch]
        /*" R1050-00-TRATA-FUNDAO-DB-INSERT-1 */
        public void R1050_00_TRATA_FUNDAO_DB_INSERT_1()
        {
            /*" -3346- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (:V0APCR-NUM-APOL , :V0APCR-RAMOFR , :V0APCR-MODALIFR , :V0APCR-CODCORR , :V0APCR-CODSUBES , :V0APCR-DTINIVIG , :V0APCR-DTTERVIG , :V0APCR-PCPARCOR , :V0APCR-PCCOMCOR , :V0APCR-TIPCOM , :V0APCR-INDCRT , :V0APCR-COD-EMPRESA , CURRENT TIMESTAMP , :V0APCR-COD-USUARIO) END-EXEC. */

            var r1050_00_TRATA_FUNDAO_DB_INSERT_1_Insert1 = new R1050_00_TRATA_FUNDAO_DB_INSERT_1_Insert1()
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

            R1050_00_TRATA_FUNDAO_DB_INSERT_1_Insert1.Execute(r1050_00_TRATA_FUNDAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-TRATA-FUNDAO-DB-INSERT-2 */
        public void R1050_00_TRATA_FUNDAO_DB_INSERT_2()
        {
            /*" -3437- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (:V0APCR-NUM-APOL , :V0APCR-RAMOFR , :V0APCR-MODALIFR , :V0APCR-CODCORR , :V0APCR-CODSUBES , :V0APCR-DTINIVIG , :V0APCR-DTTERVIG , :V0APCR-PCPARCOR , :V0APCR-PCCOMCOR , :V0APCR-TIPCOM , :V0APCR-INDCRT , :V0APCR-COD-EMPRESA , CURRENT TIMESTAMP , :V0APCR-COD-USUARIO) END-EXEC. */

            var r1050_00_TRATA_FUNDAO_DB_INSERT_2_Insert1 = new R1050_00_TRATA_FUNDAO_DB_INSERT_2_Insert1()
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

            R1050_00_TRATA_FUNDAO_DB_INSERT_2_Insert1.Execute(r1050_00_TRATA_FUNDAO_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1051-00-TRATA-FUNDAO-01-SECTION */
        private void R1051_00_TRATA_FUNDAO_01_SECTION()
        {
            /*" -3462- MOVE '1051' TO WNR-EXEC-SQL. */
            _.Move("1051", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3464- MOVE 'S' TO WWORK-FUNDAO. */
            _.Move("S", AREA_DE_WORK.WWORK_FUNDAO);

            /*" -3465- MOVE 25267 TO V0APCR-CODCORR */
            _.Move(25267, V0APCR_CODCORR);

            /*" -3467- MOVE 50 TO V0APCR-PCPARCOR. */
            _.Move(50, V0APCR_PCPARCOR);

            /*" -3470- MOVE ZEROS TO AUX-VALBAS AUX-PERCENT. */
            _.Move(0, AREA_DE_WORK.AUX_VALBAS, AREA_DE_WORK.AUX_PERCENT);

            /*" -3473- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100. */
            AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

            /*" -3477- COMPUTE AUX-PERCENT EQUAL (6,06 / AUX-VALBAS) * 100. */
            AREA_DE_WORK.AUX_PERCENT.Value = (6.06 / AREA_DE_WORK.AUX_VALBAS) * 100;

            /*" -3478- IF V0BILH-DTQITBCO GREATER '2000-09-30' */

            if (V0BILH_DTQITBCO > "2000-09-30")
            {

                /*" -3480- MOVE 1 TO V0APCR-PCCOMCOR. */
                _.Move(1, V0APCR_PCCOMCOR);
            }


            /*" -3481- IF V0BILH-DTQITBCO GREATER '2003-11-30' */

            if (V0BILH_DTQITBCO > "2003-11-30")
            {

                /*" -3485- COMPUTE AUX-PERCENT EQUAL (4,74 / AUX-VALBAS) * 100. */
                AREA_DE_WORK.AUX_PERCENT.Value = (4.74 / AREA_DE_WORK.AUX_VALBAS) * 100;
            }


            /*" -3487- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR. */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

            /*" -3488- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -3489- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -3490- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -3491- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -3492- MOVE WWORK-RAMO-ANT TO V0APCR-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0APCR_RAMOFR);

            /*" -3493- MOVE 0 TO V0APCR-MODALIFR */
            _.Move(0, V0APCR_MODALIFR);

            /*" -3494- MOVE '1' TO V0APCR-TIPCOM */
            _.Move("1", V0APCR_TIPCOM);

            /*" -3495- MOVE '1' TO V0APCR-INDCRT */
            _.Move("1", V0APCR_INDCRT);

            /*" -3497- MOVE ZEROS TO V0APCR-COD-EMPRESA. */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -3499- MOVE 'CB2005B' TO V0APCR-COD-USUARIO. */
            _.Move("CB2005B", V0APCR_COD_USUARIO);

            /*" -3515- PERFORM R1051_00_TRATA_FUNDAO_01_DB_INSERT_1 */

            R1051_00_TRATA_FUNDAO_01_DB_INSERT_1();

            /*" -3518- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3519- DISPLAY 'R1051-00 (ERRO - INSERT V0APOLCORRET)...' */
                _.Display($"R1051-00 (ERRO - INSERT V0APOLCORRET)...");

                /*" -3522- DISPLAY 'APOLICE: ' V0APCR-NUM-APOL '  ' 'RAMO: ' V0APCR-RAMOFR '  ' 'OPCAO: ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APCR_NUM_APOL}  RAMO: {V0APCR_RAMOFR}  OPCAO: {WWORK_OPCAO_ANT}"
                .Display();

                /*" -3524- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3525- ADD +1 TO AC-I-V0APOLCORRET. */
            AREA_DE_WORK.AC_I_V0APOLCORRET.Value = AREA_DE_WORK.AC_I_V0APOLCORRET + +1;

        }

        [StopWatch]
        /*" R1051-00-TRATA-FUNDAO-01-DB-INSERT-1 */
        public void R1051_00_TRATA_FUNDAO_01_DB_INSERT_1()
        {
            /*" -3515- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (:V0APCR-NUM-APOL , :V0APCR-RAMOFR , :V0APCR-MODALIFR , :V0APCR-CODCORR , :V0APCR-CODSUBES , :V0APCR-DTINIVIG , :V0APCR-DTTERVIG , :V0APCR-PCPARCOR , :V0APCR-PCCOMCOR , :V0APCR-TIPCOM , :V0APCR-INDCRT , :V0APCR-COD-EMPRESA , CURRENT TIMESTAMP , :V0APCR-COD-USUARIO) END-EXEC. */

            var r1051_00_TRATA_FUNDAO_01_DB_INSERT_1_Insert1 = new R1051_00_TRATA_FUNDAO_01_DB_INSERT_1_Insert1()
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

            R1051_00_TRATA_FUNDAO_01_DB_INSERT_1_Insert1.Execute(r1051_00_TRATA_FUNDAO_01_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1051_99_SAIDA*/

        [StopWatch]
        /*" R1060-00-TRATA-FENAE-SECTION */
        private void R1060_00_TRATA_FENAE_SECTION()
        {
            /*" -3543- MOVE '1060' TO WNR-EXEC-SQL. */
            _.Move("1060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3544- MOVE 17256 TO V0APCR-CODCORR */
            _.Move(17256, V0APCR_CODCORR);

            /*" -3546- MOVE 50 TO V0APCR-PCPARCOR. */
            _.Move(50, V0APCR_PCPARCOR);

            /*" -3549- MOVE ZEROS TO AUX-VALBAS AUX-PERCENT. */
            _.Move(0, AREA_DE_WORK.AUX_VALBAS, AREA_DE_WORK.AUX_PERCENT);

            /*" -3552- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100. */
            AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

            /*" -3556- COMPUTE AUX-PERCENT EQUAL (2,02 / AUX-VALBAS) * 100. */
            AREA_DE_WORK.AUX_PERCENT.Value = (2.02 / AREA_DE_WORK.AUX_VALBAS) * 100;

            /*" -3556- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR. */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_99_SAIDA*/

        [StopWatch]
        /*" R1080-00-GRAVA-V0APOLCOSCED-SECTION */
        private void R1080_00_GRAVA_V0APOLCOSCED_SECTION()
        {
            /*" -3570- MOVE '1080' TO WNR-EXEC-SQL. */
            _.Move("1080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3589- PERFORM R1080_00_GRAVA_V0APOLCOSCED_DB_DECLARE_1 */

            R1080_00_GRAVA_V0APOLCOSCED_DB_DECLARE_1();

            /*" -3591- PERFORM R1080_00_GRAVA_V0APOLCOSCED_DB_OPEN_1 */

            R1080_00_GRAVA_V0APOLCOSCED_DB_OPEN_1();

            /*" -3594- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3595- DISPLAY 'R1080-00 (ERRO OPEN CURSOR V1COSSEGPROD)...' */
                _.Display($"R1080-00 (ERRO OPEN CURSOR V1COSSEGPROD)...");

                /*" -3599- DISPLAY 'PRODUTO: ' V1BILP-CODPRODU '  ' 'RAMO: ' WWORK-RAMO-ANT ' ' 'OPCA: ' WWORK-OPCAO-ANT ' ' 'INIVIG: ' V0ENDO-DTINIVIG */

                $"PRODUTO: {V1BILP_CODPRODU}  RAMO: {WWORK_RAMO_ANT} OPCA: {WWORK_OPCAO_ANT} INIVIG: {V0ENDO_DTINIVIG}"
                .Display();

                /*" -3601- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3602- MOVE 0 TO WACC-PCTCED WACC-QTCOSSEG. */
            _.Move(0, AREA_DE_WORK.WACC_PCTCED, AREA_DE_WORK.WACC_QTCOSSEG);

            /*" -0- FLUXCONTROL_PERFORM R1080_10_FETCH_V1COSSEGPROD */

            R1080_10_FETCH_V1COSSEGPROD();

        }

        [StopWatch]
        /*" R1080-00-GRAVA-V0APOLCOSCED-DB-OPEN-1 */
        public void R1080_00_GRAVA_V0APOLCOSCED_DB_OPEN_1()
        {
            /*" -3591- EXEC SQL OPEN V1COSSEGPROD END-EXEC. */

            V1COSSEGPROD.Open();

        }

        [StopWatch]
        /*" R3200-10-DECLARE-V0RCAPCOMP-DB-DECLARE-1 */
        public void R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1()
        {
            /*" -5561- EXEC SQL DECLARE V1RCAPCOMP CURSOR FOR SELECT FONTE , NRRCAP , NRRCAPCO , OPERACAO , DTMOVTO , HORAOPER , SITUACAO , BCOAVISO , AGEAVISO , NRAVISO , VLRCAP , DATARCAP , DTCADAST , SITCONTB FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP WITH UR END-EXEC. */
            V1RCAPCOMP = new CB2005B_V1RCAPCOMP(true);
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
            /*" -3609- MOVE '1081' TO WNR-EXEC-SQL. */
            _.Move("1081", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3619- PERFORM R1080_10_FETCH_V1COSSEGPROD_DB_FETCH_1 */

            R1080_10_FETCH_V1COSSEGPROD_DB_FETCH_1();

            /*" -3622- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3638- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3638- PERFORM R1080_10_FETCH_V1COSSEGPROD_DB_CLOSE_1 */

                    R1080_10_FETCH_V1COSSEGPROD_DB_CLOSE_1();

                    /*" -3640- GO TO R1080-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1080_99_SAIDA*/ //GOTO
                    return;

                    /*" -3641- ELSE */
                }
                else
                {


                    /*" -3642- DISPLAY 'R1080-10 (ERRO - FETCH V1COSSEGPROD)...' */
                    _.Display($"R1080-10 (ERRO - FETCH V1COSSEGPROD)...");

                    /*" -3646- DISPLAY 'PRODUTO: ' V1BILP-CODPRODU '  ' 'RAMO: ' WWORK-RAMO-ANT ' ' 'OPCA: ' WWORK-OPCAO-ANT ' ' 'INIVIG: ' V0ENDO-DTINIVIG */

                    $"PRODUTO: {V1BILP_CODPRODU}  RAMO: {WWORK_RAMO_ANT} OPCA: {WWORK_OPCAO_ANT} INIVIG: {V0ENDO_DTINIVIG}"
                    .Display();

                    /*" -3648- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3649- MOVE V1COSP-CONGENER TO V0APCC-CODCOSS */
            _.Move(V1COSP_CONGENER, V0APCC_CODCOSS);

            /*" -3650- MOVE V0APOL-NUM-APOL TO V0APCC-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCC_NUM_APOL);

            /*" -3651- MOVE WWORK-RAMO-ANT TO V0APCC-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V0APCC_RAMOFR);

            /*" -3652- MOVE V0ENDO-DTINIVIG TO V0APCC-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCC_DTINIVIG);

            /*" -3653- MOVE V0ENDO-DTTERVIG TO V0APCC-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCC_DTTERVIG);

            /*" -3654- MOVE V1COSP-PCPARTIC TO V0APCC-PCPARTIC */
            _.Move(V1COSP_PCPARTIC, V0APCC_PCPARTIC);

            /*" -3655- MOVE V1COSP-PCCOMCOS TO V0APCC-PCCOMCOS */
            _.Move(V1COSP_PCCOMCOS, V0APCC_PCCOMCOS);

            /*" -3657- MOVE ZEROS TO V0APCC-COD-EMPRESA */
            _.Move(0, V0APCC_COD_EMPRESA);

            /*" -3658- ADD V1COSP-PCPARTIC TO WACC-PCTCED */
            AREA_DE_WORK.WACC_PCTCED.Value = AREA_DE_WORK.WACC_PCTCED + V1COSP_PCPARTIC;

            /*" -3660- ADD 1 TO WACC-QTCOSSEG. */
            AREA_DE_WORK.WACC_QTCOSSEG.Value = AREA_DE_WORK.WACC_QTCOSSEG + 1;

            /*" -3662- PERFORM R1082-00-INSERT-V0APOLCOSCED. */

            R1082_00_INSERT_V0APOLCOSCED_SECTION();

            /*" -3662- GO TO R1080-10-FETCH-V1COSSEGPROD. */
            new Task(() => R1080_10_FETCH_V1COSSEGPROD()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1080-10-FETCH-V1COSSEGPROD-DB-FETCH-1 */
        public void R1080_10_FETCH_V1COSSEGPROD_DB_FETCH_1()
        {
            /*" -3619- EXEC SQL FETCH V1COSSEGPROD INTO :V1COSP-CODPRODU , :V1COSP-RAMO , :V1COSP-CONGENER , :V1COSP-PCPARTIC , :V1COSP-PCCOMCOS , :V1COSP-PCADMCOS , :V1COSP-DTINIVIG , :V1COSP-DTTERVIG , :V1COSP-SITUACAO END-EXEC. */

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
            /*" -3638- EXEC SQL CLOSE V1COSSEGPROD END-EXEC */

            V1COSSEGPROD.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1080_99_SAIDA*/

        [StopWatch]
        /*" R1082-00-INSERT-V0APOLCOSCED-SECTION */
        private void R1082_00_INSERT_V0APOLCOSCED_SECTION()
        {
            /*" -3675- MOVE '1082' TO WNR-EXEC-SQL. */
            _.Move("1082", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3686- PERFORM R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1 */

            R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1();

            /*" -3689- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3690- DISPLAY 'R1082-00 (ERRO INSERT V0APOLCOSCED)...' */
                _.Display($"R1082-00 (ERRO INSERT V0APOLCOSCED)...");

                /*" -3693- DISPLAY 'APOLICE: ' V0APCC-NUM-APOL '  ' 'CODCOSS: ' V0APCC-CODCOSS '  ' 'RAMO: ' V0APCC-RAMOFR */

                $"APOLICE: {V0APCC_NUM_APOL}  CODCOSS: {V0APCC_CODCOSS}  RAMO: {V0APCC_RAMOFR}"
                .Display();

                /*" -3695- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3697- ADD +1 TO AC-I-V0APOLCOSCED. */
            AREA_DE_WORK.AC_I_V0APOLCOSCED.Value = AREA_DE_WORK.AC_I_V0APOLCOSCED + +1;

            /*" -3697- PERFORM R1083-00-INSERT-V0ORDECOSCED. */

            R1083_00_INSERT_V0ORDECOSCED_SECTION();

        }

        [StopWatch]
        /*" R1082-00-INSERT-V0APOLCOSCED-DB-INSERT-1 */
        public void R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1()
        {
            /*" -3686- EXEC SQL INSERT INTO SEGUROS.V0APOLCOSCED VALUES (:V0APCC-NUM-APOL , :V0APCC-CODCOSS , :V0APCC-RAMOFR , :V0APCC-DTINIVIG , :V0APCC-DTTERVIG , :V0APCC-PCPARTIC , :V0APCC-PCCOMCOS , :V0APCC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -3709- MOVE '1083' TO WNR-EXEC-SQL. */
            _.Move("1083", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3710- MOVE ZEROS TO V0ORDC-COD-EMPRESA. */
            _.Move(0, V0ORDC_COD_EMPRESA);

            /*" -3711- MOVE V0APCC-NUM-APOL TO V0ORDC-NUM-APOL */
            _.Move(V0APCC_NUM_APOL, V0ORDC_NUM_APOL);

            /*" -3712- MOVE 0 TO V0ORDC-NRENDOS */
            _.Move(0, V0ORDC_NRENDOS);

            /*" -3715- MOVE V0APCC-CODCOSS TO V0ORDC-CODCOSS WWORK-ORD-CONGE. */
            _.Move(V0APCC_CODCOSS, V0ORDC_CODCOSS);
            _.Move(V0APCC_CODCOSS, AREA_DE_WORK.FILLER_3.WWORK_ORD_CONGE);


            /*" -3717- MOVE WH-JV1-COD-ORGAO TO WWORK-ORD-ORGAO. */
            _.Move(WORK_JV1.WH_JV1_COD_ORGAO, AREA_DE_WORK.FILLER_3.WWORK_ORD_ORGAO);

            /*" -3719- MOVE V0APCC-CODCOSS TO V1NCOS-CONGENER */
            _.Move(V0APCC_CODCOSS, V1NCOS_CONGENER);

            /*" -3721- MOVE WH-JV1-COD-ORGAO TO V1NCOS-ORGAO. */
            _.Move(WORK_JV1.WH_JV1_COD_ORGAO, V1NCOS_ORGAO);

            /*" -3727- PERFORM R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1 */

            R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1();

            /*" -3730- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3731- DISPLAY 'R1083-00 (ERRO - SELECT V1NUMERO_COSSEGURO)...' */
                _.Display($"R1083-00 (ERRO - SELECT V1NUMERO_COSSEGURO)...");

                /*" -3734- DISPLAY 'ORGAO: ' V1NCOS-ORGAO '  ' 'CONGENER: ' V1NCOS-CONGENER '  ' 'BILHETE : ' V0BILH-NUMBIL */

                $"ORGAO: {V1NCOS_ORGAO}  CONGENER: {V1NCOS_CONGENER}  BILHETE : {V0BILH_NUMBIL}"
                .Display();

                /*" -3736- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3739- MOVE '1084' TO WNR-EXEC-SQL. */
            _.Move("1084", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3741- COMPUTE V1NCOS-NRORDEM = V1NCOS-NRORDEM + 1. */
            V1NCOS_NRORDEM.Value = V1NCOS_NRORDEM + 1;

            /*" -3743- MOVE V1NCOS-NRORDEM TO WWORK-ORD-SEQUE. */
            _.Move(V1NCOS_NRORDEM, AREA_DE_WORK.FILLER_3.WWORK_ORD_SEQUE);

            /*" -3745- MOVE WWORK-NUM-ORDEM TO V0ORDC-ORDEM-CED. */
            _.Move(AREA_DE_WORK.WWORK_NUM_ORDEM, V0ORDC_ORDEM_CED);

            /*" -3753- PERFORM R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1 */

            R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1();

            /*" -3756- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3757- DISPLAY 'R1084-00 (ERRO - INSERT V0ORDECOSCED)...' */
                _.Display($"R1084-00 (ERRO - INSERT V0ORDECOSCED)...");

                /*" -3761- DISPLAY 'APOLICE: ' V0ORDC-NUM-APOL '  ' 'ENDOSSO: ' V0ORDC-NRENDOS '  ' 'CODCOSS: ' V0ORDC-CODCOSS '  ' 'NRORDEM: ' V0ORDC-ORDEM-CED */

                $"APOLICE: {V0ORDC_NUM_APOL}  ENDOSSO: {V0ORDC_NRENDOS}  CODCOSS: {V0ORDC_CODCOSS}  NRORDEM: {V0ORDC_ORDEM_CED}"
                .Display();

                /*" -3762- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -3764- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3766- ADD +1 TO AC-I-V0ORDECOSCED. */
            AREA_DE_WORK.AC_I_V0ORDECOSCED.Value = AREA_DE_WORK.AC_I_V0ORDECOSCED + +1;

            /*" -3769- MOVE '1085' TO WNR-EXEC-SQL. */
            _.Move("1085", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3771- MOVE V0APCC-CODCOSS TO V1NCOS-CONGENER */
            _.Move(V0APCC_CODCOSS, V1NCOS_CONGENER);

            /*" -3774- MOVE WH-JV1-COD-ORGAO TO V1NCOS-ORGAO. */
            _.Move(WORK_JV1.WH_JV1_COD_ORGAO, V1NCOS_ORGAO);

            /*" -3780- PERFORM R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1 */

            R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1();

            /*" -3783- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3784- DISPLAY 'R1085-00 (ERRO - UPDATE V0NUMERO_COSSEGURO)...' */
                _.Display($"R1085-00 (ERRO - UPDATE V0NUMERO_COSSEGURO)...");

                /*" -3787- DISPLAY 'ORGAO: ' V1NCOS-ORGAO '  ' 'CONGENER: ' V1NCOS-CONGENER '  ' 'BILHETE : ' V0BILH-NUMBIL */

                $"ORGAO: {V1NCOS_ORGAO}  CONGENER: {V1NCOS_CONGENER}  BILHETE : {V0BILH_NUMBIL}"
                .Display();

                /*" -3789- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3789- ADD +1 TO AC-U-V0NUMERO-COSSEGURO. */
            AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO.Value = AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO + +1;

        }

        [StopWatch]
        /*" R1083-00-INSERT-V0ORDECOSCED-DB-SELECT-1 */
        public void R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1()
        {
            /*" -3727- EXEC SQL SELECT NRORDEM INTO :V1NCOS-NRORDEM FROM SEGUROS.V1NUMERO_COSSEGURO WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

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
            /*" -3753- EXEC SQL INSERT INTO SEGUROS.V0ORDECOSCED VALUES (:V0ORDC-NUM-APOL , :V0ORDC-NRENDOS , :V0ORDC-CODCOSS , :V0ORDC-ORDEM-CED , :V0ORDC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -3780- EXEC SQL UPDATE SEGUROS.V0NUMERO_COSSEGURO SET NRORDEM = :V1NCOS-NRORDEM , TIMESTAMP = CURRENT TIMESTAMP WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

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
            /*" -3801- MOVE '1090' TO WNR-EXEC-SQL. */
            _.Move("1090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3802- MOVE WACC-QTCOSSEG TO V0APOL-QTCOSSEG */
            _.Move(AREA_DE_WORK.WACC_QTCOSSEG, V0APOL_QTCOSSEG);

            /*" -3804- MOVE WACC-PCTCED TO V0APOL-PCTCED. */
            _.Move(AREA_DE_WORK.WACC_PCTCED, V0APOL_PCTCED);

            /*" -3809- PERFORM R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1 */

            R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1();

            /*" -3812- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3813- DISPLAY 'R1090-00 (ERRO - UPDATE V0APOLICE)...' */
                _.Display($"R1090-00 (ERRO - UPDATE V0APOLICE)...");

                /*" -3814- DISPLAY 'APOLICE: ' V0APOL-NUM-APOL */
                _.Display($"APOLICE: {V0APOL_NUM_APOL}");

                /*" -3816- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3816- ADD +1 TO AC-U-V0APOLICE. */
            AREA_DE_WORK.AC_U_V0APOLICE.Value = AREA_DE_WORK.AC_U_V0APOLICE + +1;

        }

        [StopWatch]
        /*" R1090-00-UPDATE-V0APOLICE-DB-UPDATE-1 */
        public void R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1()
        {
            /*" -3809- EXEC SQL UPDATE SEGUROS.V0APOLICE SET QTCOSSEG = :V0APOL-QTCOSSEG , PCTCED = :V0APOL-PCTCED WHERE NUM_APOLICE = :V0APOL-NUM-APOL END-EXEC. */

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
        /*" R1100-00-SELECT-CLIENTE-SECTION */
        private void R1100_00_SELECT_CLIENTE_SECTION()
        {
            /*" -3828- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3836- PERFORM R1100_00_SELECT_CLIENTE_DB_SELECT_1 */

            R1100_00_SELECT_CLIENTE_DB_SELECT_1();

            /*" -3839- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3840- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3842- DISPLAY 'R1100 - REGISTRO NAO ENCONTRADO V0CLIENTE' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN */

                    $"R1100 - REGISTRO NAO ENCONTRADO V0CLIENTE{V0BILH_NUMBIL} {V0BILH_CODCLIEN}"
                    .Display();

                    /*" -3843- GO TO R1100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                    return;

                    /*" -3844- ELSE */
                }
                else
                {


                    /*" -3845- DISPLAY 'R1100 - ERRO SELECT V0CLIENTE ' SQLCODE */
                    _.Display($"R1100 - ERRO SELECT V0CLIENTE {DB.SQLCODE}");

                    /*" -3846- DISPLAY 'NUMBIL = ' V0BILH-NUMBIL */
                    _.Display($"NUMBIL = {V0BILH_NUMBIL}");

                    /*" -3847- DISPLAY 'CODCLI = ' V0BILH-CODCLIEN */
                    _.Display($"CODCLI = {V0BILH_CODCLIEN}");

                    /*" -3847- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-CLIENTE-DB-SELECT-1 */
        public void R1100_00_SELECT_CLIENTE_DB_SELECT_1()
        {
            /*" -3836- EXEC SQL SELECT CGCCPF, DATA_NASCIMENTO INTO :V0CLIE-CGCCPF, :V0CLIE-DTNASC:VIND-DTNASC FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0BILH-CODCLIEN WITH UR END-EXEC. */

            var r1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1 = new R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1()
            {
                V0BILH_CODCLIEN = V0BILH_CODCLIEN.ToString(),
            };

            var executed_1 = R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIE_CGCCPF, V0CLIE_CGCCPF);
                _.Move(executed_1.V0CLIE_DTNASC, V0CLIE_DTNASC);
                _.Move(executed_1.VIND_DTNASC, VIND_DTNASC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-GELIMRISCO-SECTION */
        private void R1200_00_SELECT_GELIMRISCO_SECTION()
        {
            /*" -3858- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3860- MOVE 'SIM' TO WTEM-GELMR. */
            _.Move("SIM", AREA_DE_WORK.WTEM_GELMR);

            /*" -3867- PERFORM R1200_00_SELECT_GELIMRISCO_DB_SELECT_1 */

            R1200_00_SELECT_GELIMRISCO_DB_SELECT_1();

            /*" -3870- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3871- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3872- MOVE 'NAO' TO WTEM-GELMR */
                    _.Move("NAO", AREA_DE_WORK.WTEM_GELMR);

                    /*" -3874- MOVE ZEROES TO GELMR-QTD-SEGUROS GELMR-VLR-SOMA-IS */
                    _.Move(0, GELMR_QTD_SEGUROS, GELMR_VLR_SOMA_IS);

                    /*" -3875- ELSE */
                }
                else
                {


                    /*" -3877- DISPLAY 'R1200 - ERRO SELECT GE_LIMITE_DE_RISCO..' SQLCODE */
                    _.Display($"R1200 - ERRO SELECT GE_LIMITE_DE_RISCO..{DB.SQLCODE}");

                    /*" -3878- DISPLAY 'NUMBIL = ' V0BILH-NUMBIL */
                    _.Display($"NUMBIL = {V0BILH_NUMBIL}");

                    /*" -3879- DISPLAY 'CODCLI = ' V0BILH-CODCLIEN */
                    _.Display($"CODCLI = {V0BILH_CODCLIEN}");

                    /*" -3880- DISPLAY 'CGCCPF = ' V0CLIE-CGCCPF */
                    _.Display($"CGCCPF = {V0CLIE_CGCCPF}");

                    /*" -3880- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-GELIMRISCO-DB-SELECT-1 */
        public void R1200_00_SELECT_GELIMRISCO_DB_SELECT_1()
        {
            /*" -3867- EXEC SQL SELECT VALUE(QTD_SEGUROS, 0), VALUE(VLR_SOMA_IS, 0) INTO :GELMR-QTD-SEGUROS, :GELMR-VLR-SOMA-IS FROM SEGUROS.GE_LIMITE_DE_RISCO WHERE CGCCPF = :V0CLIE-CGCCPF END-EXEC. */

            var r1200_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1 = new R1200_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1()
            {
                V0CLIE_CGCCPF = V0CLIE_CGCCPF.ToString(),
            };

            var executed_1 = R1200_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GELMR_QTD_SEGUROS, GELMR_QTD_SEGUROS);
                _.Move(executed_1.GELMR_VLR_SOMA_IS, GELMR_VLR_SOMA_IS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-BIL-COBER-SECTION */
        private void R1300_00_SELECT_BIL_COBER_SECTION()
        {
            /*" -3892- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3902- PERFORM R1300_00_SELECT_BIL_COBER_DB_SELECT_1 */

            R1300_00_SELECT_BIL_COBER_DB_SELECT_1();

            /*" -3905- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3906- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3907- MOVE ZEROES TO V1BILC-IMPSEG-IX */
                    _.Move(0, V1BILC_IMPSEG_IX);

                    /*" -3908- ELSE */
                }
                else
                {


                    /*" -3909- DISPLAY 'R1300 - ERRO SELECT BILHETE_COBER' SQLCODE */
                    _.Display($"R1300 - ERRO SELECT BILHETE_COBER{DB.SQLCODE}");

                    /*" -3910- DISPLAY 'NUMBIL = ' V0BILH-NUMBIL */
                    _.Display($"NUMBIL = {V0BILH_NUMBIL}");

                    /*" -3911- DISPLAY 'CODCLI = ' V0BILH-CODCLIEN */
                    _.Display($"CODCLI = {V0BILH_CODCLIEN}");

                    /*" -3912- DISPLAY 'CGCCPF = ' V0CLIE-CGCCPF */
                    _.Display($"CGCCPF = {V0CLIE_CGCCPF}");

                    /*" -3912- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-BIL-COBER-DB-SELECT-1 */
        public void R1300_00_SELECT_BIL_COBER_DB_SELECT_1()
        {
            /*" -3902- EXEC SQL SELECT VALUE(VAL_COBERTURA_IX, 0) INTO :V1BILC-IMPSEG-IX FROM SEGUROS.V0BILHETE_COBER WHERE RAMOFR = :V0BILH-RAMO AND MODALIFR = 0 AND COD_OPCAO = :V0BILH-OPCAO-COBER AND DTINIVIG <= :V0BILH-DTQITBCO AND DTTERVIG >= :V0BILH-DTQITBCO WITH UR END-EXEC. */

            var r1300_00_SELECT_BIL_COBER_DB_SELECT_1_Query1 = new R1300_00_SELECT_BIL_COBER_DB_SELECT_1_Query1()
            {
                V0BILH_OPCAO_COBER = V0BILH_OPCAO_COBER.ToString(),
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
            };

            var executed_1 = R1300_00_SELECT_BIL_COBER_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_BIL_COBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILC_IMPSEG_IX, V1BILC_IMPSEG_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-UPDATE-GELIMRISCO-SECTION */
        private void R1400_00_UPDATE_GELIMRISCO_SECTION()
        {
            /*" -3924- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3931- PERFORM R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1 */

            R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1();

            /*" -3934- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3936- DISPLAY 'R1400 - ERRO UPDATE GE_LIMITE_DE_RISCO..' SQLCODE */
                _.Display($"R1400 - ERRO UPDATE GE_LIMITE_DE_RISCO..{DB.SQLCODE}");

                /*" -3937- DISPLAY 'NUMBIL = ' V0BILH-NUMBIL */
                _.Display($"NUMBIL = {V0BILH_NUMBIL}");

                /*" -3938- DISPLAY 'CODCLI = ' V0BILH-CODCLIEN */
                _.Display($"CODCLI = {V0BILH_CODCLIEN}");

                /*" -3939- DISPLAY 'CGCCPF = ' V0CLIE-CGCCPF */
                _.Display($"CGCCPF = {V0CLIE_CGCCPF}");

                /*" -3941- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3941- ADD +1 TO AC-U-GELMR. */
            AREA_DE_WORK.AC_U_GELMR.Value = AREA_DE_WORK.AC_U_GELMR + +1;

        }

        [StopWatch]
        /*" R1400-00-UPDATE-GELIMRISCO-DB-UPDATE-1 */
        public void R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1()
        {
            /*" -3931- EXEC SQL UPDATE SEGUROS.GE_LIMITE_DE_RISCO SET QTD_SEGUROS = :GELMR-QTD-SEGUROS, VLR_SOMA_IS = :GELMR-VLR-SOMA-IS, COD_USUARIO = 'CB2005B' , DTH_TIMESTAMP = CURRENT TIMESTAMP WHERE CGCCPF = :V0CLIE-CGCCPF END-EXEC. */

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
            /*" -3953- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3962- PERFORM R1500_00_INSERT_GELIMRISCO_DB_INSERT_1 */

            R1500_00_INSERT_GELIMRISCO_DB_INSERT_1();

            /*" -3965- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3967- DISPLAY 'R1500 - ERRO INSERT GE_LIMITE_DE_RISCO..' SQLCODE */
                _.Display($"R1500 - ERRO INSERT GE_LIMITE_DE_RISCO..{DB.SQLCODE}");

                /*" -3970- DISPLAY 'CGCCPF ' V0CLIE-CGCCPF '  ' 'NUMBIL ' V0BILH-NUMBIL '  ' 'CODCLI ' V0BILH-CODCLIEN */

                $"CGCCPF {V0CLIE_CGCCPF}  NUMBIL {V0BILH_NUMBIL}  CODCLI {V0BILH_CODCLIEN}"
                .Display();

                /*" -3972- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3972- ADD +1 TO AC-I-GELMR. */
            AREA_DE_WORK.AC_I_GELMR.Value = AREA_DE_WORK.AC_I_GELMR + +1;

        }

        [StopWatch]
        /*" R1500-00-INSERT-GELIMRISCO-DB-INSERT-1 */
        public void R1500_00_INSERT_GELIMRISCO_DB_INSERT_1()
        {
            /*" -3962- EXEC SQL INSERT INTO SEGUROS.GE_LIMITE_DE_RISCO VALUES (:V0CLIE-CGCCPF , :V0BILH-RAMO , :GELMR-QTD-SEGUROS , :GELMR-VLR-SOMA-IS , CURRENT DATE , 'CB2005B' , CURRENT TIMESTAMP) END-EXEC. */

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
        /*" R1600-00-BUSCA-PRODUTO-SECTION */
        private void R1600_00_BUSCA_PRODUTO_SECTION()
        {
            /*" -3983- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3985- MOVE 'SIM' TO WS-JV1-ACHEI-PRODUTO. */
            _.Move("SIM", WORK_JV1.WS_JV1_ACHEI_PRODUTO);

            /*" -3995- PERFORM R1600_00_BUSCA_PRODUTO_DB_SELECT_1 */

            R1600_00_BUSCA_PRODUTO_DB_SELECT_1();

            /*" -3998- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3999- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4000- MOVE 'NAO' TO WS-JV1-ACHEI-PRODUTO */
                    _.Move("NAO", WORK_JV1.WS_JV1_ACHEI_PRODUTO);

                    /*" -4001- ELSE */
                }
                else
                {


                    /*" -4002- DISPLAY 'R1600-00 (ERRO - SELECT BILHETE_COBERTURA)' */
                    _.Display($"R1600-00 (ERRO - SELECT BILHETE_COBERTURA)");

                    /*" -4006- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'RAMO: ' V0BILH-RAMO '  ' 'OPCAO PLANO: ' V0BILH-OPCAO-COBER ' ' 'DT. QUITACAO: ' V0BILH-DTQITBCO */

                    $"BILHETE: {V0BILH_NUMBIL}  RAMO: {V0BILH_RAMO}  OPCAO PLANO: {V0BILH_OPCAO_COBER} DT. QUITACAO: {V0BILH_DTQITBCO}"
                    .Display();

                    /*" -4007- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4008- END-IF */
                }


                /*" -4008- END-IF. */
            }


        }

        [StopWatch]
        /*" R1600-00-BUSCA-PRODUTO-DB-SELECT-1 */
        public void R1600_00_BUSCA_PRODUTO_DB_SELECT_1()
        {
            /*" -3995- EXEC SQL SELECT COD_PRODUTO INTO :V1BILP-CODPRODU FROM SEGUROS.BILHETE_COBERTURA WHERE RAMO_COBERTURA = :V0BILH-RAMO AND COD_OPCAO_PLANO = :V0BILH-OPCAO-COBER AND DATA_INIVIGENCIA <= :V0BILH-DTQITBCO AND DATA_TERVIGENCIA >= :V0BILH-DTQITBCO AND IDE_COBERTURA = '1' WITH UR END-EXEC */

            var r1600_00_BUSCA_PRODUTO_DB_SELECT_1_Query1 = new R1600_00_BUSCA_PRODUTO_DB_SELECT_1_Query1()
            {
                V0BILH_OPCAO_COBER = V0BILH_OPCAO_COBER.ToString(),
                V0BILH_DTQITBCO = V0BILH_DTQITBCO.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
            };

            var executed_1 = R1600_00_BUSCA_PRODUTO_DB_SELECT_1_Query1.Execute(r1600_00_BUSCA_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILP_CODPRODU, V1BILP_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-GRAVA-V0HISTOPARC-SECTION */
        private void R2010_00_GRAVA_V0HISTOPARC_SECTION()
        {
            /*" -4020- MOVE '2010' TO WNR-EXEC-SQL. */
            _.Move("2010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4021- MOVE V0APOL-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0HISP_NUM_APOL);

            /*" -4023- MOVE 0 TO V0HISP-NRENDOS */
            _.Move(0, V0HISP_NRENDOS);

            /*" -4024- MOVE V0PARC-NRPARCEL TO V0HISP-NRPARCEL */
            _.Move(V0PARC_NRPARCEL, V0HISP_NRPARCEL);

            /*" -4025- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -4026- MOVE 0101 TO V0HISP-OPERACAO */
            _.Move(0101, V0HISP_OPERACAO);

            /*" -4028- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO. */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -4029- IF V0HISP-NRPARCEL EQUAL 1 */

            if (V0HISP_NRPARCEL == 1)
            {

                /*" -4031- MOVE V0BILH-DTQITBCO TO V0HISP-DTVENCTO WDATA-SISTEMA */
                _.Move(V0BILH_DTQITBCO, V0HISP_DTVENCTO, AREA_DE_WORK.WDATA_SISTEMA);

                /*" -4032- MOVE WDATA-SIS-DIA TO WWORK-DIAINI */
                _.Move(AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA, AREA_DE_WORK.FILLER_14.WWORK_DIAINI);

                /*" -4033- ELSE */
            }
            else
            {


                /*" -4034- MOVE V0HISP-DTVENCTO TO WDATA-SISTEMA */
                _.Move(V0HISP_DTVENCTO, AREA_DE_WORK.WDATA_SISTEMA);

                /*" -4036- PERFORM R2015-00-CALCULA-VENCTO. */

                R2015_00_CALCULA_VENCTO_SECTION();
            }


            /*" -4037- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -4038- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -4039- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -4040- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -4042- MOVE WS000-HORA-TIME TO V0HISP-HORAOPER. */
            _.Move(WS000_HORA_TIME, V0HISP_HORAOPER);

            /*" -4044- MOVE 1 TO V0HISP-OCORHIST */
            _.Move(1, V0HISP_OCORHIST);

            /*" -4045- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -4046- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -4047- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -4048- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -4049- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -4050- MOVE V0PARC-OTNIOF TO V0HISP-VLIOCC */
            _.Move(V0PARC_OTNIOF, V0HISP_VLIOCC);

            /*" -4051- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -4052- MOVE ZEROS TO V0HISP-VLPREMIO */
            _.Move(0, V0HISP_VLPREMIO);

            /*" -4053- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -4054- MOVE V0ENDO-AGECOBR TO V0HISP-AGECOBR */
            _.Move(V0ENDO_AGECOBR, V0HISP_AGECOBR);

            /*" -4055- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -4056- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -4057- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -4058- MOVE 'CB2005B' TO V0HISP-COD-USUAR */
            _.Move("CB2005B", V0HISP_COD_USUAR);

            /*" -4060- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -4062- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -4064- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -4064- PERFORM R2030-00-INSERT-V0HISTOPARC. */

            R2030_00_INSERT_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2015-00-CALCULA-VENCTO-SECTION */
        private void R2015_00_CALCULA_VENCTO_SECTION()
        {
            /*" -4076- MOVE '2015' TO WNR-EXEC-SQL. */
            _.Move("2015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4077- MOVE WWORK-DIAINI TO WDATA-SIS-DIA. */
            _.Move(AREA_DE_WORK.FILLER_14.WWORK_DIAINI, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

            /*" -4079- ADD 1 TO WDATA-SIS-MES. */
            AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES + 1;

            /*" -4080- IF WDATA-SIS-MES GREATER 12 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES > 12)
            {

                /*" -4081- MOVE 1 TO WDATA-SIS-MES */
                _.Move(1, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES);

                /*" -4086- ADD 1 TO WDATA-SIS-ANO. */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO + 1;
            }


            /*" -4087- IF WDATA-SIS-MES EQUAL 4 OR 6 OR 9 OR 11 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.In("4", "6", "9", "11"))
            {

                /*" -4088- IF WDATA-SIS-DIA GREATER 30 */

                if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA > 30)
                {

                    /*" -4089- MOVE 30 TO WDATA-SIS-DIA */
                    _.Move(30, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

                    /*" -4091- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -4092- ELSE */
                }

            }
            else
            {


                /*" -4093- IF WDATA-SIS-MES EQUAL 2 */

                if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES == 2)
                {

                    /*" -4096- DIVIDE WDATA-SIS-ANO BY 4 GIVING W-INTEIRO REMAINDER W-RESTO */
                    _.Divide(AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO, 4, AREA_DE_WORK.W_INTEIRO, AREA_DE_WORK.W_RESTO);

                    /*" -4098- IF W-RESTO EQUAL ZEROS AND WDATA-SIS-DIA GREATER 29 */

                    if (AREA_DE_WORK.W_RESTO == 00 && AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA > 29)
                    {

                        /*" -4099- MOVE 29 TO WDATA-SIS-DIA */
                        _.Move(29, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

                        /*" -4100- ELSE */
                    }
                    else
                    {


                        /*" -4102- IF W-RESTO NOT EQUAL ZEROS AND WDATA-SIS-DIA GREATER 28 */

                        if (AREA_DE_WORK.W_RESTO != 00 && AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA > 28)
                        {

                            /*" -4105- MOVE 28 TO WDATA-SIS-DIA. */
                            _.Move(28, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);
                        }

                    }

                }

            }


            /*" -4105- MOVE WDATA-SISTEMA TO V0HISP-DTVENCTO. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0HISP_DTVENCTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2015_99_SAIDA*/

        [StopWatch]
        /*" R2020-00-GRAVA-OPERACAO-BAIXA-SECTION */
        private void R2020_00_GRAVA_OPERACAO_BAIXA_SECTION()
        {
            /*" -4118- MOVE '2020' TO WNR-EXEC-SQL. */
            _.Move("2020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4119- MOVE V0APOL-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0HISP_NUM_APOL);

            /*" -4120- MOVE 0 TO V0HISP-NRENDOS */
            _.Move(0, V0HISP_NRENDOS);

            /*" -4122- MOVE V0PARC-NRPARCEL TO V0HISP-NRPARCEL */
            _.Move(V0PARC_NRPARCEL, V0HISP_NRPARCEL);

            /*" -4123- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -4124- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -4126- MOVE 0201 TO V0HISP-OPERACAO */
            _.Move(0201, V0HISP_OPERACAO);

            /*" -4127- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -4128- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -4129- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -4130- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -4132- MOVE WS000-HORA-TIME TO V0HISP-HORAOPER. */
            _.Move(WS000_HORA_TIME, V0HISP_HORAOPER);

            /*" -4134- MOVE 2 TO V0HISP-OCORHIST */
            _.Move(2, V0HISP_OCORHIST);

            /*" -4135- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -4136- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -4137- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -4138- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -4139- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -4140- MOVE V0PARC-OTNIOF TO V0HISP-VLIOCC */
            _.Move(V0PARC_OTNIOF, V0HISP_VLIOCC);

            /*" -4143- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -4144- MOVE V2RCAP-VLRCAP TO V0HISP-VLPREMIO */
            _.Move(V2RCAP_VLRCAP, V0HISP_VLPREMIO);

            /*" -4145- MOVE V0ENDO-DATARCAP TO V0HISP-DTVENCTO */
            _.Move(V0ENDO_DATARCAP, V0HISP_DTVENCTO);

            /*" -4146- MOVE V1RCAC-BCOAVISO TO V0HISP-BCOCOBR */
            _.Move(V1RCAC_BCOAVISO, V0HISP_BCOCOBR);

            /*" -4147- MOVE V1RCAC-AGEAVISO TO V0HISP-AGECOBR */
            _.Move(V1RCAC_AGEAVISO, V0HISP_AGECOBR);

            /*" -4148- MOVE V1RCAC-NRAVISO TO V0HISP-NRAVISO */
            _.Move(V1RCAC_NRAVISO, V0HISP_NRAVISO);

            /*" -4149- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -4150- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -4151- MOVE 'CB2005B' TO V0HISP-COD-USUAR */
            _.Move("CB2005B", V0HISP_COD_USUAR);

            /*" -4153- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -4154- MOVE +0 TO VIND-DTQITBCO */
            _.Move(+0, VIND_DTQITBCO);

            /*" -4156- MOVE V0BILH-DTQITBCO TO V0HISP-DTQITBCO. */
            _.Move(V0BILH_DTQITBCO, V0HISP_DTQITBCO);

            /*" -4158- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -4158- PERFORM R2030-00-INSERT-V0HISTOPARC. */

            R2030_00_INSERT_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2020_99_SAIDA*/

        [StopWatch]
        /*" R2030-00-INSERT-V0HISTOPARC-SECTION */
        private void R2030_00_INSERT_V0HISTOPARC_SECTION()
        {
            /*" -4170- MOVE '2030' TO WNR-EXEC-SQL. */
            _.Move("2030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4199- PERFORM R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1 */

            R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1();

            /*" -4202- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4203- DISPLAY 'R2030-00 (ERRO - INSERT V0HISTOPARC)...' */
                _.Display($"R2030-00 (ERRO - INSERT V0HISTOPARC)...");

                /*" -4208- DISPLAY 'APOL: ' V0HISP-NUM-APOL '  ' 'ENDO: ' V0HISP-NRENDOS '  ' 'PARC: ' V0HISP-NRPARCEL '  ' 'OCOR: ' V0HISP-OCORHIST '  ' 'BILH: ' V0BILH-NUMBIL */

                $"APOL: {V0HISP_NUM_APOL}  ENDO: {V0HISP_NRENDOS}  PARC: {V0HISP_NRPARCEL}  OCOR: {V0HISP_OCORHIST}  BILH: {V0BILH_NUMBIL}"
                .Display();

                /*" -4210- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4210- ADD +1 TO AC-I-V0HISTOPARC. */
            AREA_DE_WORK.AC_I_V0HISTOPARC.Value = AREA_DE_WORK.AC_I_V0HISTOPARC + +1;

        }

        [StopWatch]
        /*" R2030-00-INSERT-V0HISTOPARC-DB-INSERT-1 */
        public void R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -4199- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-DACPARC , :V0HISP-DTMOVTO , :V0HISP-OPERACAO , :V0HISP-HORAOPER , :V0HISP-OCORHIST , :V0HISP-PRM-TARIFA , :V0HISP-VAL-DESCON , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-SITCONTB , :V0HISP-COD-USUAR , :V0HISP-RNUDOC , :V0HISP-DTQITBCO:VIND-DTQITBCO , :V0HISP-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1 = new R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1()
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

            R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1.Execute(r2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2030_99_SAIDA*/

        [StopWatch]
        /*" R2050-00-GRAVA-MOVDEBCC-CEF-SECTION */
        private void R2050_00_GRAVA_MOVDEBCC_CEF_SECTION()
        {
            /*" -4221- MOVE '2050' TO WNR-EXEC-SQL. */
            _.Move("2050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4222- MOVE V0HISP-COD-EMPRESA TO V0MVDB-COD-EMPRESA */
            _.Move(V0HISP_COD_EMPRESA, V0MVDB_COD_EMPRESA);

            /*" -4223- MOVE V0HISP-NUM-APOL TO V0MVDB-NUM-APOL */
            _.Move(V0HISP_NUM_APOL, V0MVDB_NUM_APOL);

            /*" -4224- MOVE V0HISP-NRENDOS TO V0MVDB-NRENDOS */
            _.Move(V0HISP_NRENDOS, V0MVDB_NRENDOS);

            /*" -4225- MOVE V0HISP-NRPARCEL TO V0MVDB-NRPARCEL */
            _.Move(V0HISP_NRPARCEL, V0MVDB_NRPARCEL);

            /*" -4226- MOVE '0' TO V0MVDB-SITUACAO */
            _.Move("0", V0MVDB_SITUACAO);

            /*" -4227- MOVE V0HISP-DTVENCTO TO V0MVDB-DTVENCTO */
            _.Move(V0HISP_DTVENCTO, V0MVDB_DTVENCTO);

            /*" -4228- MOVE V0HISP-VLPRMTOT TO V0MVDB-VLR-DEBITO */
            _.Move(V0HISP_VLPRMTOT, V0MVDB_VLR_DEBITO);

            /*" -4229- MOVE V1SIST-DTMOVACB TO V0MVDB-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0MVDB_DTMOVTO);

            /*" -4230- MOVE V0APCB-DIA-DEBITO TO V0MVDB-DIA-DEBITO */
            _.Move(V0APCB_DIA_DEBITO, V0MVDB_DIA_DEBITO);

            /*" -4231- MOVE V0APCB-AGENCIA-DEB TO V0MVDB-AGENCIA-DEB */
            _.Move(V0APCB_AGENCIA_DEB, V0MVDB_AGENCIA_DEB);

            /*" -4232- MOVE V0APCB-OPERACAO-DEB TO V0MVDB-OPERACAO-DEB */
            _.Move(V0APCB_OPERACAO_DEB, V0MVDB_OPERACAO_DEB);

            /*" -4233- MOVE V0APCB-NUMCTA-DEB TO V0MVDB-NUMCTA-DEB */
            _.Move(V0APCB_NUMCTA_DEB, V0MVDB_NUMCTA_DEB);

            /*" -4234- MOVE V0APCB-DIGCTA-DEB TO V0MVDB-DIGCTA-DEB */
            _.Move(V0APCB_DIGCTA_DEB, V0MVDB_DIGCTA_DEB);

            /*" -4235- MOVE 6114 TO V0MVDB-CONVENIO */
            _.Move(6114, V0MVDB_CONVENIO);

            /*" -4236- MOVE SPACES TO V0MVDB-DTENVIO */
            _.Move("", V0MVDB_DTENVIO);

            /*" -4237- MOVE SPACES TO V0MVDB-DTRETORNO */
            _.Move("", V0MVDB_DTRETORNO);

            /*" -4238- MOVE ZEROS TO V0MVDB-COD-RETORNO */
            _.Move(0, V0MVDB_COD_RETORNO);

            /*" -4239- MOVE ZEROS TO V0MVDB-NSAS */
            _.Move(0, V0MVDB_NSAS);

            /*" -4240- MOVE 'CB2005B' TO V0MVDB-COD-USUARIO */
            _.Move("CB2005B", V0MVDB_COD_USUARIO);

            /*" -4241- MOVE ZEROS TO V0MVDB-REQUISICAO */
            _.Move(0, V0MVDB_REQUISICAO);

            /*" -4242- MOVE ZEROS TO V0MVDB-NUM-CARTAO */
            _.Move(0, V0MVDB_NUM_CARTAO);

            /*" -4243- MOVE ZEROS TO V0MVDB-SEQUENCIA */
            _.Move(0, V0MVDB_SEQUENCIA);

            /*" -4244- MOVE ZEROS TO V0MVDB-NUM-LOTE */
            _.Move(0, V0MVDB_NUM_LOTE);

            /*" -4245- MOVE SPACES TO V0MVDB-DTCREDITO */
            _.Move("", V0MVDB_DTCREDITO);

            /*" -4246- MOVE SPACES TO V0MVDB-STATUS */
            _.Move("", V0MVDB_STATUS);

            /*" -4248- MOVE ZEROS TO V0MVDB-VLR-CREDITO. */
            _.Move(0, V0MVDB_VLR_CREDITO);

            /*" -4251- IF V0MVDB-AGENCIA-DEB EQUAL ZEROS OR V0MVDB-OPERACAO-DEB EQUAL ZEROS OR V0MVDB-NUMCTA-DEB EQUAL ZEROS */

            if (V0MVDB_AGENCIA_DEB == 00 || V0MVDB_OPERACAO_DEB == 00 || V0MVDB_NUMCTA_DEB == 00)
            {

                /*" -4253- MOVE '6' TO V0MVDB-SITUACAO. */
                _.Move("6", V0MVDB_SITUACAO);
            }


            /*" -4260- MOVE ZEROS TO VIND-DIADEBITO VIND-AGENCIA VIND-OPERACAO VIND-NUMCONTA VIND-DIGCONTA VIND-USUARIO. */
            _.Move(0, VIND_DIADEBITO, VIND_AGENCIA, VIND_OPERACAO, VIND_NUMCONTA, VIND_DIGCONTA, VIND_USUARIO);

            /*" -4272- MOVE -1 TO VIND-DTENVIO VIND-DTRETORNO VIND-CODRETORNO VIND-REQUISICAO VIND-NUMCARTAO VIND-SEQUENCIA VIND-NUM-LOTE VIND-DTCREDITO VIND-STATUS VIND-VLCREDITO. */
            _.Move(-1, VIND_DTENVIO, VIND_DTRETORNO, VIND_CODRETORNO, VIND_REQUISICAO, VIND_NUMCARTAO, VIND_SEQUENCIA, VIND_NUM_LOTE, VIND_DTCREDITO, VIND_STATUS, VIND_VLCREDITO);

            /*" -4272- PERFORM R2060-00-INSERT-V0MOVDEBCC. */

            R2060_00_INSERT_V0MOVDEBCC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2050_99_SAIDA*/

        [StopWatch]
        /*" R2060-00-INSERT-V0MOVDEBCC-SECTION */
        private void R2060_00_INSERT_V0MOVDEBCC_SECTION()
        {
            /*" -4285- MOVE '2060' TO WNR-EXEC-SQL. */
            _.Move("2060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4341- PERFORM R2060_00_INSERT_V0MOVDEBCC_DB_INSERT_1 */

            R2060_00_INSERT_V0MOVDEBCC_DB_INSERT_1();

            /*" -4344- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4345- DISPLAY 'R2060-00 (ERRO - INSERT V0MOVDEBCC)...' */
                _.Display($"R2060-00 (ERRO - INSERT V0MOVDEBCC)...");

                /*" -4350- DISPLAY 'APOL: ' V0HISP-NUM-APOL '  ' 'ENDO: ' V0HISP-NRENDOS '  ' 'PARC: ' V0HISP-NRPARCEL '  ' 'OCOR: ' V0HISP-OCORHIST '  ' 'BILH: ' V0BILH-NUMBIL */

                $"APOL: {V0HISP_NUM_APOL}  ENDO: {V0HISP_NRENDOS}  PARC: {V0HISP_NRPARCEL}  OCOR: {V0HISP_OCORHIST}  BILH: {V0BILH_NUMBIL}"
                .Display();

                /*" -4350- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2060-00-INSERT-V0MOVDEBCC-DB-INSERT-1 */
        public void R2060_00_INSERT_V0MOVDEBCC_DB_INSERT_1()
        {
            /*" -4341- EXEC SQL INSERT INTO SEGUROS.V0MOVDEBCC_CEF ( COD_EMPRESA ,NUM_APOLICE ,NRENDOS ,NRPARCEL ,SIT_COBRANCA ,DTVENCTO ,VLR_DEBITO ,DTMOVTO ,TIMESTAMP ,DIA_DEBITO ,COD_AGENCIA_DEB ,OPER_CONTA_DEB ,NUM_CONTA_DEB ,DIG_CONTA_DEB ,COD_CONVENIO ,DTENVIO ,DTRETORNO ,COD_RETORNO_CEF ,NSAS ,COD_USUARIO ,NUM_REQUISICAO ,NUM_CARTAO ,SEQUENCIA ,NUM_LOTE ,DTCREDITO ,STATUS_CARTAO ,VLR_CREDITO ) VALUES (:V0MVDB-COD-EMPRESA , :V0MVDB-NUM-APOL , :V0MVDB-NRENDOS , :V0MVDB-NRPARCEL , :V0MVDB-SITUACAO, :V0MVDB-DTVENCTO, :V0MVDB-VLR-DEBITO, :V0MVDB-DTMOVTO , CURRENT TIMESTAMP, :V0MVDB-DIA-DEBITO:VIND-DIADEBITO, :V0MVDB-AGENCIA-DEB:VIND-AGENCIA, :V0MVDB-OPERACAO-DEB:VIND-OPERACAO, :V0MVDB-NUMCTA-DEB:VIND-NUMCONTA, :V0MVDB-DIGCTA-DEB:VIND-DIGCONTA, :V0MVDB-CONVENIO , :V0MVDB-DTENVIO:VIND-DTENVIO, :V0MVDB-DTRETORNO:VIND-DTRETORNO, :V0MVDB-COD-RETORNO:VIND-CODRETORNO, :V0MVDB-NSAS , :V0MVDB-COD-USUARIO:VIND-USUARIO, :V0MVDB-REQUISICAO:VIND-REQUISICAO, :V0MVDB-NUM-CARTAO:VIND-NUMCARTAO, :V0MVDB-SEQUENCIA:VIND-SEQUENCIA, :V0MVDB-NUM-LOTE:VIND-NUM-LOTE, :V0MVDB-DTCREDITO:VIND-DTCREDITO, :V0MVDB-STATUS:VIND-STATUS, :V0MVDB-VLR-CREDITO:VIND-VLCREDITO) END-EXEC. */

            var r2060_00_INSERT_V0MOVDEBCC_DB_INSERT_1_Insert1 = new R2060_00_INSERT_V0MOVDEBCC_DB_INSERT_1_Insert1()
            {
                V0MVDB_COD_EMPRESA = V0MVDB_COD_EMPRESA.ToString(),
                V0MVDB_NUM_APOL = V0MVDB_NUM_APOL.ToString(),
                V0MVDB_NRENDOS = V0MVDB_NRENDOS.ToString(),
                V0MVDB_NRPARCEL = V0MVDB_NRPARCEL.ToString(),
                V0MVDB_SITUACAO = V0MVDB_SITUACAO.ToString(),
                V0MVDB_DTVENCTO = V0MVDB_DTVENCTO.ToString(),
                V0MVDB_VLR_DEBITO = V0MVDB_VLR_DEBITO.ToString(),
                V0MVDB_DTMOVTO = V0MVDB_DTMOVTO.ToString(),
                V0MVDB_DIA_DEBITO = V0MVDB_DIA_DEBITO.ToString(),
                VIND_DIADEBITO = VIND_DIADEBITO.ToString(),
                V0MVDB_AGENCIA_DEB = V0MVDB_AGENCIA_DEB.ToString(),
                VIND_AGENCIA = VIND_AGENCIA.ToString(),
                V0MVDB_OPERACAO_DEB = V0MVDB_OPERACAO_DEB.ToString(),
                VIND_OPERACAO = VIND_OPERACAO.ToString(),
                V0MVDB_NUMCTA_DEB = V0MVDB_NUMCTA_DEB.ToString(),
                VIND_NUMCONTA = VIND_NUMCONTA.ToString(),
                V0MVDB_DIGCTA_DEB = V0MVDB_DIGCTA_DEB.ToString(),
                VIND_DIGCONTA = VIND_DIGCONTA.ToString(),
                V0MVDB_CONVENIO = V0MVDB_CONVENIO.ToString(),
                V0MVDB_DTENVIO = V0MVDB_DTENVIO.ToString(),
                VIND_DTENVIO = VIND_DTENVIO.ToString(),
                V0MVDB_DTRETORNO = V0MVDB_DTRETORNO.ToString(),
                VIND_DTRETORNO = VIND_DTRETORNO.ToString(),
                V0MVDB_COD_RETORNO = V0MVDB_COD_RETORNO.ToString(),
                VIND_CODRETORNO = VIND_CODRETORNO.ToString(),
                V0MVDB_NSAS = V0MVDB_NSAS.ToString(),
                V0MVDB_COD_USUARIO = V0MVDB_COD_USUARIO.ToString(),
                VIND_USUARIO = VIND_USUARIO.ToString(),
                V0MVDB_REQUISICAO = V0MVDB_REQUISICAO.ToString(),
                VIND_REQUISICAO = VIND_REQUISICAO.ToString(),
                V0MVDB_NUM_CARTAO = V0MVDB_NUM_CARTAO.ToString(),
                VIND_NUMCARTAO = VIND_NUMCARTAO.ToString(),
                V0MVDB_SEQUENCIA = V0MVDB_SEQUENCIA.ToString(),
                VIND_SEQUENCIA = VIND_SEQUENCIA.ToString(),
                V0MVDB_NUM_LOTE = V0MVDB_NUM_LOTE.ToString(),
                VIND_NUM_LOTE = VIND_NUM_LOTE.ToString(),
                V0MVDB_DTCREDITO = V0MVDB_DTCREDITO.ToString(),
                VIND_DTCREDITO = VIND_DTCREDITO.ToString(),
                V0MVDB_STATUS = V0MVDB_STATUS.ToString(),
                VIND_STATUS = VIND_STATUS.ToString(),
                V0MVDB_VLR_CREDITO = V0MVDB_VLR_CREDITO.ToString(),
                VIND_VLCREDITO = VIND_VLCREDITO.ToString(),
            };

            R2060_00_INSERT_V0MOVDEBCC_DB_INSERT_1_Insert1.Execute(r2060_00_INSERT_V0MOVDEBCC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-SECTION */
        private void R3000_00_ACUMULA_BILHETE_SECTION()
        {
            /*" -4539- MOVE '.' TO WS000-P1 WS000-P2. */
            _.Move(".", WS000_HORA_TIME_REDF.WS000_P1);
            _.Move(".", WS000_HORA_TIME_REDF.WS000_P2);


            /*" -4541- MOVE SPACES TO WFIM-V1RCAP */
            _.Move("", AREA_DE_WORK.WFIM_V1RCAP);

            /*" -4544- MOVE V0BILH-NUMBIL TO WWORK-NUMBIL V0APOL-NUMBIL. */
            _.Move(V0BILH_NUMBIL, AREA_DE_WORK.WWORK_NUMBIL, V0APOL_NUMBIL);

            /*" -4549- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4551- MOVE V0BILH-NUMBIL TO V0RCAP-NRTIT. */
            _.Move(V0BILH_NUMBIL, V0RCAP_NRTIT);

            /*" -4570- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_1 */

            R3000_00_ACUMULA_BILHETE_DB_SELECT_1();

            /*" -4573- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4574- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4575- MOVE 'S' TO WFIM-V1RCAP */
                    _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);

                    /*" -4576- ELSE */
                }
                else
                {


                    /*" -4577- DISPLAY 'R3000-00 (ERRO - SELECT V0RCAP)...' */
                    _.Display($"R3000-00 (ERRO - SELECT V0RCAP)...");

                    /*" -4580- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'FONTE: ' V0BILH-FONTE '  ' 'NRRCAP: ' WHOST-NRRCAP */

                    $"BILHETE: {V0BILH_NUMBIL}  FONTE: {V0BILH_FONTE}  NRRCAP: {WHOST_NRRCAP}"
                    .Display();

                    /*" -4581- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4583- ELSE */
                }

            }
            else
            {


                /*" -4584- IF V0RCAP-SITUACAO NOT EQUAL '0' */

                if (V0RCAP_SITUACAO != "0")
                {

                    /*" -4585- MOVE 'S' TO WFIM-V1RCAP */
                    _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);

                    /*" -4586- ELSE */
                }
                else
                {


                    /*" -4588- IF V0RCAP-OPERACAO GREATER 199 AND V0RCAP-OPERACAO LESS 300 */

                    if (V0RCAP_OPERACAO > 199 && V0RCAP_OPERACAO < 300)
                    {

                        /*" -4589- MOVE 'S' TO WFIM-V1RCAP */
                        _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);

                        /*" -4590- ELSE */
                    }
                    else
                    {


                        /*" -4592- IF V0RCAP-OPERACAO GREATER 399 AND V0RCAP-OPERACAO LESS 500 */

                        if (V0RCAP_OPERACAO > 399 && V0RCAP_OPERACAO < 500)
                        {

                            /*" -4595- MOVE 'S' TO WFIM-V1RCAP. */
                            _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);
                        }

                    }

                }

            }


            /*" -4601- DISPLAY 'R3000 - 001    - ' SQLCODE ' / ' V0BILH-NUMBIL ' / ' V0RCAP-SITUACAO ' / ' V0RCAP-OPERACAO ' / ' WFIM-V1RCAP */

            $"R3000 - 001    - {DB.SQLCODE} / {V0BILH_NUMBIL} / {V0RCAP_SITUACAO} / {V0RCAP_OPERACAO} / {AREA_DE_WORK.WFIM_V1RCAP}"
            .Display();

            /*" -4602- IF WFIM-V1RCAP EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V1RCAP == "S")
            {

                /*" -4603- MOVE 'F' TO V0BILH-SITUACAO */
                _.Move("F", V0BILH_SITUACAO);

                /*" -4604- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -4606- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4607- MOVE V0RCAP-NRRCAP TO WWORK-NRRCAP */
            _.Move(V0RCAP_NRRCAP, AREA_DE_WORK.FILLER_4.WWORK_NRRCAP);

            /*" -4609- MOVE V0RCAP-NRRCAP TO WHOST-NRRCAP. */
            _.Move(V0RCAP_NRRCAP, WHOST_NRRCAP);

            /*" -4612- MOVE '3025' TO WNR-EXEC-SQL. */
            _.Move("3025", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4627- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_2 */

            R3000_00_ACUMULA_BILHETE_DB_SELECT_2();

            /*" -4630- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4631- DISPLAY 'R3025-00 (ERRO - SELECT V1RCAPCOMP)... ' */
                _.Display($"R3025-00 (ERRO - SELECT V1RCAPCOMP)... ");

                /*" -4634- DISPLAY 'FONTE: ' V0BILH-FONTE '  ' 'NRRCAP: ' WHOST-NRRCAP '  ' 'BILHETE: ' V0BILH-NUMBIL */

                $"FONTE: {V0BILH_FONTE}  NRRCAP: {WHOST_NRRCAP}  BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -4636- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4639- COMPUTE WS-VALORDIF EQUAL V0BILH-VLRCAP - V2RCAP-VLRCAP. */
            AREA_DE_WORK.WS_VALORDIF.Value = V0BILH_VLRCAP - V2RCAP_VLRCAP;

            /*" -4640- IF WS-VALORDIF LESS ZEROS */

            if (AREA_DE_WORK.WS_VALORDIF < 00)
            {

                /*" -4649- COMPUTE WS-VALORDIF EQUAL WS-VALORDIF * -1. */
                AREA_DE_WORK.WS_VALORDIF.Value = AREA_DE_WORK.WS_VALORDIF * -1;
            }


            /*" -4652- DISPLAY 'R3000 - 002    - ' WS-VALORDIF ' > ' WS-VLDIFE */

            $"R3000 - 002    - {AREA_DE_WORK.WS_VALORDIF} > {AREA_DE_WORK.WS_VLDIFE}"
            .Display();

            /*" -4654- IF WS-VALORDIF GREATER WS-VLDIFE */

            if (AREA_DE_WORK.WS_VALORDIF > AREA_DE_WORK.WS_VLDIFE)
            {

                /*" -4662- IF V0BILH-NUMBIL = 84611840295 OR V0BILH-NUMBIL = 84633012883 OR V0BILH-NUMBIL = 84635706912 OR V0BILH-NUMBIL = 84625550006 OR V0BILH-NUMBIL = 84627012397 OR V0BILH-NUMBIL = 84553030079 OR V0BILH-NUMBIL = 84571676635 OR V0BILH-NUMBIL = 8259298302 */

                if (V0BILH_NUMBIL == 84611840295 || V0BILH_NUMBIL == 84633012883 || V0BILH_NUMBIL == 84635706912 || V0BILH_NUMBIL == 84625550006 || V0BILH_NUMBIL == 84627012397 || V0BILH_NUMBIL == 84553030079 || V0BILH_NUMBIL == 84571676635 || V0BILH_NUMBIL == 8259298302)
                {

                    /*" -4663- DISPLAY 'V 04-BILHETE-->' V0BILH-NUMBIL */
                    _.Display($"V 04-BILHETE-->{V0BILH_NUMBIL}");

                    /*" -4664- ELSE */
                }
                else
                {


                    /*" -4665- MOVE '1' TO V0BILH-SITUACAO */
                    _.Move("1", V0BILH_SITUACAO);

                    /*" -4666- PERFORM R3040-00-MONTA-V0BILHETE */

                    R3040_00_MONTA_V0BILHETE_SECTION();

                    /*" -4667- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -4669- GO TO R3000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;

                    /*" -4670- END-IF */
                }


                /*" -4672- END-IF. */
            }


            /*" -4675- MOVE '3050' TO WNR-EXEC-SQL. */
            _.Move("3050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4676- MOVE SPACES TO WFIM-V1COMIFENAE. */
            _.Move("", AREA_DE_WORK.WFIM_V1COMIFENAE);

            /*" -4678- MOVE V0BILH-NUMBIL TO V1COFE-NUMBIL. */
            _.Move(V0BILH_NUMBIL, V1COFE_NUMBIL);

            /*" -4686- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_3 */

            R3000_00_ACUMULA_BILHETE_DB_SELECT_3();

            /*" -4693- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4694- MOVE 'F' TO V0BILH-SITUACAO */
                _.Move("F", V0BILH_SITUACAO);

                /*" -4695- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -4696- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -4697- ELSE */
            }
            else
            {


                /*" -4698- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4699- DISPLAY 'R3050-00 (ERRO - SELECT V1COMISSAO_FENAE)...' */
                    _.Display($"R3050-00 (ERRO - SELECT V1COMISSAO_FENAE)...");

                    /*" -4700- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                    _.Display($"BILHETE: {V0BILH_NUMBIL}");

                    /*" -4701- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4703- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -4704- END-IF */
                }


                /*" -4711- END-IF. */
            }


            /*" -4714- MOVE '3055' TO WNR-EXEC-SQL. */
            _.Move("3055", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4720- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_4 */

            R3000_00_ACUMULA_BILHETE_DB_SELECT_4();

            /*" -4726- DISPLAY 'R3000 - 003    - ' SQLCODE ' -   V1AGENCIACEF' ' - ' V0BILH-AGECOBR */

            $"R3000 - 003    - {DB.SQLCODE} -   V1AGENCIACEF - {V0BILH_AGECOBR}"
            .Display();

            /*" -4727- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4728- MOVE 'F' TO V0BILH-SITUACAO */
                _.Move("F", V0BILH_SITUACAO);

                /*" -4729- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -4730- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -4731- ELSE */
            }
            else
            {


                /*" -4732- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4733- DISPLAY 'R3055-00 (ERRO - SELECT V1AGENCIACEF)...' */
                    _.Display($"R3055-00 (ERRO - SELECT V1AGENCIACEF)...");

                    /*" -4734- DISPLAY 'BILHETE    : ' V0BILH-NUMBIL */
                    _.Display($"BILHETE    : {V0BILH_NUMBIL}");

                    /*" -4735- DISPLAY 'COD.AGENCIA: ' V1COFE-AGECOBR */
                    _.Display($"COD.AGENCIA: {V1COFE_AGECOBR}");

                    /*" -4737- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4740- MOVE '3060' TO WNR-EXEC-SQL. */
            _.Move("3060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4746- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_5 */

            R3000_00_ACUMULA_BILHETE_DB_SELECT_5();

            /*" -4752- DISPLAY 'R3000 - 004    - ' SQLCODE ' -   V1MALHACEF' ' - ' V0BILH-AGECOBR */

            $"R3000 - 004    - {DB.SQLCODE} -   V1MALHACEF - {V0BILH_AGECOBR}"
            .Display();

            /*" -4753- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4754- MOVE 'F' TO V0BILH-SITUACAO */
                _.Move("F", V0BILH_SITUACAO);

                /*" -4755- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -4756- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -4757- ELSE */
            }
            else
            {


                /*" -4758- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4759- DISPLAY 'R3060-00 (ERRO SELECT V1MALHACEF)...' */
                    _.Display($"R3060-00 (ERRO SELECT V1MALHACEF)...");

                    /*" -4760- DISPLAY 'ESCNEG : ' V1ACEF-CODESCNEG */
                    _.Display($"ESCNEG : {V1ACEF_CODESCNEG}");

                    /*" -4761- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                    _.Display($"BILHETE: {V0BILH_NUMBIL}");

                    /*" -4763- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4764- IF V1COFE-AGECOBR NOT EQUAL V0BILH-AGECOBR */

            if (V1COFE_AGECOBR != V0BILH_AGECOBR)
            {

                /*" -4765- MOVE V1COFE-AGECOBR TO V0BILH-AGECOBR */
                _.Move(V1COFE_AGECOBR, V0BILH_AGECOBR);

                /*" -4767- PERFORM R3095-00-UPDATE-V0BILHETE. */

                R3095_00_UPDATE_V0BILHETE_SECTION();
            }


            /*" -4769- ADD V0BILFX-VALADT TO V0ADIA-VALADT. */
            V0ADIA_VALADT.Value = V0ADIA_VALADT + V0BILFX_VALADT;

            /*" -4770- IF V1MCEF-COD-FONTE NOT EQUAL V0BILH-FONTE */

            if (V1MCEF_COD_FONTE != V0BILH_FONTE)
            {

                /*" -4771- MOVE V1MCEF-COD-FONTE TO V0BILH-FONTE */
                _.Move(V1MCEF_COD_FONTE, V0BILH_FONTE);

                /*" -4776- PERFORM R3090-00-UPDATE-V0BILHETE. */

                R3090_00_UPDATE_V0BILHETE_SECTION();
            }


            /*" -4777- MOVE V1ACEF-CODESCNEG TO V1COBI-COD-ESCNEG */
            _.Move(V1ACEF_CODESCNEG, V1COBI_COD_ESCNEG);

            /*" -4778- MOVE V0BILH-RAMO TO V1COBI-RAMO */
            _.Move(V0BILH_RAMO, V1COBI_RAMO);

            /*" -4780- MOVE V1COFE-DTQITBCO TO V1COBI-DTINIVIG. */
            _.Move(V1COFE_DTQITBCO, V1COBI_DTINIVIG);

            /*" -4783- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4796- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_6 */

            R3000_00_ACUMULA_BILHETE_DB_SELECT_6();

            /*" -4799- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4800- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4801- MOVE 'S' TO WFIM-V1COMERC-BIL */
                    _.Move("S", AREA_DE_WORK.WFIM_V1COMERC_BIL);

                    /*" -4802- ELSE */
                }
                else
                {


                    /*" -4803- DISPLAY 'R3100-00 (ERRO - SELECT V0COMERC_BILHETE.. ' */
                    _.Display($"R3100-00 (ERRO - SELECT V0COMERC_BILHETE.. ");

                    /*" -4806- DISPLAY 'ESCNEG   : ' V1COBI-COD-ESCNEG ' ' 'RAMO     : ' V1COBI-RAMO '  ' 'DTINIVIG ; ' V1COBI-DTINIVIG */

                    $"ESCNEG   : {V1COBI_COD_ESCNEG} RAMO     : {V1COBI_RAMO} DTINIVIG;{V1COBI_DTINIVIG}"
                    .Display();

                    /*" -4808- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4812- DISPLAY 'R3000 - 005    - ' SQLCODE ' -   V1COMERC_BILHETE' ' - ' WFIM-V1COMERC-BIL */

            $"R3000 - 005    - {DB.SQLCODE} -   V1COMERC_BILHETE - {AREA_DE_WORK.WFIM_V1COMERC_BIL}"
            .Display();

            /*" -4813- IF WFIM-V1COMERC-BIL NOT EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V1COMERC_BIL != "S")
            {

                /*" -4815- IF V0BILH-OPCAO-COBER EQUAL 1 AND V1COBI-COBERTURA1 EQUAL 'B' */

                if (V0BILH_OPCAO_COBER == 1 && V1COBI_COBERTURA1 == "B")
                {

                    /*" -4816- PERFORM R3110-00-INSERT-V0BIL-CC00396 */

                    R3110_00_INSERT_V0BIL_CC00396_SECTION();

                    /*" -4817- ELSE */
                }
                else
                {


                    /*" -4819- IF V0BILH-OPCAO-COBER EQUAL 2 AND V1COBI-COBERTURA2 EQUAL 'B' */

                    if (V0BILH_OPCAO_COBER == 2 && V1COBI_COBERTURA2 == "B")
                    {

                        /*" -4820- PERFORM R3110-00-INSERT-V0BIL-CC00396 */

                        R3110_00_INSERT_V0BIL_CC00396_SECTION();

                        /*" -4821- ELSE */
                    }
                    else
                    {


                        /*" -4823- IF V0BILH-OPCAO-COBER EQUAL 3 AND V1COBI-COBERTURA3 EQUAL 'B' */

                        if (V0BILH_OPCAO_COBER == 3 && V1COBI_COBERTURA3 == "B")
                        {

                            /*" -4825- PERFORM R3110-00-INSERT-V0BIL-CC00396. */

                            R3110_00_INSERT_V0BIL_CC00396_SECTION();
                        }

                    }

                }

            }


            /*" -4828- MOVE '3120' TO WNR-EXEC-SQL. */
            _.Move("3120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4830- MOVE SPACES TO WFIM-V1FUNCIOCEF. */
            _.Move("", AREA_DE_WORK.WFIM_V1FUNCIOCEF);

            /*" -4849- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_7 */

            R3000_00_ACUMULA_BILHETE_DB_SELECT_7();

            /*" -4854- DISPLAY 'R3000 - 006    - ' SQLCODE ' -   V1FUNCIOCEF' */

            $"R3000 - 006    - {DB.SQLCODE} -   V1FUNCIOCEF"
            .Display();

            /*" -4855- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4857- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4858- MOVE 10701 TO V0BILER-COD-ERRO */
                    _.Move(10701, V0BILER_COD_ERRO);

                    /*" -4859- PERFORM R3045-00-GRAVA-TAB-ERRO */

                    R3045_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -4860- MOVE 'F' TO V0BILH-SITUACAO */
                    _.Move("F", V0BILH_SITUACAO);

                    /*" -4861- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -4862- GO TO R3000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;

                    /*" -4863- ELSE */
                }
                else
                {


                    /*" -4864- DISPLAY 'R3120-00 (ERRO - SELECT V1FUNCIOCEF)...' */
                    _.Display($"R3120-00 (ERRO - SELECT V1FUNCIOCEF)...");

                    /*" -4865- DISPLAY 'MATRICULA: ' V0BILH-NUM-MATR */
                    _.Display($"MATRICULA: {V0BILH_NUM_MATR}");

                    /*" -4866- DISPLAY 'BILHETE  : ' V0BILH-NUMBIL */
                    _.Display($"BILHETE  : {V0BILH_NUMBIL}");

                    /*" -4868- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4869- IF VIND-COD-ANGAR LESS ZEROS */

            if (VIND_COD_ANGAR < 00)
            {

                /*" -4871- MOVE ZEROS TO V1FUNC-COD-ANGAR. */
                _.Move(0, V1FUNC_COD_ANGAR);
            }


            /*" -4876- DISPLAY 'R3000 - 007    - ' SQLCODE ' -   V1FUNC-COD-ANGAR' ' - ' V1FUNC-COD-ANGAR ' - ' V0BILH-NUM-MATR */

            $"R3000 - 007    - {DB.SQLCODE} -   V1FUNC-COD-ANGAR - {V1FUNC_COD_ANGAR} - {V0BILH_NUM_MATR}"
            .Display();

            /*" -4877- IF V1FUNC-COD-ANGAR NOT EQUAL ZEROS */

            if (V1FUNC_COD_ANGAR != 00)
            {

                /*" -4879- GO TO R3000-90-CONTINUA. */

                R3000_90_CONTINUA(); //GOTO
                return;
            }


            /*" -4882- MOVE '3130' TO WNR-EXEC-SQL. */
            _.Move("3130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4886- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_8 */

            R3000_00_ACUMULA_BILHETE_DB_SELECT_8();

            /*" -4889- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4890- DISPLAY 'R3130-00 (ERRO - SELECT V1NUMERO_OUTROS)...' */
                _.Display($"R3130-00 (ERRO - SELECT V1NUMERO_OUTROS)...");

                /*" -4891- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -4893- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4894- MOVE V1NOUT-CODANGAR TO WS-NUM-ANGAR */
            _.Move(V1NOUT_CODANGAR, AREA_DE_WORK.WS_CODANGAR_R.WS_NUM_ANGAR);

            /*" -4895- ADD 1 TO WS-NUM-ANGAR */
            AREA_DE_WORK.WS_CODANGAR_R.WS_NUM_ANGAR.Value = AREA_DE_WORK.WS_CODANGAR_R.WS_NUM_ANGAR + 1;

            /*" -4896- MOVE WS-NUM-ANGAR TO PROM11W099-NUMERO */
            _.Move(AREA_DE_WORK.WS_CODANGAR_R.WS_NUM_ANGAR, AREA_DE_WORK.PROM11W099.PROM11W099_NUMERO);

            /*" -4898- MOVE 6 TO PROM11W099-TAM */
            _.Move(6, AREA_DE_WORK.PROM11W099.PROM11W099_TAM);

            /*" -4899- CALL 'PROM1101' USING PROM11W099 */
            _.Call("PROM1101", AREA_DE_WORK.PROM11W099);

            /*" -4900- MOVE PROM11W099-DAC TO WS-DAC-ANGAR */
            _.Move(AREA_DE_WORK.PROM11W099.PROM11W099_DAC, AREA_DE_WORK.WS_CODANGAR_R.WS_DAC_ANGAR);

            /*" -4902- MOVE WS-CODANGAR TO V1FUNC-COD-ANGAR */
            _.Move(AREA_DE_WORK.WS_CODANGAR, V1FUNC_COD_ANGAR);

            /*" -4905- MOVE '3140' TO WNR-EXEC-SQL. */
            _.Move("3140", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4913- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_9 */

            R3000_00_ACUMULA_BILHETE_DB_SELECT_9();

            /*" -4919- DISPLAY 'R3000 - 008    - ' SQLCODE ' -   V1AGENCIACEF' ' - ' V1COFE-AGECOBR */

            $"R3000 - 008    - {DB.SQLCODE} -   V1AGENCIACEF - {V1COFE_AGECOBR}"
            .Display();

            /*" -4920- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4922- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4923- MOVE 10202 TO V0BILER-COD-ERRO */
                    _.Move(10202, V0BILER_COD_ERRO);

                    /*" -4924- PERFORM R3045-00-GRAVA-TAB-ERRO */

                    R3045_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -4925- MOVE 'F' TO V0BILH-SITUACAO */
                    _.Move("F", V0BILH_SITUACAO);

                    /*" -4926- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -4927- ELSE */
                }
                else
                {


                    /*" -4928- GO TO R3000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -4936- MOVE '3150' TO WNR-EXEC-SQL. */
            _.Move("3150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4941- PERFORM R3000_00_ACUMULA_BILHETE_DB_UPDATE_1 */

            R3000_00_ACUMULA_BILHETE_DB_UPDATE_1();

            /*" -4949- DISPLAY 'R3000 - 009    - ' SQLCODE ' -   V0FUNCIOCEF' ' - ' V1FUNC-COD-ANGAR ' - ' V1FUNC-NUM-MATRIC ' - ' V1FUNC-NUM-CPF */

            $"R3000 - 009    - {DB.SQLCODE} -   V0FUNCIOCEF - {V1FUNC_COD_ANGAR} - {V1FUNC_NUM_MATRIC} - {V1FUNC_NUM_CPF}"
            .Display();

            /*" -4950- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4951- DISPLAY 'R3150-00 (ERRO - UPDATE V0FUNCIOCEF)...' */
                _.Display($"R3150-00 (ERRO - UPDATE V0FUNCIOCEF)...");

                /*" -4954- DISPLAY 'MATRICULA: ' V1FUNC-NUM-MATRIC '  ' 'CPF: ' V1FUNC-NUM-CPF '  ' 'BILHETE: ' V0BILH-NUMBIL */

                $"MATRICULA: {V1FUNC_NUM_MATRIC}  CPF: {V1FUNC_NUM_CPF}  BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -4956- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4958- ADD +1 TO AC-U-V0FUNCIOCEF. */
            AREA_DE_WORK.AC_U_V0FUNCIOCEF.Value = AREA_DE_WORK.AC_U_V0FUNCIOCEF + +1;

            /*" -4959- MOVE V1FUNC-ENDERECO TO V1PROD-ENDERECO */
            _.Move(V1FUNC_ENDERECO, V1PROD_ENDERECO);

            /*" -4961- MOVE V1FUNC-CIDADE TO V1PROD-CIDADE */
            _.Move(V1FUNC_CIDADE, V1PROD_CIDADE);

            /*" -4962- MOVE V1SIST-DTMOVACB TO WDATA-SISTEMA */
            _.Move(V1SIST_DTMOVACB, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -4963- MOVE WDATA-SIS-ANO TO WS-AA-NUMREC */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO, AREA_DE_WORK.WS_NUMREC_R.WS_AA_NUMREC);

            /*" -4964- MOVE ZEROS TO WS-NN-NUMREC */
            _.Move(0, AREA_DE_WORK.WS_NUMREC_R.WS_NN_NUMREC);

            /*" -4966- MOVE WS-NUMREC TO WHOST-NUMREC. */
            _.Move(AREA_DE_WORK.WS_NUMREC, WHOST_NUMREC);

            /*" -4969- MOVE '3160' TO WNR-EXEC-SQL. */
            _.Move("3160", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5013- PERFORM R3000_00_ACUMULA_BILHETE_DB_INSERT_1 */

            R3000_00_ACUMULA_BILHETE_DB_INSERT_1();

            /*" -5016- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5017- DISPLAY 'R3160-00 (ERRO - INSERT V0PRODUTOR)...' */
                _.Display($"R3160-00 (ERRO - INSERT V0PRODUTOR)...");

                /*" -5020- DISPLAY 'FONTE: ' V1MCEF-COD-FONTE '  ' 'COD.: ' V1FUNC-COD-ANGAR '  ' 'BILHETE: ' V0BILH-NUMBIL */

                $"FONTE: {V1MCEF_COD_FONTE}  COD.: {V1FUNC_COD_ANGAR}  BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -5022- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5024- ADD +1 TO AC-I-V0PRODUTOR */
            AREA_DE_WORK.AC_I_V0PRODUTOR.Value = AREA_DE_WORK.AC_I_V0PRODUTOR + +1;

            /*" -5027- MOVE '3170' TO WNR-EXEC-SQL. */
            _.Move("3170", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5032- PERFORM R3000_00_ACUMULA_BILHETE_DB_UPDATE_2 */

            R3000_00_ACUMULA_BILHETE_DB_UPDATE_2();

            /*" -5035- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5036- DISPLAY 'R3170-00 (ERRO - UPDATE V0NUMERO_OUTROS)...' */
                _.Display($"R3170-00 (ERRO - UPDATE V0NUMERO_OUTROS)...");

                /*" -5037- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -5039- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5039- ADD +1 TO AC-U-V0NUMEROUT. */
            AREA_DE_WORK.AC_U_V0NUMEROUT.Value = AREA_DE_WORK.AC_U_V0NUMEROUT + +1;

            /*" -0- FLUXCONTROL_PERFORM R3000_90_CONTINUA */

            R3000_90_CONTINUA();

        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-1 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_1()
        {
            /*" -4570- EXEC SQL SELECT FONTE, NRRCAP, VLRCAP, SITUACAO, OPERACAO INTO :V0RCAP-FONTE, :V0RCAP-NRRCAP, :V2RCAP-VLRCAP, :V0RCAP-SITUACAO, :V0RCAP-OPERACAO FROM SEGUROS.V0RCAP WHERE NRTIT = :V0RCAP-NRTIT END-EXEC. */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1()
            {
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_FONTE, V0RCAP_FONTE);
                _.Move(executed_1.V0RCAP_NRRCAP, V0RCAP_NRRCAP);
                _.Move(executed_1.V2RCAP_VLRCAP, V2RCAP_VLRCAP);
                _.Move(executed_1.V0RCAP_SITUACAO, V0RCAP_SITUACAO);
                _.Move(executed_1.V0RCAP_OPERACAO, V0RCAP_OPERACAO);
            }


        }

        [StopWatch]
        /*" R3000-90-CONTINUA */
        private void R3000_90_CONTINUA(bool isPerform = false)
        {
            /*" -5076- MOVE '3172' TO WNR-EXEC-SQL. */
            _.Move("3172", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5081- PERFORM R3000_90_CONTINUA_DB_SELECT_1 */

            R3000_90_CONTINUA_DB_SELECT_1();

            /*" -5084- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5085- DISPLAY 'R3172-00 (ERRO - SELECT V1FONTE)...' */
                _.Display($"R3172-00 (ERRO - SELECT V1FONTE)...");

                /*" -5087- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5090- COMPUTE V1FONT-PROPAUTOM = V1FONT-PROPAUTOM + 1. */
            V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

            /*" -5090- MOVE '3173' TO WNR-EXEC-SQL. */
            _.Move("3173", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

        }

        [StopWatch]
        /*" R3000-90-CONTINUA-DB-SELECT-1 */
        public void R3000_90_CONTINUA_DB_SELECT_1()
        {
            /*" -5081- EXEC SQL SELECT PROPAUTOM INTO :V1FONT-PROPAUTOM FROM SEGUROS.V1FONTE WHERE FONTE = :V0BILH-FONTE END-EXEC. */

            var r3000_90_CONTINUA_DB_SELECT_1_Query1 = new R3000_90_CONTINUA_DB_SELECT_1_Query1()
            {
                V0BILH_FONTE = V0BILH_FONTE.ToString(),
            };

            var executed_1 = R3000_90_CONTINUA_DB_SELECT_1_Query1.Execute(r3000_90_CONTINUA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONT_PROPAUTOM, V1FONT_PROPAUTOM);
            }


        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-2 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_2()
        {
            /*" -4627- EXEC SQL SELECT BCOAVISO , AGEAVISO , NRAVISO , DATARCAP INTO :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-DATARCAP FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :WHOST-NRRCAP AND NRRCAPCO = 0 AND OPERACAO = :V0RCAP-OPERACAO AND SITUACAO = '0' END-EXEC. */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1()
            {
                V0RCAP_OPERACAO = V0RCAP_OPERACAO.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
                WHOST_NRRCAP = WHOST_NRRCAP.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RCAC_BCOAVISO, V1RCAC_BCOAVISO);
                _.Move(executed_1.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(executed_1.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
                _.Move(executed_1.V1RCAC_DATARCAP, V1RCAC_DATARCAP);
            }


        }

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO */
        private void R3000_91_LE_ENDOSSO(bool isPerform = false)
        {
            /*" -5101- PERFORM R3000_91_LE_ENDOSSO_DB_SELECT_1 */

            R3000_91_LE_ENDOSSO_DB_SELECT_1();

            /*" -5104- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5105- DISPLAY '(PROPOSTA DUPLICADO NA ENDOSSO)... ' */
                _.Display($"(PROPOSTA DUPLICADO NA ENDOSSO)... ");

                /*" -5106- DISPLAY ' FONTE    - ' V0BILH-FONTE */
                _.Display($" FONTE    - {V0BILH_FONTE}");

                /*" -5107- DISPLAY ' PROPOSTA - ' V1FONT-PROPAUTOM */
                _.Display($" PROPOSTA - {V1FONT_PROPAUTOM}");

                /*" -5109- COMPUTE V1FONT-PROPAUTOM = V1FONT-PROPAUTOM + 1 */
                V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

                /*" -5110- GO TO R3000-91-LE-ENDOSSO */
                new Task(() => R3000_91_LE_ENDOSSO()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -5111- ELSE */
            }
            else
            {


                /*" -5113- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -5114- ELSE */
                }
                else
                {


                    /*" -5115- DISPLAY 'R3173-00 (ERRO - SELECT V1ENDOSSO)... ' */
                    _.Display($"R3173-00 (ERRO - SELECT V1ENDOSSO)... ");

                    /*" -5117- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5120- MOVE '3174' TO WNR-EXEC-SQL. */
            _.Move("3174", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5124- PERFORM R3000_91_LE_ENDOSSO_DB_UPDATE_1 */

            R3000_91_LE_ENDOSSO_DB_UPDATE_1();

            /*" -5127- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5128- DISPLAY 'R3173-00 (ERRO - UPDATE V0FONTE)...' */
                _.Display($"R3173-00 (ERRO - UPDATE V0FONTE)...");

                /*" -5130- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5131- MOVE '9' TO V0BILH-SITUACAO. */
            _.Move("9", V0BILH_SITUACAO);

            /*" -5133- ADD 1 TO WWORK-NUM-ITENS. */
            AREA_DE_WORK.WWORK_NUM_ITENS.Value = AREA_DE_WORK.WWORK_NUM_ITENS + 1;

            /*" -5136- MOVE '3180' TO WNR-EXEC-SQL. */
            _.Move("3180", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5143- PERFORM R3000_91_LE_ENDOSSO_DB_UPDATE_2 */

            R3000_91_LE_ENDOSSO_DB_UPDATE_2();

            /*" -5146- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5147- DISPLAY 'R3180-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3180-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -5148- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -5150- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5155- ADD +1 TO WPROC-BILHETES WACC-PROCESSADOS. */
            AREA_DE_WORK.WPROC_BILHETES.Value = AREA_DE_WORK.WPROC_BILHETES + +1;
            AREA_DE_WORK.WACC_PROCESSADOS.Value = AREA_DE_WORK.WACC_PROCESSADOS + +1;

            /*" -5158- MOVE '3190' TO WNR-EXEC-SQL. */
            _.Move("3190", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5159- MOVE V0BILH-NUMBIL TO V0COFE-NUMBIL. */
            _.Move(V0BILH_NUMBIL, V0COFE_NUMBIL);

            /*" -5160- MOVE V0BILH-AGECOBR TO V0COFE-AGECOBR */
            _.Move(V0BILH_AGECOBR, V0COFE_AGECOBR);

            /*" -5161- MOVE V0BILH-NUM-MATR TO V0COFE-NUM-MATR */
            _.Move(V0BILH_NUM_MATR, V0COFE_NUM_MATR);

            /*" -5162- MOVE V0BILH-AGENCIA-DEB TO V0COFE-AGENCIA-DEB */
            _.Move(V0BILH_AGENCIA_DEB, V0COFE_AGENCIA_DEB);

            /*" -5163- MOVE V0BILH-OPERACAO-DEB TO V0COFE-OPERACAO-DEB */
            _.Move(V0BILH_OPERACAO_DEB, V0COFE_OPERACAO_DEB);

            /*" -5164- MOVE V0BILH-NUMCTA-DEB TO V0COFE-NUMCTA-DEB */
            _.Move(V0BILH_NUMCTA_DEB, V0COFE_NUMCTA_DEB);

            /*" -5165- MOVE V0BILH-DIGCTA-DEB TO V0COFE-DIGCTA-DEB */
            _.Move(V0BILH_DIGCTA_DEB, V0COFE_DIGCTA_DEB);

            /*" -5166- MOVE SPACES TO V0COFE-NOME-SIND */
            _.Move("", V0COFE_NOME_SIND);

            /*" -5168- MOVE '9' TO V0COFE-SITUACAO. */
            _.Move("9", V0COFE_SITUACAO);

            /*" -5180- PERFORM R3000_91_LE_ENDOSSO_DB_UPDATE_3 */

            R3000_91_LE_ENDOSSO_DB_UPDATE_3();

            /*" -5183- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5184- DISPLAY 'R3190-00 (ERRO - UPDATE V0COMISSAO_FENAE)...' */
                _.Display($"R3190-00 (ERRO - UPDATE V0COMISSAO_FENAE)...");

                /*" -5185- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -5187- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5189- ADD +1 TO AC-U-V0COMIFENAE. */
            AREA_DE_WORK.AC_U_V0COMIFENAE.Value = AREA_DE_WORK.AC_U_V0COMIFENAE + +1;

            /*" -5191- PERFORM R3200-00-BAIXA-RCAP. */

            R3200_00_BAIXA_RCAP_SECTION();

            /*" -5194- MOVE '3210' TO WNR-EXEC-SQL. */
            _.Move("3210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5204- PERFORM R3000_91_LE_ENDOSSO_DB_UPDATE_4 */

            R3000_91_LE_ENDOSSO_DB_UPDATE_4();

            /*" -5207- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5208- DISPLAY 'R3210-00 (ERRO - UPDATE V0RCAP)...' */
                _.Display($"R3210-00 (ERRO - UPDATE V0RCAP)...");

                /*" -5211- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'FONTE: ' V0RCAP-FONTE '  ' 'NRRCAP: ' V0RCAP-NRRCAP */

                $"BILHETE: {V0BILH_NUMBIL}  FONTE: {V0RCAP_FONTE}  NRRCAP: {V0RCAP_NRRCAP}"
                .Display();

                /*" -5213- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5218- ADD 1 TO AC-U-V0RCAP. */
            AREA_DE_WORK.AC_U_V0RCAP.Value = AREA_DE_WORK.AC_U_V0RCAP + 1;

            /*" -5221- MOVE '3220' TO WNR-EXEC-SQL. */
            _.Move("3220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5229- PERFORM R3000_91_LE_ENDOSSO_DB_SELECT_2 */

            R3000_91_LE_ENDOSSO_DB_SELECT_2();

            /*" -5232- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5233- DISPLAY 'R3220-00 - ERRO SELECT V0CLIENTE ' */
                _.Display($"R3220-00 - ERRO SELECT V0CLIENTE ");

                /*" -5234- DISPLAY 'BILHETE ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN */

                $"BILHETE {V0BILH_NUMBIL} {V0BILH_CODCLIEN}"
                .Display();

                /*" -5236- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5239- MOVE '3230' TO WNR-EXEC-SQL. */
            _.Move("3230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5241- MOVE V0BILH-CGCCPF TO V1CROT-CGCCPF */
            _.Move(V0BILH_CGCCPF, V1CROT_CGCCPF);

            /*" -5254- PERFORM R3000_91_LE_ENDOSSO_DB_SELECT_3 */

            R3000_91_LE_ENDOSSO_DB_SELECT_3();

            /*" -5257- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -5258- DISPLAY 'PROBLEMAS DE LEITURA CREDITO ROTATIVO' */
                _.Display($"PROBLEMAS DE LEITURA CREDITO ROTATIVO");

                /*" -5259- DISPLAY 'CODIGO DE ERRO ... ' SQLCODE */
                _.Display($"CODIGO DE ERRO ... {DB.SQLCODE}");

                /*" -5260- DISPLAY 'NR. BILHETE    ... ' V0BILH-NUMBIL */
                _.Display($"NR. BILHETE    ... {V0BILH_NUMBIL}");

                /*" -5261- DISPLAY 'NR. CGCCPF     ... ' V0BILH-CGCCPF */
                _.Display($"NR. CGCCPF     ... {V0BILH_CGCCPF}");

                /*" -5262- DISPLAY 'NAO FOI INCLUIDO NA TAB. CLIENTE_CROT' */
                _.Display($"NAO FOI INCLUIDO NA TAB. CLIENTE_CROT");

                /*" -5264- DISPLAY 'BILHETE EMITIDO. PROCESSAMENTO CONTINUA' . */
                _.Display($"BILHETE EMITIDO. PROCESSAMENTO CONTINUA");
            }


            /*" -5265- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5267- IF V0BILH-RAMO EQUAL 82 OR 81 */

                if (V0BILH_RAMO.In("82", "81"))
                {

                    /*" -5268- PERFORM R3240-00-UPDATE-CROT-AP */

                    R3240_00_UPDATE_CROT_AP_SECTION();

                    /*" -5269- ELSE */
                }
                else
                {


                    /*" -5270- PERFORM R3250-00-UPDATE-CROT-RES */

                    R3250_00_UPDATE_CROT_RES_SECTION();

                    /*" -5271- ELSE */
                }

            }
            else
            {


                /*" -5273- IF V0BILH-RAMO EQUAL 82 OR 81 */

                if (V0BILH_RAMO.In("82", "81"))
                {

                    /*" -5274- MOVE 'S' TO V0CROT-BILH-AP */
                    _.Move("S", V0CROT_BILH_AP);

                    /*" -5275- MOVE 'N' TO V0CROT-BILH-RES */
                    _.Move("N", V0CROT_BILH_RES);

                    /*" -5276- ELSE */
                }
                else
                {


                    /*" -5277- MOVE 'N' TO V0CROT-BILH-AP */
                    _.Move("N", V0CROT_BILH_AP);

                    /*" -5278- MOVE 'S' TO V0CROT-BILH-RES */
                    _.Move("S", V0CROT_BILH_RES);

                    /*" -5279- END-IF */
                }


                /*" -5290- PERFORM R3260-00-INSERT-V0CLIEN-CROT. */

                R3260_00_INSERT_V0CLIEN_CROT_SECTION();
            }


        }

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO-DB-SELECT-1 */
        public void R3000_91_LE_ENDOSSO_DB_SELECT_1()
        {
            /*" -5101- EXEC SQL SELECT NRPROPOS INTO :V0ENDO-NRPROPOS FROM SEGUROS.V1ENDOSSO WHERE FONTE = :V0BILH-FONTE AND NRPROPOS = :V1FONT-PROPAUTOM WITH UR END-EXEC. */

            var r3000_91_LE_ENDOSSO_DB_SELECT_1_Query1 = new R3000_91_LE_ENDOSSO_DB_SELECT_1_Query1()
            {
                V1FONT_PROPAUTOM = V1FONT_PROPAUTOM.ToString(),
                V0BILH_FONTE = V0BILH_FONTE.ToString(),
            };

            var executed_1 = R3000_91_LE_ENDOSSO_DB_SELECT_1_Query1.Execute(r3000_91_LE_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_NRPROPOS, V0ENDO_NRPROPOS);
            }


        }

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO-DB-UPDATE-1 */
        public void R3000_91_LE_ENDOSSO_DB_UPDATE_1()
        {
            /*" -5124- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V1FONT-PROPAUTOM WHERE FONTE = :V0BILH-FONTE END-EXEC. */

            var r3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1 = new R3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1()
            {
                V1FONT_PROPAUTOM = V1FONT_PROPAUTOM.ToString(),
                V0BILH_FONTE = V0BILH_FONTE.ToString(),
            };

            R3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1.Execute(r3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-3 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_3()
        {
            /*" -4686- EXEC SQL SELECT AGECOBR, DTQITBCO INTO :V1COFE-AGECOBR, :V1COFE-DTQITBCO FROM SEGUROS.V1COMISSAO_FENAE WHERE NUMBIL = :V1COFE-NUMBIL WITH UR END-EXEC. */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1()
            {
                V1COFE_NUMBIL = V1COFE_NUMBIL.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1COFE_AGECOBR, V1COFE_AGECOBR);
                _.Move(executed_1.V1COFE_DTQITBCO, V1COFE_DTQITBCO);
            }


        }

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO-DB-UPDATE-2 */
        public void R3000_91_LE_ENDOSSO_DB_UPDATE_2()
        {
            /*" -5143- EXEC SQL UPDATE SEGUROS.V0BILHETE SET NUM_APOLICE = :V0APOL-NUM-APOL, SITUACAO = :V0BILH-SITUACAO, COD_USUARIO = 'CB2005B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1 = new R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1()
            {
                V0APOL_NUM_APOL = V0APOL_NUM_APOL.ToString(),
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1.Execute(r3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO-DB-UPDATE-3 */
        public void R3000_91_LE_ENDOSSO_DB_UPDATE_3()
        {
            /*" -5180- EXEC SQL UPDATE SEGUROS.V0COMISSAO_FENAE SET AGECOBR = :V0COFE-AGECOBR , NUM_MATRICULA = :V0COFE-NUM-MATR , COD_AGENCIA_DEB = :V0COFE-AGENCIA-DEB , OPERACAO_DEB = :V0COFE-OPERACAO-DEB , NUM_CONTA_DEB = :V0COFE-NUMCTA-DEB , DIG_CONTA_DEB = :V0COFE-DIGCTA-DEB , NOM_SINDICO = :V0COFE-NOME-SIND , SITUACAO = :V0COFE-SITUACAO , TIMESTAMP = CURRENT TIMESTAMP WHERE NUMBIL = :V0COFE-NUMBIL END-EXEC. */

            var r3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1 = new R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1()
            {
                V0COFE_OPERACAO_DEB = V0COFE_OPERACAO_DEB.ToString(),
                V0COFE_AGENCIA_DEB = V0COFE_AGENCIA_DEB.ToString(),
                V0COFE_NUMCTA_DEB = V0COFE_NUMCTA_DEB.ToString(),
                V0COFE_DIGCTA_DEB = V0COFE_DIGCTA_DEB.ToString(),
                V0COFE_NOME_SIND = V0COFE_NOME_SIND.ToString(),
                V0COFE_NUM_MATR = V0COFE_NUM_MATR.ToString(),
                V0COFE_SITUACAO = V0COFE_SITUACAO.ToString(),
                V0COFE_AGECOBR = V0COFE_AGECOBR.ToString(),
                V0COFE_NUMBIL = V0COFE_NUMBIL.ToString(),
            };

            R3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1.Execute(r3000_91_LE_ENDOSSO_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO-DB-SELECT-2 */
        public void R3000_91_LE_ENDOSSO_DB_SELECT_2()
        {
            /*" -5229- EXEC SQL SELECT CGCCPF, NOME_RAZAO INTO :V0BILH-CGCCPF, :V0BILH-NOME FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0BILH-CODCLIEN WITH UR END-EXEC. */

            var r3000_91_LE_ENDOSSO_DB_SELECT_2_Query1 = new R3000_91_LE_ENDOSSO_DB_SELECT_2_Query1()
            {
                V0BILH_CODCLIEN = V0BILH_CODCLIEN.ToString(),
            };

            var executed_1 = R3000_91_LE_ENDOSSO_DB_SELECT_2_Query1.Execute(r3000_91_LE_ENDOSSO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BILH_CGCCPF, V0BILH_CGCCPF);
                _.Move(executed_1.V0BILH_NOME, V0BILH_NOME);
            }


        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-4 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_4()
        {
            /*" -4720- EXEC SQL SELECT COD_ESCNEG INTO :V1ACEF-CODESCNEG FROM SEGUROS.V1AGENCIACEF WHERE COD_AGENCIA = :V0BILH-AGECOBR WITH UR END-EXEC. */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_4_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_4_Query1()
            {
                V0BILH_AGECOBR = V0BILH_AGECOBR.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_4_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ACEF_CODESCNEG, V1ACEF_CODESCNEG);
            }


        }

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO-DB-SELECT-3 */
        public void R3000_91_LE_ENDOSSO_DB_SELECT_3()
        {
            /*" -5254- EXEC SQL SELECT CGCCPF , BILH_AP , BILH_RES , BILH_VDAZUL , DTMOVABE INTO :V1CROT-CGCCPF , :V1CROT-BILH-AP , :V1CROT-BILH-RES , :V1CROT-BILH-VDAZUL , :V1CROT-DTMOVABE FROM SEGUROS.V1CLIENTE_CROT WHERE CGCCPF = :V0BILH-CGCCPF END-EXEC. */

            var r3000_91_LE_ENDOSSO_DB_SELECT_3_Query1 = new R3000_91_LE_ENDOSSO_DB_SELECT_3_Query1()
            {
                V0BILH_CGCCPF = V0BILH_CGCCPF.ToString(),
            };

            var executed_1 = R3000_91_LE_ENDOSSO_DB_SELECT_3_Query1.Execute(r3000_91_LE_ENDOSSO_DB_SELECT_3_Query1);
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
        /*" R3000-91-LE-ENDOSSO-DB-UPDATE-4 */
        public void R3000_91_LE_ENDOSSO_DB_UPDATE_4()
        {
            /*" -5204- EXEC SQL UPDATE SEGUROS.V0RCAP SET SITUACAO = '1' , OPERACAO = 220 , NUM_APOLICE = :V0APOL-NUM-APOL , NRENDOS = 0, NRPARCEL = 0, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC. */

            var r3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1 = new R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1()
            {
                V0APOL_NUM_APOL = V0APOL_NUM_APOL.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1.Execute(r3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1);

        }

        [StopWatch]
        /*" R3020-00-UPDATE-V0BILHETE-SECTION */
        private void R3020_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -5301- MOVE '3020' TO WNR-EXEC-SQL. */
            _.Move("3020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5307- PERFORM R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -5310- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5311- DISPLAY 'R3020-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3020-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -5312- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -5314- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5314- ADD +1 TO AC-U-V0BILHETE. */
            AREA_DE_WORK.AC_U_V0BILHETE.Value = AREA_DE_WORK.AC_U_V0BILHETE + +1;

        }

        [StopWatch]
        /*" R3020-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -5307- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO, TIMESTAMP = CURRENT TIMESTAMP, COD_USUARIO = 'CB2005B' WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-5 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_5()
        {
            /*" -4746- EXEC SQL SELECT COD_FONTE INTO :V1MCEF-COD-FONTE FROM SEGUROS.V1MALHACEF WHERE COD_SUREG = :V1ACEF-CODESCNEG WITH UR END-EXEC. */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_5_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_5_Query1()
            {
                V1ACEF_CODESCNEG = V1ACEF_CODESCNEG.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_5_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MCEF_COD_FONTE, V1MCEF_COD_FONTE);
            }


        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-UPDATE-1 */
        public void R3000_00_ACUMULA_BILHETE_DB_UPDATE_1()
        {
            /*" -4941- EXEC SQL UPDATE SEGUROS.V0FUNCIOCEF SET COD_ANGARIADOR = :V1FUNC-COD-ANGAR WHERE NUM_MATRICULA = :V1FUNC-NUM-MATRIC AND NUM_CPF = :V1FUNC-NUM-CPF END-EXEC. */

            var r3000_00_ACUMULA_BILHETE_DB_UPDATE_1_Update1 = new R3000_00_ACUMULA_BILHETE_DB_UPDATE_1_Update1()
            {
                V1FUNC_COD_ANGAR = V1FUNC_COD_ANGAR.ToString(),
                V1FUNC_NUM_MATRIC = V1FUNC_NUM_MATRIC.ToString(),
                V1FUNC_NUM_CPF = V1FUNC_NUM_CPF.ToString(),
            };

            R3000_00_ACUMULA_BILHETE_DB_UPDATE_1_Update1.Execute(r3000_00_ACUMULA_BILHETE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-INSERT-1 */
        public void R3000_00_ACUMULA_BILHETE_DB_INSERT_1()
        {
            /*" -5013- EXEC SQL INSERT INTO SEGUROS.V0PRODUTOR VALUES (:V1MCEF-COD-FONTE , :V1FUNC-COD-ANGAR , '3' , :V1FUNC-NOME-FUN , :V1FUNC-NUM-MATRIC , 0 , ' ' , :V1PROD-ENDERECO , ' ' , :V1PROD-CIDADE , :V1FUNC-SIGLA-UF , :V1FUNC-CEP , 0 , 0 , 0 , ' ' , ' ' , 0 , :V1FUNC-NUM-CPF , 0 , 0 , 'F' , 'S' , :V1SURG-PCDESISS , ' ' , ' ' , 104 , :V0BILH-AGENCIA , 0 , '0' , 0 , 0 , 0 , 0 , :V1SIST-DTMOVACB , :V1SIST-DTMOVACB , :V1SIST-DTMOVACB , :WHOST-NUMREC , 0 , '0' , NULL , CURRENT TIMESTAMP) END-EXEC. */

            var r3000_00_ACUMULA_BILHETE_DB_INSERT_1_Insert1 = new R3000_00_ACUMULA_BILHETE_DB_INSERT_1_Insert1()
            {
                V1MCEF_COD_FONTE = V1MCEF_COD_FONTE.ToString(),
                V1FUNC_COD_ANGAR = V1FUNC_COD_ANGAR.ToString(),
                V1FUNC_NOME_FUN = V1FUNC_NOME_FUN.ToString(),
                V1FUNC_NUM_MATRIC = V1FUNC_NUM_MATRIC.ToString(),
                V1PROD_ENDERECO = V1PROD_ENDERECO.ToString(),
                V1PROD_CIDADE = V1PROD_CIDADE.ToString(),
                V1FUNC_SIGLA_UF = V1FUNC_SIGLA_UF.ToString(),
                V1FUNC_CEP = V1FUNC_CEP.ToString(),
                V1FUNC_NUM_CPF = V1FUNC_NUM_CPF.ToString(),
                V1SURG_PCDESISS = V1SURG_PCDESISS.ToString(),
                V0BILH_AGENCIA = V0BILH_AGENCIA.ToString(),
                V1SIST_DTMOVACB = V1SIST_DTMOVACB.ToString(),
                WHOST_NUMREC = WHOST_NUMREC.ToString(),
            };

            R3000_00_ACUMULA_BILHETE_DB_INSERT_1_Insert1.Execute(r3000_00_ACUMULA_BILHETE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-UPDATE-2 */
        public void R3000_00_ACUMULA_BILHETE_DB_UPDATE_2()
        {
            /*" -5032- EXEC SQL UPDATE SEGUROS.V0NUMERO_OUTROS SET CODANGAR = CODANGAR + 1 WHERE CODANGAR = :V1NOUT-CODANGAR END-EXEC. */

            var r3000_00_ACUMULA_BILHETE_DB_UPDATE_2_Update1 = new R3000_00_ACUMULA_BILHETE_DB_UPDATE_2_Update1()
            {
                V1NOUT_CODANGAR = V1NOUT_CODANGAR.ToString(),
            };

            R3000_00_ACUMULA_BILHETE_DB_UPDATE_2_Update1.Execute(r3000_00_ACUMULA_BILHETE_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-6 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_6()
        {
            /*" -4796- EXEC SQL SELECT COBERTURA1 , COBERTURA2 , COBERTURA3 INTO :V1COBI-COBERTURA1 , :V1COBI-COBERTURA2 , :V1COBI-COBERTURA3 FROM SEGUROS.V1COMERC_BILHETE WHERE COD_ESCNEG = :V1COBI-COD-ESCNEG AND RAMO = :V1COBI-RAMO AND DTINIVIG <= :V1COBI-DTINIVIG AND DTTERVIG >= :V1COBI-DTINIVIG WITH UR END-EXEC. */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_6_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_6_Query1()
            {
                V1COBI_COD_ESCNEG = V1COBI_COD_ESCNEG.ToString(),
                V1COBI_DTINIVIG = V1COBI_DTINIVIG.ToString(),
                V1COBI_RAMO = V1COBI_RAMO.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_6_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1COBI_COBERTURA1, V1COBI_COBERTURA1);
                _.Move(executed_1.V1COBI_COBERTURA2, V1COBI_COBERTURA2);
                _.Move(executed_1.V1COBI_COBERTURA3, V1COBI_COBERTURA3);
            }


        }

        [StopWatch]
        /*" R3040-00-MONTA-V0BILHETE-SECTION */
        private void R3040_00_MONTA_V0BILHETE_SECTION()
        {
            /*" -5326- MOVE '3040' TO WNR-EXEC-SQL. */
            _.Move("3040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5328- IF (V0BILH-DTQITBCO NOT EQUAL V1RCAC-DATARCAP) */

            if ((V0BILH_DTQITBCO != V1RCAC_DATARCAP))
            {

                /*" -5329- MOVE 11901 TO V0BILER-COD-ERRO */
                _.Move(11901, V0BILER_COD_ERRO);

                /*" -5331- PERFORM R3045-00-GRAVA-TAB-ERRO. */

                R3045_00_GRAVA_TAB_ERRO_SECTION();
            }


            /*" -5333- IF (V0BILH-VLRCAP NOT EQUAL V2RCAP-VLRCAP) */

            if ((V0BILH_VLRCAP != V2RCAP_VLRCAP))
            {

                /*" -5334- MOVE 12101 TO V0BILER-COD-ERRO */
                _.Move(12101, V0BILER_COD_ERRO);

                /*" -5334- PERFORM R3045-00-GRAVA-TAB-ERRO. */

                R3045_00_GRAVA_TAB_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-7 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_7()
        {
            /*" -4849- EXEC SQL SELECT NUM_MATRICULA , NOME_FUNCIONARIO , ENDERECO_CEF , CIDADE_CEF , SIGLA_UF , CEP , NUM_CPF , COD_ANGARIADOR INTO :V1FUNC-NUM-MATRIC , :V1FUNC-NOME-FUN , :V1FUNC-ENDERECO , :V1FUNC-CIDADE , :V1FUNC-SIGLA-UF , :V1FUNC-CEP , :V1FUNC-NUM-CPF , :V1FUNC-COD-ANGAR:VIND-COD-ANGAR FROM SEGUROS.V1FUNCIOCEF WHERE NUM_MATRICULA = :V0BILH-NUM-MATR END-EXEC. */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_7_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_7_Query1()
            {
                V0BILH_NUM_MATR = V0BILH_NUM_MATR.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_7_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FUNC_NUM_MATRIC, V1FUNC_NUM_MATRIC);
                _.Move(executed_1.V1FUNC_NOME_FUN, V1FUNC_NOME_FUN);
                _.Move(executed_1.V1FUNC_ENDERECO, V1FUNC_ENDERECO);
                _.Move(executed_1.V1FUNC_CIDADE, V1FUNC_CIDADE);
                _.Move(executed_1.V1FUNC_SIGLA_UF, V1FUNC_SIGLA_UF);
                _.Move(executed_1.V1FUNC_CEP, V1FUNC_CEP);
                _.Move(executed_1.V1FUNC_NUM_CPF, V1FUNC_NUM_CPF);
                _.Move(executed_1.V1FUNC_COD_ANGAR, V1FUNC_COD_ANGAR);
                _.Move(executed_1.VIND_COD_ANGAR, VIND_COD_ANGAR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3040_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-8 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_8()
        {
            /*" -4886- EXEC SQL SELECT CODANGAR INTO :V1NOUT-CODANGAR FROM SEGUROS.V1NUMERO_OUTROS END-EXEC. */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_8_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_8_Query1()
            {
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_8_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1NOUT_CODANGAR, V1NOUT_CODANGAR);
            }


        }

        [StopWatch]
        /*" R3045-00-GRAVA-TAB-ERRO-SECTION */
        private void R3045_00_GRAVA_TAB_ERRO_SECTION()
        {
            /*" -5345- MOVE '3045' TO WNR-EXEC-SQL. */
            _.Move("3045", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5347- ADD 1 TO WS-I-ERRO */
            WS_I_ERRO.Value = WS_I_ERRO + 1;

            /*" -5348- MOVE V0BILER-COD-ERRO TO TB-ERRO-CERT(WS-I-ERRO) */
            _.Move(V0BILER_COD_ERRO, WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT);

            /*" -5348- . */

        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-9 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_9()
        {
            /*" -4913- EXEC SQL SELECT B.PCDESISS INTO :V1SURG-PCDESISS FROM SEGUROS.V1AGENCIACEF A, SEGUROS.V1SUREG B WHERE A.COD_AGENCIA = :V1COFE-AGECOBR AND B.COD_SUREG = A.COD_ESCNEG WITH UR END-EXEC. */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_9_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_9_Query1()
            {
                V1COFE_AGECOBR = V1COFE_AGECOBR.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_9_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_9_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SURG_PCDESISS, V1SURG_PCDESISS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3045_99_SAIDA*/

        [StopWatch]
        /*" R3050-00-INSERE-ERRO-SECTION */
        private void R3050_00_INSERE_ERRO_SECTION()
        {
            /*" -5360- MOVE '3050' TO WNR-EXEC-SQL. */
            _.Move("3050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5362- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -5363- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -5364- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -5365- MOVE V0BILH-NUMBIL TO LK-VG001-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -5366- MOVE TB-ERRO-CERT(WS-I-ERRO) TO LK-VG001-COD-MSG-CRITICA */
            _.Move(WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -5367- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -5368- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -5369- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -5370- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -5371- MOVE 'CB2005B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("CB2005B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -5372- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -5373- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -5374- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -5377- MOVE 'INSERCAO DE ERRO NA EMISSAO DA PROPOSTA' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("INSERCAO DE ERRO NA EMISSAO DA PROPOSTA", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -5379- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -5380- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -5381- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -5385- DISPLAY 'ERRO JAH GRAVADO 3050 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 3050 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -5386- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -5387- ELSE */
                }
                else
                {


                    /*" -5388- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -5389- DISPLAY '* 3050 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 3050 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -5390- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -5391- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -5392- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -5393- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -5394- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -5395- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -5396- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -5398- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -5399- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -5400- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5401- END-IF */
                }


                /*" -5403- END-IF */
            }


            /*" -5405- ADD 1 TO WS-I-ERRO */
            WS_I_ERRO.Value = WS_I_ERRO + 1;

            /*" -5406- IF TB-ERRO-CERT(WS-I-ERRO) EQUAL ZEROS */

            if (WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT == 00)
            {

                /*" -5407- MOVE 'N' TO WS-FLAG-TEM-ERRO */
                _.Move("N", WS_FLAG_TEM_ERRO);

                /*" -5408- END-IF */
            }


            /*" -5408- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3050_99_SAIDA*/

        [StopWatch]
        /*" R3080-00-UPDATE-V0BILHETE-SECTION */
        private void R3080_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -5435- MOVE '3080' TO WNR-EXEC-SQL. */
            _.Move("3080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5440- PERFORM R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -5443- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5444- DISPLAY 'R3080-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3080-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -5445- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -5448- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5450- MOVE 10205 TO V0BILER-COD-ERRO. */
            _.Move(10205, V0BILER_COD_ERRO);

            /*" -5450- PERFORM R3045-00-GRAVA-TAB-ERRO. */

            R3045_00_GRAVA_TAB_ERRO_SECTION();

        }

        [StopWatch]
        /*" R3080-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -5440- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO, COD_USUARIO = 'CB2005B' WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r3080_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r3080_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3080_99_SAIDA*/

        [StopWatch]
        /*" R3090-00-UPDATE-V0BILHETE-SECTION */
        private void R3090_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -5462- MOVE '3090' TO WNR-EXEC-SQL. */
            _.Move("3090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5467- PERFORM R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -5470- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5471- DISPLAY 'R3090-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3090-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -5472- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -5472- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3090-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -5467- EXEC SQL UPDATE SEGUROS.V0BILHETE SET FONTE = :V1MCEF-COD-FONTE, COD_USUARIO = 'CB2005B' WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r3090_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V1MCEF_COD_FONTE = V1MCEF_COD_FONTE.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r3090_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3090_99_SAIDA*/

        [StopWatch]
        /*" R3095-00-UPDATE-V0BILHETE-SECTION */
        private void R3095_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -5484- MOVE '3095' TO WNR-EXEC-SQL. */
            _.Move("3095", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5489- PERFORM R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -5492- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5493- DISPLAY 'R3095-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3095-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -5494- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -5494- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3095-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -5489- EXEC SQL UPDATE SEGUROS.V0BILHETE SET AGECOBR = :V1COFE-AGECOBR, COD_USUARIO = 'CB2005B' WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V1COFE_AGECOBR = V1COFE_AGECOBR.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r3095_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3095_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-INSERT-V0BIL-CC00396-SECTION */
        private void R3110_00_INSERT_V0BIL_CC00396_SECTION()
        {
            /*" -5506- MOVE '3110' TO WNR-EXEC-SQL. */
            _.Move("3110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5507- MOVE V0BILH-NUMBIL TO V0C396-NUMBIL */
            _.Move(V0BILH_NUMBIL, V0C396_NUMBIL);

            /*" -5508- MOVE V1SIST-DTMOVACB TO V0C396-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0C396_DTMOVTO);

            /*" -5510- MOVE '0' TO V0C396-SITUACAO */
            _.Move("0", V0C396_SITUACAO);

            /*" -5516- PERFORM R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1 */

            R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1();

            /*" -5519- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5521- IF SQLCODE EQUAL -803 NEXT SENTENCE */

                if (DB.SQLCODE == -803)
                {

                    /*" -5522- ELSE */
                }
                else
                {


                    /*" -5526- DISPLAY '3110-00 (ERRO - INSERT TABELA V0BIL_CC00396)..' 'NUMBIL : ' V0C396-NUMBIL '  ' 'DTMOVTO: ' V0C396-DTMOVTO '  ' 'SITUACAO: ' V0C396-SITUACAO */

                    $"3110-00 (ERRO - INSERT TABELA V0BIL_CC00396)..NUMBIL : {V0C396_NUMBIL}  DTMOVTO: {V0C396_DTMOVTO}  SITUACAO: {V0C396_SITUACAO}"
                    .Display();

                    /*" -5526- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3110-00-INSERT-V0BIL-CC00396-DB-INSERT-1 */
        public void R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1()
        {
            /*" -5516- EXEC SQL INSERT INTO SEGUROS.V0BIL_CC00396 VALUES (:V0C396-NUMBIL , :V0C396-DTMOVTO , :V0C396-SITUACAO, CURRENT TIMESTAMP) END-EXEC. */

            var r3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1 = new R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1()
            {
                V0C396_NUMBIL = V0C396_NUMBIL.ToString(),
                V0C396_DTMOVTO = V0C396_DTMOVTO.ToString(),
                V0C396_SITUACAO = V0C396_SITUACAO.ToString(),
            };

            R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1.Execute(r3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3110_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-BAIXA-RCAP-SECTION */
        private void R3200_00_BAIXA_RCAP_SECTION()
        {
            /*" -5535- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R3200_10_DECLARE_V0RCAPCOMP */

            R3200_10_DECLARE_V0RCAPCOMP();

        }

        [StopWatch]
        /*" R3200-10-DECLARE-V0RCAPCOMP */
        private void R3200_10_DECLARE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -5561- PERFORM R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1 */

            R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1();

            /*" -5563- PERFORM R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1 */

            R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1();

        }

        [StopWatch]
        /*" R3200-10-DECLARE-V0RCAPCOMP-DB-OPEN-1 */
        public void R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1()
        {
            /*" -5563- EXEC SQL OPEN V1RCAPCOMP END-EXEC. */

            V1RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R8100-00-DECLARE-CBO-DB-DECLARE-1 */
        public void R8100_00_DECLARE_CBO_DB_DECLARE_1()
        {
            /*" -6392- EXEC SQL DECLARE CCBO CURSOR FOR SELECT COD_CBO, DESCR_CBO FROM SEGUROS.CBO WHERE COD_CBO BETWEEN 001 AND 999 ORDER BY COD_CBO WITH UR END-EXEC. */
            CCBO = new CB2005B_CCBO(false);
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
        /*" R3200-20-FETCH-V0RCAPCOMP */
        private void R3200_20_FETCH_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -5570- MOVE '3201' TO WNR-EXEC-SQL. */
            _.Move("3201", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5585- PERFORM R3200_20_FETCH_V0RCAPCOMP_DB_FETCH_1 */

            R3200_20_FETCH_V0RCAPCOMP_DB_FETCH_1();

            /*" -5588- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5589- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5589- PERFORM R3200_20_FETCH_V0RCAPCOMP_DB_CLOSE_1 */

                    R3200_20_FETCH_V0RCAPCOMP_DB_CLOSE_1();

                    /*" -5591- GO TO R3200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                    return;

                    /*" -5592- ELSE */
                }
                else
                {


                    /*" -5593- DISPLAY 'R3200-20 (PROBLEMAS FETCH V1RCAPCOMP)... ' */
                    _.Display($"R3200-20 (PROBLEMAS FETCH V1RCAPCOMP)... ");

                    /*" -5596- DISPLAY 'FONTE: ' V0RCAP-FONTE '  ' 'RECIBO: ' V0RCAP-NRRCAP '  ' 'BILHETE: ' V0BILH-NUMBIL */

                    $"FONTE: {V0RCAP_FONTE}  RECIBO: {V0RCAP_NRRCAP}  BILHETE: {V0BILH_NUMBIL}"
                    .Display();

                    /*" -5601- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5602- IF V1RCAC-SITUACAO NOT EQUAL '0' */

            if (V1RCAC_SITUACAO != "0")
            {

                /*" -5604- GO TO R3200-20-FETCH-V0RCAPCOMP. */
                new Task(() => R3200_20_FETCH_V0RCAPCOMP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -5606- IF V1RCAC-OPERACAO GREATER 199 AND V1RCAC-OPERACAO LESS 300 */

            if (V1RCAC_OPERACAO > 199 && V1RCAC_OPERACAO < 300)
            {

                /*" -5608- GO TO R3200-20-FETCH-V0RCAPCOMP. */
                new Task(() => R3200_20_FETCH_V0RCAPCOMP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -5610- IF V1RCAC-OPERACAO GREATER 399 AND V1RCAC-OPERACAO LESS 500 */

            if (V1RCAC_OPERACAO > 399 && V1RCAC_OPERACAO < 500)
            {

                /*" -5610- GO TO R3200-20-FETCH-V0RCAPCOMP. */
                new Task(() => R3200_20_FETCH_V0RCAPCOMP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }

        [StopWatch]
        /*" R3200-20-FETCH-V0RCAPCOMP-DB-FETCH-1 */
        public void R3200_20_FETCH_V0RCAPCOMP_DB_FETCH_1()
        {
            /*" -5585- EXEC SQL FETCH V1RCAPCOMP INTO :V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1RCAC-DTMOVTO , :V1RCAC-HORAOPER , :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB END-EXEC. */

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
            /*" -5589- EXEC SQL CLOSE V1RCAPCOMP END-EXEC */

            V1RCAPCOMP.Close();

        }

        [StopWatch]
        /*" R3200-30-UPDATE-V0RCAPCOMP */
        private void R3200_30_UPDATE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -5620- MOVE '3202' TO WNR-EXEC-SQL. */
            _.Move("3202", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5630- PERFORM R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1 */

            R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1();

            /*" -5633- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5634- DISPLAY 'R3200-30 (ERRO - UPDATE V0RCAPCOMP)...' */
                _.Display($"R3200-30 (ERRO - UPDATE V0RCAPCOMP)...");

                /*" -5637- DISPLAY 'FONTE: ' V1RCAC-FONTE ' ' 'RECIBO: ' V1RCAC-NRRCAP 'BILHETE: ' V0BILH-NUMBIL */

                $"FONTE: {V1RCAC_FONTE} RECIBO: {V1RCAC_NRRCAP}BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -5639- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5639- ADD +1 TO AC-U-V0RCAPCOMP. */
            AREA_DE_WORK.AC_U_V0RCAPCOMP.Value = AREA_DE_WORK.AC_U_V0RCAPCOMP + +1;

        }

        [StopWatch]
        /*" R3200-30-UPDATE-V0RCAPCOMP-DB-UPDATE-1 */
        public void R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1()
        {
            /*" -5630- EXEC SQL UPDATE SEGUROS.V0RCAPCOMP SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1RCAC-FONTE AND NRRCAP = :V1RCAC-NRRCAP AND NRRCAPCO = :V1RCAC-NRRCAPCO AND OPERACAO = :V1RCAC-OPERACAO AND DTMOVTO = :V1RCAC-DTMOVTO AND HORAOPER = :V1RCAC-HORAOPER END-EXEC. */

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
            /*" -5646- MOVE '3203' TO WNR-EXEC-SQL. */
            _.Move("3203", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5647- MOVE '0' TO V1RCAC-SITCONTB */
            _.Move("0", V1RCAC_SITCONTB);

            /*" -5648- MOVE '0' TO V1RCAC-SITUACAO */
            _.Move("0", V1RCAC_SITUACAO);

            /*" -5649- MOVE 220 TO V1RCAC-OPERACAO */
            _.Move(220, V1RCAC_OPERACAO);

            /*" -5650- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -5651- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -5652- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -5653- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -5655- MOVE WS000-HORA-TIME TO V1RCAC-HORAOPER. */
            _.Move(WS000_HORA_TIME, V1RCAC_HORAOPER);

            /*" -5673- PERFORM R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1 */

            R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1();

            /*" -5676- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5677- DISPLAY 'R3200-40 (ERRO - INSERT V0RCAPCOMP)...' */
                _.Display($"R3200-40 (ERRO - INSERT V0RCAPCOMP)...");

                /*" -5680- DISPLAY 'BILHETE:  ' V0BILH-NUMBIL '  ' 'AGENCIA:  ' V1RCAC-AGEAVISO '  ' 'BANCO:    ' V1RCAC-BCOAVISO */

                $"BILHETE:  {V0BILH_NUMBIL}  AGENCIA:  {V1RCAC_AGEAVISO}  BANCO:    {V1RCAC_BCOAVISO}"
                .Display();

                /*" -5683- DISPLAY 'DATARCAP: ' V1RCAC-DATARCAP '  ' 'FONTE:    ' V1RCAC-FONTE '  ' 'NRRCAP:   ' V1RCAC-NRRCAP */

                $"DATARCAP: {V1RCAC_DATARCAP}  FONTE:    {V1RCAC_FONTE}  NRRCAP:   {V1RCAC_NRRCAP}"
                .Display();

                /*" -5685- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5688- ADD 1 TO AC-I-V0RCAPCOMP. */
            AREA_DE_WORK.AC_I_V0RCAPCOMP.Value = AREA_DE_WORK.AC_I_V0RCAPCOMP + 1;

        }

        [StopWatch]
        /*" R3200-40-INSERT-V0RCAPCOMP-DB-INSERT-1 */
        public void R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -5673- EXEC SQL INSERT INTO SEGUROS.V0RCAPCOMP VALUES (:V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1SIST-DTMOVACB , :V1RCAC-HORAOPER , :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB , :V1RCAC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -5695- MOVE '3204' TO WNR-EXEC-SQL. */
            _.Move("3204", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5702- PERFORM R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1 */

            R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1();

            /*" -5706- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -5710- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5710- GO TO R3200-20-FETCH-V0RCAPCOMP. */

            R3200_20_FETCH_V0RCAPCOMP(); //GOTO
            return;

        }

        [StopWatch]
        /*" R3200-50-UPDATE-V0AVISOSALDO-DB-UPDATE-1 */
        public void R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1()
        {
            /*" -5702- EXEC SQL UPDATE SEGUROS.V0AVISOS_SALDOS SET SDOATU = (SDOATU - :V1RCAC-VLRCAP) WHERE BCOAVISO = :V1RCAC-BCOAVISO AND AGEAVISO = :V1RCAC-AGEAVISO AND NRAVISO = :V1RCAC-NRAVISO END-EXEC. */

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
        /*" R3240-00-UPDATE-CROT-AP-SECTION */
        private void R3240_00_UPDATE_CROT_AP_SECTION()
        {
            /*" -5722- MOVE '3240' TO WNR-EXEC-SQL. */
            _.Move("3240", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5724- MOVE 'S' TO V0CROT-BILH-AP */
            _.Move("S", V0CROT_BILH_AP);

            /*" -5725- IF V1CROT-DTMOVABE < V1SIST-DTMOVACB */

            if (V1CROT_DTMOVABE < V1SIST_DTMOVACB)
            {

                /*" -5726- MOVE V1SIST-DTMOVACB TO V0CROT-DTMOVABE */
                _.Move(V1SIST_DTMOVACB, V0CROT_DTMOVABE);

                /*" -5727- ELSE */
            }
            else
            {


                /*" -5729- MOVE V1CROT-DTMOVABE TO V0CROT-DTMOVABE. */
                _.Move(V1CROT_DTMOVABE, V0CROT_DTMOVABE);
            }


            /*" -5734- PERFORM R3240_00_UPDATE_CROT_AP_DB_UPDATE_1 */

            R3240_00_UPDATE_CROT_AP_DB_UPDATE_1();

            /*" -5737- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5738- DISPLAY 'R3240-00 (ERRO - UPDATE V0CLIENTE_CROT)...' */
                _.Display($"R3240-00 (ERRO - UPDATE V0CLIENTE_CROT)...");

                /*" -5739- DISPLAY 'ATUALIZANDO ACIDENTES PESSOAIS         ...' */
                _.Display($"ATUALIZANDO ACIDENTES PESSOAIS         ...");

                /*" -5740- DISPLAY 'CGCCPF : ' V1CROT-CGCCPF */
                _.Display($"CGCCPF : {V1CROT_CGCCPF}");

                /*" -5742- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5742- ADD +1 TO AC-U-V0CLIE-CROT. */
            AREA_DE_WORK.AC_U_V0CLIE_CROT.Value = AREA_DE_WORK.AC_U_V0CLIE_CROT + +1;

        }

        [StopWatch]
        /*" R3240-00-UPDATE-CROT-AP-DB-UPDATE-1 */
        public void R3240_00_UPDATE_CROT_AP_DB_UPDATE_1()
        {
            /*" -5734- EXEC SQL UPDATE SEGUROS.V0CLIENTE_CROT SET BILH_AP = :V0CROT-BILH-AP , DTMOVABE = :V0CROT-DTMOVABE WHERE CGCCPF = :V0BILH-CGCCPF END-EXEC. */

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
            /*" -5754- MOVE '3250' TO WNR-EXEC-SQL. */
            _.Move("3250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5756- MOVE 'S' TO V0CROT-BILH-RES */
            _.Move("S", V0CROT_BILH_RES);

            /*" -5757- IF V1CROT-DTMOVABE < V1SIST-DTMOVACB */

            if (V1CROT_DTMOVABE < V1SIST_DTMOVACB)
            {

                /*" -5758- MOVE V1SIST-DTMOVACB TO V0CROT-DTMOVABE */
                _.Move(V1SIST_DTMOVACB, V0CROT_DTMOVABE);

                /*" -5759- ELSE */
            }
            else
            {


                /*" -5761- MOVE V1CROT-DTMOVABE TO V0CROT-DTMOVABE. */
                _.Move(V1CROT_DTMOVABE, V0CROT_DTMOVABE);
            }


            /*" -5766- PERFORM R3250_00_UPDATE_CROT_RES_DB_UPDATE_1 */

            R3250_00_UPDATE_CROT_RES_DB_UPDATE_1();

            /*" -5769- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5770- DISPLAY 'R3250-00 (ERRO - UPDATE V0CLIENTE_CROT)...' */
                _.Display($"R3250-00 (ERRO - UPDATE V0CLIENTE_CROT)...");

                /*" -5771- DISPLAY 'ATUALIZANDO RESIDENCIAIS               ...' */
                _.Display($"ATUALIZANDO RESIDENCIAIS               ...");

                /*" -5772- DISPLAY 'CGCCPF : ' V1CROT-CGCCPF */
                _.Display($"CGCCPF : {V1CROT_CGCCPF}");

                /*" -5774- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5774- ADD +1 TO AC-U-V0CLIE-CROT. */
            AREA_DE_WORK.AC_U_V0CLIE_CROT.Value = AREA_DE_WORK.AC_U_V0CLIE_CROT + +1;

        }

        [StopWatch]
        /*" R3250-00-UPDATE-CROT-RES-DB-UPDATE-1 */
        public void R3250_00_UPDATE_CROT_RES_DB_UPDATE_1()
        {
            /*" -5766- EXEC SQL UPDATE SEGUROS.V0CLIENTE_CROT SET BILH_RES = :V0CROT-BILH-RES , DTMOVABE = :V0CROT-DTMOVABE WHERE CGCCPF = :V0BILH-CGCCPF END-EXEC. */

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
            /*" -5786- MOVE '3260' TO WNR-EXEC-SQL. */
            _.Move("3260", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5787- MOVE V0BILH-CGCCPF TO V0CROT-CGCCPF */
            _.Move(V0BILH_CGCCPF, V0CROT_CGCCPF);

            /*" -5788- MOVE 'N' TO V0CROT-BILH-VDAZUL */
            _.Move("N", V0CROT_BILH_VDAZUL);

            /*" -5790- MOVE V1SIST-DTMOVACB TO V0CROT-DTMOVABE */
            _.Move(V1SIST_DTMOVACB, V0CROT_DTMOVABE);

            /*" -5797- PERFORM R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1 */

            R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1();

            /*" -5800- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5801- DISPLAY 'R3260-00 (ERRO - INSERT V0CLIENTE_CROT)...' */
                _.Display($"R3260-00 (ERRO - INSERT V0CLIENTE_CROT)...");

                /*" -5802- DISPLAY 'CGCCPF: ' V0BILH-CGCCPF */
                _.Display($"CGCCPF: {V0BILH_CGCCPF}");

                /*" -5804- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5804- ADD +1 TO AC-I-V0CLIE-CROT. */
            AREA_DE_WORK.AC_I_V0CLIE_CROT.Value = AREA_DE_WORK.AC_I_V0CLIE_CROT + +1;

        }

        [StopWatch]
        /*" R3260-00-INSERT-V0CLIEN-CROT-DB-INSERT-1 */
        public void R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1()
        {
            /*" -5797- EXEC SQL INSERT INTO SEGUROS.V0CLIENTE_CROT VALUES (:V0CROT-CGCCPF , :V0CROT-BILH-AP , :V0CROT-BILH-RES , :V0CROT-BILH-VDAZUL , :V0CROT-DTMOVABE) END-EXEC. */

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
        /*" R3270-00-SELECT-APOLICE-ANT-SECTION */
        private void R3270_00_SELECT_APOLICE_ANT_SECTION()
        {
            /*" -5816- MOVE '3270' TO WNR-EXEC-SQL. */
            _.Move("3270", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5818- MOVE V0BILH-NUM-APO-ANT TO V1APOL-NUMBIL */
            _.Move(V0BILH_NUM_APO_ANT, V1APOL_NUMBIL);

            /*" -5823- PERFORM R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1 */

            R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1();

            /*" -5826- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5827- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5828- MOVE 0 TO V1APOL-NUM-APOL */
                    _.Move(0, V1APOL_NUM_APOL);

                    /*" -5829- ELSE */
                }
                else
                {


                    /*" -5830- DISPLAY 'R3270-00 (ERRO SELECT V0APOLICE)' */
                    _.Display($"R3270-00 (ERRO SELECT V0APOLICE)");

                    /*" -5831- DISPLAY 'NUMBIL     : ' V1APOL-NUMBIL */
                    _.Display($"NUMBIL     : {V1APOL_NUMBIL}");

                    /*" -5831- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3270-00-SELECT-APOLICE-ANT-DB-SELECT-1 */
        public void R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1()
        {
            /*" -5823- EXEC SQL SELECT NUM_APOLICE INTO :V1APOL-NUM-APOL FROM SEGUROS.V0APOLICE WHERE NUMBIL = :V1APOL-NUMBIL END-EXEC. */

            var r3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1 = new R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1()
            {
                V1APOL_NUMBIL = V1APOL_NUMBIL.ToString(),
            };

            var executed_1 = R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1.Execute(r3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APOL_NUM_APOL, V1APOL_NUM_APOL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3270_99_SAIDA*/

        [StopWatch]
        /*" R3280-00-TRATA-FC0001S-SECTION */
        private void R3280_00_TRATA_FC0001S_SECTION()
        {
            /*" -5843- MOVE '3280' TO WNR-EXEC-SQL */
            _.Move("3280", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5845- PERFORM R3290-00-INSERT-MOVFEDCA. */

            R3290_00_INSERT_MOVFEDCA_SECTION();

            /*" -5847- PERFORM R3300-00-INSERT-TITFEDCA. */

            R3300_00_INSERT_TITFEDCA_SECTION();

            /*" -5849- PERFORM R3400-00-INSERT-COMFEDCA. */

            R3400_00_INSERT_COMFEDCA_SECTION();

            /*" -5851- PERFORM R3500-00-INSERT-PARFEDCA. */

            R3500_00_INSERT_PARFEDCA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3280_99_SAIDA*/

        [StopWatch]
        /*" R3290-00-INSERT-MOVFEDCA-SECTION */
        private void R3290_00_INSERT_MOVFEDCA_SECTION()
        {
            /*" -5862- MOVE '3290' TO WNR-EXEC-SQL */
            _.Move("3290", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5864- INITIALIZE FC0001S-LINKAGE */
            _.Initialize(
                FC0001S_LINKAGE
            );

            /*" -5867- MOVE 809 TO FC0001S-NUM-PLANO */
            _.Move(809, FC0001S_LINKAGE.FC0001S_NUM_PLANO);

            /*" -5870- MOVE V0BILH-NUMBIL TO FC0001S-NUM-PROPOSTA */
            _.Move(V0BILH_NUMBIL, FC0001S_LINKAGE.FC0001S_NUM_PROPOSTA);

            /*" -5873- MOVE V1BILC-VALMAX TO FC0001S-VLR-MENSALIDADE */
            _.Move(V1BILC_VALMAX, FC0001S_LINKAGE.FC0001S_VLR_MENSALIDADE);

            /*" -5875- CALL 'FC0001S' USING FC0001S-LINKAGE. */
            _.Call("FC0001S", FC0001S_LINKAGE);

            /*" -5876- IF FC0001S-COD-RETORNO NOT EQUAL ZEROS */

            if (FC0001S_LINKAGE.FC0001S_COD_RETORNO != 00)
            {

                /*" -5877- MOVE FC0001S-SQLCODE TO WS-SQLCODE */
                _.Move(FC0001S_LINKAGE.FC0001S_SQLCODE, AREA_DE_WORK.WS_SQLCODE);

                /*" -5881- DISPLAY 'PROBLEMAS NO ACESSO A FC0001S ' FC0001S-NUM-PROPOSTA ' ' WS-SQLCODE ' ' FC0001S-DES-MENSAGEM */

                $"PROBLEMAS NO ACESSO A FC0001S {FC0001S_LINKAGE.FC0001S_NUM_PROPOSTA} {AREA_DE_WORK.WS_SQLCODE} {FC0001S_LINKAGE.FC0001S_DES_MENSAGEM}"
                .Display();

                /*" -5882- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5884- END-IF. */
            }


            /*" -5886- MOVE FC0001S-NUM-PLANO TO WS-NUM-PLANO */
            _.Move(FC0001S_LINKAGE.FC0001S_NUM_PLANO, AREA_DE_WORK.WS_NUM_TITULO_X.WS_NUM_PLANO);

            /*" -5888- MOVE FC0001S-NUM-SERIE TO WS-NUM-SERIE */
            _.Move(FC0001S_LINKAGE.FC0001S_NUM_SERIE, AREA_DE_WORK.WS_NUM_TITULO_X.WS_NUM_SERIE);

            /*" -5890- MOVE FC0001S-NUM-TITULO TO WS-NUM-TITULO */
            _.Move(FC0001S_LINKAGE.FC0001S_NUM_TITULO, AREA_DE_WORK.WS_NUM_TITULO_X.WS_NUM_TITULO);

            /*" -5893- MOVE WS-NUM-TITULO-9 TO MOVFEDCA-NRTITFDCAP. */
            _.Move(AREA_DE_WORK.WS_NUM_TITULO_9, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP);

            /*" -5894- IF V0BILH-FONTE EQUAL ZEROS */

            if (V0BILH_FONTE == 00)
            {

                /*" -5896- MOVE 5 TO V0BILH-FONTE */
                _.Move(5, V0BILH_FONTE);

                /*" -5897- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R3290_10_INSERT */

            R3290_10_INSERT();

        }

        [StopWatch]
        /*" R3290-10-INSERT */
        private void R3290_10_INSERT(bool isPerform = false)
        {
            /*" -5931- PERFORM R3290_10_INSERT_DB_INSERT_1 */

            R3290_10_INSERT_DB_INSERT_1();

            /*" -5935- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5936- DISPLAY 'R3290 - ERRO NO INSERT DA MOVFEDCA ' */
                _.Display($"R3290 - ERRO NO INSERT DA MOVFEDCA ");

                /*" -5937- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                _.Display($"BILHETE {V0BILH_NUMBIL}");

                /*" -5938- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5938- END-IF. */
            }


        }

        [StopWatch]
        /*" R3290-10-INSERT-DB-INSERT-1 */
        public void R3290_10_INSERT_DB_INSERT_1()
        {
            /*" -5931- EXEC SQL INSERT INTO SEGUROS.MOVIMEN_FED_CAP_VA ( NUM_CERTIFICADO , COD_OPERACAO , COD_FONTE , NUM_PROPOSTA , DTMVFDCAP , NUM_PARCELA , QUANT_TIT_CAPITALI , VAL_CUSTO_CAPITALI , SITUACAO , NRTITFDCAP , NRMSCAP , NUM_SEQUENCIA , TIMESTAMP , CODPRODU ) VALUES ( :V0BILH-NUMBIL , 1 , :V0BILH-FONTE, 0 , :V1SIST-DTMOVABE , 0 , 1 , :V1BILC-VALMAX, '1' , :MOVFEDCA-NRTITFDCAP , 0 , 0 , CURRENT TIMESTAMP , :V1BILP-CODPRODU ) END-EXEC. */

            var r3290_10_INSERT_DB_INSERT_1_Insert1 = new R3290_10_INSERT_DB_INSERT_1_Insert1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
                V0BILH_FONTE = V0BILH_FONTE.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V1BILC_VALMAX = V1BILC_VALMAX.ToString(),
                MOVFEDCA_NRTITFDCAP = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP.ToString(),
                V1BILP_CODPRODU = V1BILP_CODPRODU.ToString(),
            };

            R3290_10_INSERT_DB_INSERT_1_Insert1.Execute(r3290_10_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3290_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-INSERT-TITFEDCA-SECTION */
        private void R3300_00_INSERT_TITFEDCA_SECTION()
        {
            /*" -5950- MOVE '3300' TO WNR-EXEC-SQL */
            _.Move("3300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5952- MOVE FC0001S-DTH-INI-VIGENCIA TO TITFEDCA-DATA-INIVIGENCIA */
            _.Move(FC0001S_LINKAGE.FC0001S_DTH_INI_VIGENCIA, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_INIVIGENCIA);

            /*" -5954- MOVE FC0001S-DTH-FIM-VIGENCIA TO TITFEDCA-DATA-TERVIGENCIA */
            _.Move(FC0001S_LINKAGE.FC0001S_DTH_FIM_VIGENCIA, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_TERVIGENCIA);

            /*" -5957- MOVE FC0001S-DES-COMBINACAO TO WS-COMBINACAO. */
            _.Move(FC0001S_LINKAGE.FC0001S_DES_COMBINACAO, AREA_DE_WORK.WS_COMBINACAO);

            /*" -5959- PERFORM R3310-00-TRATA-COMBINACAO. */

            R3310_00_TRATA_COMBINACAO_SECTION();

            /*" -5961- MOVE WS-COMBINACAO-9 TO TITFEDCA-NRSORTEIO. */
            _.Move(AREA_DE_WORK.WS_COMBINACAO_9, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO);

            /*" -0- FLUXCONTROL_PERFORM R3300_00_INSERT */

            R3300_00_INSERT();

        }

        [StopWatch]
        /*" R3300-00-INSERT */
        private void R3300_00_INSERT(bool isPerform = false)
        {
            /*" -5995- PERFORM R3300_00_INSERT_DB_INSERT_1 */

            R3300_00_INSERT_DB_INSERT_1();

            /*" -5998- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5999- DISPLAY 'R3300 - ERRO NO INSERT DA TITFEDCA ' */
                _.Display($"R3300 - ERRO NO INSERT DA TITFEDCA ");

                /*" -6000- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                _.Display($"BILHETE {V0BILH_NUMBIL}");

                /*" -6001- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6001- END-IF. */
            }


        }

        [StopWatch]
        /*" R3300-00-INSERT-DB-INSERT-1 */
        public void R3300_00_INSERT_DB_INSERT_1()
        {
            /*" -5995- EXEC SQL INSERT INTO SEGUROS.TITULOS_FED_CAP_VA ( NRTITFDCAP , NUM_CERTIFICADO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , NRSORTEIO , VAL_CUSTO_TITULO , NRPARCEL , NRMFDCAPF , SITUACAO , SIT_RELAT , DATA_MOVIMENTO , TIMESTAMP , NRMFDCAPR , NRTITREN ) VALUES ( :MOVFEDCA-NRTITFDCAP , :V0BILH-NUMBIL , :TITFEDCA-DATA-INIVIGENCIA , :TITFEDCA-DATA-TERVIGENCIA , :TITFEDCA-NRSORTEIO , :V1BILC-VALMAX, 0, 0, '0' , '1' , :V1SIST-DTMOVABE , CURRENT TIMESTAMP , 0, 0 ) END-EXEC. */

            var r3300_00_INSERT_DB_INSERT_1_Insert1 = new R3300_00_INSERT_DB_INSERT_1_Insert1()
            {
                MOVFEDCA_NRTITFDCAP = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
                TITFEDCA_DATA_INIVIGENCIA = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_INIVIGENCIA.ToString(),
                TITFEDCA_DATA_TERVIGENCIA = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_TERVIGENCIA.ToString(),
                TITFEDCA_NRSORTEIO = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO.ToString(),
                V1BILC_VALMAX = V1BILC_VALMAX.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R3300_00_INSERT_DB_INSERT_1_Insert1.Execute(r3300_00_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3310-00-TRATA-COMBINACAO-SECTION */
        private void R3310_00_TRATA_COMBINACAO_SECTION()
        {
            /*" -6014- MOVE '3310' TO WNR-EXEC-SQL */
            _.Move("3310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -6015- MOVE ZEROS TO WIND. */
            _.Move(0, WIND);

            /*" -0- FLUXCONTROL_PERFORM R3310_10_LOOP */

            R3310_10_LOOP();

        }

        [StopWatch]
        /*" R3310-10-LOOP */
        private void R3310_10_LOOP(bool isPerform = false)
        {
            /*" -6020- ADD 1 TO WIND. */
            WIND.Value = WIND + 1;

            /*" -6021- IF WIND GREATER 20 */

            if (WIND > 20)
            {

                /*" -6022- DISPLAY 'PROBLEMAS NO NUMERO DE SORTE' */
                _.Display($"PROBLEMAS NO NUMERO DE SORTE");

                /*" -6024- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6025- IF WS-COMB(WIND) = ' ' */

            if (AREA_DE_WORK.WS_COMBINACAO_R.WS_COMB[WIND] == " ")
            {

                /*" -6026- SUBTRACT 1 FROM WIND */
                WIND.Value = WIND - 1;

                /*" -6028- MOVE WS-COMBINACAO(1:WIND) TO WS-COMBINACAO-9 */
                _.Move(AREA_DE_WORK.WS_COMBINACAO.Substring(1, WIND), AREA_DE_WORK.WS_COMBINACAO_9);

                /*" -6029- ELSE */
            }
            else
            {


                /*" -6029- GO TO R3310-10-LOOP. */
                new Task(() => R3310_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3310_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-INSERT-COMFEDCA-SECTION */
        private void R3400_00_INSERT_COMFEDCA_SECTION()
        {
            /*" -6040- MOVE '3400' TO WNR-EXEC-SQL. */
            _.Move("3400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R3400_10_INSERT */

            R3400_10_INSERT();

        }

        [StopWatch]
        /*" R3400-10-INSERT */
        private void R3400_10_INSERT(bool isPerform = false)
        {
            /*" -6055- PERFORM R3400_10_INSERT_DB_INSERT_1 */

            R3400_10_INSERT_DB_INSERT_1();

            /*" -6058- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6059- DISPLAY 'R3300 - ERRO NO INSERT DA TITFEDCA ' */
                _.Display($"R3300 - ERRO NO INSERT DA TITFEDCA ");

                /*" -6060- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                _.Display($"BILHETE {V0BILH_NUMBIL}");

                /*" -6061- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6061- END-IF. */
            }


        }

        [StopWatch]
        /*" R3400-10-INSERT-DB-INSERT-1 */
        public void R3400_10_INSERT_DB_INSERT_1()
        {
            /*" -6055- EXEC SQL INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO , SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ( :V0BILH-NUMBIL , '0' , :V1SIST-DTMOVABE , CURRENT TIMESTAMP ) END-EXEC. */

            var r3400_10_INSERT_DB_INSERT_1_Insert1 = new R3400_10_INSERT_DB_INSERT_1_Insert1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R3400_10_INSERT_DB_INSERT_1_Insert1.Execute(r3400_10_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-INSERT-PARFEDCA-SECTION */
        private void R3500_00_INSERT_PARFEDCA_SECTION()
        {
            /*" -6073- MOVE '3500' TO WNR-EXEC-SQL. */
            _.Move("3500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R3500_10_INSERT */

            R3500_10_INSERT();

        }

        [StopWatch]
        /*" R3500-10-INSERT */
        private void R3500_10_INSERT(bool isPerform = false)
        {
            /*" -6095- PERFORM R3500_10_INSERT_DB_INSERT_1 */

            R3500_10_INSERT_DB_INSERT_1();

            /*" -6098- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6099- DISPLAY 'R3500 - ERRO NO INSERT DA TITFEDCA ' */
                _.Display($"R3500 - ERRO NO INSERT DA TITFEDCA ");

                /*" -6100- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                _.Display($"BILHETE {V0BILH_NUMBIL}");

                /*" -6101- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6101- END-IF. */
            }


        }

        [StopWatch]
        /*" R3500-10-INSERT-DB-INSERT-1 */
        public void R3500_10_INSERT_DB_INSERT_1()
        {
            /*" -6095- EXEC SQL INSERT INTO SEGUROS.PARCEL_FED_CAP_VA ( NRTITFDCAP , NUM_PARCELA , VAL_CUSTO_TITULO , DTFATUR , DATA_MOVIMENTO , SITUACAO , NRMFDCAP , TIMESTAMP ) VALUES ( :MOVFEDCA-NRTITFDCAP , 0, :V1BILC-VALMAX, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, '1' , 0 , CURRENT TIMESTAMP ) END-EXEC. */

            var r3500_10_INSERT_DB_INSERT_1_Insert1 = new R3500_10_INSERT_DB_INSERT_1_Insert1()
            {
                MOVFEDCA_NRTITFDCAP = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP.ToString(),
                V1BILC_VALMAX = V1BILC_VALMAX.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R3500_10_INSERT_DB_INSERT_1_Insert1.Execute(r3500_10_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TOTAIS-CONTROLE-SECTION */
        private void R4000_00_TOTAIS_CONTROLE_SECTION()
        {
            /*" -6116- MOVE '7100' TO WNR-EXEC-SQL. */
            _.Move("7100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -6117- MOVE V1SIST-DTCURRENT TO WDATA-CURR */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -6118- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -6119- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -6121- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -6123- DISPLAY '+------------------------------------------------ '-----------------+' */
            _.Display($"+------------------------------------------------ -----------------+");

            /*" -6125- DISPLAY 'I BILHETES DE SEGUROS '                 I' */
            _.Display($"I BILHETES DE SEGUROS I");

            /*" -6127- DISPLAY 'I '                 I' */
            _.Display($"I I");

            /*" -6130- DISPLAY 'I                TOTAIS DE CONTROLE EM ' WDATA-CABEC '                 I' */

            $"I                TOTAIS DE CONTROLE EM {AREA_DE_WORK.WDATA_CABEC}                 I"
            .Display();

            /*" -6133- DISPLAY '+------------------------------------------------ '-----------------+' . */
            _.Display($"+------------------------------------------------ -----------------+");

            /*" -6135- DISPLAY 'I T A B E L A S A T U A L I Z A D A ' S               I' . */

            $"I T A B E L A S A T U A L I Z A D A SI"
            .Display();

            /*" -6137- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -6139- DISPLAY 'I NOME DA TABELA I IN 'SERT   I UPDATE  I' */

            $"I NOME DA TABELA I IN SERTIUPDATEI"
            .Display();

            /*" -6141- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -6144- DISPLAY 'I NUMERO OUTROS             (V0NUMERO_OUTS)  I  ' '     ' '   I  ' AC-U-V0NUMEROUT '  I' */

            $"I NUMERO OUTROS             (V0NUMERO_OUTS)  I          I  {AREA_DE_WORK.AC_U_V0NUMEROUT}  I"
            .Display();

            /*" -6147- DISPLAY 'I NUMERACAO GERAL           (V0NUMERO_AES)   I  ' '     ' '   I  ' AC-U-V0NUMERAES '  I' */

            $"I NUMERACAO GERAL           (V0NUMERO_AES)   I          I  {AREA_DE_WORK.AC_U_V0NUMERAES}  I"
            .Display();

            /*" -6150- DISPLAY 'I APOLICES                  (V0APOLICE)      I  ' AC-I-V0APOLICE '   I  ' AC-U-V0APOLICE '  I' */

            $"I APOLICES                  (V0APOLICE)      I  {AREA_DE_WORK.AC_I_V0APOLICE}   I  {AREA_DE_WORK.AC_U_V0APOLICE}  I"
            .Display();

            /*" -6153- DISPLAY 'I ENDOSSOS                  (V0ENDOSSO)      I  ' AC-I-V0ENDOSSO '   I  ' '     ' '  I' */

            $"I ENDOSSOS                  (V0ENDOSSO)      I  {AREA_DE_WORK.AC_I_V0ENDOSSO}   I         I"
            .Display();

            /*" -6156- DISPLAY 'I RECIBOS COB ANTECIPADA    (V0RCAP)         I  ' '     ' '   I  ' AC-U-V0RCAP '  I' */

            $"I RECIBOS COB ANTECIPADA    (V0RCAP)         I          I  {AREA_DE_WORK.AC_U_V0RCAP}  I"
            .Display();

            /*" -6159- DISPLAY 'I REC COBRANC ANTEC COMPL   (V0RCAPCOMP)     I  ' AC-I-V0RCAPCOMP '   I  ' AC-U-V0RCAPCOMP '  I' */

            $"I REC COBRANC ANTEC COMPL   (V0RCAPCOMP)     I  {AREA_DE_WORK.AC_I_V0RCAPCOMP}   I  {AREA_DE_WORK.AC_U_V0RCAPCOMP}  I"
            .Display();

            /*" -6162- DISPLAY 'I PRODUTORES                (V0PRODUTOR)     I  ' AC-I-V0PRODUTOR '   I  ' '     ' '  I' */

            $"I PRODUTORES                (V0PRODUTOR)     I  {AREA_DE_WORK.AC_I_V0PRODUTOR}   I         I"
            .Display();

            /*" -6165- DISPLAY 'I FUNCIONARIOS CEF          (V0FUNCIOCEF)    I  ' '     ' '   I  ' AC-U-V0FUNCIOCEF '  I' */

            $"I FUNCIONARIOS CEF          (V0FUNCIOCEF)    I          I  {AREA_DE_WORK.AC_U_V0FUNCIOCEF}  I"
            .Display();

            /*" -6168- DISPLAY 'I APOLICE CORRETOR          (V0APOLCORRET)   I  ' AC-I-V0APOLCORRET '   I  ' '     ' '  I' */

            $"I APOLICE CORRETOR          (V0APOLCORRET)   I  {AREA_DE_WORK.AC_I_V0APOLCORRET}   I         I"
            .Display();

            /*" -6171- DISPLAY 'I APOLICE COSSEGURO         (V0APOLCOSCED)   I  ' AC-I-V0APOLCOSCED '   I  ' '     ' '  I' */

            $"I APOLICE COSSEGURO         (V0APOLCOSCED)   I  {AREA_DE_WORK.AC_I_V0APOLCOSCED}   I         I"
            .Display();

            /*" -6174- DISPLAY 'I ORDEM DE COSSEG CEDIDO    (V0ORDECOSCED)   I  ' AC-I-V0ORDECOSCED '   I  ' '     ' '  I' */

            $"I ORDEM DE COSSEG CEDIDO    (V0ORDECOSCED)   I  {AREA_DE_WORK.AC_I_V0ORDECOSCED}   I         I"
            .Display();

            /*" -6177- DISPLAY 'I PARCELAS                  (V0PARCELAS)     I  ' AC-I-V0PARCELA '   I  ' '     ' '  I' */

            $"I PARCELAS                  (V0PARCELAS)     I  {AREA_DE_WORK.AC_I_V0PARCELA}   I         I"
            .Display();

            /*" -6180- DISPLAY 'I HISTORICO DE PARCELAS     (V0HISTOPARC)    I  ' AC-I-V0HISTOPARC '   I  ' '     ' '  I' */

            $"I HISTORICO DE PARCELAS     (V0HISTOPARC)    I  {AREA_DE_WORK.AC_I_V0HISTOPARC}   I         I"
            .Display();

            /*" -6183- DISPLAY 'I COBERTURAS DE APOLICE     (V0COBERAPOL)    I  ' AC-I-V0COBERAPOL '   I  ' '     ' '  I' */

            $"I COBERTURAS DE APOLICE     (V0COBERAPOL)    I  {AREA_DE_WORK.AC_I_V0COBERAPOL}   I         I"
            .Display();

            /*" -6187- DISPLAY 'I COMISSAO FENAE            (V0COMISSAO_FENAEI  ' '     ' '   I  ' AC-U-V0COMIFENAE '  I' */

            $"I COMISSAO FENAE            (V0COMISSAO_FENAEI          I  {AREA_DE_WORK.AC_U_V0COMIFENAE}  I"
            .Display();

            /*" -6190- DISPLAY 'I CLIENTE CROT              (V0CLIENTE_CROT) I  ' AC-I-V0CLIE-CROT '   I  ' AC-U-V0CLIE-CROT '  I' */

            $"I CLIENTE CROT              (V0CLIENTE_CROT) I  {AREA_DE_WORK.AC_I_V0CLIE_CROT}   I  {AREA_DE_WORK.AC_U_V0CLIE_CROT}  I"
            .Display();

            /*" -6193- DISPLAY 'I ADIANTAMENTOS             (V0ADIANTA)      I  ' AC-I-V0ADIANTA '   I  ' '     ' '  I' */

            $"I ADIANTAMENTOS             (V0ADIANTA)      I  {AREA_DE_WORK.AC_I_V0ADIANTA}   I         I"
            .Display();

            /*" -6196- DISPLAY 'I LIMITE DE RISCO                            I  ' AC-I-GELMR '   I  ' AC-U-GELMR '  I' */

            $"I LIMITE DE RISCO                            I  {AREA_DE_WORK.AC_I_GELMR}   I  {AREA_DE_WORK.AC_U_GELMR}  I"
            .Display();

            /*" -6198- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -6200- DISPLAY 'I QUANTIDADE DE BILHETES REJEITADOS          I  ' AC-U-V0BILHETE '   I         I' */

            $"I QUANTIDADE DE BILHETES REJEITADOS          I  {AREA_DE_WORK.AC_U_V0BILHETE}   I         I"
            .Display();

            /*" -6201- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4280-00-TRATA-FC0105S-SECTION */
        private void R4280_00_TRATA_FC0105S_SECTION()
        {
            /*" -6212- MOVE '4280' TO WNR-EXEC-SQL */
            _.Move("4280", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -6214- PERFORM R4290-00-INSERT-MOVFEDCA. */

            R4290_00_INSERT_MOVFEDCA_SECTION();

            /*" -6215- PERFORM R4400-00-INSERT-COMFEDCA. */

            R4400_00_INSERT_COMFEDCA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4280_99_SAIDA*/

        [StopWatch]
        /*" R4290-00-INSERT-MOVFEDCA-SECTION */
        private void R4290_00_INSERT_MOVFEDCA_SECTION()
        {
            /*" -6226- MOVE '4290' TO WNR-EXEC-SQL */
            _.Move("4290", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -6243- INITIALIZE LK-PLANO LK-SERIE LK-TITULO LK-NUM-PROPOSTA LK-QTD-TITULOS LK-VLR-TITULO LK-PARCEIRO LK-RAMO LK-COD-USUARIO LK-TRACE LK-OUT-COD-RETORNO LK-OUT-SQLCODE LK-OUT-MENSAGEM LK-OUT-SQLERRMC LK-OUT-SQLSTATE. */
            _.Initialize(
                LK_PLANO
                , LK_SERIE
                , LK_TITULO
                , LK_NUM_PROPOSTA
                , LK_QTD_TITULOS
                , LK_VLR_TITULO
                , LK_PARCEIRO
                , LK_RAMO
                , LK_COD_USUARIO
                , LK_TRACE
                , LK_OUT_COD_RETORNO
                , LK_OUT_SQLCODE
                , LK_OUT_MENSAGEM
                , LK_OUT_SQLERRMC
                , LK_OUT_SQLSTATE
            );

            /*" -6246- MOVE 850 TO LK-PLANO. */
            _.Move(850, LK_PLANO);

            /*" -6248- MOVE V0BILH-NUMBIL TO LK-NUM-PROPOSTA. */
            _.Move(V0BILH_NUMBIL, LK_NUM_PROPOSTA);

            /*" -6250- MOVE 1 TO LK-QTD-TITULOS. */
            _.Move(1, LK_QTD_TITULOS);

            /*" -6251- IF ORIGEM-MARSH */

            if (WREA88.W_ORIGEM_PROPOSTA["ORIGEM_MARSH"])
            {

                /*" -6252- MOVE 6,75 TO LK-VLR-TITULO */
                _.Move(6.75, LK_VLR_TITULO);

                /*" -6253- ELSE */
            }
            else
            {


                /*" -6254- MOVE 3,00 TO LK-VLR-TITULO */
                _.Move(3.00, LK_VLR_TITULO);

                /*" -6256- END-IF. */
            }


            /*" -6259- MOVE PARAMGER-COD-EMPRESA-CAP TO LK-PARCEIRO. */
            _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA_CAP, LK_PARCEIRO);

            /*" -6260- MOVE 'CB2005B' TO LK-COD-USUARIO. */
            _.Move("CB2005B", LK_COD_USUARIO);

            /*" -6262- MOVE V1BILP-CODPRODU TO LK-RAMO. */
            _.Move(V1BILP_CODPRODU, LK_RAMO);

            /*" -6264- MOVE 'TRACE OFF' TO LK-TRACE. */
            _.Move("TRACE OFF", LK_TRACE);

            /*" -6267- MOVE ZEROS TO LK-NUM-NSA. */
            _.Move(0, LK_NUM_NSA);

            /*" -6279- DISPLAY 'PARAMETROS ACESSO A VG105S ' ' ' LK-PLANO ' ' LK-SERIE ' ' LK-TITULO ' ' LK-NUM-PROPOSTA ' ' LK-QTD-TITULOS ' ' LK-PARCEIRO ' ' LK-COD-USUARIO ' ' LK-RAMO ' ' LK-NUM-NSA ' ' LK-TRACE. */

            $"PARAMETROS ACESSO A VG105S  {LK_PLANO} {LK_SERIE} {LK_TITULO} {LK_NUM_PROPOSTA} {LK_QTD_TITULOS} {LK_PARCEIRO} {LK_COD_USUARIO} {LK_RAMO} {LK_NUM_NSA} {LK_TRACE}"
            .Display();

            /*" -6299- CALL 'VG0105S' USING LK-PLANO , LK-SERIE , LK-TITULO , LK-NUM-PROPOSTA , LK-QTD-TITULOS , LK-VLR-TITULO , LK-PARCEIRO , LK-RAMO , LK-COD-USUARIO , LK-NUM-NSA , LK-TRACE , LK-OUT-COD-RETORNO , LK-OUT-SQLCODE , LK-OUT-MENSAGEM , LK-OUT-SQLERRMC , LK-OUT-SQLSTATE. */
            _.Call("VG0105S", LK_PLANO, LK_SERIE, LK_TITULO, LK_NUM_PROPOSTA, LK_QTD_TITULOS, LK_VLR_TITULO, LK_PARCEIRO, LK_RAMO, LK_COD_USUARIO, LK_NUM_NSA, LK_TRACE, LK_OUT_COD_RETORNO, LK_OUT_SQLCODE, LK_OUT_MENSAGEM, LK_OUT_SQLERRMC, LK_OUT_SQLSTATE);

            /*" -6300- IF LK-OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LK_OUT_COD_RETORNO != 00)
            {

                /*" -6301- MOVE LK-OUT-SQLCODE TO WS-SQLCODE */
                _.Move(LK_OUT_SQLCODE, AREA_DE_WORK.WS_SQLCODE);

                /*" -6308- DISPLAY 'PROBLEMAS NO ACESSO A VG0105S ' ' ' LK-NUM-PROPOSTA ' ' LK-OUT-COD-RETORNO ' ' WS-SQLCODE ' ' LK-OUT-MENSAGEM ' ' LK-OUT-SQLERRMC ' ' LK-OUT-SQLSTATE */

                $"PROBLEMAS NO ACESSO A VG0105S  {LK_NUM_PROPOSTA} {LK_OUT_COD_RETORNO} {AREA_DE_WORK.WS_SQLCODE} {LK_OUT_MENSAGEM} {LK_OUT_SQLERRMC} {LK_OUT_SQLSTATE}"
                .Display();

                /*" -6309- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6309- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4290_99_SAIDA*/

        [StopWatch]
        /*" R4400-00-INSERT-COMFEDCA-SECTION */
        private void R4400_00_INSERT_COMFEDCA_SECTION()
        {
            /*" -6321- MOVE '4400' TO WNR-EXEC-SQL. */
            _.Move("4400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -6332- PERFORM R4400_00_INSERT_COMFEDCA_DB_INSERT_1 */

            R4400_00_INSERT_COMFEDCA_DB_INSERT_1();

            /*" -6335- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6336- DISPLAY 'R4400 - ERRO NO INSERT DA COMFEDCA' */
                _.Display($"R4400 - ERRO NO INSERT DA COMFEDCA");

                /*" -6337- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                _.Display($"BILHETE {V0BILH_NUMBIL}");

                /*" -6338- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6339- END-IF. */
            }


        }

        [StopWatch]
        /*" R4400-00-INSERT-COMFEDCA-DB-INSERT-1 */
        public void R4400_00_INSERT_COMFEDCA_DB_INSERT_1()
        {
            /*" -6332- EXEC SQL INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO , SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ( :V0BILH-NUMBIL , '0' , :V1SIST-DTMOVABE , CURRENT TIMESTAMP ) END-EXEC. */

            var r4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 = new R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1.Execute(r4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" R7000-JV1-BUSCA-EMPRESA-RAMO-SECTION */
        private void R7000_JV1_BUSCA_EMPRESA_RAMO_SECTION()
        {
            /*" -6352- MOVE '7000' TO WNR-EXEC-SQL. */
            _.Move("7000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -6364- PERFORM R7000_JV1_BUSCA_EMPRESA_RAMO_DB_SELECT_1 */

            R7000_JV1_BUSCA_EMPRESA_RAMO_DB_SELECT_1();

            /*" -6367- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6368- DISPLAY 'R7000-JV1-BUSCA-EMPRESA-RAMO  ..' */
                _.Display($"R7000-JV1-BUSCA-EMPRESA-RAMO  ..");

                /*" -6369- DISPLAY 'PRODUTO - ' PRODUTO-COD-PRODUTO */
                _.Display($"PRODUTO - {PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO}");

                /*" -6370- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -6371- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6371- END-IF. */
            }


        }

        [StopWatch]
        /*" R7000-JV1-BUSCA-EMPRESA-RAMO-DB-SELECT-1 */
        public void R7000_JV1_BUSCA_EMPRESA_RAMO_DB_SELECT_1()
        {
            /*" -6364- EXEC SQL SELECT A.COD_EMPRESA ,A.RAMO_EMISSOR ,B.COD_EMPRESA_CAP INTO :PRODUTO-COD-EMPRESA ,:PRODUTO-RAMO-EMISSOR ,:PARAMGER-COD-EMPRESA-CAP FROM SEGUROS.PRODUTO A ,SEGUROS.PARAMETROS_GERAIS B WHERE A.COD_PRODUTO = :PRODUTO-COD-PRODUTO AND B.COD_EMPRESA = A.COD_EMPRESA WITH UR END-EXEC. */

            var r7000_JV1_BUSCA_EMPRESA_RAMO_DB_SELECT_1_Query1 = new R7000_JV1_BUSCA_EMPRESA_RAMO_DB_SELECT_1_Query1()
            {
                PRODUTO_COD_PRODUTO = PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO.ToString(),
            };

            var executed_1 = R7000_JV1_BUSCA_EMPRESA_RAMO_DB_SELECT_1_Query1.Execute(r7000_JV1_BUSCA_EMPRESA_RAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
                _.Move(executed_1.PRODUTO_RAMO_EMISSOR, PRODUTO.DCLPRODUTO.PRODUTO_RAMO_EMISSOR);
                _.Move(executed_1.PARAMGER_COD_EMPRESA_CAP, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA_CAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R8100-00-DECLARE-CBO-SECTION */
        private void R8100_00_DECLARE_CBO_SECTION()
        {
            /*" -6385- MOVE '8100' TO WNR-EXEC-SQL. */
            _.Move("8100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -6392- PERFORM R8100_00_DECLARE_CBO_DB_DECLARE_1 */

            R8100_00_DECLARE_CBO_DB_DECLARE_1();

            /*" -6394- PERFORM R8100_00_DECLARE_CBO_DB_OPEN_1 */

            R8100_00_DECLARE_CBO_DB_OPEN_1();

            /*" -6397- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6398- DISPLAY 'R8100 - PROBLEMAS DECLARE (CBO      ) ..' */
                _.Display($"R8100 - PROBLEMAS DECLARE (CBO      ) ..");

                /*" -6399- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -6400- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8100-00-DECLARE-CBO-DB-OPEN-1 */
        public void R8100_00_DECLARE_CBO_DB_OPEN_1()
        {
            /*" -6394- EXEC SQL OPEN CCBO END-EXEC. */

            CCBO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_99_SAIDA*/

        [StopWatch]
        /*" R8110-00-FETCH-CBO-SECTION */
        private void R8110_00_FETCH_CBO_SECTION()
        {
            /*" -6409- MOVE '8110' TO WNR-EXEC-SQL. */
            _.Move("8110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -6412- PERFORM R8110_00_FETCH_CBO_DB_FETCH_1 */

            R8110_00_FETCH_CBO_DB_FETCH_1();

            /*" -6415- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6416- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6417- MOVE 'S' TO WFIM-CBO */
                    _.Move("S", AREA_DE_WORK.WFIM_CBO);

                    /*" -6417- PERFORM R8110_00_FETCH_CBO_DB_CLOSE_1 */

                    R8110_00_FETCH_CBO_DB_CLOSE_1();

                    /*" -6419- ELSE */
                }
                else
                {


                    /*" -6419- PERFORM R8110_00_FETCH_CBO_DB_CLOSE_2 */

                    R8110_00_FETCH_CBO_DB_CLOSE_2();

                    /*" -6421- DISPLAY '8110 - (PROBLEMAS NO FETCH CCBO     ) ..' */
                    _.Display($"8110 - (PROBLEMAS NO FETCH CCBO     ) ..");

                    /*" -6422- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -6423- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R8110-00-FETCH-CBO-DB-FETCH-1 */
        public void R8110_00_FETCH_CBO_DB_FETCH_1()
        {
            /*" -6412- EXEC SQL FETCH CCBO INTO :CBO-COD-CBO, :CBO-DESCR-CBO END-EXEC. */

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
            /*" -6417- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8110_99_SAIDA*/

        [StopWatch]
        /*" R8110-00-FETCH-CBO-DB-CLOSE-2 */
        public void R8110_00_FETCH_CBO_DB_CLOSE_2()
        {
            /*" -6419- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }

        [StopWatch]
        /*" R8120-00-CARREGA-CBO-SECTION */
        private void R8120_00_CARREGA_CBO_SECTION()
        {
            /*" -6433- MOVE '8120' TO WNR-EXEC-SQL. */
            _.Move("8120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -6436- MOVE CBO-DESCR-CBO TO TAB-DESCR-CBO-C (CBO-COD-CBO) */
            _.Move(CBO_DESCR_CBO, TAB_CBO1.TAB_CBO.FILLER_1[CBO_COD_CBO].TAB_DESCR_CBO_C);

            /*" -6437- PERFORM R8110-00-FETCH-CBO. */

            R8110_00_FETCH_CBO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8120_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -6449- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -6451- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -6451- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -6453- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -6457- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -6457- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}