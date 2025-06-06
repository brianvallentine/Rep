using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0034B
{
    public class R3300_00_CARTA_ORIGINAL_DB_SELECT_1_Query1 : QueryBasis<R3300_00_CARTA_ORIGINAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CARTA_REITERA
            INTO :GECARTA-NUM-CARTA-REITERA:NL-NUM-CARTA-REITERA
            FROM SEGUROS.GE_CARTA
            WHERE NUM_CARTA = :GECARTA-NUM-CARTA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CARTA_REITERA
											FROM SEGUROS.GE_CARTA
											WHERE NUM_CARTA = '{this.GECARTA_NUM_CARTA}'";

            return query;
        }
        public string GECARTA_NUM_CARTA_REITERA { get; set; }
        public string NL_NUM_CARTA_REITERA { get; set; }
        public string GECARTA_NUM_CARTA { get; set; }

        public static R3300_00_CARTA_ORIGINAL_DB_SELECT_1_Query1 Execute(R3300_00_CARTA_ORIGINAL_DB_SELECT_1_Query1 r3300_00_CARTA_ORIGINAL_DB_SELECT_1_Query1)
        {
            var ths = r3300_00_CARTA_ORIGINAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3300_00_CARTA_ORIGINAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3300_00_CARTA_ORIGINAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.GECARTA_NUM_CARTA_REITERA = result[i++].Value?.ToString();
            dta.NL_NUM_CARTA_REITERA = string.IsNullOrWhiteSpace(dta.GECARTA_NUM_CARTA_REITERA) ? "-1" : "0";
            return dta;
        }

    }
}