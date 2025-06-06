using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0846B
{
    public class R040_000_SELECT_V0FRANQ_VASPEX_DB_SELECT_1_Query1 : QueryBasis<R040_000_SELECT_V0FRANQ_VASPEX_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :V0FRANQ-COD-CLIENTE
            FROM SEGUROS.V0FRANQ_VASPEX
            WHERE COD_FRANQUEADO = :V0FRANQ-COD-FRANQUEADO
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.V0FRANQ_VASPEX
											WHERE COD_FRANQUEADO = '{this.V0FRANQ_COD_FRANQUEADO}'
											AND SITUACAO = '0'";

            return query;
        }
        public string V0FRANQ_COD_CLIENTE { get; set; }
        public string V0FRANQ_COD_FRANQUEADO { get; set; }

        public static R040_000_SELECT_V0FRANQ_VASPEX_DB_SELECT_1_Query1 Execute(R040_000_SELECT_V0FRANQ_VASPEX_DB_SELECT_1_Query1 r040_000_SELECT_V0FRANQ_VASPEX_DB_SELECT_1_Query1)
        {
            var ths = r040_000_SELECT_V0FRANQ_VASPEX_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R040_000_SELECT_V0FRANQ_VASPEX_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R040_000_SELECT_V0FRANQ_VASPEX_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0FRANQ_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}