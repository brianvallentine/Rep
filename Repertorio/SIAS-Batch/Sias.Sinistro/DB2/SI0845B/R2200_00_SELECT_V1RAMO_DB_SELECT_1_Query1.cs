using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0845B
{
    public class R2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1 : QueryBasis<R2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMERAMO
            INTO :V1RAMO-NOMERAMO
            FROM SEGUROS.V1RAMO
            WHERE RAMO = :HOST-RAMO
            AND MODALIDA = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMERAMO
											FROM SEGUROS.V1RAMO
											WHERE RAMO = '{this.HOST_RAMO}'
											AND MODALIDA = 0";

            return query;
        }
        public string V1RAMO_NOMERAMO { get; set; }
        public string HOST_RAMO { get; set; }

        public static R2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1 Execute(R2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1 r2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_SELECT_V1RAMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1RAMO_NOMERAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}