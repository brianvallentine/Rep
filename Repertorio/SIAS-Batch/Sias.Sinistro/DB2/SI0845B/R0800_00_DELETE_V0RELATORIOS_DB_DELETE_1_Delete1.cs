using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0845B
{
    public class R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 : QueryBasis<R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL DELETE
            FROM SEGUROS.V0RELATORIOS
            WHERE CODRELAT = :V1RELA-CODRELAT
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE
				FROM SEGUROS.V0RELATORIOS
				WHERE CODRELAT = '{this.V1RELA_CODRELAT}'
				AND SITUACAO = '0'";

            return query;
        }
        public string V1RELA_CODRELAT { get; set; }

        public static void Execute(R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 r0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1)
        {
            var ths = r0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}