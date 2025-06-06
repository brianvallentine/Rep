using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5066B
{
    public class Execute_DB_SELECT_3_Query1 : QueryBasis<Execute_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CURRENT TIMESTAMP
            INTO :HOST-TIMESTAMP
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'FI'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CURRENT TIMESTAMP
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'FI'
											WITH UR";

            return query;
        }
        public string HOST_TIMESTAMP { get; set; }

        public static Execute_DB_SELECT_3_Query1 Execute(Execute_DB_SELECT_3_Query1 execute_DB_SELECT_3_Query1)
        {
            var ths = execute_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override Execute_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new Execute_DB_SELECT_3_Query1();
            var i = 0;
            dta.HOST_TIMESTAMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}