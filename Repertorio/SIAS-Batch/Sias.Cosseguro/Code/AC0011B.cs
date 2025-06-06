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
using Sias.Cosseguro.DB2.AC0011B;

namespace Code
{
    public class AC0011B
    {
        public bool IsCall { get; set; }

        public AC0011B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  ADMINISTRACAO DE COSSEGURO         *      */
        /*"      *   PROGRAMA ...............  AC0011B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  GILSON                             *      */
        /*"      *   PROGRAMADOR ............  GILSON                             *      */
        /*"      *   DATA CODIFICACAO .......  JUNHO / 1993                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  ATUALIZAR DB DE COSSEGURO CEDIDO   *      */
        /*"      *                             DOCUMENTOS QUE SEJAM DE CONVENIOS  *      */
        /*"      *                             (ORGAO �= 10).                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V0SISTEMA         INPUT    *      */
        /*"      * HISTORICO PARCELAS                  V1HISTOPARC       INPUT    *      */
        /*"      * APOLICES                            V0APOLICE         INPUT    *      */
        /*"      * ENDOSSOS                            V0ENDOSSO         INPUT    *      */
        /*"      * APOLICE COSSEGURO CEDIDO            V1APOLCOSCED      INPUT    *      */
        /*"      * NR. DE ORDEM COSSEG. CED.           V1ORDECOSCED      INPUT    *      */
        /*"      * COSSEGURO PRODUTO                   V0COSSEGPROD      INPUT    *      */
        /*"      * PARCELAS                            V1PARCELA         INPUT    *      */
        /*"      * ASSIST.24 HORAS DO AUTOMOVEL        V1PARCELA-COMPL   INPUT    *      */
        /*"      * PLANO DE COMISSAO                   V1PLANCOMIS       INPUT    *      */
        /*"      * PREMIOS DE COSSEGURO                V0COSSEG-PREM     I-O      *      */
        /*"      * HISTORICO DE COSSEGURO              V0COSSEG-HISTPRE  I-O      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACOES                                                    *      */
        /*"      *  EM 02.06.95 POR KITA (PROCAS)                                 *      */
        /*"      *  - INCLUSAO DE ROTINA DE VERIFICACAO DE PROCESSAMENTO EM DUPLI *      */
        /*"      *    CIDADE                                                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EM SET/1996 POR CARLOS ALBERTO                                *      */
        /*"      *  - INCLUSAO DA ROTINA PARA RETIRAR O VALOR DE ASSISTENCIA      *      */
        /*"      *    24 HORAS DA DISTRIBUICAO DE COSSEGURO CEDIDO.               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EM ABR/2003 POR CARLOS ALBERTO - PRODUCAR CA0403              *      */
        /*"      *  - INCLUSAO DE CALCULO PARA O CONVENIO VERA CRUZ (ORGAO = 100) *      */
        /*"      *                                                                *      */
        /*"      *    PREMIO-TARIFA-CEDIDO = PREMIO-TARIFA-TOTAL + CUSTO APOLICE  *      */
        /*"      *                         * %PARTICIPACAO (70%) / 100.           *      */
        /*"      *                                                                *      */
        /*"      *    VALOR-DESCONTO-CEDIDO= VALOR-DESCONTO-TOTAL                 *      */
        /*"      *                         * %PARTICIPACAO (70%) / 100.           *      */
        /*"      *                                                                *      */
        /*"      *    VALOR-ADIC-FRAC-CEDID= VALOR-ADIC-FRAC-TOTAL                *      */
        /*"      *                         * %PARTICIPACAO (70%) / 100.           *      */
        /*"      *                                                                *      */
        /*"      *    VALOR-COMISSAO-COSSEG= PREMIO-TARIFA-TOTAL                  *      */
        /*"      *                         * %PARTICIPACAO (70%) / 100            *      */
        /*"      *                         * %COMISSAO-COSSEGURO (35%) / 100.     *      */
        /*"      *                                                                *      */
        /*"      *    VALOR-PRO-LABORE     = PREMIO-TARIFA-TOTAL                  *      */
        /*"      *                         * (100 - %PARTICIPACAO (70%)) / 100    *      */
        /*"      *                         * %PRO-LABORE (10%) / 100.             *      */
        /*"      *                                                                *      */
        /*"      *    VALOR-COMISSAO-COSSEG= VALOR-COMISSAO-COSSEG                *      */
        /*"      *                         - VALOR-PRO-LABORE.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EM JUN/2011 POR GILSON PINTO DA SILVA - PROCURAR GP0611       *      */
        /*"      *  - ALTERACAO PARA TRATAR O NOVO CONVENIO AUTO SAS - ORGAO 110  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO  - ALTERAR O CALCULO DA COMISSAO PARA INTEGRACAO DE  *      */
        /*"      *              COSSEGURO NOS RAMOS 31 E 53.                      *      */
        /*"      * 14/01/2014 - WELLINGTON VERAS  TE39902     PROCURAR POR C91182 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - PREPARAR A COLUNA CODIGO DE EMPRESA PARA RECEBER  *      */
        /*"      *              A INFORMACAO DO CODIGO CORRESPONDENTE             *      */
        /*"      * 04/10/2018 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 173142 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - PREPARAR A ROTINA PARA DESPREZAR OS DOCUMENTOS    *      */
        /*"      *              EMITIDOS ATRAVES DO ORGAO 0300                    *      */
        /*"      * 22/01/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 188194 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          VIND-DAT-QTBC            PIC S9(004)  VALUE +0 COMP.*/
        public IntBasis VIND_DAT_QTBC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          VIND-DTQITBCO            PIC S9(004)  VALUE +0 COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          VIND-OCR-HIST            PIC S9(004)  VALUE +0 COMP.*/
        public IntBasis VIND_OCR_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          VIND-SIT-FINC            PIC S9(004)  VALUE +0 COMP.*/
        public IntBasis VIND_SIT_FINC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          VIND-SIT-LIBR            PIC S9(004)  VALUE +0 COMP.*/
        public IntBasis VIND_SIT_LIBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          VIND-NUM-OCOR            PIC S9(004)  VALUE +0 COMP.*/
        public IntBasis VIND_NUM_OCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WSHOST-QTDE-REG          PIC S9(009)          COMP.*/
        public IntBasis WSHOST_QTDE_REG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          WSHOST-OCORHIST          PIC S9(004)          COMP.*/
        public IntBasis WSHOST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WSHOST-VLCOMIS           PIC S9(013)V99       COMP-3*/
        public DoubleBasis WSHOST_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          WSHOST-VLCOMIS-IX        PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis WSHOST_VLCOMIS_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          WSHOST-SITUACAO          PIC  X(001).*/
        public StringBasis WSHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          WDTLIMITE-COMIS          PIC  X(010)                                     VALUE '1994-12-01'.*/
        public StringBasis WDTLIMITE_COMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"1994-12-01");
        /*"77          V0SIST-DTMOVABE          PIC  X(010).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1HISP-NUM-APOL          PIC S9(013)          COMP-3*/
        public IntBasis V1HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1HISP-NRENDOS           PIC S9(009)          COMP.*/
        public IntBasis V1HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1HISP-NRPARCEL          PIC S9(004)          COMP.*/
        public IntBasis V1HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HISP-OCORHIST          PIC S9(004)          COMP.*/
        public IntBasis V1HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HISP-OPERACAO          PIC S9(004)          COMP.*/
        public IntBasis V1HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HISP-DTMOVTO           PIC  X(010).*/
        public StringBasis V1HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1HISP-PRM-TAR           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V1HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V1HISP-VAL-DES           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V1HISP_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V1HISP-VLADIFRA          PIC S9(013)V99       COMP-3*/
        public DoubleBasis V1HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V1HISP-VLCUSEMI          PIC S9(013)V99       COMP-3*/
        public DoubleBasis V1HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V1HISP-DTQITBCO          PIC  X(010).*/
        public StringBasis V1HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V2HISP-NUM-APOL          PIC S9(013)          COMP-3*/
        public IntBasis V2HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V2HISP-NRENDOS           PIC S9(009)          COMP.*/
        public IntBasis V2HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V2HISP-NRPARCEL          PIC S9(004)          COMP.*/
        public IntBasis V2HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2HISP-OCORHIST          PIC S9(004)          COMP.*/
        public IntBasis V2HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2HISP-OPERACAO          PIC S9(004)          COMP.*/
        public IntBasis V2HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2HISP-DTMOVTO           PIC  X(010).*/
        public StringBasis V2HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V2HISP-PRM-TAR           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V2HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2HISP-VAL-DES           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V2HISP_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2HISP-VLADIFRA          PIC S9(013)V99       COMP-3*/
        public DoubleBasis V2HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2HISP-VLCUSEMI          PIC S9(013)V99       COMP-3*/
        public DoubleBasis V2HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2HISP-DTQITBCO          PIC  X(010).*/
        public StringBasis V2HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V3HISP-NUM-APOL          PIC S9(013)          COMP-3*/
        public IntBasis V3HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V3HISP-NRENDOS           PIC S9(009)          COMP.*/
        public IntBasis V3HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V3HISP-NRPARCEL          PIC S9(004)          COMP.*/
        public IntBasis V3HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V3HISP-OCORHIST          PIC S9(004)          COMP.*/
        public IntBasis V3HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V3HISP-OPERACAO          PIC S9(004)          COMP.*/
        public IntBasis V3HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V3HISP-DTMOVTO           PIC  X(010).*/
        public StringBasis V3HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V3HISP-PRM-TAR           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V3HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V3HISP-VAL-DES           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V3HISP_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V3HISP-VLADIFRA          PIC S9(013)V99       COMP-3*/
        public DoubleBasis V3HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V3HISP-VLCUSEMI          PIC S9(013)V99       COMP-3*/
        public DoubleBasis V3HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0APOL-NUM-APOL          PIC S9(013)          COMP-3*/
        public IntBasis V0APOL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0APOL-ORGAO             PIC S9(004)          COMP.*/
        public IntBasis V0APOL_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0APOL-RAMO              PIC S9(004)          COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0APOL-CODPRODU          PIC S9(004)          COMP.*/
        public IntBasis V0APOL_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0ENDO-NUM-APOL          PIC S9(013)          COMP-3*/
        public IntBasis V0ENDO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0ENDO-NRENDOS           PIC S9(009)          COMP.*/
        public IntBasis V0ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0ENDO-DTEMIS            PIC  X(010).*/
        public StringBasis V0ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0ENDO-DTINIVIG          PIC  X(010).*/
        public StringBasis V0ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0ENDO-DTTERVIG          PIC  X(010).*/
        public StringBasis V0ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0ENDO-CORRECAO          PIC  X(001).*/
        public StringBasis V0ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0ENDO-QTPARCEL          PIC S9(004)          COMP.*/
        public IntBasis V0ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0ENDO-CDFRACIO          PIC S9(004)          COMP.*/
        public IntBasis V0ENDO_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1APCD-NUM-APOL          PIC S9(013)          COMP-3*/
        public IntBasis V1APCD_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1APCD-CODCOSS           PIC S9(004)          COMP.*/
        public IntBasis V1APCD_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1APCD-RAMOFR            PIC S9(004)          COMP.*/
        public IntBasis V1APCD_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1APCD-DTINIVIG          PIC  X(010).*/
        public StringBasis V1APCD_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1APCD-DTTERVIG          PIC  X(010).*/
        public StringBasis V1APCD_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1APCD-PCPARTIC          PIC S9(004)V9(5)     COMP-3*/
        public DoubleBasis V1APCD_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77          V1APCD-PCCOMCOS          PIC S9(003)V99       COMP-3*/
        public DoubleBasis V1APCD_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77          V1ORDC-NUM-APOL          PIC S9(013)          COMP-3*/
        public IntBasis V1ORDC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1ORDC-NRENDOS           PIC S9(009)          COMP.*/
        public IntBasis V1ORDC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1ORDC-COD-COSS          PIC S9(004)          COMP.*/
        public IntBasis V1ORDC_COD_COSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1ORDC-ORD-CEDIDO        PIC S9(015)          COMP-3*/
        public IntBasis V1ORDC_ORD_CEDIDO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77          V0COSP-CODPRODU          PIC S9(004)          COMP.*/
        public IntBasis V0COSP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0COSP-RAMO              PIC S9(004)          COMP.*/
        public IntBasis V0COSP_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0COSP-CONGENER          PIC S9(004)          COMP.*/
        public IntBasis V0COSP_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0COSP-PCPARTIC          PIC S9(004)V9(5)     COMP-3*/
        public DoubleBasis V0COSP_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77          V0COSP-PCCOMCOS          PIC S9(003)V99       COMP-3*/
        public DoubleBasis V0COSP_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77          V0COSP-PCADMCOS          PIC S9(003)V99       COMP-3*/
        public DoubleBasis V0COSP_PCADMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77          V0COSP-DTINIVIG          PIC  X(010).*/
        public StringBasis V0COSP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0COSP-DTTERVIG          PIC  X(010).*/
        public StringBasis V0COSP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1PARC-NUM-APOL          PIC S9(013)          COMP-3*/
        public IntBasis V1PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1PARC-NRENDOS           PIC S9(009)          COMP.*/
        public IntBasis V1PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1PARC-NRPARCEL          PIC S9(004)          COMP.*/
        public IntBasis V1PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1PARC-PRM-TAR           PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V1PARC_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1PARC-VAL-DES           PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V1PARC_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1PARC-OTNADFRA          PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V1PARC_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1PARC-OTNCUSTO          PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V1PARC_OTNCUSTO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2PARC-NUM-APOL          PIC S9(013)          COMP-3*/
        public IntBasis V2PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V2PARC-NRENDOS           PIC S9(009)          COMP.*/
        public IntBasis V2PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V2PARC-NRPARCEL          PIC S9(004)          COMP.*/
        public IntBasis V2PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2PARC-PRM-TAR           PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V2PARC_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2PARC-VAL-DES           PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V2PARC_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2PARC-OTNADFRA          PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V2PARC_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2PARC-OTNCUSTO          PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V2PARC_OTNCUSTO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V3PARC-NUM-APOL          PIC S9(013)          COMP-3*/
        public IntBasis V3PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V3PARC-NRENDOS           PIC S9(009)          COMP.*/
        public IntBasis V3PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V3PARC-NRPARCEL          PIC S9(004)          COMP.*/
        public IntBasis V3PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V3PARC-PRM-TAR           PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V3PARC_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V3PARC-VAL-DES           PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V3PARC_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V3PARC-OTNADFRA          PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V3PARC_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V3PARC-OTNCUSTO          PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V3PARC_OTNCUSTO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1PCOM-NUM-APOL          PIC S9(013)          COMP-3*/
        public IntBasis V1PCOM_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1PCOM-NRENDOS           PIC S9(009)          COMP.*/
        public IntBasis V1PCOM_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1PCOM-NRPARCEL          PIC S9(004)          COMP.*/
        public IntBasis V1PCOM_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1PCOM-VLR-COMPL-IX      PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V1PCOM_VLR_COMPL_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1PCOM-VLR-COMPL         PIC S9(013)V99       COMP-3*/
        public DoubleBasis V1PCOM_VLR_COMPL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2PCOM-NUM-APOL          PIC S9(013)          COMP-3*/
        public IntBasis V2PCOM_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V2PCOM-NRENDOS           PIC S9(009)          COMP.*/
        public IntBasis V2PCOM_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V2PCOM-NRPARCEL          PIC S9(004)          COMP.*/
        public IntBasis V2PCOM_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2PCOM-VLR-COMPL-IX      PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V2PCOM_VLR_COMPL_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2PCOM-VLR-COMPL         PIC S9(013)V99       COMP-3*/
        public DoubleBasis V2PCOM_VLR_COMPL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V1PLCO-COD-EMPR          PIC S9(009)          COMP.*/
        public IntBasis V1PLCO_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1PLCO-CDFRACIO          PIC S9(004)          COMP.*/
        public IntBasis V1PLCO_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1PLCO-NRPARCEL          PIC S9(004)          COMP.*/
        public IntBasis V1PLCO_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1PLCO-PCCOMSEG          PIC S9(003)V99       COMP-3*/
        public DoubleBasis V1PLCO_PCCOMSEG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77          V1PLCO-SITUACAO          PIC  X(001).*/
        public StringBasis V1PLCO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CPRE-COD-EMPR          PIC S9(009)          COMP.*/
        public IntBasis V0CPRE_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0CPRE-TIPSGU            PIC  X(001).*/
        public StringBasis V0CPRE_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CPRE-CONGENER          PIC S9(004)          COMP.*/
        public IntBasis V0CPRE_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CPRE-NUM-ORDEM         PIC S9(015)          COMP-3*/
        public IntBasis V0CPRE_NUM_ORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77          V0CPRE-NUM-APOL          PIC S9(013)          COMP-3*/
        public IntBasis V0CPRE_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0CPRE-NRENDOS           PIC S9(009)          COMP.*/
        public IntBasis V0CPRE_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0CPRE-NRPARCEL          PIC S9(004)          COMP.*/
        public IntBasis V0CPRE_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CPRE-PRM-TAR-IX        PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V0CPRE_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0CPRE-VAL-DES-IX        PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V0CPRE_VAL_DES_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0CPRE-OTNPRLIQ          PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V0CPRE_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0CPRE-OTNADFRA          PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V0CPRE_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0CPRE-VLCOMISIX         PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V0CPRE_VLCOMISIX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0CPRE-OTNTOTAL          PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V0CPRE_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0CPRE-SITUACAO          PIC  X(001).*/
        public StringBasis V0CPRE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CPRE-SIT-CONG          PIC  X(001).*/
        public StringBasis V0CPRE_SIT_CONG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CPRE-TIMESTAMP         PIC  X(026).*/
        public StringBasis V0CPRE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77          V0CPRE-OCORHIST          PIC S9(004)          COMP.*/
        public IntBasis V0CPRE_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CPRE-COD-EMPR          PIC S9(009)          COMP.*/
        public IntBasis V2CPRE_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V2CPRE-TIPSGU            PIC  X(001).*/
        public StringBasis V2CPRE_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CPRE-CONGENER          PIC S9(004)          COMP.*/
        public IntBasis V2CPRE_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CPRE-NUM-ORDEM         PIC S9(015)          COMP-3*/
        public IntBasis V2CPRE_NUM_ORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77          V2CPRE-NUM-APOL          PIC S9(013)          COMP-3*/
        public IntBasis V2CPRE_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V2CPRE-NRENDOS           PIC S9(009)          COMP.*/
        public IntBasis V2CPRE_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V2CPRE-NRPARCEL          PIC S9(004)          COMP.*/
        public IntBasis V2CPRE_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CPRE-PRM-TAR-IX        PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V2CPRE_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2CPRE-VAL-DES-IX        PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V2CPRE_VAL_DES_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2CPRE-OTNPRLIQ          PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V2CPRE_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2CPRE-OTNADFRA          PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V2CPRE_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2CPRE-VLCOMISIX         PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V2CPRE_VLCOMISIX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2CPRE-OTNTOTAL          PIC S9(010)V9(5)     COMP-3*/
        public DoubleBasis V2CPRE_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2CPRE-SITUACAO          PIC  X(001).*/
        public StringBasis V2CPRE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CPRE-SIT-CONG          PIC  X(001).*/
        public StringBasis V2CPRE_SIT_CONG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CPRE-TIMESTAMP         PIC  X(026).*/
        public StringBasis V2CPRE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77          V2CPRE-OCORHIST          PIC S9(004)          COMP.*/
        public IntBasis V2CPRE_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHIS-COD-EMPR          PIC S9(009)          COMP.*/
        public IntBasis V0CHIS_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0CHIS-TIPSGU            PIC  X(001).*/
        public StringBasis V0CHIS_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CHIS-CONGENER          PIC S9(004)          COMP.*/
        public IntBasis V0CHIS_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHIS-NUM-APOL          PIC S9(013)          COMP-3*/
        public IntBasis V0CHIS_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0CHIS-NRENDOS           PIC S9(009)          COMP.*/
        public IntBasis V0CHIS_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0CHIS-NRPARCEL          PIC S9(004)          COMP.*/
        public IntBasis V0CHIS_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHIS-OCORHIST          PIC S9(004)          COMP.*/
        public IntBasis V0CHIS_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHIS-OPERACAO          PIC S9(004)          COMP.*/
        public IntBasis V0CHIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHIS-NUMOCOR           PIC S9(004)          COMP.*/
        public IntBasis V0CHIS_NUMOCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHIS-DTMOVTO           PIC  X(010).*/
        public StringBasis V0CHIS_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0CHIS-PRM-TAR           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V0CHIS_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0CHIS-VAL-DES           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V0CHIS_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0CHIS-VLPRMLIQ          PIC S9(013)V99       COMP-3*/
        public DoubleBasis V0CHIS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0CHIS-VLADIFRA          PIC S9(013)V99       COMP-3*/
        public DoubleBasis V0CHIS_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0CHIS-VLCOMIS           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V0CHIS_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0CHIS-VLPRMTOT          PIC S9(013)V99       COMP-3*/
        public DoubleBasis V0CHIS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0CHIS-TIMESTAMP         PIC  X(026).*/
        public StringBasis V0CHIS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77          V0CHIS-DTQITBCO          PIC  X(010).*/
        public StringBasis V0CHIS_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0CHIS-SIT-FINANC        PIC  X(001).*/
        public StringBasis V0CHIS_SIT_FINANC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CHIS-SIT-LIBRECUP      PIC  X(001).*/
        public StringBasis V0CHIS_SIT_LIBRECUP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CHIS-COD-EMPR          PIC S9(009)          COMP.*/
        public IntBasis V2CHIS_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V2CHIS-TIPSGU            PIC  X(001).*/
        public StringBasis V2CHIS_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CHIS-CONGENER          PIC S9(004)          COMP.*/
        public IntBasis V2CHIS_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CHIS-NUM-APOL          PIC S9(013)          COMP-3*/
        public IntBasis V2CHIS_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V2CHIS-NRENDOS           PIC S9(009)          COMP.*/
        public IntBasis V2CHIS_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V2CHIS-NRPARCEL          PIC S9(004)          COMP.*/
        public IntBasis V2CHIS_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CHIS-OCORHIST          PIC S9(004)          COMP.*/
        public IntBasis V2CHIS_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CHIS-OPERACAO          PIC S9(004)          COMP.*/
        public IntBasis V2CHIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CHIS-NUMOCOR           PIC S9(004)          COMP.*/
        public IntBasis V2CHIS_NUMOCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CHIS-DTMOVTO           PIC  X(010).*/
        public StringBasis V2CHIS_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V2CHIS-PRM-TAR           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V2CHIS_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2CHIS-VAL-DES           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V2CHIS_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2CHIS-VLPRMLIQ          PIC S9(013)V99       COMP-3*/
        public DoubleBasis V2CHIS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2CHIS-VLADIFRA          PIC S9(013)V99       COMP-3*/
        public DoubleBasis V2CHIS_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2CHIS-VLCOMIS           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V2CHIS_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2CHIS-VLPRMTOT          PIC S9(013)V99       COMP-3*/
        public DoubleBasis V2CHIS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2CHIS-TIMESTAMP         PIC  X(026).*/
        public StringBasis V2CHIS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77          V2CHIS-DTQITBCO          PIC  X(010).*/
        public StringBasis V2CHIS_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V2CHIS-SIT-FINANC        PIC  X(001).*/
        public StringBasis V2CHIS_SIT_FINANC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CHIS-SIT-LIBRECUP      PIC  X(001).*/
        public StringBasis V2CHIS_SIT_LIBRECUP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V3CHIS-TIPSGU            PIC  X(001).*/
        public StringBasis V3CHIS_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V3CHIS-CONGENER          PIC S9(004)          COMP.*/
        public IntBasis V3CHIS_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V3CHIS-NUM-APOL          PIC S9(013)          COMP-3*/
        public IntBasis V3CHIS_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V3CHIS-NRENDOS           PIC S9(009)          COMP.*/
        public IntBasis V3CHIS_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V3CHIS-NRPARCEL          PIC S9(004)          COMP.*/
        public IntBasis V3CHIS_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V3CHIS-OCORHIST          PIC S9(004)          COMP.*/
        public IntBasis V3CHIS_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V3CHIS-NUMOCOR           PIC S9(004)          COMP.*/
        public IntBasis V3CHIS_NUMOCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V3CHIS-DTMOVTO           PIC  X(010).*/
        public StringBasis V3CHIS_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V3CHIS-OPERACAO          PIC S9(004)          COMP.*/
        public IntBasis V3CHIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V3CHIS-PRM-TAR           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V3CHIS_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V3CHIS-VAL-DES           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V3CHIS_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V3CHIS-VLPRMLIQ          PIC S9(013)V99       COMP-3*/
        public DoubleBasis V3CHIS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V3CHIS-VLADIFRA          PIC S9(013)V99       COMP-3*/
        public DoubleBasis V3CHIS_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V3CHIS-VLCOMIS           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V3CHIS_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V3CHIS-VLPRMTOT          PIC S9(013)V99       COMP-3*/
        public DoubleBasis V3CHIS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          TABELA-COSSEGURO.*/
        public AC0011B_TABELA_COSSEGURO TABELA_COSSEGURO { get; set; } = new AC0011B_TABELA_COSSEGURO();
        public class AC0011B_TABELA_COSSEGURO : VarBasis
        {
            /*"  05        TABL-COSSEGURO      OCCURS   300   TIMES.*/
            public ListBasis<AC0011B_TABL_COSSEGURO> TABL_COSSEGURO { get; set; } = new ListBasis<AC0011B_TABL_COSSEGURO>(300);
            public class AC0011B_TABL_COSSEGURO : VarBasis
            {
                /*"    10      WCODCOSS            PIC  9(004).*/
                public IntBasis WCODCOSS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      WORD-CEDIDO         PIC  9(015).*/
                public IntBasis WORD_CEDIDO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10      WPCPARTIC           PIC  9(004)V9(5).*/
                public DoubleBasis WPCPARTIC { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(5)."), 5);
                /*"    10      WPCCOMCOS           PIC  9(003)V9(2).*/
                public DoubleBasis WPCCOMCOS { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V9(2)."), 2);
                /*"    10      WPCADMCOS           PIC  9(003)V9(2).*/
                public DoubleBasis WPCADMCOS { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V9(2)."), 2);
                /*"01          AREA-DE-WORK.*/
            }
        }
        public AC0011B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0011B_AREA_DE_WORK();
        public class AC0011B_AREA_DE_WORK : VarBasis
        {
            /*"  05        WIND                PIC  9(003)       VALUE ZEROS.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05        WTEM-COMIS-ACELER   PIC  X(001)       VALUE SPACES.*/
            public StringBasis WTEM_COMIS_ACELER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WTEM-ASSIST-24HS    PIC  X(001)       VALUE SPACES.*/
            public StringBasis WTEM_ASSIST_24HS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WFIM-EXECUCAO       PIC  X(001)       VALUE SPACES.*/
            public StringBasis WFIM_EXECUCAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WFIM-V1HISTOPARC    PIC  X(001)       VALUE SPACES.*/
            public StringBasis WFIM_V1HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WFIM-V1APOLCOSCED   PIC  X(001)       VALUE SPACES.*/
            public StringBasis WFIM_V1APOLCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WFIM-V2HISTOPARC    PIC  X(001)       VALUE SPACES.*/
            public StringBasis WFIM_V2HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        AC-L-V1HISTOPARC    PIC  9(007)       VALUE ZEROS.*/
            public IntBasis AC_L_V1HISTOPARC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-U-V0COSSEGPREM   PIC  9(007)       VALUE ZEROS.*/
            public IntBasis AC_U_V0COSSEGPREM { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-I-V0COSSEGPREM   PIC  9(007)       VALUE ZEROS.*/
            public IntBasis AC_I_V0COSSEGPREM { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-I-V0COSSEGHISP   PIC  9(007)       VALUE ZEROS.*/
            public IntBasis AC_I_V0COSSEGHISP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        WPROP-VLADIFRA      PIC  9(007)V9(10) VALUE 0 COMP-3*/
            public DoubleBasis WPROP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("9", "7", "9(007)V9(10)"), 10);
            /*"  05        WPROP-VAL-DES       PIC  9(007)V9(10) VALUE 0 COMP-3*/
            public DoubleBasis WPROP_VAL_DES { get; set; } = new DoubleBasis(new PIC("9", "7", "9(007)V9(10)"), 10);
            /*"  05        WPROPORCAO          PIC  9(007)V9(10) VALUE 0 COMP-3*/
            public DoubleBasis WPROPORCAO { get; set; } = new DoubleBasis(new PIC("9", "7", "9(007)V9(10)"), 10);
            /*"  05        WS-PRMTAR-LID       PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WS_PRMTAR_LID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05        WS-PRMTAR-LID-IX    PIC S9(010)V9(5) VALUE +0 COMP-3*/
            public DoubleBasis WS_PRMTAR_LID_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05        WS-VLCUSEMI         PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WS_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05        WS-VLCUSEMI-IX      PIC S9(010)V9(5) VALUE +0 COMP-3*/
            public DoubleBasis WS_VLCUSEMI_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05        WS-VLCOMCOS         PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WS_VLCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05        WS-VLCOMCOS-IX      PIC S9(010)V9(5) VALUE +0 COMP-3*/
            public DoubleBasis WS_VLCOMCOS_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05        WS-PRO-LABORE       PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WS_PRO_LABORE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05        WS-PRO-LABORE-IX    PIC S9(010)V9(5) VALUE +0 COMP-3*/
            public DoubleBasis WS_PRO_LABORE_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05        WNUM-APOL-ANT       PIC S9(013)      VALUE +0 COMP-3*/
            public IntBasis WNUM_APOL_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05        WNUM-ENDS-ANT       PIC S9(009)      VALUE +0 COMP.*/
            public IntBasis WNUM_ENDS_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05        WOPERACAO           PIC  9(004)       VALUE ZEROS.*/
            public IntBasis WOPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05        FILLER              REDEFINES         WOPERACAO.*/
            private _REDEF_AC0011B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_AC0011B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_AC0011B_FILLER_0(); _.Move(WOPERACAO, _filler_0); VarBasis.RedefinePassValue(WOPERACAO, _filler_0, WOPERACAO); _filler_0.ValueChanged += () => { _.Move(_filler_0, WOPERACAO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WOPERACAO); }
            }  //Redefines
            public class _REDEF_AC0011B_FILLER_0 : VarBasis
            {
                /*"    10      WTIPO-OPERACAO      PIC  9(002).*/
                public IntBasis WTIPO_OPERACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  9(002).*/
                public IntBasis FILLER_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        W2OPERACAO          PIC  9(004)       VALUE ZEROS.*/

                public _REDEF_AC0011B_FILLER_0()
                {
                    WTIPO_OPERACAO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W2OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05        FILLER              REDEFINES         W2OPERACAO.*/
            private _REDEF_AC0011B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_AC0011B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_AC0011B_FILLER_2(); _.Move(W2OPERACAO, _filler_2); VarBasis.RedefinePassValue(W2OPERACAO, _filler_2, W2OPERACAO); _filler_2.ValueChanged += () => { _.Move(_filler_2, W2OPERACAO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, W2OPERACAO); }
            }  //Redefines
            public class _REDEF_AC0011B_FILLER_2 : VarBasis
            {
                /*"    10      W2TIPO-OPERACAO     PIC  9(002).*/
                public IntBasis W2TIPO_OPERACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  9(002).*/
                public IntBasis FILLER_3 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WDATA-AUX           PIC  X(010)    VALUE SPACES.*/

                public _REDEF_AC0011B_FILLER_2()
                {
                    W2TIPO_OPERACAO.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER              REDEFINES      WDATA-AUX.*/
            private _REDEF_AC0011B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_AC0011B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_AC0011B_FILLER_4(); _.Move(WDATA_AUX, _filler_4); VarBasis.RedefinePassValue(WDATA_AUX, _filler_4, WDATA_AUX); _filler_4.ValueChanged += () => { _.Move(_filler_4, WDATA_AUX); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WDATA_AUX); }
            }  //Redefines
            public class _REDEF_AC0011B_FILLER_4 : VarBasis
            {
                /*"    10      WDAT-AUX-ANO        PIC  9(004).*/
                public IntBasis WDAT_AUX_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-AUX-MES        PIC  9(002).*/
                public IntBasis WDAT_AUX_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-AUX-DIA        PIC  9(002).*/
                public IntBasis WDAT_AUX_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WDATA-EDIT.*/

                public _REDEF_AC0011B_FILLER_4()
                {
                    WDAT_AUX_ANO.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WDAT_AUX_MES.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    WDAT_AUX_DIA.ValueChanged += OnValueChanged;
                }

            }
            public AC0011B_WDATA_EDIT WDATA_EDIT { get; set; } = new AC0011B_WDATA_EDIT();
            public class AC0011B_WDATA_EDIT : VarBasis
            {
                /*"    10      WDIA-EDIT           PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDIA_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WMES-EDIT           PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WMES_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WANO-EDIT           PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WANO_EDIT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05        WHORA-ACCEPT.*/
            }
            public AC0011B_WHORA_ACCEPT WHORA_ACCEPT { get; set; } = new AC0011B_WHORA_ACCEPT();
            public class AC0011B_WHORA_ACCEPT : VarBasis
            {
                /*"    10      WHH-ACCEPT          PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WHH_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WMM-ACCEPT          PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WMM_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WSS-ACCEPT          PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WSS_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WCC-ACCEPT          PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WCC_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        WHORA-EDIT.*/
            }
            public AC0011B_WHORA_EDIT WHORA_EDIT { get; set; } = new AC0011B_WHORA_EDIT();
            public class AC0011B_WHORA_EDIT : VarBasis
            {
                /*"    10      WHH-EDIT            PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHH_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)    VALUE ':'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10      WMM-EDIT            PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WMM_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)    VALUE ':'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10      WSS-EDIT            PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WSS_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01          WABEND.*/
            }
        }
        public AC0011B_WABEND WABEND { get; set; } = new AC0011B_WABEND();
        public class AC0011B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(008) VALUE 'AC0011B '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"AC0011B ");
            /*"  05        FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05        FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public AC0011B_V1HISTOPARC V1HISTOPARC { get; set; } = new AC0011B_V1HISTOPARC();
        public AC0011B_V1APOLCOSCED V1APOLCOSCED { get; set; } = new AC0011B_V1APOLCOSCED();
        public AC0011B_V2HISTOPARC V2HISTOPARC { get; set; } = new AC0011B_V2HISTOPARC();
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
            /*" -524- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -525- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -528- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -531- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -535- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -537- MOVE ZEROS TO WSHOST-QTDE-REG. */
            _.Move(0, WSHOST_QTDE_REG);

            /*" -539- PERFORM R0200-00-CHECA-EXECUCAO. */

            R0200_00_CHECA_EXECUCAO_SECTION();

            /*" -540- IF WFIM-EXECUCAO = 'S' */

            if (AREA_DE_WORK.WFIM_EXECUCAO == "S")
            {

                /*" -541- DISPLAY 'AC0011B - DUPLICIDADE DE PROCESSAMENTO' */
                _.Display($"AC0011B - DUPLICIDADE DE PROCESSAMENTO");

                /*" -543- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -544- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -545- MOVE WHH-ACCEPT TO WHH-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WHH_EDIT);

            /*" -546- MOVE WMM-ACCEPT TO WMM-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WMM_EDIT);

            /*" -547- MOVE WSS-ACCEPT TO WSS-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WSS_EDIT);

            /*" -549- DISPLAY 'INICIO DECLARE V1HISTOPARC - ' WHORA-EDIT. */
            _.Display($"INICIO DECLARE V1HISTOPARC - {AREA_DE_WORK.WHORA_EDIT}");

            /*" -551- PERFORM R0500-00-DECLARE-V1HISTOPARC. */

            R0500_00_DECLARE_V1HISTOPARC_SECTION();

            /*" -552- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -553- MOVE WHH-ACCEPT TO WHH-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WHH_EDIT);

            /*" -554- MOVE WMM-ACCEPT TO WMM-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WMM_EDIT);

            /*" -555- MOVE WSS-ACCEPT TO WSS-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WSS_EDIT);

            /*" -557- DISPLAY 'FINAL  DECLARE V1HISTOPARC - ' WHORA-EDIT. */
            _.Display($"FINAL  DECLARE V1HISTOPARC - {AREA_DE_WORK.WHORA_EDIT}");

            /*" -559- PERFORM R0550-00-FETCH-V1HISTOPARC. */

            R0550_00_FETCH_V1HISTOPARC_SECTION();

            /*" -560- IF WFIM-V1HISTOPARC NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1HISTOPARC.IsEmpty())
            {

                /*" -561- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -562- ELSE */
            }
            else
            {


                /*" -563- PERFORM R0700-00-PROCESSA-REGISTRO UNTIL WFIM-V1HISTOPARC NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V1HISTOPARC.IsEmpty()))
                {

                    R0700_00_PROCESSA_REGISTRO_SECTION();
                }
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -568- DISPLAY 'HISTORICOS LIDOS           ' AC-L-V1HISTOPARC. */
            _.Display($"HISTORICOS LIDOS           {AREA_DE_WORK.AC_L_V1HISTOPARC}");

            /*" -569- DISPLAY 'PREMIOS COSSEG ATUALIZADOS ' AC-U-V0COSSEGPREM. */
            _.Display($"PREMIOS COSSEG ATUALIZADOS {AREA_DE_WORK.AC_U_V0COSSEGPREM}");

            /*" -570- DISPLAY 'DOCUMENTOS INSERIDOS :     ' . */
            _.Display($"DOCUMENTOS INSERIDOS :     ");

            /*" -571- DISPLAY ' . PREMIOS    COSSEGURO    ' AC-I-V0COSSEGPREM. */
            _.Display($" . PREMIOS    COSSEGURO    {AREA_DE_WORK.AC_I_V0COSSEGPREM}");

            /*" -573- DISPLAY ' . HISTORICOS COSSEGURO    ' AC-I-V0COSSEGHISP. */
            _.Display($" . HISTORICOS COSSEGURO    {AREA_DE_WORK.AC_I_V0COSSEGHISP}");

            /*" -575- DISPLAY '*---*   AC0011B  -  FIM NORMAL   *---*' . */
            _.Display($"*---*   AC0011B  -  FIM NORMAL   *---*");

            /*" -575- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -579- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -579- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -592- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -597- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -600- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -601- DISPLAY 'R0100 - ERRO NO SELECT DA V0SISTEMA' */
                _.Display($"R0100 - ERRO NO SELECT DA V0SISTEMA");

                /*" -602- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -603- ELSE */
            }
            else
            {


                /*" -604- DISPLAY 'DATA DO SISTEMA AC - ' V0SIST-DTMOVABE UPON CONSOLE. */
                _.Display($"DATA DO SISTEMA AC - {V0SIST_DTMOVABE}");
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -597- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'AC' END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-CHECA-EXECUCAO-SECTION */
        private void R0200_00_CHECA_EXECUCAO_SECTION()
        {
            /*" -617- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -629- PERFORM R0200_00_CHECA_EXECUCAO_DB_SELECT_1 */

            R0200_00_CHECA_EXECUCAO_DB_SELECT_1();

            /*" -632- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -633- DISPLAY 'R0200 - ERRO NO SELECT DA V1COSSEG-HISTPRE' */
                _.Display($"R0200 - ERRO NO SELECT DA V1COSSEG-HISTPRE");

                /*" -634- DISPLAY 'DT MOVTO - ' V0SIST-DTMOVABE */
                _.Display($"DT MOVTO - {V0SIST_DTMOVABE}");

                /*" -635- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -636- ELSE */
            }
            else
            {


                /*" -637- IF WSHOST-QTDE-REG = ZEROS */

                if (WSHOST_QTDE_REG == 00)
                {

                    /*" -638- MOVE SPACES TO WFIM-EXECUCAO */
                    _.Move("", AREA_DE_WORK.WFIM_EXECUCAO);

                    /*" -639- ELSE */
                }
                else
                {


                    /*" -639- MOVE 'S' TO WFIM-EXECUCAO. */
                    _.Move("S", AREA_DE_WORK.WFIM_EXECUCAO);
                }

            }


        }

        [StopWatch]
        /*" R0200-00-CHECA-EXECUCAO-DB-SELECT-1 */
        public void R0200_00_CHECA_EXECUCAO_DB_SELECT_1()
        {
            /*" -629- EXEC SQL SELECT COUNT(*) INTO :WSHOST-QTDE-REG FROM SEGUROS.V1COSSEG_HISTPRE A, SEGUROS.V0APOLICE B WHERE A.DTMOVTO = :V0SIST-DTMOVABE AND A.TIPSGU = '1' AND A.OPERACAO < 0600 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.TIPSGU = '1' AND B.ORGAO NOT IN (0010,0300) END-EXEC. */

            var r0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1 = new R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1()
            {
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
            };

            var executed_1 = R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1.Execute(r0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WSHOST_QTDE_REG, WSHOST_QTDE_REG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-DECLARE-V1HISTOPARC-SECTION */
        private void R0500_00_DECLARE_V1HISTOPARC_SECTION()
        {
            /*" -652- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -681- PERFORM R0500_00_DECLARE_V1HISTOPARC_DB_DECLARE_1 */

            R0500_00_DECLARE_V1HISTOPARC_DB_DECLARE_1();

            /*" -683- PERFORM R0500_00_DECLARE_V1HISTOPARC_DB_OPEN_1 */

            R0500_00_DECLARE_V1HISTOPARC_DB_OPEN_1();

            /*" -686- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -687- DISPLAY 'R0500 - ERRO NO DECLARE DA V1HISTOPARC' */
                _.Display($"R0500 - ERRO NO DECLARE DA V1HISTOPARC");

                /*" -688- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -689- ELSE */
            }
            else
            {


                /*" -689- MOVE SPACES TO WFIM-V1HISTOPARC. */
                _.Move("", AREA_DE_WORK.WFIM_V1HISTOPARC);
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-V1HISTOPARC-DB-DECLARE-1 */
        public void R0500_00_DECLARE_V1HISTOPARC_DB_DECLARE_1()
        {
            /*" -681- EXEC SQL DECLARE V1HISTOPARC CURSOR FOR SELECT A.NUM_APOLICE , A.NRENDOS , A.NRPARCEL , A.OCORHIST , A.OPERACAO , A.DTMOVTO , A.PRM_TARIFARIO , A.VAL_DESCONTO , A.VLADIFRA , A.VLCUSEMI , A.DTQITBCO , B.ORGAO , B.RAMO , B.CODPRODU FROM SEGUROS.V1HISTOPARC A, SEGUROS.V0APOLICE B WHERE A.DTMOVTO = :V0SIST-DTMOVABE AND A.OPERACAO < 0900 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.PCTCED > 0 AND B.ORGAO NOT IN (0010,0300) AND B.TIPSGU = '1' ORDER BY A.NUM_APOLICE , A.NRENDOS , A.NRPARCEL , A.OCORHIST END-EXEC. */
            V1HISTOPARC = new AC0011B_V1HISTOPARC(true);
            string GetQuery_V1HISTOPARC()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.OCORHIST
							, 
							A.OPERACAO
							, 
							A.DTMOVTO
							, 
							A.PRM_TARIFARIO
							, 
							A.VAL_DESCONTO
							, 
							A.VLADIFRA
							, 
							A.VLCUSEMI
							, 
							A.DTQITBCO
							, 
							B.ORGAO
							, 
							B.RAMO
							, 
							B.CODPRODU 
							FROM SEGUROS.V1HISTOPARC A
							, 
							SEGUROS.V0APOLICE B 
							WHERE A.DTMOVTO = '{V0SIST_DTMOVABE}' 
							AND A.OPERACAO < 0900 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.PCTCED > 0 
							AND B.ORGAO NOT IN (0010
							,0300) 
							AND B.TIPSGU = '1' 
							ORDER BY 
							A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.OCORHIST";

                return query;
            }
            V1HISTOPARC.GetQueryEvent += GetQuery_V1HISTOPARC;

        }

        [StopWatch]
        /*" R0500-00-DECLARE-V1HISTOPARC-DB-OPEN-1 */
        public void R0500_00_DECLARE_V1HISTOPARC_DB_OPEN_1()
        {
            /*" -683- EXEC SQL OPEN V1HISTOPARC END-EXEC. */

            V1HISTOPARC.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1APOLCOSCED-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V1APOLCOSCED_DB_DECLARE_1()
        {
            /*" -845- EXEC SQL DECLARE V1APOLCOSCED CURSOR FOR SELECT CODCOSS , PCPARTIC , PCCOMCOS FROM SEGUROS.V1APOLCOSCED WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND DTINIVIG <= :V0ENDO-DTINIVIG AND DTTERVIG >= :V0ENDO-DTINIVIG END-EXEC. */
            V1APOLCOSCED = new AC0011B_V1APOLCOSCED(true);
            string GetQuery_V1APOLCOSCED()
            {
                var query = @$"SELECT CODCOSS
							, 
							PCPARTIC
							, 
							PCCOMCOS 
							FROM SEGUROS.V1APOLCOSCED 
							WHERE NUM_APOLICE = '{V1HISP_NUM_APOL}' 
							AND DTINIVIG <= '{V0ENDO_DTINIVIG}' 
							AND DTTERVIG >= '{V0ENDO_DTINIVIG}'";

                return query;
            }
            V1APOLCOSCED.GetQueryEvent += GetQuery_V1APOLCOSCED;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-FETCH-V1HISTOPARC-SECTION */
        private void R0550_00_FETCH_V1HISTOPARC_SECTION()
        {
            /*" -700- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0550_10_LER_V1HISTOPARC */

            R0550_10_LER_V1HISTOPARC();

        }

        [StopWatch]
        /*" R0550-10-LER-V1HISTOPARC */
        private void R0550_10_LER_V1HISTOPARC(bool isPerform = false)
        {
            /*" -719- PERFORM R0550_10_LER_V1HISTOPARC_DB_FETCH_1 */

            R0550_10_LER_V1HISTOPARC_DB_FETCH_1();

            /*" -722- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -723- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -724- MOVE 'S' TO WFIM-V1HISTOPARC */
                    _.Move("S", AREA_DE_WORK.WFIM_V1HISTOPARC);

                    /*" -724- PERFORM R0550_10_LER_V1HISTOPARC_DB_CLOSE_1 */

                    R0550_10_LER_V1HISTOPARC_DB_CLOSE_1();

                    /*" -726- GO TO R0550-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/ //GOTO
                    return;

                    /*" -727- ELSE */
                }
                else
                {


                    /*" -728- DISPLAY 'R0550 - ERRO NO FETCH DA V1HISTOPARC' */
                    _.Display($"R0550 - ERRO NO FETCH DA V1HISTOPARC");

                    /*" -729- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -730- END-IF */
                }


                /*" -731- ELSE */
            }
            else
            {


                /*" -732- IF VIND-DAT-QTBC < ZEROS */

                if (VIND_DAT_QTBC < 00)
                {

                    /*" -733- MOVE SPACES TO V1HISP-DTQITBCO */
                    _.Move("", V1HISP_DTQITBCO);

                    /*" -734- END-IF */
                }


                /*" -736- END-IF. */
            }


            /*" -738- MOVE V1HISP-OPERACAO TO WOPERACAO. */
            _.Move(V1HISP_OPERACAO, AREA_DE_WORK.WOPERACAO);

            /*" -739- IF WTIPO-OPERACAO = 06 OR 07 */

            if (AREA_DE_WORK.FILLER_0.WTIPO_OPERACAO.In("06", "07"))
            {

                /*" -740- GO TO R0550-10-LER-V1HISTOPARC */
                new Task(() => R0550_10_LER_V1HISTOPARC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -741- ELSE */
            }
            else
            {


                /*" -742- MOVE ZEROS TO WSHOST-OCORHIST */
                _.Move(0, WSHOST_OCORHIST);

                /*" -743- ADD 1 TO AC-L-V1HISTOPARC */
                AREA_DE_WORK.AC_L_V1HISTOPARC.Value = AREA_DE_WORK.AC_L_V1HISTOPARC + 1;

                /*" -743- END-IF. */
            }


        }

        [StopWatch]
        /*" R0550-10-LER-V1HISTOPARC-DB-FETCH-1 */
        public void R0550_10_LER_V1HISTOPARC_DB_FETCH_1()
        {
            /*" -719- EXEC SQL FETCH V1HISTOPARC INTO :V1HISP-NUM-APOL , :V1HISP-NRENDOS , :V1HISP-NRPARCEL , :V1HISP-OCORHIST , :V1HISP-OPERACAO , :V1HISP-DTMOVTO , :V1HISP-PRM-TAR , :V1HISP-VAL-DES , :V1HISP-VLADIFRA , :V1HISP-VLCUSEMI , :V1HISP-DTQITBCO:VIND-DAT-QTBC , :V0APOL-ORGAO , :V0APOL-RAMO , :V0APOL-CODPRODU END-EXEC. */

            if (V1HISTOPARC.Fetch())
            {
                _.Move(V1HISTOPARC.V1HISP_NUM_APOL, V1HISP_NUM_APOL);
                _.Move(V1HISTOPARC.V1HISP_NRENDOS, V1HISP_NRENDOS);
                _.Move(V1HISTOPARC.V1HISP_NRPARCEL, V1HISP_NRPARCEL);
                _.Move(V1HISTOPARC.V1HISP_OCORHIST, V1HISP_OCORHIST);
                _.Move(V1HISTOPARC.V1HISP_OPERACAO, V1HISP_OPERACAO);
                _.Move(V1HISTOPARC.V1HISP_DTMOVTO, V1HISP_DTMOVTO);
                _.Move(V1HISTOPARC.V1HISP_PRM_TAR, V1HISP_PRM_TAR);
                _.Move(V1HISTOPARC.V1HISP_VAL_DES, V1HISP_VAL_DES);
                _.Move(V1HISTOPARC.V1HISP_VLADIFRA, V1HISP_VLADIFRA);
                _.Move(V1HISTOPARC.V1HISP_VLCUSEMI, V1HISP_VLCUSEMI);
                _.Move(V1HISTOPARC.V1HISP_DTQITBCO, V1HISP_DTQITBCO);
                _.Move(V1HISTOPARC.VIND_DAT_QTBC, VIND_DAT_QTBC);
                _.Move(V1HISTOPARC.V0APOL_ORGAO, V0APOL_ORGAO);
                _.Move(V1HISTOPARC.V0APOL_RAMO, V0APOL_RAMO);
                _.Move(V1HISTOPARC.V0APOL_CODPRODU, V0APOL_CODPRODU);
            }

        }

        [StopWatch]
        /*" R0550-10-LER-V1HISTOPARC-DB-CLOSE-1 */
        public void R0550_10_LER_V1HISTOPARC_DB_CLOSE_1()
        {
            /*" -724- EXEC SQL CLOSE V1HISTOPARC END-EXEC */

            V1HISTOPARC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-PROCESSA-REGISTRO-SECTION */
        private void R0700_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -756- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WABEND.WNR_EXEC_SQL);

            /*" -758- INITIALIZE TABELA-COSSEGURO. */
            _.Initialize(
                TABELA_COSSEGURO
            );

            /*" -760- MOVE ZEROS TO WIND. */
            _.Move(0, AREA_DE_WORK.WIND);

            /*" -761- MOVE V1HISP-NUM-APOL TO WNUM-APOL-ANT. */
            _.Move(V1HISP_NUM_APOL, AREA_DE_WORK.WNUM_APOL_ANT);

            /*" -763- MOVE V1HISP-NRENDOS TO WNUM-ENDS-ANT. */
            _.Move(V1HISP_NRENDOS, AREA_DE_WORK.WNUM_ENDS_ANT);

            /*" -765- PERFORM R0800-00-SELECT-V0ENDOSSO. */

            R0800_00_SELECT_V0ENDOSSO_SECTION();

            /*" -767- PERFORM R0900-00-DECLARE-V1APOLCOSCED. */

            R0900_00_DECLARE_V1APOLCOSCED_SECTION();

            /*" -769- PERFORM R0950-00-FETCH-V1APOLCOSCED. */

            R0950_00_FETCH_V1APOLCOSCED_SECTION();

            /*" -770- IF WFIM-V1APOLCOSCED NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1APOLCOSCED.IsEmpty())
            {

                /*" -771- DISPLAY 'R0700 - NAO EXISTE DISTRIBUICAO DE COSSEGURO' */
                _.Display($"R0700 - NAO EXISTE DISTRIBUICAO DE COSSEGURO");

                /*" -772- DISPLAY '        PARA A APOLICE:' */
                _.Display($"        PARA A APOLICE:");

                /*" -773- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -774- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -775- DISPLAY 'INI VIG - ' V0ENDO-DTINIVIG */
                _.Display($"INI VIG - {V0ENDO_DTINIVIG}");

                /*" -777- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -780- PERFORM R1000-00-CARREGA-TABL-COSSEG UNTIL WFIM-V1APOLCOSCED NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1APOLCOSCED.IsEmpty()))
            {

                R1000_00_CARREGA_TABL_COSSEG_SECTION();
            }

            /*" -783- PERFORM R1300-00-PROCESSA-DOCUMENTO UNTIL WFIM-V1HISTOPARC NOT EQUAL SPACES OR V1HISP-NUM-APOL NOT EQUAL WNUM-APOL-ANT OR V1HISP-NRENDOS NOT EQUAL WNUM-ENDS-ANT. */

            while (!(!AREA_DE_WORK.WFIM_V1HISTOPARC.IsEmpty() || V1HISP_NUM_APOL != AREA_DE_WORK.WNUM_APOL_ANT || V1HISP_NRENDOS != AREA_DE_WORK.WNUM_ENDS_ANT))
            {

                R1300_00_PROCESSA_DOCUMENTO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-SELECT-V0ENDOSSO-SECTION */
        private void R0800_00_SELECT_V0ENDOSSO_SECTION()
        {
            /*" -796- MOVE '0800' TO WNR-EXEC-SQL. */
            _.Move("0800", WABEND.WNR_EXEC_SQL);

            /*" -816- PERFORM R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1 */

            R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1();

            /*" -819- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -820- DISPLAY 'R0800 - ERRO NO SELECT DA V0ENDOSSO' */
                _.Display($"R0800 - ERRO NO SELECT DA V0ENDOSSO");

                /*" -821- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -822- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -823- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                /*" -824- DISPLAY 'OC HIST - ' V1HISP-OCORHIST */
                _.Display($"OC HIST - {V1HISP_OCORHIST}");

                /*" -824- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0800-00-SELECT-V0ENDOSSO-DB-SELECT-1 */
        public void R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1()
        {
            /*" -816- EXEC SQL SELECT NUM_APOLICE , NRENDOS , DTEMIS , QTPARCEL , DTINIVIG , DTTERVIG , CORRECAO , CDFRACIO INTO :V0ENDO-NUM-APOL , :V0ENDO-NRENDOS , :V0ENDO-DTEMIS , :V0ENDO-QTPARCEL , :V0ENDO-DTINIVIG , :V0ENDO-DTTERVIG , :V0ENDO-CORRECAO , :V0ENDO-CDFRACIO FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS END-EXEC. */

            var r0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 = new R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1.Execute(r0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_NUM_APOL, V0ENDO_NUM_APOL);
                _.Move(executed_1.V0ENDO_NRENDOS, V0ENDO_NRENDOS);
                _.Move(executed_1.V0ENDO_DTEMIS, V0ENDO_DTEMIS);
                _.Move(executed_1.V0ENDO_QTPARCEL, V0ENDO_QTPARCEL);
                _.Move(executed_1.V0ENDO_DTINIVIG, V0ENDO_DTINIVIG);
                _.Move(executed_1.V0ENDO_DTTERVIG, V0ENDO_DTTERVIG);
                _.Move(executed_1.V0ENDO_CORRECAO, V0ENDO_CORRECAO);
                _.Move(executed_1.V0ENDO_CDFRACIO, V0ENDO_CDFRACIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V1APOLCOSCED-SECTION */
        private void R0900_00_DECLARE_V1APOLCOSCED_SECTION()
        {
            /*" -837- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -845- PERFORM R0900_00_DECLARE_V1APOLCOSCED_DB_DECLARE_1 */

            R0900_00_DECLARE_V1APOLCOSCED_DB_DECLARE_1();

            /*" -847- PERFORM R0900_00_DECLARE_V1APOLCOSCED_DB_OPEN_1 */

            R0900_00_DECLARE_V1APOLCOSCED_DB_OPEN_1();

            /*" -850- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -851- DISPLAY 'R0900 - ERRO NO DECLARE DA V1APOLCOSCED' */
                _.Display($"R0900 - ERRO NO DECLARE DA V1APOLCOSCED");

                /*" -852- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -853- ELSE */
            }
            else
            {


                /*" -853- MOVE SPACES TO WFIM-V1APOLCOSCED. */
                _.Move("", AREA_DE_WORK.WFIM_V1APOLCOSCED);
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1APOLCOSCED-DB-OPEN-1 */
        public void R0900_00_DECLARE_V1APOLCOSCED_DB_OPEN_1()
        {
            /*" -847- EXEC SQL OPEN V1APOLCOSCED END-EXEC. */

            V1APOLCOSCED.Open();

        }

        [StopWatch]
        /*" R4100-00-DECLARE-V2HISTOPARC-DB-DECLARE-1 */
        public void R4100_00_DECLARE_V2HISTOPARC_DB_DECLARE_1()
        {
            /*" -2171- EXEC SQL DECLARE V2HISTOPARC CURSOR FOR SELECT A.NUM_APOLICE, A.NRENDOS, A.NRPARCEL, A.OCORHIST, A.OPERACAO, A.DTMOVTO, A.PRM_TARIFARIO, A.VAL_DESCONTO, A.VLADIFRA, A.VLCUSEMI, A.DTQITBCO, B.PRM_TARIFARIO_IX, B.VAL_DESCONTO_IX, B.OTNADFRA, B.OTNCUSTO FROM SEGUROS.V1HISTOPARC A, SEGUROS.V1PARCELA B WHERE A.NUM_APOLICE = :V1HISP-NUM-APOL AND A.NRENDOS = :V1HISP-NRENDOS AND A.NRPARCEL = :V1HISP-NRPARCEL AND A.DTMOVTO < :V1HISP-DTMOVTO AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NRENDOS = A.NRENDOS AND B.NRPARCEL = A.NRPARCEL ORDER BY A.NUM_APOLICE, A.NRENDOS, A.NRPARCEL, A.OCORHIST END-EXEC. */
            V2HISTOPARC = new AC0011B_V2HISTOPARC(true);
            string GetQuery_V2HISTOPARC()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.OCORHIST
							, 
							A.OPERACAO
							, 
							A.DTMOVTO
							, 
							A.PRM_TARIFARIO
							, 
							A.VAL_DESCONTO
							, 
							A.VLADIFRA
							, 
							A.VLCUSEMI
							, 
							A.DTQITBCO
							, 
							B.PRM_TARIFARIO_IX
							, 
							B.VAL_DESCONTO_IX
							, 
							B.OTNADFRA
							, 
							B.OTNCUSTO 
							FROM SEGUROS.V1HISTOPARC A
							, 
							SEGUROS.V1PARCELA B 
							WHERE A.NUM_APOLICE = '{V1HISP_NUM_APOL}' 
							AND A.NRENDOS = '{V1HISP_NRENDOS}' 
							AND A.NRPARCEL = '{V1HISP_NRPARCEL}' 
							AND A.DTMOVTO < '{V1HISP_DTMOVTO}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NRENDOS = A.NRENDOS 
							AND B.NRPARCEL = A.NRPARCEL 
							ORDER BY 
							A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.OCORHIST";

                return query;
            }
            V2HISTOPARC.GetQueryEvent += GetQuery_V2HISTOPARC;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-FETCH-V1APOLCOSCED-SECTION */
        private void R0950_00_FETCH_V1APOLCOSCED_SECTION()
        {
            /*" -866- MOVE '0950' TO WNR-EXEC-SQL. */
            _.Move("0950", WABEND.WNR_EXEC_SQL);

            /*" -870- PERFORM R0950_00_FETCH_V1APOLCOSCED_DB_FETCH_1 */

            R0950_00_FETCH_V1APOLCOSCED_DB_FETCH_1();

            /*" -873- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -874- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -875- MOVE 'S' TO WFIM-V1APOLCOSCED */
                    _.Move("S", AREA_DE_WORK.WFIM_V1APOLCOSCED);

                    /*" -875- PERFORM R0950_00_FETCH_V1APOLCOSCED_DB_CLOSE_1 */

                    R0950_00_FETCH_V1APOLCOSCED_DB_CLOSE_1();

                    /*" -877- ELSE */
                }
                else
                {


                    /*" -878- DISPLAY 'R0950 - ERRO NO FETCH DA V1APOLCOSCED' */
                    _.Display($"R0950 - ERRO NO FETCH DA V1APOLCOSCED");

                    /*" -879- DISPLAY 'APOLICE  - ' V1HISP-NUM-APOL */
                    _.Display($"APOLICE  - {V1HISP_NUM_APOL}");

                    /*" -880- DISPLAY 'INIC VIG - ' V0ENDO-DTINIVIG */
                    _.Display($"INIC VIG - {V0ENDO_DTINIVIG}");

                    /*" -880- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0950-00-FETCH-V1APOLCOSCED-DB-FETCH-1 */
        public void R0950_00_FETCH_V1APOLCOSCED_DB_FETCH_1()
        {
            /*" -870- EXEC SQL FETCH V1APOLCOSCED INTO :V1APCD-CODCOSS , :V1APCD-PCPARTIC , :V1APCD-PCCOMCOS END-EXEC. */

            if (V1APOLCOSCED.Fetch())
            {
                _.Move(V1APOLCOSCED.V1APCD_CODCOSS, V1APCD_CODCOSS);
                _.Move(V1APOLCOSCED.V1APCD_PCPARTIC, V1APCD_PCPARTIC);
                _.Move(V1APOLCOSCED.V1APCD_PCCOMCOS, V1APCD_PCCOMCOS);
            }

        }

        [StopWatch]
        /*" R0950-00-FETCH-V1APOLCOSCED-DB-CLOSE-1 */
        public void R0950_00_FETCH_V1APOLCOSCED_DB_CLOSE_1()
        {
            /*" -875- EXEC SQL CLOSE V1APOLCOSCED END-EXEC */

            V1APOLCOSCED.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-CARREGA-TABL-COSSEG-SECTION */
        private void R1000_00_CARREGA_TABL_COSSEG_SECTION()
        {
            /*" -893- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -895- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -896- IF WIND > 300 */

            if (AREA_DE_WORK.WIND > 300)
            {

                /*" -897- DISPLAY 'R1000 - NR. DE CONGENERES PARTICIPANTES DA' */
                _.Display($"R1000 - NR. DE CONGENERES PARTICIPANTES DA");

                /*" -898- DISPLAY 'APOLICE EH MAIOR QUE OCORRENCIAS DA TABELA-WORK' */
                _.Display($"APOLICE EH MAIOR QUE OCORRENCIAS DA TABELA-WORK");

                /*" -899- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -900- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -901- DISPLAY 'INI VIG - ' V0ENDO-DTINIVIG */
                _.Display($"INI VIG - {V0ENDO_DTINIVIG}");

                /*" -903- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -905- PERFORM R1100-00-SELECT-V1ORDCOSCED. */

            R1100_00_SELECT_V1ORDCOSCED_SECTION();

            /*" -906- IF V0APOL-ORGAO = 100 */

            if (V0APOL_ORGAO == 100)
            {

                /*" -907- PERFORM R1200-00-SELECT-V0COSSEGPROD */

                R1200_00_SELECT_V0COSSEGPROD_SECTION();

                /*" -908- ELSE */
            }
            else
            {


                /*" -910- MOVE ZEROS TO V0COSP-PCADMCOS. */
                _.Move(0, V0COSP_PCADMCOS);
            }


            /*" -912- MOVE V1APCD-CODCOSS TO WCODCOSS (WIND). */
            _.Move(V1APCD_CODCOSS, TABELA_COSSEGURO.TABL_COSSEGURO[AREA_DE_WORK.WIND].WCODCOSS);

            /*" -914- MOVE V1ORDC-ORD-CEDIDO TO WORD-CEDIDO (WIND). */
            _.Move(V1ORDC_ORD_CEDIDO, TABELA_COSSEGURO.TABL_COSSEGURO[AREA_DE_WORK.WIND].WORD_CEDIDO);

            /*" -915- MOVE V1APCD-PCPARTIC TO WPCPARTIC (WIND). */
            _.Move(V1APCD_PCPARTIC, TABELA_COSSEGURO.TABL_COSSEGURO[AREA_DE_WORK.WIND].WPCPARTIC);

            /*" -917- MOVE V1APCD-PCCOMCOS TO WPCCOMCOS (WIND). */
            _.Move(V1APCD_PCCOMCOS, TABELA_COSSEGURO.TABL_COSSEGURO[AREA_DE_WORK.WIND].WPCCOMCOS);

            /*" -919- MOVE V0COSP-PCADMCOS TO WPCADMCOS (WIND). */
            _.Move(V0COSP_PCADMCOS, TABELA_COSSEGURO.TABL_COSSEGURO[AREA_DE_WORK.WIND].WPCADMCOS);

            /*" -919- PERFORM R0950-00-FETCH-V1APOLCOSCED. */

            R0950_00_FETCH_V1APOLCOSCED_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V1ORDCOSCED-SECTION */
        private void R1100_00_SELECT_V1ORDCOSCED_SECTION()
        {
            /*" -932- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -939- PERFORM R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1 */

            R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1();

            /*" -942- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -943- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -944- MOVE ZEROS TO V1ORDC-ORD-CEDIDO */
                    _.Move(0, V1ORDC_ORD_CEDIDO);

                    /*" -945- DISPLAY 'R1100 - NAO EXISTE NA V1ORDCOSCED' */
                    _.Display($"R1100 - NAO EXISTE NA V1ORDCOSCED");

                    /*" -946- DISPLAY 'APOLICE   - ' V1HISP-NUM-APOL */
                    _.Display($"APOLICE   - {V1HISP_NUM_APOL}");

                    /*" -947- DISPLAY 'ENDOSSO   - ' V1HISP-NRENDOS */
                    _.Display($"ENDOSSO   - {V1HISP_NRENDOS}");

                    /*" -948- DISPLAY 'CONGENERE - ' V1APCD-CODCOSS */
                    _.Display($"CONGENERE - {V1APCD_CODCOSS}");

                    /*" -949- ELSE */
                }
                else
                {


                    /*" -950- DISPLAY 'R1100 - ERRO NO SELECT DA V1ORDCOSCED' */
                    _.Display($"R1100 - ERRO NO SELECT DA V1ORDCOSCED");

                    /*" -951- DISPLAY 'APOLICE   - ' V1HISP-NUM-APOL */
                    _.Display($"APOLICE   - {V1HISP_NUM_APOL}");

                    /*" -952- DISPLAY 'ENDOSSO   - ' V1HISP-NRENDOS */
                    _.Display($"ENDOSSO   - {V1HISP_NRENDOS}");

                    /*" -953- DISPLAY 'CONGENERE - ' V1APCD-CODCOSS */
                    _.Display($"CONGENERE - {V1APCD_CODCOSS}");

                    /*" -953- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-V1ORDCOSCED-DB-SELECT-1 */
        public void R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1()
        {
            /*" -939- EXEC SQL SELECT ORDEM_CEDIDO INTO :V1ORDC-ORD-CEDIDO FROM SEGUROS.V1ORDECOSCED WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS AND CODCOSS = :V1APCD-CODCOSS END-EXEC. */

            var r1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1_Query1 = new R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
                V1APCD_CODCOSS = V1APCD_CODCOSS.ToString(),
            };

            var executed_1 = R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ORDC_ORD_CEDIDO, V1ORDC_ORD_CEDIDO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V0COSSEGPROD-SECTION */
        private void R1200_00_SELECT_V0COSSEGPROD_SECTION()
        {
            /*" -966- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -975- PERFORM R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1 */

            R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1();

            /*" -978- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -979- DISPLAY 'R1200 - ERRO NO SELECT DA V0COSSEGPROD' */
                _.Display($"R1200 - ERRO NO SELECT DA V0COSSEGPROD");

                /*" -980- DISPLAY 'CONGENERE - ' V1APCD-CODCOSS */
                _.Display($"CONGENERE - {V1APCD_CODCOSS}");

                /*" -981- DISPLAY 'APOLICE   - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE   - {V1HISP_NUM_APOL}");

                /*" -982- DISPLAY 'ENDOSSO   - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO   - {V1HISP_NRENDOS}");

                /*" -983- DISPLAY 'RAMO      - ' V0APOL-RAMO */
                _.Display($"RAMO      - {V0APOL_RAMO}");

                /*" -984- DISPLAY 'PRODUTO   - ' V0APOL-CODPRODU */
                _.Display($"PRODUTO   - {V0APOL_CODPRODU}");

                /*" -985- DISPLAY 'INI VIG   - ' V0ENDO-DTINIVIG */
                _.Display($"INI VIG   - {V0ENDO_DTINIVIG}");

                /*" -985- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V0COSSEGPROD-DB-SELECT-1 */
        public void R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1()
        {
            /*" -975- EXEC SQL SELECT PCADMCOS INTO :V0COSP-PCADMCOS FROM SEGUROS.V0COSSEGPROD WHERE CODPRODU = :V0APOL-CODPRODU AND RAMO = :V0APOL-RAMO AND CONGENER = :V1APCD-CODCOSS AND DTINIVIG <= :V0ENDO-DTINIVIG AND DTTERVIG >= :V0ENDO-DTINIVIG END-EXEC. */

            var r1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1 = new R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1()
            {
                V0APOL_CODPRODU = V0APOL_CODPRODU.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
                V1APCD_CODCOSS = V1APCD_CODCOSS.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COSP_PCADMCOS, V0COSP_PCADMCOS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-PROCESSA-DOCUMENTO-SECTION */
        private void R1300_00_PROCESSA_DOCUMENTO_SECTION()
        {
            /*" -998- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -1000- MOVE 01 TO WIND. */
            _.Move(01, AREA_DE_WORK.WIND);

            /*" -1003- MOVE ZEROS TO V1PCOM-VLR-COMPL V1PCOM-VLR-COMPL-IX. */
            _.Move(0, V1PCOM_VLR_COMPL, V1PCOM_VLR_COMPL_IX);

            /*" -1004- IF WTIPO-OPERACAO = 01 */

            if (AREA_DE_WORK.FILLER_0.WTIPO_OPERACAO == 01)
            {

                /*" -1008- PERFORM R1400-00-OPERACAO-EMISSAO UNTIL WCODCOSS (WIND) EQUAL +0 OR WIND EQUAL 301 */

                while (!(TABELA_COSSEGURO.TABL_COSSEGURO[AREA_DE_WORK.WIND].WCODCOSS == +0 || AREA_DE_WORK.WIND == 301))
                {

                    R1400_00_OPERACAO_EMISSAO_SECTION();
                }

                /*" -1009- ELSE */
            }
            else
            {


                /*" -1013- PERFORM R3000-00-OPER-DIF-EMISSAO UNTIL WCODCOSS (WIND) EQUAL +0 OR WIND EQUAL 301. */

                while (!(TABELA_COSSEGURO.TABL_COSSEGURO[AREA_DE_WORK.WIND].WCODCOSS == +0 || AREA_DE_WORK.WIND == 301))
                {

                    R3000_00_OPER_DIF_EMISSAO_SECTION();
                }
            }


            /*" -1013- PERFORM R0550-00-FETCH-V1HISTOPARC. */

            R0550_00_FETCH_V1HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-OPERACAO-EMISSAO-SECTION */
        private void R1400_00_OPERACAO_EMISSAO_SECTION()
        {
            /*" -1026- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -1027- IF WIND = 01 */

            if (AREA_DE_WORK.WIND == 01)
            {

                /*" -1028- PERFORM R1500-00-SELECT-V1PARCELA */

                R1500_00_SELECT_V1PARCELA_SECTION();

                /*" -1029- IF V0APOL-ORGAO = 100 OR 110 */

                if (V0APOL_ORGAO.In("100", "110"))
                {

                    /*" -1030- MOVE ZEROS TO V1PCOM-VLR-COMPL */
                    _.Move(0, V1PCOM_VLR_COMPL);

                    /*" -1031- MOVE ZEROS TO V1PCOM-VLR-COMPL-IX */
                    _.Move(0, V1PCOM_VLR_COMPL_IX);

                    /*" -1032- ELSE */
                }
                else
                {


                    /*" -1033- IF V0APOL-RAMO = 31 */

                    if (V0APOL_RAMO == 31)
                    {

                        /*" -1035- PERFORM R1600-00-PROCESSA-ASSIST-24HS. */

                        R1600_00_PROCESSA_ASSIST_24HS_SECTION();
                    }

                }

            }


            /*" -1037- MOVE WCODCOSS (WIND) TO V1APCD-CODCOSS. */
            _.Move(TABELA_COSSEGURO.TABL_COSSEGURO[AREA_DE_WORK.WIND].WCODCOSS, V1APCD_CODCOSS);

            /*" -1039- MOVE WORD-CEDIDO (WIND) TO V1ORDC-ORD-CEDIDO. */
            _.Move(TABELA_COSSEGURO.TABL_COSSEGURO[AREA_DE_WORK.WIND].WORD_CEDIDO, V1ORDC_ORD_CEDIDO);

            /*" -1040- MOVE WPCPARTIC (WIND) TO V1APCD-PCPARTIC. */
            _.Move(TABELA_COSSEGURO.TABL_COSSEGURO[AREA_DE_WORK.WIND].WPCPARTIC, V1APCD_PCPARTIC);

            /*" -1042- MOVE WPCCOMCOS (WIND) TO V1APCD-PCCOMCOS. */
            _.Move(TABELA_COSSEGURO.TABL_COSSEGURO[AREA_DE_WORK.WIND].WPCCOMCOS, V1APCD_PCCOMCOS);

            /*" -1044- MOVE WPCADMCOS (WIND) TO V0COSP-PCADMCOS. */
            _.Move(TABELA_COSSEGURO.TABL_COSSEGURO[AREA_DE_WORK.WIND].WPCADMCOS, V0COSP_PCADMCOS);

            /*" -1045- IF V0APOL-ORGAO = 100 */

            if (V0APOL_ORGAO == 100)
            {

                /*" -1046- PERFORM R1800-00-CALCULA-EMISSAO-CV */

                R1800_00_CALCULA_EMISSAO_CV_SECTION();

                /*" -1047- ELSE */
            }
            else
            {


                /*" -1049- PERFORM R1900-00-CALCULA-VALOR-EMIS. */

                R1900_00_CALCULA_VALOR_EMIS_SECTION();
            }


            /*" -1051- PERFORM R2600-00-MONTA-V0COSSEG-PREM. */

            R2600_00_MONTA_V0COSSEG_PREM_SECTION();

            /*" -1053- PERFORM R2700-00-INSERT-V0COSSEG-PREM. */

            R2700_00_INSERT_V0COSSEG_PREM_SECTION();

            /*" -1055- PERFORM R2800-00-MONTA-V0COSSEG-HIST. */

            R2800_00_MONTA_V0COSSEG_HIST_SECTION();

            /*" -1057- PERFORM R2900-00-INSERT-V0COSSEG-HIST. */

            R2900_00_INSERT_V0COSSEG_HIST_SECTION();

            /*" -1057- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-V1PARCELA-SECTION */
        private void R1500_00_SELECT_V1PARCELA_SECTION()
        {
            /*" -1070- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -1089- PERFORM R1500_00_SELECT_V1PARCELA_DB_SELECT_1 */

            R1500_00_SELECT_V1PARCELA_DB_SELECT_1();

            /*" -1092- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1093- DISPLAY 'R1500 - ERRO NO SELECT DA V1PARCELA' */
                _.Display($"R1500 - ERRO NO SELECT DA V1PARCELA");

                /*" -1094- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -1095- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -1096- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                /*" -1097- DISPLAY 'OC HIST - ' V1HISP-OCORHIST */
                _.Display($"OC HIST - {V1HISP_OCORHIST}");

                /*" -1097- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-V1PARCELA-DB-SELECT-1 */
        public void R1500_00_SELECT_V1PARCELA_DB_SELECT_1()
        {
            /*" -1089- EXEC SQL SELECT NUM_APOLICE , NRENDOS , NRPARCEL , PRM_TARIFARIO_IX , VAL_DESCONTO_IX , OTNADFRA , OTNCUSTO INTO :V1PARC-NUM-APOL , :V1PARC-NRENDOS , :V1PARC-NRPARCEL , :V1PARC-PRM-TAR , :V1PARC-VAL-DES , :V1PARC-OTNADFRA , :V1PARC-OTNCUSTO FROM SEGUROS.V1PARCELA WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS AND NRPARCEL = :V1HISP-NRPARCEL END-EXEC. */

            var r1500_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 = new R1500_00_SELECT_V1PARCELA_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRPARCEL = V1HISP_NRPARCEL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R1500_00_SELECT_V1PARCELA_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_V1PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARC_NUM_APOL, V1PARC_NUM_APOL);
                _.Move(executed_1.V1PARC_NRENDOS, V1PARC_NRENDOS);
                _.Move(executed_1.V1PARC_NRPARCEL, V1PARC_NRPARCEL);
                _.Move(executed_1.V1PARC_PRM_TAR, V1PARC_PRM_TAR);
                _.Move(executed_1.V1PARC_VAL_DES, V1PARC_VAL_DES);
                _.Move(executed_1.V1PARC_OTNADFRA, V1PARC_OTNADFRA);
                _.Move(executed_1.V1PARC_OTNCUSTO, V1PARC_OTNCUSTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-PROCESSA-ASSIST-24HS-SECTION */
        private void R1600_00_PROCESSA_ASSIST_24HS_SECTION()
        {
            /*" -1113- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -1115- PERFORM R1700-00-SELECT-V1PARC-COMPL. */

            R1700_00_SELECT_V1PARC_COMPL_SECTION();

            /*" -1116- IF V1PCOM-VLR-COMPL = ZEROS */

            if (V1PCOM_VLR_COMPL == 00)
            {

                /*" -1118- GO TO R1600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1123- COMPUTE WPROP-VAL-DES ROUNDED = V1HISP-VAL-DES / V1HISP-PRM-TAR ON SIZE ERROR MOVE ZEROS TO WPROP-VAL-DES END-COMPUTE. */
            if (V1HISP_PRM_TAR.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROP_VAL_DES);
            else

                AREA_DE_WORK.WPROP_VAL_DES.Value = V1HISP_VAL_DES / V1HISP_PRM_TAR;

            /*" -1128- COMPUTE WPROP-VLADIFRA ROUNDED = V1HISP-VLADIFRA / (V1HISP-PRM-TAR - V1HISP-VAL-DES) ON SIZE ERROR MOVE ZEROS TO WPROP-VLADIFRA END-COMPUTE. */
            if (V1HISP_PRM_TAR.Value - V1HISP_VAL_DES.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROP_VLADIFRA);
            else

                AREA_DE_WORK.WPROP_VLADIFRA.Value = V1HISP_VLADIFRA / (V1HISP_PRM_TAR - V1HISP_VAL_DES);

            /*" -1131- COMPUTE V1HISP-PRM-TAR = V1HISP-PRM-TAR - V1PCOM-VLR-COMPL. */
            V1HISP_PRM_TAR.Value = V1HISP_PRM_TAR - V1PCOM_VLR_COMPL;

            /*" -1134- COMPUTE V1HISP-VAL-DES ROUNDED = V1HISP-PRM-TAR * WPROP-VAL-DES. */
            V1HISP_VAL_DES.Value = V1HISP_PRM_TAR * AREA_DE_WORK.WPROP_VAL_DES;

            /*" -1138- COMPUTE V1HISP-VLADIFRA ROUNDED = (V1HISP-PRM-TAR - V1HISP-VAL-DES) * WPROP-VLADIFRA. */
            V1HISP_VLADIFRA.Value = (V1HISP_PRM_TAR - V1HISP_VAL_DES) * AREA_DE_WORK.WPROP_VLADIFRA;

            /*" -1143- COMPUTE WPROP-VAL-DES ROUNDED = V1PARC-VAL-DES / V1PARC-PRM-TAR ON SIZE ERROR MOVE ZEROS TO WPROP-VAL-DES END-COMPUTE. */
            if (V1PARC_PRM_TAR.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROP_VAL_DES);
            else

                AREA_DE_WORK.WPROP_VAL_DES.Value = V1PARC_VAL_DES / V1PARC_PRM_TAR;

            /*" -1149- COMPUTE WPROP-VLADIFRA ROUNDED = V1PARC-OTNADFRA / (V1PARC-PRM-TAR - V1PARC-VAL-DES) ON SIZE ERROR MOVE ZEROS TO WPROP-VLADIFRA END-COMPUTE. */
            if (V1PARC_PRM_TAR.Value - V1PARC_VAL_DES.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROP_VLADIFRA);
            else

                AREA_DE_WORK.WPROP_VLADIFRA.Value = V1PARC_OTNADFRA / (V1PARC_PRM_TAR - V1PARC_VAL_DES);

            /*" -1152- COMPUTE V1PARC-PRM-TAR = V1PARC-PRM-TAR - V1PCOM-VLR-COMPL-IX. */
            V1PARC_PRM_TAR.Value = V1PARC_PRM_TAR - V1PCOM_VLR_COMPL_IX;

            /*" -1155- COMPUTE V1PARC-VAL-DES ROUNDED = V1PARC-PRM-TAR * WPROP-VAL-DES. */
            V1PARC_VAL_DES.Value = V1PARC_PRM_TAR * AREA_DE_WORK.WPROP_VAL_DES;

            /*" -1157- COMPUTE V1PARC-OTNADFRA ROUNDED = (V1PARC-PRM-TAR - V1PARC-VAL-DES) * WPROP-VLADIFRA. */
            V1PARC_OTNADFRA.Value = (V1PARC_PRM_TAR - V1PARC_VAL_DES) * AREA_DE_WORK.WPROP_VLADIFRA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-SELECT-V1PARC-COMPL-SECTION */
        private void R1700_00_SELECT_V1PARC_COMPL_SECTION()
        {
            /*" -1170- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", WABEND.WNR_EXEC_SQL);

            /*" -1185- PERFORM R1700_00_SELECT_V1PARC_COMPL_DB_SELECT_1 */

            R1700_00_SELECT_V1PARC_COMPL_DB_SELECT_1();

            /*" -1188- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1189- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1190- MOVE ZEROS TO V1PCOM-VLR-COMPL */
                    _.Move(0, V1PCOM_VLR_COMPL);

                    /*" -1191- MOVE ZEROS TO V1PCOM-VLR-COMPL-IX */
                    _.Move(0, V1PCOM_VLR_COMPL_IX);

                    /*" -1192- ELSE */
                }
                else
                {


                    /*" -1193- DISPLAY 'R1700 - ERRO NO SELECT DA V1PARCELA-COMPL' */
                    _.Display($"R1700 - ERRO NO SELECT DA V1PARCELA-COMPL");

                    /*" -1194- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                    _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                    /*" -1195- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                    _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                    /*" -1196- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                    _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                    /*" -1197- DISPLAY 'OC HIST - ' V1HISP-OCORHIST */
                    _.Display($"OC HIST - {V1HISP_OCORHIST}");

                    /*" -1197- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1700-00-SELECT-V1PARC-COMPL-DB-SELECT-1 */
        public void R1700_00_SELECT_V1PARC_COMPL_DB_SELECT_1()
        {
            /*" -1185- EXEC SQL SELECT NUM_APOLICE, NRENDOS, NRPARCEL, VLR_COMPLEMENT_IX, VLR_COMPLEMENTO INTO :V1PCOM-NUM-APOL, :V1PCOM-NRENDOS, :V1PCOM-NRPARCEL, :V1PCOM-VLR-COMPL-IX, :V1PCOM-VLR-COMPL FROM SEGUROS.V1PARCELA_COMPL WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS AND NRPARCEL = :V1HISP-NRPARCEL END-EXEC. */

            var r1700_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1 = new R1700_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRPARCEL = V1HISP_NRPARCEL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R1700_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1.Execute(r1700_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PCOM_NUM_APOL, V1PCOM_NUM_APOL);
                _.Move(executed_1.V1PCOM_NRENDOS, V1PCOM_NRENDOS);
                _.Move(executed_1.V1PCOM_NRPARCEL, V1PCOM_NRPARCEL);
                _.Move(executed_1.V1PCOM_VLR_COMPL_IX, V1PCOM_VLR_COMPL_IX);
                _.Move(executed_1.V1PCOM_VLR_COMPL, V1PCOM_VLR_COMPL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-CALCULA-EMISSAO-CV-SECTION */
        private void R1800_00_CALCULA_EMISSAO_CV_SECTION()
        {
            /*" -1210- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", WABEND.WNR_EXEC_SQL);

            /*" -1215- MOVE ZEROS TO WS-VLCUSEMI WS-VLCOMCOS WS-PRMTAR-LID WS-PRO-LABORE. */
            _.Move(0, AREA_DE_WORK.WS_VLCUSEMI, AREA_DE_WORK.WS_VLCOMCOS, AREA_DE_WORK.WS_PRMTAR_LID, AREA_DE_WORK.WS_PRO_LABORE);

            /*" -1220- MOVE ZEROS TO WS-VLCUSEMI-IX WS-VLCOMCOS-IX WS-PRMTAR-LID-IX WS-PRO-LABORE-IX. */
            _.Move(0, AREA_DE_WORK.WS_VLCUSEMI_IX, AREA_DE_WORK.WS_VLCOMCOS_IX, AREA_DE_WORK.WS_PRMTAR_LID_IX, AREA_DE_WORK.WS_PRO_LABORE_IX);

            /*" -1224- COMPUTE V0CHIS-PRM-TAR = V1HISP-PRM-TAR * V1APCD-PCPARTIC / 100. */
            V0CHIS_PRM_TAR.Value = V1HISP_PRM_TAR * V1APCD_PCPARTIC / 100f;

            /*" -1235- COMPUTE WS-VLCOMCOS = V0CHIS-PRM-TAR * V1APCD-PCCOMCOS / 100. */
            AREA_DE_WORK.WS_VLCOMCOS.Value = V0CHIS_PRM_TAR * V1APCD_PCCOMCOS / 100f;

            /*" -1244- COMPUTE V0CHIS-VLCOMIS = WS-VLCOMCOS - WS-PRO-LABORE. */
            V0CHIS_VLCOMIS.Value = AREA_DE_WORK.WS_VLCOMCOS - AREA_DE_WORK.WS_PRO_LABORE;

            /*" -1248- COMPUTE V0CHIS-VAL-DES = V1HISP-VAL-DES * V1APCD-PCPARTIC / 100. */
            V0CHIS_VAL_DES.Value = V1HISP_VAL_DES * V1APCD_PCPARTIC / 100f;

            /*" -1251- COMPUTE V0CHIS-VLPRMLIQ = V0CHIS-PRM-TAR - V0CHIS-VAL-DES. */
            V0CHIS_VLPRMLIQ.Value = V0CHIS_PRM_TAR - V0CHIS_VAL_DES;

            /*" -1255- COMPUTE V0CHIS-VLADIFRA = V1HISP-VLADIFRA * V1APCD-PCPARTIC / 100. */
            V0CHIS_VLADIFRA.Value = V1HISP_VLADIFRA * V1APCD_PCPARTIC / 100f;

            /*" -1261- COMPUTE V0CHIS-VLPRMTOT = V0CHIS-VLPRMLIQ + V0CHIS-VLADIFRA - V0CHIS-VLCOMIS. */
            V0CHIS_VLPRMTOT.Value = V0CHIS_VLPRMLIQ + V0CHIS_VLADIFRA - V0CHIS_VLCOMIS;

            /*" -1262- IF V0ENDO-CORRECAO = '1' OR '3' */

            if (V0ENDO_CORRECAO.In("1", "3"))
            {

                /*" -1263- MOVE V0CHIS-PRM-TAR TO V0CPRE-PRM-TAR-IX */
                _.Move(V0CHIS_PRM_TAR, V0CPRE_PRM_TAR_IX);

                /*" -1264- MOVE V0CHIS-VAL-DES TO V0CPRE-VAL-DES-IX */
                _.Move(V0CHIS_VAL_DES, V0CPRE_VAL_DES_IX);

                /*" -1265- MOVE V0CHIS-VLPRMLIQ TO V0CPRE-OTNPRLIQ */
                _.Move(V0CHIS_VLPRMLIQ, V0CPRE_OTNPRLIQ);

                /*" -1266- MOVE V0CHIS-VLADIFRA TO V0CPRE-OTNADFRA */
                _.Move(V0CHIS_VLADIFRA, V0CPRE_OTNADFRA);

                /*" -1267- MOVE V0CHIS-VLCOMIS TO V0CPRE-VLCOMISIX */
                _.Move(V0CHIS_VLCOMIS, V0CPRE_VLCOMISIX);

                /*" -1268- MOVE V0CHIS-VLPRMTOT TO V0CPRE-OTNTOTAL */
                _.Move(V0CHIS_VLPRMTOT, V0CPRE_OTNTOTAL);

                /*" -1269- ELSE */
            }
            else
            {


                /*" -1273- COMPUTE V0CPRE-PRM-TAR-IX = V1PARC-PRM-TAR * V1APCD-PCPARTIC / 100 */
                V0CPRE_PRM_TAR_IX.Value = V1PARC_PRM_TAR * V1APCD_PCPARTIC / 100f;

                /*" -1284- COMPUTE WS-VLCOMCOS-IX = V0CPRE-PRM-TAR-IX * V1APCD-PCCOMCOS / 100 */
                AREA_DE_WORK.WS_VLCOMCOS_IX.Value = V0CPRE_PRM_TAR_IX * V1APCD_PCCOMCOS / 100f;

                /*" -1293- COMPUTE V0CPRE-VLCOMISIX = WS-VLCOMCOS-IX - WS-PRO-LABORE-IX */
                V0CPRE_VLCOMISIX.Value = AREA_DE_WORK.WS_VLCOMCOS_IX - AREA_DE_WORK.WS_PRO_LABORE_IX;

                /*" -1297- COMPUTE V0CPRE-VAL-DES-IX = V1PARC-VAL-DES * V1APCD-PCPARTIC / 100 */
                V0CPRE_VAL_DES_IX.Value = V1PARC_VAL_DES * V1APCD_PCPARTIC / 100f;

                /*" -1300- COMPUTE V0CPRE-OTNPRLIQ = V0CPRE-PRM-TAR-IX - V0CPRE-VAL-DES-IX */
                V0CPRE_OTNPRLIQ.Value = V0CPRE_PRM_TAR_IX - V0CPRE_VAL_DES_IX;

                /*" -1304- COMPUTE V0CPRE-OTNADFRA = V1PARC-OTNADFRA * V1APCD-PCPARTIC / 100 */
                V0CPRE_OTNADFRA.Value = V1PARC_OTNADFRA * V1APCD_PCPARTIC / 100f;

                /*" -1306- COMPUTE V0CPRE-OTNTOTAL = V0CPRE-OTNPRLIQ + V0CPRE-OTNADFRA - V0CPRE-VLCOMISIX. */
                V0CPRE_OTNTOTAL.Value = V0CPRE_OTNPRLIQ + V0CPRE_OTNADFRA - V0CPRE_VLCOMISIX;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-CALCULA-VALOR-EMIS-SECTION */
        private void R1900_00_CALCULA_VALOR_EMIS_SECTION()
        {
            /*" -1319- MOVE '1900' TO WNR-EXEC-SQL. */
            _.Move("1900", WABEND.WNR_EXEC_SQL);

            /*" -1323- COMPUTE V0CHIS-PRM-TAR = V1HISP-PRM-TAR * V1APCD-PCPARTIC / 100. */
            V0CHIS_PRM_TAR.Value = V1HISP_PRM_TAR * V1APCD_PCPARTIC / 100f;

            /*" -1327- COMPUTE V0CHIS-VAL-DES = V1HISP-VAL-DES * V1APCD-PCPARTIC / 100. */
            V0CHIS_VAL_DES.Value = V1HISP_VAL_DES * V1APCD_PCPARTIC / 100f;

            /*" -1330- COMPUTE V0CHIS-VLPRMLIQ = V0CHIS-PRM-TAR - V0CHIS-VAL-DES. */
            V0CHIS_VLPRMLIQ.Value = V0CHIS_PRM_TAR - V0CHIS_VAL_DES;

            /*" -1334- COMPUTE V0CHIS-VLADIFRA = V1HISP-VLADIFRA * V1APCD-PCPARTIC / 100. */
            V0CHIS_VLADIFRA.Value = V1HISP_VLADIFRA * V1APCD_PCPARTIC / 100f;

            /*" -1338- COMPUTE V0CPRE-PRM-TAR-IX = V1PARC-PRM-TAR * V1APCD-PCPARTIC / 100. */
            V0CPRE_PRM_TAR_IX.Value = V1PARC_PRM_TAR * V1APCD_PCPARTIC / 100f;

            /*" -1342- COMPUTE V0CPRE-VAL-DES-IX = V1PARC-VAL-DES * V1APCD-PCPARTIC / 100. */
            V0CPRE_VAL_DES_IX.Value = V1PARC_VAL_DES * V1APCD_PCPARTIC / 100f;

            /*" -1345- COMPUTE V0CPRE-OTNPRLIQ = V0CPRE-PRM-TAR-IX - V0CPRE-VAL-DES-IX. */
            V0CPRE_OTNPRLIQ.Value = V0CPRE_PRM_TAR_IX - V0CPRE_VAL_DES_IX;

            /*" -1349- COMPUTE V0CPRE-OTNADFRA = V1PARC-OTNADFRA * V1APCD-PCPARTIC / 100. */
            V0CPRE_OTNADFRA.Value = V1PARC_OTNADFRA * V1APCD_PCPARTIC / 100f;

            /*" -1352- IF V0ENDO-CDFRACIO > 0 AND V0ENDO-QTPARCEL > 1 AND V1HISP-DTMOVTO NOT LESS WDTLIMITE-COMIS */

            if (V0ENDO_CDFRACIO > 0 && V0ENDO_QTPARCEL > 1 && V1HISP_DTMOVTO >= WDTLIMITE_COMIS)
            {

                /*" -1353- PERFORM R2000-00-TRATA-COMIS-ACELERADA */

                R2000_00_TRATA_COMIS_ACELERADA_SECTION();

                /*" -1354- ELSE */
            }
            else
            {


                /*" -1355- IF V0APOL-RAMO = 31 OR 53 */

                if (V0APOL_RAMO.In("31", "53"))
                {

                    /*" -1358- COMPUTE V0CHIS-VLCOMIS = V0CHIS-VLPRMLIQ * V1APCD-PCCOMCOS / 100 */
                    V0CHIS_VLCOMIS.Value = V0CHIS_VLPRMLIQ * V1APCD_PCCOMCOS / 100f;

                    /*" -1361- COMPUTE V0CPRE-VLCOMISIX = V0CPRE-OTNPRLIQ * V1APCD-PCCOMCOS / 100 */
                    V0CPRE_VLCOMISIX.Value = V0CPRE_OTNPRLIQ * V1APCD_PCCOMCOS / 100f;

                    /*" -1362- ELSE */
                }
                else
                {


                    /*" -1366- COMPUTE V0CHIS-VLCOMIS = (V0CHIS-VLPRMLIQ + V0CHIS-VLADIFRA) * V1APCD-PCCOMCOS / 100 */
                    V0CHIS_VLCOMIS.Value = (V0CHIS_VLPRMLIQ + V0CHIS_VLADIFRA) * V1APCD_PCCOMCOS / 100f;

                    /*" -1371- COMPUTE V0CPRE-VLCOMISIX = ((V0CPRE-OTNPRLIQ + V0CPRE-OTNADFRA) * V1APCD-PCCOMCOS / 100). */
                    V0CPRE_VLCOMISIX.Value = ((V0CPRE_OTNPRLIQ + V0CPRE_OTNADFRA) * V1APCD_PCCOMCOS / 100f);
                }

            }


            /*" -1372- IF V0ENDO-CORRECAO = '1' OR '3' */

            if (V0ENDO_CORRECAO.In("1", "3"))
            {

                /*" -1373- MOVE V0CHIS-PRM-TAR TO V0CPRE-PRM-TAR-IX */
                _.Move(V0CHIS_PRM_TAR, V0CPRE_PRM_TAR_IX);

                /*" -1374- MOVE V0CHIS-VAL-DES TO V0CPRE-VAL-DES-IX */
                _.Move(V0CHIS_VAL_DES, V0CPRE_VAL_DES_IX);

                /*" -1375- MOVE V0CHIS-VLPRMLIQ TO V0CPRE-OTNPRLIQ */
                _.Move(V0CHIS_VLPRMLIQ, V0CPRE_OTNPRLIQ);

                /*" -1376- MOVE V0CHIS-VLADIFRA TO V0CPRE-OTNADFRA */
                _.Move(V0CHIS_VLADIFRA, V0CPRE_OTNADFRA);

                /*" -1378- MOVE V0CHIS-VLCOMIS TO V0CPRE-VLCOMISIX. */
                _.Move(V0CHIS_VLCOMIS, V0CPRE_VLCOMISIX);
            }


            /*" -1382- COMPUTE V0CHIS-VLPRMTOT = V0CHIS-VLPRMLIQ + V0CHIS-VLADIFRA - V0CHIS-VLCOMIS. */
            V0CHIS_VLPRMTOT.Value = V0CHIS_VLPRMLIQ + V0CHIS_VLADIFRA - V0CHIS_VLCOMIS;

            /*" -1384- COMPUTE V0CPRE-OTNTOTAL = (V0CPRE-OTNPRLIQ + V0CPRE-OTNADFRA - V0CPRE-VLCOMISIX). */
            V0CPRE_OTNTOTAL.Value = (V0CPRE_OTNPRLIQ + V0CPRE_OTNADFRA - V0CPRE_VLCOMISIX);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-TRATA-COMIS-ACELERADA-SECTION */
        private void R2000_00_TRATA_COMIS_ACELERADA_SECTION()
        {
            /*" -1397- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -1399- PERFORM R2100-00-SELECT-V1PLANCOMIS. */

            R2100_00_SELECT_V1PLANCOMIS_SECTION();

            /*" -1400- IF V1PLCO-PCCOMSEG = ZEROS */

            if (V1PLCO_PCCOMSEG == 00)
            {

                /*" -1401- MOVE ZEROS TO V0CHIS-VLCOMIS */
                _.Move(0, V0CHIS_VLCOMIS);

                /*" -1402- MOVE ZEROS TO V0CPRE-VLCOMISIX */
                _.Move(0, V0CPRE_VLCOMISIX);

                /*" -1404- GO TO R2000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1406- PERFORM R2200-00-SUM-V0PARCELA. */

            R2200_00_SUM_V0PARCELA_SECTION();

            /*" -1408- PERFORM R2300-00-SUM-V0HISTOPARC. */

            R2300_00_SUM_V0HISTOPARC_SECTION();

            /*" -1409- IF V1PCOM-VLR-COMPL NOT EQUAL ZEROS */

            if (V1PCOM_VLR_COMPL != 00)
            {

                /*" -1410- PERFORM R2400-00-SUM-V0PARC-COMPL */

                R2400_00_SUM_V0PARC_COMPL_SECTION();

                /*" -1412- PERFORM R2500-00-TRATA-ASSIST-24HS. */

                R2500_00_TRATA_ASSIST_24HS_SECTION();
            }


            /*" -1413- IF V0APOL-RAMO = 31 OR 53 */

            if (V0APOL_RAMO.In("31", "53"))
            {

                /*" -1422- COMPUTE V0CHIS-VLCOMIS ROUNDED = (((V3HISP-PRM-TAR - V3HISP-VAL-DES * V1APCD-PCPARTIC / 100) * V1APCD-PCCOMCOS / 100) * V1PLCO-PCCOMSEG / 100) */
                V0CHIS_VLCOMIS.Value = (((V3HISP_PRM_TAR - V3HISP_VAL_DES * V1APCD_PCPARTIC / 100f) * V1APCD_PCCOMCOS / 100f) * V1PLCO_PCCOMSEG / 100f);

                /*" -1430- COMPUTE V0CPRE-VLCOMISIX ROUNDED = (((V3PARC-PRM-TAR - V3PARC-VAL-DES * V1APCD-PCPARTIC / 100) * V1APCD-PCCOMCOS / 100) * V1PLCO-PCCOMSEG / 100) */
                V0CPRE_VLCOMISIX.Value = (((V3PARC_PRM_TAR - V3PARC_VAL_DES * V1APCD_PCPARTIC / 100f) * V1APCD_PCCOMCOS / 100f) * V1PLCO_PCCOMSEG / 100f);

                /*" -1431- ELSE */
            }
            else
            {


                /*" -1441- COMPUTE V0CHIS-VLCOMIS ROUNDED = ((((V3HISP-PRM-TAR - V3HISP-VAL-DES + V3HISP-VLADIFRA) * V1APCD-PCPARTIC / 100) * V1APCD-PCCOMCOS / 100) * V1PLCO-PCCOMSEG / 100) */
                V0CHIS_VLCOMIS.Value = ((((V3HISP_PRM_TAR - V3HISP_VAL_DES + V3HISP_VLADIFRA) * V1APCD_PCPARTIC / 100f) * V1APCD_PCCOMCOS / 100f) * V1PLCO_PCCOMSEG / 100f);

                /*" -1449- COMPUTE V0CPRE-VLCOMISIX ROUNDED = ((((V3PARC-PRM-TAR - V3PARC-VAL-DES + V3PARC-OTNADFRA) * V1APCD-PCPARTIC / 100) * V1APCD-PCCOMCOS / 100) * V1PLCO-PCCOMSEG / 100). */
                V0CPRE_VLCOMISIX.Value = ((((V3PARC_PRM_TAR - V3PARC_VAL_DES + V3PARC_OTNADFRA) * V1APCD_PCPARTIC / 100f) * V1APCD_PCCOMCOS / 100f) * V1PLCO_PCCOMSEG / 100f);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-V1PLANCOMIS-SECTION */
        private void R2100_00_SELECT_V1PLANCOMIS_SECTION()
        {
            /*" -1462- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -1468- PERFORM R2100_00_SELECT_V1PLANCOMIS_DB_SELECT_1 */

            R2100_00_SELECT_V1PLANCOMIS_DB_SELECT_1();

            /*" -1471- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1472- DISPLAY 'R2100 - ERRO NO SELECT DA V1PLANCOMIS' */
                _.Display($"R2100 - ERRO NO SELECT DA V1PLANCOMIS");

                /*" -1473- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -1474- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -1475- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                /*" -1476- DISPLAY 'OC HIST - ' V1HISP-OCORHIST */
                _.Display($"OC HIST - {V1HISP_OCORHIST}");

                /*" -1476- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-SELECT-V1PLANCOMIS-DB-SELECT-1 */
        public void R2100_00_SELECT_V1PLANCOMIS_DB_SELECT_1()
        {
            /*" -1468- EXEC SQL SELECT PCCOMSEG INTO :V1PLCO-PCCOMSEG FROM SEGUROS.V1PLANCOMIS WHERE CDFRACIO = :V0ENDO-CDFRACIO AND NRPARCEL = :V1HISP-NRPARCEL END-EXEC. */

            var r2100_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1 = new R2100_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1()
            {
                V0ENDO_CDFRACIO = V0ENDO_CDFRACIO.ToString(),
                V1HISP_NRPARCEL = V1HISP_NRPARCEL.ToString(),
            };

            var executed_1 = R2100_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1.Execute(r2100_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PLCO_PCCOMSEG, V1PLCO_PCCOMSEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SUM-V0PARCELA-SECTION */
        private void R2200_00_SUM_V0PARCELA_SECTION()
        {
            /*" -1489- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -1501- PERFORM R2200_00_SUM_V0PARCELA_DB_SELECT_1 */

            R2200_00_SUM_V0PARCELA_DB_SELECT_1();

            /*" -1504- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1505- DISPLAY 'R2200 - ERRO NO SELECT DA V0PARCELA' */
                _.Display($"R2200 - ERRO NO SELECT DA V0PARCELA");

                /*" -1506- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -1507- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -1508- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                /*" -1509- DISPLAY 'OC HIST - ' V1HISP-OCORHIST */
                _.Display($"OC HIST - {V1HISP_OCORHIST}");

                /*" -1509- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2200-00-SUM-V0PARCELA-DB-SELECT-1 */
        public void R2200_00_SUM_V0PARCELA_DB_SELECT_1()
        {
            /*" -1501- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO_IX),+0) , VALUE(SUM(VAL_DESCONTO_IX),+0) , VALUE(SUM(OTNADFRA),+0) , VALUE(SUM(OTNCUSTO),+0) INTO :V3PARC-PRM-TAR , :V3PARC-VAL-DES , :V3PARC-OTNADFRA , :V3PARC-OTNCUSTO FROM SEGUROS.V0PARCELA WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS END-EXEC. */

            var r2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1 = new R2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1.Execute(r2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V3PARC_PRM_TAR, V3PARC_PRM_TAR);
                _.Move(executed_1.V3PARC_VAL_DES, V3PARC_VAL_DES);
                _.Move(executed_1.V3PARC_OTNADFRA, V3PARC_OTNADFRA);
                _.Move(executed_1.V3PARC_OTNCUSTO, V3PARC_OTNCUSTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-SUM-V0HISTOPARC-SECTION */
        private void R2300_00_SUM_V0HISTOPARC_SECTION()
        {
            /*" -1522- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -1536- PERFORM R2300_00_SUM_V0HISTOPARC_DB_SELECT_1 */

            R2300_00_SUM_V0HISTOPARC_DB_SELECT_1();

            /*" -1539- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1540- DISPLAY 'R2300 - ERRO NO SELECT DA V0HISTOPARC' */
                _.Display($"R2300 - ERRO NO SELECT DA V0HISTOPARC");

                /*" -1541- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -1542- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -1543- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                /*" -1544- DISPLAY 'OC HIST - ' V1HISP-OCORHIST */
                _.Display($"OC HIST - {V1HISP_OCORHIST}");

                /*" -1544- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2300-00-SUM-V0HISTOPARC-DB-SELECT-1 */
        public void R2300_00_SUM_V0HISTOPARC_DB_SELECT_1()
        {
            /*" -1536- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO),+0) , VALUE(SUM(VAL_DESCONTO),+0) , VALUE(SUM(VLADIFRA),+0) , VALUE(SUM(VLCUSEMI),+0) INTO :V3HISP-PRM-TAR , :V3HISP-VAL-DES , :V3HISP-VLADIFRA , :V3HISP-VLCUSEMI FROM SEGUROS.V0HISTOPARC WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS AND OCORHIST = 01 AND OPERACAO < 0200 END-EXEC. */

            var r2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1 = new R2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1.Execute(r2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V3HISP_PRM_TAR, V3HISP_PRM_TAR);
                _.Move(executed_1.V3HISP_VAL_DES, V3HISP_VAL_DES);
                _.Move(executed_1.V3HISP_VLADIFRA, V3HISP_VLADIFRA);
                _.Move(executed_1.V3HISP_VLCUSEMI, V3HISP_VLCUSEMI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-SUM-V0PARC-COMPL-SECTION */
        private void R2400_00_SUM_V0PARC_COMPL_SECTION()
        {
            /*" -1557- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", WABEND.WNR_EXEC_SQL);

            /*" -1565- PERFORM R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1 */

            R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1();

            /*" -1568- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1569- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1570- MOVE ZEROS TO V2PCOM-VLR-COMPL */
                    _.Move(0, V2PCOM_VLR_COMPL);

                    /*" -1571- MOVE ZEROS TO V2PCOM-VLR-COMPL-IX */
                    _.Move(0, V2PCOM_VLR_COMPL_IX);

                    /*" -1572- ELSE */
                }
                else
                {


                    /*" -1573- DISPLAY 'R2400 - ERRO NO SELECT DA V0PARCELA-COMPL' */
                    _.Display($"R2400 - ERRO NO SELECT DA V0PARCELA-COMPL");

                    /*" -1574- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                    _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                    /*" -1575- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                    _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                    /*" -1576- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                    _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                    /*" -1577- DISPLAY 'OC HIST - ' V1HISP-OCORHIST */
                    _.Display($"OC HIST - {V1HISP_OCORHIST}");

                    /*" -1577- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2400-00-SUM-V0PARC-COMPL-DB-SELECT-1 */
        public void R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1()
        {
            /*" -1565- EXEC SQL SELECT VALUE(SUM(VLR_COMPLEMENT_IX),+0) , VALUE(SUM(VLR_COMPLEMENTO),+0) INTO :V2PCOM-VLR-COMPL-IX , :V2PCOM-VLR-COMPL FROM SEGUROS.V0PARCELA_COMPL WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS END-EXEC. */

            var r2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1 = new R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1.Execute(r2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V2PCOM_VLR_COMPL_IX, V2PCOM_VLR_COMPL_IX);
                _.Move(executed_1.V2PCOM_VLR_COMPL, V2PCOM_VLR_COMPL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-TRATA-ASSIST-24HS-SECTION */
        private void R2500_00_TRATA_ASSIST_24HS_SECTION()
        {
            /*" -1594- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -1599- COMPUTE WPROP-VAL-DES ROUNDED = V3HISP-VAL-DES / V3HISP-PRM-TAR ON SIZE ERROR MOVE ZEROS TO WPROP-VAL-DES END-COMPUTE. */
            if (V3HISP_PRM_TAR.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROP_VAL_DES);
            else

                AREA_DE_WORK.WPROP_VAL_DES.Value = V3HISP_VAL_DES / V3HISP_PRM_TAR;

            /*" -1605- COMPUTE WPROP-VLADIFRA ROUNDED = V3HISP-VLADIFRA / (V3HISP-PRM-TAR - V3HISP-VAL-DES) ON SIZE ERROR MOVE ZEROS TO WPROP-VLADIFRA END-COMPUTE. */
            if (V3HISP_PRM_TAR.Value - V3HISP_VAL_DES.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROP_VLADIFRA);
            else

                AREA_DE_WORK.WPROP_VLADIFRA.Value = V3HISP_VLADIFRA / (V3HISP_PRM_TAR - V3HISP_VAL_DES);

            /*" -1608- COMPUTE V3HISP-PRM-TAR = V3HISP-PRM-TAR - V2PCOM-VLR-COMPL. */
            V3HISP_PRM_TAR.Value = V3HISP_PRM_TAR - V2PCOM_VLR_COMPL;

            /*" -1611- COMPUTE V3HISP-VAL-DES ROUNDED = V3HISP-PRM-TAR * WPROP-VAL-DES. */
            V3HISP_VAL_DES.Value = V3HISP_PRM_TAR * AREA_DE_WORK.WPROP_VAL_DES;

            /*" -1616- COMPUTE V3HISP-VLADIFRA ROUNDED = (V3HISP-PRM-TAR - V3HISP-VAL-DES) * WPROP-VLADIFRA END-COMPUTE. */
            V3HISP_VLADIFRA.Value = (V3HISP_PRM_TAR - V3HISP_VAL_DES) * AREA_DE_WORK.WPROP_VLADIFRA;

            /*" -1621- COMPUTE WPROP-VAL-DES ROUNDED = V3PARC-VAL-DES / V3PARC-PRM-TAR ON SIZE ERROR MOVE ZEROS TO WPROP-VAL-DES END-COMPUTE. */
            if (V3PARC_PRM_TAR.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROP_VAL_DES);
            else

                AREA_DE_WORK.WPROP_VAL_DES.Value = V3PARC_VAL_DES / V3PARC_PRM_TAR;

            /*" -1627- COMPUTE WPROP-VLADIFRA ROUNDED = V3PARC-OTNADFRA / (V3PARC-PRM-TAR - V3PARC-VAL-DES) ON SIZE ERROR MOVE ZEROS TO WPROP-VLADIFRA END-COMPUTE. */
            if (V3PARC_PRM_TAR.Value - V3PARC_VAL_DES.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROP_VLADIFRA);
            else

                AREA_DE_WORK.WPROP_VLADIFRA.Value = V3PARC_OTNADFRA / (V3PARC_PRM_TAR - V3PARC_VAL_DES);

            /*" -1630- COMPUTE V3PARC-PRM-TAR = V3PARC-PRM-TAR - V2PCOM-VLR-COMPL-IX. */
            V3PARC_PRM_TAR.Value = V3PARC_PRM_TAR - V2PCOM_VLR_COMPL_IX;

            /*" -1633- COMPUTE V3PARC-VAL-DES ROUNDED = V3PARC-PRM-TAR * WPROP-VAL-DES. */
            V3PARC_VAL_DES.Value = V3PARC_PRM_TAR * AREA_DE_WORK.WPROP_VAL_DES;

            /*" -1635- COMPUTE V3PARC-OTNADFRA ROUNDED = (V3PARC-PRM-TAR - V3PARC-VAL-DES) * WPROP-VLADIFRA. */
            V3PARC_OTNADFRA.Value = (V3PARC_PRM_TAR - V3PARC_VAL_DES) * AREA_DE_WORK.WPROP_VLADIFRA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-MONTA-V0COSSEG-PREM-SECTION */
        private void R2600_00_MONTA_V0COSSEG_PREM_SECTION()
        {
            /*" -1648- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", WABEND.WNR_EXEC_SQL);

            /*" -1649- MOVE ZEROS TO V0CPRE-COD-EMPR. */
            _.Move(0, V0CPRE_COD_EMPR);

            /*" -1650- MOVE '1' TO V0CPRE-TIPSGU. */
            _.Move("1", V0CPRE_TIPSGU);

            /*" -1651- MOVE V1APCD-CODCOSS TO V0CPRE-CONGENER. */
            _.Move(V1APCD_CODCOSS, V0CPRE_CONGENER);

            /*" -1652- MOVE V1ORDC-ORD-CEDIDO TO V0CPRE-NUM-ORDEM. */
            _.Move(V1ORDC_ORD_CEDIDO, V0CPRE_NUM_ORDEM);

            /*" -1653- MOVE V1HISP-NUM-APOL TO V0CPRE-NUM-APOL. */
            _.Move(V1HISP_NUM_APOL, V0CPRE_NUM_APOL);

            /*" -1654- MOVE V1HISP-NRENDOS TO V0CPRE-NRENDOS. */
            _.Move(V1HISP_NRENDOS, V0CPRE_NRENDOS);

            /*" -1655- MOVE V1HISP-NRPARCEL TO V0CPRE-NRPARCEL. */
            _.Move(V1HISP_NRPARCEL, V0CPRE_NRPARCEL);

            /*" -1656- MOVE '0' TO V0CPRE-SITUACAO. */
            _.Move("0", V0CPRE_SITUACAO);

            /*" -1657- MOVE '0' TO V0CPRE-SIT-CONG. */
            _.Move("0", V0CPRE_SIT_CONG);

            /*" -1659- MOVE 01 TO V0CPRE-OCORHIST. */
            _.Move(01, V0CPRE_OCORHIST);

            /*" -1661- MOVE +1 TO VIND-OCR-HIST. */
            _.Move(+1, VIND_OCR_HIST);

            /*" -1661- MOVE ZEROS TO WSHOST-OCORHIST. */
            _.Move(0, WSHOST_OCORHIST);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-INSERT-V0COSSEG-PREM-SECTION */
        private void R2700_00_INSERT_V0COSSEG_PREM_SECTION()
        {
            /*" -1674- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", WABEND.WNR_EXEC_SQL);

            /*" -1693- PERFORM R2700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1 */

            R2700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1();

            /*" -1696- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1697- DISPLAY 'R2700 - ERRO NO INSERT DA V0COSSEG-PREM' */
                _.Display($"R2700 - ERRO NO INSERT DA V0COSSEG-PREM");

                /*" -1698- DISPLAY 'CONGENERE - ' V1APCD-CODCOSS */
                _.Display($"CONGENERE - {V1APCD_CODCOSS}");

                /*" -1699- DISPLAY 'NUM ORDEM - ' V1ORDC-ORD-CEDIDO */
                _.Display($"NUM ORDEM - {V1ORDC_ORD_CEDIDO}");

                /*" -1700- DISPLAY 'APOLICE   - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE   - {V1HISP_NUM_APOL}");

                /*" -1701- DISPLAY 'ENDOSSO   - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO   - {V1HISP_NRENDOS}");

                /*" -1702- DISPLAY 'PARCELA   - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA   - {V1HISP_NRPARCEL}");

                /*" -1703- DISPLAY 'OCOR HIST - ' V1HISP-OCORHIST */
                _.Display($"OCOR HIST - {V1HISP_OCORHIST}");

                /*" -1704- DISPLAY 'OPERACAO  - ' V1HISP-OPERACAO */
                _.Display($"OPERACAO  - {V1HISP_OPERACAO}");

                /*" -1705- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1706- ELSE */
            }
            else
            {


                /*" -1706- ADD 1 TO AC-I-V0COSSEGPREM. */
                AREA_DE_WORK.AC_I_V0COSSEGPREM.Value = AREA_DE_WORK.AC_I_V0COSSEGPREM + 1;
            }


        }

        [StopWatch]
        /*" R2700-00-INSERT-V0COSSEG-PREM-DB-INSERT-1 */
        public void R2700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1()
        {
            /*" -1693- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_PREM VALUES (:V0CPRE-COD-EMPR , :V0CPRE-TIPSGU , :V0CPRE-CONGENER , :V0CPRE-NUM-ORDEM , :V0CPRE-NUM-APOL , :V0CPRE-NRENDOS , :V0CPRE-NRPARCEL , :V0CPRE-PRM-TAR-IX , :V0CPRE-VAL-DES-IX , :V0CPRE-OTNPRLIQ , :V0CPRE-OTNADFRA , :V0CPRE-VLCOMISIX , :V0CPRE-OTNTOTAL , :V0CPRE-SITUACAO , :V0CPRE-SIT-CONG , CURRENT TIMESTAMP , :V0CPRE-OCORHIST:VIND-OCR-HIST) END-EXEC. */

            var r2700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1 = new R2700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1()
            {
                V0CPRE_COD_EMPR = V0CPRE_COD_EMPR.ToString(),
                V0CPRE_TIPSGU = V0CPRE_TIPSGU.ToString(),
                V0CPRE_CONGENER = V0CPRE_CONGENER.ToString(),
                V0CPRE_NUM_ORDEM = V0CPRE_NUM_ORDEM.ToString(),
                V0CPRE_NUM_APOL = V0CPRE_NUM_APOL.ToString(),
                V0CPRE_NRENDOS = V0CPRE_NRENDOS.ToString(),
                V0CPRE_NRPARCEL = V0CPRE_NRPARCEL.ToString(),
                V0CPRE_PRM_TAR_IX = V0CPRE_PRM_TAR_IX.ToString(),
                V0CPRE_VAL_DES_IX = V0CPRE_VAL_DES_IX.ToString(),
                V0CPRE_OTNPRLIQ = V0CPRE_OTNPRLIQ.ToString(),
                V0CPRE_OTNADFRA = V0CPRE_OTNADFRA.ToString(),
                V0CPRE_VLCOMISIX = V0CPRE_VLCOMISIX.ToString(),
                V0CPRE_OTNTOTAL = V0CPRE_OTNTOTAL.ToString(),
                V0CPRE_SITUACAO = V0CPRE_SITUACAO.ToString(),
                V0CPRE_SIT_CONG = V0CPRE_SIT_CONG.ToString(),
                V0CPRE_OCORHIST = V0CPRE_OCORHIST.ToString(),
                VIND_OCR_HIST = VIND_OCR_HIST.ToString(),
            };

            R2700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1.Execute(r2700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-MONTA-V0COSSEG-HIST-SECTION */
        private void R2800_00_MONTA_V0COSSEG_HIST_SECTION()
        {
            /*" -1719- MOVE '2800' TO WNR-EXEC-SQL. */
            _.Move("2800", WABEND.WNR_EXEC_SQL);

            /*" -1720- MOVE ZEROS TO V0CHIS-COD-EMPR. */
            _.Move(0, V0CHIS_COD_EMPR);

            /*" -1721- MOVE V1APCD-CODCOSS TO V0CHIS-CONGENER. */
            _.Move(V1APCD_CODCOSS, V0CHIS_CONGENER);

            /*" -1722- MOVE V1HISP-NUM-APOL TO V0CHIS-NUM-APOL. */
            _.Move(V1HISP_NUM_APOL, V0CHIS_NUM_APOL);

            /*" -1723- MOVE V1HISP-NRENDOS TO V0CHIS-NRENDOS. */
            _.Move(V1HISP_NRENDOS, V0CHIS_NRENDOS);

            /*" -1725- MOVE V1HISP-NRPARCEL TO V0CHIS-NRPARCEL. */
            _.Move(V1HISP_NRPARCEL, V0CHIS_NRPARCEL);

            /*" -1727- COMPUTE WSHOST-OCORHIST = WSHOST-OCORHIST + 1. */
            WSHOST_OCORHIST.Value = WSHOST_OCORHIST + 1;

            /*" -1728- MOVE WSHOST-OCORHIST TO V0CHIS-OCORHIST. */
            _.Move(WSHOST_OCORHIST, V0CHIS_OCORHIST);

            /*" -1729- MOVE V1HISP-OPERACAO TO V0CHIS-OPERACAO. */
            _.Move(V1HISP_OPERACAO, V0CHIS_OPERACAO);

            /*" -1730- MOVE V1HISP-DTMOVTO TO V0CHIS-DTMOVTO. */
            _.Move(V1HISP_DTMOVTO, V0CHIS_DTMOVTO);

            /*" -1731- MOVE '1' TO V0CHIS-TIPSGU. */
            _.Move("1", V0CHIS_TIPSGU);

            /*" -1733- MOVE V1HISP-DTQITBCO TO V0CHIS-DTQITBCO. */
            _.Move(V1HISP_DTQITBCO, V0CHIS_DTQITBCO);

            /*" -1734- IF V1HISP-DTQITBCO = SPACES */

            if (V1HISP_DTQITBCO.IsEmpty())
            {

                /*" -1735- MOVE -1 TO VIND-DAT-QTBC */
                _.Move(-1, VIND_DAT_QTBC);

                /*" -1736- ELSE */
            }
            else
            {


                /*" -1737- MOVE +1 TO VIND-DAT-QTBC */
                _.Move(+1, VIND_DAT_QTBC);

                /*" -1739- END-IF. */
            }


            /*" -1740- MOVE '0' TO V0CHIS-SIT-FINANC */
            _.Move("0", V0CHIS_SIT_FINANC);

            /*" -1742- MOVE '0' TO V0CHIS-SIT-LIBRECUP. */
            _.Move("0", V0CHIS_SIT_LIBRECUP);

            /*" -1745- MOVE +1 TO VIND-SIT-FINC VIND-SIT-LIBR. */
            _.Move(+1, VIND_SIT_FINC, VIND_SIT_LIBR);

            /*" -1747- MOVE WSHOST-OCORHIST TO V0CHIS-NUMOCOR. */
            _.Move(WSHOST_OCORHIST, V0CHIS_NUMOCOR);

            /*" -1747- MOVE +1 TO VIND-NUM-OCOR. */
            _.Move(+1, VIND_NUM_OCOR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-INSERT-V0COSSEG-HIST-SECTION */
        private void R2900_00_INSERT_V0COSSEG_HIST_SECTION()
        {
            /*" -1760- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", WABEND.WNR_EXEC_SQL);

            /*" -1782- PERFORM R2900_00_INSERT_V0COSSEG_HIST_DB_INSERT_1 */

            R2900_00_INSERT_V0COSSEG_HIST_DB_INSERT_1();

            /*" -1785- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1786- DISPLAY 'R2900 - ERRO NO INSERT DA V0COSSEG-HISTPRE' */
                _.Display($"R2900 - ERRO NO INSERT DA V0COSSEG-HISTPRE");

                /*" -1787- DISPLAY 'CONGENERE - ' V1APCD-CODCOSS */
                _.Display($"CONGENERE - {V1APCD_CODCOSS}");

                /*" -1788- DISPLAY 'APOLICE   - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE   - {V1HISP_NUM_APOL}");

                /*" -1789- DISPLAY 'ENDOSSO   - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO   - {V1HISP_NRENDOS}");

                /*" -1790- DISPLAY 'PARCELA   - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA   - {V1HISP_NRPARCEL}");

                /*" -1791- DISPLAY 'OCOR HIST - ' V1HISP-OCORHIST */
                _.Display($"OCOR HIST - {V1HISP_OCORHIST}");

                /*" -1792- DISPLAY 'OPERACAO  - ' V1HISP-OPERACAO */
                _.Display($"OPERACAO  - {V1HISP_OPERACAO}");

                /*" -1793- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1794- ELSE */
            }
            else
            {


                /*" -1794- ADD 1 TO AC-I-V0COSSEGHISP. */
                AREA_DE_WORK.AC_I_V0COSSEGHISP.Value = AREA_DE_WORK.AC_I_V0COSSEGHISP + 1;
            }


        }

        [StopWatch]
        /*" R2900-00-INSERT-V0COSSEG-HIST-DB-INSERT-1 */
        public void R2900_00_INSERT_V0COSSEG_HIST_DB_INSERT_1()
        {
            /*" -1782- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_HISTPRE VALUES (:V0CHIS-COD-EMPR , :V0CHIS-CONGENER , :V0CHIS-NUM-APOL , :V0CHIS-NRENDOS , :V0CHIS-NRPARCEL , :V0CHIS-OCORHIST , :V0CHIS-OPERACAO , :V0CHIS-DTMOVTO , :V0CHIS-TIPSGU , :V0CHIS-PRM-TAR , :V0CHIS-VAL-DES , :V0CHIS-VLPRMLIQ , :V0CHIS-VLADIFRA , :V0CHIS-VLCOMIS , :V0CHIS-VLPRMTOT , CURRENT TIMESTAMP , :V0CHIS-DTQITBCO:VIND-DAT-QTBC, :V0CHIS-SIT-FINANC:VIND-SIT-FINC, :V0CHIS-SIT-LIBRECUP:VIND-SIT-LIBR, :V0CHIS-NUMOCOR:VIND-NUM-OCOR) END-EXEC. */

            var r2900_00_INSERT_V0COSSEG_HIST_DB_INSERT_1_Insert1 = new R2900_00_INSERT_V0COSSEG_HIST_DB_INSERT_1_Insert1()
            {
                V0CHIS_COD_EMPR = V0CHIS_COD_EMPR.ToString(),
                V0CHIS_CONGENER = V0CHIS_CONGENER.ToString(),
                V0CHIS_NUM_APOL = V0CHIS_NUM_APOL.ToString(),
                V0CHIS_NRENDOS = V0CHIS_NRENDOS.ToString(),
                V0CHIS_NRPARCEL = V0CHIS_NRPARCEL.ToString(),
                V0CHIS_OCORHIST = V0CHIS_OCORHIST.ToString(),
                V0CHIS_OPERACAO = V0CHIS_OPERACAO.ToString(),
                V0CHIS_DTMOVTO = V0CHIS_DTMOVTO.ToString(),
                V0CHIS_TIPSGU = V0CHIS_TIPSGU.ToString(),
                V0CHIS_PRM_TAR = V0CHIS_PRM_TAR.ToString(),
                V0CHIS_VAL_DES = V0CHIS_VAL_DES.ToString(),
                V0CHIS_VLPRMLIQ = V0CHIS_VLPRMLIQ.ToString(),
                V0CHIS_VLADIFRA = V0CHIS_VLADIFRA.ToString(),
                V0CHIS_VLCOMIS = V0CHIS_VLCOMIS.ToString(),
                V0CHIS_VLPRMTOT = V0CHIS_VLPRMTOT.ToString(),
                V0CHIS_DTQITBCO = V0CHIS_DTQITBCO.ToString(),
                VIND_DAT_QTBC = VIND_DAT_QTBC.ToString(),
                V0CHIS_SIT_FINANC = V0CHIS_SIT_FINANC.ToString(),
                VIND_SIT_FINC = VIND_SIT_FINC.ToString(),
                V0CHIS_SIT_LIBRECUP = V0CHIS_SIT_LIBRECUP.ToString(),
                VIND_SIT_LIBR = VIND_SIT_LIBR.ToString(),
                V0CHIS_NUMOCOR = V0CHIS_NUMOCOR.ToString(),
                VIND_NUM_OCOR = VIND_NUM_OCOR.ToString(),
            };

            R2900_00_INSERT_V0COSSEG_HIST_DB_INSERT_1_Insert1.Execute(r2900_00_INSERT_V0COSSEG_HIST_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-OPER-DIF-EMISSAO-SECTION */
        private void R3000_00_OPER_DIF_EMISSAO_SECTION()
        {
            /*" -1807- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", WABEND.WNR_EXEC_SQL);

            /*" -1808- IF WIND > 01 */

            if (AREA_DE_WORK.WIND > 01)
            {

                /*" -1810- GO TO R3000-10-OPER-DIF-EMIS. */

                R3000_10_OPER_DIF_EMIS(); //GOTO
                return;
            }


            /*" -1813- MOVE SPACES TO WTEM-ASSIST-24HS WTEM-COMIS-ACELER. */
            _.Move("", AREA_DE_WORK.WTEM_ASSIST_24HS, AREA_DE_WORK.WTEM_COMIS_ACELER);

            /*" -1815- PERFORM R3100-00-SELECT-V0HISTOPARC. */

            R3100_00_SELECT_V0HISTOPARC_SECTION();

            /*" -1816- IF V0APOL-ORGAO = 100 OR 110 */

            if (V0APOL_ORGAO.In("100", "110"))
            {

                /*" -1817- MOVE ZEROS TO V1PCOM-VLR-COMPL */
                _.Move(0, V1PCOM_VLR_COMPL);

                /*" -1818- MOVE ZEROS TO V1PCOM-VLR-COMPL-IX */
                _.Move(0, V1PCOM_VLR_COMPL_IX);

                /*" -1819- ELSE */
            }
            else
            {


                /*" -1820- IF V0APOL-RAMO = 31 */

                if (V0APOL_RAMO == 31)
                {

                    /*" -1821- PERFORM R1700-00-SELECT-V1PARC-COMPL */

                    R1700_00_SELECT_V1PARC_COMPL_SECTION();

                    /*" -1822- IF V1PCOM-VLR-COMPL NOT EQUAL ZEROS */

                    if (V1PCOM_VLR_COMPL != 00)
                    {

                        /*" -1824- MOVE 'S' TO WTEM-ASSIST-24HS. */
                        _.Move("S", AREA_DE_WORK.WTEM_ASSIST_24HS);
                    }

                }

            }


            /*" -1827- IF V0ENDO-CDFRACIO > 0 AND V0ENDO-QTPARCEL > 1 AND V3HISP-DTMOVTO NOT LESS WDTLIMITE-COMIS */

            if (V0ENDO_CDFRACIO > 0 && V0ENDO_QTPARCEL > 1 && V3HISP_DTMOVTO >= WDTLIMITE_COMIS)
            {

                /*" -1827- MOVE 'S' TO WTEM-COMIS-ACELER. */
                _.Move("S", AREA_DE_WORK.WTEM_COMIS_ACELER);
            }


            /*" -0- FLUXCONTROL_PERFORM R3000_10_OPER_DIF_EMIS */

            R3000_10_OPER_DIF_EMIS();

        }

        [StopWatch]
        /*" R3000-10-OPER-DIF-EMIS */
        private void R3000_10_OPER_DIF_EMIS(bool isPerform = false)
        {
            /*" -1833- MOVE WCODCOSS (WIND) TO V1APCD-CODCOSS. */
            _.Move(TABELA_COSSEGURO.TABL_COSSEGURO[AREA_DE_WORK.WIND].WCODCOSS, V1APCD_CODCOSS);

            /*" -1835- MOVE WORD-CEDIDO (WIND) TO V1ORDC-ORD-CEDIDO. */
            _.Move(TABELA_COSSEGURO.TABL_COSSEGURO[AREA_DE_WORK.WIND].WORD_CEDIDO, V1ORDC_ORD_CEDIDO);

            /*" -1836- MOVE WPCCOMCOS (WIND) TO V1APCD-PCCOMCOS. */
            _.Move(TABELA_COSSEGURO.TABL_COSSEGURO[AREA_DE_WORK.WIND].WPCCOMCOS, V1APCD_PCCOMCOS);

            /*" -1838- MOVE WPCPARTIC (WIND) TO V1APCD-PCPARTIC. */
            _.Move(TABELA_COSSEGURO.TABL_COSSEGURO[AREA_DE_WORK.WIND].WPCPARTIC, V1APCD_PCPARTIC);

            /*" -1840- MOVE WPCADMCOS (WIND) TO V0COSP-PCADMCOS. */
            _.Move(TABELA_COSSEGURO.TABL_COSSEGURO[AREA_DE_WORK.WIND].WPCADMCOS, V0COSP_PCADMCOS);

            /*" -1842- PERFORM R3200-00-SELECT-V1COSSEG-PREM. */

            R3200_00_SELECT_V1COSSEG_PREM_SECTION();

            /*" -1844- PERFORM R3300-00-SELECT-V0COSSEG-HISTP. */

            R3300_00_SELECT_V0COSSEG_HISTP_SECTION();

            /*" -1846- PERFORM R3400-00-PROCESSA-CALCULOS. */

            R3400_00_PROCESSA_CALCULOS_SECTION();

            /*" -1848- PERFORM R2800-00-MONTA-V0COSSEG-HIST. */

            R2800_00_MONTA_V0COSSEG_HIST_SECTION();

            /*" -1850- PERFORM R2900-00-INSERT-V0COSSEG-HIST. */

            R2900_00_INSERT_V0COSSEG_HIST_SECTION();

            /*" -1852- PERFORM R3500-00-VERIFICA-SITUACAO. */

            R3500_00_VERIFICA_SITUACAO_SECTION();

            /*" -1854- PERFORM R3600-00-UPDATE-V0COSSEG-PREM. */

            R3600_00_UPDATE_V0COSSEG_PREM_SECTION();

            /*" -1854- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-SELECT-V0HISTOPARC-SECTION */
        private void R3100_00_SELECT_V0HISTOPARC_SECTION()
        {
            /*" -1867- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", WABEND.WNR_EXEC_SQL);

            /*" -1894- PERFORM R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1 */

            R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1();

            /*" -1897- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1898- DISPLAY 'R3100 - ERRO NO SELECT DA V1HISTOPARC' */
                _.Display($"R3100 - ERRO NO SELECT DA V1HISTOPARC");

                /*" -1899- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -1900- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -1901- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                /*" -1902- DISPLAY 'OC HIST - ' V1HISP-OCORHIST */
                _.Display($"OC HIST - {V1HISP_OCORHIST}");

                /*" -1902- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3100-00-SELECT-V0HISTOPARC-DB-SELECT-1 */
        public void R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1()
        {
            /*" -1894- EXEC SQL SELECT NUM_APOLICE, NRENDOS, NRPARCEL, OCORHIST, OPERACAO, DTMOVTO, PRM_TARIFARIO, VAL_DESCONTO, VLADIFRA, VLCUSEMI INTO :V3HISP-NUM-APOL, :V3HISP-NRENDOS, :V3HISP-NRPARCEL, :V3HISP-OCORHIST, :V3HISP-OPERACAO, :V3HISP-DTMOVTO, :V3HISP-PRM-TAR, :V3HISP-VAL-DES, :V3HISP-VLADIFRA, :V3HISP-VLCUSEMI FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS AND NRPARCEL = :V1HISP-NRPARCEL AND OCORHIST = 01 AND OPERACAO < 0200 END-EXEC. */

            var r3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1 = new R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRPARCEL = V1HISP_NRPARCEL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1.Execute(r3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V3HISP_NUM_APOL, V3HISP_NUM_APOL);
                _.Move(executed_1.V3HISP_NRENDOS, V3HISP_NRENDOS);
                _.Move(executed_1.V3HISP_NRPARCEL, V3HISP_NRPARCEL);
                _.Move(executed_1.V3HISP_OCORHIST, V3HISP_OCORHIST);
                _.Move(executed_1.V3HISP_OPERACAO, V3HISP_OPERACAO);
                _.Move(executed_1.V3HISP_DTMOVTO, V3HISP_DTMOVTO);
                _.Move(executed_1.V3HISP_PRM_TAR, V3HISP_PRM_TAR);
                _.Move(executed_1.V3HISP_VAL_DES, V3HISP_VAL_DES);
                _.Move(executed_1.V3HISP_VLADIFRA, V3HISP_VLADIFRA);
                _.Move(executed_1.V3HISP_VLCUSEMI, V3HISP_VLCUSEMI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-SELECT-V1COSSEG-PREM-SECTION */
        private void R3200_00_SELECT_V1COSSEG_PREM_SECTION()
        {
            /*" -1915- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", WABEND.WNR_EXEC_SQL);

            /*" -1925- PERFORM R3200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1 */

            R3200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1();

            /*" -1940- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1941- DISPLAY 'R3200 - ERRO NO SELECT DA V1COSSEG-PREM' */
                _.Display($"R3200 - ERRO NO SELECT DA V1COSSEG-PREM");

                /*" -1942- DISPLAY 'CONGENERE - ' V1APCD-CODCOSS */
                _.Display($"CONGENERE - {V1APCD_CODCOSS}");

                /*" -1943- DISPLAY 'NUM ORDEM - ' V1ORDC-ORD-CEDIDO */
                _.Display($"NUM ORDEM - {V1ORDC_ORD_CEDIDO}");

                /*" -1944- DISPLAY 'APOLICE   - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE   - {V1HISP_NUM_APOL}");

                /*" -1945- DISPLAY 'ENDOSSO   - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO   - {V1HISP_NRENDOS}");

                /*" -1946- DISPLAY 'PARCELA   - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA   - {V1HISP_NRPARCEL}");

                /*" -1947- DISPLAY 'OC HIST   - ' V1HISP-OCORHIST */
                _.Display($"OC HIST   - {V1HISP_OCORHIST}");

                /*" -1947- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3200-00-SELECT-V1COSSEG-PREM-DB-SELECT-1 */
        public void R3200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1()
        {
            /*" -1925- EXEC SQL SELECT OCORHIST INTO :WSHOST-OCORHIST FROM SEGUROS.V1COSSEG_PREM WHERE TIPSGU = '1' AND CONGENER = :V1APCD-CODCOSS AND NUM_ORDEM = :V1ORDC-ORD-CEDIDO AND NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS AND NRPARCEL = :V1HISP-NRPARCEL END-EXEC. */

            var r3200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1 = new R3200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1()
            {
                V1ORDC_ORD_CEDIDO = V1ORDC_ORD_CEDIDO.ToString(),
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRPARCEL = V1HISP_NRPARCEL.ToString(),
                V1APCD_CODCOSS = V1APCD_CODCOSS.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R3200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1.Execute(r3200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WSHOST_OCORHIST, WSHOST_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-SELECT-V0COSSEG-HISTP-SECTION */
        private void R3300_00_SELECT_V0COSSEG_HISTP_SECTION()
        {
            /*" -1960- MOVE '3300' TO WNR-EXEC-SQL. */
            _.Move("3300", WABEND.WNR_EXEC_SQL);

            /*" -1991- PERFORM R3300_00_SELECT_V0COSSEG_HISTP_DB_SELECT_1 */

            R3300_00_SELECT_V0COSSEG_HISTP_DB_SELECT_1();

            /*" -1994- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1995- DISPLAY 'R3300 - ERRO NO SELECT DA V1COSSEG-HISTPRE' */
                _.Display($"R3300 - ERRO NO SELECT DA V1COSSEG-HISTPRE");

                /*" -1996- DISPLAY 'CONGENERE - ' V1APCD-CODCOSS */
                _.Display($"CONGENERE - {V1APCD_CODCOSS}");

                /*" -1997- DISPLAY 'APOLICE   - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE   - {V1HISP_NUM_APOL}");

                /*" -1998- DISPLAY 'ENDOSSO   - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO   - {V1HISP_NRENDOS}");

                /*" -1999- DISPLAY 'PARCELA   - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA   - {V1HISP_NRPARCEL}");

                /*" -2000- DISPLAY 'OC HIST   - ' V1HISP-OCORHIST */
                _.Display($"OC HIST   - {V1HISP_OCORHIST}");

                /*" -2000- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3300-00-SELECT-V0COSSEG-HISTP-DB-SELECT-1 */
        public void R3300_00_SELECT_V0COSSEG_HISTP_DB_SELECT_1()
        {
            /*" -1991- EXEC SQL SELECT TIPSGU, CONGENER, NUM_APOLICE, NRENDOS, NRPARCEL, OCORHIST, OPERACAO, PRM_TARIFARIO, VAL_DESCONTO, VLADIFRA, VLCOMIS INTO :V3CHIS-TIPSGU, :V3CHIS-CONGENER, :V3CHIS-NUM-APOL, :V3CHIS-NRENDOS, :V3CHIS-NRPARCEL, :V3CHIS-OCORHIST, :V3CHIS-OPERACAO, :V3CHIS-PRM-TAR, :V3CHIS-VAL-DES, :V3CHIS-VLADIFRA, :V3CHIS-VLCOMIS FROM SEGUROS.V1COSSEG_HISTPRE WHERE TIPSGU = '1' AND CONGENER = :V1APCD-CODCOSS AND NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS AND NRPARCEL = :V1HISP-NRPARCEL AND OCORHIST = 01 AND OPERACAO < 0200 END-EXEC. */

            var r3300_00_SELECT_V0COSSEG_HISTP_DB_SELECT_1_Query1 = new R3300_00_SELECT_V0COSSEG_HISTP_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRPARCEL = V1HISP_NRPARCEL.ToString(),
                V1APCD_CODCOSS = V1APCD_CODCOSS.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R3300_00_SELECT_V0COSSEG_HISTP_DB_SELECT_1_Query1.Execute(r3300_00_SELECT_V0COSSEG_HISTP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V3CHIS_TIPSGU, V3CHIS_TIPSGU);
                _.Move(executed_1.V3CHIS_CONGENER, V3CHIS_CONGENER);
                _.Move(executed_1.V3CHIS_NUM_APOL, V3CHIS_NUM_APOL);
                _.Move(executed_1.V3CHIS_NRENDOS, V3CHIS_NRENDOS);
                _.Move(executed_1.V3CHIS_NRPARCEL, V3CHIS_NRPARCEL);
                _.Move(executed_1.V3CHIS_OCORHIST, V3CHIS_OCORHIST);
                _.Move(executed_1.V3CHIS_OPERACAO, V3CHIS_OPERACAO);
                _.Move(executed_1.V3CHIS_PRM_TAR, V3CHIS_PRM_TAR);
                _.Move(executed_1.V3CHIS_VAL_DES, V3CHIS_VAL_DES);
                _.Move(executed_1.V3CHIS_VLADIFRA, V3CHIS_VLADIFRA);
                _.Move(executed_1.V3CHIS_VLCOMIS, V3CHIS_VLCOMIS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-PROCESSA-CALCULOS-SECTION */
        private void R3400_00_PROCESSA_CALCULOS_SECTION()
        {
            /*" -2013- MOVE '3400' TO WNR-EXEC-SQL. */
            _.Move("3400", WABEND.WNR_EXEC_SQL);

            /*" -2018- COMPUTE WPROPORCAO ROUNDED = V1HISP-PRM-TAR / V3HISP-PRM-TAR ON SIZE ERROR MOVE ZEROS TO WPROPORCAO END-COMPUTE. */
            if (V3HISP_PRM_TAR.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROPORCAO);
            else

                AREA_DE_WORK.WPROPORCAO.Value = V1HISP_PRM_TAR / V3HISP_PRM_TAR;

            /*" -2021- COMPUTE V0CHIS-PRM-TAR ROUNDED = V3CHIS-PRM-TAR * WPROPORCAO. */
            V0CHIS_PRM_TAR.Value = V3CHIS_PRM_TAR * AREA_DE_WORK.WPROPORCAO;

            /*" -2024- COMPUTE V0CHIS-VAL-DES ROUNDED = V3CHIS-VAL-DES * WPROPORCAO. */
            V0CHIS_VAL_DES.Value = V3CHIS_VAL_DES * AREA_DE_WORK.WPROPORCAO;

            /*" -2027- COMPUTE V0CHIS-VLPRMLIQ = V0CHIS-PRM-TAR - V0CHIS-VAL-DES. */
            V0CHIS_VLPRMLIQ.Value = V0CHIS_PRM_TAR - V0CHIS_VAL_DES;

            /*" -2030- COMPUTE V0CHIS-VLADIFRA ROUNDED = V3CHIS-VLADIFRA * WPROPORCAO. */
            V0CHIS_VLADIFRA.Value = V3CHIS_VLADIFRA * AREA_DE_WORK.WPROPORCAO;

            /*" -2033- COMPUTE V0CHIS-VLCOMIS ROUNDED = V3CHIS-VLCOMIS * WPROPORCAO. */
            V0CHIS_VLCOMIS.Value = V3CHIS_VLCOMIS * AREA_DE_WORK.WPROPORCAO;

            /*" -2035- COMPUTE V0CHIS-VLPRMTOT = V0CHIS-VLPRMLIQ + V0CHIS-VLADIFRA - V0CHIS-VLCOMIS. */
            V0CHIS_VLPRMTOT.Value = V0CHIS_VLPRMLIQ + V0CHIS_VLADIFRA - V0CHIS_VLCOMIS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-VERIFICA-SITUACAO-SECTION */
        private void R3500_00_VERIFICA_SITUACAO_SECTION()
        {
            /*" -2048- MOVE '3500' TO WNR-EXEC-SQL. */
            _.Move("3500", WABEND.WNR_EXEC_SQL);

            /*" -2049- IF WTIPO-OPERACAO EQUAL 02 */

            if (AREA_DE_WORK.FILLER_0.WTIPO_OPERACAO == 02)
            {

                /*" -2050- MOVE '1' TO WSHOST-SITUACAO */
                _.Move("1", WSHOST_SITUACAO);

                /*" -2051- ELSE */
            }
            else
            {


                /*" -2052- IF WTIPO-OPERACAO EQUAL 03 OR 05 OR 08 */

                if (AREA_DE_WORK.FILLER_0.WTIPO_OPERACAO.In("03", "05", "08"))
                {

                    /*" -2053- MOVE '0' TO WSHOST-SITUACAO */
                    _.Move("0", WSHOST_SITUACAO);

                    /*" -2054- ELSE */
                }
                else
                {


                    /*" -2055- IF WTIPO-OPERACAO EQUAL 04 */

                    if (AREA_DE_WORK.FILLER_0.WTIPO_OPERACAO == 04)
                    {

                        /*" -2056- MOVE '2' TO WSHOST-SITUACAO */
                        _.Move("2", WSHOST_SITUACAO);

                        /*" -2057- ELSE */
                    }
                    else
                    {


                        /*" -2058- DISPLAY 'R3500 -FAIXA DE OPERACAO NAO PREVISTA P/ SITUACAO' */
                        _.Display($"R3500 -FAIXA DE OPERACAO NAO PREVISTA P/ SITUACAO");

                        /*" -2059- DISPLAY 'APOLICE  - ' V1HISP-NUM-APOL */
                        _.Display($"APOLICE  - {V1HISP_NUM_APOL}");

                        /*" -2060- DISPLAY 'ENDOSSO  - ' V1HISP-NRENDOS */
                        _.Display($"ENDOSSO  - {V1HISP_NRENDOS}");

                        /*" -2061- DISPLAY 'PARCELA  - ' V1HISP-NRPARCEL */
                        _.Display($"PARCELA  - {V1HISP_NRPARCEL}");

                        /*" -2062- DISPLAY 'OC HIST  - ' V1HISP-OCORHIST */
                        _.Display($"OC HIST  - {V1HISP_OCORHIST}");

                        /*" -2063- DISPLAY 'OPERACAO - ' V1HISP-OPERACAO */
                        _.Display($"OPERACAO - {V1HISP_OPERACAO}");

                        /*" -2063- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R3600-00-UPDATE-V0COSSEG-PREM-SECTION */
        private void R3600_00_UPDATE_V0COSSEG_PREM_SECTION()
        {
            /*" -2076- MOVE '3600' TO WNR-EXEC-SQL. */
            _.Move("3600", WABEND.WNR_EXEC_SQL);

            /*" -2087- PERFORM R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1 */

            R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1();

            /*" -2090- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2091- DISPLAY 'R3600 - ERRO NO UPDATE DA V0COSSEG-PREM' */
                _.Display($"R3600 - ERRO NO UPDATE DA V0COSSEG-PREM");

                /*" -2092- DISPLAY 'CONGENERE - ' V1APCD-CODCOSS */
                _.Display($"CONGENERE - {V1APCD_CODCOSS}");

                /*" -2093- DISPLAY 'NUM ORDEM - ' V1ORDC-ORD-CEDIDO */
                _.Display($"NUM ORDEM - {V1ORDC_ORD_CEDIDO}");

                /*" -2094- DISPLAY 'APOLICE   - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE   - {V1HISP_NUM_APOL}");

                /*" -2095- DISPLAY 'ENDOSSO   - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO   - {V1HISP_NRENDOS}");

                /*" -2096- DISPLAY 'PARCELA   - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA   - {V1HISP_NRPARCEL}");

                /*" -2097- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2098- ELSE */
            }
            else
            {


                /*" -2098- ADD 1 TO AC-U-V0COSSEGPREM. */
                AREA_DE_WORK.AC_U_V0COSSEGPREM.Value = AREA_DE_WORK.AC_U_V0COSSEGPREM + 1;
            }


        }

        [StopWatch]
        /*" R3600-00-UPDATE-V0COSSEG-PREM-DB-UPDATE-1 */
        public void R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1()
        {
            /*" -2087- EXEC SQL UPDATE SEGUROS.V0COSSEG_PREM SET OCORHIST = :WSHOST-OCORHIST , SITUACAO = :WSHOST-SITUACAO , TIMESTAMP = CURRENT TIMESTAMP WHERE TIPSGU = '1' AND CONGENER = :V1APCD-CODCOSS AND NUM_ORDEM = :V1ORDC-ORD-CEDIDO AND NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS AND NRPARCEL = :V1HISP-NRPARCEL END-EXEC. */

            var r3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1 = new R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1()
            {
                WSHOST_OCORHIST = WSHOST_OCORHIST.ToString(),
                WSHOST_SITUACAO = WSHOST_SITUACAO.ToString(),
                V1ORDC_ORD_CEDIDO = V1ORDC_ORD_CEDIDO.ToString(),
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRPARCEL = V1HISP_NRPARCEL.ToString(),
                V1APCD_CODCOSS = V1APCD_CODCOSS.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1.Execute(r3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TRATA-INTEGRIDADE-SECTION */
        private void R4000_00_TRATA_INTEGRIDADE_SECTION()
        {
            /*" -2111- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", WABEND.WNR_EXEC_SQL);

            /*" -2113- PERFORM R4100-00-DECLARE-V2HISTOPARC. */

            R4100_00_DECLARE_V2HISTOPARC_SECTION();

            /*" -2115- PERFORM R4150-00-FETCH-V2HISTOPARC. */

            R4150_00_FETCH_V2HISTOPARC_SECTION();

            /*" -2116- IF WFIM-V2HISTOPARC NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V2HISTOPARC.IsEmpty())
            {

                /*" -2117- DISPLAY 'R4000 -  BASE DE DADOS INCORRETA ***' */
                _.Display($"R4000 -  BASE DE DADOS INCORRETA ***");

                /*" -2118- DISPLAY '***** -  NAO EXISTE OPERACAO 101 ***' */
                _.Display($"***** -  NAO EXISTE OPERACAO 101 ***");

                /*" -2119- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -2120- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -2121- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                /*" -2123- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2125- MOVE ZEROS TO V2CHIS-OCORHIST. */
            _.Move(0, V2CHIS_OCORHIST);

            /*" -2128- PERFORM R4200-00-PROCESSA-V2HISTOPARC UNTIL WFIM-V2HISTOPARC NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V2HISTOPARC.IsEmpty()))
            {

                R4200_00_PROCESSA_V2HISTOPARC_SECTION();
            }

            /*" -2128- PERFORM R4800-00-UPDATE-V0COSSEG-PREM. */

            R4800_00_UPDATE_V0COSSEG_PREM_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-DECLARE-V2HISTOPARC-SECTION */
        private void R4100_00_DECLARE_V2HISTOPARC_SECTION()
        {
            /*" -2141- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", WABEND.WNR_EXEC_SQL);

            /*" -2171- PERFORM R4100_00_DECLARE_V2HISTOPARC_DB_DECLARE_1 */

            R4100_00_DECLARE_V2HISTOPARC_DB_DECLARE_1();

            /*" -2173- PERFORM R4100_00_DECLARE_V2HISTOPARC_DB_OPEN_1 */

            R4100_00_DECLARE_V2HISTOPARC_DB_OPEN_1();

            /*" -2176- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2177- DISPLAY 'R4100 - ERRO NO DECLARE DA V2HISTOPARC' */
                _.Display($"R4100 - ERRO NO DECLARE DA V2HISTOPARC");

                /*" -2178- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2179- ELSE */
            }
            else
            {


                /*" -2179- MOVE SPACES TO WFIM-V2HISTOPARC. */
                _.Move("", AREA_DE_WORK.WFIM_V2HISTOPARC);
            }


        }

        [StopWatch]
        /*" R4100-00-DECLARE-V2HISTOPARC-DB-OPEN-1 */
        public void R4100_00_DECLARE_V2HISTOPARC_DB_OPEN_1()
        {
            /*" -2173- EXEC SQL OPEN V2HISTOPARC END-EXEC. */

            V2HISTOPARC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4150-00-FETCH-V2HISTOPARC-SECTION */
        private void R4150_00_FETCH_V2HISTOPARC_SECTION()
        {
            /*" -2190- MOVE '4150' TO WNR-EXEC-SQL. */
            _.Move("4150", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R4150_10_LER_V2HISTOPARC */

            R4150_10_LER_V2HISTOPARC();

        }

        [StopWatch]
        /*" R4150-10-LER-V2HISTOPARC */
        private void R4150_10_LER_V2HISTOPARC(bool isPerform = false)
        {
            /*" -2210- PERFORM R4150_10_LER_V2HISTOPARC_DB_FETCH_1 */

            R4150_10_LER_V2HISTOPARC_DB_FETCH_1();

            /*" -2213- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2214- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2215- MOVE 'S' TO WFIM-V2HISTOPARC */
                    _.Move("S", AREA_DE_WORK.WFIM_V2HISTOPARC);

                    /*" -2215- PERFORM R4150_10_LER_V2HISTOPARC_DB_CLOSE_1 */

                    R4150_10_LER_V2HISTOPARC_DB_CLOSE_1();

                    /*" -2217- GO TO R4150-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R4150_99_SAIDA*/ //GOTO
                    return;

                    /*" -2218- ELSE */
                }
                else
                {


                    /*" -2219- DISPLAY 'R4150 - ERRO NO FETCH DA V2HISTOPARC' */
                    _.Display($"R4150 - ERRO NO FETCH DA V2HISTOPARC");

                    /*" -2220- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                    _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                    /*" -2221- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                    _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                    /*" -2222- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                    _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                    /*" -2223- DISPLAY 'OC HIST - ' V2HISP-OCORHIST */
                    _.Display($"OC HIST - {V2HISP_OCORHIST}");

                    /*" -2224- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2225- END-IF */
                }


                /*" -2226- ELSE */
            }
            else
            {


                /*" -2227- IF VIND-DTQITBCO < ZEROS */

                if (VIND_DTQITBCO < 00)
                {

                    /*" -2228- MOVE SPACES TO V2HISP-DTQITBCO */
                    _.Move("", V2HISP_DTQITBCO);

                    /*" -2229- END-IF */
                }


                /*" -2231- END-IF. */
            }


            /*" -2233- MOVE V2HISP-OPERACAO TO W2OPERACAO. */
            _.Move(V2HISP_OPERACAO, AREA_DE_WORK.W2OPERACAO);

            /*" -2234- IF W2TIPO-OPERACAO = 06 OR 07 OR 09 OR 10 */

            if (AREA_DE_WORK.FILLER_2.W2TIPO_OPERACAO.In("06", "07", "09", "10"))
            {

                /*" -2235- GO TO R4150-10-LER-V2HISTOPARC */
                new Task(() => R4150_10_LER_V2HISTOPARC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -2236- ELSE */
            }
            else
            {


                /*" -2237- ADD 1 TO AC-L-V1HISTOPARC */
                AREA_DE_WORK.AC_L_V1HISTOPARC.Value = AREA_DE_WORK.AC_L_V1HISTOPARC + 1;

                /*" -2237- END-IF. */
            }


        }

        [StopWatch]
        /*" R4150-10-LER-V2HISTOPARC-DB-FETCH-1 */
        public void R4150_10_LER_V2HISTOPARC_DB_FETCH_1()
        {
            /*" -2210- EXEC SQL FETCH V2HISTOPARC INTO :V2HISP-NUM-APOL , :V2HISP-NRENDOS , :V2HISP-NRPARCEL , :V2HISP-OCORHIST , :V2HISP-OPERACAO , :V2HISP-DTMOVTO , :V2HISP-PRM-TAR , :V2HISP-VAL-DES , :V2HISP-VLADIFRA , :V2HISP-VLCUSEMI , :V2HISP-DTQITBCO:VIND-DTQITBCO, :V2PARC-PRM-TAR , :V2PARC-VAL-DES , :V2PARC-OTNADFRA , :V2PARC-OTNCUSTO END-EXEC. */

            if (V2HISTOPARC.Fetch())
            {
                _.Move(V2HISTOPARC.V2HISP_NUM_APOL, V2HISP_NUM_APOL);
                _.Move(V2HISTOPARC.V2HISP_NRENDOS, V2HISP_NRENDOS);
                _.Move(V2HISTOPARC.V2HISP_NRPARCEL, V2HISP_NRPARCEL);
                _.Move(V2HISTOPARC.V2HISP_OCORHIST, V2HISP_OCORHIST);
                _.Move(V2HISTOPARC.V2HISP_OPERACAO, V2HISP_OPERACAO);
                _.Move(V2HISTOPARC.V2HISP_DTMOVTO, V2HISP_DTMOVTO);
                _.Move(V2HISTOPARC.V2HISP_PRM_TAR, V2HISP_PRM_TAR);
                _.Move(V2HISTOPARC.V2HISP_VAL_DES, V2HISP_VAL_DES);
                _.Move(V2HISTOPARC.V2HISP_VLADIFRA, V2HISP_VLADIFRA);
                _.Move(V2HISTOPARC.V2HISP_VLCUSEMI, V2HISP_VLCUSEMI);
                _.Move(V2HISTOPARC.V2HISP_DTQITBCO, V2HISP_DTQITBCO);
                _.Move(V2HISTOPARC.VIND_DTQITBCO, VIND_DTQITBCO);
                _.Move(V2HISTOPARC.V2PARC_PRM_TAR, V2PARC_PRM_TAR);
                _.Move(V2HISTOPARC.V2PARC_VAL_DES, V2PARC_VAL_DES);
                _.Move(V2HISTOPARC.V2PARC_OTNADFRA, V2PARC_OTNADFRA);
                _.Move(V2HISTOPARC.V2PARC_OTNCUSTO, V2PARC_OTNCUSTO);
            }

        }

        [StopWatch]
        /*" R4150-10-LER-V2HISTOPARC-DB-CLOSE-1 */
        public void R4150_10_LER_V2HISTOPARC_DB_CLOSE_1()
        {
            /*" -2215- EXEC SQL CLOSE V2HISTOPARC END-EXEC */

            V2HISTOPARC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4150_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-PROCESSA-V2HISTOPARC-SECTION */
        private void R4200_00_PROCESSA_V2HISTOPARC_SECTION()
        {
            /*" -2250- MOVE '4200' TO WNR-EXEC-SQL. */
            _.Move("4200", WABEND.WNR_EXEC_SQL);

            /*" -2252- PERFORM R4300-00-CALCULA-VALORES. */

            R4300_00_CALCULA_VALORES_SECTION();

            /*" -2253- IF W2TIPO-OPERACAO = 01 */

            if (AREA_DE_WORK.FILLER_2.W2TIPO_OPERACAO == 01)
            {

                /*" -2254- PERFORM R4400-00-MONTA-V0COSSEG-PREM */

                R4400_00_MONTA_V0COSSEG_PREM_SECTION();

                /*" -2255- PERFORM R4500-00-INSERT-V0COSSEG-PREM */

                R4500_00_INSERT_V0COSSEG_PREM_SECTION();

                /*" -2257- END-IF. */
            }


            /*" -2259- PERFORM R4600-00-MONTA-V0COSSEG-HPRE. */

            R4600_00_MONTA_V0COSSEG_HPRE_SECTION();

            /*" -2261- PERFORM R4700-00-INSERT-V0COSSEG-HPRE. */

            R4700_00_INSERT_V0COSSEG_HPRE_SECTION();

            /*" -2261- PERFORM R4150-00-FETCH-V2HISTOPARC. */

            R4150_00_FETCH_V2HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-CALCULA-VALORES-SECTION */
        private void R4300_00_CALCULA_VALORES_SECTION()
        {
            /*" -2274- MOVE '4300' TO WNR-EXEC-SQL. */
            _.Move("4300", WABEND.WNR_EXEC_SQL);

            /*" -2278- COMPUTE V2CPRE-PRM-TAR-IX = V2PARC-PRM-TAR * V1APCD-PCPARTIC / 100. */
            V2CPRE_PRM_TAR_IX.Value = V2PARC_PRM_TAR * V1APCD_PCPARTIC / 100f;

            /*" -2282- COMPUTE V2CHIS-PRM-TAR = V2HISP-PRM-TAR * V1APCD-PCPARTIC / 100. */
            V2CHIS_PRM_TAR.Value = V2HISP_PRM_TAR * V1APCD_PCPARTIC / 100f;

            /*" -2286- COMPUTE V2CPRE-VAL-DES-IX = V2PARC-VAL-DES * V1APCD-PCPARTIC / 100. */
            V2CPRE_VAL_DES_IX.Value = V2PARC_VAL_DES * V1APCD_PCPARTIC / 100f;

            /*" -2290- COMPUTE V2CHIS-VAL-DES = V2HISP-VAL-DES * V1APCD-PCPARTIC / 100. */
            V2CHIS_VAL_DES.Value = V2HISP_VAL_DES * V1APCD_PCPARTIC / 100f;

            /*" -2293- COMPUTE V2CPRE-OTNPRLIQ = V2CPRE-PRM-TAR-IX - V2CPRE-VAL-DES-IX. */
            V2CPRE_OTNPRLIQ.Value = V2CPRE_PRM_TAR_IX - V2CPRE_VAL_DES_IX;

            /*" -2296- COMPUTE V2CHIS-VLPRMLIQ = V2CHIS-PRM-TAR - V2CHIS-VAL-DES. */
            V2CHIS_VLPRMLIQ.Value = V2CHIS_PRM_TAR - V2CHIS_VAL_DES;

            /*" -2300- COMPUTE V2CPRE-OTNADFRA = V2PARC-OTNADFRA * V1APCD-PCPARTIC / 100. */
            V2CPRE_OTNADFRA.Value = V2PARC_OTNADFRA * V1APCD_PCPARTIC / 100f;

            /*" -2304- COMPUTE V2CHIS-VLADIFRA = V2HISP-VLADIFRA * V1APCD-PCPARTIC / 100. */
            V2CHIS_VLADIFRA.Value = V2HISP_VLADIFRA * V1APCD_PCPARTIC / 100f;

            /*" -2305- IF V0APOL-RAMO = 31 OR 53 */

            if (V0APOL_RAMO.In("31", "53"))
            {

                /*" -2309- COMPUTE V2CPRE-VLCOMISIX = V2CPRE-OTNPRLIQ * V1APCD-PCCOMCOS / 100 */
                V2CPRE_VLCOMISIX.Value = V2CPRE_OTNPRLIQ * V1APCD_PCCOMCOS / 100f;

                /*" -2312- COMPUTE V2CHIS-VLCOMIS = V2CHIS-VLPRMLIQ * V1APCD-PCCOMCOS / 100 */
                V2CHIS_VLCOMIS.Value = V2CHIS_VLPRMLIQ * V1APCD_PCCOMCOS / 100f;

                /*" -2313- ELSE */
            }
            else
            {


                /*" -2318- COMPUTE V2CPRE-VLCOMISIX = (V2CPRE-OTNPRLIQ + V2CPRE-OTNADFRA) * V1APCD-PCCOMCOS / 100 */
                V2CPRE_VLCOMISIX.Value = (V2CPRE_OTNPRLIQ + V2CPRE_OTNADFRA) * V1APCD_PCCOMCOS / 100f;

                /*" -2322- COMPUTE V2CHIS-VLCOMIS = (V2CHIS-VLPRMLIQ + V2CHIS-VLADIFRA) * V1APCD-PCCOMCOS / 100 */
                V2CHIS_VLCOMIS.Value = (V2CHIS_VLPRMLIQ + V2CHIS_VLADIFRA) * V1APCD_PCCOMCOS / 100f;

                /*" -2324- END-IF. */
            }


            /*" -2328- COMPUTE V2CPRE-OTNTOTAL = V2CPRE-OTNPRLIQ + V2CPRE-OTNADFRA - V2CPRE-VLCOMISIX. */
            V2CPRE_OTNTOTAL.Value = V2CPRE_OTNPRLIQ + V2CPRE_OTNADFRA - V2CPRE_VLCOMISIX;

            /*" -2332- COMPUTE V2CHIS-VLPRMTOT = V2CHIS-VLPRMLIQ + V2CHIS-VLADIFRA - V2CHIS-VLCOMIS. */
            V2CHIS_VLPRMTOT.Value = V2CHIS_VLPRMLIQ + V2CHIS_VLADIFRA - V2CHIS_VLCOMIS;

            /*" -2333- IF V0ENDO-CORRECAO = '1' OR '3' */

            if (V0ENDO_CORRECAO.In("1", "3"))
            {

                /*" -2334- MOVE ZEROS TO V2CPRE-PRM-TAR-IX */
                _.Move(0, V2CPRE_PRM_TAR_IX);

                /*" -2335- MOVE V2CHIS-PRM-TAR TO V2CPRE-PRM-TAR-IX */
                _.Move(V2CHIS_PRM_TAR, V2CPRE_PRM_TAR_IX);

                /*" -2336- MOVE ZEROS TO V2CPRE-VAL-DES-IX */
                _.Move(0, V2CPRE_VAL_DES_IX);

                /*" -2337- MOVE V2CHIS-VAL-DES TO V2CPRE-VAL-DES-IX */
                _.Move(V2CHIS_VAL_DES, V2CPRE_VAL_DES_IX);

                /*" -2338- MOVE ZEROS TO V2CPRE-OTNPRLIQ */
                _.Move(0, V2CPRE_OTNPRLIQ);

                /*" -2339- MOVE V2CHIS-VLPRMLIQ TO V2CPRE-OTNPRLIQ */
                _.Move(V2CHIS_VLPRMLIQ, V2CPRE_OTNPRLIQ);

                /*" -2340- MOVE ZEROS TO V2CPRE-OTNADFRA */
                _.Move(0, V2CPRE_OTNADFRA);

                /*" -2341- MOVE V2CHIS-VLADIFRA TO V2CPRE-OTNADFRA */
                _.Move(V2CHIS_VLADIFRA, V2CPRE_OTNADFRA);

                /*" -2342- MOVE ZEROS TO V2CPRE-VLCOMISIX */
                _.Move(0, V2CPRE_VLCOMISIX);

                /*" -2343- MOVE V2CHIS-VLCOMIS TO V2CPRE-VLCOMISIX */
                _.Move(V2CHIS_VLCOMIS, V2CPRE_VLCOMISIX);

                /*" -2344- MOVE ZEROS TO V2CPRE-OTNTOTAL */
                _.Move(0, V2CPRE_OTNTOTAL);

                /*" -2345- MOVE V2CHIS-VLPRMTOT TO V2CPRE-OTNTOTAL */
                _.Move(V2CHIS_VLPRMTOT, V2CPRE_OTNTOTAL);

                /*" -2345- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R4400-00-MONTA-V0COSSEG-PREM-SECTION */
        private void R4400_00_MONTA_V0COSSEG_PREM_SECTION()
        {
            /*" -2358- MOVE '4400' TO WNR-EXEC-SQL. */
            _.Move("4400", WABEND.WNR_EXEC_SQL);

            /*" -2359- MOVE ZEROS TO V2CPRE-COD-EMPR. */
            _.Move(0, V2CPRE_COD_EMPR);

            /*" -2360- MOVE '1' TO V2CPRE-TIPSGU. */
            _.Move("1", V2CPRE_TIPSGU);

            /*" -2361- MOVE V1APCD-CODCOSS TO V2CPRE-CONGENER. */
            _.Move(V1APCD_CODCOSS, V2CPRE_CONGENER);

            /*" -2362- MOVE V1ORDC-ORD-CEDIDO TO V2CPRE-NUM-ORDEM. */
            _.Move(V1ORDC_ORD_CEDIDO, V2CPRE_NUM_ORDEM);

            /*" -2363- MOVE V1HISP-NUM-APOL TO V2CPRE-NUM-APOL. */
            _.Move(V1HISP_NUM_APOL, V2CPRE_NUM_APOL);

            /*" -2364- MOVE V1HISP-NRENDOS TO V2CPRE-NRENDOS. */
            _.Move(V1HISP_NRENDOS, V2CPRE_NRENDOS);

            /*" -2365- MOVE V1HISP-NRPARCEL TO V2CPRE-NRPARCEL. */
            _.Move(V1HISP_NRPARCEL, V2CPRE_NRPARCEL);

            /*" -2366- MOVE '0' TO V2CPRE-SITUACAO. */
            _.Move("0", V2CPRE_SITUACAO);

            /*" -2367- MOVE '0' TO V2CPRE-SIT-CONG. */
            _.Move("0", V2CPRE_SIT_CONG);

            /*" -2369- MOVE 01 TO V2CPRE-OCORHIST. */
            _.Move(01, V2CPRE_OCORHIST);

            /*" -2369- MOVE +1 TO VIND-OCR-HIST. */
            _.Move(+1, VIND_OCR_HIST);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-INSERT-V0COSSEG-PREM-SECTION */
        private void R4500_00_INSERT_V0COSSEG_PREM_SECTION()
        {
            /*" -2382- MOVE '4500' TO WNR-EXEC-SQL. */
            _.Move("4500", WABEND.WNR_EXEC_SQL);

            /*" -2401- PERFORM R4500_00_INSERT_V0COSSEG_PREM_DB_INSERT_1 */

            R4500_00_INSERT_V0COSSEG_PREM_DB_INSERT_1();

            /*" -2404- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2405- DISPLAY 'R4500 - ERRO NO INSERT DA V0COSSEG-PREM' */
                _.Display($"R4500 - ERRO NO INSERT DA V0COSSEG-PREM");

                /*" -2406- DISPLAY 'TP SEGURO - ' V2CPRE-TIPSGU */
                _.Display($"TP SEGURO - {V2CPRE_TIPSGU}");

                /*" -2407- DISPLAY 'CONGENERE - ' V2CPRE-CONGENER */
                _.Display($"CONGENERE - {V2CPRE_CONGENER}");

                /*" -2408- DISPLAY 'NUM ORDEM - ' V2CPRE-NUM-ORDEM */
                _.Display($"NUM ORDEM - {V2CPRE_NUM_ORDEM}");

                /*" -2409- DISPLAY 'APOLICE   - ' V2CPRE-NUM-APOL */
                _.Display($"APOLICE   - {V2CPRE_NUM_APOL}");

                /*" -2410- DISPLAY 'ENDOSSO   - ' V2CPRE-NRENDOS */
                _.Display($"ENDOSSO   - {V2CPRE_NRENDOS}");

                /*" -2411- DISPLAY 'PARCELA   - ' V2CPRE-NRPARCEL */
                _.Display($"PARCELA   - {V2CPRE_NRPARCEL}");

                /*" -2412- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2413- ELSE */
            }
            else
            {


                /*" -2413- ADD 1 TO AC-I-V0COSSEGPREM. */
                AREA_DE_WORK.AC_I_V0COSSEGPREM.Value = AREA_DE_WORK.AC_I_V0COSSEGPREM + 1;
            }


        }

        [StopWatch]
        /*" R4500-00-INSERT-V0COSSEG-PREM-DB-INSERT-1 */
        public void R4500_00_INSERT_V0COSSEG_PREM_DB_INSERT_1()
        {
            /*" -2401- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_PREM VALUES (:V2CPRE-COD-EMPR , :V2CPRE-TIPSGU , :V2CPRE-CONGENER , :V2CPRE-NUM-ORDEM , :V2CPRE-NUM-APOL , :V2CPRE-NRENDOS , :V2CPRE-NRPARCEL , :V2CPRE-PRM-TAR-IX , :V2CPRE-VAL-DES-IX , :V2CPRE-OTNPRLIQ , :V2CPRE-OTNADFRA , :V2CPRE-VLCOMISIX , :V2CPRE-OTNTOTAL , :V2CPRE-SITUACAO , :V2CPRE-SIT-CONG , CURRENT TIMESTAMP , :V2CPRE-OCORHIST:VIND-OCR-HIST) END-EXEC. */

            var r4500_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1 = new R4500_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1()
            {
                V2CPRE_COD_EMPR = V2CPRE_COD_EMPR.ToString(),
                V2CPRE_TIPSGU = V2CPRE_TIPSGU.ToString(),
                V2CPRE_CONGENER = V2CPRE_CONGENER.ToString(),
                V2CPRE_NUM_ORDEM = V2CPRE_NUM_ORDEM.ToString(),
                V2CPRE_NUM_APOL = V2CPRE_NUM_APOL.ToString(),
                V2CPRE_NRENDOS = V2CPRE_NRENDOS.ToString(),
                V2CPRE_NRPARCEL = V2CPRE_NRPARCEL.ToString(),
                V2CPRE_PRM_TAR_IX = V2CPRE_PRM_TAR_IX.ToString(),
                V2CPRE_VAL_DES_IX = V2CPRE_VAL_DES_IX.ToString(),
                V2CPRE_OTNPRLIQ = V2CPRE_OTNPRLIQ.ToString(),
                V2CPRE_OTNADFRA = V2CPRE_OTNADFRA.ToString(),
                V2CPRE_VLCOMISIX = V2CPRE_VLCOMISIX.ToString(),
                V2CPRE_OTNTOTAL = V2CPRE_OTNTOTAL.ToString(),
                V2CPRE_SITUACAO = V2CPRE_SITUACAO.ToString(),
                V2CPRE_SIT_CONG = V2CPRE_SIT_CONG.ToString(),
                V2CPRE_OCORHIST = V2CPRE_OCORHIST.ToString(),
                VIND_OCR_HIST = VIND_OCR_HIST.ToString(),
            };

            R4500_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1.Execute(r4500_00_INSERT_V0COSSEG_PREM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_99_SAIDA*/

        [StopWatch]
        /*" R4600-00-MONTA-V0COSSEG-HPRE-SECTION */
        private void R4600_00_MONTA_V0COSSEG_HPRE_SECTION()
        {
            /*" -2426- MOVE '4600' TO WNR-EXEC-SQL. */
            _.Move("4600", WABEND.WNR_EXEC_SQL);

            /*" -2427- MOVE ZEROS TO V2CHIS-COD-EMPR. */
            _.Move(0, V2CHIS_COD_EMPR);

            /*" -2428- MOVE V1APCD-CODCOSS TO V2CHIS-CONGENER. */
            _.Move(V1APCD_CODCOSS, V2CHIS_CONGENER);

            /*" -2429- MOVE V1HISP-NUM-APOL TO V2CHIS-NUM-APOL. */
            _.Move(V1HISP_NUM_APOL, V2CHIS_NUM_APOL);

            /*" -2430- MOVE V1HISP-NRENDOS TO V2CHIS-NRENDOS. */
            _.Move(V1HISP_NRENDOS, V2CHIS_NRENDOS);

            /*" -2432- MOVE V1HISP-NRPARCEL TO V2CHIS-NRPARCEL. */
            _.Move(V1HISP_NRPARCEL, V2CHIS_NRPARCEL);

            /*" -2434- COMPUTE V2CHIS-OCORHIST = V2CHIS-OCORHIST + 1. */
            V2CHIS_OCORHIST.Value = V2CHIS_OCORHIST + 1;

            /*" -2435- MOVE V2HISP-OPERACAO TO V2CHIS-OPERACAO. */
            _.Move(V2HISP_OPERACAO, V2CHIS_OPERACAO);

            /*" -2436- MOVE V2HISP-DTMOVTO TO V2CHIS-DTMOVTO. */
            _.Move(V2HISP_DTMOVTO, V2CHIS_DTMOVTO);

            /*" -2438- MOVE '1' TO V2CHIS-TIPSGU. */
            _.Move("1", V2CHIS_TIPSGU);

            /*" -2440- MOVE V2HISP-DTQITBCO TO V2CHIS-DTQITBCO. */
            _.Move(V2HISP_DTQITBCO, V2CHIS_DTQITBCO);

            /*" -2441- IF V2HISP-DTQITBCO = SPACES */

            if (V2HISP_DTQITBCO.IsEmpty())
            {

                /*" -2442- MOVE -1 TO VIND-DTQITBCO */
                _.Move(-1, VIND_DTQITBCO);

                /*" -2443- ELSE */
            }
            else
            {


                /*" -2444- MOVE +1 TO VIND-DTQITBCO */
                _.Move(+1, VIND_DTQITBCO);

                /*" -2446- END-IF. */
            }


            /*" -2449- MOVE '0' TO V2CHIS-SIT-FINANC V2CHIS-SIT-LIBRECUP. */
            _.Move("0", V2CHIS_SIT_FINANC, V2CHIS_SIT_LIBRECUP);

            /*" -2452- MOVE +1 TO VIND-SIT-FINC VIND-SIT-LIBR. */
            _.Move(+1, VIND_SIT_FINC, VIND_SIT_LIBR);

            /*" -2454- MOVE V2HISP-OCORHIST TO V2CHIS-NUMOCOR. */
            _.Move(V2HISP_OCORHIST, V2CHIS_NUMOCOR);

            /*" -2454- MOVE +1 TO VIND-NUM-OCOR. */
            _.Move(+1, VIND_NUM_OCOR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4600_99_SAIDA*/

        [StopWatch]
        /*" R4700-00-INSERT-V0COSSEG-HPRE-SECTION */
        private void R4700_00_INSERT_V0COSSEG_HPRE_SECTION()
        {
            /*" -2467- MOVE '4700' TO WNR-EXEC-SQL. */
            _.Move("4700", WABEND.WNR_EXEC_SQL);

            /*" -2489- PERFORM R4700_00_INSERT_V0COSSEG_HPRE_DB_INSERT_1 */

            R4700_00_INSERT_V0COSSEG_HPRE_DB_INSERT_1();

            /*" -2492- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2493- DISPLAY 'R4700 - ERRO NO INSERT DA V0COSSEG-HISTPRE' */
                _.Display($"R4700 - ERRO NO INSERT DA V0COSSEG-HISTPRE");

                /*" -2494- DISPLAY 'CONGENERE - ' V2CHIS-CONGENER */
                _.Display($"CONGENERE - {V2CHIS_CONGENER}");

                /*" -2495- DISPLAY 'APOLICE   - ' V2CHIS-NUM-APOL */
                _.Display($"APOLICE   - {V2CHIS_NUM_APOL}");

                /*" -2496- DISPLAY 'ENDOSSO   - ' V2CHIS-NRENDOS */
                _.Display($"ENDOSSO   - {V2CHIS_NRENDOS}");

                /*" -2497- DISPLAY 'PARCELA   - ' V2CHIS-NRPARCEL */
                _.Display($"PARCELA   - {V2CHIS_NRPARCEL}");

                /*" -2498- DISPLAY 'OC HIST   - ' V2CHIS-OCORHIST */
                _.Display($"OC HIST   - {V2CHIS_OCORHIST}");

                /*" -2499- DISPLAY 'OPERACAO  - ' V2CHIS-OPERACAO */
                _.Display($"OPERACAO  - {V2CHIS_OPERACAO}");

                /*" -2500- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2501- ELSE */
            }
            else
            {


                /*" -2501- ADD 1 TO AC-I-V0COSSEGHISP. */
                AREA_DE_WORK.AC_I_V0COSSEGHISP.Value = AREA_DE_WORK.AC_I_V0COSSEGHISP + 1;
            }


        }

        [StopWatch]
        /*" R4700-00-INSERT-V0COSSEG-HPRE-DB-INSERT-1 */
        public void R4700_00_INSERT_V0COSSEG_HPRE_DB_INSERT_1()
        {
            /*" -2489- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_HISTPRE VALUES (:V2CHIS-COD-EMPR , :V2CHIS-CONGENER , :V2CHIS-NUM-APOL , :V2CHIS-NRENDOS , :V2CHIS-NRPARCEL , :V2CHIS-OCORHIST , :V2CHIS-OPERACAO , :V2CHIS-DTMOVTO , :V2CHIS-TIPSGU , :V2CHIS-PRM-TAR , :V2CHIS-VAL-DES , :V2CHIS-VLPRMLIQ , :V2CHIS-VLADIFRA , :V2CHIS-VLCOMIS , :V2CHIS-VLPRMTOT , CURRENT TIMESTAMP , :V2CHIS-DTQITBCO:VIND-DTQITBCO, :V2CHIS-SIT-FINANC:VIND-SIT-FINC, :V2CHIS-SIT-LIBRECUP:VIND-SIT-LIBR, :V2CHIS-NUMOCOR:VIND-NUM-OCOR) END-EXEC. */

            var r4700_00_INSERT_V0COSSEG_HPRE_DB_INSERT_1_Insert1 = new R4700_00_INSERT_V0COSSEG_HPRE_DB_INSERT_1_Insert1()
            {
                V2CHIS_COD_EMPR = V2CHIS_COD_EMPR.ToString(),
                V2CHIS_CONGENER = V2CHIS_CONGENER.ToString(),
                V2CHIS_NUM_APOL = V2CHIS_NUM_APOL.ToString(),
                V2CHIS_NRENDOS = V2CHIS_NRENDOS.ToString(),
                V2CHIS_NRPARCEL = V2CHIS_NRPARCEL.ToString(),
                V2CHIS_OCORHIST = V2CHIS_OCORHIST.ToString(),
                V2CHIS_OPERACAO = V2CHIS_OPERACAO.ToString(),
                V2CHIS_DTMOVTO = V2CHIS_DTMOVTO.ToString(),
                V2CHIS_TIPSGU = V2CHIS_TIPSGU.ToString(),
                V2CHIS_PRM_TAR = V2CHIS_PRM_TAR.ToString(),
                V2CHIS_VAL_DES = V2CHIS_VAL_DES.ToString(),
                V2CHIS_VLPRMLIQ = V2CHIS_VLPRMLIQ.ToString(),
                V2CHIS_VLADIFRA = V2CHIS_VLADIFRA.ToString(),
                V2CHIS_VLCOMIS = V2CHIS_VLCOMIS.ToString(),
                V2CHIS_VLPRMTOT = V2CHIS_VLPRMTOT.ToString(),
                V2CHIS_DTQITBCO = V2CHIS_DTQITBCO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                V2CHIS_SIT_FINANC = V2CHIS_SIT_FINANC.ToString(),
                VIND_SIT_FINC = VIND_SIT_FINC.ToString(),
                V2CHIS_SIT_LIBRECUP = V2CHIS_SIT_LIBRECUP.ToString(),
                VIND_SIT_LIBR = VIND_SIT_LIBR.ToString(),
                V2CHIS_NUMOCOR = V2CHIS_NUMOCOR.ToString(),
                VIND_NUM_OCOR = VIND_NUM_OCOR.ToString(),
            };

            R4700_00_INSERT_V0COSSEG_HPRE_DB_INSERT_1_Insert1.Execute(r4700_00_INSERT_V0COSSEG_HPRE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4700_99_SAIDA*/

        [StopWatch]
        /*" R4800-00-UPDATE-V0COSSEG-PREM-SECTION */
        private void R4800_00_UPDATE_V0COSSEG_PREM_SECTION()
        {
            /*" -2514- MOVE '4800' TO WNR-EXEC-SQL. */
            _.Move("4800", WABEND.WNR_EXEC_SQL);

            /*" -2522- PERFORM R4800_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1 */

            R4800_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1();

            /*" -2525- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2526- DISPLAY 'R4800 - ERRO NO UPDATE DA V0COSSEG-PREM' */
                _.Display($"R4800 - ERRO NO UPDATE DA V0COSSEG-PREM");

                /*" -2527- DISPLAY 'CONGENERE - ' V2CHIS-CONGENER */
                _.Display($"CONGENERE - {V2CHIS_CONGENER}");

                /*" -2528- DISPLAY 'NUM ORDEM - ' V2CPRE-NUM-ORDEM */
                _.Display($"NUM ORDEM - {V2CPRE_NUM_ORDEM}");

                /*" -2529- DISPLAY 'APOLICE   - ' V2CHIS-NUM-APOL */
                _.Display($"APOLICE   - {V2CHIS_NUM_APOL}");

                /*" -2530- DISPLAY 'ENDOSSO   - ' V2CHIS-NRENDOS */
                _.Display($"ENDOSSO   - {V2CHIS_NRENDOS}");

                /*" -2531- DISPLAY 'PARCELA   - ' V2CHIS-NRPARCEL */
                _.Display($"PARCELA   - {V2CHIS_NRPARCEL}");

                /*" -2531- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4800-00-UPDATE-V0COSSEG-PREM-DB-UPDATE-1 */
        public void R4800_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1()
        {
            /*" -2522- EXEC SQL UPDATE SEGUROS.V0COSSEG_PREM SET OCORHIST = :V2CHIS-OCORHIST WHERE CONGENER = :V2CHIS-CONGENER AND NUM_ORDEM = :V2CPRE-NUM-ORDEM AND NUM_APOLICE = :V2CHIS-NUM-APOL AND NRENDOS = :V2CHIS-NRENDOS AND NRPARCEL = :V2CHIS-NRPARCEL END-EXEC. */

            var r4800_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1 = new R4800_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1()
            {
                V2CHIS_OCORHIST = V2CHIS_OCORHIST.ToString(),
                V2CPRE_NUM_ORDEM = V2CPRE_NUM_ORDEM.ToString(),
                V2CHIS_CONGENER = V2CHIS_CONGENER.ToString(),
                V2CHIS_NUM_APOL = V2CHIS_NUM_APOL.ToString(),
                V2CHIS_NRPARCEL = V2CHIS_NRPARCEL.ToString(),
                V2CHIS_NRENDOS = V2CHIS_NRENDOS.ToString(),
            };

            R4800_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1.Execute(r4800_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4800_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -2544- MOVE V0SIST-DTMOVABE TO WDATA-AUX. */
            _.Move(V0SIST_DTMOVABE, AREA_DE_WORK.WDATA_AUX);

            /*" -2545- MOVE WDAT-AUX-DIA TO WDIA-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_4.WDAT_AUX_DIA, AREA_DE_WORK.WDATA_EDIT.WDIA_EDIT);

            /*" -2546- MOVE WDAT-AUX-MES TO WMES-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_4.WDAT_AUX_MES, AREA_DE_WORK.WDATA_EDIT.WMES_EDIT);

            /*" -2548- MOVE WDAT-AUX-ANO TO WANO-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_4.WDAT_AUX_ANO, AREA_DE_WORK.WDATA_EDIT.WANO_EDIT);

            /*" -2549- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -2550- DISPLAY '*   AC0011B - ATUALIZACAO DB DE COSSEGURO  *' . */
            _.Display($"*   AC0011B - ATUALIZACAO DB DE COSSEGURO  *");

            /*" -2551- DISPLAY '*   -------   ----------- -- -- ---------  *' . */
            _.Display($"*   -------   ----------- -- -- ---------  *");

            /*" -2552- DISPLAY '*             COSSEGURO CEDIDO             *' . */
            _.Display($"*             COSSEGURO CEDIDO             *");

            /*" -2553- DISPLAY '*             --------- ------             *' . */
            _.Display($"*             --------- ------             *");

            /*" -2554- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -2555- DISPLAY '*   NAO HOUVE MOVIMENTACAO NESTA DATA      *' . */
            _.Display($"*   NAO HOUVE MOVIMENTACAO NESTA DATA      *");

            /*" -2557- DISPLAY '*              ' WDATA-EDIT '                    *' . */

            $"*              {AREA_DE_WORK.WDATA_EDIT}                    *"
            .Display();

            /*" -2557- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2572- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -2574- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -2574- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2578- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2578- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}