using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1000B
{
    public class R3700_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 : QueryBasis<R3700_00_SELECT_V0COTACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VAL_VENDA
            INTO :V0COTM-VAL-VNDA
            FROM SEGUROS.V0COTACAO
            WHERE CODUNIMO = :V1ENDO-MOEDA-PRM
            AND DTINIVIG <= :V1SIST-DTMOVABE
            AND DTTERVIG >= :V1SIST-DTMOVABE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VAL_VENDA
											FROM SEGUROS.V0COTACAO
											WHERE CODUNIMO = '{this.V1ENDO_MOEDA_PRM}'
											AND DTINIVIG <= '{this.V1SIST_DTMOVABE}'
											AND DTTERVIG >= '{this.V1SIST_DTMOVABE}'
											WITH UR";

            return query;
        }
        public string V0COTM_VAL_VNDA { get; set; }
        public string V1ENDO_MOEDA_PRM { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static R3700_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 Execute(R3700_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 r3700_00_SELECT_V0COTACAO_DB_SELECT_1_Query1)
        {
            var ths = r3700_00_SELECT_V0COTACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3700_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3700_00_SELECT_V0COTACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0COTM_VAL_VNDA = result[i++].Value?.ToString();
            return dta;
        }

    }
}