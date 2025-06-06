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
using Sias.VidaEmGrupo.DB2.VG1625B;

namespace Code
{
    public class VG1625B
    {
        public bool IsCall { get; set; }

        public VG1625B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------  ---------                                              */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ................  VG - VIDA EM GRUPO (CONSORCIO)     *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG1625B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA................  TERCIO CARVALHO                    *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  TERCIO CARVALHO                    *      */
        /*"      *                                                                *      */
        /*"      *   DATA CODIFICACAO .......  SETEMBRO/2005                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  PREPARAR A COBERPROPVA COM OS DA-  *      */
        /*"      *                             DOS PARA O FATURAMENTO DOS SUBGRU- *      */
        /*"      *                             POS. PARA AS APOLICES ESPECIFICAS. *      */
        /*"      *                                  (SINDUSCON - CE)              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - PASSA A TRATAR PARCELA JA GERADA                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/03/2006 - FAST COMPUTER - TERCIO   PROCURE POR V.01    *      */
        /*"      *                                                                *      */
        /*"      *   CAD 11.971                                                   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - AJUSTE NO CAPITAL E PREMIO APOLICE SINDUSCONCE   *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/08/2008 - FAST COMPUTER - EDIVALDO PROCURE POR V.02    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 16/09/2008   INIBIR O COMANDO DISPLAY               - WV0908   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - CAD 31.817                                       *      */
        /*"      *                                                                *      */
        /*"      *               - AJUSTE NO CALCULO DO PREMIOVG.                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/10/2009 - FAST COMPUTER - TERCIO FREITAS               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - CAD 33.297                                       *      */
        /*"      *                                                                *      */
        /*"      *               - AJUSTE NA ROTINA R2400-00-SELECT-FXAETA-PLAVG  *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/12/2009 - FAST COMPUTER - TERCIO FREITAS               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
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
        /*"77  WHOST-PRMVG                   PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
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
        public VG1625B_WRETORNO_REG WRETORNO_REG { get; set; } = new VG1625B_WRETORNO_REG();
        public class VG1625B_WRETORNO_REG : VarBasis
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
        public VG1625B_FILLER_0 FILLER_0 { get; set; } = new VG1625B_FILLER_0();
        public class VG1625B_FILLER_0 : VarBasis
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
            public VG1625B_WS_W01DTSQL WS_W01DTSQL { get; set; } = new VG1625B_WS_W01DTSQL();
            public class VG1625B_WS_W01DTSQL : VarBasis
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
            public VG1625B_WS_W02DTSQL WS_W02DTSQL { get; set; } = new VG1625B_WS_W02DTSQL();
            public class VG1625B_WS_W02DTSQL : VarBasis
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
            public VG1625B_WS_W03DTSQL WS_W03DTSQL { get; set; } = new VG1625B_WS_W03DTSQL();
            public class VG1625B_WS_W03DTSQL : VarBasis
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
            public VG1625B_WS_W05DTREF WS_W05DTREF { get; set; } = new VG1625B_WS_W05DTREF();
            public class VG1625B_WS_W05DTREF : VarBasis
            {
                /*"    05          WS-W05AAREF         PIC  9(004).*/
                public IntBasis WS_W05AAREF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-W05MMREF         PIC  9(002).*/
                public IntBasis WS_W05MMREF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W05DDREF         PIC  9(002).*/
                public IntBasis WS_W05DDREF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-W02DTSQL-GERA.*/
            }
            public VG1625B_WS_W02DTSQL_GERA WS_W02DTSQL_GERA { get; set; } = new VG1625B_WS_W02DTSQL_GERA();
            public class VG1625B_WS_W02DTSQL_GERA : VarBasis
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
            public VG1625B_WK_DATA1 WK_DATA1 { get; set; } = new VG1625B_WK_DATA1();
            public class VG1625B_WK_DATA1 : VarBasis
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
            private _REDEF_VG1625B_WS_DATA_ADESAO_R _ws_data_adesao_r { get; set; }
            public _REDEF_VG1625B_WS_DATA_ADESAO_R WS_DATA_ADESAO_R
            {
                get { _ws_data_adesao_r = new _REDEF_VG1625B_WS_DATA_ADESAO_R(); _.Move(WS_DATA_ADESAO, _ws_data_adesao_r); VarBasis.RedefinePassValue(WS_DATA_ADESAO, _ws_data_adesao_r, WS_DATA_ADESAO); _ws_data_adesao_r.ValueChanged += () => { _.Move(_ws_data_adesao_r, WS_DATA_ADESAO); }; return _ws_data_adesao_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_adesao_r, WS_DATA_ADESAO); }
            }  //Redefines
            public class _REDEF_VG1625B_WS_DATA_ADESAO_R : VarBasis
            {
                /*"    10          WS-ANO-ADESAO     PIC  9(004).*/
                public IntBasis WS_ANO_ADESAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10          WS-MES-ADESAO     PIC  9(002).*/
                public IntBasis WS_MES_ADESAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          WS-DIA-ADESAO     PIC  9(002).*/
                public IntBasis WS_DIA_ADESAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-DATA-AUX.*/

                public _REDEF_VG1625B_WS_DATA_ADESAO_R()
                {
                    WS_ANO_ADESAO.ValueChanged += OnValueChanged;
                    WS_MES_ADESAO.ValueChanged += OnValueChanged;
                    WS_DIA_ADESAO.ValueChanged += OnValueChanged;
                }

            }
            public VG1625B_WS_DATA_AUX WS_DATA_AUX { get; set; } = new VG1625B_WS_DATA_AUX();
            public class VG1625B_WS_DATA_AUX : VarBasis
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
            public VG1625B_WS_DATA_INICIAL WS_DATA_INICIAL { get; set; } = new VG1625B_WS_DATA_INICIAL();
            public class VG1625B_WS_DATA_INICIAL : VarBasis
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
            public VG1625B_WS_DATA_FINAL WS_DATA_FINAL { get; set; } = new VG1625B_WS_DATA_FINAL();
            public class VG1625B_WS_DATA_FINAL : VarBasis
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
            public VG1625B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VG1625B_WS_DATA_SQL();
            public class VG1625B_WS_DATA_SQL : VarBasis
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
            public VG1625B_WS_DATA WS_DATA { get; set; } = new VG1625B_WS_DATA();
            public class VG1625B_WS_DATA : VarBasis
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
            private _REDEF_VG1625B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VG1625B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VG1625B_FILLER_5(); _.Move(W01GRUPOCOTA, _filler_5); VarBasis.RedefinePassValue(W01GRUPOCOTA, _filler_5, W01GRUPOCOTA); _filler_5.ValueChanged += () => { _.Move(_filler_5, W01GRUPOCOTA); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, W01GRUPOCOTA); }
            }  //Redefines
            public class _REDEF_VG1625B_FILLER_5 : VarBasis
            {
                /*"    10       W01-GRUPO         PIC  9(006).*/
                public IntBasis W01_GRUPO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       W01-COTA          PIC  9(003).*/
                public IntBasis W01_COTA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"  03         W01DTCSP          PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG1625B_FILLER_5()
                {
                    W01_GRUPO.ValueChanged += OnValueChanged;
                    W01_COTA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W01DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      W01DTCSP.*/
            private _REDEF_VG1625B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_VG1625B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_VG1625B_FILLER_6(); _.Move(W01DTCSP, _filler_6); VarBasis.RedefinePassValue(W01DTCSP, _filler_6, W01DTCSP); _filler_6.ValueChanged += () => { _.Move(_filler_6, W01DTCSP); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, W01DTCSP); }
            }  //Redefines
            public class _REDEF_VG1625B_FILLER_6 : VarBasis
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

                public _REDEF_VG1625B_FILLER_6()
                {
                    W01DDCSP.ValueChanged += OnValueChanged;
                    W01MMCSP.ValueChanged += OnValueChanged;
                    W01SCCSP.ValueChanged += OnValueChanged;
                    W01AACSP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W02DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      W02DTCSP.*/
            private _REDEF_VG1625B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_VG1625B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_VG1625B_FILLER_7(); _.Move(W02DTCSP, _filler_7); VarBasis.RedefinePassValue(W02DTCSP, _filler_7, W02DTCSP); _filler_7.ValueChanged += () => { _.Move(_filler_7, W02DTCSP); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, W02DTCSP); }
            }  //Redefines
            public class _REDEF_VG1625B_FILLER_7 : VarBasis
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

                public _REDEF_VG1625B_FILLER_7()
                {
                    W02DDCSP.ValueChanged += OnValueChanged;
                    W02MMCSP.ValueChanged += OnValueChanged;
                    W02SCCSP.ValueChanged += OnValueChanged;
                    W02AACSP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DTREF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03         FILLER            REDEFINES      WS-DTREF.*/
            private _REDEF_VG1625B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_VG1625B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_VG1625B_FILLER_8(); _.Move(WS_DTREF, _filler_8); VarBasis.RedefinePassValue(WS_DTREF, _filler_8, WS_DTREF); _filler_8.ValueChanged += () => { _.Move(_filler_8, WS_DTREF); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WS_DTREF); }
            }  //Redefines
            public class _REDEF_VG1625B_FILLER_8 : VarBasis
            {
                /*"    10       WS-REF-ANO        PIC  9(004).*/
                public IntBasis WS_REF_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS-REF-MES        PIC  9(002).*/
                public IntBasis WS_REF_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-DTREF-SQL      PIC  X(010).*/

                public _REDEF_VG1625B_FILLER_8()
                {
                    WS_REF_ANO.ValueChanged += OnValueChanged;
                    WS_REF_MES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DTREF_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03         FILLER            REDEFINES      WS-DTREF-SQL.*/
            private _REDEF_VG1625B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_VG1625B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_VG1625B_FILLER_9(); _.Move(WS_DTREF_SQL, _filler_9); VarBasis.RedefinePassValue(WS_DTREF_SQL, _filler_9, WS_DTREF_SQL); _filler_9.ValueChanged += () => { _.Move(_filler_9, WS_DTREF_SQL); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, WS_DTREF_SQL); }
            }  //Redefines
            public class _REDEF_VG1625B_FILLER_9 : VarBasis
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

                public _REDEF_VG1625B_FILLER_9()
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
            public VG1625B_FILLER_10 FILLER_10 { get; set; } = new VG1625B_FILLER_10();
            public class VG1625B_FILLER_10 : VarBasis
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
                public VG1625B_WABEND WABEND { get; set; } = new VG1625B_WABEND();
                public class VG1625B_WABEND : VarBasis
                {
                    /*"      05      FILLER              PIC  X(010) VALUE             ' VG1625B'.*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG1625B");
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
                public VG1625B_WSQLERRO WSQLERRO { get; set; } = new VG1625B_WSQLERRO();
                public class VG1625B_WSQLERRO : VarBasis
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
            private _REDEF_VG1625B_FILLER_18 _filler_18 { get; set; }
            public _REDEF_VG1625B_FILLER_18 FILLER_18
            {
                get { _filler_18 = new _REDEF_VG1625B_FILLER_18(); _.Move(W_NUMR_TITULO, _filler_18); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_18, W_NUMR_TITULO); _filler_18.ValueChanged += () => { _.Move(_filler_18, W_NUMR_TITULO); }; return _filler_18; }
                set { VarBasis.RedefinePassValue(value, _filler_18, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_VG1625B_FILLER_18 : VarBasis
            {
                /*"      05    WTITL-ZEROS              PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05    WTITL-SEQUENCIA          PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05    WTITL-DIGITO             PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03  DPARM01X.*/

                public _REDEF_VG1625B_FILLER_18()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public VG1625B_DPARM01X DPARM01X { get; set; } = new VG1625B_DPARM01X();
            public class VG1625B_DPARM01X : VarBasis
            {
                /*"      05            DPARM01          PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05            DPARM01-R        REDEFINES   DPARM01.*/
                private _REDEF_VG1625B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_VG1625B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_VG1625B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_VG1625B_DPARM01_R : VarBasis
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

                    public _REDEF_VG1625B_DPARM01_R()
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
            public VG1625B_FILLER_19 FILLER_19 { get; set; } = new VG1625B_FILLER_19();
            public class VG1625B_FILLER_19 : VarBasis
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
            private _REDEF_VG1625B_FILLER_20 _filler_20 { get; set; }
            public _REDEF_VG1625B_FILLER_20 FILLER_20
            {
                get { _filler_20 = new _REDEF_VG1625B_FILLER_20(); _.Move(WDATA_REL, _filler_20); VarBasis.RedefinePassValue(WDATA_REL, _filler_20, WDATA_REL); _filler_20.ValueChanged += () => { _.Move(_filler_20, WDATA_REL); }; return _filler_20; }
                set { VarBasis.RedefinePassValue(value, _filler_20, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VG1625B_FILLER_20 : VarBasis
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

                public _REDEF_VG1625B_FILLER_20()
                {
                    WDAT_REL_SEC.ValueChanged += OnValueChanged;
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_21.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_22.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VG1625B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VG1625B_WDAT_REL_LIT();
            public class VG1625B_WDAT_REL_LIT : VarBasis
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
            private _REDEF_VG1625B_FILLER_25 _filler_25 { get; set; }
            public _REDEF_VG1625B_FILLER_25 FILLER_25
            {
                get { _filler_25 = new _REDEF_VG1625B_FILLER_25(); _.Move(WDATA_ALTERACAO, _filler_25); VarBasis.RedefinePassValue(WDATA_ALTERACAO, _filler_25, WDATA_ALTERACAO); _filler_25.ValueChanged += () => { _.Move(_filler_25, WDATA_ALTERACAO); }; return _filler_25; }
                set { VarBasis.RedefinePassValue(value, _filler_25, WDATA_ALTERACAO); }
            }  //Redefines
            public class _REDEF_VG1625B_FILLER_25 : VarBasis
            {
                /*"    10       WCOR-ANO.*/
                public VG1625B_WCOR_ANO WCOR_ANO { get; set; } = new VG1625B_WCOR_ANO();
                public class VG1625B_WCOR_ANO : VarBasis
                {
                    /*"      15     WCOR-ANOS         PIC  9(002).*/
                    public IntBasis WCOR_ANOS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     WCOR-ANOA         PIC  9(002).*/
                    public IntBasis WCOR_ANOA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       WCOR-BR1          PIC  X(001).*/

                    public VG1625B_WCOR_ANO()
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

                public _REDEF_VG1625B_FILLER_25()
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
            private _REDEF_VG1625B_FILLER_26 _filler_26 { get; set; }
            public _REDEF_VG1625B_FILLER_26 FILLER_26
            {
                get { _filler_26 = new _REDEF_VG1625B_FILLER_26(); _.Move(WDATA_RETORNO, _filler_26); VarBasis.RedefinePassValue(WDATA_RETORNO, _filler_26, WDATA_RETORNO); _filler_26.ValueChanged += () => { _.Move(_filler_26, WDATA_RETORNO); }; return _filler_26; }
                set { VarBasis.RedefinePassValue(value, _filler_26, WDATA_RETORNO); }
            }  //Redefines
            public class _REDEF_VG1625B_FILLER_26 : VarBasis
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

                public _REDEF_VG1625B_FILLER_26()
                {
                    WRET_DIA.ValueChanged += OnValueChanged;
                    WRET_MES.ValueChanged += OnValueChanged;
                    WRET_SEC.ValueChanged += OnValueChanged;
                    WRET_ANO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATA_PARAMETRO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      WDATA-PARAMETRO.*/
            private _REDEF_VG1625B_FILLER_27 _filler_27 { get; set; }
            public _REDEF_VG1625B_FILLER_27 FILLER_27
            {
                get { _filler_27 = new _REDEF_VG1625B_FILLER_27(); _.Move(WDATA_PARAMETRO, _filler_27); VarBasis.RedefinePassValue(WDATA_PARAMETRO, _filler_27, WDATA_PARAMETRO); _filler_27.ValueChanged += () => { _.Move(_filler_27, WDATA_PARAMETRO); }; return _filler_27; }
                set { VarBasis.RedefinePassValue(value, _filler_27, WDATA_PARAMETRO); }
            }  //Redefines
            public class _REDEF_VG1625B_FILLER_27 : VarBasis
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

                public _REDEF_VG1625B_FILLER_27()
                {
                    WPAR_DIA.ValueChanged += OnValueChanged;
                    WPAR_MES.ValueChanged += OnValueChanged;
                    WPAR_SEC.ValueChanged += OnValueChanged;
                    WPAR_ANO.ValueChanged += OnValueChanged;
                }

            }
            public VG1625B_CHAVE_MOVIMENTO CHAVE_MOVIMENTO { get; set; } = new VG1625B_CHAVE_MOVIMENTO();
            public class VG1625B_CHAVE_MOVIMENTO : VarBasis
            {
                /*"    10      CH-MATRIC-MOV       PIC  9(015)  VALUE ZEROS.*/
                public IntBasis CH_MATRIC_MOV { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"  03        CHAVE-SEGURADO.*/
            }
            public VG1625B_CHAVE_SEGURADO CHAVE_SEGURADO { get; set; } = new VG1625B_CHAVE_SEGURADO();
            public class VG1625B_CHAVE_SEGURADO : VarBasis
            {
                /*"    10      CH-MATRIC-SEG       PIC  9(015)  VALUE ZEROS.*/
                public IntBasis CH_MATRIC_SEG { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"01    WS-HORAS.*/
            }
        }
        public VG1625B_WS_HORAS WS_HORAS { get; set; } = new VG1625B_WS_HORAS();
        public class VG1625B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VG1625B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VG1625B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VG1625B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VG1625B_WS_HORA_INI_R : VarBasis
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

                public _REDEF_VG1625B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VG1625B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VG1625B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VG1625B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VG1625B_WS_HORA_FIM_R : VarBasis
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

                public _REDEF_VG1625B_WS_HORA_FIM_R()
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
        public VG1625B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VG1625B_TOTAIS_ROT();
        public class VG1625B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<VG1625B_FILLER_28> FILLER_28 { get; set; } = new ListBasis<VG1625B_FILLER_28>(50);
            public class VG1625B_FILLER_28 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"01        LK-LINK.*/
            }
        }
        public VG1625B_LK_LINK LK_LINK { get; set; } = new VG1625B_LK_LINK();
        public class VG1625B_LK_LINK : VarBasis
        {
            /*"      05     LK-DATA1          PIC  9(008).*/
            public IntBasis LK_DATA1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"      05     LK-DATA2          PIC  9(008).*/
            public IntBasis LK_DATA2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"      05     QTDIA             PIC S9(005)          COMP-3.*/
            public IntBasis QTDIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"01         WPROSOMD2.*/
        }
        public VG1625B_WPROSOMD2 WPROSOMD2 { get; set; } = new VG1625B_WPROSOMD2();
        public class VG1625B_WPROSOMD2 : VarBasis
        {
            /*"    05       WDATA-INFORMADA   PIC  9(008).*/
            public IntBasis WDATA_INFORMADA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05       WDATA-QTDIAS      PIC S9(005)    COMP-3.*/
            public IntBasis WDATA_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"    05       WDATA-CALCULO     PIC  9(008).*/
            public IntBasis WDATA_CALCULO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"01        PARAMETROS.*/
        }
        public VG1625B_PARAMETROS PARAMETROS { get; set; } = new VG1625B_PARAMETROS();
        public class VG1625B_PARAMETROS : VarBasis
        {
            /*"    10      LK710-APOLICE               PIC S9(013) COMP-3.*/
            public IntBasis LK710_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    10      LK710-SUBGRUPO              PIC S9(004) COMP.*/
            public IntBasis LK710_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      LK710-IDADE                 PIC S9(004) COMP.*/
            public IntBasis LK710_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      LK710-NASCIMENTO.*/
            public VG1625B_LK710_NASCIMENTO LK710_NASCIMENTO { get; set; } = new VG1625B_LK710_NASCIMENTO();
            public class VG1625B_LK710_NASCIMENTO : VarBasis
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
            /*"01        PARAMETROS-702.*/
        }
        public VG1625B_PARAMETROS_702 PARAMETROS_702 { get; set; } = new VG1625B_PARAMETROS_702();
        public class VG1625B_PARAMETROS_702 : VarBasis
        {
            /*"    10      LK-APOLICE               PIC S9(013) COMP-3.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    10      LK-SUBGRUPO              PIC S9(004) COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      LK-IDADE                 PIC S9(004) COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      LK-NASCIMENTO.*/
            public VG1625B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VG1625B_LK_NASCIMENTO();
            public class VG1625B_LK_NASCIMENTO : VarBasis
            {
                /*"      15 LK-DATA-NASCIMENTO          PIC  9(008).*/
                public IntBasis LK_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10      LK-SALARIO               PIC S9(013)V99 COMP-3.*/
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
        public VG1625B_WS_MOVTO_CLIENTE WS_MOVTO_CLIENTE { get; set; } = new VG1625B_WS_MOVTO_CLIENTE();
        public class VG1625B_WS_MOVTO_CLIENTE : VarBasis
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
        public VG1625B_WS_PARAMETROS WS_PARAMETROS { get; set; } = new VG1625B_WS_PARAMETROS();
        public class VG1625B_WS_PARAMETROS : VarBasis
        {
            /*"  03            W01DIGCERT.*/
            public VG1625B_W01DIGCERT W01DIGCERT { get; set; } = new VG1625B_W01DIGCERT();
            public class VG1625B_W01DIGCERT : VarBasis
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
        public VG1625B_CPROPOVA CPROPOVA { get; set; } = new VG1625B_CPROPOVA();
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
            /*" -769- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -770- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -773- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -776- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -782- DISPLAY 'VG1625B - VERSAO V.04 - CADMUS 34.297' . */
            _.Display($"VG1625B - VERSAO V.04 - CADMUS 34.297");

            /*" -784- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -786- PERFORM R0100-00-SELECT-TSISTEMA. */

            R0100_00_SELECT_TSISTEMA_SECTION();

            /*" -788- PERFORM R0900-00-DECLA-PROPOVA. */

            R0900_00_DECLA_PROPOVA_SECTION();

            /*" -790- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

            /*" -791- IF WFIM-MOVIMENTO EQUAL 'SIM' */

            if (FILLER_0.FILLER_10.WFIM_MOVIMENTO == "SIM")
            {

                /*" -792- MOVE 01 TO RETURN-CODE */
                _.Move(01, RETURN_CODE);

                /*" -793- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -795- GO TO R9000-00-FINALIZA. */

                R9000_00_FINALIZA_SECTION(); //GOTO
                return;
            }


            /*" -798- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-MOVIMENTO EQUAL 'SIM' . */

            while (!(FILLER_0.FILLER_10.WFIM_MOVIMENTO == "SIM"))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -800- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -802- PERFORM R9000-00-FINALIZA. */

            R9000_00_FINALIZA_SECTION();

            /*" -802- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-TSISTEMA-SECTION */
        private void R0100_00_SELECT_TSISTEMA_SECTION()
        {
            /*" -815- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -821- PERFORM R0100_00_SELECT_TSISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_TSISTEMA_DB_SELECT_1();

            /*" -824- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -825- DISPLAY 'VG1625B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"VG1625B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -826- DISPLAY 'IDSISTEM =  VG ' */
                _.Display($"IDSISTEM =  VG ");

                /*" -828- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -829- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -830- DISPLAY 'VG1625B - ERRO NA LEITURA NA SISTEMAS  ' */
                _.Display($"VG1625B - ERRO NA LEITURA NA SISTEMAS  ");

                /*" -830- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-TSISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_TSISTEMA_DB_SELECT_1()
        {
            /*" -821- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' END-EXEC. */

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
            /*" -843- MOVE 'R0900-00-DECLA-PROPOVA ' TO PARAGRAFO. */
            _.Move("R0900-00-DECLA-PROPOVA ", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -844- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -863- PERFORM R0900_00_DECLA_PROPOVA_DB_DECLARE_1 */

            R0900_00_DECLA_PROPOVA_DB_DECLARE_1();

            /*" -867- PERFORM R0900_00_DECLA_PROPOVA_DB_OPEN_1 */

            R0900_00_DECLA_PROPOVA_DB_OPEN_1();

            /*" -872- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -873- DISPLAY 'PROBLEMAS NO OPEN (CPROPOVA) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CPROPOVA) ... ");

                /*" -873- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLA-PROPOVA-DB-DECLARE-1 */
        public void R0900_00_DECLA_PROPOVA_DB_DECLARE_1()
        {
            /*" -863- EXEC SQL DECLARE CPROPOVA CURSOR WITH HOLD FOR SELECT A.NUM_CERTIFICADO , A.NUM_APOLICE, A.COD_SUBGRUPO, A.NUM_PARCELA, A.OCORR_HISTORICO, A.DTPROXVEN FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.PRODUTOS_VG B WHERE B.ORIG_PRODU = 'ESPE1' AND A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND A.SIT_REGISTRO IN ( '3' , '6' ) AND A.DTPROXVEN <> '9999-12-31' ORDER BY A.NUM_APOLICE, A.COD_SUBGRUPO END-EXEC. */
            CPROPOVA = new VG1625B_CPROPOVA(false);
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
							FROM SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.PRODUTOS_VG B 
							WHERE B.ORIG_PRODU = 'ESPE1' 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.COD_SUBGRUPO = B.COD_SUBGRUPO 
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
            /*" -867- EXEC SQL OPEN CPROPOVA END-EXEC. */

            CPROPOVA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-SECTION */
        private void R0910_00_FETCH_PROPOVA_SECTION()
        {
            /*" -886- MOVE 'R0910-00-FETCH-PROPOVA' TO PARAGRAFO. */
            _.Move("R0910-00-FETCH-PROPOVA", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -890- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -897- PERFORM R0910_00_FETCH_PROPOVA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOVA_DB_FETCH_1();

            /*" -901- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -903- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -903- PERFORM R0910_00_FETCH_PROPOVA_DB_CLOSE_1 */

                    R0910_00_FETCH_PROPOVA_DB_CLOSE_1();

                    /*" -906- MOVE 'SIM' TO WFIM-MOVIMENTO */
                    _.Move("SIM", FILLER_0.FILLER_10.WFIM_MOVIMENTO);

                    /*" -907- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -908- ELSE */
                }
                else
                {


                    /*" -909- DISPLAY 'R0910-00 (ERRO -  FETCH CPROPOVA).. ' */
                    _.Display($"R0910-00 (ERRO -  FETCH CPROPOVA).. ");

                    /*" -911- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -914- ADD 1 TO AC-LIDOS AC-LIDOS-M. */
            FILLER_0.AC_LIDOS.Value = FILLER_0.AC_LIDOS + 1;
            FILLER_0.AC_LIDOS_M.Value = FILLER_0.AC_LIDOS_M + 1;

            /*" -915- IF AC-LIDOS GREATER 999 */

            if (FILLER_0.AC_LIDOS > 999)
            {

                /*" -916- MOVE ZEROS TO AC-LIDOS */
                _.Move(0, FILLER_0.AC_LIDOS);

                /*" -917- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), FILLER_0.WS_TIME);

                /*" -917- DISPLAY 'LIDOS MOVIMENTO ' AC-LIDOS-M ' ' WS-TIME. */

                $"LIDOS MOVIMENTO {FILLER_0.AC_LIDOS_M} {FILLER_0.WS_TIME}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOVA_DB_FETCH_1()
        {
            /*" -897- EXEC SQL FETCH CPROPOVA INTO :PROPOVA-NUM-CERTIFICADO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-NUM-PARCELA, :PROPOVA-OCORR-HISTORICO, :PROPOVA-DTPROXVEN END-EXEC. */

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
            /*" -903- EXEC SQL CLOSE CPROPOVA END-EXEC */

            CPROPOVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -932- MOVE 'R1000-00-PROCESSA-REGISTRO' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA-REGISTRO", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -936- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -938- PERFORM R2100-00-SELECT-SEGURVGA. */

            R2100_00_SELECT_SEGURVGA_SECTION();

            /*" -940- IF WTEM-SEGURVGA EQUAL 'SIM' */

            if (FILLER_0.FILLER_10.WTEM_SEGURVGA == "SIM")
            {

                /*" -941- MOVE 'N' TO WS-UPDATE */
                _.Move("N", FILLER_0.WS_UPDATE);

                /*" -943- PERFORM R2400-00-SELECT-FXAETA-PLAVG */

                R2400_00_SELECT_FXAETA_PLAVG_SECTION();

                /*" -950- COMPUTE WHOST-PRMVG = WHOST-QTDSEG * WHOST-PREMIO-VG */
                WHOST_PRMVG.Value = WHOST_QTDSEG * WHOST_PREMIO_VG;

                /*" -957- COMPUTE WHOST-IMPSEG = WHOST-QTDSEG * WHOST-IMP-MORNATU */
                WHOST_IMPSEG.Value = WHOST_QTDSEG * WHOST_IMP_MORNATU;

                /*" -958- ELSE */
            }
            else
            {


                /*" -959- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -961- END-IF. */
            }


            /*" -963- PERFORM R2200-00-SELECT-SUBGVGAP. */

            R2200_00_SELECT_SUBGVGAP_SECTION();

            /*" -965- PERFORM R2300-00-SELECT-COBERPROPVA. */

            R2300_00_SELECT_COBERPROPVA_SECTION();

            /*" -967- IF WPROCESSA EQUAL 'SIM' NEXT SENTENCE */

            if (FILLER_0.FILLER_10.WPROCESSA == "SIM")
            {

                /*" -968- ELSE */
            }
            else
            {


                /*" -969- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -971- END-IF. */
            }


            /*" -973- PERFORM R2250-00-SELECT-PARCEVID. */

            R2250_00_SELECT_PARCEVID_SECTION();

            /*" -974- IF WTEM-PARCEVID EQUAL 'SIM' */

            if (FILLER_0.FILLER_10.WTEM_PARCEVID == "SIM")
            {

                /*" -975- IF PARCEVID-SIT-REGISTRO EQUAL '1' */

                if (PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO == "1")
                {

                    /*" -976- ADD 1 TO AC-PAGOS */
                    FILLER_0.AC_PAGOS.Value = FILLER_0.AC_PAGOS + 1;

                    /*" -977- ELSE */
                }
                else
                {


                    /*" -978- IF PARCEVID-PREMIO-VG EQUAL WHOST-PRMVG */

                    if (PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG == WHOST_PRMVG)
                    {

                        /*" -979- ADD 1 TO AC-PREMIO-IGUAL */
                        FILLER_0.AC_PREMIO_IGUAL.Value = FILLER_0.AC_PREMIO_IGUAL + 1;

                        /*" -980- GO TO R1000-10-NEXT */

                        R1000_10_NEXT(); //GOTO
                        return;

                        /*" -981- ELSE */
                    }
                    else
                    {


                        /*" -982- ADD 1 TO AC-PREMIO-AJUSTADO */
                        FILLER_0.AC_PREMIO_AJUSTADO.Value = FILLER_0.AC_PREMIO_AJUSTADO + 1;

                        /*" -983- PERFORM R3000-00-AJUSTA-COBRANCA */

                        R3000_00_AJUSTA_COBRANCA_SECTION();

                        /*" -984- GO TO R1000-10-NEXT */

                        R1000_10_NEXT(); //GOTO
                        return;

                        /*" -985- END-IF */
                    }


                    /*" -986- END-IF */
                }


                /*" -988- END-IF. */
            }


            /*" -990- PERFORM R2910-00-UPDATE-COBERPROPVA. */

            R2910_00_UPDATE_COBERPROPVA_SECTION();

            /*" -991- IF HISCOBPR-IMP-MORNATU GREATER ZEROES */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU > 00)
            {

                /*" -992- IF WHOST-IMPSEG EQUAL HISCOBPR-IMP-MORNATU */

                if (WHOST_IMPSEG == HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU)
                {

                    /*" -994- MOVE 0 TO HISCOBPR-COD-OPERACAO */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                    /*" -995- ELSE */
                }
                else
                {


                    /*" -996- IF WHOST-IMPSEG LESS HISCOBPR-IMP-MORNATU */

                    if (WHOST_IMPSEG < HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU)
                    {

                        /*" -998- MOVE 701 TO HISCOBPR-COD-OPERACAO */
                        _.Move(701, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                        /*" -999- ELSE */
                    }
                    else
                    {


                        /*" -1001- MOVE 801 TO HISCOBPR-COD-OPERACAO */
                        _.Move(801, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                        /*" -1002- END-IF */
                    }


                    /*" -1003- END-IF */
                }


                /*" -1004- ELSE */
            }
            else
            {


                /*" -1005- IF WHOST-IMPSEG EQUAL HISCOBPR-IMPMORACID */

                if (WHOST_IMPSEG == HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID)
                {

                    /*" -1007- MOVE 0 TO HISCOBPR-COD-OPERACAO */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                    /*" -1008- ELSE */
                }
                else
                {


                    /*" -1009- IF WHOST-IMPSEG LESS HISCOBPR-IMPMORACID */

                    if (WHOST_IMPSEG < HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID)
                    {

                        /*" -1011- MOVE 701 TO HISCOBPR-COD-OPERACAO */
                        _.Move(701, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                        /*" -1012- ELSE */
                    }
                    else
                    {


                        /*" -1014- MOVE 801 TO HISCOBPR-COD-OPERACAO */
                        _.Move(801, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                        /*" -1015- END-IF */
                    }


                    /*" -1016- END-IF */
                }


                /*" -1018- END-IF. */
            }


            /*" -1020- PERFORM R2900-00-INSERT-COBERPROPVA. */

            R2900_00_INSERT_COBERPROPVA_SECTION();

            /*" -1020- PERFORM R2920-00-UPDATE-PROPOSTAVA. */

            R2920_00_UPDATE_PROPOSTAVA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1024- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-SEGURVGA-SECTION */
        private void R2100_00_SELECT_SEGURVGA_SECTION()
        {
            /*" -1037- MOVE 'R2100-00-SELECT-SEGURVGA' TO PARAGRAFO. */
            _.Move("R2100-00-SELECT-SEGURVGA", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1041- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1044- MOVE 'SIM' TO WTEM-SEGURVGA. */
            _.Move("SIM", FILLER_0.FILLER_10.WTEM_SEGURVGA);

            /*" -1052- PERFORM R2100_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R2100_00_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -1055- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1056- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1058- MOVE 'NAO' TO WTEM-SEGURVGA */
                    _.Move("NAO", FILLER_0.FILLER_10.WTEM_SEGURVGA);

                    /*" -1059- ELSE */
                }
                else
                {


                    /*" -1061- DISPLAY 'APOLICE = ' PROPOVA-NUM-APOLICE ' ' PROPOVA-COD-SUBGRUPO */

                    $"APOLICE = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}"
                    .Display();

                    /*" -1063- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1064- IF WHOST-QTDSEG EQUAL ZEROS */

            if (WHOST_QTDSEG == 00)
            {

                /*" -1065- MOVE 'NAO' TO WTEM-SEGURVGA. */
                _.Move("NAO", FILLER_0.FILLER_10.WTEM_SEGURVGA);
            }


        }

        [StopWatch]
        /*" R2100-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R2100_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -1052- EXEC SQL SELECT COUNT(*) INTO :WHOST-QTDSEG FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO AND SIT_REGISTRO IN ( '0' , '1' ) AND COD_PROFISSAO = 9999 END-EXEC. */

            var r2100_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 = new R2100_00_SELECT_SEGURVGA_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2100_00_SELECT_SEGURVGA_DB_SELECT_1_Query1.Execute(r2100_00_SELECT_SEGURVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTDSEG, WHOST_QTDSEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SELECT-SUBGVGAP-SECTION */
        private void R2200_00_SELECT_SUBGVGAP_SECTION()
        {
            /*" -1078- MOVE 'R2200-00-ACESSA-SUBGVGAP' TO PARAGRAFO. */
            _.Move("R2200-00-ACESSA-SUBGVGAP", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1082- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1088- PERFORM R2200_00_SELECT_SUBGVGAP_DB_SELECT_1 */

            R2200_00_SELECT_SUBGVGAP_DB_SELECT_1();

            /*" -1094- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1095- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1096- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1097- END-IF */
                }


                /*" -1097- END-IF. */
            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-SUBGVGAP-DB-SELECT-1 */
        public void R2200_00_SELECT_SUBGVGAP_DB_SELECT_1()
        {
            /*" -1088- EXEC SQL SELECT PERI_FATURAMENTO INTO :SUBGVGAP-PERI-FATURAMENTO FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO END-EXEC. */

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
        /*" R2250-00-SELECT-PARCEVID-SECTION */
        private void R2250_00_SELECT_PARCEVID_SECTION()
        {
            /*" -1110- MOVE 'R2250-00-SELECT-PARCEVID    ' TO PARAGRAFO. */
            _.Move("R2250-00-SELECT-PARCEVID    ", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1112- MOVE '2250' TO WNR-EXEC-SQL. */
            _.Move("2250", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1114- MOVE 'SIM' TO WTEM-PARCEVID */
            _.Move("SIM", FILLER_0.FILLER_10.WTEM_PARCEVID);

            /*" -1125- PERFORM R2250_00_SELECT_PARCEVID_DB_SELECT_1 */

            R2250_00_SELECT_PARCEVID_DB_SELECT_1();

            /*" -1128- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1129- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1130- MOVE 'NAO' TO WTEM-PARCEVID */
                    _.Move("NAO", FILLER_0.FILLER_10.WTEM_PARCEVID);

                    /*" -1131- ELSE */
                }
                else
                {


                    /*" -1133- DISPLAY 'ERRO  DE ACESSO A PARCELAS_VIDAZUL  ' ' ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-OCORR-HISTORICO */

                    $"ERRO  DE ACESSO A PARCELAS_VIDAZUL   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO}"
                    .Display();

                    /*" -1133- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2250-00-SELECT-PARCEVID-DB-SELECT-1 */
        public void R2250_00_SELECT_PARCEVID_DB_SELECT_1()
        {
            /*" -1125- EXEC SQL SELECT DATA_VENCIMENTO , PREMIO_VG , SIT_REGISTRO INTO :PARCEVID-DATA-VENCIMENTO , :PARCEVID-PREMIO-VG , :PARCEVID-SIT-REGISTRO FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-APOLICE AND NUM_PARCELA = :PROPOVA-OCORR-HISTORICO AND DATA_VENCIMENTO > :SISTEMAS-DATA-MOV-ABERTO END-EXEC. */

            var r2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1 = new R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                PROPOVA_OCORR_HISTORICO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1.Execute(r2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEVID_DATA_VENCIMENTO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO);
                _.Move(executed_1.PARCEVID_PREMIO_VG, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG);
                _.Move(executed_1.PARCEVID_SIT_REGISTRO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-SELECT-COBERPROPVA-SECTION */
        private void R2300_00_SELECT_COBERPROPVA_SECTION()
        {
            /*" -1147- MOVE 'R2300-00-SELECT-COBERPROPVA ' TO PARAGRAFO. */
            _.Move("R2300-00-SELECT-COBERPROPVA ", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1149- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1152- MOVE 'SIM' TO WPROCESSA. */
            _.Move("SIM", FILLER_0.FILLER_10.WPROCESSA);

            /*" -1207- PERFORM R2300_00_SELECT_COBERPROPVA_DB_SELECT_1 */

            R2300_00_SELECT_COBERPROPVA_DB_SELECT_1();

            /*" -1210- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1212- DISPLAY 'ERRO  DE ACESSO A HIS_COBER_PROPOST ' ' ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-OCORR-HISTORICO */

                $"ERRO  DE ACESSO A HIS_COBER_PROPOST  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO}"
                .Display();

                /*" -1217- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1219- IF WHOST-DATA-INIVIGENCIA > PROPOVA-DTPROXVEN OR WHOST-DATA-INIVIGENCIA = PROPOVA-DTPROXVEN */

            if (WHOST_DATA_INIVIGENCIA > PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN || WHOST_DATA_INIVIGENCIA == PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN)
            {

                /*" -1220- ADD 1 TO AC-DESPREZ-VIG */
                FILLER_0.AC_DESPREZ_VIG.Value = FILLER_0.AC_DESPREZ_VIG + 1;

                /*" -1222- MOVE 'NAO' TO WPROCESSA */
                _.Move("NAO", FILLER_0.FILLER_10.WPROCESSA);

                /*" -1222- END-IF. */
            }


        }

        [StopWatch]
        /*" R2300-00-SELECT-COBERPROPVA-DB-SELECT-1 */
        public void R2300_00_SELECT_COBERPROPVA_DB_SELECT_1()
        {
            /*" -1207- EXEC SQL SELECT NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA, DATA_INIVIGENCIA + :SUBGVGAP-PERI-FATURAMENTO MONTHS , DATA_TERVIGENCIA, IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO, OPCAO_COBERTURA, IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ , VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI , IMPSEGCDG , VLCUSTCDG , COD_USUARIO INTO :HISCOBPR-NUM-CERTIFICADO , :HISCOBPR-OCORR-HISTORICO , :HISCOBPR-DATA-INIVIGENCIA , :WHOST-DATA-INIVIGENCIA , :HISCOBPR-DATA-TERVIGENCIA , :HISCOBPR-IMPSEGUR , :HISCOBPR-QUANT-VIDAS , :HISCOBPR-IMPSEGIND , :HISCOBPR-COD-OPERACAO, :HISCOBPR-OPCAO-COBERTURA, :HISCOBPR-IMP-MORNATU , :HISCOBPR-IMPMORACID , :HISCOBPR-IMPINVPERM , :HISCOBPR-IMPAMDS , :HISCOBPR-IMPDH , :HISCOBPR-IMPDIT , :HISCOBPR-VLPREMIO , :HISCOBPR-PRMVG , :HISCOBPR-PRMAP , :HISCOBPR-QTDE-TIT-CAPITALIZ, :HISCOBPR-VAL-TIT-CAPITALIZ, :HISCOBPR-VAL-CUSTO-CAPITALI, :HISCOBPR-IMPSEGCDG , :HISCOBPR-VLCUSTCDG , :HISCOBPR-COD-USUARIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = :PROPOVA-OCORR-HISTORICO END-EXEC. */

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
        /*" R2400-00-SELECT-FXAETA-PLAVG-SECTION */
        private void R2400_00_SELECT_FXAETA_PLAVG_SECTION()
        {
            /*" -1236- MOVE 'R2400-00-SELECT-FXAETA-PLAVG' TO PARAGRAFO. */
            _.Move("R2400-00-SELECT-FXAETA-PLAVG", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1238- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1254- PERFORM R2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1 */

            R2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1();

            /*" -1257- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1258- IF SQLCODE EQUAL 100 AND WS-UPDATE EQUAL 'N' */

                if (DB.SQLCODE == 100 && FILLER_0.WS_UPDATE == "N")
                {

                    /*" -1259- PERFORM R2450-SELECT-00-MAX-PLAN */

                    R2450_SELECT_00_MAX_PLAN_SECTION();

                    /*" -1260- ELSE */
                }
                else
                {


                    /*" -1261- IF SQLCODE EQUAL -811 AND WS-UPDATE EQUAL 'N' */

                    if (DB.SQLCODE == -811 && FILLER_0.WS_UPDATE == "N")
                    {

                        /*" -1262- PERFORM R2460-SELECT-00-MIN-PLAN */

                        R2460_SELECT_00_MIN_PLAN_SECTION();

                        /*" -1263- ELSE */
                    }
                    else
                    {


                        /*" -1266- DISPLAY 'ERRO  DE ACESSO A PLANOS_FAIXAETA ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-COD-SUBGRUPO ' ' PROPOVA-NUM-APOLICE */

                        $"ERRO  DE ACESSO A PLANOS_FAIXAETA {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}"
                        .Display();

                        /*" -1267- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1268- END-IF */
                    }


                    /*" -1269- END-IF */
                }


                /*" -1270- GO TO R2400-00-SELECT-FXAETA-PLAVG */
                new Task(() => R2400_00_SELECT_FXAETA_PLAVG_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1272- END-IF */
            }


            /*" -1273- MOVE PLANOFAI-PRM-VG TO WHOST-PREMIO-VG */
            _.Move(PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_PRM_VG, WHOST_PREMIO_VG);

            /*" -1273- MOVE PLANOVGA-IMP-MORNATU TO WHOST-IMP-MORNATU. */
            _.Move(PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_MORNATU, WHOST_IMP_MORNATU);

        }

        [StopWatch]
        /*" R2400-00-SELECT-FXAETA-PLAVG-DB-SELECT-1 */
        public void R2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1()
        {
            /*" -1254- EXEC SQL SELECT A.PRM_VG + A.PRM_AP , B.IMP_MORNATU INTO :PLANOFAI-PRM-VG, :PLANOVGA-IMP-MORNATU FROM SEGUROS.PLANOS_FAIXAETA A, SEGUROS.PLANOS_VGAP B, SEGUROS.SUBGRUPOS_VGAP C WHERE A.NUM_APOLICE = :PROPOVA-NUM-APOLICE AND B.SIT_REGISTRO = '0' AND C.COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.COD_PLANO = A.COD_PLANO AND C.NUM_APOLICE = A.NUM_APOLICE AND C.COD_SUBGRUPO = A.COD_SUBGRUPO END-EXEC. */

            var r2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1_Query1 = new R2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1_Query1.Execute(r2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLANOFAI_PRM_VG, PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_PRM_VG);
                _.Move(executed_1.PLANOVGA_IMP_MORNATU, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_MORNATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2450-SELECT-00-MAX-PLAN-SECTION */
        private void R2450_SELECT_00_MAX_PLAN_SECTION()
        {
            /*" -1287- MOVE '2450-SELECT-00-MAX-PLAN' TO PARAGRAFO */
            _.Move("2450-SELECT-00-MAX-PLAN", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1296- PERFORM R2450_SELECT_00_MAX_PLAN_DB_SELECT_1 */

            R2450_SELECT_00_MAX_PLAN_DB_SELECT_1();

            /*" -1299- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1302- DISPLAY 'ERRO  DE ACESSO A PLANOS_VGAP ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-COD-SUBGRUPO ' ' PROPOVA-NUM-APOLICE */

                $"ERRO  DE ACESSO A PLANOS_VGAP {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}"
                .Display();

                /*" -1303- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1304- ELSE */
            }
            else
            {


                /*" -1305- MOVE '0' TO WS-SIT-REGISTRO */
                _.Move("0", FILLER_0.WS_SIT_REGISTRO);

                /*" -1306- PERFORM R2470-UPDATE-PLAN-VGAP */

                R2470_UPDATE_PLAN_VGAP_SECTION();

                /*" -1306- END-IF. */
            }


        }

        [StopWatch]
        /*" R2450-SELECT-00-MAX-PLAN-DB-SELECT-1 */
        public void R2450_SELECT_00_MAX_PLAN_DB_SELECT_1()
        {
            /*" -1296- EXEC SQL SELECT VALUE (MAX (COD_PLANO),0) INTO :PLANOVGA-COD-PLANO FROM SEGUROS.PLANOS_VGAP WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO END-EXEC */

            var r2450_SELECT_00_MAX_PLAN_DB_SELECT_1_Query1 = new R2450_SELECT_00_MAX_PLAN_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2450_SELECT_00_MAX_PLAN_DB_SELECT_1_Query1.Execute(r2450_SELECT_00_MAX_PLAN_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLANOVGA_COD_PLANO, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_PLANO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/

        [StopWatch]
        /*" R2460-SELECT-00-MIN-PLAN-SECTION */
        private void R2460_SELECT_00_MIN_PLAN_SECTION()
        {
            /*" -1320- MOVE '2460-SELECT-00-MIN-PLAN' TO PARAGRAFO */
            _.Move("2460-SELECT-00-MIN-PLAN", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1330- PERFORM R2460_SELECT_00_MIN_PLAN_DB_SELECT_1 */

            R2460_SELECT_00_MIN_PLAN_DB_SELECT_1();

            /*" -1333- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1336- DISPLAY 'ERRO  DE ACESSO A PLANOS_FAIXAETA ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-COD-SUBGRUPO ' ' PROPOVA-NUM-APOLICE */

                $"ERRO  DE ACESSO A PLANOS_FAIXAETA {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}"
                .Display();

                /*" -1337- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1338- ELSE */
            }
            else
            {


                /*" -1339- MOVE ' ' TO WS-SIT-REGISTRO */
                _.Move(" ", FILLER_0.WS_SIT_REGISTRO);

                /*" -1340- PERFORM R2470-UPDATE-PLAN-VGAP */

                R2470_UPDATE_PLAN_VGAP_SECTION();

                /*" -1340- END-IF. */
            }


        }

        [StopWatch]
        /*" R2460-SELECT-00-MIN-PLAN-DB-SELECT-1 */
        public void R2460_SELECT_00_MIN_PLAN_DB_SELECT_1()
        {
            /*" -1330- EXEC SQL SELECT VALUE (MIN (COD_PLANO),0) INTO :PLANOVGA-COD-PLANO FROM SEGUROS.PLANOS_VGAP WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND SIT_REGISTRO = '0' AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO END-EXEC */

            var r2460_SELECT_00_MIN_PLAN_DB_SELECT_1_Query1 = new R2460_SELECT_00_MIN_PLAN_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2460_SELECT_00_MIN_PLAN_DB_SELECT_1_Query1.Execute(r2460_SELECT_00_MIN_PLAN_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLANOVGA_COD_PLANO, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_PLANO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2460_99_SAIDA*/

        [StopWatch]
        /*" R2470-UPDATE-PLAN-VGAP-SECTION */
        private void R2470_UPDATE_PLAN_VGAP_SECTION()
        {
            /*" -1353- MOVE '2470-SELECT-00-MIN-PLAN' TO PARAGRAFO */
            _.Move("2470-SELECT-00-MIN-PLAN", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1359- PERFORM R2470_UPDATE_PLAN_VGAP_DB_UPDATE_1 */

            R2470_UPDATE_PLAN_VGAP_DB_UPDATE_1();

            /*" -1362- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1365- DISPLAY 'ERRO NO UPDATE NA PLANOS_VGAP ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-COD-SUBGRUPO ' ' PROPOVA-NUM-APOLICE ' ' */

                $"ERRO NO UPDATE NA PLANOS_VGAP {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE} "
                .Display();

                /*" -1366- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1368- END-IF */
            }


            /*" -1368- MOVE 'S' TO WS-UPDATE. */
            _.Move("S", FILLER_0.WS_UPDATE);

        }

        [StopWatch]
        /*" R2470-UPDATE-PLAN-VGAP-DB-UPDATE-1 */
        public void R2470_UPDATE_PLAN_VGAP_DB_UPDATE_1()
        {
            /*" -1359- EXEC SQL UPDATE SEGUROS.PLANOS_VGAP SET SIT_REGISTRO = :WS-SIT-REGISTRO WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_PLANO = :PLANOVGA-COD-PLANO AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO END-EXEC */

            var r2470_UPDATE_PLAN_VGAP_DB_UPDATE_1_Update1 = new R2470_UPDATE_PLAN_VGAP_DB_UPDATE_1_Update1()
            {
                WS_SIT_REGISTRO = FILLER_0.WS_SIT_REGISTRO.ToString(),
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                PLANOVGA_COD_PLANO = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_PLANO.ToString(),
            };

            R2470_UPDATE_PLAN_VGAP_DB_UPDATE_1_Update1.Execute(r2470_UPDATE_PLAN_VGAP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2470_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-INSERT-COBERPROPVA-SECTION */
        private void R2900_00_INSERT_COBERPROPVA_SECTION()
        {
            /*" -1384- MOVE 'R2900-00-INSERT-COBERPROPVA' TO PARAGRAFO */
            _.Move("R2900-00-INSERT-COBERPROPVA", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1386- INITIALIZE PARAMETROS. */
            _.Initialize(
                PARAMETROS
            );

            /*" -1388- MOVE PROPOVA-NUM-APOLICE TO LK710-APOLICE OF PARAMETROS. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, PARAMETROS.LK710_APOLICE);

            /*" -1393- MOVE PROPOVA-COD-SUBGRUPO TO LK710-SUBGRUPO OF PARAMETROS. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, PARAMETROS.LK710_SUBGRUPO);

            /*" -1395- MOVE WHOST-IMPSEG TO LK710-PU-MORTE-NATURAL OF PARAMETROS. */
            _.Move(WHOST_IMPSEG, PARAMETROS.LK710_PU_MORTE_NATURAL);

            /*" -1398- MOVE ZEROS TO LK710-PU-MORTE-ACIDENTAL OF PARAMETROS. */
            _.Move(0, PARAMETROS.LK710_PU_MORTE_ACIDENTAL);

            /*" -1400- CALL 'VG0710S' USING PARAMETROS. */
            _.Call("VG0710S", PARAMETROS);

            /*" -1401- IF LK710-RETURN-CODE NOT EQUAL ZEROS */

            if (PARAMETROS.LK710_RETURN_CODE != 00)
            {

                /*" -1402- DISPLAY '** PROBLEMA COM SUBROTINA VG0710S **' */
                _.Display($"** PROBLEMA COM SUBROTINA VG0710S **");

                /*" -1403- DISPLAY 'CERTIF. : ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIF. : {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1404- DISPLAY 'MENSAGEM DA VG0710S -> ' LK710-MENSAGEM */
                _.Display($"MENSAGEM DA VG0710S -> {PARAMETROS.LK710_MENSAGEM}");

                /*" -1406- DISPLAY 'COD.ERRO DA VG0710S -> ' LK710-RETURN-CODE */
                _.Display($"COD.ERRO DA VG0710S -> {PARAMETROS.LK710_RETURN_CODE}");

                /*" -1408- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1410- MOVE LK710-CO-MORTE-NATURAL TO HISCOBPR-IMP-MORNATU. */
            _.Move(PARAMETROS.LK710_CO_MORTE_NATURAL, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);

            /*" -1412- MOVE LK710-CO-MORTE-NATURAL TO HISCOBPR-IMPSEGIND. */
            _.Move(PARAMETROS.LK710_CO_MORTE_NATURAL, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND);

            /*" -1414- MOVE LK710-CO-MORTE-NATURAL TO HISCOBPR-IMPSEGUR. */
            _.Move(PARAMETROS.LK710_CO_MORTE_NATURAL, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);

            /*" -1416- MOVE LK710-CO-MORTE-ACIDENTAL TO HISCOBPR-IMPMORACID. */
            _.Move(PARAMETROS.LK710_CO_MORTE_ACIDENTAL, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);

            /*" -1418- MOVE LK710-CO-INV-PERMANENTE TO HISCOBPR-IMPINVPERM. */
            _.Move(PARAMETROS.LK710_CO_INV_PERMANENTE, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);

            /*" -1420- MOVE LK710-CO-ASS-MEDICA TO HISCOBPR-IMPAMDS. */
            _.Move(PARAMETROS.LK710_CO_ASS_MEDICA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS);

            /*" -1422- MOVE LK710-CO-DI-HOSPITALAR TO HISCOBPR-IMPDH. */
            _.Move(PARAMETROS.LK710_CO_DI_HOSPITALAR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH);

            /*" -1425- MOVE LK710-CO-DI-INTERNACAO TO HISCOBPR-IMPDIT. */
            _.Move(PARAMETROS.LK710_CO_DI_INTERNACAO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT);

            /*" -1427- IF HISCOBPR-IMP-MORNATU = ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU == 00)
            {

                /*" -1430- MOVE HISCOBPR-IMPMORACID TO HISCOBPR-IMPSEGIND HISCOBPR-IMPSEGUR */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);

                /*" -1431- ELSE */
            }
            else
            {


                /*" -1435- MOVE HISCOBPR-IMP-MORNATU TO HISCOBPR-IMPSEGIND HISCOBPR-IMPSEGUR. */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);
            }


            /*" -1437- MOVE 0 TO HISCOBPR-QTDE-TIT-CAPITALIZ */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ);

            /*" -1439- MOVE 0,00 TO HISCOBPR-VAL-TIT-CAPITALIZ */
            _.Move(0.00, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ);

            /*" -1442- MOVE 0,00 TO HISCOBPR-VAL-CUSTO-CAPITALI */
            _.Move(0.00, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI);

            /*" -1446- MOVE ZEROS TO HISCOBPR-IMPSEGCDG HISCOBPR-VLCUSTCDG. */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG);

            /*" -1448- MOVE WHOST-DATA-INIVIGENCIA TO HISCOBPR-DATA-INIVIGENCIA. */
            _.Move(WHOST_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);

            /*" -1451- MOVE '9999-12-31' TO HISCOBPR-DATA-TERVIGENCIA. */
            _.Move("9999-12-31", HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

            /*" -1454- COMPUTE PROPOVA-OCORR-HISTORICO = PROPOVA-OCORR-HISTORICO + 1 */
            PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.Value = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO + 1;

            /*" -1457- MOVE PROPOVA-OCORR-HISTORICO TO HISCOBPR-OCORR-HISTORICO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO);

            /*" -1459- MOVE WHOST-PRMVG TO HISCOBPR-PRMVG. */
            _.Move(WHOST_PRMVG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);

            /*" -1462- MOVE 0 TO HISCOBPR-PRMAP. */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);

            /*" -1465- MOVE WHOST-QTDSEG TO HISCOBPR-QUANT-VIDAS. */
            _.Move(WHOST_QTDSEG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS);

            /*" -1468- COMPUTE HISCOBPR-VLPREMIO = HISCOBPR-PRMVG + HISCOBPR-PRMAP. */
            HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP;

            /*" -1470- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1531- PERFORM R2900_00_INSERT_COBERPROPVA_DB_INSERT_1 */

            R2900_00_INSERT_COBERPROPVA_DB_INSERT_1();

            /*" -1534- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1535- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1539- MOVE 'S' TO WTEM-COBERPROPVA */
                    _.Move("S", FILLER_0.FILLER_10.WTEM_COBERPROPVA);

                    /*" -1540- ELSE */
                }
                else
                {


                    /*" -1543- DISPLAY 'PROBLEMA INSERT HIS_COBER_PROPOST     ..' PROPOVA-NUM-CERTIFICADO ' ' HISCOBPR-OCORR-HISTORICO ' ' HISCOBPR-DATA-INIVIGENCIA ' ' ' ' SQLCODE */

                    $"PROBLEMA INSERT HIS_COBER_PROPOST     ..{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO} {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA}  {DB.SQLCODE}"
                    .Display();

                    /*" -1544- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1545- ELSE */
                }

            }
            else
            {


                /*" -1547- MOVE 'N' TO WTEM-COBERPROPVA. */
                _.Move("N", FILLER_0.FILLER_10.WTEM_COBERPROPVA);
            }


            /*" -1547- ADD 1 TO AC-I-COBERPROPVA. */
            FILLER_0.AC_I_COBERPROPVA.Value = FILLER_0.AC_I_COBERPROPVA + 1;

        }

        [StopWatch]
        /*" R2900-00-INSERT-COBERPROPVA-DB-INSERT-1 */
        public void R2900_00_INSERT_COBERPROPVA_DB_INSERT_1()
        {
            /*" -1531- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI, IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT ) VALUES (:PROPOVA-NUM-CERTIFICADO, :HISCOBPR-OCORR-HISTORICO, :HISCOBPR-DATA-INIVIGENCIA, :HISCOBPR-DATA-TERVIGENCIA, :HISCOBPR-IMPSEGUR, :HISCOBPR-QUANT-VIDAS, :HISCOBPR-IMPSEGIND, :HISCOBPR-COD-OPERACAO, ' ' , :HISCOBPR-IMP-MORNATU, :HISCOBPR-IMPMORACID, :HISCOBPR-IMPINVPERM, :HISCOBPR-IMPAMDS, :HISCOBPR-IMPDH, :HISCOBPR-IMPDIT, :HISCOBPR-VLPREMIO, :HISCOBPR-PRMVG, :HISCOBPR-PRMAP, :HISCOBPR-QTDE-TIT-CAPITALIZ, :HISCOBPR-VAL-TIT-CAPITALIZ, :HISCOBPR-VAL-CUSTO-CAPITALI, :HISCOBPR-IMPSEGCDG, :HISCOBPR-VLCUSTCDG, 'VG1625B' , CURRENT TIMESTAMP, NULL, NULL, NULL, NULL) END-EXEC. */

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
            /*" -1561- MOVE 'R2910-00-UPDATE-COBERPROPVA' TO PARAGRAFO. */
            _.Move("R2910-00-UPDATE-COBERPROPVA", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1565- MOVE '2910' TO WNR-EXEC-SQL. */
            _.Move("2910", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1573- PERFORM R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1 */

            R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1();

            /*" -1576- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1577- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1579- DISPLAY 'ERRO  DE ACESSO A HIS_COBER_PROPOST ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"ERRO  DE ACESSO A HIS_COBER_PROPOST {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1579- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2910-00-UPDATE-COBERPROPVA-DB-UPDATE-1 */
        public void R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1()
        {
            /*" -1573- EXEC SQL UPDATE SEGUROS.HIS_COBER_PROPOST SET DATA_TERVIGENCIA = DATA_INIVIGENCIA + :SUBGVGAP-PERI-FATURAMENTO MONTHS - 1 DAY WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = :PROPOVA-OCORR-HISTORICO END-EXEC. */

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
            /*" -1593- MOVE 'R2920-00-UPDATE-PROPOSTAVA ' TO PARAGRAFO. */
            _.Move("R2920-00-UPDATE-PROPOSTAVA ", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1597- MOVE '4200' TO WNR-EXEC-SQL. */
            _.Move("4200", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1603- PERFORM R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1 */

            R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1();

            /*" -1606- MOVE '4200' TO WNR-EXEC-SQL. */
            _.Move("4200", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1607- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1609- DISPLAY 'ERRO  DE ACESSO A PROPOSTAS_VA ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"ERRO  DE ACESSO A PROPOSTAS_VA {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1609- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2920-00-UPDATE-PROPOSTAVA-DB-UPDATE-1 */
        public void R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1()
        {
            /*" -1603- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET OCORR_HISTORICO = :HISCOBPR-OCORR-HISTORICO, NUM_PARCELA = :PROPOVA-NUM-PARCELA + 1 WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

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
        /*" R3000-00-AJUSTA-COBRANCA-SECTION */
        private void R3000_00_AJUSTA_COBRANCA_SECTION()
        {
            /*" -1622- MOVE 'R3000-00-PROCESSA-REGISTRO' TO PARAGRAFO. */
            _.Move("R3000-00-PROCESSA-REGISTRO", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1626- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1628- PERFORM R3100-00-UPDATE-COBERPROPVA. */

            R3100_00_UPDATE_COBERPROPVA_SECTION();

            /*" -1630- PERFORM R3200-00-UPDATE-PARCELVA. */

            R3200_00_UPDATE_PARCELVA_SECTION();

            /*" -1630- PERFORM R3300-00-UPDATE-HISTCOBVA. */

            R3300_00_UPDATE_HISTCOBVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-UPDATE-COBERPROPVA-SECTION */
        private void R3100_00_UPDATE_COBERPROPVA_SECTION()
        {
            /*" -1644- MOVE 'R3100-00-UPDATE-COBERPROPVA' TO PARAGRAFO. */
            _.Move("R3100-00-UPDATE-COBERPROPVA", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1656- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1666- PERFORM R3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1 */

            R3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1();

            /*" -1669- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1671- DISPLAY 'ERRO  DE ACESSO A HIS_COBER_PROPOST ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"ERRO  DE ACESSO A HIS_COBER_PROPOST {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1681- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1681- ADD 1 TO AC-U-COBERPROPVA. */
            FILLER_0.AC_U_COBERPROPVA.Value = FILLER_0.AC_U_COBERPROPVA + 1;

        }

        [StopWatch]
        /*" R3100-00-UPDATE-COBERPROPVA-DB-UPDATE-1 */
        public void R3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1()
        {
            /*" -1666- EXEC SQL UPDATE SEGUROS.HIS_COBER_PROPOST SET IMPSEGUR = :WHOST-IMPSEG, IMPSEGIND = :WHOST-IMPSEG, IMP_MORNATU = :WHOST-IMPSEG, QUANT_VIDAS = :WHOST-QTDSEG, VLPREMIO = :WHOST-PRMVG, PRMVG = :WHOST-PRMVG WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = :PROPOVA-OCORR-HISTORICO END-EXEC. */

            var r3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1 = new R3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1()
            {
                WHOST_IMPSEG = WHOST_IMPSEG.ToString(),
                WHOST_QTDSEG = WHOST_QTDSEG.ToString(),
                WHOST_PRMVG = WHOST_PRMVG.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_OCORR_HISTORICO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.ToString(),
            };

            R3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1.Execute(r3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-UPDATE-PARCELVA-SECTION */
        private void R3200_00_UPDATE_PARCELVA_SECTION()
        {
            /*" -1695- MOVE 'R3200-00-UPDATE-PARCELVA   ' TO PARAGRAFO. */
            _.Move("R3200-00-UPDATE-PARCELVA   ", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1699- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1704- PERFORM R3200_00_UPDATE_PARCELVA_DB_UPDATE_1 */

            R3200_00_UPDATE_PARCELVA_DB_UPDATE_1();

            /*" -1707- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1709- DISPLAY 'ERRO  DE ACESSO A PARCELAS_VIDAZUL  ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"ERRO  DE ACESSO A PARCELAS_VIDAZUL  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1711- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1711- ADD 1 TO AC-U-PARCELVA. */
            FILLER_0.AC_U_PARCELVA.Value = FILLER_0.AC_U_PARCELVA + 1;

        }

        [StopWatch]
        /*" R3200-00-UPDATE-PARCELVA-DB-UPDATE-1 */
        public void R3200_00_UPDATE_PARCELVA_DB_UPDATE_1()
        {
            /*" -1704- EXEC SQL UPDATE SEGUROS.PARCELAS_VIDAZUL SET PREMIO_VG = :WHOST-PRMVG WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA = :PROPOVA-OCORR-HISTORICO END-EXEC. */

            var r3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1 = new R3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1()
            {
                WHOST_PRMVG = WHOST_PRMVG.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_OCORR_HISTORICO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.ToString(),
            };

            R3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1.Execute(r3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-UPDATE-HISTCOBVA-SECTION */
        private void R3300_00_UPDATE_HISTCOBVA_SECTION()
        {
            /*" -1725- MOVE 'R3300-00-UPDATE-HISTCOBVA  ' TO PARAGRAFO. */
            _.Move("R3300-00-UPDATE-HISTCOBVA  ", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1729- MOVE '3300' TO WNR-EXEC-SQL. */
            _.Move("3300", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1735- PERFORM R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1 */

            R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1();

            /*" -1738- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1740- DISPLAY 'ERRO  DE ACESSO A COBER_HIST_VIDAZUL' PROPOVA-NUM-CERTIFICADO */
                _.Display($"ERRO  DE ACESSO A COBER_HIST_VIDAZUL{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1742- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1742- ADD 1 TO AC-U-HISTCOBVA. */
            FILLER_0.AC_U_HISTCOBVA.Value = FILLER_0.AC_U_HISTCOBVA + 1;

        }

        [StopWatch]
        /*" R3300-00-UPDATE-HISTCOBVA-DB-UPDATE-1 */
        public void R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1()
        {
            /*" -1735- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET PRM_TOTAL = :WHOST-PRMVG, SIT_REGISTRO = '5' WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA = :PROPOVA-OCORR-HISTORICO END-EXEC. */

            var r3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1 = new R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1()
            {
                WHOST_PRMVG = WHOST_PRMVG.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_OCORR_HISTORICO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.ToString(),
            };

            R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1.Execute(r3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-FINALIZA-SECTION */
        private void R9000_00_FINALIZA_SECTION()
        {
            /*" -1756- MOVE 'R9000-00-FINALIZA' TO PARAGRAFO. */
            _.Move("R9000-00-FINALIZA", FILLER_0.FILLER_10.WABEND.PARAGRAFO);

            /*" -1760- MOVE '8100' TO WNR-EXEC-SQL */
            _.Move("8100", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1762- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", FILLER_0.FILLER_10.WABEND.WNR_EXEC_SQL);

            /*" -1763- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -1764- DISPLAY 'PROGRAMA VG1625B ' */
            _.Display($"PROGRAMA VG1625B ");

            /*" -1765- DISPLAY 'TOTAIS PARA CONTROLE ' */
            _.Display($"TOTAIS PARA CONTROLE ");

            /*" -1766- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -1767- DISPLAY 'LIDOS DA PROPOSTAVA                 = ' AC-LIDOS-M */
            _.Display($"LIDOS DA PROPOSTAVA                 = {FILLER_0.AC_LIDOS_M}");

            /*" -1768- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -1769- DISPLAY ' .INCLUSOES                           ' */
            _.Display($" .INCLUSOES                           ");

            /*" -1771- DISPLAY '   COBERPROPVA                      = ' AC-I-COBERPROPVA. */
            _.Display($"   COBERPROPVA                      = {FILLER_0.AC_I_COBERPROPVA}");

            /*" -1772- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -1773- DISPLAY ' .ATUALIZACOES                        ' */
            _.Display($" .ATUALIZACOES                        ");

            /*" -1775- DISPLAY '   COBERPROPVA                      = ' AC-U-COBERPROPVA. */
            _.Display($"   COBERPROPVA                      = {FILLER_0.AC_U_COBERPROPVA}");

            /*" -1777- DISPLAY '   PARCELVA                         = ' AC-U-PARCELVA. */
            _.Display($"   PARCELVA                         = {FILLER_0.AC_U_PARCELVA}");

            /*" -1779- DISPLAY '   HISTCOBVA                        = ' AC-U-HISTCOBVA. */
            _.Display($"   HISTCOBVA                        = {FILLER_0.AC_U_HISTCOBVA}");

            /*" -1780- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -1781- DISPLAY ' .ESTATISTICAS                        ' */
            _.Display($" .ESTATISTICAS                        ");

            /*" -1782- DISPLAY '   PARCELAS JA PAGAS                = ' AC-PAGOS */
            _.Display($"   PARCELAS JA PAGAS                = {FILLER_0.AC_PAGOS}");

            /*" -1784- DISPLAY '   PARCELAS COM PREMIO IGUAL        = ' AC-PREMIO-IGUAL */
            _.Display($"   PARCELAS COM PREMIO IGUAL        = {FILLER_0.AC_PREMIO_IGUAL}");

            /*" -1786- DISPLAY '   PARCELAS COM PREMIO AJUSTADO     = ' AC-PREMIO-AJUSTADO */
            _.Display($"   PARCELAS COM PREMIO AJUSTADO     = {FILLER_0.AC_PREMIO_AJUSTADO}");

            /*" -1789- DISPLAY '   DESPREZADOS VIGENCIA             = ' AC-DESPREZ-VIG */
            _.Display($"   DESPREZADOS VIGENCIA             = {FILLER_0.AC_DESPREZ_VIG}");

            /*" -1790- DISPLAY '-------------------------------------' */
            _.Display($"-------------------------------------");

            /*" -1791- DISPLAY ' ' */
            _.Display($" ");

            /*" -1793- DISPLAY ' *** VG1625B - FIM NORMAL ' . */
            _.Display($" *** VG1625B - FIM NORMAL ");

            /*" -1793- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1795- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1807- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FILLER_0.WDATA_REL);

            /*" -1808- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(FILLER_0.FILLER_20.WDAT_REL_DIA, FILLER_0.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -1809- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(FILLER_0.FILLER_20.WDAT_REL_MES, FILLER_0.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -1810- MOVE WDAT-REL-SEC TO WDAT-LIT-SEC */
            _.Move(FILLER_0.FILLER_20.WDAT_REL_SEC, FILLER_0.WDAT_REL_LIT.WDAT_LIT_SEC);

            /*" -1812- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(FILLER_0.FILLER_20.WDAT_REL_ANO, FILLER_0.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -1813- DISPLAY '*--------------------------------------------*' */
            _.Display($"*--------------------------------------------*");

            /*" -1814- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1815- DISPLAY '*  VG1625B - CONSISTENCIA LOGICA MOVIMENTO   *' */
            _.Display($"*  VG1625B - CONSISTENCIA LOGICA MOVIMENTO   *");

            /*" -1816- DISPLAY '*  -------   ------------ ------ ---------   *' */
            _.Display($"*  -------   ------------ ------ ---------   *");

            /*" -1817- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1818- DISPLAY '*     NAO HOUVE MOVIMENTACAO NESTA DATA      *' */
            _.Display($"*     NAO HOUVE MOVIMENTACAO NESTA DATA      *");

            /*" -1820- DISPLAY '*               ' WDAT-REL-LIT '                     *' */

            $"*               {FILLER_0.WDAT_REL_LIT}                     *"
            .Display();

            /*" -1821- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1821- DISPLAY '*--------------------------------------------*' . */
            _.Display($"*--------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1833- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1834- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, FILLER_0.FILLER_10.WABEND.WSQLCODE);

                /*" -1835- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], FILLER_0.FILLER_10.WABEND.WSQLCODE1);

                /*" -1836- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], FILLER_0.FILLER_10.WABEND.WSQLCODE2);

                /*" -1837- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, FILLER_0.WSQLCODE3);

                /*" -1838- DISPLAY WABEND */
                _.Display(FILLER_0.FILLER_10.WABEND);

                /*" -1839- MOVE SQLERRMC TO WSQLERRMC */
                _.Move(DB.SQLERRMC, FILLER_0.FILLER_10.WSQLERRO.WSQLERRMC);

                /*" -1840- DISPLAY WSQLERRO */
                _.Display(FILLER_0.FILLER_10.WSQLERRO);

                /*" -1841- DISPLAY SPACES */
                _.Display($"");

                /*" -1842- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), FILLER_0.WS_TIME);

                /*" -1844- DISPLAY 'LIDOS MOVIMENTO   ' AC-LIDOS-M ' ' WS-TIME. */

                $"LIDOS MOVIMENTO   {FILLER_0.AC_LIDOS_M} {FILLER_0.WS_TIME}"
                .Display();
            }


            /*" -1846- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1850- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1854- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1854- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}