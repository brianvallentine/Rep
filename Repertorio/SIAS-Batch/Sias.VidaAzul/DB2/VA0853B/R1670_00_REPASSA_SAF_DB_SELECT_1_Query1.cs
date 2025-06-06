using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R1670_00_REPASSA_SAF_DB_SELECT_1_Query1 : QueryBasis<R1670_00_REPASSA_SAF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO
            INTO :V0RSAF-SITUACAO
            FROM SEGUROS.V0HISTREPSAF
            WHERE CODCLIEN = :V0PROP-CODCLIEN
            AND DTREF = :V0RSAF-DTREFER
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
											FROM SEGUROS.V0HISTREPSAF
											WHERE CODCLIEN = '{this.V0PROP_CODCLIEN}'
											AND DTREF = '{this.V0RSAF_DTREFER}'
											WITH UR";

            return query;
        }
        public string V0RSAF_SITUACAO { get; set; }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0RSAF_DTREFER { get; set; }

        public static R1670_00_REPASSA_SAF_DB_SELECT_1_Query1 Execute(R1670_00_REPASSA_SAF_DB_SELECT_1_Query1 r1670_00_REPASSA_SAF_DB_SELECT_1_Query1)
        {
            var ths = r1670_00_REPASSA_SAF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1670_00_REPASSA_SAF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1670_00_REPASSA_SAF_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RSAF_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}