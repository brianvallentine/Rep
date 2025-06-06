using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0843B
{
    public class R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 : QueryBasis<R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL DELETE
            FROM SEGUROS.V0RELATORIOS
            WHERE IDSISTEM = 'SI'
            AND CODRELAT = 'SI0843B'
            AND DATA_SOLICITACAO = :V0DTMOVABE
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE
				FROM SEGUROS.V0RELATORIOS
				WHERE IDSISTEM = 'SI'
				AND CODRELAT = 'SI0843B'
				AND DATA_SOLICITACAO = '{this.V0DTMOVABE}'";

            return query;
        }
        public string V0DTMOVABE { get; set; }

        public static void Execute(R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 r0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1)
        {
            var ths = r0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}