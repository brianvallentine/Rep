using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0106B
{
    public class M_015_000_PROCESSA_DB_UPDATE_1_Update1 : QueryBasis<M_015_000_PROCESSA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V1RELATORIOS
				SET SITUACAO = '1'
				WHERE  CODRELAT = 'VP0106B'
				AND SITUACAO = '0'
				AND NRCOPIAS =  '{this.NRCOPIAS}'";

            return query;
        }
        public string NRCOPIAS { get; set; }

        public static void Execute(M_015_000_PROCESSA_DB_UPDATE_1_Update1 m_015_000_PROCESSA_DB_UPDATE_1_Update1)
        {
            var ths = m_015_000_PROCESSA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_015_000_PROCESSA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}