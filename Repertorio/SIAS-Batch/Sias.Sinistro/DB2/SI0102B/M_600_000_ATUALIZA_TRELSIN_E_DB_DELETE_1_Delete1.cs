using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0102B
{
    public class M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1 : QueryBasis<M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL DELETE FROM
            SEGUROS.V0RELATORIOS
            WHERE
            IDSISTEM = 'SI'
            AND CODRELAT = 'SI0102B'
            AND DATA_SOLICITACAO = :TSISTEMA-DTMOVABE
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM
				SEGUROS.V0RELATORIOS
				WHERE
				IDSISTEM = 'SI'
				AND CODRELAT = 'SI0102B'
				AND DATA_SOLICITACAO = '{this.TSISTEMA_DTMOVABE}'";

            return query;
        }
        public string TSISTEMA_DTMOVABE { get; set; }

        public static void Execute(M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1 m_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1)
        {
            var ths = m_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_600_000_ATUALIZA_TRELSIN_E_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}