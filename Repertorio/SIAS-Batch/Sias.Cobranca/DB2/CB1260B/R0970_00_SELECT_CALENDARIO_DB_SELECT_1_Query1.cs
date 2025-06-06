using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1260B
{
    public class R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1 : QueryBasis<R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*) / 30,+0)
            INTO :WS-HOST-QTD-MESES-VIG
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO BETWEEN :WS-HOST-DTINIVIG-APOL
            AND :WS-HOST-DTTERVIG-APOL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*) / 30
							,+0)
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO BETWEEN '{this.WS_HOST_DTINIVIG_APOL}'
											AND '{this.WS_HOST_DTTERVIG_APOL}'
											WITH UR";

            return query;
        }
        public string WS_HOST_QTD_MESES_VIG { get; set; }
        public string WS_HOST_DTINIVIG_APOL { get; set; }
        public string WS_HOST_DTTERVIG_APOL { get; set; }

        public static R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1 Execute(R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1 r0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1)
        {
            var ths = r0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_HOST_QTD_MESES_VIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}