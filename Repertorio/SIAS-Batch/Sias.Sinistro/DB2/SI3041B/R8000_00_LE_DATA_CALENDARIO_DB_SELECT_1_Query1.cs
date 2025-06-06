using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI3041B
{
    public class R8000_00_LE_DATA_CALENDARIO_DB_SELECT_1_Query1 : QueryBasis<R8000_00_LE_DATA_CALENDARIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CURRENT DATE
            INTO :CALENDAR-DATA-CALENDARIO
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :SISTEMAS-DATA-MOV-ABERTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CURRENT DATE
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.SISTEMAS_DATA_MOV_ABERTO}'
											WITH UR";

            return query;
        }
        public string CALENDAR_DATA_CALENDARIO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static R8000_00_LE_DATA_CALENDARIO_DB_SELECT_1_Query1 Execute(R8000_00_LE_DATA_CALENDARIO_DB_SELECT_1_Query1 r8000_00_LE_DATA_CALENDARIO_DB_SELECT_1_Query1)
        {
            var ths = r8000_00_LE_DATA_CALENDARIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8000_00_LE_DATA_CALENDARIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8000_00_LE_DATA_CALENDARIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CALENDAR_DATA_CALENDARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}