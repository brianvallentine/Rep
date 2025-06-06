using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0815B
{
    public class R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VAL_VENDA
            INTO
            :V1MOED-VLCRUZAD
            FROM
            SEGUROS.V1COTACAO
            WHERE
            CODUNIMO = :V1MOED-CODUNIMO
            AND DTINIVIG <= :V1MOED-DTINIVIG
            AND DTTERVIG >= :V1MOED-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VAL_VENDA
											FROM
											SEGUROS.V1COTACAO
											WHERE
											CODUNIMO = '{this.V1MOED_CODUNIMO}'
											AND DTINIVIG <= '{this.V1MOED_DTINIVIG}'
											AND DTTERVIG >= '{this.V1MOED_DTINIVIG}'";

            return query;
        }
        public string V1MOED_VLCRUZAD { get; set; }
        public string V1MOED_CODUNIMO { get; set; }
        public string V1MOED_DTINIVIG { get; set; }

        public static R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 r1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_V1MOEDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1MOED_VLCRUZAD = result[i++].Value?.ToString();
            return dta;
        }

    }
}