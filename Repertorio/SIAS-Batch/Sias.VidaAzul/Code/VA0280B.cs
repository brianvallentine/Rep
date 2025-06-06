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
using Sias.VidaAzul.DB2.VA0280B;

namespace Code
{
    public class VA0280B
    {
        public bool IsCall { get; set; }

        public VA0280B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  EMISSAO                            *      */
        /*"      *   PROGRAMA ...............  VA0280B                                   */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  EDIVALDO GOMES (FAST COMPUTER)     *      */
        /*"      *   PROGRAMADOR ............  EDIVALDO GOMES (FAST COMPUTER)     *      */
        /*"      *   DATA CODIFICACAO .......  SETEMBRO/2011                      *      */
        /*"      *   CADMUS .................  58.433                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  - TRATA MOVIMENTO DE RETORNO DA    *      */
        /*"      *                             SOER E ATUALIZA INFORMACOES NA     *      */
        /*"      *                             BASE DE DADOS SIAS.                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/02/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02- CAD  74.140                                      *       */
        /*"      *                                                                *      */
        /*"      *             - AJUSTE NO TAMANHO DA TABELA INTERNA DE PRODUTOS  *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/09/2012 - CLAUDIO FREITAS (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - CAD  62.998                                      *      */
        /*"      *               - AJUSTE PARA ATUALIZACAO DE DADOS DE CONTA E    *      */
        /*"      *                 CADASTRAIS.                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/10/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 00 - CAD  58.433                                      *      */
        /*"      *               - TRATA MOVIMENTO RETORNO DA SOER E ATUALIZA     *      */
        /*"      *                 INFORMACOES NA BASE DE DADOS DO SIASM.         *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/09/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.00         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _MOVIMENTO { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis MOVIMENTO
        {
            get
            {
                _.Move(MOV_REGISTRO, _MOVIMENTO); VarBasis.RedefinePassValue(MOV_REGISTRO, _MOVIMENTO, MOV_REGISTRO); return _MOVIMENTO;
            }
        }
        public FileBasis _RVA0280B { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis RVA0280B
        {
            get
            {
                _.Move(REG_VA0280B, _RVA0280B); VarBasis.RedefinePassValue(REG_VA0280B, _RVA0280B, REG_VA0280B); return _RVA0280B;
            }
        }
        /*"01        MOV-REGISTRO.*/
        public VA0280B_MOV_REGISTRO MOV_REGISTRO { get; set; } = new VA0280B_MOV_REGISTRO();
        public class VA0280B_MOV_REGISTRO : VarBasis
        {
            /*"  05      TIPO-REG           PIC  X(001).*/
            public StringBasis TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      FILLER             PIC  X(099).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "99", "X(099)."), @"");
            /*"01              REG-VA0280B        PIC  X(100).*/
        }
        public StringBasis REG_VA0280B { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_PRD { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_TIP { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_SIT { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77    VIND-NUM-CARTAO           PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NUM_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77    WSHOST-NUM-PROPOSTA       PIC  S9(015)V COMP-3.*/
        public DoubleBasis WSHOST_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V"), 0);
        /*"77    WSHOST-PARAM              PIC  X(057).*/
        public StringBasis WSHOST_PARAM { get; set; } = new StringBasis(new PIC("X", "57", "X(057)."), @"");
        /*"77    WSHOST-DT-NASC            PIC  X(008).*/
        public StringBasis WSHOST_DT_NASC { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77    WSHOST-CEP                PIC S9(009).*/
        public IntBasis WSHOST_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)."));
        /*"77    WSHOST-AGENCIA            PIC S9(004).*/
        public IntBasis WSHOST_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
        /*"77    WSHOST-OPERACAO           PIC S9(004).*/
        public IntBasis WSHOST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
        /*"77    WSHOST-CONTA              PIC S9(013)V COMP-3.*/
        public DoubleBasis WSHOST_CONTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V"), 0);
        /*"77    WSHOST-DV                 PIC S9(004).*/
        public IntBasis WSHOST_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
        /*"77    WSHOST-EXISTE-CONTA       PIC  X(001).*/
        public StringBasis WSHOST_EXISTE_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    WSHOST-CBO                PIC  9(009).*/
        public IntBasis WSHOST_CBO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"77    WSHOST-DIA-DEB            PIC S9(004).*/
        public IntBasis WSHOST_DIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
        /*"77    WSHOST-BANCO              PIC S9(004).*/
        public IntBasis WSHOST_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
        /*"77    WSHOST-NUM-CARTAO         PIC S9(016)V COMP-3.*/
        public DoubleBasis WSHOST_NUM_CARTAO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(016)V"), 0);
        /*"77    WSHOST-DDD-RES            PIC S9(004).*/
        public IntBasis WSHOST_DDD_RES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
        /*"77    WSHOST-TEL-RES            PIC S9(009).*/
        public IntBasis WSHOST_TEL_RES { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)."));
        /*"77    WSHOST-NUM-LOTE           PIC S9(09)    COMP.*/
        public IntBasis WSHOST_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTMOVABE-1   PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"01        MOV-HEADER.*/
        public VA0280B_MOV_HEADER MOV_HEADER { get; set; } = new VA0280B_MOV_HEADER();
        public class VA0280B_MOV_HEADER : VarBasis
        {
            /*"  05      HD-TIPO-REG           PIC  X(001).*/
            public StringBasis HD_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HD-NOME               PIC  X(008).*/
            public StringBasis HD_NOME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05      HD-DATA-GERACAO       PIC  9(008).*/
            public IntBasis HD_DATA_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      HD-SIST-ORIGEM        PIC  9(001).*/
            public IntBasis HD_SIST_ORIGEM { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      HD-SIST-DESTINO       PIC  9(001).*/
            public IntBasis HD_SIST_DESTINO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      HD-NSAS               PIC  9(006).*/
            public IntBasis HD_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      FILLER                PIC  X(075).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)."), @"");
            /*"01        MOV-REGISTRO-DT.*/
        }
        public VA0280B_MOV_REGISTRO_DT MOV_REGISTRO_DT { get; set; } = new VA0280B_MOV_REGISTRO_DT();
        public class VA0280B_MOV_REGISTRO_DT : VarBasis
        {
            /*"  05      DT-TIPO-REG           PIC  X(001).*/
            public StringBasis DT_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      DT-NUM-PROPOSTA       PIC  9(014).*/
            public IntBasis DT_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  05      FILLER                PIC  X(003).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05      FILLER                PIC  X(003).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05      DT-COD-ATRIBUTO       PIC  9(004).*/
            public IntBasis DT_COD_ATRIBUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      DT-DATA-SITUACAO      PIC  9(008).*/
            public IntBasis DT_DATA_SITUACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      DT-VAL-ATRIBUTO       PIC  X(057).*/
            public StringBasis DT_VAL_ATRIBUTO { get; set; } = new StringBasis(new PIC("X", "57", "X(057)."), @"");
            /*"  05      DT-COD-RETORNO        PIC  9(004).*/
            public IntBasis DT_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      DT-NSR                PIC  9(006).*/
            public IntBasis DT_NSR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01        MOV-TRAILLER.*/
        }
        public VA0280B_MOV_TRAILLER MOV_TRAILLER { get; set; } = new VA0280B_MOV_TRAILLER();
        public class VA0280B_MOV_TRAILLER : VarBasis
        {
            /*"  05      RT-TIPO-REG           PIC  X(001).*/
            public StringBasis RT_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      RT-NOME-EMPRESA       PIC  X(008).*/
            public StringBasis RT_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05      RT-QTDE-TIPO-1        PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      RT-QTDE-TIPO-2        PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      RT-QTDE-TIPO-3        PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      RT-QTDE-TIPO-4        PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      RT-QTDE-TIPO-5        PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      RT-QTDE-TIPO-6        PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      RT-QTDE-TIPO-7        PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      RT-QTDE-TIPO-8        PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      RT-QTDE-TIPO-9        PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      RT-QTDE-TIPO-0        PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      RT-QTDE-TOTAL         PIC  9(008).*/
            public IntBasis RT_QTDE_TOTAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      FILLER                PIC  X(003).*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"01           AREA-DE-WORK.*/
        }
        public VA0280B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA0280B_AREA_DE_WORK();
        public class VA0280B_AREA_DE_WORK : VarBasis
        {
            /*"  05         W-NSAS            PIC  9(06)     VALUE ZEROS.*/
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"  05         WSL-SQLCODE       PIC  9(09)     VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  05         AC-LINHAS         PIC  9(002)    VALUE 80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"  05         AC-PAGINA         PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-LIDOS          PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-ALTERADOS      PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_ALTERADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-PROCESSADO     PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_PROCESSADO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WS-ALTERA-CONTA   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WS_ALTERA_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
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
            /*"  05         WTEM-PROPOVA      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_PROPOVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WDUP-V0RCAP       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WDUP_V0RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WS-PROGRAMA       PIC  X(007)    VALUE SPACES.*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"  05         WS-SQLCODE        PIC  ----9.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "5", "----9."));
            /*"  05         WS-CANCBIL        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WS_CANCBIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         TB-MENSAGENS.*/
            public VA0280B_TB_MENSAGENS TB_MENSAGENS { get; set; } = new VA0280B_TB_MENSAGENS();
            public class VA0280B_TB_MENSAGENS : VarBasis
            {
                /*"    10       FILLER            PIC  X(037)    VALUE            '01INSUFICIENCIA DE FUNDOS'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"01INSUFICIENCIA DE FUNDOS");
                /*"    10       FILLER            PIC  X(037)    VALUE            '02CARTAO CANCELADO'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"02CARTAO CANCELADO");
                /*"    10       FILLER            PIC  X(037)    VALUE            '03SUBSTITUICAO CARTAO'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"03SUBSTITUICAO CARTAO");
                /*"    10       FILLER            PIC  X(037)    VALUE            '04CARTAO INVALIDO'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"04CARTAO INVALIDO");
                /*"    10       FILLER            PIC  X(037)    VALUE            '97ESTORNO S/COB OU ERRO DUPLICIDADE'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"97ESTORNO S/COB OU ERRO DUPLICIDADE");
                /*"    10       FILLER            PIC  X(037)    VALUE            '98ESTORNO S/COB NO PROXIMO MES'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"98ESTORNO S/COB NO PROXIMO MES");
                /*"    10       FILLER            PIC  X(037)    VALUE            '99CANCELA SEGURO'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"99CANCELA SEGURO");
                /*"  05         TB-MENSAGENS-R    REDEFINES TB-MENSAGENS.*/
            }
            private _REDEF_VA0280B_TB_MENSAGENS_R _tb_mensagens_r { get; set; }
            public _REDEF_VA0280B_TB_MENSAGENS_R TB_MENSAGENS_R
            {
                get { _tb_mensagens_r = new _REDEF_VA0280B_TB_MENSAGENS_R(); _.Move(TB_MENSAGENS, _tb_mensagens_r); VarBasis.RedefinePassValue(TB_MENSAGENS, _tb_mensagens_r, TB_MENSAGENS); _tb_mensagens_r.ValueChanged += () => { _.Move(_tb_mensagens_r, TB_MENSAGENS); }; return _tb_mensagens_r; }
                set { VarBasis.RedefinePassValue(value, _tb_mensagens_r, TB_MENSAGENS); }
            }  //Redefines
            public class _REDEF_VA0280B_TB_MENSAGENS_R : VarBasis
            {
                /*"    10       FILLER            OCCURS 7  TIMES.*/
                public ListBasis<VA0280B_FILLER_12> FILLER_12 { get; set; } = new ListBasis<VA0280B_FILLER_12>(7);
                public class VA0280B_FILLER_12 : VarBasis
                {
                    /*"      15     TB-RETORNO        PIC  9(002).*/
                    public IntBasis TB_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     TB-MENSAGEM       PIC  X(035).*/
                    public StringBasis TB_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "35", "X(035)."), @"");
                    /*"  05         W-DATA-NASCIMENTO  PIC 9(008)    VALUE ZEROS.*/

                    public VA0280B_FILLER_12()
                    {
                        TB_RETORNO.ValueChanged += OnValueChanged;
                        TB_MENSAGEM.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VA0280B_TB_MENSAGENS_R()
                {
                    FILLER_12.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER REDEFINES   W-DATA-NASCIMENTO.*/
            private _REDEF_VA0280B_FILLER_13 _filler_13 { get; set; }
            public _REDEF_VA0280B_FILLER_13 FILLER_13
            {
                get { _filler_13 = new _REDEF_VA0280B_FILLER_13(); _.Move(W_DATA_NASCIMENTO, _filler_13); VarBasis.RedefinePassValue(W_DATA_NASCIMENTO, _filler_13, W_DATA_NASCIMENTO); _filler_13.ValueChanged += () => { _.Move(_filler_13, W_DATA_NASCIMENTO); }; return _filler_13; }
                set { VarBasis.RedefinePassValue(value, _filler_13, W_DATA_NASCIMENTO); }
            }  //Redefines
            public class _REDEF_VA0280B_FILLER_13 : VarBasis
            {
                /*"    10       W-DIA-NASCIMENTO   PIC 9(002).*/
                public IntBasis W_DIA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W-MES-NASCIMENTO   PIC 9(002).*/
                public IntBasis W_MES_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W-ANO-NASCIMENTO   PIC 9(004).*/
                public IntBasis W_ANO_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05  W-DATA-SQL                    PIC X(010).*/

                public _REDEF_VA0280B_FILLER_13()
                {
                    W_DIA_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_MES_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_ANO_NASCIMENTO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05  W-DATA-SQL1 REDEFINES W-DATA-SQL.*/
            private _REDEF_VA0280B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_VA0280B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_VA0280B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_VA0280B_W_DATA_SQL1 : VarBasis
            {
                /*"    10    W-ANO-SQL                 PIC 9(004).*/
                public IntBasis W_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    W-MES-SQL                 PIC 9(002).*/
                public IntBasis W_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    W-DIA-SQL                 PIC 9(002).*/
                public IntBasis W_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_VA0280B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VA0280B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_VA0280B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_VA0280B_FILLER_14(); _.Move(WDATA_REL, _filler_14); VarBasis.RedefinePassValue(WDATA_REL, _filler_14, WDATA_REL); _filler_14.ValueChanged += () => { _.Move(_filler_14, WDATA_REL); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VA0280B_FILLER_14 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-SQL.*/

                public _REDEF_VA0280B_FILLER_14()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_15.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_16.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VA0280B_WDATA_SQL WDATA_SQL { get; set; } = new VA0280B_WDATA_SQL();
            public class VA0280B_WDATA_SQL : VarBasis
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
            private _REDEF_VA0280B_FILLER_17 _filler_17 { get; set; }
            public _REDEF_VA0280B_FILLER_17 FILLER_17
            {
                get { _filler_17 = new _REDEF_VA0280B_FILLER_17(); _.Move(WDATA_CURR, _filler_17); VarBasis.RedefinePassValue(WDATA_CURR, _filler_17, WDATA_CURR); _filler_17.ValueChanged += () => { _.Move(_filler_17, WDATA_CURR); }; return _filler_17; }
                set { VarBasis.RedefinePassValue(value, _filler_17, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_VA0280B_FILLER_17 : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-AMD-R.*/

                public _REDEF_VA0280B_FILLER_17()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_18.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_19.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public VA0280B_WDATA_AMD_R WDATA_AMD_R { get; set; } = new VA0280B_WDATA_AMD_R();
            public class VA0280B_WDATA_AMD_R : VarBasis
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
            public VA0280B_WHORA_CURR WHORA_CURR { get; set; } = new VA0280B_WHORA_CURR();
            public class VA0280B_WHORA_CURR : VarBasis
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
            public VA0280B_WDATA_CABEC WDATA_CABEC { get; set; } = new VA0280B_WDATA_CABEC();
            public class VA0280B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WHORA-CABEC.*/
            }
            public VA0280B_WHORA_CABEC WHORA_CABEC { get; set; } = new VA0280B_WHORA_CABEC();
            public class VA0280B_WHORA_CABEC : VarBasis
            {
                /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-HOST        PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_HOST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-HOST.*/
            private _REDEF_VA0280B_FILLER_24 _filler_24 { get; set; }
            public _REDEF_VA0280B_FILLER_24 FILLER_24
            {
                get { _filler_24 = new _REDEF_VA0280B_FILLER_24(); _.Move(WDATA_HOST, _filler_24); VarBasis.RedefinePassValue(WDATA_HOST, _filler_24, WDATA_HOST); _filler_24.ValueChanged += () => { _.Move(_filler_24, WDATA_HOST); }; return _filler_24; }
                set { VarBasis.RedefinePassValue(value, _filler_24, WDATA_HOST); }
            }  //Redefines
            public class _REDEF_VA0280B_FILLER_24 : VarBasis
            {
                /*"    10       WDATA-AA-HOST     PIC  9(004).*/
                public IntBasis WDATA_AA_HOST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-HOST     PIC  9(002).*/
                public IntBasis WDATA_MM_HOST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-HOST     PIC  9(002).*/
                public IntBasis WDATA_DD_HOST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WSSIST-DTMOVABE   PIC  X(008)    VALUE SPACES.*/

                public _REDEF_VA0280B_FILLER_24()
                {
                    WDATA_AA_HOST.ValueChanged += OnValueChanged;
                    FILLER_25.ValueChanged += OnValueChanged;
                    WDATA_MM_HOST.ValueChanged += OnValueChanged;
                    FILLER_26.ValueChanged += OnValueChanged;
                    WDATA_DD_HOST.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WSSIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05         WIDTCLIEMP        PIC  X(025)    VALUE SPACES.*/
            public StringBasis WIDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
            /*"  05         FILLER            REDEFINES      WIDTCLIEMP.*/
            private _REDEF_VA0280B_FILLER_27 _filler_27 { get; set; }
            public _REDEF_VA0280B_FILLER_27 FILLER_27
            {
                get { _filler_27 = new _REDEF_VA0280B_FILLER_27(); _.Move(WIDTCLIEMP, _filler_27); VarBasis.RedefinePassValue(WIDTCLIEMP, _filler_27, WIDTCLIEMP); _filler_27.ValueChanged += () => { _.Move(_filler_27, WIDTCLIEMP); }; return _filler_27; }
                set { VarBasis.RedefinePassValue(value, _filler_27, WIDTCLIEMP); }
            }  //Redefines
            public class _REDEF_VA0280B_FILLER_27 : VarBasis
            {
                /*"    10       WNUMBIL           PIC  9(015).*/
                public IntBasis WNUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10       FILLER            PIC  X(010).*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  05         WS-IDTCLIEMP      PIC  X(044)    VALUE SPACES.*/

                public _REDEF_VA0280B_FILLER_27()
                {
                    WNUMBIL.ValueChanged += OnValueChanged;
                    FILLER_28.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_IDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "44", "X(044)"), @"");
            /*"  05         FILLER            REDEFINES      WS-IDTCLIEMP.*/
            private _REDEF_VA0280B_FILLER_29 _filler_29 { get; set; }
            public _REDEF_VA0280B_FILLER_29 FILLER_29
            {
                get { _filler_29 = new _REDEF_VA0280B_FILLER_29(); _.Move(WS_IDTCLIEMP, _filler_29); VarBasis.RedefinePassValue(WS_IDTCLIEMP, _filler_29, WS_IDTCLIEMP); _filler_29.ValueChanged += () => { _.Move(_filler_29, WS_IDTCLIEMP); }; return _filler_29; }
                set { VarBasis.RedefinePassValue(value, _filler_29, WS_IDTCLIEMP); }
            }  //Redefines
            public class _REDEF_VA0280B_FILLER_29 : VarBasis
            {
                /*"    10       FILLER            PIC  X(023).*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"    10       WNUMPROP          PIC  9(013).*/
                public IntBasis WNUMPROP { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10       WNRPARCEL         PIC  9(004).*/
                public IntBasis WNRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(004).*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05         WAPOLICE          PIC  9(013)    VALUE  ZEROS.*/

                public _REDEF_VA0280B_FILLER_29()
                {
                    FILLER_30.ValueChanged += OnValueChanged;
                    WNUMPROP.ValueChanged += OnValueChanged;
                    WNRPARCEL.ValueChanged += OnValueChanged;
                    FILLER_31.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WAPOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         FILLER            REDEFINES      WAPOLICE.*/
            private _REDEF_VA0280B_FILLER_32 _filler_32 { get; set; }
            public _REDEF_VA0280B_FILLER_32 FILLER_32
            {
                get { _filler_32 = new _REDEF_VA0280B_FILLER_32(); _.Move(WAPOLICE, _filler_32); VarBasis.RedefinePassValue(WAPOLICE, _filler_32, WAPOLICE); _filler_32.ValueChanged += () => { _.Move(_filler_32, WAPOLICE); }; return _filler_32; }
                set { VarBasis.RedefinePassValue(value, _filler_32, WAPOLICE); }
            }  //Redefines
            public class _REDEF_VA0280B_FILLER_32 : VarBasis
            {
                /*"    10       WNUMAPOL          PIC  9(013).*/
                public IntBasis WNUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"  05         WS-NRTIT          PIC  9(014)    VALUE  ZEROS.*/

                public _REDEF_VA0280B_FILLER_32()
                {
                    WNUMAPOL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NRTIT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05         FILLER            REDEFINES      WS-NRTIT.*/
            private _REDEF_VA0280B_FILLER_33 _filler_33 { get; set; }
            public _REDEF_VA0280B_FILLER_33 FILLER_33
            {
                get { _filler_33 = new _REDEF_VA0280B_FILLER_33(); _.Move(WS_NRTIT, _filler_33); VarBasis.RedefinePassValue(WS_NRTIT, _filler_33, WS_NRTIT); _filler_33.ValueChanged += () => { _.Move(_filler_33, WS_NRTIT); }; return _filler_33; }
                set { VarBasis.RedefinePassValue(value, _filler_33, WS_NRTIT); }
            }  //Redefines
            public class _REDEF_VA0280B_FILLER_33 : VarBasis
            {
                /*"    10       WS-NUMTIT         PIC  9(013).*/
                public IntBasis WS_NUMTIT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10       WS-DIGTIT         PIC  9(001).*/
                public IntBasis WS_DIGTIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05         WAGENCIA          PIC  X(004)    VALUE SPACES.*/

                public _REDEF_VA0280B_FILLER_33()
                {
                    WS_NUMTIT.ValueChanged += OnValueChanged;
                    WS_DIGTIT.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WAGENCIA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05         FILLER            REDEFINES      WAGENCIA.*/
            private _REDEF_VA0280B_FILLER_34 _filler_34 { get; set; }
            public _REDEF_VA0280B_FILLER_34 FILLER_34
            {
                get { _filler_34 = new _REDEF_VA0280B_FILLER_34(); _.Move(WAGENCIA, _filler_34); VarBasis.RedefinePassValue(WAGENCIA, _filler_34, WAGENCIA); _filler_34.ValueChanged += () => { _.Move(_filler_34, WAGENCIA); }; return _filler_34; }
                set { VarBasis.RedefinePassValue(value, _filler_34, WAGENCIA); }
            }  //Redefines
            public class _REDEF_VA0280B_FILLER_34 : VarBasis
            {
                /*"    10       WAGEDEBITO        PIC  9(004).*/
                public IntBasis WAGEDEBITO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WNRAVISO          PIC  9(009)    VALUE ZEROS.*/

                public _REDEF_VA0280B_FILLER_34()
                {
                    WAGEDEBITO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WNRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         FILLER            REDEFINES      WNRAVISO.*/
            private _REDEF_VA0280B_FILLER_35 _filler_35 { get; set; }
            public _REDEF_VA0280B_FILLER_35 FILLER_35
            {
                get { _filler_35 = new _REDEF_VA0280B_FILLER_35(); _.Move(WNRAVISO, _filler_35); VarBasis.RedefinePassValue(WNRAVISO, _filler_35, WNRAVISO); _filler_35.ValueChanged += () => { _.Move(_filler_35, WNRAVISO); }; return _filler_35; }
                set { VarBasis.RedefinePassValue(value, _filler_35, WNRAVISO); }
            }  //Redefines
            public class _REDEF_VA0280B_FILLER_35 : VarBasis
            {
                /*"    10       WCONVENIOC        PIC  9(004).*/
                public IntBasis WCONVENIOC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WSEQUENCIA        PIC  9(005).*/
                public IntBasis WSEQUENCIA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  05         WCONVENIO         PIC  9(010)    VALUE ZEROS.*/

                public _REDEF_VA0280B_FILLER_35()
                {
                    WCONVENIOC.ValueChanged += OnValueChanged;
                    WSEQUENCIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WCONVENIO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"  05         WBILHETE          PIC  9(011)    VALUE ZEROS.*/
            public IntBasis WBILHETE { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  05         FILLER            REDEFINES      WBILHETE.*/
            private _REDEF_VA0280B_FILLER_36 _filler_36 { get; set; }
            public _REDEF_VA0280B_FILLER_36 FILLER_36
            {
                get { _filler_36 = new _REDEF_VA0280B_FILLER_36(); _.Move(WBILHETE, _filler_36); VarBasis.RedefinePassValue(WBILHETE, _filler_36, WBILHETE); _filler_36.ValueChanged += () => { _.Move(_filler_36, WBILHETE); }; return _filler_36; }
                set { VarBasis.RedefinePassValue(value, _filler_36, WBILHETE); }
            }  //Redefines
            public class _REDEF_VA0280B_FILLER_36 : VarBasis
            {
                /*"    10       FILLER            PIC  9(001).*/
                public IntBasis FILLER_37 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       WNRRCAP           PIC  9(009).*/
                public IntBasis WNRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10       FILLER            PIC  9(001).*/
                public IntBasis FILLER_38 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_VA0280B_FILLER_36()
                {
                    FILLER_37.ValueChanged += OnValueChanged;
                    WNRRCAP.ValueChanged += OnValueChanged;
                    FILLER_38.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  05         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_VA0280B_FILLER_39 _filler_39 { get; set; }
            public _REDEF_VA0280B_FILLER_39 FILLER_39
            {
                get { _filler_39 = new _REDEF_VA0280B_FILLER_39(); _.Move(WTIME_DAY, _filler_39); VarBasis.RedefinePassValue(WTIME_DAY, _filler_39, WTIME_DAY); _filler_39.ValueChanged += () => { _.Move(_filler_39, WTIME_DAY); }; return _filler_39; }
                set { VarBasis.RedefinePassValue(value, _filler_39, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_VA0280B_FILLER_39 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public VA0280B_WTIME_DAYR WTIME_DAYR { get; set; } = new VA0280B_WTIME_DAYR();
                public class VA0280B_WTIME_DAYR : VarBasis
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

                    public VA0280B_WTIME_DAYR()
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

                public _REDEF_VA0280B_FILLER_39()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public VA0280B_WS_TIME WS_TIME { get; set; } = new VA0280B_WS_TIME();
            public class VA0280B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WABEND.*/
            }
            public VA0280B_WABEND WABEND { get; set; } = new VA0280B_WABEND();
            public class VA0280B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' VA0280B'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0280B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public VA0280B_LK_LINK LK_LINK { get; set; } = new VA0280B_LK_LINK();
        public class VA0280B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TIT              PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TIT { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"01  AUX-TABELAS.*/
        }
        public VA0280B_AUX_TABELAS AUX_TABELAS { get; set; } = new VA0280B_AUX_TABELAS();
        public class VA0280B_AUX_TABELAS : VarBasis
        {
            /*"  03          WTABG-VALORES.*/
            public VA0280B_WTABG_VALORES WTABG_VALORES { get; set; } = new VA0280B_WTABG_VALORES();
            public class VA0280B_WTABG_VALORES : VarBasis
            {
                /*"    05        WTABG-OCORREPRD     OCCURS       800   TIMES                                  INDEXED      BY    WS-PRD.*/
                public ListBasis<VA0280B_WTABG_OCORREPRD> WTABG_OCORREPRD { get; set; } = new ListBasis<VA0280B_WTABG_OCORREPRD>(800);
                public class VA0280B_WTABG_OCORREPRD : VarBasis
                {
                    /*"      10      WTABG-CODPRODU      PIC S9(004)        COMP.*/
                    public IntBasis WTABG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WTABG-OCORRETIP     OCCURS       003   TIMES                                  INDEXED      BY    WS-TIP.*/
                    public ListBasis<VA0280B_WTABG_OCORRETIP> WTABG_OCORRETIP { get; set; } = new ListBasis<VA0280B_WTABG_OCORRETIP>(003);
                    public class VA0280B_WTABG_OCORRETIP : VarBasis
                    {
                        /*"        15    WTABG-TIPO          PIC  X(001).*/
                        public StringBasis WTABG_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"        15    WTABG-OCORRESIT     OCCURS       002   TIMES                                  INDEXED      BY    WS-SIT.*/
                        public ListBasis<VA0280B_WTABG_OCORRESIT> WTABG_OCORRESIT { get; set; } = new ListBasis<VA0280B_WTABG_OCORRESIT>(002);
                        public class VA0280B_WTABG_OCORRESIT : VarBasis
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


        public Dclgens.NUMERAES NUMERAES { get; set; } = new Dclgens.NUMERAES();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.PESSOFIS PESSOFIS { get; set; } = new Dclgens.PESSOFIS();
        public Dclgens.PESEMAIL PESEMAIL { get; set; } = new Dclgens.PESEMAIL();
        public Dclgens.PROPFID PROPFID { get; set; } = new Dclgens.PROPFID();
        public Dclgens.PF062 PF062 { get; set; } = new Dclgens.PF062();
        public VA0280B_V0PRODUTO V0PRODUTO { get; set; } = new VA0280B_V0PRODUTO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVIMENTO_FILE_NAME_P, string RVA0280B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVIMENTO.SetFile(MOVIMENTO_FILE_NAME_P);
                RVA0280B.SetFile(RVA0280B_FILE_NAME_P);

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
            /*" -672- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -675- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -678- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -681- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -682- DISPLAY 'PROGRAMA EM EXECUCAO VA0280B  ' . */
            _.Display($"PROGRAMA EM EXECUCAO VA0280B  ");

            /*" -683- DISPLAY '                              ' . */
            _.Display($"                              ");

            /*" -687- DISPLAY 'VERSAO V.03 NSGD   10/02/2015 ' . */
            _.Display($"VERSAO V.03 NSGD   10/02/2015 ");

            /*" -688- DISPLAY '                              ' . */
            _.Display($"                              ");

            /*" -690- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -692- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -694- PERFORM R0900-00-LER-ENTRADA. */

            R0900_00_LER_ENTRADA_SECTION();

            /*" -695- IF WFIM-MOVIMENTO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty())
            {

                /*" -696- PERFORM R0910-00-TRATA-VAZIO */

                R0910_00_TRATA_VAZIO_SECTION();

                /*" -698- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -701- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -703- PERFORM R2000-00-PROCESSA-FINAL. */

            R2000_00_PROCESSA_FINAL_SECTION();

            /*" -705- DISPLAY 'REGISTROS LIDOS ........... ' AC-LIDOS. */
            _.Display($"REGISTROS LIDOS ........... {AREA_DE_WORK.AC_LIDOS}");

            /*" -705- DISPLAY 'REGISTROS ALTER ........... ' AC-ALTERADOS. */
            _.Display($"REGISTROS ALTER ........... {AREA_DE_WORK.AC_ALTERADOS}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -713- CLOSE MOVIMENTO RVA0280B. */
            MOVIMENTO.Close();
            RVA0280B.Close();

            /*" -715- PERFORM R2200-00-CONTROLAR-ARQ-ENVIADO. */

            R2200_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -716- DISPLAY '*--- VA0280B   ' . */
            _.Display($"*--- VA0280B   ");

            /*" -718- DISPLAY '    FIM NORMAL' . */
            _.Display($"    FIM NORMAL");

            /*" -720- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -720- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -722- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -733- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -734- OPEN INPUT MOVIMENTO */
            MOVIMENTO.Open(MOV_REGISTRO);

            /*" -736- OPEN OUTPUT RVA0280B. */
            RVA0280B.Open(REG_VA0280B);

            /*" -738- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -743- PERFORM R0120-00-OBTER-MAX-NSAS. */

            R0120_00_OBTER_MAX_NSAS_SECTION();

            /*" -744- SET WS-PRD TO 1. */
            WS_PRD.Value = 1;

            /*" -747- MOVE ZEROS TO V0PROD-CODPRODU. */
            _.Move(0, V0PROD_CODPRODU);

            /*" -749- PERFORM R0220-00-MOVE-DADOS. */

            R0220_00_MOVE_DADOS_SECTION();

            /*" -750- MOVE 1 TO LD-PRODUTO */
            _.Move(1, AREA_DE_WORK.LD_PRODUTO);

            /*" -751- MOVE SPACES TO WFIM-PRODUTO */
            _.Move("", AREA_DE_WORK.WFIM_PRODUTO);

            /*" -753- PERFORM R0200-00-DECLARE-V0PRODUTO. */

            R0200_00_DECLARE_V0PRODUTO_SECTION();

            /*" -756- PERFORM R0210-00-FETCH-V0PRODUTO UNTIL WFIM-PRODUTO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_PRODUTO.IsEmpty()))
            {

                R0210_00_FETCH_V0PRODUTO_SECTION();
            }

            /*" -759- MOVE 9999 TO V0PROD-CODPRODU. */
            _.Move(9999, V0PROD_CODPRODU);

            /*" -763- PERFORM R0220-00-MOVE-DADOS UNTIL WS-SUBS GREATER 800. */

            while (!(AREA_DE_WORK.WS_SUBS > 800))
            {

                R0220_00_MOVE_DADOS_SECTION();
            }

            /*" -764- MOVE ZEROS TO WSHOST-QTDE. */
            _.Move(0, WSHOST_QTDE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -776- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -785- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -788- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -789- DISPLAY 'VA0280B - SISTEMA NAO ESTA CADASTRADO' */
                _.Display($"VA0280B - SISTEMA NAO ESTA CADASTRADO");

                /*" -791- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -792- MOVE V1SIST-DTMOVABE TO WDATA-HOST. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_HOST);

            /*" -793- MOVE WDATA-AA-HOST TO WSSIST-DTMOVABE(5:4). */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_24.WDATA_AA_HOST, AREA_DE_WORK.WSSIST_DTMOVABE, 5, 4);

            /*" -794- MOVE WDATA-MM-HOST TO WSSIST-DTMOVABE(3:2). */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_24.WDATA_MM_HOST, AREA_DE_WORK.WSSIST_DTMOVABE, 3, 2);

            /*" -794- MOVE WDATA-DD-HOST TO WSSIST-DTMOVABE(1:2). */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_24.WDATA_DD_HOST, AREA_DE_WORK.WSSIST_DTMOVABE, 1, 2);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -785- EXEC SQL SELECT DTMOVABE, DTMOVABE - 1 DAY, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTMOVABE-1, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTMOVABE_1, V1SIST_DTMOVABE_1);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-OBTER-MAX-NSAS-SECTION */
        private void R0120_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -804- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -807- MOVE 'STASOER5' TO ARQSIVPF-SIGLA-ARQUIVO. */
            _.Move("STASOER5", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -810- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -816- PERFORM R0120_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0120_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -819- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -820- DISPLAY 'VA0280B - ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"VA0280B - ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -822- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -825- MOVE ARQSIVPF-NSAS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, AREA_DE_WORK.W_NSAS);

            /*" -827- ADD 1 TO W-NSAS. */
            AREA_DE_WORK.W_NSAS.Value = AREA_DE_WORK.W_NSAS + 1;

            /*" -828- MOVE W-NSAS TO ARQSIVPF-NSAS-SIVPF. */
            _.Move(AREA_DE_WORK.W_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

        }

        [StopWatch]
        /*" R0120-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0120_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -816- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :ARQSIVPF-SISTEMA-ORIGEM END-EXEC. */

            var r0120_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 = new R0120_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0120_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1.Execute(r0120_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-SECTION */
        private void R0200_00_DECLARE_V0PRODUTO_SECTION()
        {
            /*" -844- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -849- PERFORM R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1 */

            R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1();

            /*" -851- PERFORM R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1 */

            R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1();

            /*" -854- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -855- DISPLAY 'R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ' */
                _.Display($"R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ");

                /*" -855- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1()
        {
            /*" -849- EXEC SQL DECLARE V0PRODUTO CURSOR FOR SELECT CODPRODU FROM SEGUROS.V0PRODUTO WHERE COD_EMPRESA = 0 ORDER BY CODPRODU END-EXEC. */
            V0PRODUTO = new VA0280B_V0PRODUTO(false);
            string GetQuery_V0PRODUTO()
            {
                var query = @$"SELECT CODPRODU 
							FROM SEGUROS.V0PRODUTO 
							WHERE COD_EMPRESA = 0 
							ORDER BY CODPRODU";

                return query;
            }
            V0PRODUTO.GetQueryEvent += GetQuery_V0PRODUTO;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-DB-OPEN-1 */
        public void R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1()
        {
            /*" -851- EXEC SQL OPEN V0PRODUTO END-EXEC. */

            V0PRODUTO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-SECTION */
        private void R0210_00_FETCH_V0PRODUTO_SECTION()
        {
            /*" -867- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -869- PERFORM R0210_00_FETCH_V0PRODUTO_DB_FETCH_1 */

            R0210_00_FETCH_V0PRODUTO_DB_FETCH_1();

            /*" -872- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -872- PERFORM R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1 */

                R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1();

                /*" -874- MOVE 'S' TO WFIM-PRODUTO */
                _.Move("S", AREA_DE_WORK.WFIM_PRODUTO);

                /*" -876- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -877- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -878- DISPLAY 'R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ' */
                _.Display($"R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ");

                /*" -880- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -883- ADD 1 TO LD-PRODUTO. */
            AREA_DE_WORK.LD_PRODUTO.Value = AREA_DE_WORK.LD_PRODUTO + 1;

            /*" -884- IF LD-PRODUTO GREATER 800 */

            if (AREA_DE_WORK.LD_PRODUTO > 800)
            {

                /*" -884- PERFORM R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2 */

                R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2();

                /*" -886- DISPLAY 'R0210-00 - ESTOURO TABELA INTERNA PRODUTO' */
                _.Display($"R0210-00 - ESTOURO TABELA INTERNA PRODUTO");

                /*" -888- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -888- PERFORM R0220-00-MOVE-DADOS. */

            R0220_00_MOVE_DADOS_SECTION();

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-FETCH-1 */
        public void R0210_00_FETCH_V0PRODUTO_DB_FETCH_1()
        {
            /*" -869- EXEC SQL FETCH V0PRODUTO INTO :V0PROD-CODPRODU END-EXEC. */

            if (V0PRODUTO.Fetch())
            {
                _.Move(V0PRODUTO.V0PROD_CODPRODU, V0PROD_CODPRODU);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1()
        {
            /*" -872- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-CLOSE-2 */
        public void R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2()
        {
            /*" -884- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }

        [StopWatch]
        /*" R0220-00-MOVE-DADOS-SECTION */
        private void R0220_00_MOVE_DADOS_SECTION()
        {
            /*" -900- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -903- MOVE V0PROD-CODPRODU TO WTABG-CODPRODU(WS-PRD). */
            _.Move(V0PROD_CODPRODU, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU);

            /*" -904- SET WS-TIP TO 1 */
            WS_TIP.Value = 1;

            /*" -906- PERFORM R0250-00-MOVE-TIPO 03 TIMES. */

            for (int i = 0; i < 3; i++)
            {

                R0250_00_MOVE_TIPO_SECTION();

            }

            /*" -907- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

            /*" -907- SET WS-SUBS TO WS-PRD. */
            AREA_DE_WORK.WS_SUBS.Value = WS_PRD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-MOVE-TIPO-SECTION */
        private void R0250_00_MOVE_TIPO_SECTION()
        {
            /*" -919- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -924- SET WS-SUBS1 TO WS-TIP. */
            AREA_DE_WORK.WS_SUBS1.Value = WS_TIP;

            /*" -925- IF WS-SUBS1 EQUAL 1 */

            if (AREA_DE_WORK.WS_SUBS1 == 1)
            {

                /*" -927- MOVE 'D' TO WTABG-TIPO(WS-PRD WS-TIP) */
                _.Move("D", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                /*" -931- ELSE */
            }
            else
            {


                /*" -932- IF WS-SUBS1 EQUAL 2 */

                if (AREA_DE_WORK.WS_SUBS1 == 2)
                {

                    /*" -934- MOVE 'R' TO WTABG-TIPO(WS-PRD WS-TIP) */
                    _.Move("R", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                    /*" -938- ELSE */
                }
                else
                {


                    /*" -941- MOVE 'S' TO WTABG-TIPO(WS-PRD WS-TIP). */
                    _.Move("S", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);
                }

            }


            /*" -942- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -944- PERFORM R0260-00-MOVE-SITUACAO 02 TIMES. */

            for (int i = 0; i < 2; i++)
            {

                R0260_00_MOVE_SITUACAO_SECTION();

            }

            /*" -944- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-MOVE-SITUACAO-SECTION */
        private void R0260_00_MOVE_SITUACAO_SECTION()
        {
            /*" -957- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -965- MOVE ZEROS TO WTABG-QTDE(WS-PRD WS-TIP WS-SIT) WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT) WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT). */
            _.Move(0, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON);

            /*" -969- SET WS-SUBS2 TO WS-SIT. */
            AREA_DE_WORK.WS_SUBS2.Value = WS_SIT;

            /*" -970- IF WS-SUBS2 EQUAL 1 */

            if (AREA_DE_WORK.WS_SUBS2 == 1)
            {

                /*" -972- MOVE '0' TO WTABG-SITUACAO(WS-PRD WS-TIP WS-SIT) */
                _.Move("0", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);

                /*" -976- ELSE */
            }
            else
            {


                /*" -979- MOVE '2' TO WTABG-SITUACAO(WS-PRD WS-TIP WS-SIT). */
                _.Move("2", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);
            }


            /*" -979- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-LER-ENTRADA-SECTION */
        private void R0900_00_LER_ENTRADA_SECTION()
        {
            /*" -991- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM R0900_10_LEITURA */

            R0900_10_LEITURA();

        }

        [StopWatch]
        /*" R0900-10-LEITURA */
        private void R0900_10_LEITURA(bool isPerform = false)
        {
            /*" -993- READ MOVIMENTO AT END */
            try
            {
                MOVIMENTO.Read(() =>
                {

                    /*" -995- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

                    /*" -997- GO TO R0900-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(MOVIMENTO.Value, MOV_REGISTRO);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1000- IF TIPO-REG NOT EQUAL 'H' AND '7' AND 'T' */

            if (!MOV_REGISTRO.TIPO_REG.In("H", "7", "T"))
            {

                /*" -1002- GO TO R0900-10-LEITURA. */
                new Task(() => R0900_10_LEITURA()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1004- ADD 1 TO AC-LIDOS. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

            /*" -1005- IF TIPO-REG EQUAL 'H' */

            if (MOV_REGISTRO.TIPO_REG == "H")
            {

                /*" -1006- MOVE MOV-REGISTRO TO MOV-HEADER */
                _.Move(MOVIMENTO?.Value, MOV_HEADER);

                /*" -1007- PERFORM R0905-00-TRATA-HEADER */

                R0905_00_TRATA_HEADER_SECTION();

                /*" -1008- MOVE 'H' TO WTEM-HEADER */
                _.Move("H", AREA_DE_WORK.WTEM_HEADER);

                /*" -1010- GO TO R0900-10-LEITURA. */
                new Task(() => R0900_10_LEITURA()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1011- IF TIPO-REG EQUAL 'T' */

            if (MOV_REGISTRO.TIPO_REG == "T")
            {

                /*" -1012- MOVE MOV-REGISTRO TO MOV-TRAILLER */
                _.Move(MOVIMENTO?.Value, MOV_TRAILLER);

                /*" -1013- MOVE 'T' TO WTEM-TRAILLER */
                _.Move("T", AREA_DE_WORK.WTEM_TRAILLER);

                /*" -1014- ADD 1 TO AC-QT-APROVADOS */
                AREA_DE_WORK.AC_QT_APROVADOS.Value = AREA_DE_WORK.AC_QT_APROVADOS + 1;

                /*" -1015- WRITE REG-VA0280B FROM MOV-TRAILLER */
                _.Move(MOV_TRAILLER.GetMoveValues(), REG_VA0280B);

                RVA0280B.Write(REG_VA0280B.GetMoveValues().ToString());

                /*" -1017- GO TO R0900-10-LEITURA. */
                new Task(() => R0900_10_LEITURA()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1018- IF TIPO-REG EQUAL '7' */

            if (MOV_REGISTRO.TIPO_REG == "7")
            {

                /*" -1018- MOVE MOV-REGISTRO TO MOV-REGISTRO-DT. */
                _.Move(MOVIMENTO?.Value, MOV_REGISTRO_DT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0905-00-TRATA-HEADER-SECTION */
        private void R0905_00_TRATA_HEADER_SECTION()
        {
            /*" -1030- IF HD-NOME NOT EQUAL 'STASOER' */

            if (MOV_HEADER.HD_NOME != "STASOER")
            {

                /*" -1032- DISPLAY 'R0905-00 - NOME DO ARQUIVO INVALIDO      ' MOV-HEADER */
                _.Display($"R0905-00 - NOME DO ARQUIVO INVALIDO      {MOV_HEADER}");

                /*" -1034- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1035- IF HD-SIST-ORIGEM NOT EQUAL 4 */

            if (MOV_HEADER.HD_SIST_ORIGEM != 4)
            {

                /*" -1037- DISPLAY 'R0905-00 - CODIGO ORIGEM INVALIDO        ' MOV-HEADER */
                _.Display($"R0905-00 - CODIGO ORIGEM INVALIDO        {MOV_HEADER}");

                /*" -1039- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1040- IF HD-SIST-DESTINO NOT EQUAL 4 */

            if (MOV_HEADER.HD_SIST_DESTINO != 4)
            {

                /*" -1042- DISPLAY 'R0905-00 - CODIGO DESTINO INVALIDO       ' MOV-HEADER */
                _.Display($"R0905-00 - CODIGO DESTINO INVALIDO       {MOV_HEADER}");

                /*" -1045- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1047- MOVE WSSIST-DTMOVABE TO HD-DATA-GERACAO. */
            _.Move(AREA_DE_WORK.WSSIST_DTMOVABE, MOV_HEADER.HD_DATA_GERACAO);

            /*" -1049- MOVE ARQSIVPF-NSAS-SIVPF TO HD-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, MOV_HEADER.HD_NSAS);

            /*" -1049- WRITE REG-VA0280B FROM MOV-HEADER. */
            _.Move(MOV_HEADER.GetMoveValues(), REG_VA0280B);

            RVA0280B.Write(REG_VA0280B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0905_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-TRATA-VAZIO-SECTION */
        private void R0910_00_TRATA_VAZIO_SECTION()
        {
            /*" -1062- MOVE 'H' TO HD-TIPO-REG. */
            _.Move("H", MOV_HEADER.HD_TIPO_REG);

            /*" -1063- MOVE 'STASOER' TO HD-NOME. */
            _.Move("STASOER", MOV_HEADER.HD_NOME);

            /*" -1064- MOVE WSSIST-DTMOVABE TO HD-DATA-GERACAO. */
            _.Move(AREA_DE_WORK.WSSIST_DTMOVABE, MOV_HEADER.HD_DATA_GERACAO);

            /*" -1065- MOVE '4' TO HD-SIST-ORIGEM. */
            _.Move("4", MOV_HEADER.HD_SIST_ORIGEM);

            /*" -1066- MOVE '4' TO HD-SIST-DESTINO. */
            _.Move("4", MOV_HEADER.HD_SIST_DESTINO);

            /*" -1067- MOVE ARQSIVPF-NSAS-SIVPF TO HD-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, MOV_HEADER.HD_NSAS);

            /*" -1069- WRITE REG-VA0280B FROM MOV-HEADER. */
            _.Move(MOV_HEADER.GetMoveValues(), REG_VA0280B);

            RVA0280B.Write(REG_VA0280B.GetMoveValues().ToString());

            /*" -1070- MOVE 'T' TO RT-TIPO-REG. */
            _.Move("T", MOV_TRAILLER.RT_TIPO_REG);

            /*" -1071- MOVE 'STASOER' TO RT-NOME-EMPRESA. */
            _.Move("STASOER", MOV_TRAILLER.RT_NOME_EMPRESA);

            /*" -1082- MOVE 00000000 TO RT-QTDE-TIPO-1 RT-QTDE-TIPO-2 RT-QTDE-TIPO-3 RT-QTDE-TIPO-4 RT-QTDE-TIPO-5 RT-QTDE-TIPO-6 RT-QTDE-TIPO-7 RT-QTDE-TIPO-8 RT-QTDE-TIPO-9 RT-QTDE-TIPO-0 RT-QTDE-TOTAL. */
            _.Move(00000000, MOV_TRAILLER.RT_QTDE_TIPO_1, MOV_TRAILLER.RT_QTDE_TIPO_2, MOV_TRAILLER.RT_QTDE_TIPO_3, MOV_TRAILLER.RT_QTDE_TIPO_4, MOV_TRAILLER.RT_QTDE_TIPO_5, MOV_TRAILLER.RT_QTDE_TIPO_6, MOV_TRAILLER.RT_QTDE_TIPO_7, MOV_TRAILLER.RT_QTDE_TIPO_8, MOV_TRAILLER.RT_QTDE_TIPO_9, MOV_TRAILLER.RT_QTDE_TIPO_0, MOV_TRAILLER.RT_QTDE_TOTAL);

            /*" -1082- WRITE REG-VA0280B FROM MOV-TRAILLER. */
            _.Move(MOV_TRAILLER.GetMoveValues(), REG_VA0280B);

            RVA0280B.Write(REG_VA0280B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1103- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1105- PERFORM R1050-00-SELECT-PROPOSTA. */

            R1050_00_SELECT_PROPOSTA_SECTION();

            /*" -1106- IF WTEM-PROPOVA EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_PROPOVA == "N")
            {

                /*" -1107- WRITE REG-VA0280B FROM MOV-REGISTRO-DT */
                _.Move(MOV_REGISTRO_DT.GetMoveValues(), REG_VA0280B);

                RVA0280B.Write(REG_VA0280B.GetMoveValues().ToString());

                /*" -1108- PERFORM R0900-00-LER-ENTRADA */

                R0900_00_LER_ENTRADA_SECTION();

                /*" -1110- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1114- PERFORM R1100-00-TRATA-RETORNO UNTIL DT-NUM-PROPOSTA NOT EQUAL WSHOST-NUM-PROPOSTA OR WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(MOV_REGISTRO_DT.DT_NUM_PROPOSTA != WSHOST_NUM_PROPOSTA || !AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty()))
            {

                R1100_00_TRATA_RETORNO_SECTION();
            }

            /*" -1115- IF WS-ALTERA-CONTA EQUAL 'S' */

            if (AREA_DE_WORK.WS_ALTERA_CONTA == "S")
            {

                /*" -1116- PERFORM R1390-00-TRATA-INF-CONTA */

                R1390_00_TRATA_INF_CONTA_SECTION();

                /*" -1116- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-SELECT-PROPOSTA-SECTION */
        private void R1050_00_SELECT_PROPOSTA_SECTION()
        {
            /*" -1127- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1136- MOVE ZEROS TO WSHOST-NUM-PROPOSTA OPCPAGVI-COD-AGENCIA-DEBITO OPCPAGVI-OPE-CONTA-DEBITO OPCPAGVI-NUM-CONTA-DEBITO OPCPAGVI-DIG-CONTA-DEBITO OPCPAGVI-NUM-CARTAO-CREDITO OPCPAGVI-DIA-DEBITO. */
            _.Move(0, WSHOST_NUM_PROPOSTA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);

            /*" -1139- MOVE DT-NUM-PROPOSTA TO WSHOST-NUM-PROPOSTA. */
            _.Move(MOV_REGISTRO_DT.DT_NUM_PROPOSTA, WSHOST_NUM_PROPOSTA);

            /*" -1141- MOVE 'S' TO WTEM-PROPOVA. */
            _.Move("S", AREA_DE_WORK.WTEM_PROPOVA);

            /*" -1143- MOVE 'N' TO WS-ALTERA-CONTA. */
            _.Move("N", AREA_DE_WORK.WS_ALTERA_CONTA);

            /*" -1146- MOVE DT-COD-ATRIBUTO TO DT-COD-RETORNO. */
            _.Move(MOV_REGISTRO_DT.DT_COD_ATRIBUTO, MOV_REGISTRO_DT.DT_COD_RETORNO);

            /*" -1159- PERFORM R1050_00_SELECT_PROPOSTA_DB_SELECT_1 */

            R1050_00_SELECT_PROPOSTA_DB_SELECT_1();

            /*" -1162- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1163- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1164- MOVE 'N' TO WTEM-PROPOVA */
                    _.Move("N", AREA_DE_WORK.WTEM_PROPOVA);

                    /*" -1165- ELSE */
                }
                else
                {


                    /*" -1166- DISPLAY 'R1050-00 - PROBLEMAS ACESSO (PROPOSTA)' */
                    _.Display($"R1050-00 - PROBLEMAS ACESSO (PROPOSTA)");

                    /*" -1166- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1050-00-SELECT-PROPOSTA-DB-SELECT-1 */
        public void R1050_00_SELECT_PROPOSTA_DB_SELECT_1()
        {
            /*" -1159- EXEC SQL SELECT T1.NUM_CERTIFICADO, T1.COD_CLIENTE, T1.OCOREND, T1.NUM_APOLICE INTO :PROPOVA-NUM-CERTIFICADO, :PROPOVA-COD-CLIENTE, :PROPOVA-OCOREND, :PROPOVA-NUM-APOLICE FROM SEGUROS.PROPOSTAS_VA T1 WHERE T1.NUM_CERTIFICADO = :WSHOST-NUM-PROPOSTA AND T1.SIT_REGISTRO IN ( '3' , '6' ) WITH UR END-EXEC. */

            var r1050_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 = new R1050_00_SELECT_PROPOSTA_DB_SELECT_1_Query1()
            {
                WSHOST_NUM_PROPOSTA = WSHOST_NUM_PROPOSTA.ToString(),
            };

            var executed_1 = R1050_00_SELECT_PROPOSTA_DB_SELECT_1_Query1.Execute(r1050_00_SELECT_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(executed_1.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(executed_1.PROPOVA_OCOREND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);
                _.Move(executed_1.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-TRATA-RETORNO-SECTION */
        private void R1100_00_TRATA_RETORNO_SECTION()
        {
            /*" -1177- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1180- MOVE DT-COD-ATRIBUTO TO DT-COD-RETORNO. */
            _.Move(MOV_REGISTRO_DT.DT_COD_ATRIBUTO, MOV_REGISTRO_DT.DT_COD_RETORNO);

            /*" -1183- MOVE ZEROS TO AC-PROCESSADO. */
            _.Move(0, AREA_DE_WORK.AC_PROCESSADO);

            /*" -1186- IF DT-COD-ATRIBUTO EQUAL 0401 OR 0402 OR 0403 */

            if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO.In("0401", "0402", "0403"))
            {

                /*" -1187- PERFORM R1150-00-TRATA-CANCEL */

                R1150_00_TRATA_CANCEL_SECTION();

                /*" -1188- ELSE */
            }
            else
            {


                /*" -1189- IF DT-COD-ATRIBUTO EQUAL 0595 */

                if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0595)
                {

                    /*" -1190- PERFORM R1170-00-TRATA-PROFISSAO */

                    R1170_00_TRATA_PROFISSAO_SECTION();

                    /*" -1191- ELSE */
                }
                else
                {


                    /*" -1192- IF DT-COD-ATRIBUTO EQUAL 0691 */

                    if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0691)
                    {

                        /*" -1193- PERFORM R1200-00-TRATA-NOME */

                        R1200_00_TRATA_NOME_SECTION();

                        /*" -1194- ELSE */
                    }
                    else
                    {


                        /*" -1195- IF DT-COD-ATRIBUTO EQUAL 0697 */

                        if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0697)
                        {

                            /*" -1196- PERFORM R1210-00-TRATA-DT-NASC */

                            R1210_00_TRATA_DT_NASC_SECTION();

                            /*" -1197- ELSE */
                        }
                        else
                        {


                            /*" -1198- IF DT-COD-ATRIBUTO EQUAL 0700 */

                            if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0700)
                            {

                                /*" -1199- PERFORM R1220-00-TRATA-SEXO */

                                R1220_00_TRATA_SEXO_SECTION();

                                /*" -1200- ELSE */
                            }
                            else
                            {


                                /*" -1201- IF DT-COD-ATRIBUTO EQUAL 0702 */

                                if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0702)
                                {

                                    /*" -1202- PERFORM R1230-00-TRATA-EST-CIVIL */

                                    R1230_00_TRATA_EST_CIVIL_SECTION();

                                    /*" -1203- ELSE */
                                }
                                else
                                {


                                    /*" -1204- IF DT-COD-ATRIBUTO EQUAL 0703 */

                                    if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0703)
                                    {

                                        /*" -1205- PERFORM R1240-00-TRATA-ENDERECO */

                                        R1240_00_TRATA_ENDERECO_SECTION();

                                        /*" -1206- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1207- IF DT-COD-ATRIBUTO EQUAL 0704 */

                                        if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0704)
                                        {

                                            /*" -1208- PERFORM R1250-00-TRATA-BAIRRO */

                                            R1250_00_TRATA_BAIRRO_SECTION();

                                            /*" -1209- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1210- IF DT-COD-ATRIBUTO EQUAL 0705 */

                                            if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0705)
                                            {

                                                /*" -1211- PERFORM R1260-00-TRATA-CIDADE */

                                                R1260_00_TRATA_CIDADE_SECTION();

                                                /*" -1212- ELSE */
                                            }
                                            else
                                            {


                                                /*" -1213- IF DT-COD-ATRIBUTO EQUAL 0706 */

                                                if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0706)
                                                {

                                                    /*" -1214- PERFORM R1270-00-TRATA-UF */

                                                    R1270_00_TRATA_UF_SECTION();

                                                    /*" -1215- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -1216- IF DT-COD-ATRIBUTO EQUAL 0708 */

                                                    if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0708)
                                                    {

                                                        /*" -1217- PERFORM R1280-00-TRATA-CEP */

                                                        R1280_00_TRATA_CEP_SECTION();

                                                        /*" -1218- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -1219- IF DT-COD-ATRIBUTO EQUAL 0721 */

                                                        if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0721)
                                                        {

                                                            /*" -1220- PERFORM R1290-00-TRATA-AGENCIA */

                                                            R1290_00_TRATA_AGENCIA_SECTION();

                                                            /*" -1221- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -1222- IF DT-COD-ATRIBUTO EQUAL 0723 */

                                                            if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0723)
                                                            {

                                                                /*" -1223- PERFORM R1300-00-TRATA-OPERACAO */

                                                                R1300_00_TRATA_OPERACAO_SECTION();

                                                                /*" -1224- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -1225- IF DT-COD-ATRIBUTO EQUAL 0724 */

                                                                if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0724)
                                                                {

                                                                    /*" -1226- PERFORM R1310-00-TRATA-CONTA */

                                                                    R1310_00_TRATA_CONTA_SECTION();

                                                                    /*" -1227- ELSE */
                                                                }
                                                                else
                                                                {


                                                                    /*" -1228- IF DT-COD-ATRIBUTO EQUAL 0725 */

                                                                    if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0725)
                                                                    {

                                                                        /*" -1229- PERFORM R1320-00-TRATA-DV */

                                                                        R1320_00_TRATA_DV_SECTION();

                                                                        /*" -1230- ELSE */
                                                                    }
                                                                    else
                                                                    {


                                                                        /*" -1231- IF DT-COD-ATRIBUTO EQUAL 0729 */

                                                                        if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0729)
                                                                        {

                                                                            /*" -1232- PERFORM R1325-00-TRATA-RENDA-IND */

                                                                            R1325_00_TRATA_RENDA_IND_SECTION();

                                                                            /*" -1233- ELSE */
                                                                        }
                                                                        else
                                                                        {


                                                                            /*" -1234- IF DT-COD-ATRIBUTO EQUAL 0730 */

                                                                            if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0730)
                                                                            {

                                                                                /*" -1235- PERFORM R1326-00-TRATA-RENDA-FAM */

                                                                                R1326_00_TRATA_RENDA_FAM_SECTION();

                                                                                /*" -1236- ELSE */
                                                                            }
                                                                            else
                                                                            {


                                                                                /*" -1237- IF DT-COD-ATRIBUTO EQUAL 0904 */

                                                                                if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0904)
                                                                                {

                                                                                    /*" -1238- PERFORM R1330-00-TRATA-DIA-DEB */

                                                                                    R1330_00_TRATA_DIA_DEB_SECTION();

                                                                                    /*" -1242- ELSE */
                                                                                }
                                                                                else
                                                                                {


                                                                                    /*" -1243- IF DT-COD-ATRIBUTO EQUAL 0906 */

                                                                                    if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0906)
                                                                                    {

                                                                                        /*" -1245- PERFORM R1350-00-TRATA-CARTAO */

                                                                                        R1350_00_TRATA_CARTAO_SECTION();

                                                                                        /*" -1246- ELSE */
                                                                                    }
                                                                                    else
                                                                                    {


                                                                                        /*" -1247- IF DT-COD-ATRIBUTO EQUAL 0907 */

                                                                                        if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0907)
                                                                                        {

                                                                                            /*" -1249- PERFORM R1360-00-TRATA-DDD-RES */

                                                                                            R1360_00_TRATA_DDD_RES_SECTION();

                                                                                            /*" -1250- ELSE */
                                                                                        }
                                                                                        else
                                                                                        {


                                                                                            /*" -1251- IF DT-COD-ATRIBUTO EQUAL 0908 */

                                                                                            if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0908)
                                                                                            {

                                                                                                /*" -1253- PERFORM R1370-00-TRATA-TEL-RES */

                                                                                                R1370_00_TRATA_TEL_RES_SECTION();

                                                                                                /*" -1254- ELSE */
                                                                                            }
                                                                                            else
                                                                                            {


                                                                                                /*" -1255- IF DT-COD-ATRIBUTO EQUAL 0913 */

                                                                                                if (MOV_REGISTRO_DT.DT_COD_ATRIBUTO == 0913)
                                                                                                {

                                                                                                    /*" -1256- PERFORM R1380-00-TRATA-EMAIL */

                                                                                                    R1380_00_TRATA_EMAIL_SECTION();

                                                                                                    /*" -1258- END-IF. */
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


            /*" -1259- IF AC-PROCESSADO GREATER ZEROS */

            if (AREA_DE_WORK.AC_PROCESSADO > 00)
            {

                /*" -1262- MOVE ZEROS TO DT-COD-RETORNO. */
                _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);
            }


            /*" -1262- WRITE REG-VA0280B FROM MOV-REGISTRO-DT. */
            _.Move(MOV_REGISTRO_DT.GetMoveValues(), REG_VA0280B);

            RVA0280B.Write(REG_VA0280B.GetMoveValues().ToString());

            /*" -0- FLUXCONTROL_PERFORM R1100_50_SAIDA */

            R1100_50_SAIDA();

        }

        [StopWatch]
        /*" R1100-50-SAIDA */
        private void R1100_50_SAIDA(bool isPerform = false)
        {
            /*" -1266- PERFORM R0900-00-LER-ENTRADA. */

            R0900_00_LER_ENTRADA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-TRATA-CANCEL-SECTION */
        private void R1150_00_TRATA_CANCEL_SECTION()
        {
            /*" -1280- MOVE '1150' TO WNR-EXEC-SQL. */
            _.Move("1150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1365- PERFORM R1150_00_TRATA_CANCEL_DB_INSERT_1 */

            R1150_00_TRATA_CANCEL_DB_INSERT_1();

            /*" -1368- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1369- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1370- GO TO R1150-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/ //GOTO
                    return;

                    /*" -1371- ELSE */
                }
                else
                {


                    /*" -1372- DISPLAY 'R1150-00 - PROBLEMAS INSERT RELAT' */
                    _.Display($"R1150-00 - PROBLEMAS INSERT RELAT");

                    /*" -1373- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1374- END-IF */
                }


                /*" -1376- END-IF. */
            }


            /*" -1382- PERFORM R1150_00_TRATA_CANCEL_DB_UPDATE_1 */

            R1150_00_TRATA_CANCEL_DB_UPDATE_1();

            /*" -1385- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1386- DISPLAY 'R1150-00 - PROBLEMAS UPDATE PROPOSTA' */
                _.Display($"R1150-00 - PROBLEMAS UPDATE PROPOSTA");

                /*" -1387- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1390- END-IF. */
            }


            /*" -1392- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -1392- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1150-00-TRATA-CANCEL-DB-INSERT-1 */
        public void R1150_00_TRATA_CANCEL_DB_INSERT_1()
        {
            /*" -1365- EXEC SQL INSERT INTO SEGUROS.RELATORIOS ( COD_USUARIO, DATA_SOLICITACAO, IDE_SISTEMA, COD_RELATORIO, NUM_COPIAS, QUANTIDADE, PERI_INICIAL, PERI_FINAL, DATA_REFERENCIA, MES_REFERENCIA, ANO_REFERENCIA, ORGAO_EMISSOR, COD_FONTE, COD_PRODUTOR, RAMO_EMISSOR, COD_MODALIDADE, COD_CONGENERE, NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, NUM_CERTIFICADO, NUM_TITULO, COD_SUBGRUPO, COD_OPERACAO, COD_PLANO, OCORR_HISTORICO, NUM_APOL_LIDER, ENDOS_LIDER, NUM_PARC_LIDER, NUM_SINISTRO, NUM_SINI_LIDER, NUM_ORDEM, COD_MOEDA, TIPO_CORRECAO, SIT_REGISTRO, IND_PREV_DEFINIT, IND_ANAL_RESUMO, COD_EMPRESA, PERI_RENOVACAO, PCT_AUMENTO, TIMESTAMP) VALUES ( 'VA0280B' , :V1SIST-DTMOVABE, 'VA' , 'VA0437B' , 0, 0, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, 0, 0, 0, 0, 0, 0, 0, 0, :PROPOVA-NUM-APOLICE, 0, 2, :PROPOVA-NUM-CERTIFICADO, 0, 0, 2, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0.00, CURRENT TIMESTAMP ) END-EXEC. */

            var r1150_00_TRATA_CANCEL_DB_INSERT_1_Insert1 = new R1150_00_TRATA_CANCEL_DB_INSERT_1_Insert1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1150_00_TRATA_CANCEL_DB_INSERT_1_Insert1.Execute(r1150_00_TRATA_CANCEL_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1150-00-TRATA-CANCEL-DB-UPDATE-1 */
        public void R1150_00_TRATA_CANCEL_DB_UPDATE_1()
        {
            /*" -1382- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_REGISTRO = '4' , COD_USUARIO = 'VA0280B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1150_00_TRATA_CANCEL_DB_UPDATE_1_Update1 = new R1150_00_TRATA_CANCEL_DB_UPDATE_1_Update1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1150_00_TRATA_CANCEL_DB_UPDATE_1_Update1.Execute(r1150_00_TRATA_CANCEL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1170-00-TRATA-PROFISSAO-SECTION */
        private void R1170_00_TRATA_PROFISSAO_SECTION()
        {
            /*" -1404- MOVE '1170' TO WNR-EXEC-SQL. */
            _.Move("1170", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1407- MOVE ZEROS TO WSHOST-CBO. */
            _.Move(0, WSHOST_CBO);

            /*" -1410- MOVE DT-VAL-ATRIBUTO (1:9) TO WSHOST-CBO. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 9), WSHOST_CBO);

            /*" -1411- IF WSHOST-CBO EQUAL ZEROS */

            if (WSHOST_CBO == 00)
            {

                /*" -1413- GO TO R1170-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1170_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1417- MOVE ZEROS TO PESSOFIS-COD-CBO PF062-COD-CBO OF DCLPF-CBO. */
            _.Move(0, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_CBO, PF062.DCLPF_CBO.PF062_COD_CBO);

            /*" -1421- MOVE WSHOST-CBO TO PESSOFIS-COD-CBO PF062-COD-CBO OF DCLPF-CBO. */
            _.Move(WSHOST_CBO, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_CBO, PF062.DCLPF_CBO.PF062_COD_CBO);

            /*" -1425- PERFORM R1170_00_TRATA_PROFISSAO_DB_UPDATE_1 */

            R1170_00_TRATA_PROFISSAO_DB_UPDATE_1();

            /*" -1428- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1429- DISPLAY 'R1170-00 - PROBLEMAS UPDATE PF-CBO' */
                _.Display($"R1170-00 - PROBLEMAS UPDATE PF-CBO");

                /*" -1430- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1431- ELSE */
            }
            else
            {


                /*" -1432- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1433- ADD 1 TO AC-PROCESSADO */
                    AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

                    /*" -1434- MOVE ZEROS TO DT-COD-RETORNO */
                    _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

                    /*" -1435- END-IF */
                }


                /*" -1437- END-IF. */
            }


            /*" -1441- PERFORM R1170_00_TRATA_PROFISSAO_DB_UPDATE_2 */

            R1170_00_TRATA_PROFISSAO_DB_UPDATE_2();

            /*" -1444- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1445- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1446- GO TO R1170-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1170_99_SAIDA*/ //GOTO
                    return;

                    /*" -1447- ELSE */
                }
                else
                {


                    /*" -1448- DISPLAY 'R1170-00 - PROBLEMAS UPDATE PEFISICA' */
                    _.Display($"R1170-00 - PROBLEMAS UPDATE PEFISICA");

                    /*" -1449- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1450- END-IF */
                }


                /*" -1452- END-IF. */
            }


            /*" -1453- IF AC-PROCESSADO EQUAL ZEROS */

            if (AREA_DE_WORK.AC_PROCESSADO == 00)
            {

                /*" -1455- ADD 1 TO AC-ALTERADOS AC-PROCESSADO */
                AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
                AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

                /*" -1456- MOVE ZEROS TO DT-COD-RETORNO */
                _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

                /*" -1456- END-IF. */
            }


        }

        [StopWatch]
        /*" R1170-00-TRATA-PROFISSAO-DB-UPDATE-1 */
        public void R1170_00_TRATA_PROFISSAO_DB_UPDATE_1()
        {
            /*" -1425- EXEC SQL UPDATE SEGUROS.PF_CBO SET COD_CBO = :DCLPF-CBO.PF062-COD-CBO WHERE NUM_PROPOSTA_SIVPF = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1170_00_TRATA_PROFISSAO_DB_UPDATE_1_Update1 = new R1170_00_TRATA_PROFISSAO_DB_UPDATE_1_Update1()
            {
                PF062_COD_CBO = PF062.DCLPF_CBO.PF062_COD_CBO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1170_00_TRATA_PROFISSAO_DB_UPDATE_1_Update1.Execute(r1170_00_TRATA_PROFISSAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1170_99_SAIDA*/

        [StopWatch]
        /*" R1170-00-TRATA-PROFISSAO-DB-UPDATE-2 */
        public void R1170_00_TRATA_PROFISSAO_DB_UPDATE_2()
        {
            /*" -1441- EXEC SQL UPDATE SEGUROS.PESSOA_FISICA SET COD_CBO = :PESSOFIS-COD-CBO WHERE COD_PESSOA = :PROPOVA-COD-CLIENTE END-EXEC. */

            var r1170_00_TRATA_PROFISSAO_DB_UPDATE_2_Update1 = new R1170_00_TRATA_PROFISSAO_DB_UPDATE_2_Update1()
            {
                PESSOFIS_COD_CBO = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_CBO.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            R1170_00_TRATA_PROFISSAO_DB_UPDATE_2_Update1.Execute(r1170_00_TRATA_PROFISSAO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1200-00-TRATA-NOME-SECTION */
        private void R1200_00_TRATA_NOME_SECTION()
        {
            /*" -1469- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1472- MOVE SPACES TO WSHOST-PARAM. */
            _.Move("", WSHOST_PARAM);

            /*" -1475- MOVE DT-VAL-ATRIBUTO (1:40) TO WSHOST-PARAM. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 40), WSHOST_PARAM);

            /*" -1476- IF WSHOST-PARAM EQUAL SPACES */

            if (WSHOST_PARAM.IsEmpty())
            {

                /*" -1478- GO TO R1200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1481- MOVE WSHOST-PARAM (1:40) TO CLIENTES-NOME-RAZAO. */
            _.Move(WSHOST_PARAM.Substring(1, 40), CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

            /*" -1485- PERFORM R1200_00_TRATA_NOME_DB_UPDATE_1 */

            R1200_00_TRATA_NOME_DB_UPDATE_1();

            /*" -1488- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1489- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1490- GO TO R1200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;

                    /*" -1491- ELSE */
                }
                else
                {


                    /*" -1492- DISPLAY 'R1200-00 - PROBLEMAS UPDATE CLIENTE' */
                    _.Display($"R1200-00 - PROBLEMAS UPDATE CLIENTE");

                    /*" -1493- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1494- END-IF */
                }


                /*" -1496- END-IF. */
            }


            /*" -1498- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -1498- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1200-00-TRATA-NOME-DB-UPDATE-1 */
        public void R1200_00_TRATA_NOME_DB_UPDATE_1()
        {
            /*" -1485- EXEC SQL UPDATE SEGUROS.CLIENTES SET NOME_RAZAO = :CLIENTES-NOME-RAZAO WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE END-EXEC. */

            var r1200_00_TRATA_NOME_DB_UPDATE_1_Update1 = new R1200_00_TRATA_NOME_DB_UPDATE_1_Update1()
            {
                CLIENTES_NOME_RAZAO = CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            R1200_00_TRATA_NOME_DB_UPDATE_1_Update1.Execute(r1200_00_TRATA_NOME_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-TRATA-DT-NASC-SECTION */
        private void R1210_00_TRATA_DT_NASC_SECTION()
        {
            /*" -1510- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1513- MOVE SPACES TO WSHOST-DT-NASC. */
            _.Move("", WSHOST_DT_NASC);

            /*" -1516- MOVE DT-VAL-ATRIBUTO (1:8) TO WSHOST-DT-NASC. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 8), WSHOST_DT_NASC);

            /*" -1517- IF WSHOST-DT-NASC EQUAL SPACES */

            if (WSHOST_DT_NASC.IsEmpty())
            {

                /*" -1519- GO TO R1210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1522- MOVE WSHOST-DT-NASC TO W-DATA-NASCIMENTO. */
            _.Move(WSHOST_DT_NASC, AREA_DE_WORK.W_DATA_NASCIMENTO);

            /*" -1525- MOVE W-DIA-NASCIMENTO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(AREA_DE_WORK.FILLER_13.W_DIA_NASCIMENTO, AREA_DE_WORK.W_DATA_SQL1.W_DIA_SQL);

            /*" -1528- MOVE W-MES-NASCIMENTO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(AREA_DE_WORK.FILLER_13.W_MES_NASCIMENTO, AREA_DE_WORK.W_DATA_SQL1.W_MES_SQL);

            /*" -1531- MOVE W-ANO-NASCIMENTO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(AREA_DE_WORK.FILLER_13.W_ANO_NASCIMENTO, AREA_DE_WORK.W_DATA_SQL1.W_ANO_SQL);

            /*" -1535- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", AREA_DE_WORK.W_DATA_SQL1.W_BARRA1);
            _.Move("-", AREA_DE_WORK.W_DATA_SQL1.W_BARRA2);


            /*" -1538- MOVE W-DATA-SQL TO CLIENTES-DATA-NASCIMENTO. */
            _.Move(AREA_DE_WORK.W_DATA_SQL, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

            /*" -1542- PERFORM R1210_00_TRATA_DT_NASC_DB_UPDATE_1 */

            R1210_00_TRATA_DT_NASC_DB_UPDATE_1();

            /*" -1545- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1546- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1547- GO TO R1210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/ //GOTO
                    return;

                    /*" -1548- ELSE */
                }
                else
                {


                    /*" -1549- DISPLAY 'R1210-00 - PROBLEMAS UPDATE CLIENTE' */
                    _.Display($"R1210-00 - PROBLEMAS UPDATE CLIENTE");

                    /*" -1550- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1551- END-IF */
                }


                /*" -1553- END-IF. */
            }


            /*" -1555- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -1555- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1210-00-TRATA-DT-NASC-DB-UPDATE-1 */
        public void R1210_00_TRATA_DT_NASC_DB_UPDATE_1()
        {
            /*" -1542- EXEC SQL UPDATE SEGUROS.CLIENTES SET DATA_NASCIMENTO = :CLIENTES-DATA-NASCIMENTO WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE END-EXEC. */

            var r1210_00_TRATA_DT_NASC_DB_UPDATE_1_Update1 = new R1210_00_TRATA_DT_NASC_DB_UPDATE_1_Update1()
            {
                CLIENTES_DATA_NASCIMENTO = CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            R1210_00_TRATA_DT_NASC_DB_UPDATE_1_Update1.Execute(r1210_00_TRATA_DT_NASC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1220-00-TRATA-SEXO-SECTION */
        private void R1220_00_TRATA_SEXO_SECTION()
        {
            /*" -1567- MOVE '1220' TO WNR-EXEC-SQL. */
            _.Move("1220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1570- MOVE SPACES TO WSHOST-PARAM. */
            _.Move("", WSHOST_PARAM);

            /*" -1573- MOVE DT-VAL-ATRIBUTO (1:1) TO WSHOST-PARAM. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 1), WSHOST_PARAM);

            /*" -1574- IF WSHOST-PARAM EQUAL SPACES */

            if (WSHOST_PARAM.IsEmpty())
            {

                /*" -1576- GO TO R1220-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1577- IF WSHOST-PARAM (1:1) NOT EQUAL '1' AND '2' */

            if (!WSHOST_PARAM.Substring(1, 1).In("1", "2"))
            {

                /*" -1579- GO TO R1220-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1582- MOVE SPACES TO CLIENTES-IDE-SEXO. */
            _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);

            /*" -1583- IF WSHOST-PARAM (1:1) EQUAL '1' */

            if (WSHOST_PARAM.Substring(1, 1) == "1")
            {

                /*" -1585- MOVE 'M' TO CLIENTES-IDE-SEXO */
                _.Move("M", CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);

                /*" -1586- ELSE */
            }
            else
            {


                /*" -1588- MOVE 'F' TO CLIENTES-IDE-SEXO */
                _.Move("F", CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);

                /*" -1590- END-IF. */
            }


            /*" -1594- PERFORM R1220_00_TRATA_SEXO_DB_UPDATE_1 */

            R1220_00_TRATA_SEXO_DB_UPDATE_1();

            /*" -1597- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1598- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1599- GO TO R1220-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/ //GOTO
                    return;

                    /*" -1600- ELSE */
                }
                else
                {


                    /*" -1601- DISPLAY 'R1220-00 - PROBLEMAS UPDATE CLIENTE' */
                    _.Display($"R1220-00 - PROBLEMAS UPDATE CLIENTE");

                    /*" -1602- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1603- END-IF */
                }


                /*" -1605- END-IF. */
            }


            /*" -1607- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -1607- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1220-00-TRATA-SEXO-DB-UPDATE-1 */
        public void R1220_00_TRATA_SEXO_DB_UPDATE_1()
        {
            /*" -1594- EXEC SQL UPDATE SEGUROS.CLIENTES SET IDE_SEXO = :CLIENTES-IDE-SEXO WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE END-EXEC. */

            var r1220_00_TRATA_SEXO_DB_UPDATE_1_Update1 = new R1220_00_TRATA_SEXO_DB_UPDATE_1_Update1()
            {
                CLIENTES_IDE_SEXO = CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            R1220_00_TRATA_SEXO_DB_UPDATE_1_Update1.Execute(r1220_00_TRATA_SEXO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/

        [StopWatch]
        /*" R1230-00-TRATA-EST-CIVIL-SECTION */
        private void R1230_00_TRATA_EST_CIVIL_SECTION()
        {
            /*" -1620- MOVE '1230' TO WNR-EXEC-SQL. */
            _.Move("1230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1623- MOVE SPACES TO WSHOST-PARAM. */
            _.Move("", WSHOST_PARAM);

            /*" -1626- MOVE DT-VAL-ATRIBUTO (1:1) TO WSHOST-PARAM. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 1), WSHOST_PARAM);

            /*" -1627- IF WSHOST-PARAM EQUAL SPACES */

            if (WSHOST_PARAM.IsEmpty())
            {

                /*" -1629- GO TO R1230-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1230_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1632- MOVE SPACES TO CLIENTES-ESTADO-CIVIL. */
            _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_ESTADO_CIVIL);

            /*" -1635- MOVE WSHOST-PARAM (1:1) TO CLIENTES-ESTADO-CIVIL. */
            _.Move(WSHOST_PARAM.Substring(1, 1), CLIENTES.DCLCLIENTES.CLIENTES_ESTADO_CIVIL);

            /*" -1639- PERFORM R1230_00_TRATA_EST_CIVIL_DB_UPDATE_1 */

            R1230_00_TRATA_EST_CIVIL_DB_UPDATE_1();

            /*" -1642- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1643- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1644- GO TO R1230-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1230_99_SAIDA*/ //GOTO
                    return;

                    /*" -1645- ELSE */
                }
                else
                {


                    /*" -1646- DISPLAY 'R1230-00 - PROBLEMAS UPDATE CLIENTE' */
                    _.Display($"R1230-00 - PROBLEMAS UPDATE CLIENTE");

                    /*" -1647- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1648- END-IF */
                }


                /*" -1650- END-IF. */
            }


            /*" -1652- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -1652- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1230-00-TRATA-EST-CIVIL-DB-UPDATE-1 */
        public void R1230_00_TRATA_EST_CIVIL_DB_UPDATE_1()
        {
            /*" -1639- EXEC SQL UPDATE SEGUROS.CLIENTES SET ESTADO_CIVIL = :CLIENTES-ESTADO-CIVIL WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE END-EXEC. */

            var r1230_00_TRATA_EST_CIVIL_DB_UPDATE_1_Update1 = new R1230_00_TRATA_EST_CIVIL_DB_UPDATE_1_Update1()
            {
                CLIENTES_ESTADO_CIVIL = CLIENTES.DCLCLIENTES.CLIENTES_ESTADO_CIVIL.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            R1230_00_TRATA_EST_CIVIL_DB_UPDATE_1_Update1.Execute(r1230_00_TRATA_EST_CIVIL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1230_99_SAIDA*/

        [StopWatch]
        /*" R1240-00-TRATA-ENDERECO-SECTION */
        private void R1240_00_TRATA_ENDERECO_SECTION()
        {
            /*" -1664- MOVE '1240' TO WNR-EXEC-SQL. */
            _.Move("1240", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1667- MOVE SPACES TO WSHOST-PARAM. */
            _.Move("", WSHOST_PARAM);

            /*" -1670- MOVE DT-VAL-ATRIBUTO (1:57) TO WSHOST-PARAM. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 57), WSHOST_PARAM);

            /*" -1671- IF WSHOST-PARAM EQUAL SPACES */

            if (WSHOST_PARAM.IsEmpty())
            {

                /*" -1673- GO TO R1240-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1240_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1676- MOVE SPACES TO ENDERECO-ENDERECO. */
            _.Move("", ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);

            /*" -1679- MOVE WSHOST-PARAM (1:57) TO ENDERECO-ENDERECO. */
            _.Move(WSHOST_PARAM.Substring(1, 57), ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);

            /*" -1684- PERFORM R1240_00_TRATA_ENDERECO_DB_UPDATE_1 */

            R1240_00_TRATA_ENDERECO_DB_UPDATE_1();

            /*" -1687- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1688- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1689- GO TO R1240-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1240_99_SAIDA*/ //GOTO
                    return;

                    /*" -1690- ELSE */
                }
                else
                {


                    /*" -1691- DISPLAY 'R1240-00 - PROBLEMAS UPDATE ENDERECO' */
                    _.Display($"R1240-00 - PROBLEMAS UPDATE ENDERECO");

                    /*" -1692- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1693- END-IF */
                }


                /*" -1695- END-IF. */
            }


            /*" -1697- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -1697- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1240-00-TRATA-ENDERECO-DB-UPDATE-1 */
        public void R1240_00_TRATA_ENDERECO_DB_UPDATE_1()
        {
            /*" -1684- EXEC SQL UPDATE SEGUROS.ENDERECOS SET ENDERECO = :ENDERECO-ENDERECO WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE AND OCORR_ENDERECO = :PROPOVA-OCOREND END-EXEC. */

            var r1240_00_TRATA_ENDERECO_DB_UPDATE_1_Update1 = new R1240_00_TRATA_ENDERECO_DB_UPDATE_1_Update1()
            {
                ENDERECO_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
                PROPOVA_OCOREND = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND.ToString(),
            };

            R1240_00_TRATA_ENDERECO_DB_UPDATE_1_Update1.Execute(r1240_00_TRATA_ENDERECO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1240_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-TRATA-BAIRRO-SECTION */
        private void R1250_00_TRATA_BAIRRO_SECTION()
        {
            /*" -1709- MOVE '1250' TO WNR-EXEC-SQL. */
            _.Move("1250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1712- MOVE SPACES TO WSHOST-PARAM. */
            _.Move("", WSHOST_PARAM);

            /*" -1715- MOVE DT-VAL-ATRIBUTO (1:57) TO WSHOST-PARAM. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 57), WSHOST_PARAM);

            /*" -1716- IF WSHOST-PARAM EQUAL SPACES */

            if (WSHOST_PARAM.IsEmpty())
            {

                /*" -1718- GO TO R1250-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1721- MOVE SPACES TO ENDERECO-BAIRRO. */
            _.Move("", ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);

            /*" -1724- MOVE WSHOST-PARAM (1:57) TO ENDERECO-BAIRRO. */
            _.Move(WSHOST_PARAM.Substring(1, 57), ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);

            /*" -1729- PERFORM R1250_00_TRATA_BAIRRO_DB_UPDATE_1 */

            R1250_00_TRATA_BAIRRO_DB_UPDATE_1();

            /*" -1732- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1733- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1734- GO TO R1250-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/ //GOTO
                    return;

                    /*" -1735- ELSE */
                }
                else
                {


                    /*" -1736- DISPLAY 'R1250-00 - PROBLEMAS UPDATE ENDERECO' */
                    _.Display($"R1250-00 - PROBLEMAS UPDATE ENDERECO");

                    /*" -1737- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1738- END-IF */
                }


                /*" -1740- END-IF. */
            }


            /*" -1742- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -1742- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1250-00-TRATA-BAIRRO-DB-UPDATE-1 */
        public void R1250_00_TRATA_BAIRRO_DB_UPDATE_1()
        {
            /*" -1729- EXEC SQL UPDATE SEGUROS.ENDERECOS SET BAIRRO = :ENDERECO-BAIRRO WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE AND OCORR_ENDERECO = :PROPOVA-OCOREND END-EXEC. */

            var r1250_00_TRATA_BAIRRO_DB_UPDATE_1_Update1 = new R1250_00_TRATA_BAIRRO_DB_UPDATE_1_Update1()
            {
                ENDERECO_BAIRRO = ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
                PROPOVA_OCOREND = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND.ToString(),
            };

            R1250_00_TRATA_BAIRRO_DB_UPDATE_1_Update1.Execute(r1250_00_TRATA_BAIRRO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R1260-00-TRATA-CIDADE-SECTION */
        private void R1260_00_TRATA_CIDADE_SECTION()
        {
            /*" -1754- MOVE '1260' TO WNR-EXEC-SQL. */
            _.Move("1260", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1757- MOVE SPACES TO WSHOST-PARAM. */
            _.Move("", WSHOST_PARAM);

            /*" -1760- MOVE DT-VAL-ATRIBUTO (1:57) TO WSHOST-PARAM. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 57), WSHOST_PARAM);

            /*" -1761- IF WSHOST-PARAM EQUAL SPACES */

            if (WSHOST_PARAM.IsEmpty())
            {

                /*" -1763- GO TO R1260-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1260_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1766- MOVE SPACES TO ENDERECO-CIDADE. */
            _.Move("", ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);

            /*" -1769- MOVE WSHOST-PARAM (1:57) TO ENDERECO-CIDADE. */
            _.Move(WSHOST_PARAM.Substring(1, 57), ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);

            /*" -1774- PERFORM R1260_00_TRATA_CIDADE_DB_UPDATE_1 */

            R1260_00_TRATA_CIDADE_DB_UPDATE_1();

            /*" -1777- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1778- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1779- GO TO R1260-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1260_99_SAIDA*/ //GOTO
                    return;

                    /*" -1780- ELSE */
                }
                else
                {


                    /*" -1781- DISPLAY 'R1260-00 - PROBLEMAS UPDATE ENDERECO' */
                    _.Display($"R1260-00 - PROBLEMAS UPDATE ENDERECO");

                    /*" -1782- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1783- END-IF */
                }


                /*" -1785- END-IF. */
            }


            /*" -1787- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -1787- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1260-00-TRATA-CIDADE-DB-UPDATE-1 */
        public void R1260_00_TRATA_CIDADE_DB_UPDATE_1()
        {
            /*" -1774- EXEC SQL UPDATE SEGUROS.ENDERECOS SET CIDADE = :ENDERECO-CIDADE WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE AND OCORR_ENDERECO = :PROPOVA-OCOREND END-EXEC. */

            var r1260_00_TRATA_CIDADE_DB_UPDATE_1_Update1 = new R1260_00_TRATA_CIDADE_DB_UPDATE_1_Update1()
            {
                ENDERECO_CIDADE = ENDERECO.DCLENDERECOS.ENDERECO_CIDADE.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
                PROPOVA_OCOREND = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND.ToString(),
            };

            R1260_00_TRATA_CIDADE_DB_UPDATE_1_Update1.Execute(r1260_00_TRATA_CIDADE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1260_99_SAIDA*/

        [StopWatch]
        /*" R1270-00-TRATA-UF-SECTION */
        private void R1270_00_TRATA_UF_SECTION()
        {
            /*" -1799- MOVE '1270' TO WNR-EXEC-SQL. */
            _.Move("1270", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1802- MOVE SPACES TO WSHOST-PARAM. */
            _.Move("", WSHOST_PARAM);

            /*" -1805- MOVE DT-VAL-ATRIBUTO (1:2) TO WSHOST-PARAM. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 2), WSHOST_PARAM);

            /*" -1806- IF WSHOST-PARAM EQUAL SPACES */

            if (WSHOST_PARAM.IsEmpty())
            {

                /*" -1808- GO TO R1270-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1270_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1811- MOVE SPACES TO ENDERECO-SIGLA-UF. */
            _.Move("", ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);

            /*" -1814- MOVE WSHOST-PARAM (1:2) TO ENDERECO-SIGLA-UF. */
            _.Move(WSHOST_PARAM.Substring(1, 2), ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);

            /*" -1819- PERFORM R1270_00_TRATA_UF_DB_UPDATE_1 */

            R1270_00_TRATA_UF_DB_UPDATE_1();

            /*" -1822- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1823- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1824- GO TO R1270-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1270_99_SAIDA*/ //GOTO
                    return;

                    /*" -1825- ELSE */
                }
                else
                {


                    /*" -1826- DISPLAY 'R1270-00 - PROBLEMAS UPDATE ENDERECO' */
                    _.Display($"R1270-00 - PROBLEMAS UPDATE ENDERECO");

                    /*" -1827- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1828- END-IF */
                }


                /*" -1830- END-IF. */
            }


            /*" -1832- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -1832- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1270-00-TRATA-UF-DB-UPDATE-1 */
        public void R1270_00_TRATA_UF_DB_UPDATE_1()
        {
            /*" -1819- EXEC SQL UPDATE SEGUROS.ENDERECOS SET SIGLA_UF = :ENDERECO-SIGLA-UF WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE AND OCORR_ENDERECO = :PROPOVA-OCOREND END-EXEC. */

            var r1270_00_TRATA_UF_DB_UPDATE_1_Update1 = new R1270_00_TRATA_UF_DB_UPDATE_1_Update1()
            {
                ENDERECO_SIGLA_UF = ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
                PROPOVA_OCOREND = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND.ToString(),
            };

            R1270_00_TRATA_UF_DB_UPDATE_1_Update1.Execute(r1270_00_TRATA_UF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1270_99_SAIDA*/

        [StopWatch]
        /*" R1280-00-TRATA-CEP-SECTION */
        private void R1280_00_TRATA_CEP_SECTION()
        {
            /*" -1844- MOVE '1280' TO WNR-EXEC-SQL. */
            _.Move("1280", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1847- MOVE ZEROS TO WSHOST-CEP. */
            _.Move(0, WSHOST_CEP);

            /*" -1850- MOVE DT-VAL-ATRIBUTO (1:8) TO WSHOST-CEP. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 8), WSHOST_CEP);

            /*" -1851- IF WSHOST-CEP EQUAL ZEROS */

            if (WSHOST_CEP == 00)
            {

                /*" -1853- GO TO R1280-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1280_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1856- MOVE ZEROS TO ENDERECO-CEP. */
            _.Move(0, ENDERECO.DCLENDERECOS.ENDERECO_CEP);

            /*" -1859- MOVE WSHOST-CEP TO ENDERECO-CEP. */
            _.Move(WSHOST_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);

            /*" -1864- PERFORM R1280_00_TRATA_CEP_DB_UPDATE_1 */

            R1280_00_TRATA_CEP_DB_UPDATE_1();

            /*" -1867- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1868- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1869- GO TO R1280-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1280_99_SAIDA*/ //GOTO
                    return;

                    /*" -1870- ELSE */
                }
                else
                {


                    /*" -1871- DISPLAY 'R1280-00 - PROBLEMAS UPDATE ENDERECO' */
                    _.Display($"R1280-00 - PROBLEMAS UPDATE ENDERECO");

                    /*" -1872- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1873- END-IF */
                }


                /*" -1875- END-IF. */
            }


            /*" -1877- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -1877- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1280-00-TRATA-CEP-DB-UPDATE-1 */
        public void R1280_00_TRATA_CEP_DB_UPDATE_1()
        {
            /*" -1864- EXEC SQL UPDATE SEGUROS.ENDERECOS SET CEP = :ENDERECO-CEP WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE AND OCORR_ENDERECO = :PROPOVA-OCOREND END-EXEC. */

            var r1280_00_TRATA_CEP_DB_UPDATE_1_Update1 = new R1280_00_TRATA_CEP_DB_UPDATE_1_Update1()
            {
                ENDERECO_CEP = ENDERECO.DCLENDERECOS.ENDERECO_CEP.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
                PROPOVA_OCOREND = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND.ToString(),
            };

            R1280_00_TRATA_CEP_DB_UPDATE_1_Update1.Execute(r1280_00_TRATA_CEP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1280_99_SAIDA*/

        [StopWatch]
        /*" R1290-00-TRATA-AGENCIA-SECTION */
        private void R1290_00_TRATA_AGENCIA_SECTION()
        {
            /*" -1889- MOVE '1290' TO WNR-EXEC-SQL. */
            _.Move("1290", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1892- MOVE ZEROS TO WSHOST-AGENCIA. */
            _.Move(0, WSHOST_AGENCIA);

            /*" -1895- MOVE DT-VAL-ATRIBUTO (1:4) TO WSHOST-AGENCIA. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 4), WSHOST_AGENCIA);

            /*" -1899- MOVE ZEROS TO PROPOVA-COD-AGE-VENDEDOR OPCPAGVI-COD-AGENCIA-DEBITO. */
            _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_AGE_VENDEDOR, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);

            /*" -1900- IF WSHOST-AGENCIA EQUAL ZEROS */

            if (WSHOST_AGENCIA == 00)
            {

                /*" -1902- GO TO R1290-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1290_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1905- MOVE SPACES TO WSHOST-EXISTE-CONTA. */
            _.Move("", WSHOST_EXISTE_CONTA);

            /*" -1909- MOVE WSHOST-AGENCIA TO PROPOVA-COD-AGE-VENDEDOR OPCPAGVI-COD-AGENCIA-DEBITO. */
            _.Move(WSHOST_AGENCIA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_AGE_VENDEDOR, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);

            /*" -1913- PERFORM R1290_00_TRATA_AGENCIA_DB_UPDATE_1 */

            R1290_00_TRATA_AGENCIA_DB_UPDATE_1();

            /*" -1916- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1917- DISPLAY 'R1290-00 - PROBLEMAS UPDATE PROPOVA' */
                _.Display($"R1290-00 - PROBLEMAS UPDATE PROPOVA");

                /*" -1918- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1935- END-IF. */
            }


            /*" -1942- PERFORM R1290_00_TRATA_AGENCIA_DB_SELECT_1 */

            R1290_00_TRATA_AGENCIA_DB_SELECT_1();

            /*" -1945- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1947- MOVE 'S' TO WS-ALTERA-CONTA */
                _.Move("S", AREA_DE_WORK.WS_ALTERA_CONTA);

                /*" -1949- END-IF. */
            }


            /*" -1951- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -1951- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1290-00-TRATA-AGENCIA-DB-UPDATE-1 */
        public void R1290_00_TRATA_AGENCIA_DB_UPDATE_1()
        {
            /*" -1913- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET COD_AGE_VENDEDOR = :PROPOVA-COD-AGE-VENDEDOR WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1290_00_TRATA_AGENCIA_DB_UPDATE_1_Update1 = new R1290_00_TRATA_AGENCIA_DB_UPDATE_1_Update1()
            {
                PROPOVA_COD_AGE_VENDEDOR = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_AGE_VENDEDOR.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1290_00_TRATA_AGENCIA_DB_UPDATE_1_Update1.Execute(r1290_00_TRATA_AGENCIA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1290-00-TRATA-AGENCIA-DB-SELECT-1 */
        public void R1290_00_TRATA_AGENCIA_DB_SELECT_1()
        {
            /*" -1942- EXEC SQL SELECT '1' INTO :WSHOST-EXISTE-CONTA FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r1290_00_TRATA_AGENCIA_DB_SELECT_1_Query1 = new R1290_00_TRATA_AGENCIA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1290_00_TRATA_AGENCIA_DB_SELECT_1_Query1.Execute(r1290_00_TRATA_AGENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WSHOST_EXISTE_CONTA, WSHOST_EXISTE_CONTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1290_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-TRATA-OPERACAO-SECTION */
        private void R1300_00_TRATA_OPERACAO_SECTION()
        {
            /*" -1963- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1967- MOVE ZEROS TO WSHOST-OPERACAO. */
            _.Move(0, WSHOST_OPERACAO);

            /*" -1970- MOVE DT-VAL-ATRIBUTO (1:4) TO WSHOST-OPERACAO. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 4), WSHOST_OPERACAO);

            /*" -1977- MOVE ZEROS TO PROPOVA-OPE-CONTA-VENDEDOR OPCPAGVI-OPE-CONTA-DEBITO. */
            _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPE_CONTA_VENDEDOR, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);

            /*" -1980- MOVE SPACES TO WSHOST-EXISTE-CONTA. */
            _.Move("", WSHOST_EXISTE_CONTA);

            /*" -1984- MOVE WSHOST-OPERACAO TO PROPOVA-OPE-CONTA-VENDEDOR OPCPAGVI-OPE-CONTA-DEBITO. */
            _.Move(WSHOST_OPERACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPE_CONTA_VENDEDOR, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);

            /*" -1988- PERFORM R1300_00_TRATA_OPERACAO_DB_UPDATE_1 */

            R1300_00_TRATA_OPERACAO_DB_UPDATE_1();

            /*" -1991- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1992- DISPLAY 'R1300-00 - PROBLEMAS UPDATE PROPOVA' */
                _.Display($"R1300-00 - PROBLEMAS UPDATE PROPOVA");

                /*" -1993- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2010- END-IF. */
            }


            /*" -2017- PERFORM R1300_00_TRATA_OPERACAO_DB_SELECT_1 */

            R1300_00_TRATA_OPERACAO_DB_SELECT_1();

            /*" -2020- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2022- MOVE 'S' TO WS-ALTERA-CONTA */
                _.Move("S", AREA_DE_WORK.WS_ALTERA_CONTA);

                /*" -2024- END-IF. */
            }


            /*" -2026- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -2026- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1300-00-TRATA-OPERACAO-DB-UPDATE-1 */
        public void R1300_00_TRATA_OPERACAO_DB_UPDATE_1()
        {
            /*" -1988- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET OPE_CONTA_VENDEDOR = :PROPOVA-OPE-CONTA-VENDEDOR WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1300_00_TRATA_OPERACAO_DB_UPDATE_1_Update1 = new R1300_00_TRATA_OPERACAO_DB_UPDATE_1_Update1()
            {
                PROPOVA_OPE_CONTA_VENDEDOR = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPE_CONTA_VENDEDOR.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1300_00_TRATA_OPERACAO_DB_UPDATE_1_Update1.Execute(r1300_00_TRATA_OPERACAO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1300-00-TRATA-OPERACAO-DB-SELECT-1 */
        public void R1300_00_TRATA_OPERACAO_DB_SELECT_1()
        {
            /*" -2017- EXEC SQL SELECT '1' INTO :WSHOST-EXISTE-CONTA FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r1300_00_TRATA_OPERACAO_DB_SELECT_1_Query1 = new R1300_00_TRATA_OPERACAO_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1300_00_TRATA_OPERACAO_DB_SELECT_1_Query1.Execute(r1300_00_TRATA_OPERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WSHOST_EXISTE_CONTA, WSHOST_EXISTE_CONTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1310-00-TRATA-CONTA-SECTION */
        private void R1310_00_TRATA_CONTA_SECTION()
        {
            /*" -2038- MOVE '1310' TO WNR-EXEC-SQL. */
            _.Move("1310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2042- MOVE ZEROS TO WSHOST-CONTA. */
            _.Move(0, WSHOST_CONTA);

            /*" -2045- MOVE DT-VAL-ATRIBUTO (1:12) TO WSHOST-CONTA. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 12), WSHOST_CONTA);

            /*" -2049- MOVE ZEROS TO PROPOVA-NUM-CONTA-VENDEDOR OPCPAGVI-NUM-CONTA-DEBITO. */
            _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CONTA_VENDEDOR, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);

            /*" -2050- IF WSHOST-CONTA EQUAL ZEROS */

            if (WSHOST_CONTA == 00)
            {

                /*" -2052- GO TO R1310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2055- MOVE SPACES TO WSHOST-EXISTE-CONTA. */
            _.Move("", WSHOST_EXISTE_CONTA);

            /*" -2059- MOVE WSHOST-CONTA TO PROPOVA-NUM-CONTA-VENDEDOR OPCPAGVI-NUM-CONTA-DEBITO. */
            _.Move(WSHOST_CONTA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CONTA_VENDEDOR, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);

            /*" -2063- PERFORM R1310_00_TRATA_CONTA_DB_UPDATE_1 */

            R1310_00_TRATA_CONTA_DB_UPDATE_1();

            /*" -2066- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2067- DISPLAY 'R1310-00 - PROBLEMAS UPDATE PROPOVA' */
                _.Display($"R1310-00 - PROBLEMAS UPDATE PROPOVA");

                /*" -2068- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2086- END-IF. */
            }


            /*" -2093- PERFORM R1310_00_TRATA_CONTA_DB_SELECT_1 */

            R1310_00_TRATA_CONTA_DB_SELECT_1();

            /*" -2096- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2098- MOVE 'S' TO WS-ALTERA-CONTA */
                _.Move("S", AREA_DE_WORK.WS_ALTERA_CONTA);

                /*" -2100- END-IF. */
            }


            /*" -2102- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -2102- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1310-00-TRATA-CONTA-DB-UPDATE-1 */
        public void R1310_00_TRATA_CONTA_DB_UPDATE_1()
        {
            /*" -2063- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET NUM_CONTA_VENDEDOR = :PROPOVA-NUM-CONTA-VENDEDOR WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1310_00_TRATA_CONTA_DB_UPDATE_1_Update1 = new R1310_00_TRATA_CONTA_DB_UPDATE_1_Update1()
            {
                PROPOVA_NUM_CONTA_VENDEDOR = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CONTA_VENDEDOR.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1310_00_TRATA_CONTA_DB_UPDATE_1_Update1.Execute(r1310_00_TRATA_CONTA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1310-00-TRATA-CONTA-DB-SELECT-1 */
        public void R1310_00_TRATA_CONTA_DB_SELECT_1()
        {
            /*" -2093- EXEC SQL SELECT '1' INTO :WSHOST-EXISTE-CONTA FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r1310_00_TRATA_CONTA_DB_SELECT_1_Query1 = new R1310_00_TRATA_CONTA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1310_00_TRATA_CONTA_DB_SELECT_1_Query1.Execute(r1310_00_TRATA_CONTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WSHOST_EXISTE_CONTA, WSHOST_EXISTE_CONTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1310_99_SAIDA*/

        [StopWatch]
        /*" R1320-00-TRATA-DV-SECTION */
        private void R1320_00_TRATA_DV_SECTION()
        {
            /*" -2115- MOVE '1320' TO WNR-EXEC-SQL. */
            _.Move("1320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2118- MOVE ZEROS TO WSHOST-DV. */
            _.Move(0, WSHOST_DV);

            /*" -2121- MOVE DT-VAL-ATRIBUTO (1:1) TO WSHOST-DV. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 1), WSHOST_DV);

            /*" -2125- MOVE ZEROS TO PROPOVA-DIG-CONTA-VENDEDOR OPCPAGVI-DIG-CONTA-DEBITO. */
            _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DIG_CONTA_VENDEDOR, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);

            /*" -2126- IF WSHOST-DV EQUAL ZEROS */

            if (WSHOST_DV == 00)
            {

                /*" -2128- GO TO R1320-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1320_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2131- MOVE SPACES TO WSHOST-EXISTE-CONTA. */
            _.Move("", WSHOST_EXISTE_CONTA);

            /*" -2135- MOVE WSHOST-DV TO PROPOVA-DIG-CONTA-VENDEDOR OPCPAGVI-DIG-CONTA-DEBITO. */
            _.Move(WSHOST_DV, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DIG_CONTA_VENDEDOR, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);

            /*" -2139- PERFORM R1320_00_TRATA_DV_DB_UPDATE_1 */

            R1320_00_TRATA_DV_DB_UPDATE_1();

            /*" -2142- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2143- DISPLAY 'R1320-00 - PROBLEMAS UPDATE PROPOVA' */
                _.Display($"R1320-00 - PROBLEMAS UPDATE PROPOVA");

                /*" -2144- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2162- END-IF. */
            }


            /*" -2169- PERFORM R1320_00_TRATA_DV_DB_SELECT_1 */

            R1320_00_TRATA_DV_DB_SELECT_1();

            /*" -2172- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2174- MOVE 'S' TO WS-ALTERA-CONTA */
                _.Move("S", AREA_DE_WORK.WS_ALTERA_CONTA);

                /*" -2176- END-IF. */
            }


            /*" -2178- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -2178- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1320-00-TRATA-DV-DB-UPDATE-1 */
        public void R1320_00_TRATA_DV_DB_UPDATE_1()
        {
            /*" -2139- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET DIG_CONTA_VENDEDOR = :PROPOVA-DIG-CONTA-VENDEDOR WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1320_00_TRATA_DV_DB_UPDATE_1_Update1 = new R1320_00_TRATA_DV_DB_UPDATE_1_Update1()
            {
                PROPOVA_DIG_CONTA_VENDEDOR = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DIG_CONTA_VENDEDOR.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1320_00_TRATA_DV_DB_UPDATE_1_Update1.Execute(r1320_00_TRATA_DV_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1320-00-TRATA-DV-DB-SELECT-1 */
        public void R1320_00_TRATA_DV_DB_SELECT_1()
        {
            /*" -2169- EXEC SQL SELECT '1' INTO :WSHOST-EXISTE-CONTA FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r1320_00_TRATA_DV_DB_SELECT_1_Query1 = new R1320_00_TRATA_DV_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1320_00_TRATA_DV_DB_SELECT_1_Query1.Execute(r1320_00_TRATA_DV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WSHOST_EXISTE_CONTA, WSHOST_EXISTE_CONTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1320_99_SAIDA*/

        [StopWatch]
        /*" R1325-00-TRATA-RENDA-IND-SECTION */
        private void R1325_00_TRATA_RENDA_IND_SECTION()
        {
            /*" -2191- MOVE '1325' TO WNR-EXEC-SQL. */
            _.Move("1325", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2194- MOVE SPACES TO WSHOST-PARAM. */
            _.Move("", WSHOST_PARAM);

            /*" -2197- MOVE DT-VAL-ATRIBUTO (1:1) TO WSHOST-PARAM. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 1), WSHOST_PARAM);

            /*" -2198- IF WSHOST-PARAM EQUAL SPACES */

            if (WSHOST_PARAM.IsEmpty())
            {

                /*" -2200- GO TO R1325-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1325_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2203- MOVE SPACES TO FAIXA-RENDA-IND. */
            _.Move("", PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_IND);

            /*" -2206- MOVE WSHOST-PARAM (1:1) TO FAIXA-RENDA-IND. */
            _.Move(WSHOST_PARAM.Substring(1, 1), PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_IND);

            /*" -2210- PERFORM R1325_00_TRATA_RENDA_IND_DB_UPDATE_1 */

            R1325_00_TRATA_RENDA_IND_DB_UPDATE_1();

            /*" -2213- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2214- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2215- GO TO R1325-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1325_99_SAIDA*/ //GOTO
                    return;

                    /*" -2216- ELSE */
                }
                else
                {


                    /*" -2217- DISPLAY 'R1325-00 - PROBLEMAS UPDATE PROPFID' */
                    _.Display($"R1325-00 - PROBLEMAS UPDATE PROPFID");

                    /*" -2218- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2219- END-IF */
                }


                /*" -2221- END-IF. */
            }


            /*" -2223- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -2223- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1325-00-TRATA-RENDA-IND-DB-UPDATE-1 */
        public void R1325_00_TRATA_RENDA_IND_DB_UPDATE_1()
        {
            /*" -2210- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET FAIXA_RENDA_IND = :FAIXA-RENDA-IND WHERE NUM_PROPOSTA_SIVPF = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1325_00_TRATA_RENDA_IND_DB_UPDATE_1_Update1 = new R1325_00_TRATA_RENDA_IND_DB_UPDATE_1_Update1()
            {
                FAIXA_RENDA_IND = PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_IND.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1325_00_TRATA_RENDA_IND_DB_UPDATE_1_Update1.Execute(r1325_00_TRATA_RENDA_IND_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1325_99_SAIDA*/

        [StopWatch]
        /*" R1326-00-TRATA-RENDA-FAM-SECTION */
        private void R1326_00_TRATA_RENDA_FAM_SECTION()
        {
            /*" -2235- MOVE '1326' TO WNR-EXEC-SQL. */
            _.Move("1326", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2238- MOVE SPACES TO WSHOST-PARAM. */
            _.Move("", WSHOST_PARAM);

            /*" -2241- MOVE DT-VAL-ATRIBUTO (1:1) TO WSHOST-PARAM. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 1), WSHOST_PARAM);

            /*" -2242- IF WSHOST-PARAM EQUAL SPACES */

            if (WSHOST_PARAM.IsEmpty())
            {

                /*" -2244- GO TO R1325-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1325_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2247- MOVE SPACES TO FAIXA-RENDA-FAM. */
            _.Move("", PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_FAM);

            /*" -2250- MOVE WSHOST-PARAM (1:1) TO FAIXA-RENDA-FAM. */
            _.Move(WSHOST_PARAM.Substring(1, 1), PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_FAM);

            /*" -2254- PERFORM R1326_00_TRATA_RENDA_FAM_DB_UPDATE_1 */

            R1326_00_TRATA_RENDA_FAM_DB_UPDATE_1();

            /*" -2257- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2258- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2259- GO TO R1326-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1326_99_SAIDA*/ //GOTO
                    return;

                    /*" -2260- ELSE */
                }
                else
                {


                    /*" -2261- DISPLAY 'R1326-00 - PROBLEMAS UPDATE PROPFID' */
                    _.Display($"R1326-00 - PROBLEMAS UPDATE PROPFID");

                    /*" -2262- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2263- END-IF */
                }


                /*" -2265- END-IF. */
            }


            /*" -2267- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -2267- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1326-00-TRATA-RENDA-FAM-DB-UPDATE-1 */
        public void R1326_00_TRATA_RENDA_FAM_DB_UPDATE_1()
        {
            /*" -2254- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET FAIXA_RENDA_FAM = :FAIXA-RENDA-FAM WHERE NUM_PROPOSTA_SIVPF = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1326_00_TRATA_RENDA_FAM_DB_UPDATE_1_Update1 = new R1326_00_TRATA_RENDA_FAM_DB_UPDATE_1_Update1()
            {
                FAIXA_RENDA_FAM = PROPFID.DCLPROPOSTA_FIDELIZ.FAIXA_RENDA_FAM.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1326_00_TRATA_RENDA_FAM_DB_UPDATE_1_Update1.Execute(r1326_00_TRATA_RENDA_FAM_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1326_99_SAIDA*/

        [StopWatch]
        /*" R1330-00-TRATA-DIA-DEB-SECTION */
        private void R1330_00_TRATA_DIA_DEB_SECTION()
        {
            /*" -2280- MOVE '1330' TO WNR-EXEC-SQL. */
            _.Move("1330", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2283- MOVE ZEROS TO WSHOST-DIA-DEB. */
            _.Move(0, WSHOST_DIA_DEB);

            /*" -2286- MOVE SPACES TO WSHOST-EXISTE-CONTA. */
            _.Move("", WSHOST_EXISTE_CONTA);

            /*" -2289- MOVE DT-VAL-ATRIBUTO (1:2) TO WSHOST-DIA-DEB. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 2), WSHOST_DIA_DEB);

            /*" -2292- MOVE ZEROS TO OPCPAGVI-DIA-DEBITO. */
            _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);

            /*" -2293- IF WSHOST-DIA-DEB EQUAL ZEROS */

            if (WSHOST_DIA_DEB == 00)
            {

                /*" -2295- GO TO R1330-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1330_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2313- MOVE WSHOST-DIA-DEB TO OPCPAGVI-DIA-DEBITO. */
            _.Move(WSHOST_DIA_DEB, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);

            /*" -2320- PERFORM R1330_00_TRATA_DIA_DEB_DB_SELECT_1 */

            R1330_00_TRATA_DIA_DEB_DB_SELECT_1();

            /*" -2323- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2324- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2325- GO TO R1330-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1330_99_SAIDA*/ //GOTO
                    return;

                    /*" -2326- ELSE */
                }
                else
                {


                    /*" -2327- DISPLAY 'R1330-00 - PROBLEMAS ACESSO OPCPAG' */
                    _.Display($"R1330-00 - PROBLEMAS ACESSO OPCPAG");

                    /*" -2328- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2329- END-IF */
                }


                /*" -2331- END-IF. */
            }


            /*" -2333- MOVE 'S' TO WS-ALTERA-CONTA. */
            _.Move("S", AREA_DE_WORK.WS_ALTERA_CONTA);

            /*" -2335- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -2335- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1330-00-TRATA-DIA-DEB-DB-SELECT-1 */
        public void R1330_00_TRATA_DIA_DEB_DB_SELECT_1()
        {
            /*" -2320- EXEC SQL SELECT '1' INTO :WSHOST-EXISTE-CONTA FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r1330_00_TRATA_DIA_DEB_DB_SELECT_1_Query1 = new R1330_00_TRATA_DIA_DEB_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1330_00_TRATA_DIA_DEB_DB_SELECT_1_Query1.Execute(r1330_00_TRATA_DIA_DEB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WSHOST_EXISTE_CONTA, WSHOST_EXISTE_CONTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1330_99_SAIDA*/

        [StopWatch]
        /*" R1350-00-TRATA-CARTAO-SECTION */
        private void R1350_00_TRATA_CARTAO_SECTION()
        {
            /*" -2407- MOVE '1350' TO WNR-EXEC-SQL. */
            _.Move("1350", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2410- MOVE ZEROS TO WSHOST-NUM-CARTAO. */
            _.Move(0, WSHOST_NUM_CARTAO);

            /*" -2413- MOVE DT-VAL-ATRIBUTO (1:16) TO WSHOST-NUM-CARTAO. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 16), WSHOST_NUM_CARTAO);

            /*" -2416- MOVE ZEROS TO OPCPAGVI-NUM-CARTAO-CREDITO. */
            _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

            /*" -2417- IF WSHOST-NUM-CARTAO EQUAL ZEROS */

            if (WSHOST_NUM_CARTAO == 00)
            {

                /*" -2419- GO TO R1350-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2422- MOVE SPACES TO WSHOST-EXISTE-CONTA. */
            _.Move("", WSHOST_EXISTE_CONTA);

            /*" -2441- MOVE WSHOST-NUM-CARTAO TO OPCPAGVI-NUM-CARTAO-CREDITO. */
            _.Move(WSHOST_NUM_CARTAO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

            /*" -2448- PERFORM R1350_00_TRATA_CARTAO_DB_SELECT_1 */

            R1350_00_TRATA_CARTAO_DB_SELECT_1();

            /*" -2451- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2452- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2453- GO TO R1350-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_99_SAIDA*/ //GOTO
                    return;

                    /*" -2454- ELSE */
                }
                else
                {


                    /*" -2455- DISPLAY 'R1350-00 - PROBLEMAS ACESSO OPCPAG' */
                    _.Display($"R1350-00 - PROBLEMAS ACESSO OPCPAG");

                    /*" -2456- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2457- END-IF */
                }


                /*" -2459- END-IF. */
            }


            /*" -2461- MOVE 'S' TO WS-ALTERA-CONTA. */
            _.Move("S", AREA_DE_WORK.WS_ALTERA_CONTA);

            /*" -2463- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -2463- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1350-00-TRATA-CARTAO-DB-SELECT-1 */
        public void R1350_00_TRATA_CARTAO_DB_SELECT_1()
        {
            /*" -2448- EXEC SQL SELECT '1' INTO :WSHOST-EXISTE-CONTA FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r1350_00_TRATA_CARTAO_DB_SELECT_1_Query1 = new R1350_00_TRATA_CARTAO_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1350_00_TRATA_CARTAO_DB_SELECT_1_Query1.Execute(r1350_00_TRATA_CARTAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WSHOST_EXISTE_CONTA, WSHOST_EXISTE_CONTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_99_SAIDA*/

        [StopWatch]
        /*" R1360-00-TRATA-DDD-RES-SECTION */
        private void R1360_00_TRATA_DDD_RES_SECTION()
        {
            /*" -2475- MOVE '1360' TO WNR-EXEC-SQL. */
            _.Move("1360", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2478- MOVE ZEROS TO WSHOST-DDD-RES. */
            _.Move(0, WSHOST_DDD_RES);

            /*" -2481- MOVE DT-VAL-ATRIBUTO (1:4) TO WSHOST-DDD-RES. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 4), WSHOST_DDD_RES);

            /*" -2482- IF WSHOST-DDD-RES EQUAL ZEROS */

            if (WSHOST_DDD_RES == 00)
            {

                /*" -2484- GO TO R1360-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1360_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2487- MOVE ZEROS TO ENDERECO-DDD. */
            _.Move(0, ENDERECO.DCLENDERECOS.ENDERECO_DDD);

            /*" -2490- MOVE WSHOST-DDD-RES TO ENDERECO-DDD. */
            _.Move(WSHOST_DDD_RES, ENDERECO.DCLENDERECOS.ENDERECO_DDD);

            /*" -2495- PERFORM R1360_00_TRATA_DDD_RES_DB_UPDATE_1 */

            R1360_00_TRATA_DDD_RES_DB_UPDATE_1();

            /*" -2498- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2499- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2500- GO TO R1360-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1360_99_SAIDA*/ //GOTO
                    return;

                    /*" -2501- ELSE */
                }
                else
                {


                    /*" -2502- DISPLAY 'R1360-00 - PROBLEMAS UPDATE ENDERECO' */
                    _.Display($"R1360-00 - PROBLEMAS UPDATE ENDERECO");

                    /*" -2503- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2504- END-IF */
                }


                /*" -2506- END-IF. */
            }


            /*" -2508- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -2508- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1360-00-TRATA-DDD-RES-DB-UPDATE-1 */
        public void R1360_00_TRATA_DDD_RES_DB_UPDATE_1()
        {
            /*" -2495- EXEC SQL UPDATE SEGUROS.ENDERECOS SET DDD = :ENDERECO-DDD WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE AND OCORR_ENDERECO = :PROPOVA-OCOREND END-EXEC. */

            var r1360_00_TRATA_DDD_RES_DB_UPDATE_1_Update1 = new R1360_00_TRATA_DDD_RES_DB_UPDATE_1_Update1()
            {
                ENDERECO_DDD = ENDERECO.DCLENDERECOS.ENDERECO_DDD.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
                PROPOVA_OCOREND = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND.ToString(),
            };

            R1360_00_TRATA_DDD_RES_DB_UPDATE_1_Update1.Execute(r1360_00_TRATA_DDD_RES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1360_99_SAIDA*/

        [StopWatch]
        /*" R1370-00-TRATA-TEL-RES-SECTION */
        private void R1370_00_TRATA_TEL_RES_SECTION()
        {
            /*" -2520- MOVE '1370' TO WNR-EXEC-SQL. */
            _.Move("1370", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2523- MOVE ZEROS TO WSHOST-TEL-RES. */
            _.Move(0, WSHOST_TEL_RES);

            /*" -2526- MOVE DT-VAL-ATRIBUTO (1:9) TO WSHOST-TEL-RES. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 9), WSHOST_TEL_RES);

            /*" -2527- IF WSHOST-TEL-RES EQUAL ZEROS */

            if (WSHOST_TEL_RES == 00)
            {

                /*" -2529- GO TO R1370-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1370_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2532- MOVE ZEROS TO ENDERECO-TELEFONE. */
            _.Move(0, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);

            /*" -2535- MOVE WSHOST-TEL-RES TO ENDERECO-TELEFONE. */
            _.Move(WSHOST_TEL_RES, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);

            /*" -2540- PERFORM R1370_00_TRATA_TEL_RES_DB_UPDATE_1 */

            R1370_00_TRATA_TEL_RES_DB_UPDATE_1();

            /*" -2543- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2544- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2545- GO TO R1370-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1370_99_SAIDA*/ //GOTO
                    return;

                    /*" -2546- ELSE */
                }
                else
                {


                    /*" -2547- DISPLAY 'R1370-00 - PROBLEMAS UPDATE ENDERECO' */
                    _.Display($"R1370-00 - PROBLEMAS UPDATE ENDERECO");

                    /*" -2548- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2549- END-IF */
                }


                /*" -2551- END-IF. */
            }


            /*" -2553- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -2553- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1370-00-TRATA-TEL-RES-DB-UPDATE-1 */
        public void R1370_00_TRATA_TEL_RES_DB_UPDATE_1()
        {
            /*" -2540- EXEC SQL UPDATE SEGUROS.ENDERECOS SET TELEFONE = :ENDERECO-TELEFONE WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE AND OCORR_ENDERECO = :PROPOVA-OCOREND END-EXEC. */

            var r1370_00_TRATA_TEL_RES_DB_UPDATE_1_Update1 = new R1370_00_TRATA_TEL_RES_DB_UPDATE_1_Update1()
            {
                ENDERECO_TELEFONE = ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
                PROPOVA_OCOREND = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND.ToString(),
            };

            R1370_00_TRATA_TEL_RES_DB_UPDATE_1_Update1.Execute(r1370_00_TRATA_TEL_RES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1370_99_SAIDA*/

        [StopWatch]
        /*" R1380-00-TRATA-EMAIL-SECTION */
        private void R1380_00_TRATA_EMAIL_SECTION()
        {
            /*" -2565- MOVE '1380' TO WNR-EXEC-SQL. */
            _.Move("1380", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2568- MOVE SPACES TO WSHOST-PARAM. */
            _.Move("", WSHOST_PARAM);

            /*" -2571- MOVE DT-VAL-ATRIBUTO (1:40) TO WSHOST-PARAM. */
            _.Move(MOV_REGISTRO_DT.DT_VAL_ATRIBUTO.Substring(1, 40), WSHOST_PARAM);

            /*" -2572- IF WSHOST-PARAM EQUAL SPACES */

            if (WSHOST_PARAM.IsEmpty())
            {

                /*" -2574- GO TO R1380-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1380_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2577- MOVE WSHOST-PARAM (1:40) TO EMAIL OF DCLPESSOA-EMAIL. */
            _.Move(WSHOST_PARAM.Substring(1, 40), PESEMAIL.DCLPESSOA_EMAIL.EMAIL);

            /*" -2581- PERFORM R1380_00_TRATA_EMAIL_DB_UPDATE_1 */

            R1380_00_TRATA_EMAIL_DB_UPDATE_1();

            /*" -2584- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2585- DISPLAY 'R1380-00 - PROBLEMAS UPDATE PESEMAIL' */
                _.Display($"R1380-00 - PROBLEMAS UPDATE PESEMAIL");

                /*" -2586- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2588- END-IF. */
            }


            /*" -2589- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2603- PERFORM R1380_00_TRATA_EMAIL_DB_INSERT_1 */

                R1380_00_TRATA_EMAIL_DB_INSERT_1();

                /*" -2605- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2606- GO TO R1380-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1380_99_SAIDA*/ //GOTO
                    return;

                    /*" -2607- END-IF */
                }


                /*" -2609- END-IF. */
            }


            /*" -2611- ADD 1 TO AC-ALTERADOS AC-PROCESSADO. */
            AREA_DE_WORK.AC_ALTERADOS.Value = AREA_DE_WORK.AC_ALTERADOS + 1;
            AREA_DE_WORK.AC_PROCESSADO.Value = AREA_DE_WORK.AC_PROCESSADO + 1;

            /*" -2611- MOVE ZEROS TO DT-COD-RETORNO. */
            _.Move(0, MOV_REGISTRO_DT.DT_COD_RETORNO);

        }

        [StopWatch]
        /*" R1380-00-TRATA-EMAIL-DB-UPDATE-1 */
        public void R1380_00_TRATA_EMAIL_DB_UPDATE_1()
        {
            /*" -2581- EXEC SQL UPDATE SEGUROS.PESSOA_EMAIL SET EMAIL = :DCLPESSOA-EMAIL.EMAIL WHERE COD_PESSOA = :PROPOVA-COD-CLIENTE END-EXEC. */

            var r1380_00_TRATA_EMAIL_DB_UPDATE_1_Update1 = new R1380_00_TRATA_EMAIL_DB_UPDATE_1_Update1()
            {
                EMAIL = PESEMAIL.DCLPESSOA_EMAIL.EMAIL.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            R1380_00_TRATA_EMAIL_DB_UPDATE_1_Update1.Execute(r1380_00_TRATA_EMAIL_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1380-00-TRATA-EMAIL-DB-INSERT-1 */
        public void R1380_00_TRATA_EMAIL_DB_INSERT_1()
        {
            /*" -2603- EXEC SQL INSERT INTO SEGUROS.PESSOA_EMAIL ( COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL, COD_USUARIO, TIMESTAMP) VALUES(:PROPOVA-COD-CLIENTE, 1, :DCLPESSOA-EMAIL.EMAIL, 'A' , 'BI0080B' , CURRENT TIMESTAMP) END-EXEC */

            var r1380_00_TRATA_EMAIL_DB_INSERT_1_Insert1 = new R1380_00_TRATA_EMAIL_DB_INSERT_1_Insert1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
                EMAIL = PESEMAIL.DCLPESSOA_EMAIL.EMAIL.ToString(),
            };

            R1380_00_TRATA_EMAIL_DB_INSERT_1_Insert1.Execute(r1380_00_TRATA_EMAIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1380_99_SAIDA*/

        [StopWatch]
        /*" R1390-00-TRATA-INF-CONTA-SECTION */
        private void R1390_00_TRATA_INF_CONTA_SECTION()
        {
            /*" -2623- MOVE '1390' TO WNR-EXEC-SQL. */
            _.Move("1390", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2629- PERFORM R1390_00_TRATA_INF_CONTA_DB_UPDATE_1 */

            R1390_00_TRATA_INF_CONTA_DB_UPDATE_1();

            /*" -2632- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -2633- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2634- GO TO R1390-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1390_99_SAIDA*/ //GOTO
                    return;

                    /*" -2635- ELSE */
                }
                else
                {


                    /*" -2636- DISPLAY 'R1390-00 - PROBLEMAS UPDATE OPCAOPAG' */
                    _.Display($"R1390-00 - PROBLEMAS UPDATE OPCAOPAG");

                    /*" -2637- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2638- END-IF */
                }


                /*" -2640- END-IF. */
            }


            /*" -2695- PERFORM R1390_00_TRATA_INF_CONTA_DB_INSERT_1 */

            R1390_00_TRATA_INF_CONTA_DB_INSERT_1();

            /*" -2698- IF SQLCODE NOT EQUAL ZEROS AND 100 AND -803 */

            if (!DB.SQLCODE.In("00", "100", "-803"))
            {

                /*" -2699- DISPLAY 'R1390-00 - PROBLEMAS INSERT OPCAOPAG' */
                _.Display($"R1390-00 - PROBLEMAS INSERT OPCAOPAG");

                /*" -2700- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2700- END-IF. */
            }


        }

        [StopWatch]
        /*" R1390-00-TRATA-INF-CONTA-DB-UPDATE-1 */
        public void R1390_00_TRATA_INF_CONTA_DB_UPDATE_1()
        {
            /*" -2629- EXEC SQL UPDATE SEGUROS.OPCAO_PAG_VIDAZUL SET DATA_TERVIGENCIA = :V1SIST-DTMOVABE-1, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :WSHOST-NUM-PROPOSTA AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1390_00_TRATA_INF_CONTA_DB_UPDATE_1_Update1 = new R1390_00_TRATA_INF_CONTA_DB_UPDATE_1_Update1()
            {
                V1SIST_DTMOVABE_1 = V1SIST_DTMOVABE_1.ToString(),
                WSHOST_NUM_PROPOSTA = WSHOST_NUM_PROPOSTA.ToString(),
            };

            R1390_00_TRATA_INF_CONTA_DB_UPDATE_1_Update1.Execute(r1390_00_TRATA_INF_CONTA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1390-00-TRATA-INF-CONTA-DB-INSERT-1 */
        public void R1390_00_TRATA_INF_CONTA_DB_INSERT_1()
        {
            /*" -2695- EXEC SQL INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL (NUM_CERTIFICADO, DATA_INIVIGENCIA, DATA_TERVIGENCIA, OPCAO_PAGAMENTO, PERI_PAGAMENTO, DIA_DEBITO, COD_USUARIO, TIMESTAMP, COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO, NUM_CARTAO_CREDITO) SELECT NUM_CERTIFICADO, :V1SIST-DTMOVABE, '9999-12-31' , OPCAO_PAGAMENTO, PERI_PAGAMENTO, CASE WHEN :OPCPAGVI-DIA-DEBITO > 0 THEN :OPCPAGVI-DIA-DEBITO ELSE DIA_DEBITO END, 'VA0280B' , CURRENT TIMESTAMP, CASE WHEN :OPCPAGVI-COD-AGENCIA-DEBITO > 0 THEN :OPCPAGVI-COD-AGENCIA-DEBITO ELSE COD_AGENCIA_DEBITO END, CASE WHEN :OPCPAGVI-OPE-CONTA-DEBITO > 0 THEN :OPCPAGVI-OPE-CONTA-DEBITO ELSE OPE_CONTA_DEBITO END, CASE WHEN :OPCPAGVI-NUM-CONTA-DEBITO > 0 THEN :OPCPAGVI-NUM-CONTA-DEBITO ELSE NUM_CONTA_DEBITO END, CASE WHEN :OPCPAGVI-DIG-CONTA-DEBITO > 0 THEN :OPCPAGVI-DIG-CONTA-DEBITO ELSE DIG_CONTA_DEBITO END, CASE WHEN :OPCPAGVI-NUM-CARTAO-CREDITO > 0 THEN :OPCPAGVI-NUM-CARTAO-CREDITO ELSE NUM_CARTAO_CREDITO END FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :WSHOST-NUM-PROPOSTA AND DATA_TERVIGENCIA = :V1SIST-DTMOVABE-1 END-EXEC. */

            var r1390_00_TRATA_INF_CONTA_DB_INSERT_1_Insert1 = new R1390_00_TRATA_INF_CONTA_DB_INSERT_1_Insert1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                OPCPAGVI_DIA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO.ToString(),
                OPCPAGVI_COD_AGENCIA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO.ToString(),
                OPCPAGVI_OPE_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO.ToString(),
                OPCPAGVI_NUM_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO.ToString(),
                OPCPAGVI_DIG_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO.ToString(),
                OPCPAGVI_NUM_CARTAO_CREDITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO.ToString(),
                WSHOST_NUM_PROPOSTA = WSHOST_NUM_PROPOSTA.ToString(),
                V1SIST_DTMOVABE_1 = V1SIST_DTMOVABE_1.ToString(),
            };

            R1390_00_TRATA_INF_CONTA_DB_INSERT_1_Insert1.Execute(r1390_00_TRATA_INF_CONTA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1390_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-FINAL-SECTION */
        private void R2000_00_PROCESSA_FINAL_SECTION()
        {
            /*" -2713- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2715- COMPUTE AC-QT-TOTAL = AC-QT-APROVADOS + AC-QT-REJEITADOS. */
            AREA_DE_WORK.AC_QT_TOTAL.Value = AREA_DE_WORK.AC_QT_APROVADOS + AREA_DE_WORK.AC_QT_REJEITADOS;

            /*" -2718- COMPUTE AC-VL-TOTAL = AC-VL-APROVADOS + AC-VL-REJEITADOS. */
            AREA_DE_WORK.AC_VL_TOTAL.Value = AREA_DE_WORK.AC_VL_APROVADOS + AREA_DE_WORK.AC_VL_REJEITADOS;

            /*" -2719- IF WTEM-HEADER EQUAL SPACES */

            if (AREA_DE_WORK.WTEM_HEADER.IsEmpty())
            {

                /*" -2721- DISPLAY 'VA0280B - ARQUIVO DA SOER ESTA SEM HEADER  ' ' , IMPOSSIVEL PROSSEGUIR ' */
                _.Display($"VA0280B - ARQUIVO DA SOER ESTA SEM HEADER   , IMPOSSIVEL PROSSEGUIR ");

                /*" -2723- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2724- IF WTEM-TRAILLER EQUAL SPACES */

            if (AREA_DE_WORK.WTEM_TRAILLER.IsEmpty())
            {

                /*" -2726- DISPLAY 'VA0280B - ARQUIVO DA SOER ESTA SEM ' ' TRAILLER, IMPOSSIVEL PROSSEGUIR ' */
                _.Display($"VA0280B - ARQUIVO DA SOER ESTA SEM  TRAILLER, IMPOSSIVEL PROSSEGUIR ");

                /*" -2726- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R2200_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -2740- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2744- MOVE V1SIST-DTMOVABE TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(V1SIST_DTMOVABE, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -2747- MOVE AC-LIDOS TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(AREA_DE_WORK.AC_LIDOS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -2755- PERFORM R2200_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R2200_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -2758- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2759- DISPLAY 'VA0280B - ERRO INSERT ARQUIVOS-SIVPF' */
                _.Display($"VA0280B - ERRO INSERT ARQUIVOS-SIVPF");

                /*" -2761- DISPLAY '          SIGLA DO ARQUIVO .............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQUIVO .............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -2763- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -2765- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -2767- DISPLAY '          QTDE. REGISTROS...............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -2769- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2769- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2200-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R2200_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -2755- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r2200_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1 = new R2200_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R2200_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1.Execute(r2200_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2780- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -2782- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -2785- CLOSE MOVIMENTO RVA0280B. */
            MOVIMENTO.Close();
            RVA0280B.Close();

            /*" -2785- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -2787- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2791- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2791- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}