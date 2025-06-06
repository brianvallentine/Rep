using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1650B
{
    public class R3010_00_MOVE_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R3010_00_MOVE_CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(COD_CLIENTE),0)
            INTO :CLIENTES-COD-CLIENTE
            FROM SEGUROS.CLIENTES
            WHERE CGCCPF = :CLIENTES-CGCCPF
            AND DATA_NASCIMENTO = :CLIENTES-DATA-NASCIMENTO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(COD_CLIENTE)
							,0)
											FROM SEGUROS.CLIENTES
											WHERE CGCCPF = '{this.CLIENTES_CGCCPF}'
											AND DATA_NASCIMENTO = '{this.CLIENTES_DATA_NASCIMENTO}'";

            return query;
        }
        public string CLIENTES_COD_CLIENTE { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }

        public static R3010_00_MOVE_CLIENTE_DB_SELECT_1_Query1 Execute(R3010_00_MOVE_CLIENTE_DB_SELECT_1_Query1 r3010_00_MOVE_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r3010_00_MOVE_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3010_00_MOVE_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3010_00_MOVE_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}