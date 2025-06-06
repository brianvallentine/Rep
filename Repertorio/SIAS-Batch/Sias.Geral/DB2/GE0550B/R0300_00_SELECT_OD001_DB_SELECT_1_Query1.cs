using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0550B
{
    public class R0300_00_SELECT_OD001_DB_SELECT_1_Query1 : QueryBasis<R0300_00_SELECT_OD001_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_DV_PESSOA
            INTO :OD001-NUM-DV-PESSOA
            FROM ODS.OD_PESSOA
            WHERE NUM_PESSOA = :OD001-NUM-PESSOA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_DV_PESSOA
											FROM ODS.OD_PESSOA
											WHERE NUM_PESSOA = '{this.OD001_NUM_PESSOA}'";

            return query;
        }
        public string OD001_NUM_DV_PESSOA { get; set; }
        public string OD001_NUM_PESSOA { get; set; }

        public static R0300_00_SELECT_OD001_DB_SELECT_1_Query1 Execute(R0300_00_SELECT_OD001_DB_SELECT_1_Query1 r0300_00_SELECT_OD001_DB_SELECT_1_Query1)
        {
            var ths = r0300_00_SELECT_OD001_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_00_SELECT_OD001_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_00_SELECT_OD001_DB_SELECT_1_Query1();
            var i = 0;
            dta.OD001_NUM_DV_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}