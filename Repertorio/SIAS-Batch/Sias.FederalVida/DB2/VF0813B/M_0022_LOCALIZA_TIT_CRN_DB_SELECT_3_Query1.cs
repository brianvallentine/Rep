using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0813B
{
    public class M_0022_LOCALIZA_TIT_CRN_DB_SELECT_3_Query1 : QueryBasis<M_0022_LOCALIZA_TIT_CRN_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MIN(NRTIT),0)
            INTO :V0HCOB-NRTIT
            FROM SEGUROS.V0HISTCOBVA
            WHERE NRCERTIF = :V0HCTA-NRCERTIF
            AND NRPARCEL = :V0HCTA-NRPARCEL
            AND SITUACAO = '1'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MIN(NRTIT)
							,0)
											FROM SEGUROS.V0HISTCOBVA
											WHERE NRCERTIF = '{this.V0HCTA_NRCERTIF}'
											AND NRPARCEL = '{this.V0HCTA_NRPARCEL}'
											AND SITUACAO = '1'";

            return query;
        }
        public string V0HCOB_NRTIT { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0HCTA_NRPARCEL { get; set; }

        public static M_0022_LOCALIZA_TIT_CRN_DB_SELECT_3_Query1 Execute(M_0022_LOCALIZA_TIT_CRN_DB_SELECT_3_Query1 m_0022_LOCALIZA_TIT_CRN_DB_SELECT_3_Query1)
        {
            var ths = m_0022_LOCALIZA_TIT_CRN_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0022_LOCALIZA_TIT_CRN_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0022_LOCALIZA_TIT_CRN_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0HCOB_NRTIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}