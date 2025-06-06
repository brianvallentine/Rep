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
    public class R3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1_Query1 : QueryBasis<R3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTVENCTO
            INTO :V0PARC-DTVENCTO
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :V0HISC-NRCERTIF
            AND NRPARCEL = :V0HISC-NRPARCEL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTVENCTO
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.V0HISC_NRCERTIF}'
											AND NRPARCEL = '{this.V0HISC_NRPARCEL}'
											WITH UR";

            return query;
        }
        public string V0PARC_DTVENCTO { get; set; }
        public string V0HISC_NRCERTIF { get; set; }
        public string V0HISC_NRPARCEL { get; set; }

        public static R3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1_Query1 Execute(R3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1_Query1 r3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARC_DTVENCTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}