using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0006S
{
    public class LOOP_CALEND_DB_SELECT_1_Query1 : QueryBasis<LOOP_CALEND_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_CALENDARIO
            INTO :CALENDAR-DATA-CALENDARIO
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :WHOST-DTTRAB
            AND DIA_SEMANA IN ( 'S' , 'D' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_CALENDARIO
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.WHOST_DTTRAB}'
											AND DIA_SEMANA IN ( 'S' 
							, 'D' )";

            return query;
        }
        public string CALENDAR_DATA_CALENDARIO { get; set; }
        public string WHOST_DTTRAB { get; set; }

        public static LOOP_CALEND_DB_SELECT_1_Query1 Execute(LOOP_CALEND_DB_SELECT_1_Query1 lOOP_CALEND_DB_SELECT_1_Query1)
        {
            var ths = lOOP_CALEND_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override LOOP_CALEND_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new LOOP_CALEND_DB_SELECT_1_Query1();
            var i = 0;
            dta.CALENDAR_DATA_CALENDARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}