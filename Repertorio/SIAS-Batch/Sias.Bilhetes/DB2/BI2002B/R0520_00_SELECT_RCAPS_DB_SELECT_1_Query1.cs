using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI2002B
{
    public class R0520_00_SELECT_RCAPS_DB_SELECT_1_Query1 : QueryBasis<R0520_00_SELECT_RCAPS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE
            ,NUM_RCAP
            INTO :RCAPS-COD-FONTE
            ,:RCAPS-NUM-RCAP
            FROM SEGUROS.RCAPS
            WHERE NUM_TITULO = :CBCONDEV-NUM-TITULO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
											,NUM_RCAP
											FROM SEGUROS.RCAPS
											WHERE NUM_TITULO = '{this.CBCONDEV_NUM_TITULO}'
											WITH UR";

            return query;
        }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }
        public string CBCONDEV_NUM_TITULO { get; set; }

        public static R0520_00_SELECT_RCAPS_DB_SELECT_1_Query1 Execute(R0520_00_SELECT_RCAPS_DB_SELECT_1_Query1 r0520_00_SELECT_RCAPS_DB_SELECT_1_Query1)
        {
            var ths = r0520_00_SELECT_RCAPS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0520_00_SELECT_RCAPS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0520_00_SELECT_RCAPS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_COD_FONTE = result[i++].Value?.ToString();
            dta.RCAPS_NUM_RCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}