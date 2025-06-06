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
using Sias.VidaEmGrupo.DB2.VG0130B;

namespace Code
{
    public class VG0130B
    {
        public bool IsCall { get; set; }

        public VG0130B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  AUMENTO DE CAPITAL COLETIVO        *      */
        /*"      *                             LEITURA TABELAS..: V1SEGURAVG      *      */
        /*"      *                                                V1MOEDA         *      */
        /*"      *                                                V1COBERAPOL     *      */
        /*"      *                                                V1RELATORIOS    *      */
        /*"      *                                                                *      */
        /*"      *                             GRAVACAO TABELAS.: V0MOVIMENTO     *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  PROCAS                             *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG0130B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  DEZEMBRO/ 91                       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      **********************************************************              */
        /*"      *  PROGRAMA ALTERADO EM 12/07/94                         *              */
        /*"      *  MOTIVO - MUDANCA DA MOEDA, DE CRUZEIRO REAL PARA REAL *              */
        /*"      *  CONTEUDO - BUSCAR A MOEDA USADA PARA IMPORTANCIA SEGU-*              */
        /*"      *             RADA/PREMIO DA V0HISTSEGVG                 *              */
        /*"      *  EFETUADO POR -   EDSON LUIZ NUNES GUIMARAES           *              */
        /*"      ******************************************************************      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 29/05/1998.   *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
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
        /*"77  SNUM-APOLICE               PIC S9(013)      COMP-3.*/
        public IntBasis SNUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  SCOD-SUBGRUPO              PIC S9(004)      COMP.*/
        public IntBasis SCOD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SNUM-CERTIFICADO           PIC S9(015)      COMP-3.*/
        public IntBasis SNUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  SDAC-CERTIFICADO           PIC  X(001).*/
        public StringBasis SDAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  STIPO-SEGURADO             PIC  X(001).*/
        public StringBasis STIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  SNUM-ITEM                  PIC S9(009)      COMP.*/
        public IntBasis SNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  STIPO-INCLUSAO             PIC  X(001).*/
        public StringBasis STIPO_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  SCOD-CLIENTE               PIC S9(009)      COMP.*/
        public IntBasis SCOD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  SCOD-FONTE                 PIC S9(004)      COMP.*/
        public IntBasis SCOD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SNUM-PROPOSTA              PIC S9(009)      COMP.*/
        public IntBasis SNUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  SCOD-AGENCIADOR            PIC S9(009)      COMP.*/
        public IntBasis SCOD_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  SCOD-CORRETOR              PIC S9(009)      COMP.*/
        public IntBasis SCOD_CORRETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  SCOD-PLANOVGAP             PIC S9(004)      COMP.*/
        public IntBasis SCOD_PLANOVGAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SCOD-PLANOAP               PIC S9(004)      COMP.*/
        public IntBasis SCOD_PLANOAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SFAIXA                     PIC S9(004)      COMP.*/
        public IntBasis SFAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SAUTOR-AUM-AUTOMAT         PIC  X(001).*/
        public StringBasis SAUTOR_AUM_AUTOMAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  STIPO-BENEFICIARIO         PIC  X(001).*/
        public StringBasis STIPO_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  SPERI-PAGAMENTO            PIC S9(004)      COMP.*/
        public IntBasis SPERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SPERI-RENOVACAO            PIC S9(004)      COMP.*/
        public IntBasis SPERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SNUM-CARNE                 PIC S9(004)      COMP.*/
        public IntBasis SNUM_CARNE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SCOD-OCUPACAO              PIC  X(004).*/
        public StringBasis SCOD_OCUPACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
        /*"77  SESTADO-CIVIL              PIC  X(001).*/
        public StringBasis SESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  SIDE-SEXO                  PIC  X(001).*/
        public StringBasis SIDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  SCOD-PROFISSAO             PIC S9(004)      COMP.*/
        public IntBasis SCOD_PROFISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SNATURALIDADE              PIC  X(030).*/
        public StringBasis SNATURALIDADE { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"77  SOCORR-ENDERECO            PIC S9(004)      COMP.*/
        public IntBasis SOCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SOCORR-END-COBRAN          PIC S9(004)      COMP.*/
        public IntBasis SOCORR_END_COBRAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SBCO-COBRANCA              PIC S9(004)      COMP.*/
        public IntBasis SBCO_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SAGE-COBRANCA              PIC S9(004)      COMP.*/
        public IntBasis SAGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SDAC-COBRANCA              PIC  X(001).*/
        public StringBasis SDAC_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  SNUM-MATRICULA             PIC S9(015)      COMP-3.*/
        public IntBasis SNUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  SVAL-SALARIO               PIC S9(013)V99   COMP-3.*/
        public DoubleBasis SVAL_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  STIPO-SALARIO              PIC  X(001).*/
        public StringBasis STIPO_SALARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  STIPO-PLANO                PIC  X(001).*/
        public StringBasis STIPO_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  SDATA-INIVIGENCIA          PIC  X(010).*/
        public StringBasis SDATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SPCT-CONJUGE-VG            PIC S9(003)V99   COMP-3.*/
        public DoubleBasis SPCT_CONJUGE_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  SPCT-CONJUGE-AP            PIC S9(003)V99   COMP-3.*/
        public DoubleBasis SPCT_CONJUGE_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  SQTD-SAL-MORNATU           PIC S9(004)      COMP.*/
        public IntBasis SQTD_SAL_MORNATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SQTD-SAL-MORACID           PIC S9(004)      COMP.*/
        public IntBasis SQTD_SAL_MORACID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SQTD-SAL-INVPERM           PIC S9(004)      COMP.*/
        public IntBasis SQTD_SAL_INVPERM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  STAXA-AP-MORACID           PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis STAXA_AP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  STAXA-AP-INVPERM           PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis STAXA_AP_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  STAXA-AP-AMDS              PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis STAXA_AP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  STAXA-AP-DH                PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis STAXA_AP_DH { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  STAXA-AP-DIT               PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis STAXA_AP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  STAXA-AP                   PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis STAXA_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  STAXA-VG                   PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis STAXA_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  SSIT-REGISTRO              PIC  X(001).*/
        public StringBasis SSIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  SDATA-ADMISSAO             PIC  X(010).*/
        public StringBasis SDATA_ADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SDATA-NASCIMENTO           PIC  X(010).*/
        public StringBasis SDATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SCOD-EMPRESA               PIC S9(009)      COMP.*/
        public IntBasis SCOD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  SDATA-ADMISSAO-I           PIC S9(004)      COMP.*/
        public IntBasis SDATA_ADMISSAO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SDATA-NASCIMENTO-I         PIC S9(004)      COMP.*/
        public IntBasis SDATA_NASCIMENTO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SOCORR-HISTORICO           PIC S9(004)      COMP.*/
        public IntBasis SOCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SCOD-EMPRESA-I             PIC S9(004)      COMP.*/
        public IntBasis SCOD_EMPRESA_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SLOT-EMP-SEGURADO          PIC  X(030).*/
        public StringBasis SLOT_EMP_SEGURADO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"77  R-IDSISTEM                PIC  X(002).*/
        public StringBasis R_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77  R-CODRELAT                PIC  X(008).*/
        public StringBasis R_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  R-NUM-APOLICE             PIC S9(013)        COMP-3.*/
        public IntBasis R_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  R-CODSUBES                PIC S9(004)        COMP.*/
        public IntBasis R_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  R-OPERACAO                PIC S9(004)        COMP.*/
        public IntBasis R_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  R-DATA-REFERENCIA         PIC  X(010).*/
        public StringBasis R_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  M-DATA-REFERENCIA         PIC  X(010).*/
        public StringBasis M_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  R-SITUACAO                PIC  X(001).*/
        public StringBasis R_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  R-PERI-RENOVACAO          PIC S9(004)        COMP.*/
        public IntBasis R_PERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  R-PCT-AUMENTO             PIC S9(003)V99     COMP-3.*/
        public DoubleBasis R_PCT_AUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  R-CODUSU                  PIC  X(008).*/
        public StringBasis R_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  R-CORRECAO                PIC  X(001).*/
        public StringBasis R_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          FONTE-PROPAUTOM          PIC S9(009)    COMP.*/
        public IntBasis FONTE_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  DVLCRUZAD-IMP             PIC S9(006)V9(9) COMP-3.*/
        public DoubleBasis DVLCRUZAD_IMP { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77  DVLCRUZAD-PRM             PIC S9(006)V9(9) COMP-3.*/
        public DoubleBasis DVLCRUZAD_PRM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77  FCOD-SUBGRUPO             PIC S9(004)      COMP.*/
        public IntBasis FCOD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  FDATA-REFERENCIA          PIC  X(010).*/
        public StringBasis FDATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  OCOD-CLIENTE              PIC S9(009)      COMP.*/
        public IntBasis OCOD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  ONUM-APOLICE              PIC S9(013)      COMP-3.*/
        public IntBasis ONUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  NUM-CTA-CORRENTE          PIC S9(013)      COMP-3.*/
        public IntBasis NUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  DAC-CTA-CORRENTE          PIC  X(001).*/
        public StringBasis DAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  NUM-FATURA                PIC S9(009)      COMP.*/
        public IntBasis NUM_FATURA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V1SISTEMA-DTMOVABE        PIC  X(010).*/
        public StringBasis V1SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V1PAR-RAMO-VG             PIC S9(009)      COMP.*/
        public IntBasis V1PAR_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V1PAR-RAMO-AP             PIC S9(009)      COMP.*/
        public IntBasis V1PAR_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  ECOD-MOEDA-IMP            PIC S9(004)      COMP.*/
        public IntBasis ECOD_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  ECOD-MOEDA-PRM            PIC S9(004)      COMP.*/
        public IntBasis ECOD_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  HNUM-APOLICE              PIC S9(013)      COMP-3.*/
        public IntBasis HNUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  HCOD-SUBGRUPO             PIC S9(004)      COMP.*/
        public IntBasis HCOD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  HNUM-ITEM                 PIC S9(009)      COMP.*/
        public IntBasis HNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  HDATA-MOVIMENTO           PIC  X(010).*/
        public StringBasis HDATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  XDATA-MOVIMENTO           PIC  X(010).*/
        public StringBasis XDATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  CNUM-APOLICE             PIC S9(013)      COMP-3.*/
        public IntBasis CNUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  CNRENDOS                 PIC S9(009)      COMP.*/
        public IntBasis CNRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  CNUM-ITEM                PIC S9(009)      COMP.*/
        public IntBasis CNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  COCORHIST                PIC S9(004)      COMP.*/
        public IntBasis COCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  CRAMOFR                  PIC S9(004)      COMP.*/
        public IntBasis CRAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  CMODALIFR                PIC S9(004)      COMP.*/
        public IntBasis CMODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  CCOD-COBERTURA           PIC S9(004)      COMP.*/
        public IntBasis CCOD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  CIMP-SEGURADA-IX         PIC S9(013)V99   COMP-3.*/
        public DoubleBasis CIMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  CPRM-TARIFARIO-IX        PIC S9(010)V9(5) COMP-3.*/
        public DoubleBasis CPRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77  CFATOR-MULTIPLICA        PIC S9(004)      COMP.*/
        public IntBasis CFATOR_MULTIPLICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  CDATA-INIVIGENCIA        PIC  X(010).*/
        public StringBasis CDATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  COD-SUBGRUPO-IN           PIC S9(004)      COMP.*/
        public IntBasis COD_SUBGRUPO_IN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  COD-SUBGRUPO-FI           PIC S9(004)      COMP.*/
        public IntBasis COD_SUBGRUPO_FI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77  WDATA-MOVIMENTO1          PIC S9(004)      COMP.*/
        public IntBasis WDATA_MOVIMENTO1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WCOD-EMPRESA              PIC S9(004)      COMP.*/
        public IntBasis WCOD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WNUM-ITEM                 PIC S9(004)      COMP.*/
        public IntBasis WNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  W-PCT-AUMENTO             PIC S9(003)V9(7) COMP-3 VALUE +0.*/
        public DoubleBasis W_PCT_AUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(7)"), 7);
        /*"77  WLOT-EMP-SEGURADO         PIC S9(004)      COMP.*/
        public IntBasis WLOT_EMP_SEGURADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  03        WSQLCODE3           PIC S9(009) COMP.*/
        public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"  03        AC-GRAVA            PIC  9(007) VALUE ZEROS.*/
        public IntBasis AC_GRAVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03        QTMES               PIC S9(005) COMP-3   VALUE +0.*/
        public IntBasis QTMES { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*"  03        RESTO               PIC S9(005) COMP-3   VALUE +0.*/
        public IntBasis RESTO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*"  03            WFIM-MOVIMENTO      PIC  X(001) VALUE 'N'.*/
        public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"  03            WFIM-INCLUSAO       PIC  X(001) VALUE 'N'.*/
        public StringBasis WFIM_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"  03            WFIM-SEGURAVG       PIC  X(001) VALUE 'N'.*/
        public StringBasis WFIM_SEGURAVG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"  03            TEM-MOVIMENTO       PIC  X(001) VALUE 'N'.*/
        public StringBasis TEM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"  03            TEM-COBERTURA       PIC  X(001) VALUE 'N'.*/
        public StringBasis TEM_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"  03            TEM-SEGURADO        PIC  X(001) VALUE 'N'.*/
        public StringBasis TEM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"  03            TEM-FATURA          PIC  X(001) VALUE 'N'.*/
        public StringBasis TEM_FATURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"  03            WS-W01DTSQL.*/
        public VG0130B_WS_W01DTSQL WS_W01DTSQL { get; set; } = new VG0130B_WS_W01DTSQL();
        public class VG0130B_WS_W01DTSQL : VarBasis
        {
            /*"    05          WS-W01AASQL         PIC  9(004).*/
            public IntBasis WS_W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05          WS-W01T1SQL         PIC  X(001) VALUE '-'.*/
            public StringBasis WS_W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"    05          WS-W01MMSQL         PIC  9(002).*/
            public IntBasis WS_W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05          WS-W01T2SQL         PIC  X(001) VALUE '-'.*/
            public StringBasis WS_W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"    05          WS-W01DDSQL         PIC  9(002).*/
            public IntBasis WS_W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03         WK-DATA1.*/
        }
        public VG0130B_WK_DATA1 WK_DATA1 { get; set; } = new VG0130B_WK_DATA1();
        public class VG0130B_WK_DATA1 : VarBasis
        {
            /*"    10       WK-ANO1           PIC  9(004).*/
            public IntBasis WK_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10       FILLER            PIC  X(001).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10       WK-MES1           PIC  9(002).*/
            public IntBasis WK_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       FILLER            PIC  X(001).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10       WK-DIA1           PIC  9(002).*/
            public IntBasis WK_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03         W01DTCSP          PIC  9(008)    VALUE ZEROS.*/
        }
        public IntBasis W01DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"  03         FILLER            REDEFINES      W01DTCSP.*/
        private _REDEF_VG0130B_FILLER_2 _filler_2 { get; set; }
        public _REDEF_VG0130B_FILLER_2 FILLER_2
        {
            get { _filler_2 = new _REDEF_VG0130B_FILLER_2(); _.Move(W01DTCSP, _filler_2); VarBasis.RedefinePassValue(W01DTCSP, _filler_2, W01DTCSP); _filler_2.ValueChanged += () => { _.Move(_filler_2, W01DTCSP); }; return _filler_2; }
            set { VarBasis.RedefinePassValue(value, _filler_2, W01DTCSP); }
        }  //Redefines
        public class _REDEF_VG0130B_FILLER_2 : VarBasis
        {
            /*"    10       W01DDCSP          PIC  9(002).*/
            public IntBasis W01DDCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       W01MMCSP          PIC  9(002).*/
            public IntBasis W01MMCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       W01AACSP          PIC  9(004).*/
            public IntBasis W01AACSP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03         W02DTCSP          PIC  9(008)    VALUE ZEROS.*/

            public _REDEF_VG0130B_FILLER_2()
            {
                W01DDCSP.ValueChanged += OnValueChanged;
                W01MMCSP.ValueChanged += OnValueChanged;
                W01AACSP.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis W02DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"  03         FILLER            REDEFINES      W02DTCSP.*/
        private _REDEF_VG0130B_FILLER_3 _filler_3 { get; set; }
        public _REDEF_VG0130B_FILLER_3 FILLER_3
        {
            get { _filler_3 = new _REDEF_VG0130B_FILLER_3(); _.Move(W02DTCSP, _filler_3); VarBasis.RedefinePassValue(W02DTCSP, _filler_3, W02DTCSP); _filler_3.ValueChanged += () => { _.Move(_filler_3, W02DTCSP); }; return _filler_3; }
            set { VarBasis.RedefinePassValue(value, _filler_3, W02DTCSP); }
        }  //Redefines
        public class _REDEF_VG0130B_FILLER_3 : VarBasis
        {
            /*"    10       W02DDCSP          PIC  9(002).*/
            public IntBasis W02DDCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       W02MMCSP          PIC  9(002).*/
            public IntBasis W02MMCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       W02AACSP          PIC  9(004).*/
            public IntBasis W02AACSP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03         WNUMFAT           PIC  9(006)    VALUE ZEROS.*/

            public _REDEF_VG0130B_FILLER_3()
            {
                W02DDCSP.ValueChanged += OnValueChanged;
                W02MMCSP.ValueChanged += OnValueChanged;
                W02AACSP.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WNUMFAT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"  03         FILLER            REDEFINES      WNUMFAT.*/
        private _REDEF_VG0130B_FILLER_4 _filler_4 { get; set; }
        public _REDEF_VG0130B_FILLER_4 FILLER_4
        {
            get { _filler_4 = new _REDEF_VG0130B_FILLER_4(); _.Move(WNUMFAT, _filler_4); VarBasis.RedefinePassValue(WNUMFAT, _filler_4, WNUMFAT); _filler_4.ValueChanged += () => { _.Move(_filler_4, WNUMFAT); }; return _filler_4; }
            set { VarBasis.RedefinePassValue(value, _filler_4, WNUMFAT); }
        }  //Redefines
        public class _REDEF_VG0130B_FILLER_4 : VarBasis
        {
            /*"    10       WNUMFAT-ANO       PIC  9(004).*/
            public IntBasis WNUMFAT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10       WNUMFAT-MES       PIC  9(002).*/
            public IntBasis WNUMFAT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03        WPRMTOT                  PIC S9(013)V99                                        VALUE +0 COMP-3.*/

            public _REDEF_VG0130B_FILLER_4()
            {
                WNUMFAT_ANO.ValueChanged += OnValueChanged;
                WNUMFAT_MES.ValueChanged += OnValueChanged;
            }

        }
        public DoubleBasis WPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"  03        AC-EMITIDOS              PIC  9(007) VALUE 0.*/
        public IntBasis AC_EMITIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03        AC-SOLICITADOS           PIC  9(007) VALUE 0.*/
        public IntBasis AC_SOLICITADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03        W-LIDOS                  PIC  9(007) VALUE 0.*/
        public IntBasis W_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03        W-GRAVADOS               PIC  9(007) VALUE 0.*/
        public IntBasis W_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03        FILLER.*/
        public VG0130B_FILLER_5 FILLER_5 { get; set; } = new VG0130B_FILLER_5();
        public class VG0130B_FILLER_5 : VarBasis
        {
            /*"    05      FLAG-FIM-RELATORIO       PIC  9(001) VALUE 0.*/

            public SelectorBasis FLAG_FIM_RELATORIO { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88    FIM-RELATORIO            VALUE 1. */
							new SelectorItemBasis("FIM_RELATORIO", "1")
                }
            };

            /*"    05      FLAG-EXISTE-REL          PIC  9(001) VALUE 0.*/

            public SelectorBasis FLAG_EXISTE_REL { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88    HOUVE-RELATORIO          VALUE 1. */
							new SelectorItemBasis("HOUVE_RELATORIO", "1")
                }
            };

            /*"    05      FLAG-DEBITOS             PIC  9(001) VALUE 0.*/

            public SelectorBasis FLAG_DEBITOS { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88    HOUVE-DEBITOS            VALUE 1. */
							new SelectorItemBasis("HOUVE_DEBITOS", "1")
                }
            };

            /*"    05      FLAG-SEGURAVG            PIC  9(001) VALUE 0.*/

            public SelectorBasis FLAG_SEGURAVG { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88    HOUVE-SEGURAVG           VALUE 1. */
							new SelectorItemBasis("HOUVE_SEGURAVG", "1")
                }
            };

            /*"  03        WABEND.*/
        }
        public VG0130B_WABEND WABEND { get; set; } = new VG0130B_WABEND();
        public class VG0130B_WABEND : VarBasis
        {
            /*"    05      FILLER              PIC  X(010) VALUE           ' VG0130B'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0130B");
            /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
            /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
            /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
            /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"  01        LK-LINK.*/
        }
        public VG0130B_LK_LINK LK_LINK { get; set; } = new VG0130B_LK_LINK();
        public class VG0130B_LK_LINK : VarBasis
        {
            /*"      05     LK-DATA1          PIC  9(008).*/
            public IntBasis LK_DATA1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"      05     LK-DATA2          PIC  9(008).*/
            public IntBasis LK_DATA2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"      05     QTDIA             PIC S9(005)          COMP-3.*/
            public IntBasis QTDIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        }


        public VG0130B_RELATORIO RELATORIO { get; set; } = new VG0130B_RELATORIO();
        public VG0130B_TSEGURAVG TSEGURAVG { get; set; } = new VG0130B_TSEGURAVG();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL */

                M_000_000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL */
        private void M_000_000_PRINCIPAL(bool isPerform = false)
        {
            /*" -411- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -413- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -415- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -419- PERFORM 030-000-LER-TSISTEMA. */

            M_030_000_LER_TSISTEMA_SECTION();

            /*" -421- PERFORM 040-000-LER-V1PARAMRAMO. */

            M_040_000_LER_V1PARAMRAMO_SECTION();

            /*" -421- PERFORM 010-000-INICIO-PROCESSO. */

            M_010_000_INICIO_PROCESSO(true);

        }

        [StopWatch]
        /*" M-010-000-INICIO-PROCESSO */
        private void M_010_000_INICIO_PROCESSO(bool isPerform = false)
        {
            /*" -426- PERFORM 050-000-DECLARA-RELATORIO. */

            M_050_000_DECLARA_RELATORIO_SECTION();

            /*" -427- PERFORM 060-000-FETCH-RELATORIO. */

            M_060_000_FETCH_RELATORIO_SECTION();

            /*" -430- PERFORM 020-000-PROCESSA UNTIL FIM-RELATORIO. */

            while (!(FILLER_5.FLAG_FIM_RELATORIO["FIM_RELATORIO"]))
            {

                M_020_000_PROCESSA_SECTION();
            }

            /*" -431- IF HOUVE-RELATORIO */

            if (FILLER_5.FLAG_EXISTE_REL["HOUVE_RELATORIO"])
            {

                /*" -432- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -433- DISPLAY ' PROGRAMA VG0130B ' */
                _.Display($" PROGRAMA VG0130B ");

                /*" -434- DISPLAY ' TOTAL DE SOLICITACAO          = ' AC-SOLICITADOS */
                _.Display($" TOTAL DE SOLICITACAO          = {AC_SOLICITADOS}");

                /*" -435- DISPLAY ' TOTAL DE SEGURADOS PROCESADOS = ' AC-EMITIDOS */
                _.Display($" TOTAL DE SEGURADOS PROCESADOS = {AC_EMITIDOS}");

                /*" -436- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -437- DISPLAY ' ' */
                _.Display($" ");

                /*" -438- ELSE */
            }
            else
            {


                /*" -440- DISPLAY '------------------------------------------------- '--------------------------' */
                _.Display($"------------------------------------------------- --------------------------");

                /*" -442- DISPLAY ' VG0130B - NAO HOUVE SELECAO DE SOLICITACAO NEST 'A DATA - ' V1SISTEMA-DTMOVABE */

                $" VG0130B - NAO HOUVE SELECAO DE SOLICITACAO NEST ADATA-{V1SISTEMA_DTMOVABE}"
                .Display();

                /*" -444- DISPLAY '------------------------------------------------- '--------------------------' */
                _.Display($"------------------------------------------------- --------------------------");

                /*" -446- DISPLAY ' ' */
                _.Display($" ");

                /*" -446- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();
            }


            /*" -448- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

        }

        [StopWatch]
        /*" M-020-000-PROCESSA-SECTION */
        private void M_020_000_PROCESSA_SECTION()
        {
            /*" -455- PERFORM 070-000-VE-FATURAS. */

            M_070_000_VE_FATURAS_SECTION();

            /*" -456- IF TEM-FATURA EQUAL 'N' */

            if (TEM_FATURA == "N")
            {

                /*" -457- PERFORM 090-000-CURSOR-V1SEGURAVG */

                M_090_000_CURSOR_V1SEGURAVG_SECTION();

                /*" -460- PERFORM 100-000-FETCH-V1SEGURAVG UNTIL WFIM-SEGURAVG EQUAL 'S' . */

                while (!(WFIM_SEGURAVG == "S"))
                {

                    M_100_000_FETCH_V1SEGURAVG_SECTION();
                }
            }


            /*" -461- IF HOUVE-SEGURAVG */

            if (FILLER_5.FLAG_SEGURAVG["HOUVE_SEGURAVG"])
            {

                /*" -462- PERFORM 700-000-UPDATE */

                M_700_000_UPDATE_SECTION();

                /*" -463- ELSE */
            }
            else
            {


                /*" -465- DISPLAY '------------------------------------------------- '---------------------------------------' */
                _.Display($"------------------------------------------------- ---------------------------------------");

                /*" -467- DISPLAY ' VG0130B - NAO HOUVE SELECAO DE AUMENTO DE CAPITA 'L COLETIVO OU EXISTE FATURA PENDENTE  ' */

                $" VG0130B - NAO HOUVE SELECAO DE AUMENTO DE CAPITA LCOLETIVOOUEXISTEFATURAPENDENTE"
                .Display();

                /*" -468- DISPLAY ' VG0130B - PROGRAMA NAO PROCESSADO    ' */
                _.Display($" VG0130B - PROGRAMA NAO PROCESSADO    ");

                /*" -469- DISPLAY '   DATA DE REFERENCIA = ' R-DATA-REFERENCIA */
                _.Display($"   DATA DE REFERENCIA = {R_DATA_REFERENCIA}");

                /*" -470- DISPLAY '   NUMERO DA APOLICE  = ' R-NUM-APOLICE */
                _.Display($"   NUMERO DA APOLICE  = {R_NUM_APOLICE}");

                /*" -472- DISPLAY '------------------------------------------------- '---------------------------------------' */
                _.Display($"------------------------------------------------- ---------------------------------------");

                /*" -474- DISPLAY ' ' . */
                _.Display($" ");
            }


            /*" -474- PERFORM 060-000-FETCH-RELATORIO. */

            M_060_000_FETCH_RELATORIO_SECTION();

        }

        [StopWatch]
        /*" M-030-000-LER-TSISTEMA-SECTION */
        private void M_030_000_LER_TSISTEMA_SECTION()
        {
            /*" -485- MOVE '030-000-LER-TSISTEMA' TO PARAGRAFO. */
            _.Move("030-000-LER-TSISTEMA", WABEND.PARAGRAFO);

            /*" -487- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", WABEND.WNR_EXEC_SQL);

            /*" -493- PERFORM M_030_000_LER_TSISTEMA_DB_SELECT_1 */

            M_030_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -496- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -497- DISPLAY 'VG0130B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"VG0130B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -498- DISPLAY 'IDSISTEM =  VG ' */
                _.Display($"IDSISTEM =  VG ");

                /*" -500- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -501- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -502- DISPLAY 'VG0130B - ERRO NA LEITURA NA V1SISTEMA  ' */
                _.Display($"VG0130B - ERRO NA LEITURA NA V1SISTEMA  ");

                /*" -502- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-030-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_030_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -493- EXEC SQL SELECT DTMOVABE INTO :V1SISTEMA-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

            var m_030_000_LER_TSISTEMA_DB_SELECT_1_Query1 = new M_030_000_LER_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_030_000_LER_TSISTEMA_DB_SELECT_1_Query1.Execute(m_030_000_LER_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SISTEMA_DTMOVABE, V1SISTEMA_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-040-000-LER-V1PARAMRAMO-SECTION */
        private void M_040_000_LER_V1PARAMRAMO_SECTION()
        {
            /*" -517- MOVE '040-000-LER-V1PARAMRAMO' TO PARAGRAFO. */
            _.Move("040-000-LER-V1PARAMRAMO", WABEND.PARAGRAFO);

            /*" -519- MOVE '040' TO WNR-EXEC-SQL. */
            _.Move("040", WABEND.WNR_EXEC_SQL);

            /*" -523- PERFORM M_040_000_LER_V1PARAMRAMO_DB_SELECT_1 */

            M_040_000_LER_V1PARAMRAMO_DB_SELECT_1();

            /*" -526- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -527- DISPLAY 'VG0130B - NAO CONSTA REGISTRO NA V1PARAMRAMO' */
                _.Display($"VG0130B - NAO CONSTA REGISTRO NA V1PARAMRAMO");

                /*" -529- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -530- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -531- DISPLAY 'VG0130B - ERRO NA LEITURA NA V1PARAMRAMO' */
                _.Display($"VG0130B - ERRO NA LEITURA NA V1PARAMRAMO");

                /*" -531- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-040-000-LER-V1PARAMRAMO-DB-SELECT-1 */
        public void M_040_000_LER_V1PARAMRAMO_DB_SELECT_1()
        {
            /*" -523- EXEC SQL SELECT RAMO_VG, RAMO_AP INTO :V1PAR-RAMO-VG, :V1PAR-RAMO-AP FROM SEGUROS.V1PARAMRAMO END-EXEC. */

            var m_040_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1 = new M_040_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_040_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1.Execute(m_040_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PAR_RAMO_VG, V1PAR_RAMO_VG);
                _.Move(executed_1.V1PAR_RAMO_AP, V1PAR_RAMO_AP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_040_999_EXIT*/

        [StopWatch]
        /*" M-050-000-DECLARA-RELATORIO-SECTION */
        private void M_050_000_DECLARA_RELATORIO_SECTION()
        {
            /*" -546- MOVE '050-000-DECLARA-RELATORIO' TO PARAGRAFO. */
            _.Move("050-000-DECLARA-RELATORIO", WABEND.PARAGRAFO);

            /*" -548- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", WABEND.WNR_EXEC_SQL);

            /*" -566- PERFORM M_050_000_DECLARA_RELATORIO_DB_DECLARE_1 */

            M_050_000_DECLARA_RELATORIO_DB_DECLARE_1();

            /*" -569- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -570- DISPLAY 'VG0130B - ERRO NO DECLARE NA V1RELATORIO' */
                _.Display($"VG0130B - ERRO NO DECLARE NA V1RELATORIO");

                /*" -572- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -573- PERFORM M_050_000_DECLARA_RELATORIO_DB_OPEN_1 */

            M_050_000_DECLARA_RELATORIO_DB_OPEN_1();

            /*" -576- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -577- DISPLAY 'VG0130B - ERRO NO OPEN NA V1RELATORIO' */
                _.Display($"VG0130B - ERRO NO OPEN NA V1RELATORIO");

                /*" -577- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-050-000-DECLARA-RELATORIO-DB-DECLARE-1 */
        public void M_050_000_DECLARA_RELATORIO_DB_DECLARE_1()
        {
            /*" -566- EXEC SQL DECLARE RELATORIO CURSOR FOR SELECT IDSISTEM, CODRELAT, NUM_APOLICE, CODSUBES, OPERACAO, DATA_REFERENCIA, SITUACAO, PERI_RENOVACAO, PCT_AUMENTO, CODUSU, CORRECAO FROM SEGUROS.V1RELATORIOS WHERE IDSISTEM = 'VG' AND SITUACAO = '0' AND CODRELAT = 'VG0130B' AND NUM_APOLICE = 97010000889 END-EXEC. */
            RELATORIO = new VG0130B_RELATORIO(false);
            string GetQuery_RELATORIO()
            {
                var query = @$"SELECT IDSISTEM
							, 
							CODRELAT
							, 
							NUM_APOLICE
							, 
							CODSUBES
							, 
							OPERACAO
							, 
							DATA_REFERENCIA
							, 
							SITUACAO
							, 
							PERI_RENOVACAO
							, 
							PCT_AUMENTO
							, 
							CODUSU
							, 
							CORRECAO 
							FROM SEGUROS.V1RELATORIOS 
							WHERE IDSISTEM = 'VG' 
							AND SITUACAO = '0' 
							AND CODRELAT = 'VG0130B' 
							AND NUM_APOLICE = 97010000889";

                return query;
            }
            RELATORIO.GetQueryEvent += GetQuery_RELATORIO;

        }

        [StopWatch]
        /*" M-050-000-DECLARA-RELATORIO-DB-OPEN-1 */
        public void M_050_000_DECLARA_RELATORIO_DB_OPEN_1()
        {
            /*" -573- EXEC SQL OPEN RELATORIO END-EXEC. */

            RELATORIO.Open();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1SEGURAVG-DB-DECLARE-1 */
        public void M_090_000_CURSOR_V1SEGURAVG_DB_DECLARE_1()
        {
            /*" -779- EXEC SQL DECLARE TSEGURAVG CURSOR FOR SELECT NUM_APOLICE, COD_SUBGRUPO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_SEGURADO, NUM_ITEM, TIPO_INCLUSAO, COD_CLIENTE, COD_FONTE, NUM_PROPOSTA, COD_AGENCIADOR, COD_CORRETOR, COD_PLANOVGAP, COD_PLANOAP, FAIXA, AUTOR_AUM_AUTOMAT, TIPO_BENEFICIARIO, OCORR_HISTORICO, PERI_PAGAMENTO, PERI_RENOVACAO, NUM_CARNE, COD_OCUPACAO, ESTADO_CIVIL, IDE_SEXO, COD_PROFISSAO, NATURALIDADE, OCORR_ENDERECO, OCORR_END_COBRAN, BCO_COBRANCA, AGE_COBRANCA, DAC_COBRANCA, NUM_MATRICULA, VAL_SALARIO, TIPO_SALARIO, TIPO_PLANO, DATA_INIVIGENCIA, PCT_CONJUGE_VG, PCT_CONJUGE_AP, QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_AP, TAXA_VG, SIT_REGISTRO, DATA_ADMISSAO, DATA_NASCIMENTO, OCORR_HISTORICO, COD_EMPRESA, LOT_EMP_SEGURADO FROM SEGUROS.V1SEGURAVG WHERE NUM_APOLICE = :R-NUM-APOLICE AND COD_SUBGRUPO >= :COD-SUBGRUPO-IN AND COD_SUBGRUPO <= :COD-SUBGRUPO-FI AND SIT_REGISTRO = '0' AND AUTOR_AUM_AUTOMAT = 'S' END-EXEC. */
            TSEGURAVG = new VG0130B_TSEGURAVG(true);
            string GetQuery_TSEGURAVG()
            {
                var query = @$"SELECT 
							NUM_APOLICE
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
							OCORR_HISTORICO
							, 
							COD_EMPRESA
							, 
							LOT_EMP_SEGURADO 
							FROM SEGUROS.V1SEGURAVG 
							WHERE 
							NUM_APOLICE = '{R_NUM_APOLICE}' AND 
							COD_SUBGRUPO >= '{COD_SUBGRUPO_IN}' AND 
							COD_SUBGRUPO <= '{COD_SUBGRUPO_FI}' AND 
							SIT_REGISTRO = '0' AND 
							AUTOR_AUM_AUTOMAT = 'S'";

                return query;
            }
            TSEGURAVG.GetQueryEvent += GetQuery_TSEGURAVG;

        }

        [StopWatch]
        /*" M-060-000-FETCH-RELATORIO-SECTION */
        private void M_060_000_FETCH_RELATORIO_SECTION()
        {
            /*" -588- MOVE '060-000-FETCH-RELATORIO' TO PARAGRAFO. */
            _.Move("060-000-FETCH-RELATORIO", WABEND.PARAGRAFO);

            /*" -590- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", WABEND.WNR_EXEC_SQL);

            /*" -602- PERFORM M_060_000_FETCH_RELATORIO_DB_FETCH_1 */

            M_060_000_FETCH_RELATORIO_DB_FETCH_1();

            /*" -605- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -606- IF SQLCODE NOT EQUAL +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -607- DISPLAY 'ATENCAO -----------------------------------' */
                    _.Display($"ATENCAO -----------------------------------");

                    /*" -608- DISPLAY '    VG0130BB - ERRO NO FETCH DO RELATORIOS ' */
                    _.Display($"    VG0130BB - ERRO NO FETCH DO RELATORIOS ");

                    /*" -609- DISPLAY '-------------------------------------------' */
                    _.Display($"-------------------------------------------");

                    /*" -610- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -611- ELSE */
                }
                else
                {


                    /*" -612- MOVE 1 TO FLAG-FIM-RELATORIO */
                    _.Move(1, FILLER_5.FLAG_FIM_RELATORIO);

                    /*" -613- ELSE */
                }

            }
            else
            {


                /*" -614- MOVE 1 TO FLAG-EXISTE-REL */
                _.Move(1, FILLER_5.FLAG_EXISTE_REL);

                /*" -614- ADD 1 TO AC-SOLICITADOS. */
                AC_SOLICITADOS.Value = AC_SOLICITADOS + 1;
            }


        }

        [StopWatch]
        /*" M-060-000-FETCH-RELATORIO-DB-FETCH-1 */
        public void M_060_000_FETCH_RELATORIO_DB_FETCH_1()
        {
            /*" -602- EXEC SQL FETCH RELATORIO INTO :R-IDSISTEM, :R-CODRELAT, :R-NUM-APOLICE, :R-CODSUBES, :R-OPERACAO, :R-DATA-REFERENCIA, :R-SITUACAO, :R-PERI-RENOVACAO, :R-PCT-AUMENTO, :R-CODUSU, :R-CORRECAO END-EXEC. */

            if (RELATORIO.Fetch())
            {
                _.Move(RELATORIO.R_IDSISTEM, R_IDSISTEM);
                _.Move(RELATORIO.R_CODRELAT, R_CODRELAT);
                _.Move(RELATORIO.R_NUM_APOLICE, R_NUM_APOLICE);
                _.Move(RELATORIO.R_CODSUBES, R_CODSUBES);
                _.Move(RELATORIO.R_OPERACAO, R_OPERACAO);
                _.Move(RELATORIO.R_DATA_REFERENCIA, R_DATA_REFERENCIA);
                _.Move(RELATORIO.R_SITUACAO, R_SITUACAO);
                _.Move(RELATORIO.R_PERI_RENOVACAO, R_PERI_RENOVACAO);
                _.Move(RELATORIO.R_PCT_AUMENTO, R_PCT_AUMENTO);
                _.Move(RELATORIO.R_CODUSU, R_CODUSU);
                _.Move(RELATORIO.R_CORRECAO, R_CORRECAO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_060_999_EXIT*/

        [StopWatch]
        /*" M-070-000-VE-FATURAS-SECTION */
        private void M_070_000_VE_FATURAS_SECTION()
        {
            /*" -628- MOVE '070-000-VE-FATURAS     ' TO PARAGRAFO. */
            _.Move("070-000-VE-FATURAS     ", WABEND.PARAGRAFO);

            /*" -634- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", WABEND.WNR_EXEC_SQL);

            /*" -636- MOVE 'N' TO TEM-FATURA. */
            _.Move("N", TEM_FATURA);

            /*" -637- IF R-CORRECAO EQUAL '4' */

            if (R_CORRECAO == "4")
            {

                /*" -638- MOVE R-CODSUBES TO FCOD-SUBGRUPO */
                _.Move(R_CODSUBES, FCOD_SUBGRUPO);

                /*" -639- ELSE */
            }
            else
            {


                /*" -641- MOVE 0 TO FCOD-SUBGRUPO. */
                _.Move(0, FCOD_SUBGRUPO);
            }


            /*" -651- PERFORM M_070_000_VE_FATURAS_DB_SELECT_1 */

            M_070_000_VE_FATURAS_DB_SELECT_1();

            /*" -654- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -656- DISPLAY 'VG0130B - NAO EXISTE CONTROLE DE FATURAS  ' R-NUM-APOLICE */
                _.Display($"VG0130B - NAO EXISTE CONTROLE DE FATURAS  {R_NUM_APOLICE}");

                /*" -658- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -659- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -660- DISPLAY 'VG0130B - ERRO NO SELECT DA V1FATURCONT ' */
                _.Display($"VG0130B - ERRO NO SELECT DA V1FATURCONT ");

                /*" -662- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -663- MOVE FDATA-REFERENCIA TO WK-DATA1. */
            _.Move(FDATA_REFERENCIA, WK_DATA1);

            /*" -664- MOVE WK-ANO1 TO WNUMFAT-ANO. */
            _.Move(WK_DATA1.WK_ANO1, FILLER_4.WNUMFAT_ANO);

            /*" -665- MOVE WK-MES1 TO WNUMFAT-MES. */
            _.Move(WK_DATA1.WK_MES1, FILLER_4.WNUMFAT_MES);

            /*" -667- MOVE WNUMFAT TO NUM-FATURA. */
            _.Move(WNUMFAT, NUM_FATURA);

            /*" -678- PERFORM M_070_000_VE_FATURAS_DB_SELECT_2 */

            M_070_000_VE_FATURAS_DB_SELECT_2();

            /*" -682- IF SQLCODE EQUAL 100 NEXT SENTENCE */

            if (DB.SQLCODE == 100)
            {

                /*" -683- ELSE */
            }
            else
            {


                /*" -684- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -685- DISPLAY 'VG0130B - ERRO NO SELECT DA V1FATURAS   ' */
                    _.Display($"VG0130B - ERRO NO SELECT DA V1FATURAS   ");

                    /*" -686- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -687- ELSE */
                }
                else
                {


                    /*" -687- MOVE 'S' TO TEM-FATURA. */
                    _.Move("S", TEM_FATURA);
                }

            }


        }

        [StopWatch]
        /*" M-070-000-VE-FATURAS-DB-SELECT-1 */
        public void M_070_000_VE_FATURAS_DB_SELECT_1()
        {
            /*" -651- EXEC SQL SELECT DATA_REFERENCIA INTO :FDATA-REFERENCIA FROM SEGUROS.V1FATURCONT WHERE NUM_APOLICE = :R-NUM-APOLICE AND COD_SUBGRUPO = :FCOD-SUBGRUPO END-EXEC. */

            var m_070_000_VE_FATURAS_DB_SELECT_1_Query1 = new M_070_000_VE_FATURAS_DB_SELECT_1_Query1()
            {
                R_NUM_APOLICE = R_NUM_APOLICE.ToString(),
                FCOD_SUBGRUPO = FCOD_SUBGRUPO.ToString(),
            };

            var executed_1 = M_070_000_VE_FATURAS_DB_SELECT_1_Query1.Execute(m_070_000_VE_FATURAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FDATA_REFERENCIA, FDATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_070_999_EXIT*/

        [StopWatch]
        /*" M-070-000-VE-FATURAS-DB-SELECT-2 */
        public void M_070_000_VE_FATURAS_DB_SELECT_2()
        {
            /*" -678- EXEC SQL SELECT NUM_FATURA INTO :NUM-FATURA FROM SEGUROS.V1FATURAS WHERE NUM_APOLICE = :R-NUM-APOLICE AND COD_SUBGRUPO = :FCOD-SUBGRUPO AND NUM_FATURA = :NUM-FATURA END-EXEC. */

            var m_070_000_VE_FATURAS_DB_SELECT_2_Query1 = new M_070_000_VE_FATURAS_DB_SELECT_2_Query1()
            {
                R_NUM_APOLICE = R_NUM_APOLICE.ToString(),
                FCOD_SUBGRUPO = FCOD_SUBGRUPO.ToString(),
                NUM_FATURA = NUM_FATURA.ToString(),
            };

            var executed_1 = M_070_000_VE_FATURAS_DB_SELECT_2_Query1.Execute(m_070_000_VE_FATURAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_FATURA, NUM_FATURA);
            }


        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1SEGURAVG-SECTION */
        private void M_090_000_CURSOR_V1SEGURAVG_SECTION()
        {
            /*" -704- MOVE '090-000-CURSOR-V1SEGURAVG' TO PARAGRAFO */
            _.Move("090-000-CURSOR-V1SEGURAVG", WABEND.PARAGRAFO);

            /*" -706- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -707- IF R-CODSUBES EQUAL 0 */

            if (R_CODSUBES == 0)
            {

                /*" -708- MOVE 0 TO COD-SUBGRUPO-IN */
                _.Move(0, COD_SUBGRUPO_IN);

                /*" -709- MOVE 9999 TO COD-SUBGRUPO-FI */
                _.Move(9999, COD_SUBGRUPO_FI);

                /*" -710- ELSE */
            }
            else
            {


                /*" -711- MOVE R-CODSUBES TO COD-SUBGRUPO-IN */
                _.Move(R_CODSUBES, COD_SUBGRUPO_IN);

                /*" -713- MOVE R-CODSUBES TO COD-SUBGRUPO-FI. */
                _.Move(R_CODSUBES, COD_SUBGRUPO_FI);
            }


            /*" -715- MOVE 'N' TO WFIM-SEGURAVG. */
            _.Move("N", WFIM_SEGURAVG);

            /*" -779- PERFORM M_090_000_CURSOR_V1SEGURAVG_DB_DECLARE_1 */

            M_090_000_CURSOR_V1SEGURAVG_DB_DECLARE_1();

            /*" -781- PERFORM M_090_000_CURSOR_V1SEGURAVG_DB_OPEN_1 */

            M_090_000_CURSOR_V1SEGURAVG_DB_OPEN_1();

            /*" -784- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -785- DISPLAY 'VG0130B - ERRO NO DECLARE NA V1SEGURAVG ' */
                _.Display($"VG0130B - ERRO NO DECLARE NA V1SEGURAVG ");

                /*" -785- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1SEGURAVG-DB-OPEN-1 */
        public void M_090_000_CURSOR_V1SEGURAVG_DB_OPEN_1()
        {
            /*" -781- EXEC SQL OPEN TSEGURAVG END-EXEC. */

            TSEGURAVG.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-100-000-FETCH-V1SEGURAVG-SECTION */
        private void M_100_000_FETCH_V1SEGURAVG_SECTION()
        {
            /*" -803- MOVE '100-000-FETCH-V1SEGURAVG' TO PARAGRAFO */
            _.Move("100-000-FETCH-V1SEGURAVG", WABEND.PARAGRAFO);

            /*" -806- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -862- PERFORM M_100_000_FETCH_V1SEGURAVG_DB_FETCH_1 */

            M_100_000_FETCH_V1SEGURAVG_DB_FETCH_1();

            /*" -865- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -866- MOVE 'S' TO WFIM-SEGURAVG */
                _.Move("S", WFIM_SEGURAVG);

                /*" -866- PERFORM M_100_000_FETCH_V1SEGURAVG_DB_CLOSE_1 */

                M_100_000_FETCH_V1SEGURAVG_DB_CLOSE_1();

                /*" -869- GO TO 100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;
            }


            /*" -870- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -871- DISPLAY 'VG0130B - ERRO NO FETCH   NA V1SEGURAVG ' */
                _.Display($"VG0130B - ERRO NO FETCH   NA V1SEGURAVG ");

                /*" -873- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -874- MOVE 'S' TO TEM-COBERTURA. */
            _.Move("S", TEM_COBERTURA);

            /*" -875- MOVE 1 TO FLAG-SEGURAVG. */
            _.Move(1, FILLER_5.FLAG_SEGURAVG);

            /*" -876- ADD 1 TO W-LIDOS. */
            W_LIDOS.Value = W_LIDOS + 1;

            /*" -878- PERFORM 200-000-VERIFICA-PREMIOS. */

            M_200_000_VERIFICA_PREMIOS_SECTION();

            /*" -880- IF TEM-COBERTURA EQUAL 'S' */

            if (TEM_COBERTURA == "S")
            {

                /*" -881- IF TEM-MOVIMENTO EQUAL 'N' */

                if (TEM_MOVIMENTO == "N")
                {

                    /*" -882- PERFORM 290-000-CALCULA-VALORES */

                    M_290_000_CALCULA_VALORES_SECTION();

                    /*" -882- PERFORM 300-000-INSERE-V0MOVIMENTO. */

                    M_300_000_INSERE_V0MOVIMENTO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-100-000-FETCH-V1SEGURAVG-DB-FETCH-1 */
        public void M_100_000_FETCH_V1SEGURAVG_DB_FETCH_1()
        {
            /*" -862- EXEC SQL FETCH TSEGURAVG INTO :SNUM-APOLICE, :SCOD-SUBGRUPO, :SNUM-CERTIFICADO, :SDAC-CERTIFICADO, :STIPO-SEGURADO, :SNUM-ITEM, :STIPO-INCLUSAO, :SCOD-CLIENTE, :SCOD-FONTE, :SNUM-PROPOSTA, :SCOD-AGENCIADOR, :SCOD-CORRETOR, :SCOD-PLANOVGAP, :SCOD-PLANOAP, :SFAIXA, :SAUTOR-AUM-AUTOMAT, :STIPO-BENEFICIARIO, :SOCORR-HISTORICO, :SPERI-PAGAMENTO, :SPERI-RENOVACAO, :SNUM-CARNE, :SCOD-OCUPACAO, :SESTADO-CIVIL, :SIDE-SEXO, :SCOD-PROFISSAO, :SNATURALIDADE, :SOCORR-ENDERECO, :SOCORR-END-COBRAN, :SBCO-COBRANCA, :SAGE-COBRANCA, :SDAC-COBRANCA, :SNUM-MATRICULA, :SVAL-SALARIO, :STIPO-SALARIO, :STIPO-PLANO, :SDATA-INIVIGENCIA, :SPCT-CONJUGE-VG, :SPCT-CONJUGE-AP, :SQTD-SAL-MORNATU, :SQTD-SAL-MORACID, :SQTD-SAL-INVPERM, :STAXA-AP-MORACID, :STAXA-AP-INVPERM, :STAXA-AP-AMDS, :STAXA-AP-DH, :STAXA-AP-DIT, :STAXA-AP, :STAXA-VG, :SSIT-REGISTRO, :SDATA-ADMISSAO:SDATA-ADMISSAO-I, :SDATA-NASCIMENTO:SDATA-NASCIMENTO-I, :SOCORR-HISTORICO, :SCOD-EMPRESA:SCOD-EMPRESA-I, :SLOT-EMP-SEGURADO:WLOT-EMP-SEGURADO END-EXEC. */

            if (TSEGURAVG.Fetch())
            {
                _.Move(TSEGURAVG.SNUM_APOLICE, SNUM_APOLICE);
                _.Move(TSEGURAVG.SCOD_SUBGRUPO, SCOD_SUBGRUPO);
                _.Move(TSEGURAVG.SNUM_CERTIFICADO, SNUM_CERTIFICADO);
                _.Move(TSEGURAVG.SDAC_CERTIFICADO, SDAC_CERTIFICADO);
                _.Move(TSEGURAVG.STIPO_SEGURADO, STIPO_SEGURADO);
                _.Move(TSEGURAVG.SNUM_ITEM, SNUM_ITEM);
                _.Move(TSEGURAVG.STIPO_INCLUSAO, STIPO_INCLUSAO);
                _.Move(TSEGURAVG.SCOD_CLIENTE, SCOD_CLIENTE);
                _.Move(TSEGURAVG.SCOD_FONTE, SCOD_FONTE);
                _.Move(TSEGURAVG.SNUM_PROPOSTA, SNUM_PROPOSTA);
                _.Move(TSEGURAVG.SCOD_AGENCIADOR, SCOD_AGENCIADOR);
                _.Move(TSEGURAVG.SCOD_CORRETOR, SCOD_CORRETOR);
                _.Move(TSEGURAVG.SCOD_PLANOVGAP, SCOD_PLANOVGAP);
                _.Move(TSEGURAVG.SCOD_PLANOAP, SCOD_PLANOAP);
                _.Move(TSEGURAVG.SFAIXA, SFAIXA);
                _.Move(TSEGURAVG.SAUTOR_AUM_AUTOMAT, SAUTOR_AUM_AUTOMAT);
                _.Move(TSEGURAVG.STIPO_BENEFICIARIO, STIPO_BENEFICIARIO);
                _.Move(TSEGURAVG.SOCORR_HISTORICO, SOCORR_HISTORICO);
                _.Move(TSEGURAVG.SPERI_PAGAMENTO, SPERI_PAGAMENTO);
                _.Move(TSEGURAVG.SPERI_RENOVACAO, SPERI_RENOVACAO);
                _.Move(TSEGURAVG.SNUM_CARNE, SNUM_CARNE);
                _.Move(TSEGURAVG.SCOD_OCUPACAO, SCOD_OCUPACAO);
                _.Move(TSEGURAVG.SESTADO_CIVIL, SESTADO_CIVIL);
                _.Move(TSEGURAVG.SIDE_SEXO, SIDE_SEXO);
                _.Move(TSEGURAVG.SCOD_PROFISSAO, SCOD_PROFISSAO);
                _.Move(TSEGURAVG.SNATURALIDADE, SNATURALIDADE);
                _.Move(TSEGURAVG.SOCORR_ENDERECO, SOCORR_ENDERECO);
                _.Move(TSEGURAVG.SOCORR_END_COBRAN, SOCORR_END_COBRAN);
                _.Move(TSEGURAVG.SBCO_COBRANCA, SBCO_COBRANCA);
                _.Move(TSEGURAVG.SAGE_COBRANCA, SAGE_COBRANCA);
                _.Move(TSEGURAVG.SDAC_COBRANCA, SDAC_COBRANCA);
                _.Move(TSEGURAVG.SNUM_MATRICULA, SNUM_MATRICULA);
                _.Move(TSEGURAVG.SVAL_SALARIO, SVAL_SALARIO);
                _.Move(TSEGURAVG.STIPO_SALARIO, STIPO_SALARIO);
                _.Move(TSEGURAVG.STIPO_PLANO, STIPO_PLANO);
                _.Move(TSEGURAVG.SDATA_INIVIGENCIA, SDATA_INIVIGENCIA);
                _.Move(TSEGURAVG.SPCT_CONJUGE_VG, SPCT_CONJUGE_VG);
                _.Move(TSEGURAVG.SPCT_CONJUGE_AP, SPCT_CONJUGE_AP);
                _.Move(TSEGURAVG.SQTD_SAL_MORNATU, SQTD_SAL_MORNATU);
                _.Move(TSEGURAVG.SQTD_SAL_MORACID, SQTD_SAL_MORACID);
                _.Move(TSEGURAVG.SQTD_SAL_INVPERM, SQTD_SAL_INVPERM);
                _.Move(TSEGURAVG.STAXA_AP_MORACID, STAXA_AP_MORACID);
                _.Move(TSEGURAVG.STAXA_AP_INVPERM, STAXA_AP_INVPERM);
                _.Move(TSEGURAVG.STAXA_AP_AMDS, STAXA_AP_AMDS);
                _.Move(TSEGURAVG.STAXA_AP_DH, STAXA_AP_DH);
                _.Move(TSEGURAVG.STAXA_AP_DIT, STAXA_AP_DIT);
                _.Move(TSEGURAVG.STAXA_AP, STAXA_AP);
                _.Move(TSEGURAVG.STAXA_VG, STAXA_VG);
                _.Move(TSEGURAVG.SSIT_REGISTRO, SSIT_REGISTRO);
                _.Move(TSEGURAVG.SDATA_ADMISSAO, SDATA_ADMISSAO);
                _.Move(TSEGURAVG.SDATA_ADMISSAO_I, SDATA_ADMISSAO_I);
                _.Move(TSEGURAVG.SDATA_NASCIMENTO, SDATA_NASCIMENTO);
                _.Move(TSEGURAVG.SDATA_NASCIMENTO_I, SDATA_NASCIMENTO_I);
                _.Move(TSEGURAVG.SOCORR_HISTORICO, SOCORR_HISTORICO);
                _.Move(TSEGURAVG.SCOD_EMPRESA, SCOD_EMPRESA);
                _.Move(TSEGURAVG.SCOD_EMPRESA_I, SCOD_EMPRESA_I);
                _.Move(TSEGURAVG.SLOT_EMP_SEGURADO, SLOT_EMP_SEGURADO);
                _.Move(TSEGURAVG.WLOT_EMP_SEGURADO, WLOT_EMP_SEGURADO);
            }

        }

        [StopWatch]
        /*" M-100-000-FETCH-V1SEGURAVG-DB-CLOSE-1 */
        public void M_100_000_FETCH_V1SEGURAVG_DB_CLOSE_1()
        {
            /*" -866- EXEC SQL CLOSE TSEGURAVG END-EXEC */

            TSEGURAVG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/

        [StopWatch]
        /*" M-200-000-VERIFICA-PREMIOS-SECTION */
        private void M_200_000_VERIFICA_PREMIOS_SECTION()
        {
            /*" -899- MOVE '200-000-VERIFICA-PREMIOS' TO PARAGRAFO. */
            _.Move("200-000-VERIFICA-PREMIOS", WABEND.PARAGRAFO);

            /*" -901- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WABEND.WNR_EXEC_SQL);

            /*" -910- MOVE 0 TO MIMP-MORNATU-ANT MIMP-MORACID-ANT MIMP-INVPERM-ANT MIMP-AMDS-ANT MIMP-DH-ANT MIMP-DIT-ANT MPRM-VG-ANT MPRM-AP-ANT. */
            _.Move(0, MIMP_MORNATU_ANT, MIMP_MORACID_ANT, MIMP_INVPERM_ANT, MIMP_AMDS_ANT, MIMP_DH_ANT, MIMP_DIT_ANT, MPRM_VG_ANT, MPRM_AP_ANT);

            /*" -911- MOVE SNUM-APOLICE TO CNUM-APOLICE. */
            _.Move(SNUM_APOLICE, CNUM_APOLICE);

            /*" -912- MOVE SNUM-ITEM TO CNUM-ITEM. */
            _.Move(SNUM_ITEM, CNUM_ITEM);

            /*" -913- MOVE SOCORR-HISTORICO TO COCORHIST. */
            _.Move(SOCORR_HISTORICO, COCORHIST);

            /*" -915- MOVE V1PAR-RAMO-VG TO CRAMOFR. */
            _.Move(V1PAR_RAMO_VG, CRAMOFR);

            /*" -916- PERFORM 240-000-ACESSA-V1HISTSEG. */

            M_240_000_ACESSA_V1HISTSEG_SECTION();

            /*" -918- MOVE 11 TO CCOD-COBERTURA. */
            _.Move(11, CCOD_COBERTURA);

            /*" -928- PERFORM 230-000-SELECT-V1COBERAPOL. */

            M_230_000_SELECT_V1COBERAPOL_SECTION();

            /*" -929- IF CDATA-INIVIGENCIA NOT LESS R-DATA-REFERENCIA */

            if (CDATA_INIVIGENCIA >= R_DATA_REFERENCIA)
            {

                /*" -930- MOVE 'N' TO TEM-COBERTURA */
                _.Move("N", TEM_COBERTURA);

                /*" -932- GO TO 210-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_210_999_EXIT*/ //GOTO
                return;
            }


            /*" -933- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -935- MOVE 0 TO MIMP-MORNATU-ANT MPRM-VG-ANT */
                _.Move(0, MIMP_MORNATU_ANT, MPRM_VG_ANT);

                /*" -936- ELSE */
            }
            else
            {


                /*" -941- COMPUTE MIMP-MORNATU-ANT ROUNDED = CIMP-SEGURADA-IX * CFATOR-MULTIPLICA * DVLCRUZAD-IMP */
                MIMP_MORNATU_ANT.Value = CIMP_SEGURADA_IX * CFATOR_MULTIPLICA * DVLCRUZAD_IMP;

                /*" -944- COMPUTE MPRM-VG-ANT ROUNDED = CPRM-TARIFARIO-IX * CFATOR-MULTIPLICA * DVLCRUZAD-PRM. */
                MPRM_VG_ANT.Value = CPRM_TARIFARIO_IX * CFATOR_MULTIPLICA * DVLCRUZAD_PRM;
            }


            /*" -0- FLUXCONTROL_PERFORM M_210_020_VERIFICA_PREMIO_AP */

            M_210_020_VERIFICA_PREMIO_AP();

        }

        [StopWatch]
        /*" M-210-020-VERIFICA-PREMIO-AP */
        private void M_210_020_VERIFICA_PREMIO_AP(bool isPerform = false)
        {
            /*" -952- MOVE '210-020-VERIFICA-PREMIO-AP' TO PARAGRAFO. */
            _.Move("210-020-VERIFICA-PREMIO-AP", WABEND.PARAGRAFO);

            /*" -954- MOVE '211' TO WNR-EXEC-SQL. */
            _.Move("211", WABEND.WNR_EXEC_SQL);

            /*" -955- MOVE V1PAR-RAMO-AP TO CRAMOFR. */
            _.Move(V1PAR_RAMO_AP, CRAMOFR);

            /*" -957- MOVE 1 TO CCOD-COBERTURA. */
            _.Move(1, CCOD_COBERTURA);

            /*" -959- PERFORM 230-000-SELECT-V1COBERAPOL. */

            M_230_000_SELECT_V1COBERAPOL_SECTION();

            /*" -960- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -962- MOVE 0 TO MIMP-MORACID-ANT MPRM-AP-ANT */
                _.Move(0, MIMP_MORACID_ANT, MPRM_AP_ANT);

                /*" -963- ELSE */
            }
            else
            {


                /*" -968- COMPUTE MIMP-MORACID-ANT ROUNDED = CIMP-SEGURADA-IX * CFATOR-MULTIPLICA * DVLCRUZAD-IMP */
                MIMP_MORACID_ANT.Value = CIMP_SEGURADA_IX * CFATOR_MULTIPLICA * DVLCRUZAD_IMP;

                /*" -971- COMPUTE MPRM-AP-ANT ROUNDED = CPRM-TARIFARIO-IX * CFATOR-MULTIPLICA * DVLCRUZAD-PRM. */
                MPRM_AP_ANT.Value = CPRM_TARIFARIO_IX * CFATOR_MULTIPLICA * DVLCRUZAD_PRM;
            }


        }

        [StopWatch]
        /*" M-210-030-VERIFICA-INVPERM */
        private void M_210_030_VERIFICA_INVPERM(bool isPerform = false)
        {
            /*" -979- MOVE '210-030-VERIFICA-INVPERM' TO PARAGRAFO. */
            _.Move("210-030-VERIFICA-INVPERM", WABEND.PARAGRAFO);

            /*" -981- MOVE '212' TO WNR-EXEC-SQL. */
            _.Move("212", WABEND.WNR_EXEC_SQL);

            /*" -983- MOVE 2 TO CCOD-COBERTURA. */
            _.Move(2, CCOD_COBERTURA);

            /*" -985- PERFORM 230-000-SELECT-V1COBERAPOL. */

            M_230_000_SELECT_V1COBERAPOL_SECTION();

            /*" -986- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -987- MOVE 0 TO MIMP-INVPERM-ANT */
                _.Move(0, MIMP_INVPERM_ANT);

                /*" -988- ELSE */
            }
            else
            {


                /*" -991- COMPUTE MIMP-INVPERM-ANT ROUNDED = CIMP-SEGURADA-IX * CFATOR-MULTIPLICA * DVLCRUZAD-IMP. */
                MIMP_INVPERM_ANT.Value = CIMP_SEGURADA_IX * CFATOR_MULTIPLICA * DVLCRUZAD_IMP;
            }


        }

        [StopWatch]
        /*" M-210-040-VERIFICA-AMDS */
        private void M_210_040_VERIFICA_AMDS(bool isPerform = false)
        {
            /*" -999- MOVE '210-040-VERIFICA-AMDS' TO PARAGRAFO. */
            _.Move("210-040-VERIFICA-AMDS", WABEND.PARAGRAFO);

            /*" -1001- MOVE '213' TO WNR-EXEC-SQL. */
            _.Move("213", WABEND.WNR_EXEC_SQL);

            /*" -1003- MOVE 3 TO CCOD-COBERTURA. */
            _.Move(3, CCOD_COBERTURA);

            /*" -1005- PERFORM 230-000-SELECT-V1COBERAPOL. */

            M_230_000_SELECT_V1COBERAPOL_SECTION();

            /*" -1006- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1007- MOVE 0 TO MIMP-AMDS-ANT */
                _.Move(0, MIMP_AMDS_ANT);

                /*" -1008- ELSE */
            }
            else
            {


                /*" -1011- COMPUTE MIMP-AMDS-ANT ROUNDED = CIMP-SEGURADA-IX * CFATOR-MULTIPLICA * DVLCRUZAD-IMP. */
                MIMP_AMDS_ANT.Value = CIMP_SEGURADA_IX * CFATOR_MULTIPLICA * DVLCRUZAD_IMP;
            }


        }

        [StopWatch]
        /*" M-210-050-VERIFICA-DH */
        private void M_210_050_VERIFICA_DH(bool isPerform = false)
        {
            /*" -1019- MOVE '210-050-VERIFICA-DH' TO PARAGRAFO. */
            _.Move("210-050-VERIFICA-DH", WABEND.PARAGRAFO);

            /*" -1021- MOVE '214' TO WNR-EXEC-SQL. */
            _.Move("214", WABEND.WNR_EXEC_SQL);

            /*" -1023- MOVE 4 TO CCOD-COBERTURA. */
            _.Move(4, CCOD_COBERTURA);

            /*" -1025- PERFORM 230-000-SELECT-V1COBERAPOL. */

            M_230_000_SELECT_V1COBERAPOL_SECTION();

            /*" -1026- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1027- MOVE 0 TO MIMP-DH-ANT */
                _.Move(0, MIMP_DH_ANT);

                /*" -1028- ELSE */
            }
            else
            {


                /*" -1031- COMPUTE MIMP-DH-ANT ROUNDED = CIMP-SEGURADA-IX * CFATOR-MULTIPLICA * DVLCRUZAD-IMP. */
                MIMP_DH_ANT.Value = CIMP_SEGURADA_IX * CFATOR_MULTIPLICA * DVLCRUZAD_IMP;
            }


        }

        [StopWatch]
        /*" M-210-060-VERIFICA-DIT */
        private void M_210_060_VERIFICA_DIT(bool isPerform = false)
        {
            /*" -1039- MOVE '210-060-VERIFICA-DH' TO PARAGRAFO. */
            _.Move("210-060-VERIFICA-DH", WABEND.PARAGRAFO);

            /*" -1041- MOVE '215' TO WNR-EXEC-SQL. */
            _.Move("215", WABEND.WNR_EXEC_SQL);

            /*" -1043- MOVE 5 TO CCOD-COBERTURA. */
            _.Move(5, CCOD_COBERTURA);

            /*" -1045- PERFORM 230-000-SELECT-V1COBERAPOL. */

            M_230_000_SELECT_V1COBERAPOL_SECTION();

            /*" -1046- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1047- MOVE 0 TO MIMP-DIT-ANT */
                _.Move(0, MIMP_DIT_ANT);

                /*" -1048- ELSE */
            }
            else
            {


                /*" -1051- COMPUTE MIMP-DIT-ANT ROUNDED = CIMP-SEGURADA-IX * CFATOR-MULTIPLICA * DVLCRUZAD-IMP. */
                MIMP_DIT_ANT.Value = CIMP_SEGURADA_IX * CFATOR_MULTIPLICA * DVLCRUZAD_IMP;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_210_999_EXIT*/

        [StopWatch]
        /*" M-230-000-SELECT-V1COBERAPOL-SECTION */
        private void M_230_000_SELECT_V1COBERAPOL_SECTION()
        {
            /*" -1067- MOVE '230-000-SELECT-V1COBERAPOL' TO PARAGRAFO. */
            _.Move("230-000-SELECT-V1COBERAPOL", WABEND.PARAGRAFO);

            /*" -1069- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", WABEND.WNR_EXEC_SQL);

            /*" -1104- PERFORM M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1 */

            M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1();

            /*" -1108- IF SQLCODE EQUAL 100 NEXT SENTENCE */

            if (DB.SQLCODE == 100)
            {

                /*" -1109- ELSE */
            }
            else
            {


                /*" -1110- IF SQLCODE NOT EQUAL 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -1112- DISPLAY 'VG0130B - NAO EXISTE CAPITAL NA COBERAPOL ' SNUM-APOLICE */
                    _.Display($"VG0130B - NAO EXISTE CAPITAL NA COBERAPOL {SNUM_APOLICE}");

                    /*" -1112- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-230-000-SELECT-V1COBERAPOL-DB-SELECT-1 */
        public void M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1()
        {
            /*" -1104- EXEC SQL SELECT NUM_APOLICE, NRENDOS, NUM_ITEM, OCORHIST, RAMOFR, MODALIFR, COD_COBERTURA, IMP_SEGURADA_IX, PRM_TARIFARIO_IX, FATOR_MULTIPLICA, DATA_INIVIGENCIA INTO :CNUM-APOLICE, :CNRENDOS, :CNUM-ITEM, :COCORHIST, :CRAMOFR, :CMODALIFR, :CCOD-COBERTURA, :CIMP-SEGURADA-IX, :CPRM-TARIFARIO-IX, :CFATOR-MULTIPLICA, :CDATA-INIVIGENCIA FROM SEGUROS.V1COBERAPOL WHERE NUM_APOLICE = :CNUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :CNUM-ITEM AND OCORHIST = :COCORHIST AND MODALIFR = 0 AND COD_COBERTURA = :CCOD-COBERTURA AND RAMOFR = :CRAMOFR END-EXEC. */

            var m_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1 = new M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1()
            {
                CCOD_COBERTURA = CCOD_COBERTURA.ToString(),
                CNUM_APOLICE = CNUM_APOLICE.ToString(),
                CNUM_ITEM = CNUM_ITEM.ToString(),
                COCORHIST = COCORHIST.ToString(),
                CRAMOFR = CRAMOFR.ToString(),
            };

            var executed_1 = M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1.Execute(m_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CNUM_APOLICE, CNUM_APOLICE);
                _.Move(executed_1.CNRENDOS, CNRENDOS);
                _.Move(executed_1.CNUM_ITEM, CNUM_ITEM);
                _.Move(executed_1.COCORHIST, COCORHIST);
                _.Move(executed_1.CRAMOFR, CRAMOFR);
                _.Move(executed_1.CMODALIFR, CMODALIFR);
                _.Move(executed_1.CCOD_COBERTURA, CCOD_COBERTURA);
                _.Move(executed_1.CIMP_SEGURADA_IX, CIMP_SEGURADA_IX);
                _.Move(executed_1.CPRM_TARIFARIO_IX, CPRM_TARIFARIO_IX);
                _.Move(executed_1.CFATOR_MULTIPLICA, CFATOR_MULTIPLICA);
                _.Move(executed_1.CDATA_INIVIGENCIA, CDATA_INIVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_230_999_EXIT*/

        [StopWatch]
        /*" M-240-000-ACESSA-V1HISTSEG-SECTION */
        private void M_240_000_ACESSA_V1HISTSEG_SECTION()
        {
            /*" -1132- MOVE '240-000-ACESSA-V1HISTSEGVG' TO PARAGRAFO. */
            _.Move("240-000-ACESSA-V1HISTSEGVG", WABEND.PARAGRAFO);

            /*" -1134- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", WABEND.WNR_EXEC_SQL);

            /*" -1155- PERFORM M_240_000_ACESSA_V1HISTSEG_DB_SELECT_1 */

            M_240_000_ACESSA_V1HISTSEG_DB_SELECT_1();

            /*" -1158- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1160- DISPLAY 'VG0130B - NAO EXISTE HISTSEGVG P/ A APOLICE ' MNUM-APOLICE */
                _.Display($"VG0130B - NAO EXISTE HISTSEGVG P/ A APOLICE {MNUM_APOLICE}");

                /*" -1162- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1163- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1164- DISPLAY 'VG0130B - ERRO NO SELECT NA V1HISTSEGVG' */
                _.Display($"VG0130B - ERRO NO SELECT NA V1HISTSEGVG");

                /*" -1165- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1166- IF ECOD-MOEDA-IMP = 0 OR ECOD-MOEDA-PRM = 0 */

            if (ECOD_MOEDA_IMP == 0 || ECOD_MOEDA_PRM == 0)
            {

                /*" -1167- DISPLAY 'VG0130B - ERRO: V1HISTSEGVG SEM MOEDA' */
                _.Display($"VG0130B - ERRO: V1HISTSEGVG SEM MOEDA");

                /*" -1168- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1170- MOVE XDATA-MOVIMENTO TO M-DATA-REFERENCIA HDATA-MOVIMENTO. */
            _.Move(XDATA_MOVIMENTO, M_DATA_REFERENCIA, HDATA_MOVIMENTO);

            /*" -1170- PERFORM 270-000-ACESSA-V1MOEDA. */

            M_270_000_ACESSA_V1MOEDA_SECTION();

        }

        [StopWatch]
        /*" M-240-000-ACESSA-V1HISTSEG-DB-SELECT-1 */
        public void M_240_000_ACESSA_V1HISTSEG_DB_SELECT_1()
        {
            /*" -1155- EXEC SQL SELECT NUM_APOLICE, COD_SUBGRUPO, NUM_ITEM, DATA_MOVIMENTO, VALUE(COD_MOEDA_IMP, 0), VALUE(COD_MOEDA_PRM, 0) INTO :HNUM-APOLICE, :HCOD-SUBGRUPO, :HNUM-ITEM, :XDATA-MOVIMENTO, :ECOD-MOEDA-IMP, :ECOD-MOEDA-PRM FROM SEGUROS.V1HISTSEGVG WHERE NUM_APOLICE = :R-NUM-APOLICE AND NUM_ITEM = :SNUM-ITEM AND OCORR_HISTORICO = :SOCORR-HISTORICO END-EXEC. */

            var m_240_000_ACESSA_V1HISTSEG_DB_SELECT_1_Query1 = new M_240_000_ACESSA_V1HISTSEG_DB_SELECT_1_Query1()
            {
                SOCORR_HISTORICO = SOCORR_HISTORICO.ToString(),
                R_NUM_APOLICE = R_NUM_APOLICE.ToString(),
                SNUM_ITEM = SNUM_ITEM.ToString(),
            };

            var executed_1 = M_240_000_ACESSA_V1HISTSEG_DB_SELECT_1_Query1.Execute(m_240_000_ACESSA_V1HISTSEG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HNUM_APOLICE, HNUM_APOLICE);
                _.Move(executed_1.HCOD_SUBGRUPO, HCOD_SUBGRUPO);
                _.Move(executed_1.HNUM_ITEM, HNUM_ITEM);
                _.Move(executed_1.XDATA_MOVIMENTO, XDATA_MOVIMENTO);
                _.Move(executed_1.ECOD_MOEDA_IMP, ECOD_MOEDA_IMP);
                _.Move(executed_1.ECOD_MOEDA_PRM, ECOD_MOEDA_PRM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_240_999_EXIT*/

        [StopWatch]
        /*" M-270-000-ACESSA-V1MOEDA-SECTION */
        private void M_270_000_ACESSA_V1MOEDA_SECTION()
        {
            /*" -1186- MOVE '270-000-ACESSA-V1MOEDA' TO PARAGRAFO. */
            _.Move("270-000-ACESSA-V1MOEDA", WABEND.PARAGRAFO);

            /*" -1188- MOVE '270' TO WNR-EXEC-SQL. */
            _.Move("270", WABEND.WNR_EXEC_SQL);

            /*" -1197- PERFORM M_270_000_ACESSA_V1MOEDA_DB_SELECT_1 */

            M_270_000_ACESSA_V1MOEDA_DB_SELECT_1();

            /*" -1200- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1202- DISPLAY 'VG0130B - NAO CONSTA REGISTRO NA V1MOEDA ' ECOD-MOEDA-IMP ' ' V1SISTEMA-DTMOVABE */

                $"VG0130B - NAO CONSTA REGISTRO NA V1MOEDA {ECOD_MOEDA_IMP} {V1SISTEMA_DTMOVABE}"
                .Display();

                /*" -1204- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1205- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1206- DISPLAY 'VG0130B - ERRO NO SELECT  NA V1MOEDA  1 ' */
                _.Display($"VG0130B - ERRO NO SELECT  NA V1MOEDA  1 ");

                /*" -1209- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1210- IF ECOD-MOEDA-IMP EQUAL ECOD-MOEDA-PRM */

            if (ECOD_MOEDA_IMP == ECOD_MOEDA_PRM)
            {

                /*" -1211- MOVE DVLCRUZAD-IMP TO DVLCRUZAD-PRM */
                _.Move(DVLCRUZAD_IMP, DVLCRUZAD_PRM);

                /*" -1214- GO TO 270-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_270_999_EXIT*/ //GOTO
                return;
            }


            /*" -1223- PERFORM M_270_000_ACESSA_V1MOEDA_DB_SELECT_2 */

            M_270_000_ACESSA_V1MOEDA_DB_SELECT_2();

            /*" -1226- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1228- DISPLAY 'VG0130B - NAO CONSTA REGISTRO NA V1MOEDA ' ECOD-MOEDA-PRM ' ' V1SISTEMA-DTMOVABE */

                $"VG0130B - NAO CONSTA REGISTRO NA V1MOEDA {ECOD_MOEDA_PRM} {V1SISTEMA_DTMOVABE}"
                .Display();

                /*" -1230- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1231- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1232- DISPLAY 'VG0130B - ERRO NO SELECT  NA V1MOEDA  2 ' */
                _.Display($"VG0130B - ERRO NO SELECT  NA V1MOEDA  2 ");

                /*" -1232- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-270-000-ACESSA-V1MOEDA-DB-SELECT-1 */
        public void M_270_000_ACESSA_V1MOEDA_DB_SELECT_1()
        {
            /*" -1197- EXEC SQL SELECT VLCRUZAD INTO :DVLCRUZAD-IMP FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :ECOD-MOEDA-IMP AND DTINIVIG <= :M-DATA-REFERENCIA AND DTTERVIG >= :M-DATA-REFERENCIA AND SITUACAO = '0' END-EXEC. */

            var m_270_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1 = new M_270_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1()
            {
                M_DATA_REFERENCIA = M_DATA_REFERENCIA.ToString(),
                ECOD_MOEDA_IMP = ECOD_MOEDA_IMP.ToString(),
            };

            var executed_1 = M_270_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1.Execute(m_270_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DVLCRUZAD_IMP, DVLCRUZAD_IMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_270_999_EXIT*/

        [StopWatch]
        /*" M-270-000-ACESSA-V1MOEDA-DB-SELECT-2 */
        public void M_270_000_ACESSA_V1MOEDA_DB_SELECT_2()
        {
            /*" -1223- EXEC SQL SELECT VLCRUZAD INTO :DVLCRUZAD-PRM FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :ECOD-MOEDA-PRM AND DTINIVIG <= :M-DATA-REFERENCIA AND DTTERVIG >= :M-DATA-REFERENCIA AND SITUACAO = '0' END-EXEC. */

            var m_270_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1 = new M_270_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1()
            {
                M_DATA_REFERENCIA = M_DATA_REFERENCIA.ToString(),
                ECOD_MOEDA_PRM = ECOD_MOEDA_PRM.ToString(),
            };

            var executed_1 = M_270_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1.Execute(m_270_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DVLCRUZAD_PRM, DVLCRUZAD_PRM);
            }


        }

        [StopWatch]
        /*" M-280-000-ACESSA-V1MOVIMENTO-SECTION */
        private void M_280_000_ACESSA_V1MOVIMENTO_SECTION()
        {
            /*" -1246- MOVE '280-000-ACESSA-V1MOVIMENTO' TO PARAGRAFO. */
            _.Move("280-000-ACESSA-V1MOVIMENTO", WABEND.PARAGRAFO);

            /*" -1247- MOVE '280' TO WNR-EXEC-SQL. */
            _.Move("280", WABEND.WNR_EXEC_SQL);

            /*" -1249- MOVE 'N' TO TEM-MOVIMENTO. */
            _.Move("N", TEM_MOVIMENTO);

            /*" -1267- PERFORM M_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1 */

            M_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1();

            /*" -1270- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1272- GO TO 280-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_280_999_EXIT*/ //GOTO
                return;
            }


            /*" -1273- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1275- DISPLAY 'VG0130B - PROBLEMAS NO ACESSO V1MOVIMENTO ' MNUM-APOLICE */
                _.Display($"VG0130B - PROBLEMAS NO ACESSO V1MOVIMENTO {MNUM_APOLICE}");

                /*" -1277- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1277- MOVE 'S' TO TEM-MOVIMENTO. */
            _.Move("S", TEM_MOVIMENTO);

        }

        [StopWatch]
        /*" M-280-000-ACESSA-V1MOVIMENTO-DB-SELECT-1 */
        public void M_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1()
        {
            /*" -1267- EXEC SQL SELECT NUM_APOLICE, NUM_CERTIFICADO, TIPO_SEGURADO, DATA_INCLUSAO INTO :MNUM-APOLICE, :MNUM-CERTIFICADO, :MTIPO-SEGURADO, :MDATA-INCLUSAO:WDATA-INCLUSAO FROM SEGUROS.V1MOVIMENTO WHERE NUM_CERTIFICADO = :SNUM-CERTIFICADO AND COD_OPERACAO = 0891 AND TIPO_SEGURADO = :STIPO-SEGURADO AND DATA_INCLUSAO IS NULL END-EXEC. */

            var m_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1_Query1 = new M_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1_Query1()
            {
                SNUM_CERTIFICADO = SNUM_CERTIFICADO.ToString(),
                STIPO_SEGURADO = STIPO_SEGURADO.ToString(),
            };

            var executed_1 = M_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1_Query1.Execute(m_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MNUM_APOLICE, MNUM_APOLICE);
                _.Move(executed_1.MNUM_CERTIFICADO, MNUM_CERTIFICADO);
                _.Move(executed_1.MTIPO_SEGURADO, MTIPO_SEGURADO);
                _.Move(executed_1.MDATA_INCLUSAO, MDATA_INCLUSAO);
                _.Move(executed_1.WDATA_INCLUSAO, WDATA_INCLUSAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_280_999_EXIT*/

        [StopWatch]
        /*" M-290-000-CALCULA-VALORES-SECTION */
        private void M_290_000_CALCULA_VALORES_SECTION()
        {
            /*" -1291- MOVE '290-000-CALCULA-VALORES' TO PARAGRAFO. */
            _.Move("290-000-CALCULA-VALORES", WABEND.PARAGRAFO);

            /*" -1293- MOVE '290' TO WNR-EXEC-SQL. */
            _.Move("290", WABEND.WNR_EXEC_SQL);

            /*" -1294- IF R-OPERACAO EQUAL 1 */

            if (R_OPERACAO == 1)
            {

                /*" -1295- COMPUTE W-PCT-AUMENTO = R-PCT-AUMENTO / 100 */
                W_PCT_AUMENTO.Value = R_PCT_AUMENTO / 100f;

                /*" -1296- COMPUTE W-PCT-AUMENTO = W-PCT-AUMENTO + 1 */
                W_PCT_AUMENTO.Value = W_PCT_AUMENTO + 1;

                /*" -1297- ELSE */
            }
            else
            {


                /*" -1299- PERFORM 310-000-CALCULA-PRORATA. */

                M_310_000_CALCULA_PRORATA_SECTION();
            }


            /*" -1302- COMPUTE MIMP-MORNATU-ATU ROUNDED = MIMP-MORNATU-ANT * W-PCT-AUMENTO */
            MIMP_MORNATU_ATU.Value = MIMP_MORNATU_ANT * W_PCT_AUMENTO;

            /*" -1305- COMPUTE MPRM-VG-ATU ROUNDED = MPRM-VG-ANT * W-PCT-AUMENTO */
            MPRM_VG_ATU.Value = MPRM_VG_ANT * W_PCT_AUMENTO;

            /*" -1308- COMPUTE MIMP-MORACID-ATU ROUNDED = MIMP-MORACID-ANT * W-PCT-AUMENTO */
            MIMP_MORACID_ATU.Value = MIMP_MORACID_ANT * W_PCT_AUMENTO;

            /*" -1311- COMPUTE MPRM-AP-ATU ROUNDED = MPRM-AP-ANT * W-PCT-AUMENTO */
            MPRM_AP_ATU.Value = MPRM_AP_ANT * W_PCT_AUMENTO;

            /*" -1314- COMPUTE MIMP-INVPERM-ATU ROUNDED = MIMP-INVPERM-ANT * W-PCT-AUMENTO */
            MIMP_INVPERM_ATU.Value = MIMP_INVPERM_ANT * W_PCT_AUMENTO;

            /*" -1317- COMPUTE MIMP-AMDS-ATU ROUNDED = MIMP-AMDS-ANT * W-PCT-AUMENTO */
            MIMP_AMDS_ATU.Value = MIMP_AMDS_ANT * W_PCT_AUMENTO;

            /*" -1320- COMPUTE MIMP-DH-ATU ROUNDED = MIMP-DH-ANT * W-PCT-AUMENTO */
            MIMP_DH_ATU.Value = MIMP_DH_ANT * W_PCT_AUMENTO;

            /*" -1321- COMPUTE MIMP-DIT-ATU ROUNDED = MIMP-DIT-ANT * W-PCT-AUMENTO. */
            MIMP_DIT_ATU.Value = MIMP_DIT_ANT * W_PCT_AUMENTO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_290_999_EXIT*/

        [StopWatch]
        /*" M-300-000-INSERE-V0MOVIMENTO-SECTION */
        private void M_300_000_INSERE_V0MOVIMENTO_SECTION()
        {
            /*" -1332- PERFORM 306-000-ACESSA-FONTE */

            M_306_000_ACESSA_FONTE_SECTION();

            /*" -1334- PERFORM 307-000-ATUALIZA-FONTE */

            M_307_000_ATUALIZA_FONTE_SECTION();

            /*" -1339- MOVE +0 TO WDATA-MOVIMENTO WDATA-REFERENCIA WDATA-AVERBACAO WDATA-INCLUSAO. */
            _.Move(+0, WDATA_MOVIMENTO, WDATA_REFERENCIA, WDATA_AVERBACAO, WDATA_INCLUSAO);

            /*" -1340- MOVE 0891 TO MCOD-OPERACAO */
            _.Move(0891, MCOD_OPERACAO);

            /*" -1341- MOVE R-DATA-REFERENCIA TO MDATA-MOVIMENTO. */
            _.Move(R_DATA_REFERENCIA, MDATA_MOVIMENTO);

            /*" -1342- MOVE FDATA-REFERENCIA TO MDATA-REFERENCIA. */
            _.Move(FDATA_REFERENCIA, MDATA_REFERENCIA);

            /*" -1344- MOVE V1SISTEMA-DTMOVABE TO MDATA-OPERACAO MDATA-AVERBACAO. */
            _.Move(V1SISTEMA_DTMOVABE, MDATA_OPERACAO, MDATA_AVERBACAO);

            /*" -1345- MOVE -1 TO WDATA-INCLUSAO */
            _.Move(-1, WDATA_INCLUSAO);

            /*" -1346- MOVE -1 TO WDATA-FATURA */
            _.Move(-1, WDATA_FATURA);

            /*" -1347- MOVE -1 TO WCOD-EMPRESA */
            _.Move(-1, WCOD_EMPRESA);

            /*" -1348- MOVE ZEROS TO COD-SUBGRUPO-TRANS */
            _.Move(0, COD_SUBGRUPO_TRANS);

            /*" -1349- MOVE '1' TO MSIT-REGISTRO. */
            _.Move("1", MSIT_REGISTRO);

            /*" -1350- MOVE R-CODUSU TO MCOD-USUARIO. */
            _.Move(R_CODUSU, MCOD_USUARIO);

            /*" -1351- IF SDATA-ADMISSAO-I LESS 0 */

            if (SDATA_ADMISSAO_I < 0)
            {

                /*" -1352- MOVE -1 TO WDATA-ADMISSAO */
                _.Move(-1, WDATA_ADMISSAO);

                /*" -1353- ELSE */
            }
            else
            {


                /*" -1355- MOVE SDATA-ADMISSAO TO MDATA-ADMISSAO. */
                _.Move(SDATA_ADMISSAO, MDATA_ADMISSAO);
            }


            /*" -1356- IF SDATA-NASCIMENTO-I LESS 0 */

            if (SDATA_NASCIMENTO_I < 0)
            {

                /*" -1357- MOVE -1 TO WDATA-NASCIMENTO */
                _.Move(-1, WDATA_NASCIMENTO);

                /*" -1358- ELSE */
            }
            else
            {


                /*" -1360- MOVE SDATA-NASCIMENTO TO MDATA-NASCIMENTO. */
                _.Move(SDATA_NASCIMENTO, MDATA_NASCIMENTO);
            }


            /*" -1362- PERFORM 320-000-ACESSA-V1CONTACOR. */

            M_320_000_ACESSA_V1CONTACOR_SECTION();

            /*" -1363- IF WLOT-EMP-SEGURADO LESS ZEROS */

            if (WLOT_EMP_SEGURADO < 00)
            {

                /*" -1370- MOVE SPACES TO SLOT-EMP-SEGURADO. */
                _.Move("", SLOT_EMP_SEGURADO);
            }


            /*" -1371- MOVE '300-000-INSERE-V0MOVIMENTO' TO PARAGRAFO. */
            _.Move("300-000-INSERE-V0MOVIMENTO", WABEND.PARAGRAFO);

            /*" -1373- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", WABEND.WNR_EXEC_SQL);

            /*" -1374- IF SNUM-APOLICE = 109300000552 */

            if (SNUM_APOLICE == 109300000552)
            {

                /*" -1375- MOVE '9999-12-31' TO MDATA-INCLUSAO */
                _.Move("9999-12-31", MDATA_INCLUSAO);

                /*" -1377- MOVE ZEROS TO WDATA-INCLUSAO. */
                _.Move(0, WDATA_INCLUSAO);
            }


            /*" -1456- PERFORM M_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1 */

            M_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1();

            /*" -1459- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1461- DISPLAY 'VG0130B - PROBLEMAS NA INCLUSAO V0MOVIMENTO  ' SNUM-APOLICE */
                _.Display($"VG0130B - PROBLEMAS NA INCLUSAO V0MOVIMENTO  {SNUM_APOLICE}");

                /*" -1463- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1463- ADD 1 TO W-GRAVADOS. */
            W_GRAVADOS.Value = W_GRAVADOS + 1;

        }

        [StopWatch]
        /*" M-300-000-INSERE-V0MOVIMENTO-DB-INSERT-1 */
        public void M_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1()
        {
            /*" -1456- EXEC SQL INSERT INTO SEGUROS.V0MOVIMENTO VALUES (:SNUM-APOLICE, :SCOD-SUBGRUPO, :SCOD-FONTE, :FONTE-PROPAUTOM, :STIPO-SEGURADO, :SNUM-CERTIFICADO, :SDAC-CERTIFICADO, :STIPO-INCLUSAO, :SCOD-CLIENTE, :SCOD-AGENCIADOR, :SCOD-CORRETOR, :SCOD-PLANOVGAP, :SCOD-PLANOAP, :SFAIXA, :SAUTOR-AUM-AUTOMAT, :STIPO-BENEFICIARIO, :SPERI-PAGAMENTO, :SPERI-RENOVACAO, :SCOD-OCUPACAO, :SESTADO-CIVIL, :SIDE-SEXO, :SCOD-PROFISSAO, :SNATURALIDADE, :SOCORR-ENDERECO, :SOCORR-END-COBRAN, :SBCO-COBRANCA, :SAGE-COBRANCA, :SDAC-COBRANCA, :SNUM-MATRICULA, :NUM-CTA-CORRENTE, :DAC-CTA-CORRENTE, :SVAL-SALARIO, :STIPO-SALARIO, :STIPO-PLANO, :SPCT-CONJUGE-VG, :SPCT-CONJUGE-AP, :SQTD-SAL-MORNATU, :SQTD-SAL-MORACID, :SQTD-SAL-INVPERM, :STAXA-AP-MORACID, :STAXA-AP-INVPERM, :STAXA-AP-AMDS, :STAXA-AP-DH, :STAXA-AP-DIT, :STAXA-VG, :MIMP-MORNATU-ANT, :MIMP-MORNATU-ATU, :MIMP-MORACID-ANT, :MIMP-MORACID-ATU, :MIMP-INVPERM-ANT, :MIMP-INVPERM-ATU, :MIMP-AMDS-ANT, :MIMP-AMDS-ATU, :MIMP-DH-ANT, :MIMP-DH-ATU, :MIMP-DIT-ANT, :MIMP-DIT-ATU, :MPRM-VG-ANT, :MPRM-VG-ATU, :MPRM-AP-ANT, :MPRM-AP-ATU, :MCOD-OPERACAO, :MDATA-OPERACAO, :COD-SUBGRUPO-TRANS, :MSIT-REGISTRO, :MCOD-USUARIO, :MDATA-AVERBACAO:WDATA-AVERBACAO, :MDATA-ADMISSAO:WDATA-ADMISSAO, :MDATA-INCLUSAO:WDATA-INCLUSAO, :MDATA-NASCIMENTO:WDATA-NASCIMENTO, :MDATA-FATURA:WDATA-FATURA, :MDATA-REFERENCIA:WDATA-REFERENCIA, :MDATA-MOVIMENTO:WDATA-MOVIMENTO, :MCOD-EMPRESA:WCOD-EMPRESA, :SLOT-EMP-SEGURADO) END-EXEC. */

            var m_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1_Insert1 = new M_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1_Insert1()
            {
                SNUM_APOLICE = SNUM_APOLICE.ToString(),
                SCOD_SUBGRUPO = SCOD_SUBGRUPO.ToString(),
                SCOD_FONTE = SCOD_FONTE.ToString(),
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                STIPO_SEGURADO = STIPO_SEGURADO.ToString(),
                SNUM_CERTIFICADO = SNUM_CERTIFICADO.ToString(),
                SDAC_CERTIFICADO = SDAC_CERTIFICADO.ToString(),
                STIPO_INCLUSAO = STIPO_INCLUSAO.ToString(),
                SCOD_CLIENTE = SCOD_CLIENTE.ToString(),
                SCOD_AGENCIADOR = SCOD_AGENCIADOR.ToString(),
                SCOD_CORRETOR = SCOD_CORRETOR.ToString(),
                SCOD_PLANOVGAP = SCOD_PLANOVGAP.ToString(),
                SCOD_PLANOAP = SCOD_PLANOAP.ToString(),
                SFAIXA = SFAIXA.ToString(),
                SAUTOR_AUM_AUTOMAT = SAUTOR_AUM_AUTOMAT.ToString(),
                STIPO_BENEFICIARIO = STIPO_BENEFICIARIO.ToString(),
                SPERI_PAGAMENTO = SPERI_PAGAMENTO.ToString(),
                SPERI_RENOVACAO = SPERI_RENOVACAO.ToString(),
                SCOD_OCUPACAO = SCOD_OCUPACAO.ToString(),
                SESTADO_CIVIL = SESTADO_CIVIL.ToString(),
                SIDE_SEXO = SIDE_SEXO.ToString(),
                SCOD_PROFISSAO = SCOD_PROFISSAO.ToString(),
                SNATURALIDADE = SNATURALIDADE.ToString(),
                SOCORR_ENDERECO = SOCORR_ENDERECO.ToString(),
                SOCORR_END_COBRAN = SOCORR_END_COBRAN.ToString(),
                SBCO_COBRANCA = SBCO_COBRANCA.ToString(),
                SAGE_COBRANCA = SAGE_COBRANCA.ToString(),
                SDAC_COBRANCA = SDAC_COBRANCA.ToString(),
                SNUM_MATRICULA = SNUM_MATRICULA.ToString(),
                NUM_CTA_CORRENTE = NUM_CTA_CORRENTE.ToString(),
                DAC_CTA_CORRENTE = DAC_CTA_CORRENTE.ToString(),
                SVAL_SALARIO = SVAL_SALARIO.ToString(),
                STIPO_SALARIO = STIPO_SALARIO.ToString(),
                STIPO_PLANO = STIPO_PLANO.ToString(),
                SPCT_CONJUGE_VG = SPCT_CONJUGE_VG.ToString(),
                SPCT_CONJUGE_AP = SPCT_CONJUGE_AP.ToString(),
                SQTD_SAL_MORNATU = SQTD_SAL_MORNATU.ToString(),
                SQTD_SAL_MORACID = SQTD_SAL_MORACID.ToString(),
                SQTD_SAL_INVPERM = SQTD_SAL_INVPERM.ToString(),
                STAXA_AP_MORACID = STAXA_AP_MORACID.ToString(),
                STAXA_AP_INVPERM = STAXA_AP_INVPERM.ToString(),
                STAXA_AP_AMDS = STAXA_AP_AMDS.ToString(),
                STAXA_AP_DH = STAXA_AP_DH.ToString(),
                STAXA_AP_DIT = STAXA_AP_DIT.ToString(),
                STAXA_VG = STAXA_VG.ToString(),
                MIMP_MORNATU_ANT = MIMP_MORNATU_ANT.ToString(),
                MIMP_MORNATU_ATU = MIMP_MORNATU_ATU.ToString(),
                MIMP_MORACID_ANT = MIMP_MORACID_ANT.ToString(),
                MIMP_MORACID_ATU = MIMP_MORACID_ATU.ToString(),
                MIMP_INVPERM_ANT = MIMP_INVPERM_ANT.ToString(),
                MIMP_INVPERM_ATU = MIMP_INVPERM_ATU.ToString(),
                MIMP_AMDS_ANT = MIMP_AMDS_ANT.ToString(),
                MIMP_AMDS_ATU = MIMP_AMDS_ATU.ToString(),
                MIMP_DH_ANT = MIMP_DH_ANT.ToString(),
                MIMP_DH_ATU = MIMP_DH_ATU.ToString(),
                MIMP_DIT_ANT = MIMP_DIT_ANT.ToString(),
                MIMP_DIT_ATU = MIMP_DIT_ATU.ToString(),
                MPRM_VG_ANT = MPRM_VG_ANT.ToString(),
                MPRM_VG_ATU = MPRM_VG_ATU.ToString(),
                MPRM_AP_ANT = MPRM_AP_ANT.ToString(),
                MPRM_AP_ATU = MPRM_AP_ATU.ToString(),
                MCOD_OPERACAO = MCOD_OPERACAO.ToString(),
                MDATA_OPERACAO = MDATA_OPERACAO.ToString(),
                COD_SUBGRUPO_TRANS = COD_SUBGRUPO_TRANS.ToString(),
                MSIT_REGISTRO = MSIT_REGISTRO.ToString(),
                MCOD_USUARIO = MCOD_USUARIO.ToString(),
                MDATA_AVERBACAO = MDATA_AVERBACAO.ToString(),
                WDATA_AVERBACAO = WDATA_AVERBACAO.ToString(),
                MDATA_ADMISSAO = MDATA_ADMISSAO.ToString(),
                WDATA_ADMISSAO = WDATA_ADMISSAO.ToString(),
                MDATA_INCLUSAO = MDATA_INCLUSAO.ToString(),
                WDATA_INCLUSAO = WDATA_INCLUSAO.ToString(),
                MDATA_NASCIMENTO = MDATA_NASCIMENTO.ToString(),
                WDATA_NASCIMENTO = WDATA_NASCIMENTO.ToString(),
                MDATA_FATURA = MDATA_FATURA.ToString(),
                WDATA_FATURA = WDATA_FATURA.ToString(),
                MDATA_REFERENCIA = MDATA_REFERENCIA.ToString(),
                WDATA_REFERENCIA = WDATA_REFERENCIA.ToString(),
                MDATA_MOVIMENTO = MDATA_MOVIMENTO.ToString(),
                WDATA_MOVIMENTO = WDATA_MOVIMENTO.ToString(),
                MCOD_EMPRESA = MCOD_EMPRESA.ToString(),
                WCOD_EMPRESA = WCOD_EMPRESA.ToString(),
                SLOT_EMP_SEGURADO = SLOT_EMP_SEGURADO.ToString(),
            };

            M_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1_Insert1.Execute(m_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_999_EXIT*/

        [StopWatch]
        /*" M-306-000-ACESSA-FONTE-SECTION */
        private void M_306_000_ACESSA_FONTE_SECTION()
        {
            /*" -1480- MOVE '306' TO WNR-EXEC-SQL. */
            _.Move("306", WABEND.WNR_EXEC_SQL);

            /*" -1482- MOVE '306-000-ACESSA-FONTE' TO PARAGRAFO. */
            _.Move("306-000-ACESSA-FONTE", WABEND.PARAGRAFO);

            /*" -1489- PERFORM M_306_000_ACESSA_FONTE_DB_SELECT_1 */

            M_306_000_ACESSA_FONTE_DB_SELECT_1();

            /*" -1493- COMPUTE FONTE-PROPAUTOM = FONTE-PROPAUTOM + 1 */
            FONTE_PROPAUTOM.Value = FONTE_PROPAUTOM + 1;

            /*" -1494- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1494- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-306-000-ACESSA-FONTE-DB-SELECT-1 */
        public void M_306_000_ACESSA_FONTE_DB_SELECT_1()
        {
            /*" -1489- EXEC SQL SELECT PROPAUTOM INTO :FONTE-PROPAUTOM FROM SEGUROS.V1FONTE WHERE FONTE = :SCOD-FONTE END-EXEC. */

            var m_306_000_ACESSA_FONTE_DB_SELECT_1_Query1 = new M_306_000_ACESSA_FONTE_DB_SELECT_1_Query1()
            {
                SCOD_FONTE = SCOD_FONTE.ToString(),
            };

            var executed_1 = M_306_000_ACESSA_FONTE_DB_SELECT_1_Query1.Execute(m_306_000_ACESSA_FONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTE_PROPAUTOM, FONTE_PROPAUTOM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_306_999_EXIT*/

        [StopWatch]
        /*" M-307-000-ATUALIZA-FONTE-SECTION */
        private void M_307_000_ATUALIZA_FONTE_SECTION()
        {
            /*" -1510- MOVE '307' TO WNR-EXEC-SQL. */
            _.Move("307", WABEND.WNR_EXEC_SQL);

            /*" -1512- MOVE '307-000-ATUALIZA-FONTE' TO PARAGRAFO. */
            _.Move("307-000-ATUALIZA-FONTE", WABEND.PARAGRAFO);

            /*" -1517- PERFORM M_307_000_ATUALIZA_FONTE_DB_UPDATE_1 */

            M_307_000_ATUALIZA_FONTE_DB_UPDATE_1();

            /*" -1520- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1520- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-307-000-ATUALIZA-FONTE-DB-UPDATE-1 */
        public void M_307_000_ATUALIZA_FONTE_DB_UPDATE_1()
        {
            /*" -1517- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :FONTE-PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :SCOD-FONTE END-EXEC. */

            var m_307_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1 = new M_307_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1()
            {
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                SCOD_FONTE = SCOD_FONTE.ToString(),
            };

            M_307_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1.Execute(m_307_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_307_999_EXIT*/

        [StopWatch]
        /*" M-310-000-CALCULA-PRORATA-SECTION */
        private void M_310_000_CALCULA_PRORATA_SECTION()
        {
            /*" -1565- MOVE HDATA-MOVIMENTO TO WK-DATA1 */
            _.Move(HDATA_MOVIMENTO, WK_DATA1);

            /*" -1566- MOVE WK-ANO1 TO W01AACSP */
            _.Move(WK_DATA1.WK_ANO1, FILLER_2.W01AACSP);

            /*" -1567- MOVE WK-MES1 TO W01MMCSP */
            _.Move(WK_DATA1.WK_MES1, FILLER_2.W01MMCSP);

            /*" -1568- MOVE WK-DIA1 TO W01DDCSP */
            _.Move(WK_DATA1.WK_DIA1, FILLER_2.W01DDCSP);

            /*" -1569- MOVE W01DTCSP TO LK-DATA2 */
            _.Move(W01DTCSP, LK_LINK.LK_DATA2);

            /*" -1570- MOVE R-DATA-REFERENCIA TO WK-DATA1 */
            _.Move(R_DATA_REFERENCIA, WK_DATA1);

            /*" -1571- MOVE WK-ANO1 TO W02AACSP */
            _.Move(WK_DATA1.WK_ANO1, FILLER_3.W02AACSP);

            /*" -1572- MOVE WK-MES1 TO W02MMCSP */
            _.Move(WK_DATA1.WK_MES1, FILLER_3.W02MMCSP);

            /*" -1573- MOVE WK-DIA1 TO W02DDCSP */
            _.Move(WK_DATA1.WK_DIA1, FILLER_3.W02DDCSP);

            /*" -1574- MOVE W02DTCSP TO LK-DATA1 */
            _.Move(W02DTCSP, LK_LINK.LK_DATA1);

            /*" -1577- MOVE ZEROS TO QTDIA. */
            _.Move(0, LK_LINK.QTDIA);

            /*" -1580- CALL 'PRODIFC1' USING LK-LINK. */
            _.Call("PRODIFC1", LK_LINK);

            /*" -1581- IF QTDIA GREATER 360 */

            if (LK_LINK.QTDIA > 360)
            {

                /*" -1583- MOVE 360 TO QTDIA. */
                _.Move(360, LK_LINK.QTDIA);
            }


            /*" -1587- DIVIDE QTDIA BY 30 GIVING QTMES REMAINDER RESTO. */
            _.Divide(LK_LINK.QTDIA, 30, QTMES, RESTO);

            /*" -1590- COMPUTE QTMES = QTMES / R-PERI-RENOVACAO. */
            QTMES.Value = QTMES / R_PERI_RENOVACAO;

            /*" -1591- IF RESTO NOT EQUAL 0 */

            if (RESTO != 0)
            {

                /*" -1594- ADD +1 TO QTMES. */
                QTMES.Value = QTMES + +1;
            }


            /*" -1595- COMPUTE W-PCT-AUMENTO = R-PCT-AUMENTO / 12 */
            W_PCT_AUMENTO.Value = R_PCT_AUMENTO / 12f;

            /*" -1597- COMPUTE W-PCT-AUMENTO = W-PCT-AUMENTO * R-PERI-RENOVACAO */
            W_PCT_AUMENTO.Value = W_PCT_AUMENTO * R_PERI_RENOVACAO;

            /*" -1600- COMPUTE W-PCT-AUMENTO = W-PCT-AUMENTO * QTMES */
            W_PCT_AUMENTO.Value = W_PCT_AUMENTO * QTMES;

            /*" -1601- COMPUTE W-PCT-AUMENTO = W-PCT-AUMENTO / 100 */
            W_PCT_AUMENTO.Value = W_PCT_AUMENTO / 100f;

            /*" -1601- COMPUTE W-PCT-AUMENTO = W-PCT-AUMENTO + 1. */
            W_PCT_AUMENTO.Value = W_PCT_AUMENTO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_310_999_EXIT*/

        [StopWatch]
        /*" M-320-000-ACESSA-V1CONTACOR-SECTION */
        private void M_320_000_ACESSA_V1CONTACOR_SECTION()
        {
            /*" -1618- MOVE '320-000-ACESSA-V1CONTACOR' TO PARAGRAFO. */
            _.Move("320-000-ACESSA-V1CONTACOR", WABEND.PARAGRAFO);

            /*" -1620- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", WABEND.WNR_EXEC_SQL);

            /*" -1621- MOVE SCOD-CLIENTE TO OCOD-CLIENTE. */
            _.Move(SCOD_CLIENTE, OCOD_CLIENTE);

            /*" -1623- MOVE SNUM-APOLICE TO ONUM-APOLICE. */
            _.Move(SNUM_APOLICE, ONUM_APOLICE);

            /*" -1639- PERFORM M_320_000_ACESSA_V1CONTACOR_DB_SELECT_1 */

            M_320_000_ACESSA_V1CONTACOR_DB_SELECT_1();

            /*" -1642- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1643- MOVE 0 TO NUM-CTA-CORRENTE */
                _.Move(0, NUM_CTA_CORRENTE);

                /*" -1644- MOVE ' ' TO DAC-CTA-CORRENTE */
                _.Move(" ", DAC_CTA_CORRENTE);

                /*" -1646- GO TO 320-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_320_999_EXIT*/ //GOTO
                return;
            }


            /*" -1647- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1649- DISPLAY 'VG0130B - PROBLEMAS NO ACESSO V1CONTACOR  ' ONUM-APOLICE ' ' OCOD-CLIENTE */

                $"VG0130B - PROBLEMAS NO ACESSO V1CONTACOR  {ONUM_APOLICE} {OCOD_CLIENTE}"
                .Display();

                /*" -1649- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-320-000-ACESSA-V1CONTACOR-DB-SELECT-1 */
        public void M_320_000_ACESSA_V1CONTACOR_DB_SELECT_1()
        {
            /*" -1639- EXEC SQL SELECT COD_CLIENTE, NUM_APOLICE, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE INTO :OCOD-CLIENTE, :ONUM-APOLICE, :NUM-CTA-CORRENTE, :DAC-CTA-CORRENTE FROM SEGUROS.V1CONTACOR WHERE COD_CLIENTE = :OCOD-CLIENTE AND NUM_APOLICE = :ONUM-APOLICE END-EXEC. */

            var m_320_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1 = new M_320_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1()
            {
                OCOD_CLIENTE = OCOD_CLIENTE.ToString(),
                ONUM_APOLICE = ONUM_APOLICE.ToString(),
            };

            var executed_1 = M_320_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1.Execute(m_320_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCOD_CLIENTE, OCOD_CLIENTE);
                _.Move(executed_1.ONUM_APOLICE, ONUM_APOLICE);
                _.Move(executed_1.NUM_CTA_CORRENTE, NUM_CTA_CORRENTE);
                _.Move(executed_1.DAC_CTA_CORRENTE, DAC_CTA_CORRENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_320_999_EXIT*/

        [StopWatch]
        /*" M-700-000-UPDATE-SECTION */
        private void M_700_000_UPDATE_SECTION()
        {
            /*" -1664- MOVE '700-000-UPDATE           ' TO PARAGRAFO. */
            _.Move("700-000-UPDATE           ", WABEND.PARAGRAFO);

            /*" -1666- MOVE '700' TO WNR-EXEC-SQL. */
            _.Move("700", WABEND.WNR_EXEC_SQL);

            /*" -1675- PERFORM M_700_000_UPDATE_DB_UPDATE_1 */

            M_700_000_UPDATE_DB_UPDATE_1();

            /*" -1678- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1679- DISPLAY 'VG0130B - ERRO NA ATUALIZACAO DA V0RELATORIOS' */
                _.Display($"VG0130B - ERRO NA ATUALIZACAO DA V0RELATORIOS");

                /*" -1679- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-700-000-UPDATE-DB-UPDATE-1 */
        public void M_700_000_UPDATE_DB_UPDATE_1()
        {
            /*" -1675- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE CODRELAT = 'VG0130B' AND IDSISTEM = 'VG' AND SITUACAO = '0' AND NUM_APOLICE <> 97010000889 AND NUM_APOLICE = :R-NUM-APOLICE AND CODSUBES = :R-CODSUBES END-EXEC. */

            var m_700_000_UPDATE_DB_UPDATE_1_Update1 = new M_700_000_UPDATE_DB_UPDATE_1_Update1()
            {
                R_NUM_APOLICE = R_NUM_APOLICE.ToString(),
                R_CODSUBES = R_CODSUBES.ToString(),
            };

            M_700_000_UPDATE_DB_UPDATE_1_Update1.Execute(m_700_000_UPDATE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -1689- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1692- DISPLAY 'VG0130B --------------------------------------' . */
            _.Display($"VG0130B --------------------------------------");

            /*" -1693- DISPLAY '  TOTAL DE REGISTROS PROCESSADOS.             ' */
            _.Display($"  TOTAL DE REGISTROS PROCESSADOS.             ");

            /*" -1694- DISPLAY '      TOTAL DE LIDOS............ ' W-LIDOS */
            _.Display($"      TOTAL DE LIDOS............ {W_LIDOS}");

            /*" -1695- DISPLAY '      TOTAL DE GRAVADOS......... ' W-GRAVADOS */
            _.Display($"      TOTAL DE GRAVADOS......... {W_GRAVADOS}");

            /*" -1696- DISPLAY '----------------------------------------------' . */
            _.Display($"----------------------------------------------");

            /*" -1698- DISPLAY 'FIM NORMAL      **** VG0130B ****' */
            _.Display($"FIM NORMAL      **** VG0130B ****");

            /*" -1700- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1700- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO */
        private void M_999_999_ROT_ERRO(bool isPerform = false)
        {
            /*" -1713- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1714- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -1715- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], WABEND.WSQLCODE1);

                /*" -1716- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], WABEND.WSQLCODE2);

                /*" -1717- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, WSQLCODE3);

                /*" -1719- DISPLAY WABEND. */
                _.Display(WABEND);
            }


            /*" -1721- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1725- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1729- MOVE 9 TO RETURN-CODE */
            _.Move(9, RETURN_CODE);

            /*" -1729- GOBACK. */

            throw new GoBack();

        }
    }
}