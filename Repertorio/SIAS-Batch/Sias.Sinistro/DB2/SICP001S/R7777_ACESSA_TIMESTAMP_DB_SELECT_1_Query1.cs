using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SICP001S
{
    public class R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1 : QueryBasis<R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CURRENT TIMESTAMP
            INTO :HOST-CURRENT-TIMESTAMP
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
        public string HOST_CURRENT_TIMESTAMP { get; set; }

        public static R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1 Execute(R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1 r7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1)
        {
            var ths = r7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_CURRENT_TIMESTAMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}