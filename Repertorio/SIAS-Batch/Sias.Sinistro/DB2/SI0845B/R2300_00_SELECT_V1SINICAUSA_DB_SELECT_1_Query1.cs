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
    public class R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1 : QueryBasis<R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCAU
            INTO :V1SCAU-DESCAU
            FROM SEGUROS.V1SINICAUSA
            WHERE CODCAU = :V1MSIN-CODCAU
            AND RAMO = :V1MSIN-RAMO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCAU
											FROM SEGUROS.V1SINICAUSA
											WHERE CODCAU = '{this.V1MSIN_CODCAU}'
											AND RAMO = '{this.V1MSIN_RAMO}'";

            return query;
        }
        public string V1SCAU_DESCAU { get; set; }
        public string V1MSIN_CODCAU { get; set; }
        public string V1MSIN_RAMO { get; set; }

        public static R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1 Execute(R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1 r2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1)
        {
            var ths = r2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SCAU_DESCAU = result[i++].Value?.ToString();
            return dta;
        }

    }
}