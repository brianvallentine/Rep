using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FI0100S
{
    public class R0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1 : QueryBasis<R0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMEFTE,
            PCDESISS
            INTO :V1FONT-NOMEFTE,
            :V1FONT-PCDESISS
            FROM SEGUROS.V1FONTE
            WHERE FONTE = :V1FONT-FONTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMEFTE
							,
											PCDESISS
											FROM SEGUROS.V1FONTE
											WHERE FONTE = '{this.V1FONT_FONTE}'
											WITH UR";

            return query;
        }
        public string V1FONT_NOMEFTE { get; set; }
        public string V1FONT_PCDESISS { get; set; }
        public string V1FONT_FONTE { get; set; }

        public static R0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1 Execute(R0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1 r0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1)
        {
            var ths = r0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1FONT_NOMEFTE = result[i++].Value?.ToString();
            dta.V1FONT_PCDESISS = result[i++].Value?.ToString();
            return dta;
        }

    }
}