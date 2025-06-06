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
using Sias.VidaEmGrupo.DB2.VG1652B;

namespace Code
{
    public class VG1652B
    {
        public bool IsCall { get; set; }

        public VG1652B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------  ---------                                              */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ................  VG - VIDA EM GRUPO (REDE-SIM)      *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG1652B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA................  LUIZ MARQUES (FAST COMPUTER)       *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  LUIZ MARQUES (FAST COMPUTER)       *      */
        /*"      *                                                                *      */
        /*"      *   DATA CODIFICACAO .......  SETEMBRO/2012                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  PREPARAR A COBERPROPVA COM OS DA-  *      */
        /*"      *                             DOS PARA O FATURAMENTO DOS SUBGRU- *      */
        /*"      *                             POS DA APOLICE COMERCIALIZADA PELA *      */
        /*"      *                             REDE SIM.                          *      */
        /*"      *                                                                *      */
        /*"      *                             FATURAMENTO: TIPO '3' - POR SUB-   *      */
        /*"      *                                          GRUPO COM RESUMO.     *      */
        /*"      *                             (RECUPERA OS DADOS DE TODOS  OS    *      */
        /*"      *                              SUBGRUPOS DA AP�LICE MAS GERA     *      */
        /*"      *                              FATURA SOMENTE PARA O SUBGRUPO    *      */
        /*"      *                              "0" (ZERO). SOMENTE PARA O ESTI-  *      */
        /*"      *                              PULANTE)                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 01 - PROCURAR POR V.01.                                 *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 79.013  DATA: 02/02/2013                           *      */
        /*"      *                                                                *      */
        /*"      *           LUIZ EDUARDO MARQUES         FAST COMPUTER           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 00 - VERSAO ORIGINAL.                                   *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 72.667  DATA: 22/09/2012                           *      */
        /*"      *                                                                *      */
        /*"      *           LUIZ EDUARDO MARQUES         FAST COMPUTER           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WS-COBERPROPVA                PIC  X(001)    VALUE  'S'.*/
        public StringBasis WS_COBERPROPVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
        /*"77  WHOST-DATA-HOJE               PIC  X(010).*/
        public StringBasis WHOST_DATA_HOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-HOJE-MAIS15        PIC  X(010).*/
        public StringBasis WHOST_DATA_HOJE_MAIS15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DIA-HOJE-MAIS15         PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_DIA_HOJE_MAIS15 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-DATA-FATURAMENTO        PIC  X(010).*/
        public StringBasis WHOST_DATA_FATURAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-FAT-INI            PIC  X(010).*/
        public StringBasis WHOST_DATA_FAT_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-FAT-FIM            PIC  X(010).*/
        public StringBasis WHOST_DATA_FAT_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-FIM-VIG            PIC  X(010).*/
        public StringBasis WHOST_DATA_FIM_VIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DTINIVIG                PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DTTERVIG                PIC  X(010).*/
        public StringBasis WHOST_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-COD-SUBGRUPO            PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-QTDSEG                  PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTDSEG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-OCOR-HISTORICO          PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_OCOR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-SIT-PROPOVA             PIC  X(010).*/
        public StringBasis WHOST_SIT_PROPOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DIA-INIVIGENCIA-1       PIC  9(002).*/
        public IntBasis WHOST_DIA_INIVIGENCIA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"77  WHOST-DATA-INIVIGENCIA-1      PIC  X(010).*/
        public StringBasis WHOST_DATA_INIVIGENCIA_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-INIVIGENCIA        PIC  X(010).*/
        public StringBasis WHOST_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-TERVIGENCIA        PIC  X(010).*/
        public StringBasis WHOST_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-IND                     PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-QTDTIMES                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTDTIMES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-IMPSEG                  PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_IMPSEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-PRM                     PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_PRM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-PREMIO-VG               PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_PREMIO_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-PREMIO-AP               PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_PREMIO_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-PARCELA                 PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-CONTRATO                PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-SIT-REGISTRO            PIC  X(001).*/
        public StringBasis WHOST_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WHOST-COD-USUARIO             PIC  X(008).*/
        public StringBasis WHOST_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  WHOST-SIT-REGISTRO1           PIC  X(001).*/
        public StringBasis WHOST_SIT_REGISTRO1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WHOST-COD-USUARIO1            PIC  X(008).*/
        public StringBasis WHOST_COD_USUARIO1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  WHOST-NRPARCEL                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-NRPARCEL2               PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_NRPARCEL2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-MINPARC                 PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_MINPARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-OPER-INI                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_OPER_INI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-OPER-FIN                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_OPER_FIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-DATA-PAGTO              PIC  X(010).*/
        public StringBasis WHOST_DATA_PAGTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-IMP-MORNATU-ATU         PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_IMP_MORNATU_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-IMP-MORACID-ATU         PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_IMP_MORACID_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-IMP-INVPERM-ATU         PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_IMP_INVPERM_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-IMP-AMDS-ATU            PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_IMP_AMDS_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-DH-ATU                  PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_DH_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-DIT-ATU                 PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_DIT_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-PRM-VG-ATU              PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_PRM_VG_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-PRM-AP-ATU              PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_PRM_AP_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-CGCCPF                  PIC S9(015)    VALUE +0 COMP-3*/
        public IntBasis WHOST_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-DATA-NASCIMENTO         PIC  X(010).*/
        public StringBasis WHOST_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-TIPO-SEGURADO           PIC  X(001).*/
        public StringBasis WHOST_TIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WHOST-APOLICE                 PIC S9(013)    VALUE +0 COMP-3*/
        public IntBasis WHOST_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  WHOST-SUBGRUPO                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-NRCERTIF                PIC S9(015)    VALUE +0 COMP-3*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-QTDE                    PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-QUANTIDADE              PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_QUANTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-QTDE-SEGVG              PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTDE_SEGVG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-PREMIO                  PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-NUM-CERTIFICADO         PIC S9(015)    VALUE +0 COMP-3*/
        public IntBasis WHOST_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-DAC-CERTIFICADO         PIC  X(001).*/
        public StringBasis WHOST_DAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WHOST-COD-ENDERECO            PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_COD_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-OCORR-ENDERECO          PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-ENDERECO                PIC  X(040)    VALUE SPACES.*/
        public StringBasis WHOST_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"77  WHOST-BAIRRO                  PIC  X(020)    VALUE SPACES.*/
        public StringBasis WHOST_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"77  WHOST-CIDADE                  PIC  X(020)    VALUE SPACES.*/
        public StringBasis WHOST_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"77  WHOST-SIGLA-UF                PIC  X(002)    VALUE SPACES.*/
        public StringBasis WHOST_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"77  WHOST-CEP                     PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-DDD                     PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-TELEFONE                PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V1SIST-DTVENFIM-CN            PIC  X(010).*/
        public StringBasis V1SIST_DTVENFIM_CN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-MIN-DTPROXVEN           PIC  X(010).*/
        public StringBasis WHOST_MIN_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-VENCIMENTO         PIC  X(010).*/
        public StringBasis WHOST_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-NUM-PARCELA             PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CODUSU                   PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_CODUSU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-LOT-EMP-SEGURADO         PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_LOT_EMP_SEGURADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-AVERBACAO           PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_DATA_AVERBACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-ADMISSAO            PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_DATA_ADMISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-INCLUSAO            PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_DATA_INCLUSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-NASCIMENTO          PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-FATURA              PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_DATA_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-FATURA-U            PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_DATA_FATURA_U { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-COD-EMPRESA              PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-MAXDTMOVTO               PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_MAXDTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-MAXDTREFER               PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_MAXDTREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-COD-CRM                  PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_COD_CRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-SIGLA-CRM                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_SIGLA_CRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-OPCAO-MARCADA            PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_OPCAO_MARCADA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-HISCONPA-DATA-FATURA     PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_HISCONPA_DATA_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NRPARCEL-1               PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_NRPARCEL_1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NOME-RAZAO               PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_NOME_RAZAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-TIPO-PESSOA              PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_TIPO_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-IDE-SEXO                 PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_IDE_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-EST-CIVIL                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_EST_CIVIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-OCORR-END                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-ENDERECO                 PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-BAIRRO                   PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_BAIRRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CIDADE                   PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_CIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-SIGLA-UF                 PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_SIGLA_UF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CEP                      PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_CEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DDD                      PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-TELEFONE                 PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-FAX                      PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_FAX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CGCCPF                   PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DTNASC                   PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CODUSU                   PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_CODUSU_0 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          FILLER.*/
        public VG1652B_FILLER_0 FILLER_0 { get; set; } = new VG1652B_FILLER_0();
        public class VG1652B_FILLER_0 : VarBasis
        {
            /*"  03        WSQLCODE3           PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03        AC-PAGOS            PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_PAGOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-PREMIO-IGUAL     PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_PREMIO_IGUAL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-PREMIO-AJUSTADO  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_PREMIO_AJUSTADO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-ERROS-QTDE       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_ERROS_QTDE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-ERROS-VALOR      PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_ERROS_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  03        AC-LIDOS-M          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_M { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-LIDOS            PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-LIDOS-S          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_S { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-LIDOS-PR         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_PR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-LIDOS-OP         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_OP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-I-PROPOSTAVA     PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_PROPOSTAVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-I-OPCAOPAGVA     PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_OPCAOPAGVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-I-COBERPROPVA    PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_COBERPROPVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-U-COBERPROPVA    PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_COBERPROPVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-U-HISTCONTABILVA PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_HISTCONTABILVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-U-OPCAOPAGVA     PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_OPCAOPAGVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-U-MOVIMENTO      PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-DESPREZ-VIG      PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_DESPREZ_VIG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-DESPREZ-FAT-MANU PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_DESPREZ_FAT_MANU { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        FL-ERRO             PIC  X(001).*/

            public SelectorBasis FL_ERRO { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88      HOUVE-ERRO          VALUE '1'. */
							new SelectorItemBasis("HOUVE_ERRO", "1"),
							/*" 88      NAO-HOUVE-ERRO      VALUE '0'. */
							new SelectorItemBasis("NAO_HOUVE_ERRO", "0")
                }
            };

            /*"  03        WPRIM-VEZ           PIC  9(004)             VALUE  0*/
            public IntBasis WPRIM_VEZ { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03        WCONTADOR           PIC  9(004)             VALUE  0*/
            public IntBasis WCONTADOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03        WCLIENTE-SEG        PIC  X(001).*/
            public StringBasis WCLIENTE_SEG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03        WCLIENTE-PROP       PIC  X(001).*/
            public StringBasis WCLIENTE_PROP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03        WCLIENTE-MOV        PIC  X(001).*/
            public StringBasis WCLIENTE_MOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03        WREG-DUPLICA        PIC  9(007)             VALUE  0*/
            public IntBasis WREG_DUPLICA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        WFLAG               PIC  9(001)             VALUE  0*/
            public IntBasis WFLAG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03            WS-TIME         PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03            WS-DTPROXVEN.*/
            public VG1652B_WS_DTPROXVEN WS_DTPROXVEN { get; set; } = new VG1652B_WS_DTPROXVEN();
            public class VG1652B_WS_DTPROXVEN : VarBasis
            {
                /*"    05          WS-PRXAASQL         PIC  9(004).*/
                public IntBasis WS_PRXAASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-PRXT1SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_PRXT1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-PRXMMSQL         PIC  9(002).*/
                public IntBasis WS_PRXMMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-PRXT2SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_PRXT2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-PRXDDSQL         PIC  9(002).*/
                public IntBasis WS_PRXDDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-W01DTSQL.*/
            }
            public VG1652B_WS_W01DTSQL WS_W01DTSQL { get; set; } = new VG1652B_WS_W01DTSQL();
            public class VG1652B_WS_W01DTSQL : VarBasis
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
                /*"  03            WS-W05DTREF.*/
            }
            public VG1652B_WS_W05DTREF WS_W05DTREF { get; set; } = new VG1652B_WS_W05DTREF();
            public class VG1652B_WS_W05DTREF : VarBasis
            {
                /*"    05          WS-W05AAREF         PIC  9(004).*/
                public IntBasis WS_W05AAREF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-W05MMREF         PIC  9(002).*/
                public IntBasis WS_W05MMREF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W05DDREF         PIC  9(002).*/
                public IntBasis WS_W05DDREF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-W02DTSQL-GERA.*/
            }
            public VG1652B_WS_W02DTSQL_GERA WS_W02DTSQL_GERA { get; set; } = new VG1652B_WS_W02DTSQL_GERA();
            public class VG1652B_WS_W02DTSQL_GERA : VarBasis
            {
                /*"    05          WS-W02AASQL-G       PIC  9(004).*/
                public IntBasis WS_W02AASQL_G { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-W02T1SQL-G       PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W02T1SQL_G { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W02MMSQL-G       PIC  9(002).*/
                public IntBasis WS_W02MMSQL_G { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W02T2SQL-G       PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W02T2SQL_G { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W02DDSQL-G       PIC  9(002).*/
                public IntBasis WS_W02DDSQL_G { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WK-DATA1.*/
            }
            public VG1652B_WK_DATA1 WK_DATA1 { get; set; } = new VG1652B_WK_DATA1();
            public class VG1652B_WK_DATA1 : VarBasis
            {
                /*"    10          WS-SEC1           PIC  9(002).*/
                public IntBasis WS_SEC1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          WK-ANO1           PIC  9(002).*/
                public IntBasis WK_ANO1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER            PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10          WK-MES1           PIC  9(002).*/
                public IntBasis WK_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10          WK-DIA1           PIC  9(002).*/
                public IntBasis WK_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-DATA-NASC      PIC  X(008).*/
            }
            public StringBasis WS_DATA_NASC { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03            WS-DATA-ADESAO    PIC  9(008).*/
            public IntBasis WS_DATA_ADESAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  03            WS-DATA-ADESAO-R  REDEFINES                WS-DATA-ADESAO.*/
            private _REDEF_VG1652B_WS_DATA_ADESAO_R _ws_data_adesao_r { get; set; }
            public _REDEF_VG1652B_WS_DATA_ADESAO_R WS_DATA_ADESAO_R
            {
                get { _ws_data_adesao_r = new _REDEF_VG1652B_WS_DATA_ADESAO_R(); _.Move(WS_DATA_ADESAO, _ws_data_adesao_r); VarBasis.RedefinePassValue(WS_DATA_ADESAO, _ws_data_adesao_r, WS_DATA_ADESAO); _ws_data_adesao_r.ValueChanged += () => { _.Move(_ws_data_adesao_r, WS_DATA_ADESAO); }; return _ws_data_adesao_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_adesao_r, WS_DATA_ADESAO); }
            }  //Redefines
            public class _REDEF_VG1652B_WS_DATA_ADESAO_R : VarBasis
            {
                /*"    10          WS-ANO-ADESAO     PIC  9(004).*/
                public IntBasis WS_ANO_ADESAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10          WS-MES-ADESAO     PIC  9(002).*/
                public IntBasis WS_MES_ADESAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          WS-DIA-ADESAO     PIC  9(002).*/
                public IntBasis WS_DIA_ADESAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-DATA-AUX.*/

                public _REDEF_VG1652B_WS_DATA_ADESAO_R()
                {
                    WS_ANO_ADESAO.ValueChanged += OnValueChanged;
                    WS_MES_ADESAO.ValueChanged += OnValueChanged;
                    WS_DIA_ADESAO.ValueChanged += OnValueChanged;
                }

            }
            public VG1652B_WS_DATA_AUX WS_DATA_AUX { get; set; } = new VG1652B_WS_DATA_AUX();
            public class VG1652B_WS_DATA_AUX : VarBasis
            {
                /*"    05          WS-ANO-AUX          PIC  9(004).*/
                public IntBasis WS_ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-TRA1-AUX         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA1_AUX { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-MES-AUX          PIC  9(002).*/
                public IntBasis WS_MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-TRA2-AUX         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA2_AUX { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-DIA-AUX          PIC  9(002).*/
                public IntBasis WS_DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-DATA-INICIAL.*/
            }
            public VG1652B_WS_DATA_INICIAL WS_DATA_INICIAL { get; set; } = new VG1652B_WS_DATA_INICIAL();
            public class VG1652B_WS_DATA_INICIAL : VarBasis
            {
                /*"    05          WS-ANO-INI          PIC  9(004).*/
                public IntBasis WS_ANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-TRA1-INI         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA1_INI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-MES-INI          PIC  9(002).*/
                public IntBasis WS_MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-TRA2-INI         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA2_INI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-DIA-INI          PIC  9(002).*/
                public IntBasis WS_DIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-DATA-FINAL.*/
            }
            public VG1652B_WS_DATA_FINAL WS_DATA_FINAL { get; set; } = new VG1652B_WS_DATA_FINAL();
            public class VG1652B_WS_DATA_FINAL : VarBasis
            {
                /*"    05          WS-ANO-FIM          PIC  9(004).*/
                public IntBasis WS_ANO_FIM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-TRA1-FIM         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA1_FIM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-MES-FIM          PIC  9(002).*/
                public IntBasis WS_MES_FIM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-TRA2-FIM         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA2_FIM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-DIA-FIM          PIC  9(002).*/
                public IntBasis WS_DIA_FIM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-DATA-SQL.*/
            }
            public VG1652B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VG1652B_WS_DATA_SQL();
            public class VG1652B_WS_DATA_SQL : VarBasis
            {
                /*"    05          WS-SEC-SQL          PIC  9(002) VALUE 19.*/
                public IntBasis WS_SEC_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 19);
                /*"    05          WS-ANO-SQL          PIC  9(002).*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-TRA1             PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-MES-SQL          PIC  9(002).*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-TRA2             PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-DIA-SQL          PIC  9(002).*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-DATA.*/
            }
            public VG1652B_WS_DATA WS_DATA { get; set; } = new VG1652B_WS_DATA();
            public class VG1652B_WS_DATA : VarBasis
            {
                /*"    10       WS-SEC            PIC  9(002)    VALUE 19.*/
                public IntBasis WS_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 19);
                /*"    10       WS-ANO            PIC  9(002).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-MES            PIC  9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-DIA            PIC  9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         W01GRUPOCOTA      PIC  9(009)    VALUE ZEROS.*/
            }
            public IntBasis W01GRUPOCOTA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         FILLER            REDEFINES      W01GRUPOCOTA.*/
            private _REDEF_VG1652B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VG1652B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VG1652B_FILLER_5(); _.Move(W01GRUPOCOTA, _filler_5); VarBasis.RedefinePassValue(W01GRUPOCOTA, _filler_5, W01GRUPOCOTA); _filler_5.ValueChanged += () => { _.Move(_filler_5, W01GRUPOCOTA); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, W01GRUPOCOTA); }
            }  //Redefines
            public class _REDEF_VG1652B_FILLER_5 : VarBasis
            {
                /*"    10       W01-GRUPO         PIC  9(006).*/
                public IntBasis W01_GRUPO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       W01-COTA          PIC  9(003).*/
                public IntBasis W01_COTA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"  03         W01DTCSP          PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG1652B_FILLER_5()
                {
                    W01_GRUPO.ValueChanged += OnValueChanged;
                    W01_COTA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W01DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      W01DTCSP.*/
            private _REDEF_VG1652B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_VG1652B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_VG1652B_FILLER_6(); _.Move(W01DTCSP, _filler_6); VarBasis.RedefinePassValue(W01DTCSP, _filler_6, W01DTCSP); _filler_6.ValueChanged += () => { _.Move(_filler_6, W01DTCSP); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, W01DTCSP); }
            }  //Redefines
            public class _REDEF_VG1652B_FILLER_6 : VarBasis
            {
                /*"    10       W01DDCSP          PIC  9(002).*/
                public IntBasis W01DDCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W01MMCSP          PIC  9(002).*/
                public IntBasis W01MMCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W01SCCSP          PIC  9(002).*/
                public IntBasis W01SCCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W01AACSP          PIC  9(002).*/
                public IntBasis W01AACSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         W02DTCSP          PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG1652B_FILLER_6()
                {
                    W01DDCSP.ValueChanged += OnValueChanged;
                    W01MMCSP.ValueChanged += OnValueChanged;
                    W01SCCSP.ValueChanged += OnValueChanged;
                    W01AACSP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W02DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      W02DTCSP.*/
            private _REDEF_VG1652B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_VG1652B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_VG1652B_FILLER_7(); _.Move(W02DTCSP, _filler_7); VarBasis.RedefinePassValue(W02DTCSP, _filler_7, W02DTCSP); _filler_7.ValueChanged += () => { _.Move(_filler_7, W02DTCSP); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, W02DTCSP); }
            }  //Redefines
            public class _REDEF_VG1652B_FILLER_7 : VarBasis
            {
                /*"    10       W02DDCSP          PIC  9(002).*/
                public IntBasis W02DDCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W02MMCSP          PIC  9(002).*/
                public IntBasis W02MMCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W02SCCSP          PIC  9(002).*/
                public IntBasis W02SCCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W02AACSP          PIC  9(002).*/
                public IntBasis W02AACSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-DTREF          PIC  9(006)    VALUE ZEROS.*/

                public _REDEF_VG1652B_FILLER_7()
                {
                    W02DDCSP.ValueChanged += OnValueChanged;
                    W02MMCSP.ValueChanged += OnValueChanged;
                    W02SCCSP.ValueChanged += OnValueChanged;
                    W02AACSP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DTREF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03         FILLER            REDEFINES      WS-DTREF.*/
            private _REDEF_VG1652B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_VG1652B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_VG1652B_FILLER_8(); _.Move(WS_DTREF, _filler_8); VarBasis.RedefinePassValue(WS_DTREF, _filler_8, WS_DTREF); _filler_8.ValueChanged += () => { _.Move(_filler_8, WS_DTREF); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WS_DTREF); }
            }  //Redefines
            public class _REDEF_VG1652B_FILLER_8 : VarBasis
            {
                /*"    10       WS-REF-ANO        PIC  9(004).*/
                public IntBasis WS_REF_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS-REF-MES        PIC  9(002).*/
                public IntBasis WS_REF_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-DTREF-SQL      PIC  X(010).*/

                public _REDEF_VG1652B_FILLER_8()
                {
                    WS_REF_ANO.ValueChanged += OnValueChanged;
                    WS_REF_MES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DTREF_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03         FILLER            REDEFINES      WS-DTREF-SQL.*/
            private _REDEF_VG1652B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_VG1652B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_VG1652B_FILLER_9(); _.Move(WS_DTREF_SQL, _filler_9); VarBasis.RedefinePassValue(WS_DTREF_SQL, _filler_9, WS_DTREF_SQL); _filler_9.ValueChanged += () => { _.Move(_filler_9, WS_DTREF_SQL); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, WS_DTREF_SQL); }
            }  //Redefines
            public class _REDEF_VG1652B_FILLER_9 : VarBasis
            {
                /*"    10       WS-REF-ANO-SQL    PIC  9(004).*/
                public IntBasis WS_REF_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS-REF-TRA1-SQL   PIC  X(001).*/
                public StringBasis WS_REF_TRA1_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-REF-MES-SQL    PIC  9(002).*/
                public IntBasis WS_REF_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS-REF-TRA2-SQL   PIC  X(001).*/
                public StringBasis WS_REF_TRA2_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-REF-DIA-SQL    PIC  9(002).*/
                public IntBasis WS_REF_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        WPRMTOT                  PIC S9(013)V99                                        VALUE +0 COMP-3.*/

                public _REDEF_VG1652B_FILLER_9()
                {
                    WS_REF_ANO_SQL.ValueChanged += OnValueChanged;
                    WS_REF_TRA1_SQL.ValueChanged += OnValueChanged;
                    WS_REF_MES_SQL.ValueChanged += OnValueChanged;
                    WS_REF_TRA2_SQL.ValueChanged += OnValueChanged;
                    WS_REF_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        PARCEL-SEG               PIC  9(004) VALUE ZEROS.*/
            public IntBasis PARCEL_SEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03        PARCEL-PROP              PIC  9(004) VALUE ZEROS.*/
            public IntBasis PARCEL_PROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03        CPF-SEG-ANT              PIC  9(014) VALUE ZEROS.*/
            public IntBasis CPF_SEG_ANT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03        GRUPO-SEG-ANT            PIC  9(009) VALUE ZEROS.*/
            public IntBasis GRUPO_SEG_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03        COTA-SEG-ANT             PIC  9(009) VALUE ZEROS.*/
            public IntBasis COTA_SEG_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03        WS-NUM-APOLICE-ANT       PIC  9(013) VALUE ZEROS.*/
            public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03        AC-SOLICITADOS           PIC  9(007) VALUE 0.*/
            public IntBasis AC_SOLICITADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-LIDOS                  PIC  9(007) VALUE 0.*/
            public IntBasis W_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        WAC-LIDOS                PIC  9(007) VALUE 0.*/
            public IntBasis WAC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-GRAVADOS               PIC  9(007) VALUE 0.*/
            public IntBasis W_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        FILLER.*/
            public VG1652B_FILLER_10 FILLER_10 { get; set; } = new VG1652B_FILLER_10();
            public class VG1652B_FILLER_10 : VarBasis
            {
                /*"    05      WTEM-PARCEVID            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_PARCEVID { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-NRPARCEL            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_NRPARCEL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WGERA-PARCELA            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WGERA_PARCELA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-INTERVALO           PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_INTERVALO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-HISTCOBVA           PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_HISTCOBVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-HISTCONTABILVA      PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_HISTCONTABILVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-HISTCONTABILVA2     PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_HISTCONTABILVA2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-COBERPROPVA         PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_COBERPROPVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-SEGURVGA            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_SEGURVGA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-CLIENTE             PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_CLIENTE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-SUBGVGAP            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_SUBGVGAP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WFIM-MOVIMENTO           PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WFIM-SEGURVGA            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WFIM_SEGURVGA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WPROCESSA                PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WPROCESSA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      FLAG-WFIM-SEGURADO             PIC  9(001) VALUE 0.*/

                public SelectorBasis FLAG_WFIM_SEGURADO { get; set; } = new SelectorBasis("001", "0")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88    FIM-SEGURADO                   VALUE 1. */
							new SelectorItemBasis("FIM_SEGURADO", "1")
                }
                };

                /*"    03      WABEND.*/
                public VG1652B_WABEND WABEND { get; set; } = new VG1652B_WABEND();
                public class VG1652B_WABEND : VarBasis
                {
                    /*"      05      FILLER              PIC  X(010) VALUE             ' VG1652B'.*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG1652B");
                    /*"      05      FILLER              PIC  X(028) VALUE             ' *** ERRO  EXEC SQL  NUMERO '.*/
                    public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                    /*"      05      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                    /*"      05      FILLER              PIC  X(017) VALUE             ' *** PARAGRAFO = '.*/
                    public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                    /*"      05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                    public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                    /*"      05      FILLER              PIC  X(014) VALUE             '    SQLCODE = '.*/
                    public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                    /*"      05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"      05      FILLER              PIC  X(014) VALUE             '    SQLCODE1= '.*/
                    public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                    /*"      05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"      05      FILLER              PIC  X(014) VALUE             '    SQLCODE2= '.*/
                    public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                    /*"      05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"    03         WSQLERRO.*/
                }
                public VG1652B_WSQLERRO WSQLERRO { get; set; } = new VG1652B_WSQLERRO();
                public class VG1652B_WSQLERRO : VarBasis
                {
                    /*"      05         FILLER               PIC  X(014) VALUE                ' *** SQLERRMC '.*/
                    public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                    /*"      05         WSQLERRMC            PIC  X(070) VALUE  SPACES.*/
                    public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                    /*"  03  W-NUMR-TITULO                  PIC  9(013)   VALUE ZEROS.*/
                }
            }
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03  FILLER                         REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_VG1652B_FILLER_18 _filler_18 { get; set; }
            public _REDEF_VG1652B_FILLER_18 FILLER_18
            {
                get { _filler_18 = new _REDEF_VG1652B_FILLER_18(); _.Move(W_NUMR_TITULO, _filler_18); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_18, W_NUMR_TITULO); _filler_18.ValueChanged += () => { _.Move(_filler_18, W_NUMR_TITULO); }; return _filler_18; }
                set { VarBasis.RedefinePassValue(value, _filler_18, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_VG1652B_FILLER_18 : VarBasis
            {
                /*"      05    WTITL-ZEROS              PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05    WTITL-SEQUENCIA          PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05    WTITL-DIGITO             PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03  DPARM01X.*/

                public _REDEF_VG1652B_FILLER_18()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public VG1652B_DPARM01X DPARM01X { get; set; } = new VG1652B_DPARM01X();
            public class VG1652B_DPARM01X : VarBasis
            {
                /*"      05            DPARM01          PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05            DPARM01-R        REDEFINES   DPARM01.*/
                private _REDEF_VG1652B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_VG1652B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_VG1652B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_VG1652B_DPARM01_R : VarBasis
                {
                    /*"        10          DPARM01-1        PIC  9(001).*/
                    public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-2        PIC  9(001).*/
                    public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-3        PIC  9(001).*/
                    public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-4        PIC  9(001).*/
                    public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-5        PIC  9(001).*/
                    public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-6        PIC  9(001).*/
                    public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-7        PIC  9(001).*/
                    public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-8        PIC  9(001).*/
                    public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-9        PIC  9(001).*/
                    public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-10       PIC  9(001).*/
                    public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      05            DPARM01-D1       PIC  9(001).*/

                    public _REDEF_VG1652B_DPARM01_R()
                    {
                        DPARM01_1.ValueChanged += OnValueChanged;
                        DPARM01_2.ValueChanged += OnValueChanged;
                        DPARM01_3.ValueChanged += OnValueChanged;
                        DPARM01_4.ValueChanged += OnValueChanged;
                        DPARM01_5.ValueChanged += OnValueChanged;
                        DPARM01_6.ValueChanged += OnValueChanged;
                        DPARM01_7.ValueChanged += OnValueChanged;
                        DPARM01_8.ValueChanged += OnValueChanged;
                        DPARM01_9.ValueChanged += OnValueChanged;
                        DPARM01_10.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis DPARM01_D1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      05            DPARM01-RC       PIC S9(004) COMP VALUE +0.*/
                public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  03        FILLER.*/
            }
            public VG1652B_FILLER_19 FILLER_19 { get; set; } = new VG1652B_FILLER_19();
            public class VG1652B_FILLER_19 : VarBasis
            {
                /*"    05      AUX-MORTE-NATURAL        PIC  9(013)V99.*/
                public DoubleBasis AUX_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-MORTE-ACIDENTAL      PIC  9(013)V99.*/
                public DoubleBasis AUX_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-INV-PERMANENTE       PIC  9(013)V99.*/
                public DoubleBasis AUX_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-AMDS                 PIC  9(013)V99.*/
                public DoubleBasis AUX_AMDS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-DIARIA-HOSP          PIC  9(013)V99.*/
                public DoubleBasis AUX_DIARIA_HOSP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-DIARIA-INT           PIC  9(013)V99.*/
                public DoubleBasis AUX_DIARIA_INT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-DESPESA-MED          PIC  9(013)V99.*/
                public DoubleBasis AUX_DESPESA_MED { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-TIPO-CLIENTE         PIC  X(030).*/
                public StringBasis AUX_TIPO_CLIENTE { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    05      AUX-TIPO-IMPORT          PIC  X(030).*/
                public StringBasis AUX_TIPO_IMPORT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    05      AUX-OUTROS               PIC  X(001) VALUE SPACES.*/
                public StringBasis AUX_OUTROS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05      I                        PIC  9(002) VALUE ZEROS.*/
                public IntBasis I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03        WDATA-REL           PIC  X(010)  VALUE SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03        FILLER              REDEFINES    WDATA-REL.*/
            private _REDEF_VG1652B_FILLER_20 _filler_20 { get; set; }
            public _REDEF_VG1652B_FILLER_20 FILLER_20
            {
                get { _filler_20 = new _REDEF_VG1652B_FILLER_20(); _.Move(WDATA_REL, _filler_20); VarBasis.RedefinePassValue(WDATA_REL, _filler_20, WDATA_REL); _filler_20.ValueChanged += () => { _.Move(_filler_20, WDATA_REL); }; return _filler_20; }
                set { VarBasis.RedefinePassValue(value, _filler_20, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VG1652B_FILLER_20 : VarBasis
            {
                /*"    10      WDAT-REL-SEC        PIC  9(002).*/
                public IntBasis WDAT_REL_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WDAT-REL-ANO        PIC  9(002).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-REL-MES        PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-REL-DIA        PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        WDAT-REL-LIT.*/

                public _REDEF_VG1652B_FILLER_20()
                {
                    WDAT_REL_SEC.ValueChanged += OnValueChanged;
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_21.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_22.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VG1652B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VG1652B_WDAT_REL_LIT();
            public class VG1652B_WDAT_REL_LIT : VarBasis
            {
                /*"    10      WDAT-LIT-DIA        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDAT-LIT-MES        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDAT-LIT-SEC        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WDAT-LIT-ANO        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03         WDATA-ALTERACAO   PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_ALTERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-ALTERACAO.*/
            private _REDEF_VG1652B_FILLER_25 _filler_25 { get; set; }
            public _REDEF_VG1652B_FILLER_25 FILLER_25
            {
                get { _filler_25 = new _REDEF_VG1652B_FILLER_25(); _.Move(WDATA_ALTERACAO, _filler_25); VarBasis.RedefinePassValue(WDATA_ALTERACAO, _filler_25, WDATA_ALTERACAO); _filler_25.ValueChanged += () => { _.Move(_filler_25, WDATA_ALTERACAO); }; return _filler_25; }
                set { VarBasis.RedefinePassValue(value, _filler_25, WDATA_ALTERACAO); }
            }  //Redefines
            public class _REDEF_VG1652B_FILLER_25 : VarBasis
            {
                /*"    10       WCOR-ANO.*/
                public VG1652B_WCOR_ANO WCOR_ANO { get; set; } = new VG1652B_WCOR_ANO();
                public class VG1652B_WCOR_ANO : VarBasis
                {
                    /*"      15     WCOR-ANOS         PIC  9(002).*/
                    public IntBasis WCOR_ANOS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     WCOR-ANOA         PIC  9(002).*/
                    public IntBasis WCOR_ANOA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       WCOR-BR1          PIC  X(001).*/

                    public VG1652B_WCOR_ANO()
                    {
                        WCOR_ANOS.ValueChanged += OnValueChanged;
                        WCOR_ANOA.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WCOR_BR1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WCOR-MES          PIC  9(002).*/
                public IntBasis WCOR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WCOR-BR2          PIC  X(001).*/
                public StringBasis WCOR_BR2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WCOR-DIA          PIC  9(002).*/
                public IntBasis WCOR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WNUM-ENDOSSO      PIC  9(009)    VALUE ZEROS.*/

                public _REDEF_VG1652B_FILLER_25()
                {
                    WCOR_ANO.ValueChanged += OnValueChanged;
                    WCOR_BR1.ValueChanged += OnValueChanged;
                    WCOR_MES.ValueChanged += OnValueChanged;
                    WCOR_BR2.ValueChanged += OnValueChanged;
                    WCOR_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WNUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         FILLER            REDEFINES      WNUM-ENDOSSO.*/
            private _REDEF_VG1652B_FILLER_26 _filler_26 { get; set; }
            public _REDEF_VG1652B_FILLER_26 FILLER_26
            {
                get { _filler_26 = new _REDEF_VG1652B_FILLER_26(); _.Move(WNUM_ENDOSSO, _filler_26); VarBasis.RedefinePassValue(WNUM_ENDOSSO, _filler_26, WNUM_ENDOSSO); _filler_26.ValueChanged += () => { _.Move(_filler_26, WNUM_ENDOSSO); }; return _filler_26; }
                set { VarBasis.RedefinePassValue(value, _filler_26, WNUM_ENDOSSO); }
            }  //Redefines
            public class _REDEF_VG1652B_FILLER_26 : VarBasis
            {
                /*"    10       WFAT-ZEROS        PIC  9(003).*/
                public IntBasis WFAT_ZEROS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WFAT-ANO          PIC  9(004).*/
                public IntBasis WFAT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WFAT-MES          PIC  9(002).*/
                public IntBasis WFAT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        CHAVE-MOVIMENTO.*/

                public _REDEF_VG1652B_FILLER_26()
                {
                    WFAT_ZEROS.ValueChanged += OnValueChanged;
                    WFAT_ANO.ValueChanged += OnValueChanged;
                    WFAT_MES.ValueChanged += OnValueChanged;
                }

            }
            public VG1652B_CHAVE_MOVIMENTO CHAVE_MOVIMENTO { get; set; } = new VG1652B_CHAVE_MOVIMENTO();
            public class VG1652B_CHAVE_MOVIMENTO : VarBasis
            {
                /*"    10      CH-MATRIC-MOV       PIC  9(015)  VALUE ZEROS.*/
                public IntBasis CH_MATRIC_MOV { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"  03        CHAVE-SEGURADO.*/
            }
            public VG1652B_CHAVE_SEGURADO CHAVE_SEGURADO { get; set; } = new VG1652B_CHAVE_SEGURADO();
            public class VG1652B_CHAVE_SEGURADO : VarBasis
            {
                /*"    10      CH-MATRIC-SEG       PIC  9(015)  VALUE ZEROS.*/
                public IntBasis CH_MATRIC_SEG { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"01    WS-HORAS.*/
            }
        }
        public VG1652B_WS_HORAS WS_HORAS { get; set; } = new VG1652B_WS_HORAS();
        public class VG1652B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VG1652B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VG1652B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VG1652B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VG1652B_WS_HORA_INI_R : VarBasis
            {
                /*"      05  HI                    PIC  9(002).*/
                public IntBasis HI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MI                    PIC  9(002).*/
                public IntBasis MI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SI                    PIC  9(002).*/
                public IntBasis SI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DI                    PIC  9(002).*/
                public IntBasis DI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-HORA-FIM               PIC  X(008).*/

                public _REDEF_VG1652B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VG1652B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VG1652B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VG1652B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VG1652B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  SIT                       PIC S9(013)V99 COMP-3 VALUE +0.*/

                public _REDEF_VG1652B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SFT                       PIC S9(013)V99 COMP-3 VALUE +0.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SII                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  IND                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public VG1652B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VG1652B_TOTAIS_ROT();
        public class VG1652B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<VG1652B_FILLER_27> FILLER_27 { get; set; } = new ListBasis<VG1652B_FILLER_27>(50);
            public class VG1652B_FILLER_27 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"01        LK-LINK.*/
            }
        }
        public VG1652B_LK_LINK LK_LINK { get; set; } = new VG1652B_LK_LINK();
        public class VG1652B_LK_LINK : VarBasis
        {
            /*"      05     LK-DATA1          PIC  9(008).*/
            public IntBasis LK_DATA1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"      05     LK-DATA2          PIC  9(008).*/
            public IntBasis LK_DATA2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"      05     QTDIA             PIC S9(005)          COMP-3.*/
            public IntBasis QTDIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"01         WPROSOMD2.*/
        }
        public VG1652B_WPROSOMD2 WPROSOMD2 { get; set; } = new VG1652B_WPROSOMD2();
        public class VG1652B_WPROSOMD2 : VarBasis
        {
            /*"    05       WDATA-INFORMADA   PIC  9(008).*/
            public IntBasis WDATA_INFORMADA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05       WDATA-QTDIAS      PIC S9(005)    COMP-3.*/
            public IntBasis WDATA_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"    05       WDATA-CALCULO     PIC  9(008).*/
            public IntBasis WDATA_CALCULO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"01        PARAMETROS.*/
        }
        public VG1652B_PARAMETROS PARAMETROS { get; set; } = new VG1652B_PARAMETROS();
        public class VG1652B_PARAMETROS : VarBasis
        {
            /*"    10      LK710-APOLICE               PIC S9(013) COMP-3.*/
            public IntBasis LK710_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    10      LK710-SUBGRUPO              PIC S9(004) COMP.*/
            public IntBasis LK710_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      LK710-IDADE                 PIC S9(004) COMP.*/
            public IntBasis LK710_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      LK710-NASCIMENTO.*/
            public VG1652B_LK710_NASCIMENTO LK710_NASCIMENTO { get; set; } = new VG1652B_LK710_NASCIMENTO();
            public class VG1652B_LK710_NASCIMENTO : VarBasis
            {
                /*"      15 LK710-DATA-NASCIMENTO          PIC  9(008).*/
                public IntBasis LK710_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10      LK710-SALARIO               PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis LK710_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-MORTE-NATURAL      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-MORTE-ACIDENTAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-INV-PERMANENTE     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-INV-POR-ACIDENTE   PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_INV_POR_ACIDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-ASS-MEDICA         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-DI-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_DI_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-DI-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_DI_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-MORTE-NATURAL      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-MORTE-ACIDENTAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-INV-PERMANENTE     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-ASS-MEDICA         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-DI-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_DI_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-DI-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_DI_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PREM-MORTE-NATURAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PREM-ACIDENTES-PESSOAIS PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PREM-TOTAL            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-RETURN-CODE           PIC S9(03) COMP-3.*/
            public IntBasis LK710_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
            /*"    10      LK710-MENSAGEM              PIC  X(77).*/
            public StringBasis LK710_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
            /*"  01        PARAMETROS-702.*/
            public VG1652B_PARAMETROS_702 PARAMETROS_702 { get; set; } = new VG1652B_PARAMETROS_702();
            public class VG1652B_PARAMETROS_702 : VarBasis
            {
                /*"    10      LK-APOLICE               PIC S9(013) COMP-3.*/
                public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                /*"    10      LK-SUBGRUPO              PIC S9(004) COMP.*/
                public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10      LK-IDADE                 PIC S9(004) COMP.*/
                public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10      LK-NASCIMENTO.*/
                public VG1652B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VG1652B_LK_NASCIMENTO();
                public class VG1652B_LK_NASCIMENTO : VarBasis
                {
                    /*"      15 LK-DATA-NASCIMENTO          PIC  9(008).*/
                    public IntBasis LK_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"    10      LK-SALARIO               PIC S9(013)V99 COMP-3.*/
                }
            }
            public DoubleBasis LK_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-MORTE-NATURAL      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-MORTE-ACIDENTAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-INV-PERMANENTE     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-ASS-MEDICA         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-DI-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_DI_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-DI-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_DI_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-DESPESA-MEDICA     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_DESPESA_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-MORTE-NATURAL      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-MORTE-ACIDENTAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-INV-PERMANENTE     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-ASS-MEDICA         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-DI-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_DI_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-DI-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_DI_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-DESPESA-MEDICA     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_DESPESA_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PREM-MORTE-NATURAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PREM-ACIDENTES-PESSOAIS PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PREM-TOTAL            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-RETURN-CODE           PIC S9(03) COMP.*/
            public IntBasis LK_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
            /*"    10      LK-MENSAGEM              PIC  X(77).*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
            /*"01         WS-MOVTO-CLIENTE.*/
        }
        public VG1652B_WS_MOVTO_CLIENTE WS_MOVTO_CLIENTE { get; set; } = new VG1652B_WS_MOVTO_CLIENTE();
        public class VG1652B_WS_MOVTO_CLIENTE : VarBasis
        {
            /*"  05       WWORK-COD-CLIENTE      PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-TIPO-MOVIMENTO   PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-DATA-ULT-MANUTEN PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WWORK_DATA_ULT_MANUTEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05       WWORK-NOME-RAZAO       PIC  X(040)    VALUE  SPACES.*/
            public StringBasis WWORK_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05       WWORK-TIPO-PESSOA      PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-IDE-SEXO         PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-ESTADO-CIVIL     PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-OCORR-ENDERECO   PIC S9(004)    VALUE +0 COMP-4*/
            public IntBasis WWORK_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WWORK-ENDERECO         PIC  X(040)    VALUE  SPACES.*/
            public StringBasis WWORK_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05       WWORK-BAIRRO           PIC  X(020)    VALUE  SPACES.*/
            public StringBasis WWORK_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05       WWORK-CIDADE           PIC  X(020)    VALUE  SPACES.*/
            public StringBasis WWORK_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05       WWORK-SIGLA-UF         PIC  X(002)    VALUE  SPACES.*/
            public StringBasis WWORK_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05       WWORK-CEP              PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-DDD              PIC S9(004)    VALUE +0 COMP-4*/
            public IntBasis WWORK_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WWORK-TELEFONE         PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-FAX              PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-CGCCPF           PIC S9(015)    VALUE +0 COMP-3*/
            public IntBasis WWORK_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  05       WWORK-DATA-NASCIMENTO  PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WWORK_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05       WTEM-GECLIMOV          PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WTEM_GECLIMOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01              WS-PARAMETROS.*/
        }
        public VG1652B_WS_PARAMETROS WS_PARAMETROS { get; set; } = new VG1652B_WS_PARAMETROS();
        public class VG1652B_WS_PARAMETROS : VarBasis
        {
            /*"  03            W01DIGCERT.*/
            public VG1652B_W01DIGCERT W01DIGCERT { get; set; } = new VG1652B_W01DIGCERT();
            public class VG1652B_W01DIGCERT : VarBasis
            {
                /*"    05          WCERTIFICADO    PIC  9(015)        VALUE  0.*/
                public IntBasis WCERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"    05          WNUMERO         PIC S9(004)  COMP  VALUE +15.*/
                public IntBasis WNUMERO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +15);
                /*"    05          WDIG            PIC  X(001)  VALUE SPACES.*/
                public StringBasis WDIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            }
        }


        public Copies.LBFVG001 LBFVG001 { get; set; } = new Copies.LBFVG001();
        public Copies.LBFVG002 LBFVG002 { get; set; } = new Copies.LBFVG002();
        public Copies.LBFVG003 LBFVG003 { get; set; } = new Copies.LBFVG003();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.PARAMRAM PARAMRAM { get; set; } = new Dclgens.PARAMRAM();
        public Dclgens.PLANOVGA PLANOVGA { get; set; } = new Dclgens.PLANOVGA();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public VG1652B_CPROPOVA CPROPOVA { get; set; } = new VG1652B_CPROPOVA();
        public VG1652B_SEGURVGA1 SEGURVGA1 { get; set; } = new VG1652B_SEGURVGA1();
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
            /*" -684- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -685- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -688- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -691- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -694- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -695- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -696- DISPLAY ' PROGRAMA EM EXECUCAO VG1652B  ' */
            _.Display($" PROGRAMA EM EXECUCAO VG1652B  ");

            /*" -697- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -699- DISPLAY ' VERSAO V.01 79.013 02/02/2013 ' */
            _.Display($" VERSAO V.01 79.013 02/02/2013 ");

            /*" -700- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -702- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -704- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -706- PERFORM R0090-00-SELECT-PARAMRAM. */

            R0090_00_SELECT_PARAMRAM_SECTION();

            /*" -708- PERFORM R0100-00-SELECT-TSISTEMA. */

            R0100_00_SELECT_TSISTEMA_SECTION();

            /*" -710- PERFORM R0900-00-DECLA-PROPOVA. */

            R0900_00_DECLA_PROPOVA_SECTION();

            /*" -712- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

            /*" -713- IF WFIM-MOVIMENTO EQUAL 'SIM' */

            if (FILLER_0.FILLER_10.WFIM_MOVIMENTO == "SIM")
            {

                /*" -714- MOVE 01 TO RETURN-CODE */
                _.Move(01, RETURN_CODE);

                /*" -715- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -717- GO TO R9000-00-FINALIZA. */

                R9000_00_FINALIZA_SECTION(); //GOTO
                return;
            }


            /*" -720- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-MOVIMENTO EQUAL 'SIM' . */

            while (!(FILLER_0.FILLER_10.WFIM_MOVIMENTO == "SIM"))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -722- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -724- PERFORM R9000-00-FINALIZA. */

            R9000_00_FINALIZA_SECTION();

            /*" -724- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0090-00-SELECT-PARAMRAM-SECTION */
        private void R0090_00_SELECT_PARAMRAM_SECTION()
        {
            /*" -737- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -747- PERFORM R0090_00_SELECT_PARAMRAM_DB_SELECT_1 */

            R0090_00_SELECT_PARAMRAM_DB_SELECT_1();

            /*" -750- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -751- DISPLAY 'VG1652B - ERRO NA LEITURA - PARAMRAMO  ' */
                _.Display($"VG1652B - ERRO NA LEITURA - PARAMRAMO  ");

                /*" -751- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0090-00-SELECT-PARAMRAM-DB-SELECT-1 */
        public void R0090_00_SELECT_PARAMRAM_DB_SELECT_1()
        {
            /*" -747- EXEC SQL SELECT RAMO_VG, RAMO_AP INTO :PARAMRAM-RAMO-VG, :PARAMRAM-RAMO-AP FROM SEGUROS.PARAMETROS_RAMOS WITH UR END-EXEC. */

            var r0090_00_SELECT_PARAMRAM_DB_SELECT_1_Query1 = new R0090_00_SELECT_PARAMRAM_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0090_00_SELECT_PARAMRAM_DB_SELECT_1_Query1.Execute(r0090_00_SELECT_PARAMRAM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMRAM_RAMO_VG, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG);
                _.Move(executed_1.PARAMRAM_RAMO_AP, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0090_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-TSISTEMA-SECTION */
        private void R0100_00_SELECT_TSISTEMA_SECTION()
        {
            /*" -769- MOVE 'R0100-00-SELECT-TSISTEMA ' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-TSISTEMA ", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -771- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -792- PERFORM R0100_00_SELECT_TSISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_TSISTEMA_DB_SELECT_1();

            /*" -795- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -796- DISPLAY 'VG1652B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"VG1652B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -797- DISPLAY 'IDSISTEM =  VG ' */
                _.Display($"IDSISTEM =  VG ");

                /*" -799- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -800- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -801- DISPLAY 'VG1652B - ERRO NA LEITURA NA SISTEMAS  ' */
                _.Display($"VG1652B - ERRO NA LEITURA NA SISTEMAS  ");

                /*" -803- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -805- IF WHOST-DATA-FATURAMENTO NOT EQUAL SISTEMAS-DATA-MOV-ABERTO */

            if (WHOST_DATA_FATURAMENTO != SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO)
            {

                /*" -806- DISPLAY '*  VG1652B - F I M   A N O R M A L  *    ' */
                _.Display($"*  VG1652B - F I M   A N O R M A L  *    ");

                /*" -807- DISPLAY 'VG1652B - DATA DE PROCESSAMENTO INVALIDA ' */
                _.Display($"VG1652B - DATA DE PROCESSAMENTO INVALIDA ");

                /*" -809- DISPLAY 'MOV = ' SISTEMAS-DATA-MOV-ABERTO ' FAT = ' WHOST-DATA-FATURAMENTO */

                $"MOV = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO} FAT = {WHOST_DATA_FATURAMENTO}"
                .Display();

                /*" -810- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -812- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -814- MOVE SISTEMAS-DATA-MOV-ABERTO TO WHOST-DATA-FAT-FIM. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WHOST_DATA_FAT_FIM);

            /*" -815- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-W01DTSQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FILLER_0.WS_W01DTSQL);

            /*" -816- MOVE 01 TO WS-W01DDSQL. */
            _.Move(01, FILLER_0.WS_W01DTSQL.WS_W01DDSQL);

            /*" -818- MOVE WS-W01DTSQL TO WHOST-DATA-FAT-INI. */
            _.Move(FILLER_0.WS_W01DTSQL, WHOST_DATA_FAT_INI);

            /*" -819- MOVE WHOST-DTTERVIG TO WS-W01DTSQL. */
            _.Move(WHOST_DTTERVIG, FILLER_0.WS_W01DTSQL);

            /*" -820- MOVE 01 TO WS-W01DDSQL. */
            _.Move(01, FILLER_0.WS_W01DTSQL.WS_W01DDSQL);

            /*" -822- MOVE WS-W01DTSQL TO WHOST-DTINIVIG. */
            _.Move(FILLER_0.WS_W01DTSQL, WHOST_DTINIVIG);

            /*" -826- DISPLAY '** VG1652B - APURACAO DO MOVIMENTO DE: ' WHOST-DATA-FAT-INI ' ATE ' WHOST-DATA-FAT-FIM. */

            $"** VG1652B - APURACAO DO MOVIMENTO DE: {WHOST_DATA_FAT_INI} ATE {WHOST_DATA_FAT_FIM}"
            .Display();

            /*" -827- DISPLAY '** ' . */
            _.Display($"** ");

            /*" -829- DISPLAY '** VG1652B - GERACAO DA FATURA DE: ' WHOST-DTINIVIG ' ATE ' WHOST-DTTERVIG. */

            $"** VG1652B - GERACAO DA FATURA DE: {WHOST_DTINIVIG} ATE {WHOST_DTTERVIG}"
            .Display();

        }

        [StopWatch]
        /*" R0100-00-SELECT-TSISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_TSISTEMA_DB_SELECT_1()
        {
            /*" -792- EXEC SQL SELECT CURRENT DATE, CURRENT DATE + 15 DAYS, DAY(CURRENT DATE + 15 DAYS), DATA_MOV_ABERTO, DATA_MOV_ABERTO, LAST_DAY(LAST_DAY(DATA_MOV_ABERTO) + 1 DAY) INTO :WHOST-DATA-HOJE, :WHOST-DATA-HOJE-MAIS15, :WHOST-DIA-HOJE-MAIS15, :SISTEMAS-DATA-MOV-ABERTO, :WHOST-DATA-FATURAMENTO, :WHOST-DTTERVIG FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' WITH UR END-EXEC. */

            var r0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATA_HOJE, WHOST_DATA_HOJE);
                _.Move(executed_1.WHOST_DATA_HOJE_MAIS15, WHOST_DATA_HOJE_MAIS15);
                _.Move(executed_1.WHOST_DIA_HOJE_MAIS15, WHOST_DIA_HOJE_MAIS15);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DATA_FATURAMENTO, WHOST_DATA_FATURAMENTO);
                _.Move(executed_1.WHOST_DTTERVIG, WHOST_DTTERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLA-PROPOVA-SECTION */
        private void R0900_00_DECLA_PROPOVA_SECTION()
        {
            /*" -847- MOVE 'R0900-00-DECLA-PROPOVA ' TO PARAGRAFO. */
            _.Move("R0900-00-DECLA-PROPOVA ", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -849- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -872- PERFORM R0900_00_DECLA_PROPOVA_DB_DECLARE_1 */

            R0900_00_DECLA_PROPOVA_DB_DECLARE_1();

            /*" -876- DISPLAY '*** VG1652B *** ABRINDO CURSOR PVA ...' . */
            _.Display($"*** VG1652B *** ABRINDO CURSOR PVA ...");

            /*" -876- PERFORM R0900_00_DECLA_PROPOVA_DB_OPEN_1 */

            R0900_00_DECLA_PROPOVA_DB_OPEN_1();

            /*" -880- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -881- DISPLAY 'PROBLEMAS NO OPEN CURSOR (CPROPOVA) ... ' */
                _.Display($"PROBLEMAS NO OPEN CURSOR (CPROPOVA) ... ");

                /*" -881- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLA-PROPOVA-DB-DECLARE-1 */
        public void R0900_00_DECLA_PROPOVA_DB_DECLARE_1()
        {
            /*" -872- EXEC SQL DECLARE CPROPOVA CURSOR FOR SELECT A.NUM_CERTIFICADO, A.NUM_APOLICE, A.COD_SUBGRUPO, A.NUM_PARCELA, A.OCORR_HISTORICO, A.DTPROXVEN FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.PRODUTOS_VG B WHERE A.NUM_APOLICE IN (108210871143) AND A.COD_SUBGRUPO >= 0 AND A.SIT_REGISTRO IN ( '3' , '6' ) AND A.COD_FONTE >= 0 AND A.DTPROXVEN <> '9999-12-31' AND A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO ORDER BY A.NUM_APOLICE, A.COD_SUBGRUPO END-EXEC. */
            CPROPOVA = new VG1652B_CPROPOVA(false);
            string GetQuery_CPROPOVA()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.NUM_PARCELA
							, 
							A.OCORR_HISTORICO
							, 
							A.DTPROXVEN 
							FROM 
							SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.PRODUTOS_VG B 
							WHERE 
							A.NUM_APOLICE IN (108210871143) 
							AND A.COD_SUBGRUPO >= 0 
							AND A.SIT_REGISTRO IN ( '3'
							, '6' ) 
							AND A.COD_FONTE >= 0 
							AND A.DTPROXVEN <> '9999-12-31' 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.COD_SUBGRUPO = B.COD_SUBGRUPO 
							ORDER BY 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO";

                return query;
            }
            CPROPOVA.GetQueryEvent += GetQuery_CPROPOVA;

        }

        [StopWatch]
        /*" R0900-00-DECLA-PROPOVA-DB-OPEN-1 */
        public void R0900_00_DECLA_PROPOVA_DB_OPEN_1()
        {
            /*" -876- EXEC SQL OPEN CPROPOVA END-EXEC. */

            CPROPOVA.Open();

        }

        [StopWatch]
        /*" R2100-00-DECLARE-SEGURVGA-DB-DECLARE-1 */
        public void R2100_00_DECLARE_SEGURVGA_DB_DECLARE_1()
        {
            /*" -1104- EXEC SQL DECLARE SEGURVGA1 CURSOR FOR SELECT A.NUM_ITEM , A.OCORR_HISTORICO, A.NUM_CERTIFICADO, C.NUM_PARCELA , B.COD_FONTE , B.NUM_PROPOSTA FROM SEGUROS.SEGURADOS_VGAP A, SEGUROS.MOVIMENTO_VGAP B, SEGUROS.PROPOSTAS_VA C WHERE B.NUM_APOLICE = :PROPOVA-NUM-APOLICE AND B.DATA_INCLUSAO <= :WHOST-DATA-FAT-FIM AND B.NUM_CERTIFICADO = C.NUM_CERTIFICADO AND B.COD_OPERACAO BETWEEN 100 AND 299 AND B.DATA_FATURA IS NULL AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND B.TIPO_SEGURADO = A.TIPO_SEGURADO AND A.TIPO_SEGURADO = '1' WITH UR END-EXEC. */
            SEGURVGA1 = new VG1652B_SEGURVGA1(true);
            string GetQuery_SEGURVGA1()
            {
                var query = @$"SELECT A.NUM_ITEM
							, 
							A.OCORR_HISTORICO
							, 
							A.NUM_CERTIFICADO
							, 
							C.NUM_PARCELA
							, 
							B.COD_FONTE
							, 
							B.NUM_PROPOSTA 
							FROM SEGUROS.SEGURADOS_VGAP A
							, 
							SEGUROS.MOVIMENTO_VGAP B
							, 
							SEGUROS.PROPOSTAS_VA C 
							WHERE 
							B.NUM_APOLICE = '{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}' 
							AND B.DATA_INCLUSAO <= '{WHOST_DATA_FAT_FIM}' 
							AND B.NUM_CERTIFICADO = C.NUM_CERTIFICADO 
							AND B.COD_OPERACAO BETWEEN 100 AND 299 
							AND B.DATA_FATURA IS NULL 
							AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO 
							AND B.TIPO_SEGURADO = A.TIPO_SEGURADO 
							AND A.TIPO_SEGURADO = '1'";

                return query;
            }
            SEGURVGA1.GetQueryEvent += GetQuery_SEGURVGA1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-SECTION */
        private void R0910_00_FETCH_PROPOVA_SECTION()
        {
            /*" -894- MOVE 'R0910-00-FETCH-PROPOVA' TO PARAGRAFO. */
            _.Move("R0910-00-FETCH-PROPOVA", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -901- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -908- PERFORM R0910_00_FETCH_PROPOVA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOVA_DB_FETCH_1();

            /*" -911- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -912- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -912- PERFORM R0910_00_FETCH_PROPOVA_DB_CLOSE_1 */

                    R0910_00_FETCH_PROPOVA_DB_CLOSE_1();

                    /*" -914- MOVE 'SIM' TO WFIM-MOVIMENTO */
                    _.Move("SIM", FILLER_0.FILLER_10.WFIM_MOVIMENTO);

                    /*" -915- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -916- ELSE */
                }
                else
                {


                    /*" -917- DISPLAY 'R0910-00 (ERRO -  FETCH CPROPOVA).. ' */
                    _.Display($"R0910-00 (ERRO -  FETCH CPROPOVA).. ");

                    /*" -919- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -922- ADD 1 TO AC-LIDOS AC-LIDOS-M. */
            FILLER_0.AC_LIDOS.Value = FILLER_0.AC_LIDOS + 1;
            FILLER_0.AC_LIDOS_M.Value = FILLER_0.AC_LIDOS_M + 1;

            /*" -923- IF AC-LIDOS GREATER 999 */

            if (FILLER_0.AC_LIDOS > 999)
            {

                /*" -924- MOVE ZEROS TO AC-LIDOS */
                _.Move(0, FILLER_0.AC_LIDOS);

                /*" -925- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), FILLER_0.WS_TIME);

                /*" -925- DISPLAY 'LIDOS MOVIMENTO ' AC-LIDOS-M ' ' WS-TIME. */

                $"LIDOS MOVIMENTO {FILLER_0.AC_LIDOS_M} {FILLER_0.WS_TIME}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOVA_DB_FETCH_1()
        {
            /*" -908- EXEC SQL FETCH CPROPOVA INTO :PROPOVA-NUM-CERTIFICADO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-NUM-PARCELA, :PROPOVA-OCORR-HISTORICO, :PROPOVA-DTPROXVEN END-EXEC. */

            if (CPROPOVA.Fetch())
            {
                _.Move(CPROPOVA.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CPROPOVA.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CPROPOVA.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(CPROPOVA.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
                _.Move(CPROPOVA.PROPOVA_OCORR_HISTORICO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO);
                _.Move(CPROPOVA.PROPOVA_DTPROXVEN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_PROPOVA_DB_CLOSE_1()
        {
            /*" -912- EXEC SQL CLOSE CPROPOVA END-EXEC */

            CPROPOVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -938- MOVE 'R1000-00-PROCESSA-REGISTRO' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA-REGISTRO", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -942- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -948- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -951- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -953- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -954- ELSE */
                }
                else
                {


                    /*" -955- DISPLAY 'PROBLEMA NA VERIFICACAO DA FATURA ... ' */
                    _.Display($"PROBLEMA NA VERIFICACAO DA FATURA ... ");

                    /*" -956- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -957- END-IF */
                }


                /*" -958- ELSE */
            }
            else
            {


                /*" -960- DISPLAY 'JA EXISTE FATURA PARA O MES SELECIONADO .. ' PROPOVA-NUM-CERTIFICADO ' ' WHOST-DTINIVIG */

                $"JA EXISTE FATURA PARA O MES SELECIONADO .. {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {WHOST_DTINIVIG}"
                .Display();

                /*" -961- ADD 1 TO AC-DESPREZ-VIG */
                FILLER_0.AC_DESPREZ_VIG.Value = FILLER_0.AC_DESPREZ_VIG + 1;

                /*" -962- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -964- END-IF. */
            }


            /*" -965- IF PROPOVA-NUM-APOLICE NOT EQUAL WS-NUM-APOLICE-ANT */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE != FILLER_0.WS_NUM_APOLICE_ANT)
            {

                /*" -966- PERFORM R2150-00-SELECT-APOLICES */

                R2150_00_SELECT_APOLICES_SECTION();

                /*" -968- END-IF. */
            }


            /*" -970- MOVE PROPOVA-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -971- IF PROPOVA-COD-SUBGRUPO EQUAL ZEROS */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO == 00)
            {

                /*" -973- MOVE 001 TO SUBGVGAP-COD-SUBGRUPO WHOST-COD-SUBGRUPO */
                _.Move(001, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, WHOST_COD_SUBGRUPO);

                /*" -974- ELSE */
            }
            else
            {


                /*" -976- MOVE PROPOVA-COD-SUBGRUPO TO SUBGVGAP-COD-SUBGRUPO WHOST-COD-SUBGRUPO */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, WHOST_COD_SUBGRUPO);

                /*" -978- END-IF. */
            }


            /*" -980- PERFORM R2200-00-SELECT-SUBGVGAP. */

            R2200_00_SELECT_SUBGVGAP_SECTION();

            /*" -981- IF SUBGVGAP-TIPO-FATURAMENTO NOT EQUAL '3' */

            if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_FATURAMENTO != "3")
            {

                /*" -983- DISPLAY 'PRODUTO NAO PODE SER FATURADO PELO VG1652B .. ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"PRODUTO NAO PODE SER FATURADO PELO VG1652B .. {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -984- ADD 1 TO AC-DESPREZ-FAT-MANU */
                FILLER_0.AC_DESPREZ_FAT_MANU.Value = FILLER_0.AC_DESPREZ_FAT_MANU + 1;

                /*" -985- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -987- END-IF. */
            }


            /*" -989- PERFORM R2300-00-SELECT-COBERPROPVA. */

            R2300_00_SELECT_COBERPROPVA_SECTION();

            /*" -990- IF WS-COBERPROPVA EQUAL 'N' */

            if (WS_COBERPROPVA == "N")
            {

                /*" -992- DISPLAY 'VG1652B - NAO EXISTE COBERTURA ATUAL ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"VG1652B - NAO EXISTE COBERTURA ATUAL {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -993- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -995- END-IF. */
            }


            /*" -997- IF HISCOBPR-DATA-INIVIGENCIA (1:7) NOT LESS WHOST-DTINIVIG (1:7) */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.Substring(1, 7) >= WHOST_DTINIVIG.Substring(1, 7))
            {

                /*" -999- DISPLAY 'JA EXISTE FATURA PARA O MES SELECIONADO ' PROPOVA-NUM-CERTIFICADO ' ' WHOST-DTINIVIG */

                $"JA EXISTE FATURA PARA O MES SELECIONADO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {WHOST_DTINIVIG}"
                .Display();

                /*" -1000- ADD 1 TO AC-DESPREZ-VIG */
                FILLER_0.AC_DESPREZ_VIG.Value = FILLER_0.AC_DESPREZ_VIG + 1;

                /*" -1001- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1003- END-IF. */
            }


            /*" -1005- PERFORM R2100-00-DECLARE-SEGURVGA */

            R2100_00_DECLARE_SEGURVGA_SECTION();

            /*" -1007- PERFORM R2120-00-FETCH-SEGURVGA */

            R2120_00_FETCH_SEGURVGA_SECTION();

            /*" -1011- MOVE ZEROS TO WHOST-PRM WHOST-IMPSEG WHOST-QTDSEG. */
            _.Move(0, WHOST_PRM, WHOST_IMPSEG, WHOST_QTDSEG);

            /*" -1012- IF WFIM-SEGURVGA EQUAL 'NAO' */

            if (FILLER_0.FILLER_10.WFIM_SEGURVGA == "NAO")
            {

                /*" -1014- PERFORM R2130-00-ACUMULA-IS UNTIL WFIM-SEGURVGA EQUAL 'SIM' */

                while (!(FILLER_0.FILLER_10.WFIM_SEGURVGA == "SIM"))
                {

                    R2130_00_ACUMULA_IS_SECTION();
                }

                /*" -1015- ELSE */
            }
            else
            {


                /*" -1017- MOVE ZEROS TO WHOST-PRM WHOST-IMPSEG WHOST-QTDSEG */
                _.Move(0, WHOST_PRM, WHOST_IMPSEG, WHOST_QTDSEG);

                /*" -1018- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1020- END-IF. */
            }


            /*" -1021- IF WHOST-PRM NOT GREATER ZEROS */

            if (WHOST_PRM <= 00)
            {

                /*" -1023- MOVE ZEROS TO WHOST-PRM WHOST-IMPSEG WHOST-QTDSEG */
                _.Move(0, WHOST_PRM, WHOST_IMPSEG, WHOST_QTDSEG);

                /*" -1024- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1026- END-IF. */
            }


            /*" -1027- IF HISCOBPR-IMP-MORNATU GREATER ZEROES */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU > 00)
            {

                /*" -1028- IF WHOST-IMPSEG EQUAL HISCOBPR-IMP-MORNATU */

                if (WHOST_IMPSEG == HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU)
                {

                    /*" -1030- MOVE 0 TO HISCOBPR-COD-OPERACAO */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                    /*" -1031- ELSE */
                }
                else
                {


                    /*" -1032- IF WHOST-IMPSEG LESS HISCOBPR-IMP-MORNATU */

                    if (WHOST_IMPSEG < HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU)
                    {

                        /*" -1034- MOVE 701 TO HISCOBPR-COD-OPERACAO */
                        _.Move(701, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                        /*" -1035- ELSE */
                    }
                    else
                    {


                        /*" -1037- MOVE 801 TO HISCOBPR-COD-OPERACAO */
                        _.Move(801, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                        /*" -1038- END-IF */
                    }


                    /*" -1039- END-IF */
                }


                /*" -1040- ELSE */
            }
            else
            {


                /*" -1041- IF WHOST-IMPSEG EQUAL HISCOBPR-IMPMORACID */

                if (WHOST_IMPSEG == HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID)
                {

                    /*" -1043- MOVE 0 TO HISCOBPR-COD-OPERACAO */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                    /*" -1044- ELSE */
                }
                else
                {


                    /*" -1045- IF WHOST-IMPSEG LESS HISCOBPR-IMPMORACID */

                    if (WHOST_IMPSEG < HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID)
                    {

                        /*" -1047- MOVE 701 TO HISCOBPR-COD-OPERACAO */
                        _.Move(701, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                        /*" -1048- ELSE */
                    }
                    else
                    {


                        /*" -1050- MOVE 801 TO HISCOBPR-COD-OPERACAO */
                        _.Move(801, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                        /*" -1051- END-IF */
                    }


                    /*" -1052- END-IF */
                }


                /*" -1054- END-IF. */
            }


            /*" -1056- PERFORM R2910-00-UPDATE-COBERPROPVA. */

            R2910_00_UPDATE_COBERPROPVA_SECTION();

            /*" -1058- PERFORM R2900-00-INSERT-COBERPROPVA. */

            R2900_00_INSERT_COBERPROPVA_SECTION();

            /*" -1060- PERFORM R2400-00-SELECT-OPCAOPAGVA. */

            R2400_00_SELECT_OPCAOPAGVA_SECTION();

            /*" -1060- PERFORM R2920-00-UPDATE-PROPOSTAVA. */

            R2920_00_UPDATE_PROPOSTAVA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -948- EXEC SQL SELECT NUM_CERTIFICADO INTO :HISCOBPR-NUM-CERTIFICADO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_INIVIGENCIA = :WHOST-DTINIVIG END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);
            }


        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1064- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-DECLARE-SEGURVGA-SECTION */
        private void R2100_00_DECLARE_SEGURVGA_SECTION()
        {
            /*" -1077- MOVE 'R2100-00-DECLARE-SEGURVGA' TO PARAGRAFO. */
            _.Move("R2100-00-DECLARE-SEGURVGA", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1081- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1084- MOVE 'NAO' TO WFIM-SEGURVGA. */
            _.Move("NAO", FILLER_0.FILLER_10.WFIM_SEGURVGA);

            /*" -1104- PERFORM R2100_00_DECLARE_SEGURVGA_DB_DECLARE_1 */

            R2100_00_DECLARE_SEGURVGA_DB_DECLARE_1();

            /*" -1108- DISPLAY '*** VG1652B *** ABRINDO CURSOR SVG1 ..' . */
            _.Display($"*** VG1652B *** ABRINDO CURSOR SVG1 ..");

            /*" -1108- PERFORM R2100_00_DECLARE_SEGURVGA_DB_OPEN_1 */

            R2100_00_DECLARE_SEGURVGA_DB_OPEN_1();

            /*" -1111- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1113- DISPLAY 'APOLICE = ' PROPOVA-NUM-APOLICE ' ' WHOST-COD-SUBGRUPO */

                $"APOLICE = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE} {WHOST_COD_SUBGRUPO}"
                .Display();

                /*" -1114- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1114- END-IF. */
            }


        }

        [StopWatch]
        /*" R2100-00-DECLARE-SEGURVGA-DB-OPEN-1 */
        public void R2100_00_DECLARE_SEGURVGA_DB_OPEN_1()
        {
            /*" -1108- EXEC SQL OPEN SEGURVGA1 END-EXEC. */

            SEGURVGA1.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2120-00-FETCH-SEGURVGA-SECTION */
        private void R2120_00_FETCH_SEGURVGA_SECTION()
        {
            /*" -1128- MOVE 'R2120-00-FETCH-SEGURVGA' TO PARAGRAFO. */
            _.Move("R2120-00-FETCH-SEGURVGA", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1132- MOVE '2120' TO WNR-EXEC-SQL. */
            _.Move("2120", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1139- PERFORM R2120_00_FETCH_SEGURVGA_DB_FETCH_1 */

            R2120_00_FETCH_SEGURVGA_DB_FETCH_1();

            /*" -1142- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1143- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1144- MOVE 'SIM' TO WFIM-SEGURVGA */
                    _.Move("SIM", FILLER_0.FILLER_10.WFIM_SEGURVGA);

                    /*" -1144- PERFORM R2120_00_FETCH_SEGURVGA_DB_CLOSE_1 */

                    R2120_00_FETCH_SEGURVGA_DB_CLOSE_1();

                    /*" -1146- ELSE */
                }
                else
                {


                    /*" -1147- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1148- END-IF */
                }


                /*" -1148- END-IF. */
            }


        }

        [StopWatch]
        /*" R2120-00-FETCH-SEGURVGA-DB-FETCH-1 */
        public void R2120_00_FETCH_SEGURVGA_DB_FETCH_1()
        {
            /*" -1139- EXEC SQL FETCH SEGURVGA1 INTO :SEGURVGA-NUM-ITEM , :SEGURVGA-OCORR-HISTORICO, :SEGURVGA-NUM-CERTIFICADO, :WHOST-NUM-PARCELA , :MOVIMVGA-COD-FONTE , :MOVIMVGA-NUM-PROPOSTA END-EXEC. */

            if (SEGURVGA1.Fetch())
            {
                _.Move(SEGURVGA1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(SEGURVGA1.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
                _.Move(SEGURVGA1.SEGURVGA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);
                _.Move(SEGURVGA1.WHOST_NUM_PARCELA, WHOST_NUM_PARCELA);
                _.Move(SEGURVGA1.MOVIMVGA_COD_FONTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE);
                _.Move(SEGURVGA1.MOVIMVGA_NUM_PROPOSTA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA);
            }

        }

        [StopWatch]
        /*" R2120-00-FETCH-SEGURVGA-DB-CLOSE-1 */
        public void R2120_00_FETCH_SEGURVGA_DB_CLOSE_1()
        {
            /*" -1144- EXEC SQL CLOSE SEGURVGA1 END-EXEC */

            SEGURVGA1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2120_99_SAIDA*/

        [StopWatch]
        /*" R2130-00-ACUMULA-IS-SECTION */
        private void R2130_00_ACUMULA_IS_SECTION()
        {
            /*" -1165- MOVE 'R2130-00-ACUMULA-IS' TO PARAGRAFO. */
            _.Move("R2130-00-ACUMULA-IS", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1167- MOVE '2130' TO WNR-EXEC-SQL. */
            _.Move("2130", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1169- PERFORM R2140-00-SELECT-APOLICOB. */

            R2140_00_SELECT_APOLICOB_SECTION();

            /*" -1172- COMPUTE WHOST-QTDSEG = WHOST-QTDSEG + 1 */
            WHOST_QTDSEG.Value = WHOST_QTDSEG + 1;

            /*" -1175- COMPUTE WHOST-PRM = WHOST-PRM + APOLICOB-PRM-TARIFARIO-IX */
            WHOST_PRM.Value = WHOST_PRM + APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX;

            /*" -1178- COMPUTE WHOST-IMPSEG = WHOST-IMPSEG + APOLICOB-IMP-SEGURADA-IX. */
            WHOST_IMPSEG.Value = WHOST_IMPSEG + APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX;

            /*" -1180- MOVE '213A' TO WNR-EXEC-SQL. */
            _.Move("213A", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1182- MOVE WHOST-DTINIVIG TO WS-W01DTSQL. */
            _.Move(WHOST_DTINIVIG, FILLER_0.WS_W01DTSQL);

            /*" -1183- MOVE ZEROS TO WFAT-ZEROS. */
            _.Move(0, FILLER_0.FILLER_26.WFAT_ZEROS);

            /*" -1184- MOVE WS-W01AASQL TO WFAT-ANO. */
            _.Move(FILLER_0.WS_W01DTSQL.WS_W01AASQL, FILLER_0.FILLER_26.WFAT_ANO);

            /*" -1186- MOVE WS-W01MMSQL TO WFAT-MES. */
            _.Move(FILLER_0.WS_W01DTSQL.WS_W01MMSQL, FILLER_0.FILLER_26.WFAT_MES);

            /*" -1188- COMPUTE HISCONPA-NUM-ENDOSSO = WNUM-ENDOSSO * -1. */
            HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO.Value = FILLER_0.WNUM_ENDOSSO * -1;

            /*" -1199- PERFORM R2130_00_ACUMULA_IS_DB_UPDATE_1 */

            R2130_00_ACUMULA_IS_DB_UPDATE_1();

            /*" -1202- IF SQLCODE NOT EQUAL ZEROS AND -811 */

            if (!DB.SQLCODE.In("00", "-811"))
            {

                /*" -1203- DISPLAY 'ERRO NO UPDATE HISTCONTABILVA ' */
                _.Display($"ERRO NO UPDATE HISTCONTABILVA ");

                /*" -1204- DISPLAY 'CERTIF      = ' SEGURVGA-NUM-CERTIFICADO */
                _.Display($"CERTIF      = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO}");

                /*" -1205- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1207- END-IF. */
            }


            /*" -1209- ADD 1 TO AC-U-HISTCONTABILVA. */
            FILLER_0.AC_U_HISTCONTABILVA.Value = FILLER_0.AC_U_HISTCONTABILVA + 1;

            /*" -1211- MOVE '213C' TO WNR-EXEC-SQL. */
            _.Move("213C", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1213- MOVE ZEROS TO VIND-DATA-FATURA-U. */
            _.Move(0, VIND_DATA_FATURA_U);

            /*" -1220- PERFORM R2130_00_ACUMULA_IS_DB_UPDATE_2 */

            R2130_00_ACUMULA_IS_DB_UPDATE_2();

            /*" -1223- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1224- DISPLAY 'ERRO NO UPDATE MOVIMVGA ' */
                _.Display($"ERRO NO UPDATE MOVIMVGA ");

                /*" -1227- DISPLAY 'CERTIF = ' SEGURVGA-NUM-CERTIFICADO ' FONTE ' MOVIMVGA-COD-FONTE ' PROP  ' MOVIMVGA-NUM-PROPOSTA */

                $"CERTIF = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO} FONTE {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE} PROP  {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA}"
                .Display();

                /*" -1228- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1230- END-IF. */
            }


            /*" -1232- ADD 1 TO AC-U-MOVIMENTO. */
            FILLER_0.AC_U_MOVIMENTO.Value = FILLER_0.AC_U_MOVIMENTO + 1;

            /*" -1232- PERFORM R2120-00-FETCH-SEGURVGA. */

            R2120_00_FETCH_SEGURVGA_SECTION();

        }

        [StopWatch]
        /*" R2130-00-ACUMULA-IS-DB-UPDATE-1 */
        public void R2130_00_ACUMULA_IS_DB_UPDATE_1()
        {
            /*" -1199- EXEC SQL UPDATE SEGUROS.HIST_CONT_PARCELVA SET DTFATUR = :WHOST-DATA-FAT-FIM, NUM_ENDOSSO = :HISCONPA-NUM-ENDOSSO, SIT_REGISTRO = '1' WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO AND NUM_PARCELA = :WHOST-NUM-PARCELA AND COD_OPERACAO BETWEEN 200 AND 299 AND SIT_REGISTRO = '9' AND DTFATUR IS NULL END-EXEC. */

            var r2130_00_ACUMULA_IS_DB_UPDATE_1_Update1 = new R2130_00_ACUMULA_IS_DB_UPDATE_1_Update1()
            {
                HISCONPA_NUM_ENDOSSO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO.ToString(),
                WHOST_DATA_FAT_FIM = WHOST_DATA_FAT_FIM.ToString(),
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
                WHOST_NUM_PARCELA = WHOST_NUM_PARCELA.ToString(),
            };

            R2130_00_ACUMULA_IS_DB_UPDATE_1_Update1.Execute(r2130_00_ACUMULA_IS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2130_99_SAIDA*/

        [StopWatch]
        /*" R2130-00-ACUMULA-IS-DB-UPDATE-2 */
        public void R2130_00_ACUMULA_IS_DB_UPDATE_2()
        {
            /*" -1220- EXEC SQL UPDATE SEGUROS.MOVIMENTO_VGAP SET DATA_FATURA = :SISTEMAS-DATA-MOV-ABERTO :VIND-DATA-FATURA-U WHERE COD_FONTE = :MOVIMVGA-COD-FONTE AND NUM_PROPOSTA = :MOVIMVGA-NUM-PROPOSTA END-EXEC. */

            var r2130_00_ACUMULA_IS_DB_UPDATE_2_Update1 = new R2130_00_ACUMULA_IS_DB_UPDATE_2_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                VIND_DATA_FATURA_U = VIND_DATA_FATURA_U.ToString(),
                MOVIMVGA_NUM_PROPOSTA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA.ToString(),
                MOVIMVGA_COD_FONTE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE.ToString(),
            };

            R2130_00_ACUMULA_IS_DB_UPDATE_2_Update1.Execute(r2130_00_ACUMULA_IS_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R2140-00-SELECT-APOLICOB-SECTION */
        private void R2140_00_SELECT_APOLICOB_SECTION()
        {
            /*" -1249- MOVE 'R2140-00-SELECT-APOLICOB' TO PARAGRAFO. */
            _.Move("R2140-00-SELECT-APOLICOB", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1251- MOVE '2140' TO WNR-EXEC-SQL. */
            _.Move("2140", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1260- PERFORM R2140_00_SELECT_APOLICOB_DB_SELECT_1 */

            R2140_00_SELECT_APOLICOB_DB_SELECT_1();

            /*" -1263- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1264- DISPLAY 'ERRO NO SELECT APOLICE_COBERTURAS - IS' */
                _.Display($"ERRO NO SELECT APOLICE_COBERTURAS - IS");

                /*" -1265- DISPLAY 'APOLICE     = ' PROPOVA-NUM-APOLICE */
                _.Display($"APOLICE     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -1266- DISPLAY 'ITEM        = ' SEGURVGA-NUM-ITEM */
                _.Display($"ITEM        = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

                /*" -1267- DISPLAY 'OCORR HIST  = ' SEGURVGA-OCORR-HISTORICO */
                _.Display($"OCORR HIST  = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO}");

                /*" -1268- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1270- END-IF. */
            }


            /*" -1272- MOVE '2141' TO WNR-EXEC-SQL. */
            _.Move("2141", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1281- PERFORM R2140_00_SELECT_APOLICOB_DB_SELECT_2 */

            R2140_00_SELECT_APOLICOB_DB_SELECT_2();

            /*" -1284- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1285- DISPLAY 'ERRO NA APOLICE_COBERTURAS - PREMIO' */
                _.Display($"ERRO NA APOLICE_COBERTURAS - PREMIO");

                /*" -1286- DISPLAY 'APOLICE     = ' PROPOVA-NUM-APOLICE */
                _.Display($"APOLICE     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -1287- DISPLAY 'ITEM        = ' SEGURVGA-NUM-ITEM */
                _.Display($"ITEM        = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

                /*" -1288- DISPLAY 'OCORR HIST  = ' SEGURVGA-OCORR-HISTORICO */
                _.Display($"OCORR HIST  = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO}");

                /*" -1289- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1289- END-IF. */
            }


        }

        [StopWatch]
        /*" R2140-00-SELECT-APOLICOB-DB-SELECT-1 */
        public void R2140_00_SELECT_APOLICOB_DB_SELECT_1()
        {
            /*" -1260- EXEC SQL SELECT MAX(IMP_SEGURADA_IX) INTO :APOLICOB-IMP-SEGURADA-IX FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR WITH UR END-EXEC. */

            var r2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1 = new R2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = R2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1.Execute(r2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2140_99_SAIDA*/

        [StopWatch]
        /*" R2140-00-SELECT-APOLICOB-DB-SELECT-2 */
        public void R2140_00_SELECT_APOLICOB_DB_SELECT_2()
        {
            /*" -1281- EXEC SQL SELECT SUM(PRM_TARIFARIO_IX) INTO :APOLICOB-PRM-TARIFARIO-IX FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR WITH UR END-EXEC. */

            var r2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1 = new R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1.Execute(r2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);
            }


        }

        [StopWatch]
        /*" R2150-00-SELECT-APOLICES-SECTION */
        private void R2150_00_SELECT_APOLICES_SECTION()
        {
            /*" -1303- MOVE 'R2150-00-SELECT-APOLICES' TO PARAGRAFO. */
            _.Move("R2150-00-SELECT-APOLICES", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1308- MOVE '2150' TO WNR-EXEC-SQL. */
            _.Move("2150", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1311- MOVE PROPOVA-NUM-APOLICE TO WS-NUM-APOLICE-ANT. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, FILLER_0.WS_NUM_APOLICE_ANT);

            /*" -1317- PERFORM R2150_00_SELECT_APOLICES_DB_SELECT_1 */

            R2150_00_SELECT_APOLICES_DB_SELECT_1();

        }

        [StopWatch]
        /*" R2150-00-SELECT-APOLICES-DB-SELECT-1 */
        public void R2150_00_SELECT_APOLICES_DB_SELECT_1()
        {
            /*" -1317- EXEC SQL SELECT RAMO_EMISSOR INTO :APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE WITH UR END-EXEC. */

            var r2150_00_SELECT_APOLICES_DB_SELECT_1_Query1 = new R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1.Execute(r2150_00_SELECT_APOLICES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2150_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SELECT-SUBGVGAP-SECTION */
        private void R2200_00_SELECT_SUBGVGAP_SECTION()
        {
            /*" -1330- MOVE 'R2200-00-ACESSA-SUBGVGAP' TO PARAGRAFO. */
            _.Move("R2200-00-ACESSA-SUBGVGAP", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1335- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1344- PERFORM R2200_00_SELECT_SUBGVGAP_DB_SELECT_1 */

            R2200_00_SELECT_SUBGVGAP_DB_SELECT_1();

            /*" -1347- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1348- DISPLAY 'PARAGRAFO...' PARAGRAFO */
                _.Display($"PARAGRAFO...{FILLER_0.FILLER_10.WABEND.PARAGRAFO}");

                /*" -1349- DISPLAY 'APOLICE.....' SUBGVGAP-NUM-APOLICE */
                _.Display($"APOLICE.....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                /*" -1350- DISPLAY 'SUBGRUPO....' SUBGVGAP-COD-SUBGRUPO */
                _.Display($"SUBGRUPO....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                /*" -1350- END-IF. */
            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-SUBGVGAP-DB-SELECT-1 */
        public void R2200_00_SELECT_SUBGVGAP_DB_SELECT_1()
        {
            /*" -1344- EXEC SQL SELECT PERI_FATURAMENTO, TIPO_FATURAMENTO INTO :SUBGVGAP-PERI-FATURAMENTO, :SUBGVGAP-TIPO-FATURAMENTO FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO WITH UR END-EXEC. */

            var r2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 = new R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1.Execute(r2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_PERI_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO);
                _.Move(executed_1.SUBGVGAP_TIPO_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_FATURAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-SELECT-COBERPROPVA-SECTION */
        private void R2300_00_SELECT_COBERPROPVA_SECTION()
        {
            /*" -1368- MOVE 'R2300-00-SELECT-COBERPROPVA ' TO PARAGRAFO. */
            _.Move("R2300-00-SELECT-COBERPROPVA ", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1370- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1372- MOVE 'S' TO WS-COBERPROPVA. */
            _.Move("S", WS_COBERPROPVA);

            /*" -1430- PERFORM R2300_00_SELECT_COBERPROPVA_DB_SELECT_1 */

            R2300_00_SELECT_COBERPROPVA_DB_SELECT_1();

            /*" -1433- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1434- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1435- MOVE 'N' TO WS-COBERPROPVA */
                    _.Move("N", WS_COBERPROPVA);

                    /*" -1436- GO TO R2300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/ //GOTO
                    return;

                    /*" -1437- ELSE */
                }
                else
                {


                    /*" -1439- DISPLAY 'ERRO  DE ACESSO A HIS_COBER_PROPOST ' ' ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-OCORR-HISTORICO */

                    $"ERRO  DE ACESSO A HIS_COBER_PROPOST  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO}"
                    .Display();

                    /*" -1439- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2300-00-SELECT-COBERPROPVA-DB-SELECT-1 */
        public void R2300_00_SELECT_COBERPROPVA_DB_SELECT_1()
        {
            /*" -1430- EXEC SQL SELECT NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA, DATA_INIVIGENCIA + :SUBGVGAP-PERI-FATURAMENTO MONTHS, DATA_TERVIGENCIA, DATA_INIVIGENCIA + :SUBGVGAP-PERI-FATURAMENTO MONTHS - 1 DAY, IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO, OPCAO_COBERTURA, IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ , VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI , IMPSEGCDG , VLCUSTCDG , COD_USUARIO INTO :HISCOBPR-NUM-CERTIFICADO , :HISCOBPR-OCORR-HISTORICO , :HISCOBPR-DATA-INIVIGENCIA , :WHOST-DATA-INIVIGENCIA , :HISCOBPR-DATA-TERVIGENCIA , :WHOST-DATA-TERVIGENCIA, :HISCOBPR-IMPSEGUR , :HISCOBPR-QUANT-VIDAS , :HISCOBPR-IMPSEGIND , :HISCOBPR-COD-OPERACAO, :HISCOBPR-OPCAO-COBERTURA, :HISCOBPR-IMP-MORNATU , :HISCOBPR-IMPMORACID , :HISCOBPR-IMPINVPERM , :HISCOBPR-IMPAMDS , :HISCOBPR-IMPDH , :HISCOBPR-IMPDIT , :HISCOBPR-VLPREMIO , :HISCOBPR-PRMVG , :HISCOBPR-PRMAP , :HISCOBPR-QTDE-TIT-CAPITALIZ, :HISCOBPR-VAL-TIT-CAPITALIZ, :HISCOBPR-VAL-CUSTO-CAPITALI, :HISCOBPR-IMPSEGCDG , :HISCOBPR-VLCUSTCDG , :HISCOBPR-COD-USUARIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = :PROPOVA-OCORR-HISTORICO END-EXEC. */

            var r2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1 = new R2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1()
            {
                SUBGVGAP_PERI_FATURAMENTO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_OCORR_HISTORICO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1.Execute(r2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);
                _.Move(executed_1.HISCOBPR_OCORR_HISTORICO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO);
                _.Move(executed_1.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);
                _.Move(executed_1.WHOST_DATA_INIVIGENCIA, WHOST_DATA_INIVIGENCIA);
                _.Move(executed_1.HISCOBPR_DATA_TERVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);
                _.Move(executed_1.WHOST_DATA_TERVIGENCIA, WHOST_DATA_TERVIGENCIA);
                _.Move(executed_1.HISCOBPR_IMPSEGUR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);
                _.Move(executed_1.HISCOBPR_QUANT_VIDAS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS);
                _.Move(executed_1.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND);
                _.Move(executed_1.HISCOBPR_COD_OPERACAO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);
                _.Move(executed_1.HISCOBPR_OPCAO_COBERTURA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA);
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
                _.Move(executed_1.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);
                _.Move(executed_1.HISCOBPR_IMPINVPERM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);
                _.Move(executed_1.HISCOBPR_IMPAMDS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS);
                _.Move(executed_1.HISCOBPR_IMPDH, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH);
                _.Move(executed_1.HISCOBPR_IMPDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT);
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
                _.Move(executed_1.HISCOBPR_PRMVG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);
                _.Move(executed_1.HISCOBPR_PRMAP, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);
                _.Move(executed_1.HISCOBPR_QTDE_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ);
                _.Move(executed_1.HISCOBPR_VAL_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ);
                _.Move(executed_1.HISCOBPR_VAL_CUSTO_CAPITALI, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI);
                _.Move(executed_1.HISCOBPR_IMPSEGCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG);
                _.Move(executed_1.HISCOBPR_VLCUSTCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG);
                _.Move(executed_1.HISCOBPR_COD_USUARIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-SELECT-OPCAOPAGVA-SECTION */
        private void R2400_00_SELECT_OPCAOPAGVA_SECTION()
        {
            /*" -1453- MOVE 'R2400-00-SELECT-OPCAOPAGVA  ' TO PARAGRAFO. */
            _.Move("R2400-00-SELECT-OPCAOPAGVA  ", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1459- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1466- PERFORM R2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1 */

            R2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1();

            /*" -1469- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1470- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1471- MOVE 15 TO OPCPAGVI-DIA-DEBITO */
                    _.Move(15, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);

                    /*" -1472- ELSE */
                }
                else
                {


                    /*" -1474- DISPLAY 'ERRO  DE ACESSO A OPCAOPAG          ' ' ' PROPOVA-NUM-CERTIFICADO ' ' WHOST-DTINIVIG */

                    $"ERRO  DE ACESSO A OPCAOPAG           {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {WHOST_DTINIVIG}"
                    .Display();

                    /*" -1476- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1477- MOVE WHOST-DTINIVIG TO WS-DTPROXVEN. */
            _.Move(WHOST_DTINIVIG, FILLER_0.WS_DTPROXVEN);

            /*" -1478- MOVE OPCPAGVI-DIA-DEBITO TO WS-PRXDDSQL. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO, FILLER_0.WS_DTPROXVEN.WS_PRXDDSQL);

            /*" -1478- MOVE WS-DTPROXVEN TO PROPOVA-DTPROXVEN. */
            _.Move(FILLER_0.WS_DTPROXVEN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);

        }

        [StopWatch]
        /*" R2400-00-SELECT-OPCAOPAGVA-DB-SELECT-1 */
        public void R2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1()
        {
            /*" -1466- EXEC SQL SELECT DIA_DEBITO INTO :OPCPAGVI-DIA-DEBITO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_INIVIGENCIA <= :WHOST-DTINIVIG AND DATA_TERVIGENCIA >= :WHOST-DTINIVIG END-EXEC. */

            var r2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1 = new R2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
            };

            var executed_1 = R2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1.Execute(r2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-INSERT-COBERPROPVA-SECTION */
        private void R2900_00_INSERT_COBERPROPVA_SECTION()
        {
            /*" -1497- MOVE 'R2900-00-INSERT-COBERPROPVA' TO PARAGRAFO. */
            _.Move("R2900-00-INSERT-COBERPROPVA", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1499- INITIALIZE PARAMETROS. */
            _.Initialize(
                PARAMETROS
            );

            /*" -1501- MOVE SUBGVGAP-NUM-APOLICE TO LK710-APOLICE OF PARAMETROS. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, PARAMETROS.LK710_APOLICE);

            /*" -1506- MOVE SUBGVGAP-COD-SUBGRUPO TO LK710-SUBGRUPO OF PARAMETROS. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, PARAMETROS.LK710_SUBGRUPO);

            /*" -1507- IF APOLICES-RAMO-EMISSOR EQUAL PARAMRAM-RAMO-VG */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG)
            {

                /*" -1509- MOVE WHOST-IMPSEG TO LK710-PU-MORTE-NATURAL OF PARAMETROS */
                _.Move(WHOST_IMPSEG, PARAMETROS.LK710_PU_MORTE_NATURAL);

                /*" -1511- MOVE ZEROS TO LK710-PU-MORTE-ACIDENTAL OF PARAMETROS */
                _.Move(0, PARAMETROS.LK710_PU_MORTE_ACIDENTAL);

                /*" -1513- END-IF. */
            }


            /*" -1514- IF APOLICES-RAMO-EMISSOR EQUAL PARAMRAM-RAMO-AP */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP)
            {

                /*" -1516- MOVE ZEROS TO LK710-PU-MORTE-NATURAL OF PARAMETROS */
                _.Move(0, PARAMETROS.LK710_PU_MORTE_NATURAL);

                /*" -1518- MOVE WHOST-IMPSEG TO LK710-PU-MORTE-ACIDENTAL OF PARAMETROS */
                _.Move(WHOST_IMPSEG, PARAMETROS.LK710_PU_MORTE_ACIDENTAL);

                /*" -1520- END-IF. */
            }


            /*" -1522- CALL 'VG0710S' USING PARAMETROS. */
            _.Call("VG0710S", PARAMETROS);

            /*" -1523- IF LK710-RETURN-CODE NOT EQUAL ZEROS */

            if (PARAMETROS.LK710_RETURN_CODE != 00)
            {

                /*" -1524- DISPLAY '** PROBLEMA COM SUBROTINA VG0710S **' */
                _.Display($"** PROBLEMA COM SUBROTINA VG0710S **");

                /*" -1525- DISPLAY 'CERTIF. : ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIF. : {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1526- DISPLAY 'MENSAGEM DA VG0710S -> ' LK710-MENSAGEM */
                _.Display($"MENSAGEM DA VG0710S -> {PARAMETROS.LK710_MENSAGEM}");

                /*" -1528- DISPLAY 'COD.ERRO DA VG0710S -> ' LK710-RETURN-CODE */
                _.Display($"COD.ERRO DA VG0710S -> {PARAMETROS.LK710_RETURN_CODE}");

                /*" -1530- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1532- MOVE LK710-CO-MORTE-NATURAL TO HISCOBPR-IMP-MORNATU. */
            _.Move(PARAMETROS.LK710_CO_MORTE_NATURAL, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);

            /*" -1534- MOVE LK710-CO-MORTE-NATURAL TO HISCOBPR-IMPSEGIND. */
            _.Move(PARAMETROS.LK710_CO_MORTE_NATURAL, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND);

            /*" -1536- MOVE LK710-CO-MORTE-NATURAL TO HISCOBPR-IMPSEGUR. */
            _.Move(PARAMETROS.LK710_CO_MORTE_NATURAL, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);

            /*" -1538- MOVE LK710-CO-MORTE-ACIDENTAL TO HISCOBPR-IMPMORACID. */
            _.Move(PARAMETROS.LK710_CO_MORTE_ACIDENTAL, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);

            /*" -1540- MOVE LK710-CO-INV-PERMANENTE TO HISCOBPR-IMPINVPERM. */
            _.Move(PARAMETROS.LK710_CO_INV_PERMANENTE, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);

            /*" -1542- MOVE LK710-CO-ASS-MEDICA TO HISCOBPR-IMPAMDS. */
            _.Move(PARAMETROS.LK710_CO_ASS_MEDICA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS);

            /*" -1544- MOVE LK710-CO-DI-HOSPITALAR TO HISCOBPR-IMPDH. */
            _.Move(PARAMETROS.LK710_CO_DI_HOSPITALAR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH);

            /*" -1547- MOVE LK710-CO-DI-INTERNACAO TO HISCOBPR-IMPDIT. */
            _.Move(PARAMETROS.LK710_CO_DI_INTERNACAO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT);

            /*" -1549- IF HISCOBPR-IMP-MORNATU = ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU == 00)
            {

                /*" -1552- MOVE HISCOBPR-IMPMORACID TO HISCOBPR-IMPSEGIND HISCOBPR-IMPSEGUR */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);

                /*" -1553- ELSE */
            }
            else
            {


                /*" -1557- MOVE HISCOBPR-IMP-MORNATU TO HISCOBPR-IMPSEGIND HISCOBPR-IMPSEGUR. */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);
            }


            /*" -1559- MOVE 0 TO HISCOBPR-QTDE-TIT-CAPITALIZ */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ);

            /*" -1561- MOVE 0 TO HISCOBPR-VAL-TIT-CAPITALIZ */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ);

            /*" -1564- MOVE 0 TO HISCOBPR-VAL-CUSTO-CAPITALI */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI);

            /*" -1568- MOVE ZEROS TO HISCOBPR-IMPSEGCDG HISCOBPR-VLCUSTCDG. */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG);

            /*" -1570- MOVE WHOST-DTINIVIG TO HISCOBPR-DATA-INIVIGENCIA. */
            _.Move(WHOST_DTINIVIG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);

            /*" -1573- MOVE '9999-12-31' TO HISCOBPR-DATA-TERVIGENCIA. */
            _.Move("9999-12-31", HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

            /*" -1576- COMPUTE PROPOVA-OCORR-HISTORICO = PROPOVA-OCORR-HISTORICO + 1 */
            PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.Value = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO + 1;

            /*" -1580- MOVE PROPOVA-OCORR-HISTORICO TO HISCOBPR-OCORR-HISTORICO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO);

            /*" -1582- IF APOLICES-RAMO-EMISSOR EQUAL PARAMRAM-RAMO-AP */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP)
            {

                /*" -1585- MOVE 0 TO HISCOBPR-PRMVG HISCOBPR-IMP-MORNATU */
                _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);

                /*" -1587- MOVE WHOST-PRM TO HISCOBPR-PRMAP */
                _.Move(WHOST_PRM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);

                /*" -1589- END-IF. */
            }


            /*" -1591- IF APOLICES-RAMO-EMISSOR EQUAL PARAMRAM-RAMO-VG */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG)
            {

                /*" -1593- MOVE 0 TO HISCOBPR-PRMAP */
                _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);

                /*" -1595- MOVE WHOST-PRM TO HISCOBPR-PRMVG */
                _.Move(WHOST_PRM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);

                /*" -1597- END-IF. */
            }


            /*" -1600- MOVE WHOST-QTDSEG TO HISCOBPR-QUANT-VIDAS. */
            _.Move(WHOST_QTDSEG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS);

            /*" -1603- COMPUTE HISCOBPR-VLPREMIO = HISCOBPR-PRMVG + HISCOBPR-PRMAP. */
            HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP;

            /*" -1605- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1666- PERFORM R2900_00_INSERT_COBERPROPVA_DB_INSERT_1 */

            R2900_00_INSERT_COBERPROPVA_DB_INSERT_1();

            /*" -1669- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1670- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1671- MOVE 'S' TO WTEM-COBERPROPVA */
                    _.Move("S", FILLER_0.FILLER_10.WTEM_COBERPROPVA);

                    /*" -1674- DISPLAY 'JA EXISTE NA HIS_COBER_PROPOST        ..' PROPOVA-NUM-CERTIFICADO ' ' HISCOBPR-OCORR-HISTORICO ' ' HISCOBPR-DATA-INIVIGENCIA ' ' ' ' SQLCODE */

                    $"JA EXISTE NA HIS_COBER_PROPOST        ..{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO} {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA}  {DB.SQLCODE}"
                    .Display();

                    /*" -1675- ELSE */
                }
                else
                {


                    /*" -1678- DISPLAY 'PROBLEMA INSERT HIS_COBER_PROPOST     ..' PROPOVA-NUM-CERTIFICADO ' ' HISCOBPR-OCORR-HISTORICO ' ' HISCOBPR-DATA-INIVIGENCIA ' ' ' ' SQLCODE */

                    $"PROBLEMA INSERT HIS_COBER_PROPOST     ..{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO} {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA}  {DB.SQLCODE}"
                    .Display();

                    /*" -1679- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1680- ELSE */
                }

            }
            else
            {


                /*" -1682- MOVE 'N' TO WTEM-COBERPROPVA. */
                _.Move("N", FILLER_0.FILLER_10.WTEM_COBERPROPVA);
            }


            /*" -1682- ADD 1 TO AC-I-COBERPROPVA. */
            FILLER_0.AC_I_COBERPROPVA.Value = FILLER_0.AC_I_COBERPROPVA + 1;

        }

        [StopWatch]
        /*" R2900-00-INSERT-COBERPROPVA-DB-INSERT-1 */
        public void R2900_00_INSERT_COBERPROPVA_DB_INSERT_1()
        {
            /*" -1666- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI, IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT ) VALUES (:PROPOVA-NUM-CERTIFICADO, :HISCOBPR-OCORR-HISTORICO, :HISCOBPR-DATA-INIVIGENCIA, :HISCOBPR-DATA-TERVIGENCIA, :HISCOBPR-IMPSEGUR, :HISCOBPR-QUANT-VIDAS, :HISCOBPR-IMPSEGIND, :HISCOBPR-COD-OPERACAO, ' ' , :HISCOBPR-IMP-MORNATU, :HISCOBPR-IMPMORACID, :HISCOBPR-IMPINVPERM, :HISCOBPR-IMPAMDS, :HISCOBPR-IMPDH, :HISCOBPR-IMPDIT, :HISCOBPR-VLPREMIO, :HISCOBPR-PRMVG, :HISCOBPR-PRMAP, :HISCOBPR-QTDE-TIT-CAPITALIZ, :HISCOBPR-VAL-TIT-CAPITALIZ, :HISCOBPR-VAL-CUSTO-CAPITALI, :HISCOBPR-IMPSEGCDG, :HISCOBPR-VLCUSTCDG, 'VG1652B' , CURRENT TIMESTAMP, NULL, NULL, NULL, NULL) END-EXEC. */

            var r2900_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1 = new R2900_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                HISCOBPR_OCORR_HISTORICO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.ToString(),
                HISCOBPR_DATA_INIVIGENCIA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.ToString(),
                HISCOBPR_DATA_TERVIGENCIA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA.ToString(),
                HISCOBPR_IMPSEGUR = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR.ToString(),
                HISCOBPR_QUANT_VIDAS = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS.ToString(),
                HISCOBPR_IMPSEGIND = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND.ToString(),
                HISCOBPR_COD_OPERACAO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO.ToString(),
                HISCOBPR_IMP_MORNATU = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU.ToString(),
                HISCOBPR_IMPMORACID = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID.ToString(),
                HISCOBPR_IMPINVPERM = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM.ToString(),
                HISCOBPR_IMPAMDS = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS.ToString(),
                HISCOBPR_IMPDH = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH.ToString(),
                HISCOBPR_IMPDIT = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT.ToString(),
                HISCOBPR_VLPREMIO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO.ToString(),
                HISCOBPR_PRMVG = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG.ToString(),
                HISCOBPR_PRMAP = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP.ToString(),
                HISCOBPR_QTDE_TIT_CAPITALIZ = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ.ToString(),
                HISCOBPR_VAL_TIT_CAPITALIZ = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ.ToString(),
                HISCOBPR_VAL_CUSTO_CAPITALI = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI.ToString(),
                HISCOBPR_IMPSEGCDG = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG.ToString(),
                HISCOBPR_VLCUSTCDG = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG.ToString(),
            };

            R2900_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1.Execute(r2900_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R2910-00-UPDATE-COBERPROPVA-SECTION */
        private void R2910_00_UPDATE_COBERPROPVA_SECTION()
        {
            /*" -1700- MOVE 'R2910-00-UPDATE-COBERPROPVA' TO PARAGRAFO. */
            _.Move("R2910-00-UPDATE-COBERPROPVA", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1702- MOVE '2910' TO WNR-EXEC-SQL. */
            _.Move("2910", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1707- PERFORM R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1 */

            R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1();

            /*" -1710- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1712- DISPLAY '(R2910) NUM_CERTIFICADO : ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-OCORR-HISTORICO */

                $"(R2910) NUM_CERTIFICADO : {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO}"
                .Display();

                /*" -1713- DISPLAY 'ERRO  DE ACESSO A HIS_COBER_PROPOST ' */
                _.Display($"ERRO  DE ACESSO A HIS_COBER_PROPOST ");

                /*" -1715- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1717- MOVE '291A' TO WNR-EXEC-SQL. */
            _.Move("291A", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1722- PERFORM R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_2 */

            R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_2();

            /*" -1725- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1727- DISPLAY '(R2910) NUM_CERTIFICADO : ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-OCORR-HISTORICO */

                $"(R2910) NUM_CERTIFICADO : {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO}"
                .Display();

                /*" -1728- DISPLAY 'ERRO  DE ACESSO A HIS_COBER_PROPOST ' */
                _.Display($"ERRO  DE ACESSO A HIS_COBER_PROPOST ");

                /*" -1730- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1730- ADD 1 TO AC-U-COBERPROPVA. */
            FILLER_0.AC_U_COBERPROPVA.Value = FILLER_0.AC_U_COBERPROPVA + 1;

        }

        [StopWatch]
        /*" R2910-00-UPDATE-COBERPROPVA-DB-UPDATE-1 */
        public void R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1()
        {
            /*" -1707- EXEC SQL UPDATE SEGUROS.HIS_COBER_PROPOST SET DATA_TERVIGENCIA = :WHOST-DTINIVIG WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = :PROPOVA-OCORR-HISTORICO END-EXEC. */

            var r2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1 = new R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1()
            {
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_OCORR_HISTORICO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.ToString(),
            };

            R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1.Execute(r2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2910_99_SAIDA*/

        [StopWatch]
        /*" R2910-00-UPDATE-COBERPROPVA-DB-UPDATE-2 */
        public void R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_2()
        {
            /*" -1722- EXEC SQL UPDATE SEGUROS.HIS_COBER_PROPOST SET DATA_TERVIGENCIA = DATA_TERVIGENCIA - 1 DAY WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = :PROPOVA-OCORR-HISTORICO END-EXEC. */

            var r2910_00_UPDATE_COBERPROPVA_DB_UPDATE_2_Update1 = new R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_2_Update1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_OCORR_HISTORICO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.ToString(),
            };

            R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_2_Update1.Execute(r2910_00_UPDATE_COBERPROPVA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R2920-00-UPDATE-PROPOSTAVA-SECTION */
        private void R2920_00_UPDATE_PROPOSTAVA_SECTION()
        {
            /*" -1748- MOVE 'R2920-00-UPDATE-PROPOSTAVA ' TO PARAGRAFO. */
            _.Move("R2920-00-UPDATE-PROPOSTAVA ", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1750- MOVE '2920' TO WNR-EXEC-SQL. */
            _.Move("2920", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1755- PERFORM R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1 */

            R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1();

            /*" -1758- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1760- DISPLAY 'ERRO  UPDATE PROPOSTAS_VA ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"ERRO  UPDATE PROPOSTAS_VA {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1760- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2920-00-UPDATE-PROPOSTAVA-DB-UPDATE-1 */
        public void R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1()
        {
            /*" -1755- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET OCORR_HISTORICO = :HISCOBPR-OCORR-HISTORICO, DTPROXVEN = :PROPOVA-DTPROXVEN WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1 = new R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1()
            {
                HISCOBPR_OCORR_HISTORICO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.ToString(),
                PROPOVA_DTPROXVEN = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1.Execute(r2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2920_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-FINALIZA-SECTION */
        private void R9000_00_FINALIZA_SECTION()
        {
            /*" -1774- MOVE 'R9000-00-FINALIZA' TO PARAGRAFO. */
            _.Move("R9000-00-FINALIZA", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1778- MOVE '8100' TO WNR-EXEC-SQL */
            _.Move("8100", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1780- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1781- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -1782- DISPLAY 'PROGRAMA VG1652B ' */
            _.Display($"PROGRAMA VG1652B ");

            /*" -1783- DISPLAY 'TOTAIS PARA CONTROLE ' */
            _.Display($"TOTAIS PARA CONTROLE ");

            /*" -1784- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -1785- DISPLAY 'LIDOS DA PROPOSTAVA                 = ' AC-LIDOS-M */
            _.Display($"LIDOS DA PROPOSTAVA                 = {FILLER_0.AC_LIDOS_M}");

            /*" -1786- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -1787- DISPLAY ' .INCLUSOES                           ' */
            _.Display($" .INCLUSOES                           ");

            /*" -1789- DISPLAY '   COBERPROPVA                      = ' AC-I-COBERPROPVA. */
            _.Display($"   COBERPROPVA                      = {FILLER_0.AC_I_COBERPROPVA}");

            /*" -1790- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -1791- DISPLAY ' .ATUALIZACOES                        ' */
            _.Display($" .ATUALIZACOES                        ");

            /*" -1793- DISPLAY '   COBERPROPVA                      = ' AC-U-COBERPROPVA. */
            _.Display($"   COBERPROPVA                      = {FILLER_0.AC_U_COBERPROPVA}");

            /*" -1795- DISPLAY '   HISTCONTABILVA                   = ' AC-U-HISTCONTABILVA. */
            _.Display($"   HISTCONTABILVA                   = {FILLER_0.AC_U_HISTCONTABILVA}");

            /*" -1797- DISPLAY '   MOVIMENTO_VGAP                   = ' AC-U-MOVIMENTO. */
            _.Display($"   MOVIMENTO_VGAP                   = {FILLER_0.AC_U_MOVIMENTO}");

            /*" -1798- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -1799- DISPLAY ' .ESTATISTICAS                        ' */
            _.Display($" .ESTATISTICAS                        ");

            /*" -1800- DISPLAY '   PARCELAS JA PAGAS                = ' AC-PAGOS */
            _.Display($"   PARCELAS JA PAGAS                = {FILLER_0.AC_PAGOS}");

            /*" -1802- DISPLAY '   PARCELAS COM PREMIO IGUAL        = ' AC-PREMIO-IGUAL */
            _.Display($"   PARCELAS COM PREMIO IGUAL        = {FILLER_0.AC_PREMIO_IGUAL}");

            /*" -1804- DISPLAY '   PARCELAS COM PREMIO AJUSTADO     = ' AC-PREMIO-AJUSTADO */
            _.Display($"   PARCELAS COM PREMIO AJUSTADO     = {FILLER_0.AC_PREMIO_AJUSTADO}");

            /*" -1806- DISPLAY '   DESPREZADOS VIGENCIA             = ' AC-DESPREZ-VIG */
            _.Display($"   DESPREZADOS VIGENCIA             = {FILLER_0.AC_DESPREZ_VIG}");

            /*" -1809- DISPLAY '   DESPREZADOS TIPO FATURAMENTO     = ' AC-DESPREZ-FAT-MANU */
            _.Display($"   DESPREZADOS TIPO FATURAMENTO     = {FILLER_0.AC_DESPREZ_FAT_MANU}");

            /*" -1810- DISPLAY '-------------------------------------' */
            _.Display($"-------------------------------------");

            /*" -1811- DISPLAY ' ' */
            _.Display($" ");

            /*" -1813- DISPLAY ' *** VG1652B - FIM NORMAL ' . */
            _.Display($" *** VG1652B - FIM NORMAL ");

            /*" -1813- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1815- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1827- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FILLER_0.WDATA_REL);

            /*" -1828- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(FILLER_0.FILLER_20.WDAT_REL_DIA, FILLER_0.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -1829- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(FILLER_0.FILLER_20.WDAT_REL_MES, FILLER_0.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -1830- MOVE WDAT-REL-SEC TO WDAT-LIT-SEC */
            _.Move(FILLER_0.FILLER_20.WDAT_REL_SEC, FILLER_0.WDAT_REL_LIT.WDAT_LIT_SEC);

            /*" -1832- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(FILLER_0.FILLER_20.WDAT_REL_ANO, FILLER_0.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -1833- DISPLAY '*--------------------------------------------*' */
            _.Display($"*--------------------------------------------*");

            /*" -1834- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1835- DISPLAY '*  VG1652B - CONSISTENCIA LOGICA MOVIMENTO   *' */
            _.Display($"*  VG1652B - CONSISTENCIA LOGICA MOVIMENTO   *");

            /*" -1836- DISPLAY '*  -------   ------------ ------ ---------   *' */
            _.Display($"*  -------   ------------ ------ ---------   *");

            /*" -1837- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1838- DISPLAY '*     NAO HOUVE MOVIMENTACAO NESTA DATA      *' */
            _.Display($"*     NAO HOUVE MOVIMENTACAO NESTA DATA      *");

            /*" -1840- DISPLAY '*               ' WDAT-REL-LIT '            *' '*                                            *' */

            $"*               {FILLER_0.WDAT_REL_LIT}            **                                            *"
            .Display();

            /*" -1841- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1841- DISPLAY '*--------------------------------------------*' . */
            _.Display($"*--------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1853- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1854- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, FILLER_0.FILLER_10.WABEND.WSQLCODE);

                /*" -1855- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], FILLER_0.FILLER_10.WABEND.WSQLCODE1);

                /*" -1856- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], FILLER_0.FILLER_10.WABEND.WSQLCODE2);

                /*" -1857- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, FILLER_0.WSQLCODE3);

                /*" -1858- DISPLAY WABEND */
                _.Display(FILLER_0.FILLER_10.WABEND);

                /*" -1859- MOVE SQLERRMC TO WSQLERRMC */
                _.Move(DB.SQLERRMC, FILLER_0.FILLER_10.WSQLERRO.WSQLERRMC);

                /*" -1860- DISPLAY WSQLERRO */
                _.Display(FILLER_0.FILLER_10.WSQLERRO);

                /*" -1861- DISPLAY SPACES */
                _.Display($"");

                /*" -1862- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), FILLER_0.WS_TIME);

                /*" -1864- DISPLAY 'LIDOS MOVIMENTO   ' AC-LIDOS-M ' ' WS-TIME. */

                $"LIDOS MOVIMENTO   {FILLER_0.AC_LIDOS_M} {FILLER_0.WS_TIME}"
                .Display();
            }


            /*" -1866- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1870- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1874- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1874- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}