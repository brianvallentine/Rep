using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0815B
{
    public class R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1 : QueryBasis<R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            PCCOMCOS
            INTO
            :V1APCC-PCCOMCOS
            FROM
            SEGUROS.V1APOLCOSCED
            WHERE
            NUM_APOLICE = :V1CHIS-NUM-APOL
            AND CODCOSS = :V1CHIS-CONGENER
            AND DTINIVIG <= :V0ENDO-DTINIVIG
            AND DTTERVIG >= :V0ENDO-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											PCCOMCOS
											FROM
											SEGUROS.V1APOLCOSCED
											WHERE
											NUM_APOLICE = '{this.V1CHIS_NUM_APOL}'
											AND CODCOSS = '{this.V1CHIS_CONGENER}'
											AND DTINIVIG <= '{this.V0ENDO_DTINIVIG}'
											AND DTTERVIG >= '{this.V0ENDO_DTINIVIG}'";

            return query;
        }
        public string V1APCC_PCCOMCOS { get; set; }
        public string V1CHIS_NUM_APOL { get; set; }
        public string V1CHIS_CONGENER { get; set; }
        public string V0ENDO_DTINIVIG { get; set; }

        public static R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1 Execute(R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1 r1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1)
        {
            var ths = r1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1900_00_SELECT_V1APOLCOSCED_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1APCC_PCCOMCOS = result[i++].Value?.ToString();
            return dta;
        }

    }
}