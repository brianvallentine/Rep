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
    public class R1100_00_MONTA_SORT_DB_SELECT_4_Query1 : QueryBasis<R1100_00_MONTA_SORT_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODGER
            INTO :V0GERE-CODGER
            FROM SEGUROS.V0ASSISTFC
            WHERE CODAST = :V0ASST-CODAST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODGER
											FROM SEGUROS.V0ASSISTFC
											WHERE CODAST = '{this.V0ASST_CODAST}'";

            return query;
        }
        public string V0GERE_CODGER { get; set; }
        public string V0ASST_CODAST { get; set; }

        public static R1100_00_MONTA_SORT_DB_SELECT_4_Query1 Execute(R1100_00_MONTA_SORT_DB_SELECT_4_Query1 r1100_00_MONTA_SORT_DB_SELECT_4_Query1)
        {
            var ths = r1100_00_MONTA_SORT_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_MONTA_SORT_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_MONTA_SORT_DB_SELECT_4_Query1();
            var i = 0;
            dta.V0GERE_CODGER = result[i++].Value?.ToString();
            return dta;
        }

    }
}