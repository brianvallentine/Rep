using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5421B
{
    public class R120_SELECT_CDGCOBER_DB_SELECT_1_Query1 : QueryBasis<R120_SELECT_CDGCOBER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTTERVIG,
            OCORHIST,
            NRCERTIF
            INTO :V0CDGC-DTTERVIG,
            :V0CDGC-OCORHIST,
            :V0CDGC-NRCERTIF
            FROM SEGUROS.V0CDGCOBER
            WHERE CODCLIEN = :V0PROP-CODCLIEN
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTTERVIG
							,
											OCORHIST
							,
											NRCERTIF
											FROM SEGUROS.V0CDGCOBER
											WHERE CODCLIEN = '{this.V0PROP_CODCLIEN}'";

            return query;
        }
        public string V0CDGC_DTTERVIG { get; set; }
        public string V0CDGC_OCORHIST { get; set; }
        public string V0CDGC_NRCERTIF { get; set; }
        public string V0PROP_CODCLIEN { get; set; }

        public static R120_SELECT_CDGCOBER_DB_SELECT_1_Query1 Execute(R120_SELECT_CDGCOBER_DB_SELECT_1_Query1 r120_SELECT_CDGCOBER_DB_SELECT_1_Query1)
        {
            var ths = r120_SELECT_CDGCOBER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R120_SELECT_CDGCOBER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R120_SELECT_CDGCOBER_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CDGC_DTTERVIG = result[i++].Value?.ToString();
            dta.V0CDGC_OCORHIST = result[i++].Value?.ToString();
            dta.V0CDGC_NRCERTIF = result[i++].Value?.ToString();
            return dta;
        }

    }
}