using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0077B
{
    public class R1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_VENDA
            INTO :V0COTA-VL-VENDA
            FROM SEGUROS.V0COTACAO
            WHERE CODUNIMO = :V1MSIN-COD-MOEDA
            AND DTINIVIG <= :V1HSIN-DTMOVTO
            AND DTTERVIG >= :V1HSIN-DTMOVTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_VENDA
											FROM SEGUROS.V0COTACAO
											WHERE CODUNIMO = '{this.V1MSIN_COD_MOEDA}'
											AND DTINIVIG <= '{this.V1HSIN_DTMOVTO}'
											AND DTTERVIG >= '{this.V1HSIN_DTMOVTO}'";

            return query;
        }
        public string V0COTA_VL_VENDA { get; set; }
        public string V1MSIN_COD_MOEDA { get; set; }
        public string V1HSIN_DTMOVTO { get; set; }

        public static R1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 r1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0COTA_VL_VENDA = result[i++].Value?.ToString();
            return dta;
        }

    }
}