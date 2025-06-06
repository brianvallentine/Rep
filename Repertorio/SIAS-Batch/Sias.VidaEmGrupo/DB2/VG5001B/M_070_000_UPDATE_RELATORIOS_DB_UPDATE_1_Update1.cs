using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG5001B
{
    public class M_070_000_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 : QueryBasis<M_070_000_UPDATE_RELATORIOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RELATORIOS
				SET SITUACAO = '1' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  CODRELAT = 'VG5001B1'
				AND SITUACAO = '0'";

            return query;
        }

        public static void Execute(M_070_000_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 m_070_000_UPDATE_RELATORIOS_DB_UPDATE_1_Update1)
        {
            var ths = m_070_000_UPDATE_RELATORIOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_070_000_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}