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
    public class R1100_00_MONTA_SORT_DB_SELECT_3_Query1 : QueryBasis<R1100_00_MONTA_SORT_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODAST
            INTO :V0ASST-CODAST
            FROM SEGUROS.V0PROPOSTAVF
            WHERE NRCERTIF = :V0EVEN-NRCERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODAST
											FROM SEGUROS.V0PROPOSTAVF
											WHERE NRCERTIF = '{this.V0EVEN_NRCERTIF}'";

            return query;
        }
        public string V0ASST_CODAST { get; set; }
        public string V0EVEN_NRCERTIF { get; set; }

        public static R1100_00_MONTA_SORT_DB_SELECT_3_Query1 Execute(R1100_00_MONTA_SORT_DB_SELECT_3_Query1 r1100_00_MONTA_SORT_DB_SELECT_3_Query1)
        {
            var ths = r1100_00_MONTA_SORT_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_MONTA_SORT_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_MONTA_SORT_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0ASST_CODAST = result[i++].Value?.ToString();
            return dta;
        }

    }
}