using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0501B
{
    public class R100_INSERT_PJ_DB_SELECT_1_Query1 : QueryBasis<R100_INSERT_PJ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_PESSOA),0) + 1
            INTO :OD001-NUM-PESSOA
            FROM ODS.OD_PESSOA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_PESSOA)
							,0) + 1
											FROM ODS.OD_PESSOA";

            return query;
        }
        public string OD001_NUM_PESSOA { get; set; }

        public static R100_INSERT_PJ_DB_SELECT_1_Query1 Execute(R100_INSERT_PJ_DB_SELECT_1_Query1 r100_INSERT_PJ_DB_SELECT_1_Query1)
        {
            var ths = r100_INSERT_PJ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R100_INSERT_PJ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R100_INSERT_PJ_DB_SELECT_1_Query1();
            var i = 0;
            dta.OD001_NUM_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}