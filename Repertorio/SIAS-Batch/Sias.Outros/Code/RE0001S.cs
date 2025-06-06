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
using Sias.Outros.DB2.RE0001S;

namespace Code
{
    public class RE0001S
    {
        public bool IsCall { get; set; }

        public RE0001S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  RE - RESSEGURO                     *      */
        /*"      *   PROGRAMA ...............  RE0001S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA/PROGRAMADOR....  CARLOS ALBERTO DE A ALVES          *      */
        /*"      *   DATA CODIFICACAO .......  MAIO/1999                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  SUB-ROTINA PARA CALCULO DOS PERCEN-*      */
        /*"      *                             TUAIS DE RESSEGURO                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * HISTORICO PARCELAS                  V0HISTOPARC       INPUT    *      */
        /*"      * COBERTURA DE APOLICES               V0COBERAPOL       INPUT    *      */
        /*"      * HISTORICO RESSEGUROS                V0HISTORES        INPUT    *      */
        /*"      * DADOS TECNICOS RESSEGURO            V0DADOSRES        INPUT    *      */
        /*"      * MOVIMENTO DO HABITACIONAL           MOVIMENTO-HABIT   INPUT    *      */
        /*"      * PARCELAS COMPLEMENTO                V0PARCELA-COMPL   INPUT    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * (CAAA1) ALTERACAO EM FEV/2000 POR CARLOS ALBERTO DE A ALVES    *      */
        /*"      * RAMO 68 APOLICE 6501000001, PASSARA A ABATER O ER NO CALCULO   *      */
        /*"      * DE COTA, E O % DE COTA SERA O LANCADO DA V0DADOSRES.           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *         ALTERACAO EM MAI/2005 POR GILSON PINTO DA SILVA PARA   *      */
        /*"      * INCLUIR O RAMO 67 NA REGRA DE QUANDO HOUVER EXCD. RESP., NAO   *      */
        /*"      * CALULAR COTA, E O % SERA IGUAL A ZERO (E-MAIL DE 02/05/2005)   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *         ALTERACAO EM JUN/2005 POR GILSON PINTO DA SILVA PARA   *      */
        /*"      * INCLUIR A APOLICE 106800000013 PRODUTO 6815 PARA TER O MESMO   *      */
        /*"      * TRATAMENTO DA APOLICE 6501000001 PRODUTO 6800                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM JUL/2007 POR BRSEG    ( PROCURAR POR BRSEG1 E 2 ) *      */
        /*"      * INCLUIR TRATAMENTO DIFERENCIADO DE PREMIO/IS PARA PRODUTO 1804 *      */
        /*"      * ALTERACAO NO TAMANHO DE VARIAVEL                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 10/09/2007 POR GILSON  ( PROCURAR POR GP0907 )    *      */
        /*"      * CALCULO DA I.S. DO E.R. ATRAVES DA MULTIPLICACAO DA IMP SEG DO *      */
        /*"      * RAMO DE COBERTURA PELO PERCENTUAL DE E.R.                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 28/12/2010 POR HERVAL    ( PROCURAR POR C47532 )  *      */
        /*"      * ATENDER CIRCULAR 395 QUE ALTERA DIVERSOS RAMOS.                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EM ABR/2013 POR GILSON PINTO DA SILVA - PROCURAR C81385       *      */
        /*"      *  - ALTERAR A CRITICA PARA IDENTIFICAR OS RAMOS DE VIDA COM A   *      */
        /*"      *    INCLUSAO DO RAMO 37, PROD 3701(MICROSSEGURO AMPARO - PESSOA)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - INCLUIR NO PARAMETRO DE SAIDA A DATA DO CUTOFF    *      */
        /*"      * 07/03/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 192299 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - AJUSTAR OS PARAMETROS DE ENTRADA DA SUB-ROTINA    *      */
        /*"      *              RE0002S PARA O RESSEGURO DO PRODUTO 1804          *      */
        /*"      * 13/08/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 192299 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - INCLUIR NO PARAMETRO DE SAIDA O CODIGO DO CONTRATO*      */
        /*"      *              DE RESSEGURO                                      *      */
        /*"      * 11/10/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 212422 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - CORRECAO DE ABEND.                                *      */
        /*"      *              ALTERAR O TAMANHO DA VARIAVEL LKRE02-PCT-CORR     *      */
        /*"      * 10/12/2019 - WELLINGTON FRC VERAS     JAZZ - TAREFA   - 226487 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - ALTERAR A REGRA DE CALCULO DO RESSEGURO DO PRODUTO*      */
        /*"      *              1804 DO MODO PROPORCIONAL PARA O MODO FINANCEIRO  *      */
        /*"      *              A PARTIR DO DIA 17/05/2021 COM A INCLUSAO DO NOVO *      */
        /*"      *              PARAMETRO LKRE02-DTEMS-AP DA SUB-ROTINA RE0002S   *      */
        /*"      * 15/05/2021 - GILSON PINTO DA SILVA    JAZZ - TAREFA   - 289210 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"77          VIND-NUM-ENDS       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NUM_ENDS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          VIND-DTCUTOFF       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTCUTOFF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          VIND-CONTR-RE       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_CONTR_RE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WHOST-NUM-APOL      PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis WHOST_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          WHOST-NRENDOS       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis WHOST_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          WHOST-RAMOFR        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WHOST_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WHOST-MODALIFR      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WHOST_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WHOST-DTINIVIG      PIC  X(010)      VALUE SPACES.*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          WHOST-IMPSEG-ER     PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WHOST_IMPSEG_ER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0HISP-NUM-APOL     PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0HISP-NRENDOS      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0HISP-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0HISP-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0HISP-OPERACAO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0HISP-DTMOVTO      PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0HISP-PRM-TAR      PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0COBA-NUM-APOL     PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0COBA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0COBA-NRENDOS      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0COBA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0COBA-NRITEM       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0COBA_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0COBA-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0COBA-RAMOFR       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBA_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0COBA-MODLFR       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBA_MODLFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0COBA-COD-COBT     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBA_COD_COBT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0COBA-DTINIVIG     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0COBA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0COBA-DTTERVIG     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0COBA_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0COBA-IMP-IX-T     PIC S9(013)V9(2) VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_IMP_IX_T { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77          V0COBA-IMP-IX-R     PIC S9(013)V9(2) VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_IMP_IX_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77          V0COBA-PRM-VAR-T    PIC S9(010)V9(5) VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PRM_VAR_T { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0COBA-PRM-VAR-R    PIC S9(010)V9(5) VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PRM_VAR_R { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0HISR-NUM-APOL     PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0HISR_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0HISR-NRENDOS      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0HISR_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0HISR-RAMOFR       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HISR_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0HISR-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HISR_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0HISR-DTMOVTO      PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0HISR_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0HISR-OPERACAO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HISR_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0HISR-VLSEGURO     PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0HISR_VLSEGURO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0HISR-PRERSP       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0HISR_PRERSP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0HISR-COMRSP       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0HISR_COMRSP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0DRES-RAMO         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DRES_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0DRES-MODL         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DRES_MODL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0DRES-TIPRIS       PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0DRES_TIPRIS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77          V0DRES-DTINIVIG     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0DRES_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0DRES-DTTERVIG     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0DRES_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0DRES-PCTCOT       PIC S9(004)V9(5) VALUE +0 COMP-3*/
        public DoubleBasis V0DRES_PCTCOT { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77          V0DRES-PCTCTF       PIC S9(004)V9(5) VALUE +0 COMP-3*/
        public DoubleBasis V0DRES_PCTCTF { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77          V0DRES-PCTDNO       PIC S9(004)V9(5) VALUE +0 COMP-3*/
        public DoubleBasis V0DRES_PCTDNO { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77          V0DRES-PCTCOMCO     PIC S9(004)V9(5) VALUE +0 COMP-3*/
        public DoubleBasis V0DRES_PCTCOMCO { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77          V0DRES-PCTCOMRS     PIC S9(004)V9(5) VALUE +0 COMP-3*/
        public DoubleBasis V0DRES_PCTCOMRS { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77          V0DRES-DTCUTOFF     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0DRES_DTCUTOFF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0DRES-RECUP-PSL    PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0DRES_RECUP_PSL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77          V0DRES-CONTR-RESG   PIC  X(025)      VALUE SPACES.*/
        public StringBasis V0DRES_CONTR_RESG { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
        /*"77          MOVHBT-NUM-APOL     PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis MOVHBT_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          MOVHBT-NUM-ENDS     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis MOVHBT_NUM_ENDS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          MOVHBT-PRM-CRED     PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis MOVHBT_PRM_CRED { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0PCMP-NUM-APOL     PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0PCMP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0PCMP-NRENDOS      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0PCMP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0PCMP-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PCMP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0PCMP-VLR-COMPL    PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0PCMP_VLR_COMPL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0PCMP-VLR-COMPL-I  PIC S9(010)V9(5) VALUE +0 COMP-3*/
        public DoubleBasis V0PCMP_VLR_COMPL_I { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0ENDO-NUM-APOL     PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0ENDO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0ENDO-NRENDOS      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0ENDO-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0ENDO-CODSUBES     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0ENDO-DTEMIS       PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0ENDO-DTINIVIG     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0ENDO-DTTERVIG     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0ENDO-TIP-ENDO     PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0ENDO_TIP_ENDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77          V0ENDS-NUM-APOL     PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0ENDS_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0ENDS-NRENDOS      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ENDS_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0ENDS-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ENDS_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0ENDS-CODSUBES     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ENDS_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0ENDS-DTEMIS       PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0ENDS_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0ENDS-DTINIVIG     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0ENDS_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0ENDS-DTTERVIG     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0ENDS_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0ENDS-TIP-ENDS     PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0ENDS_TIP_ENDS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01         AREA-DE-WORK.*/
        public RE0001S_AREA_DE_WORK AREA_DE_WORK { get; set; } = new RE0001S_AREA_DE_WORK();
        public class RE0001S_AREA_DE_WORK : VarBasis
        {
            /*"  05       WPCT-CED             PIC  9(004)V9(9) VALUE ZEROS.*/
            public DoubleBasis WPCT_CED { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05       WPCT-LIDER           PIC  9(004)V9(9) VALUE ZEROS.*/
            public DoubleBasis WPCT_LIDER { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05       WPCT-RAMOFR-IS       PIC S9(007)V9(9) VALUE +0 COMP-3*/
            public DoubleBasis WPCT_RAMOFR_IS { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V9(9)"), 9);
            /*"  05       WPCT-RAMOFR-PR       PIC S9(007)V9(9) VALUE +0 COMP-3*/
            public DoubleBasis WPCT_RAMOFR_PR { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V9(9)"), 9);
            /*"  05       WS-IS-LIDER          PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WS_IS_LIDER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WPRM-LIDR            PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WPRM_LIDR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WPRM-BASE            PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WPRM_BASE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WPRM-TAR-C           PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WPRM_TAR_C { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WPRM-TAR-L           PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WPRM_TAR_L { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WVLR-COMPL           PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WVLR_COMPL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WVLR-COMPL-I         PIC S9(010)V9(5) VALUE +0 COMP-3*/
            public DoubleBasis WVLR_COMPL_I { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05       WPCTRSP-IS           PIC  9(004)V9(9) VALUE ZEROS.*/
            public DoubleBasis WPCTRSP_IS { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05       WPCTRSP-PR           PIC  9(004)V9(9) VALUE ZEROS.*/
            public DoubleBasis WPCTRSP_PR { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05       WPCTCOT              PIC  9(004)V9(9) VALUE ZEROS.*/
            public DoubleBasis WPCTCOT { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05       WPCTCTF              PIC  9(004)V9(9) VALUE ZEROS.*/
            public DoubleBasis WPCTCTF { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05       WPCTDNO              PIC  9(004)V9(9) VALUE ZEROS.*/
            public DoubleBasis WPCTDNO { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05       WPCTCOMCO            PIC  9(004)V9(9) VALUE ZEROS.*/
            public DoubleBasis WPCTCOMCO { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05       WPCTCOMER            PIC  9(004)V9(9) VALUE ZEROS.*/
            public DoubleBasis WPCTCOMER { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05       WPRERSP              PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WPRERSP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WPRECOT              PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WPRECOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WPRECTF              PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WPRECTF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WPREDNO              PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WPREDNO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WCOMCOT              PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WCOMCOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WS-MENSG-0.*/
            public RE0001S_WS_MENSG_0 WS_MENSG_0 { get; set; } = new RE0001S_WS_MENSG_0();
            public class RE0001S_WS_MENSG_0 : VarBasis
            {
                /*"    10     FILLER               PIC  X(008)   VALUE 'RE0002S-'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"RE0002S-");
                /*"    10     WS-MENSG-1           PIC  X(040).*/
                public StringBasis WS_MENSG_1 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10     FILLER               PIC  X(007)   VALUE ' RET = '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @" RET = ");
                /*"    10     WS-MENSG-2           PIC  9(004).*/
                public IntBasis WS_MENSG_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"01         LK-GE0005S.*/
            }
        }
        public RE0001S_LK_GE0005S LK_GE0005S { get; set; } = new RE0001S_LK_GE0005S();
        public class RE0001S_LK_GE0005S : VarBasis
        {
            /*"  05       LKGE05-COD-RAMO      PIC  9(004)      VALUE ZEROS.*/
            public IntBasis LKGE05_COD_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05       LKGE05-COD-MODL      PIC  9(004)      VALUE ZEROS.*/
            public IntBasis LKGE05_COD_MODL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05       LKGE05-COD-PROD      PIC  9(004)      VALUE ZEROS.*/
            public IntBasis LKGE05_COD_PROD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05       LKGE05-INI-VIGC      PIC  X(010)      VALUE ZEROS.*/
            public StringBasis LKGE05_INI_VIGC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05       LKGE05-GRP-SUSEP     PIC  9(004)      VALUE ZEROS.*/
            public IntBasis LKGE05_GRP_SUSEP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05       LKGE05-RMO-SUSEP     PIC  9(004)      VALUE ZEROS.*/
            public IntBasis LKGE05_RMO_SUSEP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05       LKGE05-SQL-CODE      PIC  ---9.*/
            public IntBasis LKGE05_SQL_CODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
            /*"  05       LKGE05-MENSAGEM      PIC  X(070)      VALUE SPACES.*/
            public StringBasis LKGE05_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            /*"01         LK-RE0002S.*/
        }
        public RE0001S_LK_RE0002S LK_RE0002S { get; set; } = new RE0001S_LK_RE0002S();
        public class RE0001S_LK_RE0002S : VarBasis
        {
            /*"  05       LKRE02-ENTRADA.*/
            public RE0001S_LKRE02_ENTRADA LKRE02_ENTRADA { get; set; } = new RE0001S_LKRE02_ENTRADA();
            public class RE0001S_LKRE02_ENTRADA : VarBasis
            {
                /*"    10     LKRE02-NUM-APOL      PIC S9(013)      COMP-3.*/
                public IntBasis LKRE02_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                /*"    10     LKRE02-NUM-ENDS      PIC S9(009)      COMP.*/
                public IntBasis LKRE02_NUM_ENDS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    10     LKRE02-COD-PROD      PIC S9(004)      COMP.*/
                public IntBasis LKRE02_COD_PROD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10     LKRE02-COD-SUBG      PIC S9(004)      COMP.*/
                public IntBasis LKRE02_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10     LKRE02-DTEMS-AP      PIC  X(010).*/
                public StringBasis LKRE02_DTEMS_AP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10     LKRE02-DTINIVIG      PIC  X(010).*/
                public StringBasis LKRE02_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10     LKRE02-DTTERVIG      PIC  X(010).*/
                public StringBasis LKRE02_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10     LKRE02-TIP-ENDS      PIC  X(001).*/
                public StringBasis LKRE02_TIP_ENDS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10     LKRE02-RAMO-CBT      PIC S9(004)      COMP.*/
                public IntBasis LKRE02_RAMO_CBT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10     LKRE02-MODL-CBT      PIC S9(004)      COMP.*/
                public IntBasis LKRE02_MODL_CBT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10     LKRE02-NUM-VERS      PIC S9(004)      COMP.*/
                public IntBasis LKRE02_NUM_VERS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10     LKRE02-NUM-ITEM      PIC S9(004)      COMP.*/
                public IntBasis LKRE02_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05       LKRE02-SAIDA.*/
            }
            public RE0001S_LKRE02_SAIDA LKRE02_SAIDA { get; set; } = new RE0001S_LKRE02_SAIDA();
            public class RE0001S_LKRE02_SAIDA : VarBasis
            {
                /*"    10     LKRE02-IMP-SEGR      PIC S9(013)V9(2) COMP-3.*/
                public DoubleBasis LKRE02_IMP_SEGR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                /*"    10     LKRE02-PRM-TARF      PIC S9(013)V9(2) COMP-3.*/
                public DoubleBasis LKRE02_PRM_TARF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                /*"    10     LKRE02-VLDESCTO      PIC S9(013)V9(2) COMP-3.*/
                public DoubleBasis LKRE02_VLDESCTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                /*"    10     LKRE02-PCT-CORR      PIC S9(005)V9(7) COMP-3.*/
                public DoubleBasis LKRE02_PCT_CORR { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(7)"), 7);
                /*"    10     LKRE02-PCT-COSC      PIC S9(004)V9(5) COMP-3.*/
                public DoubleBasis LKRE02_PCT_COSC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
                /*"    10     LKRE02-PRM-LIDR      PIC S9(013)V9(2) COMP-3.*/
                public DoubleBasis LKRE02_PRM_LIDR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                /*"    10     LKRE02-ADC-FRAC      PIC S9(013)V9(2) COMP-3.*/
                public DoubleBasis LKRE02_ADC_FRAC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                /*"    10     LKRE02-COD-RETN      PIC S9(004)      COMP.*/
                public IntBasis LKRE02_COD_RETN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10     LKRE02-MENSAGEM      PIC  X(070)      VALUE SPACES.*/
                public StringBasis LKRE02_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01         LK-RE0001S.*/
            }
        }
        public RE0001S_LK_RE0001S LK_RE0001S { get; set; } = new RE0001S_LK_RE0001S();
        public class RE0001S_LK_RE0001S : VarBasis
        {
            /*"  05       LKRE01-TIP-CALC      PIC  9(001).*/
            public IntBasis LKRE01_TIP_CALC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05       LKRE01-NUM-APOL      PIC  9(013).*/
            public IntBasis LKRE01_NUM_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       LKRE01-NRENDOS       PIC  9(009).*/
            public IntBasis LKRE01_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       LKRE01-DTINIVIG      PIC  X(010).*/
            public StringBasis LKRE01_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       LKRE01-PCTCED        PIC  9(004)V9(9).*/
            public DoubleBasis LKRE01_PCTCED { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)."), 9);
            /*"  05       LKRE01-RAMOFR        PIC  9(004).*/
            public IntBasis LKRE01_RAMOFR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       LKRE01-MODALIFR      PIC  9(004).*/
            public IntBasis LKRE01_MODALIFR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       LKRE01-PCTRSP-PR     PIC  9(004)V9(9).*/
            public DoubleBasis LKRE01_PCTRSP_PR { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)."), 9);
            /*"  05       LKRE01-PCTRSP-IS     PIC  9(004)V9(9).*/
            public DoubleBasis LKRE01_PCTRSP_IS { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)."), 9);
            /*"  05       LKRE01-PCTCOT        PIC  9(004)V9(9).*/
            public DoubleBasis LKRE01_PCTCOT { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)."), 9);
            /*"  05       LKRE01-PCTCTF        PIC  9(004)V9(9).*/
            public DoubleBasis LKRE01_PCTCTF { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)."), 9);
            /*"  05       LKRE01-PCTDNO        PIC  9(004)V9(9).*/
            public DoubleBasis LKRE01_PCTDNO { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)."), 9);
            /*"  05       LKRE01-PCTCOMCO      PIC  9(004)V9(9).*/
            public DoubleBasis LKRE01_PCTCOMCO { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)."), 9);
            /*"  05       LKRE01-PCTCOMRS      PIC  9(004)V9(9).*/
            public DoubleBasis LKRE01_PCTCOMRS { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)."), 9);
            /*"  05       LKRE01-DTCUTOFF      PIC  X(010).*/
            public StringBasis LKRE01_DTCUTOFF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       LKRE01-RECP-PSL      PIC  X(001).*/
            public StringBasis LKRE01_RECP_PSL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       LKRE01-CONTR-RE      PIC  X(025).*/
            public StringBasis LKRE01_CONTR_RE { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"  05       LKRE01-SQL-CODE      PIC  9(009).*/
            public IntBasis LKRE01_SQL_CODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       LKRE01-RTN-CODE      PIC  9(002).*/
            public IntBasis LKRE01_RTN_CODE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05       LKRE01-MENSAGEM      PIC  X(040).*/
            public StringBasis LKRE01_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(RE0001S_LK_RE0001S RE0001S_LK_RE0001S_P) //PROCEDURE DIVISION USING 
        /*LK_RE0001S*/
        {
            try
            {
                this.LK_RE0001S = RE0001S_LK_RE0001S_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_RE0001S };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -345- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -348- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -351- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -359- MOVE ZEROS TO WPCT-CED WPCT-LIDER WPCT-RAMOFR-IS WPCT-RAMOFR-PR MOVHBT-PRM-CRED. */
            _.Move(0, AREA_DE_WORK.WPCT_CED, AREA_DE_WORK.WPCT_LIDER, AREA_DE_WORK.WPCT_RAMOFR_IS, AREA_DE_WORK.WPCT_RAMOFR_PR, MOVHBT_PRM_CRED);

            /*" -362- MOVE ZEROS TO WS-IS-LIDER WHOST-IMPSEG-ER. */
            _.Move(0, AREA_DE_WORK.WS_IS_LIDER, WHOST_IMPSEG_ER);

            /*" -369- MOVE ZEROS TO WPRM-LIDR WPRM-BASE WPRM-TAR-C WPRM-TAR-L WVLR-COMPL WVLR-COMPL-I. */
            _.Move(0, AREA_DE_WORK.WPRM_LIDR, AREA_DE_WORK.WPRM_BASE, AREA_DE_WORK.WPRM_TAR_C, AREA_DE_WORK.WPRM_TAR_L, AREA_DE_WORK.WVLR_COMPL, AREA_DE_WORK.WVLR_COMPL_I);

            /*" -375- MOVE ZEROS TO WPRERSP WPRECOT WPRECTF WPREDNO WCOMCOT. */
            _.Move(0, AREA_DE_WORK.WPRERSP, AREA_DE_WORK.WPRECOT, AREA_DE_WORK.WPRECTF, AREA_DE_WORK.WPREDNO, AREA_DE_WORK.WCOMCOT);

            /*" -383- MOVE ZEROS TO WPCTRSP-IS WPCTRSP-PR WPCTCOT WPCTCTF WPCTDNO WPCTCOMCO WPCTCOMER. */
            _.Move(0, AREA_DE_WORK.WPCTRSP_IS, AREA_DE_WORK.WPCTRSP_PR, AREA_DE_WORK.WPCTCOT, AREA_DE_WORK.WPCTCTF, AREA_DE_WORK.WPCTDNO, AREA_DE_WORK.WPCTCOMCO, AREA_DE_WORK.WPCTCOMER);

            /*" -393- MOVE ZEROS TO LKRE01-PCTRSP-IS LKRE01-PCTRSP-PR LKRE01-PCTCOT LKRE01-PCTCTF LKRE01-PCTDNO LKRE01-PCTCOMCO LKRE01-PCTCOMRS LKRE01-SQL-CODE LKRE01-RTN-CODE. */
            _.Move(0, LK_RE0001S.LKRE01_PCTRSP_IS, LK_RE0001S.LKRE01_PCTRSP_PR, LK_RE0001S.LKRE01_PCTCOT, LK_RE0001S.LKRE01_PCTCTF, LK_RE0001S.LKRE01_PCTDNO, LK_RE0001S.LKRE01_PCTCOMCO, LK_RE0001S.LKRE01_PCTCOMRS, LK_RE0001S.LKRE01_SQL_CODE, LK_RE0001S.LKRE01_RTN_CODE);

            /*" -398- MOVE SPACES TO LKRE01-DTCUTOFF LKRE01-RECP-PSL LKRE01-CONTR-RE LKRE01-MENSAGEM. */
            _.Move("", LK_RE0001S.LKRE01_DTCUTOFF, LK_RE0001S.LKRE01_RECP_PSL, LK_RE0001S.LKRE01_CONTR_RE, LK_RE0001S.LKRE01_MENSAGEM);

            /*" -407- IF (LKRE01-TIP-CALC NOT NUMERIC) OR (LKRE01-NUM-APOL NOT NUMERIC) OR (LKRE01-NRENDOS NOT NUMERIC) OR (LKRE01-PCTCED NOT NUMERIC) OR (LKRE01-RAMOFR NOT NUMERIC) OR (LKRE01-MODALIFR NOT NUMERIC) OR (LKRE01-NUM-APOL EQUAL ZEROS) OR (LKRE01-RAMOFR EQUAL ZEROS) OR (LKRE01-DTINIVIG EQUAL SPACES) */

            if ((!LK_RE0001S.LKRE01_TIP_CALC.IsNumeric()) || (!LK_RE0001S.LKRE01_NUM_APOL.IsNumeric()) || (!LK_RE0001S.LKRE01_NRENDOS.IsNumeric()) || (!LK_RE0001S.LKRE01_PCTCED.IsNumeric()) || (!LK_RE0001S.LKRE01_RAMOFR.IsNumeric()) || (!LK_RE0001S.LKRE01_MODALIFR.IsNumeric()) || (LK_RE0001S.LKRE01_NUM_APOL == 00) || (LK_RE0001S.LKRE01_RAMOFR == 00) || (LK_RE0001S.LKRE01_DTINIVIG.IsEmpty()))
            {

                /*" -408- MOVE 'RE0001S - DADOS INVALIDOS' TO LKRE01-MENSAGEM */
                _.Move("RE0001S - DADOS INVALIDOS", LK_RE0001S.LKRE01_MENSAGEM);

                /*" -409- MOVE 99 TO LKRE01-RTN-CODE */
                _.Move(99, LK_RE0001S.LKRE01_RTN_CODE);

                /*" -410- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -412- END-IF. */
            }


            /*" -414- IF LKRE01-TIP-CALC = 1 OR 2 NEXT SENTENCE */

            if (LK_RE0001S.LKRE01_TIP_CALC.In("1", "2"))
            {

                /*" -415- ELSE */
            }
            else
            {


                /*" -416- MOVE 'RE0001S - TIP-CALC INVALIDO' TO LKRE01-MENSAGEM */
                _.Move("RE0001S - TIP-CALC INVALIDO", LK_RE0001S.LKRE01_MENSAGEM);

                /*" -417- MOVE 99 TO LKRE01-RTN-CODE */
                _.Move(99, LK_RE0001S.LKRE01_RTN_CODE);

                /*" -418- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -420- END-IF. */
            }


            /*" -421- MOVE LKRE01-NUM-APOL TO WHOST-NUM-APOL. */
            _.Move(LK_RE0001S.LKRE01_NUM_APOL, WHOST_NUM_APOL);

            /*" -422- MOVE LKRE01-NRENDOS TO WHOST-NRENDOS. */
            _.Move(LK_RE0001S.LKRE01_NRENDOS, WHOST_NRENDOS);

            /*" -423- MOVE LKRE01-RAMOFR TO WHOST-RAMOFR. */
            _.Move(LK_RE0001S.LKRE01_RAMOFR, WHOST_RAMOFR);

            /*" -424- MOVE LKRE01-MODALIFR TO WHOST-MODALIFR. */
            _.Move(LK_RE0001S.LKRE01_MODALIFR, WHOST_MODALIFR);

            /*" -426- MOVE LKRE01-DTINIVIG TO WHOST-DTINIVIG. */
            _.Move(LK_RE0001S.LKRE01_DTINIVIG, WHOST_DTINIVIG);

            /*" -430- MOVE LKRE01-PCTCED TO WPCT-CED. */
            _.Move(LK_RE0001S.LKRE01_PCTCED, AREA_DE_WORK.WPCT_CED);

            /*" -434- PERFORM R0200-00-SELECT-V0HISTOPARC. */

            R0200_00_SELECT_V0HISTOPARC_SECTION();

            /*" -436- PERFORM R0300-00-SELECT-V0COBERAPOL-T. */

            R0300_00_SELECT_V0COBERAPOL_T_SECTION();

            /*" -440- PERFORM R0400-00-SELECT-V0COBERAPOL-R. */

            R0400_00_SELECT_V0COBERAPOL_R_SECTION();

            /*" -444- PERFORM R0500-00-SELECT-V0HISTORES. */

            R0500_00_SELECT_V0HISTORES_SECTION();

            /*" -448- PERFORM R0600-00-SELECT-V0DADOSRES. */

            R0600_00_SELECT_V0DADOSRES_SECTION();

            /*" -449- IF WHOST-RAMOFR = 66 */

            if (WHOST_RAMOFR == 66)
            {

                /*" -451- MOVE ZEROS TO MOVHBT-PRM-CRED */
                _.Move(0, MOVHBT_PRM_CRED);

                /*" -455- END-IF. */
            }


            /*" -456- IF WHOST-RAMOFR = 16 OR 18 */

            if (WHOST_RAMOFR.In("16", "18"))
            {

                /*" -457- PERFORM R0800-00-SELECT-V0PARC-COMPL */

                R0800_00_SELECT_V0PARC_COMPL_SECTION();

                /*" -458- ELSE */
            }
            else
            {


                /*" -459- MOVE ZEROS TO V0PCMP-VLR-COMPL */
                _.Move(0, V0PCMP_VLR_COMPL);

                /*" -460- MOVE ZEROS TO V0PCMP-VLR-COMPL-I */
                _.Move(0, V0PCMP_VLR_COMPL_I);

                /*" -464- END-IF. */
            }


            /*" -468- PERFORM R0900-00-SELECT-V0ENDOSSO. */

            R0900_00_SELECT_V0ENDOSSO_SECTION();

            /*" -470- PERFORM R1000-00-CALCULA-RESSEGURO. */

            R1000_00_CALCULA_RESSEGURO_SECTION();

            /*" -470- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-V0HISTOPARC-SECTION */
        private void R0200_00_SELECT_V0HISTOPARC_SECTION()
        {
            /*" -490- PERFORM R0200_00_SELECT_V0HISTOPARC_DB_SELECT_1 */

            R0200_00_SELECT_V0HISTOPARC_DB_SELECT_1();

            /*" -493- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -494- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -495- MOVE ZEROS TO V0HISP-PRM-TAR */
                    _.Move(0, V0HISP_PRM_TAR);

                    /*" -496- ELSE */
                }
                else
                {


                    /*" -498- MOVE 'R0200 - ERRO NO SELECT DA V0HISTOPARC' TO LKRE01-MENSAGEM */
                    _.Move("R0200 - ERRO NO SELECT DA V0HISTOPARC", LK_RE0001S.LKRE01_MENSAGEM);

                    /*" -499- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -500- END-IF */
                }


                /*" -500- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-SELECT-V0HISTOPARC-DB-SELECT-1 */
        public void R0200_00_SELECT_V0HISTOPARC_DB_SELECT_1()
        {
            /*" -490- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO),+0) INTO :V0HISP-PRM-TAR FROM SEGUROS.V0HISTOPARC WHERE NUM_APOLICE = :WHOST-NUM-APOL AND NRENDOS = :WHOST-NRENDOS AND OCORHIST = 01 AND OPERACAO < 0200 WITH UR END-EXEC. */

            var r0200_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1 = new R0200_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1()
            {
                WHOST_NUM_APOL = WHOST_NUM_APOL.ToString(),
                WHOST_NRENDOS = WHOST_NRENDOS.ToString(),
            };

            var executed_1 = R0200_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HISP_PRM_TAR, V0HISP_PRM_TAR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-SELECT-V0COBERAPOL-T-SECTION */
        private void R0300_00_SELECT_V0COBERAPOL_T_SECTION()
        {
            /*" -522- PERFORM R0300_00_SELECT_V0COBERAPOL_T_DB_SELECT_1 */

            R0300_00_SELECT_V0COBERAPOL_T_DB_SELECT_1();

            /*" -525- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -526- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -527- MOVE ZEROS TO V0COBA-IMP-IX-T */
                    _.Move(0, V0COBA_IMP_IX_T);

                    /*" -528- MOVE ZEROS TO V0COBA-PRM-VAR-T */
                    _.Move(0, V0COBA_PRM_VAR_T);

                    /*" -529- ELSE */
                }
                else
                {


                    /*" -531- MOVE 'R0300 - ERRO NO SELECT DA V0COBERAPOL' TO LKRE01-MENSAGEM */
                    _.Move("R0300 - ERRO NO SELECT DA V0COBERAPOL", LK_RE0001S.LKRE01_MENSAGEM);

                    /*" -532- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -533- END-IF */
                }


                /*" -533- END-IF. */
            }


        }

        [StopWatch]
        /*" R0300-00-SELECT-V0COBERAPOL-T-DB-SELECT-1 */
        public void R0300_00_SELECT_V0COBERAPOL_T_DB_SELECT_1()
        {
            /*" -522- EXEC SQL SELECT VALUE(SUM(IMP_SEGURADA_IX),+0), VALUE(SUM(PRM_TARIFARIO_VAR),+0) INTO :V0COBA-IMP-IX-T, :V0COBA-PRM-VAR-T FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :WHOST-NUM-APOL AND NRENDOS = :WHOST-NRENDOS AND NUM_ITEM = 0 AND COD_COBERTURA = 0 WITH UR END-EXEC. */

            var r0300_00_SELECT_V0COBERAPOL_T_DB_SELECT_1_Query1 = new R0300_00_SELECT_V0COBERAPOL_T_DB_SELECT_1_Query1()
            {
                WHOST_NUM_APOL = WHOST_NUM_APOL.ToString(),
                WHOST_NRENDOS = WHOST_NRENDOS.ToString(),
            };

            var executed_1 = R0300_00_SELECT_V0COBERAPOL_T_DB_SELECT_1_Query1.Execute(r0300_00_SELECT_V0COBERAPOL_T_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMP_IX_T, V0COBA_IMP_IX_T);
                _.Move(executed_1.V0COBA_PRM_VAR_T, V0COBA_PRM_VAR_T);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-SELECT-V0COBERAPOL-R-SECTION */
        private void R0400_00_SELECT_V0COBERAPOL_R_SECTION()
        {
            /*" -556- PERFORM R0400_00_SELECT_V0COBERAPOL_R_DB_SELECT_1 */

            R0400_00_SELECT_V0COBERAPOL_R_DB_SELECT_1();

            /*" -559- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -560- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -561- MOVE ZEROS TO V0COBA-IMP-IX-R */
                    _.Move(0, V0COBA_IMP_IX_R);

                    /*" -562- MOVE ZEROS TO V0COBA-PRM-VAR-R */
                    _.Move(0, V0COBA_PRM_VAR_R);

                    /*" -563- ELSE */
                }
                else
                {


                    /*" -565- MOVE 'R0400 - ERRO NO SELECT DA V0COBERAPOL' TO LKRE01-MENSAGEM */
                    _.Move("R0400 - ERRO NO SELECT DA V0COBERAPOL", LK_RE0001S.LKRE01_MENSAGEM);

                    /*" -566- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -567- END-IF */
                }


                /*" -569- END-IF. */
            }


            /*" -571- IF V0COBA-IMP-IX-T = ZEROS OR V0COBA-IMP-IX-R = ZEROS */

            if (V0COBA_IMP_IX_T == 00 || V0COBA_IMP_IX_R == 00)
            {

                /*" -572- MOVE ZEROS TO WPCT-RAMOFR-IS */
                _.Move(0, AREA_DE_WORK.WPCT_RAMOFR_IS);

                /*" -573- ELSE */
            }
            else
            {


                /*" -577- COMPUTE WPCT-RAMOFR-IS ROUNDED = V0COBA-IMP-IX-R / V0COBA-IMP-IX-T * 100 ON SIZE ERROR MOVE ZEROS TO WPCT-RAMOFR-IS END-COMPUTE */
                if (V0COBA_IMP_IX_T.Value == 0)
                    _.Move(0, AREA_DE_WORK.WPCT_RAMOFR_IS);
                else

                    AREA_DE_WORK.WPCT_RAMOFR_IS.Value = V0COBA_IMP_IX_R / V0COBA_IMP_IX_T * 100;

                /*" -579- END-IF. */
            }


            /*" -581- IF V0COBA-PRM-VAR-T = ZEROS OR V0COBA-PRM-VAR-R = ZEROS */

            if (V0COBA_PRM_VAR_T == 00 || V0COBA_PRM_VAR_R == 00)
            {

                /*" -582- MOVE ZEROS TO WPCT-RAMOFR-PR */
                _.Move(0, AREA_DE_WORK.WPCT_RAMOFR_PR);

                /*" -583- ELSE */
            }
            else
            {


                /*" -587- COMPUTE WPCT-RAMOFR-PR ROUNDED = V0COBA-PRM-VAR-R / V0COBA-PRM-VAR-T * 100 ON SIZE ERROR MOVE ZEROS TO WPCT-RAMOFR-PR END-COMPUTE */
                if (V0COBA_PRM_VAR_T.Value == 0)
                    _.Move(0, AREA_DE_WORK.WPCT_RAMOFR_PR);
                else

                    AREA_DE_WORK.WPCT_RAMOFR_PR.Value = V0COBA_PRM_VAR_R / V0COBA_PRM_VAR_T * 100;

                /*" -587- END-IF. */
            }


        }

        [StopWatch]
        /*" R0400-00-SELECT-V0COBERAPOL-R-DB-SELECT-1 */
        public void R0400_00_SELECT_V0COBERAPOL_R_DB_SELECT_1()
        {
            /*" -556- EXEC SQL SELECT VALUE(SUM(IMP_SEGURADA_IX),+0), VALUE(SUM(PRM_TARIFARIO_VAR),+0) INTO :V0COBA-IMP-IX-R, :V0COBA-PRM-VAR-R FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :WHOST-NUM-APOL AND NRENDOS = :WHOST-NRENDOS AND NUM_ITEM = 0 AND RAMOFR = :WHOST-RAMOFR AND COD_COBERTURA = 0 WITH UR END-EXEC. */

            var r0400_00_SELECT_V0COBERAPOL_R_DB_SELECT_1_Query1 = new R0400_00_SELECT_V0COBERAPOL_R_DB_SELECT_1_Query1()
            {
                WHOST_NUM_APOL = WHOST_NUM_APOL.ToString(),
                WHOST_NRENDOS = WHOST_NRENDOS.ToString(),
                WHOST_RAMOFR = WHOST_RAMOFR.ToString(),
            };

            var executed_1 = R0400_00_SELECT_V0COBERAPOL_R_DB_SELECT_1_Query1.Execute(r0400_00_SELECT_V0COBERAPOL_R_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMP_IX_R, V0COBA_IMP_IX_R);
                _.Move(executed_1.V0COBA_PRM_VAR_R, V0COBA_PRM_VAR_R);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-SELECT-V0HISTORES-SECTION */
        private void R0500_00_SELECT_V0HISTORES_SECTION()
        {
            /*" -614- PERFORM R0500_00_SELECT_V0HISTORES_DB_SELECT_1 */

            R0500_00_SELECT_V0HISTORES_DB_SELECT_1();

            /*" -617- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -618- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -619- MOVE ZEROS TO V0HISR-PRERSP */
                    _.Move(0, V0HISR_PRERSP);

                    /*" -620- MOVE ZEROS TO V0HISR-COMRSP */
                    _.Move(0, V0HISR_COMRSP);

                    /*" -621- MOVE ZEROS TO V0HISR-VLSEGURO */
                    _.Move(0, V0HISR_VLSEGURO);

                    /*" -622- MOVE ZEROS TO WHOST-IMPSEG-ER */
                    _.Move(0, WHOST_IMPSEG_ER);

                    /*" -623- ELSE */
                }
                else
                {


                    /*" -625- MOVE 'R0500 - ERRO NO SELECT DA V0HISTORES' TO LKRE01-MENSAGEM */
                    _.Move("R0500 - ERRO NO SELECT DA V0HISTORES", LK_RE0001S.LKRE01_MENSAGEM);

                    /*" -626- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -627- END-IF */
                }


                /*" -627- END-IF. */
            }


        }

        [StopWatch]
        /*" R0500-00-SELECT-V0HISTORES-DB-SELECT-1 */
        public void R0500_00_SELECT_V0HISTORES_DB_SELECT_1()
        {
            /*" -614- EXEC SQL SELECT VALUE(SUM(PRERSP),+0), VALUE(SUM(COMRSP),+0), DECIMAL(VALUE(SUM(ROUND((VLSEGURO * PCTRSP/100),2)),+0),15,2) INTO :V0HISR-PRERSP, :V0HISR-COMRSP, :WHOST-IMPSEG-ER FROM SEGUROS.V0HISTORES WHERE NUM_APOLICE = :WHOST-NUM-APOL AND NRENDOS = :WHOST-NRENDOS AND RAMOFR = :WHOST-RAMOFR AND OPERACAO IN (0101,0102) AND SITUACAO <> '2' WITH UR END-EXEC. */

            var r0500_00_SELECT_V0HISTORES_DB_SELECT_1_Query1 = new R0500_00_SELECT_V0HISTORES_DB_SELECT_1_Query1()
            {
                WHOST_NUM_APOL = WHOST_NUM_APOL.ToString(),
                WHOST_NRENDOS = WHOST_NRENDOS.ToString(),
                WHOST_RAMOFR = WHOST_RAMOFR.ToString(),
            };

            var executed_1 = R0500_00_SELECT_V0HISTORES_DB_SELECT_1_Query1.Execute(r0500_00_SELECT_V0HISTORES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HISR_PRERSP, V0HISR_PRERSP);
                _.Move(executed_1.V0HISR_COMRSP, V0HISR_COMRSP);
                _.Move(executed_1.WHOST_IMPSEG_ER, WHOST_IMPSEG_ER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-SELECT-V0DADOSRES-SECTION */
        private void R0600_00_SELECT_V0DADOSRES_SECTION()
        {
            /*" -659- PERFORM R0600_00_SELECT_V0DADOSRES_DB_SELECT_1 */

            R0600_00_SELECT_V0DADOSRES_DB_SELECT_1();

            /*" -662- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -664- MOVE 'R0600 - ERRO NO SELECT DA V0DADOSRES' TO LKRE01-MENSAGEM */
                _.Move("R0600 - ERRO NO SELECT DA V0DADOSRES", LK_RE0001S.LKRE01_MENSAGEM);

                /*" -665- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -666- ELSE */
            }
            else
            {


                /*" -667- IF VIND-DTCUTOFF < ZEROS */

                if (VIND_DTCUTOFF < 00)
                {

                    /*" -668- MOVE SPACES TO V0DRES-DTCUTOFF */
                    _.Move("", V0DRES_DTCUTOFF);

                    /*" -669- END-IF */
                }


                /*" -670- IF VIND-CONTR-RE < ZEROS */

                if (VIND_CONTR_RE < 00)
                {

                    /*" -671- MOVE SPACES TO V0DRES-CONTR-RESG */
                    _.Move("", V0DRES_CONTR_RESG);

                    /*" -672- END-IF */
                }


                /*" -672- END-IF. */
            }


        }

        [StopWatch]
        /*" R0600-00-SELECT-V0DADOSRES-DB-SELECT-1 */
        public void R0600_00_SELECT_V0DADOSRES_DB_SELECT_1()
        {
            /*" -659- EXEC SQL SELECT PCTCOT, PCTCTF, PCTDNO, PCTCOMCO, DTCUTOFF, RECUP_PSL, COD_CONTRATO_RE INTO :V0DRES-PCTCOT, :V0DRES-PCTCTF, :V0DRES-PCTDNO, :V0DRES-PCTCOMCO, :V0DRES-DTCUTOFF:VIND-DTCUTOFF, :V0DRES-RECUP-PSL, :V0DRES-CONTR-RESG:VIND-CONTR-RE FROM SEGUROS.V0DADOSRES WHERE RAMO = :WHOST-RAMOFR AND MODALIDA = :WHOST-MODALIFR AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG WITH UR END-EXEC. */

            var r0600_00_SELECT_V0DADOSRES_DB_SELECT_1_Query1 = new R0600_00_SELECT_V0DADOSRES_DB_SELECT_1_Query1()
            {
                WHOST_MODALIFR = WHOST_MODALIFR.ToString(),
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
                WHOST_RAMOFR = WHOST_RAMOFR.ToString(),
            };

            var executed_1 = R0600_00_SELECT_V0DADOSRES_DB_SELECT_1_Query1.Execute(r0600_00_SELECT_V0DADOSRES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0DRES_PCTCOT, V0DRES_PCTCOT);
                _.Move(executed_1.V0DRES_PCTCTF, V0DRES_PCTCTF);
                _.Move(executed_1.V0DRES_PCTDNO, V0DRES_PCTDNO);
                _.Move(executed_1.V0DRES_PCTCOMCO, V0DRES_PCTCOMCO);
                _.Move(executed_1.V0DRES_DTCUTOFF, V0DRES_DTCUTOFF);
                _.Move(executed_1.VIND_DTCUTOFF, VIND_DTCUTOFF);
                _.Move(executed_1.V0DRES_RECUP_PSL, V0DRES_RECUP_PSL);
                _.Move(executed_1.V0DRES_CONTR_RESG, V0DRES_CONTR_RESG);
                _.Move(executed_1.VIND_CONTR_RE, VIND_CONTR_RE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-SELECT-V0PARC-COMPL-SECTION */
        private void R0800_00_SELECT_V0PARC_COMPL_SECTION()
        {
            /*" -724- PERFORM R0800_00_SELECT_V0PARC_COMPL_DB_SELECT_1 */

            R0800_00_SELECT_V0PARC_COMPL_DB_SELECT_1();

            /*" -727- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -728- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -729- MOVE ZEROS TO V0PCMP-VLR-COMPL */
                    _.Move(0, V0PCMP_VLR_COMPL);

                    /*" -730- MOVE ZEROS TO V0PCMP-VLR-COMPL-I */
                    _.Move(0, V0PCMP_VLR_COMPL_I);

                    /*" -731- ELSE */
                }
                else
                {


                    /*" -733- MOVE 'R0800 - ERRO NO SELECT DA PARCELA-COMPL' TO LKRE01-MENSAGEM */
                    _.Move("R0800 - ERRO NO SELECT DA PARCELA-COMPL", LK_RE0001S.LKRE01_MENSAGEM);

                    /*" -734- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -735- END-IF */
                }


                /*" -735- END-IF. */
            }


        }

        [StopWatch]
        /*" R0800-00-SELECT-V0PARC-COMPL-DB-SELECT-1 */
        public void R0800_00_SELECT_V0PARC_COMPL_DB_SELECT_1()
        {
            /*" -724- EXEC SQL SELECT VALUE(SUM(VLR_COMPLEMENTO),+0), VALUE(SUM(VLR_COMPLEMENT_IX),+0) INTO :V0PCMP-VLR-COMPL, :V0PCMP-VLR-COMPL-I FROM SEGUROS.V0PARCELA_COMPL WHERE NUM_APOLICE = :WHOST-NUM-APOL AND NRENDOS = :WHOST-NRENDOS WITH UR END-EXEC. */

            var r0800_00_SELECT_V0PARC_COMPL_DB_SELECT_1_Query1 = new R0800_00_SELECT_V0PARC_COMPL_DB_SELECT_1_Query1()
            {
                WHOST_NUM_APOL = WHOST_NUM_APOL.ToString(),
                WHOST_NRENDOS = WHOST_NRENDOS.ToString(),
            };

            var executed_1 = R0800_00_SELECT_V0PARC_COMPL_DB_SELECT_1_Query1.Execute(r0800_00_SELECT_V0PARC_COMPL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PCMP_VLR_COMPL, V0PCMP_VLR_COMPL);
                _.Move(executed_1.V0PCMP_VLR_COMPL_I, V0PCMP_VLR_COMPL_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-SELECT-V0ENDOSSO-SECTION */
        private void R0900_00_SELECT_V0ENDOSSO_SECTION()
        {
            /*" -767- PERFORM R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1 */

            R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1();

            /*" -770- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -772- MOVE 'R0900 - ERRO NO SELECT DA V0ENDOSSO' TO LKRE01-MENSAGEM */
                _.Move("R0900 - ERRO NO SELECT DA V0ENDOSSO", LK_RE0001S.LKRE01_MENSAGEM);

                /*" -773- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -773- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-SELECT-V0ENDOSSO-DB-SELECT-1 */
        public void R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1()
        {
            /*" -767- EXEC SQL SELECT NUM_APOLICE, NRENDOS, CODPRODU, CODSUBES, DTEMIS, DTINIVIG, DTTERVIG, TIPO_ENDOSSO INTO :V0ENDO-NUM-APOL, :V0ENDO-NRENDOS, :V0ENDO-CODPRODU, :V0ENDO-CODSUBES, :V0ENDO-DTEMIS, :V0ENDO-DTINIVIG, :V0ENDO-DTTERVIG, :V0ENDO-TIP-ENDO FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :WHOST-NUM-APOL AND NRENDOS = 0 WITH UR END-EXEC. */

            var r0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 = new R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1()
            {
                WHOST_NUM_APOL = WHOST_NUM_APOL.ToString(),
            };

            var executed_1 = R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1.Execute(r0900_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_NUM_APOL, V0ENDO_NUM_APOL);
                _.Move(executed_1.V0ENDO_NRENDOS, V0ENDO_NRENDOS);
                _.Move(executed_1.V0ENDO_CODPRODU, V0ENDO_CODPRODU);
                _.Move(executed_1.V0ENDO_CODSUBES, V0ENDO_CODSUBES);
                _.Move(executed_1.V0ENDO_DTEMIS, V0ENDO_DTEMIS);
                _.Move(executed_1.V0ENDO_DTINIVIG, V0ENDO_DTINIVIG);
                _.Move(executed_1.V0ENDO_DTTERVIG, V0ENDO_DTTERVIG);
                _.Move(executed_1.V0ENDO_TIP_ENDO, V0ENDO_TIP_ENDO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-CALCULA-RESSEGURO-SECTION */
        private void R1000_00_CALCULA_RESSEGURO_SECTION()
        {
            /*" -786- PERFORM R1100-00-CALL-GE0005S. */

            R1100_00_CALL_GE0005S_SECTION();

            /*" -792- COMPUTE WPCT-LIDER = (100 - WPCT-CED). */
            AREA_DE_WORK.WPCT_LIDER.Value = (100 - AREA_DE_WORK.WPCT_CED);

            /*" -793- IF LKRE01-TIP-CALC = 1 */

            if (LK_RE0001S.LKRE01_TIP_CALC == 1)
            {

                /*" -794- IF V0ENDO-CODPRODU = 1804 */

                if (V0ENDO_CODPRODU == 1804)
                {

                    /*" -795- IF V0ENDO-DTEMIS > '2007-07-31' */

                    if (V0ENDO_DTEMIS > "2007-07-31")
                    {

                        /*" -796- PERFORM R1200-00-CALL-RE0002S */

                        R1200_00_CALL_RE0002S_SECTION();

                        /*" -797- PERFORM R1400-00-PROCESSA-TC-01-1804 */

                        R1400_00_PROCESSA_TC_01_1804_SECTION();

                        /*" -798- ELSE */
                    }
                    else
                    {


                        /*" -799- PERFORM R1500-00-PROCESSA-TP-CALC-01 */

                        R1500_00_PROCESSA_TP_CALC_01_SECTION();

                        /*" -800- END-IF */
                    }


                    /*" -801- ELSE */
                }
                else
                {


                    /*" -802- PERFORM R1500-00-PROCESSA-TP-CALC-01 */

                    R1500_00_PROCESSA_TP_CALC_01_SECTION();

                    /*" -803- END-IF */
                }


                /*" -804- ELSE */
            }
            else
            {


                /*" -805- IF V0ENDO-CODPRODU = 1804 */

                if (V0ENDO_CODPRODU == 1804)
                {

                    /*" -806- IF V0ENDO-DTEMIS > '2007-07-31' */

                    if (V0ENDO_DTEMIS > "2007-07-31")
                    {

                        /*" -807- PERFORM R1200-00-CALL-RE0002S */

                        R1200_00_CALL_RE0002S_SECTION();

                        /*" -808- PERFORM R1600-00-PROCESSA-TC-02-1804 */

                        R1600_00_PROCESSA_TC_02_1804_SECTION();

                        /*" -809- ELSE */
                    }
                    else
                    {


                        /*" -810- PERFORM R1700-00-CALCULA-PRM-BASE */

                        R1700_00_CALCULA_PRM_BASE_SECTION();

                        /*" -811- PERFORM R1800-00-PROCESSA-TP-CALC-02 */

                        R1800_00_PROCESSA_TP_CALC_02_SECTION();

                        /*" -812- END-IF */
                    }


                    /*" -813- ELSE */
                }
                else
                {


                    /*" -814- PERFORM R1700-00-CALCULA-PRM-BASE */

                    R1700_00_CALCULA_PRM_BASE_SECTION();

                    /*" -815- PERFORM R1800-00-PROCESSA-TP-CALC-02 */

                    R1800_00_PROCESSA_TP_CALC_02_SECTION();

                    /*" -816- END-IF */
                }


                /*" -816- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-CALL-GE0005S-SECTION */
        private void R1100_00_CALL_GE0005S_SECTION()
        {
            /*" -834- MOVE ZEROS TO LKGE05-COD-RAMO LKGE05-COD-MODL LKGE05-COD-PROD LKGE05-GRP-SUSEP LKGE05-RMO-SUSEP LKGE05-SQL-CODE. */
            _.Move(0, LK_GE0005S.LKGE05_COD_RAMO, LK_GE0005S.LKGE05_COD_MODL, LK_GE0005S.LKGE05_COD_PROD, LK_GE0005S.LKGE05_GRP_SUSEP, LK_GE0005S.LKGE05_RMO_SUSEP, LK_GE0005S.LKGE05_SQL_CODE);

            /*" -837- MOVE SPACES TO LKGE05-INI-VIGC LKGE05-MENSAGEM. */
            _.Move("", LK_GE0005S.LKGE05_INI_VIGC, LK_GE0005S.LKGE05_MENSAGEM);

            /*" -839- MOVE LKRE01-RAMOFR TO LKGE05-COD-RAMO. */
            _.Move(LK_RE0001S.LKRE01_RAMOFR, LK_GE0005S.LKGE05_COD_RAMO);

            /*" -840- IF LKRE01-RAMOFR EQUAL 48 */

            if (LK_RE0001S.LKRE01_RAMOFR == 48)
            {

                /*" -841- MOVE V0ENDO-CODPRODU TO LKGE05-COD-PROD */
                _.Move(V0ENDO_CODPRODU, LK_GE0005S.LKGE05_COD_PROD);

                /*" -843- END-IF. */
            }


            /*" -844- IF V0ENDO-DTEMIS < '2005-01-01' */

            if (V0ENDO_DTEMIS < "2005-01-01")
            {

                /*" -845- MOVE '2005-01-01' TO LKGE05-INI-VIGC */
                _.Move("2005-01-01", LK_GE0005S.LKGE05_INI_VIGC);

                /*" -846- ELSE */
            }
            else
            {


                /*" -847- MOVE V0ENDO-DTEMIS TO LKGE05-INI-VIGC */
                _.Move(V0ENDO_DTEMIS, LK_GE0005S.LKGE05_INI_VIGC);

                /*" -849- END-IF. */
            }


            /*" -851- CALL 'GE0005S' USING LK-GE0005S. */
            _.Call("GE0005S", LK_GE0005S);

            /*" -852- IF LKGE05-MENSAGEM NOT EQUAL SPACES */

            if (!LK_GE0005S.LKGE05_MENSAGEM.IsEmpty())
            {

                /*" -853- MOVE ZEROS TO LKGE05-SQL-CODE */
                _.Move(0, LK_GE0005S.LKGE05_SQL_CODE);

                /*" -855- MOVE SPACES TO LKGE05-MENSAGEM */
                _.Move("", LK_GE0005S.LKGE05_MENSAGEM);

                /*" -856- IF LKRE01-DTINIVIG < '2011-01-01' */

                if (LK_RE0001S.LKRE01_DTINIVIG < "2011-01-01")
                {

                    /*" -857- MOVE '2011-01-01' TO LKGE05-INI-VIGC */
                    _.Move("2011-01-01", LK_GE0005S.LKGE05_INI_VIGC);

                    /*" -858- ELSE */
                }
                else
                {


                    /*" -859- MOVE LKRE01-DTINIVIG TO LKGE05-INI-VIGC */
                    _.Move(LK_RE0001S.LKRE01_DTINIVIG, LK_GE0005S.LKGE05_INI_VIGC);

                    /*" -861- END-IF */
                }


                /*" -863- CALL 'GE0005S' USING LK-GE0005S */
                _.Call("GE0005S", LK_GE0005S);

                /*" -864- IF LKGE05-MENSAGEM NOT EQUAL SPACES */

                if (!LK_GE0005S.LKGE05_MENSAGEM.IsEmpty())
                {

                    /*" -865- MOVE LKGE05-MENSAGEM TO LKRE01-MENSAGEM */
                    _.Move(LK_GE0005S.LKGE05_MENSAGEM, LK_RE0001S.LKRE01_MENSAGEM);

                    /*" -866- MOVE LKGE05-SQL-CODE TO SQLCODE */
                    _.Move(LK_GE0005S.LKGE05_SQL_CODE, DB.SQLCODE);

                    /*" -867- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -868- END-IF */
                }


                /*" -868- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-CALL-RE0002S-SECTION */
        private void R1200_00_CALL_RE0002S_SECTION()
        {
            /*" -882- IF WHOST-NRENDOS = ZEROS */

            if (WHOST_NRENDOS == 00)
            {

                /*" -883- MOVE V0ENDO-NUM-APOL TO V0ENDS-NUM-APOL */
                _.Move(V0ENDO_NUM_APOL, V0ENDS_NUM_APOL);

                /*" -884- MOVE V0ENDO-NRENDOS TO V0ENDS-NRENDOS */
                _.Move(V0ENDO_NRENDOS, V0ENDS_NRENDOS);

                /*" -885- MOVE V0ENDO-CODPRODU TO V0ENDS-CODPRODU */
                _.Move(V0ENDO_CODPRODU, V0ENDS_CODPRODU);

                /*" -886- MOVE V0ENDO-CODSUBES TO V0ENDS-CODSUBES */
                _.Move(V0ENDO_CODSUBES, V0ENDS_CODSUBES);

                /*" -887- MOVE V0ENDO-DTINIVIG TO V0ENDS-DTINIVIG */
                _.Move(V0ENDO_DTINIVIG, V0ENDS_DTINIVIG);

                /*" -888- MOVE V0ENDO-DTTERVIG TO V0ENDS-DTTERVIG */
                _.Move(V0ENDO_DTTERVIG, V0ENDS_DTTERVIG);

                /*" -889- MOVE V0ENDO-TIP-ENDO TO V0ENDS-TIP-ENDS */
                _.Move(V0ENDO_TIP_ENDO, V0ENDS_TIP_ENDS);

                /*" -890- ELSE */
            }
            else
            {


                /*" -891- PERFORM R1300-00-SELECT-V0ENDOSSO */

                R1300_00_SELECT_V0ENDOSSO_SECTION();

                /*" -893- END-IF. */
            }


            /*" -894- MOVE V0ENDS-NUM-APOL TO LKRE02-NUM-APOL. */
            _.Move(V0ENDS_NUM_APOL, LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_APOL);

            /*" -895- MOVE V0ENDS-NRENDOS TO LKRE02-NUM-ENDS. */
            _.Move(V0ENDS_NRENDOS, LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_ENDS);

            /*" -896- MOVE V0ENDS-CODPRODU TO LKRE02-COD-PROD. */
            _.Move(V0ENDS_CODPRODU, LK_RE0002S.LKRE02_ENTRADA.LKRE02_COD_PROD);

            /*" -898- MOVE V0ENDS-CODSUBES TO LKRE02-COD-SUBG. */
            _.Move(V0ENDS_CODSUBES, LK_RE0002S.LKRE02_ENTRADA.LKRE02_COD_SUBG);

            /*" -899- IF WHOST-NRENDOS = ZEROS */

            if (WHOST_NRENDOS == 00)
            {

                /*" -900- MOVE V0ENDO-DTEMIS TO LKRE02-DTEMS-AP */
                _.Move(V0ENDO_DTEMIS, LK_RE0002S.LKRE02_ENTRADA.LKRE02_DTEMS_AP);

                /*" -901- ELSE */
            }
            else
            {


                /*" -902- IF V0ENDO-DTEMIS > '2021-05-16' */

                if (V0ENDO_DTEMIS > "2021-05-16")
                {

                    /*" -903- MOVE V0ENDO-DTEMIS TO LKRE02-DTEMS-AP */
                    _.Move(V0ENDO_DTEMIS, LK_RE0002S.LKRE02_ENTRADA.LKRE02_DTEMS_AP);

                    /*" -904- ELSE */
                }
                else
                {


                    /*" -905- MOVE V0ENDS-DTEMIS TO LKRE02-DTEMS-AP */
                    _.Move(V0ENDS_DTEMIS, LK_RE0002S.LKRE02_ENTRADA.LKRE02_DTEMS_AP);

                    /*" -906- END-IF */
                }


                /*" -908- END-IF. */
            }


            /*" -909- MOVE V0ENDS-DTINIVIG TO LKRE02-DTINIVIG. */
            _.Move(V0ENDS_DTINIVIG, LK_RE0002S.LKRE02_ENTRADA.LKRE02_DTINIVIG);

            /*" -910- MOVE V0ENDS-DTTERVIG TO LKRE02-DTTERVIG. */
            _.Move(V0ENDS_DTTERVIG, LK_RE0002S.LKRE02_ENTRADA.LKRE02_DTTERVIG);

            /*" -911- MOVE V0ENDS-TIP-ENDS TO LKRE02-TIP-ENDS. */
            _.Move(V0ENDS_TIP_ENDS, LK_RE0002S.LKRE02_ENTRADA.LKRE02_TIP_ENDS);

            /*" -912- MOVE LKRE01-RAMOFR TO LKRE02-RAMO-CBT. */
            _.Move(LK_RE0001S.LKRE01_RAMOFR, LK_RE0002S.LKRE02_ENTRADA.LKRE02_RAMO_CBT);

            /*" -914- MOVE LKRE01-MODALIFR TO LKRE02-MODL-CBT. */
            _.Move(LK_RE0001S.LKRE01_MODALIFR, LK_RE0002S.LKRE02_ENTRADA.LKRE02_MODL_CBT);

            /*" -915- MOVE ZEROS TO LKRE02-NUM-VERS. */
            _.Move(0, LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_VERS);

            /*" -916- MOVE ZEROS TO LKRE02-NUM-ITEM. */
            _.Move(0, LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_ITEM);

            /*" -917- MOVE ZEROS TO LKRE02-COD-RETN. */
            _.Move(0, LK_RE0002S.LKRE02_SAIDA.LKRE02_COD_RETN);

            /*" -919- MOVE SPACES TO LKRE02-MENSAGEM. */
            _.Move("", LK_RE0002S.LKRE02_SAIDA.LKRE02_MENSAGEM);

            /*" -921- CALL 'RE0002S' USING LK-RE0002S. */
            _.Call("RE0002S", LK_RE0002S);

            /*" -922- IF LKRE02-COD-RETN NOT = ZEROS */

            if (LK_RE0002S.LKRE02_SAIDA.LKRE02_COD_RETN != 00)
            {

                /*" -923- MOVE LKRE02-MENSAGEM TO WS-MENSG-1 */
                _.Move(LK_RE0002S.LKRE02_SAIDA.LKRE02_MENSAGEM, AREA_DE_WORK.WS_MENSG_0.WS_MENSG_1);

                /*" -924- MOVE LKRE02-COD-RETN TO WS-MENSG-2 */
                _.Move(LK_RE0002S.LKRE02_SAIDA.LKRE02_COD_RETN, AREA_DE_WORK.WS_MENSG_0.WS_MENSG_2);

                /*" -925- MOVE WS-MENSG-0 TO LKRE01-MENSAGEM */
                _.Move(AREA_DE_WORK.WS_MENSG_0, LK_RE0001S.LKRE01_MENSAGEM);

                /*" -926- MOVE 99 TO LKRE01-RTN-CODE */
                _.Move(99, LK_RE0001S.LKRE01_RTN_CODE);

                /*" -927- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -931- END-IF. */
            }


            /*" -932- IF LKRE02-PRM-TARF = V0HISP-PRM-TAR */

            if (LK_RE0002S.LKRE02_SAIDA.LKRE02_PRM_TARF == V0HISP_PRM_TAR)
            {

                /*" -934- COMPUTE WPRM-TAR-C ROUNDED = LKRE02-PRM-TARF * WPCT-RAMOFR-PR / 100 */
                AREA_DE_WORK.WPRM_TAR_C.Value = LK_RE0002S.LKRE02_SAIDA.LKRE02_PRM_TARF * AREA_DE_WORK.WPCT_RAMOFR_PR / 100f;

                /*" -935- ELSE */
            }
            else
            {


                /*" -937- COMPUTE WPRM-TAR-C ROUNDED = V0HISP-PRM-TAR * WPCT-RAMOFR-PR / 100 */
                AREA_DE_WORK.WPRM_TAR_C.Value = V0HISP_PRM_TAR * AREA_DE_WORK.WPCT_RAMOFR_PR / 100f;

                /*" -941- END-IF */
            }


            /*" -946- COMPUTE WPRM-LIDR ROUNDED = WPRM-TAR-C * WPCT-LIDER / 100. */
            AREA_DE_WORK.WPRM_LIDR.Value = AREA_DE_WORK.WPRM_TAR_C * AREA_DE_WORK.WPCT_LIDER / 100f;

            /*" -947- COMPUTE WPRM-TAR-L = LKRE02-PRM-LIDR * WPCT-RAMOFR-PR / 100. */
            AREA_DE_WORK.WPRM_TAR_L.Value = LK_RE0002S.LKRE02_SAIDA.LKRE02_PRM_LIDR * AREA_DE_WORK.WPCT_RAMOFR_PR / 100f;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V0ENDOSSO-SECTION */
        private void R1300_00_SELECT_V0ENDOSSO_SECTION()
        {
            /*" -981- PERFORM R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1 */

            R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1();

            /*" -984- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -986- MOVE 'R1300 - ERRO NO SELECT DA V0ENDOSSO' TO LKRE01-MENSAGEM */
                _.Move("R1300 - ERRO NO SELECT DA V0ENDOSSO", LK_RE0001S.LKRE01_MENSAGEM);

                /*" -987- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -988- ELSE */
            }
            else
            {


                /*" -990- IF V0ENDS-CODPRODU = V0ENDO-CODPRODU NEXT SENTENCE */

                if (V0ENDS_CODPRODU == V0ENDO_CODPRODU)
                {

                    /*" -991- ELSE */
                }
                else
                {


                    /*" -993- MOVE 'R1300 - PRODUTO DA APOLICE DIFERE DO ENDOSSO' TO LKRE01-MENSAGEM */
                    _.Move("R1300 - PRODUTO DA APOLICE DIFERE DO ENDOSSO", LK_RE0001S.LKRE01_MENSAGEM);

                    /*" -994- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -995- END-IF */
                }


                /*" -995- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-V0ENDOSSO-DB-SELECT-1 */
        public void R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1()
        {
            /*" -981- EXEC SQL SELECT NUM_APOLICE, NRENDOS, CODPRODU, CODSUBES, DTEMIS, DTINIVIG, DTTERVIG, TIPO_ENDOSSO INTO :V0ENDS-NUM-APOL, :V0ENDS-NRENDOS, :V0ENDS-CODPRODU, :V0ENDS-CODSUBES, :V0ENDS-DTEMIS, :V0ENDS-DTINIVIG, :V0ENDS-DTTERVIG, :V0ENDS-TIP-ENDS FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :WHOST-NUM-APOL AND NRENDOS = :WHOST-NRENDOS WITH UR END-EXEC. */

            var r1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 = new R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1()
            {
                WHOST_NUM_APOL = WHOST_NUM_APOL.ToString(),
                WHOST_NRENDOS = WHOST_NRENDOS.ToString(),
            };

            var executed_1 = R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDS_NUM_APOL, V0ENDS_NUM_APOL);
                _.Move(executed_1.V0ENDS_NRENDOS, V0ENDS_NRENDOS);
                _.Move(executed_1.V0ENDS_CODPRODU, V0ENDS_CODPRODU);
                _.Move(executed_1.V0ENDS_CODSUBES, V0ENDS_CODSUBES);
                _.Move(executed_1.V0ENDS_DTEMIS, V0ENDS_DTEMIS);
                _.Move(executed_1.V0ENDS_DTINIVIG, V0ENDS_DTINIVIG);
                _.Move(executed_1.V0ENDS_DTTERVIG, V0ENDS_DTTERVIG);
                _.Move(executed_1.V0ENDS_TIP_ENDS, V0ENDS_TIP_ENDS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-PROCESSA-TC-01-1804-SECTION */
        private void R1400_00_PROCESSA_TC_01_1804_SECTION()
        {
            /*" -1014- COMPUTE WS-IS-LIDER = (LKRE02-IMP-SEGR * WPCT-LIDER / 100 * WPCT-RAMOFR-IS / 100). */
            AREA_DE_WORK.WS_IS_LIDER.Value = (LK_RE0002S.LKRE02_SAIDA.LKRE02_IMP_SEGR * AREA_DE_WORK.WPCT_LIDER / 100f * AREA_DE_WORK.WPCT_RAMOFR_IS / 100f);

            /*" -1015- IF WHOST-IMPSEG-ER < ZEROS */

            if (WHOST_IMPSEG_ER < 00)
            {

                /*" -1017- MOVE 'R1400 - IMP SEG DO EXCEDENTE NEGATIVA' TO LKRE01-MENSAGEM */
                _.Move("R1400 - IMP SEG DO EXCEDENTE NEGATIVA", LK_RE0001S.LKRE01_MENSAGEM);

                /*" -1018- MOVE 99 TO LKRE01-RTN-CODE */
                _.Move(99, LK_RE0001S.LKRE01_RTN_CODE);

                /*" -1019- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1020- ELSE */
            }
            else
            {


                /*" -1021- IF WS-IS-LIDER = ZEROS */

                if (AREA_DE_WORK.WS_IS_LIDER == 00)
                {

                    /*" -1022- MOVE ZEROS TO WPCTRSP-IS */
                    _.Move(0, AREA_DE_WORK.WPCTRSP_IS);

                    /*" -1023- ELSE */
                }
                else
                {


                    /*" -1027- COMPUTE WPCTRSP-IS ROUNDED = WHOST-IMPSEG-ER / WS-IS-LIDER * 100 ON SIZE ERROR MOVE ZEROS TO WPCTRSP-IS END-COMPUTE */
                    if (AREA_DE_WORK.WS_IS_LIDER.Value == 0)
                        _.Move(0, AREA_DE_WORK.WPCTRSP_IS);
                    else

                        AREA_DE_WORK.WPCTRSP_IS.Value = WHOST_IMPSEG_ER / AREA_DE_WORK.WS_IS_LIDER * 100;

                    /*" -1028- END-IF */
                }


                /*" -1032- END-IF. */
            }


            /*" -1033- IF WPRM-TAR-L = ZEROS */

            if (AREA_DE_WORK.WPRM_TAR_L == 00)
            {

                /*" -1034- MOVE ZEROS TO WPCTRSP-PR */
                _.Move(0, AREA_DE_WORK.WPCTRSP_PR);

                /*" -1035- ELSE */
            }
            else
            {


                /*" -1039- COMPUTE WPCTRSP-PR ROUNDED = V0HISR-PRERSP / WPRM-TAR-L * 100 ON SIZE ERROR MOVE ZEROS TO WPCTRSP-PR END-COMPUTE */
                if (AREA_DE_WORK.WPRM_TAR_L.Value == 0)
                    _.Move(0, AREA_DE_WORK.WPCTRSP_PR);
                else

                    AREA_DE_WORK.WPCTRSP_PR.Value = V0HISR_PRERSP / AREA_DE_WORK.WPRM_TAR_L * 100;

                /*" -1041- END-IF. */
            }


            /*" -1042- IF V0HISR-PRERSP = ZEROS */

            if (V0HISR_PRERSP == 00)
            {

                /*" -1043- MOVE ZEROS TO WPCTCOMER */
                _.Move(0, AREA_DE_WORK.WPCTCOMER);

                /*" -1044- ELSE */
            }
            else
            {


                /*" -1048- COMPUTE WPCTCOMER ROUNDED = V0HISR-COMRSP / V0HISR-PRERSP * 100 ON SIZE ERROR MOVE ZEROS TO WPCTCOMER END-COMPUTE */
                if (V0HISR_PRERSP.Value == 0)
                    _.Move(0, AREA_DE_WORK.WPCTCOMER);
                else

                    AREA_DE_WORK.WPCTCOMER.Value = V0HISR_COMRSP / V0HISR_PRERSP * 100;

                /*" -1050- END-IF. */
            }


            /*" -1052- MOVE WPCTRSP-PR TO LKRE01-PCTRSP-PR. */
            _.Move(AREA_DE_WORK.WPCTRSP_PR, LK_RE0001S.LKRE01_PCTRSP_PR);

            /*" -1053- IF WPCTRSP-IS = ZEROS */

            if (AREA_DE_WORK.WPCTRSP_IS == 00)
            {

                /*" -1054- MOVE WPCTRSP-PR TO LKRE01-PCTRSP-IS */
                _.Move(AREA_DE_WORK.WPCTRSP_PR, LK_RE0001S.LKRE01_PCTRSP_IS);

                /*" -1055- ELSE */
            }
            else
            {


                /*" -1056- MOVE WPCTRSP-IS TO LKRE01-PCTRSP-IS */
                _.Move(AREA_DE_WORK.WPCTRSP_IS, LK_RE0001S.LKRE01_PCTRSP_IS);

                /*" -1058- END-IF. */
            }


            /*" -1059- MOVE V0DRES-PCTCOT TO LKRE01-PCTCOT. */
            _.Move(V0DRES_PCTCOT, LK_RE0001S.LKRE01_PCTCOT);

            /*" -1060- MOVE V0DRES-PCTCTF TO LKRE01-PCTCTF. */
            _.Move(V0DRES_PCTCTF, LK_RE0001S.LKRE01_PCTCTF);

            /*" -1061- MOVE V0DRES-PCTDNO TO LKRE01-PCTDNO. */
            _.Move(V0DRES_PCTDNO, LK_RE0001S.LKRE01_PCTDNO);

            /*" -1062- MOVE V0DRES-PCTCOMCO TO LKRE01-PCTCOMCO. */
            _.Move(V0DRES_PCTCOMCO, LK_RE0001S.LKRE01_PCTCOMCO);

            /*" -1064- MOVE WPCTCOMER TO LKRE01-PCTCOMRS. */
            _.Move(AREA_DE_WORK.WPCTCOMER, LK_RE0001S.LKRE01_PCTCOMRS);

            /*" -1065- MOVE V0DRES-DTCUTOFF TO LKRE01-DTCUTOFF. */
            _.Move(V0DRES_DTCUTOFF, LK_RE0001S.LKRE01_DTCUTOFF);

            /*" -1067- MOVE V0DRES-RECUP-PSL TO LKRE01-RECP-PSL. */
            _.Move(V0DRES_RECUP_PSL, LK_RE0001S.LKRE01_RECP_PSL);

            /*" -1067- MOVE V0DRES-CONTR-RESG TO LKRE01-CONTR-RE. */
            _.Move(V0DRES_CONTR_RESG, LK_RE0001S.LKRE01_CONTR_RE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-PROCESSA-TP-CALC-01-SECTION */
        private void R1500_00_PROCESSA_TP_CALC_01_SECTION()
        {
            /*" -1087- COMPUTE WS-IS-LIDER = V0COBA-IMP-IX-R * WPCT-LIDER / 100. */
            AREA_DE_WORK.WS_IS_LIDER.Value = V0COBA_IMP_IX_R * AREA_DE_WORK.WPCT_LIDER / 100f;

            /*" -1088- IF WHOST-IMPSEG-ER < ZEROS */

            if (WHOST_IMPSEG_ER < 00)
            {

                /*" -1090- MOVE 'R1500 - IMP SEG DO EXCEDENTE NEGATIVA' TO LKRE01-MENSAGEM */
                _.Move("R1500 - IMP SEG DO EXCEDENTE NEGATIVA", LK_RE0001S.LKRE01_MENSAGEM);

                /*" -1091- MOVE 99 TO LKRE01-RTN-CODE */
                _.Move(99, LK_RE0001S.LKRE01_RTN_CODE);

                /*" -1092- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1093- ELSE */
            }
            else
            {


                /*" -1094- IF WS-IS-LIDER = ZEROS */

                if (AREA_DE_WORK.WS_IS_LIDER == 00)
                {

                    /*" -1095- MOVE ZEROS TO WPCTRSP-IS */
                    _.Move(0, AREA_DE_WORK.WPCTRSP_IS);

                    /*" -1096- ELSE */
                }
                else
                {


                    /*" -1100- COMPUTE WPCTRSP-IS ROUNDED = WHOST-IMPSEG-ER / WS-IS-LIDER * 100 ON SIZE ERROR MOVE ZEROS TO WPCTRSP-IS END-COMPUTE */
                    if (AREA_DE_WORK.WS_IS_LIDER.Value == 0)
                        _.Move(0, AREA_DE_WORK.WPCTRSP_IS);
                    else

                        AREA_DE_WORK.WPCTRSP_IS.Value = WHOST_IMPSEG_ER / AREA_DE_WORK.WS_IS_LIDER * 100;

                    /*" -1101- END-IF */
                }


                /*" -1105- END-IF. */
            }


            /*" -1107- IF V0HISP-PRM-TAR = ZEROS OR WPCT-RAMOFR-PR = ZEROS */

            if (V0HISP_PRM_TAR == 00 || AREA_DE_WORK.WPCT_RAMOFR_PR == 00)
            {

                /*" -1108- MOVE ZEROS TO WPRM-TAR-C */
                _.Move(0, AREA_DE_WORK.WPRM_TAR_C);

                /*" -1109- ELSE */
            }
            else
            {


                /*" -1112- COMPUTE WPRM-TAR-C ROUNDED = V0HISP-PRM-TAR * WPCT-RAMOFR-PR / 100 */
                AREA_DE_WORK.WPRM_TAR_C.Value = V0HISP_PRM_TAR * AREA_DE_WORK.WPCT_RAMOFR_PR / 100f;

                /*" -1114- END-IF. */
            }


            /*" -1115- IF WPRM-TAR-C = ZEROS */

            if (AREA_DE_WORK.WPRM_TAR_C == 00)
            {

                /*" -1116- MOVE ZEROS TO WPRM-TAR-L */
                _.Move(0, AREA_DE_WORK.WPRM_TAR_L);

                /*" -1117- ELSE */
            }
            else
            {


                /*" -1119- COMPUTE WPRM-TAR-L ROUNDED = WPRM-TAR-C * WPCT-LIDER / 100 */
                AREA_DE_WORK.WPRM_TAR_L.Value = AREA_DE_WORK.WPRM_TAR_C * AREA_DE_WORK.WPCT_LIDER / 100f;

                /*" -1123- END-IF. */
            }


            /*" -1124- IF WPRM-TAR-L = ZEROS */

            if (AREA_DE_WORK.WPRM_TAR_L == 00)
            {

                /*" -1125- MOVE ZEROS TO WPCTRSP-PR */
                _.Move(0, AREA_DE_WORK.WPCTRSP_PR);

                /*" -1126- ELSE */
            }
            else
            {


                /*" -1130- COMPUTE WPCTRSP-PR ROUNDED = V0HISR-PRERSP / WPRM-TAR-L * 100 ON SIZE ERROR MOVE ZEROS TO WPCTRSP-PR END-COMPUTE */
                if (AREA_DE_WORK.WPRM_TAR_L.Value == 0)
                    _.Move(0, AREA_DE_WORK.WPCTRSP_PR);
                else

                    AREA_DE_WORK.WPCTRSP_PR.Value = V0HISR_PRERSP / AREA_DE_WORK.WPRM_TAR_L * 100;

                /*" -1132- END-IF. */
            }


            /*" -1133- IF V0HISR-PRERSP = ZEROS */

            if (V0HISR_PRERSP == 00)
            {

                /*" -1134- MOVE ZEROS TO WPCTCOMER */
                _.Move(0, AREA_DE_WORK.WPCTCOMER);

                /*" -1135- ELSE */
            }
            else
            {


                /*" -1139- COMPUTE WPCTCOMER ROUNDED = V0HISR-COMRSP / V0HISR-PRERSP * 100 ON SIZE ERROR MOVE ZEROS TO WPCTCOMER END-COMPUTE */
                if (V0HISR_PRERSP.Value == 0)
                    _.Move(0, AREA_DE_WORK.WPCTCOMER);
                else

                    AREA_DE_WORK.WPCTCOMER.Value = V0HISR_COMRSP / V0HISR_PRERSP * 100;

                /*" -1143- END-IF. */
            }


            /*" -1145- MOVE WPCTRSP-PR TO LKRE01-PCTRSP-PR. */
            _.Move(AREA_DE_WORK.WPCTRSP_PR, LK_RE0001S.LKRE01_PCTRSP_PR);

            /*" -1146- IF WPCTRSP-IS = ZEROS */

            if (AREA_DE_WORK.WPCTRSP_IS == 00)
            {

                /*" -1147- MOVE WPCTRSP-PR TO LKRE01-PCTRSP-IS */
                _.Move(AREA_DE_WORK.WPCTRSP_PR, LK_RE0001S.LKRE01_PCTRSP_IS);

                /*" -1148- ELSE */
            }
            else
            {


                /*" -1149- MOVE WPCTRSP-IS TO LKRE01-PCTRSP-IS */
                _.Move(AREA_DE_WORK.WPCTRSP_IS, LK_RE0001S.LKRE01_PCTRSP_IS);

                /*" -1151- END-IF. */
            }


            /*" -1152- MOVE V0DRES-PCTCOT TO LKRE01-PCTCOT. */
            _.Move(V0DRES_PCTCOT, LK_RE0001S.LKRE01_PCTCOT);

            /*" -1153- MOVE V0DRES-PCTCTF TO LKRE01-PCTCTF. */
            _.Move(V0DRES_PCTCTF, LK_RE0001S.LKRE01_PCTCTF);

            /*" -1154- MOVE V0DRES-PCTDNO TO LKRE01-PCTDNO. */
            _.Move(V0DRES_PCTDNO, LK_RE0001S.LKRE01_PCTDNO);

            /*" -1155- MOVE V0DRES-PCTCOMCO TO LKRE01-PCTCOMCO. */
            _.Move(V0DRES_PCTCOMCO, LK_RE0001S.LKRE01_PCTCOMCO);

            /*" -1157- MOVE WPCTCOMER TO LKRE01-PCTCOMRS. */
            _.Move(AREA_DE_WORK.WPCTCOMER, LK_RE0001S.LKRE01_PCTCOMRS);

            /*" -1158- MOVE V0DRES-DTCUTOFF TO LKRE01-DTCUTOFF. */
            _.Move(V0DRES_DTCUTOFF, LK_RE0001S.LKRE01_DTCUTOFF);

            /*" -1160- MOVE V0DRES-RECUP-PSL TO LKRE01-RECP-PSL. */
            _.Move(V0DRES_RECUP_PSL, LK_RE0001S.LKRE01_RECP_PSL);

            /*" -1160- MOVE V0DRES-CONTR-RESG TO LKRE01-CONTR-RE. */
            _.Move(V0DRES_CONTR_RESG, LK_RE0001S.LKRE01_CONTR_RE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-PROCESSA-TC-02-1804-SECTION */
        private void R1600_00_PROCESSA_TC_02_1804_SECTION()
        {
            /*" -1181- COMPUTE WS-IS-LIDER = V0COBA-IMP-IX-R * WPCT-LIDER / 100. */
            AREA_DE_WORK.WS_IS_LIDER.Value = V0COBA_IMP_IX_R * AREA_DE_WORK.WPCT_LIDER / 100f;

            /*" -1182- IF WHOST-IMPSEG-ER < ZEROS */

            if (WHOST_IMPSEG_ER < 00)
            {

                /*" -1184- MOVE 'R1000 - IMP SEG DO EXCEDENTE NEGATIVA' TO LKRE01-MENSAGEM */
                _.Move("R1000 - IMP SEG DO EXCEDENTE NEGATIVA", LK_RE0001S.LKRE01_MENSAGEM);

                /*" -1185- MOVE 99 TO LKRE01-RTN-CODE */
                _.Move(99, LK_RE0001S.LKRE01_RTN_CODE);

                /*" -1186- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1187- ELSE */
            }
            else
            {


                /*" -1191- COMPUTE WPCTRSP-IS ROUNDED = WHOST-IMPSEG-ER / WS-IS-LIDER * 100 ON SIZE ERROR MOVE ZEROS TO WPCTRSP-IS END-COMPUTE */
                if (AREA_DE_WORK.WS_IS_LIDER.Value == 0)
                    _.Move(0, AREA_DE_WORK.WPCTRSP_IS);
                else

                    AREA_DE_WORK.WPCTRSP_IS.Value = WHOST_IMPSEG_ER / AREA_DE_WORK.WS_IS_LIDER * 100;

                /*" -1195- END-IF. */
            }


            /*" -1196- IF WPRM-LIDR = ZEROS */

            if (AREA_DE_WORK.WPRM_LIDR == 00)
            {

                /*" -1197- MOVE ZEROS TO WPCTRSP-PR */
                _.Move(0, AREA_DE_WORK.WPCTRSP_PR);

                /*" -1198- ELSE */
            }
            else
            {


                /*" -1202- COMPUTE WPCTRSP-PR ROUNDED = V0HISR-PRERSP / WPRM-LIDR * 100 ON SIZE ERROR MOVE ZEROS TO WPCTRSP-PR END-COMPUTE */
                if (AREA_DE_WORK.WPRM_LIDR.Value == 0)
                    _.Move(0, AREA_DE_WORK.WPCTRSP_PR);
                else

                    AREA_DE_WORK.WPCTRSP_PR.Value = V0HISR_PRERSP / AREA_DE_WORK.WPRM_LIDR * 100;

                /*" -1204- END-IF. */
            }


            /*" -1205- IF V0HISR-PRERSP = ZEROS */

            if (V0HISR_PRERSP == 00)
            {

                /*" -1206- MOVE ZEROS TO WPCTCOMER */
                _.Move(0, AREA_DE_WORK.WPCTCOMER);

                /*" -1207- ELSE */
            }
            else
            {


                /*" -1211- COMPUTE WPCTCOMER ROUNDED = V0HISR-COMRSP / V0HISR-PRERSP * 100 ON SIZE ERROR MOVE ZEROS TO WPCTCOMER END-COMPUTE */
                if (V0HISR_PRERSP.Value == 0)
                    _.Move(0, AREA_DE_WORK.WPCTCOMER);
                else

                    AREA_DE_WORK.WPCTCOMER.Value = V0HISR_COMRSP / V0HISR_PRERSP * 100;

                /*" -1216- END-IF. */
            }


            /*" -1220- COMPUTE WPRM-BASE = WPRM-TAR-L - V0HISR-PRERSP. */
            AREA_DE_WORK.WPRM_BASE.Value = AREA_DE_WORK.WPRM_TAR_L - V0HISR_PRERSP;

            /*" -1223- COMPUTE WPRECOT ROUNDED = WPRM-BASE * V0DRES-PCTCOT / 100. */
            AREA_DE_WORK.WPRECOT.Value = AREA_DE_WORK.WPRM_BASE * V0DRES_PCTCOT / 100f;

            /*" -1226- COMPUTE WCOMCOT ROUNDED = WPRECOT * V0DRES-PCTCOMCO / 100. */
            AREA_DE_WORK.WCOMCOT.Value = AREA_DE_WORK.WPRECOT * V0DRES_PCTCOMCO / 100f;

            /*" -1229- COMPUTE WPRECTF ROUNDED = WPRM-BASE * V0DRES-PCTCTF / 100. */
            AREA_DE_WORK.WPRECTF.Value = AREA_DE_WORK.WPRM_BASE * V0DRES_PCTCTF / 100f;

            /*" -1232- COMPUTE WPREDNO ROUNDED = WPRM-BASE * V0DRES-PCTDNO / 100. */
            AREA_DE_WORK.WPREDNO.Value = AREA_DE_WORK.WPRM_BASE * V0DRES_PCTDNO / 100f;

            /*" -1233- IF WPRM-LIDR = ZEROS */

            if (AREA_DE_WORK.WPRM_LIDR == 00)
            {

                /*" -1237- MOVE ZEROS TO WPCTCOT WPCTCTF WPCTDNO WPCTCOMCO */
                _.Move(0, AREA_DE_WORK.WPCTCOT, AREA_DE_WORK.WPCTCTF, AREA_DE_WORK.WPCTDNO, AREA_DE_WORK.WPCTCOMCO);

                /*" -1238- ELSE */
            }
            else
            {


                /*" -1242- COMPUTE WPCTCOT ROUNDED = WPRECOT / WPRM-LIDR * 100 */
                AREA_DE_WORK.WPCTCOT.Value = AREA_DE_WORK.WPRECOT / AREA_DE_WORK.WPRM_LIDR * 100;

                /*" -1246- COMPUTE WPCTCTF ROUNDED = WPRECTF / WPRM-LIDR * 100 */
                AREA_DE_WORK.WPCTCTF.Value = AREA_DE_WORK.WPRECTF / AREA_DE_WORK.WPRM_LIDR * 100;

                /*" -1250- COMPUTE WPCTDNO ROUNDED = WPREDNO / WPRM-LIDR * 100 */
                AREA_DE_WORK.WPCTDNO.Value = AREA_DE_WORK.WPREDNO / AREA_DE_WORK.WPRM_LIDR * 100;

                /*" -1251- IF WPRECOT = ZEROS */

                if (AREA_DE_WORK.WPRECOT == 00)
                {

                    /*" -1252- MOVE ZEROS TO WPCTCOMCO */
                    _.Move(0, AREA_DE_WORK.WPCTCOMCO);

                    /*" -1253- ELSE */
                }
                else
                {


                    /*" -1256- COMPUTE WPCTCOMCO ROUNDED = WCOMCOT / WPRECOT * 100 */
                    AREA_DE_WORK.WPCTCOMCO.Value = AREA_DE_WORK.WCOMCOT / AREA_DE_WORK.WPRECOT * 100;

                    /*" -1257- END-IF */
                }


                /*" -1259- END-IF. */
            }


            /*" -1261- MOVE WPCTRSP-PR TO LKRE01-PCTRSP-PR. */
            _.Move(AREA_DE_WORK.WPCTRSP_PR, LK_RE0001S.LKRE01_PCTRSP_PR);

            /*" -1262- IF WPCTRSP-IS = ZEROS */

            if (AREA_DE_WORK.WPCTRSP_IS == 00)
            {

                /*" -1263- MOVE WPCTRSP-PR TO LKRE01-PCTRSP-IS */
                _.Move(AREA_DE_WORK.WPCTRSP_PR, LK_RE0001S.LKRE01_PCTRSP_IS);

                /*" -1264- ELSE */
            }
            else
            {


                /*" -1265- MOVE WPCTRSP-IS TO LKRE01-PCTRSP-IS */
                _.Move(AREA_DE_WORK.WPCTRSP_IS, LK_RE0001S.LKRE01_PCTRSP_IS);

                /*" -1267- END-IF. */
            }


            /*" -1268- MOVE WPCTCOT TO LKRE01-PCTCOT. */
            _.Move(AREA_DE_WORK.WPCTCOT, LK_RE0001S.LKRE01_PCTCOT);

            /*" -1269- MOVE WPCTCTF TO LKRE01-PCTCTF. */
            _.Move(AREA_DE_WORK.WPCTCTF, LK_RE0001S.LKRE01_PCTCTF);

            /*" -1270- MOVE WPCTDNO TO LKRE01-PCTDNO. */
            _.Move(AREA_DE_WORK.WPCTDNO, LK_RE0001S.LKRE01_PCTDNO);

            /*" -1271- MOVE WPCTCOMCO TO LKRE01-PCTCOMCO. */
            _.Move(AREA_DE_WORK.WPCTCOMCO, LK_RE0001S.LKRE01_PCTCOMCO);

            /*" -1273- MOVE WPCTCOMER TO LKRE01-PCTCOMRS. */
            _.Move(AREA_DE_WORK.WPCTCOMER, LK_RE0001S.LKRE01_PCTCOMRS);

            /*" -1274- MOVE V0DRES-DTCUTOFF TO LKRE01-DTCUTOFF. */
            _.Move(V0DRES_DTCUTOFF, LK_RE0001S.LKRE01_DTCUTOFF);

            /*" -1276- MOVE V0DRES-RECUP-PSL TO LKRE01-RECP-PSL. */
            _.Move(V0DRES_RECUP_PSL, LK_RE0001S.LKRE01_RECP_PSL);

            /*" -1276- MOVE V0DRES-CONTR-RESG TO LKRE01-CONTR-RE. */
            _.Move(V0DRES_CONTR_RESG, LK_RE0001S.LKRE01_CONTR_RE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-CALCULA-PRM-BASE-SECTION */
        private void R1700_00_CALCULA_PRM_BASE_SECTION()
        {
            /*" -1294- COMPUTE WPRM-TAR-C ROUNDED = V0HISP-PRM-TAR * WPCT-RAMOFR-PR / 100. */
            AREA_DE_WORK.WPRM_TAR_C.Value = V0HISP_PRM_TAR * AREA_DE_WORK.WPCT_RAMOFR_PR / 100f;

            /*" -1299- COMPUTE WPRM-TAR-L ROUNDED = WPRM-TAR-C * WPCT-LIDER / 100. */
            AREA_DE_WORK.WPRM_TAR_L.Value = AREA_DE_WORK.WPRM_TAR_C * AREA_DE_WORK.WPCT_LIDER / 100f;

            /*" -1300- IF WHOST-RAMOFR = 16 OR 18 */

            if (WHOST_RAMOFR.In("16", "18"))
            {

                /*" -1304- COMPUTE WVLR-COMPL = V0PCMP-VLR-COMPL * WPCT-RAMOFR-PR / 100 */
                AREA_DE_WORK.WVLR_COMPL.Value = V0PCMP_VLR_COMPL * AREA_DE_WORK.WPCT_RAMOFR_PR / 100f;

                /*" -1307- COMPUTE WVLR-COMPL-I = V0PCMP-VLR-COMPL-I * WPCT-RAMOFR-PR / 100 */
                AREA_DE_WORK.WVLR_COMPL_I.Value = V0PCMP_VLR_COMPL_I * AREA_DE_WORK.WPCT_RAMOFR_PR / 100f;

                /*" -1308- ELSE */
            }
            else
            {


                /*" -1309- MOVE ZEROS TO WVLR-COMPL */
                _.Move(0, AREA_DE_WORK.WVLR_COMPL);

                /*" -1310- MOVE ZEROS TO WVLR-COMPL-I */
                _.Move(0, AREA_DE_WORK.WVLR_COMPL_I);

                /*" -1314- END-IF. */
            }


            /*" -1315- IF WHOST-RAMOFR = 16 OR 18 */

            if (WHOST_RAMOFR.In("16", "18"))
            {

                /*" -1316- IF LKRE01-TIP-CALC = 1 */

                if (LK_RE0001S.LKRE01_TIP_CALC == 1)
                {

                    /*" -1320- COMPUTE WPRM-BASE ROUNDED = ((WPRM-TAR-C - WVLR-COMPL) * WPCT-LIDER) / 100 */
                    AREA_DE_WORK.WPRM_BASE.Value = ((AREA_DE_WORK.WPRM_TAR_C - AREA_DE_WORK.WVLR_COMPL) * AREA_DE_WORK.WPCT_LIDER) / 100f;

                    /*" -1321- ELSE */
                }
                else
                {


                    /*" -1323- COMPUTE WPRM-BASE = WPRM-TAR-L - WVLR-COMPL */
                    AREA_DE_WORK.WPRM_BASE.Value = AREA_DE_WORK.WPRM_TAR_L - AREA_DE_WORK.WVLR_COMPL;

                    /*" -1324- END-IF */
                }


                /*" -1325- ELSE */
            }
            else
            {


                /*" -1326- IF WHOST-RAMOFR = 66 */

                if (WHOST_RAMOFR == 66)
                {

                    /*" -1328- COMPUTE WPRM-BASE = WPRM-TAR-C - MOVHBT-PRM-CRED */
                    AREA_DE_WORK.WPRM_BASE.Value = AREA_DE_WORK.WPRM_TAR_C - MOVHBT_PRM_CRED;

                    /*" -1329- ELSE */
                }
                else
                {


                    /*" -1332- IF WHOST-RAMOFR = 68 AND (WHOST-NUM-APOL = 006501000001 OR WHOST-NUM-APOL = 106800000013) */

                    if (WHOST_RAMOFR == 68 && (WHOST_NUM_APOL == 006501000001 || WHOST_NUM_APOL == 106800000013))
                    {

                        /*" -1333- MOVE WPRM-TAR-C TO WPRM-BASE */
                        _.Move(AREA_DE_WORK.WPRM_TAR_C, AREA_DE_WORK.WPRM_BASE);

                        /*" -1334- ELSE */
                    }
                    else
                    {


                        /*" -1335- MOVE WPRM-TAR-L TO WPRM-BASE */
                        _.Move(AREA_DE_WORK.WPRM_TAR_L, AREA_DE_WORK.WPRM_BASE);

                        /*" -1336- END-IF */
                    }


                    /*" -1337- END-IF */
                }


                /*" -1337- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-PROCESSA-TP-CALC-02-SECTION */
        private void R1800_00_PROCESSA_TP_CALC_02_SECTION()
        {
            /*" -1353- IF WPRM-TAR-L = ZEROS */

            if (AREA_DE_WORK.WPRM_TAR_L == 00)
            {

                /*" -1354- MOVE ZEROS TO WPCTRSP-PR */
                _.Move(0, AREA_DE_WORK.WPCTRSP_PR);

                /*" -1355- ELSE */
            }
            else
            {


                /*" -1359- COMPUTE WPCTRSP-PR ROUNDED = V0HISR-PRERSP / WPRM-TAR-L * 100 ON SIZE ERROR MOVE ZEROS TO WPCTRSP-PR END-COMPUTE */
                if (AREA_DE_WORK.WPRM_TAR_L.Value == 0)
                    _.Move(0, AREA_DE_WORK.WPCTRSP_PR);
                else

                    AREA_DE_WORK.WPCTRSP_PR.Value = V0HISR_PRERSP / AREA_DE_WORK.WPRM_TAR_L * 100;

                /*" -1361- END-IF. */
            }


            /*" -1362- IF V0HISR-PRERSP = ZEROS */

            if (V0HISR_PRERSP == 00)
            {

                /*" -1363- MOVE ZEROS TO WPCTCOMER */
                _.Move(0, AREA_DE_WORK.WPCTCOMER);

                /*" -1364- ELSE */
            }
            else
            {


                /*" -1368- COMPUTE WPCTCOMER ROUNDED = V0HISR-COMRSP / V0HISR-PRERSP * 100 ON SIZE ERROR MOVE ZEROS TO WPCTCOMER END-COMPUTE */
                if (V0HISR_PRERSP.Value == 0)
                    _.Move(0, AREA_DE_WORK.WPCTCOMER);
                else

                    AREA_DE_WORK.WPCTCOMER.Value = V0HISR_COMRSP / V0HISR_PRERSP * 100;

                /*" -1373- END-IF. */
            }


            /*" -1377- COMPUTE WPRM-BASE = WPRM-BASE - V0HISR-PRERSP. */
            AREA_DE_WORK.WPRM_BASE.Value = AREA_DE_WORK.WPRM_BASE - V0HISR_PRERSP;

            /*" -1380- COMPUTE WPRECOT ROUNDED = WPRM-BASE * V0DRES-PCTCOT / 100. */
            AREA_DE_WORK.WPRECOT.Value = AREA_DE_WORK.WPRM_BASE * V0DRES_PCTCOT / 100f;

            /*" -1383- COMPUTE WCOMCOT ROUNDED = WPRECOT * V0DRES-PCTCOMCO / 100. */
            AREA_DE_WORK.WCOMCOT.Value = AREA_DE_WORK.WPRECOT * V0DRES_PCTCOMCO / 100f;

            /*" -1387- IF (WHOST-RAMOFR = 37 OR 73 OR 77 OR WHOST-RAMOFR = 80 OR 81 OR 82 OR WHOST-RAMOFR = 93 OR 97) OR (LKGE05-GRP-SUSEP = 09 OR 13) */

            if ((WHOST_RAMOFR.In("37", "73", "77") || WHOST_RAMOFR.In("80", "81", "82") || WHOST_RAMOFR.In("93", "97")) || (LK_GE0005S.LKGE05_GRP_SUSEP.In("09", "13")))
            {

                /*" -1392- COMPUTE WPREDNO ROUNDED = (WPRM-BASE - WPRECOT) * V0DRES-PCTDNO / 100 */
                AREA_DE_WORK.WPREDNO.Value = (AREA_DE_WORK.WPRM_BASE - AREA_DE_WORK.WPRECOT) * V0DRES_PCTDNO / 100f;

                /*" -1397- COMPUTE WPRECTF ROUNDED = (WPRM-BASE - WPRECOT - WPREDNO) * V0DRES-PCTCTF / 100 */
                AREA_DE_WORK.WPRECTF.Value = (AREA_DE_WORK.WPRM_BASE - AREA_DE_WORK.WPRECOT - AREA_DE_WORK.WPREDNO) * V0DRES_PCTCTF / 100f;

                /*" -1398- ELSE */
            }
            else
            {


                /*" -1402- COMPUTE WPREDNO ROUNDED = WPRM-BASE * V0DRES-PCTDNO / 100 */
                AREA_DE_WORK.WPREDNO.Value = AREA_DE_WORK.WPRM_BASE * V0DRES_PCTDNO / 100f;

                /*" -1405- COMPUTE WPRECTF ROUNDED = WPRM-BASE * V0DRES-PCTCTF / 100 */
                AREA_DE_WORK.WPRECTF.Value = AREA_DE_WORK.WPRM_BASE * V0DRES_PCTCTF / 100f;

                /*" -1407- END-IF. */
            }


            /*" -1408- IF WPRM-TAR-L = ZEROS */

            if (AREA_DE_WORK.WPRM_TAR_L == 00)
            {

                /*" -1412- MOVE ZEROS TO WPCTCOT WPCTCTF WPCTDNO WPCTCOMCO */
                _.Move(0, AREA_DE_WORK.WPCTCOT, AREA_DE_WORK.WPCTCTF, AREA_DE_WORK.WPCTDNO, AREA_DE_WORK.WPCTCOMCO);

                /*" -1413- ELSE */
            }
            else
            {


                /*" -1417- COMPUTE WPCTCOT ROUNDED = WPRECOT / WPRM-TAR-L * 100 */
                AREA_DE_WORK.WPCTCOT.Value = AREA_DE_WORK.WPRECOT / AREA_DE_WORK.WPRM_TAR_L * 100;

                /*" -1421- COMPUTE WPCTCTF ROUNDED = WPRECTF / WPRM-TAR-L * 100 */
                AREA_DE_WORK.WPCTCTF.Value = AREA_DE_WORK.WPRECTF / AREA_DE_WORK.WPRM_TAR_L * 100;

                /*" -1425- COMPUTE WPCTDNO ROUNDED = WPREDNO / WPRM-TAR-L * 100 */
                AREA_DE_WORK.WPCTDNO.Value = AREA_DE_WORK.WPREDNO / AREA_DE_WORK.WPRM_TAR_L * 100;

                /*" -1426- IF WPRECOT = ZEROS */

                if (AREA_DE_WORK.WPRECOT == 00)
                {

                    /*" -1427- MOVE ZEROS TO WPCTCOMCO */
                    _.Move(0, AREA_DE_WORK.WPCTCOMCO);

                    /*" -1428- ELSE */
                }
                else
                {


                    /*" -1431- COMPUTE WPCTCOMCO ROUNDED = WCOMCOT / WPRECOT * 100 */
                    AREA_DE_WORK.WPCTCOMCO.Value = AREA_DE_WORK.WCOMCOT / AREA_DE_WORK.WPRECOT * 100;

                    /*" -1432- END-IF */
                }


                /*" -1434- END-IF. */
            }


            /*" -1439- IF ((WHOST-RAMOFR = 39 OR 40 OR 45 OR 47 OR 50 OR 51 OR 67 OR 75 OR 76 OR 78) AND (WPCTRSP-PR NOT = ZEROS)) */

            if (((WHOST_RAMOFR.In("39", "40", "45", "47", "50", "51", "67", "75", "76", "78")) && (AREA_DE_WORK.WPCTRSP_PR != 00)))
            {

                /*" -1443- MOVE ZEROS TO WPCTCOT WPCTDNO WPCTCTF WPCTCOMCO */
                _.Move(0, AREA_DE_WORK.WPCTCOT, AREA_DE_WORK.WPCTDNO, AREA_DE_WORK.WPCTCTF, AREA_DE_WORK.WPCTCOMCO);

                /*" -1445- END-IF. */
            }


            /*" -1448- MOVE WPCTRSP-PR TO LKRE01-PCTRSP-PR LKRE01-PCTRSP-IS. */
            _.Move(AREA_DE_WORK.WPCTRSP_PR, LK_RE0001S.LKRE01_PCTRSP_PR, LK_RE0001S.LKRE01_PCTRSP_IS);

            /*" -1449- MOVE WPCTCOT TO LKRE01-PCTCOT. */
            _.Move(AREA_DE_WORK.WPCTCOT, LK_RE0001S.LKRE01_PCTCOT);

            /*" -1450- MOVE WPCTCTF TO LKRE01-PCTCTF. */
            _.Move(AREA_DE_WORK.WPCTCTF, LK_RE0001S.LKRE01_PCTCTF);

            /*" -1451- MOVE WPCTDNO TO LKRE01-PCTDNO. */
            _.Move(AREA_DE_WORK.WPCTDNO, LK_RE0001S.LKRE01_PCTDNO);

            /*" -1452- MOVE WPCTCOMCO TO LKRE01-PCTCOMCO. */
            _.Move(AREA_DE_WORK.WPCTCOMCO, LK_RE0001S.LKRE01_PCTCOMCO);

            /*" -1454- MOVE WPCTCOMER TO LKRE01-PCTCOMRS. */
            _.Move(AREA_DE_WORK.WPCTCOMER, LK_RE0001S.LKRE01_PCTCOMRS);

            /*" -1455- MOVE V0DRES-DTCUTOFF TO LKRE01-DTCUTOFF. */
            _.Move(V0DRES_DTCUTOFF, LK_RE0001S.LKRE01_DTCUTOFF);

            /*" -1457- MOVE V0DRES-RECUP-PSL TO LKRE01-RECP-PSL. */
            _.Move(V0DRES_RECUP_PSL, LK_RE0001S.LKRE01_RECP_PSL);

            /*" -1457- MOVE V0DRES-CONTR-RESG TO LKRE01-CONTR-RE. */
            _.Move(V0DRES_CONTR_RESG, LK_RE0001S.LKRE01_CONTR_RE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1472- MOVE SQLCODE TO LKRE01-SQL-CODE. */
            _.Move(DB.SQLCODE, LK_RE0001S.LKRE01_SQL_CODE);

            /*" -1472- GOBACK. */

            throw new GoBack();

        }
    }
}