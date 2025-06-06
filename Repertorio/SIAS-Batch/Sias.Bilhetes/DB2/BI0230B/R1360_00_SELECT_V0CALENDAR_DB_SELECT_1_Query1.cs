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
    public class R1360_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1 : QueryBasis<R1360_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT (DATA_CALENDARIO + 60 DAYS)
            INTO :RELATORI-DATA-REFERENCIA
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :RELATORI-PERI-FINAL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT (DATA_CALENDARIO + 60 DAYS)
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.RELATORI_PERI_FINAL}'
											WITH UR";

            return query;
        }
        public string RELATORI_DATA_REFERENCIA { get; set; }
        public string RELATORI_PERI_FINAL { get; set; }

        public static R1360_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1 Execute(R1360_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1 r1360_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1)
        {
            var ths = r1360_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1360_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1360_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_DATA_REFERENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}