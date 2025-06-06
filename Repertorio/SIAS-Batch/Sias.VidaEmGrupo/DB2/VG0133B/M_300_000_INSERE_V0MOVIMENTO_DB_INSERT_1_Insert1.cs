using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0133B
{
    public class M_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1_Insert1 : QueryBasis<M_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO
            SEGUROS.V0MOVIMENTO
            VALUES
            (:SNUM-APOLICE,
            :SCOD-SUBGRUPO,
            :SCOD-FONTE,
            :FONTE-PROPAUTOM,
            :STIPO-SEGURADO,
            :SNUM-CERTIFICADO,
            :SDAC-CERTIFICADO,
            :STIPO-INCLUSAO,
            :SCOD-CLIENTE,
            :SCOD-AGENCIADOR,
            :SCOD-CORRETOR,
            :SCOD-PLANOVGAP,
            :SCOD-PLANOAP,
            :SFAIXA,
            :SAUTOR-AUM-AUTOMAT,
            :STIPO-BENEFICIARIO,
            :SPERI-PAGAMENTO,
            :SPERI-RENOVACAO,
            :SCOD-OCUPACAO,
            :SESTADO-CIVIL,
            :SIDE-SEXO,
            :SCOD-PROFISSAO,
            :SNATURALIDADE,
            :SOCORR-ENDERECO,
            :SOCORR-END-COBRAN,
            :SBCO-COBRANCA,
            :SAGE-COBRANCA,
            :SDAC-COBRANCA,
            :SNUM-MATRICULA,
            :NUM-CTA-CORRENTE,
            :DAC-CTA-CORRENTE,
            :SVAL-SALARIO,
            :STIPO-SALARIO,
            :STIPO-PLANO,
            :SPCT-CONJUGE-VG,
            :SPCT-CONJUGE-AP,
            :SQTD-SAL-MORNATU,
            :SQTD-SAL-MORACID,
            :SQTD-SAL-INVPERM,
            :STAXA-AP-MORACID,
            :STAXA-AP-INVPERM,
            :STAXA-AP-AMDS,
            :STAXA-AP-DH,
            :STAXA-AP-DIT,
            :STAXA-VG,
            :MIMP-MORNATU-ANT,
            :MIMP-MORNATU-ATU,
            :MIMP-MORACID-ANT,
            :MIMP-MORACID-ATU,
            :MIMP-INVPERM-ANT,
            :MIMP-INVPERM-ATU,
            :MIMP-AMDS-ANT,
            :MIMP-AMDS-ATU,
            :MIMP-DH-ANT,
            :MIMP-DH-ATU,
            :MIMP-DIT-ANT,
            :MIMP-DIT-ATU,
            :MPRM-VG-ANT,
            :MPRM-VG-ATU,
            :MPRM-AP-ANT,
            :MPRM-AP-ATU,
            :MCOD-OPERACAO,
            :MDATA-OPERACAO,
            :COD-SUBGRUPO-TRANS,
            :MSIT-REGISTRO,
            :MCOD-USUARIO,
            :MDATA-AVERBACAO:WDATA-AVERBACAO,
            :MDATA-ADMISSAO:WDATA-ADMISSAO,
            :MDATA-INCLUSAO:WDATA-INCLUSAO,
            :MDATA-NASCIMENTO:WDATA-NASCIMENTO,
            :MDATA-FATURA:WDATA-FATURA,
            :MDATA-REFERENCIA:WDATA-REFERENCIA,
            :MDATA-MOVIMENTO:WDATA-MOVIMENTO,
            :MCOD-EMPRESA:WCOD-EMPRESA,
            :SLOT-EMP-SEGURADO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0MOVIMENTO VALUES ({FieldThreatment(this.SNUM_APOLICE)}, {FieldThreatment(this.SCOD_SUBGRUPO)}, {FieldThreatment(this.SCOD_FONTE)}, {FieldThreatment(this.FONTE_PROPAUTOM)}, {FieldThreatment(this.STIPO_SEGURADO)}, {FieldThreatment(this.SNUM_CERTIFICADO)}, {FieldThreatment(this.SDAC_CERTIFICADO)}, {FieldThreatment(this.STIPO_INCLUSAO)}, {FieldThreatment(this.SCOD_CLIENTE)}, {FieldThreatment(this.SCOD_AGENCIADOR)}, {FieldThreatment(this.SCOD_CORRETOR)}, {FieldThreatment(this.SCOD_PLANOVGAP)}, {FieldThreatment(this.SCOD_PLANOAP)}, {FieldThreatment(this.SFAIXA)}, {FieldThreatment(this.SAUTOR_AUM_AUTOMAT)}, {FieldThreatment(this.STIPO_BENEFICIARIO)}, {FieldThreatment(this.SPERI_PAGAMENTO)}, {FieldThreatment(this.SPERI_RENOVACAO)}, {FieldThreatment(this.SCOD_OCUPACAO)}, {FieldThreatment(this.SESTADO_CIVIL)}, {FieldThreatment(this.SIDE_SEXO)}, {FieldThreatment(this.SCOD_PROFISSAO)}, {FieldThreatment(this.SNATURALIDADE)}, {FieldThreatment(this.SOCORR_ENDERECO)}, {FieldThreatment(this.SOCORR_END_COBRAN)}, {FieldThreatment(this.SBCO_COBRANCA)}, {FieldThreatment(this.SAGE_COBRANCA)}, {FieldThreatment(this.SDAC_COBRANCA)}, {FieldThreatment(this.SNUM_MATRICULA)}, {FieldThreatment(this.NUM_CTA_CORRENTE)}, {FieldThreatment(this.DAC_CTA_CORRENTE)}, {FieldThreatment(this.SVAL_SALARIO)}, {FieldThreatment(this.STIPO_SALARIO)}, {FieldThreatment(this.STIPO_PLANO)}, {FieldThreatment(this.SPCT_CONJUGE_VG)}, {FieldThreatment(this.SPCT_CONJUGE_AP)}, {FieldThreatment(this.SQTD_SAL_MORNATU)}, {FieldThreatment(this.SQTD_SAL_MORACID)}, {FieldThreatment(this.SQTD_SAL_INVPERM)}, {FieldThreatment(this.STAXA_AP_MORACID)}, {FieldThreatment(this.STAXA_AP_INVPERM)}, {FieldThreatment(this.STAXA_AP_AMDS)}, {FieldThreatment(this.STAXA_AP_DH)}, {FieldThreatment(this.STAXA_AP_DIT)}, {FieldThreatment(this.STAXA_VG)}, {FieldThreatment(this.MIMP_MORNATU_ANT)}, {FieldThreatment(this.MIMP_MORNATU_ATU)}, {FieldThreatment(this.MIMP_MORACID_ANT)}, {FieldThreatment(this.MIMP_MORACID_ATU)}, {FieldThreatment(this.MIMP_INVPERM_ANT)}, {FieldThreatment(this.MIMP_INVPERM_ATU)}, {FieldThreatment(this.MIMP_AMDS_ANT)}, {FieldThreatment(this.MIMP_AMDS_ATU)}, {FieldThreatment(this.MIMP_DH_ANT)}, {FieldThreatment(this.MIMP_DH_ATU)}, {FieldThreatment(this.MIMP_DIT_ANT)}, {FieldThreatment(this.MIMP_DIT_ATU)}, {FieldThreatment(this.MPRM_VG_ANT)}, {FieldThreatment(this.MPRM_VG_ATU)}, {FieldThreatment(this.MPRM_AP_ANT)}, {FieldThreatment(this.MPRM_AP_ATU)}, {FieldThreatment(this.MCOD_OPERACAO)}, {FieldThreatment(this.MDATA_OPERACAO)}, {FieldThreatment(this.COD_SUBGRUPO_TRANS)}, {FieldThreatment(this.MSIT_REGISTRO)}, {FieldThreatment(this.MCOD_USUARIO)},  {FieldThreatment((this.WDATA_AVERBACAO?.ToInt() == -1 ? null : this.MDATA_AVERBACAO))},  {FieldThreatment((this.WDATA_ADMISSAO?.ToInt() == -1 ? null : this.MDATA_ADMISSAO))},  {FieldThreatment((this.WDATA_INCLUSAO?.ToInt() == -1 ? null : this.MDATA_INCLUSAO))},  {FieldThreatment((this.WDATA_NASCIMENTO?.ToInt() == -1 ? null : this.MDATA_NASCIMENTO))},  {FieldThreatment((this.WDATA_FATURA?.ToInt() == -1 ? null : this.MDATA_FATURA))},  {FieldThreatment((this.WDATA_REFERENCIA?.ToInt() == -1 ? null : this.MDATA_REFERENCIA))},  {FieldThreatment((this.WDATA_MOVIMENTO?.ToInt() == -1 ? null : this.MDATA_MOVIMENTO))},  {FieldThreatment((this.WCOD_EMPRESA?.ToInt() == -1 ? null : this.MCOD_EMPRESA))}, {FieldThreatment(this.SLOT_EMP_SEGURADO)})";

            return query;
        }
        public string SNUM_APOLICE { get; set; }
        public string SCOD_SUBGRUPO { get; set; }
        public string SCOD_FONTE { get; set; }
        public string FONTE_PROPAUTOM { get; set; }
        public string STIPO_SEGURADO { get; set; }
        public string SNUM_CERTIFICADO { get; set; }
        public string SDAC_CERTIFICADO { get; set; }
        public string STIPO_INCLUSAO { get; set; }
        public string SCOD_CLIENTE { get; set; }
        public string SCOD_AGENCIADOR { get; set; }
        public string SCOD_CORRETOR { get; set; }
        public string SCOD_PLANOVGAP { get; set; }
        public string SCOD_PLANOAP { get; set; }
        public string SFAIXA { get; set; }
        public string SAUTOR_AUM_AUTOMAT { get; set; }
        public string STIPO_BENEFICIARIO { get; set; }
        public string SPERI_PAGAMENTO { get; set; }
        public string SPERI_RENOVACAO { get; set; }
        public string SCOD_OCUPACAO { get; set; }
        public string SESTADO_CIVIL { get; set; }
        public string SIDE_SEXO { get; set; }
        public string SCOD_PROFISSAO { get; set; }
        public string SNATURALIDADE { get; set; }
        public string SOCORR_ENDERECO { get; set; }
        public string SOCORR_END_COBRAN { get; set; }
        public string SBCO_COBRANCA { get; set; }
        public string SAGE_COBRANCA { get; set; }
        public string SDAC_COBRANCA { get; set; }
        public string SNUM_MATRICULA { get; set; }
        public string NUM_CTA_CORRENTE { get; set; }
        public string DAC_CTA_CORRENTE { get; set; }
        public string SVAL_SALARIO { get; set; }
        public string STIPO_SALARIO { get; set; }
        public string STIPO_PLANO { get; set; }
        public string SPCT_CONJUGE_VG { get; set; }
        public string SPCT_CONJUGE_AP { get; set; }
        public string SQTD_SAL_MORNATU { get; set; }
        public string SQTD_SAL_MORACID { get; set; }
        public string SQTD_SAL_INVPERM { get; set; }
        public string STAXA_AP_MORACID { get; set; }
        public string STAXA_AP_INVPERM { get; set; }
        public string STAXA_AP_AMDS { get; set; }
        public string STAXA_AP_DH { get; set; }
        public string STAXA_AP_DIT { get; set; }
        public string STAXA_VG { get; set; }
        public string MIMP_MORNATU_ANT { get; set; }
        public string MIMP_MORNATU_ATU { get; set; }
        public string MIMP_MORACID_ANT { get; set; }
        public string MIMP_MORACID_ATU { get; set; }
        public string MIMP_INVPERM_ANT { get; set; }
        public string MIMP_INVPERM_ATU { get; set; }
        public string MIMP_AMDS_ANT { get; set; }
        public string MIMP_AMDS_ATU { get; set; }
        public string MIMP_DH_ANT { get; set; }
        public string MIMP_DH_ATU { get; set; }
        public string MIMP_DIT_ANT { get; set; }
        public string MIMP_DIT_ATU { get; set; }
        public string MPRM_VG_ANT { get; set; }
        public string MPRM_VG_ATU { get; set; }
        public string MPRM_AP_ANT { get; set; }
        public string MPRM_AP_ATU { get; set; }
        public string MCOD_OPERACAO { get; set; }
        public string MDATA_OPERACAO { get; set; }
        public string COD_SUBGRUPO_TRANS { get; set; }
        public string MSIT_REGISTRO { get; set; }
        public string MCOD_USUARIO { get; set; }
        public string MDATA_AVERBACAO { get; set; }
        public string WDATA_AVERBACAO { get; set; }
        public string MDATA_ADMISSAO { get; set; }
        public string WDATA_ADMISSAO { get; set; }
        public string MDATA_INCLUSAO { get; set; }
        public string WDATA_INCLUSAO { get; set; }
        public string MDATA_NASCIMENTO { get; set; }
        public string WDATA_NASCIMENTO { get; set; }
        public string MDATA_FATURA { get; set; }
        public string WDATA_FATURA { get; set; }
        public string MDATA_REFERENCIA { get; set; }
        public string WDATA_REFERENCIA { get; set; }
        public string MDATA_MOVIMENTO { get; set; }
        public string WDATA_MOVIMENTO { get; set; }
        public string MCOD_EMPRESA { get; set; }
        public string WCOD_EMPRESA { get; set; }
        public string SLOT_EMP_SEGURADO { get; set; }

        public static void Execute(M_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1_Insert1 m_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1_Insert1)
        {
            var ths = m_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}