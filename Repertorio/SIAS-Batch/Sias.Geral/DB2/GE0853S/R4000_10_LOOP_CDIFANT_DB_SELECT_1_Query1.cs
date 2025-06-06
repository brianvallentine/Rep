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
    public class R4000_10_LOOP_CDIFANT_DB_SELECT_1_Query1 : QueryBasis<R4000_10_LOOP_CDIFANT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTVENCTO
            INTO :V0PARC-DTVENCTO
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :V0HISC-NRCERTIF
            AND NRPARCEL = :V2DIFP-NRPARCDIF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTVENCTO
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.V0HISC_NRCERTIF}'
											AND NRPARCEL = '{this.V2DIFP_NRPARCDIF}'
											WITH UR";

            return query;
        }
        public string V0PARC_DTVENCTO { get; set; }
        public string V2DIFP_NRPARCDIF { get; set; }
        public string V0HISC_NRCERTIF { get; set; }

        public static R4000_10_LOOP_CDIFANT_DB_SELECT_1_Query1 Execute(R4000_10_LOOP_CDIFANT_DB_SELECT_1_Query1 r4000_10_LOOP_CDIFANT_DB_SELECT_1_Query1)
        {
            var ths = r4000_10_LOOP_CDIFANT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4000_10_LOOP_CDIFANT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4000_10_LOOP_CDIFANT_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARC_DTVENCTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}