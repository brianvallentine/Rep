using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class A6200_000_LE_RCAP_DB_SELECT_3_Query1 : QueryBasis<A6200_000_LE_RCAP_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRTIT
            INTO :V0RCAP-NRTIT
            FROM SEGUROS.V0RCAP
            WHERE FONTE = 010
            AND NRRCAP = :ENDO-NRRCAP
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NRTIT
											FROM SEGUROS.V0RCAP
											WHERE FONTE = 010
											AND NRRCAP = '{this.ENDO_NRRCAP}'
											WITH UR";

            return query;
        }
        public string V0RCAP_NRTIT { get; set; }
        public string ENDO_NRRCAP { get; set; }

        public static A6200_000_LE_RCAP_DB_SELECT_3_Query1 Execute(A6200_000_LE_RCAP_DB_SELECT_3_Query1 a6200_000_LE_RCAP_DB_SELECT_3_Query1)
        {
            var ths = a6200_000_LE_RCAP_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override A6200_000_LE_RCAP_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new A6200_000_LE_RCAP_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0RCAP_NRTIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}