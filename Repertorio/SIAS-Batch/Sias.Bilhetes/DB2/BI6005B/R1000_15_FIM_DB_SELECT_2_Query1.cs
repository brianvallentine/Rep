using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6005B
{
    public class R1000_15_FIM_DB_SELECT_2_Query1 : QueryBasis<R1000_15_FIM_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUMOPG
            INTO :V1NOUT-NUMOPG
            FROM SEGUROS.V0NUMERO_OUTROS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUMOPG
											FROM SEGUROS.V0NUMERO_OUTROS";

            return query;
        }
        public string V1NOUT_NUMOPG { get; set; }

        public static R1000_15_FIM_DB_SELECT_2_Query1 Execute(R1000_15_FIM_DB_SELECT_2_Query1 r1000_15_FIM_DB_SELECT_2_Query1)
        {
            var ths = r1000_15_FIM_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_15_FIM_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_15_FIM_DB_SELECT_2_Query1();
            var i = 0;
            dta.V1NOUT_NUMOPG = result[i++].Value?.ToString();
            return dta;
        }

    }
}