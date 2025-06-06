using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0010B
{
    public class R2350_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1 : QueryBasis<R2350_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCCOMSEG
            INTO :V1PLCO-PCCOMSEG
            FROM SEGUROS.V1PLANCOMIS
            WHERE CDFRACIO = :V0ENDO-CDFRACIO
            AND NRPARCEL = :V1HISP-NRPARCEL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCCOMSEG
											FROM SEGUROS.V1PLANCOMIS
											WHERE CDFRACIO = '{this.V0ENDO_CDFRACIO}'
											AND NRPARCEL = '{this.V1HISP_NRPARCEL}'";

            return query;
        }
        public string V1PLCO_PCCOMSEG { get; set; }
        public string V0ENDO_CDFRACIO { get; set; }
        public string V1HISP_NRPARCEL { get; set; }

        public static R2350_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1 Execute(R2350_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1 r2350_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1)
        {
            var ths = r2350_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2350_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2350_00_SELECT_V1PLANCOMIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PLCO_PCCOMSEG = result[i++].Value?.ToString();
            return dta;
        }

    }
}