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
using Sias.Bilhetes.DB2.BI0033B;

namespace Code
{
    public class BI0033B
    {
        public bool IsCall { get; set; }

        public BI0033B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  BI0033B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FAST COMPUTER                      *      */
        /*"      *   PROGRAMADOR ............  FAST COMPUTER                      *      */
        /*"      *   DATA CODIFICACAO .......  OUTUBRO/2007                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  - GERAR FITA DE MOVTO P/ DEBITO EM *      */
        /*"      *                               CONTA CORRENTE PARA RENOVACAO DE *      */
        /*"      *                               BILHETE SASSE FACIL              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      *                                     V0MOVDEBCC_CEF    I-O      *      */
        /*"      *                                     V0PARAM_CONTACEF  I-O      *      */
        /*"      *                                     V0BILHETE         I-O      *      */
        /*"V.03  *----------------------------------------------------------------*      */
        /*"      *   CADMUS 103.659 - COREON - 01/09/2014                         *      */
        /*"      *   NSGD - NOVA SOLUCAO DE GESTAO DE DEPOSITOS                   *      */
        /*"      *                                                  PROCURE: V.03 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO 19/11/2007 - MARCO PAIVA         -  PROCURAR V.02    *      */
        /*"      *                                                                *      */
        /*"      *     -  CORRECAO DO ABEND OCORRIDO  SQLCODE = -305 NA TABELA    *      */
        /*"      *            MOVTO_DEBITOCC_CEF.                                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO 09/04/2007 - TERCIO CARVALHO     -  PROCURAR TL0704  *      */
        /*"      *                                                                *      */
        /*"      *     -  O PROGRAMA PASSA A NAO MAIS AJUSTAR A DATA DE           *      */
        /*"      *            VENCIMENTO UMA VEZ QUE O PROGRAMA BI0030B JA O FAZ. *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO 29/05/2002 - TERCIO CARVALHO     -  PROCURAR TL0205  *      */
        /*"      *                                                                *      */
        /*"      *     -  O PROGRAMA PASSA A TRATAR LANCAMENTOS COM MENOS DE      *      */
        /*"      *            3 DIAS UTEIS FAZENDO A PRORROGACAO DO MESMO.        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO 07/03/2001 - ENRICO (PRODEXTER)  -  PROCURAR EB0703  *      */
        /*"      *                                                                *      */
        /*"      *     -  CORRECAO DOS "DISPLAYS" DE CONTROLE                     *      */
        /*"      *            DATA DA GERACAO DA FITA                             *      */
        /*"      *            DATA DO PROXIMO DEBITO                              *      */
        /*"      *            DATA DO VENCIMENTO                                  *      */
        /*"      *                                                                *      */
        /*"      *     -  SUBSTITUIR DATA DO SISTEMA "RN" PELA DATA CORRENTE      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO  .............  - ALTERACAO DA COLUNA COD_CONVENIO *      */
        /*"      *                               DE SMALLINT PARA INTEGER.        *      */
        /*"      *               LIANE PONTES  -  LP0301   EM:  14/03/2001.       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _MOVDEBITO_CC { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis MOVDEBITO_CC
        {
            get
            {
                _.Move(HEADER_REGISTRO, _MOVDEBITO_CC); VarBasis.RedefinePassValue(HEADER_REGISTRO, _MOVDEBITO_CC, HEADER_REGISTRO); return _MOVDEBITO_CC;
            }
        }
        public FileBasis _RBI0033B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RBI0033B
        {
            get
            {
                _.Move(REG_BI0033B, _RBI0033B); VarBasis.RedefinePassValue(REG_BI0033B, _RBI0033B, REG_BI0033B); return _RBI0033B;
            }
        }
        /*"01        HEADER-REGISTRO.*/
        public BI0033B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new BI0033B_HEADER_REGISTRO();
        public class BI0033B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTRO  PIC  X(001).*/
            public StringBasis HEADER_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODREMESSA   PIC  9(001).*/
            public IntBasis HEADER_CODREMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      HEADER-CODCONVENIO  PIC  X(020).*/
            public StringBasis HEADER_CODCONVENIO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-NOMEMPRESA   PIC  X(020).*/
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-CODBANCO     PIC  9(003).*/
            public IntBasis HEADER_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      HEADER-NOMBANCO     PIC  X(020).*/
            public StringBasis HEADER_NOMBANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-DATGERACAO   PIC  9(008).*/
            public IntBasis HEADER_DATGERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      HEADER-NSA          PIC  9(006).*/
            public IntBasis HEADER_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      HEADER-VERSAO       PIC  9(002).*/
            public IntBasis HEADER_VERSAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      HEADER-DEBITOAUT    PIC  X(017).*/
            public StringBasis HEADER_DEBITOAUT { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"  05      HEADER-FILLER       PIC  X(052).*/
            public StringBasis HEADER_FILLER { get; set; } = new StringBasis(new PIC("X", "52", "X(052)."), @"");
            /*"01        MOVCC-REGISTRO.*/
        }
        public BI0033B_MOVCC_REGISTRO MOVCC_REGISTRO { get; set; } = new BI0033B_MOVCC_REGISTRO();
        public class BI0033B_MOVCC_REGISTRO : VarBasis
        {
            /*"  05      MOVCC-CODREGISTRO  PIC  X(001).*/
            public StringBasis MOVCC_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-IDTCLIEMP    PIC  X(025).*/
            public StringBasis MOVCC_IDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"  05      MOVCC-AGEDEBITO    PIC  X(004).*/
            public StringBasis MOVCC_AGEDEBITO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05      MOVCC-IDTCLIBAN    PIC  X(019).*/
            public StringBasis MOVCC_IDTCLIBAN { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
            /*"  05      MOVCC-DTVENCTO     PIC  9(008).*/
            public IntBasis MOVCC_DTVENCTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      MOVCC-VLRDEBITO    PIC  9(013)V99.*/
            public DoubleBasis MOVCC_VLRDEBITO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      MOVCC-CODMOEDA     PIC  X(002).*/
            public StringBasis MOVCC_CODMOEDA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      MOVCC-USOEMPRESA   PIC  X(058).*/
            public StringBasis MOVCC_USOEMPRESA { get; set; } = new StringBasis(new PIC("X", "58", "X(058)."), @"");
            /*"  05      MOVCC-FILLER       PIC  X(017).*/
            public StringBasis MOVCC_FILLER { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"  05      MOVCC-CODMOVTO     PIC  9(001).*/
            public IntBasis MOVCC_CODMOVTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01        TRAILL-REGISTRO.*/
        }
        public BI0033B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new BI0033B_TRAILL_REGISTRO();
        public class BI0033B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTRO  PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-TOTREGISTRO  PIC  9(006).*/
            public IntBasis TRAILL_TOTREGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      TRAILL-VLRTOTDEB    PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTDEB { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      TRAILL-VLRTOTCRE    PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTCRE { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      TRAILL-FILLER       PIC  X(109).*/
            public StringBasis TRAILL_FILLER { get; set; } = new StringBasis(new PIC("X", "109", "X(109)."), @"");
            /*"01        REG-BI0033B        PIC  X(132).*/
        }
        public StringBasis REG_BI0033B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  V1SISTE-DTMOVABE             PIC X(10).*/
        public StringBasis V1SISTE_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTE-DTMOVABE-10          PIC X(10).*/
        public StringBasis V1SISTE_DTMOVABE_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTE-DTCURRENT            PIC X(10).*/
        public StringBasis V1SISTE_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTE-DTMOVABE-FI          PIC X(10).*/
        public StringBasis V1SISTE_DTMOVABE_FI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1EMPR-COD-EMP               PIC S9(004)     COMP.*/
        public IntBasis V1EMPR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1EMPR-NOM-EMP               PIC  X(040).*/
        public StringBasis V1EMPR_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  V0MOVDE-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0MOVDE_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MOVDE-SIT-COBRANCA         PIC X(1).*/
        public StringBasis V0MOVDE_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0MOVDE-DTVENCTO             PIC X(10).*/
        public StringBasis V0MOVDE_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-DIA-DEBITO           PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-VLR-DEBITO           PIC S9(13)V9(2) COMP-3.*/
        public DoubleBasis V0MOVDE_VLR_DEBITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V0MOVDE-COD-AGENCIA-DEB      PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-OPER-CONTA-DEB       PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_OPER_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-NUM-CONTA-DEB        PIC S9(13) COMP-3.*/
        public IntBasis V0MOVDE_NUM_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MOVDE-DIG-CONTA-DEB        PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_DIG_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-COD-CONVENIO         PIC S9(09) COMP.*/
        public IntBasis V0MOVDE_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MOVDE-DTMOVTO              PIC X(10).*/
        public StringBasis V0MOVDE_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-DTENVIO              PIC X(10).*/
        public StringBasis V0MOVDE_DTENVIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-DTRETORNO            PIC X(10).*/
        public StringBasis V0MOVDE_DTRETORNO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-COD-RETORNO-CEF      PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_COD_RETORNO_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-NSAS                 PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-DAYS                 PIC S9(09) COMP.*/
        public IntBasis V0MOVDE_DAYS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0PARAMC-TIPO-MOVTOCC         PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_TIPO_MOVTOCC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-CODPRODU             PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-COD-CONVENIO         PIC S9(09) COMP.*/
        public IntBasis V0PARAMC_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0PARAMC-NSAS                 PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-COD-AGENCIA-SASS     PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_COD_AGENCIA_SASS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-DTPROX-DEB           PIC X(10).*/
        public StringBasis V0PARAMC_DTPROX_DEB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0PARAMC-DIA-DEBITO           PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-SITUACAO             PIC X(1).*/
        public StringBasis V0PARAMC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0BILH-NUMBIL                 PIC S9(15) COMP-3.*/
        public IntBasis V0BILH_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0BILH-SITUACAO               PIC  X(01).*/
        public StringBasis V0BILH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V1BILH-NUMBIL                 PIC S9(15) COMP-3.*/
        public IntBasis V1BILH_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V1BILH-SITUACAO               PIC  X(01).*/
        public StringBasis V1BILH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V1BILH-COD-CLIENTE            PIC S9(09) COMP.*/
        public IntBasis V1BILH_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1CLIEN-COD-CLIENTE          PIC S9(09) COMP.*/
        public IntBasis V1CLIEN_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1CLIEN-NOME-RAZAO           PIC  X(40).*/
        public StringBasis V1CLIEN_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01           AREA-DE-WORK.*/
        public BI0033B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new BI0033B_AREA_DE_WORK();
        public class BI0033B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WS-NSAS              PIC S9(04) COMP.*/
            public IntBasis WS_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         WS-SEQUENCIA         PIC S9(04) COMP.*/
            public IntBasis WS_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         WS-REQUISICAO        PIC S9(04) COMP.*/
            public IntBasis WS_REQUISICAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         WFIMV1SISTEMA        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIMV1BILHETE        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV1BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-MOVDEBCE        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_MOVDEBCE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIMV0PARAM-CONTACEF PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV0PARAM_CONTACEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIMV0MOVDEBCC-CEF   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV0MOVDEBCC_CEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WPAG                 PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WPAG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WLIN                 PIC  9(009)    VALUE 90.*/
            public IntBasis WLIN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"), 90);
            /*"  05         WTOTPARAMC           PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WTOTPARAMC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WTOTMOVDE            PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WTOTMOVDE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WTOTREG              PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WTOTREG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WTOTGER              PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WTOTGER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WTOTDEB              PIC  9(016)V99 VALUE ZEROS.*/
            public DoubleBasis WTOTDEB { get; set; } = new DoubleBasis(new PIC("9", "16", "9(016)V99"), 2);
            /*"  05         WCOD-CONVENIO        PIC S9(004) COMP VALUE ZEROS.*/
            public IntBasis WCOD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WDATSIS              PIC  9(008)    VALUE ZEROS.*/
            public IntBasis WDATSIS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         WNSAS                PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WNSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WIDTCLIBAN           PIC   X(019).*/
            public StringBasis WIDTCLIBAN { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
            /*"  05         FILLER        REDEFINES    WIDTCLIBAN.*/
            private _REDEF_BI0033B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_BI0033B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_BI0033B_FILLER_0(); _.Move(WIDTCLIBAN, _filler_0); VarBasis.RedefinePassValue(WIDTCLIBAN, _filler_0, WIDTCLIBAN); _filler_0.ValueChanged += () => { _.Move(_filler_0, WIDTCLIBAN); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WIDTCLIBAN); }
            }  //Redefines
            public class _REDEF_BI0033B_FILLER_0 : VarBasis
            {
                /*"     10      WOPER-CONTA          PIC   9(004).*/
                public IntBasis WOPER_CONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10      WNUM-CONTA           PIC   9(012).*/
                public IntBasis WNUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"     10      WDIG-CONTA           PIC   9(001).*/
                public IntBasis WDIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"     10      WIDT-SPACES          PIC   X(002).*/
                public StringBasis WIDT_SPACES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05         WIDTCLIEMP           PIC  X(025).*/

                public _REDEF_BI0033B_FILLER_0()
                {
                    WOPER_CONTA.ValueChanged += OnValueChanged;
                    WNUM_CONTA.ValueChanged += OnValueChanged;
                    WDIG_CONTA.ValueChanged += OnValueChanged;
                    WIDT_SPACES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WIDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"  05         FILLER        REDEFINES   WIDTCLIEMP.*/
            private _REDEF_BI0033B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI0033B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI0033B_FILLER_1(); _.Move(WIDTCLIEMP, _filler_1); VarBasis.RedefinePassValue(WIDTCLIEMP, _filler_1, WIDTCLIEMP); _filler_1.ValueChanged += () => { _.Move(_filler_1, WIDTCLIEMP); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WIDTCLIEMP); }
            }  //Redefines
            public class _REDEF_BI0033B_FILLER_1 : VarBasis
            {
                /*"     10      WNUMBIL              PIC   9(015).*/
                public IntBasis WNUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"     10      WEMP-SPACES          PIC   X(010).*/
                public StringBasis WEMP_SPACES { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  05         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/

                public _REDEF_BI0033B_FILLER_1()
                {
                    WNUMBIL.ValueChanged += OnValueChanged;
                    WEMP_SPACES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_BI0033B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_BI0033B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_BI0033B_FILLER_2(); _.Move(WDATA_CURR, _filler_2); VarBasis.RedefinePassValue(WDATA_CURR, _filler_2, WDATA_CURR); _filler_2.ValueChanged += () => { _.Move(_filler_2, WDATA_CURR); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_BI0033B_FILLER_2 : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WHORA-CURR.*/

                public _REDEF_BI0033B_FILLER_2()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public BI0033B_WHORA_CURR WHORA_CURR { get; set; } = new BI0033B_WHORA_CURR();
            public class BI0033B_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-CC-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CABEC.*/
            }
            public BI0033B_WDATA_CABEC WDATA_CABEC { get; set; } = new BI0033B_WDATA_CABEC();
            public class BI0033B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WHORA-CABEC.*/
            }
            public BI0033B_WHORA_CABEC WHORA_CABEC { get; set; } = new BI0033B_WHORA_CABEC();
            public class BI0033B_WHORA_CABEC : VarBasis
            {
                /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WUSOEMPRESA          PIC  X(060).*/
            }
            public StringBasis WUSOEMPRESA { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
            /*"  05         FILLER        REDEFINES   WUSOEMPRESA.*/
            private _REDEF_BI0033B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_BI0033B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_BI0033B_FILLER_9(); _.Move(WUSOEMPRESA, _filler_9); VarBasis.RedefinePassValue(WUSOEMPRESA, _filler_9, WUSOEMPRESA); _filler_9.ValueChanged += () => { _.Move(_filler_9, WUSOEMPRESA); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, WUSOEMPRESA); }
            }  //Redefines
            public class _REDEF_BI0033B_FILLER_9 : VarBasis
            {
                /*"     10      WUSO-CONVENIO        PIC   9(006).*/
                public IntBasis WUSO_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"     10      WUSO-NSAS            PIC   9(006).*/
                public IntBasis WUSO_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"     10      WUSO-SEQFITA         PIC   9(006).*/
                public IntBasis WUSO_SEQFITA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"     10      WUSO-SPACES          PIC   X(042).*/
                public StringBasis WUSO_SPACES { get; set; } = new StringBasis(new PIC("X", "42", "X(042)."), @"");
                /*"  05         WDATA-DEBITO         PIC   X(010).*/

                public _REDEF_BI0033B_FILLER_9()
                {
                    WUSO_CONVENIO.ValueChanged += OnValueChanged;
                    WUSO_NSAS.ValueChanged += OnValueChanged;
                    WUSO_SEQFITA.ValueChanged += OnValueChanged;
                    WUSO_SPACES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_DEBITO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         WDATA-SQL            PIC   X(010).*/
            public StringBasis WDATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         FILLER        REDEFINES   WDATA-SQL.*/
            private _REDEF_BI0033B_FILLER_10 _filler_10 { get; set; }
            public _REDEF_BI0033B_FILLER_10 FILLER_10
            {
                get { _filler_10 = new _REDEF_BI0033B_FILLER_10(); _.Move(WDATA_SQL, _filler_10); VarBasis.RedefinePassValue(WDATA_SQL, _filler_10, WDATA_SQL); _filler_10.ValueChanged += () => { _.Move(_filler_10, WDATA_SQL); }; return _filler_10; }
                set { VarBasis.RedefinePassValue(value, _filler_10, WDATA_SQL); }
            }  //Redefines
            public class _REDEF_BI0033B_FILLER_10 : VarBasis
            {
                /*"     10      WANO-SQL             PIC   9(004).*/
                public IntBasis WANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10      FILLER               PIC   X(001).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10      WMES-SQL             PIC   9(002).*/
                public IntBasis WMES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10      FILLER               PIC   X(001).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10      WDIA-SQL             PIC   9(002).*/
                public IntBasis WDIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATATRA             PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_BI0033B_FILLER_10()
                {
                    WANO_SQL.ValueChanged += OnValueChanged;
                    FILLER_11.ValueChanged += OnValueChanged;
                    WMES_SQL.ValueChanged += OnValueChanged;
                    FILLER_12.ValueChanged += OnValueChanged;
                    WDIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATATRA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER        REDEFINES   WDATATRA.*/
            private _REDEF_BI0033B_FILLER_13 _filler_13 { get; set; }
            public _REDEF_BI0033B_FILLER_13 FILLER_13
            {
                get { _filler_13 = new _REDEF_BI0033B_FILLER_13(); _.Move(WDATATRA, _filler_13); VarBasis.RedefinePassValue(WDATATRA, _filler_13, WDATATRA); _filler_13.ValueChanged += () => { _.Move(_filler_13, WDATATRA); }; return _filler_13; }
                set { VarBasis.RedefinePassValue(value, _filler_13, WDATATRA); }
            }  //Redefines
            public class _REDEF_BI0033B_FILLER_13 : VarBasis
            {
                /*"     10      WANO-TRA            PIC   9(004).*/
                public IntBasis WANO_TRA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10      WMES-TRA            PIC   9(002).*/
                public IntBasis WMES_TRA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10      WDIA-TRA            PIC   9(002).*/
                public IntBasis WDIA_TRA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-DISPLAY        PIC   X(010).*/

                public _REDEF_BI0033B_FILLER_13()
                {
                    WANO_TRA.ValueChanged += OnValueChanged;
                    WMES_TRA.ValueChanged += OnValueChanged;
                    WDIA_TRA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_DISPLAY { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         LPARM.*/
            public BI0033B_LPARM LPARM { get; set; } = new BI0033B_LPARM();
            public class BI0033B_LPARM : VarBasis
            {
                /*"    10       DATA1.*/
                public BI0033B_DATA1 DATA1 { get; set; } = new BI0033B_DATA1();
                public class BI0033B_DATA1 : VarBasis
                {
                    /*"      15     DATA1-DD          PIC  9(002).*/
                    public IntBasis DATA1_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     DATA1-MM          PIC  9(002).*/
                    public IntBasis DATA1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     DATA1-AA          PIC  9(004).*/
                    public IntBasis DATA1_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10       RESPOSTA          PIC  X(001).*/
                }
                public StringBasis RESPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05         LPARM2.*/
            }
            public BI0033B_LPARM2 LPARM2 { get; set; } = new BI0033B_LPARM2();
            public class BI0033B_LPARM2 : VarBasis
            {
                /*"    10       DATA2             PIC  9(008).*/
                public IntBasis DATA2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10       DATA2-R           REDEFINES             DATA2.*/
                private _REDEF_BI0033B_DATA2_R _data2_r { get; set; }
                public _REDEF_BI0033B_DATA2_R DATA2_R
                {
                    get { _data2_r = new _REDEF_BI0033B_DATA2_R(); _.Move(DATA2, _data2_r); VarBasis.RedefinePassValue(DATA2, _data2_r, DATA2); _data2_r.ValueChanged += () => { _.Move(_data2_r, DATA2); }; return _data2_r; }
                    set { VarBasis.RedefinePassValue(value, _data2_r, DATA2); }
                }  //Redefines
                public class _REDEF_BI0033B_DATA2_R : VarBasis
                {
                    /*"      15     DATA2-DD          PIC  X(002).*/
                    public StringBasis DATA2_DD { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     DATA2-MM          PIC  X(002).*/
                    public StringBasis DATA2_MM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     DATA2-AA          PIC  X(004).*/
                    public StringBasis DATA2_AA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"    10       QUANTIDA          PIC S9(005)  COMP-3  VALUE +1.*/

                    public _REDEF_BI0033B_DATA2_R()
                    {
                        DATA2_DD.ValueChanged += OnValueChanged;
                        DATA2_MM.ValueChanged += OnValueChanged;
                        DATA2_AA.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis QUANTIDA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"), +1);
                /*"    10       DATA3             PIC  9(008).*/
                public IntBasis DATA3 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10       DATA3-R           REDEFINES             DATA3.*/
                private _REDEF_BI0033B_DATA3_R _data3_r { get; set; }
                public _REDEF_BI0033B_DATA3_R DATA3_R
                {
                    get { _data3_r = new _REDEF_BI0033B_DATA3_R(); _.Move(DATA3, _data3_r); VarBasis.RedefinePassValue(DATA3, _data3_r, DATA3); _data3_r.ValueChanged += () => { _.Move(_data3_r, DATA3); }; return _data3_r; }
                    set { VarBasis.RedefinePassValue(value, _data3_r, DATA3); }
                }  //Redefines
                public class _REDEF_BI0033B_DATA3_R : VarBasis
                {
                    /*"      15     DATA3-DD          PIC  X(002).*/
                    public StringBasis DATA3_DD { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     DATA3-MM          PIC  X(002).*/
                    public StringBasis DATA3_MM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     DATA3-AA          PIC  X(004).*/
                    public StringBasis DATA3_AA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"  05            LC01.*/

                    public _REDEF_BI0033B_DATA3_R()
                    {
                        DATA3_DD.ValueChanged += OnValueChanged;
                        DATA3_MM.ValueChanged += OnValueChanged;
                        DATA3_AA.ValueChanged += OnValueChanged;
                    }

                }
            }
            public BI0033B_LC01 LC01 { get; set; } = new BI0033B_LC01();
            public class BI0033B_LC01 : VarBasis
            {
                /*"    10          LC01-RELATORIO  PIC  X(007) VALUE 'BI0033B'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"BI0033B");
                /*"    10          FILLER          PIC  X(036) VALUE  SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    10          LC01-EMPRESA    PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10          FILLER          PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    10          FILLER          PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    10          LC01-PAGINA     PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  05            LC02.*/
            }
            public BI0033B_LC02 LC02 { get; set; } = new BI0033B_LC02();
            public class BI0033B_LC02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    10          FILLER          PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    10          LC02-DATA       PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public BI0033B_LC03 LC03 { get; set; } = new BI0033B_LC03();
            public class BI0033B_LC03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(025) VALUE  SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    10          FILLER          PIC  X(053) VALUE               'RELACAO DE DOCUMENTOS ENVIADOS PELA FITA DE ESTOR               'NO- '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"RELACAO DE DOCUMENTOS ENVIADOS PELA FITA DE ESTOR               ");
                /*"    10          FILLER          PIC  X(018) VALUE 'C.E.F.'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"C.E.F.");
                /*"    10          FILLER          PIC  X(003) VALUE 'EM'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"EM");
                /*"    10          LC03-DATA       PIC  X(010).*/
                public StringBasis LC03_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER          PIC  X(008) VALUE  SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10          FILLER          PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    10          LC03-HORA       PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public BI0033B_LC04 LC04 { get; set; } = new BI0033B_LC04();
            public class BI0033B_LC04 : VarBasis
            {
                /*"    10          FILLER          PIC  X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05            LC05.*/
            }
            public BI0033B_LC05 LC05 { get; set; } = new BI0033B_LC05();
            public class BI0033B_LC05 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048)  VALUE      '          APOLICE    ENDOSSO PARC DT.VENC. DIA'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"          APOLICE    ENDOSSO PARC DT.VENC. DIA");
                /*"    10          FILLER          PIC  X(026)  VALUE      '-- C/C DEBITADA --'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"-- C/C DEBITADA --");
                /*"    10          FILLER          PIC  X(050)  VALUE      'NOME DO SEGURADO'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"NOME DO SEGURADO");
                /*"    10          FILLER          PIC  X(005)  VALUE      'VALOR'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"VALOR");
                /*"  05            LC06.*/
            }
            public BI0033B_LC06 LC06 { get; set; } = new BI0033B_LC06();
            public class BI0033B_LC06 : VarBasis
            {
                /*"    10          FILLER          PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          FILLER          PIC  X(011) VALUE    'FITA  NR.: '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"FITA  NR.: ");
                /*"    10          LC06-NRFITA     PIC  ZZZZZZZZZ9.*/
                public IntBasis LC06_NRFITA { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZZZZ9."));
                /*"  05            LC07.*/
            }
            public BI0033B_LC07 LC07 { get; set; } = new BI0033B_LC07();
            public class BI0033B_LC07 : VarBasis
            {
                /*"    10          FILLER          PIC  X(132) VALUE  ALL ' '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05            LD01.*/
            }
            public BI0033B_LD01 LD01 { get; set; } = new BI0033B_LD01();
            public class BI0033B_LD01 : VarBasis
            {
                /*"    10          FILLER          PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10          LD01-NUMBIL     PIC  9(013).*/
                public IntBasis LD01_NUMBIL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-NRENDOS    PIC  9(009).*/
                public IntBasis LD01_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-NRPARCEL   PIC  9(002).*/
                public IntBasis LD01_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-DTVENCTO   PIC  X(010).*/
                public StringBasis LD01_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-DIA-DEBITO PIC  9(002).*/
                public IntBasis LD01_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-DEBITO.*/
                public BI0033B_LD01_DEBITO LD01_DEBITO { get; set; } = new BI0033B_LD01_DEBITO();
                public class BI0033B_LD01_DEBITO : VarBasis
                {
                    /*"      15        LD01-AGENCIA    PIC  9(004).*/
                    public IntBasis LD01_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15        FILLER          PIC  X(001) VALUE SPACES.*/
                    public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      15        LD01-OPERACAO   PIC  9(004).*/
                    public IntBasis LD01_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15        LD01-BARRA      PIC  X(001).*/
                    public StringBasis LD01_BARRA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15        LD01-CONTA      PIC  9(012).*/
                    public IntBasis LD01_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                    /*"      15        LD01-HIFEN1     PIC  X(001).*/
                    public StringBasis LD01_HIFEN1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15        LD01-DIGITO     PIC  X(001).*/
                    public StringBasis LD01_DIGITO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                }
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-NOME       PIC  X(040).*/
                public StringBasis LD01_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-VLDEBITO   PIC  ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLDEBITO { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"  05            LD02.*/
            }
            public BI0033B_LD02 LD02 { get; set; } = new BI0033B_LD02();
            public class BI0033B_LD02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE ALL '*'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"ALL");
                /*"  05            LD03.*/
            }
            public BI0033B_LD03 LD03 { get; set; } = new BI0033B_LD03();
            public class BI0033B_LD03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE    '*  NAO HOUVE MOVIMENTO NESTA DATA  *'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"*  NAO HOUVE MOVIMENTO NESTA DATA  *");
                /*"  05            LD04.*/
            }
            public BI0033B_LD04 LD04 { get; set; } = new BI0033B_LD04();
            public class BI0033B_LD04 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE    '*                                  *'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"*                                  *");
                /*"  05            LT01.*/
            }
            public BI0033B_LT01 LT01 { get; set; } = new BI0033B_LT01();
            public class BI0033B_LT01 : VarBasis
            {
                /*"    10          FILLER          PIC  X(074) VALUE SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "74", "X(074)"), @"");
                /*"    10          FILLER          PIC  X(026) VALUE 'TOTAIS'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"TOTAIS");
                /*"    10          LT01-QT-TOTAL   PIC  ZZZZ.ZZ9.*/
                public IntBasis LT01_QT_TOTAL { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ.ZZ9."));
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LT01-VL-TOTAL   PIC  ZZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_VL_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"  05        WABEND.*/
            }
            public BI0033B_WABEND WABEND { get; set; } = new BI0033B_WABEND();
            public class BI0033B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' BI0033B'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI0033B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"  05        WPARAGRAFO          PIC  X(040)    VALUE SPACES.*/
            }
            public StringBasis WPARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"01          LK-LINK.*/
        }
        public BI0033B_LK_LINK LK_LINK { get; set; } = new BI0033B_LK_LINK();
        public class BI0033B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public BI0033B_V0PARAMC V0PARAMC { get; set; } = new BI0033B_V0PARAMC();
        public BI0033B_V0MOVDE V0MOVDE { get; set; } = new BI0033B_V0MOVDE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVDEBITO_CC_FILE_NAME_P, string RBI0033B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVDEBITO_CC.SetFile(MOVDEBITO_CC_FILE_NAME_P);
                RBI0033B.SetFile(RBI0033B_FILE_NAME_P);

                /*" -460- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -463- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -466- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -469- ACCEPT WHORA-CURR FROM TIME. */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -470- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
                _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

                /*" -471- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
                _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

                /*" -472- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
                _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

                /*" -472- MOVE WHORA-CABEC TO LC03-HORA. */
                _.Move(AREA_DE_WORK.WHORA_CABEC, AREA_DE_WORK.LC03.LC03_HORA);

                /*" -472- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -481- ACCEPT WDATSIS FROM DATE */
            _.Move(_.AcceptDate("DATE"), AREA_DE_WORK.WDATSIS);

            /*" -483- OPEN OUTPUT MOVDEBITO-CC RBI0033B */
            MOVDEBITO_CC.Open(HEADER_REGISTRO);
            RBI0033B.Open(REG_BI0033B);

            /*" -484- PERFORM R0010-00-SELECT-V1SISTEMA */

            R0010_00_SELECT_V1SISTEMA_SECTION();

            /*" -485- IF WFIMV1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIMV1SISTEMA.IsEmpty())
            {

                /*" -487- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -489- PERFORM R0015-00-MONTA-V1EMPRESA */

            R0015_00_MONTA_V1EMPRESA_SECTION();

            /*" -490- PERFORM R0020-00-DECLARE-V0PARAM-CONTA */

            R0020_00_DECLARE_V0PARAM_CONTA_SECTION();

            /*" -491- PERFORM R0060-00-LE-V0PARAM-CONTACEF */

            R0060_00_LE_V0PARAM_CONTACEF_SECTION();

            /*" -492- IF WFIMV0PARAM-CONTACEF EQUAL 'S' */

            if (AREA_DE_WORK.WFIMV0PARAM_CONTACEF == "S")
            {

                /*" -494- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -497- PERFORM R0050-00-PROCE-V0PARAM-CONTA UNTIL WFIMV0PARAM-CONTACEF EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIMV0PARAM_CONTACEF == "S"))
            {

                R0050_00_PROCE_V0PARAM_CONTA_SECTION();
            }

            /*" -498- IF WTOTMOVDE GREATER ZEROS */

            if (AREA_DE_WORK.WTOTMOVDE > 00)
            {

                /*" -499- PERFORM R0080-00-REGISTRO-TRAILLER */

                R0080_00_REGISTRO_TRAILLER_SECTION();

                /*" -499- PERFORM R0170-00-TOTALIZADOR. */

                R0170_00_TOTALIZADOR_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -504- IF WTOTMOVDE GREATER ZEROS */

            if (AREA_DE_WORK.WTOTMOVDE > 00)
            {

                /*" -506- DISPLAY '*** BI0033B *** DATA GERACAO DA FITA ' WDATSIS */
                _.Display($"*** BI0033B *** DATA GERACAO DA FITA {AREA_DE_WORK.WDATSIS}");

                /*" -508- DISPLAY '*** BI0033B *** DATA DO DEBITO       ' WDATA-DISPLAY */
                _.Display($"*** BI0033B *** DATA DO DEBITO       {AREA_DE_WORK.WDATA_DISPLAY}");

                /*" -510- DISPLAY '*** BI0033B *** QUANTIDADE           ' WTOTREG */
                _.Display($"*** BI0033B *** QUANTIDADE           {AREA_DE_WORK.WTOTREG}");

                /*" -512- DISPLAY '*** BI0033B *** VALOR TOTAL          ' WTOTDEB */
                _.Display($"*** BI0033B *** VALOR TOTAL          {AREA_DE_WORK.WTOTDEB}");

                /*" -514- DISPLAY '*** BI0033B *** NSA                  ' WNSAS */
                _.Display($"*** BI0033B *** NSA                  {AREA_DE_WORK.WNSAS}");

                /*" -515- DISPLAY ' ' */
                _.Display($" ");

                /*" -516- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -517- DISPLAY '*                                   *' */
                _.Display($"*                                   *");

                /*" -518- DISPLAY '* BI0033B - TERMINO NORMAL DE       *' */
                _.Display($"* BI0033B - TERMINO NORMAL DE       *");

                /*" -519- DISPLAY '*             PROCESSAMENTO         *' */
                _.Display($"*             PROCESSAMENTO         *");

                /*" -520- DISPLAY '*                                   *' */
                _.Display($"*                                   *");

                /*" -521- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -522- ELSE */
            }
            else
            {


                /*" -523- PERFORM R0160-00-CABECALHOS */

                R0160_00_CABECALHOS_SECTION();

                /*" -524- PERFORM R0180-00-RELAT-SEM-MOVTO */

                R0180_00_RELAT_SEM_MOVTO_SECTION();

                /*" -525- DISPLAY '******************************' */
                _.Display($"******************************");

                /*" -526- DISPLAY '* BI0033B - SEM MOVIMENTACAO *' */
                _.Display($"* BI0033B - SEM MOVIMENTACAO *");

                /*" -528- DISPLAY '******************************' . */
                _.Display($"******************************");
            }


            /*" -530- CLOSE MOVDEBITO-CC */
            MOVDEBITO_CC.Close();

            /*" -530- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -532- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -532- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECT-V1SISTEMA-SECTION */
        private void R0010_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -542- MOVE 'R0010-00-SELECT-V1SISTEMA' TO WPARAGRAFO */
            _.Move("R0010-00-SELECT-V1SISTEMA", AREA_DE_WORK.WPARAGRAFO);

            /*" -544- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -550- PERFORM R0010_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0010_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -553- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -554- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -555- DISPLAY 'BI0033B - SISTEMA (CB) NAO CADASTRADO' */
                    _.Display($"BI0033B - SISTEMA (CB) NAO CADASTRADO");

                    /*" -556- MOVE 'S' TO WFIMV1SISTEMA */
                    _.Move("S", AREA_DE_WORK.WFIMV1SISTEMA);

                    /*" -557- ELSE */
                }
                else
                {


                    /*" -558- DISPLAY 'BI0033B - ' WPARAGRAFO */
                    _.Display($"BI0033B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -560- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -561- MOVE V1SISTE-DTCURRENT TO WDATA-CURR */
            _.Move(V1SISTE_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -562- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_2.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -563- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_2.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -564- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_2.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -564- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC02.LC02_DATA);

        }

        [StopWatch]
        /*" R0010-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0010_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -550- EXEC SQL SELECT DTMOVABE, CURRENT DATE, DTMOVABE + 10 DAYS INTO :V1SISTE-DTMOVABE, :V1SISTE-DTCURRENT, :V1SISTE-DTMOVABE-10 FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'RN' END-EXEC. */

            var r0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SISTE_DTMOVABE, V1SISTE_DTMOVABE);
                _.Move(executed_1.V1SISTE_DTCURRENT, V1SISTE_DTCURRENT);
                _.Move(executed_1.V1SISTE_DTMOVABE_10, V1SISTE_DTMOVABE_10);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0015-00-MONTA-V1EMPRESA-SECTION */
        private void R0015_00_MONTA_V1EMPRESA_SECTION()
        {
            /*" -574- MOVE 'R0015-00-MONTA-V1EMPRESA' TO WPARAGRAFO */
            _.Move("R0015-00-MONTA-V1EMPRESA", AREA_DE_WORK.WPARAGRAFO);

            /*" -576- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -580- PERFORM R0015_00_MONTA_V1EMPRESA_DB_SELECT_1 */

            R0015_00_MONTA_V1EMPRESA_DB_SELECT_1();

            /*" -583- MOVE V1EMPR-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPR_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -585- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -586- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -587- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, AREA_DE_WORK.LC01.LC01_EMPRESA);

                /*" -588- ELSE */
            }
            else
            {


                /*" -589- DISPLAY 'PROBLEMA CALL V0EMPRESA' */
                _.Display($"PROBLEMA CALL V0EMPRESA");

                /*" -589- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" R0015-00-MONTA-V1EMPRESA-DB-SELECT-1 */
        public void R0015_00_MONTA_V1EMPRESA_DB_SELECT_1()
        {
            /*" -580- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPR-NOM-EMP FROM SEGUROS.V0EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var r0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1 = new R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1.Execute(r0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPR_NOM_EMP, V1EMPR_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0015_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-DECLARE-V0PARAM-CONTA-SECTION */
        private void R0020_00_DECLARE_V0PARAM_CONTA_SECTION()
        {
            /*" -598- MOVE 'R0020-00-DECLARE-V0PARAM-CONTA' TO WPARAGRAFO */
            _.Move("R0020-00-DECLARE-V0PARAM-CONTA", AREA_DE_WORK.WPARAGRAFO);

            /*" -600- MOVE '020' TO WNR-EXEC-SQL */
            _.Move("020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -601- MOVE 01 TO V0PARAMC-TIPO-MOVTOCC */
            _.Move(01, V0PARAMC_TIPO_MOVTOCC);

            /*" -603- MOVE 'A' TO V0PARAMC-SITUACAO */
            _.Move("A", V0PARAMC_SITUACAO);

            /*" -617- PERFORM R0020_00_DECLARE_V0PARAM_CONTA_DB_DECLARE_1 */

            R0020_00_DECLARE_V0PARAM_CONTA_DB_DECLARE_1();

            /*" -619- PERFORM R0020_00_DECLARE_V0PARAM_CONTA_DB_OPEN_1 */

            R0020_00_DECLARE_V0PARAM_CONTA_DB_OPEN_1();

            /*" -622- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -623- DISPLAY 'BI0033B - ' WPARAGRAFO */
                _.Display($"BI0033B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -624- DISPLAY 'PROBLEMAS DECLARE V0PARAM_CONTACEF' */
                _.Display($"PROBLEMAS DECLARE V0PARAM_CONTACEF");

                /*" -624- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0020-00-DECLARE-V0PARAM-CONTA-DB-DECLARE-1 */
        public void R0020_00_DECLARE_V0PARAM_CONTA_DB_DECLARE_1()
        {
            /*" -617- EXEC SQL DECLARE V0PARAMC CURSOR FOR SELECT TIPO_MOVTOCC, CODPRODU, COD_CONVENIO, NSAS, COD_AGENCIA_SASS, DTPROX_DEB, DIA_DEBITO FROM SEGUROS.V0PARAM_CONTACEF WHERE TIPO_MOVTOCC = :V0PARAMC-TIPO-MOVTOCC AND SITUACAO = :V0PARAMC-SITUACAO AND COD_CONVENIO = 6114 AND CODPRODU = 7106 ORDER BY COD_CONVENIO END-EXEC. */
            V0PARAMC = new BI0033B_V0PARAMC(true);
            string GetQuery_V0PARAMC()
            {
                var query = @$"SELECT TIPO_MOVTOCC
							, 
							CODPRODU
							, 
							COD_CONVENIO
							, 
							NSAS
							, 
							COD_AGENCIA_SASS
							, 
							DTPROX_DEB
							, 
							DIA_DEBITO 
							FROM SEGUROS.V0PARAM_CONTACEF 
							WHERE TIPO_MOVTOCC = '{V0PARAMC_TIPO_MOVTOCC}' 
							AND SITUACAO = '{V0PARAMC_SITUACAO}' 
							AND COD_CONVENIO = 6114 
							AND CODPRODU = 7106 
							ORDER BY COD_CONVENIO";

                return query;
            }
            V0PARAMC.GetQueryEvent += GetQuery_V0PARAMC;

        }

        [StopWatch]
        /*" R0020-00-DECLARE-V0PARAM-CONTA-DB-OPEN-1 */
        public void R0020_00_DECLARE_V0PARAM_CONTA_DB_OPEN_1()
        {
            /*" -619- EXEC SQL OPEN V0PARAMC END-EXEC. */

            V0PARAMC.Open();

        }

        [StopWatch]
        /*" R0065-00-DECLARE-V0MOVDEBCC-DB-DECLARE-1 */
        public void R0065_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1()
        {
            /*" -728- EXEC SQL DECLARE V0MOVDE CURSOR FOR SELECT A.COD_CONVENIO, A.COD_AGENCIA_DEB, A.OPER_CONTA_DEB, A.NUM_CONTA_DEB, A.DIG_CONTA_DEB, A.DTVENCTO, A.VLR_DEBITO, A.NUM_APOLICE, A.DIA_DEBITO, DAYS(A.DTVENCTO) - DAYS(CURRENT DATE) FROM SEGUROS.V0MOVDEBCC_CEF A WHERE A.SIT_COBRANCA = :V0MOVDE-SIT-COBRANCA AND A.COD_CONVENIO = :V0PARAMC-COD-CONVENIO ORDER BY A.COD_CONVENIO, A.DTVENCTO , A.NUM_APOLICE END-EXEC. */
            V0MOVDE = new BI0033B_V0MOVDE(true);
            string GetQuery_V0MOVDE()
            {
                var query = @$"SELECT 
							A.COD_CONVENIO
							, 
							A.COD_AGENCIA_DEB
							, 
							A.OPER_CONTA_DEB
							, 
							A.NUM_CONTA_DEB
							, 
							A.DIG_CONTA_DEB
							, 
							A.DTVENCTO
							, 
							A.VLR_DEBITO
							, 
							A.NUM_APOLICE
							, 
							A.DIA_DEBITO
							, 
							DAYS(A.DTVENCTO) - DAYS(CURRENT DATE) 
							FROM SEGUROS.V0MOVDEBCC_CEF A 
							WHERE A.SIT_COBRANCA = '{V0MOVDE_SIT_COBRANCA}' 
							AND A.COD_CONVENIO = '{V0PARAMC_COD_CONVENIO}' 
							ORDER BY A.COD_CONVENIO
							, 
							A.DTVENCTO
							, 
							A.NUM_APOLICE";

                return query;
            }
            V0MOVDE.GetQueryEvent += GetQuery_V0MOVDE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-PROCE-V0PARAM-CONTA-SECTION */
        private void R0050_00_PROCE_V0PARAM_CONTA_SECTION()
        {
            /*" -633- DISPLAY 'GERACAO DO MOVTO DE DEBITO EM CONTA *****' */
            _.Display($"GERACAO DO MOVTO DE DEBITO EM CONTA *****");

            /*" -634- DISPLAY 'PROCESSANDO PRODUTO = ' V0PARAMC-CODPRODU */
            _.Display($"PROCESSANDO PRODUTO = {V0PARAMC_CODPRODU}");

            /*" -636- DISPLAY 'DATA DO VENCIMENTO  = ' V0PARAMC-DTPROX-DEB */
            _.Display($"DATA DO VENCIMENTO  = {V0PARAMC_DTPROX_DEB}");

            /*" -638- MOVE V0PARAMC-DTPROX-DEB TO WDATA-DEBITO. */
            _.Move(V0PARAMC_DTPROX_DEB, AREA_DE_WORK.WDATA_DEBITO);

            /*" -639- PERFORM R0065-00-DECLARE-V0MOVDEBCC */

            R0065_00_DECLARE_V0MOVDEBCC_SECTION();

            /*" -641- PERFORM R0110-00-LE-V0MOVDEBCC-CEF */

            R0110_00_LE_V0MOVDEBCC_CEF_SECTION();

            /*" -644- PERFORM R0100-00-PROCESSA-V0MOVDEBCC UNTIL WFIMV0MOVDEBCC-CEF EQUAL 'S' */

            while (!(AREA_DE_WORK.WFIMV0MOVDEBCC_CEF == "S"))
            {

                R0100_00_PROCESSA_V0MOVDEBCC_SECTION();
            }

            /*" -646- PERFORM R0130-00-UPDATE-V0PARAM-CONTA. */

            R0130_00_UPDATE_V0PARAM_CONTA_SECTION();

            /*" -646- PERFORM R0060-00-LE-V0PARAM-CONTACEF. */

            R0060_00_LE_V0PARAM_CONTACEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0060-00-LE-V0PARAM-CONTACEF-SECTION */
        private void R0060_00_LE_V0PARAM_CONTACEF_SECTION()
        {
            /*" -655- MOVE 'R0060-00-LE-V0PARAM-CONTA-CEF' TO WPARAGRAFO */
            _.Move("R0060-00-LE-V0PARAM-CONTA-CEF", AREA_DE_WORK.WPARAGRAFO);

            /*" -657- MOVE '060' TO WNR-EXEC-SQL */
            _.Move("060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -665- PERFORM R0060_00_LE_V0PARAM_CONTACEF_DB_FETCH_1 */

            R0060_00_LE_V0PARAM_CONTACEF_DB_FETCH_1();

            /*" -668- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -669- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -670- MOVE 'S' TO WFIMV0PARAM-CONTACEF */
                    _.Move("S", AREA_DE_WORK.WFIMV0PARAM_CONTACEF);

                    /*" -670- PERFORM R0060_00_LE_V0PARAM_CONTACEF_DB_CLOSE_1 */

                    R0060_00_LE_V0PARAM_CONTACEF_DB_CLOSE_1();

                    /*" -672- GO TO R0060-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_99_SAIDA*/ //GOTO
                    return;

                    /*" -673- ELSE */
                }
                else
                {


                    /*" -674- DISPLAY 'BI0033B - ' WPARAGRAFO */
                    _.Display($"BI0033B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -676- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -677- IF WCOD-CONVENIO EQUAL ZEROS */

            if (AREA_DE_WORK.WCOD_CONVENIO == 00)
            {

                /*" -678- MOVE V0PARAMC-DTPROX-DEB TO WDATA-DISPLAY */
                _.Move(V0PARAMC_DTPROX_DEB, AREA_DE_WORK.WDATA_DISPLAY);

                /*" -688- MOVE V0PARAMC-COD-CONVENIO TO WCOD-CONVENIO. */
                _.Move(V0PARAMC_COD_CONVENIO, AREA_DE_WORK.WCOD_CONVENIO);
            }


            /*" -689- MOVE V0PARAMC-DTPROX-DEB TO WDATA-SQL */
            _.Move(V0PARAMC_DTPROX_DEB, AREA_DE_WORK.WDATA_SQL);

            /*" -690- MOVE WDIA-SQL TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.FILLER_10.WDIA_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -691- MOVE WMES-SQL TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.FILLER_10.WMES_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -692- MOVE WANO-SQL TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.FILLER_10.WANO_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -694- MOVE WDATA-CABEC TO LC03-DATA */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC03.LC03_DATA);

            /*" -694- COMPUTE WTOTPARAMC = WTOTPARAMC + 1. */
            AREA_DE_WORK.WTOTPARAMC.Value = AREA_DE_WORK.WTOTPARAMC + 1;

        }

        [StopWatch]
        /*" R0060-00-LE-V0PARAM-CONTACEF-DB-FETCH-1 */
        public void R0060_00_LE_V0PARAM_CONTACEF_DB_FETCH_1()
        {
            /*" -665- EXEC SQL FETCH V0PARAMC INTO :V0PARAMC-TIPO-MOVTOCC, :V0PARAMC-CODPRODU, :V0PARAMC-COD-CONVENIO, :V0PARAMC-NSAS, :V0PARAMC-COD-AGENCIA-SASS, :V0PARAMC-DTPROX-DEB, :V0PARAMC-DIA-DEBITO END-EXEC. */

            if (V0PARAMC.Fetch())
            {
                _.Move(V0PARAMC.V0PARAMC_TIPO_MOVTOCC, V0PARAMC_TIPO_MOVTOCC);
                _.Move(V0PARAMC.V0PARAMC_CODPRODU, V0PARAMC_CODPRODU);
                _.Move(V0PARAMC.V0PARAMC_COD_CONVENIO, V0PARAMC_COD_CONVENIO);
                _.Move(V0PARAMC.V0PARAMC_NSAS, V0PARAMC_NSAS);
                _.Move(V0PARAMC.V0PARAMC_COD_AGENCIA_SASS, V0PARAMC_COD_AGENCIA_SASS);
                _.Move(V0PARAMC.V0PARAMC_DTPROX_DEB, V0PARAMC_DTPROX_DEB);
                _.Move(V0PARAMC.V0PARAMC_DIA_DEBITO, V0PARAMC_DIA_DEBITO);
            }

        }

        [StopWatch]
        /*" R0060-00-LE-V0PARAM-CONTACEF-DB-CLOSE-1 */
        public void R0060_00_LE_V0PARAM_CONTACEF_DB_CLOSE_1()
        {
            /*" -670- EXEC SQL CLOSE V0PARAMC END-EXEC */

            V0PARAMC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_99_SAIDA*/

        [StopWatch]
        /*" R0065-00-DECLARE-V0MOVDEBCC-SECTION */
        private void R0065_00_DECLARE_V0MOVDEBCC_SECTION()
        {
            /*" -703- MOVE 'R0065-00-DECLARE-V0MOVDEBCC' TO WPARAGRAFO */
            _.Move("R0065-00-DECLARE-V0MOVDEBCC", AREA_DE_WORK.WPARAGRAFO);

            /*" -706- MOVE '065' TO WNR-EXEC-SQL */
            _.Move("065", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -707- MOVE 'D' TO V0MOVDE-SIT-COBRANCA */
            _.Move("D", V0MOVDE_SIT_COBRANCA);

            /*" -709- MOVE 'N' TO WFIMV0MOVDEBCC-CEF */
            _.Move("N", AREA_DE_WORK.WFIMV0MOVDEBCC_CEF);

            /*" -728- PERFORM R0065_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1 */

            R0065_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1();

            /*" -730- PERFORM R0065_00_DECLARE_V0MOVDEBCC_DB_OPEN_1 */

            R0065_00_DECLARE_V0MOVDEBCC_DB_OPEN_1();

            /*" -733- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -734- DISPLAY 'BI0033B - ' WPARAGRAFO */
                _.Display($"BI0033B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -735- DISPLAY 'PROBLEMAS OPEN V0MOVDEBCC_CEF ' */
                _.Display($"PROBLEMAS OPEN V0MOVDEBCC_CEF ");

                /*" -735- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0065-00-DECLARE-V0MOVDEBCC-DB-OPEN-1 */
        public void R0065_00_DECLARE_V0MOVDEBCC_DB_OPEN_1()
        {
            /*" -730- EXEC SQL OPEN V0MOVDE END-EXEC. */

            V0MOVDE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0065_99_SAIDA*/

        [StopWatch]
        /*" R0070-00-REGISTRO-HEADER-SECTION */
        private void R0070_00_REGISTRO_HEADER_SECTION()
        {
            /*" -744- MOVE ALL SPACES TO HEADER-REGISTRO */
            _.MoveAll("", HEADER_REGISTRO);

            /*" -745- MOVE 'A' TO HEADER-CODREGISTRO */
            _.Move("A", HEADER_REGISTRO.HEADER_CODREGISTRO);

            /*" -746- MOVE 1 TO HEADER-CODREMESSA */
            _.Move(1, HEADER_REGISTRO.HEADER_CODREMESSA);

            /*" -747- MOVE 600114 TO HEADER-CODCONVENIO */
            _.Move(600114, HEADER_REGISTRO.HEADER_CODCONVENIO);

            /*" -748- MOVE 'CAIXA SEGURO FACIL' TO HEADER-NOMEMPRESA */
            _.Move("CAIXA SEGURO FACIL", HEADER_REGISTRO.HEADER_NOMEMPRESA);

            /*" -749- MOVE 104 TO HEADER-CODBANCO */
            _.Move(104, HEADER_REGISTRO.HEADER_CODBANCO);

            /*" -750- MOVE 'CEF' TO HEADER-NOMBANCO */
            _.Move("CEF", HEADER_REGISTRO.HEADER_NOMBANCO);

            /*" -751- MOVE V1SISTE-DTCURRENT TO WDATA-SQL */
            _.Move(V1SISTE_DTCURRENT, AREA_DE_WORK.WDATA_SQL);

            /*" -752- MOVE WANO-SQL TO WANO-TRA */
            _.Move(AREA_DE_WORK.FILLER_10.WANO_SQL, AREA_DE_WORK.FILLER_13.WANO_TRA);

            /*" -753- MOVE WMES-SQL TO WMES-TRA */
            _.Move(AREA_DE_WORK.FILLER_10.WMES_SQL, AREA_DE_WORK.FILLER_13.WMES_TRA);

            /*" -754- MOVE WDIA-SQL TO WDIA-TRA */
            _.Move(AREA_DE_WORK.FILLER_10.WDIA_SQL, AREA_DE_WORK.FILLER_13.WDIA_TRA);

            /*" -757- MOVE WDATATRA TO HEADER-DATGERACAO WDATSIS. */
            _.Move(AREA_DE_WORK.WDATATRA, HEADER_REGISTRO.HEADER_DATGERACAO, AREA_DE_WORK.WDATSIS);

            /*" -758- IF WTOTMOVDE NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WTOTMOVDE != 00)
            {

                /*" -760- ADD 1 TO V0PARAMC-NSAS. */
                V0PARAMC_NSAS.Value = V0PARAMC_NSAS + 1;
            }


            /*" -762- MOVE V0PARAMC-NSAS TO HEADER-NSA WNSAS */
            _.Move(V0PARAMC_NSAS, HEADER_REGISTRO.HEADER_NSA, AREA_DE_WORK.WNSAS);

            /*" -763- MOVE 04 TO HEADER-VERSAO */
            _.Move(04, HEADER_REGISTRO.HEADER_VERSAO);

            /*" -764- MOVE 'DEB/CRED AUTOMAT' TO HEADER-DEBITOAUT */
            _.Move("DEB/CRED AUTOMAT", HEADER_REGISTRO.HEADER_DEBITOAUT);

            /*" -766- MOVE ALL SPACES TO HEADER-FILLER */
            _.MoveAll("", HEADER_REGISTRO.HEADER_FILLER);

            /*" -766- WRITE HEADER-REGISTRO. */
            MOVDEBITO_CC.Write(HEADER_REGISTRO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_99_SAIDA*/

        [StopWatch]
        /*" R0080-00-REGISTRO-TRAILLER-SECTION */
        private void R0080_00_REGISTRO_TRAILLER_SECTION()
        {
            /*" -775- MOVE 'R0080-00-REGISTRO-TRAILLER' TO WPARAGRAFO */
            _.Move("R0080-00-REGISTRO-TRAILLER", AREA_DE_WORK.WPARAGRAFO);

            /*" -777- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -778- MOVE ALL SPACES TO TRAILL-REGISTRO */
            _.MoveAll("", TRAILL_REGISTRO);

            /*" -779- MOVE 'Z' TO TRAILL-CODREGISTRO */
            _.Move("Z", TRAILL_REGISTRO.TRAILL_CODREGISTRO);

            /*" -780- COMPUTE WTOTREG = WTOTREG + 2 */
            AREA_DE_WORK.WTOTREG.Value = AREA_DE_WORK.WTOTREG + 2;

            /*" -781- MOVE WTOTREG TO TRAILL-TOTREGISTRO */
            _.Move(AREA_DE_WORK.WTOTREG, TRAILL_REGISTRO.TRAILL_TOTREGISTRO);

            /*" -782- MOVE WTOTDEB TO TRAILL-VLRTOTDEB */
            _.Move(AREA_DE_WORK.WTOTDEB, TRAILL_REGISTRO.TRAILL_VLRTOTDEB);

            /*" -783- MOVE ZEROS TO TRAILL-VLRTOTCRE */
            _.Move(0, TRAILL_REGISTRO.TRAILL_VLRTOTCRE);

            /*" -784- MOVE ALL SPACES TO TRAILL-FILLER */
            _.MoveAll("", TRAILL_REGISTRO.TRAILL_FILLER);

            /*" -784- WRITE TRAILL-REGISTRO. */
            MOVDEBITO_CC.Write(TRAILL_REGISTRO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-PROCESSA-V0MOVDEBCC-SECTION */
        private void R0100_00_PROCESSA_V0MOVDEBCC_SECTION()
        {
            /*" -793- IF WTOTMOVDE EQUAL 1 */

            if (AREA_DE_WORK.WTOTMOVDE == 1)
            {

                /*" -795- PERFORM R0070-00-REGISTRO-HEADER. */

                R0070_00_REGISTRO_HEADER_SECTION();
            }


            /*" -796- PERFORM R0117-00-SELECT-MOVDEBCE */

            R0117_00_SELECT_MOVDEBCE_SECTION();

            /*" -797- IF WFIM-MOVDEBCE EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_MOVDEBCE == "S")
            {

                /*" -798- GO TO R1000-10-LEITURA */

                R1000_10_LEITURA(); //GOTO
                return;

                /*" -799- END-IF. */
            }


            /*" -800- PERFORM R0120-00-REGISTRO-E */

            R0120_00_REGISTRO_E_SECTION();

            /*" -801- PERFORM R0125-00-RELATORIO */

            R0125_00_RELATORIO_SECTION();

            /*" -802- PERFORM R0140-00-UPDATE-V0MOVDEBCC-CEF */

            R0140_00_UPDATE_V0MOVDEBCC_CEF_SECTION();

            /*" -802- PERFORM R0150-00-UPDATE-V0BILHETE. */

            R0150_00_UPDATE_V0BILHETE_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_10_LEITURA */

            R1000_10_LEITURA();

        }

        [StopWatch]
        /*" R1000-10-LEITURA */
        private void R1000_10_LEITURA(bool isPerform = false)
        {
            /*" -805- PERFORM R0110-00-LE-V0MOVDEBCC-CEF. */

            R0110_00_LE_V0MOVDEBCC_CEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-LE-V0MOVDEBCC-CEF-SECTION */
        private void R0110_00_LE_V0MOVDEBCC_CEF_SECTION()
        {
            /*" -814- MOVE 'R0110-00-LE-V0MOVDEBCC-CEF' TO WPARAGRAFO */
            _.Move("R0110-00-LE-V0MOVDEBCC-CEF", AREA_DE_WORK.WPARAGRAFO);

            /*" -814- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0110_10_LE_MOVDEBCC */

            R0110_10_LE_MOVDEBCC();

        }

        [StopWatch]
        /*" R0110-10-LE-MOVDEBCC */
        private void R0110_10_LE_MOVDEBCC(bool isPerform = false)
        {
            /*" -830- PERFORM R0110_10_LE_MOVDEBCC_DB_FETCH_1 */

            R0110_10_LE_MOVDEBCC_DB_FETCH_1();

            /*" -833- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -834- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -835- MOVE 'S' TO WFIMV0MOVDEBCC-CEF */
                    _.Move("S", AREA_DE_WORK.WFIMV0MOVDEBCC_CEF);

                    /*" -835- PERFORM R0110_10_LE_MOVDEBCC_DB_CLOSE_1 */

                    R0110_10_LE_MOVDEBCC_DB_CLOSE_1();

                    /*" -837- GO TO R0110-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/ //GOTO
                    return;

                    /*" -838- ELSE */
                }
                else
                {


                    /*" -839- DISPLAY 'BI0033B - ' WPARAGRAFO */
                    _.Display($"BI0033B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -841- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -842- IF V0MOVDE-VLR-DEBITO IS NEGATIVE */

            if (V0MOVDE_VLR_DEBITO < 0)
            {

                /*" -844- GO TO R0110-10-LE-MOVDEBCC. */
                new Task(() => R0110_10_LE_MOVDEBCC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -845- MOVE V0MOVDE-NUM-APOLICE TO V1BILH-NUMBIL */
            _.Move(V0MOVDE_NUM_APOLICE, V1BILH_NUMBIL);

            /*" -847- MOVE '5' TO V1BILH-SITUACAO */
            _.Move("5", V1BILH_SITUACAO);

            /*" -852- PERFORM R0115-00-LE-V1BILHETE */

            R0115_00_LE_V1BILHETE_SECTION();

            /*" -853- COMPUTE WTOTMOVDE = WTOTMOVDE + 1 */
            AREA_DE_WORK.WTOTMOVDE.Value = AREA_DE_WORK.WTOTMOVDE + 1;

            /*" -854- COMPUTE WTOTREG = WTOTREG + 1 */
            AREA_DE_WORK.WTOTREG.Value = AREA_DE_WORK.WTOTREG + 1;

            /*" -855- COMPUTE WTOTGER = WTOTGER + 1 */
            AREA_DE_WORK.WTOTGER.Value = AREA_DE_WORK.WTOTGER + 1;

            /*" -855- COMPUTE WTOTDEB = WTOTDEB + V0MOVDE-VLR-DEBITO. */
            AREA_DE_WORK.WTOTDEB.Value = AREA_DE_WORK.WTOTDEB + V0MOVDE_VLR_DEBITO;

        }

        [StopWatch]
        /*" R0110-10-LE-MOVDEBCC-DB-FETCH-1 */
        public void R0110_10_LE_MOVDEBCC_DB_FETCH_1()
        {
            /*" -830- EXEC SQL FETCH V0MOVDE INTO :V0MOVDE-COD-CONVENIO, :V0MOVDE-COD-AGENCIA-DEB, :V0MOVDE-OPER-CONTA-DEB, :V0MOVDE-NUM-CONTA-DEB, :V0MOVDE-DIG-CONTA-DEB, :V0MOVDE-DTVENCTO, :V0MOVDE-VLR-DEBITO, :V0MOVDE-NUM-APOLICE, :V0MOVDE-DIA-DEBITO, :V0MOVDE-DAYS END-EXEC. */

            if (V0MOVDE.Fetch())
            {
                _.Move(V0MOVDE.V0MOVDE_COD_CONVENIO, V0MOVDE_COD_CONVENIO);
                _.Move(V0MOVDE.V0MOVDE_COD_AGENCIA_DEB, V0MOVDE_COD_AGENCIA_DEB);
                _.Move(V0MOVDE.V0MOVDE_OPER_CONTA_DEB, V0MOVDE_OPER_CONTA_DEB);
                _.Move(V0MOVDE.V0MOVDE_NUM_CONTA_DEB, V0MOVDE_NUM_CONTA_DEB);
                _.Move(V0MOVDE.V0MOVDE_DIG_CONTA_DEB, V0MOVDE_DIG_CONTA_DEB);
                _.Move(V0MOVDE.V0MOVDE_DTVENCTO, V0MOVDE_DTVENCTO);
                _.Move(V0MOVDE.V0MOVDE_VLR_DEBITO, V0MOVDE_VLR_DEBITO);
                _.Move(V0MOVDE.V0MOVDE_NUM_APOLICE, V0MOVDE_NUM_APOLICE);
                _.Move(V0MOVDE.V0MOVDE_DIA_DEBITO, V0MOVDE_DIA_DEBITO);
                _.Move(V0MOVDE.V0MOVDE_DAYS, V0MOVDE_DAYS);
            }

        }

        [StopWatch]
        /*" R0110-10-LE-MOVDEBCC-DB-CLOSE-1 */
        public void R0110_10_LE_MOVDEBCC_DB_CLOSE_1()
        {
            /*" -835- EXEC SQL CLOSE V0MOVDE END-EXEC */

            V0MOVDE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0115-00-LE-V1BILHETE-SECTION */
        private void R0115_00_LE_V1BILHETE_SECTION()
        {
            /*" -864- MOVE 'R0115-00-LE-V1BILHETE ' TO WPARAGRAFO */
            _.Move("R0115-00-LE-V1BILHETE ", AREA_DE_WORK.WPARAGRAFO);

            /*" -866- MOVE '115' TO WNR-EXEC-SQL. */
            _.Move("115", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -874- PERFORM R0115_00_LE_V1BILHETE_DB_SELECT_1 */

            R0115_00_LE_V1BILHETE_DB_SELECT_1();

            /*" -877- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -878- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -879- MOVE 'S' TO WFIMV1BILHETE */
                    _.Move("S", AREA_DE_WORK.WFIMV1BILHETE);

                    /*" -880- ELSE */
                }
                else
                {


                    /*" -881- DISPLAY 'BI0033B - ' WPARAGRAFO */
                    _.Display($"BI0033B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -882- DISPLAY 'V0MOVDE-NUM-APOLICE ' V0MOVDE-NUM-APOLICE */
                    _.Display($"V0MOVDE-NUM-APOLICE {V0MOVDE_NUM_APOLICE}");

                    /*" -882- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0115-00-LE-V1BILHETE-DB-SELECT-1 */
        public void R0115_00_LE_V1BILHETE_DB_SELECT_1()
        {
            /*" -874- EXEC SQL SELECT NUMBIL, CODCLIEN INTO :V1BILH-NUMBIL, :V1BILH-COD-CLIENTE FROM SEGUROS.V0BILHETE WHERE NUMBIL = :V1BILH-NUMBIL AND SITUACAO = :V1BILH-SITUACAO END-EXEC. */

            var r0115_00_LE_V1BILHETE_DB_SELECT_1_Query1 = new R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1()
            {
                V1BILH_SITUACAO = V1BILH_SITUACAO.ToString(),
                V1BILH_NUMBIL = V1BILH_NUMBIL.ToString(),
            };

            var executed_1 = R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1.Execute(r0115_00_LE_V1BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILH_NUMBIL, V1BILH_NUMBIL);
                _.Move(executed_1.V1BILH_COD_CLIENTE, V1BILH_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0115_99_SAIDA*/

        [StopWatch]
        /*" R0117-00-SELECT-MOVDEBCE-SECTION */
        private void R0117_00_SELECT_MOVDEBCE_SECTION()
        {
            /*" -891- MOVE 'R0117-00-SELECT-MOVDEBCE' TO WPARAGRAFO */
            _.Move("R0117-00-SELECT-MOVDEBCE", AREA_DE_WORK.WPARAGRAFO);

            /*" -892- MOVE '117' TO WNR-EXEC-SQL. */
            _.Move("117", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -894- MOVE SPACES TO WFIM-MOVDEBCE. */
            _.Move("", AREA_DE_WORK.WFIM_MOVDEBCE);

            /*" -918- PERFORM R0117_00_SELECT_MOVDEBCE_DB_SELECT_1 */

            R0117_00_SELECT_MOVDEBCE_DB_SELECT_1();

            /*" -921- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -922- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -923- MOVE 'S' TO WFIM-MOVDEBCE */
                    _.Move("S", AREA_DE_WORK.WFIM_MOVDEBCE);

                    /*" -924- ELSE */
                }
                else
                {


                    /*" -925- DISPLAY 'BI0033B - ' WPARAGRAFO */
                    _.Display($"BI0033B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -926- DISPLAY 'V0MOVDE-NUM-APOLICE ' V0MOVDE-NUM-APOLICE */
                    _.Display($"V0MOVDE-NUM-APOLICE {V0MOVDE_NUM_APOLICE}");

                    /*" -928- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -929- IF WS-NSAS < + 0 */

            if (AREA_DE_WORK.WS_NSAS < +0)
            {

                /*" -930- MOVE ZEROS TO MOVDEBCE-NSAS */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

                /*" -932- END-IF. */
            }


            /*" -933- IF WS-SEQUENCIA < + 0 */

            if (AREA_DE_WORK.WS_SEQUENCIA < +0)
            {

                /*" -934- MOVE ZEROS TO MOVDEBCE-SEQUENCIA */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA);

                /*" -936- END-IF. */
            }


            /*" -937- IF WS-REQUISICAO < + 0 */

            if (AREA_DE_WORK.WS_REQUISICAO < +0)
            {

                /*" -938- MOVE ZEROS TO MOVDEBCE-NUM-REQUISICAO */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);

                /*" -938- END-IF. */
            }


        }

        [StopWatch]
        /*" R0117-00-SELECT-MOVDEBCE-DB-SELECT-1 */
        public void R0117_00_SELECT_MOVDEBCE_DB_SELECT_1()
        {
            /*" -918- EXEC SQL SELECT NUM_APOLICE , COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , DATA_VENCIMENTO , VALOR_DEBITO , NSAS , SEQUENCIA , NUM_REQUISICAO INTO :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-COD-AGENCIA-DEB , :MOVDEBCE-OPER-CONTA-DEB , :MOVDEBCE-NUM-CONTA-DEB , :MOVDEBCE-DIG-CONTA-DEB , :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-VALOR-DEBITO , :MOVDEBCE-NSAS:WS-NSAS , :MOVDEBCE-SEQUENCIA:WS-SEQUENCIA, :MOVDEBCE-NUM-REQUISICAO:WS-REQUISICAO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :V0MOVDE-NUM-APOLICE AND SITUACAO_COBRANCA = '1' END-EXEC. */

            var r0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 = new R0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1()
            {
                V0MOVDE_NUM_APOLICE = V0MOVDE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1.Execute(r0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(executed_1.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(executed_1.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(executed_1.MOVDEBCE_VALOR_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);
                _.Move(executed_1.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
                _.Move(executed_1.WS_NSAS, AREA_DE_WORK.WS_NSAS);
                _.Move(executed_1.MOVDEBCE_SEQUENCIA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA);
                _.Move(executed_1.WS_SEQUENCIA, AREA_DE_WORK.WS_SEQUENCIA);
                _.Move(executed_1.MOVDEBCE_NUM_REQUISICAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);
                _.Move(executed_1.WS_REQUISICAO, AREA_DE_WORK.WS_REQUISICAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0117_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-REGISTRO-E-SECTION */
        private void R0120_00_REGISTRO_E_SECTION()
        {
            /*" -948- MOVE 'R0120-00-REGISTRO-E ' TO WPARAGRAFO */
            _.Move("R0120-00-REGISTRO-E ", AREA_DE_WORK.WPARAGRAFO);

            /*" -950- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -951- MOVE ALL SPACES TO MOVCC-REGISTRO */
            _.MoveAll("", MOVCC_REGISTRO);

            /*" -953- MOVE 'E' TO MOVCC-CODREGISTRO */
            _.Move("E", MOVCC_REGISTRO.MOVCC_CODREGISTRO);

            /*" -954- MOVE MOVDEBCE-NUM-APOLICE TO WNUMBIL */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, AREA_DE_WORK.FILLER_1.WNUMBIL);

            /*" -955- MOVE ALL SPACES TO WEMP-SPACES */
            _.MoveAll("", AREA_DE_WORK.FILLER_1.WEMP_SPACES);

            /*" -957- MOVE WIDTCLIEMP TO MOVCC-IDTCLIEMP */
            _.Move(AREA_DE_WORK.WIDTCLIEMP, MOVCC_REGISTRO.MOVCC_IDTCLIEMP);

            /*" -959- MOVE MOVDEBCE-COD-AGENCIA-DEB TO MOVCC-AGEDEBITO */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, MOVCC_REGISTRO.MOVCC_AGEDEBITO);

            /*" -960- MOVE MOVDEBCE-OPER-CONTA-DEB TO WOPER-CONTA */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, AREA_DE_WORK.FILLER_0.WOPER_CONTA);

            /*" -961- MOVE MOVDEBCE-NUM-CONTA-DEB TO WNUM-CONTA */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, AREA_DE_WORK.FILLER_0.WNUM_CONTA);

            /*" -962- MOVE MOVDEBCE-DIG-CONTA-DEB TO WDIG-CONTA */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB, AREA_DE_WORK.FILLER_0.WDIG_CONTA);

            /*" -963- MOVE ALL SPACES TO WIDT-SPACES */
            _.MoveAll("", AREA_DE_WORK.FILLER_0.WIDT_SPACES);

            /*" -965- MOVE WIDTCLIBAN TO MOVCC-IDTCLIBAN */
            _.Move(AREA_DE_WORK.WIDTCLIBAN, MOVCC_REGISTRO.MOVCC_IDTCLIBAN);

            /*" -967- MOVE MOVDEBCE-DATA-VENCIMENTO TO WDATA-SQL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, AREA_DE_WORK.WDATA_SQL);

            /*" -968- MOVE WANO-SQL TO WANO-TRA */
            _.Move(AREA_DE_WORK.FILLER_10.WANO_SQL, AREA_DE_WORK.FILLER_13.WANO_TRA);

            /*" -969- MOVE WMES-SQL TO WMES-TRA */
            _.Move(AREA_DE_WORK.FILLER_10.WMES_SQL, AREA_DE_WORK.FILLER_13.WMES_TRA);

            /*" -970- MOVE WDIA-SQL TO WDIA-TRA */
            _.Move(AREA_DE_WORK.FILLER_10.WDIA_SQL, AREA_DE_WORK.FILLER_13.WDIA_TRA);

            /*" -972- MOVE WDATATRA TO MOVCC-DTVENCTO */
            _.Move(AREA_DE_WORK.WDATATRA, MOVCC_REGISTRO.MOVCC_DTVENCTO);

            /*" -973- MOVE MOVDEBCE-VALOR-DEBITO TO MOVCC-VLRDEBITO */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO, MOVCC_REGISTRO.MOVCC_VLRDEBITO);

            /*" -975- MOVE ZEROS TO MOVCC-CODMOEDA */
            _.Move(0, MOVCC_REGISTRO.MOVCC_CODMOEDA);

            /*" -977- MOVE 600114 TO WUSO-CONVENIO */
            _.Move(600114, AREA_DE_WORK.FILLER_9.WUSO_CONVENIO);

            /*" -979- MOVE MOVDEBCE-NSAS TO WUSO-NSAS */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, AREA_DE_WORK.FILLER_9.WUSO_NSAS);

            /*" -980- MOVE MOVDEBCE-NUM-REQUISICAO TO WUSO-SEQFITA */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO, AREA_DE_WORK.FILLER_9.WUSO_SEQFITA);

            /*" -981- MOVE ALL SPACES TO WUSO-SPACES */
            _.MoveAll("", AREA_DE_WORK.FILLER_9.WUSO_SPACES);

            /*" -983- MOVE WUSOEMPRESA TO MOVCC-USOEMPRESA */
            _.Move(AREA_DE_WORK.WUSOEMPRESA, MOVCC_REGISTRO.MOVCC_USOEMPRESA);

            /*" -984- MOVE ALL SPACES TO MOVCC-FILLER */
            _.MoveAll("", MOVCC_REGISTRO.MOVCC_FILLER);

            /*" -986- MOVE 1 TO MOVCC-CODMOVTO */
            _.Move(1, MOVCC_REGISTRO.MOVCC_CODMOVTO);

            /*" -986- WRITE MOVCC-REGISTRO. */
            MOVDEBITO_CC.Write(MOVCC_REGISTRO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0125-00-RELATORIO-SECTION */
        private void R0125_00_RELATORIO_SECTION()
        {
            /*" -995- MOVE 'R0125-00-RELATORIO ' TO WPARAGRAFO */
            _.Move("R0125-00-RELATORIO ", AREA_DE_WORK.WPARAGRAFO);

            /*" -997- MOVE '125' TO WNR-EXEC-SQL. */
            _.Move("125", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -999- PERFORM R0126-00-LE-V1CLIENTE */

            R0126_00_LE_V1CLIENTE_SECTION();

            /*" -1000- MOVE V0MOVDE-NUM-APOLICE TO LD01-NUMBIL */
            _.Move(V0MOVDE_NUM_APOLICE, AREA_DE_WORK.LD01.LD01_NUMBIL);

            /*" -1001- MOVE V0MOVDE-DTVENCTO TO WDATA-SQL */
            _.Move(V0MOVDE_DTVENCTO, AREA_DE_WORK.WDATA_SQL);

            /*" -1002- MOVE WDIA-SQL TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.FILLER_10.WDIA_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1003- MOVE WMES-SQL TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.FILLER_10.WMES_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1004- MOVE WANO-SQL TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.FILLER_10.WANO_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1005- MOVE WDATA-CABEC TO LD01-DTVENCTO */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LD01.LD01_DTVENCTO);

            /*" -1006- MOVE V0MOVDE-DIA-DEBITO TO LD01-DIA-DEBITO */
            _.Move(V0MOVDE_DIA_DEBITO, AREA_DE_WORK.LD01.LD01_DIA_DEBITO);

            /*" -1007- MOVE V0MOVDE-COD-AGENCIA-DEB TO LD01-AGENCIA */
            _.Move(V0MOVDE_COD_AGENCIA_DEB, AREA_DE_WORK.LD01.LD01_DEBITO.LD01_AGENCIA);

            /*" -1008- MOVE V0MOVDE-OPER-CONTA-DEB TO LD01-OPERACAO */
            _.Move(V0MOVDE_OPER_CONTA_DEB, AREA_DE_WORK.LD01.LD01_DEBITO.LD01_OPERACAO);

            /*" -1009- MOVE '/' TO LD01-BARRA */
            _.Move("/", AREA_DE_WORK.LD01.LD01_DEBITO.LD01_BARRA);

            /*" -1010- MOVE V0MOVDE-NUM-CONTA-DEB TO LD01-CONTA */
            _.Move(V0MOVDE_NUM_CONTA_DEB, AREA_DE_WORK.LD01.LD01_DEBITO.LD01_CONTA);

            /*" -1011- MOVE '-' TO LD01-HIFEN1 */
            _.Move("-", AREA_DE_WORK.LD01.LD01_DEBITO.LD01_HIFEN1);

            /*" -1012- MOVE V0MOVDE-DIG-CONTA-DEB TO LD01-DIGITO */
            _.Move(V0MOVDE_DIG_CONTA_DEB, AREA_DE_WORK.LD01.LD01_DEBITO.LD01_DIGITO);

            /*" -1014- MOVE V0MOVDE-VLR-DEBITO TO LD01-VLDEBITO */
            _.Move(V0MOVDE_VLR_DEBITO, AREA_DE_WORK.LD01.LD01_VLDEBITO);

            /*" -1016- MOVE V1CLIEN-NOME-RAZAO TO LD01-NOME */
            _.Move(V1CLIEN_NOME_RAZAO, AREA_DE_WORK.LD01.LD01_NOME);

            /*" -1017- IF WLIN GREATER 50 */

            if (AREA_DE_WORK.WLIN > 50)
            {

                /*" -1019- PERFORM R0160-00-CABECALHOS. */

                R0160_00_CABECALHOS_SECTION();
            }


            /*" -1021- WRITE REG-BI0033B FROM LD01 AFTER 1 */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_BI0033B);

            RBI0033B.Write(REG_BI0033B.GetMoveValues().ToString());

            /*" -1021- COMPUTE WLIN = WLIN + 1. */
            AREA_DE_WORK.WLIN.Value = AREA_DE_WORK.WLIN + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0125_99_SAIDA*/

        [StopWatch]
        /*" R0126-00-LE-V1CLIENTE-SECTION */
        private void R0126_00_LE_V1CLIENTE_SECTION()
        {
            /*" -1030- MOVE 'R0126-00-LE-V1CLIENTE ' TO WPARAGRAFO */
            _.Move("R0126-00-LE-V1CLIENTE ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1032- MOVE '126' TO WNR-EXEC-SQL. */
            _.Move("126", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1033- MOVE V1BILH-COD-CLIENTE TO V1CLIEN-COD-CLIENTE */
            _.Move(V1BILH_COD_CLIENTE, V1CLIEN_COD_CLIENTE);

            /*" -1035- MOVE SPACES TO V1CLIEN-NOME-RAZAO. */
            _.Move("", V1CLIEN_NOME_RAZAO);

            /*" -1040- PERFORM R0126_00_LE_V1CLIENTE_DB_SELECT_1 */

            R0126_00_LE_V1CLIENTE_DB_SELECT_1();

            /*" -1043- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1044- DISPLAY 'BI0033B - ' WPARAGRAFO */
                _.Display($"BI0033B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1045- DISPLAY 'V0MOVDE-NUM-APOLICE ' V0MOVDE-NUM-APOLICE */
                _.Display($"V0MOVDE-NUM-APOLICE {V0MOVDE_NUM_APOLICE}");

                /*" -1046- DISPLAY 'V1CLIEN-COD-CLIENTE ' V1CLIEN-COD-CLIENTE */
                _.Display($"V1CLIEN-COD-CLIENTE {V1CLIEN_COD_CLIENTE}");

                /*" -1046- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0126-00-LE-V1CLIENTE-DB-SELECT-1 */
        public void R0126_00_LE_V1CLIENTE_DB_SELECT_1()
        {
            /*" -1040- EXEC SQL SELECT NOME_RAZAO INTO :V1CLIEN-NOME-RAZAO FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = :V1CLIEN-COD-CLIENTE END-EXEC. */

            var r0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1 = new R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1()
            {
                V1CLIEN_COD_CLIENTE = V1CLIEN_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1.Execute(r0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CLIEN_NOME_RAZAO, V1CLIEN_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0126_99_SAIDA*/

        [StopWatch]
        /*" R0130-00-UPDATE-V0PARAM-CONTA-SECTION */
        private void R0130_00_UPDATE_V0PARAM_CONTA_SECTION()
        {
            /*" -1056- PERFORM R0135-00-PROXIMO-DEBITO */

            R0135_00_PROXIMO_DEBITO_SECTION();

            /*" -1057- MOVE 'R0130-00-UPDATE-V0PARAM-CONTA' TO WPARAGRAFO */
            _.Move("R0130-00-UPDATE-V0PARAM-CONTA", AREA_DE_WORK.WPARAGRAFO);

            /*" -1059- MOVE '130' TO WNR-EXEC-SQL */
            _.Move("130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1060- DISPLAY '***********************************' */
            _.Display($"***********************************");

            /*" -1061- DISPLAY '*     DATA DO PROXIMO DEBITO      *' */
            _.Display($"*     DATA DO PROXIMO DEBITO      *");

            /*" -1062- DISPLAY '*          ' WDATA-SQL '             *' */

            $"*          {AREA_DE_WORK.WDATA_SQL}             *"
            .Display();

            /*" -1064- DISPLAY '***********************************' . */
            _.Display($"***********************************");

            /*" -1073- PERFORM R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1 */

            R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1();

            /*" -1076- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1077- DISPLAY 'BI0033B - ' WPARAGRAFO */
                _.Display($"BI0033B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1078- DISPLAY 'V0PARAMC-TIPO-MOVTOCC ' V0PARAMC-TIPO-MOVTOCC */
                _.Display($"V0PARAMC-TIPO-MOVTOCC {V0PARAMC_TIPO_MOVTOCC}");

                /*" -1079- DISPLAY 'V0PARAMC-CODPRODU     ' V0PARAMC-CODPRODU */
                _.Display($"V0PARAMC-CODPRODU     {V0PARAMC_CODPRODU}");

                /*" -1080- DISPLAY 'V0PARAMC-COD-CONVENIO ' V0PARAMC-COD-CONVENIO */
                _.Display($"V0PARAMC-COD-CONVENIO {V0PARAMC_COD_CONVENIO}");

                /*" -1080- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0130-00-UPDATE-V0PARAM-CONTA-DB-UPDATE-1 */
        public void R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1()
        {
            /*" -1073- EXEC SQL UPDATE SEGUROS.V0PARAM_CONTACEF SET NSAS = :V0PARAMC-NSAS, DTMOVTO = :V1SISTE-DTCURRENT, DTPROX_DEB = :V0PARAMC-DTPROX-DEB, TIMESTAMP = CURRENT TIMESTAMP WHERE TIPO_MOVTOCC = :V0PARAMC-TIPO-MOVTOCC AND COD_CONVENIO = :V0PARAMC-COD-CONVENIO AND SITUACAO = :V0PARAMC-SITUACAO END-EXEC. */

            var r0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1 = new R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1()
            {
                V0PARAMC_DTPROX_DEB = V0PARAMC_DTPROX_DEB.ToString(),
                V1SISTE_DTCURRENT = V1SISTE_DTCURRENT.ToString(),
                V0PARAMC_NSAS = V0PARAMC_NSAS.ToString(),
                V0PARAMC_TIPO_MOVTOCC = V0PARAMC_TIPO_MOVTOCC.ToString(),
                V0PARAMC_COD_CONVENIO = V0PARAMC_COD_CONVENIO.ToString(),
                V0PARAMC_SITUACAO = V0PARAMC_SITUACAO.ToString(),
            };

            R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1.Execute(r0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0135-00-PROXIMO-DEBITO-SECTION */
        private void R0135_00_PROXIMO_DEBITO_SECTION()
        {
            /*" -1089- MOVE 'R0135-00-PROXIMO-DEBITO' TO WPARAGRAFO */
            _.Move("R0135-00-PROXIMO-DEBITO", AREA_DE_WORK.WPARAGRAFO);

            /*" -1092- MOVE '135' TO WNR-EXEC-SQL. */
            _.Move("135", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1093- MOVE V0PARAMC-DTPROX-DEB TO WDATA-SQL. */
            _.Move(V0PARAMC_DTPROX_DEB, AREA_DE_WORK.WDATA_SQL);

            /*" -1094- MOVE WDIA-SQL TO DATA3-DD */
            _.Move(AREA_DE_WORK.FILLER_10.WDIA_SQL, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_DD);

            /*" -1095- MOVE WMES-SQL TO DATA3-MM */
            _.Move(AREA_DE_WORK.FILLER_10.WMES_SQL, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_MM);

            /*" -1096- MOVE WANO-SQL TO DATA3-AA */
            _.Move(AREA_DE_WORK.FILLER_10.WANO_SQL, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_AA);

            /*" -1097- MOVE ZEROS TO DATA2-DD */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA2_R.DATA2_DD);

            /*" -1098- MOVE ZEROS TO DATA2-MM */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA2_R.DATA2_MM);

            /*" -1100- MOVE ZEROS TO DATA2-AA */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA2_R.DATA2_AA);

            /*" -1102- PERFORM R0136-00-ACHA-DATA 1 TIMES. */

            for (int i = 0; i < 1; i++)
            {

                R0136_00_ACHA_DATA_SECTION();

            }

            /*" -1103- IF QUANTIDA EQUAL +99999 */

            if (AREA_DE_WORK.LPARM2.QUANTIDA == +99999)
            {

                /*" -1104- MOVE 31 TO DATA3-DD */
                _.Move(31, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_DD);

                /*" -1105- MOVE 12 TO DATA3-MM */
                _.Move(12, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_MM);

                /*" -1106- MOVE 9999 TO DATA3-AA */
                _.Move(9999, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_AA);

                /*" -1107- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -1108- DISPLAY '* BI0033B - ERRO NA ROTINA PROSOMC1 *' */
                _.Display($"* BI0033B - ERRO NA ROTINA PROSOMC1 *");

                /*" -1109- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -1111- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1112- MOVE DATA3-DD TO WDIA-SQL */
            _.Move(AREA_DE_WORK.LPARM2.DATA3_R.DATA3_DD, AREA_DE_WORK.FILLER_10.WDIA_SQL);

            /*" -1113- MOVE DATA3-MM TO WMES-SQL */
            _.Move(AREA_DE_WORK.LPARM2.DATA3_R.DATA3_MM, AREA_DE_WORK.FILLER_10.WMES_SQL);

            /*" -1115- MOVE DATA3-AA TO WANO-SQL */
            _.Move(AREA_DE_WORK.LPARM2.DATA3_R.DATA3_AA, AREA_DE_WORK.FILLER_10.WANO_SQL);

            /*" -1115- MOVE WDATA-SQL TO V0PARAMC-DTPROX-DEB. */
            _.Move(AREA_DE_WORK.WDATA_SQL, V0PARAMC_DTPROX_DEB);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0135_99_SAIDA*/

        [StopWatch]
        /*" R0136-00-ACHA-DATA-SECTION */
        private void R0136_00_ACHA_DATA_SECTION()
        {
            /*" -1124- MOVE 'R0136-00-ACHA-DATA' TO WPARAGRAFO */
            _.Move("R0136-00-ACHA-DATA", AREA_DE_WORK.WPARAGRAFO);

            /*" -1126- MOVE '136' TO WNR-EXEC-SQL. */
            _.Move("136", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1128- MOVE DATA3 TO DATA2 */
            _.Move(AREA_DE_WORK.LPARM2.DATA3, AREA_DE_WORK.LPARM2.DATA2);

            /*" -1128- CALL 'PROSOMC1' USING LPARM2. */
            _.Call("PROSOMC1", AREA_DE_WORK.LPARM2);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0136_99_SAIDA*/

        [StopWatch]
        /*" R0140-00-UPDATE-V0MOVDEBCC-CEF-SECTION */
        private void R0140_00_UPDATE_V0MOVDEBCC_CEF_SECTION()
        {
            /*" -1137- MOVE 'R0140-00-UPDATE-V0MOVDEBCC-CEF' TO WPARAGRAFO */
            _.Move("R0140-00-UPDATE-V0MOVDEBCC-CEF", AREA_DE_WORK.WPARAGRAFO);

            /*" -1139- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1152- PERFORM R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1 */

            R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1();

            /*" -1155- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1156- DISPLAY 'BI0033B - ' WPARAGRAFO */
                _.Display($"BI0033B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1157- DISPLAY 'V0MOVDE-NUM-APOLICE  ' V0MOVDE-NUM-APOLICE */
                _.Display($"V0MOVDE-NUM-APOLICE  {V0MOVDE_NUM_APOLICE}");

                /*" -1158- DISPLAY 'V0MOVDE-SIT-COBRANCA ' V0MOVDE-SIT-COBRANCA */
                _.Display($"V0MOVDE-SIT-COBRANCA {V0MOVDE_SIT_COBRANCA}");

                /*" -1159- DISPLAY 'V0MOVDE-DTVENCTO     ' V0MOVDE-DTVENCTO */
                _.Display($"V0MOVDE-DTVENCTO     {V0MOVDE_DTVENCTO}");

                /*" -1159- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0140-00-UPDATE-V0MOVDEBCC-CEF-DB-UPDATE-1 */
        public void R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1()
        {
            /*" -1152- EXEC SQL UPDATE SEGUROS.V0MOVDEBCC_CEF SET SIT_COBRANCA = '1' , DTMOVTO = :V1SISTE-DTCURRENT, DTENVIO = CURRENT DATE, NSAS = :V0PARAMC-NSAS, COD_USUARIO = 'BI0033B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V0MOVDE-NUM-APOLICE AND SIT_COBRANCA = :V0MOVDE-SIT-COBRANCA AND DTVENCTO <= :V0MOVDE-DTVENCTO END-EXEC. */

            var r0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1 = new R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1()
            {
                V1SISTE_DTCURRENT = V1SISTE_DTCURRENT.ToString(),
                V0PARAMC_NSAS = V0PARAMC_NSAS.ToString(),
                V0MOVDE_SIT_COBRANCA = V0MOVDE_SIT_COBRANCA.ToString(),
                V0MOVDE_NUM_APOLICE = V0MOVDE_NUM_APOLICE.ToString(),
                V0MOVDE_DTVENCTO = V0MOVDE_DTVENCTO.ToString(),
            };

            R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1.Execute(r0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0140_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-UPDATE-V0BILHETE-SECTION */
        private void R0150_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -1168- MOVE 'R0150-00-UPDATE-V0BILHETE' TO WPARAGRAFO */
            _.Move("R0150-00-UPDATE-V0BILHETE", AREA_DE_WORK.WPARAGRAFO);

            /*" -1170- MOVE '150' TO WNR-EXEC-SQL */
            _.Move("150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1171- MOVE V0MOVDE-NUM-APOLICE TO V0BILH-NUMBIL */
            _.Move(V0MOVDE_NUM_APOLICE, V0BILH_NUMBIL);

            /*" -1173- MOVE '6' TO V0BILH-SITUACAO */
            _.Move("6", V0BILH_SITUACAO);

            /*" -1177- PERFORM R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -1180- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1181- DISPLAY 'BI0033B - ' WPARAGRAFO */
                _.Display($"BI0033B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1182- DISPLAY 'V0BILH-NUMBIL ' V0BILH-NUMBIL */
                _.Display($"V0BILH-NUMBIL {V0BILH_NUMBIL}");

                /*" -1182- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0150-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -1177- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO, TIMESTAMP = CURRENT TIMESTAMP WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r0150_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r0150_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0160-00-CABECALHOS-SECTION */
        private void R0160_00_CABECALHOS_SECTION()
        {
            /*" -1192- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1193- MOVE V0PARAMC-NSAS TO LC06-NRFITA */
            _.Move(V0PARAMC_NSAS, AREA_DE_WORK.LC06.LC06_NRFITA);

            /*" -1194- COMPUTE WPAG = WPAG + 1 */
            AREA_DE_WORK.WPAG.Value = AREA_DE_WORK.WPAG + 1;

            /*" -1196- MOVE WPAG TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.WPAG, AREA_DE_WORK.LC01.LC01_PAGINA);

            /*" -1197- WRITE REG-BI0033B FROM LC01 AFTER PAGE */
            _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REG_BI0033B);

            RBI0033B.Write(REG_BI0033B.GetMoveValues().ToString());

            /*" -1198- WRITE REG-BI0033B FROM LC02 AFTER 1 */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REG_BI0033B);

            RBI0033B.Write(REG_BI0033B.GetMoveValues().ToString());

            /*" -1199- WRITE REG-BI0033B FROM LC03 AFTER 1 */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REG_BI0033B);

            RBI0033B.Write(REG_BI0033B.GetMoveValues().ToString());

            /*" -1200- WRITE REG-BI0033B FROM LC07 AFTER 1 */
            _.Move(AREA_DE_WORK.LC07.GetMoveValues(), REG_BI0033B);

            RBI0033B.Write(REG_BI0033B.GetMoveValues().ToString());

            /*" -1201- WRITE REG-BI0033B FROM LC06 AFTER 1 */
            _.Move(AREA_DE_WORK.LC06.GetMoveValues(), REG_BI0033B);

            RBI0033B.Write(REG_BI0033B.GetMoveValues().ToString());

            /*" -1202- WRITE REG-BI0033B FROM LC04 AFTER 1 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_BI0033B);

            RBI0033B.Write(REG_BI0033B.GetMoveValues().ToString());

            /*" -1203- WRITE REG-BI0033B FROM LC05 AFTER 1 */
            _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REG_BI0033B);

            RBI0033B.Write(REG_BI0033B.GetMoveValues().ToString());

            /*" -1205- WRITE REG-BI0033B FROM LC04 AFTER 1 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_BI0033B);

            RBI0033B.Write(REG_BI0033B.GetMoveValues().ToString());

            /*" -1205- MOVE 08 TO WLIN. */
            _.Move(08, AREA_DE_WORK.WLIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/

        [StopWatch]
        /*" R0170-00-TOTALIZADOR-SECTION */
        private void R0170_00_TOTALIZADOR_SECTION()
        {
            /*" -1214- COMPUTE WTOTREG = WTOTREG - 2 */
            AREA_DE_WORK.WTOTREG.Value = AREA_DE_WORK.WTOTREG - 2;

            /*" -1215- MOVE WTOTREG TO LT01-QT-TOTAL */
            _.Move(AREA_DE_WORK.WTOTREG, AREA_DE_WORK.LT01.LT01_QT_TOTAL);

            /*" -1217- MOVE WTOTDEB TO LT01-VL-TOTAL */
            _.Move(AREA_DE_WORK.WTOTDEB, AREA_DE_WORK.LT01.LT01_VL_TOTAL);

            /*" -1217- WRITE REG-BI0033B FROM LT01 AFTER 2. */
            _.Move(AREA_DE_WORK.LT01.GetMoveValues(), REG_BI0033B);

            RBI0033B.Write(REG_BI0033B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0170_99_SAIDA*/

        [StopWatch]
        /*" R0180-00-RELAT-SEM-MOVTO-SECTION */
        private void R0180_00_RELAT_SEM_MOVTO_SECTION()
        {
            /*" -1227- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1228- WRITE REG-BI0033B FROM LD02 AFTER 2 */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_BI0033B);

            RBI0033B.Write(REG_BI0033B.GetMoveValues().ToString());

            /*" -1229- WRITE REG-BI0033B FROM LD04 AFTER 1 */
            _.Move(AREA_DE_WORK.LD04.GetMoveValues(), REG_BI0033B);

            RBI0033B.Write(REG_BI0033B.GetMoveValues().ToString());

            /*" -1230- WRITE REG-BI0033B FROM LD03 AFTER 1 */
            _.Move(AREA_DE_WORK.LD03.GetMoveValues(), REG_BI0033B);

            RBI0033B.Write(REG_BI0033B.GetMoveValues().ToString());

            /*" -1231- WRITE REG-BI0033B FROM LD04 AFTER 1 */
            _.Move(AREA_DE_WORK.LD04.GetMoveValues(), REG_BI0033B);

            RBI0033B.Write(REG_BI0033B.GetMoveValues().ToString());

            /*" -1231- WRITE REG-BI0033B FROM LD02 AFTER 1. */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_BI0033B);

            RBI0033B.Write(REG_BI0033B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1241- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1243- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1243- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1245- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1249- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1249- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}