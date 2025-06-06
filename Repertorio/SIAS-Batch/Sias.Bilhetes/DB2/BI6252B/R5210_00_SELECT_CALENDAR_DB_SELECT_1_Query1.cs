using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6252B
{
    public class R5210_00_SELECT_CALENDAR_DB_SELECT_1_Query1 : QueryBasis<R5210_00_SELECT_CALENDAR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT (DATA_CALENDARIO - 012 MONTH)
            INTO :WSCOR99-DATA-INIVIGENCIA
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO =
            :CALENDAR-DATA-CALENDARIO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT (DATA_CALENDARIO - 012 MONTH)
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO =
											'{this.CALENDAR_DATA_CALENDARIO}'
											WITH UR";

            return query;
        }
        public string WSCOR99_DATA_INIVIGENCIA { get; set; }
        public string CALENDAR_DATA_CALENDARIO { get; set; }

        public static R5210_00_SELECT_CALENDAR_DB_SELECT_1_Query1 Execute(R5210_00_SELECT_CALENDAR_DB_SELECT_1_Query1 r5210_00_SELECT_CALENDAR_DB_SELECT_1_Query1)
        {
            var ths = r5210_00_SELECT_CALENDAR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5210_00_SELECT_CALENDAR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5210_00_SELECT_CALENDAR_DB_SELECT_1_Query1();
            var i = 0;
            dta.WSCOR99_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}