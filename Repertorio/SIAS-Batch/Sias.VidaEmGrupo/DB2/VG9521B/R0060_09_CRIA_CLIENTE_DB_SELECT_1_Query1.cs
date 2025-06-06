using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9521B
{
    public class R0060_09_CRIA_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R0060_09_CRIA_CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_CLIENTE
            INTO :SEGURVGA-COD-CLIENTE
            FROM SEGUROS.NUMERO_OUTROS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_CLIENTE
											FROM SEGUROS.NUMERO_OUTROS";

            return query;
        }
        public string SEGURVGA_COD_CLIENTE { get; set; }

        public static R0060_09_CRIA_CLIENTE_DB_SELECT_1_Query1 Execute(R0060_09_CRIA_CLIENTE_DB_SELECT_1_Query1 r0060_09_CRIA_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r0060_09_CRIA_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0060_09_CRIA_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0060_09_CRIA_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURVGA_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}