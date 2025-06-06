using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1139B
{
    public class R1102_00_SELECT_RCAP_DB_SELECT_1_Query1 : QueryBasis<R1102_00_SELECT_RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT FONTE,
            NRRCAP
            INTO :V0RCAP-FONTE,
            :V0RCAP-NRRCAP
            FROM SEGUROS.V0RCAP
            WHERE NRTIT = :V0RCAP-NRTIT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT FONTE
							,
											NRRCAP
											FROM SEGUROS.V0RCAP
											WHERE NRTIT = '{this.V0RCAP_NRTIT}'";

            return query;
        }
        public string V0RCAP_FONTE { get; set; }
        public string V0RCAP_NRRCAP { get; set; }
        public string V0RCAP_NRTIT { get; set; }

        public static R1102_00_SELECT_RCAP_DB_SELECT_1_Query1 Execute(R1102_00_SELECT_RCAP_DB_SELECT_1_Query1 r1102_00_SELECT_RCAP_DB_SELECT_1_Query1)
        {
            var ths = r1102_00_SELECT_RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1102_00_SELECT_RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1102_00_SELECT_RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RCAP_FONTE = result[i++].Value?.ToString();
            dta.V0RCAP_NRRCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}