using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0847B
{
    public class R2310_00_SELECT_V1SINIAUTO_DB_SELECT_1_Query1 : QueryBasis<R2310_00_SELECT_V1SINIAUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_ITEM
            INTO :V1SAUT-NRITEM
            FROM SEGUROS.V1SINISTRO_AUTO1
            WHERE NUM_APOLICE = :V1MSIN-NUM-APOL
            AND NUM_APOL_SINISTRO = :V1HSIN-NUM-SINI
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_ITEM
											FROM SEGUROS.V1SINISTRO_AUTO1
											WHERE NUM_APOLICE = '{this.V1MSIN_NUM_APOL}'
											AND NUM_APOL_SINISTRO = '{this.V1HSIN_NUM_SINI}'";

            return query;
        }
        public string V1SAUT_NRITEM { get; set; }
        public string V1MSIN_NUM_APOL { get; set; }
        public string V1HSIN_NUM_SINI { get; set; }

        public static R2310_00_SELECT_V1SINIAUTO_DB_SELECT_1_Query1 Execute(R2310_00_SELECT_V1SINIAUTO_DB_SELECT_1_Query1 r2310_00_SELECT_V1SINIAUTO_DB_SELECT_1_Query1)
        {
            var ths = r2310_00_SELECT_V1SINIAUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2310_00_SELECT_V1SINIAUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2310_00_SELECT_V1SINIAUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SAUT_NRITEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}