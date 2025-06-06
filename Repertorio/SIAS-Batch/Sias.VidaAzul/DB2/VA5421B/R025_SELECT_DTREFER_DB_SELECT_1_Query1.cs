using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5421B
{
    public class R025_SELECT_DTREFER_DB_SELECT_1_Query1 : QueryBasis<R025_SELECT_DTREFER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(DTREF) + 1 MONTH
            INTO :V0FATUR-DTREFER
            FROM SEGUROS.V0HISTREPSAF
            WHERE CODCLIEN = :V0SUBG-CODCLIEN
            AND CODOPER = 1800
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(DTREF) + 1 MONTH
											FROM SEGUROS.V0HISTREPSAF
											WHERE CODCLIEN = '{this.V0SUBG_CODCLIEN}'
											AND CODOPER = 1800";

            return query;
        }
        public string V0FATUR_DTREFER { get; set; }
        public string V0SUBG_CODCLIEN { get; set; }

        public static R025_SELECT_DTREFER_DB_SELECT_1_Query1 Execute(R025_SELECT_DTREFER_DB_SELECT_1_Query1 r025_SELECT_DTREFER_DB_SELECT_1_Query1)
        {
            var ths = r025_SELECT_DTREFER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R025_SELECT_DTREFER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R025_SELECT_DTREFER_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0FATUR_DTREFER = result[i++].Value?.ToString();
            return dta;
        }

    }
}