using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0843B
{
    public class R0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO
            INTO :V0NOME-RAZAO
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :V0COD-FRANQUE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.V0COD_FRANQUE}'";

            return query;
        }
        public string V0NOME_RAZAO { get; set; }
        public string V0COD_FRANQUE { get; set; }

        public static R0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 Execute(R0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 r0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}