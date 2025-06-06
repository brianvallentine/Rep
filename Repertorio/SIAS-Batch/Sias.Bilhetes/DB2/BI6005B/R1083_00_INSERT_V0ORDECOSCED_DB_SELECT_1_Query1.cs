using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6005B
{
    public class R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1 : QueryBasis<R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRORDEM
            INTO :V1NCOS-NRORDEM
            FROM SEGUROS.V1NUMERO_COSSEGURO
            WHERE ORGAO = :V1NCOS-ORGAO
            AND CONGENER = :V1NCOS-CONGENER
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRORDEM
											FROM SEGUROS.V1NUMERO_COSSEGURO
											WHERE ORGAO = '{this.V1NCOS_ORGAO}'
											AND CONGENER = '{this.V1NCOS_CONGENER}'
											WITH UR";

            return query;
        }
        public string V1NCOS_NRORDEM { get; set; }
        public string V1NCOS_CONGENER { get; set; }
        public string V1NCOS_ORGAO { get; set; }

        public static R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1 Execute(R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1 r1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1)
        {
            var ths = r1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1NCOS_NRORDEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}