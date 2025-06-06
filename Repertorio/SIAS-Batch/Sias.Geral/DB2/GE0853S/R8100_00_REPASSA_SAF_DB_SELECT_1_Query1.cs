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
    public class R8100_00_REPASSA_SAF_DB_SELECT_1_Query1 : QueryBasis<R8100_00_REPASSA_SAF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO
            INTO :V0RSAF-SITUACAO
            FROM SEGUROS.V0HISTREPSAF
            WHERE NRCERTIF = :V0HISC-NRCERTIF
            AND DTREF = :V0RSAF-DTREFER
            AND CODOPER = 1100
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
											FROM SEGUROS.V0HISTREPSAF
											WHERE NRCERTIF = '{this.V0HISC_NRCERTIF}'
											AND DTREF = '{this.V0RSAF_DTREFER}'
											AND CODOPER = 1100
											WITH UR";

            return query;
        }
        public string V0RSAF_SITUACAO { get; set; }
        public string V0HISC_NRCERTIF { get; set; }
        public string V0RSAF_DTREFER { get; set; }

        public static R8100_00_REPASSA_SAF_DB_SELECT_1_Query1 Execute(R8100_00_REPASSA_SAF_DB_SELECT_1_Query1 r8100_00_REPASSA_SAF_DB_SELECT_1_Query1)
        {
            var ths = r8100_00_REPASSA_SAF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8100_00_REPASSA_SAF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8100_00_REPASSA_SAF_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RSAF_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}