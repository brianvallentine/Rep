using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0061B
{
    public class R1800_LE_TAB_PLANO_DB_SELECT_2_Query1 : QueryBasis<R1800_LE_TAB_PLANO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_RCAP,
            VAL_RCAP
            INTO
            :RCAPS-NUM-RCAP,
            :RCAPS-VAL-RCAP
            FROM SEGUROS.RCAPS
            WHERE NUM_TITULO =:RCAPS-NUM-TITULO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_RCAP
							,
											VAL_RCAP
											FROM SEGUROS.RCAPS
											WHERE NUM_TITULO ='{this.RCAPS_NUM_TITULO}'";

            return query;
        }
        public string RCAPS_NUM_RCAP { get; set; }
        public string RCAPS_VAL_RCAP { get; set; }
        public string RCAPS_NUM_TITULO { get; set; }

        public static R1800_LE_TAB_PLANO_DB_SELECT_2_Query1 Execute(R1800_LE_TAB_PLANO_DB_SELECT_2_Query1 r1800_LE_TAB_PLANO_DB_SELECT_2_Query1)
        {
            var ths = r1800_LE_TAB_PLANO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1800_LE_TAB_PLANO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1800_LE_TAB_PLANO_DB_SELECT_2_Query1();
            var i = 0;
            dta.RCAPS_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_VAL_RCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}