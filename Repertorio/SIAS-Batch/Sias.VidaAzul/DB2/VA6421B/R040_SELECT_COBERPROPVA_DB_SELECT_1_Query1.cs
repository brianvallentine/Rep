using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6421B
{
    public class R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1 : QueryBasis<R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMPSEGCDC,
            VLCUSTCDG
            INTO :V0COBV-IMPSEGCDG,
            :V0COBV-VLCUSTCDG
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND OCORHIST = :V0PROP-OCORHIST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMPSEGCDC
							,
											VLCUSTCDG
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND OCORHIST = '{this.V0PROP_OCORHIST}'";

            return query;
        }
        public string V0COBV_IMPSEGCDG { get; set; }
        public string V0COBV_VLCUSTCDG { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_OCORHIST { get; set; }

        public static R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1 Execute(R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1 r040_SELECT_COBERPROPVA_DB_SELECT_1_Query1)
        {
            var ths = r040_SELECT_COBERPROPVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0COBV_IMPSEGCDG = result[i++].Value?.ToString();
            dta.V0COBV_VLCUSTCDG = result[i++].Value?.ToString();
            return dta;
        }

    }
}