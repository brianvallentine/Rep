using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R6000_10_CANCEL_DB_SELECT_5_Query1 : QueryBasis<R6000_10_CANCEL_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRMVG,
            PRMAP
            INTO :V0COBP-PRMVG,
            :V0COBP-PRMAP
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND DTINIVIG <= :V0PROP-DTPROXVEN
            AND DTTERVIG >= :V0PROP-DTPROXVEN
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PRMVG
							,
											PRMAP
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND DTINIVIG <= '{this.V0PROP_DTPROXVEN}'
											AND DTTERVIG >= '{this.V0PROP_DTPROXVEN}'
											WITH UR";

            return query;
        }
        public string V0COBP_PRMVG { get; set; }
        public string V0COBP_PRMAP { get; set; }
        public string V0PROP_DTPROXVEN { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R6000_10_CANCEL_DB_SELECT_5_Query1 Execute(R6000_10_CANCEL_DB_SELECT_5_Query1 r6000_10_CANCEL_DB_SELECT_5_Query1)
        {
            var ths = r6000_10_CANCEL_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6000_10_CANCEL_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6000_10_CANCEL_DB_SELECT_5_Query1();
            var i = 0;
            dta.V0COBP_PRMVG = result[i++].Value?.ToString();
            dta.V0COBP_PRMAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}