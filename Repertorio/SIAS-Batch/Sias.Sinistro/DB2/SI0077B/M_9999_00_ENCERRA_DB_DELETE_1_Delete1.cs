using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0077B
{
    public class M_9999_00_ENCERRA_DB_DELETE_1_Delete1 : QueryBasis<M_9999_00_ENCERRA_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM SEGUROS.V0RELATORIOS
            WHERE CODRELAT = 'SI0077B'
            AND IDSISTEM = 'SI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.V0RELATORIOS
				WHERE CODRELAT = 'SI0077B'
				AND IDSISTEM = 'SI'";

            return query;
        }

        public static void Execute(M_9999_00_ENCERRA_DB_DELETE_1_Delete1 m_9999_00_ENCERRA_DB_DELETE_1_Delete1)
        {
            var ths = m_9999_00_ENCERRA_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_9999_00_ENCERRA_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}