using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0458B
{
    public class R3170_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1 : QueryBasis<R3170_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET SIT_REGISTRO = '0' ,
				TIMESTAMP = CURRENT TIMESTAMP,
				COD_USUARIO = 'VA0458B'
				WHERE NUM_CERTIFICADO =  '{this.V0PROP_NRCERTIF}'";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }

        public static void Execute(R3170_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1 r3170_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1)
        {
            var ths = r3170_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3170_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}