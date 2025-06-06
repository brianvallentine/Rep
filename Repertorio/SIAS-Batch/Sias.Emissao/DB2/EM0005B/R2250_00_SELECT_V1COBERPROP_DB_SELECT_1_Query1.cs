using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0005B
{
    public class R2250_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1 : QueryBasis<R2250_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_ITEM
            INTO :W1COBP-NUM-ITEM
            FROM SEGUROS.V1COBERPROP
            WHERE FONTE = :V1PROP-FONTE
            AND NRPROPOS = :V1PROP-NRPROPOS
            AND RAMOFR = :V1PROP-RAMO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_ITEM
											FROM SEGUROS.V1COBERPROP
											WHERE FONTE = '{this.V1PROP_FONTE}'
											AND NRPROPOS = '{this.V1PROP_NRPROPOS}'
											AND RAMOFR = '{this.V1PROP_RAMO}'";

            return query;
        }
        public string W1COBP_NUM_ITEM { get; set; }
        public string V1PROP_NRPROPOS { get; set; }
        public string V1PROP_FONTE { get; set; }
        public string V1PROP_RAMO { get; set; }

        public static R2250_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1 Execute(R2250_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1 r2250_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1)
        {
            var ths = r2250_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2250_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2250_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1();
            var i = 0;
            dta.W1COBP_NUM_ITEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}