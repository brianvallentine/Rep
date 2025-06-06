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
using Sias.Bilhetes.DB2.BI0032B;

namespace Code
{
    public class BI0032B
    {
        public bool IsCall { get; set; }

        public BI0032B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  BILHETES   CC                      *      */
        /*"      *   PROGRAMA ...............  BI0032B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FAST COMPUTER                      *      */
        /*"      *   PROGRAMADOR ............  FAST COMPUTER                      *      */
        /*"      *   DATA CODIFICACAO .......  OUTUBRO / 2007                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  A PARTIR DA TABELA RELATORIO  COM  *      */
        /*"      *                             COM SITUACAO     = '0'             *      */
        /*"      *                             GERA A TABELA V0MOVDEBCC_CEF       *      */
        /*"      *                             PARA ENVIAR ESTORNO DE DEBITO.     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 -   DEMANDA 455.132                                *      */
        /*"      *             - COLCAR OS CAMPOS NO MOMENTO DO INSERT PARA       *      */
        /*"      *               TABELA MOVTO_DEBITOCC_CEF (VIEW)                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/02/2023 - HUSNI ALI HUSNI                              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/10/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - CORRECAO DO ABEND SQLCODE = -803 NA TABELA       *      */
        /*"      *               V0MOVDEBCC_CEF                                          */
        /*"      *   EM 20/11/2007 - MARCO PAIVA              PROCURE POR V.06    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"BRSEG1*   BRSEG1 - ALTERACAO ACESSO BILHETE ANTERIOR                   *      */
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
        /*"      *                                                                       */
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
        /*"77         V0MOVDE-NUM-CTA-DEB    PIC S9(13)              COMP-3*/
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
        /*"01              AREA-DE-WORK.*/
        public BI0032B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new BI0032B_AREA_DE_WORK();
        public class BI0032B_AREA_DE_WORK : VarBasis
        {
            /*"  05  W-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  05  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_BI0032B_CANAL _canal { get; set; }
            public _REDEF_BI0032B_CANAL CANAL
            {
                get { _canal = new _REDEF_BI0032B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_BI0032B_CANAL : VarBasis
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

                public _REDEF_BI0032B_CANAL()
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
            /*"  05            WFIM-RELATORIO    PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WFIM_RELATORIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            WFIM-CALENDARIO   PIC  X(001)   VALUE  'N'.*/
            public StringBasis WFIM_CALENDARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  05            WTEM-FERIADO      PIC  X(001)   VALUE  'N'.*/
            public StringBasis WTEM_FERIADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  05            WDATA-SQL            PIC   X(010).*/
            public StringBasis WDATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05            FILLER               REDEFINES         WDATA-SQL*/
            private _REDEF_BI0032B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI0032B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI0032B_FILLER_1(); _.Move(WDATA_SQL, _filler_1); VarBasis.RedefinePassValue(WDATA_SQL, _filler_1, WDATA_SQL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_SQL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_SQL); }
            }  //Redefines
            public class _REDEF_BI0032B_FILLER_1 : VarBasis
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

                public _REDEF_BI0032B_FILLER_1()
                {
                    WANO_SQL.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WMES_SQL.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public BI0032B_WS_TIME WS_TIME { get; set; } = new BI0032B_WS_TIME();
            public class BI0032B_WS_TIME : VarBasis
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
            public BI0032B_LPARM2 LPARM2 { get; set; } = new BI0032B_LPARM2();
            public class BI0032B_LPARM2 : VarBasis
            {
                /*"    10          DATA2.*/
                public BI0032B_DATA2 DATA2 { get; set; } = new BI0032B_DATA2();
                public class BI0032B_DATA2 : VarBasis
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
                public BI0032B_DATA3 DATA3 { get; set; } = new BI0032B_DATA3();
                public class BI0032B_DATA3 : VarBasis
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
            public BI0032B_WABEND WABEND { get; set; } = new BI0032B_WABEND();
            public class BI0032B_WABEND : VarBasis
            {
                /*"    10          FILLER         PIC  X(008)      VALUE               'BI0032B '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"BI0032B ");
                /*"    10          FILLER         PIC  X(025)      VALUE               '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10          WNR-EXEC-SQL   PIC  X(004)      VALUE   '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10          FILLER         PIC  X(013)      VALUE               ' *** SQLCODE '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10          WSQLCODE       PIC  ZZZZZ999-   VALUE    ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01           GE0006S-LINKAGE.*/
            }
        }
        public BI0032B_GE0006S_LINKAGE GE0006S_LINKAGE { get; set; } = new BI0032B_GE0006S_LINKAGE();
        public class BI0032B_GE0006S_LINKAGE : VarBasis
        {
            /*"  05         GE0006S-DATA-DESTINO    PIC  X(010).*/
            public StringBasis GE0006S_DATA_DESTINO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         GE0006S-QTDDIAS         PIC  9(004).*/
            public IntBasis GE0006S_QTDDIAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         GE0006S-MENSAGEM        PIC  X(070).*/
            public StringBasis GE0006S_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        }


        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public BI0032B_V1RELAT V1RELAT { get; set; } = new BI0032B_V1RELAT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -348- DISPLAY '-------------------------------' . */
                _.Display($"-------------------------------");

                /*" -349- DISPLAY 'PROGRAMA EM EXECUCAO BI0032B   ' . */
                _.Display($"PROGRAMA EM EXECUCAO BI0032B   ");

                /*" -350- DISPLAY '                               ' . */
                _.Display($"                               ");

                /*" -351- DISPLAY 'VERSAO V.08 455.132 24/02/2023 ' . */
                _.Display($"VERSAO V.08 455.132 24/02/2023 ");

                /*" -352- DISPLAY '                               ' . */
                _.Display($"                               ");

                /*" -359- DISPLAY '-------------------------------' . */
                _.Display($"-------------------------------");

                /*" -361- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -362- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -365- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -368- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -368- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -378- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -379- PERFORM R0400-00-DECLARE-RELATORIO */

            R0400_00_DECLARE_RELATORIO_SECTION();

            /*" -381- PERFORM R0500-00-FETCH-RELATORIO */

            R0500_00_FETCH_RELATORIO_SECTION();

            /*" -382- IF WFIM-RELATORIO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_RELATORIO.IsEmpty())
            {

                /*" -383- DISPLAY '*-----------------------------------------------*' */
                _.Display($"*-----------------------------------------------*");

                /*" -384- DISPLAY '* NAO HOUVE MOVIMENTO NESTA DATA: ' WDATA-BASE */
                _.Display($"* NAO HOUVE MOVIMENTO NESTA DATA: {WDATA_BASE}");

                /*" -385- DISPLAY '*-----------------------------------------------*' */
                _.Display($"*-----------------------------------------------*");

                /*" -387- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -388- PERFORM R1000-00-PROCESSA-RELATORIO UNTIL WFIM-RELATORIO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_RELATORIO.IsEmpty()))
            {

                R1000_00_PROCESSA_RELATORIO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -395- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -396- DISPLAY 'BI0032B - FIM NORMAL' */
            _.Display($"BI0032B - FIM NORMAL");

            /*" -397- DISPLAY 'LIDOS............... ' WACC-LIDOS */
            _.Display($"LIDOS............... {AREA_DE_WORK.WACC_LIDOS}");

            /*" -399- DISPLAY 'GRAVADOS............ ' WACC-GRAVADOS */
            _.Display($"GRAVADOS............ {AREA_DE_WORK.WACC_GRAVADOS}");

            /*" -399- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -401- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -413- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -420- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -423- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -424- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -425- DISPLAY 'BI0032B - SISTEMA CB NAO CADASTRADO' */
                    _.Display($"BI0032B - SISTEMA CB NAO CADASTRADO");

                    /*" -426- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -427- ELSE */
                }
                else
                {


                    /*" -428- DISPLAY 'PROBLEMA SELECT V1SISTEMA' */
                    _.Display($"PROBLEMA SELECT V1SISTEMA");

                    /*" -430- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -431- DISPLAY 'V1SIST-DTMOVABE ' V1SIST-DTMOVABE. */
            _.Display($"V1SIST-DTMOVABE {V1SIST_DTMOVABE}");

            /*" -432- MOVE V1SIST-DTMOVABE TO WDATA-SQL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_SQL);

            /*" -433- MOVE 4 TO GE0006S-QTDDIAS */
            _.Move(4, GE0006S_LINKAGE.GE0006S_QTDDIAS);

            /*" -438- PERFORM R2502-00-VALIDA-DATA */

            R2502_00_VALIDA_DATA_SECTION();

            /*" -439- MOVE WDATA-SQL TO WDATA-BASE-4. */
            _.Move(AREA_DE_WORK.WDATA_SQL, WDATA_BASE_4);

            /*" -441- DISPLAY 'DATA-BASE-4 ' WDATA-BASE-4. */
            _.Display($"DATA-BASE-4 {WDATA_BASE_4}");

            /*" -442- MOVE V1SIST-DTMOVABE TO WDATA-SQL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_SQL);

            /*" -443- MOVE 5 TO GE0006S-QTDDIAS */
            _.Move(5, GE0006S_LINKAGE.GE0006S_QTDDIAS);

            /*" -448- PERFORM R2502-00-VALIDA-DATA */

            R2502_00_VALIDA_DATA_SECTION();

            /*" -449- MOVE WDATA-SQL TO WDATA-BASE. */
            _.Move(AREA_DE_WORK.WDATA_SQL, WDATA_BASE);

            /*" -449- DISPLAY 'DATA-BASE ' WDATA-BASE. */
            _.Display($"DATA-BASE {WDATA_BASE}");

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -420- EXEC SQL SELECT DTMOVABE , DTMOVABE - 30 DAYS INTO :V1SIST-DTMOVABE , :V1SIST-DTMOVABE-30 FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'RN' END-EXEC. */

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
        /*" R0200-00-PROX-ANT-DATA-UTIL-SECTION */
        private void R0200_00_PROX_ANT_DATA_UTIL_SECTION()
        {
            /*" -461- MOVE '0200' TO WNR-EXEC-SQL */
            _.Move("0200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -462- MOVE WDIA-SQL TO DATA2-DD */
            _.Move(AREA_DE_WORK.FILLER_1.WDIA_SQL, AREA_DE_WORK.LPARM2.DATA2.DATA2_DD);

            /*" -463- MOVE WMES-SQL TO DATA2-MM */
            _.Move(AREA_DE_WORK.FILLER_1.WMES_SQL, AREA_DE_WORK.LPARM2.DATA2.DATA2_MM);

            /*" -464- MOVE WANO-SQL TO DATA2-AA */
            _.Move(AREA_DE_WORK.FILLER_1.WANO_SQL, AREA_DE_WORK.LPARM2.DATA2.DATA2_AA);

            /*" -465- MOVE ZEROS TO DATA3-DD */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA3.DATA3_DD);

            /*" -466- MOVE ZEROS TO DATA3-MM */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA3.DATA3_MM);

            /*" -468- MOVE ZEROS TO DATA3-AA */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA3.DATA3_AA);

            /*" -470- CALL 'PROSOCU1' USING LPARM2. */
            _.Call("PROSOCU1", AREA_DE_WORK.LPARM2);

            /*" -471- MOVE DATA3-DD TO WDIA-SQL */
            _.Move(AREA_DE_WORK.LPARM2.DATA3.DATA3_DD, AREA_DE_WORK.FILLER_1.WDIA_SQL);

            /*" -472- MOVE DATA3-MM TO WMES-SQL */
            _.Move(AREA_DE_WORK.LPARM2.DATA3.DATA3_MM, AREA_DE_WORK.FILLER_1.WMES_SQL);

            /*" -472- MOVE DATA3-AA TO WANO-SQL. */
            _.Move(AREA_DE_WORK.LPARM2.DATA3.DATA3_AA, AREA_DE_WORK.FILLER_1.WANO_SQL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-SELECT-V0RELATORIOS-SECTION */
        private void R0300_00_SELECT_V0RELATORIOS_SECTION()
        {
            /*" -484- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -490- PERFORM R0300_00_SELECT_V0RELATORIOS_DB_SELECT_1 */

            R0300_00_SELECT_V0RELATORIOS_DB_SELECT_1();

            /*" -493- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -495- DISPLAY 'R0300 - PROBLEMA SELECT V0RELATORIOS ' 'CODRELAT     - BI0032B1' V0RELA-DATA-REFER */

                $"R0300 - PROBLEMA SELECT V0RELATORIOS CODRELAT     - BI0032B1{V0RELA_DATA_REFER}"
                .Display();

                /*" -496- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -497- ELSE */
            }
            else
            {


                /*" -498- DISPLAY 'R0300 - RENOVACAO A PARTIR DE ' V0RELA-DATA-REFER. */
                _.Display($"R0300 - RENOVACAO A PARTIR DE {V0RELA_DATA_REFER}");
            }


        }

        [StopWatch]
        /*" R0300-00-SELECT-V0RELATORIOS-DB-SELECT-1 */
        public void R0300_00_SELECT_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -490- EXEC SQL SELECT DATA_REFERENCIA INTO :V0RELA-DATA-REFER FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'BI0032B1' AND SITUACAO = '0' END-EXEC. */

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
        /*" R0400-00-DECLARE-RELATORIO-SECTION */
        private void R0400_00_DECLARE_RELATORIO_SECTION()
        {
            /*" -510- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -520- PERFORM R0400_00_DECLARE_RELATORIO_DB_DECLARE_1 */

            R0400_00_DECLARE_RELATORIO_DB_DECLARE_1();

            /*" -523- PERFORM R0400_00_DECLARE_RELATORIO_DB_OPEN_1 */

            R0400_00_DECLARE_RELATORIO_DB_OPEN_1();

            /*" -526- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -527- DISPLAY 'PROBLEMAS NO OPEN (V1RELAT)... ' */
                _.Display($"PROBLEMAS NO OPEN (V1RELAT)... ");

                /*" -527- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0400-00-DECLARE-RELATORIO-DB-DECLARE-1 */
        public void R0400_00_DECLARE_RELATORIO_DB_DECLARE_1()
        {
            /*" -520- EXEC SQL DECLARE V1RELAT CURSOR FOR SELECT COD_RELATORIO , COD_FONTE , RAMO_EMISSOR , NUM_APOLICE , NUM_TITULO , DATA_SOLICITACAO FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'BI0032B' AND SIT_REGISTRO = '0' END-EXEC */
            V1RELAT = new BI0032B_V1RELAT(false);
            string GetQuery_V1RELAT()
            {
                var query = @$"SELECT COD_RELATORIO
							, 
							COD_FONTE
							, 
							RAMO_EMISSOR
							, 
							NUM_APOLICE
							, 
							NUM_TITULO
							, 
							DATA_SOLICITACAO 
							FROM SEGUROS.RELATORIOS 
							WHERE COD_RELATORIO = 'BI0032B' 
							AND SIT_REGISTRO = '0'";

                return query;
            }
            V1RELAT.GetQueryEvent += GetQuery_V1RELAT;

        }

        [StopWatch]
        /*" R0400-00-DECLARE-RELATORIO-DB-OPEN-1 */
        public void R0400_00_DECLARE_RELATORIO_DB_OPEN_1()
        {
            /*" -523- EXEC SQL OPEN V1RELAT END-EXEC. */

            V1RELAT.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-FETCH-RELATORIO-SECTION */
        private void R0500_00_FETCH_RELATORIO_SECTION()
        {
            /*" -537- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0500_10_LE */

            R0500_10_LE();

        }

        [StopWatch]
        /*" R0500-10-LE */
        private void R0500_10_LE(bool isPerform = false)
        {
            /*" -548- PERFORM R0500_10_LE_DB_FETCH_1 */

            R0500_10_LE_DB_FETCH_1();

            /*" -551- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -552- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -552- PERFORM R0500_10_LE_DB_CLOSE_1 */

                    R0500_10_LE_DB_CLOSE_1();

                    /*" -554- MOVE 'S' TO WFIM-RELATORIO */
                    _.Move("S", AREA_DE_WORK.WFIM_RELATORIO);

                    /*" -555- GO TO R0500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                    return;

                    /*" -556- ELSE */
                }
                else
                {


                    /*" -557- DISPLAY 'R0500-00 (ERRO -  FETCH V1RELAT).. ' */
                    _.Display($"R0500-00 (ERRO -  FETCH V1RELAT).. ");

                    /*" -559- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -562- ADD 1 TO WACC-LIDOS WACC-DISPLAY. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;
            AREA_DE_WORK.WACC_DISPLAY.Value = AREA_DE_WORK.WACC_DISPLAY + 1;

            /*" -563- IF WACC-DISPLAY EQUAL 500 */

            if (AREA_DE_WORK.WACC_DISPLAY == 500)
            {

                /*" -564- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

                /*" -565- DISPLAY 'TOTAL LIDO.....' WACC-LIDOS ' ' WS-TIME */

                $"TOTAL LIDO.....{AREA_DE_WORK.WACC_LIDOS} {AREA_DE_WORK.WS_TIME}"
                .Display();

                /*" -568- MOVE ZEROS TO WACC-DISPLAY. */
                _.Move(0, AREA_DE_WORK.WACC_DISPLAY);
            }


            /*" -568- PERFORM R0600-00-SELEC-V1BILHETE. */

            R0600_00_SELEC_V1BILHETE_SECTION();

        }

        [StopWatch]
        /*" R0500-10-LE-DB-FETCH-1 */
        public void R0500_10_LE_DB_FETCH_1()
        {
            /*" -548- EXEC SQL FETCH V1RELAT INTO :RELATORI-DATA-SOLICITACAO , :RELATORI-COD-FONTE , :RELATORI-RAMO-EMISSOR , :RELATORI-NUM-APOLICE , :RELATORI-NUM-TITULO END-EXEC. */

            if (V1RELAT.Fetch())
            {
                _.Move(V1RELAT.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(V1RELAT.RELATORI_COD_FONTE, RELATORI.DCLRELATORIOS.RELATORI_COD_FONTE);
                _.Move(V1RELAT.RELATORI_RAMO_EMISSOR, RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR);
                _.Move(V1RELAT.RELATORI_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);
                _.Move(V1RELAT.RELATORI_NUM_TITULO, RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO);
            }

        }

        [StopWatch]
        /*" R0500-10-LE-DB-CLOSE-1 */
        public void R0500_10_LE_DB_CLOSE_1()
        {
            /*" -552- EXEC SQL CLOSE V1RELAT END-EXEC */

            V1RELAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-SELEC-V1BILHETE-SECTION */
        private void R0600_00_SELEC_V1BILHETE_SECTION()
        {
            /*" -578- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -610- PERFORM R0600_00_SELEC_V1BILHETE_DB_SELECT_1 */

            R0600_00_SELEC_V1BILHETE_DB_SELECT_1();

            /*" -613- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -615- DISPLAY 'R0600-00 (ERRO - SELECT V0BILHETE)....' ' NUMBIL : ' RELATORI-NUM-TITULO */

                $"R0600-00 (ERRO - SELECT V0BILHETE).... NUMBIL : {RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO}"
                .Display();

                /*" -615- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0600-00-SELEC-V1BILHETE-DB-SELECT-1 */
        public void R0600_00_SELEC_V1BILHETE_DB_SELECT_1()
        {
            /*" -610- EXEC SQL SELECT NUMBIL , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB, NUM_CONTA_DEB , DIG_CONTA_DEB , DTQITBCO , VLRCAP , NUM_APOL_ANTERIOR , RAMO , SITUACAO INTO :V1BILH-NUMBIL , :V1BILH-AGENCIA , :V1BILH-OPERACAO , :V1BILH-NUMCTA , :V1BILH-DIGCTA , :V1BILH-AGENCIA-DEB , :V1BILH-OPERACAO-DEB , :V1BILH-NUMCTA-DEB , :V1BILH-DIGCTA-DEB , :V1BILH-DTQITBCO , :V1BILH-VLRCAP , :V1BILH-NUM-APOL-ANT , :V1BILH-RAMO , :V1BILH-SITUACAO FROM SEGUROS.V0BILHETE WHERE NUMBIL =:RELATORI-NUM-TITULO END-EXEC. */

            var r0600_00_SELEC_V1BILHETE_DB_SELECT_1_Query1 = new R0600_00_SELEC_V1BILHETE_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
            };

            var executed_1 = R0600_00_SELEC_V1BILHETE_DB_SELECT_1_Query1.Execute(r0600_00_SELEC_V1BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILH_NUMBIL, V1BILH_NUMBIL);
                _.Move(executed_1.V1BILH_AGENCIA, V1BILH_AGENCIA);
                _.Move(executed_1.V1BILH_OPERACAO, V1BILH_OPERACAO);
                _.Move(executed_1.V1BILH_NUMCTA, V1BILH_NUMCTA);
                _.Move(executed_1.V1BILH_DIGCTA, V1BILH_DIGCTA);
                _.Move(executed_1.V1BILH_AGENCIA_DEB, V1BILH_AGENCIA_DEB);
                _.Move(executed_1.V1BILH_OPERACAO_DEB, V1BILH_OPERACAO_DEB);
                _.Move(executed_1.V1BILH_NUMCTA_DEB, V1BILH_NUMCTA_DEB);
                _.Move(executed_1.V1BILH_DIGCTA_DEB, V1BILH_DIGCTA_DEB);
                _.Move(executed_1.V1BILH_DTQITBCO, V1BILH_DTQITBCO);
                _.Move(executed_1.V1BILH_VLRCAP, V1BILH_VLRCAP);
                _.Move(executed_1.V1BILH_NUM_APOL_ANT, V1BILH_NUM_APOL_ANT);
                _.Move(executed_1.V1BILH_RAMO, V1BILH_RAMO);
                _.Move(executed_1.V1BILH_SITUACAO, V1BILH_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-RELATORIO-SECTION */
        private void R1000_00_PROCESSA_RELATORIO_SECTION()
        {
            /*" -638- PERFORM R1050-00-SELECT-CONVERSI */

            R1050_00_SELECT_CONVERSI_SECTION();

            /*" -639- IF CANAL-VENDA-GITEL */

            if (AREA_DE_WORK.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_GITEL"])
            {

                /*" -640- PERFORM R1200-00-MONTA-V0MOVDEBCC-CEF */

                R1200_00_MONTA_V0MOVDEBCC_CEF_SECTION();

                /*" -641- PERFORM R1500-00-GRAVA-V0MOVDEBCC-CEF */

                R1500_00_GRAVA_V0MOVDEBCC_CEF_SECTION();

                /*" -643- GO TO R1000-10-LEITURA. */

                R1000_10_LEITURA(); //GOTO
                return;
            }


            /*" -645- PERFORM R1100-00-SELECT-CONT-REN-BIL */

            R1100_00_SELECT_CONT_REN_BIL_SECTION();

            /*" -647- IF V1CREN-SITUACAO EQUAL '0' OR 'F' */

            if (V1CREN_SITUACAO.In("0", "F"))
            {

                /*" -648- GO TO R1000-10-LEITURA */

                R1000_10_LEITURA(); //GOTO
                return;

                /*" -649- ELSE */
            }
            else
            {


                /*" -653- PERFORM R1150-00-SELECT-BILHETE-ANT */

                R1150_00_SELECT_BILHETE_ANT_SECTION();

                /*" -655- IF V0BILH-ANT-SITUACAO EQUAL '8' OR SQLCODE EQUAL -811 */

                if (V0BILH_ANT_SITUACAO == "8" || DB.SQLCODE == -811)
                {

                    /*" -656- PERFORM R2500-00-UPDATE-V0BILHETE */

                    R2500_00_UPDATE_V0BILHETE_SECTION();

                    /*" -657- GO TO R1000-10-LEITURA */

                    R1000_10_LEITURA(); //GOTO
                    return;

                    /*" -658- ELSE */
                }
                else
                {


                    /*" -659- PERFORM R1200-00-MONTA-V0MOVDEBCC-CEF */

                    R1200_00_MONTA_V0MOVDEBCC_CEF_SECTION();

                    /*" -659- PERFORM R1500-00-GRAVA-V0MOVDEBCC-CEF. */

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
            /*" -664- PERFORM R2000-00-UPDATE-V0RELATORIOS. */

            R2000_00_UPDATE_V0RELATORIOS_SECTION();

            /*" -664- PERFORM R0500-00-FETCH-RELATORIO. */

            R0500_00_FETCH_RELATORIO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-SELECT-CONVERSI-SECTION */
        private void R1050_00_SELECT_CONVERSI_SECTION()
        {
            /*" -677- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -682- PERFORM R1050_00_SELECT_CONVERSI_DB_SELECT_1 */

            R1050_00_SELECT_CONVERSI_DB_SELECT_1();

            /*" -685- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -686- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -688- MOVE ZEROS TO CONVERSI-NUM-PROPOSTA-SIVPF */
                    _.Move(0, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);

                    /*" -689- ELSE */
                }
                else
                {


                    /*" -691- DISPLAY 'R1050-00 (ERRO - SELECT COVERSAO_SICOB)....' ' NUMBIL : ' V1BILH-NUMBIL */

                    $"R1050-00 (ERRO - SELECT COVERSAO_SICOB).... NUMBIL : {V1BILH_NUMBIL}"
                    .Display();

                    /*" -693- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -694- MOVE CONVERSI-NUM-PROPOSTA-SIVPF TO W-NUM-PROPOSTA. */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF, AREA_DE_WORK.W_NUM_PROPOSTA);

        }

        [StopWatch]
        /*" R1050-00-SELECT-CONVERSI-DB-SELECT-1 */
        public void R1050_00_SELECT_CONVERSI_DB_SELECT_1()
        {
            /*" -682- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :CONVERSI-NUM-PROPOSTA-SIVPF FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB = :V1BILH-NUMBIL END-EXEC. */

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
        /*" R1100-00-SELECT-CONT-REN-BIL-SECTION */
        private void R1100_00_SELECT_CONT_REN_BIL_SECTION()
        {
            /*" -707- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -713- PERFORM R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1 */

            R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1();

            /*" -716- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -717- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -718- MOVE SPACES TO V1CREN-SITUACAO */
                    _.Move("", V1CREN_SITUACAO);

                    /*" -719- ELSE */
                }
                else
                {


                    /*" -721- DISPLAY 'R1100-00 (ERRO - SELECT V1CONT_RENO_BIL)...' ' NUMBIL : ' V1BILH-NUMBIL */

                    $"R1100-00 (ERRO - SELECT V1CONT_RENO_BIL)... NUMBIL : {V1BILH_NUMBIL}"
                    .Display();

                    /*" -721- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-CONT-REN-BIL-DB-SELECT-1 */
        public void R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1()
        {
            /*" -713- EXEC SQL SELECT SITUACAO INTO :V1CREN-SITUACAO FROM SEGUROS.V1CONT_RENO_BIL WHERE NUMBIL = :V1BILH-NUMBIL AND SITUACAO <> '*' END-EXEC. */

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
            /*" -732- MOVE '1150' TO WNR-EXEC-SQL. */
            _.Move("1150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -738- PERFORM R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1 */

            R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1();

            /*" -741- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -742- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -743- DISPLAY 'R1150-00 BILHETE ANTERIOR NAO ENCONTRADO' */
                    _.Display($"R1150-00 BILHETE ANTERIOR NAO ENCONTRADO");

                    /*" -744- DISPLAY 'NUM-BILHETE-ANTERIOR = ' V1BILH-NUM-APOL-ANT */
                    _.Display($"NUM-BILHETE-ANTERIOR = {V1BILH_NUM_APOL_ANT}");

                    /*" -745- DISPLAY 'NUM-BILHETE-RENOVACAO = ' V1BILH-NUMBIL */
                    _.Display($"NUM-BILHETE-RENOVACAO = {V1BILH_NUMBIL}");

                    /*" -746- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -747- ELSE */
                }
                else
                {


                    /*" -748- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -749- DISPLAY 'R1150-00 DUPLICADO - SELECT V0BILHETE ANTERIOR' */
                        _.Display($"R1150-00 DUPLICADO - SELECT V0BILHETE ANTERIOR");

                        /*" -750- DISPLAY 'NUM-BILHETE-ANTERIOR = ' V1BILH-NUM-APOL-ANT */
                        _.Display($"NUM-BILHETE-ANTERIOR = {V1BILH_NUM_APOL_ANT}");

                        /*" -751- DISPLAY 'NUM-BILHETE-RENOVACAO = ' V1BILH-NUMBIL */
                        _.Display($"NUM-BILHETE-RENOVACAO = {V1BILH_NUMBIL}");

                        /*" -752- ELSE */
                    }
                    else
                    {


                        /*" -753- DISPLAY 'R1150-00 ERRO - SELECT V0BILHETE ANTERIOR' */
                        _.Display($"R1150-00 ERRO - SELECT V0BILHETE ANTERIOR");

                        /*" -754- DISPLAY 'NUM-BILHETE-ANTERIOR = ' V1BILH-NUM-APOL-ANT */
                        _.Display($"NUM-BILHETE-ANTERIOR = {V1BILH_NUM_APOL_ANT}");

                        /*" -755- DISPLAY 'NUM-BILHETE-RENOVACAO = ' V1BILH-NUMBIL */
                        _.Display($"NUM-BILHETE-RENOVACAO = {V1BILH_NUMBIL}");

                        /*" -755- GO TO R9999-00-ROT-ERRO. */

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
            /*" -738- EXEC SQL SELECT SITUACAO INTO :V0BILH-ANT-SITUACAO FROM SEGUROS.V0BILHETE WHERE NUMBIL = :V1BILH-NUM-APOL-ANT END-EXEC. */

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
            /*" -765- MOVE V1BILH-NUMBIL TO V0MOVDE-NUM-APOLICE */
            _.Move(V1BILH_NUMBIL, V0MOVDE_NUM_APOLICE);

            /*" -767- MOVE 'D' TO V0MOVDE-SIT-COBRANCA */
            _.Move("D", V0MOVDE_SIT_COBRANCA);

            /*" -787- MOVE 'N' TO WTEM-FERIADO */
            _.Move("N", AREA_DE_WORK.WTEM_FERIADO);

            /*" -790- IF V1BILH-DTQITBCO EQUAL WDATA-BASE OR V1BILH-DTQITBCO EQUAL WDATA-BASE-4 NEXT SENTENCE */

            if (V1BILH_DTQITBCO == WDATA_BASE || V1BILH_DTQITBCO == WDATA_BASE_4)
            {

                /*" -791- ELSE */
            }
            else
            {


                /*" -792- MOVE WDATA-BASE TO WDATA-SQL */
                _.Move(WDATA_BASE, AREA_DE_WORK.WDATA_SQL);

                /*" -793- PERFORM R2501-00-UPDATE-V0BILHETE */

                R2501_00_UPDATE_V0BILHETE_SECTION();

                /*" -795- END-IF. */
            }


            /*" -796- MOVE WDATA-SQL TO V0MOVDE-DTVENCTO */
            _.Move(AREA_DE_WORK.WDATA_SQL, V0MOVDE_DTVENCTO);

            /*" -797- MOVE V1BILH-VLRCAP TO V0MOVDE-VLR-DEBITO */
            _.Move(V1BILH_VLRCAP, V0MOVDE_VLR_DEBITO);

            /*" -798- MOVE V1SIST-DTMOVABE TO V0MOVDE-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0MOVDE_DTMOVTO);

            /*" -799- MOVE WDIA-SQL TO V0MOVDE-DIA-DEBITO */
            _.Move(AREA_DE_WORK.FILLER_1.WDIA_SQL, V0MOVDE_DIA_DEBITO);

            /*" -800- MOVE V1BILH-AGENCIA-DEB TO V0MOVDE-COD-AGE-DEB */
            _.Move(V1BILH_AGENCIA_DEB, V0MOVDE_COD_AGE_DEB);

            /*" -801- MOVE V1BILH-OPERACAO-DEB TO V0MOVDE-OPER-CTA-DEB */
            _.Move(V1BILH_OPERACAO_DEB, V0MOVDE_OPER_CTA_DEB);

            /*" -802- MOVE V1BILH-NUMCTA-DEB TO V0MOVDE-NUM-CTA-DEB */
            _.Move(V1BILH_NUMCTA_DEB, V0MOVDE_NUM_CTA_DEB);

            /*" -804- MOVE V1BILH-DIGCTA-DEB TO V0MOVDE-DIG-CTA-DEB */
            _.Move(V1BILH_DIGCTA_DEB, V0MOVDE_DIG_CTA_DEB);

            /*" -804- MOVE 6114 TO V0MOVDE-COD-CONVENIO. */
            _.Move(6114, V0MOVDE_COD_CONVENIO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V0CALENDARIO-SECTION */
        private void R1300_00_SELECT_V0CALENDARIO_SECTION()
        {
            /*" -816- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -823- PERFORM R1300_00_SELECT_V0CALENDARIO_DB_SELECT_1 */

            R1300_00_SELECT_V0CALENDARIO_DB_SELECT_1();

            /*" -826- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -828- DISPLAY 'DATA NAO ENCONTRADA NA CALENDARIO ' V0CALE-DTMOVTO */
                _.Display($"DATA NAO ENCONTRADA NA CALENDARIO {V0CALE_DTMOVTO}");

                /*" -830- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -831- IF V0CALE-DIASEM EQUAL 'S' OR 'D' */

            if (V0CALE_DIASEM.In("S", "D"))
            {

                /*" -832- MOVE 'S' TO WTEM-FERIADO */
                _.Move("S", AREA_DE_WORK.WTEM_FERIADO);

                /*" -833- ELSE */
            }
            else
            {


                /*" -833- PERFORM R1400-00-SELECT-V0FERIADOS. */

                R1400_00_SELECT_V0FERIADOS_SECTION();
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-V0CALENDARIO-DB-SELECT-1 */
        public void R1300_00_SELECT_V0CALENDARIO_DB_SELECT_1()
        {
            /*" -823- EXEC SQL SELECT DATA_CALENDARIO , DIA_SEMANA INTO :V0CALE-DTMOVTO , :V0CALE-DIASEM FROM SEGUROS.V0CALENDARIO WHERE DATA_CALENDARIO = :V0CALE-DTMOVTO END-EXEC. */

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
            /*" -845- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -855- PERFORM R1400_00_SELECT_V0FERIADOS_DB_SELECT_1 */

            R1400_00_SELECT_V0FERIADOS_DB_SELECT_1();

            /*" -858- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -859- MOVE 'S' TO WTEM-FERIADO */
                _.Move("S", AREA_DE_WORK.WTEM_FERIADO);

                /*" -861- GO TO R1400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -862- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -863- DISPLAY 'R0220-00 - PROBLEMAS NO SELECT(V0FERIADOS)  ' */
                _.Display($"R0220-00 - PROBLEMAS NO SELECT(V0FERIADOS)  ");

                /*" -863- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-V0FERIADOS-DB-SELECT-1 */
        public void R1400_00_SELECT_V0FERIADOS_DB_SELECT_1()
        {
            /*" -855- EXEC SQL SELECT DATA_FERIADO , TIPO_FERIADO , SIT_REGISTRO INTO :V0FERI-DTMOVTO , :V0FERI-TIPO , :V0FERI-SITUACAO FROM SEGUROS.V0FERIADOS WHERE DATA_FERIADO = :V0CALE-DTMOVTO AND SIT_REGISTRO = '0' END-EXEC. */

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
            /*" -875- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -932- PERFORM R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1 */

            R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1();

            /*" -936- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -937- DISPLAY 'PROBLEMA INSERT V0MOVDEBCC_CEF ' */
                _.Display($"PROBLEMA INSERT V0MOVDEBCC_CEF ");

                /*" -938- DISPLAY '(R1500) - APOLICE: ' V0MOVDE-NUM-APOLICE */
                _.Display($"(R1500) - APOLICE: {V0MOVDE_NUM_APOLICE}");

                /*" -940- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -940- ADD 1 TO WACC-GRAVADOS. */
            AREA_DE_WORK.WACC_GRAVADOS.Value = AREA_DE_WORK.WACC_GRAVADOS + 1;

        }

        [StopWatch]
        /*" R1500-00-GRAVA-V0MOVDEBCC-CEF-DB-INSERT-1 */
        public void R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1()
        {
            /*" -932- EXEC SQL INSERT INTO SEGUROS.V0MOVDEBCC_CEF ( COD_EMPRESA ,NUM_APOLICE ,NRENDOS ,NRPARCEL ,SIT_COBRANCA ,DTVENCTO ,VLR_DEBITO ,DTMOVTO ,TIMESTAMP ,DIA_DEBITO ,COD_AGENCIA_DEB ,OPER_CONTA_DEB ,NUM_CONTA_DEB ,DIG_CONTA_DEB ,COD_CONVENIO ,DTENVIO ,DTRETORNO ,COD_RETORNO_CEF ,NSAS ,COD_USUARIO ,NUM_REQUISICAO ,NUM_CARTAO ,SEQUENCIA ,NUM_LOTE ,DTCREDITO ,STATUS_CARTAO ,VLR_CREDITO ) VALUES (0, :V0MOVDE-NUM-APOLICE, 0, 0, :V0MOVDE-SIT-COBRANCA, :V0MOVDE-DTVENCTO, :V0MOVDE-VLR-DEBITO, :V0MOVDE-DTMOVTO, CURRENT TIMESTAMP, :V0MOVDE-DIA-DEBITO, :V0MOVDE-COD-AGE-DEB, :V0MOVDE-OPER-CTA-DEB, :V0MOVDE-NUM-CTA-DEB, :V0MOVDE-DIG-CTA-DEB, :V0MOVDE-COD-CONVENIO, NULL, NULL, NULL, 0, 'BI0032B' , NULL, NULL, NULL, NULL, NULL, NULL, NULL) END-EXEC. */

            var r1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1 = new R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1()
            {
                V0MOVDE_NUM_APOLICE = V0MOVDE_NUM_APOLICE.ToString(),
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
            /*" -952- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -960- PERFORM R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1 */

            R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1();

            /*" -963- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -964- DISPLAY 'R2000 - PROBLEMA UPDATE RELATORIOS ' */
                _.Display($"R2000 - PROBLEMA UPDATE RELATORIOS ");

                /*" -964- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2000-00-UPDATE-V0RELATORIOS-DB-UPDATE-1 */
        public void R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1()
        {
            /*" -960- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE CODRELAT = 'BI0032B' AND SITUACAO = '0' AND NRTIT = :RELATORI-NUM-TITULO END-EXEC. */

            var r2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 = new R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1()
            {
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
            };

            R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1.Execute(r2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-UPDATE-V0BILHETE-SECTION */
        private void R2500_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -976- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -982- PERFORM R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -985- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -987- DISPLAY 'R2500 - PROBLEMA UPDATE V0BILHETE ' V1BILH-NUMBIL */
                _.Display($"R2500 - PROBLEMA UPDATE V0BILHETE {V1BILH_NUMBIL}");

                /*" -987- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2500-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -982- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = '*' , COD_USUARIO = 'BI0032B' WHERE NUMBIL = :V1BILH-NUMBIL AND SITUACAO = '6' END-EXEC. */

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
            /*" -999- MOVE '2501' TO WNR-EXEC-SQL. */
            _.Move("2501", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1004- PERFORM R2501_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R2501_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -1007- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1009- DISPLAY 'R2501 - PROBLEMA UPDATE V0BILHETE ' V1BILH-NUMBIL */
                _.Display($"R2501 - PROBLEMA UPDATE V0BILHETE {V1BILH_NUMBIL}");

                /*" -1009- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2501-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R2501_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -1004- EXEC SQL UPDATE SEGUROS.V0BILHETE SET DTQITBCO = :WDATA-BASE WHERE NUMBIL = :V1BILH-NUMBIL AND SITUACAO = '6' END-EXEC. */

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
            /*" -1019- MOVE '2502' TO WNR-EXEC-SQL. */
            _.Move("2502", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1020- MOVE WDATA-SQL TO GE0006S-DATA-DESTINO. */
            _.Move(AREA_DE_WORK.WDATA_SQL, GE0006S_LINKAGE.GE0006S_DATA_DESTINO);

            /*" -1022- MOVE SPACES TO GE0006S-MENSAGEM. */
            _.Move("", GE0006S_LINKAGE.GE0006S_MENSAGEM);

            /*" -1024- CALL 'GE0006S' USING GE0006S-LINKAGE. */
            _.Call("GE0006S", GE0006S_LINKAGE);

            /*" -1025- IF GE0006S-MENSAGEM EQUAL SPACES */

            if (GE0006S_LINKAGE.GE0006S_MENSAGEM.IsEmpty())
            {

                /*" -1026- MOVE GE0006S-DATA-DESTINO TO WDATA-SQL */
                _.Move(GE0006S_LINKAGE.GE0006S_DATA_DESTINO, AREA_DE_WORK.WDATA_SQL);

                /*" -1027- ELSE */
            }
            else
            {


                /*" -1028- DISPLAY 'PROBLEMA NA ROTINA GE0006S' */
                _.Display($"PROBLEMA NA ROTINA GE0006S");

                /*" -1029- DISPLAY 'MENSAGEM -->' GE0006S-MENSAGEM */
                _.Display($"MENSAGEM -->{GE0006S_LINKAGE.GE0006S_MENSAGEM}");

                /*" -1030- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1032- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2502_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1045- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1047- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1047- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1049- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1053- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1053- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}