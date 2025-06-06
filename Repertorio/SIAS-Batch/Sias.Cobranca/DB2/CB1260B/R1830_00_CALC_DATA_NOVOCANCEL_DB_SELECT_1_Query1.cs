using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1260B
{
    public class R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1 : QueryBasis<R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT (DATA_CALENDARIO + 07 DAYS)
            INTO :WS-HOST-DATA-NOVOCANCEL
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT (DATA_CALENDARIO + 07 DAYS)
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.CALENDAR_DATA_CALENDARIO}'
											WITH UR";

            return query;
        }
        public string WS_HOST_DATA_NOVOCANCEL { get; set; }
        public string CALENDAR_DATA_CALENDARIO { get; set; }

        public static R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1 Execute(R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1 r1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1)
        {
            var ths = r1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_HOST_DATA_NOVOCANCEL = result[i++].Value?.ToString();
            return dta;
        }

    }
}