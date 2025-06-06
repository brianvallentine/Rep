using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0848B
{
    public class R0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1 : QueryBasis<R0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM SEGUROS.V0RELATORIOS
            WHERE IDSISTEM = 'SI'
            AND DATA_SOLICITACAO = :V0SIST-DTMOVABE
            AND CODRELAT = 'SI0848B'
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.V0RELATORIOS
				WHERE IDSISTEM = 'SI'
				AND DATA_SOLICITACAO = '{this.V0SIST_DTMOVABE}'
				AND CODRELAT = 'SI0848B'";

            return query;
        }
        public string V0SIST_DTMOVABE { get; set; }

        public static void Execute(R0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1 r0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1)
        {
            var ths = r0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0000_90_FINALIZACAO_2_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}