using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PR0011B
{
    public class R5000_00_SELECT_V1FONTES_DB_SELECT_1_Query1 : QueryBasis<R5000_00_SELECT_V1FONTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NOMEFTE
            INTO :V1FONTES-NOMEFTE
            FROM SEGUROS.V1FONTE
            WHERE FONTE = :V1ACOMPR-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NOMEFTE
											FROM SEGUROS.V1FONTE
											WHERE FONTE = '{this.V1ACOMPR_FONTE}'";

            return query;
        }
        public string V1FONTES_NOMEFTE { get; set; }
        public string V1ACOMPR_FONTE { get; set; }

        public static R5000_00_SELECT_V1FONTES_DB_SELECT_1_Query1 Execute(R5000_00_SELECT_V1FONTES_DB_SELECT_1_Query1 r5000_00_SELECT_V1FONTES_DB_SELECT_1_Query1)
        {
            var ths = r5000_00_SELECT_V1FONTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5000_00_SELECT_V1FONTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5000_00_SELECT_V1FONTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1FONTES_NOMEFTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}