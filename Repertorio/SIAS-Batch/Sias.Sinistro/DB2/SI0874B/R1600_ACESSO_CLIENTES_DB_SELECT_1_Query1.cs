using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0874B
{
    public class R1600_ACESSO_CLIENTES_DB_SELECT_1_Query1 : QueryBasis<R1600_ACESSO_CLIENTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO, CGCCPF
            INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :HOST-COD-CLIENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
							, CGCCPF
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.HOST_COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string HOST_COD_CLIENTE { get; set; }

        public static R1600_ACESSO_CLIENTES_DB_SELECT_1_Query1 Execute(R1600_ACESSO_CLIENTES_DB_SELECT_1_Query1 r1600_ACESSO_CLIENTES_DB_SELECT_1_Query1)
        {
            var ths = r1600_ACESSO_CLIENTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1600_ACESSO_CLIENTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1600_ACESSO_CLIENTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}