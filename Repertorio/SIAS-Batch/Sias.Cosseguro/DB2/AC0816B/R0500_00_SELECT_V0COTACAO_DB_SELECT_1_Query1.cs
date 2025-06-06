using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0816B
{
    public class R0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 : QueryBasis<R0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_VENDA
            INTO :V0COTA-VAL-VENDA
            FROM SEGUROS.V0COTACAO
            WHERE CODUNIMO = :V0COTA-CODUNIMO
            AND DTINIVIG <= :V0COTA-DTINIVIG
            AND DTTERVIG >= :V0COTA-DTINIVIG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_VENDA
											FROM SEGUROS.V0COTACAO
											WHERE CODUNIMO = '{this.V0COTA_CODUNIMO}'
											AND DTINIVIG <= '{this.V0COTA_DTINIVIG}'
											AND DTTERVIG >= '{this.V0COTA_DTINIVIG}'
											WITH UR";

            return query;
        }
        public string V0COTA_VAL_VENDA { get; set; }
        public string V0COTA_CODUNIMO { get; set; }
        public string V0COTA_DTINIVIG { get; set; }

        public static R0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 Execute(R0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 r0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1)
        {
            var ths = r0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0COTA_VAL_VENDA = result[i++].Value?.ToString();
            return dta;
        }

    }
}