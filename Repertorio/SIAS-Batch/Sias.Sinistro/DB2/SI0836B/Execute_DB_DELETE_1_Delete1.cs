using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0836B
{
    public class Execute_DB_DELETE_1_Delete1 : QueryBasis<Execute_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE
            FROM SEGUROS.V0RELATORIOS
            WHERE IDSISTEM = 'SI'
            AND CODRELAT = 'SI0836B'
            END-EXEC
            */
            #endregion
            var query = @$"
				DELETE
				FROM SEGUROS.V0RELATORIOS
				WHERE IDSISTEM = 'SI'
				AND CODRELAT = 'SI0836B'";

            return query;
        }

        public static void Execute(Execute_DB_DELETE_1_Delete1 execute_DB_DELETE_1_Delete1)
        {
            var ths = execute_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override Execute_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}