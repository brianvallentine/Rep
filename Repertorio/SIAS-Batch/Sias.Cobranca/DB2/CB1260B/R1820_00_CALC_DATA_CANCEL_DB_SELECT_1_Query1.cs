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
    public class R1820_00_CALC_DATA_CANCEL_DB_SELECT_1_Query1 : QueryBasis<R1820_00_CALC_DATA_CANCEL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT (DATA_CALENDARIO + 15 DAYS)
            INTO :WS-HOST-DATA-CANCELAMENTO
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT (DATA_CALENDARIO + 15 DAYS)
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.CALENDAR_DATA_CALENDARIO}'
											WITH UR";

            return query;
        }
        public string WS_HOST_DATA_CANCELAMENTO { get; set; }
        public string CALENDAR_DATA_CALENDARIO { get; set; }

        public static R1820_00_CALC_DATA_CANCEL_DB_SELECT_1_Query1 Execute(R1820_00_CALC_DATA_CANCEL_DB_SELECT_1_Query1 r1820_00_CALC_DATA_CANCEL_DB_SELECT_1_Query1)
        {
            var ths = r1820_00_CALC_DATA_CANCEL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1820_00_CALC_DATA_CANCEL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1820_00_CALC_DATA_CANCEL_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_HOST_DATA_CANCELAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}