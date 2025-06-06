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
using Sias.VidaEmGrupo.DB2.VG0031B;

namespace Code
{
    public class VG0031B
    {
        public bool IsCall { get; set; }

        public VG0031B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDA EM GRUPO                      *      */
        /*"      *   PROGRAMA ...............  VG0031B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  LUIZ CARLOS                        *      */
        /*"      *   PROGRAMADOR ............  LUIZ CARLOS                        *      */
        /*"      *   DATA CODIFICACAO .......  MAIO/1999                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ..............  CANCELAMENTO DAS APOLICES/SUBGRUPOS   *      */
        /*"      *                          DE APOLICES ESPECIFICAS DE V.G.       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *       A L T E R A C O E S                                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  005 - 26/08/2009 - FAST COMPUTER - EDIVALDO GOMES             *      */
        /*"      *  CRIACAO DOS RELATORIOS DE ERRO NA ROTINA                      *      */
        /*"      *  CADMUS 28521                                                  *      */
        /*"      *                                            PROCURAR POR V.05   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  004 - 08/12/2008 - FAST COMPUTER                              *      */
        /*"      *  CORRECAO DO ABEND OCORRIDO NA TABELA V0HISTSEGVG              *      */
        /*"      *  SQLCODE = 100 - CADMUS 18294                                  *      */
        /*"      *                                            PROCURAR POR V.04   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  003 - 04/06/2007 - MARCO PAIVA                                *      */
        /*"      *  CORRECAO DO ABEND OCORRIDO NA TABELA V1FATURCONT              *      */
        /*"      *  SQLCODE = 100 - CADMUS 3643.                                  *      */
        /*"      *                                            PROCURAR POR V.03   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  002 - 08/05/2007 - MARCO PAIVA                                *      */
        /*"      *  CORRECAO DO ABEND OCORRIDO NA TABELA EXPURGO.RETORNO_EXPURGO*        */
        /*"      *  SQLCODE = -811 - CADMUS 3190.                                 *      */
        /*"      *                                            PROCURAR POR V.02   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  001 - 09/10/2001 - MESSIAS/FREDERICO                          *      */
        /*"      *  MUDADO O ACESSO A TABELA V0CONTACOR PARA A CHAVE PRIMARIA.    *      */
        /*"      *  OCORREU ABEND COM O ACESSO ANTERIOR (-811).                   *      */
        /*"      *                                            PROCURAR POR MM1001 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * COTACAO                             V1COTACAO         INPUT    *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * PARAMRAMO                           V1PARAMRAMO       INPUT    *      */
        /*"      * CONTA CORRENTE                      V1CONTACOR        INPUT    *      */
        /*"      * COBERTURA APOLICE                   V1COBERAPOL       INPUT    *      */
        /*"      * HISTORICO SEGURADOS                 V1HISTSEGVG       INPUT    *      */
        /*"      *                                                                *      */
        /*"      * FONTE                               V0FONTE           I-O      *      */
        /*"      * PARCELAS                            V1PARCELA         I-O      *      */
        /*"      * ENDOSSOS                            V0ENDOSSOS        I-O      *      */
        /*"      * RELATORIOS                          V0RELATORIOS      I-O      *      */
        /*"      * CONTROLE FATURA                     V0FATURCONT       I-O      *      */
        /*"      * SEGURADOS - V.G                     V0SEGURAVG        I-O      *      */
        /*"      * HISTORICO PARCELAS                  V0HISTOPARC       I-O      *      */
        /*"      * NUMERACAO APOLICE/ENDOSSOS          V1NUMERO_AES      I-O      *      */
        /*"      *                                                                *      */
        /*"      * SUBGRUPO                            V0SUBGRUPO        OUTPUT   *      */
        /*"      * MOVIMENTO                           V0MOVIMENTO       OUTPUT   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _DSAIDA { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis DSAIDA
        {
            get
            {
                _.Move(RECORD_DSAIDA, _DSAIDA); VarBasis.RedefinePassValue(RECORD_DSAIDA, _DSAIDA, RECORD_DSAIDA); return _DSAIDA;
            }
        }
        public FileBasis _SSAIDA { get; set; } = new FileBasis(new PIC("X", "250", "X(250)"));

        public FileBasis SSAIDA
        {
            get
            {
                _.Move(RECORD_SSAIDA, _SSAIDA); VarBasis.RedefinePassValue(RECORD_SSAIDA, _SSAIDA, RECORD_SSAIDA); return _SSAIDA;
            }
        }
        /*"01            RECORD-DSAIDA       PIC X(200).*/
        public StringBasis RECORD_DSAIDA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"01            RECORD-SSAIDA       PIC X(250).*/
        public StringBasis RECORD_SSAIDA { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77           V0PROP-CODOPER    PIC S9(004)                 COMP.*/
        public IntBasis V0PROP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           WOCORHIST         PIC S9(004)                 COMP.*/
        public IntBasis WOCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           W0NAES-NRENDOCA   PIC S9(009)      VALUE +0   COMP.*/
        public IntBasis W0NAES_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           WP-PRM-TAR        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VAL-DESC       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WP_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLPRMLIQ       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLADIFRA       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLCUSEMI       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLIOCC         PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLPRMTOT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WP-VLPREMIO       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-PRM-TAR        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WC_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VAL-DESC       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WC_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLPRMLIQ       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WC_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLADIFRA       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WC_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLCUSEMI       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WC_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLIOCC         PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WC_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLPRMTOT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WC_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           WC-VLPREMIO       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WC_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         VIND-DTQITBCO       PIC S9(004)                COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-COD-EMP        PIC S9(004)                COMP.*/
        public IntBasis VIND_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-COD-PRODU      PIC S9(004)                COMP.*/
        public IntBasis VIND_COD_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DT-ADMISSAO    PIC S9(004)                COMP.*/
        public IntBasis VIND_DT_ADMISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DT-NASCI       PIC S9(004)                COMP.*/
        public IntBasis VIND_DT_NASCI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CODPRP         PIC S9(004)                COMP.*/
        public IntBasis VIND_CODPRP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NUMBIL         PIC S9(004)                COMP.*/
        public IntBasis VIND_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-VLVARMON       PIC S9(004)                COMP.*/
        public IntBasis VIND_VLVARMON { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CPF-CGC        PIC S9(004)                COMP.*/
        public IntBasis VIND_CPF_CGC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WS-SEGURAVG         PIC  X(001)    VALUE 'N'.*/
        public StringBasis WS_SEGURAVG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01          WHOST-CODSUBES-I              PIC S9(004)  COMP.*/
        public IntBasis WHOST_CODSUBES_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          WHOST-CODSUBES-F              PIC S9(004)  COMP.*/
        public IntBasis WHOST_CODSUBES_F { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0CTAC-COD-CLIENTE             PIC S9(009)      COMP.*/
        public IntBasis V0CTAC_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V0CTAC-NUM-APOLICE             PIC S9(013)      COMP-3.*/
        public IntBasis V0CTAC_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  V0CTAC-NUM-CTA-COR             PIC S9(017)      COMP-3.*/
        public IntBasis V0CTAC_NUM_CTA_COR { get; set; } = new IntBasis(new PIC("S9", "17", "S9(017)"));
        /*"01  V0CTAC-DAC-CTA-COR             PIC  X(001).*/
        public StringBasis V0CTAC_DAC_CTA_COR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  V0CBA-NUM-APOLICE              PIC S9(013)      COMP-3.*/
        public IntBasis V0CBA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  V0CBA-NRENDOS                  PIC S9(009)      COMP.*/
        public IntBasis V0CBA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V0CBA-NUM-ITEM                 PIC S9(009)      COMP.*/
        public IntBasis V0CBA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V0CBA-OCOR-HIST                PIC S9(004)      COMP.*/
        public IntBasis V0CBA_OCOR_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0CBA-RAMOFR                   PIC S9(004)      COMP.*/
        public IntBasis V0CBA_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0CBA-MODALIFR                 PIC S9(004)      COMP.*/
        public IntBasis V0CBA_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0CBA-CD-COBERTURA             PIC S9(004)      COMP.*/
        public IntBasis V0CBA_CD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0CBA-IMP-SEGURADA             PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0CBA_IMP_SEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  V0CBA-PR-TARIFARIO             PIC S9(010)V9(5) COMP-3.*/
        public DoubleBasis V0CBA_PR_TARIFARIO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01  V0CBA-FATOR-MULTIP             PIC S9(004)      COMP.*/
        public IntBasis V0CBA_FATOR_MULTIP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0CBA-DTINIVIG                 PIC  X(010).*/
        public StringBasis V0CBA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V1PAR-RAMO-VG                  PIC S9(004)      COMP.*/
        public IntBasis V1PAR_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V1PAR-RAMO-AP                  PIC S9(004)      COMP.*/
        public IntBasis V1PAR_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V1PAR-RAMO-PST                 PIC S9(004)      COMP.*/
        public IntBasis V1PAR_RAMO_PST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0VLCRUZAD-IMP                 PIC S9(006)V9(9) COMP-3.*/
        public DoubleBasis V0VLCRUZAD_IMP { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"01  V0VLCRUZAD-PRM                 PIC S9(006)V9(9) COMP-3.*/
        public DoubleBasis V0VLCRUZAD_PRM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"01          V0MOV-IMP-MORNATU        PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0MOV_IMP_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          V0MOV-IMP-MORACID        PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0MOV_IMP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          V0MOV-IMP-INVPERM        PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0MOV_IMP_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          V0MOV-IMP-AMDS           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0MOV_IMP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          V0MOV-IMP-DH             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0MOV_IMP_DH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          V0MOV-IMP-DIT            PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0MOV_IMP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          V0MOV-PRM-VG             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0MOV_PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          V0MOV-PRM-AP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0MOV_PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          V1HSEG-DT-MOVTO               PIC  X(010).*/
        public StringBasis V1HSEG_DT_MOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          V1HSEG-MOEDA-IMP              PIC S9(004)  COMP.*/
        public IntBasis V1HSEG_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1HSEG-MOEDA-PRM              PIC S9(004)  COMP.*/
        public IntBasis V1HSEG_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1FATC-DT-REFER               PIC  X(010).*/
        public StringBasis V1FATC_DT_REFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          V0FONTE-PROPAUTOM             PIC S9(009)  COMP.*/
        public IntBasis V0FONTE_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          V0SEG-NUM-APOL                PIC S9(013)  COMP-3.*/
        public IntBasis V0SEG_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          V0SEG-COD-SUBG                PIC S9(004)  COMP.*/
        public IntBasis V0SEG_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SEG-NUM-CERTIF              PIC S9(015)  COMP-3.*/
        public IntBasis V0SEG_NUM_CERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          V0SEG-DAC-CERTIF              PIC  X(001).*/
        public StringBasis V0SEG_DAC_CERTIF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          V0SEG-TP-SEGURADO             PIC  X(001).*/
        public StringBasis V0SEG_TP_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          V0SEG-NUM-ITEM                PIC S9(009)  COMP.*/
        public IntBasis V0SEG_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          V0SEG-TP-INCLUSAO             PIC  X(001).*/
        public StringBasis V0SEG_TP_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          V0SEG-COD-CLIENTE             PIC S9(009)  COMP.*/
        public IntBasis V0SEG_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          V0SEG-COD-FONTE               PIC S9(004)  COMP.*/
        public IntBasis V0SEG_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SEG-NUM-PROPOSTA            PIC S9(009)  COMP.*/
        public IntBasis V0SEG_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          V0SEG-AGENCIADOR              PIC S9(009)  COMP.*/
        public IntBasis V0SEG_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          V0SEG-CORRETOR                PIC S9(009)  COMP.*/
        public IntBasis V0SEG_CORRETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          V0SEG-CD-PLANOVGAP            PIC S9(004)  COMP.*/
        public IntBasis V0SEG_CD_PLANOVGAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SEG-CD-PLANOAP              PIC S9(004)  COMP.*/
        public IntBasis V0SEG_CD_PLANOAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SEG-FAIXA                   PIC S9(004)  COMP.*/
        public IntBasis V0SEG_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SEG-AUT-AUM-AUT             PIC  X(001).*/
        public StringBasis V0SEG_AUT_AUM_AUT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          V0SEG-TP-BENEFICIA            PIC  X(001).*/
        public StringBasis V0SEG_TP_BENEFICIA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          V0SEG-OCORR-HIST              PIC S9(004)    COMP.*/
        public IntBasis V0SEG_OCORR_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SEG-PERI-PGTO               PIC S9(004)    COMP.*/
        public IntBasis V0SEG_PERI_PGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SEG-PERI-RENOVA             PIC S9(004)    COMP.*/
        public IntBasis V0SEG_PERI_RENOVA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SEG-NUM-CARNE               PIC S9(004)    COMP.*/
        public IntBasis V0SEG_NUM_CARNE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SEG-COD-OCUPACAO            PIC  X(004).*/
        public StringBasis V0SEG_COD_OCUPACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
        /*"01          V0SEG-EST-CIVIL               PIC  X(001).*/
        public StringBasis V0SEG_EST_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          V0SEG-SEXO                    PIC  X(001).*/
        public StringBasis V0SEG_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          V0SEG-CD-PROFISSAO            PIC S9(004)    COMP.*/
        public IntBasis V0SEG_CD_PROFISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SEG-NATURALIDADE            PIC  X(030).*/
        public StringBasis V0SEG_NATURALIDADE { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"01          V0SEG-OCOR-ENDERE             PIC S9(004)    COMP.*/
        public IntBasis V0SEG_OCOR_ENDERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SEG-OCOR-END-COB            PIC S9(004)    COMP.*/
        public IntBasis V0SEG_OCOR_END_COB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SEG-BCO-COBRANCA            PIC S9(004)    COMP.*/
        public IntBasis V0SEG_BCO_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SEG-AGE-COBRANCA            PIC S9(004)    COMP.*/
        public IntBasis V0SEG_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SEG-DAC-COBRANCA            PIC  X(001).*/
        public StringBasis V0SEG_DAC_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          V0SEG-NUM-MATRIC              PIC S9(015)    COMP-3.*/
        public IntBasis V0SEG_NUM_MATRIC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          V0SEG-VAL-SALARIO             PIC S9(013)V99  COMP-3*/
        public DoubleBasis V0SEG_VAL_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          V0SEG-TP-SALARIO              PIC  X(001).*/
        public StringBasis V0SEG_TP_SALARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          V0SEG-TP-PLANO                PIC  X(001).*/
        public StringBasis V0SEG_TP_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          V0SEG-DT-INIVIG               PIC  X(010).*/
        public StringBasis V0SEG_DT_INIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          V0SEG-PCT-CONJ-VG             PIC S9(003)V99  COMP-3*/
        public DoubleBasis V0SEG_PCT_CONJ_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01          V0SEG-PCT-CONJ-AP             PIC S9(003)V99  COMP-3*/
        public DoubleBasis V0SEG_PCT_CONJ_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01          V0SEG-QTD-S-MONATU            PIC S9(004)     COMP.*/
        public IntBasis V0SEG_QTD_S_MONATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SEG-QTD-S-MOACID            PIC S9(004)     COMP.*/
        public IntBasis V0SEG_QTD_S_MOACID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SEG-QTD-S-INVPER            PIC S9(004)     COMP.*/
        public IntBasis V0SEG_QTD_S_INVPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SEG-TX-AP-MOACID            PIC S9(03)V9(4) COMP-3*/
        public DoubleBasis V0SEG_TX_AP_MOACID { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(4)"), 4);
        /*"01          V0SEG-TX-AP-INVPER            PIC S9(03)V9(4) COMP-3*/
        public DoubleBasis V0SEG_TX_AP_INVPER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(4)"), 4);
        /*"01          V0SEG-TX-AP-AMDS              PIC S9(03)V9(4) COMP-3*/
        public DoubleBasis V0SEG_TX_AP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(4)"), 4);
        /*"01          V0SEG-TX-AP-DH                PIC S9(03)V9(4) COMP-3*/
        public DoubleBasis V0SEG_TX_AP_DH { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(4)"), 4);
        /*"01          V0SEG-TX-AP-DIT               PIC S9(03)V9(4) COMP-3*/
        public DoubleBasis V0SEG_TX_AP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(4)"), 4);
        /*"01          V0SEG-TAXA-AP                 PIC S9(03)V9(4) COMP-3*/
        public DoubleBasis V0SEG_TAXA_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(4)"), 4);
        /*"01          V0SEG-TAXA-VG                 PIC S9(03)V9(4) COMP-3*/
        public DoubleBasis V0SEG_TAXA_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(4)"), 4);
        /*"01          V0SEG-SIT-REGISTRO            PIC  X(01).*/
        public StringBasis V0SEG_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01          V0SEG-DT-ADMISSAO             PIC  X(10).*/
        public StringBasis V0SEG_DT_ADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01          V0SEG-DT-NASCI                PIC  X(10).*/
        public StringBasis V0SEG_DT_NASCI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01          V0SEG-COD-EMPRESA             PIC S9(009)     COMP.*/
        public IntBasis V0SEG_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          V0SEG-CPF-CGC                 PIC S9(15)      COMP-3*/
        public IntBasis V0SEG_CPF_CGC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01          V0SEG-LOT-EMP-SEGURADO        PIC  X(30).*/
        public StringBasis V0SEG_LOT_EMP_SEGURADO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"01          WLOT-EMP-SEGURADO             PIC S9(004)  COMP.*/
        public IntBasis WLOT_EMP_SEGURADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1FUNC-NUM-MATRIC             PIC S9(015)  COMP-3.*/
        public IntBasis V1FUNC_NUM_MATRIC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          V1FUNC-COD-ANGARIA            PIC S9(009)  COMP.*/
        public IntBasis V1FUNC_COD_ANGARIA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          V1PROD-COD-ESCNEG             PIC S9(004)  COMP.*/
        public IntBasis V1PROD_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1PROD-DTINIVIG               PIC  X(010).*/
        public StringBasis V1PROD_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          V1PROD-DTTERVIG               PIC  X(010).*/
        public StringBasis V1PROD_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          V1PROD-NUM-MATRIC             PIC S9(015)  COMP-3.*/
        public IntBasis V1PROD_NUM_MATRIC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          V1AGENC-COD-AGENCIA           PIC S9(004)  COMP.*/
        public IntBasis V1AGENC_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1AGENC-COD-SUREG             PIC S9(004)  COMP.*/
        public IntBasis V1AGENC_COD_SUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1AGENC-COD-ESCNEG            PIC S9(004)  COMP.*/
        public IntBasis V1AGENC_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1AGENC-SITUACAO              PIC  X(001).*/
        public StringBasis V1AGENC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          V1MALHA-COD-SUREG             PIC S9(004)  COMP.*/
        public IntBasis V1MALHA_COD_SUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1MALHA-COD-FONTE             PIC S9(004)  COMP.*/
        public IntBasis V1MALHA_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1REL-COD-USUR                PIC  X(008).*/
        public StringBasis V1REL_COD_USUR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01          V1REL-CODRELAT                PIC  X(008).*/
        public StringBasis V1REL_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01          V1REL-NUM-APOL                PIC S9(013)  COMP-3.*/
        public IntBasis V1REL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          V1REL-COD-SUBG                PIC S9(004)  COMP.*/
        public IntBasis V1REL_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V1REL-SIT-REGISTRO            PIC  X(001).*/
        public StringBasis V1REL_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          V1REL-APOL-RAMO               PIC S9(004)  COMP.*/
        public IntBasis V1REL_APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0SUBG-NUM-APOL               PIC S9(013)  COMP-3.*/
        public IntBasis V0SUBG_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          V0SUBG-COD-SUBG               PIC S9(004)  COMP.*/
        public IntBasis V0SUBG_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01            V0PROD-NOMPRODU             PIC X(030).*/
        public StringBasis V0PROD_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"01            V0PROD-CODPRODU             PIC S9(004)  COMP.*/
        public IntBasis V0PROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0NAES-NRENDOCA     PIC S9(009)                COMP.*/
        public IntBasis V0NAES_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1ENDO-NUM-APOL    PIC S9(013)                 COMP-3*/
        public IntBasis V1ENDO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V1ENDO-NRENDOS     PIC S9(009)                 COMP.*/
        public IntBasis V1ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1ENDO-CODSUBES    PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1ENDO-CODPRODU    PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1ENDO-ORGAO       PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1ENDO-RAMO        PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1ENDO-DTEMIS      PIC  X(010).*/
        public StringBasis V1ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1ENDO-NRRCAP      PIC S9(009)                 COMP.*/
        public IntBasis V1ENDO_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1ENDO-VLRCAP      PIC S9(013)V99              COMP-3*/
        public DoubleBasis V1ENDO_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V1ENDO-BCORCAP     PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_BCORCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1ENDO-AGERCAP     PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1ENDO-DACRCAP     PIC  X(001).*/
        public StringBasis V1ENDO_DACRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1ENDO-IDRCAP      PIC  X(001).*/
        public StringBasis V1ENDO_IDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1ENDO-BCOCOBR     PIC S9(009)                 COMP.*/
        public IntBasis V1ENDO_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1ENDO-AGECOBR     PIC S9(009)                 COMP.*/
        public IntBasis V1ENDO_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1ENDO-DACCOBR     PIC  X(001).*/
        public StringBasis V1ENDO_DACCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1ENDO-DTINIVIG    PIC  X(010).*/
        public StringBasis V1ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1ENDO-DTTERVIG    PIC  X(010).*/
        public StringBasis V1ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1ENDO-QTPARCEL    PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1ENDO-SITUACAO    PIC  X(001).*/
        public StringBasis V1ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1ENDO-COD-EMP     PIC S9(009)                 COMP.*/
        public IntBasis V1ENDO_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1PARC-NUM-APOL    PIC S9(013)                 COMP-3*/
        public IntBasis V1PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V1PARC-NRENDOS     PIC S9(009)                 COMP.*/
        public IntBasis V1PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1PARC-NRPARCEL    PIC S9(004)                 COMP.*/
        public IntBasis V1PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1PARC-DACPARC     PIC  X(001).*/
        public StringBasis V1PARC_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1PARC-FONTE       PIC S9(004)                 COMP.*/
        public IntBasis V1PARC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1PARC-NRTIT       PIC S9(013)                 COMP-3*/
        public IntBasis V1PARC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V1PARC-OCORHIST    PIC S9(004)                 COMP.*/
        public IntBasis V1PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1PARC-QTDDOC      PIC S9(004)                 COMP.*/
        public IntBasis V1PARC_QTDDOC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1PARC-SITUACAO    PIC  X(001).*/
        public StringBasis V1PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1PARC-COD-EMP     PIC S9(009)                 COMP.*/
        public IntBasis V1PARC_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0PARC-NUM-APOL    PIC S9(013)                 COMP-3*/
        public IntBasis V0PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0PARC-NRENDOS     PIC S9(009)                 COMP.*/
        public IntBasis V0PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0PARC-NRPARCEL    PIC S9(004)                 COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PARC-SITUACAO    PIC  X(001).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1HISP-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V1HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V1HISP-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis V1HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1HISP-NRPARCEL     PIC S9(004)                COMP.*/
        public IntBasis V1HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1HISP-DACPARC      PIC  X(001).*/
        public StringBasis V1HISP_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1HISP-DTMOVTO      PIC  X(010).*/
        public StringBasis V1HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1HISP-OPERACAO     PIC S9(004)                COMP.*/
        public IntBasis V1HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1HISP-HORAOPER     PIC  X(008).*/
        public StringBasis V1HISP_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01         V1HISP-OCORHIST     PIC S9(004)                COMP.*/
        public IntBasis V1HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1HISP-PRM-TAR      PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V1HISP-VAL-DESC     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V1HISP-VLPRMLIQ     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V1HISP-VLADIFRA     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V1HISP-VLCUSEMI     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V1HISP-VLIOCC       PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V1HISP-VLPRMTOT     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V1HISP-VLPREMIO     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HISP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V1HISP-DTVENCTO     PIC  X(010).*/
        public StringBasis V1HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1HISP-BCOCOBR      PIC S9(004)                COMP.*/
        public IntBasis V1HISP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1HISP-AGECOBR      PIC S9(004)                COMP.*/
        public IntBasis V1HISP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1HISP-NRAVISO      PIC S9(009)                COMP.*/
        public IntBasis V1HISP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1HISP-NRENDOCA     PIC S9(009)                COMP.*/
        public IntBasis V1HISP_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1HISP-SITCONTB     PIC  X(001).*/
        public StringBasis V1HISP_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1HISP-COD-USUARIO  PIC  X(008).*/
        public StringBasis V1HISP_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01         V1HISP-RNUDOC       PIC S9(009)                COMP.*/
        public IntBasis V1HISP_RNUDOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1HISP-DTQITBCO     PIC  X(010).*/
        public StringBasis V1HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1HISP-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V1HISP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0HISP-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis V0HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-NRPARCEL     PIC S9(004)                COMP.*/
        public IntBasis V0HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-DACPARC      PIC  X(001).*/
        public StringBasis V0HISP_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0HISP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0HISP-OPERACAO     PIC S9(004)                COMP.*/
        public IntBasis V0HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-HORAOPER     PIC  X(008).*/
        public StringBasis V0HISP_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01         V0HISP-OCORHIST     PIC S9(004)                COMP.*/
        public IntBasis V0HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-PRM-TAR      PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V0HISP-VAL-DESC     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V0HISP-VLPRMLIQ     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V0HISP-VLADIFRA     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V0HISP-VLCUSEMI     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V0HISP-VLIOCC       PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V0HISP-VLPRMTOT     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V0HISP-VLPREMIO     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V0HISP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V0HISP-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0HISP-BCOCOBR      PIC S9(004)                COMP.*/
        public IntBasis V0HISP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-AGECOBR      PIC S9(004)                COMP.*/
        public IntBasis V0HISP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-NRAVISO      PIC S9(009)                COMP.*/
        public IntBasis V0HISP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-NRENDOCA     PIC S9(009)                COMP.*/
        public IntBasis V0HISP_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-SITCONTB     PIC  X(001).*/
        public StringBasis V0HISP_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0HISP-COD-USUARIO  PIC  X(008).*/
        public StringBasis V0HISP_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01         V0HISP-RNUDOC       PIC S9(009)                COMP.*/
        public IntBasis V0HISP_RNUDOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-DTQITBCO     PIC  X(010).*/
        public StringBasis V0HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0HISP-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V0HISP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01           AREA-DE-WORK.*/
        public VG0031B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0031B_AREA_DE_WORK();
        public class VG0031B_AREA_DE_WORK : VarBasis
        {
            /*"  05         AC-L-V1PARCELA    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_V1PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-V1ENDOSSO    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_V1ENDOSSO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-V0SUBGRUPO   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_V0SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-C-V0HISTOPARC  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_C_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-P-V0HISTOPARC  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_P_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-V0SEGURAVG   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_V0SEGURAVG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0SEGURAVG   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0SEGURAVG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-V0RELATORIOS PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_V0RELATORIOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-EXPURGO      PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_EXPURGO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-EXPURGADO      PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_EXPURGADO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-UPDT-V1ENDOSSO  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_UPDT_V1ENDOSSO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-UPDT-V1PARCELA  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_UPDT_V1PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-UPDT-V1APOLICE  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_UPDT_V1APOLICE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-UPDT-V1SUBGRUPO PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_UPDT_V1SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-ERRO-DADOS      PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_ERRO_DADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         AC-ERRO-SISTEMA    PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_ERRO_SISTEMA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WFIM-V1SISTEMA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PARCELA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0SUBGRUPO   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0SUBGRUPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0PARCELA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1HISTOPARC  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0RELATORIOS PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0SEGURAVG   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0SEGURAVG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1ENDOSSO    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-V1PARCELA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_V1PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-V1HISTOPARC  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_V1HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WHOUVE-CANCELA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WHOUVE_CANCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      HD-REG-DSAIDA.*/
            public VG0031B_HD_REG_DSAIDA HD_REG_DSAIDA { get; set; } = new VG0031B_HD_REG_DSAIDA();
            public class VG0031B_HD_REG_DSAIDA : VarBasis
            {
                /*"    10    HD-COD-PRO-DSAIDA   PIC  X(008)   VALUE 'VG0031B'.*/
                public StringBasis HD_COD_PRO_DSAIDA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0031B");
                /*"    10    HD-DES-REL-DSAIDA   PIC  X(050)   VALUE    'RELATORIO DE ERROS DE DADOS'.*/
                public StringBasis HD_DES_REL_DSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"RELATORIO DE ERROS DE DADOS");
                /*"    10    HD-DTA-SIS-DSAIDA   PIC  X(010)   VALUE SPACES.*/
                public StringBasis HD_DTA_SIS_DSAIDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05      CB-REG-DSAIDA.*/
            }
            public VG0031B_CB_REG_DSAIDA CB_REG_DSAIDA { get; set; } = new VG0031B_CB_REG_DSAIDA();
            public class VG0031B_CB_REG_DSAIDA : VarBasis
            {
                /*"    10    FILLER              PIC  X(045)   VALUE    'APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;");
                /*"    10    FILLER              PIC  X(042)   VALUE    'CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;");
                /*"    10    FILLER              PIC  X(033)   VALUE    'DETALHAMENTO DO PROBLEMA OCORRIDO'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"DETALHAMENTO DO PROBLEMA OCORRIDO");
                /*"  05      LD-REG-DSAIDA.*/
            }
            public VG0031B_LD_REG_DSAIDA LD_REG_DSAIDA { get; set; } = new VG0031B_LD_REG_DSAIDA();
            public class VG0031B_LD_REG_DSAIDA : VarBasis
            {
                /*"    10    LD-NUM-APOL-DSAIDA         PIC 9(013).*/
                public IntBasis LD_NUM_APOL_DSAIDA { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-COD-SUBG-DSAIDA         PIC 9(004).*/
                public IntBasis LD_COD_SUBG_DSAIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-COD-PROD-DSAIDA         PIC 9(004).*/
                public IntBasis LD_COD_PROD_DSAIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-NOM-PROD-DSAIDA         PIC X(030).*/
                public StringBasis LD_NOM_PROD_DSAIDA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-NUM-CERT-SUB-DSAIDA     PIC 9(015).*/
                public IntBasis LD_NUM_CERT_SUB_DSAIDA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-NUM-CERT-SEG-DSAIDA     PIC 9(015).*/
                public IntBasis LD_NUM_CERT_SEG_DSAIDA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-DES-ERRO-DSAIDA         PIC X(080).*/
                public StringBasis LD_DES_ERRO_DSAIDA { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"  05      HD-REG-SSAIDA.*/
            }
            public VG0031B_HD_REG_SSAIDA HD_REG_SSAIDA { get; set; } = new VG0031B_HD_REG_SSAIDA();
            public class VG0031B_HD_REG_SSAIDA : VarBasis
            {
                /*"    10    HD-COD-PRO-SSAIDA   PIC  X(008)   VALUE 'VG0031B'.*/
                public StringBasis HD_COD_PRO_SSAIDA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0031B");
                /*"    10    HD-DES-REL-SSAIDA   PIC  X(050)   VALUE    'RELATORIO DE ERROS DE SISTEMAS'.*/
                public StringBasis HD_DES_REL_SSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"RELATORIO DE ERROS DE SISTEMAS");
                /*"    10    HD-DTA-SIS-SSAIDA   PIC  X(010)   VALUE SPACES.*/
                public StringBasis HD_DTA_SIS_SSAIDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05      CB-REG-SSAIDA.*/
            }
            public VG0031B_CB_REG_SSAIDA CB_REG_SSAIDA { get; set; } = new VG0031B_CB_REG_SSAIDA();
            public class VG0031B_CB_REG_SSAIDA : VarBasis
            {
                /*"    10    FILLER              PIC  X(045)   VALUE    'APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;");
                /*"    10    FILLER              PIC  X(042)   VALUE    'CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;");
                /*"    10    FILLER              PIC  X(035)   VALUE    'CODIGO ERRO DB2;DESCRICAO ERRO DB2;'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"CODIGO ERRO DB2;DESCRICAO ERRO DB2;");
                /*"    10    FILLER              PIC  X(034)   VALUE    'DETALHAMENTO DO PROBLEMA OCORRIDO;'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"DETALHAMENTO DO PROBLEMA OCORRIDO;");
                /*"    10    FILLER              PIC  X(016)   VALUE    'PROGRAMA'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"PROGRAMA");
                /*"  05      LD-REG-SSAIDA.*/
            }
            public VG0031B_LD_REG_SSAIDA LD_REG_SSAIDA { get; set; } = new VG0031B_LD_REG_SSAIDA();
            public class VG0031B_LD_REG_SSAIDA : VarBasis
            {
                /*"    10    LD-NUM-APOL-SSAIDA         PIC 9(013).*/
                public IntBasis LD_NUM_APOL_SSAIDA { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-COD-SUBG-SSAIDA         PIC 9(004).*/
                public IntBasis LD_COD_SUBG_SSAIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-COD-PROD-SSAIDA         PIC 9(004).*/
                public IntBasis LD_COD_PROD_SSAIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-NOM-PROD-SSAIDA         PIC X(030).*/
                public StringBasis LD_NOM_PROD_SSAIDA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-NUM-CERT-SUB-SSAIDA     PIC 9(015).*/
                public IntBasis LD_NUM_CERT_SUB_SSAIDA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-NUM-CERT-SEG-SSAIDA     PIC 9(015).*/
                public IntBasis LD_NUM_CERT_SEG_SSAIDA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-COD-ERRO-DB2-SSAIDA     PIC -9(004).*/
                public IntBasis LD_COD_ERRO_DB2_SSAIDA { get; set; } = new IntBasis(new PIC("-9", "4", "-9(004)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-DES-ERRO-DB2-SSAIDA     PIC X(050).*/
                public StringBasis LD_DES_ERRO_DB2_SSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-DES-ERRO-SSAIDA         PIC X(050).*/
                public StringBasis LD_DES_ERRO_SSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-NOM-PROG-SSAIDA        PIC X(008) VALUE 'VG0031B'.*/
                public StringBasis LD_NOM_PROG_SSAIDA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0031B");
                /*"  05         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VG0031B_FILLER_23 _filler_23 { get; set; }
            public _REDEF_VG0031B_FILLER_23 FILLER_23
            {
                get { _filler_23 = new _REDEF_VG0031B_FILLER_23(); _.Move(WDATA_REL, _filler_23); VarBasis.RedefinePassValue(WDATA_REL, _filler_23, WDATA_REL); _filler_23.ValueChanged += () => { _.Move(_filler_23, WDATA_REL); }; return _filler_23; }
                set { VarBasis.RedefinePassValue(value, _filler_23, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VG0031B_FILLER_23 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDAT-REF-AUX      PIC  X(010)    VALUE SPACES.*/

                public _REDEF_VG0031B_FILLER_23()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_24.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_25.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDAT_REF_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDAT-REF-AUX.*/
            private _REDEF_VG0031B_FILLER_26 _filler_26 { get; set; }
            public _REDEF_VG0031B_FILLER_26 FILLER_26
            {
                get { _filler_26 = new _REDEF_VG0031B_FILLER_26(); _.Move(WDAT_REF_AUX, _filler_26); VarBasis.RedefinePassValue(WDAT_REF_AUX, _filler_26, WDAT_REF_AUX); _filler_26.ValueChanged += () => { _.Move(_filler_26, WDAT_REF_AUX); }; return _filler_26; }
                set { VarBasis.RedefinePassValue(value, _filler_26, WDAT_REF_AUX); }
            }  //Redefines
            public class _REDEF_VG0031B_FILLER_26 : VarBasis
            {
                /*"    10       WDAT-REF-ANO      PIC  9(004).*/
                public IntBasis WDAT_REF_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REF-MES      PIC  9(002).*/
                public IntBasis WDAT_REF_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REF-DIA      PIC  9(002).*/
                public IntBasis WDAT_REF_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDAT-REL-LIT.*/

                public _REDEF_VG0031B_FILLER_26()
                {
                    WDAT_REF_ANO.ValueChanged += OnValueChanged;
                    FILLER_27.ValueChanged += OnValueChanged;
                    WDAT_REF_MES.ValueChanged += OnValueChanged;
                    FILLER_28.ValueChanged += OnValueChanged;
                    WDAT_REF_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VG0031B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VG0031B_WDAT_REL_LIT();
            public class VG0031B_WDAT_REL_LIT : VarBasis
            {
                /*"    10       WDAT-LIT-DIA      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-MES      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-ANO      PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WEMIS-DATA        PIC  X(010)    VALUE ZEROS.*/
            }
            public StringBasis WEMIS_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WEMIS-DATA.*/
            private _REDEF_VG0031B_FILLER_31 _filler_31 { get; set; }
            public _REDEF_VG0031B_FILLER_31 FILLER_31
            {
                get { _filler_31 = new _REDEF_VG0031B_FILLER_31(); _.Move(WEMIS_DATA, _filler_31); VarBasis.RedefinePassValue(WEMIS_DATA, _filler_31, WEMIS_DATA); _filler_31.ValueChanged += () => { _.Move(_filler_31, WEMIS_DATA); }; return _filler_31; }
                set { VarBasis.RedefinePassValue(value, _filler_31, WEMIS_DATA); }
            }  //Redefines
            public class _REDEF_VG0031B_FILLER_31 : VarBasis
            {
                /*"    10       WEMIS-ANOMES.*/
                public VG0031B_WEMIS_ANOMES WEMIS_ANOMES { get; set; } = new VG0031B_WEMIS_ANOMES();
                public class VG0031B_WEMIS_ANOMES : VarBasis
                {
                    /*"      15     WEMI-ANO          PIC  9(004).*/
                    public IntBasis WEMI_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15     FILLER            PIC  X(001).*/
                    public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WEMI-MES          PIC  9(002).*/
                    public IntBasis WEMI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       FILLER            PIC  X(001).*/

                    public VG0031B_WEMIS_ANOMES()
                    {
                        WEMI_ANO.ValueChanged += OnValueChanged;
                        FILLER_32.ValueChanged += OnValueChanged;
                        WEMI_MES.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WEMI-DIA          PIC  9(002).*/
                public IntBasis WEMI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WSIST-DATA        PIC  X(010)    VALUE ZEROS.*/

                public _REDEF_VG0031B_FILLER_31()
                {
                    WEMIS_ANOMES.ValueChanged += OnValueChanged;
                    FILLER_33.ValueChanged += OnValueChanged;
                    WEMI_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WSIST_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WSIST-DATA.*/
            private _REDEF_VG0031B_FILLER_34 _filler_34 { get; set; }
            public _REDEF_VG0031B_FILLER_34 FILLER_34
            {
                get { _filler_34 = new _REDEF_VG0031B_FILLER_34(); _.Move(WSIST_DATA, _filler_34); VarBasis.RedefinePassValue(WSIST_DATA, _filler_34, WSIST_DATA); _filler_34.ValueChanged += () => { _.Move(_filler_34, WSIST_DATA); }; return _filler_34; }
                set { VarBasis.RedefinePassValue(value, _filler_34, WSIST_DATA); }
            }  //Redefines
            public class _REDEF_VG0031B_FILLER_34 : VarBasis
            {
                /*"    10       WSIST-ANOMES.*/
                public VG0031B_WSIST_ANOMES WSIST_ANOMES { get; set; } = new VG0031B_WSIST_ANOMES();
                public class VG0031B_WSIST_ANOMES : VarBasis
                {
                    /*"      15     WSIS-ANO          PIC  9(004).*/
                    public IntBasis WSIS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15     FILLER            PIC  X(001).*/
                    public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WSIS-MES          PIC  9(002).*/
                    public IntBasis WSIS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       FILLER            PIC  X(001).*/

                    public VG0031B_WSIST_ANOMES()
                    {
                        WSIS_ANO.ValueChanged += OnValueChanged;
                        FILLER_35.ValueChanged += OnValueChanged;
                        WSIS_MES.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WSIS-DIA          PIC  9(002).*/
                public IntBasis WSIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         CH-CHAVE-ATU.*/

                public _REDEF_VG0031B_FILLER_34()
                {
                    WSIST_ANOMES.ValueChanged += OnValueChanged;
                    FILLER_36.ValueChanged += OnValueChanged;
                    WSIS_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VG0031B_CH_CHAVE_ATU CH_CHAVE_ATU { get; set; } = new VG0031B_CH_CHAVE_ATU();
            public class VG0031B_CH_CHAVE_ATU : VarBasis
            {
                /*"    10       CH-APOLI-ATU      PIC  9(013)    VALUE ZEROS.*/
                public IntBasis CH_APOLI_ATU { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    10       CH-ENDOS-ATU      PIC  9(006)    VALUE ZEROS.*/
                public IntBasis CH_ENDOS_ATU { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"  05         CH-CHAVE-ANT.*/
            }
            public VG0031B_CH_CHAVE_ANT CH_CHAVE_ANT { get; set; } = new VG0031B_CH_CHAVE_ANT();
            public class VG0031B_CH_CHAVE_ANT : VarBasis
            {
                /*"    10       CH-APOLI-ANT      PIC  9(013)    VALUE ZEROS.*/
                public IntBasis CH_APOLI_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    10       CH-ENDOS-ANT      PIC  9(006)    VALUE ZEROS.*/
                public IntBasis CH_ENDOS_ANT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"  05  W-DATA.*/
            }
            public VG0031B_W_DATA W_DATA { get; set; } = new VG0031B_W_DATA();
            public class VG0031B_W_DATA : VarBasis
            {
                /*"    07  W-DD                    PIC  9(02).*/
                public IntBasis W_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    07  W-MM                    PIC  9(02).*/
                public IntBasis W_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    07  W-AA                    PIC  9(04).*/
                public IntBasis W_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"  05  W-DATA-EDITADA.*/
            }
            public VG0031B_W_DATA_EDITADA W_DATA_EDITADA { get; set; } = new VG0031B_W_DATA_EDITADA();
            public class VG0031B_W_DATA_EDITADA : VarBasis
            {
                /*"    07  W-ANO                   PIC  9(04).*/
                public IntBasis W_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    07  FILLER                  PIC  X(01).*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"    07  W-MES                   PIC  9(02).*/
                public IntBasis W_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    07  FILLER                  PIC  X(01).*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"    07  W-DIA                   PIC  9(02).*/
                public IntBasis W_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  05         WTIME-DAY         PIC  99.99.99.99.*/
            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  05         FILLER            REDEFINES      WTIME-DAY.*/
            private _REDEF_VG0031B_FILLER_39 _filler_39 { get; set; }
            public _REDEF_VG0031B_FILLER_39 FILLER_39
            {
                get { _filler_39 = new _REDEF_VG0031B_FILLER_39(); _.Move(WTIME_DAY, _filler_39); VarBasis.RedefinePassValue(WTIME_DAY, _filler_39, WTIME_DAY); _filler_39.ValueChanged += () => { _.Move(_filler_39, WTIME_DAY); }; return _filler_39; }
                set { VarBasis.RedefinePassValue(value, _filler_39, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_VG0031B_FILLER_39 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public VG0031B_WTIME_DAYR WTIME_DAYR { get; set; } = new VG0031B_WTIME_DAYR();
                public class VG0031B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA        PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT1        PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-MINU        PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT2        PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-SEGU        PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10       WTIME-2PT3        PIC  X(001).*/

                    public VG0031B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-CCSG        PIC  X(002).*/
                public StringBasis WTIME_CCSG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05        WABEND.*/

                public _REDEF_VG0031B_FILLER_39()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSG.ValueChanged += OnValueChanged;
                }

            }
            public VG0031B_WABEND WABEND { get; set; } = new VG0031B_WABEND();
            public class VG0031B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(009) VALUE           'VG0031B '.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"VG0031B ");
                /*"    10      FILLER              PIC  X(035) VALUE           ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
                /*"    10      WNR-EXEC-SQL        PIC  X(008) VALUE '00000000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"00000000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"  05         WS-EXPURGO             PIC  9         VALUE ZERO.*/
            }

            public SelectorBasis WS_EXPURGO { get; set; } = new SelectorBasis("9", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88       EXISTE-EXPURGO                        VALUE 1. */
							new SelectorItemBasis("EXISTE_EXPURGO", "1")
                }
            };

            /*"  05         WS-SOLI-EXPURGO        PIC  9         VALUE ZERO.*/

            public SelectorBasis WS_SOLI_EXPURGO { get; set; } = new SelectorBasis("9", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88       EXPURGO-SOLICITADO                    VALUE 1. */
							new SelectorItemBasis("EXPURGO_SOLICITADO", "1")
                }
            };

            /*"  05         WS-RELATORIO           PIC  9         VALUE ZERO.*/

            public SelectorBasis WS_RELATORIO { get; set; } = new SelectorBasis("9", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88       ATUALIZA-RELATORIO                    VALUE 1. */
							new SelectorItemBasis("ATUALIZA_RELATORIO", "1")
                }
            };

            /*"  05         WS-EXPURGO-SUBGRUPO    PIC  9         VALUE ZERO.*/

            public SelectorBasis WS_EXPURGO_SUBGRUPO { get; set; } = new SelectorBasis("9", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88       HOUVE-EXPURGO-SUBGRUPO                VALUE 1. */
							new SelectorItemBasis("HOUVE_EXPURGO_SUBGRUPO", "1")
                }
            };

        }


        public Dclgens.APOLIEXP APOLIEXP { get; set; } = new Dclgens.APOLIEXP();
        public Dclgens.RETOREXP RETOREXP { get; set; } = new Dclgens.RETOREXP();
        public VG0031B_V0RELATORIOS V0RELATORIOS { get; set; } = new VG0031B_V0RELATORIOS();
        public VG0031B_V0SUBGRUPO V0SUBGRUPO { get; set; } = new VG0031B_V0SUBGRUPO();
        public VG0031B_V0SEGURAVG V0SEGURAVG { get; set; } = new VG0031B_V0SEGURAVG();
        public VG0031B_V1ENDOSSO V1ENDOSSO { get; set; } = new VG0031B_V1ENDOSSO();
        public VG0031B_V1PARCELA V1PARCELA { get; set; } = new VG0031B_V1PARCELA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string DSAIDA_FILE_NAME_P, string SSAIDA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                DSAIDA.SetFile(DSAIDA_FILE_NAME_P);
                SSAIDA.SetFile(SSAIDA_FILE_NAME_P);

                /*" -707- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -708- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -711- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -714- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -714- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -722- OPEN OUTPUT DSAIDA SSAIDA. */
            DSAIDA.Open(RECORD_DSAIDA);
            SSAIDA.Open(RECORD_SSAIDA);

            /*" -726- MOVE ZEROS TO V1REL-NUM-APOL V0SUBG-COD-SUBG V0SEG-NUM-CERTIF V0PROD-CODPRODU. */
            _.Move(0, V1REL_NUM_APOL, V0SUBG_COD_SUBG, V0SEG_NUM_CERTIF, V0PROD_CODPRODU);

            /*" -729- MOVE SPACES TO V0PROD-NOMPRODU V0SEG-TP-SEGURADO. */
            _.Move("", V0PROD_NOMPRODU, V0SEG_TP_SEGURADO);

            /*" -730- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -731- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -733- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -735- PERFORM R0200-00-DECLER-V0RELATORIOS. */

            R0200_00_DECLER_V0RELATORIOS_SECTION();

            /*" -736- PERFORM R0210-00-FETCH-V0RELATORIOS */

            R0210_00_FETCH_V0RELATORIOS_SECTION();

            /*" -737- IF WFIM-V0RELATORIOS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0RELATORIOS.IsEmpty())
            {

                /*" -738- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -740- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -742- PERFORM R0215-00-LER-V1PARAMRAMO. */

            R0215_00_LER_V1PARAMRAMO_SECTION();

            /*" -754- PERFORM R0220-00-PROCESSA-V0RELATORIOS UNTIL WFIM-V0RELATORIOS NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0RELATORIOS.IsEmpty()))
            {

                R0220_00_PROCESSA_V0RELATORIOS_SECTION();
            }

            /*" -759- DISPLAY 'VG0031B - TERMINO   NORMAL' */
            _.Display($"VG0031B - TERMINO   NORMAL");

            /*" -761- DISPLAY '          SEGURADOS A CENCELAR.... ' AC-I-V0SEGURAVG */
            _.Display($"          SEGURADOS A CENCELAR.... {AREA_DE_WORK.AC_I_V0SEGURAVG}");

            /*" -763- DISPLAY '          PARCELAS  CANCELADAS.... ' AC-UPDT-V1PARCELA */
            _.Display($"          PARCELAS  CANCELADAS.... {AREA_DE_WORK.AC_UPDT_V1PARCELA}");

            /*" -765- DISPLAY '          ENDOSSOS  CANCELADOS.... ' AC-UPDT-V1ENDOSSO. */
            _.Display($"          ENDOSSOS  CANCELADOS.... {AREA_DE_WORK.AC_UPDT_V1ENDOSSO}");

            /*" -766- DISPLAY '          EXTORNADOS A RETORNAR... ' AC-EXPURGADO. */
            _.Display($"          EXTORNADOS A RETORNAR... {AREA_DE_WORK.AC_EXPURGADO}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -772- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -774- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -778- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -780- IF AC-ERRO-DADOS GREATER ZEROS AND AC-ERRO-SISTEMA GREATER ZEROS */

            if (AREA_DE_WORK.AC_ERRO_DADOS > 00 && AREA_DE_WORK.AC_ERRO_SISTEMA > 00)
            {

                /*" -781- MOVE 3 TO RETURN-CODE */
                _.Move(3, RETURN_CODE);

                /*" -782- ELSE */
            }
            else
            {


                /*" -783- IF AC-ERRO-SISTEMA GREATER ZEROS */

                if (AREA_DE_WORK.AC_ERRO_SISTEMA > 00)
                {

                    /*" -784- MOVE 2 TO RETURN-CODE */
                    _.Move(2, RETURN_CODE);

                    /*" -785- ELSE */
                }
                else
                {


                    /*" -786- IF AC-ERRO-DADOS GREATER ZEROS */

                    if (AREA_DE_WORK.AC_ERRO_DADOS > 00)
                    {

                        /*" -788- MOVE 1 TO RETURN-CODE. */
                        _.Move(1, RETURN_CODE);
                    }

                }

            }


            /*" -791- CLOSE DSAIDA SSAIDA. */
            DSAIDA.Close();
            SSAIDA.Close();

            /*" -791- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -803- MOVE 'R0100-00' TO WNR-EXEC-SQL. */
            _.Move("R0100-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -808- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -811- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -812- PERFORM R0450-00-LIMPA-REGISTROS */

                R0450_00_LIMPA_REGISTROS_SECTION();

                /*" -814- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -816- MOVE 'ERRO NO ACESSO A TABELA DE SISTEMAS - CB' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A TABELA DE SISTEMAS - CB", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -817- WRITE RECORD-DSAIDA FROM HD-REG-DSAIDA */
                _.Move(AREA_DE_WORK.HD_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

                DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

                /*" -818- WRITE RECORD-DSAIDA FROM CB-REG-DSAIDA */
                _.Move(AREA_DE_WORK.CB_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

                DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

                /*" -819- WRITE RECORD-SSAIDA FROM HD-REG-SSAIDA */
                _.Move(AREA_DE_WORK.HD_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

                SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

                /*" -820- WRITE RECORD-SSAIDA FROM CB-REG-SSAIDA */
                _.Move(AREA_DE_WORK.CB_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

                SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

                /*" -821- PERFORM R0460-00-GRAVA-REGISTROS */

                R0460_00_GRAVA_REGISTROS_SECTION();

                /*" -822- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -823- DISPLAY 'VG0031B - SISTEMA DE COBRANCA NAO CADASTRADO' */
                    _.Display($"VG0031B - SISTEMA DE COBRANCA NAO CADASTRADO");

                    /*" -824- MOVE 'S' TO WFIM-V1SISTEMA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                    /*" -825- GO TO R0100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                    return;

                    /*" -826- ELSE */
                }
                else
                {


                    /*" -827- DISPLAY 'PROBLEMAS SELECT V1SISTEMA ... ' */
                    _.Display($"PROBLEMAS SELECT V1SISTEMA ... ");

                    /*" -829- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -831- MOVE V1SIST-DTMOVABE TO WSIST-DATA WDATA-REL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WSIST_DATA, AREA_DE_WORK.WDATA_REL);

            /*" -832- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(AREA_DE_WORK.FILLER_23.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -833- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(AREA_DE_WORK.FILLER_23.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -835- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(AREA_DE_WORK.FILLER_23.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -836- MOVE V1SIST-DTMOVABE(1:4) TO HD-DTA-SIS-DSAIDA(7:4). */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(1, 4), AREA_DE_WORK.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 7, 4);

            /*" -837- MOVE V1SIST-DTMOVABE(6:2) TO HD-DTA-SIS-DSAIDA(4:2). */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(6, 2), AREA_DE_WORK.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 4, 2);

            /*" -838- MOVE V1SIST-DTMOVABE(9:2) TO HD-DTA-SIS-DSAIDA(1:2). */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(9, 2), AREA_DE_WORK.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 1, 2);

            /*" -840- MOVE '/' TO HD-DTA-SIS-DSAIDA(6:1). */
            _.MoveAtPosition("/", AREA_DE_WORK.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 6, 1);

            /*" -840- MOVE '/' TO HD-DTA-SIS-DSAIDA(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 3, 1);

            /*" -842- MOVE HD-DTA-SIS-DSAIDA TO HD-DTA-SIS-SSAIDA. */
            _.Move(AREA_DE_WORK.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, AREA_DE_WORK.HD_REG_SSAIDA.HD_DTA_SIS_SSAIDA);

            /*" -843- WRITE RECORD-DSAIDA FROM HD-REG-DSAIDA. */
            _.Move(AREA_DE_WORK.HD_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

            DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

            /*" -844- WRITE RECORD-DSAIDA FROM CB-REG-DSAIDA. */
            _.Move(AREA_DE_WORK.CB_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

            DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

            /*" -845- WRITE RECORD-SSAIDA FROM HD-REG-SSAIDA. */
            _.Move(AREA_DE_WORK.HD_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

            SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

            /*" -845- WRITE RECORD-SSAIDA FROM CB-REG-SSAIDA. */
            _.Move(AREA_DE_WORK.CB_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

            SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -808- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CB' END-EXEC. */

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
            /*" -857- MOVE 'R0200-00' TO WNR-EXEC-SQL. */
            _.Move("R0200-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -872- PERFORM R0200_00_DECLER_V0RELATORIOS_DB_DECLARE_1 */

            R0200_00_DECLER_V0RELATORIOS_DB_DECLARE_1();

            /*" -874- PERFORM R0200_00_DECLER_V0RELATORIOS_DB_OPEN_1 */

            R0200_00_DECLER_V0RELATORIOS_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0200-00-DECLER-V0RELATORIOS-DB-DECLARE-1 */
        public void R0200_00_DECLER_V0RELATORIOS_DB_DECLARE_1()
        {
            /*" -872- EXEC SQL DECLARE V0RELATORIOS CURSOR FOR SELECT A.CODUSU, A.CODRELAT, A.NUM_APOLICE, A.CODSUBES, A.SITUACAO, B.RAMO FROM SEGUROS.V0RELATORIOS A, SEGUROS.V0APOLICE B WHERE A.CODRELAT IN ( 'VG0031B' , 'VG0031B1' ) AND A.IDSISTEM = 'VG' AND A.SITUACAO = '0' AND A.NUM_APOLICE = B.NUM_APOLICE ORDER BY A.CODRELAT, A.NUM_APOLICE, A.CODSUBES END-EXEC. */
            V0RELATORIOS = new VG0031B_V0RELATORIOS(false);
            string GetQuery_V0RELATORIOS()
            {
                var query = @$"SELECT A.CODUSU
							, 
							A.CODRELAT
							, 
							A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.SITUACAO
							, 
							B.RAMO 
							FROM SEGUROS.V0RELATORIOS A
							, 
							SEGUROS.V0APOLICE B 
							WHERE A.CODRELAT IN ( 'VG0031B'
							, 'VG0031B1' ) 
							AND A.IDSISTEM = 'VG' 
							AND A.SITUACAO = '0' 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							ORDER BY A.CODRELAT
							, A.NUM_APOLICE
							, A.CODSUBES";

                return query;
            }
            V0RELATORIOS.GetQueryEvent += GetQuery_V0RELATORIOS;

        }

        [StopWatch]
        /*" R0200-00-DECLER-V0RELATORIOS-DB-OPEN-1 */
        public void R0200_00_DECLER_V0RELATORIOS_DB_OPEN_1()
        {
            /*" -874- EXEC SQL OPEN V0RELATORIOS END-EXEC. */

            V0RELATORIOS.Open();

        }

        [StopWatch]
        /*" R0221-00-DECLER-V0SUBGRUPO-DB-DECLARE-1 */
        public void R0221_00_DECLER_V0SUBGRUPO_DB_DECLARE_1()
        {
            /*" -1102- EXEC SQL DECLARE V0SUBGRUPO CURSOR FOR SELECT NUM_APOLICE, COD_SUBGRUPO FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = :V1REL-NUM-APOL AND COD_SUBGRUPO >= :WHOST-CODSUBES-I AND COD_SUBGRUPO <= :WHOST-CODSUBES-F ORDER BY COD_SUBGRUPO END-EXEC. */
            V0SUBGRUPO = new VG0031B_V0SUBGRUPO(true);
            string GetQuery_V0SUBGRUPO()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_SUBGRUPO 
							FROM SEGUROS.V0SUBGRUPO 
							WHERE NUM_APOLICE = '{V1REL_NUM_APOL}' 
							AND COD_SUBGRUPO >= '{WHOST_CODSUBES_I}' 
							AND COD_SUBGRUPO <= '{WHOST_CODSUBES_F}' 
							ORDER BY COD_SUBGRUPO";

                return query;
            }
            V0SUBGRUPO.GetQueryEvent += GetQuery_V0SUBGRUPO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0RELATORIOS-SECTION */
        private void R0210_00_FETCH_V0RELATORIOS_SECTION()
        {
            /*" -886- MOVE 'R0210-00' TO WNR-EXEC-SQL. */
            _.Move("R0210-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -893- PERFORM R0210_00_FETCH_V0RELATORIOS_DB_FETCH_1 */

            R0210_00_FETCH_V0RELATORIOS_DB_FETCH_1();

            /*" -896- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -897- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -898- MOVE 'S' TO WFIM-V0RELATORIOS */
                    _.Move("S", AREA_DE_WORK.WFIM_V0RELATORIOS);

                    /*" -898- PERFORM R0210_00_FETCH_V0RELATORIOS_DB_CLOSE_1 */

                    R0210_00_FETCH_V0RELATORIOS_DB_CLOSE_1();

                    /*" -900- ELSE */
                }
                else
                {


                    /*" -901- DISPLAY 'R0210 - PROBLEMAS FETCH V0RELATORIOS... ' */
                    _.Display($"R0210 - PROBLEMAS FETCH V0RELATORIOS... ");

                    /*" -902- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -904- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -906- MOVE 'ERRO NO FETCH DO CURSOR DE RELATORIOS' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO FETCH DO CURSOR DE RELATORIOS", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -907- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -908- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -909- ELSE */
                }

            }
            else
            {


                /*" -909- ADD 1 TO AC-L-V0RELATORIOS. */
                AREA_DE_WORK.AC_L_V0RELATORIOS.Value = AREA_DE_WORK.AC_L_V0RELATORIOS + 1;
            }


        }

        [StopWatch]
        /*" R0210-00-FETCH-V0RELATORIOS-DB-FETCH-1 */
        public void R0210_00_FETCH_V0RELATORIOS_DB_FETCH_1()
        {
            /*" -893- EXEC SQL FETCH V0RELATORIOS INTO :V1REL-COD-USUR, :V1REL-CODRELAT, :V1REL-NUM-APOL, :V1REL-COD-SUBG, :V1REL-SIT-REGISTRO, :V1REL-APOL-RAMO END-EXEC. */

            if (V0RELATORIOS.Fetch())
            {
                _.Move(V0RELATORIOS.V1REL_COD_USUR, V1REL_COD_USUR);
                _.Move(V0RELATORIOS.V1REL_CODRELAT, V1REL_CODRELAT);
                _.Move(V0RELATORIOS.V1REL_NUM_APOL, V1REL_NUM_APOL);
                _.Move(V0RELATORIOS.V1REL_COD_SUBG, V1REL_COD_SUBG);
                _.Move(V0RELATORIOS.V1REL_SIT_REGISTRO, V1REL_SIT_REGISTRO);
                _.Move(V0RELATORIOS.V1REL_APOL_RAMO, V1REL_APOL_RAMO);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0RELATORIOS-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0RELATORIOS_DB_CLOSE_1()
        {
            /*" -898- EXEC SQL CLOSE V0RELATORIOS END-EXEC */

            V0RELATORIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0215-00-LER-V1PARAMRAMO-SECTION */
        private void R0215_00_LER_V1PARAMRAMO_SECTION()
        {
            /*" -921- MOVE 'R0215-00' TO WNR-EXEC-SQL. */
            _.Move("R0215-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -926- PERFORM R0215_00_LER_V1PARAMRAMO_DB_SELECT_1 */

            R0215_00_LER_V1PARAMRAMO_DB_SELECT_1();

            /*" -929- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -930- DISPLAY ' ' */
                _.Display($" ");

                /*" -931- DISPLAY 'R0215-00 - ERRO NO ACESSO A V1PARAMRAMO' */
                _.Display($"R0215-00 - ERRO NO ACESSO A V1PARAMRAMO");

                /*" -932- PERFORM R0450-00-LIMPA-REGISTROS */

                R0450_00_LIMPA_REGISTROS_SECTION();

                /*" -934- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -936- MOVE 'PROBLEMAS NO ACESSO A VIEW V1PARAMRAMO' TO LD-DES-ERRO-SSAIDA */
                _.Move("PROBLEMAS NO ACESSO A VIEW V1PARAMRAMO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -937- PERFORM R0460-00-GRAVA-REGISTROS */

                R0460_00_GRAVA_REGISTROS_SECTION();

                /*" -937- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0215-00-LER-V1PARAMRAMO-DB-SELECT-1 */
        public void R0215_00_LER_V1PARAMRAMO_DB_SELECT_1()
        {
            /*" -926- EXEC SQL SELECT RAMO_VG, RAMO_AP, NUM_RAMO_PRSTMISTA INTO :V1PAR-RAMO-VG, :V1PAR-RAMO-AP, :V1PAR-RAMO-PST FROM SEGUROS.V1PARAMRAMO END-EXEC. */

            var r0215_00_LER_V1PARAMRAMO_DB_SELECT_1_Query1 = new R0215_00_LER_V1PARAMRAMO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0215_00_LER_V1PARAMRAMO_DB_SELECT_1_Query1.Execute(r0215_00_LER_V1PARAMRAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PAR_RAMO_VG, V1PAR_RAMO_VG);
                _.Move(executed_1.V1PAR_RAMO_AP, V1PAR_RAMO_AP);
                _.Move(executed_1.V1PAR_RAMO_PST, V1PAR_RAMO_PST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0215_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-PROCESSA-V0RELATORIOS-SECTION */
        private void R0220_00_PROCESSA_V0RELATORIOS_SECTION()
        {
            /*" -956- MOVE 'R0220-00' TO WNR-EXEC-SQL. */
            _.Move("R0220-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -957- IF V1REL-CODRELAT = 'VG0031B' */

            if (V1REL_CODRELAT == "VG0031B")
            {

                /*" -958- MOVE 0 TO WHOST-CODSUBES-I */
                _.Move(0, WHOST_CODSUBES_I);

                /*" -959- MOVE 9999 TO WHOST-CODSUBES-F */
                _.Move(9999, WHOST_CODSUBES_F);

                /*" -969- MOVE 410 TO V0PROP-CODOPER */
                _.Move(410, V0PROP_CODOPER);

                /*" -970- ELSE */
            }
            else
            {


                /*" -971- MOVE 409 TO V0PROP-CODOPER */
                _.Move(409, V0PROP_CODOPER);

                /*" -972- MOVE V1REL-COD-SUBG TO WHOST-CODSUBES-I */
                _.Move(V1REL_COD_SUBG, WHOST_CODSUBES_I);

                /*" -974- MOVE V1REL-COD-SUBG TO WHOST-CODSUBES-F. */
                _.Move(V1REL_COD_SUBG, WHOST_CODSUBES_F);
            }


            /*" -976- MOVE 1 TO WS-RELATORIO. */
            _.Move(1, AREA_DE_WORK.WS_RELATORIO);

            /*" -978- MOVE SPACES TO WFIM-V0SUBGRUPO. */
            _.Move("", AREA_DE_WORK.WFIM_V0SUBGRUPO);

            /*" -980- PERFORM R0221-00-DECLER-V0SUBGRUPO. */

            R0221_00_DECLER_V0SUBGRUPO_SECTION();

            /*" -982- PERFORM R0222-00-FETCH-V0SUBGRUPO. */

            R0222_00_FETCH_V0SUBGRUPO_SECTION();

            /*" -985- PERFORM R0223-00-PROCESSA-V0SUBGRUPO UNTIL WFIM-V0SUBGRUPO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0SUBGRUPO.IsEmpty()))
            {

                R0223_00_PROCESSA_V0SUBGRUPO_SECTION();
            }

            /*" -986- IF ATUALIZA-RELATORIO */

            if (AREA_DE_WORK.WS_RELATORIO["ATUALIZA_RELATORIO"])
            {

                /*" -986- PERFORM R0410-00-UPDATE-V0RELATORIO. */

                R0410_00_UPDATE_V0RELATORIO_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0220_88_FETCH */

            R0220_88_FETCH();

        }

        [StopWatch]
        /*" R0220-88-FETCH */
        private void R0220_88_FETCH(bool isPerform = false)
        {
            /*" -990- PERFORM R0210-00-FETCH-V0RELATORIOS. */

            R0210_00_FETCH_V0RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0220-10-UPDATE-ENDOSSO-ZERO-SECTION */
        private void R0220_10_UPDATE_ENDOSSO_ZERO_SECTION()
        {
            /*" -1002- MOVE 'R0220-10' TO WNR-EXEC-SQL. */
            _.Move("R0220-10", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1009- PERFORM R0220_10_UPDATE_ENDOSSO_ZERO_DB_UPDATE_1 */

            R0220_10_UPDATE_ENDOSSO_ZERO_DB_UPDATE_1();

            /*" -1013- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1014- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1015- DISPLAY 'R0220-10 (V0APOLICE CANCELADA ANTERIORMENTE' */
                    _.Display($"R0220-10 (V0APOLICE CANCELADA ANTERIORMENTE");

                    /*" -1016- DISPLAY 'APOLICE.......   ' V1REL-NUM-APOL */
                    _.Display($"APOLICE.......   {V1REL_NUM_APOL}");

                    /*" -1017- DISPLAY 'ENDOSSO.......     00' */
                    _.Display($"ENDOSSO.......     00");

                    /*" -1018- DISPLAY 'SQLCODE.......   ' SQLCODE */
                    _.Display($"SQLCODE.......   {DB.SQLCODE}");

                    /*" -1019- ELSE */
                }
                else
                {


                    /*" -1020- DISPLAY 'R0220-10 (PROBLEMAS UPDATE V0ENDOSSO) ... ' */
                    _.Display($"R0220-10 (PROBLEMAS UPDATE V0ENDOSSO) ... ");

                    /*" -1021- DISPLAY 'APOLICE.......   ' V1REL-NUM-APOL */
                    _.Display($"APOLICE.......   {V1REL_NUM_APOL}");

                    /*" -1022- DISPLAY 'ENDOSSO.......     00' */
                    _.Display($"ENDOSSO.......     00");

                    /*" -1023- DISPLAY 'SQLCODE.......   ' SQLCODE */
                    _.Display($"SQLCODE.......   {DB.SQLCODE}");

                    /*" -1024- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1025- ELSE */
                }

            }
            else
            {


                /*" -1025- ADD 1 TO AC-UPDT-V1APOLICE. */
                AREA_DE_WORK.AC_UPDT_V1APOLICE.Value = AREA_DE_WORK.AC_UPDT_V1APOLICE + 1;
            }


        }

        [StopWatch]
        /*" R0220-10-UPDATE-ENDOSSO-ZERO-DB-UPDATE-1 */
        public void R0220_10_UPDATE_ENDOSSO_ZERO_DB_UPDATE_1()
        {
            /*" -1009- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET SITUACAO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V1REL-NUM-APOL AND NRENDOS = 0 AND SITUACAO NOT IN ( '2' ) END-EXEC. */

            var r0220_10_UPDATE_ENDOSSO_ZERO_DB_UPDATE_1_Update1 = new R0220_10_UPDATE_ENDOSSO_ZERO_DB_UPDATE_1_Update1()
            {
                V1REL_NUM_APOL = V1REL_NUM_APOL.ToString(),
            };

            R0220_10_UPDATE_ENDOSSO_ZERO_DB_UPDATE_1_Update1.Execute(r0220_10_UPDATE_ENDOSSO_ZERO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_10_SAIDA*/

        [StopWatch]
        /*" R0220-20-UPDATE-SUBGRUPO-ZERO-SECTION */
        private void R0220_20_UPDATE_SUBGRUPO_ZERO_SECTION()
        {
            /*" -1037- MOVE 'R0220-20' TO WNR-EXEC-SQL. */
            _.Move("R0220-20", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1043- PERFORM R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_1 */

            R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_1();

            /*" -1046- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1047- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1048- DISPLAY 'R0220-20 (V0SUBGRUPO CANCELADO ANTERIORMENTE' */
                    _.Display($"R0220-20 (V0SUBGRUPO CANCELADO ANTERIORMENTE");

                    /*" -1049- DISPLAY 'APOLICE.......   ' V1REL-NUM-APOL */
                    _.Display($"APOLICE.......   {V1REL_NUM_APOL}");

                    /*" -1050- DISPLAY 'SUBGRUPO......     00' */
                    _.Display($"SUBGRUPO......     00");

                    /*" -1051- DISPLAY 'SQLCODE.......   ' SQLCODE */
                    _.Display($"SQLCODE.......   {DB.SQLCODE}");

                    /*" -1052- ELSE */
                }
                else
                {


                    /*" -1053- DISPLAY 'R0220-20 (PROBLEMAS UPDATE V0SUBGRUPO) ... ' */
                    _.Display($"R0220-20 (PROBLEMAS UPDATE V0SUBGRUPO) ... ");

                    /*" -1054- DISPLAY 'APOLICE.......   ' V1REL-NUM-APOL */
                    _.Display($"APOLICE.......   {V1REL_NUM_APOL}");

                    /*" -1055- DISPLAY 'SUBGRUPO......     00' */
                    _.Display($"SUBGRUPO......     00");

                    /*" -1056- DISPLAY 'SQLCODE.......   ' SQLCODE */
                    _.Display($"SQLCODE.......   {DB.SQLCODE}");

                    /*" -1058- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1060- MOVE 'R0220-21' TO WNR-EXEC-SQL. */
            _.Move("R0220-21", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1070- PERFORM R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_2 */

            R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_2();

            /*" -1073- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1075- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1076- ELSE */
                }
                else
                {


                    /*" -1077- DISPLAY 'R0220-20 (PROBLEMAS UPDATE V0PROPOSTAVA) . ' */
                    _.Display($"R0220-20 (PROBLEMAS UPDATE V0PROPOSTAVA) . ");

                    /*" -1078- DISPLAY 'APOLICE.......   ' V1REL-NUM-APOL */
                    _.Display($"APOLICE.......   {V1REL_NUM_APOL}");

                    /*" -1079- DISPLAY 'SUBGRUPO......     00' */
                    _.Display($"SUBGRUPO......     00");

                    /*" -1080- DISPLAY 'SQLCODE.......   ' SQLCODE */
                    _.Display($"SQLCODE.......   {DB.SQLCODE}");

                    /*" -1080- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0220-20-UPDATE-SUBGRUPO-ZERO-DB-UPDATE-1 */
        public void R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_1()
        {
            /*" -1043- EXEC SQL UPDATE SEGUROS.V0SUBGRUPO SET SIT_REGISTRO = '2' WHERE NUM_APOLICE = :V1REL-NUM-APOL AND COD_SUBGRUPO = 0 AND SIT_REGISTRO NOT IN ( '2' ) END-EXEC. */

            var r0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_1_Update1 = new R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_1_Update1()
            {
                V1REL_NUM_APOL = V1REL_NUM_APOL.ToString(),
            };

            R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_1_Update1.Execute(r0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_20_SAIDA*/

        [StopWatch]
        /*" R0220-20-UPDATE-SUBGRUPO-ZERO-DB-UPDATE-2 */
        public void R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_2()
        {
            /*" -1070- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '4' , CODUSU = 'VG0031B' , CODOPER = :V0PROP-CODOPER, DTMOVTO = :V1SIST-DTMOVABE, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V1REL-NUM-APOL AND CODSUBES = 0 AND SITUACAO IN ( '3' , '6' ) END-EXEC. */

            var r0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_2_Update1 = new R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_2_Update1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0PROP_CODOPER = V0PROP_CODOPER.ToString(),
                V1REL_NUM_APOL = V1REL_NUM_APOL.ToString(),
            };

            R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_2_Update1.Execute(r0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R0221-00-DECLER-V0SUBGRUPO-SECTION */
        private void R0221_00_DECLER_V0SUBGRUPO_SECTION()
        {
            /*" -1093- MOVE 'R0221-00' TO WNR-EXEC-SQL. */
            _.Move("R0221-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1102- PERFORM R0221_00_DECLER_V0SUBGRUPO_DB_DECLARE_1 */

            R0221_00_DECLER_V0SUBGRUPO_DB_DECLARE_1();

            /*" -1104- PERFORM R0221_00_DECLER_V0SUBGRUPO_DB_OPEN_1 */

            R0221_00_DECLER_V0SUBGRUPO_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0221-00-DECLER-V0SUBGRUPO-DB-OPEN-1 */
        public void R0221_00_DECLER_V0SUBGRUPO_DB_OPEN_1()
        {
            /*" -1104- EXEC SQL OPEN V0SUBGRUPO END-EXEC. */

            V0SUBGRUPO.Open();

        }

        [StopWatch]
        /*" R0224-10-DECLER-V0SEGURAVG-DB-DECLARE-1 */
        public void R0224_10_DECLER_V0SEGURAVG_DB_DECLARE_1()
        {
            /*" -1347- EXEC SQL DECLARE V0SEGURAVG CURSOR FOR SELECT NUM_APOLICE, COD_SUBGRUPO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_SEGURADO, NUM_ITEM, TIPO_INCLUSAO, COD_CLIENTE, COD_FONTE, NUM_PROPOSTA, COD_AGENCIADOR, COD_CORRETOR, COD_PLANOVGAP, COD_PLANOAP, FAIXA, AUTOR_AUM_AUTOMAT, TIPO_BENEFICIARIO, OCORR_HISTORICO, PERI_PAGAMENTO, PERI_RENOVACAO, NUM_CARNE, COD_OCUPACAO, ESTADO_CIVIL, IDE_SEXO, COD_PROFISSAO, NATURALIDADE, OCORR_ENDERECO, OCORR_END_COBRAN, BCO_COBRANCA, AGE_COBRANCA, DAC_COBRANCA, NUM_MATRICULA, VAL_SALARIO, TIPO_SALARIO, TIPO_PLANO, DATA_INIVIGENCIA, PCT_CONJUGE_VG, PCT_CONJUGE_AP, QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_AP, TAXA_VG, SIT_REGISTRO, DATA_ADMISSAO, DATA_NASCIMENTO, LOT_EMP_SEGURADO FROM SEGUROS.V0SEGURAVG WHERE NUM_APOLICE = :V0SUBG-NUM-APOL AND COD_SUBGRUPO = :V0SUBG-COD-SUBG AND SIT_REGISTRO NOT IN ( '2' ) ORDER BY NUM_CERTIFICADO, TIPO_SEGURADO END-EXEC. */
            V0SEGURAVG = new VG0031B_V0SEGURAVG(true);
            string GetQuery_V0SEGURAVG()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							NUM_CERTIFICADO
							, 
							DAC_CERTIFICADO
							, 
							TIPO_SEGURADO
							, 
							NUM_ITEM
							, 
							TIPO_INCLUSAO
							, 
							COD_CLIENTE
							, 
							COD_FONTE
							, 
							NUM_PROPOSTA
							, 
							COD_AGENCIADOR
							, 
							COD_CORRETOR
							, 
							COD_PLANOVGAP
							, 
							COD_PLANOAP
							, 
							FAIXA
							, 
							AUTOR_AUM_AUTOMAT
							, 
							TIPO_BENEFICIARIO
							, 
							OCORR_HISTORICO
							, 
							PERI_PAGAMENTO
							, 
							PERI_RENOVACAO
							, 
							NUM_CARNE
							, 
							COD_OCUPACAO
							, 
							ESTADO_CIVIL
							, 
							IDE_SEXO
							, 
							COD_PROFISSAO
							, 
							NATURALIDADE
							, 
							OCORR_ENDERECO
							, 
							OCORR_END_COBRAN
							, 
							BCO_COBRANCA
							, 
							AGE_COBRANCA
							, 
							DAC_COBRANCA
							, 
							NUM_MATRICULA
							, 
							VAL_SALARIO
							, 
							TIPO_SALARIO
							, 
							TIPO_PLANO
							, 
							DATA_INIVIGENCIA
							, 
							PCT_CONJUGE_VG
							, 
							PCT_CONJUGE_AP
							, 
							QTD_SAL_MORNATU
							, 
							QTD_SAL_MORACID
							, 
							QTD_SAL_INVPERM
							, 
							TAXA_AP_MORACID
							, 
							TAXA_AP_INVPERM
							, 
							TAXA_AP_AMDS
							, 
							TAXA_AP_DH
							, 
							TAXA_AP_DIT
							, 
							TAXA_AP
							, 
							TAXA_VG
							, 
							SIT_REGISTRO
							, 
							DATA_ADMISSAO
							, 
							DATA_NASCIMENTO
							, 
							LOT_EMP_SEGURADO 
							FROM SEGUROS.V0SEGURAVG 
							WHERE NUM_APOLICE = '{V0SUBG_NUM_APOL}' 
							AND COD_SUBGRUPO = '{V0SUBG_COD_SUBG}' 
							AND SIT_REGISTRO NOT IN ( '2' ) 
							ORDER BY NUM_CERTIFICADO
							, TIPO_SEGURADO";

                return query;
            }
            V0SEGURAVG.GetQueryEvent += GetQuery_V0SEGURAVG;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0221_99_SAIDA*/

        [StopWatch]
        /*" R0222-00-FETCH-V0SUBGRUPO-SECTION */
        private void R0222_00_FETCH_V0SUBGRUPO_SECTION()
        {
            /*" -1116- MOVE 'R0222-00' TO WNR-EXEC-SQL. */
            _.Move("R0222-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1119- PERFORM R0222_00_FETCH_V0SUBGRUPO_DB_FETCH_1 */

            R0222_00_FETCH_V0SUBGRUPO_DB_FETCH_1();

            /*" -1122- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1123- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1124- MOVE 'S' TO WFIM-V0SUBGRUPO */
                    _.Move("S", AREA_DE_WORK.WFIM_V0SUBGRUPO);

                    /*" -1124- PERFORM R0222_00_FETCH_V0SUBGRUPO_DB_CLOSE_1 */

                    R0222_00_FETCH_V0SUBGRUPO_DB_CLOSE_1();

                    /*" -1126- ELSE */
                }
                else
                {


                    /*" -1127- DISPLAY 'R0222 - PROBLEMAS FETCH V0SUBGRUPO..... ' */
                    _.Display($"R0222 - PROBLEMAS FETCH V0SUBGRUPO..... ");

                    /*" -1128- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -1130- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1132- MOVE 'ERRO NO FETCH DO CURSOR DE SUBGRUPOS' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO FETCH DO CURSOR DE SUBGRUPOS", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1133- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -1134- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1135- ELSE */
                }

            }
            else
            {


                /*" -1135- ADD 1 TO AC-L-V0SUBGRUPO. */
                AREA_DE_WORK.AC_L_V0SUBGRUPO.Value = AREA_DE_WORK.AC_L_V0SUBGRUPO + 1;
            }


        }

        [StopWatch]
        /*" R0222-00-FETCH-V0SUBGRUPO-DB-FETCH-1 */
        public void R0222_00_FETCH_V0SUBGRUPO_DB_FETCH_1()
        {
            /*" -1119- EXEC SQL FETCH V0SUBGRUPO INTO :V0SUBG-NUM-APOL, :V0SUBG-COD-SUBG END-EXEC. */

            if (V0SUBGRUPO.Fetch())
            {
                _.Move(V0SUBGRUPO.V0SUBG_NUM_APOL, V0SUBG_NUM_APOL);
                _.Move(V0SUBGRUPO.V0SUBG_COD_SUBG, V0SUBG_COD_SUBG);
            }

        }

        [StopWatch]
        /*" R0222-00-FETCH-V0SUBGRUPO-DB-CLOSE-1 */
        public void R0222_00_FETCH_V0SUBGRUPO_DB_CLOSE_1()
        {
            /*" -1124- EXEC SQL CLOSE V0SUBGRUPO END-EXEC */

            V0SUBGRUPO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0222_99_SAIDA*/

        [StopWatch]
        /*" R0223-00-PROCESSA-V0SUBGRUPO-SECTION */
        private void R0223_00_PROCESSA_V0SUBGRUPO_SECTION()
        {
            /*" -1148- MOVE 'R0223-00' TO WNR-EXEC-SQL. */
            _.Move("R0223-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1156- PERFORM R0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1 */

            R0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1();

            /*" -1159- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1160- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1161- MOVE ZEROS TO V0PROD-CODPRODU */
                    _.Move(0, V0PROD_CODPRODU);

                    /*" -1162- MOVE SPACES TO V0PROD-NOMPRODU */
                    _.Move("", V0PROD_NOMPRODU);

                    /*" -1163- ELSE */
                }
                else
                {


                    /*" -1164- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -1166- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1168- MOVE 'PROBLEMAS NO ACESSO A TABELA PRODUTOSVG' TO LD-DES-ERRO-SSAIDA */
                    _.Move("PROBLEMAS NO ACESSO A TABELA PRODUTOSVG", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1169- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -1171- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1176- MOVE ZEROS TO WS-EXPURGO-SUBGRUPO. */
            _.Move(0, AREA_DE_WORK.WS_EXPURGO_SUBGRUPO);

            /*" -1178- PERFORM R0224-00-OBTER-DT-REFERENCIA. */

            R0224_00_OBTER_DT_REFERENCIA_SECTION();

            /*" -1183- PERFORM R0224-05-PROCESSA-SEGURADOS. */

            R0224_05_PROCESSA_SEGURADOS_SECTION();

            /*" -1185- IF HOUVE-EXPURGO-SUBGRUPO NEXT SENTENCE */

            if (AREA_DE_WORK.WS_EXPURGO_SUBGRUPO["HOUVE_EXPURGO_SUBGRUPO"])
            {

                /*" -1186- ELSE */
            }
            else
            {


                /*" -1190- PERFORM R0230-00-CANCELA-PENDENTE */

                R0230_00_CANCELA_PENDENTE_SECTION();

                /*" -1190- PERFORM R0260-00-CANCELA-V0SUBGRUPO. */

                R0260_00_CANCELA_V0SUBGRUPO_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0223_88_FETCH */

            R0223_88_FETCH();

        }

        [StopWatch]
        /*" R0223-00-PROCESSA-V0SUBGRUPO-DB-SELECT-1 */
        public void R0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1()
        {
            /*" -1156- EXEC SQL SELECT CODPRODU, NOMPRODU INTO :V0PROD-CODPRODU, :V0PROD-NOMPRODU FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :V0SUBG-NUM-APOL AND CODSUBES = :V0SUBG-COD-SUBG END-EXEC. */

            var r0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1_Query1 = new R0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1_Query1()
            {
                V0SUBG_NUM_APOL = V0SUBG_NUM_APOL.ToString(),
                V0SUBG_COD_SUBG = V0SUBG_COD_SUBG.ToString(),
            };

            var executed_1 = R0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1_Query1.Execute(r0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROD_CODPRODU, V0PROD_CODPRODU);
                _.Move(executed_1.V0PROD_NOMPRODU, V0PROD_NOMPRODU);
            }


        }

        [StopWatch]
        /*" R0223-88-FETCH */
        private void R0223_88_FETCH(bool isPerform = false)
        {
            /*" -1193- PERFORM R0222-00-FETCH-V0SUBGRUPO. */

            R0222_00_FETCH_V0SUBGRUPO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0223_99_SAIDA*/

        [StopWatch]
        /*" R0224-00-OBTER-DT-REFERENCIA-SECTION */
        private void R0224_00_OBTER_DT_REFERENCIA_SECTION()
        {
            /*" -1205- MOVE 'R224-00' TO WNR-EXEC-SQL. */
            _.Move("R224-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1207- IF V0SUBG-NUM-APOL = 109300000377 AND V0SUBG-COD-SUBG = 0 */

            if (V0SUBG_NUM_APOL == 109300000377 && V0SUBG_COD_SUBG == 0)
            {

                /*" -1208- MOVE '2002-04-01' TO V1FATC-DT-REFER */
                _.Move("2002-04-01", V1FATC_DT_REFER);

                /*" -1210- GO TO R0224-00-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0224_00_EXIT*/ //GOTO
                return;
            }


            /*" -1216- PERFORM R0224_00_OBTER_DT_REFERENCIA_DB_SELECT_1 */

            R0224_00_OBTER_DT_REFERENCIA_DB_SELECT_1();

            /*" -1219- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1220- DISPLAY ' ' */
                _.Display($" ");

                /*" -1221- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1227- PERFORM R0224_00_OBTER_DT_REFERENCIA_DB_SELECT_2 */

                    R0224_00_OBTER_DT_REFERENCIA_DB_SELECT_2();

                    /*" -1229- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1234- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -1235- MOVE V1SIST-DTMOVABE TO WDAT-REF-AUX */
                            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDAT_REF_AUX);

                            /*" -1236- MOVE 01 TO WDAT-REF-DIA */
                            _.Move(01, AREA_DE_WORK.FILLER_26.WDAT_REF_DIA);

                            /*" -1237- MOVE WDAT-REF-AUX TO V1FATC-DT-REFER */
                            _.Move(AREA_DE_WORK.WDAT_REF_AUX, V1FATC_DT_REFER);

                            /*" -1238- GO TO R0224-00-EXIT */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0224_00_EXIT*/ //GOTO
                            return;

                            /*" -1239- ELSE */
                        }
                        else
                        {


                            /*" -1240- DISPLAY 'R0224-00 - ERRO NO ACESSO A V0FATURCONT' */
                            _.Display($"R0224-00 - ERRO NO ACESSO A V0FATURCONT");

                            /*" -1241- DISPLAY 'APOLICE......  ' V0SUBG-NUM-APOL */
                            _.Display($"APOLICE......  {V0SUBG_NUM_APOL}");

                            /*" -1242- DISPLAY 'SQLCODE......  ' SQLCODE */
                            _.Display($"SQLCODE......  {DB.SQLCODE}");

                            /*" -1243- PERFORM R0450-00-LIMPA-REGISTROS */

                            R0450_00_LIMPA_REGISTROS_SECTION();

                            /*" -1245- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                            _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                            /*" -1247- MOVE 'ERRO NO ACESSO A VIEW V0FATURCONT' TO LD-DES-ERRO-SSAIDA */
                            _.Move("ERRO NO ACESSO A VIEW V0FATURCONT", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                            /*" -1248- PERFORM R0460-00-GRAVA-REGISTROS */

                            R0460_00_GRAVA_REGISTROS_SECTION();

                            /*" -1249- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1251- ELSE NEXT SENTENCE */
                        }

                    }
                    else
                    {


                        /*" -1252- ELSE */
                    }

                }
                else
                {


                    /*" -1253- DISPLAY 'R0224-00 - PROBLEMAS ACESSO V0FATURCONT' */
                    _.Display($"R0224-00 - PROBLEMAS ACESSO V0FATURCONT");

                    /*" -1254- DISPLAY 'APOLICE......  ' V1REL-NUM-APOL */
                    _.Display($"APOLICE......  {V1REL_NUM_APOL}");

                    /*" -1255- DISPLAY 'SUBGRUPO.....  ' V1REL-COD-SUBG */
                    _.Display($"SUBGRUPO.....  {V1REL_COD_SUBG}");

                    /*" -1256- DISPLAY 'SQLCODE......  ' SQLCODE */
                    _.Display($"SQLCODE......  {DB.SQLCODE}");

                    /*" -1257- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -1259- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1261- MOVE 'ERRO NO ACESSO A VIEW V0FATURCONT' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO ACESSO A VIEW V0FATURCONT", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1262- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -1262- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0224-00-OBTER-DT-REFERENCIA-DB-SELECT-1 */
        public void R0224_00_OBTER_DT_REFERENCIA_DB_SELECT_1()
        {
            /*" -1216- EXEC SQL SELECT DATA_REFERENCIA INTO :V1FATC-DT-REFER FROM SEGUROS.V1FATURCONT WHERE NUM_APOLICE = :V0SUBG-NUM-APOL AND COD_SUBGRUPO = :V0SUBG-COD-SUBG END-EXEC. */

            var r0224_00_OBTER_DT_REFERENCIA_DB_SELECT_1_Query1 = new R0224_00_OBTER_DT_REFERENCIA_DB_SELECT_1_Query1()
            {
                V0SUBG_NUM_APOL = V0SUBG_NUM_APOL.ToString(),
                V0SUBG_COD_SUBG = V0SUBG_COD_SUBG.ToString(),
            };

            var executed_1 = R0224_00_OBTER_DT_REFERENCIA_DB_SELECT_1_Query1.Execute(r0224_00_OBTER_DT_REFERENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FATC_DT_REFER, V1FATC_DT_REFER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0224_00_EXIT*/

        [StopWatch]
        /*" R0224-00-OBTER-DT-REFERENCIA-DB-SELECT-2 */
        public void R0224_00_OBTER_DT_REFERENCIA_DB_SELECT_2()
        {
            /*" -1227- EXEC SQL SELECT DATA_REFERENCIA INTO :V1FATC-DT-REFER FROM SEGUROS.V1FATURCONT WHERE NUM_APOLICE = :V0SUBG-NUM-APOL AND COD_SUBGRUPO = 0 END-EXEC */

            var r0224_00_OBTER_DT_REFERENCIA_DB_SELECT_2_Query1 = new R0224_00_OBTER_DT_REFERENCIA_DB_SELECT_2_Query1()
            {
                V0SUBG_NUM_APOL = V0SUBG_NUM_APOL.ToString(),
            };

            var executed_1 = R0224_00_OBTER_DT_REFERENCIA_DB_SELECT_2_Query1.Execute(r0224_00_OBTER_DT_REFERENCIA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FATC_DT_REFER, V1FATC_DT_REFER);
            }


        }

        [StopWatch]
        /*" R0224-05-PROCESSA-SEGURADOS-SECTION */
        private void R0224_05_PROCESSA_SEGURADOS_SECTION()
        {
            /*" -1271- MOVE 'R0224-05' TO WNR-EXEC-SQL. */
            _.Move("R0224-05", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1273- MOVE SPACES TO WFIM-V0SEGURAVG. */
            _.Move("", AREA_DE_WORK.WFIM_V0SEGURAVG);

            /*" -1275- PERFORM R0224-10-DECLER-V0SEGURAVG. */

            R0224_10_DECLER_V0SEGURAVG_SECTION();

            /*" -1277- PERFORM R0224-15-FETCH-V0SEGURAVG. */

            R0224_15_FETCH_V0SEGURAVG_SECTION();

            /*" -1278- PERFORM R0224-20-PROCESSA-V0SEGURAVG UNTIL WFIM-V0SEGURAVG NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0SEGURAVG.IsEmpty()))
            {

                R0224_20_PROCESSA_V0SEGURAVG_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0224_05_EXIT*/

        [StopWatch]
        /*" R0224-10-DECLER-V0SEGURAVG-SECTION */
        private void R0224_10_DECLER_V0SEGURAVG_SECTION()
        {
            /*" -1287- MOVE 'R0224-10' TO WNR-EXEC-SQL. */
            _.Move("R0224-10", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1347- PERFORM R0224_10_DECLER_V0SEGURAVG_DB_DECLARE_1 */

            R0224_10_DECLER_V0SEGURAVG_DB_DECLARE_1();

            /*" -1349- PERFORM R0224_10_DECLER_V0SEGURAVG_DB_OPEN_1 */

            R0224_10_DECLER_V0SEGURAVG_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0224-10-DECLER-V0SEGURAVG-DB-OPEN-1 */
        public void R0224_10_DECLER_V0SEGURAVG_DB_OPEN_1()
        {
            /*" -1349- EXEC SQL OPEN V0SEGURAVG END-EXEC. */

            V0SEGURAVG.Open();

        }

        [StopWatch]
        /*" R0230-05-DECLER-V1ENDOSSO-DB-DECLARE-1 */
        public void R0230_05_DECLER_V1ENDOSSO_DB_DECLARE_1()
        {
            /*" -2377- EXEC SQL DECLARE V1ENDOSSO CURSOR FOR SELECT NUM_APOLICE , NRENDOS , DTEMIS , DTINIVIG , DTTERVIG , BCORCAP , AGERCAP , DACRCAP , BCOCOBR , AGECOBR , DACCOBR , QTPARCEL , ORGAO , RAMO , CODPRODU FROM SEGUROS.V1ENDOSSO WHERE NUM_APOLICE = :V0SUBG-NUM-APOL AND CODSUBES = :V0SUBG-COD-SUBG AND NRENDOS �= 0 AND SITUACAO = '0' ORDER BY NRENDOS END-EXEC. */
            V1ENDOSSO = new VG0031B_V1ENDOSSO(true);
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
							WHERE NUM_APOLICE = '{V0SUBG_NUM_APOL}' 
							AND CODSUBES = '{V0SUBG_COD_SUBG}' 
							AND NRENDOS �= 0 
							AND SITUACAO = '0' 
							ORDER BY NRENDOS";

                return query;
            }
            V1ENDOSSO.GetQueryEvent += GetQuery_V1ENDOSSO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0224_10_SAIDA*/

        [StopWatch]
        /*" R0224-15-FETCH-V0SEGURAVG-SECTION */
        private void R0224_15_FETCH_V0SEGURAVG_SECTION()
        {
            /*" -1361- MOVE 'R0224-15' TO WNR-EXEC-SQL. */
            _.Move("R0224-15", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1414- PERFORM R0224_15_FETCH_V0SEGURAVG_DB_FETCH_1 */

            R0224_15_FETCH_V0SEGURAVG_DB_FETCH_1();

            /*" -1417- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1418- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1419- MOVE 'S' TO WFIM-V0SEGURAVG */
                    _.Move("S", AREA_DE_WORK.WFIM_V0SEGURAVG);

                    /*" -1419- PERFORM R0224_15_FETCH_V0SEGURAVG_DB_CLOSE_1 */

                    R0224_15_FETCH_V0SEGURAVG_DB_CLOSE_1();

                    /*" -1421- ELSE */
                }
                else
                {


                    /*" -1422- DISPLAY 'R0224-15- PROBLEMAS FETCH V0SEGURAVG' */
                    _.Display($"R0224-15- PROBLEMAS FETCH V0SEGURAVG");

                    /*" -1423- DISPLAY 'APOLICE..........   ' V0SEG-NUM-APOL */
                    _.Display($"APOLICE..........   {V0SEG_NUM_APOL}");

                    /*" -1424- DISPLAY 'SUBGRUPO.........   ' V0SEG-COD-SUBG */
                    _.Display($"SUBGRUPO.........   {V0SEG_COD_SUBG}");

                    /*" -1425- DISPLAY 'CERTIFICADO......   ' V0SEG-NUM-CERTIF */
                    _.Display($"CERTIFICADO......   {V0SEG_NUM_CERTIF}");

                    /*" -1426- DISPLAY 'SQLCODE..........   ' SQLCODE */
                    _.Display($"SQLCODE..........   {DB.SQLCODE}");

                    /*" -1427- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -1429- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1431- MOVE 'ERRO NO FETCH DO CURSOR DA VIEW V0SEGURAVG' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO FETCH DO CURSOR DA VIEW V0SEGURAVG", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1432- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -1433- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1434- ELSE */
                }

            }
            else
            {


                /*" -1437- ADD 1 TO AC-L-V0SEGURAVG. */
                AREA_DE_WORK.AC_L_V0SEGURAVG.Value = AREA_DE_WORK.AC_L_V0SEGURAVG + 1;
            }


            /*" -1438- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1439- IF VIND-DT-ADMISSAO LESS 1 */

                if (VIND_DT_ADMISSAO < 1)
                {

                    /*" -1440- MOVE -1 TO VIND-DT-ADMISSAO */
                    _.Move(-1, VIND_DT_ADMISSAO);

                    /*" -1441- END-IF */
                }


                /*" -1442- IF VIND-DT-NASCI LESS 1 */

                if (VIND_DT_NASCI < 1)
                {

                    /*" -1442- MOVE -1 TO VIND-DT-NASCI. */
                    _.Move(-1, VIND_DT_NASCI);
                }

            }


        }

        [StopWatch]
        /*" R0224-15-FETCH-V0SEGURAVG-DB-FETCH-1 */
        public void R0224_15_FETCH_V0SEGURAVG_DB_FETCH_1()
        {
            /*" -1414- EXEC SQL FETCH V0SEGURAVG INTO :V0SEG-NUM-APOL, :V0SEG-COD-SUBG, :V0SEG-NUM-CERTIF, :V0SEG-DAC-CERTIF, :V0SEG-TP-SEGURADO, :V0SEG-NUM-ITEM, :V0SEG-TP-INCLUSAO, :V0SEG-COD-CLIENTE, :V0SEG-COD-FONTE, :V0SEG-NUM-PROPOSTA, :V0SEG-AGENCIADOR, :V0SEG-CORRETOR, :V0SEG-CD-PLANOVGAP, :V0SEG-CD-PLANOAP, :V0SEG-FAIXA, :V0SEG-AUT-AUM-AUT, :V0SEG-TP-BENEFICIA, :V0SEG-OCORR-HIST, :V0SEG-PERI-PGTO, :V0SEG-PERI-RENOVA, :V0SEG-NUM-CARNE, :V0SEG-COD-OCUPACAO, :V0SEG-EST-CIVIL, :V0SEG-SEXO, :V0SEG-CD-PROFISSAO, :V0SEG-NATURALIDADE, :V0SEG-OCOR-ENDERE, :V0SEG-OCOR-END-COB, :V0SEG-BCO-COBRANCA, :V0SEG-AGE-COBRANCA, :V0SEG-DAC-COBRANCA, :V0SEG-NUM-MATRIC, :V0SEG-VAL-SALARIO, :V0SEG-TP-SALARIO, :V0SEG-TP-PLANO, :V0SEG-DT-INIVIG, :V0SEG-PCT-CONJ-VG, :V0SEG-PCT-CONJ-AP, :V0SEG-QTD-S-MONATU, :V0SEG-QTD-S-MOACID, :V0SEG-QTD-S-INVPER, :V0SEG-TX-AP-MOACID, :V0SEG-TX-AP-INVPER, :V0SEG-TX-AP-AMDS, :V0SEG-TX-AP-DH, :V0SEG-TX-AP-DIT, :V0SEG-TAXA-AP, :V0SEG-TAXA-VG, :V0SEG-SIT-REGISTRO, :V0SEG-DT-ADMISSAO:VIND-DT-ADMISSAO, :V0SEG-DT-NASCI:VIND-DT-NASCI, :V0SEG-LOT-EMP-SEGURADO:WLOT-EMP-SEGURADO END-EXEC. */

            if (V0SEGURAVG.Fetch())
            {
                _.Move(V0SEGURAVG.V0SEG_NUM_APOL, V0SEG_NUM_APOL);
                _.Move(V0SEGURAVG.V0SEG_COD_SUBG, V0SEG_COD_SUBG);
                _.Move(V0SEGURAVG.V0SEG_NUM_CERTIF, V0SEG_NUM_CERTIF);
                _.Move(V0SEGURAVG.V0SEG_DAC_CERTIF, V0SEG_DAC_CERTIF);
                _.Move(V0SEGURAVG.V0SEG_TP_SEGURADO, V0SEG_TP_SEGURADO);
                _.Move(V0SEGURAVG.V0SEG_NUM_ITEM, V0SEG_NUM_ITEM);
                _.Move(V0SEGURAVG.V0SEG_TP_INCLUSAO, V0SEG_TP_INCLUSAO);
                _.Move(V0SEGURAVG.V0SEG_COD_CLIENTE, V0SEG_COD_CLIENTE);
                _.Move(V0SEGURAVG.V0SEG_COD_FONTE, V0SEG_COD_FONTE);
                _.Move(V0SEGURAVG.V0SEG_NUM_PROPOSTA, V0SEG_NUM_PROPOSTA);
                _.Move(V0SEGURAVG.V0SEG_AGENCIADOR, V0SEG_AGENCIADOR);
                _.Move(V0SEGURAVG.V0SEG_CORRETOR, V0SEG_CORRETOR);
                _.Move(V0SEGURAVG.V0SEG_CD_PLANOVGAP, V0SEG_CD_PLANOVGAP);
                _.Move(V0SEGURAVG.V0SEG_CD_PLANOAP, V0SEG_CD_PLANOAP);
                _.Move(V0SEGURAVG.V0SEG_FAIXA, V0SEG_FAIXA);
                _.Move(V0SEGURAVG.V0SEG_AUT_AUM_AUT, V0SEG_AUT_AUM_AUT);
                _.Move(V0SEGURAVG.V0SEG_TP_BENEFICIA, V0SEG_TP_BENEFICIA);
                _.Move(V0SEGURAVG.V0SEG_OCORR_HIST, V0SEG_OCORR_HIST);
                _.Move(V0SEGURAVG.V0SEG_PERI_PGTO, V0SEG_PERI_PGTO);
                _.Move(V0SEGURAVG.V0SEG_PERI_RENOVA, V0SEG_PERI_RENOVA);
                _.Move(V0SEGURAVG.V0SEG_NUM_CARNE, V0SEG_NUM_CARNE);
                _.Move(V0SEGURAVG.V0SEG_COD_OCUPACAO, V0SEG_COD_OCUPACAO);
                _.Move(V0SEGURAVG.V0SEG_EST_CIVIL, V0SEG_EST_CIVIL);
                _.Move(V0SEGURAVG.V0SEG_SEXO, V0SEG_SEXO);
                _.Move(V0SEGURAVG.V0SEG_CD_PROFISSAO, V0SEG_CD_PROFISSAO);
                _.Move(V0SEGURAVG.V0SEG_NATURALIDADE, V0SEG_NATURALIDADE);
                _.Move(V0SEGURAVG.V0SEG_OCOR_ENDERE, V0SEG_OCOR_ENDERE);
                _.Move(V0SEGURAVG.V0SEG_OCOR_END_COB, V0SEG_OCOR_END_COB);
                _.Move(V0SEGURAVG.V0SEG_BCO_COBRANCA, V0SEG_BCO_COBRANCA);
                _.Move(V0SEGURAVG.V0SEG_AGE_COBRANCA, V0SEG_AGE_COBRANCA);
                _.Move(V0SEGURAVG.V0SEG_DAC_COBRANCA, V0SEG_DAC_COBRANCA);
                _.Move(V0SEGURAVG.V0SEG_NUM_MATRIC, V0SEG_NUM_MATRIC);
                _.Move(V0SEGURAVG.V0SEG_VAL_SALARIO, V0SEG_VAL_SALARIO);
                _.Move(V0SEGURAVG.V0SEG_TP_SALARIO, V0SEG_TP_SALARIO);
                _.Move(V0SEGURAVG.V0SEG_TP_PLANO, V0SEG_TP_PLANO);
                _.Move(V0SEGURAVG.V0SEG_DT_INIVIG, V0SEG_DT_INIVIG);
                _.Move(V0SEGURAVG.V0SEG_PCT_CONJ_VG, V0SEG_PCT_CONJ_VG);
                _.Move(V0SEGURAVG.V0SEG_PCT_CONJ_AP, V0SEG_PCT_CONJ_AP);
                _.Move(V0SEGURAVG.V0SEG_QTD_S_MONATU, V0SEG_QTD_S_MONATU);
                _.Move(V0SEGURAVG.V0SEG_QTD_S_MOACID, V0SEG_QTD_S_MOACID);
                _.Move(V0SEGURAVG.V0SEG_QTD_S_INVPER, V0SEG_QTD_S_INVPER);
                _.Move(V0SEGURAVG.V0SEG_TX_AP_MOACID, V0SEG_TX_AP_MOACID);
                _.Move(V0SEGURAVG.V0SEG_TX_AP_INVPER, V0SEG_TX_AP_INVPER);
                _.Move(V0SEGURAVG.V0SEG_TX_AP_AMDS, V0SEG_TX_AP_AMDS);
                _.Move(V0SEGURAVG.V0SEG_TX_AP_DH, V0SEG_TX_AP_DH);
                _.Move(V0SEGURAVG.V0SEG_TX_AP_DIT, V0SEG_TX_AP_DIT);
                _.Move(V0SEGURAVG.V0SEG_TAXA_AP, V0SEG_TAXA_AP);
                _.Move(V0SEGURAVG.V0SEG_TAXA_VG, V0SEG_TAXA_VG);
                _.Move(V0SEGURAVG.V0SEG_SIT_REGISTRO, V0SEG_SIT_REGISTRO);
                _.Move(V0SEGURAVG.V0SEG_DT_ADMISSAO, V0SEG_DT_ADMISSAO);
                _.Move(V0SEGURAVG.VIND_DT_ADMISSAO, VIND_DT_ADMISSAO);
                _.Move(V0SEGURAVG.V0SEG_DT_NASCI, V0SEG_DT_NASCI);
                _.Move(V0SEGURAVG.VIND_DT_NASCI, VIND_DT_NASCI);
                _.Move(V0SEGURAVG.V0SEG_LOT_EMP_SEGURADO, V0SEG_LOT_EMP_SEGURADO);
                _.Move(V0SEGURAVG.WLOT_EMP_SEGURADO, WLOT_EMP_SEGURADO);
            }

        }

        [StopWatch]
        /*" R0224-15-FETCH-V0SEGURAVG-DB-CLOSE-1 */
        public void R0224_15_FETCH_V0SEGURAVG_DB_CLOSE_1()
        {
            /*" -1419- EXEC SQL CLOSE V0SEGURAVG END-EXEC */

            V0SEGURAVG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0224_15_SAIDA*/

        [StopWatch]
        /*" R0224-20-PROCESSA-V0SEGURAVG-SECTION */
        private void R0224_20_PROCESSA_V0SEGURAVG_SECTION()
        {
            /*" -1454- MOVE 'R0224-20' TO WNR-EXEC-SQL. */
            _.Move("R0224-20", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1456- MOVE ZERO TO WS-SOLI-EXPURGO, WS-EXPURGO. */
            _.Move(0, AREA_DE_WORK.WS_SOLI_EXPURGO, AREA_DE_WORK.WS_EXPURGO);

            /*" -1458- PERFORM RA224-00-PROCESSA-EXPURGO. */

            RA224_00_PROCESSA_EXPURGO_SECTION();

            /*" -1460- IF EXPURGO-SOLICITADO NEXT SENTENCE */

            if (AREA_DE_WORK.WS_SOLI_EXPURGO["EXPURGO_SOLICITADO"])
            {

                /*" -1461- ELSE */
            }
            else
            {


                /*" -1462- MOVE 'N' TO WS-SEGURAVG */
                _.Move("N", WS_SEGURAVG);

                /*" -1463- PERFORM R0224-30-SELECT-V0HISTSEG */

                R0224_30_SELECT_V0HISTSEG_SECTION();

                /*" -1464- IF WS-SEGURAVG EQUAL 'S' */

                if (WS_SEGURAVG == "S")
                {

                    /*" -1465- GO TO R0224-NEXT */

                    R0224_NEXT(); //GOTO
                    return;

                    /*" -1466- END-IF */
                }


                /*" -1467- PERFORM R0224-35-OBTER-MOEDA */

                R0224_35_OBTER_MOEDA_SECTION();

                /*" -1468- PERFORM R0224-40-OBTER-CAPITAL-PREMIO */

                R0224_40_OBTER_CAPITAL_PREMIO_SECTION();

                /*" -1469- PERFORM R0224-50-OBTER-CONTA-CORR */

                R0224_50_OBTER_CONTA_CORR_SECTION();

                /*" -1470- PERFORM R0224-25-OBTER-NUM-PROPOSTA */

                R0224_25_OBTER_NUM_PROPOSTA_SECTION();

                /*" -1470- PERFORM R0224-55-CANCELA-SEGURADO. */

                R0224_55_CANCELA_SEGURADO_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0224_NEXT */

            R0224_NEXT();

        }

        [StopWatch]
        /*" R0224-NEXT */
        private void R0224_NEXT(bool isPerform = false)
        {
            /*" -1473- PERFORM R0224-15-FETCH-V0SEGURAVG. */

            R0224_15_FETCH_V0SEGURAVG_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0224_20_SAIDA*/

        [StopWatch]
        /*" RA224-00-PROCESSA-EXPURGO-SECTION */
        private void RA224_00_PROCESSA_EXPURGO_SECTION()
        {
            /*" -1485- MOVE 'RA224-00' TO WNR-EXEC-SQL. */
            _.Move("RA224-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1487- PERFORM RB224-00-LER-APOL-EXPURGO. */

            RB224_00_LER_APOL_EXPURGO_SECTION();

            /*" -1488- IF EXISTE-EXPURGO */

            if (AREA_DE_WORK.WS_EXPURGO["EXISTE_EXPURGO"])
            {

                /*" -1488- PERFORM RC224-00-PROCESSA-EXPURGO. */

                RC224_00_PROCESSA_EXPURGO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RA224_10_SAIDA*/

        [StopWatch]
        /*" RB224-00-LER-APOL-EXPURGO-SECTION */
        private void RB224_00_LER_APOL_EXPURGO_SECTION()
        {
            /*" -1500- MOVE 'RB224-00' TO WNR-EXEC-SQL. */
            _.Move("RB224-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1518- PERFORM RB224_00_LER_APOL_EXPURGO_DB_SELECT_1 */

            RB224_00_LER_APOL_EXPURGO_DB_SELECT_1();

            /*" -1521- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1523- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1524- ELSE */
                }
                else
                {


                    /*" -1526- DISPLAY 'VG0031B - PROBLEMAS LEITURA APOLIEXPURGO... ' SQLCODE */
                    _.Display($"VG0031B - PROBLEMAS LEITURA APOLIEXPURGO... {DB.SQLCODE}");

                    /*" -1528- DISPLAY '          NUM-APOLICE...................... ' V0SEG-NUM-APOL */
                    _.Display($"          NUM-APOLICE...................... {V0SEG_NUM_APOL}");

                    /*" -1530- DISPLAY '          NUM-ITEM......................... ' V0SEG-NUM-ITEM */
                    _.Display($"          NUM-ITEM......................... {V0SEG_NUM_ITEM}");

                    /*" -1531- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -1533- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1535- MOVE 'ERRO NO ACESSO DA TABELA APOLICE_EXPURGO ' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO ACESSO DA TABELA APOLICE_EXPURGO ", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1536- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -1537- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1538- ELSE */
                }

            }
            else
            {


                /*" -1539- MOVE 1 TO WS-EXPURGO */
                _.Move(1, AREA_DE_WORK.WS_EXPURGO);

                /*" -1539- ADD 1 TO AC-L-EXPURGO. */
                AREA_DE_WORK.AC_L_EXPURGO.Value = AREA_DE_WORK.AC_L_EXPURGO + 1;
            }


        }

        [StopWatch]
        /*" RB224-00-LER-APOL-EXPURGO-DB-SELECT-1 */
        public void RB224_00_LER_APOL_EXPURGO_DB_SELECT_1()
        {
            /*" -1518- EXEC SQL SELECT NUM_APOLICE , NUM_ITEM , ID_MESTRE_EXPURGO, RAMO , SITUACAO_APOLICE , DATA_SITUACAO , COD_CLIENTE INTO :DCLAPOLICE-EXPURGO.APOLIEXP-NUM-APOLICE , :DCLAPOLICE-EXPURGO.APOLIEXP-NUM-ITEM , :DCLAPOLICE-EXPURGO.APOLIEXP-ID-MESTRE-EXPURGO, :DCLAPOLICE-EXPURGO.APOLIEXP-RAMO , :DCLAPOLICE-EXPURGO.APOLIEXP-SITUACAO-APOLICE , :DCLAPOLICE-EXPURGO.APOLIEXP-DATA-SITUACAO , :DCLAPOLICE-EXPURGO.APOLIEXP-COD-CLIENTE FROM EXPURGO.APOLICE_EXPURGO WHERE NUM_APOLICE = :V0SEG-NUM-APOL AND NUM_ITEM = :V0SEG-NUM-ITEM END-EXEC. */

            var rB224_00_LER_APOL_EXPURGO_DB_SELECT_1_Query1 = new RB224_00_LER_APOL_EXPURGO_DB_SELECT_1_Query1()
            {
                V0SEG_NUM_APOL = V0SEG_NUM_APOL.ToString(),
                V0SEG_NUM_ITEM = V0SEG_NUM_ITEM.ToString(),
            };

            var executed_1 = RB224_00_LER_APOL_EXPURGO_DB_SELECT_1_Query1.Execute(rB224_00_LER_APOL_EXPURGO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLIEXP_NUM_APOLICE, APOLIEXP.DCLAPOLICE_EXPURGO.APOLIEXP_NUM_APOLICE);
                _.Move(executed_1.APOLIEXP_NUM_ITEM, APOLIEXP.DCLAPOLICE_EXPURGO.APOLIEXP_NUM_ITEM);
                _.Move(executed_1.APOLIEXP_ID_MESTRE_EXPURGO, APOLIEXP.DCLAPOLICE_EXPURGO.APOLIEXP_ID_MESTRE_EXPURGO);
                _.Move(executed_1.APOLIEXP_RAMO, APOLIEXP.DCLAPOLICE_EXPURGO.APOLIEXP_RAMO);
                _.Move(executed_1.APOLIEXP_SITUACAO_APOLICE, APOLIEXP.DCLAPOLICE_EXPURGO.APOLIEXP_SITUACAO_APOLICE);
                _.Move(executed_1.APOLIEXP_DATA_SITUACAO, APOLIEXP.DCLAPOLICE_EXPURGO.APOLIEXP_DATA_SITUACAO);
                _.Move(executed_1.APOLIEXP_COD_CLIENTE, APOLIEXP.DCLAPOLICE_EXPURGO.APOLIEXP_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RB224_99_SAIDA*/

        [StopWatch]
        /*" RC224-00-PROCESSA-EXPURGO-SECTION */
        private void RC224_00_PROCESSA_EXPURGO_SECTION()
        {
            /*" -1552- PERFORM RD224-00-LER-RETORNO-EXPURGO */

            RD224_00_LER_RETORNO_EXPURGO_SECTION();

            /*" -1553- IF EXPURGO-SOLICITADO */

            if (AREA_DE_WORK.WS_SOLI_EXPURGO["EXPURGO_SOLICITADO"])
            {

                /*" -1554- IF RETOREXP-SITUACAO-RETORNO EQUAL 1 */

                if (RETOREXP.DCLRETORNO_EXPURGO.RETOREXP_SITUACAO_RETORNO == 1)
                {

                    /*" -1555- MOVE ZERO TO WS-SOLI-EXPURGO */
                    _.Move(0, AREA_DE_WORK.WS_SOLI_EXPURGO);

                    /*" -1556- END-IF */
                }


                /*" -1557- ELSE */
            }
            else
            {


                /*" -1559- MOVE 1 TO WS-SOLI-EXPURGO WS-EXPURGO-SUBGRUPO */
                _.Move(1, AREA_DE_WORK.WS_SOLI_EXPURGO, AREA_DE_WORK.WS_EXPURGO_SUBGRUPO);

                /*" -1560- MOVE ZERO TO WS-RELATORIO */
                _.Move(0, AREA_DE_WORK.WS_RELATORIO);

                /*" -1561- ADD 1 TO AC-EXPURGADO */
                AREA_DE_WORK.AC_EXPURGADO.Value = AREA_DE_WORK.AC_EXPURGADO + 1;

                /*" -1561- PERFORM RE224-00-GRAVAR-TORNO-EXPURGO. */

                RE224_00_GRAVAR_TORNO_EXPURGO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RC224_99_SAIDA*/

        [StopWatch]
        /*" RD224-00-LER-RETORNO-EXPURGO-SECTION */
        private void RD224_00_LER_RETORNO_EXPURGO_SECTION()
        {
            /*" -1577- MOVE 'RD224-00' TO WNR-EXEC-SQL. */
            _.Move("RD224-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1585- PERFORM RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1 */

            RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1();

            /*" -1589- IF SQLCODE EQUAL ZEROS OR SQLCODE EQUAL -811 */

            if (DB.SQLCODE == 00 || DB.SQLCODE == -811)
            {

                /*" -1590- MOVE 1 TO WS-SOLI-EXPURGO */
                _.Move(1, AREA_DE_WORK.WS_SOLI_EXPURGO);

                /*" -1591- IF RETOREXP-SITUACAO-RETORNO EQUAL ZERO */

                if (RETOREXP.DCLRETORNO_EXPURGO.RETOREXP_SITUACAO_RETORNO == 00)
                {

                    /*" -1592- MOVE 1 TO WS-EXPURGO-SUBGRUPO */
                    _.Move(1, AREA_DE_WORK.WS_EXPURGO_SUBGRUPO);

                    /*" -1593- MOVE ZERO TO WS-RELATORIO */
                    _.Move(0, AREA_DE_WORK.WS_RELATORIO);

                    /*" -1594- END-IF */
                }


                /*" -1595- ELSE */
            }
            else
            {


                /*" -1597- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1598- ELSE */
                }
                else
                {


                    /*" -1599- DISPLAY 'VG0031B - PROBLEMAS ACESSO RETORNO EXPURGO' */
                    _.Display($"VG0031B - PROBLEMAS ACESSO RETORNO EXPURGO");

                    /*" -1600- DISPLAY '          APOLICE......  ' V0SEG-NUM-APOL */
                    _.Display($"          APOLICE......  {V0SEG_NUM_APOL}");

                    /*" -1601- DISPLAY '          ITEM.........  ' V0SEG-NUM-ITEM */
                    _.Display($"          ITEM.........  {V0SEG_NUM_ITEM}");

                    /*" -1602- DISPLAY '          SQLCODE......  ' SQLCODE */
                    _.Display($"          SQLCODE......  {DB.SQLCODE}");

                    /*" -1603- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -1605- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1607- MOVE 'ERRO NO ACESSO DA TABELA APOLICE_EXPURGO ' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO ACESSO DA TABELA APOLICE_EXPURGO ", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1608- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -1608- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" RD224-00-LER-RETORNO-EXPURGO-DB-SELECT-1 */
        public void RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1()
        {
            /*" -1585- EXEC SQL SELECT NUM_APOLICE, SITUACAO_RETORNO INTO :DCLRETORNO-EXPURGO.RETOREXP-NUM-APOLICE, :DCLRETORNO-EXPURGO.RETOREXP-SITUACAO-RETORNO FROM EXPURGO.RETORNO_EXPURGO WHERE NUM_APOLICE = :V0SEG-NUM-APOL AND NUM_ITEM = :V0SEG-NUM-ITEM END-EXEC. */

            var rD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1 = new RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1()
            {
                V0SEG_NUM_APOL = V0SEG_NUM_APOL.ToString(),
                V0SEG_NUM_ITEM = V0SEG_NUM_ITEM.ToString(),
            };

            var executed_1 = RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1.Execute(rD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RETOREXP_NUM_APOLICE, RETOREXP.DCLRETORNO_EXPURGO.RETOREXP_NUM_APOLICE);
                _.Move(executed_1.RETOREXP_SITUACAO_RETORNO, RETOREXP.DCLRETORNO_EXPURGO.RETOREXP_SITUACAO_RETORNO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RD224_99_SAIDA*/

        [StopWatch]
        /*" RE224-00-GRAVAR-TORNO-EXPURGO-SECTION */
        private void RE224_00_GRAVAR_TORNO_EXPURGO_SECTION()
        {
            /*" -1623- MOVE 'RE224-00' TO WNR-EXEC-SQL. */
            _.Move("RE224-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1631- PERFORM RE224_00_GRAVAR_TORNO_EXPURGO_DB_INSERT_1 */

            RE224_00_GRAVAR_TORNO_EXPURGO_DB_INSERT_1();

            /*" -1635- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1636- DISPLAY 'VG0031B - PROBLEMAS INSERT RETORNO EXPURGO' */
                _.Display($"VG0031B - PROBLEMAS INSERT RETORNO EXPURGO");

                /*" -1637- DISPLAY '          APOLICE......  ' V0SEG-NUM-APOL */
                _.Display($"          APOLICE......  {V0SEG_NUM_APOL}");

                /*" -1638- DISPLAY '          ITEM.........  ' V0SEG-NUM-ITEM */
                _.Display($"          ITEM.........  {V0SEG_NUM_ITEM}");

                /*" -1639- DISPLAY '          SQLCODE......  ' SQLCODE */
                _.Display($"          SQLCODE......  {DB.SQLCODE}");

                /*" -1640- PERFORM R0450-00-LIMPA-REGISTROS */

                R0450_00_LIMPA_REGISTROS_SECTION();

                /*" -1642- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1644- MOVE 'ERRO NO ACESSO DA TABELA APOLICE_EXPURGO ' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO DA TABELA APOLICE_EXPURGO ", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1645- PERFORM R0460-00-GRAVA-REGISTROS */

                R0460_00_GRAVA_REGISTROS_SECTION();

                /*" -1645- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" RE224-00-GRAVAR-TORNO-EXPURGO-DB-INSERT-1 */
        public void RE224_00_GRAVAR_TORNO_EXPURGO_DB_INSERT_1()
        {
            /*" -1631- EXEC SQL INSERT INTO EXPURGO.RETORNO_EXPURGO VALUES (:V1SIST-DTMOVABE , :DCLAPOLICE-EXPURGO.APOLIEXP-NUM-APOLICE, :DCLAPOLICE-EXPURGO.APOLIEXP-NUM-ITEM , :DCLAPOLICE-EXPURGO.APOLIEXP-ID-MESTRE-EXPURGO , 'VG0031B' , 0) END-EXEC. */

            var rE224_00_GRAVAR_TORNO_EXPURGO_DB_INSERT_1_Insert1 = new RE224_00_GRAVAR_TORNO_EXPURGO_DB_INSERT_1_Insert1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                APOLIEXP_NUM_APOLICE = APOLIEXP.DCLAPOLICE_EXPURGO.APOLIEXP_NUM_APOLICE.ToString(),
                APOLIEXP_NUM_ITEM = APOLIEXP.DCLAPOLICE_EXPURGO.APOLIEXP_NUM_ITEM.ToString(),
                APOLIEXP_ID_MESTRE_EXPURGO = APOLIEXP.DCLAPOLICE_EXPURGO.APOLIEXP_ID_MESTRE_EXPURGO.ToString(),
            };

            RE224_00_GRAVAR_TORNO_EXPURGO_DB_INSERT_1_Insert1.Execute(rE224_00_GRAVAR_TORNO_EXPURGO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RE224_99_SAIDA*/

        [StopWatch]
        /*" R0224-25-OBTER-NUM-PROPOSTA-SECTION */
        private void R0224_25_OBTER_NUM_PROPOSTA_SECTION()
        {
            /*" -1657- MOVE 'R0224-25' TO WNR-EXEC-SQL. */
            _.Move("R0224-25", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1662- PERFORM R0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1 */

            R0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1();

            /*" -1665- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1666- DISPLAY ' ' */
                _.Display($" ");

                /*" -1667- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1668- DISPLAY 'R0224-25 - FONTE NAO CADASTRADA' */
                    _.Display($"R0224-25 - FONTE NAO CADASTRADA");

                    /*" -1669- DISPLAY 'COD.FONTE....  ' V0SEG-COD-FONTE */
                    _.Display($"COD.FONTE....  {V0SEG_COD_FONTE}");

                    /*" -1670- DISPLAY 'SQLCODE......  ' SQLCODE */
                    _.Display($"SQLCODE......  {DB.SQLCODE}");

                    /*" -1671- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -1673- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1675- MOVE 'FONTE NAO CADASTRADA ' TO LD-DES-ERRO-SSAIDA */
                    _.Move("FONTE NAO CADASTRADA ", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1676- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -1677- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1678- ELSE */
                }
                else
                {


                    /*" -1679- DISPLAY 'R0224-25 - PROBLEMAS ACESSO V0FONTE' */
                    _.Display($"R0224-25 - PROBLEMAS ACESSO V0FONTE");

                    /*" -1680- DISPLAY 'COD.FONTE....  ' V0SEG-COD-FONTE */
                    _.Display($"COD.FONTE....  {V0SEG_COD_FONTE}");

                    /*" -1681- DISPLAY 'SQLCODE......  ' SQLCODE */
                    _.Display($"SQLCODE......  {DB.SQLCODE}");

                    /*" -1682- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -1684- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1686- MOVE 'ERRO NO ACESSO A VIEW V0FONTE' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO ACESSO A VIEW V0FONTE", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1687- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -1690- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1692- ADD +1 TO V0FONTE-PROPAUTOM. */
            V0FONTE_PROPAUTOM.Value = V0FONTE_PROPAUTOM + +1;

            /*" -1697- PERFORM R0224_25_OBTER_NUM_PROPOSTA_DB_UPDATE_1 */

            R0224_25_OBTER_NUM_PROPOSTA_DB_UPDATE_1();

            /*" -1700- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1701- DISPLAY 'R0224-25 - PROBLEMAS UPDATE V0FONTE' */
                _.Display($"R0224-25 - PROBLEMAS UPDATE V0FONTE");

                /*" -1702- DISPLAY 'COD.FONTE....  ' V0SEG-COD-FONTE */
                _.Display($"COD.FONTE....  {V0SEG_COD_FONTE}");

                /*" -1703- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -1704- PERFORM R0450-00-LIMPA-REGISTROS */

                R0450_00_LIMPA_REGISTROS_SECTION();

                /*" -1706- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1708- MOVE 'ERRO NO UPDATE DA VIEW V0FONTE' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO UPDATE DA VIEW V0FONTE", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1709- PERFORM R0460-00-GRAVA-REGISTROS */

                R0460_00_GRAVA_REGISTROS_SECTION();

                /*" -1709- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0224-25-OBTER-NUM-PROPOSTA-DB-SELECT-1 */
        public void R0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1()
        {
            /*" -1662- EXEC SQL SELECT PROPAUTOM INTO :V0FONTE-PROPAUTOM FROM SEGUROS.V0FONTE WHERE FONTE = :V0SEG-COD-FONTE END-EXEC. */

            var r0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1_Query1 = new R0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1_Query1()
            {
                V0SEG_COD_FONTE = V0SEG_COD_FONTE.ToString(),
            };

            var executed_1 = R0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1_Query1.Execute(r0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FONTE_PROPAUTOM, V0FONTE_PROPAUTOM);
            }


        }

        [StopWatch]
        /*" R0224-25-OBTER-NUM-PROPOSTA-DB-UPDATE-1 */
        public void R0224_25_OBTER_NUM_PROPOSTA_DB_UPDATE_1()
        {
            /*" -1697- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V0FONTE-PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0SEG-COD-FONTE END-EXEC. */

            var r0224_25_OBTER_NUM_PROPOSTA_DB_UPDATE_1_Update1 = new R0224_25_OBTER_NUM_PROPOSTA_DB_UPDATE_1_Update1()
            {
                V0FONTE_PROPAUTOM = V0FONTE_PROPAUTOM.ToString(),
                V0SEG_COD_FONTE = V0SEG_COD_FONTE.ToString(),
            };

            R0224_25_OBTER_NUM_PROPOSTA_DB_UPDATE_1_Update1.Execute(r0224_25_OBTER_NUM_PROPOSTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0224_25_SAIDA*/

        [StopWatch]
        /*" R0224-30-SELECT-V0HISTSEG-SECTION */
        private void R0224_30_SELECT_V0HISTSEG_SECTION()
        {
            /*" -1719- MOVE 'R0224-30' TO WNR-EXEC-SQL. */
            _.Move("R0224-30", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1730- PERFORM R0224_30_SELECT_V0HISTSEG_DB_SELECT_1 */

            R0224_30_SELECT_V0HISTSEG_DB_SELECT_1();

            /*" -1733- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1734- DISPLAY ' ' */
                _.Display($" ");

                /*" -1736- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1742- PERFORM R0224-32-UPD-SEGURAVG */

                    R0224_32_UPD_SEGURAVG_SECTION();

                    /*" -1743- ELSE */
                }
                else
                {


                    /*" -1744- DISPLAY 'R0224-30 - PROBLEMAS ACESSO V1HISTSEGVG' */
                    _.Display($"R0224-30 - PROBLEMAS ACESSO V1HISTSEGVG");

                    /*" -1745- DISPLAY 'APOLICE......  ' V0SEG-NUM-APOL */
                    _.Display($"APOLICE......  {V0SEG_NUM_APOL}");

                    /*" -1746- DISPLAY 'ITEM.........  ' V0SEG-NUM-ITEM */
                    _.Display($"ITEM.........  {V0SEG_NUM_ITEM}");

                    /*" -1747- DISPLAY 'OCORHIST.....  ' V0SEG-OCORR-HIST */
                    _.Display($"OCORHIST.....  {V0SEG_OCORR_HIST}");

                    /*" -1748- DISPLAY 'SQLCODE......  ' SQLCODE */
                    _.Display($"SQLCODE......  {DB.SQLCODE}");

                    /*" -1749- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -1751- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1753- MOVE 'ERRO NO ACESSO A VIEW V1HISTSEGVG ' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO ACESSO A VIEW V1HISTSEGVG ", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1754- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -1754- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0224-30-SELECT-V0HISTSEG-DB-SELECT-1 */
        public void R0224_30_SELECT_V0HISTSEG_DB_SELECT_1()
        {
            /*" -1730- EXEC SQL SELECT DATA_MOVIMENTO, COD_MOEDA_IMP, COD_MOEDA_PRM INTO :V1HSEG-DT-MOVTO, :V1HSEG-MOEDA-IMP, :V1HSEG-MOEDA-PRM FROM SEGUROS.V1HISTSEGVG WHERE NUM_APOLICE = :V0SEG-NUM-APOL AND NUM_ITEM = :V0SEG-NUM-ITEM AND OCORR_HISTORICO = :V0SEG-OCORR-HIST END-EXEC. */

            var r0224_30_SELECT_V0HISTSEG_DB_SELECT_1_Query1 = new R0224_30_SELECT_V0HISTSEG_DB_SELECT_1_Query1()
            {
                V0SEG_OCORR_HIST = V0SEG_OCORR_HIST.ToString(),
                V0SEG_NUM_APOL = V0SEG_NUM_APOL.ToString(),
                V0SEG_NUM_ITEM = V0SEG_NUM_ITEM.ToString(),
            };

            var executed_1 = R0224_30_SELECT_V0HISTSEG_DB_SELECT_1_Query1.Execute(r0224_30_SELECT_V0HISTSEG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1HSEG_DT_MOVTO, V1HSEG_DT_MOVTO);
                _.Move(executed_1.V1HSEG_MOEDA_IMP, V1HSEG_MOEDA_IMP);
                _.Move(executed_1.V1HSEG_MOEDA_PRM, V1HSEG_MOEDA_PRM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0224_30_SAIDA*/

        [StopWatch]
        /*" R0224-32-UPD-SEGURAVG-SECTION */
        private void R0224_32_UPD_SEGURAVG_SECTION()
        {
            /*" -1764- MOVE 'R0230-32' TO WNR-EXEC-SQL. */
            _.Move("R0230-32", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1766- MOVE 'N' TO WS-SEGURAVG. */
            _.Move("N", WS_SEGURAVG);

            /*" -1771- PERFORM R0224_32_UPD_SEGURAVG_DB_UPDATE_1 */

            R0224_32_UPD_SEGURAVG_DB_UPDATE_1();

            /*" -1774- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1775- DISPLAY 'R0230-32 (PROBLEMAS UPDATE SEGURADOS_VGAP)' */
                _.Display($"R0230-32 (PROBLEMAS UPDATE SEGURADOS_VGAP)");

                /*" -1776- DISPLAY 'NUM_APOLICE :' V0SEG-NUM-APOL */
                _.Display($"NUM_APOLICE :{V0SEG_NUM_APOL}");

                /*" -1777- DISPLAY 'NUM ITEM    :' V0SEG-NUM-ITEM */
                _.Display($"NUM ITEM    :{V0SEG_NUM_ITEM}");

                /*" -1778- PERFORM R0450-00-LIMPA-REGISTROS */

                R0450_00_LIMPA_REGISTROS_SECTION();

                /*" -1780- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1782- MOVE 'ERRO NO UPDATE DA TABELA SEGURADOS_VGAP' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO UPDATE DA TABELA SEGURADOS_VGAP", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1783- PERFORM R0460-00-GRAVA-REGISTROS */

                R0460_00_GRAVA_REGISTROS_SECTION();

                /*" -1785- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1785- MOVE 'S' TO WS-SEGURAVG. */
            _.Move("S", WS_SEGURAVG);

        }

        [StopWatch]
        /*" R0224-32-UPD-SEGURAVG-DB-UPDATE-1 */
        public void R0224_32_UPD_SEGURAVG_DB_UPDATE_1()
        {
            /*" -1771- EXEC SQL UPDATE SEGUROS.SEGURADOS_VGAP SET SIT_REGISTRO = '2' WHERE NUM_APOLICE = :V0SEG-NUM-APOL AND NUM_ITEM = :V0SEG-NUM-ITEM END-EXEC. */

            var r0224_32_UPD_SEGURAVG_DB_UPDATE_1_Update1 = new R0224_32_UPD_SEGURAVG_DB_UPDATE_1_Update1()
            {
                V0SEG_NUM_APOL = V0SEG_NUM_APOL.ToString(),
                V0SEG_NUM_ITEM = V0SEG_NUM_ITEM.ToString(),
            };

            R0224_32_UPD_SEGURAVG_DB_UPDATE_1_Update1.Execute(r0224_32_UPD_SEGURAVG_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0224_32_SAIDA*/

        [StopWatch]
        /*" R0224-35-OBTER-MOEDA-SECTION */
        private void R0224_35_OBTER_MOEDA_SECTION()
        {
            /*" -1795- MOVE 'R224-35' TO WNR-EXEC-SQL. */
            _.Move("R224-35", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1802- PERFORM R0224_35_OBTER_MOEDA_DB_SELECT_1 */

            R0224_35_OBTER_MOEDA_DB_SELECT_1();

            /*" -1805- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1806- DISPLAY ' ' */
                _.Display($" ");

                /*" -1807- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1808- DISPLAY 'R0224-35 - V0COTACAO NAO CADASTRADA' */
                    _.Display($"R0224-35 - V0COTACAO NAO CADASTRADA");

                    /*" -1809- DISPLAY 'CODUNIMO.IMP.  ' V1HSEG-MOEDA-IMP */
                    _.Display($"CODUNIMO.IMP.  {V1HSEG_MOEDA_IMP}");

                    /*" -1810- DISPLAY 'DT.MOVTO.....  ' V1HSEG-DT-MOVTO */
                    _.Display($"DT.MOVTO.....  {V1HSEG_DT_MOVTO}");

                    /*" -1811- DISPLAY 'SQLCODE......  ' SQLCODE */
                    _.Display($"SQLCODE......  {DB.SQLCODE}");

                    /*" -1812- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -1817- STRING 'V0COTACAO NAO CADASTRADA ' ' DT.MOVTO.....  ' V1HSEG-DT-MOVTO DELIMITED BY SIZE INTO LD-DES-ERRO-DSAIDA END-STRING */
                    #region STRING
                    var spl1 = "V0COTACAO NAO CADASTRADA " + " DT.MOVTO..... " + V1HSEG_DT_MOVTO.GetMoveValues();
                    _.Move(spl1, AREA_DE_WORK.LD_REG_DSAIDA.LD_DES_ERRO_DSAIDA);
                    #endregion

                    /*" -1818- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -1819- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1820- ELSE */
                }
                else
                {


                    /*" -1821- DISPLAY 'R0224-35 - PROBLEMAS ACESSO V0COTACAO' */
                    _.Display($"R0224-35 - PROBLEMAS ACESSO V0COTACAO");

                    /*" -1822- DISPLAY 'CODUNIMO.IMP.  ' V1HSEG-MOEDA-IMP */
                    _.Display($"CODUNIMO.IMP.  {V1HSEG_MOEDA_IMP}");

                    /*" -1823- DISPLAY 'DT.MOVTO.....  ' V1HSEG-DT-MOVTO */
                    _.Display($"DT.MOVTO.....  {V1HSEG_DT_MOVTO}");

                    /*" -1824- DISPLAY 'SQLCODE......  ' SQLCODE */
                    _.Display($"SQLCODE......  {DB.SQLCODE}");

                    /*" -1825- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -1827- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1832- STRING 'ERRO NO ACESSO A VIEW V0COTACAO ' ' DT.MOVTO.....  ' V1HSEG-DT-MOVTO DELIMITED BY SIZE INTO LD-DES-ERRO-SSAIDA END-STRING */
                    #region STRING
                    var spl2 = "ERRO NO ACESSO A VIEW V0COTACAO " + " DT.MOVTO..... " + V1HSEG_DT_MOVTO.GetMoveValues();
                    _.Move(spl2, AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);
                    #endregion

                    /*" -1834- MOVE 'ERRO NO ACESSO A VIEW V0COTACAO' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO ACESSO A VIEW V0COTACAO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1835- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -1837- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1838- IF V1HSEG-MOEDA-IMP EQUAL V1HSEG-MOEDA-PRM */

            if (V1HSEG_MOEDA_IMP == V1HSEG_MOEDA_PRM)
            {

                /*" -1839- MOVE V0VLCRUZAD-IMP TO V0VLCRUZAD-PRM */
                _.Move(V0VLCRUZAD_IMP, V0VLCRUZAD_PRM);

                /*" -1840- ELSE */
            }
            else
            {


                /*" -1847- PERFORM R0224_35_OBTER_MOEDA_DB_SELECT_2 */

                R0224_35_OBTER_MOEDA_DB_SELECT_2();

                /*" -1850- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1851- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1852- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1853- DISPLAY 'R0224-35 - V0COTACAO NAO CADASTRADA' */
                        _.Display($"R0224-35 - V0COTACAO NAO CADASTRADA");

                        /*" -1854- DISPLAY 'CODUNIMO.PRM.  ' V1HSEG-MOEDA-PRM */
                        _.Display($"CODUNIMO.PRM.  {V1HSEG_MOEDA_PRM}");

                        /*" -1855- DISPLAY 'DT.MOVTO.....  ' V1HSEG-DT-MOVTO */
                        _.Display($"DT.MOVTO.....  {V1HSEG_DT_MOVTO}");

                        /*" -1856- DISPLAY 'SQLCODE......  ' SQLCODE */
                        _.Display($"SQLCODE......  {DB.SQLCODE}");

                        /*" -1857- PERFORM R0450-00-LIMPA-REGISTROS */

                        R0450_00_LIMPA_REGISTROS_SECTION();

                        /*" -1862- STRING 'V0COTACAO NAO CADASTRADA ' ' DT.MOVTO.....  ' V1HSEG-DT-MOVTO DELIMITED BY SIZE INTO LD-DES-ERRO-DSAIDA END-STRING */
                        #region STRING
                        var spl3 = "V0COTACAO NAO CADASTRADA " + " DT.MOVTO..... " + V1HSEG_DT_MOVTO.GetMoveValues();
                        _.Move(spl3, AREA_DE_WORK.LD_REG_DSAIDA.LD_DES_ERRO_DSAIDA);
                        #endregion

                        /*" -1863- PERFORM R0460-00-GRAVA-REGISTROS */

                        R0460_00_GRAVA_REGISTROS_SECTION();

                        /*" -1864- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1865- ELSE */
                    }
                    else
                    {


                        /*" -1866- DISPLAY 'R0224-35 - PROBLEMAS ACESSO V0COTACAO' */
                        _.Display($"R0224-35 - PROBLEMAS ACESSO V0COTACAO");

                        /*" -1867- DISPLAY 'CODUNIMO-PRM.  ' V1HSEG-MOEDA-PRM */
                        _.Display($"CODUNIMO-PRM.  {V1HSEG_MOEDA_PRM}");

                        /*" -1868- DISPLAY 'DT.MOVTO.....  ' V1HSEG-DT-MOVTO */
                        _.Display($"DT.MOVTO.....  {V1HSEG_DT_MOVTO}");

                        /*" -1869- DISPLAY 'SQLCODE......  ' SQLCODE */
                        _.Display($"SQLCODE......  {DB.SQLCODE}");

                        /*" -1870- PERFORM R0450-00-LIMPA-REGISTROS */

                        R0450_00_LIMPA_REGISTROS_SECTION();

                        /*" -1872- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                        _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                        /*" -1877- STRING 'ERRO NO ACESSO A VIEW V0COTACAO ' ' DT.MOVTO.....  ' V1HSEG-DT-MOVTO DELIMITED BY SIZE INTO LD-DES-ERRO-SSAIDA END-STRING */
                        #region STRING
                        var spl4 = "ERRO NO ACESSO A VIEW V0COTACAO " + " DT.MOVTO..... " + V1HSEG_DT_MOVTO.GetMoveValues();
                        _.Move(spl4, AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);
                        #endregion

                        /*" -1879- MOVE 'ERRO NO ACESSO A VIEW V0COTACAO' TO LD-DES-ERRO-SSAIDA */
                        _.Move("ERRO NO ACESSO A VIEW V0COTACAO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                        /*" -1880- PERFORM R0460-00-GRAVA-REGISTROS */

                        R0460_00_GRAVA_REGISTROS_SECTION();

                        /*" -1880- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R0224-35-OBTER-MOEDA-DB-SELECT-1 */
        public void R0224_35_OBTER_MOEDA_DB_SELECT_1()
        {
            /*" -1802- EXEC SQL SELECT VALCPR INTO :V0VLCRUZAD-IMP FROM SEGUROS.V0COTACAO WHERE CODUNIMO = :V1HSEG-MOEDA-IMP AND DTINIVIG <= :V1HSEG-DT-MOVTO AND DTTERVIG >= :V1HSEG-DT-MOVTO END-EXEC. */

            var r0224_35_OBTER_MOEDA_DB_SELECT_1_Query1 = new R0224_35_OBTER_MOEDA_DB_SELECT_1_Query1()
            {
                V1HSEG_MOEDA_IMP = V1HSEG_MOEDA_IMP.ToString(),
                V1HSEG_DT_MOVTO = V1HSEG_DT_MOVTO.ToString(),
            };

            var executed_1 = R0224_35_OBTER_MOEDA_DB_SELECT_1_Query1.Execute(r0224_35_OBTER_MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0VLCRUZAD_IMP, V0VLCRUZAD_IMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0224_35_SAIDA*/

        [StopWatch]
        /*" R0224-35-OBTER-MOEDA-DB-SELECT-2 */
        public void R0224_35_OBTER_MOEDA_DB_SELECT_2()
        {
            /*" -1847- EXEC SQL SELECT VALCPR INTO :V0VLCRUZAD-PRM FROM SEGUROS.V0COTACAO WHERE CODUNIMO = :V1HSEG-MOEDA-PRM AND DTINIVIG <= :V1HSEG-DT-MOVTO AND DTTERVIG >= :V1HSEG-DT-MOVTO END-EXEC */

            var r0224_35_OBTER_MOEDA_DB_SELECT_2_Query1 = new R0224_35_OBTER_MOEDA_DB_SELECT_2_Query1()
            {
                V1HSEG_MOEDA_PRM = V1HSEG_MOEDA_PRM.ToString(),
                V1HSEG_DT_MOVTO = V1HSEG_DT_MOVTO.ToString(),
            };

            var executed_1 = R0224_35_OBTER_MOEDA_DB_SELECT_2_Query1.Execute(r0224_35_OBTER_MOEDA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0VLCRUZAD_PRM, V0VLCRUZAD_PRM);
            }


        }

        [StopWatch]
        /*" R0224-40-OBTER-CAPITAL-PREMIO-SECTION */
        private void R0224_40_OBTER_CAPITAL_PREMIO_SECTION()
        {
            /*" -1891- MOVE 'R0224-40' TO WNR-EXEC-SQL. */
            _.Move("R0224-40", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1900- MOVE 0 TO V0MOV-IMP-MORNATU V0MOV-IMP-MORACID V0MOV-IMP-INVPERM V0MOV-IMP-AMDS V0MOV-IMP-DH V0MOV-IMP-DIT V0MOV-PRM-VG V0MOV-PRM-AP. */
            _.Move(0, V0MOV_IMP_MORNATU, V0MOV_IMP_MORACID, V0MOV_IMP_INVPERM, V0MOV_IMP_AMDS, V0MOV_IMP_DH, V0MOV_IMP_DIT, V0MOV_PRM_VG, V0MOV_PRM_AP);

            /*" -1901- MOVE V0SEG-NUM-APOL TO V0CBA-NUM-APOLICE. */
            _.Move(V0SEG_NUM_APOL, V0CBA_NUM_APOLICE);

            /*" -1902- MOVE V0SEG-NUM-ITEM TO V0CBA-NUM-ITEM. */
            _.Move(V0SEG_NUM_ITEM, V0CBA_NUM_ITEM);

            /*" -1904- MOVE V0SEG-OCORR-HIST TO V0CBA-OCOR-HIST. */
            _.Move(V0SEG_OCORR_HIST, V0CBA_OCOR_HIST);

            /*" -1905- IF V1REL-APOL-RAMO = V1PAR-RAMO-VG OR 97 */

            if (V1REL_APOL_RAMO.In(V1PAR_RAMO_VG.ToString(), "97"))
            {

                /*" -1907- MOVE V1PAR-RAMO-VG TO V0CBA-RAMOFR. */
                _.Move(V1PAR_RAMO_VG, V0CBA_RAMOFR);
            }


            /*" -1908- IF V1REL-APOL-RAMO = V1PAR-RAMO-PST */

            if (V1REL_APOL_RAMO == V1PAR_RAMO_PST)
            {

                /*" -1910- MOVE V1PAR-RAMO-PST TO V0CBA-RAMOFR. */
                _.Move(V1PAR_RAMO_PST, V0CBA_RAMOFR);
            }


            /*" -1912- MOVE 11 TO V0CBA-CD-COBERTURA. */
            _.Move(11, V0CBA_CD_COBERTURA);

            /*" -1914- PERFORM R0224-45-SELECT-V1COBERAPOL. */

            R0224_45_SELECT_V1COBERAPOL_SECTION();

            /*" -1915- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1917- MOVE 0 TO V0MOV-IMP-MORNATU V0MOV-PRM-VG */
                _.Move(0, V0MOV_IMP_MORNATU, V0MOV_PRM_VG);

                /*" -1918- ELSE */
            }
            else
            {


                /*" -1923- COMPUTE V0MOV-IMP-MORNATU ROUNDED = V0CBA-IMP-SEGURADA * V0CBA-FATOR-MULTIP * V0VLCRUZAD-IMP */
                V0MOV_IMP_MORNATU.Value = V0CBA_IMP_SEGURADA * V0CBA_FATOR_MULTIP * V0VLCRUZAD_IMP;

                /*" -1926- COMPUTE V0MOV-PRM-VG ROUNDED = V0CBA-PR-TARIFARIO * V0CBA-FATOR-MULTIP * V0VLCRUZAD-PRM. */
                V0MOV_PRM_VG.Value = V0CBA_PR_TARIFARIO * V0CBA_FATOR_MULTIP * V0VLCRUZAD_PRM;
            }


            /*" -0- FLUXCONTROL_PERFORM R0224_020_VERIFICA_PREMIO_AP */

            R0224_020_VERIFICA_PREMIO_AP();

        }

        [StopWatch]
        /*" R0224-020-VERIFICA-PREMIO-AP */
        private void R0224_020_VERIFICA_PREMIO_AP(bool isPerform = false)
        {
            /*" -1934- MOVE V1PAR-RAMO-AP TO V0CBA-RAMOFR. */
            _.Move(V1PAR_RAMO_AP, V0CBA_RAMOFR);

            /*" -1936- MOVE 1 TO V0CBA-CD-COBERTURA. */
            _.Move(1, V0CBA_CD_COBERTURA);

            /*" -1938- PERFORM R0224-46-SELECT-V1COBERAPOL. */

            R0224_46_SELECT_V1COBERAPOL_SECTION();

            /*" -1939- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1941- MOVE 0 TO V0MOV-IMP-MORACID V0MOV-PRM-AP */
                _.Move(0, V0MOV_IMP_MORACID, V0MOV_PRM_AP);

                /*" -1942- ELSE */
            }
            else
            {


                /*" -1947- COMPUTE V0MOV-IMP-MORACID ROUNDED = V0CBA-IMP-SEGURADA * V0CBA-FATOR-MULTIP * V0VLCRUZAD-IMP */
                V0MOV_IMP_MORACID.Value = V0CBA_IMP_SEGURADA * V0CBA_FATOR_MULTIP * V0VLCRUZAD_IMP;

                /*" -1952- COMPUTE V0MOV-PRM-AP ROUNDED = V0CBA-PR-TARIFARIO * V0CBA-FATOR-MULTIP * V0VLCRUZAD-PRM. */
                V0MOV_PRM_AP.Value = V0CBA_PR_TARIFARIO * V0CBA_FATOR_MULTIP * V0VLCRUZAD_PRM;
            }


            /*" -1952- PERFORM R0224-030-VERIFICA-INVPERM. */

            R0224_030_VERIFICA_INVPERM(true);

        }

        [StopWatch]
        /*" R0224-030-VERIFICA-INVPERM */
        private void R0224_030_VERIFICA_INVPERM(bool isPerform = false)
        {
            /*" -1960- MOVE 2 TO V0CBA-CD-COBERTURA. */
            _.Move(2, V0CBA_CD_COBERTURA);

            /*" -1962- PERFORM R0224-46-SELECT-V1COBERAPOL. */

            R0224_46_SELECT_V1COBERAPOL_SECTION();

            /*" -1963- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1964- MOVE 0 TO V0MOV-IMP-INVPERM */
                _.Move(0, V0MOV_IMP_INVPERM);

                /*" -1965- ELSE */
            }
            else
            {


                /*" -1970- COMPUTE V0MOV-IMP-INVPERM ROUNDED = V0CBA-IMP-SEGURADA * V0CBA-FATOR-MULTIP * V0VLCRUZAD-IMP. */
                V0MOV_IMP_INVPERM.Value = V0CBA_IMP_SEGURADA * V0CBA_FATOR_MULTIP * V0VLCRUZAD_IMP;
            }


            /*" -1970- PERFORM R0224-040-VERIFICA-AMDS. */

            R0224_040_VERIFICA_AMDS(true);

        }

        [StopWatch]
        /*" R0224-040-VERIFICA-AMDS */
        private void R0224_040_VERIFICA_AMDS(bool isPerform = false)
        {
            /*" -1978- MOVE 3 TO V0CBA-CD-COBERTURA. */
            _.Move(3, V0CBA_CD_COBERTURA);

            /*" -1980- PERFORM R0224-46-SELECT-V1COBERAPOL. */

            R0224_46_SELECT_V1COBERAPOL_SECTION();

            /*" -1981- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1982- MOVE 0 TO V0MOV-IMP-AMDS */
                _.Move(0, V0MOV_IMP_AMDS);

                /*" -1983- ELSE */
            }
            else
            {


                /*" -1988- COMPUTE V0MOV-IMP-AMDS ROUNDED = V0CBA-IMP-SEGURADA * V0CBA-FATOR-MULTIP * V0VLCRUZAD-IMP. */
                V0MOV_IMP_AMDS.Value = V0CBA_IMP_SEGURADA * V0CBA_FATOR_MULTIP * V0VLCRUZAD_IMP;
            }


            /*" -1988- PERFORM R0224-050-VERIFICA-DH. */

            R0224_050_VERIFICA_DH(true);

        }

        [StopWatch]
        /*" R0224-050-VERIFICA-DH */
        private void R0224_050_VERIFICA_DH(bool isPerform = false)
        {
            /*" -1996- MOVE 4 TO V0CBA-CD-COBERTURA. */
            _.Move(4, V0CBA_CD_COBERTURA);

            /*" -1998- PERFORM R0224-46-SELECT-V1COBERAPOL. */

            R0224_46_SELECT_V1COBERAPOL_SECTION();

            /*" -1999- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2000- MOVE 0 TO V0MOV-IMP-DH */
                _.Move(0, V0MOV_IMP_DH);

                /*" -2001- ELSE */
            }
            else
            {


                /*" -2006- COMPUTE V0MOV-IMP-DH ROUNDED = V0CBA-IMP-SEGURADA * V0CBA-FATOR-MULTIP * V0VLCRUZAD-IMP. */
                V0MOV_IMP_DH.Value = V0CBA_IMP_SEGURADA * V0CBA_FATOR_MULTIP * V0VLCRUZAD_IMP;
            }


            /*" -2006- PERFORM R0224-060-VERIFICA-DIT. */

            R0224_060_VERIFICA_DIT(true);

        }

        [StopWatch]
        /*" R0224-060-VERIFICA-DIT */
        private void R0224_060_VERIFICA_DIT(bool isPerform = false)
        {
            /*" -2014- MOVE 5 TO V0CBA-CD-COBERTURA. */
            _.Move(5, V0CBA_CD_COBERTURA);

            /*" -2016- PERFORM R0224-46-SELECT-V1COBERAPOL. */

            R0224_46_SELECT_V1COBERAPOL_SECTION();

            /*" -2017- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2018- MOVE 0 TO V0MOV-IMP-DIT */
                _.Move(0, V0MOV_IMP_DIT);

                /*" -2019- ELSE */
            }
            else
            {


                /*" -2022- COMPUTE V0MOV-IMP-DIT ROUNDED = V0CBA-IMP-SEGURADA * V0CBA-FATOR-MULTIP * V0VLCRUZAD-IMP. */
                V0MOV_IMP_DIT.Value = V0CBA_IMP_SEGURADA * V0CBA_FATOR_MULTIP * V0VLCRUZAD_IMP;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0224_40_EXIT*/

        [StopWatch]
        /*" R0224-45-SELECT-V1COBERAPOL-SECTION */
        private void R0224_45_SELECT_V1COBERAPOL_SECTION()
        {
            /*" -2039- MOVE 'R0224-45' TO WNR-EXEC-SQL. */
            _.Move("R0224-45", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2074- PERFORM R0224_45_SELECT_V1COBERAPOL_DB_SELECT_1 */

            R0224_45_SELECT_V1COBERAPOL_DB_SELECT_1();

            /*" -2078- IF SQLCODE EQUAL 100 NEXT SENTENCE */

            if (DB.SQLCODE == 100)
            {

                /*" -2079- ELSE */
            }
            else
            {


                /*" -2080- IF SQLCODE NOT EQUAL 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -2081- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -2082- DISPLAY 'R0224-45 - PROBLEMAS NO ACESSO V0COBERAPOL' */
                    _.Display($"R0224-45 - PROBLEMAS NO ACESSO V0COBERAPOL");

                    /*" -2083- DISPLAY 'APOLICE........   ' V0CBA-NUM-APOLICE */
                    _.Display($"APOLICE........   {V0CBA_NUM_APOLICE}");

                    /*" -2084- DISPLAY 'ITEM...........   ' V0CBA-NUM-ITEM */
                    _.Display($"ITEM...........   {V0CBA_NUM_ITEM}");

                    /*" -2085- DISPLAY 'OCORHIST.......   ' V0CBA-OCOR-HIST */
                    _.Display($"OCORHIST.......   {V0CBA_OCOR_HIST}");

                    /*" -2086- DISPLAY 'COBERTURA......   ' V0CBA-CD-COBERTURA */
                    _.Display($"COBERTURA......   {V0CBA_CD_COBERTURA}");

                    /*" -2087- DISPLAY 'RAMO...........   ' V0CBA-RAMOFR */
                    _.Display($"RAMO...........   {V0CBA_RAMOFR}");

                    /*" -2088- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -2090- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2092- MOVE 'PROBLEMAS NO ACESSO A VIEW V0COBERAPOL ' TO LD-DES-ERRO-SSAIDA */
                    _.Move("PROBLEMAS NO ACESSO A VIEW V0COBERAPOL ", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2093- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -2093- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0224-45-SELECT-V1COBERAPOL-DB-SELECT-1 */
        public void R0224_45_SELECT_V1COBERAPOL_DB_SELECT_1()
        {
            /*" -2074- EXEC SQL SELECT NUM_APOLICE, NRENDOS, NUM_ITEM, OCORHIST, RAMOFR, MODALIFR, COD_COBERTURA, IMP_SEGURADA_IX, PRM_TARIFARIO_IX, FATOR_MULTIPLICA, DATA_INIVIGENCIA INTO :V0CBA-NUM-APOLICE, :V0CBA-NRENDOS, :V0CBA-NUM-ITEM, :V0CBA-OCOR-HIST, :V0CBA-RAMOFR, :V0CBA-MODALIFR, :V0CBA-CD-COBERTURA, :V0CBA-IMP-SEGURADA, :V0CBA-PR-TARIFARIO, :V0CBA-FATOR-MULTIP, :V0CBA-DTINIVIG FROM SEGUROS.V1COBERAPOL WHERE NUM_APOLICE = :V0CBA-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0CBA-NUM-ITEM AND OCORHIST = :V0CBA-OCOR-HIST AND MODALIFR = 0 AND COD_COBERTURA = :V0CBA-CD-COBERTURA AND RAMOFR = :V0CBA-RAMOFR END-EXEC. */

            var r0224_45_SELECT_V1COBERAPOL_DB_SELECT_1_Query1 = new R0224_45_SELECT_V1COBERAPOL_DB_SELECT_1_Query1()
            {
                V0CBA_CD_COBERTURA = V0CBA_CD_COBERTURA.ToString(),
                V0CBA_NUM_APOLICE = V0CBA_NUM_APOLICE.ToString(),
                V0CBA_OCOR_HIST = V0CBA_OCOR_HIST.ToString(),
                V0CBA_NUM_ITEM = V0CBA_NUM_ITEM.ToString(),
                V0CBA_RAMOFR = V0CBA_RAMOFR.ToString(),
            };

            var executed_1 = R0224_45_SELECT_V1COBERAPOL_DB_SELECT_1_Query1.Execute(r0224_45_SELECT_V1COBERAPOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CBA_NUM_APOLICE, V0CBA_NUM_APOLICE);
                _.Move(executed_1.V0CBA_NRENDOS, V0CBA_NRENDOS);
                _.Move(executed_1.V0CBA_NUM_ITEM, V0CBA_NUM_ITEM);
                _.Move(executed_1.V0CBA_OCOR_HIST, V0CBA_OCOR_HIST);
                _.Move(executed_1.V0CBA_RAMOFR, V0CBA_RAMOFR);
                _.Move(executed_1.V0CBA_MODALIFR, V0CBA_MODALIFR);
                _.Move(executed_1.V0CBA_CD_COBERTURA, V0CBA_CD_COBERTURA);
                _.Move(executed_1.V0CBA_IMP_SEGURADA, V0CBA_IMP_SEGURADA);
                _.Move(executed_1.V0CBA_PR_TARIFARIO, V0CBA_PR_TARIFARIO);
                _.Move(executed_1.V0CBA_FATOR_MULTIP, V0CBA_FATOR_MULTIP);
                _.Move(executed_1.V0CBA_DTINIVIG, V0CBA_DTINIVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0224_45_SAIDA*/

        [StopWatch]
        /*" R0224-46-SELECT-V1COBERAPOL-SECTION */
        private void R0224_46_SELECT_V1COBERAPOL_SECTION()
        {
            /*" -2105- MOVE 'R0224-46' TO WNR-EXEC-SQL. */
            _.Move("R0224-46", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2140- PERFORM R0224_46_SELECT_V1COBERAPOL_DB_SELECT_1 */

            R0224_46_SELECT_V1COBERAPOL_DB_SELECT_1();

            /*" -2144- IF SQLCODE EQUAL 100 NEXT SENTENCE */

            if (DB.SQLCODE == 100)
            {

                /*" -2145- ELSE */
            }
            else
            {


                /*" -2146- IF SQLCODE NOT EQUAL 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -2147- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -2148- DISPLAY 'R0224-46 - PROBLEMAS NO ACESSO V0COBERAPOL' */
                    _.Display($"R0224-46 - PROBLEMAS NO ACESSO V0COBERAPOL");

                    /*" -2149- DISPLAY 'APOLICE........   ' V0CBA-NUM-APOLICE */
                    _.Display($"APOLICE........   {V0CBA_NUM_APOLICE}");

                    /*" -2150- DISPLAY 'ITEM...........   ' V0CBA-NUM-ITEM */
                    _.Display($"ITEM...........   {V0CBA_NUM_ITEM}");

                    /*" -2151- DISPLAY 'OCORHIST.......   ' V0CBA-OCOR-HIST */
                    _.Display($"OCORHIST.......   {V0CBA_OCOR_HIST}");

                    /*" -2152- DISPLAY 'COBERTURA......   ' V0CBA-CD-COBERTURA */
                    _.Display($"COBERTURA......   {V0CBA_CD_COBERTURA}");

                    /*" -2153- DISPLAY 'RAMO...........   ' V0CBA-RAMOFR */
                    _.Display($"RAMO...........   {V0CBA_RAMOFR}");

                    /*" -2154- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -2156- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2158- MOVE 'ERRO NO ACESSO A VIEW V0COBERAPOL' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO ACESSO A VIEW V0COBERAPOL", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2159- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -2159- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0224-46-SELECT-V1COBERAPOL-DB-SELECT-1 */
        public void R0224_46_SELECT_V1COBERAPOL_DB_SELECT_1()
        {
            /*" -2140- EXEC SQL SELECT NUM_APOLICE, NRENDOS, NUM_ITEM, OCORHIST, RAMOFR, MODALIFR, COD_COBERTURA, IMP_SEGURADA_IX, PRM_TARIFARIO_IX, FATOR_MULTIPLICA, DATA_INIVIGENCIA INTO :V0CBA-NUM-APOLICE, :V0CBA-NRENDOS, :V0CBA-NUM-ITEM, :V0CBA-OCOR-HIST, :V0CBA-RAMOFR, :V0CBA-MODALIFR, :V0CBA-CD-COBERTURA, :V0CBA-IMP-SEGURADA, :V0CBA-PR-TARIFARIO, :V0CBA-FATOR-MULTIP, :V0CBA-DTINIVIG FROM SEGUROS.V1COBERAPOL WHERE NUM_APOLICE = :V0CBA-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0CBA-NUM-ITEM AND OCORHIST = :V0CBA-OCOR-HIST AND MODALIFR = 0 AND COD_COBERTURA = :V0CBA-CD-COBERTURA AND RAMOFR IN (:V0CBA-RAMOFR, 81) END-EXEC. */

            var r0224_46_SELECT_V1COBERAPOL_DB_SELECT_1_Query1 = new R0224_46_SELECT_V1COBERAPOL_DB_SELECT_1_Query1()
            {
                V0CBA_CD_COBERTURA = V0CBA_CD_COBERTURA.ToString(),
                V0CBA_NUM_APOLICE = V0CBA_NUM_APOLICE.ToString(),
                V0CBA_OCOR_HIST = V0CBA_OCOR_HIST.ToString(),
                V0CBA_NUM_ITEM = V0CBA_NUM_ITEM.ToString(),
                V0CBA_RAMOFR = V0CBA_RAMOFR.ToString(),
            };

            var executed_1 = R0224_46_SELECT_V1COBERAPOL_DB_SELECT_1_Query1.Execute(r0224_46_SELECT_V1COBERAPOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CBA_NUM_APOLICE, V0CBA_NUM_APOLICE);
                _.Move(executed_1.V0CBA_NRENDOS, V0CBA_NRENDOS);
                _.Move(executed_1.V0CBA_NUM_ITEM, V0CBA_NUM_ITEM);
                _.Move(executed_1.V0CBA_OCOR_HIST, V0CBA_OCOR_HIST);
                _.Move(executed_1.V0CBA_RAMOFR, V0CBA_RAMOFR);
                _.Move(executed_1.V0CBA_MODALIFR, V0CBA_MODALIFR);
                _.Move(executed_1.V0CBA_CD_COBERTURA, V0CBA_CD_COBERTURA);
                _.Move(executed_1.V0CBA_IMP_SEGURADA, V0CBA_IMP_SEGURADA);
                _.Move(executed_1.V0CBA_PR_TARIFARIO, V0CBA_PR_TARIFARIO);
                _.Move(executed_1.V0CBA_FATOR_MULTIP, V0CBA_FATOR_MULTIP);
                _.Move(executed_1.V0CBA_DTINIVIG, V0CBA_DTINIVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0224_46_SAIDA*/

        [StopWatch]
        /*" R0224-50-OBTER-CONTA-CORR-SECTION */
        private void R0224_50_OBTER_CONTA_CORR_SECTION()
        {
            /*" -2173- MOVE 'R0224-50' TO WNR-EXEC-SQL. */
            _.Move("R0224-50", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2174- MOVE V0SEG-COD-CLIENTE TO V0CTAC-COD-CLIENTE. */
            _.Move(V0SEG_COD_CLIENTE, V0CTAC_COD_CLIENTE);

            /*" -2176- MOVE V0SEG-NUM-APOL TO V0CTAC-NUM-APOLICE. */
            _.Move(V0SEG_NUM_APOL, V0CTAC_NUM_APOLICE);

            /*" -2192- PERFORM R0224_50_OBTER_CONTA_CORR_DB_SELECT_1 */

            R0224_50_OBTER_CONTA_CORR_DB_SELECT_1();

            /*" -2195- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2196- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2197- MOVE 0 TO V0CTAC-NUM-CTA-COR */
                    _.Move(0, V0CTAC_NUM_CTA_COR);

                    /*" -2198- MOVE ' ' TO V0CTAC-DAC-CTA-COR */
                    _.Move(" ", V0CTAC_DAC_CTA_COR);

                    /*" -2199- ELSE */
                }
                else
                {


                    /*" -2200- DISPLAY 'VG0031B - PROBLEMAS NO ACESSO V1CONTACOR' */
                    _.Display($"VG0031B - PROBLEMAS NO ACESSO V1CONTACOR");

                    /*" -2201- DISPLAY 'APOLICE.........   ' V0CTAC-NUM-APOLICE */
                    _.Display($"APOLICE.........   {V0CTAC_NUM_APOLICE}");

                    /*" -2202- DISPLAY 'CLIENTE.........   ' V0CTAC-COD-CLIENTE */
                    _.Display($"CLIENTE.........   {V0CTAC_COD_CLIENTE}");

                    /*" -2203- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -2205- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2207- MOVE 'ERRO NO ACESSO A VIEW V1CONTACOR' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO ACESSO A VIEW V1CONTACOR", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2208- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -2208- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0224-50-OBTER-CONTA-CORR-DB-SELECT-1 */
        public void R0224_50_OBTER_CONTA_CORR_DB_SELECT_1()
        {
            /*" -2192- EXEC SQL SELECT COD_CLIENTE, NUM_APOLICE, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE INTO :V0CTAC-COD-CLIENTE, :V0CTAC-NUM-APOLICE, :V0CTAC-NUM-CTA-COR, :V0CTAC-DAC-CTA-COR FROM SEGUROS.V1CONTACOR WHERE NUM_CERTIFICADO = :V0SEG-NUM-CERTIF END-EXEC. */

            var r0224_50_OBTER_CONTA_CORR_DB_SELECT_1_Query1 = new R0224_50_OBTER_CONTA_CORR_DB_SELECT_1_Query1()
            {
                V0SEG_NUM_CERTIF = V0SEG_NUM_CERTIF.ToString(),
            };

            var executed_1 = R0224_50_OBTER_CONTA_CORR_DB_SELECT_1_Query1.Execute(r0224_50_OBTER_CONTA_CORR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CTAC_COD_CLIENTE, V0CTAC_COD_CLIENTE);
                _.Move(executed_1.V0CTAC_NUM_APOLICE, V0CTAC_NUM_APOLICE);
                _.Move(executed_1.V0CTAC_NUM_CTA_COR, V0CTAC_NUM_CTA_COR);
                _.Move(executed_1.V0CTAC_DAC_CTA_COR, V0CTAC_DAC_CTA_COR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0244_50_SAIDA*/

        [StopWatch]
        /*" R0224-55-CANCELA-SEGURADO-SECTION */
        private void R0224_55_CANCELA_SEGURADO_SECTION()
        {
            /*" -2220- MOVE 'R0224-55' TO WNR-EXEC-SQL. */
            _.Move("R0224-55", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2221- IF WLOT-EMP-SEGURADO LESS ZEROS */

            if (WLOT_EMP_SEGURADO < 00)
            {

                /*" -2223- MOVE SPACES TO V0SEG-LOT-EMP-SEGURADO. */
                _.Move("", V0SEG_LOT_EMP_SEGURADO);
            }


            /*" -2300- PERFORM R0224_55_CANCELA_SEGURADO_DB_INSERT_1 */

            R0224_55_CANCELA_SEGURADO_DB_INSERT_1();

            /*" -2304- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2305- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -2306- PERFORM R0224-25-OBTER-NUM-PROPOSTA */

                    R0224_25_OBTER_NUM_PROPOSTA_SECTION();

                    /*" -2307- GO TO R0224-55-CANCELA-SEGURADO */
                    new Task(() => R0224_55_CANCELA_SEGURADO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2308- ELSE */
                }
                else
                {


                    /*" -2309- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -2310- DISPLAY 'R0224-55 - PROBLEMAS NO INSERT V0MOVIMENTO' */
                    _.Display($"R0224-55 - PROBLEMAS NO INSERT V0MOVIMENTO");

                    /*" -2311- DISPLAY '           APOLICE.........  ' V0SEG-NUM-APOL */
                    _.Display($"           APOLICE.........  {V0SEG_NUM_APOL}");

                    /*" -2312- DISPLAY '           SUBGRUPO........  ' V0SEG-COD-SUBG */
                    _.Display($"           SUBGRUPO........  {V0SEG_COD_SUBG}");

                    /*" -2313- DISPLAY '           FONTE...........  ' V0SEG-COD-FONTE */
                    _.Display($"           FONTE...........  {V0SEG_COD_FONTE}");

                    /*" -2314- DISPLAY '           CERTIFICADO.....  ' V0SEG-NUM-CERTIF */
                    _.Display($"           CERTIFICADO.....  {V0SEG_NUM_CERTIF}");

                    /*" -2315- DISPLAY '           SQLCODE.........  ' SQLCODE */
                    _.Display($"           SQLCODE.........  {DB.SQLCODE}");

                    /*" -2316- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -2318- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2320- MOVE 'ERRO NO INSERT DA VIEW V0MOVIMENTO' TO LD-DES-ERRO-DSAIDA */
                    _.Move("ERRO NO INSERT DA VIEW V0MOVIMENTO", AREA_DE_WORK.LD_REG_DSAIDA.LD_DES_ERRO_DSAIDA);

                    /*" -2321- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -2322- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2323- ELSE */
                }

            }
            else
            {


                /*" -2323- ADD 1 TO AC-I-V0SEGURAVG. */
                AREA_DE_WORK.AC_I_V0SEGURAVG.Value = AREA_DE_WORK.AC_I_V0SEGURAVG + 1;
            }


        }

        [StopWatch]
        /*" R0224-55-CANCELA-SEGURADO-DB-INSERT-1 */
        public void R0224_55_CANCELA_SEGURADO_DB_INSERT_1()
        {
            /*" -2300- EXEC SQL INSERT INTO SEGUROS.V0MOVIMENTO VALUES (:V0SEG-NUM-APOL, :V0SEG-COD-SUBG, :V0SEG-COD-FONTE, :V0FONTE-PROPAUTOM, :V0SEG-TP-SEGURADO, :V0SEG-NUM-CERTIF, :V0SEG-DAC-CERTIF, :V0SEG-TP-INCLUSAO, :V0SEG-COD-CLIENTE, :V0SEG-AGENCIADOR, :V0SEG-CORRETOR, :V0SEG-CD-PLANOVGAP, :V0SEG-CD-PLANOAP, :V0SEG-FAIXA, :V0SEG-AUT-AUM-AUT, :V0SEG-TP-BENEFICIA, :V0SEG-PERI-PGTO, :V0SEG-PERI-RENOVA, :V0SEG-COD-OCUPACAO, :V0SEG-EST-CIVIL, :V0SEG-SEXO, :V0SEG-CD-PROFISSAO, :V0SEG-NATURALIDADE, :V0SEG-OCOR-ENDERE, :V0SEG-OCOR-END-COB, :V0SEG-BCO-COBRANCA, :V0SEG-AGE-COBRANCA, :V0SEG-DAC-COBRANCA, :V0SEG-NUM-MATRIC, :V0CTAC-NUM-CTA-COR, :V0CTAC-DAC-CTA-COR, :V0SEG-VAL-SALARIO, :V0SEG-TP-SALARIO, :V0SEG-TP-PLANO, :V0SEG-PCT-CONJ-VG, :V0SEG-PCT-CONJ-AP, :V0SEG-QTD-S-MONATU, :V0SEG-QTD-S-MOACID, :V0SEG-QTD-S-INVPER, :V0SEG-TX-AP-MOACID, :V0SEG-TX-AP-INVPER, :V0SEG-TX-AP-AMDS, :V0SEG-TX-AP-DH, :V0SEG-TX-AP-DIT, :V0SEG-TAXA-VG, :V0MOV-IMP-MORNATU, :V0MOV-IMP-MORNATU, :V0MOV-IMP-MORACID, :V0MOV-IMP-MORACID, :V0MOV-IMP-INVPERM, :V0MOV-IMP-INVPERM, :V0MOV-IMP-AMDS, :V0MOV-IMP-AMDS, :V0MOV-IMP-DH, :V0MOV-IMP-DH, :V0MOV-IMP-DIT, :V0MOV-IMP-DIT, :V0MOV-PRM-VG, :V0MOV-PRM-VG, :V0MOV-PRM-AP, :V0MOV-PRM-AP, 409, :V1SIST-DTMOVABE, 0, '0' , 'VG0031B' , :V1SIST-DTMOVABE, :V0SEG-DT-ADMISSAO:VIND-DT-ADMISSAO, NULL, :V0SEG-DT-NASCI:VIND-DT-NASCI, NULL, :V1FATC-DT-REFER, :V1SIST-DTMOVABE, NULL, :V0SEG-LOT-EMP-SEGURADO) END-EXEC. */

            var r0224_55_CANCELA_SEGURADO_DB_INSERT_1_Insert1 = new R0224_55_CANCELA_SEGURADO_DB_INSERT_1_Insert1()
            {
                V0SEG_NUM_APOL = V0SEG_NUM_APOL.ToString(),
                V0SEG_COD_SUBG = V0SEG_COD_SUBG.ToString(),
                V0SEG_COD_FONTE = V0SEG_COD_FONTE.ToString(),
                V0FONTE_PROPAUTOM = V0FONTE_PROPAUTOM.ToString(),
                V0SEG_TP_SEGURADO = V0SEG_TP_SEGURADO.ToString(),
                V0SEG_NUM_CERTIF = V0SEG_NUM_CERTIF.ToString(),
                V0SEG_DAC_CERTIF = V0SEG_DAC_CERTIF.ToString(),
                V0SEG_TP_INCLUSAO = V0SEG_TP_INCLUSAO.ToString(),
                V0SEG_COD_CLIENTE = V0SEG_COD_CLIENTE.ToString(),
                V0SEG_AGENCIADOR = V0SEG_AGENCIADOR.ToString(),
                V0SEG_CORRETOR = V0SEG_CORRETOR.ToString(),
                V0SEG_CD_PLANOVGAP = V0SEG_CD_PLANOVGAP.ToString(),
                V0SEG_CD_PLANOAP = V0SEG_CD_PLANOAP.ToString(),
                V0SEG_FAIXA = V0SEG_FAIXA.ToString(),
                V0SEG_AUT_AUM_AUT = V0SEG_AUT_AUM_AUT.ToString(),
                V0SEG_TP_BENEFICIA = V0SEG_TP_BENEFICIA.ToString(),
                V0SEG_PERI_PGTO = V0SEG_PERI_PGTO.ToString(),
                V0SEG_PERI_RENOVA = V0SEG_PERI_RENOVA.ToString(),
                V0SEG_COD_OCUPACAO = V0SEG_COD_OCUPACAO.ToString(),
                V0SEG_EST_CIVIL = V0SEG_EST_CIVIL.ToString(),
                V0SEG_SEXO = V0SEG_SEXO.ToString(),
                V0SEG_CD_PROFISSAO = V0SEG_CD_PROFISSAO.ToString(),
                V0SEG_NATURALIDADE = V0SEG_NATURALIDADE.ToString(),
                V0SEG_OCOR_ENDERE = V0SEG_OCOR_ENDERE.ToString(),
                V0SEG_OCOR_END_COB = V0SEG_OCOR_END_COB.ToString(),
                V0SEG_BCO_COBRANCA = V0SEG_BCO_COBRANCA.ToString(),
                V0SEG_AGE_COBRANCA = V0SEG_AGE_COBRANCA.ToString(),
                V0SEG_DAC_COBRANCA = V0SEG_DAC_COBRANCA.ToString(),
                V0SEG_NUM_MATRIC = V0SEG_NUM_MATRIC.ToString(),
                V0CTAC_NUM_CTA_COR = V0CTAC_NUM_CTA_COR.ToString(),
                V0CTAC_DAC_CTA_COR = V0CTAC_DAC_CTA_COR.ToString(),
                V0SEG_VAL_SALARIO = V0SEG_VAL_SALARIO.ToString(),
                V0SEG_TP_SALARIO = V0SEG_TP_SALARIO.ToString(),
                V0SEG_TP_PLANO = V0SEG_TP_PLANO.ToString(),
                V0SEG_PCT_CONJ_VG = V0SEG_PCT_CONJ_VG.ToString(),
                V0SEG_PCT_CONJ_AP = V0SEG_PCT_CONJ_AP.ToString(),
                V0SEG_QTD_S_MONATU = V0SEG_QTD_S_MONATU.ToString(),
                V0SEG_QTD_S_MOACID = V0SEG_QTD_S_MOACID.ToString(),
                V0SEG_QTD_S_INVPER = V0SEG_QTD_S_INVPER.ToString(),
                V0SEG_TX_AP_MOACID = V0SEG_TX_AP_MOACID.ToString(),
                V0SEG_TX_AP_INVPER = V0SEG_TX_AP_INVPER.ToString(),
                V0SEG_TX_AP_AMDS = V0SEG_TX_AP_AMDS.ToString(),
                V0SEG_TX_AP_DH = V0SEG_TX_AP_DH.ToString(),
                V0SEG_TX_AP_DIT = V0SEG_TX_AP_DIT.ToString(),
                V0SEG_TAXA_VG = V0SEG_TAXA_VG.ToString(),
                V0MOV_IMP_MORNATU = V0MOV_IMP_MORNATU.ToString(),
                V0MOV_IMP_MORACID = V0MOV_IMP_MORACID.ToString(),
                V0MOV_IMP_INVPERM = V0MOV_IMP_INVPERM.ToString(),
                V0MOV_IMP_AMDS = V0MOV_IMP_AMDS.ToString(),
                V0MOV_IMP_DH = V0MOV_IMP_DH.ToString(),
                V0MOV_IMP_DIT = V0MOV_IMP_DIT.ToString(),
                V0MOV_PRM_VG = V0MOV_PRM_VG.ToString(),
                V0MOV_PRM_AP = V0MOV_PRM_AP.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0SEG_DT_ADMISSAO = V0SEG_DT_ADMISSAO.ToString(),
                VIND_DT_ADMISSAO = VIND_DT_ADMISSAO.ToString(),
                V0SEG_DT_NASCI = V0SEG_DT_NASCI.ToString(),
                VIND_DT_NASCI = VIND_DT_NASCI.ToString(),
                V1FATC_DT_REFER = V1FATC_DT_REFER.ToString(),
                V0SEG_LOT_EMP_SEGURADO = V0SEG_LOT_EMP_SEGURADO.ToString(),
            };

            R0224_55_CANCELA_SEGURADO_DB_INSERT_1_Insert1.Execute(r0224_55_CANCELA_SEGURADO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0224_55_SAIDA*/

        [StopWatch]
        /*" R0230-00-CANCELA-PENDENTE-SECTION */
        private void R0230_00_CANCELA_PENDENTE_SECTION()
        {
            /*" -2333- MOVE 'R0230-00' TO WNR-EXEC-SQL. */
            _.Move("R0230-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2335- MOVE SPACES TO WFIM-V1ENDOSSO. */
            _.Move("", AREA_DE_WORK.WFIM_V1ENDOSSO);

            /*" -2337- PERFORM R0230-05-DECLER-V1ENDOSSO */

            R0230_05_DECLER_V1ENDOSSO_SECTION();

            /*" -2339- PERFORM R0230-10-FETCH-V1ENDOSSO */

            R0230_10_FETCH_V1ENDOSSO_SECTION();

            /*" -2340- PERFORM R0230-15-PROCESSA-V1ENDOSSO UNTIL WFIM-V1ENDOSSO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1ENDOSSO.IsEmpty()))
            {

                R0230_15_PROCESSA_V1ENDOSSO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_00_SAIDA*/

        [StopWatch]
        /*" R0230-05-DECLER-V1ENDOSSO-SECTION */
        private void R0230_05_DECLER_V1ENDOSSO_SECTION()
        {
            /*" -2352- MOVE 'R0230-05' TO WNR-EXEC-SQL. */
            _.Move("R0230-05", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2377- PERFORM R0230_05_DECLER_V1ENDOSSO_DB_DECLARE_1 */

            R0230_05_DECLER_V1ENDOSSO_DB_DECLARE_1();

            /*" -2379- PERFORM R0230_05_DECLER_V1ENDOSSO_DB_OPEN_1 */

            R0230_05_DECLER_V1ENDOSSO_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0230-05-DECLER-V1ENDOSSO-DB-OPEN-1 */
        public void R0230_05_DECLER_V1ENDOSSO_DB_OPEN_1()
        {
            /*" -2379- EXEC SQL OPEN V1ENDOSSO END-EXEC. */

            V1ENDOSSO.Open();

        }

        [StopWatch]
        /*" R0230-20-DECLARE-V1PARCELA-DB-DECLARE-1 */
        public void R0230_20_DECLARE_V1PARCELA_DB_DECLARE_1()
        {
            /*" -2499- EXEC SQL DECLARE V1PARCELA CURSOR FOR SELECT NUM_APOLICE , NRENDOS , NRPARCEL , DACPARC , FONTE , NRTIT , OCORHIST , QTDDOC , SITUACAO , COD_EMPRESA FROM SEGUROS.V1PARCELA WHERE NUM_APOLICE = :V1ENDO-NUM-APOL AND NRENDOS = :V1ENDO-NRENDOS ORDER BY NUM_APOLICE, NRENDOS, NRPARCEL END-EXEC. */
            V1PARCELA = new VG0031B_V1PARCELA(true);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_05_SAIDA*/

        [StopWatch]
        /*" R0230-10-FETCH-V1ENDOSSO-SECTION */
        private void R0230_10_FETCH_V1ENDOSSO_SECTION()
        {
            /*" -2391- MOVE 'R0230-10' TO WNR-EXEC-SQL. */
            _.Move("R0230-10", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2407- PERFORM R0230_10_FETCH_V1ENDOSSO_DB_FETCH_1 */

            R0230_10_FETCH_V1ENDOSSO_DB_FETCH_1();

            /*" -2410- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2411- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2412- MOVE 'S' TO WFIM-V1ENDOSSO */
                    _.Move("S", AREA_DE_WORK.WFIM_V1ENDOSSO);

                    /*" -2412- PERFORM R0230_10_FETCH_V1ENDOSSO_DB_CLOSE_1 */

                    R0230_10_FETCH_V1ENDOSSO_DB_CLOSE_1();

                    /*" -2414- ELSE */
                }
                else
                {


                    /*" -2415- DISPLAY 'R0230-10- PROBLEMAS FETCH V1ENDOSSO.... ' */
                    _.Display($"R0230-10- PROBLEMAS FETCH V1ENDOSSO.... ");

                    /*" -2416- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -2418- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2420- MOVE 'ERRO NO FETCH DO CURSOR DA V1ENDOSSO' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO FETCH DO CURSOR DA V1ENDOSSO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2421- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -2422- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2423- ELSE */
                }

            }
            else
            {


                /*" -2426- ADD 1 TO AC-L-V1ENDOSSO. */
                AREA_DE_WORK.AC_L_V1ENDOSSO.Value = AREA_DE_WORK.AC_L_V1ENDOSSO + 1;
            }


            /*" -2427- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2428- IF VIND-COD-PRODU LESS ZEROS */

                if (VIND_COD_PRODU < 00)
                {

                    /*" -2428- MOVE ZEROS TO V1ENDO-CODPRODU. */
                    _.Move(0, V1ENDO_CODPRODU);
                }

            }


        }

        [StopWatch]
        /*" R0230-10-FETCH-V1ENDOSSO-DB-FETCH-1 */
        public void R0230_10_FETCH_V1ENDOSSO_DB_FETCH_1()
        {
            /*" -2407- EXEC SQL FETCH V1ENDOSSO INTO :V1ENDO-NUM-APOL, :V1ENDO-NRENDOS, :V1ENDO-DTEMIS , :V1ENDO-DTINIVIG , :V1ENDO-DTTERVIG , :V1ENDO-BCORCAP , :V1ENDO-AGERCAP , :V1ENDO-DACRCAP , :V1ENDO-BCOCOBR , :V1ENDO-AGECOBR , :V1ENDO-DACCOBR , :V1ENDO-QTPARCEL , :V1ENDO-ORGAO , :V1ENDO-RAMO , :V1ENDO-CODPRODU:VIND-COD-PRODU END-EXEC. */

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
        /*" R0230-10-FETCH-V1ENDOSSO-DB-CLOSE-1 */
        public void R0230_10_FETCH_V1ENDOSSO_DB_CLOSE_1()
        {
            /*" -2412- EXEC SQL CLOSE V1ENDOSSO END-EXEC */

            V1ENDOSSO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_10_SAIDA*/

        [StopWatch]
        /*" R0230-15-PROCESSA-V1ENDOSSO-SECTION */
        private void R0230_15_PROCESSA_V1ENDOSSO_SECTION()
        {
            /*" -2440- MOVE 'R0230-15' TO WNR-EXEC-SQL. */
            _.Move("R0230-15", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2442- MOVE SPACES TO WFIM-V1PARCELA. */
            _.Move("", AREA_DE_WORK.WFIM_V1PARCELA);

            /*" -2444- PERFORM R0230-20-DECLARE-V1PARCELA */

            R0230_20_DECLARE_V1PARCELA_SECTION();

            /*" -2446- PERFORM R0230-25-FETCH-V1PARCELA */

            R0230_25_FETCH_V1PARCELA_SECTION();

            /*" -2447- IF WFIM-V1PARCELA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1PARCELA.IsEmpty())
            {

                /*" -2448- DISPLAY '*------ VG0031B -- FIM ANORMAL ---------------*' */
                _.Display($"*------ VG0031B -- FIM ANORMAL ---------------*");

                /*" -2449- DISPLAY '*  NAO EXISTE PARCELA PENDENTE DE BAIXA, PARA O' */
                _.Display($"*  NAO EXISTE PARCELA PENDENTE DE BAIXA, PARA O");

                /*" -2450- DISPLAY '*  REFERIDO ENDOSSO.' */
                _.Display($"*  REFERIDO ENDOSSO.");

                /*" -2451- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -2452- DISPLAY '*- APOLICE .................  ' V0SUBG-NUM-APOL */
                _.Display($"*- APOLICE .................  {V0SUBG_NUM_APOL}");

                /*" -2453- DISPLAY '*- SUBGRUPO.................  ' V0SUBG-COD-SUBG */
                _.Display($"*- SUBGRUPO.................  {V0SUBG_COD_SUBG}");

                /*" -2454- DISPLAY '*- ENDOSSO..................  ' V1PARC-NRENDOS */
                _.Display($"*- ENDOSSO..................  {V1PARC_NRENDOS}");

                /*" -2455- DISPLAY '*- PARCELA..................  ' V1PARC-NRPARCEL */
                _.Display($"*- PARCELA..................  {V1PARC_NRPARCEL}");

                /*" -2456- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -2457- PERFORM R0450-00-LIMPA-REGISTROS */

                R0450_00_LIMPA_REGISTROS_SECTION();

                /*" -2459- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2461- MOVE 'ENDOSSO SEM PARCELA PENDENTE DE BAIXA ' TO LD-DES-ERRO-SSAIDA */
                _.Move("ENDOSSO SEM PARCELA PENDENTE DE BAIXA ", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2462- PERFORM R0460-00-GRAVA-REGISTROS */

                R0460_00_GRAVA_REGISTROS_SECTION();

                /*" -2464- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2466- MOVE CH-CHAVE-ATU TO CH-CHAVE-ANT */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU, AREA_DE_WORK.CH_CHAVE_ANT);

            /*" -2469- PERFORM R0230-30-PROCESSA-REGISTRO UNTIL WFIM-V1PARCELA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1PARCELA.IsEmpty()))
            {

                R0230_30_PROCESSA_REGISTRO_SECTION();
            }

            /*" -2469- PERFORM R0230-10-FETCH-V1ENDOSSO. */

            R0230_10_FETCH_V1ENDOSSO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_15_SAIDA*/

        [StopWatch]
        /*" R0230-20-DECLARE-V1PARCELA-SECTION */
        private void R0230_20_DECLARE_V1PARCELA_SECTION()
        {
            /*" -2481- MOVE 'R0230-20' TO WNR-EXEC-SQL. */
            _.Move("R0230-20", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2499- PERFORM R0230_20_DECLARE_V1PARCELA_DB_DECLARE_1 */

            R0230_20_DECLARE_V1PARCELA_DB_DECLARE_1();

            /*" -2501- PERFORM R0230_20_DECLARE_V1PARCELA_DB_OPEN_1 */

            R0230_20_DECLARE_V1PARCELA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0230-20-DECLARE-V1PARCELA-DB-OPEN-1 */
        public void R0230_20_DECLARE_V1PARCELA_DB_OPEN_1()
        {
            /*" -2501- EXEC SQL OPEN V1PARCELA END-EXEC. */

            V1PARCELA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_20_SAIDA*/

        [StopWatch]
        /*" R0230-25-FETCH-V1PARCELA-SECTION */
        private void R0230_25_FETCH_V1PARCELA_SECTION()
        {
            /*" -2513- MOVE 'R0230-25' TO WNR-EXEC-SQL. */
            _.Move("R0230-25", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2524- PERFORM R0230_25_FETCH_V1PARCELA_DB_FETCH_1 */

            R0230_25_FETCH_V1PARCELA_DB_FETCH_1();

            /*" -2527- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2528- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2529- MOVE 'S' TO WFIM-V1PARCELA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1PARCELA);

                    /*" -2530- MOVE SPACES TO CH-CHAVE-ATU */
                    _.Move("", AREA_DE_WORK.CH_CHAVE_ATU);

                    /*" -2530- PERFORM R0230_25_FETCH_V1PARCELA_DB_CLOSE_1 */

                    R0230_25_FETCH_V1PARCELA_DB_CLOSE_1();

                    /*" -2532- GO TO R0230-25-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_25_SAIDA*/ //GOTO
                    return;

                    /*" -2533- ELSE */
                }
                else
                {


                    /*" -2534- DISPLAY 'R0230-25 PROBLEMAS FETCH V1PARCELA ... ' */
                    _.Display($"R0230-25 PROBLEMAS FETCH V1PARCELA ... ");

                    /*" -2535- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -2537- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2539- MOVE 'ERRO NO FETCH DO CURSOR DA V1PARCELA' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO FETCH DO CURSOR DA V1PARCELA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2540- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -2543- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2544- IF V1PARC-SITUACAO NOT EQUAL '0' */

            if (V1PARC_SITUACAO != "0")
            {

                /*" -2545- MOVE 'S' TO WFIM-V1PARCELA */
                _.Move("S", AREA_DE_WORK.WFIM_V1PARCELA);

                /*" -2545- PERFORM R0230_25_FETCH_V1PARCELA_DB_CLOSE_2 */

                R0230_25_FETCH_V1PARCELA_DB_CLOSE_2();

                /*" -2547- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -2548- DISPLAY '*------ VG0031B -- PARCELA DESPRESADA  -------*' */
                _.Display($"*------ VG0031B -- PARCELA DESPRESADA  -------*");

                /*" -2549- DISPLAY '*- PARCELA PENDENTE NA V0ENDOSSO E, PAGA  OU -*' */
                _.Display($"*- PARCELA PENDENTE NA V0ENDOSSO E, PAGA  OU -*");

                /*" -2550- DISPLAY '*- CANCELADA NA V0PARCELA.                   -*' */
                _.Display($"*- CANCELADA NA V0PARCELA.                   -*");

                /*" -2551- DISPLAY '*- APOLICE .................  ' V0SUBG-NUM-APOL */
                _.Display($"*- APOLICE .................  {V0SUBG_NUM_APOL}");

                /*" -2552- DISPLAY '*- SUBGRUPO.................  ' V0SUBG-COD-SUBG */
                _.Display($"*- SUBGRUPO.................  {V0SUBG_COD_SUBG}");

                /*" -2553- DISPLAY '*- ENDOSSO..................  ' V1ENDO-NRENDOS */
                _.Display($"*- ENDOSSO..................  {V1ENDO_NRENDOS}");

                /*" -2554- DISPLAY '*- PARCELA..................  ' V1PARC-NRPARCEL */
                _.Display($"*- PARCELA..................  {V1PARC_NRPARCEL}");

                /*" -2555- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -2556- PERFORM R0450-00-LIMPA-REGISTROS */

                R0450_00_LIMPA_REGISTROS_SECTION();

                /*" -2558- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2560- MOVE 'PARCELA DESPREZADA PARA CANCELAMENTO ' TO LD-DES-ERRO-DSAIDA */
                _.Move("PARCELA DESPREZADA PARA CANCELAMENTO ", AREA_DE_WORK.LD_REG_DSAIDA.LD_DES_ERRO_DSAIDA);

                /*" -2561- PERFORM R0460-00-GRAVA-REGISTROS */

                R0460_00_GRAVA_REGISTROS_SECTION();

                /*" -2563- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2564- MOVE V1PARC-NUM-APOL TO CH-APOLI-ATU */
            _.Move(V1PARC_NUM_APOL, AREA_DE_WORK.CH_CHAVE_ATU.CH_APOLI_ATU);

            /*" -2566- MOVE V1PARC-NRENDOS TO CH-ENDOS-ATU */
            _.Move(V1PARC_NRENDOS, AREA_DE_WORK.CH_CHAVE_ATU.CH_ENDOS_ATU);

            /*" -2566- ADD 1 TO AC-L-V1PARCELA. */
            AREA_DE_WORK.AC_L_V1PARCELA.Value = AREA_DE_WORK.AC_L_V1PARCELA + 1;

        }

        [StopWatch]
        /*" R0230-25-FETCH-V1PARCELA-DB-FETCH-1 */
        public void R0230_25_FETCH_V1PARCELA_DB_FETCH_1()
        {
            /*" -2524- EXEC SQL FETCH V1PARCELA INTO :V1PARC-NUM-APOL , :V1PARC-NRENDOS , :V1PARC-NRPARCEL , :V1PARC-DACPARC , :V1PARC-FONTE , :V1PARC-NRTIT , :V1PARC-OCORHIST , :V1PARC-QTDDOC , :V1PARC-SITUACAO, :V1PARC-COD-EMP:VIND-COD-EMP END-EXEC. */

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
        /*" R0230-25-FETCH-V1PARCELA-DB-CLOSE-1 */
        public void R0230_25_FETCH_V1PARCELA_DB_CLOSE_1()
        {
            /*" -2530- EXEC SQL CLOSE V1PARCELA END-EXEC */

            V1PARCELA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_25_SAIDA*/

        [StopWatch]
        /*" R0230-25-FETCH-V1PARCELA-DB-CLOSE-2 */
        public void R0230_25_FETCH_V1PARCELA_DB_CLOSE_2()
        {
            /*" -2545- EXEC SQL CLOSE V1PARCELA END-EXEC */

            V1PARCELA.Close();

        }

        [StopWatch]
        /*" R0230-30-PROCESSA-REGISTRO-SECTION */
        private void R0230_30_PROCESSA_REGISTRO_SECTION()
        {
            /*" -2580- MOVE 'R0230-30' TO WNR-EXEC-SQL. */
            _.Move("R0230-30", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2581- PERFORM R0230-35-SELECT-NUMERO-AES */

            R0230_35_SELECT_NUMERO_AES_SECTION();

            /*" -2582- MOVE V0NAES-NRENDOCA TO W0NAES-NRENDOCA */
            _.Move(V0NAES_NRENDOCA, W0NAES_NRENDOCA);

            /*" -2583- ADD 1 TO W0NAES-NRENDOCA */
            W0NAES_NRENDOCA.Value = W0NAES_NRENDOCA + 1;

            /*" -2584- MOVE W0NAES-NRENDOCA TO V0NAES-NRENDOCA */
            _.Move(W0NAES_NRENDOCA, V0NAES_NRENDOCA);

            /*" -2586- PERFORM R0230-40-UPDATE-NUMERO-AES */

            R0230_40_UPDATE_NUMERO_AES_SECTION();

            /*" -2588- MOVE SPACES TO WHOUVE-CANCELA */
            _.Move("", AREA_DE_WORK.WHOUVE_CANCELA);

            /*" -2590- PERFORM R0230-45-CANCELAMENTO */

            R0230_45_CANCELAMENTO_SECTION();

            /*" -2591- IF WHOUVE-CANCELA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WHOUVE_CANCELA.IsEmpty())
            {

                /*" -2595- PERFORM R0230-80-UPDATE-V0ENDOSSO. */

                R0230_80_UPDATE_V0ENDOSSO_SECTION();
            }


            /*" -2600- PERFORM R0230-25-FETCH-V1PARCELA UNTIL CH-CHAVE-ATU NOT EQUAL CH-CHAVE-ANT. */

            while (!(AREA_DE_WORK.CH_CHAVE_ATU != AREA_DE_WORK.CH_CHAVE_ANT))
            {

                R0230_25_FETCH_V1PARCELA_SECTION();
            }

            /*" -2600- MOVE CH-CHAVE-ATU TO CH-CHAVE-ANT. */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU, AREA_DE_WORK.CH_CHAVE_ANT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_30_SAIDA*/

        [StopWatch]
        /*" R0230-35-SELECT-NUMERO-AES-SECTION */
        private void R0230_35_SELECT_NUMERO_AES_SECTION()
        {
            /*" -2612- MOVE 'R0230-35' TO WNR-EXEC-SQL. */
            _.Move("R0230-35", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2618- PERFORM R0230_35_SELECT_NUMERO_AES_DB_SELECT_1 */

            R0230_35_SELECT_NUMERO_AES_DB_SELECT_1();

            /*" -2621- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2624- DISPLAY 'R0230-35 (NAO EXITE NA V1NUMERO-AES) ... ' ' ' V1ENDO-ORGAO ' ' V1ENDO-RAMO */

                $"R0230-35 (NAO EXITE NA V1NUMERO-AES) ...  {V1ENDO_ORGAO} {V1ENDO_RAMO}"
                .Display();

                /*" -2625- PERFORM R0450-00-LIMPA-REGISTROS */

                R0450_00_LIMPA_REGISTROS_SECTION();

                /*" -2627- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2629- MOVE 'INFORMACAO NAO ENCONTRADA NA VIEW V0NUMERO_AES ' TO LD-DES-ERRO-SSAIDA */
                _.Move("INFORMACAO NAO ENCONTRADA NA VIEW V0NUMERO_AES ", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2630- PERFORM R0460-00-GRAVA-REGISTROS */

                R0460_00_GRAVA_REGISTROS_SECTION();

                /*" -2630- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0230-35-SELECT-NUMERO-AES-DB-SELECT-1 */
        public void R0230_35_SELECT_NUMERO_AES_DB_SELECT_1()
        {
            /*" -2618- EXEC SQL SELECT NRENDOCA INTO :V0NAES-NRENDOCA FROM SEGUROS.V0NUMERO_AES WHERE COD_ORGAO = :V1ENDO-ORGAO AND COD_RAMO = :V1ENDO-RAMO END-EXEC. */

            var r0230_35_SELECT_NUMERO_AES_DB_SELECT_1_Query1 = new R0230_35_SELECT_NUMERO_AES_DB_SELECT_1_Query1()
            {
                V1ENDO_ORGAO = V1ENDO_ORGAO.ToString(),
                V1ENDO_RAMO = V1ENDO_RAMO.ToString(),
            };

            var executed_1 = R0230_35_SELECT_NUMERO_AES_DB_SELECT_1_Query1.Execute(r0230_35_SELECT_NUMERO_AES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0NAES_NRENDOCA, V0NAES_NRENDOCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_35_SAIDA*/

        [StopWatch]
        /*" R0230-40-UPDATE-NUMERO-AES-SECTION */
        private void R0230_40_UPDATE_NUMERO_AES_SECTION()
        {
            /*" -2642- MOVE 'R0230-40' TO WNR-EXEC-SQL. */
            _.Move("R0230-40", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2648- PERFORM R0230_40_UPDATE_NUMERO_AES_DB_UPDATE_1 */

            R0230_40_UPDATE_NUMERO_AES_DB_UPDATE_1();

            /*" -2651- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2654- DISPLAY 'R0230-40 (PROBLEMAS UPDATE NUMERO-AES) ... ' ' ' V1ENDO-ORGAO ' ' V1ENDO-RAMO */

                $"R0230-40 (PROBLEMAS UPDATE NUMERO-AES) ...  {V1ENDO_ORGAO} {V1ENDO_RAMO}"
                .Display();

                /*" -2655- PERFORM R0450-00-LIMPA-REGISTROS */

                R0450_00_LIMPA_REGISTROS_SECTION();

                /*" -2657- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2659- MOVE 'ERRO NO UPDATE DA VIEW V0NUMERO_AES ' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO UPDATE DA VIEW V0NUMERO_AES ", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2660- PERFORM R0460-00-GRAVA-REGISTROS */

                R0460_00_GRAVA_REGISTROS_SECTION();

                /*" -2660- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0230-40-UPDATE-NUMERO-AES-DB-UPDATE-1 */
        public void R0230_40_UPDATE_NUMERO_AES_DB_UPDATE_1()
        {
            /*" -2648- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET NRENDOCA = :V0NAES-NRENDOCA, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_ORGAO = :V1ENDO-ORGAO AND COD_RAMO = :V1ENDO-RAMO END-EXEC. */

            var r0230_40_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1 = new R0230_40_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1()
            {
                V0NAES_NRENDOCA = V0NAES_NRENDOCA.ToString(),
                V1ENDO_ORGAO = V1ENDO_ORGAO.ToString(),
                V1ENDO_RAMO = V1ENDO_RAMO.ToString(),
            };

            R0230_40_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1.Execute(r0230_40_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_40_SAIDA*/

        [StopWatch]
        /*" R0230-45-CANCELAMENTO-SECTION */
        private void R0230_45_CANCELAMENTO_SECTION()
        {
            /*" -2672- MOVE 'R0230-45' TO WNR-EXEC-SQL. */
            _.Move("R0230-45", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2673- MOVE V1PARC-OCORHIST TO WOCORHIST. */
            _.Move(V1PARC_OCORHIST, WOCORHIST);

            /*" -2675- MOVE V1PARC-NRPARCEL TO V0HISP-NRPARCEL. */
            _.Move(V1PARC_NRPARCEL, V0HISP_NRPARCEL);

            /*" -2677- PERFORM R0230-65-ACUMULA-PREMIOS */

            R0230_65_ACUMULA_PREMIOS_SECTION();

            /*" -2679- PERFORM R0230-50-ACUMULA-CORRECAO. */

            R0230_50_ACUMULA_CORRECAO_SECTION();

            /*" -2680- IF WC-VLPRMTOT NOT EQUAL +0 */

            if (WC_VLPRMTOT != +0)
            {

                /*" -2681- PERFORM R0230-55-MONTA-CORRECAO */

                R0230_55_MONTA_CORRECAO_SECTION();

                /*" -2683- PERFORM R0230-60-INSERT-V0HISTOPARC. */

                R0230_60_INSERT_V0HISTOPARC_SECTION();
            }


            /*" -2684- PERFORM R0230-70-MONTA-PREMIOS */

            R0230_70_MONTA_PREMIOS_SECTION();

            /*" -2686- PERFORM R0230-60-INSERT-V0HISTOPARC */

            R0230_60_INSERT_V0HISTOPARC_SECTION();

            /*" -2688- PERFORM R0230-75-UPDATE-V0PARCELA */

            R0230_75_UPDATE_V0PARCELA_SECTION();

            /*" -2688- MOVE '*' TO WHOUVE-CANCELA. */
            _.Move("*", AREA_DE_WORK.WHOUVE_CANCELA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_45_SAIDA*/

        [StopWatch]
        /*" R0230-50-ACUMULA-CORRECAO-SECTION */
        private void R0230_50_ACUMULA_CORRECAO_SECTION()
        {
            /*" -2700- MOVE 'R0230-50' TO WNR-EXEC-SQL. */
            _.Move("R0230-50", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2722- PERFORM R0230_50_ACUMULA_CORRECAO_DB_SELECT_1 */

            R0230_50_ACUMULA_CORRECAO_DB_SELECT_1();

            /*" -2725- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2729- DISPLAY 'R0230-50 (PROBLEMAS ACESSO V1HISTOPARC) ...' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL */

                $"R0230-50 (PROBLEMAS ACESSO V1HISTOPARC) ...{V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL}"
                .Display();

                /*" -2730- PERFORM R0450-00-LIMPA-REGISTROS */

                R0450_00_LIMPA_REGISTROS_SECTION();

                /*" -2732- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2734- MOVE 'ERRO NO ACESSO A VIEW V1HISTOPARC - OPER 0801 ' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A VIEW V1HISTOPARC - OPER 0801 ", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2735- PERFORM R0460-00-GRAVA-REGISTROS */

                R0460_00_GRAVA_REGISTROS_SECTION();

                /*" -2735- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0230-50-ACUMULA-CORRECAO-DB-SELECT-1 */
        public void R0230_50_ACUMULA_CORRECAO_DB_SELECT_1()
        {
            /*" -2722- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO),0) , VALUE(SUM(VAL_DESCONTO),0) , VALUE(SUM(VLPRMLIQ),0) , VALUE(SUM(VLADIFRA),0) , VALUE(SUM(VLCUSEMI),0) , VALUE(SUM(VLIOCC),0) , VALUE(SUM(VLPRMTOT),0) , VALUE(SUM(VLPREMIO),0) INTO :WC-PRM-TAR , :WC-VAL-DESC , :WC-VLPRMLIQ , :WC-VLADIFRA , :WC-VLCUSEMI , :WC-VLIOCC , :WC-VLPRMTOT , :WC-VLPREMIO FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL = :V0HISP-NRPARCEL AND OPERACAO = 0801 END-EXEC. */

            var r0230_50_ACUMULA_CORRECAO_DB_SELECT_1_Query1 = new R0230_50_ACUMULA_CORRECAO_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R0230_50_ACUMULA_CORRECAO_DB_SELECT_1_Query1.Execute(r0230_50_ACUMULA_CORRECAO_DB_SELECT_1_Query1);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_50_SAIDA*/

        [StopWatch]
        /*" R0230-55-MONTA-CORRECAO-SECTION */
        private void R0230_55_MONTA_CORRECAO_SECTION()
        {
            /*" -2747- MOVE 'R0230-55' TO WNR-EXEC-SQL. */
            _.Move("R0230-55", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2748- MOVE V1PARC-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V1PARC_NUM_APOL, V0HISP_NUM_APOL);

            /*" -2750- MOVE V1PARC-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V1PARC_NRENDOS, V0HISP_NRENDOS);

            /*" -2751- MOVE V1PARC-DACPARC TO V0HISP-DACPARC */
            _.Move(V1PARC_DACPARC, V0HISP_DACPARC);

            /*" -2752- MOVE V1SIST-DTMOVABE TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0HISP_DTMOVTO);

            /*" -2754- MOVE 0804 TO V0HISP-OPERACAO */
            _.Move(0804, V0HISP_OPERACAO);

            /*" -2755- ADD +1 TO WOCORHIST */
            WOCORHIST.Value = WOCORHIST + +1;

            /*" -2757- MOVE WOCORHIST TO V0HISP-OCORHIST */
            _.Move(WOCORHIST, V0HISP_OCORHIST);

            /*" -2758- ACCEPT WTIME-DAY FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME_DAY);

            /*" -2760- MOVE WTIME-DAYR TO V0HISP-HORAOPER */
            _.Move(AREA_DE_WORK.FILLER_39.WTIME_DAYR, V0HISP_HORAOPER);

            /*" -2761- MOVE V1HISP-DTVENCTO TO V0HISP-DTVENCTO */
            _.Move(V1HISP_DTVENCTO, V0HISP_DTVENCTO);

            /*" -2762- MOVE V1ENDO-BCOCOBR TO V0HISP-BCOCOBR */
            _.Move(V1ENDO_BCOCOBR, V0HISP_BCOCOBR);

            /*" -2763- MOVE V1ENDO-AGECOBR TO V0HISP-AGECOBR */
            _.Move(V1ENDO_AGECOBR, V0HISP_AGECOBR);

            /*" -2764- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -2765- MOVE W0NAES-NRENDOCA TO V0HISP-NRENDOCA */
            _.Move(W0NAES_NRENDOCA, V0HISP_NRENDOCA);

            /*" -2766- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -2767- MOVE 'VG0031B' TO V0HISP-COD-USUARIO */
            _.Move("VG0031B", V0HISP_COD_USUARIO);

            /*" -2768- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -2769- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -2771- MOVE V1PARC-COD-EMP TO V0HISP-COD-EMPRESA */
            _.Move(V1PARC_COD_EMP, V0HISP_COD_EMPRESA);

            /*" -2772- MOVE WC-PRM-TAR TO V0HISP-PRM-TAR */
            _.Move(WC_PRM_TAR, V0HISP_PRM_TAR);

            /*" -2773- MOVE WC-VAL-DESC TO V0HISP-VAL-DESC */
            _.Move(WC_VAL_DESC, V0HISP_VAL_DESC);

            /*" -2774- MOVE WC-VLPRMLIQ TO V0HISP-VLPRMLIQ */
            _.Move(WC_VLPRMLIQ, V0HISP_VLPRMLIQ);

            /*" -2775- MOVE WC-VLADIFRA TO V0HISP-VLADIFRA */
            _.Move(WC_VLADIFRA, V0HISP_VLADIFRA);

            /*" -2776- MOVE WC-VLCUSEMI TO V0HISP-VLCUSEMI */
            _.Move(WC_VLCUSEMI, V0HISP_VLCUSEMI);

            /*" -2777- MOVE WC-VLIOCC TO V0HISP-VLIOCC */
            _.Move(WC_VLIOCC, V0HISP_VLIOCC);

            /*" -2778- MOVE WC-VLPRMTOT TO V0HISP-VLPRMTOT */
            _.Move(WC_VLPRMTOT, V0HISP_VLPRMTOT);

            /*" -2780- MOVE WC-VLPREMIO TO V0HISP-VLPREMIO. */
            _.Move(WC_VLPREMIO, V0HISP_VLPREMIO);

            /*" -2780- ADD +1 TO AC-C-V0HISTOPARC. */
            AREA_DE_WORK.AC_C_V0HISTOPARC.Value = AREA_DE_WORK.AC_C_V0HISTOPARC + +1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_55_SAIDA*/

        [StopWatch]
        /*" R0230-60-INSERT-V0HISTOPARC-SECTION */
        private void R0230_60_INSERT_V0HISTOPARC_SECTION()
        {
            /*" -2792- MOVE 'R0230-60' TO WNR-EXEC-SQL. */
            _.Move("R0230-60", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2821- PERFORM R0230_60_INSERT_V0HISTOPARC_DB_INSERT_1 */

            R0230_60_INSERT_V0HISTOPARC_DB_INSERT_1();

            /*" -2824- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2829- DISPLAY 'R0230-60 (REGISTRO DUPLICADO) ... ' ' ' V0HISP-NUM-APOL ' ' V0HISP-NRENDOS ' ' V0HISP-NRPARCEL ' ' V0HISP-OCORHIST */

                $"R0230-60 (REGISTRO DUPLICADO) ...  {V0HISP_NUM_APOL} {V0HISP_NRENDOS} {V0HISP_NRPARCEL} {V0HISP_OCORHIST}"
                .Display();

                /*" -2830- PERFORM R0450-00-LIMPA-REGISTROS */

                R0450_00_LIMPA_REGISTROS_SECTION();

                /*" -2832- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2834- MOVE 'REGISTRO DUPLICADO INSERT V0HISTOPARC' TO LD-DES-ERRO-SSAIDA */
                _.Move("REGISTRO DUPLICADO INSERT V0HISTOPARC", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2835- PERFORM R0460-00-GRAVA-REGISTROS */

                R0460_00_GRAVA_REGISTROS_SECTION();

                /*" -2838- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2839- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2843- DISPLAY 'R0230-60 (PROBLEMAS NA INSERCAO) ... ' ' ' V0HISP-NUM-APOL ' ' V0HISP-NRENDOS ' ' V0HISP-NRPARCEL */

                $"R0230-60 (PROBLEMAS NA INSERCAO) ...  {V0HISP_NUM_APOL} {V0HISP_NRENDOS} {V0HISP_NRPARCEL}"
                .Display();

                /*" -2844- PERFORM R0450-00-LIMPA-REGISTROS */

                R0450_00_LIMPA_REGISTROS_SECTION();

                /*" -2846- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2848- MOVE 'ERRO NO INSERT DA VIEW V0HISTOPARC' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO INSERT DA VIEW V0HISTOPARC", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2849- PERFORM R0460-00-GRAVA-REGISTROS */

                R0460_00_GRAVA_REGISTROS_SECTION();

                /*" -2849- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0230-60-INSERT-V0HISTOPARC-DB-INSERT-1 */
        public void R0230_60_INSERT_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -2821- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-DACPARC , :V0HISP-DTMOVTO , :V0HISP-OPERACAO , :V0HISP-HORAOPER , :V0HISP-OCORHIST , :V0HISP-PRM-TAR , :V0HISP-VAL-DESC , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-SITCONTB , :V0HISP-COD-USUARIO , :V0HISP-RNUDOC , :V0HISP-DTQITBCO:VIND-DTQITBCO, :V0HISP-COD-EMPRESA, CURRENT TIMESTAMP) END-EXEC. */

            var r0230_60_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1 = new R0230_60_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1()
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

            R0230_60_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1.Execute(r0230_60_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_60_SAIDA*/

        [StopWatch]
        /*" R0230-65-ACUMULA-PREMIOS-SECTION */
        private void R0230_65_ACUMULA_PREMIOS_SECTION()
        {
            /*" -2861- MOVE 'R0230-65' TO WNR-EXEC-SQL. */
            _.Move("R0230-65", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2885- PERFORM R0230_65_ACUMULA_PREMIOS_DB_SELECT_1 */

            R0230_65_ACUMULA_PREMIOS_DB_SELECT_1();

            /*" -2888- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2892- DISPLAY 'R0230-65 (PROBLEMAS ACESSO V1HISTOPARC) ...' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL */

                $"R0230-65 (PROBLEMAS ACESSO V1HISTOPARC) ...{V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL}"
                .Display();

                /*" -2893- PERFORM R0450-00-LIMPA-REGISTROS */

                R0450_00_LIMPA_REGISTROS_SECTION();

                /*" -2895- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2897- MOVE 'ERRO NO ACESSO A VIEW V1HISTOPARC ' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A VIEW V1HISTOPARC ", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2898- PERFORM R0460-00-GRAVA-REGISTROS */

                R0460_00_GRAVA_REGISTROS_SECTION();

                /*" -2898- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0230-65-ACUMULA-PREMIOS-DB-SELECT-1 */
        public void R0230_65_ACUMULA_PREMIOS_DB_SELECT_1()
        {
            /*" -2885- EXEC SQL SELECT PRM_TARIFARIO , VAL_DESCONTO , VLPRMLIQ , VLADIFRA , VLCUSEMI , VLIOCC , VLPRMTOT , VLPREMIO , DTVENCTO INTO :WP-PRM-TAR , :WP-VAL-DESC , :WP-VLPRMLIQ , :WP-VLADIFRA , :WP-VLCUSEMI , :WP-VLIOCC , :WP-VLPRMTOT , :WP-VLPREMIO , :V1HISP-DTVENCTO FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL = :V0HISP-NRPARCEL AND OPERACAO = 0101 END-EXEC. */

            var r0230_65_ACUMULA_PREMIOS_DB_SELECT_1_Query1 = new R0230_65_ACUMULA_PREMIOS_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R0230_65_ACUMULA_PREMIOS_DB_SELECT_1_Query1.Execute(r0230_65_ACUMULA_PREMIOS_DB_SELECT_1_Query1);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_65_SAIDA*/

        [StopWatch]
        /*" R0230-70-MONTA-PREMIOS-SECTION */
        private void R0230_70_MONTA_PREMIOS_SECTION()
        {
            /*" -2910- MOVE 'R0230-70' TO WNR-EXEC-SQL. */
            _.Move("R0230-70", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2911- MOVE V1PARC-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V1PARC_NUM_APOL, V0HISP_NUM_APOL);

            /*" -2913- MOVE V1PARC-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V1PARC_NRENDOS, V0HISP_NRENDOS);

            /*" -2914- MOVE V1PARC-DACPARC TO V0HISP-DACPARC */
            _.Move(V1PARC_DACPARC, V0HISP_DACPARC);

            /*" -2915- MOVE V1SIST-DTMOVABE TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0HISP_DTMOVTO);

            /*" -2919- MOVE 0403 TO V0HISP-OPERACAO */
            _.Move(0403, V0HISP_OPERACAO);

            /*" -2920- ADD +1 TO WOCORHIST */
            WOCORHIST.Value = WOCORHIST + +1;

            /*" -2922- MOVE WOCORHIST TO V0HISP-OCORHIST */
            _.Move(WOCORHIST, V0HISP_OCORHIST);

            /*" -2923- ACCEPT WTIME-DAY FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME_DAY);

            /*" -2925- MOVE WTIME-DAYR TO V0HISP-HORAOPER */
            _.Move(AREA_DE_WORK.FILLER_39.WTIME_DAYR, V0HISP_HORAOPER);

            /*" -2926- MOVE V1HISP-DTVENCTO TO V0HISP-DTVENCTO */
            _.Move(V1HISP_DTVENCTO, V0HISP_DTVENCTO);

            /*" -2927- MOVE V1ENDO-BCOCOBR TO V0HISP-BCOCOBR */
            _.Move(V1ENDO_BCOCOBR, V0HISP_BCOCOBR);

            /*" -2928- MOVE V1ENDO-AGECOBR TO V0HISP-AGECOBR */
            _.Move(V1ENDO_AGECOBR, V0HISP_AGECOBR);

            /*" -2929- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -2930- MOVE W0NAES-NRENDOCA TO V0HISP-NRENDOCA */
            _.Move(W0NAES_NRENDOCA, V0HISP_NRENDOCA);

            /*" -2931- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -2932- MOVE 'VG0031B' TO V0HISP-COD-USUARIO */
            _.Move("VG0031B", V0HISP_COD_USUARIO);

            /*" -2933- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -2934- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -2936- MOVE V1PARC-COD-EMP TO V0HISP-COD-EMPRESA */
            _.Move(V1PARC_COD_EMP, V0HISP_COD_EMPRESA);

            /*" -2937- MOVE WP-PRM-TAR TO V0HISP-PRM-TAR */
            _.Move(WP_PRM_TAR, V0HISP_PRM_TAR);

            /*" -2938- MOVE WP-VAL-DESC TO V0HISP-VAL-DESC */
            _.Move(WP_VAL_DESC, V0HISP_VAL_DESC);

            /*" -2939- MOVE WP-VLPRMLIQ TO V0HISP-VLPRMLIQ */
            _.Move(WP_VLPRMLIQ, V0HISP_VLPRMLIQ);

            /*" -2940- MOVE WP-VLADIFRA TO V0HISP-VLADIFRA */
            _.Move(WP_VLADIFRA, V0HISP_VLADIFRA);

            /*" -2941- MOVE WP-VLCUSEMI TO V0HISP-VLCUSEMI */
            _.Move(WP_VLCUSEMI, V0HISP_VLCUSEMI);

            /*" -2942- MOVE WP-VLIOCC TO V0HISP-VLIOCC */
            _.Move(WP_VLIOCC, V0HISP_VLIOCC);

            /*" -2943- MOVE WP-VLPRMTOT TO V0HISP-VLPRMTOT */
            _.Move(WP_VLPRMTOT, V0HISP_VLPRMTOT);

            /*" -2945- MOVE WP-VLPREMIO TO V0HISP-VLPREMIO */
            _.Move(WP_VLPREMIO, V0HISP_VLPREMIO);

            /*" -2945- ADD +1 TO AC-P-V0HISTOPARC. */
            AREA_DE_WORK.AC_P_V0HISTOPARC.Value = AREA_DE_WORK.AC_P_V0HISTOPARC + +1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_70_SAIDA*/

        [StopWatch]
        /*" R0230-75-UPDATE-V0PARCELA-SECTION */
        private void R0230_75_UPDATE_V0PARCELA_SECTION()
        {
            /*" -2957- MOVE 'R0230-75' TO WNR-EXEC-SQL. */
            _.Move("R0230-75", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2965- PERFORM R0230_75_UPDATE_V0PARCELA_DB_UPDATE_1 */

            R0230_75_UPDATE_V0PARCELA_DB_UPDATE_1();

            /*" -2968- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2972- DISPLAY 'R0230-75 (PROBLEMAS UPDATE V0PARCELA) ... ' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL */

                $"R0230-75 (PROBLEMAS UPDATE V0PARCELA) ...  {V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL}"
                .Display();

                /*" -2973- PERFORM R0450-00-LIMPA-REGISTROS */

                R0450_00_LIMPA_REGISTROS_SECTION();

                /*" -2975- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2977- MOVE 'ERRO NO UPDATE DA VIEW V0PARCELA' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO UPDATE DA VIEW V0PARCELA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2978- PERFORM R0460-00-GRAVA-REGISTROS */

                R0460_00_GRAVA_REGISTROS_SECTION();

                /*" -2980- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2980- ADD 1 TO AC-UPDT-V1PARCELA. */
            AREA_DE_WORK.AC_UPDT_V1PARCELA.Value = AREA_DE_WORK.AC_UPDT_V1PARCELA + 1;

        }

        [StopWatch]
        /*" R0230-75-UPDATE-V0PARCELA-DB-UPDATE-1 */
        public void R0230_75_UPDATE_V0PARCELA_DB_UPDATE_1()
        {
            /*" -2965- EXEC SQL UPDATE SEGUROS.V0PARCELA SET OCORHIST = :WOCORHIST, SITUACAO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL = :V0HISP-NRPARCEL END-EXEC. */

            var r0230_75_UPDATE_V0PARCELA_DB_UPDATE_1_Update1 = new R0230_75_UPDATE_V0PARCELA_DB_UPDATE_1_Update1()
            {
                WOCORHIST = WOCORHIST.ToString(),
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            R0230_75_UPDATE_V0PARCELA_DB_UPDATE_1_Update1.Execute(r0230_75_UPDATE_V0PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_75_SAIDA*/

        [StopWatch]
        /*" R0230-80-UPDATE-V0ENDOSSO-SECTION */
        private void R0230_80_UPDATE_V0ENDOSSO_SECTION()
        {
            /*" -2992- MOVE 'R0230-80' TO WNR-EXEC-SQL. */
            _.Move("R0230-80", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2998- PERFORM R0230_80_UPDATE_V0ENDOSSO_DB_UPDATE_1 */

            R0230_80_UPDATE_V0ENDOSSO_DB_UPDATE_1();

            /*" -3001- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3004- DISPLAY 'R0230-80 (PROBLEMAS UPDATE V0ENDOSSO) ... ' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS */

                $"R0230-80 (PROBLEMAS UPDATE V0ENDOSSO) ...  {V1PARC_NUM_APOL} {V1PARC_NRENDOS}"
                .Display();

                /*" -3005- PERFORM R0450-00-LIMPA-REGISTROS */

                R0450_00_LIMPA_REGISTROS_SECTION();

                /*" -3007- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -3009- MOVE 'ERRO NO UPDATE DA VIEW V0ENDOSSO' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO UPDATE DA VIEW V0ENDOSSO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -3010- PERFORM R0460-00-GRAVA-REGISTROS */

                R0460_00_GRAVA_REGISTROS_SECTION();

                /*" -3011- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3012- ELSE */
            }
            else
            {


                /*" -3012- ADD 1 TO AC-UPDT-V1ENDOSSO. */
                AREA_DE_WORK.AC_UPDT_V1ENDOSSO.Value = AREA_DE_WORK.AC_UPDT_V1ENDOSSO + 1;
            }


        }

        [StopWatch]
        /*" R0230-80-UPDATE-V0ENDOSSO-DB-UPDATE-1 */
        public void R0230_80_UPDATE_V0ENDOSSO_DB_UPDATE_1()
        {
            /*" -2998- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET SITUACAO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V0HISP-NUM-APOL AND NRENDOS = :V0HISP-NRENDOS END-EXEC. */

            var r0230_80_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1 = new R0230_80_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
            };

            R0230_80_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1.Execute(r0230_80_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_80_SAIDA*/

        [StopWatch]
        /*" R0260-00-CANCELA-V0SUBGRUPO-SECTION */
        private void R0260_00_CANCELA_V0SUBGRUPO_SECTION()
        {
            /*" -3024- MOVE 'R0260-00' TO WNR-EXEC-SQL. */
            _.Move("R0260-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3029- PERFORM R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1 */

            R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1();

            /*" -3032- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3033- DISPLAY 'R0260-00 - PROBLEMAS UPDATE V0SUBGRUPO.... ' */
                _.Display($"R0260-00 - PROBLEMAS UPDATE V0SUBGRUPO.... ");

                /*" -3034- DISPLAY 'APOLICE......  ' V0SUBG-NUM-APOL */
                _.Display($"APOLICE......  {V0SUBG_NUM_APOL}");

                /*" -3035- DISPLAY 'SUBGRUPO.....  ' V0SUBG-COD-SUBG */
                _.Display($"SUBGRUPO.....  {V0SUBG_COD_SUBG}");

                /*" -3036- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -3037- PERFORM R0450-00-LIMPA-REGISTROS */

                R0450_00_LIMPA_REGISTROS_SECTION();

                /*" -3039- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -3041- MOVE 'ERRO NO UPDATE DA VIEW V0SUBGRUPO' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO UPDATE DA VIEW V0SUBGRUPO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -3042- PERFORM R0460-00-GRAVA-REGISTROS */

                R0460_00_GRAVA_REGISTROS_SECTION();

                /*" -3044- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3046- MOVE 'R0260-01' TO WNR-EXEC-SQL. */
            _.Move("R0260-01", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3056- PERFORM R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_2 */

            R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_2();

            /*" -3059- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3061- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -3062- ELSE */
                }
                else
                {


                    /*" -3063- DISPLAY 'R0260-00 (PROBLEMAS UPDATE V0PROPOSTAVA) . ' */
                    _.Display($"R0260-00 (PROBLEMAS UPDATE V0PROPOSTAVA) . ");

                    /*" -3064- DISPLAY 'APOLICE.......   ' V0SUBG-NUM-APOL */
                    _.Display($"APOLICE.......   {V0SUBG_NUM_APOL}");

                    /*" -3065- DISPLAY 'SUBGRUPO......   ' V0SUBG-COD-SUBG */
                    _.Display($"SUBGRUPO......   {V0SUBG_COD_SUBG}");

                    /*" -3066- DISPLAY 'SQLCODE.......   ' SQLCODE */
                    _.Display($"SQLCODE.......   {DB.SQLCODE}");

                    /*" -3067- PERFORM R0450-00-LIMPA-REGISTROS */

                    R0450_00_LIMPA_REGISTROS_SECTION();

                    /*" -3069- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -3071- MOVE 'ERRO NO UPDATE DA VIEW V0PROPOSTAVA' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO UPDATE DA VIEW V0PROPOSTAVA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -3072- PERFORM R0460-00-GRAVA-REGISTROS */

                    R0460_00_GRAVA_REGISTROS_SECTION();

                    /*" -3074- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3074- ADD 1 TO AC-UPDT-V1SUBGRUPO. */
            AREA_DE_WORK.AC_UPDT_V1SUBGRUPO.Value = AREA_DE_WORK.AC_UPDT_V1SUBGRUPO + 1;

        }

        [StopWatch]
        /*" R0260-00-CANCELA-V0SUBGRUPO-DB-UPDATE-1 */
        public void R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1()
        {
            /*" -3029- EXEC SQL UPDATE SEGUROS.V0SUBGRUPO SET SIT_REGISTRO = '2' WHERE NUM_APOLICE = :V0SUBG-NUM-APOL AND COD_SUBGRUPO = :V0SUBG-COD-SUBG END-EXEC. */

            var r0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1 = new R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1()
            {
                V0SUBG_NUM_APOL = V0SUBG_NUM_APOL.ToString(),
                V0SUBG_COD_SUBG = V0SUBG_COD_SUBG.ToString(),
            };

            R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1.Execute(r0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-CANCELA-V0SUBGRUPO-DB-UPDATE-2 */
        public void R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_2()
        {
            /*" -3056- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '4' , CODUSU = 'VG0031B' , CODOPER = :V0PROP-CODOPER, DTMOVTO = :V1SIST-DTMOVABE, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V0SUBG-NUM-APOL AND CODSUBES = :V0SUBG-COD-SUBG AND SITUACAO IN ( '3' , '6' ) END-EXEC. */

            var r0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_2_Update1 = new R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_2_Update1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0PROP_CODOPER = V0PROP_CODOPER.ToString(),
                V0SUBG_NUM_APOL = V0SUBG_NUM_APOL.ToString(),
                V0SUBG_COD_SUBG = V0SUBG_COD_SUBG.ToString(),
            };

            R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_2_Update1.Execute(r0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R0410-00-UPDATE-V0RELATORIO-SECTION */
        private void R0410_00_UPDATE_V0RELATORIO_SECTION()
        {
            /*" -3086- MOVE 'R0410-00' TO WNR-EXEC-SQL. */
            _.Move("R0410-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3095- PERFORM R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1 */

            R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1();

            /*" -3098- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3099- DISPLAY 'R0400-00 - PROBLEMAS UPDATE V0RELATORIOS' */
                _.Display($"R0400-00 - PROBLEMAS UPDATE V0RELATORIOS");

                /*" -3100- DISPLAY 'APOLICE......  ' V1REL-NUM-APOL */
                _.Display($"APOLICE......  {V1REL_NUM_APOL}");

                /*" -3101- DISPLAY 'SUBGRUPO.....  ' V1REL-COD-SUBG */
                _.Display($"SUBGRUPO.....  {V1REL_COD_SUBG}");

                /*" -3102- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -3103- PERFORM R0450-00-LIMPA-REGISTROS */

                R0450_00_LIMPA_REGISTROS_SECTION();

                /*" -3105- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -3107- MOVE 'ERRO NO UPDATE DA VIEW V0RELATORIOS' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO UPDATE DA VIEW V0RELATORIOS", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -3108- PERFORM R0460-00-GRAVA-REGISTROS */

                R0460_00_GRAVA_REGISTROS_SECTION();

                /*" -3108- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0410-00-UPDATE-V0RELATORIO-DB-UPDATE-1 */
        public void R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1()
        {
            /*" -3095- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE CODUSU = :V1REL-COD-USUR AND CODRELAT = :V1REL-CODRELAT AND NUM_APOLICE = :V1REL-NUM-APOL AND CODSUBES = :V1REL-COD-SUBG AND SITUACAO = '0' END-EXEC. */

            var r0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1 = new R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1()
            {
                V1REL_COD_USUR = V1REL_COD_USUR.ToString(),
                V1REL_CODRELAT = V1REL_CODRELAT.ToString(),
                V1REL_NUM_APOL = V1REL_NUM_APOL.ToString(),
                V1REL_COD_SUBG = V1REL_COD_SUBG.ToString(),
            };

            R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1.Execute(r0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-LIMPA-REGISTROS-SECTION */
        private void R0450_00_LIMPA_REGISTROS_SECTION()
        {
            /*" -3120- MOVE 'R0450-00' TO WNR-EXEC-SQL. */
            _.Move("R0450-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3126- MOVE ZEROS TO LD-NUM-APOL-SSAIDA LD-COD-SUBG-SSAIDA LD-COD-PROD-SSAIDA LD-NUM-CERT-SUB-SSAIDA LD-NUM-CERT-SEG-SSAIDA LD-COD-ERRO-DB2-SSAIDA. */
            _.Move(0, AREA_DE_WORK.LD_REG_SSAIDA.LD_NUM_APOL_SSAIDA, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_SUBG_SSAIDA, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_PROD_SSAIDA, AREA_DE_WORK.LD_REG_SSAIDA.LD_NUM_CERT_SUB_SSAIDA, AREA_DE_WORK.LD_REG_SSAIDA.LD_NUM_CERT_SEG_SSAIDA, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

            /*" -3130- MOVE SPACES TO LD-NOM-PROD-SSAIDA LD-DES-ERRO-DB2-SSAIDA LD-DES-ERRO-SSAIDA. */
            _.Move("", AREA_DE_WORK.LD_REG_SSAIDA.LD_NOM_PROD_SSAIDA, AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_DB2_SSAIDA, AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

            /*" -3135- MOVE ZEROS TO LD-NUM-APOL-DSAIDA LD-COD-SUBG-DSAIDA LD-COD-PROD-DSAIDA LD-NUM-CERT-SUB-DSAIDA LD-NUM-CERT-SEG-DSAIDA. */
            _.Move(0, AREA_DE_WORK.LD_REG_DSAIDA.LD_NUM_APOL_DSAIDA, AREA_DE_WORK.LD_REG_DSAIDA.LD_COD_SUBG_DSAIDA, AREA_DE_WORK.LD_REG_DSAIDA.LD_COD_PROD_DSAIDA, AREA_DE_WORK.LD_REG_DSAIDA.LD_NUM_CERT_SUB_DSAIDA, AREA_DE_WORK.LD_REG_DSAIDA.LD_NUM_CERT_SEG_DSAIDA);

            /*" -3136- MOVE SPACES TO LD-NOM-PROD-DSAIDA LD-DES-ERRO-DSAIDA. */
            _.Move("", AREA_DE_WORK.LD_REG_DSAIDA.LD_NOM_PROD_DSAIDA, AREA_DE_WORK.LD_REG_DSAIDA.LD_DES_ERRO_DSAIDA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0460-00-GRAVA-REGISTROS-SECTION */
        private void R0460_00_GRAVA_REGISTROS_SECTION()
        {
            /*" -3148- MOVE 'R0460-00' TO WNR-EXEC-SQL. */
            _.Move("R0460-00", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3149- IF LD-DES-ERRO-SSAIDA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA.IsEmpty())
            {

                /*" -3151- MOVE V1REL-NUM-APOL TO LD-NUM-APOL-SSAIDA */
                _.Move(V1REL_NUM_APOL, AREA_DE_WORK.LD_REG_SSAIDA.LD_NUM_APOL_SSAIDA);

                /*" -3153- MOVE V0SUBG-COD-SUBG TO LD-COD-SUBG-SSAIDA */
                _.Move(V0SUBG_COD_SUBG, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_SUBG_SSAIDA);

                /*" -3156- MOVE V0PROD-CODPRODU TO LD-COD-PROD-SSAIDA */
                _.Move(V0PROD_CODPRODU, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_PROD_SSAIDA);

                /*" -3157- IF V0SEG-TP-SEGURADO NOT EQUAL ZEROS */

                if (V0SEG_TP_SEGURADO != 00)
                {

                    /*" -3159- MOVE V0SEG-NUM-CERTIF TO LD-NUM-CERT-SUB-SSAIDA */
                    _.Move(V0SEG_NUM_CERTIF, AREA_DE_WORK.LD_REG_SSAIDA.LD_NUM_CERT_SUB_SSAIDA);

                    /*" -3160- ELSE */
                }
                else
                {


                    /*" -3162- MOVE V0SEG-NUM-CERTIF TO LD-NUM-CERT-SEG-SSAIDA */
                    _.Move(V0SEG_NUM_CERTIF, AREA_DE_WORK.LD_REG_SSAIDA.LD_NUM_CERT_SEG_SSAIDA);

                    /*" -3164- END-IF */
                }


                /*" -3166- MOVE V0PROD-NOMPRODU TO LD-NOM-PROD-SSAIDA */
                _.Move(V0PROD_NOMPRODU, AREA_DE_WORK.LD_REG_SSAIDA.LD_NOM_PROD_SSAIDA);

                /*" -3167- WRITE RECORD-SSAIDA FROM LD-REG-SSAIDA */
                _.Move(AREA_DE_WORK.LD_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

                SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

                /*" -3168- ADD 1 TO AC-ERRO-SISTEMA */
                AREA_DE_WORK.AC_ERRO_SISTEMA.Value = AREA_DE_WORK.AC_ERRO_SISTEMA + 1;

                /*" -3169- ELSE */
            }
            else
            {


                /*" -3171- MOVE V1REL-NUM-APOL TO LD-NUM-APOL-DSAIDA */
                _.Move(V1REL_NUM_APOL, AREA_DE_WORK.LD_REG_DSAIDA.LD_NUM_APOL_DSAIDA);

                /*" -3173- MOVE V0SUBG-COD-SUBG TO LD-COD-SUBG-DSAIDA */
                _.Move(V0SUBG_COD_SUBG, AREA_DE_WORK.LD_REG_DSAIDA.LD_COD_SUBG_DSAIDA);

                /*" -3176- MOVE V0PROD-CODPRODU TO LD-COD-PROD-DSAIDA */
                _.Move(V0PROD_CODPRODU, AREA_DE_WORK.LD_REG_DSAIDA.LD_COD_PROD_DSAIDA);

                /*" -3177- IF V0SEG-TP-SEGURADO NOT EQUAL ZEROS */

                if (V0SEG_TP_SEGURADO != 00)
                {

                    /*" -3179- MOVE V0SEG-NUM-CERTIF TO LD-NUM-CERT-SUB-DSAIDA */
                    _.Move(V0SEG_NUM_CERTIF, AREA_DE_WORK.LD_REG_DSAIDA.LD_NUM_CERT_SUB_DSAIDA);

                    /*" -3180- ELSE */
                }
                else
                {


                    /*" -3182- MOVE V0SEG-NUM-CERTIF TO LD-NUM-CERT-SEG-DSAIDA */
                    _.Move(V0SEG_NUM_CERTIF, AREA_DE_WORK.LD_REG_DSAIDA.LD_NUM_CERT_SEG_DSAIDA);

                    /*" -3184- END-IF */
                }


                /*" -3186- MOVE V0PROD-NOMPRODU TO LD-NOM-PROD-DSAIDA */
                _.Move(V0PROD_NOMPRODU, AREA_DE_WORK.LD_REG_DSAIDA.LD_NOM_PROD_DSAIDA);

                /*" -3187- WRITE RECORD-DSAIDA FROM LD-REG-DSAIDA */
                _.Move(AREA_DE_WORK.LD_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

                DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

                /*" -3188- ADD 1 TO AC-ERRO-DADOS */
                AREA_DE_WORK.AC_ERRO_DADOS.Value = AREA_DE_WORK.AC_ERRO_DADOS + 1;

                /*" -3188- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0460_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -3203- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -3204- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3205- DISPLAY '*   VG0031B - CANCELAMENTO DE ENDOSSOS     *' */
            _.Display($"*   VG0031B - CANCELAMENTO DE ENDOSSOS     *");

            /*" -3206- DISPLAY '*   -------   ------------ -----------     *' */
            _.Display($"*   -------   ------------ -----------     *");

            /*" -3207- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3208- DISPLAY '*          NAO HOUVE SOLICITACAO           *' */
            _.Display($"*          NAO HOUVE SOLICITACAO           *");

            /*" -3209- DISPLAY '*          --- ----- -----------           *' */
            _.Display($"*          --- ----- -----------           *");

            /*" -3209- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -3224- MOVE V1SIST-DTMOVABE TO WDATA-REL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_REL);

            /*" -3225- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(AREA_DE_WORK.FILLER_23.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -3226- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(AREA_DE_WORK.FILLER_23.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -3228- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(AREA_DE_WORK.FILLER_23.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -3229- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -3230- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3231- DISPLAY '*   VG0031B - CANCELAMENTO AUTOMATICO      *' */
            _.Display($"*   VG0031B - CANCELAMENTO AUTOMATICO      *");

            /*" -3232- DISPLAY '*   -------   ------------ ----------      *' */
            _.Display($"*   -------   ------------ ----------      *");

            /*" -3233- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3234- DISPLAY '*      Nao houve parcelas em atraso        *' */
            _.Display($"*      Nao houve parcelas em atraso        *");

            /*" -3235- DISPLAY '*          ate a data informada            *' */
            _.Display($"*          ate a data informada            *");

            /*" -3237- DISPLAY '*               ' WDAT-REL-LIT '                   *' */

            $"*               {AREA_DE_WORK.WDAT_REL_LIT}                   *"
            .Display();

            /*" -3238- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3238- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3253- DISPLAY ' ' */
            _.Display($" ");

            /*" -3254- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -3255- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3256- DISPLAY '*       ABEND OCORRIDO NO PGM VG0031B      *' */
            _.Display($"*       ABEND OCORRIDO NO PGM VG0031B      *");

            /*" -3257- DISPLAY '*       -----------------------------      *' */
            _.Display($"*       -----------------------------      *");

            /*" -3258- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3259- DISPLAY '*         PULAR PARA O PROXIMO STEP        *' */
            _.Display($"*         PULAR PARA O PROXIMO STEP        *");

            /*" -3260- DISPLAY '*         -------------------------        *' */
            _.Display($"*         -------------------------        *");

            /*" -3261- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3262- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -3264- DISPLAY ' ' */
            _.Display($" ");

            /*" -3266- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -3268- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -3268- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -3270- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3274- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -3276- IF AC-ERRO-DADOS GREATER ZEROS AND AC-ERRO-SISTEMA GREATER ZEROS */

            if (AREA_DE_WORK.AC_ERRO_DADOS > 00 && AREA_DE_WORK.AC_ERRO_SISTEMA > 00)
            {

                /*" -3277- MOVE 3 TO RETURN-CODE */
                _.Move(3, RETURN_CODE);

                /*" -3278- ELSE */
            }
            else
            {


                /*" -3279- IF AC-ERRO-SISTEMA GREATER ZEROS */

                if (AREA_DE_WORK.AC_ERRO_SISTEMA > 00)
                {

                    /*" -3280- MOVE 2 TO RETURN-CODE */
                    _.Move(2, RETURN_CODE);

                    /*" -3281- ELSE */
                }
                else
                {


                    /*" -3282- IF AC-ERRO-DADOS GREATER ZEROS */

                    if (AREA_DE_WORK.AC_ERRO_DADOS > 00)
                    {

                        /*" -3284- MOVE 1 TO RETURN-CODE. */
                        _.Move(1, RETURN_CODE);
                    }

                }

            }


            /*" -3287- CLOSE DSAIDA SSAIDA. */
            DSAIDA.Close();
            SSAIDA.Close();

            /*" -3287- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}