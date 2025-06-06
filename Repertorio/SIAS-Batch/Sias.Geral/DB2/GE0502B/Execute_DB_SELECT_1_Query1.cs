using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0502B
{
    public class Execute_DB_SELECT_1_Query1 : QueryBasis<Execute_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CURRENT DATE,
            CURRENT TIMESTAMP
            INTO :HOST-CURRENT-DATE,
            :HOST-CURRENT-TIMESTAMP
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'EM'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CURRENT DATE
							,
											CURRENT TIMESTAMP
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'EM'";

            return query;
        }
        public string HOST_CURRENT_DATE { get; set; }
        public string HOST_CURRENT_TIMESTAMP { get; set; }

        public static Execute_DB_SELECT_1_Query1 Execute(Execute_DB_SELECT_1_Query1 execute_DB_SELECT_1_Query1)
        {
            var ths = execute_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override Execute_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new Execute_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_CURRENT_DATE = result[i++].Value?.ToString();
            dta.HOST_CURRENT_TIMESTAMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}