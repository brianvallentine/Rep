using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0820B
{
    public class R0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1 : QueryBasis<R0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE,
            CURRENT DATE
            INTO :V0SIST-DTMOVABE-FI,
            :V0SIST-DTCURRENT
            FROM SEGUROS.V0SISTEMA
            WHERE IDSISTEM = 'FI'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
							,
											CURRENT DATE
											FROM SEGUROS.V0SISTEMA
											WHERE IDSISTEM = 'FI'
											WITH UR";

            return query;
        }
        public string V0SIST_DTMOVABE_FI { get; set; }
        public string V0SIST_DTCURRENT { get; set; }

        public static R0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1 Execute(R0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1 r0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1)
        {
            var ths = r0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SIST_DTMOVABE_FI = result[i++].Value?.ToString();
            dta.V0SIST_DTCURRENT = result[i++].Value?.ToString();
            return dta;
        }

    }
}