using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0340B
{
    public class R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3_Query1 : QueryBasis<R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_CALENDARIO,
            DIA_SEMANA,
            FERIADO
            INTO :CALENDAR-DATA-CALENDARIO,
            :CALENDAR-DIA-SEMANA,
            :CALENDAR-FERIADO
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :DTVENCTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_CALENDARIO
							,
											DIA_SEMANA
							,
											FERIADO
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.DTVENCTO}'";

            return query;
        }
        public string CALENDAR_DATA_CALENDARIO { get; set; }
        public string CALENDAR_DIA_SEMANA { get; set; }
        public string CALENDAR_FERIADO { get; set; }
        public string DTVENCTO { get; set; }

        public static R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3_Query1 Execute(R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3_Query1 r0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3_Query1)
        {
            var ths = r0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3_Query1();
            var i = 0;
            dta.CALENDAR_DATA_CALENDARIO = result[i++].Value?.ToString();
            dta.CALENDAR_DIA_SEMANA = result[i++].Value?.ToString();
            dta.CALENDAR_FERIADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}