using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6032B
{
    public class R0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1 : QueryBasis<R0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TITULO
            INTO :MOVIMCOB-NUM-TITULO
            FROM SEGUROS.MOVIMENTO_COBRANCA
            WHERE NUM_TITULO = :MOVIMCOB-NUM-TITULO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_TITULO
											FROM SEGUROS.MOVIMENTO_COBRANCA
											WHERE NUM_TITULO = '{this.MOVIMCOB_NUM_TITULO}'";

            return query;
        }
        public string MOVIMCOB_NUM_TITULO { get; set; }

        public static R0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1 Execute(R0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1 r0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1)
        {
            var ths = r0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVIMCOB_NUM_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}