using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0811B
{
    public class R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_EMPRESA,
            COD_PRODUTO
            INTO :PRODUTO-COD-EMPRESA,
            :PRODUTO-COD-PRODUTO
            FROM SEGUROS.PRODUTO
            WHERE COD_PRODUTO = :SINISMES-COD-PRODUTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_EMPRESA
							,
											COD_PRODUTO
											FROM SEGUROS.PRODUTO
											WHERE COD_PRODUTO = '{this.SINISMES_COD_PRODUTO}'
											WITH UR";

            return query;
        }
        public string PRODUTO_COD_EMPRESA { get; set; }
        public string PRODUTO_COD_PRODUTO { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }

        public static R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1 Execute(R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1 r0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUTO_COD_EMPRESA = result[i++].Value?.ToString();
            dta.PRODUTO_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}