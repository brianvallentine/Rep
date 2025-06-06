using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0007B
{
    public class R1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 : QueryBasis<R1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODUNIMO,
            VAL_VENDA
            INTO :V0COTA-CODUNIMO,
            :V0COTA-VALVENDA
            FROM SEGUROS.V0COTACAO
            WHERE CODUNIMO = :V0ENDO-MOEDA-PRM
            AND DTINIVIG <= :V0ENDO-DTINIVIG
            AND DTTERVIG >= :V0ENDO-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODUNIMO
							,
											VAL_VENDA
											FROM SEGUROS.V0COTACAO
											WHERE CODUNIMO = '{this.V0ENDO_MOEDA_PRM}'
											AND DTINIVIG <= '{this.V0ENDO_DTINIVIG}'
											AND DTTERVIG >= '{this.V0ENDO_DTINIVIG}'";

            return query;
        }
        public string V0COTA_CODUNIMO { get; set; }
        public string V0COTA_VALVENDA { get; set; }
        public string V0ENDO_MOEDA_PRM { get; set; }
        public string V0ENDO_DTINIVIG { get; set; }

        public static R1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 Execute(R1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 r1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1)
        {
            var ths = r1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1600_00_SELECT_V0COTACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0COTA_CODUNIMO = result[i++].Value?.ToString();
            dta.V0COTA_VALVENDA = result[i++].Value?.ToString();
            return dta;
        }

    }
}