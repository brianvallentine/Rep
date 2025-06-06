using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0416B
{
    public class R2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1 : QueryBasis<R2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRMVG ,
            PRMAP
            INTO :V0PARC-PRMVG ,
            :V0PARC-PRMAP
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :V0HCOB-NRCERTIF
            AND NRPARCEL = :V0HCOB-NRPARCEL
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT PRMVG 
							,
											PRMAP
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.V0HCOB_NRCERTIF}'
											AND NRPARCEL = '{this.V0HCOB_NRPARCEL}'";

            return query;
        }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }

        public static R2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1 Execute(R2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1 r2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARC_PRMVG = result[i++].Value?.ToString();
            dta.V0PARC_PRMAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}