using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG001
{
    public class P0851_01_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0851_01_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CHAR(CURRENT TIMESTAMP)
            INTO :WH-CURRENT-TIMESTAMP
            FROM SYSIBM.SYSDUMMY1
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT CHAR(CURRENT TIMESTAMP)
											FROM SYSIBM.SYSDUMMY1";

            return query;
        }
        public string WH_CURRENT_TIMESTAMP { get; set; }

        public static P0851_01_INICIO_DB_SELECT_1_Query1 Execute(P0851_01_INICIO_DB_SELECT_1_Query1 p0851_01_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0851_01_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0851_01_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0851_01_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WH_CURRENT_TIMESTAMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}