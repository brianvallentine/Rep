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
    public class R1755_00_SELECT_CLIENTES_DB_SELECT_1_Query1 : QueryBasis<R1755_00_SELECT_CLIENTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_NASCIMENTO
            INTO :CLIENTES-DATA-NASCIMENTO
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE= :PROPOVA-COD-CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_NASCIMENTO
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE= '{this.PROPOVA_COD_CLIENTE}'";

            return query;
        }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }

        public static R1755_00_SELECT_CLIENTES_DB_SELECT_1_Query1 Execute(R1755_00_SELECT_CLIENTES_DB_SELECT_1_Query1 r1755_00_SELECT_CLIENTES_DB_SELECT_1_Query1)
        {
            var ths = r1755_00_SELECT_CLIENTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1755_00_SELECT_CLIENTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1755_00_SELECT_CLIENTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_DATA_NASCIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}