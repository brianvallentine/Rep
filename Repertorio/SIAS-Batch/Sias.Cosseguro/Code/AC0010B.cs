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
using Sias.Cosseguro.DB2.AC0010B;

namespace Code
{
    public class AC0010B
    {
        public bool IsCall { get; set; }

        public AC0010B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  ADMINISTRACAO DE COSSEGURO         *      */
        /*"      *   PROGRAMA ...............  AC0010B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  GILSON                             *      */
        /*"      *   PROGRAMADOR ............  GILSON                             *      */
        /*"      *   DATA CODIFICACAO .......  JUNHO/1993                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  ATUALIZAR DB DE COSSEGURO CEDIDO   *      */
        /*"      *                             DOCUMENTOS QUE NAO SEJAM DO CON-   *      */
        /*"      *                             VENIO (ORGAO=10).                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW                ACESSO *      */
        /*"      * ----------------------------------- ------------------- ------ *      */
        /*"      * SISTEMAS                            V1SISTEMA           INPUT  *      */
        /*"      * HISTORICO PARCELAS                  V1HISTOPARC         INPUT  *      */
        /*"      * APOLICES                            V0APOLICE           INPUT  *      */
        /*"      * ENDOS COSSEG COBERTURA              GE-ENDOS-COSEG-COB  INPUT  *      */
        /*"      * ENDOSSOS                            V0ENDOSSO           INPUT  *      */
        /*"      * APOLICE COSSEGURO CEDIDO            V1APOLCOSCED        INPUT  *      */
        /*"      * NR. DE ORDEM COSSEG. CED.           V1ORDECOSCED        INPUT  *      */
        /*"      * PARCELAS                            V1PARCELA           INPUT  *      */
        /*"      * PARCELA COMPLEMENTO                 V1PARCELA-COMPL     INPUT  *      */
        /*"      * PLANO DE COMISSAO                   V1PLANCOMIS         INPUT  *      */
        /*"      * PREMIOS DE COSSEGURO                V1COSSEG-PREM       INPUT  *      */
        /*"      * PREMIOS DE COSSEGURO                V0COSSEG-PREM       I-O    *      */
        /*"      * HISTORICO DE COSSEGURO              V1COSSEG-HISTPRE    INPUT  *      */
        /*"      * HISTORICO DE COSSEGURO              V0COSSEG-HISTPRE    OUTPUT *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EM SET/1996 POR CARLOS ALBERTO                                *      */
        /*"      *  - INCLUSAO DA ROTINA PARA RETIRAR O VALOR DE ASSISTENCIA      *      */
        /*"      *    24 HORAS DA DISTRIBUICAO DE COSSEGURO CEDIDO.               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EM SET/2005 POR GILSON                                        *      */
        /*"      *  - INCLUSAO DA ROTINA PARA RETIRAR O VALOR DE ASSISTENCIA      *      */
        /*"      *    24 HORAS DA DISTRB. DE COSSEGURO CEDIDO DOS RAMOS 16 E 18   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ACESSAR MOVTO_HABIT COM OCORHIST DO V1HISP-OCORHIST - JAN/2006 *      */
        /*"      * - PROCURAR POR BOLDRI                                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EM 14/07/2006 POR GILSON                                      *      */
        /*"      *  - ENCERRAMENTO DA VIGENCIA DA DISTRIBUICAO DE COSSEGURO DA    *      */
        /*"      *    APOLICE 93010000890 PELA GEVID                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EM AGO/2013 POR GILSON PINTO DA SILVA - PROCURAR C86341       *      */
        /*"      *  - ALTERAR O PROGRAMA PARA DESPREZAR AS APOL/ENDS/PARC QUE TEM *      */
        /*"      *    O COSSEGURO CEDIDO TRATADOS POR RAMO E CODIGO DE COBERTURA  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EM JAN/2014 POR GILSON PINTO DA SILVA - PROCURAR 108542       *      */
        /*"      *  - ALTERAR O PROGRAMA PARA TRATAR SOMENTE OS ENDS QUE PERTENCEM*      */
        /*"      *    A APOLICE 107700000022 COM INICIO DE VIGENCIA A PARTIR DE   *      */
        /*"      *    01/12/2014, ANTES DESTA DATA DESPREZAR OS REGISTROS         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - PREPARAR A COLUNA CODIGO DE EMPRESA PARA RECEBER  *      */
        /*"      *              A INFORMACAO DO CODIGO CORRESPONDENTE             *      */
        /*"      * 03/10/2018 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 173142 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - PREPARAR A ROTINA PARA TRATAR/INCLUIR O ORGAO 300 *      */
        /*"      * 21/01/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 188194 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          VIND-NUM-ENDS            PIC S9(004)  VALUE +0 COMP.*/
        public IntBasis VIND_NUM_ENDS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77          WHOST-QTDE-REG           PIC S9(009)  VALUE +0 COMP.*/
        public IntBasis WHOST_QTDE_REG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          WHOST-OCORHIST           PIC S9(004)  VALUE +0 COMP.*/
        public IntBasis WHOST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WHOST-SITUACAO           PIC  X(001)  VALUE SPACES.*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77          V1SIST-DTMOVABE          PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1HISP-NUM-APOL          PIC S9(013)         COMP-3.*/
        public IntBasis V1HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1HISP-NRENDOS           PIC S9(009)         COMP.*/
        public IntBasis V1HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1HISP-NRPARCEL          PIC S9(004)         COMP.*/
        public IntBasis V1HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HISP-DTMOVTO           PIC  X(010).*/
        public StringBasis V1HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1HISP-OPERACAO          PIC S9(004)         COMP.*/
        public IntBasis V1HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HISP-OCORHIST          PIC S9(004)         COMP.*/
        public IntBasis V1HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HISP-PRM-TAR           PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V1HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V1HISP-VAL-DES           PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V1HISP_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V1HISP-VLADIFRA          PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V1HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V1HISP-DTQITBCO          PIC  X(010).*/
        public StringBasis V1HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V2HISP-DTMOVTO           PIC  X(010).*/
        public StringBasis V2HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V2HISP-OPERACAO          PIC S9(004)         COMP.*/
        public IntBasis V2HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2HISP-OCORHIST          PIC S9(004)         COMP.*/
        public IntBasis V2HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2HISP-PRM-TAR           PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V2HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2HISP-VAL-DES           PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V2HISP_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2HISP-VLADIFRA          PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V2HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2HISP-DTQITBCO          PIC  X(010).*/
        public StringBasis V2HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V3HISP-DTMOVTO           PIC  X(010).*/
        public StringBasis V3HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V3HISP-PRM-TAR           PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V3HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V3HISP-VAL-DES           PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V3HISP_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V3HISP-VLADIFRA          PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V3HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0APOL-RAMO              PIC S9(004)         COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          GE397-NUM-APOL           PIC S9(013)         COMP-3.*/
        public IntBasis GE397_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          GE397-NUM-ENDS           PIC S9(009)         COMP.*/
        public IntBasis GE397_NUM_ENDS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          GE397-RAMO-CBT           PIC S9(004)         COMP.*/
        public IntBasis GE397_RAMO_CBT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          GE397-COD-COBT           PIC S9(004)         COMP.*/
        public IntBasis GE397_COD_COBT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          GE397-IMP-SEG-VR         PIC S9(013)V99      COMP-3.*/
        public DoubleBasis GE397_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          GE397-PRM-TAR-VR         PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis GE397_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0ENDO-NUM-APOL          PIC S9(013)         COMP-3.*/
        public IntBasis V0ENDO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0ENDO-NRENDOS           PIC S9(009)         COMP.*/
        public IntBasis V0ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0ENDO-DTINIVIG          PIC  X(010).*/
        public StringBasis V0ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0ENDO-CORRECAO          PIC  X(001).*/
        public StringBasis V0ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0ENDO-QTPARCEL          PIC S9(004)         COMP.*/
        public IntBasis V0ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0ENDO-CDFRACIO          PIC S9(004)         COMP.*/
        public IntBasis V0ENDO_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1APCD-NUM-APOL          PIC S9(013)         COMP-3.*/
        public IntBasis V1APCD_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1APCD-CODCOSS           PIC S9(004)         COMP.*/
        public IntBasis V1APCD_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1APCD-PCPARTIC          PIC S9(004)V9(5)    COMP-3.*/
        public DoubleBasis V1APCD_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77          V1APCD-PCCOMCOS          PIC S9(003)V9(2)    COMP-3.*/
        public DoubleBasis V1APCD_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77          V1APCD-DTINIVIG          PIC  X(010).*/
        public StringBasis V1APCD_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1APCD-DTTERVIG          PIC  X(010).*/
        public StringBasis V1APCD_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1ORDC-NUM-APOL          PIC S9(013)         COMP-3.*/
        public IntBasis V1ORDC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1ORDC-NRENDOS           PIC S9(009)         COMP.*/
        public IntBasis V1ORDC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1ORDC-CODCOSS           PIC S9(004)         COMP.*/
        public IntBasis V1ORDC_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1ORDC-ORD-CEDIDO        PIC S9(015)         COMP-3.*/
        public IntBasis V1ORDC_ORD_CEDIDO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77          V1PARC-NUM-APOL          PIC S9(013)         COMP-3.*/
        public IntBasis V1PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1PARC-NRENDOS           PIC S9(009)         COMP.*/
        public IntBasis V1PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1PARC-NRPARCEL          PIC S9(004)         COMP.*/
        public IntBasis V1PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1PARC-PRM-TAR           PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V1PARC_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1PARC-VAL-DES           PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V1PARC_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1PARC-OTNADFRA          PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V1PARC_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2PARC-NUM-APOL          PIC S9(013)         COMP-3.*/
        public IntBasis V2PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V2PARC-NRENDOS           PIC S9(009)         COMP.*/
        public IntBasis V2PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V2PARC-NRPARCEL          PIC S9(004)         COMP.*/
        public IntBasis V2PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2PARC-PRM-TAR           PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V2PARC_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2PARC-VAL-DES           PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V2PARC_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2PARC-OTNADFRA          PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V2PARC_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V3PARC-NUM-APOL          PIC S9(013)         COMP-3.*/
        public IntBasis V3PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V3PARC-NRENDOS           PIC S9(009)         COMP.*/
        public IntBasis V3PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V3PARC-NRPARCEL          PIC S9(004)         COMP.*/
        public IntBasis V3PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V3PARC-PRM-TAR           PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V3PARC_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V3PARC-VAL-DES           PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V3PARC_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V3PARC-OTNADFRA          PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V3PARC_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1PCOM-NUM-APOL          PIC S9(013)         COMP-3.*/
        public IntBasis V1PCOM_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1PCOM-NRENDOS           PIC S9(009)         COMP.*/
        public IntBasis V1PCOM_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1PCOM-NRPARCEL          PIC S9(004)         COMP.*/
        public IntBasis V1PCOM_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1PCOM-VLR-COMPL-IX      PIC S9(010)V9(05)   COMP-3.*/
        public DoubleBasis V1PCOM_VLR_COMPL_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
        /*"77          V1PCOM-VLR-COMPL         PIC S9(013)V9(02)   COMP-3.*/
        public DoubleBasis V1PCOM_VLR_COMPL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77          V3PCOM-NUM-APOL          PIC S9(013)         COMP-3.*/
        public IntBasis V3PCOM_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V3PCOM-NRENDOS           PIC S9(009)         COMP.*/
        public IntBasis V3PCOM_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V3PCOM-NRPARCEL          PIC S9(004)         COMP.*/
        public IntBasis V3PCOM_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V3PCOM-VLR-COMPL-IX      PIC S9(010)V9(05)   COMP-3.*/
        public DoubleBasis V3PCOM_VLR_COMPL_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
        /*"77          V3PCOM-VLR-COMPL         PIC S9(013)V9(02)   COMP-3.*/
        public DoubleBasis V3PCOM_VLR_COMPL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77          V1PLCO-CDFRACIO          PIC S9(004)         COMP.*/
        public IntBasis V1PLCO_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1PLCO-NRPARCEL          PIC S9(004)         COMP.*/
        public IntBasis V1PLCO_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1PLCO-PCCOMSEG          PIC S9(003)V9(002)  COMP-3.*/
        public DoubleBasis V1PLCO_PCCOMSEG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(002)"), 2);
        /*"77          V1PLCO-SITUACAO          PIC  X(001).*/
        public StringBasis V1PLCO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          MOVHBT-NUM-APOL          PIC S9(013)         COMP-3.*/
        public IntBasis MOVHBT_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          MOVHBT-NUM-ENDS          PIC S9(009)         COMP.*/
        public IntBasis MOVHBT_NUM_ENDS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          MOVHBT-NRPARCEL          PIC S9(004)         COMP.*/
        public IntBasis MOVHBT_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          MOVHBT-OCORHIST          PIC S9(004)         COMP.*/
        public IntBasis MOVHBT_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          MOVHBT-VAL-REMUN         PIC S9(013)V9(02)   COMP-3.*/
        public DoubleBasis MOVHBT_VAL_REMUN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77          MOVHBT-VAL-SUSEP         PIC S9(013)V9(02)   COMP-3.*/
        public DoubleBasis MOVHBT_VAL_SUSEP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77          V0CPRE-COD-EMPR          PIC S9(009)         COMP.*/
        public IntBasis V0CPRE_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0CPRE-TIPSGU            PIC  X(001).*/
        public StringBasis V0CPRE_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CPRE-CONGENER          PIC S9(004)         COMP.*/
        public IntBasis V0CPRE_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CPRE-NUM-ORDEM         PIC S9(015)         COMP-3.*/
        public IntBasis V0CPRE_NUM_ORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77          V0CPRE-NUM-APOL          PIC S9(013)         COMP-3.*/
        public IntBasis V0CPRE_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0CPRE-NRENDOS           PIC S9(009)         COMP.*/
        public IntBasis V0CPRE_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0CPRE-NRPARCEL          PIC S9(004)         COMP.*/
        public IntBasis V0CPRE_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CPRE-PRM-TAR-IX        PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V0CPRE_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0CPRE-VAL-DES-IX        PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V0CPRE_VAL_DES_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0CPRE-OTNPRLIQ          PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V0CPRE_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0CPRE-OTNADFRA          PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V0CPRE_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0CPRE-VLCOMISIX         PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V0CPRE_VLCOMISIX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0CPRE-OTNTOTAL          PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V0CPRE_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0CPRE-SITUACAO          PIC  X(001).*/
        public StringBasis V0CPRE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CPRE-SIT-CONG          PIC  X(001).*/
        public StringBasis V0CPRE_SIT_CONG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CPRE-TIMESTAMP         PIC  X(026).*/
        public StringBasis V0CPRE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77          V0CPRE-OCORHIST          PIC S9(004)         COMP.*/
        public IntBasis V0CPRE_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CPRE-COD-EMPR          PIC S9(009)         COMP.*/
        public IntBasis V2CPRE_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V2CPRE-TIPSGU            PIC  X(001).*/
        public StringBasis V2CPRE_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CPRE-CONGENER          PIC S9(004)         COMP.*/
        public IntBasis V2CPRE_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CPRE-NUM-ORDEM         PIC S9(015)         COMP-3.*/
        public IntBasis V2CPRE_NUM_ORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77          V2CPRE-NUM-APOL          PIC S9(013)         COMP-3.*/
        public IntBasis V2CPRE_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V2CPRE-NRENDOS           PIC S9(009)         COMP.*/
        public IntBasis V2CPRE_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V2CPRE-NRPARCEL          PIC S9(004)         COMP.*/
        public IntBasis V2CPRE_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CPRE-PRM-TAR-IX        PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V2CPRE_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2CPRE-VAL-DES-IX        PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V2CPRE_VAL_DES_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2CPRE-OTNPRLIQ          PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V2CPRE_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2CPRE-OTNADFRA          PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V2CPRE_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2CPRE-VLCOMISIX         PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V2CPRE_VLCOMISIX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2CPRE-OTNTOTAL          PIC S9(010)V9(5)    COMP-3.*/
        public DoubleBasis V2CPRE_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2CPRE-SITUACAO          PIC  X(001).*/
        public StringBasis V2CPRE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CPRE-SIT-CONG          PIC  X(001).*/
        public StringBasis V2CPRE_SIT_CONG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CPRE-TIMESTAMP         PIC  X(026).*/
        public StringBasis V2CPRE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77          V2CPRE-OCORHIST          PIC S9(004)         COMP.*/
        public IntBasis V2CPRE_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHIS-COD-EMPR          PIC S9(009)         COMP.*/
        public IntBasis V0CHIS_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0CHIS-CONGENER          PIC S9(004)         COMP.*/
        public IntBasis V0CHIS_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHIS-NUM-APOL          PIC S9(013)         COMP-3.*/
        public IntBasis V0CHIS_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0CHIS-NRENDOS           PIC S9(009)         COMP.*/
        public IntBasis V0CHIS_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0CHIS-NRPARCEL          PIC S9(004)         COMP.*/
        public IntBasis V0CHIS_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHIS-OCORHIST          PIC S9(004)         COMP.*/
        public IntBasis V0CHIS_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHIS-OPERACAO          PIC S9(004)         COMP.*/
        public IntBasis V0CHIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHIS-DTMOVTO           PIC  X(010).*/
        public StringBasis V0CHIS_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0CHIS-TIPSGU            PIC  X(001).*/
        public StringBasis V0CHIS_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CHIS-PRM-TAR           PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V0CHIS_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0CHIS-VAL-DES           PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V0CHIS_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0CHIS-VLPRMLIQ          PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V0CHIS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0CHIS-VLADIFRA          PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V0CHIS_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0CHIS-VLCOMIS           PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V0CHIS_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0CHIS-VLPRMTOT          PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V0CHIS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0CHIS-TIMESTAMP         PIC  X(026).*/
        public StringBasis V0CHIS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77          V0CHIS-DTQITBCO          PIC  X(010).*/
        public StringBasis V0CHIS_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0CHIS-SIT-FINANC        PIC  X(001).*/
        public StringBasis V0CHIS_SIT_FINANC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CHIS-SIT-LIBREC        PIC  X(001).*/
        public StringBasis V0CHIS_SIT_LIBREC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CHIS-NUM-OCOR          PIC S9(004)         COMP.*/
        public IntBasis V0CHIS_NUM_OCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CHIS-COD-EMPR          PIC S9(009)         COMP.*/
        public IntBasis V2CHIS_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V2CHIS-CONGENER          PIC S9(004)         COMP.*/
        public IntBasis V2CHIS_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CHIS-NUM-APOL          PIC S9(013)         COMP-3.*/
        public IntBasis V2CHIS_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V2CHIS-NRENDOS           PIC S9(009)         COMP.*/
        public IntBasis V2CHIS_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V2CHIS-NRPARCEL          PIC S9(004)         COMP.*/
        public IntBasis V2CHIS_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CHIS-OCORHIST          PIC S9(004)         COMP.*/
        public IntBasis V2CHIS_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CHIS-OPERACAO          PIC S9(004)         COMP.*/
        public IntBasis V2CHIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CHIS-DTMOVTO           PIC  X(010).*/
        public StringBasis V2CHIS_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V2CHIS-TIPSGU            PIC  X(001).*/
        public StringBasis V2CHIS_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CHIS-PRM-TAR           PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V2CHIS_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2CHIS-VAL-DES           PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V2CHIS_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2CHIS-VLPRMLIQ          PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V2CHIS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2CHIS-VLADIFRA          PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V2CHIS_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2CHIS-VLCOMIS           PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V2CHIS_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2CHIS-VLPRMTOT          PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V2CHIS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V2CHIS-TIMESTAMP         PIC  X(026).*/
        public StringBasis V2CHIS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77          V2CHIS-DTQITBCO          PIC  X(010).*/
        public StringBasis V2CHIS_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V2CHIS-SIT-FINANC        PIC  X(001).*/
        public StringBasis V2CHIS_SIT_FINANC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CHIS-SIT-LIBREC        PIC  X(001).*/
        public StringBasis V2CHIS_SIT_LIBREC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CHIS-NUM-OCOR          PIC S9(004)         COMP.*/
        public IntBasis V2CHIS_NUM_OCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V3CHIS-PRM-TAR           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V3CHIS_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V3CHIS-VAL-DES           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V3CHIS_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V3CHIS-VLADIFRA          PIC S9(013)V99       COMP-3*/
        public DoubleBasis V3CHIS_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V3CHIS-VLCOMIS           PIC S9(013)V99       COMP-3*/
        public DoubleBasis V3CHIS_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          TABELA-COSCED.*/
        public AC0010B_TABELA_COSCED TABELA_COSCED { get; set; } = new AC0010B_TABELA_COSCED();
        public class AC0010B_TABELA_COSCED : VarBasis
        {
            /*"  05        TAB-COSSEGCED       OCCURS   100  TIMES.*/
            public ListBasis<AC0010B_TAB_COSSEGCED> TAB_COSSEGCED { get; set; } = new ListBasis<AC0010B_TAB_COSSEGCED>(100);
            public class AC0010B_TAB_COSSEGCED : VarBasis
            {
                /*"    10      WCODCOSS            PIC  9(004).*/
                public IntBasis WCODCOSS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      WPCPARTIC           PIC  9(004)V9(9).*/
                public DoubleBasis WPCPARTIC { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)."), 9);
                /*"    10      WPCCOMCOS           PIC  9(004)V9(9).*/
                public DoubleBasis WPCCOMCOS { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)."), 9);
                /*"    10      WORD-CEDIDO         PIC  9(015).*/
                public IntBasis WORD_CEDIDO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"01          AREA-DE-WORK.*/
            }
        }
        public AC0010B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0010B_AREA_DE_WORK();
        public class AC0010B_AREA_DE_WORK : VarBasis
        {
            /*"  05        WIND                PIC  9(003)       VALUE ZEROS.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05        WFIM-V1HISTOPARC    PIC  X(001)       VALUE SPACES.*/
            public StringBasis WFIM_V1HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WFIM-V1APOLCOSCED   PIC  X(001)       VALUE SPACES.*/
            public StringBasis WFIM_V1APOLCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WFIM-V2HISTOPARC    PIC  X(001)       VALUE SPACES.*/
            public StringBasis WFIM_V2HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WTEM-COSSEGURO      PIC  X(001)       VALUE SPACES.*/
            public StringBasis WTEM_COSSEGURO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WTEM-PARC-COMPL     PIC  X(001)       VALUE SPACES.*/
            public StringBasis WTEM_PARC_COMPL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WTEM-COMIS-ACELER   PIC  X(001)       VALUE SPACES.*/
            public StringBasis WTEM_COMIS_ACELER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        AC-L-V1HISTOPARC    PIC  9(007)       VALUE ZEROS.*/
            public IntBasis AC_L_V1HISTOPARC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-I-V0COSSEGPREM   PIC  9(007)       VALUE ZEROS.*/
            public IntBasis AC_I_V0COSSEGPREM { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-U-V0COSSEGPREM   PIC  9(007)       VALUE ZEROS.*/
            public IntBasis AC_U_V0COSSEGPREM { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-I-V0COSSEGHISP   PIC  9(007)       VALUE ZEROS.*/
            public IntBasis AC_I_V0COSSEGHISP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        WOPERACAO           PIC  9(004)       VALUE ZEROS.*/
            public IntBasis WOPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05        FILLER              REDEFINES         WOPERACAO.*/
            private _REDEF_AC0010B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_AC0010B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_AC0010B_FILLER_0(); _.Move(WOPERACAO, _filler_0); VarBasis.RedefinePassValue(WOPERACAO, _filler_0, WOPERACAO); _filler_0.ValueChanged += () => { _.Move(_filler_0, WOPERACAO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WOPERACAO); }
            }  //Redefines
            public class _REDEF_AC0010B_FILLER_0 : VarBasis
            {
                /*"    10      WTIPO-OPERACAO      PIC  9(002).*/
                public IntBasis WTIPO_OPERACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  9(002).*/
                public IntBasis FILLER_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        W2OPERACAO          PIC  9(004)       VALUE ZEROS.*/

                public _REDEF_AC0010B_FILLER_0()
                {
                    WTIPO_OPERACAO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W2OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05        FILLER              REDEFINES         W2OPERACAO.*/
            private _REDEF_AC0010B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_AC0010B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_AC0010B_FILLER_2(); _.Move(W2OPERACAO, _filler_2); VarBasis.RedefinePassValue(W2OPERACAO, _filler_2, W2OPERACAO); _filler_2.ValueChanged += () => { _.Move(_filler_2, W2OPERACAO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, W2OPERACAO); }
            }  //Redefines
            public class _REDEF_AC0010B_FILLER_2 : VarBasis
            {
                /*"    10      W2TIPO-OPERACAO     PIC  9(002).*/
                public IntBasis W2TIPO_OPERACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  9(002).*/
                public IntBasis FILLER_3 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WNUM-APOL-ANT       PIC S9(013)      VALUE +0 COMP-3*/

                public _REDEF_AC0010B_FILLER_2()
                {
                    W2TIPO_OPERACAO.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WNUM_APOL_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05        WNRENDOS-ANT        PIC S9(009)      VALUE +0 COMP.*/
            public IntBasis WNRENDOS_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05        WNRPARCEL-ANT       PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis WNRPARCEL_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        WPCTCED             PIC  9(004)V9(9)  VALUE ZEROS.*/
            public DoubleBasis WPCTCED { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05        WPCTCED-NOVO        PIC  9(004)V9(9)  VALUE ZEROS.*/
            public DoubleBasis WPCTCED_NOVO { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05        WPART-COB-8105      PIC  9(004)V9(9)  VALUE ZEROS.*/
            public DoubleBasis WPART_COB_8105 { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05        WS-PCPARTIC         PIC  9(004)V9(9)  VALUE ZEROS.*/
            public DoubleBasis WS_PCPARTIC { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05        WS-PCCOMCOS         PIC  9(004)V9(9)  VALUE ZEROS.*/
            public DoubleBasis WS_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05        WPROP-VAL-REMUN     PIC  9(007)V9(10) VALUE 0 COMP-3*/
            public DoubleBasis WPROP_VAL_REMUN { get; set; } = new DoubleBasis(new PIC("9", "7", "9(007)V9(10)"), 10);
            /*"  05        WPROP-VLADIFRA      PIC  9(007)V9(10) VALUE 0 COMP-3*/
            public DoubleBasis WPROP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("9", "7", "9(007)V9(10)"), 10);
            /*"  05        WPROP-VAL-DES       PIC  9(007)V9(10) VALUE 0 COMP-3*/
            public DoubleBasis WPROP_VAL_DES { get; set; } = new DoubleBasis(new PIC("9", "7", "9(007)V9(10)"), 10);
            /*"  05        WPROPORCAO          PIC  9(007)V9(10) VALUE 0 COMP-3*/
            public DoubleBasis WPROPORCAO { get; set; } = new DoubleBasis(new PIC("9", "7", "9(007)V9(10)"), 10);
            /*"  05        WS-VLR-COMPL        PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WS_VLR_COMPL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05        WS-VLR-COMPL-IX     PIC S9(010)V9(5) VALUE +0 COMP-3*/
            public DoubleBasis WS_VLR_COMPL_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05        WDAT-LIMT-COMS      PIC  X(010)  VALUE '1995-10-01'.*/
            public StringBasis WDAT_LIMT_COMS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"1995-10-01");
            /*"  05        WDATA-AUX           PIC  X(010)      VALUE SPACES.*/
            public StringBasis WDATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER              REDEFINES        WDATA-AUX.*/
            private _REDEF_AC0010B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_AC0010B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_AC0010B_FILLER_4(); _.Move(WDATA_AUX, _filler_4); VarBasis.RedefinePassValue(WDATA_AUX, _filler_4, WDATA_AUX); _filler_4.ValueChanged += () => { _.Move(_filler_4, WDATA_AUX); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WDATA_AUX); }
            }  //Redefines
            public class _REDEF_AC0010B_FILLER_4 : VarBasis
            {
                /*"    10      WDATA-ANO-AUX       PIC  9(004).*/
                public IntBasis WDATA_ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDATA-MES-AUX       PIC  9(002).*/
                public IntBasis WDATA_MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDATA-DIA-AUX       PIC  9(002).*/
                public IntBasis WDATA_DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WDATA-EDIT.*/

                public _REDEF_AC0010B_FILLER_4()
                {
                    WDATA_ANO_AUX.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WDATA_MES_AUX.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    WDATA_DIA_AUX.ValueChanged += OnValueChanged;
                }

            }
            public AC0010B_WDATA_EDIT WDATA_EDIT { get; set; } = new AC0010B_WDATA_EDIT();
            public class AC0010B_WDATA_EDIT : VarBasis
            {
                /*"    10      WDATA-DIA-EDT       PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDATA_DIA_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDATA-MES-EDT       PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDATA_MES_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDATA-ANO-EDT       PIC  9(004)      VALUE ZEROS.*/
                public IntBasis WDATA_ANO_EDT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05        WHORA-ACCEPT.*/
            }
            public AC0010B_WHORA_ACCEPT WHORA_ACCEPT { get; set; } = new AC0010B_WHORA_ACCEPT();
            public class AC0010B_WHORA_ACCEPT : VarBasis
            {
                /*"    10      WHH-ACCEPT          PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WHH_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WMM-ACCEPT          PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WMM_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WSS-ACCEPT          PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WSS_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WCC-ACCEPT          PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WCC_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        WHORA-CABEC.*/
            }
            public AC0010B_WHORA_CABEC WHORA_CABEC { get; set; } = new AC0010B_WHORA_CABEC();
            public class AC0010B_WHORA_CABEC : VarBasis
            {
                /*"    10      WHH-CABEC           PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)      VALUE ':'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10      WMM-CABEC           PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WMM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)      VALUE ':'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10      WSS-CABEC           PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WSS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01          WABEND.*/
            }
        }
        public AC0010B_WABEND WABEND { get; set; } = new AC0010B_WABEND();
        public class AC0010B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)    VALUE ' AC0010B'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" AC0010B");
            /*"  05        FILLER              PIC  X(026)    VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(003)    VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"  05        FILLER              PIC  X(013)    VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public AC0010B_V1HISTOPARC V1HISTOPARC { get; set; } = new AC0010B_V1HISTOPARC();
        public AC0010B_V1APOLCOSCED V1APOLCOSCED { get; set; } = new AC0010B_V1APOLCOSCED();
        public AC0010B_V2HISTOPARC V2HISTOPARC { get; set; } = new AC0010B_V2HISTOPARC();
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
            /*" -481- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WABEND.WNR_EXEC_SQL);

            /*" -482- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -485- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -488- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -494- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -498- MOVE ZEROS TO WHOST-QTDE-REG. */
            _.Move(0, WHOST_QTDE_REG);

            /*" -499- IF WHOST-QTDE-REG > ZEROS */

            if (WHOST_QTDE_REG > 00)
            {

                /*" -500- DISPLAY 'AC0010B - DUPLICIDADE DE PROCESSAMENTO' */
                _.Display($"AC0010B - DUPLICIDADE DE PROCESSAMENTO");

                /*" -501- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -503- END-IF. */
            }


            /*" -504- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -505- MOVE WHH-ACCEPT TO WHH-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHH_CABEC);

            /*" -506- MOVE WMM-ACCEPT TO WMM-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WMM_CABEC);

            /*" -507- MOVE WSS-ACCEPT TO WSS-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WSS_CABEC);

            /*" -509- DISPLAY 'INICIO  DECLARE  -  ' WHORA-CABEC. */
            _.Display($"INICIO  DECLARE  -  {AREA_DE_WORK.WHORA_CABEC}");

            /*" -511- PERFORM R0500-00-DECLARE-V1HISTOPARC. */

            R0500_00_DECLARE_V1HISTOPARC_SECTION();

            /*" -512- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -513- MOVE WHH-ACCEPT TO WHH-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHH_CABEC);

            /*" -514- MOVE WMM-ACCEPT TO WMM-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WMM_CABEC);

            /*" -515- MOVE WSS-ACCEPT TO WSS-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WSS_CABEC);

            /*" -517- DISPLAY 'FIM     DECLARE  -  ' WHORA-CABEC. */
            _.Display($"FIM     DECLARE  -  {AREA_DE_WORK.WHORA_CABEC}");

            /*" -519- PERFORM R0550-00-FETCH-V1HISTOPARC. */

            R0550_00_FETCH_V1HISTOPARC_SECTION();

            /*" -520- IF WFIM-V1HISTOPARC NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1HISTOPARC.IsEmpty())
            {

                /*" -522- PERFORM R9900-00-ENCERRA-SEM-MOVTO. */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();
            }


            /*" -525- PERFORM R0600-00-PROCESSA-HISTOPARC UNTIL WFIM-V1HISTOPARC NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1HISTOPARC.IsEmpty()))
            {

                R0600_00_PROCESSA_HISTOPARC_SECTION();
            }

            /*" -526- DISPLAY 'HISTORICOS LIDOS           ' AC-L-V1HISTOPARC. */
            _.Display($"HISTORICOS LIDOS           {AREA_DE_WORK.AC_L_V1HISTOPARC}");

            /*" -527- DISPLAY 'PREMIOS COSSEG ATUALIZADOS ' AC-U-V0COSSEGPREM. */
            _.Display($"PREMIOS COSSEG ATUALIZADOS {AREA_DE_WORK.AC_U_V0COSSEGPREM}");

            /*" -528- DISPLAY 'DOCUMENTOS INSERIDOS :     ' . */
            _.Display($"DOCUMENTOS INSERIDOS :     ");

            /*" -529- DISPLAY ' . PREMIOS COSSEGURO       ' AC-I-V0COSSEGPREM. */
            _.Display($" . PREMIOS COSSEGURO       {AREA_DE_WORK.AC_I_V0COSSEGPREM}");

            /*" -530- DISPLAY ' . HISTORICOS COSSEGURO    ' AC-I-V0COSSEGHISP. */
            _.Display($" . HISTORICOS COSSEGURO    {AREA_DE_WORK.AC_I_V0COSSEGHISP}");

            /*" -530- DISPLAY 'AC0010B - FIM NORMAL ' . */
            _.Display($"AC0010B - FIM NORMAL ");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -534- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -538- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -538- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -551- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -556- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -559- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -560- DISPLAY 'R0100 - ERRO NO SELECT DA V1SISTEMA - AC' */
                _.Display($"R0100 - ERRO NO SELECT DA V1SISTEMA - AC");

                /*" -561- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -562- ELSE */
            }
            else
            {


                /*" -562- DISPLAY 'DATA DO SISTEMA AC - ' V1SIST-DTMOVABE. */
                _.Display($"DATA DO SISTEMA AC - {V1SIST_DTMOVABE}");
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -556- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'AC' END-EXEC. */

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
        /*" R0200-00-CHECA-EXECUCAO-SECTION */
        private void R0200_00_CHECA_EXECUCAO_SECTION()
        {
            /*" -575- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -586- PERFORM R0200_00_CHECA_EXECUCAO_DB_SELECT_1 */

            R0200_00_CHECA_EXECUCAO_DB_SELECT_1();

            /*" -589- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -590- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -591- MOVE ZEROS TO WHOST-QTDE-REG */
                    _.Move(0, WHOST_QTDE_REG);

                    /*" -592- ELSE */
                }
                else
                {


                    /*" -593- DISPLAY 'R0200 - ERRO NO SELECT DA V1COSSEG-HISTPRE' */
                    _.Display($"R0200 - ERRO NO SELECT DA V1COSSEG-HISTPRE");

                    /*" -594- DISPLAY 'DATA MOVTO - ' V1SIST-DTMOVABE */
                    _.Display($"DATA MOVTO - {V1SIST_DTMOVABE}");

                    /*" -595- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -596- END-IF */
                }


                /*" -596- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-CHECA-EXECUCAO-DB-SELECT-1 */
        public void R0200_00_CHECA_EXECUCAO_DB_SELECT_1()
        {
            /*" -586- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WHOST-QTDE-REG FROM SEGUROS.V1COSSEG_HISTPRE A, SEGUROS.V0APOLICE B WHERE A.DTMOVTO = :V1SIST-DTMOVABE AND A.TIPSGU = '1' AND A.OPERACAO < 0600 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.TIPSGU = A.TIPSGU AND B.ORGAO IN (0010,0300) END-EXEC. */

            var r0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1 = new R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            var executed_1 = R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1.Execute(r0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTDE_REG, WHOST_QTDE_REG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-DECLARE-V1HISTOPARC-SECTION */
        private void R0500_00_DECLARE_V1HISTOPARC_SECTION()
        {
            /*" -609- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", WABEND.WNR_EXEC_SQL);

            /*" -633- PERFORM R0500_00_DECLARE_V1HISTOPARC_DB_DECLARE_1 */

            R0500_00_DECLARE_V1HISTOPARC_DB_DECLARE_1();

            /*" -635- PERFORM R0500_00_DECLARE_V1HISTOPARC_DB_OPEN_1 */

            R0500_00_DECLARE_V1HISTOPARC_DB_OPEN_1();

            /*" -638- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -639- DISPLAY 'R0500 - ERRO NO DECLARE DA V1HISTOPARC' */
                _.Display($"R0500 - ERRO NO DECLARE DA V1HISTOPARC");

                /*" -640- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -641- ELSE */
            }
            else
            {


                /*" -642- MOVE SPACES TO WFIM-V1HISTOPARC */
                _.Move("", AREA_DE_WORK.WFIM_V1HISTOPARC);

                /*" -642- END-IF. */
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-V1HISTOPARC-DB-DECLARE-1 */
        public void R0500_00_DECLARE_V1HISTOPARC_DB_DECLARE_1()
        {
            /*" -633- EXEC SQL DECLARE V1HISTOPARC CURSOR FOR SELECT A.NUM_APOLICE , A.NRENDOS , A.NRPARCEL , A.DTMOVTO , A.OPERACAO , A.OCORHIST , A.PRM_TARIFARIO , A.VAL_DESCONTO , A.VLADIFRA , A.DTQITBCO , B.RAMO FROM SEGUROS.V1HISTOPARC A, SEGUROS.V0APOLICE B WHERE A.DTMOVTO = :V1SIST-DTMOVABE AND A.OPERACAO < 0900 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.TIPSGU = '1' AND B.ORGAO IN (0010,0300) AND B.PCTCED > 0 ORDER BY A.NUM_APOLICE , A.NRENDOS , A.NRPARCEL , A.OCORHIST END-EXEC. */
            V1HISTOPARC = new AC0010B_V1HISTOPARC(true);
            string GetQuery_V1HISTOPARC()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.DTMOVTO
							, 
							A.OPERACAO
							, 
							A.OCORHIST
							, 
							A.PRM_TARIFARIO
							, 
							A.VAL_DESCONTO
							, 
							A.VLADIFRA
							, 
							A.DTQITBCO
							, 
							B.RAMO 
							FROM SEGUROS.V1HISTOPARC A
							, 
							SEGUROS.V0APOLICE B 
							WHERE A.DTMOVTO = '{V1SIST_DTMOVABE}' 
							AND A.OPERACAO < 0900 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.TIPSGU = '1' 
							AND B.ORGAO IN (0010
							,0300) 
							AND B.PCTCED > 0 
							ORDER BY A.NUM_APOLICE
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
            /*" -635- EXEC SQL OPEN V1HISTOPARC END-EXEC. */

            V1HISTOPARC.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1APOLCOSCED-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V1APOLCOSCED_DB_DECLARE_1()
        {
            /*" -922- EXEC SQL DECLARE V1APOLCOSCED CURSOR FOR SELECT CODCOSS , PCPARTIC , PCCOMCOS FROM SEGUROS.V1APOLCOSCED WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND DTINIVIG <= :V0ENDO-DTINIVIG AND DTTERVIG >= :V0ENDO-DTINIVIG END-EXEC. */
            V1APOLCOSCED = new AC0010B_V1APOLCOSCED(true);
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
            /*" -653- MOVE '055' TO WNR-EXEC-SQL. */
            _.Move("055", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0550_10_LER_V1HISTOPARC */

            R0550_10_LER_V1HISTOPARC();

        }

        [StopWatch]
        /*" R0550-10-LER-V1HISTOPARC */
        private void R0550_10_LER_V1HISTOPARC(bool isPerform = false)
        {
            /*" -669- PERFORM R0550_10_LER_V1HISTOPARC_DB_FETCH_1 */

            R0550_10_LER_V1HISTOPARC_DB_FETCH_1();

            /*" -672- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -673- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -674- MOVE 'S' TO WFIM-V1HISTOPARC */
                    _.Move("S", AREA_DE_WORK.WFIM_V1HISTOPARC);

                    /*" -674- PERFORM R0550_10_LER_V1HISTOPARC_DB_CLOSE_1 */

                    R0550_10_LER_V1HISTOPARC_DB_CLOSE_1();

                    /*" -676- GO TO R0550-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/ //GOTO
                    return;

                    /*" -677- ELSE */
                }
                else
                {


                    /*" -678- DISPLAY 'R0550 - ERRO NO FETCH DA V1HISTOPARC' */
                    _.Display($"R0550 - ERRO NO FETCH DA V1HISTOPARC");

                    /*" -679- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -680- END-IF */
                }


                /*" -681- ELSE */
            }
            else
            {


                /*" -682- IF VIND-DAT-QTBC < ZEROS */

                if (VIND_DAT_QTBC < 00)
                {

                    /*" -683- MOVE SPACES TO V1HISP-DTQITBCO */
                    _.Move("", V1HISP_DTQITBCO);

                    /*" -684- END-IF */
                }


                /*" -686- END-IF. */
            }


            /*" -688- MOVE V1HISP-OPERACAO TO WOPERACAO. */
            _.Move(V1HISP_OPERACAO, AREA_DE_WORK.WOPERACAO);

            /*" -689- IF WTIPO-OPERACAO = 06 OR 07 */

            if (AREA_DE_WORK.FILLER_0.WTIPO_OPERACAO.In("06", "07"))
            {

                /*" -690- GO TO R0550-10-LER-V1HISTOPARC */
                new Task(() => R0550_10_LER_V1HISTOPARC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -691- ELSE */
            }
            else
            {


                /*" -692- MOVE ZEROS TO WHOST-OCORHIST */
                _.Move(0, WHOST_OCORHIST);

                /*" -693- ADD 1 TO AC-L-V1HISTOPARC */
                AREA_DE_WORK.AC_L_V1HISTOPARC.Value = AREA_DE_WORK.AC_L_V1HISTOPARC + 1;

                /*" -693- END-IF. */
            }


        }

        [StopWatch]
        /*" R0550-10-LER-V1HISTOPARC-DB-FETCH-1 */
        public void R0550_10_LER_V1HISTOPARC_DB_FETCH_1()
        {
            /*" -669- EXEC SQL FETCH V1HISTOPARC INTO :V1HISP-NUM-APOL , :V1HISP-NRENDOS , :V1HISP-NRPARCEL , :V1HISP-DTMOVTO , :V1HISP-OPERACAO , :V1HISP-OCORHIST , :V1HISP-PRM-TAR , :V1HISP-VAL-DES , :V1HISP-VLADIFRA , :V1HISP-DTQITBCO:VIND-DAT-QTBC, :V0APOL-RAMO END-EXEC. */

            if (V1HISTOPARC.Fetch())
            {
                _.Move(V1HISTOPARC.V1HISP_NUM_APOL, V1HISP_NUM_APOL);
                _.Move(V1HISTOPARC.V1HISP_NRENDOS, V1HISP_NRENDOS);
                _.Move(V1HISTOPARC.V1HISP_NRPARCEL, V1HISP_NRPARCEL);
                _.Move(V1HISTOPARC.V1HISP_DTMOVTO, V1HISP_DTMOVTO);
                _.Move(V1HISTOPARC.V1HISP_OPERACAO, V1HISP_OPERACAO);
                _.Move(V1HISTOPARC.V1HISP_OCORHIST, V1HISP_OCORHIST);
                _.Move(V1HISTOPARC.V1HISP_PRM_TAR, V1HISP_PRM_TAR);
                _.Move(V1HISTOPARC.V1HISP_VAL_DES, V1HISP_VAL_DES);
                _.Move(V1HISTOPARC.V1HISP_VLADIFRA, V1HISP_VLADIFRA);
                _.Move(V1HISTOPARC.V1HISP_DTQITBCO, V1HISP_DTQITBCO);
                _.Move(V1HISTOPARC.VIND_DAT_QTBC, VIND_DAT_QTBC);
                _.Move(V1HISTOPARC.V0APOL_RAMO, V0APOL_RAMO);
            }

        }

        [StopWatch]
        /*" R0550-10-LER-V1HISTOPARC-DB-CLOSE-1 */
        public void R0550_10_LER_V1HISTOPARC_DB_CLOSE_1()
        {
            /*" -674- EXEC SQL CLOSE V1HISTOPARC END-EXEC */

            V1HISTOPARC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-PROCESSA-HISTOPARC-SECTION */
        private void R0600_00_PROCESSA_HISTOPARC_SECTION()
        {
            /*" -709- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", WABEND.WNR_EXEC_SQL);

            /*" -711- MOVE ZEROS TO WHOST-QTDE-REG. */
            _.Move(0, WHOST_QTDE_REG);

            /*" -713- PERFORM R0700-00-SELECT-GE397. */

            R0700_00_SELECT_GE397_SECTION();

            /*" -714- IF WHOST-QTDE-REG > ZEROS */

            if (WHOST_QTDE_REG > 00)
            {

                /*" -715- DISPLAY 'R0600 - DOCTO NAO PODE TER COSG CED POR APOLICE' */
                _.Display($"R0600 - DOCTO NAO PODE TER COSG CED POR APOLICE");

                /*" -716- DISPLAY 'APOLICE  - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE  - {V1HISP_NUM_APOL}");

                /*" -717- DISPLAY 'ENDOSSO  - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO  - {V1HISP_NRENDOS}");

                /*" -718- DISPLAY 'PARCELA  - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA  - {V1HISP_NRPARCEL}");

                /*" -719- DISPLAY 'OCR HIST - ' V1HISP-OCORHIST */
                _.Display($"OCR HIST - {V1HISP_OCORHIST}");

                /*" -720- DISPLAY 'DT MOVTO - ' V1HISP-DTMOVTO */
                _.Display($"DT MOVTO - {V1HISP_DTMOVTO}");

                /*" -721- DISPLAY 'OPERACAO - ' V1HISP-OPERACAO */
                _.Display($"OPERACAO - {V1HISP_OPERACAO}");

                /*" -722- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -726- END-IF. */
            }


            /*" -728- MOVE 'S' TO WTEM-COSSEGURO. */
            _.Move("S", AREA_DE_WORK.WTEM_COSSEGURO);

            /*" -729- MOVE ZEROS TO WIND. */
            _.Move(0, AREA_DE_WORK.WIND);

            /*" -731- MOVE ZEROS TO TABELA-COSCED. */
            _.Move(0, TABELA_COSCED);

            /*" -732- MOVE ZEROS TO WPCTCED. */
            _.Move(0, AREA_DE_WORK.WPCTCED);

            /*" -733- MOVE ZEROS TO WPCTCED-NOVO. */
            _.Move(0, AREA_DE_WORK.WPCTCED_NOVO);

            /*" -735- MOVE ZEROS TO WPART-COB-8105. */
            _.Move(0, AREA_DE_WORK.WPART_COB_8105);

            /*" -736- MOVE ZEROS TO WS-PCPARTIC. */
            _.Move(0, AREA_DE_WORK.WS_PCPARTIC);

            /*" -738- MOVE ZEROS TO WS-PCCOMCOS. */
            _.Move(0, AREA_DE_WORK.WS_PCCOMCOS);

            /*" -739- MOVE V1HISP-NUM-APOL TO WNUM-APOL-ANT. */
            _.Move(V1HISP_NUM_APOL, AREA_DE_WORK.WNUM_APOL_ANT);

            /*" -742- MOVE V1HISP-NRENDOS TO WNRENDOS-ANT. */
            _.Move(V1HISP_NRENDOS, AREA_DE_WORK.WNRENDOS_ANT);

            /*" -745- PERFORM R0800-00-SELECT-V0ENDOSSO. */

            R0800_00_SELECT_V0ENDOSSO_SECTION();

            /*" -747- PERFORM R0900-00-DECLARE-V1APOLCOSCED. */

            R0900_00_DECLARE_V1APOLCOSCED_SECTION();

            /*" -750- PERFORM R0950-00-FETCH-V1APOLCOSCED. */

            R0950_00_FETCH_V1APOLCOSCED_SECTION();

            /*" -751- IF WFIM-V1APOLCOSCED NOT = SPACES */

            if (!AREA_DE_WORK.WFIM_V1APOLCOSCED.IsEmpty())
            {

                /*" -754- IF V1HISP-NUM-APOL = 93010000890 AND (V0ENDO-DTINIVIG < '1998-06-01' OR V0ENDO-DTINIVIG > '2006-06-30' ) */

                if (V1HISP_NUM_APOL == 93010000890 && (V0ENDO_DTINIVIG < "1998-06-01" || V0ENDO_DTINIVIG > "2006-06-30"))
                {

                    /*" -755- MOVE 'N' TO WTEM-COSSEGURO */
                    _.Move("N", AREA_DE_WORK.WTEM_COSSEGURO);

                    /*" -756- ELSE */
                }
                else
                {


                    /*" -759- IF V1HISP-NUM-APOL = 97010000889 AND (V0ENDO-DTINIVIG < '1995-06-01' OR V0ENDO-DTINIVIG > '2001-09-30' ) */

                    if (V1HISP_NUM_APOL == 97010000889 && (V0ENDO_DTINIVIG < "1995-06-01" || V0ENDO_DTINIVIG > "2001-09-30"))
                    {

                        /*" -760- MOVE 'N' TO WTEM-COSSEGURO */
                        _.Move("N", AREA_DE_WORK.WTEM_COSSEGURO);

                        /*" -761- ELSE */
                    }
                    else
                    {


                        /*" -763- IF V1HISP-NUM-APOL = 107700000022 AND V0ENDO-DTINIVIG < '2014-12-01' */

                        if (V1HISP_NUM_APOL == 107700000022 && V0ENDO_DTINIVIG < "2014-12-01")
                        {

                            /*" -764- MOVE 'N' TO WTEM-COSSEGURO */
                            _.Move("N", AREA_DE_WORK.WTEM_COSSEGURO);

                            /*" -765- ELSE */
                        }
                        else
                        {


                            /*" -768- IF V1HISP-NUM-APOL = 109300000027 AND (V0ENDO-DTINIVIG < '1997-11-01' OR V0ENDO-DTINIVIG > '2005-08-31' ) */

                            if (V1HISP_NUM_APOL == 109300000027 && (V0ENDO_DTINIVIG < "1997-11-01" || V0ENDO_DTINIVIG > "2005-08-31"))
                            {

                                /*" -769- MOVE 'N' TO WTEM-COSSEGURO */
                                _.Move("N", AREA_DE_WORK.WTEM_COSSEGURO);

                                /*" -770- ELSE */
                            }
                            else
                            {


                                /*" -773- IF V1HISP-NUM-APOL = 109300000303 AND (V0ENDO-DTINIVIG < '1999-10-01' OR V0ENDO-DTINIVIG > '2001-11-30' ) */

                                if (V1HISP_NUM_APOL == 109300000303 && (V0ENDO_DTINIVIG < "1999-10-01" || V0ENDO_DTINIVIG > "2001-11-30"))
                                {

                                    /*" -774- MOVE 'N' TO WTEM-COSSEGURO */
                                    _.Move("N", AREA_DE_WORK.WTEM_COSSEGURO);

                                    /*" -775- ELSE */
                                }
                                else
                                {


                                    /*" -778- IF V1HISP-NUM-APOL = 109700000025 AND (V0ENDO-DTINIVIG < '1997-10-01' OR V0ENDO-DTINIVIG > '2005-09-30' ) */

                                    if (V1HISP_NUM_APOL == 109700000025 && (V0ENDO_DTINIVIG < "1997-10-01" || V0ENDO_DTINIVIG > "2005-09-30"))
                                    {

                                        /*" -779- MOVE 'N' TO WTEM-COSSEGURO */
                                        _.Move("N", AREA_DE_WORK.WTEM_COSSEGURO);

                                        /*" -780- ELSE */
                                    }
                                    else
                                    {


                                        /*" -783- IF V1HISP-NUM-APOL = 109700000027 AND (V0ENDO-DTINIVIG < '1998-02-01' OR V0ENDO-DTINIVIG > '2005-09-30' ) */

                                        if (V1HISP_NUM_APOL == 109700000027 && (V0ENDO_DTINIVIG < "1998-02-01" || V0ENDO_DTINIVIG > "2005-09-30"))
                                        {

                                            /*" -784- MOVE 'N' TO WTEM-COSSEGURO */
                                            _.Move("N", AREA_DE_WORK.WTEM_COSSEGURO);

                                            /*" -785- ELSE */
                                        }
                                        else
                                        {


                                            /*" -788- IF V1HISP-NUM-APOL = 109700000029 AND (V0ENDO-DTINIVIG < '1999-05-01' OR V0ENDO-DTINIVIG > '2001-03-31' ) */

                                            if (V1HISP_NUM_APOL == 109700000029 && (V0ENDO_DTINIVIG < "1999-05-01" || V0ENDO_DTINIVIG > "2001-03-31"))
                                            {

                                                /*" -789- MOVE 'N' TO WTEM-COSSEGURO */
                                                _.Move("N", AREA_DE_WORK.WTEM_COSSEGURO);

                                                /*" -790- ELSE */
                                            }
                                            else
                                            {


                                                /*" -792- IF (V0APOL-RAMO = 66 OR 68) AND V0ENDO-DTINIVIG > '2001-11-30' */

                                                if ((V0APOL_RAMO.In("66", "68")) && V0ENDO_DTINIVIG > "2001-11-30")
                                                {

                                                    /*" -793- MOVE 'N' TO WTEM-COSSEGURO */
                                                    _.Move("N", AREA_DE_WORK.WTEM_COSSEGURO);

                                                    /*" -794- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -795- DISPLAY 'R0600 - NAO EXISTE DISTRIB. DE COSSEGURO' */
                                                    _.Display($"R0600 - NAO EXISTE DISTRIB. DE COSSEGURO");

                                                    /*" -796- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                                                    _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                                                    /*" -797- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                                                    _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                                                    /*" -798- DISPLAY 'INI VIG - ' V0ENDO-DTINIVIG */
                                                    _.Display($"INI VIG - {V0ENDO_DTINIVIG}");

                                                    /*" -802- GO TO R9999-00-ROT-ERRO. */

                                                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                                                    return;
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


            /*" -808- PERFORM R1000-00-PROCESSA-APOLCOSCED UNTIL WFIM-V1APOLCOSCED NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1APOLCOSCED.IsEmpty()))
            {

                R1000_00_PROCESSA_APOLCOSCED_SECTION();
            }

            /*" -810- IF WPCTCED GREATER ZEROS AND V1HISP-NUM-APOL EQUAL 109700000025 */

            if (AREA_DE_WORK.WPCTCED > 00 && V1HISP_NUM_APOL == 109700000025)
            {

                /*" -811- MOVE 1 TO WIND */
                _.Move(1, AREA_DE_WORK.WIND);

                /*" -817- PERFORM R1200-00-CALC-NOVO-PCPARTIC UNTIL WCODCOSS (WIND) EQUAL +0 OR WIND EQUAL 101. */

                while (!(TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WCODCOSS == +0 || AREA_DE_WORK.WIND == 101))
                {

                    R1200_00_CALC_NOVO_PCPARTIC_SECTION();
                }
            }


            /*" -818- IF V0APOL-RAMO = 66 */

            if (V0APOL_RAMO == 66)
            {

                /*" -819- MOVE 1 TO WIND */
                _.Move(1, AREA_DE_WORK.WIND);

                /*" -825- PERFORM R1500-00-CALC-NOVO-PCCOMCOS UNTIL WCODCOSS (WIND) EQUAL +0 OR WIND EQUAL 101. */

                while (!(TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WCODCOSS == +0 || AREA_DE_WORK.WIND == 101))
                {

                    R1500_00_CALC_NOVO_PCCOMCOS_SECTION();
                }
            }


            /*" -826- IF WTEM-COSSEGURO EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_COSSEGURO == "S")
            {

                /*" -830- PERFORM R1700-00-PROCESSA-ENDOSSO UNTIL WFIM-V1HISTOPARC NOT EQUAL SPACES OR V1HISP-NUM-APOL NOT EQUAL WNUM-APOL-ANT OR V1HISP-NRENDOS NOT EQUAL WNRENDOS-ANT */

                while (!(!AREA_DE_WORK.WFIM_V1HISTOPARC.IsEmpty() || V1HISP_NUM_APOL != AREA_DE_WORK.WNUM_APOL_ANT || V1HISP_NRENDOS != AREA_DE_WORK.WNRENDOS_ANT))
                {

                    R1700_00_PROCESSA_ENDOSSO_SECTION();
                }

                /*" -831- ELSE */
            }
            else
            {


                /*" -834- PERFORM R0550-00-FETCH-V1HISTOPARC UNTIL WFIM-V1HISTOPARC NOT EQUAL SPACES OR V1HISP-NUM-APOL NOT EQUAL WNUM-APOL-ANT OR V1HISP-NRENDOS NOT EQUAL WNRENDOS-ANT. */

                while (!(!AREA_DE_WORK.WFIM_V1HISTOPARC.IsEmpty() || V1HISP_NUM_APOL != AREA_DE_WORK.WNUM_APOL_ANT || V1HISP_NRENDOS != AREA_DE_WORK.WNRENDOS_ANT))
                {

                    R0550_00_FETCH_V1HISTOPARC_SECTION();
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-SELECT-GE397-SECTION */
        private void R0700_00_SELECT_GE397_SECTION()
        {
            /*" -847- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", WABEND.WNR_EXEC_SQL);

            /*" -853- PERFORM R0700_00_SELECT_GE397_DB_SELECT_1 */

            R0700_00_SELECT_GE397_DB_SELECT_1();

            /*" -856- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -857- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -858- MOVE ZEROS TO WHOST-QTDE-REG */
                    _.Move(0, WHOST_QTDE_REG);

                    /*" -859- ELSE */
                }
                else
                {


                    /*" -860- DISPLAY 'R0700 - ERRO NO SELECT DA GE-ENDOS-COSSEG-COB' */
                    _.Display($"R0700 - ERRO NO SELECT DA GE-ENDOS-COSSEG-COB");

                    /*" -861- DISPLAY 'APOLICE  - ' V1HISP-NUM-APOL */
                    _.Display($"APOLICE  - {V1HISP_NUM_APOL}");

                    /*" -862- DISPLAY 'ENDOSSO  - ' V1HISP-NRENDOS */
                    _.Display($"ENDOSSO  - {V1HISP_NRENDOS}");

                    /*" -863- DISPLAY 'PARCELA  - ' V1HISP-NRPARCEL */
                    _.Display($"PARCELA  - {V1HISP_NRPARCEL}");

                    /*" -864- DISPLAY 'OCR HIST - ' V1HISP-OCORHIST */
                    _.Display($"OCR HIST - {V1HISP_OCORHIST}");

                    /*" -865- DISPLAY 'DT MOVTO - ' V1HISP-DTMOVTO */
                    _.Display($"DT MOVTO - {V1HISP_DTMOVTO}");

                    /*" -866- DISPLAY 'OPERACAO - ' V1HISP-OPERACAO */
                    _.Display($"OPERACAO - {V1HISP_OPERACAO}");

                    /*" -867- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -868- END-IF */
                }


                /*" -868- END-IF. */
            }


        }

        [StopWatch]
        /*" R0700-00-SELECT-GE397-DB-SELECT-1 */
        public void R0700_00_SELECT_GE397_DB_SELECT_1()
        {
            /*" -853- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WHOST-QTDE-REG FROM SEGUROS.GE_ENDOS_COSSEG_COBER WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NUM_ENDOSSO = :V1HISP-NRENDOS END-EXEC. */

            var r0700_00_SELECT_GE397_DB_SELECT_1_Query1 = new R0700_00_SELECT_GE397_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R0700_00_SELECT_GE397_DB_SELECT_1_Query1.Execute(r0700_00_SELECT_GE397_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTDE_REG, WHOST_QTDE_REG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-SELECT-V0ENDOSSO-SECTION */
        private void R0800_00_SELECT_V0ENDOSSO_SECTION()
        {
            /*" -881- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", WABEND.WNR_EXEC_SQL);

            /*" -893- PERFORM R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1 */

            R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1();

            /*" -896- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -897- DISPLAY 'R0800 - ERRO NO SELECT DA V0ENDOSSO' */
                _.Display($"R0800 - ERRO NO SELECT DA V0ENDOSSO");

                /*" -898- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -899- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -900- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                /*" -901- DISPLAY 'OC HIST - ' V1HISP-OCORHIST */
                _.Display($"OC HIST - {V1HISP_OCORHIST}");

                /*" -901- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0800-00-SELECT-V0ENDOSSO-DB-SELECT-1 */
        public void R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1()
        {
            /*" -893- EXEC SQL SELECT QTPARCEL , DTINIVIG , CORRECAO , CDFRACIO INTO :V0ENDO-QTPARCEL , :V0ENDO-DTINIVIG , :V0ENDO-CORRECAO , :V0ENDO-CDFRACIO FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS END-EXEC. */

            var r0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 = new R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1.Execute(r0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_QTPARCEL, V0ENDO_QTPARCEL);
                _.Move(executed_1.V0ENDO_DTINIVIG, V0ENDO_DTINIVIG);
                _.Move(executed_1.V0ENDO_CORRECAO, V0ENDO_CORRECAO);
                _.Move(executed_1.V0ENDO_CDFRACIO, V0ENDO_CDFRACIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V1APOLCOSCED-SECTION */
        private void R0900_00_DECLARE_V1APOLCOSCED_SECTION()
        {
            /*" -914- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -922- PERFORM R0900_00_DECLARE_V1APOLCOSCED_DB_DECLARE_1 */

            R0900_00_DECLARE_V1APOLCOSCED_DB_DECLARE_1();

            /*" -924- PERFORM R0900_00_DECLARE_V1APOLCOSCED_DB_OPEN_1 */

            R0900_00_DECLARE_V1APOLCOSCED_DB_OPEN_1();

            /*" -927- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -928- DISPLAY 'R0900 - ERRO NO DECLARE DA V1APOLCOSCED' */
                _.Display($"R0900 - ERRO NO DECLARE DA V1APOLCOSCED");

                /*" -929- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -930- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -931- DISPLAY 'INI VIG - ' V0ENDO-DTINIVIG */
                _.Display($"INI VIG - {V0ENDO_DTINIVIG}");

                /*" -932- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -933- ELSE */
            }
            else
            {


                /*" -933- MOVE SPACES TO WFIM-V1APOLCOSCED. */
                _.Move("", AREA_DE_WORK.WFIM_V1APOLCOSCED);
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1APOLCOSCED-DB-OPEN-1 */
        public void R0900_00_DECLARE_V1APOLCOSCED_DB_OPEN_1()
        {
            /*" -924- EXEC SQL OPEN V1APOLCOSCED END-EXEC. */

            V1APOLCOSCED.Open();

        }

        [StopWatch]
        /*" R4100-00-DECLARE-V2HISTOPARC-DB-DECLARE-1 */
        public void R4100_00_DECLARE_V2HISTOPARC_DB_DECLARE_1()
        {
            /*" -2172- EXEC SQL DECLARE V2HISTOPARC CURSOR FOR SELECT A.DTMOVTO , A.OCORHIST , A.OPERACAO , A.PRM_TARIFARIO , A.VAL_DESCONTO , A.VLADIFRA , A.DTQITBCO , B.PRM_TARIFARIO_IX, B.VAL_DESCONTO_IX, B.OTNADFRA FROM SEGUROS.V1HISTOPARC A, SEGUROS.V1PARCELA B WHERE A.NUM_APOLICE = :V1HISP-NUM-APOL AND A.NRENDOS = :V1HISP-NRENDOS AND A.NRPARCEL = :V1HISP-NRPARCEL AND A.DTMOVTO < :V1HISP-DTMOVTO AND B.NUM_APOLICE = :V1HISP-NUM-APOL AND B.NRENDOS = :V1HISP-NRENDOS AND B.NRPARCEL = :V1HISP-NRPARCEL ORDER BY A.OCORHIST END-EXEC. */
            V2HISTOPARC = new AC0010B_V2HISTOPARC(true);
            string GetQuery_V2HISTOPARC()
            {
                var query = @$"SELECT A.DTMOVTO
							, 
							A.OCORHIST
							, 
							A.OPERACAO
							, 
							A.PRM_TARIFARIO
							, 
							A.VAL_DESCONTO
							, 
							A.VLADIFRA
							, 
							A.DTQITBCO
							, 
							B.PRM_TARIFARIO_IX
							, 
							B.VAL_DESCONTO_IX
							, 
							B.OTNADFRA 
							FROM SEGUROS.V1HISTOPARC A
							, 
							SEGUROS.V1PARCELA B 
							WHERE A.NUM_APOLICE = '{V1HISP_NUM_APOL}' 
							AND A.NRENDOS = '{V1HISP_NRENDOS}' 
							AND A.NRPARCEL = '{V1HISP_NRPARCEL}' 
							AND A.DTMOVTO < '{V1HISP_DTMOVTO}' 
							AND B.NUM_APOLICE = '{V1HISP_NUM_APOL}' 
							AND B.NRENDOS = '{V1HISP_NRENDOS}' 
							AND B.NRPARCEL = '{V1HISP_NRPARCEL}' 
							ORDER BY A.OCORHIST";

                return query;
            }
            V2HISTOPARC.GetQueryEvent += GetQuery_V2HISTOPARC;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-FETCH-V1APOLCOSCED-SECTION */
        private void R0950_00_FETCH_V1APOLCOSCED_SECTION()
        {
            /*" -946- MOVE '095' TO WNR-EXEC-SQL. */
            _.Move("095", WABEND.WNR_EXEC_SQL);

            /*" -950- PERFORM R0950_00_FETCH_V1APOLCOSCED_DB_FETCH_1 */

            R0950_00_FETCH_V1APOLCOSCED_DB_FETCH_1();

            /*" -953- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -954- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -955- MOVE 'S' TO WFIM-V1APOLCOSCED */
                    _.Move("S", AREA_DE_WORK.WFIM_V1APOLCOSCED);

                    /*" -955- PERFORM R0950_00_FETCH_V1APOLCOSCED_DB_CLOSE_1 */

                    R0950_00_FETCH_V1APOLCOSCED_DB_CLOSE_1();

                    /*" -957- ELSE */
                }
                else
                {


                    /*" -958- DISPLAY 'R0950 - ERRO NO FETCH DA V1APOLCOSCED' */
                    _.Display($"R0950 - ERRO NO FETCH DA V1APOLCOSCED");

                    /*" -959- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                    _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                    /*" -960- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                    _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                    /*" -961- DISPLAY 'INI VIG - ' V0ENDO-DTINIVIG */
                    _.Display($"INI VIG - {V0ENDO_DTINIVIG}");

                    /*" -961- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0950-00-FETCH-V1APOLCOSCED-DB-FETCH-1 */
        public void R0950_00_FETCH_V1APOLCOSCED_DB_FETCH_1()
        {
            /*" -950- EXEC SQL FETCH V1APOLCOSCED INTO :V1APCD-CODCOSS , :V1APCD-PCPARTIC , :V1APCD-PCCOMCOS END-EXEC. */

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
            /*" -955- EXEC SQL CLOSE V1APOLCOSCED END-EXEC */

            V1APOLCOSCED.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-APOLCOSCED-SECTION */
        private void R1000_00_PROCESSA_APOLCOSCED_SECTION()
        {
            /*" -974- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -976- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -977- IF WIND GREATER 100 */

            if (AREA_DE_WORK.WIND > 100)
            {

                /*" -978- DISPLAY 'R1000 - NR. DE CONGENERES PARTICIPANTES  DA' */
                _.Display($"R1000 - NR. DE CONGENERES PARTICIPANTES  DA");

                /*" -979- DISPLAY 'APOLICE MAIOR QUE OCORRENCIAS DA TABELA-COSCED' */
                _.Display($"APOLICE MAIOR QUE OCORRENCIAS DA TABELA-COSCED");

                /*" -980- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -981- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -982- DISPLAY 'INI VIG - ' V0ENDO-DTINIVIG */
                _.Display($"INI VIG - {V0ENDO_DTINIVIG}");

                /*" -984- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -985- IF V1APCD-CODCOSS EQUAL 5631 */

            if (V1APCD_CODCOSS == 5631)
            {

                /*" -986- DISPLAY 'R1000- DISTRIBUICAO DE COSSEGURO INVALIDA' */
                _.Display($"R1000- DISTRIBUICAO DE COSSEGURO INVALIDA");

                /*" -987- DISPLAY 'APOLICE  - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE  - {V1HISP_NUM_APOL}");

                /*" -988- DISPLAY 'ENDOSSO  - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO  - {V1HISP_NRENDOS}");

                /*" -989- DISPLAY 'INI VIG  - ' V0ENDO-DTINIVIG */
                _.Display($"INI VIG  - {V0ENDO_DTINIVIG}");

                /*" -990- DISPLAY 'COD COSS - ' V1APCD-CODCOSS */
                _.Display($"COD COSS - {V1APCD_CODCOSS}");

                /*" -992- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -994- PERFORM R1100-00-SELECT-V1ORDCOSCED. */

            R1100_00_SELECT_V1ORDCOSCED_SECTION();

            /*" -995- MOVE V1APCD-CODCOSS TO WCODCOSS (WIND). */
            _.Move(V1APCD_CODCOSS, TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WCODCOSS);

            /*" -996- MOVE V1APCD-PCPARTIC TO WPCPARTIC (WIND). */
            _.Move(V1APCD_PCPARTIC, TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WPCPARTIC);

            /*" -997- MOVE V1APCD-PCCOMCOS TO WPCCOMCOS (WIND). */
            _.Move(V1APCD_PCCOMCOS, TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WPCCOMCOS);

            /*" -999- MOVE V1ORDC-ORD-CEDIDO TO WORD-CEDIDO (WIND). */
            _.Move(V1ORDC_ORD_CEDIDO, TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WORD_CEDIDO);

            /*" -1003- ADD V1APCD-PCPARTIC TO WPCTCED. */
            AREA_DE_WORK.WPCTCED.Value = AREA_DE_WORK.WPCTCED + V1APCD_PCPARTIC;

            /*" -1003- PERFORM R0950-00-FETCH-V1APOLCOSCED. */

            R0950_00_FETCH_V1APOLCOSCED_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V1ORDCOSCED-SECTION */
        private void R1100_00_SELECT_V1ORDCOSCED_SECTION()
        {
            /*" -1016- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WABEND.WNR_EXEC_SQL);

            /*" -1023- PERFORM R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1 */

            R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1();

            /*" -1026- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1027- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1028- MOVE ZEROS TO V1ORDC-ORD-CEDIDO */
                    _.Move(0, V1ORDC_ORD_CEDIDO);

                    /*" -1029- DISPLAY 'R1100 - NAO EXISTE NUM. ORDEM NA V1ORDCOSCED' */
                    _.Display($"R1100 - NAO EXISTE NUM. ORDEM NA V1ORDCOSCED");

                    /*" -1030- DISPLAY 'APOLICE  - ' V1HISP-NUM-APOL */
                    _.Display($"APOLICE  - {V1HISP_NUM_APOL}");

                    /*" -1031- DISPLAY 'ENDOSSO  - ' V1HISP-NRENDOS */
                    _.Display($"ENDOSSO  - {V1HISP_NRENDOS}");

                    /*" -1032- DISPLAY 'INI VIG  - ' V0ENDO-DTINIVIG */
                    _.Display($"INI VIG  - {V0ENDO_DTINIVIG}");

                    /*" -1033- DISPLAY 'COD COSS - ' V1APCD-CODCOSS */
                    _.Display($"COD COSS - {V1APCD_CODCOSS}");

                    /*" -1034- ELSE */
                }
                else
                {


                    /*" -1035- DISPLAY 'R1100 - ERRO NO SELECT DA V1ORDCOSCED' */
                    _.Display($"R1100 - ERRO NO SELECT DA V1ORDCOSCED");

                    /*" -1036- DISPLAY 'APOLICE  - ' V1HISP-NUM-APOL */
                    _.Display($"APOLICE  - {V1HISP_NUM_APOL}");

                    /*" -1037- DISPLAY 'ENDOSSO  - ' V1HISP-NRENDOS */
                    _.Display($"ENDOSSO  - {V1HISP_NRENDOS}");

                    /*" -1038- DISPLAY 'INI VIG  - ' V0ENDO-DTINIVIG */
                    _.Display($"INI VIG  - {V0ENDO_DTINIVIG}");

                    /*" -1039- DISPLAY 'COD COSS - ' V1APCD-CODCOSS */
                    _.Display($"COD COSS - {V1APCD_CODCOSS}");

                    /*" -1039- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-V1ORDCOSCED-DB-SELECT-1 */
        public void R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1()
        {
            /*" -1023- EXEC SQL SELECT ORDEM_CEDIDO INTO :V1ORDC-ORD-CEDIDO FROM SEGUROS.V1ORDECOSCED WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS AND CODCOSS = :V1APCD-CODCOSS END-EXEC. */

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
        /*" R1200-00-CALC-NOVO-PCPARTIC-SECTION */
        private void R1200_00_CALC_NOVO_PCPARTIC_SECTION()
        {
            /*" -1052- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -1054- PERFORM R1300-00-SUM-V1PARC-COMPL. */

            R1300_00_SUM_V1PARC_COMPL_SECTION();

            /*" -1055- IF V3PCOM-VLR-COMPL EQUAL ZEROS */

            if (V3PCOM_VLR_COMPL == 00)
            {

                /*" -1056- MOVE 101 TO WIND */
                _.Move(101, AREA_DE_WORK.WIND);

                /*" -1058- GO TO R1200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1060- PERFORM R1400-00-SUM-V1HISTOPARC. */

            R1400_00_SUM_V1HISTOPARC_SECTION();

            /*" -1061- IF V3HISP-PRM-TAR EQUAL ZEROS */

            if (V3HISP_PRM_TAR == 00)
            {

                /*" -1062- MOVE 101 TO WIND */
                _.Move(101, AREA_DE_WORK.WIND);

                /*" -1064- GO TO R1200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1067- COMPUTE WPART-COB-8105 ROUNDED = V3PCOM-VLR-COMPL / V3HISP-PRM-TAR. */
            AREA_DE_WORK.WPART_COB_8105.Value = V3PCOM_VLR_COMPL / V3HISP_PRM_TAR;

            /*" -1069- COMPUTE WPCTCED-NOVO = ((100 - WPCTCED) * WPART-COB-8105) + WPCTCED. */
            AREA_DE_WORK.WPCTCED_NOVO.Value = ((100 - AREA_DE_WORK.WPCTCED) * AREA_DE_WORK.WPART_COB_8105) + AREA_DE_WORK.WPCTCED;

            /*" -0- FLUXCONTROL_PERFORM R1200_10_CALC_NOVO_PCPARTIC */

            R1200_10_CALC_NOVO_PCPARTIC();

        }

        [StopWatch]
        /*" R1200-10-CALC-NOVO-PCPARTIC */
        private void R1200_10_CALC_NOVO_PCPARTIC(bool isPerform = false)
        {
            /*" -1077- COMPUTE WPCPARTIC (WIND) ROUNDED = WPCPARTIC (WIND) * WPCTCED-NOVO / WPCTCED. */
            TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WPCPARTIC.Value = TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WPCPARTIC.Value * AREA_DE_WORK.WPCTCED_NOVO / AREA_DE_WORK.WPCTCED;

            /*" -1079- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -1081- IF WIND NOT = 101 AND WCODCOSS (WIND) NOT = 0 */

            if (AREA_DE_WORK.WIND != 101 && TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WCODCOSS != 0)
            {

                /*" -1081- GO TO R1200-10-CALC-NOVO-PCPARTIC. */
                new Task(() => R1200_10_CALC_NOVO_PCPARTIC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SUM-V1PARC-COMPL-SECTION */
        private void R1300_00_SUM_V1PARC_COMPL_SECTION()
        {
            /*" -1094- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -1102- PERFORM R1300_00_SUM_V1PARC_COMPL_DB_SELECT_1 */

            R1300_00_SUM_V1PARC_COMPL_DB_SELECT_1();

            /*" -1105- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1106- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1107- MOVE ZEROS TO V3PCOM-VLR-COMPL-IX */
                    _.Move(0, V3PCOM_VLR_COMPL_IX);

                    /*" -1108- MOVE ZEROS TO V3PCOM-VLR-COMPL */
                    _.Move(0, V3PCOM_VLR_COMPL);

                    /*" -1109- ELSE */
                }
                else
                {


                    /*" -1110- DISPLAY 'R1300 - ERRO NO SELECT DA V1PARCELA-COMPL' */
                    _.Display($"R1300 - ERRO NO SELECT DA V1PARCELA-COMPL");

                    /*" -1111- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                    _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                    /*" -1112- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                    _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                    /*" -1113- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                    _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                    /*" -1113- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1300-00-SUM-V1PARC-COMPL-DB-SELECT-1 */
        public void R1300_00_SUM_V1PARC_COMPL_DB_SELECT_1()
        {
            /*" -1102- EXEC SQL SELECT VALUE(SUM(VLR_COMPLEMENT_IX),+0) , VALUE(SUM(VLR_COMPLEMENTO),+0) INTO :V3PCOM-VLR-COMPL-IX , :V3PCOM-VLR-COMPL FROM SEGUROS.V1PARCELA_COMPL WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS END-EXEC. */

            var r1300_00_SUM_V1PARC_COMPL_DB_SELECT_1_Query1 = new R1300_00_SUM_V1PARC_COMPL_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R1300_00_SUM_V1PARC_COMPL_DB_SELECT_1_Query1.Execute(r1300_00_SUM_V1PARC_COMPL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V3PCOM_VLR_COMPL_IX, V3PCOM_VLR_COMPL_IX);
                _.Move(executed_1.V3PCOM_VLR_COMPL, V3PCOM_VLR_COMPL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SUM-V1HISTOPARC-SECTION */
        private void R1400_00_SUM_V1HISTOPARC_SECTION()
        {
            /*" -1126- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", WABEND.WNR_EXEC_SQL);

            /*" -1138- PERFORM R1400_00_SUM_V1HISTOPARC_DB_SELECT_1 */

            R1400_00_SUM_V1HISTOPARC_DB_SELECT_1();

            /*" -1141- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1142- DISPLAY 'R1400 - ERRO NO SELECT DA V1HISTOPARC' */
                _.Display($"R1400 - ERRO NO SELECT DA V1HISTOPARC");

                /*" -1143- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -1144- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -1144- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1400-00-SUM-V1HISTOPARC-DB-SELECT-1 */
        public void R1400_00_SUM_V1HISTOPARC_DB_SELECT_1()
        {
            /*" -1138- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO),+0) , VALUE(SUM(VAL_DESCONTO),+0) , VALUE(SUM(VLADIFRA),+0) INTO :V3HISP-PRM-TAR , :V3HISP-VAL-DES , :V3HISP-VLADIFRA FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS AND OCORHIST = 01 AND OPERACAO < 0200 END-EXEC. */

            var r1400_00_SUM_V1HISTOPARC_DB_SELECT_1_Query1 = new R1400_00_SUM_V1HISTOPARC_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R1400_00_SUM_V1HISTOPARC_DB_SELECT_1_Query1.Execute(r1400_00_SUM_V1HISTOPARC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V3HISP_PRM_TAR, V3HISP_PRM_TAR);
                _.Move(executed_1.V3HISP_VAL_DES, V3HISP_VAL_DES);
                _.Move(executed_1.V3HISP_VLADIFRA, V3HISP_VLADIFRA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-CALC-NOVO-PCCOMCOS-SECTION */
        private void R1500_00_CALC_NOVO_PCCOMCOS_SECTION()
        {
            /*" -1157- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WABEND.WNR_EXEC_SQL);

            /*" -1159- PERFORM R1600-00-SELECT-MOVTO-HABIT. */

            R1600_00_SELECT_MOVTO_HABIT_SECTION();

            /*" -1161- IF MOVHBT-VAL-REMUN EQUAL ZEROS AND MOVHBT-VAL-SUSEP EQUAL ZEROS */

            if (MOVHBT_VAL_REMUN == 00 && MOVHBT_VAL_SUSEP == 00)
            {

                /*" -1162- MOVE 101 TO WIND */
                _.Move(101, AREA_DE_WORK.WIND);

                /*" -1164- GO TO R1500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1166- PERFORM R1300-00-SUM-V1PARC-COMPL. */

            R1300_00_SUM_V1PARC_COMPL_SECTION();

            /*" -1167- IF V3PCOM-VLR-COMPL EQUAL ZEROS */

            if (V3PCOM_VLR_COMPL == 00)
            {

                /*" -1168- MOVE 101 TO WIND */
                _.Move(101, AREA_DE_WORK.WIND);

                /*" -1170- GO TO R1500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1172- PERFORM R1400-00-SUM-V1HISTOPARC. */

            R1400_00_SUM_V1HISTOPARC_SECTION();

            /*" -1173- IF V3HISP-PRM-TAR EQUAL ZEROS */

            if (V3HISP_PRM_TAR == 00)
            {

                /*" -1174- MOVE 101 TO WIND */
                _.Move(101, AREA_DE_WORK.WIND);

                /*" -1176- GO TO R1500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1179- COMPUTE WPROP-VAL-REMUN ROUNDED = (MOVHBT-VAL-REMUN + MOVHBT-VAL-SUSEP) / (V3HISP-PRM-TAR - V3PCOM-VLR-COMPL). */
            AREA_DE_WORK.WPROP_VAL_REMUN.Value = (MOVHBT_VAL_REMUN + MOVHBT_VAL_SUSEP) / (V3HISP_PRM_TAR - V3PCOM_VLR_COMPL);

            /*" -0- FLUXCONTROL_PERFORM R1500_10_CALC_NOVO_PCCOMCOS */

            R1500_10_CALC_NOVO_PCCOMCOS();

        }

        [StopWatch]
        /*" R1500-10-CALC-NOVO-PCCOMCOS */
        private void R1500_10_CALC_NOVO_PCCOMCOS(bool isPerform = false)
        {
            /*" -1187- COMPUTE WPCCOMCOS (WIND) ROUNDED = (WPCCOMCOS (WIND) * WPROP-VAL-REMUN) + WPCCOMCOS (WIND). */
            TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WPCCOMCOS.Value = (TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WPCCOMCOS.Value * AREA_DE_WORK.WPROP_VAL_REMUN) + TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WPCCOMCOS.Value;

            /*" -1189- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -1191- IF WIND NOT = 101 AND WCODCOSS (WIND) NOT = 0 */

            if (AREA_DE_WORK.WIND != 101 && TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WCODCOSS != 0)
            {

                /*" -1191- GO TO R1500-10-CALC-NOVO-PCCOMCOS. */
                new Task(() => R1500_10_CALC_NOVO_PCCOMCOS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-MOVTO-HABIT-SECTION */
        private void R1600_00_SELECT_MOVTO_HABIT_SECTION()
        {
            /*" -1204- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", WABEND.WNR_EXEC_SQL);

            /*" -1218- PERFORM R1600_00_SELECT_MOVTO_HABIT_DB_SELECT_1 */

            R1600_00_SELECT_MOVTO_HABIT_DB_SELECT_1();

            /*" -1221- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1222- DISPLAY 'R1600 - ERRO NO SELECT DA MOVIMENTO-HABIT' */
                _.Display($"R1600 - ERRO NO SELECT DA MOVIMENTO-HABIT");

                /*" -1223- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -1224- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -1225- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                /*" -1226- DISPLAY 'OC. HIST- ' V1HISP-OCORHIST */
                _.Display($"OC. HIST- {V1HISP_OCORHIST}");

                /*" -1226- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1600-00-SELECT-MOVTO-HABIT-DB-SELECT-1 */
        public void R1600_00_SELECT_MOVTO_HABIT_DB_SELECT_1()
        {
            /*" -1218- EXEC SQL SELECT NUM_APOLICE, NUM_ENDOSSO, VAL_REMUNERA, VAL_SUSEP INTO :MOVHBT-NUM-APOL, :MOVHBT-NUM-ENDS:VIND-NUM-ENDS, :MOVHBT-VAL-REMUN, :MOVHBT-VAL-SUSEP FROM SEGUROS.MOVIMENTO_HABIT WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NUM_ENDOSSO = :V1HISP-NRENDOS AND NUM_PARCELA = :V1HISP-NRPARCEL AND OCORR_HISTORICO = 01 END-EXEC. */

            var r1600_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1 = new R1600_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRPARCEL = V1HISP_NRPARCEL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R1600_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1.Execute(r1600_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVHBT_NUM_APOL, MOVHBT_NUM_APOL);
                _.Move(executed_1.MOVHBT_NUM_ENDS, MOVHBT_NUM_ENDS);
                _.Move(executed_1.VIND_NUM_ENDS, VIND_NUM_ENDS);
                _.Move(executed_1.MOVHBT_VAL_REMUN, MOVHBT_VAL_REMUN);
                _.Move(executed_1.MOVHBT_VAL_SUSEP, MOVHBT_VAL_SUSEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-PROCESSA-ENDOSSO-SECTION */
        private void R1700_00_PROCESSA_ENDOSSO_SECTION()
        {
            /*" -1239- MOVE '170' TO WNR-EXEC-SQL. */
            _.Move("170", WABEND.WNR_EXEC_SQL);

            /*" -1242- MOVE +0 TO V1PCOM-VLR-COMPL V1PCOM-VLR-COMPL-IX. */
            _.Move(+0, V1PCOM_VLR_COMPL, V1PCOM_VLR_COMPL_IX);

            /*" -1245- MOVE 01 TO WIND. */
            _.Move(01, AREA_DE_WORK.WIND);

            /*" -1246- IF WTIPO-OPERACAO EQUAL 01 */

            if (AREA_DE_WORK.FILLER_0.WTIPO_OPERACAO == 01)
            {

                /*" -1250- PERFORM R1800-00-OPERACAO-EMISSAO UNTIL WCODCOSS (WIND) EQUAL +0 OR WIND EQUAL 101 */

                while (!(TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WCODCOSS == +0 || AREA_DE_WORK.WIND == 101))
                {

                    R1800_00_OPERACAO_EMISSAO_SECTION();
                }

                /*" -1251- ELSE */
            }
            else
            {


                /*" -1256- PERFORM R3000-00-OPER-DIF-EMISSAO UNTIL WCODCOSS (WIND) EQUAL +0 OR WIND EQUAL 101. */

                while (!(TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WCODCOSS == +0 || AREA_DE_WORK.WIND == 101))
                {

                    R3000_00_OPER_DIF_EMISSAO_SECTION();
                }
            }


            /*" -1256- PERFORM R0550-00-FETCH-V1HISTOPARC. */

            R0550_00_FETCH_V1HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-OPERACAO-EMISSAO-SECTION */
        private void R1800_00_OPERACAO_EMISSAO_SECTION()
        {
            /*" -1269- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", WABEND.WNR_EXEC_SQL);

            /*" -1270- MOVE WCODCOSS (WIND) TO V1APCD-CODCOSS. */
            _.Move(TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WCODCOSS, V1APCD_CODCOSS);

            /*" -1271- MOVE WPCPARTIC (WIND) TO WS-PCPARTIC. */
            _.Move(TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WPCPARTIC, AREA_DE_WORK.WS_PCPARTIC);

            /*" -1272- MOVE WPCCOMCOS (WIND) TO WS-PCCOMCOS. */
            _.Move(TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WPCCOMCOS, AREA_DE_WORK.WS_PCCOMCOS);

            /*" -1274- MOVE WORD-CEDIDO (WIND) TO V1ORDC-ORD-CEDIDO. */
            _.Move(TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WORD_CEDIDO, V1ORDC_ORD_CEDIDO);

            /*" -1276- IF V1APCD-CODCOSS = 5240 AND V1HISP-NRENDOS = ZEROS */

            if (V1APCD_CODCOSS == 5240 && V1HISP_NRENDOS == 00)
            {

                /*" -1277- DISPLAY '*** EMISSAO PARA A CONGENERE 5240 ***' */
                _.Display($"*** EMISSAO PARA A CONGENERE 5240 ***");

                /*" -1278- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -1279- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1281- END-IF. */
            }


            /*" -1282- IF WIND = 01 */

            if (AREA_DE_WORK.WIND == 01)
            {

                /*" -1283- PERFORM R1900-00-SELECT-V1PARCELA */

                R1900_00_SELECT_V1PARCELA_SECTION();

                /*" -1284- IF V0APOL-RAMO = 16 OR 18 OR 31 OR 66 OR 68 */

                if (V0APOL_RAMO.In("16", "18", "31", "66", "68"))
                {

                    /*" -1285- PERFORM R2000-00-PROCESSA-V1PARC-COMPL */

                    R2000_00_PROCESSA_V1PARC_COMPL_SECTION();

                    /*" -1286- END-IF */
                }


                /*" -1288- END-IF. */
            }


            /*" -1290- PERFORM R2200-00-PROCESSA-CALCULOS. */

            R2200_00_PROCESSA_CALCULOS_SECTION();

            /*" -1292- PERFORM R2500-00-MONTA-COSSEG-PREM. */

            R2500_00_MONTA_COSSEG_PREM_SECTION();

            /*" -1294- PERFORM R2600-00-INSERT-COSSEG-PREM. */

            R2600_00_INSERT_COSSEG_PREM_SECTION();

            /*" -1296- PERFORM R2700-00-MONTA-COSSEG-HIST. */

            R2700_00_MONTA_COSSEG_HIST_SECTION();

            /*" -1298- PERFORM R2900-00-INSERT-COSSEG-HIST. */

            R2900_00_INSERT_COSSEG_HIST_SECTION();

            /*" -1298- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-SELECT-V1PARCELA-SECTION */
        private void R1900_00_SELECT_V1PARCELA_SECTION()
        {
            /*" -1311- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", WABEND.WNR_EXEC_SQL);

            /*" -1322- PERFORM R1900_00_SELECT_V1PARCELA_DB_SELECT_1 */

            R1900_00_SELECT_V1PARCELA_DB_SELECT_1();

            /*" -1325- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1326- DISPLAY 'R1900 - ERRO NO SELECT DA V1PARCELA' */
                _.Display($"R1900 - ERRO NO SELECT DA V1PARCELA");

                /*" -1327- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -1328- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -1329- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                /*" -1330- DISPLAY 'OC HIST - ' V1HISP-OCORHIST */
                _.Display($"OC HIST - {V1HISP_OCORHIST}");

                /*" -1330- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1900-00-SELECT-V1PARCELA-DB-SELECT-1 */
        public void R1900_00_SELECT_V1PARCELA_DB_SELECT_1()
        {
            /*" -1322- EXEC SQL SELECT PRM_TARIFARIO_IX , VAL_DESCONTO_IX , OTNADFRA INTO :V1PARC-PRM-TAR , :V1PARC-VAL-DES , :V1PARC-OTNADFRA FROM SEGUROS.V1PARCELA WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS AND NRPARCEL = :V1HISP-NRPARCEL END-EXEC. */

            var r1900_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 = new R1900_00_SELECT_V1PARCELA_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRPARCEL = V1HISP_NRPARCEL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R1900_00_SELECT_V1PARCELA_DB_SELECT_1_Query1.Execute(r1900_00_SELECT_V1PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARC_PRM_TAR, V1PARC_PRM_TAR);
                _.Move(executed_1.V1PARC_VAL_DES, V1PARC_VAL_DES);
                _.Move(executed_1.V1PARC_OTNADFRA, V1PARC_OTNADFRA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-V1PARC-COMPL-SECTION */
        private void R2000_00_PROCESSA_V1PARC_COMPL_SECTION()
        {
            /*" -1343- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WABEND.WNR_EXEC_SQL);

            /*" -1346- MOVE ZEROS TO WS-VLR-COMPL WS-VLR-COMPL-IX. */
            _.Move(0, AREA_DE_WORK.WS_VLR_COMPL, AREA_DE_WORK.WS_VLR_COMPL_IX);

            /*" -1348- PERFORM R2100-00-SELECT-V1PARC-COMPL. */

            R2100_00_SELECT_V1PARC_COMPL_SECTION();

            /*" -1349- IF V1PCOM-VLR-COMPL = ZEROS */

            if (V1PCOM_VLR_COMPL == 00)
            {

                /*" -1350- GO TO R2000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;

                /*" -1351- ELSE */
            }
            else
            {


                /*" -1352- IF V0APOL-RAMO = 16 OR 18 */

                if (V0APOL_RAMO.In("16", "18"))
                {

                    /*" -1353- MOVE V1PCOM-VLR-COMPL TO WS-VLR-COMPL */
                    _.Move(V1PCOM_VLR_COMPL, AREA_DE_WORK.WS_VLR_COMPL);

                    /*" -1356- MOVE V1PCOM-VLR-COMPL-IX TO WS-VLR-COMPL-IX. */
                    _.Move(V1PCOM_VLR_COMPL_IX, AREA_DE_WORK.WS_VLR_COMPL_IX);
                }

            }


            /*" -1361- COMPUTE WPROP-VAL-DES ROUNDED = V1HISP-VAL-DES / (V1HISP-PRM-TAR - WS-VLR-COMPL) ON SIZE ERROR MOVE ZEROS TO WPROP-VAL-DES END-COMPUTE. */
            if (V1HISP_PRM_TAR.Value - AREA_DE_WORK.WS_VLR_COMPL.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROP_VAL_DES);
            else

                AREA_DE_WORK.WPROP_VAL_DES.Value = V1HISP_VAL_DES / (V1HISP_PRM_TAR - AREA_DE_WORK.WS_VLR_COMPL);

            /*" -1366- COMPUTE WPROP-VLADIFRA ROUNDED = V1HISP-VLADIFRA / (V1HISP-PRM-TAR - V1HISP-VAL-DES) ON SIZE ERROR MOVE ZEROS TO WPROP-VLADIFRA END-COMPUTE. */
            if (V1HISP_PRM_TAR.Value - V1HISP_VAL_DES.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROP_VLADIFRA);
            else

                AREA_DE_WORK.WPROP_VLADIFRA.Value = V1HISP_VLADIFRA / (V1HISP_PRM_TAR - V1HISP_VAL_DES);

            /*" -1369- COMPUTE V1HISP-PRM-TAR = V1HISP-PRM-TAR - V1PCOM-VLR-COMPL. */
            V1HISP_PRM_TAR.Value = V1HISP_PRM_TAR - V1PCOM_VLR_COMPL;

            /*" -1372- COMPUTE V1HISP-VAL-DES ROUNDED = V1HISP-PRM-TAR * WPROP-VAL-DES. */
            V1HISP_VAL_DES.Value = V1HISP_PRM_TAR * AREA_DE_WORK.WPROP_VAL_DES;

            /*" -1377- COMPUTE V1HISP-VLADIFRA ROUNDED = (V1HISP-PRM-TAR - V1HISP-VAL-DES) * WPROP-VLADIFRA. */
            V1HISP_VLADIFRA.Value = (V1HISP_PRM_TAR - V1HISP_VAL_DES) * AREA_DE_WORK.WPROP_VLADIFRA;

            /*" -1382- COMPUTE WPROP-VAL-DES ROUNDED = V1PARC-VAL-DES / (V1PARC-PRM-TAR - WS-VLR-COMPL-IX) ON SIZE ERROR MOVE ZEROS TO WPROP-VAL-DES END-COMPUTE. */
            if (V1PARC_PRM_TAR.Value - AREA_DE_WORK.WS_VLR_COMPL_IX.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROP_VAL_DES);
            else

                AREA_DE_WORK.WPROP_VAL_DES.Value = V1PARC_VAL_DES / (V1PARC_PRM_TAR - AREA_DE_WORK.WS_VLR_COMPL_IX);

            /*" -1387- COMPUTE WPROP-VLADIFRA ROUNDED = V1PARC-OTNADFRA / (V1PARC-PRM-TAR - V1PARC-VAL-DES) ON SIZE ERROR MOVE ZEROS TO WPROP-VLADIFRA END-COMPUTE. */
            if (V1PARC_PRM_TAR.Value - V1PARC_VAL_DES.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROP_VLADIFRA);
            else

                AREA_DE_WORK.WPROP_VLADIFRA.Value = V1PARC_OTNADFRA / (V1PARC_PRM_TAR - V1PARC_VAL_DES);

            /*" -1390- COMPUTE V1PARC-PRM-TAR = V1PARC-PRM-TAR - V1PCOM-VLR-COMPL-IX. */
            V1PARC_PRM_TAR.Value = V1PARC_PRM_TAR - V1PCOM_VLR_COMPL_IX;

            /*" -1393- COMPUTE V1PARC-VAL-DES ROUNDED = V1PARC-PRM-TAR * WPROP-VAL-DES. */
            V1PARC_VAL_DES.Value = V1PARC_PRM_TAR * AREA_DE_WORK.WPROP_VAL_DES;

            /*" -1395- COMPUTE V1PARC-OTNADFRA ROUNDED = (V1PARC-PRM-TAR - V1PARC-VAL-DES) * WPROP-VLADIFRA. */
            V1PARC_OTNADFRA.Value = (V1PARC_PRM_TAR - V1PARC_VAL_DES) * AREA_DE_WORK.WPROP_VLADIFRA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-V1PARC-COMPL-SECTION */
        private void R2100_00_SELECT_V1PARC_COMPL_SECTION()
        {
            /*" -1408- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WABEND.WNR_EXEC_SQL);

            /*" -1417- PERFORM R2100_00_SELECT_V1PARC_COMPL_DB_SELECT_1 */

            R2100_00_SELECT_V1PARC_COMPL_DB_SELECT_1();

            /*" -1420- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1421- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1422- MOVE ZEROS TO V1PCOM-VLR-COMPL-IX */
                    _.Move(0, V1PCOM_VLR_COMPL_IX);

                    /*" -1423- MOVE ZEROS TO V1PCOM-VLR-COMPL */
                    _.Move(0, V1PCOM_VLR_COMPL);

                    /*" -1424- ELSE */
                }
                else
                {


                    /*" -1425- DISPLAY 'R2100 - ERRO NO SELECT DA V1PARCELA-COMPL' */
                    _.Display($"R2100 - ERRO NO SELECT DA V1PARCELA-COMPL");

                    /*" -1426- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                    _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                    /*" -1427- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                    _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                    /*" -1428- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                    _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                    /*" -1428- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2100-00-SELECT-V1PARC-COMPL-DB-SELECT-1 */
        public void R2100_00_SELECT_V1PARC_COMPL_DB_SELECT_1()
        {
            /*" -1417- EXEC SQL SELECT VLR_COMPLEMENT_IX, VLR_COMPLEMENTO INTO :V1PCOM-VLR-COMPL-IX, :V1PCOM-VLR-COMPL FROM SEGUROS.V1PARCELA_COMPL WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS AND NRPARCEL = :V1HISP-NRPARCEL END-EXEC. */

            var r2100_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1 = new R2100_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRPARCEL = V1HISP_NRPARCEL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R2100_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1.Execute(r2100_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PCOM_VLR_COMPL_IX, V1PCOM_VLR_COMPL_IX);
                _.Move(executed_1.V1PCOM_VLR_COMPL, V1PCOM_VLR_COMPL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-CALCULOS-SECTION */
        private void R2200_00_PROCESSA_CALCULOS_SECTION()
        {
            /*" -1441- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", WABEND.WNR_EXEC_SQL);

            /*" -1445- COMPUTE V0CHIS-PRM-TAR = V1HISP-PRM-TAR * WS-PCPARTIC / 100. */
            V0CHIS_PRM_TAR.Value = V1HISP_PRM_TAR * AREA_DE_WORK.WS_PCPARTIC / 100f;

            /*" -1449- COMPUTE V0CHIS-VAL-DES = V1HISP-VAL-DES * WS-PCPARTIC / 100. */
            V0CHIS_VAL_DES.Value = V1HISP_VAL_DES * AREA_DE_WORK.WS_PCPARTIC / 100f;

            /*" -1452- COMPUTE V0CHIS-VLPRMLIQ = V0CHIS-PRM-TAR - V0CHIS-VAL-DES. */
            V0CHIS_VLPRMLIQ.Value = V0CHIS_PRM_TAR - V0CHIS_VAL_DES;

            /*" -1457- COMPUTE V0CHIS-VLADIFRA = V1HISP-VLADIFRA * WS-PCPARTIC / 100. */
            V0CHIS_VLADIFRA.Value = V1HISP_VLADIFRA * AREA_DE_WORK.WS_PCPARTIC / 100f;

            /*" -1461- COMPUTE V0CPRE-PRM-TAR-IX = V1PARC-PRM-TAR * WS-PCPARTIC / 100. */
            V0CPRE_PRM_TAR_IX.Value = V1PARC_PRM_TAR * AREA_DE_WORK.WS_PCPARTIC / 100f;

            /*" -1465- COMPUTE V0CPRE-VAL-DES-IX = V1PARC-VAL-DES * WS-PCPARTIC / 100. */
            V0CPRE_VAL_DES_IX.Value = V1PARC_VAL_DES * AREA_DE_WORK.WS_PCPARTIC / 100f;

            /*" -1468- COMPUTE V0CPRE-OTNPRLIQ = V0CPRE-PRM-TAR-IX - V0CPRE-VAL-DES-IX. */
            V0CPRE_OTNPRLIQ.Value = V0CPRE_PRM_TAR_IX - V0CPRE_VAL_DES_IX;

            /*" -1473- COMPUTE V0CPRE-OTNADFRA = V1PARC-OTNADFRA * WS-PCPARTIC / 100. */
            V0CPRE_OTNADFRA.Value = V1PARC_OTNADFRA * AREA_DE_WORK.WS_PCPARTIC / 100f;

            /*" -1476- IF V0ENDO-CDFRACIO GREATER 0 AND V0ENDO-QTPARCEL GREATER 1 AND V1HISP-DTMOVTO NOT LESS WDAT-LIMT-COMS */

            if (V0ENDO_CDFRACIO > 0 && V0ENDO_QTPARCEL > 1 && V1HISP_DTMOVTO >= AREA_DE_WORK.WDAT_LIMT_COMS)
            {

                /*" -1477- PERFORM R2300-00-COMISSAO-ACELERADA */

                R2300_00_COMISSAO_ACELERADA_SECTION();

                /*" -1478- ELSE */
            }
            else
            {


                /*" -1482- COMPUTE V0CHIS-VLCOMIS = (V0CHIS-VLPRMLIQ + V0CHIS-VLADIFRA) * WS-PCCOMCOS / 100 */
                V0CHIS_VLCOMIS.Value = (V0CHIS_VLPRMLIQ + V0CHIS_VLADIFRA) * AREA_DE_WORK.WS_PCCOMCOS / 100f;

                /*" -1487- COMPUTE V0CPRE-VLCOMISIX = ((V0CPRE-OTNPRLIQ + V0CPRE-OTNADFRA) * WS-PCCOMCOS / 100). */
                V0CPRE_VLCOMISIX.Value = ((V0CPRE_OTNPRLIQ + V0CPRE_OTNADFRA) * AREA_DE_WORK.WS_PCCOMCOS / 100f);
            }


            /*" -1488- IF V0ENDO-CORRECAO EQUAL '1' OR '3' */

            if (V0ENDO_CORRECAO.In("1", "3"))
            {

                /*" -1489- MOVE V0CHIS-PRM-TAR TO V0CPRE-PRM-TAR-IX */
                _.Move(V0CHIS_PRM_TAR, V0CPRE_PRM_TAR_IX);

                /*" -1490- MOVE V0CHIS-VAL-DES TO V0CPRE-VAL-DES-IX */
                _.Move(V0CHIS_VAL_DES, V0CPRE_VAL_DES_IX);

                /*" -1491- MOVE V0CHIS-VLPRMLIQ TO V0CPRE-OTNPRLIQ */
                _.Move(V0CHIS_VLPRMLIQ, V0CPRE_OTNPRLIQ);

                /*" -1492- MOVE V0CHIS-VLADIFRA TO V0CPRE-OTNADFRA */
                _.Move(V0CHIS_VLADIFRA, V0CPRE_OTNADFRA);

                /*" -1494- MOVE V0CHIS-VLCOMIS TO V0CPRE-VLCOMISIX. */
                _.Move(V0CHIS_VLCOMIS, V0CPRE_VLCOMISIX);
            }


            /*" -1498- COMPUTE V0CHIS-VLPRMTOT = V0CHIS-VLPRMLIQ + V0CHIS-VLADIFRA - V0CHIS-VLCOMIS. */
            V0CHIS_VLPRMTOT.Value = V0CHIS_VLPRMLIQ + V0CHIS_VLADIFRA - V0CHIS_VLCOMIS;

            /*" -1500- COMPUTE V0CPRE-OTNTOTAL = (V0CPRE-OTNPRLIQ + V0CPRE-OTNADFRA - V0CPRE-VLCOMISIX). */
            V0CPRE_OTNTOTAL.Value = (V0CPRE_OTNPRLIQ + V0CPRE_OTNADFRA - V0CPRE_VLCOMISIX);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-COMISSAO-ACELERADA-SECTION */
        private void R2300_00_COMISSAO_ACELERADA_SECTION()
        {
            /*" -1513- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", WABEND.WNR_EXEC_SQL);

            /*" -1515- PERFORM R2350-00-SELECT-V1PLANCOMIS. */

            R2350_00_SELECT_V1PLANCOMIS_SECTION();

            /*" -1516- IF V1PLCO-PCCOMSEG EQUAL ZEROS */

            if (V1PLCO_PCCOMSEG == 00)
            {

                /*" -1518- MOVE +0 TO V0CHIS-VLCOMIS V0CPRE-VLCOMISIX */
                _.Move(+0, V0CHIS_VLCOMIS, V0CPRE_VLCOMISIX);

                /*" -1520- GO TO R2300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1522- PERFORM R2400-00-SUM-V1PARCELA. */

            R2400_00_SUM_V1PARCELA_SECTION();

            /*" -1524- PERFORM R1400-00-SUM-V1HISTOPARC. */

            R1400_00_SUM_V1HISTOPARC_SECTION();

            /*" -1525- IF V1PCOM-VLR-COMPL NOT EQUAL ZEROS */

            if (V1PCOM_VLR_COMPL != 00)
            {

                /*" -1526- PERFORM R1300-00-SUM-V1PARC-COMPL */

                R1300_00_SUM_V1PARC_COMPL_SECTION();

                /*" -1528- PERFORM R2450-00-PROCESSA-V1PARC-COMPL. */

                R2450_00_PROCESSA_V1PARC_COMPL_SECTION();
            }


            /*" -1538- COMPUTE V0CHIS-VLCOMIS ROUNDED = ((((V3HISP-PRM-TAR - V3HISP-VAL-DES + V3HISP-VLADIFRA) * WS-PCPARTIC / 100) * WS-PCCOMCOS / 100) * V1PLCO-PCCOMSEG / 100). */
            V0CHIS_VLCOMIS.Value = ((((V3HISP_PRM_TAR - V3HISP_VAL_DES + V3HISP_VLADIFRA) * AREA_DE_WORK.WS_PCPARTIC / 100f) * AREA_DE_WORK.WS_PCCOMCOS / 100f) * V1PLCO_PCCOMSEG / 100f);

            /*" -1546- COMPUTE V0CPRE-VLCOMISIX ROUNDED = ((((V3PARC-PRM-TAR - V3PARC-VAL-DES + V3PARC-OTNADFRA) * WS-PCPARTIC / 100) * WS-PCCOMCOS / 100) * V1PLCO-PCCOMSEG / 100). */
            V0CPRE_VLCOMISIX.Value = ((((V3PARC_PRM_TAR - V3PARC_VAL_DES + V3PARC_OTNADFRA) * AREA_DE_WORK.WS_PCPARTIC / 100f) * AREA_DE_WORK.WS_PCCOMCOS / 100f) * V1PLCO_PCCOMSEG / 100f);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2350-00-SELECT-V1PLANCOMIS-SECTION */
        private void R2350_00_SELECT_V1PLANCOMIS_SECTION()
        {
            /*" -1559- MOVE '235' TO WNR-EXEC-SQL. */
            _.Move("235", WABEND.WNR_EXEC_SQL);

            /*" -1565- PERFORM R2350_00_SELECT_V1PLANCOMIS_DB_SELECT_1 */

            R2350_00_SELECT_V1PLANCOMIS_DB_SELECT_1();

            /*" -1568- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1569- DISPLAY 'R2350 - ERRO NO SELECT DA V1PLANCOMIS' */
                _.Display($"R2350 - ERRO NO SELECT DA V1PLANCOMIS");

                /*" -1570- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -1571- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -1572- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                /*" -1573- DISPLAY 'CD FRAC - ' V0ENDO-CDFRACIO */
                _.Display($"CD FRAC - {V0ENDO_CDFRACIO}");

                /*" -1573- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2350-00-SELECT-V1PLANCOMIS-DB-SELECT-1 */
        public void R2350_00_SELECT_V1PLANCOMIS_DB_SELECT_1()
        {
            /*" -1565- EXEC SQL SELECT PCCOMSEG INTO :V1PLCO-PCCOMSEG FROM SEGUROS.V1PLANCOMIS WHERE CDFRACIO = :V0ENDO-CDFRACIO AND NRPARCEL = :V1HISP-NRPARCEL END-EXEC. */

            var r2350_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1 = new R2350_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1()
            {
                V0ENDO_CDFRACIO = V0ENDO_CDFRACIO.ToString(),
                V1HISP_NRPARCEL = V1HISP_NRPARCEL.ToString(),
            };

            var executed_1 = R2350_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1.Execute(r2350_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PLCO_PCCOMSEG, V1PLCO_PCCOMSEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-SUM-V1PARCELA-SECTION */
        private void R2400_00_SUM_V1PARCELA_SECTION()
        {
            /*" -1586- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", WABEND.WNR_EXEC_SQL);

            /*" -1596- PERFORM R2400_00_SUM_V1PARCELA_DB_SELECT_1 */

            R2400_00_SUM_V1PARCELA_DB_SELECT_1();

            /*" -1599- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1600- DISPLAY 'R2400 - ERRO NO SELECT DA V1PARCELA' */
                _.Display($"R2400 - ERRO NO SELECT DA V1PARCELA");

                /*" -1601- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -1602- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -1603- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                /*" -1603- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2400-00-SUM-V1PARCELA-DB-SELECT-1 */
        public void R2400_00_SUM_V1PARCELA_DB_SELECT_1()
        {
            /*" -1596- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO_IX),+0) , VALUE(SUM(VAL_DESCONTO_IX),+0) , VALUE(SUM(OTNADFRA),+0) INTO :V3PARC-PRM-TAR , :V3PARC-VAL-DES , :V3PARC-OTNADFRA FROM SEGUROS.V1PARCELA WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS END-EXEC. */

            var r2400_00_SUM_V1PARCELA_DB_SELECT_1_Query1 = new R2400_00_SUM_V1PARCELA_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R2400_00_SUM_V1PARCELA_DB_SELECT_1_Query1.Execute(r2400_00_SUM_V1PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V3PARC_PRM_TAR, V3PARC_PRM_TAR);
                _.Move(executed_1.V3PARC_VAL_DES, V3PARC_VAL_DES);
                _.Move(executed_1.V3PARC_OTNADFRA, V3PARC_OTNADFRA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2450-00-PROCESSA-V1PARC-COMPL-SECTION */
        private void R2450_00_PROCESSA_V1PARC_COMPL_SECTION()
        {
            /*" -1616- MOVE '245' TO WNR-EXEC-SQL. */
            _.Move("245", WABEND.WNR_EXEC_SQL);

            /*" -1619- MOVE ZEROS TO WS-VLR-COMPL WS-VLR-COMPL-IX. */
            _.Move(0, AREA_DE_WORK.WS_VLR_COMPL, AREA_DE_WORK.WS_VLR_COMPL_IX);

            /*" -1620- IF V0APOL-RAMO = 16 OR 18 */

            if (V0APOL_RAMO.In("16", "18"))
            {

                /*" -1621- MOVE V3PCOM-VLR-COMPL TO WS-VLR-COMPL */
                _.Move(V3PCOM_VLR_COMPL, AREA_DE_WORK.WS_VLR_COMPL);

                /*" -1623- MOVE V3PCOM-VLR-COMPL-IX TO WS-VLR-COMPL-IX. */
                _.Move(V3PCOM_VLR_COMPL_IX, AREA_DE_WORK.WS_VLR_COMPL_IX);
            }


            /*" -1628- COMPUTE WPROP-VAL-DES ROUNDED = V3HISP-VAL-DES / (V3HISP-PRM-TAR - WS-VLR-COMPL) ON SIZE ERROR MOVE ZEROS TO WPROP-VAL-DES END-COMPUTE. */
            if (V3HISP_PRM_TAR.Value - AREA_DE_WORK.WS_VLR_COMPL.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROP_VAL_DES);
            else

                AREA_DE_WORK.WPROP_VAL_DES.Value = V3HISP_VAL_DES / (V3HISP_PRM_TAR - AREA_DE_WORK.WS_VLR_COMPL);

            /*" -1633- COMPUTE WPROP-VLADIFRA ROUNDED = V3HISP-VLADIFRA / (V3HISP-PRM-TAR - V3HISP-VAL-DES) ON SIZE ERROR MOVE ZEROS TO WPROP-VLADIFRA END-COMPUTE. */
            if (V3HISP_PRM_TAR.Value - V3HISP_VAL_DES.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROP_VLADIFRA);
            else

                AREA_DE_WORK.WPROP_VLADIFRA.Value = V3HISP_VLADIFRA / (V3HISP_PRM_TAR - V3HISP_VAL_DES);

            /*" -1636- COMPUTE V3HISP-PRM-TAR = V3HISP-PRM-TAR - V3PCOM-VLR-COMPL. */
            V3HISP_PRM_TAR.Value = V3HISP_PRM_TAR - V3PCOM_VLR_COMPL;

            /*" -1639- COMPUTE V3HISP-VAL-DES ROUNDED = V3HISP-PRM-TAR * WPROP-VAL-DES. */
            V3HISP_VAL_DES.Value = V3HISP_PRM_TAR * AREA_DE_WORK.WPROP_VAL_DES;

            /*" -1645- COMPUTE V3HISP-VLADIFRA ROUNDED = (V3HISP-PRM-TAR - V3HISP-VAL-DES) * WPROP-VLADIFRA. */
            V3HISP_VLADIFRA.Value = (V3HISP_PRM_TAR - V3HISP_VAL_DES) * AREA_DE_WORK.WPROP_VLADIFRA;

            /*" -1650- COMPUTE WPROP-VAL-DES ROUNDED = V3PARC-VAL-DES / (V3PARC-PRM-TAR - WS-VLR-COMPL-IX) ON SIZE ERROR MOVE ZEROS TO WPROP-VAL-DES END-COMPUTE. */
            if (V3PARC_PRM_TAR.Value - AREA_DE_WORK.WS_VLR_COMPL_IX.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROP_VAL_DES);
            else

                AREA_DE_WORK.WPROP_VAL_DES.Value = V3PARC_VAL_DES / (V3PARC_PRM_TAR - AREA_DE_WORK.WS_VLR_COMPL_IX);

            /*" -1655- COMPUTE WPROP-VLADIFRA ROUNDED = V3PARC-OTNADFRA / (V3PARC-PRM-TAR - V3PARC-VAL-DES) ON SIZE ERROR MOVE ZEROS TO WPROP-VLADIFRA END-COMPUTE. */
            if (V3PARC_PRM_TAR.Value - V3PARC_VAL_DES.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROP_VLADIFRA);
            else

                AREA_DE_WORK.WPROP_VLADIFRA.Value = V3PARC_OTNADFRA / (V3PARC_PRM_TAR - V3PARC_VAL_DES);

            /*" -1658- COMPUTE V3PARC-PRM-TAR = V3PARC-PRM-TAR - V3PCOM-VLR-COMPL-IX. */
            V3PARC_PRM_TAR.Value = V3PARC_PRM_TAR - V3PCOM_VLR_COMPL_IX;

            /*" -1661- COMPUTE V3PARC-VAL-DES ROUNDED = V3PARC-PRM-TAR * WPROP-VAL-DES. */
            V3PARC_VAL_DES.Value = V3PARC_PRM_TAR * AREA_DE_WORK.WPROP_VAL_DES;

            /*" -1663- COMPUTE V3PARC-OTNADFRA ROUNDED = (V3PARC-PRM-TAR - V3PARC-VAL-DES) * WPROP-VLADIFRA. */
            V3PARC_OTNADFRA.Value = (V3PARC_PRM_TAR - V3PARC_VAL_DES) * AREA_DE_WORK.WPROP_VLADIFRA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-MONTA-COSSEG-PREM-SECTION */
        private void R2500_00_MONTA_COSSEG_PREM_SECTION()
        {
            /*" -1676- MOVE '250' TO WNR-EXEC-SQL. */
            _.Move("250", WABEND.WNR_EXEC_SQL);

            /*" -1677- MOVE ZEROS TO V0CPRE-COD-EMPR. */
            _.Move(0, V0CPRE_COD_EMPR);

            /*" -1678- MOVE '1' TO V0CPRE-TIPSGU. */
            _.Move("1", V0CPRE_TIPSGU);

            /*" -1679- MOVE V1APCD-CODCOSS TO V0CPRE-CONGENER. */
            _.Move(V1APCD_CODCOSS, V0CPRE_CONGENER);

            /*" -1680- MOVE V1ORDC-ORD-CEDIDO TO V0CPRE-NUM-ORDEM. */
            _.Move(V1ORDC_ORD_CEDIDO, V0CPRE_NUM_ORDEM);

            /*" -1681- MOVE V1HISP-NUM-APOL TO V0CPRE-NUM-APOL. */
            _.Move(V1HISP_NUM_APOL, V0CPRE_NUM_APOL);

            /*" -1682- MOVE V1HISP-NRENDOS TO V0CPRE-NRENDOS. */
            _.Move(V1HISP_NRENDOS, V0CPRE_NRENDOS);

            /*" -1683- MOVE V1HISP-NRPARCEL TO V0CPRE-NRPARCEL. */
            _.Move(V1HISP_NRPARCEL, V0CPRE_NRPARCEL);

            /*" -1684- MOVE '0' TO V0CPRE-SITUACAO. */
            _.Move("0", V0CPRE_SITUACAO);

            /*" -1685- MOVE '0' TO V0CPRE-SIT-CONG. */
            _.Move("0", V0CPRE_SIT_CONG);

            /*" -1687- MOVE 01 TO V0CPRE-OCORHIST. */
            _.Move(01, V0CPRE_OCORHIST);

            /*" -1689- MOVE +1 TO VIND-OCR-HIST. */
            _.Move(+1, VIND_OCR_HIST);

            /*" -1689- MOVE ZEROS TO WHOST-OCORHIST. */
            _.Move(0, WHOST_OCORHIST);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-INSERT-COSSEG-PREM-SECTION */
        private void R2600_00_INSERT_COSSEG_PREM_SECTION()
        {
            /*" -1702- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", WABEND.WNR_EXEC_SQL);

            /*" -1721- PERFORM R2600_00_INSERT_COSSEG_PREM_DB_INSERT_1 */

            R2600_00_INSERT_COSSEG_PREM_DB_INSERT_1();

            /*" -1724- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1731- DISPLAY V1APCD-CODCOSS ' ' V1ORDC-ORD-CEDIDO ' ' V1HISP-NUM-APOL ' ' V1HISP-NRENDOS ' ' V1HISP-NRPARCEL ' ' V1HISP-OCORHIST ' ' V1HISP-OPERACAO */

                $"{V1APCD_CODCOSS} {V1ORDC_ORD_CEDIDO} {V1HISP_NUM_APOL} {V1HISP_NRENDOS} {V1HISP_NRPARCEL} {V1HISP_OCORHIST} {V1HISP_OPERACAO}"
                .Display();

                /*" -1732- DISPLAY '... R2600-00 - PROBLEMAS NA INSERCAO' */
                _.Display($"... R2600-00 - PROBLEMAS NA INSERCAO");

                /*" -1734- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1734- ADD 1 TO AC-I-V0COSSEGPREM. */
            AREA_DE_WORK.AC_I_V0COSSEGPREM.Value = AREA_DE_WORK.AC_I_V0COSSEGPREM + 1;

        }

        [StopWatch]
        /*" R2600-00-INSERT-COSSEG-PREM-DB-INSERT-1 */
        public void R2600_00_INSERT_COSSEG_PREM_DB_INSERT_1()
        {
            /*" -1721- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_PREM VALUES (:V0CPRE-COD-EMPR , :V0CPRE-TIPSGU , :V0CPRE-CONGENER , :V0CPRE-NUM-ORDEM , :V0CPRE-NUM-APOL , :V0CPRE-NRENDOS , :V0CPRE-NRPARCEL , :V0CPRE-PRM-TAR-IX , :V0CPRE-VAL-DES-IX , :V0CPRE-OTNPRLIQ , :V0CPRE-OTNADFRA , :V0CPRE-VLCOMISIX , :V0CPRE-OTNTOTAL , :V0CPRE-SITUACAO , :V0CPRE-SIT-CONG , CURRENT TIMESTAMP , :V0CPRE-OCORHIST:VIND-OCR-HIST) END-EXEC. */

            var r2600_00_INSERT_COSSEG_PREM_DB_INSERT_1_Insert1 = new R2600_00_INSERT_COSSEG_PREM_DB_INSERT_1_Insert1()
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

            R2600_00_INSERT_COSSEG_PREM_DB_INSERT_1_Insert1.Execute(r2600_00_INSERT_COSSEG_PREM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-MONTA-COSSEG-HIST-SECTION */
        private void R2700_00_MONTA_COSSEG_HIST_SECTION()
        {
            /*" -1747- MOVE '270' TO WNR-EXEC-SQL. */
            _.Move("270", WABEND.WNR_EXEC_SQL);

            /*" -1748- MOVE ZEROS TO V0CHIS-COD-EMPR. */
            _.Move(0, V0CHIS_COD_EMPR);

            /*" -1749- MOVE V1APCD-CODCOSS TO V0CHIS-CONGENER. */
            _.Move(V1APCD_CODCOSS, V0CHIS_CONGENER);

            /*" -1750- MOVE V1HISP-NUM-APOL TO V0CHIS-NUM-APOL. */
            _.Move(V1HISP_NUM_APOL, V0CHIS_NUM_APOL);

            /*" -1751- MOVE V1HISP-NRENDOS TO V0CHIS-NRENDOS. */
            _.Move(V1HISP_NRENDOS, V0CHIS_NRENDOS);

            /*" -1753- MOVE V1HISP-NRPARCEL TO V0CHIS-NRPARCEL. */
            _.Move(V1HISP_NRPARCEL, V0CHIS_NRPARCEL);

            /*" -1756- COMPUTE WHOST-OCORHIST = WHOST-OCORHIST + 1. */
            WHOST_OCORHIST.Value = WHOST_OCORHIST + 1;

            /*" -1757- MOVE WHOST-OCORHIST TO V0CHIS-OCORHIST. */
            _.Move(WHOST_OCORHIST, V0CHIS_OCORHIST);

            /*" -1758- MOVE V1HISP-OPERACAO TO V0CHIS-OPERACAO. */
            _.Move(V1HISP_OPERACAO, V0CHIS_OPERACAO);

            /*" -1759- MOVE V1HISP-DTMOVTO TO V0CHIS-DTMOVTO. */
            _.Move(V1HISP_DTMOVTO, V0CHIS_DTMOVTO);

            /*" -1760- MOVE '1' TO V0CHIS-TIPSGU. */
            _.Move("1", V0CHIS_TIPSGU);

            /*" -1762- MOVE V1HISP-DTQITBCO TO V0CHIS-DTQITBCO. */
            _.Move(V1HISP_DTQITBCO, V0CHIS_DTQITBCO);

            /*" -1763- IF V1HISP-DTQITBCO = SPACES */

            if (V1HISP_DTQITBCO.IsEmpty())
            {

                /*" -1764- MOVE -1 TO VIND-DAT-QTBC */
                _.Move(-1, VIND_DAT_QTBC);

                /*" -1765- ELSE */
            }
            else
            {


                /*" -1766- MOVE +1 TO VIND-DAT-QTBC */
                _.Move(+1, VIND_DAT_QTBC);

                /*" -1768- END-IF. */
            }


            /*" -1771- MOVE '0' TO V0CHIS-SIT-FINANC V0CHIS-SIT-LIBREC. */
            _.Move("0", V0CHIS_SIT_FINANC, V0CHIS_SIT_LIBREC);

            /*" -1774- MOVE +1 TO VIND-SIT-FINC VIND-SIT-LIBR. */
            _.Move(+1, VIND_SIT_FINC, VIND_SIT_LIBR);

            /*" -1776- MOVE WHOST-OCORHIST TO V0CHIS-NUM-OCOR. */
            _.Move(WHOST_OCORHIST, V0CHIS_NUM_OCOR);

            /*" -1776- MOVE +1 TO VIND-NUM-OCOR. */
            _.Move(+1, VIND_NUM_OCOR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-INSERT-COSSEG-HIST-SECTION */
        private void R2900_00_INSERT_COSSEG_HIST_SECTION()
        {
            /*" -1789- MOVE '290' TO WNR-EXEC-SQL. */
            _.Move("290", WABEND.WNR_EXEC_SQL);

            /*" -1811- PERFORM R2900_00_INSERT_COSSEG_HIST_DB_INSERT_1 */

            R2900_00_INSERT_COSSEG_HIST_DB_INSERT_1();

            /*" -1814- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1820- DISPLAY V1APCD-CODCOSS ' ' V1HISP-NUM-APOL ' ' V1HISP-NRENDOS ' ' V1HISP-NRPARCEL ' ' V1HISP-OCORHIST ' ' V1HISP-OPERACAO */

                $"{V1APCD_CODCOSS} {V1HISP_NUM_APOL} {V1HISP_NRENDOS} {V1HISP_NRPARCEL} {V1HISP_OCORHIST} {V1HISP_OPERACAO}"
                .Display();

                /*" -1821- DISPLAY '... R2900-00 - PROBLEMAS NA INSERCAO' */
                _.Display($"... R2900-00 - PROBLEMAS NA INSERCAO");

                /*" -1823- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1823- ADD 1 TO AC-I-V0COSSEGHISP. */
            AREA_DE_WORK.AC_I_V0COSSEGHISP.Value = AREA_DE_WORK.AC_I_V0COSSEGHISP + 1;

        }

        [StopWatch]
        /*" R2900-00-INSERT-COSSEG-HIST-DB-INSERT-1 */
        public void R2900_00_INSERT_COSSEG_HIST_DB_INSERT_1()
        {
            /*" -1811- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_HISTPRE VALUES (:V0CHIS-COD-EMPR , :V0CHIS-CONGENER , :V0CHIS-NUM-APOL , :V0CHIS-NRENDOS , :V0CHIS-NRPARCEL , :V0CHIS-OCORHIST , :V0CHIS-OPERACAO , :V0CHIS-DTMOVTO , :V0CHIS-TIPSGU , :V0CHIS-PRM-TAR , :V0CHIS-VAL-DES , :V0CHIS-VLPRMLIQ , :V0CHIS-VLADIFRA , :V0CHIS-VLCOMIS , :V0CHIS-VLPRMTOT , CURRENT TIMESTAMP , :V0CHIS-DTQITBCO:VIND-DAT-QTBC, :V0CHIS-SIT-FINANC:VIND-SIT-FINC, :V0CHIS-SIT-LIBREC:VIND-SIT-LIBR, :V0CHIS-NUM-OCOR:VIND-NUM-OCOR) END-EXEC. */

            var r2900_00_INSERT_COSSEG_HIST_DB_INSERT_1_Insert1 = new R2900_00_INSERT_COSSEG_HIST_DB_INSERT_1_Insert1()
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
                V0CHIS_SIT_LIBREC = V0CHIS_SIT_LIBREC.ToString(),
                VIND_SIT_LIBR = VIND_SIT_LIBR.ToString(),
                V0CHIS_NUM_OCOR = V0CHIS_NUM_OCOR.ToString(),
                VIND_NUM_OCOR = VIND_NUM_OCOR.ToString(),
            };

            R2900_00_INSERT_COSSEG_HIST_DB_INSERT_1_Insert1.Execute(r2900_00_INSERT_COSSEG_HIST_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-OPER-DIF-EMISSAO-SECTION */
        private void R3000_00_OPER_DIF_EMISSAO_SECTION()
        {
            /*" -1836- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", WABEND.WNR_EXEC_SQL);

            /*" -1837- MOVE WCODCOSS (WIND) TO V1APCD-CODCOSS. */
            _.Move(TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WCODCOSS, V1APCD_CODCOSS);

            /*" -1838- MOVE WPCPARTIC (WIND) TO WS-PCPARTIC. */
            _.Move(TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WPCPARTIC, AREA_DE_WORK.WS_PCPARTIC);

            /*" -1839- MOVE WPCCOMCOS (WIND) TO WS-PCCOMCOS. */
            _.Move(TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WPCCOMCOS, AREA_DE_WORK.WS_PCCOMCOS);

            /*" -1841- MOVE WORD-CEDIDO (WIND) TO V1ORDC-ORD-CEDIDO. */
            _.Move(TABELA_COSCED.TAB_COSSEGCED[AREA_DE_WORK.WIND].WORD_CEDIDO, V1ORDC_ORD_CEDIDO);

            /*" -1844- IF V1APCD-CODCOSS = 5240 AND V1HISP-NRENDOS = ZEROS AND V1HISP-OPERACAO < 0200 */

            if (V1APCD_CODCOSS == 5240 && V1HISP_NRENDOS == 00 && V1HISP_OPERACAO < 0200)
            {

                /*" -1845- DISPLAY '*** EMISSAO PARA A CONGENERE 5240 ***' */
                _.Display($"*** EMISSAO PARA A CONGENERE 5240 ***");

                /*" -1846- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -1847- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1848- ELSE */
            }
            else
            {


                /*" -1849- IF WIND > 01 */

                if (AREA_DE_WORK.WIND > 01)
                {

                    /*" -1850- GO TO R3000-10-OPER-DIF-EMIS */

                    R3000_10_OPER_DIF_EMIS(); //GOTO
                    return;

                    /*" -1851- END-IF */
                }


                /*" -1853- END-IF. */
            }


            /*" -1856- MOVE ZEROS TO WS-VLR-COMPL WS-VLR-COMPL-IX. */
            _.Move(0, AREA_DE_WORK.WS_VLR_COMPL, AREA_DE_WORK.WS_VLR_COMPL_IX);

            /*" -1859- MOVE SPACES TO WTEM-PARC-COMPL WTEM-COMIS-ACELER. */
            _.Move("", AREA_DE_WORK.WTEM_PARC_COMPL, AREA_DE_WORK.WTEM_COMIS_ACELER);

            /*" -1861- PERFORM R3100-00-EMISSAO-HISTOPARC. */

            R3100_00_EMISSAO_HISTOPARC_SECTION();

            /*" -1862- IF V0APOL-RAMO = 16 OR 18 OR 31 OR 66 OR 68 */

            if (V0APOL_RAMO.In("16", "18", "31", "66", "68"))
            {

                /*" -1863- PERFORM R2100-00-SELECT-V1PARC-COMPL */

                R2100_00_SELECT_V1PARC_COMPL_SECTION();

                /*" -1865- IF V1PCOM-VLR-COMPL = ZEROS NEXT SENTENCE */

                if (V1PCOM_VLR_COMPL == 00)
                {

                    /*" -1866- ELSE */
                }
                else
                {


                    /*" -1867- MOVE 'S' TO WTEM-PARC-COMPL */
                    _.Move("S", AREA_DE_WORK.WTEM_PARC_COMPL);

                    /*" -1868- IF V0APOL-RAMO = 16 OR 18 */

                    if (V0APOL_RAMO.In("16", "18"))
                    {

                        /*" -1869- MOVE V1PCOM-VLR-COMPL TO WS-VLR-COMPL */
                        _.Move(V1PCOM_VLR_COMPL, AREA_DE_WORK.WS_VLR_COMPL);

                        /*" -1871- MOVE V1PCOM-VLR-COMPL-IX TO WS-VLR-COMPL-IX. */
                        _.Move(V1PCOM_VLR_COMPL_IX, AREA_DE_WORK.WS_VLR_COMPL_IX);
                    }

                }

            }


            /*" -1874- IF V0ENDO-CDFRACIO GREATER 0 AND V0ENDO-QTPARCEL GREATER 1 AND V3HISP-DTMOVTO NOT LESS WDAT-LIMT-COMS */

            if (V0ENDO_CDFRACIO > 0 && V0ENDO_QTPARCEL > 1 && V3HISP_DTMOVTO >= AREA_DE_WORK.WDAT_LIMT_COMS)
            {

                /*" -1874- MOVE 'S' TO WTEM-COMIS-ACELER. */
                _.Move("S", AREA_DE_WORK.WTEM_COMIS_ACELER);
            }


            /*" -0- FLUXCONTROL_PERFORM R3000_10_OPER_DIF_EMIS */

            R3000_10_OPER_DIF_EMIS();

        }

        [StopWatch]
        /*" R3000-10-OPER-DIF-EMIS */
        private void R3000_10_OPER_DIF_EMIS(bool isPerform = false)
        {
            /*" -1881- PERFORM R3200-00-OCORHIST-COSSEG-PREM. */

            R3200_00_OCORHIST_COSSEG_PREM_SECTION();

            /*" -1883- PERFORM R3300-00-EMISSAO-COSSEG-HIST. */

            R3300_00_EMISSAO_COSSEG_HIST_SECTION();

            /*" -1885- PERFORM R3400-00-PROCESSA-CALCULOS. */

            R3400_00_PROCESSA_CALCULOS_SECTION();

            /*" -1887- PERFORM R2700-00-MONTA-COSSEG-HIST. */

            R2700_00_MONTA_COSSEG_HIST_SECTION();

            /*" -1889- PERFORM R2900-00-INSERT-COSSEG-HIST. */

            R2900_00_INSERT_COSSEG_HIST_SECTION();

            /*" -1891- PERFORM R3500-00-VERIFICA-SITUACAO. */

            R3500_00_VERIFICA_SITUACAO_SECTION();

            /*" -1893- PERFORM R3600-00-UPDATE-COSSEG-PREM. */

            R3600_00_UPDATE_COSSEG_PREM_SECTION();

            /*" -1893- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-EMISSAO-HISTOPARC-SECTION */
        private void R3100_00_EMISSAO_HISTOPARC_SECTION()
        {
            /*" -1906- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", WABEND.WNR_EXEC_SQL);

            /*" -1921- PERFORM R3100_00_EMISSAO_HISTOPARC_DB_SELECT_1 */

            R3100_00_EMISSAO_HISTOPARC_DB_SELECT_1();

            /*" -1924- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1925- DISPLAY 'R3100 - ERRO NO SELECT DA V1HISTOPARC' */
                _.Display($"R3100 - ERRO NO SELECT DA V1HISTOPARC");

                /*" -1926- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                /*" -1927- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                /*" -1928- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                /*" -1928- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3100-00-EMISSAO-HISTOPARC-DB-SELECT-1 */
        public void R3100_00_EMISSAO_HISTOPARC_DB_SELECT_1()
        {
            /*" -1921- EXEC SQL SELECT DTMOVTO, PRM_TARIFARIO, VAL_DESCONTO, VLADIFRA INTO :V3HISP-DTMOVTO, :V3HISP-PRM-TAR, :V3HISP-VAL-DES, :V3HISP-VLADIFRA FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS AND NRPARCEL = :V1HISP-NRPARCEL AND OCORHIST = 01 AND OPERACAO < 0200 END-EXEC. */

            var r3100_00_EMISSAO_HISTOPARC_DB_SELECT_1_Query1 = new R3100_00_EMISSAO_HISTOPARC_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRPARCEL = V1HISP_NRPARCEL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R3100_00_EMISSAO_HISTOPARC_DB_SELECT_1_Query1.Execute(r3100_00_EMISSAO_HISTOPARC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V3HISP_DTMOVTO, V3HISP_DTMOVTO);
                _.Move(executed_1.V3HISP_PRM_TAR, V3HISP_PRM_TAR);
                _.Move(executed_1.V3HISP_VAL_DES, V3HISP_VAL_DES);
                _.Move(executed_1.V3HISP_VLADIFRA, V3HISP_VLADIFRA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-OCORHIST-COSSEG-PREM-SECTION */
        private void R3200_00_OCORHIST_COSSEG_PREM_SECTION()
        {
            /*" -1941- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", WABEND.WNR_EXEC_SQL);

            /*" -1950- PERFORM R3200_00_OCORHIST_COSSEG_PREM_DB_SELECT_1 */

            R3200_00_OCORHIST_COSSEG_PREM_DB_SELECT_1();

            /*" -1965- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1966- DISPLAY 'R3200 - ERRO NO SELECT DA V1COSSEG-PREM' */
                _.Display($"R3200 - ERRO NO SELECT DA V1COSSEG-PREM");

                /*" -1967- DISPLAY 'COD COSS - ' V1APCD-CODCOSS */
                _.Display($"COD COSS - {V1APCD_CODCOSS}");

                /*" -1968- DISPLAY 'APOLICE  - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE  - {V1HISP_NUM_APOL}");

                /*" -1969- DISPLAY 'ENDOSSO  - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO  - {V1HISP_NRENDOS}");

                /*" -1970- DISPLAY 'PARCELA  - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA  - {V1HISP_NRPARCEL}");

                /*" -1970- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3200-00-OCORHIST-COSSEG-PREM-DB-SELECT-1 */
        public void R3200_00_OCORHIST_COSSEG_PREM_DB_SELECT_1()
        {
            /*" -1950- EXEC SQL SELECT OCORHIST INTO :WHOST-OCORHIST FROM SEGUROS.V1COSSEG_PREM WHERE CONGENER = :V1APCD-CODCOSS AND NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS AND NRPARCEL = :V1HISP-NRPARCEL AND TIPSGU = '1' END-EXEC. */

            var r3200_00_OCORHIST_COSSEG_PREM_DB_SELECT_1_Query1 = new R3200_00_OCORHIST_COSSEG_PREM_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRPARCEL = V1HISP_NRPARCEL.ToString(),
                V1APCD_CODCOSS = V1APCD_CODCOSS.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R3200_00_OCORHIST_COSSEG_PREM_DB_SELECT_1_Query1.Execute(r3200_00_OCORHIST_COSSEG_PREM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_OCORHIST, WHOST_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-EMISSAO-COSSEG-HIST-SECTION */
        private void R3300_00_EMISSAO_COSSEG_HIST_SECTION()
        {
            /*" -1983- MOVE '330' TO WNR-EXEC-SQL. */
            _.Move("330", WABEND.WNR_EXEC_SQL);

            /*" -2000- PERFORM R3300_00_EMISSAO_COSSEG_HIST_DB_SELECT_1 */

            R3300_00_EMISSAO_COSSEG_HIST_DB_SELECT_1();

            /*" -2003- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2004- DISPLAY 'R3300 - ERRO NO SELECT DA V1COSSEG-HISTPRE' */
                _.Display($"R3300 - ERRO NO SELECT DA V1COSSEG-HISTPRE");

                /*" -2005- DISPLAY 'COD COSS - ' V1APCD-CODCOSS */
                _.Display($"COD COSS - {V1APCD_CODCOSS}");

                /*" -2006- DISPLAY 'APOLICE  - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE  - {V1HISP_NUM_APOL}");

                /*" -2007- DISPLAY 'ENDOSSO  - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO  - {V1HISP_NRENDOS}");

                /*" -2008- DISPLAY 'PARCELA  - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA  - {V1HISP_NRPARCEL}");

                /*" -2008- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3300-00-EMISSAO-COSSEG-HIST-DB-SELECT-1 */
        public void R3300_00_EMISSAO_COSSEG_HIST_DB_SELECT_1()
        {
            /*" -2000- EXEC SQL SELECT PRM_TARIFARIO, VAL_DESCONTO, VLADIFRA, VLCOMIS INTO :V3CHIS-PRM-TAR, :V3CHIS-VAL-DES, :V3CHIS-VLADIFRA, :V3CHIS-VLCOMIS FROM SEGUROS.V1COSSEG_HISTPRE WHERE CONGENER = :V1APCD-CODCOSS AND NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS AND NRPARCEL = :V1HISP-NRPARCEL AND OCORHIST = 01 AND OPERACAO < 0200 AND TIPSGU = '1' END-EXEC. */

            var r3300_00_EMISSAO_COSSEG_HIST_DB_SELECT_1_Query1 = new R3300_00_EMISSAO_COSSEG_HIST_DB_SELECT_1_Query1()
            {
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRPARCEL = V1HISP_NRPARCEL.ToString(),
                V1APCD_CODCOSS = V1APCD_CODCOSS.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R3300_00_EMISSAO_COSSEG_HIST_DB_SELECT_1_Query1.Execute(r3300_00_EMISSAO_COSSEG_HIST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
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
            /*" -2021- MOVE '340' TO WNR-EXEC-SQL. */
            _.Move("340", WABEND.WNR_EXEC_SQL);

            /*" -2026- COMPUTE WPROPORCAO ROUNDED = V1HISP-PRM-TAR / V3HISP-PRM-TAR ON SIZE ERROR MOVE ZEROS TO WPROPORCAO END-COMPUTE. */
            if (V3HISP_PRM_TAR.Value == 0)
                _.Move(0, AREA_DE_WORK.WPROPORCAO);
            else

                AREA_DE_WORK.WPROPORCAO.Value = V1HISP_PRM_TAR / V3HISP_PRM_TAR;

            /*" -2029- COMPUTE V0CHIS-PRM-TAR ROUNDED = V3CHIS-PRM-TAR * WPROPORCAO. */
            V0CHIS_PRM_TAR.Value = V3CHIS_PRM_TAR * AREA_DE_WORK.WPROPORCAO;

            /*" -2032- COMPUTE V0CHIS-VAL-DES ROUNDED = V3CHIS-VAL-DES * WPROPORCAO. */
            V0CHIS_VAL_DES.Value = V3CHIS_VAL_DES * AREA_DE_WORK.WPROPORCAO;

            /*" -2035- COMPUTE V0CHIS-VLPRMLIQ = V0CHIS-PRM-TAR - V0CHIS-VAL-DES. */
            V0CHIS_VLPRMLIQ.Value = V0CHIS_PRM_TAR - V0CHIS_VAL_DES;

            /*" -2038- COMPUTE V0CHIS-VLADIFRA ROUNDED = V3CHIS-VLADIFRA * WPROPORCAO. */
            V0CHIS_VLADIFRA.Value = V3CHIS_VLADIFRA * AREA_DE_WORK.WPROPORCAO;

            /*" -2041- COMPUTE V0CHIS-VLCOMIS ROUNDED = V3CHIS-VLCOMIS * WPROPORCAO. */
            V0CHIS_VLCOMIS.Value = V3CHIS_VLCOMIS * AREA_DE_WORK.WPROPORCAO;

            /*" -2043- COMPUTE V0CHIS-VLPRMTOT = V0CHIS-VLPRMLIQ + V0CHIS-VLADIFRA - V0CHIS-VLCOMIS. */
            V0CHIS_VLPRMTOT.Value = V0CHIS_VLPRMLIQ + V0CHIS_VLADIFRA - V0CHIS_VLCOMIS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-VERIFICA-SITUACAO-SECTION */
        private void R3500_00_VERIFICA_SITUACAO_SECTION()
        {
            /*" -2056- MOVE '350' TO WNR-EXEC-SQL. */
            _.Move("350", WABEND.WNR_EXEC_SQL);

            /*" -2057- IF WTIPO-OPERACAO EQUAL 02 */

            if (AREA_DE_WORK.FILLER_0.WTIPO_OPERACAO == 02)
            {

                /*" -2058- MOVE '1' TO WHOST-SITUACAO */
                _.Move("1", WHOST_SITUACAO);

                /*" -2059- ELSE */
            }
            else
            {


                /*" -2060- IF WTIPO-OPERACAO EQUAL 03 OR 05 OR 08 */

                if (AREA_DE_WORK.FILLER_0.WTIPO_OPERACAO.In("03", "05", "08"))
                {

                    /*" -2061- MOVE '0' TO WHOST-SITUACAO */
                    _.Move("0", WHOST_SITUACAO);

                    /*" -2062- ELSE */
                }
                else
                {


                    /*" -2063- IF WTIPO-OPERACAO EQUAL 04 */

                    if (AREA_DE_WORK.FILLER_0.WTIPO_OPERACAO == 04)
                    {

                        /*" -2064- MOVE '2' TO WHOST-SITUACAO */
                        _.Move("2", WHOST_SITUACAO);

                        /*" -2065- ELSE */
                    }
                    else
                    {


                        /*" -2066- DISPLAY 'FAIXA DE OPERACAO NAO PREVISTA P/ SITUACAO' */
                        _.Display($"FAIXA DE OPERACAO NAO PREVISTA P/ SITUACAO");

                        /*" -2067- DISPLAY 'APOLICE  - ' V1HISP-NUM-APOL */
                        _.Display($"APOLICE  - {V1HISP_NUM_APOL}");

                        /*" -2068- DISPLAY 'ENDOSSO  - ' V1HISP-NRENDOS */
                        _.Display($"ENDOSSO  - {V1HISP_NRENDOS}");

                        /*" -2069- DISPLAY 'PARCELA  - ' V1HISP-NRPARCEL */
                        _.Display($"PARCELA  - {V1HISP_NRPARCEL}");

                        /*" -2070- DISPLAY 'OC HIST  - ' V1HISP-OCORHIST */
                        _.Display($"OC HIST  - {V1HISP_OCORHIST}");

                        /*" -2071- DISPLAY 'OPERACAO - ' V1HISP-OPERACAO */
                        _.Display($"OPERACAO - {V1HISP_OPERACAO}");

                        /*" -2071- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R3600-00-UPDATE-COSSEG-PREM-SECTION */
        private void R3600_00_UPDATE_COSSEG_PREM_SECTION()
        {
            /*" -2084- MOVE '360' TO WNR-EXEC-SQL. */
            _.Move("360", WABEND.WNR_EXEC_SQL);

            /*" -2094- PERFORM R3600_00_UPDATE_COSSEG_PREM_DB_UPDATE_1 */

            R3600_00_UPDATE_COSSEG_PREM_DB_UPDATE_1();

            /*" -2097- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2098- DISPLAY 'R3600 - ERRO NO UPDATE DA V0COSSEG-PREM' */
                _.Display($"R3600 - ERRO NO UPDATE DA V0COSSEG-PREM");

                /*" -2099- DISPLAY 'COD COSS - ' V1APCD-CODCOSS */
                _.Display($"COD COSS - {V1APCD_CODCOSS}");

                /*" -2100- DISPLAY 'NR ORDEM - ' V1ORDC-ORD-CEDIDO */
                _.Display($"NR ORDEM - {V1ORDC_ORD_CEDIDO}");

                /*" -2101- DISPLAY 'APOLICE  - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE  - {V1HISP_NUM_APOL}");

                /*" -2102- DISPLAY 'ENDOSSO  - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO  - {V1HISP_NRENDOS}");

                /*" -2103- DISPLAY 'PARCELA  - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA  - {V1HISP_NRPARCEL}");

                /*" -2104- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2105- ELSE */
            }
            else
            {


                /*" -2105- ADD 1 TO AC-U-V0COSSEGPREM. */
                AREA_DE_WORK.AC_U_V0COSSEGPREM.Value = AREA_DE_WORK.AC_U_V0COSSEGPREM + 1;
            }


        }

        [StopWatch]
        /*" R3600-00-UPDATE-COSSEG-PREM-DB-UPDATE-1 */
        public void R3600_00_UPDATE_COSSEG_PREM_DB_UPDATE_1()
        {
            /*" -2094- EXEC SQL UPDATE SEGUROS.V0COSSEG_PREM SET SITUACAO = :WHOST-SITUACAO , OCORHIST = :WHOST-OCORHIST , TIMESTAMP = CURRENT TIMESTAMP WHERE CONGENER = :V1APCD-CODCOSS AND NUM_APOLICE = :V1HISP-NUM-APOL AND NRENDOS = :V1HISP-NRENDOS AND NRPARCEL = :V1HISP-NRPARCEL AND TIPSGU = '1' END-EXEC. */

            var r3600_00_UPDATE_COSSEG_PREM_DB_UPDATE_1_Update1 = new R3600_00_UPDATE_COSSEG_PREM_DB_UPDATE_1_Update1()
            {
                WHOST_SITUACAO = WHOST_SITUACAO.ToString(),
                WHOST_OCORHIST = WHOST_OCORHIST.ToString(),
                V1HISP_NUM_APOL = V1HISP_NUM_APOL.ToString(),
                V1HISP_NRPARCEL = V1HISP_NRPARCEL.ToString(),
                V1APCD_CODCOSS = V1APCD_CODCOSS.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            R3600_00_UPDATE_COSSEG_PREM_DB_UPDATE_1_Update1.Execute(r3600_00_UPDATE_COSSEG_PREM_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TRATA-INTEGRIDADE-SECTION */
        private void R4000_00_TRATA_INTEGRIDADE_SECTION()
        {
            /*" -2118- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", WABEND.WNR_EXEC_SQL);

            /*" -2120- PERFORM R4100-00-DECLARE-V2HISTOPARC. */

            R4100_00_DECLARE_V2HISTOPARC_SECTION();

            /*" -2122- PERFORM R4150-00-FETCH-V2HISTOPARC. */

            R4150_00_FETCH_V2HISTOPARC_SECTION();

            /*" -2123- IF WFIM-V2HISTOPARC NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V2HISTOPARC.IsEmpty())
            {

                /*" -2124- DISPLAY '*** BASE DE DADOS INCORRETA ***' */
                _.Display($"*** BASE DE DADOS INCORRETA ***");

                /*" -2125- DISPLAY '*** NAO EXISTE OPERACAO DE EMISSAO ***' */
                _.Display($"*** NAO EXISTE OPERACAO DE EMISSAO ***");

                /*" -2126- DISPLAY 'APOLICE  - ' V1HISP-NUM-APOL */
                _.Display($"APOLICE  - {V1HISP_NUM_APOL}");

                /*" -2127- DISPLAY 'ENDOSSO  - ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO  - {V1HISP_NRENDOS}");

                /*" -2128- DISPLAY 'PARCELA  - ' V1HISP-NRPARCEL */
                _.Display($"PARCELA  - {V1HISP_NRPARCEL}");

                /*" -2129- DISPLAY 'OCR HIST - ' V1HISP-OCORHIST */
                _.Display($"OCR HIST - {V1HISP_OCORHIST}");

                /*" -2130- DISPLAY 'OPERACAO - ' V1HISP-OPERACAO */
                _.Display($"OPERACAO - {V1HISP_OPERACAO}");

                /*" -2131- DISPLAY 'DT MOVTO - ' V1HISP-DTMOVTO */
                _.Display($"DT MOVTO - {V1HISP_DTMOVTO}");

                /*" -2132- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2133- ELSE */
            }
            else
            {


                /*" -2135- MOVE ZEROS TO V2CHIS-OCORHIST. */
                _.Move(0, V2CHIS_OCORHIST);
            }


            /*" -2138- PERFORM R4200-00-PROCESSA-V2HISTOPARC UNTIL WFIM-V2HISTOPARC NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V2HISTOPARC.IsEmpty()))
            {

                R4200_00_PROCESSA_V2HISTOPARC_SECTION();
            }

            /*" -2138- PERFORM R4800-00-ATUALIZA-OCORHIST. */

            R4800_00_ATUALIZA_OCORHIST_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-DECLARE-V2HISTOPARC-SECTION */
        private void R4100_00_DECLARE_V2HISTOPARC_SECTION()
        {
            /*" -2151- MOVE '410' TO WNR-EXEC-SQL. */
            _.Move("410", WABEND.WNR_EXEC_SQL);

            /*" -2172- PERFORM R4100_00_DECLARE_V2HISTOPARC_DB_DECLARE_1 */

            R4100_00_DECLARE_V2HISTOPARC_DB_DECLARE_1();

            /*" -2174- PERFORM R4100_00_DECLARE_V2HISTOPARC_DB_OPEN_1 */

            R4100_00_DECLARE_V2HISTOPARC_DB_OPEN_1();

            /*" -2177- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2178- DISPLAY 'R4100 - ERRO NO DECLARE DA V2HISTOPARC' */
                _.Display($"R4100 - ERRO NO DECLARE DA V2HISTOPARC");

                /*" -2179- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2180- ELSE */
            }
            else
            {


                /*" -2180- MOVE SPACES TO WFIM-V2HISTOPARC. */
                _.Move("", AREA_DE_WORK.WFIM_V2HISTOPARC);
            }


        }

        [StopWatch]
        /*" R4100-00-DECLARE-V2HISTOPARC-DB-OPEN-1 */
        public void R4100_00_DECLARE_V2HISTOPARC_DB_OPEN_1()
        {
            /*" -2174- EXEC SQL OPEN V2HISTOPARC END-EXEC. */

            V2HISTOPARC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4150-00-FETCH-V2HISTOPARC-SECTION */
        private void R4150_00_FETCH_V2HISTOPARC_SECTION()
        {
            /*" -2191- MOVE '415' TO WNR-EXEC-SQL. */
            _.Move("415", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R4150_10_LER_V2HISTOPARC */

            R4150_10_LER_V2HISTOPARC();

        }

        [StopWatch]
        /*" R4150-10-LER-V2HISTOPARC */
        private void R4150_10_LER_V2HISTOPARC(bool isPerform = false)
        {
            /*" -2206- PERFORM R4150_10_LER_V2HISTOPARC_DB_FETCH_1 */

            R4150_10_LER_V2HISTOPARC_DB_FETCH_1();

            /*" -2209- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2210- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2211- MOVE 'S' TO WFIM-V2HISTOPARC */
                    _.Move("S", AREA_DE_WORK.WFIM_V2HISTOPARC);

                    /*" -2211- PERFORM R4150_10_LER_V2HISTOPARC_DB_CLOSE_1 */

                    R4150_10_LER_V2HISTOPARC_DB_CLOSE_1();

                    /*" -2213- GO TO R4150-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R4150_99_SAIDA*/ //GOTO
                    return;

                    /*" -2214- ELSE */
                }
                else
                {


                    /*" -2215- DISPLAY 'R4150 - ERRO NO FETCH DA V1HISTOPARC' */
                    _.Display($"R4150 - ERRO NO FETCH DA V1HISTOPARC");

                    /*" -2216- DISPLAY 'APOLICE - ' V1HISP-NUM-APOL */
                    _.Display($"APOLICE - {V1HISP_NUM_APOL}");

                    /*" -2217- DISPLAY 'ENDOSSO - ' V1HISP-NRENDOS */
                    _.Display($"ENDOSSO - {V1HISP_NRENDOS}");

                    /*" -2218- DISPLAY 'PARCELA - ' V1HISP-NRPARCEL */
                    _.Display($"PARCELA - {V1HISP_NRPARCEL}");

                    /*" -2219- DISPLAY 'OC HIST - ' V2HISP-OCORHIST */
                    _.Display($"OC HIST - {V2HISP_OCORHIST}");

                    /*" -2220- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2221- END-IF */
                }


                /*" -2222- ELSE */
            }
            else
            {


                /*" -2223- IF VIND-DTQITBCO < ZEROS */

                if (VIND_DTQITBCO < 00)
                {

                    /*" -2224- MOVE SPACES TO V2HISP-DTQITBCO */
                    _.Move("", V2HISP_DTQITBCO);

                    /*" -2225- END-IF */
                }


                /*" -2227- END-IF. */
            }


            /*" -2229- MOVE V2HISP-OPERACAO TO W2OPERACAO. */
            _.Move(V2HISP_OPERACAO, AREA_DE_WORK.W2OPERACAO);

            /*" -2230- IF W2TIPO-OPERACAO = 06 OR 07 OR 09 OR 10 */

            if (AREA_DE_WORK.FILLER_2.W2TIPO_OPERACAO.In("06", "07", "09", "10"))
            {

                /*" -2231- GO TO R4150-10-LER-V2HISTOPARC */
                new Task(() => R4150_10_LER_V2HISTOPARC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -2232- ELSE */
            }
            else
            {


                /*" -2233- ADD 1 TO AC-L-V1HISTOPARC */
                AREA_DE_WORK.AC_L_V1HISTOPARC.Value = AREA_DE_WORK.AC_L_V1HISTOPARC + 1;

                /*" -2233- END-IF. */
            }


        }

        [StopWatch]
        /*" R4150-10-LER-V2HISTOPARC-DB-FETCH-1 */
        public void R4150_10_LER_V2HISTOPARC_DB_FETCH_1()
        {
            /*" -2206- EXEC SQL FETCH V2HISTOPARC INTO :V2HISP-DTMOVTO , :V2HISP-OCORHIST , :V2HISP-OPERACAO , :V2HISP-PRM-TAR , :V2HISP-VAL-DES , :V2HISP-VLADIFRA , :V2HISP-DTQITBCO:VIND-DTQITBCO, :V2PARC-PRM-TAR , :V2PARC-VAL-DES , :V2PARC-OTNADFRA END-EXEC. */

            if (V2HISTOPARC.Fetch())
            {
                _.Move(V2HISTOPARC.V2HISP_DTMOVTO, V2HISP_DTMOVTO);
                _.Move(V2HISTOPARC.V2HISP_OCORHIST, V2HISP_OCORHIST);
                _.Move(V2HISTOPARC.V2HISP_OPERACAO, V2HISP_OPERACAO);
                _.Move(V2HISTOPARC.V2HISP_PRM_TAR, V2HISP_PRM_TAR);
                _.Move(V2HISTOPARC.V2HISP_VAL_DES, V2HISP_VAL_DES);
                _.Move(V2HISTOPARC.V2HISP_VLADIFRA, V2HISP_VLADIFRA);
                _.Move(V2HISTOPARC.V2HISP_DTQITBCO, V2HISP_DTQITBCO);
                _.Move(V2HISTOPARC.VIND_DTQITBCO, VIND_DTQITBCO);
                _.Move(V2HISTOPARC.V2PARC_PRM_TAR, V2PARC_PRM_TAR);
                _.Move(V2HISTOPARC.V2PARC_VAL_DES, V2PARC_VAL_DES);
                _.Move(V2HISTOPARC.V2PARC_OTNADFRA, V2PARC_OTNADFRA);
            }

        }

        [StopWatch]
        /*" R4150-10-LER-V2HISTOPARC-DB-CLOSE-1 */
        public void R4150_10_LER_V2HISTOPARC_DB_CLOSE_1()
        {
            /*" -2211- EXEC SQL CLOSE V2HISTOPARC END-EXEC */

            V2HISTOPARC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4150_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-PROCESSA-V2HISTOPARC-SECTION */
        private void R4200_00_PROCESSA_V2HISTOPARC_SECTION()
        {
            /*" -2246- MOVE '420' TO WNR-EXEC-SQL. */
            _.Move("420", WABEND.WNR_EXEC_SQL);

            /*" -2248- PERFORM R4300-00-CALCULA-VALORES. */

            R4300_00_CALCULA_VALORES_SECTION();

            /*" -2249- IF W2TIPO-OPERACAO EQUAL 01 */

            if (AREA_DE_WORK.FILLER_2.W2TIPO_OPERACAO == 01)
            {

                /*" -2250- PERFORM R4400-00-MONTA-COSSEG-PREM */

                R4400_00_MONTA_COSSEG_PREM_SECTION();

                /*" -2252- PERFORM R4500-00-INCLUI-COSSEG-PREM. */

                R4500_00_INCLUI_COSSEG_PREM_SECTION();
            }


            /*" -2254- PERFORM R4600-00-MONTA-COSSEG-HPRE. */

            R4600_00_MONTA_COSSEG_HPRE_SECTION();

            /*" -2256- PERFORM R4700-00-INCLUI-COSSEG-HPRE. */

            R4700_00_INCLUI_COSSEG_HPRE_SECTION();

            /*" -2256- PERFORM R4150-00-FETCH-V2HISTOPARC. */

            R4150_00_FETCH_V2HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-CALCULA-VALORES-SECTION */
        private void R4300_00_CALCULA_VALORES_SECTION()
        {
            /*" -2269- MOVE '430' TO WNR-EXEC-SQL. */
            _.Move("430", WABEND.WNR_EXEC_SQL);

            /*" -2273- COMPUTE V2CPRE-PRM-TAR-IX = V2PARC-PRM-TAR * WS-PCPARTIC / 100. */
            V2CPRE_PRM_TAR_IX.Value = V2PARC_PRM_TAR * AREA_DE_WORK.WS_PCPARTIC / 100f;

            /*" -2277- COMPUTE V2CHIS-PRM-TAR = V2HISP-PRM-TAR * WS-PCPARTIC / 100. */
            V2CHIS_PRM_TAR.Value = V2HISP_PRM_TAR * AREA_DE_WORK.WS_PCPARTIC / 100f;

            /*" -2281- COMPUTE V2CPRE-VAL-DES-IX = V2PARC-VAL-DES * WS-PCPARTIC / 100. */
            V2CPRE_VAL_DES_IX.Value = V2PARC_VAL_DES * AREA_DE_WORK.WS_PCPARTIC / 100f;

            /*" -2285- COMPUTE V2CHIS-VAL-DES = V2HISP-VAL-DES * WS-PCPARTIC / 100. */
            V2CHIS_VAL_DES.Value = V2HISP_VAL_DES * AREA_DE_WORK.WS_PCPARTIC / 100f;

            /*" -2288- COMPUTE V2CPRE-OTNPRLIQ = V2CPRE-PRM-TAR-IX - V2CPRE-VAL-DES-IX. */
            V2CPRE_OTNPRLIQ.Value = V2CPRE_PRM_TAR_IX - V2CPRE_VAL_DES_IX;

            /*" -2291- COMPUTE V2CHIS-VLPRMLIQ = V2CHIS-PRM-TAR - V2CHIS-VAL-DES. */
            V2CHIS_VLPRMLIQ.Value = V2CHIS_PRM_TAR - V2CHIS_VAL_DES;

            /*" -2295- COMPUTE V2CPRE-OTNADFRA = V2PARC-OTNADFRA * WS-PCPARTIC / 100. */
            V2CPRE_OTNADFRA.Value = V2PARC_OTNADFRA * AREA_DE_WORK.WS_PCPARTIC / 100f;

            /*" -2299- COMPUTE V2CHIS-VLADIFRA = V2HISP-VLADIFRA * WS-PCPARTIC / 100. */
            V2CHIS_VLADIFRA.Value = V2HISP_VLADIFRA * AREA_DE_WORK.WS_PCPARTIC / 100f;

            /*" -2304- COMPUTE V2CPRE-VLCOMISIX = (V2CPRE-OTNPRLIQ + V2CPRE-OTNADFRA) * WS-PCCOMCOS / 100. */
            V2CPRE_VLCOMISIX.Value = (V2CPRE_OTNPRLIQ + V2CPRE_OTNADFRA) * AREA_DE_WORK.WS_PCCOMCOS / 100f;

            /*" -2309- COMPUTE V2CHIS-VLCOMIS = (V2CHIS-VLPRMLIQ + V2CHIS-VLADIFRA) * WS-PCCOMCOS / 100. */
            V2CHIS_VLCOMIS.Value = (V2CHIS_VLPRMLIQ + V2CHIS_VLADIFRA) * AREA_DE_WORK.WS_PCCOMCOS / 100f;

            /*" -2313- COMPUTE V2CPRE-OTNTOTAL = V2CPRE-OTNPRLIQ + V2CPRE-OTNADFRA - V2CPRE-VLCOMISIX. */
            V2CPRE_OTNTOTAL.Value = V2CPRE_OTNPRLIQ + V2CPRE_OTNADFRA - V2CPRE_VLCOMISIX;

            /*" -2317- COMPUTE V2CHIS-VLPRMTOT = V2CHIS-VLPRMLIQ + V2CHIS-VLADIFRA - V2CHIS-VLCOMIS. */
            V2CHIS_VLPRMTOT.Value = V2CHIS_VLPRMLIQ + V2CHIS_VLADIFRA - V2CHIS_VLCOMIS;

            /*" -2318- IF V0ENDO-CORRECAO = '1' OR '3' */

            if (V0ENDO_CORRECAO.In("1", "3"))
            {

                /*" -2319- MOVE ZEROS TO V2CPRE-PRM-TAR-IX */
                _.Move(0, V2CPRE_PRM_TAR_IX);

                /*" -2320- MOVE V2CHIS-PRM-TAR TO V2CPRE-PRM-TAR-IX */
                _.Move(V2CHIS_PRM_TAR, V2CPRE_PRM_TAR_IX);

                /*" -2321- MOVE ZEROS TO V2CPRE-VAL-DES-IX */
                _.Move(0, V2CPRE_VAL_DES_IX);

                /*" -2322- MOVE V2CHIS-VAL-DES TO V2CPRE-VAL-DES-IX */
                _.Move(V2CHIS_VAL_DES, V2CPRE_VAL_DES_IX);

                /*" -2323- MOVE ZEROS TO V2CPRE-OTNPRLIQ */
                _.Move(0, V2CPRE_OTNPRLIQ);

                /*" -2324- MOVE V2CHIS-VLPRMLIQ TO V2CPRE-OTNPRLIQ */
                _.Move(V2CHIS_VLPRMLIQ, V2CPRE_OTNPRLIQ);

                /*" -2325- MOVE ZEROS TO V2CPRE-OTNADFRA */
                _.Move(0, V2CPRE_OTNADFRA);

                /*" -2326- MOVE V2CHIS-VLADIFRA TO V2CPRE-OTNADFRA */
                _.Move(V2CHIS_VLADIFRA, V2CPRE_OTNADFRA);

                /*" -2327- MOVE ZEROS TO V2CPRE-VLCOMISIX */
                _.Move(0, V2CPRE_VLCOMISIX);

                /*" -2328- MOVE V2CHIS-VLCOMIS TO V2CPRE-VLCOMISIX */
                _.Move(V2CHIS_VLCOMIS, V2CPRE_VLCOMISIX);

                /*" -2329- MOVE ZEROS TO V2CPRE-OTNTOTAL */
                _.Move(0, V2CPRE_OTNTOTAL);

                /*" -2330- MOVE V2CHIS-VLPRMTOT TO V2CPRE-OTNTOTAL */
                _.Move(V2CHIS_VLPRMTOT, V2CPRE_OTNTOTAL);

                /*" -2330- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R4400-00-MONTA-COSSEG-PREM-SECTION */
        private void R4400_00_MONTA_COSSEG_PREM_SECTION()
        {
            /*" -2343- MOVE '440' TO WNR-EXEC-SQL. */
            _.Move("440", WABEND.WNR_EXEC_SQL);

            /*" -2344- MOVE ZEROS TO V2CPRE-COD-EMPR. */
            _.Move(0, V2CPRE_COD_EMPR);

            /*" -2345- MOVE '1' TO V2CPRE-TIPSGU. */
            _.Move("1", V2CPRE_TIPSGU);

            /*" -2346- MOVE V1APCD-CODCOSS TO V2CPRE-CONGENER. */
            _.Move(V1APCD_CODCOSS, V2CPRE_CONGENER);

            /*" -2347- MOVE V1ORDC-ORD-CEDIDO TO V2CPRE-NUM-ORDEM. */
            _.Move(V1ORDC_ORD_CEDIDO, V2CPRE_NUM_ORDEM);

            /*" -2348- MOVE V1HISP-NUM-APOL TO V2CPRE-NUM-APOL. */
            _.Move(V1HISP_NUM_APOL, V2CPRE_NUM_APOL);

            /*" -2349- MOVE V1HISP-NRENDOS TO V2CPRE-NRENDOS. */
            _.Move(V1HISP_NRENDOS, V2CPRE_NRENDOS);

            /*" -2350- MOVE V1HISP-NRPARCEL TO V2CPRE-NRPARCEL. */
            _.Move(V1HISP_NRPARCEL, V2CPRE_NRPARCEL);

            /*" -2351- MOVE '0' TO V2CPRE-SITUACAO. */
            _.Move("0", V2CPRE_SITUACAO);

            /*" -2352- MOVE '0' TO V2CPRE-SIT-CONG. */
            _.Move("0", V2CPRE_SIT_CONG);

            /*" -2354- MOVE 01 TO V2CPRE-OCORHIST. */
            _.Move(01, V2CPRE_OCORHIST);

            /*" -2354- MOVE +1 TO VIND-OCR-HIST. */
            _.Move(+1, VIND_OCR_HIST);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-INCLUI-COSSEG-PREM-SECTION */
        private void R4500_00_INCLUI_COSSEG_PREM_SECTION()
        {
            /*" -2367- MOVE '450' TO WNR-EXEC-SQL. */
            _.Move("450", WABEND.WNR_EXEC_SQL);

            /*" -2386- PERFORM R4500_00_INCLUI_COSSEG_PREM_DB_INSERT_1 */

            R4500_00_INCLUI_COSSEG_PREM_DB_INSERT_1();

            /*" -2389- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2390- DISPLAY 'R4500 - ERRO NO INSERT DA V0COSSEG-PREM' */
                _.Display($"R4500 - ERRO NO INSERT DA V0COSSEG-PREM");

                /*" -2391- DISPLAY 'TIPO SEG - ' V2CPRE-TIPSGU */
                _.Display($"TIPO SEG - {V2CPRE_TIPSGU}");

                /*" -2392- DISPLAY 'COD COSS - ' V2CPRE-CONGENER */
                _.Display($"COD COSS - {V2CPRE_CONGENER}");

                /*" -2393- DISPLAY 'NR ORDEM - ' V2CPRE-NUM-ORDEM */
                _.Display($"NR ORDEM - {V2CPRE_NUM_ORDEM}");

                /*" -2394- DISPLAY 'APOLICE  - ' V2CPRE-NUM-APOL */
                _.Display($"APOLICE  - {V2CPRE_NUM_APOL}");

                /*" -2395- DISPLAY 'ENDOSSO  - ' V2CPRE-NRENDOS */
                _.Display($"ENDOSSO  - {V2CPRE_NRENDOS}");

                /*" -2396- DISPLAY 'PARCELA  - ' V2CPRE-NRPARCEL */
                _.Display($"PARCELA  - {V2CPRE_NRPARCEL}");

                /*" -2397- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2398- ELSE */
            }
            else
            {


                /*" -2398- ADD 1 TO AC-I-V0COSSEGPREM. */
                AREA_DE_WORK.AC_I_V0COSSEGPREM.Value = AREA_DE_WORK.AC_I_V0COSSEGPREM + 1;
            }


        }

        [StopWatch]
        /*" R4500-00-INCLUI-COSSEG-PREM-DB-INSERT-1 */
        public void R4500_00_INCLUI_COSSEG_PREM_DB_INSERT_1()
        {
            /*" -2386- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_PREM VALUES (:V2CPRE-COD-EMPR , :V2CPRE-TIPSGU , :V2CPRE-CONGENER , :V2CPRE-NUM-ORDEM , :V2CPRE-NUM-APOL , :V2CPRE-NRENDOS , :V2CPRE-NRPARCEL , :V2CPRE-PRM-TAR-IX , :V2CPRE-VAL-DES-IX , :V2CPRE-OTNPRLIQ , :V2CPRE-OTNADFRA , :V2CPRE-VLCOMISIX , :V2CPRE-OTNTOTAL , :V2CPRE-SITUACAO , :V2CPRE-SIT-CONG , CURRENT TIMESTAMP , :V2CPRE-OCORHIST:VIND-OCR-HIST) END-EXEC. */

            var r4500_00_INCLUI_COSSEG_PREM_DB_INSERT_1_Insert1 = new R4500_00_INCLUI_COSSEG_PREM_DB_INSERT_1_Insert1()
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

            R4500_00_INCLUI_COSSEG_PREM_DB_INSERT_1_Insert1.Execute(r4500_00_INCLUI_COSSEG_PREM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_99_SAIDA*/

        [StopWatch]
        /*" R4600-00-MONTA-COSSEG-HPRE-SECTION */
        private void R4600_00_MONTA_COSSEG_HPRE_SECTION()
        {
            /*" -2411- MOVE '460' TO WNR-EXEC-SQL. */
            _.Move("460", WABEND.WNR_EXEC_SQL);

            /*" -2412- MOVE ZEROS TO V2CHIS-COD-EMPR. */
            _.Move(0, V2CHIS_COD_EMPR);

            /*" -2413- MOVE V1APCD-CODCOSS TO V2CHIS-CONGENER. */
            _.Move(V1APCD_CODCOSS, V2CHIS_CONGENER);

            /*" -2414- MOVE V1HISP-NUM-APOL TO V2CHIS-NUM-APOL. */
            _.Move(V1HISP_NUM_APOL, V2CHIS_NUM_APOL);

            /*" -2415- MOVE V1HISP-NRENDOS TO V2CHIS-NRENDOS. */
            _.Move(V1HISP_NRENDOS, V2CHIS_NRENDOS);

            /*" -2417- MOVE V1HISP-NRPARCEL TO V2CHIS-NRPARCEL. */
            _.Move(V1HISP_NRPARCEL, V2CHIS_NRPARCEL);

            /*" -2420- COMPUTE V2CHIS-OCORHIST = V2CHIS-OCORHIST + 1. */
            V2CHIS_OCORHIST.Value = V2CHIS_OCORHIST + 1;

            /*" -2421- MOVE V2HISP-OPERACAO TO V2CHIS-OPERACAO. */
            _.Move(V2HISP_OPERACAO, V2CHIS_OPERACAO);

            /*" -2422- MOVE V2HISP-DTMOVTO TO V2CHIS-DTMOVTO. */
            _.Move(V2HISP_DTMOVTO, V2CHIS_DTMOVTO);

            /*" -2424- MOVE '1' TO V2CHIS-TIPSGU. */
            _.Move("1", V2CHIS_TIPSGU);

            /*" -2426- MOVE V2HISP-DTQITBCO TO V2CHIS-DTQITBCO. */
            _.Move(V2HISP_DTQITBCO, V2CHIS_DTQITBCO);

            /*" -2427- IF V2HISP-DTQITBCO = SPACES */

            if (V2HISP_DTQITBCO.IsEmpty())
            {

                /*" -2428- MOVE -1 TO VIND-DTQITBCO */
                _.Move(-1, VIND_DTQITBCO);

                /*" -2429- ELSE */
            }
            else
            {


                /*" -2430- MOVE +1 TO VIND-DTQITBCO */
                _.Move(+1, VIND_DTQITBCO);

                /*" -2432- END-IF. */
            }


            /*" -2435- MOVE '0' TO V2CHIS-SIT-FINANC V2CHIS-SIT-LIBREC. */
            _.Move("0", V2CHIS_SIT_FINANC, V2CHIS_SIT_LIBREC);

            /*" -2438- MOVE +1 TO VIND-SIT-FINC VIND-SIT-LIBR. */
            _.Move(+1, VIND_SIT_FINC, VIND_SIT_LIBR);

            /*" -2440- MOVE V2HISP-OCORHIST TO V2CHIS-NUM-OCOR. */
            _.Move(V2HISP_OCORHIST, V2CHIS_NUM_OCOR);

            /*" -2440- MOVE +1 TO VIND-NUM-OCOR. */
            _.Move(+1, VIND_NUM_OCOR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4600_99_SAIDA*/

        [StopWatch]
        /*" R4700-00-INCLUI-COSSEG-HPRE-SECTION */
        private void R4700_00_INCLUI_COSSEG_HPRE_SECTION()
        {
            /*" -2453- MOVE '470' TO WNR-EXEC-SQL. */
            _.Move("470", WABEND.WNR_EXEC_SQL);

            /*" -2475- PERFORM R4700_00_INCLUI_COSSEG_HPRE_DB_INSERT_1 */

            R4700_00_INCLUI_COSSEG_HPRE_DB_INSERT_1();

            /*" -2478- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2479- DISPLAY 'R4700 - ERRO NO INSERT DA V0COSSEG-HISPRE' */
                _.Display($"R4700 - ERRO NO INSERT DA V0COSSEG-HISPRE");

                /*" -2480- DISPLAY 'TIPO SEG - ' V2CHIS-TIPSGU */
                _.Display($"TIPO SEG - {V2CHIS_TIPSGU}");

                /*" -2481- DISPLAY 'COD COSS - ' V2CHIS-CONGENER */
                _.Display($"COD COSS - {V2CHIS_CONGENER}");

                /*" -2482- DISPLAY 'APOLICE  - ' V2CHIS-NUM-APOL */
                _.Display($"APOLICE  - {V2CHIS_NUM_APOL}");

                /*" -2483- DISPLAY 'ENDOSSO  - ' V2CHIS-NRENDOS */
                _.Display($"ENDOSSO  - {V2CHIS_NRENDOS}");

                /*" -2484- DISPLAY 'PARCELA  - ' V2CHIS-NRPARCEL */
                _.Display($"PARCELA  - {V2CHIS_NRPARCEL}");

                /*" -2485- DISPLAY 'OC. HIST - ' V2CHIS-OCORHIST */
                _.Display($"OC. HIST - {V2CHIS_OCORHIST}");

                /*" -2486- DISPLAY 'OPERACAO - ' V2CHIS-OPERACAO */
                _.Display($"OPERACAO - {V2CHIS_OPERACAO}");

                /*" -2487- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2488- ELSE */
            }
            else
            {


                /*" -2488- ADD 1 TO AC-I-V0COSSEGHISP. */
                AREA_DE_WORK.AC_I_V0COSSEGHISP.Value = AREA_DE_WORK.AC_I_V0COSSEGHISP + 1;
            }


        }

        [StopWatch]
        /*" R4700-00-INCLUI-COSSEG-HPRE-DB-INSERT-1 */
        public void R4700_00_INCLUI_COSSEG_HPRE_DB_INSERT_1()
        {
            /*" -2475- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_HISTPRE VALUES (:V2CHIS-COD-EMPR , :V2CHIS-CONGENER , :V2CHIS-NUM-APOL , :V2CHIS-NRENDOS , :V2CHIS-NRPARCEL , :V2CHIS-OCORHIST , :V2CHIS-OPERACAO , :V2CHIS-DTMOVTO , :V2CHIS-TIPSGU , :V2CHIS-PRM-TAR , :V2CHIS-VAL-DES , :V2CHIS-VLPRMLIQ , :V2CHIS-VLADIFRA , :V2CHIS-VLCOMIS , :V2CHIS-VLPRMTOT , CURRENT TIMESTAMP , :V2CHIS-DTQITBCO:VIND-DTQITBCO, :V2CHIS-SIT-FINANC:VIND-SIT-FINC, :V2CHIS-SIT-LIBREC:VIND-SIT-LIBR, :V2CHIS-NUM-OCOR:VIND-NUM-OCOR) END-EXEC. */

            var r4700_00_INCLUI_COSSEG_HPRE_DB_INSERT_1_Insert1 = new R4700_00_INCLUI_COSSEG_HPRE_DB_INSERT_1_Insert1()
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
                V2CHIS_SIT_LIBREC = V2CHIS_SIT_LIBREC.ToString(),
                VIND_SIT_LIBR = VIND_SIT_LIBR.ToString(),
                V2CHIS_NUM_OCOR = V2CHIS_NUM_OCOR.ToString(),
                VIND_NUM_OCOR = VIND_NUM_OCOR.ToString(),
            };

            R4700_00_INCLUI_COSSEG_HPRE_DB_INSERT_1_Insert1.Execute(r4700_00_INCLUI_COSSEG_HPRE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4700_99_SAIDA*/

        [StopWatch]
        /*" R4800-00-ATUALIZA-OCORHIST-SECTION */
        private void R4800_00_ATUALIZA_OCORHIST_SECTION()
        {
            /*" -2501- MOVE '480' TO WNR-EXEC-SQL. */
            _.Move("480", WABEND.WNR_EXEC_SQL);

            /*" -2509- PERFORM R4800_00_ATUALIZA_OCORHIST_DB_UPDATE_1 */

            R4800_00_ATUALIZA_OCORHIST_DB_UPDATE_1();

            /*" -2512- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2513- DISPLAY 'R4800 - ERRO NO UPDATE DA V0COSSEG-PREM' */
                _.Display($"R4800 - ERRO NO UPDATE DA V0COSSEG-PREM");

                /*" -2514- DISPLAY 'TIPO SEG - ' V2CHIS-TIPSGU */
                _.Display($"TIPO SEG - {V2CHIS_TIPSGU}");

                /*" -2515- DISPLAY 'COD COSS - ' V2CHIS-CONGENER */
                _.Display($"COD COSS - {V2CHIS_CONGENER}");

                /*" -2516- DISPLAY 'APOLICE  - ' V2CHIS-NUM-APOL */
                _.Display($"APOLICE  - {V2CHIS_NUM_APOL}");

                /*" -2517- DISPLAY 'ENDOSSO  - ' V2CHIS-NRENDOS */
                _.Display($"ENDOSSO  - {V2CHIS_NRENDOS}");

                /*" -2518- DISPLAY 'PARCELA  - ' V2CHIS-NRPARCEL */
                _.Display($"PARCELA  - {V2CHIS_NRPARCEL}");

                /*" -2518- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4800-00-ATUALIZA-OCORHIST-DB-UPDATE-1 */
        public void R4800_00_ATUALIZA_OCORHIST_DB_UPDATE_1()
        {
            /*" -2509- EXEC SQL UPDATE SEGUROS.V0COSSEG_PREM SET OCORHIST = :V2CHIS-OCORHIST WHERE CONGENER = :V2CHIS-CONGENER AND NUM_APOLICE = :V2CHIS-NUM-APOL AND NRENDOS = :V2CHIS-NRENDOS AND NRPARCEL = :V2CHIS-NRPARCEL AND TIPSGU = '1' END-EXEC. */

            var r4800_00_ATUALIZA_OCORHIST_DB_UPDATE_1_Update1 = new R4800_00_ATUALIZA_OCORHIST_DB_UPDATE_1_Update1()
            {
                V2CHIS_OCORHIST = V2CHIS_OCORHIST.ToString(),
                V2CHIS_CONGENER = V2CHIS_CONGENER.ToString(),
                V2CHIS_NUM_APOL = V2CHIS_NUM_APOL.ToString(),
                V2CHIS_NRPARCEL = V2CHIS_NRPARCEL.ToString(),
                V2CHIS_NRENDOS = V2CHIS_NRENDOS.ToString(),
            };

            R4800_00_ATUALIZA_OCORHIST_DB_UPDATE_1_Update1.Execute(r4800_00_ATUALIZA_OCORHIST_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4800_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -2531- MOVE V1SIST-DTMOVABE TO WDATA-AUX. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_AUX);

            /*" -2532- MOVE WDATA-DIA-AUX TO WDATA-DIA-EDT. */
            _.Move(AREA_DE_WORK.FILLER_4.WDATA_DIA_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_DIA_EDT);

            /*" -2533- MOVE WDATA-MES-AUX TO WDATA-MES-EDT. */
            _.Move(AREA_DE_WORK.FILLER_4.WDATA_MES_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_MES_EDT);

            /*" -2535- MOVE WDATA-ANO-AUX TO WDATA-ANO-EDT. */
            _.Move(AREA_DE_WORK.FILLER_4.WDATA_ANO_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_ANO_EDT);

            /*" -2536- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -2537- DISPLAY '*   AC0010B - ATUALIZACAO DB DE COSSEGURO  *' . */
            _.Display($"*   AC0010B - ATUALIZACAO DB DE COSSEGURO  *");

            /*" -2538- DISPLAY '*   -------   ----------- -- -- ---------  *' . */
            _.Display($"*   -------   ----------- -- -- ---------  *");

            /*" -2539- DISPLAY '*             COSSEGURO CEDIDO             *' . */
            _.Display($"*             COSSEGURO CEDIDO             *");

            /*" -2540- DISPLAY '*             --------- ------             *' . */
            _.Display($"*             --------- ------             *");

            /*" -2541- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -2542- DISPLAY '*   NAO HOUVE MOVIMENTACAO NESTA DATA      *' . */
            _.Display($"*   NAO HOUVE MOVIMENTACAO NESTA DATA      *");

            /*" -2544- DISPLAY '*              ' WDATA-EDIT '                    *' . */

            $"*              {AREA_DE_WORK.WDATA_EDIT}                    *"
            .Display();

            /*" -2544- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2559- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -2561- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -2561- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2565- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2565- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}