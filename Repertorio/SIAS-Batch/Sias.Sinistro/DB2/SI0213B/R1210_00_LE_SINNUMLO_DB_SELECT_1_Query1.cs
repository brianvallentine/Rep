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
    public class R1210_00_LE_SINNUMLO_DB_SELECT_1_Query1 : QueryBasis<R1210_00_LE_SINNUMLO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_LOTE,
            TIMESTAMP
            INTO :SINNUMLO-NUM-LOTE,
            :SINNUMLO-TIMESTAMP
            FROM SEGUROS.SINISTRO_NUM_LOTE
            WHERE COD_FONTE = :SINNUMLO-COD-FONTE
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_LOTE
							,
											TIMESTAMP
											FROM SEGUROS.SINISTRO_NUM_LOTE
											WHERE COD_FONTE = '{this.SINNUMLO_COD_FONTE}'";

            return query;
        }
        public string SINNUMLO_NUM_LOTE { get; set; }
        public string SINNUMLO_TIMESTAMP { get; set; }
        public string SINNUMLO_COD_FONTE { get; set; }

        public static R1210_00_LE_SINNUMLO_DB_SELECT_1_Query1 Execute(R1210_00_LE_SINNUMLO_DB_SELECT_1_Query1 r1210_00_LE_SINNUMLO_DB_SELECT_1_Query1)
        {
            var ths = r1210_00_LE_SINNUMLO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1210_00_LE_SINNUMLO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1210_00_LE_SINNUMLO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINNUMLO_NUM_LOTE = result[i++].Value?.ToString();
            dta.SINNUMLO_TIMESTAMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}