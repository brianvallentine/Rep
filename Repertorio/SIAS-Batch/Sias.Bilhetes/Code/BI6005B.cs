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
using Sias.Bilhetes.DB2.BI6005B;

namespace Code
{
    public class BI6005B
    {
        public bool IsCall { get; set; }

        public BI6005B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  BILHETES DE SEGURO (SASSE)         *      */
        /*"      *   PROGRAMA ...............  BI6005B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  WANGER C.SILVA / ALEXANDRE BURGOS  *      */
        /*"      *   PROGRAMADOR ............  ALEXANDRE BURGOS / ENRICO / WANGER *      */
        /*"      *   DATA CODIFICACAO .......  MARCO / 1995                       *      */
        /*"      *   VERSAO .................  V.04 18052009 15:38HS              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  A PARTIR DO MOVIMENTO DE BILHETES  *      */
        /*"      *                             (V0BILHETE), ATUALIZA O DB DE APO- *      */
        /*"      *                             LICES.                             *      */
        /*"      *                             PROGRAMA ESPECIFICO PARA:          *      */
        /*"      *                             RENOVACAO(VERSAO DO BI6005B).      *      */
        /*"      *                             O ID INTERNO FOI MANTIDO. ESTA     *      */
        /*"      *                             VERSAO NAO EH A DEFINITIVA.        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.11  *  VERSAO 11  - DEMANDA 402.982                                  *      */
        /*"      *             - RETIRAR GRAVACAO DE ERROS DA PROPOSTA DA TABELA  *      */
        /*"      *               BILHETE_ERROS                                    *      */
        /*"      *             - GRAVAR ERROS DA PROPOSTA NA NOVA TABELA          *      */
        /*"      *               VG_CRITICA_PROPOSTA PARA POSTERIOR ANALISE DO    *      */
        /*"      *               GESTOR NO ATALHO 04.23                           *      */
        /*"      *             - SOMAR 10000 AOS COD-ERRO UTILIZADOS NAS TABELAS  *      */
        /*"      *               DE BILHETE E VIDA AO MESMO TEMPO                 *      */
        /*"      *             - COLOCA BILHETE EM CRITICA QUANDO O MESMO ESTIVER *      */
        /*"      *               COM CRITICAS PENDENTES CADASTRADAS               *      */
        /*"      *                                                                *      */
        /*"      *  EM 14/02/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.11        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 - HISTORIA SEM NUMERO                              *      */
        /*"      *                                                                *      */
        /*"      *             - ALTERACAO DO CODIGO DO PARCEIRO DA CAPITALIZACAO,*      */
        /*"      *               DE CAIXA SEGUROS (01) PARA CAIXA VIDA E          *      */
        /*"      *               PREVIDENCIA (03).                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/12/2019 - LUIZ FERNANDO GON�ALVES                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/03/2020 - HUSNI ALI HUSNI - VOLTAR V.10                *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.10        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - HISTORIA 178780                                  *      */
        /*"      *             - MUDANCAS DE PRODUTOS ACOPLADOS - CAP             *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/01/2019 - RIBAMAR MARQUES (ALTRAN)                     *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - CAD 64.999                                       *      */
        /*"      *            ADAPTAR OS PROGRAMAS DE VIDA PARA UTILIZAREM A NOVA *      */
        /*"      *           ROTINA DE COMPRA DA CAP QUE SOFREU ALTERACAO,        *      */
        /*"      *           MODIFICANDO A CHAMADA DA ROTINA FC0105B PARA FC0105S.*      */
        /*"      *                                                                *      */
        /*"      *   EM 22/12/2011 - FAST COMPUTER - ROGERIO PEREIRA              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - CAD 31.934                                       *      */
        /*"      *                                                                *      */
        /*"      *               - INCLUSAO DO CAMPO LK-NUM-NSA NOS PARAMETROS DA *      */
        /*"      *                 CHAMADA DA ROTINA FC0105B.                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/11/2009 - FAST COMPUTER - TERCIO FREITAS               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05                                                    *      */
        /*"      *             - CAD 24.589                                       *      */
        /*"      *               CORRECAO DO ABEND OCORRIDO                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/05/2009 - FAST COMPUTER            PROCURE POR V.05    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04                                                    *      */
        /*"      *             - CAD 24.390                                       *      */
        /*"      *               ERRO -305 NA ROTINA R9130- TABELAS:              *      */
        /*"      *               FDRCAP.FC_TITULO                                 *      */
        /*"      *               FDRCAP.FC_COMB_TITULOS                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/05/2009 - GEFAB                    PROCURE POR V.04    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03                                                    *      */
        /*"      *             - CAD 21.756                                       *      */
        /*"      *               MUDANCA NOS PRODUTOS ACOPLADOS COM CAPITALIZACAO *      */
        /*"      *               PARA ATENDER A CIRCULAR SUSEP                    *      */
        /*"      *               CIRCULAR 365 DE 27 DE MAIO DE 2008               *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/03/2009 - FAST COMPUTER            PROCURE POR V.03    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    PROJETO FGV  (POLITEC)  WELLINGTON VERAS  -  TE39902        *      */
        /*"      *                                                                *      */
        /*"      * 14/11/2008   INIBIR O COMANDO DISPLAY               - WV1108   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  WANGER 10/11/2008           V.02   *      */
        /*"      *                             CADMUS 17054.                      *      */
        /*"      *                             NAO ESTAVA GERANDO SORTEIO DE CAP  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  CLOVIS 07/11/2008           V.01   *      */
        /*"      *                             CADMUS 17054.                      *      */
        /*"      *                             ESTAVA REPRESANDO BILHETES QUANDO  *      */
        /*"      *                             BUSCAVA COBERTURA PARA RAMO 72.    *      */
        /*"      *                             O CORRETO E RAMO 14.               *      */
        /*"      *                                                                *      */
        /*"      *                             CADEIA DE COMISSIONAMENTO.         *      */
        /*"      *                                                                *      */
        /*"      *                             1402 - FENAE           R$2,02.     *      */
        /*"      *                             1402 - INDICADOR       R$2,74.     *      */
        /*"      *                             1402 - BALCAO          R$3,65.     *      */
        /*"      *                             1402 - CRP             R$0,91.     *      */
        /*"      *                                                                *      */
        /*"      *                             SSI 22564/2007 PARA PRODUTO 1405   *      */
        /*"      *                                                                *      */
        /*"      *                             1405 - FENAE           R$3,00.     *      */
        /*"      *                             1405 - INDICADOR       R$2,74.     *      */
        /*"      *                             1405 - BALCAO          R$6,82.     *      */
        /*"      *                             1405 - CRP             R$0,00.     *      */
        /*"      *                                                                *      */
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
        /*"      *   EM 01/03/2004                                                *      */
        /*"      *   ALTERA COMISSAO FENAE PARA R$2,02 (FIXO).                    *      */
        /*"      *   CORRETOR 17256 PARA DOCUMENTOS COM QUITACAO                  *      */
        /*"      *                  A PARTIR DE 01/12/2003.                       *      */
        /*"      *                         PROCURE POR CL0304                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 13/07/2006            LUCIA  VIEIRA                       *      */
        /*"      *   IMPEDE MOVIMEMTO DESCRICAO CBO PARA CBO MAIOR QUE 1000       *      */
        /*"      *                                                                *      */
        /*"      *                         PROCURE POR LV0706                     *      */
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
        /*"      *-----------------------------------------------------------------      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
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
        /*"77         WWORK-RAMO-ANT      PIC S9(004)                COMP.*/
        public IntBasis WWORK_RAMO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WWORK-OPCAO-ANT     PIC S9(004)                COMP.*/
        public IntBasis WWORK_OPCAO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WIND                PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W-FCRCAP            PIC  X(001)      VALUE ' '.*/
        public StringBasis W_FCRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
        /*"77         W-FCRCAP2           PIC  X(001)      VALUE ' '.*/
        public StringBasis W_FCRCAP2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
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
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTMOVACB     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVACB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTCURRENT    PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"77         WSIND-NUM-APOL      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis WSIND_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77         V0ENDO-INIVIG-ANT   PIC  X(010).*/
        public StringBasis V0ENDO_INIVIG_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-TERVIG-ANT   PIC  X(010).*/
        public StringBasis V0ENDO_TERVIG_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"77         PROD-COD-EMPRESA     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis PROD_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         PARM-COD-EMPR-CAP    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis PARM_COD_EMPR_CAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-ERRO-COUNT               PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WS_ERRO_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-I-ERRO                   PIC  9(003) VALUE ZEROS.*/
        public IntBasis WS_I_ERRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"01  WS-FLAG-TEM-ERRO            PIC  X(001) VALUE 'N'.*/
        public StringBasis WS_FLAG_TEM_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WORK-TAB-ERROS-CERT.*/
        public BI6005B_WORK_TAB_ERROS_CERT WORK_TAB_ERROS_CERT { get; set; } = new BI6005B_WORK_TAB_ERROS_CERT();
        public class BI6005B_WORK_TAB_ERROS_CERT : VarBasis
        {
            /*"    05  WS-TAB-ERROS-CERT   OCCURS 100 TIMES.*/
            public ListBasis<BI6005B_WS_TAB_ERROS_CERT> WS_TAB_ERROS_CERT { get; set; } = new ListBasis<BI6005B_WS_TAB_ERROS_CERT>(100);
            public class BI6005B_WS_TAB_ERROS_CERT : VarBasis
            {
                /*"      10  TB-ERRO-CERT          PIC S9(004) COMP.*/
                public IntBasis TB_ERRO_CERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"01  TAB-CBO1.*/
            }
        }
        public BI6005B_TAB_CBO1 TAB_CBO1 { get; set; } = new BI6005B_TAB_CBO1();
        public class BI6005B_TAB_CBO1 : VarBasis
        {
            /*"    05      TAB-CBO.*/
            public BI6005B_TAB_CBO TAB_CBO { get; set; } = new BI6005B_TAB_CBO();
            public class BI6005B_TAB_CBO : VarBasis
            {
                /*"      10    FILLER    OCCURS    999   TIMES.*/
                public ListBasis<BI6005B_FILLER_0> FILLER_0 { get; set; } = new ListBasis<BI6005B_FILLER_0>(999);
                public class BI6005B_FILLER_0 : VarBasis
                {
                    /*"        15  TAB-DESCR-CBO-C          PIC  X(20).*/
                    public StringBasis TAB_DESCR_CBO_C { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                    /*"01 WS-NUMBIL                    PIC  9(015)   VALUE ZEROS.*/
                }
            }
        }
        public IntBasis WS_NUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
        /*"01 WS-APOLICE-ANT               PIC  9(013)   VALUE ZEROS.*/
        public IntBasis WS_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"01           WS-TIME.*/
        public BI6005B_WS_TIME WS_TIME { get; set; } = new BI6005B_WS_TIME();
        public class BI6005B_WS_TIME : VarBasis
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
        private _REDEF_BI6005B_WS000_HORA_TIME_REDF _ws000_hora_time_redf { get; set; }
        public _REDEF_BI6005B_WS000_HORA_TIME_REDF WS000_HORA_TIME_REDF
        {
            get { _ws000_hora_time_redf = new _REDEF_BI6005B_WS000_HORA_TIME_REDF(); _.Move(WS000_HORA_TIME, _ws000_hora_time_redf); VarBasis.RedefinePassValue(WS000_HORA_TIME, _ws000_hora_time_redf, WS000_HORA_TIME); _ws000_hora_time_redf.ValueChanged += () => { _.Move(_ws000_hora_time_redf, WS000_HORA_TIME); }; return _ws000_hora_time_redf; }
            set { VarBasis.RedefinePassValue(value, _ws000_hora_time_redf, WS000_HORA_TIME); }
        }  //Redefines
        public class _REDEF_BI6005B_WS000_HORA_TIME_REDF : VarBasis
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

            public _REDEF_BI6005B_WS000_HORA_TIME_REDF()
            {
                WS000_HT.ValueChanged += OnValueChanged;
                WS000_P1.ValueChanged += OnValueChanged;
                WS000_MT.ValueChanged += OnValueChanged;
                WS000_P2.ValueChanged += OnValueChanged;
                WS000_ST.ValueChanged += OnValueChanged;
            }

        }
        public BI6005B_WS000_PARM_PROSOMD1 WS000_PARM_PROSOMD1 { get; set; } = new BI6005B_WS000_PARM_PROSOMD1();
        public class BI6005B_WS000_PARM_PROSOMD1 : VarBasis
        {
            /*"  05         WS000-DATA01       PIC  9(008).*/
            public IntBasis WS000_DATA01 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05         WS000-QTDIAS       PIC S9(005) COMP-3.*/
            public IntBasis WS000_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05         WS000-DATA02       PIC  9(008).*/
            public IntBasis WS000_DATA02 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"01         WS002-ACUMULADORES.*/
        }
        public BI6005B_WS002_ACUMULADORES WS002_ACUMULADORES { get; set; } = new BI6005B_WS002_ACUMULADORES();
        public class BI6005B_WS002_ACUMULADORES : VarBasis
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
        public BI6005B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new BI6005B_AREA_DE_WORK();
        public class BI6005B_AREA_DE_WORK : VarBasis
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
            /*"  05         WFIM-CBO          PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_CBO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-FCAP         PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_FCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
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
            /*"  05         WS-RENOVACAO      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WS_RENOVACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WWORK-FUNDAO      PIC  X(001)    VALUE SPACE.*/
            public StringBasis WWORK_FUNDAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WPROC-BILHETES    PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WPROC_BILHETES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WTEM-PROPESTIP    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_PROPESTIP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WWORK-NUM-APOL    PIC  9(013)    VALUE ZEROS.*/
            public IntBasis WWORK_NUM_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUM-APOL.*/
            private _REDEF_BI6005B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI6005B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI6005B_FILLER_1(); _.Move(WWORK_NUM_APOL, _filler_1); VarBasis.RedefinePassValue(WWORK_NUM_APOL, _filler_1, WWORK_NUM_APOL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WWORK_NUM_APOL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WWORK_NUM_APOL); }
            }  //Redefines
            public class _REDEF_BI6005B_FILLER_1 : VarBasis
            {
                /*"    10       WWORK-ORG-APOL    PIC  9(003).*/
                public IntBasis WWORK_ORG_APOL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-RMO-APOL    PIC  9(002).*/
                public IntBasis WWORK_RMO_APOL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-SEQ-APOL    PIC  9(008).*/
                public IntBasis WWORK_SEQ_APOL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  05         WWORK-PCPARCOR-I  PIC S9(003)V99   COMP-3.*/

                public _REDEF_BI6005B_FILLER_1()
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
            /*"  05         AUX-VLCOMIS       PIC S9(013)V99       COMP-3.*/
            public DoubleBasis AUX_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WWORK-NUM-ITENS   PIC S9(009)    COMP.*/
            public IntBasis WWORK_NUM_ITENS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         WWORK-NUM-ORDEM   PIC  9(014)    VALUE ZEROS.*/
            public IntBasis WWORK_NUM_ORDEM { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUM-ORDEM.*/
            private _REDEF_BI6005B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_BI6005B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_BI6005B_FILLER_2(); _.Move(WWORK_NUM_ORDEM, _filler_2); VarBasis.RedefinePassValue(WWORK_NUM_ORDEM, _filler_2, WWORK_NUM_ORDEM); _filler_2.ValueChanged += () => { _.Move(_filler_2, WWORK_NUM_ORDEM); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WWORK_NUM_ORDEM); }
            }  //Redefines
            public class _REDEF_BI6005B_FILLER_2 : VarBasis
            {
                /*"    10       WWORK-ORD-CONGE   PIC  9(004).*/
                public IntBasis WWORK_ORD_CONGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-ORD-ORGAO   PIC  9(003).*/
                public IntBasis WWORK_ORD_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-ORD-SEQUE   PIC  9(007).*/
                public IntBasis WWORK_ORD_SEQUE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"  05         WWORK-NUMBIL      PIC  9(015)    VALUE ZEROS.*/

                public _REDEF_BI6005B_FILLER_2()
                {
                    WWORK_ORD_CONGE.ValueChanged += OnValueChanged;
                    WWORK_ORD_ORGAO.ValueChanged += OnValueChanged;
                    WWORK_ORD_SEQUE.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_NUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUMBIL.*/
            private _REDEF_BI6005B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_BI6005B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_BI6005B_FILLER_3(); _.Move(WWORK_NUMBIL, _filler_3); VarBasis.RedefinePassValue(WWORK_NUMBIL, _filler_3, WWORK_NUMBIL); _filler_3.ValueChanged += () => { _.Move(_filler_3, WWORK_NUMBIL); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WWORK_NUMBIL); }
            }  //Redefines
            public class _REDEF_BI6005B_FILLER_3 : VarBasis
            {
                /*"    10       FILLER            PIC  9(004).*/
                public IntBasis FILLER_4 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-NRRCAP      PIC  9(009).*/
                public IntBasis WWORK_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10       FILLER            PIC  9(002).*/
                public IntBasis FILLER_5 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WWORK-DATA.*/

                public _REDEF_BI6005B_FILLER_3()
                {
                    FILLER_4.ValueChanged += OnValueChanged;
                    WWORK_NRRCAP.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                }

            }
            public BI6005B_WWORK_DATA WWORK_DATA { get; set; } = new BI6005B_WWORK_DATA();
            public class BI6005B_WWORK_DATA : VarBasis
            {
                /*"    10       WWORK-ANO         PIC  9(004).*/
                public IntBasis WWORK_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WWORK-MES         PIC  9(002).*/
                public IntBasis WWORK_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WWORK-DIA         PIC  9(002).*/
                public IntBasis WWORK_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WWORK-ANO-BI      PIC  9(009)    COMP-3.*/
            }
            public IntBasis WWORK_ANO_BI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WDATA-SISTEMA.*/
            public BI6005B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new BI6005B_WDATA_SISTEMA();
            public class BI6005B_WDATA_SISTEMA : VarBasis
            {
                /*"    10       WDATA-SIS-ANO     PIC  X(004).*/
                public StringBasis WDATA_SIS_ANO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-MES     PIC  X(002).*/
                public StringBasis WDATA_SIS_MES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-DIA     PIC  X(002).*/
                public StringBasis WDATA_SIS_DIA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05         WWORK-DATAINI     PIC  9(008)  VALUE ZEROS.*/
            }
            public IntBasis WWORK_DATAINI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER            REDEFINES    WWORK-DATAINI.*/
            private _REDEF_BI6005B_FILLER_10 _filler_10 { get; set; }
            public _REDEF_BI6005B_FILLER_10 FILLER_10
            {
                get { _filler_10 = new _REDEF_BI6005B_FILLER_10(); _.Move(WWORK_DATAINI, _filler_10); VarBasis.RedefinePassValue(WWORK_DATAINI, _filler_10, WWORK_DATAINI); _filler_10.ValueChanged += () => { _.Move(_filler_10, WWORK_DATAINI); }; return _filler_10; }
                set { VarBasis.RedefinePassValue(value, _filler_10, WWORK_DATAINI); }
            }  //Redefines
            public class _REDEF_BI6005B_FILLER_10 : VarBasis
            {
                /*"    10       WWORK-DIAINI      PIC  9(002).*/
                public IntBasis WWORK_DIAINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-MESINI      PIC  9(002).*/
                public IntBasis WWORK_MESINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-ANOINI      PIC  9(004).*/
                public IntBasis WWORK_ANOINI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WWORK-DATATER     PIC  9(008)  VALUE ZEROS.*/

                public _REDEF_BI6005B_FILLER_10()
                {
                    WWORK_DIAINI.ValueChanged += OnValueChanged;
                    WWORK_MESINI.ValueChanged += OnValueChanged;
                    WWORK_ANOINI.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_DATATER { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER            REDEFINES    WWORK-DATATER.*/
            private _REDEF_BI6005B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_BI6005B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_BI6005B_FILLER_11(); _.Move(WWORK_DATATER, _filler_11); VarBasis.RedefinePassValue(WWORK_DATATER, _filler_11, WWORK_DATATER); _filler_11.ValueChanged += () => { _.Move(_filler_11, WWORK_DATATER); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, WWORK_DATATER); }
            }  //Redefines
            public class _REDEF_BI6005B_FILLER_11 : VarBasis
            {
                /*"    10       WWORK-DIATER      PIC  9(002).*/
                public IntBasis WWORK_DIATER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-MESTER      PIC  9(002).*/
                public IntBasis WWORK_MESTER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WWORK-ANOTER      PIC  9(004).*/
                public IntBasis WWORK_ANOTER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WWORK-QTCOSSEG    PIC  9(002)  VALUE ZEROS.*/

                public _REDEF_BI6005B_FILLER_11()
                {
                    WWORK_DIATER.ValueChanged += OnValueChanged;
                    WWORK_MESTER.ValueChanged += OnValueChanged;
                    WWORK_ANOTER.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_QTCOSSEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WDATA-CURR.*/
            public BI6005B_WDATA_CURR WDATA_CURR { get; set; } = new BI6005B_WDATA_CURR();
            public class BI6005B_WDATA_CURR : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CABEC.*/
            }
            public BI6005B_WDATA_CABEC WDATA_CABEC { get; set; } = new BI6005B_WDATA_CABEC();
            public class BI6005B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WS-CODANGAR-R.*/
            }
            public BI6005B_WS_CODANGAR_R WS_CODANGAR_R { get; set; } = new BI6005B_WS_CODANGAR_R();
            public class BI6005B_WS_CODANGAR_R : VarBasis
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
            public BI6005B_PROM11W099 PROM11W099 { get; set; } = new BI6005B_PROM11W099();
            public class BI6005B_PROM11W099 : VarBasis
            {
                /*"    10       PROM11W099-NUMERO   PIC  9(015).*/
                public IntBasis PROM11W099_NUMERO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10       PROM11W099-TAM      PIC S9(004)   COMP.*/
                public IntBasis PROM11W099_TAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10       PROM11W099-DAC      PIC  X(001).*/
                public StringBasis PROM11W099_DAC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05         WS-NUMREC-R.*/
            }
            public BI6005B_WS_NUMREC_R WS_NUMREC_R { get; set; } = new BI6005B_WS_NUMREC_R();
            public class BI6005B_WS_NUMREC_R : VarBasis
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
            /*"  05         AC-I-FCAP             PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_I_FCAP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-L-FCAP             PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_L_FCAP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
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
            /*"  05   WS-COMBINACAO                 PIC  X(020).*/
            public StringBasis WS_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05   WS-COMBINACAO-R               REDEFINES       WS-COMBINACAO.*/
            private _REDEF_BI6005B_WS_COMBINACAO_R _ws_combinacao_r { get; set; }
            public _REDEF_BI6005B_WS_COMBINACAO_R WS_COMBINACAO_R
            {
                get { _ws_combinacao_r = new _REDEF_BI6005B_WS_COMBINACAO_R(); _.Move(WS_COMBINACAO, _ws_combinacao_r); VarBasis.RedefinePassValue(WS_COMBINACAO, _ws_combinacao_r, WS_COMBINACAO); _ws_combinacao_r.ValueChanged += () => { _.Move(_ws_combinacao_r, WS_COMBINACAO); }; return _ws_combinacao_r; }
                set { VarBasis.RedefinePassValue(value, _ws_combinacao_r, WS_COMBINACAO); }
            }  //Redefines
            public class _REDEF_BI6005B_WS_COMBINACAO_R : VarBasis
            {
                /*"       10  WS-COMB OCCURS 20 TIMES   PIC  X(001).*/
                public ListBasis<StringBasis, string> WS_COMB { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 20);
                /*"  05   WS-COMBINACAO-9               PIC  9(009).*/

                public _REDEF_BI6005B_WS_COMBINACAO_R()
                {
                    WS_COMB.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_COMBINACAO_9 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05   WS-NUM-TITULO-X.*/
            public BI6005B_WS_NUM_TITULO_X WS_NUM_TITULO_X { get; set; } = new BI6005B_WS_NUM_TITULO_X();
            public class BI6005B_WS_NUM_TITULO_X : VarBasis
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
            /*"01           FC0001S-LINKAGE.*/
        }
        public BI6005B_FC0001S_LINKAGE FC0001S_LINKAGE { get; set; } = new BI6005B_FC0001S_LINKAGE();
        public class BI6005B_FC0001S_LINKAGE : VarBasis
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
            /*"  05        WABEND.*/
            public BI6005B_WABEND WABEND { get; set; } = new BI6005B_WABEND();
            public class BI6005B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'BI6005B '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"BI6005B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            }
        }


        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Dclgens.MOVFEDCA MOVFEDCA { get; set; } = new Dclgens.MOVFEDCA();
        public Dclgens.TITFEDCA TITFEDCA { get; set; } = new Dclgens.TITFEDCA();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.BILHECOB BILHECOB { get; set; } = new Dclgens.BILHECOB();
        public Dclgens.FCTITULO FCTITULO { get; set; } = new Dclgens.FCTITULO();
        public Dclgens.FCCOMTIT FCCOMTIT { get; set; } = new Dclgens.FCCOMTIT();
        public BI6005B_V0BILHETE V0BILHETE { get; set; } = new BI6005B_V0BILHETE();
        public BI6005B_V1COSSEGPROD V1COSSEGPROD { get; set; } = new BI6005B_V1COSSEGPROD();
        public BI6005B_V1RCAPCOMP V1RCAPCOMP { get; set; } = new BI6005B_V1RCAPCOMP();
        public BI6005B_CCBO CCBO { get; set; } = new BI6005B_CCBO();
        public BI6005B_FCAP FCAP { get; set; } = new BI6005B_FCAP();
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
            /*" -1229- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1232- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1235- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1248- DISPLAY 'BI6005B - VERSAO V.11 - CADMUS 402982' */
            _.Display($"BI6005B - VERSAO V.11 - CADMUS 402982");

            /*" -1250- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -1252- INITIALIZE TAB-CBO1. */
            _.Initialize(
                TAB_CBO1
            );

            /*" -1254- PERFORM R8100-00-DECLARE-CBO. */

            R8100_00_DECLARE_CBO_SECTION();

            /*" -1256- PERFORM R8110-00-FETCH-CBO. */

            R8110_00_FETCH_CBO_SECTION();

            /*" -1257- IF WFIM-CBO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CBO.IsEmpty())
            {

                /*" -1258- DISPLAY '8110 - PROBLEMA NO FETCH DA CBO 1� LEITURA' */
                _.Display($"8110 - PROBLEMA NO FETCH DA CBO 1� LEITURA");

                /*" -1260- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1263- PERFORM R8120-00-CARREGA-CBO UNTIL WFIM-CBO EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_CBO == "S"))
            {

                R8120_00_CARREGA_CBO_SECTION();
            }

            /*" -1266- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -1267- MOVE ' ' TO W-FCRCAP. */
            _.Move(" ", W_FCRCAP);

            /*" -1268- MOVE ' ' TO W-FCRCAP2. */
            _.Move(" ", W_FCRCAP2);

            /*" -1270- PERFORM R0900-00-DECLARE-V0BILHETE. */

            R0900_00_DECLARE_V0BILHETE_SECTION();

            /*" -1272- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -1274- PERFORM R0910-00-FETCH-V0BILHETE. */

            R0910_00_FETCH_V0BILHETE_SECTION();

            /*" -1275- IF WFIM-V0BILHETE NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0BILHETE.IsEmpty())
            {

                /*" -1277- DISPLAY 'BI6005B - NAO FOI SELECIONADO BILHETE P/ EMISSAO...' */
                _.Display($"BI6005B - NAO FOI SELECIONADO BILHETE P/ EMISSAO...");

                /*" -1278- GO TO R0000-90-FINALIZA */

                R0000_90_FINALIZA(); //GOTO
                return;

                /*" -1280- END-IF. */
            }


            /*" -1283- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V0BILHETE NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0BILHETE.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1285- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -1285- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1291- MOVE '1' TO W-FCRCAP */
            _.Move("1", W_FCRCAP);

            /*" -1292- MOVE ' ' TO W-FCRCAP2 */
            _.Move(" ", W_FCRCAP2);

            /*" -1295- MOVE ' ' TO WFIM-FCAP */
            _.Move(" ", AREA_DE_WORK.WFIM_FCAP);

            /*" -1297- PERFORM R4100-00-TOTAIS-CONTROLE. */

            R4100_00_TOTAIS_CONTROLE_SECTION();

            /*" -1297- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1301- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1302- DISPLAY ' ' */
            _.Display($" ");

            /*" -1303- DISPLAY '*--------  BI6005B - FIM NORMAL  --------*' */
            _.Display($"*--------  BI6005B - FIM NORMAL  --------*");

            /*" -1305- DISPLAY ' ' */
            _.Display($" ");

            /*" -1305- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -1316- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -1322- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1326- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1327- DISPLAY 'ERRO SELECT V1SISTEMA EM' */
                _.Display($"ERRO SELECT V1SISTEMA EM");

                /*" -1329- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1331- MOVE '0101' TO WNR-EXEC-SQL. */
            _.Move("0101", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -1337- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_2 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_2();

            /*" -1340- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1341- DISPLAY 'ERRO SELECT V1SISTEMA CB' */
                _.Display($"ERRO SELECT V1SISTEMA CB");

                /*" -1343- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1344- MOVE 5 TO WS-VLMAIOR */
            _.Move(5, AREA_DE_WORK.WS_VLMAIOR);

            /*" -1346- MOVE 1 TO WS-VLDIFE. */
            _.Move(1, AREA_DE_WORK.WS_VLDIFE);

            /*" -1346- DISPLAY 'DATA SISTEMA "CB": ' V1SIST-DTMOVACB. */

            $"DATA SISTEMA CB: {V1SIST_DTMOVACB}"
            .Display();

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1322- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' WITH UR END-EXEC. */

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
            /*" -1337- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVACB FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CB' WITH UR END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVACB, V1SIST_DTMOVACB);
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0BILHETE-SECTION */
        private void R0900_00_DECLARE_V0BILHETE_SECTION()
        {
            /*" -1357- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -1359- MOVE SPACE TO WFIM-V0BILHETE. */
            _.Move("", AREA_DE_WORK.WFIM_V0BILHETE);

            /*" -1386- PERFORM R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1 */

            R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1();

            /*" -1388- PERFORM R0900_00_DECLARE_V0BILHETE_DB_OPEN_1 */

            R0900_00_DECLARE_V0BILHETE_DB_OPEN_1();

            /*" -1391- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1392- DISPLAY 'PROBLEMAS NO OPEN (V0BILHETE) ... ' */
                _.Display($"PROBLEMAS NO OPEN (V0BILHETE) ... ");

                /*" -1392- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0BILHETE-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1()
        {
            /*" -1386- EXEC SQL DECLARE V0BILHETE CURSOR WITH HOLD FOR SELECT NUMBIL , FONTE , AGECOBR , NUM_MATRICULA , COD_AGENCIA , CODCLIEN , PROFISSAO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB, NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DTQITBCO , VLRCAP , RAMO , COD_USUARIO , SITUACAO , NUM_APOL_ANTERIOR FROM SEGUROS.V0BILHETE WHERE SITUACAO = '0' AND NUM_APOL_ANTERIOR > 0 AND RAMO = 14 WITH UR END-EXEC. */
            V0BILHETE = new BI6005B_V0BILHETE(false);
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
							WHERE SITUACAO = '0' 
							AND NUM_APOL_ANTERIOR > 0 
							AND RAMO = 14";

                return query;
            }
            V0BILHETE.GetQueryEvent += GetQuery_V0BILHETE;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0BILHETE-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0BILHETE_DB_OPEN_1()
        {
            /*" -1388- EXEC SQL OPEN V0BILHETE END-EXEC. */

            V0BILHETE.Open();

        }

        [StopWatch]
        /*" R1080-00-GRAVA-V0APOLCOSCED-DB-DECLARE-1 */
        public void R1080_00_GRAVA_V0APOLCOSCED_DB_DECLARE_1()
        {
            /*" -2964- EXEC SQL DECLARE V1COSSEGPROD CURSOR FOR SELECT CODPRODU , RAMO , CONGENER , PCPARTIC , PCCOMCOS , PCADMCOS , DTINIVIG , DTTERVIG , SITUACAO FROM SEGUROS.V1COSSEGPROD WHERE CODPRODU = :V1BILP-CODPRODU AND RAMO = :WWORK-RAMO-ANT AND DTINIVIG <= :V0ENDO-DTINIVIG AND DTTERVIG >= :V0ENDO-DTINIVIG AND SUBPRODU = :WWORK-OPCAO-ANT WITH UR END-EXEC. */
            V1COSSEGPROD = new BI6005B_V1COSSEGPROD(true);
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
            /*" -1401- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0910_10_LE */

            R0910_10_LE();

        }

        [StopWatch]
        /*" R0910-10-LE */
        private void R0910_10_LE(bool isPerform = false)
        {
            /*" -1424- PERFORM R0910_10_LE_DB_FETCH_1 */

            R0910_10_LE_DB_FETCH_1();

            /*" -1428- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1429- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1429- PERFORM R0910_10_LE_DB_CLOSE_1 */

                    R0910_10_LE_DB_CLOSE_1();

                    /*" -1431- MOVE 'S' TO WFIM-V0BILHETE */
                    _.Move("S", AREA_DE_WORK.WFIM_V0BILHETE);

                    /*" -1432- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -1433- ELSE */
                }
                else
                {


                    /*" -1434- DISPLAY 'R0910-00 (ERRO -  FETCH V0BILHETE)...' */
                    _.Display($"R0910-00 (ERRO -  FETCH V0BILHETE)...");

                    /*" -1436- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1437- IF V0BILH-NUMBIL EQUAL 82340761517 */

            if (V0BILH_NUMBIL == 82340761517)
            {

                /*" -1439- GO TO R0910-10-LE. */
                new Task(() => R0910_10_LE()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1440- INITIALIZE WORK-TAB-ERROS-CERT */
            _.Initialize(
                WORK_TAB_ERROS_CERT
            );

            /*" -1441- MOVE ZEROS TO WS-I-ERRO */
            _.Move(0, WS_I_ERRO);

            /*" -1442- . */

            /*" -1443- MOVE V0BILH-NUMBIL TO WS-NUMBIL. */
            _.Move(V0BILH_NUMBIL, WS_NUMBIL);

            /*" -1446- MOVE V0BILH-NUM-APO-ANT TO WS-APOLICE-ANT. */
            _.Move(V0BILH_NUM_APO_ANT, WS_APOLICE_ANT);

            /*" -1454- ADD 1 TO WACC-LIDOS WACC-DISPLAY. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;
            AREA_DE_WORK.WACC_DISPLAY.Value = AREA_DE_WORK.WACC_DISPLAY + 1;

            /*" -1455- IF WACC-PROCESSADOS EQUAL 500 */

            if (AREA_DE_WORK.WACC_PROCESSADOS == 500)
            {

                /*" -1456- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -1457- DISPLAY 'TOTAL ATUALIZADO.. ' WPROC-BILHETES '  ' WS-TIME */

                $"TOTAL ATUALIZADO.. {AREA_DE_WORK.WPROC_BILHETES}  {WS_TIME}"
                .Display();

                /*" -1457- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -1458- MOVE ZEROS TO WACC-PROCESSADOS. */
                _.Move(0, AREA_DE_WORK.WACC_PROCESSADOS);
            }


        }

        [StopWatch]
        /*" R0910-10-LE-DB-FETCH-1 */
        public void R0910_10_LE_DB_FETCH_1()
        {
            /*" -1424- EXEC SQL FETCH V0BILHETE INTO :V0BILH-NUMBIL , :V0BILH-FONTE , :V0BILH-AGECOBR , :V0BILH-NUM-MATR , :V0BILH-AGENCIA , :V0BILH-CODCLIEN , :V0BILH-PROFISSAO , :V0BILH-AGENCIA-DEB , :V0BILH-OPERACAO-DEB , :V0BILH-NUMCTA-DEB , :V0BILH-DIGCTA-DEB , :V0BILH-OPCAO-COBER , :V0BILH-DTQITBCO , :V0BILH-VLRCAP , :V0BILH-RAMO , :V0BILH-CODUSU , :V0BILH-SITUACAO , :V0BILH-NUM-APO-ANT END-EXEC. */

            if (V0BILHETE.Fetch())
            {
                _.Move(V0BILHETE.V0BILH_NUMBIL, V0BILH_NUMBIL);
                _.Move(V0BILHETE.V0BILH_FONTE, V0BILH_FONTE);
                _.Move(V0BILHETE.V0BILH_AGECOBR, V0BILH_AGECOBR);
                _.Move(V0BILHETE.V0BILH_NUM_MATR, V0BILH_NUM_MATR);
                _.Move(V0BILHETE.V0BILH_AGENCIA, V0BILH_AGENCIA);
                _.Move(V0BILHETE.V0BILH_CODCLIEN, V0BILH_CODCLIEN);
                _.Move(V0BILHETE.V0BILH_PROFISSAO, V0BILH_PROFISSAO);
                _.Move(V0BILHETE.V0BILH_AGENCIA_DEB, V0BILH_AGENCIA_DEB);
                _.Move(V0BILHETE.V0BILH_OPERACAO_DEB, V0BILH_OPERACAO_DEB);
                _.Move(V0BILHETE.V0BILH_NUMCTA_DEB, V0BILH_NUMCTA_DEB);
                _.Move(V0BILHETE.V0BILH_DIGCTA_DEB, V0BILH_DIGCTA_DEB);
                _.Move(V0BILHETE.V0BILH_OPCAO_COBER, V0BILH_OPCAO_COBER);
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
            /*" -1429- EXEC SQL CLOSE V0BILHETE END-EXEC */

            V0BILHETE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1470- MOVE V0BILH-RAMO TO WWORK-RAMO-ANT */
            _.Move(V0BILH_RAMO, WWORK_RAMO_ANT);

            /*" -1472- MOVE V0BILH-OPCAO-COBER TO WWORK-OPCAO-ANT. */
            _.Move(V0BILH_OPCAO_COBER, WWORK_OPCAO_ANT);

            /*" -1473- MOVE ZEROES TO V0ADIA-VALADT. */
            _.Move(0, V0ADIA_VALADT);

            /*" -1474- MOVE SPACES TO WWORK-MIN-DTINIVIG. */
            _.Move("", WWORK_MIN_DTINIVIG);

            /*" -1475- MOVE SPACES TO WWORK-MAX-DTTERVIG. */
            _.Move("", WWORK_MAX_DTTERVIG);

            /*" -1476- MOVE SPACES TO WS-RENOVACAO. */
            _.Move("", AREA_DE_WORK.WS_RENOVACAO);

            /*" -1478- MOVE ZEROES TO WWORK-NUM-ITENS. */
            _.Move(0, AREA_DE_WORK.WWORK_NUM_ITENS);

            /*" -1480- PERFORM R3060-00-VERIFICA-CRTCA-PEND */

            R3060_00_VERIFICA_CRTCA_PEND_SECTION();

            /*" -1481- IF WS-ERRO-COUNT > ZEROS */

            if (WS_ERRO_COUNT > 00)
            {

                /*" -1482- MOVE '1' TO V0BILH-SITUACAO */
                _.Move("1", V0BILH_SITUACAO);

                /*" -1483- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -1486- DISPLAY 'BILHETE POSSUI CRITICA PENDENTE CADASTRADA' '. ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN ' ' WS-ERRO-COUNT */

                $"BILHETE POSSUI CRITICA PENDENTE CADASTRADA. {V0BILH_NUMBIL} {V0BILH_CODCLIEN} {WS_ERRO_COUNT}"
                .Display();

                /*" -1487- GO TO R1000-00-LEITURA */

                R1000_00_LEITURA(); //GOTO
                return;

                /*" -1492- END-IF */
            }


            /*" -1493- IF V0BILH-NUM-APO-ANT GREATER 0 */

            if (V0BILH_NUM_APO_ANT > 0)
            {

                /*" -1494- PERFORM R3270-00-SELECT-APOLICE-ANT */

                R3270_00_SELECT_APOLICE_ANT_SECTION();

                /*" -1495- IF WS-RENOVACAO EQUAL '*' */

                if (AREA_DE_WORK.WS_RENOVACAO == "*")
                {

                    /*" -1496- GO TO R1000-00-LEITURA */

                    R1000_00_LEITURA(); //GOTO
                    return;

                    /*" -1497- ELSE */
                }
                else
                {


                    /*" -1498- PERFORM R3275-00-SELECT-ENDOSSO-ANT */

                    R3275_00_SELECT_ENDOSSO_ANT_SECTION();

                    /*" -1499- IF WS-RENOVACAO EQUAL '*' */

                    if (AREA_DE_WORK.WS_RENOVACAO == "*")
                    {

                        /*" -1544- GO TO R1000-00-LEITURA. */

                        R1000_00_LEITURA(); //GOTO
                        return;
                    }

                }

            }


            /*" -1546- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -1554- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -1558- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1559- DISPLAY 'R1000-00 (ERRO - SELECT V1NUMERO_AES)...' */
                _.Display($"R1000-00 (ERRO - SELECT V1NUMERO_AES)...");

                /*" -1561- DISPLAY 'ORGAO: 10 ' 'RAMO: ' V0BILH-RAMO */

                $"ORGAO: 10 RAMO: {V0BILH_RAMO}"
                .Display();

                /*" -1563- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1566- COMPUTE V0NAES-SEQ-APOL = V1NAES-SEQ-APOL + 1. */
            V0NAES_SEQ_APOL.Value = V1NAES_SEQ_APOL + 1;

            /*" -1568- MOVE '1015' TO WNR-EXEC-SQL. */
            _.Move("1015", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -1578- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_2();

            /*" -1584- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1585- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1586- DISPLAY 'R1015-00 (NAO ENCONTRADO V0BILHETE_PLCOBER)' */
                    _.Display($"R1015-00 (NAO ENCONTRADO V0BILHETE_PLCOBER)");

                    /*" -1588- DISPLAY 'BILHETE: ' V0BILH-NUMBIL ' ' V0BILH-RAMO ' ' V0BILH-OPCAO-COBER */

                    $"BILHETE: {V0BILH_NUMBIL} {V0BILH_RAMO} {V0BILH_OPCAO_COBER}"
                    .Display();

                    /*" -1589- GO TO R1000-00-LEITURA */

                    R1000_00_LEITURA(); //GOTO
                    return;

                    /*" -1590- ELSE */
                }
                else
                {


                    /*" -1591- DISPLAY 'R1015-00 (ERRO - SELECT V0BILHETE_PLCOBER)' */
                    _.Display($"R1015-00 (ERRO - SELECT V0BILHETE_PLCOBER)");

                    /*" -1594- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'RAMO: ' V0BILH-RAMO '  ' 'OPCAO COBER: ' V0BILH-OPCAO-COBER */

                    $"BILHETE: {V0BILH_NUMBIL}  RAMO: {V0BILH_RAMO}  OPCAO COBER: {V0BILH_OPCAO_COBER}"
                    .Display();

                    /*" -1596- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1597- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -1599- MOVE 'S' TO WS-SIVPF. */
            _.Move("S", AREA_DE_WORK.WS_SIVPF);

            /*" -1608- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_3 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_3();

            /*" -1612- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1613- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1614- MOVE 'N' TO WS-SIVPF */
                    _.Move("N", AREA_DE_WORK.WS_SIVPF);

                    /*" -1615- ELSE */
                }
                else
                {


                    /*" -1616- DISPLAY 'R1020-00 (ERRO - SELECT PROPOSTA_FIDELIZ)' */
                    _.Display($"R1020-00 (ERRO - SELECT PROPOSTA_FIDELIZ)");

                    /*" -1618- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'RAMO: ' V0BILH-RAMO '  ' */

                    $"BILHETE: {V0BILH_NUMBIL}  RAMO: {V0BILH_RAMO}  "
                    .Display();

                    /*" -1620- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1621- IF WS-SIVPF EQUAL 'N' */

            if (AREA_DE_WORK.WS_SIVPF == "N")
            {

                /*" -1622- MOVE '1021' TO WNR-EXEC-SQL */
                _.Move("1021", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

                /*" -1623- MOVE 'S' TO WS-SIVPF */
                _.Move("S", AREA_DE_WORK.WS_SIVPF);

                /*" -1629- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_4 */

                R1000_00_PROCESSA_REGISTRO_DB_SELECT_4();

                /*" -1631- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1632- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1633- MOVE 'N' TO WS-SIVPF */
                        _.Move("N", AREA_DE_WORK.WS_SIVPF);

                        /*" -1634- ELSE */
                    }
                    else
                    {


                        /*" -1635- DISPLAY 'R1021-00 (ERRO - SELECT CONVERSAO_SICOB)' */
                        _.Display($"R1021-00 (ERRO - SELECT CONVERSAO_SICOB)");

                        /*" -1637- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'RAMO: ' V0BILH-RAMO '  ' */

                        $"BILHETE: {V0BILH_NUMBIL}  RAMO: {V0BILH_RAMO}  "
                        .Display();

                        /*" -1639- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -1641- MOVE ZEROS TO WWORK-NUM-APOL */
            _.Move(0, AREA_DE_WORK.WWORK_NUM_APOL);

            /*" -1642- MOVE 10 TO WWORK-ORG-APOL. */
            _.Move(10, AREA_DE_WORK.FILLER_1.WWORK_ORG_APOL);

            /*" -1644- MOVE 14 TO WWORK-RMO-APOL. */
            _.Move(14, AREA_DE_WORK.FILLER_1.WWORK_RMO_APOL);

            /*" -1645- MOVE V0NAES-SEQ-APOL TO WWORK-SEQ-APOL. */
            _.Move(V0NAES_SEQ_APOL, AREA_DE_WORK.FILLER_1.WWORK_SEQ_APOL);

            /*" -1648- MOVE WWORK-NUM-APOL TO V0APOL-NUM-APOL. */
            _.Move(AREA_DE_WORK.WWORK_NUM_APOL, V0APOL_NUM_APOL);

            /*" -1650- MOVE '1040' TO WNR-EXEC-SQL. */
            _.Move("1040", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -1651- MOVE 0 TO V1BILC-COD-EMPR */
            _.Move(0, V1BILC_COD_EMPR);

            /*" -1652- MOVE V1BILP-CODPRODU TO V1BILC-CODPRODU */
            _.Move(V1BILP_CODPRODU, V1BILC_CODPRODU);

            /*" -1653- MOVE WWORK-RAMO-ANT TO V1BILC-RAMOFR */
            _.Move(WWORK_RAMO_ANT, V1BILC_RAMOFR);

            /*" -1654- MOVE 0 TO V1BILC-MODALIFR */
            _.Move(0, V1BILC_MODALIFR);

            /*" -1656- MOVE WWORK-OPCAO-ANT TO V1BILC-OPCAO */
            _.Move(WWORK_OPCAO_ANT, V1BILC_OPCAO);

            /*" -1670- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_5 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_5();

            /*" -1693- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1694- MOVE 1503 TO V0BILER-COD-ERRO */
                _.Move(1503, V0BILER_COD_ERRO);

                /*" -1695- PERFORM R3045-00-GRAVA-TAB-ERRO */

                R3045_00_GRAVA_TAB_ERRO_SECTION();

                /*" -1696- MOVE '1' TO V0BILH-SITUACAO */
                _.Move("1", V0BILH_SITUACAO);

                /*" -1698- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -1706- DISPLAY 'BILHETE    : ' V0BILH-NUMBIL '  ' */

                $"BILHETE    : {V0BILH_NUMBIL}  "
                .Display();

                /*" -1710- GO TO R1000-00-LEITURA. */

                R1000_00_LEITURA(); //GOTO
                return;
            }


            /*" -1711- IF V0BILH-RAMO EQUAL 82 */

            if (V0BILH_RAMO == 82)
            {

                /*" -1713- PERFORM R2990-00-VERIFICA-PROFISSAO. */

                R2990_00_VERIFICA_PROFISSAO_SECTION();
            }


            /*" -1715- PERFORM R3000-00-ACUMULA-BILHETE. */

            R3000_00_ACUMULA_BILHETE_SECTION();

            /*" -1716- IF WWORK-NUM-ITENS EQUAL ZEROES */

            if (AREA_DE_WORK.WWORK_NUM_ITENS == 00)
            {

                /*" -1718- GO TO R1000-00-LEITURA. */

                R1000_00_LEITURA(); //GOTO
                return;
            }


            /*" -1721- MOVE '1025' TO WNR-EXEC-SQL. */
            _.Move("1025", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -1727- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1 */

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1();

            /*" -1730- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1731- DISPLAY 'R1025-00 (ERRO - UPDATE V0NUMERO_AES)...' */
                _.Display($"R1025-00 (ERRO - UPDATE V0NUMERO_AES)...");

                /*" -1733- DISPLAY 'ORGAO: 10 ' 'RAMO: ' WWORK-RAMO-ANT */

                $"ORGAO: 10 RAMO: {WWORK_RAMO_ANT}"
                .Display();

                /*" -1735- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1737- ADD +1 TO AC-U-V0NUMERAES. */
            AREA_DE_WORK.AC_U_V0NUMERAES.Value = AREA_DE_WORK.AC_U_V0NUMERAES + +1;

            /*" -1740- ADD +1 TO AC-U-V0FONTE. */
            AREA_DE_WORK.AC_U_V0FONTE.Value = AREA_DE_WORK.AC_U_V0FONTE + +1;

            /*" -1741- COMPUTE WWORK-IS-APOL = V1BILC-IMPSEG-IX * WWORK-NUM-ITENS. */
            AREA_DE_WORK.WWORK_IS_APOL.Value = V1BILC_IMPSEG_IX * AREA_DE_WORK.WWORK_NUM_ITENS;

            /*" -1743- COMPUTE WWORK-PR-APOL = V1BILC-PRMTAR-IX * WWORK-NUM-ITENS. */
            AREA_DE_WORK.WWORK_PR_APOL.Value = V1BILC_PRMTAR_IX * AREA_DE_WORK.WWORK_NUM_ITENS;

            /*" -1745- MOVE V0BILH-CODCLIEN TO V0APOL-CODCLIEN. */
            _.Move(V0BILH_CODCLIEN, V0APOL_CODCLIEN);

            /*" -1746- MOVE WWORK-NUM-ITENS TO V0APOL-NUM-ITEM */
            _.Move(AREA_DE_WORK.WWORK_NUM_ITENS, V0APOL_NUM_ITEM);

            /*" -1747- MOVE ZEROS TO V0APOL-MODALIDA */
            _.Move(0, V0APOL_MODALIDA);

            /*" -1749- MOVE 10 TO V0APOL-ORGAO */
            _.Move(10, V0APOL_ORGAO);

            /*" -1751- MOVE 14 TO V0APOL-RAMO */
            _.Move(14, V0APOL_RAMO);

            /*" -1752- IF V0BILH-NUM-APO-ANT GREATER 0 */

            if (V0BILH_NUM_APO_ANT > 0)
            {

                /*" -1753- PERFORM R3270-00-SELECT-APOLICE-ANT */

                R3270_00_SELECT_APOLICE_ANT_SECTION();

                /*" -1754- IF WS-RENOVACAO EQUAL '*' */

                if (AREA_DE_WORK.WS_RENOVACAO == "*")
                {

                    /*" -1755- GO TO R1000-00-LEITURA */

                    R1000_00_LEITURA(); //GOTO
                    return;

                    /*" -1756- END-IF */
                }


                /*" -1757- MOVE V1APOL-NUM-APOL TO V0APOL-NUM-APO-ANT */
                _.Move(V1APOL_NUM_APOL, V0APOL_NUM_APO_ANT);

                /*" -1758- ELSE */
            }
            else
            {


                /*" -1761- GO TO R1000-00-LEITURA. */

                R1000_00_LEITURA(); //GOTO
                return;
            }


            /*" -1762- MOVE '1' TO V0APOL-TIPSGU */
            _.Move("1", V0APOL_TIPSGU);

            /*" -1763- MOVE '2' TO V0APOL-TIPAPO */
            _.Move("2", V0APOL_TIPAPO);

            /*" -1764- MOVE '3' TO V0APOL-TIPCALC */
            _.Move("3", V0APOL_TIPCALC);

            /*" -1765- MOVE 'N' TO V0APOL-PODPUBL */
            _.Move("N", V0APOL_PODPUBL);

            /*" -1766- MOVE ZEROS TO V0APOL-NUM-ATA */
            _.Move(0, V0APOL_NUM_ATA);

            /*" -1767- MOVE ZEROS TO V0APOL-ANO-ATA */
            _.Move(0, V0APOL_ANO_ATA);

            /*" -1768- MOVE SPACES TO V0APOL-IDEMAN */
            _.Move("", V0APOL_IDEMAN);

            /*" -1770- MOVE ZEROS TO V0APOL-PCDESCON */
            _.Move(0, V0APOL_PCDESCON);

            /*" -1771- MOVE ZEROS TO V0APOL-PCTCED */
            _.Move(0, V0APOL_PCTCED);

            /*" -1772- MOVE '4' TO V0APOL-TPCOSCED */
            _.Move("4", V0APOL_TPCOSCED);

            /*" -1773- MOVE ZEROS TO V0APOL-QTCOSSEG */
            _.Move(0, V0APOL_QTCOSSEG);

            /*" -1775- MOVE ZEROS TO V0APOL-COD-EMPRESA */
            _.Move(0, V0APOL_COD_EMPRESA);

            /*" -1777- MOVE '2' TO V0APOL-TPCORRET. */
            _.Move("2", V0APOL_TPCORRET);

            /*" -1779- MOVE '1070' TO WNR-EXEC-SQL. */
            _.Move("1070", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -1799- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_6 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_6();

            /*" -1802- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1803- DISPLAY 'R1070-00 (ERRO - SELECT V0BILHETE_COBER)...' */
                _.Display($"R1070-00 (ERRO - SELECT V0BILHETE_COBER)...");

                /*" -1810- DISPLAY 'EMPR: ' V1BILC-COD-EMPR '  ' 'PROD: ' V1BILC-CODPRODU '  ' 'RAMO: ' V1BILC-RAMOFR '  ' 'MODA: ' V1BILC-MODALIFR '  ' 'OPCA: ' V1BILC-OPCAO '  ' 'DAT1: ' V0ENDO-DTINIVIG '  ' 'DAT2: ' V0ENDO-DTTERVIG */

                $"EMPR: {V1BILC_COD_EMPR}  PROD: {V1BILC_CODPRODU}  RAMO: {V1BILC_RAMOFR}  MODA: {V1BILC_MODALIFR}  OPCA: {V1BILC_OPCAO}  DAT1: {V0ENDO_DTINIVIG}  DAT2: {V0ENDO_DTTERVIG}"
                .Display();

                /*" -1813- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1815- MOVE V1BILC-PCIOCC TO V0APOL-PCIOCC */
            _.Move(V1BILC_PCIOCC, V0APOL_PCIOCC);

            /*" -1817- MOVE ' ' TO WTEM-PROPESTIP. */
            _.Move(" ", AREA_DE_WORK.WTEM_PROPESTIP);

            /*" -1826- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_7 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_7();

            /*" -1829- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1830- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1831- MOVE 'N' TO WTEM-PROPESTIP */
                    _.Move("N", AREA_DE_WORK.WTEM_PROPESTIP);

                    /*" -1832- ELSE */
                }
                else
                {


                    /*" -1833- DISPLAY 'R1070-00 (ERRO - SELECT V0PROP_ESTIPULANTE).' */
                    _.Display($"R1070-00 (ERRO - SELECT V0PROP_ESTIPULANTE).");

                    /*" -1836- DISPLAY 'EMPR: ' V1BILC-COD-EMPR '  ' 'PROD: ' V1BILC-CODPRODU '  ' 'BILH: ' V0BILH-NUMBIL */

                    $"EMPR: {V1BILC_COD_EMPR}  PROD: {V1BILC_CODPRODU}  BILH: {V0BILH_NUMBIL}"
                    .Display();

                    /*" -1837- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1838- ELSE */
                }

            }
            else
            {


                /*" -1850- MOVE 'S' TO WTEM-PROPESTIP. */
                _.Move("S", AREA_DE_WORK.WTEM_PROPESTIP);
            }


            /*" -1851- IF WTEM-PROPESTIP EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_PROPESTIP == "S")
            {

                /*" -1852- MOVE V0PROE-CODPRODU TO V0APOL-CODPRODU */
                _.Move(V0PROE_CODPRODU, V0APOL_CODPRODU);

                /*" -1853- ELSE */
            }
            else
            {


                /*" -1856- MOVE V1BILP-CODPRODU TO V0APOL-CODPRODU. */
                _.Move(V1BILP_CODPRODU, V0APOL_CODPRODU);
            }


            /*" -1858- IF V0APOL-CODPRODU NOT EQUAL 1402 AND V0APOL-CODPRODU NOT EQUAL 1405 */

            if (V0APOL_CODPRODU != 1402 && V0APOL_CODPRODU != 1405)
            {

                /*" -1861- MOVE 1402 TO V0APOL-CODPRODU. */
                _.Move(1402, V0APOL_CODPRODU);
            }


            /*" -1863- MOVE '1065' TO WNR-EXEC-SQL. */
            _.Move("1065", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -1915- PERFORM R1000_00_PROCESSA_REGISTRO_DB_INSERT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_1();

            /*" -1918- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1919- DISPLAY 'R1065-00 (PROBLEMAS NA INSERCAO) ... ' */
                _.Display($"R1065-00 (PROBLEMAS NA INSERCAO) ... ");

                /*" -1921- DISPLAY 'APOLICE: ' V0APOL-NUM-APOL '  ' 'OPCAO: ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APOL_NUM_APOL}  OPCAO: {WWORK_OPCAO_ANT}"
                .Display();

                /*" -1923- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1924- ADD +1 TO AC-I-V0APOLICE. */
            AREA_DE_WORK.AC_I_V0APOLICE.Value = AREA_DE_WORK.AC_I_V0APOLICE + +1;

            /*" -1925- MOVE V0APOL-NUM-APOL TO V0ENDO-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0ENDO_NUM_APOL);

            /*" -1926- MOVE ZEROS TO V0ENDO-NRENDOS */
            _.Move(0, V0ENDO_NRENDOS);

            /*" -1927- MOVE ZEROS TO V0ENDO-CODSUBES */
            _.Move(0, V0ENDO_CODSUBES);

            /*" -1928- MOVE V0BILH-FONTE TO V0ENDO-FONTE */
            _.Move(V0BILH_FONTE, V0ENDO_FONTE);

            /*" -1929- MOVE V1FONT-PROPAUTOM TO V0ENDO-NRPROPOS */
            _.Move(V1FONT_PROPAUTOM, V0ENDO_NRPROPOS);

            /*" -1930- MOVE V1SIST-DTMOVACB TO V0ENDO-DATPRO */
            _.Move(V1SIST_DTMOVACB, V0ENDO_DATPRO);

            /*" -1931- MOVE V1SIST-DTMOVACB TO V0ENDO-DT-LIBER */
            _.Move(V1SIST_DTMOVACB, V0ENDO_DT_LIBER);

            /*" -1933- MOVE V1SIST-DTMOVACB TO V0ENDO-DTEMIS */
            _.Move(V1SIST_DTMOVACB, V0ENDO_DTEMIS);

            /*" -1935- MOVE 104 TO V0ENDO-BCORCAP V0ENDO-BCOCOBR. */
            _.Move(104, V0ENDO_BCORCAP, V0ENDO_BCOCOBR);

            /*" -1936- MOVE V0BILH-AGECOBR TO V0ENDO-AGERCAP. */
            _.Move(V0BILH_AGECOBR, V0ENDO_AGERCAP);

            /*" -1937- MOVE V1RCAC-AGEAVISO TO V0ENDO-AGECOBR. */
            _.Move(V1RCAC_AGEAVISO, V0ENDO_AGECOBR);

            /*" -1939- MOVE '0' TO V0ENDO-DACCOBR */
            _.Move("0", V0ENDO_DACCOBR);

            /*" -1940- MOVE WWORK-NRRCAP TO V0ENDO-NRRCAP */
            _.Move(AREA_DE_WORK.FILLER_3.WWORK_NRRCAP, V0ENDO_NRRCAP);

            /*" -1941- MOVE V0BILH-VLRCAP TO V0ENDO-VLRCAP. */
            _.Move(V0BILH_VLRCAP, V0ENDO_VLRCAP);

            /*" -1942- MOVE '0' TO V0ENDO-DACRCAP */
            _.Move("0", V0ENDO_DACRCAP);

            /*" -1943- MOVE '0' TO V0ENDO-IDRCAP */
            _.Move("0", V0ENDO_IDRCAP);

            /*" -1944- MOVE V0BILH-DTQITBCO TO V0ENDO-DATARCAP */
            _.Move(V0BILH_DTQITBCO, V0ENDO_DATARCAP);

            /*" -1946- MOVE +0 TO VIND-DATARCAP. */
            _.Move(+0, VIND_DATARCAP);

            /*" -1947- IF V0BILH-NUM-APO-ANT GREATER 0 */

            if (V0BILH_NUM_APO_ANT > 0)
            {

                /*" -1948- PERFORM R3275-00-SELECT-ENDOSSO-ANT */

                R3275_00_SELECT_ENDOSSO_ANT_SECTION();

                /*" -1949- MOVE V0ENDO-INIVIG-ANT TO WWORK-DATA */
                _.Move(V0ENDO_INIVIG_ANT, AREA_DE_WORK.WWORK_DATA);

                /*" -1950- COMPUTE WWORK-ANO = WWORK-ANO + 1 */
                AREA_DE_WORK.WWORK_DATA.WWORK_ANO.Value = AREA_DE_WORK.WWORK_DATA.WWORK_ANO + 1;

                /*" -1951- IF WWORK-MES EQUAL 02 */

                if (AREA_DE_WORK.WWORK_DATA.WWORK_MES == 02)
                {

                    /*" -1952- IF WWORK-DIA EQUAL 29 */

                    if (AREA_DE_WORK.WWORK_DATA.WWORK_DIA == 29)
                    {

                        /*" -1953- COMPUTE WWORK-ANO-BI = WWORK-ANO / 4 */
                        AREA_DE_WORK.WWORK_ANO_BI.Value = AREA_DE_WORK.WWORK_DATA.WWORK_ANO / 4;

                        /*" -1954- COMPUTE WWORK-ANO-BI = WWORK-ANO-BI * 4 */
                        AREA_DE_WORK.WWORK_ANO_BI.Value = AREA_DE_WORK.WWORK_ANO_BI * 4;

                        /*" -1955- IF WWORK-ANO NOT EQUAL WWORK-ANO-BI */

                        if (AREA_DE_WORK.WWORK_DATA.WWORK_ANO != AREA_DE_WORK.WWORK_ANO_BI)
                        {

                            /*" -1956- MOVE 03 TO WWORK-MES */
                            _.Move(03, AREA_DE_WORK.WWORK_DATA.WWORK_MES);

                            /*" -1957- MOVE 01 TO WWORK-DIA */
                            _.Move(01, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);

                            /*" -1958- END-IF */
                        }


                        /*" -1959- END-IF */
                    }


                    /*" -1960- END-IF */
                }


                /*" -1961- MOVE WWORK-DATA TO V0ENDO-DTINIVIG */
                _.Move(AREA_DE_WORK.WWORK_DATA, V0ENDO_DTINIVIG);

                /*" -1962- MOVE V0ENDO-TERVIG-ANT TO WWORK-DATA */
                _.Move(V0ENDO_TERVIG_ANT, AREA_DE_WORK.WWORK_DATA);

                /*" -1963- COMPUTE WWORK-ANO = WWORK-ANO + 1 */
                AREA_DE_WORK.WWORK_DATA.WWORK_ANO.Value = AREA_DE_WORK.WWORK_DATA.WWORK_ANO + 1;

                /*" -1964- IF WWORK-MES EQUAL 02 */

                if (AREA_DE_WORK.WWORK_DATA.WWORK_MES == 02)
                {

                    /*" -1965- IF WWORK-DIA EQUAL 29 */

                    if (AREA_DE_WORK.WWORK_DATA.WWORK_DIA == 29)
                    {

                        /*" -1966- COMPUTE WWORK-ANO-BI = WWORK-ANO / 4 */
                        AREA_DE_WORK.WWORK_ANO_BI.Value = AREA_DE_WORK.WWORK_DATA.WWORK_ANO / 4;

                        /*" -1967- COMPUTE WWORK-ANO-BI = WWORK-ANO-BI * 4 */
                        AREA_DE_WORK.WWORK_ANO_BI.Value = AREA_DE_WORK.WWORK_ANO_BI * 4;

                        /*" -1968- IF WWORK-ANO NOT EQUAL WWORK-ANO-BI */

                        if (AREA_DE_WORK.WWORK_DATA.WWORK_ANO != AREA_DE_WORK.WWORK_ANO_BI)
                        {

                            /*" -1969- MOVE 03 TO WWORK-MES */
                            _.Move(03, AREA_DE_WORK.WWORK_DATA.WWORK_MES);

                            /*" -1970- MOVE 01 TO WWORK-DIA */
                            _.Move(01, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);

                            /*" -1971- END-IF */
                        }


                        /*" -1972- END-IF */
                    }


                    /*" -1973- END-IF */
                }


                /*" -1974- MOVE WWORK-DATA TO V0ENDO-DTTERVIG */
                _.Move(AREA_DE_WORK.WWORK_DATA, V0ENDO_DTTERVIG);

                /*" -1975- ELSE */
            }
            else
            {


                /*" -1976- GO TO R1000-00-LEITURA */

                R1000_00_LEITURA(); //GOTO
                return;

                /*" -1978- END-IF. */
            }


            /*" -1982- IF V0BILH-NUMBIL EQUAL 82714427157 OR 82714427165 OR 82714427173 OR 82714427149 */

            if (V0BILH_NUMBIL.In("82714427157", "82714427165", "82714427173", "82714427149"))
            {

                /*" -1983- MOVE '2004-04-13' TO V0ENDO-DTINIVIG */
                _.Move("2004-04-13", V0ENDO_DTINIVIG);

                /*" -1984- MOVE '2005-04-13' TO V0ENDO-DTTERVIG */
                _.Move("2005-04-13", V0ENDO_DTTERVIG);

                /*" -1987- END-IF. */
            }


            /*" -1988- MOVE ZEROS TO V0ENDO-PCENTRAD. */
            _.Move(0, V0ENDO_PCENTRAD);

            /*" -1989- MOVE ZEROS TO V0ENDO-PCADICIO. */
            _.Move(0, V0ENDO_PCADICIO);

            /*" -1990- MOVE ZEROS TO V0ENDO-PRESTA1. */
            _.Move(0, V0ENDO_PRESTA1);

            /*" -1991- MOVE ZEROS TO V0ENDO-QTPARCEL. */
            _.Move(0, V0ENDO_QTPARCEL);

            /*" -1992- MOVE ZEROS TO V0ENDO-CDFRACIO. */
            _.Move(0, V0ENDO_CDFRACIO);

            /*" -1993- MOVE ZEROS TO V0ENDO-QTPRESTA. */
            _.Move(0, V0ENDO_QTPRESTA);

            /*" -1994- MOVE 1 TO V0ENDO-QTITENS. */
            _.Move(1, V0ENDO_QTITENS);

            /*" -1995- MOVE SPACES TO V0ENDO-CODTXT. */
            _.Move("", V0ENDO_CODTXT);

            /*" -1996- MOVE ZEROS TO V0ENDO-CDACEITA. */
            _.Move(0, V0ENDO_CDACEITA);

            /*" -1998- MOVE V1BILC-CODUNIMO TO V0ENDO-MOEDA-IMP V0ENDO-MOEDA-PRM. */
            _.Move(V1BILC_CODUNIMO, V0ENDO_MOEDA_IMP, V0ENDO_MOEDA_PRM);

            /*" -1999- MOVE '0' TO V0ENDO-TIPO-ENDO. */
            _.Move("0", V0ENDO_TIPO_ENDO);

            /*" -2000- MOVE 'BI6005B' TO V0ENDO-COD-USUAR. */
            _.Move("BI6005B", V0ENDO_COD_USUAR);

            /*" -2001- MOVE 1 TO V0ENDO-OCORR-END. */
            _.Move(1, V0ENDO_OCORR_END);

            /*" -2002- MOVE '1' TO V0ENDO-SITUACAO. */
            _.Move("1", V0ENDO_SITUACAO);

            /*" -2003- MOVE ZEROS TO V0ENDO-COD-EMPRESA. */
            _.Move(0, V0ENDO_COD_EMPRESA);

            /*" -2004- MOVE '1' TO V0ENDO-CORRECAO. */
            _.Move("1", V0ENDO_CORRECAO);

            /*" -2005- MOVE 'S' TO V0ENDO-ISENTA-CST. */
            _.Move("S", V0ENDO_ISENTA_CST);

            /*" -2006- MOVE -1 TO VIND-DTVENCTO. */
            _.Move(-1, VIND_DTVENCTO);

            /*" -2007- MOVE -1 TO VIND-VLCUSEMI. */
            _.Move(-1, VIND_VLCUSEMI);

            /*" -2008- MOVE -1 TO VIND-CFPREFIX. */
            _.Move(-1, VIND_CFPREFIX);

            /*" -2009- MOVE V0APOL-RAMO TO V0ENDO-RAMO. */
            _.Move(V0APOL_RAMO, V0ENDO_RAMO);

            /*" -2010- MOVE V0APOL-CODPRODU TO V0ENDO-CODPRODU. */
            _.Move(V0APOL_CODPRODU, V0ENDO_CODPRODU);

            /*" -2012- MOVE '1075' TO WNR-EXEC-SQL. */
            _.Move("1075", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2102- PERFORM R1000_00_PROCESSA_REGISTRO_DB_INSERT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_INSERT_2();

            /*" -2105- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2106- DISPLAY 'R1075-00 (ERRO - INSERT V0ENDOSSO)...' */
                _.Display($"R1075-00 (ERRO - INSERT V0ENDOSSO)...");

                /*" -2107- DISPLAY 'V0ENDO-NUM-APOL   = ' V0ENDO-NUM-APOL */
                _.Display($"V0ENDO-NUM-APOL   = {V0ENDO_NUM_APOL}");

                /*" -2108- DISPLAY 'NUM BILHETE       = ' WS-NUMBIL */
                _.Display($"NUM BILHETE       = {WS_NUMBIL}");

                /*" -2109- DISPLAY 'APOLICE ANTERIOR  = ' WS-APOLICE-ANT */
                _.Display($"APOLICE ANTERIOR  = {WS_APOLICE_ANT}");

                /*" -2110- DISPLAY 'V0ENDO-NRENDOS    = ' V0ENDO-NRENDOS */
                _.Display($"V0ENDO-NRENDOS    = {V0ENDO_NRENDOS}");

                /*" -2111- DISPLAY 'V0ENDO-FONTE      = ' V0ENDO-FONTE */
                _.Display($"V0ENDO-FONTE      = {V0ENDO_FONTE}");

                /*" -2112- DISPLAY 'V0ENDO-NRPROPOS   = ' V0ENDO-NRPROPOS */
                _.Display($"V0ENDO-NRPROPOS   = {V0ENDO_NRPROPOS}");

                /*" -2113- DISPLAY 'DATA INI VIGENCIA = ' V0ENDO-DTINIVIG */
                _.Display($"DATA INI VIGENCIA = {V0ENDO_DTINIVIG}");

                /*" -2114- DISPLAY 'DATA FIM VIGENCIA = ' V0ENDO-DTTERVIG */
                _.Display($"DATA FIM VIGENCIA = {V0ENDO_DTTERVIG}");

                /*" -2115- DISPLAY 'DATA DATARCAP     = ' V0ENDO-DATARCAP */
                _.Display($"DATA DATARCAP     = {V0ENDO_DATARCAP}");

                /*" -2116- DISPLAY 'DATA VENCIMENTO   = ' V0ENDO-DTVENCTO */
                _.Display($"DATA VENCIMENTO   = {V0ENDO_DTVENCTO}");

                /*" -2117- DISPLAY 'RAMO   : ' WWORK-RAMO-ANT */
                _.Display($"RAMO   : {WWORK_RAMO_ANT}");

                /*" -2118- DISPLAY 'OPCAO  : ' WWORK-OPCAO-ANT */
                _.Display($"OPCAO  : {WWORK_OPCAO_ANT}");

                /*" -2119- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2121- END-IF. */
            }


            /*" -2131- ADD +1 TO AC-I-V0ENDOSSO. */
            AREA_DE_WORK.AC_I_V0ENDOSSO.Value = AREA_DE_WORK.AC_I_V0ENDOSSO + +1;

            /*" -2132- IF V0BILH-DTQITBCO GREATER '1999-06-29' */

            if (V0BILH_DTQITBCO > "1999-06-29")
            {

                /*" -2133- PERFORM R1050-00-TRATA-FUNDAO */

                R1050_00_TRATA_FUNDAO_SECTION();

                /*" -2134- GO TO R1000-15-FIM */

                R1000_15_FIM(); //GOTO
                return;

                /*" -2139- END-IF. */
            }


            /*" -2141- MOVE '1076' TO WNR-EXEC-SQL. */
            _.Move("1076", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2147- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_8 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_8();

            /*" -2150- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2151- DISPLAY 'R1076-00 (ERRO SELECT V0COMISSAO-FENAE)' */
                _.Display($"R1076-00 (ERRO SELECT V0COMISSAO-FENAE)");

                /*" -2152- DISPLAY 'NUMBIL     : ' V0BILH-NUMBIL */
                _.Display($"NUMBIL     : {V0BILH_NUMBIL}");

                /*" -2153- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2155- END-IF. */
            }


            /*" -2157- MOVE SPACES TO WWORK-FUNDAO. */
            _.Move("", AREA_DE_WORK.WWORK_FUNDAO);

            /*" -2158- IF V0COFE-VALADT EQUAL ZEROS */

            if (V0COFE_VALADT == 00)
            {

                /*" -2159- MOVE 'S' TO WWORK-FUNDAO */
                _.Move("S", AREA_DE_WORK.WWORK_FUNDAO);

                /*" -2160- GO TO R1000-15-NOVA */

                R1000_15_NOVA(); //GOTO
                return;

                /*" -2162- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_10_ANTIGA */

            R1000_10_ANTIGA();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -1554- EXEC SQL SELECT SEQ_APOLICE INTO :V1NAES-SEQ-APOL FROM SEGUROS.V1NUMERO_AES WHERE COD_ORGAO = 10 AND COD_RAMO = 14 WITH UR END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1NAES_SEQ_APOL, V1NAES_SEQ_APOL);
            }


        }

        [StopWatch]
        /*" R1000-10-ANTIGA */
        private void R1000_10_ANTIGA(bool isPerform = false)
        {
            /*" -2165- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL. */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -2166- MOVE 17256 TO V0APCR-CODCORR. */
            _.Move(17256, V0APCR_CODCORR);

            /*" -2167- MOVE ZEROS TO V0APCR-CODSUBES. */
            _.Move(0, V0APCR_CODSUBES);

            /*" -2168- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG. */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -2169- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG. */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -2170- MOVE 14 TO V0APCR-RAMOFR. */
            _.Move(14, V0APCR_RAMOFR);

            /*" -2171- MOVE 0 TO V0APCR-MODALIFR. */
            _.Move(0, V0APCR_MODALIFR);

            /*" -2172- MOVE 100,00 TO V0APCR-PCPARCOR. */
            _.Move(100.00, V0APCR_PCPARCOR);

            /*" -2173- MOVE V1BILC-PCCOMCOR TO V0APCR-PCCOMCOR. */
            _.Move(V1BILC_PCCOMCOR, V0APCR_PCCOMCOR);

            /*" -2174- MOVE '1' TO V0APCR-TIPCOM. */
            _.Move("1", V0APCR_TIPCOM);

            /*" -2175- MOVE '1' TO V0APCR-INDCRT. */
            _.Move("1", V0APCR_INDCRT);

            /*" -2176- MOVE ZEROS TO V0APCR-COD-EMPRESA. */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -2177- MOVE 'BI6005B' TO V0APCR-COD-USUARIO. */
            _.Move("BI6005B", V0APCR_COD_USUARIO);

            /*" -2179- MOVE '1077' TO WNR-EXEC-SQL. */
            _.Move("1077", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2195- PERFORM R1000_10_ANTIGA_DB_INSERT_1 */

            R1000_10_ANTIGA_DB_INSERT_1();

            /*" -2198- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2199- DISPLAY 'R1077-00 (ERRO - INSERT V0APOLCORRET)...' */
                _.Display($"R1077-00 (ERRO - INSERT V0APOLCORRET)...");

                /*" -2202- DISPLAY 'APOLICE: ' V0APCR-NUM-APOL '  ' 'RAMO: ' V0APCR-RAMOFR '  ' 'OPCAO: ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APCR_NUM_APOL}  RAMO: {V0APCR_RAMOFR}  OPCAO: {WWORK_OPCAO_ANT}"
                .Display();

                /*" -2203- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2205- END-IF. */
            }


            /*" -2207- ADD +1 TO AC-I-V0APOLCORRET. */
            AREA_DE_WORK.AC_I_V0APOLCORRET.Value = AREA_DE_WORK.AC_I_V0APOLCORRET + +1;

            /*" -2209- GO TO R1000-15-FIM. */

            R1000_15_FIM(); //GOTO
            return;

        }

        [StopWatch]
        /*" R1000-10-ANTIGA-DB-INSERT-1 */
        public void R1000_10_ANTIGA_DB_INSERT_1()
        {
            /*" -2195- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (:V0APCR-NUM-APOL , :V0APCR-RAMOFR , :V0APCR-MODALIFR , :V0APCR-CODCORR , :V0APCR-CODSUBES , :V0APCR-DTINIVIG , :V0APCR-DTTERVIG , :V0APCR-PCPARCOR , :V0APCR-PCCOMCOR , :V0APCR-TIPCOM , :V0APCR-INDCRT , :V0APCR-COD-EMPRESA , CURRENT TIMESTAMP , :V0APCR-COD-USUARIO) END-EXEC. */

            var r1000_10_ANTIGA_DB_INSERT_1_Insert1 = new R1000_10_ANTIGA_DB_INSERT_1_Insert1()
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

            R1000_10_ANTIGA_DB_INSERT_1_Insert1.Execute(r1000_10_ANTIGA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_2()
        {
            /*" -1578- EXEC SQL SELECT CODPRODU INTO :V1BILP-CODPRODU FROM SEGUROS.V0BILHETE_PLCOBER WHERE COD_EMPRESA = 0 AND RAMOFR = :V0BILH-RAMO AND MODALIFR = 0 AND COD_OPCAO = :V0BILH-OPCAO-COBER AND SITUACAO = '0' WITH UR END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1()
            {
                V0BILH_OPCAO_COBER = V0BILH_OPCAO_COBER.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILP_CODPRODU, V1BILP_CODPRODU);
            }


        }

        [StopWatch]
        /*" R1000-15-NOVA */
        private void R1000_15_NOVA(bool isPerform = false)
        {
            /*" -2213- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -2215- MOVE 18040 TO V0APCR-CODCORR. */
            _.Move(18040, V0APCR_CODCORR);

            /*" -2216- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -2217- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -2219- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -2220- MOVE 14 TO V0APCR-RAMOFR */
            _.Move(14, V0APCR_RAMOFR);

            /*" -2222- MOVE 0 TO V0APCR-MODALIFR. */
            _.Move(0, V0APCR_MODALIFR);

            /*" -2224- COMPUTE WWORK-PCPARCOR = V0BILFX-VALADT / ( 3 + V0BILFX-VALADT ). */
            AREA_DE_WORK.WWORK_PCPARCOR.Value = V0BILFX_VALADT / (3 + V0BILFX_VALADT);

            /*" -2226- COMPUTE WWORK-PCPARCOR-I = WWORK-PCPARCOR * 100. */
            AREA_DE_WORK.WWORK_PCPARCOR_I.Value = AREA_DE_WORK.WWORK_PCPARCOR * 100;

            /*" -2228- MOVE WWORK-PCPARCOR-I TO V0APCR-PCPARCOR. */
            _.Move(AREA_DE_WORK.WWORK_PCPARCOR_I, V0APCR_PCPARCOR);

            /*" -2230- COMPUTE WWORK-PCCOMCOR = ( 3 + V0BILFX-VALADT) / V1BILC-PRMTAR-IX */
            AREA_DE_WORK.WWORK_PCCOMCOR.Value = (3 + V0BILFX_VALADT) / V1BILC_PRMTAR_IX;

            /*" -2232- COMPUTE WWORK-PCCOMCOR-I = WWORK-PCCOMCOR * 100 */
            AREA_DE_WORK.WWORK_PCCOMCOR_I.Value = AREA_DE_WORK.WWORK_PCCOMCOR * 100;

            /*" -2234- MOVE WWORK-PCCOMCOR-I TO V0APCR-PCCOMCOR. */
            _.Move(AREA_DE_WORK.WWORK_PCCOMCOR_I, V0APCR_PCCOMCOR);

            /*" -2235- MOVE '1' TO V0APCR-TIPCOM */
            _.Move("1", V0APCR_TIPCOM);

            /*" -2236- MOVE '2' TO V0APCR-INDCRT */
            _.Move("2", V0APCR_INDCRT);

            /*" -2238- MOVE ZEROS TO V0APCR-COD-EMPRESA. */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -2240- MOVE 'BI6005B' TO V0APCR-COD-USUARIO. */
            _.Move("BI6005B", V0APCR_COD_USUARIO);

            /*" -2242- MOVE '107A' TO WNR-EXEC-SQL. */
            _.Move("107A", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2258- PERFORM R1000_15_NOVA_DB_INSERT_1 */

            R1000_15_NOVA_DB_INSERT_1();

            /*" -2261- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2262- DISPLAY 'R1077-00 (ERRO - INSERT V0APOLCORRET)...' */
                _.Display($"R1077-00 (ERRO - INSERT V0APOLCORRET)...");

                /*" -2265- DISPLAY 'APOLICE: ' V0APCR-NUM-APOL '  ' 'RAMO: ' V0APCR-RAMOFR '  ' 'OPCAO: ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APCR_NUM_APOL}  RAMO: {V0APCR_RAMOFR}  OPCAO: {WWORK_OPCAO_ANT}"
                .Display();

                /*" -2267- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2269- ADD +1 TO AC-I-V0APOLCORRET. */
            AREA_DE_WORK.AC_I_V0APOLCORRET.Value = AREA_DE_WORK.AC_I_V0APOLCORRET + +1;

            /*" -2271- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -2273- MOVE 17256 TO V0APCR-CODCORR. */
            _.Move(17256, V0APCR_CODCORR);

            /*" -2274- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -2275- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -2277- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -2278- MOVE 14 TO V0APCR-RAMOFR */
            _.Move(14, V0APCR_RAMOFR);

            /*" -2294- MOVE 0 TO V0APCR-MODALIFR. */
            _.Move(0, V0APCR_MODALIFR);

            /*" -2295- COMPUTE V0APCR-PCPARCOR = 100 - WWORK-PCPARCOR-I. */
            V0APCR_PCPARCOR.Value = 100 - AREA_DE_WORK.WWORK_PCPARCOR_I;

            /*" -2297- COMPUTE WWORK-PCCOMCOR = ( 3,96 + V0BILFX-VALADT ) / V1BILC-PRMTAR-IX */
            AREA_DE_WORK.WWORK_PCCOMCOR.Value = (3.96 + V0BILFX_VALADT) / V1BILC_PRMTAR_IX;

            /*" -2299- COMPUTE WWORK-PCCOMCOR-F = WWORK-PCCOMCOR * 100 */
            AREA_DE_WORK.WWORK_PCCOMCOR_F.Value = AREA_DE_WORK.WWORK_PCCOMCOR * 100;

            /*" -2301- MOVE WWORK-PCCOMCOR-F TO V0APCR-PCCOMCOR. */
            _.Move(AREA_DE_WORK.WWORK_PCCOMCOR_F, V0APCR_PCCOMCOR);

            /*" -2302- MOVE '1' TO V0APCR-TIPCOM */
            _.Move("1", V0APCR_TIPCOM);

            /*" -2303- MOVE '1' TO V0APCR-INDCRT */
            _.Move("1", V0APCR_INDCRT);

            /*" -2305- MOVE ZEROS TO V0APCR-COD-EMPRESA. */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -2307- MOVE 'BI6005B' TO V0APCR-COD-USUARIO. */
            _.Move("BI6005B", V0APCR_COD_USUARIO);

            /*" -2309- MOVE '107B' TO WNR-EXEC-SQL. */
            _.Move("107B", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2325- PERFORM R1000_15_NOVA_DB_INSERT_2 */

            R1000_15_NOVA_DB_INSERT_2();

            /*" -2328- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2329- DISPLAY 'R1077-00 (ERRO - INSERT V0APOLCORRET)...' */
                _.Display($"R1077-00 (ERRO - INSERT V0APOLCORRET)...");

                /*" -2332- DISPLAY 'APOLICE: ' V0APCR-NUM-APOL '  ' 'RAMO: ' V0APCR-RAMOFR '  ' 'OPCAO: ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APCR_NUM_APOL}  RAMO: {V0APCR_RAMOFR}  OPCAO: {WWORK_OPCAO_ANT}"
                .Display();

                /*" -2334- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2334- ADD +1 TO AC-I-V0APOLCORRET. */
            AREA_DE_WORK.AC_I_V0APOLCORRET.Value = AREA_DE_WORK.AC_I_V0APOLCORRET + +1;

        }

        [StopWatch]
        /*" R1000-15-NOVA-DB-INSERT-1 */
        public void R1000_15_NOVA_DB_INSERT_1()
        {
            /*" -2258- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (:V0APCR-NUM-APOL , :V0APCR-RAMOFR , :V0APCR-MODALIFR , :V0APCR-CODCORR , :V0APCR-CODSUBES , :V0APCR-DTINIVIG , :V0APCR-DTTERVIG , :V0APCR-PCPARCOR , :V0APCR-PCCOMCOR , :V0APCR-TIPCOM , :V0APCR-INDCRT , :V0APCR-COD-EMPRESA , CURRENT TIMESTAMP , :V0APCR-COD-USUARIO) END-EXEC. */

            var r1000_15_NOVA_DB_INSERT_1_Insert1 = new R1000_15_NOVA_DB_INSERT_1_Insert1()
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

            R1000_15_NOVA_DB_INSERT_1_Insert1.Execute(r1000_15_NOVA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_3()
        {
            /*" -1608- EXEC SQL SELECT NUM_SICOB, SIT_PROPOSTA INTO :V0CONV-NUM-SICOB, :V0SIVPF-SIT-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :V0BILH-NUMBIL AND COD_PRODUTO_SIVPF IN (09,10) WITH UR END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_NUM_SICOB, V0CONV_NUM_SICOB);
                _.Move(executed_1.V0SIVPF_SIT_PROPOSTA, V0SIVPF_SIT_PROPOSTA);
            }


        }

        [StopWatch]
        /*" R1000-15-NOVA-DB-INSERT-2 */
        public void R1000_15_NOVA_DB_INSERT_2()
        {
            /*" -2325- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (:V0APCR-NUM-APOL , :V0APCR-RAMOFR , :V0APCR-MODALIFR , :V0APCR-CODCORR , :V0APCR-CODSUBES , :V0APCR-DTINIVIG , :V0APCR-DTTERVIG , :V0APCR-PCPARCOR , :V0APCR-PCCOMCOR , :V0APCR-TIPCOM , :V0APCR-INDCRT , :V0APCR-COD-EMPRESA , CURRENT TIMESTAMP , :V0APCR-COD-USUARIO) END-EXEC. */

            var r1000_15_NOVA_DB_INSERT_2_Insert1 = new R1000_15_NOVA_DB_INSERT_2_Insert1()
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

            R1000_15_NOVA_DB_INSERT_2_Insert1.Execute(r1000_15_NOVA_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1()
        {
            /*" -1727- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET SEQ_APOLICE = :V0NAES-SEQ-APOL WHERE COD_ORGAO = 10 AND COD_RAMO = 14 END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1()
            {
                V0NAES_SEQ_APOL = V0NAES_SEQ_APOL.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-15-FIM */
        private void R1000_15_FIM(bool isPerform = false)
        {
            /*" -2344- IF V1BILC-VALMAX GREATER ZEROS */

            if (V1BILC_VALMAX > 00)
            {

                /*" -2346- PERFORM R4280-00-TRATA-FC0105S */

                R4280_00_TRATA_FC0105S_SECTION();

                /*" -2348- END-IF. */
            }


            /*" -2350- PERFORM R1080-00-GRAVA-V0APOLCOSCED. */

            R1080_00_GRAVA_V0APOLCOSCED_SECTION();

            /*" -2352- IF WACC-PCTCED GREATER ZEROS AND WACC-QTCOSSEG GREATER ZEROS */

            if (AREA_DE_WORK.WACC_PCTCED > 00 && AREA_DE_WORK.WACC_QTCOSSEG > 00)
            {

                /*" -2354- PERFORM R1090-00-UPDATE-V0APOLICE. */

                R1090_00_UPDATE_V0APOLICE_SECTION();
            }


            /*" -2355- MOVE V0APOL-NUM-APOL TO V0PARC-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0PARC_NUM_APOL);

            /*" -2356- MOVE 0 TO V0PARC-NRENDOS */
            _.Move(0, V0PARC_NRENDOS);

            /*" -2358- MOVE ZEROS TO V0PARC-NRPARCEL */
            _.Move(0, V0PARC_NRPARCEL);

            /*" -2359- MOVE '0' TO V0PARC-DACPARC */
            _.Move("0", V0PARC_DACPARC);

            /*" -2360- MOVE V0BILH-FONTE TO V0PARC-FONTE */
            _.Move(V0BILH_FONTE, V0PARC_FONTE);

            /*" -2361- MOVE V0BILH-NUMBIL TO V0PARC-NRTIT */
            _.Move(V0BILH_NUMBIL, V0PARC_NRTIT);

            /*" -2362- MOVE WWORK-PR-APOL TO V0PARC-PRM-TAR-IX */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0PARC_PRM_TAR_IX);

            /*" -2363- MOVE ZEROS TO V0PARC-VAL-DES-IX */
            _.Move(0, V0PARC_VAL_DES_IX);

            /*" -2364- MOVE WWORK-PR-APOL TO V0PARC-OTNPRLIQ */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0PARC_OTNPRLIQ);

            /*" -2365- MOVE ZEROS TO V0PARC-OTNADFRA */
            _.Move(0, V0PARC_OTNADFRA);

            /*" -2367- MOVE ZEROS TO V0PARC-OTNCUSTO */
            _.Move(0, V0PARC_OTNCUSTO);

            /*" -2371- COMPUTE V0PARC-OTNIOF ROUNDED = V0PARC-OTNPRLIQ * V1BILC-PCIOCC / 100. */
            V0PARC_OTNIOF.Value = V0PARC_OTNPRLIQ * V1BILC_PCIOCC / 100f;

            /*" -2376- COMPUTE V0PARC-OTNTOTAL = V0PARC-OTNPRLIQ + V0PARC-OTNADFRA + V0PARC-OTNCUSTO + V0PARC-OTNIOF. */
            V0PARC_OTNTOTAL.Value = V0PARC_OTNPRLIQ + V0PARC_OTNADFRA + V0PARC_OTNCUSTO + V0PARC_OTNIOF;

            /*" -2377- MOVE 2 TO V0PARC-OCORHIST */
            _.Move(2, V0PARC_OCORHIST);

            /*" -2378- MOVE ZEROS TO V0PARC-QTDDOC */
            _.Move(0, V0PARC_QTDDOC);

            /*" -2379- MOVE '1' TO V0PARC-SITUACAO */
            _.Move("1", V0PARC_SITUACAO);

            /*" -2381- MOVE ZEROS TO V0PARC-COD-EMPRESA. */
            _.Move(0, V0PARC_COD_EMPRESA);

            /*" -2383- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2407- PERFORM R1000_15_FIM_DB_INSERT_1 */

            R1000_15_FIM_DB_INSERT_1();

            /*" -2410- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2411- DISPLAY 'R2000-00 (ERRO - INSERT V0PARCELA)...' */
                _.Display($"R2000-00 (ERRO - INSERT V0PARCELA)...");

                /*" -2415- DISPLAY 'APOL: ' V0PARC-NUM-APOL '  ' 'ENDO: ' V0PARC-NRENDOS '  ' 'PARC: ' V0PARC-NRPARCEL '  ' 'BILH: ' V0BILH-NUMBIL */

                $"APOL: {V0PARC_NUM_APOL}  ENDO: {V0PARC_NRENDOS}  PARC: {V0PARC_NRPARCEL}  BILH: {V0BILH_NUMBIL}"
                .Display();

                /*" -2417- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2419- ADD +1 TO AC-I-V0PARCELA. */
            AREA_DE_WORK.AC_I_V0PARCELA.Value = AREA_DE_WORK.AC_I_V0PARCELA + +1;

            /*" -2421- PERFORM R2010-00-GRAVA-V0HISTOPARC. */

            R2010_00_GRAVA_V0HISTOPARC_SECTION();

            /*" -2423- PERFORM R2020-00-GRAVA-OPERACAO-BAIXA. */

            R2020_00_GRAVA_OPERACAO_BAIXA_SECTION();

            /*" -2424- MOVE V0APOL-NUM-APOL TO V0COBA-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0COBA_NUM_APOL);

            /*" -2425- MOVE 0 TO V0COBA-NRENDOS */
            _.Move(0, V0COBA_NRENDOS);

            /*" -2426- MOVE ZEROS TO V0COBA-NUM-ITEM */
            _.Move(0, V0COBA_NUM_ITEM);

            /*" -2427- MOVE ZEROS TO V0COBA-COD-COBER */
            _.Move(0, V0COBA_COD_COBER);

            /*" -2428- MOVE 1 TO V0COBA-FATOR-MULT */
            _.Move(1, V0COBA_FATOR_MULT);

            /*" -2429- MOVE ZEROS TO V0COBA-COD-EMPRESA */
            _.Move(0, V0COBA_COD_EMPRESA);

            /*" -2430- MOVE '0' TO V0COBA-SITUACAO */
            _.Move("0", V0COBA_SITUACAO);

            /*" -2432- MOVE +0 TO VIND-SITUACAO */
            _.Move(+0, VIND_SITUACAO);

            /*" -2433- MOVE V0ENDO-DTINIVIG TO V0COBA-DATA-INIVI */
            _.Move(V0ENDO_DTINIVIG, V0COBA_DATA_INIVI);

            /*" -2434- MOVE V0ENDO-DTTERVIG TO V0COBA-DATA-TERVI */
            _.Move(V0ENDO_DTTERVIG, V0COBA_DATA_TERVI);

            /*" -2436- MOVE 1 TO V0COBA-OCORHIST */
            _.Move(1, V0COBA_OCORHIST);

            /*" -2437- MOVE 14 TO V0COBA-RAMOFR */
            _.Move(14, V0COBA_RAMOFR);

            /*" -2439- MOVE V0APOL-MODALIDA TO V0COBA-MODALIFR */
            _.Move(V0APOL_MODALIDA, V0COBA_MODALIFR);

            /*" -2440- MOVE WWORK-IS-APOL TO V0COBA-IMP-SEG-IX */
            _.Move(AREA_DE_WORK.WWORK_IS_APOL, V0COBA_IMP_SEG_IX);

            /*" -2441- MOVE WWORK-PR-APOL TO V0COBA-PRM-TAR-IX */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0COBA_PRM_TAR_IX);

            /*" -2442- MOVE WWORK-IS-APOL TO V0COBA-IMP-SEG-VR */
            _.Move(AREA_DE_WORK.WWORK_IS_APOL, V0COBA_IMP_SEG_VR);

            /*" -2444- MOVE WWORK-PR-APOL TO V0COBA-PRM-TAR-VR */
            _.Move(AREA_DE_WORK.WWORK_PR_APOL, V0COBA_PRM_TAR_VR);

            /*" -2446- MOVE 100 TO V0COBA-PCT-COBERT. */
            _.Move(100, V0COBA_PCT_COBERT);

            /*" -2448- MOVE '2030' TO WNR-EXEC-SQL. */
            _.Move("2030", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2468- PERFORM R1000_15_FIM_DB_INSERT_2 */

            R1000_15_FIM_DB_INSERT_2();

            /*" -2471- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2472- DISPLAY 'R2030-00 (ERRO - INSERT V0COBERAPOL)...' */
                _.Display($"R2030-00 (ERRO - INSERT V0COBERAPOL)...");

                /*" -2475- DISPLAY 'APOL: ' V0COBA-NUM-APOL '  ' 'ENDO: ' V0COBA-NRENDOS '  ' 'RAMO: ' V0COBA-RAMOFR '  ' */

                $"APOL: {V0COBA_NUM_APOL}  ENDO: {V0COBA_NRENDOS}  RAMO: {V0COBA_RAMOFR}  "
                .Display();

                /*" -2477- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2484- ADD +1 TO AC-I-V0COBERAPOL. */
            AREA_DE_WORK.AC_I_V0COBERAPOL.Value = AREA_DE_WORK.AC_I_V0COBERAPOL + +1;

            /*" -2485- IF WWORK-FUNDAO EQUAL 'S' */

            if (AREA_DE_WORK.WWORK_FUNDAO == "S")
            {

                /*" -2490- GO TO R1000-00-LEITURA. */

                R1000_00_LEITURA(); //GOTO
                return;
            }


            /*" -2491- MOVE 17256 TO V0ADIA-CODPDT */
            _.Move(17256, V0ADIA_CODPDT);

            /*" -2493- MOVE 010 TO V0ADIA-FONTE */
            _.Move(010, V0ADIA_FONTE);

            /*" -2494- MOVE '2034' TO WNR-EXEC-SQL. */
            _.Move("2034", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2496- MOVE V0APOL-NUMBIL TO WHOST-NUMBIL. */
            _.Move(V0APOL_NUMBIL, WHOST_NUMBIL);

            /*" -2504- PERFORM R1000_15_FIM_DB_SELECT_1 */

            R1000_15_FIM_DB_SELECT_1();

            /*" -2507- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2508- GO TO R1000-00-LEITURA */

                R1000_00_LEITURA(); //GOTO
                return;

                /*" -2509- ELSE */
            }
            else
            {


                /*" -2510- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2511- DISPLAY 'R2034-00 (ERRO - SELECT V0ADIANTA)...' */
                    _.Display($"R2034-00 (ERRO - SELECT V0ADIANTA)...");

                    /*" -2513- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2515- MOVE '2035' TO WNR-EXEC-SQL. */
            _.Move("2035", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2519- PERFORM R1000_15_FIM_DB_SELECT_2 */

            R1000_15_FIM_DB_SELECT_2();

            /*" -2522- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2523- DISPLAY 'R2035-00 (ERRO - SELECT V0NUMERO_OUTROS)...' */
                _.Display($"R2035-00 (ERRO - SELECT V0NUMERO_OUTROS)...");

                /*" -2525- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2526- COMPUTE V1NOUT-NUMOPG = V1NOUT-NUMOPG + 1. */
            V1NOUT_NUMOPG.Value = V1NOUT_NUMOPG + 1;

            /*" -2528- MOVE V1NOUT-NUMOPG TO V0ADIA-NUMOPG */
            _.Move(V1NOUT_NUMOPG, V0ADIA_NUMOPG);

            /*" -2530- MOVE '2040' TO WNR-EXEC-SQL. */
            _.Move("2040", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2534- PERFORM R1000_15_FIM_DB_UPDATE_1 */

            R1000_15_FIM_DB_UPDATE_1();

            /*" -2537- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2538- DISPLAY 'R2040-00 (ERRO - UPDATE V0NUMERO_OUTROS)...' */
                _.Display($"R2040-00 (ERRO - UPDATE V0NUMERO_OUTROS)...");

                /*" -2539- DISPLAY 'NUMOPG: ' V1NOUT-NUMOPG */
                _.Display($"NUMOPG: {V1NOUT_NUMOPG}");

                /*" -2541- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2542- MOVE ZEROS TO V0ADIA-QTPRESTA */
            _.Move(0, V0ADIA_QTPRESTA);

            /*" -2543- MOVE ZEROS TO V0ADIA-NRPROPOS */
            _.Move(0, V0ADIA_NRPROPOS);

            /*" -2544- MOVE V0APOL-NUM-APOL TO V0ADIA-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0ADIA_NUM_APOL);

            /*" -2545- MOVE ZEROS TO V0ADIA-NRENDOS */
            _.Move(0, V0ADIA_NRENDOS);

            /*" -2546- MOVE ZEROS TO V0ADIA-NRPARCEL */
            _.Move(0, V0ADIA_NRPARCEL);

            /*" -2547- MOVE V1SIST-DTMOVABE TO V0ADIA-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0ADIA_DTMOVTO);

            /*" -2548- MOVE '0' TO V0ADIA-SITUACAO */
            _.Move("0", V0ADIA_SITUACAO);

            /*" -2549- MOVE ZEROS TO V0ADIA-COD-EMP */
            _.Move(0, V0ADIA_COD_EMP);

            /*" -2551- MOVE '2' TO V0ADIA-TIPO-ADT */
            _.Move("2", V0ADIA_TIPO_ADT);

            /*" -2553- MOVE '2045' TO WNR-EXEC-SQL. */
            _.Move("2045", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2569- PERFORM R1000_15_FIM_DB_INSERT_3 */

            R1000_15_FIM_DB_INSERT_3();

            /*" -2572- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2579- DISPLAY 'R2045-00 (ERRO - INSERT V0ADIANTA)...' 'CODPDT: ' V0ADIA-CODPDT '  ' 'NUMOPG: ' V0ADIA-NUMOPG '  ' 'APOL: ' V0ADIA-NUM-APOL '  ' 'ENDO: ' V0ADIA-NRENDOS '  ' 'PARC: ' V0ADIA-NRPARCEL '  ' 'FONTE: ' V0ADIA-FONTE */

                $"R2045-00 (ERRO - INSERT V0ADIANTA)...CODPDT: {V0ADIA_CODPDT}  NUMOPG: {V0ADIA_NUMOPG}  APOL: {V0ADIA_NUM_APOL}  ENDO: {V0ADIA_NRENDOS}  PARC: {V0ADIA_NRPARCEL}  FONTE: {V0ADIA_FONTE}"
                .Display();

                /*" -2581- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2586- ADD +1 TO AC-I-V0ADIANTA. */
            AREA_DE_WORK.AC_I_V0ADIANTA.Value = AREA_DE_WORK.AC_I_V0ADIANTA + +1;

            /*" -2587- MOVE 17256 TO V0FORM-CODPDT */
            _.Move(17256, V0FORM_CODPDT);

            /*" -2588- MOVE 010 TO V0FORM-FONTE */
            _.Move(010, V0FORM_FONTE);

            /*" -2589- MOVE V0ADIA-NUMOPG TO V0FORM-NUMOPG */
            _.Move(V0ADIA_NUMOPG, V0FORM_NUMOPG);

            /*" -2590- MOVE ZEROS TO V0FORM-NRPROPOS */
            _.Move(0, V0FORM_NRPROPOS);

            /*" -2591- MOVE V0APOL-NUM-APOL TO V0FORM-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0FORM_NUM_APOL);

            /*" -2592- MOVE ZEROS TO V0FORM-NRENDOS */
            _.Move(0, V0FORM_NRENDOS);

            /*" -2593- MOVE ZEROS TO V0FORM-NRPARCEL */
            _.Move(0, V0FORM_NRPARCEL);

            /*" -2594- MOVE ZEROS TO V0FORM-NUMPTC */
            _.Move(0, V0FORM_NUMPTC);

            /*" -2595- MOVE V0ADIA-VALADT TO V0FORM-VALRCP */
            _.Move(V0ADIA_VALADT, V0FORM_VALRCP);

            /*" -2596- MOVE ZEROS TO V0FORM-PCGACM */
            _.Move(0, V0FORM_PCGACM);

            /*" -2597- MOVE '0' TO V0FORM-SITUACAO */
            _.Move("0", V0FORM_SITUACAO);

            /*" -2598- MOVE V0ADIA-VALADT TO V0FORM-VALSDO */
            _.Move(V0ADIA_VALADT, V0FORM_VALSDO);

            /*" -2599- MOVE V1SIST-DTMOVABE TO V0FORM-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0FORM_DTMOVTO);

            /*" -2600- MOVE V1SIST-DTMOVABE TO V0FORM-DTVENCTO */
            _.Move(V1SIST_DTMOVABE, V0FORM_DTVENCTO);

            /*" -2602- MOVE ZEROS TO V0FORM-COD-EMP */
            _.Move(0, V0FORM_COD_EMP);

            /*" -2604- MOVE '2050' TO WNR-EXEC-SQL. */
            _.Move("2050", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2622- PERFORM R1000_15_FIM_DB_INSERT_4 */

            R1000_15_FIM_DB_INSERT_4();

            /*" -2625- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2632- DISPLAY 'PROBLEMAS NA INSERCAO (V0FORMAREC) ... ' ' ' V0FORM-CODPDT ' ' V0FORM-NUMOPG ' ' V0FORM-NUM-APOL ' ' V0FORM-NRENDOS ' ' V0FORM-NRPARCEL ' ' V0FORM-FONTE */

                $"PROBLEMAS NA INSERCAO (V0FORMAREC) ...  {V0FORM_CODPDT} {V0FORM_NUMOPG} {V0FORM_NUM_APOL} {V0FORM_NRENDOS} {V0FORM_NRPARCEL} {V0FORM_FONTE}"
                .Display();

                /*" -2637- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2638- MOVE 17256 TO V0HISR-CODPDT */
            _.Move(17256, V0HISR_CODPDT);

            /*" -2639- MOVE 010 TO V0HISR-FONTE */
            _.Move(010, V0HISR_FONTE);

            /*" -2640- MOVE V0ADIA-NUMOPG TO V0HISR-NUMOPG */
            _.Move(V0ADIA_NUMOPG, V0HISR_NUMOPG);

            /*" -2641- MOVE ZEROS TO V0HISR-NRPROPOS */
            _.Move(0, V0HISR_NRPROPOS);

            /*" -2642- MOVE V0APOL-NUM-APOL TO V0HISR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0HISR_NUM_APOL);

            /*" -2643- MOVE ZEROS TO V0HISR-NRENDOS */
            _.Move(0, V0HISR_NRENDOS);

            /*" -2644- MOVE ZEROS TO V0HISR-NRPARCEL */
            _.Move(0, V0HISR_NRPARCEL);

            /*" -2645- MOVE ZEROS TO V0HISR-NUMPTC */
            _.Move(0, V0HISR_NUMPTC);

            /*" -2646- MOVE V0ADIA-VALADT TO V0HISR-VALRCP */
            _.Move(V0ADIA_VALADT, V0HISR_VALRCP);

            /*" -2647- MOVE 999999 TO V0HISR-NUMREC */
            _.Move(999999, V0HISR_NUMREC);

            /*" -2648- MOVE V1SIST-DTMOVABE TO V0HISR-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0HISR_DTMOVTO);

            /*" -2649- MOVE 1401 TO V0HISR-OPERACAO */
            _.Move(1401, V0HISR_OPERACAO);

            /*" -2651- MOVE ZEROS TO V0HISR-COD-EMP */
            _.Move(0, V0HISR_COD_EMP);

            /*" -2653- MOVE '2055' TO WNR-EXEC-SQL. */
            _.Move("2055", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2670- PERFORM R1000_15_FIM_DB_INSERT_5 */

            R1000_15_FIM_DB_INSERT_5();

            /*" -2673- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2680- DISPLAY 'PROBLEMAS NA INSERCAO (V0HISTOREC) ... ' ' ' V0HISR-CODPDT ' ' V0HISR-NUMOPG ' ' V0HISR-NUM-APOL ' ' V0HISR-NRENDOS ' ' V0HISR-NRPARCEL ' ' V0HISR-FONTE */

                $"PROBLEMAS NA INSERCAO (V0HISTOREC) ...  {V0HISR_CODPDT} {V0HISR_NUMOPG} {V0HISR_NUM_APOL} {V0HISR_NRENDOS} {V0HISR_NRPARCEL} {V0HISR_FONTE}"
                .Display();

                /*" -2680- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1000-15-FIM-DB-INSERT-1 */
        public void R1000_15_FIM_DB_INSERT_1()
        {
            /*" -2407- EXEC SQL INSERT INTO SEGUROS.V0PARCELA VALUES (:V0PARC-NUM-APOL , :V0PARC-NRENDOS , :V0PARC-NRPARCEL , :V0PARC-DACPARC , :V0PARC-FONTE , :V0PARC-NRTIT , :V0PARC-PRM-TAR-IX , :V0PARC-VAL-DES-IX , :V0PARC-OTNPRLIQ , :V0PARC-OTNADFRA , :V0PARC-OTNCUSTO , :V0PARC-OTNIOF , :V0PARC-OTNTOTAL , :V0PARC-OCORHIST , :V0PARC-QTDDOC , :V0PARC-SITUACAO , :V0PARC-COD-EMPRESA , CURRENT TIMESTAMP, NULL) END-EXEC. */

            var r1000_15_FIM_DB_INSERT_1_Insert1 = new R1000_15_FIM_DB_INSERT_1_Insert1()
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

            R1000_15_FIM_DB_INSERT_1_Insert1.Execute(r1000_15_FIM_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-4 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_4()
        {
            /*" -1629- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :V0CONV-NUM-PROPOSTA-SIVPF FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB = :V0BILH-NUMBIL WITH UR END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_NUM_PROPOSTA_SIVPF, V0CONV_NUM_PROPOSTA_SIVPF);
            }


        }

        [StopWatch]
        /*" R1000-15-FIM-DB-SELECT-1 */
        public void R1000_15_FIM_DB_SELECT_1()
        {
            /*" -2504- EXEC SQL SELECT NUMOPG INTO :WHOST-NUMOPG FROM SEGUROS.V0ADIANTA WHERE CODPDT = 17256 AND NUM_APOLICE = :WHOST-NUMBIL AND NUMOPG > 0 WITH UR END-EXEC. */

            var r1000_15_FIM_DB_SELECT_1_Query1 = new R1000_15_FIM_DB_SELECT_1_Query1()
            {
                WHOST_NUMBIL = WHOST_NUMBIL.ToString(),
            };

            var executed_1 = R1000_15_FIM_DB_SELECT_1_Query1.Execute(r1000_15_FIM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NUMOPG, WHOST_NUMOPG);
            }


        }

        [StopWatch]
        /*" R1000-15-FIM-DB-INSERT-2 */
        public void R1000_15_FIM_DB_INSERT_2()
        {
            /*" -2468- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:V0COBA-NUM-APOL , :V0COBA-NRENDOS , :V0COBA-NUM-ITEM , :V0COBA-OCORHIST , :V0COBA-RAMOFR , :V0COBA-MODALIFR , :V0COBA-COD-COBER , :V0COBA-IMP-SEG-IX , :V0COBA-PRM-TAR-IX , :V0COBA-IMP-SEG-VR , :V0COBA-PRM-TAR-VR , :V0COBA-PCT-COBERT , :V0COBA-FATOR-MULT , :V0COBA-DATA-INIVI , :V0COBA-DATA-TERVI , :V0COBA-COD-EMPRESA , CURRENT TIMESTAMP , :V0COBA-SITUACAO:VIND-SITUACAO) END-EXEC. */

            var r1000_15_FIM_DB_INSERT_2_Insert1 = new R1000_15_FIM_DB_INSERT_2_Insert1()
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

            R1000_15_FIM_DB_INSERT_2_Insert1.Execute(r1000_15_FIM_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1000-15-FIM-DB-UPDATE-1 */
        public void R1000_15_FIM_DB_UPDATE_1()
        {
            /*" -2534- EXEC SQL UPDATE SEGUROS.V0NUMERO_OUTROS SET NUMOPG = :V1NOUT-NUMOPG WHERE NUMOPG > 0 END-EXEC. */

            var r1000_15_FIM_DB_UPDATE_1_Update1 = new R1000_15_FIM_DB_UPDATE_1_Update1()
            {
                V1NOUT_NUMOPG = V1NOUT_NUMOPG.ToString(),
            };

            R1000_15_FIM_DB_UPDATE_1_Update1.Execute(r1000_15_FIM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-15-FIM-DB-SELECT-2 */
        public void R1000_15_FIM_DB_SELECT_2()
        {
            /*" -2519- EXEC SQL SELECT NUMOPG INTO :V1NOUT-NUMOPG FROM SEGUROS.V0NUMERO_OUTROS END-EXEC. */

            var r1000_15_FIM_DB_SELECT_2_Query1 = new R1000_15_FIM_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R1000_15_FIM_DB_SELECT_2_Query1.Execute(r1000_15_FIM_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1NOUT_NUMOPG, V1NOUT_NUMOPG);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-INSERT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_INSERT_1()
        {
            /*" -1915- EXEC SQL INSERT INTO SEGUROS.V0APOLICE (CODCLIEN , NUM_APOLICE , NUM_ITEM , MODALIDA , ORGAO , RAMO , NUM_APOL_ANTERIOR , NUMBIL , TIPSGU , TIPAPO , TIPCALC , PODPUBL , NUM_ATA , ANO_ATA , IDEMAN , PCDESCON , PCIOCC , TPCOSCED , QTCOSSEG , PCTCED , DATA_SORTEIO , COD_EMPRESA , TIMESTAMP , CODPRODU , TPCORRET) VALUES (:V0APOL-CODCLIEN , :V0APOL-NUM-APOL , :V0APOL-NUM-ITEM , :V0APOL-MODALIDA , :V0APOL-ORGAO , :V0APOL-RAMO , :V0APOL-NUM-APO-ANT , :V0APOL-NUMBIL , :V0APOL-TIPSGU , :V0APOL-TIPAPO , :V0APOL-TIPCALC , :V0APOL-PODPUBL , :V0APOL-NUM-ATA , :V0APOL-ANO-ATA , :V0APOL-IDEMAN , :V0APOL-PCDESCON , :V0APOL-PCIOCC , :V0APOL-TPCOSCED , :V0APOL-QTCOSSEG , :V0APOL-PCTCED , NULL , :V0APOL-COD-EMPRESA , CURRENT TIMESTAMP , :V0APOL-CODPRODU , :V0APOL-TPCORRET) END-EXEC. */

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
        /*" R1000-15-FIM-DB-INSERT-3 */
        public void R1000_15_FIM_DB_INSERT_3()
        {
            /*" -2569- EXEC SQL INSERT INTO SEGUROS.V0ADIANTA VALUES (:V0ADIA-CODPDT , :V0ADIA-FONTE , :V0ADIA-NUMOPG , :V0ADIA-VALADT , :V0ADIA-QTPRESTA , :V0ADIA-NRPROPOS , :V0ADIA-NUM-APOL , :V0ADIA-NRENDOS , :V0ADIA-NRPARCEL , :V0ADIA-DTMOVTO , :V0ADIA-SITUACAO , :V0ADIA-COD-EMP , CURRENT TIMESTAMP , :V0ADIA-TIPO-ADT) END-EXEC. */

            var r1000_15_FIM_DB_INSERT_3_Insert1 = new R1000_15_FIM_DB_INSERT_3_Insert1()
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

            R1000_15_FIM_DB_INSERT_3_Insert1.Execute(r1000_15_FIM_DB_INSERT_3_Insert1);

        }

        [StopWatch]
        /*" R1000-00-LEITURA */
        private void R1000_00_LEITURA(bool isPerform = false)
        {
            /*" -2686- IF WS-I-ERRO > ZEROS */

            if (WS_I_ERRO > 00)
            {

                /*" -2687- MOVE 'S' TO WS-FLAG-TEM-ERRO */
                _.Move("S", WS_FLAG_TEM_ERRO);

                /*" -2689- MOVE 1 TO WS-I-ERRO */
                _.Move(1, WS_I_ERRO);

                /*" -2691- PERFORM R3050-00-INSERE-ERRO UNTIL WS-FLAG-TEM-ERRO EQUAL 'N' */

                while (!(WS_FLAG_TEM_ERRO == "N"))
                {

                    R3050_00_INSERE_ERRO_SECTION();
                }

                /*" -2693- END-IF */
            }


            /*" -2694- IF WS-SIVPF EQUAL 'S' */

            if (AREA_DE_WORK.WS_SIVPF == "S")
            {

                /*" -2695- IF V0BILH-SITUACAO EQUAL '9' */

                if (V0BILH_SITUACAO == "9")
                {

                    /*" -2696- MOVE 'EMT' TO WHOST-SIT-PROP-SIVPF */
                    _.Move("EMT", WHOST_SIT_PROP_SIVPF);

                    /*" -2697- ELSE */
                }
                else
                {


                    /*" -2698- MOVE 'PEN' TO WHOST-SIT-PROP-SIVPF */
                    _.Move("PEN", WHOST_SIT_PROP_SIVPF);

                    /*" -2700- END-IF */
                }


                /*" -2702- IF V0SIVPF-SIT-PROPOSTA EQUAL WHOST-SIT-PROP-SIVPF NEXT SENTENCE */

                if (V0SIVPF_SIT_PROPOSTA == WHOST_SIT_PROP_SIVPF)
                {

                    /*" -2703- ELSE */
                }
                else
                {


                    /*" -2704- MOVE '2060' TO WNR-EXEC-SQL */
                    _.Move("2060", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

                    /*" -2711- PERFORM R1000_00_LEITURA_DB_UPDATE_1 */

                    R1000_00_LEITURA_DB_UPDATE_1();

                    /*" -2713- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                    if (!DB.SQLCODE.In("00", "100"))
                    {

                        /*" -2715- DISPLAY 'PROBLEMAS NO UPDATE (PROPOSTA_FIDELIZ) ' ' ' V0BILH-NUMBIL */

                        $"PROBLEMAS NO UPDATE (PROPOSTA_FIDELIZ)  {V0BILH_NUMBIL}"
                        .Display();

                        /*" -2717- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -2717- PERFORM R0910-00-FETCH-V0BILHETE. */

            R0910_00_FETCH_V0BILHETE_SECTION();

        }

        [StopWatch]
        /*" R1000-00-LEITURA-DB-UPDATE-1 */
        public void R1000_00_LEITURA_DB_UPDATE_1()
        {
            /*" -2711- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WHOST-SIT-PROP-SIVPF, SITUACAO_ENVIO = 'S' , COD_USUARIO = 'BI6005B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_SICOB = :V0BILH-NUMBIL END-EXEC */

            var r1000_00_LEITURA_DB_UPDATE_1_Update1 = new R1000_00_LEITURA_DB_UPDATE_1_Update1()
            {
                WHOST_SIT_PROP_SIVPF = WHOST_SIT_PROP_SIVPF.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R1000_00_LEITURA_DB_UPDATE_1_Update1.Execute(r1000_00_LEITURA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-15-FIM-DB-INSERT-4 */
        public void R1000_15_FIM_DB_INSERT_4()
        {
            /*" -2622- EXEC SQL INSERT INTO SEGUROS.V0FORMAREC VALUES (:V0FORM-CODPDT , :V0FORM-FONTE , :V0FORM-NUMOPG , :V0FORM-NRPROPOS , :V0FORM-NUM-APOL , :V0FORM-NRENDOS , :V0FORM-NRPARCEL , :V0FORM-NUMPTC , :V0FORM-VALRCP , :V0FORM-PCGACM , :V0FORM-SITUACAO , :V0FORM-VALSDO , :V0FORM-DTMOVTO , :V0FORM-DTVENCTO , :V0FORM-COD-EMP , CURRENT TIMESTAMP) END-EXEC. */

            var r1000_15_FIM_DB_INSERT_4_Insert1 = new R1000_15_FIM_DB_INSERT_4_Insert1()
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

            R1000_15_FIM_DB_INSERT_4_Insert1.Execute(r1000_15_FIM_DB_INSERT_4_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-INSERT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_INSERT_2()
        {
            /*" -2102- EXEC SQL INSERT INTO SEGUROS.V0ENDOSSO (NUM_APOLICE , NRENDOS , CODSUBES , FONTE , NRPROPOS , DATPRO , DATA_LIBERACAO , DTEMIS , NRRCAP , VLRCAP , BCORCAP , AGERCAP , DACRCAP , IDRCAP , BCOCOBR , AGECOBR , DACCOBR , DTINIVIG , DTTERVIG , CDFRACIO , PCENTRAD , PCADICIO , PRESTA1 , QTPARCEL , QTPRESTA , QTITENS , CODTXT , CDACEITA , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SITUACAO , DATARCAP , COD_EMPRESA , CORRECAO , ISENTA_CUSTO , TIMESTAMP , DTVENCTO , CFPREFIX , VLCUSEMI , RAMO , CODPRODU) VALUES (:V0ENDO-NUM-APOL , :V0ENDO-NRENDOS , :V0ENDO-CODSUBES , :V0ENDO-FONTE , :V0ENDO-NRPROPOS , :V0ENDO-DATPRO , :V0ENDO-DT-LIBER , :V0ENDO-DTEMIS , :V0ENDO-NRRCAP , :V0ENDO-VLRCAP , :V0ENDO-BCORCAP , :V0ENDO-AGERCAP , :V0ENDO-DACRCAP , :V0ENDO-IDRCAP , :V0ENDO-BCOCOBR , :V0ENDO-AGECOBR , :V0ENDO-DACCOBR , :V0ENDO-DTINIVIG , :V0ENDO-DTTERVIG , :V0ENDO-CDFRACIO , :V0ENDO-PCENTRAD , :V0ENDO-PCADICIO , :V0ENDO-PRESTA1 , :V0ENDO-QTPARCEL , :V0ENDO-QTPRESTA , :V0ENDO-QTITENS , :V0ENDO-CODTXT , :V0ENDO-CDACEITA , :V0ENDO-MOEDA-IMP, :V0ENDO-MOEDA-PRM, :V0ENDO-TIPO-ENDO, :V0ENDO-COD-USUAR, :V0ENDO-OCORR-END, :V0ENDO-SITUACAO , :V0ENDO-DATARCAP:VIND-DATARCAP , :V0ENDO-COD-EMPRESA , :V0ENDO-CORRECAO , :V0ENDO-ISENTA-CST , CURRENT TIMESTAMP , :V0ENDO-DTVENCTO:VIND-DTVENCTO , :V0ENDO-CFPREFIX:VIND-CFPREFIX , :V0ENDO-VLCUSEMI:VIND-VLCUSEMI , :V0ENDO-RAMO , :V0ENDO-CODPRODU) END-EXEC. */

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
        /*" R1000-15-FIM-DB-INSERT-5 */
        public void R1000_15_FIM_DB_INSERT_5()
        {
            /*" -2670- EXEC SQL INSERT INTO SEGUROS.V0HISTOREC VALUES (:V0HISR-CODPDT , :V0HISR-FONTE , :V0HISR-NUMOPG , :V0HISR-NRPROPOS , :V0HISR-NUM-APOL , :V0HISR-NRENDOS , :V0HISR-NRPARCEL , :V0HISR-NUMPTC , :V0HISR-VALRCP , :V0HISR-NUMREC , :V0HISR-DTMOVTO , :V0HISR-OPERACAO , CURRENT TIME, :V0HISR-COD-EMP , CURRENT TIMESTAMP) END-EXEC. */

            var r1000_15_FIM_DB_INSERT_5_Insert1 = new R1000_15_FIM_DB_INSERT_5_Insert1()
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

            R1000_15_FIM_DB_INSERT_5_Insert1.Execute(r1000_15_FIM_DB_INSERT_5_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-5 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_5()
        {
            /*" -1670- EXEC SQL SELECT SUM(VAL_COBERTURA_IX), SUM(PRM_TARIFARIO_IX) INTO :V1BILC-IMPSEG-IX, :V1BILC-PRMTAR-IX FROM SEGUROS.V0BILHETE_COBER WHERE RAMOFR = :V1BILC-RAMOFR AND MODALIFR = :V1BILC-MODALIFR AND COD_OPCAO = :V1BILC-OPCAO WITH UR END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1()
            {
                V1BILC_MODALIFR = V1BILC_MODALIFR.ToString(),
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-6 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_6()
        {
            /*" -1799- EXEC SQL SELECT CODUNIMO, PCCOMCOR, PCIOCC , VALMAX_COBERBAS INTO :V1BILC-CODUNIMO, :V1BILC-PCCOMCOR, :V1BILC-PCIOCC , :V1BILC-VALMAX FROM SEGUROS.V0BILHETE_COBER WHERE RAMOFR = :V1BILC-RAMOFR AND MODALIFR = :V1BILC-MODALIFR AND COD_OPCAO = :V1BILC-OPCAO AND PCCOMCOR > 0 AND IDE_COBERTURA = '1' WITH UR END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1()
            {
                V1BILC_MODALIFR = V1BILC_MODALIFR.ToString(),
                V1BILC_RAMOFR = V1BILC_RAMOFR.ToString(),
                V1BILC_OPCAO = V1BILC_OPCAO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILC_CODUNIMO, V1BILC_CODUNIMO);
                _.Move(executed_1.V1BILC_PCCOMCOR, V1BILC_PCCOMCOR);
                _.Move(executed_1.V1BILC_PCIOCC, V1BILC_PCIOCC);
                _.Move(executed_1.V1BILC_VALMAX, V1BILC_VALMAX);
            }


        }

        [StopWatch]
        /*" R1050-00-TRATA-FUNDAO-SECTION */
        private void R1050_00_TRATA_FUNDAO_SECTION()
        {
            /*" -2731- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2738- MOVE 'S' TO WWORK-FUNDAO. */
            _.Move("S", AREA_DE_WORK.WWORK_FUNDAO);

            /*" -2739- IF V0APOL-CODPRODU EQUAL 1405 */

            if (V0APOL_CODPRODU == 1405)
            {

                /*" -2740- MOVE 2,74 TO AUX-VLCOMIS */
                _.Move(2.74, AREA_DE_WORK.AUX_VLCOMIS);

                /*" -2741- ELSE */
            }
            else
            {


                /*" -2744- MOVE 2,74 TO AUX-VLCOMIS. */
                _.Move(2.74, AREA_DE_WORK.AUX_VLCOMIS);
            }


            /*" -2745- MOVE 19224 TO V0APCR-CODCORR */
            _.Move(19224, V0APCR_CODCORR);

            /*" -2747- MOVE 50 TO V0APCR-PCPARCOR. */
            _.Move(50, V0APCR_PCPARCOR);

            /*" -2750- MOVE ZEROS TO AUX-VALBAS AUX-PERCENT. */
            _.Move(0, AREA_DE_WORK.AUX_VALBAS, AREA_DE_WORK.AUX_PERCENT);

            /*" -2753- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100. */
            AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

            /*" -2757- COMPUTE AUX-PERCENT EQUAL (AUX-VLCOMIS / AUX-VALBAS) * 100. */
            AREA_DE_WORK.AUX_PERCENT.Value = (AREA_DE_WORK.AUX_VLCOMIS / AREA_DE_WORK.AUX_VALBAS) * 100;

            /*" -2759- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR. */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

            /*" -2760- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -2761- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -2762- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -2764- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -2765- MOVE 14 TO V0APCR-RAMOFR */
            _.Move(14, V0APCR_RAMOFR);

            /*" -2766- MOVE 0 TO V0APCR-MODALIFR */
            _.Move(0, V0APCR_MODALIFR);

            /*" -2767- MOVE '1' TO V0APCR-TIPCOM */
            _.Move("1", V0APCR_TIPCOM);

            /*" -2768- MOVE '2' TO V0APCR-INDCRT */
            _.Move("2", V0APCR_INDCRT);

            /*" -2770- MOVE ZEROS TO V0APCR-COD-EMPRESA. */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -2772- MOVE 'BI6005B' TO V0APCR-COD-USUARIO. */
            _.Move("BI6005B", V0APCR_COD_USUARIO);

            /*" -2774- MOVE '105A' TO WNR-EXEC-SQL. */
            _.Move("105A", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2790- PERFORM R1050_00_TRATA_FUNDAO_DB_INSERT_1 */

            R1050_00_TRATA_FUNDAO_DB_INSERT_1();

            /*" -2793- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2794- DISPLAY 'R1077-00 (ERRO - INSERT V0APOLCORRET)...' */
                _.Display($"R1077-00 (ERRO - INSERT V0APOLCORRET)...");

                /*" -2797- DISPLAY 'APOLICE: ' V0APCR-NUM-APOL '  ' 'RAMO: ' V0APCR-RAMOFR '  ' 'OPCAO: ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APCR_NUM_APOL}  RAMO: {V0APCR_RAMOFR}  OPCAO: {WWORK_OPCAO_ANT}"
                .Display();

                /*" -2799- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2807- ADD +1 TO AC-I-V0APOLCORRET. */
            AREA_DE_WORK.AC_I_V0APOLCORRET.Value = AREA_DE_WORK.AC_I_V0APOLCORRET + +1;

            /*" -2808- MOVE 17256 TO V0APCR-CODCORR */
            _.Move(17256, V0APCR_CODCORR);

            /*" -2810- MOVE 50 TO V0APCR-PCPARCOR. */
            _.Move(50, V0APCR_PCPARCOR);

            /*" -2813- MOVE ZEROS TO AUX-VALBAS AUX-PERCENT. */
            _.Move(0, AREA_DE_WORK.AUX_VALBAS, AREA_DE_WORK.AUX_PERCENT);

            /*" -2816- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100. */
            AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

            /*" -2820- COMPUTE AUX-PERCENT EQUAL (3,32 / AUX-VALBAS) * 100. */
            AREA_DE_WORK.AUX_PERCENT.Value = (3.32 / AREA_DE_WORK.AUX_VALBAS) * 100;

            /*" -2835- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR. */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

            /*" -2836- IF V0BILH-DTQITBCO GREATER '2000-09-30' */

            if (V0BILH_DTQITBCO > "2000-09-30")
            {

                /*" -2846- MOVE 1 TO V0APCR-PCCOMCOR. */
                _.Move(1, V0APCR_PCCOMCOR);
            }


            /*" -2847- IF V0BILH-DTQITBCO GREATER '2003-11-30' */

            if (V0BILH_DTQITBCO > "2003-11-30")
            {

                /*" -2850- PERFORM R1060-00-TRATA-FENAE. */

                R1060_00_TRATA_FENAE_SECTION();
            }


            /*" -2851- MOVE V0APOL-NUM-APOL TO V0APCR-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCR_NUM_APOL);

            /*" -2852- MOVE ZEROS TO V0APCR-CODSUBES */
            _.Move(0, V0APCR_CODSUBES);

            /*" -2853- MOVE V0ENDO-DTINIVIG TO V0APCR-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCR_DTINIVIG);

            /*" -2855- MOVE V0ENDO-DTTERVIG TO V0APCR-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCR_DTTERVIG);

            /*" -2856- MOVE 14 TO V0APCR-RAMOFR */
            _.Move(14, V0APCR_RAMOFR);

            /*" -2857- MOVE 0 TO V0APCR-MODALIFR */
            _.Move(0, V0APCR_MODALIFR);

            /*" -2858- MOVE '1' TO V0APCR-TIPCOM */
            _.Move("1", V0APCR_TIPCOM);

            /*" -2859- MOVE '1' TO V0APCR-INDCRT */
            _.Move("1", V0APCR_INDCRT);

            /*" -2861- MOVE ZEROS TO V0APCR-COD-EMPRESA. */
            _.Move(0, V0APCR_COD_EMPRESA);

            /*" -2863- MOVE 'BI6005B' TO V0APCR-COD-USUARIO. */
            _.Move("BI6005B", V0APCR_COD_USUARIO);

            /*" -2865- MOVE '105B' TO WNR-EXEC-SQL. */
            _.Move("105B", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2881- PERFORM R1050_00_TRATA_FUNDAO_DB_INSERT_2 */

            R1050_00_TRATA_FUNDAO_DB_INSERT_2();

            /*" -2884- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2885- DISPLAY 'R1077-00 (ERRO - INSERT V0APOLCORRET)...' */
                _.Display($"R1077-00 (ERRO - INSERT V0APOLCORRET)...");

                /*" -2888- DISPLAY 'APOLICE: ' V0APCR-NUM-APOL '  ' 'RAMO: ' V0APCR-RAMOFR '  ' 'OPCAO: ' WWORK-OPCAO-ANT */

                $"APOLICE: {V0APCR_NUM_APOL}  RAMO: {V0APCR_RAMOFR}  OPCAO: {WWORK_OPCAO_ANT}"
                .Display();

                /*" -2890- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2890- ADD +1 TO AC-I-V0APOLCORRET. */
            AREA_DE_WORK.AC_I_V0APOLCORRET.Value = AREA_DE_WORK.AC_I_V0APOLCORRET + +1;

        }

        [StopWatch]
        /*" R1050-00-TRATA-FUNDAO-DB-INSERT-1 */
        public void R1050_00_TRATA_FUNDAO_DB_INSERT_1()
        {
            /*" -2790- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (:V0APCR-NUM-APOL , :V0APCR-RAMOFR , :V0APCR-MODALIFR , :V0APCR-CODCORR , :V0APCR-CODSUBES , :V0APCR-DTINIVIG , :V0APCR-DTTERVIG , :V0APCR-PCPARCOR , :V0APCR-PCCOMCOR , :V0APCR-TIPCOM , :V0APCR-INDCRT , :V0APCR-COD-EMPRESA , CURRENT TIMESTAMP , :V0APCR-COD-USUARIO) END-EXEC. */

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

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-7 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_7()
        {
            /*" -1826- EXEC SQL SELECT COD_PRODUTO INTO :V0PROE-CODPRODU FROM SEGUROS.V0PROP_ESTIPULANTE WHERE NUMBIL = :V0BILH-NUMBIL AND FONTE = 0 AND NUM_PROPOSTA = 0 AND COD_FROTA = '0' WITH UR END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROE_CODPRODU, V0PROE_CODPRODU);
            }


        }

        [StopWatch]
        /*" R1050-00-TRATA-FUNDAO-DB-INSERT-2 */
        public void R1050_00_TRATA_FUNDAO_DB_INSERT_2()
        {
            /*" -2881- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (:V0APCR-NUM-APOL , :V0APCR-RAMOFR , :V0APCR-MODALIFR , :V0APCR-CODCORR , :V0APCR-CODSUBES , :V0APCR-DTINIVIG , :V0APCR-DTTERVIG , :V0APCR-PCPARCOR , :V0APCR-PCCOMCOR , :V0APCR-TIPCOM , :V0APCR-INDCRT , :V0APCR-COD-EMPRESA , CURRENT TIMESTAMP , :V0APCR-COD-USUARIO) END-EXEC. */

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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-8 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_8()
        {
            /*" -2147- EXEC SQL SELECT VALADT INTO :V0COFE-VALADT FROM SEGUROS.V0COMISSAO_FENAE WHERE NUMBIL = :V0BILH-NUMBIL WITH UR END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COFE_VALADT, V0COFE_VALADT);
            }


        }

        [StopWatch]
        /*" R1060-00-TRATA-FENAE-SECTION */
        private void R1060_00_TRATA_FENAE_SECTION()
        {
            /*" -2909- MOVE '1060' TO WNR-EXEC-SQL. */
            _.Move("1060", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2910- IF V0APOL-CODPRODU EQUAL 1405 */

            if (V0APOL_CODPRODU == 1405)
            {

                /*" -2911- MOVE 3,00 TO AUX-VLCOMIS */
                _.Move(3.00, AREA_DE_WORK.AUX_VLCOMIS);

                /*" -2912- ELSE */
            }
            else
            {


                /*" -2915- MOVE 2,02 TO AUX-VLCOMIS. */
                _.Move(2.02, AREA_DE_WORK.AUX_VLCOMIS);
            }


            /*" -2916- MOVE 17256 TO V0APCR-CODCORR */
            _.Move(17256, V0APCR_CODCORR);

            /*" -2918- MOVE 50 TO V0APCR-PCPARCOR. */
            _.Move(50, V0APCR_PCPARCOR);

            /*" -2921- MOVE ZEROS TO AUX-VALBAS AUX-PERCENT. */
            _.Move(0, AREA_DE_WORK.AUX_VALBAS, AREA_DE_WORK.AUX_PERCENT);

            /*" -2924- COMPUTE AUX-VALBAS EQUAL (V1BILC-PRMTAR-IX * V0APCR-PCPARCOR) / 100. */
            AREA_DE_WORK.AUX_VALBAS.Value = (V1BILC_PRMTAR_IX * V0APCR_PCPARCOR) / 100f;

            /*" -2928- COMPUTE AUX-PERCENT EQUAL (AUX-VLCOMIS / AUX-VALBAS) * 100. */
            AREA_DE_WORK.AUX_PERCENT.Value = (AREA_DE_WORK.AUX_VLCOMIS / AREA_DE_WORK.AUX_VALBAS) * 100;

            /*" -2928- MOVE AUX-PERCENT TO V0APCR-PCCOMCOR. */
            _.Move(AREA_DE_WORK.AUX_PERCENT, V0APCR_PCCOMCOR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_99_SAIDA*/

        [StopWatch]
        /*" R1080-00-GRAVA-V0APOLCOSCED-SECTION */
        private void R1080_00_GRAVA_V0APOLCOSCED_SECTION()
        {
            /*" -2941- MOVE '1080' TO WNR-EXEC-SQL. */
            _.Move("1080", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2964- PERFORM R1080_00_GRAVA_V0APOLCOSCED_DB_DECLARE_1 */

            R1080_00_GRAVA_V0APOLCOSCED_DB_DECLARE_1();

            /*" -2966- PERFORM R1080_00_GRAVA_V0APOLCOSCED_DB_OPEN_1 */

            R1080_00_GRAVA_V0APOLCOSCED_DB_OPEN_1();

            /*" -2969- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2970- DISPLAY 'R1080-00 (ERRO OPEN CURSOR V1COSSEGPROD)...' */
                _.Display($"R1080-00 (ERRO OPEN CURSOR V1COSSEGPROD)...");

                /*" -2974- DISPLAY 'PRODUTO: ' V1BILP-CODPRODU '  ' 'RAMO: ' WWORK-RAMO-ANT ' ' 'OPCA: ' WWORK-OPCAO-ANT ' ' 'INIVIG: ' V0ENDO-DTINIVIG */

                $"PRODUTO: {V1BILP_CODPRODU}  RAMO: {WWORK_RAMO_ANT} OPCA: {WWORK_OPCAO_ANT} INIVIG: {V0ENDO_DTINIVIG}"
                .Display();

                /*" -2976- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2977- MOVE 0 TO WACC-PCTCED WACC-QTCOSSEG. */
            _.Move(0, AREA_DE_WORK.WACC_PCTCED, AREA_DE_WORK.WACC_QTCOSSEG);

            /*" -0- FLUXCONTROL_PERFORM R1080_10_FETCH_V1COSSEGPROD */

            R1080_10_FETCH_V1COSSEGPROD();

        }

        [StopWatch]
        /*" R1080-00-GRAVA-V0APOLCOSCED-DB-OPEN-1 */
        public void R1080_00_GRAVA_V0APOLCOSCED_DB_OPEN_1()
        {
            /*" -2966- EXEC SQL OPEN V1COSSEGPROD END-EXEC. */

            V1COSSEGPROD.Open();

        }

        [StopWatch]
        /*" R3200-10-DECLARE-V0RCAPCOMP-DB-DECLARE-1 */
        public void R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1()
        {
            /*" -4404- EXEC SQL DECLARE V1RCAPCOMP CURSOR FOR SELECT FONTE , NRRCAP , NRRCAPCO , OPERACAO , DTMOVTO , HORAOPER , SITUACAO , BCOAVISO , AGEAVISO , NRAVISO , VLRCAP , DATARCAP , DTCADAST , SITCONTB FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP WITH UR END-EXEC. */
            V1RCAPCOMP = new BI6005B_V1RCAPCOMP(true);
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
            /*" -2983- MOVE '1081' TO WNR-EXEC-SQL. */
            _.Move("1081", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -2993- PERFORM R1080_10_FETCH_V1COSSEGPROD_DB_FETCH_1 */

            R1080_10_FETCH_V1COSSEGPROD_DB_FETCH_1();

            /*" -2996- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3012- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3012- PERFORM R1080_10_FETCH_V1COSSEGPROD_DB_CLOSE_1 */

                    R1080_10_FETCH_V1COSSEGPROD_DB_CLOSE_1();

                    /*" -3014- GO TO R1080-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1080_99_SAIDA*/ //GOTO
                    return;

                    /*" -3015- ELSE */
                }
                else
                {


                    /*" -3016- DISPLAY 'R1080-10 (ERRO - FETCH V1COSSEGPROD)...' */
                    _.Display($"R1080-10 (ERRO - FETCH V1COSSEGPROD)...");

                    /*" -3020- DISPLAY 'PRODUTO: ' V1BILP-CODPRODU '  ' 'RAMO: ' WWORK-RAMO-ANT ' ' 'OPCA: ' WWORK-OPCAO-ANT ' ' 'INIVIG: ' V0ENDO-DTINIVIG */

                    $"PRODUTO: {V1BILP_CODPRODU}  RAMO: {WWORK_RAMO_ANT} OPCA: {WWORK_OPCAO_ANT} INIVIG: {V0ENDO_DTINIVIG}"
                    .Display();

                    /*" -3022- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3023- MOVE V1COSP-CONGENER TO V0APCC-CODCOSS */
            _.Move(V1COSP_CONGENER, V0APCC_CODCOSS);

            /*" -3025- MOVE V0APOL-NUM-APOL TO V0APCC-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0APCC_NUM_APOL);

            /*" -3026- MOVE 14 TO V0APCC-RAMOFR */
            _.Move(14, V0APCC_RAMOFR);

            /*" -3027- MOVE V0ENDO-DTINIVIG TO V0APCC-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APCC_DTINIVIG);

            /*" -3028- MOVE V0ENDO-DTTERVIG TO V0APCC-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APCC_DTTERVIG);

            /*" -3029- MOVE V1COSP-PCPARTIC TO V0APCC-PCPARTIC */
            _.Move(V1COSP_PCPARTIC, V0APCC_PCPARTIC);

            /*" -3030- MOVE V1COSP-PCCOMCOS TO V0APCC-PCCOMCOS */
            _.Move(V1COSP_PCCOMCOS, V0APCC_PCCOMCOS);

            /*" -3032- MOVE ZEROS TO V0APCC-COD-EMPRESA */
            _.Move(0, V0APCC_COD_EMPRESA);

            /*" -3033- ADD V1COSP-PCPARTIC TO WACC-PCTCED */
            AREA_DE_WORK.WACC_PCTCED.Value = AREA_DE_WORK.WACC_PCTCED + V1COSP_PCPARTIC;

            /*" -3035- ADD 1 TO WACC-QTCOSSEG. */
            AREA_DE_WORK.WACC_QTCOSSEG.Value = AREA_DE_WORK.WACC_QTCOSSEG + 1;

            /*" -3037- PERFORM R1082-00-INSERT-V0APOLCOSCED. */

            R1082_00_INSERT_V0APOLCOSCED_SECTION();

            /*" -3037- GO TO R1080-10-FETCH-V1COSSEGPROD. */
            new Task(() => R1080_10_FETCH_V1COSSEGPROD()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1080-10-FETCH-V1COSSEGPROD-DB-FETCH-1 */
        public void R1080_10_FETCH_V1COSSEGPROD_DB_FETCH_1()
        {
            /*" -2993- EXEC SQL FETCH V1COSSEGPROD INTO :V1COSP-CODPRODU , :V1COSP-RAMO , :V1COSP-CONGENER , :V1COSP-PCPARTIC , :V1COSP-PCCOMCOS , :V1COSP-PCADMCOS , :V1COSP-DTINIVIG , :V1COSP-DTTERVIG , :V1COSP-SITUACAO END-EXEC. */

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
            /*" -3012- EXEC SQL CLOSE V1COSSEGPROD END-EXEC */

            V1COSSEGPROD.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1080_99_SAIDA*/

        [StopWatch]
        /*" R1082-00-INSERT-V0APOLCOSCED-SECTION */
        private void R1082_00_INSERT_V0APOLCOSCED_SECTION()
        {
            /*" -3048- MOVE '1082' TO WNR-EXEC-SQL. */
            _.Move("1082", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3059- PERFORM R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1 */

            R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1();

            /*" -3062- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3063- DISPLAY 'R1082-00 (ERRO INSERT V0APOLCOSCED)...' */
                _.Display($"R1082-00 (ERRO INSERT V0APOLCOSCED)...");

                /*" -3066- DISPLAY 'APOLICE: ' V0APCC-NUM-APOL '  ' 'CODCOSS: ' V0APCC-CODCOSS '  ' 'RAMO: ' V0APCC-RAMOFR */

                $"APOLICE: {V0APCC_NUM_APOL}  CODCOSS: {V0APCC_CODCOSS}  RAMO: {V0APCC_RAMOFR}"
                .Display();

                /*" -3068- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3070- ADD +1 TO AC-I-V0APOLCOSCED. */
            AREA_DE_WORK.AC_I_V0APOLCOSCED.Value = AREA_DE_WORK.AC_I_V0APOLCOSCED + +1;

            /*" -3070- PERFORM R1083-00-INSERT-V0ORDECOSCED. */

            R1083_00_INSERT_V0ORDECOSCED_SECTION();

        }

        [StopWatch]
        /*" R1082-00-INSERT-V0APOLCOSCED-DB-INSERT-1 */
        public void R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1()
        {
            /*" -3059- EXEC SQL INSERT INTO SEGUROS.V0APOLCOSCED VALUES (:V0APCC-NUM-APOL , :V0APCC-CODCOSS , :V0APCC-RAMOFR , :V0APCC-DTINIVIG , :V0APCC-DTTERVIG , :V0APCC-PCPARTIC , :V0APCC-PCCOMCOS , :V0APCC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -3081- MOVE '1083' TO WNR-EXEC-SQL. */
            _.Move("1083", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3082- MOVE ZEROS TO V0ORDC-COD-EMPRESA. */
            _.Move(0, V0ORDC_COD_EMPRESA);

            /*" -3083- MOVE V0APCC-NUM-APOL TO V0ORDC-NUM-APOL */
            _.Move(V0APCC_NUM_APOL, V0ORDC_NUM_APOL);

            /*" -3084- MOVE 0 TO V0ORDC-NRENDOS */
            _.Move(0, V0ORDC_NRENDOS);

            /*" -3086- MOVE V0APCC-CODCOSS TO V0ORDC-CODCOSS WWORK-ORD-CONGE. */
            _.Move(V0APCC_CODCOSS, V0ORDC_CODCOSS);
            _.Move(V0APCC_CODCOSS, AREA_DE_WORK.FILLER_2.WWORK_ORD_CONGE);


            /*" -3088- MOVE 10 TO WWORK-ORD-ORGAO. */
            _.Move(10, AREA_DE_WORK.FILLER_2.WWORK_ORD_ORGAO);

            /*" -3089- MOVE V0APCC-CODCOSS TO V1NCOS-CONGENER */
            _.Move(V0APCC_CODCOSS, V1NCOS_CONGENER);

            /*" -3091- MOVE 10 TO V1NCOS-ORGAO. */
            _.Move(10, V1NCOS_ORGAO);

            /*" -3098- PERFORM R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1 */

            R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1();

            /*" -3101- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3102- DISPLAY 'R1083-00 (ERRO - SELECT V1NUMERO_COSSEGURO)...' */
                _.Display($"R1083-00 (ERRO - SELECT V1NUMERO_COSSEGURO)...");

                /*" -3105- DISPLAY 'ORGAO: ' V1NCOS-ORGAO '  ' 'CONGENER: ' V1NCOS-CONGENER '  ' 'BILHETE : ' V0BILH-NUMBIL */

                $"ORGAO: {V1NCOS_ORGAO}  CONGENER: {V1NCOS_CONGENER}  BILHETE : {V0BILH_NUMBIL}"
                .Display();

                /*" -3107- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3109- MOVE '1084' TO WNR-EXEC-SQL. */
            _.Move("1084", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3111- COMPUTE V1NCOS-NRORDEM = V1NCOS-NRORDEM + 1. */
            V1NCOS_NRORDEM.Value = V1NCOS_NRORDEM + 1;

            /*" -3113- MOVE V1NCOS-NRORDEM TO WWORK-ORD-SEQUE. */
            _.Move(V1NCOS_NRORDEM, AREA_DE_WORK.FILLER_2.WWORK_ORD_SEQUE);

            /*" -3115- MOVE WWORK-NUM-ORDEM TO V0ORDC-ORDEM-CED. */
            _.Move(AREA_DE_WORK.WWORK_NUM_ORDEM, V0ORDC_ORDEM_CED);

            /*" -3123- PERFORM R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1 */

            R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1();

            /*" -3126- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3127- DISPLAY 'R1084-00 (ERRO - INSERT V0ORDECOSCED)...' */
                _.Display($"R1084-00 (ERRO - INSERT V0ORDECOSCED)...");

                /*" -3131- DISPLAY 'APOLICE: ' V0ORDC-NUM-APOL '  ' 'ENDOSSO: ' V0ORDC-NRENDOS '  ' 'CODCOSS: ' V0ORDC-CODCOSS '  ' 'NRORDEM: ' V0ORDC-ORDEM-CED */

                $"APOLICE: {V0ORDC_NUM_APOL}  ENDOSSO: {V0ORDC_NRENDOS}  CODCOSS: {V0ORDC_CODCOSS}  NRORDEM: {V0ORDC_ORDEM_CED}"
                .Display();

                /*" -3132- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -3134- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3136- ADD +1 TO AC-I-V0ORDECOSCED. */
            AREA_DE_WORK.AC_I_V0ORDECOSCED.Value = AREA_DE_WORK.AC_I_V0ORDECOSCED + +1;

            /*" -3138- MOVE '1085' TO WNR-EXEC-SQL. */
            _.Move("1085", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3139- MOVE V0APCC-CODCOSS TO V1NCOS-CONGENER */
            _.Move(V0APCC_CODCOSS, V1NCOS_CONGENER);

            /*" -3141- MOVE 10 TO V1NCOS-ORGAO. */
            _.Move(10, V1NCOS_ORGAO);

            /*" -3147- PERFORM R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1 */

            R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1();

            /*" -3150- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3151- DISPLAY 'R1085-00 (ERRO - UPDATE V0NUMERO_COSSEGURO)...' */
                _.Display($"R1085-00 (ERRO - UPDATE V0NUMERO_COSSEGURO)...");

                /*" -3154- DISPLAY 'ORGAO: ' V1NCOS-ORGAO '  ' 'CONGENER: ' V1NCOS-CONGENER '  ' 'BILHETE : ' V0BILH-NUMBIL */

                $"ORGAO: {V1NCOS_ORGAO}  CONGENER: {V1NCOS_CONGENER}  BILHETE : {V0BILH_NUMBIL}"
                .Display();

                /*" -3156- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3156- ADD +1 TO AC-U-V0NUMERO-COSSEGURO. */
            AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO.Value = AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO + +1;

        }

        [StopWatch]
        /*" R1083-00-INSERT-V0ORDECOSCED-DB-SELECT-1 */
        public void R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1()
        {
            /*" -3098- EXEC SQL SELECT NRORDEM INTO :V1NCOS-NRORDEM FROM SEGUROS.V1NUMERO_COSSEGURO WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER WITH UR END-EXEC. */

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
            /*" -3123- EXEC SQL INSERT INTO SEGUROS.V0ORDECOSCED VALUES (:V0ORDC-NUM-APOL , :V0ORDC-NRENDOS , :V0ORDC-CODCOSS , :V0ORDC-ORDEM-CED , :V0ORDC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -3147- EXEC SQL UPDATE SEGUROS.V0NUMERO_COSSEGURO SET NRORDEM = :V1NCOS-NRORDEM , TIMESTAMP = CURRENT TIMESTAMP WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

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
            /*" -3167- MOVE '1090' TO WNR-EXEC-SQL. */
            _.Move("1090", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3168- MOVE WACC-QTCOSSEG TO V0APOL-QTCOSSEG */
            _.Move(AREA_DE_WORK.WACC_QTCOSSEG, V0APOL_QTCOSSEG);

            /*" -3170- MOVE WACC-PCTCED TO V0APOL-PCTCED. */
            _.Move(AREA_DE_WORK.WACC_PCTCED, V0APOL_PCTCED);

            /*" -3175- PERFORM R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1 */

            R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1();

            /*" -3178- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3179- DISPLAY 'R1090-00 (ERRO - UPDATE V0APOLICE)...' */
                _.Display($"R1090-00 (ERRO - UPDATE V0APOLICE)...");

                /*" -3180- DISPLAY 'APOLICE: ' V0APOL-NUM-APOL */
                _.Display($"APOLICE: {V0APOL_NUM_APOL}");

                /*" -3182- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3182- ADD +1 TO AC-U-V0APOLICE. */
            AREA_DE_WORK.AC_U_V0APOLICE.Value = AREA_DE_WORK.AC_U_V0APOLICE + +1;

        }

        [StopWatch]
        /*" R1090-00-UPDATE-V0APOLICE-DB-UPDATE-1 */
        public void R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1()
        {
            /*" -3175- EXEC SQL UPDATE SEGUROS.V0APOLICE SET QTCOSSEG = :V0APOL-QTCOSSEG , PCTCED = :V0APOL-PCTCED WHERE NUM_APOLICE = :V0APOL-NUM-APOL END-EXEC. */

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
        /*" R2010-00-GRAVA-V0HISTOPARC-SECTION */
        private void R2010_00_GRAVA_V0HISTOPARC_SECTION()
        {
            /*" -3193- MOVE '2010' TO WNR-EXEC-SQL. */
            _.Move("2010", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3194- MOVE V0APOL-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0HISP_NUM_APOL);

            /*" -3196- MOVE 0 TO V0HISP-NRENDOS */
            _.Move(0, V0HISP_NRENDOS);

            /*" -3197- MOVE ZEROS TO V0HISP-NRPARCEL */
            _.Move(0, V0HISP_NRPARCEL);

            /*" -3198- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -3199- MOVE 0101 TO V0HISP-OPERACAO */
            _.Move(0101, V0HISP_OPERACAO);

            /*" -3201- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -3202- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -3203- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -3204- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -3205- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -3207- MOVE WS000-HORA-TIME TO V0HISP-HORAOPER. */
            _.Move(WS000_HORA_TIME, V0HISP_HORAOPER);

            /*" -3209- MOVE 1 TO V0HISP-OCORHIST */
            _.Move(1, V0HISP_OCORHIST);

            /*" -3210- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -3211- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -3212- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -3213- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -3214- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -3215- MOVE V0PARC-OTNIOF TO V0HISP-VLIOCC */
            _.Move(V0PARC_OTNIOF, V0HISP_VLIOCC);

            /*" -3216- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -3217- MOVE ZEROS TO V0HISP-VLPREMIO */
            _.Move(0, V0HISP_VLPREMIO);

            /*" -3218- MOVE V1SIST-DTMOVACB TO V0HISP-DTVENCTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTVENCTO);

            /*" -3219- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -3220- MOVE V0ENDO-AGECOBR TO V0HISP-AGECOBR */
            _.Move(V0ENDO_AGECOBR, V0HISP_AGECOBR);

            /*" -3221- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -3222- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -3223- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -3224- MOVE 'BI6005B' TO V0HISP-COD-USUAR */
            _.Move("BI6005B", V0HISP_COD_USUAR);

            /*" -3226- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -3228- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -3230- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -3230- PERFORM R2030-00-INSERT-V0HISTOPARC. */

            R2030_00_INSERT_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2020-00-GRAVA-OPERACAO-BAIXA-SECTION */
        private void R2020_00_GRAVA_OPERACAO_BAIXA_SECTION()
        {
            /*" -3241- MOVE '2020' TO WNR-EXEC-SQL. */
            _.Move("2020", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3242- MOVE V0APOL-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V0APOL_NUM_APOL, V0HISP_NUM_APOL);

            /*" -3243- MOVE 0 TO V0HISP-NRENDOS */
            _.Move(0, V0HISP_NRENDOS);

            /*" -3245- MOVE ZEROS TO V0HISP-NRPARCEL */
            _.Move(0, V0HISP_NRPARCEL);

            /*" -3246- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -3247- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -3249- MOVE 0201 TO V0HISP-OPERACAO */
            _.Move(0201, V0HISP_OPERACAO);

            /*" -3250- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -3251- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -3252- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -3253- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -3255- MOVE WS000-HORA-TIME TO V0HISP-HORAOPER. */
            _.Move(WS000_HORA_TIME, V0HISP_HORAOPER);

            /*" -3257- MOVE 2 TO V0HISP-OCORHIST */
            _.Move(2, V0HISP_OCORHIST);

            /*" -3258- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -3259- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -3260- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -3261- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -3262- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -3263- MOVE V0PARC-OTNIOF TO V0HISP-VLIOCC */
            _.Move(V0PARC_OTNIOF, V0HISP_VLIOCC);

            /*" -3266- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -3267- MOVE V2RCAP-VLRCAP TO V0HISP-VLPREMIO */
            _.Move(V2RCAP_VLRCAP, V0HISP_VLPREMIO);

            /*" -3268- MOVE V0ENDO-DATARCAP TO V0HISP-DTVENCTO */
            _.Move(V0ENDO_DATARCAP, V0HISP_DTVENCTO);

            /*" -3269- MOVE V1RCAC-BCOAVISO TO V0HISP-BCOCOBR */
            _.Move(V1RCAC_BCOAVISO, V0HISP_BCOCOBR);

            /*" -3270- MOVE V1RCAC-AGEAVISO TO V0HISP-AGECOBR */
            _.Move(V1RCAC_AGEAVISO, V0HISP_AGECOBR);

            /*" -3271- MOVE V1RCAC-NRAVISO TO V0HISP-NRAVISO */
            _.Move(V1RCAC_NRAVISO, V0HISP_NRAVISO);

            /*" -3272- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -3273- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -3274- MOVE 'BI6005B' TO V0HISP-COD-USUAR */
            _.Move("BI6005B", V0HISP_COD_USUAR);

            /*" -3276- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -3277- MOVE +0 TO VIND-DTQITBCO */
            _.Move(+0, VIND_DTQITBCO);

            /*" -3279- MOVE V0BILH-DTQITBCO TO V0HISP-DTQITBCO. */
            _.Move(V0BILH_DTQITBCO, V0HISP_DTQITBCO);

            /*" -3281- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -3281- PERFORM R2030-00-INSERT-V0HISTOPARC. */

            R2030_00_INSERT_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2020_99_SAIDA*/

        [StopWatch]
        /*" R2030-00-INSERT-V0HISTOPARC-SECTION */
        private void R2030_00_INSERT_V0HISTOPARC_SECTION()
        {
            /*" -3292- MOVE '2030' TO WNR-EXEC-SQL. */
            _.Move("2030", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3321- PERFORM R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1 */

            R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1();

            /*" -3324- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3325- DISPLAY 'R2030-00 (ERRO - INSERT V0HISTOPARC)...' */
                _.Display($"R2030-00 (ERRO - INSERT V0HISTOPARC)...");

                /*" -3330- DISPLAY 'APOL: ' V0HISP-NUM-APOL '  ' 'ENDO: ' V0HISP-NRENDOS '  ' 'PARC: ' V0HISP-NRPARCEL '  ' 'OCOR: ' V0HISP-OCORHIST '  ' 'BILH: ' V0BILH-NUMBIL */

                $"APOL: {V0HISP_NUM_APOL}  ENDO: {V0HISP_NRENDOS}  PARC: {V0HISP_NRPARCEL}  OCOR: {V0HISP_OCORHIST}  BILH: {V0BILH_NUMBIL}"
                .Display();

                /*" -3332- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3332- ADD +1 TO AC-I-V0HISTOPARC. */
            AREA_DE_WORK.AC_I_V0HISTOPARC.Value = AREA_DE_WORK.AC_I_V0HISTOPARC + +1;

        }

        [StopWatch]
        /*" R2030-00-INSERT-V0HISTOPARC-DB-INSERT-1 */
        public void R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -3321- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-DACPARC , :V0HISP-DTMOVTO , :V0HISP-OPERACAO , :V0HISP-HORAOPER , :V0HISP-OCORHIST , :V0HISP-PRM-TARIFA , :V0HISP-VAL-DESCON , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-SITCONTB , :V0HISP-COD-USUAR , :V0HISP-RNUDOC , :V0HISP-DTQITBCO:VIND-DTQITBCO , :V0HISP-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

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
        /*" R2990-00-VERIFICA-PROFISSAO-SECTION */
        private void R2990_00_VERIFICA_PROFISSAO_SECTION()
        {
            /*" -3343- MOVE '2990' TO WNR-EXEC-SQL. */
            _.Move("2990", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3349- PERFORM R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1 */

            R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1();

            /*" -3352- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3354- GO TO R2990-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2990_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3356- MOVE '299A' TO WNR-EXEC-SQL. */
            _.Move("299A", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3362- PERFORM R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2 */

            R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2();

            /*" -3365- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3370- IF PESSOA-FISICA-COD-CBO EQUAL 296 OR 297 OR 298 OR 996 NEXT SENTENCE */

                if (PESSOA_FISICA_COD_CBO.In("296", "297", "298", "996"))
                {

                    /*" -3371- ELSE */
                }
                else
                {


                    /*" -3372- IF PESSOA-FISICA-COD-CBO LESS THAN 1000 */

                    if (PESSOA_FISICA_COD_CBO < 1000)
                    {

                        /*" -3374- MOVE TAB-DESCR-CBO-C(PESSOA-FISICA-COD-CBO) TO CBO-DESCR-CBO */
                        _.Move(TAB_CBO1.TAB_CBO.FILLER_0[PESSOA_FISICA_COD_CBO].TAB_DESCR_CBO_C, CBO_DESCR_CBO);

                        /*" -3391- IF CBO-DESCR-CBO (1:5) EQUAL 'POLIC' OR 'MILIT' OR 'VIGIA' OR 'VIGIL' OR 'SEGUR' OR 'PILOT' OR 'INSTR' OR 'PARAQ' OR 'MOTOB' OR 'MOTOC' OR 'MOTOQ' OR 'MERGU' OR 'ALPIN' OR 'AGENT' OR 'PERIT' OR 'SERVE' */

                        if (CBO_DESCR_CBO.Substring(1, 5).In("POLIC", "MILIT", "VIGIA", "VIGIL", "SEGUR", "PILOT", "INSTR", "PARAQ", "MOTOB", "MOTOC", "MOTOQ", "MERGU", "ALPIN", "AGENT", "PERIT", "SERVE"))
                        {

                            /*" -3392- MOVE 11803 TO V0BILER-COD-ERRO */
                            _.Move(11803, V0BILER_COD_ERRO);

                            /*" -3393- PERFORM R3045-00-GRAVA-TAB-ERRO */

                            R3045_00_GRAVA_TAB_ERRO_SECTION();

                            /*" -3394- END-IF */
                        }


                        /*" -3394- END-IF. */
                    }

                }

            }


        }

        [StopWatch]
        /*" R2990-00-VERIFICA-PROFISSAO-DB-SELECT-1 */
        public void R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1()
        {
            /*" -3349- EXEC SQL SELECT COD_PESSOA INTO :PRPFIDEL-COD-PESSOA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :V0BILH-NUMBIL WITH UR END-EXEC. */

            var r2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1 = new R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1.Execute(r2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRPFIDEL_COD_PESSOA, PRPFIDEL_COD_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2990_99_SAIDA*/

        [StopWatch]
        /*" R2990-00-VERIFICA-PROFISSAO-DB-SELECT-2 */
        public void R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2()
        {
            /*" -3362- EXEC SQL SELECT COD_CBO INTO :PESSOA-FISICA-COD-CBO FROM SEGUROS.PESSOA_FISICA WHERE COD_PESSOA = :PRPFIDEL-COD-PESSOA WITH UR END-EXEC. */

            var r2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1 = new R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1()
            {
                PRPFIDEL_COD_PESSOA = PRPFIDEL_COD_PESSOA.ToString(),
            };

            var executed_1 = R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1.Execute(r2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_FISICA_COD_CBO, PESSOA_FISICA_COD_CBO);
            }


        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-SECTION */
        private void R3000_00_ACUMULA_BILHETE_SECTION()
        {
            /*" -3404- MOVE '.' TO WS000-P1 WS000-P2. */
            _.Move(".", WS000_HORA_TIME_REDF.WS000_P1);
            _.Move(".", WS000_HORA_TIME_REDF.WS000_P2);


            /*" -3406- MOVE SPACES TO WFIM-V1RCAP */
            _.Move("", AREA_DE_WORK.WFIM_V1RCAP);

            /*" -3409- MOVE V0BILH-NUMBIL TO WWORK-NUMBIL V0APOL-NUMBIL. */
            _.Move(V0BILH_NUMBIL, AREA_DE_WORK.WWORK_NUMBIL, V0APOL_NUMBIL);

            /*" -3413- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3415- MOVE V0BILH-NUMBIL TO V0RCAP-NRTIT. */
            _.Move(V0BILH_NUMBIL, V0RCAP_NRTIT);

            /*" -3435- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_1 */

            R3000_00_ACUMULA_BILHETE_DB_SELECT_1();

            /*" -3438- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3439- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3440- MOVE 'S' TO WFIM-V1RCAP */
                    _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);

                    /*" -3441- ELSE */
                }
                else
                {


                    /*" -3442- DISPLAY 'R3000-00 (ERRO - SELECT V0RCAP)...' */
                    _.Display($"R3000-00 (ERRO - SELECT V0RCAP)...");

                    /*" -3445- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'FONTE: ' V0BILH-FONTE '  ' 'NRRCAP: ' WHOST-NRRCAP */

                    $"BILHETE: {V0BILH_NUMBIL}  FONTE: {V0BILH_FONTE}  NRRCAP: {WHOST_NRRCAP}"
                    .Display();

                    /*" -3446- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3448- ELSE */
                }

            }
            else
            {


                /*" -3449- IF V0RCAP-SITUACAO NOT EQUAL '0' */

                if (V0RCAP_SITUACAO != "0")
                {

                    /*" -3450- MOVE 'S' TO WFIM-V1RCAP */
                    _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);

                    /*" -3451- ELSE */
                }
                else
                {


                    /*" -3453- IF V0RCAP-OPERACAO GREATER 199 AND V0RCAP-OPERACAO LESS 300 */

                    if (V0RCAP_OPERACAO > 199 && V0RCAP_OPERACAO < 300)
                    {

                        /*" -3454- MOVE 'S' TO WFIM-V1RCAP */
                        _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);

                        /*" -3455- ELSE */
                    }
                    else
                    {


                        /*" -3457- IF V0RCAP-OPERACAO GREATER 399 AND V0RCAP-OPERACAO LESS 500 */

                        if (V0RCAP_OPERACAO > 399 && V0RCAP_OPERACAO < 500)
                        {

                            /*" -3461- MOVE 'S' TO WFIM-V1RCAP. */
                            _.Move("S", AREA_DE_WORK.WFIM_V1RCAP);
                        }

                    }

                }

            }


            /*" -3462- IF WFIM-V1RCAP EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V1RCAP == "S")
            {

                /*" -3463- IF V0BILH-SITUACAO EQUAL '2' */

                if (V0BILH_SITUACAO == "2")
                {

                    /*" -3464- GO TO R3000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;

                    /*" -3465- ELSE */
                }
                else
                {


                    /*" -3466- MOVE '2' TO V0BILH-SITUACAO */
                    _.Move("2", V0BILH_SITUACAO);

                    /*" -3467- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -3469- GO TO R3000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -3470- MOVE V0RCAP-NRRCAP TO WWORK-NRRCAP */
            _.Move(V0RCAP_NRRCAP, AREA_DE_WORK.FILLER_3.WWORK_NRRCAP);

            /*" -3472- MOVE V0RCAP-NRRCAP TO WHOST-NRRCAP. */
            _.Move(V0RCAP_NRRCAP, WHOST_NRRCAP);

            /*" -3474- MOVE '3025' TO WNR-EXEC-SQL. */
            _.Move("3025", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3490- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_2 */

            R3000_00_ACUMULA_BILHETE_DB_SELECT_2();

            /*" -3493- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3494- DISPLAY 'R3025-00 (ERRO - SELECT V1RCAPCOMP)... ' */
                _.Display($"R3025-00 (ERRO - SELECT V1RCAPCOMP)... ");

                /*" -3497- DISPLAY 'FONTE: ' V0BILH-FONTE '  ' 'NRRCAP: ' WHOST-NRRCAP '  ' 'BILHETE: ' V0BILH-NUMBIL */

                $"FONTE: {V0BILH_FONTE}  NRRCAP: {WHOST_NRRCAP}  BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -3511- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3512- IF WS-SIVPF EQUAL 'S' */

            if (AREA_DE_WORK.WS_SIVPF == "S")
            {

                /*" -3514- GO TO R3000-10-CONTINUA. */

                R3000_10_CONTINUA(); //GOTO
                return;
            }


            /*" -3516- MOVE '3030' TO WNR-EXEC-SQL. */
            _.Move("3030", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3527- PERFORM R3000_00_ACUMULA_BILHETE_DB_SELECT_3 */

            R3000_00_ACUMULA_BILHETE_DB_SELECT_3();

            /*" -3530- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3531- DISPLAY 'R3030-00 (ERRO - SELECT V0BILHETE_FAIXA)... ' */
                _.Display($"R3030-00 (ERRO - SELECT V0BILHETE_FAIXA)... ");

                /*" -3532- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                _.Display($"BILHETE {V0BILH_NUMBIL}");

                /*" -3534- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3535- IF V0BILFX-VERSAO NOT EQUAL 01 */

            if (V0BILFX_VERSAO != 01)
            {

                /*" -3537- MOVE V1RCAC-DATARCAP TO V0BILH-DTQITBCO. */
                _.Move(V1RCAC_DATARCAP, V0BILH_DTQITBCO);
            }


            /*" -3540- IF (V0BILH-DTQITBCO < '1995-03-27' ) OR (V0BILH-DTQITBCO NOT EQUAL V1RCAC-DATARCAP) */

            if ((V0BILH_DTQITBCO < "1995-03-27") || (V0BILH_DTQITBCO != V1RCAC_DATARCAP))
            {

                /*" -3541- MOVE '1' TO V0BILH-SITUACAO */
                _.Move("1", V0BILH_SITUACAO);

                /*" -3542- PERFORM R3040-00-MONTA-V0BILHETE */

                R3040_00_MONTA_V0BILHETE_SECTION();

                /*" -3543- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -3543- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R3000_10_CONTINUA */

            R3000_10_CONTINUA();

        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-1 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_1()
        {
            /*" -3435- EXEC SQL SELECT FONTE, NRRCAP, VLRCAP, SITUACAO, OPERACAO INTO :V0RCAP-FONTE, :V0RCAP-NRRCAP, :V2RCAP-VLRCAP, :V0RCAP-SITUACAO, :V0RCAP-OPERACAO FROM SEGUROS.V0RCAP WHERE NRTIT = :V0RCAP-NRTIT WITH UR END-EXEC. */

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
        /*" R3000-10-CONTINUA */
        private void R3000_10_CONTINUA(bool isPerform = false)
        {
            /*" -3550- COMPUTE WS-VALORDIF EQUAL V0BILH-VLRCAP - V2RCAP-VLRCAP. */
            AREA_DE_WORK.WS_VALORDIF.Value = V0BILH_VLRCAP - V2RCAP_VLRCAP;

            /*" -3551- IF WS-VALORDIF LESS ZEROS */

            if (AREA_DE_WORK.WS_VALORDIF < 00)
            {

                /*" -3555- COMPUTE WS-VALORDIF EQUAL WS-VALORDIF * -1. */
                AREA_DE_WORK.WS_VALORDIF.Value = AREA_DE_WORK.WS_VALORDIF * -1;
            }


            /*" -3558- COMPUTE WS-VALORMAIS EQUAL V2RCAP-VLRCAP - V0BILH-VLRCAP. */
            AREA_DE_WORK.WS_VALORMAIS.Value = V2RCAP_VLRCAP - V0BILH_VLRCAP;

            /*" -3559- IF WS-VALORMAIS LESS ZEROS */

            if (AREA_DE_WORK.WS_VALORMAIS < 00)
            {

                /*" -3562- MOVE 10 TO WS-VALORMAIS. */
                _.Move(10, AREA_DE_WORK.WS_VALORMAIS);
            }


            /*" -3563- IF WS-VALORDIF GREATER WS-VLDIFE */

            if (AREA_DE_WORK.WS_VALORDIF > AREA_DE_WORK.WS_VLDIFE)
            {

                /*" -3564- IF WS-VALORMAIS GREATER WS-VLMAIOR */

                if (AREA_DE_WORK.WS_VALORMAIS > AREA_DE_WORK.WS_VLMAIOR)
                {

                    /*" -3565- MOVE '1' TO V0BILH-SITUACAO */
                    _.Move("1", V0BILH_SITUACAO);

                    /*" -3566- PERFORM R3040-00-MONTA-V0BILHETE */

                    R3040_00_MONTA_V0BILHETE_SECTION();

                    /*" -3567- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -3569- GO TO R3000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -3571- MOVE '3050' TO WNR-EXEC-SQL. */
            _.Move("3050", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3572- MOVE SPACES TO WFIM-V1COMIFENAE. */
            _.Move("", AREA_DE_WORK.WFIM_V1COMIFENAE);

            /*" -3574- MOVE V0BILH-NUMBIL TO V1COFE-NUMBIL. */
            _.Move(V0BILH_NUMBIL, V1COFE_NUMBIL);

            /*" -3582- PERFORM R3000_10_CONTINUA_DB_SELECT_1 */

            R3000_10_CONTINUA_DB_SELECT_1();

            /*" -3585- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3589- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3590- MOVE 'S' TO WFIM-V1COMIFENAE */
                    _.Move("S", AREA_DE_WORK.WFIM_V1COMIFENAE);

                    /*" -3591- ELSE */
                }
                else
                {


                    /*" -3592- DISPLAY 'R3050-00 (ERRO - SELECT V1COMISSAO_FENAE)...' */
                    _.Display($"R3050-00 (ERRO - SELECT V1COMISSAO_FENAE)...");

                    /*" -3593- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                    _.Display($"BILHETE: {V0BILH_NUMBIL}");

                    /*" -3595- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3596- IF WFIM-V1COMIFENAE EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V1COMIFENAE == "S")
            {

                /*" -3597- MOVE '4' TO V0BILH-SITUACAO */
                _.Move("4", V0BILH_SITUACAO);

                /*" -3598- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -3600- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3602- MOVE '3055' TO WNR-EXEC-SQL. */
            _.Move("3055", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3608- PERFORM R3000_10_CONTINUA_DB_SELECT_2 */

            R3000_10_CONTINUA_DB_SELECT_2();

            /*" -3611- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3612- MOVE '4' TO V0BILH-SITUACAO */
                _.Move("4", V0BILH_SITUACAO);

                /*" -3613- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -3614- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -3615- ELSE */
            }
            else
            {


                /*" -3616- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3617- DISPLAY 'R3055-00 (ERRO - SELECT V1AGENCIACEF)...' */
                    _.Display($"R3055-00 (ERRO - SELECT V1AGENCIACEF)...");

                    /*" -3618- DISPLAY 'BILHETE    : ' V0BILH-NUMBIL */
                    _.Display($"BILHETE    : {V0BILH_NUMBIL}");

                    /*" -3619- DISPLAY 'COD.AGENCIA: ' V1COFE-AGECOBR */
                    _.Display($"COD.AGENCIA: {V1COFE_AGECOBR}");

                    /*" -3621- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3623- MOVE '3060' TO WNR-EXEC-SQL. */
            _.Move("3060", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3629- PERFORM R3000_10_CONTINUA_DB_SELECT_3 */

            R3000_10_CONTINUA_DB_SELECT_3();

            /*" -3632- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3633- MOVE '4' TO V0BILH-SITUACAO */
                _.Move("4", V0BILH_SITUACAO);

                /*" -3634- PERFORM R3020-00-UPDATE-V0BILHETE */

                R3020_00_UPDATE_V0BILHETE_SECTION();

                /*" -3635- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -3636- ELSE */
            }
            else
            {


                /*" -3637- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3638- DISPLAY 'R3060-00 (ERRO SELECT V1MALHACEF)...' */
                    _.Display($"R3060-00 (ERRO SELECT V1MALHACEF)...");

                    /*" -3639- DISPLAY 'ESCNEG : ' V1ACEF-CODESCNEG */
                    _.Display($"ESCNEG : {V1ACEF_CODESCNEG}");

                    /*" -3640- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                    _.Display($"BILHETE: {V0BILH_NUMBIL}");

                    /*" -3642- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3643- IF V1COFE-AGECOBR NOT EQUAL V0BILH-AGECOBR */

            if (V1COFE_AGECOBR != V0BILH_AGECOBR)
            {

                /*" -3644- MOVE V1COFE-AGECOBR TO V0BILH-AGECOBR */
                _.Move(V1COFE_AGECOBR, V0BILH_AGECOBR);

                /*" -3646- PERFORM R3095-00-UPDATE-V0BILHETE. */

                R3095_00_UPDATE_V0BILHETE_SECTION();
            }


            /*" -3648- ADD V0BILFX-VALADT TO V0ADIA-VALADT. */
            V0ADIA_VALADT.Value = V0ADIA_VALADT + V0BILFX_VALADT;

            /*" -3649- IF V1MCEF-COD-FONTE NOT EQUAL V0BILH-FONTE */

            if (V1MCEF_COD_FONTE != V0BILH_FONTE)
            {

                /*" -3650- MOVE V1MCEF-COD-FONTE TO V0BILH-FONTE */
                _.Move(V1MCEF_COD_FONTE, V0BILH_FONTE);

                /*" -3655- PERFORM R3090-00-UPDATE-V0BILHETE. */

                R3090_00_UPDATE_V0BILHETE_SECTION();
            }


            /*" -3656- MOVE V1ACEF-CODESCNEG TO V1COBI-COD-ESCNEG */
            _.Move(V1ACEF_CODESCNEG, V1COBI_COD_ESCNEG);

            /*" -3657- MOVE V0BILH-RAMO TO V1COBI-RAMO */
            _.Move(V0BILH_RAMO, V1COBI_RAMO);

            /*" -3659- MOVE V1COFE-DTQITBCO TO V1COBI-DTINIVIG. */
            _.Move(V1COFE_DTQITBCO, V1COBI_DTINIVIG);

            /*" -3661- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3675- PERFORM R3000_10_CONTINUA_DB_SELECT_4 */

            R3000_10_CONTINUA_DB_SELECT_4();

            /*" -3678- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3679- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3680- MOVE 'S' TO WFIM-V1COMERC-BIL */
                    _.Move("S", AREA_DE_WORK.WFIM_V1COMERC_BIL);

                    /*" -3681- ELSE */
                }
                else
                {


                    /*" -3682- DISPLAY 'R3100-00 (ERRO - SELECT V0COMERC_BILHETE.. ' */
                    _.Display($"R3100-00 (ERRO - SELECT V0COMERC_BILHETE.. ");

                    /*" -3685- DISPLAY 'ESCNEG   : ' V1COBI-COD-ESCNEG ' ' 'RAMO     : ' V1COBI-RAMO '  ' 'DTINIVIG ; ' V1COBI-DTINIVIG */

                    $"ESCNEG   : {V1COBI_COD_ESCNEG} RAMO     : {V1COBI_RAMO} DTINIVIG;{V1COBI_DTINIVIG}"
                    .Display();

                    /*" -3687- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3688- IF WFIM-V1COMERC-BIL NOT EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V1COMERC_BIL != "S")
            {

                /*" -3690- IF V0BILH-OPCAO-COBER EQUAL 1 AND V1COBI-COBERTURA1 EQUAL 'B' */

                if (V0BILH_OPCAO_COBER == 1 && V1COBI_COBERTURA1 == "B")
                {

                    /*" -3691- PERFORM R3110-00-INSERT-V0BIL-CC00396 */

                    R3110_00_INSERT_V0BIL_CC00396_SECTION();

                    /*" -3692- ELSE */
                }
                else
                {


                    /*" -3694- IF V0BILH-OPCAO-COBER EQUAL 2 AND V1COBI-COBERTURA2 EQUAL 'B' */

                    if (V0BILH_OPCAO_COBER == 2 && V1COBI_COBERTURA2 == "B")
                    {

                        /*" -3695- PERFORM R3110-00-INSERT-V0BIL-CC00396 */

                        R3110_00_INSERT_V0BIL_CC00396_SECTION();

                        /*" -3696- ELSE */
                    }
                    else
                    {


                        /*" -3698- IF V0BILH-OPCAO-COBER EQUAL 3 AND V1COBI-COBERTURA3 EQUAL 'B' */

                        if (V0BILH_OPCAO_COBER == 3 && V1COBI_COBERTURA3 == "B")
                        {

                            /*" -3700- PERFORM R3110-00-INSERT-V0BIL-CC00396. */

                            R3110_00_INSERT_V0BIL_CC00396_SECTION();
                        }

                    }

                }

            }


            /*" -3702- MOVE '3120' TO WNR-EXEC-SQL. */
            _.Move("3120", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3704- MOVE SPACES TO WFIM-V1FUNCIOCEF. */
            _.Move("", AREA_DE_WORK.WFIM_V1FUNCIOCEF);

            /*" -3724- PERFORM R3000_10_CONTINUA_DB_SELECT_5 */

            R3000_10_CONTINUA_DB_SELECT_5();

            /*" -3727- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3729- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3730- MOVE 10701 TO V0BILER-COD-ERRO */
                    _.Move(10701, V0BILER_COD_ERRO);

                    /*" -3731- PERFORM R3045-00-GRAVA-TAB-ERRO */

                    R3045_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -3732- MOVE '1' TO V0BILH-SITUACAO */
                    _.Move("1", V0BILH_SITUACAO);

                    /*" -3733- PERFORM R3020-00-UPDATE-V0BILHETE */

                    R3020_00_UPDATE_V0BILHETE_SECTION();

                    /*" -3734- GO TO R3000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;

                    /*" -3735- ELSE */
                }
                else
                {


                    /*" -3736- DISPLAY 'R3120-00 (ERRO - SELECT V1FUNCIOCEF)...' */
                    _.Display($"R3120-00 (ERRO - SELECT V1FUNCIOCEF)...");

                    /*" -3737- DISPLAY 'MATRICULA: ' V0BILH-NUM-MATR */
                    _.Display($"MATRICULA: {V0BILH_NUM_MATR}");

                    /*" -3738- DISPLAY 'BILHETE  : ' V0BILH-NUMBIL */
                    _.Display($"BILHETE  : {V0BILH_NUMBIL}");

                    /*" -3740- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3741- IF VIND-COD-ANGAR LESS ZEROS */

            if (VIND_COD_ANGAR < 00)
            {

                /*" -3743- MOVE ZEROS TO V1FUNC-COD-ANGAR. */
                _.Move(0, V1FUNC_COD_ANGAR);
            }


            /*" -3744- IF V1FUNC-COD-ANGAR NOT EQUAL ZEROS */

            if (V1FUNC_COD_ANGAR != 00)
            {

                /*" -3746- GO TO R3000-90-CONTINUA. */

                R3000_90_CONTINUA(); //GOTO
                return;
            }


            /*" -3748- MOVE '3130' TO WNR-EXEC-SQL. */
            _.Move("3130", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3753- PERFORM R3000_10_CONTINUA_DB_SELECT_6 */

            R3000_10_CONTINUA_DB_SELECT_6();

            /*" -3756- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3757- DISPLAY 'R3130-00 (ERRO - SELECT V1NUMERO_OUTROS)...' */
                _.Display($"R3130-00 (ERRO - SELECT V1NUMERO_OUTROS)...");

                /*" -3758- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -3760- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3761- MOVE V1NOUT-CODANGAR TO WS-NUM-ANGAR */
            _.Move(V1NOUT_CODANGAR, AREA_DE_WORK.WS_CODANGAR_R.WS_NUM_ANGAR);

            /*" -3762- ADD 1 TO WS-NUM-ANGAR */
            AREA_DE_WORK.WS_CODANGAR_R.WS_NUM_ANGAR.Value = AREA_DE_WORK.WS_CODANGAR_R.WS_NUM_ANGAR + 1;

            /*" -3763- MOVE WS-NUM-ANGAR TO PROM11W099-NUMERO */
            _.Move(AREA_DE_WORK.WS_CODANGAR_R.WS_NUM_ANGAR, AREA_DE_WORK.PROM11W099.PROM11W099_NUMERO);

            /*" -3765- MOVE 6 TO PROM11W099-TAM */
            _.Move(6, AREA_DE_WORK.PROM11W099.PROM11W099_TAM);

            /*" -3766- CALL 'PROM1101' USING PROM11W099 */
            _.Call("PROM1101", AREA_DE_WORK.PROM11W099);

            /*" -3767- MOVE PROM11W099-DAC TO WS-DAC-ANGAR */
            _.Move(AREA_DE_WORK.PROM11W099.PROM11W099_DAC, AREA_DE_WORK.WS_CODANGAR_R.WS_DAC_ANGAR);

            /*" -3769- MOVE WS-CODANGAR TO V1FUNC-COD-ANGAR */
            _.Move(AREA_DE_WORK.WS_CODANGAR, V1FUNC_COD_ANGAR);

            /*" -3771- MOVE '3140' TO WNR-EXEC-SQL. */
            _.Move("3140", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3779- PERFORM R3000_10_CONTINUA_DB_SELECT_7 */

            R3000_10_CONTINUA_DB_SELECT_7();

            /*" -3782- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3783- DISPLAY 'R3140-00 (ERRO - SELECT V1AGENCIACEF)...' */
                _.Display($"R3140-00 (ERRO - SELECT V1AGENCIACEF)...");

                /*" -3784- DISPLAY 'COD.AGENCIA: ' V1COFE-AGECOBR */
                _.Display($"COD.AGENCIA: {V1COFE_AGECOBR}");

                /*" -3785- DISPLAY 'BILHETE    : ' V0BILH-NUMBIL */
                _.Display($"BILHETE    : {V0BILH_NUMBIL}");

                /*" -3787- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3789- MOVE '3150' TO WNR-EXEC-SQL. */
            _.Move("3150", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3794- PERFORM R3000_10_CONTINUA_DB_UPDATE_1 */

            R3000_10_CONTINUA_DB_UPDATE_1();

            /*" -3797- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3798- DISPLAY 'R3150-00 (ERRO - UPDATE V0FUNCIOCEF)...' */
                _.Display($"R3150-00 (ERRO - UPDATE V0FUNCIOCEF)...");

                /*" -3801- DISPLAY 'MATRICULA: ' V1FUNC-NUM-MATRIC '  ' 'CPF: ' V1FUNC-NUM-CPF '  ' 'BILHETE: ' V0BILH-NUMBIL */

                $"MATRICULA: {V1FUNC_NUM_MATRIC}  CPF: {V1FUNC_NUM_CPF}  BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -3803- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3805- ADD +1 TO AC-U-V0FUNCIOCEF. */
            AREA_DE_WORK.AC_U_V0FUNCIOCEF.Value = AREA_DE_WORK.AC_U_V0FUNCIOCEF + +1;

            /*" -3806- MOVE V1FUNC-ENDERECO TO V1PROD-ENDERECO */
            _.Move(V1FUNC_ENDERECO, V1PROD_ENDERECO);

            /*" -3808- MOVE V1FUNC-CIDADE TO V1PROD-CIDADE */
            _.Move(V1FUNC_CIDADE, V1PROD_CIDADE);

            /*" -3809- MOVE V1SIST-DTMOVACB TO WDATA-SISTEMA */
            _.Move(V1SIST_DTMOVACB, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -3810- MOVE WDATA-SIS-ANO TO WS-AA-NUMREC */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO, AREA_DE_WORK.WS_NUMREC_R.WS_AA_NUMREC);

            /*" -3811- MOVE ZEROS TO WS-NN-NUMREC */
            _.Move(0, AREA_DE_WORK.WS_NUMREC_R.WS_NN_NUMREC);

            /*" -3813- MOVE WS-NUMREC TO WHOST-NUMREC. */
            _.Move(AREA_DE_WORK.WS_NUMREC, WHOST_NUMREC);

            /*" -3815- MOVE '3160' TO WNR-EXEC-SQL. */
            _.Move("3160", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3859- PERFORM R3000_10_CONTINUA_DB_INSERT_1 */

            R3000_10_CONTINUA_DB_INSERT_1();

            /*" -3862- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3863- DISPLAY 'R3160-00 (ERRO - INSERT V0PRODUTOR)...' */
                _.Display($"R3160-00 (ERRO - INSERT V0PRODUTOR)...");

                /*" -3866- DISPLAY 'FONTE: ' V1MCEF-COD-FONTE '  ' 'COD.: ' V1FUNC-COD-ANGAR '  ' 'BILHETE: ' V0BILH-NUMBIL */

                $"FONTE: {V1MCEF_COD_FONTE}  COD.: {V1FUNC_COD_ANGAR}  BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -3868- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3870- ADD +1 TO AC-I-V0PRODUTOR */
            AREA_DE_WORK.AC_I_V0PRODUTOR.Value = AREA_DE_WORK.AC_I_V0PRODUTOR + +1;

            /*" -3872- MOVE '3170' TO WNR-EXEC-SQL. */
            _.Move("3170", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3877- PERFORM R3000_10_CONTINUA_DB_UPDATE_2 */

            R3000_10_CONTINUA_DB_UPDATE_2();

            /*" -3880- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3881- DISPLAY 'R3170-00 (ERRO - UPDATE V0NUMERO_OUTROS)...' */
                _.Display($"R3170-00 (ERRO - UPDATE V0NUMERO_OUTROS)...");

                /*" -3882- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -3884- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3884- ADD +1 TO AC-U-V0NUMEROUT. */
            AREA_DE_WORK.AC_U_V0NUMEROUT.Value = AREA_DE_WORK.AC_U_V0NUMEROUT + +1;

        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-1 */
        public void R3000_10_CONTINUA_DB_SELECT_1()
        {
            /*" -3582- EXEC SQL SELECT AGECOBR, DTQITBCO INTO :V1COFE-AGECOBR, :V1COFE-DTQITBCO FROM SEGUROS.V1COMISSAO_FENAE WHERE NUMBIL = :V1COFE-NUMBIL WITH UR END-EXEC. */

            var r3000_10_CONTINUA_DB_SELECT_1_Query1 = new R3000_10_CONTINUA_DB_SELECT_1_Query1()
            {
                V1COFE_NUMBIL = V1COFE_NUMBIL.ToString(),
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_1_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1COFE_AGECOBR, V1COFE_AGECOBR);
                _.Move(executed_1.V1COFE_DTQITBCO, V1COFE_DTQITBCO);
            }


        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-2 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_2()
        {
            /*" -3490- EXEC SQL SELECT BCOAVISO , AGEAVISO , NRAVISO , DATARCAP INTO :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-DATARCAP FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :WHOST-NRRCAP AND NRRCAPCO = 0 AND OPERACAO = :V0RCAP-OPERACAO AND SITUACAO = '0' WITH UR END-EXEC. */

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
        /*" R3000-10-CONTINUA-DB-SELECT-2 */
        public void R3000_10_CONTINUA_DB_SELECT_2()
        {
            /*" -3608- EXEC SQL SELECT COD_ESCNEG INTO :V1ACEF-CODESCNEG FROM SEGUROS.V1AGENCIACEF WHERE COD_AGENCIA = :V1COFE-AGECOBR WITH UR END-EXEC. */

            var r3000_10_CONTINUA_DB_SELECT_2_Query1 = new R3000_10_CONTINUA_DB_SELECT_2_Query1()
            {
                V1COFE_AGECOBR = V1COFE_AGECOBR.ToString(),
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_2_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ACEF_CODESCNEG, V1ACEF_CODESCNEG);
            }


        }

        [StopWatch]
        /*" R3000-90-CONTINUA */
        private void R3000_90_CONTINUA(bool isPerform = false)
        {
            /*" -3920- MOVE '3172' TO WNR-EXEC-SQL. */
            _.Move("3172", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3926- PERFORM R3000_90_CONTINUA_DB_SELECT_1 */

            R3000_90_CONTINUA_DB_SELECT_1();

            /*" -3929- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3930- DISPLAY 'R3172-00 (ERRO - SELECT V1FONTE)...' */
                _.Display($"R3172-00 (ERRO - SELECT V1FONTE)...");

                /*" -3932- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3935- COMPUTE V1FONT-PROPAUTOM = V1FONT-PROPAUTOM + 1. */
            V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

            /*" -3935- MOVE '3173' TO WNR-EXEC-SQL. */
            _.Move("3173", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

        }

        [StopWatch]
        /*" R3000-90-CONTINUA-DB-SELECT-1 */
        public void R3000_90_CONTINUA_DB_SELECT_1()
        {
            /*" -3926- EXEC SQL SELECT PROPAUTOM INTO :V1FONT-PROPAUTOM FROM SEGUROS.V1FONTE WHERE FONTE = :V0BILH-FONTE WITH UR END-EXEC. */

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
        /*" R3000-10-CONTINUA-DB-SELECT-3 */
        public void R3000_10_CONTINUA_DB_SELECT_3()
        {
            /*" -3629- EXEC SQL SELECT COD_FONTE INTO :V1MCEF-COD-FONTE FROM SEGUROS.V1MALHACEF WHERE COD_SUREG = :V1ACEF-CODESCNEG WITH UR END-EXEC. */

            var r3000_10_CONTINUA_DB_SELECT_3_Query1 = new R3000_10_CONTINUA_DB_SELECT_3_Query1()
            {
                V1ACEF_CODESCNEG = V1ACEF_CODESCNEG.ToString(),
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_3_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MCEF_COD_FONTE, V1MCEF_COD_FONTE);
            }


        }

        [StopWatch]
        /*" R3000-00-ACUMULA-BILHETE-DB-SELECT-3 */
        public void R3000_00_ACUMULA_BILHETE_DB_SELECT_3()
        {
            /*" -3527- EXEC SQL SELECT VERSAO_BIL , VALADT_IND + VALADT_GER + VALADT_SUN INTO :V0BILFX-VERSAO , :V0BILFX-VALADT FROM SEGUROS.V0BILHETE_FAIXA WHERE NUMBIL_INI <= :V0BILH-NUMBIL AND NUMBIL_FIM >= :V0BILH-NUMBIL WITH UR END-EXEC. */

            var r3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1 = new R3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1.Execute(r3000_00_ACUMULA_BILHETE_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BILFX_VERSAO, V0BILFX_VERSAO);
                _.Move(executed_1.V0BILFX_VALADT, V0BILFX_VALADT);
            }


        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-4 */
        public void R3000_10_CONTINUA_DB_SELECT_4()
        {
            /*" -3675- EXEC SQL SELECT COBERTURA1 , COBERTURA2 , COBERTURA3 INTO :V1COBI-COBERTURA1 , :V1COBI-COBERTURA2 , :V1COBI-COBERTURA3 FROM SEGUROS.V1COMERC_BILHETE WHERE COD_ESCNEG = :V1COBI-COD-ESCNEG AND RAMO = 14 AND DTINIVIG <= :V1COBI-DTINIVIG AND DTTERVIG >= :V1COBI-DTINIVIG WITH UR END-EXEC. */

            var r3000_10_CONTINUA_DB_SELECT_4_Query1 = new R3000_10_CONTINUA_DB_SELECT_4_Query1()
            {
                V1COBI_COD_ESCNEG = V1COBI_COD_ESCNEG.ToString(),
                V1COBI_DTINIVIG = V1COBI_DTINIVIG.ToString(),
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_4_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1COBI_COBERTURA1, V1COBI_COBERTURA1);
                _.Move(executed_1.V1COBI_COBERTURA2, V1COBI_COBERTURA2);
                _.Move(executed_1.V1COBI_COBERTURA3, V1COBI_COBERTURA3);
            }


        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-UPDATE-1 */
        public void R3000_10_CONTINUA_DB_UPDATE_1()
        {
            /*" -3794- EXEC SQL UPDATE SEGUROS.V0FUNCIOCEF SET COD_ANGARIADOR = :V1FUNC-COD-ANGAR WHERE NUM_MATRICULA = :V1FUNC-NUM-MATRIC AND NUM_CPF = :V1FUNC-NUM-CPF END-EXEC. */

            var r3000_10_CONTINUA_DB_UPDATE_1_Update1 = new R3000_10_CONTINUA_DB_UPDATE_1_Update1()
            {
                V1FUNC_COD_ANGAR = V1FUNC_COD_ANGAR.ToString(),
                V1FUNC_NUM_MATRIC = V1FUNC_NUM_MATRIC.ToString(),
                V1FUNC_NUM_CPF = V1FUNC_NUM_CPF.ToString(),
            };

            R3000_10_CONTINUA_DB_UPDATE_1_Update1.Execute(r3000_10_CONTINUA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-INSERT-1 */
        public void R3000_10_CONTINUA_DB_INSERT_1()
        {
            /*" -3859- EXEC SQL INSERT INTO SEGUROS.V0PRODUTOR VALUES (:V1MCEF-COD-FONTE , :V1FUNC-COD-ANGAR , '3' , :V1FUNC-NOME-FUN , :V1FUNC-NUM-MATRIC , 0 , ' ' , :V1PROD-ENDERECO , ' ' , :V1PROD-CIDADE , :V1FUNC-SIGLA-UF , :V1FUNC-CEP , 0 , 0 , 0 , ' ' , ' ' , 0 , :V1FUNC-NUM-CPF , 0 , 0 , 'F' , 'S' , :V1SURG-PCDESISS , ' ' , ' ' , 104 , :V0BILH-AGENCIA , 0 , '0' , 0 , 0 , 0 , 0 , :V1SIST-DTMOVACB , :V1SIST-DTMOVACB , :V1SIST-DTMOVACB , :WHOST-NUMREC , 0 , '0' , NULL , CURRENT TIMESTAMP) END-EXEC. */

            var r3000_10_CONTINUA_DB_INSERT_1_Insert1 = new R3000_10_CONTINUA_DB_INSERT_1_Insert1()
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

            R3000_10_CONTINUA_DB_INSERT_1_Insert1.Execute(r3000_10_CONTINUA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO */
        private void R3000_91_LE_ENDOSSO(bool isPerform = false)
        {
            /*" -3945- PERFORM R3000_91_LE_ENDOSSO_DB_SELECT_1 */

            R3000_91_LE_ENDOSSO_DB_SELECT_1();

            /*" -3951- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3953- COMPUTE V1FONT-PROPAUTOM = V1FONT-PROPAUTOM + 1 */
                V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

                /*" -3954- GO TO R3000-91-LE-ENDOSSO */
                new Task(() => R3000_91_LE_ENDOSSO()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -3955- ELSE */
            }
            else
            {


                /*" -3957- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -3958- ELSE */
                }
                else
                {


                    /*" -3959- DISPLAY 'R3173-00 (ERRO - SELECT V1ENDOSSO)... ' */
                    _.Display($"R3173-00 (ERRO - SELECT V1ENDOSSO)... ");

                    /*" -3961- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3963- MOVE '3174' TO WNR-EXEC-SQL. */
            _.Move("3174", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3967- PERFORM R3000_91_LE_ENDOSSO_DB_UPDATE_1 */

            R3000_91_LE_ENDOSSO_DB_UPDATE_1();

            /*" -3970- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3971- DISPLAY 'R3173-00 (ERRO - UPDATE V0FONTE)...' */
                _.Display($"R3173-00 (ERRO - UPDATE V0FONTE)...");

                /*" -3973- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3974- MOVE '9' TO V0BILH-SITUACAO. */
            _.Move("9", V0BILH_SITUACAO);

            /*" -3976- ADD 1 TO WWORK-NUM-ITENS. */
            AREA_DE_WORK.WWORK_NUM_ITENS.Value = AREA_DE_WORK.WWORK_NUM_ITENS + 1;

            /*" -3978- MOVE '3180' TO WNR-EXEC-SQL. */
            _.Move("3180", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3984- PERFORM R3000_91_LE_ENDOSSO_DB_UPDATE_2 */

            R3000_91_LE_ENDOSSO_DB_UPDATE_2();

            /*" -3987- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3988- DISPLAY 'R3180-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3180-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -3989- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -3991- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3996- ADD +1 TO WPROC-BILHETES WACC-PROCESSADOS. */
            AREA_DE_WORK.WPROC_BILHETES.Value = AREA_DE_WORK.WPROC_BILHETES + +1;
            AREA_DE_WORK.WACC_PROCESSADOS.Value = AREA_DE_WORK.WACC_PROCESSADOS + +1;

            /*" -3998- MOVE '3190' TO WNR-EXEC-SQL. */
            _.Move("3190", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -3999- MOVE V0BILH-NUMBIL TO V0COFE-NUMBIL. */
            _.Move(V0BILH_NUMBIL, V0COFE_NUMBIL);

            /*" -4000- MOVE V0BILH-AGECOBR TO V0COFE-AGECOBR */
            _.Move(V0BILH_AGECOBR, V0COFE_AGECOBR);

            /*" -4001- MOVE V0BILH-NUM-MATR TO V0COFE-NUM-MATR */
            _.Move(V0BILH_NUM_MATR, V0COFE_NUM_MATR);

            /*" -4002- MOVE V0BILH-AGENCIA-DEB TO V0COFE-AGENCIA-DEB */
            _.Move(V0BILH_AGENCIA_DEB, V0COFE_AGENCIA_DEB);

            /*" -4003- MOVE V0BILH-OPERACAO-DEB TO V0COFE-OPERACAO-DEB */
            _.Move(V0BILH_OPERACAO_DEB, V0COFE_OPERACAO_DEB);

            /*" -4004- MOVE V0BILH-NUMCTA-DEB TO V0COFE-NUMCTA-DEB */
            _.Move(V0BILH_NUMCTA_DEB, V0COFE_NUMCTA_DEB);

            /*" -4005- MOVE V0BILH-DIGCTA-DEB TO V0COFE-DIGCTA-DEB */
            _.Move(V0BILH_DIGCTA_DEB, V0COFE_DIGCTA_DEB);

            /*" -4006- MOVE SPACES TO V0COFE-NOME-SIND */
            _.Move("", V0COFE_NOME_SIND);

            /*" -4008- MOVE '9' TO V0COFE-SITUACAO. */
            _.Move("9", V0COFE_SITUACAO);

            /*" -4020- PERFORM R3000_91_LE_ENDOSSO_DB_UPDATE_3 */

            R3000_91_LE_ENDOSSO_DB_UPDATE_3();

            /*" -4023- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4024- DISPLAY 'R3190-00 (ERRO - UPDATE V0COMISSAO_FENAE)...' */
                _.Display($"R3190-00 (ERRO - UPDATE V0COMISSAO_FENAE)...");

                /*" -4025- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -4027- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4030- ADD +1 TO AC-U-V0COMIFENAE. */
            AREA_DE_WORK.AC_U_V0COMIFENAE.Value = AREA_DE_WORK.AC_U_V0COMIFENAE + +1;

            /*" -4032- PERFORM R3200-00-BAIXA-RCAP. */

            R3200_00_BAIXA_RCAP_SECTION();

            /*" -4034- MOVE '3210' TO WNR-EXEC-SQL. */
            _.Move("3210", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4044- PERFORM R3000_91_LE_ENDOSSO_DB_UPDATE_4 */

            R3000_91_LE_ENDOSSO_DB_UPDATE_4();

            /*" -4047- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4048- DISPLAY 'R3210-00 (ERRO - UPDATE V0RCAP)...' */
                _.Display($"R3210-00 (ERRO - UPDATE V0RCAP)...");

                /*" -4051- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' 'FONTE: ' V0RCAP-FONTE '  ' 'NRRCAP: ' V0RCAP-NRRCAP */

                $"BILHETE: {V0BILH_NUMBIL}  FONTE: {V0RCAP_FONTE}  NRRCAP: {V0RCAP_NRRCAP}"
                .Display();

                /*" -4053- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4058- ADD 1 TO AC-U-V0RCAP. */
            AREA_DE_WORK.AC_U_V0RCAP.Value = AREA_DE_WORK.AC_U_V0RCAP + 1;

            /*" -4060- MOVE '3220' TO WNR-EXEC-SQL. */
            _.Move("3220", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4068- PERFORM R3000_91_LE_ENDOSSO_DB_SELECT_2 */

            R3000_91_LE_ENDOSSO_DB_SELECT_2();

            /*" -4071- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4072- DISPLAY 'R3220-00 - ERRO SELECT V0CLIENTE ' */
                _.Display($"R3220-00 - ERRO SELECT V0CLIENTE ");

                /*" -4073- DISPLAY 'BILHETE ' V0BILH-NUMBIL ' ' V0BILH-CODCLIEN */

                $"BILHETE {V0BILH_NUMBIL} {V0BILH_CODCLIEN}"
                .Display();

                /*" -4075- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4077- MOVE '3230' TO WNR-EXEC-SQL. */
            _.Move("3230", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4079- MOVE V0BILH-CGCCPF TO V1CROT-CGCCPF */
            _.Move(V0BILH_CGCCPF, V1CROT_CGCCPF);

            /*" -4093- PERFORM R3000_91_LE_ENDOSSO_DB_SELECT_3 */

            R3000_91_LE_ENDOSSO_DB_SELECT_3();

            /*" -4096- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4097- DISPLAY 'PROBLEMAS DE LEITURA CREDITO ROTATIVO' */
                _.Display($"PROBLEMAS DE LEITURA CREDITO ROTATIVO");

                /*" -4098- DISPLAY 'CODIGO DE ERRO ... ' SQLCODE */
                _.Display($"CODIGO DE ERRO ... {DB.SQLCODE}");

                /*" -4099- DISPLAY 'NR. BILHETE    ... ' V0BILH-NUMBIL */
                _.Display($"NR. BILHETE    ... {V0BILH_NUMBIL}");

                /*" -4100- DISPLAY 'NR. CGCCPF     ... ' V0BILH-CGCCPF */
                _.Display($"NR. CGCCPF     ... {V0BILH_CGCCPF}");

                /*" -4101- DISPLAY 'NAO FOI INCLUIDO NA TAB. CLIENTE_CROT' */
                _.Display($"NAO FOI INCLUIDO NA TAB. CLIENTE_CROT");

                /*" -4103- DISPLAY 'BILHETE EMITIDO. PROCESSAMENTO CONTINUA' . */
                _.Display($"BILHETE EMITIDO. PROCESSAMENTO CONTINUA");
            }


            /*" -4104- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4105- IF V0BILH-RAMO EQUAL 82 */

                if (V0BILH_RAMO == 82)
                {

                    /*" -4106- PERFORM R3240-00-UPDATE-CROT-AP */

                    R3240_00_UPDATE_CROT_AP_SECTION();

                    /*" -4107- ELSE */
                }
                else
                {


                    /*" -4108- PERFORM R3250-00-UPDATE-CROT-RES */

                    R3250_00_UPDATE_CROT_RES_SECTION();

                    /*" -4109- ELSE */
                }

            }
            else
            {


                /*" -4110- IF V0BILH-RAMO EQUAL 82 */

                if (V0BILH_RAMO == 82)
                {

                    /*" -4111- MOVE 'S' TO V0CROT-BILH-AP */
                    _.Move("S", V0CROT_BILH_AP);

                    /*" -4112- MOVE 'N' TO V0CROT-BILH-RES */
                    _.Move("N", V0CROT_BILH_RES);

                    /*" -4113- ELSE */
                }
                else
                {


                    /*" -4114- MOVE 'N' TO V0CROT-BILH-AP */
                    _.Move("N", V0CROT_BILH_AP);

                    /*" -4115- MOVE 'S' TO V0CROT-BILH-RES */
                    _.Move("S", V0CROT_BILH_RES);

                    /*" -4116- END-IF */
                }


                /*" -4117- PERFORM R3260-00-INSERT-V0CLIEN-CROT. */

                R3260_00_INSERT_V0CLIEN_CROT_SECTION();
            }


        }

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO-DB-SELECT-1 */
        public void R3000_91_LE_ENDOSSO_DB_SELECT_1()
        {
            /*" -3945- EXEC SQL SELECT NRPROPOS INTO :V0ENDO-NRPROPOS FROM SEGUROS.V1ENDOSSO WHERE FONTE = :V0BILH-FONTE AND NRPROPOS = :V1FONT-PROPAUTOM WITH UR END-EXEC. */

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
            /*" -3967- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V1FONT-PROPAUTOM WHERE FONTE = :V0BILH-FONTE END-EXEC. */

            var r3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1 = new R3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1()
            {
                V1FONT_PROPAUTOM = V1FONT_PROPAUTOM.ToString(),
                V0BILH_FONTE = V0BILH_FONTE.ToString(),
            };

            R3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1.Execute(r3000_91_LE_ENDOSSO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-UPDATE-2 */
        public void R3000_10_CONTINUA_DB_UPDATE_2()
        {
            /*" -3877- EXEC SQL UPDATE SEGUROS.V0NUMERO_OUTROS SET CODANGAR = CODANGAR + 1 WHERE CODANGAR = :V1NOUT-CODANGAR END-EXEC. */

            var r3000_10_CONTINUA_DB_UPDATE_2_Update1 = new R3000_10_CONTINUA_DB_UPDATE_2_Update1()
            {
                V1NOUT_CODANGAR = V1NOUT_CODANGAR.ToString(),
            };

            R3000_10_CONTINUA_DB_UPDATE_2_Update1.Execute(r3000_10_CONTINUA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO-DB-UPDATE-2 */
        public void R3000_91_LE_ENDOSSO_DB_UPDATE_2()
        {
            /*" -3984- EXEC SQL UPDATE SEGUROS.V0BILHETE SET NUM_APOLICE = :V0APOL-NUM-APOL, SITUACAO = :V0BILH-SITUACAO, TIMESTAMP = CURRENT TIMESTAMP WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1 = new R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1()
            {
                V0APOL_NUM_APOL = V0APOL_NUM_APOL.ToString(),
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1.Execute(r3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-5 */
        public void R3000_10_CONTINUA_DB_SELECT_5()
        {
            /*" -3724- EXEC SQL SELECT NUM_MATRICULA , NOME_FUNCIONARIO , ENDERECO_CEF , CIDADE_CEF , SIGLA_UF , CEP , NUM_CPF , COD_ANGARIADOR INTO :V1FUNC-NUM-MATRIC , :V1FUNC-NOME-FUN , :V1FUNC-ENDERECO , :V1FUNC-CIDADE , :V1FUNC-SIGLA-UF , :V1FUNC-CEP , :V1FUNC-NUM-CPF , :V1FUNC-COD-ANGAR:VIND-COD-ANGAR FROM SEGUROS.V1FUNCIOCEF WHERE NUM_MATRICULA = :V0BILH-NUM-MATR WITH UR END-EXEC. */

            var r3000_10_CONTINUA_DB_SELECT_5_Query1 = new R3000_10_CONTINUA_DB_SELECT_5_Query1()
            {
                V0BILH_NUM_MATR = V0BILH_NUM_MATR.ToString(),
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_5_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_5_Query1);
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

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO-DB-UPDATE-3 */
        public void R3000_91_LE_ENDOSSO_DB_UPDATE_3()
        {
            /*" -4020- EXEC SQL UPDATE SEGUROS.V0COMISSAO_FENAE SET AGECOBR = :V0COFE-AGECOBR , NUM_MATRICULA = :V0COFE-NUM-MATR , COD_AGENCIA_DEB = :V0COFE-AGENCIA-DEB , OPERACAO_DEB = :V0COFE-OPERACAO-DEB , NUM_CONTA_DEB = :V0COFE-NUMCTA-DEB , DIG_CONTA_DEB = :V0COFE-DIGCTA-DEB , NOM_SINDICO = :V0COFE-NOME-SIND , SITUACAO = :V0COFE-SITUACAO , TIMESTAMP = CURRENT TIMESTAMP WHERE NUMBIL = :V0COFE-NUMBIL END-EXEC. */

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
            /*" -4068- EXEC SQL SELECT CGCCPF, NOME_RAZAO INTO :V0BILH-CGCCPF, :V0BILH-NOME FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0BILH-CODCLIEN WITH UR END-EXEC. */

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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3000-91-LE-ENDOSSO-DB-SELECT-3 */
        public void R3000_91_LE_ENDOSSO_DB_SELECT_3()
        {
            /*" -4093- EXEC SQL SELECT CGCCPF , BILH_AP , BILH_RES , BILH_VDAZUL , DTMOVABE INTO :V1CROT-CGCCPF , :V1CROT-BILH-AP , :V1CROT-BILH-RES , :V1CROT-BILH-VDAZUL , :V1CROT-DTMOVABE FROM SEGUROS.V1CLIENTE_CROT WHERE CGCCPF = :V0BILH-CGCCPF WITH UR END-EXEC. */

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
            /*" -4044- EXEC SQL UPDATE SEGUROS.V0RCAP SET SITUACAO = '1' , OPERACAO = 220 , NUM_APOLICE = :V0APOL-NUM-APOL , NRENDOS = 0, NRPARCEL = 0, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC. */

            var r3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1 = new R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1()
            {
                V0APOL_NUM_APOL = V0APOL_NUM_APOL.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1.Execute(r3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1);

        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-6 */
        public void R3000_10_CONTINUA_DB_SELECT_6()
        {
            /*" -3753- EXEC SQL SELECT CODANGAR INTO :V1NOUT-CODANGAR FROM SEGUROS.V1NUMERO_OUTROS WITH UR END-EXEC. */

            var r3000_10_CONTINUA_DB_SELECT_6_Query1 = new R3000_10_CONTINUA_DB_SELECT_6_Query1()
            {
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_6_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1NOUT_CODANGAR, V1NOUT_CODANGAR);
            }


        }

        [StopWatch]
        /*" R3020-00-UPDATE-V0BILHETE-SECTION */
        private void R3020_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -4127- MOVE '3020' TO WNR-EXEC-SQL. */
            _.Move("3020", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4132- PERFORM R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -4135- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4136- DISPLAY 'R3020-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3020-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -4137- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -4139- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4139- ADD +1 TO AC-U-V0BILHETE. */
            AREA_DE_WORK.AC_U_V0BILHETE.Value = AREA_DE_WORK.AC_U_V0BILHETE + +1;

        }

        [StopWatch]
        /*" R3020-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -4132- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO, TIMESTAMP = CURRENT TIMESTAMP WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r3020_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3000-10-CONTINUA-DB-SELECT-7 */
        public void R3000_10_CONTINUA_DB_SELECT_7()
        {
            /*" -3779- EXEC SQL SELECT B.PCDESISS INTO :V1SURG-PCDESISS FROM SEGUROS.V1AGENCIACEF A, SEGUROS.V1SUREG B WHERE A.COD_AGENCIA = :V1COFE-AGECOBR AND B.COD_SUREG = A.COD_ESCNEG WITH UR END-EXEC. */

            var r3000_10_CONTINUA_DB_SELECT_7_Query1 = new R3000_10_CONTINUA_DB_SELECT_7_Query1()
            {
                V1COFE_AGECOBR = V1COFE_AGECOBR.ToString(),
            };

            var executed_1 = R3000_10_CONTINUA_DB_SELECT_7_Query1.Execute(r3000_10_CONTINUA_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SURG_PCDESISS, V1SURG_PCDESISS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/

        [StopWatch]
        /*" R3040-00-MONTA-V0BILHETE-SECTION */
        private void R3040_00_MONTA_V0BILHETE_SECTION()
        {
            /*" -4150- MOVE '3040' TO WNR-EXEC-SQL. */
            _.Move("3040", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4152- IF (V0BILH-DTQITBCO NOT EQUAL V1RCAC-DATARCAP) */

            if ((V0BILH_DTQITBCO != V1RCAC_DATARCAP))
            {

                /*" -4153- MOVE 11901 TO V0BILER-COD-ERRO */
                _.Move(11901, V0BILER_COD_ERRO);

                /*" -4155- PERFORM R3045-00-GRAVA-TAB-ERRO. */

                R3045_00_GRAVA_TAB_ERRO_SECTION();
            }


            /*" -4157- IF (V0BILH-VLRCAP NOT EQUAL V2RCAP-VLRCAP) */

            if ((V0BILH_VLRCAP != V2RCAP_VLRCAP))
            {

                /*" -4158- MOVE 12101 TO V0BILER-COD-ERRO */
                _.Move(12101, V0BILER_COD_ERRO);

                /*" -4158- PERFORM R3045-00-GRAVA-TAB-ERRO. */

                R3045_00_GRAVA_TAB_ERRO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3040_99_SAIDA*/

        [StopWatch]
        /*" R3045-00-GRAVA-TAB-ERRO-SECTION */
        private void R3045_00_GRAVA_TAB_ERRO_SECTION()
        {
            /*" -4169- MOVE '3045' TO WNR-EXEC-SQL. */
            _.Move("3045", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4171- ADD 1 TO WS-I-ERRO */
            WS_I_ERRO.Value = WS_I_ERRO + 1;

            /*" -4172- MOVE V0BILER-COD-ERRO TO TB-ERRO-CERT(WS-I-ERRO) */
            _.Move(V0BILER_COD_ERRO, WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT);

            /*" -4172- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3045_99_SAIDA*/

        [StopWatch]
        /*" R3050-00-INSERE-ERRO-SECTION */
        private void R3050_00_INSERE_ERRO_SECTION()
        {
            /*" -4183- MOVE '3050' TO WNR-EXEC-SQL. */
            _.Move("3050", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4185- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -4186- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -4187- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -4188- MOVE V0BILH-NUMBIL TO LK-VG001-NUM-CERTIFICADO */
            _.Move(V0BILH_NUMBIL, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -4189- MOVE TB-ERRO-CERT(WS-I-ERRO) TO LK-VG001-COD-MSG-CRITICA */
            _.Move(WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -4190- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -4191- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -4192- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -4193- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -4194- MOVE 'BI6005B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("BI6005B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -4195- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -4196- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -4197- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -4200- MOVE 'INSERCAO DE ERRO NA EMISSAO DA PROPOSTA' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("INSERCAO DE ERRO NA EMISSAO DA PROPOSTA", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -4202- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -4203- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -4204- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -4208- DISPLAY 'ERRO JAH GRAVADO 3050 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 3050 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -4209- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -4210- ELSE */
                }
                else
                {


                    /*" -4211- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -4212- DISPLAY '* 3050 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 3050 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -4213- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -4214- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -4215- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -4216- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -4217- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -4218- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -4219- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -4221- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -4222- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4223- END-IF */
                }


                /*" -4225- END-IF */
            }


            /*" -4227- ADD 1 TO WS-I-ERRO */
            WS_I_ERRO.Value = WS_I_ERRO + 1;

            /*" -4228- IF TB-ERRO-CERT(WS-I-ERRO) EQUAL ZEROS */

            if (WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT == 00)
            {

                /*" -4229- MOVE 'N' TO WS-FLAG-TEM-ERRO */
                _.Move("N", WS_FLAG_TEM_ERRO);

                /*" -4230- END-IF */
            }


            /*" -4230- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3050_99_SAIDA*/

        [StopWatch]
        /*" R3060-00-VERIFICA-CRTCA-PEND-SECTION */
        private void R3060_00_VERIFICA_CRTCA_PEND_SECTION()
        {
            /*" -4256- MOVE '3060' TO WNR-EXEC-SQL. */
            _.Move("3060", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4258- MOVE ZEROS TO WS-ERRO-COUNT */
            _.Move(0, WS_ERRO_COUNT);

            /*" -4268- PERFORM R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1 */

            R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1();

            /*" -4271- IF SQLCODE NOT EQUAL ZEROS AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -4272- DISPLAY 'R1510-00 - PROBLEMAS NO SELECT(V0ERROS)  ' */
                _.Display($"R1510-00 - PROBLEMAS NO SELECT(V0ERROS)  ");

                /*" -4273- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4274- END-IF */
            }


            /*" -4274- . */

        }

        [StopWatch]
        /*" R3060-00-VERIFICA-CRTCA-PEND-DB-SELECT-1 */
        public void R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1()
        {
            /*" -4268- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :WS-ERRO-COUNT FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :V0BILH-NUMBIL AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> 3 WITH UR END-EXEC. */

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
        /*" R3080-00-UPDATE-V0BILHETE-SECTION */
        private void R3080_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -4285- MOVE '3080' TO WNR-EXEC-SQL. */
            _.Move("3080", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4289- PERFORM R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -4292- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4293- DISPLAY 'R3080-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3080-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -4294- DISPLAY 'BILHETE: ' V0BILH-NUMBIL */
                _.Display($"BILHETE: {V0BILH_NUMBIL}");

                /*" -4297- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4299- MOVE 10205 TO V0BILER-COD-ERRO. */
            _.Move(10205, V0BILER_COD_ERRO);

            /*" -4299- PERFORM R3045-00-GRAVA-TAB-ERRO. */

            R3045_00_GRAVA_TAB_ERRO_SECTION();

        }

        [StopWatch]
        /*" R3080-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -4289- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

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
            /*" -4310- MOVE '3090' TO WNR-EXEC-SQL. */
            _.Move("3090", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4314- PERFORM R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -4317- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4318- DISPLAY 'R3090-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3090-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -4319- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -4319- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3090-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -4314- EXEC SQL UPDATE SEGUROS.V0BILHETE SET FONTE = :V1MCEF-COD-FONTE WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

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
            /*" -4330- MOVE '3095' TO WNR-EXEC-SQL. */
            _.Move("3095", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4334- PERFORM R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -4337- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4338- DISPLAY 'R3095-00 (ERRO - UPDATE V0BILHETE)...' */
                _.Display($"R3095-00 (ERRO - UPDATE V0BILHETE)...");

                /*" -4339- DISPLAY 'BILHETE: ' V0BILH-NUMBIL '  ' */

                $"BILHETE: {V0BILH_NUMBIL}  "
                .Display();

                /*" -4339- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3095-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -4334- EXEC SQL UPDATE SEGUROS.V0BILHETE SET AGECOBR = :V1COFE-AGECOBR WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

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
            /*" -4350- MOVE '3110' TO WNR-EXEC-SQL. */
            _.Move("3110", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4351- MOVE V0BILH-NUMBIL TO V0C396-NUMBIL */
            _.Move(V0BILH_NUMBIL, V0C396_NUMBIL);

            /*" -4352- MOVE V1SIST-DTMOVACB TO V0C396-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0C396_DTMOVTO);

            /*" -4354- MOVE '0' TO V0C396-SITUACAO */
            _.Move("0", V0C396_SITUACAO);

            /*" -4360- PERFORM R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1 */

            R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1();

            /*" -4363- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4365- IF SQLCODE EQUAL -803 NEXT SENTENCE */

                if (DB.SQLCODE == -803)
                {

                    /*" -4366- ELSE */
                }
                else
                {


                    /*" -4370- DISPLAY '3110-00 (ERRO - INSERT TABELA V0BIL_CC00396)..' 'NUMBIL : ' V0C396-NUMBIL '  ' 'DTMOVTO: ' V0C396-DTMOVTO '  ' 'SITUACAO: ' V0C396-SITUACAO */

                    $"3110-00 (ERRO - INSERT TABELA V0BIL_CC00396)..NUMBIL : {V0C396_NUMBIL}  DTMOVTO: {V0C396_DTMOVTO}  SITUACAO: {V0C396_SITUACAO}"
                    .Display();

                    /*" -4370- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3110-00-INSERT-V0BIL-CC00396-DB-INSERT-1 */
        public void R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1()
        {
            /*" -4360- EXEC SQL INSERT INTO SEGUROS.V0BIL_CC00396 VALUES (:V0C396-NUMBIL , :V0C396-DTMOVTO , :V0C396-SITUACAO, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -4379- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R3200_10_DECLARE_V0RCAPCOMP */

            R3200_10_DECLARE_V0RCAPCOMP();

        }

        [StopWatch]
        /*" R3200-10-DECLARE-V0RCAPCOMP */
        private void R3200_10_DECLARE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -4404- PERFORM R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1 */

            R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1();

            /*" -4406- PERFORM R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1 */

            R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1();

        }

        [StopWatch]
        /*" R3200-10-DECLARE-V0RCAPCOMP-DB-OPEN-1 */
        public void R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1()
        {
            /*" -4406- EXEC SQL OPEN V1RCAPCOMP END-EXEC. */

            V1RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R8100-00-DECLARE-CBO-DB-DECLARE-1 */
        public void R8100_00_DECLARE_CBO_DB_DECLARE_1()
        {
            /*" -5390- EXEC SQL DECLARE CCBO CURSOR FOR SELECT COD_CBO, DESCR_CBO FROM SEGUROS.CBO WHERE COD_CBO > 0 AND COD_CBO < 1000 ORDER BY COD_CBO WITH UR END-EXEC. */
            CCBO = new BI6005B_CCBO(false);
            string GetQuery_CCBO()
            {
                var query = @$"SELECT COD_CBO
							, 
							DESCR_CBO 
							FROM SEGUROS.CBO 
							WHERE COD_CBO > 0 
							AND COD_CBO < 1000 
							ORDER BY COD_CBO";

                return query;
            }
            CCBO.GetQueryEvent += GetQuery_CCBO;

        }

        [StopWatch]
        /*" R3200-20-FETCH-V0RCAPCOMP */
        private void R3200_20_FETCH_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -4412- MOVE '3201' TO WNR-EXEC-SQL. */
            _.Move("3201", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4427- PERFORM R3200_20_FETCH_V0RCAPCOMP_DB_FETCH_1 */

            R3200_20_FETCH_V0RCAPCOMP_DB_FETCH_1();

            /*" -4430- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4431- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4431- PERFORM R3200_20_FETCH_V0RCAPCOMP_DB_CLOSE_1 */

                    R3200_20_FETCH_V0RCAPCOMP_DB_CLOSE_1();

                    /*" -4433- GO TO R3200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                    return;

                    /*" -4434- ELSE */
                }
                else
                {


                    /*" -4435- DISPLAY 'R3200-20 (PROBLEMAS FETCH V1RCAPCOMP)... ' */
                    _.Display($"R3200-20 (PROBLEMAS FETCH V1RCAPCOMP)... ");

                    /*" -4438- DISPLAY 'FONTE: ' V0RCAP-FONTE '  ' 'RECIBO: ' V0RCAP-NRRCAP '  ' 'BILHETE: ' V0BILH-NUMBIL */

                    $"FONTE: {V0RCAP_FONTE}  RECIBO: {V0RCAP_NRRCAP}  BILHETE: {V0BILH_NUMBIL}"
                    .Display();

                    /*" -4443- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4444- IF V1RCAC-SITUACAO NOT EQUAL '0' */

            if (V1RCAC_SITUACAO != "0")
            {

                /*" -4446- GO TO R3200-20-FETCH-V0RCAPCOMP. */
                new Task(() => R3200_20_FETCH_V0RCAPCOMP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -4448- IF V1RCAC-OPERACAO GREATER 199 AND V1RCAC-OPERACAO LESS 300 */

            if (V1RCAC_OPERACAO > 199 && V1RCAC_OPERACAO < 300)
            {

                /*" -4450- GO TO R3200-20-FETCH-V0RCAPCOMP. */
                new Task(() => R3200_20_FETCH_V0RCAPCOMP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -4452- IF V1RCAC-OPERACAO GREATER 399 AND V1RCAC-OPERACAO LESS 500 */

            if (V1RCAC_OPERACAO > 399 && V1RCAC_OPERACAO < 500)
            {

                /*" -4452- GO TO R3200-20-FETCH-V0RCAPCOMP. */
                new Task(() => R3200_20_FETCH_V0RCAPCOMP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }

        [StopWatch]
        /*" R3200-20-FETCH-V0RCAPCOMP-DB-FETCH-1 */
        public void R3200_20_FETCH_V0RCAPCOMP_DB_FETCH_1()
        {
            /*" -4427- EXEC SQL FETCH V1RCAPCOMP INTO :V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1RCAC-DTMOVTO , :V1RCAC-HORAOPER , :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB END-EXEC. */

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
            /*" -4431- EXEC SQL CLOSE V1RCAPCOMP END-EXEC */

            V1RCAPCOMP.Close();

        }

        [StopWatch]
        /*" R3200-30-UPDATE-V0RCAPCOMP */
        private void R3200_30_UPDATE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -4461- MOVE '3202' TO WNR-EXEC-SQL. */
            _.Move("3202", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4471- PERFORM R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1 */

            R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1();

            /*" -4474- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4475- DISPLAY 'R3200-30 (ERRO - UPDATE V0RCAPCOMP)...' */
                _.Display($"R3200-30 (ERRO - UPDATE V0RCAPCOMP)...");

                /*" -4478- DISPLAY 'FONTE: ' V1RCAC-FONTE ' ' 'RECIBO: ' V1RCAC-NRRCAP 'BILHETE: ' V0BILH-NUMBIL */

                $"FONTE: {V1RCAC_FONTE} RECIBO: {V1RCAC_NRRCAP}BILHETE: {V0BILH_NUMBIL}"
                .Display();

                /*" -4480- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4480- ADD +1 TO AC-U-V0RCAPCOMP. */
            AREA_DE_WORK.AC_U_V0RCAPCOMP.Value = AREA_DE_WORK.AC_U_V0RCAPCOMP + +1;

        }

        [StopWatch]
        /*" R3200-30-UPDATE-V0RCAPCOMP-DB-UPDATE-1 */
        public void R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1()
        {
            /*" -4471- EXEC SQL UPDATE SEGUROS.V0RCAPCOMP SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1RCAC-FONTE AND NRRCAP = :V1RCAC-NRRCAP AND NRRCAPCO = :V1RCAC-NRRCAPCO AND OPERACAO = :V1RCAC-OPERACAO AND DTMOVTO = :V1RCAC-DTMOVTO AND HORAOPER = :V1RCAC-HORAOPER END-EXEC. */

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
            /*" -4486- MOVE '3203' TO WNR-EXEC-SQL. */
            _.Move("3203", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4487- MOVE '0' TO V1RCAC-SITCONTB */
            _.Move("0", V1RCAC_SITCONTB);

            /*" -4488- MOVE '0' TO V1RCAC-SITUACAO */
            _.Move("0", V1RCAC_SITUACAO);

            /*" -4489- MOVE 220 TO V1RCAC-OPERACAO */
            _.Move(220, V1RCAC_OPERACAO);

            /*" -4490- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -4491- MOVE WS000-H TO WS000-HT */
            _.Move(WS_TIME.WS000_H, WS000_HORA_TIME_REDF.WS000_HT);

            /*" -4492- MOVE WS000-M TO WS000-MT */
            _.Move(WS_TIME.WS000_M, WS000_HORA_TIME_REDF.WS000_MT);

            /*" -4493- MOVE WS000-S TO WS000-ST */
            _.Move(WS_TIME.WS000_S, WS000_HORA_TIME_REDF.WS000_ST);

            /*" -4495- MOVE WS000-HORA-TIME TO V1RCAC-HORAOPER. */
            _.Move(WS000_HORA_TIME, V1RCAC_HORAOPER);

            /*" -4513- PERFORM R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1 */

            R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1();

            /*" -4516- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4517- DISPLAY 'R3200-40 (ERRO - INSERT V0RCAPCOMP)...' */
                _.Display($"R3200-40 (ERRO - INSERT V0RCAPCOMP)...");

                /*" -4520- DISPLAY 'BILHETE:  ' V0BILH-NUMBIL '  ' 'AGENCIA:  ' V1RCAC-AGEAVISO '  ' 'BANCO:    ' V1RCAC-BCOAVISO */

                $"BILHETE:  {V0BILH_NUMBIL}  AGENCIA:  {V1RCAC_AGEAVISO}  BANCO:    {V1RCAC_BCOAVISO}"
                .Display();

                /*" -4523- DISPLAY 'DATARCAP: ' V1RCAC-DATARCAP '  ' 'FONTE:    ' V1RCAC-FONTE '  ' 'NRRCAP:   ' V1RCAC-NRRCAP */

                $"DATARCAP: {V1RCAC_DATARCAP}  FONTE:    {V1RCAC_FONTE}  NRRCAP:   {V1RCAC_NRRCAP}"
                .Display();

                /*" -4525- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4528- ADD 1 TO AC-I-V0RCAPCOMP. */
            AREA_DE_WORK.AC_I_V0RCAPCOMP.Value = AREA_DE_WORK.AC_I_V0RCAPCOMP + 1;

        }

        [StopWatch]
        /*" R3200-40-INSERT-V0RCAPCOMP-DB-INSERT-1 */
        public void R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -4513- EXEC SQL INSERT INTO SEGUROS.V0RCAPCOMP VALUES (:V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1SIST-DTMOVACB , :V1RCAC-HORAOPER , :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB , :V1RCAC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -4534- MOVE '3204' TO WNR-EXEC-SQL. */
            _.Move("3204", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4541- PERFORM R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1 */

            R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1();

            /*" -4545- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -4549- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4549- GO TO R3200-20-FETCH-V0RCAPCOMP. */

            R3200_20_FETCH_V0RCAPCOMP(); //GOTO
            return;

        }

        [StopWatch]
        /*" R3200-50-UPDATE-V0AVISOSALDO-DB-UPDATE-1 */
        public void R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1()
        {
            /*" -4541- EXEC SQL UPDATE SEGUROS.V0AVISOS_SALDOS SET SDOATU = (SDOATU - :V1RCAC-VLRCAP) WHERE BCOAVISO = :V1RCAC-BCOAVISO AND AGEAVISO = :V1RCAC-AGEAVISO AND NRAVISO = :V1RCAC-NRAVISO END-EXEC. */

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
            /*" -4560- MOVE '3240' TO WNR-EXEC-SQL. */
            _.Move("3240", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4562- MOVE 'S' TO V0CROT-BILH-AP */
            _.Move("S", V0CROT_BILH_AP);

            /*" -4563- IF V1CROT-DTMOVABE < V1SIST-DTMOVACB */

            if (V1CROT_DTMOVABE < V1SIST_DTMOVACB)
            {

                /*" -4564- MOVE V1SIST-DTMOVACB TO V0CROT-DTMOVABE */
                _.Move(V1SIST_DTMOVACB, V0CROT_DTMOVABE);

                /*" -4565- ELSE */
            }
            else
            {


                /*" -4567- MOVE V1CROT-DTMOVABE TO V0CROT-DTMOVABE. */
                _.Move(V1CROT_DTMOVABE, V0CROT_DTMOVABE);
            }


            /*" -4572- PERFORM R3240_00_UPDATE_CROT_AP_DB_UPDATE_1 */

            R3240_00_UPDATE_CROT_AP_DB_UPDATE_1();

            /*" -4575- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4576- DISPLAY 'R3240-00 (ERRO - UPDATE V0CLIENTE_CROT)...' */
                _.Display($"R3240-00 (ERRO - UPDATE V0CLIENTE_CROT)...");

                /*" -4577- DISPLAY 'ATUALIZANDO ACIDENTES PESSOAIS         ...' */
                _.Display($"ATUALIZANDO ACIDENTES PESSOAIS         ...");

                /*" -4578- DISPLAY 'CGCCPF : ' V1CROT-CGCCPF */
                _.Display($"CGCCPF : {V1CROT_CGCCPF}");

                /*" -4580- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4580- ADD +1 TO AC-U-V0CLIE-CROT. */
            AREA_DE_WORK.AC_U_V0CLIE_CROT.Value = AREA_DE_WORK.AC_U_V0CLIE_CROT + +1;

        }

        [StopWatch]
        /*" R3240-00-UPDATE-CROT-AP-DB-UPDATE-1 */
        public void R3240_00_UPDATE_CROT_AP_DB_UPDATE_1()
        {
            /*" -4572- EXEC SQL UPDATE SEGUROS.V0CLIENTE_CROT SET BILH_AP = :V0CROT-BILH-AP , DTMOVABE = :V0CROT-DTMOVABE WHERE CGCCPF = :V0BILH-CGCCPF END-EXEC. */

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
            /*" -4591- MOVE '3250' TO WNR-EXEC-SQL. */
            _.Move("3250", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4593- MOVE 'S' TO V0CROT-BILH-RES */
            _.Move("S", V0CROT_BILH_RES);

            /*" -4594- IF V1CROT-DTMOVABE < V1SIST-DTMOVACB */

            if (V1CROT_DTMOVABE < V1SIST_DTMOVACB)
            {

                /*" -4595- MOVE V1SIST-DTMOVACB TO V0CROT-DTMOVABE */
                _.Move(V1SIST_DTMOVACB, V0CROT_DTMOVABE);

                /*" -4596- ELSE */
            }
            else
            {


                /*" -4598- MOVE V1CROT-DTMOVABE TO V0CROT-DTMOVABE. */
                _.Move(V1CROT_DTMOVABE, V0CROT_DTMOVABE);
            }


            /*" -4603- PERFORM R3250_00_UPDATE_CROT_RES_DB_UPDATE_1 */

            R3250_00_UPDATE_CROT_RES_DB_UPDATE_1();

            /*" -4606- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4607- DISPLAY 'R3250-00 (ERRO - UPDATE V0CLIENTE_CROT)...' */
                _.Display($"R3250-00 (ERRO - UPDATE V0CLIENTE_CROT)...");

                /*" -4608- DISPLAY 'ATUALIZANDO RESIDENCIAIS               ...' */
                _.Display($"ATUALIZANDO RESIDENCIAIS               ...");

                /*" -4609- DISPLAY 'CGCCPF : ' V1CROT-CGCCPF */
                _.Display($"CGCCPF : {V1CROT_CGCCPF}");

                /*" -4611- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4611- ADD +1 TO AC-U-V0CLIE-CROT. */
            AREA_DE_WORK.AC_U_V0CLIE_CROT.Value = AREA_DE_WORK.AC_U_V0CLIE_CROT + +1;

        }

        [StopWatch]
        /*" R3250-00-UPDATE-CROT-RES-DB-UPDATE-1 */
        public void R3250_00_UPDATE_CROT_RES_DB_UPDATE_1()
        {
            /*" -4603- EXEC SQL UPDATE SEGUROS.V0CLIENTE_CROT SET BILH_RES = :V0CROT-BILH-RES , DTMOVABE = :V0CROT-DTMOVABE WHERE CGCCPF = :V0BILH-CGCCPF END-EXEC. */

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
            /*" -4622- MOVE '3260' TO WNR-EXEC-SQL. */
            _.Move("3260", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4623- MOVE V0BILH-CGCCPF TO V0CROT-CGCCPF */
            _.Move(V0BILH_CGCCPF, V0CROT_CGCCPF);

            /*" -4624- MOVE 'N' TO V0CROT-BILH-VDAZUL */
            _.Move("N", V0CROT_BILH_VDAZUL);

            /*" -4626- MOVE V1SIST-DTMOVACB TO V0CROT-DTMOVABE */
            _.Move(V1SIST_DTMOVACB, V0CROT_DTMOVABE);

            /*" -4633- PERFORM R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1 */

            R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1();

            /*" -4636- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4637- DISPLAY 'R3260-00 (ERRO - INSERT V0CLIENTE_CROT)...' */
                _.Display($"R3260-00 (ERRO - INSERT V0CLIENTE_CROT)...");

                /*" -4638- DISPLAY 'CGCCPF: ' V0BILH-CGCCPF */
                _.Display($"CGCCPF: {V0BILH_CGCCPF}");

                /*" -4640- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4640- ADD +1 TO AC-I-V0CLIE-CROT. */
            AREA_DE_WORK.AC_I_V0CLIE_CROT.Value = AREA_DE_WORK.AC_I_V0CLIE_CROT + +1;

        }

        [StopWatch]
        /*" R3260-00-INSERT-V0CLIEN-CROT-DB-INSERT-1 */
        public void R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1()
        {
            /*" -4633- EXEC SQL INSERT INTO SEGUROS.V0CLIENTE_CROT VALUES (:V0CROT-CGCCPF , :V0CROT-BILH-AP , :V0CROT-BILH-RES , :V0CROT-BILH-VDAZUL , :V0CROT-DTMOVABE) END-EXEC. */

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
            /*" -4651- MOVE '3270' TO WNR-EXEC-SQL. */
            _.Move("3270", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4653- MOVE V0BILH-NUM-APO-ANT TO V1APOL-NUMBIL */
            _.Move(V0BILH_NUM_APO_ANT, V1APOL_NUMBIL);

            /*" -4660- PERFORM R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1 */

            R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1();

            /*" -4663- IF WSIND-NUM-APOL LESS ZEROS */

            if (WSIND_NUM_APOL < 00)
            {

                /*" -4664- MOVE '*' TO WS-RENOVACAO */
                _.Move("*", AREA_DE_WORK.WS_RENOVACAO);

                /*" -4666- END-IF. */
            }


            /*" -4667- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4668- DISPLAY 'R3270-00 (ERRO SELECT V0APOLICE)' */
                _.Display($"R3270-00 (ERRO SELECT V0APOLICE)");

                /*" -4669- DISPLAY 'RENOVACAO DE BILHETE...........)' */
                _.Display($"RENOVACAO DE BILHETE...........)");

                /*" -4670- DISPLAY 'NUMBIL     : ' V1APOL-NUMBIL */
                _.Display($"NUMBIL     : {V1APOL_NUMBIL}");

                /*" -4670- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3270-00-SELECT-APOLICE-ANT-DB-SELECT-1 */
        public void R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1()
        {
            /*" -4660- EXEC SQL SELECT MAX(NUM_APOLICE) INTO :V1APOL-NUM-APOL:WSIND-NUM-APOL FROM SEGUROS.V1ENDOSSO WHERE NUMBIL = :V1APOL-NUMBIL AND NRENDOS = 0 WITH UR END-EXEC. */

            var r3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1 = new R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1()
            {
                V1APOL_NUMBIL = V1APOL_NUMBIL.ToString(),
            };

            var executed_1 = R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1.Execute(r3270_00_SELECT_APOLICE_ANT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APOL_NUM_APOL, V1APOL_NUM_APOL);
                _.Move(executed_1.WSIND_NUM_APOL, WSIND_NUM_APOL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3270_99_SAIDA*/

        [StopWatch]
        /*" R3275-00-SELECT-ENDOSSO-ANT-SECTION */
        private void R3275_00_SELECT_ENDOSSO_ANT_SECTION()
        {
            /*" -4684- MOVE '3275' TO WNR-EXEC-SQL. */
            _.Move("3275", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4693- PERFORM R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1 */

            R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1();

            /*" -4696- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4697- IF SQLCODE EQUAL 100 OR -811 */

                if (DB.SQLCODE.In("100", "-811"))
                {

                    /*" -4698- MOVE '*' TO WS-RENOVACAO */
                    _.Move("*", AREA_DE_WORK.WS_RENOVACAO);

                    /*" -4699- DISPLAY 'RENOVACAO DE BILHETE...........)' */
                    _.Display($"RENOVACAO DE BILHETE...........)");

                    /*" -4700- DISPLAY 'APOLICE ANT: ' V1APOL-NUM-APOL */
                    _.Display($"APOLICE ANT: {V1APOL_NUM_APOL}");

                    /*" -4701- DISPLAY 'NUMBIL  ANT: ' V1APOL-NUMBIL */
                    _.Display($"NUMBIL  ANT: {V1APOL_NUMBIL}");

                    /*" -4702- ELSE */
                }
                else
                {


                    /*" -4703- DISPLAY 'R3275-00 (ERRO SELECT V0ENDOSSO)' */
                    _.Display($"R3275-00 (ERRO SELECT V0ENDOSSO)");

                    /*" -4704- DISPLAY 'RENOVACAO DE BILHETE...........)' */
                    _.Display($"RENOVACAO DE BILHETE...........)");

                    /*" -4705- DISPLAY 'NUMBIL     : ' V1APOL-NUMBIL */
                    _.Display($"NUMBIL     : {V1APOL_NUMBIL}");

                    /*" -4705- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3275-00-SELECT-ENDOSSO-ANT-DB-SELECT-1 */
        public void R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1()
        {
            /*" -4693- EXEC SQL SELECT DTINIVIG, DTTERVIG INTO :V0ENDO-INIVIG-ANT, :V0ENDO-TERVIG-ANT FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V1APOL-NUM-APOL AND NRENDOS = 0 WITH UR END-EXEC. */

            var r3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1 = new R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1()
            {
                V1APOL_NUM_APOL = V1APOL_NUM_APOL.ToString(),
            };

            var executed_1 = R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1.Execute(r3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_INIVIG_ANT, V0ENDO_INIVIG_ANT);
                _.Move(executed_1.V0ENDO_TERVIG_ANT, V0ENDO_TERVIG_ANT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3275_99_SAIDA*/

        [StopWatch]
        /*" R3280-00-TRATA-FC0001S-SECTION */
        private void R3280_00_TRATA_FC0001S_SECTION()
        {
            /*" -4722- MOVE '3280' TO WNR-EXEC-SQL */
            _.Move("3280", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4725- MOVE ' ' TO W-FCRCAP2 */
            _.Move(" ", W_FCRCAP2);

            /*" -4731- PERFORM R3290-00-INSERT-MOVFEDCA. */

            R3290_00_INSERT_MOVFEDCA_SECTION();

            /*" -4733- PERFORM R3300-00-INSERT-TITFEDCA. */

            R3300_00_INSERT_TITFEDCA_SECTION();

            /*" -4735- PERFORM R3400-00-INSERT-COMFEDCA. */

            R3400_00_INSERT_COMFEDCA_SECTION();

            /*" -4737- PERFORM R3500-00-INSERT-PARFEDCA. */

            R3500_00_INSERT_PARFEDCA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3280_99_SAIDA*/

        [StopWatch]
        /*" R3290-00-INSERT-MOVFEDCA-SECTION */
        private void R3290_00_INSERT_MOVFEDCA_SECTION()
        {
            /*" -4749- MOVE '3290' TO WNR-EXEC-SQL */
            _.Move("3290", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4751- INITIALIZE FC0001S-LINKAGE */
            _.Initialize(
                FC0001S_LINKAGE
            );

            /*" -4755- MOVE 809 TO FC0001S-NUM-PLANO WS-NUM-PLANO. */
            _.Move(809, FC0001S_LINKAGE.FC0001S_NUM_PLANO, AREA_DE_WORK.WS_NUM_TITULO_X.WS_NUM_PLANO);

            /*" -4758- MOVE V0BILH-NUMBIL TO FC0001S-NUM-PROPOSTA */
            _.Move(V0BILH_NUMBIL, FC0001S_LINKAGE.FC0001S_NUM_PROPOSTA);

            /*" -4761- MOVE V1BILC-VALMAX TO FC0001S-VLR-MENSALIDADE */
            _.Move(V1BILC_VALMAX, FC0001S_LINKAGE.FC0001S_VLR_MENSALIDADE);

            /*" -4762- IF W-FCRCAP EQUAL '1' */

            if (W_FCRCAP == "1")
            {

                /*" -4763- PERFORM R9130-00-SELECT-TITULO */

                R9130_00_SELECT_TITULO_SECTION();

                /*" -4764- IF SQLCODE EQUAL 0 */

                if (DB.SQLCODE == 0)
                {

                    /*" -4765- GO TO R3290-10-INSERT */

                    R3290_10_INSERT(); //GOTO
                    return;

                    /*" -4767- END-IF. */
                }

            }


            /*" -4769- CALL 'FC0001S' USING FC0001S-LINKAGE. */
            _.Call("FC0001S", FC0001S_LINKAGE);

            /*" -4770- IF FC0001S-COD-RETORNO NOT EQUAL ZEROS */

            if (FC0001S_LINKAGE.FC0001S_COD_RETORNO != 00)
            {

                /*" -4771- MOVE FC0001S-SQLCODE TO WS-SQLCODE */
                _.Move(FC0001S_LINKAGE.FC0001S_SQLCODE, AREA_DE_WORK.WS_SQLCODE);

                /*" -4772- IF W-FCRCAP EQUAL '1' */

                if (W_FCRCAP == "1")
                {

                    /*" -4773- IF WS-SQLCODE NOT EQUAL -811 */

                    if (AREA_DE_WORK.WS_SQLCODE != -811)
                    {

                        /*" -4774- MOVE '1' TO W-FCRCAP2 */
                        _.Move("1", W_FCRCAP2);

                        /*" -4775- ELSE */
                    }
                    else
                    {


                        /*" -4779- DISPLAY 'PROBLEMAS NO ACESSO A FC0001S ' FC0001S-NUM-PROPOSTA ' ' WS-SQLCODE ' ' FC0001S-DES-MENSAGEM */

                        $"PROBLEMAS NO ACESSO A FC0001S {FC0001S_LINKAGE.FC0001S_NUM_PROPOSTA} {AREA_DE_WORK.WS_SQLCODE} {FC0001S_LINKAGE.FC0001S_DES_MENSAGEM}"
                        .Display();

                        /*" -4780- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -4781- END-IF */
                    }


                    /*" -4782- ELSE */
                }
                else
                {


                    /*" -4786- DISPLAY 'PROBLEMAS NO ACESSO A FC0001S ' FC0001S-NUM-PROPOSTA ' ' WS-SQLCODE ' ' FC0001S-DES-MENSAGEM */

                    $"PROBLEMAS NO ACESSO A FC0001S {FC0001S_LINKAGE.FC0001S_NUM_PROPOSTA} {AREA_DE_WORK.WS_SQLCODE} {FC0001S_LINKAGE.FC0001S_DES_MENSAGEM}"
                    .Display();

                    /*" -4787- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4802- END-IF. */
                }

            }


            /*" -4804- MOVE FC0001S-NUM-PLANO TO WS-NUM-PLANO */
            _.Move(FC0001S_LINKAGE.FC0001S_NUM_PLANO, AREA_DE_WORK.WS_NUM_TITULO_X.WS_NUM_PLANO);

            /*" -4806- MOVE FC0001S-NUM-SERIE TO WS-NUM-SERIE */
            _.Move(FC0001S_LINKAGE.FC0001S_NUM_SERIE, AREA_DE_WORK.WS_NUM_TITULO_X.WS_NUM_SERIE);

            /*" -4808- MOVE FC0001S-NUM-TITULO TO WS-NUM-TITULO */
            _.Move(FC0001S_LINKAGE.FC0001S_NUM_TITULO, AREA_DE_WORK.WS_NUM_TITULO_X.WS_NUM_TITULO);

            /*" -4811- MOVE WS-NUM-TITULO-9 TO MOVFEDCA-NRTITFDCAP. */
            _.Move(AREA_DE_WORK.WS_NUM_TITULO_9, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP);

            /*" -4812- IF V0BILH-FONTE EQUAL ZEROS */

            if (V0BILH_FONTE == 00)
            {

                /*" -4814- MOVE 5 TO V0BILH-FONTE */
                _.Move(5, V0BILH_FONTE);

                /*" -4815- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R3290_10_INSERT */

            R3290_10_INSERT();

        }

        [StopWatch]
        /*" R3290-10-INSERT */
        private void R3290_10_INSERT(bool isPerform = false)
        {
            /*" -4850- PERFORM R3290_10_INSERT_DB_INSERT_1 */

            R3290_10_INSERT_DB_INSERT_1();

            /*" -4854- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4855- IF W-FCRCAP EQUAL '1' */

                if (W_FCRCAP == "1")
                {

                    /*" -4857- IF WS-SQLCODE NOT EQUAL -811 OR WS-SQLCODE NOT EQUAL -803 */

                    if (AREA_DE_WORK.WS_SQLCODE != -811 || AREA_DE_WORK.WS_SQLCODE != -803)
                    {

                        /*" -4858- DISPLAY 'R3290 - ERRO NO INSERT DA MOVFEDCA -811' */
                        _.Display($"R3290 - ERRO NO INSERT DA MOVFEDCA -811");

                        /*" -4859- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                        _.Display($"BILHETE {V0BILH_NUMBIL}");

                        /*" -4860- ELSE */
                    }
                    else
                    {


                        /*" -4861- DISPLAY 'R3290 - ERRO NO INSERT DA MOVFEDCA ' */
                        _.Display($"R3290 - ERRO NO INSERT DA MOVFEDCA ");

                        /*" -4862- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                        _.Display($"BILHETE {V0BILH_NUMBIL}");

                        /*" -4863- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -4864- END-IF */
                    }


                    /*" -4865- ELSE */
                }
                else
                {


                    /*" -4866- DISPLAY 'R3290 - ERRO NO INSERT DA MOVFEDCA ' */
                    _.Display($"R3290 - ERRO NO INSERT DA MOVFEDCA ");

                    /*" -4867- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                    _.Display($"BILHETE {V0BILH_NUMBIL}");

                    /*" -4868- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4869- END-IF */
                }


                /*" -4870- END-IF. */
            }


        }

        [StopWatch]
        /*" R3290-10-INSERT-DB-INSERT-1 */
        public void R3290_10_INSERT_DB_INSERT_1()
        {
            /*" -4850- EXEC SQL INSERT INTO SEGUROS.MOVIMEN_FED_CAP_VA ( NUM_CERTIFICADO , COD_OPERACAO , COD_FONTE , NUM_PROPOSTA , DTMVFDCAP , NUM_PARCELA , QUANT_TIT_CAPITALI , VAL_CUSTO_CAPITALI , SITUACAO , NRTITFDCAP , NRMSCAP , NUM_SEQUENCIA , TIMESTAMP , CODPRODU ) VALUES ( :V0BILH-NUMBIL , 1 , :V0BILH-FONTE, 0 , :V1SIST-DTMOVABE , 0 , 1 , :V1BILC-VALMAX, '1' , :MOVFEDCA-NRTITFDCAP , 0 , 0 , CURRENT TIMESTAMP , :V1BILP-CODPRODU ) END-EXEC. */

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
            /*" -4880- MOVE '3300' TO WNR-EXEC-SQL */
            _.Move("3300", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4882- MOVE FC0001S-DTH-INI-VIGENCIA TO TITFEDCA-DATA-INIVIGENCIA */
            _.Move(FC0001S_LINKAGE.FC0001S_DTH_INI_VIGENCIA, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_INIVIGENCIA);

            /*" -4884- MOVE FC0001S-DTH-FIM-VIGENCIA TO TITFEDCA-DATA-TERVIGENCIA */
            _.Move(FC0001S_LINKAGE.FC0001S_DTH_FIM_VIGENCIA, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_TERVIGENCIA);

            /*" -4887- MOVE FC0001S-DES-COMBINACAO TO WS-COMBINACAO. */
            _.Move(FC0001S_LINKAGE.FC0001S_DES_COMBINACAO, AREA_DE_WORK.WS_COMBINACAO);

            /*" -4889- PERFORM R3310-00-TRATA-COMBINACAO. */

            R3310_00_TRATA_COMBINACAO_SECTION();

            /*" -4891- MOVE WS-COMBINACAO-9 TO TITFEDCA-NRSORTEIO. */
            _.Move(AREA_DE_WORK.WS_COMBINACAO_9, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO);

            /*" -0- FLUXCONTROL_PERFORM R3300_00_INSERT */

            R3300_00_INSERT();

        }

        [StopWatch]
        /*" R3300-00-INSERT */
        private void R3300_00_INSERT(bool isPerform = false)
        {
            /*" -4926- PERFORM R3300_00_INSERT_DB_INSERT_1 */

            R3300_00_INSERT_DB_INSERT_1();

            /*" -4929- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4930- IF W-FCRCAP EQUAL '1' */

                if (W_FCRCAP == "1")
                {

                    /*" -4932- IF WS-SQLCODE NOT EQUAL -811 OR WS-SQLCODE NOT EQUAL -803 */

                    if (AREA_DE_WORK.WS_SQLCODE != -811 || AREA_DE_WORK.WS_SQLCODE != -803)
                    {

                        /*" -4933- DISPLAY 'R3300 - ERRO NO INSERT DA TITFEDCA -811 ' */
                        _.Display($"R3300 - ERRO NO INSERT DA TITFEDCA -811 ");

                        /*" -4934- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                        _.Display($"BILHETE {V0BILH_NUMBIL}");

                        /*" -4935- ELSE */
                    }
                    else
                    {


                        /*" -4936- DISPLAY 'R3300 - ERRO NO INSERT DA TITFEDCA ' */
                        _.Display($"R3300 - ERRO NO INSERT DA TITFEDCA ");

                        /*" -4937- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                        _.Display($"BILHETE {V0BILH_NUMBIL}");

                        /*" -4938- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -4939- END-IF */
                    }


                    /*" -4940- ELSE */
                }
                else
                {


                    /*" -4941- DISPLAY 'R3300 - ERRO NO INSERT DA TITFEDCA ' */
                    _.Display($"R3300 - ERRO NO INSERT DA TITFEDCA ");

                    /*" -4942- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                    _.Display($"BILHETE {V0BILH_NUMBIL}");

                    /*" -4943- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4944- END-IF */
                }


                /*" -4944- END-IF. */
            }


        }

        [StopWatch]
        /*" R3300-00-INSERT-DB-INSERT-1 */
        public void R3300_00_INSERT_DB_INSERT_1()
        {
            /*" -4926- EXEC SQL INSERT INTO SEGUROS.TITULOS_FED_CAP_VA ( NRTITFDCAP , NUM_CERTIFICADO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , NRSORTEIO , VAL_CUSTO_TITULO , NRPARCEL , NRMFDCAPF , SITUACAO , SIT_RELAT , DATA_MOVIMENTO , TIMESTAMP , NRMFDCAPR , NRTITREN ) VALUES ( :MOVFEDCA-NRTITFDCAP , :V0BILH-NUMBIL , :TITFEDCA-DATA-INIVIGENCIA , :TITFEDCA-DATA-TERVIGENCIA , :TITFEDCA-NRSORTEIO , :V1BILC-VALMAX, 0, 0, '0' , '1' , :V1SIST-DTMOVABE , CURRENT TIMESTAMP , 0, 0 ) END-EXEC. */

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
            /*" -4957- MOVE '3310' TO WNR-EXEC-SQL */
            _.Move("3310", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -4958- MOVE ZEROS TO WIND. */
            _.Move(0, WIND);

            /*" -0- FLUXCONTROL_PERFORM R3310_10_LOOP */

            R3310_10_LOOP();

        }

        [StopWatch]
        /*" R3310-10-LOOP */
        private void R3310_10_LOOP(bool isPerform = false)
        {
            /*" -4963- ADD 1 TO WIND. */
            WIND.Value = WIND + 1;

            /*" -4964- IF WIND GREATER 20 */

            if (WIND > 20)
            {

                /*" -4965- DISPLAY 'PROBLEMAS NO NUMERO DE SORTE' */
                _.Display($"PROBLEMAS NO NUMERO DE SORTE");

                /*" -4967- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4968- IF WS-COMB(WIND) = ' ' */

            if (AREA_DE_WORK.WS_COMBINACAO_R.WS_COMB[WIND] == " ")
            {

                /*" -4969- SUBTRACT 1 FROM WIND */
                WIND.Value = WIND - 1;

                /*" -4971- MOVE WS-COMBINACAO(1:WIND) TO WS-COMBINACAO-9 */
                _.Move(AREA_DE_WORK.WS_COMBINACAO.Substring(1, WIND), AREA_DE_WORK.WS_COMBINACAO_9);

                /*" -4972- ELSE */
            }
            else
            {


                /*" -4973- GO TO R3310-10-LOOP. */
                new Task(() => R3310_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3310_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-INSERT-COMFEDCA-SECTION */
        private void R3400_00_INSERT_COMFEDCA_SECTION()
        {
            /*" -4983- MOVE '3400' TO WNR-EXEC-SQL. */
            _.Move("3400", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R3400_10_INSERT */

            R3400_10_INSERT();

        }

        [StopWatch]
        /*" R3400-10-INSERT */
        private void R3400_10_INSERT(bool isPerform = false)
        {
            /*" -4998- PERFORM R3400_10_INSERT_DB_INSERT_1 */

            R3400_10_INSERT_DB_INSERT_1();

            /*" -5001- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5002- IF W-FCRCAP EQUAL '1' */

                if (W_FCRCAP == "1")
                {

                    /*" -5004- IF WS-SQLCODE NOT EQUAL -811 OR WS-SQLCODE NOT EQUAL -803 */

                    if (AREA_DE_WORK.WS_SQLCODE != -811 || AREA_DE_WORK.WS_SQLCODE != -803)
                    {

                        /*" -5005- DISPLAY 'R3400 - ERRO NO INSERT DA COMFEDCA -811 ' */
                        _.Display($"R3400 - ERRO NO INSERT DA COMFEDCA -811 ");

                        /*" -5006- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                        _.Display($"BILHETE {V0BILH_NUMBIL}");

                        /*" -5007- ELSE */
                    }
                    else
                    {


                        /*" -5008- DISPLAY 'R3400 - ERRO NO INSERT DA COMFEDCA  ' */
                        _.Display($"R3400 - ERRO NO INSERT DA COMFEDCA  ");

                        /*" -5009- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                        _.Display($"BILHETE {V0BILH_NUMBIL}");

                        /*" -5010- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -5011- END-IF */
                    }


                    /*" -5012- ELSE */
                }
                else
                {


                    /*" -5013- DISPLAY 'R3400 - ERRO NO INSERT DA COMFEDCA  ' */
                    _.Display($"R3400 - ERRO NO INSERT DA COMFEDCA  ");

                    /*" -5014- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                    _.Display($"BILHETE {V0BILH_NUMBIL}");

                    /*" -5015- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5016- END-IF */
                }


                /*" -5016- END-IF. */
            }


        }

        [StopWatch]
        /*" R3400-10-INSERT-DB-INSERT-1 */
        public void R3400_10_INSERT_DB_INSERT_1()
        {
            /*" -4998- EXEC SQL INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO , SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ( :V0BILH-NUMBIL , '0' , :V1SIST-DTMOVABE , CURRENT TIMESTAMP ) END-EXEC. */

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
            /*" -5027- MOVE '3500' TO WNR-EXEC-SQL. */
            _.Move("3500", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R3500_10_INSERT */

            R3500_10_INSERT();

        }

        [StopWatch]
        /*" R3500-10-INSERT */
        private void R3500_10_INSERT(bool isPerform = false)
        {
            /*" -5049- PERFORM R3500_10_INSERT_DB_INSERT_1 */

            R3500_10_INSERT_DB_INSERT_1();

            /*" -5052- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5053- IF W-FCRCAP EQUAL '1' */

                if (W_FCRCAP == "1")
                {

                    /*" -5055- IF WS-SQLCODE NOT EQUAL -811 OR WS-SQLCODE NOT EQUAL -803 */

                    if (AREA_DE_WORK.WS_SQLCODE != -811 || AREA_DE_WORK.WS_SQLCODE != -803)
                    {

                        /*" -5056- DISPLAY 'R3500 - ERRO NO INSERT DA TITFEDCA -811' */
                        _.Display($"R3500 - ERRO NO INSERT DA TITFEDCA -811");

                        /*" -5057- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                        _.Display($"BILHETE {V0BILH_NUMBIL}");

                        /*" -5058- ELSE */
                    }
                    else
                    {


                        /*" -5059- DISPLAY 'R3500 - ERRO NO INSERT DA TITFEDCA ' */
                        _.Display($"R3500 - ERRO NO INSERT DA TITFEDCA ");

                        /*" -5060- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                        _.Display($"BILHETE {V0BILH_NUMBIL}");

                        /*" -5061- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -5062- END-IF */
                    }


                    /*" -5063- ELSE */
                }
                else
                {


                    /*" -5064- DISPLAY 'R3500 - ERRO NO INSERT DA TITFEDCA ' */
                    _.Display($"R3500 - ERRO NO INSERT DA TITFEDCA ");

                    /*" -5065- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                    _.Display($"BILHETE {V0BILH_NUMBIL}");

                    /*" -5066- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5067- END-IF */
                }


                /*" -5068- END-IF. */
            }


        }

        [StopWatch]
        /*" R3500-10-INSERT-DB-INSERT-1 */
        public void R3500_10_INSERT_DB_INSERT_1()
        {
            /*" -5049- EXEC SQL INSERT INTO SEGUROS.PARCEL_FED_CAP_VA ( NRTITFDCAP , NUM_PARCELA , VAL_CUSTO_TITULO , DTFATUR , DATA_MOVIMENTO , SITUACAO , NRMFDCAP , TIMESTAMP ) VALUES ( :MOVFEDCA-NRTITFDCAP , 0, :V1BILC-VALMAX, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, '1' , 0 , CURRENT TIMESTAMP ) END-EXEC. */

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
            /*" -5081- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5082- MOVE V1SIST-DTCURRENT TO WDATA-CURR */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -5083- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -5084- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -5086- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -5088- DISPLAY '+------------------------------------------------ '-----------------+' */
            _.Display($"+------------------------------------------------ -----------------+");

            /*" -5090- DISPLAY 'I BILHETES DE SEGUROS '                 I' */
            _.Display($"I BILHETES DE SEGUROS I");

            /*" -5092- DISPLAY 'I '                 I' */
            _.Display($"I I");

            /*" -5094- DISPLAY 'I                TOTAIS DE CONTROLE EM ' WDATA-CABEC '                   I' */

            $"I                TOTAIS DE CONTROLE EM {AREA_DE_WORK.WDATA_CABEC}                   I"
            .Display();

            /*" -5097- DISPLAY '+------------------------------------------------ '-----------------+' . */
            _.Display($"+------------------------------------------------ -----------------+");

            /*" -5099- DISPLAY 'I T A B E L A S A T U A L I Z A D A ' S               I' . */

            $"I T A B E L A S A T U A L I Z A D A SI"
            .Display();

            /*" -5101- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -5103- DISPLAY 'I NOME DA TABELA I IN 'SERT   I UPDATE  I' */

            $"I NOME DA TABELA I IN SERTIUPDATEI"
            .Display();

            /*" -5105- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -5108- DISPLAY 'I NUMERO OUTROS             (V0NUMERO_OUTS)  I  ' '     ' '   I  ' AC-U-V0NUMEROUT '  I' */

            $"I NUMERO OUTROS             (V0NUMERO_OUTS)  I          I  {AREA_DE_WORK.AC_U_V0NUMEROUT}  I"
            .Display();

            /*" -5111- DISPLAY 'I NUMERACAO GERAL           (V0NUMERO_AES)   I  ' '     ' '   I  ' AC-U-V0NUMERAES '  I' */

            $"I NUMERACAO GERAL           (V0NUMERO_AES)   I          I  {AREA_DE_WORK.AC_U_V0NUMERAES}  I"
            .Display();

            /*" -5114- DISPLAY 'I APOLICES                  (V0APOLICE)      I  ' AC-I-V0APOLICE '   I  ' AC-U-V0APOLICE '  I' */

            $"I APOLICES                  (V0APOLICE)      I  {AREA_DE_WORK.AC_I_V0APOLICE}   I  {AREA_DE_WORK.AC_U_V0APOLICE}  I"
            .Display();

            /*" -5117- DISPLAY 'I ENDOSSOS                  (V0ENDOSSO)      I  ' AC-I-V0ENDOSSO '   I  ' '     ' '  I' */

            $"I ENDOSSOS                  (V0ENDOSSO)      I  {AREA_DE_WORK.AC_I_V0ENDOSSO}   I         I"
            .Display();

            /*" -5120- DISPLAY 'I RECIBOS COB ANTECIPADA    (V0RCAP)         I  ' '     ' '   I  ' AC-U-V0RCAP '  I' */

            $"I RECIBOS COB ANTECIPADA    (V0RCAP)         I          I  {AREA_DE_WORK.AC_U_V0RCAP}  I"
            .Display();

            /*" -5123- DISPLAY 'I REC COBRANC ANTEC COMPL   (V0RCAPCOMP)     I  ' AC-I-V0RCAPCOMP '   I  ' AC-U-V0RCAPCOMP '  I' */

            $"I REC COBRANC ANTEC COMPL   (V0RCAPCOMP)     I  {AREA_DE_WORK.AC_I_V0RCAPCOMP}   I  {AREA_DE_WORK.AC_U_V0RCAPCOMP}  I"
            .Display();

            /*" -5126- DISPLAY 'I PRODUTORES                (V0PRODUTOR)     I  ' AC-I-V0PRODUTOR '   I  ' '     ' '  I' */

            $"I PRODUTORES                (V0PRODUTOR)     I  {AREA_DE_WORK.AC_I_V0PRODUTOR}   I         I"
            .Display();

            /*" -5129- DISPLAY 'I FUNCIONARIOS CEF          (V0FUNCIOCEF)    I  ' '     ' '   I  ' AC-U-V0FUNCIOCEF '  I' */

            $"I FUNCIONARIOS CEF          (V0FUNCIOCEF)    I          I  {AREA_DE_WORK.AC_U_V0FUNCIOCEF}  I"
            .Display();

            /*" -5132- DISPLAY 'I APOLICE CORRETOR          (V0APOLCORRET)   I  ' AC-I-V0APOLCORRET '   I  ' '     ' '  I' */

            $"I APOLICE CORRETOR          (V0APOLCORRET)   I  {AREA_DE_WORK.AC_I_V0APOLCORRET}   I         I"
            .Display();

            /*" -5135- DISPLAY 'I APOLICE COSSEGURO         (V0APOLCOSCED)   I  ' AC-I-V0APOLCOSCED '   I  ' '     ' '  I' */

            $"I APOLICE COSSEGURO         (V0APOLCOSCED)   I  {AREA_DE_WORK.AC_I_V0APOLCOSCED}   I         I"
            .Display();

            /*" -5138- DISPLAY 'I ORDEM DE COSSEG CEDIDO    (V0ORDECOSCED)   I  ' AC-I-V0ORDECOSCED '   I  ' '     ' '  I' */

            $"I ORDEM DE COSSEG CEDIDO    (V0ORDECOSCED)   I  {AREA_DE_WORK.AC_I_V0ORDECOSCED}   I         I"
            .Display();

            /*" -5141- DISPLAY 'I PARCELAS                  (V0PARCELAS)     I  ' AC-I-V0PARCELA '   I  ' '     ' '  I' */

            $"I PARCELAS                  (V0PARCELAS)     I  {AREA_DE_WORK.AC_I_V0PARCELA}   I         I"
            .Display();

            /*" -5144- DISPLAY 'I HISTORICO DE PARCELAS     (V0HISTOPARC)    I  ' AC-I-V0HISTOPARC '   I  ' '     ' '  I' */

            $"I HISTORICO DE PARCELAS     (V0HISTOPARC)    I  {AREA_DE_WORK.AC_I_V0HISTOPARC}   I         I"
            .Display();

            /*" -5147- DISPLAY 'I COBERTURAS DE APOLICE     (V0COBERAPOL)    I  ' AC-I-V0COBERAPOL '   I  ' '     ' '  I' */

            $"I COBERTURAS DE APOLICE     (V0COBERAPOL)    I  {AREA_DE_WORK.AC_I_V0COBERAPOL}   I         I"
            .Display();

            /*" -5150- DISPLAY 'I COMISSAO FENAE            (V0COMISSAO_FENAEI  ' '     ' '   I  ' AC-U-V0COMIFENAE '  I' */

            $"I COMISSAO FENAE            (V0COMISSAO_FENAEI          I  {AREA_DE_WORK.AC_U_V0COMIFENAE}  I"
            .Display();

            /*" -5153- DISPLAY 'I CLIENTE CROT              (V0CLIENTE_CROT  I  ' AC-I-V0CLIE-CROT '   I  ' AC-U-V0CLIE-CROT '  I' */

            $"I CLIENTE CROT              (V0CLIENTE_CROT  I  {AREA_DE_WORK.AC_I_V0CLIE_CROT}   I  {AREA_DE_WORK.AC_U_V0CLIE_CROT}  I"
            .Display();

            /*" -5156- DISPLAY 'I ADIANTAMENTOS             (V0ADIANTA)      I  ' AC-I-V0ADIANTA '   I  ' '     ' '  I' */

            $"I ADIANTAMENTOS             (V0ADIANTA)      I  {AREA_DE_WORK.AC_I_V0ADIANTA}   I         I"
            .Display();

            /*" -5158- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -5160- DISPLAY 'I QUANTIDADE DE BILHETES REJEITADOS          I  ' AC-U-V0BILHETE '   I         I' */

            $"I QUANTIDADE DE BILHETES REJEITADOS          I  {AREA_DE_WORK.AC_U_V0BILHETE}   I         I"
            .Display();

            /*" -5161- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-TOTAIS-CONTROLE-SECTION */
        private void R4100_00_TOTAIS_CONTROLE_SECTION()
        {
            /*" -5175- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5176- MOVE V1SIST-DTCURRENT TO WDATA-CURR */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -5177- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -5178- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -5180- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -5182- DISPLAY '+------------------------------------------------ '-----------------+' */
            _.Display($"+------------------------------------------------ -----------------+");

            /*" -5184- DISPLAY 'I BILHETES DE SEGUROS '                 I' */
            _.Display($"I BILHETES DE SEGUROS I");

            /*" -5186- DISPLAY 'I '                 I' */
            _.Display($"I I");

            /*" -5188- DISPLAY 'I                TOTAIS DE CONTROLE EM ' WDATA-CABEC '                   I' */

            $"I                TOTAIS DE CONTROLE EM {AREA_DE_WORK.WDATA_CABEC}                   I"
            .Display();

            /*" -5191- DISPLAY '+------------------------------------------------ '-----------------+' . */
            _.Display($"+------------------------------------------------ -----------------+");

            /*" -5193- DISPLAY 'I T A B E L A S A T U A L I Z A D A ' S               I' . */

            $"I T A B E L A S A T U A L I Z A D A SI"
            .Display();

            /*" -5195- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -5197- DISPLAY 'I NOME DA TABELA I IN 'SERT   I UPDATE  I' */

            $"I NOME DA TABELA I IN SERTIUPDATEI"
            .Display();

            /*" -5199- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -5201- DISPLAY 'I QDTE DE BILHETES QUE CONTINHAM FCAP        I  ' AC-L-FCAP '   I         I' */

            $"I QDTE DE BILHETES QUE CONTINHAM FCAP        I  {AREA_DE_WORK.AC_L_FCAP}   I         I"
            .Display();

            /*" -5203- DISPLAY 'I QDTE DE BILHETES CORRIGIDOS   FCAP         I  ' AC-I-FCAP '   I         I' */

            $"I QDTE DE BILHETES CORRIGIDOS   FCAP         I  {AREA_DE_WORK.AC_I_FCAP}   I         I"
            .Display();

            /*" -5204- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4280-00-TRATA-FC0105S-SECTION */
        private void R4280_00_TRATA_FC0105S_SECTION()
        {
            /*" -5217- MOVE '4280' TO WNR-EXEC-SQL */
            _.Move("4280", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5220- MOVE ' ' TO W-FCRCAP2 */
            _.Move(" ", W_FCRCAP2);

            /*" -5222- PERFORM R4290-00-INSERT-MOVFEDCA. */

            R4290_00_INSERT_MOVFEDCA_SECTION();

            /*" -5223- PERFORM R4400-00-INSERT-COMFEDCA. */

            R4400_00_INSERT_COMFEDCA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4280_99_SAIDA*/

        [StopWatch]
        /*" R4290-00-INSERT-MOVFEDCA-SECTION */
        private void R4290_00_INSERT_MOVFEDCA_SECTION()
        {
            /*" -5234- MOVE '4290' TO WNR-EXEC-SQL */
            _.Move("4290", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5250- INITIALIZE LK-PLANO LK-SERIE LK-TITULO LK-NUM-PROPOSTA LK-QTD-TITULOS LK-VLR-TITULO LK-PARCEIRO LK-RAMO LK-NUM-NSA LK-TRACE LK-OUT-COD-RETORNO LK-OUT-SQLCODE LK-OUT-MENSAGEM LK-OUT-SQLERRMC LK-OUT-SQLSTATE. */
            _.Initialize(
                LK_PLANO
                , LK_SERIE
                , LK_TITULO
                , LK_NUM_PROPOSTA
                , LK_QTD_TITULOS
                , LK_VLR_TITULO
                , LK_PARCEIRO
                , LK_RAMO
                , LK_NUM_NSA
                , LK_TRACE
                , LK_OUT_COD_RETORNO
                , LK_OUT_SQLCODE
                , LK_OUT_MENSAGEM
                , LK_OUT_SQLERRMC
                , LK_OUT_SQLSTATE
            );

            /*" -5253- MOVE 850 TO LK-PLANO. */
            _.Move(850, LK_PLANO);

            /*" -5255- MOVE V0BILH-NUMBIL TO LK-NUM-PROPOSTA. */
            _.Move(V0BILH_NUMBIL, LK_NUM_PROPOSTA);

            /*" -5257- MOVE 1 TO LK-QTD-TITULOS. */
            _.Move(1, LK_QTD_TITULOS);

            /*" -5260- MOVE V1BILC-VALMAX TO LK-VLR-TITULO. */
            _.Move(V1BILC_VALMAX, LK_VLR_TITULO);

            /*" -5263- PERFORM R5000-00-SELECT-EMP-CAP. */

            R5000_00_SELECT_EMP_CAP_SECTION();

            /*" -5265- MOVE PARM-COD-EMPR-CAP TO LK-PARCEIRO. */
            _.Move(PARM_COD_EMPR_CAP, LK_PARCEIRO);

            /*" -5267- MOVE V1BILP-CODPRODU TO LK-RAMO. */
            _.Move(V1BILP_CODPRODU, LK_RAMO);

            /*" -5269- MOVE 'TRACE OFF' TO LK-TRACE. */
            _.Move("TRACE OFF", LK_TRACE);

            /*" -5271- MOVE ZEROS TO LK-NUM-NSA. */
            _.Move(0, LK_NUM_NSA);

            /*" -5289- CALL 'FC0105S' USING LK-PLANO , LK-SERIE , LK-TITULO , LK-NUM-PROPOSTA , LK-QTD-TITULOS , LK-VLR-TITULO , LK-PARCEIRO , LK-RAMO , LK-NUM-NSA , LK-TRACE , LK-OUT-COD-RETORNO , LK-OUT-SQLCODE , LK-OUT-MENSAGEM , LK-OUT-SQLERRMC , LK-OUT-SQLSTATE. */
            _.Call("FC0105S", LK_PLANO, LK_SERIE, LK_TITULO, LK_NUM_PROPOSTA, LK_QTD_TITULOS, LK_VLR_TITULO, LK_PARCEIRO, LK_RAMO, LK_NUM_NSA, LK_TRACE, LK_OUT_COD_RETORNO, LK_OUT_SQLCODE, LK_OUT_MENSAGEM, LK_OUT_SQLERRMC, LK_OUT_SQLSTATE);

            /*" -5290- IF LK-OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LK_OUT_COD_RETORNO != 00)
            {

                /*" -5291- MOVE LK-OUT-SQLCODE TO WS-SQLCODE */
                _.Move(LK_OUT_SQLCODE, AREA_DE_WORK.WS_SQLCODE);

                /*" -5299- DISPLAY 'PROBLEMAS NO ACESSO A FC0105S ' ' ' LK-NUM-PROPOSTA ' ' LK-OUT-COD-RETORNO ' ' WS-SQLCODE ' ' LK-OUT-MENSAGEM ' ' LK-OUT-SQLERRMC ' ' LK-OUT-SQLSTATE */

                $"PROBLEMAS NO ACESSO A FC0105S  {LK_NUM_PROPOSTA} {LK_OUT_COD_RETORNO} {AREA_DE_WORK.WS_SQLCODE} {LK_OUT_MENSAGEM} {LK_OUT_SQLERRMC} {LK_OUT_SQLSTATE}"
                .Display();

                /*" -5300- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5300- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4290_99_SAIDA*/

        [StopWatch]
        /*" R4400-00-INSERT-COMFEDCA-SECTION */
        private void R4400_00_INSERT_COMFEDCA_SECTION()
        {
            /*" -5312- MOVE '4400' TO WNR-EXEC-SQL. */
            _.Move("4400", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5323- PERFORM R4400_00_INSERT_COMFEDCA_DB_INSERT_1 */

            R4400_00_INSERT_COMFEDCA_DB_INSERT_1();

            /*" -5326- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5327- IF W-FCRCAP EQUAL '1' */

                if (W_FCRCAP == "1")
                {

                    /*" -5329- IF WS-SQLCODE NOT EQUAL -811 OR WS-SQLCODE NOT EQUAL -803 */

                    if (AREA_DE_WORK.WS_SQLCODE != -811 || AREA_DE_WORK.WS_SQLCODE != -803)
                    {

                        /*" -5330- DISPLAY 'R4400 - ERRO NO INSERT DA COMFEDCA -811 ' */
                        _.Display($"R4400 - ERRO NO INSERT DA COMFEDCA -811 ");

                        /*" -5331- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                        _.Display($"BILHETE {V0BILH_NUMBIL}");

                        /*" -5332- ELSE */
                    }
                    else
                    {


                        /*" -5333- DISPLAY 'R4400 - ERRO NO INSERT DA COMFEDCA  ' */
                        _.Display($"R4400 - ERRO NO INSERT DA COMFEDCA  ");

                        /*" -5334- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                        _.Display($"BILHETE {V0BILH_NUMBIL}");

                        /*" -5335- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -5336- END-IF */
                    }


                    /*" -5337- ELSE */
                }
                else
                {


                    /*" -5338- DISPLAY 'R4400 - ERRO NO INSERT DA COMFEDCA  ' */
                    _.Display($"R4400 - ERRO NO INSERT DA COMFEDCA  ");

                    /*" -5339- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                    _.Display($"BILHETE {V0BILH_NUMBIL}");

                    /*" -5340- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5341- END-IF */
                }


                /*" -5341- END-IF. */
            }


        }

        [StopWatch]
        /*" R4400-00-INSERT-COMFEDCA-DB-INSERT-1 */
        public void R4400_00_INSERT_COMFEDCA_DB_INSERT_1()
        {
            /*" -5323- EXEC SQL INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO , SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ( :V0BILH-NUMBIL , '0' , :V1SIST-DTMOVABE , CURRENT TIMESTAMP ) END-EXEC. */

            var r4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 = new R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1.Execute(r4400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-SELECT-EMP-CAP-SECTION */
        private void R5000_00_SELECT_EMP_CAP_SECTION()
        {
            /*" -5364- PERFORM R5000_00_SELECT_EMP_CAP_DB_SELECT_1 */

            R5000_00_SELECT_EMP_CAP_DB_SELECT_1();

            /*" -5367- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5368- DISPLAY 'R1000-00 (ERRO - SELECT PRODUTO )...' */
                _.Display($"R1000-00 (ERRO - SELECT PRODUTO )...");

                /*" -5369- DISPLAY 'PRODUTO: ' V1BILP-CODPRODU */
                _.Display($"PRODUTO: {V1BILP_CODPRODU}");

                /*" -5369- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5000-00-SELECT-EMP-CAP-DB-SELECT-1 */
        public void R5000_00_SELECT_EMP_CAP_DB_SELECT_1()
        {
            /*" -5364- EXEC SQL SELECT PR.COD_EMPRESA , PG.COD_EMPRESA_CAP INTO :PROD-COD-EMPRESA, :PARM-COD-EMPR-CAP FROM SEGUROS.PRODUTO PR, SEGUROS.PARAMETROS_GERAIS PG WHERE PR.COD_PRODUTO = :V1BILP-CODPRODU AND PR.COD_EMPRESA = PG.COD_EMPRESA END-EXEC. */

            var r5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1 = new R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1()
            {
                V1BILP_CODPRODU = V1BILP_CODPRODU.ToString(),
            };

            var executed_1 = R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1.Execute(r5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROD_COD_EMPRESA, PROD_COD_EMPRESA);
                _.Move(executed_1.PARM_COD_EMPR_CAP, PARM_COD_EMPR_CAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R8100-00-DECLARE-CBO-SECTION */
        private void R8100_00_DECLARE_CBO_SECTION()
        {
            /*" -5382- MOVE '8100' TO WNR-EXEC-SQL. */
            _.Move("8100", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5390- PERFORM R8100_00_DECLARE_CBO_DB_DECLARE_1 */

            R8100_00_DECLARE_CBO_DB_DECLARE_1();

            /*" -5392- PERFORM R8100_00_DECLARE_CBO_DB_OPEN_1 */

            R8100_00_DECLARE_CBO_DB_OPEN_1();

            /*" -5395- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5396- DISPLAY 'R8100 - PROBLEMAS DECLARE (CBO      ) ..' */
                _.Display($"R8100 - PROBLEMAS DECLARE (CBO      ) ..");

                /*" -5397- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -5398- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8100-00-DECLARE-CBO-DB-OPEN-1 */
        public void R8100_00_DECLARE_CBO_DB_OPEN_1()
        {
            /*" -5392- EXEC SQL OPEN CCBO END-EXEC. */

            CCBO.Open();

        }

        [StopWatch]
        /*" R9100-00-DECLARE-FCAP-DB-DECLARE-1 */
        public void R9100_00_DECLARE_FCAP_DB_DECLARE_1()
        {
            /*" -5491- EXEC SQL DECLARE FCAP CURSOR FOR SELECT A.NUM_BILHETE, Y.VAL_MAX_COBER_BAS FROM SEGUROS.BILHETE A, SEGUROS.ENDOSSOS X, SEGUROS.BILHETE_COBERTURA Y WHERE X.COD_PRODUTO = 1405 AND A.NUM_APOLICE = X.NUM_APOLICE AND X.NUM_ENDOSSO = 0 AND Y.RAMO_COBERTURA = 14 AND Y.MODALI_COBERTURA = 0 AND Y.COD_OPCAO_PLANO = A.OPC_COBERTURA AND Y.PCT_COM_CORRETOR > 0 AND Y.IDE_COBERTURA = '1' AND A.NUM_BILHETE NOT IN (SELECT B.NUM_CERTIFICADO FROM SEGUROS.MOVIMEN_FED_CAP_VA B WHERE A.NUM_BILHETE = B.NUM_CERTIFICADO) ORDER BY A.NUM_BILHETE WITH UR END-EXEC. */
            FCAP = new BI6005B_FCAP(false);
            string GetQuery_FCAP()
            {
                var query = @$"SELECT A.NUM_BILHETE
							, Y.VAL_MAX_COBER_BAS 
							FROM SEGUROS.BILHETE A
							, 
							SEGUROS.ENDOSSOS X
							, 
							SEGUROS.BILHETE_COBERTURA Y 
							WHERE 
							X.COD_PRODUTO = 1405 
							AND A.NUM_APOLICE = X.NUM_APOLICE 
							AND X.NUM_ENDOSSO = 0 
							AND Y.RAMO_COBERTURA = 14 
							AND Y.MODALI_COBERTURA = 0 
							AND Y.COD_OPCAO_PLANO = A.OPC_COBERTURA 
							AND Y.PCT_COM_CORRETOR > 0 
							AND Y.IDE_COBERTURA = '1' 
							AND A.NUM_BILHETE NOT IN 
							(SELECT B.NUM_CERTIFICADO 
							FROM SEGUROS.MOVIMEN_FED_CAP_VA B 
							WHERE A.NUM_BILHETE = B.NUM_CERTIFICADO) 
							ORDER BY A.NUM_BILHETE";

                return query;
            }
            FCAP.GetQueryEvent += GetQuery_FCAP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_99_SAIDA*/

        [StopWatch]
        /*" R8110-00-FETCH-CBO-SECTION */
        private void R8110_00_FETCH_CBO_SECTION()
        {
            /*" -5407- MOVE '8110' TO WNR-EXEC-SQL. */
            _.Move("8110", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5410- PERFORM R8110_00_FETCH_CBO_DB_FETCH_1 */

            R8110_00_FETCH_CBO_DB_FETCH_1();

            /*" -5413- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5414- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5415- MOVE 'S' TO WFIM-CBO */
                    _.Move("S", AREA_DE_WORK.WFIM_CBO);

                    /*" -5415- PERFORM R8110_00_FETCH_CBO_DB_CLOSE_1 */

                    R8110_00_FETCH_CBO_DB_CLOSE_1();

                    /*" -5418- ELSE */
                }
                else
                {


                    /*" -5420- DISPLAY '8110 - (PROBLEMAS NO FETCH CCBO SQLCODE = ' SQLCODE */
                    _.Display($"8110 - (PROBLEMAS NO FETCH CCBO SQLCODE = {DB.SQLCODE}");

                    /*" -5421- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R8110-00-FETCH-CBO-DB-FETCH-1 */
        public void R8110_00_FETCH_CBO_DB_FETCH_1()
        {
            /*" -5410- EXEC SQL FETCH CCBO INTO :CBO-COD-CBO, :CBO-DESCR-CBO END-EXEC. */

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
            /*" -5415- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8110_99_SAIDA*/

        [StopWatch]
        /*" R8120-00-CARREGA-CBO-SECTION */
        private void R8120_00_CARREGA_CBO_SECTION()
        {
            /*" -5430- MOVE '8120' TO WNR-EXEC-SQL. */
            _.Move("8120", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5432- IF CBO-COD-CBO > 0 AND CBO-COD-CBO < 1000 */

            if (CBO_COD_CBO > 0 && CBO_COD_CBO < 1000)
            {

                /*" -5435- MOVE CBO-DESCR-CBO TO TAB-DESCR-CBO-C (CBO-COD-CBO) */
                _.Move(CBO_DESCR_CBO, TAB_CBO1.TAB_CBO.FILLER_0[CBO_COD_CBO].TAB_DESCR_CBO_C);

                /*" -5436- PERFORM R8110-00-FETCH-CBO */

                R8110_00_FETCH_CBO_SECTION();

                /*" -5436- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8120_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-ACERTO-FC0001-SECTION */
        private void R9000_00_ACERTO_FC0001_SECTION()
        {
            /*" -5448- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5451- DISPLAY 'BI6005B - PROCESSANDO ATUALIZACOES FED CAP...' */
            _.Display($"BI6005B - PROCESSANDO ATUALIZACOES FED CAP...");

            /*" -5453- PERFORM R9100-00-DECLARE-FCAP. */

            R9100_00_DECLARE_FCAP_SECTION();

            /*" -5455- PERFORM R9110-00-FETCH-FCAP. */

            R9110_00_FETCH_FCAP_SECTION();

            /*" -5456- IF WFIM-FCAP NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_FCAP.IsEmpty())
            {

                /*" -5458- GO TO R9000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5460- PERFORM R9120-00-CARREGA-FCAP UNTIL WFIM-FCAP EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_FCAP == "S"))
            {

                R9120_00_CARREGA_FCAP_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-DECLARE-FCAP-SECTION */
        private void R9100_00_DECLARE_FCAP_SECTION()
        {
            /*" -5471- MOVE '9100' TO WNR-EXEC-SQL. */
            _.Move("9100", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5491- PERFORM R9100_00_DECLARE_FCAP_DB_DECLARE_1 */

            R9100_00_DECLARE_FCAP_DB_DECLARE_1();

            /*" -5493- PERFORM R9100_00_DECLARE_FCAP_DB_OPEN_1 */

            R9100_00_DECLARE_FCAP_DB_OPEN_1();

            /*" -5496- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5497- DISPLAY 'R9100 - PROBLEMAS DECLARE (FCAP     ) ..' */
                _.Display($"R9100 - PROBLEMAS DECLARE (FCAP     ) ..");

                /*" -5498- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -5499- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9100-00-DECLARE-FCAP-DB-OPEN-1 */
        public void R9100_00_DECLARE_FCAP_DB_OPEN_1()
        {
            /*" -5493- EXEC SQL OPEN FCAP END-EXEC. */

            FCAP.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9110-00-FETCH-FCAP-SECTION */
        private void R9110_00_FETCH_FCAP_SECTION()
        {
            /*" -5509- MOVE '9110' TO WNR-EXEC-SQL. */
            _.Move("9110", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5512- PERFORM R9110_00_FETCH_FCAP_DB_FETCH_1 */

            R9110_00_FETCH_FCAP_DB_FETCH_1();

            /*" -5515- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5516- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5517- MOVE 'S' TO WFIM-FCAP */
                    _.Move("S", AREA_DE_WORK.WFIM_FCAP);

                    /*" -5517- PERFORM R9110_00_FETCH_FCAP_DB_CLOSE_1 */

                    R9110_00_FETCH_FCAP_DB_CLOSE_1();

                    /*" -5519- GO TO R9110-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R9110_99_SAIDA*/ //GOTO
                    return;

                    /*" -5520- ELSE */
                }
                else
                {


                    /*" -5522- DISPLAY '9110 - (PROBLEMAS NO FETCH FCAP SQLCODE = ' SQLCODE */
                    _.Display($"9110 - (PROBLEMAS NO FETCH FCAP SQLCODE = {DB.SQLCODE}");

                    /*" -5524- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5525- ADD +1 TO AC-L-FCAP. */
            AREA_DE_WORK.AC_L_FCAP.Value = AREA_DE_WORK.AC_L_FCAP + +1;

        }

        [StopWatch]
        /*" R9110-00-FETCH-FCAP-DB-FETCH-1 */
        public void R9110_00_FETCH_FCAP_DB_FETCH_1()
        {
            /*" -5512- EXEC SQL FETCH FCAP INTO :V0BILH-NUMBIL, :V1BILC-VALMAX END-EXEC. */

            if (FCAP.Fetch())
            {
                _.Move(FCAP.V0BILH_NUMBIL, V0BILH_NUMBIL);
                _.Move(FCAP.V1BILC_VALMAX, V1BILC_VALMAX);
            }

        }

        [StopWatch]
        /*" R9110-00-FETCH-FCAP-DB-CLOSE-1 */
        public void R9110_00_FETCH_FCAP_DB_CLOSE_1()
        {
            /*" -5517- EXEC SQL CLOSE FCAP END-EXEC */

            FCAP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9110_99_SAIDA*/

        [StopWatch]
        /*" R9120-00-CARREGA-FCAP-SECTION */
        private void R9120_00_CARREGA_FCAP_SECTION()
        {
            /*" -5537- MOVE '9120' TO WNR-EXEC-SQL. */
            _.Move("9120", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5540- PERFORM R4280-00-TRATA-FC0105S. */

            R4280_00_TRATA_FC0105S_SECTION();

            /*" -5541- ADD +1 TO AC-I-FCAP. */
            AREA_DE_WORK.AC_I_FCAP.Value = AREA_DE_WORK.AC_I_FCAP + +1;

            /*" -0- FLUXCONTROL_PERFORM R9120_10_LE_PROXIMO */

            R9120_10_LE_PROXIMO();

        }

        [StopWatch]
        /*" R9120-10-LE-PROXIMO */
        private void R9120_10_LE_PROXIMO(bool isPerform = false)
        {
            /*" -5544- PERFORM R9110-00-FETCH-FCAP. */

            R9110_00_FETCH_FCAP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9120_99_SAIDA*/

        [StopWatch]
        /*" R9130-00-SELECT-TITULO-SECTION */
        private void R9130_00_SELECT_TITULO_SECTION()
        {
            /*" -5556- MOVE '9100' TO WNR-EXEC-SQL. */
            _.Move("9100", FC0001S_LINKAGE.WABEND.WNR_EXEC_SQL);

            /*" -5580- PERFORM R9130_00_SELECT_TITULO_DB_SELECT_1 */

            R9130_00_SELECT_TITULO_DB_SELECT_1();

            /*" -5584- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -5585- DISPLAY 'R9130 - PROBLEMAS SELECT TITULO  ..' */
                _.Display($"R9130 - PROBLEMAS SELECT TITULO  ..");

                /*" -5586- DISPLAY ' MR.BILHETE  =' V0BILH-NUMBIL */
                _.Display($" MR.BILHETE  ={V0BILH_NUMBIL}");

                /*" -5587- DISPLAY ' FONTE-BILH  =' V0BILH-FONTE */
                _.Display($" FONTE-BILH  ={V0BILH_FONTE}");

                /*" -5588- DISPLAY ' SQLCODE     =' SQLCODE */
                _.Display($" SQLCODE     ={DB.SQLCODE}");

                /*" -5589- DISPLAY ' SQLERRMC    =' SQLERRMC */
                _.Display($" SQLERRMC    ={DB.SQLERRMC}");

                /*" -5591- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5592- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5594- MOVE 809 TO WS-NUM-PLANO */
                _.Move(809, AREA_DE_WORK.WS_NUM_TITULO_X.WS_NUM_PLANO);

                /*" -5596- MOVE FCTITULO-NUM-SERIE TO WS-NUM-SERIE */
                _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_NUM_SERIE, AREA_DE_WORK.WS_NUM_TITULO_X.WS_NUM_SERIE);

                /*" -5598- MOVE FCTITULO-NUM-TITULO TO WS-NUM-TITULO */
                _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_NUM_TITULO, AREA_DE_WORK.WS_NUM_TITULO_X.WS_NUM_TITULO);

                /*" -5600- MOVE WS-NUM-TITULO-9 TO MOVFEDCA-NRTITFDCAP */
                _.Move(AREA_DE_WORK.WS_NUM_TITULO_9, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP);

                /*" -5602- MOVE FCTITULO-DTH-INI-VIGENCIA TO FC0001S-DTH-INI-VIGENCIA */
                _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_DTH_INI_VIGENCIA, FC0001S_LINKAGE.FC0001S_DTH_INI_VIGENCIA);

                /*" -5604- MOVE FCTITULO-DTH-FIM-VIGENCIA TO FC0001S-DTH-FIM-VIGENCIA */
                _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_DTH_FIM_VIGENCIA, FC0001S_LINKAGE.FC0001S_DTH_FIM_VIGENCIA);

                /*" -5606- MOVE FCCOMTIT-DES-COMBINACAO TO FC0001S-DES-COMBINACAO */
                _.Move(FCCOMTIT.DCLFC_COMB_TITULOS.FCCOMTIT_DES_COMBINACAO, FC0001S_LINKAGE.FC0001S_DES_COMBINACAO);

                /*" -5608- END-IF. */
            }


            /*" -5609- IF V0BILH-FONTE EQUAL ZEROS */

            if (V0BILH_FONTE == 00)
            {

                /*" -5611- MOVE 5 TO V0BILH-FONTE */
                _.Move(5, V0BILH_FONTE);

                /*" -5612- END-IF. */
            }


        }

        [StopWatch]
        /*" R9130-00-SELECT-TITULO-DB-SELECT-1 */
        public void R9130_00_SELECT_TITULO_DB_SELECT_1()
        {
            /*" -5580- EXEC SQL SELECT A.NUM_PLANO ,A.NUM_SERIE ,A.NUM_TITULO ,A.IND_DV ,A.DTH_INI_VIGENCIA ,A.DTH_FIM_VIGENCIA ,B.DES_COMBINACAO INTO :FCTITULO-NUM-PLANO , :FCTITULO-NUM-SERIE , :FCTITULO-NUM-TITULO , :FCTITULO-IND-DV , :FCTITULO-DTH-INI-VIGENCIA , :FCTITULO-DTH-FIM-VIGENCIA , :FCCOMTIT-DES-COMBINACAO FROM FDRCAP.FC_TITULO A JOIN FDRCAP.FC_COMB_TITULOS B ON A.IDE_SERIEPADRAO = B.IDE_SERIEPADRAO AND A.NUM_TITULO = B.NUM_TITULO WHERE A.NUM_PROPOSTA = :V0BILH-NUMBIL AND B.NUM_COMBINACAO = 1 WITH UR END-EXEC. */

            var r9130_00_SELECT_TITULO_DB_SELECT_1_Query1 = new R9130_00_SELECT_TITULO_DB_SELECT_1_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R9130_00_SELECT_TITULO_DB_SELECT_1_Query1.Execute(r9130_00_SELECT_TITULO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FCTITULO_NUM_PLANO, FCTITULO.DCLFC_TITULO.FCTITULO_NUM_PLANO);
                _.Move(executed_1.FCTITULO_NUM_SERIE, FCTITULO.DCLFC_TITULO.FCTITULO_NUM_SERIE);
                _.Move(executed_1.FCTITULO_NUM_TITULO, FCTITULO.DCLFC_TITULO.FCTITULO_NUM_TITULO);
                _.Move(executed_1.FCTITULO_IND_DV, FCTITULO.DCLFC_TITULO.FCTITULO_IND_DV);
                _.Move(executed_1.FCTITULO_DTH_INI_VIGENCIA, FCTITULO.DCLFC_TITULO.FCTITULO_DTH_INI_VIGENCIA);
                _.Move(executed_1.FCTITULO_DTH_FIM_VIGENCIA, FCTITULO.DCLFC_TITULO.FCTITULO_DTH_FIM_VIGENCIA);
                _.Move(executed_1.FCCOMTIT_DES_COMBINACAO, FCCOMTIT.DCLFC_COMB_TITULOS.FCCOMTIT_DES_COMBINACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9130_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -5624- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, FC0001S_LINKAGE.WABEND.WSQLCODE);

            /*" -5626- DISPLAY 'SQLCODE = ' WSQLCODE */
            _.Display($"SQLCODE = {FC0001S_LINKAGE.WABEND.WSQLCODE}");

            /*" -5626- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -5628- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5632- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -5634- DISPLAY 'RETURN-CODE = ' RETURN-CODE */
            _.Display($"RETURN-CODE = {RETURN_CODE}");

            /*" -5634- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}