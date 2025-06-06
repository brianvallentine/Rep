using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0071B
{
    public class R0013_00_SELECT_TIMESTAMP_DB_SELECT_1_Query1 : QueryBasis<R0013_00_SELECT_TIMESTAMP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CURRENT_TIMESTAMP
            INTO :V1SISTE-TSCURRENT
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'EM'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CURRENT_TIMESTAMP
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'EM'
											WITH UR";

            return query;
        }
        public string V1SISTE_TSCURRENT { get; set; }

        public static R0013_00_SELECT_TIMESTAMP_DB_SELECT_1_Query1 Execute(R0013_00_SELECT_TIMESTAMP_DB_SELECT_1_Query1 r0013_00_SELECT_TIMESTAMP_DB_SELECT_1_Query1)
        {
            var ths = r0013_00_SELECT_TIMESTAMP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0013_00_SELECT_TIMESTAMP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0013_00_SELECT_TIMESTAMP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SISTE_TSCURRENT = result[i++].Value?.ToString();
            return dta;
        }

    }
}