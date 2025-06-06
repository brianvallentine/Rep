using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0099B
{
    public class R2950_UPT_PROPOSTAS_VA_DB_UPDATE_1_Update1 : QueryBasis<R2950_UPT_PROPOSTAS_VA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET SIT_INTERFACE =  '{this.PROPOVA_SIT_INTERFACE}'
				WHERE  NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPOVA_SIT_INTERFACE { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R2950_UPT_PROPOSTAS_VA_DB_UPDATE_1_Update1 r2950_UPT_PROPOSTAS_VA_DB_UPDATE_1_Update1)
        {
            var ths = r2950_UPT_PROPOSTAS_VA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2950_UPT_PROPOSTAS_VA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}