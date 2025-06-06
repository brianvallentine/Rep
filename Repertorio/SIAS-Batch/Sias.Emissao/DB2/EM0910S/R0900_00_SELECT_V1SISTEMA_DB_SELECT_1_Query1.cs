using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0910S
{
    public class R0900_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 : QueryBasis<R0900_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE
            INTO :V0SIST-DTMOVABE
            FROM SEGUROS.V0SISTEMA
            WHERE IDSISTEM = 'EM'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
											FROM SEGUROS.V0SISTEMA
											WHERE IDSISTEM = 'EM'";

            return query;
        }
        public string V0SIST_DTMOVABE { get; set; }

        public static R0900_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 Execute(R0900_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 r0900_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = r0900_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0900_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0900_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SIST_DTMOVABE = result[i++].Value?.ToString();
            return dta;
        }

    }
}