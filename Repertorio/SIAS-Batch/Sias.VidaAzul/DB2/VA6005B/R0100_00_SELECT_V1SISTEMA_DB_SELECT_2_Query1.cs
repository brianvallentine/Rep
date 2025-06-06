using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6005B
{
    public class R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1 : QueryBasis<R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE
            INTO :V1SIST-DTMOVACB
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'CB'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'CB'";

            return query;
        }
        public string V1SIST_DTMOVACB { get; set; }

        public static R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1 Execute(R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1 r0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1)
        {
            var ths = r0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1();
            var i = 0;
            dta.V1SIST_DTMOVACB = result[i++].Value?.ToString();
            return dta;
        }

    }
}