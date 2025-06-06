using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI4922B
{
    public class R110_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1 : QueryBasis<R110_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MIN(DATA_CALENDARIO)
            INTO :W-DATA-PROXIMO-DIA-UTIL
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO > :HOST-DATA-SISTEMA
            AND DATA_CALENDARIO <= :W-DATA-LIMITE-MAXIMO
            AND DIA_SEMANA IN ( '2' , '3' , '4' , '5' , '6' )
            AND FERIADO = ' '
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MIN(DATA_CALENDARIO)
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO > '{this.HOST_DATA_SISTEMA}'
											AND DATA_CALENDARIO <= '{this.W_DATA_LIMITE_MAXIMO}'
											AND DIA_SEMANA IN ( '2' 
							, '3' 
							, '4' 
							, '5' 
							, '6' )
											AND FERIADO = ' '";

            return query;
        }
        public string W_DATA_PROXIMO_DIA_UTIL { get; set; }
        public string W_DATA_LIMITE_MAXIMO { get; set; }
        public string HOST_DATA_SISTEMA { get; set; }

        public static R110_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1 Execute(R110_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1 r110_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1)
        {
            var ths = r110_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R110_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R110_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1();
            var i = 0;
            dta.W_DATA_PROXIMO_DIA_UTIL = result[i++].Value?.ToString();
            return dta;
        }

    }
}