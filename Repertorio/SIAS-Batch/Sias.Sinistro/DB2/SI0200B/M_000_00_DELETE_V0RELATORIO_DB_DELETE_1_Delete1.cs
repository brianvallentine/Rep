using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0200B
{
    public class M_000_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1 : QueryBasis<M_000_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL DELETE
            FROM SEGUROS.V0RELATORIOS
            WHERE IDSISTEM = 'SI'
            AND CODUSU = 'SI0200B'
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE
				FROM SEGUROS.V0RELATORIOS
				WHERE IDSISTEM = 'SI'
				AND CODUSU = 'SI0200B'";

            return query;
        }

        public static void Execute(M_000_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1 m_000_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1)
        {
            var ths = m_000_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_000_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}