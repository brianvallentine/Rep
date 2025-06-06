using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PR0011B
{
    public class R1200_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            RAMO
            INTO :V1CONTPR-RAMO
            FROM SEGUROS.V1CONTPROP
            WHERE FONTE = :V1ACOMPR-FONTE
            AND NRPROPOS = :V1ACOMPR-NRPROPOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											RAMO
											FROM SEGUROS.V1CONTPROP
											WHERE FONTE = '{this.V1ACOMPR_FONTE}'
											AND NRPROPOS = '{this.V1ACOMPR_NRPROPOS}'";

            return query;
        }
        public string V1CONTPR_RAMO { get; set; }
        public string V1ACOMPR_NRPROPOS { get; set; }
        public string V1ACOMPR_FONTE { get; set; }

        public static R1200_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1 r1200_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1CONTPR_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}