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
    public class R3620_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1 : QueryBasis<R3620_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            OCORHIST
            INTO :W1CPRO-OCORHIST
            FROM SEGUROS.V1CONTPROP
            WHERE FONTE = :V1PROP-FONTE
            AND NRPROPOS = :V1PROP-NRPROPOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											OCORHIST
											FROM SEGUROS.V1CONTPROP
											WHERE FONTE = '{this.V1PROP_FONTE}'
											AND NRPROPOS = '{this.V1PROP_NRPROPOS}'";

            return query;
        }
        public string W1CPRO_OCORHIST { get; set; }
        public string V1PROP_NRPROPOS { get; set; }
        public string V1PROP_FONTE { get; set; }

        public static R3620_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1 Execute(R3620_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1 r3620_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1)
        {
            var ths = r3620_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3620_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3620_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1();
            var i = 0;
            dta.W1CPRO_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}