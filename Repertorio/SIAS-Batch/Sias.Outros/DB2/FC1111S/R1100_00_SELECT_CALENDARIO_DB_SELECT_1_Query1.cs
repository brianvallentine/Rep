using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FC1111S
{
    public class R1100_00_SELECT_CALENDARIO_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_CALENDARIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_CALENDARIO + 1 DAY
            INTO :WHOST-DTMOVTO-I
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :GE387-DTA-FIM-MOVIMENTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_CALENDARIO + 1 DAY
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.GE387_DTA_FIM_MOVIMENTO}'";

            return query;
        }
        public string WHOST_DTMOVTO_I { get; set; }
        public string GE387_DTA_FIM_MOVIMENTO { get; set; }

        public static R1100_00_SELECT_CALENDARIO_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_CALENDARIO_DB_SELECT_1_Query1 r1100_00_SELECT_CALENDARIO_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_CALENDARIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_CALENDARIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_CALENDARIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DTMOVTO_I = result[i++].Value?.ToString();
            return dta;
        }

    }
}