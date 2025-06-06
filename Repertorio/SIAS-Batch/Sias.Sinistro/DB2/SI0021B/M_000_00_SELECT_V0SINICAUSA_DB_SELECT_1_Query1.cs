using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0021B
{
    public class M_000_00_SELECT_V0SINICAUSA_DB_SELECT_1_Query1 : QueryBasis<M_000_00_SELECT_V0SINICAUSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCAU
            INTO :V0SINICAUSA-DESCAU
            FROM SEGUROS.V0SINICAUSA
            WHERE CODCAU = :V1MEST-CODCAU
            AND RAMO = :V1MEST-RAMO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCAU
											FROM SEGUROS.V0SINICAUSA
											WHERE CODCAU = '{this.V1MEST_CODCAU}'
											AND RAMO = '{this.V1MEST_RAMO}'";

            return query;
        }
        public string V0SINICAUSA_DESCAU { get; set; }
        public string V1MEST_CODCAU { get; set; }
        public string V1MEST_RAMO { get; set; }

        public static M_000_00_SELECT_V0SINICAUSA_DB_SELECT_1_Query1 Execute(M_000_00_SELECT_V0SINICAUSA_DB_SELECT_1_Query1 m_000_00_SELECT_V0SINICAUSA_DB_SELECT_1_Query1)
        {
            var ths = m_000_00_SELECT_V0SINICAUSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_000_00_SELECT_V0SINICAUSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_000_00_SELECT_V0SINICAUSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SINICAUSA_DESCAU = result[i++].Value?.ToString();
            return dta;
        }

    }
}