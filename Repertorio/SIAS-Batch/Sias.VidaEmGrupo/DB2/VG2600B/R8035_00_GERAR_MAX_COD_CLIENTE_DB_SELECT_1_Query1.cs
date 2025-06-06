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
    public class R8035_00_GERAR_MAX_COD_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R8035_00_GERAR_MAX_COD_CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CLIENTE + 1
            INTO :CLIENTES-COD-CLIENTE
            FROM SEGUROS.NUMERO_OUTROS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CLIENTE + 1
											FROM SEGUROS.NUMERO_OUTROS
											WITH UR";

            return query;
        }
        public string CLIENTES_COD_CLIENTE { get; set; }

        public static R8035_00_GERAR_MAX_COD_CLIENTE_DB_SELECT_1_Query1 Execute(R8035_00_GERAR_MAX_COD_CLIENTE_DB_SELECT_1_Query1 r8035_00_GERAR_MAX_COD_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r8035_00_GERAR_MAX_COD_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8035_00_GERAR_MAX_COD_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8035_00_GERAR_MAX_COD_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}