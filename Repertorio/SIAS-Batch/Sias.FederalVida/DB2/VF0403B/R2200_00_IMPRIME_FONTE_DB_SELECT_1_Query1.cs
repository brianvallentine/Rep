using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0403B
{
    public class R2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1 : QueryBasis<R2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMEFTE
            INTO :V0FONT-NOMEFTE
            FROM SEGUROS.V0FONTE
            WHERE FONTE = :V0FONT-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMEFTE
											FROM SEGUROS.V0FONTE
											WHERE FONTE = '{this.V0FONT_FONTE}'";

            return query;
        }
        public string V0FONT_NOMEFTE { get; set; }
        public string V0FONT_FONTE { get; set; }

        public static R2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1 Execute(R2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1 r2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0FONT_NOMEFTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}