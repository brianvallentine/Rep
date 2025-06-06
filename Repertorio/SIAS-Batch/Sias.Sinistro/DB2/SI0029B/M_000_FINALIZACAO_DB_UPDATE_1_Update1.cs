using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0029B
{
    public class M_000_FINALIZACAO_DB_UPDATE_1_Update1 : QueryBasis<M_000_FINALIZACAO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RELATORIOS
				SET SITUACAO = '1'
				WHERE  CODRELAT = 'SI0029B'
				AND DATA_SOLICITACAO =  '{this.SIST_DTMOVABE}'
				AND SITUACAO = '0'";

            return query;
        }
        public string SIST_DTMOVABE { get; set; }

        public static void Execute(M_000_FINALIZACAO_DB_UPDATE_1_Update1 m_000_FINALIZACAO_DB_UPDATE_1_Update1)
        {
            var ths = m_000_FINALIZACAO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_000_FINALIZACAO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}