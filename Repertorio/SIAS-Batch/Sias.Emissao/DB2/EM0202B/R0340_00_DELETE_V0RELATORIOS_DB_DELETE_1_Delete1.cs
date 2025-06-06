using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R0340_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 : QueryBasis<R0340_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM SEGUROS.V0RELATORIOS
            WHERE CODRELAT = 'EM0202B1'
            AND DATA_SOLICITACAO = :V1SIST-DTMOVABE
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.V0RELATORIOS
				WHERE CODRELAT = 'EM0202B1'
				AND DATA_SOLICITACAO = '{this.V1SIST_DTMOVABE}'
				AND SITUACAO = '0'";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }

        public static void Execute(R0340_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 r0340_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1)
        {
            var ths = r0340_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0340_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}