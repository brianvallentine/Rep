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
using Sias.Bilhetes.DB2.BI0072B;

namespace Code
{
    public class BI0072B
    {
        public bool IsCall { get; set; }

        public BI0072B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  BI0072B   (VERSAO DO CB7114B)             */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FAST COMPUTER                      *      */
        /*"      *   PROGRAMADOR ............  FAST COMPUTER                      *      */
        /*"      *   DATA CODIFICACAO .......  AGOSTO/2010                        *      */
        /*"      *   CADMUS .................  45.765                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  - TRATAMENTO MOVIMENTO RETORNO DE  *      */
        /*"      *                             FITA DE DEBITO SYSTEM CRED         *      */
        /*"      *                             ATUALIZANDO A BASE DE DADOS DE     *      */
        /*"      *                             BILHETE AP                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV.01 *   VERSAO 13 - PROJETO JOINT VENTURE (JV)                       *      */
        /*"=     *             - AVALIAR IMPACTO PRODUTO, APOLICE, ORGAO, ETC.    *      */
        /*"=     *             - Historia: 191871.                                *      */
        /*"=     *    EM 22/02/2019 - HERVAL SOUZA                                *      */
        /*"=     *                                        PROCURE POR JV.01       *      */
        /*"JV.01 *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12 -   HIST�RIA JAZZ = 10807/11931                    *      */
        /*"      *                 TAREFA JAZZ = 107.303 (JAZZ antigo)            *      */
        /*"      *                 CORRIGIR A ATUALIZACAO DO CAMPO                *      */
        /*"      *                 TIP_CANCELAMENTO DA TABELA BILHETE PARA O      *      */
        /*"      *                 DOMINIO '3' - CANCELAMENTO POR INADIMPLENCIA.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/03/2018 - HERVAL SOUZA                                 *      */
        /*"      *                                       PROCURE POR V.12         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/10/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 - CAD 85.727                                       *      */
        /*"      *                                                                *      */
        /*"      *             - CANCELAMENTO DE BILHETES COM RETORNOS:           *      */
        /*"      *                02 - CONTA N�O CADASTRADA                       *      */
        /*"      *                05 - CARTAO DE CREDITO CANCELADO                *      */
        /*"      *                06 - CARTAO INV�LIDO                            *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/08/2013 - EDIVALDO GOMES    (FAST COMPUTER)            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - CAD 74.005                                       *      */
        /*"      *                                                                *      */
        /*"      *             - AUMENTO DA TABELA INTERNA DE PRODUTO             *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/09/2012 - CLAUDIO FREITAS   (FAST COMPUTER)            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - CAD  58.146                                      *      */
        /*"      *               - CANCELA PROPOSTAS QUE RECEBEM CODIGO DE        *      */
        /*"      *                 RETORNO MAIOR QUE ZERO PARA PARCELA DE         *      */
        /*"      *                 ADESAO.                                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/08/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - CAD 201.085                                      *      */
        /*"      *               - COMPLEMENTA O PROCESSO DE CANCELAMENTO.        *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/05/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - CAD 54.362                                       *      */
        /*"      *                                                                *      */
        /*"      *      - PASSA A TRATAR O TIPO MOVIMENTO IGUAL A U               *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/03/2011 - TERCIO CARVALHO(FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - CAD 53.649                                       *      */
        /*"      *                                                                *      */
        /*"      *      - AJUSTE NO PROGRAMA PARA CORRECAO DO ABEND SQLCODE = -180*      */
        /*"      *        OCORRIDO NO PROCESSO R4000-00-INSERT-V0FOLLOWUP         *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/02/2012 - MARCO PAIVA    (FAST COMPRSIR)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - CAD 53.548                                       *      */
        /*"      *                                                                *      */
        /*"      *      - AJUSTE NO PROGRAMA PARA CORRECAO DO ABEND SQLCODE = -811*      */
        /*"      *        OCORRIDO NO PROCESSO R1050-00-SELECT-CONVERSI           *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/02/2012 - MARCO PAIVA    (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - CAD 52.124                                       *      */
        /*"      *                                                                *      */
        /*"      *             - AJUSTE NO NUMERO DA CONTA PARA CONTABILIZACAO    *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/01/2010 - MARCO PAIVA    (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CAD 51.584                                       *      */
        /*"      *                                                                *      */
        /*"      *             - AUMENTO DA TABELA INTERNA DE PRODUTO             *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/12/2010 - MARCO PAIVA    (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - CAD 51.456                                       *      */
        /*"      *                                                                *      */
        /*"      *             - TRATA MENOR PARCELA PENDENTE QUANDO NO ARQUIVO   *      */
        /*"      *               DE RETORNO A PARCELA ESTIVER ZERADA.             *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/12/2010 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * EMPRESAS                            V1EMPRESA         INPUT    *      */
        /*"      * MOVIMENTO DE DEBITO EM C/C          V1MOVDEBCC_CEF    INPUT    *      */
        /*"      * AVISOS DE CREDITO                   V0AVISOCRED       OUTPUT   *      */
        /*"      * SALDOS DE AVISOS DE CREDITO         V0AVISOS_SALDOS   OUTPUT   *      */
        /*"      * RCAPS                               V0RCAP            I-O      *      */
        /*"      * RCAP COMPLEMENTAR                   V0RCAPCOMP        OUTPUT   *      */
        /*"      * COMISSAO FENAE                      V0COMISSAO_FENAE  OUTPUT   *      */
        /*"      * VENDAS BILHETE                      V0VENDAS_BILHETE  OUTPUT   *      */
        /*"      * CONTROLE DESPESAS CEF               V0CONT_DESP_CEF   OUTPUT   *      */
        /*"      * COMISSAO ADIANTA                    V0ADIANTA         OUTPUT   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RBI0072B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RBI0072B
        {
            get
            {
                _.Move(REG_BI0072B, _RBI0072B); VarBasis.RedefinePassValue(REG_BI0072B, _RBI0072B, REG_BI0072B); return _RBI0072B;
            }
        }
        /*"01              REG-BI0072B        PIC  X(132).*/
        public StringBasis REG_BI0072B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_PRD { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_TIP { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_SIT { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77    VIND-DTQITBCO             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-COD-EMPRESA          PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTLIBER              PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTLIBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTQITBC              PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTQITBC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODEMP               PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ORDLIDER             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_ORDLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-TIPSGU               PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_TIPSGU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-APOLIDER             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_APOLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ENDOSLID             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_ENDOSLID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODLIDER             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-FONTE                PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRRCAP               PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-SEQUENCIA            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NUM-LOTE             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRTIT                PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NRTIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODPRODU             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-AGECOBR              PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRCERTIF             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NUMAPOL              PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRENDOS              PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRPARCEL             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-RECUPERA             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_RECUPERA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ACRESCIMO            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_ACRESCIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRMATRGER            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NRMATRGER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VALADTGER            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_VALADTGER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTPAGGER             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTPAGGER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTCANCEL             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTCANCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRMATRSUN            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NRMATRSUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VALADTSUN            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_VALADTSUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTPAGSUN             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTPAGSUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-TIPO                 PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_TIPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTVENCTO             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DATSEL               PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DATSEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODPRP               PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_CODPRP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NUMBIL               PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VLVARMON             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_VLVARMON { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTQITBCO2            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTQITBCO2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTMOVTO              PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTCREDITO            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTCREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-CODPRODU           PIC S9(004)     COMP.*/
        public IntBasis WSHOST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-QTDE               PIC S9(009)     COMP.*/
        public IntBasis WSHOST_QTDE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WSHOST-VLPRMTOT           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-VLTARIFA           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-SITUACAO           PIC  X(001).*/
        public StringBasis WSHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    WSHOST-NUMSIV01           PIC S9(015)     COMP-3.*/
        public IntBasis WSHOST_NUMSIV01 { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    WSHOST-NUMSIV02           PIC S9(015)     COMP-3.*/
        public IntBasis WSHOST_NUMSIV02 { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    WSHOST-COUNT              PIC S9(009)     COMP.*/
        public IntBasis WSHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WSHOST-DATA-INIVIGENCIA   PIC  X(010).*/
        public StringBasis WSHOST_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSHOST-DATA-TERVIGENCIA   PIC  X(010).*/
        public StringBasis WSHOST_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSHOST-NUM-LOTE           PIC S9(09)    COMP.*/
        public IntBasis WSHOST_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTCURRENT    PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1EMPR-COD-EMP      PIC S9(004)                COMP.*/
        public IntBasis V1EMPR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1EMPR-NOM-EMP      PIC  X(040).*/
        public StringBasis V1EMPR_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  V0PARC-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0PARC_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0PARC-NUM-ENDOSSO          PIC S9(09) COMP.*/
        public IntBasis V0PARC_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0PARC-NUM-PARCELA          PIC S9(04) COMP.*/
        public IntBasis V0PARC_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PCHS-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0PCHS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0PCHS-NUM-ENDOSSO          PIC S9(09) COMP.*/
        public IntBasis V0PCHS_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0PCHS-NUM-PARCELA          PIC S9(04) COMP.*/
        public IntBasis V0PCHS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1MVDB-COD-EMPRESA          PIC S9(09) COMP.*/
        public IntBasis V1MVDB_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1MVDB-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V1MVDB_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1MVDB-NRENDOS              PIC S9(09) COMP.*/
        public IntBasis V1MVDB_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1MVDB-NRENDOS1             PIC S9(09) COMP.*/
        public IntBasis V1MVDB_NRENDOS1 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1MVDB-NRPARCEL             PIC S9(04) COMP.*/
        public IntBasis V1MVDB_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1MVDB-SIT-COBRANCA         PIC  X(01).*/
        public StringBasis V1MVDB_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V1MVDB-DTVENCTO             PIC  X(10).*/
        public StringBasis V1MVDB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1MVDB-DIA-DEBITO           PIC S9(04) COMP.*/
        public IntBasis V1MVDB_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1MVDB-VLR-DEBITO           PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V1MVDB_VLR_DEBITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V1MVDB-COD-AGENCIA-DEB      PIC S9(04) COMP.*/
        public IntBasis V1MVDB_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1MVDB-OPER-CONTA-DEB       PIC S9(04) COMP.*/
        public IntBasis V1MVDB_OPER_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1MVDB-NUM-CONTA-DEB        PIC S9(13) COMP-3.*/
        public IntBasis V1MVDB_NUM_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1MVDB-DIG-CONTA-DEB        PIC S9(04) COMP.*/
        public IntBasis V1MVDB_DIG_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1MVDB-COD-CONVENIO         PIC S9(09) COMP.*/
        public IntBasis V1MVDB_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1MVDB-DTMOVTO              PIC  X(10).*/
        public StringBasis V1MVDB_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1MVDB-DTENVIO              PIC  X(10).*/
        public StringBasis V1MVDB_DTENVIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1MVDB-DTRETORNO            PIC  X(10).*/
        public StringBasis V1MVDB_DTRETORNO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1MVDB-DTCREDITO            PIC  X(10).*/
        public StringBasis V1MVDB_DTCREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1MVDB-COD-RET-CEF          PIC S9(04) COMP.*/
        public IntBasis V1MVDB_COD_RET_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1MVDB-NSAS                 PIC S9(04) COMP.*/
        public IntBasis V1MVDB_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1MVDB-VLR-CREDITO          PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V1MVDB_VLR_CREDITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V1MVDB-SEQUENCIA            PIC S9(04)    COMP.*/
        public IntBasis V1MVDB_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1MVDB-NUM-LOTE             PIC S9(09)    COMP.*/
        public IntBasis V1MVDB_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77    V0FOLL-NUMAPOL            PIC S9(013)     COMP-3.*/
        public IntBasis V0FOLL_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0FOLL-NRENDOS            PIC S9(009)     COMP.*/
        public IntBasis V0FOLL_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-NRPARCEL           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-DACPARC            PIC  X(001).*/
        public StringBasis V0FOLL_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-DTMOVTO            PIC  X(010).*/
        public StringBasis V0FOLL_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FOLL-HORAOPER           PIC  X(008).*/
        public StringBasis V0FOLL_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77    V0FOLL-VLPREMIO           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0FOLL_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0FOLL-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0FOLL_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-CODBAIXA           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_CODBAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-CDERRO01           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO02           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO03           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO04           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO05           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO05 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO06           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO06 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-SITUACAO           PIC  X(001).*/
        public StringBasis V0FOLL_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-SITCONTB           PIC  X(001).*/
        public StringBasis V0FOLL_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-OPERACAO           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-DTLIBER            PIC  X(010).*/
        public StringBasis V0FOLL_DTLIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FOLL-DTQITBCO           PIC  X(010).*/
        public StringBasis V0FOLL_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FOLL-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0FOLL_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-ORDLIDER           PIC S9(015)     COMP-3.*/
        public IntBasis V0FOLL_ORDLIDER { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0FOLL-TIPSGU             PIC  X(001).*/
        public StringBasis V0FOLL_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-APOLIDER           PIC  X(015).*/
        public StringBasis V0FOLL_APOLIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77    V0FOLL-ENDOSLID           PIC  X(015).*/
        public StringBasis V0FOLL_ENDOSLID { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77    V0FOLL-CODLIDER           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-NRRCAP             PIC S9(009)     COMP.*/
        public IntBasis V0FOLL_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0PROD-CODPRODU           PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis V0PROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-NUMBIL             PIC S9(015)     COMP-3.*/
        public IntBasis V0BILH_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0BILH-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0BILH_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-AGECOBR            PIC S9(004)     COMP.*/
        public IntBasis V0BILH_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-RAMO               PIC S9(004)     COMP.*/
        public IntBasis V0BILH_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-CODCLIEN           PIC S9(009)     COMP.*/
        public IntBasis V0BILH_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0BILH-NRMATRVEN          PIC S9(015)     COMP-3.*/
        public IntBasis V0BILH_NRMATRVEN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0BILH-AGECTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0BILH_AGECTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-OPRCTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0BILH_OPRCTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-NUMCTAVEN          PIC S9(013)     COMP-3.*/
        public IntBasis V0BILH_NUMCTAVEN { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0BILH-DIGCTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0BILH_DIGCTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-AGECTADEB          PIC S9(004)     COMP.*/
        public IntBasis V0BILH_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-OPRCTADEB          PIC S9(004)     COMP.*/
        public IntBasis V0BILH_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-NUMCTADEB          PIC S9(013)     COMP-3.*/
        public IntBasis V0BILH_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0BILH-DIGCTADEB          PIC S9(004)     COMP.*/
        public IntBasis V0BILH_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-OPCAO-COB          PIC S9(004)     COMP.*/
        public IntBasis V0BILH_OPCAO_COB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-DTQITBCO           PIC  X(010).*/
        public StringBasis V0BILH_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0BILH-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0BILH_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0BILH-DTVENDA            PIC  X(010).*/
        public StringBasis V0BILH_DTVENDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0BILH-SITUACAO           PIC  X(001).*/
        public StringBasis V0BILH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0BILH-NUMAPOL            PIC S9(013)    VALUE +0   COMP-3*/
        public IntBasis V0BILH_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0PRFD-NUMPROPOSTA        PIC S9(15)V    COMP-3.*/
        public DoubleBasis V0PRFD_NUMPROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"77    V0PRFD-NUMSICOB           PIC S9(15)V    COMP-3.*/
        public DoubleBasis V0PRFD_NUMSICOB { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"77    V0PRFD-CODPROD            PIC S9(4)      COMP.*/
        public IntBasis V0PRFD_CODPROD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77    V0APCB-NUMAPOL            PIC S9(013)    COMP-3.*/
        public IntBasis V0APCB_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0APCB-NRENDOS            PIC S9(009)    COMP.*/
        public IntBasis V0APCB_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0APCB-CODPROD            PIC S9(004)    COMP-3.*/
        public IntBasis V0APCB_CODPROD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0APCB-NUMCARTAO          PIC S9(016)V   COMP-3.*/
        public DoubleBasis V0APCB_NUMCARTAO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(016)V"), 0);
        /*"01        HEADER-REGISTRO.*/
        public BI0072B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new BI0072B_HEADER_REGISTRO();
        public class BI0072B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTRO  PIC  X(001).*/
            public StringBasis HEADER_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODREMESSA   PIC  9(001).*/
            public IntBasis HEADER_CODREMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      HEADER-CODCONVENIO  PIC  X(010).*/
            public StringBasis HEADER_CODCONVENIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      FILLER              PIC  X(010).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        public BI0072B_MOVCC_REGISTRO MOVCC_REGISTRO { get; set; } = new BI0072B_MOVCC_REGISTRO();
        public class BI0072B_MOVCC_REGISTRO : VarBasis
        {
            /*"  05      MOVCC-CODREGISTRO  PIC  X(001).*/
            public StringBasis MOVCC_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-IDTCLIBAN    PIC  X(020).*/
            public StringBasis MOVCC_IDTCLIBAN { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      MOVCC-DTPAGTO      PIC  9(008).*/
            public IntBasis MOVCC_DTPAGTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      MOVCC-DTCREDITO    PIC  9(008).*/
            public IntBasis MOVCC_DTCREDITO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      MOVCC-IDTCLIEMP    PIC  X(044).*/
            public StringBasis MOVCC_IDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "44", "X(044)."), @"");
            /*"  05      MOVCC-VLRDEBITO    PIC  9(010)V99.*/
            public DoubleBasis MOVCC_VLRDEBITO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"  05      MOVCC-VLRTARIFA    PIC  9(005)V99.*/
            public DoubleBasis MOVCC_VLRTARIFA { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99."), 2);
            /*"  05      MOVCC-NSR          PIC  9(008).*/
            public IntBasis MOVCC_NSR { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      MOVCC-AGEDEBITO    PIC  X(008).*/
            public StringBasis MOVCC_AGEDEBITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05      MOVCC-TPCAPTURA    PIC  X(001).*/
            public StringBasis MOVCC_TPCAPTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-NUMCARTAO    PIC  9(016).*/
            public IntBasis MOVCC_NUMCARTAO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      MOVCC-CODRETORNO   PIC  9(002).*/
            public IntBasis MOVCC_CODRETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      MOVCC-CODIDENTI    PIC  X(005).*/
            public StringBasis MOVCC_CODIDENTI { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
            /*"  05      MOVCC-TPPAGTO      PIC  9(001).*/
            public IntBasis MOVCC_TPPAGTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      MOVCC-FILLER       PIC  X(009).*/
            public StringBasis MOVCC_FILLER { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"01        TRAILL-REGISTRO.*/
        }
        public BI0072B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new BI0072B_TRAILL_REGISTRO();
        public class BI0072B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTRO  PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-TOTREGISTRO  PIC  9(006).*/
            public IntBasis TRAILL_TOTREGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      TRAILL-VLRTOTDEB    PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTDEB { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      TRAILL-FILLER       PIC  X(126).*/
            public StringBasis TRAILL_FILLER { get; set; } = new StringBasis(new PIC("X", "126", "X(126)."), @"");
            /*"01           AREA-DE-WORK.*/
        }
        public BI0072B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new BI0072B_AREA_DE_WORK();
        public class BI0072B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(09)     VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  05         AC-LINHAS         PIC  9(002)    VALUE 80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"  05         AC-PAGINA         PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-LIDOS          PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WS-IND            PIC  9(003)    VALUE ZEROS.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05         WS-INDMAX         PIC  9(003)    VALUE ZEROS.*/
            public IntBasis WS_INDMAX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05         WS-CHAVE          PIC  X(001)    VALUE SPACES.*/
            public StringBasis WS_CHAVE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         AC-QT-REJEITADOS  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_QT_REJEITADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-QT-APROVADOS   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_QT_APROVADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-QT-DEVOLVIDO   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_QT_DEVOLVIDO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-QT-TOTAL       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_QT_TOTAL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-VL-REJEITADOS  PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VL_REJEITADOS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05         AC-VL-APROVADOS   PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VL_APROVADOS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05         AC-VL-DEVOLVIDO   PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VL_DEVOLVIDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05         AC-VL-FOLLOW      PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VL_FOLLOW { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05         AC-VL-TOTAL       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VL_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05         WVLPENDEN         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WVLPENDEN { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05         WS-VLPRMTAR       PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WS_VLPRMTAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WS-QTDBIL         PIC S9(004)    COMP.*/
            public IntBasis WS_QTDBIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WS-SUBS           PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WS_SUBS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WS-SUBS1          PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WS_SUBS1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WS-SUBS2          PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WS_SUBS2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AD-QTDEBIL        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AD_QTDEBIL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AD-VLRABIL        PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AD_VLRABIL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         ZZ-VALADT         PIC ZZZ.ZZZ.ZZ9,99-.*/
            public DoubleBasis ZZ_VALADT { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
            /*"  05         AC-U-V0MOVDEBCC   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_U_V0MOVDEBCC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-S-V0MOVDEBCC   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_S_V0MOVDEBCC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-D-V0RCAP       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_D_V0RCAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0RCAP       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0RCAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0RCAPCOMP   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-V1RCAP       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_V1RCAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0AVISOCRED  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0AVISOCRED { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0AVISOSAL   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0AVISOSAL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0FOLLOWUP   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0FOLLOWUP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-MOVICOB        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_MOVICOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-COMISSAO       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_COMISSAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-U-V0BILHETE    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_U_V0BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-C-V0BILHETE    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_C_V0BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-C-V0ENDOSSO    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_C_V0ENDOSSO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-C-V0COMIFENAE  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_C_V0COMIFENAE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-C-V0PARCELAS   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_C_V0PARCELAS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-C-V0PARCHIST   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_C_V0PARCHIST { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-C-V0APOLCOBR   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_C_V0APOLCOBR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0COMIFENAE  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0COMIFENAE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0VENDASBIL  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0VENDASBIL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0ADIANTA    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0ADIANTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0FORMAREC   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0FORMAREC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0HISTOREC   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0HISTOREC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-DESPESAS     PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_DESPESAS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         LD-PRODUTO        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis LD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WFIM-V1EMPRESA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1EMPRESA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1MOVDEBCC   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1MOVDEBCC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1BILHETE    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-BILCOBER     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_BILCOBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-PRODUTO      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-PARCELA      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-MOVIMENTO    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-HEADER       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_HEADER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-TRAILLER     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_TRAILLER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-CONVERSI     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_CONVERSI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WDUP-V0RCAP       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WDUP_V0RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WS-PROGRAMA       PIC  X(007)    VALUE SPACES.*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"  05         WS-SQLCODE        PIC  ----9.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "5", "----9."));
            /*"  05         WS-CANCBIL        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WS_CANCBIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         TB-MENSAGENS.*/
            public BI0072B_TB_MENSAGENS TB_MENSAGENS { get; set; } = new BI0072B_TB_MENSAGENS();
            public class BI0072B_TB_MENSAGENS : VarBasis
            {
                /*"    10       FILLER            PIC  X(037)    VALUE            '01INSUFICIENCIA DE FUNDOS'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"01INSUFICIENCIA DE FUNDOS");
                /*"    10       FILLER            PIC  X(037)    VALUE            '02CARTAO CANCELADO'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"02CARTAO CANCELADO");
                /*"    10       FILLER            PIC  X(037)    VALUE            '03SUBSTITUICAO CARTAO'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"03SUBSTITUICAO CARTAO");
                /*"    10       FILLER            PIC  X(037)    VALUE            '04CARTAO INVALIDO'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"04CARTAO INVALIDO");
                /*"    10       FILLER            PIC  X(037)    VALUE            '97ESTORNO S/COB OU ERRO DUPLICIDADE'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"97ESTORNO S/COB OU ERRO DUPLICIDADE");
                /*"    10       FILLER            PIC  X(037)    VALUE            '98ESTORNO S/COB NO PROXIMO MES'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"98ESTORNO S/COB NO PROXIMO MES");
                /*"    10       FILLER            PIC  X(037)    VALUE            '99CANCELA SEGURO'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"99CANCELA SEGURO");
                /*"  05         TB-MENSAGENS-R    REDEFINES TB-MENSAGENS.*/
            }
            private _REDEF_BI0072B_TB_MENSAGENS_R _tb_mensagens_r { get; set; }
            public _REDEF_BI0072B_TB_MENSAGENS_R TB_MENSAGENS_R
            {
                get { _tb_mensagens_r = new _REDEF_BI0072B_TB_MENSAGENS_R(); _.Move(TB_MENSAGENS, _tb_mensagens_r); VarBasis.RedefinePassValue(TB_MENSAGENS, _tb_mensagens_r, TB_MENSAGENS); _tb_mensagens_r.ValueChanged += () => { _.Move(_tb_mensagens_r, TB_MENSAGENS); }; return _tb_mensagens_r; }
                set { VarBasis.RedefinePassValue(value, _tb_mensagens_r, TB_MENSAGENS); }
            }  //Redefines
            public class _REDEF_BI0072B_TB_MENSAGENS_R : VarBasis
            {
                /*"    10       FILLER            OCCURS 7  TIMES.*/
                public ListBasis<BI0072B_FILLER_8> FILLER_8 { get; set; } = new ListBasis<BI0072B_FILLER_8>(7);
                public class BI0072B_FILLER_8 : VarBasis
                {
                    /*"      15     TB-RETORNO        PIC  9(002).*/
                    public IntBasis TB_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     TB-MENSAGEM       PIC  X(035).*/
                    public StringBasis TB_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "35", "X(035)."), @"");
                    /*"  05         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                    public BI0072B_FILLER_8()
                    {
                        TB_RETORNO.ValueChanged += OnValueChanged;
                        TB_MENSAGEM.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_BI0072B_TB_MENSAGENS_R()
                {
                    FILLER_8.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_BI0072B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_BI0072B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_BI0072B_FILLER_9(); _.Move(WDATA_REL, _filler_9); VarBasis.RedefinePassValue(WDATA_REL, _filler_9, WDATA_REL); _filler_9.ValueChanged += () => { _.Move(_filler_9, WDATA_REL); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, WDATA_REL); }
            }  //Redefines
            public class _REDEF_BI0072B_FILLER_9 : VarBasis
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
                /*"  05         WDATA-SQL.*/

                public _REDEF_BI0072B_FILLER_9()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_11.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public BI0072B_WDATA_SQL WDATA_SQL { get; set; } = new BI0072B_WDATA_SQL();
            public class BI0072B_WDATA_SQL : VarBasis
            {
                /*"    10       WDAT-AA-SQL       PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDAT_AA_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       WDAT-T1-SQL       PIC  X(001)    VALUE '-'.*/
                public StringBasis WDAT_T1_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WDAT-MM-SQL       PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_MM_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WDAT-T2-SQL       PIC  X(001)    VALUE '-'.*/
                public StringBasis WDAT_T2_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WDAT-DD-SQL       PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_DD_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_BI0072B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_BI0072B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_BI0072B_FILLER_12(); _.Move(WDATA_CURR, _filler_12); VarBasis.RedefinePassValue(WDATA_CURR, _filler_12, WDATA_CURR); _filler_12.ValueChanged += () => { _.Move(_filler_12, WDATA_CURR); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_BI0072B_FILLER_12 : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-AMD-R.*/

                public _REDEF_BI0072B_FILLER_12()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_13.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_14.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public BI0072B_WDATA_AMD_R WDATA_AMD_R { get; set; } = new BI0072B_WDATA_AMD_R();
            public class BI0072B_WDATA_AMD_R : VarBasis
            {
                /*"    10       WDATA-AA-AMD      PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_AMD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       WDATA-MM-AMD      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_AMD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WDATA-DD-AMD      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_AMD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-AMD         REDEFINES      WDATA-AMD-R                               PIC  9(008).*/
            }
            private _REDEF_IntBasis _wdata_amd { get; set; }
            public _REDEF_IntBasis WDATA_AMD
            {
                get { _wdata_amd = new _REDEF_IntBasis(new PIC("9", "008", "9(008).")); ; _.Move(WDATA_AMD_R, _wdata_amd); VarBasis.RedefinePassValue(WDATA_AMD_R, _wdata_amd, WDATA_AMD_R); _wdata_amd.ValueChanged += () => { _.Move(_wdata_amd, WDATA_AMD_R); }; return _wdata_amd; }
                set { VarBasis.RedefinePassValue(value, _wdata_amd, WDATA_AMD_R); }
            }  //Redefines
            /*"  05         WHORA-CURR.*/
            public BI0072B_WHORA_CURR WHORA_CURR { get; set; } = new BI0072B_WHORA_CURR();
            public class BI0072B_WHORA_CURR : VarBasis
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
            public BI0072B_WDATA_CABEC WDATA_CABEC { get; set; } = new BI0072B_WDATA_CABEC();
            public class BI0072B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WHORA-CABEC.*/
            }
            public BI0072B_WHORA_CABEC WHORA_CABEC { get; set; } = new BI0072B_WHORA_CABEC();
            public class BI0072B_WHORA_CABEC : VarBasis
            {
                /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-HOST        PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_HOST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-HOST.*/
            private _REDEF_BI0072B_FILLER_19 _filler_19 { get; set; }
            public _REDEF_BI0072B_FILLER_19 FILLER_19
            {
                get { _filler_19 = new _REDEF_BI0072B_FILLER_19(); _.Move(WDATA_HOST, _filler_19); VarBasis.RedefinePassValue(WDATA_HOST, _filler_19, WDATA_HOST); _filler_19.ValueChanged += () => { _.Move(_filler_19, WDATA_HOST); }; return _filler_19; }
                set { VarBasis.RedefinePassValue(value, _filler_19, WDATA_HOST); }
            }  //Redefines
            public class _REDEF_BI0072B_FILLER_19 : VarBasis
            {
                /*"    10       WDATA-AA-HOST     PIC  9(004).*/
                public IntBasis WDATA_AA_HOST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-HOST     PIC  9(002).*/
                public IntBasis WDATA_MM_HOST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-HOST     PIC  9(002).*/
                public IntBasis WDATA_DD_HOST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WSSIST-DTMOVABE   PIC  X(010)    VALUE SPACES.*/

                public _REDEF_BI0072B_FILLER_19()
                {
                    WDATA_AA_HOST.ValueChanged += OnValueChanged;
                    FILLER_20.ValueChanged += OnValueChanged;
                    WDATA_MM_HOST.ValueChanged += OnValueChanged;
                    FILLER_21.ValueChanged += OnValueChanged;
                    WDATA_DD_HOST.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WSSIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         WIDTCLIEMP        PIC  X(025)    VALUE SPACES.*/
            public StringBasis WIDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
            /*"  05         FILLER            REDEFINES      WIDTCLIEMP.*/
            private _REDEF_BI0072B_FILLER_22 _filler_22 { get; set; }
            public _REDEF_BI0072B_FILLER_22 FILLER_22
            {
                get { _filler_22 = new _REDEF_BI0072B_FILLER_22(); _.Move(WIDTCLIEMP, _filler_22); VarBasis.RedefinePassValue(WIDTCLIEMP, _filler_22, WIDTCLIEMP); _filler_22.ValueChanged += () => { _.Move(_filler_22, WIDTCLIEMP); }; return _filler_22; }
                set { VarBasis.RedefinePassValue(value, _filler_22, WIDTCLIEMP); }
            }  //Redefines
            public class _REDEF_BI0072B_FILLER_22 : VarBasis
            {
                /*"    10       WNUMBIL           PIC  9(015).*/
                public IntBasis WNUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10       FILLER            PIC  X(010).*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  05         WS-IDTCLIEMP      PIC  X(044)    VALUE SPACES.*/

                public _REDEF_BI0072B_FILLER_22()
                {
                    WNUMBIL.ValueChanged += OnValueChanged;
                    FILLER_23.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_IDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "44", "X(044)"), @"");
            /*"  05         FILLER            REDEFINES      WS-IDTCLIEMP.*/
            private _REDEF_BI0072B_FILLER_24 _filler_24 { get; set; }
            public _REDEF_BI0072B_FILLER_24 FILLER_24
            {
                get { _filler_24 = new _REDEF_BI0072B_FILLER_24(); _.Move(WS_IDTCLIEMP, _filler_24); VarBasis.RedefinePassValue(WS_IDTCLIEMP, _filler_24, WS_IDTCLIEMP); _filler_24.ValueChanged += () => { _.Move(_filler_24, WS_IDTCLIEMP); }; return _filler_24; }
                set { VarBasis.RedefinePassValue(value, _filler_24, WS_IDTCLIEMP); }
            }  //Redefines
            public class _REDEF_BI0072B_FILLER_24 : VarBasis
            {
                /*"    10       FILLER            PIC  X(023).*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"    10       WNUMPROP          PIC  9(013).*/
                public IntBasis WNUMPROP { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10       WNRPARCEL         PIC  9(004).*/
                public IntBasis WNRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(004).*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05         WAPOLICE          PIC  9(013)    VALUE  ZEROS.*/

                public _REDEF_BI0072B_FILLER_24()
                {
                    FILLER_25.ValueChanged += OnValueChanged;
                    WNUMPROP.ValueChanged += OnValueChanged;
                    WNRPARCEL.ValueChanged += OnValueChanged;
                    FILLER_26.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WAPOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         FILLER            REDEFINES      WAPOLICE.*/
            private _REDEF_BI0072B_FILLER_27 _filler_27 { get; set; }
            public _REDEF_BI0072B_FILLER_27 FILLER_27
            {
                get { _filler_27 = new _REDEF_BI0072B_FILLER_27(); _.Move(WAPOLICE, _filler_27); VarBasis.RedefinePassValue(WAPOLICE, _filler_27, WAPOLICE); _filler_27.ValueChanged += () => { _.Move(_filler_27, WAPOLICE); }; return _filler_27; }
                set { VarBasis.RedefinePassValue(value, _filler_27, WAPOLICE); }
            }  //Redefines
            public class _REDEF_BI0072B_FILLER_27 : VarBasis
            {
                /*"    10       WNUMAPOL          PIC  9(013).*/
                public IntBasis WNUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"  05         WS-NRTIT          PIC  9(014)    VALUE  ZEROS.*/

                public _REDEF_BI0072B_FILLER_27()
                {
                    WNUMAPOL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NRTIT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05         FILLER            REDEFINES      WS-NRTIT.*/
            private _REDEF_BI0072B_FILLER_28 _filler_28 { get; set; }
            public _REDEF_BI0072B_FILLER_28 FILLER_28
            {
                get { _filler_28 = new _REDEF_BI0072B_FILLER_28(); _.Move(WS_NRTIT, _filler_28); VarBasis.RedefinePassValue(WS_NRTIT, _filler_28, WS_NRTIT); _filler_28.ValueChanged += () => { _.Move(_filler_28, WS_NRTIT); }; return _filler_28; }
                set { VarBasis.RedefinePassValue(value, _filler_28, WS_NRTIT); }
            }  //Redefines
            public class _REDEF_BI0072B_FILLER_28 : VarBasis
            {
                /*"    10       WS-NUMTIT         PIC  9(013).*/
                public IntBasis WS_NUMTIT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10       WS-DIGTIT         PIC  9(001).*/
                public IntBasis WS_DIGTIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05         WAGENCIA          PIC  X(004)    VALUE SPACES.*/

                public _REDEF_BI0072B_FILLER_28()
                {
                    WS_NUMTIT.ValueChanged += OnValueChanged;
                    WS_DIGTIT.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WAGENCIA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05         FILLER            REDEFINES      WAGENCIA.*/
            private _REDEF_BI0072B_FILLER_29 _filler_29 { get; set; }
            public _REDEF_BI0072B_FILLER_29 FILLER_29
            {
                get { _filler_29 = new _REDEF_BI0072B_FILLER_29(); _.Move(WAGENCIA, _filler_29); VarBasis.RedefinePassValue(WAGENCIA, _filler_29, WAGENCIA); _filler_29.ValueChanged += () => { _.Move(_filler_29, WAGENCIA); }; return _filler_29; }
                set { VarBasis.RedefinePassValue(value, _filler_29, WAGENCIA); }
            }  //Redefines
            public class _REDEF_BI0072B_FILLER_29 : VarBasis
            {
                /*"    10       WAGEDEBITO        PIC  9(004).*/
                public IntBasis WAGEDEBITO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WNRAVISO          PIC  9(009)    VALUE ZEROS.*/

                public _REDEF_BI0072B_FILLER_29()
                {
                    WAGEDEBITO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WNRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         FILLER            REDEFINES      WNRAVISO.*/
            private _REDEF_BI0072B_FILLER_30 _filler_30 { get; set; }
            public _REDEF_BI0072B_FILLER_30 FILLER_30
            {
                get { _filler_30 = new _REDEF_BI0072B_FILLER_30(); _.Move(WNRAVISO, _filler_30); VarBasis.RedefinePassValue(WNRAVISO, _filler_30, WNRAVISO); _filler_30.ValueChanged += () => { _.Move(_filler_30, WNRAVISO); }; return _filler_30; }
                set { VarBasis.RedefinePassValue(value, _filler_30, WNRAVISO); }
            }  //Redefines
            public class _REDEF_BI0072B_FILLER_30 : VarBasis
            {
                /*"    10       WCONVENIOC        PIC  9(004).*/
                public IntBasis WCONVENIOC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WSEQUENCIA        PIC  9(005).*/
                public IntBasis WSEQUENCIA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  05         WCONVENIO         PIC  9(010)    VALUE ZEROS.*/

                public _REDEF_BI0072B_FILLER_30()
                {
                    WCONVENIOC.ValueChanged += OnValueChanged;
                    WSEQUENCIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WCONVENIO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"  05         WBILHETE          PIC  9(011)    VALUE ZEROS.*/
            public IntBasis WBILHETE { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  05         FILLER            REDEFINES      WBILHETE.*/
            private _REDEF_BI0072B_FILLER_31 _filler_31 { get; set; }
            public _REDEF_BI0072B_FILLER_31 FILLER_31
            {
                get { _filler_31 = new _REDEF_BI0072B_FILLER_31(); _.Move(WBILHETE, _filler_31); VarBasis.RedefinePassValue(WBILHETE, _filler_31, WBILHETE); _filler_31.ValueChanged += () => { _.Move(_filler_31, WBILHETE); }; return _filler_31; }
                set { VarBasis.RedefinePassValue(value, _filler_31, WBILHETE); }
            }  //Redefines
            public class _REDEF_BI0072B_FILLER_31 : VarBasis
            {
                /*"    10       FILLER            PIC  9(001).*/
                public IntBasis FILLER_32 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       WNRRCAP           PIC  9(009).*/
                public IntBasis WNRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10       FILLER            PIC  9(001).*/
                public IntBasis FILLER_33 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_BI0072B_FILLER_31()
                {
                    FILLER_32.ValueChanged += OnValueChanged;
                    WNRRCAP.ValueChanged += OnValueChanged;
                    FILLER_33.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  05         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_BI0072B_FILLER_34 _filler_34 { get; set; }
            public _REDEF_BI0072B_FILLER_34 FILLER_34
            {
                get { _filler_34 = new _REDEF_BI0072B_FILLER_34(); _.Move(WTIME_DAY, _filler_34); VarBasis.RedefinePassValue(WTIME_DAY, _filler_34, WTIME_DAY); _filler_34.ValueChanged += () => { _.Move(_filler_34, WTIME_DAY); }; return _filler_34; }
                set { VarBasis.RedefinePassValue(value, _filler_34, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_BI0072B_FILLER_34 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public BI0072B_WTIME_DAYR WTIME_DAYR { get; set; } = new BI0072B_WTIME_DAYR();
                public class BI0072B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA         PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT1         PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-MINU         PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT2         PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-SEGU         PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10       WTIME-2PT3         PIC  X(001).*/

                    public BI0072B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-CCSE         PIC  X(002).*/
                public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05         WS-TIME.*/

                public _REDEF_BI0072B_FILLER_34()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public BI0072B_WS_TIME WS_TIME { get; set; } = new BI0072B_WS_TIME();
            public class BI0072B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05            LC01.*/
            }
            public BI0072B_LC01 LC01 { get; set; } = new BI0072B_LC01();
            public class BI0072B_LC01 : VarBasis
            {
                /*"    10          LC01-RELATORIO  PIC  X(007) VALUE 'BI0072B'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"BI0072B");
                /*"    10          FILLER          PIC  X(036) VALUE  SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    10          LC01-EMPRESA    PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10          FILLER          PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    10          FILLER          PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    10          LC01-PAGINA     PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  05            LC02.*/
            }
            public BI0072B_LC02 LC02 { get; set; } = new BI0072B_LC02();
            public class BI0072B_LC02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    10          FILLER          PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    10          LC02-DATA       PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public BI0072B_LC03 LC03 { get; set; } = new BI0072B_LC03();
            public class BI0072B_LC03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(035) VALUE  SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"    10          FILLER          PIC  X(047) VALUE               'RELATORIO DE OCORRENCIAS NO CONVENIO 1028370056'*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"RELATORIO DE OCORRENCIAS NO CONVENIO 1028370056");
                /*"    10          FILLER          PIC  X(004) VALUE ' EM '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" EM ");
                /*"    10          LC03-DATA       PIC  X(010).*/
                public StringBasis LC03_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER          PIC  X(021) VALUE  SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    10          FILLER          PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    10          LC03-HORA       PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public BI0072B_LC04 LC04 { get; set; } = new BI0072B_LC04();
            public class BI0072B_LC04 : VarBasis
            {
                /*"    10          FILLER          PIC  X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05            LC06.*/
            }
            public BI0072B_LC06 LC06 { get; set; } = new BI0072B_LC06();
            public class BI0072B_LC06 : VarBasis
            {
                /*"    10          FILLER          PIC  X(014) VALUE      'FITA RETORNO: '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"FITA RETORNO: ");
                /*"    10          LC06-FITA-RET   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC06_FITA_RET { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER          PIC  X(114) VALUE  SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "114", "X(114)"), @"");
                /*"  05            LC05.*/
            }
            public BI0072B_LC05 LC05 { get; set; } = new BI0072B_LC05();
            public class BI0072B_LC05 : VarBasis
            {
                /*"    10          FILLER          PIC  X(006) VALUE  SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10          FILLER          PIC  X(022)  VALUE               'BILHETE'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"BILHETE");
                /*"    10          FILLER          PIC  X(010)  VALUE               'DT.VENC.'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DT.VENC.");
                /*"    10          FILLER          PIC  X(010)  VALUE               'TIPO'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"TIPO");
                /*"    10          FILLER          PIC  X(015)  VALUE               'VALOR DEB/CRED'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"VALOR DEB/CRED");
                /*"    10          FILLER          PIC  X(016)  VALUE               'VALOR PENDENTE'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"VALOR PENDENTE");
                /*"    10          FILLER          PIC  X(036)  VALUE               'MENSAGEM'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"MENSAGEM");
                /*"    10          FILLER          PIC  X(017)  VALUE               'FIT.ENV.'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"FIT.ENV.");
                /*"  05            LD01.*/
            }
            public BI0072B_LD01 LD01 { get; set; } = new BI0072B_LD01();
            public class BI0072B_LD01 : VarBasis
            {
                /*"    10          LD01-NUM-APOL   PIC  9(013).*/
                public IntBasis LD01_NUM_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-NRENDOS    PIC  9(009) BLANK WHEN ZEROS.*/
                public IntBasis LD01_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-NRPARCEL   PIC  9(002) BLANK WHEN ZEROS.*/
                public IntBasis LD01_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-DTVENCTO   PIC  X(010).*/
                public StringBasis LD01_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-TIPO       PIC  X(009).*/
                public StringBasis LD01_TIPO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-VLDEBITO   PIC  ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLDEBITO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-VLPENDEN   PIC  ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLPENDEN { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-MENSAGEM   PIC  X(035).*/
                public StringBasis LD01_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "35", "X(035)."), @"");
                /*"    10          FILLER          PIC  X(02) VALUE SPACES.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10          LD01-NSR        PIC  ZZZ99.*/
                public IntBasis LD01_NSR { get; set; } = new IntBasis(new PIC("9", "5", "ZZZ99."));
                /*"    10          FILLER          PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10          LD01-FOLLOW     PIC  X(008).*/
                public StringBasis LD01_FOLLOW { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"  05            LD02.*/
            }
            public BI0072B_LD02 LD02 { get; set; } = new BI0072B_LD02();
            public class BI0072B_LD02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE ALL '*'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"ALL");
                /*"  05            LD03.*/
            }
            public BI0072B_LD03 LD03 { get; set; } = new BI0072B_LD03();
            public class BI0072B_LD03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    10          FILLER          PIC  X(012) VALUE SPACES.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"    10          FILLER          PIC  X(021) VALUE 'BI0072B'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"BI0072B");
                /*"    10          FILLER          PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  05            LD04.*/
            }
            public BI0072B_LD04 LD04 { get; set; } = new BI0072B_LD04();
            public class BI0072B_LD04 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE    '*  NAO HOUVE MOVIMENTO NESTA DATA  *'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"*  NAO HOUVE MOVIMENTO NESTA DATA  *");
                /*"  05            LD05.*/
            }
            public BI0072B_LD05 LD05 { get; set; } = new BI0072B_LD05();
            public class BI0072B_LD05 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE    '*                                  *'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"*                                  *");
                /*"  05            LT01.*/
            }
            public BI0072B_LT01 LT01 { get; set; } = new BI0072B_LT01();
            public class BI0072B_LT01 : VarBasis
            {
                /*"    10          FILLER          PIC  X(030) VALUE SPACES.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    10          FILLER          PIC  X(018) VALUE               'TOTAL REJEITADOS  '.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"TOTAL REJEITADOS  ");
                /*"    10          LT01-VLDEBITO   PIC  ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_VLDEBITO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    10          FILLER          PIC  X(070) VALUE SPACES.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"  05        WABEND.*/
            }
            public BI0072B_WABEND WABEND { get; set; } = new BI0072B_WABEND();
            public class BI0072B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' BI0072B'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI0072B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public BI0072B_LK_LINK LK_LINK { get; set; } = new BI0072B_LK_LINK();
        public class BI0072B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TIT              PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TIT { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"01  AUX-TABELAS.*/
        }
        public BI0072B_AUX_TABELAS AUX_TABELAS { get; set; } = new BI0072B_AUX_TABELAS();
        public class BI0072B_AUX_TABELAS : VarBasis
        {
            /*"  03          WTABG-VALORES.*/
            public BI0072B_WTABG_VALORES WTABG_VALORES { get; set; } = new BI0072B_WTABG_VALORES();
            public class BI0072B_WTABG_VALORES : VarBasis
            {
                /*"    05        WTABG-OCORREPRD     OCCURS      2000   TIMES                                  INDEXED      BY    WS-PRD.*/
                public ListBasis<BI0072B_WTABG_OCORREPRD> WTABG_OCORREPRD { get; set; } = new ListBasis<BI0072B_WTABG_OCORREPRD>(2000);
                public class BI0072B_WTABG_OCORREPRD : VarBasis
                {
                    /*"      10      WTABG-CODPRODU      PIC S9(004)        COMP.*/
                    public IntBasis WTABG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WTABG-OCORRETIP     OCCURS       003   TIMES                                  INDEXED      BY    WS-TIP.*/
                    public ListBasis<BI0072B_WTABG_OCORRETIP> WTABG_OCORRETIP { get; set; } = new ListBasis<BI0072B_WTABG_OCORRETIP>(003);
                    public class BI0072B_WTABG_OCORRETIP : VarBasis
                    {
                        /*"        15    WTABG-TIPO          PIC  X(001).*/
                        public StringBasis WTABG_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"        15    WTABG-OCORRESIT     OCCURS       002   TIMES                                  INDEXED      BY    WS-SIT.*/
                        public ListBasis<BI0072B_WTABG_OCORRESIT> WTABG_OCORRESIT { get; set; } = new ListBasis<BI0072B_WTABG_OCORRESIT>(002);
                        public class BI0072B_WTABG_OCORRESIT : VarBasis
                        {
                            /*"          20  WTABG-SITUACAO      PIC  X(001).*/
                            public StringBasis WTABG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                            /*"          20  WTABG-QTDE          PIC S9(009)        COMP.*/
                            public IntBasis WTABG_QTDE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                            /*"          20  WTABG-VLPRMTOT      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLTARIFA      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLBALCAO      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLIOCC        PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLDESCON      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                        }
                    }
                }
            }
        }


        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.NUMERAES NUMERAES { get; set; } = new Dclgens.NUMERAES();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public BI0072B_V0PRODUTO V0PRODUTO { get; set; } = new BI0072B_V0PRODUTO();
        public BI0072B_V0MOVIMCOB V0MOVIMCOB { get; set; } = new BI0072B_V0MOVIMCOB();
        public BI0072B_V0PARC V0PARC { get; set; } = new BI0072B_V0PARC();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RBI0072B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RBI0072B.SetFile(RBI0072B_FILE_NAME_P);

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
            /*" -860- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -863- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -866- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -869- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -870- DISPLAY 'PROGRAMA EM EXECUCAO BI0072B   ' . */
            _.Display($"PROGRAMA EM EXECUCAO BI0072B   ");

            /*" -871- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -883- DISPLAY 'VERSAO V.12 107.303 03/03/2018 ' . */
            _.Display($"VERSAO V.12 107.303 03/03/2018 ");

            /*" -884- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -886- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -888- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -891- MOVE 102837 TO WCONVENIO. */
            _.Move(102837, AREA_DE_WORK.WCONVENIO);

            /*" -892- PERFORM R0300-00-DECLARE-MOVIMCOB. */

            R0300_00_DECLARE_MOVIMCOB_SECTION();

            /*" -894- PERFORM R0310-00-FETCH-MOVIMCOB. */

            R0310_00_FETCH_MOVIMCOB_SECTION();

            /*" -895- IF WFIM-MOVIMENTO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty())
            {

                /*" -896- IF AC-LIDOS EQUAL ZEROS */

                if (AREA_DE_WORK.AC_LIDOS == 00)
                {

                    /*" -897- PERFORM R3000-00-CABECALHOS */

                    R3000_00_CABECALHOS_SECTION();

                    /*" -898- PERFORM R3100-00-RELAT-SEM-MOVIMENTO */

                    R3100_00_RELAT_SEM_MOVIMENTO_SECTION();

                    /*" -899- END-IF */
                }


                /*" -901- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -904- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -906- PERFORM R2000-00-PROCESSA-FINAL. */

            R2000_00_PROCESSA_FINAL_SECTION();

            /*" -907- DISPLAY 'REGISTROS LIDOS ........... ' AC-LIDOS */
            _.Display($"REGISTROS LIDOS ........... {AREA_DE_WORK.AC_LIDOS}");

            /*" -908- DISPLAY ' ' */
            _.Display($" ");

            /*" -909- DISPLAY '** INSERIDOS **' */
            _.Display($"** INSERIDOS **");

            /*" -910- DISPLAY ' ' */
            _.Display($" ");

            /*" -911- DISPLAY ' V0FOLLOWUP ............... ' AC-I-V0FOLLOWUP */
            _.Display($" V0FOLLOWUP ............... {AREA_DE_WORK.AC_I_V0FOLLOWUP}");

            /*" -912- DISPLAY ' ' . */
            _.Display($" ");

            /*" -913- DISPLAY ' ** ALTERADOS **' */
            _.Display($" ** ALTERADOS **");

            /*" -914- DISPLAY ' ' */
            _.Display($" ");

            /*" -915- DISPLAY ' V0MOVDEBCC_CEF ........... ' AC-U-V0MOVDEBCC. */
            _.Display($" V0MOVDEBCC_CEF ........... {AREA_DE_WORK.AC_U_V0MOVDEBCC}");

            /*" -916- DISPLAY ' ' . */
            _.Display($" ");

            /*" -917- DISPLAY ' SUSPENDE DEMAIS PARCELAS . ' AC-S-V0MOVDEBCC. */
            _.Display($" SUSPENDE DEMAIS PARCELAS . {AREA_DE_WORK.AC_S_V0MOVDEBCC}");

            /*" -918- DISPLAY ' ' . */
            _.Display($" ");

            /*" -919- DISPLAY ' BILHETES CANCELADOS ...... ' AC-C-V0BILHETE. */
            _.Display($" BILHETES CANCELADOS ...... {AREA_DE_WORK.AC_C_V0BILHETE}");

            /*" -920- DISPLAY ' ' . */
            _.Display($" ");

            /*" -921- DISPLAY ' ENDOSSOS CANCELADOS ...... ' AC-C-V0ENDOSSO. */
            _.Display($" ENDOSSOS CANCELADOS ...... {AREA_DE_WORK.AC_C_V0ENDOSSO}");

            /*" -922- DISPLAY ' ' . */
            _.Display($" ");

            /*" -923- DISPLAY ' PARCELAS CANCELADAS ...... ' AC-C-V0PARCELAS. */
            _.Display($" PARCELAS CANCELADAS ...... {AREA_DE_WORK.AC_C_V0PARCELAS}");

            /*" -924- DISPLAY ' ' . */
            _.Display($" ");

            /*" -925- DISPLAY ' PARCELAS HIST CANCELADAS . ' AC-C-V0PARCHIST. */
            _.Display($" PARCELAS HIST CANCELADAS . {AREA_DE_WORK.AC_C_V0PARCHIST}");

            /*" -926- DISPLAY ' ' . */
            _.Display($" ");

            /*" -927- DISPLAY ' APOLICE COBR ALTERADOS ... ' AC-C-V0APOLCOBR. */
            _.Display($" APOLICE COBR ALTERADOS ... {AREA_DE_WORK.AC_C_V0APOLCOBR}");

            /*" -927- DISPLAY ' ' . */
            _.Display($" ");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -935- CLOSE RBI0072B. */
            RBI0072B.Close();

            /*" -936- DISPLAY '*--- BI0072B   ' . */
            _.Display($"*--- BI0072B   ");

            /*" -938- DISPLAY '    FIM NORMAL ' . */
            _.Display($"    FIM NORMAL ");

            /*" -940- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -940- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -942- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -954- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -956- OPEN OUTPUT RBI0072B. */
            RBI0072B.Open(REG_BI0072B);

            /*" -958- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -963- PERFORM R0120-00-MONTA-EMPRESA. */

            R0120_00_MONTA_EMPRESA_SECTION();

            /*" -964- SET WS-PRD TO 1. */
            WS_PRD.Value = 1;

            /*" -967- MOVE ZEROS TO V0PROD-CODPRODU. */
            _.Move(0, V0PROD_CODPRODU);

            /*" -969- PERFORM R0220-00-MOVE-DADOS. */

            R0220_00_MOVE_DADOS_SECTION();

            /*" -970- MOVE 1 TO LD-PRODUTO */
            _.Move(1, AREA_DE_WORK.LD_PRODUTO);

            /*" -971- MOVE SPACES TO WFIM-PRODUTO */
            _.Move("", AREA_DE_WORK.WFIM_PRODUTO);

            /*" -973- PERFORM R0200-00-DECLARE-V0PRODUTO. */

            R0200_00_DECLARE_V0PRODUTO_SECTION();

            /*" -976- PERFORM R0210-00-FETCH-V0PRODUTO UNTIL WFIM-PRODUTO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_PRODUTO.IsEmpty()))
            {

                R0210_00_FETCH_V0PRODUTO_SECTION();
            }

            /*" -979- MOVE 9999 TO V0PROD-CODPRODU. */
            _.Move(9999, V0PROD_CODPRODU);

            /*" -985- PERFORM R0220-00-MOVE-DADOS UNTIL WS-SUBS GREATER 2000. */

            while (!(AREA_DE_WORK.WS_SUBS > 2000))
            {

                R0220_00_MOVE_DADOS_SECTION();
            }

            /*" -986- MOVE ZEROS TO WSHOST-QTDE. */
            _.Move(0, WSHOST_QTDE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -998- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1005- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1008- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1009- DISPLAY 'BI0072B - SISTEMA NAO ESTA CADASTRADO' */
                _.Display($"BI0072B - SISTEMA NAO ESTA CADASTRADO");

                /*" -1011- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1012- MOVE V1SIST-DTCURRENT TO WDATA-CURR. */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -1013- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_12.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1014- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_12.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1015- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_12.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1017- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC02.LC02_DATA);

            /*" -1018- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -1019- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -1020- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -1021- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -1023- MOVE WHORA-CABEC TO LC03-HORA. */
            _.Move(AREA_DE_WORK.WHORA_CABEC, AREA_DE_WORK.LC03.LC03_HORA);

            /*" -1024- MOVE V1SIST-DTMOVABE TO WDATA-HOST. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_HOST);

            /*" -1025- MOVE WDATA-AA-HOST TO WDATA-AA-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_19.WDATA_AA_HOST, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1026- MOVE WDATA-MM-HOST TO WDATA-MM-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_19.WDATA_MM_HOST, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1027- MOVE WDATA-DD-HOST TO WDATA-DD-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_19.WDATA_DD_HOST, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1029- MOVE WDATA-CABEC TO LC03-DATA. */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC03.LC03_DATA);

            /*" -1030- MOVE WDATA-DD-CURR TO WDATA-DD-HOST. */
            _.Move(AREA_DE_WORK.FILLER_12.WDATA_DD_CURR, AREA_DE_WORK.FILLER_19.WDATA_DD_HOST);

            /*" -1031- MOVE WDATA-MM-CURR TO WDATA-MM-HOST. */
            _.Move(AREA_DE_WORK.FILLER_12.WDATA_MM_CURR, AREA_DE_WORK.FILLER_19.WDATA_MM_HOST);

            /*" -1032- MOVE WDATA-AA-CURR TO WDATA-AA-HOST. */
            _.Move(AREA_DE_WORK.FILLER_12.WDATA_AA_CURR, AREA_DE_WORK.FILLER_19.WDATA_AA_HOST);

            /*" -1032- MOVE WDATA-HOST TO WSSIST-DTMOVABE. */
            _.Move(AREA_DE_WORK.WDATA_HOST, AREA_DE_WORK.WSSIST_DTMOVABE);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1005- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'BI' END-EXEC. */

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
        /*" R0120-00-MONTA-EMPRESA-SECTION */
        private void R0120_00_MONTA_EMPRESA_SECTION()
        {
            /*" -1046- MOVE '0120' TO WNR-EXEC-SQL. */
            _.Move("0120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1051- PERFORM R0120_00_MONTA_EMPRESA_DB_SELECT_1 */

            R0120_00_MONTA_EMPRESA_DB_SELECT_1();

            /*" -1054- MOVE V1EMPR-NOM-EMP TO LK-TIT */
            _.Move(V1EMPR_NOM_EMP, LK_LINK.LK_TIT);

            /*" -1056- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -1057- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -1058- MOVE LK-TIT TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TIT, AREA_DE_WORK.LC01.LC01_EMPRESA);

                /*" -1059- ELSE */
            }
            else
            {


                /*" -1060- DISPLAY 'PROBLEMA CALL V1EMPRESA' */
                _.Display($"PROBLEMA CALL V1EMPRESA");

                /*" -1060- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" R0120-00-MONTA-EMPRESA-DB-SELECT-1 */
        public void R0120_00_MONTA_EMPRESA_DB_SELECT_1()
        {
            /*" -1051- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPR-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var r0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1 = new R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1.Execute(r0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPR_NOM_EMP, V1EMPR_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-SECTION */
        private void R0200_00_DECLARE_V0PRODUTO_SECTION()
        {
            /*" -1073- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1079- PERFORM R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1 */

            R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1();

            /*" -1081- PERFORM R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1 */

            R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1();

            /*" -1084- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1085- DISPLAY 'R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ' */
                _.Display($"R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ");

                /*" -1085- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1()
        {
            /*" -1079- EXEC SQL DECLARE V0PRODUTO CURSOR FOR SELECT CODPRODU FROM SEGUROS.V0PRODUTO WHERE COD_EMPRESA IN (0, 10, 11) ORDER BY CODPRODU END-EXEC. */
            V0PRODUTO = new BI0072B_V0PRODUTO(false);
            string GetQuery_V0PRODUTO()
            {
                var query = @$"SELECT CODPRODU 
							FROM SEGUROS.V0PRODUTO 
							WHERE COD_EMPRESA IN (0
							, 10
							, 11) 
							ORDER BY CODPRODU";

                return query;
            }
            V0PRODUTO.GetQueryEvent += GetQuery_V0PRODUTO;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-DB-OPEN-1 */
        public void R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1()
        {
            /*" -1081- EXEC SQL OPEN V0PRODUTO END-EXEC. */

            V0PRODUTO.Open();

        }

        [StopWatch]
        /*" R0300-00-DECLARE-MOVIMCOB-DB-DECLARE-1 */
        public void R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1()
        {
            /*" -1255- EXEC SQL DECLARE V0MOVIMCOB CURSOR FOR SELECT COD_EMPRESA , COD_MOVIMENTO , COD_BANCO , COD_AGENCIA , NUM_AVISO , NUM_FITA , DATA_MOVIMENTO , DATA_QUITACAO , (DATA_QUITACAO + 001 DAYS) , (DATA_QUITACAO + 366 DAYS) , NUM_TITULO , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , VAL_TITULO , VAL_CREDITO , SIT_REGISTRO , NOME_SEGURADO , NUM_NOSSO_TITULO , VAL_IOCC , TIPO_MOVIMENTO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE SIT_REGISTRO = ' ' AND TIPO_MOVIMENTO IN ( 'T' , 'U' ) AND DATA_MOVIMENTO <= :V1SIST-DTMOVABE FOR UPDATE OF SIT_REGISTRO END-EXEC. */
            V0MOVIMCOB = new BI0072B_V0MOVIMCOB(true);
            string GetQuery_V0MOVIMCOB()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							COD_MOVIMENTO
							, 
							COD_BANCO
							, 
							COD_AGENCIA
							, 
							NUM_AVISO
							, 
							NUM_FITA
							, 
							DATA_MOVIMENTO
							, 
							DATA_QUITACAO
							, 
							(DATA_QUITACAO + 001 DAYS)
							, 
							(DATA_QUITACAO + 366 DAYS)
							, 
							NUM_TITULO
							, 
							NUM_APOLICE
							, 
							NUM_ENDOSSO
							, 
							NUM_PARCELA
							, 
							VAL_TITULO
							, 
							VAL_CREDITO
							, 
							SIT_REGISTRO
							, 
							NOME_SEGURADO
							, 
							NUM_NOSSO_TITULO
							, 
							VAL_IOCC
							, 
							TIPO_MOVIMENTO 
							FROM SEGUROS.MOVIMENTO_COBRANCA 
							WHERE SIT_REGISTRO = ' ' 
							AND TIPO_MOVIMENTO IN ( 'T'
							, 'U' ) 
							AND DATA_MOVIMENTO <= '{V1SIST_DTMOVABE}'";

                return query;
            }
            V0MOVIMCOB.GetQueryEvent += GetQuery_V0MOVIMCOB;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-SECTION */
        private void R0210_00_FETCH_V0PRODUTO_SECTION()
        {
            /*" -1097- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1099- PERFORM R0210_00_FETCH_V0PRODUTO_DB_FETCH_1 */

            R0210_00_FETCH_V0PRODUTO_DB_FETCH_1();

            /*" -1102- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1102- PERFORM R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1 */

                R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1();

                /*" -1104- MOVE 'S' TO WFIM-PRODUTO */
                _.Move("S", AREA_DE_WORK.WFIM_PRODUTO);

                /*" -1106- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1107- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1108- DISPLAY 'R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ' */
                _.Display($"R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ");

                /*" -1110- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1115- ADD 1 TO LD-PRODUTO. */
            AREA_DE_WORK.LD_PRODUTO.Value = AREA_DE_WORK.LD_PRODUTO + 1;

            /*" -1116- IF LD-PRODUTO GREATER 2000 */

            if (AREA_DE_WORK.LD_PRODUTO > 2000)
            {

                /*" -1116- PERFORM R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2 */

                R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2();

                /*" -1118- DISPLAY 'R0210-00 - ESTOURO TABELA INTERNA PRODUTO' */
                _.Display($"R0210-00 - ESTOURO TABELA INTERNA PRODUTO");

                /*" -1120- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1120- PERFORM R0220-00-MOVE-DADOS. */

            R0220_00_MOVE_DADOS_SECTION();

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-FETCH-1 */
        public void R0210_00_FETCH_V0PRODUTO_DB_FETCH_1()
        {
            /*" -1099- EXEC SQL FETCH V0PRODUTO INTO :V0PROD-CODPRODU END-EXEC. */

            if (V0PRODUTO.Fetch())
            {
                _.Move(V0PRODUTO.V0PROD_CODPRODU, V0PROD_CODPRODU);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1()
        {
            /*" -1102- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-CLOSE-2 */
        public void R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2()
        {
            /*" -1116- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }

        [StopWatch]
        /*" R0220-00-MOVE-DADOS-SECTION */
        private void R0220_00_MOVE_DADOS_SECTION()
        {
            /*" -1132- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1135- MOVE V0PROD-CODPRODU TO WTABG-CODPRODU(WS-PRD). */
            _.Move(V0PROD_CODPRODU, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU);

            /*" -1136- SET WS-TIP TO 1 */
            WS_TIP.Value = 1;

            /*" -1138- PERFORM R0250-00-MOVE-TIPO 03 TIMES. */

            for (int i = 0; i < 3; i++)
            {

                R0250_00_MOVE_TIPO_SECTION();

            }

            /*" -1139- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

            /*" -1139- SET WS-SUBS TO WS-PRD. */
            AREA_DE_WORK.WS_SUBS.Value = WS_PRD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-MOVE-TIPO-SECTION */
        private void R0250_00_MOVE_TIPO_SECTION()
        {
            /*" -1151- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1156- SET WS-SUBS1 TO WS-TIP. */
            AREA_DE_WORK.WS_SUBS1.Value = WS_TIP;

            /*" -1157- IF WS-SUBS1 EQUAL 1 */

            if (AREA_DE_WORK.WS_SUBS1 == 1)
            {

                /*" -1159- MOVE 'D' TO WTABG-TIPO(WS-PRD WS-TIP) */
                _.Move("D", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                /*" -1163- ELSE */
            }
            else
            {


                /*" -1164- IF WS-SUBS1 EQUAL 2 */

                if (AREA_DE_WORK.WS_SUBS1 == 2)
                {

                    /*" -1166- MOVE 'R' TO WTABG-TIPO(WS-PRD WS-TIP) */
                    _.Move("R", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                    /*" -1170- ELSE */
                }
                else
                {


                    /*" -1173- MOVE 'S' TO WTABG-TIPO(WS-PRD WS-TIP). */
                    _.Move("S", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);
                }

            }


            /*" -1174- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -1176- PERFORM R0260-00-MOVE-SITUACAO 02 TIMES. */

            for (int i = 0; i < 2; i++)
            {

                R0260_00_MOVE_SITUACAO_SECTION();

            }

            /*" -1176- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-MOVE-SITUACAO-SECTION */
        private void R0260_00_MOVE_SITUACAO_SECTION()
        {
            /*" -1189- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1197- MOVE ZEROS TO WTABG-QTDE(WS-PRD WS-TIP WS-SIT) WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT) WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT). */
            _.Move(0, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON);

            /*" -1201- SET WS-SUBS2 TO WS-SIT. */
            AREA_DE_WORK.WS_SUBS2.Value = WS_SIT;

            /*" -1202- IF WS-SUBS2 EQUAL 1 */

            if (AREA_DE_WORK.WS_SUBS2 == 1)
            {

                /*" -1204- MOVE '0' TO WTABG-SITUACAO(WS-PRD WS-TIP WS-SIT) */
                _.Move("0", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);

                /*" -1208- ELSE */
            }
            else
            {


                /*" -1211- MOVE '2' TO WTABG-SITUACAO(WS-PRD WS-TIP WS-SIT). */
                _.Move("2", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);
            }


            /*" -1211- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-MOVIMCOB-SECTION */
        private void R0300_00_DECLARE_MOVIMCOB_SECTION()
        {
            /*" -1227- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1255- PERFORM R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1 */

            R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1();

            /*" -1257- PERFORM R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1 */

            R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1();

            /*" -1261- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1262- DISPLAY 'R0300-00 - PROBLEMAS DECLARE (MOVIMCOB)   ' */
                _.Display($"R0300-00 - PROBLEMAS DECLARE (MOVIMCOB)   ");

                /*" -1262- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0300-00-DECLARE-MOVIMCOB-DB-OPEN-1 */
        public void R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1()
        {
            /*" -1257- EXEC SQL OPEN V0MOVIMCOB END-EXEC. */

            V0MOVIMCOB.Open();

        }

        [StopWatch]
        /*" R1471-00-DECLARE-V0PARC-DB-DECLARE-1 */
        public void R1471_00_DECLARE_V0PARC_DB_DECLARE_1()
        {
            /*" -1924- EXEC SQL DECLARE V0PARC CURSOR FOR SELECT NRENDOS FROM SEGUROS.V0PARCELA WHERE NUM_APOLICE = :V1MVDB-NUM-APOLICE AND SITUACAO = '0' ORDER BY NRENDOS WITH UR END-EXEC. */
            V0PARC = new BI0072B_V0PARC(true);
            string GetQuery_V0PARC()
            {
                var query = @$"SELECT NRENDOS 
							FROM SEGUROS.V0PARCELA 
							WHERE NUM_APOLICE = '{V1MVDB_NUM_APOLICE}' 
							AND SITUACAO = '0' 
							ORDER BY NRENDOS";

                return query;
            }
            V0PARC.GetQueryEvent += GetQuery_V0PARC;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-MOVIMCOB-SECTION */
        private void R0310_00_FETCH_MOVIMCOB_SECTION()
        {
            /*" -1276- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1298- PERFORM R0310_00_FETCH_MOVIMCOB_DB_FETCH_1 */

            R0310_00_FETCH_MOVIMCOB_DB_FETCH_1();

            /*" -1302- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1302- PERFORM R0310_00_FETCH_MOVIMCOB_DB_CLOSE_1 */

                R0310_00_FETCH_MOVIMCOB_DB_CLOSE_1();

                /*" -1304- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

                /*" -1306- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1307- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1308- DISPLAY 'R0310-00 - PROBLEMAS FETCH   (MOVIMCOB)   ' */
                _.Display($"R0310-00 - PROBLEMAS FETCH   (MOVIMCOB)   ");

                /*" -1310- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1313- MOVE MOVIMCOB-VAL-TITULO TO MOVCC-VLRDEBITO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, MOVCC_REGISTRO.MOVCC_VLRDEBITO);

            /*" -1316- MOVE MOVIMCOB-COD-MOVIMENTO TO MOVCC-NSR. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO, MOVCC_REGISTRO.MOVCC_NSR);

            /*" -1319- MOVE MOVIMCOB-VAL-IOCC TO MOVCC-CODRETORNO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC, MOVCC_REGISTRO.MOVCC_CODRETORNO);

            /*" -1322- MOVE MOVIMCOB-NUM-FITA TO V1MVDB-SEQUENCIA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA, V1MVDB_SEQUENCIA);

            /*" -1325- MOVE MOVIMCOB-NUM-AVISO TO WSHOST-NUM-LOTE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, WSHOST_NUM_LOTE);

            /*" -1328- MOVE MOVIMCOB-NUM-TITULO TO WNUMBIL. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO, AREA_DE_WORK.FILLER_22.WNUMBIL);

            /*" -1330- ADD 1 TO AC-LIDOS. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0310-00-FETCH-MOVIMCOB-DB-FETCH-1 */
        public void R0310_00_FETCH_MOVIMCOB_DB_FETCH_1()
        {
            /*" -1298- EXEC SQL FETCH V0MOVIMCOB INTO :MOVIMCOB-COD-EMPRESA , :MOVIMCOB-COD-MOVIMENTO , :MOVIMCOB-COD-BANCO , :MOVIMCOB-COD-AGENCIA , :MOVIMCOB-NUM-AVISO , :MOVIMCOB-NUM-FITA , :MOVIMCOB-DATA-MOVIMENTO , :MOVIMCOB-DATA-QUITACAO , :WSHOST-DATA-INIVIGENCIA , :WSHOST-DATA-TERVIGENCIA , :MOVIMCOB-NUM-TITULO , :MOVIMCOB-NUM-APOLICE , :MOVIMCOB-NUM-ENDOSSO , :MOVIMCOB-NUM-PARCELA , :MOVIMCOB-VAL-TITULO , :MOVIMCOB-VAL-CREDITO , :MOVIMCOB-SIT-REGISTRO , :MOVIMCOB-NOME-SEGURADO , :MOVIMCOB-NUM-NOSSO-TITULO , :MOVIMCOB-VAL-IOCC , :MOVIMCOB-TIPO-MOVIMENTO END-EXEC. */

            if (V0MOVIMCOB.Fetch())
            {
                _.Move(V0MOVIMCOB.MOVIMCOB_COD_EMPRESA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA);
                _.Move(V0MOVIMCOB.MOVIMCOB_COD_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO);
                _.Move(V0MOVIMCOB.MOVIMCOB_COD_BANCO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);
                _.Move(V0MOVIMCOB.MOVIMCOB_COD_AGENCIA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_AVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_FITA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA);
                _.Move(V0MOVIMCOB.MOVIMCOB_DATA_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO);
                _.Move(V0MOVIMCOB.MOVIMCOB_DATA_QUITACAO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO);
                _.Move(V0MOVIMCOB.WSHOST_DATA_INIVIGENCIA, WSHOST_DATA_INIVIGENCIA);
                _.Move(V0MOVIMCOB.WSHOST_DATA_TERVIGENCIA, WSHOST_DATA_TERVIGENCIA);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_ENDOSSO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_PARCELA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA);
                _.Move(V0MOVIMCOB.MOVIMCOB_VAL_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);
                _.Move(V0MOVIMCOB.MOVIMCOB_VAL_CREDITO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO);
                _.Move(V0MOVIMCOB.MOVIMCOB_SIT_REGISTRO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NOME_SEGURADO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_NOSSO_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);
                _.Move(V0MOVIMCOB.MOVIMCOB_VAL_IOCC, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC);
                _.Move(V0MOVIMCOB.MOVIMCOB_TIPO_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-MOVIMCOB-DB-CLOSE-1 */
        public void R0310_00_FETCH_MOVIMCOB_DB_CLOSE_1()
        {
            /*" -1302- EXEC SQL CLOSE V0MOVIMCOB END-EXEC */

            V0MOVIMCOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1450- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1451- MOVE ZEROS TO WSHOST-CODPRODU */
            _.Move(0, WSHOST_CODPRODU);

            /*" -1452- MOVE '0' TO WSHOST-SITUACAO. */
            _.Move("0", WSHOST_SITUACAO);

            /*" -1456- MOVE '1' TO MOVIMCOB-SIT-REGISTRO. */
            _.Move("1", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

            /*" -1457- MOVE MOVCC-IDTCLIEMP TO WS-IDTCLIEMP. */
            _.Move(MOVCC_REGISTRO.MOVCC_IDTCLIEMP, AREA_DE_WORK.WS_IDTCLIEMP);

            /*" -1460- MOVE ZEROS TO WNUMAPOL V1MVDB-NUM-APOLICE V1MVDB-NRPARCEL. */
            _.Move(0, AREA_DE_WORK.FILLER_27.WNUMAPOL);
            _.Move(0, V1MVDB_NUM_APOLICE);
            _.Move(0, V1MVDB_NRPARCEL);


            /*" -1461- IF WNRPARCEL IS NOT NUMERIC */

            if (!AREA_DE_WORK.FILLER_24.WNRPARCEL.IsNumeric())
            {

                /*" -1462- MOVE ZEROS TO WNRPARCEL */
                _.Move(0, AREA_DE_WORK.FILLER_24.WNRPARCEL);

                /*" -1464- END-IF. */
            }


            /*" -1467- MOVE WNRPARCEL TO V1MVDB-NRENDOS. */
            _.Move(AREA_DE_WORK.FILLER_24.WNRPARCEL, V1MVDB_NRENDOS);

            /*" -1469- PERFORM R1050-00-SELECT-CONVERSI. */

            R1050_00_SELECT_CONVERSI_SECTION();

            /*" -1471- IF WTEM-CONVERSI EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_CONVERSI == "N")
            {

                /*" -1473- MOVE 'DOCUMENTO INEXISTENTE NO CADASTRO' TO LD01-MENSAGEM */
                _.Move("DOCUMENTO INEXISTENTE NO CADASTRO", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                /*" -1474- MOVE '3' TO V1MVDB-SIT-COBRANCA */
                _.Move("3", V1MVDB_SIT_COBRANCA);

                /*" -1475- MOVE 99 TO V1MVDB-COD-RET-CEF */
                _.Move(99, V1MVDB_COD_RET_CEF);

                /*" -1476- MOVE ZEROS TO V1MVDB-VLR-CREDITO */
                _.Move(0, V1MVDB_VLR_CREDITO);

                /*" -1477- MOVE WDATA-HOST TO V0FOLL-DTQITBCO */
                _.Move(AREA_DE_WORK.WDATA_HOST, V0FOLL_DTQITBCO);

                /*" -1478- MOVE '1' TO V0FOLL-CDERRO01 */
                _.Move("1", V0FOLL_CDERRO01);

                /*" -1479- MOVE V0PRFD-NUMSICOB TO WNUMBIL */
                _.Move(V0PRFD_NUMSICOB, AREA_DE_WORK.FILLER_22.WNUMBIL);

                /*" -1480- PERFORM R4000-00-INSERT-V0FOLLOWUP */

                R4000_00_INSERT_V0FOLLOWUP_SECTION();

                /*" -1484- PERFORM R1200-00-IMPRIME-RELATORIO */

                R1200_00_IMPRIME_RELATORIO_SECTION();

                /*" -1488- GO TO R1000-50-SAIDA. */

                R1000_50_SAIDA(); //GOTO
                return;
            }


            /*" -1489- MOVE SPACES TO WFIM-V1BILHETE. */
            _.Move("", AREA_DE_WORK.WFIM_V1BILHETE);

            /*" -1491- MOVE V0PRFD-NUMSICOB TO V0BILH-NUMBIL. */
            _.Move(V0PRFD_NUMSICOB, V0BILH_NUMBIL);

            /*" -1493- PERFORM R1160-00-SELECT-V1BILHETE. */

            R1160_00_SELECT_V1BILHETE_SECTION();

            /*" -1494- IF WFIM-V1BILHETE NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1BILHETE.IsEmpty())
            {

                /*" -1496- MOVE 'DOCUMENTO INEXISTENTE NO CADASTRO' TO LD01-MENSAGEM */
                _.Move("DOCUMENTO INEXISTENTE NO CADASTRO", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                /*" -1497- MOVE '3' TO V1MVDB-SIT-COBRANCA */
                _.Move("3", V1MVDB_SIT_COBRANCA);

                /*" -1498- MOVE 99 TO V1MVDB-COD-RET-CEF */
                _.Move(99, V1MVDB_COD_RET_CEF);

                /*" -1499- MOVE ZEROS TO V1MVDB-VLR-CREDITO */
                _.Move(0, V1MVDB_VLR_CREDITO);

                /*" -1500- MOVE WDATA-HOST TO V0FOLL-DTQITBCO */
                _.Move(AREA_DE_WORK.WDATA_HOST, V0FOLL_DTQITBCO);

                /*" -1501- MOVE '1' TO V0FOLL-CDERRO01 */
                _.Move("1", V0FOLL_CDERRO01);

                /*" -1502- MOVE V0PRFD-NUMSICOB TO WNUMBIL */
                _.Move(V0PRFD_NUMSICOB, AREA_DE_WORK.FILLER_22.WNUMBIL);

                /*" -1503- PERFORM R4000-00-INSERT-V0FOLLOWUP */

                R4000_00_INSERT_V0FOLLOWUP_SECTION();

                /*" -1504- PERFORM R1200-00-IMPRIME-RELATORIO */

                R1200_00_IMPRIME_RELATORIO_SECTION();

                /*" -1506- GO TO R1000-50-SAIDA. */

                R1000_50_SAIDA(); //GOTO
                return;
            }


            /*" -1509- IF V0BILH-NUMAPOL EQUAL ZEROS AND MOVCC-CODRETORNO NOT EQUAL ZEROS AND MOVIMCOB-TIPO-MOVIMENTO EQUAL 'U' */

            if (V0BILH_NUMAPOL == 00 && MOVCC_REGISTRO.MOVCC_CODRETORNO != 00 && MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO == "U")
            {

                /*" -1510- PERFORM R3462-00-UPDATE-BILHETE */

                R3462_00_UPDATE_BILHETE_SECTION();

                /*" -1512- GO TO R1000-50-SAIDA. */

                R1000_50_SAIDA(); //GOTO
                return;
            }


            /*" -1514- MOVE V0PRFD-CODPROD TO WSHOST-CODPRODU. */
            _.Move(V0PRFD_CODPROD, WSHOST_CODPRODU);

            /*" -1517- MOVE V0BILH-NUMAPOL TO WNUMAPOL V1MVDB-NUM-APOLICE. */
            _.Move(V0BILH_NUMAPOL, AREA_DE_WORK.FILLER_27.WNUMAPOL);
            _.Move(V0BILH_NUMAPOL, V1MVDB_NUM_APOLICE);


            /*" -1518- MOVE ZEROS TO WVLPENDEN. */
            _.Move(0, AREA_DE_WORK.WVLPENDEN);

            /*" -1526- MOVE ZEROS TO V1MVDB-COD-EMPRESA. */
            _.Move(0, V1MVDB_COD_EMPRESA);

            /*" -1530- MOVE MOVIMCOB-DATA-QUITACAO TO WDATA-HOST. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, AREA_DE_WORK.WDATA_HOST);

            /*" -1531- MOVE WCONVENIO TO V1MVDB-COD-CONVENIO. */
            _.Move(AREA_DE_WORK.WCONVENIO, V1MVDB_COD_CONVENIO);

            /*" -1533- MOVE SPACES TO WFIM-V1MOVDEBCC. */
            _.Move("", AREA_DE_WORK.WFIM_V1MOVDEBCC);

            /*" -1535- PERFORM R3450-00-SELECT-V1MOVDEBCC. */

            R3450_00_SELECT_V1MOVDEBCC_SECTION();

            /*" -1542- MOVE SPACES TO V0FOLL-CDERRO01 V0FOLL-CDERRO02 V0FOLL-CDERRO03 V0FOLL-CDERRO04 V0FOLL-CDERRO05 V0FOLL-CDERRO06. */
            _.Move("", V0FOLL_CDERRO01, V0FOLL_CDERRO02, V0FOLL_CDERRO03, V0FOLL_CDERRO04, V0FOLL_CDERRO05, V0FOLL_CDERRO06);

            /*" -1543- IF WFIM-V1MOVDEBCC NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1MOVDEBCC.IsEmpty())
            {

                /*" -1545- MOVE 'DOCUMENTO INEXISTENTE P/DEBITO' TO LD01-MENSAGEM */
                _.Move("DOCUMENTO INEXISTENTE P/DEBITO", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                /*" -1546- MOVE '3' TO V1MVDB-SIT-COBRANCA */
                _.Move("3", V1MVDB_SIT_COBRANCA);

                /*" -1547- MOVE 99 TO V1MVDB-COD-RET-CEF */
                _.Move(99, V1MVDB_COD_RET_CEF);

                /*" -1548- MOVE ZEROS TO V1MVDB-VLR-CREDITO */
                _.Move(0, V1MVDB_VLR_CREDITO);

                /*" -1549- MOVE WDATA-HOST TO V0FOLL-DTQITBCO */
                _.Move(AREA_DE_WORK.WDATA_HOST, V0FOLL_DTQITBCO);

                /*" -1551- MOVE '1' TO V0FOLL-CDERRO01 */
                _.Move("1", V0FOLL_CDERRO01);

                /*" -1552- PERFORM R1200-00-IMPRIME-RELATORIO */

                R1200_00_IMPRIME_RELATORIO_SECTION();

                /*" -1556- GO TO R1000-50-SAIDA. */

                R1000_50_SAIDA(); //GOTO
                return;
            }


            /*" -1558- PERFORM R3460-00-UPDATE-V0MOVDEBCC. */

            R3460_00_UPDATE_V0MOVDEBCC_SECTION();

            /*" -1559- IF MOVCC-CODRETORNO NOT EQUAL ZEROS */

            if (MOVCC_REGISTRO.MOVCC_CODRETORNO != 00)
            {

                /*" -1560- MOVE SPACES TO WS-CHAVE */
                _.Move("", AREA_DE_WORK.WS_CHAVE);

                /*" -1563- PERFORM R1300-00-ACHA-MENSAGEM VARYING WS-IND FROM 1 BY 1 UNTIL WS-CHAVE NOT EQUAL SPACES */

                for (AREA_DE_WORK.WS_IND.Value = 1; !(!AREA_DE_WORK.WS_CHAVE.IsEmpty()); AREA_DE_WORK.WS_IND.Value += 1)
                {

                    R1300_00_ACHA_MENSAGEM_SECTION();
                }

                /*" -1564- MOVE SPACES TO LD01-FOLLOW */
                _.Move("", AREA_DE_WORK.LD01.LD01_FOLLOW);

                /*" -1565- PERFORM R1200-00-IMPRIME-RELATORIO */

                R1200_00_IMPRIME_RELATORIO_SECTION();

                /*" -1567- GO TO R1000-50-SAIDA. */

                R1000_50_SAIDA(); //GOTO
                return;
            }


            /*" -1568- IF MOVIMCOB-TIPO-MOVIMENTO EQUAL 'U' */

            if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO == "U")
            {

                /*" -1569- PERFORM R3462-00-UPDATE-BILHETE */

                R3462_00_UPDATE_BILHETE_SECTION();

                /*" -1571- END-IF. */
            }


            /*" -1572- IF MOVCC-VLRDEBITO NOT EQUAL V1MVDB-VLR-DEBITO */

            if (MOVCC_REGISTRO.MOVCC_VLRDEBITO != V1MVDB_VLR_DEBITO)
            {

                /*" -1573- MOVE V1MVDB-VLR-DEBITO TO WVLPENDEN */
                _.Move(V1MVDB_VLR_DEBITO, AREA_DE_WORK.WVLPENDEN);

                /*" -1575- MOVE 'DOCUMENTO BAIXADO COM DIFERENCA' TO LD01-MENSAGEM */
                _.Move("DOCUMENTO BAIXADO COM DIFERENCA", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                /*" -1576- MOVE SPACES TO LD01-FOLLOW */
                _.Move("", AREA_DE_WORK.LD01.LD01_FOLLOW);

                /*" -1578- PERFORM R1200-00-IMPRIME-RELATORIO. */

                R1200_00_IMPRIME_RELATORIO_SECTION();
            }


            /*" -1580- ADD 1 TO AC-QT-APROVADOS WSHOST-QTDE. */
            AREA_DE_WORK.AC_QT_APROVADOS.Value = AREA_DE_WORK.AC_QT_APROVADOS + 1;
            WSHOST_QTDE.Value = WSHOST_QTDE + 1;

            /*" -1580- ADD MOVCC-VLRDEBITO TO AC-VL-APROVADOS. */
            AREA_DE_WORK.AC_VL_APROVADOS.Value = AREA_DE_WORK.AC_VL_APROVADOS + MOVCC_REGISTRO.MOVCC_VLRDEBITO;

            /*" -0- FLUXCONTROL_PERFORM R1000_50_SAIDA */

            R1000_50_SAIDA();

        }

        [StopWatch]
        /*" R1000-50-SAIDA */
        private void R1000_50_SAIDA(bool isPerform = false)
        {
            /*" -1587- MOVE '1001' TO WNR-EXEC-SQL. */
            _.Move("1001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1591- PERFORM R1000_50_SAIDA_DB_UPDATE_1 */

            R1000_50_SAIDA_DB_UPDATE_1();

            /*" -1594- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1595- DISPLAY 'R1000-00 - PROBLEMAS UPDATE  (MOVIMCOB)   ' */
                _.Display($"R1000-00 - PROBLEMAS UPDATE  (MOVIMCOB)   ");

                /*" -1596- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1599- END-IF. */
            }


            /*" -1599- PERFORM R0310-00-FETCH-MOVIMCOB. */

            R0310_00_FETCH_MOVIMCOB_SECTION();

        }

        [StopWatch]
        /*" R1000-50-SAIDA-DB-UPDATE-1 */
        public void R1000_50_SAIDA_DB_UPDATE_1()
        {
            /*" -1591- EXEC SQL UPDATE SEGUROS.MOVIMENTO_COBRANCA SET SIT_REGISTRO = :MOVIMCOB-SIT-REGISTRO WHERE CURRENT OF V0MOVIMCOB END-EXEC. */

            var r1000_50_SAIDA_DB_UPDATE_1_Update1 = new R1000_50_SAIDA_DB_UPDATE_1_Update1(V0MOVIMCOB)
            {
                MOVIMCOB_SIT_REGISTRO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R1000_50_SAIDA_DB_UPDATE_1_Update1.Execute(r1000_50_SAIDA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-SELECT-CONVERSI-SECTION */
        private void R1050_00_SELECT_CONVERSI_SECTION()
        {
            /*" -1610- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1611- MOVE ZEROS TO WS-NRTIT. */
            _.Move(0, AREA_DE_WORK.WS_NRTIT);

            /*" -1613- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO WS-NRTIT. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, AREA_DE_WORK.WS_NRTIT);

            /*" -1614- MOVE ZEROS TO WS-DIGTIT. */
            _.Move(0, AREA_DE_WORK.FILLER_28.WS_DIGTIT);

            /*" -1616- MOVE WS-NRTIT TO WSHOST-NUMSIV01. */
            _.Move(AREA_DE_WORK.WS_NRTIT, WSHOST_NUMSIV01);

            /*" -1617- MOVE 9 TO WS-DIGTIT. */
            _.Move(9, AREA_DE_WORK.FILLER_28.WS_DIGTIT);

            /*" -1619- MOVE WS-NRTIT TO WSHOST-NUMSIV02. */
            _.Move(AREA_DE_WORK.WS_NRTIT, WSHOST_NUMSIV02);

            /*" -1621- MOVE 'S' TO WTEM-CONVERSI. */
            _.Move("S", AREA_DE_WORK.WTEM_CONVERSI);

            /*" -1634- PERFORM R1050_00_SELECT_CONVERSI_DB_SELECT_1 */

            R1050_00_SELECT_CONVERSI_DB_SELECT_1();

            /*" -1644- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1645- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1646- MOVE 'N' TO WTEM-CONVERSI */
                    _.Move("N", AREA_DE_WORK.WTEM_CONVERSI);

                    /*" -1647- ELSE */
                }
                else
                {


                    /*" -1648- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -1649- PERFORM R1060-00-SELECT-CONVERSI */

                        R1060_00_SELECT_CONVERSI_SECTION();

                        /*" -1650- ELSE */
                    }
                    else
                    {


                        /*" -1651- DISPLAY 'R1050-00 - PROBLEMAS ACESSO (PROPFID)' */
                        _.Display($"R1050-00 - PROBLEMAS ACESSO (PROPFID)");

                        /*" -1652- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1653- END-IF */
                    }


                    /*" -1654- END-IF */
                }


                /*" -1654- END-IF. */
            }


        }

        [StopWatch]
        /*" R1050-00-SELECT-CONVERSI-DB-SELECT-1 */
        public void R1050_00_SELECT_CONVERSI_DB_SELECT_1()
        {
            /*" -1634- EXEC SQL SELECT A.NUM_PROPOSTA_SIVPF , A.COD_PRODUTO_SIVPF , B.NUM_SICOB INTO :V0PRFD-NUMPROPOSTA , :V0PRFD-CODPROD , :V0PRFD-NUMSICOB FROM SEGUROS.CONVERSAO_SICOB A, SEGUROS.PROPOSTA_FIDELIZ B WHERE A.NUM_PROPOSTA_SIVPF >= :WSHOST-NUMSIV01 AND A.NUM_PROPOSTA_SIVPF <= :WSHOST-NUMSIV02 AND A.NUM_PROPOSTA_SIVPF = B.NUM_PROPOSTA_SIVPF WITH UR END-EXEC. */

            var r1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1 = new R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1()
            {
                WSHOST_NUMSIV01 = WSHOST_NUMSIV01.ToString(),
                WSHOST_NUMSIV02 = WSHOST_NUMSIV02.ToString(),
            };

            var executed_1 = R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1.Execute(r1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRFD_NUMPROPOSTA, V0PRFD_NUMPROPOSTA);
                _.Move(executed_1.V0PRFD_CODPROD, V0PRFD_CODPROD);
                _.Move(executed_1.V0PRFD_NUMSICOB, V0PRFD_NUMSICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1060-00-SELECT-CONVERSI-SECTION */
        private void R1060_00_SELECT_CONVERSI_SECTION()
        {
            /*" -1664- MOVE '1060' TO WNR-EXEC-SQL. */
            _.Move("1060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1684- PERFORM R1060_00_SELECT_CONVERSI_DB_SELECT_1 */

            R1060_00_SELECT_CONVERSI_DB_SELECT_1();

            /*" -1688- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -811 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -811)
            {

                /*" -1689- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1690- MOVE 'N' TO WTEM-CONVERSI */
                    _.Move("N", AREA_DE_WORK.WTEM_CONVERSI);

                    /*" -1691- ELSE */
                }
                else
                {


                    /*" -1692- DISPLAY 'R1050-00 - PROBLEMAS ACESSO (PROPFID)' */
                    _.Display($"R1050-00 - PROBLEMAS ACESSO (PROPFID)");

                    /*" -1693- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1694- END-IF */
                }


                /*" -1694- END-IF. */
            }


        }

        [StopWatch]
        /*" R1060-00-SELECT-CONVERSI-DB-SELECT-1 */
        public void R1060_00_SELECT_CONVERSI_DB_SELECT_1()
        {
            /*" -1684- EXEC SQL SELECT A.NUM_PROPOSTA_SIVPF , A.COD_PRODUTO_SIVPF , B.NUM_SICOB INTO :V0PRFD-NUMPROPOSTA , :V0PRFD-CODPROD , :V0PRFD-NUMSICOB FROM SEGUROS.CONVERSAO_SICOB A, SEGUROS.PROPOSTA_FIDELIZ B, SEGUROS.V0MOVDEBCC_CEF C, SEGUROS.BILHETE D WHERE A.NUM_PROPOSTA_SIVPF >= :WSHOST-NUMSIV01 AND A.NUM_PROPOSTA_SIVPF <= :WSHOST-NUMSIV02 AND A.NUM_PROPOSTA_SIVPF = B.NUM_PROPOSTA_SIVPF AND A.NUM_SICOB = D.NUM_BILHETE AND D.NUM_APOLICE = C.NUM_APOLICE AND C.SIT_COBRANCA = '1' ORDER BY NRENDOS FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r1060_00_SELECT_CONVERSI_DB_SELECT_1_Query1 = new R1060_00_SELECT_CONVERSI_DB_SELECT_1_Query1()
            {
                WSHOST_NUMSIV01 = WSHOST_NUMSIV01.ToString(),
                WSHOST_NUMSIV02 = WSHOST_NUMSIV02.ToString(),
            };

            var executed_1 = R1060_00_SELECT_CONVERSI_DB_SELECT_1_Query1.Execute(r1060_00_SELECT_CONVERSI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRFD_NUMPROPOSTA, V0PRFD_NUMPROPOSTA);
                _.Move(executed_1.V0PRFD_CODPROD, V0PRFD_CODPROD);
                _.Move(executed_1.V0PRFD_NUMSICOB, V0PRFD_NUMSICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_99_SAIDA*/

        [StopWatch]
        /*" R1160-00-SELECT-V1BILHETE-SECTION */
        private void R1160_00_SELECT_V1BILHETE_SECTION()
        {
            /*" -1706- MOVE '116' TO WNR-EXEC-SQL. */
            _.Move("116", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1739- PERFORM R1160_00_SELECT_V1BILHETE_DB_SELECT_1 */

            R1160_00_SELECT_V1BILHETE_DB_SELECT_1();

            /*" -1742- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1743- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1744- MOVE 'S' TO WFIM-V1BILHETE */
                    _.Move("S", AREA_DE_WORK.WFIM_V1BILHETE);

                    /*" -1745- ELSE */
                }
                else
                {


                    /*" -1746- DISPLAY 'BI0072B - PROBLEMAS SELECT V1BILHETE ' */
                    _.Display($"BI0072B - PROBLEMAS SELECT V1BILHETE ");

                    /*" -1747- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                    _.Display($"BILHETE {V0BILH_NUMBIL}");

                    /*" -1747- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1160-00-SELECT-V1BILHETE-DB-SELECT-1 */
        public void R1160_00_SELECT_V1BILHETE_DB_SELECT_1()
        {
            /*" -1739- EXEC SQL SELECT NUMBIL , NUM_APOLICE, CODCLIEN , AGECOBR , RAMO , OPC_COBERTURA, NUM_MATRICULA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB INTO :V0BILH-NUMBIL , :V0BILH-NUMAPOL , :V0BILH-CODCLIEN , :V0BILH-AGECOBR , :V0BILH-RAMO , :V0BILH-OPCAO-COB , :V0BILH-NRMATRVEN , :V0BILH-AGECTAVEN , :V0BILH-OPRCTAVEN , :V0BILH-NUMCTAVEN , :V0BILH-DIGCTAVEN , :V0BILH-AGECTADEB , :V0BILH-OPRCTADEB , :V0BILH-NUMCTADEB , :V0BILH-DIGCTADEB FROM SEGUROS.V0BILHETE WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1 = new R1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1.Execute(r1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BILH_NUMBIL, V0BILH_NUMBIL);
                _.Move(executed_1.V0BILH_NUMAPOL, V0BILH_NUMAPOL);
                _.Move(executed_1.V0BILH_CODCLIEN, V0BILH_CODCLIEN);
                _.Move(executed_1.V0BILH_AGECOBR, V0BILH_AGECOBR);
                _.Move(executed_1.V0BILH_RAMO, V0BILH_RAMO);
                _.Move(executed_1.V0BILH_OPCAO_COB, V0BILH_OPCAO_COB);
                _.Move(executed_1.V0BILH_NRMATRVEN, V0BILH_NRMATRVEN);
                _.Move(executed_1.V0BILH_AGECTAVEN, V0BILH_AGECTAVEN);
                _.Move(executed_1.V0BILH_OPRCTAVEN, V0BILH_OPRCTAVEN);
                _.Move(executed_1.V0BILH_NUMCTAVEN, V0BILH_NUMCTAVEN);
                _.Move(executed_1.V0BILH_DIGCTAVEN, V0BILH_DIGCTAVEN);
                _.Move(executed_1.V0BILH_AGECTADEB, V0BILH_AGECTADEB);
                _.Move(executed_1.V0BILH_OPRCTADEB, V0BILH_OPRCTADEB);
                _.Move(executed_1.V0BILH_NUMCTADEB, V0BILH_NUMCTADEB);
                _.Move(executed_1.V0BILH_DIGCTADEB, V0BILH_DIGCTADEB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1160_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-IMPRIME-RELATORIO-SECTION */
        private void R1200_00_IMPRIME_RELATORIO_SECTION()
        {
            /*" -1759- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1760- MOVE 'CREDITO' TO LD01-TIPO */
            _.Move("CREDITO", AREA_DE_WORK.LD01.LD01_TIPO);

            /*" -1761- MOVE WNUMAPOL TO LD01-NUM-APOL */
            _.Move(AREA_DE_WORK.FILLER_27.WNUMAPOL, AREA_DE_WORK.LD01.LD01_NUM_APOL);

            /*" -1762- MOVE ZEROS TO LD01-NRENDOS */
            _.Move(0, AREA_DE_WORK.LD01.LD01_NRENDOS);

            /*" -1764- MOVE WNRPARCEL TO LD01-NRPARCEL. */
            _.Move(AREA_DE_WORK.FILLER_24.WNRPARCEL, AREA_DE_WORK.LD01.LD01_NRPARCEL);

            /*" -1767- MOVE MOVCC-NSR TO LD01-NSR. */
            _.Move(MOVCC_REGISTRO.MOVCC_NSR, AREA_DE_WORK.LD01.LD01_NSR);

            /*" -1769- MOVE MOVIMCOB-DATA-QUITACAO TO WDATA-AMD. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, AREA_DE_WORK.WDATA_AMD);

            /*" -1770- MOVE WDATA-DD-AMD TO WDATA-DD-CABEC. */
            _.Move(AREA_DE_WORK.WDATA_AMD_R.WDATA_DD_AMD, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1771- MOVE WDATA-MM-AMD TO WDATA-MM-CABEC. */
            _.Move(AREA_DE_WORK.WDATA_AMD_R.WDATA_MM_AMD, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1772- MOVE WDATA-AA-AMD TO WDATA-AA-CABEC. */
            _.Move(AREA_DE_WORK.WDATA_AMD_R.WDATA_AA_AMD, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1773- MOVE WDATA-CABEC TO LD01-DTVENCTO. */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LD01.LD01_DTVENCTO);

            /*" -1774- MOVE MOVCC-VLRDEBITO TO LD01-VLDEBITO. */
            _.Move(MOVCC_REGISTRO.MOVCC_VLRDEBITO, AREA_DE_WORK.LD01.LD01_VLDEBITO);

            /*" -1776- MOVE WVLPENDEN TO LD01-VLPENDEN. */
            _.Move(AREA_DE_WORK.WVLPENDEN, AREA_DE_WORK.LD01.LD01_VLPENDEN);

            /*" -1777- IF AC-LINHAS GREATER 50 */

            if (AREA_DE_WORK.AC_LINHAS > 50)
            {

                /*" -1779- PERFORM R3000-00-CABECALHOS. */

                R3000_00_CABECALHOS_SECTION();
            }


            /*" -1780- ADD 1 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

            /*" -1782- WRITE REG-BI0072B FROM LD01 AFTER 1. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_BI0072B);

            RBI0072B.Write(REG_BI0072B.GetMoveValues().ToString());

            /*" -1783- IF WVLPENDEN EQUAL ZEROS */

            if (AREA_DE_WORK.WVLPENDEN == 00)
            {

                /*" -1784- ADD 1 TO AC-QT-REJEITADOS */
                AREA_DE_WORK.AC_QT_REJEITADOS.Value = AREA_DE_WORK.AC_QT_REJEITADOS + 1;

                /*" -1784- ADD MOVCC-VLRDEBITO TO AC-VL-REJEITADOS. */
                AREA_DE_WORK.AC_VL_REJEITADOS.Value = AREA_DE_WORK.AC_VL_REJEITADOS + MOVCC_REGISTRO.MOVCC_VLRDEBITO;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-ACHA-MENSAGEM-SECTION */
        private void R1300_00_ACHA_MENSAGEM_SECTION()
        {
            /*" -1796- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1797- IF WS-IND GREATER 7 */

            if (AREA_DE_WORK.WS_IND > 7)
            {

                /*" -1798- MOVE 'CODIGO DE RETORNO IMPREVISTO' TO LD01-MENSAGEM */
                _.Move("CODIGO DE RETORNO IMPREVISTO", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                /*" -1799- MOVE '*' TO WS-CHAVE */
                _.Move("*", AREA_DE_WORK.WS_CHAVE);

                /*" -1800- ELSE */
            }
            else
            {


                /*" -1801- IF MOVCC-CODRETORNO EQUAL TB-RETORNO (WS-IND) */

                if (MOVCC_REGISTRO.MOVCC_CODRETORNO == AREA_DE_WORK.TB_MENSAGENS_R.FILLER_8[AREA_DE_WORK.WS_IND].TB_RETORNO)
                {

                    /*" -1802- MOVE TB-MENSAGEM (WS-IND) TO LD01-MENSAGEM */
                    _.Move(AREA_DE_WORK.TB_MENSAGENS_R.FILLER_8[AREA_DE_WORK.WS_IND].TB_MENSAGEM, AREA_DE_WORK.LD01.LD01_MENSAGEM);

                    /*" -1802- MOVE '*' TO WS-CHAVE. */
                    _.Move("*", AREA_DE_WORK.WS_CHAVE);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1440-00-CANCELA-BILHETE-SECTION */
        private void R1440_00_CANCELA_BILHETE_SECTION()
        {
            /*" -1814- MOVE '144' TO WNR-EXEC-SQL. */
            _.Move("144", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1816- MOVE '8' TO V0BILH-SITUACAO. */
            _.Move("8", V0BILH_SITUACAO);

            /*" -1825- PERFORM R1440_00_CANCELA_BILHETE_DB_UPDATE_1 */

            R1440_00_CANCELA_BILHETE_DB_UPDATE_1();

            /*" -1828- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1828- ADD 1 TO AC-C-V0BILHETE. */
                AREA_DE_WORK.AC_C_V0BILHETE.Value = AREA_DE_WORK.AC_C_V0BILHETE + 1;
            }


        }

        [StopWatch]
        /*" R1440-00-CANCELA-BILHETE-DB-UPDATE-1 */
        public void R1440_00_CANCELA_BILHETE_DB_UPDATE_1()
        {
            /*" -1825- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO, TIP_CANCELAMENTO = '3' , DTCANCEL = :V1SIST-DTMOVABE, COD_USUARIO = 'BI0072B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1 = new R1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1()
            {
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1.Execute(r1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1440_99_SAIDA*/

        [StopWatch]
        /*" R1450-00-UPDATE-V0MOVDEBCC-SECTION */
        private void R1450_00_UPDATE_V0MOVDEBCC_SECTION()
        {
            /*" -1840- MOVE '145' TO WNR-EXEC-SQL. */
            _.Move("145", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1842- MOVE '6' TO V1MVDB-SIT-COBRANCA. */
            _.Move("6", V1MVDB_SIT_COBRANCA);

            /*" -1849- PERFORM R1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1 */

            R1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1();

            /*" -1852- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1852- ADD 1 TO AC-S-V0MOVDEBCC. */
                AREA_DE_WORK.AC_S_V0MOVDEBCC.Value = AREA_DE_WORK.AC_S_V0MOVDEBCC + 1;
            }


        }

        [StopWatch]
        /*" R1450-00-UPDATE-V0MOVDEBCC-DB-UPDATE-1 */
        public void R1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1()
        {
            /*" -1849- EXEC SQL UPDATE SEGUROS.V0MOVDEBCC_CEF SET SIT_COBRANCA = :V1MVDB-SIT-COBRANCA WHERE NUM_APOLICE = :V1MVDB-NUM-APOLICE AND NRENDOS > :V1MVDB-NRENDOS AND NRPARCEL = :V1MVDB-NRPARCEL AND COD_CONVENIO = :V1MVDB-COD-CONVENIO END-EXEC. */

            var r1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1 = new R1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1()
            {
                V1MVDB_SIT_COBRANCA = V1MVDB_SIT_COBRANCA.ToString(),
                V1MVDB_COD_CONVENIO = V1MVDB_COD_CONVENIO.ToString(),
                V1MVDB_NUM_APOLICE = V1MVDB_NUM_APOLICE.ToString(),
                V1MVDB_NRPARCEL = V1MVDB_NRPARCEL.ToString(),
                V1MVDB_NRENDOS = V1MVDB_NRENDOS.ToString(),
            };

            R1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1.Execute(r1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/

        [StopWatch]
        /*" R1460-00-CANCELA-ENDOSSO-SECTION */
        private void R1460_00_CANCELA_ENDOSSO_SECTION()
        {
            /*" -1863- MOVE '146' TO WNR-EXEC-SQL. */
            _.Move("146", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1869- PERFORM R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1 */

            R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1();

            /*" -1872- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1873- DISPLAY 'R1460 - ERRO NO UPDATE DA V0ENDOSSO' */
                _.Display($"R1460 - ERRO NO UPDATE DA V0ENDOSSO");

                /*" -1874- DISPLAY 'APOLICE - ' V1MVDB-NUM-APOLICE */
                _.Display($"APOLICE - {V1MVDB_NUM_APOLICE}");

                /*" -1875- DISPLAY 'ENDOSSO - ' V1MVDB-NRENDOS */
                _.Display($"ENDOSSO - {V1MVDB_NRENDOS}");

                /*" -1876- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1877- ELSE */
            }
            else
            {


                /*" -1877- ADD 1 TO AC-C-V0ENDOSSO. */
                AREA_DE_WORK.AC_C_V0ENDOSSO.Value = AREA_DE_WORK.AC_C_V0ENDOSSO + 1;
            }


        }

        [StopWatch]
        /*" R1460-00-CANCELA-ENDOSSO-DB-UPDATE-1 */
        public void R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1()
        {
            /*" -1869- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET SITUACAO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V1MVDB-NUM-APOLICE AND NRENDOS = :V1MVDB-NRENDOS END-EXEC. */

            var r1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1 = new R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1()
            {
                V1MVDB_NUM_APOLICE = V1MVDB_NUM_APOLICE.ToString(),
                V1MVDB_NRENDOS = V1MVDB_NRENDOS.ToString(),
            };

            R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1.Execute(r1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1460_99_SAIDA*/

        [StopWatch]
        /*" R1470-00-CANCELA-PARCELAS-SECTION */
        private void R1470_00_CANCELA_PARCELAS_SECTION()
        {
            /*" -1889- MOVE '1470' TO WNR-EXEC-SQL. */
            _.Move("1470", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1891- MOVE SPACES TO WFIM-PARCELA. */
            _.Move("", AREA_DE_WORK.WFIM_PARCELA);

            /*" -1892- PERFORM R1471-00-DECLARE-V0PARC. */

            R1471_00_DECLARE_V0PARC_SECTION();

            /*" -1893- PERFORM R1472-00-FETCH-V0PARC. */

            R1472_00_FETCH_V0PARC_SECTION();

            /*" -1894- IF WFIM-PARCELA EQUAL SPACES */

            if (AREA_DE_WORK.WFIM_PARCELA.IsEmpty())
            {

                /*" -1895- PERFORM R1477-00-SELECT-APOLICES */

                R1477_00_SELECT_APOLICES_SECTION();

                /*" -1896- PERFORM R1476-00-SELECT-NRENDOCA */

                R1476_00_SELECT_NRENDOCA_SECTION();

                /*" -1897- PERFORM R1478-00-UPDATE-NRENDOCA */

                R1478_00_UPDATE_NRENDOCA_SECTION();

                /*" -1898- END-IF */
            }


            /*" -1899- PERFORM R1473-00-PROCESSA-V0PARC UNTIL WFIM-PARCELA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_PARCELA.IsEmpty()))
            {

                R1473_00_PROCESSA_V0PARC_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1470_99_SAIDA*/

        [StopWatch]
        /*" R1471-00-DECLARE-V0PARC-SECTION */
        private void R1471_00_DECLARE_V0PARC_SECTION()
        {
            /*" -1912- MOVE '1471' TO WNR-EXEC-SQL. */
            _.Move("1471", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1914- MOVE SPACES TO WFIM-PARCELA. */
            _.Move("", AREA_DE_WORK.WFIM_PARCELA);

            /*" -1924- PERFORM R1471_00_DECLARE_V0PARC_DB_DECLARE_1 */

            R1471_00_DECLARE_V0PARC_DB_DECLARE_1();

            /*" -1926- PERFORM R1471_00_DECLARE_V0PARC_DB_OPEN_1 */

            R1471_00_DECLARE_V0PARC_DB_OPEN_1();

            /*" -1929- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1930- DISPLAY 'R1471-00 - PROBLEMAS DECLARE (V0PARC) ' */
                _.Display($"R1471-00 - PROBLEMAS DECLARE (V0PARC) ");

                /*" -1930- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1471-00-DECLARE-V0PARC-DB-OPEN-1 */
        public void R1471_00_DECLARE_V0PARC_DB_OPEN_1()
        {
            /*" -1926- EXEC SQL OPEN V0PARC END-EXEC. */

            V0PARC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1471_99_SAIDA*/

        [StopWatch]
        /*" R1472-00-FETCH-V0PARC-SECTION */
        private void R1472_00_FETCH_V0PARC_SECTION()
        {
            /*" -1943- MOVE '1472' TO WNR-EXEC-SQL. */
            _.Move("1472", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1945- PERFORM R1472_00_FETCH_V0PARC_DB_FETCH_1 */

            R1472_00_FETCH_V0PARC_DB_FETCH_1();

            /*" -1948- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1948- PERFORM R1472_00_FETCH_V0PARC_DB_CLOSE_1 */

                R1472_00_FETCH_V0PARC_DB_CLOSE_1();

                /*" -1950- MOVE 'S' TO WFIM-PARCELA */
                _.Move("S", AREA_DE_WORK.WFIM_PARCELA);

                /*" -1952- GO TO R1472-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1472_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1953- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1954- DISPLAY 'R1472-00 - PROBLEMAS FETCH (V0PARC)   ' */
                _.Display($"R1472-00 - PROBLEMAS FETCH (V0PARC)   ");

                /*" -1954- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1472-00-FETCH-V0PARC-DB-FETCH-1 */
        public void R1472_00_FETCH_V0PARC_DB_FETCH_1()
        {
            /*" -1945- EXEC SQL FETCH V0PARC INTO :V1MVDB-NRENDOS1 END-EXEC. */

            if (V0PARC.Fetch())
            {
                _.Move(V0PARC.V1MVDB_NRENDOS1, V1MVDB_NRENDOS1);
            }

        }

        [StopWatch]
        /*" R1472-00-FETCH-V0PARC-DB-CLOSE-1 */
        public void R1472_00_FETCH_V0PARC_DB_CLOSE_1()
        {
            /*" -1948- EXEC SQL CLOSE V0PARC END-EXEC */

            V0PARC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1472_99_SAIDA*/

        [StopWatch]
        /*" R1473-00-PROCESSA-V0PARC-SECTION */
        private void R1473_00_PROCESSA_V0PARC_SECTION()
        {
            /*" -1967- MOVE '1473' TO WNR-EXEC-SQL. */
            _.Move("1473", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1969- MOVE V1MVDB-NRENDOS1 TO V1MVDB-NRENDOS */
            _.Move(V1MVDB_NRENDOS1, V1MVDB_NRENDOS);

            /*" -1971- PERFORM R1460-00-CANCELA-ENDOSSO */

            R1460_00_CANCELA_ENDOSSO_SECTION();

            /*" -1973- PERFORM R1475-00-CANCELA-PARCHIS. */

            R1475_00_CANCELA_PARCHIS_SECTION();

            /*" -1975- PERFORM R1474-00-CANCELA-PARCELA. */

            R1474_00_CANCELA_PARCELA_SECTION();

            /*" -1975- PERFORM R1472-00-FETCH-V0PARC. */

            R1472_00_FETCH_V0PARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1473_99_SAIDA*/

        [StopWatch]
        /*" R1474-00-CANCELA-PARCELA-SECTION */
        private void R1474_00_CANCELA_PARCELA_SECTION()
        {
            /*" -1989- MOVE '1474' TO WNR-EXEC-SQL. */
            _.Move("1474", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1990- MOVE V1MVDB-NUM-APOLICE TO V0PARC-NUM-APOLICE. */
            _.Move(V1MVDB_NUM_APOLICE, V0PARC_NUM_APOLICE);

            /*" -1992- MOVE V1MVDB-NRENDOS1 TO V0PARC-NUM-ENDOSSO. */
            _.Move(V1MVDB_NRENDOS1, V0PARC_NUM_ENDOSSO);

            /*" -1994- MOVE ZEROS TO V0PARC-NUM-PARCELA. */
            _.Move(0, V0PARC_NUM_PARCELA);

            /*" -2007- PERFORM R1474_00_CANCELA_PARCELA_DB_UPDATE_1 */

            R1474_00_CANCELA_PARCELA_DB_UPDATE_1();

            /*" -2010- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2011- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2012- GO TO R1474-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1474_99_SAIDA*/ //GOTO
                    return;

                    /*" -2013- ELSE */
                }
                else
                {


                    /*" -2014- DISPLAY 'R1474 - ERRO NO UPDATE DA PARCELAS ' */
                    _.Display($"R1474 - ERRO NO UPDATE DA PARCELAS ");

                    /*" -2015- DISPLAY 'APOLICE  - ' V0PARC-NUM-APOLICE */
                    _.Display($"APOLICE  - {V0PARC_NUM_APOLICE}");

                    /*" -2016- DISPLAY 'ENDOSSO  - ' V0PARC-NUM-ENDOSSO */
                    _.Display($"ENDOSSO  - {V0PARC_NUM_ENDOSSO}");

                    /*" -2017- DISPLAY 'PARCELA  - ' V0PARC-NUM-PARCELA */
                    _.Display($"PARCELA  - {V0PARC_NUM_PARCELA}");

                    /*" -2018- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2019- ELSE */
                }

            }
            else
            {


                /*" -2019- ADD 1 TO AC-C-V0PARCELAS. */
                AREA_DE_WORK.AC_C_V0PARCELAS.Value = AREA_DE_WORK.AC_C_V0PARCELAS + 1;
            }


        }

        [StopWatch]
        /*" R1474-00-CANCELA-PARCELA-DB-UPDATE-1 */
        public void R1474_00_CANCELA_PARCELA_DB_UPDATE_1()
        {
            /*" -2007- EXEC SQL UPDATE SEGUROS.PARCELAS SET SIT_REGISTRO = '2' , TIMESTAMP = CURRENT TIMESTAMP, OCORR_HISTORICO = ( SELECT MAX(OCORR_HISTORICO) FROM SEGUROS.PARCELA_HISTORICO WHERE NUM_APOLICE = :V0PARC-NUM-APOLICE AND NUM_ENDOSSO = :V0PARC-NUM-ENDOSSO AND NUM_PARCELA = :V0PARC-NUM-PARCELA) WHERE NUM_APOLICE = :V0PARC-NUM-APOLICE AND NUM_ENDOSSO = :V0PARC-NUM-ENDOSSO AND NUM_PARCELA = :V0PARC-NUM-PARCELA END-EXEC. */

            var r1474_00_CANCELA_PARCELA_DB_UPDATE_1_Update1 = new R1474_00_CANCELA_PARCELA_DB_UPDATE_1_Update1()
            {
                V0PARC_NUM_APOLICE = V0PARC_NUM_APOLICE.ToString(),
                V0PARC_NUM_ENDOSSO = V0PARC_NUM_ENDOSSO.ToString(),
                V0PARC_NUM_PARCELA = V0PARC_NUM_PARCELA.ToString(),
            };

            R1474_00_CANCELA_PARCELA_DB_UPDATE_1_Update1.Execute(r1474_00_CANCELA_PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1474_99_SAIDA*/

        [StopWatch]
        /*" R1475-00-CANCELA-PARCHIS-SECTION */
        private void R1475_00_CANCELA_PARCHIS_SECTION()
        {
            /*" -2032- MOVE '1475' TO WNR-EXEC-SQL. */
            _.Move("1475", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2033- MOVE V1MVDB-NUM-APOLICE TO V0PCHS-NUM-APOLICE. */
            _.Move(V1MVDB_NUM_APOLICE, V0PCHS_NUM_APOLICE);

            /*" -2035- MOVE V1MVDB-NRENDOS1 TO V0PCHS-NUM-ENDOSSO. */
            _.Move(V1MVDB_NRENDOS1, V0PCHS_NUM_ENDOSSO);

            /*" -2037- MOVE ZEROS TO V0PCHS-NUM-PARCELA. */
            _.Move(0, V0PCHS_NUM_PARCELA);

            /*" -2076- PERFORM R1475_00_CANCELA_PARCHIS_DB_INSERT_1 */

            R1475_00_CANCELA_PARCHIS_DB_INSERT_1();

            /*" -2079- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2080- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2081- GO TO R1475-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1475_99_SAIDA*/ //GOTO
                    return;

                    /*" -2082- ELSE */
                }
                else
                {


                    /*" -2083- DISPLAY 'R1475 - ERRO NO INSERT PARCELA HISTORICO' */
                    _.Display($"R1475 - ERRO NO INSERT PARCELA HISTORICO");

                    /*" -2084- DISPLAY 'APOLICE  - ' V0PCHS-NUM-APOLICE */
                    _.Display($"APOLICE  - {V0PCHS_NUM_APOLICE}");

                    /*" -2085- DISPLAY 'ENDOSSO  - ' V0PCHS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO  - {V0PCHS_NUM_ENDOSSO}");

                    /*" -2086- DISPLAY 'PARCELA  - ' V0PCHS-NUM-PARCELA */
                    _.Display($"PARCELA  - {V0PCHS_NUM_PARCELA}");

                    /*" -2087- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2088- ELSE */
                }

            }
            else
            {


                /*" -2088- ADD 1 TO AC-C-V0PARCHIST. */
                AREA_DE_WORK.AC_C_V0PARCHIST.Value = AREA_DE_WORK.AC_C_V0PARCHIST + 1;
            }


        }

        [StopWatch]
        /*" R1475-00-CANCELA-PARCHIS-DB-INSERT-1 */
        public void R1475_00_CANCELA_PARCHIS_DB_INSERT_1()
        {
            /*" -2076- EXEC SQL INSERT INTO SEGUROS.PARCELA_HISTORICO SELECT NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DAC_PARCELA , :V1SIST-DTMOVABE , 401 COD_OPERACAO , HORA_OPERACAO , OCORR_HISTORICO + 1 , PRM_TARIFARIO , VAL_DESCONTO , PRM_LIQUIDO , ADICIONAL_FRACIO , VAL_CUSTO_EMISSAO , VAL_IOCC , PRM_TOTAL , VAL_OPERACAO , DATA_VENCIMENTO , BCO_COBRANCA , AGE_COBRANCA , NUM_AVISO_CREDITO , :NUMERAES-ENDOS-CANCELA ENDOS_CANCELA, SIT_CONTABIL , 'BI0072B' COD_USUARIO, RENUM_DOCUMENTO , DATA_QUITACAO , COD_EMPRESA , CURRENT TIMESTAMP FROM SEGUROS.PARCELA_HISTORICO T1 WHERE T1.NUM_APOLICE = :V0PCHS-NUM-APOLICE AND T1.NUM_ENDOSSO = :V0PCHS-NUM-ENDOSSO AND T1.NUM_PARCELA = :V0PCHS-NUM-PARCELA AND T1.OCORR_HISTORICO IN ( SELECT MAX(T10.OCORR_HISTORICO) FROM SEGUROS.PARCELA_HISTORICO T10 WHERE T1.NUM_APOLICE = T10.NUM_APOLICE AND T1.NUM_ENDOSSO = T10.NUM_ENDOSSO AND T1.NUM_PARCELA = T10.NUM_PARCELA) END-EXEC. */

            var r1475_00_CANCELA_PARCHIS_DB_INSERT_1_Insert1 = new R1475_00_CANCELA_PARCHIS_DB_INSERT_1_Insert1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                NUMERAES_ENDOS_CANCELA = NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA.ToString(),
                V0PCHS_NUM_APOLICE = V0PCHS_NUM_APOLICE.ToString(),
                V0PCHS_NUM_ENDOSSO = V0PCHS_NUM_ENDOSSO.ToString(),
                V0PCHS_NUM_PARCELA = V0PCHS_NUM_PARCELA.ToString(),
            };

            R1475_00_CANCELA_PARCHIS_DB_INSERT_1_Insert1.Execute(r1475_00_CANCELA_PARCHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1475_99_SAIDA*/

        [StopWatch]
        /*" R1476-00-SELECT-NRENDOCA-SECTION */
        private void R1476_00_SELECT_NRENDOCA_SECTION()
        {
            /*" -2100- MOVE '1476' TO WNR-EXEC-SQL. */
            _.Move("1476", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2101- MOVE APOLICES-RAMO-EMISSOR TO NUMERAES-RAMO-EMISSOR */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR);

            /*" -2103- MOVE APOLICES-ORGAO-EMISSOR TO NUMERAES-ORGAO-EMISSOR */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR, NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR);

            /*" -2109- PERFORM R1476_00_SELECT_NRENDOCA_DB_SELECT_1 */

            R1476_00_SELECT_NRENDOCA_DB_SELECT_1();

            /*" -2112- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2113- DISPLAY 'R1476-00 - PROBLEMAS SELECT NUMERO_AES) ' */
                _.Display($"R1476-00 - PROBLEMAS SELECT NUMERO_AES) ");

                /*" -2115- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2115- ADD 1 TO NUMERAES-ENDOS-CANCELA. */
            NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA.Value = NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA + 1;

        }

        [StopWatch]
        /*" R1476-00-SELECT-NRENDOCA-DB-SELECT-1 */
        public void R1476_00_SELECT_NRENDOCA_DB_SELECT_1()
        {
            /*" -2109- EXEC SQL SELECT ENDOS_CANCELA INTO :NUMERAES-ENDOS-CANCELA FROM SEGUROS.NUMERO_AES WHERE RAMO_EMISSOR = :NUMERAES-RAMO-EMISSOR AND ORGAO_EMISSOR = :NUMERAES-ORGAO-EMISSOR END-EXEC. */

            var r1476_00_SELECT_NRENDOCA_DB_SELECT_1_Query1 = new R1476_00_SELECT_NRENDOCA_DB_SELECT_1_Query1()
            {
                NUMERAES_ORGAO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR.ToString(),
                NUMERAES_RAMO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR.ToString(),
            };

            var executed_1 = R1476_00_SELECT_NRENDOCA_DB_SELECT_1_Query1.Execute(r1476_00_SELECT_NRENDOCA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUMERAES_ENDOS_CANCELA, NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1476_99_SAIDA*/

        [StopWatch]
        /*" R1477-00-SELECT-APOLICES-SECTION */
        private void R1477_00_SELECT_APOLICES_SECTION()
        {
            /*" -2127- MOVE '1477' TO WNR-EXEC-SQL. */
            _.Move("1477", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2129- MOVE V1MVDB-NUM-APOLICE TO APOLICES-NUM-APOLICE. */
            _.Move(V1MVDB_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -2138- PERFORM R1477_00_SELECT_APOLICES_DB_SELECT_1 */

            R1477_00_SELECT_APOLICES_DB_SELECT_1();

            /*" -2141- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2142- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2143- GO TO R1477-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1477_99_SAIDA*/ //GOTO
                    return;

                    /*" -2144- ELSE */
                }
                else
                {


                    /*" -2145- DISPLAY 'R1477 - ERRO NO SELECT DA APOLICES ' */
                    _.Display($"R1477 - ERRO NO SELECT DA APOLICES ");

                    /*" -2146- DISPLAY 'APOLICE  - ' V0PARC-NUM-APOLICE */
                    _.Display($"APOLICE  - {V0PARC_NUM_APOLICE}");

                    /*" -2147- DISPLAY 'ENDOSSO  - ' V0PARC-NUM-ENDOSSO */
                    _.Display($"ENDOSSO  - {V0PARC_NUM_ENDOSSO}");

                    /*" -2148- DISPLAY 'PARCELA  - ' V0PARC-NUM-PARCELA */
                    _.Display($"PARCELA  - {V0PARC_NUM_PARCELA}");

                    /*" -2149- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1477-00-SELECT-APOLICES-DB-SELECT-1 */
        public void R1477_00_SELECT_APOLICES_DB_SELECT_1()
        {
            /*" -2138- EXEC SQL SELECT NUM_APOLICE, ORGAO_EMISSOR, RAMO_EMISSOR INTO :APOLICES-NUM-APOLICE , :APOLICES-ORGAO-EMISSOR, :APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE END-EXEC. */

            var r1477_00_SELECT_APOLICES_DB_SELECT_1_Query1 = new R1477_00_SELECT_APOLICES_DB_SELECT_1_Query1()
            {
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1477_00_SELECT_APOLICES_DB_SELECT_1_Query1.Execute(r1477_00_SELECT_APOLICES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);
                _.Move(executed_1.APOLICES_ORGAO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR);
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1477_99_SAIDA*/

        [StopWatch]
        /*" R1478-00-UPDATE-NRENDOCA-SECTION */
        private void R1478_00_UPDATE_NRENDOCA_SECTION()
        {
            /*" -2159- MOVE '1478' TO WNR-EXEC-SQL. */
            _.Move("1478", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2164- PERFORM R1478_00_UPDATE_NRENDOCA_DB_UPDATE_1 */

            R1478_00_UPDATE_NRENDOCA_DB_UPDATE_1();

            /*" -2167- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2168- DISPLAY 'R1478-00 - PROBLEMAS UPDATE NUMERO_AES) ' */
                _.Display($"R1478-00 - PROBLEMAS UPDATE NUMERO_AES) ");

                /*" -2168- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1478-00-UPDATE-NRENDOCA-DB-UPDATE-1 */
        public void R1478_00_UPDATE_NRENDOCA_DB_UPDATE_1()
        {
            /*" -2164- EXEC SQL UPDATE SEGUROS.NUMERO_AES SET ENDOS_CANCELA = :NUMERAES-ENDOS-CANCELA WHERE RAMO_EMISSOR = :NUMERAES-RAMO-EMISSOR AND ORGAO_EMISSOR = :NUMERAES-ORGAO-EMISSOR END-EXEC. */

            var r1478_00_UPDATE_NRENDOCA_DB_UPDATE_1_Update1 = new R1478_00_UPDATE_NRENDOCA_DB_UPDATE_1_Update1()
            {
                NUMERAES_ENDOS_CANCELA = NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA.ToString(),
                NUMERAES_ORGAO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR.ToString(),
                NUMERAES_RAMO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR.ToString(),
            };

            R1478_00_UPDATE_NRENDOCA_DB_UPDATE_1_Update1.Execute(r1478_00_UPDATE_NRENDOCA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1478_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-FINAL-SECTION */
        private void R2000_00_PROCESSA_FINAL_SECTION()
        {
            /*" -2212- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2214- PERFORM R3010-00-TOTALIZADOR */

            R3010_00_TOTALIZADOR_SECTION();

            /*" -2216- COMPUTE AC-QT-TOTAL = AC-QT-APROVADOS + AC-QT-REJEITADOS. */
            AREA_DE_WORK.AC_QT_TOTAL.Value = AREA_DE_WORK.AC_QT_APROVADOS + AREA_DE_WORK.AC_QT_REJEITADOS;

            /*" -2217- COMPUTE AC-VL-TOTAL = AC-VL-APROVADOS + AC-VL-REJEITADOS. */
            AREA_DE_WORK.AC_VL_TOTAL.Value = AREA_DE_WORK.AC_VL_APROVADOS + AREA_DE_WORK.AC_VL_REJEITADOS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-CABECALHOS-SECTION */
        private void R3000_00_CABECALHOS_SECTION()
        {
            /*" -2240- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2241- ADD 1 TO AC-PAGINA */
            AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;

            /*" -2242- MOVE AC-PAGINA TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.LC01.LC01_PAGINA);

            /*" -2244- MOVE ZEROS TO AC-LINHAS */
            _.Move(0, AREA_DE_WORK.AC_LINHAS);

            /*" -2245- WRITE REG-BI0072B FROM LC01 AFTER PAGE */
            _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REG_BI0072B);

            RBI0072B.Write(REG_BI0072B.GetMoveValues().ToString());

            /*" -2246- WRITE REG-BI0072B FROM LC02 AFTER 1 */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REG_BI0072B);

            RBI0072B.Write(REG_BI0072B.GetMoveValues().ToString());

            /*" -2247- WRITE REG-BI0072B FROM LC03 AFTER 1 */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REG_BI0072B);

            RBI0072B.Write(REG_BI0072B.GetMoveValues().ToString());

            /*" -2248- WRITE REG-BI0072B FROM LC06 AFTER 1 */
            _.Move(AREA_DE_WORK.LC06.GetMoveValues(), REG_BI0072B);

            RBI0072B.Write(REG_BI0072B.GetMoveValues().ToString());

            /*" -2249- WRITE REG-BI0072B FROM LC04 AFTER 2 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_BI0072B);

            RBI0072B.Write(REG_BI0072B.GetMoveValues().ToString());

            /*" -2250- WRITE REG-BI0072B FROM LC05 AFTER 1 */
            _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REG_BI0072B);

            RBI0072B.Write(REG_BI0072B.GetMoveValues().ToString());

            /*" -2250- WRITE REG-BI0072B FROM LC04 AFTER 1. */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_BI0072B);

            RBI0072B.Write(REG_BI0072B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3010-00-TOTALIZADOR-SECTION */
        private void R3010_00_TOTALIZADOR_SECTION()
        {
            /*" -2262- MOVE '3010' TO WNR-EXEC-SQL. */
            _.Move("3010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2264- MOVE AC-VL-REJEITADOS TO LT01-VLDEBITO */
            _.Move(AREA_DE_WORK.AC_VL_REJEITADOS, AREA_DE_WORK.LT01.LT01_VLDEBITO);

            /*" -2264- WRITE REG-BI0072B FROM LT01 AFTER 2. */
            _.Move(AREA_DE_WORK.LT01.GetMoveValues(), REG_BI0072B);

            RBI0072B.Write(REG_BI0072B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-RELAT-SEM-MOVIMENTO-SECTION */
        private void R3100_00_RELAT_SEM_MOVIMENTO_SECTION()
        {
            /*" -2276- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2277- WRITE REG-BI0072B FROM LD02 AFTER 2 */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_BI0072B);

            RBI0072B.Write(REG_BI0072B.GetMoveValues().ToString());

            /*" -2278- WRITE REG-BI0072B FROM LD05 AFTER 1 */
            _.Move(AREA_DE_WORK.LD05.GetMoveValues(), REG_BI0072B);

            RBI0072B.Write(REG_BI0072B.GetMoveValues().ToString());

            /*" -2279- WRITE REG-BI0072B FROM LD03 AFTER 1 */
            _.Move(AREA_DE_WORK.LD03.GetMoveValues(), REG_BI0072B);

            RBI0072B.Write(REG_BI0072B.GetMoveValues().ToString());

            /*" -2280- WRITE REG-BI0072B FROM LD05 AFTER 1 */
            _.Move(AREA_DE_WORK.LD05.GetMoveValues(), REG_BI0072B);

            RBI0072B.Write(REG_BI0072B.GetMoveValues().ToString());

            /*" -2281- WRITE REG-BI0072B FROM LD04 AFTER 1 */
            _.Move(AREA_DE_WORK.LD04.GetMoveValues(), REG_BI0072B);

            RBI0072B.Write(REG_BI0072B.GetMoveValues().ToString());

            /*" -2282- WRITE REG-BI0072B FROM LD05 AFTER 1 */
            _.Move(AREA_DE_WORK.LD05.GetMoveValues(), REG_BI0072B);

            RBI0072B.Write(REG_BI0072B.GetMoveValues().ToString());

            /*" -2282- WRITE REG-BI0072B FROM LD02 AFTER 1. */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_BI0072B);

            RBI0072B.Write(REG_BI0072B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3450-00-SELECT-V1MOVDEBCC-SECTION */
        private void R3450_00_SELECT_V1MOVDEBCC_SECTION()
        {
            /*" -2295- MOVE '3450' TO WNR-EXEC-SQL. */
            _.Move("3450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2296- IF V1MVDB-NRENDOS NOT EQUAL ZEROS */

            if (V1MVDB_NRENDOS != 00)
            {

                /*" -2306- PERFORM R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1 */

                R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1();

                /*" -2308- ELSE */
            }
            else
            {


                /*" -2323- PERFORM R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_2 */

                R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_2();

                /*" -2326- END-IF. */
            }


            /*" -2327- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2328- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2329- MOVE 'S' TO WFIM-V1MOVDEBCC */
                    _.Move("S", AREA_DE_WORK.WFIM_V1MOVDEBCC);

                    /*" -2330- ELSE */
                }
                else
                {


                    /*" -2331- DISPLAY 'BI0072B - PROBLEMAS SELECT V1MOVDEBCC_CEF ' */
                    _.Display($"BI0072B - PROBLEMAS SELECT V1MOVDEBCC_CEF ");

                    /*" -2332- DISPLAY 'APOLICE ' V1MVDB-NUM-APOLICE */
                    _.Display($"APOLICE {V1MVDB_NUM_APOLICE}");

                    /*" -2332- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3450-00-SELECT-V1MOVDEBCC-DB-SELECT-1 */
        public void R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1()
        {
            /*" -2306- EXEC SQL SELECT VLR_DEBITO, DTVENCTO + 30 DAYS INTO :V1MVDB-VLR-DEBITO, :V1MVDB-DTCREDITO FROM SEGUROS.V1MOVDEBCC_CEF WHERE NUM_APOLICE = :V1MVDB-NUM-APOLICE AND NRENDOS = :V1MVDB-NRENDOS AND NRPARCEL = :V1MVDB-NRPARCEL AND COD_CONVENIO = :V1MVDB-COD-CONVENIO END-EXEC */

            var r3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1 = new R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1()
            {
                V1MVDB_COD_CONVENIO = V1MVDB_COD_CONVENIO.ToString(),
                V1MVDB_NUM_APOLICE = V1MVDB_NUM_APOLICE.ToString(),
                V1MVDB_NRPARCEL = V1MVDB_NRPARCEL.ToString(),
                V1MVDB_NRENDOS = V1MVDB_NRENDOS.ToString(),
            };

            var executed_1 = R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1.Execute(r3450_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MVDB_VLR_DEBITO, V1MVDB_VLR_DEBITO);
                _.Move(executed_1.V1MVDB_DTCREDITO, V1MVDB_DTCREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3450_99_SAIDA*/

        [StopWatch]
        /*" R3450-00-SELECT-V1MOVDEBCC-DB-SELECT-2 */
        public void R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_2()
        {
            /*" -2323- EXEC SQL SELECT VLR_DEBITO, DTVENCTO + 30 DAYS, NRENDOS INTO :V1MVDB-VLR-DEBITO, :V1MVDB-DTCREDITO, :V1MVDB-NRENDOS FROM SEGUROS.V1MOVDEBCC_CEF WHERE NUM_APOLICE = :V1MVDB-NUM-APOLICE AND NRPARCEL = :V1MVDB-NRPARCEL AND COD_CONVENIO = :V1MVDB-COD-CONVENIO AND SIT_COBRANCA = '1' AND DTVENCTO <= :V1SIST-DTMOVABE ORDER BY NRENDOS FETCH FIRST 1 ROW ONLY END-EXEC */

            var r3450_00_SELECT_V1MOVDEBCC_DB_SELECT_2_Query1 = new R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_2_Query1()
            {
                V1MVDB_COD_CONVENIO = V1MVDB_COD_CONVENIO.ToString(),
                V1MVDB_NUM_APOLICE = V1MVDB_NUM_APOLICE.ToString(),
                V1MVDB_NRPARCEL = V1MVDB_NRPARCEL.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            var executed_1 = R3450_00_SELECT_V1MOVDEBCC_DB_SELECT_2_Query1.Execute(r3450_00_SELECT_V1MOVDEBCC_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MVDB_VLR_DEBITO, V1MVDB_VLR_DEBITO);
                _.Move(executed_1.V1MVDB_DTCREDITO, V1MVDB_DTCREDITO);
                _.Move(executed_1.V1MVDB_NRENDOS, V1MVDB_NRENDOS);
            }


        }

        [StopWatch]
        /*" R3460-00-UPDATE-V0MOVDEBCC-SECTION */
        private void R3460_00_UPDATE_V0MOVDEBCC_SECTION()
        {
            /*" -2344- MOVE '3460' TO WNR-EXEC-SQL. */
            _.Move("3460", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2345- IF MOVCC-CODRETORNO EQUAL ZEROS */

            if (MOVCC_REGISTRO.MOVCC_CODRETORNO == 00)
            {

                /*" -2346- MOVE MOVCC-VLRDEBITO TO V1MVDB-VLR-CREDITO */
                _.Move(MOVCC_REGISTRO.MOVCC_VLRDEBITO, V1MVDB_VLR_CREDITO);

                /*" -2347- MOVE 'P' TO V1MVDB-SIT-COBRANCA */
                _.Move("P", V1MVDB_SIT_COBRANCA);

                /*" -2348- MOVE MOVCC-CODRETORNO TO V1MVDB-COD-RET-CEF */
                _.Move(MOVCC_REGISTRO.MOVCC_CODRETORNO, V1MVDB_COD_RET_CEF);

                /*" -2349- MOVE WSHOST-NUM-LOTE TO V1MVDB-NUM-LOTE */
                _.Move(WSHOST_NUM_LOTE, V1MVDB_NUM_LOTE);

                /*" -2351- MOVE +1 TO VIND-NUM-LOTE VIND-DTCREDITO */
                _.Move(+1, VIND_NUM_LOTE, VIND_DTCREDITO);

                /*" -2352- ELSE */
            }
            else
            {


                /*" -2353- MOVE '3' TO V1MVDB-SIT-COBRANCA */
                _.Move("3", V1MVDB_SIT_COBRANCA);

                /*" -2354- MOVE ZEROS TO V1MVDB-VLR-CREDITO */
                _.Move(0, V1MVDB_VLR_CREDITO);

                /*" -2355- MOVE MOVCC-CODRETORNO TO V1MVDB-COD-RET-CEF */
                _.Move(MOVCC_REGISTRO.MOVCC_CODRETORNO, V1MVDB_COD_RET_CEF);

                /*" -2356- MOVE ZEROS TO V1MVDB-NUM-LOTE */
                _.Move(0, V1MVDB_NUM_LOTE);

                /*" -2359- MOVE -1 TO VIND-NUM-LOTE VIND-DTCREDITO. */
                _.Move(-1, VIND_NUM_LOTE, VIND_DTCREDITO);
            }


            /*" -2360- MOVE V1SIST-DTMOVABE TO V1MVDB-DTMOVTO. */
            _.Move(V1SIST_DTMOVABE, V1MVDB_DTMOVTO);

            /*" -2362- MOVE WSSIST-DTMOVABE TO V1MVDB-DTRETORNO. */
            _.Move(AREA_DE_WORK.WSSIST_DTMOVABE, V1MVDB_DTRETORNO);

            /*" -2365- MOVE WCONVENIO TO V1MVDB-COD-CONVENIO. */
            _.Move(AREA_DE_WORK.WCONVENIO, V1MVDB_COD_CONVENIO);

            /*" -2380- PERFORM R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1 */

            R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1();

            /*" -2383- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2384- DISPLAY 'BI0072B - PROBLEMAS UPDATE V0MOVDEBCC_CEF' */
                _.Display($"BI0072B - PROBLEMAS UPDATE V0MOVDEBCC_CEF");

                /*" -2385- DISPLAY 'APOLICE ' V1MVDB-NUM-APOLICE */
                _.Display($"APOLICE {V1MVDB_NUM_APOLICE}");

                /*" -2386- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2387- ELSE */
            }
            else
            {


                /*" -2389- ADD 1 TO AC-U-V0MOVDEBCC. */
                AREA_DE_WORK.AC_U_V0MOVDEBCC.Value = AREA_DE_WORK.AC_U_V0MOVDEBCC + 1;
            }


            /*" -2391- MOVE 'N' TO WS-CANCBIL. */
            _.Move("N", AREA_DE_WORK.WS_CANCBIL);

            /*" -2392- IF MOVCC-CODRETORNO NOT EQUAL ZEROS */

            if (MOVCC_REGISTRO.MOVCC_CODRETORNO != 00)
            {

                /*" -2393- PERFORM R3465-00-SELECT-V1MOVDEBCC */

                R3465_00_SELECT_V1MOVDEBCC_SECTION();

                /*" -2398- IF WS-CANCBIL EQUAL 'S' OR MOVCC-CODRETORNO EQUAL 99 OR 02 OR 05 OR 06 */

                if (AREA_DE_WORK.WS_CANCBIL == "S" || MOVCC_REGISTRO.MOVCC_CODRETORNO.In("99", "02", "05", "06"))
                {

                    /*" -2399- PERFORM R1450-00-UPDATE-V0MOVDEBCC */

                    R1450_00_UPDATE_V0MOVDEBCC_SECTION();

                    /*" -2400- PERFORM R1440-00-CANCELA-BILHETE */

                    R1440_00_CANCELA_BILHETE_SECTION();

                    /*" -2402- MOVE ZEROS TO V1MVDB-NRENDOS V1MVDB-NRENDOS1 */
                    _.Move(0, V1MVDB_NRENDOS, V1MVDB_NRENDOS1);

                    /*" -2402- PERFORM R1470-00-CANCELA-PARCELAS. */

                    R1470_00_CANCELA_PARCELAS_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3460-00-UPDATE-V0MOVDEBCC-DB-UPDATE-1 */
        public void R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1()
        {
            /*" -2380- EXEC SQL UPDATE SEGUROS.V0MOVDEBCC_CEF SET COD_RETORNO_CEF = :V1MVDB-COD-RET-CEF, DTMOVTO = :V1MVDB-DTMOVTO , DTRETORNO = :V1MVDB-DTRETORNO , DTCREDITO = :V1MVDB-DTCREDITO:VIND-DTCREDITO, SIT_COBRANCA = :V1MVDB-SIT-COBRANCA, VLR_CREDITO = :V1MVDB-VLR-CREDITO , COD_USUARIO = 'BI0072B' , SEQUENCIA = :V1MVDB-SEQUENCIA:VIND-SEQUENCIA , NUM_LOTE = :V1MVDB-NUM-LOTE:VIND-NUM-LOTE WHERE NUM_APOLICE = :V1MVDB-NUM-APOLICE AND NRENDOS = :V1MVDB-NRENDOS AND NRPARCEL = :V1MVDB-NRPARCEL AND COD_CONVENIO = :V1MVDB-COD-CONVENIO END-EXEC. */

            var r3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1 = new R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1()
            {
                V1MVDB_DTCREDITO = V1MVDB_DTCREDITO.ToString(),
                VIND_DTCREDITO = VIND_DTCREDITO.ToString(),
                V1MVDB_SEQUENCIA = V1MVDB_SEQUENCIA.ToString(),
                VIND_SEQUENCIA = VIND_SEQUENCIA.ToString(),
                V1MVDB_NUM_LOTE = V1MVDB_NUM_LOTE.ToString(),
                VIND_NUM_LOTE = VIND_NUM_LOTE.ToString(),
                V1MVDB_SIT_COBRANCA = V1MVDB_SIT_COBRANCA.ToString(),
                V1MVDB_COD_RET_CEF = V1MVDB_COD_RET_CEF.ToString(),
                V1MVDB_VLR_CREDITO = V1MVDB_VLR_CREDITO.ToString(),
                V1MVDB_DTRETORNO = V1MVDB_DTRETORNO.ToString(),
                V1MVDB_DTMOVTO = V1MVDB_DTMOVTO.ToString(),
                V1MVDB_COD_CONVENIO = V1MVDB_COD_CONVENIO.ToString(),
                V1MVDB_NUM_APOLICE = V1MVDB_NUM_APOLICE.ToString(),
                V1MVDB_NRPARCEL = V1MVDB_NRPARCEL.ToString(),
                V1MVDB_NRENDOS = V1MVDB_NRENDOS.ToString(),
            };

            R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1.Execute(r3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3460_99_SAIDA*/

        [StopWatch]
        /*" R3462-00-UPDATE-BILHETE-SECTION */
        private void R3462_00_UPDATE_BILHETE_SECTION()
        {
            /*" -2419- MOVE '3462' TO WNR-EXEC-SQL. */
            _.Move("3462", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2425- PERFORM R3462_00_UPDATE_BILHETE_DB_UPDATE_1 */

            R3462_00_UPDATE_BILHETE_DB_UPDATE_1();

            /*" -2428- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2429- DISPLAY 'BI0072B - PROBLEMAS UPDATE BILHETE' */
                _.Display($"BI0072B - PROBLEMAS UPDATE BILHETE");

                /*" -2430- DISPLAY 'APOLICE ' V1MVDB-NUM-APOLICE */
                _.Display($"APOLICE {V1MVDB_NUM_APOLICE}");

                /*" -2431- DISPLAY 'BILHETE ' V0PRFD-NUMSICOB */
                _.Display($"BILHETE {V0PRFD_NUMSICOB}");

                /*" -2432- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2433- ELSE */
            }
            else
            {


                /*" -2434- ADD 1 TO AC-C-V0BILHETE */
                AREA_DE_WORK.AC_C_V0BILHETE.Value = AREA_DE_WORK.AC_C_V0BILHETE + 1;

                /*" -2434- ADD 1 TO AC-U-V0BILHETE. */
                AREA_DE_WORK.AC_U_V0BILHETE.Value = AREA_DE_WORK.AC_U_V0BILHETE + 1;
            }


        }

        [StopWatch]
        /*" R3462-00-UPDATE-BILHETE-DB-UPDATE-1 */
        public void R3462_00_UPDATE_BILHETE_DB_UPDATE_1()
        {
            /*" -2425- EXEC SQL UPDATE SEGUROS.BILHETE SET SITUACAO = '7' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_BILHETE = :V0PRFD-NUMSICOB AND SITUACAO <> '9' END-EXEC. */

            var r3462_00_UPDATE_BILHETE_DB_UPDATE_1_Update1 = new R3462_00_UPDATE_BILHETE_DB_UPDATE_1_Update1()
            {
                V0PRFD_NUMSICOB = V0PRFD_NUMSICOB.ToString(),
            };

            R3462_00_UPDATE_BILHETE_DB_UPDATE_1_Update1.Execute(r3462_00_UPDATE_BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3462_99_SAIDA*/

        [StopWatch]
        /*" R3465-00-SELECT-V1MOVDEBCC-SECTION */
        private void R3465_00_SELECT_V1MOVDEBCC_SECTION()
        {
            /*" -2446- MOVE '3465' TO WNR-EXEC-SQL. */
            _.Move("3465", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2447- MOVE 'N' TO WS-CANCBIL. */
            _.Move("N", AREA_DE_WORK.WS_CANCBIL);

            /*" -2449- MOVE ZEROS TO WS-QTDBIL. */
            _.Move(0, AREA_DE_WORK.WS_QTDBIL);

            /*" -2458- PERFORM R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1 */

            R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1();

            /*" -2461- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2462- DISPLAY 'BI0072B - PROBLEMAS SELECT V1MOVDEBCC_CEF ' */
                _.Display($"BI0072B - PROBLEMAS SELECT V1MOVDEBCC_CEF ");

                /*" -2463- DISPLAY 'APOLICE ' V1MVDB-NUM-APOLICE */
                _.Display($"APOLICE {V1MVDB_NUM_APOLICE}");

                /*" -2465- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2466- IF WS-QTDBIL GREATER 2 */

            if (AREA_DE_WORK.WS_QTDBIL > 2)
            {

                /*" -2466- MOVE 'S' TO WS-CANCBIL. */
                _.Move("S", AREA_DE_WORK.WS_CANCBIL);
            }


        }

        [StopWatch]
        /*" R3465-00-SELECT-V1MOVDEBCC-DB-SELECT-1 */
        public void R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1()
        {
            /*" -2458- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :WS-QTDBIL FROM SEGUROS.V1MOVDEBCC_CEF WHERE NUM_APOLICE = :V1MVDB-NUM-APOLICE AND NRENDOS <= :V1MVDB-NRENDOS AND COD_CONVENIO = :V1MVDB-COD-CONVENIO AND SIT_COBRANCA = '3' WITH UR END-EXEC. */

            var r3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1 = new R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1()
            {
                V1MVDB_COD_CONVENIO = V1MVDB_COD_CONVENIO.ToString(),
                V1MVDB_NUM_APOLICE = V1MVDB_NUM_APOLICE.ToString(),
                V1MVDB_NRENDOS = V1MVDB_NRENDOS.ToString(),
            };

            var executed_1 = R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1.Execute(r3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QTDBIL, AREA_DE_WORK.WS_QTDBIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3465_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-INSERT-V0FOLLOWUP-SECTION */
        private void R4000_00_INSERT_V0FOLLOWUP_SECTION()
        {
            /*" -2478- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2479- IF MOVCC-CODRETORNO NOT EQUAL ZEROS */

            if (MOVCC_REGISTRO.MOVCC_CODRETORNO != 00)
            {

                /*" -2480- MOVE ZEROS TO V1MVDB-NUM-LOTE */
                _.Move(0, V1MVDB_NUM_LOTE);

                /*" -2481- MOVE -1 TO VIND-NUM-LOTE */
                _.Move(-1, VIND_NUM_LOTE);

                /*" -2482- MOVE SPACES TO LD01-FOLLOW */
                _.Move("", AREA_DE_WORK.LD01.LD01_FOLLOW);

                /*" -2484- GO TO R4000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2486- ADD 1 TO WSHOST-QTDE. */
            WSHOST_QTDE.Value = WSHOST_QTDE + 1;

            /*" -2488- MOVE '1' TO WSHOST-SITUACAO. */
            _.Move("1", WSHOST_SITUACAO);

            /*" -2491- MOVE 'U' TO MOVIMCOB-SIT-REGISTRO */
            _.Move("U", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

            /*" -2492- MOVE 'FOLLOWUP' TO LD01-FOLLOW. */
            _.Move("FOLLOWUP", AREA_DE_WORK.LD01.LD01_FOLLOW);

            /*" -2493- MOVE +1 TO VIND-NUM-LOTE. */
            _.Move(+1, VIND_NUM_LOTE);

            /*" -2494- IF WNUMAPOL EQUAL ZEROS */

            if (AREA_DE_WORK.FILLER_27.WNUMAPOL == 00)
            {

                /*" -2495- MOVE WNUMBIL TO V0FOLL-NUMAPOL */
                _.Move(AREA_DE_WORK.FILLER_22.WNUMBIL, V0FOLL_NUMAPOL);

                /*" -2496- ELSE */
            }
            else
            {


                /*" -2497- MOVE WNUMAPOL TO V0FOLL-NUMAPOL */
                _.Move(AREA_DE_WORK.FILLER_27.WNUMAPOL, V0FOLL_NUMAPOL);

                /*" -2500- END-IF. */
            }


            /*" -2501- MOVE ZEROS TO V0FOLL-NRENDOS */
            _.Move(0, V0FOLL_NRENDOS);

            /*" -2502- MOVE WNRPARCEL TO V0FOLL-NRPARCEL */
            _.Move(AREA_DE_WORK.FILLER_24.WNRPARCEL, V0FOLL_NRPARCEL);

            /*" -2503- MOVE SPACES TO V0FOLL-DACPARC */
            _.Move("", V0FOLL_DACPARC);

            /*" -2504- MOVE V1SIST-DTMOVABE TO V0FOLL-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0FOLL_DTMOVTO);

            /*" -2505- MOVE MOVCC-VLRDEBITO TO V0FOLL-VLPREMIO */
            _.Move(MOVCC_REGISTRO.MOVCC_VLRDEBITO, V0FOLL_VLPREMIO);

            /*" -2506- MOVE 104 TO V0FOLL-BCOAVISO */
            _.Move(104, V0FOLL_BCOAVISO);

            /*" -2507- MOVE 9777 TO V0FOLL-AGEAVISO */
            _.Move(9777, V0FOLL_AGEAVISO);

            /*" -2508- MOVE WNRAVISO TO V0FOLL-NRAVISO */
            _.Move(AREA_DE_WORK.WNRAVISO, V0FOLL_NRAVISO);

            /*" -2509- MOVE 30 TO V0FOLL-CODBAIXA */
            _.Move(30, V0FOLL_CODBAIXA);

            /*" -2511- MOVE '0' TO V0FOLL-SITUACAO V0FOLL-SITCONTB */
            _.Move("0", V0FOLL_SITUACAO, V0FOLL_SITCONTB);

            /*" -2512- MOVE 103 TO V0FOLL-OPERACAO */
            _.Move(103, V0FOLL_OPERACAO);

            /*" -2513- MOVE SPACES TO V0FOLL-DTLIBER */
            _.Move("", V0FOLL_DTLIBER);

            /*" -2514- MOVE ZEROS TO V0FOLL-CODEMP */
            _.Move(0, V0FOLL_CODEMP);

            /*" -2515- MOVE '1' TO V0FOLL-TIPSGU */
            _.Move("1", V0FOLL_TIPSGU);

            /*" -2517- MOVE ZEROS TO V0FOLL-ORDLIDER V0FOLL-CODLIDER */
            _.Move(0, V0FOLL_ORDLIDER, V0FOLL_CODLIDER);

            /*" -2519- MOVE ZEROS TO V0FOLL-FONTE V0FOLL-NRRCAP */
            _.Move(0, V0FOLL_FONTE, V0FOLL_NRRCAP);

            /*" -2522- MOVE SPACES TO V0FOLL-APOLIDER V0FOLL-ENDOSLID. */
            _.Move("", V0FOLL_APOLIDER, V0FOLL_ENDOSLID);

            /*" -2523- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -2524- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.FILLER_34.WTIME_DAYR.WTIME_HORA);

            /*" -2525- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", AREA_DE_WORK.FILLER_34.WTIME_DAYR.WTIME_2PT1);

            /*" -2526- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.FILLER_34.WTIME_DAYR.WTIME_MINU);

            /*" -2527- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", AREA_DE_WORK.FILLER_34.WTIME_DAYR.WTIME_2PT2);

            /*" -2528- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.FILLER_34.WTIME_DAYR.WTIME_SEGU);

            /*" -2531- MOVE WTIME-DAYR TO V0FOLL-HORAOPER. */
            _.Move(AREA_DE_WORK.FILLER_34.WTIME_DAYR, V0FOLL_HORAOPER);

            /*" -2533- MOVE ZEROS TO VIND-CODEMP VIND-TIPSGU */
            _.Move(0, VIND_CODEMP, VIND_TIPSGU);

            /*" -2539- MOVE -1 TO VIND-DTLIBER VIND-ORDLIDER VIND-APOLIDER VIND-ENDOSLID VIND-CODLIDER. */
            _.Move(-1, VIND_DTLIBER, VIND_ORDLIDER, VIND_APOLIDER, VIND_ENDOSLID, VIND_CODLIDER);

            /*" -2540- IF V0FOLL-DTQITBCO NOT EQUAL SPACES */

            if (!V0FOLL_DTQITBCO.IsEmpty())
            {

                /*" -2541- MOVE ZEROS TO VIND-DTQITBC */
                _.Move(0, VIND_DTQITBC);

                /*" -2542- ELSE */
            }
            else
            {


                /*" -2544- MOVE -1 TO VIND-DTQITBC. */
                _.Move(-1, VIND_DTQITBC);
            }


            /*" -2545- IF V0FOLL-FONTE NOT EQUAL ZEROS */

            if (V0FOLL_FONTE != 00)
            {

                /*" -2546- MOVE ZEROS TO VIND-FONTE */
                _.Move(0, VIND_FONTE);

                /*" -2547- ELSE */
            }
            else
            {


                /*" -2549- MOVE -1 TO VIND-FONTE. */
                _.Move(-1, VIND_FONTE);
            }


            /*" -2550- IF V0FOLL-NRRCAP NOT EQUAL ZEROS */

            if (V0FOLL_NRRCAP != 00)
            {

                /*" -2551- MOVE ZEROS TO VIND-NRRCAP */
                _.Move(0, VIND_NRRCAP);

                /*" -2552- ELSE */
            }
            else
            {


                /*" -2554- MOVE -1 TO VIND-NRRCAP. */
                _.Move(-1, VIND_NRRCAP);
            }


            /*" -2588- PERFORM R4000_00_INSERT_V0FOLLOWUP_DB_INSERT_1 */

            R4000_00_INSERT_V0FOLLOWUP_DB_INSERT_1();

            /*" -2591- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -2592- DISPLAY 'R4000-00 - PROBLEMAS INSERT (V0FOLLOWUP) ' */
                _.Display($"R4000-00 - PROBLEMAS INSERT (V0FOLLOWUP) ");

                /*" -2593- DISPLAY 'APOLICE  ' V0FOLL-NUMAPOL */
                _.Display($"APOLICE  {V0FOLL_NUMAPOL}");

                /*" -2594- DISPLAY 'DTMOVTO  ' V0FOLL-DTMOVTO */
                _.Display($"DTMOVTO  {V0FOLL_DTMOVTO}");

                /*" -2595- DISPLAY 'OPERACAO ' V0FOLL-OPERACAO */
                _.Display($"OPERACAO {V0FOLL_OPERACAO}");

                /*" -2596- DISPLAY 'HORAOPER ' V0FOLL-HORAOPER */
                _.Display($"HORAOPER {V0FOLL_HORAOPER}");

                /*" -2597- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2598- ELSE */
            }
            else
            {


                /*" -2599- ADD 1 TO AC-I-V0FOLLOWUP */
                AREA_DE_WORK.AC_I_V0FOLLOWUP.Value = AREA_DE_WORK.AC_I_V0FOLLOWUP + 1;

                /*" -2599- ADD MOVCC-VLRDEBITO TO AC-VL-FOLLOW. */
                AREA_DE_WORK.AC_VL_FOLLOW.Value = AREA_DE_WORK.AC_VL_FOLLOW + MOVCC_REGISTRO.MOVCC_VLRDEBITO;
            }


        }

        [StopWatch]
        /*" R4000-00-INSERT-V0FOLLOWUP-DB-INSERT-1 */
        public void R4000_00_INSERT_V0FOLLOWUP_DB_INSERT_1()
        {
            /*" -2588- EXEC SQL INSERT INTO SEGUROS.V0FOLLOWUP VALUES (:V0FOLL-NUMAPOL , :V0FOLL-NRENDOS , :V0FOLL-NRPARCEL , :V0FOLL-DACPARC , :V0FOLL-DTMOVTO , :V0FOLL-HORAOPER , :V0FOLL-VLPREMIO , :V0FOLL-BCOAVISO , :V0FOLL-AGEAVISO , :V0FOLL-NRAVISO , :V0FOLL-CODBAIXA , :V0FOLL-CDERRO01 , :V0FOLL-CDERRO02 , :V0FOLL-CDERRO03 , :V0FOLL-CDERRO04 , :V0FOLL-CDERRO05 , :V0FOLL-CDERRO06 , :V0FOLL-SITUACAO , :V0FOLL-SITCONTB , :V0FOLL-OPERACAO , :V0FOLL-DTLIBER:VIND-DTLIBER , :V0FOLL-DTQITBCO:VIND-DTQITBC , :V0FOLL-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP , :V0FOLL-ORDLIDER:VIND-ORDLIDER , :V0FOLL-TIPSGU:VIND-TIPSGU , :V0FOLL-APOLIDER:VIND-APOLIDER , :V0FOLL-ENDOSLID:VIND-ENDOSLID , :V0FOLL-CODLIDER:VIND-CODLIDER , :V0FOLL-FONTE:VIND-FONTE , :V0FOLL-NRRCAP:VIND-NRRCAP , 0) END-EXEC. */

            var r4000_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1 = new R4000_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1()
            {
                V0FOLL_NUMAPOL = V0FOLL_NUMAPOL.ToString(),
                V0FOLL_NRENDOS = V0FOLL_NRENDOS.ToString(),
                V0FOLL_NRPARCEL = V0FOLL_NRPARCEL.ToString(),
                V0FOLL_DACPARC = V0FOLL_DACPARC.ToString(),
                V0FOLL_DTMOVTO = V0FOLL_DTMOVTO.ToString(),
                V0FOLL_HORAOPER = V0FOLL_HORAOPER.ToString(),
                V0FOLL_VLPREMIO = V0FOLL_VLPREMIO.ToString(),
                V0FOLL_BCOAVISO = V0FOLL_BCOAVISO.ToString(),
                V0FOLL_AGEAVISO = V0FOLL_AGEAVISO.ToString(),
                V0FOLL_NRAVISO = V0FOLL_NRAVISO.ToString(),
                V0FOLL_CODBAIXA = V0FOLL_CODBAIXA.ToString(),
                V0FOLL_CDERRO01 = V0FOLL_CDERRO01.ToString(),
                V0FOLL_CDERRO02 = V0FOLL_CDERRO02.ToString(),
                V0FOLL_CDERRO03 = V0FOLL_CDERRO03.ToString(),
                V0FOLL_CDERRO04 = V0FOLL_CDERRO04.ToString(),
                V0FOLL_CDERRO05 = V0FOLL_CDERRO05.ToString(),
                V0FOLL_CDERRO06 = V0FOLL_CDERRO06.ToString(),
                V0FOLL_SITUACAO = V0FOLL_SITUACAO.ToString(),
                V0FOLL_SITCONTB = V0FOLL_SITCONTB.ToString(),
                V0FOLL_OPERACAO = V0FOLL_OPERACAO.ToString(),
                V0FOLL_DTLIBER = V0FOLL_DTLIBER.ToString(),
                VIND_DTLIBER = VIND_DTLIBER.ToString(),
                V0FOLL_DTQITBCO = V0FOLL_DTQITBCO.ToString(),
                VIND_DTQITBC = VIND_DTQITBC.ToString(),
                V0FOLL_CODEMP = V0FOLL_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                V0FOLL_ORDLIDER = V0FOLL_ORDLIDER.ToString(),
                VIND_ORDLIDER = VIND_ORDLIDER.ToString(),
                V0FOLL_TIPSGU = V0FOLL_TIPSGU.ToString(),
                VIND_TIPSGU = VIND_TIPSGU.ToString(),
                V0FOLL_APOLIDER = V0FOLL_APOLIDER.ToString(),
                VIND_APOLIDER = VIND_APOLIDER.ToString(),
                V0FOLL_ENDOSLID = V0FOLL_ENDOSLID.ToString(),
                VIND_ENDOSLID = VIND_ENDOSLID.ToString(),
                V0FOLL_CODLIDER = V0FOLL_CODLIDER.ToString(),
                VIND_CODLIDER = VIND_CODLIDER.ToString(),
                V0FOLL_FONTE = V0FOLL_FONTE.ToString(),
                VIND_FONTE = VIND_FONTE.ToString(),
                V0FOLL_NRRCAP = V0FOLL_NRRCAP.ToString(),
                VIND_NRRCAP = VIND_NRRCAP.ToString(),
            };

            R4000_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1.Execute(r4000_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2610- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -2613- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -2615- CLOSE RBI0072B */
            RBI0072B.Close();

            /*" -2615- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -2617- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2622- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2622- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}