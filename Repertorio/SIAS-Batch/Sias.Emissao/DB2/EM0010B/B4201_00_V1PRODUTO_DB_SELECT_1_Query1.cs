using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class B4201_00_V1PRODUTO_DB_SELECT_1_Query1 : QueryBasis<B4201_00_V1PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(IDEIMPESPC, 'N' )
            INTO
            :V1PROD-IDEIMPESPC
            FROM
            SEGUROS.V1PRODUTO
            WHERE
            CODPRODU = :ENDO-CODPRODU
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(IDEIMPESPC
							, 'N' )
											FROM
											SEGUROS.V1PRODUTO
											WHERE
											CODPRODU = '{this.ENDO_CODPRODU}'
											WITH UR";

            return query;
        }
        public string V1PROD_IDEIMPESPC { get; set; }
        public string ENDO_CODPRODU { get; set; }

        public static B4201_00_V1PRODUTO_DB_SELECT_1_Query1 Execute(B4201_00_V1PRODUTO_DB_SELECT_1_Query1 b4201_00_V1PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = b4201_00_V1PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B4201_00_V1PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B4201_00_V1PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PROD_IDEIMPESPC = result[i++].Value?.ToString();
            return dta;
        }

    }
}