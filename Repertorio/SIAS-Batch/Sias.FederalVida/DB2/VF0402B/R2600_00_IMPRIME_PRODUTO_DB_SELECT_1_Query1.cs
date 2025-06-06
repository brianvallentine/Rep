using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0402B
{
    public class R2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCRPROD
            INTO :V0PDVG-NOMPRODU
            FROM SEGUROS.V0PRODUTO
            WHERE CODPRODU = :V0PDVG-CODPRODU
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCRPROD
											FROM SEGUROS.V0PRODUTO
											WHERE CODPRODU = '{this.V0PDVG_CODPRODU}'";

            return query;
        }
        public string V0PDVG_NOMPRODU { get; set; }
        public string V0PDVG_CODPRODU { get; set; }

        public static R2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1 Execute(R2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1 r2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PDVG_NOMPRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}