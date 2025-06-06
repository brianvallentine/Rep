using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5419B
{
    public class R1400_00_SELECT_V0SAFCOBER_DB_SELECT_1_Query1 : QueryBasis<R1400_00_SELECT_V0SAFCOBER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTINIVIG
            INTO :V0SAFC-DTINIVIG
            FROM SEGUROS.V0SAFCOBER
            WHERE CODCLIEN = :V0RSAF-CODCLIEN
            AND DTTERVIG = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTINIVIG
											FROM SEGUROS.V0SAFCOBER
											WHERE CODCLIEN = '{this.V0RSAF_CODCLIEN}'
											AND DTTERVIG = '9999-12-31'";

            return query;
        }
        public string V0SAFC_DTINIVIG { get; set; }
        public string V0RSAF_CODCLIEN { get; set; }

        public static R1400_00_SELECT_V0SAFCOBER_DB_SELECT_1_Query1 Execute(R1400_00_SELECT_V0SAFCOBER_DB_SELECT_1_Query1 r1400_00_SELECT_V0SAFCOBER_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_SELECT_V0SAFCOBER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_SELECT_V0SAFCOBER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_SELECT_V0SAFCOBER_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SAFC_DTINIVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}