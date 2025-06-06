using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0812B
{
    public class R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1 : QueryBasis<R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VAL_VENDA
            INTO
            :V1COTA-VAL-VENDA
            FROM
            SEGUROS.V1COTACAO
            WHERE
            CODUNIMO = :V1COTA-CODUNIMO
            AND DTINIVIG <= :V1COTA-DTINIVIG
            AND DTTERVIG >= :V1COTA-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VAL_VENDA
											FROM
											SEGUROS.V1COTACAO
											WHERE
											CODUNIMO = '{this.V1COTA_CODUNIMO}'
											AND DTINIVIG <= '{this.V1COTA_DTINIVIG}'
											AND DTTERVIG >= '{this.V1COTA_DTINIVIG}'";

            return query;
        }
        public string V1COTA_VAL_VENDA { get; set; }
        public string V1COTA_CODUNIMO { get; set; }
        public string V1COTA_DTINIVIG { get; set; }

        public static R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1 Execute(R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1 r2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1)
        {
            var ths = r2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2400_00_SELECT_V1COTACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1COTA_VAL_VENDA = result[i++].Value?.ToString();
            return dta;
        }

    }
}