using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0140B
{
    public class R0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1 : QueryBasis<R0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_CALENDARIO
            ,DATA_CALENDARIO +
            :WHOST-PERI MONTHS - 1 DAYS
            INTO :WHOST-DTINI01
            ,:WHOST-DTTER01
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :WHOST-DTINI01
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_CALENDARIO
											,DATA_CALENDARIO +
											{this.WHOST_PERI} MONTHS - 1 DAYS
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.WHOST_DTINI01}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string WHOST_DTINI01 { get; set; }
        public string WHOST_DTTER01 { get; set; }
        public string WHOST_PERI { get; set; }

        public static R0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1 Execute(R0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1 r0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1)
        {
            var ths = r0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DTINI01 = result[i++].Value?.ToString();
            dta.WHOST_DTTER01 = result[i++].Value?.ToString();
            return dta;
        }

    }
}