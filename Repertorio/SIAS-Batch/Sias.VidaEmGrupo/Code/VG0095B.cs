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
using Sias.VidaEmGrupo.DB2.VG0095B;

namespace Code
{
    public class VG0095B
    {
        public bool IsCall { get; set; }

        public VG0095B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      * TRANSFERENCIA DE FONTES - APOLICE 97010000889 - FONTE 10       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     01     *  02/01/98  *   FREDERICO  *                       *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  PROPAUTOM                        PIC S9(9) COMP.*/
        public IntBasis PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"77  V0SEG-FONTE                PIC S9(004)      COMP.*/
        public IntBasis V0SEG_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MNUM-APOLICE               PIC S9(013)      COMP-3.*/
        public IntBasis MNUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  MCOD-SUBGRUPO              PIC S9(004)      COMP.*/
        public IntBasis MCOD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MCOD-FONTE                 PIC S9(004)      COMP.*/
        public IntBasis MCOD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MNUM-PROPOSTA              PIC S9(009)      COMP.*/
        public IntBasis MNUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  MTIPO-SEGURADO             PIC  X(001).*/
        public StringBasis MTIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MNUM-CERTIFICADO           PIC S9(015)      COMP-3.*/
        public IntBasis MNUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  MDAC-CERTIFICADO           PIC  X(001).*/
        public StringBasis MDAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MTIPO-INCLUSAO             PIC  X(001).*/
        public StringBasis MTIPO_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MCOD-CLIENTE               PIC S9(009)      COMP.*/
        public IntBasis MCOD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  MCOD-AGENCIADOR            PIC S9(009)      COMP.*/
        public IntBasis MCOD_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  MCOD-CORRETOR              PIC S9(009)      COMP.*/
        public IntBasis MCOD_CORRETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  MCOD-PLANOVGAP             PIC S9(004)      COMP.*/
        public IntBasis MCOD_PLANOVGAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MCOD-PLANOAP               PIC S9(004)      COMP.*/
        public IntBasis MCOD_PLANOAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MFAIXA                     PIC S9(004)      COMP.*/
        public IntBasis MFAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MAUTOR-AUM-AUTOMAT         PIC  X(001).*/
        public StringBasis MAUTOR_AUM_AUTOMAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MTIPO-BENEFICIARIO         PIC  X(001).*/
        public StringBasis MTIPO_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MPERI-PAGAMENTO            PIC S9(004)      COMP.*/
        public IntBasis MPERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MPERI-RENOVACAO            PIC S9(004)      COMP.*/
        public IntBasis MPERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MCOD-OCUPACAO              PIC  X(004).*/
        public StringBasis MCOD_OCUPACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
        /*"77  MESTADO-CIVIL              PIC  X(001).*/
        public StringBasis MESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MIDE-SEXO                  PIC  X(001).*/
        public StringBasis MIDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MCOD-PROFISSAO             PIC S9(004)      COMP.*/
        public IntBasis MCOD_PROFISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MNATURALIDADE              PIC  X(030).*/
        public StringBasis MNATURALIDADE { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"77  MOCORR-ENDERECO            PIC S9(004)      COMP.*/
        public IntBasis MOCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MOCORR-END-COBRAN          PIC S9(004)      COMP.*/
        public IntBasis MOCORR_END_COBRAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MBCO-COBRANCA              PIC S9(004)      COMP.*/
        public IntBasis MBCO_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MAGE-COBRANCA              PIC S9(004)      COMP.*/
        public IntBasis MAGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MDAC-COBRANCA              PIC  X(001).*/
        public StringBasis MDAC_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MNUM-MATRICULA             PIC S9(015)      COMP-3.*/
        public IntBasis MNUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  MNUM-CTA-CORRENTE          PIC S9(013)      COMP-3.*/
        public IntBasis MNUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  MDAC-CTA-CORRENTE          PIC  X(001).*/
        public StringBasis MDAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MVAL-SALARIO               PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MVAL_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MTIPO-SALARIO              PIC  X(001).*/
        public StringBasis MTIPO_SALARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MTIPO-PLANO                PIC  X(001).*/
        public StringBasis MTIPO_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MPCT-CONJUGE-VG            PIC S9(003)V99   COMP-3.*/
        public DoubleBasis MPCT_CONJUGE_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  MPCT-CONJUGE-AP            PIC S9(003)V99   COMP-3.*/
        public DoubleBasis MPCT_CONJUGE_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  MQTD-SAL-MORNATU           PIC S9(004)      COMP.*/
        public IntBasis MQTD_SAL_MORNATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MQTD-SAL-MORACID           PIC S9(004)      COMP.*/
        public IntBasis MQTD_SAL_MORACID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MQTD-SAL-INVPERM           PIC S9(004)      COMP.*/
        public IntBasis MQTD_SAL_INVPERM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MTAXA-AP-MORACID           PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTAXA_AP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  MTAXA-AP-INVPERM           PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTAXA_AP_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  MTAXA-AP-AMDS              PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTAXA_AP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  MTAXA-AP-DH                PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTAXA_AP_DH { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  MTAXA-AP-DIT               PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTAXA_AP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  MTAXA-VG                   PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTAXA_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  MIMP-MORNATU-ANT           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_MORNATU_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-MORNATU-ATU           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_MORNATU_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-MORACID-ANT           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_MORACID_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-MORACID-ATU           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_MORACID_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-INVPERM-ANT           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_INVPERM_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-INVPERM-ATU           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_INVPERM_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-AMDS-ANT              PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_AMDS_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-AMDS-ATU              PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_AMDS_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-DH-ANT                PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_DH_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-DH-ATU                PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_DH_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-DIT-ANT               PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_DIT_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-DIT-ATU               PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_DIT_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MPRM-VG-ANT                PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MPRM_VG_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MPRM-VG-ATU                PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MPRM_VG_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MPRM-AP-ANT                PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MPRM_AP_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MPRM-AP-ATU                PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MPRM_AP_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MCOD-OPERACAO              PIC S9(004)      COMP.*/
        public IntBasis MCOD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MDATA-OPERACAO             PIC  X(010).*/
        public StringBasis MDATA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  COD-SUBGRUPO-TRANS         PIC S9(004)      COMP.*/
        public IntBasis COD_SUBGRUPO_TRANS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MSIT-REGISTRO              PIC  X(001).*/
        public StringBasis MSIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MCOD-USUARIO               PIC  X(008).*/
        public StringBasis MCOD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  MDATA-AVERBACAO            PIC  X(010).*/
        public StringBasis MDATA_AVERBACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MDATA-ADMISSAO             PIC  X(010).*/
        public StringBasis MDATA_ADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MDATA-INCLUSAO             PIC  X(010).*/
        public StringBasis MDATA_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MDATA-NASCIMENTO           PIC  X(010).*/
        public StringBasis MDATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MDATA-FATURA               PIC  X(010).*/
        public StringBasis MDATA_FATURA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MDATA-REFERENCIA           PIC  X(010).*/
        public StringBasis MDATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MDATA-MOVIMENTO            PIC  X(010).*/
        public StringBasis MDATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MCOD-EMPRESA               PIC S9(009)      COMP.*/
        public IntBasis MCOD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  H-NUM-CERTIFICADO          PIC S9(015)      COMP-3.*/
        public IntBasis H_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  H-DAC-CERTIFICADO          PIC  X(001).*/
        public StringBasis H_DAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WDATA-AVERBACAO           PIC S9(004)      COMP.*/
        public IntBasis WDATA_AVERBACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-ADMISSAO            PIC S9(004)      COMP.*/
        public IntBasis WDATA_ADMISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-INCLUSAO            PIC S9(004)      COMP.*/
        public IntBasis WDATA_INCLUSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-NASCIMENTO          PIC S9(004)      COMP.*/
        public IntBasis WDATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-FATURA              PIC S9(004)      COMP.*/
        public IntBasis WDATA_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-REFERENCIA          PIC S9(004)      COMP.*/
        public IntBasis WDATA_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-MOVIMENTO           PIC S9(004)      COMP.*/
        public IntBasis WDATA_MOVIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WCOD-EMPRESA              PIC S9(004)      COMP.*/
        public IntBasis WCOD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WCOD-MOEDA                PIC S9(004)      COMP VALUE +1.*/
        public IntBasis WCOD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +1);
        /*"77  WNUM-ITEM                 PIC S9(004)      COMP.*/
        public IntBasis WNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-FONTE         PIC S9(04) COMP.*/
        public IntBasis WHOST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-ESCNEG        PIC S9(04) COMP.*/
        public IntBasis WHOST_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-AGENCIA       PIC S9(04) COMP.*/
        public IntBasis WHOST_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-AGECOBR       PIC S9(04) COMP.*/
        public IntBasis WHOST_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-DTINICIAL     PIC  X(10).*/
        public StringBasis WHOST_DTINICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTFINAL       PIC  X(10).*/
        public StringBasis WHOST_DTFINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTREF         PIC  X(010).*/
        public StringBasis WHOST_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V1CCOR-CODAGE       PIC S9(04)    COMP.*/
        public IntBasis V1CCOR_CODAGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0MOVIM-APOLICE     PIC S9(13)    COMP-3.*/
        public IntBasis V0MOVIM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0MOVIM-NRCERTIF    PIC S9(15)    COMP-3.*/
        public IntBasis V0MOVIM_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0MOVIM-FONTE       PIC S9(04)    COMP.*/
        public IntBasis V0MOVIM_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0SEGUR-APOLICE     PIC S9(13)    COMP-3.*/
        public IntBasis V0SEGUR_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0SEGUR-NRCERTIF    PIC S9(15)    COMP-3.*/
        public IntBasis V0SEGUR_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0SEGUR-FONTE       PIC S9(04)    COMP.*/
        public IntBasis V0SEGUR_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0SEGUR-SITUACAO    PIC  X(01).*/
        public StringBasis V0SEGUR_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77            V1MALHA-CDESCNEG     PIC S9(04)    COMP.*/
        public IntBasis V1MALHA_CDESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V1MALHA-CDFONTE      PIC S9(04)    COMP.*/
        public IntBasis V1MALHA_CDFONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WORK-AREA.*/
        public VG0095B_WORK_AREA WORK_AREA { get; set; } = new VG0095B_WORK_AREA();
        public class VG0095B_WORK_AREA : VarBasis
        {
            /*"    05        AC-LIDOS            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-ATUALIZADOS      PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_ATUALIZADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-REJEITADOS       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_REJEITADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        DATA-SQL.*/
            public VG0095B_DATA_SQL DATA_SQL { get; set; } = new VG0095B_DATA_SQL();
            public class VG0095B_DATA_SQL : VarBasis
            {
                /*"      10      SECANO-SQL          PIC  9(004).*/
                public IntBasis SECANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WABEND.*/
                public VG0095B_WABEND WABEND { get; set; } = new VG0095B_WABEND();
                public class VG0095B_WABEND : VarBasis
                {
                    /*"    10      FILLER              PIC  X(010) VALUE           ' VG0095B'.*/
                }
            }
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0095B");
            /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public VG0095B_TMOVIMENTO TMOVIMENTO { get; set; } = new VG0095B_TMOVIMENTO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -236- EXEC SQL WHENEVER SQLWARNING GO TO R9999-00-ROT-ERRO END-EXEC. */

            /*" -240- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

            /*" -243- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -251- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -254- MOVE V0SIST-DTMOVABE TO DATA-SQL. */
            _.Move(V0SIST_DTMOVABE, WORK_AREA.DATA_SQL);

            /*" -255- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -257- MOVE DATA-SQL TO WHOST-DTREF. */
            _.Move(WORK_AREA.DATA_SQL, WHOST_DTREF);

            /*" -259- DISPLAY '** PROCESSANDO REF = ' WHOST-DTREF. */
            _.Display($"** PROCESSANDO REF = {WHOST_DTREF}");

            /*" -342- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -343- GO TO R0000-00-PRINCIPAL. */

            R0000_00_PRINCIPAL_SECTION(); //GOTO
            return;

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -251- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-DECLARE-1 */
        public void M_0000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -342- EXEC SQL DECLARE TMOVIMENTO CURSOR FOR SELECT NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_PROPOSTA, TIPO_SEGURADO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_INCLUSAO, COD_CLIENTE, COD_AGENCIADOR, COD_CORRETOR, COD_PLANOVGAP, COD_PLANOAP, FAIXA, AUTOR_AUM_AUTOMAT, TIPO_BENEFICIARIO, PERI_PAGAMENTO, PERI_RENOVACAO, COD_OCUPACAO, ESTADO_CIVIL, IDE_SEXO, COD_PROFISSAO, NATURALIDADE, OCORR_ENDERECO, OCORR_END_COBRAN, BCO_COBRANCA, AGE_COBRANCA, DAC_COBRANCA, NUM_MATRICULA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE, VAL_SALARIO, TIPO_SALARIO, TIPO_PLANO, PCT_CONJUGE_VG, PCT_CONJUGE_AP, QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_VG, IMP_MORNATU_ANT, IMP_MORNATU_ATU, IMP_MORACID_ANT, IMP_MORACID_ATU, IMP_INVPERM_ANT, IMP_INVPERM_ATU, IMP_AMDS_ANT, IMP_AMDS_ATU, IMP_DH_ANT, IMP_DH_ATU, IMP_DIT_ANT, IMP_DIT_ATU, PRM_VG_ANT, PRM_VG_ATU, PRM_AP_ANT, PRM_AP_ATU, COD_OPERACAO, DATA_OPERACAO, COD_SUBGRUPO_TRANS, SIT_REGISTRO, COD_USUARIO, DATA_AVERBACAO, DATA_ADMISSAO, DATA_INCLUSAO, DATA_NASCIMENTO, DATA_FATURA, DATA_REFERENCIA, DATA_MOVIMENTO, COD_EMPRESA FROM SEGUROS.V0MOVIMENTO WHERE NUM_APOLICE = 0097010000889 AND COD_SUBGRUPO IN (1, 1948, 1949, 1950, 1951, 2910) AND DATA_REFERENCIA = :WHOST-DTREF AND COD_FONTE = 10 END-EXEC. */
            TMOVIMENTO = new VG0095B_TMOVIMENTO(true);
            string GetQuery_TMOVIMENTO()
            {
                var query = @$"SELECT 
							NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							COD_FONTE
							, 
							NUM_PROPOSTA
							, 
							TIPO_SEGURADO
							, 
							NUM_CERTIFICADO
							, 
							DAC_CERTIFICADO
							, 
							TIPO_INCLUSAO
							, 
							COD_CLIENTE
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
							PERI_PAGAMENTO
							, 
							PERI_RENOVACAO
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
							NUM_CTA_CORRENTE
							, 
							DAC_CTA_CORRENTE
							, 
							VAL_SALARIO
							, 
							TIPO_SALARIO
							, 
							TIPO_PLANO
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
							TAXA_VG
							, 
							IMP_MORNATU_ANT
							, 
							IMP_MORNATU_ATU
							, 
							IMP_MORACID_ANT
							, 
							IMP_MORACID_ATU
							, 
							IMP_INVPERM_ANT
							, 
							IMP_INVPERM_ATU
							, 
							IMP_AMDS_ANT
							, 
							IMP_AMDS_ATU
							, 
							IMP_DH_ANT
							, 
							IMP_DH_ATU
							, 
							IMP_DIT_ANT
							, 
							IMP_DIT_ATU
							, 
							PRM_VG_ANT
							, 
							PRM_VG_ATU
							, 
							PRM_AP_ANT
							, 
							PRM_AP_ATU
							, 
							COD_OPERACAO
							, 
							DATA_OPERACAO
							, 
							COD_SUBGRUPO_TRANS
							, 
							SIT_REGISTRO
							, 
							COD_USUARIO
							, 
							DATA_AVERBACAO
							, 
							DATA_ADMISSAO
							, 
							DATA_INCLUSAO
							, 
							DATA_NASCIMENTO
							, 
							DATA_FATURA
							, 
							DATA_REFERENCIA
							, 
							DATA_MOVIMENTO
							, 
							COD_EMPRESA 
							FROM SEGUROS.V0MOVIMENTO 
							WHERE NUM_APOLICE = 0097010000889 
							AND COD_SUBGRUPO IN 
							(1
							, 1948
							, 1949
							, 1950
							, 1951
							, 2910) 
							AND DATA_REFERENCIA = '{WHOST_DTREF}' 
							AND COD_FONTE = 10";

                return query;
            }
            TMOVIMENTO.GetQueryEvent += GetQuery_TMOVIMENTO;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -349- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM R0000_10_PRINCIPAL */

            R0000_10_PRINCIPAL();

        }

        [StopWatch]
        /*" R0000-10-PRINCIPAL */
        private void R0000_10_PRINCIPAL(bool isPerform = false)
        {
            /*" -353- PERFORM R0010-00-SELECIONA. */

            R0010_00_SELECIONA_SECTION();

            /*" -353- PERFORM R0000_10_PRINCIPAL_DB_CLOSE_1 */

            R0000_10_PRINCIPAL_DB_CLOSE_1();

            /*" -355- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -357- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WORK_AREA.WNR_EXEC_SQL);

        }

        [StopWatch]
        /*" R0000-10-PRINCIPAL-DB-CLOSE-1 */
        public void R0000_10_PRINCIPAL_DB_CLOSE_1()
        {
            /*" -353- EXEC SQL CLOSE TMOVIMENTO END-EXEC. */

            TMOVIMENTO.Close();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -363- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -363- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -366- DISPLAY '*** VG0095B - ' */
            _.Display($"*** VG0095B - ");

            /*" -367- DISPLAY 'LIDOS      V0MOVIMENTO      ' AC-LIDOS. */
            _.Display($"LIDOS      V0MOVIMENTO      {WORK_AREA.AC_LIDOS}");

            /*" -368- DISPLAY 'ATUALIZAD  V0MOVIMENTO      ' AC-ATUALIZADOS. */
            _.Display($"ATUALIZAD  V0MOVIMENTO      {WORK_AREA.AC_ATUALIZADOS}");

            /*" -370- DISPLAY 'REJEITADOS V0MOVIMENTO      ' AC-REJEITADOS. */
            _.Display($"REJEITADOS V0MOVIMENTO      {WORK_AREA.AC_REJEITADOS}");

            /*" -372- DISPLAY '*** VG0095B - TERMINO NORMAL ***' */
            _.Display($"*** VG0095B - TERMINO NORMAL ***");

            /*" -372- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -383- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM R0010_10_ABRE_CURSOR */

            R0010_10_ABRE_CURSOR();

        }

        [StopWatch]
        /*" R0010-10-ABRE-CURSOR */
        private void R0010_10_ABRE_CURSOR(bool isPerform = false)
        {
            /*" -387- MOVE '0010' TO WNR-EXEC-SQL. */
            _.Move("0010", WORK_AREA.WNR_EXEC_SQL);

            /*" -387- PERFORM R0010_10_ABRE_CURSOR_DB_OPEN_1 */

            R0010_10_ABRE_CURSOR_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0010-10-ABRE-CURSOR-DB-OPEN-1 */
        public void R0010_10_ABRE_CURSOR_DB_OPEN_1()
        {
            /*" -387- EXEC SQL OPEN TMOVIMENTO END-EXEC. */

            TMOVIMENTO.Open();

        }

        [StopWatch]
        /*" R0010-10-LEITURA */
        private void R0010_10_LEITURA(bool isPerform = false)
        {
            /*" -393- MOVE 'L010' TO WNR-EXEC-SQL. */
            _.Move("L010", WORK_AREA.WNR_EXEC_SQL);

            /*" -470- PERFORM R0010_10_LEITURA_DB_FETCH_1 */

            R0010_10_LEITURA_DB_FETCH_1();

            /*" -473- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -474- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -475- IF AC-LIDOS = 0 */

                    if (WORK_AREA.AC_LIDOS == 0)
                    {

                        /*" -476- DISPLAY '*** NENHUM REGISTRO SELECIONADO ***' */
                        _.Display($"*** NENHUM REGISTRO SELECIONADO ***");

                        /*" -477- GO TO R0010-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/ //GOTO
                        return;

                        /*" -478- ELSE */
                    }
                    else
                    {


                        /*" -479- GO TO R0010-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/ //GOTO
                        return;

                        /*" -480- ELSE */
                    }

                }
                else
                {


                    /*" -482- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -484- ADD 1 TO AC-LIDOS. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;

            /*" -490- PERFORM R0010_10_LEITURA_DB_SELECT_1 */

            R0010_10_LEITURA_DB_SELECT_1();

            /*" -493- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -494- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -495- MOVE 5 TO V0SEG-FONTE */
                    _.Move(5, V0SEG_FONTE);

                    /*" -496- ELSE */
                }
                else
                {


                    /*" -497- DISPLAY 'PROBLEMAS NO ACESSO A SEGVG ' MNUM-CERTIFICADO */
                    _.Display($"PROBLEMAS NO ACESSO A SEGVG {MNUM_CERTIFICADO}");

                    /*" -499- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -500- IF V0SEG-FONTE = 10 */

            if (V0SEG_FONTE == 10)
            {

                /*" -506- MOVE 5 TO V0SEG-FONTE. */
                _.Move(5, V0SEG_FONTE);
            }


            /*" -511- PERFORM R0010_10_LEITURA_DB_SELECT_2 */

            R0010_10_LEITURA_DB_SELECT_2();

            /*" -514- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -515- DISPLAY 'FONTE NAO ENCONTRADA ' V0SEG-FONTE */
                _.Display($"FONTE NAO ENCONTRADA {V0SEG_FONTE}");

                /*" -517- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -519- ADD 1 TO PROPAUTOM. */
            PROPAUTOM.Value = PROPAUTOM + 1;

            /*" -521- PERFORM R0020-00-UPDATE-MOVIMENTO. */

            R0020_00_UPDATE_MOVIMENTO_SECTION();

            /*" -526- PERFORM R0010_10_LEITURA_DB_UPDATE_1 */

            R0010_10_LEITURA_DB_UPDATE_1();

            /*" -529- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -530- DISPLAY 'PROBLEMA UPDATE DA V0FONTE ' V0SEG-FONTE */
                _.Display($"PROBLEMA UPDATE DA V0FONTE {V0SEG_FONTE}");

                /*" -531- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -531- PERFORM R0010-20-LOOP. */

            R0010_20_LOOP(true);

        }

        [StopWatch]
        /*" R0010-10-LEITURA-DB-FETCH-1 */
        public void R0010_10_LEITURA_DB_FETCH_1()
        {
            /*" -470- EXEC SQL FETCH TMOVIMENTO INTO :MNUM-APOLICE, :MCOD-SUBGRUPO, :MCOD-FONTE, :MNUM-PROPOSTA, :MTIPO-SEGURADO, :MNUM-CERTIFICADO, :MDAC-CERTIFICADO, :MTIPO-INCLUSAO, :MCOD-CLIENTE, :MCOD-AGENCIADOR, :MCOD-CORRETOR, :MCOD-PLANOVGAP, :MCOD-PLANOAP, :MFAIXA, :MAUTOR-AUM-AUTOMAT, :MTIPO-BENEFICIARIO, :MPERI-PAGAMENTO, :MPERI-RENOVACAO, :MCOD-OCUPACAO, :MESTADO-CIVIL, :MIDE-SEXO, :MCOD-PROFISSAO, :MNATURALIDADE, :MOCORR-ENDERECO, :MOCORR-END-COBRAN, :MBCO-COBRANCA, :MAGE-COBRANCA, :MDAC-COBRANCA, :MNUM-MATRICULA, :MNUM-CTA-CORRENTE, :MDAC-CTA-CORRENTE, :MVAL-SALARIO, :MTIPO-SALARIO, :MTIPO-PLANO, :MPCT-CONJUGE-VG, :MPCT-CONJUGE-AP, :MQTD-SAL-MORNATU, :MQTD-SAL-MORACID, :MQTD-SAL-INVPERM, :MTAXA-AP-MORACID, :MTAXA-AP-INVPERM, :MTAXA-AP-AMDS, :MTAXA-AP-DH, :MTAXA-AP-DIT, :MTAXA-VG, :MIMP-MORNATU-ANT, :MIMP-MORNATU-ATU, :MIMP-MORACID-ANT, :MIMP-MORACID-ATU, :MIMP-INVPERM-ANT, :MIMP-INVPERM-ATU, :MIMP-AMDS-ANT, :MIMP-AMDS-ATU, :MIMP-DH-ANT, :MIMP-DH-ATU, :MIMP-DIT-ANT, :MIMP-DIT-ATU, :MPRM-VG-ANT, :MPRM-VG-ATU, :MPRM-AP-ANT, :MPRM-AP-ATU, :MCOD-OPERACAO, :MDATA-OPERACAO, :COD-SUBGRUPO-TRANS, :MSIT-REGISTRO, :MCOD-USUARIO, :MDATA-AVERBACAO:WDATA-AVERBACAO, :MDATA-ADMISSAO:WDATA-ADMISSAO, :MDATA-INCLUSAO:WDATA-INCLUSAO, :MDATA-NASCIMENTO:WDATA-NASCIMENTO, :MDATA-FATURA:WDATA-FATURA, :MDATA-REFERENCIA:WDATA-REFERENCIA, :MDATA-MOVIMENTO:WDATA-MOVIMENTO, :MCOD-EMPRESA:WCOD-EMPRESA END-EXEC. */

            if (TMOVIMENTO.Fetch())
            {
                _.Move(TMOVIMENTO.MNUM_APOLICE, MNUM_APOLICE);
                _.Move(TMOVIMENTO.MCOD_SUBGRUPO, MCOD_SUBGRUPO);
                _.Move(TMOVIMENTO.MCOD_FONTE, MCOD_FONTE);
                _.Move(TMOVIMENTO.MNUM_PROPOSTA, MNUM_PROPOSTA);
                _.Move(TMOVIMENTO.MTIPO_SEGURADO, MTIPO_SEGURADO);
                _.Move(TMOVIMENTO.MNUM_CERTIFICADO, MNUM_CERTIFICADO);
                _.Move(TMOVIMENTO.MDAC_CERTIFICADO, MDAC_CERTIFICADO);
                _.Move(TMOVIMENTO.MTIPO_INCLUSAO, MTIPO_INCLUSAO);
                _.Move(TMOVIMENTO.MCOD_CLIENTE, MCOD_CLIENTE);
                _.Move(TMOVIMENTO.MCOD_AGENCIADOR, MCOD_AGENCIADOR);
                _.Move(TMOVIMENTO.MCOD_CORRETOR, MCOD_CORRETOR);
                _.Move(TMOVIMENTO.MCOD_PLANOVGAP, MCOD_PLANOVGAP);
                _.Move(TMOVIMENTO.MCOD_PLANOAP, MCOD_PLANOAP);
                _.Move(TMOVIMENTO.MFAIXA, MFAIXA);
                _.Move(TMOVIMENTO.MAUTOR_AUM_AUTOMAT, MAUTOR_AUM_AUTOMAT);
                _.Move(TMOVIMENTO.MTIPO_BENEFICIARIO, MTIPO_BENEFICIARIO);
                _.Move(TMOVIMENTO.MPERI_PAGAMENTO, MPERI_PAGAMENTO);
                _.Move(TMOVIMENTO.MPERI_RENOVACAO, MPERI_RENOVACAO);
                _.Move(TMOVIMENTO.MCOD_OCUPACAO, MCOD_OCUPACAO);
                _.Move(TMOVIMENTO.MESTADO_CIVIL, MESTADO_CIVIL);
                _.Move(TMOVIMENTO.MIDE_SEXO, MIDE_SEXO);
                _.Move(TMOVIMENTO.MCOD_PROFISSAO, MCOD_PROFISSAO);
                _.Move(TMOVIMENTO.MNATURALIDADE, MNATURALIDADE);
                _.Move(TMOVIMENTO.MOCORR_ENDERECO, MOCORR_ENDERECO);
                _.Move(TMOVIMENTO.MOCORR_END_COBRAN, MOCORR_END_COBRAN);
                _.Move(TMOVIMENTO.MBCO_COBRANCA, MBCO_COBRANCA);
                _.Move(TMOVIMENTO.MAGE_COBRANCA, MAGE_COBRANCA);
                _.Move(TMOVIMENTO.MDAC_COBRANCA, MDAC_COBRANCA);
                _.Move(TMOVIMENTO.MNUM_MATRICULA, MNUM_MATRICULA);
                _.Move(TMOVIMENTO.MNUM_CTA_CORRENTE, MNUM_CTA_CORRENTE);
                _.Move(TMOVIMENTO.MDAC_CTA_CORRENTE, MDAC_CTA_CORRENTE);
                _.Move(TMOVIMENTO.MVAL_SALARIO, MVAL_SALARIO);
                _.Move(TMOVIMENTO.MTIPO_SALARIO, MTIPO_SALARIO);
                _.Move(TMOVIMENTO.MTIPO_PLANO, MTIPO_PLANO);
                _.Move(TMOVIMENTO.MPCT_CONJUGE_VG, MPCT_CONJUGE_VG);
                _.Move(TMOVIMENTO.MPCT_CONJUGE_AP, MPCT_CONJUGE_AP);
                _.Move(TMOVIMENTO.MQTD_SAL_MORNATU, MQTD_SAL_MORNATU);
                _.Move(TMOVIMENTO.MQTD_SAL_MORACID, MQTD_SAL_MORACID);
                _.Move(TMOVIMENTO.MQTD_SAL_INVPERM, MQTD_SAL_INVPERM);
                _.Move(TMOVIMENTO.MTAXA_AP_MORACID, MTAXA_AP_MORACID);
                _.Move(TMOVIMENTO.MTAXA_AP_INVPERM, MTAXA_AP_INVPERM);
                _.Move(TMOVIMENTO.MTAXA_AP_AMDS, MTAXA_AP_AMDS);
                _.Move(TMOVIMENTO.MTAXA_AP_DH, MTAXA_AP_DH);
                _.Move(TMOVIMENTO.MTAXA_AP_DIT, MTAXA_AP_DIT);
                _.Move(TMOVIMENTO.MTAXA_VG, MTAXA_VG);
                _.Move(TMOVIMENTO.MIMP_MORNATU_ANT, MIMP_MORNATU_ANT);
                _.Move(TMOVIMENTO.MIMP_MORNATU_ATU, MIMP_MORNATU_ATU);
                _.Move(TMOVIMENTO.MIMP_MORACID_ANT, MIMP_MORACID_ANT);
                _.Move(TMOVIMENTO.MIMP_MORACID_ATU, MIMP_MORACID_ATU);
                _.Move(TMOVIMENTO.MIMP_INVPERM_ANT, MIMP_INVPERM_ANT);
                _.Move(TMOVIMENTO.MIMP_INVPERM_ATU, MIMP_INVPERM_ATU);
                _.Move(TMOVIMENTO.MIMP_AMDS_ANT, MIMP_AMDS_ANT);
                _.Move(TMOVIMENTO.MIMP_AMDS_ATU, MIMP_AMDS_ATU);
                _.Move(TMOVIMENTO.MIMP_DH_ANT, MIMP_DH_ANT);
                _.Move(TMOVIMENTO.MIMP_DH_ATU, MIMP_DH_ATU);
                _.Move(TMOVIMENTO.MIMP_DIT_ANT, MIMP_DIT_ANT);
                _.Move(TMOVIMENTO.MIMP_DIT_ATU, MIMP_DIT_ATU);
                _.Move(TMOVIMENTO.MPRM_VG_ANT, MPRM_VG_ANT);
                _.Move(TMOVIMENTO.MPRM_VG_ATU, MPRM_VG_ATU);
                _.Move(TMOVIMENTO.MPRM_AP_ANT, MPRM_AP_ANT);
                _.Move(TMOVIMENTO.MPRM_AP_ATU, MPRM_AP_ATU);
                _.Move(TMOVIMENTO.MCOD_OPERACAO, MCOD_OPERACAO);
                _.Move(TMOVIMENTO.MDATA_OPERACAO, MDATA_OPERACAO);
                _.Move(TMOVIMENTO.COD_SUBGRUPO_TRANS, COD_SUBGRUPO_TRANS);
                _.Move(TMOVIMENTO.MSIT_REGISTRO, MSIT_REGISTRO);
                _.Move(TMOVIMENTO.MCOD_USUARIO, MCOD_USUARIO);
                _.Move(TMOVIMENTO.MDATA_AVERBACAO, MDATA_AVERBACAO);
                _.Move(TMOVIMENTO.WDATA_AVERBACAO, WDATA_AVERBACAO);
                _.Move(TMOVIMENTO.MDATA_ADMISSAO, MDATA_ADMISSAO);
                _.Move(TMOVIMENTO.WDATA_ADMISSAO, WDATA_ADMISSAO);
                _.Move(TMOVIMENTO.MDATA_INCLUSAO, MDATA_INCLUSAO);
                _.Move(TMOVIMENTO.WDATA_INCLUSAO, WDATA_INCLUSAO);
                _.Move(TMOVIMENTO.MDATA_NASCIMENTO, MDATA_NASCIMENTO);
                _.Move(TMOVIMENTO.WDATA_NASCIMENTO, WDATA_NASCIMENTO);
                _.Move(TMOVIMENTO.MDATA_FATURA, MDATA_FATURA);
                _.Move(TMOVIMENTO.WDATA_FATURA, WDATA_FATURA);
                _.Move(TMOVIMENTO.MDATA_REFERENCIA, MDATA_REFERENCIA);
                _.Move(TMOVIMENTO.WDATA_REFERENCIA, WDATA_REFERENCIA);
                _.Move(TMOVIMENTO.MDATA_MOVIMENTO, MDATA_MOVIMENTO);
                _.Move(TMOVIMENTO.WDATA_MOVIMENTO, WDATA_MOVIMENTO);
                _.Move(TMOVIMENTO.MCOD_EMPRESA, MCOD_EMPRESA);
                _.Move(TMOVIMENTO.WCOD_EMPRESA, WCOD_EMPRESA);
            }

        }

        [StopWatch]
        /*" R0010-10-LEITURA-DB-SELECT-1 */
        public void R0010_10_LEITURA_DB_SELECT_1()
        {
            /*" -490- EXEC SQL SELECT COD_FONTE INTO :V0SEG-FONTE FROM SEGUROS.V0SEGURAVG WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND TIPO_SEGURADO = :MTIPO-SEGURADO END-EXEC. */

            var r0010_10_LEITURA_DB_SELECT_1_Query1 = new R0010_10_LEITURA_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
            };

            var executed_1 = R0010_10_LEITURA_DB_SELECT_1_Query1.Execute(r0010_10_LEITURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SEG_FONTE, V0SEG_FONTE);
            }


        }

        [StopWatch]
        /*" R0010-20-LOOP */
        private void R0010_20_LOOP(bool isPerform = false)
        {
            /*" -534- GO TO R0010-10-LEITURA. */

            R0010_10_LEITURA(); //GOTO
            return;

        }

        [StopWatch]
        /*" R0010-10-LEITURA-DB-UPDATE-1 */
        public void R0010_10_LEITURA_DB_UPDATE_1()
        {
            /*" -526- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0SEG-FONTE END-EXEC. */

            var r0010_10_LEITURA_DB_UPDATE_1_Update1 = new R0010_10_LEITURA_DB_UPDATE_1_Update1()
            {
                PROPAUTOM = PROPAUTOM.ToString(),
                V0SEG_FONTE = V0SEG_FONTE.ToString(),
            };

            R0010_10_LEITURA_DB_UPDATE_1_Update1.Execute(r0010_10_LEITURA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0010-10-LEITURA-DB-SELECT-2 */
        public void R0010_10_LEITURA_DB_SELECT_2()
        {
            /*" -511- EXEC SQL SELECT PROPAUTOM INTO :PROPAUTOM FROM SEGUROS.V0FONTE WHERE FONTE = :V0SEG-FONTE END-EXEC. */

            var r0010_10_LEITURA_DB_SELECT_2_Query1 = new R0010_10_LEITURA_DB_SELECT_2_Query1()
            {
                V0SEG_FONTE = V0SEG_FONTE.ToString(),
            };

            var executed_1 = R0010_10_LEITURA_DB_SELECT_2_Query1.Execute(r0010_10_LEITURA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPAUTOM, PROPAUTOM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-UPDATE-MOVIMENTO-SECTION */
        private void R0020_00_UPDATE_MOVIMENTO_SECTION()
        {
            /*" -542- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM R0020_10_UPDATE */

            R0020_10_UPDATE();

        }

        [StopWatch]
        /*" R0020-10-UPDATE */
        private void R0020_10_UPDATE(bool isPerform = false)
        {
            /*" -546- MOVE '0020' TO WNR-EXEC-SQL. */
            _.Move("0020", WORK_AREA.WNR_EXEC_SQL);

            /*" -553- PERFORM R0020_10_UPDATE_DB_UPDATE_1 */

            R0020_10_UPDATE_DB_UPDATE_1();

            /*" -556- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -557- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -558- DISPLAY '*** CERTIFICADO NAO ENCONTRADO *****' */
                    _.Display($"*** CERTIFICADO NAO ENCONTRADO *****");

                    /*" -559- DISPLAY '*** NUM CERTIFICADO = ' V0MOVIM-NRCERTIF */
                    _.Display($"*** NUM CERTIFICADO = {V0MOVIM_NRCERTIF}");

                    /*" -560- ADD 1 TO AC-REJEITADOS */
                    WORK_AREA.AC_REJEITADOS.Value = WORK_AREA.AC_REJEITADOS + 1;

                    /*" -561- GO TO R0020-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/ //GOTO
                    return;

                    /*" -562- ELSE */
                }
                else
                {


                    /*" -563- IF SQLCODE EQUAL -803 */

                    if (DB.SQLCODE == -803)
                    {

                        /*" -564- DISPLAY '*** CERTIFICADO DUPLICADO      *****' */
                        _.Display($"*** CERTIFICADO DUPLICADO      *****");

                        /*" -565- DISPLAY '*** NUM CERTIFICADO = ' V0MOVIM-NRCERTIF */
                        _.Display($"*** NUM CERTIFICADO = {V0MOVIM_NRCERTIF}");

                        /*" -566- ADD 1 TO AC-REJEITADOS */
                        WORK_AREA.AC_REJEITADOS.Value = WORK_AREA.AC_REJEITADOS + 1;

                        /*" -567- GO TO R0020-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/ //GOTO
                        return;

                        /*" -568- ELSE */
                    }
                    else
                    {


                        /*" -570- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -570- ADD 1 TO AC-ATUALIZADOS. */
            WORK_AREA.AC_ATUALIZADOS.Value = WORK_AREA.AC_ATUALIZADOS + 1;

        }

        [StopWatch]
        /*" R0020-10-UPDATE-DB-UPDATE-1 */
        public void R0020_10_UPDATE_DB_UPDATE_1()
        {
            /*" -553- EXEC SQL UPDATE SEGUROS.V0MOVIMENTO SET COD_FONTE = :V0SEG-FONTE, NUM_PROPOSTA = :PROPAUTOM WHERE COD_FONTE = :MCOD-FONTE AND NUM_PROPOSTA = :MNUM-PROPOSTA AND TIPO_SEGURADO= :MTIPO-SEGURADO END-EXEC. */

            var r0020_10_UPDATE_DB_UPDATE_1_Update1 = new R0020_10_UPDATE_DB_UPDATE_1_Update1()
            {
                V0SEG_FONTE = V0SEG_FONTE.ToString(),
                PROPAUTOM = PROPAUTOM.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
                MNUM_PROPOSTA = MNUM_PROPOSTA.ToString(),
                MCOD_FONTE = MCOD_FONTE.ToString(),
            };

            R0020_10_UPDATE_DB_UPDATE_1_Update1.Execute(r0020_10_UPDATE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -585- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WSQLCODE);

            /*" -587- DISPLAY WABEND */
            _.Display(WORK_AREA.DATA_SQL.WABEND);

            /*" -587- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -589- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -593- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -593- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}