using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1626B
{
    public class R0151_00_DATA_FATURAMENTO_DB_SELECT_1_Query1 : QueryBasis<R0151_00_DATA_FATURAMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DIA_SEMANA ,
            FERIADO
            INTO :CALENDAR-DIA-SEMANA ,
            :CALENDAR-FERIADO
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :WS-DATA-FATUR
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DIA_SEMANA 
							,
											FERIADO
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.WS_DATA_FATUR}'
											WITH UR";

            return query;
        }
        public string CALENDAR_DIA_SEMANA { get; set; }
        public string CALENDAR_FERIADO { get; set; }
        public string WS_DATA_FATUR { get; set; }

        public static R0151_00_DATA_FATURAMENTO_DB_SELECT_1_Query1 Execute(R0151_00_DATA_FATURAMENTO_DB_SELECT_1_Query1 r0151_00_DATA_FATURAMENTO_DB_SELECT_1_Query1)
        {
            var ths = r0151_00_DATA_FATURAMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0151_00_DATA_FATURAMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0151_00_DATA_FATURAMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CALENDAR_DIA_SEMANA = result[i++].Value?.ToString();
            dta.CALENDAR_FERIADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}