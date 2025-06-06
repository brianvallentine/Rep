using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0213B
{
    public class R0800_00_EXCLUI_RELATORI_DB_DELETE_1_Delete1 : QueryBasis<R0800_00_EXCLUI_RELATORI_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM SEGUROS.RELATORIOS
            WHERE COD_RELATORIO = 'SI0213B1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.RELATORIOS
				WHERE COD_RELATORIO = 'SI0213B1'";

            return query;
        }

        public static void Execute(R0800_00_EXCLUI_RELATORI_DB_DELETE_1_Delete1 r0800_00_EXCLUI_RELATORI_DB_DELETE_1_Delete1)
        {
            var ths = r0800_00_EXCLUI_RELATORI_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0800_00_EXCLUI_RELATORI_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}