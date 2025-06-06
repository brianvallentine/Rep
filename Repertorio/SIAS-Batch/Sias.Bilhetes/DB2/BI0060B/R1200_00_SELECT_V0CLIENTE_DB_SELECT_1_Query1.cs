using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0060B
{
    public class R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO
            INTO :CLIENTES-NOME-RAZAO
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :APOLICES-COD-CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.APOLICES_COD_CLIENTE}'";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string APOLICES_COD_CLIENTE { get; set; }

        public static R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 r1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}