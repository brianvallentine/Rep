using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0010B
{
    public class M_180_000_INCLUI_V0SEGURAVG_DB_INSERT_1_Insert1 : QueryBasis<M_180_000_INCLUI_V0SEGURAVG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO
            SEGUROS.V0SEGURAVG
            VALUES (:MNUM-APOLICE,
            :MCOD-SUBGRUPO,
            :MNUM-CERTIFICADO,
            :DAC-CERTIFICADO,
            :MTIPO-SEGURADO,
            :SNUM-ITEM,
            :MTIPO-INCLUSAO,
            :MCOD-CLIENTE,
            :MCOD-FONTE,
            :MNUM-PROPOSTA,
            :MCOD-AGENCIADOR,
            :MCOD-CORRETOR,
            :MCOD-PLANOVGAP,
            :MCOD-PLANOAP,
            :MFAIXA,
            :MAUTOR-AUM-AUTOMAT,
            :MTIPO-BENEFICIARIO,
            :SEGUR-OCORHIST,
            :MPERI-PAGAMENTO,
            :MPERI-RENOVACAO,
            0,
            :MCOD-OCUPACAO,
            :MESTADO-CIVIL,
            :MIDE-SEXO,
            :MCOD-PROFISSAO,
            :MNATURALIDADE,
            :MOCORR-ENDERECO,
            :MOCORR-END-COBRAN,
            :MBCO-COBRANCA,
            :MAGE-COBRANCA,
            :MDAC-COBRANCA,
            :MNUM-MATRICULA,
            :MVAL-SALARIO,
            :MTIPO-SALARIO,
            :MTIPO-PLANO,
            :MDATA-MOVIMENTO,
            :MPCT-CONJUGE-VG,
            :MPCT-CONJUGE-AP,
            :MQTD-SAL-MORNATU,
            :MQTD-SAL-MORACID,
            :MQTD-SAL-INVPERM,
            :MTAXA-AP-MORACID,
            :MTAXA-AP-INVPERM,
            :MTAXA-AP-AMDS,
            :MTAXA-AP-DH,
            :MTAXA-AP-DIT,
            0,
            :MTAXA-VG,
            '0' ,
            :MDATA-RENOVACAO:WDATA-RENOVACAO,
            :MDATA-NASCIMENTO:WDATA-NASCIMENTO,
            :MCOD-EMPRESA:WCOD-EMPRESA,
            NULL,
            :MLOT-EMP-SEGURADO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0SEGURAVG VALUES ({FieldThreatment(this.MNUM_APOLICE)}, {FieldThreatment(this.MCOD_SUBGRUPO)}, {FieldThreatment(this.MNUM_CERTIFICADO)}, {FieldThreatment(this.DAC_CERTIFICADO)}, {FieldThreatment(this.MTIPO_SEGURADO)}, {FieldThreatment(this.SNUM_ITEM)}, {FieldThreatment(this.MTIPO_INCLUSAO)}, {FieldThreatment(this.MCOD_CLIENTE)}, {FieldThreatment(this.MCOD_FONTE)}, {FieldThreatment(this.MNUM_PROPOSTA)}, {FieldThreatment(this.MCOD_AGENCIADOR)}, {FieldThreatment(this.MCOD_CORRETOR)}, {FieldThreatment(this.MCOD_PLANOVGAP)}, {FieldThreatment(this.MCOD_PLANOAP)}, {FieldThreatment(this.MFAIXA)}, {FieldThreatment(this.MAUTOR_AUM_AUTOMAT)}, {FieldThreatment(this.MTIPO_BENEFICIARIO)}, {FieldThreatment(this.SEGUR_OCORHIST)}, {FieldThreatment(this.MPERI_PAGAMENTO)}, {FieldThreatment(this.MPERI_RENOVACAO)}, 0, {FieldThreatment(this.MCOD_OCUPACAO)}, {FieldThreatment(this.MESTADO_CIVIL)}, {FieldThreatment(this.MIDE_SEXO)}, {FieldThreatment(this.MCOD_PROFISSAO)}, {FieldThreatment(this.MNATURALIDADE)}, {FieldThreatment(this.MOCORR_ENDERECO)}, {FieldThreatment(this.MOCORR_END_COBRAN)}, {FieldThreatment(this.MBCO_COBRANCA)}, {FieldThreatment(this.MAGE_COBRANCA)}, {FieldThreatment(this.MDAC_COBRANCA)}, {FieldThreatment(this.MNUM_MATRICULA)}, {FieldThreatment(this.MVAL_SALARIO)}, {FieldThreatment(this.MTIPO_SALARIO)}, {FieldThreatment(this.MTIPO_PLANO)}, {FieldThreatment(this.MDATA_MOVIMENTO)}, {FieldThreatment(this.MPCT_CONJUGE_VG)}, {FieldThreatment(this.MPCT_CONJUGE_AP)}, {FieldThreatment(this.MQTD_SAL_MORNATU)}, {FieldThreatment(this.MQTD_SAL_MORACID)}, {FieldThreatment(this.MQTD_SAL_INVPERM)}, {FieldThreatment(this.MTAXA_AP_MORACID)}, {FieldThreatment(this.MTAXA_AP_INVPERM)}, {FieldThreatment(this.MTAXA_AP_AMDS)}, {FieldThreatment(this.MTAXA_AP_DH)}, {FieldThreatment(this.MTAXA_AP_DIT)}, 0, {FieldThreatment(this.MTAXA_VG)}, '0' ,  {FieldThreatment((this.WDATA_RENOVACAO?.ToInt() == -1 ? null : this.MDATA_RENOVACAO))},  {FieldThreatment((this.WDATA_NASCIMENTO?.ToInt() == -1 ? null : this.MDATA_NASCIMENTO))},  {FieldThreatment((this.WCOD_EMPRESA?.ToInt() == -1 ? null : this.MCOD_EMPRESA))}, NULL, {FieldThreatment(this.MLOT_EMP_SEGURADO)})";

            return query;
        }
        public string MNUM_APOLICE { get; set; }
        public string MCOD_SUBGRUPO { get; set; }
        public string MNUM_CERTIFICADO { get; set; }
        public string DAC_CERTIFICADO { get; set; }
        public string MTIPO_SEGURADO { get; set; }
        public string SNUM_ITEM { get; set; }
        public string MTIPO_INCLUSAO { get; set; }
        public string MCOD_CLIENTE { get; set; }
        public string MCOD_FONTE { get; set; }
        public string MNUM_PROPOSTA { get; set; }
        public string MCOD_AGENCIADOR { get; set; }
        public string MCOD_CORRETOR { get; set; }
        public string MCOD_PLANOVGAP { get; set; }
        public string MCOD_PLANOAP { get; set; }
        public string MFAIXA { get; set; }
        public string MAUTOR_AUM_AUTOMAT { get; set; }
        public string MTIPO_BENEFICIARIO { get; set; }
        public string SEGUR_OCORHIST { get; set; }
        public string MPERI_PAGAMENTO { get; set; }
        public string MPERI_RENOVACAO { get; set; }
        public string MCOD_OCUPACAO { get; set; }
        public string MESTADO_CIVIL { get; set; }
        public string MIDE_SEXO { get; set; }
        public string MCOD_PROFISSAO { get; set; }
        public string MNATURALIDADE { get; set; }
        public string MOCORR_ENDERECO { get; set; }
        public string MOCORR_END_COBRAN { get; set; }
        public string MBCO_COBRANCA { get; set; }
        public string MAGE_COBRANCA { get; set; }
        public string MDAC_COBRANCA { get; set; }
        public string MNUM_MATRICULA { get; set; }
        public string MVAL_SALARIO { get; set; }
        public string MTIPO_SALARIO { get; set; }
        public string MTIPO_PLANO { get; set; }
        public string MDATA_MOVIMENTO { get; set; }
        public string MPCT_CONJUGE_VG { get; set; }
        public string MPCT_CONJUGE_AP { get; set; }
        public string MQTD_SAL_MORNATU { get; set; }
        public string MQTD_SAL_MORACID { get; set; }
        public string MQTD_SAL_INVPERM { get; set; }
        public string MTAXA_AP_MORACID { get; set; }
        public string MTAXA_AP_INVPERM { get; set; }
        public string MTAXA_AP_AMDS { get; set; }
        public string MTAXA_AP_DH { get; set; }
        public string MTAXA_AP_DIT { get; set; }
        public string MTAXA_VG { get; set; }
        public string MDATA_RENOVACAO { get; set; }
        public string WDATA_RENOVACAO { get; set; }
        public string MDATA_NASCIMENTO { get; set; }
        public string WDATA_NASCIMENTO { get; set; }
        public string MCOD_EMPRESA { get; set; }
        public string WCOD_EMPRESA { get; set; }
        public string MLOT_EMP_SEGURADO { get; set; }

        public static void Execute(M_180_000_INCLUI_V0SEGURAVG_DB_INSERT_1_Insert1 m_180_000_INCLUI_V0SEGURAVG_DB_INSERT_1_Insert1)
        {
            var ths = m_180_000_INCLUI_V0SEGURAVG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_180_000_INCLUI_V0SEGURAVG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}