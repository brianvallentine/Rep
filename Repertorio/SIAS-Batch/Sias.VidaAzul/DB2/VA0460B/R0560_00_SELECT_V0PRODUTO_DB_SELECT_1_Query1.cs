using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0460B
{
    public class R0560_00_SELECT_V0PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R0560_00_SELECT_V0PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT RAMO_EMISSOR
            INTO :PRODUTO-RAMO-EMISSOR
            FROM SEGUROS.PRODUTO
            WHERE COD_PRODUTO = :PRODUTO-COD-PRODUTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT RAMO_EMISSOR
											FROM SEGUROS.PRODUTO
											WHERE COD_PRODUTO = '{this.PRODUTO_COD_PRODUTO}'";

            return query;
        }
        public string PRODUTO_RAMO_EMISSOR { get; set; }
        public string PRODUTO_COD_PRODUTO { get; set; }

        public static R0560_00_SELECT_V0PRODUTO_DB_SELECT_1_Query1 Execute(R0560_00_SELECT_V0PRODUTO_DB_SELECT_1_Query1 r0560_00_SELECT_V0PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r0560_00_SELECT_V0PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0560_00_SELECT_V0PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0560_00_SELECT_V0PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUTO_RAMO_EMISSOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}