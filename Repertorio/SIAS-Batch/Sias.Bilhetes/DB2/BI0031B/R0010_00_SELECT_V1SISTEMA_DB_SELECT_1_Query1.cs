using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0031B
{
    public class R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 : QueryBasis<R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE,
            CURRENT DATE,
            DTMOVABE + 10 DAYS,
            DTMOVABE - 30 DAYS
            INTO :V1SISTE-DTMOVABE,
            :V1SISTE-DTCURRENT,
            :V1SISTE-DTMOVABE-10,
            :V1SISTE-DTMOVABE-30
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'EM'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
							,
											CURRENT DATE
							,
											DTMOVABE + 10 DAYS
							,
											DTMOVABE - 30 DAYS
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'EM'";

            return query;
        }
        public string V1SISTE_DTMOVABE { get; set; }
        public string V1SISTE_DTCURRENT { get; set; }
        public string V1SISTE_DTMOVABE_10 { get; set; }
        public string V1SISTE_DTMOVABE_30 { get; set; }

        public static R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 Execute(R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 r0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = r0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SISTE_DTMOVABE = result[i++].Value?.ToString();
            dta.V1SISTE_DTCURRENT = result[i++].Value?.ToString();
            dta.V1SISTE_DTMOVABE_10 = result[i++].Value?.ToString();
            dta.V1SISTE_DTMOVABE_30 = result[i++].Value?.ToString();
            return dta;
        }

    }
}