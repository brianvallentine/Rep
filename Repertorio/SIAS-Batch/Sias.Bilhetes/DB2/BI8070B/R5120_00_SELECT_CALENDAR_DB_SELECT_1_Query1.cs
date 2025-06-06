using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8070B
{
    public class R5120_00_SELECT_CALENDAR_DB_SELECT_1_Query1 : QueryBasis<R5120_00_SELECT_CALENDAR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_CALENDARIO + 1 DAYS
            INTO :CALENDAR-DATA-CALENDARIO
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :ENDOSSOS-DATA-TERVIGENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_CALENDARIO + 1 DAYS
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.ENDOSSOS_DATA_TERVIGENCIA}'
											WITH UR";

            return query;
        }
        public string CALENDAR_DATA_CALENDARIO { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }

        public static R5120_00_SELECT_CALENDAR_DB_SELECT_1_Query1 Execute(R5120_00_SELECT_CALENDAR_DB_SELECT_1_Query1 r5120_00_SELECT_CALENDAR_DB_SELECT_1_Query1)
        {
            var ths = r5120_00_SELECT_CALENDAR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5120_00_SELECT_CALENDAR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5120_00_SELECT_CALENDAR_DB_SELECT_1_Query1();
            var i = 0;
            dta.CALENDAR_DATA_CALENDARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}