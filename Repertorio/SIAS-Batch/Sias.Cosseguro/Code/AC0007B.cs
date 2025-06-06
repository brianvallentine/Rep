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
using Sias.Cosseguro.DB2.AC0007B;

namespace Code
{
    public class AC0007B
    {
        public bool IsCall { get; set; }

        public AC0007B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  ADMINISTRACAO DE COSSEGURO         *      */
        /*"      *   PROGRAMA ...............  AC0007B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA/PROGRAMADOR ...  CARLOS AAA                         *      */
        /*"      *   DATA CODIFICACAO .......  AGOSTO / 1996                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................- CARREGAR A TABELA DE COBERTURA  DE *      */
        /*"      *                             ASSISTENCIA 24 HORAS E ASSISTENCIA *      */
        /*"      *                             A SINISTROS,POR PARCELA COM COSSE- *      */
        /*"      *                             GURO CEDIDO, A  SER  UTILIZADA  NO *      */
        /*"      *                             PROGRAMA QUE CARREGA O CONTA  COR- *      */
        /*"      *                             RENTE DE COSSEGURO.                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * HISTORICO PARCELAS                  V0HISTOPARC       INPUT    *      */
        /*"      * APOLICES                            V0APOLICE         INPUT    *      */
        /*"      * ENDOSSOS                            V0ENDOSSO         INPUT    *      */
        /*"      * MR-APOLICE-COBER                    MR-APOLICE-COBER  INPUT    *      */
        /*"      * COBERTURAS DO AUTO                  V1AUTOCOBER       INPUT    *      */
        /*"      * COBERTURAS DE APOLICES              V1COBERAPOL       INPUT    *      */
        /*"      * MOVIMENTO DO HABITACIONAL           MOVIMENTO-HABIT   INPUT    *      */
        /*"      * RESSEGURO               CALL SUBROT RE0001S           INPUT    *      */
        /*"      * PARCELAS                            V0PARCELA         INPUT    *      */
        /*"      * COTACAO DE MOEDAS                   V0COTACAO         INPUT    *      */
        /*"      * COBERT 3103 + 3106 + 3107 + DIT     V0PARCELA_COMPL   OUTPUT   *      */
        /*"      * RAMO 66  CRED + REMUN + SUSEP       V0PARCELA_COMPL   OUTPUT   *      */
        /*"      * RAMO 68  RESSEGURO (EXCED + COTA)   V0PARCELA_COMPL   OUTPUT   *      */
        /*"      * COBERT 99 ( RAMO 16 E 18)           V0PARCELA_COMPL   OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * - A PARTIR DE NOV/1997 CARREGA A COBERTURA DIT - 8105 DA       *      */
        /*"      *   APOLICE  109700000025                                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * - A PARTIR DE DEZ/1998 CARREGA AS COBERTURAS REFERENTES AO RAMO*      */
        /*"      *   66, E 68 (HIPOTECARIO / HABITACIONAL SFH)                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * - A PARTIR DE AGO/2001 A TABELA MOVIMENTO-SFH FOI SUBSTITUIDA  *      */
        /*"      *   PELA MOVIMENTO-HABIT PARA O RAMO 66                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * - A PARTIR DE SET/2005 CARREGA A COBERTURA DE ASSIST. 24 HS    *      */
        /*"      *   PARA O CODIGO EMPR. 5495, E PRODUTOS 1601 E 1801, OU CODIGO  *      */
        /*"      *   EMPR. IGUAL A 0, E PRODUTOS 1602 E 1802                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * - A PARTIR DE JAN/2006 O ACESSO A TABELA MOVIMENTO-HABIT DEVERA*      */
        /*"      *   SER FEITO UTILIZANDO TAMBEM AS COLUNAS PARCELA E OCOR. HIST. *      */
        /*"      *   PROCURAR POR BOLDRI                                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   BRSEG - 29/06/07 - ALTERACAO SUBROTINA RE0001S               *      */
        /*"      *   PERC EXCED RESPONSABILIDADE - PREMIO E IS          VER BR.01 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - INCLUIR NO PARAMETRO DE SAIDA DA SUB-ROTN RE0001S *      */
        /*"      *              A DATA DO CUTOFF                                  *      */
        /*"      * 08/03/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 192299 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - INCLUIR NO PARAMETRO DE SAIDA DA SUB-ROTN RE0001S *      */
        /*"      *              O CODIGO DO CONTRATO DE RESSEGURO                 *      */
        /*"      * 12/10/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 212422 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         VIND-NRENDOS        PIC S9(004)                COMP.*/
        public IntBasis VIND_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HISP-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis V0HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-NRPARCEL     PIC S9(004)                COMP.*/
        public IntBasis V0HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-OCORHIST     PIC S9(004)                COMP.*/
        public IntBasis V0HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-OPERACAO     PIC S9(004)                COMP.*/
        public IntBasis V0HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-PRM-TAR      PIC S9(013)V99             COMP-3*/
        public DoubleBasis V0HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HISP-PRM-TAR-TOT  PIC S9(013)V99             COMP-3*/
        public DoubleBasis V0HISP_PRM_TAR_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0APOL-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0APOL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APOL-RAMO         PIC S9(004)                COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-MODALIDA     PIC S9(004)                COMP.*/
        public IntBasis V0APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-CODPRODU     PIC S9(004)                COMP.*/
        public IntBasis V0APOL_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-COD-EMPR     PIC S9(009)                COMP.*/
        public IntBasis V0APOL_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0ENDO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ENDO-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis V0ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-RAMO         PIC S9(004)                COMP.*/
        public IntBasis V0ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-CODPRODU     PIC S9(004)                COMP.*/
        public IntBasis V0ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-QTPARCEL     PIC S9(004)                COMP.*/
        public IntBasis V0ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-MOEDA-PRM    PIC S9(004)                COMP.*/
        public IntBasis V0ENDO_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-DTEMIS       PIC  X(010).*/
        public StringBasis V0ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DTINIVIG     PIC  X(010).*/
        public StringBasis V0ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DTTERVIG     PIC  X(010).*/
        public StringBasis V0ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-CORRECAO     PIC  X(001).*/
        public StringBasis V0ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-TIPO-ENDO    PIC  X(001).*/
        public StringBasis V0ENDO_TIPO_ENDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-COD-EMPR     PIC S9(009)                COMP.*/
        public IntBasis V0ENDO_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         MRAPCOB-NUM-APOL    PIC S9(013)                COMP-3*/
        public IntBasis MRAPCOB_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         MRAPCOB-NUM-ENDS    PIC S9(009)                COMP.*/
        public IntBasis MRAPCOB_NUM_ENDS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         MRAPCOB-PRM-TAR-VAR PIC S9(013)V99             COMP-3*/
        public DoubleBasis MRAPCOB_PRM_TAR_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1AUTC-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V1AUTC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1AUTC-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis V1AUTC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUTC-PRM-TAR-VAR  PIC S9(010)V9(05)          COMP-3*/
        public DoubleBasis V1AUTC_PRM_TAR_VAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
        /*"77         V1COBA-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V1COBA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1COBA-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis V1COBA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBA-PRM-TAR-VAR  PIC S9(010)V9(05)          COMP-3*/
        public DoubleBasis V1COBA_PRM_TAR_VAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
        /*"77         MOVHBT-NUM-APOL    PIC S9(013)                COMP-3.*/
        public IntBasis MOVHBT_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         MOVHBT-NUM-ENDS    PIC S9(009)                COMP.*/
        public IntBasis MOVHBT_NUM_ENDS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         MOVHBT-NRPARCEL    PIC S9(004)                COMP.*/
        public IntBasis MOVHBT_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         MOVHBT-OCORHIST    PIC S9(004)                COMP.*/
        public IntBasis MOVHBT_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         MOVHBT-PRM-MIP     PIC S9(013)V99             COMP-3.*/
        public DoubleBasis MOVHBT_PRM_MIP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         MOVHBT-PRM-DFI     PIC S9(013)V99             COMP-3.*/
        public DoubleBasis MOVHBT_PRM_DFI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         MOVHBT-PRM-CRED    PIC S9(013)V99             COMP-3.*/
        public DoubleBasis MOVHBT_PRM_CRED { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         MOVHBT-VAL-REMUN   PIC S9(013)V99             COMP-3.*/
        public DoubleBasis MOVHBT_VAL_REMUN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         MOVHBT-VAL-SUSEP   PIC S9(013)V99             COMP-3.*/
        public DoubleBasis MOVHBT_VAL_SUSEP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PARC-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PARC-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis V0PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PARC-PRMTAR-IX    PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V0PARC_PRMTAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COTA-CODUNIMO    PIC S9(004)                COMP.*/
        public IntBasis V0COTA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COTA-VALVENDA    PIC S9(006)V9(09)          COMP-3.*/
        public DoubleBasis V0COTA_VALVENDA { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(09)"), 9);
        /*"77         V0COTA-DTINIVIG    PIC  X(010).*/
        public StringBasis V0COTA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COTA-DTTERVIG    PIC  X(010).*/
        public StringBasis V0COTA_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PCOM-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0PCOM_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PCOM-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis V0PCOM_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PCOM-NRPARCEL     PIC S9(004)                COMP.*/
        public IntBasis V0PCOM_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PCOM-VLR-COMPL-IX PIC S9(010)V9(05)          COMP-3*/
        public DoubleBasis V0PCOM_VLR_COMPL_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
        /*"77         V0PCOM-VLR-COMPL    PIC S9(013)V99             COMP-3*/
        public DoubleBasis V0PCOM_VLR_COMPL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         AREA-DE-WORK.*/
        public AC0007B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0007B_AREA_DE_WORK();
        public class AC0007B_AREA_DE_WORK : VarBasis
        {
            /*"  05       WFIM-V0HISTOPARC    PIC  X(001)       VALUE SPACES.*/
            public StringBasis WFIM_V0HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       AC-L-V0HISTOPARC    PIC  9(007)       VALUE ZEROS.*/
            public IntBasis AC_L_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       AC-I-V0PARC-COMP    PIC  9(007)       VALUE ZEROS.*/
            public IntBasis AC_I_V0PARC_COMP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       WNUM-APOL-ANT       PIC S9(013)       VALUE +0 COMP-3*/
            public IntBasis WNUM_APOL_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05       WNRENDOS-ANT        PIC S9(009)       VALUE +0 COMP.*/
            public IntBasis WNRENDOS_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WVLR-COMPL          PIC S9(013)V99    VALUE +0 COMP-3*/
            public DoubleBasis WVLR_COMPL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WVLR-COMPL-IX       PIC S9(013)V9(5)  VALUE +0 COMP-3*/
            public DoubleBasis WVLR_COMPL_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05       WPRM-TARIF          PIC S9(013)V99    VALUE +0 COMP-3*/
            public DoubleBasis WPRM_TARIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WPRM-TARIF-IX       PIC S9(013)V9(5)  VALUE +0 COMP-3*/
            public DoubleBasis WPRM_TARIF_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05       WPRM-TAR-VAR        PIC S9(013)V9(5)  VALUE +0 COMP-3*/
            public DoubleBasis WPRM_TAR_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05       WS-VAL-COTA         PIC S9(010)V9(5)  VALUE +0 COMP-3*/
            public DoubleBasis WS_VAL_COTA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05       WS-VAL-EXCED        PIC S9(010)V9(5)  VALUE +0 COMP-3*/
            public DoubleBasis WS_VAL_EXCED { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05       WPROPORCAO          PIC S9(008)V9(9)  VALUE +0 COMP-3*/
            public DoubleBasis WPROPORCAO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(9)"), 9);
            /*"01         PARAMETROS-RE.*/
        }
        public AC0007B_PARAMETROS_RE PARAMETROS_RE { get; set; } = new AC0007B_PARAMETROS_RE();
        public class AC0007B_PARAMETROS_RE : VarBasis
        {
            /*"  05       LKRE-TIP-CALC       PIC  9(001)       VALUE ZEROS.*/
            public IntBasis LKRE_TIP_CALC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  05       LKRE-NUM-APOL       PIC  9(013)       VALUE ZEROS.*/
            public IntBasis LKRE_NUM_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05       LKRE-NRENDOS        PIC  9(009)       VALUE ZEROS.*/
            public IntBasis LKRE_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05       LKRE-DTINIVIG       PIC  X(010)       VALUE SPACES.*/
            public StringBasis LKRE_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05       LKRE-PCTCED         PIC  9(004)V9(9)  VALUE ZEROS.*/
            public DoubleBasis LKRE_PCTCED { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05       LKRE-RAMOFR         PIC  9(004)       VALUE ZEROS.*/
            public IntBasis LKRE_RAMOFR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05       LKRE-MODALIFR       PIC  9(004)       VALUE ZEROS.*/
            public IntBasis LKRE_MODALIFR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05       LKRE-PCTRSP         PIC  9(004)V9(9)  VALUE ZEROS.*/
            public DoubleBasis LKRE_PCTRSP { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05       LKRE-PCTRSP-IS      PIC  9(004)V9(9)  VALUE ZEROS.*/
            public DoubleBasis LKRE_PCTRSP_IS { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05       LKRE-PCTCOT         PIC  9(004)V9(9)  VALUE ZEROS.*/
            public DoubleBasis LKRE_PCTCOT { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05       LKRE-PCTCTF         PIC  9(004)V9(9)  VALUE ZEROS.*/
            public DoubleBasis LKRE_PCTCTF { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05       LKRE-PCTDNO         PIC  9(004)V9(9)  VALUE ZEROS.*/
            public DoubleBasis LKRE_PCTDNO { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05       LKRE-PCTCOMCO       PIC  9(004)V9(9)  VALUE ZEROS.*/
            public DoubleBasis LKRE_PCTCOMCO { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05       LKRE-PCTCOMRS       PIC  9(004)V9(9)  VALUE ZEROS.*/
            public DoubleBasis LKRE_PCTCOMRS { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05       LKRE-DTCUTOFF       PIC  X(010)       VALUE SPACES.*/
            public StringBasis LKRE_DTCUTOFF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05       LKRE-RECP-PSL       PIC  X(001)       VALUE SPACES.*/
            public StringBasis LKRE_RECP_PSL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       LKRE-CONTR-RE       PIC  X(025)       VALUE SPACES.*/
            public StringBasis LKRE_CONTR_RE { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
            /*"  05       LKRE-SQL-CODE       PIC  9(009)       VALUE ZEROS.*/
            public IntBasis LKRE_SQL_CODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05       LKRE-RTN-CODE       PIC  9(002)       VALUE ZEROS.*/
            public IntBasis LKRE_RTN_CODE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05       LKRE-MENSAGEM       PIC  X(040)       VALUE SPACES.*/
            public StringBasis LKRE_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"01        WABEND.*/
        }
        public AC0007B_WABEND WABEND { get; set; } = new AC0007B_WABEND();
        public class AC0007B_WABEND : VarBasis
        {
            /*"  05      FILLER              PIC  X(010) VALUE         ' AC0007B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" AC0007B");
            /*"  05      FILLER              PIC  X(026) VALUE         ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"  05      FILLER              PIC  X(013) VALUE         ' *** SQLCODE '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public AC0007B_V0HISTOPARC V0HISTOPARC { get; set; } = new AC0007B_V0HISTOPARC();
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
            /*" -294- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WABEND.WNR_EXEC_SQL);

            /*" -295- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -298- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -301- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -305- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -307- PERFORM R0900-00-DECLARE-V0HISTOPARC. */

            R0900_00_DECLARE_V0HISTOPARC_SECTION();

            /*" -309- PERFORM R0950-00-FETCH-V0HISTOPARC. */

            R0950_00_FETCH_V0HISTOPARC_SECTION();

            /*" -310- IF WFIM-V0HISTOPARC NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0HISTOPARC.IsEmpty())
            {

                /*" -311- DISPLAY 'AC0007B - NAO HOUVE MOVIMENTACAO PARA EXECUCAO' */
                _.Display($"AC0007B - NAO HOUVE MOVIMENTACAO PARA EXECUCAO");

                /*" -312- ELSE */
            }
            else
            {


                /*" -315- PERFORM R1000-00-PROCESSA-V0HISTOPARC UNTIL WFIM-V0HISTOPARC NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V0HISTOPARC.IsEmpty()))
                {

                    R1000_00_PROCESSA_V0HISTOPARC_SECTION();
                }
            }


            /*" -316- DISPLAY ' ' . */
            _.Display($" ");

            /*" -317- DISPLAY ' - LIDOS  V0HISTOPARC - ' AC-L-V0HISTOPARC. */
            _.Display($" - LIDOS  V0HISTOPARC - {AREA_DE_WORK.AC_L_V0HISTOPARC}");

            /*" -318- DISPLAY ' - INSERT V0PARC-COMP - ' AC-I-V0PARC-COMP. */
            _.Display($" - INSERT V0PARC-COMP - {AREA_DE_WORK.AC_I_V0PARC_COMP}");

            /*" -319- DISPLAY ' ' . */
            _.Display($" ");

            /*" -319- DISPLAY '****    AC0007B  -  FIM NORMAL    *****' . */
            _.Display($"****    AC0007B  -  FIM NORMAL    *****");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -323- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -327- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -327- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -340- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -345- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -348- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -349- DISPLAY 'R0100 - ERRO NO SELECT DA V1SISTEMA' */
                _.Display($"R0100 - ERRO NO SELECT DA V1SISTEMA");

                /*" -350- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -351- ELSE */
            }
            else
            {


                /*" -351- DISPLAY 'DATA DO SISTEMA AC - ' V1SIST-DTMOVABE. */
                _.Display($"DATA DO SISTEMA AC - {V1SIST_DTMOVABE}");
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -345- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'AC' END-EXEC. */

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
        /*" R0900-00-DECLARE-V0HISTOPARC-SECTION */
        private void R0900_00_DECLARE_V0HISTOPARC_SECTION()
        {
            /*" -364- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -387- PERFORM R0900_00_DECLARE_V0HISTOPARC_DB_DECLARE_1 */

            R0900_00_DECLARE_V0HISTOPARC_DB_DECLARE_1();

            /*" -389- PERFORM R0900_00_DECLARE_V0HISTOPARC_DB_OPEN_1 */

            R0900_00_DECLARE_V0HISTOPARC_DB_OPEN_1();

            /*" -392- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -393- DISPLAY 'R0900 - ERRO NO DECLARE DA V0HISTOPARC' */
                _.Display($"R0900 - ERRO NO DECLARE DA V0HISTOPARC");

                /*" -394- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -395- ELSE */
            }
            else
            {


                /*" -395- MOVE SPACES TO WFIM-V0HISTOPARC. */
                _.Move("", AREA_DE_WORK.WFIM_V0HISTOPARC);
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTOPARC-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0HISTOPARC_DB_DECLARE_1()
        {
            /*" -387- EXEC SQL DECLARE V0HISTOPARC CURSOR FOR SELECT A.NUM_APOLICE , A.NRENDOS , A.NRPARCEL , A.OCORHIST , A.PRM_TARIFARIO , B.RAMO , B.MODALIDA , B.CODPRODU , VALUE(B.COD_EMPRESA,+0) FROM SEGUROS.V0HISTOPARC A, SEGUROS.V0APOLICE B WHERE A.DTMOVTO = :V1SIST-DTMOVABE AND A.OCORHIST = 01 AND A.OPERACAO < 0200 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.RAMO IN (16,18,31,66,68,97) AND B.TIPSGU = '1' AND B.ORGAO = 10 ORDER BY A.NUM_APOLICE , A.NRENDOS , A.NRPARCEL , A.OCORHIST END-EXEC. */
            V0HISTOPARC = new AC0007B_V0HISTOPARC(true);
            string GetQuery_V0HISTOPARC()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.OCORHIST
							, 
							A.PRM_TARIFARIO
							, 
							B.RAMO
							, 
							B.MODALIDA
							, 
							B.CODPRODU
							, 
							VALUE(B.COD_EMPRESA
							,+0) 
							FROM SEGUROS.V0HISTOPARC A
							, 
							SEGUROS.V0APOLICE B 
							WHERE A.DTMOVTO = '{V1SIST_DTMOVABE}' 
							AND A.OCORHIST = 01 
							AND A.OPERACAO < 0200 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.RAMO IN (16
							,18
							,31
							,66
							,68
							,97) 
							AND B.TIPSGU = '1' 
							AND B.ORGAO = 10 
							ORDER BY A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.OCORHIST";

                return query;
            }
            V0HISTOPARC.GetQueryEvent += GetQuery_V0HISTOPARC;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTOPARC-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0HISTOPARC_DB_OPEN_1()
        {
            /*" -389- EXEC SQL OPEN V0HISTOPARC END-EXEC. */

            V0HISTOPARC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-FETCH-V0HISTOPARC-SECTION */
        private void R0950_00_FETCH_V0HISTOPARC_SECTION()
        {
            /*" -406- MOVE '095' TO WNR-EXEC-SQL. */
            _.Move("095", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0950_10_LER_V0HISTOPARC */

            R0950_10_LER_V0HISTOPARC();

        }

        [StopWatch]
        /*" R0950-10-LER-V0HISTOPARC */
        private void R0950_10_LER_V0HISTOPARC(bool isPerform = false)
        {
            /*" -420- PERFORM R0950_10_LER_V0HISTOPARC_DB_FETCH_1 */

            R0950_10_LER_V0HISTOPARC_DB_FETCH_1();

            /*" -423- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -424- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -425- MOVE 'S' TO WFIM-V0HISTOPARC */
                    _.Move("S", AREA_DE_WORK.WFIM_V0HISTOPARC);

                    /*" -425- PERFORM R0950_10_LER_V0HISTOPARC_DB_CLOSE_1 */

                    R0950_10_LER_V0HISTOPARC_DB_CLOSE_1();

                    /*" -427- ELSE */
                }
                else
                {


                    /*" -428- DISPLAY 'R0950 - ERRO NO FETCH DA V0HISTOPARC' */
                    _.Display($"R0950 - ERRO NO FETCH DA V0HISTOPARC");

                    /*" -429- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -430- ELSE */
                }

            }
            else
            {


                /*" -432- IF V0APOL-RAMO EQUAL 97 AND V0HISP-NUM-APOL NOT = 109700000025 */

                if (V0APOL_RAMO == 97 && V0HISP_NUM_APOL != 109700000025)
                {

                    /*" -433- GO TO R0950-10-LER-V0HISTOPARC */
                    new Task(() => R0950_10_LER_V0HISTOPARC()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -434- ELSE */
                }
                else
                {


                    /*" -436- IF V0APOL-RAMO EQUAL 68 AND V0HISP-NUM-APOL NOT = 6501000001 */

                    if (V0APOL_RAMO == 68 && V0HISP_NUM_APOL != 6501000001)
                    {

                        /*" -437- GO TO R0950-10-LER-V0HISTOPARC */
                        new Task(() => R0950_10_LER_V0HISTOPARC()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -438- ELSE */
                    }
                    else
                    {


                        /*" -439- IF V0APOL-RAMO EQUAL 16 OR 18 */

                        if (V0APOL_RAMO.In("16", "18"))
                        {

                            /*" -441- IF V0APOL-COD-EMPR = ZEROS AND (V0APOL-CODPRODU = 1602 OR 1802) */

                            if (V0APOL_COD_EMPR == 00 && (V0APOL_CODPRODU.In("1602", "1802")))
                            {

                                /*" -442- ADD 1 TO AC-L-V0HISTOPARC */
                                AREA_DE_WORK.AC_L_V0HISTOPARC.Value = AREA_DE_WORK.AC_L_V0HISTOPARC + 1;

                                /*" -443- ELSE */
                            }
                            else
                            {


                                /*" -445- IF V0APOL-COD-EMPR = 5495 AND (V0APOL-CODPRODU = 1601 OR 1801) */

                                if (V0APOL_COD_EMPR == 5495 && (V0APOL_CODPRODU.In("1601", "1801")))
                                {

                                    /*" -446- ADD 1 TO AC-L-V0HISTOPARC */
                                    AREA_DE_WORK.AC_L_V0HISTOPARC.Value = AREA_DE_WORK.AC_L_V0HISTOPARC + 1;

                                    /*" -447- ELSE */
                                }
                                else
                                {


                                    /*" -448- GO TO R0950-10-LER-V0HISTOPARC */
                                    new Task(() => R0950_10_LER_V0HISTOPARC()).RunSynchronously(); //GOTO
                                    return;//Recursividade detectada, cuidado...

                                    /*" -449- ELSE */
                                }

                            }

                        }
                        else
                        {


                            /*" -449- ADD 1 TO AC-L-V0HISTOPARC. */
                            AREA_DE_WORK.AC_L_V0HISTOPARC.Value = AREA_DE_WORK.AC_L_V0HISTOPARC + 1;
                        }

                    }

                }

            }


        }

        [StopWatch]
        /*" R0950-10-LER-V0HISTOPARC-DB-FETCH-1 */
        public void R0950_10_LER_V0HISTOPARC_DB_FETCH_1()
        {
            /*" -420- EXEC SQL FETCH V0HISTOPARC INTO :V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-OCORHIST , :V0HISP-PRM-TAR , :V0APOL-RAMO , :V0APOL-MODALIDA , :V0APOL-CODPRODU , :V0APOL-COD-EMPR END-EXEC. */

            if (V0HISTOPARC.Fetch())
            {
                _.Move(V0HISTOPARC.V0HISP_NUM_APOL, V0HISP_NUM_APOL);
                _.Move(V0HISTOPARC.V0HISP_NRENDOS, V0HISP_NRENDOS);
                _.Move(V0HISTOPARC.V0HISP_NRPARCEL, V0HISP_NRPARCEL);
                _.Move(V0HISTOPARC.V0HISP_OCORHIST, V0HISP_OCORHIST);
                _.Move(V0HISTOPARC.V0HISP_PRM_TAR, V0HISP_PRM_TAR);
                _.Move(V0HISTOPARC.V0APOL_RAMO, V0APOL_RAMO);
                _.Move(V0HISTOPARC.V0APOL_MODALIDA, V0APOL_MODALIDA);
                _.Move(V0HISTOPARC.V0APOL_CODPRODU, V0APOL_CODPRODU);
                _.Move(V0HISTOPARC.V0APOL_COD_EMPR, V0APOL_COD_EMPR);
            }

        }

        [StopWatch]
        /*" R0950-10-LER-V0HISTOPARC-DB-CLOSE-1 */
        public void R0950_10_LER_V0HISTOPARC_DB_CLOSE_1()
        {
            /*" -425- EXEC SQL CLOSE V0HISTOPARC END-EXEC */

            V0HISTOPARC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-V0HISTOPARC-SECTION */
        private void R1000_00_PROCESSA_V0HISTOPARC_SECTION()
        {
            /*" -462- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -464- PERFORM R1050-00-SELECT-V0ENDOSSO. */

            R1050_00_SELECT_V0ENDOSSO_SECTION();

            /*" -468- MOVE +0 TO WPRM-TARIF WPRM-TAR-VAR WPRM-TARIF-IX. */
            _.Move(+0, AREA_DE_WORK.WPRM_TARIF, AREA_DE_WORK.WPRM_TAR_VAR, AREA_DE_WORK.WPRM_TARIF_IX);

            /*" -469- MOVE V0HISP-NUM-APOL TO WNUM-APOL-ANT. */
            _.Move(V0HISP_NUM_APOL, AREA_DE_WORK.WNUM_APOL_ANT);

            /*" -471- MOVE V0HISP-NRENDOS TO WNRENDOS-ANT. */
            _.Move(V0HISP_NRENDOS, AREA_DE_WORK.WNRENDOS_ANT);

            /*" -472- IF V0APOL-RAMO = 16 OR 18 */

            if (V0APOL_RAMO.In("16", "18"))
            {

                /*" -477- IF V0ENDO-NUM-APOL = V0HISP-NUM-APOL AND V0ENDO-NRENDOS = V0HISP-NRENDOS AND V0ENDO-RAMO = V0APOL-RAMO AND V0ENDO-CODPRODU = V0APOL-CODPRODU AND V0ENDO-COD-EMPR = V0APOL-COD-EMPR */

                if (V0ENDO_NUM_APOL == V0HISP_NUM_APOL && V0ENDO_NRENDOS == V0HISP_NRENDOS && V0ENDO_RAMO == V0APOL_RAMO && V0ENDO_CODPRODU == V0APOL_CODPRODU && V0ENDO_COD_EMPR == V0APOL_COD_EMPR)
                {

                    /*" -478- PERFORM R1100-00-SUM-MR-APOL-COBT */

                    R1100_00_SUM_MR_APOL_COBT_SECTION();

                    /*" -479- MOVE MRAPCOB-PRM-TAR-VAR TO WPRM-TAR-VAR */
                    _.Move(MRAPCOB_PRM_TAR_VAR, AREA_DE_WORK.WPRM_TAR_VAR);

                    /*" -480- ELSE */
                }
                else
                {


                    /*" -481- DISPLAY 'R1000 - EMPRESA DA ENDS. DIFERE DA APOLICE' */
                    _.Display($"R1000 - EMPRESA DA ENDS. DIFERE DA APOLICE");

                    /*" -482- DISPLAY 'DADOS DA APOLICE' */
                    _.Display($"DADOS DA APOLICE");

                    /*" -483- DISPLAY 'APOLICE   - ' V0HISP-NUM-APOL */
                    _.Display($"APOLICE   - {V0HISP_NUM_APOL}");

                    /*" -484- DISPLAY 'ENDOSSO   - ' V0HISP-NRENDOS */
                    _.Display($"ENDOSSO   - {V0HISP_NRENDOS}");

                    /*" -485- DISPLAY 'COD RAMO  - ' V0APOL-RAMO */
                    _.Display($"COD RAMO  - {V0APOL_RAMO}");

                    /*" -486- DISPLAY 'COD PRODU - ' V0APOL-CODPRODU */
                    _.Display($"COD PRODU - {V0APOL_CODPRODU}");

                    /*" -487- DISPLAY 'COD EMPR  - ' V0APOL-COD-EMPR */
                    _.Display($"COD EMPR  - {V0APOL_COD_EMPR}");

                    /*" -488- DISPLAY 'DADOS DO ENDOSSO' */
                    _.Display($"DADOS DO ENDOSSO");

                    /*" -489- DISPLAY 'APOLICE   - ' V0ENDO-NUM-APOL */
                    _.Display($"APOLICE   - {V0ENDO_NUM_APOL}");

                    /*" -490- DISPLAY 'ENDOSSO   - ' V0ENDO-NRENDOS */
                    _.Display($"ENDOSSO   - {V0ENDO_NRENDOS}");

                    /*" -491- DISPLAY 'COD RAMO  - ' V0ENDO-RAMO */
                    _.Display($"COD RAMO  - {V0ENDO_RAMO}");

                    /*" -492- DISPLAY 'COD PRODU - ' V0ENDO-CODPRODU */
                    _.Display($"COD PRODU - {V0ENDO_CODPRODU}");

                    /*" -493- DISPLAY 'COD EMPR  - ' V0ENDO-COD-EMPR */
                    _.Display($"COD EMPR  - {V0ENDO_COD_EMPR}");

                    /*" -494- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -495- ELSE */
                }

            }
            else
            {


                /*" -496- IF V0APOL-RAMO = 31 */

                if (V0APOL_RAMO == 31)
                {

                    /*" -497- PERFORM R1200-00-SUM-V1AUTOCOBER */

                    R1200_00_SUM_V1AUTOCOBER_SECTION();

                    /*" -498- MOVE V1AUTC-PRM-TAR-VAR TO WPRM-TAR-VAR */
                    _.Move(V1AUTC_PRM_TAR_VAR, AREA_DE_WORK.WPRM_TAR_VAR);

                    /*" -499- ELSE */
                }
                else
                {


                    /*" -500- IF V0APOL-RAMO = 97 */

                    if (V0APOL_RAMO == 97)
                    {

                        /*" -501- PERFORM R1300-00-SELECT-V1COBERAPOL */

                        R1300_00_SELECT_V1COBERAPOL_SECTION();

                        /*" -502- MOVE V1COBA-PRM-TAR-VAR TO WPRM-TAR-VAR */
                        _.Move(V1COBA_PRM_TAR_VAR, AREA_DE_WORK.WPRM_TAR_VAR);

                        /*" -503- ELSE */
                    }
                    else
                    {


                        /*" -504- IF V0APOL-RAMO = 66 */

                        if (V0APOL_RAMO == 66)
                        {

                            /*" -505- PERFORM R1400-00-SELECT-MOVTO-HABIT */

                            R1400_00_SELECT_MOVTO_HABIT_SECTION();

                            /*" -508- COMPUTE WPRM-TAR-VAR = MOVHBT-PRM-CRED + MOVHBT-VAL-REMUN + MOVHBT-VAL-SUSEP */
                            AREA_DE_WORK.WPRM_TAR_VAR.Value = MOVHBT_PRM_CRED + MOVHBT_VAL_REMUN + MOVHBT_VAL_SUSEP;

                            /*" -509- ELSE */
                        }
                        else
                        {


                            /*" -510- IF V0APOL-RAMO = 68 */

                            if (V0APOL_RAMO == 68)
                            {

                                /*" -511- PERFORM R1500-00-PROCESSA-RESSEGURO */

                                R1500_00_PROCESSA_RESSEGURO_SECTION();

                                /*" -512- ELSE */
                            }
                            else
                            {


                                /*" -513- DISPLAY 'R1000 - CODIGO DE RAMO NAO PREVISTO' */
                                _.Display($"R1000 - CODIGO DE RAMO NAO PREVISTO");

                                /*" -514- DISPLAY 'APOLICE - ' V0HISP-NUM-APOL */
                                _.Display($"APOLICE - {V0HISP_NUM_APOL}");

                                /*" -515- DISPLAY 'ENDOSSO - ' V0HISP-NRENDOS */
                                _.Display($"ENDOSSO - {V0HISP_NRENDOS}");

                                /*" -516- DISPLAY 'RAMO    - ' V0APOL-RAMO */
                                _.Display($"RAMO    - {V0APOL_RAMO}");

                                /*" -518- GO TO R9999-00-ROT-ERRO. */

                                R9999_00_ROT_ERRO_SECTION(); //GOTO
                                return;
                            }

                        }

                    }

                }

            }


            /*" -520- IF (V0ENDO-TIPO-ENDO = '3' OR '5' ) AND WPRM-TAR-VAR < 0 */

            if ((V0ENDO_TIPO_ENDO.In("3", "5")) && AREA_DE_WORK.WPRM_TAR_VAR < 0)
            {

                /*" -522- COMPUTE WPRM-TAR-VAR = WPRM-TAR-VAR * -1. */
                AREA_DE_WORK.WPRM_TAR_VAR.Value = AREA_DE_WORK.WPRM_TAR_VAR * -1;
            }


            /*" -524- IF V0ENDO-TIPO-ENDO = '0' AND WPRM-TAR-VAR < 0 */

            if (V0ENDO_TIPO_ENDO == "0" && AREA_DE_WORK.WPRM_TAR_VAR < 0)
            {

                /*" -525- DISPLAY 'R1000 - VLR NAO PODE SER NEGATIVO PARA APOLICE' */
                _.Display($"R1000 - VLR NAO PODE SER NEGATIVO PARA APOLICE");

                /*" -526- DISPLAY 'APOLICE - ' V0HISP-NUM-APOL */
                _.Display($"APOLICE - {V0HISP_NUM_APOL}");

                /*" -527- DISPLAY 'ENDOSSO - ' V0HISP-NRENDOS */
                _.Display($"ENDOSSO - {V0HISP_NRENDOS}");

                /*" -529- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -533- IF ((WPRM-TAR-VAR = 0) OR (V0ENDO-TIPO-ENDO = '4' ) OR (V0ENDO-TIPO-ENDO = '1' AND WPRM-TAR-VAR < 0)) */

            if (((AREA_DE_WORK.WPRM_TAR_VAR == 0) || (V0ENDO_TIPO_ENDO == "4") || (V0ENDO_TIPO_ENDO == "1" && AREA_DE_WORK.WPRM_TAR_VAR < 0)))
            {

                /*" -537- PERFORM R0950-00-FETCH-V0HISTOPARC UNTIL WFIM-V0HISTOPARC NOT EQUAL SPACES OR V0HISP-NUM-APOL NOT EQUAL WNUM-APOL-ANT OR V0HISP-NRENDOS NOT EQUAL WNRENDOS-ANT */

                while (!(!AREA_DE_WORK.WFIM_V0HISTOPARC.IsEmpty() || V0HISP_NUM_APOL != AREA_DE_WORK.WNUM_APOL_ANT || V0HISP_NRENDOS != AREA_DE_WORK.WNRENDOS_ANT))
                {

                    R0950_00_FETCH_V0HISTOPARC_SECTION();
                }

                /*" -538- GO TO R1000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;

                /*" -539- ELSE */
            }
            else
            {


                /*" -541- PERFORM R1600-00-SELECT-V0COTACAO. */

                R1600_00_SELECT_V0COTACAO_SECTION();
            }


            /*" -542- IF V0APOL-RAMO = 31 */

            if (V0APOL_RAMO == 31)
            {

                /*" -544- MOVE ZEROS TO V0PARC-PRMTAR-IX V0HISP-PRM-TAR-TOT */
                _.Move(0, V0PARC_PRMTAR_IX, V0HISP_PRM_TAR_TOT);

                /*" -545- IF V0ENDO-CORRECAO = '1' */

                if (V0ENDO_CORRECAO == "1")
                {

                    /*" -546- PERFORM R1700-00-SUM-V0HISTOPARC */

                    R1700_00_SUM_V0HISTOPARC_SECTION();

                    /*" -550- COMPUTE WPROPORCAO ROUNDED = WPRM-TAR-VAR / V0HISP-PRM-TAR-TOT ON SIZE ERROR MOVE ZEROS TO WPROPORCAO END-COMPUTE */
                    if (V0HISP_PRM_TAR_TOT.Value == 0)
                        _.Move(0, AREA_DE_WORK.WPROPORCAO);
                    else

                        AREA_DE_WORK.WPROPORCAO.Value = AREA_DE_WORK.WPRM_TAR_VAR / V0HISP_PRM_TAR_TOT;

                    /*" -551- ELSE */
                }
                else
                {


                    /*" -552- PERFORM R1550-00-SELECT-V0PARCELA */

                    R1550_00_SELECT_V0PARCELA_SECTION();

                    /*" -557- COMPUTE WPROPORCAO ROUNDED = WPRM-TAR-VAR / V0PARC-PRMTAR-IX ON SIZE ERROR MOVE ZEROS TO WPROPORCAO END-COMPUTE */
                    if (V0PARC_PRMTAR_IX.Value == 0)
                        _.Move(0, AREA_DE_WORK.WPROPORCAO);
                    else

                        AREA_DE_WORK.WPROPORCAO.Value = AREA_DE_WORK.WPRM_TAR_VAR / V0PARC_PRMTAR_IX;

                    /*" -560- PERFORM R1800-00-PROCESSA-DOCUMENTO UNTIL WFIM-V0HISTOPARC NOT EQUAL SPACES OR V0HISP-NUM-APOL NOT EQUAL WNUM-APOL-ANT OR V0HISP-NRENDOS NOT EQUAL WNRENDOS-ANT. */

                    while (!(!AREA_DE_WORK.WFIM_V0HISTOPARC.IsEmpty() || V0HISP_NUM_APOL != AREA_DE_WORK.WNUM_APOL_ANT || V0HISP_NRENDOS != AREA_DE_WORK.WNRENDOS_ANT))
                    {

                        R1800_00_PROCESSA_DOCUMENTO_SECTION();
                    }
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-SELECT-V0ENDOSSO-SECTION */
        private void R1050_00_SELECT_V0ENDOSSO_SECTION()
        {
            /*" -573- MOVE '105' TO WNR-EXEC-SQL. */
            _.Move("105", WABEND.WNR_EXEC_SQL);

            /*" -597- PERFORM R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1 */

            R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1();

            /*" -600- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -601- DISPLAY 'R1050 - ERRO NO SELECT DA V0ENDOSSO' */
                _.Display($"R1050 - ERRO NO SELECT DA V0ENDOSSO");

                /*" -602- DISPLAY 'APOLICE - ' V0HISP-NUM-APOL */
                _.Display($"APOLICE - {V0HISP_NUM_APOL}");

                /*" -603- DISPLAY 'ENDOSSO - ' V0HISP-NRENDOS */
                _.Display($"ENDOSSO - {V0HISP_NRENDOS}");

                /*" -604- DISPLAY 'PARCELA - ' V0HISP-NRPARCEL */
                _.Display($"PARCELA - {V0HISP_NRPARCEL}");

                /*" -604- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1050-00-SELECT-V0ENDOSSO-DB-SELECT-1 */
        public void R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1()
        {
            /*" -597- EXEC SQL SELECT NUM_APOLICE , NRENDOS , RAMO , CODPRODU , QTPARCEL , COD_MOEDA_PRM , DTINIVIG , CORRECAO , TIPO_ENDOSSO , VALUE(COD_EMPRESA,+0) INTO :V0ENDO-NUM-APOL , :V0ENDO-NRENDOS , :V0ENDO-RAMO , :V0ENDO-CODPRODU , :V0ENDO-QTPARCEL , :V0ENDO-MOEDA-PRM , :V0ENDO-DTINIVIG , :V0ENDO-CORRECAO , :V0ENDO-TIPO-ENDO , :V0ENDO-COD-EMPR FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V0HISP-NUM-APOL AND NRENDOS = :V0HISP-NRENDOS END-EXEC. */

            var r1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 = new R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
            };

            var executed_1 = R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1.Execute(r1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_NUM_APOL, V0ENDO_NUM_APOL);
                _.Move(executed_1.V0ENDO_NRENDOS, V0ENDO_NRENDOS);
                _.Move(executed_1.V0ENDO_RAMO, V0ENDO_RAMO);
                _.Move(executed_1.V0ENDO_CODPRODU, V0ENDO_CODPRODU);
                _.Move(executed_1.V0ENDO_QTPARCEL, V0ENDO_QTPARCEL);
                _.Move(executed_1.V0ENDO_MOEDA_PRM, V0ENDO_MOEDA_PRM);
                _.Move(executed_1.V0ENDO_DTINIVIG, V0ENDO_DTINIVIG);
                _.Move(executed_1.V0ENDO_CORRECAO, V0ENDO_CORRECAO);
                _.Move(executed_1.V0ENDO_TIPO_ENDO, V0ENDO_TIPO_ENDO);
                _.Move(executed_1.V0ENDO_COD_EMPR, V0ENDO_COD_EMPR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SUM-MR-APOL-COBT-SECTION */
        private void R1100_00_SUM_MR_APOL_COBT_SECTION()
        {
            /*" -617- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WABEND.WNR_EXEC_SQL);

            /*" -625- PERFORM R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1 */

            R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1();

            /*" -628- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -629- DISPLAY 'R1100 - ERRO NO SELECT DA MR-APOLICE-COBER' */
                _.Display($"R1100 - ERRO NO SELECT DA MR-APOLICE-COBER");

                /*" -630- DISPLAY 'APOLICE - ' V0HISP-NUM-APOL */
                _.Display($"APOLICE - {V0HISP_NUM_APOL}");

                /*" -631- DISPLAY 'ENDOSSO - ' V0HISP-NRENDOS */
                _.Display($"ENDOSSO - {V0HISP_NRENDOS}");

                /*" -632- DISPLAY 'PARCELA - ' V0HISP-NRPARCEL */
                _.Display($"PARCELA - {V0HISP_NRPARCEL}");

                /*" -632- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-SUM-MR-APOL-COBT-DB-SELECT-1 */
        public void R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1()
        {
            /*" -625- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO_VAR),+0) INTO :MRAPCOB-PRM-TAR-VAR FROM SEGUROS.MR_APOLICE_COBER WHERE NUM_APOLICE = :V0HISP-NUM-APOL AND NUM_ENDOSSO = :V0HISP-NRENDOS AND RAMO_COBERTURA = :V0APOL-RAMO AND COD_COBERTURA = 099 END-EXEC. */

            var r1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1 = new R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            var executed_1 = R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1.Execute(r1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MRAPCOB_PRM_TAR_VAR, MRAPCOB_PRM_TAR_VAR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SUM-V1AUTOCOBER-SECTION */
        private void R1200_00_SUM_V1AUTOCOBER_SECTION()
        {
            /*" -645- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -654- PERFORM R1200_00_SUM_V1AUTOCOBER_DB_SELECT_1 */

            R1200_00_SUM_V1AUTOCOBER_DB_SELECT_1();

            /*" -657- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -658- DISPLAY 'R1200 - ERRO NO SELECT DA V1AUTOCOBER' */
                _.Display($"R1200 - ERRO NO SELECT DA V1AUTOCOBER");

                /*" -659- DISPLAY 'APOLICE - ' V0HISP-NUM-APOL */
                _.Display($"APOLICE - {V0HISP_NUM_APOL}");

                /*" -660- DISPLAY 'ENDOSSO - ' V0HISP-NRENDOS */
                _.Display($"ENDOSSO - {V0HISP_NRENDOS}");

                /*" -661- DISPLAY 'PARCELA - ' V0HISP-NRPARCEL */
                _.Display($"PARCELA - {V0HISP_NRPARCEL}");

                /*" -661- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SUM-V1AUTOCOBER-DB-SELECT-1 */
        public void R1200_00_SUM_V1AUTOCOBER_DB_SELECT_1()
        {
            /*" -654- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO_VAR),+0) INTO :V1AUTC-PRM-TAR-VAR FROM SEGUROS.V1AUTOCOBER WHERE NUM_APOLICE = :V0HISP-NUM-APOL AND NRENDOS = :V0HISP-NRENDOS AND RAMOFR = 31 AND MODALIFR = 00 AND COD_COBERTURA IN (3103,3106,3107) END-EXEC. */

            var r1200_00_SUM_V1AUTOCOBER_DB_SELECT_1_Query1 = new R1200_00_SUM_V1AUTOCOBER_DB_SELECT_1_Query1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
            };

            var executed_1 = R1200_00_SUM_V1AUTOCOBER_DB_SELECT_1_Query1.Execute(r1200_00_SUM_V1AUTOCOBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1AUTC_PRM_TAR_VAR, V1AUTC_PRM_TAR_VAR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V1COBERAPOL-SECTION */
        private void R1300_00_SELECT_V1COBERAPOL_SECTION()
        {
            /*" -674- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -684- PERFORM R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1 */

            R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1();

            /*" -687- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -688- DISPLAY 'R1300 - ERRO NO SELECT DA V1COBERAPOL' */
                _.Display($"R1300 - ERRO NO SELECT DA V1COBERAPOL");

                /*" -689- DISPLAY 'APOLICE - ' V0HISP-NUM-APOL */
                _.Display($"APOLICE - {V0HISP_NUM_APOL}");

                /*" -690- DISPLAY 'ENDOSSO - ' V0HISP-NRENDOS */
                _.Display($"ENDOSSO - {V0HISP_NRENDOS}");

                /*" -691- DISPLAY 'PARCELA - ' V0HISP-NRPARCEL */
                _.Display($"PARCELA - {V0HISP_NRPARCEL}");

                /*" -691- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-V1COBERAPOL-DB-SELECT-1 */
        public void R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1()
        {
            /*" -684- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO_VAR),+0) INTO :V1COBA-PRM-TAR-VAR FROM SEGUROS.V1COBERAPOL WHERE NUM_APOLICE = :V0HISP-NUM-APOL AND NRENDOS = :V0HISP-NRENDOS AND NUM_ITEM = 00 AND RAMOFR = 81 AND MODALIFR = 00 AND COD_COBERTURA = 05 END-EXEC. */

            var r1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1 = new R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
            };

            var executed_1 = R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1COBA_PRM_TAR_VAR, V1COBA_PRM_TAR_VAR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-MOVTO-HABIT-SECTION */
        private void R1400_00_SELECT_MOVTO_HABIT_SECTION()
        {
            /*" -704- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", WABEND.WNR_EXEC_SQL);

            /*" -720- PERFORM R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1 */

            R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1();

            /*" -723- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -724- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -727- MOVE ZEROS TO MOVHBT-PRM-CRED MOVHBT-VAL-REMUN MOVHBT-VAL-SUSEP */
                    _.Move(0, MOVHBT_PRM_CRED, MOVHBT_VAL_REMUN, MOVHBT_VAL_SUSEP);

                    /*" -728- ELSE */
                }
                else
                {


                    /*" -729- DISPLAY 'R1400 - ERRO NO SELECT DA MOVIMENTO-HABIT' */
                    _.Display($"R1400 - ERRO NO SELECT DA MOVIMENTO-HABIT");

                    /*" -730- DISPLAY 'APOLICE - ' V0HISP-NUM-APOL */
                    _.Display($"APOLICE - {V0HISP_NUM_APOL}");

                    /*" -731- DISPLAY 'ENDOSSO - ' V0HISP-NRENDOS */
                    _.Display($"ENDOSSO - {V0HISP_NRENDOS}");

                    /*" -732- DISPLAY 'PARCELA - ' V0HISP-NRPARCEL */
                    _.Display($"PARCELA - {V0HISP_NRPARCEL}");

                    /*" -733- DISPLAY 'OC. HIST- ' V0HISP-OCORHIST */
                    _.Display($"OC. HIST- {V0HISP_OCORHIST}");

                    /*" -733- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-MOVTO-HABIT-DB-SELECT-1 */
        public void R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1()
        {
            /*" -720- EXEC SQL SELECT NUM_APOLICE, NUM_ENDOSSO, VAL_PRM_CRED, VAL_REMUNERA, VAL_SUSEP INTO :MOVHBT-NUM-APOL, :MOVHBT-NUM-ENDS:VIND-NRENDOS, :MOVHBT-PRM-CRED, :MOVHBT-VAL-REMUN, :MOVHBT-VAL-SUSEP FROM SEGUROS.MOVIMENTO_HABIT WHERE NUM_APOLICE = :V0HISP-NUM-APOL AND NUM_ENDOSSO = :V0HISP-NRENDOS AND NUM_PARCELA = :V0HISP-NRPARCEL AND OCORR_HISTORICO = :V0HISP-OCORHIST END-EXEC. */

            var r1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1 = new R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V0HISP_OCORHIST = V0HISP_OCORHIST.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
            };

            var executed_1 = R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVHBT_NUM_APOL, MOVHBT_NUM_APOL);
                _.Move(executed_1.MOVHBT_NUM_ENDS, MOVHBT_NUM_ENDS);
                _.Move(executed_1.VIND_NRENDOS, VIND_NRENDOS);
                _.Move(executed_1.MOVHBT_PRM_CRED, MOVHBT_PRM_CRED);
                _.Move(executed_1.MOVHBT_VAL_REMUN, MOVHBT_VAL_REMUN);
                _.Move(executed_1.MOVHBT_VAL_SUSEP, MOVHBT_VAL_SUSEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-PROCESSA-RESSEGURO-SECTION */
        private void R1500_00_PROCESSA_RESSEGURO_SECTION()
        {
            /*" -746- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WABEND.WNR_EXEC_SQL);

            /*" -750- MOVE ZEROS TO WS-VAL-COTA WS-VAL-EXCED V0PARC-PRMTAR-IX. */
            _.Move(0, AREA_DE_WORK.WS_VAL_COTA, AREA_DE_WORK.WS_VAL_EXCED, V0PARC_PRMTAR_IX);

            /*" -766- MOVE ZEROS TO LKRE-TIP-CALC LKRE-NUM-APOL LKRE-NRENDOS LKRE-RAMOFR LKRE-MODALIFR LKRE-PCTCED LKRE-PCTRSP LKRE-PCTRSP-IS LKRE-PCTCOT LKRE-PCTCTF LKRE-PCTDNO LKRE-PCTCOMCO LKRE-PCTCOMRS LKRE-SQL-CODE LKRE-RTN-CODE. */
            _.Move(0, PARAMETROS_RE.LKRE_TIP_CALC, PARAMETROS_RE.LKRE_NUM_APOL, PARAMETROS_RE.LKRE_NRENDOS, PARAMETROS_RE.LKRE_RAMOFR, PARAMETROS_RE.LKRE_MODALIFR, PARAMETROS_RE.LKRE_PCTCED, PARAMETROS_RE.LKRE_PCTRSP, PARAMETROS_RE.LKRE_PCTRSP_IS, PARAMETROS_RE.LKRE_PCTCOT, PARAMETROS_RE.LKRE_PCTCTF, PARAMETROS_RE.LKRE_PCTDNO, PARAMETROS_RE.LKRE_PCTCOMCO, PARAMETROS_RE.LKRE_PCTCOMRS, PARAMETROS_RE.LKRE_SQL_CODE, PARAMETROS_RE.LKRE_RTN_CODE);

            /*" -772- MOVE SPACES TO LKRE-DTINIVIG LKRE-DTCUTOFF LKRE-RECP-PSL LKRE-CONTR-RE LKRE-MENSAGEM. */
            _.Move("", PARAMETROS_RE.LKRE_DTINIVIG, PARAMETROS_RE.LKRE_DTCUTOFF, PARAMETROS_RE.LKRE_RECP_PSL, PARAMETROS_RE.LKRE_CONTR_RE, PARAMETROS_RE.LKRE_MENSAGEM);

            /*" -773- MOVE 1 TO LKRE-TIP-CALC. */
            _.Move(1, PARAMETROS_RE.LKRE_TIP_CALC);

            /*" -774- MOVE V0HISP-NUM-APOL TO LKRE-NUM-APOL. */
            _.Move(V0HISP_NUM_APOL, PARAMETROS_RE.LKRE_NUM_APOL);

            /*" -775- MOVE V0HISP-NRENDOS TO LKRE-NRENDOS. */
            _.Move(V0HISP_NRENDOS, PARAMETROS_RE.LKRE_NRENDOS);

            /*" -776- MOVE V0APOL-RAMO TO LKRE-RAMOFR. */
            _.Move(V0APOL_RAMO, PARAMETROS_RE.LKRE_RAMOFR);

            /*" -777- MOVE V0APOL-MODALIDA TO LKRE-MODALIFR. */
            _.Move(V0APOL_MODALIDA, PARAMETROS_RE.LKRE_MODALIFR);

            /*" -778- MOVE ZEROS TO LKRE-PCTCED. */
            _.Move(0, PARAMETROS_RE.LKRE_PCTCED);

            /*" -780- MOVE V0ENDO-DTINIVIG TO LKRE-DTINIVIG. */
            _.Move(V0ENDO_DTINIVIG, PARAMETROS_RE.LKRE_DTINIVIG);

            /*" -782- CALL 'RE0001S' USING PARAMETROS-RE. */
            _.Call("RE0001S", PARAMETROS_RE);

            /*" -784- IF LKRE-RTN-CODE = ZEROS AND LKRE-SQL-CODE = ZEROS */

            if (PARAMETROS_RE.LKRE_RTN_CODE == 00 && PARAMETROS_RE.LKRE_SQL_CODE == 00)
            {

                /*" -785- PERFORM R1550-00-SELECT-V0PARCELA */

                R1550_00_SELECT_V0PARCELA_SECTION();

                /*" -786- ELSE */
            }
            else
            {


                /*" -787- DISPLAY 'R1500 - ERRO NO CALL DA SUB-ROTINA RE0001S' */
                _.Display($"R1500 - ERRO NO CALL DA SUB-ROTINA RE0001S");

                /*" -788- DISPLAY LKRE-MENSAGEM */
                _.Display(PARAMETROS_RE.LKRE_MENSAGEM);

                /*" -789- MOVE LKRE-SQL-CODE TO SQLCODE */
                _.Move(PARAMETROS_RE.LKRE_SQL_CODE, DB.SQLCODE);

                /*" -790- DISPLAY 'NUM-APOL - ' LKRE-NUM-APOL */
                _.Display($"NUM-APOL - {PARAMETROS_RE.LKRE_NUM_APOL}");

                /*" -791- DISPLAY 'NRENDOS  - ' LKRE-NRENDOS */
                _.Display($"NRENDOS  - {PARAMETROS_RE.LKRE_NRENDOS}");

                /*" -792- DISPLAY 'RAMOFR   - ' LKRE-RAMOFR */
                _.Display($"RAMOFR   - {PARAMETROS_RE.LKRE_RAMOFR}");

                /*" -793- DISPLAY 'MODALIFR - ' LKRE-MODALIFR */
                _.Display($"MODALIFR - {PARAMETROS_RE.LKRE_MODALIFR}");

                /*" -795- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -798- COMPUTE WS-VAL-EXCED ROUNDED = V0PARC-PRMTAR-IX * LKRE-PCTRSP / 100. */
            AREA_DE_WORK.WS_VAL_EXCED.Value = V0PARC_PRMTAR_IX * PARAMETROS_RE.LKRE_PCTRSP / 100f;

            /*" -802- COMPUTE WS-VAL-COTA ROUNDED = (V0PARC-PRMTAR-IX - WS-VAL-EXCED) * LKRE-PCTCOT / 100. */
            AREA_DE_WORK.WS_VAL_COTA.Value = (V0PARC_PRMTAR_IX - AREA_DE_WORK.WS_VAL_EXCED) * PARAMETROS_RE.LKRE_PCTCOT / 100f;

            /*" -802- COMPUTE WPRM-TAR-VAR = WS-VAL-EXCED + WS-VAL-COTA. */
            AREA_DE_WORK.WPRM_TAR_VAR.Value = AREA_DE_WORK.WS_VAL_EXCED + AREA_DE_WORK.WS_VAL_COTA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1550-00-SELECT-V0PARCELA-SECTION */
        private void R1550_00_SELECT_V0PARCELA_SECTION()
        {
            /*" -815- MOVE '155' TO WNR-EXEC-SQL. */
            _.Move("155", WABEND.WNR_EXEC_SQL);

            /*" -821- PERFORM R1550_00_SELECT_V0PARCELA_DB_SELECT_1 */

            R1550_00_SELECT_V0PARCELA_DB_SELECT_1();

            /*" -824- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -825- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -826- MOVE ZEROS TO V0PARC-PRMTAR-IX */
                    _.Move(0, V0PARC_PRMTAR_IX);

                    /*" -827- ELSE */
                }
                else
                {


                    /*" -828- DISPLAY 'R1550 - ERRO NO SELECT DA V0PARCELA' */
                    _.Display($"R1550 - ERRO NO SELECT DA V0PARCELA");

                    /*" -829- DISPLAY 'APOLICE - ' V0HISP-NUM-APOL */
                    _.Display($"APOLICE - {V0HISP_NUM_APOL}");

                    /*" -830- DISPLAY 'ENDOSSO - ' V0HISP-NRENDOS */
                    _.Display($"ENDOSSO - {V0HISP_NRENDOS}");

                    /*" -831- DISPLAY 'PARCELA - ' V0HISP-NRPARCEL */
                    _.Display($"PARCELA - {V0HISP_NRPARCEL}");

                    /*" -831- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1550-00-SELECT-V0PARCELA-DB-SELECT-1 */
        public void R1550_00_SELECT_V0PARCELA_DB_SELECT_1()
        {
            /*" -821- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO_IX),+0) INTO :V0PARC-PRMTAR-IX FROM SEGUROS.V0PARCELA WHERE NUM_APOLICE = :V0HISP-NUM-APOL AND NRENDOS = :V0HISP-NRENDOS END-EXEC. */

            var r1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1 = new R1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
            };

            var executed_1 = R1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1.Execute(r1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_PRMTAR_IX, V0PARC_PRMTAR_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1550_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-V0COTACAO-SECTION */
        private void R1600_00_SELECT_V0COTACAO_SECTION()
        {
            /*" -844- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", WABEND.WNR_EXEC_SQL);

            /*" -853- PERFORM R1600_00_SELECT_V0COTACAO_DB_SELECT_1 */

            R1600_00_SELECT_V0COTACAO_DB_SELECT_1();

            /*" -856- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -857- DISPLAY 'R1600 - ERRO NO SELECT DA V0COTACAO' */
                _.Display($"R1600 - ERRO NO SELECT DA V0COTACAO");

                /*" -858- DISPLAY 'APOLICE - ' V0HISP-NUM-APOL */
                _.Display($"APOLICE - {V0HISP_NUM_APOL}");

                /*" -859- DISPLAY 'ENDOSSO - ' V0HISP-NRENDOS */
                _.Display($"ENDOSSO - {V0HISP_NRENDOS}");

                /*" -860- DISPLAY 'PARCELA - ' V0HISP-NRPARCEL */
                _.Display($"PARCELA - {V0HISP_NRPARCEL}");

                /*" -861- DISPLAY 'MOEDA   - ' V0ENDO-MOEDA-PRM */
                _.Display($"MOEDA   - {V0ENDO_MOEDA_PRM}");

                /*" -862- DISPLAY 'INI VIG - ' V0ENDO-DTINIVIG */
                _.Display($"INI VIG - {V0ENDO_DTINIVIG}");

                /*" -862- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1600-00-SELECT-V0COTACAO-DB-SELECT-1 */
        public void R1600_00_SELECT_V0COTACAO_DB_SELECT_1()
        {
            /*" -853- EXEC SQL SELECT CODUNIMO, VAL_VENDA INTO :V0COTA-CODUNIMO, :V0COTA-VALVENDA FROM SEGUROS.V0COTACAO WHERE CODUNIMO = :V0ENDO-MOEDA-PRM AND DTINIVIG <= :V0ENDO-DTINIVIG AND DTTERVIG >= :V0ENDO-DTINIVIG END-EXEC. */

            var r1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 = new R1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1()
            {
                V0ENDO_MOEDA_PRM = V0ENDO_MOEDA_PRM.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = R1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1.Execute(r1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COTA_CODUNIMO, V0COTA_CODUNIMO);
                _.Move(executed_1.V0COTA_VALVENDA, V0COTA_VALVENDA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-SUM-V0HISTOPARC-SECTION */
        private void R1700_00_SUM_V0HISTOPARC_SECTION()
        {
            /*" -875- MOVE '170' TO WNR-EXEC-SQL. */
            _.Move("170", WABEND.WNR_EXEC_SQL);

            /*" -883- PERFORM R1700_00_SUM_V0HISTOPARC_DB_SELECT_1 */

            R1700_00_SUM_V0HISTOPARC_DB_SELECT_1();

            /*" -886- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -887- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -888- MOVE ZEROS TO V0HISP-PRM-TAR-TOT */
                    _.Move(0, V0HISP_PRM_TAR_TOT);

                    /*" -889- ELSE */
                }
                else
                {


                    /*" -890- DISPLAY 'R1700 - ERRO NO SELECT DA V0HISTOPARC' */
                    _.Display($"R1700 - ERRO NO SELECT DA V0HISTOPARC");

                    /*" -891- DISPLAY 'APOLICE - ' V0HISP-NUM-APOL */
                    _.Display($"APOLICE - {V0HISP_NUM_APOL}");

                    /*" -892- DISPLAY 'ENDOSSO - ' V0HISP-NRENDOS */
                    _.Display($"ENDOSSO - {V0HISP_NRENDOS}");

                    /*" -893- DISPLAY 'OC. HIST- ' V0HISP-OCORHIST */
                    _.Display($"OC. HIST- {V0HISP_OCORHIST}");

                    /*" -893- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1700-00-SUM-V0HISTOPARC-DB-SELECT-1 */
        public void R1700_00_SUM_V0HISTOPARC_DB_SELECT_1()
        {
            /*" -883- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO),+0) INTO :V0HISP-PRM-TAR-TOT FROM SEGUROS.V0HISTOPARC WHERE NUM_APOLICE = :V0HISP-NUM-APOL AND NRENDOS = :V0HISP-NRENDOS AND OCORHIST = :V0HISP-OCORHIST AND OPERACAO < 0200 END-EXEC. */

            var r1700_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1 = new R1700_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_OCORHIST = V0HISP_OCORHIST.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
            };

            var executed_1 = R1700_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1.Execute(r1700_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HISP_PRM_TAR_TOT, V0HISP_PRM_TAR_TOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-PROCESSA-DOCUMENTO-SECTION */
        private void R1800_00_PROCESSA_DOCUMENTO_SECTION()
        {
            /*" -906- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", WABEND.WNR_EXEC_SQL);

            /*" -907- IF V0ENDO-QTPARCEL = ZEROS */

            if (V0ENDO_QTPARCEL == 00)
            {

                /*" -908- MOVE WPRM-TAR-VAR TO WVLR-COMPL-IX */
                _.Move(AREA_DE_WORK.WPRM_TAR_VAR, AREA_DE_WORK.WVLR_COMPL_IX);

                /*" -910- COMPUTE WVLR-COMPL ROUNDED = WVLR-COMPL-IX * V0COTA-VALVENDA */
                AREA_DE_WORK.WVLR_COMPL.Value = AREA_DE_WORK.WVLR_COMPL_IX * V0COTA_VALVENDA;

                /*" -911- ELSE */
            }
            else
            {


                /*" -912- IF V0HISP-NRPARCEL < V0ENDO-QTPARCEL */

                if (V0HISP_NRPARCEL < V0ENDO_QTPARCEL)
                {

                    /*" -913- IF V0APOL-RAMO = 31 */

                    if (V0APOL_RAMO == 31)
                    {

                        /*" -915- COMPUTE WVLR-COMPL ROUNDED = V0HISP-PRM-TAR * WPROPORCAO */
                        AREA_DE_WORK.WVLR_COMPL.Value = V0HISP_PRM_TAR * AREA_DE_WORK.WPROPORCAO;

                        /*" -917- COMPUTE WVLR-COMPL-IX ROUNDED = WVLR-COMPL / V0COTA-VALVENDA */
                        AREA_DE_WORK.WVLR_COMPL_IX.Value = AREA_DE_WORK.WVLR_COMPL / V0COTA_VALVENDA;

                        /*" -918- ADD WVLR-COMPL-IX TO WPRM-TARIF-IX */
                        AREA_DE_WORK.WPRM_TARIF_IX.Value = AREA_DE_WORK.WPRM_TARIF_IX + AREA_DE_WORK.WVLR_COMPL_IX;

                        /*" -919- ADD WVLR-COMPL TO WPRM-TARIF */
                        AREA_DE_WORK.WPRM_TARIF.Value = AREA_DE_WORK.WPRM_TARIF + AREA_DE_WORK.WVLR_COMPL;

                        /*" -920- ELSE */
                    }
                    else
                    {


                        /*" -922- COMPUTE WVLR-COMPL-IX ROUNDED = WPRM-TAR-VAR / V0ENDO-QTPARCEL */
                        AREA_DE_WORK.WVLR_COMPL_IX.Value = AREA_DE_WORK.WPRM_TAR_VAR / V0ENDO_QTPARCEL;

                        /*" -924- COMPUTE WVLR-COMPL ROUNDED = WVLR-COMPL-IX * V0COTA-VALVENDA */
                        AREA_DE_WORK.WVLR_COMPL.Value = AREA_DE_WORK.WVLR_COMPL_IX * V0COTA_VALVENDA;

                        /*" -925- ADD WVLR-COMPL-IX TO WPRM-TARIF-IX */
                        AREA_DE_WORK.WPRM_TARIF_IX.Value = AREA_DE_WORK.WPRM_TARIF_IX + AREA_DE_WORK.WVLR_COMPL_IX;

                        /*" -926- ADD WVLR-COMPL TO WPRM-TARIF */
                        AREA_DE_WORK.WPRM_TARIF.Value = AREA_DE_WORK.WPRM_TARIF + AREA_DE_WORK.WVLR_COMPL;

                        /*" -927- ELSE */
                    }

                }
                else
                {


                    /*" -929- COMPUTE WVLR-COMPL-IX = WPRM-TAR-VAR - WPRM-TARIF-IX */
                    AREA_DE_WORK.WVLR_COMPL_IX.Value = AREA_DE_WORK.WPRM_TAR_VAR - AREA_DE_WORK.WPRM_TARIF_IX;

                    /*" -935- COMPUTE WVLR-COMPL ROUNDED = (WPRM-TAR-VAR * V0COTA-VALVENDA) - WPRM-TARIF. */
                    AREA_DE_WORK.WVLR_COMPL.Value = (AREA_DE_WORK.WPRM_TAR_VAR * V0COTA_VALVENDA) - AREA_DE_WORK.WPRM_TARIF;
                }

            }


            /*" -936- MOVE V0HISP-NUM-APOL TO V0PCOM-NUM-APOL. */
            _.Move(V0HISP_NUM_APOL, V0PCOM_NUM_APOL);

            /*" -937- MOVE V0HISP-NRENDOS TO V0PCOM-NRENDOS. */
            _.Move(V0HISP_NRENDOS, V0PCOM_NRENDOS);

            /*" -939- MOVE V0HISP-NRPARCEL TO V0PCOM-NRPARCEL. */
            _.Move(V0HISP_NRPARCEL, V0PCOM_NRPARCEL);

            /*" -941- MOVE WVLR-COMPL TO V0PCOM-VLR-COMPL. */
            _.Move(AREA_DE_WORK.WVLR_COMPL, V0PCOM_VLR_COMPL);

            /*" -942- IF V0ENDO-MOEDA-PRM = 01 */

            if (V0ENDO_MOEDA_PRM == 01)
            {

                /*" -943- MOVE WVLR-COMPL TO V0PCOM-VLR-COMPL-IX */
                _.Move(AREA_DE_WORK.WVLR_COMPL, V0PCOM_VLR_COMPL_IX);

                /*" -944- ELSE */
            }
            else
            {


                /*" -947- MOVE WVLR-COMPL-IX TO V0PCOM-VLR-COMPL-IX. */
                _.Move(AREA_DE_WORK.WVLR_COMPL_IX, V0PCOM_VLR_COMPL_IX);
            }


            /*" -949- PERFORM R2000-00-INSERT-V0PARC-COMPL. */

            R2000_00_INSERT_V0PARC_COMPL_SECTION();

            /*" -949- PERFORM R0950-00-FETCH-V0HISTOPARC. */

            R0950_00_FETCH_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-INSERT-V0PARC-COMPL-SECTION */
        private void R2000_00_INSERT_V0PARC_COMPL_SECTION()
        {
            /*" -962- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WABEND.WNR_EXEC_SQL);

            /*" -970- PERFORM R2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1 */

            R2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1();

            /*" -973- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -974- DISPLAY 'APOLICE - ' V0HISP-NUM-APOL */
                _.Display($"APOLICE - {V0HISP_NUM_APOL}");

                /*" -975- DISPLAY 'ENDOSSO - ' V0HISP-NRENDOS */
                _.Display($"ENDOSSO - {V0HISP_NRENDOS}");

                /*" -976- DISPLAY 'PARCELA - ' V0HISP-NRPARCEL */
                _.Display($"PARCELA - {V0HISP_NRPARCEL}");

                /*" -977- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -978- DISPLAY 'R2000 - REGISTRO DUPLICADO V0PARCELA-COMPL' */
                    _.Display($"R2000 - REGISTRO DUPLICADO V0PARCELA-COMPL");

                    /*" -979- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -980- ELSE */
                }
                else
                {


                    /*" -981- DISPLAY 'R2000 - ERRO NO INSERT DA V0PARCELA-COMPL' */
                    _.Display($"R2000 - ERRO NO INSERT DA V0PARCELA-COMPL");

                    /*" -982- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -983- ELSE */
                }

            }
            else
            {


                /*" -983- ADD 1 TO AC-I-V0PARC-COMP. */
                AREA_DE_WORK.AC_I_V0PARC_COMP.Value = AREA_DE_WORK.AC_I_V0PARC_COMP + 1;
            }


        }

        [StopWatch]
        /*" R2000-00-INSERT-V0PARC-COMPL-DB-INSERT-1 */
        public void R2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1()
        {
            /*" -970- EXEC SQL INSERT INTO SEGUROS.V0PARCELA_COMPL VALUES (:V0PCOM-NUM-APOL , :V0PCOM-NRENDOS , :V0PCOM-NRPARCEL , :V0PCOM-VLR-COMPL-IX , :V0PCOM-VLR-COMPL , CURRENT TIMESTAMP) END-EXEC. */

            var r2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1 = new R2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1()
            {
                V0PCOM_NUM_APOL = V0PCOM_NUM_APOL.ToString(),
                V0PCOM_NRENDOS = V0PCOM_NRENDOS.ToString(),
                V0PCOM_NRPARCEL = V0PCOM_NRPARCEL.ToString(),
                V0PCOM_VLR_COMPL_IX = V0PCOM_VLR_COMPL_IX.ToString(),
                V0PCOM_VLR_COMPL = V0PCOM_VLR_COMPL.ToString(),
            };

            R2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1.Execute(r2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -997- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -999- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -999- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1003- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1003- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}