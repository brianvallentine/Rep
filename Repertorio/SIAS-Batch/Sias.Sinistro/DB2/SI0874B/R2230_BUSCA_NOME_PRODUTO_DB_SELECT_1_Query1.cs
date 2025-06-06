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
    public class R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCR_PRODUTO
            INTO :PRODUTO-DESCR-PRODUTO
            FROM SEGUROS.PRODUTO
            WHERE COD_PRODUTO = :SITRATEM-COD-PRODUTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCR_PRODUTO
											FROM SEGUROS.PRODUTO
											WHERE COD_PRODUTO = '{this.SITRATEM_COD_PRODUTO}'
											WITH UR";

            return query;
        }
        public string PRODUTO_DESCR_PRODUTO { get; set; }
        public string SITRATEM_COD_PRODUTO { get; set; }

        public static R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1 Execute(R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1 r2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUTO_DESCR_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}