using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0229B
{
    public class S4000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 : QueryBasis<S4000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL DELETE FROM
            SEGUROS.V0RELATORIOS
            WHERE CODRELAT = 'EM0230B1'
            AND DATA_SOLICITACAO = :V1SIST-DTMOVABE
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM
				SEGUROS.V0RELATORIOS
				WHERE CODRELAT = 'EM0230B1'
				AND DATA_SOLICITACAO = '{this.V1SIST_DTMOVABE}'";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }

        public static void Execute(S4000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 s4000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1)
        {
            var ths = s4000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override S4000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}