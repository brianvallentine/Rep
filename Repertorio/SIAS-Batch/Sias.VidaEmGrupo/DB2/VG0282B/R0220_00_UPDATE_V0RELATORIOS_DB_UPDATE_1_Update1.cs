using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0282B
{
    public class R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 : QueryBasis<R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RELATORIOS
				SET SITUACAO = '1' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  CODRELAT = 'VG0282B1'
				AND SITUACAO = '0'";

            return query;
        }

        public static void Execute(R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 r0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1)
        {
            var ths = r0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}