using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0071B
{
    public class R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO
            INTO :V1CLIEN-NOME-RAZAO
            FROM SEGUROS.V1CLIENTE
            WHERE COD_CLIENTE = :V1CLIEN-COD-CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
											FROM SEGUROS.V1CLIENTE
											WHERE COD_CLIENTE = '{this.V1CLIEN_COD_CLIENTE}'";

            return query;
        }
        public string V1CLIEN_NOME_RAZAO { get; set; }
        public string V1CLIEN_COD_CLIENTE { get; set; }

        public static R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1 Execute(R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1 r0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1CLIEN_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}