using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0403B
{
    public class R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 : QueryBasis<R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CURRENT DATE,
            DTMOVABE,
            DTMOVABE - 6 DAYS
            INTO :V1SIST-DTHOJE,
            :DTFIMSEM,
            :DTINISEM
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'VF'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CURRENT DATE
							,
											DTMOVABE
							,
											DTMOVABE - 6 DAYS
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'VF'";

            return query;
        }
        public string V1SIST_DTHOJE { get; set; }
        public string DTFIMSEM { get; set; }
        public string DTINISEM { get; set; }

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
            dta.V1SIST_DTHOJE = result[i++].Value?.ToString();
            dta.DTFIMSEM = result[i++].Value?.ToString();
            dta.DTINISEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}