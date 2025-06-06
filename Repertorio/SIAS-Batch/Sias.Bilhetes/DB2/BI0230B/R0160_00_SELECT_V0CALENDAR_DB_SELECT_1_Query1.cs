using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0230B
{
    public class R0160_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1 : QueryBasis<R0160_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTH_ULT_DIA_MES
            INTO :CALENDAR-DTH-ULT-DIA-MES
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :WSHOST-DTINIVIG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTH_ULT_DIA_MES
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.WSHOST_DTINIVIG}'
											WITH UR";

            return query;
        }
        public string CALENDAR_DTH_ULT_DIA_MES { get; set; }
        public string WSHOST_DTINIVIG { get; set; }

        public static R0160_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1 Execute(R0160_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1 r0160_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1)
        {
            var ths = r0160_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0160_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0160_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1();
            var i = 0;
            dta.CALENDAR_DTH_ULT_DIA_MES = result[i++].Value?.ToString();
            return dta;
        }

    }
}