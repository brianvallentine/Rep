using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1 : QueryBasis<R7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO
            INTO :V0RCAP-SITUACAO
            FROM SEGUROS.V0RCAP
            WHERE NRTIT = :V0RCAP-NRTIT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
											FROM SEGUROS.V0RCAP
											WHERE NRTIT = '{this.V0RCAP_NRTIT}'";

            return query;
        }
        public string V0RCAP_SITUACAO { get; set; }
        public string V0RCAP_NRTIT { get; set; }

        public static R7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1 Execute(R7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1 r7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1)
        {
            var ths = r7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7160_00_SELECT_V0RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RCAP_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}