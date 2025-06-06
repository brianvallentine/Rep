using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0403B
{
    public class R1100_00_MONTA_SORT_DB_SELECT_6_Query1 : QueryBasis<R1100_00_MONTA_SORT_DB_SELECT_6_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DISTINCT CODPDT
            INTO :V0PLCO-CODCOR
            FROM SEGUROS.V0PLANCOMISVF
            WHERE NRCERTIF = :V0EVEN-NRCERTIF
            AND TIPCOM = '2'
            ORDER BY 1
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DISTINCT CODPDT
											FROM SEGUROS.V0PLANCOMISVF
											WHERE NRCERTIF = '{this.V0EVEN_NRCERTIF}'
											AND TIPCOM = '2'
											ORDER BY 1";

            return query;
        }
        public string V0PLCO_CODCOR { get; set; }
        public string V0EVEN_NRCERTIF { get; set; }

        public static R1100_00_MONTA_SORT_DB_SELECT_6_Query1 Execute(R1100_00_MONTA_SORT_DB_SELECT_6_Query1 r1100_00_MONTA_SORT_DB_SELECT_6_Query1)
        {
            var ths = r1100_00_MONTA_SORT_DB_SELECT_6_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_MONTA_SORT_DB_SELECT_6_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_MONTA_SORT_DB_SELECT_6_Query1();
            var i = 0;
            dta.V0PLCO_CODCOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}