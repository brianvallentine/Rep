using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0050B
{
    public class R0210_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1 : QueryBasis<R0210_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL DELETE
            FROM SEGUROS.V0RELATORIOS
            WHERE CODRELAT = 'VP0050B1'
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE
				FROM SEGUROS.V0RELATORIOS
				WHERE CODRELAT = 'VP0050B1'
				AND SITUACAO = '0'";

            return query;
        }

        public static void Execute(R0210_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1 r0210_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1)
        {
            var ths = r0210_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0210_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}