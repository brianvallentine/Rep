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
    public class R1200_00_SELECT_V1FONTE_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_V1FONTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            ORGAOEMIS
            INTO :V1FONT-ORGAOEMIS
            FROM SEGUROS.V1FONTE
            WHERE FONTE = :V1PROP-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											ORGAOEMIS
											FROM SEGUROS.V1FONTE
											WHERE FONTE = '{this.V1PROP_FONTE}'";

            return query;
        }
        public string V1FONT_ORGAOEMIS { get; set; }
        public string V1PROP_FONTE { get; set; }

        public static R1200_00_SELECT_V1FONTE_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_V1FONTE_DB_SELECT_1_Query1 r1200_00_SELECT_V1FONTE_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_V1FONTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_V1FONTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_V1FONTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1FONT_ORGAOEMIS = result[i++].Value?.ToString();
            return dta;
        }

    }
}