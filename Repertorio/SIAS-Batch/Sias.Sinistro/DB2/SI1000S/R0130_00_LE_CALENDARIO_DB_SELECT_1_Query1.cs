using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI1000S
{
    public class R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1 : QueryBasis<R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_CALENDARIO
            INTO :CALENDAR-DATA-CALENDARIO
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_CALENDARIO
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.CALENDAR_DATA_CALENDARIO}'";

            return query;
        }
        public string CALENDAR_DATA_CALENDARIO { get; set; }

        public static R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1 Execute(R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1 r0130_00_LE_CALENDARIO_DB_SELECT_1_Query1)
        {
            var ths = r0130_00_LE_CALENDARIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CALENDAR_DATA_CALENDARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}