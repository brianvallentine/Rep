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
using Sias.Bilhetes.DB2.BI0030B;

namespace Code
{
    public class BI0030B
    {
        public bool IsCall { get; set; }

        public BI0030B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  BILHETES                           *      */
        /*"      *   PROGRAMA ...............  BI0030B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CONSEDA                            *      */
        /*"      *   PROGRAMADOR ............  CONSEDA                            *      */
        /*"      *   DATA CODIFICACAO .......  AGOSTO/1999                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  A PARTIR DA TABELA V0BILHETES COM  *      */
        /*"      *                             COM SITUACAO     = '5'             *      */
        /*"      *                             GERA A TABELA V0MOVDEBCC_CEF       *      */
        /*"      *                             A NOVA DATA DE QUITACAO SERA IGUAL *      */
        /*"      *                             A ULTIMA DATA MAIS UM ANO          *      */
        /*"      *                             ENVIAR PARA DEBITO AUTOMATICO EM   *      */
        /*"      *                             CONTA CORRENTE, TODOS OS BILHETES  *      */
        /*"      *                             COM 5 DIAS UTEIS DE ANTECEDENCIA   *      */
        /*"      *                             A DATA DE DEBITO SERA A NOVA DATA  *      */
        /*"      *                             DE QUITACAO OU A DATA UTIL ANTERIOR*      */
        /*"      *                             NO CASO DE A DATA DE QUITACAO CAIR *      */
        /*"      *                             NUM FERIADO OU FIM DE SEMANA       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.13  *   VERSAO 13  -  DEMANDA 455132                                 *      */
        /*"      *                 IMPACTOS DA CRIACAO DE CAMPOS NA TABELA        *      */
        /*"      *                 V0MOVDEBCC_CEF                                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/02/2023 - FRANK CARVALHO      PROCURE POR V.13         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 12     - DEMANDA 265732 TAREFA 999999                 *      */
        /*"      *                 - TRATAR FAIXA DE PRODUTO PARA JV1             *      */
        /*"      *   EM 24/11/2020 - HUSNI ALI HUSNI                              *      */
        /*"      *   PROCURE  POR    V.12                                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/02/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"BRSEG1*   BRSEG1 - ALTERACAO ACESSO BILHETE ANTERIOR                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 - CAD-68.235                                       *      */
        /*"      *                                                                *      */
        /*"      *             - CUSTOMIZACAO PARA O CANAL DE VENDA MAIS ESTUDO   *      */
        /*"      *               OS PROGRAMAS                                     *      */
        /*"      *                                                                *      */
        /*"      *                  . BI3600B                                     *      */
        /*"      *                  . BI3602B                                     *      */
        /*"      *                  . BI0030B                                     *      */
        /*"      *                  . BI0031B                                     *      */
        /*"      *                  . BI0422B                                     *      */
        /*"      *                  . BI0602B                                     *      */
        /*"      *                  . BI6032B                                     *      */
        /*"      *                  . BI7028B                                     *      */
        /*"      *                  . BI7029B                                     *      */
        /*"      *                                                                *      */
        /*"      *                FORAM PREPARADOS PARA TRABALHAR COM PARAMETROS  *      */
        /*"      *                DEFINIDOS NA SEGUROS.ARQUIVOS_SIVPF.                   */
        /*"      *                                                                *      */
        /*"      *   EM 14/04/2012 - TERCIO CARVALHO (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.10    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - CAD 50.292                                       *      */
        /*"      *                                                                *      */
        /*"      *              - PASSA A TRATAR ORIGEM SYSTEM CRED E CRED NEW.   *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/11/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                          PROCURE POR V.09      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - CAD 39.946                                       *      */
        /*"      *                                                                *      */
        /*"      *              - PASSA A USAR V1SIST-DTMOVABE + 10 DIAS UTEIS.   *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/03/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                          PROCURE POR V.08      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 30/01/2008 - FAST COMPUTER                        *      */
        /*"      *                                                                *      */
        /*"      *  CORRECAO DO ABEND (SQLCODE = -803) OCORRIDO NA TABELA         *      */
        /*"      *  V0MOVDEBCC_CEF                                                *      */
        /*"      *                                             PROCURE  V.07      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 18/01/2008 - FAST COMPUTER                        *      */
        /*"      *                                                                *      */
        /*"      *  PASSARA A TRATAR BILHETES ORIUNDOS DO CANAL DE VENDA MARSH    *      */
        /*"      *                                                                *      */
        /*"      *                                             PROCURE  V.06      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - CHAMA SUBROTINA GE0006S                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/02/2007 - MARCO PAIVA              PROCURE POR V.05    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04 - PASSA A NAO MAIS ABENDAR QUANDO HOUVER DOIS      *      */
        /*"      *               BILHETES COM MESMO NUMERO NA NUM_APOLICE_ANT     *      */
        /*"      *               TORNANDO A SITUACAO DO BILHETE IGUAL A '*'       *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/01/2007 - FAST COMPUTER            PROCURE POR V.04    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - PASSA A NAO PRORROGAR DATA DE BILHETES COM       *      */
        /*"      *               D-1 DA DATA BASE.                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/12/2006 - FAST COMPUTER            PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - AJUSTADO  PARA TRATAR O RANGE DE TRINTA DIAS     *      */
        /*"      *               ANTES DA DATA DE HOJE  ATE O MAXIMO DIA PARA     *      */
        /*"      *               RENOVACAO.                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/12/2006 - FAST COMPUTER            PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 11/09/2006 - FAST COMPUTER                        *      */
        /*"      *                                                                *      */
        /*"      *  PASSARA A TRATAR BILHETES ORIUNDOS DO CANAL DE VENDA GITEL    *      */
        /*"      *                                                                *      */
        /*"      *                                             PROCURE  V.01      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 25/09/2002 - VIRGINIA                             *      */
        /*"      *  PASSARA A TESTAR A SITUACAO DO BILHETE ANTERIOR,CASO ESTEJA   *      */
        /*"      *  CANCELADO NAO IRA GERAR A V0MOVDEBCC_CEF E A SITUACAO NA      *      */
        /*"      *  V0BILHETE SERA '*'.O NOVO BILHETE NAO SERA RENOVADO.          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 09/11/2000 - ENRICO (PRODEXTER)                   *      */
        /*"      *  DESPREZAR BILHETES COM C/C DE DEBITO IGUAL AO DO INDICADOR    *      */
        /*"      *         PROCURAR EB0911                                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO  .............  - ALTERACAO DA COLUNA COD_CONVENIO *      */
        /*"      *                               DE SMALLINT PARA INTEGER.        *      */
        /*"      *               LIANE PONTES  -  LP0301   EM:  14/03/2001.       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTMOVABE-30  PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTBASE       PIC  X(010).*/
        public StringBasis V1SIST_DTBASE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTINIVIG      PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTTERVIG      PIC  X(010).*/
        public StringBasis WHOST_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RELA-DATA-REFER   PIC X(010).*/
        public StringBasis V0RELA_DATA_REFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CALE-DTMOVTO            PIC  X(010).*/
        public StringBasis V0CALE_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CALE-DIASEM             PIC  X(001).*/
        public StringBasis V0CALE_DIASEM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0CALE-FERIADO            PIC  X(001).*/
        public StringBasis V0CALE_FERIADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FERI-DTMOVTO            PIC  X(010).*/
        public StringBasis V0FERI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FERI-TIPO               PIC  X(001).*/
        public StringBasis V0FERI_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FERI-SITUACAO           PIC  X(001).*/
        public StringBasis V0FERI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1BILH-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1BILH_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1BILH-NUMBIL       PIC S9(015)      VALUE +0  COMP-3*/
        public IntBasis V1BILH_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1BILH-NUMAPOL      PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V1BILH_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1BILH-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1BILH_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILH-AGECOBR      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1BILH_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILH-NUM-MATR     PIC S9(015)      VALUE +0  COMP-3*/
        public IntBasis V1BILH_NUM_MATR { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1BILH-AGENCIA      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1BILH_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILH-OPERACAO     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1BILH_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILH-NUMCTA       PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V1BILH_NUMCTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1BILH-DIGCTA       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1BILH_DIGCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILH-CODCLIEN     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1BILH_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1BILH-OCORR-ENDER  PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1BILH_OCORR_ENDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILH-NOME         PIC  X(040).*/
        public StringBasis V1BILH_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1BILH-PROFISSAO    PIC  X(020).*/
        public StringBasis V1BILH_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77         V1BILH-CGCCPF       PIC S9(015)      VALUE +0  COMP-3*/
        public IntBasis V1BILH_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1BILH-DTNASCTO     PIC  X(010).*/
        public StringBasis V1BILH_DTNASCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1BILH-IDTNASCTO    PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1BILH_IDTNASCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILH-IDE-SEXO     PIC  X(001).*/
        public StringBasis V1BILH_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1BILH-EST-CIVIL    PIC  X(001).*/
        public StringBasis V1BILH_EST_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1BILH-ENDERECO     PIC  X(040).*/
        public StringBasis V1BILH_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1BILH-BAIRRO       PIC  X(020).*/
        public StringBasis V1BILH_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77         V1BILH-CIDADE       PIC  X(020).*/
        public StringBasis V1BILH_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77         V1BILH-SIGLA-UF     PIC  X(002).*/
        public StringBasis V1BILH_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V1BILH-CEP          PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1BILH_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1BILH-DDD          PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1BILH_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILH-TELEFONE     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1BILH_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1BILH-AGENCIA-DEB  PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1BILH_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILH-OPERACAO-DEB PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1BILH_OPERACAO_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILH-NUMCTA-DEB   PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V1BILH_NUMCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1BILH-DIGCTA-DEB   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1BILH_DIGCTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILH-OPCAO-COBER  PIC S9(004)                COMP.*/
        public IntBasis V1BILH_OPCAO_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILH-DTQITBCO     PIC  X(010).*/
        public StringBasis V1BILH_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1BILH-VLRCAP       PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1BILH_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1BILH-RAMO         PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1BILH_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BILH-DATA-VENDA   PIC  X(010).*/
        public StringBasis V1BILH_DATA_VENDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1BILH-DTMOVTO       PIC  X(010).*/
        public StringBasis V1BILH_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1BILH-NUM-APOL-ANT  PIC S9(013)     VALUE +0  COMP-3*/
        public IntBasis V1BILH_NUM_APOL_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1BILH-SITUACAO      PIC  X(001).*/
        public StringBasis V1BILH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1CREN-SITUACAO      PIC  X(001).*/
        public StringBasis V1CREN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0BILH-ANT-SITUACAO  PIC  X(001).*/
        public StringBasis V0BILH_ANT_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0MOVDE-COD-EMPRESA    PIC S9(09)              COMP.*/
        public IntBasis V0MOVDE_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77         V0MOVDE-NUM-APOLICE    PIC S9(13)              COMP-3*/
        public IntBasis V0MOVDE_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77         V0MOVDE-NRENDOS        PIC S9(09)              COMP.*/
        public IntBasis V0MOVDE_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77         V0MOVDE-NRPARCEL       PIC S9(04)              COMP.*/
        public IntBasis V0MOVDE_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         V0MOVDE-SIT-COBRANCA   PIC X(1).*/
        public StringBasis V0MOVDE_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77         V0MOVDE-DTVENCTO       PIC X(10).*/
        public StringBasis V0MOVDE_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0MOVDE-VLR-DEBITO     PIC S9(13)V9(2)         COMP-3*/
        public DoubleBasis V0MOVDE_VLR_DEBITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         V0MOVDE-DTMOVTO        PIC X(10).*/
        public StringBasis V0MOVDE_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0MOVDE-TIMESTAMP      PIC X(26).*/
        public StringBasis V0MOVDE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"77         V0MOVDE-DIA-DEBITO     PIC S9(04)              COMP.*/
        public IntBasis V0MOVDE_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         V0MOVDE-COD-AGE-DEB    PIC S9(04)              COMP.*/
        public IntBasis V0MOVDE_COD_AGE_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         V0MOVDE-OPER-CTA-DEB   PIC S9(04)              COMP.*/
        public IntBasis V0MOVDE_OPER_CTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         V0MOVDE-NUM-CTA-DEB    PIC S9(13)            COMP-3.*/
        public IntBasis V0MOVDE_NUM_CTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77         V0MOVDE-DIG-CTA-DEB    PIC S9(04)              COMP.*/
        public IntBasis V0MOVDE_DIG_CTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         V0MOVDE-COD-CONVENIO   PIC S9(09)              COMP.*/
        public IntBasis V0MOVDE_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77         V0MOVDE-DTENVIO        PIC X(10).*/
        public StringBasis V0MOVDE_DTENVIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0MOVDE-DTRETORNO      PIC X(10).*/
        public StringBasis V0MOVDE_DTRETORNO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0MOVDE-COD-RET-CEF    PIC S9(04)              COMP.*/
        public IntBasis V0MOVDE_COD_RET_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         V0MOVDE-NSAS           PIC S9(04)              COMP.*/
        public IntBasis V0MOVDE_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         WDATA-BASE             PIC  X(010).*/
        public StringBasis WDATA_BASE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WDATA-BASE-4           PIC  X(010).*/
        public StringBasis WDATA_BASE_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WDATA-BASE-10          PIC  X(010).*/
        public StringBasis WDATA_BASE_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0SIVPF-SIT-PROPOSTA PIC  X(003)     VALUE    SPACES.*/
        public StringBasis V0SIVPF_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"77         V0CONV-NUM-SICOB     PIC S9(015)     VALUE +0 COMP-3.*/
        public IntBasis V0CONV_NUM_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0CONV-NUM-PROPOSTA-SIVPF PIC S9(015) VALUE +0 COMP-3*/
        public IntBasis V0CONV_NUM_PROPOSTA_SIVPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0CONV-ORIGEM-PROPOSTA    PIC S9(004) VALUE +0 COMP.*/
        public IntBasis V0CONV_ORIGEM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  W-TAB-SISTEMA-ORIGEM.*/
        public BI0030B_W_TAB_SISTEMA_ORIGEM W_TAB_SISTEMA_ORIGEM { get; set; } = new BI0030B_W_TAB_SISTEMA_ORIGEM();
        public class BI0030B_W_TAB_SISTEMA_ORIGEM : VarBasis
        {
            /*"    05  WTAB-SISTEMA-ORIGEM   OCCURS    200  TIMES                                PIC  S9(004) COMP.*/
            public ListBasis<IntBasis, Int64> WTAB_SISTEMA_ORIGEM { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 200);
            /*"01              AREA-DE-WORK.*/
        }
        public BI0030B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new BI0030B_AREA_DE_WORK();
        public class BI0030B_AREA_DE_WORK : VarBasis
        {
            /*"  05   WIND                         PIC S9(004) COMP VALUE +0.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05   WIND1                        PIC S9(004) COMP VALUE +0.*/
            public IntBasis WIND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05   WINF                         PIC S9(004) COMP VALUE +0.*/
            public IntBasis WINF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05   WSUP                         PIC S9(004) COMP VALUE +0.*/
            public IntBasis WSUP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05   WTEM-SISTEMA-ORIGEM          PIC  X(003) VALUE SPACES.*/
            public StringBasis WTEM_SISTEMA_ORIGEM { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  W-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  05  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_BI0030B_CANAL _canal { get; set; }
            public _REDEF_BI0030B_CANAL CANAL
            {
                get { _canal = new _REDEF_BI0030B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_BI0030B_CANAL : VarBasis
            {
                /*"      07  W-CANAL-PROPOSTA          PIC 9(001).*/

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
							/*" 88 CANAL-VENDA-CORREIO                  VALUE 4. */
							new SelectorItemBasis("CANAL_VENDA_CORREIO", "4"),
							/*" 88 CANAL-VENDA-GITEL                    VALUE 5. */
							new SelectorItemBasis("CANAL_VENDA_GITEL", "5"),
							/*" 88 CANAL-VENDA-INTERNET                 VALUE 7. */
							new SelectorItemBasis("CANAL_VENDA_INTERNET", "7"),
							/*" 88 CANAL-VENDA-INTRANET                 VALUE 8. */
							new SelectorItemBasis("CANAL_VENDA_INTRANET", "8")
                }
                };

                /*"      07  FILLER                    PIC 9(013).*/
                public IntBasis FILLER_0 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"  05            WACC-LIDOS        PIC  9(009)   VALUE   ZEROS.*/

                public _REDEF_BI0030B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WACC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05            WACC-GRAVADOS     PIC  9(009)   VALUE   ZEROS.*/
            public IntBasis WACC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05            WACC-DISPLAY      PIC  9(009)   VALUE   ZEROS.*/
            public IntBasis WACC_DISPLAY { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05            WSL-SQLCODE    PIC  9(009)      VALUE   ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05            WFIM-V1BILHETE      PIC  X(001)   VALUE   SPACES*/
            public StringBasis WFIM_V1BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            WFIM-CALENDARIO     PIC  X(001)   VALUE  'N'.*/
            public StringBasis WFIM_CALENDARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  05            WTEM-FERIADO        PIC  X(001)   VALUE  'N'.*/
            public StringBasis WTEM_FERIADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  05            WFIM-SISTEMA-ORIGEM PIC  X(003)   VALUE SPACES.*/
            public StringBasis WFIM_SISTEMA_ORIGEM { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05            WDATA-SQL            PIC   X(010).*/
            public StringBasis WDATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05            FILLER               REDEFINES         WDATA-SQL*/
            private _REDEF_BI0030B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI0030B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI0030B_FILLER_1(); _.Move(WDATA_SQL, _filler_1); VarBasis.RedefinePassValue(WDATA_SQL, _filler_1, WDATA_SQL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_SQL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_SQL); }
            }  //Redefines
            public class _REDEF_BI0030B_FILLER_1 : VarBasis
            {
                /*"     10         WANO-SQL             PIC   9(004).*/
                public IntBasis WANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10         FILLER               PIC   X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10         WMES-SQL             PIC   9(002).*/
                public IntBasis WMES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10         FILLER               PIC   X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10         WDIA-SQL             PIC   9(002).*/
                public IntBasis WDIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05            WS-TIME.*/

                public _REDEF_BI0030B_FILLER_1()
                {
                    WANO_SQL.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WMES_SQL.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public BI0030B_WS_TIME WS_TIME { get; set; } = new BI0030B_WS_TIME();
            public class BI0030B_WS_TIME : VarBasis
            {
                /*"    10          WS-HH-TIME     PIC  9(002)      VALUE    ZEROS.*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          WS-MM-TIME     PIC  9(002)      VALUE    ZEROS.*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          WS-SS-TIME     PIC  9(002)      VALUE    ZEROS.*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          WS-CC-TIME     PIC  9(002)      VALUE    ZEROS.*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05            LPARM2.*/
            }
            public BI0030B_LPARM2 LPARM2 { get; set; } = new BI0030B_LPARM2();
            public class BI0030B_LPARM2 : VarBasis
            {
                /*"    10          DATA2.*/
                public BI0030B_DATA2 DATA2 { get; set; } = new BI0030B_DATA2();
                public class BI0030B_DATA2 : VarBasis
                {
                    /*"      15        DATA2-DD       PIC  9(002).*/
                    public IntBasis DATA2_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15        DATA2-MM       PIC  9(002).*/
                    public IntBasis DATA2_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15        DATA2-AA       PIC  9(004).*/
                    public IntBasis DATA2_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10          QUANTIDA       PIC S9(005)                COMP-3*/
                }
                public IntBasis QUANTIDA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    10          DATA3.*/
                public BI0030B_DATA3 DATA3 { get; set; } = new BI0030B_DATA3();
                public class BI0030B_DATA3 : VarBasis
                {
                    /*"      15        DATA3-DD       PIC  9(002).*/
                    public IntBasis DATA3_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15        DATA3-MM       PIC  9(002).*/
                    public IntBasis DATA3_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15        DATA3-AA       PIC  9(004).*/
                    public IntBasis DATA3_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"  05            WABEND.*/
                }
            }
            public BI0030B_WABEND WABEND { get; set; } = new BI0030B_WABEND();
            public class BI0030B_WABEND : VarBasis
            {
                /*"    10          FILLER         PIC  X(008)      VALUE               'BI0030B '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"BI0030B ");
                /*"    10          FILLER         PIC  X(025)      VALUE               '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10          WNR-EXEC-SQL   PIC  X(004)      VALUE   '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10          FILLER         PIC  X(013)      VALUE               ' *** SQLCODE '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10          WSQLCODE       PIC  ZZZZZ999-   VALUE    ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01  WREA88.*/
            }
        }
        public BI0030B_WREA88 WREA88 { get; set; } = new BI0030B_WREA88();
        public class BI0030B_WREA88 : VarBasis
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
							/*" 88 ORIGEM-AIC                               VALUE 1000. */
							new SelectorItemBasis("ORIGEM_AIC", "1000"),
							/*" 88 ORIGEM-SYSTEMCRED                        VALUE 1001. */
							new SelectorItemBasis("ORIGEM_SYSTEMCRED", "1001"),
							/*" 88 ORIGEM-CREDNEW                           VALUE 1002. */
							new SelectorItemBasis("ORIGEM_CREDNEW", "1002")
                }
            };

            /*"01           GE0006S-LINKAGE.*/
        }
        public BI0030B_GE0006S_LINKAGE GE0006S_LINKAGE { get; set; } = new BI0030B_GE0006S_LINKAGE();
        public class BI0030B_GE0006S_LINKAGE : VarBasis
        {
            /*"  05         GE0006S-DATA-DESTINO    PIC  X(010).*/
            public StringBasis GE0006S_DATA_DESTINO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         GE0006S-QTDDIAS         PIC  9(004).*/
            public IntBasis GE0006S_QTDDIAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         GE0006S-MENSAGEM        PIC  X(070).*/
            public StringBasis GE0006S_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        }


        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public BI0030B_CORIGEM CORIGEM { get; set; } = new BI0030B_CORIGEM();
        public BI0030B_V1BILHETE V1BILHETE { get; set; } = new BI0030B_V1BILHETE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -452- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -453- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -456- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -459- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -459- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -467- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -468- DISPLAY 'PROGRAMA EM EXECUCAO BI0030B  ' */
            _.Display($"PROGRAMA EM EXECUCAO BI0030B  ");

            /*" -469- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -474- DISPLAY 'VERSAO V.13 455132 24/02/2023 ' */
            _.Display($"VERSAO V.13 455132 24/02/2023 ");

            /*" -475- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -477- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -478- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -479- PERFORM R0300-00-SELECT-V0RELATORIOS */

            R0300_00_SELECT_V0RELATORIOS_SECTION();

            /*" -481- PERFORM R0200-00-CARREGA-ORIGEM. */

            R0200_00_CARREGA_ORIGEM_SECTION();

            /*" -482- PERFORM R0400-00-DECLARE-V1BILHETE */

            R0400_00_DECLARE_V1BILHETE_SECTION();

            /*" -484- PERFORM R0500-00-FETCH-V1BILHETE */

            R0500_00_FETCH_V1BILHETE_SECTION();

            /*" -485- IF WFIM-V1BILHETE NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1BILHETE.IsEmpty())
            {

                /*" -486- DISPLAY '*-----------------------------------------------*' */
                _.Display($"*-----------------------------------------------*");

                /*" -487- DISPLAY '* NAO HOUVE MOVIMENTO NESTA DATA: ' WDATA-BASE */
                _.Display($"* NAO HOUVE MOVIMENTO NESTA DATA: {WDATA_BASE}");

                /*" -488- DISPLAY '*-----------------------------------------------*' */
                _.Display($"*-----------------------------------------------*");

                /*" -490- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -493- PERFORM R1000-00-PROCESSA-BILHETE UNTIL WFIM-V1BILHETE NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1BILHETE.IsEmpty()))
            {

                R1000_00_PROCESSA_BILHETE_SECTION();
            }

            /*" -493- PERFORM R2000-00-UPDATE-V0RELATORIOS. */

            R2000_00_UPDATE_V0RELATORIOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -498- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -499- DISPLAY 'BI0030B - FIM NORMAL' */
            _.Display($"BI0030B - FIM NORMAL");

            /*" -500- DISPLAY 'LIDOS............... ' WACC-LIDOS */
            _.Display($"LIDOS............... {AREA_DE_WORK.WACC_LIDOS}");

            /*" -502- DISPLAY 'GRAVADOS............ ' WACC-GRAVADOS */
            _.Display($"GRAVADOS............ {AREA_DE_WORK.WACC_GRAVADOS}");

            /*" -502- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -504- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -516- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -524- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -527- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -528- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -529- DISPLAY 'BI0030B - SISTEMA CB NAO CADASTRADO' */
                    _.Display($"BI0030B - SISTEMA CB NAO CADASTRADO");

                    /*" -530- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -531- ELSE */
                }
                else
                {


                    /*" -532- DISPLAY 'PROBLEMA SELECT V1SISTEMA' */
                    _.Display($"PROBLEMA SELECT V1SISTEMA");

                    /*" -534- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -535- DISPLAY 'V1SIST-DTMOVABE ' V1SIST-DTMOVABE. */
            _.Display($"V1SIST-DTMOVABE {V1SIST_DTMOVABE}");

            /*" -536- MOVE V1SIST-DTMOVABE TO WDATA-SQL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_SQL);

            /*" -537- MOVE 4 TO GE0006S-QTDDIAS */
            _.Move(4, GE0006S_LINKAGE.GE0006S_QTDDIAS);

            /*" -542- PERFORM R2502-00-VALIDA-DATA */

            R2502_00_VALIDA_DATA_SECTION();

            /*" -543- MOVE WDATA-SQL TO WDATA-BASE-4. */
            _.Move(AREA_DE_WORK.WDATA_SQL, WDATA_BASE_4);

            /*" -545- DISPLAY 'DATA-BASE-4 ' WDATA-BASE-4. */
            _.Display($"DATA-BASE-4 {WDATA_BASE_4}");

            /*" -546- MOVE V1SIST-DTMOVABE TO WDATA-SQL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_SQL);

            /*" -547- MOVE 5 TO GE0006S-QTDDIAS */
            _.Move(5, GE0006S_LINKAGE.GE0006S_QTDDIAS);

            /*" -552- PERFORM R2502-00-VALIDA-DATA */

            R2502_00_VALIDA_DATA_SECTION();

            /*" -555- MOVE WDATA-SQL TO WDATA-BASE. */
            _.Move(AREA_DE_WORK.WDATA_SQL, WDATA_BASE);

            /*" -556- MOVE V1SIST-DTMOVABE TO WDATA-SQL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_SQL);

            /*" -557- MOVE 10 TO GE0006S-QTDDIAS */
            _.Move(10, GE0006S_LINKAGE.GE0006S_QTDDIAS);

            /*" -558- PERFORM R2502-00-VALIDA-DATA */

            R2502_00_VALIDA_DATA_SECTION();

            /*" -559- MOVE WDATA-SQL TO WDATA-BASE-10 */
            _.Move(AREA_DE_WORK.WDATA_SQL, WDATA_BASE_10);

            /*" -559- DISPLAY 'DATA-BASE ' WDATA-BASE. */
            _.Display($"DATA-BASE {WDATA_BASE}");

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -524- EXEC SQL SELECT DTMOVABE , DTMOVABE - 30 DAYS INTO :V1SIST-DTMOVABE , :V1SIST-DTMOVABE-30 FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTMOVABE_30, V1SIST_DTMOVABE_30);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-SECTION */
        private void R0200_00_CARREGA_ORIGEM_SECTION()
        {
            /*" -571- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -577- PERFORM R0200_00_CARREGA_ORIGEM_DB_DECLARE_1 */

            R0200_00_CARREGA_ORIGEM_DB_DECLARE_1();

            /*" -579- PERFORM R0200_00_CARREGA_ORIGEM_DB_OPEN_1 */

            R0200_00_CARREGA_ORIGEM_DB_OPEN_1();

            /*" -582- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -583- DISPLAY 'PROBLEMAS NO OPEN CORIGEM ' */
                _.Display($"PROBLEMAS NO OPEN CORIGEM ");

                /*" -585- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -587- MOVE '0201' TO WNR-EXEC-SQL. */
            _.Move("0201", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -588- PERFORM UNTIL WFIM-SISTEMA-ORIGEM EQUAL 'SIM' */

            while (!(AREA_DE_WORK.WFIM_SISTEMA_ORIGEM == "SIM"))
            {

                /*" -590- PERFORM R0200_00_CARREGA_ORIGEM_DB_FETCH_1 */

                R0200_00_CARREGA_ORIGEM_DB_FETCH_1();

                /*" -592- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -593- ADD 1 TO WIND1 */
                    AREA_DE_WORK.WIND1.Value = AREA_DE_WORK.WIND1 + 1;

                    /*" -595- MOVE ARQSIVPF-SISTEMA-ORIGEM TO WTAB-SISTEMA-ORIGEM (WIND1) */
                    _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM, W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[AREA_DE_WORK.WIND1]);

                    /*" -596- ELSE */
                }
                else
                {


                    /*" -597- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -598- MOVE 'SIM' TO WFIM-SISTEMA-ORIGEM */
                        _.Move("SIM", AREA_DE_WORK.WFIM_SISTEMA_ORIGEM);

                        /*" -598- PERFORM R0200_00_CARREGA_ORIGEM_DB_CLOSE_1 */

                        R0200_00_CARREGA_ORIGEM_DB_CLOSE_1();

                        /*" -600- ELSE */
                    }
                    else
                    {


                        /*" -601- DISPLAY 'PROBLEMAS NO FETCH CORIGEM ' */
                        _.Display($"PROBLEMAS NO FETCH CORIGEM ");

                        /*" -602- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -603- END-IF */
                    }


                    /*" -604- END-IF */
                }


                /*" -604- END-PERFORM. */
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-DECLARE-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_DECLARE_1()
        {
            /*" -577- EXEC SQL DECLARE CORIGEM CURSOR FOR SELECT SISTEMA_ORIGEM FROM SEGUROS.ARQUIVOS_SIVPF WHERE DATA_GERACAO = '9999-12-31' AND QTDE_REG_GER = 981 ORDER BY SISTEMA_ORIGEM END-EXEC. */
            CORIGEM = new BI0030B_CORIGEM(false);
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
            /*" -579- EXEC SQL OPEN CORIGEM END-EXEC. */

            CORIGEM.Open();

        }

        [StopWatch]
        /*" R0400-00-DECLARE-V1BILHETE-DB-DECLARE-1 */
        public void R0400_00_DECLARE_V1BILHETE_DB_DECLARE_1()
        {
            /*" -689- EXEC SQL DECLARE V1BILHETE CURSOR FOR SELECT NUMBIL , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB, NUM_CONTA_DEB , DIG_CONTA_DEB , DTQITBCO , VLRCAP , NUM_APOL_ANTERIOR , RAMO , SITUACAO FROM SEGUROS.V0BILHETE WHERE DTQITBCO >= :V1SIST-DTMOVABE-30 AND DTQITBCO <= :WDATA-BASE-10 AND NUMBIL <> 82590670780 AND SITUACAO = '5' END-EXEC. */
            V1BILHETE = new BI0030B_V1BILHETE(true);
            string GetQuery_V1BILHETE()
            {
                var query = @$"SELECT NUMBIL
							, 
							COD_AGENCIA
							, 
							OPERACAO_CONTA
							, 
							NUM_CONTA
							, 
							DIG_CONTA
							, 
							COD_AGENCIA_DEB
							, 
							OPERACAO_CONTA_DEB
							, 
							NUM_CONTA_DEB
							, 
							DIG_CONTA_DEB
							, 
							DTQITBCO
							, 
							VLRCAP
							, 
							NUM_APOL_ANTERIOR
							, 
							RAMO
							, 
							SITUACAO 
							FROM SEGUROS.V0BILHETE 
							WHERE DTQITBCO >= '{V1SIST_DTMOVABE_30}' 
							AND DTQITBCO <= '{WDATA_BASE_10}' 
							AND NUMBIL <> 82590670780 
							AND SITUACAO = '5'";

                return query;
            }
            V1BILHETE.GetQueryEvent += GetQuery_V1BILHETE;

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-FETCH-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_FETCH_1()
        {
            /*" -590- EXEC SQL FETCH CORIGEM INTO :ARQSIVPF-SISTEMA-ORIGEM END-EXEC */

            if (CORIGEM.Fetch())
            {
                _.Move(CORIGEM.ARQSIVPF_SISTEMA_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-CLOSE-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_CLOSE_1()
        {
            /*" -598- EXEC SQL CLOSE CORIGEM END-EXEC */

            CORIGEM.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-PROX-ANT-DATA-UTIL-SECTION */
        private void R0200_00_PROX_ANT_DATA_UTIL_SECTION()
        {
            /*" -616- MOVE '0200' TO WNR-EXEC-SQL */
            _.Move("0200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -617- MOVE WDIA-SQL TO DATA2-DD */
            _.Move(AREA_DE_WORK.FILLER_1.WDIA_SQL, AREA_DE_WORK.LPARM2.DATA2.DATA2_DD);

            /*" -618- MOVE WMES-SQL TO DATA2-MM */
            _.Move(AREA_DE_WORK.FILLER_1.WMES_SQL, AREA_DE_WORK.LPARM2.DATA2.DATA2_MM);

            /*" -619- MOVE WANO-SQL TO DATA2-AA */
            _.Move(AREA_DE_WORK.FILLER_1.WANO_SQL, AREA_DE_WORK.LPARM2.DATA2.DATA2_AA);

            /*" -620- MOVE ZEROS TO DATA3-DD */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA3.DATA3_DD);

            /*" -621- MOVE ZEROS TO DATA3-MM */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA3.DATA3_MM);

            /*" -623- MOVE ZEROS TO DATA3-AA */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA3.DATA3_AA);

            /*" -625- CALL 'PROSOCU1' USING LPARM2. */
            _.Call("PROSOCU1", AREA_DE_WORK.LPARM2);

            /*" -626- MOVE DATA3-DD TO WDIA-SQL */
            _.Move(AREA_DE_WORK.LPARM2.DATA3.DATA3_DD, AREA_DE_WORK.FILLER_1.WDIA_SQL);

            /*" -627- MOVE DATA3-MM TO WMES-SQL */
            _.Move(AREA_DE_WORK.LPARM2.DATA3.DATA3_MM, AREA_DE_WORK.FILLER_1.WMES_SQL);

            /*" -627- MOVE DATA3-AA TO WANO-SQL. */
            _.Move(AREA_DE_WORK.LPARM2.DATA3.DATA3_AA, AREA_DE_WORK.FILLER_1.WANO_SQL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-SELECT-V0RELATORIOS-SECTION */
        private void R0300_00_SELECT_V0RELATORIOS_SECTION()
        {
            /*" -639- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -645- PERFORM R0300_00_SELECT_V0RELATORIOS_DB_SELECT_1 */

            R0300_00_SELECT_V0RELATORIOS_DB_SELECT_1();

            /*" -648- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -650- DISPLAY 'R0300 - PROBLEMA SELECT V0RELATORIOS ' 'CODRELAT     - BI0030B1' V0RELA-DATA-REFER */

                $"R0300 - PROBLEMA SELECT V0RELATORIOS CODRELAT     - BI0030B1{V0RELA_DATA_REFER}"
                .Display();

                /*" -651- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -652- ELSE */
            }
            else
            {


                /*" -653- DISPLAY 'R0300 - RENOVACAO A PARTIR DE ' V0RELA-DATA-REFER. */
                _.Display($"R0300 - RENOVACAO A PARTIR DE {V0RELA_DATA_REFER}");
            }


        }

        [StopWatch]
        /*" R0300-00-SELECT-V0RELATORIOS-DB-SELECT-1 */
        public void R0300_00_SELECT_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -645- EXEC SQL SELECT DATA_REFERENCIA INTO :V0RELA-DATA-REFER FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'BI0030B1' AND SITUACAO = '0' END-EXEC. */

            var r0300_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 = new R0300_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0300_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1.Execute(r0300_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_DATA_REFER, V0RELA_DATA_REFER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-DECLARE-V1BILHETE-SECTION */
        private void R0400_00_DECLARE_V1BILHETE_SECTION()
        {
            /*" -665- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -689- PERFORM R0400_00_DECLARE_V1BILHETE_DB_DECLARE_1 */

            R0400_00_DECLARE_V1BILHETE_DB_DECLARE_1();

            /*" -691- PERFORM R0400_00_DECLARE_V1BILHETE_DB_OPEN_1 */

            R0400_00_DECLARE_V1BILHETE_DB_OPEN_1();

            /*" -694- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -695- DISPLAY 'PROBLEMAS NO OPEN (V1BILHETE)... ' */
                _.Display($"PROBLEMAS NO OPEN (V1BILHETE)... ");

                /*" -695- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0400-00-DECLARE-V1BILHETE-DB-OPEN-1 */
        public void R0400_00_DECLARE_V1BILHETE_DB_OPEN_1()
        {
            /*" -691- EXEC SQL OPEN V1BILHETE END-EXEC. */

            V1BILHETE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-FETCH-V1BILHETE-SECTION */
        private void R0500_00_FETCH_V1BILHETE_SECTION()
        {
            /*" -705- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0500_10_LE */

            R0500_10_LE();

        }

        [StopWatch]
        /*" R0500-10-LE */
        private void R0500_10_LE(bool isPerform = false)
        {
            /*" -725- PERFORM R0500_10_LE_DB_FETCH_1 */

            R0500_10_LE_DB_FETCH_1();

            /*" -729- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -730- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -730- PERFORM R0500_10_LE_DB_CLOSE_1 */

                    R0500_10_LE_DB_CLOSE_1();

                    /*" -732- MOVE 'S' TO WFIM-V1BILHETE */
                    _.Move("S", AREA_DE_WORK.WFIM_V1BILHETE);

                    /*" -733- GO TO R0500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                    return;

                    /*" -734- ELSE */
                }
                else
                {


                    /*" -735- DISPLAY 'R0500-00 (ERRO -  FETCH V1BILHETE).. ' */
                    _.Display($"R0500-00 (ERRO -  FETCH V1BILHETE).. ");

                    /*" -737- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -740- ADD 1 TO WACC-LIDOS WACC-DISPLAY. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;
            AREA_DE_WORK.WACC_DISPLAY.Value = AREA_DE_WORK.WACC_DISPLAY + 1;

            /*" -741- IF WACC-DISPLAY EQUAL 500 */

            if (AREA_DE_WORK.WACC_DISPLAY == 500)
            {

                /*" -742- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

                /*" -743- DISPLAY 'TOTAL LIDO.....' WACC-LIDOS ' ' WS-TIME */

                $"TOTAL LIDO.....{AREA_DE_WORK.WACC_LIDOS} {AREA_DE_WORK.WS_TIME}"
                .Display();

                /*" -743- MOVE ZEROS TO WACC-DISPLAY. */
                _.Move(0, AREA_DE_WORK.WACC_DISPLAY);
            }


        }

        [StopWatch]
        /*" R0500-10-LE-DB-FETCH-1 */
        public void R0500_10_LE_DB_FETCH_1()
        {
            /*" -725- EXEC SQL FETCH V1BILHETE INTO :V1BILH-NUMBIL , :V1BILH-AGENCIA , :V1BILH-OPERACAO , :V1BILH-NUMCTA , :V1BILH-DIGCTA , :V1BILH-AGENCIA-DEB , :V1BILH-OPERACAO-DEB , :V1BILH-NUMCTA-DEB , :V1BILH-DIGCTA-DEB , :V1BILH-DTQITBCO , :V1BILH-VLRCAP , :V1BILH-NUM-APOL-ANT , :V1BILH-RAMO , :V1BILH-SITUACAO END-EXEC. */

            if (V1BILHETE.Fetch())
            {
                _.Move(V1BILHETE.V1BILH_NUMBIL, V1BILH_NUMBIL);
                _.Move(V1BILHETE.V1BILH_AGENCIA, V1BILH_AGENCIA);
                _.Move(V1BILHETE.V1BILH_OPERACAO, V1BILH_OPERACAO);
                _.Move(V1BILHETE.V1BILH_NUMCTA, V1BILH_NUMCTA);
                _.Move(V1BILHETE.V1BILH_DIGCTA, V1BILH_DIGCTA);
                _.Move(V1BILHETE.V1BILH_AGENCIA_DEB, V1BILH_AGENCIA_DEB);
                _.Move(V1BILHETE.V1BILH_OPERACAO_DEB, V1BILH_OPERACAO_DEB);
                _.Move(V1BILHETE.V1BILH_NUMCTA_DEB, V1BILH_NUMCTA_DEB);
                _.Move(V1BILHETE.V1BILH_DIGCTA_DEB, V1BILH_DIGCTA_DEB);
                _.Move(V1BILHETE.V1BILH_DTQITBCO, V1BILH_DTQITBCO);
                _.Move(V1BILHETE.V1BILH_VLRCAP, V1BILH_VLRCAP);
                _.Move(V1BILHETE.V1BILH_NUM_APOL_ANT, V1BILH_NUM_APOL_ANT);
                _.Move(V1BILHETE.V1BILH_RAMO, V1BILH_RAMO);
                _.Move(V1BILHETE.V1BILH_SITUACAO, V1BILH_SITUACAO);
            }

        }

        [StopWatch]
        /*" R0500-10-LE-DB-CLOSE-1 */
        public void R0500_10_LE_DB_CLOSE_1()
        {
            /*" -730- EXEC SQL CLOSE V1BILHETE END-EXEC */

            V1BILHETE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-BILHETE-SECTION */
        private void R1000_00_PROCESSA_BILHETE_SECTION()
        {
            /*" -764- PERFORM R1050-00-SELECT-CONVERSI. */

            R1050_00_SELECT_CONVERSI_SECTION();

            /*" -765- PERFORM R1060-00-SELECT-FIDELIZ. */

            R1060_00_SELECT_FIDELIZ_SECTION();

            /*" -767- PERFORM R1010-00-VERIFICA-ORIGEM */

            R1010_00_VERIFICA_ORIGEM_SECTION();

            /*" -772- IF ORIGEM-MARSH OR CANAL-VENDA-GITEL OR WTEM-SISTEMA-ORIGEM EQUAL 'SIM' */

            if (WREA88.W_ORIGEM_PROPOSTA["ORIGEM_MARSH"] || AREA_DE_WORK.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_GITEL"] || AREA_DE_WORK.WTEM_SISTEMA_ORIGEM == "SIM")
            {

                /*" -773- PERFORM R1200-00-MONTA-V0MOVDEBCC-CEF */

                R1200_00_MONTA_V0MOVDEBCC_CEF_SECTION();

                /*" -774- PERFORM R1500-00-GRAVA-V0MOVDEBCC-CEF */

                R1500_00_GRAVA_V0MOVDEBCC_CEF_SECTION();

                /*" -776- GO TO R1000-10-LEITURA. */

                R1000_10_LEITURA(); //GOTO
                return;
            }


            /*" -778- PERFORM R1100-00-SELECT-CONT-REN-BIL */

            R1100_00_SELECT_CONT_REN_BIL_SECTION();

            /*" -779- IF V1CREN-SITUACAO EQUAL '0' OR 'F' */

            if (V1CREN_SITUACAO.In("0", "F"))
            {

                /*" -780- GO TO R1000-10-LEITURA */

                R1000_10_LEITURA(); //GOTO
                return;

                /*" -781- ELSE */
            }
            else
            {


                /*" -782- PERFORM R1150-00-SELECT-BILHETE-ANT */

                R1150_00_SELECT_BILHETE_ANT_SECTION();

                /*" -784- IF V0BILH-ANT-SITUACAO EQUAL '8' OR SQLCODE EQUAL -811 */

                if (V0BILH_ANT_SITUACAO == "8" || DB.SQLCODE == -811)
                {

                    /*" -785- PERFORM R2500-00-UPDATE-V0BILHETE */

                    R2500_00_UPDATE_V0BILHETE_SECTION();

                    /*" -786- GO TO R1000-10-LEITURA */

                    R1000_10_LEITURA(); //GOTO
                    return;

                    /*" -787- ELSE */
                }
                else
                {


                    /*" -788- PERFORM R1200-00-MONTA-V0MOVDEBCC-CEF */

                    R1200_00_MONTA_V0MOVDEBCC_CEF_SECTION();

                    /*" -788- PERFORM R1500-00-GRAVA-V0MOVDEBCC-CEF. */

                    R1500_00_GRAVA_V0MOVDEBCC_CEF_SECTION();
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R1000_10_LEITURA */

            R1000_10_LEITURA();

        }

        [StopWatch]
        /*" R1000-10-LEITURA */
        private void R1000_10_LEITURA(bool isPerform = false)
        {
            /*" -792- PERFORM R0500-00-FETCH-V1BILHETE. */

            R0500_00_FETCH_V1BILHETE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-VERIFICA-ORIGEM-SECTION */
        private void R1010_00_VERIFICA_ORIGEM_SECTION()
        {
            /*" -806- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -807- MOVE 1 TO WINF. */
            _.Move(1, AREA_DE_WORK.WINF);

            /*" -808- MOVE WIND1 TO WSUP. */
            _.Move(AREA_DE_WORK.WIND1, AREA_DE_WORK.WSUP);

            /*" -810- MOVE SPACES TO WTEM-SISTEMA-ORIGEM */
            _.Move("", AREA_DE_WORK.WTEM_SISTEMA_ORIGEM);

            /*" -811- PERFORM UNTIL WTEM-SISTEMA-ORIGEM NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WTEM_SISTEMA_ORIGEM.IsEmpty()))
            {

                /*" -812- IF WINF > WSUP */

                if (AREA_DE_WORK.WINF > AREA_DE_WORK.WSUP)
                {

                    /*" -813- MOVE 'NAO' TO WTEM-SISTEMA-ORIGEM */
                    _.Move("NAO", AREA_DE_WORK.WTEM_SISTEMA_ORIGEM);

                    /*" -814- ELSE */
                }
                else
                {


                    /*" -815- COMPUTE WIND = (WSUP + WINF) / 2 */
                    AREA_DE_WORK.WIND.Value = (AREA_DE_WORK.WSUP + AREA_DE_WORK.WINF) / 2;

                    /*" -817- IF V0CONV-ORIGEM-PROPOSTA < WTAB-SISTEMA-ORIGEM(WIND) */

                    if (V0CONV_ORIGEM_PROPOSTA < W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[AREA_DE_WORK.WIND])
                    {

                        /*" -818- COMPUTE WSUP = WIND - 1 */
                        AREA_DE_WORK.WSUP.Value = AREA_DE_WORK.WIND - 1;

                        /*" -819- ELSE */
                    }
                    else
                    {


                        /*" -821- IF V0CONV-ORIGEM-PROPOSTA > WTAB-SISTEMA-ORIGEM(WIND) */

                        if (V0CONV_ORIGEM_PROPOSTA > W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[AREA_DE_WORK.WIND])
                        {

                            /*" -822- COMPUTE WINF = WIND + 1 */
                            AREA_DE_WORK.WINF.Value = AREA_DE_WORK.WIND + 1;

                            /*" -823- ELSE */
                        }
                        else
                        {


                            /*" -824- MOVE 'SIM' TO WTEM-SISTEMA-ORIGEM */
                            _.Move("SIM", AREA_DE_WORK.WTEM_SISTEMA_ORIGEM);

                            /*" -825- END-IF */
                        }


                        /*" -826- END-IF */
                    }


                    /*" -827- END-IF */
                }


                /*" -827- END-PERFORM. */
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-SELECT-CONVERSI-SECTION */
        private void R1050_00_SELECT_CONVERSI_SECTION()
        {
            /*" -840- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -845- PERFORM R1050_00_SELECT_CONVERSI_DB_SELECT_1 */

            R1050_00_SELECT_CONVERSI_DB_SELECT_1();

            /*" -848- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -849- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -851- MOVE ZEROS TO CONVERSI-NUM-PROPOSTA-SIVPF */
                    _.Move(0, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);

                    /*" -852- ELSE */
                }
                else
                {


                    /*" -854- DISPLAY 'R1050-00 (ERRO - SELECT COVERSAO_SICOB)....' ' NUMBIL : ' V1BILH-NUMBIL */

                    $"R1050-00 (ERRO - SELECT COVERSAO_SICOB).... NUMBIL : {V1BILH_NUMBIL}"
                    .Display();

                    /*" -856- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -857- MOVE CONVERSI-NUM-PROPOSTA-SIVPF TO W-NUM-PROPOSTA. */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF, AREA_DE_WORK.W_NUM_PROPOSTA);

        }

        [StopWatch]
        /*" R1050-00-SELECT-CONVERSI-DB-SELECT-1 */
        public void R1050_00_SELECT_CONVERSI_DB_SELECT_1()
        {
            /*" -845- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :CONVERSI-NUM-PROPOSTA-SIVPF FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB = :V1BILH-NUMBIL END-EXEC. */

            var r1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1 = new R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1()
            {
                V1BILH_NUMBIL = V1BILH_NUMBIL.ToString(),
            };

            var executed_1 = R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1.Execute(r1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVERSI_NUM_PROPOSTA_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1060-00-SELECT-FIDELIZ-SECTION */
        private void R1060_00_SELECT_FIDELIZ_SECTION()
        {
            /*" -867- MOVE '1060' TO WNR-EXEC-SQL. */
            _.Move("1060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -881- PERFORM R1060_00_SELECT_FIDELIZ_DB_SELECT_1 */

            R1060_00_SELECT_FIDELIZ_DB_SELECT_1();

            /*" -884- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -885- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -887- MOVE ZEROS TO V0CONV-ORIGEM-PROPOSTA */
                    _.Move(0, V0CONV_ORIGEM_PROPOSTA);

                    /*" -888- ELSE */
                }
                else
                {


                    /*" -890- DISPLAY 'R1060-00 (ERRO - SELECT PROPOSTA_FIDELIZ)..' ' NUMBIL : ' V1BILH-NUMBIL */

                    $"R1060-00 (ERRO - SELECT PROPOSTA_FIDELIZ).. NUMBIL : {V1BILH_NUMBIL}"
                    .Display();

                    /*" -892- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -894- MOVE V0CONV-ORIGEM-PROPOSTA TO W-ORIGEM-PROPOSTA. */
            _.Move(V0CONV_ORIGEM_PROPOSTA, WREA88.W_ORIGEM_PROPOSTA);

        }

        [StopWatch]
        /*" R1060-00-SELECT-FIDELIZ-DB-SELECT-1 */
        public void R1060_00_SELECT_FIDELIZ_DB_SELECT_1()
        {
            /*" -881- EXEC SQL SELECT NUM_PROPOSTA_SIVPF, ORIGEM_PROPOSTA, NUM_SICOB, SIT_PROPOSTA INTO :V0CONV-NUM-PROPOSTA-SIVPF , :V0CONV-ORIGEM-PROPOSTA , :V0CONV-NUM-SICOB, :V0SIVPF-SIT-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :V1BILH-NUMBIL AND ( COD_PRODUTO_SIVPF IN (09,10) OR ( COD_PRODUTO_SIVPF BETWEEN 8100 AND 8199 ) OR ( COD_PRODUTO_SIVPF BETWEEN 8500 AND 8599 ) ) END-EXEC */

            var r1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1 = new R1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1()
            {
                V1BILH_NUMBIL = V1BILH_NUMBIL.ToString(),
            };

            var executed_1 = R1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1.Execute(r1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_NUM_PROPOSTA_SIVPF, V0CONV_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.V0CONV_ORIGEM_PROPOSTA, V0CONV_ORIGEM_PROPOSTA);
                _.Move(executed_1.V0CONV_NUM_SICOB, V0CONV_NUM_SICOB);
                _.Move(executed_1.V0SIVPF_SIT_PROPOSTA, V0SIVPF_SIT_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-CONT-REN-BIL-SECTION */
        private void R1100_00_SELECT_CONT_REN_BIL_SECTION()
        {
            /*" -906- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -912- PERFORM R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1 */

            R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1();

            /*" -915- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -916- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -917- MOVE SPACES TO V1CREN-SITUACAO */
                    _.Move("", V1CREN_SITUACAO);

                    /*" -918- ELSE */
                }
                else
                {


                    /*" -920- DISPLAY 'R1100-00 (ERRO - SELECT V1CONT_RENO_BIL)...' ' NUMBIL : ' V1BILH-NUMBIL */

                    $"R1100-00 (ERRO - SELECT V1CONT_RENO_BIL)... NUMBIL : {V1BILH_NUMBIL}"
                    .Display();

                    /*" -920- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-CONT-REN-BIL-DB-SELECT-1 */
        public void R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1()
        {
            /*" -912- EXEC SQL SELECT SITUACAO INTO :V1CREN-SITUACAO FROM SEGUROS.V1CONT_RENO_BIL WHERE NUMBIL = :V1BILH-NUMBIL AND SITUACAO <> '*' END-EXEC. */

            var r1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1 = new R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1()
            {
                V1BILH_NUMBIL = V1BILH_NUMBIL.ToString(),
            };

            var executed_1 = R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CREN_SITUACAO, V1CREN_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-SELECT-BILHETE-ANT-SECTION */
        private void R1150_00_SELECT_BILHETE_ANT_SECTION()
        {
            /*" -931- MOVE '1150' TO WNR-EXEC-SQL. */
            _.Move("1150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -937- PERFORM R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1 */

            R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1();

            /*" -940- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -941- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -942- DISPLAY 'R1150-00 BILHETE ANTERIOR NAO ENCONTRADO' */
                    _.Display($"R1150-00 BILHETE ANTERIOR NAO ENCONTRADO");

                    /*" -943- DISPLAY 'NUM-BILHETE-ANTERIOR = ' V1BILH-NUM-APOL-ANT */
                    _.Display($"NUM-BILHETE-ANTERIOR = {V1BILH_NUM_APOL_ANT}");

                    /*" -944- DISPLAY 'NUM-BILHETE-RENOVACAO = ' V1BILH-NUMBIL */
                    _.Display($"NUM-BILHETE-RENOVACAO = {V1BILH_NUMBIL}");

                    /*" -945- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -946- ELSE */
                }
                else
                {


                    /*" -947- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -948- DISPLAY 'R1150-00 DUPLICADO - SELECT V0BILHETE ANTERIOR' */
                        _.Display($"R1150-00 DUPLICADO - SELECT V0BILHETE ANTERIOR");

                        /*" -949- DISPLAY 'NUM-BILHETE-ANTERIOR = ' V1BILH-NUM-APOL-ANT */
                        _.Display($"NUM-BILHETE-ANTERIOR = {V1BILH_NUM_APOL_ANT}");

                        /*" -950- DISPLAY 'NUM-BILHETE-RENOVACAO = ' V1BILH-NUMBIL */
                        _.Display($"NUM-BILHETE-RENOVACAO = {V1BILH_NUMBIL}");

                        /*" -951- ELSE */
                    }
                    else
                    {


                        /*" -952- DISPLAY 'R1150-00 ERRO - SELECT V0BILHETE ANTERIOR' */
                        _.Display($"R1150-00 ERRO - SELECT V0BILHETE ANTERIOR");

                        /*" -953- DISPLAY 'NUM-BILHETE-ANTERIOR = ' V1BILH-NUM-APOL-ANT */
                        _.Display($"NUM-BILHETE-ANTERIOR = {V1BILH_NUM_APOL_ANT}");

                        /*" -954- DISPLAY 'NUM-BILHETE-RENOVACAO = ' V1BILH-NUMBIL */
                        _.Display($"NUM-BILHETE-RENOVACAO = {V1BILH_NUMBIL}");

                        /*" -954- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R1150-00-SELECT-BILHETE-ANT-DB-SELECT-1 */
        public void R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1()
        {
            /*" -937- EXEC SQL SELECT SITUACAO INTO :V0BILH-ANT-SITUACAO FROM SEGUROS.V0BILHETE WHERE NUMBIL = :V1BILH-NUM-APOL-ANT END-EXEC. */

            var r1150_00_SELECT_BILHETE_ANT_DB_SELECT_1_Query1 = new R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1_Query1()
            {
                V1BILH_NUM_APOL_ANT = V1BILH_NUM_APOL_ANT.ToString(),
            };

            var executed_1 = R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1_Query1.Execute(r1150_00_SELECT_BILHETE_ANT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BILH_ANT_SITUACAO, V0BILH_ANT_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-MONTA-V0MOVDEBCC-CEF-SECTION */
        private void R1200_00_MONTA_V0MOVDEBCC_CEF_SECTION()
        {
            /*" -964- MOVE V1BILH-NUMBIL TO V0MOVDE-NUM-APOLICE */
            _.Move(V1BILH_NUMBIL, V0MOVDE_NUM_APOLICE);

            /*" -966- MOVE '0' TO V0MOVDE-SIT-COBRANCA */
            _.Move("0", V0MOVDE_SIT_COBRANCA);

            /*" -996- MOVE 'N' TO WTEM-FERIADO */
            _.Move("N", AREA_DE_WORK.WTEM_FERIADO);

            /*" -997- MOVE V1BILH-DTQITBCO TO V0MOVDE-DTVENCTO */
            _.Move(V1BILH_DTQITBCO, V0MOVDE_DTVENCTO);

            /*" -998- MOVE V1BILH-VLRCAP TO V0MOVDE-VLR-DEBITO */
            _.Move(V1BILH_VLRCAP, V0MOVDE_VLR_DEBITO);

            /*" -999- MOVE V1SIST-DTMOVABE TO V0MOVDE-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0MOVDE_DTMOVTO);

            /*" -1000- MOVE WDIA-SQL TO V0MOVDE-DIA-DEBITO */
            _.Move(AREA_DE_WORK.FILLER_1.WDIA_SQL, V0MOVDE_DIA_DEBITO);

            /*" -1001- MOVE V1BILH-AGENCIA-DEB TO V0MOVDE-COD-AGE-DEB */
            _.Move(V1BILH_AGENCIA_DEB, V0MOVDE_COD_AGE_DEB);

            /*" -1002- MOVE V1BILH-OPERACAO-DEB TO V0MOVDE-OPER-CTA-DEB */
            _.Move(V1BILH_OPERACAO_DEB, V0MOVDE_OPER_CTA_DEB);

            /*" -1003- MOVE V1BILH-NUMCTA-DEB TO V0MOVDE-NUM-CTA-DEB */
            _.Move(V1BILH_NUMCTA_DEB, V0MOVDE_NUM_CTA_DEB);

            /*" -1005- MOVE V1BILH-DIGCTA-DEB TO V0MOVDE-DIG-CTA-DEB */
            _.Move(V1BILH_DIGCTA_DEB, V0MOVDE_DIG_CTA_DEB);

            /*" -1005- MOVE 6114 TO V0MOVDE-COD-CONVENIO. */
            _.Move(6114, V0MOVDE_COD_CONVENIO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V0CALENDARIO-SECTION */
        private void R1300_00_SELECT_V0CALENDARIO_SECTION()
        {
            /*" -1017- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1024- PERFORM R1300_00_SELECT_V0CALENDARIO_DB_SELECT_1 */

            R1300_00_SELECT_V0CALENDARIO_DB_SELECT_1();

            /*" -1027- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1029- DISPLAY 'DATA NAO ENCONTRADA NA CALENDARIO ' V0CALE-DTMOVTO */
                _.Display($"DATA NAO ENCONTRADA NA CALENDARIO {V0CALE_DTMOVTO}");

                /*" -1031- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1032- IF V0CALE-DIASEM EQUAL 'S' OR 'D' */

            if (V0CALE_DIASEM.In("S", "D"))
            {

                /*" -1033- MOVE 'S' TO WTEM-FERIADO */
                _.Move("S", AREA_DE_WORK.WTEM_FERIADO);

                /*" -1034- ELSE */
            }
            else
            {


                /*" -1034- PERFORM R1400-00-SELECT-V0FERIADOS. */

                R1400_00_SELECT_V0FERIADOS_SECTION();
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-V0CALENDARIO-DB-SELECT-1 */
        public void R1300_00_SELECT_V0CALENDARIO_DB_SELECT_1()
        {
            /*" -1024- EXEC SQL SELECT DATA_CALENDARIO , DIA_SEMANA INTO :V0CALE-DTMOVTO , :V0CALE-DIASEM FROM SEGUROS.V0CALENDARIO WHERE DATA_CALENDARIO = :V0CALE-DTMOVTO END-EXEC. */

            var r1300_00_SELECT_V0CALENDARIO_DB_SELECT_1_Query1 = new R1300_00_SELECT_V0CALENDARIO_DB_SELECT_1_Query1()
            {
                V0CALE_DTMOVTO = V0CALE_DTMOVTO.ToString(),
            };

            var executed_1 = R1300_00_SELECT_V0CALENDARIO_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_V0CALENDARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CALE_DTMOVTO, V0CALE_DTMOVTO);
                _.Move(executed_1.V0CALE_DIASEM, V0CALE_DIASEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-V0FERIADOS-SECTION */
        private void R1400_00_SELECT_V0FERIADOS_SECTION()
        {
            /*" -1046- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1056- PERFORM R1400_00_SELECT_V0FERIADOS_DB_SELECT_1 */

            R1400_00_SELECT_V0FERIADOS_DB_SELECT_1();

            /*" -1059- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1060- MOVE 'S' TO WTEM-FERIADO */
                _.Move("S", AREA_DE_WORK.WTEM_FERIADO);

                /*" -1062- GO TO R1400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1063- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1064- DISPLAY 'R0220-00 - PROBLEMAS NO SELECT(V0FERIADOS)  ' */
                _.Display($"R0220-00 - PROBLEMAS NO SELECT(V0FERIADOS)  ");

                /*" -1064- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-V0FERIADOS-DB-SELECT-1 */
        public void R1400_00_SELECT_V0FERIADOS_DB_SELECT_1()
        {
            /*" -1056- EXEC SQL SELECT DATA_FERIADO , TIPO_FERIADO , SIT_REGISTRO INTO :V0FERI-DTMOVTO , :V0FERI-TIPO , :V0FERI-SITUACAO FROM SEGUROS.V0FERIADOS WHERE DATA_FERIADO = :V0CALE-DTMOVTO AND SIT_REGISTRO = '0' END-EXEC. */

            var r1400_00_SELECT_V0FERIADOS_DB_SELECT_1_Query1 = new R1400_00_SELECT_V0FERIADOS_DB_SELECT_1_Query1()
            {
                V0CALE_DTMOVTO = V0CALE_DTMOVTO.ToString(),
            };

            var executed_1 = R1400_00_SELECT_V0FERIADOS_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_V0FERIADOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FERI_DTMOVTO, V0FERI_DTMOVTO);
                _.Move(executed_1.V0FERI_TIPO, V0FERI_TIPO);
                _.Move(executed_1.V0FERI_SITUACAO, V0FERI_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-GRAVA-V0MOVDEBCC-CEF-SECTION */
        private void R1500_00_GRAVA_V0MOVDEBCC_CEF_SECTION()
        {
            /*" -1078- IF V0MOVDE-COD-AGE-DEB EQUAL ZEROS OR V0MOVDE-OPER-CTA-DEB EQUAL ZEROS OR V0MOVDE-NUM-CTA-DEB EQUAL ZEROS */

            if (V0MOVDE_COD_AGE_DEB == 00 || V0MOVDE_OPER_CTA_DEB == 00 || V0MOVDE_NUM_CTA_DEB == 00)
            {

                /*" -1080- MOVE '6' TO V0MOVDE-SIT-COBRANCA. */
                _.Move("6", V0MOVDE_SIT_COBRANCA);
            }


            /*" -1082- MOVE ZEROS TO V0MOVDE-NRENDOS */
            _.Move(0, V0MOVDE_NRENDOS);

            /*" -1083- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1141- PERFORM R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1 */

            R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1();

            /*" -1146- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -1147- DISPLAY 'PROBLEMA INSERT V0MOVDEBCC_CEF ' */
                _.Display($"PROBLEMA INSERT V0MOVDEBCC_CEF ");

                /*" -1148- DISPLAY '(R1500) - APOLICE: ' V0MOVDE-NUM-APOLICE */
                _.Display($"(R1500) - APOLICE: {V0MOVDE_NUM_APOLICE}");

                /*" -1150- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1150- ADD 1 TO WACC-GRAVADOS. */
            AREA_DE_WORK.WACC_GRAVADOS.Value = AREA_DE_WORK.WACC_GRAVADOS + 1;

        }

        [StopWatch]
        /*" R1500-00-GRAVA-V0MOVDEBCC-CEF-DB-INSERT-1 */
        public void R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1()
        {
            /*" -1141- EXEC SQL INSERT INTO SEGUROS.V0MOVDEBCC_CEF ( COD_EMPRESA ,NUM_APOLICE ,NRENDOS ,NRPARCEL ,SIT_COBRANCA ,DTVENCTO ,VLR_DEBITO ,DTMOVTO ,TIMESTAMP ,DIA_DEBITO ,COD_AGENCIA_DEB ,OPER_CONTA_DEB ,NUM_CONTA_DEB ,DIG_CONTA_DEB ,COD_CONVENIO ,DTENVIO ,DTRETORNO ,COD_RETORNO_CEF ,NSAS ,COD_USUARIO ,NUM_REQUISICAO ,NUM_CARTAO ,SEQUENCIA ,NUM_LOTE ,DTCREDITO ,STATUS_CARTAO ,VLR_CREDITO ) VALUES (0, :V0MOVDE-NUM-APOLICE, :V0MOVDE-NRENDOS, 0, :V0MOVDE-SIT-COBRANCA, :V0MOVDE-DTVENCTO, :V0MOVDE-VLR-DEBITO, :V0MOVDE-DTMOVTO, CURRENT TIMESTAMP, :V0MOVDE-DIA-DEBITO, :V0MOVDE-COD-AGE-DEB, :V0MOVDE-OPER-CTA-DEB, :V0MOVDE-NUM-CTA-DEB, :V0MOVDE-DIG-CTA-DEB, :V0MOVDE-COD-CONVENIO, NULL, NULL, NULL, 0, 'BI0030B' , NULL, NULL, NULL, NULL, NULL, NULL, NULL) END-EXEC. */

            var r1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1 = new R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1()
            {
                V0MOVDE_NUM_APOLICE = V0MOVDE_NUM_APOLICE.ToString(),
                V0MOVDE_NRENDOS = V0MOVDE_NRENDOS.ToString(),
                V0MOVDE_SIT_COBRANCA = V0MOVDE_SIT_COBRANCA.ToString(),
                V0MOVDE_DTVENCTO = V0MOVDE_DTVENCTO.ToString(),
                V0MOVDE_VLR_DEBITO = V0MOVDE_VLR_DEBITO.ToString(),
                V0MOVDE_DTMOVTO = V0MOVDE_DTMOVTO.ToString(),
                V0MOVDE_DIA_DEBITO = V0MOVDE_DIA_DEBITO.ToString(),
                V0MOVDE_COD_AGE_DEB = V0MOVDE_COD_AGE_DEB.ToString(),
                V0MOVDE_OPER_CTA_DEB = V0MOVDE_OPER_CTA_DEB.ToString(),
                V0MOVDE_NUM_CTA_DEB = V0MOVDE_NUM_CTA_DEB.ToString(),
                V0MOVDE_DIG_CTA_DEB = V0MOVDE_DIG_CTA_DEB.ToString(),
                V0MOVDE_COD_CONVENIO = V0MOVDE_COD_CONVENIO.ToString(),
            };

            R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1.Execute(r1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-UPDATE-V0RELATORIOS-SECTION */
        private void R2000_00_UPDATE_V0RELATORIOS_SECTION()
        {
            /*" -1162- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1167- PERFORM R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1 */

            R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1();

            /*" -1170- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1171- DISPLAY 'R2000 - PROBLEMA UPDATE RELATORIOS ' */
                _.Display($"R2000 - PROBLEMA UPDATE RELATORIOS ");

                /*" -1171- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2000-00-UPDATE-V0RELATORIOS-DB-UPDATE-1 */
        public void R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1()
        {
            /*" -1167- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET DATA_REFERENCIA = :WDATA-BASE-10 WHERE CODRELAT = 'BI0030B1' AND SITUACAO = '0' END-EXEC. */

            var r2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 = new R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1()
            {
                WDATA_BASE_10 = WDATA_BASE_10.ToString(),
            };

            R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1.Execute(r2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-UPDATE-V0BILHETE-SECTION */
        private void R2500_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -1183- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1189- PERFORM R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -1192- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1194- DISPLAY 'R2500 - PROBLEMA UPDATE V0BILHETE ' V1BILH-NUMBIL */
                _.Display($"R2500 - PROBLEMA UPDATE V0BILHETE {V1BILH_NUMBIL}");

                /*" -1194- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2500-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -1189- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = '*' , COD_USUARIO = 'BI0030B' WHERE NUMBIL = :V1BILH-NUMBIL AND SITUACAO = '5' END-EXEC. */

            var r2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V1BILH_NUMBIL = V1BILH_NUMBIL.ToString(),
            };

            R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2501-00-UPDATE-V0BILHETE-SECTION */
        private void R2501_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -1206- MOVE '2501' TO WNR-EXEC-SQL. */
            _.Move("2501", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1211- PERFORM R2501_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R2501_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -1214- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1216- DISPLAY 'R2500 - PROBLEMA UPDATE V0BILHETE ' V1BILH-NUMBIL */
                _.Display($"R2500 - PROBLEMA UPDATE V0BILHETE {V1BILH_NUMBIL}");

                /*" -1216- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2501-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R2501_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -1211- EXEC SQL UPDATE SEGUROS.V0BILHETE SET DTQITBCO = :WDATA-BASE WHERE NUMBIL = :V1BILH-NUMBIL AND SITUACAO = '5' END-EXEC. */

            var r2501_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R2501_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                WDATA_BASE = WDATA_BASE.ToString(),
                V1BILH_NUMBIL = V1BILH_NUMBIL.ToString(),
            };

            R2501_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r2501_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2501_99_SAIDA*/

        [StopWatch]
        /*" R2502-00-VALIDA-DATA-SECTION */
        private void R2502_00_VALIDA_DATA_SECTION()
        {
            /*" -1226- MOVE '2502' TO WNR-EXEC-SQL. */
            _.Move("2502", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1227- MOVE WDATA-SQL TO GE0006S-DATA-DESTINO. */
            _.Move(AREA_DE_WORK.WDATA_SQL, GE0006S_LINKAGE.GE0006S_DATA_DESTINO);

            /*" -1229- MOVE SPACES TO GE0006S-MENSAGEM. */
            _.Move("", GE0006S_LINKAGE.GE0006S_MENSAGEM);

            /*" -1231- CALL 'GE0006S' USING GE0006S-LINKAGE. */
            _.Call("GE0006S", GE0006S_LINKAGE);

            /*" -1232- IF GE0006S-MENSAGEM EQUAL SPACES */

            if (GE0006S_LINKAGE.GE0006S_MENSAGEM.IsEmpty())
            {

                /*" -1233- MOVE GE0006S-DATA-DESTINO TO WDATA-SQL */
                _.Move(GE0006S_LINKAGE.GE0006S_DATA_DESTINO, AREA_DE_WORK.WDATA_SQL);

                /*" -1234- ELSE */
            }
            else
            {


                /*" -1235- DISPLAY 'PROBLEMA NA ROTINA GE0006S' */
                _.Display($"PROBLEMA NA ROTINA GE0006S");

                /*" -1236- DISPLAY 'MENSAGEM -->' GE0006S-MENSAGEM */
                _.Display($"MENSAGEM -->{GE0006S_LINKAGE.GE0006S_MENSAGEM}");

                /*" -1237- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1239- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2502_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1252- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1254- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1254- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1256- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1260- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1260- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}