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
    public class R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1 : QueryBasis<R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMPDT
            INTO :V0PROD-NOMPDT
            FROM SEGUROS.V0PRODUTOR
            WHERE CODPDT = :V0PROD-CODPDT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMPDT
											FROM SEGUROS.V0PRODUTOR
											WHERE CODPDT = '{this.V0PROD_CODPDT}'";

            return query;
        }
        public string V0PROD_NOMPDT { get; set; }
        public string V0PROD_CODPDT { get; set; }

        public static R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1 Execute(R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1 r2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1)
        {
            var ths = r2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROD_NOMPDT = result[i++].Value?.ToString();
            return dta;
        }

    }
}