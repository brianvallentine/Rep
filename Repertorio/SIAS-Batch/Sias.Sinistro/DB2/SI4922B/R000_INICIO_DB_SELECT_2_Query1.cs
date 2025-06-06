using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI4922B
{
    public class R000_INICIO_DB_SELECT_2_Query1 : QueryBasis<R000_INICIO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_CALENDARIO
            INTO :CALENDAR-DATA-CALENDARIO
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :HOST-DATA-NEGOCIADA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_CALENDARIO
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.HOST_DATA_NEGOCIADA}'";

            return query;
        }
        public string CALENDAR_DATA_CALENDARIO { get; set; }
        public string HOST_DATA_NEGOCIADA { get; set; }

        public static R000_INICIO_DB_SELECT_2_Query1 Execute(R000_INICIO_DB_SELECT_2_Query1 r000_INICIO_DB_SELECT_2_Query1)
        {
            var ths = r000_INICIO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R000_INICIO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R000_INICIO_DB_SELECT_2_Query1();
            var i = 0;
            dta.CALENDAR_DATA_CALENDARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}