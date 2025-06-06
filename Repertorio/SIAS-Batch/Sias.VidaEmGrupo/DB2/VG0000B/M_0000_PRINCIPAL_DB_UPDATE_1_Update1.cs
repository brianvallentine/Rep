using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0000B
{
    public class M_0000_PRINCIPAL_DB_UPDATE_1_Update1 : QueryBasis<M_0000_PRINCIPAL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PROPOSTAVA
				SET OCORHIST = 17
				WHERE  NRCERTIF = 10020079849";

            return query;
        }

        public static void Execute(M_0000_PRINCIPAL_DB_UPDATE_1_Update1 m_0000_PRINCIPAL_DB_UPDATE_1_Update1)
        {
            var ths = m_0000_PRINCIPAL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0000_PRINCIPAL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}