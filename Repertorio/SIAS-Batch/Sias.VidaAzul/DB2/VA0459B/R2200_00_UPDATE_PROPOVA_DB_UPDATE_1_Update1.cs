using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0459B
{
    public class R2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1 : QueryBasis<R2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET SIT_REGISTRO = '2' ,
				DATA_MOVIMENTO =  '{this.V1SIST_DTMOVABE}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_CERTIFICADO =  '{this.V0PROP_NRCERTIF}'";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static void Execute(R2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1 r2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1)
        {
            var ths = r2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}