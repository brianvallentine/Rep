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
    public class R090_SELECT_SAFCOBER_DB_SELECT_1_Query1 : QueryBasis<R090_SELECT_SAFCOBER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTTERVIG,
            OCORHIST,
            NRCERTIF
            INTO :V0SAFC-DTTERVIG,
            :V0SAFC-OCORHIST,
            :V0SAFC-NRCERTIF
            FROM SEGUROS.V0SAFCOBER
            WHERE CODCLIEN = :V0PROP-CODCLIEN
            AND DTINIVIG <= :V0SIST-DTMOVABE
            AND DTTERVIG >= :V0SIST-DTMOVABE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTTERVIG
							,
											OCORHIST
							,
											NRCERTIF
											FROM SEGUROS.V0SAFCOBER
											WHERE CODCLIEN = '{this.V0PROP_CODCLIEN}'
											AND DTINIVIG <= '{this.V0SIST_DTMOVABE}'
											AND DTTERVIG >= '{this.V0SIST_DTMOVABE}'";

            return query;
        }
        public string V0SAFC_DTTERVIG { get; set; }
        public string V0SAFC_OCORHIST { get; set; }
        public string V0SAFC_NRCERTIF { get; set; }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0SIST_DTMOVABE { get; set; }

        public static R090_SELECT_SAFCOBER_DB_SELECT_1_Query1 Execute(R090_SELECT_SAFCOBER_DB_SELECT_1_Query1 r090_SELECT_SAFCOBER_DB_SELECT_1_Query1)
        {
            var ths = r090_SELECT_SAFCOBER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R090_SELECT_SAFCOBER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R090_SELECT_SAFCOBER_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SAFC_DTTERVIG = result[i++].Value?.ToString();
            dta.V0SAFC_OCORHIST = result[i++].Value?.ToString();
            dta.V0SAFC_NRCERTIF = result[i++].Value?.ToString();
            return dta;
        }

    }
}