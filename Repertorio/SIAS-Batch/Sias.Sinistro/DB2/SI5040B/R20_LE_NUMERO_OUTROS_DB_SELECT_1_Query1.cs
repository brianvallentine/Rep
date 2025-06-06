using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5040B
{
    public class R20_LE_NUMERO_OUTROS_DB_SELECT_1_Query1 : QueryBasis<R20_LE_NUMERO_OUTROS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(NUM_SIVAT,0)
            INTO
            :NUMEROUT-NUM-SIVAT
            FROM
            SEGUROS.NUMERO_OUTROS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(NUM_SIVAT
							,0)
											FROM
											SEGUROS.NUMERO_OUTROS";

            return query;
        }
        public string NUMEROUT_NUM_SIVAT { get; set; }

        public static R20_LE_NUMERO_OUTROS_DB_SELECT_1_Query1 Execute(R20_LE_NUMERO_OUTROS_DB_SELECT_1_Query1 r20_LE_NUMERO_OUTROS_DB_SELECT_1_Query1)
        {
            var ths = r20_LE_NUMERO_OUTROS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R20_LE_NUMERO_OUTROS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R20_LE_NUMERO_OUTROS_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUMEROUT_NUM_SIVAT = result[i++].Value?.ToString();
            return dta;
        }

    }
}