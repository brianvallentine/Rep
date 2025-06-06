using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU9303B
{
    public class R0085_00_SELECT_V0AUTOPROP_DB_SELECT_1_Query1 : QueryBasis<R0085_00_SELECT_V0AUTOPROP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO
            INTO :V0AUTP-SITUACAO
            FROM SEGUROS.V0AUTOPROP
            WHERE FONTE = :V1AUTA-FONTE
            AND NRPROPOS = :V1AUTA-NRPROPOS
            AND NRITEM = :V1AUTA-NRITEM
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
											FROM SEGUROS.V0AUTOPROP
											WHERE FONTE = '{this.V1AUTA_FONTE}'
											AND NRPROPOS = '{this.V1AUTA_NRPROPOS}'
											AND NRITEM = '{this.V1AUTA_NRITEM}'";

            return query;
        }
        public string V0AUTP_SITUACAO { get; set; }
        public string V1AUTA_NRPROPOS { get; set; }
        public string V1AUTA_NRITEM { get; set; }
        public string V1AUTA_FONTE { get; set; }

        public static R0085_00_SELECT_V0AUTOPROP_DB_SELECT_1_Query1 Execute(R0085_00_SELECT_V0AUTOPROP_DB_SELECT_1_Query1 r0085_00_SELECT_V0AUTOPROP_DB_SELECT_1_Query1)
        {
            var ths = r0085_00_SELECT_V0AUTOPROP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0085_00_SELECT_V0AUTOPROP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0085_00_SELECT_V0AUTOPROP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0AUTP_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}