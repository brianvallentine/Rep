using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0002B
{
    public class R3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1 : QueryBasis<R3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRTIT
            INTO :V1RCAP-NRTIT
            FROM SEGUROS.V1RCAP
            WHERE NRTIT = :V0RCAP-NRTIT
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRTIT
											FROM SEGUROS.V1RCAP
											WHERE NRTIT = '{this.V0RCAP_NRTIT}'
											WITH UR";

            return query;
        }
        public string V1RCAP_NRTIT { get; set; }
        public string V0RCAP_NRTIT { get; set; }

        public static R3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1 Execute(R3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1 r3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1)
        {
            var ths = r3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1RCAP_NRTIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}