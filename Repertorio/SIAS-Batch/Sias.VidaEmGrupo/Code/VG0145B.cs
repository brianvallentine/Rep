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
using Sias.VidaEmGrupo.DB2.VG0145B;

namespace Code
{
    public class VG0145B
    {
        public bool IsCall { get; set; }

        public VG0145B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------  ---------                                              */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ................  VG - VIDA EM GRUPO (SEGURO VIAGEM) *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG0145B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA................  EDIVALDO GOMES                     *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  EDIVALDO GOMES                     *      */
        /*"      *                                                                *      */
        /*"      *   DATA CODIFICACAO .......  OUTUBRO/2010                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  FATURAMENTO DO PRODUTO SEGURO VIA- *      */
        /*"      *                             GEM DESTINADO A BRASIL ASSISTENCIA.*      */
        /*"      *                                                                *      */
        /*"      *   CADMUS .................  49.010                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WS-IND-2                      PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_IND_2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-JA-TEM-CODIGO              PIC  X(001)    VALUE 'N'.*/
        public StringBasis WS_JA_TEM_CODIGO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  WS-MOVTO-H-DATA-REFER         PIC  9(006)    VALUE  0.*/
        public IntBasis WS_MOVTO_H_DATA_REFER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77  WS-NUM-APOLICE                PIC S9(013)    VALUE +0 COMP-3*/
        public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  WS-COD-SUBGRUPO               PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-FLAG-HEADER                PIC  X(001).*/
        public StringBasis WS_FLAG_HEADER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WS-FLAG-TRAILER               PIC  X(001).*/
        public StringBasis WS_FLAG_TRAILER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WHOST-QTDSEG                  PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTDSEG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-OCORR-END-I             PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_OCORR_END_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-OCORR-END-F             PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_OCORR_END_F { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-OCOR-HISTORICO          PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_OCOR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-SIT-PROPOVA             PIC  X(010).*/
        public StringBasis WHOST_SIT_PROPOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"77  WHOST-PRMAP                   PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
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
        /*"77  WHOST-DATA-80ANOS             PIC  X(010).*/
        public StringBasis WHOST_DATA_80ANOS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-NASCIMENTO         PIC  X(010).*/
        public StringBasis WHOST_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-ADESAO             PIC  9(008).*/
        public IntBasis WHOST_DATA_ADESAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
        /*"77  WHOST-DATA-FINANCIAMENTO      PIC  X(010).*/
        public StringBasis WHOST_DATA_FINANCIAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-MAX-DTMOVTO             PIC  X(010).*/
        public StringBasis WHOST_MAX_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-MAX-DTREFER             PIC  X(010).*/
        public StringBasis WHOST_MAX_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        public StringBasis WHOST_DATA_NASCIMENTO_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-TIPO-SEGURADO           PIC  X(001).*/
        public StringBasis WHOST_TIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WHOST-APOLICE                 PIC S9(013)    VALUE +0 COMP-3*/
        public IntBasis WHOST_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  WHOST-SUBGRUPO                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-NRCERTIF-PARC           PIC S9(015)    VALUE +0 COMP-3*/
        public IntBasis WHOST_NRCERTIF_PARC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-NRCERTIF                PIC S9(015)    VALUE +0 COMP-3*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-NRCERTIF-PCP            PIC S9(015)    VALUE +0 COMP-3*/
        public IntBasis WHOST_NRCERTIF_PCP { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-NRCERTIF-MOV            PIC S9(015)    VALUE +0 COMP-3*/
        public IntBasis WHOST_NRCERTIF_MOV { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-NRCERTIF-PROP           PIC S9(015)    VALUE +0 COMP-3*/
        public IntBasis WHOST_NRCERTIF_PROP { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-QTDE                    PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-QUANTIDADE              PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_QUANTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-QTDE-SEGVG              PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTDE_SEGVG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-GRUPO                   PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_GRUPO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-COTA                    PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_COTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
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
        /*"77  WHOST-PREMIO-VG               PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_PREMIO_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-IMP-MORNATU             PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_IMP_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
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
        /*"   01       WRETORNO-REG.*/
        public VG0145B_WRETORNO_REG WRETORNO_REG { get; set; } = new VG0145B_WRETORNO_REG();
        public class VG0145B_WRETORNO_REG : VarBasis
        {
            /*"    10      WRETORNO-NOME       PIC  X(040).*/
            public StringBasis WRETORNO_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    10      WRETORNO-CPF        PIC  9(014).*/
            public IntBasis WRETORNO_CPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    10      WRETORNO-CONTRATO   PIC  9(008).*/
            public IntBasis WRETORNO_CONTRATO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    10      WRETORNO-GRUPO      PIC  9(006).*/
            public IntBasis WRETORNO_GRUPO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    10      WRETORNO-COTA       PIC  9(003).*/
            public IntBasis WRETORNO_COTA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    10      WRETORNO-MENSAGEM   PIC  X(040).*/
            public StringBasis WRETORNO_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"01          FILLER.*/
        }
        public VG0145B_FILLER_0 FILLER_0 { get; set; } = new VG0145B_FILLER_0();
        public class VG0145B_FILLER_0 : VarBasis
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
            /*"  03        AC-U-OPCAOPAGVA     PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_OPCAOPAGVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-U-PARCELVA       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_PARCELVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-U-HISTCOBVA      PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_HISTCOBVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-I-PARCELVA       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_PARCELVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-I-HISTCOBVA      PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_HISTCOBVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-I-HISTCTABI      PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_HISTCTABI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-DESPREZ-VIG      PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_DESPREZ_VIG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-ERRO       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_ERRO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-M          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_M { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-E          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_E { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-C          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_C { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-D          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_D { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-B          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_B { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-1          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-2          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_2 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-3          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_3 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-4          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_4 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-5          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_5 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-6          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_6 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-7          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_7 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-8          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_8 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-9          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_9 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-10         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_10 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-11         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_11 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        WS-EOF1             PIC  9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03        WS-EOF2             PIC  9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03        QTMES               PIC S9(005) COMP-3   VALUE +0.*/
            public IntBasis QTMES { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03        RESTO               PIC S9(005) COMP-3   VALUE +0.*/
            public IntBasis RESTO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
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
            /*"  03            WS-SIT-REGISTRO     PIC  X(001).*/
            public StringBasis WS_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03            WS-UPDATE           PIC  X(001) VALUE 'N'.*/
            public StringBasis WS_UPDATE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WS-TIME             PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03            WS-W01DTSQL.*/
            public VG0145B_WS_W01DTSQL WS_W01DTSQL { get; set; } = new VG0145B_WS_W01DTSQL();
            public class VG0145B_WS_W01DTSQL : VarBasis
            {
                /*"    05          WS-W01SCSQL         PIC  9(002).*/
                public IntBasis WS_W01SCSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W01AASQL         PIC  9(002).*/
                public IntBasis WS_W01AASQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W01T1SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W01MMSQL         PIC  9(002).*/
                public IntBasis WS_W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W01T2SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W01DDSQL         PIC  9(002).*/
                public IntBasis WS_W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-W02DTSQL.*/
            }
            public VG0145B_WS_W02DTSQL WS_W02DTSQL { get; set; } = new VG0145B_WS_W02DTSQL();
            public class VG0145B_WS_W02DTSQL : VarBasis
            {
                /*"    05          WS-W02AASQL         PIC  9(004).*/
                public IntBasis WS_W02AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-W02T1SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W02T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W02MMSQL         PIC  9(002).*/
                public IntBasis WS_W02MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W02T2SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W02T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W02DDSQL         PIC  9(002).*/
                public IntBasis WS_W02DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-W03DTSQL.*/
            }
            public VG0145B_WS_W03DTSQL WS_W03DTSQL { get; set; } = new VG0145B_WS_W03DTSQL();
            public class VG0145B_WS_W03DTSQL : VarBasis
            {
                /*"    05          WS-W03AASQL         PIC  9(004).*/
                public IntBasis WS_W03AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-W03T1SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W03T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W03MMSQL         PIC  9(002).*/
                public IntBasis WS_W03MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W03T2SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W03T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W03DDSQL         PIC  9(002).*/
                public IntBasis WS_W03DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-W05DTREF.*/
            }
            public VG0145B_WS_W05DTREF WS_W05DTREF { get; set; } = new VG0145B_WS_W05DTREF();
            public class VG0145B_WS_W05DTREF : VarBasis
            {
                /*"    05          WS-W05AAREF         PIC  9(004).*/
                public IntBasis WS_W05AAREF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-W05MMREF         PIC  9(002).*/
                public IntBasis WS_W05MMREF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W05DDREF         PIC  9(002).*/
                public IntBasis WS_W05DDREF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-W02DTSQL-GERA.*/
            }
            public VG0145B_WS_W02DTSQL_GERA WS_W02DTSQL_GERA { get; set; } = new VG0145B_WS_W02DTSQL_GERA();
            public class VG0145B_WS_W02DTSQL_GERA : VarBasis
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
            public VG0145B_WK_DATA1 WK_DATA1 { get; set; } = new VG0145B_WK_DATA1();
            public class VG0145B_WK_DATA1 : VarBasis
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
            private _REDEF_VG0145B_WS_DATA_ADESAO_R _ws_data_adesao_r { get; set; }
            public _REDEF_VG0145B_WS_DATA_ADESAO_R WS_DATA_ADESAO_R
            {
                get { _ws_data_adesao_r = new _REDEF_VG0145B_WS_DATA_ADESAO_R(); _.Move(WS_DATA_ADESAO, _ws_data_adesao_r); VarBasis.RedefinePassValue(WS_DATA_ADESAO, _ws_data_adesao_r, WS_DATA_ADESAO); _ws_data_adesao_r.ValueChanged += () => { _.Move(_ws_data_adesao_r, WS_DATA_ADESAO); }; return _ws_data_adesao_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_adesao_r, WS_DATA_ADESAO); }
            }  //Redefines
            public class _REDEF_VG0145B_WS_DATA_ADESAO_R : VarBasis
            {
                /*"    10          WS-ANO-ADESAO     PIC  9(004).*/
                public IntBasis WS_ANO_ADESAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10          WS-MES-ADESAO     PIC  9(002).*/
                public IntBasis WS_MES_ADESAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          WS-DIA-ADESAO     PIC  9(002).*/
                public IntBasis WS_DIA_ADESAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-DATA-AUX.*/

                public _REDEF_VG0145B_WS_DATA_ADESAO_R()
                {
                    WS_ANO_ADESAO.ValueChanged += OnValueChanged;
                    WS_MES_ADESAO.ValueChanged += OnValueChanged;
                    WS_DIA_ADESAO.ValueChanged += OnValueChanged;
                }

            }
            public VG0145B_WS_DATA_AUX WS_DATA_AUX { get; set; } = new VG0145B_WS_DATA_AUX();
            public class VG0145B_WS_DATA_AUX : VarBasis
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
            public VG0145B_WS_DATA_INICIAL WS_DATA_INICIAL { get; set; } = new VG0145B_WS_DATA_INICIAL();
            public class VG0145B_WS_DATA_INICIAL : VarBasis
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
            public VG0145B_WS_DATA_FINAL WS_DATA_FINAL { get; set; } = new VG0145B_WS_DATA_FINAL();
            public class VG0145B_WS_DATA_FINAL : VarBasis
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
            public VG0145B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VG0145B_WS_DATA_SQL();
            public class VG0145B_WS_DATA_SQL : VarBasis
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
            public VG0145B_WS_DATA WS_DATA { get; set; } = new VG0145B_WS_DATA();
            public class VG0145B_WS_DATA : VarBasis
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
            private _REDEF_VG0145B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VG0145B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VG0145B_FILLER_5(); _.Move(W01GRUPOCOTA, _filler_5); VarBasis.RedefinePassValue(W01GRUPOCOTA, _filler_5, W01GRUPOCOTA); _filler_5.ValueChanged += () => { _.Move(_filler_5, W01GRUPOCOTA); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, W01GRUPOCOTA); }
            }  //Redefines
            public class _REDEF_VG0145B_FILLER_5 : VarBasis
            {
                /*"    10       W01-GRUPO         PIC  9(006).*/
                public IntBasis W01_GRUPO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       W01-COTA          PIC  9(003).*/
                public IntBasis W01_COTA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"  03         W01DTCSP          PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG0145B_FILLER_5()
                {
                    W01_GRUPO.ValueChanged += OnValueChanged;
                    W01_COTA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W01DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      W01DTCSP.*/
            private _REDEF_VG0145B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_VG0145B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_VG0145B_FILLER_6(); _.Move(W01DTCSP, _filler_6); VarBasis.RedefinePassValue(W01DTCSP, _filler_6, W01DTCSP); _filler_6.ValueChanged += () => { _.Move(_filler_6, W01DTCSP); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, W01DTCSP); }
            }  //Redefines
            public class _REDEF_VG0145B_FILLER_6 : VarBasis
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

                public _REDEF_VG0145B_FILLER_6()
                {
                    W01DDCSP.ValueChanged += OnValueChanged;
                    W01MMCSP.ValueChanged += OnValueChanged;
                    W01SCCSP.ValueChanged += OnValueChanged;
                    W01AACSP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W02DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      W02DTCSP.*/
            private _REDEF_VG0145B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_VG0145B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_VG0145B_FILLER_7(); _.Move(W02DTCSP, _filler_7); VarBasis.RedefinePassValue(W02DTCSP, _filler_7, W02DTCSP); _filler_7.ValueChanged += () => { _.Move(_filler_7, W02DTCSP); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, W02DTCSP); }
            }  //Redefines
            public class _REDEF_VG0145B_FILLER_7 : VarBasis
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

                public _REDEF_VG0145B_FILLER_7()
                {
                    W02DDCSP.ValueChanged += OnValueChanged;
                    W02MMCSP.ValueChanged += OnValueChanged;
                    W02SCCSP.ValueChanged += OnValueChanged;
                    W02AACSP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DTREF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03         FILLER            REDEFINES      WS-DTREF.*/
            private _REDEF_VG0145B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_VG0145B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_VG0145B_FILLER_8(); _.Move(WS_DTREF, _filler_8); VarBasis.RedefinePassValue(WS_DTREF, _filler_8, WS_DTREF); _filler_8.ValueChanged += () => { _.Move(_filler_8, WS_DTREF); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WS_DTREF); }
            }  //Redefines
            public class _REDEF_VG0145B_FILLER_8 : VarBasis
            {
                /*"    10       WS-REF-ANO        PIC  9(004).*/
                public IntBasis WS_REF_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS-REF-MES        PIC  9(002).*/
                public IntBasis WS_REF_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-DTREF-SQL      PIC  X(010).*/

                public _REDEF_VG0145B_FILLER_8()
                {
                    WS_REF_ANO.ValueChanged += OnValueChanged;
                    WS_REF_MES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DTREF_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03         FILLER            REDEFINES      WS-DTREF-SQL.*/
            private _REDEF_VG0145B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_VG0145B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_VG0145B_FILLER_9(); _.Move(WS_DTREF_SQL, _filler_9); VarBasis.RedefinePassValue(WS_DTREF_SQL, _filler_9, WS_DTREF_SQL); _filler_9.ValueChanged += () => { _.Move(_filler_9, WS_DTREF_SQL); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, WS_DTREF_SQL); }
            }  //Redefines
            public class _REDEF_VG0145B_FILLER_9 : VarBasis
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

                public _REDEF_VG0145B_FILLER_9()
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
            /*"  03        AC-EMITIDOS              PIC  9(007) VALUE 0.*/
            public IntBasis AC_EMITIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-SOLICITADOS           PIC  9(007) VALUE 0.*/
            public IntBasis AC_SOLICITADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-LIDOS                  PIC  9(007) VALUE 0.*/
            public IntBasis W_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        WAC-LIDOS                PIC  9(007) VALUE 0.*/
            public IntBasis WAC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-GRAVADOS               PIC  9(007) VALUE 0.*/
            public IntBasis W_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        FILLER.*/
            public VG0145B_FILLER_10 FILLER_10 { get; set; } = new VG0145B_FILLER_10();
            public class VG0145B_FILLER_10 : VarBasis
            {
                /*"    05      WTEM-PARCEVID            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_PARCEVID { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-HISCOBPR            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_HISCOBPR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
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
                public VG0145B_WABEND WABEND { get; set; } = new VG0145B_WABEND();
                public class VG0145B_WABEND : VarBasis
                {
                    /*"      05      FILLER              PIC  X(010) VALUE             ' VG0145B'.*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0145B");
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
                public VG0145B_WSQLERRO WSQLERRO { get; set; } = new VG0145B_WSQLERRO();
                public class VG0145B_WSQLERRO : VarBasis
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
            private _REDEF_VG0145B_FILLER_18 _filler_18 { get; set; }
            public _REDEF_VG0145B_FILLER_18 FILLER_18
            {
                get { _filler_18 = new _REDEF_VG0145B_FILLER_18(); _.Move(W_NUMR_TITULO, _filler_18); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_18, W_NUMR_TITULO); _filler_18.ValueChanged += () => { _.Move(_filler_18, W_NUMR_TITULO); }; return _filler_18; }
                set { VarBasis.RedefinePassValue(value, _filler_18, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_VG0145B_FILLER_18 : VarBasis
            {
                /*"      05    WTITL-ZEROS              PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05    WTITL-SEQUENCIA          PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05    WTITL-DIGITO             PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03  DPARM01X.*/

                public _REDEF_VG0145B_FILLER_18()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public VG0145B_DPARM01X DPARM01X { get; set; } = new VG0145B_DPARM01X();
            public class VG0145B_DPARM01X : VarBasis
            {
                /*"      05            DPARM01          PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05            DPARM01-R        REDEFINES   DPARM01.*/
                private _REDEF_VG0145B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_VG0145B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_VG0145B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_VG0145B_DPARM01_R : VarBasis
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

                    public _REDEF_VG0145B_DPARM01_R()
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
            public VG0145B_FILLER_19 FILLER_19 { get; set; } = new VG0145B_FILLER_19();
            public class VG0145B_FILLER_19 : VarBasis
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
            private _REDEF_VG0145B_FILLER_20 _filler_20 { get; set; }
            public _REDEF_VG0145B_FILLER_20 FILLER_20
            {
                get { _filler_20 = new _REDEF_VG0145B_FILLER_20(); _.Move(WDATA_REL, _filler_20); VarBasis.RedefinePassValue(WDATA_REL, _filler_20, WDATA_REL); _filler_20.ValueChanged += () => { _.Move(_filler_20, WDATA_REL); }; return _filler_20; }
                set { VarBasis.RedefinePassValue(value, _filler_20, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VG0145B_FILLER_20 : VarBasis
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

                public _REDEF_VG0145B_FILLER_20()
                {
                    WDAT_REL_SEC.ValueChanged += OnValueChanged;
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_21.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_22.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VG0145B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VG0145B_WDAT_REL_LIT();
            public class VG0145B_WDAT_REL_LIT : VarBasis
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
            private _REDEF_VG0145B_FILLER_25 _filler_25 { get; set; }
            public _REDEF_VG0145B_FILLER_25 FILLER_25
            {
                get { _filler_25 = new _REDEF_VG0145B_FILLER_25(); _.Move(WDATA_ALTERACAO, _filler_25); VarBasis.RedefinePassValue(WDATA_ALTERACAO, _filler_25, WDATA_ALTERACAO); _filler_25.ValueChanged += () => { _.Move(_filler_25, WDATA_ALTERACAO); }; return _filler_25; }
                set { VarBasis.RedefinePassValue(value, _filler_25, WDATA_ALTERACAO); }
            }  //Redefines
            public class _REDEF_VG0145B_FILLER_25 : VarBasis
            {
                /*"    10       WCOR-ANO.*/
                public VG0145B_WCOR_ANO WCOR_ANO { get; set; } = new VG0145B_WCOR_ANO();
                public class VG0145B_WCOR_ANO : VarBasis
                {
                    /*"      15     WCOR-ANOS         PIC  9(002).*/
                    public IntBasis WCOR_ANOS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     WCOR-ANOA         PIC  9(002).*/
                    public IntBasis WCOR_ANOA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       WCOR-BR1          PIC  X(001).*/

                    public VG0145B_WCOR_ANO()
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
                /*"  03         WDATA-RETORNO     PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG0145B_FILLER_25()
                {
                    WCOR_ANO.ValueChanged += OnValueChanged;
                    WCOR_BR1.ValueChanged += OnValueChanged;
                    WCOR_MES.ValueChanged += OnValueChanged;
                    WCOR_BR2.ValueChanged += OnValueChanged;
                    WCOR_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATA_RETORNO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      WDATA-RETORNO.*/
            private _REDEF_VG0145B_FILLER_26 _filler_26 { get; set; }
            public _REDEF_VG0145B_FILLER_26 FILLER_26
            {
                get { _filler_26 = new _REDEF_VG0145B_FILLER_26(); _.Move(WDATA_RETORNO, _filler_26); VarBasis.RedefinePassValue(WDATA_RETORNO, _filler_26, WDATA_RETORNO); _filler_26.ValueChanged += () => { _.Move(_filler_26, WDATA_RETORNO); }; return _filler_26; }
                set { VarBasis.RedefinePassValue(value, _filler_26, WDATA_RETORNO); }
            }  //Redefines
            public class _REDEF_VG0145B_FILLER_26 : VarBasis
            {
                /*"    10       WRET-DIA          PIC  9(002).*/
                public IntBasis WRET_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WRET-MES          PIC  9(002).*/
                public IntBasis WRET_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WRET-SEC          PIC  9(002).*/
                public IntBasis WRET_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WRET-ANO          PIC  9(002).*/
                public IntBasis WRET_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-PARAMETRO   PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG0145B_FILLER_26()
                {
                    WRET_DIA.ValueChanged += OnValueChanged;
                    WRET_MES.ValueChanged += OnValueChanged;
                    WRET_SEC.ValueChanged += OnValueChanged;
                    WRET_ANO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATA_PARAMETRO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      WDATA-PARAMETRO.*/
            private _REDEF_VG0145B_FILLER_27 _filler_27 { get; set; }
            public _REDEF_VG0145B_FILLER_27 FILLER_27
            {
                get { _filler_27 = new _REDEF_VG0145B_FILLER_27(); _.Move(WDATA_PARAMETRO, _filler_27); VarBasis.RedefinePassValue(WDATA_PARAMETRO, _filler_27, WDATA_PARAMETRO); _filler_27.ValueChanged += () => { _.Move(_filler_27, WDATA_PARAMETRO); }; return _filler_27; }
                set { VarBasis.RedefinePassValue(value, _filler_27, WDATA_PARAMETRO); }
            }  //Redefines
            public class _REDEF_VG0145B_FILLER_27 : VarBasis
            {
                /*"    10       WPAR-DIA          PIC  9(002).*/
                public IntBasis WPAR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WPAR-MES          PIC  9(002).*/
                public IntBasis WPAR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WPAR-SEC          PIC  9(002).*/
                public IntBasis WPAR_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WPAR-ANO          PIC  9(002).*/
                public IntBasis WPAR_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        CHAVE-MOVIMENTO.*/

                public _REDEF_VG0145B_FILLER_27()
                {
                    WPAR_DIA.ValueChanged += OnValueChanged;
                    WPAR_MES.ValueChanged += OnValueChanged;
                    WPAR_SEC.ValueChanged += OnValueChanged;
                    WPAR_ANO.ValueChanged += OnValueChanged;
                }

            }
            public VG0145B_CHAVE_MOVIMENTO CHAVE_MOVIMENTO { get; set; } = new VG0145B_CHAVE_MOVIMENTO();
            public class VG0145B_CHAVE_MOVIMENTO : VarBasis
            {
                /*"    10      CH-MATRIC-MOV       PIC  9(015)  VALUE ZEROS.*/
                public IntBasis CH_MATRIC_MOV { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"  03        CHAVE-SEGURADO.*/
            }
            public VG0145B_CHAVE_SEGURADO CHAVE_SEGURADO { get; set; } = new VG0145B_CHAVE_SEGURADO();
            public class VG0145B_CHAVE_SEGURADO : VarBasis
            {
                /*"    10      CH-MATRIC-SEG       PIC  9(015)  VALUE ZEROS.*/
                public IntBasis CH_MATRIC_SEG { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"01    WS-HORAS.*/
            }
        }
        public VG0145B_WS_HORAS WS_HORAS { get; set; } = new VG0145B_WS_HORAS();
        public class VG0145B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VG0145B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VG0145B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VG0145B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VG0145B_WS_HORA_INI_R : VarBasis
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

                public _REDEF_VG0145B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VG0145B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VG0145B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VG0145B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VG0145B_WS_HORA_FIM_R : VarBasis
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

                public _REDEF_VG0145B_WS_HORA_FIM_R()
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
        public VG0145B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VG0145B_TOTAIS_ROT();
        public class VG0145B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<VG0145B_FILLER_28> FILLER_28 { get; set; } = new ListBasis<VG0145B_FILLER_28>(50);
            public class VG0145B_FILLER_28 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"  01        LK-LINK.*/
                public VG0145B_LK_LINK LK_LINK { get; set; } = new VG0145B_LK_LINK();
                public class VG0145B_LK_LINK : VarBasis
                {
                    /*"      05     LK-DATA1          PIC  9(008).*/
                    public IntBasis LK_DATA1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"      05     LK-DATA2          PIC  9(008).*/
                    public IntBasis LK_DATA2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"      05     QTDIA             PIC S9(005)          COMP-3.*/
                    public IntBasis QTDIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                    /*"  01         WPROSOMD2.*/
                }
                public VG0145B_WPROSOMD2 WPROSOMD2 { get; set; } = new VG0145B_WPROSOMD2();
                public class VG0145B_WPROSOMD2 : VarBasis
                {
                    /*"    05       WDATA-INFORMADA   PIC  9(008).*/
                }
            }
            public IntBasis WDATA_INFORMADA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05       WDATA-QTDIAS      PIC S9(005)    COMP-3.*/
            public IntBasis WDATA_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"    05       WDATA-CALCULO     PIC  9(008).*/
            public IntBasis WDATA_CALCULO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  01        PARAMETROS-702.*/
            public VG0145B_PARAMETROS_702 PARAMETROS_702 { get; set; } = new VG0145B_PARAMETROS_702();
            public class VG0145B_PARAMETROS_702 : VarBasis
            {
                /*"    10      LK-APOLICE               PIC S9(013) COMP-3.*/
                public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                /*"    10      LK-SUBGRUPO              PIC S9(004) COMP.*/
                public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10      LK-IDADE                 PIC S9(004) COMP.*/
                public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10      LK-NASCIMENTO.*/
                public VG0145B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VG0145B_LK_NASCIMENTO();
                public class VG0145B_LK_NASCIMENTO : VarBasis
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
        public VG0145B_WS_MOVTO_CLIENTE WS_MOVTO_CLIENTE { get; set; } = new VG0145B_WS_MOVTO_CLIENTE();
        public class VG0145B_WS_MOVTO_CLIENTE : VarBasis
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
        public VG0145B_WS_PARAMETROS WS_PARAMETROS { get; set; } = new VG0145B_WS_PARAMETROS();
        public class VG0145B_WS_PARAMETROS : VarBasis
        {
            /*"  03            W01DIGCERT.*/
            public VG0145B_W01DIGCERT W01DIGCERT { get; set; } = new VG0145B_W01DIGCERT();
            public class VG0145B_W01DIGCERT : VarBasis
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
        public Dclgens.BANCOS BANCOS { get; set; } = new Dclgens.BANCOS();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.CONMOVVG CONMOVVG { get; set; } = new Dclgens.CONMOVVG();
        public Dclgens.GECLIMOV GECLIMOV { get; set; } = new Dclgens.GECLIMOV();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.ERRPROVI ERRPROVI { get; set; } = new Dclgens.ERRPROVI();
        public Dclgens.FAIXASAL FAIXASAL { get; set; } = new Dclgens.FAIXASAL();
        public Dclgens.FAIXAETA FAIXAETA { get; set; } = new Dclgens.FAIXAETA();
        public Dclgens.FATURCON FATURCON { get; set; } = new Dclgens.FATURCON();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.MOEDAS MOEDAS { get; set; } = new Dclgens.MOEDAS();
        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.NUMEROUT NUMEROUT { get; set; } = new Dclgens.NUMEROUT();
        public Dclgens.PARAMRAM PARAMRAM { get; set; } = new Dclgens.PARAMRAM();
        public Dclgens.PLANOVGA PLANOVGA { get; set; } = new Dclgens.PLANOVGA();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.SEGVGAPH SEGVGAPH { get; set; } = new Dclgens.SEGVGAPH();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.VGSEGCON VGSEGCON { get; set; } = new Dclgens.VGSEGCON();
        public Dclgens.PLANOFAI PLANOFAI { get; set; } = new Dclgens.PLANOFAI();
        public VG0145B_CPROPOVA CPROPOVA { get; set; } = new VG0145B_CPROPOVA();
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
            /*" -679- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -680- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -683- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -686- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -689- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -690- DISPLAY 'PROGRAMA EM EXECUCAO VG0145B  ' */
            _.Display($"PROGRAMA EM EXECUCAO VG0145B  ");

            /*" -691- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -692- DISPLAY 'VERSAO V.00 49.010 08/11/2010 ' */
            _.Display($"VERSAO V.00 49.010 08/11/2010 ");

            /*" -693- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -695- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -697- PERFORM R0100-00-SELECT-TSISTEMA. */

            R0100_00_SELECT_TSISTEMA_SECTION();

            /*" -699- PERFORM R0900-00-DECLA-PROPOVA. */

            R0900_00_DECLA_PROPOVA_SECTION();

            /*" -701- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

            /*" -702- IF WFIM-MOVIMENTO EQUAL 'SIM' */

            if (FILLER_0.FILLER_10.WFIM_MOVIMENTO == "SIM")
            {

                /*" -703- MOVE 01 TO RETURN-CODE */
                _.Move(01, RETURN_CODE);

                /*" -704- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -706- GO TO R9000-00-FINALIZA. */

                R9000_00_FINALIZA_SECTION(); //GOTO
                return;
            }


            /*" -709- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-MOVIMENTO EQUAL 'SIM' . */

            while (!(FILLER_0.FILLER_10.WFIM_MOVIMENTO == "SIM"))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -711- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -713- PERFORM R9000-00-FINALIZA. */

            R9000_00_FINALIZA_SECTION();

            /*" -713- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-TSISTEMA-SECTION */
        private void R0100_00_SELECT_TSISTEMA_SECTION()
        {
            /*" -726- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -731- PERFORM R0100_00_SELECT_TSISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_TSISTEMA_DB_SELECT_1();

            /*" -734- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -735- DISPLAY 'VG0145B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"VG0145B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -736- DISPLAY 'IDSISTEM =  VG ' */
                _.Display($"IDSISTEM =  VG ");

                /*" -738- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -739- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -740- DISPLAY 'VG0145B - ERRO NA LEITURA NA SISTEMAS  ' */
                _.Display($"VG0145B - ERRO NA LEITURA NA SISTEMAS  ");

                /*" -740- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-TSISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_TSISTEMA_DB_SELECT_1()
        {
            /*" -731- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' END-EXEC. */

            var r0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLA-PROPOVA-SECTION */
        private void R0900_00_DECLA_PROPOVA_SECTION()
        {
            /*" -753- MOVE 'R0900-00-DECLA-PROPOVA ' TO PARAGRAFO. */
            _.Move("R0900-00-DECLA-PROPOVA ", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -755- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -772- PERFORM R0900_00_DECLA_PROPOVA_DB_DECLARE_1 */

            R0900_00_DECLA_PROPOVA_DB_DECLARE_1();

            /*" -774- PERFORM R0900_00_DECLA_PROPOVA_DB_OPEN_1 */

            R0900_00_DECLA_PROPOVA_DB_OPEN_1();

            /*" -777- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -778- DISPLAY 'PROBLEMAS NO OPEN (CPROPOVA) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CPROPOVA) ... ");

                /*" -778- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLA-PROPOVA-DB-DECLARE-1 */
        public void R0900_00_DECLA_PROPOVA_DB_DECLARE_1()
        {
            /*" -772- EXEC SQL DECLARE CPROPOVA CURSOR WITH HOLD FOR SELECT A.NUM_CERTIFICADO , A.NUM_APOLICE, A.COD_SUBGRUPO, A.NUM_PARCELA, A.OCORR_HISTORICO, A.DTPROXVEN, A.DATA_QUITACAO FROM SEGUROS.PROPOSTAS_VA A WHERE A.NUM_APOLICE = 108210696253 AND A.SIT_REGISTRO IN ( '3' , '6' ) AND A.DTPROXVEN <> '9999-12-31' ORDER BY A.NUM_APOLICE, A.COD_SUBGRUPO END-EXEC. */
            CPROPOVA = new VG0145B_CPROPOVA(false);
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
							, 
							A.DATA_QUITACAO 
							FROM SEGUROS.PROPOSTAS_VA A 
							WHERE A.NUM_APOLICE = 108210696253 
							AND A.SIT_REGISTRO IN ( '3'
							, '6' ) 
							AND A.DTPROXVEN <> '9999-12-31' 
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
            /*" -774- EXEC SQL OPEN CPROPOVA END-EXEC. */

            CPROPOVA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-SECTION */
        private void R0910_00_FETCH_PROPOVA_SECTION()
        {
            /*" -791- MOVE 'R0910-00-FETCH-PROPOVA' TO PARAGRAFO. */
            _.Move("R0910-00-FETCH-PROPOVA", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -793- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -801- PERFORM R0910_00_FETCH_PROPOVA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOVA_DB_FETCH_1();

            /*" -804- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -805- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -805- PERFORM R0910_00_FETCH_PROPOVA_DB_CLOSE_1 */

                    R0910_00_FETCH_PROPOVA_DB_CLOSE_1();

                    /*" -807- MOVE 'SIM' TO WFIM-MOVIMENTO */
                    _.Move("SIM", FILLER_0.FILLER_10.WFIM_MOVIMENTO);

                    /*" -808- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -809- ELSE */
                }
                else
                {


                    /*" -810- DISPLAY 'R0910-00 (ERRO -  FETCH CPROPOVA).. ' */
                    _.Display($"R0910-00 (ERRO -  FETCH CPROPOVA).. ");

                    /*" -812- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -815- ADD 1 TO AC-LIDOS AC-LIDOS-M. */
            FILLER_0.AC_LIDOS.Value = FILLER_0.AC_LIDOS + 1;
            FILLER_0.AC_LIDOS_M.Value = FILLER_0.AC_LIDOS_M + 1;

            /*" -816- IF AC-LIDOS GREATER 999 */

            if (FILLER_0.AC_LIDOS > 999)
            {

                /*" -817- MOVE ZEROS TO AC-LIDOS */
                _.Move(0, FILLER_0.AC_LIDOS);

                /*" -818- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), FILLER_0.WS_TIME);

                /*" -818- DISPLAY 'LIDOS MOVIMENTO ' AC-LIDOS-M ' ' WS-TIME. */

                $"LIDOS MOVIMENTO {FILLER_0.AC_LIDOS_M} {FILLER_0.WS_TIME}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOVA_DB_FETCH_1()
        {
            /*" -801- EXEC SQL FETCH CPROPOVA INTO :PROPOVA-NUM-CERTIFICADO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-NUM-PARCELA, :PROPOVA-OCORR-HISTORICO, :PROPOVA-DTPROXVEN, :PROPOVA-DATA-QUITACAO END-EXEC. */

            if (CPROPOVA.Fetch())
            {
                _.Move(CPROPOVA.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CPROPOVA.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CPROPOVA.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(CPROPOVA.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
                _.Move(CPROPOVA.PROPOVA_OCORR_HISTORICO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO);
                _.Move(CPROPOVA.PROPOVA_DTPROXVEN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);
                _.Move(CPROPOVA.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_PROPOVA_DB_CLOSE_1()
        {
            /*" -805- EXEC SQL CLOSE CPROPOVA END-EXEC */

            CPROPOVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -832- MOVE 'R1000-00-PROCESSA-REGISTRO' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA-REGISTRO", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -834- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -836- PERFORM R1200-00-SELECT-PARCEVID. */

            R1200_00_SELECT_PARCEVID_SECTION();

            /*" -837- IF WTEM-PARCEVID EQUAL 'NAO' */

            if (FILLER_0.FILLER_10.WTEM_PARCEVID == "NAO")
            {

                /*" -838- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -840- END-IF. */
            }


            /*" -842- PERFORM R1400-00-SELECT-HISCOBPR. */

            R1400_00_SELECT_HISCOBPR_SECTION();

            /*" -843- IF WTEM-HISCOBPR EQUAL 'NAO' */

            if (FILLER_0.FILLER_10.WTEM_HISCOBPR == "NAO")
            {

                /*" -844- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -846- END-IF. */
            }


            /*" -850- MOVE ZEROS TO WHOST-PRMAP WHOST-IMPSEG. */
            _.Move(0, WHOST_PRMAP, WHOST_IMPSEG);

            /*" -853- MOVE PARCEVID-PREMIO-AP TO WHOST-PRMAP. */
            _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP, WHOST_PRMAP);

            /*" -856- MOVE HISCOBPR-IMPSEGUR TO WHOST-IMPSEG. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR, WHOST_IMPSEG);

            /*" -858- PERFORM R2200-00-SELECT-SUBGVGAP. */

            R2200_00_SELECT_SUBGVGAP_SECTION();

            /*" -880- MOVE ZEROS TO HISCOBPR-NUM-CERTIFICADO HISCOBPR-OCORR-HISTORICO HISCOBPR-IMPSEGUR HISCOBPR-QUANT-VIDAS HISCOBPR-IMPSEGIND HISCOBPR-IMP-MORNATU HISCOBPR-IMPMORACID HISCOBPR-IMPINVPERM HISCOBPR-IMPAMDS HISCOBPR-IMPDH HISCOBPR-IMPDIT HISCOBPR-VLPREMIO HISCOBPR-PRMVG HISCOBPR-PRMAP HISCOBPR-QTDE-TIT-CAPITALIZ HISCOBPR-VAL-TIT-CAPITALIZ HISCOBPR-VAL-CUSTO-CAPITALI HISCOBPR-IMPSEGCDG HISCOBPR-VLCUSTCDG HISCOBPR-COD-OPERACAO. */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

            /*" -887- MOVE SPACES TO HISCOBPR-DATA-INIVIGENCIA WHOST-DATA-INIVIGENCIA HISCOBPR-DATA-TERVIGENCIA HISCOBPR-OPCAO-COBERTURA HISCOBPR-COD-USUARIO. */
            _.Move("", HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA, WHOST_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_USUARIO);

            /*" -888- IF PROPOVA-OCORR-HISTORICO EQUAL ZEROS */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO == 00)
            {

                /*" -891- MOVE 101 TO HISCOBPR-COD-OPERACAO */
                _.Move(101, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                /*" -894- MOVE PROPOVA-DATA-QUITACAO TO WHOST-DATA-INIVIGENCIA */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, WHOST_DATA_INIVIGENCIA);

                /*" -895- PERFORM R2500-00-INSERT-PARCEVID */

                R2500_00_INSERT_PARCEVID_SECTION();

                /*" -897- PERFORM R2700-00-INSERT-HISTCOBVA */

                R2700_00_INSERT_HISTCOBVA_SECTION();

                /*" -898- GO TO R1000-10-CONTINUA */

                R1000_10_CONTINUA(); //GOTO
                return;

                /*" -900- END-IF. */
            }


            /*" -902- PERFORM R2300-00-SELECT-COBERPROPVA. */

            R2300_00_SELECT_COBERPROPVA_SECTION();

            /*" -903- IF WPROCESSA EQUAL 'NAO' */

            if (FILLER_0.FILLER_10.WPROCESSA == "NAO")
            {

                /*" -904- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -906- END-IF. */
            }


            /*" -908- PERFORM R2910-00-UPDATE-COBERPROPVA. */

            R2910_00_UPDATE_COBERPROPVA_SECTION();

            /*" -909- IF HISCOBPR-IMP-MORNATU GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU > 00)
            {

                /*" -910- IF WHOST-IMPSEG EQUAL HISCOBPR-IMP-MORNATU */

                if (WHOST_IMPSEG == HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU)
                {

                    /*" -912- MOVE 0 TO HISCOBPR-COD-OPERACAO */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                    /*" -913- ELSE */
                }
                else
                {


                    /*" -914- IF WHOST-IMPSEG LESS HISCOBPR-IMP-MORNATU */

                    if (WHOST_IMPSEG < HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU)
                    {

                        /*" -916- MOVE 701 TO HISCOBPR-COD-OPERACAO */
                        _.Move(701, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                        /*" -917- ELSE */
                    }
                    else
                    {


                        /*" -919- MOVE 801 TO HISCOBPR-COD-OPERACAO */
                        _.Move(801, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                        /*" -920- END-IF */
                    }


                    /*" -921- END-IF */
                }


                /*" -922- ELSE */
            }
            else
            {


                /*" -923- IF WHOST-IMPSEG EQUAL HISCOBPR-IMPMORACID */

                if (WHOST_IMPSEG == HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID)
                {

                    /*" -925- MOVE 0 TO HISCOBPR-COD-OPERACAO */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                    /*" -926- ELSE */
                }
                else
                {


                    /*" -927- IF WHOST-IMPSEG LESS HISCOBPR-IMPMORACID */

                    if (WHOST_IMPSEG < HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID)
                    {

                        /*" -929- MOVE 701 TO HISCOBPR-COD-OPERACAO */
                        _.Move(701, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                        /*" -930- ELSE */
                    }
                    else
                    {


                        /*" -932- MOVE 801 TO HISCOBPR-COD-OPERACAO */
                        _.Move(801, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                        /*" -933- END-IF */
                    }


                    /*" -934- END-IF */
                }


                /*" -934- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_10_CONTINUA */

            R1000_10_CONTINUA();

        }

        [StopWatch]
        /*" R1000-10-CONTINUA */
        private void R1000_10_CONTINUA(bool isPerform = false)
        {
            /*" -941- PERFORM R2900-00-INSERT-COBERPROPVA. */

            R2900_00_INSERT_COBERPROPVA_SECTION();

            /*" -943- PERFORM R2920-00-UPDATE-PROPOSTAVA. */

            R2920_00_UPDATE_PROPOSTAVA_SECTION();

            /*" -943- PERFORM R2940-00-UPDATE-PARCEVID. */

            R2940_00_UPDATE_PARCEVID_SECTION();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -947- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-PARCEVID-SECTION */
        private void R1200_00_SELECT_PARCEVID_SECTION()
        {
            /*" -961- MOVE 'R1200-00-SELECT-PARCEVID    ' TO PARAGRAFO. */
            _.Move("R1200-00-SELECT-PARCEVID    ", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -963- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -964- MOVE 'SIM' TO WTEM-PARCEVID. */
            _.Move("SIM", FILLER_0.FILLER_10.WTEM_PARCEVID);

            /*" -966- MOVE ZEROS TO PARCEVID-PREMIO-AP. */
            _.Move(0, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP);

            /*" -978- PERFORM R1200_00_SELECT_PARCEVID_DB_SELECT_1 */

            R1200_00_SELECT_PARCEVID_DB_SELECT_1();

            /*" -981- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -982- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -983- MOVE 'NAO' TO WTEM-PARCEVID */
                    _.Move("NAO", FILLER_0.FILLER_10.WTEM_PARCEVID);

                    /*" -984- ELSE */
                }
                else
                {


                    /*" -986- DISPLAY 'ERRO  DE ACESSO A PARCELAS_VIDAZUL  ' ' ' PROPOVA-NUM-APOLICE ' ' PROPOVA-COD-SUBGRUPO */

                    $"ERRO  DE ACESSO A PARCELAS_VIDAZUL   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}"
                    .Display();

                    /*" -988- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -989- IF WHOST-QTDSEG EQUAL ZEROS */

            if (WHOST_QTDSEG == 00)
            {

                /*" -990- MOVE 'NAO' TO WTEM-PARCEVID */
                _.Move("NAO", FILLER_0.FILLER_10.WTEM_PARCEVID);

                /*" -990- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-PARCEVID-DB-SELECT-1 */
        public void R1200_00_SELECT_PARCEVID_DB_SELECT_1()
        {
            /*" -978- EXEC SQL SELECT VALUE(COUNT(*), 0), VALUE(SUM(T1.PREMIO_AP), 0) INTO :WHOST-QTDSEG, :PARCEVID-PREMIO-AP FROM SEGUROS.PARCELAS_VIDAZUL T1 WHERE T1.SIT_REGISTRO = 'V' AND T1.NUM_CERTIFICADO IN (SELECT T10.NUM_CERTIFICADO FROM SEGUROS.PROPOSTAS_VA T10 WHERE T10.NUM_APOLICE = :PROPOVA-NUM-APOLICE AND T10.DTPROXVEN = '9999-12-31' ) END-EXEC. */

            var r1200_00_SELECT_PARCEVID_DB_SELECT_1_Query1 = new R1200_00_SELECT_PARCEVID_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_PARCEVID_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_PARCEVID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTDSEG, WHOST_QTDSEG);
                _.Move(executed_1.PARCEVID_PREMIO_AP, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-HISCOBPR-SECTION */
        private void R1400_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -1004- MOVE 'R1400-00-SELECT-HISCOBPR    ' TO PARAGRAFO. */
            _.Move("R1400-00-SELECT-HISCOBPR    ", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1006- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1007- MOVE 'SIM' TO WTEM-HISCOBPR. */
            _.Move("SIM", FILLER_0.FILLER_10.WTEM_HISCOBPR);

            /*" -1009- MOVE ZEROS TO HISCOBPR-IMPSEGUR. */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);

            /*" -1021- PERFORM R1400_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R1400_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -1024- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1025- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1026- MOVE 'NAO' TO WTEM-HISCOBPR */
                    _.Move("NAO", FILLER_0.FILLER_10.WTEM_HISCOBPR);

                    /*" -1027- ELSE */
                }
                else
                {


                    /*" -1029- DISPLAY 'ERRO  DE ACESSO A HIS_COBER_PROPOST ' ' ' PROPOVA-NUM-APOLICE ' ' PROPOVA-COD-SUBGRUPO */

                    $"ERRO  DE ACESSO A HIS_COBER_PROPOST  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}"
                    .Display();

                    /*" -1029- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R1400_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -1021- EXEC SQL SELECT VALUE(SUM(T2.IMPSEGUR), 0) INTO :HISCOBPR-IMPSEGUR FROM SEGUROS.PARCELAS_VIDAZUL T1, SEGUROS.HIS_COBER_PROPOST T2 WHERE T1.SIT_REGISTRO = 'V' AND T1.NUM_CERTIFICADO IN (SELECT T10.NUM_CERTIFICADO FROM SEGUROS.PROPOSTAS_VA T10 WHERE T10.NUM_APOLICE = :PROPOVA-NUM-APOLICE AND T10.DTPROXVEN = '9999-12-31' ) AND T1.NUM_CERTIFICADO = T2.NUM_CERTIFICADO END-EXEC. */

            var r1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_IMPSEGUR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SELECT-SUBGVGAP-SECTION */
        private void R2200_00_SELECT_SUBGVGAP_SECTION()
        {
            /*" -1043- MOVE 'R2200-00-ACESSA-SUBGVGAP' TO PARAGRAFO. */
            _.Move("R2200-00-ACESSA-SUBGVGAP", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1045- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1047- MOVE ZEROS TO SUBGVGAP-PERI-FATURAMENTO. */
            _.Move(0, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO);

            /*" -1053- PERFORM R2200_00_SELECT_SUBGVGAP_DB_SELECT_1 */

            R2200_00_SELECT_SUBGVGAP_DB_SELECT_1();

            /*" -1056- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1057- DISPLAY 'ERRO NO ACESSO A SUBGRUPOS_VGAP ' */
                _.Display($"ERRO NO ACESSO A SUBGRUPOS_VGAP ");

                /*" -1059- DISPLAY ' APOLICE  ' PROPOVA-NUM-APOLICE ' ' ' SUBGRUPO ' PROPOVA-COD-SUBGRUPO */

                $" APOLICE  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}  SUBGRUPO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}"
                .Display();

                /*" -1060- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1060- END-IF. */
            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-SUBGVGAP-DB-SELECT-1 */
        public void R2200_00_SELECT_SUBGVGAP_DB_SELECT_1()
        {
            /*" -1053- EXEC SQL SELECT PERI_FATURAMENTO INTO :SUBGVGAP-PERI-FATURAMENTO FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO END-EXEC. */

            var r2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 = new R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1.Execute(r2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_PERI_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-SELECT-COBERPROPVA-SECTION */
        private void R2300_00_SELECT_COBERPROPVA_SECTION()
        {
            /*" -1074- MOVE 'R2300-00-SELECT-COBERPROPVA ' TO PARAGRAFO. */
            _.Move("R2300-00-SELECT-COBERPROPVA ", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1076- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1078- MOVE 'SIM' TO WPROCESSA. */
            _.Move("SIM", FILLER_0.FILLER_10.WPROCESSA);

            /*" -1133- PERFORM R2300_00_SELECT_COBERPROPVA_DB_SELECT_1 */

            R2300_00_SELECT_COBERPROPVA_DB_SELECT_1();

            /*" -1136- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1138- DISPLAY 'ERRO  DE ACESSO A HIS_COBER_PROPOST ' ' ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-OCORR-HISTORICO */

                $"ERRO  DE ACESSO A HIS_COBER_PROPOST  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO}"
                .Display();

                /*" -1143- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1145- IF WHOST-DATA-INIVIGENCIA > PROPOVA-DTPROXVEN OR WHOST-DATA-INIVIGENCIA = PROPOVA-DTPROXVEN */

            if (WHOST_DATA_INIVIGENCIA > PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN || WHOST_DATA_INIVIGENCIA == PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN)
            {

                /*" -1146- ADD 1 TO AC-DESPREZ-VIG */
                FILLER_0.AC_DESPREZ_VIG.Value = FILLER_0.AC_DESPREZ_VIG + 1;

                /*" -1148- MOVE 'NAO' TO WPROCESSA */
                _.Move("NAO", FILLER_0.FILLER_10.WPROCESSA);

                /*" -1148- END-IF. */
            }


        }

        [StopWatch]
        /*" R2300-00-SELECT-COBERPROPVA-DB-SELECT-1 */
        public void R2300_00_SELECT_COBERPROPVA_DB_SELECT_1()
        {
            /*" -1133- EXEC SQL SELECT NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA, DATA_INIVIGENCIA + :SUBGVGAP-PERI-FATURAMENTO MONTHS, DATA_TERVIGENCIA, IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO, OPCAO_COBERTURA, IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ , VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI , IMPSEGCDG , VLCUSTCDG , COD_USUARIO INTO :HISCOBPR-NUM-CERTIFICADO , :HISCOBPR-OCORR-HISTORICO , :HISCOBPR-DATA-INIVIGENCIA , :WHOST-DATA-INIVIGENCIA , :HISCOBPR-DATA-TERVIGENCIA , :HISCOBPR-IMPSEGUR , :HISCOBPR-QUANT-VIDAS , :HISCOBPR-IMPSEGIND , :HISCOBPR-COD-OPERACAO, :HISCOBPR-OPCAO-COBERTURA, :HISCOBPR-IMP-MORNATU , :HISCOBPR-IMPMORACID , :HISCOBPR-IMPINVPERM , :HISCOBPR-IMPAMDS , :HISCOBPR-IMPDH , :HISCOBPR-IMPDIT , :HISCOBPR-VLPREMIO , :HISCOBPR-PRMVG , :HISCOBPR-PRMAP , :HISCOBPR-QTDE-TIT-CAPITALIZ, :HISCOBPR-VAL-TIT-CAPITALIZ, :HISCOBPR-VAL-CUSTO-CAPITALI, :HISCOBPR-IMPSEGCDG , :HISCOBPR-VLCUSTCDG , :HISCOBPR-COD-USUARIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = :PROPOVA-OCORR-HISTORICO END-EXEC. */

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
        /*" R2500-00-INSERT-PARCEVID-SECTION */
        private void R2500_00_INSERT_PARCEVID_SECTION()
        {
            /*" -1162- MOVE 'R2500-00-INSERT-PARCEVI' TO PARAGRAFO. */
            _.Move("R2500-00-INSERT-PARCEVI", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1164- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1167- MOVE 1 TO PARCEVID-NUM-PARCELA. */
            _.Move(1, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA);

            /*" -1170- MOVE '2010-12-20' TO PARCEVID-DATA-VENCIMENTO. */
            _.Move("2010-12-20", PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO);

            /*" -1173- MOVE '0' TO PARCEVID-SIT-REGISTRO. */
            _.Move("0", PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO);

            /*" -1178- PERFORM R2500_00_INSERT_PARCEVID_DB_SELECT_1 */

            R2500_00_INSERT_PARCEVID_DB_SELECT_1();

            /*" -1181- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1183- DISPLAY 'ERRO NO ACESSO A OPCAO_PAG_VIDAZUL: ' ' CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */

                $"ERRO NO ACESSO A OPCAO_PAG_VIDAZUL:  CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                .Display();

                /*" -1185- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1188- MOVE OPCPAGVI-OPCAO-PAGAMENTO TO PARCEVID-OPCAO-PAGAMENTO. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OPCAO_PAGAMENTO);

            /*" -1191- MOVE ZEROS TO PARCEVID-PREMIO-VG. */
            _.Move(0, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG);

            /*" -1194- MOVE WHOST-PRMAP TO PARCEVID-PREMIO-AP. */
            _.Move(WHOST_PRMAP, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP);

            /*" -1197- MOVE ZEROS TO PARCEVID-OCORR-HISTORICO */
            _.Move(0, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO);

            /*" -1220- PERFORM R2500_00_INSERT_PARCEVID_DB_INSERT_1 */

            R2500_00_INSERT_PARCEVID_DB_INSERT_1();

            /*" -1223- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1224- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1225- GO TO R2500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/ //GOTO
                    return;

                    /*" -1226- ELSE */
                }
                else
                {


                    /*" -1229- DISPLAY 'PROBLEMA INSERT DA PARCELVA ....' PROPOVA-NUM-CERTIFICADO ' ' PARCEVID-NUM-PARCELA */

                    $"PROBLEMA INSERT DA PARCELVA ....{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA}"
                    .Display();

                    /*" -1230- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1231- END-IF */
                }


                /*" -1231- END-IF. */
            }


        }

        [StopWatch]
        /*" R2500-00-INSERT-PARCEVID-DB-SELECT-1 */
        public void R2500_00_INSERT_PARCEVID_DB_SELECT_1()
        {
            /*" -1178- EXEC SQL SELECT OPCAO_PAGAMENTO INTO :OPCPAGVI-OPCAO-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r2500_00_INSERT_PARCEVID_DB_SELECT_1_Query1 = new R2500_00_INSERT_PARCEVID_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2500_00_INSERT_PARCEVID_DB_SELECT_1_Query1.Execute(r2500_00_INSERT_PARCEVID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
            }


        }

        [StopWatch]
        /*" R2500-00-INSERT-PARCEVID-DB-INSERT-1 */
        public void R2500_00_INSERT_PARCEVID_DB_INSERT_1()
        {
            /*" -1220- EXEC SQL INSERT INTO SEGUROS.PARCELAS_VIDAZUL ( NUM_CERTIFICADO , NUM_PARCELA , DATA_VENCIMENTO , PREMIO_VG , PREMIO_AP , VLMULTA , OPCAO_PAGAMENTO , SIT_REGISTRO , OCORR_HISTORICO , TIMESTAMP) VALUES (:PROPOVA-NUM-CERTIFICADO, :PARCEVID-NUM-PARCELA, :PARCEVID-DATA-VENCIMENTO, :PARCEVID-PREMIO-VG, :PARCEVID-PREMIO-AP, 0.0, :PARCEVID-OPCAO-PAGAMENTO, :PARCEVID-SIT-REGISTRO, :PARCEVID-OCORR-HISTORICO, CURRENT TIMESTAMP) END-EXEC. */

            var r2500_00_INSERT_PARCEVID_DB_INSERT_1_Insert1 = new R2500_00_INSERT_PARCEVID_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PARCEVID_NUM_PARCELA = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA.ToString(),
                PARCEVID_DATA_VENCIMENTO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO.ToString(),
                PARCEVID_PREMIO_VG = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG.ToString(),
                PARCEVID_PREMIO_AP = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP.ToString(),
                PARCEVID_OPCAO_PAGAMENTO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OPCAO_PAGAMENTO.ToString(),
                PARCEVID_SIT_REGISTRO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO.ToString(),
                PARCEVID_OCORR_HISTORICO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO.ToString(),
            };

            R2500_00_INSERT_PARCEVID_DB_INSERT_1_Insert1.Execute(r2500_00_INSERT_PARCEVID_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-INSERT-HISTCOBVA-SECTION */
        private void R2700_00_INSERT_HISTCOBVA_SECTION()
        {
            /*" -1244- MOVE 'R2700-00-INSERT-HISTCOBVA' TO PARAGRAFO. */
            _.Move("R2700-00-INSERT-HISTCOBVA", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1246- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1254- PERFORM R2700_00_INSERT_HISTCOBVA_DB_SELECT_1 */

            R2700_00_INSERT_HISTCOBVA_DB_SELECT_1();

            /*" -1257- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1258- GO TO R2700-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                return;

                /*" -1260- END-IF. */
            }


            /*" -1264- COMPUTE COBHISVI-PRM-TOTAL = PARCEVID-PREMIO-VG + PARCEVID-PREMIO-AP. */
            COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL.Value = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG + PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP;

            /*" -1266- PERFORM R2710-00-NUM-TITULO. */

            R2710_00_NUM_TITULO_SECTION();

            /*" -1269- MOVE BANCOS-NUM-TITULO TO COBHISVI-NUM-TITULO. */
            _.Move(BANCOS.DCLBANCOS.BANCOS_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);

            /*" -1272- MOVE 1 TO COBHISVI-NUM-PARCELA. */
            _.Move(1, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA);

            /*" -1275- MOVE '5' TO COBHISVI-SIT-REGISTRO. */
            _.Move("5", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

            /*" -1278- MOVE ZEROS TO COBHISVI-OCORR-HISTORICO. */
            _.Move(0, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO);

            /*" -1281- MOVE '2010-12-20' TO COBHISVI-DATA-VENCIMENTO. */
            _.Move("2010-12-20", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_DATA_VENCIMENTO);

            /*" -1284- MOVE ZEROS TO COBHISVI-BCO-AVISO. */
            _.Move(0, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_BCO_AVISO);

            /*" -1287- MOVE ZEROS TO COBHISVI-AGE-AVISO. */
            _.Move(0, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_AGE_AVISO);

            /*" -1290- MOVE ZEROS TO COBHISVI-NUM-AVISO-CREDITO. */
            _.Move(0, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_AVISO_CREDITO);

            /*" -1292- MOVE '2700' TO WNR-EXEC-SQL */
            _.Move("2700", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1323- PERFORM R2700_00_INSERT_HISTCOBVA_DB_INSERT_1 */

            R2700_00_INSERT_HISTCOBVA_DB_INSERT_1();

            /*" -1326- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1335- DISPLAY 'PROBLEMA INSERT DA HISTCOBVA ...' ' ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-NUM-PARCELA ' ' COBHISVI-NUM-TITULO ' ' PROPOVA-DATA-VENCIMENTO ' ' COBHISVI-PRM-TOTAL ' ' PARCEVID-OPCAO-PAGAMENTO ' ' COBHISVI-SIT-REGISTRO ' ' COBHISVI-OCORR-HISTORICO */

                $"PROBLEMA INSERT DA HISTCOBVA ... {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA} {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO} {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL} {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OPCAO_PAGAMENTO} {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO} {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO}"
                .Display();

                /*" -1336- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1336- END-IF. */
            }


        }

        [StopWatch]
        /*" R2700-00-INSERT-HISTCOBVA-DB-SELECT-1 */
        public void R2700_00_INSERT_HISTCOBVA_DB_SELECT_1()
        {
            /*" -1254- EXEC SQL SELECT NUM_CERTIFICADO, NUM_TITULO INTO :COBHISVI-NUM-CERTIFICADO, :COBHISVI-NUM-TITULO FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA = :PARCEVID-NUM-PARCELA END-EXEC. */

            var r2700_00_INSERT_HISTCOBVA_DB_SELECT_1_Query1 = new R2700_00_INSERT_HISTCOBVA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PARCEVID_NUM_PARCELA = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA.ToString(),
            };

            var executed_1 = R2700_00_INSERT_HISTCOBVA_DB_SELECT_1_Query1.Execute(r2700_00_INSERT_HISTCOBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBHISVI_NUM_CERTIFICADO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO);
                _.Move(executed_1.COBHISVI_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);
            }


        }

        [StopWatch]
        /*" R2700-00-INSERT-HISTCOBVA-DB-INSERT-1 */
        public void R2700_00_INSERT_HISTCOBVA_DB_INSERT_1()
        {
            /*" -1323- EXEC SQL INSERT INTO SEGUROS.COBER_HIST_VIDAZUL (NUM_CERTIFICADO , NUM_PARCELA , NUM_TITULO , DATA_VENCIMENTO , PRM_TOTAL , OPCAO_PAGAMENTO , SIT_REGISTRO , COD_OPERACAO , OCORR_HISTORICO , COD_DEVOLUCAO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , NUM_TITULO_COMP) VALUES (:PROPOVA-NUM-CERTIFICADO, :COBHISVI-NUM-PARCELA, :COBHISVI-NUM-TITULO, :COBHISVI-DATA-VENCIMENTO, :COBHISVI-PRM-TOTAL, :PARCEVID-OPCAO-PAGAMENTO, :COBHISVI-SIT-REGISTRO, 0, :COBHISVI-OCORR-HISTORICO, 0, :COBHISVI-BCO-AVISO , :COBHISVI-AGE-AVISO , :COBHISVI-NUM-AVISO-CREDITO, 0) END-EXEC. */

            var r2700_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1 = new R2700_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                COBHISVI_NUM_PARCELA = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA.ToString(),
                COBHISVI_NUM_TITULO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO.ToString(),
                COBHISVI_DATA_VENCIMENTO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_DATA_VENCIMENTO.ToString(),
                COBHISVI_PRM_TOTAL = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL.ToString(),
                PARCEVID_OPCAO_PAGAMENTO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OPCAO_PAGAMENTO.ToString(),
                COBHISVI_SIT_REGISTRO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO.ToString(),
                COBHISVI_OCORR_HISTORICO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO.ToString(),
                COBHISVI_BCO_AVISO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_BCO_AVISO.ToString(),
                COBHISVI_AGE_AVISO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_AGE_AVISO.ToString(),
                COBHISVI_NUM_AVISO_CREDITO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_AVISO_CREDITO.ToString(),
            };

            R2700_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1.Execute(r2700_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2710-00-NUM-TITULO-SECTION */
        private void R2710_00_NUM_TITULO_SECTION()
        {
            /*" -1348- MOVE 'R2710-00-NUM-TITULO' TO PARAGRAFO. */
            _.Move("R2710-00-NUM-TITULO", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1350- MOVE '2710' TO WNR-EXEC-SQL */
            _.Move("2710", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1355- PERFORM R2710_00_NUM_TITULO_DB_SELECT_1 */

            R2710_00_NUM_TITULO_DB_SELECT_1();

            /*" -1358- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1359- DISPLAY 'PROBLEMA SELECT BANCOS - 104 ...' */
                _.Display($"PROBLEMA SELECT BANCOS - 104 ...");

                /*" -1360- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1362- END-IF */
            }


            /*" -1365- MOVE BANCOS-NUM-TITULO TO W-NUMR-TITULO. */
            _.Move(BANCOS.DCLBANCOS.BANCOS_NUM_TITULO, FILLER_0.W_NUMR_TITULO);

            /*" -1367- ADD 1 TO WTITL-SEQUENCIA. */
            FILLER_0.FILLER_18.WTITL_SEQUENCIA.Value = FILLER_0.FILLER_18.WTITL_SEQUENCIA + 1;

            /*" -1370- MOVE WTITL-SEQUENCIA TO DPARM01. */
            _.Move(FILLER_0.FILLER_18.WTITL_SEQUENCIA, FILLER_0.DPARM01X.DPARM01);

            /*" -1372- CALL 'PROTIT01' USING DPARM01X. */
            _.Call("PROTIT01", FILLER_0.DPARM01X);

            /*" -1373- IF DPARM01-RC NOT EQUAL +0 */

            if (FILLER_0.DPARM01X.DPARM01_RC != +0)
            {

                /*" -1374- DISPLAY 'ERRO CHAMADA PROTIT01' */
                _.Display($"ERRO CHAMADA PROTIT01");

                /*" -1375- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1377- END-IF */
            }


            /*" -1380- MOVE DPARM01-D1 TO WTITL-DIGITO. */
            _.Move(FILLER_0.DPARM01X.DPARM01_D1, FILLER_0.FILLER_18.WTITL_DIGITO);

            /*" -1383- MOVE W-NUMR-TITULO TO BANCOS-NUM-TITULO. */
            _.Move(FILLER_0.W_NUMR_TITULO, BANCOS.DCLBANCOS.BANCOS_NUM_TITULO);

            /*" -1385- MOVE '2710' TO WNR-EXEC-SQL */
            _.Move("2710", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1390- PERFORM R2710_00_NUM_TITULO_DB_UPDATE_1 */

            R2710_00_NUM_TITULO_DB_UPDATE_1();

            /*" -1393- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1394- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1394- END-IF. */
            }


        }

        [StopWatch]
        /*" R2710-00-NUM-TITULO-DB-SELECT-1 */
        public void R2710_00_NUM_TITULO_DB_SELECT_1()
        {
            /*" -1355- EXEC SQL SELECT NUM_TITULO INTO :BANCOS-NUM-TITULO FROM SEGUROS.BANCOS WHERE COD_BANCO = 104 END-EXEC. */

            var r2710_00_NUM_TITULO_DB_SELECT_1_Query1 = new R2710_00_NUM_TITULO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R2710_00_NUM_TITULO_DB_SELECT_1_Query1.Execute(r2710_00_NUM_TITULO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BANCOS_NUM_TITULO, BANCOS.DCLBANCOS.BANCOS_NUM_TITULO);
            }


        }

        [StopWatch]
        /*" R2710-00-NUM-TITULO-DB-UPDATE-1 */
        public void R2710_00_NUM_TITULO_DB_UPDATE_1()
        {
            /*" -1390- EXEC SQL UPDATE SEGUROS.BANCOS SET NUM_TITULO = :BANCOS-NUM-TITULO, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_BANCO = 104 END-EXEC. */

            var r2710_00_NUM_TITULO_DB_UPDATE_1_Update1 = new R2710_00_NUM_TITULO_DB_UPDATE_1_Update1()
            {
                BANCOS_NUM_TITULO = BANCOS.DCLBANCOS.BANCOS_NUM_TITULO.ToString(),
            };

            R2710_00_NUM_TITULO_DB_UPDATE_1_Update1.Execute(r2710_00_NUM_TITULO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-INSERT-COBERPROPVA-SECTION */
        private void R2900_00_INSERT_COBERPROPVA_SECTION()
        {
            /*" -1408- MOVE 'R2900-00-INSERT-COBERPROPVA' TO PARAGRAFO. */
            _.Move("R2900-00-INSERT-COBERPROPVA", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1410- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1415- MOVE WHOST-IMPSEG TO HISCOBPR-IMPSEGUR HISCOBPR-IMPSEGIND HISCOBPR-IMPMORACID. */
            _.Move(WHOST_IMPSEG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);

            /*" -1422- MOVE ZEROS TO HISCOBPR-IMP-MORNATU HISCOBPR-IMPINVPERM HISCOBPR-IMPAMDS HISCOBPR-IMPDH HISCOBPR-IMPDIT. */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT);

            /*" -1424- MOVE 0 TO HISCOBPR-QTDE-TIT-CAPITALIZ. */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ);

            /*" -1426- MOVE 0,00 TO HISCOBPR-VAL-TIT-CAPITALIZ. */
            _.Move(0.00, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ);

            /*" -1429- MOVE 0,00 TO HISCOBPR-VAL-CUSTO-CAPITALI. */
            _.Move(0.00, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI);

            /*" -1433- MOVE ZEROS TO HISCOBPR-IMPSEGCDG HISCOBPR-VLCUSTCDG. */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG);

            /*" -1435- MOVE WHOST-DATA-INIVIGENCIA TO HISCOBPR-DATA-INIVIGENCIA. */
            _.Move(WHOST_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);

            /*" -1438- MOVE '9999-12-31' TO HISCOBPR-DATA-TERVIGENCIA. */
            _.Move("9999-12-31", HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

            /*" -1441- COMPUTE PROPOVA-OCORR-HISTORICO = PROPOVA-OCORR-HISTORICO + 1. */
            PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.Value = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO + 1;

            /*" -1444- MOVE PROPOVA-OCORR-HISTORICO TO HISCOBPR-OCORR-HISTORICO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO);

            /*" -1447- MOVE 0 TO HISCOBPR-PRMVG. */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);

            /*" -1450- MOVE WHOST-PRMAP TO HISCOBPR-PRMAP. */
            _.Move(WHOST_PRMAP, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);

            /*" -1453- MOVE WHOST-QTDSEG TO HISCOBPR-QUANT-VIDAS. */
            _.Move(WHOST_QTDSEG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS);

            /*" -1457- COMPUTE HISCOBPR-VLPREMIO = HISCOBPR-PRMVG + HISCOBPR-PRMAP. */
            HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP;

            /*" -1518- PERFORM R2900_00_INSERT_COBERPROPVA_DB_INSERT_1 */

            R2900_00_INSERT_COBERPROPVA_DB_INSERT_1();

            /*" -1521- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -1524- DISPLAY 'PROBLEMA INSERT HIS_COBER_PROPOST     ..' PROPOVA-NUM-CERTIFICADO ' ' HISCOBPR-OCORR-HISTORICO ' ' HISCOBPR-DATA-INIVIGENCIA ' ' ' ' SQLCODE */

                $"PROBLEMA INSERT HIS_COBER_PROPOST     ..{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO} {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA}  {DB.SQLCODE}"
                .Display();

                /*" -1526- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1526- ADD 1 TO AC-I-COBERPROPVA. */
            FILLER_0.AC_I_COBERPROPVA.Value = FILLER_0.AC_I_COBERPROPVA + 1;

        }

        [StopWatch]
        /*" R2900-00-INSERT-COBERPROPVA-DB-INSERT-1 */
        public void R2900_00_INSERT_COBERPROPVA_DB_INSERT_1()
        {
            /*" -1518- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI, IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT ) VALUES (:PROPOVA-NUM-CERTIFICADO, :HISCOBPR-OCORR-HISTORICO, :HISCOBPR-DATA-INIVIGENCIA, :HISCOBPR-DATA-TERVIGENCIA, :HISCOBPR-IMPSEGUR, :HISCOBPR-QUANT-VIDAS, :HISCOBPR-IMPSEGIND, :HISCOBPR-COD-OPERACAO, ' ' , :HISCOBPR-IMP-MORNATU, :HISCOBPR-IMPMORACID, :HISCOBPR-IMPINVPERM, :HISCOBPR-IMPAMDS, :HISCOBPR-IMPDH, :HISCOBPR-IMPDIT, :HISCOBPR-VLPREMIO, :HISCOBPR-PRMVG, :HISCOBPR-PRMAP, :HISCOBPR-QTDE-TIT-CAPITALIZ, :HISCOBPR-VAL-TIT-CAPITALIZ, :HISCOBPR-VAL-CUSTO-CAPITALI, :HISCOBPR-IMPSEGCDG, :HISCOBPR-VLCUSTCDG, 'VG0145B' , CURRENT TIMESTAMP, NULL, NULL, NULL, NULL) END-EXEC. */

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
            /*" -1540- MOVE 'R2910-00-UPDATE-COBERPROPVA' TO PARAGRAFO. */
            _.Move("R2910-00-UPDATE-COBERPROPVA", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1542- MOVE '2910' TO WNR-EXEC-SQL. */
            _.Move("2910", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1550- PERFORM R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1 */

            R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1();

            /*" -1553- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1555- DISPLAY 'ERRO  DE ACESSO A HIS_COBER_PROPOST ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"ERRO  DE ACESSO A HIS_COBER_PROPOST {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1555- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2910-00-UPDATE-COBERPROPVA-DB-UPDATE-1 */
        public void R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1()
        {
            /*" -1550- EXEC SQL UPDATE SEGUROS.HIS_COBER_PROPOST SET DATA_TERVIGENCIA = DATA_INIVIGENCIA + :SUBGVGAP-PERI-FATURAMENTO MONTHS - 1 DAY WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = :PROPOVA-OCORR-HISTORICO END-EXEC. */

            var r2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1 = new R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1()
            {
                SUBGVGAP_PERI_FATURAMENTO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_OCORR_HISTORICO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.ToString(),
            };

            R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1.Execute(r2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2910_99_SAIDA*/

        [StopWatch]
        /*" R2920-00-UPDATE-PROPOSTAVA-SECTION */
        private void R2920_00_UPDATE_PROPOSTAVA_SECTION()
        {
            /*" -1569- MOVE 'R2920-00-UPDATE-PROPOSTAVA ' TO PARAGRAFO. */
            _.Move("R2920-00-UPDATE-PROPOSTAVA ", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1571- MOVE '2920' TO WNR-EXEC-SQL. */
            _.Move("2920", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1581- PERFORM R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1 */

            R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1();

            /*" -1584- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1586- DISPLAY 'ERRO  DE ACESSO A PROPOSTAS_VA ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"ERRO  DE ACESSO A PROPOSTAS_VA {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1586- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2920-00-UPDATE-PROPOSTAVA-DB-UPDATE-1 */
        public void R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1()
        {
            /*" -1581- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET OCORR_HISTORICO = :HISCOBPR-OCORR-HISTORICO, NUM_PARCELA = :PROPOVA-NUM-PARCELA + 1, DTPROXVEN = CASE WHEN NUM_PARCELA = 0 THEN '2011-01-20' ELSE DTPROXVEN END WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1 = new R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1()
            {
                HISCOBPR_OCORR_HISTORICO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.ToString(),
                PROPOVA_NUM_PARCELA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1.Execute(r2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2920_99_SAIDA*/

        [StopWatch]
        /*" R2940-00-UPDATE-PARCEVID-SECTION */
        private void R2940_00_UPDATE_PARCEVID_SECTION()
        {
            /*" -1600- MOVE 'R2940-00-UPDATE-PARCEVID   ' TO PARAGRAFO. */
            _.Move("R2940-00-UPDATE-PARCEVID   ", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1602- MOVE '2940' TO WNR-EXEC-SQL. */
            _.Move("2940", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1611- PERFORM R2940_00_UPDATE_PARCEVID_DB_UPDATE_1 */

            R2940_00_UPDATE_PARCEVID_DB_UPDATE_1();

            /*" -1614- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1616- DISPLAY 'ERRO  NO UPDATE A PARCEVID     ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"ERRO  NO UPDATE A PARCEVID     {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1616- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2940-00-UPDATE-PARCEVID-DB-UPDATE-1 */
        public void R2940_00_UPDATE_PARCEVID_DB_UPDATE_1()
        {
            /*" -1611- EXEC SQL UPDATE SEGUROS.PARCELAS_VIDAZUL T1 SET T1.SIT_REGISTRO = '1' WHERE T1.SIT_REGISTRO = 'V' AND T1.NUM_CERTIFICADO IN (SELECT T10.NUM_CERTIFICADO FROM SEGUROS.PROPOSTAS_VA T10 WHERE T10.NUM_APOLICE = :PROPOVA-NUM-APOLICE AND T10.DTPROXVEN = '9999-12-31' ) END-EXEC. */

            var r2940_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1 = new R2940_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            R2940_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1.Execute(r2940_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2940_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-FINALIZA-SECTION */
        private void R9000_00_FINALIZA_SECTION()
        {
            /*" -1630- MOVE 'R9000-00-FINALIZA' TO PARAGRAFO. */
            _.Move("R9000-00-FINALIZA", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1632- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1633- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -1634- DISPLAY 'PROGRAMA VG0145B ' */
            _.Display($"PROGRAMA VG0145B ");

            /*" -1635- DISPLAY 'TOTAIS PARA CONTROLE ' */
            _.Display($"TOTAIS PARA CONTROLE ");

            /*" -1636- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -1637- DISPLAY 'LIDOS DA PROPOSTAVA                 = ' AC-LIDOS-M */
            _.Display($"LIDOS DA PROPOSTAVA                 = {FILLER_0.AC_LIDOS_M}");

            /*" -1638- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -1639- DISPLAY ' .INCLUSOES                           ' */
            _.Display($" .INCLUSOES                           ");

            /*" -1641- DISPLAY '   COBERPROPVA                      = ' AC-I-COBERPROPVA. */
            _.Display($"   COBERPROPVA                      = {FILLER_0.AC_I_COBERPROPVA}");

            /*" -1642- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -1643- DISPLAY ' .ESTATISTICAS                        ' */
            _.Display($" .ESTATISTICAS                        ");

            /*" -1645- DISPLAY '   DESPREZADOS VIGENCIA             = ' AC-DESPREZ-VIG */
            _.Display($"   DESPREZADOS VIGENCIA             = {FILLER_0.AC_DESPREZ_VIG}");

            /*" -1646- DISPLAY '-------------------------------------' */
            _.Display($"-------------------------------------");

            /*" -1647- DISPLAY ' ' */
            _.Display($" ");

            /*" -1649- DISPLAY ' *** VG0145B - FIM NORMAL ' . */
            _.Display($" *** VG0145B - FIM NORMAL ");

            /*" -1649- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1651- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1663- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FILLER_0.WDATA_REL);

            /*" -1664- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(FILLER_0.FILLER_20.WDAT_REL_DIA, FILLER_0.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -1665- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(FILLER_0.FILLER_20.WDAT_REL_MES, FILLER_0.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -1666- MOVE WDAT-REL-SEC TO WDAT-LIT-SEC */
            _.Move(FILLER_0.FILLER_20.WDAT_REL_SEC, FILLER_0.WDAT_REL_LIT.WDAT_LIT_SEC);

            /*" -1668- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(FILLER_0.FILLER_20.WDAT_REL_ANO, FILLER_0.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -1669- DISPLAY '*--------------------------------------------*' */
            _.Display($"*--------------------------------------------*");

            /*" -1670- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1671- DISPLAY '*  VG0145B - CONSISTENCIA LOGICA MOVIMENTO   *' */
            _.Display($"*  VG0145B - CONSISTENCIA LOGICA MOVIMENTO   *");

            /*" -1672- DISPLAY '*  -------   ------------ ------ ---------   *' */
            _.Display($"*  -------   ------------ ------ ---------   *");

            /*" -1673- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1674- DISPLAY '*     NAO HOUVE MOVIMENTACAO NESTA DATA      *' */
            _.Display($"*     NAO HOUVE MOVIMENTACAO NESTA DATA      *");

            /*" -1676- DISPLAY '*               ' WDAT-REL-LIT '                     *' */

            $"*               {FILLER_0.WDAT_REL_LIT}                     *"
            .Display();

            /*" -1677- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1677- DISPLAY '*--------------------------------------------*' . */
            _.Display($"*--------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1689- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1690- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, FILLER_0.FILLER_10.WABEND.WSQLCODE);

                /*" -1691- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], FILLER_0.FILLER_10.WABEND.WSQLCODE1);

                /*" -1692- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], FILLER_0.FILLER_10.WABEND.WSQLCODE2);

                /*" -1693- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, FILLER_0.WSQLCODE3);

                /*" -1694- DISPLAY WABEND */
                _.Display(FILLER_0.FILLER_10.WABEND);

                /*" -1695- MOVE SQLERRMC TO WSQLERRMC */
                _.Move(DB.SQLERRMC, FILLER_0.FILLER_10.WSQLERRO.WSQLERRMC);

                /*" -1696- DISPLAY WSQLERRO */
                _.Display(FILLER_0.FILLER_10.WSQLERRO);

                /*" -1697- DISPLAY SPACES */
                _.Display($"");

                /*" -1698- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), FILLER_0.WS_TIME);

                /*" -1700- DISPLAY 'LIDOS MOVIMENTO   ' AC-LIDOS-M ' ' WS-TIME. */

                $"LIDOS MOVIMENTO   {FILLER_0.AC_LIDOS_M} {FILLER_0.WS_TIME}"
                .Display();
            }


            /*" -1702- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1706- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1710- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1710- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}