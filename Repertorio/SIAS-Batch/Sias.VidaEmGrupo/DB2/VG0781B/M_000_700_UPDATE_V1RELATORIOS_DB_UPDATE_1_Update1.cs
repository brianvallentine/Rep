using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0781B
{
    public class M_000_700_UPDATE_V1RELATORIOS_DB_UPDATE_1_Update1 : QueryBasis<M_000_700_UPDATE_V1RELATORIOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V1RELATORIOS
				SET SITUACAO = '1'
				WHERE  IDSISTEM = 'VG' AND
				CODRELAT = 'VG0781B' AND
				SITUACAO = '0'";

            return query;
        }

        public static void Execute(M_000_700_UPDATE_V1RELATORIOS_DB_UPDATE_1_Update1 m_000_700_UPDATE_V1RELATORIOS_DB_UPDATE_1_Update1)
        {
            var ths = m_000_700_UPDATE_V1RELATORIOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_000_700_UPDATE_V1RELATORIOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}