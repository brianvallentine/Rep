using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PR0100B
{
    public class R7000_00_DELETE_V1RELATO_DB_DELETE_1_Delete1 : QueryBasis<R7000_00_DELETE_V1RELATO_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS
            WHERE IDSISTEM = 'PR'
            AND CODRELAT = 'PR0100B1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.V0RELATORIOS
				WHERE IDSISTEM = 'PR'
				AND CODRELAT = 'PR0100B1'";

            return query;
        }

        public static void Execute(R7000_00_DELETE_V1RELATO_DB_DELETE_1_Delete1 r7000_00_DELETE_V1RELATO_DB_DELETE_1_Delete1)
        {
            var ths = r7000_00_DELETE_V1RELATO_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7000_00_DELETE_V1RELATO_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}