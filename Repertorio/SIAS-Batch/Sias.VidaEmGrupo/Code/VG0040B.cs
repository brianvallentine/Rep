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
using Sias.VidaEmGrupo.DB2.VG0040B;

namespace Code
{
    public class VG0040B
    {
        public bool IsCall { get; set; }

        public VG0040B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *               *** REABILITACAO ***                             *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  LE TABELA MOVIMENTO E INCLUI DADOS *      */
        /*"      *                             NAS TABELAS ..:V0COBERAPOL         *      */
        /*"      *                                            V0HISTSEGVG         *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  PROCAS                             *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG0040B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  AGOSTO/ 91                         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *              A L T E R A C O E S                               *      */
        /*"      ******************************************************************      */
        /*"V.07  *VERSAO V.07-DEMANDA 281754-KINKAS 29/03/2021-ESTIPULANTE FENAE  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - HIST 181.598                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *   EM 18/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - CADMUS 154.956                                   *      */
        /*"      *             - SELECIONAR MODALIDADE DA APOLICE A SER EMITIDA   *      */
        /*"      *               CHAMANDO SUBROTINA GE0510S.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/10/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.05    *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   ALTERACAO EM  01/07/2015 - COREON - CADMUS 103659            *      */
        /*"      *                - NOVA SOLUCAO DE GESTAO DE DEPOSITOS           *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.04        *      */
        /*"      ******************************************************************      */
        /*"      *   ALTERACAO EM 15-12-2014 - ELIERMES OLIVEIRA - CADMUS 99.500  *      */
        /*"      *                                                                *      */
        /*"      *          - RETORNAR O COD-PROFISSAO DO SEGURADO PARA 9999, PARA*      */
        /*"      *            QUE O CERTIFICADO NAO SEJA CANCELADO NOVAMENTE PELO *      */
        /*"      *            VG0020B                                             *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.03        *      */
        /*"      ******************************************************************      */
        /*"      *   ALTERACAO EM 02-10-2014 - JONNY ANDERSON C.SARAIVA           *      */
        /*"      *                                                                *      */
        /*"      *          - AJUSTE NO CONTEUDO DO CAMPO VGMODALIFR              *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.02        *      */
        /*"      ******************************************************************      */
        /*"      * ALTERACAO EFETUADA EM 16-03-1999 POR LUIZ CARLOS.              *      */
        /*"      *           GERAR DATA TERMINO DE VIGENCIA DO SEGURADO,          *      */
        /*"      *           PROCURAR POR 'LC0399'.                               *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * RECONVERSAO ANO 2000            CONSEDA4           11/09/1998  *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * ALTERACAO EFETUADA EM 13-04-2006 POR FAST COMPUTER.            *      */
        /*"      *           DESFAZER O CONTROLE DE OCORRENCIA DA APOLICE DO CON- *      */
        /*"      *           SORCIO POIS ESTAVA DESPONTERANDO AS TABELAS.         *      */
        /*"      *           PROCURAR POR 'FC0604'.                               *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  MNUM-APOLICE               PIC S9(013)      COMP-3.*/
        public IntBasis MNUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  V0RELA-NUM-APOLICE         PIC S9(013)      COMP-3.*/
        public IntBasis V0RELA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  MCOD-SUBGRUPO              PIC S9(004)      COMP.*/
        public IntBasis MCOD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MCOD-FONTE                 PIC S9(004)      COMP.*/
        public IntBasis MCOD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MNUM-PROPOSTA              PIC S9(009)      COMP.*/
        public IntBasis MNUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  MTIPO-SEGURADO             PIC  X(001).*/
        public StringBasis MTIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0NUM-CERTIFICADO          PIC S9(015)      COMP-3.*/
        public IntBasis V0NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  V0NUM-COUNT                PIC S9(009)      COMP.*/
        public IntBasis V0NUM_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
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
        /*"77  MNUM-CTA-CORRENTE          PIC S9(017)      COMP-3.*/
        public IntBasis MNUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "17", "S9(017)"));
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
        /*"77  SDATA-MOVIMENTO            PIC  X(010).*/
        public StringBasis SDATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MCOD-EMPRESA               PIC S9(009)      COMP.*/
        public IntBasis MCOD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0APOL-RAMO                PIC S9(004)      COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0APOL-MODALIDA            PIC S9(004)      COMP.*/
        public IntBasis V0APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SOCORR-HISTORICO          PIC S9(004)      COMP.*/
        public IntBasis SOCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SNUM-ITEM                 PIC S9(009)      COMP.*/
        public IntBasis SNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  SDATA-TERVIGENCIA         PIC  X(010).*/
        public StringBasis SDATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SDATA-DTTERVIG            PIC  X(010).*/
        public StringBasis SDATA_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SSIT-REGISTRO             PIC  X(001).*/
        public StringBasis SSIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  SNUM-CARNE                PIC S9(004)      COMP.*/
        public IntBasis SNUM_CARNE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  DVLCRUZAD-IMP             PIC S9(006)V9(9) COMP-3.*/
        public DoubleBasis DVLCRUZAD_IMP { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77  DVLCRUZAD-PRM             PIC S9(006)V9(9) COMP-3.*/
        public DoubleBasis DVLCRUZAD_PRM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77  V1SISTEMA-DTMOVABE        PIC  X(010).*/
        public StringBasis V1SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V1PAR-RAMO-VG             PIC S9(009)      COMP.*/
        public IntBasis V1PAR_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V1PAR-RAMO-AP             PIC S9(009)      COMP.*/
        public IntBasis V1PAR_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V1PAR-RAMO-PST            PIC S9(009)      COMP.*/
        public IntBasis V1PAR_RAMO_PST { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V1EN-COD-MOEDA-IMP        PIC S9(004)      COMP.*/
        public IntBasis V1EN_COD_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1EN-COD-MOEDA-PRM        PIC S9(004)      COMP.*/
        public IntBasis V1EN_COD_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VGNUM-APOLICE             PIC S9(013)      COMP-3.*/
        public IntBasis VGNUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  VGNRENDOS                 PIC S9(009)      COMP.*/
        public IntBasis VGNRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  VGNUM-ITEM                PIC S9(009)      COMP.*/
        public IntBasis VGNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  VGOCORHIST                PIC S9(004)      COMP.*/
        public IntBasis VGOCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VGRAMOFR                  PIC S9(004)      COMP.*/
        public IntBasis VGRAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VGMODALIFR                PIC S9(004)      COMP.*/
        public IntBasis VGMODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VGCOD-COBERTURA           PIC S9(004)      COMP.*/
        public IntBasis VGCOD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VGIMP-SEGURADA-IX         PIC S9(013)V99   COMP-3.*/
        public DoubleBasis VGIMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  VGPRM-TARIFARIO-IX        PIC S9(010)V9(5) COMP-3.*/
        public DoubleBasis VGPRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77  VGIMP-SEGURADA-VAR        PIC S9(013)V99   COMP-3.*/
        public DoubleBasis VGIMP_SEGURADA_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  PRM-TARIFARIO-VAR         PIC S9(010)V9(5) COMP-3.*/
        public DoubleBasis PRM_TARIFARIO_VAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77  VGPCT-COBERTURA           PIC S9(003)V99   COMP-3 VALUE +0.*/
        public DoubleBasis VGPCT_COBERTURA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  VGPCT-COBERTURA1          PIC S9(003)V99   COMP-3 VALUE +0.*/
        public DoubleBasis VGPCT_COBERTURA1 { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  VGPCT-COBERTURA2          PIC S9(003)V99   COMP-3 VALUE +0.*/
        public DoubleBasis VGPCT_COBERTURA2 { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  VGFATOR-MULTIPLICA        PIC S9(004)      COMP.*/
        public IntBasis VGFATOR_MULTIPLICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VGDATA-INIVIGENCIA        PIC  X(010).*/
        public StringBasis VGDATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  VGDATA-TERVIGENCIA        PIC  X(010).*/
        public StringBasis VGDATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  VGCOD-EMPRESA             PIC S9(009)      COMP.*/
        public IntBasis VGCOD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  VGSITUACAO                PIC  X(001).*/
        public StringBasis VGSITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  VGSITUACAOI               PIC S9(004)      COMP.*/
        public IntBasis VGSITUACAOI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  HHORA-OPERACAO            PIC  X(008).*/
        public StringBasis HHORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  WHOCORR-HISTORICO         PIC S9(004)      COMP.*/
        public IntBasis WHOCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  HOCORR-HISTORICO          PIC S9(004)      COMP.*/
        public IntBasis HOCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  HCOD-SUBGRUP-TRANS        PIC S9(004)      COMP.*/
        public IntBasis HCOD_SUBGRUP_TRANS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-TERVIGENCIA         PIC S9(004)      COMP.*/
        public IntBasis WDATA_TERVIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-DTTERVIG            PIC S9(004)      COMP.*/
        public IntBasis WDATA_DTTERVIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77  WCOD-MOEDA                PIC S9(004)      COMP VALUE +1.*/
        public IntBasis WCOD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +1);
        /*"77  WNUM-ITEM                 PIC S9(004)      COMP.*/
        public IntBasis WNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  REGISTRO-LINKAGE-GE0510S.*/
        public VG0040B_REGISTRO_LINKAGE_GE0510S REGISTRO_LINKAGE_GE0510S { get; set; } = new VG0040B_REGISTRO_LINKAGE_GE0510S();
        public class VG0040B_REGISTRO_LINKAGE_GE0510S : VarBasis
        {
            /*"    10 LK-GE510-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
            public DoubleBasis LK_GE510_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
            /*"    10 LK-GE510-COD-SUBGRUPO      PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE510_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE510-NUM-CERTIFICADO   PIC S9(15)V USAGE COMP-3.*/
            public DoubleBasis LK_GE510_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*"    10 LK-GE510-COD-MODALIDADE    PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE510_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE510-COD-REJEICAO      PIC  X(10).*/
            public StringBasis LK_GE510_COD_REJEICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE510-COD-RETORNO       PIC  X(01).*/
            public StringBasis LK_GE510_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    10 LK-GE510-MENSAGEM.*/
            public VG0040B_LK_GE510_MENSAGEM LK_GE510_MENSAGEM { get; set; } = new VG0040B_LK_GE510_MENSAGEM();
            public class VG0040B_LK_GE510_MENSAGEM : VarBasis
            {
                /*"       20 LK-GE510-SQLCODE        PIC -ZZ9.*/
                public IntBasis LK_GE510_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       20 FILLER                  PIC X(01).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       20 LK-GE510-MSG-RETORNO    PIC X(75).*/
                public StringBasis LK_GE510_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
                /*"01  WS-DADOS-AUXILIARES.*/
            }
        }
        public VG0040B_WS_DADOS_AUXILIARES WS_DADOS_AUXILIARES { get; set; } = new VG0040B_WS_DADOS_AUXILIARES();
        public class VG0040B_WS_DADOS_AUXILIARES : VarBasis
        {
            /*"  03            WANO-BISSEXTO       PIC  9(004) VALUE ZEROS.*/
            public IntBasis WANO_BISSEXTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            AC-GRAVA            PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            WFIM-MOVIMENTO      PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WFIM-INCLUSAO       PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WTEM-MOVIMENTO      PIC  X(001) VALUE 'N'.*/
            public StringBasis WTEM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WAPOLICE-ATU        PIC S9(013) VALUE +0 COMP-3.*/
            public IntBasis WAPOLICE_ATU { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  03            WAPOLICE-ANT        PIC S9(013) VALUE +0 COMP-3.*/
            public IntBasis WAPOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  03            WHORA-OPERACAO-WORK.*/
            public VG0040B_WHORA_OPERACAO_WORK WHORA_OPERACAO_WORK { get; set; } = new VG0040B_WHORA_OPERACAO_WORK();
            public class VG0040B_WHORA_OPERACAO_WORK : VarBasis
            {
                /*"    05          WHORA-HORA          PIC  X(002).*/
                public StringBasis WHORA_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05          FILLER              PIC  X(001)  VALUE '.'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    05          WHORA-MINU          PIC  X(002).*/
                public StringBasis WHORA_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05          FILLER              PIC  X(001) VALUE '.'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    05          WHORA-SEGU          PIC  X(002).*/
                public StringBasis WHORA_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  03            WHORA-OPERACAO-WORK-R    REDEFINES                WHORA-OPERACAO-WORK      PIC  X(008).*/
            }
            private _REDEF_StringBasis _whora_operacao_work_r { get; set; }
            public _REDEF_StringBasis WHORA_OPERACAO_WORK_R
            {
                get { _whora_operacao_work_r = new _REDEF_StringBasis(new PIC("X", "008", "X(008).")); ; _.Move(WHORA_OPERACAO_WORK, _whora_operacao_work_r); VarBasis.RedefinePassValue(WHORA_OPERACAO_WORK, _whora_operacao_work_r, WHORA_OPERACAO_WORK); _whora_operacao_work_r.ValueChanged += () => { _.Move(_whora_operacao_work_r, WHORA_OPERACAO_WORK); }; return _whora_operacao_work_r; }
                set { VarBasis.RedefinePassValue(value, _whora_operacao_work_r, WHORA_OPERACAO_WORK); }
            }  //Redefines
            /*"  03            WHORA-OPERACAO-1    PIC 99999999.*/
            public IntBasis WHORA_OPERACAO_1 { get; set; } = new IntBasis(new PIC("9", "8", "99999999."));
            /*"  03            WHORA-PER-X REDEFINES WHORA-OPERACAO-1.*/
            private _REDEF_VG0040B_WHORA_PER_X _whora_per_x { get; set; }
            public _REDEF_VG0040B_WHORA_PER_X WHORA_PER_X
            {
                get { _whora_per_x = new _REDEF_VG0040B_WHORA_PER_X(); _.Move(WHORA_OPERACAO_1, _whora_per_x); VarBasis.RedefinePassValue(WHORA_OPERACAO_1, _whora_per_x, WHORA_OPERACAO_1); _whora_per_x.ValueChanged += () => { _.Move(_whora_per_x, WHORA_OPERACAO_1); }; return _whora_per_x; }
                set { VarBasis.RedefinePassValue(value, _whora_per_x, WHORA_OPERACAO_1); }
            }  //Redefines
            public class _REDEF_VG0040B_WHORA_PER_X : VarBasis
            {
                /*"     05         WHORA-OPERACAO-2    PIC 999999.*/
                public IntBasis WHORA_OPERACAO_2 { get; set; } = new IntBasis(new PIC("9", "6", "999999."));
                /*"     05         FILLER              PIC 99.*/
                public IntBasis FILLER_3 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"  03            WHORA-OPERACAO.*/

                public _REDEF_VG0040B_WHORA_PER_X()
                {
                    WHORA_OPERACAO_2.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                }

            }
            public VG0040B_WHORA_OPERACAO WHORA_OPERACAO { get; set; } = new VG0040B_WHORA_OPERACAO();
            public class VG0040B_WHORA_OPERACAO : VarBasis
            {
                /*"    05          WHORA-HORA-W        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_HORA_W { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-MINU-W        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_MINU_W { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-SEGU-W        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_SEGU_W { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WHORA-OPERACAO-R    REDEFINES                WHORA-OPERACAO      PIC  9(006).*/
            }
            private _REDEF_IntBasis _whora_operacao_r { get; set; }
            public _REDEF_IntBasis WHORA_OPERACAO_R
            {
                get { _whora_operacao_r = new _REDEF_IntBasis(new PIC("9", "006", "9(006).")); ; _.Move(WHORA_OPERACAO, _whora_operacao_r); VarBasis.RedefinePassValue(WHORA_OPERACAO, _whora_operacao_r, WHORA_OPERACAO); _whora_operacao_r.ValueChanged += () => { _.Move(_whora_operacao_r, WHORA_OPERACAO); }; return _whora_operacao_r; }
                set { VarBasis.RedefinePassValue(value, _whora_operacao_r, WHORA_OPERACAO); }
            }  //Redefines
            /*"  03            WS-W01DTSQL.*/
            public VG0040B_WS_W01DTSQL WS_W01DTSQL { get; set; } = new VG0040B_WS_W01DTSQL();
            public class VG0040B_WS_W01DTSQL : VarBasis
            {
                /*"    05          WS-W01AASQL         PIC  9(004).*/
                public IntBasis WS_W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-W01T1SQL         PIC  X(001).*/
                public StringBasis WS_W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WS-W01MMSQL         PIC  9(002).*/
                public IntBasis WS_W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W01T2SQL         PIC  X(001).*/
                public StringBasis WS_W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WS-W01DDSQL         PIC  9(002).*/
                public IntBasis WS_W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-W01DTTRAB.*/
            }
            public VG0040B_WS_W01DTTRAB WS_W01DTTRAB { get; set; } = new VG0040B_WS_W01DTTRAB();
            public class VG0040B_WS_W01DTTRAB : VarBasis
            {
                /*"    05          WS-W01AATRAB        PIC  9(004).*/
                public IntBasis WS_W01AATRAB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-W01T1TRAB        PIC  X(001).*/
                public StringBasis WS_W01T1TRAB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WS-W01MMTRAB        PIC  9(002).*/
                public IntBasis WS_W01MMTRAB { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W01T2TRAB        PIC  X(001).*/
                public StringBasis WS_W01T2TRAB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WS-W01DDTRAB        PIC  9(002).*/
                public IntBasis WS_W01DDTRAB { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WPRMTOT             PIC S9(013)V99                                        VALUE +0 COMP-3.*/
            }
            public DoubleBasis WPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WABEND.*/
            public VG0040B_WABEND WABEND { get; set; } = new VG0040B_WABEND();
            public class VG0040B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' VG0040B'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0040B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public VG0040B_LK_LINK LK_LINK { get; set; } = new VG0040B_LK_LINK();
        public class VG0040B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public VG0040B_TMOVIMENTO TMOVIMENTO { get; set; } = new VG0040B_TMOVIMENTO();
        public VG0040B_CDEBTO CDEBTO { get; set; } = new VG0040B_CDEBTO();
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
            /*" -371- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -373- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -375- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -379- PERFORM 060-000-LER-TSISTEMA. */

            M_060_000_LER_TSISTEMA(true);

            /*" -381- PERFORM 070-000-LER-V1PARAMRAMO. */

            M_070_000_LER_V1PARAMRAMO_SECTION();

            /*" -383- PERFORM 080-000-LER-V1MOEDA. */

            M_080_000_LER_V1MOEDA_SECTION();

            /*" -385- PERFORM 090-000-CURSOR-V1MOVIMENTO */

            M_090_000_CURSOR_V1MOVIMENTO_SECTION();

            /*" -389- PERFORM 120-000-FETCH-V1MOVIMENTO UNTIL WFIM-MOVIMENTO = 'S' . */

            while (!(WS_DADOS_AUXILIARES.WFIM_MOVIMENTO == "S"))
            {

                M_120_000_FETCH_V1MOVIMENTO_SECTION();
            }

            /*" -390- GO TO 900-000-FINALIZA */

            M_900_000_FINALIZA_SECTION(); //GOTO
            return;

            /*" -390- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA */
        private void M_060_000_LER_TSISTEMA(bool isPerform = false)
        {
            /*" -404- MOVE '060-000-LER-TSISTEMA' TO PARAGRAFO. */
            _.Move("060-000-LER-TSISTEMA", WS_DADOS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -406- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -412- PERFORM M_060_000_LER_TSISTEMA_DB_SELECT_1 */

            M_060_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -415- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -416- DISPLAY 'VG0040B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"VG0040B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -417- DISPLAY 'IDSISTEM =  VG ' */
                _.Display($"IDSISTEM =  VG ");

                /*" -417- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_060_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -412- EXEC SQL SELECT DTMOVABE INTO :V1SISTEMA-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

            var m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1 = new M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1.Execute(m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SISTEMA_DTMOVABE, V1SISTEMA_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_060_999_EXIT*/

        [StopWatch]
        /*" M-070-000-LER-V1PARAMRAMO-SECTION */
        private void M_070_000_LER_V1PARAMRAMO_SECTION()
        {
            /*" -433- MOVE '070-000-LER-V1PARAMRAMO' TO PARAGRAFO. */
            _.Move("070-000-LER-V1PARAMRAMO", WS_DADOS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -435- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -440- PERFORM M_070_000_LER_V1PARAMRAMO_DB_SELECT_1 */

            M_070_000_LER_V1PARAMRAMO_DB_SELECT_1();

            /*" -443- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -444- DISPLAY 'VG0040B - NAO CONSTA REGISTRO NA V1PARAMRAMO' */
                _.Display($"VG0040B - NAO CONSTA REGISTRO NA V1PARAMRAMO");

                /*" -444- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-070-000-LER-V1PARAMRAMO-DB-SELECT-1 */
        public void M_070_000_LER_V1PARAMRAMO_DB_SELECT_1()
        {
            /*" -440- EXEC SQL SELECT RAMO_VG, RAMO_AP, NUM_RAMO_PRSTMISTA INTO :V1PAR-RAMO-VG, :V1PAR-RAMO-AP, :V1PAR-RAMO-PST FROM SEGUROS.V1PARAMRAMO END-EXEC. */

            var m_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1 = new M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1.Execute(m_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PAR_RAMO_VG, V1PAR_RAMO_VG);
                _.Move(executed_1.V1PAR_RAMO_AP, V1PAR_RAMO_AP);
                _.Move(executed_1.V1PAR_RAMO_PST, V1PAR_RAMO_PST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_070_999_EXIT*/

        [StopWatch]
        /*" M-080-000-LER-V1MOEDA-SECTION */
        private void M_080_000_LER_V1MOEDA_SECTION()
        {
            /*" -461- MOVE '080-000-LER-V1MOEDA' TO PARAGRAFO. */
            _.Move("080-000-LER-V1MOEDA", WS_DADOS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -463- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -471- PERFORM M_080_000_LER_V1MOEDA_DB_SELECT_1 */

            M_080_000_LER_V1MOEDA_DB_SELECT_1();

            /*" -474- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -475- DISPLAY 'VG0040B - NAO CONSTA REGISTRO NA V1MOEDA' */
                _.Display($"VG0040B - NAO CONSTA REGISTRO NA V1MOEDA");

                /*" -477- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -478- MOVE V1EN-COD-MOEDA-IMP TO V1EN-COD-MOEDA-PRM. */
            _.Move(V1EN_COD_MOEDA_IMP, V1EN_COD_MOEDA_PRM);

            /*" -478- MOVE DVLCRUZAD-IMP TO DVLCRUZAD-PRM. */
            _.Move(DVLCRUZAD_IMP, DVLCRUZAD_PRM);

        }

        [StopWatch]
        /*" M-080-000-LER-V1MOEDA-DB-SELECT-1 */
        public void M_080_000_LER_V1MOEDA_DB_SELECT_1()
        {
            /*" -471- EXEC SQL SELECT CODUNIMO, VLCRUZAD INTO :V1EN-COD-MOEDA-IMP, :DVLCRUZAD-IMP FROM SEGUROS.V1MOEDA WHERE TIPO_MOEDA = '0' AND SITUACAO = '0' END-EXEC. */

            var m_080_000_LER_V1MOEDA_DB_SELECT_1_Query1 = new M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1.Execute(m_080_000_LER_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EN_COD_MOEDA_IMP, V1EN_COD_MOEDA_IMP);
                _.Move(executed_1.DVLCRUZAD_IMP, DVLCRUZAD_IMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_080_999_EXIT*/

        [StopWatch]
        /*" M-090-000-CURSOR-V1MOVIMENTO-SECTION */
        private void M_090_000_CURSOR_V1MOVIMENTO_SECTION()
        {
            /*" -496- MOVE '090-000-CURSOR-V1MOVIMENTO' TO PARAGRAFO */
            _.Move("090-000-CURSOR-V1MOVIMENTO", WS_DADOS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -498- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -588- PERFORM M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1 */

            M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1();

            /*" -592- PERFORM M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1 */

            M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1MOVIMENTO-DB-DECLARE-1 */
        public void M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1()
        {
            /*" -588- EXEC SQL DECLARE TMOVIMENTO CURSOR FOR SELECT A.NUM_APOLICE, A.COD_SUBGRUPO, A.COD_FONTE, A.NUM_PROPOSTA, A.TIPO_SEGURADO, A.NUM_CERTIFICADO, A.DAC_CERTIFICADO, A.TIPO_INCLUSAO, A.COD_CLIENTE, A.COD_AGENCIADOR, A.COD_CORRETOR, A.COD_PLANOVGAP, A.COD_PLANOAP, A.FAIXA, A.AUTOR_AUM_AUTOMAT, A.TIPO_BENEFICIARIO, A.PERI_PAGAMENTO, A.PERI_RENOVACAO, A.COD_OCUPACAO, A.ESTADO_CIVIL, A.IDE_SEXO, A.COD_PROFISSAO, A.NATURALIDADE, A.OCORR_ENDERECO, A.OCORR_END_COBRAN, A.BCO_COBRANCA, A.AGE_COBRANCA, A.DAC_COBRANCA, A.NUM_MATRICULA, A.NUM_CTA_CORRENTE, A.DAC_CTA_CORRENTE, A.VAL_SALARIO, A.TIPO_SALARIO, A.TIPO_PLANO, A.PCT_CONJUGE_VG, A.PCT_CONJUGE_AP, A.QTD_SAL_MORNATU, A.QTD_SAL_MORACID, A.QTD_SAL_INVPERM, A.TAXA_AP_MORACID, A.TAXA_AP_INVPERM, A.TAXA_AP_AMDS, A.TAXA_AP_DH, A.TAXA_AP_DIT, A.TAXA_VG, A.IMP_MORNATU_ANT, A.IMP_MORNATU_ATU, A.IMP_MORACID_ANT, A.IMP_MORACID_ATU, A.IMP_INVPERM_ANT, A.IMP_INVPERM_ATU, A.IMP_AMDS_ANT, A.IMP_AMDS_ATU, A.IMP_DH_ANT, A.IMP_DH_ATU, A.IMP_DIT_ANT, A.IMP_DIT_ATU, A.PRM_VG_ANT, A.PRM_VG_ATU, A.PRM_AP_ANT, A.PRM_AP_ATU, A.COD_OPERACAO, A.DATA_OPERACAO, A.COD_SUBGRUPO_TRANS, A.SIT_REGISTRO, A.COD_USUARIO, A.DATA_AVERBACAO, A.DATA_ADMISSAO, A.DATA_INCLUSAO, A.DATA_NASCIMENTO, A.DATA_FATURA, A.DATA_REFERENCIA, A.DATA_MOVIMENTO, A.DATA_MOVIMENTO - 1 DAY, A.COD_EMPRESA, B.RAMO, B.MODALIDA FROM SEGUROS.V1MOVIMENTO A, SEGUROS.V0APOLICE B WHERE A.DATA_AVERBACAO IS NOT NULL AND A.DATA_INCLUSAO IS NULL AND A.COD_OPERACAO >= 0500 AND A.COD_OPERACAO <= 0599 AND A.NUM_APOLICE = B.NUM_APOLICE AND A.DATA_OPERACAO > '2015-06-01' END-EXEC. */
            TMOVIMENTO = new VG0040B_TMOVIMENTO(false);
            string GetQuery_TMOVIMENTO()
            {
                var query = @$"SELECT 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.COD_FONTE
							, 
							A.NUM_PROPOSTA
							, 
							A.TIPO_SEGURADO
							, 
							A.NUM_CERTIFICADO
							, 
							A.DAC_CERTIFICADO
							, 
							A.TIPO_INCLUSAO
							, 
							A.COD_CLIENTE
							, 
							A.COD_AGENCIADOR
							, 
							A.COD_CORRETOR
							, 
							A.COD_PLANOVGAP
							, 
							A.COD_PLANOAP
							, 
							A.FAIXA
							, 
							A.AUTOR_AUM_AUTOMAT
							, 
							A.TIPO_BENEFICIARIO
							, 
							A.PERI_PAGAMENTO
							, 
							A.PERI_RENOVACAO
							, 
							A.COD_OCUPACAO
							, 
							A.ESTADO_CIVIL
							, 
							A.IDE_SEXO
							, 
							A.COD_PROFISSAO
							, 
							A.NATURALIDADE
							, 
							A.OCORR_ENDERECO
							, 
							A.OCORR_END_COBRAN
							, 
							A.BCO_COBRANCA
							, 
							A.AGE_COBRANCA
							, 
							A.DAC_COBRANCA
							, 
							A.NUM_MATRICULA
							, 
							A.NUM_CTA_CORRENTE
							, 
							A.DAC_CTA_CORRENTE
							, 
							A.VAL_SALARIO
							, 
							A.TIPO_SALARIO
							, 
							A.TIPO_PLANO
							, 
							A.PCT_CONJUGE_VG
							, 
							A.PCT_CONJUGE_AP
							, 
							A.QTD_SAL_MORNATU
							, 
							A.QTD_SAL_MORACID
							, 
							A.QTD_SAL_INVPERM
							, 
							A.TAXA_AP_MORACID
							, 
							A.TAXA_AP_INVPERM
							, 
							A.TAXA_AP_AMDS
							, 
							A.TAXA_AP_DH
							, 
							A.TAXA_AP_DIT
							, 
							A.TAXA_VG
							, 
							A.IMP_MORNATU_ANT
							, 
							A.IMP_MORNATU_ATU
							, 
							A.IMP_MORACID_ANT
							, 
							A.IMP_MORACID_ATU
							, 
							A.IMP_INVPERM_ANT
							, 
							A.IMP_INVPERM_ATU
							, 
							A.IMP_AMDS_ANT
							, 
							A.IMP_AMDS_ATU
							, 
							A.IMP_DH_ANT
							, 
							A.IMP_DH_ATU
							, 
							A.IMP_DIT_ANT
							, 
							A.IMP_DIT_ATU
							, 
							A.PRM_VG_ANT
							, 
							A.PRM_VG_ATU
							, 
							A.PRM_AP_ANT
							, 
							A.PRM_AP_ATU
							, 
							A.COD_OPERACAO
							, 
							A.DATA_OPERACAO
							, 
							A.COD_SUBGRUPO_TRANS
							, 
							A.SIT_REGISTRO
							, 
							A.COD_USUARIO
							, 
							A.DATA_AVERBACAO
							, 
							A.DATA_ADMISSAO
							, 
							A.DATA_INCLUSAO
							, 
							A.DATA_NASCIMENTO
							, 
							A.DATA_FATURA
							, 
							A.DATA_REFERENCIA
							, 
							A.DATA_MOVIMENTO
							, 
							A.DATA_MOVIMENTO - 1 DAY
							, 
							A.COD_EMPRESA
							, 
							B.RAMO
							, 
							B.MODALIDA 
							FROM SEGUROS.V1MOVIMENTO A
							, 
							SEGUROS.V0APOLICE B 
							WHERE 
							A.DATA_AVERBACAO IS NOT NULL AND 
							A.DATA_INCLUSAO IS NULL AND 
							A.COD_OPERACAO >= 0500 AND 
							A.COD_OPERACAO <= 0599 AND 
							A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.DATA_OPERACAO > '2015-06-01'";

                return query;
            }
            TMOVIMENTO.GetQueryEvent += GetQuery_TMOVIMENTO;

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1MOVIMENTO-DB-OPEN-1 */
        public void M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1()
        {
            /*" -592- EXEC SQL OPEN TMOVIMENTO END-EXEC. */

            TMOVIMENTO.Open();

        }

        [StopWatch]
        /*" M-430-000-MIGRACAO-VIDAZUL-DB-DECLARE-1 */
        public void M_430_000_MIGRACAO_VIDAZUL_DB_DECLARE_1()
        {
            /*" -1718- EXEC SQL DECLARE CDEBTO CURSOR FOR SELECT NRPARCEL FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :MNUM-CERTIFICADO ORDER BY NRPARCEL DESC END-EXEC. */
            CDEBTO = new VG0040B_CDEBTO(true);
            string GetQuery_CDEBTO()
            {
                var query = @$"SELECT NRPARCEL 
							FROM 
							SEGUROS.V0PARCELVA 
							WHERE 
							NRCERTIF = '{MNUM_CERTIFICADO}' 
							ORDER BY NRPARCEL DESC";

                return query;
            }
            CDEBTO.GetQueryEvent += GetQuery_CDEBTO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-120-000-FETCH-V1MOVIMENTO-SECTION */
        private void M_120_000_FETCH_V1MOVIMENTO_SECTION()
        {
            /*" -609- MOVE '120-000-FETCH-V1MOVIMENTO' TO PARAGRAFO */
            _.Move("120-000-FETCH-V1MOVIMENTO", WS_DADOS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -611- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -612- MOVE -1 TO WDATA-DTTERVIG */
            _.Move(-1, WDATA_DTTERVIG);

            /*" -614- MOVE WDATA-DTTERVIG TO SDATA-DTTERVIG. */
            _.Move(WDATA_DTTERVIG, SDATA_DTTERVIG);

            /*" -694- PERFORM M_120_000_FETCH_V1MOVIMENTO_DB_FETCH_1 */

            M_120_000_FETCH_V1MOVIMENTO_DB_FETCH_1();

            /*" -697- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -698- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", WS_DADOS_AUXILIARES.WFIM_MOVIMENTO);

                /*" -698- PERFORM M_120_000_FETCH_V1MOVIMENTO_DB_CLOSE_1 */

                M_120_000_FETCH_V1MOVIMENTO_DB_CLOSE_1();

                /*" -702- GO TO 120-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/ //GOTO
                return;
            }


            /*" -705- IF V0APOL-RAMO EQUAL V1PAR-RAMO-VG AND V0APOL-MODALIDA EQUAL 2 NEXT SENTENCE */

            if (V0APOL_RAMO == V1PAR_RAMO_VG && V0APOL_MODALIDA == 2)
            {

                /*" -706- ELSE */
            }
            else
            {


                /*" -708- IF MIMP-MORNATU-ATU > +0 AND MPRM-VG-ATU EQUAL +0 */

                if (MIMP_MORNATU_ATU > +0 && MPRM_VG_ATU == +0)
                {

                    /*" -710- MOVE 0,01 TO MPRM-VG-ATU. */
                    _.Move(0.01, MPRM_VG_ATU);
                }

            }


            /*" -713- IF V0APOL-RAMO EQUAL V1PAR-RAMO-VG AND V0APOL-MODALIDA EQUAL 2 NEXT SENTENCE */

            if (V0APOL_RAMO == V1PAR_RAMO_VG && V0APOL_MODALIDA == 2)
            {

                /*" -714- ELSE */
            }
            else
            {


                /*" -717- IF (MIMP-MORACID-ATU > +0 OR MIMP-INVPERM-ATU > +0) AND MPRM-AP-ATU EQUAL +0 */

                if ((MIMP_MORACID_ATU > +0 || MIMP_INVPERM_ATU > +0) && MPRM_AP_ATU == +0)
                {

                    /*" -719- MOVE 0,01 TO MPRM-AP-ATU. */
                    _.Move(0.01, MPRM_AP_ATU);
                }

            }


            /*" -721- IF MPRM-VG-ATU EQUAL ZEROS AND MPRM-AP-ATU EQUAL ZEROS */

            if (MPRM_VG_ATU == 00 && MPRM_AP_ATU == 00)
            {

                /*" -722- DISPLAY 'PREMIOS ZERADOS ' */
                _.Display($"PREMIOS ZERADOS ");

                /*" -723- DISPLAY 'APOLICE         ' MNUM-APOLICE */
                _.Display($"APOLICE         {MNUM_APOLICE}");

                /*" -724- DISPLAY 'SUBGRUPO        ' MCOD-SUBGRUPO */
                _.Display($"SUBGRUPO        {MCOD_SUBGRUPO}");

                /*" -725- DISPLAY 'FONTE           ' MCOD-FONTE */
                _.Display($"FONTE           {MCOD_FONTE}");

                /*" -726- DISPLAY 'PROPOSTA        ' MNUM-PROPOSTA */
                _.Display($"PROPOSTA        {MNUM_PROPOSTA}");

                /*" -727- DISPLAY 'NRCERTIF        ' MNUM-CERTIFICADO */
                _.Display($"NRCERTIF        {MNUM_CERTIFICADO}");

                /*" -728- DISPLAY 'NAO PROCESSADO - PULADO ' */
                _.Display($"NAO PROCESSADO - PULADO ");

                /*" -730- GO TO 120-000-FETCH-V1MOVIMENTO. */
                new Task(() => M_120_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -733- IF V0APOL-RAMO EQUAL V1PAR-RAMO-VG AND V0APOL-MODALIDA EQUAL 2 NEXT SENTENCE */

            if (V0APOL_RAMO == V1PAR_RAMO_VG && V0APOL_MODALIDA == 2)
            {

                /*" -734- ELSE */
            }
            else
            {


                /*" -736- IF MIMP-MORNATU-ATU EQUAL ZEROS AND MIMP-MORACID-ATU EQUAL ZEROS */

                if (MIMP_MORNATU_ATU == 00 && MIMP_MORACID_ATU == 00)
                {

                    /*" -737- DISPLAY 'COBERTURAS BASICAS ZERADAS ' */
                    _.Display($"COBERTURAS BASICAS ZERADAS ");

                    /*" -738- DISPLAY 'APOLICE         ' MNUM-APOLICE */
                    _.Display($"APOLICE         {MNUM_APOLICE}");

                    /*" -739- DISPLAY 'SUBGRUPO        ' MCOD-SUBGRUPO */
                    _.Display($"SUBGRUPO        {MCOD_SUBGRUPO}");

                    /*" -740- DISPLAY 'FONTE           ' MCOD-FONTE */
                    _.Display($"FONTE           {MCOD_FONTE}");

                    /*" -741- DISPLAY 'PROPOSTA        ' MNUM-PROPOSTA */
                    _.Display($"PROPOSTA        {MNUM_PROPOSTA}");

                    /*" -742- DISPLAY 'NRCERTIF        ' MNUM-CERTIFICADO */
                    _.Display($"NRCERTIF        {MNUM_CERTIFICADO}");

                    /*" -743- DISPLAY 'NAO PROCESSADO - PULADO' */
                    _.Display($"NAO PROCESSADO - PULADO");

                    /*" -745- GO TO 120-000-FETCH-V1MOVIMENTO. */
                    new Task(() => M_120_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


            /*" -747- MOVE MNUM-APOLICE TO WAPOLICE-ATU. */
            _.Move(MNUM_APOLICE, WS_DADOS_AUXILIARES.WAPOLICE_ATU);

            /*" -748- IF MDATA-MOVIMENTO GREATER MDATA-REFERENCIA */

            if (MDATA_MOVIMENTO > MDATA_REFERENCIA)
            {

                /*" -749- MOVE MDATA-MOVIMENTO TO WS-W01DTSQL */
                _.Move(MDATA_MOVIMENTO, WS_DADOS_AUXILIARES.WS_W01DTSQL);

                /*" -750- MOVE 01 TO WS-W01DDSQL */
                _.Move(01, WS_DADOS_AUXILIARES.WS_W01DTSQL.WS_W01DDSQL);

                /*" -752- MOVE WS-W01DTSQL TO MDATA-REFERENCIA. */
                _.Move(WS_DADOS_AUXILIARES.WS_W01DTSQL, MDATA_REFERENCIA);
            }


            /*" -754- PERFORM 150-000-SELECT-V1SEGURAVG. */

            M_150_000_SELECT_V1SEGURAVG_SECTION();

            /*" -755- IF SSIT-REGISTRO EQUAL '0' OR '1' */

            if (SSIT_REGISTRO.In("0", "1"))
            {

                /*" -759- DISPLAY 'CERTIFICADO JA REABILITADO ' MCOD-FONTE ' ' MNUM-PROPOSTA ' ' MNUM-CERTIFICADO */

                $"CERTIFICADO JA REABILITADO {MCOD_FONTE} {MNUM_PROPOSTA} {MNUM_CERTIFICADO}"
                .Display();

                /*" -761- GO TO 120-000-FETCH-V1MOVIMENTO. */
                new Task(() => M_120_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -762- IF MNUM-APOLICE EQUAL 109300000635 */

            if (MNUM_APOLICE == 109300000635)
            {

                /*" -764- PERFORM 160-000-SELECT-V0MOVIMENTO */

                M_160_000_SELECT_V0MOVIMENTO_SECTION();

                /*" -765- IF WTEM-MOVIMENTO EQUAL 'S' */

                if (WS_DADOS_AUXILIARES.WTEM_MOVIMENTO == "S")
                {

                    /*" -767- DISPLAY '*** MOVIMENTO PENDENTE - REATIVACAO NAO EFETUADA ****' */
                    _.Display($"*** MOVIMENTO PENDENTE - REATIVACAO NAO EFETUADA ****");

                    /*" -769- DISPLAY MNUM-CERTIFICADO ' ' MNUM-APOLICE ' ' */

                    $"{MNUM_CERTIFICADO} {MNUM_APOLICE} "
                    .Display();

                    /*" -770- GO TO 120-000-FETCH-V1MOVIMENTO */
                    new Task(() => M_120_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -771- END-IF */
                }


                /*" -773- END-IF */
            }


            /*" -775- PERFORM R7777-CONS-MODALIDADE-APOL. */

            R7777_CONS_MODALIDADE_APOL_SECTION();

            /*" -777- PERFORM 210-000-MONTA-V0COBERAPOL. */

            M_210_000_MONTA_V0COBERAPOL_SECTION();

            /*" -779- PERFORM 330-000-INSERE-V0HISTSEGVG. */

            M_330_000_INSERE_V0HISTSEGVG_SECTION();

            /*" -781- PERFORM 350-000-DETERMINA-DTTERVIG. */

            M_350_000_DETERMINA_DTTERVIG_SECTION();

            /*" -783- PERFORM 360-000-UPDATE-V0SEGURAVG. */

            M_360_000_UPDATE_V0SEGURAVG_SECTION();

            /*" -785- PERFORM 390-000-UPDATE-V0MOVIMENTO. */

            M_390_000_UPDATE_V0MOVIMENTO_SECTION();

            /*" -785- PERFORM 420-000-UPDATE-V0PROPOSTAVA. */

            M_420_000_UPDATE_V0PROPOSTAVA_SECTION();

        }

        [StopWatch]
        /*" M-120-000-FETCH-V1MOVIMENTO-DB-FETCH-1 */
        public void M_120_000_FETCH_V1MOVIMENTO_DB_FETCH_1()
        {
            /*" -694- EXEC SQL FETCH TMOVIMENTO INTO :MNUM-APOLICE, :MCOD-SUBGRUPO, :MCOD-FONTE, :MNUM-PROPOSTA, :MTIPO-SEGURADO, :MNUM-CERTIFICADO, :MDAC-CERTIFICADO, :MTIPO-INCLUSAO, :MCOD-CLIENTE, :MCOD-AGENCIADOR, :MCOD-CORRETOR, :MCOD-PLANOVGAP, :MCOD-PLANOAP, :MFAIXA, :MAUTOR-AUM-AUTOMAT, :MTIPO-BENEFICIARIO, :MPERI-PAGAMENTO, :MPERI-RENOVACAO, :MCOD-OCUPACAO, :MESTADO-CIVIL, :MIDE-SEXO, :MCOD-PROFISSAO, :MNATURALIDADE, :MOCORR-ENDERECO, :MOCORR-END-COBRAN, :MBCO-COBRANCA, :MAGE-COBRANCA, :MDAC-COBRANCA, :MNUM-MATRICULA, :MNUM-CTA-CORRENTE, :MDAC-CTA-CORRENTE, :MVAL-SALARIO, :MTIPO-SALARIO, :MTIPO-PLANO, :MPCT-CONJUGE-VG, :MPCT-CONJUGE-AP, :MQTD-SAL-MORNATU, :MQTD-SAL-MORACID, :MQTD-SAL-INVPERM, :MTAXA-AP-MORACID, :MTAXA-AP-INVPERM, :MTAXA-AP-AMDS, :MTAXA-AP-DH, :MTAXA-AP-DIT, :MTAXA-VG, :MIMP-MORNATU-ANT, :MIMP-MORNATU-ATU, :MIMP-MORACID-ANT, :MIMP-MORACID-ATU, :MIMP-INVPERM-ANT, :MIMP-INVPERM-ATU, :MIMP-AMDS-ANT, :MIMP-AMDS-ATU, :MIMP-DH-ANT, :MIMP-DH-ATU, :MIMP-DIT-ANT, :MIMP-DIT-ATU, :MPRM-VG-ANT, :MPRM-VG-ATU, :MPRM-AP-ANT, :MPRM-AP-ATU, :MCOD-OPERACAO, :MDATA-OPERACAO, :COD-SUBGRUPO-TRANS, :MSIT-REGISTRO, :MCOD-USUARIO, :MDATA-AVERBACAO:WDATA-AVERBACAO, :MDATA-ADMISSAO:WDATA-ADMISSAO, :MDATA-INCLUSAO:WDATA-INCLUSAO, :MDATA-NASCIMENTO:WDATA-NASCIMENTO, :MDATA-FATURA:WDATA-FATURA, :MDATA-REFERENCIA:WDATA-REFERENCIA, :MDATA-MOVIMENTO:WDATA-MOVIMENTO, :SDATA-MOVIMENTO:WDATA-MOVIMENTO1, :MCOD-EMPRESA:WCOD-EMPRESA, :V0APOL-RAMO, :V0APOL-MODALIDA END-EXEC. */

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
                _.Move(TMOVIMENTO.SDATA_MOVIMENTO, SDATA_MOVIMENTO);
                _.Move(TMOVIMENTO.WDATA_MOVIMENTO1, WDATA_MOVIMENTO1);
                _.Move(TMOVIMENTO.MCOD_EMPRESA, MCOD_EMPRESA);
                _.Move(TMOVIMENTO.WCOD_EMPRESA, WCOD_EMPRESA);
                _.Move(TMOVIMENTO.V0APOL_RAMO, V0APOL_RAMO);
                _.Move(TMOVIMENTO.V0APOL_MODALIDA, V0APOL_MODALIDA);
            }

        }

        [StopWatch]
        /*" M-120-000-FETCH-V1MOVIMENTO-DB-CLOSE-1 */
        public void M_120_000_FETCH_V1MOVIMENTO_DB_CLOSE_1()
        {
            /*" -698- EXEC SQL CLOSE TMOVIMENTO END-EXEC */

            TMOVIMENTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/

        [StopWatch]
        /*" M-150-000-SELECT-V1SEGURAVG-SECTION */
        private void M_150_000_SELECT_V1SEGURAVG_SECTION()
        {
            /*" -803- MOVE '150-000-SELECT-V1SEGURAVG' TO PARAGRAFO */
            _.Move("150-000-SELECT-V1SEGURAVG", WS_DADOS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -805- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -820- PERFORM M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1 */

            M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1();

            /*" -823- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -825- DISPLAY 'VG0040B - NAO EXISTE OCORRENCIA DE HISTORICO ' MNUM-CERTIFICADO ' ' MTIPO-SEGURADO */

                $"VG0040B - NAO EXISTE OCORRENCIA DE HISTORICO {MNUM_CERTIFICADO} {MTIPO_SEGURADO}"
                .Display();

                /*" -827- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -827- COMPUTE HOCORR-HISTORICO = SOCORR-HISTORICO + 1. */
            HOCORR_HISTORICO.Value = SOCORR_HISTORICO + 1;

        }

        [StopWatch]
        /*" M-150-000-SELECT-V1SEGURAVG-DB-SELECT-1 */
        public void M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1()
        {
            /*" -820- EXEC SQL SELECT OCORR_HISTORICO, NUM_ITEM, DATA_INIVIGENCIA + 1 YEAR - 1 DAY, DATA_ADMISSAO, SIT_REGISTRO INTO :SOCORR-HISTORICO, :SNUM-ITEM, :SDATA-TERVIGENCIA:WDATA-TERVIGENCIA, :SDATA-DTTERVIG:WDATA-DTTERVIG, :SSIT-REGISTRO FROM SEGUROS.V1SEGURAVG WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND TIPO_SEGURADO = :MTIPO-SEGURADO END-EXEC. */

            var m_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1 = new M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
            };

            var executed_1 = M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1.Execute(m_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SOCORR_HISTORICO, SOCORR_HISTORICO);
                _.Move(executed_1.SNUM_ITEM, SNUM_ITEM);
                _.Move(executed_1.SDATA_TERVIGENCIA, SDATA_TERVIGENCIA);
                _.Move(executed_1.WDATA_TERVIGENCIA, WDATA_TERVIGENCIA);
                _.Move(executed_1.SDATA_DTTERVIG, SDATA_DTTERVIG);
                _.Move(executed_1.WDATA_DTTERVIG, WDATA_DTTERVIG);
                _.Move(executed_1.SSIT_REGISTRO, SSIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/

        [StopWatch]
        /*" M-160-000-SELECT-V0MOVIMENTO-SECTION */
        private void M_160_000_SELECT_V0MOVIMENTO_SECTION()
        {
            /*" -868- MOVE '160-000-SELECT-V0MOVIMENTO' TO PARAGRAFO */
            _.Move("160-000-SELECT-V0MOVIMENTO", WS_DADOS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -870- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -872- MOVE 'N' TO WTEM-MOVIMENTO */
            _.Move("N", WS_DADOS_AUXILIARES.WTEM_MOVIMENTO);

            /*" -882- PERFORM M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1 */

            M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1();

            /*" -885- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -886- DISPLAY ' CERTIFICADO  = ' MNUM-CERTIFICADO */
                _.Display($" CERTIFICADO  = {MNUM_CERTIFICADO}");

                /*" -888- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -889- IF V0NUM-COUNT GREATER ZEROS */

            if (V0NUM_COUNT > 00)
            {

                /*" -890- MOVE 'S' TO WTEM-MOVIMENTO */
                _.Move("S", WS_DADOS_AUXILIARES.WTEM_MOVIMENTO);

                /*" -891- ELSE */
            }
            else
            {


                /*" -891- MOVE 'N' TO WTEM-MOVIMENTO. */
                _.Move("N", WS_DADOS_AUXILIARES.WTEM_MOVIMENTO);
            }


        }

        [StopWatch]
        /*" M-160-000-SELECT-V0MOVIMENTO-DB-SELECT-1 */
        public void M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1()
        {
            /*" -882- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :V0NUM-COUNT FROM SEGUROS.V0MOVIMENTO WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND COD_OPERACAO NOT BETWEEN 0500 AND 599 AND DATA_MOVIMENTO < :MDATA-MOVIMENTO AND DATA_INCLUSAO IS NULL END-EXEC. */

            var m_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1 = new M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                MDATA_MOVIMENTO = MDATA_MOVIMENTO.ToString(),
            };

            var executed_1 = M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1.Execute(m_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0NUM_COUNT, V0NUM_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_160_999_EXIT*/

        [StopWatch]
        /*" M-210-000-MONTA-V0COBERAPOL-SECTION */
        private void M_210_000_MONTA_V0COBERAPOL_SECTION()
        {
            /*" -905- MOVE '210-000-MONTA-V0COBERAPOL' TO PARAGRAFO. */
            _.Move("210-000-MONTA-V0COBERAPOL", WS_DADOS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -907- IF WAPOLICE-ATU NOT EQUAL WAPOLICE-ANT */

            if (WS_DADOS_AUXILIARES.WAPOLICE_ATU != WS_DADOS_AUXILIARES.WAPOLICE_ANT)
            {

                /*" -910- MOVE WAPOLICE-ATU TO WAPOLICE-ANT. */
                _.Move(WS_DADOS_AUXILIARES.WAPOLICE_ATU, WS_DADOS_AUXILIARES.WAPOLICE_ANT);
            }


            /*" -912- MOVE MNUM-APOLICE TO VGNUM-APOLICE */
            _.Move(MNUM_APOLICE, VGNUM_APOLICE);

            /*" -913- MOVE 0 TO VGNRENDOS */
            _.Move(0, VGNRENDOS);

            /*" -913- MOVE SNUM-ITEM TO VGNUM-ITEM. */
            _.Move(SNUM_ITEM, VGNUM_ITEM);

            /*" -0- FLUXCONTROL_PERFORM M_210_010_VERIFICA_PREMIO_VG */

            M_210_010_VERIFICA_PREMIO_VG();

        }

        [StopWatch]
        /*" M-210-010-VERIFICA-PREMIO-VG */
        private void M_210_010_VERIFICA_PREMIO_VG(bool isPerform = false)
        {
            /*" -920- MOVE ZEROS TO VGPCT-COBERTURA1. */
            _.Move(0, VGPCT_COBERTURA1);

            /*" -926- IF MIMP-MORNATU-ATU NOT EQUAL ZEROS OR (MIMP-MORNATU-ATU EQUAL ZEROS AND V0APOL-RAMO EQUAL V1PAR-RAMO-VG AND V0APOL-MODALIDA EQUAL 2 AND MPRM-VG-ATU GREATER ZEROS) */

            if (MIMP_MORNATU_ATU != 00 || (MIMP_MORNATU_ATU == 00 && V0APOL_RAMO == V1PAR_RAMO_VG && V0APOL_MODALIDA == 2 && MPRM_VG_ATU > 00))
            {

                /*" -927- IF V0APOL-RAMO EQUAL V1PAR-RAMO-PST */

                if (V0APOL_RAMO == V1PAR_RAMO_PST)
                {

                    /*" -928- MOVE V1PAR-RAMO-PST TO VGRAMOFR */
                    _.Move(V1PAR_RAMO_PST, VGRAMOFR);

                    /*" -929- MOVE 11 TO VGCOD-COBERTURA */
                    _.Move(11, VGCOD_COBERTURA);

                    /*" -931- END-IF */
                }


                /*" -932- IF V0APOL-RAMO EQUAL V1PAR-RAMO-VG */

                if (V0APOL_RAMO == V1PAR_RAMO_VG)
                {

                    /*" -933- MOVE V1PAR-RAMO-VG TO VGRAMOFR */
                    _.Move(V1PAR_RAMO_VG, VGRAMOFR);

                    /*" -934- MOVE 11 TO VGCOD-COBERTURA */
                    _.Move(11, VGCOD_COBERTURA);

                    /*" -936- END-IF */
                }


                /*" -937- IF V0APOL-RAMO EQUAL 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -938- MOVE V1PAR-RAMO-VG TO VGRAMOFR */
                    _.Move(V1PAR_RAMO_VG, VGRAMOFR);

                    /*" -939- MOVE 11 TO VGCOD-COBERTURA */
                    _.Move(11, VGCOD_COBERTURA);

                    /*" -942- END-IF */
                }


                /*" -944- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -948- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-MORNATU-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_MORNATU_ATU / DVLCRUZAD_IMP;

                /*" -952- COMPUTE VGPRM-TARIFARIO-IX ROUNDED = MPRM-VG-ATU / DVLCRUZAD-PRM */
                VGPRM_TARIFARIO_IX.Value = MPRM_VG_ATU / DVLCRUZAD_PRM;

                /*" -955- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -958- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -961- COMPUTE WPRMTOT = MPRM-VG-ATU + MPRM-AP-ATU */
                WS_DADOS_AUXILIARES.WPRMTOT.Value = MPRM_VG_ATU + MPRM_AP_ATU;

                /*" -962- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -965- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -966- IF MNUM-APOLICE EQUAL 109300000635 */

                if (MNUM_APOLICE == 109300000635)
                {

                    /*" -973- PERFORM M_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1 */

                    M_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1();

                    /*" -976- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -977- DISPLAY 'ERRO ACESSO COBERPROPVA ' MNUM-CERTIFICADO */
                        _.Display($"ERRO ACESSO COBERPROPVA {MNUM_CERTIFICADO}");

                        /*" -978- GO TO 999-999-ROT-ERRO */

                        M_999_999_ROT_ERRO(); //GOTO
                        return;

                        /*" -979- END-IF */
                    }


                    /*" -980- ELSE */
                }
                else
                {


                    /*" -981- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                    _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                    /*" -983- END-IF */
                }


                /*" -985- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -989- COMPUTE VGPCT-COBERTURA1 ROUNDED = MPRM-VG-ATU * 100 / WPRMTOT */
                VGPCT_COBERTURA1.Value = MPRM_VG_ATU * 100 / WS_DADOS_AUXILIARES.WPRMTOT;

                /*" -991- MOVE VGPCT-COBERTURA1 TO VGPCT-COBERTURA */
                _.Move(VGPCT_COBERTURA1, VGPCT_COBERTURA);

                /*" -991- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


        }

        [StopWatch]
        /*" M-210-010-VERIFICA-PREMIO-VG-DB-SELECT-1 */
        public void M_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1()
        {
            /*" -973- EXEC SQL SELECT MAX(DTTERVIG) INTO :VGDATA-TERVIGENCIA FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :MNUM-CERTIFICADO END-EXEC */

            var m_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1_Query1 = new M_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1_Query1.Execute(m_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGDATA_TERVIGENCIA, VGDATA_TERVIGENCIA);
            }


        }

        [StopWatch]
        /*" M-210-020-VERIFICA-PREMIO-AP */
        private void M_210_020_VERIFICA_PREMIO_AP(bool isPerform = false)
        {
            /*" -998- MOVE ZEROS TO VGPCT-COBERTURA2. */
            _.Move(0, VGPCT_COBERTURA2);

            /*" -1000- IF MIMP-MORACID-ATU NOT EQUAL ZEROS */

            if (MIMP_MORACID_ATU != 00)
            {

                /*" -1004- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -1005- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1007- MOVE 01 TO VGCOD-COBERTURA */
                _.Move(01, VGCOD_COBERTURA);

                /*" -1011- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-MORACID-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_MORACID_ATU / DVLCRUZAD_IMP;

                /*" -1015- COMPUTE VGPRM-TARIFARIO-IX ROUNDED = MPRM-AP-ATU / DVLCRUZAD-PRM */
                VGPRM_TARIFARIO_IX.Value = MPRM_AP_ATU / DVLCRUZAD_PRM;

                /*" -1018- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1021- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1024- COMPUTE WPRMTOT = MPRM-VG-ATU + MPRM-AP-ATU */
                WS_DADOS_AUXILIARES.WPRMTOT.Value = MPRM_VG_ATU + MPRM_AP_ATU;

                /*" -1025- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1027- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1029- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                /*" -1031- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1035- COMPUTE VGPCT-COBERTURA2 ROUNDED = MPRM-AP-ATU * 100 / WPRMTOT */
                VGPCT_COBERTURA2.Value = MPRM_AP_ATU * 100 / WS_DADOS_AUXILIARES.WPRMTOT;

                /*" -1036- IF VGPCT-COBERTURA2 EQUAL 0 */

                if (VGPCT_COBERTURA2 == 0)
                {

                    /*" -1038- IF V0APOL-RAMO EQUAL V1PAR-RAMO-VG AND V0APOL-MODALIDA EQUAL 2 */

                    if (V0APOL_RAMO == V1PAR_RAMO_VG && V0APOL_MODALIDA == 2)
                    {

                        /*" -1040- COMPUTE VGPCT-COBERTURA2 = 100 - VGPCT-COBERTURA1 */
                        VGPCT_COBERTURA2.Value = 100 - VGPCT_COBERTURA1;

                        /*" -1042- MOVE VGPCT-COBERTURA2 TO VGPCT-COBERTURA */
                        _.Move(VGPCT_COBERTURA2, VGPCT_COBERTURA);

                        /*" -1043- PERFORM 300-000-INSERE-V0COBERAPOL */

                        M_300_000_INSERE_V0COBERAPOL_SECTION();

                        /*" -1044- ELSE */
                    }
                    else
                    {


                        /*" -1046- MOVE VGPCT-COBERTURA2 TO VGPCT-COBERTURA */
                        _.Move(VGPCT_COBERTURA2, VGPCT_COBERTURA);

                        /*" -1047- ELSE */
                    }

                }
                else
                {


                    /*" -1049- COMPUTE VGPCT-COBERTURA2 = 100 - VGPCT-COBERTURA1 */
                    VGPCT_COBERTURA2.Value = 100 - VGPCT_COBERTURA1;

                    /*" -1051- MOVE VGPCT-COBERTURA2 TO VGPCT-COBERTURA */
                    _.Move(VGPCT_COBERTURA2, VGPCT_COBERTURA);

                    /*" -1051- PERFORM 300-000-INSERE-V0COBERAPOL. */

                    M_300_000_INSERE_V0COBERAPOL_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-210-030-VERIFICA-INVPERM */
        private void M_210_030_VERIFICA_INVPERM(bool isPerform = false)
        {
            /*" -1057- IF MIMP-INVPERM-ATU NOT EQUAL ZEROS */

            if (MIMP_INVPERM_ATU != 00)
            {

                /*" -1061- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -1062- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1064- MOVE 02 TO VGCOD-COBERTURA */
                _.Move(02, VGCOD_COBERTURA);

                /*" -1068- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-INVPERM-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_INVPERM_ATU / DVLCRUZAD_IMP;

                /*" -1070- MOVE 0 TO VGPRM-TARIFARIO-IX */
                _.Move(0, VGPRM_TARIFARIO_IX);

                /*" -1073- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1077- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1078- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1080- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1082- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                /*" -1084- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1085- MOVE 0 TO VGPCT-COBERTURA */
                _.Move(0, VGPCT_COBERTURA);

                /*" -1085- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


        }

        [StopWatch]
        /*" M-210-040-VERIFICA-AMDS */
        private void M_210_040_VERIFICA_AMDS(bool isPerform = false)
        {
            /*" -1091- IF MIMP-AMDS-ATU NOT EQUAL ZEROS */

            if (MIMP_AMDS_ATU != 00)
            {

                /*" -1095- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -1096- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1098- MOVE 03 TO VGCOD-COBERTURA */
                _.Move(03, VGCOD_COBERTURA);

                /*" -1102- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-AMDS-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_AMDS_ATU / DVLCRUZAD_IMP;

                /*" -1104- MOVE 0 TO VGPRM-TARIFARIO-IX */
                _.Move(0, VGPRM_TARIFARIO_IX);

                /*" -1107- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1111- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1112- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1114- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1116- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                /*" -1118- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1119- MOVE 0 TO VGPCT-COBERTURA */
                _.Move(0, VGPCT_COBERTURA);

                /*" -1119- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


        }

        [StopWatch]
        /*" M-210-050-VERIFICA-DH */
        private void M_210_050_VERIFICA_DH(bool isPerform = false)
        {
            /*" -1125- IF MIMP-DH-ATU NOT EQUAL ZEROS */

            if (MIMP_DH_ATU != 00)
            {

                /*" -1129- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -1130- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1132- MOVE 04 TO VGCOD-COBERTURA */
                _.Move(04, VGCOD_COBERTURA);

                /*" -1136- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-DH-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_DH_ATU / DVLCRUZAD_IMP;

                /*" -1138- MOVE 0 TO VGPRM-TARIFARIO-IX */
                _.Move(0, VGPRM_TARIFARIO_IX);

                /*" -1141- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1145- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1146- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1148- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1150- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                /*" -1152- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1153- MOVE 0 TO VGPCT-COBERTURA */
                _.Move(0, VGPCT_COBERTURA);

                /*" -1153- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


        }

        [StopWatch]
        /*" M-210-060-VERIFICA-DIT */
        private void M_210_060_VERIFICA_DIT(bool isPerform = false)
        {
            /*" -1159- IF MIMP-DIT-ATU NOT EQUAL ZEROS */

            if (MIMP_DIT_ATU != 00)
            {

                /*" -1163- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -1164- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1166- MOVE 05 TO VGCOD-COBERTURA */
                _.Move(05, VGCOD_COBERTURA);

                /*" -1170- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-DIT-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_DIT_ATU / DVLCRUZAD_IMP;

                /*" -1172- MOVE 0 TO VGPRM-TARIFARIO-IX */
                _.Move(0, VGPRM_TARIFARIO_IX);

                /*" -1175- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1179- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1180- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1182- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1184- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                /*" -1186- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1187- MOVE 0 TO VGPCT-COBERTURA */
                _.Move(0, VGPCT_COBERTURA);

                /*" -1187- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_210_999_EXIT*/

        [StopWatch]
        /*" M-300-000-INSERE-V0COBERAPOL-SECTION */
        private void M_300_000_INSERE_V0COBERAPOL_SECTION()
        {
            /*" -1291- MOVE '300-000-INSERE-V0COBERAPOL' TO PARAGRAFO */
            _.Move("300-000-INSERE-V0COBERAPOL", WS_DADOS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1293- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1294- MOVE -1 TO WCOD-EMPRESA. */
            _.Move(-1, WCOD_EMPRESA);

            /*" -1296- MOVE -1 TO VGSITUACAOI. */
            _.Move(-1, VGSITUACAOI);

            /*" -1317- PERFORM M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1 */

            M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1();

            /*" -1320- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1323- DISPLAY 'VG0040B - PROBLEMAS NA INCLUSAO V0COBERAPOL  ' VGNUM-APOLICE ' ' VGNRENDOS ' ' VGNUM-ITEM */

                $"VG0040B - PROBLEMAS NA INCLUSAO V0COBERAPOL  {VGNUM_APOLICE} {VGNRENDOS} {VGNUM_ITEM}"
                .Display();

                /*" -1323- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-300-000-INSERE-V0COBERAPOL-DB-INSERT-1 */
        public void M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1()
        {
            /*" -1317- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:VGNUM-APOLICE, :VGNRENDOS, :VGNUM-ITEM, :HOCORR-HISTORICO, :VGRAMOFR, :VGMODALIFR, :VGCOD-COBERTURA, :VGIMP-SEGURADA-IX, :VGPRM-TARIFARIO-IX, :VGIMP-SEGURADA-VAR, :PRM-TARIFARIO-VAR, :VGPCT-COBERTURA, :VGFATOR-MULTIPLICA, :VGDATA-INIVIGENCIA, :VGDATA-TERVIGENCIA, :MCOD-EMPRESA:WCOD-EMPRESA, CURRENT TIMESTAMP, :VGSITUACAO:VGSITUACAOI) END-EXEC. */

            var m_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1 = new M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1()
            {
                VGNUM_APOLICE = VGNUM_APOLICE.ToString(),
                VGNRENDOS = VGNRENDOS.ToString(),
                VGNUM_ITEM = VGNUM_ITEM.ToString(),
                HOCORR_HISTORICO = HOCORR_HISTORICO.ToString(),
                VGRAMOFR = VGRAMOFR.ToString(),
                VGMODALIFR = VGMODALIFR.ToString(),
                VGCOD_COBERTURA = VGCOD_COBERTURA.ToString(),
                VGIMP_SEGURADA_IX = VGIMP_SEGURADA_IX.ToString(),
                VGPRM_TARIFARIO_IX = VGPRM_TARIFARIO_IX.ToString(),
                VGIMP_SEGURADA_VAR = VGIMP_SEGURADA_VAR.ToString(),
                PRM_TARIFARIO_VAR = PRM_TARIFARIO_VAR.ToString(),
                VGPCT_COBERTURA = VGPCT_COBERTURA.ToString(),
                VGFATOR_MULTIPLICA = VGFATOR_MULTIPLICA.ToString(),
                VGDATA_INIVIGENCIA = VGDATA_INIVIGENCIA.ToString(),
                VGDATA_TERVIGENCIA = VGDATA_TERVIGENCIA.ToString(),
                MCOD_EMPRESA = MCOD_EMPRESA.ToString(),
                WCOD_EMPRESA = WCOD_EMPRESA.ToString(),
                VGSITUACAO = VGSITUACAO.ToString(),
                VGSITUACAOI = VGSITUACAOI.ToString(),
            };

            M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1.Execute(m_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_999_EXIT*/

        [StopWatch]
        /*" M-330-000-INSERE-V0HISTSEGVG-SECTION */
        private void M_330_000_INSERE_V0HISTSEGVG_SECTION()
        {
            /*" -1341- MOVE '330-000-INCLUI-V0HISTSEGVG' TO PARAGRAFO */
            _.Move("330-000-INCLUI-V0HISTSEGVG", WS_DADOS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1343- MOVE '330' TO WNR-EXEC-SQL. */
            _.Move("330", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1344- ACCEPT WHORA-OPERACAO-1 FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_DADOS_AUXILIARES.WHORA_OPERACAO_1);

            /*" -1345- MOVE WHORA-OPERACAO-2 TO WHORA-OPERACAO-R */
            _.Move(WS_DADOS_AUXILIARES.WHORA_PER_X.WHORA_OPERACAO_2, WS_DADOS_AUXILIARES.WHORA_OPERACAO_R);

            /*" -1346- MOVE WHORA-HORA-W TO WHORA-HORA */
            _.Move(WS_DADOS_AUXILIARES.WHORA_OPERACAO.WHORA_HORA_W, WS_DADOS_AUXILIARES.WHORA_OPERACAO_WORK.WHORA_HORA);

            /*" -1347- MOVE WHORA-MINU-W TO WHORA-MINU */
            _.Move(WS_DADOS_AUXILIARES.WHORA_OPERACAO.WHORA_MINU_W, WS_DADOS_AUXILIARES.WHORA_OPERACAO_WORK.WHORA_MINU);

            /*" -1348- MOVE WHORA-SEGU-W TO WHORA-SEGU */
            _.Move(WS_DADOS_AUXILIARES.WHORA_OPERACAO.WHORA_SEGU_W, WS_DADOS_AUXILIARES.WHORA_OPERACAO_WORK.WHORA_SEGU);

            /*" -1349- MOVE WHORA-OPERACAO-WORK-R TO HHORA-OPERACAO */
            _.Move(WS_DADOS_AUXILIARES.WHORA_OPERACAO_WORK_R, HHORA_OPERACAO);

            /*" -1352- MOVE 0 TO HCOD-SUBGRUP-TRANS. */
            _.Move(0, HCOD_SUBGRUP_TRANS);

            /*" -1354- MOVE -1 TO WCOD-EMPRESA. */
            _.Move(-1, WCOD_EMPRESA);

            /*" -1371- PERFORM M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1 */

            M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1();

            /*" -1374- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1377- DISPLAY 'VG0040B - PROBLEMAS NA INCLUSAO V0HISTSEGVG ' MNUM-APOLICE ' ' MCOD-SUBGRUPO ' ' SNUM-ITEM */

                $"VG0040B - PROBLEMAS NA INCLUSAO V0HISTSEGVG {MNUM_APOLICE} {MCOD_SUBGRUPO} {SNUM_ITEM}"
                .Display();

                /*" -1379- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1379- ADD 1 TO AC-GRAVA. */
            WS_DADOS_AUXILIARES.AC_GRAVA.Value = WS_DADOS_AUXILIARES.AC_GRAVA + 1;

        }

        [StopWatch]
        /*" M-330-000-INSERE-V0HISTSEGVG-DB-INSERT-1 */
        public void M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1()
        {
            /*" -1371- EXEC SQL INSERT INTO SEGUROS.V0HISTSEGVG VALUES (:MNUM-APOLICE, :MCOD-SUBGRUPO, :SNUM-ITEM, :MCOD-OPERACAO, :V1SISTEMA-DTMOVABE, :HHORA-OPERACAO, :MDATA-MOVIMENTO:WDATA-MOVIMENTO, :HOCORR-HISTORICO, :HCOD-SUBGRUP-TRANS, :MDATA-REFERENCIA:WDATA-REFERENCIA, :MCOD-USUARIO, :MCOD-EMPRESA:WCOD-EMPRESA, :V1EN-COD-MOEDA-IMP:WCOD-MOEDA, :V1EN-COD-MOEDA-PRM:WCOD-MOEDA) END-EXEC. */

            var m_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1 = new M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1()
            {
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
                MCOD_SUBGRUPO = MCOD_SUBGRUPO.ToString(),
                SNUM_ITEM = SNUM_ITEM.ToString(),
                MCOD_OPERACAO = MCOD_OPERACAO.ToString(),
                V1SISTEMA_DTMOVABE = V1SISTEMA_DTMOVABE.ToString(),
                HHORA_OPERACAO = HHORA_OPERACAO.ToString(),
                MDATA_MOVIMENTO = MDATA_MOVIMENTO.ToString(),
                WDATA_MOVIMENTO = WDATA_MOVIMENTO.ToString(),
                HOCORR_HISTORICO = HOCORR_HISTORICO.ToString(),
                HCOD_SUBGRUP_TRANS = HCOD_SUBGRUP_TRANS.ToString(),
                MDATA_REFERENCIA = MDATA_REFERENCIA.ToString(),
                WDATA_REFERENCIA = WDATA_REFERENCIA.ToString(),
                MCOD_USUARIO = MCOD_USUARIO.ToString(),
                MCOD_EMPRESA = MCOD_EMPRESA.ToString(),
                WCOD_EMPRESA = WCOD_EMPRESA.ToString(),
                V1EN_COD_MOEDA_IMP = V1EN_COD_MOEDA_IMP.ToString(),
                WCOD_MOEDA = WCOD_MOEDA.ToString(),
                V1EN_COD_MOEDA_PRM = V1EN_COD_MOEDA_PRM.ToString(),
            };

            M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1.Execute(m_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_330_999_EXIT*/

        [StopWatch]
        /*" M-350-000-DETERMINA-DTTERVIG-SECTION */
        private void M_350_000_DETERMINA_DTTERVIG_SECTION()
        {
            /*" -1400- MOVE '350-000-DETERMINA-DTTERVIG' TO PARAGRAFO */
            _.Move("350-000-DETERMINA-DTTERVIG", WS_DADOS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1402- MOVE '350' TO WNR-EXEC-SQL. */
            _.Move("350", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1403- IF WDATA-DTTERVIG EQUAL 0 */

            if (WDATA_DTTERVIG == 0)
            {

                /*" -1405- GO TO 350-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_350_999_EXIT*/ //GOTO
                return;
            }


            /*" -1406- IF SDATA-TERVIGENCIA LESS V1SISTEMA-DTMOVABE */

            if (SDATA_TERVIGENCIA < V1SISTEMA_DTMOVABE)
            {

                /*" -1407- MOVE SDATA-TERVIGENCIA TO WS-W01DTTRAB */
                _.Move(SDATA_TERVIGENCIA, WS_DADOS_AUXILIARES.WS_W01DTTRAB);

                /*" -1408- ADD 1 TO WS-W01AATRAB */
                WS_DADOS_AUXILIARES.WS_W01DTTRAB.WS_W01AATRAB.Value = WS_DADOS_AUXILIARES.WS_W01DTTRAB.WS_W01AATRAB + 1;

                /*" -1409- IF WS-W01MMTRAB EQUAL 2 */

                if (WS_DADOS_AUXILIARES.WS_W01DTTRAB.WS_W01MMTRAB == 2)
                {

                    /*" -1410- IF WS-W01DDTRAB GREATER 27 */

                    if (WS_DADOS_AUXILIARES.WS_W01DTTRAB.WS_W01DDTRAB > 27)
                    {

                        /*" -1411- COMPUTE WANO-BISSEXTO = WS-W01AATRAB / 4 */
                        WS_DADOS_AUXILIARES.WANO_BISSEXTO.Value = WS_DADOS_AUXILIARES.WS_W01DTTRAB.WS_W01AATRAB / 4;

                        /*" -1412- COMPUTE WANO-BISSEXTO = WANO-BISSEXTO * 4 */
                        WS_DADOS_AUXILIARES.WANO_BISSEXTO.Value = WS_DADOS_AUXILIARES.WANO_BISSEXTO * 4;

                        /*" -1413- IF WANO-BISSEXTO EQUAL WS-W01AATRAB */

                        if (WS_DADOS_AUXILIARES.WANO_BISSEXTO == WS_DADOS_AUXILIARES.WS_W01DTTRAB.WS_W01AATRAB)
                        {

                            /*" -1414- MOVE 29 TO WS-W01DDTRAB */
                            _.Move(29, WS_DADOS_AUXILIARES.WS_W01DTTRAB.WS_W01DDTRAB);

                            /*" -1415- ELSE */
                        }
                        else
                        {


                            /*" -1416- MOVE 28 TO WS-W01DDTRAB */
                            _.Move(28, WS_DADOS_AUXILIARES.WS_W01DTTRAB.WS_W01DDTRAB);

                            /*" -1417- END-IF */
                        }


                        /*" -1418- END-IF */
                    }


                    /*" -1419- END-IF */
                }


                /*" -1420- MOVE WS-W01DTTRAB TO SDATA-DTTERVIG */
                _.Move(WS_DADOS_AUXILIARES.WS_W01DTTRAB, SDATA_DTTERVIG);

                /*" -1421- ELSE */
            }
            else
            {


                /*" -1426- MOVE SDATA-TERVIGENCIA TO SDATA-DTTERVIG. */
                _.Move(SDATA_TERVIGENCIA, SDATA_DTTERVIG);
            }


            /*" -1427- IF SDATA-DTTERVIG LESS V1SISTEMA-DTMOVABE */

            if (SDATA_DTTERVIG < V1SISTEMA_DTMOVABE)
            {

                /*" -1428- MOVE SDATA-DTTERVIG TO SDATA-TERVIGENCIA */
                _.Move(SDATA_DTTERVIG, SDATA_TERVIGENCIA);

                /*" -1429- GO TO 350-000-DETERMINA-DTTERVIG. */
                new Task(() => M_350_000_DETERMINA_DTTERVIG_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_350_999_EXIT*/

        [StopWatch]
        /*" M-360-000-UPDATE-V0SEGURAVG-SECTION */
        private void M_360_000_UPDATE_V0SEGURAVG_SECTION()
        {
            /*" -1445- MOVE '360-000-UPDATE-V0SEGURAVG' TO PARAGRAFO */
            _.Move("360-000-UPDATE-V0SEGURAVG", WS_DADOS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1447- MOVE '360' TO WNR-EXEC-SQL. */
            _.Move("360", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1456- PERFORM M_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1 */

            M_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1();

            /*" -1464- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1466- DISPLAY 'VG0040B - PROBLEMAS ALTERACAO V0SEGURAVG  ' MNUM-CERTIFICADO ' ' MTIPO-SEGURADO */

                $"VG0040B - PROBLEMAS ALTERACAO V0SEGURAVG  {MNUM_CERTIFICADO} {MTIPO_SEGURADO}"
                .Display();

                /*" -1466- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-360-000-UPDATE-V0SEGURAVG-DB-UPDATE-1 */
        public void M_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1()
        {
            /*" -1456- EXEC SQL UPDATE SEGUROS.V0SEGURAVG SET SIT_REGISTRO = '0' , DATA_ADMISSAO = :SDATA-DTTERVIG, OCORR_HISTORICO = :HOCORR-HISTORICO, COD_PROFISSAO = 9999 WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND TIPO_SEGURADO = :MTIPO-SEGURADO AND SIT_REGISTRO IN ( '2' , '9' ) END-EXEC. */

            var m_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1 = new M_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1()
            {
                HOCORR_HISTORICO = HOCORR_HISTORICO.ToString(),
                SDATA_DTTERVIG = SDATA_DTTERVIG.ToString(),
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
            };

            M_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1.Execute(m_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_360_999_EXIT*/

        [StopWatch]
        /*" M-390-000-UPDATE-V0MOVIMENTO-SECTION */
        private void M_390_000_UPDATE_V0MOVIMENTO_SECTION()
        {
            /*" -1483- MOVE '390-000-UPDATE-V0MOVIMENTO' TO PARAGRAFO */
            _.Move("390-000-UPDATE-V0MOVIMENTO", WS_DADOS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1485- MOVE '390' TO WNR-EXEC-SQL. */
            _.Move("390", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1494- PERFORM M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1 */

            M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1();

            /*" -1497- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1499- DISPLAY 'VG0040B - NAO EXISTE MOVIMENTO PARA ' MCOD-FONTE ' ' MNUM-PROPOSTA */

                $"VG0040B - NAO EXISTE MOVIMENTO PARA {MCOD_FONTE} {MNUM_PROPOSTA}"
                .Display();

                /*" -1500- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1502- END-IF */
            }


            /*" -1505- IF NOT ( MNUM-APOLICE EQUAL 109300000559 OR 3009300000559 OR 3009300001559 ) */

            if (!(MNUM_APOLICE.In("109300000559", "3009300000559", "3009300001559")))
            {

                /*" -1506- GO TO 390-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_390_999_EXIT*/ //GOTO
                return;

                /*" -1508- END-IF */
            }


            /*" -1510- MOVE '391' TO WNR-EXEC-SQL. */
            _.Move("391", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1518- PERFORM M_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_1 */

            M_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_1();

            /*" -1520- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1521- GO TO 390-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_390_999_EXIT*/ //GOTO
                return;

                /*" -1522- ELSE */
            }
            else
            {


                /*" -1523- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1524- CONTINUE */

                    /*" -1525- ELSE */
                }
                else
                {


                    /*" -1526- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1527- END-IF */
                }


                /*" -1531- END-IF */
            }


            /*" -1533- IF ( MNUM-APOLICE = 109300000559 OR 3009300000559 ) AND MDATA-MOVIMENTO < '2004-06-01' */

            if ((MNUM_APOLICE.In("109300000559", "3009300000559")) && MDATA_MOVIMENTO < "2004-06-01")
            {

                /*" -1534- MOVE '392' TO WNR-EXEC-SQL */
                _.Move("392", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

                /*" -1577- PERFORM M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1 */

                M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1();

                /*" -1579- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1581- DISPLAY 'VG0040B - ERRO INSERT RELATORIOS    ' MCOD-FONTE ' ' MNUM-PROPOSTA ' ' MNUM-CERTIFICADO */

                    $"VG0040B - ERRO INSERT RELATORIOS    {MCOD_FONTE} {MNUM_PROPOSTA} {MNUM_CERTIFICADO}"
                    .Display();

                    /*" -1587- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -1589- IF MNUM-APOLICE = 109300000680 AND MDATA-MOVIMENTO < '2004-07-10' */

            if (MNUM_APOLICE == 109300000680 && MDATA_MOVIMENTO < "2004-07-10")
            {

                /*" -1590- MOVE '393' TO WNR-EXEC-SQL */
                _.Move("393", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

                /*" -1633- PERFORM M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2 */

                M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2();

                /*" -1635- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1637- DISPLAY 'VG0040B - ERRO INSERT RELATORIOS    ' MCOD-FONTE ' ' MNUM-PROPOSTA ' ' MNUM-CERTIFICADO */

                    $"VG0040B - ERRO INSERT RELATORIOS    {MCOD_FONTE} {MNUM_PROPOSTA} {MNUM_CERTIFICADO}"
                    .Display();

                    /*" -1638- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-390-000-UPDATE-V0MOVIMENTO-DB-UPDATE-1 */
        public void M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1()
        {
            /*" -1494- EXEC SQL UPDATE SEGUROS.V0MOVIMENTO SET DATA_INCLUSAO = :V1SISTEMA-DTMOVABE, DATA_REFERENCIA = :MDATA-REFERENCIA WHERE COD_FONTE = :MCOD-FONTE AND NUM_PROPOSTA = :MNUM-PROPOSTA AND TIPO_SEGURADO = :MTIPO-SEGURADO END-EXEC. */

            var m_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1 = new M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1()
            {
                V1SISTEMA_DTMOVABE = V1SISTEMA_DTMOVABE.ToString(),
                MDATA_REFERENCIA = MDATA_REFERENCIA.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
                MNUM_PROPOSTA = MNUM_PROPOSTA.ToString(),
                MCOD_FONTE = MCOD_FONTE.ToString(),
            };

            M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1.Execute(m_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-390-000-UPDATE-V0MOVIMENTO-DB-SELECT-1 */
        public void M_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_1()
        {
            /*" -1518- EXEC SQL SELECT NUM_APOLICE INTO :V0RELA-NUM-APOLICE FROM SEGUROS.V0RELATORIOS WHERE CODRELAT IN ( 'VP0198B' , 'VP0199B' ) AND NRCERTIF = :MNUM-CERTIFICADO END-EXEC. */

            var m_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_1_Query1 = new M_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_1_Query1.Execute(m_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_NUM_APOLICE, V0RELA_NUM_APOLICE);
            }


        }

        [StopWatch]
        /*" M-390-000-UPDATE-V0MOVIMENTO-DB-INSERT-1 */
        public void M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1()
        {
            /*" -1577- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VG0040B' , :V1SISTEMA-DTMOVABE, 'VP' , 'VP0198B' , 0, 0, CURRENT DATE, CURRENT DATE, CURRENT DATE, 0, 0, 0, 0, 0, 0, 0, 0, :MNUM-APOLICE, 0, 0, :MNUM-CERTIFICADO, 0, :MCOD-SUBGRUPO, :MCOD-OPERACAO, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , ' ' , ' ' , ' ' , NULL, 0, NULL, CURRENT TIMESTAMP) END-EXEC */

            var m_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1_Insert1 = new M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1_Insert1()
            {
                V1SISTEMA_DTMOVABE = V1SISTEMA_DTMOVABE.ToString(),
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                MCOD_SUBGRUPO = MCOD_SUBGRUPO.ToString(),
                MCOD_OPERACAO = MCOD_OPERACAO.ToString(),
            };

            M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1_Insert1.Execute(m_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_390_999_EXIT*/

        [StopWatch]
        /*" M-390-000-UPDATE-V0MOVIMENTO-DB-INSERT-2 */
        public void M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2()
        {
            /*" -1633- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VG0040B' , :V1SISTEMA-DTMOVABE, 'VP' , 'VP0199B' , 0, 0, CURRENT DATE, CURRENT DATE, CURRENT DATE, 0, 0, 0, 0, 0, 0, 0, 0, :MNUM-APOLICE, 0, 0, :MNUM-CERTIFICADO, 0, :MCOD-SUBGRUPO, :MCOD-OPERACAO, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , ' ' , ' ' , ' ' , NULL, 0, NULL, CURRENT TIMESTAMP) END-EXEC */

            var m_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2_Insert1 = new M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2_Insert1()
            {
                V1SISTEMA_DTMOVABE = V1SISTEMA_DTMOVABE.ToString(),
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                MCOD_SUBGRUPO = MCOD_SUBGRUPO.ToString(),
                MCOD_OPERACAO = MCOD_OPERACAO.ToString(),
            };

            M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2_Insert1.Execute(m_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" M-420-000-UPDATE-V0PROPOSTAVA-SECTION */
        private void M_420_000_UPDATE_V0PROPOSTAVA_SECTION()
        {
            /*" -1656- MOVE '420-000-UPDATE-V0PROPOSTAVA' TO PARAGRAFO */
            _.Move("420-000-UPDATE-V0PROPOSTAVA", WS_DADOS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1658- MOVE '420' TO WNR-EXEC-SQL. */
            _.Move("420", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1669- PERFORM M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1 */

            M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1();

            /*" -1672- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1673- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1675- DISPLAY 'VG0040B - ERRO UPDATE PROPOSTAVA    ' MNUM-CERTIFICADO */
                    _.Display($"VG0040B - ERRO UPDATE PROPOSTAVA    {MNUM_CERTIFICADO}");

                    /*" -1676- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1677- ELSE */
                }
                else
                {


                    /*" -1677- PERFORM 430-000-MIGRACAO-VIDAZUL. */

                    M_430_000_MIGRACAO_VIDAZUL_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-420-000-UPDATE-V0PROPOSTAVA-DB-UPDATE-1 */
        public void M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1()
        {
            /*" -1669- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '3' , NRPRIPARATZ = 0, QTDPARATZ = 0, CODOPER = :MCOD-OPERACAO, DTMOVTO = :MDATA-OPERACAO, CODUSU = :MCOD-USUARIO, NRPROPOS = :MNUM-PROPOSTA, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :MNUM-CERTIFICADO END-EXEC. */

            var m_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1 = new M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1()
            {
                MDATA_OPERACAO = MDATA_OPERACAO.ToString(),
                MCOD_OPERACAO = MCOD_OPERACAO.ToString(),
                MNUM_PROPOSTA = MNUM_PROPOSTA.ToString(),
                MCOD_USUARIO = MCOD_USUARIO.ToString(),
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1.Execute(m_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_420_999_EXIT*/

        [StopWatch]
        /*" M-430-000-MIGRACAO-VIDAZUL-SECTION */
        private void M_430_000_MIGRACAO_VIDAZUL_SECTION()
        {
            /*" -1694- MOVE '430-000-MIGRACAO-VIDAZUL   ' TO PARAGRAFO */
            _.Move("430-000-MIGRACAO-VIDAZUL   ", WS_DADOS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1695- IF MNUM-APOLICE = 97010000889 */

            if (MNUM_APOLICE == 97010000889)
            {

                /*" -1703- IF MCOD-SUBGRUPO = (1 OR 1948 OR 1949 OR 1950 OR 1951 OR 2910) NEXT SENTENCE */

                if (MCOD_SUBGRUPO.In("1", "1948", "1949", "1950", "1951", "2910"))
                {

                    /*" -1704- ELSE */
                }
                else
                {


                    /*" -1705- GO TO 430-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_430_999_EXIT*/ //GOTO
                    return;

                    /*" -1706- ELSE */
                }

            }
            else
            {


                /*" -1708- GO TO 430-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_430_999_EXIT*/ //GOTO
                return;
            }


            /*" -1710- MOVE '430' TO WNR-EXEC-SQL. */
            _.Move("430", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1718- PERFORM M_430_000_MIGRACAO_VIDAZUL_DB_DECLARE_1 */

            M_430_000_MIGRACAO_VIDAZUL_DB_DECLARE_1();

            /*" -1720- PERFORM M_430_000_MIGRACAO_VIDAZUL_DB_OPEN_1 */

            M_430_000_MIGRACAO_VIDAZUL_DB_OPEN_1();

            /*" -1723- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1725- DISPLAY 'VG0040B - ERRO OPEN CDEBTO          ' MNUM-CERTIFICADO */
                _.Display($"VG0040B - ERRO OPEN CDEBTO          {MNUM_CERTIFICADO}");

                /*" -1727- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1729- MOVE '431' TO WNR-EXEC-SQL. */
            _.Move("431", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1729- PERFORM M_430_000_MIGRACAO_VIDAZUL_DB_FETCH_1 */

            M_430_000_MIGRACAO_VIDAZUL_DB_FETCH_1();

            /*" -1732- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1733- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1734- MOVE 01 TO SNUM-CARNE */
                    _.Move(01, SNUM_CARNE);

                    /*" -1735- ELSE */
                }
                else
                {


                    /*" -1737- DISPLAY 'VG0040B - ERRO FETCH CDEBTO          ' MNUM-CERTIFICADO */
                    _.Display($"VG0040B - ERRO FETCH CDEBTO          {MNUM_CERTIFICADO}");

                    /*" -1739- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -1739- PERFORM M_430_000_MIGRACAO_VIDAZUL_DB_CLOSE_1 */

            M_430_000_MIGRACAO_VIDAZUL_DB_CLOSE_1();

            /*" -1742- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1744- DISPLAY 'VG0040B - ERRO CLOSE CDEBTO ' MNUM-CERTIFICADO */
                _.Display($"VG0040B - ERRO CLOSE CDEBTO {MNUM_CERTIFICADO}");

                /*" -1746- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1753- PERFORM M_430_000_MIGRACAO_VIDAZUL_DB_UPDATE_1 */

            M_430_000_MIGRACAO_VIDAZUL_DB_UPDATE_1();

            /*" -1756- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1758- DISPLAY 'VG0040B - ERRO UPDATE V0SEGURAVG ' MNUM-CERTIFICADO */
                _.Display($"VG0040B - ERRO UPDATE V0SEGURAVG {MNUM_CERTIFICADO}");

                /*" -1758- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-430-000-MIGRACAO-VIDAZUL-DB-OPEN-1 */
        public void M_430_000_MIGRACAO_VIDAZUL_DB_OPEN_1()
        {
            /*" -1720- EXEC SQL OPEN CDEBTO END-EXEC. */

            CDEBTO.Open();

        }

        [StopWatch]
        /*" M-430-000-MIGRACAO-VIDAZUL-DB-FETCH-1 */
        public void M_430_000_MIGRACAO_VIDAZUL_DB_FETCH_1()
        {
            /*" -1729- EXEC SQL FETCH CDEBTO INTO :SNUM-CARNE END-EXEC. */

            if (CDEBTO.Fetch())
            {
                _.Move(CDEBTO.SNUM_CARNE, SNUM_CARNE);
            }

        }

        [StopWatch]
        /*" M-430-000-MIGRACAO-VIDAZUL-DB-CLOSE-1 */
        public void M_430_000_MIGRACAO_VIDAZUL_DB_CLOSE_1()
        {
            /*" -1739- EXEC SQL CLOSE CDEBTO END-EXEC. */

            CDEBTO.Close();

        }

        [StopWatch]
        /*" M-430-000-MIGRACAO-VIDAZUL-DB-UPDATE-1 */
        public void M_430_000_MIGRACAO_VIDAZUL_DB_UPDATE_1()
        {
            /*" -1753- EXEC SQL UPDATE SEGUROS.V0SEGURAVG SET NUM_CARNE = :SNUM-CARNE WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND TIPO_SEGURADO = :MTIPO-SEGURADO END-EXEC. */

            var m_430_000_MIGRACAO_VIDAZUL_DB_UPDATE_1_Update1 = new M_430_000_MIGRACAO_VIDAZUL_DB_UPDATE_1_Update1()
            {
                SNUM_CARNE = SNUM_CARNE.ToString(),
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
            };

            M_430_000_MIGRACAO_VIDAZUL_DB_UPDATE_1_Update1.Execute(m_430_000_MIGRACAO_VIDAZUL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_430_999_EXIT*/

        [StopWatch]
        /*" R7777-CONS-MODALIDADE-APOL-SECTION */
        private void R7777_CONS_MODALIDADE_APOL_SECTION()
        {
            /*" -1768- MOVE '7777' TO WNR-EXEC-SQL. */
            _.Move("7777", WS_DADOS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1770- MOVE 'R7777-CONS-MODALIDADE-APOL' TO PARAGRAFO */
            _.Move("R7777-CONS-MODALIDADE-APOL", WS_DADOS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1772- INITIALIZE REGISTRO-LINKAGE-GE0510S. */
            _.Initialize(
                REGISTRO_LINKAGE_GE0510S
            );

            /*" -1773- MOVE MNUM-APOLICE TO LK-GE510-NUM-APOLICE */
            _.Move(MNUM_APOLICE, REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE);

            /*" -1775- MOVE MCOD-SUBGRUPO TO LK-GE510-COD-SUBGRUPO */
            _.Move(MCOD_SUBGRUPO, REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO);

            /*" -1777- CALL 'GE0510S' USING REGISTRO-LINKAGE-GE0510S. */
            _.Call("GE0510S", REGISTRO_LINKAGE_GE0510S);

            /*" -1778- IF (LK-GE510-COD-RETORNO EQUAL '0' ) */

            if ((REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO == "0"))
            {

                /*" -1779- MOVE LK-GE510-COD-MODALIDADE TO V0APOL-MODALIDA */
                _.Move(REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_MODALIDADE, V0APOL_MODALIDA);

                /*" -1780- ELSE */
            }
            else
            {


                /*" -1781- DISPLAY ' ' */
                _.Display($" ");

                /*" -1782- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1783- DISPLAY '*      R7777-CONS-MODALIDA-APOL         *' */
                _.Display($"*      R7777-CONS-MODALIDA-APOL         *");

                /*" -1784- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0510S  *' */
                _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0510S  *");

                /*" -1785- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1786- DISPLAY '=> APOLICE........ ' LK-GE510-NUM-APOLICE */
                _.Display($"=> APOLICE........ {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE}");

                /*" -1787- DISPLAY '=> COD-SUBGRUPO... ' LK-GE510-COD-SUBGRUPO */
                _.Display($"=> COD-SUBGRUPO... {REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO}");

                /*" -1788- DISPLAY '=> NUM-CERTIFICADO ' LK-GE510-NUM-CERTIFICADO */
                _.Display($"=> NUM-CERTIFICADO {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_CERTIFICADO}");

                /*" -1789- DISPLAY '-----------------------------------------' */
                _.Display($"-----------------------------------------");

                /*" -1790- DISPLAY '=> LK-MENSAGEM ... ' LK-GE510-MENSAGEM */
                _.Display($"=> LK-MENSAGEM ... {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM}");

                /*" -1791- DISPLAY '=> LK-COD-RETORNO. ' LK-GE510-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO. {REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO}");

                /*" -1792- DISPLAY '=> LK-SQLCODE..... ' LK-GE510-SQLCODE */
                _.Display($"=> LK-SQLCODE..... {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_SQLCODE}");

                /*" -1793- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1794- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1795- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_99_SAIDA*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -1809- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1812- DISPLAY 'INSERIDOS NA HISTSEGVG ... ' AC-GRAVA */
            _.Display($"INSERIDOS NA HISTSEGVG ... {WS_DADOS_AUXILIARES.AC_GRAVA}");

            /*" -1813- DISPLAY 'FIM NORMAL      **** VG0040B ****' . */
            _.Display($"FIM NORMAL      **** VG0040B ****");

            /*" -1814- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1816- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" M-999-999-ROT-ERRO */
        private void M_999_999_ROT_ERRO(bool isPerform = false)
        {
            /*" -1825- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1826- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WS_DADOS_AUXILIARES.WABEND.WSQLCODE);

                /*" -1827- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], WS_DADOS_AUXILIARES.WABEND.WSQLCODE1);

                /*" -1828- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], WS_DADOS_AUXILIARES.WABEND.WSQLCODE2);

                /*" -1829- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, WS_DADOS_AUXILIARES.WSQLCODE3);

                /*" -1831- DISPLAY WABEND. */
                _.Display(WS_DADOS_AUXILIARES.WABEND);
            }


            /*" -1833- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1837- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1840- MOVE 9 TO RETURN-CODE */
            _.Move(9, RETURN_CODE);

            /*" -1840- GOBACK. */

            throw new GoBack();

        }
    }
}