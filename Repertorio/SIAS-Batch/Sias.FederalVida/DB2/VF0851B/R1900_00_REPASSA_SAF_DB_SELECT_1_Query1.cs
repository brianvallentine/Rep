using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0851B
{
    public class R1900_00_REPASSA_SAF_DB_SELECT_1_Query1 : QueryBasis<R1900_00_REPASSA_SAF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO
            INTO :V0RSAF-SITUACAO
            FROM SEGUROS.V0HISTREPSAF
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND DTREF = :V0RSAF-DTREFER
            AND CODOPER = 1100
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
											FROM SEGUROS.V0HISTREPSAF
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND DTREF = '{this.V0RSAF_DTREFER}'
											AND CODOPER = 1100";

            return query;
        }
        public string V0RSAF_SITUACAO { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0RSAF_DTREFER { get; set; }

        public static R1900_00_REPASSA_SAF_DB_SELECT_1_Query1 Execute(R1900_00_REPASSA_SAF_DB_SELECT_1_Query1 r1900_00_REPASSA_SAF_DB_SELECT_1_Query1)
        {
            var ths = r1900_00_REPASSA_SAF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1900_00_REPASSA_SAF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1900_00_REPASSA_SAF_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RSAF_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}