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
    public class R0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1 : QueryBasis<R0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CONGENER,
            NOMECONG
            INTO :V0CONG-CONGENER,
            :V0CONG-NOMECONG
            FROM SEGUROS.V0CONGENERE
            WHERE CONGENER = :V0CCCH-CONGENER
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CONGENER
							,
											NOMECONG
											FROM SEGUROS.V0CONGENERE
											WHERE CONGENER = '{this.V0CCCH_CONGENER}'
											WITH UR";

            return query;
        }
        public string V0CONG_CONGENER { get; set; }
        public string V0CONG_NOMECONG { get; set; }
        public string V0CCCH_CONGENER { get; set; }

        public static R0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1 Execute(R0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1 r0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1)
        {
            var ths = r0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CONG_CONGENER = result[i++].Value?.ToString();
            dta.V0CONG_NOMECONG = result[i++].Value?.ToString();
            return dta;
        }

    }
}