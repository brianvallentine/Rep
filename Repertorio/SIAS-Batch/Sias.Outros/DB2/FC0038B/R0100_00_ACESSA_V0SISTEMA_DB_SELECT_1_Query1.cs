using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FC0038B
{
    public class R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1 : QueryBasis<R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE,
            (DTMOVABE + 1 DAY)
            INTO :V0SIST-DTMOVABE,
            :WHOST-DTMOVABE
            FROM SEGUROS.V0SISTEMA
            WHERE IDSISTEM = 'FI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
							,
											(DTMOVABE + 1 DAY)
											FROM SEGUROS.V0SISTEMA
											WHERE IDSISTEM = 'FI'";

            return query;
        }
        public string V0SIST_DTMOVABE { get; set; }
        public string WHOST_DTMOVABE { get; set; }

        public static R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1 Execute(R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1 r0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = r0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SIST_DTMOVABE = result[i++].Value?.ToString();
            dta.WHOST_DTMOVABE = result[i++].Value?.ToString();
            return dta;
        }

    }
}