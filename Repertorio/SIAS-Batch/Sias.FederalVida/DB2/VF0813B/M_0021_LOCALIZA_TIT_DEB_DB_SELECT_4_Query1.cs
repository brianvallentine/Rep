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
    public class M_0021_LOCALIZA_TIT_DEB_DB_SELECT_4_Query1 : QueryBasis<M_0021_LOCALIZA_TIT_DEB_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MIN(NRTIT),0)
            INTO :V0HCOB-NRTIT
            FROM SEGUROS.V0HISTCOBVA
            WHERE NRCERTIF = :V0HCTA-NRCERTIF
            AND SITUACAO IN ( '2' , '5' )
            AND VLPRMTOT = :V0HCOB-VLPRMTOT
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MIN(NRTIT)
							,0)
											FROM SEGUROS.V0HISTCOBVA
											WHERE NRCERTIF = '{this.V0HCTA_NRCERTIF}'
											AND SITUACAO IN ( '2' 
							, '5' )
											AND VLPRMTOT = '{this.V0HCOB_VLPRMTOT}'";

            return query;
        }
        public string V0HCOB_NRTIT { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0HCOB_VLPRMTOT { get; set; }

        public static M_0021_LOCALIZA_TIT_DEB_DB_SELECT_4_Query1 Execute(M_0021_LOCALIZA_TIT_DEB_DB_SELECT_4_Query1 m_0021_LOCALIZA_TIT_DEB_DB_SELECT_4_Query1)
        {
            var ths = m_0021_LOCALIZA_TIT_DEB_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0021_LOCALIZA_TIT_DEB_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0021_LOCALIZA_TIT_DEB_DB_SELECT_4_Query1();
            var i = 0;
            dta.V0HCOB_NRTIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}