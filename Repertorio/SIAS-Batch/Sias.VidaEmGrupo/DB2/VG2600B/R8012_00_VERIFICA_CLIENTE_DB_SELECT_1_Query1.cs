using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8012_00_VERIFICA_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R8012_00_VERIFICA_CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE,
            NOME_RAZAO
            INTO :CLIENTES-COD-CLIENTE,
            :CLIENTES-NOME-RAZAO
            FROM SEGUROS.CLIENTES
            WHERE CGCCPF = :CLIENTES-CGCCPF
            ORDER BY COD_CLIENTE DESC
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
							,
											NOME_RAZAO
											FROM SEGUROS.CLIENTES
											WHERE CGCCPF = '{this.CLIENTES_CGCCPF}'
											ORDER BY COD_CLIENTE DESC
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string CLIENTES_COD_CLIENTE { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }

        public static R8012_00_VERIFICA_CLIENTE_DB_SELECT_1_Query1 Execute(R8012_00_VERIFICA_CLIENTE_DB_SELECT_1_Query1 r8012_00_VERIFICA_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r8012_00_VERIFICA_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8012_00_VERIFICA_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8012_00_VERIFICA_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_COD_CLIENTE = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}