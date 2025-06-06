using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0213B
{
    public class R0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1 : QueryBasis<R0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MIN(DATA_CALENDARIO), '0001-01-01' )
            INTO :HOST-DATA-PROX-DIA-UTIL
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO > :SISTEMAS-DATA-MOV-ABERTO
            AND DIA_SEMANA NOT IN ( 'S' , 'D' )
            AND FERIADO <> 'N'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MIN(DATA_CALENDARIO)
							, '0001-01-01' )
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO > '{this.SISTEMAS_DATA_MOV_ABERTO}'
											AND DIA_SEMANA NOT IN ( 'S' 
							, 'D' )
											AND FERIADO <> 'N'";

            return query;
        }
        public string HOST_DATA_PROX_DIA_UTIL { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static R0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1 Execute(R0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1 r0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_DATA_PROX_DIA_UTIL = result[i++].Value?.ToString();
            return dta;
        }

    }
}