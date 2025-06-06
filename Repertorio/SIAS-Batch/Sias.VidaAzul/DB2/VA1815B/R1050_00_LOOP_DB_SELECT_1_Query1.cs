using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1815B
{
    public class R1050_00_LOOP_DB_SELECT_1_Query1 : QueryBasis<R1050_00_LOOP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTVENCTO
            INTO :V0PARC-DTVENCTO
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :V0HCTA-NRCERTIF
            AND NRPARCEL = :V0DIFP-NRPARCEL
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DTVENCTO
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.V0HCTA_NRCERTIF}'
											AND NRPARCEL = '{this.V0DIFP_NRPARCEL}'";

            return query;
        }
        public string V0PARC_DTVENCTO { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0DIFP_NRPARCEL { get; set; }

        public static R1050_00_LOOP_DB_SELECT_1_Query1 Execute(R1050_00_LOOP_DB_SELECT_1_Query1 r1050_00_LOOP_DB_SELECT_1_Query1)
        {
            var ths = r1050_00_LOOP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1050_00_LOOP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1050_00_LOOP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARC_DTVENCTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}