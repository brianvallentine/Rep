using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT2036B
{
    public class R0130_DEL_V0RELATORIOS_DB_DELETE_1_Delete1 : QueryBasis<R0130_DEL_V0RELATORIOS_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL DELETE FROM
            SEGUROS.V0RELATORIOS
            WHERE
            IDSISTEM = 'LT'
            AND CODRELAT = 'LT2036B1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM
				SEGUROS.V0RELATORIOS
				WHERE
				IDSISTEM = 'LT'
				AND CODRELAT = 'LT2036B1'";

            return query;
        }

        public static void Execute(R0130_DEL_V0RELATORIOS_DB_DELETE_1_Delete1 r0130_DEL_V0RELATORIOS_DB_DELETE_1_Delete1)
        {
            var ths = r0130_DEL_V0RELATORIOS_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0130_DEL_V0RELATORIOS_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}