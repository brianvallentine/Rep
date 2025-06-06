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
    public class R1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NOMECONG
            INTO :V1CONG-NOMECONG
            FROM SEGUROS.V1CONGENERE
            WHERE CONGENER = :V0CCHQ-CONGENER
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NOMECONG
											FROM SEGUROS.V1CONGENERE
											WHERE CONGENER = '{this.V0CCHQ_CONGENER}'";

            return query;
        }
        public string V1CONG_NOMECONG { get; set; }
        public string V0CCHQ_CONGENER { get; set; }

        public static R1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1 r1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1CONG_NOMECONG = result[i++].Value?.ToString();
            return dta;
        }

    }
}