using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT3117S
{
    public class R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1 : QueryBasis<R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :HOST-COUNT
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO >= :HOST-DATA-INI
            AND DATA_CALENDARIO < :HOST-DATA-FIM
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO >= '{this.HOST_DATA_INI}'
											AND DATA_CALENDARIO < '{this.HOST_DATA_FIM}'";

            return query;
        }
        public string HOST_COUNT { get; set; }
        public string HOST_DATA_INI { get; set; }
        public string HOST_DATA_FIM { get; set; }

        public static R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1 Execute(R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1 r1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}