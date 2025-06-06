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
    public class R0440_00_SELECT_V0ESCNEG_DB_SELECT_1_Query1 : QueryBasis<R0440_00_SELECT_V0ESCNEG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_ESCNEG
            INTO :ESCRINEG-COD-ESCNEG
            FROM SEGUROS.ESCRITORIO_NEGOCIO
            WHERE COD_ESCNEG = :ESCRINEG-COD-ESCNEG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_ESCNEG
											FROM SEGUROS.ESCRITORIO_NEGOCIO
											WHERE COD_ESCNEG = '{this.ESCRINEG_COD_ESCNEG}'";

            return query;
        }
        public string ESCRINEG_COD_ESCNEG { get; set; }

        public static R0440_00_SELECT_V0ESCNEG_DB_SELECT_1_Query1 Execute(R0440_00_SELECT_V0ESCNEG_DB_SELECT_1_Query1 r0440_00_SELECT_V0ESCNEG_DB_SELECT_1_Query1)
        {
            var ths = r0440_00_SELECT_V0ESCNEG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0440_00_SELECT_V0ESCNEG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0440_00_SELECT_V0ESCNEG_DB_SELECT_1_Query1();
            var i = 0;
            dta.ESCRINEG_COD_ESCNEG = result[i++].Value?.ToString();
            return dta;
        }

    }
}