using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0350S
{
    public class R0090_SELECT_SISTEMAS_DB_SELECT_1_Query1 : QueryBasis<R0090_SELECT_SISTEMAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CURRENT DATE,
            CURRENT TIMESTAMP,
            CURRENT TIME
            INTO :HOST-CURRENT-DATE,
            :HOST-TIMESTAMP,
            :HOST-CURRENT-TIME
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'FI'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CURRENT DATE
							,
											CURRENT TIMESTAMP
							,
											CURRENT TIME
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'FI'
											WITH UR";

            return query;
        }
        public string HOST_CURRENT_DATE { get; set; }
        public string HOST_TIMESTAMP { get; set; }
        public string HOST_CURRENT_TIME { get; set; }

        public static R0090_SELECT_SISTEMAS_DB_SELECT_1_Query1 Execute(R0090_SELECT_SISTEMAS_DB_SELECT_1_Query1 r0090_SELECT_SISTEMAS_DB_SELECT_1_Query1)
        {
            var ths = r0090_SELECT_SISTEMAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0090_SELECT_SISTEMAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0090_SELECT_SISTEMAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_CURRENT_DATE = result[i++].Value?.ToString();
            dta.HOST_TIMESTAMP = result[i++].Value?.ToString();
            dta.HOST_CURRENT_TIME = result[i++].Value?.ToString();
            return dta;
        }

    }
}