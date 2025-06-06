using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0814B
{
    public class M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1 : QueryBasis<M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL DELETE FROM
            SEGUROS.V0RELATORIOS
            WHERE
            IDSISTEM = 'SI'
            AND CODRELAT = 'SI0814B'
            AND DATA_SOLICITACAO = :SIST-DTMOVABE
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM
				SEGUROS.V0RELATORIOS
				WHERE
				IDSISTEM = 'SI'
				AND CODRELAT = 'SI0814B'
				AND DATA_SOLICITACAO = '{this.SIST_DTMOVABE}'";

            return query;
        }
        public string SIST_DTMOVABE { get; set; }

        public static void Execute(M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1 m_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1)
        {
            var ths = m_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_590_000_ATUALIZA_TRELSIN_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}