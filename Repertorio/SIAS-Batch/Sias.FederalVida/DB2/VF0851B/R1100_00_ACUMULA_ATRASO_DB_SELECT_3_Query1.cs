using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0851B
{
    public class R1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1 : QueryBasis<R1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTVENCTO
            INTO :V0HCOB-DTVENCTO
            FROM SEGUROS.V0HISTCOBVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND NRTIT = :V0HCOB-NRTIT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTVENCTO
											FROM SEGUROS.V0HISTCOBVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND NRTIT = '{this.V0HCOB_NRTIT}'";

            return query;
        }
        public string V0HCOB_DTVENCTO { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0HCOB_NRTIT { get; set; }

        public static R1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1 Execute(R1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1 r1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1)
        {
            var ths = r1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_ACUMULA_ATRASO_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0HCOB_DTVENCTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}