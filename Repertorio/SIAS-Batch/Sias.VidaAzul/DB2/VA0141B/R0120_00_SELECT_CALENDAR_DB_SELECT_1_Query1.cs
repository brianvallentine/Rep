using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class R0120_00_SELECT_CALENDAR_DB_SELECT_1_Query1 : QueryBasis<R0120_00_SELECT_CALENDAR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_CALENDARIO
            ,DTH_ULT_DIA_MES
            INTO :CALENDAR-DATA-CALENDARIO
            ,:CALENDAR-DTH-ULT-DIA-MES
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :SISTEMAS-DATA-MOV-ABERTO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_CALENDARIO
											,DTH_ULT_DIA_MES
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.SISTEMAS_DATA_MOV_ABERTO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string CALENDAR_DATA_CALENDARIO { get; set; }
        public string CALENDAR_DTH_ULT_DIA_MES { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static R0120_00_SELECT_CALENDAR_DB_SELECT_1_Query1 Execute(R0120_00_SELECT_CALENDAR_DB_SELECT_1_Query1 r0120_00_SELECT_CALENDAR_DB_SELECT_1_Query1)
        {
            var ths = r0120_00_SELECT_CALENDAR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0120_00_SELECT_CALENDAR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0120_00_SELECT_CALENDAR_DB_SELECT_1_Query1();
            var i = 0;
            dta.CALENDAR_DATA_CALENDARIO = result[i++].Value?.ToString();
            dta.CALENDAR_DTH_ULT_DIA_MES = result[i++].Value?.ToString();
            return dta;
        }

    }
}