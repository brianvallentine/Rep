using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R4500_00_SOLIC_RELAT_DB_SELECT_1_Query1 : QueryBasis<R4500_00_SOLIC_RELAT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRTIT,
            DTVENCTO
            INTO :V0RELA-NRTIT,
            :V0RELA-DTVENCTO
            FROM SEGUROS.V0HISTCOBVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND NRPARCEL = :V0RELA-NRPARCEL
            ORDER BY NRTIT
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRTIT
							,
											DTVENCTO
											FROM SEGUROS.V0HISTCOBVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND NRPARCEL = '{this.V0RELA_NRPARCEL}'
											ORDER BY NRTIT
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string V0RELA_NRTIT { get; set; }
        public string V0RELA_DTVENCTO { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0RELA_NRPARCEL { get; set; }

        public static R4500_00_SOLIC_RELAT_DB_SELECT_1_Query1 Execute(R4500_00_SOLIC_RELAT_DB_SELECT_1_Query1 r4500_00_SOLIC_RELAT_DB_SELECT_1_Query1)
        {
            var ths = r4500_00_SOLIC_RELAT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4500_00_SOLIC_RELAT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4500_00_SOLIC_RELAT_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RELA_NRTIT = result[i++].Value?.ToString();
            dta.V0RELA_DTVENCTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}