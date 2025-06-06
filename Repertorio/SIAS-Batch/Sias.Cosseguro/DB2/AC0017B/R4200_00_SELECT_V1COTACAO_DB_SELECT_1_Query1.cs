using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0017B
{
    public class R4200_00_SELECT_V1COTACAO_DB_SELECT_1_Query1 : QueryBasis<R4200_00_SELECT_V1COTACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_VENDA
            INTO :V1COTA-VL-VENDA
            FROM SEGUROS.V1COTACAO
            WHERE CODUNIMO = :V1MSIN-COD-MOEDA
            AND DTINIVIG <= :V2HSIN-DTMOVTO
            AND DTTERVIG >= :V2HSIN-DTMOVTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_VENDA
											FROM SEGUROS.V1COTACAO
											WHERE CODUNIMO = '{this.V1MSIN_COD_MOEDA}'
											AND DTINIVIG <= '{this.V2HSIN_DTMOVTO}'
											AND DTTERVIG >= '{this.V2HSIN_DTMOVTO}'";

            return query;
        }
        public string V1COTA_VL_VENDA { get; set; }
        public string V1MSIN_COD_MOEDA { get; set; }
        public string V2HSIN_DTMOVTO { get; set; }

        public static R4200_00_SELECT_V1COTACAO_DB_SELECT_1_Query1 Execute(R4200_00_SELECT_V1COTACAO_DB_SELECT_1_Query1 r4200_00_SELECT_V1COTACAO_DB_SELECT_1_Query1)
        {
            var ths = r4200_00_SELECT_V1COTACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4200_00_SELECT_V1COTACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4200_00_SELECT_V1COTACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1COTA_VL_VENDA = result[i++].Value?.ToString();
            return dta;
        }

    }
}