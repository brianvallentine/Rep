using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2513B
{
    public class R2930_00_CALCULA_DIA_UTIL_Query1 : QueryBasis<R2930_00_CALCULA_DIA_UTIL_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DATA_CALENDARIO,
            (DATA_CALENDARIO + 1 DAY),
            DIA_SEMANA,
            FERIADO
            INTO
            :CALENDAR-DATA-CALENDARIO,
            :WHOST-PROXIMA-DATA,
            :CALENDAR-DIA-SEMANA,
            :CALENDAR-FERIADO
            FROM
            SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :WHOST-PROXIMA-DATA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DATA_CALENDARIO
							,
											(DATA_CALENDARIO + 1 DAY)
							,
											DIA_SEMANA
							,
											FERIADO
											FROM
											SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.WHOST_PROXIMA_DATA}'";

            return query;
        }
        public string CALENDAR_DATA_CALENDARIO { get; set; }
        public string WHOST_PROXIMA_DATA { get; set; }
        public string CALENDAR_DIA_SEMANA { get; set; }
        public string CALENDAR_FERIADO { get; set; }

        public static R2930_00_CALCULA_DIA_UTIL_Query1 Execute(R2930_00_CALCULA_DIA_UTIL_Query1 r2930_00_CALCULA_DIA_UTIL_Query1)
        {
            var ths = r2930_00_CALCULA_DIA_UTIL_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2930_00_CALCULA_DIA_UTIL_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2930_00_CALCULA_DIA_UTIL_Query1();
            var i = 0;
            dta.CALENDAR_DATA_CALENDARIO = result[i++].Value?.ToString();
            dta.WHOST_PROXIMA_DATA = result[i++].Value?.ToString();
            dta.CALENDAR_DIA_SEMANA = result[i++].Value?.ToString();
            dta.CALENDAR_FERIADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}