using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Sias.Cosseguro.DB2.AC0815B;

namespace Code
{
    public class AC0815B
    {
        public bool IsCall { get; set; }

        public AC0815B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  ADMINISTRACAO DE COSSEGURO         *      */
        /*"      *   PROGRAMA ...............  AC0815B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA/PROGRAMADOR....  CARLOS ALBERTO                     *      */
        /*"      *   DATA CODIFICACAO .......  AGOSTO / 1996                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ................. -RESTITUICAO/RECUPERACAO DE COMISSAO*      */
        /*"      *                             PARA DOCUMENTOS COM COMISSAO ACE-  *      */
        /*"      *                             LERADA, CANCELADOS OU REATIVADOS.  *      */
        /*"      *                            -SOLICITACOES PARA PROCESSAMENTO    *      */
        /*"      *                             EFETUADAS PELAS APLICACAO AC19A.   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * RELATORIOS                          V1RELATORIOS      INPUT    *      */
        /*"      * RELATORIOS                          V0RELATORIOS      I-O      *      */
        /*"      * PREMIOS DE COSSEGURO                V1COSSEG_PREM     INPUT    *      */
        /*"      * PREMIOS DE COSSEGURO                V0COSSEG_PREM     I-O      *      */
        /*"      * HISTORICO DE COSSEGURO              V1COSSEG_HISTPRE  INPUT    *      */
        /*"      * HISTORICO DE COSSEGURO              V0COSSEG_HISTPRE  I-O      *      */
        /*"      * ENDOSSOS                            V0ENDOSSO         INPUT    *      */
        /*"      * MOEDA                               V1MOEDA           INPUT    *      */
        /*"      * COTACAO                             V1COTACAO         INPUT    *      */
        /*"      * APOLICES                            V0APOLICE         INPUT    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 21/01/2000 - CARLOS ALBERTO DE A ALVES            *      */
        /*"      * LANCAR A DEBITO O SALDO DOS PREMIOS BAIXADOS/ESTORNADOS,DAS    *      */
        /*"      * APOLICES: 106600000001 E 66001000001, COMO FORMA DE ESTORNO    *      */
        /*"      * DESTE VALOR, DEVIDO AO ENCONTRO DE CONTAS QUE E' FEITO FORA    *      */
        /*"      * DO SISTEMA.                                                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 10/05/2004 - GILSON PINTO DA SILVA                *      */
        /*"      * COLOCAR "ORDER BY" NOS DECLARES PARA ORDENAR OCOR HIST E OPER. *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - PREPARAR A COLUNA CODIGO DE EMPRESA PARA RECEBER  *      */
        /*"      *              A INFORMACAO DO CODIGO CORRESPONDENTE             *      */
        /*"      * 05/10/2018 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 173142 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - ALTERAR O PROGRAMA PARA TRATAR/GERAR A LIBERACAO  *      */
        /*"      *              DE PAGAMENTO POR EMPRESA DO GRUPO CAIXA SEGUROS   *      */
        /*"      * 24/01/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 188194 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         VIND-DAT-QTBC       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis VIND_DAT_QTBC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTQITBCO       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTLIBERA       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis VIND_DTLIBERA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SIT-FINC       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis VIND_SIT_FINC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SIT-LIBR       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis VIND_SIT_LIBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NUM-OCOR       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis VIND_NUM_OCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-QTD-RELAT     PIC S9(004)                COMP.*/
        public IntBasis WHOST_QTD_RELAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-QTD-CONGN     PIC S9(004)                COMP.*/
        public IntBasis WHOST_QTD_CONGN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-QTD-COSCH     PIC S9(004)                COMP.*/
        public IntBasis WHOST_QTD_COSCH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-DTMOVTO       PIC  X(010).*/
        public StringBasis WHOST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTMOVTO-EM    PIC  X(010).*/
        public StringBasis WHOST_DTMOVTO_EM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-OPERACAO      PIC S9(004)                COMP.*/
        public IntBasis WHOST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-VLCRUZAD1     PIC S9(006)V9(9)           COMP-3*/
        public DoubleBasis WHOST_VLCRUZAD1 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77         WHOST-VLCRUZAD2     PIC S9(006)V9(9)           COMP-3*/
        public DoubleBasis WHOST_VLCRUZAD2 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77         WHOST-PRM-TARF      PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_PRM_TARF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VAL-DESC      PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VLPRMLIQ      PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VLADIFRA      PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VLCOMISS      PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VLCOMISS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VLPRMTOT      PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMTAR-IX     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis WHOST_PRMTAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         WHOST-VLDESC-IX     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis WHOST_VLDESC_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         WHOST-PRMLIQ-IX     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis WHOST_PRMLIQ_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         WHOST-ADFRAC-IX     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis WHOST_ADFRAC_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         WHOST-VLCOMS-IX     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis WHOST_VLCOMS_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         WHOST-PRMTOT-IX     PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis WHOST_PRMTOT_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1RELA-COD-USU      PIC  X(008).*/
        public StringBasis V1RELA_COD_USU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1RELA-DATA-SOL     PIC  X(010).*/
        public StringBasis V1RELA_DATA_SOL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1RELA-IDSISTEM     PIC  X(002).*/
        public StringBasis V1RELA_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V1RELA-CODRELAT     PIC  X(008).*/
        public StringBasis V1RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1RELA-PERI-INI     PIC  X(010).*/
        public StringBasis V1RELA_PERI_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1RELA-PERI-FIN     PIC  X(010).*/
        public StringBasis V1RELA_PERI_FIN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1RELA-DATA-REF     PIC  X(010).*/
        public StringBasis V1RELA_DATA_REF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1RELA-CONGENER     PIC S9(004)               COMP.*/
        public IntBasis V1RELA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RELA-CODUNIMO     PIC S9(004)               COMP.*/
        public IntBasis V1RELA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RELA-CORRECAO     PIC  X(001).*/
        public StringBasis V1RELA_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1RELA-COD-EMPR     PIC S9(009)               COMP.*/
        public IntBasis V1RELA_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1CPRE-COD-EMPR     PIC S9(009)               COMP.*/
        public IntBasis V1CPRE_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1CPRE-TIP-SEGU     PIC  X(001).*/
        public StringBasis V1CPRE_TIP_SEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1CPRE-CONGENER     PIC S9(004)               COMP.*/
        public IntBasis V1CPRE_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1CPRE-NUM-ORDEM    PIC S9(015)               COMP-3.*/
        public IntBasis V1CPRE_NUM_ORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1CPRE-NUM-APOL     PIC S9(013)               COMP-3.*/
        public IntBasis V1CPRE_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1CPRE-NUM-ENDS     PIC S9(009)               COMP.*/
        public IntBasis V1CPRE_NUM_ENDS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1CPRE-NRPARCEL     PIC S9(004)               COMP.*/
        public IntBasis V1CPRE_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1CPRE-PRMTAR-IX    PIC S9(010)V9(5)          COMP-3.*/
        public DoubleBasis V1CPRE_PRMTAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1CPRE-VLDESC-IX    PIC S9(010)V9(5)          COMP-3.*/
        public DoubleBasis V1CPRE_VLDESC_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1CPRE-OTNPRLIQ     PIC S9(010)V9(5)          COMP-3.*/
        public DoubleBasis V1CPRE_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1CPRE-OTNADFRA     PIC S9(010)V9(5)          COMP-3.*/
        public DoubleBasis V1CPRE_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1CPRE-VLCOMS-IX    PIC S9(010)V9(5)          COMP-3.*/
        public DoubleBasis V1CPRE_VLCOMS_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1CPRE-OTNTOTAL     PIC S9(010)V9(5)          COMP-3.*/
        public DoubleBasis V1CPRE_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1CPRE-SITUACAO     PIC  X(001).*/
        public StringBasis V1CPRE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1CPRE-SIT-CONG     PIC  X(001).*/
        public StringBasis V1CPRE_SIT_CONG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1CPRE-OCORHIST     PIC S9(004)               COMP.*/
        public IntBasis V1CPRE_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1CHIS-COD-EMPR     PIC S9(009)               COMP.*/
        public IntBasis V1CHIS_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1CHIS-CONGENER     PIC S9(004)               COMP.*/
        public IntBasis V1CHIS_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1CHIS-NUM-APOL     PIC S9(013)               COMP-3.*/
        public IntBasis V1CHIS_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1CHIS-NUM-ENDS     PIC S9(009)               COMP.*/
        public IntBasis V1CHIS_NUM_ENDS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1CHIS-NRPARCEL     PIC S9(004)               COMP.*/
        public IntBasis V1CHIS_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1CHIS-OCORHIST     PIC S9(004)               COMP.*/
        public IntBasis V1CHIS_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1CHIS-OPERACAO     PIC S9(004)               COMP.*/
        public IntBasis V1CHIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1CHIS-DAT-MOVT     PIC  X(010).*/
        public StringBasis V1CHIS_DAT_MOVT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1CHIS-TIP-SEGU     PIC  X(001).*/
        public StringBasis V1CHIS_TIP_SEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1CHIS-PRM-TARF     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V1CHIS_PRM_TARF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1CHIS-VAL-DESC     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V1CHIS_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1CHIS-VLPRMLIQ     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V1CHIS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1CHIS-VLADIFRA     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V1CHIS_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1CHIS-VLCOMISS     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V1CHIS_VLCOMISS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1CHIS-VLPRMTOT     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V1CHIS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1CHIS-DTQITBCO     PIC  X(010).*/
        public StringBasis V1CHIS_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1CHIS-SIT-FINC     PIC  X(001).*/
        public StringBasis V1CHIS_SIT_FINC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1CHIS-SIT-LIBR     PIC  X(001).*/
        public StringBasis V1CHIS_SIT_LIBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1CHIS-NUM-OCOR     PIC S9(004)               COMP.*/
        public IntBasis V1CHIS_NUM_OCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V2CHIS-OPERACAO     PIC S9(004)               COMP.*/
        public IntBasis V2CHIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V2CHIS-PRM-TARF     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V2CHIS_PRM_TARF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V2CHIS-VAL-DESC     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V2CHIS_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V2CHIS-VLPRMLIQ     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V2CHIS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V2CHIS-VLADIFRA     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V2CHIS_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V2CHIS-VLCOMISS     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V2CHIS_VLCOMISS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V2CHIS-VLPRMTOT     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V2CHIS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-COD-EMPR     PIC S9(009)               COMP.*/
        public IntBasis V0CHIS_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CHIS-CONGENER     PIC S9(004)               COMP.*/
        public IntBasis V0CHIS_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHIS-NUM-APOL     PIC S9(013)               COMP-3.*/
        public IntBasis V0CHIS_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0CHIS-NUM-ENDS     PIC S9(009)               COMP.*/
        public IntBasis V0CHIS_NUM_ENDS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CHIS-NRPARCEL     PIC S9(004)               COMP.*/
        public IntBasis V0CHIS_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHIS-OCORHIST     PIC S9(004)               COMP.*/
        public IntBasis V0CHIS_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHIS-OPERACAO     PIC S9(004)               COMP.*/
        public IntBasis V0CHIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHIS-DAT-MOVT     PIC  X(010).*/
        public StringBasis V0CHIS_DAT_MOVT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CHIS-TIP-SEGU     PIC  X(001).*/
        public StringBasis V0CHIS_TIP_SEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CHIS-PRM-TARF     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V0CHIS_PRM_TARF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-VAL-DESC     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V0CHIS_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-VLPRMLIQ     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V0CHIS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-VLADIFRA     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V0CHIS_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-VLCOMISS     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V0CHIS_VLCOMISS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-VLPRMTOT     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V0CHIS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-DTQITBCO     PIC  X(010).*/
        public StringBasis V0CHIS_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CHIS-SIT-FINC     PIC  X(001).*/
        public StringBasis V0CHIS_SIT_FINC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CHIS-SIT-LIBR     PIC  X(001).*/
        public StringBasis V0CHIS_SIT_LIBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CHIS-NUM-OCOR     PIC S9(004)               COMP.*/
        public IntBasis V0CHIS_NUM_OCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-MOEDA-PRM    PIC S9(004)               COMP.*/
        public IntBasis V0ENDO_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-TIPO-ENDO    PIC  X(001).*/
        public StringBasis V0ENDO_TIPO_ENDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-CORRECAO     PIC  X(001).*/
        public StringBasis V0ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-DTINIVIG     PIC  X(010).*/
        public StringBasis V0ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-CDFRACIO     PIC S9(004)               COMP.*/
        public IntBasis V0ENDO_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-QTPARCEL     PIC S9(004)               COMP.*/
        public IntBasis V0ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MOED-CODUNIMO     PIC S9(004)               COMP.*/
        public IntBasis V1MOED_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MOED-DTINIVIG     PIC  X(010).*/
        public StringBasis V1MOED_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1MOED-VLCRUZAD     PIC S9(006)V9(9)          COMP-3.*/
        public DoubleBasis V1MOED_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77         V1COTA-CODUNIMO     PIC S9(004)               COMP.*/
        public IntBasis V1COTA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COTA-DTINIVIG     PIC  X(010).*/
        public StringBasis V1COTA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COTA-VAL-VENDA    PIC S9(006)V9(9)          COMP-3.*/
        public DoubleBasis V1COTA_VAL_VENDA { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77         V1APCC-PCCOMCOS     PIC S9(003)V99            COMP-3.*/
        public DoubleBasis V1APCC_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0CCHQ-COD-EMPR     PIC S9(009)               COMP.*/
        public IntBasis V0CCHQ_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CCHQ-CONGENER     PIC S9(004)               COMP.*/
        public IntBasis V0CCHQ_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CCHQ-COMISSAO     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V0CCHQ_COMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-OUTRDEBIT    PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V0CCHQ_OUTRDEBIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1CCHQ-CONGENER     PIC S9(004)               COMP.*/
        public IntBasis V1CCHQ_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1CCHQ-DTLIBERA     PIC  X(010).*/
        public StringBasis V1CCHQ_DTLIBERA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         AREA-DE-WORK.*/
        public AC0815B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0815B_AREA_DE_WORK();
        public class AC0815B_AREA_DE_WORK : VarBasis
        {
            /*"  05       WFIM-V1RELATORIOS   PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WFIM-V1COSSEGHIS    PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1COSSEGHIS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WTIP-SOLICIT        PIC  9(001)      VALUE ZEROS.*/
            public IntBasis WTIP_SOLICIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  05       WCOD-EMPR-ANT       PIC S9(009)      VALUE +0 COMP.*/
            public IntBasis WCOD_EMPR_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WCOD-CONG-ANT       PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis WCOD_CONG_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WNUM-APOL-ANT       PIC S9(013)      VALUE +0 COMP-3.*/
            public IntBasis WNUM_APOL_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05       WNUM-ENDS-ANT       PIC S9(009)      VALUE +0 COMP.*/
            public IntBasis WNUM_ENDS_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       AC-I-COSCEDCHQ      PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_I_COSCEDCHQ { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       AC-L-COSSEGPRE      PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_COSSEGPRE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       AC-U-COSSEGPRE      PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_U_COSSEGPRE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       AC-L-COSSEGHIS      PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_COSSEGHIS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       AC-U-COSSEGHIS      PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_U_COSSEGHIS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       AC-I-COSSEGHIS      PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_I_COSSEGHIS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       WVLR-PRMTAR-CM      PIC S9(013)V99            COMP-3.*/
            public DoubleBasis WVLR_PRMTAR_CM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WVLR-DESCTO-CM      PIC S9(013)V99            COMP-3.*/
            public DoubleBasis WVLR_DESCTO_CM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WVLR-PRMLIQ-CM      PIC S9(013)V99            COMP-3.*/
            public DoubleBasis WVLR_PRMLIQ_CM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WVLR-ADIFRA-CM      PIC S9(013)V99            COMP-3.*/
            public DoubleBasis WVLR_ADIFRA_CM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WVLR-COMISS-CM      PIC S9(013)V99            COMP-3.*/
            public DoubleBasis WVLR_COMISS_CM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WVLR-PRMTOT-CM      PIC S9(013)V99            COMP-3.*/
            public DoubleBasis WVLR_PRMTOT_CM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       AC-COMISSAO         PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis AC_COMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       AC-COMISSAO-6668    PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis AC_COMISSAO_6668 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WHORA-ACCEPT.*/
            public AC0815B_WHORA_ACCEPT WHORA_ACCEPT { get; set; } = new AC0815B_WHORA_ACCEPT();
            public class AC0815B_WHORA_ACCEPT : VarBasis
            {
                /*"    10     WHH-ACCEPT          PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WHH_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     WMM-ACCEPT          PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WMM_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     WSS-ACCEPT          PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WSS_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     WCC-ACCEPT          PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WCC_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05       WHORA-EDIT.*/
            }
            public AC0815B_WHORA_EDIT WHORA_EDIT { get; set; } = new AC0815B_WHORA_EDIT();
            public class AC0815B_WHORA_EDIT : VarBasis
            {
                /*"    10     WHH-EDT             PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WHH_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     FILLER              PIC  X(001)      VALUE  ':'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10     WMM-EDT             PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WMM_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     FILLER              PIC  X(001)      VALUE  ':'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10     WSS-EDT             PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WSS_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01         WABEND.*/
            }
        }
        public AC0815B_WABEND WABEND { get; set; } = new AC0815B_WABEND();
        public class AC0815B_WABEND : VarBasis
        {
            /*"  05       FILLER              PIC  X(008)      VALUE 'AC0815B'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"AC0815B");
            /*"  05       FILLER              PIC  X(026)      VALUE          ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05       WNR-EXEC-SQL        PIC  X(003)      VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"  05       FILLER              PIC  X(013)      VALUE          ' *** SQLCODE'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE");
            /*"  05       WSQLCODE            PIC -------999   VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "-------999"));
        }


        public AC0815B_V1RELATORIOS V1RELATORIOS { get; set; } = new AC0815B_V1RELATORIOS();
        public AC0815B_V0COSCEDCHEQUE V0COSCEDCHEQUE { get; set; } = new AC0815B_V0COSCEDCHEQUE();
        public AC0815B_V1COSGHISTP V1COSGHISTP { get; set; } = new AC0815B_V1COSGHISTP();
        public AC0815B_V1COSSEGHIS V1COSSEGHIS { get; set; } = new AC0815B_V1COSSEGHIS();
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
            /*" -335- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WABEND.WNR_EXEC_SQL);

            /*" -336- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -339- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -342- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -346- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -348- PERFORM R0200-00-DECLARE-V1RELATORIOS. */

            R0200_00_DECLARE_V1RELATORIOS_SECTION();

            /*" -350- PERFORM R0250-00-FETCH-V1RELATORIOS. */

            R0250_00_FETCH_V1RELATORIOS_SECTION();

            /*" -351- IF WFIM-V1RELATORIOS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1RELATORIOS.IsEmpty())
            {

                /*" -352- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -353- ELSE */
            }
            else
            {


                /*" -355- PERFORM R0300-00-PROCESSA-LIBERACAO UNTIL WFIM-V1RELATORIOS NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_V1RELATORIOS.IsEmpty()))
                {

                    R0300_00_PROCESSA_LIBERACAO_SECTION();
                }

                /*" -355- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZACAO */

            R0000_90_FINALIZACAO();

        }

        [StopWatch]
        /*" R0000-90-FINALIZACAO */
        private void R0000_90_FINALIZACAO(bool isPerform = false)
        {
            /*" -359- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -363- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -363- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -376- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -381- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -384- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -385- DISPLAY 'R0100 - ERRO DE SELECT NA V1SISTEMA (AC)' */
                _.Display($"R0100 - ERRO DE SELECT NA V1SISTEMA (AC)");

                /*" -386- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -387- ELSE */
            }
            else
            {


                /*" -388- DISPLAY 'DATA DO MOVIMENTO AC - ' V1SIST-DTMOVABE */
                _.Display($"DATA DO MOVIMENTO AC - {V1SIST_DTMOVABE}");

                /*" -388- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -381- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'AC' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-V1RELATORIOS-SECTION */
        private void R0200_00_DECLARE_V1RELATORIOS_SECTION()
        {
            /*" -401- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -423- PERFORM R0200_00_DECLARE_V1RELATORIOS_DB_DECLARE_1 */

            R0200_00_DECLARE_V1RELATORIOS_DB_DECLARE_1();

            /*" -425- PERFORM R0200_00_DECLARE_V1RELATORIOS_DB_OPEN_1 */

            R0200_00_DECLARE_V1RELATORIOS_DB_OPEN_1();

            /*" -428- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -429- DISPLAY 'R0200 - ERRO NO DECLARE NA V1RELATORIOS' */
                _.Display($"R0200 - ERRO NO DECLARE NA V1RELATORIOS");

                /*" -430- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -431- ELSE */
            }
            else
            {


                /*" -432- MOVE SPACES TO WFIM-V1RELATORIOS */
                _.Move("", AREA_DE_WORK.WFIM_V1RELATORIOS);

                /*" -432- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V1RELATORIOS-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V1RELATORIOS_DB_DECLARE_1()
        {
            /*" -423- EXEC SQL DECLARE V1RELATORIOS CURSOR FOR SELECT CODUSU , DATA_SOLICITACAO , IDSISTEM , CODRELAT , PERI_INICIAL , PERI_FINAL , DATA_REFERENCIA , CONGENER , CODUNIMO , CORRECAO , VALUE(COD_EMPRESA,+0) FROM SEGUROS.V1RELATORIOS WHERE DATA_SOLICITACAO = :V1SIST-DTMOVABE AND IDSISTEM = 'AC' AND CODRELAT = 'AC0815B' AND SITUACAO = ' ' ORDER BY COD_EMPRESA, CONGENER END-EXEC. */
            V1RELATORIOS = new AC0815B_V1RELATORIOS(true);
            string GetQuery_V1RELATORIOS()
            {
                var query = @$"SELECT CODUSU
							, 
							DATA_SOLICITACAO
							, 
							IDSISTEM
							, 
							CODRELAT
							, 
							PERI_INICIAL
							, 
							PERI_FINAL
							, 
							DATA_REFERENCIA
							, 
							CONGENER
							, 
							CODUNIMO
							, 
							CORRECAO
							, 
							VALUE(COD_EMPRESA
							,+0) 
							FROM 
							SEGUROS.V1RELATORIOS 
							WHERE 
							DATA_SOLICITACAO = '{V1SIST_DTMOVABE}' 
							AND IDSISTEM = 'AC' 
							AND CODRELAT = 'AC0815B' 
							AND SITUACAO = ' ' 
							ORDER BY 
							COD_EMPRESA
							, 
							CONGENER";

                return query;
            }
            V1RELATORIOS.GetQueryEvent += GetQuery_V1RELATORIOS;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V1RELATORIOS-DB-OPEN-1 */
        public void R0200_00_DECLARE_V1RELATORIOS_DB_OPEN_1()
        {
            /*" -425- EXEC SQL OPEN V1RELATORIOS END-EXEC. */

            V1RELATORIOS.Open();

        }

        [StopWatch]
        /*" R0700-00-DECLARE-V0COSCED-CHQ-DB-DECLARE-1 */
        public void R0700_00_DECLARE_V0COSCED_CHQ_DB_DECLARE_1()
        {
            /*" -705- EXEC SQL DECLARE V0COSCEDCHEQUE CURSOR FOR SELECT B.CONGENER, MAX(B.DTLIBERA) FROM SEGUROS.V0RELATORIOS A, SEGUROS.V0COSCED_CHEQUE B WHERE A.DATA_SOLICITACAO = :V1RELA-DATA-SOL AND A.IDSISTEM = :V1RELA-IDSISTEM AND A.CODRELAT = :V1RELA-CODRELAT AND A.COD_EMPRESA = :V1RELA-COD-EMPR AND B.COD_EMPRESA = A.COD_EMPRESA AND B.CONGENER = A.CONGENER AND B.DTMOVTO_AC < :V1SIST-DTMOVABE AND B.SITUACAO <> '2' GROUP BY B.CONGENER END-EXEC. */
            V0COSCEDCHEQUE = new AC0815B_V0COSCEDCHEQUE(true);
            string GetQuery_V0COSCEDCHEQUE()
            {
                var query = @$"SELECT B.CONGENER
							, 
							MAX(B.DTLIBERA) 
							FROM SEGUROS.V0RELATORIOS A
							, 
							SEGUROS.V0COSCED_CHEQUE B 
							WHERE A.DATA_SOLICITACAO = '{V1RELA_DATA_SOL}' 
							AND A.IDSISTEM = '{V1RELA_IDSISTEM}' 
							AND A.CODRELAT = '{V1RELA_CODRELAT}' 
							AND A.COD_EMPRESA = '{V1RELA_COD_EMPR}' 
							AND B.COD_EMPRESA = A.COD_EMPRESA 
							AND B.CONGENER = A.CONGENER 
							AND B.DTMOVTO_AC < '{V1SIST_DTMOVABE}' 
							AND B.SITUACAO <> '2' 
							GROUP BY 
							B.CONGENER";

                return query;
            }
            V0COSCEDCHEQUE.GetQueryEvent += GetQuery_V0COSCEDCHEQUE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-FETCH-V1RELATORIOS-SECTION */
        private void R0250_00_FETCH_V1RELATORIOS_SECTION()
        {
            /*" -445- MOVE '025' TO WNR-EXEC-SQL. */
            _.Move("025", WABEND.WNR_EXEC_SQL);

            /*" -457- PERFORM R0250_00_FETCH_V1RELATORIOS_DB_FETCH_1 */

            R0250_00_FETCH_V1RELATORIOS_DB_FETCH_1();

            /*" -460- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -461- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -462- MOVE 'S' TO WFIM-V1RELATORIOS */
                    _.Move("S", AREA_DE_WORK.WFIM_V1RELATORIOS);

                    /*" -462- PERFORM R0250_00_FETCH_V1RELATORIOS_DB_CLOSE_1 */

                    R0250_00_FETCH_V1RELATORIOS_DB_CLOSE_1();

                    /*" -464- ELSE */
                }
                else
                {


                    /*" -465- DISPLAY 'R0250 - ERRO NO FETCH DA V1RELATORIOS' */
                    _.Display($"R0250 - ERRO NO FETCH DA V1RELATORIOS");

                    /*" -466- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -467- END-IF */
                }


                /*" -467- END-IF. */
            }


        }

        [StopWatch]
        /*" R0250-00-FETCH-V1RELATORIOS-DB-FETCH-1 */
        public void R0250_00_FETCH_V1RELATORIOS_DB_FETCH_1()
        {
            /*" -457- EXEC SQL FETCH V1RELATORIOS INTO :V1RELA-COD-USU , :V1RELA-DATA-SOL , :V1RELA-IDSISTEM , :V1RELA-CODRELAT , :V1RELA-PERI-INI , :V1RELA-PERI-FIN , :V1RELA-DATA-REF , :V1RELA-CONGENER , :V1RELA-CODUNIMO , :V1RELA-CORRECAO , :V1RELA-COD-EMPR END-EXEC. */

            if (V1RELATORIOS.Fetch())
            {
                _.Move(V1RELATORIOS.V1RELA_COD_USU, V1RELA_COD_USU);
                _.Move(V1RELATORIOS.V1RELA_DATA_SOL, V1RELA_DATA_SOL);
                _.Move(V1RELATORIOS.V1RELA_IDSISTEM, V1RELA_IDSISTEM);
                _.Move(V1RELATORIOS.V1RELA_CODRELAT, V1RELA_CODRELAT);
                _.Move(V1RELATORIOS.V1RELA_PERI_INI, V1RELA_PERI_INI);
                _.Move(V1RELATORIOS.V1RELA_PERI_FIN, V1RELA_PERI_FIN);
                _.Move(V1RELATORIOS.V1RELA_DATA_REF, V1RELA_DATA_REF);
                _.Move(V1RELATORIOS.V1RELA_CONGENER, V1RELA_CONGENER);
                _.Move(V1RELATORIOS.V1RELA_CODUNIMO, V1RELA_CODUNIMO);
                _.Move(V1RELATORIOS.V1RELA_CORRECAO, V1RELA_CORRECAO);
                _.Move(V1RELATORIOS.V1RELA_COD_EMPR, V1RELA_COD_EMPR);
            }

        }

        [StopWatch]
        /*" R0250-00-FETCH-V1RELATORIOS-DB-CLOSE-1 */
        public void R0250_00_FETCH_V1RELATORIOS_DB_CLOSE_1()
        {
            /*" -462- EXEC SQL CLOSE V1RELATORIOS END-EXEC */

            V1RELATORIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-PROCESSA-LIBERACAO-SECTION */
        private void R0300_00_PROCESSA_LIBERACAO_SECTION()
        {
            /*" -480- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", WABEND.WNR_EXEC_SQL);

            /*" -481- DISPLAY '                                  ' . */
            _.Display($"                                  ");

            /*" -483- DISPLAY 'COD. EMPRESA  - ' V1RELA-COD-EMPR. */
            _.Display($"COD. EMPRESA  - {V1RELA_COD_EMPR}");

            /*" -485- MOVE V1RELA-COD-EMPR TO WCOD-EMPR-ANT. */
            _.Move(V1RELA_COD_EMPR, AREA_DE_WORK.WCOD_EMPR_ANT);

            /*" -487- PERFORM R0400-00-PROCESSA-EMPRESAS UNTIL WFIM-V1RELATORIOS NOT EQUAL SPACES OR V1RELA-COD-EMPR NOT EQUAL WCOD-EMPR-ANT. */

            while (!(!AREA_DE_WORK.WFIM_V1RELATORIOS.IsEmpty() || V1RELA_COD_EMPR != AREA_DE_WORK.WCOD_EMPR_ANT))
            {

                R0400_00_PROCESSA_EMPRESAS_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-PROCESSA-EMPRESAS-SECTION */
        private void R0400_00_PROCESSA_EMPRESAS_SECTION()
        {
            /*" -502- MOVE '040' TO WNR-EXEC-SQL. */
            _.Move("040", WABEND.WNR_EXEC_SQL);

            /*" -504- MOVE ZEROS TO WHOST-QTD-RELAT. */
            _.Move(0, WHOST_QTD_RELAT);

            /*" -506- PERFORM R0500-00-SELECT-V0RELATORIOS. */

            R0500_00_SELECT_V0RELATORIOS_SECTION();

            /*" -507- IF WHOST-QTD-RELAT > 1 */

            if (WHOST_QTD_RELAT > 1)
            {

                /*" -508- GO TO R0400-50-PROCESSA-SOLICITACOES */

                R0400_50_PROCESSA_SOLICITACOES(); //GOTO
                return;

                /*" -512- END-IF. */
            }


            /*" -515- MOVE ZEROS TO WHOST-QTD-RELAT WHOST-QTD-CONGN. */
            _.Move(0, WHOST_QTD_RELAT, WHOST_QTD_CONGN);

            /*" -517- PERFORM R0600-00-SELECT-RELAT-CONG. */

            R0600_00_SELECT_RELAT_CONG_SECTION();

            /*" -518- IF WHOST-QTD-RELAT NOT EQUAL WHOST-QTD-CONGN */

            if (WHOST_QTD_RELAT != WHOST_QTD_CONGN)
            {

                /*" -519- GO TO R0400-50-PROCESSA-SOLICITACOES */

                R0400_50_PROCESSA_SOLICITACOES(); //GOTO
                return;

                /*" -523- END-IF. */
            }


            /*" -525- MOVE 0 TO WTIP-SOLICIT. */
            _.Move(0, AREA_DE_WORK.WTIP_SOLICIT);

            /*" -527- MOVE '9999-12-31' TO WHOST-DTMOVTO. */
            _.Move("9999-12-31", WHOST_DTMOVTO);

            /*" -529- PERFORM R0700-00-DECLARE-V0COSCED-CHQ. */

            R0700_00_DECLARE_V0COSCED_CHQ_SECTION();

            /*" -532- DISPLAY 'R0400- PERIODO : ' WHOST-DTMOVTO ' A ' V1RELA-DATA-REF. */

            $"R0400- PERIODO : {WHOST_DTMOVTO} A {V1RELA_DATA_REF}"
            .Display();

            /*" -534- PERFORM R0800-00-DECLARE-V1COSGHISTP. */

            R0800_00_DECLARE_V1COSGHISTP_SECTION();

            /*" -536- PERFORM R0850-00-FETCH-V1COSGHISTP. */

            R0850_00_FETCH_V1COSGHISTP_SECTION();

            /*" -539- PERFORM R1000-00-PROCESSA-V1COSGHISTP UNTIL WFIM-V1COSSEGHIS NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1COSSEGHIS.IsEmpty()))
            {

                R1000_00_PROCESSA_V1COSGHISTP_SECTION();
            }

            /*" -543- PERFORM R1200-00-DELETE-V0RELATORIOS. */

            R1200_00_DELETE_V0RELATORIOS_SECTION();

            /*" -543- GO TO R0400-99-SAIDA. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
            return;

        }

        [StopWatch]
        /*" R0400-50-PROCESSA-SOLICITACOES */
        private void R0400_50_PROCESSA_SOLICITACOES(bool isPerform = false)
        {
            /*" -552- MOVE 1 TO WTIP-SOLICIT. */
            _.Move(1, AREA_DE_WORK.WTIP_SOLICIT);

            /*" -554- PERFORM R1300-00-PROCESSA-SOLICITACAO UNTIL WFIM-V1RELATORIOS NOT EQUAL SPACES OR V1RELA-COD-EMPR NOT EQUAL WCOD-EMPR-ANT. */

            while (!(!AREA_DE_WORK.WFIM_V1RELATORIOS.IsEmpty() || V1RELA_COD_EMPR != AREA_DE_WORK.WCOD_EMPR_ANT))
            {

                R1300_00_PROCESSA_SOLICITACAO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-SELECT-V0RELATORIOS-SECTION */
        private void R0500_00_SELECT_V0RELATORIOS_SECTION()
        {
            /*" -567- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", WABEND.WNR_EXEC_SQL);

            /*" -575- PERFORM R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1 */

            R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1();

            /*" -578- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -579- DISPLAY 'R0500 - ERRO NO SELECT DA V0RELATORIOS - 1' */
                _.Display($"R0500 - ERRO NO SELECT DA V0RELATORIOS - 1");

                /*" -580- DISPLAY 'DT SOLICT - ' V1RELA-DATA-SOL */
                _.Display($"DT SOLICT - {V1RELA_DATA_SOL}");

                /*" -581- DISPLAY 'IDE SISTM - ' V1RELA-IDSISTEM */
                _.Display($"IDE SISTM - {V1RELA_IDSISTEM}");

                /*" -582- DISPLAY 'COD RELAT - ' V1RELA-CODRELAT */
                _.Display($"COD RELAT - {V1RELA_CODRELAT}");

                /*" -583- DISPLAY 'COD EMPR  - ' V1RELA-COD-EMPR */
                _.Display($"COD EMPR  - {V1RELA_COD_EMPR}");

                /*" -584- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -585- ELSE */
            }
            else
            {


                /*" -586- IF WHOST-QTD-RELAT > 1 */

                if (WHOST_QTD_RELAT > 1)
                {

                    /*" -587- GO TO R0500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                    return;

                    /*" -588- END-IF */
                }


                /*" -592- END-IF. */
            }


            /*" -600- PERFORM R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2 */

            R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2();

            /*" -603- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -604- DISPLAY 'R0500 - ERRO NO SELECT DA V0RELATORIOS - 2' */
                _.Display($"R0500 - ERRO NO SELECT DA V0RELATORIOS - 2");

                /*" -605- DISPLAY 'DT SOLICT - ' V1RELA-DATA-SOL */
                _.Display($"DT SOLICT - {V1RELA_DATA_SOL}");

                /*" -606- DISPLAY 'IDE SISTM - ' V1RELA-IDSISTEM */
                _.Display($"IDE SISTM - {V1RELA_IDSISTEM}");

                /*" -607- DISPLAY 'COD RELAT - ' V1RELA-CODRELAT */
                _.Display($"COD RELAT - {V1RELA_CODRELAT}");

                /*" -608- DISPLAY 'COD EMPR  - ' V1RELA-COD-EMPR */
                _.Display($"COD EMPR  - {V1RELA_COD_EMPR}");

                /*" -609- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -610- ELSE */
            }
            else
            {


                /*" -611- IF WHOST-QTD-RELAT > 1 */

                if (WHOST_QTD_RELAT > 1)
                {

                    /*" -612- GO TO R0500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                    return;

                    /*" -613- END-IF */
                }


                /*" -617- END-IF. */
            }


            /*" -625- PERFORM R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3 */

            R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3();

            /*" -628- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -629- DISPLAY 'R0500 - ERRO NO SELECT DA V0RELATORIOS - 3' */
                _.Display($"R0500 - ERRO NO SELECT DA V0RELATORIOS - 3");

                /*" -630- DISPLAY 'DT SOLICT - ' V1RELA-DATA-SOL */
                _.Display($"DT SOLICT - {V1RELA_DATA_SOL}");

                /*" -631- DISPLAY 'IDE SISTM - ' V1RELA-IDSISTEM */
                _.Display($"IDE SISTM - {V1RELA_IDSISTEM}");

                /*" -632- DISPLAY 'COD RELAT - ' V1RELA-CODRELAT */
                _.Display($"COD RELAT - {V1RELA_CODRELAT}");

                /*" -633- DISPLAY 'COD EMPR  - ' V1RELA-COD-EMPR */
                _.Display($"COD EMPR  - {V1RELA_COD_EMPR}");

                /*" -634- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -634- END-IF. */
            }


        }

        [StopWatch]
        /*" R0500-00-SELECT-V0RELATORIOS-DB-SELECT-1 */
        public void R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -575- EXEC SQL SELECT VALUE(COUNT(DISTINCT DATA_REFERENCIA),+0) INTO :WHOST-QTD-RELAT FROM SEGUROS.V0RELATORIOS WHERE DATA_SOLICITACAO = :V1RELA-DATA-SOL AND IDSISTEM = :V1RELA-IDSISTEM AND CODRELAT = :V1RELA-CODRELAT AND COD_EMPRESA = :V1RELA-COD-EMPR END-EXEC. */

            var r0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 = new R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1()
            {
                V1RELA_DATA_SOL = V1RELA_DATA_SOL.ToString(),
                V1RELA_IDSISTEM = V1RELA_IDSISTEM.ToString(),
                V1RELA_CODRELAT = V1RELA_CODRELAT.ToString(),
                V1RELA_COD_EMPR = V1RELA_COD_EMPR.ToString(),
            };

            var executed_1 = R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1.Execute(r0500_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTD_RELAT, WHOST_QTD_RELAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-SELECT-V0RELATORIOS-DB-SELECT-2 */
        public void R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2()
        {
            /*" -600- EXEC SQL SELECT VALUE(COUNT(DISTINCT PERI_INICIAL),+0) INTO :WHOST-QTD-RELAT FROM SEGUROS.V0RELATORIOS WHERE DATA_SOLICITACAO = :V1RELA-DATA-SOL AND IDSISTEM = :V1RELA-IDSISTEM AND CODRELAT = :V1RELA-CODRELAT AND COD_EMPRESA = :V1RELA-COD-EMPR END-EXEC. */

            var r0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1 = new R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1()
            {
                V1RELA_DATA_SOL = V1RELA_DATA_SOL.ToString(),
                V1RELA_IDSISTEM = V1RELA_IDSISTEM.ToString(),
                V1RELA_CODRELAT = V1RELA_CODRELAT.ToString(),
                V1RELA_COD_EMPR = V1RELA_COD_EMPR.ToString(),
            };

            var executed_1 = R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1.Execute(r0500_00_SELECT_V0RELATORIOS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTD_RELAT, WHOST_QTD_RELAT);
            }


        }

        [StopWatch]
        /*" R0600-00-SELECT-RELAT-CONG-SECTION */
        private void R0600_00_SELECT_RELAT_CONG_SECTION()
        {
            /*" -647- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", WABEND.WNR_EXEC_SQL);

            /*" -655- PERFORM R0600_00_SELECT_RELAT_CONG_DB_SELECT_1 */

            R0600_00_SELECT_RELAT_CONG_DB_SELECT_1();

            /*" -658- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -659- DISPLAY 'R0600 - ERRO NO SELECT DA V0RELATORIOS' */
                _.Display($"R0600 - ERRO NO SELECT DA V0RELATORIOS");

                /*" -660- DISPLAY 'DT SOLICT - ' V1RELA-DATA-SOL */
                _.Display($"DT SOLICT - {V1RELA_DATA_SOL}");

                /*" -661- DISPLAY 'IDE SISTM - ' V1RELA-IDSISTEM */
                _.Display($"IDE SISTM - {V1RELA_IDSISTEM}");

                /*" -662- DISPLAY 'COD RELAT - ' V1RELA-CODRELAT */
                _.Display($"COD RELAT - {V1RELA_CODRELAT}");

                /*" -663- DISPLAY 'COD EMPR  - ' V1RELA-COD-EMPR */
                _.Display($"COD EMPR  - {V1RELA_COD_EMPR}");

                /*" -664- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -668- END-IF. */
            }


            /*" -672- PERFORM R0600_00_SELECT_RELAT_CONG_DB_SELECT_2 */

            R0600_00_SELECT_RELAT_CONG_DB_SELECT_2();

            /*" -675- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -676- DISPLAY 'R0600 - ERRO NO SELECT DA V0CONGENERE' */
                _.Display($"R0600 - ERRO NO SELECT DA V0CONGENERE");

                /*" -677- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -677- END-IF. */
            }


        }

        [StopWatch]
        /*" R0600-00-SELECT-RELAT-CONG-DB-SELECT-1 */
        public void R0600_00_SELECT_RELAT_CONG_DB_SELECT_1()
        {
            /*" -655- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WHOST-QTD-RELAT FROM SEGUROS.V0RELATORIOS WHERE DATA_SOLICITACAO = :V1RELA-DATA-SOL AND IDSISTEM = :V1RELA-IDSISTEM AND CODRELAT = :V1RELA-CODRELAT AND COD_EMPRESA = :V1RELA-COD-EMPR END-EXEC. */

            var r0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1 = new R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1()
            {
                V1RELA_DATA_SOL = V1RELA_DATA_SOL.ToString(),
                V1RELA_IDSISTEM = V1RELA_IDSISTEM.ToString(),
                V1RELA_CODRELAT = V1RELA_CODRELAT.ToString(),
                V1RELA_COD_EMPR = V1RELA_COD_EMPR.ToString(),
            };

            var executed_1 = R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1.Execute(r0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTD_RELAT, WHOST_QTD_RELAT);
            }


        }

        [StopWatch]
        /*" R0500-00-SELECT-V0RELATORIOS-DB-SELECT-3 */
        public void R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3()
        {
            /*" -625- EXEC SQL SELECT VALUE(COUNT(DISTINCT CODUNIMO),+0) INTO :WHOST-QTD-RELAT FROM SEGUROS.V0RELATORIOS WHERE DATA_SOLICITACAO = :V1RELA-DATA-SOL AND IDSISTEM = :V1RELA-IDSISTEM AND CODRELAT = :V1RELA-CODRELAT AND COD_EMPRESA = :V1RELA-COD-EMPR END-EXEC. */

            var r0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1 = new R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1()
            {
                V1RELA_DATA_SOL = V1RELA_DATA_SOL.ToString(),
                V1RELA_IDSISTEM = V1RELA_IDSISTEM.ToString(),
                V1RELA_CODRELAT = V1RELA_CODRELAT.ToString(),
                V1RELA_COD_EMPR = V1RELA_COD_EMPR.ToString(),
            };

            var executed_1 = R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1.Execute(r0500_00_SELECT_V0RELATORIOS_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTD_RELAT, WHOST_QTD_RELAT);
            }


        }

        [StopWatch]
        /*" R0600-00-SELECT-RELAT-CONG-DB-SELECT-2 */
        public void R0600_00_SELECT_RELAT_CONG_DB_SELECT_2()
        {
            /*" -672- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WHOST-QTD-CONGN FROM SEGUROS.V0CONGENERE END-EXEC. */

            var r0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1 = new R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1.Execute(r0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTD_CONGN, WHOST_QTD_CONGN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-DECLARE-V0COSCED-CHQ-SECTION */
        private void R0700_00_DECLARE_V0COSCED_CHQ_SECTION()
        {
            /*" -690- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", WABEND.WNR_EXEC_SQL);

            /*" -705- PERFORM R0700_00_DECLARE_V0COSCED_CHQ_DB_DECLARE_1 */

            R0700_00_DECLARE_V0COSCED_CHQ_DB_DECLARE_1();

            /*" -707- PERFORM R0700_00_DECLARE_V0COSCED_CHQ_DB_OPEN_1 */

            R0700_00_DECLARE_V0COSCED_CHQ_DB_OPEN_1();

            /*" -710- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -711- DISPLAY 'R0700 - ERRO NO DECLARE DA V0COSCED_CHEQUE' */
                _.Display($"R0700 - ERRO NO DECLARE DA V0COSCED_CHEQUE");

                /*" -712- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -712- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0700_10_LER_V0COSCEDCHEQUE */

            R0700_10_LER_V0COSCEDCHEQUE();

        }

        [StopWatch]
        /*" R0700-00-DECLARE-V0COSCED-CHQ-DB-OPEN-1 */
        public void R0700_00_DECLARE_V0COSCED_CHQ_DB_OPEN_1()
        {
            /*" -707- EXEC SQL OPEN V0COSCEDCHEQUE END-EXEC. */

            V0COSCEDCHEQUE.Open();

        }

        [StopWatch]
        /*" R0800-00-DECLARE-V1COSGHISTP-DB-DECLARE-1 */
        public void R0800_00_DECLARE_V1COSGHISTP_DB_DECLARE_1()
        {
            /*" -800- EXEC SQL DECLARE V1COSGHISTP CURSOR FOR SELECT COD_EMPRESA , CONGENER , NUM_APOLICE , NRENDOS , NRPARCEL , OCORHIST , OPERACAO , TIPSGU , PRM_TARIFARIO, VAL_DESCONTO , VLPRMLIQ , VLADIFRA , VLCOMIS , VLPRMTOT , DTMOVTO , DTQITBCO , NUMOCOR FROM SEGUROS.V1COSSEG_HISTPRE WHERE COD_EMPRESA = :V1RELA-COD-EMPR AND DTMOVTO BETWEEN :WHOST-DTMOVTO AND :V1RELA-DATA-REF AND TIPSGU = '1' AND SIT_FINANCEIRA = '0' AND SIT_LIBRECUP = '0' AND ((OPERACAO BETWEEN 0400 AND 0599) OR (OPERACAO BETWEEN 0970 AND 0971) OR (OPERACAO BETWEEN 0980 AND 0981)) ORDER BY CONGENER, NUM_APOLICE, NRENDOS, NRPARCEL, OCORHIST END-EXEC. */
            V1COSGHISTP = new AC0815B_V1COSGHISTP(true);
            string GetQuery_V1COSGHISTP()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							CONGENER
							, 
							NUM_APOLICE
							, 
							NRENDOS
							, 
							NRPARCEL
							, 
							OCORHIST
							, 
							OPERACAO
							, 
							TIPSGU
							, 
							PRM_TARIFARIO
							, 
							VAL_DESCONTO
							, 
							VLPRMLIQ
							, 
							VLADIFRA
							, 
							VLCOMIS
							, 
							VLPRMTOT
							, 
							DTMOVTO
							, 
							DTQITBCO
							, 
							NUMOCOR 
							FROM 
							SEGUROS.V1COSSEG_HISTPRE 
							WHERE 
							COD_EMPRESA = '{V1RELA_COD_EMPR}' 
							AND DTMOVTO BETWEEN '{WHOST_DTMOVTO}' 
							AND '{V1RELA_DATA_REF}' 
							AND TIPSGU = '1' 
							AND SIT_FINANCEIRA = '0' 
							AND SIT_LIBRECUP = '0' 
							AND ((OPERACAO BETWEEN 0400 AND 0599) 
							OR (OPERACAO BETWEEN 0970 AND 0971) 
							OR (OPERACAO BETWEEN 0980 AND 0981)) 
							ORDER BY 
							CONGENER
							, 
							NUM_APOLICE
							, 
							NRENDOS
							, 
							NRPARCEL
							, 
							OCORHIST";

                return query;
            }
            V1COSGHISTP.GetQueryEvent += GetQuery_V1COSGHISTP;

        }

        [StopWatch]
        /*" R0700-10-LER-V0COSCEDCHEQUE */
        private void R0700_10_LER_V0COSCEDCHEQUE(bool isPerform = false)
        {
            /*" -722- PERFORM R0700_10_LER_V0COSCEDCHEQUE_DB_FETCH_1 */

            R0700_10_LER_V0COSCEDCHEQUE_DB_FETCH_1();

            /*" -725- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -726- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -726- PERFORM R0700_10_LER_V0COSCEDCHEQUE_DB_CLOSE_1 */

                    R0700_10_LER_V0COSCEDCHEQUE_DB_CLOSE_1();

                    /*" -728- GO TO R0700-90-QTDE-REGT */

                    R0700_90_QTDE_REGT(); //GOTO
                    return;

                    /*" -729- ELSE */
                }
                else
                {


                    /*" -730- DISPLAY 'R0700 - ERRO FETCH V0COSCED_CHEQUE' */
                    _.Display($"R0700 - ERRO FETCH V0COSCED_CHEQUE");

                    /*" -731- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -732- END-IF */
                }


                /*" -733- ELSE */
            }
            else
            {


                /*" -734- ADD 1 TO WHOST-QTD-COSCH */
                WHOST_QTD_COSCH.Value = WHOST_QTD_COSCH + 1;

                /*" -736- END-IF. */
            }


            /*" -737- IF WHOST-DTMOVTO > V1CCHQ-DTLIBERA */

            if (WHOST_DTMOVTO > V1CCHQ_DTLIBERA)
            {

                /*" -738- MOVE V1CCHQ-DTLIBERA TO WHOST-DTMOVTO */
                _.Move(V1CCHQ_DTLIBERA, WHOST_DTMOVTO);

                /*" -742- END-IF. */
            }


            /*" -742- GO TO R0700-10-LER-V0COSCEDCHEQUE. */
            new Task(() => R0700_10_LER_V0COSCEDCHEQUE()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0700-10-LER-V0COSCEDCHEQUE-DB-FETCH-1 */
        public void R0700_10_LER_V0COSCEDCHEQUE_DB_FETCH_1()
        {
            /*" -722- EXEC SQL FETCH V0COSCEDCHEQUE INTO :V1CCHQ-CONGENER, :V1CCHQ-DTLIBERA END-EXEC. */

            if (V0COSCEDCHEQUE.Fetch())
            {
                _.Move(V0COSCEDCHEQUE.V1CCHQ_CONGENER, V1CCHQ_CONGENER);
                _.Move(V0COSCEDCHEQUE.V1CCHQ_DTLIBERA, V1CCHQ_DTLIBERA);
            }

        }

        [StopWatch]
        /*" R0700-10-LER-V0COSCEDCHEQUE-DB-CLOSE-1 */
        public void R0700_10_LER_V0COSCEDCHEQUE_DB_CLOSE_1()
        {
            /*" -726- EXEC SQL CLOSE V0COSCEDCHEQUE END-EXEC */

            V0COSCEDCHEQUE.Close();

        }

        [StopWatch]
        /*" R0700-90-QTDE-REGT */
        private void R0700_90_QTDE_REGT(bool isPerform = false)
        {
            /*" -750- IF WHOST-QTD-COSCH NOT EQUAL WHOST-QTD-RELAT */

            if (WHOST_QTD_COSCH != WHOST_QTD_RELAT)
            {

                /*" -751- MOVE '1990-01-01' TO WHOST-DTMOVTO */
                _.Move("1990-01-01", WHOST_DTMOVTO);

                /*" -751- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-DECLARE-V1COSGHISTP-SECTION */
        private void R0800_00_DECLARE_V1COSGHISTP_SECTION()
        {
            /*" -764- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", WABEND.WNR_EXEC_SQL);

            /*" -800- PERFORM R0800_00_DECLARE_V1COSGHISTP_DB_DECLARE_1 */

            R0800_00_DECLARE_V1COSGHISTP_DB_DECLARE_1();

            /*" -802- PERFORM R0800_00_DECLARE_V1COSGHISTP_DB_OPEN_1 */

            R0800_00_DECLARE_V1COSGHISTP_DB_OPEN_1();

            /*" -805- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -806- DISPLAY 'R0800 - ERRO NO DECLARE DA V1COSSEG_HISTPRE' */
                _.Display($"R0800 - ERRO NO DECLARE DA V1COSSEG_HISTPRE");

                /*" -807- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -808- ELSE */
            }
            else
            {


                /*" -809- MOVE SPACES TO WFIM-V1COSSEGHIS */
                _.Move("", AREA_DE_WORK.WFIM_V1COSSEGHIS);

                /*" -809- END-IF. */
            }


        }

        [StopWatch]
        /*" R0800-00-DECLARE-V1COSGHISTP-DB-OPEN-1 */
        public void R0800_00_DECLARE_V1COSGHISTP_DB_OPEN_1()
        {
            /*" -802- EXEC SQL OPEN V1COSGHISTP END-EXEC. */

            V1COSGHISTP.Open();

        }

        [StopWatch]
        /*" R1500-00-DECLARE-V1COSSEGHIS-DB-DECLARE-1 */
        public void R1500_00_DECLARE_V1COSSEGHIS_DB_DECLARE_1()
        {
            /*" -1195- EXEC SQL DECLARE V1COSSEGHIS CURSOR FOR SELECT COD_EMPRESA , CONGENER , NUM_APOLICE , NRENDOS , NRPARCEL , OCORHIST , OPERACAO , TIPSGU , PRM_TARIFARIO, VAL_DESCONTO , VLPRMLIQ , VLADIFRA , VLCOMIS , VLPRMTOT , DTMOVTO , DTQITBCO , NUMOCOR FROM SEGUROS.V1COSSEG_HISTPRE WHERE COD_EMPRESA = :V1RELA-COD-EMPR AND CONGENER = :V1RELA-CONGENER AND DTMOVTO BETWEEN :WHOST-DTMOVTO AND :V1RELA-DATA-REF AND TIPSGU = '1' AND SIT_FINANCEIRA = '0' AND SIT_LIBRECUP = '0' AND ((OPERACAO BETWEEN 0400 AND 0599) OR (OPERACAO BETWEEN 0970 AND 0971) OR (OPERACAO BETWEEN 0980 AND 0981)) ORDER BY CONGENER, NUM_APOLICE, NRENDOS, NRPARCEL, OCORHIST END-EXEC. */
            V1COSSEGHIS = new AC0815B_V1COSSEGHIS(true);
            string GetQuery_V1COSSEGHIS()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							CONGENER
							, 
							NUM_APOLICE
							, 
							NRENDOS
							, 
							NRPARCEL
							, 
							OCORHIST
							, 
							OPERACAO
							, 
							TIPSGU
							, 
							PRM_TARIFARIO
							, 
							VAL_DESCONTO
							, 
							VLPRMLIQ
							, 
							VLADIFRA
							, 
							VLCOMIS
							, 
							VLPRMTOT
							, 
							DTMOVTO
							, 
							DTQITBCO
							, 
							NUMOCOR 
							FROM 
							SEGUROS.V1COSSEG_HISTPRE 
							WHERE 
							COD_EMPRESA = '{V1RELA_COD_EMPR}' 
							AND CONGENER = '{V1RELA_CONGENER}' 
							AND DTMOVTO BETWEEN '{WHOST_DTMOVTO}' 
							AND '{V1RELA_DATA_REF}' 
							AND TIPSGU = '1' 
							AND SIT_FINANCEIRA = '0' 
							AND SIT_LIBRECUP = '0' 
							AND ((OPERACAO BETWEEN 0400 AND 0599) 
							OR (OPERACAO BETWEEN 0970 AND 0971) 
							OR (OPERACAO BETWEEN 0980 AND 0981)) 
							ORDER BY 
							CONGENER
							, 
							NUM_APOLICE
							, 
							NRENDOS
							, 
							NRPARCEL
							, 
							OCORHIST";

                return query;
            }
            V1COSSEGHIS.GetQueryEvent += GetQuery_V1COSSEGHIS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0850-00-FETCH-V1COSGHISTP-SECTION */
        private void R0850_00_FETCH_V1COSGHISTP_SECTION()
        {
            /*" -820- MOVE '065' TO WNR-EXEC-SQL. */
            _.Move("065", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0850_10_LER_V1COSGHISTP */

            R0850_10_LER_V1COSGHISTP();

        }

        [StopWatch]
        /*" R0850-10-LER-V1COSGHISTP */
        private void R0850_10_LER_V1COSGHISTP(bool isPerform = false)
        {
            /*" -842- PERFORM R0850_10_LER_V1COSGHISTP_DB_FETCH_1 */

            R0850_10_LER_V1COSGHISTP_DB_FETCH_1();

            /*" -845- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -846- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -847- MOVE 'S' TO WFIM-V1COSSEGHIS */
                    _.Move("S", AREA_DE_WORK.WFIM_V1COSSEGHIS);

                    /*" -847- PERFORM R0850_10_LER_V1COSGHISTP_DB_CLOSE_1 */

                    R0850_10_LER_V1COSGHISTP_DB_CLOSE_1();

                    /*" -849- ELSE */
                }
                else
                {


                    /*" -850- DISPLAY 'R0850 - ERRO NO FETCH DA V1COSSEG_HISTPRE' */
                    _.Display($"R0850 - ERRO NO FETCH DA V1COSSEG_HISTPRE");

                    /*" -851- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -852- END-IF */
                }


                /*" -853- ELSE */
            }
            else
            {


                /*" -854- IF VIND-DAT-QTBC < ZEROS */

                if (VIND_DAT_QTBC < 00)
                {

                    /*" -855- MOVE SPACES TO V1CHIS-DTQITBCO */
                    _.Move("", V1CHIS_DTQITBCO);

                    /*" -856- END-IF */
                }


                /*" -857- PERFORM R0900-00-SELECT-V0ENDOSSO */

                R0900_00_SELECT_V0ENDOSSO_SECTION();

                /*" -858- IF V0ENDO-QTPARCEL < 02 */

                if (V0ENDO_QTPARCEL < 02)
                {

                    /*" -859- GO TO R0850-10-LER-V1COSGHISTP */
                    new Task(() => R0850_10_LER_V1COSGHISTP()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -860- ELSE */
                }
                else
                {


                    /*" -861- IF V0ENDO-CDFRACIO < 01 */

                    if (V0ENDO_CDFRACIO < 01)
                    {

                        /*" -862- GO TO R0850-10-LER-V1COSGHISTP */
                        new Task(() => R0850_10_LER_V1COSGHISTP()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -863- END-IF */
                    }


                    /*" -864- END-IF */
                }


                /*" -864- END-IF. */
            }


        }

        [StopWatch]
        /*" R0850-10-LER-V1COSGHISTP-DB-FETCH-1 */
        public void R0850_10_LER_V1COSGHISTP_DB_FETCH_1()
        {
            /*" -842- EXEC SQL FETCH V1COSGHISTP INTO :V1CHIS-COD-EMPR , :V1CHIS-CONGENER , :V1CHIS-NUM-APOL , :V1CHIS-NUM-ENDS , :V1CHIS-NRPARCEL , :V1CHIS-OCORHIST , :V1CHIS-OPERACAO , :V1CHIS-TIP-SEGU , :V1CHIS-PRM-TARF , :V1CHIS-VAL-DESC , :V1CHIS-VLPRMLIQ , :V1CHIS-VLADIFRA , :V1CHIS-VLCOMISS , :V1CHIS-VLPRMTOT , :V1CHIS-DAT-MOVT , :V1CHIS-DTQITBCO:VIND-DAT-QTBC, :V1CHIS-NUM-OCOR:VIND-NUM-OCOR END-EXEC. */

            if (V1COSGHISTP.Fetch())
            {
                _.Move(V1COSGHISTP.V1CHIS_COD_EMPR, V1CHIS_COD_EMPR);
                _.Move(V1COSGHISTP.V1CHIS_CONGENER, V1CHIS_CONGENER);
                _.Move(V1COSGHISTP.V1CHIS_NUM_APOL, V1CHIS_NUM_APOL);
                _.Move(V1COSGHISTP.V1CHIS_NUM_ENDS, V1CHIS_NUM_ENDS);
                _.Move(V1COSGHISTP.V1CHIS_NRPARCEL, V1CHIS_NRPARCEL);
                _.Move(V1COSGHISTP.V1CHIS_OCORHIST, V1CHIS_OCORHIST);
                _.Move(V1COSGHISTP.V1CHIS_OPERACAO, V1CHIS_OPERACAO);
                _.Move(V1COSGHISTP.V1CHIS_TIP_SEGU, V1CHIS_TIP_SEGU);
                _.Move(V1COSGHISTP.V1CHIS_PRM_TARF, V1CHIS_PRM_TARF);
                _.Move(V1COSGHISTP.V1CHIS_VAL_DESC, V1CHIS_VAL_DESC);
                _.Move(V1COSGHISTP.V1CHIS_VLPRMLIQ, V1CHIS_VLPRMLIQ);
                _.Move(V1COSGHISTP.V1CHIS_VLADIFRA, V1CHIS_VLADIFRA);
                _.Move(V1COSGHISTP.V1CHIS_VLCOMISS, V1CHIS_VLCOMISS);
                _.Move(V1COSGHISTP.V1CHIS_VLPRMTOT, V1CHIS_VLPRMTOT);
                _.Move(V1COSGHISTP.V1CHIS_DAT_MOVT, V1CHIS_DAT_MOVT);
                _.Move(V1COSGHISTP.V1CHIS_DTQITBCO, V1CHIS_DTQITBCO);
                _.Move(V1COSGHISTP.VIND_DAT_QTBC, VIND_DAT_QTBC);
                _.Move(V1COSGHISTP.V1CHIS_NUM_OCOR, V1CHIS_NUM_OCOR);
                _.Move(V1COSGHISTP.VIND_NUM_OCOR, VIND_NUM_OCOR);
            }

        }

        [StopWatch]
        /*" R0850-10-LER-V1COSGHISTP-DB-CLOSE-1 */
        public void R0850_10_LER_V1COSGHISTP_DB_CLOSE_1()
        {
            /*" -847- EXEC SQL CLOSE V1COSGHISTP END-EXEC */

            V1COSGHISTP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-SELECT-V0ENDOSSO-SECTION */
        private void R0900_00_SELECT_V0ENDOSSO_SECTION()
        {
            /*" -877- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -893- PERFORM R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1 */

            R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1();

            /*" -896- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -897- DISPLAY 'R0900 - ERRO NO SELECT DA V0ENDOSSO' */
                _.Display($"R0900 - ERRO NO SELECT DA V0ENDOSSO");

                /*" -898- DISPLAY 'EMPRESA  - ' V1CHIS-COD-EMPR */
                _.Display($"EMPRESA  - {V1CHIS_COD_EMPR}");

                /*" -899- DISPLAY 'COD CONG - ' V1CHIS-CONGENER */
                _.Display($"COD CONG - {V1CHIS_CONGENER}");

                /*" -900- DISPLAY 'APOLICE  - ' V1CHIS-NUM-APOL */
                _.Display($"APOLICE  - {V1CHIS_NUM_APOL}");

                /*" -901- DISPLAY 'ENDOSSO  - ' V1CHIS-NUM-ENDS */
                _.Display($"ENDOSSO  - {V1CHIS_NUM_ENDS}");

                /*" -902- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -902- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-SELECT-V0ENDOSSO-DB-SELECT-1 */
        public void R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1()
        {
            /*" -893- EXEC SQL SELECT COD_MOEDA_PRM , TIPO_ENDOSSO , CORRECAO , DTINIVIG , CDFRACIO , QTPARCEL INTO :V0ENDO-MOEDA-PRM, :V0ENDO-TIPO-ENDO, :V0ENDO-CORRECAO , :V0ENDO-DTINIVIG , :V0ENDO-CDFRACIO , :V0ENDO-QTPARCEL FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V1CHIS-NUM-APOL AND NRENDOS = :V1CHIS-NUM-ENDS END-EXEC. */

            var r0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 = new R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1()
            {
                V1CHIS_NUM_APOL = V1CHIS_NUM_APOL.ToString(),
                V1CHIS_NUM_ENDS = V1CHIS_NUM_ENDS.ToString(),
            };

            var executed_1 = R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1.Execute(r0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_MOEDA_PRM, V0ENDO_MOEDA_PRM);
                _.Move(executed_1.V0ENDO_TIPO_ENDO, V0ENDO_TIPO_ENDO);
                _.Move(executed_1.V0ENDO_CORRECAO, V0ENDO_CORRECAO);
                _.Move(executed_1.V0ENDO_DTINIVIG, V0ENDO_DTINIVIG);
                _.Move(executed_1.V0ENDO_CDFRACIO, V0ENDO_CDFRACIO);
                _.Move(executed_1.V0ENDO_QTPARCEL, V0ENDO_QTPARCEL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-V1COSGHISTP-SECTION */
        private void R1000_00_PROCESSA_V1COSGHISTP_SECTION()
        {
            /*" -915- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -918- MOVE V1CHIS-CONGENER TO WCOD-CONG-ANT V1RELA-CONGENER. */
            _.Move(V1CHIS_CONGENER, AREA_DE_WORK.WCOD_CONG_ANT, V1RELA_CONGENER);

            /*" -924- MOVE ZEROS TO AC-L-COSSEGPRE AC-U-COSSEGPRE AC-L-COSSEGHIS AC-U-COSSEGHIS AC-I-COSSEGHIS. */
            _.Move(0, AREA_DE_WORK.AC_L_COSSEGPRE, AREA_DE_WORK.AC_U_COSSEGPRE, AREA_DE_WORK.AC_L_COSSEGHIS, AREA_DE_WORK.AC_U_COSSEGHIS, AREA_DE_WORK.AC_I_COSSEGHIS);

            /*" -927- MOVE ZEROS TO AC-COMISSAO AC-COMISSAO-6668. */
            _.Move(0, AREA_DE_WORK.AC_COMISSAO, AREA_DE_WORK.AC_COMISSAO_6668);

            /*" -928- DISPLAY 'COD. USUARIO   - ' V1RELA-COD-USU. */
            _.Display($"COD. USUARIO   - {V1RELA_COD_USU}");

            /*" -930- DISPLAY 'CONGENERE      - ' V1RELA-CONGENER. */
            _.Display($"CONGENERE      - {V1RELA_CONGENER}");

            /*" -932- IF V1RELA-CODUNIMO GREATER ZEROS AND V1RELA-PERI-INI NOT EQUAL '0001-01-01' */

            if (V1RELA_CODUNIMO > 00 && V1RELA_PERI_INI != "0001-01-01")
            {

                /*" -933- MOVE V1RELA-CODUNIMO TO V1MOED-CODUNIMO */
                _.Move(V1RELA_CODUNIMO, V1MOED_CODUNIMO);

                /*" -934- MOVE V1RELA-PERI-INI TO V1MOED-DTINIVIG */
                _.Move(V1RELA_PERI_INI, V1MOED_DTINIVIG);

                /*" -935- PERFORM R1100-00-SELECT-V1MOEDA */

                R1100_00_SELECT_V1MOEDA_SECTION();

                /*" -936- MOVE V1MOED-VLCRUZAD TO WHOST-VLCRUZAD1 */
                _.Move(V1MOED_VLCRUZAD, WHOST_VLCRUZAD1);

                /*" -938- END-IF. */
            }


            /*" -942- PERFORM R1600-00-PROCESSA-DOCUMENTO UNTIL WFIM-V1COSSEGHIS NOT EQUAL SPACES OR V1CHIS-CONGENER NOT EQUAL WCOD-CONG-ANT. */

            while (!(!AREA_DE_WORK.WFIM_V1COSSEGHIS.IsEmpty() || V1CHIS_CONGENER != AREA_DE_WORK.WCOD_CONG_ANT))
            {

                R1600_00_PROCESSA_DOCUMENTO_SECTION();
            }

            /*" -944- PERFORM R3000-00-MONTA-COSCED-CHEQUE. */

            R3000_00_MONTA_COSCED_CHEQUE_SECTION();

            /*" -945- DISPLAY '**** AC0815B ****' . */
            _.Display($"**** AC0815B ****");

            /*" -946- DISPLAY '- COSSEG-PREM    ' . */
            _.Display($"- COSSEG-PREM    ");

            /*" -947- DISPLAY ' .LIDOS......... ' AC-L-COSSEGPRE. */
            _.Display($" .LIDOS......... {AREA_DE_WORK.AC_L_COSSEGPRE}");

            /*" -948- DISPLAY ' .ATUALIZADOS... ' AC-U-COSSEGPRE. */
            _.Display($" .ATUALIZADOS... {AREA_DE_WORK.AC_U_COSSEGPRE}");

            /*" -949- DISPLAY ' ' . */
            _.Display($" ");

            /*" -950- DISPLAY '- COSSEG-HISTPRE ' . */
            _.Display($"- COSSEG-HISTPRE ");

            /*" -951- DISPLAY ' .LIDOS......... ' AC-L-COSSEGHIS. */
            _.Display($" .LIDOS......... {AREA_DE_WORK.AC_L_COSSEGHIS}");

            /*" -952- DISPLAY ' .ATUALIZADOS... ' AC-U-COSSEGHIS. */
            _.Display($" .ATUALIZADOS... {AREA_DE_WORK.AC_U_COSSEGHIS}");

            /*" -953- DISPLAY ' .INSERT........ ' AC-I-COSSEGHIS. */
            _.Display($" .INSERT........ {AREA_DE_WORK.AC_I_COSSEGHIS}");

            /*" -954- DISPLAY ' ' . */
            _.Display($" ");

            /*" -955- DISPLAY '- COSCED-CHEQUE  ' . */
            _.Display($"- COSCED-CHEQUE  ");

            /*" -956- DISPLAY ' .COMISSAO ACEL. ' AC-COMISSAO. */
            _.Display($" .COMISSAO ACEL. {AREA_DE_WORK.AC_COMISSAO}");

            /*" -957- DISPLAY ' .COM ACEL 6668. ' AC-COMISSAO-6668. */
            _.Display($" .COM ACEL 6668. {AREA_DE_WORK.AC_COMISSAO_6668}");

            /*" -957- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V1MOEDA-SECTION */
        private void R1100_00_SELECT_V1MOEDA_SECTION()
        {
            /*" -970- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WABEND.WNR_EXEC_SQL);

            /*" -980- PERFORM R1100_00_SELECT_V1MOEDA_DB_SELECT_1 */

            R1100_00_SELECT_V1MOEDA_DB_SELECT_1();

            /*" -983- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -984- DISPLAY 'R1100 - ERRO NO SELECT DA V1MOEDA' */
                _.Display($"R1100 - ERRO NO SELECT DA V1MOEDA");

                /*" -985- DISPLAY 'EMPRESA   - ' V1CHIS-COD-EMPR */
                _.Display($"EMPRESA   - {V1CHIS_COD_EMPR}");

                /*" -986- DISPLAY 'COD CONG  - ' V1CHIS-CONGENER */
                _.Display($"COD CONG  - {V1CHIS_CONGENER}");

                /*" -987- DISPLAY 'APOLICE   - ' V1CHIS-NUM-APOL */
                _.Display($"APOLICE   - {V1CHIS_NUM_APOL}");

                /*" -988- DISPLAY 'ENDOSSO   - ' V1CHIS-NUM-ENDS */
                _.Display($"ENDOSSO   - {V1CHIS_NUM_ENDS}");

                /*" -989- DISPLAY 'COD MOEDA - ' V1MOED-CODUNIMO */
                _.Display($"COD MOEDA - {V1MOED_CODUNIMO}");

                /*" -990- DISPLAY 'INIC VIGC - ' V1MOED-DTINIVIG */
                _.Display($"INIC VIGC - {V1MOED_DTINIVIG}");

                /*" -991- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -991- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-V1MOEDA-DB-SELECT-1 */
        public void R1100_00_SELECT_V1MOEDA_DB_SELECT_1()
        {
            /*" -980- EXEC SQL SELECT VAL_VENDA INTO :V1MOED-VLCRUZAD FROM SEGUROS.V1COTACAO WHERE CODUNIMO = :V1MOED-CODUNIMO AND DTINIVIG <= :V1MOED-DTINIVIG AND DTTERVIG >= :V1MOED-DTINIVIG END-EXEC. */

            var r1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 = new R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1()
            {
                V1MOED_CODUNIMO = V1MOED_CODUNIMO.ToString(),
                V1MOED_DTINIVIG = V1MOED_DTINIVIG.ToString(),
            };

            var executed_1 = R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MOED_VLCRUZAD, V1MOED_VLCRUZAD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-DELETE-V0RELATORIOS-SECTION */
        private void R1200_00_DELETE_V0RELATORIOS_SECTION()
        {
            /*" -1004- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -1012- PERFORM R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1 */

            R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1();

            /*" -1015- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1016- DISPLAY 'R1200 - ERRO NO DELETE DA V0RELATORIOS' */
                _.Display($"R1200 - ERRO NO DELETE DA V0RELATORIOS");

                /*" -1017- DISPLAY 'COD USUARIO - ' V1RELA-COD-USU */
                _.Display($"COD USUARIO - {V1RELA_COD_USU}");

                /*" -1018- DISPLAY 'DAT SOLICIT - ' V1RELA-DATA-SOL */
                _.Display($"DAT SOLICIT - {V1RELA_DATA_SOL}");

                /*" -1019- DISPLAY 'IDE SISTEMA - ' V1RELA-IDSISTEM */
                _.Display($"IDE SISTEMA - {V1RELA_IDSISTEM}");

                /*" -1020- DISPLAY 'COD RELAT   - ' V1RELA-CODRELAT */
                _.Display($"COD RELAT   - {V1RELA_CODRELAT}");

                /*" -1021- DISPLAY 'COD EMPRESA - ' V1RELA-COD-EMPR */
                _.Display($"COD EMPRESA - {V1RELA_COD_EMPR}");

                /*" -1022- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1022- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-DELETE-V0RELATORIOS-DB-DELETE-1 */
        public void R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1()
        {
            /*" -1012- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE CODUSU = :V1RELA-COD-USU AND DATA_SOLICITACAO = :V1RELA-DATA-SOL AND IDSISTEM = :V1RELA-IDSISTEM AND CODRELAT = :V1RELA-CODRELAT AND COD_EMPRESA = :V1RELA-COD-EMPR END-EXEC. */

            var r1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 = new R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1()
            {
                V1RELA_COD_USU = V1RELA_COD_USU.ToString(),
                V1RELA_DATA_SOL = V1RELA_DATA_SOL.ToString(),
                V1RELA_IDSISTEM = V1RELA_IDSISTEM.ToString(),
                V1RELA_CODRELAT = V1RELA_CODRELAT.ToString(),
                V1RELA_COD_EMPR = V1RELA_COD_EMPR.ToString(),
            };

            R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1.Execute(r1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-PROCESSA-SOLICITACAO-SECTION */
        private void R1300_00_PROCESSA_SOLICITACAO_SECTION()
        {
            /*" -1035- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -1041- MOVE ZEROS TO AC-L-COSSEGPRE AC-U-COSSEGPRE AC-L-COSSEGHIS AC-U-COSSEGHIS AC-I-COSSEGHIS. */
            _.Move(0, AREA_DE_WORK.AC_L_COSSEGPRE, AREA_DE_WORK.AC_U_COSSEGPRE, AREA_DE_WORK.AC_L_COSSEGHIS, AREA_DE_WORK.AC_U_COSSEGHIS, AREA_DE_WORK.AC_I_COSSEGHIS);

            /*" -1044- MOVE ZEROS TO AC-COMISSAO AC-COMISSAO-6668. */
            _.Move(0, AREA_DE_WORK.AC_COMISSAO, AREA_DE_WORK.AC_COMISSAO_6668);

            /*" -1046- MOVE SPACES TO WHOST-DTMOVTO. */
            _.Move("", WHOST_DTMOVTO);

            /*" -1047- DISPLAY 'COD. USUARIO - ' V1RELA-COD-USU. */
            _.Display($"COD. USUARIO - {V1RELA_COD_USU}");

            /*" -1049- DISPLAY 'CONGENERE    - ' V1RELA-CONGENER. */
            _.Display($"CONGENERE    - {V1RELA_CONGENER}");

            /*" -1051- PERFORM R1400-00-SELECT-V0COSCED-CHQ. */

            R1400_00_SELECT_V0COSCED_CHQ_SECTION();

            /*" -1054- DISPLAY 'PERIODO      - ' WHOST-DTMOVTO ' A ' V1RELA-DATA-REF. */

            $"PERIODO      - {WHOST_DTMOVTO} A {V1RELA_DATA_REF}"
            .Display();

            /*" -1055- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -1056- MOVE WHH-ACCEPT TO WHH-EDT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WHH_EDT);

            /*" -1057- MOVE WMM-ACCEPT TO WMM-EDT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WMM_EDT);

            /*" -1058- MOVE WSS-ACCEPT TO WSS-EDT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WSS_EDT);

            /*" -1060- DISPLAY 'INICIO  DECLARE -  V1COSSEGHIS ' WHORA-EDIT. */
            _.Display($"INICIO  DECLARE -  V1COSSEGHIS {AREA_DE_WORK.WHORA_EDIT}");

            /*" -1062- PERFORM R1500-00-DECLARE-V1COSSEGHIS. */

            R1500_00_DECLARE_V1COSSEGHIS_SECTION();

            /*" -1063- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -1064- MOVE WHH-ACCEPT TO WHH-EDT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WHH_EDT);

            /*" -1065- MOVE WMM-ACCEPT TO WMM-EDT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WMM_EDT);

            /*" -1066- MOVE WSS-ACCEPT TO WSS-EDT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WSS_EDT);

            /*" -1068- DISPLAY 'FINAL   DECLARE -  V1COSSEGHIS ' WHORA-EDIT. */
            _.Display($"FINAL   DECLARE -  V1COSSEGHIS {AREA_DE_WORK.WHORA_EDIT}");

            /*" -1070- PERFORM R1550-00-FETCH-V1COSSEGHIS. */

            R1550_00_FETCH_V1COSSEGHIS_SECTION();

            /*" -1071- IF WFIM-V1COSSEGHIS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1COSSEGHIS.IsEmpty())
            {

                /*" -1072- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -1073- GO TO R1300-90-LER-V1RELATORIOS */

                R1300_90_LER_V1RELATORIOS(); //GOTO
                return;

                /*" -1075- END-IF. */
            }


            /*" -1077- IF V1RELA-CODUNIMO GREATER ZEROS AND V1RELA-PERI-INI NOT EQUAL '0001-01-01' */

            if (V1RELA_CODUNIMO > 00 && V1RELA_PERI_INI != "0001-01-01")
            {

                /*" -1078- MOVE V1RELA-CODUNIMO TO V1MOED-CODUNIMO */
                _.Move(V1RELA_CODUNIMO, V1MOED_CODUNIMO);

                /*" -1079- MOVE V1RELA-PERI-INI TO V1MOED-DTINIVIG */
                _.Move(V1RELA_PERI_INI, V1MOED_DTINIVIG);

                /*" -1080- PERFORM R1100-00-SELECT-V1MOEDA */

                R1100_00_SELECT_V1MOEDA_SECTION();

                /*" -1081- MOVE V1MOED-VLCRUZAD TO WHOST-VLCRUZAD1 */
                _.Move(V1MOED_VLCRUZAD, WHOST_VLCRUZAD1);

                /*" -1083- END-IF. */
            }


            /*" -1086- PERFORM R1600-00-PROCESSA-DOCUMENTO UNTIL WFIM-V1COSSEGHIS NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1COSSEGHIS.IsEmpty()))
            {

                R1600_00_PROCESSA_DOCUMENTO_SECTION();
            }

            /*" -1088- PERFORM R3000-00-MONTA-COSCED-CHEQUE. */

            R3000_00_MONTA_COSCED_CHEQUE_SECTION();

            /*" -1089- DISPLAY '**** AC0815B ****' . */
            _.Display($"**** AC0815B ****");

            /*" -1090- DISPLAY '- COSSEG-PREM    ' . */
            _.Display($"- COSSEG-PREM    ");

            /*" -1091- DISPLAY ' .LIDOS......... ' AC-L-COSSEGPRE. */
            _.Display($" .LIDOS......... {AREA_DE_WORK.AC_L_COSSEGPRE}");

            /*" -1092- DISPLAY ' .ATUALIZADOS... ' AC-U-COSSEGPRE. */
            _.Display($" .ATUALIZADOS... {AREA_DE_WORK.AC_U_COSSEGPRE}");

            /*" -1093- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1094- DISPLAY '- COSSEG-HISTPRE ' . */
            _.Display($"- COSSEG-HISTPRE ");

            /*" -1095- DISPLAY ' .LIDOS......... ' AC-L-COSSEGHIS. */
            _.Display($" .LIDOS......... {AREA_DE_WORK.AC_L_COSSEGHIS}");

            /*" -1096- DISPLAY ' .ATUALIZADOS... ' AC-U-COSSEGHIS. */
            _.Display($" .ATUALIZADOS... {AREA_DE_WORK.AC_U_COSSEGHIS}");

            /*" -1097- DISPLAY ' .INSERT........ ' AC-I-COSSEGHIS. */
            _.Display($" .INSERT........ {AREA_DE_WORK.AC_I_COSSEGHIS}");

            /*" -1098- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1099- DISPLAY '- COSCED-CHEQUE  ' . */
            _.Display($"- COSCED-CHEQUE  ");

            /*" -1100- DISPLAY ' .COMISSAO ACEL. ' AC-COMISSAO. */
            _.Display($" .COMISSAO ACEL. {AREA_DE_WORK.AC_COMISSAO}");

            /*" -1101- DISPLAY ' .COM ACEL 6668. ' AC-COMISSAO-6668. */
            _.Display($" .COM ACEL 6668. {AREA_DE_WORK.AC_COMISSAO_6668}");

            /*" -1101- DISPLAY ' ' . */
            _.Display($" ");

            /*" -0- FLUXCONTROL_PERFORM R1300_90_LER_V1RELATORIOS */

            R1300_90_LER_V1RELATORIOS();

        }

        [StopWatch]
        /*" R1300-90-LER-V1RELATORIOS */
        private void R1300_90_LER_V1RELATORIOS(bool isPerform = false)
        {
            /*" -1107- PERFORM R3500-00-DELETE-V0RELATORIOS. */

            R3500_00_DELETE_V0RELATORIOS_SECTION();

            /*" -1107- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1111- PERFORM R0200-00-DECLARE-V1RELATORIOS. */

            R0200_00_DECLARE_V1RELATORIOS_SECTION();

            /*" -1111- PERFORM R0250-00-FETCH-V1RELATORIOS. */

            R0250_00_FETCH_V1RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-V0COSCED-CHQ-SECTION */
        private void R1400_00_SELECT_V0COSCED_CHQ_SECTION()
        {
            /*" -1124- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", WABEND.WNR_EXEC_SQL);

            /*" -1132- PERFORM R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1 */

            R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1();

            /*" -1135- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1136- DISPLAY 'R1400 - ERRO DE SELECT NA V0COSCED_CHEQUE' */
                _.Display($"R1400 - ERRO DE SELECT NA V0COSCED_CHEQUE");

                /*" -1137- DISPLAY 'EMPRESA  - ' V1RELA-COD-EMPR */
                _.Display($"EMPRESA  - {V1RELA_COD_EMPR}");

                /*" -1138- DISPLAY 'COD CONG - ' V1RELA-CONGENER */
                _.Display($"COD CONG - {V1RELA_CONGENER}");

                /*" -1139- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1140- ELSE */
            }
            else
            {


                /*" -1141- IF VIND-DTLIBERA < ZEROS */

                if (VIND_DTLIBERA < 00)
                {

                    /*" -1142- MOVE '1990-01-01' TO WHOST-DTMOVTO */
                    _.Move("1990-01-01", WHOST_DTMOVTO);

                    /*" -1143- ELSE */
                }
                else
                {


                    /*" -1144- MOVE V1CCHQ-DTLIBERA TO WHOST-DTMOVTO */
                    _.Move(V1CCHQ_DTLIBERA, WHOST_DTMOVTO);

                    /*" -1145- END-IF */
                }


                /*" -1145- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-V0COSCED-CHQ-DB-SELECT-1 */
        public void R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1()
        {
            /*" -1132- EXEC SQL SELECT MAX(DTLIBERA) INTO :V1CCHQ-DTLIBERA:VIND-DTLIBERA FROM SEGUROS.V0COSCED_CHEQUE WHERE COD_EMPRESA = :V1RELA-COD-EMPR AND CONGENER = :V1RELA-CONGENER AND DTMOVTO_AC < :V1SIST-DTMOVABE AND SITUACAO <> '2' END-EXEC. */

            var r1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1 = new R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1()
            {
                V1RELA_COD_EMPR = V1RELA_COD_EMPR.ToString(),
                V1RELA_CONGENER = V1RELA_CONGENER.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            var executed_1 = R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CCHQ_DTLIBERA, V1CCHQ_DTLIBERA);
                _.Move(executed_1.VIND_DTLIBERA, VIND_DTLIBERA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-DECLARE-V1COSSEGHIS-SECTION */
        private void R1500_00_DECLARE_V1COSSEGHIS_SECTION()
        {
            /*" -1158- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WABEND.WNR_EXEC_SQL);

            /*" -1195- PERFORM R1500_00_DECLARE_V1COSSEGHIS_DB_DECLARE_1 */

            R1500_00_DECLARE_V1COSSEGHIS_DB_DECLARE_1();

            /*" -1197- PERFORM R1500_00_DECLARE_V1COSSEGHIS_DB_OPEN_1 */

            R1500_00_DECLARE_V1COSSEGHIS_DB_OPEN_1();

            /*" -1200- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1201- DISPLAY 'R1500 - ERRO NO DECLARE DA V1COSSEG_HISTPRE' */
                _.Display($"R1500 - ERRO NO DECLARE DA V1COSSEG_HISTPRE");

                /*" -1202- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1203- ELSE */
            }
            else
            {


                /*" -1204- MOVE SPACES TO WFIM-V1COSSEGHIS */
                _.Move("", AREA_DE_WORK.WFIM_V1COSSEGHIS);

                /*" -1204- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-00-DECLARE-V1COSSEGHIS-DB-OPEN-1 */
        public void R1500_00_DECLARE_V1COSSEGHIS_DB_OPEN_1()
        {
            /*" -1197- EXEC SQL OPEN V1COSSEGHIS END-EXEC. */

            V1COSSEGHIS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1550-00-FETCH-V1COSSEGHIS-SECTION */
        private void R1550_00_FETCH_V1COSSEGHIS_SECTION()
        {
            /*" -1215- MOVE '155' TO WNR-EXEC-SQL. */
            _.Move("155", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R1550_10_LER_V1COSSEGHIS */

            R1550_10_LER_V1COSSEGHIS();

        }

        [StopWatch]
        /*" R1550-10-LER-V1COSSEGHIS */
        private void R1550_10_LER_V1COSSEGHIS(bool isPerform = false)
        {
            /*" -1237- PERFORM R1550_10_LER_V1COSSEGHIS_DB_FETCH_1 */

            R1550_10_LER_V1COSSEGHIS_DB_FETCH_1();

            /*" -1240- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1241- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1242- MOVE 'S' TO WFIM-V1COSSEGHIS */
                    _.Move("S", AREA_DE_WORK.WFIM_V1COSSEGHIS);

                    /*" -1242- PERFORM R1550_10_LER_V1COSSEGHIS_DB_CLOSE_1 */

                    R1550_10_LER_V1COSSEGHIS_DB_CLOSE_1();

                    /*" -1244- ELSE */
                }
                else
                {


                    /*" -1245- DISPLAY 'R1550 - ERRO NO FETCH DA V1COSSEG_HISTPRE' */
                    _.Display($"R1550 - ERRO NO FETCH DA V1COSSEG_HISTPRE");

                    /*" -1246- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1247- END-IF */
                }


                /*" -1248- ELSE */
            }
            else
            {


                /*" -1249- IF VIND-DAT-QTBC < ZEROS */

                if (VIND_DAT_QTBC < 00)
                {

                    /*" -1250- MOVE SPACES TO V1CHIS-DTQITBCO */
                    _.Move("", V1CHIS_DTQITBCO);

                    /*" -1251- END-IF */
                }


                /*" -1252- PERFORM R0900-00-SELECT-V0ENDOSSO */

                R0900_00_SELECT_V0ENDOSSO_SECTION();

                /*" -1253- IF V0ENDO-QTPARCEL < 02 */

                if (V0ENDO_QTPARCEL < 02)
                {

                    /*" -1254- GO TO R1550-10-LER-V1COSSEGHIS */
                    new Task(() => R1550_10_LER_V1COSSEGHIS()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1255- ELSE */
                }
                else
                {


                    /*" -1256- IF V0ENDO-CDFRACIO < 01 */

                    if (V0ENDO_CDFRACIO < 01)
                    {

                        /*" -1257- GO TO R1550-10-LER-V1COSSEGHIS */
                        new Task(() => R1550_10_LER_V1COSSEGHIS()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1258- END-IF */
                    }


                    /*" -1259- END-IF */
                }


                /*" -1259- END-IF. */
            }


        }

        [StopWatch]
        /*" R1550-10-LER-V1COSSEGHIS-DB-FETCH-1 */
        public void R1550_10_LER_V1COSSEGHIS_DB_FETCH_1()
        {
            /*" -1237- EXEC SQL FETCH V1COSSEGHIS INTO :V1CHIS-COD-EMPR , :V1CHIS-CONGENER , :V1CHIS-NUM-APOL , :V1CHIS-NUM-ENDS , :V1CHIS-NRPARCEL , :V1CHIS-OCORHIST , :V1CHIS-OPERACAO , :V1CHIS-TIP-SEGU , :V1CHIS-PRM-TARF , :V1CHIS-VAL-DESC , :V1CHIS-VLPRMLIQ , :V1CHIS-VLADIFRA , :V1CHIS-VLCOMISS , :V1CHIS-VLPRMTOT , :V1CHIS-DAT-MOVT , :V1CHIS-DTQITBCO:VIND-DAT-QTBC, :V1CHIS-NUM-OCOR:VIND-NUM-OCOR END-EXEC. */

            if (V1COSSEGHIS.Fetch())
            {
                _.Move(V1COSSEGHIS.V1CHIS_COD_EMPR, V1CHIS_COD_EMPR);
                _.Move(V1COSSEGHIS.V1CHIS_CONGENER, V1CHIS_CONGENER);
                _.Move(V1COSSEGHIS.V1CHIS_NUM_APOL, V1CHIS_NUM_APOL);
                _.Move(V1COSSEGHIS.V1CHIS_NUM_ENDS, V1CHIS_NUM_ENDS);
                _.Move(V1COSSEGHIS.V1CHIS_NRPARCEL, V1CHIS_NRPARCEL);
                _.Move(V1COSSEGHIS.V1CHIS_OCORHIST, V1CHIS_OCORHIST);
                _.Move(V1COSSEGHIS.V1CHIS_OPERACAO, V1CHIS_OPERACAO);
                _.Move(V1COSSEGHIS.V1CHIS_TIP_SEGU, V1CHIS_TIP_SEGU);
                _.Move(V1COSSEGHIS.V1CHIS_PRM_TARF, V1CHIS_PRM_TARF);
                _.Move(V1COSSEGHIS.V1CHIS_VAL_DESC, V1CHIS_VAL_DESC);
                _.Move(V1COSSEGHIS.V1CHIS_VLPRMLIQ, V1CHIS_VLPRMLIQ);
                _.Move(V1COSSEGHIS.V1CHIS_VLADIFRA, V1CHIS_VLADIFRA);
                _.Move(V1COSSEGHIS.V1CHIS_VLCOMISS, V1CHIS_VLCOMISS);
                _.Move(V1COSSEGHIS.V1CHIS_VLPRMTOT, V1CHIS_VLPRMTOT);
                _.Move(V1COSSEGHIS.V1CHIS_DAT_MOVT, V1CHIS_DAT_MOVT);
                _.Move(V1COSSEGHIS.V1CHIS_DTQITBCO, V1CHIS_DTQITBCO);
                _.Move(V1COSSEGHIS.VIND_DAT_QTBC, VIND_DAT_QTBC);
                _.Move(V1COSSEGHIS.V1CHIS_NUM_OCOR, V1CHIS_NUM_OCOR);
                _.Move(V1COSSEGHIS.VIND_NUM_OCOR, VIND_NUM_OCOR);
            }

        }

        [StopWatch]
        /*" R1550-10-LER-V1COSSEGHIS-DB-CLOSE-1 */
        public void R1550_10_LER_V1COSSEGHIS_DB_CLOSE_1()
        {
            /*" -1242- EXEC SQL CLOSE V1COSSEGHIS END-EXEC */

            V1COSSEGHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1550_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-PROCESSA-DOCUMENTO-SECTION */
        private void R1600_00_PROCESSA_DOCUMENTO_SECTION()
        {
            /*" -1272- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", WABEND.WNR_EXEC_SQL);

            /*" -1273- MOVE V1CHIS-NUM-APOL TO WNUM-APOL-ANT. */
            _.Move(V1CHIS_NUM_APOL, AREA_DE_WORK.WNUM_APOL_ANT);

            /*" -1277- MOVE V1CHIS-NUM-ENDS TO WNUM-ENDS-ANT. */
            _.Move(V1CHIS_NUM_ENDS, AREA_DE_WORK.WNUM_ENDS_ANT);

            /*" -1279- MOVE ZEROS TO WHOST-VLCRUZAD2. */
            _.Move(0, WHOST_VLCRUZAD2);

            /*" -1280- IF V1RELA-PERI-INI NOT EQUAL '0001-01-01' */

            if (V1RELA_PERI_INI != "0001-01-01")
            {

                /*" -1281- IF V0ENDO-CORRECAO EQUAL '2' OR '4' */

                if (V0ENDO_CORRECAO.In("2", "4"))
                {

                    /*" -1282- MOVE V0ENDO-MOEDA-PRM TO V1MOED-CODUNIMO */
                    _.Move(V0ENDO_MOEDA_PRM, V1MOED_CODUNIMO);

                    /*" -1283- MOVE V1RELA-PERI-INI TO V1MOED-DTINIVIG */
                    _.Move(V1RELA_PERI_INI, V1MOED_DTINIVIG);

                    /*" -1284- PERFORM R1100-00-SELECT-V1MOEDA */

                    R1100_00_SELECT_V1MOEDA_SECTION();

                    /*" -1285- MOVE V1MOED-VLCRUZAD TO WHOST-VLCRUZAD2 */
                    _.Move(V1MOED_VLCRUZAD, WHOST_VLCRUZAD2);

                    /*" -1286- END-IF */
                }


                /*" -1290- END-IF. */
            }


            /*" -1291- IF V0ENDO-QTPARCEL < 02 */

            if (V0ENDO_QTPARCEL < 02)
            {

                /*" -1292- GO TO R1600-90-LER-REGISTRO */

                R1600_90_LER_REGISTRO(); //GOTO
                return;

                /*" -1293- ELSE */
            }
            else
            {


                /*" -1294- IF V0ENDO-CDFRACIO = ZEROS */

                if (V0ENDO_CDFRACIO == 00)
                {

                    /*" -1295- GO TO R1600-90-LER-REGISTRO */

                    R1600_90_LER_REGISTRO(); //GOTO
                    return;

                    /*" -1296- END-IF */
                }


                /*" -1300- END-IF. */
            }


            /*" -1302- PERFORM R1700-00-SELECT-V1COSSEGPRE. */

            R1700_00_SELECT_V1COSSEGPRE_SECTION();

            /*" -1303- IF V1CPRE-SIT-CONG NOT EQUAL '1' */

            if (V1CPRE_SIT_CONG != "1")
            {

                /*" -1304- GO TO R1600-90-LER-REGISTRO */

                R1600_90_LER_REGISTRO(); //GOTO
                return;

                /*" -1306- END-IF. */
            }


            /*" -1308- PERFORM R1800-00-SELECT-V1COSSEGHISP. */

            R1800_00_SELECT_V1COSSEGHISP_SECTION();

            /*" -1309- IF WHOST-DTMOVTO-EM < '1994-12-01' */

            if (WHOST_DTMOVTO_EM < "1994-12-01")
            {

                /*" -1310- GO TO R1600-90-LER-REGISTRO */

                R1600_90_LER_REGISTRO(); //GOTO
                return;

                /*" -1312- END-IF. */
            }


            /*" -1314- PERFORM R1900-00-SELECT-V1APOLCOSCED. */

            R1900_00_SELECT_V1APOLCOSCED_SECTION();

            /*" -1323- MOVE ZEROS TO WVLR-PRMTAR-CM WVLR-DESCTO-CM WVLR-PRMLIQ-CM WVLR-ADIFRA-CM WVLR-COMISS-CM WVLR-PRMTOT-CM. */
            _.Move(0, AREA_DE_WORK.WVLR_PRMTAR_CM, AREA_DE_WORK.WVLR_DESCTO_CM, AREA_DE_WORK.WVLR_PRMLIQ_CM, AREA_DE_WORK.WVLR_ADIFRA_CM, AREA_DE_WORK.WVLR_COMISS_CM, AREA_DE_WORK.WVLR_PRMTOT_CM);

            /*" -1324- MOVE V1CHIS-COD-EMPR TO V0CHIS-COD-EMPR. */
            _.Move(V1CHIS_COD_EMPR, V0CHIS_COD_EMPR);

            /*" -1325- MOVE V1CHIS-CONGENER TO V0CHIS-CONGENER. */
            _.Move(V1CHIS_CONGENER, V0CHIS_CONGENER);

            /*" -1326- MOVE V1CHIS-NUM-APOL TO V0CHIS-NUM-APOL. */
            _.Move(V1CHIS_NUM_APOL, V0CHIS_NUM_APOL);

            /*" -1327- MOVE V1CHIS-NUM-ENDS TO V0CHIS-NUM-ENDS. */
            _.Move(V1CHIS_NUM_ENDS, V0CHIS_NUM_ENDS);

            /*" -1328- MOVE V1CHIS-NRPARCEL TO V0CHIS-NRPARCEL. */
            _.Move(V1CHIS_NRPARCEL, V0CHIS_NRPARCEL);

            /*" -1329- MOVE V1SIST-DTMOVABE TO V0CHIS-DAT-MOVT. */
            _.Move(V1SIST_DTMOVABE, V0CHIS_DAT_MOVT);

            /*" -1331- MOVE '1' TO V0CHIS-TIP-SEGU. */
            _.Move("1", V0CHIS_TIP_SEGU);

            /*" -1332- MOVE SPACES TO V0CHIS-DTQITBCO. */
            _.Move("", V0CHIS_DTQITBCO);

            /*" -1334- MOVE -1 TO VIND-DTQITBCO. */
            _.Move(-1, VIND_DTQITBCO);

            /*" -1335- MOVE '0' TO V0CHIS-SIT-LIBR. */
            _.Move("0", V0CHIS_SIT_LIBR);

            /*" -1337- MOVE +1 TO VIND-SIT-LIBR. */
            _.Move(+1, VIND_SIT_LIBR);

            /*" -1338- MOVE V1CHIS-NUM-OCOR TO V0CHIS-NUM-OCOR. */
            _.Move(V1CHIS_NUM_OCOR, V0CHIS_NUM_OCOR);

            /*" -1342- MOVE +1 TO VIND-NUM-OCOR. */
            _.Move(+1, VIND_NUM_OCOR);

            /*" -1346- PERFORM R2000-00-SELECT-V1COSSEG-PREM. */

            R2000_00_SELECT_V1COSSEG_PREM_SECTION();

            /*" -1347- IF V1CHIS-OPERACAO GREATER 599 */

            if (V1CHIS_OPERACAO > 599)
            {

                /*" -1348- PERFORM R2100-00-OPERACAO-ORIGINAL */

                R2100_00_OPERACAO_ORIGINAL_SECTION();

                /*" -1350- END-IF. */
            }


            /*" -1357- COMPUTE V1CHIS-VLCOMISS ROUNDED = (V1CHIS-VLPRMLIQ + V1CHIS-VLADIFRA) * V1APCC-PCCOMCOS / 100. */
            V1CHIS_VLCOMISS.Value = (V1CHIS_VLPRMLIQ + V1CHIS_VLADIFRA) * V1APCC_PCCOMCOS / 100f;

            /*" -1358- IF V1CHIS-OPERACAO GREATER 599 */

            if (V1CHIS_OPERACAO > 599)
            {

                /*" -1360- COMPUTE V2CHIS-OPERACAO = V1CHIS-OPERACAO - 140 */
                V2CHIS_OPERACAO.Value = V1CHIS_OPERACAO - 140;

                /*" -1361- ELSE */
            }
            else
            {


                /*" -1362- IF V0ENDO-TIPO-ENDO EQUAL '3' OR '5' */

                if (V0ENDO_TIPO_ENDO.In("3", "5"))
                {

                    /*" -1363- IF V1CHIS-OPERACAO GREATER 499 */

                    if (V1CHIS_OPERACAO > 499)
                    {

                        /*" -1364- MOVE 841 TO V2CHIS-OPERACAO */
                        _.Move(841, V2CHIS_OPERACAO);

                        /*" -1365- ELSE */
                    }
                    else
                    {


                        /*" -1366- MOVE 831 TO V2CHIS-OPERACAO */
                        _.Move(831, V2CHIS_OPERACAO);

                        /*" -1367- ELSE */
                    }

                }
                else
                {


                    /*" -1368- IF V1CHIS-OPERACAO GREATER 499 */

                    if (V1CHIS_OPERACAO > 499)
                    {

                        /*" -1369- MOVE 840 TO V2CHIS-OPERACAO */
                        _.Move(840, V2CHIS_OPERACAO);

                        /*" -1370- ELSE */
                    }
                    else
                    {


                        /*" -1374- MOVE 830 TO V2CHIS-OPERACAO. */
                        _.Move(830, V2CHIS_OPERACAO);
                    }

                }

            }


            /*" -1375- IF V1RELA-PERI-INI NOT EQUAL '0001-01-01' */

            if (V1RELA_PERI_INI != "0001-01-01")
            {

                /*" -1376- IF V0ENDO-CORRECAO EQUAL '2' OR '4' */

                if (V0ENDO_CORRECAO.In("2", "4"))
                {

                    /*" -1377- PERFORM R2200-00-CALC-CORR-INDEX */

                    R2200_00_CALC_CORR_INDEX_SECTION();

                    /*" -1378- PERFORM R2300-00-MONTA-CORRECAO */

                    R2300_00_MONTA_CORRECAO_SECTION();

                    /*" -1379- ELSE */
                }
                else
                {


                    /*" -1380- IF V1RELA-CODUNIMO NOT EQUAL ZEROS */

                    if (V1RELA_CODUNIMO != 00)
                    {

                        /*" -1381- PERFORM R2400-00-CALC-CORR-NINDEX */

                        R2400_00_CALC_CORR_NINDEX_SECTION();

                        /*" -1382- PERFORM R2300-00-MONTA-CORRECAO */

                        R2300_00_MONTA_CORRECAO_SECTION();

                        /*" -1383- END-IF */
                    }


                    /*" -1384- END-IF */
                }


                /*" -1388- END-IF. */
            }


            /*" -1390- MOVE V2CHIS-OPERACAO TO V0CHIS-OPERACAO. */
            _.Move(V2CHIS_OPERACAO, V0CHIS_OPERACAO);

            /*" -1392- MOVE WVLR-COMISS-CM TO V0CHIS-VLCOMISS. */
            _.Move(AREA_DE_WORK.WVLR_COMISS_CM, V0CHIS_VLCOMISS);

            /*" -1395- COMPUTE V0CHIS-VLPRMTOT = WVLR-COMISS-CM * -1. */
            V0CHIS_VLPRMTOT.Value = AREA_DE_WORK.WVLR_COMISS_CM * -1;

            /*" -1396- IF V0CHIS-VLPRMTOT NOT EQUAL ZEROS */

            if (V0CHIS_VLPRMTOT != 00)
            {

                /*" -1397- ADD +1 TO V1CPRE-OCORHIST */
                V1CPRE_OCORHIST.Value = V1CPRE_OCORHIST + +1;

                /*" -1399- MOVE V1CPRE-OCORHIST TO V0CHIS-OCORHIST */
                _.Move(V1CPRE_OCORHIST, V0CHIS_OCORHIST);

                /*" -1400- MOVE '0' TO V0CHIS-SIT-FINC */
                _.Move("0", V0CHIS_SIT_FINC);

                /*" -1402- MOVE +1 TO VIND-SIT-FINC */
                _.Move(+1, VIND_SIT_FINC);

                /*" -1403- PERFORM R2600-00-INSERT-COSSEGHIS */

                R2600_00_INSERT_COSSEGHIS_SECTION();

                /*" -1407- END-IF. */
            }


            /*" -1408- ADD +1 TO V1CPRE-OCORHIST. */
            V1CPRE_OCORHIST.Value = V1CPRE_OCORHIST + +1;

            /*" -1410- MOVE V1CPRE-OCORHIST TO V0CHIS-OCORHIST. */
            _.Move(V1CPRE_OCORHIST, V0CHIS_OCORHIST);

            /*" -1413- COMPUTE V0CHIS-OPERACAO = V2CHIS-OPERACAO + 100. */
            V0CHIS_OPERACAO.Value = V2CHIS_OPERACAO + 100;

            /*" -1415- MOVE V1CHIS-VLCOMISS TO V0CHIS-VLCOMISS. */
            _.Move(V1CHIS_VLCOMISS, V0CHIS_VLCOMISS);

            /*" -1418- COMPUTE V0CHIS-VLPRMTOT = V1CHIS-VLCOMISS * -1. */
            V0CHIS_VLPRMTOT.Value = V1CHIS_VLCOMISS * -1;

            /*" -1419- MOVE '1' TO V0CHIS-SIT-FINC. */
            _.Move("1", V0CHIS_SIT_FINC);

            /*" -1421- MOVE +1 TO VIND-SIT-FINC. */
            _.Move(+1, VIND_SIT_FINC);

            /*" -1423- PERFORM R2600-00-INSERT-COSSEGHIS. */

            R2600_00_INSERT_COSSEGHIS_SECTION();

            /*" -1424- IF V0CHIS-OPERACAO EQUAL 931 OR 940 */

            if (V0CHIS_OPERACAO.In("931", "940"))
            {

                /*" -1426- COMPUTE AC-COMISSAO = AC-COMISSAO + V0CHIS-VLCOMISS */
                AREA_DE_WORK.AC_COMISSAO.Value = AREA_DE_WORK.AC_COMISSAO + V0CHIS_VLCOMISS;

                /*" -1427- ELSE */
            }
            else
            {


                /*" -1429- COMPUTE AC-COMISSAO = AC-COMISSAO - V0CHIS-VLCOMISS */
                AREA_DE_WORK.AC_COMISSAO.Value = AREA_DE_WORK.AC_COMISSAO - V0CHIS_VLCOMISS;

                /*" -1431- END-IF. */
            }


            /*" -1433- IF V0CHIS-NUM-APOL EQUAL 66001000001 OR 106600000001 */

            if (V0CHIS_NUM_APOL.In("66001000001", "106600000001"))
            {

                /*" -1434- IF V0CHIS-OPERACAO EQUAL 931 OR 940 */

                if (V0CHIS_OPERACAO.In("931", "940"))
                {

                    /*" -1436- COMPUTE AC-COMISSAO-6668 = AC-COMISSAO-6668 + V0CHIS-VLCOMISS */
                    AREA_DE_WORK.AC_COMISSAO_6668.Value = AREA_DE_WORK.AC_COMISSAO_6668 + V0CHIS_VLCOMISS;

                    /*" -1437- ELSE */
                }
                else
                {


                    /*" -1439- COMPUTE AC-COMISSAO-6668 = AC-COMISSAO-6668 - V0CHIS-VLCOMISS */
                    AREA_DE_WORK.AC_COMISSAO_6668.Value = AREA_DE_WORK.AC_COMISSAO_6668 - V0CHIS_VLCOMISS;

                    /*" -1440- END-IF */
                }


                /*" -1442- END-IF. */
            }


            /*" -1444- PERFORM R2700-00-UPDATE-COSSEGPRE. */

            R2700_00_UPDATE_COSSEGPRE_SECTION();

            /*" -1444- PERFORM R2800-00-UPDATE-COSSEGHIS. */

            R2800_00_UPDATE_COSSEGHIS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1600_90_LER_REGISTRO */

            R1600_90_LER_REGISTRO();

        }

        [StopWatch]
        /*" R1600-90-LER-REGISTRO */
        private void R1600_90_LER_REGISTRO(bool isPerform = false)
        {
            /*" -1452- ADD 1 TO AC-L-COSSEGHIS. */
            AREA_DE_WORK.AC_L_COSSEGHIS.Value = AREA_DE_WORK.AC_L_COSSEGHIS + 1;

            /*" -1453- IF WTIP-SOLICIT = 0 */

            if (AREA_DE_WORK.WTIP_SOLICIT == 0)
            {

                /*" -1454- PERFORM R0850-00-FETCH-V1COSGHISTP */

                R0850_00_FETCH_V1COSGHISTP_SECTION();

                /*" -1455- ELSE */
            }
            else
            {


                /*" -1456- PERFORM R1550-00-FETCH-V1COSSEGHIS */

                R1550_00_FETCH_V1COSSEGHIS_SECTION();

                /*" -1456- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-SELECT-V1COSSEGPRE-SECTION */
        private void R1700_00_SELECT_V1COSSEGPRE_SECTION()
        {
            /*" -1469- MOVE '170' TO WNR-EXEC-SQL. */
            _.Move("170", WABEND.WNR_EXEC_SQL);

            /*" -1481- PERFORM R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1 */

            R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1();

            /*" -1484- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1485- DISPLAY 'R1700 - ERRO NO SELECT DA V1COSSEG_PREM' */
                _.Display($"R1700 - ERRO NO SELECT DA V1COSSEG_PREM");

                /*" -1486- DISPLAY 'EMPRESA  - ' V1CHIS-COD-EMPR */
                _.Display($"EMPRESA  - {V1CHIS_COD_EMPR}");

                /*" -1487- DISPLAY 'COD CONG - ' V1CHIS-CONGENER */
                _.Display($"COD CONG - {V1CHIS_CONGENER}");

                /*" -1488- DISPLAY 'APOLICE  - ' V1CHIS-NUM-APOL */
                _.Display($"APOLICE  - {V1CHIS_NUM_APOL}");

                /*" -1489- DISPLAY 'ENDOSSO  - ' V1CHIS-NUM-ENDS */
                _.Display($"ENDOSSO  - {V1CHIS_NUM_ENDS}");

                /*" -1490- DISPLAY 'PARCELA  - ' V1CHIS-NRPARCEL */
                _.Display($"PARCELA  - {V1CHIS_NRPARCEL}");

                /*" -1491- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1491- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-00-SELECT-V1COSSEGPRE-DB-SELECT-1 */
        public void R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1()
        {
            /*" -1481- EXEC SQL SELECT SIT_CONGENERE INTO :V1CPRE-SIT-CONG FROM SEGUROS.V1COSSEG_PREM WHERE CONGENER = :V1CHIS-CONGENER AND NUM_APOLICE = :V1CHIS-NUM-APOL AND NRENDOS = :V1CHIS-NUM-ENDS AND NRPARCEL = 01 AND TIPSGU = '1' END-EXEC. */

            var r1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1 = new R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1()
            {
                V1CHIS_CONGENER = V1CHIS_CONGENER.ToString(),
                V1CHIS_NUM_APOL = V1CHIS_NUM_APOL.ToString(),
                V1CHIS_NUM_ENDS = V1CHIS_NUM_ENDS.ToString(),
            };

            var executed_1 = R1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1.Execute(r1700_00_SELECT_V1COSSEGPRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CPRE_SIT_CONG, V1CPRE_SIT_CONG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-SELECT-V1COSSEGHISP-SECTION */
        private void R1800_00_SELECT_V1COSSEGHISP_SECTION()
        {
            /*" -1504- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", WABEND.WNR_EXEC_SQL);

            /*" -1518- PERFORM R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1 */

            R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1();

            /*" -1521- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1522- DISPLAY 'R1800 - ERRO NO SELECT DA V1COSSEG_HISTPRE' */
                _.Display($"R1800 - ERRO NO SELECT DA V1COSSEG_HISTPRE");

                /*" -1523- DISPLAY 'EMPRESA  - ' V1CHIS-COD-EMPR */
                _.Display($"EMPRESA  - {V1CHIS_COD_EMPR}");

                /*" -1524- DISPLAY 'COD CONG - ' V1CHIS-CONGENER */
                _.Display($"COD CONG - {V1CHIS_CONGENER}");

                /*" -1525- DISPLAY 'APOLICE  - ' V1CHIS-NUM-APOL */
                _.Display($"APOLICE  - {V1CHIS_NUM_APOL}");

                /*" -1526- DISPLAY 'ENDOSSO  - ' V1CHIS-NUM-ENDS */
                _.Display($"ENDOSSO  - {V1CHIS_NUM_ENDS}");

                /*" -1527- DISPLAY 'PARCELA  - ' V1CHIS-NRPARCEL */
                _.Display($"PARCELA  - {V1CHIS_NRPARCEL}");

                /*" -1528- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1528- END-IF. */
            }


        }

        [StopWatch]
        /*" R1800-00-SELECT-V1COSSEGHISP-DB-SELECT-1 */
        public void R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1()
        {
            /*" -1518- EXEC SQL SELECT DTMOVTO INTO :WHOST-DTMOVTO-EM FROM SEGUROS.V1COSSEG_HISTPRE WHERE CONGENER = :V1CHIS-CONGENER AND NUM_APOLICE = :V1CHIS-NUM-APOL AND NRENDOS = :V1CHIS-NUM-ENDS AND NRPARCEL = :V1CHIS-NRPARCEL AND OCORHIST = 01 AND OPERACAO < 0200 AND TIPSGU = '1' END-EXEC. */

            var r1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1 = new R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1()
            {
                V1CHIS_CONGENER = V1CHIS_CONGENER.ToString(),
                V1CHIS_NUM_APOL = V1CHIS_NUM_APOL.ToString(),
                V1CHIS_NUM_ENDS = V1CHIS_NUM_ENDS.ToString(),
                V1CHIS_NRPARCEL = V1CHIS_NRPARCEL.ToString(),
            };

            var executed_1 = R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1.Execute(r1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTMOVTO_EM, WHOST_DTMOVTO_EM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-SELECT-V1APOLCOSCED-SECTION */
        private void R1900_00_SELECT_V1APOLCOSCED_SECTION()
        {
            /*" -1541- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", WABEND.WNR_EXEC_SQL);

            /*" -1552- PERFORM R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1 */

            R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1();

            /*" -1555- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1556- DISPLAY 'R1900 - ERRO NO SELECT DA V1APOLCOSCED' */
                _.Display($"R1900 - ERRO NO SELECT DA V1APOLCOSCED");

                /*" -1557- DISPLAY 'EMPRESA  - ' V1CHIS-COD-EMPR */
                _.Display($"EMPRESA  - {V1CHIS_COD_EMPR}");

                /*" -1558- DISPLAY 'COD CONG - ' V1CHIS-CONGENER */
                _.Display($"COD CONG - {V1CHIS_CONGENER}");

                /*" -1559- DISPLAY 'APOLICE  - ' V1CHIS-NUM-APOL */
                _.Display($"APOLICE  - {V1CHIS_NUM_APOL}");

                /*" -1560- DISPLAY 'ENDOSSO  - ' V1CHIS-NUM-ENDS */
                _.Display($"ENDOSSO  - {V1CHIS_NUM_ENDS}");

                /*" -1561- DISPLAY 'PARCELA  - ' V1CHIS-NRPARCEL */
                _.Display($"PARCELA  - {V1CHIS_NRPARCEL}");

                /*" -1562- DISPLAY 'INIC VIG - ' V0ENDO-DTINIVIG */
                _.Display($"INIC VIG - {V0ENDO_DTINIVIG}");

                /*" -1563- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1563- END-IF. */
            }


        }

        [StopWatch]
        /*" R1900-00-SELECT-V1APOLCOSCED-DB-SELECT-1 */
        public void R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1()
        {
            /*" -1552- EXEC SQL SELECT PCCOMCOS INTO :V1APCC-PCCOMCOS FROM SEGUROS.V1APOLCOSCED WHERE NUM_APOLICE = :V1CHIS-NUM-APOL AND CODCOSS = :V1CHIS-CONGENER AND DTINIVIG <= :V0ENDO-DTINIVIG AND DTTERVIG >= :V0ENDO-DTINIVIG END-EXEC. */

            var r1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1 = new R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1()
            {
                V1CHIS_NUM_APOL = V1CHIS_NUM_APOL.ToString(),
                V1CHIS_CONGENER = V1CHIS_CONGENER.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1.Execute(r1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APCC_PCCOMCOS, V1APCC_PCCOMCOS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-SELECT-V1COSSEG-PREM-SECTION */
        private void R2000_00_SELECT_V1COSSEG_PREM_SECTION()
        {
            /*" -1576- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WABEND.WNR_EXEC_SQL);

            /*" -1600- PERFORM R2000_00_SELECT_V1COSSEG_PREM_DB_SELECT_1 */

            R2000_00_SELECT_V1COSSEG_PREM_DB_SELECT_1();

            /*" -1603- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1604- DISPLAY 'R2000 - ERRO NO SELECT DA V1COSSEG-PREM' */
                _.Display($"R2000 - ERRO NO SELECT DA V1COSSEG-PREM");

                /*" -1605- DISPLAY 'EMPRESA  - ' V1CHIS-COD-EMPR */
                _.Display($"EMPRESA  - {V1CHIS_COD_EMPR}");

                /*" -1606- DISPLAY 'COD CONG - ' V1CHIS-CONGENER */
                _.Display($"COD CONG - {V1CHIS_CONGENER}");

                /*" -1607- DISPLAY 'APOLICE  - ' V1CHIS-NUM-APOL */
                _.Display($"APOLICE  - {V1CHIS_NUM_APOL}");

                /*" -1608- DISPLAY 'ENDOSSO  - ' V1CHIS-NUM-ENDS */
                _.Display($"ENDOSSO  - {V1CHIS_NUM_ENDS}");

                /*" -1609- DISPLAY 'PARCELA  - ' V1CHIS-NRPARCEL */
                _.Display($"PARCELA  - {V1CHIS_NRPARCEL}");

                /*" -1610- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1610- END-IF. */
            }


        }

        [StopWatch]
        /*" R2000-00-SELECT-V1COSSEG-PREM-DB-SELECT-1 */
        public void R2000_00_SELECT_V1COSSEG_PREM_DB_SELECT_1()
        {
            /*" -1600- EXEC SQL SELECT OCORHIST , PRM_TARIFARIO_IX , VAL_DESCONTO_IX , OTNPRLIQ , OTNADFRA , VLCOMISIX , OTNTOTAL INTO :V1CPRE-OCORHIST , :V1CPRE-PRMTAR-IX , :V1CPRE-VLDESC-IX , :V1CPRE-OTNPRLIQ , :V1CPRE-OTNADFRA , :V1CPRE-VLCOMS-IX , :V1CPRE-OTNTOTAL FROM SEGUROS.V1COSSEG_PREM WHERE CONGENER = :V1CHIS-CONGENER AND NUM_APOLICE = :V1CHIS-NUM-APOL AND NRENDOS = :V1CHIS-NUM-ENDS AND NRPARCEL = :V1CHIS-NRPARCEL AND TIPSGU = '1' END-EXEC. */

            var r2000_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1 = new R2000_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1()
            {
                V1CHIS_CONGENER = V1CHIS_CONGENER.ToString(),
                V1CHIS_NUM_APOL = V1CHIS_NUM_APOL.ToString(),
                V1CHIS_NUM_ENDS = V1CHIS_NUM_ENDS.ToString(),
                V1CHIS_NRPARCEL = V1CHIS_NRPARCEL.ToString(),
            };

            var executed_1 = R2000_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1.Execute(r2000_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CPRE_OCORHIST, V1CPRE_OCORHIST);
                _.Move(executed_1.V1CPRE_PRMTAR_IX, V1CPRE_PRMTAR_IX);
                _.Move(executed_1.V1CPRE_VLDESC_IX, V1CPRE_VLDESC_IX);
                _.Move(executed_1.V1CPRE_OTNPRLIQ, V1CPRE_OTNPRLIQ);
                _.Move(executed_1.V1CPRE_OTNADFRA, V1CPRE_OTNADFRA);
                _.Move(executed_1.V1CPRE_VLCOMS_IX, V1CPRE_VLCOMS_IX);
                _.Move(executed_1.V1CPRE_OTNTOTAL, V1CPRE_OTNTOTAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-OPERACAO-ORIGINAL-SECTION */
        private void R2100_00_OPERACAO_ORIGINAL_SECTION()
        {
            /*" -1623- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WABEND.WNR_EXEC_SQL);

            /*" -1649- PERFORM R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1 */

            R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1();

            /*" -1652- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1653- DISPLAY 'R2100 - ERRO NO SELECT DA V0COSSEG_HISTPRE' */
                _.Display($"R2100 - ERRO NO SELECT DA V0COSSEG_HISTPRE");

                /*" -1654- DISPLAY 'EMPRESA  - ' V1CHIS-COD-EMPR */
                _.Display($"EMPRESA  - {V1CHIS_COD_EMPR}");

                /*" -1655- DISPLAY 'COD CONG - ' V1CHIS-CONGENER */
                _.Display($"COD CONG - {V1CHIS_CONGENER}");

                /*" -1656- DISPLAY 'APOLICE  - ' V1CHIS-NUM-APOL */
                _.Display($"APOLICE  - {V1CHIS_NUM_APOL}");

                /*" -1657- DISPLAY 'ENDOSSO  - ' V1CHIS-NUM-ENDS */
                _.Display($"ENDOSSO  - {V1CHIS_NUM_ENDS}");

                /*" -1658- DISPLAY 'PARCELA  - ' V1CHIS-NRPARCEL */
                _.Display($"PARCELA  - {V1CHIS_NRPARCEL}");

                /*" -1659- DISPLAY 'NUM OCOR - ' V1CHIS-NUM-OCOR */
                _.Display($"NUM OCOR - {V1CHIS_NUM_OCOR}");

                /*" -1660- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1661- ELSE */
            }
            else
            {


                /*" -1662- IF VIND-DAT-QTBC < ZEROS */

                if (VIND_DAT_QTBC < 00)
                {

                    /*" -1663- MOVE SPACES TO V1CHIS-DTQITBCO */
                    _.Move("", V1CHIS_DTQITBCO);

                    /*" -1664- END-IF */
                }


                /*" -1664- END-IF. */
            }


        }

        [StopWatch]
        /*" R2100-00-OPERACAO-ORIGINAL-DB-SELECT-1 */
        public void R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1()
        {
            /*" -1649- EXEC SQL SELECT PRM_TARIFARIO , VAL_DESCONTO , VLPRMLIQ , VLADIFRA , VLCOMIS , VLPRMTOT , DTQITBCO INTO :V1CHIS-PRM-TARF , :V1CHIS-VAL-DESC , :V1CHIS-VLPRMLIQ , :V1CHIS-VLADIFRA , :V1CHIS-VLCOMISS , :V1CHIS-VLPRMTOT , :V1CHIS-DTQITBCO:VIND-DAT-QTBC FROM SEGUROS.V0COSSEG_HISTPRE WHERE CONGENER = :V1CHIS-CONGENER AND NUM_APOLICE = :V1CHIS-NUM-APOL AND NRENDOS = :V1CHIS-NUM-ENDS AND NRPARCEL = :V1CHIS-NRPARCEL AND OCORHIST = :V1CHIS-NUM-OCOR AND OPERACAO BETWEEN 0400 AND 0599 AND TIPSGU = '1' END-EXEC. */

            var r2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1 = new R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1()
            {
                V1CHIS_CONGENER = V1CHIS_CONGENER.ToString(),
                V1CHIS_NUM_APOL = V1CHIS_NUM_APOL.ToString(),
                V1CHIS_NUM_ENDS = V1CHIS_NUM_ENDS.ToString(),
                V1CHIS_NRPARCEL = V1CHIS_NRPARCEL.ToString(),
                V1CHIS_NUM_OCOR = V1CHIS_NUM_OCOR.ToString(),
            };

            var executed_1 = R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1.Execute(r2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CHIS_PRM_TARF, V1CHIS_PRM_TARF);
                _.Move(executed_1.V1CHIS_VAL_DESC, V1CHIS_VAL_DESC);
                _.Move(executed_1.V1CHIS_VLPRMLIQ, V1CHIS_VLPRMLIQ);
                _.Move(executed_1.V1CHIS_VLADIFRA, V1CHIS_VLADIFRA);
                _.Move(executed_1.V1CHIS_VLCOMISS, V1CHIS_VLCOMISS);
                _.Move(executed_1.V1CHIS_VLPRMTOT, V1CHIS_VLPRMTOT);
                _.Move(executed_1.V1CHIS_DTQITBCO, V1CHIS_DTQITBCO);
                _.Move(executed_1.VIND_DAT_QTBC, VIND_DAT_QTBC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-CALC-CORR-INDEX-SECTION */
        private void R2200_00_CALC_CORR_INDEX_SECTION()
        {
            /*" -1677- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", WABEND.WNR_EXEC_SQL);

            /*" -1680- COMPUTE WHOST-PRM-TARF ROUNDED = V1CPRE-PRMTAR-IX * WHOST-VLCRUZAD2. */
            WHOST_PRM_TARF.Value = V1CPRE_PRMTAR_IX * WHOST_VLCRUZAD2;

            /*" -1683- COMPUTE WHOST-VAL-DESC ROUNDED = V1CPRE-VLDESC-IX * WHOST-VLCRUZAD2. */
            WHOST_VAL_DESC.Value = V1CPRE_VLDESC_IX * WHOST_VLCRUZAD2;

            /*" -1686- COMPUTE WHOST-VLPRMLIQ = WHOST-PRM-TARF - WHOST-VAL-DESC. */
            WHOST_VLPRMLIQ.Value = WHOST_PRM_TARF - WHOST_VAL_DESC;

            /*" -1689- COMPUTE WHOST-VLADIFRA ROUNDED = V1CPRE-OTNADFRA * WHOST-VLCRUZAD2. */
            WHOST_VLADIFRA.Value = V1CPRE_OTNADFRA * WHOST_VLCRUZAD2;

            /*" -1694- COMPUTE WHOST-VLCOMISS ROUNDED = (WHOST-VLPRMLIQ + WHOST-VLADIFRA) * V1APCC-PCCOMCOS / 100. */
            WHOST_VLCOMISS.Value = (WHOST_VLPRMLIQ + WHOST_VLADIFRA) * V1APCC_PCCOMCOS / 100f;

            /*" -1696- COMPUTE WHOST-VLPRMTOT = WHOST-VLPRMLIQ + WHOST-VLADIFRA - WHOST-VLCOMISS. */
            WHOST_VLPRMTOT.Value = WHOST_VLPRMLIQ + WHOST_VLADIFRA - WHOST_VLCOMISS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-MONTA-CORRECAO-SECTION */
        private void R2300_00_MONTA_CORRECAO_SECTION()
        {
            /*" -1709- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", WABEND.WNR_EXEC_SQL);

            /*" -1712- COMPUTE WVLR-PRMTAR-CM = WHOST-PRM-TARF - V1CHIS-PRM-TARF. */
            AREA_DE_WORK.WVLR_PRMTAR_CM.Value = WHOST_PRM_TARF - V1CHIS_PRM_TARF;

            /*" -1715- COMPUTE WVLR-DESCTO-CM = WHOST-VAL-DESC - V1CHIS-VAL-DESC. */
            AREA_DE_WORK.WVLR_DESCTO_CM.Value = WHOST_VAL_DESC - V1CHIS_VAL_DESC;

            /*" -1718- COMPUTE WVLR-PRMLIQ-CM = WVLR-PRMTAR-CM - WVLR-DESCTO-CM. */
            AREA_DE_WORK.WVLR_PRMLIQ_CM.Value = AREA_DE_WORK.WVLR_PRMTAR_CM - AREA_DE_WORK.WVLR_DESCTO_CM;

            /*" -1721- COMPUTE WVLR-ADIFRA-CM = WHOST-VLADIFRA - V1CHIS-VLADIFRA. */
            AREA_DE_WORK.WVLR_ADIFRA_CM.Value = WHOST_VLADIFRA - V1CHIS_VLADIFRA;

            /*" -1724- COMPUTE WVLR-COMISS-CM = WHOST-VLCOMISS - V1CHIS-VLCOMISS. */
            AREA_DE_WORK.WVLR_COMISS_CM.Value = WHOST_VLCOMISS - V1CHIS_VLCOMISS;

            /*" -1728- COMPUTE WVLR-PRMTOT-CM = WVLR-PRMLIQ-CM + WVLR-ADIFRA-CM - WVLR-COMISS-CM. */
            AREA_DE_WORK.WVLR_PRMTOT_CM.Value = AREA_DE_WORK.WVLR_PRMLIQ_CM + AREA_DE_WORK.WVLR_ADIFRA_CM - AREA_DE_WORK.WVLR_COMISS_CM;

            /*" -1729- MOVE WHOST-PRM-TARF TO V1CHIS-PRM-TARF. */
            _.Move(WHOST_PRM_TARF, V1CHIS_PRM_TARF);

            /*" -1730- MOVE WHOST-VAL-DESC TO V1CHIS-VAL-DESC. */
            _.Move(WHOST_VAL_DESC, V1CHIS_VAL_DESC);

            /*" -1731- MOVE WHOST-VLPRMLIQ TO V1CHIS-VLPRMLIQ. */
            _.Move(WHOST_VLPRMLIQ, V1CHIS_VLPRMLIQ);

            /*" -1732- MOVE WHOST-VLADIFRA TO V1CHIS-VLADIFRA. */
            _.Move(WHOST_VLADIFRA, V1CHIS_VLADIFRA);

            /*" -1733- MOVE WHOST-VLCOMISS TO V1CHIS-VLCOMISS. */
            _.Move(WHOST_VLCOMISS, V1CHIS_VLCOMISS);

            /*" -1733- MOVE WHOST-VLPRMTOT TO V1CHIS-VLPRMTOT. */
            _.Move(WHOST_VLPRMTOT, V1CHIS_VLPRMTOT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-CALC-CORR-NINDEX-SECTION */
        private void R2400_00_CALC_CORR_NINDEX_SECTION()
        {
            /*" -1748- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", WABEND.WNR_EXEC_SQL);

            /*" -1749- MOVE V1RELA-CODUNIMO TO V1MOED-CODUNIMO. */
            _.Move(V1RELA_CODUNIMO, V1MOED_CODUNIMO);

            /*" -1751- MOVE V1CHIS-DAT-MOVT TO V1MOED-DTINIVIG. */
            _.Move(V1CHIS_DAT_MOVT, V1MOED_DTINIVIG);

            /*" -1753- PERFORM R1100-00-SELECT-V1MOEDA. */

            R1100_00_SELECT_V1MOEDA_SECTION();

            /*" -1754- MOVE V0ENDO-MOEDA-PRM TO V1COTA-CODUNIMO. */
            _.Move(V0ENDO_MOEDA_PRM, V1COTA_CODUNIMO);

            /*" -1756- MOVE V0ENDO-DTINIVIG TO V1COTA-DTINIVIG. */
            _.Move(V0ENDO_DTINIVIG, V1COTA_DTINIVIG);

            /*" -1758- PERFORM R2500-00-SELECT-V1COTACAO. */

            R2500_00_SELECT_V1COTACAO_SECTION();

            /*" -1761- COMPUTE V1CPRE-PRMTAR-IX ROUNDED = V1CPRE-PRMTAR-IX * V1COTA-VAL-VENDA. */
            V1CPRE_PRMTAR_IX.Value = V1CPRE_PRMTAR_IX * V1COTA_VAL_VENDA;

            /*" -1764- COMPUTE WHOST-PRMTAR-IX = V1CPRE-PRMTAR-IX / V1MOED-VLCRUZAD. */
            WHOST_PRMTAR_IX.Value = V1CPRE_PRMTAR_IX / V1MOED_VLCRUZAD;

            /*" -1767- COMPUTE WHOST-PRM-TARF ROUNDED = WHOST-PRMTAR-IX * WHOST-VLCRUZAD1. */
            WHOST_PRM_TARF.Value = WHOST_PRMTAR_IX * WHOST_VLCRUZAD1;

            /*" -1770- COMPUTE V1CPRE-VLDESC-IX ROUNDED = V1CPRE-VLDESC-IX * V1COTA-VAL-VENDA. */
            V1CPRE_VLDESC_IX.Value = V1CPRE_VLDESC_IX * V1COTA_VAL_VENDA;

            /*" -1773- COMPUTE WHOST-VLDESC-IX = V1CPRE-VLDESC-IX / V1MOED-VLCRUZAD. */
            WHOST_VLDESC_IX.Value = V1CPRE_VLDESC_IX / V1MOED_VLCRUZAD;

            /*" -1776- COMPUTE WHOST-VAL-DESC ROUNDED = WHOST-VLDESC-IX * WHOST-VLCRUZAD1. */
            WHOST_VAL_DESC.Value = WHOST_VLDESC_IX * WHOST_VLCRUZAD1;

            /*" -1779- COMPUTE WHOST-PRMLIQ-IX = WHOST-PRMTAR-IX - WHOST-VLDESC-IX. */
            WHOST_PRMLIQ_IX.Value = WHOST_PRMTAR_IX - WHOST_VLDESC_IX;

            /*" -1782- COMPUTE WHOST-VLPRMLIQ = WHOST-PRM-TARF - WHOST-VAL-DESC. */
            WHOST_VLPRMLIQ.Value = WHOST_PRM_TARF - WHOST_VAL_DESC;

            /*" -1785- COMPUTE V1CPRE-OTNADFRA ROUNDED = V1CPRE-OTNADFRA * V1COTA-VAL-VENDA. */
            V1CPRE_OTNADFRA.Value = V1CPRE_OTNADFRA * V1COTA_VAL_VENDA;

            /*" -1788- COMPUTE WHOST-ADFRAC-IX = V1CPRE-OTNADFRA / V1MOED-VLCRUZAD. */
            WHOST_ADFRAC_IX.Value = V1CPRE_OTNADFRA / V1MOED_VLCRUZAD;

            /*" -1791- COMPUTE WHOST-VLADIFRA ROUNDED = WHOST-ADFRAC-IX * WHOST-VLCRUZAD1. */
            WHOST_VLADIFRA.Value = WHOST_ADFRAC_IX * WHOST_VLCRUZAD1;

            /*" -1796- COMPUTE WHOST-VLCOMS-IX = (WHOST-PRMLIQ-IX + WHOST-ADFRAC-IX) * V1APCC-PCCOMCOS / 100. */
            WHOST_VLCOMS_IX.Value = (WHOST_PRMLIQ_IX + WHOST_ADFRAC_IX) * V1APCC_PCCOMCOS / 100f;

            /*" -1801- COMPUTE WHOST-VLCOMISS = (WHOST-VLPRMLIQ + WHOST-VLADIFRA) * V1APCC-PCCOMCOS / 100. */
            WHOST_VLCOMISS.Value = (WHOST_VLPRMLIQ + WHOST_VLADIFRA) * V1APCC_PCCOMCOS / 100f;

            /*" -1805- COMPUTE WHOST-PRMTOT-IX = WHOST-PRMLIQ-IX + WHOST-ADFRAC-IX - WHOST-VLCOMS-IX. */
            WHOST_PRMTOT_IX.Value = WHOST_PRMLIQ_IX + WHOST_ADFRAC_IX - WHOST_VLCOMS_IX;

            /*" -1807- COMPUTE WHOST-VLPRMTOT = WHOST-VLPRMLIQ + WHOST-VLADIFRA - WHOST-VLCOMISS. */
            WHOST_VLPRMTOT.Value = WHOST_VLPRMLIQ + WHOST_VLADIFRA - WHOST_VLCOMISS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-SELECT-V1COTACAO-SECTION */
        private void R2500_00_SELECT_V1COTACAO_SECTION()
        {
            /*" -1820- MOVE '250' TO WNR-EXEC-SQL. */
            _.Move("250", WABEND.WNR_EXEC_SQL);

            /*" -1830- PERFORM R2500_00_SELECT_V1COTACAO_DB_SELECT_1 */

            R2500_00_SELECT_V1COTACAO_DB_SELECT_1();

            /*" -1833- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1834- DISPLAY 'R2500 - ERRO NO SELECT DA V1COTACAO' */
                _.Display($"R2500 - ERRO NO SELECT DA V1COTACAO");

                /*" -1835- DISPLAY 'EMPRESA   - ' V1CHIS-COD-EMPR */
                _.Display($"EMPRESA   - {V1CHIS_COD_EMPR}");

                /*" -1836- DISPLAY 'COD CONG  - ' V1CHIS-CONGENER */
                _.Display($"COD CONG  - {V1CHIS_CONGENER}");

                /*" -1837- DISPLAY 'APOLICE   - ' V1CHIS-NUM-APOL */
                _.Display($"APOLICE   - {V1CHIS_NUM_APOL}");

                /*" -1838- DISPLAY 'ENDOSSO   - ' V1CHIS-NUM-ENDS */
                _.Display($"ENDOSSO   - {V1CHIS_NUM_ENDS}");

                /*" -1839- DISPLAY 'COD MOEDA - ' V1COTA-CODUNIMO */
                _.Display($"COD MOEDA - {V1COTA_CODUNIMO}");

                /*" -1840- DISPLAY 'INIC VIGC - ' V1COTA-DTINIVIG */
                _.Display($"INIC VIGC - {V1COTA_DTINIVIG}");

                /*" -1841- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1841- END-IF. */
            }


        }

        [StopWatch]
        /*" R2500-00-SELECT-V1COTACAO-DB-SELECT-1 */
        public void R2500_00_SELECT_V1COTACAO_DB_SELECT_1()
        {
            /*" -1830- EXEC SQL SELECT VAL_VENDA INTO :V1COTA-VAL-VENDA FROM SEGUROS.V1COTACAO WHERE CODUNIMO = :V1COTA-CODUNIMO AND DTINIVIG <= :V1COTA-DTINIVIG AND DTTERVIG >= :V1COTA-DTINIVIG END-EXEC. */

            var r2500_00_SELECT_V1COTACAO_DB_SELECT_1_Query1 = new R2500_00_SELECT_V1COTACAO_DB_SELECT_1_Query1()
            {
                V1COTA_CODUNIMO = V1COTA_CODUNIMO.ToString(),
                V1COTA_DTINIVIG = V1COTA_DTINIVIG.ToString(),
            };

            var executed_1 = R2500_00_SELECT_V1COTACAO_DB_SELECT_1_Query1.Execute(r2500_00_SELECT_V1COTACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1COTA_VAL_VENDA, V1COTA_VAL_VENDA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-INSERT-COSSEGHIS-SECTION */
        private void R2600_00_INSERT_COSSEGHIS_SECTION()
        {
            /*" -1854- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", WABEND.WNR_EXEC_SQL);

            /*" -1876- PERFORM R2600_00_INSERT_COSSEGHIS_DB_INSERT_1 */

            R2600_00_INSERT_COSSEGHIS_DB_INSERT_1();

            /*" -1879- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1880- DISPLAY 'R2600 - ERRO NO INSERT DA V0COSSEG_HISTPRE' */
                _.Display($"R2600 - ERRO NO INSERT DA V0COSSEG_HISTPRE");

                /*" -1881- DISPLAY 'EMPRESA   - ' V0CHIS-COD-EMPR */
                _.Display($"EMPRESA   - {V0CHIS_COD_EMPR}");

                /*" -1882- DISPLAY 'COD CONG  - ' V0CHIS-CONGENER */
                _.Display($"COD CONG  - {V0CHIS_CONGENER}");

                /*" -1883- DISPLAY 'APOLICE   - ' V0CHIS-NUM-APOL */
                _.Display($"APOLICE   - {V0CHIS_NUM_APOL}");

                /*" -1884- DISPLAY 'ENDOSSO   - ' V0CHIS-NUM-ENDS */
                _.Display($"ENDOSSO   - {V0CHIS_NUM_ENDS}");

                /*" -1885- DISPLAY 'PARCELA   - ' V0CHIS-NRPARCEL */
                _.Display($"PARCELA   - {V0CHIS_NRPARCEL}");

                /*" -1886- DISPLAY 'OCOR HIST - ' V0CHIS-OCORHIST */
                _.Display($"OCOR HIST - {V0CHIS_OCORHIST}");

                /*" -1887- DISPLAY 'OPERACAO  - ' V0CHIS-OPERACAO */
                _.Display($"OPERACAO  - {V0CHIS_OPERACAO}");

                /*" -1888- DISPLAY 'DATA MOVT - ' V0CHIS-DAT-MOVT */
                _.Display($"DATA MOVT - {V0CHIS_DAT_MOVT}");

                /*" -1889- DISPLAY 'TIPO SEGU - ' V0CHIS-TIP-SEGU */
                _.Display($"TIPO SEGU - {V0CHIS_TIP_SEGU}");

                /*" -1890- DISPLAY 'NUM OCORR - ' V0CHIS-NUM-OCOR */
                _.Display($"NUM OCORR - {V0CHIS_NUM_OCOR}");

                /*" -1891- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1892- ELSE */
            }
            else
            {


                /*" -1893- ADD 1 TO AC-I-COSSEGHIS */
                AREA_DE_WORK.AC_I_COSSEGHIS.Value = AREA_DE_WORK.AC_I_COSSEGHIS + 1;

                /*" -1893- END-IF. */
            }


        }

        [StopWatch]
        /*" R2600-00-INSERT-COSSEGHIS-DB-INSERT-1 */
        public void R2600_00_INSERT_COSSEGHIS_DB_INSERT_1()
        {
            /*" -1876- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_HISTPRE VALUES (:V0CHIS-COD-EMPR , :V0CHIS-CONGENER , :V0CHIS-NUM-APOL , :V0CHIS-NUM-ENDS , :V0CHIS-NRPARCEL , :V0CHIS-OCORHIST , :V0CHIS-OPERACAO , :V0CHIS-DAT-MOVT , :V0CHIS-TIP-SEGU , +0 , +0 , +0 , +0 , :V0CHIS-VLCOMISS , :V0CHIS-VLPRMTOT , CURRENT TIMESTAMP , :V0CHIS-DTQITBCO:VIND-DTQITBCO, :V0CHIS-SIT-FINC:VIND-SIT-FINC, :V0CHIS-SIT-LIBR:VIND-SIT-LIBR, :V0CHIS-NUM-OCOR:VIND-NUM-OCOR) END-EXEC. */

            var r2600_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1 = new R2600_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1()
            {
                V0CHIS_COD_EMPR = V0CHIS_COD_EMPR.ToString(),
                V0CHIS_CONGENER = V0CHIS_CONGENER.ToString(),
                V0CHIS_NUM_APOL = V0CHIS_NUM_APOL.ToString(),
                V0CHIS_NUM_ENDS = V0CHIS_NUM_ENDS.ToString(),
                V0CHIS_NRPARCEL = V0CHIS_NRPARCEL.ToString(),
                V0CHIS_OCORHIST = V0CHIS_OCORHIST.ToString(),
                V0CHIS_OPERACAO = V0CHIS_OPERACAO.ToString(),
                V0CHIS_DAT_MOVT = V0CHIS_DAT_MOVT.ToString(),
                V0CHIS_TIP_SEGU = V0CHIS_TIP_SEGU.ToString(),
                V0CHIS_VLCOMISS = V0CHIS_VLCOMISS.ToString(),
                V0CHIS_VLPRMTOT = V0CHIS_VLPRMTOT.ToString(),
                V0CHIS_DTQITBCO = V0CHIS_DTQITBCO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                V0CHIS_SIT_FINC = V0CHIS_SIT_FINC.ToString(),
                VIND_SIT_FINC = VIND_SIT_FINC.ToString(),
                V0CHIS_SIT_LIBR = V0CHIS_SIT_LIBR.ToString(),
                VIND_SIT_LIBR = VIND_SIT_LIBR.ToString(),
                V0CHIS_NUM_OCOR = V0CHIS_NUM_OCOR.ToString(),
                VIND_NUM_OCOR = VIND_NUM_OCOR.ToString(),
            };

            R2600_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1.Execute(r2600_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-UPDATE-COSSEGPRE-SECTION */
        private void R2700_00_UPDATE_COSSEGPRE_SECTION()
        {
            /*" -1906- MOVE '270' TO WNR-EXEC-SQL. */
            _.Move("270", WABEND.WNR_EXEC_SQL);

            /*" -1916- PERFORM R2700_00_UPDATE_COSSEGPRE_DB_UPDATE_1 */

            R2700_00_UPDATE_COSSEGPRE_DB_UPDATE_1();

            /*" -1919- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1920- DISPLAY 'R2700 - ERRO NO UPDATE DA V0COSSEG_PREM' */
                _.Display($"R2700 - ERRO NO UPDATE DA V0COSSEG_PREM");

                /*" -1921- DISPLAY 'EMPRESA  - ' V1CHIS-COD-EMPR */
                _.Display($"EMPRESA  - {V1CHIS_COD_EMPR}");

                /*" -1922- DISPLAY 'COD CONG - ' V1CHIS-CONGENER */
                _.Display($"COD CONG - {V1CHIS_CONGENER}");

                /*" -1923- DISPLAY 'APOLICE  - ' V1CHIS-NUM-APOL */
                _.Display($"APOLICE  - {V1CHIS_NUM_APOL}");

                /*" -1924- DISPLAY 'ENDOSSO  - ' V1CHIS-NUM-ENDS */
                _.Display($"ENDOSSO  - {V1CHIS_NUM_ENDS}");

                /*" -1925- DISPLAY 'PARCELA  - ' V1CHIS-NRPARCEL */
                _.Display($"PARCELA  - {V1CHIS_NRPARCEL}");

                /*" -1926- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1927- ELSE */
            }
            else
            {


                /*" -1928- ADD 1 TO AC-U-COSSEGPRE */
                AREA_DE_WORK.AC_U_COSSEGPRE.Value = AREA_DE_WORK.AC_U_COSSEGPRE + 1;

                /*" -1928- END-IF. */
            }


        }

        [StopWatch]
        /*" R2700-00-UPDATE-COSSEGPRE-DB-UPDATE-1 */
        public void R2700_00_UPDATE_COSSEGPRE_DB_UPDATE_1()
        {
            /*" -1916- EXEC SQL UPDATE SEGUROS.V0COSSEG_PREM SET SIT_CONGENERE = '1' , OCORHIST = :V1CPRE-OCORHIST, TIMESTAMP = CURRENT TIMESTAMP WHERE CONGENER = :V1CHIS-CONGENER AND NUM_APOLICE = :V1CHIS-NUM-APOL AND NRENDOS = :V1CHIS-NUM-ENDS AND NRPARCEL = :V1CHIS-NRPARCEL AND TIPSGU = '1' END-EXEC. */

            var r2700_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1 = new R2700_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1()
            {
                V1CPRE_OCORHIST = V1CPRE_OCORHIST.ToString(),
                V1CHIS_CONGENER = V1CHIS_CONGENER.ToString(),
                V1CHIS_NUM_APOL = V1CHIS_NUM_APOL.ToString(),
                V1CHIS_NUM_ENDS = V1CHIS_NUM_ENDS.ToString(),
                V1CHIS_NRPARCEL = V1CHIS_NRPARCEL.ToString(),
            };

            R2700_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1.Execute(r2700_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-UPDATE-COSSEGHIS-SECTION */
        private void R2800_00_UPDATE_COSSEGHIS_SECTION()
        {
            /*" -1941- MOVE '280' TO WNR-EXEC-SQL. */
            _.Move("280", WABEND.WNR_EXEC_SQL);

            /*" -1952- PERFORM R2800_00_UPDATE_COSSEGHIS_DB_UPDATE_1 */

            R2800_00_UPDATE_COSSEGHIS_DB_UPDATE_1();

            /*" -1955- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1956- DISPLAY 'R2800 - ERRO NO UPDATE DA V0COSSEG_HISTPRE' */
                _.Display($"R2800 - ERRO NO UPDATE DA V0COSSEG_HISTPRE");

                /*" -1957- DISPLAY 'EMPRESA   - ' V1CHIS-COD-EMPR */
                _.Display($"EMPRESA   - {V1CHIS_COD_EMPR}");

                /*" -1958- DISPLAY 'COD CONG  - ' V1CHIS-CONGENER */
                _.Display($"COD CONG  - {V1CHIS_CONGENER}");

                /*" -1959- DISPLAY 'APOLICE   - ' V1CHIS-NUM-APOL */
                _.Display($"APOLICE   - {V1CHIS_NUM_APOL}");

                /*" -1960- DISPLAY 'ENDOSSO   - ' V1CHIS-NUM-ENDS */
                _.Display($"ENDOSSO   - {V1CHIS_NUM_ENDS}");

                /*" -1961- DISPLAY 'PARCELA   - ' V1CHIS-NRPARCEL */
                _.Display($"PARCELA   - {V1CHIS_NRPARCEL}");

                /*" -1962- DISPLAY 'OCOR HIST - ' V1CHIS-OCORHIST */
                _.Display($"OCOR HIST - {V1CHIS_OCORHIST}");

                /*" -1963- DISPLAY 'OPERACAO  - ' V1CHIS-OPERACAO */
                _.Display($"OPERACAO  - {V1CHIS_OPERACAO}");

                /*" -1964- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1965- ELSE */
            }
            else
            {


                /*" -1966- ADD 1 TO AC-U-COSSEGHIS */
                AREA_DE_WORK.AC_U_COSSEGHIS.Value = AREA_DE_WORK.AC_U_COSSEGHIS + 1;

                /*" -1966- END-IF. */
            }


        }

        [StopWatch]
        /*" R2800-00-UPDATE-COSSEGHIS-DB-UPDATE-1 */
        public void R2800_00_UPDATE_COSSEGHIS_DB_UPDATE_1()
        {
            /*" -1952- EXEC SQL UPDATE SEGUROS.V0COSSEG_HISTPRE SET TIMESTAMP = CURRENT TIMESTAMP , SIT_LIBRECUP = '1' WHERE CONGENER = :V1CHIS-CONGENER AND NUM_APOLICE = :V1CHIS-NUM-APOL AND NRENDOS = :V1CHIS-NUM-ENDS AND NRPARCEL = :V1CHIS-NRPARCEL AND OCORHIST = :V1CHIS-OCORHIST AND OPERACAO = :V1CHIS-OPERACAO AND TIPSGU = '1' END-EXEC. */

            var r2800_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1 = new R2800_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1()
            {
                V1CHIS_CONGENER = V1CHIS_CONGENER.ToString(),
                V1CHIS_NUM_APOL = V1CHIS_NUM_APOL.ToString(),
                V1CHIS_NUM_ENDS = V1CHIS_NUM_ENDS.ToString(),
                V1CHIS_NRPARCEL = V1CHIS_NRPARCEL.ToString(),
                V1CHIS_OCORHIST = V1CHIS_OCORHIST.ToString(),
                V1CHIS_OPERACAO = V1CHIS_OPERACAO.ToString(),
            };

            R2800_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1.Execute(r2800_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-MONTA-COSCED-CHEQUE-SECTION */
        private void R3000_00_MONTA_COSCED_CHEQUE_SECTION()
        {
            /*" -1979- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", WABEND.WNR_EXEC_SQL);

            /*" -1981- PERFORM R3100-00-SELECT-COSCED-CHEQUE. */

            R3100_00_SELECT_COSCED_CHEQUE_SECTION();

            /*" -1983- ADD AC-COMISSAO TO V0CCHQ-COMISSAO. */
            V0CCHQ_COMISSAO.Value = V0CCHQ_COMISSAO + AREA_DE_WORK.AC_COMISSAO;

            /*" -1986- COMPUTE V0CCHQ-OUTRDEBIT = V0CCHQ-OUTRDEBIT - AC-COMISSAO-6668. */
            V0CCHQ_OUTRDEBIT.Value = V0CCHQ_OUTRDEBIT - AREA_DE_WORK.AC_COMISSAO_6668;

            /*" -1986- PERFORM R3200-00-UPDATE-COSCED-CHEQUE. */

            R3200_00_UPDATE_COSCED_CHEQUE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-SELECT-COSCED-CHEQUE-SECTION */
        private void R3100_00_SELECT_COSCED_CHEQUE_SECTION()
        {
            /*" -1999- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", WABEND.WNR_EXEC_SQL);

            /*" -2008- PERFORM R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1 */

            R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1();

            /*" -2011- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2012- DISPLAY 'R3100 - ERRO NO SELECT DA V0COSCED_CHEQUE' */
                _.Display($"R3100 - ERRO NO SELECT DA V0COSCED_CHEQUE");

                /*" -2013- DISPLAY 'COD EMPRESA - ' V1RELA-COD-EMPR */
                _.Display($"COD EMPRESA - {V1RELA_COD_EMPR}");

                /*" -2014- DISPLAY 'COD CONGENR - ' V1RELA-CONGENER */
                _.Display($"COD CONGENR - {V1RELA_CONGENER}");

                /*" -2015- DISPLAY 'DT MOVOT AC - ' V1RELA-DATA-SOL */
                _.Display($"DT MOVOT AC - {V1RELA_DATA_SOL}");

                /*" -2016- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2016- END-IF. */
            }


        }

        [StopWatch]
        /*" R3100-00-SELECT-COSCED-CHEQUE-DB-SELECT-1 */
        public void R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1()
        {
            /*" -2008- EXEC SQL SELECT VLRCOMIS, OUTRDEBIT INTO :V0CCHQ-COMISSAO, :V0CCHQ-OUTRDEBIT FROM SEGUROS.V0COSCED_CHEQUE WHERE COD_EMPRESA = :V1RELA-COD-EMPR AND CONGENER = :V1RELA-CONGENER AND DTMOVTO_AC = :V1RELA-DATA-SOL END-EXEC. */

            var r3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1 = new R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1()
            {
                V1RELA_COD_EMPR = V1RELA_COD_EMPR.ToString(),
                V1RELA_CONGENER = V1RELA_CONGENER.ToString(),
                V1RELA_DATA_SOL = V1RELA_DATA_SOL.ToString(),
            };

            var executed_1 = R3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1.Execute(r3100_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CCHQ_COMISSAO, V0CCHQ_COMISSAO);
                _.Move(executed_1.V0CCHQ_OUTRDEBIT, V0CCHQ_OUTRDEBIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-UPDATE-COSCED-CHEQUE-SECTION */
        private void R3200_00_UPDATE_COSCED_CHEQUE_SECTION()
        {
            /*" -2029- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", WABEND.WNR_EXEC_SQL);

            /*" -2036- PERFORM R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1 */

            R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1();

            /*" -2039- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2040- DISPLAY 'R3200 - ERRO NO UPDATE DA V0COSCED_CHEQUE' */
                _.Display($"R3200 - ERRO NO UPDATE DA V0COSCED_CHEQUE");

                /*" -2041- DISPLAY 'COD EMPRESA - ' V1RELA-COD-EMPR */
                _.Display($"COD EMPRESA - {V1RELA_COD_EMPR}");

                /*" -2042- DISPLAY 'COD CONGENR - ' V1RELA-CONGENER */
                _.Display($"COD CONGENR - {V1RELA_CONGENER}");

                /*" -2043- DISPLAY 'DT MOVTO AC - ' V1RELA-DATA-SOL */
                _.Display($"DT MOVTO AC - {V1RELA_DATA_SOL}");

                /*" -2044- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2044- END-IF. */
            }


        }

        [StopWatch]
        /*" R3200-00-UPDATE-COSCED-CHEQUE-DB-UPDATE-1 */
        public void R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1()
        {
            /*" -2036- EXEC SQL UPDATE SEGUROS.V0COSCED_CHEQUE SET VLRCOMIS = :V0CCHQ-COMISSAO, OUTRDEBIT = :V0CCHQ-OUTRDEBIT WHERE COD_EMPRESA = :V1RELA-COD-EMPR AND CONGENER = :V1RELA-CONGENER AND DTMOVTO_AC = :V1RELA-DATA-SOL END-EXEC. */

            var r3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1 = new R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1()
            {
                V0CCHQ_OUTRDEBIT = V0CCHQ_OUTRDEBIT.ToString(),
                V0CCHQ_COMISSAO = V0CCHQ_COMISSAO.ToString(),
                V1RELA_COD_EMPR = V1RELA_COD_EMPR.ToString(),
                V1RELA_CONGENER = V1RELA_CONGENER.ToString(),
                V1RELA_DATA_SOL = V1RELA_DATA_SOL.ToString(),
            };

            R3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1.Execute(r3200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-DELETE-V0RELATORIOS-SECTION */
        private void R3500_00_DELETE_V0RELATORIOS_SECTION()
        {
            /*" -2057- MOVE '350' TO WNR-EXEC-SQL. */
            _.Move("350", WABEND.WNR_EXEC_SQL);

            /*" -2065- PERFORM R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1 */

            R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1();

            /*" -2068- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2070- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -2071- ELSE */
                }
                else
                {


                    /*" -2072- DISPLAY 'R3500 - ERRO NO DELETE DA V0RELATORIOS' */
                    _.Display($"R3500 - ERRO NO DELETE DA V0RELATORIOS");

                    /*" -2073- DISPLAY 'COD USUARIO - ' V1RELA-COD-USU */
                    _.Display($"COD USUARIO - {V1RELA_COD_USU}");

                    /*" -2074- DISPLAY 'DAT SOLICIT - ' V1RELA-DATA-SOL */
                    _.Display($"DAT SOLICIT - {V1RELA_DATA_SOL}");

                    /*" -2075- DISPLAY 'IDE SISTEMA - ' V1RELA-IDSISTEM */
                    _.Display($"IDE SISTEMA - {V1RELA_IDSISTEM}");

                    /*" -2076- DISPLAY 'COD RELAT   - ' V1RELA-CODRELAT */
                    _.Display($"COD RELAT   - {V1RELA_CODRELAT}");

                    /*" -2077- DISPLAY 'CONGENERE   - ' V1RELA-CONGENER */
                    _.Display($"CONGENERE   - {V1RELA_CONGENER}");

                    /*" -2078- DISPLAY 'COD EMPRESA - ' V1RELA-COD-EMPR */
                    _.Display($"COD EMPRESA - {V1RELA_COD_EMPR}");

                    /*" -2079- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2080- END-IF */
                }


                /*" -2080- END-IF. */
            }


        }

        [StopWatch]
        /*" R3500-00-DELETE-V0RELATORIOS-DB-DELETE-1 */
        public void R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1()
        {
            /*" -2065- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE CODUSU = :V1RELA-COD-USU AND DATA_SOLICITACAO = :V1RELA-DATA-SOL AND IDSISTEM = :V1RELA-IDSISTEM AND CODRELAT = :V1RELA-CODRELAT AND CONGENER = :V1RELA-CONGENER AND COD_EMPRESA = :V1RELA-COD-EMPR END-EXEC. */

            var r3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 = new R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1()
            {
                V1RELA_COD_USU = V1RELA_COD_USU.ToString(),
                V1RELA_DATA_SOL = V1RELA_DATA_SOL.ToString(),
                V1RELA_IDSISTEM = V1RELA_IDSISTEM.ToString(),
                V1RELA_CODRELAT = V1RELA_CODRELAT.ToString(),
                V1RELA_CONGENER = V1RELA_CONGENER.ToString(),
                V1RELA_COD_EMPR = V1RELA_COD_EMPR.ToString(),
            };

            R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1.Execute(r3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -2092- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -2093- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -2094- DISPLAY '*   AC0815B - COSSEGURO CEDIDO PENDENTE    *' . */
            _.Display($"*   AC0815B - COSSEGURO CEDIDO PENDENTE    *");

            /*" -2095- DISPLAY '*   -------   --------- ------ --------    *' . */
            _.Display($"*   -------   --------- ------ --------    *");

            /*" -2096- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -2097- DISPLAY '*   NAO HOUVE SOLICITACAO PARA PROCESSAR   *' . */
            _.Display($"*   NAO HOUVE SOLICITACAO PARA PROCESSAR   *");

            /*" -2098- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -2098- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -2110- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -2111- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -2112- DISPLAY '*   AC0815B - COSSEGURO CEDIDO PENDENTE    *' . */
            _.Display($"*   AC0815B - COSSEGURO CEDIDO PENDENTE    *");

            /*" -2113- DISPLAY '*   -------   --------- ------ --------    *' . */
            _.Display($"*   -------   --------- ------ --------    *");

            /*" -2114- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -2115- DISPLAY '*    NAO HA PENDENCIA PARA  A  CONGENERE   *' . */
            _.Display($"*    NAO HA PENDENCIA PARA  A  CONGENERE   *");

            /*" -2116- DISPLAY '*    ATE A DATA DE MOVIMENTOS SOLICITADA.  *' . */
            _.Display($"*    ATE A DATA DE MOVIMENTOS SOLICITADA.  *");

            /*" -2117- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -2117- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2131- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -2133- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -2133- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2137- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2137- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}