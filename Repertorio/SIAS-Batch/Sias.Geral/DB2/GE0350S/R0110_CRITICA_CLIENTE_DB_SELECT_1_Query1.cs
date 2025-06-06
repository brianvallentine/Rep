using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0350S
{
    public class R0110_CRITICA_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R0110_CRITICA_CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :CLIENTES-COD-CLIENTE
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.CLIENTES_COD_CLIENTE}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string CLIENTES_COD_CLIENTE { get; set; }

        public static R0110_CRITICA_CLIENTE_DB_SELECT_1_Query1 Execute(R0110_CRITICA_CLIENTE_DB_SELECT_1_Query1 r0110_CRITICA_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r0110_CRITICA_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0110_CRITICA_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0110_CRITICA_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}