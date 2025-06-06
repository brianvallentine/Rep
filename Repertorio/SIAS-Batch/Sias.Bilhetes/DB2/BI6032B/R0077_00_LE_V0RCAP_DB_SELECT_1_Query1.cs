using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6032B
{
    public class R0077_00_LE_V0RCAP_DB_SELECT_1_Query1 : QueryBasis<R0077_00_LE_V0RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPERACAO
            INTO :V0RCAP-OPERACAO
            FROM SEGUROS.V0RCAP
            WHERE NRTIT = :V0RCAP-NRTIT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OPERACAO
											FROM SEGUROS.V0RCAP
											WHERE NRTIT = '{this.V0RCAP_NRTIT}'";

            return query;
        }
        public string V0RCAP_OPERACAO { get; set; }
        public string V0RCAP_NRTIT { get; set; }

        public static R0077_00_LE_V0RCAP_DB_SELECT_1_Query1 Execute(R0077_00_LE_V0RCAP_DB_SELECT_1_Query1 r0077_00_LE_V0RCAP_DB_SELECT_1_Query1)
        {
            var ths = r0077_00_LE_V0RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0077_00_LE_V0RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0077_00_LE_V0RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RCAP_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}