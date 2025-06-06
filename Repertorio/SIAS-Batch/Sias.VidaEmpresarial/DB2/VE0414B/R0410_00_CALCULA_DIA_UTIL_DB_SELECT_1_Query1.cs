using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0414B
{
    public class R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1 : QueryBasis<R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1>
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

        public static R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1 Execute(R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1 r0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1)
        {
            var ths = r0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1();
            var i = 0;
            dta.CALENDAR_DATA_CALENDARIO = result[i++].Value?.ToString();
            dta.WHOST_PROXIMA_DATA = result[i++].Value?.ToString();
            dta.CALENDAR_DIA_SEMANA = result[i++].Value?.ToString();
            dta.CALENDAR_FERIADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}