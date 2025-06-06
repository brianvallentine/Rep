using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R6920_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 : QueryBasis<R6920_00_SELECT_HISCOBPR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMPMORNATU,
            IMPMORACID
            INTO :V0COBP-IMPMORNATU,
            :V0COBP-IMPMORACID
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0HCTA-NRCERTIF
            AND OCORHIST = 1
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMPMORNATU
							,
											IMPMORACID
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0HCTA_NRCERTIF}'
											AND OCORHIST = 1
											WITH UR";

            return query;
        }
        public string V0COBP_IMPMORNATU { get; set; }
        public string V0COBP_IMPMORACID { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }

        public static R6920_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 Execute(R6920_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 r6920_00_SELECT_HISCOBPR_DB_SELECT_1_Query1)
        {
            var ths = r6920_00_SELECT_HISCOBPR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6920_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6920_00_SELECT_HISCOBPR_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0COBP_IMPMORNATU = result[i++].Value?.ToString();
            dta.V0COBP_IMPMORACID = result[i++].Value?.ToString();
            return dta;
        }

    }
}