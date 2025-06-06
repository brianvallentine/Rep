using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class R0470_00_SELECT_CALENDAR_DB_SELECT_1_Query1 : QueryBasis<R0470_00_SELECT_CALENDAR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_CALENDARIO +
            :WHOST-QTDPARCEL MONTHS - 1 DAYS
            INTO :CALENDAR-DATA-CALENDARIO
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_CALENDARIO +
											{this.WHOST_QTDPARCEL} MONTHS - 1 DAYS
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.CALENDAR_DATA_CALENDARIO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string CALENDAR_DATA_CALENDARIO { get; set; }
        public string WHOST_QTDPARCEL { get; set; }

        public static R0470_00_SELECT_CALENDAR_DB_SELECT_1_Query1 Execute(R0470_00_SELECT_CALENDAR_DB_SELECT_1_Query1 r0470_00_SELECT_CALENDAR_DB_SELECT_1_Query1)
        {
            var ths = r0470_00_SELECT_CALENDAR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0470_00_SELECT_CALENDAR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0470_00_SELECT_CALENDAR_DB_SELECT_1_Query1();
            var i = 0;
            dta.CALENDAR_DATA_CALENDARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}