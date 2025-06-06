using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0139B
{
    public class R1109_00_CALCULA_RTO_DB_SELECT_1_Query1 : QueryBasis<R1109_00_CALCULA_RTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            IMPMORNATU
            INTO :V0CBPR-IMPMORNATU
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0HCTB-NRCERTIF
            AND DTINIVIG <= :V0ENDO-DTTERVIG
            AND DTTERVIG >= :V0ENDO-DTTERVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											IMPMORNATU
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0HCTB_NRCERTIF}'
											AND DTINIVIG <= '{this.V0ENDO_DTTERVIG}'
											AND DTTERVIG >= '{this.V0ENDO_DTTERVIG}'";

            return query;
        }
        public string V0CBPR_IMPMORNATU { get; set; }
        public string V0HCTB_NRCERTIF { get; set; }
        public string V0ENDO_DTTERVIG { get; set; }

        public static R1109_00_CALCULA_RTO_DB_SELECT_1_Query1 Execute(R1109_00_CALCULA_RTO_DB_SELECT_1_Query1 r1109_00_CALCULA_RTO_DB_SELECT_1_Query1)
        {
            var ths = r1109_00_CALCULA_RTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1109_00_CALCULA_RTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1109_00_CALCULA_RTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CBPR_IMPMORNATU = result[i++].Value?.ToString();
            return dta;
        }

    }
}