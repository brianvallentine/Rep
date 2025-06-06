using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R5000_00_GERA_PROXIMA_DB_SELECT_5_Query1 : QueryBasis<R5000_00_GERA_PROXIMA_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :V0MOVF-COUNT
            FROM SEGUROS.V0MOVFDCAPVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.V0MOVFDCAPVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											WITH UR";

            return query;
        }
        public string V0MOVF_COUNT { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R5000_00_GERA_PROXIMA_DB_SELECT_5_Query1 Execute(R5000_00_GERA_PROXIMA_DB_SELECT_5_Query1 r5000_00_GERA_PROXIMA_DB_SELECT_5_Query1)
        {
            var ths = r5000_00_GERA_PROXIMA_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5000_00_GERA_PROXIMA_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5000_00_GERA_PROXIMA_DB_SELECT_5_Query1();
            var i = 0;
            dta.V0MOVF_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}