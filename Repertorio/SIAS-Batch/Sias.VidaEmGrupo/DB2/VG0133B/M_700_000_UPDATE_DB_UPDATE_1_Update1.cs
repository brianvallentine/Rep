using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0133B
{
    public class M_700_000_UPDATE_DB_UPDATE_1_Update1 : QueryBasis<M_700_000_UPDATE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0SOLICUNICOVGAP
				SET SITUACAO = '1'
				WHERE  SITUACAO = '0'";

            return query;
        }

        public static void Execute(M_700_000_UPDATE_DB_UPDATE_1_Update1 m_700_000_UPDATE_DB_UPDATE_1_Update1)
        {
            var ths = m_700_000_UPDATE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_700_000_UPDATE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}