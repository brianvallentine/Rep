using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5000B
{
    public class R221_MAX_NUM_RESSARC_DB_SELECT_1_Query1 : QueryBasis<R221_MAX_NUM_RESSARC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX((NUM_RESSARC),0)
            INTO :SI112-NUM-RESSARC
            FROM SEGUROS.SI_RESSARC_ACORDO
            WHERE NUM_APOL_SINISTRO = :SI112-NUM-APOL-SINISTRO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX((NUM_RESSARC)
							,0)
											FROM SEGUROS.SI_RESSARC_ACORDO
											WHERE NUM_APOL_SINISTRO = '{this.SI112_NUM_APOL_SINISTRO}'
											WITH UR";

            return query;
        }
        public string SI112_NUM_RESSARC { get; set; }
        public string SI112_NUM_APOL_SINISTRO { get; set; }

        public static R221_MAX_NUM_RESSARC_DB_SELECT_1_Query1 Execute(R221_MAX_NUM_RESSARC_DB_SELECT_1_Query1 r221_MAX_NUM_RESSARC_DB_SELECT_1_Query1)
        {
            var ths = r221_MAX_NUM_RESSARC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R221_MAX_NUM_RESSARC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R221_MAX_NUM_RESSARC_DB_SELECT_1_Query1();
            var i = 0;
            dta.SI112_NUM_RESSARC = result[i++].Value?.ToString();
            return dta;
        }

    }
}