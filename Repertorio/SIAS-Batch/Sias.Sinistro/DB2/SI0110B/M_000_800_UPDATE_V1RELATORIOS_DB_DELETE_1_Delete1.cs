using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0110B
{
    public class M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1 : QueryBasis<M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM SEGUROS.V0RELATORIOS
            WHERE IDSISTEM = 'SI' AND
            CODRELAT = 'SI0110B' AND
            DATA_SOLICITACAO = :V1SISTEMA-DTMOVABE
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.V0RELATORIOS
				WHERE IDSISTEM = 'SI' AND
				CODRELAT = 'SI0110B' AND
				DATA_SOLICITACAO = '{this.V1SISTEMA_DTMOVABE}'";

            return query;
        }
        public string V1SISTEMA_DTMOVABE { get; set; }

        public static void Execute(M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1 m_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1)
        {
            var ths = m_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}