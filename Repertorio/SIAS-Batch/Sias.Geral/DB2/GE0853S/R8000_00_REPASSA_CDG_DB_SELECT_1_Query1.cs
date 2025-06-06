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
    public class R8000_00_REPASSA_CDG_DB_SELECT_1_Query1 : QueryBasis<R8000_00_REPASSA_CDG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO
            INTO :V0RCDG-SITUACAO
            FROM SEGUROS.V0REPASSECDG
            WHERE NRCERTIF = :V0HISC-NRCERTIF
            AND DTREFER = :V0RCDG-DTREFER
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
											FROM SEGUROS.V0REPASSECDG
											WHERE NRCERTIF = '{this.V0HISC_NRCERTIF}'
											AND DTREFER = '{this.V0RCDG_DTREFER}'
											WITH UR";

            return query;
        }
        public string V0RCDG_SITUACAO { get; set; }
        public string V0HISC_NRCERTIF { get; set; }
        public string V0RCDG_DTREFER { get; set; }

        public static R8000_00_REPASSA_CDG_DB_SELECT_1_Query1 Execute(R8000_00_REPASSA_CDG_DB_SELECT_1_Query1 r8000_00_REPASSA_CDG_DB_SELECT_1_Query1)
        {
            var ths = r8000_00_REPASSA_CDG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8000_00_REPASSA_CDG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8000_00_REPASSA_CDG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RCDG_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}