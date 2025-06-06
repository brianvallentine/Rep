using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0847B
{
    public class R2200_00_SELECT_V1FONTE_DB_SELECT_1_Query1 : QueryBasis<R2200_00_SELECT_V1FONTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMEFTE
            INTO :V1FONT-NOMEFTE
            FROM SEGUROS.V1FONTE
            WHERE FONTE = :V1MSIN-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMEFTE
											FROM SEGUROS.V1FONTE
											WHERE FONTE = '{this.V1MSIN_FONTE}'";

            return query;
        }
        public string V1FONT_NOMEFTE { get; set; }
        public string V1MSIN_FONTE { get; set; }

        public static R2200_00_SELECT_V1FONTE_DB_SELECT_1_Query1 Execute(R2200_00_SELECT_V1FONTE_DB_SELECT_1_Query1 r2200_00_SELECT_V1FONTE_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_SELECT_V1FONTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_SELECT_V1FONTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_SELECT_V1FONTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1FONT_NOMEFTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}