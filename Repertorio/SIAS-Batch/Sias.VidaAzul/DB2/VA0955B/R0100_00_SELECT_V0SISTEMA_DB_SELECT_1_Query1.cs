using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0955B
{
    public class R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 : QueryBasis<R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE - 1 YEAR,
            DTMOVABE,
            CURRENT DATE
            INTO :V0SIST-DTMOVABE-1,
            :V0SIST-DTMOVABE,
            :V0SIST-DTCURRENT
            FROM SEGUROS.V0SISTEMA
            WHERE IDSISTEM = 'VA'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE - 1 YEAR
							,
											DTMOVABE
							,
											CURRENT DATE
											FROM SEGUROS.V0SISTEMA
											WHERE IDSISTEM = 'VA'";

            return query;
        }
        public string V0SIST_DTMOVABE_1 { get; set; }
        public string V0SIST_DTMOVABE { get; set; }
        public string V0SIST_DTCURRENT { get; set; }

        public static R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 Execute(R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SIST_DTMOVABE_1 = result[i++].Value?.ToString();
            dta.V0SIST_DTMOVABE = result[i++].Value?.ToString();
            dta.V0SIST_DTCURRENT = result[i++].Value?.ToString();
            return dta;
        }

    }
}