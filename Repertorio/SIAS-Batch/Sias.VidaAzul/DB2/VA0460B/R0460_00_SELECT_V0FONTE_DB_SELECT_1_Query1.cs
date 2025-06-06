using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0460B
{
    public class R0460_00_SELECT_V0FONTE_DB_SELECT_1_Query1 : QueryBasis<R0460_00_SELECT_V0FONTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE
            INTO :FONTES-COD-FONTE
            FROM SEGUROS.FONTES
            WHERE COD_FONTE = :FONTES-COD-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
											FROM SEGUROS.FONTES
											WHERE COD_FONTE = '{this.FONTES_COD_FONTE}'";

            return query;
        }
        public string FONTES_COD_FONTE { get; set; }

        public static R0460_00_SELECT_V0FONTE_DB_SELECT_1_Query1 Execute(R0460_00_SELECT_V0FONTE_DB_SELECT_1_Query1 r0460_00_SELECT_V0FONTE_DB_SELECT_1_Query1)
        {
            var ths = r0460_00_SELECT_V0FONTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0460_00_SELECT_V0FONTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0460_00_SELECT_V0FONTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.FONTES_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}