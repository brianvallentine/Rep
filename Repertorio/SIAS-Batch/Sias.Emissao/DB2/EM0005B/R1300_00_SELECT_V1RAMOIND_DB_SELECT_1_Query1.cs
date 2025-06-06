using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0005B
{
    public class R1300_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            PCIOF
            INTO :V1RAMO-PCIOF
            FROM SEGUROS.V1RAMOIND
            WHERE RAMO = :V1PROP-RAMO
            AND DTINIVIG <= :V1PROP-DTINIVIG
            AND DTTERVIG >= :V1PROP-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											PCIOF
											FROM SEGUROS.V1RAMOIND
											WHERE RAMO = '{this.V1PROP_RAMO}'
											AND DTINIVIG <= '{this.V1PROP_DTINIVIG}'
											AND DTTERVIG >= '{this.V1PROP_DTINIVIG}'";

            return query;
        }
        public string V1RAMO_PCIOF { get; set; }
        public string V1PROP_DTINIVIG { get; set; }
        public string V1PROP_RAMO { get; set; }

        public static R1300_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1 r1300_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1RAMO_PCIOF = result[i++].Value?.ToString();
            return dta;
        }

    }
}