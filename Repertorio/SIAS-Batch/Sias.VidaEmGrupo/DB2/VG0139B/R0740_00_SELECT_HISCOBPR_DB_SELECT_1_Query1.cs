using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0139B
{
    public class R0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 : QueryBasis<R0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NRCERTIF,
            OCORHIST,
            DTINIVIG,
            DTTERVIG
            INTO
            :V0COBP-NRCERTIF,
            :V0COBP-OCORHIST,
            :V0COBP-DTINIVIG-ENDO,
            :V0COBP-DTTERVIG-ENDO
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0HCTB-NRCERTIF
            AND DTTERVIG >= :V0PARC-DTVENCTO
            ORDER BY NRCERTIF,
            DTTERVIG
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NRCERTIF
							,
											OCORHIST
							,
											DTINIVIG
							,
											DTTERVIG
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0HCTB_NRCERTIF}'
											AND DTTERVIG >= '{this.V0PARC_DTVENCTO}'
											ORDER BY NRCERTIF
							,
											DTTERVIG
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string V0COBP_NRCERTIF { get; set; }
        public string V0COBP_OCORHIST { get; set; }
        public string V0COBP_DTINIVIG_ENDO { get; set; }
        public string V0COBP_DTTERVIG_ENDO { get; set; }
        public string V0HCTB_NRCERTIF { get; set; }
        public string V0PARC_DTVENCTO { get; set; }

        public static R0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 Execute(R0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 r0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1)
        {
            var ths = r0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0COBP_NRCERTIF = result[i++].Value?.ToString();
            dta.V0COBP_OCORHIST = result[i++].Value?.ToString();
            dta.V0COBP_DTINIVIG_ENDO = result[i++].Value?.ToString();
            dta.V0COBP_DTTERVIG_ENDO = result[i++].Value?.ToString();
            return dta;
        }

    }
}