using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0815B
{
    public class R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1 : QueryBasis<R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),+0)
            INTO :WHOST-QTD-CONGN
            FROM SEGUROS.V0CONGENERE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,+0)
											FROM SEGUROS.V0CONGENERE";

            return query;
        }
        public string WHOST_QTD_CONGN { get; set; }

        public static R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1 Execute(R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1 r0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1)
        {
            var ths = r0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0600_00_SELECT_RELAT_CONG_DB_SELECT_2_Query1();
            var i = 0;
            dta.WHOST_QTD_CONGN = result[i++].Value?.ToString();
            return dta;
        }

    }
}