using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0340B
{
    public class R0050_00_INICIO_DB_SELECT_2_Query1 : QueryBasis<R0050_00_INICIO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_CALENDARIO
            INTO :CALENDAR-DATA-CALENDARIO
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :SIST-CURRDATE
            AND DIA_SEMANA IN ( 'S' , 'D' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_CALENDARIO
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.SIST_CURRDATE}'
											AND DIA_SEMANA IN ( 'S' 
							, 'D' )";

            return query;
        }
        public string CALENDAR_DATA_CALENDARIO { get; set; }
        public string SIST_CURRDATE { get; set; }

        public static R0050_00_INICIO_DB_SELECT_2_Query1 Execute(R0050_00_INICIO_DB_SELECT_2_Query1 r0050_00_INICIO_DB_SELECT_2_Query1)
        {
            var ths = r0050_00_INICIO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0050_00_INICIO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0050_00_INICIO_DB_SELECT_2_Query1();
            var i = 0;
            dta.CALENDAR_DATA_CALENDARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}