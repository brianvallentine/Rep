using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FI0007B
{
    public class R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1 : QueryBasis<R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE
            INTO :V1SIST-DTMOVABE-FI
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'FI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'FI'";

            return query;
        }
        public string V1SIST_DTMOVABE_FI { get; set; }

        public static R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1 Execute(R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1 r0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1)
        {
            var ths = r0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SIST_DTMOVABE_FI = result[i++].Value?.ToString();
            return dta;
        }

    }
}