using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0130B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_MORNATU_ATU
            , IMP_MORACID_ATU
            , PRM_VG_ATU
            , PRM_AP_ATU
            INTO :MIMP-MORNATU-ATU
            ,:MIMP-MORACID-ATU
            ,:MPRM-VG-ATU
            ,:MPRM-AP-ATU
            FROM SEGUROS.MOVIMENTO_VGAP
            WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF
            AND COD_OPERACAO BETWEEN 700 AND 899
            AND DATA_AVERBACAO IS NOT NULL
            AND DATA_INCLUSAO IS NULL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMP_MORNATU_ATU
											, IMP_MORACID_ATU
											, PRM_VG_ATU
											, PRM_AP_ATU
											FROM SEGUROS.MOVIMENTO_VGAP
											WHERE NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'
											AND COD_OPERACAO BETWEEN 700 AND 899
											AND DATA_AVERBACAO IS NOT NULL
											AND DATA_INCLUSAO IS NULL";

            return query;
        }
        public string MIMP_MORNATU_ATU { get; set; }
        public string MIMP_MORACID_ATU { get; set; }
        public string MPRM_VG_ATU { get; set; }
        public string MPRM_AP_ATU { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1();
            var i = 0;
            dta.MIMP_MORNATU_ATU = result[i++].Value?.ToString();
            dta.MIMP_MORACID_ATU = result[i++].Value?.ToString();
            dta.MPRM_VG_ATU = result[i++].Value?.ToString();
            dta.MPRM_AP_ATU = result[i++].Value?.ToString();
            return dta;
        }

    }
}