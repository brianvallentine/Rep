using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI3041B
{
    public class R0120_00_DELETE_RELATORIOS_DB_DELETE_1_Delete1 : QueryBasis<R0120_00_DELETE_RELATORIOS_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM SEGUROS.RELATORIOS
            WHERE IDE_SISTEMA = 'SI'
            AND COD_RELATORIO = 'SI3041B'
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.RELATORIOS
				WHERE IDE_SISTEMA = 'SI'
				AND COD_RELATORIO = 'SI3041B'";

            return query;
        }

        public static void Execute(R0120_00_DELETE_RELATORIOS_DB_DELETE_1_Delete1 r0120_00_DELETE_RELATORIOS_DB_DELETE_1_Delete1)
        {
            var ths = r0120_00_DELETE_RELATORIOS_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0120_00_DELETE_RELATORIOS_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}