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
using Sias.VidaEmpresarial.DB2.VE0030B;

namespace Code
{
    public class VE0030B
    {
        public bool IsCall { get; set; }

        public VE0030B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------      */
        /*"      *      */
        /*"      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  EMPRESARIAL                        *      */
        /*"      *   PROGRAMA ...............  VE0030B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  LUIZ CARLOS                        *      */
        /*"      *   PROGRAMADOR ............  LUIZ CARLOS                        *      */
        /*"      *   DATA CODIFICACAO .......  ABRIL/1999                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ..............  CANCELAR SUBGRUPOS DO EMPRESARIAL,CON-*      */
        /*"      *                          FORME SOLICITACAO NA V0RELATORIO.     *      */
        /*"      *                          CANCELAMENTO POR SOLICITACAO (VEIAA). *      */
        /*"      *                          CANCELAMENTO POR FALTA PGTO (VE0029B).*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                      A L T E R A C O E S                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.06  *   VERSAO 06 - TAREFA 608033                                    *      */
        /*"      *   608033: Inclus�o de Owner em view no programa VE0030B        *      */
        /*"      *           - corre��o para transpila��o                         *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/04/2025 -  Raul Basili Rotta                           *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.06    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - CAD 37.768                                       *      */
        /*"      *                                                                *      */
        /*"      *               TRATAR SQLCODE 100 NA ROTINA                     *      */
        /*"      *                                     R0280-00-LER-V1AGENCIACEF  *      */
        /*"      *   EM 23/02/2010 - TERCIO FREITAS(FAST COMPUTER)                *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.05    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 04/11/2008 - INCLUIR CLAUSULA WITH UR NO SELECT     - WV1108   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  004 - 27/03/07 - MARCO    (CADMUS 2547)                       *      */
        /*"      *    TRATA O ABEND OCORRIDO NA V1PRODESCNEG (SQLCODE = 100)      *      */
        /*"      *                                             PROCURE POR V.4    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  003 - 03/06/04 - MANOEL MESSIAS                               *      */
        /*"      *    PASSA A CANCELAR A V0RELATORIOS PORQUE O TERMO E OUTRAS TA  *      */
        /*"      * BELAS JA ESTAVAM CANCELADAS.                                   *      */
        /*"      *                                             PROCURE POR MM0604 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  002 - 04/12/01 - MANOEL MESSIAS                               *      */
        /*"      *    PASSA A CANCELAR A V0PROPOSTAVA DEVIDO AO NOVO FATURAMENTO  *      */
        /*"      * DA ESPECIFICA E EMPRESARIAL NA ESTRUTURA DO MULTIPREMIADO.     *      */
        /*"      *                                             PROCURE POR MM1201 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  001 - 23/11/01 - MANOEL MESSIAS                               *      */
        /*"      *    ABEND NA LEITURA DA V0COMISSAO (-305), QUE RECUPEROU UMA CO-*      */
        /*"      * LUNA COM VALOR NULO, MAS, SEM A VARIAVEL INDICADORA.           *      */
        /*"      *                                             PROCURE POR MM1101 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * PRODESCNEG                          V0PRODESCNEG      INPUT    *      */
        /*"      * AGENCIACEF                          V0AGENCIACEF      INPUT    *      */
        /*"      * FUNCIOCEF                           V0FUNCIOCEF       INPUT    *      */
        /*"      * MALHACEF                            V0MALHACEF        INPUT    *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * RELATORIOS                          VORELATORIOS      I-O      *      */
        /*"      * PARCELAS                            V1PARCELA         I-O      *      */
        /*"      * NUMERACAO APOLICE/ENDOSSOS          V1NUMERO_AES      I-O      *      */
        /*"      * HISTORICO PARCELAS                  V0HISTOPARC       I-O      *      */
        /*"      * ENDOSSOS                            V0ENDOSSOS        I-O      *      */
        /*"      * TERMOADESAO                         V0TERMOADESAO     I-O      *      */
        /*"      * PRODCAMPANHA                        V0PRODCAMPANHA    I-O      *      */
        /*"      * COMISSAO                            V0PRODCAMPANHA    I-O      *      */
        /*"      * SUBGRUPO                            V0RELATORIOS      OUTPUT   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77           WOCORHIST         PIC S9(004)                 COMP*/
        public IntBasis WOCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           W0NAES-NRENDOCA   PIC S9(009)      VALUE +0   COMP*/
        public IntBasis W0NAES_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           WP-PRM-TAR        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VAL-DESC       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WP_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLPRMLIQ       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLADIFRA       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLCUSEMI       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLIOCC         PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLPRMTOT       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLPREMIO       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-PRM-TAR        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WC_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VAL-DESC       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WC_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLPRMLIQ       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WC_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLADIFRA       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WC_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLCUSEMI       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WC_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLIOCC         PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WC_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLPRMTOT       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WC_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLPREMIO       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WC_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         VIND-DTMOVTO        PIC S9(004)                COMP*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTQITBCO       PIC S9(004)                COMP*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-COD-EMP        PIC S9(004)                COMP*/
        public IntBasis VIND_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-COD-PRODU      PIC S9(004)                COMP*/
        public IntBasis VIND_COD_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTADESAO       PIC S9(004)                COMP*/
        public IntBasis VIND_DTADESAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CODPRP         PIC S9(004)                COMP*/
        public IntBasis VIND_CODPRP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NUMBIL         PIC S9(004)                COMP*/
        public IntBasis VIND_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-VLVARMON       PIC S9(004)                COMP*/
        public IntBasis VIND_VLVARMON { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1FUNC-NUM-MATRIC             PIC S9(015)  COMP-3*/
        public IntBasis V1FUNC_NUM_MATRIC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          V1FUNC-COD-ANGARIA            PIC S9(009)  COMP*/
        public IntBasis V1FUNC_COD_ANGARIA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          V1PROD-COD-ESCNEG             PIC S9(004)  COMP*/
        public IntBasis V1PROD_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1PROD-DTINIVIG               PIC  X(010)*/
        public StringBasis V1PROD_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01          V1PROD-DTTERVIG               PIC  X(010)*/
        public StringBasis V1PROD_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01          V1PROD-NUM-MATRIC             PIC S9(015)  COMP-3*/
        public IntBasis V1PROD_NUM_MATRIC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          V1AGENC-COD-AGENCIA           PIC S9(004)  COMP*/
        public IntBasis V1AGENC_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1AGENC-COD-SUREG             PIC S9(004)  COMP*/
        public IntBasis V1AGENC_COD_SUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1AGENC-COD-ESCNEG            PIC S9(004)  COMP*/
        public IntBasis V1AGENC_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1AGENC-SITUACAO              PIC  X(001)*/
        public StringBasis V1AGENC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01          V1MALHA-COD-SUREG             PIC S9(004)  COMP*/
        public IntBasis V1MALHA_COD_SUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1MALHA-COD-FONTE             PIC S9(004)  COMP*/
        public IntBasis V1MALHA_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1REL-COD-USUR                PIC  X(008)*/
        public StringBasis V1REL_COD_USUR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01          V1REL-NUM-APOL                PIC S9(013)  COMP-3*/
        public IntBasis V1REL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          V1REL-COD-SUBG                PIC S9(004)  COMP*/
        public IntBasis V1REL_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1REL-SIT-REGISTRO            PIC  X(001)*/
        public StringBasis V1REL_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01          V1SUB-NUM-APOL                PIC S9(013)  COMP-3*/
        public IntBasis V1SUB_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          V1SUB-COD-SUBG                PIC S9(004)  COMP*/
        public IntBasis V1SUB_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1SUB-SIT-REGISTRO            PIC  X(001)*/
        public StringBasis V1SUB_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1SIST-DTMOVABE     PIC  X(010)*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V0NAES-NRENDOCA     PIC S9(009)                COMP*/
        public IntBasis V0NAES_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-NUM-APOL    PIC S9(013)                 COMP-3*/
        public IntBasis V1ENDO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1ENDO-NRENDOS     PIC S9(009)                 COMP*/
        public IntBasis V1ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-CODSUBES    PIC S9(004)                 COMP*/
        public IntBasis V1ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-CODPRODU    PIC S9(004)                 COMP*/
        public IntBasis V1ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-ORGAO       PIC S9(004)                 COMP*/
        public IntBasis V1ENDO_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-RAMO        PIC S9(004)                 COMP*/
        public IntBasis V1ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-DTEMIS      PIC  X(010)*/
        public StringBasis V1ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1ENDO-NRRCAP      PIC S9(009)                 COMP*/
        public IntBasis V1ENDO_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-VLRCAP      PIC S9(013)V99              COMP-3*/
        public DoubleBasis V1ENDO_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1ENDO-BCORCAP     PIC S9(004)                 COMP*/
        public IntBasis V1ENDO_BCORCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-AGERCAP     PIC S9(004)                 COMP*/
        public IntBasis V1ENDO_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-DACRCAP     PIC  X(001)*/
        public StringBasis V1ENDO_DACRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1ENDO-IDRCAP      PIC  X(001)*/
        public StringBasis V1ENDO_IDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1ENDO-BCOCOBR     PIC S9(009)                 COMP*/
        public IntBasis V1ENDO_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-AGECOBR     PIC S9(009)                 COMP*/
        public IntBasis V1ENDO_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-DACCOBR     PIC  X(001)*/
        public StringBasis V1ENDO_DACCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1ENDO-DTINIVIG    PIC  X(010)*/
        public StringBasis V1ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1ENDO-DTTERVIG    PIC  X(010)*/
        public StringBasis V1ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1ENDO-QTPARCEL    PIC S9(004)                 COMP*/
        public IntBasis V1ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-SITUACAO    PIC  X(001)*/
        public StringBasis V1ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1ENDO-COD-EMP     PIC S9(009)                 COMP*/
        public IntBasis V1ENDO_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PARC-NUM-APOL    PIC S9(013)                 COMP-3*/
        public IntBasis V1PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1PARC-NRENDOS     PIC S9(009)                 COMP*/
        public IntBasis V1PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PARC-NRPARCEL    PIC S9(004)                 COMP*/
        public IntBasis V1PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-DACPARC     PIC  X(001)*/
        public StringBasis V1PARC_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1PARC-FONTE       PIC S9(004)                 COMP*/
        public IntBasis V1PARC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-NRTIT       PIC S9(013)                 COMP-3*/
        public IntBasis V1PARC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1PARC-OCORHIST    PIC S9(004)                 COMP*/
        public IntBasis V1PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-QTDDOC      PIC S9(004)                 COMP*/
        public IntBasis V1PARC_QTDDOC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-SITUACAO    PIC  X(001)*/
        public StringBasis V1PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1PARC-COD-EMP     PIC S9(009)                 COMP*/
        public IntBasis V1PARC_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PARC-NUM-APOL    PIC S9(013)                 COMP-3*/
        public IntBasis V0PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PARC-NRENDOS     PIC S9(009)                 COMP*/
        public IntBasis V0PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PARC-NRPARCEL    PIC S9(004)                 COMP*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-SITUACAO    PIC  X(001)*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1HISP-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V1HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1HISP-NRENDOS      PIC S9(009)                COMP*/
        public IntBasis V1HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HISP-NRPARCEL     PIC S9(004)                COMP*/
        public IntBasis V1HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-DACPARC      PIC  X(001)*/
        public StringBasis V1HISP_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1HISP-DTMOVTO      PIC  X(010)*/
        public StringBasis V1HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1HISP-OPERACAO     PIC S9(004)                COMP*/
        public IntBasis V1HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-HORAOPER     PIC  X(008)*/
        public StringBasis V1HISP_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77         V1HISP-OCORHIST     PIC S9(004)                COMP*/
        public IntBasis V1HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-PRM-TAR      PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VAL-DESC     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLPRMLIQ     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLADIFRA     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLCUSEMI     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLIOCC       PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLPRMTOT     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLPREMIO     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-DTVENCTO     PIC  X(010)*/
        public StringBasis V1HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1HISP-BCOCOBR      PIC S9(004)                COMP*/
        public IntBasis V1HISP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-AGECOBR      PIC S9(004)                COMP*/
        public IntBasis V1HISP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-NRAVISO      PIC S9(009)                COMP*/
        public IntBasis V1HISP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HISP-NRENDOCA     PIC S9(009)                COMP*/
        public IntBasis V1HISP_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HISP-SITCONTB     PIC  X(001)*/
        public StringBasis V1HISP_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1HISP-COD-USUARIO  PIC  X(008)*/
        public StringBasis V1HISP_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77         V1HISP-RNUDOC       PIC S9(009)                COMP*/
        public IntBasis V1HISP_RNUDOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HISP-DTQITBCO     PIC  X(010)*/
        public StringBasis V1HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1HISP-COD-EMPRESA  PIC S9(009)                COMP*/
        public IntBasis V1HISP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HISP-NRENDOS      PIC S9(009)                COMP*/
        public IntBasis V0HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-NRPARCEL     PIC S9(004)                COMP*/
        public IntBasis V0HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-DACPARC      PIC  X(001)*/
        public StringBasis V0HISP_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V0HISP-DTMOVTO      PIC  X(010)*/
        public StringBasis V0HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V0HISP-OPERACAO     PIC S9(004)                COMP*/
        public IntBasis V0HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-HORAOPER     PIC  X(008)*/
        public StringBasis V0HISP_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77         V0HISP-OCORHIST     PIC S9(004)                COMP*/
        public IntBasis V0HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-PRM-TAR      PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VAL-DESC     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLPRMLIQ     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLADIFRA     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLCUSEMI     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLIOCC       PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLPRMTOT     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLPREMIO     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-DTVENCTO     PIC  X(010)*/
        public StringBasis V0HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V0HISP-BCOCOBR      PIC S9(004)                COMP*/
        public IntBasis V0HISP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-AGECOBR      PIC S9(004)                COMP*/
        public IntBasis V0HISP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-NRAVISO      PIC S9(009)                COMP*/
        public IntBasis V0HISP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-NRENDOCA     PIC S9(009)                COMP*/
        public IntBasis V0HISP_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-SITCONTB     PIC  X(001)*/
        public StringBasis V0HISP_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V0HISP-COD-USUARIO  PIC  X(008)*/
        public StringBasis V0HISP_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77         V0HISP-RNUDOC       PIC S9(009)                COMP*/
        public IntBasis V0HISP_RNUDOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-DTQITBCO     PIC  X(010)*/
        public StringBasis V0HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V0HISP-COD-EMPRESA  PIC S9(009)                COMP*/
        public IntBasis V0HISP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PRODC-NUM-MATRIC             PIC S9(015)    COMP-3*/
        public IntBasis V0PRODC_NUM_MATRIC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0PRODC-DTOPER                 PIC  X(010)*/
        public StringBasis V0PRODC_DTOPER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V0PRODC-COD-AGENC              PIC S9(004)    COMP*/
        public IntBasis V0PRODC_COD_AGENC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PRODC-CODPRODAZ              PIC  X(003)*/
        public StringBasis V0PRODC_CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"77         V0PRODC-COD-OPER               PIC S9(004)    COMP*/
        public IntBasis V0PRODC_COD_OPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PRODC-COD-FONTE              PIC S9(004)    COMP*/
        public IntBasis V0PRODC_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PRODC-NUM-PROPO              PIC S9(009)    COMP*/
        public IntBasis V0PRODC_NUM_PROPO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PRODC-QTD-REALI              PIC S9(009)    COMP*/
        public IntBasis V0PRODC_QTD_REALI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PRODC-VL-COMI-RE             PIC S9(013)V99 COMP-3*/
        public DoubleBasis V0PRODC_VL_COMI_RE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PRODC-COD-PLANO              PIC S9(004)    COMP*/
        public IntBasis V0PRODC_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PRODC-DT-REFER               PIC X(010)*/
        public StringBasis V0PRODC_DT_REFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V0PRODC-SIT-CAMPAN             PIC X*/
        public StringBasis V0PRODC_SIT_CAMPAN { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
        /*"77         V0PRODC-SIT-INTERF             PIC X*/
        public StringBasis V0PRODC_SIT_INTERF { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
        /*"77         V0PRODC-SIT-DIARIO             PIC X*/
        public StringBasis V0PRODC_SIT_DIARIO { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
        /*"77          V0TERMO-NUM-APOLICE           PIC S9(013)     COMP-3*/
        public IntBasis V0TERMO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0TERMO-NUM-TERMO             PIC S9(011)     COMP-3*/
        public IntBasis V0TERMO_NUM_TERMO { get; set; } = new IntBasis(new PIC("S9", "11", "S9(011)"));
        /*"77          V0TERMO-COD-SUBG              PIC S9(004)     COMP*/
        public IntBasis V0TERMO_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0TERMO-DT-ADESAO             PIC  X(010)*/
        public StringBasis V0TERMO_DT_ADESAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0TERMO-DTADESAO-3M           PIC  X(010)*/
        public StringBasis V0TERMO_DTADESAO_3M { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0TERMO-COD-AGE-OP            PIC S9(004)     COMP*/
        public IntBasis V0TERMO_COD_AGE_OP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0TERMO-MAT-VEN               PIC S9(015)     COMP-3*/
        public IntBasis V0TERMO_MAT_VEN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77          V0TERMO-CODPDTVEN             PIC S9(009)     COMP*/
        public IntBasis V0TERMO_CODPDTVEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0TERMO-PCCOMVEN              PIC S9(003)V99  COMP-3*/
        public DoubleBasis V0TERMO_PCCOMVEN { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77          V0TERMO-CODPDTGER             PIC S9(009)     COMP*/
        public IntBasis V0TERMO_CODPDTGER { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0TERMO-PCCOMGER              PIC S9(003)V99  COMP-3*/
        public DoubleBasis V0TERMO_PCCOMGER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77          V0TERMO-PLANO-VGAP            PIC S9(009)     COMP*/
        public IntBasis V0TERMO_PLANO_VGAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0TERMO-PLANO-APC             PIC S9(009)     COMP*/
        public IntBasis V0TERMO_PLANO_APC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0TERMO-VL-COMI-AD            PIC S9(013)V99  COMP-3*/
        public DoubleBasis V0TERMO_VL_COMI_AD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0TERMO-QTD-VIDAS             PIC S9(004)     COMP*/
        public IntBasis V0TERMO_QTD_VIDAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0TERMO-PERI-PGTO             PIC S9(004)     COMP*/
        public IntBasis V0TERMO_PERI_PGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0TERMO-COD-USUR              PIC  X(008)*/
        public StringBasis V0TERMO_COD_USUR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77          V0TERMO-SITUACAO              PIC  X(001)*/
        public StringBasis V0TERMO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77          V0COMI-NUM-APOL               PIC S9(013)     COMP-3*/
        public IntBasis V0COMI_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0COMI-NRENDOS                PIC S9(009)     COMP*/
        public IntBasis V0COMI_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0COMI-NRCERTIF               PIC S9(015)     COMP-3*/
        public IntBasis V0COMI_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77          V0COMI-DIGCERT                PIC  X(001)*/
        public StringBasis V0COMI_DIGCERT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77          V0COMI-IDTPSEGU               PIC  X(001)*/
        public StringBasis V0COMI_IDTPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77          V0COMI-NRPARCEL               PIC S9(004)     COMP*/
        public IntBasis V0COMI_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0COMI-OPERACAO               PIC S9(004)     COMP*/
        public IntBasis V0COMI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0COMI-CODPDT                 PIC S9(009)     COMP*/
        public IntBasis V0COMI_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0COMI-RAMOFR                 PIC S9(004)     COMP*/
        public IntBasis V0COMI_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0COMI-MODALIFR               PIC S9(004)     COMP*/
        public IntBasis V0COMI_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0COMI-OCORHIST               PIC S9(004)     COMP*/
        public IntBasis V0COMI_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0COMI-FONTE                  PIC S9(004)     COMP*/
        public IntBasis V0COMI_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0COMI-CODCLIEN               PIC S9(009)     COMP*/
        public IntBasis V0COMI_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0COMI-VLCOMIS                PIC S9(013)V99  COMP-3*/
        public DoubleBasis V0COMI_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0COMI-DATCLO                 PIC  X(010)*/
        public StringBasis V0COMI_DATCLO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0COMI-NUMREC                 PIC S9(009)     COMP*/
        public IntBasis V0COMI_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0COMI-VALBAS                 PIC S9(013)V99  COMP-3*/
        public DoubleBasis V0COMI_VALBAS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0COMI-TIPCOM                 PIC  X(001)*/
        public StringBasis V0COMI_TIPCOM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77          V0COMI-QTPARCEL               PIC S9(004)     COMP*/
        public IntBasis V0COMI_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0COMI-PCCOMCOR               PIC S9(003)V99  COMP*/
        public DoubleBasis V0COMI_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77          V0COMI-PCDESCON               PIC S9(003)V99  COMP*/
        public DoubleBasis V0COMI_PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77          V0COMI-CODSUBES               PIC S9(004)     COMP*/
        public IntBasis V0COMI_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0COMI-DTMOVTO                PIC  X(010)*/
        public StringBasis V0COMI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0COMI-DATSEL                 PIC  X(010)*/
        public StringBasis V0COMI_DATSEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V0COMI-COD-EMPRESA            PIC S9(009)     COMP*/
        public IntBasis V0COMI_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0COMI-CODPRP                 PIC S9(009)     COMP*/
        public IntBasis V0COMI_CODPRP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0COMI-NUMBIL                 PIC S9(015)     COMP-3*/
        public IntBasis V0COMI_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77          V0COMI-VLVARMON               PIC S9(013)V99  COMP-3*/
        public DoubleBasis V0COMI_VLVARMON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0COMI-DTQITBCO               PIC  X(010)*/
        public StringBasis V0COMI_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01           AREA-DE-WORK*/
        public VE0030B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VE0030B_AREA_DE_WORK();
        public class VE0030B_AREA_DE_WORK : VarBasis
        {
            /*"  05         AC-L-V1PARCELA    PIC  9(007)    VALUE ZEROS*/
            public IntBasis AC_L_V1PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-V1ENDOSSO    PIC  9(007)    VALUE ZEROS*/
            public IntBasis AC_L_V1ENDOSSO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-C-V0HISTOPARC  PIC  9(007)    VALUE ZEROS*/
            public IntBasis AC_C_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-P-V0HISTOPARC  PIC  9(007)    VALUE ZEROS*/
            public IntBasis AC_P_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-V0RELATORIOS   PIC  9(007)    VALUE ZEROS*/
            public IntBasis AC_L_V0RELATORIOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-V0COMISSAO     PIC  9(007)    VALUE ZEROS*/
            public IntBasis AC_L_V0COMISSAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-UPDT-V1ENDOSSO PIC  9(007)    VALUE ZEROS*/
            public IntBasis AC_UPDT_V1ENDOSSO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-UPDT-V1PARCELA PIC  9(007)    VALUE ZEROS*/
            public IntBasis AC_UPDT_V1PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WFIM-V1SISTEMA    PIC  X(001)    VALUE SPACES*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PARCELA    PIC  X(001)    VALUE SPACES*/
            public StringBasis WFIM_V1PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0PARCELA    PIC  X(001)    VALUE SPACES*/
            public StringBasis WFIM_V0PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1HISTOPARC  PIC  X(001)    VALUE SPACES*/
            public StringBasis WFIM_V1HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0RELATORIOS   PIC  X(001)    VALUE SPACES*/
            public StringBasis WFIM_V0RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0COMISSAO     PIC  X(001)    VALUE SPACES*/
            public StringBasis WFIM_V0COMISSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1ENDOSSO    PIC  X(001)    VALUE SPACES*/
            public StringBasis WFIM_V1ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROD-DESC  PIC  X(001)    VALUE SPACES*/
            public StringBasis WFIM_V1PROD_DESC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-V1PARCELA    PIC  X(001)    VALUE SPACES*/
            public StringBasis WTEM_V1PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-V1HISTOPARC  PIC  X(001)    VALUE SPACES*/
            public StringBasis WTEM_V1HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-V1AGECEF     PIC  X(001)    VALUE SPACES*/
            public StringBasis WTEM_V1AGECEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WHOUVE-CANCELA    PIC  X(001)    VALUE SPACES*/
            public StringBasis WHOUVE_CANCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WDATA-REL         PIC  X(010)    VALUE SPACES*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REL*/
            private _REDEF_VE0030B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VE0030B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VE0030B_FILLER_0(); _.Move(WDATA_REL, _filler_0); VarBasis.RedefinePassValue(WDATA_REL, _filler_0, WDATA_REL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_REL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VE0030B_FILLER_0 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004)*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001)*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002)*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002)*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDAT-REL-LIT*/

                public _REDEF_VE0030B_FILLER_0()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VE0030B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VE0030B_WDAT_REL_LIT();
            public class VE0030B_WDAT_REL_LIT : VarBasis
            {
                /*"    10       WDAT-LIT-DIA      PIC  9(002)    VALUE ZEROS*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-MES      PIC  9(002)    VALUE ZEROS*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-ANO      PIC  9(004)    VALUE ZEROS*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WEMIS-DATA        PIC  X(010)    VALUE ZEROS*/
            }
            public StringBasis WEMIS_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WEMIS-DATA*/
            private _REDEF_VE0030B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VE0030B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VE0030B_FILLER_5(); _.Move(WEMIS_DATA, _filler_5); VarBasis.RedefinePassValue(WEMIS_DATA, _filler_5, WEMIS_DATA); _filler_5.ValueChanged += () => { _.Move(_filler_5, WEMIS_DATA); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WEMIS_DATA); }
            }  //Redefines
            public class _REDEF_VE0030B_FILLER_5 : VarBasis
            {
                /*"    10       WEMIS-ANOMES*/
                public VE0030B_WEMIS_ANOMES WEMIS_ANOMES { get; set; } = new VE0030B_WEMIS_ANOMES();
                public class VE0030B_WEMIS_ANOMES : VarBasis
                {
                    /*"      15     WEMI-ANO          PIC  9(004)*/
                    public IntBasis WEMI_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"      15     FILLER            PIC  X(001)*/
                    public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      15     WEMI-MES          PIC  9(002)*/
                    public IntBasis WEMI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"    10       FILLER            PIC  X(001)*/

                    public VE0030B_WEMIS_ANOMES()
                    {
                        WEMI_ANO.ValueChanged += OnValueChanged;
                        FILLER_6.ValueChanged += OnValueChanged;
                        WEMI_MES.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WEMI-DIA          PIC  9(002)*/
                public IntBasis WEMI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WSIST-DATA        PIC  X(010)    VALUE ZEROS*/

                public _REDEF_VE0030B_FILLER_5()
                {
                    WEMIS_ANOMES.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                    WEMI_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WSIST_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WSIST-DATA*/
            private _REDEF_VE0030B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_VE0030B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_VE0030B_FILLER_8(); _.Move(WSIST_DATA, _filler_8); VarBasis.RedefinePassValue(WSIST_DATA, _filler_8, WSIST_DATA); _filler_8.ValueChanged += () => { _.Move(_filler_8, WSIST_DATA); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WSIST_DATA); }
            }  //Redefines
            public class _REDEF_VE0030B_FILLER_8 : VarBasis
            {
                /*"    10       WSIST-ANOMES*/
                public VE0030B_WSIST_ANOMES WSIST_ANOMES { get; set; } = new VE0030B_WSIST_ANOMES();
                public class VE0030B_WSIST_ANOMES : VarBasis
                {
                    /*"      15     WSIS-ANO          PIC  9(004)*/
                    public IntBasis WSIS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"      15     FILLER            PIC  X(001)*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      15     WSIS-MES          PIC  9(002)*/
                    public IntBasis WSIS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"    10       FILLER            PIC  X(001)*/

                    public VE0030B_WSIST_ANOMES()
                    {
                        WSIS_ANO.ValueChanged += OnValueChanged;
                        FILLER_9.ValueChanged += OnValueChanged;
                        WSIS_MES.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WSIS-DIA          PIC  9(002)*/
                public IntBasis WSIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         CH-CHAVE-ATU*/

                public _REDEF_VE0030B_FILLER_8()
                {
                    WSIST_ANOMES.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    WSIS_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VE0030B_CH_CHAVE_ATU CH_CHAVE_ATU { get; set; } = new VE0030B_CH_CHAVE_ATU();
            public class VE0030B_CH_CHAVE_ATU : VarBasis
            {
                /*"    10       CH-APOLI-ATU      PIC  9(013)    VALUE ZEROS*/
                public IntBasis CH_APOLI_ATU { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    10       CH-ENDOS-ATU      PIC  9(006)    VALUE ZEROS*/
                public IntBasis CH_ENDOS_ATU { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"  05         CH-CHAVE-ANT*/
            }
            public VE0030B_CH_CHAVE_ANT CH_CHAVE_ANT { get; set; } = new VE0030B_CH_CHAVE_ANT();
            public class VE0030B_CH_CHAVE_ANT : VarBasis
            {
                /*"    10       CH-APOLI-ANT      PIC  9(013)    VALUE ZEROS*/
                public IntBasis CH_APOLI_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    10       CH-ENDOS-ANT      PIC  9(006)    VALUE ZEROS*/
                public IntBasis CH_ENDOS_ANT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"  05  W-DATA*/
            }
            public VE0030B_W_DATA W_DATA { get; set; } = new VE0030B_W_DATA();
            public class VE0030B_W_DATA : VarBasis
            {
                /*"    07  W-DD                    PIC  9(02)*/
                public IntBasis W_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    07  W-MM                    PIC  9(02)*/
                public IntBasis W_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    07  W-AA                    PIC  9(04)*/
                public IntBasis W_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"  05  W-DATA-EDITADA*/
            }
            public VE0030B_W_DATA_EDITADA W_DATA_EDITADA { get; set; } = new VE0030B_W_DATA_EDITADA();
            public class VE0030B_W_DATA_EDITADA : VarBasis
            {
                /*"    07  W-ANO                   PIC  9(04)*/
                public IntBasis W_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    07  FILLER                  PIC  X(01)*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    07  W-MES                   PIC  9(02)*/
                public IntBasis W_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    07  FILLER                  PIC  X(01)*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    07  W-DIA                   PIC  9(02)*/
                public IntBasis W_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"  05         WTIME-DAY         PIC  99.99.99.99*/
            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99"));
            /*"  05         FILLER            REDEFINES      WTIME-DAY*/
            private _REDEF_VE0030B_FILLER_13 _filler_13 { get; set; }
            public _REDEF_VE0030B_FILLER_13 FILLER_13
            {
                get { _filler_13 = new _REDEF_VE0030B_FILLER_13(); _.Move(WTIME_DAY, _filler_13); VarBasis.RedefinePassValue(WTIME_DAY, _filler_13, WTIME_DAY); _filler_13.ValueChanged += () => { _.Move(_filler_13, WTIME_DAY); }; return _filler_13; }
                set { VarBasis.RedefinePassValue(value, _filler_13, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_VE0030B_FILLER_13 : VarBasis
            {
                /*"    10       WTIME-DAYR*/
                public VE0030B_WTIME_DAYR WTIME_DAYR { get; set; } = new VE0030B_WTIME_DAYR();
                public class VE0030B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA        PIC  X(002)*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                    /*"      15     WTIME-2PT1        PIC  X(001)*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      15     WTIME-MINU        PIC  X(002)*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                    /*"      15     WTIME-2PT2        PIC  X(001)*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      15     WTIME-SEGU        PIC  X(002)*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                    /*"    10       WTIME-2PT3        PIC  X(001)*/

                    public VE0030B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WTIME-CCSG        PIC  X(002)*/
                public StringBasis WTIME_CCSG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"  05        WABEND*/

                public _REDEF_VE0030B_FILLER_13()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSG.ValueChanged += OnValueChanged;
                }

            }
            public VE0030B_WABEND WABEND { get; set; } = new VE0030B_WABEND();
            public class VE0030B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VE0030B '*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VE0030B ");
                /*"    10      FILLER              PIC  X(032) VALUE           '*** ERRO OCORRIDO PARAGRAFO NR '*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"*** ERRO OCORRIDO PARAGRAFO NR ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public VE0030B_V0RELATORIOS V0RELATORIOS { get; set; } = new VE0030B_V0RELATORIOS();
        public VE0030B_V1ENDOSSO V1ENDOSSO { get; set; } = new VE0030B_V1ENDOSSO();
        public VE0030B_V0COMISSAO V0COMISSAO { get; set; } = new VE0030B_V0COMISSAO();
        public VE0030B_V1PARCELA V1PARCELA { get; set; } = new VE0030B_V1PARCELA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -499- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -500- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -503- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -506- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -506- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -512- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -513- DISPLAY 'PROGRAMA EM EXECUCAO VE0030B  ' */
            _.Display($"PROGRAMA EM EXECUCAO VE0030B  ");

            /*" -514- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -515- DISPLAY 'VERSAO V.05 37.768 23/02/2010 ' */
            _.Display($"VERSAO V.05 37.768 23/02/2010 ");

            /*" -516- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -518- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -519- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -520- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -522- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -524- PERFORM R0200-00-DECLER-V0RELATORIOS. */

            R0200_00_DECLER_V0RELATORIOS_SECTION();

            /*" -525- PERFORM R0210-00-FETCH-V0RELATORIOS */

            R0210_00_FETCH_V0RELATORIOS_SECTION();

            /*" -526- IF WFIM-V0RELATORIOS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0RELATORIOS.IsEmpty())
            {

                /*" -527- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -529- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -532- PERFORM R0220-00-PROCESSA-V0RELATORIOS UNTIL WFIM-V0RELATORIOS NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0RELATORIOS.IsEmpty()))
            {

                R0220_00_PROCESSA_V0RELATORIOS_SECTION();
            }

            /*" -533- DISPLAY 'VE0030B - TERMINO PROCESSAMENTO NORMAL' */
            _.Display($"VE0030B - TERMINO PROCESSAMENTO NORMAL");

            /*" -535- DISPLAY '          SUBGRUPOS PROCESSADOS... ' AC-L-V0RELATORIOS */
            _.Display($"          SUBGRUPOS PROCESSADOS... {AREA_DE_WORK.AC_L_V0RELATORIOS}");

            /*" -537- DISPLAY '          ENDOSSOS CANCELADOS..... ' AC-UPDT-V1ENDOSSO */
            _.Display($"          ENDOSSOS CANCELADOS..... {AREA_DE_WORK.AC_UPDT_V1ENDOSSO}");

            /*" -538- DISPLAY '          PARCELAS CANCELADAS..... ' AC-UPDT-V1PARCELA. */
            _.Display($"          PARCELAS CANCELADAS..... {AREA_DE_WORK.AC_UPDT_V1PARCELA}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -543- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -545- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -545- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -558- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -564- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -567- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -568- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -569- DISPLAY 'VE0030B - SISTEMA DE COBRANCA NAO CADASTRADO' */
                    _.Display($"VE0030B - SISTEMA DE COBRANCA NAO CADASTRADO");

                    /*" -570- MOVE 'S' TO WFIM-V1SISTEMA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                    /*" -571- GO TO R0100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                    return;

                    /*" -572- ELSE */
                }
                else
                {


                    /*" -573- DISPLAY 'PROBLEMAS SELECT V1SISTEMA ... ' */
                    _.Display($"PROBLEMAS SELECT V1SISTEMA ... ");

                    /*" -575- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -577- MOVE V1SIST-DTMOVABE TO WSIST-DATA WDATA-REL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WSIST_DATA, AREA_DE_WORK.WDATA_REL);

            /*" -578- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -579- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -579- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -564- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CB' WITH UR END-EXEC. */

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
        /*" R0200-00-DECLER-V0RELATORIOS-SECTION */
        private void R0200_00_DECLER_V0RELATORIOS_SECTION()
        {
            /*" -592- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -601- PERFORM R0200_00_DECLER_V0RELATORIOS_DB_DECLARE_1 */

            R0200_00_DECLER_V0RELATORIOS_DB_DECLARE_1();

            /*" -603- PERFORM R0200_00_DECLER_V0RELATORIOS_DB_OPEN_1 */

            R0200_00_DECLER_V0RELATORIOS_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0200-00-DECLER-V0RELATORIOS-DB-DECLARE-1 */
        public void R0200_00_DECLER_V0RELATORIOS_DB_DECLARE_1()
        {
            /*" -601- EXEC SQL DECLARE V0RELATORIOS CURSOR FOR SELECT CODUSU, NUM_APOLICE, CODSUBES, SITUACAO FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'VE0030B' AND SITUACAO = '0' ORDER BY NUM_APOLICE, CODSUBES END-EXEC. */
            V0RELATORIOS = new VE0030B_V0RELATORIOS(false);
            string GetQuery_V0RELATORIOS()
            {
                var query = @$"SELECT CODUSU
							, 
							NUM_APOLICE
							, 
							CODSUBES
							, 
							SITUACAO 
							FROM SEGUROS.V0RELATORIOS 
							WHERE CODRELAT = 'VE0030B' 
							AND SITUACAO = '0' 
							ORDER BY NUM_APOLICE
							, CODSUBES";

                return query;
            }
            V0RELATORIOS.GetQueryEvent += GetQuery_V0RELATORIOS;

        }

        [StopWatch]
        /*" R0200-00-DECLER-V0RELATORIOS-DB-OPEN-1 */
        public void R0200_00_DECLER_V0RELATORIOS_DB_OPEN_1()
        {
            /*" -603- EXEC SQL OPEN V0RELATORIOS END-EXEC. */

            V0RELATORIOS.Open();

        }

        [StopWatch]
        /*" R0230-00-DECLER-V1ENDOSSO-DB-DECLARE-1 */
        public void R0230_00_DECLER_V1ENDOSSO_DB_DECLARE_1()
        {
            /*" -785- EXEC SQL DECLARE V1ENDOSSO CURSOR FOR SELECT NUM_APOLICE , NRENDOS , DTEMIS , DTINIVIG , DTTERVIG , BCORCAP , AGERCAP , DACRCAP , BCOCOBR , AGECOBR , DACCOBR , QTPARCEL , ORGAO , RAMO , CODPRODU FROM SEGUROS.V1ENDOSSO WHERE NUM_APOLICE = :V1REL-NUM-APOL AND CODSUBES = :V1REL-COD-SUBG AND SITUACAO = '0' AND TIPO_ENDOSSO = '1' ORDER BY NRENDOS END-EXEC. */
            V1ENDOSSO = new VE0030B_V1ENDOSSO(true);
            string GetQuery_V1ENDOSSO()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							NRENDOS
							, 
							DTEMIS
							, 
							DTINIVIG
							, 
							DTTERVIG
							, 
							BCORCAP
							, 
							AGERCAP
							, 
							DACRCAP
							, 
							BCOCOBR
							, 
							AGECOBR
							, 
							DACCOBR
							, 
							QTPARCEL
							, 
							ORGAO
							, 
							RAMO
							, 
							CODPRODU 
							FROM SEGUROS.V1ENDOSSO 
							WHERE NUM_APOLICE = '{V1REL_NUM_APOL}' 
							AND CODSUBES = '{V1REL_COD_SUBG}' 
							AND SITUACAO = '0' 
							AND TIPO_ENDOSSO = '1' 
							ORDER BY NRENDOS";

                return query;
            }
            V1ENDOSSO.GetQueryEvent += GetQuery_V1ENDOSSO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0RELATORIOS-SECTION */
        private void R0210_00_FETCH_V0RELATORIOS_SECTION()
        {
            /*" -616- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -621- PERFORM R0210_00_FETCH_V0RELATORIOS_DB_FETCH_1 */

            R0210_00_FETCH_V0RELATORIOS_DB_FETCH_1();

            /*" -624- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -625- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -626- MOVE 'S' TO WFIM-V0RELATORIOS */
                    _.Move("S", AREA_DE_WORK.WFIM_V0RELATORIOS);

                    /*" -626- PERFORM R0210_00_FETCH_V0RELATORIOS_DB_CLOSE_1 */

                    R0210_00_FETCH_V0RELATORIOS_DB_CLOSE_1();

                    /*" -628- ELSE */
                }
                else
                {


                    /*" -629- DISPLAY 'R0210 - PROBLEMAS FETCH V0RELATORIOS... ' */
                    _.Display($"R0210 - PROBLEMAS FETCH V0RELATORIOS... ");

                    /*" -630- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -631- ELSE */
                }

            }
            else
            {


                /*" -632- ADD 1 TO AC-L-V0RELATORIOS. */
                AREA_DE_WORK.AC_L_V0RELATORIOS.Value = AREA_DE_WORK.AC_L_V0RELATORIOS + 1;
            }


            /*" -638- DISPLAY '   APOLICE ------------> ' ' ' V1REL-COD-USUR ' ' V1REL-NUM-APOL ' ' V1REL-COD-SUBG ' ' V1REL-SIT-REGISTRO */

            $"   APOLICE ------------>  {V1REL_COD_USUR} {V1REL_NUM_APOL} {V1REL_COD_SUBG} {V1REL_SIT_REGISTRO}"
            .Display();

            /*" -639- IF AC-L-V0RELATORIOS GREATER 50 */

            if (AREA_DE_WORK.AC_L_V0RELATORIOS > 50)
            {

                /*" -639- DISPLAY 'CANCELAMENTOS ........ ' AC-L-V0RELATORIOS. */
                _.Display($"CANCELAMENTOS ........ {AREA_DE_WORK.AC_L_V0RELATORIOS}");
            }


        }

        [StopWatch]
        /*" R0210-00-FETCH-V0RELATORIOS-DB-FETCH-1 */
        public void R0210_00_FETCH_V0RELATORIOS_DB_FETCH_1()
        {
            /*" -621- EXEC SQL FETCH V0RELATORIOS INTO :V1REL-COD-USUR, :V1REL-NUM-APOL, :V1REL-COD-SUBG, :V1REL-SIT-REGISTRO END-EXEC. */

            if (V0RELATORIOS.Fetch())
            {
                _.Move(V0RELATORIOS.V1REL_COD_USUR, V1REL_COD_USUR);
                _.Move(V0RELATORIOS.V1REL_NUM_APOL, V1REL_NUM_APOL);
                _.Move(V0RELATORIOS.V1REL_COD_SUBG, V1REL_COD_SUBG);
                _.Move(V0RELATORIOS.V1REL_SIT_REGISTRO, V1REL_SIT_REGISTRO);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0RELATORIOS-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0RELATORIOS_DB_CLOSE_1()
        {
            /*" -626- EXEC SQL CLOSE V0RELATORIOS END-EXEC */

            V0RELATORIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-PROCESSA-V0RELATORIOS-SECTION */
        private void R0220_00_PROCESSA_V0RELATORIOS_SECTION()
        {
            /*" -652- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -655- MOVE SPACES TO WFIM-V1ENDOSSO. */
            _.Move("", AREA_DE_WORK.WFIM_V1ENDOSSO);

            /*" -656- PERFORM R0225-00-LER-V0TERMOADESAO. */

            R0225_00_LER_V0TERMOADESAO_SECTION();

            /*" -657- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -658- GO TO R0220-88-FETCH. */

                R0220_88_FETCH(); //GOTO
                return;
            }


            /*" -659- IF V0TERMO-SITUACAO EQUAL '2' */

            if (V0TERMO_SITUACAO == "2")
            {

                /*" -660- PERFORM R0410-00-UPDATE-V0RELATORIO */

                R0410_00_UPDATE_V0RELATORIO_SECTION();

                /*" -661- GO TO R0220-88-FETCH. */

                R0220_88_FETCH(); //GOTO
                return;
            }


            /*" -662- PERFORM R0230-00-DECLER-V1ENDOSSO */

            R0230_00_DECLER_V1ENDOSSO_SECTION();

            /*" -663- PERFORM R0240-00-FETCH-V1ENDOSSO */

            R0240_00_FETCH_V1ENDOSSO_SECTION();

            /*" -665- PERFORM R0250-00-PROCESSA-V1ENDOSSO UNTIL WFIM-V1ENDOSSO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1ENDOSSO.IsEmpty()))
            {

                R0250_00_PROCESSA_V1ENDOSSO_SECTION();
            }

            /*" -666- PERFORM R0260-00-CANCELA-V0SUBGRUPO. */

            R0260_00_CANCELA_V0SUBGRUPO_SECTION();

            /*" -667- PERFORM R0280-00-LER-V1AGENCIACEF. */

            R0280_00_LER_V1AGENCIACEF_SECTION();

            /*" -668- IF WTEM-V1AGECEF EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_V1AGECEF == "SIM")
            {

                /*" -669- PERFORM R0290-00-LER-V1MALHACEF */

                R0290_00_LER_V1MALHACEF_SECTION();

                /*" -670- END-IF. */
            }


            /*" -671- IF V0TERMO-DT-ADESAO NOT LESS '1995-08-14' */

            if (V0TERMO_DT_ADESAO >= "1995-08-14")
            {

                /*" -672- IF V0TERMO-VL-COMI-AD GREATER ZEROS */

                if (V0TERMO_VL_COMI_AD > 00)
                {

                    /*" -674- IF V0TERMO-PLANO-VGAP GREATER ZEROS OR V0TERMO-PLANO-APC GREATER ZEROS */

                    if (V0TERMO_PLANO_VGAP > 00 || V0TERMO_PLANO_APC > 00)
                    {

                        /*" -675- PERFORM R0300-00-ESTORNA-PRODCAMPANHA. */

                        R0300_00_ESTORNA_PRODCAMPANHA_SECTION();
                    }

                }

            }


            /*" -676- IF V1SIST-DTMOVABE NOT GREATER V0TERMO-DTADESAO-3M */

            if (V1SIST_DTMOVABE <= V0TERMO_DTADESAO_3M)
            {

                /*" -677- PERFORM R0320-00-ESTORNA-V0COMISSAO. */

                R0320_00_ESTORNA_V0COMISSAO_SECTION();
            }


            /*" -678- PERFORM R0400-00-CANCELA-V0TERMOADESAO. */

            R0400_00_CANCELA_V0TERMOADESAO_SECTION();

            /*" -679- PERFORM R0420-00-CANCELA-V0PROPOSTAVA. */

            R0420_00_CANCELA_V0PROPOSTAVA_SECTION();

            /*" -679- PERFORM R0410-00-UPDATE-V0RELATORIO. */

            R0410_00_UPDATE_V0RELATORIO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0220_88_FETCH */

            R0220_88_FETCH();

        }

        [StopWatch]
        /*" R0220-88-FETCH */
        private void R0220_88_FETCH(bool isPerform = false)
        {
            /*" -681- PERFORM R0210-00-FETCH-V0RELATORIOS. */

            R0210_00_FETCH_V0RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0225-00-LER-V0TERMOADESAO-SECTION */
        private void R0225_00_LER_V0TERMOADESAO_SECTION()
        {
            /*" -694- MOVE '0225' TO WNR-EXEC-SQL. */
            _.Move("0225", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -734- PERFORM R0225_00_LER_V0TERMOADESAO_DB_SELECT_1 */

            R0225_00_LER_V0TERMOADESAO_DB_SELECT_1();

            /*" -737- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -738- DISPLAY ' ' */
                _.Display($" ");

                /*" -739- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -740- DISPLAY 'R0225-00 - TERMOADESAO NAO CADASTRADO' */
                    _.Display($"R0225-00 - TERMOADESAO NAO CADASTRADO");

                    /*" -741- DISPLAY 'APOLICE......  ' V1REL-NUM-APOL */
                    _.Display($"APOLICE......  {V1REL_NUM_APOL}");

                    /*" -742- DISPLAY 'SUBGRUPO.....  ' V1REL-COD-SUBG */
                    _.Display($"SUBGRUPO.....  {V1REL_COD_SUBG}");

                    /*" -743- DISPLAY 'SQLCODE......  ' SQLCODE */
                    _.Display($"SQLCODE......  {DB.SQLCODE}");

                    /*" -744- ELSE */
                }
                else
                {


                    /*" -745- DISPLAY 'R0225-00 - PROBLEMAS ACESSO V0TERMOADESAO' */
                    _.Display($"R0225-00 - PROBLEMAS ACESSO V0TERMOADESAO");

                    /*" -746- DISPLAY 'APOLICE......  ' V1REL-NUM-APOL */
                    _.Display($"APOLICE......  {V1REL_NUM_APOL}");

                    /*" -747- DISPLAY 'SUBGRUPO.....  ' V1REL-COD-SUBG */
                    _.Display($"SUBGRUPO.....  {V1REL_COD_SUBG}");

                    /*" -748- DISPLAY 'SQLCODE......  ' SQLCODE */
                    _.Display($"SQLCODE......  {DB.SQLCODE}");

                    /*" -748- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0225-00-LER-V0TERMOADESAO-DB-SELECT-1 */
        public void R0225_00_LER_V0TERMOADESAO_DB_SELECT_1()
        {
            /*" -734- EXEC SQL SELECT NUM_TERMO, NUM_APOLICE, COD_SUBGRUPO, DATA_ADESAO, DATA_ADESAO + 3 MONTHS, COD_AGENCIA_OP, NUM_MATRICULA_VEN, CODPDTVEN, PCCOMVEN, CODPDTGER, PCCOMGER, COD_PLANO_VGAPC, COD_PLANO_APC, VAL_COMISSAO_ADIAN, QUANT_VIDAS, PERI_PAGAMENTO, COD_USUARIO, SITUACAO INTO :V0TERMO-NUM-TERMO, :V0TERMO-NUM-APOLICE, :V0TERMO-COD-SUBG, :V0TERMO-DT-ADESAO:VIND-DTADESAO, :V0TERMO-DTADESAO-3M:VIND-DTADESAO, :V0TERMO-COD-AGE-OP, :V0TERMO-MAT-VEN, :V0TERMO-CODPDTVEN, :V0TERMO-PCCOMVEN, :V0TERMO-CODPDTGER, :V0TERMO-PCCOMGER, :V0TERMO-PLANO-VGAP, :V0TERMO-PLANO-APC, :V0TERMO-VL-COMI-AD, :V0TERMO-QTD-VIDAS, :V0TERMO-PERI-PGTO, :V0TERMO-COD-USUR, :V0TERMO-SITUACAO FROM SEGUROS.V0TERMOADESAO WHERE NUM_APOLICE = :V1REL-NUM-APOL AND COD_SUBGRUPO = :V1REL-COD-SUBG END-EXEC. */

            var r0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1 = new R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1()
            {
                V1REL_NUM_APOL = V1REL_NUM_APOL.ToString(),
                V1REL_COD_SUBG = V1REL_COD_SUBG.ToString(),
            };

            var executed_1 = R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1.Execute(r0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0TERMO_NUM_TERMO, V0TERMO_NUM_TERMO);
                _.Move(executed_1.V0TERMO_NUM_APOLICE, V0TERMO_NUM_APOLICE);
                _.Move(executed_1.V0TERMO_COD_SUBG, V0TERMO_COD_SUBG);
                _.Move(executed_1.V0TERMO_DT_ADESAO, V0TERMO_DT_ADESAO);
                _.Move(executed_1.VIND_DTADESAO, VIND_DTADESAO);
                _.Move(executed_1.V0TERMO_DTADESAO_3M, V0TERMO_DTADESAO_3M);
                _.Move(executed_1.V0TERMO_COD_AGE_OP, V0TERMO_COD_AGE_OP);
                _.Move(executed_1.V0TERMO_MAT_VEN, V0TERMO_MAT_VEN);
                _.Move(executed_1.V0TERMO_CODPDTVEN, V0TERMO_CODPDTVEN);
                _.Move(executed_1.V0TERMO_PCCOMVEN, V0TERMO_PCCOMVEN);
                _.Move(executed_1.V0TERMO_CODPDTGER, V0TERMO_CODPDTGER);
                _.Move(executed_1.V0TERMO_PCCOMGER, V0TERMO_PCCOMGER);
                _.Move(executed_1.V0TERMO_PLANO_VGAP, V0TERMO_PLANO_VGAP);
                _.Move(executed_1.V0TERMO_PLANO_APC, V0TERMO_PLANO_APC);
                _.Move(executed_1.V0TERMO_VL_COMI_AD, V0TERMO_VL_COMI_AD);
                _.Move(executed_1.V0TERMO_QTD_VIDAS, V0TERMO_QTD_VIDAS);
                _.Move(executed_1.V0TERMO_PERI_PGTO, V0TERMO_PERI_PGTO);
                _.Move(executed_1.V0TERMO_COD_USUR, V0TERMO_COD_USUR);
                _.Move(executed_1.V0TERMO_SITUACAO, V0TERMO_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0225_99_SAIDA*/

        [StopWatch]
        /*" R0230-00-DECLER-V1ENDOSSO-SECTION */
        private void R0230_00_DECLER_V1ENDOSSO_SECTION()
        {
            /*" -761- MOVE '0230' TO WNR-EXEC-SQL. */
            _.Move("0230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -785- PERFORM R0230_00_DECLER_V1ENDOSSO_DB_DECLARE_1 */

            R0230_00_DECLER_V1ENDOSSO_DB_DECLARE_1();

            /*" -787- PERFORM R0230_00_DECLER_V1ENDOSSO_DB_OPEN_1 */

            R0230_00_DECLER_V1ENDOSSO_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0230-00-DECLER-V1ENDOSSO-DB-OPEN-1 */
        public void R0230_00_DECLER_V1ENDOSSO_DB_OPEN_1()
        {
            /*" -787- EXEC SQL OPEN V1ENDOSSO END-EXEC. */

            V1ENDOSSO.Open();

        }

        [StopWatch]
        /*" R0340-00-SEL-COMISSAO-ESTORNAR-DB-DECLARE-1 */
        public void R0340_00_SEL_COMISSAO_ESTORNAR_DB_DECLARE_1()
        {
            /*" -1175- EXEC SQL DECLARE V0COMISSAO CURSOR FOR SELECT NUM_APOLICE , NRENDOS , NRCERTIF, DIGCERT, IDTPSEGU, NRPARCEL, OPERACAO, CODPDT, RAMOFR, MODALIFR, OCORHIST, FONTE, CODCLIEN, VLCOMIS, DATCLO, NUMREC, VALBAS, TIPCOM, QTPARCEL, PCCOMCOR, PCDESCON, CODSUBES, DTMOVTO, DATSEL, COD_EMPRESA, CODPRP, NUMBIL, VLVARMON, DTQITBCO FROM SEGUROS.V0COMISSAO WHERE NUM_APOLICE = :V0COMI-NUM-APOL AND CODSUBES = :V0COMI-CODSUBES AND TIPCOM = :V0COMI-TIPCOM AND CODPDT = :V0COMI-CODPDT AND OPERACAO = :V0COMI-OPERACAO ORDER BY RAMOFR, OCORHIST END-EXEC. */
            V0COMISSAO = new VE0030B_V0COMISSAO(true);
            string GetQuery_V0COMISSAO()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							NRENDOS
							, 
							NRCERTIF
							, 
							DIGCERT
							, 
							IDTPSEGU
							, 
							NRPARCEL
							, 
							OPERACAO
							, 
							CODPDT
							, 
							RAMOFR
							, 
							MODALIFR
							, 
							OCORHIST
							, 
							FONTE
							, 
							CODCLIEN
							, 
							VLCOMIS
							, 
							DATCLO
							, 
							NUMREC
							, 
							VALBAS
							, 
							TIPCOM
							, 
							QTPARCEL
							, 
							PCCOMCOR
							, 
							PCDESCON
							, 
							CODSUBES
							, 
							DTMOVTO
							, 
							DATSEL
							, 
							COD_EMPRESA
							, 
							CODPRP
							, 
							NUMBIL
							, 
							VLVARMON
							, 
							DTQITBCO 
							FROM SEGUROS.V0COMISSAO 
							WHERE NUM_APOLICE = '{V0COMI_NUM_APOL}' 
							AND CODSUBES = '{V0COMI_CODSUBES}' 
							AND TIPCOM = '{V0COMI_TIPCOM}' 
							AND CODPDT = '{V0COMI_CODPDT}' 
							AND OPERACAO = '{V0COMI_OPERACAO}' 
							ORDER BY RAMOFR
							, 
							OCORHIST";

                return query;
            }
            V0COMISSAO.GetQueryEvent += GetQuery_V0COMISSAO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_99_SAIDA*/

        [StopWatch]
        /*" R0240-00-FETCH-V1ENDOSSO-SECTION */
        private void R0240_00_FETCH_V1ENDOSSO_SECTION()
        {
            /*" -800- MOVE '0240' TO WNR-EXEC-SQL. */
            _.Move("0240", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -816- PERFORM R0240_00_FETCH_V1ENDOSSO_DB_FETCH_1 */

            R0240_00_FETCH_V1ENDOSSO_DB_FETCH_1();

            /*" -819- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -820- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -821- MOVE 'S' TO WFIM-V1ENDOSSO */
                    _.Move("S", AREA_DE_WORK.WFIM_V1ENDOSSO);

                    /*" -821- PERFORM R0240_00_FETCH_V1ENDOSSO_DB_CLOSE_1 */

                    R0240_00_FETCH_V1ENDOSSO_DB_CLOSE_1();

                    /*" -823- ELSE */
                }
                else
                {


                    /*" -824- DISPLAY 'R0240 - PROBLEMAS FETCH V1ENDOSSO.... ' */
                    _.Display($"R0240 - PROBLEMAS FETCH V1ENDOSSO.... ");

                    /*" -825- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -826- ELSE */
                }

            }
            else
            {


                /*" -828- ADD 1 TO AC-L-V1ENDOSSO. */
                AREA_DE_WORK.AC_L_V1ENDOSSO.Value = AREA_DE_WORK.AC_L_V1ENDOSSO + 1;
            }


            /*" -829- IF VIND-COD-PRODU LESS ZEROS */

            if (VIND_COD_PRODU < 00)
            {

                /*" -829- MOVE ZEROS TO V1ENDO-CODPRODU. */
                _.Move(0, V1ENDO_CODPRODU);
            }


        }

        [StopWatch]
        /*" R0240-00-FETCH-V1ENDOSSO-DB-FETCH-1 */
        public void R0240_00_FETCH_V1ENDOSSO_DB_FETCH_1()
        {
            /*" -816- EXEC SQL FETCH V1ENDOSSO INTO :V1ENDO-NUM-APOL, :V1ENDO-NRENDOS, :V1ENDO-DTEMIS , :V1ENDO-DTINIVIG , :V1ENDO-DTTERVIG , :V1ENDO-BCORCAP , :V1ENDO-AGERCAP , :V1ENDO-DACRCAP , :V1ENDO-BCOCOBR , :V1ENDO-AGECOBR , :V1ENDO-DACCOBR , :V1ENDO-QTPARCEL , :V1ENDO-ORGAO , :V1ENDO-RAMO , :V1ENDO-CODPRODU:VIND-COD-PRODU END-EXEC. */

            if (V1ENDOSSO.Fetch())
            {
                _.Move(V1ENDOSSO.V1ENDO_NUM_APOL, V1ENDO_NUM_APOL);
                _.Move(V1ENDOSSO.V1ENDO_NRENDOS, V1ENDO_NRENDOS);
                _.Move(V1ENDOSSO.V1ENDO_DTEMIS, V1ENDO_DTEMIS);
                _.Move(V1ENDOSSO.V1ENDO_DTINIVIG, V1ENDO_DTINIVIG);
                _.Move(V1ENDOSSO.V1ENDO_DTTERVIG, V1ENDO_DTTERVIG);
                _.Move(V1ENDOSSO.V1ENDO_BCORCAP, V1ENDO_BCORCAP);
                _.Move(V1ENDOSSO.V1ENDO_AGERCAP, V1ENDO_AGERCAP);
                _.Move(V1ENDOSSO.V1ENDO_DACRCAP, V1ENDO_DACRCAP);
                _.Move(V1ENDOSSO.V1ENDO_BCOCOBR, V1ENDO_BCOCOBR);
                _.Move(V1ENDOSSO.V1ENDO_AGECOBR, V1ENDO_AGECOBR);
                _.Move(V1ENDOSSO.V1ENDO_DACCOBR, V1ENDO_DACCOBR);
                _.Move(V1ENDOSSO.V1ENDO_QTPARCEL, V1ENDO_QTPARCEL);
                _.Move(V1ENDOSSO.V1ENDO_ORGAO, V1ENDO_ORGAO);
                _.Move(V1ENDOSSO.V1ENDO_RAMO, V1ENDO_RAMO);
                _.Move(V1ENDOSSO.V1ENDO_CODPRODU, V1ENDO_CODPRODU);
                _.Move(V1ENDOSSO.VIND_COD_PRODU, VIND_COD_PRODU);
            }

        }

        [StopWatch]
        /*" R0240-00-FETCH-V1ENDOSSO-DB-CLOSE-1 */
        public void R0240_00_FETCH_V1ENDOSSO_DB_CLOSE_1()
        {
            /*" -821- EXEC SQL CLOSE V1ENDOSSO END-EXEC */

            V1ENDOSSO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0240_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-PROCESSA-V1ENDOSSO-SECTION */
        private void R0250_00_PROCESSA_V1ENDOSSO_SECTION()
        {
            /*" -840- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -841- MOVE SPACES TO WFIM-V1PARCELA. */
            _.Move("", AREA_DE_WORK.WFIM_V1PARCELA);

            /*" -842- PERFORM R0900-00-DECLARE-V1PARCELA */

            R0900_00_DECLARE_V1PARCELA_SECTION();

            /*" -843- PERFORM R0910-00-FETCH-V1PARCELA */

            R0910_00_FETCH_V1PARCELA_SECTION();

            /*" -844- MOVE CH-CHAVE-ATU TO CH-CHAVE-ANT */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU, AREA_DE_WORK.CH_CHAVE_ANT);

            /*" -846- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V1PARCELA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1PARCELA.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -846- PERFORM R0240-00-FETCH-V1ENDOSSO. */

            R0240_00_FETCH_V1ENDOSSO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-CANCELA-V0SUBGRUPO-SECTION */
        private void R0260_00_CANCELA_V0SUBGRUPO_SECTION()
        {
            /*" -857- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -862- PERFORM R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1 */

            R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1();

            /*" -865- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -866- DISPLAY 'R0260-00 - PROBLEMAS UPDATE V0SUBGRUPO.... ' */
                _.Display($"R0260-00 - PROBLEMAS UPDATE V0SUBGRUPO.... ");

                /*" -867- DISPLAY 'APOLICE......  ' V1REL-NUM-APOL */
                _.Display($"APOLICE......  {V1REL_NUM_APOL}");

                /*" -868- DISPLAY 'SUBGRUPO.....  ' V1REL-COD-SUBG */
                _.Display($"SUBGRUPO.....  {V1REL_COD_SUBG}");

                /*" -869- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -869- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0260-00-CANCELA-V0SUBGRUPO-DB-UPDATE-1 */
        public void R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1()
        {
            /*" -862- EXEC SQL UPDATE SEGUROS.V0SUBGRUPO SET SIT_REGISTRO = '2' WHERE NUM_APOLICE = :V1REL-NUM-APOL AND COD_SUBGRUPO = :V1REL-COD-SUBG END-EXEC. */

            var r0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1 = new R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1()
            {
                V1REL_NUM_APOL = V1REL_NUM_APOL.ToString(),
                V1REL_COD_SUBG = V1REL_COD_SUBG.ToString(),
            };

            R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1.Execute(r0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0280-00-LER-V1AGENCIACEF-SECTION */
        private void R0280_00_LER_V1AGENCIACEF_SECTION()
        {
            /*" -882- MOVE '0280' TO WNR-EXEC-SQL. */
            _.Move("0280", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -884- MOVE 'SIM' TO WTEM-V1AGECEF. */
            _.Move("SIM", AREA_DE_WORK.WTEM_V1AGECEF);

            /*" -896- PERFORM R0280_00_LER_V1AGENCIACEF_DB_SELECT_1 */

            R0280_00_LER_V1AGENCIACEF_DB_SELECT_1();

            /*" -899- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -900- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -901- MOVE 'NAO' TO WTEM-V1AGECEF */
                    _.Move("NAO", AREA_DE_WORK.WTEM_V1AGECEF);

                    /*" -910- MOVE 5 TO V1MALHA-COD-FONTE */
                    _.Move(5, V1MALHA_COD_FONTE);

                    /*" -911- ELSE */
                }
                else
                {


                    /*" -912- DISPLAY 'R0280-00 - PROBLEMAS SELECT V1AGENCIACEF' */
                    _.Display($"R0280-00 - PROBLEMAS SELECT V1AGENCIACEF");

                    /*" -913- DISPLAY 'APOLICE.............  ' V1REL-NUM-APOL */
                    _.Display($"APOLICE.............  {V1REL_NUM_APOL}");

                    /*" -914- DISPLAY 'SUBGRUPO............  ' V1REL-COD-SUBG */
                    _.Display($"SUBGRUPO............  {V1REL_COD_SUBG}");

                    /*" -915- DISPLAY 'NUM.TERMO...........  ' V0TERMO-NUM-TERMO */
                    _.Display($"NUM.TERMO...........  {V0TERMO_NUM_TERMO}");

                    /*" -916- DISPLAY 'AGENCIA OPERADORA...  ' V0TERMO-COD-AGE-OP */
                    _.Display($"AGENCIA OPERADORA...  {V0TERMO_COD_AGE_OP}");

                    /*" -917- DISPLAY 'SQLCODE.............  ' SQLCODE */
                    _.Display($"SQLCODE.............  {DB.SQLCODE}");

                    /*" -917- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0280-00-LER-V1AGENCIACEF-DB-SELECT-1 */
        public void R0280_00_LER_V1AGENCIACEF_DB_SELECT_1()
        {
            /*" -896- EXEC SQL SELECT COD_AGENCIA, COD_SUREG, COD_ESCNEG, SITUACAO INTO :V1AGENC-COD-AGENCIA, :V1AGENC-COD-SUREG, :V1AGENC-COD-ESCNEG, :V1AGENC-SITUACAO FROM SEGUROS.V1AGENCIACEF WHERE COD_AGENCIA = :V0TERMO-COD-AGE-OP WITH UR END-EXEC. */

            var r0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1 = new R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1()
            {
                V0TERMO_COD_AGE_OP = V0TERMO_COD_AGE_OP.ToString(),
            };

            var executed_1 = R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1.Execute(r0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1AGENC_COD_AGENCIA, V1AGENC_COD_AGENCIA);
                _.Move(executed_1.V1AGENC_COD_SUREG, V1AGENC_COD_SUREG);
                _.Move(executed_1.V1AGENC_COD_ESCNEG, V1AGENC_COD_ESCNEG);
                _.Move(executed_1.V1AGENC_SITUACAO, V1AGENC_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0280_99_SAIDA*/

        [StopWatch]
        /*" R0290-00-LER-V1MALHACEF-SECTION */
        private void R0290_00_LER_V1MALHACEF_SECTION()
        {
            /*" -943- MOVE '0290' TO WNR-EXEC-SQL. */
            _.Move("0290", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -951- PERFORM R0290_00_LER_V1MALHACEF_DB_SELECT_1 */

            R0290_00_LER_V1MALHACEF_DB_SELECT_1();

            /*" -954- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -955- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -956- DISPLAY 'R0290-00 - PROBLEMAS SELECT V1MALHACEF' */
                    _.Display($"R0290-00 - PROBLEMAS SELECT V1MALHACEF");

                    /*" -957- DISPLAY 'CODSIGO SUREG NAO CADASTRADO NA V1MALHACEF' */
                    _.Display($"CODSIGO SUREG NAO CADASTRADO NA V1MALHACEF");

                    /*" -958- DISPLAY 'APOLICE.............  ' V1REL-NUM-APOL */
                    _.Display($"APOLICE.............  {V1REL_NUM_APOL}");

                    /*" -959- DISPLAY 'SUBGRUPO............  ' V1REL-COD-SUBG */
                    _.Display($"SUBGRUPO............  {V1REL_COD_SUBG}");

                    /*" -960- DISPLAY 'NUM.TERMO...........  ' V0TERMO-NUM-TERMO */
                    _.Display($"NUM.TERMO...........  {V0TERMO_NUM_TERMO}");

                    /*" -961- DISPLAY 'AGENCIA OPERADORA...  ' V0TERMO-COD-AGE-OP */
                    _.Display($"AGENCIA OPERADORA...  {V0TERMO_COD_AGE_OP}");

                    /*" -962- DISPLAY 'CODIGO SUREG........  ' V1AGENC-COD-SUREG */
                    _.Display($"CODIGO SUREG........  {V1AGENC_COD_SUREG}");

                    /*" -963- DISPLAY 'SQLCODE.............  ' SQLCODE */
                    _.Display($"SQLCODE.............  {DB.SQLCODE}");

                    /*" -964- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -965- ELSE */
                }
                else
                {


                    /*" -966- DISPLAY 'R0290-00 - PROBLEMAS SELECT V1MALHACEF' */
                    _.Display($"R0290-00 - PROBLEMAS SELECT V1MALHACEF");

                    /*" -967- DISPLAY 'APOLICE.............  ' V1REL-NUM-APOL */
                    _.Display($"APOLICE.............  {V1REL_NUM_APOL}");

                    /*" -968- DISPLAY 'SUBGRUPO............  ' V1REL-COD-SUBG */
                    _.Display($"SUBGRUPO............  {V1REL_COD_SUBG}");

                    /*" -969- DISPLAY 'NUM.TERMO...........  ' V0TERMO-NUM-TERMO */
                    _.Display($"NUM.TERMO...........  {V0TERMO_NUM_TERMO}");

                    /*" -970- DISPLAY 'AGENCIA OPERADORA...  ' V0TERMO-COD-AGE-OP */
                    _.Display($"AGENCIA OPERADORA...  {V0TERMO_COD_AGE_OP}");

                    /*" -971- DISPLAY 'CODIGO SUREG........  ' V1AGENC-COD-SUREG */
                    _.Display($"CODIGO SUREG........  {V1AGENC_COD_SUREG}");

                    /*" -972- DISPLAY 'SQLCODE.............  ' SQLCODE */
                    _.Display($"SQLCODE.............  {DB.SQLCODE}");

                    /*" -972- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0290-00-LER-V1MALHACEF-DB-SELECT-1 */
        public void R0290_00_LER_V1MALHACEF_DB_SELECT_1()
        {
            /*" -951- EXEC SQL SELECT COD_SUREG, COD_FONTE INTO :V1MALHA-COD-SUREG, :V1MALHA-COD-FONTE FROM SEGUROS.V1MALHACEF WHERE COD_SUREG = :V1AGENC-COD-SUREG WITH UR END-EXEC. */

            var r0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1 = new R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1()
            {
                V1AGENC_COD_SUREG = V1AGENC_COD_SUREG.ToString(),
            };

            var executed_1 = R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1.Execute(r0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MALHA_COD_SUREG, V1MALHA_COD_SUREG);
                _.Move(executed_1.V1MALHA_COD_FONTE, V1MALHA_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0290_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-ESTORNA-PRODCAMPANHA-SECTION */
        private void R0300_00_ESTORNA_PRODCAMPANHA_SECTION()
        {
            /*" -985- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -986- MOVE V0TERMO-MAT-VEN TO V0PRODC-NUM-MATRIC */
            _.Move(V0TERMO_MAT_VEN, V0PRODC_NUM_MATRIC);

            /*" -987- MOVE V1SIST-DTMOVABE TO V0PRODC-DTOPER */
            _.Move(V1SIST_DTMOVABE, V0PRODC_DTOPER);

            /*" -988- MOVE V0TERMO-COD-AGE-OP TO V0PRODC-COD-AGENC */
            _.Move(V0TERMO_COD_AGE_OP, V0PRODC_COD_AGENC);

            /*" -989- MOVE 'EMP' TO V0PRODC-CODPRODAZ */
            _.Move("EMP", V0PRODC_CODPRODAZ);

            /*" -990- MOVE 401 TO V0PRODC-COD-OPER */
            _.Move(401, V0PRODC_COD_OPER);

            /*" -991- MOVE V1MALHA-COD-FONTE TO V0PRODC-COD-FONTE */
            _.Move(V1MALHA_COD_FONTE, V0PRODC_COD_FONTE);

            /*" -992- MOVE V0TERMO-COD-SUBG TO V0PRODC-NUM-PROPO */
            _.Move(V0TERMO_COD_SUBG, V0PRODC_NUM_PROPO);

            /*" -993- MOVE V0TERMO-QTD-VIDAS TO V0PRODC-QTD-REALI */
            _.Move(V0TERMO_QTD_VIDAS, V0PRODC_QTD_REALI);

            /*" -994- MOVE V0TERMO-VL-COMI-AD TO V0PRODC-VL-COMI-RE */
            _.Move(V0TERMO_VL_COMI_AD, V0PRODC_VL_COMI_RE);

            /*" -995- IF V0TERMO-PLANO-VGAP GREATER ZEROS */

            if (V0TERMO_PLANO_VGAP > 00)
            {

                /*" -996- MOVE V0TERMO-PLANO-VGAP TO V0PRODC-COD-PLANO */
                _.Move(V0TERMO_PLANO_VGAP, V0PRODC_COD_PLANO);

                /*" -997- ELSE */
            }
            else
            {


                /*" -998- MOVE V0TERMO-PLANO-APC TO V0PRODC-COD-PLANO. */
                _.Move(V0TERMO_PLANO_APC, V0PRODC_COD_PLANO);
            }


            /*" -999- MOVE V0TERMO-DT-ADESAO TO V0PRODC-DT-REFER */
            _.Move(V0TERMO_DT_ADESAO, V0PRODC_DT_REFER);

            /*" -1000- MOVE '0' TO V0PRODC-SIT-CAMPAN */
            _.Move("0", V0PRODC_SIT_CAMPAN);

            /*" -1001- MOVE '0' TO V0PRODC-SIT-INTERF */
            _.Move("0", V0PRODC_SIT_INTERF);

            /*" -1003- MOVE '0' TO V0PRODC-SIT-DIARIO. */
            _.Move("0", V0PRODC_SIT_DIARIO);

            /*" -1003- PERFORM R0310-00-INSERT-V0PRODCAMPANHA. */

            R0310_00_INSERT_V0PRODCAMPANHA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-INSERT-V0PRODCAMPANHA-SECTION */
        private void R0310_00_INSERT_V0PRODCAMPANHA_SECTION()
        {
            /*" -1016- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1032- PERFORM R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1 */

            R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1();

            /*" -1035- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1036- DISPLAY 'R0310-00 - PROBLEMAS INSERT DA V0PRODCAMPANHA' */
                _.Display($"R0310-00 - PROBLEMAS INSERT DA V0PRODCAMPANHA");

                /*" -1037- DISPLAY 'APOLICE.............  ' V1REL-NUM-APOL */
                _.Display($"APOLICE.............  {V1REL_NUM_APOL}");

                /*" -1038- DISPLAY 'SUBGRUPO............  ' V1REL-COD-SUBG */
                _.Display($"SUBGRUPO............  {V1REL_COD_SUBG}");

                /*" -1039- DISPLAY 'NUM.TERMO...........  ' V0TERMO-NUM-TERMO */
                _.Display($"NUM.TERMO...........  {V0TERMO_NUM_TERMO}");

                /*" -1040- DISPLAY 'AGENCIA.............  ' V0PRODC-COD-AGENC */
                _.Display($"AGENCIA.............  {V0PRODC_COD_AGENC}");

                /*" -1041- DISPLAY 'OPERACAO............  ' V0PRODC-COD-OPER */
                _.Display($"OPERACAO............  {V0PRODC_COD_OPER}");

                /*" -1042- DISPLAY 'DATA REFERENCIA.....  ' V0PRODC-DT-REFER */
                _.Display($"DATA REFERENCIA.....  {V0PRODC_DT_REFER}");

                /*" -1043- DISPLAY 'SQLCODE.............  ' SQLCODE */
                _.Display($"SQLCODE.............  {DB.SQLCODE}");

                /*" -1043- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0310-00-INSERT-V0PRODCAMPANHA-DB-INSERT-1 */
        public void R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1()
        {
            /*" -1032- EXEC SQL INSERT INTO SEGUROS.V0PRODCAMPANHA VALUES (:V0PRODC-DTOPER, :V0PRODC-COD-AGENC, :V0PRODC-CODPRODAZ, :V0PRODC-NUM-MATRIC, :V0PRODC-COD-OPER, :V0PRODC-COD-FONTE, :V0PRODC-NUM-PROPO, :V0PRODC-QTD-REALI, :V0PRODC-VL-COMI-RE, :V0PRODC-COD-PLANO, :V0PRODC-DT-REFER, :V0PRODC-SIT-CAMPAN, :V0PRODC-SIT-INTERF, :V0PRODC-SIT-DIARIO) END-EXEC. */

            var r0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1 = new R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1()
            {
                V0PRODC_DTOPER = V0PRODC_DTOPER.ToString(),
                V0PRODC_COD_AGENC = V0PRODC_COD_AGENC.ToString(),
                V0PRODC_CODPRODAZ = V0PRODC_CODPRODAZ.ToString(),
                V0PRODC_NUM_MATRIC = V0PRODC_NUM_MATRIC.ToString(),
                V0PRODC_COD_OPER = V0PRODC_COD_OPER.ToString(),
                V0PRODC_COD_FONTE = V0PRODC_COD_FONTE.ToString(),
                V0PRODC_NUM_PROPO = V0PRODC_NUM_PROPO.ToString(),
                V0PRODC_QTD_REALI = V0PRODC_QTD_REALI.ToString(),
                V0PRODC_VL_COMI_RE = V0PRODC_VL_COMI_RE.ToString(),
                V0PRODC_COD_PLANO = V0PRODC_COD_PLANO.ToString(),
                V0PRODC_DT_REFER = V0PRODC_DT_REFER.ToString(),
                V0PRODC_SIT_CAMPAN = V0PRODC_SIT_CAMPAN.ToString(),
                V0PRODC_SIT_INTERF = V0PRODC_SIT_INTERF.ToString(),
                V0PRODC_SIT_DIARIO = V0PRODC_SIT_DIARIO.ToString(),
            };

            R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1.Execute(r0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-ESTORNA-V0COMISSAO-SECTION */
        private void R0320_00_ESTORNA_V0COMISSAO_SECTION()
        {
            /*" -1058- MOVE '0320' TO WNR-EXEC-SQL. */
            _.Move("0320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1059- MOVE V0TERMO-CODPDTVEN TO V0COMI-CODPDT */
            _.Move(V0TERMO_CODPDTVEN, V0COMI_CODPDT);

            /*" -1060- MOVE V0TERMO-PCCOMVEN TO V0COMI-PCCOMCOR */
            _.Move(V0TERMO_PCCOMVEN, V0COMI_PCCOMCOR);

            /*" -1061- IF V0TERMO-DT-ADESAO NOT GREATER '1995-08-14' */

            if (V0TERMO_DT_ADESAO <= "1995-08-14")
            {

                /*" -1062- MOVE 'A' TO V0COMI-TIPCOM */
                _.Move("A", V0COMI_TIPCOM);

                /*" -1063- ELSE */
            }
            else
            {


                /*" -1065- MOVE 'G' TO V0COMI-TIPCOM. */
                _.Move("G", V0COMI_TIPCOM);
            }


            /*" -1069- PERFORM R0330-00-MONTA-DADOS-COMISSAO. */

            R0330_00_MONTA_DADOS_COMISSAO_SECTION();

            /*" -1070- MOVE V0TERMO-CODPDTGER TO V0COMI-CODPDT */
            _.Move(V0TERMO_CODPDTGER, V0COMI_CODPDT);

            /*" -1071- MOVE V0TERMO-PCCOMGER TO V0COMI-PCCOMCOR. */
            _.Move(V0TERMO_PCCOMGER, V0COMI_PCCOMCOR);

            /*" -1072- IF V0TERMO-DT-ADESAO NOT GREATER '1995-08-14' */

            if (V0TERMO_DT_ADESAO <= "1995-08-14")
            {

                /*" -1073- MOVE 'D' TO V0COMI-TIPCOM */
                _.Move("D", V0COMI_TIPCOM);

                /*" -1074- ELSE */
            }
            else
            {


                /*" -1076- MOVE 'H' TO V0COMI-TIPCOM. */
                _.Move("H", V0COMI_TIPCOM);
            }


            /*" -1080- PERFORM R0330-00-MONTA-DADOS-COMISSAO. */

            R0330_00_MONTA_DADOS_COMISSAO_SECTION();

            /*" -1081- MOVE SPACES TO WFIM-V1PROD-DESC */
            _.Move("", AREA_DE_WORK.WFIM_V1PROD_DESC);

            /*" -1082- MOVE V1AGENC-COD-ESCNEG TO V1PROD-COD-ESCNEG */
            _.Move(V1AGENC_COD_ESCNEG, V1PROD_COD_ESCNEG);

            /*" -1083- MOVE '9999-12-31' TO V1PROD-DTTERVIG */
            _.Move("9999-12-31", V1PROD_DTTERVIG);

            /*" -1084- PERFORM R0380-00-LER-V0PRODESCNEG. */

            R0380_00_LER_V0PRODESCNEG_SECTION();

            /*" -1085- IF WFIM-V1PROD-DESC EQUAL SPACES */

            if (AREA_DE_WORK.WFIM_V1PROD_DESC.IsEmpty())
            {

                /*" -1086- MOVE V1PROD-NUM-MATRIC TO V1FUNC-NUM-MATRIC */
                _.Move(V1PROD_NUM_MATRIC, V1FUNC_NUM_MATRIC);

                /*" -1087- PERFORM R0390-00-LER-V0FUNCIOCEF */

                R0390_00_LER_V0FUNCIOCEF_SECTION();

                /*" -1088- MOVE V1FUNC-COD-ANGARIA TO V0COMI-CODPDT */
                _.Move(V1FUNC_COD_ANGARIA, V0COMI_CODPDT);

                /*" -1089- ELSE */
            }
            else
            {


                /*" -1090- MOVE SPACES TO WFIM-V1PROD-DESC */
                _.Move("", AREA_DE_WORK.WFIM_V1PROD_DESC);

                /*" -1091- MOVE ZEROS TO V0COMI-CODPDT */
                _.Move(0, V0COMI_CODPDT);

                /*" -1093- END-IF. */
            }


            /*" -1094- MOVE 'I' TO V0COMI-TIPCOM */
            _.Move("I", V0COMI_TIPCOM);

            /*" -1095- IF V0TERMO-PERI-PGTO EQUAL 1 */

            if (V0TERMO_PERI_PGTO == 1)
            {

                /*" -1096- MOVE 2,00 TO V0COMI-PCCOMCOR */
                _.Move(2.00, V0COMI_PCCOMCOR);

                /*" -1097- ELSE */
            }
            else
            {


                /*" -1099- MOVE 0,2 TO V0COMI-PCCOMCOR. */
                _.Move(0.2, V0COMI_PCCOMCOR);
            }


            /*" -1099- PERFORM R0330-00-MONTA-DADOS-COMISSAO. */

            R0330_00_MONTA_DADOS_COMISSAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0330-00-MONTA-DADOS-COMISSAO-SECTION */
        private void R0330_00_MONTA_DADOS_COMISSAO_SECTION()
        {
            /*" -1112- MOVE '0330' TO WNR-EXEC-SQL. */
            _.Move("0330", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1114- MOVE SPACES TO WFIM-V0COMISSAO. */
            _.Move("", AREA_DE_WORK.WFIM_V0COMISSAO);

            /*" -1115- MOVE V1REL-NUM-APOL TO V0COMI-NUM-APOL */
            _.Move(V1REL_NUM_APOL, V0COMI_NUM_APOL);

            /*" -1116- MOVE V1REL-COD-SUBG TO V0COMI-CODSUBES */
            _.Move(V1REL_COD_SUBG, V0COMI_CODSUBES);

            /*" -1118- MOVE 1101 TO V0COMI-OPERACAO */
            _.Move(1101, V0COMI_OPERACAO);

            /*" -1120- PERFORM R0340-00-SEL-COMISSAO-ESTORNAR */

            R0340_00_SEL_COMISSAO_ESTORNAR_SECTION();

            /*" -1122- PERFORM R0350-00-FETCH-V0COMISSAO */

            R0350_00_FETCH_V0COMISSAO_SECTION();

            /*" -1123- PERFORM R0360-00-ESTONAR-V0COMISSAO UNTIL WFIM-V0COMISSAO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0COMISSAO.IsEmpty()))
            {

                R0360_00_ESTONAR_V0COMISSAO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/

        [StopWatch]
        /*" R0340-00-SEL-COMISSAO-ESTORNAR-SECTION */
        private void R0340_00_SEL_COMISSAO_ESTORNAR_SECTION()
        {
            /*" -1136- MOVE '0340' TO WNR-EXEC-SQL. */
            _.Move("0340", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1175- PERFORM R0340_00_SEL_COMISSAO_ESTORNAR_DB_DECLARE_1 */

            R0340_00_SEL_COMISSAO_ESTORNAR_DB_DECLARE_1();

            /*" -1177- PERFORM R0340_00_SEL_COMISSAO_ESTORNAR_DB_OPEN_1 */

            R0340_00_SEL_COMISSAO_ESTORNAR_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0340-00-SEL-COMISSAO-ESTORNAR-DB-OPEN-1 */
        public void R0340_00_SEL_COMISSAO_ESTORNAR_DB_OPEN_1()
        {
            /*" -1177- EXEC SQL OPEN V0COMISSAO END-EXEC. */

            V0COMISSAO.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1PARCELA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V1PARCELA_DB_DECLARE_1()
        {
            /*" -1488- EXEC SQL DECLARE V1PARCELA CURSOR FOR SELECT NUM_APOLICE , NRENDOS , NRPARCEL , DACPARC , FONTE , NRTIT , OCORHIST , QTDDOC , SITUACAO , COD_EMPRESA FROM SEGUROS.V1PARCELA WHERE NUM_APOLICE = :V1ENDO-NUM-APOL AND NRENDOS = :V1ENDO-NRENDOS ORDER BY NUM_APOLICE, NRENDOS, NRPARCEL WITH UR END-EXEC. */
            V1PARCELA = new VE0030B_V1PARCELA(true);
            string GetQuery_V1PARCELA()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							NRENDOS
							, 
							NRPARCEL
							, 
							DACPARC
							, 
							FONTE
							, 
							NRTIT
							, 
							OCORHIST
							, 
							QTDDOC
							, 
							SITUACAO
							, 
							COD_EMPRESA 
							FROM SEGUROS.V1PARCELA 
							WHERE NUM_APOLICE = '{V1ENDO_NUM_APOL}' 
							AND NRENDOS = '{V1ENDO_NRENDOS}' 
							ORDER BY NUM_APOLICE
							, 
							NRENDOS
							, 
							NRPARCEL";

                return query;
            }
            V1PARCELA.GetQueryEvent += GetQuery_V1PARCELA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-FETCH-V0COMISSAO-SECTION */
        private void R0350_00_FETCH_V0COMISSAO_SECTION()
        {
            /*" -1190- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1220- PERFORM R0350_00_FETCH_V0COMISSAO_DB_FETCH_1 */

            R0350_00_FETCH_V0COMISSAO_DB_FETCH_1();

            /*" -1223- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1224- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1225- MOVE 'S' TO WFIM-V0COMISSAO */
                    _.Move("S", AREA_DE_WORK.WFIM_V0COMISSAO);

                    /*" -1225- PERFORM R0350_00_FETCH_V0COMISSAO_DB_CLOSE_1 */

                    R0350_00_FETCH_V0COMISSAO_DB_CLOSE_1();

                    /*" -1227- ELSE */
                }
                else
                {


                    /*" -1228- DISPLAY 'R0350 - PROBLEMAS FETCH V0COMISSAO..... ' */
                    _.Display($"R0350 - PROBLEMAS FETCH V0COMISSAO..... ");

                    /*" -1229- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1230- ELSE */
                }

            }
            else
            {


                /*" -1230- ADD 1 TO AC-L-V0COMISSAO. */
                AREA_DE_WORK.AC_L_V0COMISSAO.Value = AREA_DE_WORK.AC_L_V0COMISSAO + 1;
            }


        }

        [StopWatch]
        /*" R0350-00-FETCH-V0COMISSAO-DB-FETCH-1 */
        public void R0350_00_FETCH_V0COMISSAO_DB_FETCH_1()
        {
            /*" -1220- EXEC SQL FETCH V0COMISSAO INTO :V0COMI-NUM-APOL, :V0COMI-NRENDOS, :V0COMI-NRCERTIF, :V0COMI-DIGCERT, :V0COMI-IDTPSEGU, :V0COMI-NRPARCEL, :V0COMI-OPERACAO, :V0COMI-CODPDT, :V0COMI-RAMOFR, :V0COMI-MODALIFR, :V0COMI-OCORHIST, :V0COMI-FONTE, :V0COMI-CODCLIEN, :V0COMI-VLCOMIS, :V0COMI-DATCLO, :V0COMI-NUMREC, :V0COMI-VALBAS, :V0COMI-TIPCOM, :V0COMI-QTPARCEL, :V0COMI-PCCOMCOR, :V0COMI-PCDESCON, :V0COMI-CODSUBES, :V0COMI-DTMOVTO:VIND-DTMOVTO, :V0COMI-DATSEL, :V0COMI-COD-EMPRESA:VIND-COD-EMP, :V0COMI-CODPRP:VIND-CODPRP, :V0COMI-NUMBIL:VIND-NUMBIL, :V0COMI-VLVARMON:VIND-VLVARMON, :V0COMI-DTQITBCO:VIND-DTQITBCO END-EXEC. */

            if (V0COMISSAO.Fetch())
            {
                _.Move(V0COMISSAO.V0COMI_NUM_APOL, V0COMI_NUM_APOL);
                _.Move(V0COMISSAO.V0COMI_NRENDOS, V0COMI_NRENDOS);
                _.Move(V0COMISSAO.V0COMI_NRCERTIF, V0COMI_NRCERTIF);
                _.Move(V0COMISSAO.V0COMI_DIGCERT, V0COMI_DIGCERT);
                _.Move(V0COMISSAO.V0COMI_IDTPSEGU, V0COMI_IDTPSEGU);
                _.Move(V0COMISSAO.V0COMI_NRPARCEL, V0COMI_NRPARCEL);
                _.Move(V0COMISSAO.V0COMI_OPERACAO, V0COMI_OPERACAO);
                _.Move(V0COMISSAO.V0COMI_CODPDT, V0COMI_CODPDT);
                _.Move(V0COMISSAO.V0COMI_RAMOFR, V0COMI_RAMOFR);
                _.Move(V0COMISSAO.V0COMI_MODALIFR, V0COMI_MODALIFR);
                _.Move(V0COMISSAO.V0COMI_OCORHIST, V0COMI_OCORHIST);
                _.Move(V0COMISSAO.V0COMI_FONTE, V0COMI_FONTE);
                _.Move(V0COMISSAO.V0COMI_CODCLIEN, V0COMI_CODCLIEN);
                _.Move(V0COMISSAO.V0COMI_VLCOMIS, V0COMI_VLCOMIS);
                _.Move(V0COMISSAO.V0COMI_DATCLO, V0COMI_DATCLO);
                _.Move(V0COMISSAO.V0COMI_NUMREC, V0COMI_NUMREC);
                _.Move(V0COMISSAO.V0COMI_VALBAS, V0COMI_VALBAS);
                _.Move(V0COMISSAO.V0COMI_TIPCOM, V0COMI_TIPCOM);
                _.Move(V0COMISSAO.V0COMI_QTPARCEL, V0COMI_QTPARCEL);
                _.Move(V0COMISSAO.V0COMI_PCCOMCOR, V0COMI_PCCOMCOR);
                _.Move(V0COMISSAO.V0COMI_PCDESCON, V0COMI_PCDESCON);
                _.Move(V0COMISSAO.V0COMI_CODSUBES, V0COMI_CODSUBES);
                _.Move(V0COMISSAO.V0COMI_DTMOVTO, V0COMI_DTMOVTO);
                _.Move(V0COMISSAO.VIND_DTMOVTO, VIND_DTMOVTO);
                _.Move(V0COMISSAO.V0COMI_DATSEL, V0COMI_DATSEL);
                _.Move(V0COMISSAO.V0COMI_COD_EMPRESA, V0COMI_COD_EMPRESA);
                _.Move(V0COMISSAO.VIND_COD_EMP, VIND_COD_EMP);
                _.Move(V0COMISSAO.V0COMI_CODPRP, V0COMI_CODPRP);
                _.Move(V0COMISSAO.VIND_CODPRP, VIND_CODPRP);
                _.Move(V0COMISSAO.V0COMI_NUMBIL, V0COMI_NUMBIL);
                _.Move(V0COMISSAO.VIND_NUMBIL, VIND_NUMBIL);
                _.Move(V0COMISSAO.V0COMI_VLVARMON, V0COMI_VLVARMON);
                _.Move(V0COMISSAO.VIND_VLVARMON, VIND_VLVARMON);
                _.Move(V0COMISSAO.V0COMI_DTQITBCO, V0COMI_DTQITBCO);
                _.Move(V0COMISSAO.VIND_DTQITBCO, VIND_DTQITBCO);
            }

        }

        [StopWatch]
        /*" R0350-00-FETCH-V0COMISSAO-DB-CLOSE-1 */
        public void R0350_00_FETCH_V0COMISSAO_DB_CLOSE_1()
        {
            /*" -1225- EXEC SQL CLOSE V0COMISSAO END-EXEC */

            V0COMISSAO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0360-00-ESTONAR-V0COMISSAO-SECTION */
        private void R0360_00_ESTONAR_V0COMISSAO_SECTION()
        {
            /*" -1243- MOVE '0360' TO WNR-EXEC-SQL. */
            _.Move("0360", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1244- MOVE 1103 TO V0COMI-OPERACAO */
            _.Move(1103, V0COMI_OPERACAO);

            /*" -1245- MOVE V1SIST-DTMOVABE TO V0COMI-DATCLO */
            _.Move(V1SIST_DTMOVABE, V0COMI_DATCLO);

            /*" -1247- MOVE '9999-12-31' TO V0COMI-DATSEL */
            _.Move("9999-12-31", V0COMI_DATSEL);

            /*" -1249- PERFORM R0370-00-INSERT-ESTORNO-COMIS. */

            R0370_00_INSERT_ESTORNO_COMIS_SECTION();

            /*" -1249- PERFORM R0350-00-FETCH-V0COMISSAO. */

            R0350_00_FETCH_V0COMISSAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_99_SAIDA*/

        [StopWatch]
        /*" R0370-00-INSERT-ESTORNO-COMIS-SECTION */
        private void R0370_00_INSERT_ESTORNO_COMIS_SECTION()
        {
            /*" -1262- MOVE '0370' TO WNR-EXEC-SQL. */
            _.Move("0370", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1294- PERFORM R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1 */

            R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1();

            /*" -1297- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1298- DISPLAY 'R0370-00 - PROBLEMAS INSERT V0COMISSAO ' */
                _.Display($"R0370-00 - PROBLEMAS INSERT V0COMISSAO ");

                /*" -1299- DISPLAY 'APOLICE......  ' V0COMI-NUM-APOL */
                _.Display($"APOLICE......  {V0COMI_NUM_APOL}");

                /*" -1300- DISPLAY 'SUBGRUPO.....  ' V0COMI-CODSUBES */
                _.Display($"SUBGRUPO.....  {V0COMI_CODSUBES}");

                /*" -1301- DISPLAY 'CODPDT.......  ' V0COMI-CODPDT */
                _.Display($"CODPDT.......  {V0COMI_CODPDT}");

                /*" -1302- DISPLAY 'NRCERTIF.....  ' V0COMI-NRCERTIF */
                _.Display($"NRCERTIF.....  {V0COMI_NRCERTIF}");

                /*" -1303- DISPLAY 'OPERACAO.....  ' V0COMI-OPERACAO */
                _.Display($"OPERACAO.....  {V0COMI_OPERACAO}");

                /*" -1304- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -1304- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0370-00-INSERT-ESTORNO-COMIS-DB-INSERT-1 */
        public void R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1()
        {
            /*" -1294- EXEC SQL INSERT INTO SEGUROS.V0COMISSAO VALUES (:V0COMI-NUM-APOL, :V0COMI-NRENDOS, :V0COMI-NRCERTIF, :V0COMI-DIGCERT, :V0COMI-IDTPSEGU, :V0COMI-NRPARCEL, :V0COMI-OPERACAO, :V0COMI-CODPDT, :V0COMI-RAMOFR, :V0COMI-MODALIFR, :V0COMI-OCORHIST, :V0COMI-FONTE, :V0COMI-CODCLIEN, :V0COMI-VLCOMIS, :V0COMI-DATCLO, :V0COMI-NUMREC, :V0COMI-VALBAS, :V0COMI-TIPCOM, :V0COMI-QTPARCEL, :V0COMI-PCCOMCOR, :V0COMI-PCDESCON, :V0COMI-CODSUBES, CURRENT TIME, NULL, :V0COMI-DATSEL, NULL, NULL, CURRENT TIMESTAMP, NULL, NULL, NULL) END-EXEC. */

            var r0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1 = new R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1()
            {
                V0COMI_NUM_APOL = V0COMI_NUM_APOL.ToString(),
                V0COMI_NRENDOS = V0COMI_NRENDOS.ToString(),
                V0COMI_NRCERTIF = V0COMI_NRCERTIF.ToString(),
                V0COMI_DIGCERT = V0COMI_DIGCERT.ToString(),
                V0COMI_IDTPSEGU = V0COMI_IDTPSEGU.ToString(),
                V0COMI_NRPARCEL = V0COMI_NRPARCEL.ToString(),
                V0COMI_OPERACAO = V0COMI_OPERACAO.ToString(),
                V0COMI_CODPDT = V0COMI_CODPDT.ToString(),
                V0COMI_RAMOFR = V0COMI_RAMOFR.ToString(),
                V0COMI_MODALIFR = V0COMI_MODALIFR.ToString(),
                V0COMI_OCORHIST = V0COMI_OCORHIST.ToString(),
                V0COMI_FONTE = V0COMI_FONTE.ToString(),
                V0COMI_CODCLIEN = V0COMI_CODCLIEN.ToString(),
                V0COMI_VLCOMIS = V0COMI_VLCOMIS.ToString(),
                V0COMI_DATCLO = V0COMI_DATCLO.ToString(),
                V0COMI_NUMREC = V0COMI_NUMREC.ToString(),
                V0COMI_VALBAS = V0COMI_VALBAS.ToString(),
                V0COMI_TIPCOM = V0COMI_TIPCOM.ToString(),
                V0COMI_QTPARCEL = V0COMI_QTPARCEL.ToString(),
                V0COMI_PCCOMCOR = V0COMI_PCCOMCOR.ToString(),
                V0COMI_PCDESCON = V0COMI_PCDESCON.ToString(),
                V0COMI_CODSUBES = V0COMI_CODSUBES.ToString(),
                V0COMI_DATSEL = V0COMI_DATSEL.ToString(),
            };

            R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1.Execute(r0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_99_SAIDA*/

        [StopWatch]
        /*" R0380-00-LER-V0PRODESCNEG-SECTION */
        private void R0380_00_LER_V0PRODESCNEG_SECTION()
        {
            /*" -1317- MOVE '0380' TO WNR-EXEC-SQL. */
            _.Move("0380", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1330- PERFORM R0380_00_LER_V0PRODESCNEG_DB_SELECT_1 */

            R0380_00_LER_V0PRODESCNEG_DB_SELECT_1();

            /*" -1333- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1334- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1335- MOVE '*' TO WFIM-V1PROD-DESC */
                    _.Move("*", AREA_DE_WORK.WFIM_V1PROD_DESC);

                    /*" -1336- DISPLAY 'VE0030B - ESCRITORIO DE NEGOCIO NAO CADASTRADO' */
                    _.Display($"VE0030B - ESCRITORIO DE NEGOCIO NAO CADASTRADO");

                    /*" -1337- DISPLAY 'VE0030B - COD.ESC.NEG...  ' V1PROD-COD-ESCNEG */
                    _.Display($"VE0030B - COD.ESC.NEG...  {V1PROD_COD_ESCNEG}");

                    /*" -1338- DISPLAY 'APOLICE   ' V1REL-NUM-APOL */
                    _.Display($"APOLICE   {V1REL_NUM_APOL}");

                    /*" -1340- DISPLAY 'SUBGRUPO  ' V1REL-COD-SUBG */
                    _.Display($"SUBGRUPO  {V1REL_COD_SUBG}");

                    /*" -1341- ELSE */
                }
                else
                {


                    /*" -1342- DISPLAY 'VE0030B - PROBLEMAS NO SELECT DA V0PRODESCNEG' */
                    _.Display($"VE0030B - PROBLEMAS NO SELECT DA V0PRODESCNEG");

                    /*" -1343- DISPLAY 'VE0030B - SQLCODE....   ' SQLCODE */
                    _.Display($"VE0030B - SQLCODE....   {DB.SQLCODE}");

                    /*" -1343- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0380-00-LER-V0PRODESCNEG-DB-SELECT-1 */
        public void R0380_00_LER_V0PRODESCNEG_DB_SELECT_1()
        {
            /*" -1330- EXEC SQL SELECT COD_ESCNEG, DATA_INIVIGENCIA, DATA_TERVIGENCIA, NUM_MATRICULA INTO :V1PROD-COD-ESCNEG, :V1PROD-DTINIVIG, :V1PROD-DTTERVIG, :V1PROD-NUM-MATRIC FROM SEGUROS.V1PRODESCNEG WHERE COD_ESCNEG = :V1PROD-COD-ESCNEG AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' ) WITH UR END-EXEC. */

            var r0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1 = new R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1()
            {
                V1PROD_COD_ESCNEG = V1PROD_COD_ESCNEG.ToString(),
            };

            var executed_1 = R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1.Execute(r0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PROD_COD_ESCNEG, V1PROD_COD_ESCNEG);
                _.Move(executed_1.V1PROD_DTINIVIG, V1PROD_DTINIVIG);
                _.Move(executed_1.V1PROD_DTTERVIG, V1PROD_DTTERVIG);
                _.Move(executed_1.V1PROD_NUM_MATRIC, V1PROD_NUM_MATRIC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0380_99_SAIDA*/

        [StopWatch]
        /*" R0390-00-LER-V0FUNCIOCEF-SECTION */
        private void R0390_00_LER_V0FUNCIOCEF_SECTION()
        {
            /*" -1356- MOVE '0390' TO WNR-EXEC-SQL. */
            _.Move("0390", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1364- PERFORM R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1 */

            R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1();

            /*" -1367- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1368- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1369- DISPLAY 'VE0030B - FUNCIONARIO NAO CADASTRADO' */
                    _.Display($"VE0030B - FUNCIONARIO NAO CADASTRADO");

                    /*" -1370- DISPLAY 'VE0030B - MATRICULA.....  ' V1FUNC-NUM-MATRIC */
                    _.Display($"VE0030B - MATRICULA.....  {V1FUNC_NUM_MATRIC}");

                    /*" -1371- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1372- ELSE */
                }
                else
                {


                    /*" -1373- DISPLAY 'VE0030B - PROBLEMAS NO SELECT DA V0FUNCIOCEF' */
                    _.Display($"VE0030B - PROBLEMAS NO SELECT DA V0FUNCIOCEF");

                    /*" -1374- DISPLAY 'VE0030B - MATRICULA.....  ' V1FUNC-NUM-MATRIC */
                    _.Display($"VE0030B - MATRICULA.....  {V1FUNC_NUM_MATRIC}");

                    /*" -1374- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0390-00-LER-V0FUNCIOCEF-DB-SELECT-1 */
        public void R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1()
        {
            /*" -1364- EXEC SQL SELECT NUM_MATRICULA, COD_ANGARIADOR INTO :V1FUNC-NUM-MATRIC, :V1FUNC-COD-ANGARIA FROM SEGUROS.V1FUNCIOCEF WHERE NUM_MATRICULA = :V1FUNC-NUM-MATRIC WITH UR END-EXEC. */

            var r0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1 = new R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1()
            {
                V1FUNC_NUM_MATRIC = V1FUNC_NUM_MATRIC.ToString(),
            };

            var executed_1 = R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1.Execute(r0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FUNC_NUM_MATRIC, V1FUNC_NUM_MATRIC);
                _.Move(executed_1.V1FUNC_COD_ANGARIA, V1FUNC_COD_ANGARIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0390_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-CANCELA-V0TERMOADESAO-SECTION */
        private void R0400_00_CANCELA_V0TERMOADESAO_SECTION()
        {
            /*" -1386- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1393- PERFORM R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1 */

            R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1();

            /*" -1396- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1397- DISPLAY 'R0400-00 - PROBLEMAS UPDATE V0TERMOADESAO. ' */
                _.Display($"R0400-00 - PROBLEMAS UPDATE V0TERMOADESAO. ");

                /*" -1398- DISPLAY 'APOLICE......  ' V1REL-NUM-APOL */
                _.Display($"APOLICE......  {V1REL_NUM_APOL}");

                /*" -1399- DISPLAY 'SUBGRUPO.....  ' V1REL-COD-SUBG */
                _.Display($"SUBGRUPO.....  {V1REL_COD_SUBG}");

                /*" -1400- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -1400- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0400-00-CANCELA-V0TERMOADESAO-DB-UPDATE-1 */
        public void R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1()
        {
            /*" -1393- EXEC SQL UPDATE SEGUROS.V0TERMOADESAO SET COD_USUARIO = :V1REL-COD-USUR, TIMESTAMP = CURRENT TIMESTAMP, SITUACAO = '2' WHERE NUM_TERMO = :V0TERMO-NUM-TERMO AND COD_SUBGRUPO = :V0TERMO-COD-SUBG END-EXEC. */

            var r0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1 = new R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1()
            {
                V1REL_COD_USUR = V1REL_COD_USUR.ToString(),
                V0TERMO_NUM_TERMO = V0TERMO_NUM_TERMO.ToString(),
                V0TERMO_COD_SUBG = V0TERMO_COD_SUBG.ToString(),
            };

            R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1.Execute(r0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-UPDATE-V0RELATORIO-SECTION */
        private void R0410_00_UPDATE_V0RELATORIO_SECTION()
        {
            /*" -1412- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1419- PERFORM R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1 */

            R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1();

            /*" -1422- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1423- DISPLAY 'R0410-00 - PROBLEMAS UPDATE V0RELATORIOS' */
                _.Display($"R0410-00 - PROBLEMAS UPDATE V0RELATORIOS");

                /*" -1424- DISPLAY 'APOLICE......  ' V1REL-NUM-APOL */
                _.Display($"APOLICE......  {V1REL_NUM_APOL}");

                /*" -1425- DISPLAY 'SUBGRUPO.....  ' V1REL-COD-SUBG */
                _.Display($"SUBGRUPO.....  {V1REL_COD_SUBG}");

                /*" -1426- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -1426- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0410-00-UPDATE-V0RELATORIO-DB-UPDATE-1 */
        public void R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1()
        {
            /*" -1419- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '2' WHERE CODRELAT = 'VE0030B' AND SITUACAO = '0' AND NUM_APOLICE = :V1REL-NUM-APOL AND CODSUBES = :V1REL-COD-SUBG END-EXEC. */

            var r0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1 = new R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1()
            {
                V1REL_NUM_APOL = V1REL_NUM_APOL.ToString(),
                V1REL_COD_SUBG = V1REL_COD_SUBG.ToString(),
            };

            R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1.Execute(r0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0420-00-CANCELA-V0PROPOSTAVA-SECTION */
        private void R0420_00_CANCELA_V0PROPOSTAVA_SECTION()
        {
            /*" -1439- MOVE '0420' TO WNR-EXEC-SQL. */
            _.Move("0420", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1446- PERFORM R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1 */

            R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1();

            /*" -1449- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1451- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1452- ELSE */
                }
                else
                {


                    /*" -1453- DISPLAY 'R0420-00 - PROBLEMAS UPDATE V0PROPOSTAVA. ' */
                    _.Display($"R0420-00 - PROBLEMAS UPDATE V0PROPOSTAVA. ");

                    /*" -1454- DISPLAY 'APOLICE......  ' V1REL-NUM-APOL */
                    _.Display($"APOLICE......  {V1REL_NUM_APOL}");

                    /*" -1455- DISPLAY 'SUBGRUPO.....  ' V1REL-COD-SUBG */
                    _.Display($"SUBGRUPO.....  {V1REL_COD_SUBG}");

                    /*" -1456- DISPLAY 'SQLCODE......  ' SQLCODE */
                    _.Display($"SQLCODE......  {DB.SQLCODE}");

                    /*" -1456- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0420-00-CANCELA-V0PROPOSTAVA-DB-UPDATE-1 */
        public void R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1()
        {
            /*" -1446- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET CODUSU = :V1REL-COD-USUR, TIMESTAMP = CURRENT TIMESTAMP, SITUACAO = '4' WHERE NUM_APOLICE = :V1REL-NUM-APOL AND CODSUBES = :V1REL-COD-SUBG END-EXEC. */

            var r0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1 = new R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1()
            {
                V1REL_COD_USUR = V1REL_COD_USUR.ToString(),
                V1REL_NUM_APOL = V1REL_NUM_APOL.ToString(),
                V1REL_COD_SUBG = V1REL_COD_SUBG.ToString(),
            };

            R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1.Execute(r0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V1PARCELA-SECTION */
        private void R0900_00_DECLARE_V1PARCELA_SECTION()
        {
            /*" -1469- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1488- PERFORM R0900_00_DECLARE_V1PARCELA_DB_DECLARE_1 */

            R0900_00_DECLARE_V1PARCELA_DB_DECLARE_1();

            /*" -1490- PERFORM R0900_00_DECLARE_V1PARCELA_DB_OPEN_1 */

            R0900_00_DECLARE_V1PARCELA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1PARCELA-DB-OPEN-1 */
        public void R0900_00_DECLARE_V1PARCELA_DB_OPEN_1()
        {
            /*" -1490- EXEC SQL OPEN V1PARCELA END-EXEC. */

            V1PARCELA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V1PARCELA-SECTION */
        private void R0910_00_FETCH_V1PARCELA_SECTION()
        {
            /*" -1500- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0910_10_LEITURA */

            R0910_10_LEITURA();

        }

        [StopWatch]
        /*" R0910-10-LEITURA */
        private void R0910_10_LEITURA(bool isPerform = false)
        {
            /*" -1516- PERFORM R0910_10_LEITURA_DB_FETCH_1 */

            R0910_10_LEITURA_DB_FETCH_1();

            /*" -1519- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1520- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1521- MOVE 'S' TO WFIM-V1PARCELA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1PARCELA);

                    /*" -1522- MOVE SPACES TO CH-CHAVE-ATU */
                    _.Move("", AREA_DE_WORK.CH_CHAVE_ATU);

                    /*" -1522- PERFORM R0910_10_LEITURA_DB_CLOSE_1 */

                    R0910_10_LEITURA_DB_CLOSE_1();

                    /*" -1524- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -1525- ELSE */
                }
                else
                {


                    /*" -1526- DISPLAY 'R0910 - PROBLEMAS FETCH V1PARCELA ... ' */
                    _.Display($"R0910 - PROBLEMAS FETCH V1PARCELA ... ");

                    /*" -1529- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1530- IF V1PARC-SITUACAO NOT EQUAL '0' */

            if (V1PARC_SITUACAO != "0")
            {

                /*" -1531- MOVE 'S' TO WFIM-V1PARCELA */
                _.Move("S", AREA_DE_WORK.WFIM_V1PARCELA);

                /*" -1531- PERFORM R0910_10_LEITURA_DB_CLOSE_2 */

                R0910_10_LEITURA_DB_CLOSE_2();

                /*" -1533- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -1534- DISPLAY '*------ VE0030B -- PARCELA DESPRESADA  -------*' */
                _.Display($"*------ VE0030B -- PARCELA DESPRESADA  -------*");

                /*" -1535- DISPLAY '*- PARCELA PENDENTE NA V0ENDOSSO E, PAGA  OU -*' */
                _.Display($"*- PARCELA PENDENTE NA V0ENDOSSO E, PAGA  OU -*");

                /*" -1536- DISPLAY '*- CANCELADA NA V0PARCELA.                   -*' */
                _.Display($"*- CANCELADA NA V0PARCELA.                   -*");

                /*" -1537- DISPLAY '*- APOLICE .................  ' V1REL-NUM-APOL */
                _.Display($"*- APOLICE .................  {V1REL_NUM_APOL}");

                /*" -1538- DISPLAY '*- SUBGRUPO.................  ' V1REL-COD-SUBG */
                _.Display($"*- SUBGRUPO.................  {V1REL_COD_SUBG}");

                /*" -1539- DISPLAY '*- ENDOSSO..................  ' V1PARC-NRENDOS */
                _.Display($"*- ENDOSSO..................  {V1PARC_NRENDOS}");

                /*" -1540- DISPLAY '*- PARCELA..................  ' V1PARC-NRPARCEL */
                _.Display($"*- PARCELA..................  {V1PARC_NRPARCEL}");

                /*" -1541- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -1543- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1544- MOVE V1PARC-NUM-APOL TO CH-APOLI-ATU */
            _.Move(V1PARC_NUM_APOL, AREA_DE_WORK.CH_CHAVE_ATU.CH_APOLI_ATU);

            /*" -1546- MOVE V1PARC-NRENDOS TO CH-ENDOS-ATU */
            _.Move(V1PARC_NRENDOS, AREA_DE_WORK.CH_CHAVE_ATU.CH_ENDOS_ATU);

            /*" -1546- ADD 1 TO AC-L-V1PARCELA. */
            AREA_DE_WORK.AC_L_V1PARCELA.Value = AREA_DE_WORK.AC_L_V1PARCELA + 1;

        }

        [StopWatch]
        /*" R0910-10-LEITURA-DB-FETCH-1 */
        public void R0910_10_LEITURA_DB_FETCH_1()
        {
            /*" -1516- EXEC SQL FETCH V1PARCELA INTO :V1PARC-NUM-APOL , :V1PARC-NRENDOS , :V1PARC-NRPARCEL , :V1PARC-DACPARC , :V1PARC-FONTE , :V1PARC-NRTIT , :V1PARC-OCORHIST , :V1PARC-QTDDOC , :V1PARC-SITUACAO, :V1PARC-COD-EMP:VIND-COD-EMP END-EXEC. */

            if (V1PARCELA.Fetch())
            {
                _.Move(V1PARCELA.V1PARC_NUM_APOL, V1PARC_NUM_APOL);
                _.Move(V1PARCELA.V1PARC_NRENDOS, V1PARC_NRENDOS);
                _.Move(V1PARCELA.V1PARC_NRPARCEL, V1PARC_NRPARCEL);
                _.Move(V1PARCELA.V1PARC_DACPARC, V1PARC_DACPARC);
                _.Move(V1PARCELA.V1PARC_FONTE, V1PARC_FONTE);
                _.Move(V1PARCELA.V1PARC_NRTIT, V1PARC_NRTIT);
                _.Move(V1PARCELA.V1PARC_OCORHIST, V1PARC_OCORHIST);
                _.Move(V1PARCELA.V1PARC_QTDDOC, V1PARC_QTDDOC);
                _.Move(V1PARCELA.V1PARC_SITUACAO, V1PARC_SITUACAO);
                _.Move(V1PARCELA.V1PARC_COD_EMP, V1PARC_COD_EMP);
                _.Move(V1PARCELA.VIND_COD_EMP, VIND_COD_EMP);
            }

        }

        [StopWatch]
        /*" R0910-10-LEITURA-DB-CLOSE-1 */
        public void R0910_10_LEITURA_DB_CLOSE_1()
        {
            /*" -1522- EXEC SQL CLOSE V1PARCELA END-EXEC */

            V1PARCELA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0910-10-LEITURA-DB-CLOSE-2 */
        public void R0910_10_LEITURA_DB_CLOSE_2()
        {
            /*" -1531- EXEC SQL CLOSE V1PARCELA END-EXEC */

            V1PARCELA.Close();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1561- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1562- PERFORM R2100-00-SELECT-NUMERO-AES */

            R2100_00_SELECT_NUMERO_AES_SECTION();

            /*" -1563- MOVE V0NAES-NRENDOCA TO W0NAES-NRENDOCA */
            _.Move(V0NAES_NRENDOCA, W0NAES_NRENDOCA);

            /*" -1564- ADD 1 TO W0NAES-NRENDOCA */
            W0NAES_NRENDOCA.Value = W0NAES_NRENDOCA + 1;

            /*" -1565- MOVE W0NAES-NRENDOCA TO V0NAES-NRENDOCA */
            _.Move(W0NAES_NRENDOCA, V0NAES_NRENDOCA);

            /*" -1567- PERFORM R2200-00-UPDATE-NUMERO-AES */

            R2200_00_UPDATE_NUMERO_AES_SECTION();

            /*" -1569- MOVE SPACES TO WHOUVE-CANCELA */
            _.Move("", AREA_DE_WORK.WHOUVE_CANCELA);

            /*" -1571- PERFORM R2000-00-CANCELAMENTO */

            R2000_00_CANCELAMENTO_SECTION();

            /*" -1572- IF WHOUVE-CANCELA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WHOUVE_CANCELA.IsEmpty())
            {

                /*" -1572- PERFORM R6100-00-UPDATE-V0ENDOSSO. */

                R6100_00_UPDATE_V0ENDOSSO_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_90_DESPREZA_APOLICE */

            R1000_90_DESPREZA_APOLICE();

        }

        [StopWatch]
        /*" R1000-90-DESPREZA-APOLICE */
        private void R1000_90_DESPREZA_APOLICE(bool isPerform = false)
        {
            /*" -1583- PERFORM R0910-00-FETCH-V1PARCELA UNTIL CH-CHAVE-ATU NOT EQUAL CH-CHAVE-ANT. */

            while (!(AREA_DE_WORK.CH_CHAVE_ATU != AREA_DE_WORK.CH_CHAVE_ANT))
            {

                R0910_00_FETCH_V1PARCELA_SECTION();
            }

            /*" -1583- MOVE CH-CHAVE-ATU TO CH-CHAVE-ANT. */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU, AREA_DE_WORK.CH_CHAVE_ANT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-CANCELAMENTO-SECTION */
        private void R2000_00_CANCELAMENTO_SECTION()
        {
            /*" -1596- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1597- MOVE V1PARC-OCORHIST TO WOCORHIST. */
            _.Move(V1PARC_OCORHIST, WOCORHIST);

            /*" -1599- MOVE V1PARC-NRPARCEL TO V0HISP-NRPARCEL. */
            _.Move(V1PARC_NRPARCEL, V0HISP_NRPARCEL);

            /*" -1601- PERFORM R3100-00-ACUMULA-PREMIOS */

            R3100_00_ACUMULA_PREMIOS_SECTION();

            /*" -1603- PERFORM R3200-00-ACUMULA-CORRECAO. */

            R3200_00_ACUMULA_CORRECAO_SECTION();

            /*" -1604- IF WC-VLPRMTOT NOT EQUAL +0 */

            if (WC_VLPRMTOT != +0)
            {

                /*" -1605- PERFORM R4200-00-MONTA-CORRECAO */

                R4200_00_MONTA_CORRECAO_SECTION();

                /*" -1607- PERFORM R5000-00-INSERT-V0HISTOPARC. */

                R5000_00_INSERT_V0HISTOPARC_SECTION();
            }


            /*" -1608- PERFORM R4100-00-MONTA-PREMIOS */

            R4100_00_MONTA_PREMIOS_SECTION();

            /*" -1610- PERFORM R5000-00-INSERT-V0HISTOPARC */

            R5000_00_INSERT_V0HISTOPARC_SECTION();

            /*" -1612- PERFORM R6000-00-UPDATE-V0PARCELA */

            R6000_00_UPDATE_V0PARCELA_SECTION();

            /*" -1612- MOVE '*' TO WHOUVE-CANCELA. */
            _.Move("*", AREA_DE_WORK.WHOUVE_CANCELA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-NUMERO-AES-SECTION */
        private void R2100_00_SELECT_NUMERO_AES_SECTION()
        {
            /*" -1625- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1631- PERFORM R2100_00_SELECT_NUMERO_AES_DB_SELECT_1 */

            R2100_00_SELECT_NUMERO_AES_DB_SELECT_1();

            /*" -1634- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1637- DISPLAY 'R2100-00 (NAO EXITE NA V1NUMERO-AES) ... ' ' ' V1ENDO-ORGAO ' ' V1ENDO-RAMO */

                $"R2100-00 (NAO EXITE NA V1NUMERO-AES) ...  {V1ENDO_ORGAO} {V1ENDO_RAMO}"
                .Display();

                /*" -1637- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-SELECT-NUMERO-AES-DB-SELECT-1 */
        public void R2100_00_SELECT_NUMERO_AES_DB_SELECT_1()
        {
            /*" -1631- EXEC SQL SELECT NRENDOCA INTO :V0NAES-NRENDOCA FROM SEGUROS.V0NUMERO_AES WHERE COD_ORGAO = :V1ENDO-ORGAO AND COD_RAMO = :V1ENDO-RAMO END-EXEC. */

            var r2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 = new R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1()
            {
                V1ENDO_ORGAO = V1ENDO_ORGAO.ToString(),
                V1ENDO_RAMO = V1ENDO_RAMO.ToString(),
            };

            var executed_1 = R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1.Execute(r2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0NAES_NRENDOCA, V0NAES_NRENDOCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-UPDATE-NUMERO-AES-SECTION */
        private void R2200_00_UPDATE_NUMERO_AES_SECTION()
        {
            /*" -1649- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1655- PERFORM R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1 */

            R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1();

            /*" -1658- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1661- DISPLAY 'R2200-00 (PROBLEMAS UPDATE NUMERO-AES) ... ' ' ' V1ENDO-ORGAO ' ' V1ENDO-RAMO */

                $"R2200-00 (PROBLEMAS UPDATE NUMERO-AES) ...  {V1ENDO_ORGAO} {V1ENDO_RAMO}"
                .Display();

                /*" -1661- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2200-00-UPDATE-NUMERO-AES-DB-UPDATE-1 */
        public void R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1()
        {
            /*" -1655- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET NRENDOCA = :V0NAES-NRENDOCA, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_ORGAO = :V1ENDO-ORGAO AND COD_RAMO = :V1ENDO-RAMO END-EXEC. */

            var r2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1 = new R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1()
            {
                V0NAES_NRENDOCA = V0NAES_NRENDOCA.ToString(),
                V1ENDO_ORGAO = V1ENDO_ORGAO.ToString(),
                V1ENDO_RAMO = V1ENDO_RAMO.ToString(),
            };

            R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1.Execute(r2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-ACUMULA-PREMIOS-SECTION */
        private void R3100_00_ACUMULA_PREMIOS_SECTION()
        {
            /*" -1674- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1698- PERFORM R3100_00_ACUMULA_PREMIOS_DB_SELECT_1 */

            R3100_00_ACUMULA_PREMIOS_DB_SELECT_1();

            /*" -1701- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1705- DISPLAY 'R3100-00 (PROBLEMAS ACESSO V1HISTOPARC) ...' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL */

                $"R3100-00 (PROBLEMAS ACESSO V1HISTOPARC) ...{V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL}"
                .Display();

                /*" -1705- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3100-00-ACUMULA-PREMIOS-DB-SELECT-1 */
        public void R3100_00_ACUMULA_PREMIOS_DB_SELECT_1()
        {
            /*" -1698- EXEC SQL SELECT PRM_TARIFARIO , VAL_DESCONTO , VLPRMLIQ , VLADIFRA , VLCUSEMI , VLIOCC , VLPRMTOT , VLPREMIO , DTVENCTO INTO :WP-PRM-TAR , :WP-VAL-DESC , :WP-VLPRMLIQ , :WP-VLADIFRA , :WP-VLCUSEMI , :WP-VLIOCC , :WP-VLPRMTOT , :WP-VLPREMIO , :V1HISP-DTVENCTO FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL = :V0HISP-NRPARCEL AND OPERACAO = 0101 END-EXEC. */

            var r3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1 = new R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1.Execute(r3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WP_PRM_TAR, WP_PRM_TAR);
                _.Move(executed_1.WP_VAL_DESC, WP_VAL_DESC);
                _.Move(executed_1.WP_VLPRMLIQ, WP_VLPRMLIQ);
                _.Move(executed_1.WP_VLADIFRA, WP_VLADIFRA);
                _.Move(executed_1.WP_VLCUSEMI, WP_VLCUSEMI);
                _.Move(executed_1.WP_VLIOCC, WP_VLIOCC);
                _.Move(executed_1.WP_VLPRMTOT, WP_VLPRMTOT);
                _.Move(executed_1.WP_VLPREMIO, WP_VLPREMIO);
                _.Move(executed_1.V1HISP_DTVENCTO, V1HISP_DTVENCTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-ACUMULA-CORRECAO-SECTION */
        private void R3200_00_ACUMULA_CORRECAO_SECTION()
        {
            /*" -1718- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1740- PERFORM R3200_00_ACUMULA_CORRECAO_DB_SELECT_1 */

            R3200_00_ACUMULA_CORRECAO_DB_SELECT_1();

            /*" -1743- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1747- DISPLAY 'R3200-00 (PROBLEMAS ACESSO V1HISTOPARC) ...' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL */

                $"R3200-00 (PROBLEMAS ACESSO V1HISTOPARC) ...{V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL}"
                .Display();

                /*" -1747- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3200-00-ACUMULA-CORRECAO-DB-SELECT-1 */
        public void R3200_00_ACUMULA_CORRECAO_DB_SELECT_1()
        {
            /*" -1740- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO),0) , VALUE(SUM(VAL_DESCONTO),0) , VALUE(SUM(VLPRMLIQ),0) , VALUE(SUM(VLADIFRA),0) , VALUE(SUM(VLCUSEMI),0) , VALUE(SUM(VLIOCC),0) , VALUE(SUM(VLPRMTOT),0) , VALUE(SUM(VLPREMIO),0) INTO :WC-PRM-TAR , :WC-VAL-DESC , :WC-VLPRMLIQ , :WC-VLADIFRA , :WC-VLCUSEMI , :WC-VLIOCC , :WC-VLPRMTOT , :WC-VLPREMIO FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL = :V0HISP-NRPARCEL AND OPERACAO = 0801 END-EXEC. */

            var r3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1 = new R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1.Execute(r3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WC_PRM_TAR, WC_PRM_TAR);
                _.Move(executed_1.WC_VAL_DESC, WC_VAL_DESC);
                _.Move(executed_1.WC_VLPRMLIQ, WC_VLPRMLIQ);
                _.Move(executed_1.WC_VLADIFRA, WC_VLADIFRA);
                _.Move(executed_1.WC_VLCUSEMI, WC_VLCUSEMI);
                _.Move(executed_1.WC_VLIOCC, WC_VLIOCC);
                _.Move(executed_1.WC_VLPRMTOT, WC_VLPRMTOT);
                _.Move(executed_1.WC_VLPREMIO, WC_VLPREMIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-MONTA-PREMIOS-SECTION */
        private void R4100_00_MONTA_PREMIOS_SECTION()
        {
            /*" -1760- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1761- MOVE V1PARC-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V1PARC_NUM_APOL, V0HISP_NUM_APOL);

            /*" -1763- MOVE V1PARC-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V1PARC_NRENDOS, V0HISP_NRENDOS);

            /*" -1764- MOVE V1PARC-DACPARC TO V0HISP-DACPARC */
            _.Move(V1PARC_DACPARC, V0HISP_DACPARC);

            /*" -1765- MOVE V1SIST-DTMOVABE TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0HISP_DTMOVTO);

            /*" -1767- MOVE 0401 TO V0HISP-OPERACAO */
            _.Move(0401, V0HISP_OPERACAO);

            /*" -1768- ADD +1 TO WOCORHIST */
            WOCORHIST.Value = WOCORHIST + +1;

            /*" -1770- MOVE WOCORHIST TO V0HISP-OCORHIST */
            _.Move(WOCORHIST, V0HISP_OCORHIST);

            /*" -1771- ACCEPT WTIME-DAY FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME_DAY);

            /*" -1773- MOVE WTIME-DAYR TO V0HISP-HORAOPER */
            _.Move(AREA_DE_WORK.FILLER_13.WTIME_DAYR, V0HISP_HORAOPER);

            /*" -1774- MOVE V1HISP-DTVENCTO TO V0HISP-DTVENCTO */
            _.Move(V1HISP_DTVENCTO, V0HISP_DTVENCTO);

            /*" -1775- MOVE V1ENDO-BCOCOBR TO V0HISP-BCOCOBR */
            _.Move(V1ENDO_BCOCOBR, V0HISP_BCOCOBR);

            /*" -1776- MOVE V1ENDO-AGECOBR TO V0HISP-AGECOBR */
            _.Move(V1ENDO_AGECOBR, V0HISP_AGECOBR);

            /*" -1777- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -1778- MOVE W0NAES-NRENDOCA TO V0HISP-NRENDOCA */
            _.Move(W0NAES_NRENDOCA, V0HISP_NRENDOCA);

            /*" -1779- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -1780- MOVE 'VE0030B' TO V0HISP-COD-USUARIO */
            _.Move("VE0030B", V0HISP_COD_USUARIO);

            /*" -1781- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -1782- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -1784- MOVE V1PARC-COD-EMP TO V0HISP-COD-EMPRESA */
            _.Move(V1PARC_COD_EMP, V0HISP_COD_EMPRESA);

            /*" -1785- MOVE WP-PRM-TAR TO V0HISP-PRM-TAR */
            _.Move(WP_PRM_TAR, V0HISP_PRM_TAR);

            /*" -1786- MOVE WP-VAL-DESC TO V0HISP-VAL-DESC */
            _.Move(WP_VAL_DESC, V0HISP_VAL_DESC);

            /*" -1787- MOVE WP-VLPRMLIQ TO V0HISP-VLPRMLIQ */
            _.Move(WP_VLPRMLIQ, V0HISP_VLPRMLIQ);

            /*" -1788- MOVE WP-VLADIFRA TO V0HISP-VLADIFRA */
            _.Move(WP_VLADIFRA, V0HISP_VLADIFRA);

            /*" -1789- MOVE WP-VLCUSEMI TO V0HISP-VLCUSEMI */
            _.Move(WP_VLCUSEMI, V0HISP_VLCUSEMI);

            /*" -1790- MOVE WP-VLIOCC TO V0HISP-VLIOCC */
            _.Move(WP_VLIOCC, V0HISP_VLIOCC);

            /*" -1791- MOVE WP-VLPRMTOT TO V0HISP-VLPRMTOT */
            _.Move(WP_VLPRMTOT, V0HISP_VLPRMTOT);

            /*" -1793- MOVE WP-VLPREMIO TO V0HISP-VLPREMIO */
            _.Move(WP_VLPREMIO, V0HISP_VLPREMIO);

            /*" -1793- ADD +1 TO AC-P-V0HISTOPARC. */
            AREA_DE_WORK.AC_P_V0HISTOPARC.Value = AREA_DE_WORK.AC_P_V0HISTOPARC + +1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-MONTA-CORRECAO-SECTION */
        private void R4200_00_MONTA_CORRECAO_SECTION()
        {
            /*" -1806- MOVE '4200' TO WNR-EXEC-SQL. */
            _.Move("4200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1807- MOVE V1PARC-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V1PARC_NUM_APOL, V0HISP_NUM_APOL);

            /*" -1809- MOVE V1PARC-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V1PARC_NRENDOS, V0HISP_NRENDOS);

            /*" -1810- MOVE V1PARC-DACPARC TO V0HISP-DACPARC */
            _.Move(V1PARC_DACPARC, V0HISP_DACPARC);

            /*" -1811- MOVE V1SIST-DTMOVABE TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0HISP_DTMOVTO);

            /*" -1813- MOVE 0804 TO V0HISP-OPERACAO */
            _.Move(0804, V0HISP_OPERACAO);

            /*" -1814- ADD +1 TO WOCORHIST */
            WOCORHIST.Value = WOCORHIST + +1;

            /*" -1816- MOVE WOCORHIST TO V0HISP-OCORHIST */
            _.Move(WOCORHIST, V0HISP_OCORHIST);

            /*" -1817- ACCEPT WTIME-DAY FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME_DAY);

            /*" -1819- MOVE WTIME-DAYR TO V0HISP-HORAOPER */
            _.Move(AREA_DE_WORK.FILLER_13.WTIME_DAYR, V0HISP_HORAOPER);

            /*" -1820- MOVE V1HISP-DTVENCTO TO V0HISP-DTVENCTO */
            _.Move(V1HISP_DTVENCTO, V0HISP_DTVENCTO);

            /*" -1821- MOVE V1ENDO-BCOCOBR TO V0HISP-BCOCOBR */
            _.Move(V1ENDO_BCOCOBR, V0HISP_BCOCOBR);

            /*" -1822- MOVE V1ENDO-AGECOBR TO V0HISP-AGECOBR */
            _.Move(V1ENDO_AGECOBR, V0HISP_AGECOBR);

            /*" -1823- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -1824- MOVE W0NAES-NRENDOCA TO V0HISP-NRENDOCA */
            _.Move(W0NAES_NRENDOCA, V0HISP_NRENDOCA);

            /*" -1825- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -1826- MOVE 'VE0030B' TO V0HISP-COD-USUARIO */
            _.Move("VE0030B", V0HISP_COD_USUARIO);

            /*" -1827- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -1828- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -1830- MOVE V1PARC-COD-EMP TO V0HISP-COD-EMPRESA */
            _.Move(V1PARC_COD_EMP, V0HISP_COD_EMPRESA);

            /*" -1831- MOVE WC-PRM-TAR TO V0HISP-PRM-TAR */
            _.Move(WC_PRM_TAR, V0HISP_PRM_TAR);

            /*" -1832- MOVE WC-VAL-DESC TO V0HISP-VAL-DESC */
            _.Move(WC_VAL_DESC, V0HISP_VAL_DESC);

            /*" -1833- MOVE WC-VLPRMLIQ TO V0HISP-VLPRMLIQ */
            _.Move(WC_VLPRMLIQ, V0HISP_VLPRMLIQ);

            /*" -1834- MOVE WC-VLADIFRA TO V0HISP-VLADIFRA */
            _.Move(WC_VLADIFRA, V0HISP_VLADIFRA);

            /*" -1835- MOVE WC-VLCUSEMI TO V0HISP-VLCUSEMI */
            _.Move(WC_VLCUSEMI, V0HISP_VLCUSEMI);

            /*" -1836- MOVE WC-VLIOCC TO V0HISP-VLIOCC */
            _.Move(WC_VLIOCC, V0HISP_VLIOCC);

            /*" -1837- MOVE WC-VLPRMTOT TO V0HISP-VLPRMTOT */
            _.Move(WC_VLPRMTOT, V0HISP_VLPRMTOT);

            /*" -1839- MOVE WC-VLPREMIO TO V0HISP-VLPREMIO. */
            _.Move(WC_VLPREMIO, V0HISP_VLPREMIO);

            /*" -1839- ADD +1 TO AC-C-V0HISTOPARC. */
            AREA_DE_WORK.AC_C_V0HISTOPARC.Value = AREA_DE_WORK.AC_C_V0HISTOPARC + +1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-INSERT-V0HISTOPARC-SECTION */
        private void R5000_00_INSERT_V0HISTOPARC_SECTION()
        {
            /*" -1852- MOVE '5000' TO WNR-EXEC-SQL. */
            _.Move("5000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1881- PERFORM R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1 */

            R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1();

            /*" -1884- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1885- DISPLAY 'R5000-00 (REGISTRO DUPLICADO) ... ' */
                _.Display($"R5000-00 (REGISTRO DUPLICADO) ... ");

                /*" -1886- DISPLAY 'APOLICE..... ' V0HISP-NUM-APOL */
                _.Display($"APOLICE..... {V0HISP_NUM_APOL}");

                /*" -1887- DISPLAY 'ENDOSSO..... ' V0HISP-NRENDOS */
                _.Display($"ENDOSSO..... {V0HISP_NRENDOS}");

                /*" -1888- DISPLAY 'PARCELA..... ' V0HISP-NRPARCEL */
                _.Display($"PARCELA..... {V0HISP_NRPARCEL}");

                /*" -1889- DISPLAY 'OPERACAO.... ' V0HISP-OPERACAO */
                _.Display($"OPERACAO.... {V0HISP_OPERACAO}");

                /*" -1890- DISPLAY 'OCORHIST.... ' V0HISP-OCORHIST */
                _.Display($"OCORHIST.... {V0HISP_OCORHIST}");

                /*" -1893- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1894- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1895- DISPLAY 'R5000-00 (PROBLEMAS NA INSERCAO) ... ' */
                _.Display($"R5000-00 (PROBLEMAS NA INSERCAO) ... ");

                /*" -1896- DISPLAY 'APOLICE..... ' V0HISP-NUM-APOL */
                _.Display($"APOLICE..... {V0HISP_NUM_APOL}");

                /*" -1897- DISPLAY 'ENDOSSO..... ' V0HISP-NRENDOS */
                _.Display($"ENDOSSO..... {V0HISP_NRENDOS}");

                /*" -1898- DISPLAY 'PARCELA..... ' V0HISP-NRPARCEL */
                _.Display($"PARCELA..... {V0HISP_NRPARCEL}");

                /*" -1899- DISPLAY 'DTMOVTO..... ' V0HISP-DTMOVTO */
                _.Display($"DTMOVTO..... {V0HISP_DTMOVTO}");

                /*" -1900- DISPLAY 'OPERACAO.... ' V0HISP-OPERACAO */
                _.Display($"OPERACAO.... {V0HISP_OPERACAO}");

                /*" -1901- DISPLAY 'DTVENCTO.... ' V0HISP-DTVENCTO */
                _.Display($"DTVENCTO.... {V0HISP_DTVENCTO}");

                /*" -1902- DISPLAY 'NRAVISO..... ' V0HISP-NRAVISO */
                _.Display($"NRAVISO..... {V0HISP_NRAVISO}");

                /*" -1903- DISPLAY 'NRENDOCA.... ' V0HISP-NRENDOCA */
                _.Display($"NRENDOCA.... {V0HISP_NRENDOCA}");

                /*" -1904- DISPLAY 'USUARIO..... ' V0HISP-COD-USUARIO */
                _.Display($"USUARIO..... {V0HISP_COD_USUARIO}");

                /*" -1905- DISPLAY 'DTQITBCO.... ' V0HISP-DTQITBCO */
                _.Display($"DTQITBCO.... {V0HISP_DTQITBCO}");

                /*" -1905- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5000-00-INSERT-V0HISTOPARC-DB-INSERT-1 */
        public void R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -1881- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-DACPARC , :V0HISP-DTMOVTO , :V0HISP-OPERACAO , :V0HISP-HORAOPER , :V0HISP-OCORHIST , :V0HISP-PRM-TAR , :V0HISP-VAL-DESC , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-SITCONTB , :V0HISP-COD-USUARIO , :V0HISP-RNUDOC , :V0HISP-DTQITBCO:VIND-DTQITBCO, :V0HISP-COD-EMPRESA, CURRENT TIMESTAMP) END-EXEC. */

            var r5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1 = new R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V0HISP_DACPARC = V0HISP_DACPARC.ToString(),
                V0HISP_DTMOVTO = V0HISP_DTMOVTO.ToString(),
                V0HISP_OPERACAO = V0HISP_OPERACAO.ToString(),
                V0HISP_HORAOPER = V0HISP_HORAOPER.ToString(),
                V0HISP_OCORHIST = V0HISP_OCORHIST.ToString(),
                V0HISP_PRM_TAR = V0HISP_PRM_TAR.ToString(),
                V0HISP_VAL_DESC = V0HISP_VAL_DESC.ToString(),
                V0HISP_VLPRMLIQ = V0HISP_VLPRMLIQ.ToString(),
                V0HISP_VLADIFRA = V0HISP_VLADIFRA.ToString(),
                V0HISP_VLCUSEMI = V0HISP_VLCUSEMI.ToString(),
                V0HISP_VLIOCC = V0HISP_VLIOCC.ToString(),
                V0HISP_VLPRMTOT = V0HISP_VLPRMTOT.ToString(),
                V0HISP_VLPREMIO = V0HISP_VLPREMIO.ToString(),
                V0HISP_DTVENCTO = V0HISP_DTVENCTO.ToString(),
                V0HISP_BCOCOBR = V0HISP_BCOCOBR.ToString(),
                V0HISP_AGECOBR = V0HISP_AGECOBR.ToString(),
                V0HISP_NRAVISO = V0HISP_NRAVISO.ToString(),
                V0HISP_NRENDOCA = V0HISP_NRENDOCA.ToString(),
                V0HISP_SITCONTB = V0HISP_SITCONTB.ToString(),
                V0HISP_COD_USUARIO = V0HISP_COD_USUARIO.ToString(),
                V0HISP_RNUDOC = V0HISP_RNUDOC.ToString(),
                V0HISP_DTQITBCO = V0HISP_DTQITBCO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                V0HISP_COD_EMPRESA = V0HISP_COD_EMPRESA.ToString(),
            };

            R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1.Execute(r5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-UPDATE-V0PARCELA-SECTION */
        private void R6000_00_UPDATE_V0PARCELA_SECTION()
        {
            /*" -1917- MOVE '6000' TO WNR-EXEC-SQL. */
            _.Move("6000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1925- PERFORM R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1 */

            R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1();

            /*" -1928- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1932- DISPLAY 'R6000-00 (PROBLEMAS UPDATE V0PARCELA) ... ' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL */

                $"R6000-00 (PROBLEMAS UPDATE V0PARCELA) ...  {V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL}"
                .Display();

                /*" -1934- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1934- ADD 1 TO AC-UPDT-V1PARCELA. */
            AREA_DE_WORK.AC_UPDT_V1PARCELA.Value = AREA_DE_WORK.AC_UPDT_V1PARCELA + 1;

        }

        [StopWatch]
        /*" R6000-00-UPDATE-V0PARCELA-DB-UPDATE-1 */
        public void R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1()
        {
            /*" -1925- EXEC SQL UPDATE SEGUROS.V0PARCELA SET OCORHIST = :WOCORHIST, SITUACAO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL = :V0HISP-NRPARCEL END-EXEC. */

            var r6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1 = new R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1()
            {
                WOCORHIST = WOCORHIST.ToString(),
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1.Execute(r6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6100-00-UPDATE-V0ENDOSSO-SECTION */
        private void R6100_00_UPDATE_V0ENDOSSO_SECTION()
        {
            /*" -1946- MOVE '6100' TO WNR-EXEC-SQL. */
            _.Move("6100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1952- PERFORM R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1 */

            R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1();

            /*" -1955- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1958- DISPLAY 'R6100-00 (PROBLEMAS UPDATE V0ENDOSSO) ... ' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS */

                $"R6100-00 (PROBLEMAS UPDATE V0ENDOSSO) ...  {V1PARC_NUM_APOL} {V1PARC_NRENDOS}"
                .Display();

                /*" -1960- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1960- ADD 1 TO AC-UPDT-V1ENDOSSO. */
            AREA_DE_WORK.AC_UPDT_V1ENDOSSO.Value = AREA_DE_WORK.AC_UPDT_V1ENDOSSO + 1;

        }

        [StopWatch]
        /*" R6100-00-UPDATE-V0ENDOSSO-DB-UPDATE-1 */
        public void R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1()
        {
            /*" -1952- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET SITUACAO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V0HISP-NUM-APOL AND NRENDOS = :V0HISP-NRENDOS END-EXEC. */

            var r6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1 = new R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
            };

            R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1.Execute(r6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -1975- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1976- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1977- DISPLAY '*   VE0030B - CANCELAMENTO DE ENDOSSOS     *' */
            _.Display($"*   VE0030B - CANCELAMENTO DE ENDOSSOS     *");

            /*" -1978- DISPLAY '*   -------   ------------ -----------     *' */
            _.Display($"*   -------   ------------ -----------     *");

            /*" -1979- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1980- DISPLAY '*          NAO HOUVE SOLICITACAO           *' */
            _.Display($"*          NAO HOUVE SOLICITACAO           *");

            /*" -1981- DISPLAY '*          --- ----- -----------           *' */
            _.Display($"*          --- ----- -----------           *");

            /*" -1981- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1996- MOVE V1SIST-DTMOVABE TO WDATA-REL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_REL);

            /*" -1997- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -1998- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -2000- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -2001- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -2002- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2003- DISPLAY '*   VE0030B - CANCELAMENTO AUTOMATICO      *' */
            _.Display($"*   VE0030B - CANCELAMENTO AUTOMATICO      *");

            /*" -2004- DISPLAY '*   -------   ------------ ----------      *' */
            _.Display($"*   -------   ------------ ----------      *");

            /*" -2005- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2006- DISPLAY '*      Nao houve parcelas em atraso        *' */
            _.Display($"*      Nao houve parcelas em atraso        *");

            /*" -2007- DISPLAY '*          ate a data informada            *' */
            _.Display($"*          ate a data informada            *");

            /*" -2009- DISPLAY '*               ' WDAT-REL-LIT '                   *' */

            $"*               {AREA_DE_WORK.WDAT_REL_LIT}                   *"
            .Display();

            /*" -2010- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2010- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2025- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -2026- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2027- DISPLAY '*       ABEND OCORRIDO NO PGM VE0030B      *' */
            _.Display($"*       ABEND OCORRIDO NO PGM VE0030B      *");

            /*" -2028- DISPLAY '*       -----------------------------      *' */
            _.Display($"*       -----------------------------      *");

            /*" -2029- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2030- DISPLAY '*         PULAR PARA O PROXIMO STEP        *' */
            _.Display($"*         PULAR PARA O PROXIMO STEP        *");

            /*" -2031- DISPLAY '*         -------------------------        *' */
            _.Display($"*         -------------------------        *");

            /*" -2032- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2034- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -2036- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -2038- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -2038- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -2040- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2044- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -2044- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}