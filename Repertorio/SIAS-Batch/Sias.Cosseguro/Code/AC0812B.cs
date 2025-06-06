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
using Sias.Cosseguro.DB2.AC0812B;

namespace Code
{
    public class AC0812B
    {
        public bool IsCall { get; set; }

        public AC0812B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  ADMINISTRACAO DE COSSEGURO         *      */
        /*"      *   PROGRAMA ...............  AC0812B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA/PROGRAMADOR....  CARLOS ALBERTO                     *      */
        /*"      *   DATA CODIFICACAO .......  MAIO/1997                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ................. -LIBERACAO, CONFORME SOLICITACAO,   *      */
        /*"      *                             PARA PARCELA BAIXADA OU ESTORNADA  *      */
        /*"      *                             DE APOLICES OU ENDOSSOS QUE TENHAM *      */
        /*"      *                             COSSEG CEDIDO, PENDENTES DE REPASSE*      */
        /*"      *                             OU RECUPERACAO DA CONGENERE PARTI- *      */
        /*"      *                             CIPANTE DA APOLICE E SOLICITADA NO *      */
        /*"      *                             ON LINE - APLICACAO AC19A.         *      */
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
        /*"      * 22/01/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 188194 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         VIND-DTLIBERA       PIC S9(004)       VALUE -1 COMP.*/
        public IntBasis VIND_DTLIBERA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77         VIND-DTMOVTO-AC     PIC S9(004)       VALUE -1 COMP.*/
        public IntBasis VIND_DTMOVTO_AC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77         VIND-DTMOVTO-FI     PIC S9(004)       VALUE -1 COMP.*/
        public IntBasis VIND_DTMOVTO_FI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77         VIND-COD-USU-FI     PIC S9(004)       VALUE -1 COMP.*/
        public IntBasis VIND_COD_USU_FI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77         VIND-DTCORRECAO     PIC S9(004)       VALUE +1 COMP.*/
        public IntBasis VIND_DTCORRECAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +1);
        /*"77         VIND-CODUNIMO       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis VIND_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DAT-QTBC       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis VIND_DAT_QTBC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTQITBCO       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SIT-FINC       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis VIND_SIT_FINC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SIT-LIBR       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis VIND_SIT_LIBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NUM-OCOR       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis VIND_NUM_OCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-COD-EMPR      PIC S9(009)                COMP.*/
        public IntBasis WHOST_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-CONGENER      PIC S9(004)                COMP.*/
        public IntBasis WHOST_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-QTD-RELAT     PIC S9(009)                COMP.*/
        public IntBasis WHOST_QTD_RELAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-QTD-CONGN     PIC S9(009)                COMP.*/
        public IntBasis WHOST_QTD_CONGN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-QTD-COSCH     PIC S9(009)                COMP.*/
        public IntBasis WHOST_QTD_COSCH { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-DTMOVTO       PIC  X(010).*/
        public StringBasis WHOST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTMOVTO-AC    PIC  X(010).*/
        public StringBasis WHOST_DTMOVTO_AC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"77         WHOST-VLRPREMIO     PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VLRPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VLRDESCON     PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VLRDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VLRADIFRA     PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VLRADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VLR-COMIS     PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VLR_COMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VLR-SINIS     PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VLR_SINIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VLDESPESA     PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VLDESPESA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VLR-HONOR     PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VLR_HONOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VLR-SALVD     PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VLR_SALVD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VLRESSARC     PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VLRESSARC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VALOR-EDI     PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VALOR_EDI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VALOR-USS     PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VALOR_USS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VLEQPVNDA     PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VLEQPVNDA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VLDESPADM     PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VLDESPADM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-OUTRDEBIT     PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_OUTRDEBIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-OUTRCREDT     PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_OUTRCREDT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VLRSLDANT     PIC S9(013)V99             COMP-3*/
        public DoubleBasis WHOST_VLRSLDANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
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
        /*"77         V0CCHQ-COD-EMPR     PIC S9(009)               COMP.*/
        public IntBasis V0CCHQ_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CCHQ-CONGENER     PIC S9(004)               COMP.*/
        public IntBasis V0CCHQ_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CCHQ-DTMOVTO-AC   PIC  X(010).*/
        public StringBasis V0CCHQ_DTMOVTO_AC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CCHQ-CODUSU-AC    PIC  X(008).*/
        public StringBasis V0CCHQ_CODUSU_AC { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0CCHQ-DTLIBERA     PIC  X(010).*/
        public StringBasis V0CCHQ_DTLIBERA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CCHQ-VLPREMIO     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V0CCHQ_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-VLRDESCON    PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V0CCHQ_VLRDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-VLRADIFRA    PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V0CCHQ_VLRADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-VLRCOMIS     PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V0CCHQ_VLRCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-OUTRDEBIT    PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V0CCHQ_OUTRDEBIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-VLRSLDANT    PIC S9(013)V99            COMP-3.*/
        public DoubleBasis V0CCHQ_VLRSLDANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-COD-MOEDA    PIC S9(004)               COMP.*/
        public IntBasis V0CCHQ_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CCHQ-CODUSU-FI    PIC  X(008).*/
        public StringBasis V0CCHQ_CODUSU_FI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0CCHQ-DTMOVTO-FI   PIC  X(010).*/
        public StringBasis V0CCHQ_DTMOVTO_FI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CCHQ-DTCORRECAO   PIC  X(010).*/
        public StringBasis V0CCHQ_DTCORRECAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1CCHQ-CONGENER     PIC S9(004)               COMP.*/
        public IntBasis V1CCHQ_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1CCHQ-DTLIBERA     PIC  X(010).*/
        public StringBasis V1CCHQ_DTLIBERA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         AREA-DE-WORK.*/
        public AC0812B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0812B_AREA_DE_WORK();
        public class AC0812B_AREA_DE_WORK : VarBasis
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
            /*"  05       AC-U-COSSEGPRE      PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_U_COSSEGPRE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       AC-L-COSSEGHIS      PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_COSSEGHIS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       AC-U-COSSEGHIS      PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_U_COSSEGHIS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       AC-I-COSSEGHIS      PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_I_COSSEGHIS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       WVLR-PRMTAR-CM      PIC S9(013)V99   VALUE +0 COMP-3.*/
            public DoubleBasis WVLR_PRMTAR_CM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WVLR-DESCTO-CM      PIC S9(013)V99   VALUE +0 COMP-3.*/
            public DoubleBasis WVLR_DESCTO_CM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WVLR-PRMLIQ-CM      PIC S9(013)V99   VALUE +0 COMP-3.*/
            public DoubleBasis WVLR_PRMLIQ_CM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WVLR-ADIFRA-CM      PIC S9(013)V99   VALUE +0 COMP-3.*/
            public DoubleBasis WVLR_ADIFRA_CM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WVLR-COMISS-CM      PIC S9(013)V99   VALUE +0 COMP-3.*/
            public DoubleBasis WVLR_COMISS_CM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WVLR-PRMTOT-CM      PIC S9(013)V99   VALUE +0 COMP-3.*/
            public DoubleBasis WVLR_PRMTOT_CM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WVLR-SLD-ANT        PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis WVLR_SLD_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       AC-PRM-TARF         PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis AC_PRM_TARF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       AC-DESCONTO         PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis AC_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       AC-VLADIFRA         PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis AC_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       AC-COMISSAO         PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis AC_COMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       AC-PRMLIQ-6668      PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis AC_PRMLIQ_6668 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WHORA-ACCEPT.*/
            public AC0812B_WHORA_ACCEPT WHORA_ACCEPT { get; set; } = new AC0812B_WHORA_ACCEPT();
            public class AC0812B_WHORA_ACCEPT : VarBasis
            {
                /*"    10     WHH-ACCEPT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHH_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     WMM-ACCEPT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WMM_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     WSS-ACCEPT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WSS_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     WCC-ACCEPT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WCC_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05       WHORA-EDIT.*/
            }
            public AC0812B_WHORA_EDIT WHORA_EDIT { get; set; } = new AC0812B_WHORA_EDIT();
            public class AC0812B_WHORA_EDIT : VarBasis
            {
                /*"    10     WHH-EDT             PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHH_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     FILLER              PIC  X(001)      VALUE ':'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10     WMM-EDT             PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WMM_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     FILLER              PIC  X(001)      VALUE ':'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10     WSS-EDT             PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WSS_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01         WABEND.*/
            }
        }
        public AC0812B_WABEND WABEND { get; set; } = new AC0812B_WABEND();
        public class AC0812B_WABEND : VarBasis
        {
            /*"  05       FILLER              PIC  X(008)      VALUE 'AC0812B'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"AC0812B");
            /*"  05       FILLER              PIC  X(026)      VALUE          ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05       WNR-EXEC-SQL        PIC  X(003)      VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"  05       FILLER              PIC  X(013)      VALUE          ' *** SQLCODE'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE");
            /*"  05       WSQLCODE            PIC -------999   VALUE  ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "-------999"));
        }


        public AC0812B_V1RELATORIOS V1RELATORIOS { get; set; } = new AC0812B_V1RELATORIOS();
        public AC0812B_V0COSCEDCHEQUE V0COSCEDCHEQUE { get; set; } = new AC0812B_V0COSCEDCHEQUE();
        public AC0812B_V1COSGHISTP V1COSGHISTP { get; set; } = new AC0812B_V1COSGHISTP();
        public AC0812B_V1COSSEGHIS V1COSSEGHIS { get; set; } = new AC0812B_V1COSSEGHIS();
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
            /*" -368- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WABEND.WNR_EXEC_SQL);

            /*" -369- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -372- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -375- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -379- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -381- PERFORM R0200-00-DECLARE-V1RELATORIOS. */

            R0200_00_DECLARE_V1RELATORIOS_SECTION();

            /*" -383- PERFORM R0250-00-FETCH-V1RELATORIOS. */

            R0250_00_FETCH_V1RELATORIOS_SECTION();

            /*" -384- IF WFIM-V1RELATORIOS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1RELATORIOS.IsEmpty())
            {

                /*" -385- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -386- ELSE */
            }
            else
            {


                /*" -388- PERFORM R0300-00-PROCESSA-LIBERACAO UNTIL WFIM-V1RELATORIOS NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_V1RELATORIOS.IsEmpty()))
                {

                    R0300_00_PROCESSA_LIBERACAO_SECTION();
                }

                /*" -388- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZACAO */

            R0000_90_FINALIZACAO();

        }

        [StopWatch]
        /*" R0000-90-FINALIZACAO */
        private void R0000_90_FINALIZACAO(bool isPerform = false)
        {
            /*" -392- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -396- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -396- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -409- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -414- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -417- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -418- DISPLAY 'R0100 - ERRO DE SELECT NA V1SISTEMA (AC)' */
                _.Display($"R0100 - ERRO DE SELECT NA V1SISTEMA (AC)");

                /*" -419- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -420- ELSE */
            }
            else
            {


                /*" -421- DISPLAY 'DATA DO MOVIMENTO AC - ' V1SIST-DTMOVABE */
                _.Display($"DATA DO MOVIMENTO AC - {V1SIST_DTMOVABE}");

                /*" -421- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -414- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'AC' END-EXEC. */

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
            /*" -434- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -456- PERFORM R0200_00_DECLARE_V1RELATORIOS_DB_DECLARE_1 */

            R0200_00_DECLARE_V1RELATORIOS_DB_DECLARE_1();

            /*" -458- PERFORM R0200_00_DECLARE_V1RELATORIOS_DB_OPEN_1 */

            R0200_00_DECLARE_V1RELATORIOS_DB_OPEN_1();

            /*" -461- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -462- DISPLAY 'R0200 - ERRO NO DECLARE NA V1RELATORIOS' */
                _.Display($"R0200 - ERRO NO DECLARE NA V1RELATORIOS");

                /*" -463- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -464- ELSE */
            }
            else
            {


                /*" -465- MOVE SPACES TO WFIM-V1RELATORIOS */
                _.Move("", AREA_DE_WORK.WFIM_V1RELATORIOS);

                /*" -465- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V1RELATORIOS-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V1RELATORIOS_DB_DECLARE_1()
        {
            /*" -456- EXEC SQL DECLARE V1RELATORIOS CURSOR FOR SELECT CODUSU , DATA_SOLICITACAO , IDSISTEM , CODRELAT , PERI_INICIAL , PERI_FINAL , DATA_REFERENCIA , CONGENER , CODUNIMO , CORRECAO , VALUE(COD_EMPRESA,+0) FROM SEGUROS.V1RELATORIOS WHERE DATA_SOLICITACAO = :V1SIST-DTMOVABE AND IDSISTEM = 'AC' AND CODRELAT = 'AC0812B' AND SITUACAO = ' ' ORDER BY COD_EMPRESA, CONGENER END-EXEC. */
            V1RELATORIOS = new AC0812B_V1RELATORIOS(true);
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
							AND CODRELAT = 'AC0812B' 
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
            /*" -458- EXEC SQL OPEN V1RELATORIOS END-EXEC. */

            V1RELATORIOS.Open();

        }

        [StopWatch]
        /*" R0700-00-DECLARE-V0COSCED-CHQ-DB-DECLARE-1 */
        public void R0700_00_DECLARE_V0COSCED_CHQ_DB_DECLARE_1()
        {
            /*" -746- EXEC SQL DECLARE V0COSCEDCHEQUE CURSOR FOR SELECT B.CONGENER, MAX(B.DTLIBERA) FROM SEGUROS.V0RELATORIOS A, SEGUROS.V0COSCED_CHEQUE B WHERE A.DATA_SOLICITACAO = :V1RELA-DATA-SOL AND A.IDSISTEM = :V1RELA-IDSISTEM AND A.CODRELAT = :V1RELA-CODRELAT AND A.COD_EMPRESA = :V1RELA-COD-EMPR AND B.COD_EMPRESA = A.COD_EMPRESA AND B.CONGENER = A.CONGENER AND B.DTMOVTO_AC < :V1SIST-DTMOVABE AND B.SITUACAO <> '2' GROUP BY B.CONGENER END-EXEC. */
            V0COSCEDCHEQUE = new AC0812B_V0COSCEDCHEQUE(true);
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
            /*" -478- MOVE '025' TO WNR-EXEC-SQL. */
            _.Move("025", WABEND.WNR_EXEC_SQL);

            /*" -490- PERFORM R0250_00_FETCH_V1RELATORIOS_DB_FETCH_1 */

            R0250_00_FETCH_V1RELATORIOS_DB_FETCH_1();

            /*" -493- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -494- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -495- MOVE 'S' TO WFIM-V1RELATORIOS */
                    _.Move("S", AREA_DE_WORK.WFIM_V1RELATORIOS);

                    /*" -495- PERFORM R0250_00_FETCH_V1RELATORIOS_DB_CLOSE_1 */

                    R0250_00_FETCH_V1RELATORIOS_DB_CLOSE_1();

                    /*" -497- ELSE */
                }
                else
                {


                    /*" -498- DISPLAY 'R0250 - ERRO NO FETCH DA V1RELATORIOS' */
                    _.Display($"R0250 - ERRO NO FETCH DA V1RELATORIOS");

                    /*" -499- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -500- END-IF */
                }


                /*" -500- END-IF. */
            }


        }

        [StopWatch]
        /*" R0250-00-FETCH-V1RELATORIOS-DB-FETCH-1 */
        public void R0250_00_FETCH_V1RELATORIOS_DB_FETCH_1()
        {
            /*" -490- EXEC SQL FETCH V1RELATORIOS INTO :V1RELA-COD-USU , :V1RELA-DATA-SOL , :V1RELA-IDSISTEM , :V1RELA-CODRELAT , :V1RELA-PERI-INI , :V1RELA-PERI-FIN , :V1RELA-DATA-REF , :V1RELA-CONGENER , :V1RELA-CODUNIMO , :V1RELA-CORRECAO , :V1RELA-COD-EMPR END-EXEC. */

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
            /*" -495- EXEC SQL CLOSE V1RELATORIOS END-EXEC */

            V1RELATORIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-PROCESSA-LIBERACAO-SECTION */
        private void R0300_00_PROCESSA_LIBERACAO_SECTION()
        {
            /*" -513- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", WABEND.WNR_EXEC_SQL);

            /*" -514- DISPLAY '                                  ' . */
            _.Display($"                                  ");

            /*" -516- DISPLAY 'COD. EMPRESA  - ' V1RELA-COD-EMPR. */
            _.Display($"COD. EMPRESA  - {V1RELA_COD_EMPR}");

            /*" -519- MOVE V1RELA-COD-EMPR TO WCOD-EMPR-ANT WHOST-COD-EMPR. */
            _.Move(V1RELA_COD_EMPR, AREA_DE_WORK.WCOD_EMPR_ANT, WHOST_COD_EMPR);

            /*" -521- PERFORM R0400-00-PROCESSA-EMPRESAS UNTIL WFIM-V1RELATORIOS NOT EQUAL SPACES OR V1RELA-COD-EMPR NOT EQUAL WCOD-EMPR-ANT. */

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
            /*" -534- MOVE '040' TO WNR-EXEC-SQL. */
            _.Move("040", WABEND.WNR_EXEC_SQL);

            /*" -538- MOVE V1RELA-CONGENER TO WHOST-CONGENER. */
            _.Move(V1RELA_CONGENER, WHOST_CONGENER);

            /*" -540- MOVE ZEROS TO WHOST-QTD-RELAT. */
            _.Move(0, WHOST_QTD_RELAT);

            /*" -542- PERFORM R0500-00-SELECT-V0RELATORIOS. */

            R0500_00_SELECT_V0RELATORIOS_SECTION();

            /*" -543- IF WHOST-QTD-RELAT > 1 */

            if (WHOST_QTD_RELAT > 1)
            {

                /*" -544- GO TO R0400-50-PROCESSA-SOLICITACOES */

                R0400_50_PROCESSA_SOLICITACOES(); //GOTO
                return;

                /*" -548- END-IF. */
            }


            /*" -551- MOVE ZEROS TO WHOST-QTD-RELAT WHOST-QTD-CONGN. */
            _.Move(0, WHOST_QTD_RELAT, WHOST_QTD_CONGN);

            /*" -553- PERFORM R0600-00-SELECT-RELAT-CONG. */

            R0600_00_SELECT_RELAT_CONG_SECTION();

            /*" -554- IF WHOST-QTD-RELAT NOT EQUAL WHOST-QTD-CONGN */

            if (WHOST_QTD_RELAT != WHOST_QTD_CONGN)
            {

                /*" -555- GO TO R0400-50-PROCESSA-SOLICITACOES */

                R0400_50_PROCESSA_SOLICITACOES(); //GOTO
                return;

                /*" -559- END-IF. */
            }


            /*" -561- MOVE 0 TO WTIP-SOLICIT. */
            _.Move(0, AREA_DE_WORK.WTIP_SOLICIT);

            /*" -563- MOVE '9999-12-31' TO WHOST-DTMOVTO. */
            _.Move("9999-12-31", WHOST_DTMOVTO);

            /*" -565- PERFORM R0700-00-DECLARE-V0COSCED-CHQ. */

            R0700_00_DECLARE_V0COSCED_CHQ_SECTION();

            /*" -568- DISPLAY 'R0400- PERIODO : ' WHOST-DTMOVTO ' A ' V1RELA-DATA-REF. */

            $"R0400- PERIODO : {WHOST_DTMOVTO} A {V1RELA_DATA_REF}"
            .Display();

            /*" -570- PERFORM R0800-00-DECLARE-V1COSGHISTP. */

            R0800_00_DECLARE_V1COSGHISTP_SECTION();

            /*" -572- PERFORM R0850-00-FETCH-V1COSGHISTP. */

            R0850_00_FETCH_V1COSGHISTP_SECTION();

            /*" -575- PERFORM R0900-00-PROCESSA-V1COSGHISTP UNTIL WFIM-V1COSSEGHIS NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1COSSEGHIS.IsEmpty()))
            {

                R0900_00_PROCESSA_V1COSGHISTP_SECTION();
            }

            /*" -576- MOVE WHOST-COD-EMPR TO V1RELA-COD-EMPR. */
            _.Move(WHOST_COD_EMPR, V1RELA_COD_EMPR);

            /*" -578- MOVE WHOST-CONGENER TO V1RELA-CONGENER. */
            _.Move(WHOST_CONGENER, V1RELA_CONGENER);

            /*" -584- PERFORM R1100-00-TRATA-SOLICITACAO UNTIL WFIM-V1RELATORIOS NOT EQUAL SPACES OR V1RELA-COD-EMPR NOT EQUAL WCOD-EMPR-ANT. */

            while (!(!AREA_DE_WORK.WFIM_V1RELATORIOS.IsEmpty() || V1RELA_COD_EMPR != AREA_DE_WORK.WCOD_EMPR_ANT))
            {

                R1100_00_TRATA_SOLICITACAO_SECTION();
            }

            /*" -584- GO TO R0400-99-SAIDA. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
            return;

        }

        [StopWatch]
        /*" R0400-50-PROCESSA-SOLICITACOES */
        private void R0400_50_PROCESSA_SOLICITACOES(bool isPerform = false)
        {
            /*" -593- MOVE 1 TO WTIP-SOLICIT. */
            _.Move(1, AREA_DE_WORK.WTIP_SOLICIT);

            /*" -595- PERFORM R1300-00-PROCESSA-SOLICITACAO UNTIL WFIM-V1RELATORIOS NOT EQUAL SPACES OR V1RELA-COD-EMPR NOT EQUAL WCOD-EMPR-ANT. */

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
            /*" -608- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", WABEND.WNR_EXEC_SQL);

            /*" -616- PERFORM R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1 */

            R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1();

            /*" -619- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -620- DISPLAY 'R0500 - ERRO NO SELECT DA V0RELATORIOS - 1' */
                _.Display($"R0500 - ERRO NO SELECT DA V0RELATORIOS - 1");

                /*" -621- DISPLAY 'DT SOLICT - ' V1RELA-DATA-SOL */
                _.Display($"DT SOLICT - {V1RELA_DATA_SOL}");

                /*" -622- DISPLAY 'IDE SISTM - ' V1RELA-IDSISTEM */
                _.Display($"IDE SISTM - {V1RELA_IDSISTEM}");

                /*" -623- DISPLAY 'COD RELAT - ' V1RELA-CODRELAT */
                _.Display($"COD RELAT - {V1RELA_CODRELAT}");

                /*" -624- DISPLAY 'COD EMPR  - ' V1RELA-COD-EMPR */
                _.Display($"COD EMPR  - {V1RELA_COD_EMPR}");

                /*" -625- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -626- ELSE */
            }
            else
            {


                /*" -627- IF WHOST-QTD-RELAT > 1 */

                if (WHOST_QTD_RELAT > 1)
                {

                    /*" -628- GO TO R0500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                    return;

                    /*" -629- END-IF */
                }


                /*" -633- END-IF. */
            }


            /*" -641- PERFORM R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2 */

            R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2();

            /*" -644- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -645- DISPLAY 'R0500 - ERRO NO SELECT DA V0RELATORIOS - 2' */
                _.Display($"R0500 - ERRO NO SELECT DA V0RELATORIOS - 2");

                /*" -646- DISPLAY 'DT SOLICT - ' V1RELA-DATA-SOL */
                _.Display($"DT SOLICT - {V1RELA_DATA_SOL}");

                /*" -647- DISPLAY 'IDE SISTM - ' V1RELA-IDSISTEM */
                _.Display($"IDE SISTM - {V1RELA_IDSISTEM}");

                /*" -648- DISPLAY 'COD RELAT - ' V1RELA-CODRELAT */
                _.Display($"COD RELAT - {V1RELA_CODRELAT}");

                /*" -649- DISPLAY 'COD EMPR  - ' V1RELA-COD-EMPR */
                _.Display($"COD EMPR  - {V1RELA_COD_EMPR}");

                /*" -650- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -651- ELSE */
            }
            else
            {


                /*" -652- IF WHOST-QTD-RELAT > 1 */

                if (WHOST_QTD_RELAT > 1)
                {

                    /*" -653- GO TO R0500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                    return;

                    /*" -654- END-IF */
                }


                /*" -658- END-IF. */
            }


            /*" -666- PERFORM R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3 */

            R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3();

            /*" -669- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -670- DISPLAY 'R0500 - ERRO NO SELECT DA V0RELATORIOS - 3' */
                _.Display($"R0500 - ERRO NO SELECT DA V0RELATORIOS - 3");

                /*" -671- DISPLAY 'DT SOLICT - ' V1RELA-DATA-SOL */
                _.Display($"DT SOLICT - {V1RELA_DATA_SOL}");

                /*" -672- DISPLAY 'IDE SISTM - ' V1RELA-IDSISTEM */
                _.Display($"IDE SISTM - {V1RELA_IDSISTEM}");

                /*" -673- DISPLAY 'COD RELAT - ' V1RELA-CODRELAT */
                _.Display($"COD RELAT - {V1RELA_CODRELAT}");

                /*" -674- DISPLAY 'COD EMPR  - ' V1RELA-COD-EMPR */
                _.Display($"COD EMPR  - {V1RELA_COD_EMPR}");

                /*" -675- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -675- END-IF. */
            }


        }

        [StopWatch]
        /*" R0500-00-SELECT-V0RELATORIOS-DB-SELECT-1 */
        public void R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -616- EXEC SQL SELECT VALUE(COUNT(DISTINCT DATA_REFERENCIA),+0) INTO :WHOST-QTD-RELAT FROM SEGUROS.V0RELATORIOS WHERE DATA_SOLICITACAO = :V1RELA-DATA-SOL AND IDSISTEM = :V1RELA-IDSISTEM AND CODRELAT = :V1RELA-CODRELAT AND COD_EMPRESA = :V1RELA-COD-EMPR END-EXEC. */

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
            /*" -641- EXEC SQL SELECT VALUE(COUNT(DISTINCT PERI_INICIAL),+0) INTO :WHOST-QTD-RELAT FROM SEGUROS.V0RELATORIOS WHERE DATA_SOLICITACAO = :V1RELA-DATA-SOL AND IDSISTEM = :V1RELA-IDSISTEM AND CODRELAT = :V1RELA-CODRELAT AND COD_EMPRESA = :V1RELA-COD-EMPR END-EXEC. */

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
            /*" -688- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", WABEND.WNR_EXEC_SQL);

            /*" -696- PERFORM R0600_00_SELECT_RELAT_CONG_DB_SELECT_1 */

            R0600_00_SELECT_RELAT_CONG_DB_SELECT_1();

            /*" -699- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -700- DISPLAY 'R0600 - ERRO NO SELECT DA V0RELATORIOS' */
                _.Display($"R0600 - ERRO NO SELECT DA V0RELATORIOS");

                /*" -701- DISPLAY 'DT SOLICT - ' V1RELA-DATA-SOL */
                _.Display($"DT SOLICT - {V1RELA_DATA_SOL}");

                /*" -702- DISPLAY 'IDE SISTM - ' V1RELA-IDSISTEM */
                _.Display($"IDE SISTM - {V1RELA_IDSISTEM}");

                /*" -703- DISPLAY 'COD RELAT - ' V1RELA-CODRELAT */
                _.Display($"COD RELAT - {V1RELA_CODRELAT}");

                /*" -704- DISPLAY 'COD EMPR  - ' V1RELA-COD-EMPR */
                _.Display($"COD EMPR  - {V1RELA_COD_EMPR}");

                /*" -705- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -709- END-IF. */
            }


            /*" -713- PERFORM R0600_00_SELECT_RELAT_CONG_DB_SELECT_2 */

            R0600_00_SELECT_RELAT_CONG_DB_SELECT_2();

            /*" -716- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -717- DISPLAY 'R0600 - ERRO NO SELECT DA V0CONGENERE' */
                _.Display($"R0600 - ERRO NO SELECT DA V0CONGENERE");

                /*" -718- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -718- END-IF. */
            }


        }

        [StopWatch]
        /*" R0600-00-SELECT-RELAT-CONG-DB-SELECT-1 */
        public void R0600_00_SELECT_RELAT_CONG_DB_SELECT_1()
        {
            /*" -696- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WHOST-QTD-RELAT FROM SEGUROS.V0RELATORIOS WHERE DATA_SOLICITACAO = :V1RELA-DATA-SOL AND IDSISTEM = :V1RELA-IDSISTEM AND CODRELAT = :V1RELA-CODRELAT AND COD_EMPRESA = :V1RELA-COD-EMPR END-EXEC. */

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
            /*" -666- EXEC SQL SELECT VALUE(COUNT(DISTINCT CODUNIMO),+0) INTO :WHOST-QTD-RELAT FROM SEGUROS.V0RELATORIOS WHERE DATA_SOLICITACAO = :V1RELA-DATA-SOL AND IDSISTEM = :V1RELA-IDSISTEM AND CODRELAT = :V1RELA-CODRELAT AND COD_EMPRESA = :V1RELA-COD-EMPR END-EXEC. */

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
            /*" -713- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WHOST-QTD-CONGN FROM SEGUROS.V0CONGENERE END-EXEC. */

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
            /*" -731- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", WABEND.WNR_EXEC_SQL);

            /*" -746- PERFORM R0700_00_DECLARE_V0COSCED_CHQ_DB_DECLARE_1 */

            R0700_00_DECLARE_V0COSCED_CHQ_DB_DECLARE_1();

            /*" -748- PERFORM R0700_00_DECLARE_V0COSCED_CHQ_DB_OPEN_1 */

            R0700_00_DECLARE_V0COSCED_CHQ_DB_OPEN_1();

            /*" -751- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -752- DISPLAY 'R0700 - ERRO NO DECLARE DA V0COSCED_CHEQUE' */
                _.Display($"R0700 - ERRO NO DECLARE DA V0COSCED_CHEQUE");

                /*" -753- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -753- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0700_10_LER_V0COSCEDCHEQUE */

            R0700_10_LER_V0COSCEDCHEQUE();

        }

        [StopWatch]
        /*" R0700-00-DECLARE-V0COSCED-CHQ-DB-OPEN-1 */
        public void R0700_00_DECLARE_V0COSCED_CHQ_DB_OPEN_1()
        {
            /*" -748- EXEC SQL OPEN V0COSCEDCHEQUE END-EXEC. */

            V0COSCEDCHEQUE.Open();

        }

        [StopWatch]
        /*" R0800-00-DECLARE-V1COSGHISTP-DB-DECLARE-1 */
        public void R0800_00_DECLARE_V1COSGHISTP_DB_DECLARE_1()
        {
            /*" -841- EXEC SQL DECLARE V1COSGHISTP CURSOR FOR SELECT COD_EMPRESA , CONGENER , NUM_APOLICE , NRENDOS , NRPARCEL , OCORHIST , OPERACAO , TIPSGU , PRM_TARIFARIO, VAL_DESCONTO , VLPRMLIQ , VLADIFRA , VLCOMIS , VLPRMTOT , DTMOVTO , DTQITBCO , NUMOCOR FROM SEGUROS.V1COSSEG_HISTPRE WHERE COD_EMPRESA = :V1RELA-COD-EMPR AND DTMOVTO BETWEEN :WHOST-DTMOVTO AND :V1RELA-DATA-REF AND TIPSGU = '1' AND SIT_FINANCEIRA = '0' AND SIT_LIBRECUP = '0' AND ((OPERACAO BETWEEN 0200 AND 0300) OR (OPERACAO BETWEEN 0920 AND 0921) OR (OPERACAO BETWEEN 0960 AND 0961)) ORDER BY CONGENER, NUM_APOLICE, NRENDOS, NRPARCEL, OCORHIST END-EXEC. */
            V1COSGHISTP = new AC0812B_V1COSGHISTP(true);
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
							AND ((OPERACAO BETWEEN 0200 AND 0300) 
							OR (OPERACAO BETWEEN 0920 AND 0921) 
							OR (OPERACAO BETWEEN 0960 AND 0961)) 
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
            /*" -763- PERFORM R0700_10_LER_V0COSCEDCHEQUE_DB_FETCH_1 */

            R0700_10_LER_V0COSCEDCHEQUE_DB_FETCH_1();

            /*" -766- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -767- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -767- PERFORM R0700_10_LER_V0COSCEDCHEQUE_DB_CLOSE_1 */

                    R0700_10_LER_V0COSCEDCHEQUE_DB_CLOSE_1();

                    /*" -769- GO TO R0700-90-QTDE-REGT */

                    R0700_90_QTDE_REGT(); //GOTO
                    return;

                    /*" -770- ELSE */
                }
                else
                {


                    /*" -771- DISPLAY 'R0700 - ERRO FETCH V0COSCED_CHEQUE' */
                    _.Display($"R0700 - ERRO FETCH V0COSCED_CHEQUE");

                    /*" -772- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -773- END-IF */
                }


                /*" -774- ELSE */
            }
            else
            {


                /*" -775- ADD 1 TO WHOST-QTD-COSCH */
                WHOST_QTD_COSCH.Value = WHOST_QTD_COSCH + 1;

                /*" -777- END-IF. */
            }


            /*" -778- IF WHOST-DTMOVTO > V1CCHQ-DTLIBERA */

            if (WHOST_DTMOVTO > V1CCHQ_DTLIBERA)
            {

                /*" -779- MOVE V1CCHQ-DTLIBERA TO WHOST-DTMOVTO */
                _.Move(V1CCHQ_DTLIBERA, WHOST_DTMOVTO);

                /*" -783- END-IF. */
            }


            /*" -783- GO TO R0700-10-LER-V0COSCEDCHEQUE. */
            new Task(() => R0700_10_LER_V0COSCEDCHEQUE()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0700-10-LER-V0COSCEDCHEQUE-DB-FETCH-1 */
        public void R0700_10_LER_V0COSCEDCHEQUE_DB_FETCH_1()
        {
            /*" -763- EXEC SQL FETCH V0COSCEDCHEQUE INTO :V1CCHQ-CONGENER, :V1CCHQ-DTLIBERA END-EXEC. */

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
            /*" -767- EXEC SQL CLOSE V0COSCEDCHEQUE END-EXEC */

            V0COSCEDCHEQUE.Close();

        }

        [StopWatch]
        /*" R0700-90-QTDE-REGT */
        private void R0700_90_QTDE_REGT(bool isPerform = false)
        {
            /*" -791- IF WHOST-QTD-COSCH NOT EQUAL WHOST-QTD-RELAT */

            if (WHOST_QTD_COSCH != WHOST_QTD_RELAT)
            {

                /*" -792- MOVE '1990-01-01' TO WHOST-DTMOVTO */
                _.Move("1990-01-01", WHOST_DTMOVTO);

                /*" -792- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-DECLARE-V1COSGHISTP-SECTION */
        private void R0800_00_DECLARE_V1COSGHISTP_SECTION()
        {
            /*" -805- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", WABEND.WNR_EXEC_SQL);

            /*" -841- PERFORM R0800_00_DECLARE_V1COSGHISTP_DB_DECLARE_1 */

            R0800_00_DECLARE_V1COSGHISTP_DB_DECLARE_1();

            /*" -843- PERFORM R0800_00_DECLARE_V1COSGHISTP_DB_OPEN_1 */

            R0800_00_DECLARE_V1COSGHISTP_DB_OPEN_1();

            /*" -846- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -847- DISPLAY 'R0800 - ERRO NO DECLARE DA V1COSSEG_HISTPRE' */
                _.Display($"R0800 - ERRO NO DECLARE DA V1COSSEG_HISTPRE");

                /*" -848- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -849- ELSE */
            }
            else
            {


                /*" -850- MOVE SPACES TO WFIM-V1COSSEGHIS */
                _.Move("", AREA_DE_WORK.WFIM_V1COSSEGHIS);

                /*" -850- END-IF. */
            }


        }

        [StopWatch]
        /*" R0800-00-DECLARE-V1COSGHISTP-DB-OPEN-1 */
        public void R0800_00_DECLARE_V1COSGHISTP_DB_OPEN_1()
        {
            /*" -843- EXEC SQL OPEN V1COSGHISTP END-EXEC. */

            V1COSGHISTP.Open();

        }

        [StopWatch]
        /*" R1500-00-DECLARE-V1COSSEGHIS-DB-DECLARE-1 */
        public void R1500_00_DECLARE_V1COSSEGHIS_DB_DECLARE_1()
        {
            /*" -1224- EXEC SQL DECLARE V1COSSEGHIS CURSOR FOR SELECT COD_EMPRESA , CONGENER , NUM_APOLICE , NRENDOS , NRPARCEL , OCORHIST , OPERACAO , TIPSGU , PRM_TARIFARIO, VAL_DESCONTO , VLPRMLIQ , VLADIFRA , VLCOMIS , VLPRMTOT , DTMOVTO , DTQITBCO , NUMOCOR FROM SEGUROS.V1COSSEG_HISTPRE WHERE COD_EMPRESA = :V1RELA-COD-EMPR AND CONGENER = :V1RELA-CONGENER AND DTMOVTO BETWEEN :WHOST-DTMOVTO AND :V1RELA-DATA-REF AND TIPSGU = '1' AND SIT_FINANCEIRA = '0' AND SIT_LIBRECUP = '0' AND ((OPERACAO BETWEEN 0200 AND 0300) OR (OPERACAO BETWEEN 0920 AND 0921) OR (OPERACAO BETWEEN 0960 AND 0961)) ORDER BY CONGENER, NUM_APOLICE, NRENDOS, NRPARCEL, OCORHIST END-EXEC. */
            V1COSSEGHIS = new AC0812B_V1COSSEGHIS(true);
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
							AND ((OPERACAO BETWEEN 0200 AND 0300) 
							OR (OPERACAO BETWEEN 0920 AND 0921) 
							OR (OPERACAO BETWEEN 0960 AND 0961)) 
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
            /*" -863- MOVE '085' TO WNR-EXEC-SQL. */
            _.Move("085", WABEND.WNR_EXEC_SQL);

            /*" -881- PERFORM R0850_00_FETCH_V1COSGHISTP_DB_FETCH_1 */

            R0850_00_FETCH_V1COSGHISTP_DB_FETCH_1();

            /*" -884- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -885- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -886- MOVE 'S' TO WFIM-V1COSSEGHIS */
                    _.Move("S", AREA_DE_WORK.WFIM_V1COSSEGHIS);

                    /*" -886- PERFORM R0850_00_FETCH_V1COSGHISTP_DB_CLOSE_1 */

                    R0850_00_FETCH_V1COSGHISTP_DB_CLOSE_1();

                    /*" -888- ELSE */
                }
                else
                {


                    /*" -889- DISPLAY 'R0850 - ERRO NO FETCH DA V1COSSEG_HISTPRE' */
                    _.Display($"R0850 - ERRO NO FETCH DA V1COSSEG_HISTPRE");

                    /*" -890- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -891- END-IF */
                }


                /*" -892- ELSE */
            }
            else
            {


                /*" -893- IF VIND-DAT-QTBC < ZEROS */

                if (VIND_DAT_QTBC < 00)
                {

                    /*" -894- MOVE SPACES TO V1CHIS-DTQITBCO */
                    _.Move("", V1CHIS_DTQITBCO);

                    /*" -895- END-IF */
                }


                /*" -895- END-IF. */
            }


        }

        [StopWatch]
        /*" R0850-00-FETCH-V1COSGHISTP-DB-FETCH-1 */
        public void R0850_00_FETCH_V1COSGHISTP_DB_FETCH_1()
        {
            /*" -881- EXEC SQL FETCH V1COSGHISTP INTO :V1CHIS-COD-EMPR , :V1CHIS-CONGENER , :V1CHIS-NUM-APOL , :V1CHIS-NUM-ENDS , :V1CHIS-NRPARCEL , :V1CHIS-OCORHIST , :V1CHIS-OPERACAO , :V1CHIS-TIP-SEGU , :V1CHIS-PRM-TARF , :V1CHIS-VAL-DESC , :V1CHIS-VLPRMLIQ , :V1CHIS-VLADIFRA , :V1CHIS-VLCOMISS , :V1CHIS-VLPRMTOT , :V1CHIS-DAT-MOVT , :V1CHIS-DTQITBCO:VIND-DAT-QTBC, :V1CHIS-NUM-OCOR:VIND-NUM-OCOR END-EXEC. */

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
        /*" R0850-00-FETCH-V1COSGHISTP-DB-CLOSE-1 */
        public void R0850_00_FETCH_V1COSGHISTP_DB_CLOSE_1()
        {
            /*" -886- EXEC SQL CLOSE V1COSGHISTP END-EXEC */

            V1COSGHISTP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-PROCESSA-V1COSGHISTP-SECTION */
        private void R0900_00_PROCESSA_V1COSGHISTP_SECTION()
        {
            /*" -908- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -911- MOVE V1CHIS-CONGENER TO WCOD-CONG-ANT V1RELA-CONGENER. */
            _.Move(V1CHIS_CONGENER, AREA_DE_WORK.WCOD_CONG_ANT, V1RELA_CONGENER);

            /*" -916- MOVE ZEROS TO AC-U-COSSEGPRE AC-L-COSSEGHIS AC-U-COSSEGHIS AC-I-COSSEGHIS. */
            _.Move(0, AREA_DE_WORK.AC_U_COSSEGPRE, AREA_DE_WORK.AC_L_COSSEGHIS, AREA_DE_WORK.AC_U_COSSEGHIS, AREA_DE_WORK.AC_I_COSSEGHIS);

            /*" -922- MOVE ZEROS TO AC-PRM-TARF AC-DESCONTO AC-VLADIFRA AC-COMISSAO AC-PRMLIQ-6668. */
            _.Move(0, AREA_DE_WORK.AC_PRM_TARF, AREA_DE_WORK.AC_DESCONTO, AREA_DE_WORK.AC_VLADIFRA, AREA_DE_WORK.AC_COMISSAO, AREA_DE_WORK.AC_PRMLIQ_6668);

            /*" -923- DISPLAY 'COD. USUARIO  - ' V1RELA-COD-USU. */
            _.Display($"COD. USUARIO  - {V1RELA_COD_USU}");

            /*" -925- DISPLAY 'CONGENERE     - ' V1RELA-CONGENER. */
            _.Display($"CONGENERE     - {V1RELA_CONGENER}");

            /*" -927- IF V1RELA-CODUNIMO GREATER ZEROS AND V1RELA-PERI-INI NOT EQUAL '0001-01-01' */

            if (V1RELA_CODUNIMO > 00 && V1RELA_PERI_INI != "0001-01-01")
            {

                /*" -928- MOVE V1RELA-CODUNIMO TO V1MOED-CODUNIMO */
                _.Move(V1RELA_CODUNIMO, V1MOED_CODUNIMO);

                /*" -929- MOVE V1RELA-PERI-INI TO V1MOED-DTINIVIG */
                _.Move(V1RELA_PERI_INI, V1MOED_DTINIVIG);

                /*" -930- PERFORM R1000-00-SELECT-V1MOEDA */

                R1000_00_SELECT_V1MOEDA_SECTION();

                /*" -931- MOVE V1MOED-VLCRUZAD TO WHOST-VLCRUZAD1 */
                _.Move(V1MOED_VLCRUZAD, WHOST_VLCRUZAD1);

                /*" -933- END-IF. */
            }


            /*" -937- PERFORM R1600-00-PROCESSA-DOCUMENTO UNTIL WFIM-V1COSSEGHIS NOT EQUAL SPACES OR V1CHIS-CONGENER NOT EQUAL WCOD-CONG-ANT. */

            while (!(!AREA_DE_WORK.WFIM_V1COSSEGHIS.IsEmpty() || V1CHIS_CONGENER != AREA_DE_WORK.WCOD_CONG_ANT))
            {

                R1600_00_PROCESSA_DOCUMENTO_SECTION();
            }

            /*" -939- PERFORM R3000-00-MONTA-COSCED-CHEQUE. */

            R3000_00_MONTA_COSCED_CHEQUE_SECTION();

            /*" -940- DISPLAY '**** AC0812B ****' . */
            _.Display($"**** AC0812B ****");

            /*" -941- DISPLAY '- COSSEG-PREM    ' . */
            _.Display($"- COSSEG-PREM    ");

            /*" -942- DISPLAY ' .ATUALIZADOS... ' AC-U-COSSEGPRE. */
            _.Display($" .ATUALIZADOS... {AREA_DE_WORK.AC_U_COSSEGPRE}");

            /*" -943- DISPLAY ' ' . */
            _.Display($" ");

            /*" -944- DISPLAY '- COSSEG-HISTPRE ' . */
            _.Display($"- COSSEG-HISTPRE ");

            /*" -945- DISPLAY ' .LIDOS......... ' AC-L-COSSEGHIS. */
            _.Display($" .LIDOS......... {AREA_DE_WORK.AC_L_COSSEGHIS}");

            /*" -946- DISPLAY ' .ATUALIZADOS... ' AC-U-COSSEGHIS. */
            _.Display($" .ATUALIZADOS... {AREA_DE_WORK.AC_U_COSSEGHIS}");

            /*" -947- DISPLAY ' .INSERT........ ' AC-I-COSSEGHIS. */
            _.Display($" .INSERT........ {AREA_DE_WORK.AC_I_COSSEGHIS}");

            /*" -948- DISPLAY ' ' . */
            _.Display($" ");

            /*" -949- DISPLAY '- VALORES ACUM.  ' . */
            _.Display($"- VALORES ACUM.  ");

            /*" -950- DISPLAY ' .PRM TARIFARIO. ' AC-PRM-TARF. */
            _.Display($" .PRM TARIFARIO. {AREA_DE_WORK.AC_PRM_TARF}");

            /*" -951- DISPLAY ' .DESCONTO ..... ' AC-DESCONTO. */
            _.Display($" .DESCONTO ..... {AREA_DE_WORK.AC_DESCONTO}");

            /*" -952- DISPLAY ' .ADIC FRACION.. ' AC-VLADIFRA. */
            _.Display($" .ADIC FRACION.. {AREA_DE_WORK.AC_VLADIFRA}");

            /*" -953- DISPLAY ' .COMISSAO...... ' AC-COMISSAO. */
            _.Display($" .COMISSAO...... {AREA_DE_WORK.AC_COMISSAO}");

            /*" -953- DISPLAY ' .PRM-LIQ-6668.. ' AC-PRMLIQ-6668. */
            _.Display($" .PRM-LIQ-6668.. {AREA_DE_WORK.AC_PRMLIQ_6668}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-SELECT-V1MOEDA-SECTION */
        private void R1000_00_SELECT_V1MOEDA_SECTION()
        {
            /*" -966- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -976- PERFORM R1000_00_SELECT_V1MOEDA_DB_SELECT_1 */

            R1000_00_SELECT_V1MOEDA_DB_SELECT_1();

            /*" -979- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -980- DISPLAY 'R1000 - ERRO NO SELECT DA V1MOEDA' */
                _.Display($"R1000 - ERRO NO SELECT DA V1MOEDA");

                /*" -981- DISPLAY 'EMPRESA   - ' V1CHIS-COD-EMPR */
                _.Display($"EMPRESA   - {V1CHIS_COD_EMPR}");

                /*" -982- DISPLAY 'COD CONG  - ' V1CHIS-CONGENER */
                _.Display($"COD CONG  - {V1CHIS_CONGENER}");

                /*" -983- DISPLAY 'APOLICE   - ' V1CHIS-NUM-APOL */
                _.Display($"APOLICE   - {V1CHIS_NUM_APOL}");

                /*" -984- DISPLAY 'ENDOSSO   - ' V1CHIS-NUM-ENDS */
                _.Display($"ENDOSSO   - {V1CHIS_NUM_ENDS}");

                /*" -985- DISPLAY 'COD MOEDA - ' V1MOED-CODUNIMO */
                _.Display($"COD MOEDA - {V1MOED_CODUNIMO}");

                /*" -986- DISPLAY 'INIC VIGC - ' V1MOED-DTINIVIG */
                _.Display($"INIC VIGC - {V1MOED_DTINIVIG}");

                /*" -987- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -987- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-00-SELECT-V1MOEDA-DB-SELECT-1 */
        public void R1000_00_SELECT_V1MOEDA_DB_SELECT_1()
        {
            /*" -976- EXEC SQL SELECT VAL_VENDA INTO :V1MOED-VLCRUZAD FROM SEGUROS.V1COTACAO WHERE CODUNIMO = :V1MOED-CODUNIMO AND DTINIVIG <= :V1MOED-DTINIVIG AND DTTERVIG >= :V1MOED-DTINIVIG END-EXEC. */

            var r1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 = new R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1()
            {
                V1MOED_CODUNIMO = V1MOED_CODUNIMO.ToString(),
                V1MOED_DTINIVIG = V1MOED_DTINIVIG.ToString(),
            };

            var executed_1 = R1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1.Execute(r1000_00_SELECT_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MOED_VLCRUZAD, V1MOED_VLCRUZAD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-TRATA-SOLICITACAO-SECTION */
        private void R1100_00_TRATA_SOLICITACAO_SECTION()
        {
            /*" -1000- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -1006- MOVE ZEROS TO AC-PRM-TARF AC-DESCONTO AC-VLADIFRA AC-COMISSAO AC-PRMLIQ-6668. */
            _.Move(0, AREA_DE_WORK.AC_PRM_TARF, AREA_DE_WORK.AC_DESCONTO, AREA_DE_WORK.AC_VLADIFRA, AREA_DE_WORK.AC_COMISSAO, AREA_DE_WORK.AC_PRMLIQ_6668);

            /*" -1008- PERFORM R3000-00-MONTA-COSCED-CHEQUE. */

            R3000_00_MONTA_COSCED_CHEQUE_SECTION();

            /*" -1012- PERFORM R1200-00-DELETE-V0RELATORIOS. */

            R1200_00_DELETE_V0RELATORIOS_SECTION();

            /*" -1012- PERFORM R0250-00-FETCH-V1RELATORIOS. */

            R0250_00_FETCH_V1RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-DELETE-V0RELATORIOS-SECTION */
        private void R1200_00_DELETE_V0RELATORIOS_SECTION()
        {
            /*" -1025- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -1033- PERFORM R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1 */

            R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1();

            /*" -1036- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1038- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1039- ELSE */
                }
                else
                {


                    /*" -1040- DISPLAY 'R1200 - ERRO NO DELETE DA V0RELATORIOS' */
                    _.Display($"R1200 - ERRO NO DELETE DA V0RELATORIOS");

                    /*" -1041- DISPLAY 'COD USUARIO - ' V1RELA-COD-USU */
                    _.Display($"COD USUARIO - {V1RELA_COD_USU}");

                    /*" -1042- DISPLAY 'DAT SOLICIT - ' V1RELA-DATA-SOL */
                    _.Display($"DAT SOLICIT - {V1RELA_DATA_SOL}");

                    /*" -1043- DISPLAY 'IDE SISTEMA - ' V1RELA-IDSISTEM */
                    _.Display($"IDE SISTEMA - {V1RELA_IDSISTEM}");

                    /*" -1044- DISPLAY 'COD RELAT   - ' V1RELA-CODRELAT */
                    _.Display($"COD RELAT   - {V1RELA_CODRELAT}");

                    /*" -1045- DISPLAY 'CONGENERE   - ' V1RELA-CONGENER */
                    _.Display($"CONGENERE   - {V1RELA_CONGENER}");

                    /*" -1046- DISPLAY 'COD EMPRESA - ' V1RELA-COD-EMPR */
                    _.Display($"COD EMPRESA - {V1RELA_COD_EMPR}");

                    /*" -1047- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1048- END-IF */
                }


                /*" -1048- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-DELETE-V0RELATORIOS-DB-DELETE-1 */
        public void R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1()
        {
            /*" -1033- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE CODUSU = :V1RELA-COD-USU AND DATA_SOLICITACAO = :V1RELA-DATA-SOL AND IDSISTEM = :V1RELA-IDSISTEM AND CODRELAT = :V1RELA-CODRELAT AND CONGENER = :V1RELA-CONGENER AND COD_EMPRESA = :V1RELA-COD-EMPR END-EXEC. */

            var r1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 = new R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1()
            {
                V1RELA_COD_USU = V1RELA_COD_USU.ToString(),
                V1RELA_DATA_SOL = V1RELA_DATA_SOL.ToString(),
                V1RELA_IDSISTEM = V1RELA_IDSISTEM.ToString(),
                V1RELA_CODRELAT = V1RELA_CODRELAT.ToString(),
                V1RELA_CONGENER = V1RELA_CONGENER.ToString(),
                V1RELA_COD_EMPR = V1RELA_COD_EMPR.ToString(),
            };

            R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1.Execute(r1200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-PROCESSA-SOLICITACAO-SECTION */
        private void R1300_00_PROCESSA_SOLICITACAO_SECTION()
        {
            /*" -1061- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -1066- MOVE ZEROS TO AC-U-COSSEGPRE AC-L-COSSEGHIS AC-U-COSSEGHIS AC-I-COSSEGHIS. */
            _.Move(0, AREA_DE_WORK.AC_U_COSSEGPRE, AREA_DE_WORK.AC_L_COSSEGHIS, AREA_DE_WORK.AC_U_COSSEGHIS, AREA_DE_WORK.AC_I_COSSEGHIS);

            /*" -1072- MOVE ZEROS TO AC-PRM-TARF AC-DESCONTO AC-VLADIFRA AC-COMISSAO AC-PRMLIQ-6668. */
            _.Move(0, AREA_DE_WORK.AC_PRM_TARF, AREA_DE_WORK.AC_DESCONTO, AREA_DE_WORK.AC_VLADIFRA, AREA_DE_WORK.AC_COMISSAO, AREA_DE_WORK.AC_PRMLIQ_6668);

            /*" -1074- MOVE SPACES TO WHOST-DTMOVTO. */
            _.Move("", WHOST_DTMOVTO);

            /*" -1075- DISPLAY 'COD. USUARIO - ' V1RELA-COD-USU. */
            _.Display($"COD. USUARIO - {V1RELA_COD_USU}");

            /*" -1077- DISPLAY 'CONGENERE    - ' V1RELA-CONGENER. */
            _.Display($"CONGENERE    - {V1RELA_CONGENER}");

            /*" -1079- PERFORM R1400-00-SELECT-V0COSCED-CHQ. */

            R1400_00_SELECT_V0COSCED_CHQ_SECTION();

            /*" -1082- DISPLAY 'PERIODO      - ' WHOST-DTMOVTO ' A ' V1RELA-DATA-REF. */

            $"PERIODO      - {WHOST_DTMOVTO} A {V1RELA_DATA_REF}"
            .Display();

            /*" -1083- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -1084- MOVE WHH-ACCEPT TO WHH-EDT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WHH_EDT);

            /*" -1085- MOVE WMM-ACCEPT TO WMM-EDT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WMM_EDT);

            /*" -1086- MOVE WSS-ACCEPT TO WSS-EDT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WSS_EDT);

            /*" -1088- DISPLAY 'INICIO  DECLARE -  V1COSSEGHIS ' WHORA-EDIT. */
            _.Display($"INICIO  DECLARE -  V1COSSEGHIS {AREA_DE_WORK.WHORA_EDIT}");

            /*" -1090- PERFORM R1500-00-DECLARE-V1COSSEGHIS. */

            R1500_00_DECLARE_V1COSSEGHIS_SECTION();

            /*" -1091- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -1092- MOVE WHH-ACCEPT TO WHH-EDT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WHH_EDT);

            /*" -1093- MOVE WMM-ACCEPT TO WMM-EDT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WMM_EDT);

            /*" -1094- MOVE WSS-ACCEPT TO WSS-EDT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WSS_EDT);

            /*" -1096- DISPLAY 'FINAL   DECLARE -  V1COSSEGHIS ' WHORA-EDIT. */
            _.Display($"FINAL   DECLARE -  V1COSSEGHIS {AREA_DE_WORK.WHORA_EDIT}");

            /*" -1098- PERFORM R1550-00-FETCH-V1COSSEGHIS. */

            R1550_00_FETCH_V1COSSEGHIS_SECTION();

            /*" -1099- IF WFIM-V1COSSEGHIS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1COSSEGHIS.IsEmpty())
            {

                /*" -1100- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -1101- GO TO R1300-90-LER-V1RELATORIOS */

                R1300_90_LER_V1RELATORIOS(); //GOTO
                return;

                /*" -1103- END-IF. */
            }


            /*" -1105- IF V1RELA-CODUNIMO GREATER ZEROS AND V1RELA-PERI-INI NOT EQUAL '0001-01-01' */

            if (V1RELA_CODUNIMO > 00 && V1RELA_PERI_INI != "0001-01-01")
            {

                /*" -1106- MOVE V1RELA-CODUNIMO TO V1MOED-CODUNIMO */
                _.Move(V1RELA_CODUNIMO, V1MOED_CODUNIMO);

                /*" -1107- MOVE V1RELA-PERI-INI TO V1MOED-DTINIVIG */
                _.Move(V1RELA_PERI_INI, V1MOED_DTINIVIG);

                /*" -1108- PERFORM R1000-00-SELECT-V1MOEDA */

                R1000_00_SELECT_V1MOEDA_SECTION();

                /*" -1109- MOVE V1MOED-VLCRUZAD TO WHOST-VLCRUZAD1 */
                _.Move(V1MOED_VLCRUZAD, WHOST_VLCRUZAD1);

                /*" -1111- END-IF. */
            }


            /*" -1114- PERFORM R1600-00-PROCESSA-DOCUMENTO UNTIL WFIM-V1COSSEGHIS NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1COSSEGHIS.IsEmpty()))
            {

                R1600_00_PROCESSA_DOCUMENTO_SECTION();
            }

            /*" -1115- DISPLAY '**** AC0812B ****' . */
            _.Display($"**** AC0812B ****");

            /*" -1116- DISPLAY '- COSSEG-PREM    ' . */
            _.Display($"- COSSEG-PREM    ");

            /*" -1117- DISPLAY ' .ATUALIZADOS... ' AC-U-COSSEGPRE. */
            _.Display($" .ATUALIZADOS... {AREA_DE_WORK.AC_U_COSSEGPRE}");

            /*" -1118- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1119- DISPLAY '- COSSEG-HISTPRE ' . */
            _.Display($"- COSSEG-HISTPRE ");

            /*" -1120- DISPLAY ' .LIDOS......... ' AC-L-COSSEGHIS. */
            _.Display($" .LIDOS......... {AREA_DE_WORK.AC_L_COSSEGHIS}");

            /*" -1121- DISPLAY ' .ATUALIZADOS... ' AC-U-COSSEGHIS. */
            _.Display($" .ATUALIZADOS... {AREA_DE_WORK.AC_U_COSSEGHIS}");

            /*" -1122- DISPLAY ' .INSERT........ ' AC-I-COSSEGHIS. */
            _.Display($" .INSERT........ {AREA_DE_WORK.AC_I_COSSEGHIS}");

            /*" -1123- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1124- DISPLAY '- VALORES ACUM.  ' . */
            _.Display($"- VALORES ACUM.  ");

            /*" -1125- DISPLAY ' .PRM TARIFARIO. ' AC-PRM-TARF. */
            _.Display($" .PRM TARIFARIO. {AREA_DE_WORK.AC_PRM_TARF}");

            /*" -1126- DISPLAY ' .DESCONTO ..... ' AC-DESCONTO. */
            _.Display($" .DESCONTO ..... {AREA_DE_WORK.AC_DESCONTO}");

            /*" -1127- DISPLAY ' .ADIC FRACION.. ' AC-VLADIFRA. */
            _.Display($" .ADIC FRACION.. {AREA_DE_WORK.AC_VLADIFRA}");

            /*" -1128- DISPLAY ' .COMISSAO...... ' AC-COMISSAO. */
            _.Display($" .COMISSAO...... {AREA_DE_WORK.AC_COMISSAO}");

            /*" -1128- DISPLAY ' .PRM-LIQ-6668.. ' AC-PRMLIQ-6668. */
            _.Display($" .PRM-LIQ-6668.. {AREA_DE_WORK.AC_PRMLIQ_6668}");

            /*" -0- FLUXCONTROL_PERFORM R1300_90_LER_V1RELATORIOS */

            R1300_90_LER_V1RELATORIOS();

        }

        [StopWatch]
        /*" R1300-90-LER-V1RELATORIOS */
        private void R1300_90_LER_V1RELATORIOS(bool isPerform = false)
        {
            /*" -1134- PERFORM R3000-00-MONTA-COSCED-CHEQUE. */

            R3000_00_MONTA_COSCED_CHEQUE_SECTION();

            /*" -1136- PERFORM R1200-00-DELETE-V0RELATORIOS. */

            R1200_00_DELETE_V0RELATORIOS_SECTION();

            /*" -1136- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1140- PERFORM R0200-00-DECLARE-V1RELATORIOS. */

            R0200_00_DECLARE_V1RELATORIOS_SECTION();

            /*" -1140- PERFORM R0250-00-FETCH-V1RELATORIOS. */

            R0250_00_FETCH_V1RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-V0COSCED-CHQ-SECTION */
        private void R1400_00_SELECT_V0COSCED_CHQ_SECTION()
        {
            /*" -1153- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", WABEND.WNR_EXEC_SQL);

            /*" -1161- PERFORM R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1 */

            R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1();

            /*" -1164- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1165- DISPLAY 'R1400 - ERRO DE SELECT NA V0COSCED_CHEQUE' */
                _.Display($"R1400 - ERRO DE SELECT NA V0COSCED_CHEQUE");

                /*" -1166- DISPLAY 'EMPRESA  - ' V1RELA-COD-EMPR */
                _.Display($"EMPRESA  - {V1RELA_COD_EMPR}");

                /*" -1167- DISPLAY 'COD CONG - ' V1RELA-CONGENER */
                _.Display($"COD CONG - {V1RELA_CONGENER}");

                /*" -1168- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1169- ELSE */
            }
            else
            {


                /*" -1170- IF VIND-DTLIBERA < ZEROS */

                if (VIND_DTLIBERA < 00)
                {

                    /*" -1171- MOVE '1990-01-01' TO WHOST-DTMOVTO */
                    _.Move("1990-01-01", WHOST_DTMOVTO);

                    /*" -1172- ELSE */
                }
                else
                {


                    /*" -1173- MOVE V1CCHQ-DTLIBERA TO WHOST-DTMOVTO */
                    _.Move(V1CCHQ_DTLIBERA, WHOST_DTMOVTO);

                    /*" -1174- END-IF */
                }


                /*" -1174- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-V0COSCED-CHQ-DB-SELECT-1 */
        public void R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1()
        {
            /*" -1161- EXEC SQL SELECT MAX(DTLIBERA) INTO :V1CCHQ-DTLIBERA:VIND-DTLIBERA FROM SEGUROS.V0COSCED_CHEQUE WHERE COD_EMPRESA = :V1RELA-COD-EMPR AND CONGENER = :V1RELA-CONGENER AND DTMOVTO_AC < :V1SIST-DTMOVABE AND SITUACAO <> '2' END-EXEC. */

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
            /*" -1187- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WABEND.WNR_EXEC_SQL);

            /*" -1224- PERFORM R1500_00_DECLARE_V1COSSEGHIS_DB_DECLARE_1 */

            R1500_00_DECLARE_V1COSSEGHIS_DB_DECLARE_1();

            /*" -1226- PERFORM R1500_00_DECLARE_V1COSSEGHIS_DB_OPEN_1 */

            R1500_00_DECLARE_V1COSSEGHIS_DB_OPEN_1();

            /*" -1229- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1230- DISPLAY 'R1500 - ERRO NO DECLARE DA V1COSSEG_HISTPRE' */
                _.Display($"R1500 - ERRO NO DECLARE DA V1COSSEG_HISTPRE");

                /*" -1231- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1232- ELSE */
            }
            else
            {


                /*" -1233- MOVE SPACES TO WFIM-V1COSSEGHIS */
                _.Move("", AREA_DE_WORK.WFIM_V1COSSEGHIS);

                /*" -1233- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-00-DECLARE-V1COSSEGHIS-DB-OPEN-1 */
        public void R1500_00_DECLARE_V1COSSEGHIS_DB_OPEN_1()
        {
            /*" -1226- EXEC SQL OPEN V1COSSEGHIS END-EXEC. */

            V1COSSEGHIS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1550-00-FETCH-V1COSSEGHIS-SECTION */
        private void R1550_00_FETCH_V1COSSEGHIS_SECTION()
        {
            /*" -1246- MOVE '155' TO WNR-EXEC-SQL. */
            _.Move("155", WABEND.WNR_EXEC_SQL);

            /*" -1264- PERFORM R1550_00_FETCH_V1COSSEGHIS_DB_FETCH_1 */

            R1550_00_FETCH_V1COSSEGHIS_DB_FETCH_1();

            /*" -1267- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1268- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1269- MOVE 'S' TO WFIM-V1COSSEGHIS */
                    _.Move("S", AREA_DE_WORK.WFIM_V1COSSEGHIS);

                    /*" -1269- PERFORM R1550_00_FETCH_V1COSSEGHIS_DB_CLOSE_1 */

                    R1550_00_FETCH_V1COSSEGHIS_DB_CLOSE_1();

                    /*" -1271- ELSE */
                }
                else
                {


                    /*" -1272- DISPLAY 'R1550 - ERRO NO FETCH DA V1COSSEG_HISTPRE' */
                    _.Display($"R1550 - ERRO NO FETCH DA V1COSSEG_HISTPRE");

                    /*" -1273- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1274- END-IF */
                }


                /*" -1275- ELSE */
            }
            else
            {


                /*" -1276- IF VIND-DAT-QTBC < ZEROS */

                if (VIND_DAT_QTBC < 00)
                {

                    /*" -1277- MOVE SPACES TO V1CHIS-DTQITBCO */
                    _.Move("", V1CHIS_DTQITBCO);

                    /*" -1278- END-IF */
                }


                /*" -1279- ADD 1 TO AC-L-COSSEGHIS */
                AREA_DE_WORK.AC_L_COSSEGHIS.Value = AREA_DE_WORK.AC_L_COSSEGHIS + 1;

                /*" -1279- END-IF. */
            }


        }

        [StopWatch]
        /*" R1550-00-FETCH-V1COSSEGHIS-DB-FETCH-1 */
        public void R1550_00_FETCH_V1COSSEGHIS_DB_FETCH_1()
        {
            /*" -1264- EXEC SQL FETCH V1COSSEGHIS INTO :V1CHIS-COD-EMPR , :V1CHIS-CONGENER , :V1CHIS-NUM-APOL , :V1CHIS-NUM-ENDS , :V1CHIS-NRPARCEL , :V1CHIS-OCORHIST , :V1CHIS-OPERACAO , :V1CHIS-TIP-SEGU , :V1CHIS-PRM-TARF , :V1CHIS-VAL-DESC , :V1CHIS-VLPRMLIQ , :V1CHIS-VLADIFRA , :V1CHIS-VLCOMISS , :V1CHIS-VLPRMTOT , :V1CHIS-DAT-MOVT , :V1CHIS-DTQITBCO:VIND-DAT-QTBC, :V1CHIS-NUM-OCOR:VIND-NUM-OCOR END-EXEC. */

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
        /*" R1550-00-FETCH-V1COSSEGHIS-DB-CLOSE-1 */
        public void R1550_00_FETCH_V1COSSEGHIS_DB_CLOSE_1()
        {
            /*" -1269- EXEC SQL CLOSE V1COSSEGHIS END-EXEC */

            V1COSSEGHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1550_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-PROCESSA-DOCUMENTO-SECTION */
        private void R1600_00_PROCESSA_DOCUMENTO_SECTION()
        {
            /*" -1292- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", WABEND.WNR_EXEC_SQL);

            /*" -1299- MOVE ZEROS TO WVLR-PRMTAR-CM WVLR-DESCTO-CM WVLR-PRMLIQ-CM WVLR-ADIFRA-CM WVLR-COMISS-CM WVLR-PRMTOT-CM. */
            _.Move(0, AREA_DE_WORK.WVLR_PRMTAR_CM, AREA_DE_WORK.WVLR_DESCTO_CM, AREA_DE_WORK.WVLR_PRMLIQ_CM, AREA_DE_WORK.WVLR_ADIFRA_CM, AREA_DE_WORK.WVLR_COMISS_CM, AREA_DE_WORK.WVLR_PRMTOT_CM);

            /*" -1303- PERFORM R1700-00-SELECT-V0ENDOSSO. */

            R1700_00_SELECT_V0ENDOSSO_SECTION();

            /*" -1305- MOVE ZEROS TO WHOST-VLCRUZAD2. */
            _.Move(0, WHOST_VLCRUZAD2);

            /*" -1306- IF V1RELA-PERI-INI NOT EQUAL '0001-01-01' */

            if (V1RELA_PERI_INI != "0001-01-01")
            {

                /*" -1307- IF V0ENDO-CORRECAO EQUAL '2' OR '4' */

                if (V0ENDO_CORRECAO.In("2", "4"))
                {

                    /*" -1308- MOVE V0ENDO-MOEDA-PRM TO V1MOED-CODUNIMO */
                    _.Move(V0ENDO_MOEDA_PRM, V1MOED_CODUNIMO);

                    /*" -1309- MOVE V1RELA-PERI-INI TO V1MOED-DTINIVIG */
                    _.Move(V1RELA_PERI_INI, V1MOED_DTINIVIG);

                    /*" -1310- PERFORM R1000-00-SELECT-V1MOEDA */

                    R1000_00_SELECT_V1MOEDA_SECTION();

                    /*" -1311- MOVE V1MOED-VLCRUZAD TO WHOST-VLCRUZAD2 */
                    _.Move(V1MOED_VLCRUZAD, WHOST_VLCRUZAD2);

                    /*" -1312- END-IF */
                }


                /*" -1316- END-IF. */
            }


            /*" -1317- MOVE V1CHIS-COD-EMPR TO V0CHIS-COD-EMPR. */
            _.Move(V1CHIS_COD_EMPR, V0CHIS_COD_EMPR);

            /*" -1318- MOVE V1CHIS-CONGENER TO V0CHIS-CONGENER. */
            _.Move(V1CHIS_CONGENER, V0CHIS_CONGENER);

            /*" -1319- MOVE V1CHIS-NUM-APOL TO V0CHIS-NUM-APOL. */
            _.Move(V1CHIS_NUM_APOL, V0CHIS_NUM_APOL);

            /*" -1320- MOVE V1CHIS-NUM-ENDS TO V0CHIS-NUM-ENDS. */
            _.Move(V1CHIS_NUM_ENDS, V0CHIS_NUM_ENDS);

            /*" -1321- MOVE V1CHIS-NRPARCEL TO V0CHIS-NRPARCEL. */
            _.Move(V1CHIS_NRPARCEL, V0CHIS_NRPARCEL);

            /*" -1322- MOVE V1SIST-DTMOVABE TO V0CHIS-DAT-MOVT. */
            _.Move(V1SIST_DTMOVABE, V0CHIS_DAT_MOVT);

            /*" -1324- MOVE '1' TO V0CHIS-TIP-SEGU. */
            _.Move("1", V0CHIS_TIP_SEGU);

            /*" -1325- MOVE SPACES TO V0CHIS-DTQITBCO. */
            _.Move("", V0CHIS_DTQITBCO);

            /*" -1327- MOVE -1 TO VIND-DTQITBCO. */
            _.Move(-1, VIND_DTQITBCO);

            /*" -1328- MOVE '0' TO V0CHIS-SIT-LIBR. */
            _.Move("0", V0CHIS_SIT_LIBR);

            /*" -1330- MOVE +1 TO VIND-SIT-LIBR. */
            _.Move(+1, VIND_SIT_LIBR);

            /*" -1331- MOVE V1CHIS-NUM-OCOR TO V0CHIS-NUM-OCOR. */
            _.Move(V1CHIS_NUM_OCOR, V0CHIS_NUM_OCOR);

            /*" -1335- MOVE +1 TO VIND-NUM-OCOR. */
            _.Move(+1, VIND_NUM_OCOR);

            /*" -1339- PERFORM R1800-00-SELECT-V1COSSEG-PREM. */

            R1800_00_SELECT_V1COSSEG_PREM_SECTION();

            /*" -1340- IF V1CHIS-OPERACAO GREATER 300 */

            if (V1CHIS_OPERACAO > 300)
            {

                /*" -1341- PERFORM R1900-00-OPERACAO-ORIGINAL */

                R1900_00_OPERACAO_ORIGINAL_SECTION();

                /*" -1345- END-IF. */
            }


            /*" -1346- IF V1CHIS-OPERACAO GREATER 300 */

            if (V1CHIS_OPERACAO > 300)
            {

                /*" -1348- COMPUTE V2CHIS-OPERACAO = V1CHIS-OPERACAO - 110 */
                V2CHIS_OPERACAO.Value = V1CHIS_OPERACAO - 110;

                /*" -1349- ELSE */
            }
            else
            {


                /*" -1350- IF V0ENDO-TIPO-ENDO EQUAL '3' OR '5' */

                if (V0ENDO_TIPO_ENDO.In("3", "5"))
                {

                    /*" -1351- IF V1CHIS-OPERACAO EQUAL 300 */

                    if (V1CHIS_OPERACAO == 300)
                    {

                        /*" -1352- MOVE 851 TO V2CHIS-OPERACAO */
                        _.Move(851, V2CHIS_OPERACAO);

                        /*" -1353- ELSE */
                    }
                    else
                    {


                        /*" -1354- MOVE 811 TO V2CHIS-OPERACAO */
                        _.Move(811, V2CHIS_OPERACAO);

                        /*" -1355- ELSE */
                    }

                }
                else
                {


                    /*" -1356- IF V1CHIS-OPERACAO EQUAL 300 */

                    if (V1CHIS_OPERACAO == 300)
                    {

                        /*" -1357- MOVE 850 TO V2CHIS-OPERACAO */
                        _.Move(850, V2CHIS_OPERACAO);

                        /*" -1358- ELSE */
                    }
                    else
                    {


                        /*" -1360- MOVE 810 TO V2CHIS-OPERACAO. */
                        _.Move(810, V2CHIS_OPERACAO);
                    }

                }

            }


            /*" -1361- IF V2CHIS-OPERACAO EQUAL 810 */

            if (V2CHIS_OPERACAO == 810)
            {

                /*" -1362- MOVE 832 TO WHOST-OPERACAO */
                _.Move(832, WHOST_OPERACAO);

                /*" -1363- ELSE */
            }
            else
            {


                /*" -1364- IF V2CHIS-OPERACAO EQUAL 811 */

                if (V2CHIS_OPERACAO == 811)
                {

                    /*" -1365- MOVE 834 TO WHOST-OPERACAO */
                    _.Move(834, WHOST_OPERACAO);

                    /*" -1366- ELSE */
                }
                else
                {


                    /*" -1367- IF V2CHIS-OPERACAO EQUAL 850 */

                    if (V2CHIS_OPERACAO == 850)
                    {

                        /*" -1368- MOVE 833 TO WHOST-OPERACAO */
                        _.Move(833, WHOST_OPERACAO);

                        /*" -1369- ELSE */
                    }
                    else
                    {


                        /*" -1373- MOVE 835 TO WHOST-OPERACAO. */
                        _.Move(835, WHOST_OPERACAO);
                    }

                }

            }


            /*" -1377- PERFORM R2000-00-SOMA-CORRECAO. */

            R2000_00_SOMA_CORRECAO_SECTION();

            /*" -1378- IF V1RELA-PERI-INI NOT EQUAL '0001-01-01' */

            if (V1RELA_PERI_INI != "0001-01-01")
            {

                /*" -1379- IF V0ENDO-CORRECAO EQUAL '2' OR '4' */

                if (V0ENDO_CORRECAO.In("2", "4"))
                {

                    /*" -1380- PERFORM R2100-00-CALC-CORR-INDEX */

                    R2100_00_CALC_CORR_INDEX_SECTION();

                    /*" -1381- PERFORM R2200-00-MONTA-CORRECAO */

                    R2200_00_MONTA_CORRECAO_SECTION();

                    /*" -1382- ELSE */
                }
                else
                {


                    /*" -1383- IF V1RELA-CODUNIMO NOT EQUAL ZEROS */

                    if (V1RELA_CODUNIMO != 00)
                    {

                        /*" -1384- PERFORM R2300-00-CALC-CORR-NINDEX */

                        R2300_00_CALC_CORR_NINDEX_SECTION();

                        /*" -1385- PERFORM R2200-00-MONTA-CORRECAO */

                        R2200_00_MONTA_CORRECAO_SECTION();

                        /*" -1386- END-IF */
                    }


                    /*" -1387- END-IF */
                }


                /*" -1391- END-IF. */
            }


            /*" -1393- MOVE V2CHIS-OPERACAO TO V0CHIS-OPERACAO. */
            _.Move(V2CHIS_OPERACAO, V0CHIS_OPERACAO);

            /*" -1396- COMPUTE V0CHIS-PRM-TARF = WVLR-PRMTAR-CM - V2CHIS-PRM-TARF. */
            V0CHIS_PRM_TARF.Value = AREA_DE_WORK.WVLR_PRMTAR_CM - V2CHIS_PRM_TARF;

            /*" -1399- COMPUTE V0CHIS-VAL-DESC = WVLR-DESCTO-CM - V2CHIS-VAL-DESC. */
            V0CHIS_VAL_DESC.Value = AREA_DE_WORK.WVLR_DESCTO_CM - V2CHIS_VAL_DESC;

            /*" -1402- COMPUTE V0CHIS-VLPRMLIQ = V0CHIS-PRM-TARF - V0CHIS-VAL-DESC. */
            V0CHIS_VLPRMLIQ.Value = V0CHIS_PRM_TARF - V0CHIS_VAL_DESC;

            /*" -1405- COMPUTE V0CHIS-VLADIFRA = WVLR-ADIFRA-CM - V2CHIS-VLADIFRA. */
            V0CHIS_VLADIFRA.Value = AREA_DE_WORK.WVLR_ADIFRA_CM - V2CHIS_VLADIFRA;

            /*" -1408- COMPUTE V0CHIS-VLCOMISS = WVLR-COMISS-CM - V2CHIS-VLCOMISS. */
            V0CHIS_VLCOMISS.Value = AREA_DE_WORK.WVLR_COMISS_CM - V2CHIS_VLCOMISS;

            /*" -1412- COMPUTE V0CHIS-VLPRMTOT = V0CHIS-VLPRMLIQ + V0CHIS-VLADIFRA - V0CHIS-VLCOMISS. */
            V0CHIS_VLPRMTOT.Value = V0CHIS_VLPRMLIQ + V0CHIS_VLADIFRA - V0CHIS_VLCOMISS;

            /*" -1413- IF V0CHIS-VLPRMTOT NOT EQUAL ZEROS */

            if (V0CHIS_VLPRMTOT != 00)
            {

                /*" -1414- ADD +1 TO V1CPRE-OCORHIST */
                V1CPRE_OCORHIST.Value = V1CPRE_OCORHIST + +1;

                /*" -1416- MOVE V1CPRE-OCORHIST TO V0CHIS-OCORHIST */
                _.Move(V1CPRE_OCORHIST, V0CHIS_OCORHIST);

                /*" -1417- MOVE '0' TO V0CHIS-SIT-FINC */
                _.Move("0", V0CHIS_SIT_FINC);

                /*" -1419- MOVE +1 TO VIND-SIT-FINC */
                _.Move(+1, VIND_SIT_FINC);

                /*" -1420- PERFORM R2500-00-INSERT-COSSEGHIS */

                R2500_00_INSERT_COSSEGHIS_SECTION();

                /*" -1424- END-IF. */
            }


            /*" -1425- ADD +1 TO V1CPRE-OCORHIST. */
            V1CPRE_OCORHIST.Value = V1CPRE_OCORHIST + +1;

            /*" -1427- MOVE V1CPRE-OCORHIST TO V0CHIS-OCORHIST. */
            _.Move(V1CPRE_OCORHIST, V0CHIS_OCORHIST);

            /*" -1430- COMPUTE V0CHIS-OPERACAO = V2CHIS-OPERACAO + 100. */
            V0CHIS_OPERACAO.Value = V2CHIS_OPERACAO + 100;

            /*" -1431- MOVE V1CHIS-PRM-TARF TO V0CHIS-PRM-TARF. */
            _.Move(V1CHIS_PRM_TARF, V0CHIS_PRM_TARF);

            /*" -1432- MOVE V1CHIS-VAL-DESC TO V0CHIS-VAL-DESC. */
            _.Move(V1CHIS_VAL_DESC, V0CHIS_VAL_DESC);

            /*" -1433- MOVE V1CHIS-VLPRMLIQ TO V0CHIS-VLPRMLIQ. */
            _.Move(V1CHIS_VLPRMLIQ, V0CHIS_VLPRMLIQ);

            /*" -1434- MOVE V1CHIS-VLADIFRA TO V0CHIS-VLADIFRA. */
            _.Move(V1CHIS_VLADIFRA, V0CHIS_VLADIFRA);

            /*" -1435- MOVE V1CHIS-VLCOMISS TO V0CHIS-VLCOMISS. */
            _.Move(V1CHIS_VLCOMISS, V0CHIS_VLCOMISS);

            /*" -1437- MOVE V1CHIS-VLPRMTOT TO V0CHIS-VLPRMTOT. */
            _.Move(V1CHIS_VLPRMTOT, V0CHIS_VLPRMTOT);

            /*" -1439- MOVE V1CHIS-DTQITBCO TO V0CHIS-DTQITBCO. */
            _.Move(V1CHIS_DTQITBCO, V0CHIS_DTQITBCO);

            /*" -1440- IF V1CHIS-DTQITBCO EQUAL SPACES */

            if (V1CHIS_DTQITBCO.IsEmpty())
            {

                /*" -1441- MOVE -1 TO VIND-DTQITBCO */
                _.Move(-1, VIND_DTQITBCO);

                /*" -1442- ELSE */
            }
            else
            {


                /*" -1443- MOVE +1 TO VIND-DTQITBCO */
                _.Move(+1, VIND_DTQITBCO);

                /*" -1445- END-IF. */
            }


            /*" -1446- IF V0CHIS-OPERACAO EQUAL 910 OR 951 */

            if (V0CHIS_OPERACAO.In("910", "951"))
            {

                /*" -1448- COMPUTE AC-PRM-TARF = AC-PRM-TARF + V0CHIS-PRM-TARF */
                AREA_DE_WORK.AC_PRM_TARF.Value = AREA_DE_WORK.AC_PRM_TARF + V0CHIS_PRM_TARF;

                /*" -1450- COMPUTE AC-DESCONTO = AC-DESCONTO + V0CHIS-VAL-DESC */
                AREA_DE_WORK.AC_DESCONTO.Value = AREA_DE_WORK.AC_DESCONTO + V0CHIS_VAL_DESC;

                /*" -1452- COMPUTE AC-VLADIFRA = AC-VLADIFRA + V0CHIS-VLADIFRA */
                AREA_DE_WORK.AC_VLADIFRA.Value = AREA_DE_WORK.AC_VLADIFRA + V0CHIS_VLADIFRA;

                /*" -1454- COMPUTE AC-COMISSAO = AC-COMISSAO + V0CHIS-VLCOMISS */
                AREA_DE_WORK.AC_COMISSAO.Value = AREA_DE_WORK.AC_COMISSAO + V0CHIS_VLCOMISS;

                /*" -1455- ELSE */
            }
            else
            {


                /*" -1457- COMPUTE AC-PRM-TARF = AC-PRM-TARF - V0CHIS-PRM-TARF */
                AREA_DE_WORK.AC_PRM_TARF.Value = AREA_DE_WORK.AC_PRM_TARF - V0CHIS_PRM_TARF;

                /*" -1459- COMPUTE AC-DESCONTO = AC-DESCONTO - V0CHIS-VAL-DESC */
                AREA_DE_WORK.AC_DESCONTO.Value = AREA_DE_WORK.AC_DESCONTO - V0CHIS_VAL_DESC;

                /*" -1461- COMPUTE AC-VLADIFRA = AC-VLADIFRA - V0CHIS-VLADIFRA */
                AREA_DE_WORK.AC_VLADIFRA.Value = AREA_DE_WORK.AC_VLADIFRA - V0CHIS_VLADIFRA;

                /*" -1463- COMPUTE AC-COMISSAO = AC-COMISSAO - V0CHIS-VLCOMISS */
                AREA_DE_WORK.AC_COMISSAO.Value = AREA_DE_WORK.AC_COMISSAO - V0CHIS_VLCOMISS;

                /*" -1465- END-IF. */
            }


            /*" -1467- IF V0CHIS-NUM-APOL EQUAL 66001000001 OR 106600000001 */

            if (V0CHIS_NUM_APOL.In("66001000001", "106600000001"))
            {

                /*" -1468- IF V0CHIS-OPERACAO EQUAL 910 OR 951 */

                if (V0CHIS_OPERACAO.In("910", "951"))
                {

                    /*" -1473- COMPUTE AC-PRMLIQ-6668 = AC-PRMLIQ-6668 + (V0CHIS-PRM-TARF - V0CHIS-VAL-DESC + V0CHIS-VLADIFRA - V0CHIS-VLCOMISS) */
                    AREA_DE_WORK.AC_PRMLIQ_6668.Value = AREA_DE_WORK.AC_PRMLIQ_6668 + (V0CHIS_PRM_TARF - V0CHIS_VAL_DESC + V0CHIS_VLADIFRA - V0CHIS_VLCOMISS);

                    /*" -1474- ELSE */
                }
                else
                {


                    /*" -1479- COMPUTE AC-PRMLIQ-6668 = AC-PRMLIQ-6668 - (V0CHIS-PRM-TARF - V0CHIS-VAL-DESC + V0CHIS-VLADIFRA - V0CHIS-VLCOMISS) */
                    AREA_DE_WORK.AC_PRMLIQ_6668.Value = AREA_DE_WORK.AC_PRMLIQ_6668 - (V0CHIS_PRM_TARF - V0CHIS_VAL_DESC + V0CHIS_VLADIFRA - V0CHIS_VLCOMISS);

                    /*" -1480- END-IF */
                }


                /*" -1482- END-IF. */
            }


            /*" -1483- MOVE '1' TO V0CHIS-SIT-FINC. */
            _.Move("1", V0CHIS_SIT_FINC);

            /*" -1485- MOVE +1 TO VIND-SIT-FINC. */
            _.Move(+1, VIND_SIT_FINC);

            /*" -1487- PERFORM R2500-00-INSERT-COSSEGHIS. */

            R2500_00_INSERT_COSSEGHIS_SECTION();

            /*" -1489- PERFORM R2600-00-UPDATE-COSSEGPRE. */

            R2600_00_UPDATE_COSSEGPRE_SECTION();

            /*" -1493- PERFORM R2700-00-UPDATE-COSSEGHIS. */

            R2700_00_UPDATE_COSSEGHIS_SECTION();

            /*" -1495- ADD 1 TO AC-L-COSSEGHIS. */
            AREA_DE_WORK.AC_L_COSSEGHIS.Value = AREA_DE_WORK.AC_L_COSSEGHIS + 1;

            /*" -1496- IF WTIP-SOLICIT = 0 */

            if (AREA_DE_WORK.WTIP_SOLICIT == 0)
            {

                /*" -1497- PERFORM R0850-00-FETCH-V1COSGHISTP */

                R0850_00_FETCH_V1COSGHISTP_SECTION();

                /*" -1498- ELSE */
            }
            else
            {


                /*" -1499- PERFORM R1550-00-FETCH-V1COSSEGHIS */

                R1550_00_FETCH_V1COSSEGHIS_SECTION();

                /*" -1499- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-SELECT-V0ENDOSSO-SECTION */
        private void R1700_00_SELECT_V0ENDOSSO_SECTION()
        {
            /*" -1512- MOVE '170' TO WNR-EXEC-SQL. */
            _.Move("170", WABEND.WNR_EXEC_SQL);

            /*" -1524- PERFORM R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1 */

            R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1();

            /*" -1527- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1528- DISPLAY 'R1700 - ERRO NO SELECT DA V0ENDOSSO ' */
                _.Display($"R1700 - ERRO NO SELECT DA V0ENDOSSO ");

                /*" -1529- DISPLAY 'EMPRESA  - ' V1CHIS-COD-EMPR */
                _.Display($"EMPRESA  - {V1CHIS_COD_EMPR}");

                /*" -1530- DISPLAY 'COD CONG - ' V1CHIS-CONGENER */
                _.Display($"COD CONG - {V1CHIS_CONGENER}");

                /*" -1531- DISPLAY 'APOLICE - ' V1CHIS-NUM-APOL */
                _.Display($"APOLICE - {V1CHIS_NUM_APOL}");

                /*" -1532- DISPLAY 'ENDOSSO - ' V1CHIS-NUM-ENDS */
                _.Display($"ENDOSSO - {V1CHIS_NUM_ENDS}");

                /*" -1533- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1533- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-00-SELECT-V0ENDOSSO-DB-SELECT-1 */
        public void R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1()
        {
            /*" -1524- EXEC SQL SELECT COD_MOEDA_PRM , TIPO_ENDOSSO , CORRECAO , DTINIVIG INTO :V0ENDO-MOEDA-PRM , :V0ENDO-TIPO-ENDO , :V0ENDO-CORRECAO , :V0ENDO-DTINIVIG FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V1CHIS-NUM-APOL AND NRENDOS = :V1CHIS-NUM-ENDS END-EXEC. */

            var r1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 = new R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1()
            {
                V1CHIS_NUM_APOL = V1CHIS_NUM_APOL.ToString(),
                V1CHIS_NUM_ENDS = V1CHIS_NUM_ENDS.ToString(),
            };

            var executed_1 = R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1.Execute(r1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_MOEDA_PRM, V0ENDO_MOEDA_PRM);
                _.Move(executed_1.V0ENDO_TIPO_ENDO, V0ENDO_TIPO_ENDO);
                _.Move(executed_1.V0ENDO_CORRECAO, V0ENDO_CORRECAO);
                _.Move(executed_1.V0ENDO_DTINIVIG, V0ENDO_DTINIVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-SELECT-V1COSSEG-PREM-SECTION */
        private void R1800_00_SELECT_V1COSSEG_PREM_SECTION()
        {
            /*" -1546- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", WABEND.WNR_EXEC_SQL);

            /*" -1570- PERFORM R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1 */

            R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1();

            /*" -1573- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1574- DISPLAY 'R1800 - ERRO NO SELECT DA V1COSSEG-PREM' */
                _.Display($"R1800 - ERRO NO SELECT DA V1COSSEG-PREM");

                /*" -1575- DISPLAY 'EMPRESA  - ' V1CHIS-COD-EMPR */
                _.Display($"EMPRESA  - {V1CHIS_COD_EMPR}");

                /*" -1576- DISPLAY 'COD CONG - ' V1CHIS-CONGENER */
                _.Display($"COD CONG - {V1CHIS_CONGENER}");

                /*" -1577- DISPLAY 'APOLICE  - ' V1CHIS-NUM-APOL */
                _.Display($"APOLICE  - {V1CHIS_NUM_APOL}");

                /*" -1578- DISPLAY 'ENDOSSO  - ' V1CHIS-NUM-ENDS */
                _.Display($"ENDOSSO  - {V1CHIS_NUM_ENDS}");

                /*" -1579- DISPLAY 'PARCELA  - ' V1CHIS-NRPARCEL */
                _.Display($"PARCELA  - {V1CHIS_NRPARCEL}");

                /*" -1580- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1580- END-IF. */
            }


        }

        [StopWatch]
        /*" R1800-00-SELECT-V1COSSEG-PREM-DB-SELECT-1 */
        public void R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1()
        {
            /*" -1570- EXEC SQL SELECT OCORHIST , PRM_TARIFARIO_IX , VAL_DESCONTO_IX , OTNPRLIQ , OTNADFRA , VLCOMISIX , OTNTOTAL INTO :V1CPRE-OCORHIST , :V1CPRE-PRMTAR-IX , :V1CPRE-VLDESC-IX , :V1CPRE-OTNPRLIQ , :V1CPRE-OTNADFRA , :V1CPRE-VLCOMS-IX , :V1CPRE-OTNTOTAL FROM SEGUROS.V1COSSEG_PREM WHERE CONGENER = :V1CHIS-CONGENER AND NUM_APOLICE = :V1CHIS-NUM-APOL AND NRENDOS = :V1CHIS-NUM-ENDS AND NRPARCEL = :V1CHIS-NRPARCEL AND TIPSGU = '1' END-EXEC. */

            var r1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1 = new R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1()
            {
                V1CHIS_CONGENER = V1CHIS_CONGENER.ToString(),
                V1CHIS_NUM_APOL = V1CHIS_NUM_APOL.ToString(),
                V1CHIS_NUM_ENDS = V1CHIS_NUM_ENDS.ToString(),
                V1CHIS_NRPARCEL = V1CHIS_NRPARCEL.ToString(),
            };

            var executed_1 = R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1.Execute(r1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-OPERACAO-ORIGINAL-SECTION */
        private void R1900_00_OPERACAO_ORIGINAL_SECTION()
        {
            /*" -1593- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", WABEND.WNR_EXEC_SQL);

            /*" -1619- PERFORM R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1 */

            R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1();

            /*" -1622- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1623- DISPLAY 'R1900 - ERRO NO SELECT DA V0COSSEG_HISTPRE' */
                _.Display($"R1900 - ERRO NO SELECT DA V0COSSEG_HISTPRE");

                /*" -1624- DISPLAY 'EMPRESA  - ' V1CHIS-COD-EMPR */
                _.Display($"EMPRESA  - {V1CHIS_COD_EMPR}");

                /*" -1625- DISPLAY 'COD CONG - ' V1CHIS-CONGENER */
                _.Display($"COD CONG - {V1CHIS_CONGENER}");

                /*" -1626- DISPLAY 'APOLICE  - ' V1CHIS-NUM-APOL */
                _.Display($"APOLICE  - {V1CHIS_NUM_APOL}");

                /*" -1627- DISPLAY 'ENDOSSO  - ' V1CHIS-NUM-ENDS */
                _.Display($"ENDOSSO  - {V1CHIS_NUM_ENDS}");

                /*" -1628- DISPLAY 'PARCELA  - ' V1CHIS-NRPARCEL */
                _.Display($"PARCELA  - {V1CHIS_NRPARCEL}");

                /*" -1629- DISPLAY 'NUM OCOR - ' V1CHIS-NUM-OCOR */
                _.Display($"NUM OCOR - {V1CHIS_NUM_OCOR}");

                /*" -1630- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1631- ELSE */
            }
            else
            {


                /*" -1632- IF VIND-DAT-QTBC < ZEROS */

                if (VIND_DAT_QTBC < 00)
                {

                    /*" -1633- MOVE SPACES TO V1CHIS-DTQITBCO */
                    _.Move("", V1CHIS_DTQITBCO);

                    /*" -1634- END-IF */
                }


                /*" -1634- END-IF. */
            }


        }

        [StopWatch]
        /*" R1900-00-OPERACAO-ORIGINAL-DB-SELECT-1 */
        public void R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1()
        {
            /*" -1619- EXEC SQL SELECT PRM_TARIFARIO , VAL_DESCONTO , VLPRMLIQ , VLADIFRA , VLCOMIS , VLPRMTOT , DTQITBCO INTO :V1CHIS-PRM-TARF , :V1CHIS-VAL-DESC , :V1CHIS-VLPRMLIQ , :V1CHIS-VLADIFRA , :V1CHIS-VLCOMISS , :V1CHIS-VLPRMTOT , :V1CHIS-DTQITBCO:VIND-DAT-QTBC FROM SEGUROS.V0COSSEG_HISTPRE WHERE CONGENER = :V1CHIS-CONGENER AND NUM_APOLICE = :V1CHIS-NUM-APOL AND NRENDOS = :V1CHIS-NUM-ENDS AND NRPARCEL = :V1CHIS-NRPARCEL AND OCORHIST = :V1CHIS-NUM-OCOR AND OPERACAO BETWEEN 0200 AND 0300 AND TIPSGU = '1' END-EXEC. */

            var r1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1 = new R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1()
            {
                V1CHIS_CONGENER = V1CHIS_CONGENER.ToString(),
                V1CHIS_NUM_APOL = V1CHIS_NUM_APOL.ToString(),
                V1CHIS_NUM_ENDS = V1CHIS_NUM_ENDS.ToString(),
                V1CHIS_NRPARCEL = V1CHIS_NRPARCEL.ToString(),
                V1CHIS_NUM_OCOR = V1CHIS_NUM_OCOR.ToString(),
            };

            var executed_1 = R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1.Execute(r1900_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-SOMA-CORRECAO-SECTION */
        private void R2000_00_SOMA_CORRECAO_SECTION()
        {
            /*" -1647- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WABEND.WNR_EXEC_SQL);

            /*" -1672- PERFORM R2000_00_SOMA_CORRECAO_DB_SELECT_1 */

            R2000_00_SOMA_CORRECAO_DB_SELECT_1();

            /*" -1675- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1676- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1677- MOVE ZEROS TO V2CHIS-PRM-TARF */
                    _.Move(0, V2CHIS_PRM_TARF);

                    /*" -1678- MOVE ZEROS TO V2CHIS-VAL-DESC */
                    _.Move(0, V2CHIS_VAL_DESC);

                    /*" -1679- MOVE ZEROS TO V2CHIS-VLPRMLIQ */
                    _.Move(0, V2CHIS_VLPRMLIQ);

                    /*" -1680- MOVE ZEROS TO V2CHIS-VLADIFRA */
                    _.Move(0, V2CHIS_VLADIFRA);

                    /*" -1681- MOVE ZEROS TO V2CHIS-VLCOMISS */
                    _.Move(0, V2CHIS_VLCOMISS);

                    /*" -1682- MOVE ZEROS TO V2CHIS-VLPRMTOT */
                    _.Move(0, V2CHIS_VLPRMTOT);

                    /*" -1683- ELSE */
                }
                else
                {


                    /*" -1684- DISPLAY 'R2000 - ERRO NO SELECT DA V0COSSEG_HISTPRE' */
                    _.Display($"R2000 - ERRO NO SELECT DA V0COSSEG_HISTPRE");

                    /*" -1685- DISPLAY 'EMPRESA  - ' V1CHIS-COD-EMPR */
                    _.Display($"EMPRESA  - {V1CHIS_COD_EMPR}");

                    /*" -1686- DISPLAY 'COD CONG - ' V1CHIS-CONGENER */
                    _.Display($"COD CONG - {V1CHIS_CONGENER}");

                    /*" -1687- DISPLAY 'APOLICE  - ' V1CHIS-NUM-APOL */
                    _.Display($"APOLICE  - {V1CHIS_NUM_APOL}");

                    /*" -1688- DISPLAY 'ENDOSSO  - ' V1CHIS-NUM-ENDS */
                    _.Display($"ENDOSSO  - {V1CHIS_NUM_ENDS}");

                    /*" -1689- DISPLAY 'PARCELA  - ' V1CHIS-NRPARCEL */
                    _.Display($"PARCELA  - {V1CHIS_NRPARCEL}");

                    /*" -1690- DISPLAY 'OPERACAO - ' WHOST-OPERACAO */
                    _.Display($"OPERACAO - {WHOST_OPERACAO}");

                    /*" -1691- DISPLAY 'NUM OCOR - ' V1CHIS-NUM-OCOR */
                    _.Display($"NUM OCOR - {V1CHIS_NUM_OCOR}");

                    /*" -1692- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1693- END-IF */
                }


                /*" -1693- END-IF. */
            }


        }

        [StopWatch]
        /*" R2000-00-SOMA-CORRECAO-DB-SELECT-1 */
        public void R2000_00_SOMA_CORRECAO_DB_SELECT_1()
        {
            /*" -1672- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO),+0) , VALUE(SUM(VAL_DESCONTO),+0) , VALUE(SUM(VLPRMLIQ),+0) , VALUE(SUM(VLADIFRA),+0) , VALUE(SUM(VLCOMIS),+0) , VALUE(SUM(VLPRMTOT),+0) INTO :V2CHIS-PRM-TARF , :V2CHIS-VAL-DESC , :V2CHIS-VLPRMLIQ , :V2CHIS-VLADIFRA , :V2CHIS-VLCOMISS , :V2CHIS-VLPRMTOT FROM SEGUROS.V0COSSEG_HISTPRE WHERE CONGENER = :V1CHIS-CONGENER AND NUM_APOLICE = :V1CHIS-NUM-APOL AND NRENDOS = :V1CHIS-NUM-ENDS AND NRPARCEL = :V1CHIS-NRPARCEL AND OPERACAO = :WHOST-OPERACAO AND TIPSGU = '1' AND NUMOCOR = :V1CHIS-NUM-OCOR END-EXEC. */

            var r2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1 = new R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1()
            {
                V1CHIS_CONGENER = V1CHIS_CONGENER.ToString(),
                V1CHIS_NUM_APOL = V1CHIS_NUM_APOL.ToString(),
                V1CHIS_NUM_ENDS = V1CHIS_NUM_ENDS.ToString(),
                V1CHIS_NRPARCEL = V1CHIS_NRPARCEL.ToString(),
                V1CHIS_NUM_OCOR = V1CHIS_NUM_OCOR.ToString(),
                WHOST_OPERACAO = WHOST_OPERACAO.ToString(),
            };

            var executed_1 = R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1.Execute(r2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V2CHIS_PRM_TARF, V2CHIS_PRM_TARF);
                _.Move(executed_1.V2CHIS_VAL_DESC, V2CHIS_VAL_DESC);
                _.Move(executed_1.V2CHIS_VLPRMLIQ, V2CHIS_VLPRMLIQ);
                _.Move(executed_1.V2CHIS_VLADIFRA, V2CHIS_VLADIFRA);
                _.Move(executed_1.V2CHIS_VLCOMISS, V2CHIS_VLCOMISS);
                _.Move(executed_1.V2CHIS_VLPRMTOT, V2CHIS_VLPRMTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-CALC-CORR-INDEX-SECTION */
        private void R2100_00_CALC_CORR_INDEX_SECTION()
        {
            /*" -1706- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WABEND.WNR_EXEC_SQL);

            /*" -1709- COMPUTE WHOST-PRM-TARF ROUNDED = V1CPRE-PRMTAR-IX * WHOST-VLCRUZAD2. */
            WHOST_PRM_TARF.Value = V1CPRE_PRMTAR_IX * WHOST_VLCRUZAD2;

            /*" -1712- COMPUTE WHOST-VAL-DESC ROUNDED = V1CPRE-VLDESC-IX * WHOST-VLCRUZAD2. */
            WHOST_VAL_DESC.Value = V1CPRE_VLDESC_IX * WHOST_VLCRUZAD2;

            /*" -1715- COMPUTE WHOST-VLPRMLIQ = WHOST-PRM-TARF - WHOST-VAL-DESC. */
            WHOST_VLPRMLIQ.Value = WHOST_PRM_TARF - WHOST_VAL_DESC;

            /*" -1718- COMPUTE WHOST-VLADIFRA ROUNDED = V1CPRE-OTNADFRA * WHOST-VLCRUZAD2. */
            WHOST_VLADIFRA.Value = V1CPRE_OTNADFRA * WHOST_VLCRUZAD2;

            /*" -1721- COMPUTE WHOST-VLCOMISS ROUNDED = V1CPRE-VLCOMS-IX * WHOST-VLCRUZAD2. */
            WHOST_VLCOMISS.Value = V1CPRE_VLCOMS_IX * WHOST_VLCRUZAD2;

            /*" -1723- COMPUTE WHOST-VLPRMTOT = WHOST-VLPRMLIQ + WHOST-VLADIFRA - WHOST-VLCOMISS. */
            WHOST_VLPRMTOT.Value = WHOST_VLPRMLIQ + WHOST_VLADIFRA - WHOST_VLCOMISS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-MONTA-CORRECAO-SECTION */
        private void R2200_00_MONTA_CORRECAO_SECTION()
        {
            /*" -1736- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", WABEND.WNR_EXEC_SQL);

            /*" -1739- COMPUTE WVLR-PRMTAR-CM = WHOST-PRM-TARF - V1CHIS-PRM-TARF. */
            AREA_DE_WORK.WVLR_PRMTAR_CM.Value = WHOST_PRM_TARF - V1CHIS_PRM_TARF;

            /*" -1742- COMPUTE WVLR-DESCTO-CM = WHOST-VAL-DESC - V1CHIS-VAL-DESC. */
            AREA_DE_WORK.WVLR_DESCTO_CM.Value = WHOST_VAL_DESC - V1CHIS_VAL_DESC;

            /*" -1745- COMPUTE WVLR-PRMLIQ-CM = WVLR-PRMTAR-CM - WVLR-DESCTO-CM. */
            AREA_DE_WORK.WVLR_PRMLIQ_CM.Value = AREA_DE_WORK.WVLR_PRMTAR_CM - AREA_DE_WORK.WVLR_DESCTO_CM;

            /*" -1748- COMPUTE WVLR-ADIFRA-CM = WHOST-VLADIFRA - V1CHIS-VLADIFRA. */
            AREA_DE_WORK.WVLR_ADIFRA_CM.Value = WHOST_VLADIFRA - V1CHIS_VLADIFRA;

            /*" -1751- COMPUTE WVLR-COMISS-CM = WHOST-VLCOMISS - V1CHIS-VLCOMISS. */
            AREA_DE_WORK.WVLR_COMISS_CM.Value = WHOST_VLCOMISS - V1CHIS_VLCOMISS;

            /*" -1755- COMPUTE WVLR-PRMTOT-CM = WVLR-PRMLIQ-CM + WVLR-ADIFRA-CM - WVLR-COMISS-CM. */
            AREA_DE_WORK.WVLR_PRMTOT_CM.Value = AREA_DE_WORK.WVLR_PRMLIQ_CM + AREA_DE_WORK.WVLR_ADIFRA_CM - AREA_DE_WORK.WVLR_COMISS_CM;

            /*" -1756- MOVE WHOST-PRM-TARF TO V1CHIS-PRM-TARF. */
            _.Move(WHOST_PRM_TARF, V1CHIS_PRM_TARF);

            /*" -1757- MOVE WHOST-VAL-DESC TO V1CHIS-VAL-DESC. */
            _.Move(WHOST_VAL_DESC, V1CHIS_VAL_DESC);

            /*" -1758- MOVE WHOST-VLPRMLIQ TO V1CHIS-VLPRMLIQ. */
            _.Move(WHOST_VLPRMLIQ, V1CHIS_VLPRMLIQ);

            /*" -1759- MOVE WHOST-VLADIFRA TO V1CHIS-VLADIFRA. */
            _.Move(WHOST_VLADIFRA, V1CHIS_VLADIFRA);

            /*" -1760- MOVE WHOST-VLCOMISS TO V1CHIS-VLCOMISS. */
            _.Move(WHOST_VLCOMISS, V1CHIS_VLCOMISS);

            /*" -1762- MOVE WHOST-VLPRMTOT TO V1CHIS-VLPRMTOT. */
            _.Move(WHOST_VLPRMTOT, V1CHIS_VLPRMTOT);

            /*" -1762- MOVE V1RELA-PERI-INI TO V1CHIS-DTQITBCO. */
            _.Move(V1RELA_PERI_INI, V1CHIS_DTQITBCO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-CALC-CORR-NINDEX-SECTION */
        private void R2300_00_CALC_CORR_NINDEX_SECTION()
        {
            /*" -1775- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", WABEND.WNR_EXEC_SQL);

            /*" -1776- MOVE V1RELA-CODUNIMO TO V1MOED-CODUNIMO. */
            _.Move(V1RELA_CODUNIMO, V1MOED_CODUNIMO);

            /*" -1778- MOVE V1CHIS-DTQITBCO TO V1MOED-DTINIVIG. */
            _.Move(V1CHIS_DTQITBCO, V1MOED_DTINIVIG);

            /*" -1780- PERFORM R1000-00-SELECT-V1MOEDA. */

            R1000_00_SELECT_V1MOEDA_SECTION();

            /*" -1781- MOVE V0ENDO-MOEDA-PRM TO V1COTA-CODUNIMO. */
            _.Move(V0ENDO_MOEDA_PRM, V1COTA_CODUNIMO);

            /*" -1783- MOVE V0ENDO-DTINIVIG TO V1COTA-DTINIVIG. */
            _.Move(V0ENDO_DTINIVIG, V1COTA_DTINIVIG);

            /*" -1785- PERFORM R2400-00-SELECT-V1COTACAO. */

            R2400_00_SELECT_V1COTACAO_SECTION();

            /*" -1788- COMPUTE V1CPRE-PRMTAR-IX ROUNDED = V1CPRE-PRMTAR-IX * V1COTA-VAL-VENDA. */
            V1CPRE_PRMTAR_IX.Value = V1CPRE_PRMTAR_IX * V1COTA_VAL_VENDA;

            /*" -1791- COMPUTE WHOST-PRMTAR-IX = V1CPRE-PRMTAR-IX / V1MOED-VLCRUZAD. */
            WHOST_PRMTAR_IX.Value = V1CPRE_PRMTAR_IX / V1MOED_VLCRUZAD;

            /*" -1794- COMPUTE WHOST-PRM-TARF ROUNDED = WHOST-PRMTAR-IX * WHOST-VLCRUZAD1. */
            WHOST_PRM_TARF.Value = WHOST_PRMTAR_IX * WHOST_VLCRUZAD1;

            /*" -1797- COMPUTE V1CPRE-VLDESC-IX ROUNDED = V1CPRE-VLDESC-IX * V1COTA-VAL-VENDA. */
            V1CPRE_VLDESC_IX.Value = V1CPRE_VLDESC_IX * V1COTA_VAL_VENDA;

            /*" -1800- COMPUTE WHOST-VLDESC-IX = V1CPRE-VLDESC-IX / V1MOED-VLCRUZAD. */
            WHOST_VLDESC_IX.Value = V1CPRE_VLDESC_IX / V1MOED_VLCRUZAD;

            /*" -1803- COMPUTE WHOST-VAL-DESC ROUNDED = WHOST-VLDESC-IX * WHOST-VLCRUZAD1. */
            WHOST_VAL_DESC.Value = WHOST_VLDESC_IX * WHOST_VLCRUZAD1;

            /*" -1806- COMPUTE WHOST-PRMLIQ-IX = WHOST-PRMTAR-IX - WHOST-VLDESC-IX. */
            WHOST_PRMLIQ_IX.Value = WHOST_PRMTAR_IX - WHOST_VLDESC_IX;

            /*" -1809- COMPUTE WHOST-VLPRMLIQ = WHOST-PRM-TARF - WHOST-VAL-DESC. */
            WHOST_VLPRMLIQ.Value = WHOST_PRM_TARF - WHOST_VAL_DESC;

            /*" -1812- COMPUTE V1CPRE-OTNADFRA ROUNDED = V1CPRE-OTNADFRA * V1COTA-VAL-VENDA. */
            V1CPRE_OTNADFRA.Value = V1CPRE_OTNADFRA * V1COTA_VAL_VENDA;

            /*" -1815- COMPUTE WHOST-ADFRAC-IX = V1CPRE-OTNADFRA / V1MOED-VLCRUZAD. */
            WHOST_ADFRAC_IX.Value = V1CPRE_OTNADFRA / V1MOED_VLCRUZAD;

            /*" -1818- COMPUTE WHOST-VLADIFRA ROUNDED = WHOST-ADFRAC-IX * WHOST-VLCRUZAD1. */
            WHOST_VLADIFRA.Value = WHOST_ADFRAC_IX * WHOST_VLCRUZAD1;

            /*" -1821- COMPUTE V1CPRE-VLCOMS-IX ROUNDED = V1CPRE-VLCOMS-IX * V1COTA-VAL-VENDA. */
            V1CPRE_VLCOMS_IX.Value = V1CPRE_VLCOMS_IX * V1COTA_VAL_VENDA;

            /*" -1824- COMPUTE WHOST-VLCOMS-IX = V1CPRE-VLCOMS-IX / V1MOED-VLCRUZAD. */
            WHOST_VLCOMS_IX.Value = V1CPRE_VLCOMS_IX / V1MOED_VLCRUZAD;

            /*" -1827- COMPUTE WHOST-VLCOMISS ROUNDED = WHOST-VLCOMS-IX * WHOST-VLCRUZAD1. */
            WHOST_VLCOMISS.Value = WHOST_VLCOMS_IX * WHOST_VLCRUZAD1;

            /*" -1831- COMPUTE WHOST-PRMTOT-IX = WHOST-PRMLIQ-IX + WHOST-ADFRAC-IX - WHOST-VLCOMS-IX. */
            WHOST_PRMTOT_IX.Value = WHOST_PRMLIQ_IX + WHOST_ADFRAC_IX - WHOST_VLCOMS_IX;

            /*" -1833- COMPUTE WHOST-VLPRMTOT = WHOST-VLPRMLIQ + WHOST-VLADIFRA - WHOST-VLCOMISS. */
            WHOST_VLPRMTOT.Value = WHOST_VLPRMLIQ + WHOST_VLADIFRA - WHOST_VLCOMISS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-SELECT-V1COTACAO-SECTION */
        private void R2400_00_SELECT_V1COTACAO_SECTION()
        {
            /*" -1846- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", WABEND.WNR_EXEC_SQL);

            /*" -1856- PERFORM R2400_00_SELECT_V1COTACAO_DB_SELECT_1 */

            R2400_00_SELECT_V1COTACAO_DB_SELECT_1();

            /*" -1859- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1860- DISPLAY 'R2400 - ERRO NO SELECT DA V1COTACAO' */
                _.Display($"R2400 - ERRO NO SELECT DA V1COTACAO");

                /*" -1861- DISPLAY 'EMPRESA   - ' V1CHIS-COD-EMPR */
                _.Display($"EMPRESA   - {V1CHIS_COD_EMPR}");

                /*" -1862- DISPLAY 'COD CONG  - ' V1CHIS-CONGENER */
                _.Display($"COD CONG  - {V1CHIS_CONGENER}");

                /*" -1863- DISPLAY 'APOLICE   - ' V1CHIS-NUM-APOL */
                _.Display($"APOLICE   - {V1CHIS_NUM_APOL}");

                /*" -1864- DISPLAY 'ENDOSSO   - ' V1CHIS-NUM-ENDS */
                _.Display($"ENDOSSO   - {V1CHIS_NUM_ENDS}");

                /*" -1865- DISPLAY 'COD MOEDA - ' V1COTA-CODUNIMO */
                _.Display($"COD MOEDA - {V1COTA_CODUNIMO}");

                /*" -1866- DISPLAY 'INIC VIGC - ' V1COTA-DTINIVIG */
                _.Display($"INIC VIGC - {V1COTA_DTINIVIG}");

                /*" -1867- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1867- END-IF. */
            }


        }

        [StopWatch]
        /*" R2400-00-SELECT-V1COTACAO-DB-SELECT-1 */
        public void R2400_00_SELECT_V1COTACAO_DB_SELECT_1()
        {
            /*" -1856- EXEC SQL SELECT VAL_VENDA INTO :V1COTA-VAL-VENDA FROM SEGUROS.V1COTACAO WHERE CODUNIMO = :V1COTA-CODUNIMO AND DTINIVIG <= :V1COTA-DTINIVIG AND DTTERVIG >= :V1COTA-DTINIVIG END-EXEC. */

            var r2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1 = new R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1()
            {
                V1COTA_CODUNIMO = V1COTA_CODUNIMO.ToString(),
                V1COTA_DTINIVIG = V1COTA_DTINIVIG.ToString(),
            };

            var executed_1 = R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1.Execute(r2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1COTA_VAL_VENDA, V1COTA_VAL_VENDA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-INSERT-COSSEGHIS-SECTION */
        private void R2500_00_INSERT_COSSEGHIS_SECTION()
        {
            /*" -1880- MOVE '250' TO WNR-EXEC-SQL. */
            _.Move("250", WABEND.WNR_EXEC_SQL);

            /*" -1902- PERFORM R2500_00_INSERT_COSSEGHIS_DB_INSERT_1 */

            R2500_00_INSERT_COSSEGHIS_DB_INSERT_1();

            /*" -1905- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1906- DISPLAY 'R2500 - ERRO NO INSERT DA V0COSSEG_HISTPRE' */
                _.Display($"R2500 - ERRO NO INSERT DA V0COSSEG_HISTPRE");

                /*" -1907- DISPLAY 'EMPRESA   - ' V0CHIS-COD-EMPR */
                _.Display($"EMPRESA   - {V0CHIS_COD_EMPR}");

                /*" -1908- DISPLAY 'COD CONG  - ' V0CHIS-CONGENER */
                _.Display($"COD CONG  - {V0CHIS_CONGENER}");

                /*" -1909- DISPLAY 'APOLICE   - ' V0CHIS-NUM-APOL */
                _.Display($"APOLICE   - {V0CHIS_NUM_APOL}");

                /*" -1910- DISPLAY 'ENDOSSO   - ' V0CHIS-NUM-ENDS */
                _.Display($"ENDOSSO   - {V0CHIS_NUM_ENDS}");

                /*" -1911- DISPLAY 'PARCELA   - ' V0CHIS-NRPARCEL */
                _.Display($"PARCELA   - {V0CHIS_NRPARCEL}");

                /*" -1912- DISPLAY 'OCOR HIST - ' V0CHIS-OCORHIST */
                _.Display($"OCOR HIST - {V0CHIS_OCORHIST}");

                /*" -1913- DISPLAY 'OPERACAO  - ' V0CHIS-OPERACAO */
                _.Display($"OPERACAO  - {V0CHIS_OPERACAO}");

                /*" -1914- DISPLAY 'DATA MOVT - ' V0CHIS-DAT-MOVT */
                _.Display($"DATA MOVT - {V0CHIS_DAT_MOVT}");

                /*" -1915- DISPLAY 'TIPO SEGU - ' V0CHIS-TIP-SEGU */
                _.Display($"TIPO SEGU - {V0CHIS_TIP_SEGU}");

                /*" -1916- DISPLAY 'NUM OCORR - ' V0CHIS-NUM-OCOR */
                _.Display($"NUM OCORR - {V0CHIS_NUM_OCOR}");

                /*" -1917- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1918- ELSE */
            }
            else
            {


                /*" -1919- ADD 1 TO AC-I-COSSEGHIS */
                AREA_DE_WORK.AC_I_COSSEGHIS.Value = AREA_DE_WORK.AC_I_COSSEGHIS + 1;

                /*" -1919- END-IF. */
            }


        }

        [StopWatch]
        /*" R2500-00-INSERT-COSSEGHIS-DB-INSERT-1 */
        public void R2500_00_INSERT_COSSEGHIS_DB_INSERT_1()
        {
            /*" -1902- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_HISTPRE VALUES (:V0CHIS-COD-EMPR , :V0CHIS-CONGENER , :V0CHIS-NUM-APOL , :V0CHIS-NUM-ENDS , :V0CHIS-NRPARCEL , :V0CHIS-OCORHIST , :V0CHIS-OPERACAO , :V0CHIS-DAT-MOVT , :V0CHIS-TIP-SEGU , :V0CHIS-PRM-TARF , :V0CHIS-VAL-DESC , :V0CHIS-VLPRMLIQ , :V0CHIS-VLADIFRA , :V0CHIS-VLCOMISS , :V0CHIS-VLPRMTOT , CURRENT TIMESTAMP , :V0CHIS-DTQITBCO:VIND-DTQITBCO, :V0CHIS-SIT-FINC:VIND-SIT-FINC, :V0CHIS-SIT-LIBR:VIND-SIT-LIBR, :V0CHIS-NUM-OCOR:VIND-NUM-OCOR) END-EXEC. */

            var r2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1 = new R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1()
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
                V0CHIS_PRM_TARF = V0CHIS_PRM_TARF.ToString(),
                V0CHIS_VAL_DESC = V0CHIS_VAL_DESC.ToString(),
                V0CHIS_VLPRMLIQ = V0CHIS_VLPRMLIQ.ToString(),
                V0CHIS_VLADIFRA = V0CHIS_VLADIFRA.ToString(),
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

            R2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1.Execute(r2500_00_INSERT_COSSEGHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-UPDATE-COSSEGPRE-SECTION */
        private void R2600_00_UPDATE_COSSEGPRE_SECTION()
        {
            /*" -1932- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", WABEND.WNR_EXEC_SQL);

            /*" -1942- PERFORM R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1 */

            R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1();

            /*" -1945- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1946- DISPLAY 'R2600 - ERRO NO UPDATE DA V0COSSEG_PREM' */
                _.Display($"R2600 - ERRO NO UPDATE DA V0COSSEG_PREM");

                /*" -1947- DISPLAY 'EMPRESA  - ' V1CHIS-COD-EMPR */
                _.Display($"EMPRESA  - {V1CHIS_COD_EMPR}");

                /*" -1948- DISPLAY 'COD CONG - ' V1CHIS-CONGENER */
                _.Display($"COD CONG - {V1CHIS_CONGENER}");

                /*" -1949- DISPLAY 'APOLICE  - ' V1CHIS-NUM-APOL */
                _.Display($"APOLICE  - {V1CHIS_NUM_APOL}");

                /*" -1950- DISPLAY 'ENDOSSO  - ' V1CHIS-NUM-ENDS */
                _.Display($"ENDOSSO  - {V1CHIS_NUM_ENDS}");

                /*" -1951- DISPLAY 'PARCELA  - ' V1CHIS-NRPARCEL */
                _.Display($"PARCELA  - {V1CHIS_NRPARCEL}");

                /*" -1952- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1953- ELSE */
            }
            else
            {


                /*" -1954- ADD 1 TO AC-U-COSSEGPRE */
                AREA_DE_WORK.AC_U_COSSEGPRE.Value = AREA_DE_WORK.AC_U_COSSEGPRE + 1;

                /*" -1954- END-IF. */
            }


        }

        [StopWatch]
        /*" R2600-00-UPDATE-COSSEGPRE-DB-UPDATE-1 */
        public void R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1()
        {
            /*" -1942- EXEC SQL UPDATE SEGUROS.V0COSSEG_PREM SET SIT_CONGENERE = '1' , OCORHIST = :V1CPRE-OCORHIST , TIMESTAMP = CURRENT TIMESTAMP WHERE CONGENER = :V1CHIS-CONGENER AND NUM_APOLICE = :V1CHIS-NUM-APOL AND NRENDOS = :V1CHIS-NUM-ENDS AND NRPARCEL = :V1CHIS-NRPARCEL AND TIPSGU = '1' END-EXEC. */

            var r2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1 = new R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1()
            {
                V1CPRE_OCORHIST = V1CPRE_OCORHIST.ToString(),
                V1CHIS_CONGENER = V1CHIS_CONGENER.ToString(),
                V1CHIS_NUM_APOL = V1CHIS_NUM_APOL.ToString(),
                V1CHIS_NUM_ENDS = V1CHIS_NUM_ENDS.ToString(),
                V1CHIS_NRPARCEL = V1CHIS_NRPARCEL.ToString(),
            };

            R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1.Execute(r2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-UPDATE-COSSEGHIS-SECTION */
        private void R2700_00_UPDATE_COSSEGHIS_SECTION()
        {
            /*" -1967- MOVE '270' TO WNR-EXEC-SQL. */
            _.Move("270", WABEND.WNR_EXEC_SQL);

            /*" -1978- PERFORM R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1 */

            R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1();

            /*" -1981- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1982- DISPLAY 'R2700 - ERRO NO UPDATE DA V0COSSEG_HISTPRE' */
                _.Display($"R2700 - ERRO NO UPDATE DA V0COSSEG_HISTPRE");

                /*" -1983- DISPLAY 'EMPRESA   - ' V1CHIS-COD-EMPR */
                _.Display($"EMPRESA   - {V1CHIS_COD_EMPR}");

                /*" -1984- DISPLAY 'COD CONG  - ' V1CHIS-CONGENER */
                _.Display($"COD CONG  - {V1CHIS_CONGENER}");

                /*" -1985- DISPLAY 'APOLICE   - ' V1CHIS-NUM-APOL */
                _.Display($"APOLICE   - {V1CHIS_NUM_APOL}");

                /*" -1986- DISPLAY 'ENDOSSO   - ' V1CHIS-NUM-ENDS */
                _.Display($"ENDOSSO   - {V1CHIS_NUM_ENDS}");

                /*" -1987- DISPLAY 'PARCELA   - ' V1CHIS-NRPARCEL */
                _.Display($"PARCELA   - {V1CHIS_NRPARCEL}");

                /*" -1988- DISPLAY 'OCOR HIST - ' V1CHIS-OCORHIST */
                _.Display($"OCOR HIST - {V1CHIS_OCORHIST}");

                /*" -1989- DISPLAY 'OPERACAO  - ' V1CHIS-OPERACAO */
                _.Display($"OPERACAO  - {V1CHIS_OPERACAO}");

                /*" -1990- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1991- ELSE */
            }
            else
            {


                /*" -1992- ADD 1 TO AC-U-COSSEGHIS */
                AREA_DE_WORK.AC_U_COSSEGHIS.Value = AREA_DE_WORK.AC_U_COSSEGHIS + 1;

                /*" -1992- END-IF. */
            }


        }

        [StopWatch]
        /*" R2700-00-UPDATE-COSSEGHIS-DB-UPDATE-1 */
        public void R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1()
        {
            /*" -1978- EXEC SQL UPDATE SEGUROS.V0COSSEG_HISTPRE SET TIMESTAMP = CURRENT TIMESTAMP , SIT_LIBRECUP = '1' WHERE CONGENER = :V1CHIS-CONGENER AND NUM_APOLICE = :V1CHIS-NUM-APOL AND NRENDOS = :V1CHIS-NUM-ENDS AND NRPARCEL = :V1CHIS-NRPARCEL AND OCORHIST = :V1CHIS-OCORHIST AND OPERACAO = :V1CHIS-OPERACAO AND TIPSGU = '1' END-EXEC. */

            var r2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1 = new R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1()
            {
                V1CHIS_CONGENER = V1CHIS_CONGENER.ToString(),
                V1CHIS_NUM_APOL = V1CHIS_NUM_APOL.ToString(),
                V1CHIS_NUM_ENDS = V1CHIS_NUM_ENDS.ToString(),
                V1CHIS_NRPARCEL = V1CHIS_NRPARCEL.ToString(),
                V1CHIS_OCORHIST = V1CHIS_OCORHIST.ToString(),
                V1CHIS_OPERACAO = V1CHIS_OPERACAO.ToString(),
            };

            R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1.Execute(r2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-MONTA-COSCED-CHEQUE-SECTION */
        private void R3000_00_MONTA_COSCED_CHEQUE_SECTION()
        {
            /*" -2005- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", WABEND.WNR_EXEC_SQL);

            /*" -2007- MOVE SPACES TO WHOST-DTMOVTO-AC. */
            _.Move("", WHOST_DTMOVTO_AC);

            /*" -2024- MOVE ZEROS TO WHOST-VLRPREMIO WHOST-VLRDESCON WHOST-VLRADIFRA WHOST-VLR-COMIS WHOST-VLR-SINIS WHOST-VLDESPESA WHOST-VLR-HONOR WHOST-VLR-SALVD WHOST-VLRESSARC WHOST-VALOR-EDI WHOST-VALOR-USS WHOST-VLEQPVNDA WHOST-VLDESPADM WHOST-OUTRDEBIT WHOST-OUTRCREDT WHOST-VLRSLDANT. */
            _.Move(0, WHOST_VLRPREMIO, WHOST_VLRDESCON, WHOST_VLRADIFRA, WHOST_VLR_COMIS, WHOST_VLR_SINIS, WHOST_VLDESPESA, WHOST_VLR_HONOR, WHOST_VLR_SALVD, WHOST_VLRESSARC, WHOST_VALOR_EDI, WHOST_VALOR_USS, WHOST_VLEQPVNDA, WHOST_VLDESPADM, WHOST_OUTRDEBIT, WHOST_OUTRCREDT, WHOST_VLRSLDANT);

            /*" -2026- PERFORM R3100-00-SELECT-V0COSCED-CHQ. */

            R3100_00_SELECT_V0COSCED_CHQ_SECTION();

            /*" -2043- COMPUTE WVLR-SLD-ANT = WHOST-VLRPREMIO - WHOST-VLRDESCON + WHOST-VLRADIFRA - WHOST-VLR-COMIS - WHOST-VLR-SINIS - WHOST-VLDESPESA - WHOST-VLR-HONOR + WHOST-VLR-SALVD + WHOST-VLRESSARC - WHOST-VALOR-EDI - WHOST-VALOR-USS - WHOST-VLEQPVNDA - WHOST-VLDESPADM - WHOST-OUTRDEBIT + WHOST-OUTRCREDT - WHOST-VLRSLDANT. */
            AREA_DE_WORK.WVLR_SLD_ANT.Value = WHOST_VLRPREMIO - WHOST_VLRDESCON + WHOST_VLRADIFRA - WHOST_VLR_COMIS - WHOST_VLR_SINIS - WHOST_VLDESPESA - WHOST_VLR_HONOR + WHOST_VLR_SALVD + WHOST_VLRESSARC - WHOST_VALOR_EDI - WHOST_VALOR_USS - WHOST_VLEQPVNDA - WHOST_VLDESPADM - WHOST_OUTRDEBIT + WHOST_OUTRCREDT - WHOST_VLRSLDANT;

            /*" -2044- IF WVLR-SLD-ANT < ZEROS */

            if (AREA_DE_WORK.WVLR_SLD_ANT < 00)
            {

                /*" -2045- COMPUTE V0CCHQ-VLRSLDANT = WVLR-SLD-ANT * -1 */
                V0CCHQ_VLRSLDANT.Value = AREA_DE_WORK.WVLR_SLD_ANT * -1;

                /*" -2046- ELSE */
            }
            else
            {


                /*" -2047- MOVE +0 TO V0CCHQ-VLRSLDANT */
                _.Move(+0, V0CCHQ_VLRSLDANT);

                /*" -2049- END-IF. */
            }


            /*" -2051- MOVE V1RELA-COD-EMPR TO V0CCHQ-COD-EMPR. */
            _.Move(V1RELA_COD_EMPR, V0CCHQ_COD_EMPR);

            /*" -2052- MOVE V1RELA-CONGENER TO V0CCHQ-CONGENER. */
            _.Move(V1RELA_CONGENER, V0CCHQ_CONGENER);

            /*" -2053- MOVE V1RELA-DATA-SOL TO V0CCHQ-DTMOVTO-AC. */
            _.Move(V1RELA_DATA_SOL, V0CCHQ_DTMOVTO_AC);

            /*" -2054- MOVE V1RELA-COD-USU TO V0CCHQ-CODUSU-AC. */
            _.Move(V1RELA_COD_USU, V0CCHQ_CODUSU_AC);

            /*" -2055- MOVE V1RELA-DATA-REF TO V0CCHQ-DTLIBERA. */
            _.Move(V1RELA_DATA_REF, V0CCHQ_DTLIBERA);

            /*" -2056- MOVE AC-PRM-TARF TO V0CCHQ-VLPREMIO. */
            _.Move(AREA_DE_WORK.AC_PRM_TARF, V0CCHQ_VLPREMIO);

            /*" -2057- MOVE AC-DESCONTO TO V0CCHQ-VLRDESCON. */
            _.Move(AREA_DE_WORK.AC_DESCONTO, V0CCHQ_VLRDESCON);

            /*" -2058- MOVE AC-VLADIFRA TO V0CCHQ-VLRADIFRA. */
            _.Move(AREA_DE_WORK.AC_VLADIFRA, V0CCHQ_VLRADIFRA);

            /*" -2060- MOVE AC-COMISSAO TO V0CCHQ-VLRCOMIS. */
            _.Move(AREA_DE_WORK.AC_COMISSAO, V0CCHQ_VLRCOMIS);

            /*" -2062- MOVE AC-PRMLIQ-6668 TO V0CCHQ-OUTRDEBIT. */
            _.Move(AREA_DE_WORK.AC_PRMLIQ_6668, V0CCHQ_OUTRDEBIT);

            /*" -2064- MOVE V1RELA-CODUNIMO TO V0CCHQ-COD-MOEDA. */
            _.Move(V1RELA_CODUNIMO, V0CCHQ_COD_MOEDA);

            /*" -2065- IF V1RELA-CODUNIMO = ZEROS */

            if (V1RELA_CODUNIMO == 00)
            {

                /*" -2066- MOVE -1 TO VIND-CODUNIMO */
                _.Move(-1, VIND_CODUNIMO);

                /*" -2067- ELSE */
            }
            else
            {


                /*" -2068- MOVE +1 TO VIND-CODUNIMO */
                _.Move(+1, VIND_CODUNIMO);

                /*" -2070- END-IF. */
            }


            /*" -2071- MOVE SPACES TO V0CCHQ-DTMOVTO-FI. */
            _.Move("", V0CCHQ_DTMOVTO_FI);

            /*" -2073- MOVE -1 TO VIND-DTMOVTO-FI. */
            _.Move(-1, VIND_DTMOVTO_FI);

            /*" -2074- MOVE SPACES TO V0CCHQ-CODUSU-FI. */
            _.Move("", V0CCHQ_CODUSU_FI);

            /*" -2076- MOVE -1 TO VIND-COD-USU-FI. */
            _.Move(-1, VIND_COD_USU_FI);

            /*" -2077- IF V1RELA-PERI-INI NOT = '0001-01-01' */

            if (V1RELA_PERI_INI != "0001-01-01")
            {

                /*" -2078- MOVE V1RELA-PERI-INI TO V0CCHQ-DTCORRECAO */
                _.Move(V1RELA_PERI_INI, V0CCHQ_DTCORRECAO);

                /*" -2079- MOVE +1 TO VIND-DTCORRECAO */
                _.Move(+1, VIND_DTCORRECAO);

                /*" -2080- ELSE */
            }
            else
            {


                /*" -2081- MOVE SPACES TO V0CCHQ-DTCORRECAO */
                _.Move("", V0CCHQ_DTCORRECAO);

                /*" -2082- MOVE -1 TO VIND-DTCORRECAO */
                _.Move(-1, VIND_DTCORRECAO);

                /*" -2084- END-IF. */
            }


            /*" -2084- PERFORM R3200-00-INSERT-V0COSCED-CHQ. */

            R3200_00_INSERT_V0COSCED_CHQ_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-SELECT-V0COSCED-CHQ-SECTION */
        private void R3100_00_SELECT_V0COSCED_CHQ_SECTION()
        {
            /*" -2097- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", WABEND.WNR_EXEC_SQL);

            /*" -2104- PERFORM R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1 */

            R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1();

            /*" -2107- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2108- DISPLAY 'R3100 - ERRO NO SELECT DA V0COSCED_CHEQUE' */
                _.Display($"R3100 - ERRO NO SELECT DA V0COSCED_CHEQUE");

                /*" -2109- DISPLAY 'EMPRESA  - ' V1RELA-COD-EMPR */
                _.Display($"EMPRESA  - {V1RELA_COD_EMPR}");

                /*" -2110- DISPLAY 'COD CONG - ' V1RELA-CONGENER */
                _.Display($"COD CONG - {V1RELA_CONGENER}");

                /*" -2111- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2112- ELSE */
            }
            else
            {


                /*" -2113- IF VIND-DTMOVTO-AC < ZEROS */

                if (VIND_DTMOVTO_AC < 00)
                {

                    /*" -2114- GO TO R3100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/ //GOTO
                    return;

                    /*" -2115- END-IF */
                }


                /*" -2119- END-IF. */
            }


            /*" -2157- PERFORM R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2 */

            R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2();

            /*" -2160- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2162- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -2163- ELSE */
                }
                else
                {


                    /*" -2164- DISPLAY 'R3100 - ERRO DE SELECT NA V0COSCED_CHEQUE' */
                    _.Display($"R3100 - ERRO DE SELECT NA V0COSCED_CHEQUE");

                    /*" -2165- DISPLAY 'COD EMPRESA - ' V1RELA-COD-EMPR */
                    _.Display($"COD EMPRESA - {V1RELA_COD_EMPR}");

                    /*" -2166- DISPLAY 'COD CONGENR - ' V1RELA-CONGENER */
                    _.Display($"COD CONGENR - {V1RELA_CONGENER}");

                    /*" -2167- DISPLAY 'DT MOVTO AC - ' WHOST-DTMOVTO-AC */
                    _.Display($"DT MOVTO AC - {WHOST_DTMOVTO_AC}");

                    /*" -2168- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2169- END-IF */
                }


                /*" -2169- END-IF. */
            }


        }

        [StopWatch]
        /*" R3100-00-SELECT-V0COSCED-CHQ-DB-SELECT-1 */
        public void R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1()
        {
            /*" -2104- EXEC SQL SELECT MAX(DTMOVTO_AC) INTO :WHOST-DTMOVTO-AC:VIND-DTMOVTO-AC FROM SEGUROS.V0COSCED_CHEQUE WHERE COD_EMPRESA = :V1RELA-COD-EMPR AND CONGENER = :V1RELA-CONGENER AND SITUACAO = '1' END-EXEC. */

            var r3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1 = new R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1()
            {
                V1RELA_COD_EMPR = V1RELA_COD_EMPR.ToString(),
                V1RELA_CONGENER = V1RELA_CONGENER.ToString(),
            };

            var executed_1 = R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1.Execute(r3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTMOVTO_AC, WHOST_DTMOVTO_AC);
                _.Move(executed_1.VIND_DTMOVTO_AC, VIND_DTMOVTO_AC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-SELECT-V0COSCED-CHQ-DB-SELECT-2 */
        public void R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2()
        {
            /*" -2157- EXEC SQL SELECT VLPREMIO, VLRDESCON, VLRADIFRA, VLRCOMIS, VLRSINI, VLDESPESA, VLRHONOR, VLRSALVD, VLRESSARC, VALOR_EDI, VALOR_USS, VLEQPVNDA, VLDESPADM, OUTRDEBIT, OUTRCREDT, VLRSLDANT INTO :WHOST-VLRPREMIO, :WHOST-VLRDESCON, :WHOST-VLRADIFRA, :WHOST-VLR-COMIS, :WHOST-VLR-SINIS, :WHOST-VLDESPESA, :WHOST-VLR-HONOR, :WHOST-VLR-SALVD, :WHOST-VLRESSARC, :WHOST-VALOR-EDI, :WHOST-VALOR-USS, :WHOST-VLEQPVNDA, :WHOST-VLDESPADM, :WHOST-OUTRDEBIT, :WHOST-OUTRCREDT, :WHOST-VLRSLDANT FROM SEGUROS.V0COSCED_CHEQUE WHERE COD_EMPRESA = :V1RELA-COD-EMPR AND CONGENER = :V1RELA-CONGENER AND DTMOVTO_AC = :WHOST-DTMOVTO-AC AND SITUACAO = '1' END-EXEC. */

            var r3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1 = new R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1()
            {
                WHOST_DTMOVTO_AC = WHOST_DTMOVTO_AC.ToString(),
                V1RELA_COD_EMPR = V1RELA_COD_EMPR.ToString(),
                V1RELA_CONGENER = V1RELA_CONGENER.ToString(),
            };

            var executed_1 = R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1.Execute(r3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_VLRPREMIO, WHOST_VLRPREMIO);
                _.Move(executed_1.WHOST_VLRDESCON, WHOST_VLRDESCON);
                _.Move(executed_1.WHOST_VLRADIFRA, WHOST_VLRADIFRA);
                _.Move(executed_1.WHOST_VLR_COMIS, WHOST_VLR_COMIS);
                _.Move(executed_1.WHOST_VLR_SINIS, WHOST_VLR_SINIS);
                _.Move(executed_1.WHOST_VLDESPESA, WHOST_VLDESPESA);
                _.Move(executed_1.WHOST_VLR_HONOR, WHOST_VLR_HONOR);
                _.Move(executed_1.WHOST_VLR_SALVD, WHOST_VLR_SALVD);
                _.Move(executed_1.WHOST_VLRESSARC, WHOST_VLRESSARC);
                _.Move(executed_1.WHOST_VALOR_EDI, WHOST_VALOR_EDI);
                _.Move(executed_1.WHOST_VALOR_USS, WHOST_VALOR_USS);
                _.Move(executed_1.WHOST_VLEQPVNDA, WHOST_VLEQPVNDA);
                _.Move(executed_1.WHOST_VLDESPADM, WHOST_VLDESPADM);
                _.Move(executed_1.WHOST_OUTRDEBIT, WHOST_OUTRDEBIT);
                _.Move(executed_1.WHOST_OUTRCREDT, WHOST_OUTRCREDT);
                _.Move(executed_1.WHOST_VLRSLDANT, WHOST_VLRSLDANT);
            }


        }

        [StopWatch]
        /*" R3200-00-INSERT-V0COSCED-CHQ-SECTION */
        private void R3200_00_INSERT_V0COSCED_CHQ_SECTION()
        {
            /*" -2182- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", WABEND.WNR_EXEC_SQL);

            /*" -2213- PERFORM R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1 */

            R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1();

            /*" -2216- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2218- IF SQLCODE EQUAL -803 NEXT SENTENCE */

                if (DB.SQLCODE == -803)
                {

                    /*" -2219- ELSE */
                }
                else
                {


                    /*" -2220- DISPLAY 'R3200 - ERRO NO INSERT DA V0COSCED_CHEQUE' */
                    _.Display($"R3200 - ERRO NO INSERT DA V0COSCED_CHEQUE");

                    /*" -2221- DISPLAY 'COD EMPRESA - ' V0CCHQ-COD-EMPR */
                    _.Display($"COD EMPRESA - {V0CCHQ_COD_EMPR}");

                    /*" -2222- DISPLAY 'COD CONGENR - ' V0CCHQ-CONGENER */
                    _.Display($"COD CONGENR - {V0CCHQ_CONGENER}");

                    /*" -2223- DISPLAY 'DT MOVTO AC - ' V0CCHQ-DTMOVTO-AC */
                    _.Display($"DT MOVTO AC - {V0CCHQ_DTMOVTO_AC}");

                    /*" -2224- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2225- END-IF */
                }


                /*" -2225- END-IF. */
            }


        }

        [StopWatch]
        /*" R3200-00-INSERT-V0COSCED-CHQ-DB-INSERT-1 */
        public void R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1()
        {
            /*" -2213- EXEC SQL INSERT INTO SEGUROS.V0COSCED_CHEQUE VALUES (:V0CCHQ-COD-EMPR , :V0CCHQ-CONGENER , :V0CCHQ-DTMOVTO-AC , :V0CCHQ-CODUSU-AC , :V0CCHQ-DTLIBERA , 0, 0, :V0CCHQ-VLPREMIO , :V0CCHQ-VLRDESCON , :V0CCHQ-VLRADIFRA , :V0CCHQ-VLRCOMIS , 0, 0, 0, 0, 0, 0, 0, 0, 0, :V0CCHQ-OUTRDEBIT, 0, :V0CCHQ-VLRSLDANT, ' ' , :V0CCHQ-COD-MOEDA:VIND-CODUNIMO, :V0CCHQ-DTMOVTO-FI:VIND-DTMOVTO-FI, :V0CCHQ-CODUSU-FI:VIND-COD-USU-FI, :V0CCHQ-DTCORRECAO:VIND-DTCORRECAO, CURRENT TIMESTAMP) END-EXEC. */

            var r3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1 = new R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1()
            {
                V0CCHQ_COD_EMPR = V0CCHQ_COD_EMPR.ToString(),
                V0CCHQ_CONGENER = V0CCHQ_CONGENER.ToString(),
                V0CCHQ_DTMOVTO_AC = V0CCHQ_DTMOVTO_AC.ToString(),
                V0CCHQ_CODUSU_AC = V0CCHQ_CODUSU_AC.ToString(),
                V0CCHQ_DTLIBERA = V0CCHQ_DTLIBERA.ToString(),
                V0CCHQ_VLPREMIO = V0CCHQ_VLPREMIO.ToString(),
                V0CCHQ_VLRDESCON = V0CCHQ_VLRDESCON.ToString(),
                V0CCHQ_VLRADIFRA = V0CCHQ_VLRADIFRA.ToString(),
                V0CCHQ_VLRCOMIS = V0CCHQ_VLRCOMIS.ToString(),
                V0CCHQ_OUTRDEBIT = V0CCHQ_OUTRDEBIT.ToString(),
                V0CCHQ_VLRSLDANT = V0CCHQ_VLRSLDANT.ToString(),
                V0CCHQ_COD_MOEDA = V0CCHQ_COD_MOEDA.ToString(),
                VIND_CODUNIMO = VIND_CODUNIMO.ToString(),
                V0CCHQ_DTMOVTO_FI = V0CCHQ_DTMOVTO_FI.ToString(),
                VIND_DTMOVTO_FI = VIND_DTMOVTO_FI.ToString(),
                V0CCHQ_CODUSU_FI = V0CCHQ_CODUSU_FI.ToString(),
                VIND_COD_USU_FI = VIND_COD_USU_FI.ToString(),
                V0CCHQ_DTCORRECAO = V0CCHQ_DTCORRECAO.ToString(),
                VIND_DTCORRECAO = VIND_DTCORRECAO.ToString(),
            };

            R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1.Execute(r3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -2237- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -2238- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -2239- DISPLAY '*   AC0812B - COSSEGURO CEDIDO PENDENTE    *' . */
            _.Display($"*   AC0812B - COSSEGURO CEDIDO PENDENTE    *");

            /*" -2240- DISPLAY '*   -------   --------- ------ --------    *' . */
            _.Display($"*   -------   --------- ------ --------    *");

            /*" -2241- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -2242- DISPLAY '*   NAO HOUVE SOLICITACAO PARA PROCESSAR   *' . */
            _.Display($"*   NAO HOUVE SOLICITACAO PARA PROCESSAR   *");

            /*" -2243- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -2243- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -2255- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -2256- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -2257- DISPLAY '*   AC0812B - COSSEGURO CEDIDO PENDENTE    *' . */
            _.Display($"*   AC0812B - COSSEGURO CEDIDO PENDENTE    *");

            /*" -2258- DISPLAY '*   -------   --------- ------ --------    *' . */
            _.Display($"*   -------   --------- ------ --------    *");

            /*" -2259- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -2260- DISPLAY '*    NAO HA PENDENCIA PARA  A  CONGENERE   *' . */
            _.Display($"*    NAO HA PENDENCIA PARA  A  CONGENERE   *");

            /*" -2261- DISPLAY '*    ATE A DATA DE MOVIMENTOS SOLICITADA.  *' . */
            _.Display($"*    ATE A DATA DE MOVIMENTOS SOLICITADA.  *");

            /*" -2262- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -2262- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2276- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -2278- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -2278- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2282- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2282- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}